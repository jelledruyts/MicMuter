using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMuter
{
    public class TrayMonitor : IDisposable
    {
        #region Constants

        private const string MenuItemTextPrefixToggleMicrophone = "&Toggle Microphone";
        private const string MenuItemTextPrefixMuteMicrophone = "&Mute Microphone";
        private const string MenuItemTextPrefixUnmuteMicrophone = "&Unmute Microphone";

        #endregion

        #region Fields

        private readonly IDictionary<MicrophoneStatus, Icon> microphoneIcons;
        private readonly NotifyIcon notifyIcon;
        private readonly MicrophoneController microphoneController;
        private readonly Configuration configuration;
        private readonly ToolStripItem toggleMicrophoneMenuItem;
        private readonly ToolStripItem muteMicrophoneMenuItem;
        private readonly ToolStripItem unmuteMicrophoneMenuItem;
        private KeyboardHook keyboardHook;
        private MainForm mainForm;

        #endregion

        #region Constructors

        public TrayMonitor()
        {
            // Load embedded resources.
            this.microphoneIcons = new Dictionary<MicrophoneStatus, Icon>();
            foreach (var status in Enum.GetValues(typeof(MicrophoneStatus)).Cast<MicrophoneStatus>())
            {
                using (var stream = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), $"Resources.Microphone{status.ToString()}.ico"))
                {
                    this.microphoneIcons[status] = new Icon(stream);
                }
            }

            // Load configuration.
            this.configuration = Configuration.Load();

            // Initialize microphone controller.
            this.microphoneController = new MicrophoneController();
            this.microphoneController.OnMicrophoneStateChanged += (s, e) => UpdateUI();

            // Initialize notification icon context menu.
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("&Settings...", null, (s, e) => ShowSettings());
            contextMenu.Items.Add("&Visit Website", null, (s, e) => Helper.VisitWebsite());
            contextMenu.Items.Add("-");
            this.toggleMicrophoneMenuItem = contextMenu.Items.Add(MenuItemTextPrefixToggleMicrophone, null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Toggle));
            this.toggleMicrophoneMenuItem.Font = new Font(toggleMicrophoneMenuItem.Font, toggleMicrophoneMenuItem.Font.Style | FontStyle.Bold);
            this.muteMicrophoneMenuItem = contextMenu.Items.Add(MenuItemTextPrefixMuteMicrophone, null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Mute));
            this.unmuteMicrophoneMenuItem = contextMenu.Items.Add(MenuItemTextPrefixUnmuteMicrophone, null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Unmute));
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("E&xit", null, Exit);

            // Initialize notification icon.
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.ContextMenuStrip = contextMenu;
            this.notifyIcon.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Logger.LogMessage(TraceEventType.Information, $"Notification icon was clicked, toggling microphone");
                    PerformMicrophoneAction(MicrophoneAction.Toggle);
                }
            };
            UpdateUI();
            this.notifyIcon.Visible = true;

            // Show configuration settings on first run, otherwise apply configuration.
            if (this.configuration.IsFirstRun)
            {
                ShowSettings();
            }
            else
            {
                ApplyConfiguration();
            }
        }

        #endregion

        #region Helper Methods

        private void ShowSettings()
        {
            if (this.mainForm == null || this.mainForm.IsDisposed)
            {
                this.mainForm = new MainForm(this.configuration);
                this.mainForm.FormClosed += (s, e) =>
                {
                    if (this.mainForm.DialogResult == DialogResult.OK)
                    {
                        Logger.LogMessage(TraceEventType.Information, $"Settings changed, saving configuration");
                        Configuration.Save(this.configuration);
                        ApplyConfiguration();
                        UpdateUI();
                    }
                };
            }
            this.mainForm.Show();
            this.mainForm.BringToFront();
        }

        private void ApplyConfiguration()
        {
            // Initialize keyboard hook.
            if (this.keyboardHook != null)
            {
                this.keyboardHook.KeyPressed -= KeyboardHookPressed;
                this.keyboardHook.Dispose();
            }
            this.keyboardHook = new KeyboardHook();
            this.keyboardHook.KeyPressed += KeyboardHookPressed;
            var failedHotKeys = new List<string>(3);
            TryRegisterHotKey(this.configuration.MicrophoneToggleHotKeyModifier, this.configuration.MicrophoneToggleHotKey, this.toggleMicrophoneMenuItem, "&Toggle Microphone", failedHotKeys);
            TryRegisterHotKey(this.configuration.MicrophoneMuteHotKeyModifier, this.configuration.MicrophoneMuteHotKey, this.muteMicrophoneMenuItem, "&Mute Microphone", failedHotKeys);
            TryRegisterHotKey(this.configuration.MicrophoneUnmuteHotKeyModifier, this.configuration.MicrophoneUnmuteHotKey, this.unmuteMicrophoneMenuItem, "&Unmute Microphone", failedHotKeys);
            if (failedHotKeys.Count > 0)
            {
                var failedHotKeysDescription = string.Join(", ", failedHotKeys.Distinct().Select(f => $"\"{f}\""));
                this.notifyIcon.ShowBalloonTip(15000, Configuration.AppName, $"The {failedHotKeysDescription} keyboard shortcut(s) couldn't be registered, perhaps another app already registered them?", ToolTipIcon.Warning);
            }

            // Run on startup.
            using (var runKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (this.configuration.RunOnStartup)
                {
                    Logger.LogMessage(TraceEventType.Information, $"Applying Windows setting to run application on startup from \"{Application.ExecutablePath}\"");
                    runKey.SetValue(Configuration.AppName, $"\"{Application.ExecutablePath}\"");
                }
                else
                {
                    Logger.LogMessage(TraceEventType.Information, $"Removing Windows setting to run application on startup from \"{Application.ExecutablePath}\"");
                    runKey.DeleteValue(Configuration.AppName, false);
                }
            }
        }

        private void TryRegisterHotKey(ModifierKeys hotKeyModifier, Keys hotKey, ToolStripItem menuItem, string menuItemTextPrefix, IList<string> failedHotKeys)
        {
            menuItem.Text = menuItemTextPrefix;
            if (hotKey != Keys.None)
            {
                var description = Helper.GetHotKeyDescription(hotKeyModifier, hotKey);
                try
                {
                    Logger.LogMessage(TraceEventType.Information, $"Registering hot key for \"{description}\"");
                    this.keyboardHook.RegisterHotKey(hotKeyModifier, hotKey);
                    menuItem.Text += $" ({description})";
                }
                catch (InvalidOperationException)
                {
                    // Couldn't register the hot key; add the description to the failure list so it can be displayed in the error.
                    Logger.LogMessage(TraceEventType.Error, $"Couldn't register hot key for \"{description}\"");
                    failedHotKeys.Add(description);
                }
            }
        }

        private void KeyboardHookPressed(object sender, KeyPressedEventArgs e)
        {
            Logger.LogMessage(TraceEventType.Information, $"Detected hot key \"{Helper.GetHotKeyDescription(e.Modifier, e.Key)}\"");
            if (e.Modifier == this.configuration.MicrophoneToggleHotKeyModifier && e.Key == this.configuration.MicrophoneToggleHotKey)
            {
                PerformMicrophoneAction(MicrophoneAction.Toggle);
            }
            else if (e.Modifier == this.configuration.MicrophoneMuteHotKeyModifier && e.Key == this.configuration.MicrophoneMuteHotKey)
            {
                PerformMicrophoneAction(MicrophoneAction.Mute);
            }
            else if (e.Modifier == this.configuration.MicrophoneUnmuteHotKeyModifier && e.Key == this.configuration.MicrophoneUnmuteHotKey)
            {
                PerformMicrophoneAction(MicrophoneAction.Unmute);
            }
        }

        private void PerformMicrophoneAction(MicrophoneAction action)
        {
            this.microphoneController.PerformAction(action);
        }

        private void UpdateUI()
        {
            Logger.LogMessage(TraceEventType.Verbose, $"Updating UI");
            var status = this.microphoneController.GetStatus();
            Logger.LogMessage(TraceEventType.Verbose, $"Setting UI status to \"{status}\"");
            this.notifyIcon.Icon = this.microphoneIcons[status];
            this.notifyIcon.Text = Helper.GetStatusDescription(status);
        }

        #endregion

        #region Shutdown

        private void Exit(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        public void Dispose()
        {
            this.microphoneController.Dispose();
            if (this.keyboardHook != null)
            {
                this.keyboardHook.Dispose();
                this.keyboardHook = null;
            }
            this.notifyIcon.Dispose();
        }

        #endregion
    }
}