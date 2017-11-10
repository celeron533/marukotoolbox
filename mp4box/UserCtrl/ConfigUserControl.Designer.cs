namespace mp4box.UserCtrl
{
    partial class ConfigUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfigFunctionGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigFunctionEnableX265CheckBox = new ControlExs.QQCheckBox();
            this.ConfigFunctionVideoPlayerLabel = new System.Windows.Forms.Label();
            this.ConfigFunctionVideoPlayerTextBox = new ControlExs.QQTextBox();
            this.ConfigFunctionVideoPlayerButton = new ControlExs.QQButton();
            this.ConfigFunctionDeleteTempFileCheckBox = new ControlExs.QQCheckBox();
            this.ConfigFunctionAutoCheckUpdateCheckBox = new ControlExs.QQCheckBox();
            this.ConfigUiGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigUiSplashScreenCheckBox = new ControlExs.QQCheckBox();
            this.ConfigUiTrayModeCheckBox = new ControlExs.QQCheckBox();
            this.ConfigUiLanguageLabel = new System.Windows.Forms.Label();
            this.ConfigUiLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.ConfigX264GroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigX264ExtraParameterTextBox = new ControlExs.QQTextBox();
            this.ConfigX264ExtraParameterLabel = new System.Windows.Forms.Label();
            this.ConfigX264PriorityComboBox = new System.Windows.Forms.ComboBox();
            this.ConfigX264ThreadsComboBox = new System.Windows.Forms.ComboBox();
            this.ConfigX264ThreadsLabel = new System.Windows.Forms.Label();
            this.ConfigX264PriorityLabel = new System.Windows.Forms.Label();
            this.ConfigFunctionAllLogButton = new ControlExs.QQButton();
            this.ConfigFunctionRestoreDefaultButton = new ControlExs.QQButton();
            this.ConfigFunctionViewLogButton = new ControlExs.QQButton();
            this.ConfigFunctionGroupBox.SuspendLayout();
            this.ConfigUiGroupBox.SuspendLayout();
            this.ConfigX264GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigFunctionGroupBox
            // 
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionEnableX265CheckBox);
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionVideoPlayerLabel);
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionVideoPlayerTextBox);
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionVideoPlayerButton);
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionDeleteTempFileCheckBox);
            this.ConfigFunctionGroupBox.Controls.Add(this.ConfigFunctionAutoCheckUpdateCheckBox);
            this.ConfigFunctionGroupBox.Location = new System.Drawing.Point(3, 248);
            this.ConfigFunctionGroupBox.Name = "ConfigFunctionGroupBox";
            this.ConfigFunctionGroupBox.Size = new System.Drawing.Size(550, 85);
            this.ConfigFunctionGroupBox.TabIndex = 58;
            this.ConfigFunctionGroupBox.TabStop = false;
            this.ConfigFunctionGroupBox.Text = "功能设置";
            // 
            // ConfigFunctionEnableX265CheckBox
            // 
            this.ConfigFunctionEnableX265CheckBox.AutoSize = true;
            this.ConfigFunctionEnableX265CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigFunctionEnableX265CheckBox.Checked = true;
            this.ConfigFunctionEnableX265CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConfigFunctionEnableX265CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigFunctionEnableX265CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionEnableX265CheckBox.Location = new System.Drawing.Point(341, 56);
            this.ConfigFunctionEnableX265CheckBox.Name = "ConfigFunctionEnableX265CheckBox";
            this.ConfigFunctionEnableX265CheckBox.Size = new System.Drawing.Size(77, 19);
            this.ConfigFunctionEnableX265CheckBox.TabIndex = 51;
            this.ConfigFunctionEnableX265CheckBox.Text = "启用x265";
            this.ConfigFunctionEnableX265CheckBox.UseVisualStyleBackColor = false;
            // 
            // ConfigFunctionVideoPlayerLabel
            // 
            this.ConfigFunctionVideoPlayerLabel.AutoSize = true;
            this.ConfigFunctionVideoPlayerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionVideoPlayerLabel.Location = new System.Drawing.Point(6, 28);
            this.ConfigFunctionVideoPlayerLabel.Name = "ConfigFunctionVideoPlayerLabel";
            this.ConfigFunctionVideoPlayerLabel.Size = new System.Drawing.Size(65, 12);
            this.ConfigFunctionVideoPlayerLabel.TabIndex = 47;
            this.ConfigFunctionVideoPlayerLabel.Text = "预览播放器";
            // 
            // ConfigFunctionVideoPlayerTextBox
            // 
            this.ConfigFunctionVideoPlayerTextBox.AllowDrop = true;
            this.ConfigFunctionVideoPlayerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigFunctionVideoPlayerTextBox.EmptyTextTip = null;
            this.ConfigFunctionVideoPlayerTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.ConfigFunctionVideoPlayerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigFunctionVideoPlayerTextBox.Location = new System.Drawing.Point(106, 23);
            this.ConfigFunctionVideoPlayerTextBox.Name = "ConfigFunctionVideoPlayerTextBox";
            this.ConfigFunctionVideoPlayerTextBox.Size = new System.Drawing.Size(396, 21);
            this.ConfigFunctionVideoPlayerTextBox.TabIndex = 49;
            // 
            // ConfigFunctionVideoPlayerButton
            // 
            this.ConfigFunctionVideoPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigFunctionVideoPlayerButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionVideoPlayerButton.Location = new System.Drawing.Point(508, 23);
            this.ConfigFunctionVideoPlayerButton.Name = "ConfigFunctionVideoPlayerButton";
            this.ConfigFunctionVideoPlayerButton.Size = new System.Drawing.Size(36, 23);
            this.ConfigFunctionVideoPlayerButton.TabIndex = 48;
            this.ConfigFunctionVideoPlayerButton.Text = "...";
            this.ConfigFunctionVideoPlayerButton.UseVisualStyleBackColor = true;
            this.ConfigFunctionVideoPlayerButton.Click += new System.EventHandler(this.ConfigFunctionVideoPlayerButton_Click);
            // 
            // ConfigFunctionDeleteTempFileCheckBox
            // 
            this.ConfigFunctionDeleteTempFileCheckBox.AutoSize = true;
            this.ConfigFunctionDeleteTempFileCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigFunctionDeleteTempFileCheckBox.Checked = true;
            this.ConfigFunctionDeleteTempFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConfigFunctionDeleteTempFileCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigFunctionDeleteTempFileCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionDeleteTempFileCheckBox.Location = new System.Drawing.Point(8, 56);
            this.ConfigFunctionDeleteTempFileCheckBox.Name = "ConfigFunctionDeleteTempFileCheckBox";
            this.ConfigFunctionDeleteTempFileCheckBox.Size = new System.Drawing.Size(182, 19);
            this.ConfigFunctionDeleteTempFileCheckBox.TabIndex = 39;
            this.ConfigFunctionDeleteTempFileCheckBox.Text = "退出程序时删除所有临时文件";
            this.ConfigFunctionDeleteTempFileCheckBox.UseVisualStyleBackColor = false;
            // 
            // ConfigFunctionAutoCheckUpdateCheckBox
            // 
            this.ConfigFunctionAutoCheckUpdateCheckBox.AutoSize = true;
            this.ConfigFunctionAutoCheckUpdateCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigFunctionAutoCheckUpdateCheckBox.Checked = true;
            this.ConfigFunctionAutoCheckUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConfigFunctionAutoCheckUpdateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigFunctionAutoCheckUpdateCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionAutoCheckUpdateCheckBox.Location = new System.Drawing.Point(231, 56);
            this.ConfigFunctionAutoCheckUpdateCheckBox.Name = "ConfigFunctionAutoCheckUpdateCheckBox";
            this.ConfigFunctionAutoCheckUpdateCheckBox.Size = new System.Drawing.Size(74, 19);
            this.ConfigFunctionAutoCheckUpdateCheckBox.TabIndex = 50;
            this.ConfigFunctionAutoCheckUpdateCheckBox.Text = "检查更新";
            this.ConfigFunctionAutoCheckUpdateCheckBox.UseVisualStyleBackColor = false;
            // 
            // ConfigUiGroupBox
            // 
            this.ConfigUiGroupBox.Controls.Add(this.ConfigUiSplashScreenCheckBox);
            this.ConfigUiGroupBox.Controls.Add(this.ConfigUiTrayModeCheckBox);
            this.ConfigUiGroupBox.Controls.Add(this.ConfigUiLanguageLabel);
            this.ConfigUiGroupBox.Controls.Add(this.ConfigUiLanguageComboBox);
            this.ConfigUiGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ConfigUiGroupBox.Name = "ConfigUiGroupBox";
            this.ConfigUiGroupBox.Size = new System.Drawing.Size(550, 92);
            this.ConfigUiGroupBox.TabIndex = 57;
            this.ConfigUiGroupBox.TabStop = false;
            this.ConfigUiGroupBox.Text = "界面设置";
            // 
            // ConfigUiSplashScreenCheckBox
            // 
            this.ConfigUiSplashScreenCheckBox.AutoSize = true;
            this.ConfigUiSplashScreenCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigUiSplashScreenCheckBox.Checked = true;
            this.ConfigUiSplashScreenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConfigUiSplashScreenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigUiSplashScreenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigUiSplashScreenCheckBox.Location = new System.Drawing.Point(20, 51);
            this.ConfigUiSplashScreenCheckBox.Name = "ConfigUiSplashScreenCheckBox";
            this.ConfigUiSplashScreenCheckBox.Size = new System.Drawing.Size(98, 19);
            this.ConfigUiSplashScreenCheckBox.TabIndex = 44;
            this.ConfigUiSplashScreenCheckBox.Text = "显示启动画面";
            this.ConfigUiSplashScreenCheckBox.UseVisualStyleBackColor = false;
            // 
            // ConfigUiTrayModeCheckBox
            // 
            this.ConfigUiTrayModeCheckBox.AutoSize = true;
            this.ConfigUiTrayModeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigUiTrayModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConfigUiTrayModeCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigUiTrayModeCheckBox.Location = new System.Drawing.Point(162, 51);
            this.ConfigUiTrayModeCheckBox.Name = "ConfigUiTrayModeCheckBox";
            this.ConfigUiTrayModeCheckBox.Size = new System.Drawing.Size(74, 19);
            this.ConfigUiTrayModeCheckBox.TabIndex = 43;
            this.ConfigUiTrayModeCheckBox.Text = "托盘模式";
            this.ConfigUiTrayModeCheckBox.UseVisualStyleBackColor = false;
            this.ConfigUiTrayModeCheckBox.CheckedChanged += new System.EventHandler(this.ConfigUiTrayModeCheckBox_CheckedChanged);
            // 
            // ConfigUiLanguageLabel
            // 
            this.ConfigUiLanguageLabel.AutoSize = true;
            this.ConfigUiLanguageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigUiLanguageLabel.Location = new System.Drawing.Point(18, 23);
            this.ConfigUiLanguageLabel.Name = "ConfigUiLanguageLabel";
            this.ConfigUiLanguageLabel.Size = new System.Drawing.Size(53, 12);
            this.ConfigUiLanguageLabel.TabIndex = 24;
            this.ConfigUiLanguageLabel.Text = "界面语言";
            // 
            // ConfigUiLanguageComboBox
            // 
            this.ConfigUiLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigUiLanguageComboBox.FormattingEnabled = true;
            this.ConfigUiLanguageComboBox.Items.AddRange(new object[] {
            "简体中文",
            "繁体中文",
            "English",
            "日本語"});
            this.ConfigUiLanguageComboBox.Location = new System.Drawing.Point(93, 20);
            this.ConfigUiLanguageComboBox.Name = "ConfigUiLanguageComboBox";
            this.ConfigUiLanguageComboBox.Size = new System.Drawing.Size(143, 20);
            this.ConfigUiLanguageComboBox.TabIndex = 25;
            this.ConfigUiLanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.ConfigUiLanguageComboBox_SelectedIndexChanged);
            // 
            // ConfigX264GroupBox
            // 
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264ExtraParameterTextBox);
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264ExtraParameterLabel);
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264PriorityComboBox);
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264ThreadsComboBox);
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264ThreadsLabel);
            this.ConfigX264GroupBox.Controls.Add(this.ConfigX264PriorityLabel);
            this.ConfigX264GroupBox.Location = new System.Drawing.Point(3, 101);
            this.ConfigX264GroupBox.Name = "ConfigX264GroupBox";
            this.ConfigX264GroupBox.Size = new System.Drawing.Size(550, 141);
            this.ConfigX264GroupBox.TabIndex = 53;
            this.ConfigX264GroupBox.TabStop = false;
            this.ConfigX264GroupBox.Text = "x264设置";
            // 
            // ConfigX264ExtraParameterTextBox
            // 
            this.ConfigX264ExtraParameterTextBox.AllowDrop = true;
            this.ConfigX264ExtraParameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigX264ExtraParameterTextBox.EmptyTextTip = null;
            this.ConfigX264ExtraParameterTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.ConfigX264ExtraParameterTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.ConfigX264ExtraParameterTextBox.Location = new System.Drawing.Point(15, 72);
            this.ConfigX264ExtraParameterTextBox.Multiline = true;
            this.ConfigX264ExtraParameterTextBox.Name = "ConfigX264ExtraParameterTextBox";
            this.ConfigX264ExtraParameterTextBox.Size = new System.Drawing.Size(529, 57);
            this.ConfigX264ExtraParameterTextBox.TabIndex = 0;
            // 
            // ConfigX264ExtraParameterLabel
            // 
            this.ConfigX264ExtraParameterLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigX264ExtraParameterLabel.Location = new System.Drawing.Point(13, 53);
            this.ConfigX264ExtraParameterLabel.Name = "ConfigX264ExtraParameterLabel";
            this.ConfigX264ExtraParameterLabel.Size = new System.Drawing.Size(510, 23);
            this.ConfigX264ExtraParameterLabel.TabIndex = 1;
            this.ConfigX264ExtraParameterLabel.Text = "x264自定义命令行(下面参数将覆盖小丸内置参数 界面设置的参数依然有效)";
            // 
            // ConfigX264PriorityComboBox
            // 
            this.ConfigX264PriorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigX264PriorityComboBox.FormattingEnabled = true;
            this.ConfigX264PriorityComboBox.Items.AddRange(new object[] {
            "低",
            "低于标准",
            "普通",
            "高于标准",
            "高",
            "实时"});
            this.ConfigX264PriorityComboBox.Location = new System.Drawing.Point(106, 19);
            this.ConfigX264PriorityComboBox.Name = "ConfigX264PriorityComboBox";
            this.ConfigX264PriorityComboBox.Size = new System.Drawing.Size(116, 20);
            this.ConfigX264PriorityComboBox.TabIndex = 38;
            this.ConfigX264PriorityComboBox.SelectedIndexChanged += new System.EventHandler(this.ConfigX264PriorityComboBox_SelectedIndexChanged);
            // 
            // ConfigX264ThreadsComboBox
            // 
            this.ConfigX264ThreadsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigX264ThreadsComboBox.FormattingEnabled = true;
            this.ConfigX264ThreadsComboBox.Location = new System.Drawing.Point(341, 19);
            this.ConfigX264ThreadsComboBox.Name = "ConfigX264ThreadsComboBox";
            this.ConfigX264ThreadsComboBox.Size = new System.Drawing.Size(86, 20);
            this.ConfigX264ThreadsComboBox.TabIndex = 45;
            // 
            // ConfigX264ThreadsLabel
            // 
            this.ConfigX264ThreadsLabel.AutoSize = true;
            this.ConfigX264ThreadsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigX264ThreadsLabel.Location = new System.Drawing.Point(267, 22);
            this.ConfigX264ThreadsLabel.Name = "ConfigX264ThreadsLabel";
            this.ConfigX264ThreadsLabel.Size = new System.Drawing.Size(53, 12);
            this.ConfigX264ThreadsLabel.TabIndex = 46;
            this.ConfigX264ThreadsLabel.Text = "x264线程";
            // 
            // ConfigX264PriorityLabel
            // 
            this.ConfigX264PriorityLabel.AutoSize = true;
            this.ConfigX264PriorityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigX264PriorityLabel.Location = new System.Drawing.Point(13, 22);
            this.ConfigX264PriorityLabel.Name = "ConfigX264PriorityLabel";
            this.ConfigX264PriorityLabel.Size = new System.Drawing.Size(65, 12);
            this.ConfigX264PriorityLabel.TabIndex = 16;
            this.ConfigX264PriorityLabel.Text = "x264优先级";
            // 
            // ConfigFunctionAllLogButton
            // 
            this.ConfigFunctionAllLogButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ConfigFunctionAllLogButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionAllLogButton.Location = new System.Drawing.Point(314, 371);
            this.ConfigFunctionAllLogButton.Name = "ConfigFunctionAllLogButton";
            this.ConfigFunctionAllLogButton.Size = new System.Drawing.Size(116, 23);
            this.ConfigFunctionAllLogButton.TabIndex = 54;
            this.ConfigFunctionAllLogButton.Text = "所有日志";
            this.ConfigFunctionAllLogButton.UseVisualStyleBackColor = true;
            this.ConfigFunctionAllLogButton.Click += new System.EventHandler(this.ConfigFunctionAllLogButton_Click);
            // 
            // ConfigFunctionRestoreDefaultButton
            // 
            this.ConfigFunctionRestoreDefaultButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ConfigFunctionRestoreDefaultButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionRestoreDefaultButton.Location = new System.Drawing.Point(11, 371);
            this.ConfigFunctionRestoreDefaultButton.Name = "ConfigFunctionRestoreDefaultButton";
            this.ConfigFunctionRestoreDefaultButton.Size = new System.Drawing.Size(116, 23);
            this.ConfigFunctionRestoreDefaultButton.TabIndex = 56;
            this.ConfigFunctionRestoreDefaultButton.Text = "还原默认设置";
            this.ConfigFunctionRestoreDefaultButton.UseVisualStyleBackColor = true;
            this.ConfigFunctionRestoreDefaultButton.Click += new System.EventHandler(this.ConfigFunctionRestoreDefaultButton_Click);
            // 
            // ConfigFunctionViewLogButton
            // 
            this.ConfigFunctionViewLogButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ConfigFunctionViewLogButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfigFunctionViewLogButton.Location = new System.Drawing.Point(165, 371);
            this.ConfigFunctionViewLogButton.Name = "ConfigFunctionViewLogButton";
            this.ConfigFunctionViewLogButton.Size = new System.Drawing.Size(116, 23);
            this.ConfigFunctionViewLogButton.TabIndex = 55;
            this.ConfigFunctionViewLogButton.Text = "查看日志";
            this.ConfigFunctionViewLogButton.UseVisualStyleBackColor = true;
            this.ConfigFunctionViewLogButton.Click += new System.EventHandler(this.ConfigFunctionViewLogButton_Click);
            // 
            // ConfigUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConfigFunctionGroupBox);
            this.Controls.Add(this.ConfigUiGroupBox);
            this.Controls.Add(this.ConfigX264GroupBox);
            this.Controls.Add(this.ConfigFunctionAllLogButton);
            this.Controls.Add(this.ConfigFunctionRestoreDefaultButton);
            this.Controls.Add(this.ConfigFunctionViewLogButton);
            this.Name = "ConfigUserControl";
            this.Size = new System.Drawing.Size(559, 420);
            this.ConfigFunctionGroupBox.ResumeLayout(false);
            this.ConfigFunctionGroupBox.PerformLayout();
            this.ConfigUiGroupBox.ResumeLayout(false);
            this.ConfigUiGroupBox.PerformLayout();
            this.ConfigX264GroupBox.ResumeLayout(false);
            this.ConfigX264GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ConfigFunctionGroupBox;
        private ControlExs.QQCheckBox ConfigFunctionEnableX265CheckBox;
        private System.Windows.Forms.Label ConfigFunctionVideoPlayerLabel;
        private ControlExs.QQTextBox ConfigFunctionVideoPlayerTextBox;
        private ControlExs.QQButton ConfigFunctionVideoPlayerButton;
        private ControlExs.QQCheckBox ConfigFunctionDeleteTempFileCheckBox;
        private ControlExs.QQCheckBox ConfigFunctionAutoCheckUpdateCheckBox;
        private System.Windows.Forms.GroupBox ConfigUiGroupBox;
        private ControlExs.QQCheckBox ConfigUiSplashScreenCheckBox;
        private ControlExs.QQCheckBox ConfigUiTrayModeCheckBox;
        private System.Windows.Forms.Label ConfigUiLanguageLabel;
        private System.Windows.Forms.ComboBox ConfigUiLanguageComboBox;
        private System.Windows.Forms.GroupBox ConfigX264GroupBox;
        private ControlExs.QQTextBox ConfigX264ExtraParameterTextBox;
        private System.Windows.Forms.Label ConfigX264ExtraParameterLabel;
        private System.Windows.Forms.ComboBox ConfigX264PriorityComboBox;
        private System.Windows.Forms.ComboBox ConfigX264ThreadsComboBox;
        private System.Windows.Forms.Label ConfigX264ThreadsLabel;
        private System.Windows.Forms.Label ConfigX264PriorityLabel;
        private ControlExs.QQButton ConfigFunctionAllLogButton;
        private ControlExs.QQButton ConfigFunctionRestoreDefaultButton;
        private ControlExs.QQButton ConfigFunctionViewLogButton;
    }
}
