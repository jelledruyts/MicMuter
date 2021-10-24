using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MicMuter
{
    public partial class MainForm : Form
    {
        #region Fields
        private static readonly Keys[] ShiftModifierKeys = new[] { Keys.Shift, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey };
        private static readonly Keys[] AltModifierKeys = new[] { Keys.Alt, Keys.Menu, Keys.LMenu, Keys.RMenu };
        private static readonly Keys[] ControlModifierKeys = new[] { Keys.Control, Keys.ControlKey, Keys.LControlKey, Keys.RControlKey };
        private static readonly Keys[] WinModifierKeys = new[] { Keys.LWin, Keys.RWin };
        private static readonly Keys[] ExcludedModifierKeys = ShiftModifierKeys.Concat(AltModifierKeys).Concat(ControlModifierKeys).Concat(WinModifierKeys).ToArray();

        private readonly Configuration configuration;

        #endregion

        #region Constructors

        public MainForm(Configuration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.Text = $"{Configuration.AppName} v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)}";
            this.websiteLinkLabel.Text = Configuration.AppWebsite;
            this.websiteLinkLabel.Links.Add(0, this.websiteLinkLabel.Text.Length);

            BindHotKey(this.configuration.MicrophoneToggleHotKeyModifier, this.configuration.MicrophoneToggleHotKey, this.microphoneToggleHotKeyAltCheckBox, this.microphoneToggleHotKeyControlCheckBox, this.microphoneToggleHotKeyShiftCheckBox, this.microphoneToggleHotKeyWindowsCheckBox, this.microphoneToggleHotKeyTextBox);
            BindHotKey(this.configuration.MicrophoneMuteHotKeyModifier, this.configuration.MicrophoneMuteHotKey, this.microphoneMuteHotKeyAltCheckBox, this.microphoneMuteHotKeyControlCheckBox, this.microphoneMuteHotKeyShiftCheckBox, this.microphoneMuteHotKeyWindowsCheckBox, this.microphoneMuteHotKeyTextBox);
            BindHotKey(this.configuration.MicrophoneUnmuteHotKeyModifier, this.configuration.MicrophoneUnmuteHotKey, this.microphoneUnmuteHotKeyAltCheckBox, this.microphoneUnmuteHotKeyControlCheckBox, this.microphoneUnmuteHotKeyShiftCheckBox, this.microphoneUnmuteHotKeyWindowsCheckBox, this.microphoneUnmuteHotKeyTextBox);
            this.runOnStartupCheckbox.Checked = this.configuration.RunOnStartup;
        }

        #endregion

        #region Event Handlers

        private void microphoneHotKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ExcludedModifierKeys.Contains(e.KeyCode))
            {
                var keyCode = e.KeyCode;
                if (keyCode == Keys.Back)
                {
                    // Pressing "back" means clear the hot key.
                    keyCode = Keys.None;
                }
                var textBox = (TextBox)sender;
                textBox.Tag = keyCode;
                textBox.Text = keyCode.ToString();
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Helper.VisitWebsite();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.configuration.MicrophoneToggleHotKeyModifier = UnbindHotKeyModifier(this.microphoneToggleHotKeyAltCheckBox, this.microphoneToggleHotKeyControlCheckBox, this.microphoneToggleHotKeyShiftCheckBox, this.microphoneToggleHotKeyWindowsCheckBox);
            this.configuration.MicrophoneToggleHotKey = UnbindHotKey(this.microphoneToggleHotKeyTextBox);
            this.configuration.MicrophoneMuteHotKeyModifier = UnbindHotKeyModifier(this.microphoneMuteHotKeyAltCheckBox, this.microphoneMuteHotKeyControlCheckBox, this.microphoneMuteHotKeyShiftCheckBox, this.microphoneMuteHotKeyWindowsCheckBox);
            this.configuration.MicrophoneMuteHotKey = UnbindHotKey(this.microphoneMuteHotKeyTextBox);
            this.configuration.MicrophoneUnmuteHotKeyModifier = UnbindHotKeyModifier(this.microphoneUnmuteHotKeyAltCheckBox, this.microphoneUnmuteHotKeyControlCheckBox, this.microphoneUnmuteHotKeyShiftCheckBox, this.microphoneUnmuteHotKeyWindowsCheckBox);
            this.configuration.MicrophoneUnmuteHotKey = UnbindHotKey(this.microphoneUnmuteHotKeyTextBox);
            this.configuration.RunOnStartup = this.runOnStartupCheckbox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Helper Methods

        private void BindHotKey(ModifierKeys hotKeyModifier, Keys hotKey, CheckBox altCheckBox, CheckBox controlCheckBox, CheckBox shiftCheckBox, CheckBox windowsCheckBox, TextBox hotKeyTextBox)
        {
            altCheckBox.Checked = hotKeyModifier.HasFlag(MicMuter.ModifierKeys.Alt);
            controlCheckBox.Checked = hotKeyModifier.HasFlag(MicMuter.ModifierKeys.Control);
            shiftCheckBox.Checked = hotKeyModifier.HasFlag(MicMuter.ModifierKeys.Shift);
            windowsCheckBox.Checked = hotKeyModifier.HasFlag(MicMuter.ModifierKeys.Win);
            hotKeyTextBox.Tag = hotKey;
            hotKeyTextBox.Text = hotKey.ToString();
        }

        private ModifierKeys UnbindHotKeyModifier(CheckBox altCheckBox, CheckBox controlCheckBox, CheckBox shiftCheckBox, CheckBox windowsCheckBox)
        {
            var modifier = MicMuter.ModifierKeys.None;
            if (altCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Alt;
            if (controlCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Control;
            if (shiftCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Shift;
            if (windowsCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Win;
            return modifier;
        }

        private Keys UnbindHotKey(TextBox hotKeyTextBox)
        {
            return (Keys)hotKeyTextBox.Tag;
        }

        #endregion
    }
}