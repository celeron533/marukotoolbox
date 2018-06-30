namespace mp4box.UserCtrl
{
    partial class MuxUserControl
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
            this.MuxConvertGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxConvertAacEncoderLabel = new System.Windows.Forms.Label();
            this.MuxConvertAacEncoderComboBox = new System.Windows.Forms.ComboBox();
            this.MuxConvertFormatLabel = new System.Windows.Forms.Label();
            this.MuxConvertFormatComboBox = new System.Windows.Forms.ComboBox();
            this.MuxConvertItemListBox = new System.Windows.Forms.ListBox();
            this.MuxConvertAddButton = new ControlExs.QQButton();
            this.MuxConvertClearButton = new ControlExs.QQButton();
            this.MuxConvertOutputNotificationLabel = new System.Windows.Forms.Label();
            this.MuxConvertDeleteButton = new ControlExs.QQButton();
            this.MuxConvertStartButton = new ControlExs.QQButton();
            this.MuxMp4GroupBox = new System.Windows.Forms.GroupBox();
            this.MuxMp4ParComboBox = new System.Windows.Forms.ComboBox();
            this.MuxMp4ParLabel = new System.Windows.Forms.Label();
            this.MuxMp4ReplaceAudioButton = new ControlExs.QQButton();
            this.MuxMp4VideoInputTextBox = new ControlExs.QQTextBox();
            this.MuxMp4VideoInputButton = new ControlExs.QQButton();
            this.MuxMp4StartButton = new ControlExs.QQButton();
            this.MuxMp4FpsComboBox = new System.Windows.Forms.ComboBox();
            this.MuxMp4AudioInputButton = new ControlExs.QQButton();
            this.MuxMp4OutputButton = new ControlExs.QQButton();
            this.MuxMp4AudioInputTextBox = new ControlExs.QQTextBox();
            this.MuxMp4FpsLabel = new System.Windows.Forms.Label();
            this.MuxMp4OutputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxMkvVideoInputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvOutputButton = new ControlExs.QQButton();
            this.MuxMkvSubtitleTextBox = new ControlExs.QQTextBox();
            this.MuxMkvAudioInputButton = new ControlExs.QQButton();
            this.MuxMkvAudioInputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvSubtitleButton = new ControlExs.QQButton();
            this.MuxMkvOutputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvVideoInputButton = new ControlExs.QQButton();
            this.MuxMkvStartButton = new ControlExs.QQButton();
            this.MuxConvertGroupBox.SuspendLayout();
            this.MuxMp4GroupBox.SuspendLayout();
            this.MuxMkvGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MuxConvertGroupBox
            // 
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAacEncoderLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAacEncoderComboBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertFormatLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertFormatComboBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertItemListBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAddButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertClearButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertOutputNotificationLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertDeleteButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertStartButton);
            this.MuxConvertGroupBox.Location = new System.Drawing.Point(3, 318);
            this.MuxConvertGroupBox.Name = "MuxConvertGroupBox";
            this.MuxConvertGroupBox.Size = new System.Drawing.Size(570, 267);
            this.MuxConvertGroupBox.TabIndex = 26;
            this.MuxConvertGroupBox.TabStop = false;
            this.MuxConvertGroupBox.Text = "封装转换";
            // 
            // MuxConvertAacEncoderLabel
            // 
            this.MuxConvertAacEncoderLabel.AutoSize = true;
            this.MuxConvertAacEncoderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertAacEncoderLabel.Location = new System.Drawing.Point(8, 246);
            this.MuxConvertAacEncoderLabel.Name = "MuxConvertAacEncoderLabel";
            this.MuxConvertAacEncoderLabel.Size = new System.Drawing.Size(59, 12);
            this.MuxConvertAacEncoderLabel.TabIndex = 22;
            this.MuxConvertAacEncoderLabel.Text = "AAC编码器";
            // 
            // MuxConvertAacEncoderComboBox
            // 
            this.MuxConvertAacEncoderComboBox.FormattingEnabled = true;
            this.MuxConvertAacEncoderComboBox.Items.AddRange(new object[] {
            "aac",
            "libfdk_aac"});
            this.MuxConvertAacEncoderComboBox.Location = new System.Drawing.Point(91, 241);
            this.MuxConvertAacEncoderComboBox.Name = "MuxConvertAacEncoderComboBox";
            this.MuxConvertAacEncoderComboBox.Size = new System.Drawing.Size(98, 20);
            this.MuxConvertAacEncoderComboBox.TabIndex = 21;
            this.MuxConvertAacEncoderComboBox.Text = "aac";
            // 
            // MuxConvertFormatLabel
            // 
            this.MuxConvertFormatLabel.AutoSize = true;
            this.MuxConvertFormatLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertFormatLabel.Location = new System.Drawing.Point(204, 246);
            this.MuxConvertFormatLabel.Name = "MuxConvertFormatLabel";
            this.MuxConvertFormatLabel.Size = new System.Drawing.Size(53, 12);
            this.MuxConvertFormatLabel.TabIndex = 20;
            this.MuxConvertFormatLabel.Text = "输出格式";
            // 
            // MuxConvertFormatComboBox
            // 
            this.MuxConvertFormatComboBox.FormattingEnabled = true;
            this.MuxConvertFormatComboBox.Items.AddRange(new object[] {
            "flv",
            "mp4",
            "mkv",
            "mov",
            "avi",
            "f4v"});
            this.MuxConvertFormatComboBox.Location = new System.Drawing.Point(269, 241);
            this.MuxConvertFormatComboBox.Name = "MuxConvertFormatComboBox";
            this.MuxConvertFormatComboBox.Size = new System.Drawing.Size(49, 20);
            this.MuxConvertFormatComboBox.TabIndex = 19;
            // 
            // MuxConvertItemListBox
            // 
            this.MuxConvertItemListBox.AllowDrop = true;
            this.MuxConvertItemListBox.FormattingEnabled = true;
            this.MuxConvertItemListBox.HorizontalScrollbar = true;
            this.MuxConvertItemListBox.ItemHeight = 12;
            this.MuxConvertItemListBox.Location = new System.Drawing.Point(6, 19);
            this.MuxConvertItemListBox.Name = "MuxConvertItemListBox";
            this.MuxConvertItemListBox.Size = new System.Drawing.Size(471, 208);
            this.MuxConvertItemListBox.TabIndex = 12;
            // 
            // MuxConvertAddButton
            // 
            this.MuxConvertAddButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertAddButton.Location = new System.Drawing.Point(483, 19);
            this.MuxConvertAddButton.Name = "MuxConvertAddButton";
            this.MuxConvertAddButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertAddButton.TabIndex = 15;
            this.MuxConvertAddButton.Text = "添加";
            this.MuxConvertAddButton.UseVisualStyleBackColor = true;
            this.MuxConvertAddButton.Click += new System.EventHandler(this.MuxConvertAddButton_Click);
            // 
            // MuxConvertClearButton
            // 
            this.MuxConvertClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertClearButton.Location = new System.Drawing.Point(483, 77);
            this.MuxConvertClearButton.Name = "MuxConvertClearButton";
            this.MuxConvertClearButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertClearButton.TabIndex = 17;
            this.MuxConvertClearButton.Text = "清空";
            this.MuxConvertClearButton.UseVisualStyleBackColor = true;
            this.MuxConvertClearButton.Click += new System.EventHandler(this.MuxConvertClearButton_Click);
            // 
            // MuxConvertOutputNotificationLabel
            // 
            this.MuxConvertOutputNotificationLabel.AutoSize = true;
            this.MuxConvertOutputNotificationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertOutputNotificationLabel.Location = new System.Drawing.Point(357, 246);
            this.MuxConvertOutputNotificationLabel.Name = "MuxConvertOutputNotificationLabel";
            this.MuxConvertOutputNotificationLabel.Size = new System.Drawing.Size(101, 12);
            this.MuxConvertOutputNotificationLabel.TabIndex = 18;
            this.MuxConvertOutputNotificationLabel.Text = "输出到源文件目录";
            // 
            // MuxConvertDeleteButton
            // 
            this.MuxConvertDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertDeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertDeleteButton.Location = new System.Drawing.Point(483, 48);
            this.MuxConvertDeleteButton.Name = "MuxConvertDeleteButton";
            this.MuxConvertDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertDeleteButton.TabIndex = 16;
            this.MuxConvertDeleteButton.Text = "删除";
            this.MuxConvertDeleteButton.UseVisualStyleBackColor = true;
            this.MuxConvertDeleteButton.Click += new System.EventHandler(this.MuxConvertDeleteButton_Click);
            // 
            // MuxConvertStartButton
            // 
            this.MuxConvertStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertStartButton.Location = new System.Drawing.Point(483, 239);
            this.MuxConvertStartButton.Name = "MuxConvertStartButton";
            this.MuxConvertStartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertStartButton.TabIndex = 14;
            this.MuxConvertStartButton.Text = "封装";
            this.MuxConvertStartButton.UseVisualStyleBackColor = true;
            this.MuxConvertStartButton.Click += new System.EventHandler(this.MuxConvertStartButton_Click);
            // 
            // MuxMp4GroupBox
            // 
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ParComboBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ParLabel);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ReplaceAudioButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4VideoInputTextBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4VideoInputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4StartButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4FpsComboBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4AudioInputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4OutputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4AudioInputTextBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4FpsLabel);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4OutputTextBox);
            this.MuxMp4GroupBox.Location = new System.Drawing.Point(3, 3);
            this.MuxMp4GroupBox.Name = "MuxMp4GroupBox";
            this.MuxMp4GroupBox.Size = new System.Drawing.Size(570, 140);
            this.MuxMp4GroupBox.TabIndex = 25;
            this.MuxMp4GroupBox.TabStop = false;
            this.MuxMp4GroupBox.Text = "合并为MP4";
            // 
            // MuxMp4ParComboBox
            // 
            this.MuxMp4ParComboBox.FormattingEnabled = true;
            this.MuxMp4ParComboBox.Items.AddRange(new object[] {
            "1:1",
            "4:3",
            "8:9",
            "10:11",
            "12:11",
            "16:11",
            "32:27",
            "40:33",
            "64:45"});
            this.MuxMp4ParComboBox.Location = new System.Drawing.Point(195, 107);
            this.MuxMp4ParComboBox.Name = "MuxMp4ParComboBox";
            this.MuxMp4ParComboBox.Size = new System.Drawing.Size(89, 20);
            this.MuxMp4ParComboBox.TabIndex = 18;
            this.MuxMp4ParComboBox.Text = "1:1";
            // 
            // MuxMp4ParLabel
            // 
            this.MuxMp4ParLabel.AutoSize = true;
            this.MuxMp4ParLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4ParLabel.Location = new System.Drawing.Point(166, 111);
            this.MuxMp4ParLabel.Name = "MuxMp4ParLabel";
            this.MuxMp4ParLabel.Size = new System.Drawing.Size(23, 12);
            this.MuxMp4ParLabel.TabIndex = 19;
            this.MuxMp4ParLabel.Text = "PAR";
            // 
            // MuxMp4ReplaceAudioButton
            // 
            this.MuxMp4ReplaceAudioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4ReplaceAudioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4ReplaceAudioButton.Location = new System.Drawing.Point(359, 105);
            this.MuxMp4ReplaceAudioButton.Name = "MuxMp4ReplaceAudioButton";
            this.MuxMp4ReplaceAudioButton.Size = new System.Drawing.Size(118, 23);
            this.MuxMp4ReplaceAudioButton.TabIndex = 17;
            this.MuxMp4ReplaceAudioButton.Text = "替换音频";
            this.MuxMp4ReplaceAudioButton.UseVisualStyleBackColor = true;
            this.MuxMp4ReplaceAudioButton.Click += new System.EventHandler(this.MuxMp4ReplaceAudioButton_Click);
            // 
            // MuxMp4VideoInputTextBox
            // 
            this.MuxMp4VideoInputTextBox.AllowDrop = true;
            this.MuxMp4VideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4VideoInputTextBox.EmptyTextTip = "";
            this.MuxMp4VideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4VideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4VideoInputTextBox.Location = new System.Drawing.Point(6, 18);
            this.MuxMp4VideoInputTextBox.Name = "MuxMp4VideoInputTextBox";
            this.MuxMp4VideoInputTextBox.ReadOnly = true;
            this.MuxMp4VideoInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4VideoInputTextBox.TabIndex = 2;
            this.MuxMp4VideoInputTextBox.TextChanged += new System.EventHandler(this.MuxMp4VideoInputTextBox_TextChanged);
            // 
            // MuxMp4VideoInputButton
            // 
            this.MuxMp4VideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4VideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4VideoInputButton.Location = new System.Drawing.Point(483, 18);
            this.MuxMp4VideoInputButton.Name = "MuxMp4VideoInputButton";
            this.MuxMp4VideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4VideoInputButton.TabIndex = 0;
            this.MuxMp4VideoInputButton.Text = "视频";
            this.MuxMp4VideoInputButton.UseVisualStyleBackColor = true;
            this.MuxMp4VideoInputButton.Click += new System.EventHandler(this.MuxMp4VideoInputButton_Click);
            // 
            // MuxMp4StartButton
            // 
            this.MuxMp4StartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4StartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4StartButton.Location = new System.Drawing.Point(483, 105);
            this.MuxMp4StartButton.Name = "MuxMp4StartButton";
            this.MuxMp4StartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4StartButton.TabIndex = 6;
            this.MuxMp4StartButton.Text = "封装";
            this.MuxMp4StartButton.UseVisualStyleBackColor = true;
            this.MuxMp4StartButton.Click += new System.EventHandler(this.MuxMp4StartButton_Click);
            // 
            // MuxMp4FpsComboBox
            // 
            this.MuxMp4FpsComboBox.FormattingEnabled = true;
            this.MuxMp4FpsComboBox.Items.AddRange(new object[] {
            "auto",
            "23.976",
            "24",
            "25",
            "29.970",
            "30",
            "50",
            "59.940",
            "60"});
            this.MuxMp4FpsComboBox.Location = new System.Drawing.Point(37, 107);
            this.MuxMp4FpsComboBox.Name = "MuxMp4FpsComboBox";
            this.MuxMp4FpsComboBox.Size = new System.Drawing.Size(89, 20);
            this.MuxMp4FpsComboBox.TabIndex = 14;
            this.MuxMp4FpsComboBox.Text = "auto";
            this.MuxMp4FpsComboBox.SelectedIndexChanged += new System.EventHandler(this.MuxMp4FpsComboBox_SelectedIndexChanged);
            // 
            // MuxMp4AudioInputButton
            // 
            this.MuxMp4AudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4AudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4AudioInputButton.Location = new System.Drawing.Point(483, 47);
            this.MuxMp4AudioInputButton.Name = "MuxMp4AudioInputButton";
            this.MuxMp4AudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4AudioInputButton.TabIndex = 1;
            this.MuxMp4AudioInputButton.Text = "音频";
            this.MuxMp4AudioInputButton.UseVisualStyleBackColor = true;
            this.MuxMp4AudioInputButton.Click += new System.EventHandler(this.MuxMp4AudioInputButton_Click);
            // 
            // MuxMp4OutputButton
            // 
            this.MuxMp4OutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4OutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4OutputButton.Location = new System.Drawing.Point(483, 76);
            this.MuxMp4OutputButton.Name = "MuxMp4OutputButton";
            this.MuxMp4OutputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4OutputButton.TabIndex = 5;
            this.MuxMp4OutputButton.Text = "输出";
            this.MuxMp4OutputButton.UseVisualStyleBackColor = true;
            this.MuxMp4OutputButton.Click += new System.EventHandler(this.MuxMp4OutputButton_Click);
            // 
            // MuxMp4AudioInputTextBox
            // 
            this.MuxMp4AudioInputTextBox.AllowDrop = true;
            this.MuxMp4AudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4AudioInputTextBox.EmptyTextTip = null;
            this.MuxMp4AudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4AudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4AudioInputTextBox.Location = new System.Drawing.Point(6, 47);
            this.MuxMp4AudioInputTextBox.Name = "MuxMp4AudioInputTextBox";
            this.MuxMp4AudioInputTextBox.ReadOnly = true;
            this.MuxMp4AudioInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4AudioInputTextBox.TabIndex = 3;
            // 
            // MuxMp4FpsLabel
            // 
            this.MuxMp4FpsLabel.AutoSize = true;
            this.MuxMp4FpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4FpsLabel.Location = new System.Drawing.Point(8, 111);
            this.MuxMp4FpsLabel.Name = "MuxMp4FpsLabel";
            this.MuxMp4FpsLabel.Size = new System.Drawing.Size(23, 12);
            this.MuxMp4FpsLabel.TabIndex = 16;
            this.MuxMp4FpsLabel.Text = "FPS";
            // 
            // MuxMp4OutputTextBox
            // 
            this.MuxMp4OutputTextBox.AllowDrop = true;
            this.MuxMp4OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4OutputTextBox.EmptyTextTip = null;
            this.MuxMp4OutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4OutputTextBox.Location = new System.Drawing.Point(6, 76);
            this.MuxMp4OutputTextBox.Name = "MuxMp4OutputTextBox";
            this.MuxMp4OutputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4OutputTextBox.TabIndex = 4;
            // 
            // MuxMkvGroupBox
            // 
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvVideoInputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvOutputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvSubtitleTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvAudioInputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvAudioInputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvSubtitleButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvOutputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvVideoInputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvStartButton);
            this.MuxMkvGroupBox.Location = new System.Drawing.Point(3, 149);
            this.MuxMkvGroupBox.Name = "MuxMkvGroupBox";
            this.MuxMkvGroupBox.Size = new System.Drawing.Size(570, 163);
            this.MuxMkvGroupBox.TabIndex = 24;
            this.MuxMkvGroupBox.TabStop = false;
            this.MuxMkvGroupBox.Text = "合并为MKV";
            // 
            // MuxMkvVideoInputTextBox
            // 
            this.MuxMkvVideoInputTextBox.AllowDrop = true;
            this.MuxMkvVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvVideoInputTextBox.EmptyTextTip = null;
            this.MuxMkvVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvVideoInputTextBox.Location = new System.Drawing.Point(6, 18);
            this.MuxMkvVideoInputTextBox.Name = "MuxMkvVideoInputTextBox";
            this.MuxMkvVideoInputTextBox.ReadOnly = true;
            this.MuxMkvVideoInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvVideoInputTextBox.TabIndex = 8;
            // 
            // MuxMkvOutputButton
            // 
            this.MuxMkvOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvOutputButton.Location = new System.Drawing.Point(483, 105);
            this.MuxMkvOutputButton.Name = "MuxMkvOutputButton";
            this.MuxMkvOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvOutputButton.TabIndex = 11;
            this.MuxMkvOutputButton.Text = "输出";
            this.MuxMkvOutputButton.UseVisualStyleBackColor = true;
            this.MuxMkvOutputButton.Click += new System.EventHandler(this.MuxMkvOutputButton_Click);
            // 
            // MuxMkvSubtitleTextBox
            // 
            this.MuxMkvSubtitleTextBox.AllowDrop = true;
            this.MuxMkvSubtitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvSubtitleTextBox.EmptyTextTip = null;
            this.MuxMkvSubtitleTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvSubtitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvSubtitleTextBox.Location = new System.Drawing.Point(6, 76);
            this.MuxMkvSubtitleTextBox.Name = "MuxMkvSubtitleTextBox";
            this.MuxMkvSubtitleTextBox.ReadOnly = true;
            this.MuxMkvSubtitleTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvSubtitleTextBox.TabIndex = 9;
            // 
            // MuxMkvAudioInputButton
            // 
            this.MuxMkvAudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvAudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvAudioInputButton.Location = new System.Drawing.Point(483, 47);
            this.MuxMkvAudioInputButton.Name = "MuxMkvAudioInputButton";
            this.MuxMkvAudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvAudioInputButton.TabIndex = 7;
            this.MuxMkvAudioInputButton.Text = "音频";
            this.MuxMkvAudioInputButton.UseVisualStyleBackColor = true;
            this.MuxMkvAudioInputButton.Click += new System.EventHandler(this.MuxMkvAudioInputButton_Click);
            // 
            // MuxMkvAudioInputTextBox
            // 
            this.MuxMkvAudioInputTextBox.AllowDrop = true;
            this.MuxMkvAudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvAudioInputTextBox.EmptyTextTip = "";
            this.MuxMkvAudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvAudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvAudioInputTextBox.Location = new System.Drawing.Point(6, 47);
            this.MuxMkvAudioInputTextBox.Name = "MuxMkvAudioInputTextBox";
            this.MuxMkvAudioInputTextBox.ReadOnly = true;
            this.MuxMkvAudioInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvAudioInputTextBox.TabIndex = 9;
            // 
            // MuxMkvSubtitleButton
            // 
            this.MuxMkvSubtitleButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvSubtitleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvSubtitleButton.Location = new System.Drawing.Point(483, 76);
            this.MuxMkvSubtitleButton.Name = "MuxMkvSubtitleButton";
            this.MuxMkvSubtitleButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvSubtitleButton.TabIndex = 7;
            this.MuxMkvSubtitleButton.Text = "字幕";
            this.MuxMkvSubtitleButton.UseVisualStyleBackColor = true;
            this.MuxMkvSubtitleButton.Click += new System.EventHandler(this.MuxMkvSubtitleButton_Click);
            // 
            // MuxMkvOutputTextBox
            // 
            this.MuxMkvOutputTextBox.AllowDrop = true;
            this.MuxMkvOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvOutputTextBox.EmptyTextTip = null;
            this.MuxMkvOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvOutputTextBox.Location = new System.Drawing.Point(6, 105);
            this.MuxMkvOutputTextBox.Name = "MuxMkvOutputTextBox";
            this.MuxMkvOutputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvOutputTextBox.TabIndex = 10;
            // 
            // MuxMkvVideoInputButton
            // 
            this.MuxMkvVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvVideoInputButton.Location = new System.Drawing.Point(483, 18);
            this.MuxMkvVideoInputButton.Name = "MuxMkvVideoInputButton";
            this.MuxMkvVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvVideoInputButton.TabIndex = 6;
            this.MuxMkvVideoInputButton.Text = "视频";
            this.MuxMkvVideoInputButton.UseVisualStyleBackColor = true;
            this.MuxMkvVideoInputButton.Click += new System.EventHandler(this.MuxMkvVideoInputButton_Click);
            // 
            // MuxMkvStartButton
            // 
            this.MuxMkvStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvStartButton.Location = new System.Drawing.Point(483, 134);
            this.MuxMkvStartButton.Name = "MuxMkvStartButton";
            this.MuxMkvStartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvStartButton.TabIndex = 12;
            this.MuxMkvStartButton.Text = "封装";
            this.MuxMkvStartButton.UseVisualStyleBackColor = true;
            this.MuxMkvStartButton.Click += new System.EventHandler(this.MuxMkvStartButton_Click);
            // 
            // MuxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MuxConvertGroupBox);
            this.Controls.Add(this.MuxMp4GroupBox);
            this.Controls.Add(this.MuxMkvGroupBox);
            this.Name = "MuxUserControl";
            this.Size = new System.Drawing.Size(566, 585);
            this.MuxConvertGroupBox.ResumeLayout(false);
            this.MuxConvertGroupBox.PerformLayout();
            this.MuxMp4GroupBox.ResumeLayout(false);
            this.MuxMp4GroupBox.PerformLayout();
            this.MuxMkvGroupBox.ResumeLayout(false);
            this.MuxMkvGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MuxConvertGroupBox;
        private System.Windows.Forms.Label MuxConvertAacEncoderLabel;
        private System.Windows.Forms.ComboBox MuxConvertAacEncoderComboBox;
        private System.Windows.Forms.Label MuxConvertFormatLabel;
        private System.Windows.Forms.ComboBox MuxConvertFormatComboBox;
        private System.Windows.Forms.ListBox MuxConvertItemListBox;
        private ControlExs.QQButton MuxConvertAddButton;
        private ControlExs.QQButton MuxConvertClearButton;
        private System.Windows.Forms.Label MuxConvertOutputNotificationLabel;
        private ControlExs.QQButton MuxConvertDeleteButton;
        private ControlExs.QQButton MuxConvertStartButton;
        private System.Windows.Forms.GroupBox MuxMp4GroupBox;
        private System.Windows.Forms.ComboBox MuxMp4ParComboBox;
        private System.Windows.Forms.Label MuxMp4ParLabel;
        private ControlExs.QQButton MuxMp4ReplaceAudioButton;
        private ControlExs.QQTextBox MuxMp4VideoInputTextBox;
        private ControlExs.QQButton MuxMp4VideoInputButton;
        private ControlExs.QQButton MuxMp4StartButton;
        private System.Windows.Forms.ComboBox MuxMp4FpsComboBox;
        private ControlExs.QQButton MuxMp4AudioInputButton;
        private ControlExs.QQButton MuxMp4OutputButton;
        private ControlExs.QQTextBox MuxMp4AudioInputTextBox;
        private System.Windows.Forms.Label MuxMp4FpsLabel;
        private ControlExs.QQTextBox MuxMp4OutputTextBox;
        private System.Windows.Forms.GroupBox MuxMkvGroupBox;
        private ControlExs.QQTextBox MuxMkvVideoInputTextBox;
        private ControlExs.QQButton MuxMkvOutputButton;
        private ControlExs.QQTextBox MuxMkvSubtitleTextBox;
        private ControlExs.QQButton MuxMkvAudioInputButton;
        private ControlExs.QQTextBox MuxMkvAudioInputTextBox;
        private ControlExs.QQButton MuxMkvSubtitleButton;
        private ControlExs.QQTextBox MuxMkvOutputTextBox;
        private ControlExs.QQButton MuxMkvVideoInputButton;
        private ControlExs.QQButton MuxMkvStartButton;
    }
}
