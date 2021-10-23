using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMuter
{
    public class TrayMonitor : IDisposable
    {
        #region Fields

        private readonly IDictionary<MicrophoneStatus, Icon> microphoneIcons;
        private readonly NotifyIcon notifyIcon;
        private readonly MicrophoneController microphoneController;
        private readonly Configuration configuration;
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
            contextMenu.Items.Add("&Visit Website", null, (s, e) => Program.VisitWebsite());
            contextMenu.Items.Add("-");
            var toggleMicrophoneMenuItem = contextMenu.Items.Add("&Toggle Microphone", null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Toggle));
            toggleMicrophoneMenuItem.Font = new Font(toggleMicrophoneMenuItem.Font, toggleMicrophoneMenuItem.Font.Style | FontStyle.Bold);
            contextMenu.Items.Add("&Mute Microphone", null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Mute));
            contextMenu.Items.Add("&Unmute Microphone", null, (s, e) => PerformMicrophoneAction(MicrophoneAction.Unmute));
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("E&xit", null, Exit);

            // Initialize notification icon.
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.ContextMenuStrip = contextMenu;
            this.notifyIcon.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
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
            try
            {
                this.keyboardHook.RegisterHotKey(this.configuration.MicrophoneToggleHotKeyModifier, this.configuration.MicrophoneToggleHotKey);
            }
            catch (InvalidOperationException)
            {
                // Couldn't register the hot key.
                this.notifyIcon.ShowBalloonTip(10000, Configuration.AppName, "The keyboard shortcut couldn't be registered, perhaps another app already registered it?", ToolTipIcon.Warning);
            }

            // Run on startup.
            using (var runKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (this.configuration.RunOnStartup)
                {
                    runKey.SetValue(Configuration.AppName, $"\"{Application.ExecutablePath}\"");
                }
                else
                {
                    runKey.DeleteValue(Configuration.AppName, false);
                }
            }
        }

        private void KeyboardHookPressed(object sender, KeyPressedEventArgs e)
        {
            PerformMicrophoneAction(MicrophoneAction.Toggle);
        }

        private void PerformMicrophoneAction(MicrophoneAction action)
        {
            this.microphoneController.PerformAction(action);
        }

        private void UpdateUI()
        {
            var status = this.microphoneController.GetStatus();
            this.notifyIcon.Icon = this.microphoneIcons[status];
            this.notifyIcon.Text = GetStatusDescription(status);
        }

        private string GetStatusDescription(MicrophoneStatus status)
        {
            if (status == MicrophoneStatus.NotInUse)
            {
                return "No microphone is currently in use.";
            }
            else if (status == MicrophoneStatus.Muted)
            {
                return "Your microphone is currently muted.";
            }
            else
            {
                return "Your microphone is currently unmuted.";
            }
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