using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MicMuter
{
    public partial class MainForm : Form
    {
        private static readonly Keys[] ShiftModifierKeys = new[] { Keys.Shift, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey };
        private static readonly Keys[] AltModifierKeys = new[] { Keys.Alt, Keys.Menu, Keys.LMenu, Keys.RMenu };
        private static readonly Keys[] ControlModifierKeys = new[] { Keys.Control, Keys.ControlKey, Keys.LControlKey, Keys.RControlKey };
        private static readonly Keys[] WinModifierKeys = new[] { Keys.LWin, Keys.RWin };
        private static readonly Keys[] ExcludedModifierKeys = ShiftModifierKeys.Concat(AltModifierKeys).Concat(ControlModifierKeys).Concat(WinModifierKeys).ToArray();
        private Keys currentMicrophoneToggleHotKey;

        private readonly Configuration configuration;

        public MainForm(Configuration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.altCheckBox.Checked = this.configuration.MicrophoneToggleHotKeyModifier.HasFlag(MicMuter.ModifierKeys.Alt);
            this.controlCheckBox.Checked = this.configuration.MicrophoneToggleHotKeyModifier.HasFlag(MicMuter.ModifierKeys.Control);
            this.shiftCheckBox.Checked = this.configuration.MicrophoneToggleHotKeyModifier.HasFlag(MicMuter.ModifierKeys.Shift);
            this.windowsKeyCheckBox.Checked = this.configuration.MicrophoneToggleHotKeyModifier.HasFlag(MicMuter.ModifierKeys.Win);
            this.currentMicrophoneToggleHotKey = this.configuration.MicrophoneToggleHotKey;
            this.runOnStartupCheckbox.Checked = this.configuration.RunOnStartup;
            this.microphoneToggleHotKeyTextBox.Text = this.currentMicrophoneToggleHotKey.ToString();
            this.Text = $"{Configuration.AppName} v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)}";
            this.websiteLinkLabel.Text = Configuration.AppWebsite;
            this.websiteLinkLabel.Links.Add(0, this.websiteLinkLabel.Text.Length);
        }

        private void microphoneToggleHotKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ExcludedModifierKeys.Contains(e.KeyCode))
            {
                this.currentMicrophoneToggleHotKey = e.KeyCode;
                this.microphoneToggleHotKeyTextBox.Text = this.currentMicrophoneToggleHotKey.ToString();
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.VisitWebsite();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var modifier = MicMuter.ModifierKeys.None;
            if (this.altCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Alt;
            if (this.controlCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Control;
            if (this.shiftCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Shift;
            if (this.windowsKeyCheckBox.Checked) modifier |= MicMuter.ModifierKeys.Win;
            this.configuration.MicrophoneToggleHotKeyModifier = modifier;
            this.configuration.MicrophoneToggleHotKey = currentMicrophoneToggleHotKey;
            this.configuration.RunOnStartup = this.runOnStartupCheckbox.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
