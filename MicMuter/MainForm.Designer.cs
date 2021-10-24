
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
            this.microphoneToggleHotKeyLabel = new System.Windows.Forms.Label();
            this.microphoneToggleHotKeyWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneToggleHotKeyAltCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneToggleHotKeyControlCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneToggleHotKeyShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneMuteHotKeyTextBox = new System.Windows.Forms.TextBox();
            this.microphoneMuteHotKeyLabel = new System.Windows.Forms.Label();
            this.microphoneMuteHotKeyWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneMuteHotKeyAltCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneMuteHotKeyControlCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneMuteHotKeyShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneUnmuteHotKeyTextBox = new System.Windows.Forms.TextBox();
            this.microphoneUnmuteHotKeyLabel = new System.Windows.Forms.Label();
            this.microphoneUnmuteHotKeyWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneUnmuteHotKeyAltCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneUnmuteHotKeyControlCheckBox = new System.Windows.Forms.CheckBox();
            this.microphoneUnmuteHotKeyShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // runOnStartupCheckbox
            // 
            this.runOnStartupCheckbox.AutoSize = true;
            this.runOnStartupCheckbox.Location = new System.Drawing.Point(22, 201);
            this.runOnStartupCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.runOnStartupCheckbox.Name = "runOnStartupCheckbox";
            this.runOnStartupCheckbox.Size = new System.Drawing.Size(310, 24);
            this.runOnStartupCheckbox.TabIndex = 19;
            this.runOnStartupCheckbox.Text = "&Automatically run when Windows starts";
            this.runOnStartupCheckbox.UseVisualStyleBackColor = true;
            // 
            // microphoneToggleHotKeyTextBox
            // 
            this.microphoneToggleHotKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.microphoneToggleHotKeyTextBox.Location = new System.Drawing.Point(486, 78);
            this.microphoneToggleHotKeyTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneToggleHotKeyTextBox.Name = "microphoneToggleHotKeyTextBox";
            this.microphoneToggleHotKeyTextBox.ShortcutsEnabled = false;
            this.microphoneToggleHotKeyTextBox.Size = new System.Drawing.Size(112, 26);
            this.microphoneToggleHotKeyTextBox.TabIndex = 6;
            this.microphoneToggleHotKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.microphoneHotKeyTextBox_KeyDown);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(366, 271);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(112, 35);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(488, 271);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 35);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.Location = new System.Drawing.Point(18, 278);
            this.websiteLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(67, 20);
            this.websiteLinkLabel.TabIndex = 20;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "Website";
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.Location = new System.Drawing.Point(18, 14);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(582, 60);
            this.helpLabel.TabIndex = 0;
            this.helpLabel.Text = "When your microphone is being used, it will be toggled on or off when you press t" +
    "he shortcut keys below or click the icon in the notification area.";
            // 
            // microphoneToggleHotKeyLabel
            // 
            this.microphoneToggleHotKeyLabel.AutoSize = true;
            this.microphoneToggleHotKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.microphoneToggleHotKeyLabel.Location = new System.Drawing.Point(18, 83);
            this.microphoneToggleHotKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.microphoneToggleHotKeyLabel.Name = "microphoneToggleHotKeyLabel";
            this.microphoneToggleHotKeyLabel.Size = new System.Drawing.Size(68, 20);
            this.microphoneToggleHotKeyLabel.TabIndex = 1;
            this.microphoneToggleHotKeyLabel.Text = "Toggle:";
            // 
            // microphoneToggleHotKeyWindowsCheckBox
            // 
            this.microphoneToggleHotKeyWindowsCheckBox.AutoSize = true;
            this.microphoneToggleHotKeyWindowsCheckBox.Location = new System.Drawing.Point(372, 82);
            this.microphoneToggleHotKeyWindowsCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneToggleHotKeyWindowsCheckBox.Name = "microphoneToggleHotKeyWindowsCheckBox";
            this.microphoneToggleHotKeyWindowsCheckBox.Size = new System.Drawing.Size(99, 24);
            this.microphoneToggleHotKeyWindowsCheckBox.TabIndex = 5;
            this.microphoneToggleHotKeyWindowsCheckBox.Text = "&Windows";
            this.microphoneToggleHotKeyWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneToggleHotKeyAltCheckBox
            // 
            this.microphoneToggleHotKeyAltCheckBox.AutoSize = true;
            this.microphoneToggleHotKeyAltCheckBox.Location = new System.Drawing.Point(129, 82);
            this.microphoneToggleHotKeyAltCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneToggleHotKeyAltCheckBox.Name = "microphoneToggleHotKeyAltCheckBox";
            this.microphoneToggleHotKeyAltCheckBox.Size = new System.Drawing.Size(54, 24);
            this.microphoneToggleHotKeyAltCheckBox.TabIndex = 2;
            this.microphoneToggleHotKeyAltCheckBox.Text = "A&lt";
            this.microphoneToggleHotKeyAltCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneToggleHotKeyControlCheckBox
            // 
            this.microphoneToggleHotKeyControlCheckBox.AutoSize = true;
            this.microphoneToggleHotKeyControlCheckBox.Location = new System.Drawing.Point(195, 82);
            this.microphoneToggleHotKeyControlCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneToggleHotKeyControlCheckBox.Name = "microphoneToggleHotKeyControlCheckBox";
            this.microphoneToggleHotKeyControlCheckBox.Size = new System.Drawing.Size(86, 24);
            this.microphoneToggleHotKeyControlCheckBox.TabIndex = 3;
            this.microphoneToggleHotKeyControlCheckBox.Text = "Co&ntrol";
            this.microphoneToggleHotKeyControlCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneToggleHotKeyShiftCheckBox
            // 
            this.microphoneToggleHotKeyShiftCheckBox.AutoSize = true;
            this.microphoneToggleHotKeyShiftCheckBox.Location = new System.Drawing.Point(292, 82);
            this.microphoneToggleHotKeyShiftCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneToggleHotKeyShiftCheckBox.Name = "microphoneToggleHotKeyShiftCheckBox";
            this.microphoneToggleHotKeyShiftCheckBox.Size = new System.Drawing.Size(68, 24);
            this.microphoneToggleHotKeyShiftCheckBox.TabIndex = 4;
            this.microphoneToggleHotKeyShiftCheckBox.Text = "S&hift";
            this.microphoneToggleHotKeyShiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneMuteHotKeyTextBox
            // 
            this.microphoneMuteHotKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.microphoneMuteHotKeyTextBox.Location = new System.Drawing.Point(486, 113);
            this.microphoneMuteHotKeyTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneMuteHotKeyTextBox.Name = "microphoneMuteHotKeyTextBox";
            this.microphoneMuteHotKeyTextBox.ShortcutsEnabled = false;
            this.microphoneMuteHotKeyTextBox.Size = new System.Drawing.Size(112, 26);
            this.microphoneMuteHotKeyTextBox.TabIndex = 12;
            this.microphoneMuteHotKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.microphoneHotKeyTextBox_KeyDown);
            // 
            // microphoneMuteHotKeyLabel
            // 
            this.microphoneMuteHotKeyLabel.AutoSize = true;
            this.microphoneMuteHotKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.microphoneMuteHotKeyLabel.Location = new System.Drawing.Point(18, 118);
            this.microphoneMuteHotKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.microphoneMuteHotKeyLabel.Name = "microphoneMuteHotKeyLabel";
            this.microphoneMuteHotKeyLabel.Size = new System.Drawing.Size(54, 20);
            this.microphoneMuteHotKeyLabel.TabIndex = 7;
            this.microphoneMuteHotKeyLabel.Text = "Mute:";
            // 
            // microphoneMuteHotKeyWindowsCheckBox
            // 
            this.microphoneMuteHotKeyWindowsCheckBox.AutoSize = true;
            this.microphoneMuteHotKeyWindowsCheckBox.Location = new System.Drawing.Point(372, 117);
            this.microphoneMuteHotKeyWindowsCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneMuteHotKeyWindowsCheckBox.Name = "microphoneMuteHotKeyWindowsCheckBox";
            this.microphoneMuteHotKeyWindowsCheckBox.Size = new System.Drawing.Size(99, 24);
            this.microphoneMuteHotKeyWindowsCheckBox.TabIndex = 11;
            this.microphoneMuteHotKeyWindowsCheckBox.Text = "&Windows";
            this.microphoneMuteHotKeyWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneMuteHotKeyAltCheckBox
            // 
            this.microphoneMuteHotKeyAltCheckBox.AutoSize = true;
            this.microphoneMuteHotKeyAltCheckBox.Location = new System.Drawing.Point(129, 117);
            this.microphoneMuteHotKeyAltCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneMuteHotKeyAltCheckBox.Name = "microphoneMuteHotKeyAltCheckBox";
            this.microphoneMuteHotKeyAltCheckBox.Size = new System.Drawing.Size(54, 24);
            this.microphoneMuteHotKeyAltCheckBox.TabIndex = 8;
            this.microphoneMuteHotKeyAltCheckBox.Text = "A&lt";
            this.microphoneMuteHotKeyAltCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneMuteHotKeyControlCheckBox
            // 
            this.microphoneMuteHotKeyControlCheckBox.AutoSize = true;
            this.microphoneMuteHotKeyControlCheckBox.Location = new System.Drawing.Point(195, 117);
            this.microphoneMuteHotKeyControlCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneMuteHotKeyControlCheckBox.Name = "microphoneMuteHotKeyControlCheckBox";
            this.microphoneMuteHotKeyControlCheckBox.Size = new System.Drawing.Size(86, 24);
            this.microphoneMuteHotKeyControlCheckBox.TabIndex = 9;
            this.microphoneMuteHotKeyControlCheckBox.Text = "Co&ntrol";
            this.microphoneMuteHotKeyControlCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneMuteHotKeyShiftCheckBox
            // 
            this.microphoneMuteHotKeyShiftCheckBox.AutoSize = true;
            this.microphoneMuteHotKeyShiftCheckBox.Location = new System.Drawing.Point(292, 117);
            this.microphoneMuteHotKeyShiftCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneMuteHotKeyShiftCheckBox.Name = "microphoneMuteHotKeyShiftCheckBox";
            this.microphoneMuteHotKeyShiftCheckBox.Size = new System.Drawing.Size(68, 24);
            this.microphoneMuteHotKeyShiftCheckBox.TabIndex = 10;
            this.microphoneMuteHotKeyShiftCheckBox.Text = "S&hift";
            this.microphoneMuteHotKeyShiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneUnmuteHotKeyTextBox
            // 
            this.microphoneUnmuteHotKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.microphoneUnmuteHotKeyTextBox.Location = new System.Drawing.Point(486, 148);
            this.microphoneUnmuteHotKeyTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneUnmuteHotKeyTextBox.Name = "microphoneUnmuteHotKeyTextBox";
            this.microphoneUnmuteHotKeyTextBox.ShortcutsEnabled = false;
            this.microphoneUnmuteHotKeyTextBox.Size = new System.Drawing.Size(112, 26);
            this.microphoneUnmuteHotKeyTextBox.TabIndex = 18;
            this.microphoneUnmuteHotKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.microphoneHotKeyTextBox_KeyDown);
            // 
            // microphoneUnmuteHotKeyLabel
            // 
            this.microphoneUnmuteHotKeyLabel.AutoSize = true;
            this.microphoneUnmuteHotKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.microphoneUnmuteHotKeyLabel.Location = new System.Drawing.Point(18, 153);
            this.microphoneUnmuteHotKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.microphoneUnmuteHotKeyLabel.Name = "microphoneUnmuteHotKeyLabel";
            this.microphoneUnmuteHotKeyLabel.Size = new System.Drawing.Size(77, 20);
            this.microphoneUnmuteHotKeyLabel.TabIndex = 13;
            this.microphoneUnmuteHotKeyLabel.Text = "Unmute:";
            // 
            // microphoneUnmuteHotKeyWindowsCheckBox
            // 
            this.microphoneUnmuteHotKeyWindowsCheckBox.AutoSize = true;
            this.microphoneUnmuteHotKeyWindowsCheckBox.Location = new System.Drawing.Point(372, 152);
            this.microphoneUnmuteHotKeyWindowsCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneUnmuteHotKeyWindowsCheckBox.Name = "microphoneUnmuteHotKeyWindowsCheckBox";
            this.microphoneUnmuteHotKeyWindowsCheckBox.Size = new System.Drawing.Size(99, 24);
            this.microphoneUnmuteHotKeyWindowsCheckBox.TabIndex = 17;
            this.microphoneUnmuteHotKeyWindowsCheckBox.Text = "&Windows";
            this.microphoneUnmuteHotKeyWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneUnmuteHotKeyAltCheckBox
            // 
            this.microphoneUnmuteHotKeyAltCheckBox.AutoSize = true;
            this.microphoneUnmuteHotKeyAltCheckBox.Location = new System.Drawing.Point(129, 152);
            this.microphoneUnmuteHotKeyAltCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneUnmuteHotKeyAltCheckBox.Name = "microphoneUnmuteHotKeyAltCheckBox";
            this.microphoneUnmuteHotKeyAltCheckBox.Size = new System.Drawing.Size(54, 24);
            this.microphoneUnmuteHotKeyAltCheckBox.TabIndex = 14;
            this.microphoneUnmuteHotKeyAltCheckBox.Text = "A&lt";
            this.microphoneUnmuteHotKeyAltCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneUnmuteHotKeyControlCheckBox
            // 
            this.microphoneUnmuteHotKeyControlCheckBox.AutoSize = true;
            this.microphoneUnmuteHotKeyControlCheckBox.Location = new System.Drawing.Point(195, 152);
            this.microphoneUnmuteHotKeyControlCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneUnmuteHotKeyControlCheckBox.Name = "microphoneUnmuteHotKeyControlCheckBox";
            this.microphoneUnmuteHotKeyControlCheckBox.Size = new System.Drawing.Size(86, 24);
            this.microphoneUnmuteHotKeyControlCheckBox.TabIndex = 15;
            this.microphoneUnmuteHotKeyControlCheckBox.Text = "Co&ntrol";
            this.microphoneUnmuteHotKeyControlCheckBox.UseVisualStyleBackColor = true;
            // 
            // microphoneUnmuteHotKeyShiftCheckBox
            // 
            this.microphoneUnmuteHotKeyShiftCheckBox.AutoSize = true;
            this.microphoneUnmuteHotKeyShiftCheckBox.Location = new System.Drawing.Point(292, 152);
            this.microphoneUnmuteHotKeyShiftCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.microphoneUnmuteHotKeyShiftCheckBox.Name = "microphoneUnmuteHotKeyShiftCheckBox";
            this.microphoneUnmuteHotKeyShiftCheckBox.Size = new System.Drawing.Size(68, 24);
            this.microphoneUnmuteHotKeyShiftCheckBox.TabIndex = 16;
            this.microphoneUnmuteHotKeyShiftCheckBox.Text = "S&hift";
            this.microphoneUnmuteHotKeyShiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(618, 324);
            this.Controls.Add(this.microphoneUnmuteHotKeyShiftCheckBox);
            this.Controls.Add(this.microphoneMuteHotKeyShiftCheckBox);
            this.Controls.Add(this.microphoneToggleHotKeyShiftCheckBox);
            this.Controls.Add(this.microphoneUnmuteHotKeyControlCheckBox);
            this.Controls.Add(this.microphoneMuteHotKeyControlCheckBox);
            this.Controls.Add(this.microphoneToggleHotKeyControlCheckBox);
            this.Controls.Add(this.microphoneUnmuteHotKeyAltCheckBox);
            this.Controls.Add(this.microphoneMuteHotKeyAltCheckBox);
            this.Controls.Add(this.microphoneToggleHotKeyAltCheckBox);
            this.Controls.Add(this.microphoneUnmuteHotKeyWindowsCheckBox);
            this.Controls.Add(this.microphoneMuteHotKeyWindowsCheckBox);
            this.Controls.Add(this.microphoneToggleHotKeyWindowsCheckBox);
            this.Controls.Add(this.microphoneUnmuteHotKeyLabel);
            this.Controls.Add(this.microphoneMuteHotKeyLabel);
            this.Controls.Add(this.microphoneToggleHotKeyLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.websiteLinkLabel);
            this.Controls.Add(this.microphoneUnmuteHotKeyTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.microphoneMuteHotKeyTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.microphoneToggleHotKeyTextBox);
            this.Controls.Add(this.runOnStartupCheckbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 380);
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
        private System.Windows.Forms.Label microphoneToggleHotKeyLabel;
        private System.Windows.Forms.CheckBox microphoneToggleHotKeyWindowsCheckBox;
        private System.Windows.Forms.CheckBox microphoneToggleHotKeyAltCheckBox;
        private System.Windows.Forms.CheckBox microphoneToggleHotKeyControlCheckBox;
        private System.Windows.Forms.CheckBox microphoneToggleHotKeyShiftCheckBox;
        private System.Windows.Forms.TextBox microphoneMuteHotKeyTextBox;
        private System.Windows.Forms.Label microphoneMuteHotKeyLabel;
        private System.Windows.Forms.CheckBox microphoneMuteHotKeyWindowsCheckBox;
        private System.Windows.Forms.CheckBox microphoneMuteHotKeyAltCheckBox;
        private System.Windows.Forms.CheckBox microphoneMuteHotKeyControlCheckBox;
        private System.Windows.Forms.CheckBox microphoneMuteHotKeyShiftCheckBox;
        private System.Windows.Forms.TextBox microphoneUnmuteHotKeyTextBox;
        private System.Windows.Forms.Label microphoneUnmuteHotKeyLabel;
        private System.Windows.Forms.CheckBox microphoneUnmuteHotKeyWindowsCheckBox;
        private System.Windows.Forms.CheckBox microphoneUnmuteHotKeyAltCheckBox;
        private System.Windows.Forms.CheckBox microphoneUnmuteHotKeyControlCheckBox;
        private System.Windows.Forms.CheckBox microphoneUnmuteHotKeyShiftCheckBox;
    }
}

