
namespace MicMuter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.runOnStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.microphoneToggleHotKeyTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.helpLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.windowsKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.altCheckBox = new System.Windows.Forms.CheckBox();
            this.controlCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // runOnStartupCheckbox
            // 
            this.runOnStartupCheckbox.AutoSize = true;
            this.runOnStartupCheckbox.Location = new System.Drawing.Point(15, 89);
            this.runOnStartupCheckbox.Name = "runOnStartupCheckbox";
            this.runOnStartupCheckbox.Size = new System.Drawing.Size(210, 17);
            this.runOnStartupCheckbox.TabIndex = 1;
            this.runOnStartupCheckbox.Text = "&Automatically run when Windows starts";
            this.runOnStartupCheckbox.UseVisualStyleBackColor = true;
            // 
            // microphoneToggleHotKeyTextBox
            // 
            this.microphoneToggleHotKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.microphoneToggleHotKeyTextBox.Location = new System.Drawing.Point(324, 51);
            this.microphoneToggleHotKeyTextBox.Name = "microphoneToggleHotKeyTextBox";
            this.microphoneToggleHotKeyTextBox.ShortcutsEnabled = false;
            this.microphoneToggleHotKeyTextBox.Size = new System.Drawing.Size(88, 20);
            this.microphoneToggleHotKeyTextBox.TabIndex = 0;
            this.microphoneToggleHotKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.microphoneToggleHotKeyTextBox_KeyDown);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(256, 146);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(337, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.Location = new System.Drawing.Point(12, 151);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(46, 13);
            this.websiteLinkLabel.TabIndex = 2;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "Website";
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.Location = new System.Drawing.Point(12, 9);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(400, 39);
            this.helpLabel.TabIndex = 5;
            this.helpLabel.Text = "When your microphone is being used, it will be toggled on or off when you press t" +
    "he shortcut key below or click the icon in the notification area.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Shortcut Key:";
            // 
            // windowsKeyCheckBox
            // 
            this.windowsKeyCheckBox.AutoSize = true;
            this.windowsKeyCheckBox.Location = new System.Drawing.Point(248, 53);
            this.windowsKeyCheckBox.Name = "windowsKeyCheckBox";
            this.windowsKeyCheckBox.Size = new System.Drawing.Size(70, 17);
            this.windowsKeyCheckBox.TabIndex = 10;
            this.windowsKeyCheckBox.Text = "&Windows";
            this.windowsKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // altCheckBox
            // 
            this.altCheckBox.AutoSize = true;
            this.altCheckBox.Location = new System.Drawing.Point(86, 53);
            this.altCheckBox.Name = "altCheckBox";
            this.altCheckBox.Size = new System.Drawing.Size(38, 17);
            this.altCheckBox.TabIndex = 7;
            this.altCheckBox.Text = "A&lt";
            this.altCheckBox.UseVisualStyleBackColor = true;
            // 
            // controlCheckBox
            // 
            this.controlCheckBox.AutoSize = true;
            this.controlCheckBox.Location = new System.Drawing.Point(130, 53);
            this.controlCheckBox.Name = "controlCheckBox";
            this.controlCheckBox.Size = new System.Drawing.Size(59, 17);
            this.controlCheckBox.TabIndex = 8;
            this.controlCheckBox.Text = "Co&ntrol";
            this.controlCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftCheckBox
            // 
            this.shiftCheckBox.AutoSize = true;
            this.shiftCheckBox.Location = new System.Drawing.Point(195, 53);
            this.shiftCheckBox.Name = "shiftCheckBox";
            this.shiftCheckBox.Size = new System.Drawing.Size(47, 17);
            this.shiftCheckBox.TabIndex = 9;
            this.shiftCheckBox.Text = "S&hift";
            this.shiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(424, 181);
            this.Controls.Add(this.shiftCheckBox);
            this.Controls.Add(this.controlCheckBox);
            this.Controls.Add(this.altCheckBox);
            this.Controls.Add(this.windowsKeyCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.websiteLinkLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.microphoneToggleHotKeyTextBox);
            this.Controls.Add(this.runOnStartupCheckbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 220);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox runOnStartupCheckbox;
        private System.Windows.Forms.TextBox microphoneToggleHotKeyTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.LinkLabel websiteLinkLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox windowsKeyCheckBox;
        private System.Windows.Forms.CheckBox altCheckBox;
        private System.Windows.Forms.CheckBox controlCheckBox;
        private System.Windows.Forms.CheckBox shiftCheckBox;
    }
}

