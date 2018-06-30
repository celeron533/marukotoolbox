namespace mp4box.UserCtrl
{
    partial class MiscUserControl
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
            this.MiscMiscGroupBox = new System.Windows.Forms.GroupBox();
            this.MiscMiscTransposeLabel = new System.Windows.Forms.Label();
            this.MiscMiscTransposeComboBox = new System.Windows.Forms.ComboBox();
            this.MiscMiscStartRotateButton = new ControlExs.QQButton();
            this.MiscMiscVideoInputTextBox = new ControlExs.QQTextBox();
            this.MiscMiscVideoInputButton = new ControlExs.QQButton();
            this.MiscMiscVideoOutputButton = new ControlExs.QQButton();
            this.MiscMiscStartClipButton = new ControlExs.QQButton();
            this.MiscMiscVideoOutputTextBox = new ControlExs.QQTextBox();
            this.MiscMiscEndTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.MiscMiscBeginTimeLabel = new System.Windows.Forms.Label();
            this.MiscMiscEndTimeLabel = new System.Windows.Forms.Label();
            this.MiscMiscBeginTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.MiscOnePicGroupBox = new System.Windows.Forms.GroupBox();
            this.MiscOnePicDurationSecondsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicDurationSecondsTextBox = new System.Windows.Forms.TextBox();
            this.MiscOnePicDurationLabel = new System.Windows.Forms.Label();
            this.MiscOnePicCrfNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicCrfLabel = new System.Windows.Forms.Label();
            this.MiscOnePicCopyAudioCheckBox = new ControlExs.QQCheckBox();
            this.MiscOnePicFpsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicFpsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicKbpsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicBitrateLabel = new System.Windows.Forms.Label();
            this.MiscOnePicBitrateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicOutputButton = new ControlExs.QQButton();
            this.MiscOnePicStartButton = new ControlExs.QQButton();
            this.MiscOnePicAudioInputButton = new ControlExs.QQButton();
            this.MiscOnePicInputButton = new ControlExs.QQButton();
            this.MiscOnePicOutputTextBox = new ControlExs.QQTextBox();
            this.MiscOnePicAudioInputTextBox = new ControlExs.QQTextBox();
            this.MiscOnePicInputTextBox = new ControlExs.QQTextBox();
            this.MiscMiscGroupBox.SuspendLayout();
            this.MiscOnePicGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicCrfNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicFpsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicBitrateNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MiscMiscGroupBox
            // 
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscTransposeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscTransposeComboBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscStartRotateButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoInputTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoInputButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoOutputButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscStartClipButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoOutputTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscEndTimeMaskedTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscBeginTimeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscEndTimeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscBeginTimeMaskedTextBox);
            this.MiscMiscGroupBox.Location = new System.Drawing.Point(3, 172);
            this.MiscMiscGroupBox.Name = "MiscMiscGroupBox";
            this.MiscMiscGroupBox.Size = new System.Drawing.Size(566, 135);
            this.MiscMiscGroupBox.TabIndex = 23;
            this.MiscMiscGroupBox.TabStop = false;
            this.MiscMiscGroupBox.Text = "其他";
            // 
            // MiscMiscTransposeLabel
            // 
            this.MiscMiscTransposeLabel.AutoSize = true;
            this.MiscMiscTransposeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscTransposeLabel.Location = new System.Drawing.Point(92, 108);
            this.MiscMiscTransposeLabel.Name = "MiscMiscTransposeLabel";
            this.MiscMiscTransposeLabel.Size = new System.Drawing.Size(59, 12);
            this.MiscMiscTransposeLabel.TabIndex = 39;
            this.MiscMiscTransposeLabel.Text = "Transpose";
            // 
            // MiscMiscTransposeComboBox
            // 
            this.MiscMiscTransposeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MiscMiscTransposeComboBox.FormattingEnabled = true;
            this.MiscMiscTransposeComboBox.Items.AddRange(new object[] {
            "0: 逆时针旋转90°然后垂直翻转",
            "1: 顺时针旋转90°",
            "2: 逆时针旋转90°",
            "3: 顺时针旋转90°然后水平翻转"});
            this.MiscMiscTransposeComboBox.Location = new System.Drawing.Point(185, 105);
            this.MiscMiscTransposeComboBox.Name = "MiscMiscTransposeComboBox";
            this.MiscMiscTransposeComboBox.Size = new System.Drawing.Size(233, 20);
            this.MiscMiscTransposeComboBox.TabIndex = 38;
            // 
            // MiscMiscStartRotateButton
            // 
            this.MiscMiscStartRotateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscStartRotateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscStartRotateButton.Location = new System.Drawing.Point(483, 105);
            this.MiscMiscStartRotateButton.Name = "MiscMiscStartRotateButton";
            this.MiscMiscStartRotateButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscStartRotateButton.TabIndex = 21;
            this.MiscMiscStartRotateButton.Text = "旋转";
            this.MiscMiscStartRotateButton.UseVisualStyleBackColor = true;
            this.MiscMiscStartRotateButton.Click += new System.EventHandler(this.MiscMiscStartRotateButton_Click);
            // 
            // MiscMiscVideoInputTextBox
            // 
            this.MiscMiscVideoInputTextBox.AllowDrop = true;
            this.MiscMiscVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscMiscVideoInputTextBox.EmptyTextTip = null;
            this.MiscMiscVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscMiscVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscMiscVideoInputTextBox.Location = new System.Drawing.Point(9, 18);
            this.MiscMiscVideoInputTextBox.Name = "MiscMiscVideoInputTextBox";
            this.MiscMiscVideoInputTextBox.ReadOnly = true;
            this.MiscMiscVideoInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscMiscVideoInputTextBox.TabIndex = 7;
            this.MiscMiscVideoInputTextBox.TextChanged += new System.EventHandler(this.MiscMiscVideoInputTextBox_TextChanged);
            // 
            // MiscMiscVideoInputButton
            // 
            this.MiscMiscVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscVideoInputButton.Location = new System.Drawing.Point(483, 17);
            this.MiscMiscVideoInputButton.Name = "MiscMiscVideoInputButton";
            this.MiscMiscVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscVideoInputButton.TabIndex = 5;
            this.MiscMiscVideoInputButton.Text = "视频";
            this.MiscMiscVideoInputButton.UseVisualStyleBackColor = true;
            this.MiscMiscVideoInputButton.Click += new System.EventHandler(this.MiscMiscVideoInputButton_Click);
            // 
            // MiscMiscVideoOutputButton
            // 
            this.MiscMiscVideoOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscVideoOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscVideoOutputButton.Location = new System.Drawing.Point(483, 47);
            this.MiscMiscVideoOutputButton.Name = "MiscMiscVideoOutputButton";
            this.MiscMiscVideoOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscVideoOutputButton.TabIndex = 4;
            this.MiscMiscVideoOutputButton.Text = "输出";
            this.MiscMiscVideoOutputButton.UseVisualStyleBackColor = true;
            this.MiscMiscVideoOutputButton.Click += new System.EventHandler(this.MiscMiscVideoOutputButton_Click);
            // 
            // MiscMiscStartClipButton
            // 
            this.MiscMiscStartClipButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscStartClipButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscStartClipButton.Location = new System.Drawing.Point(483, 76);
            this.MiscMiscStartClipButton.Name = "MiscMiscStartClipButton";
            this.MiscMiscStartClipButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscStartClipButton.TabIndex = 20;
            this.MiscMiscStartClipButton.Text = "截取";
            this.MiscMiscStartClipButton.UseVisualStyleBackColor = true;
            this.MiscMiscStartClipButton.Click += new System.EventHandler(this.MiscMiscStartClipButton_Click);
            // 
            // MiscMiscVideoOutputTextBox
            // 
            this.MiscMiscVideoOutputTextBox.AllowDrop = true;
            this.MiscMiscVideoOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscMiscVideoOutputTextBox.EmptyTextTip = null;
            this.MiscMiscVideoOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscMiscVideoOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscMiscVideoOutputTextBox.Location = new System.Drawing.Point(9, 47);
            this.MiscMiscVideoOutputTextBox.Name = "MiscMiscVideoOutputTextBox";
            this.MiscMiscVideoOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscMiscVideoOutputTextBox.TabIndex = 6;
            // 
            // MiscMiscEndTimeMaskedTextBox
            // 
            this.MiscMiscEndTimeMaskedTextBox.Location = new System.Drawing.Point(407, 76);
            this.MiscMiscEndTimeMaskedTextBox.Mask = "90:00:00";
            this.MiscMiscEndTimeMaskedTextBox.Name = "MiscMiscEndTimeMaskedTextBox";
            this.MiscMiscEndTimeMaskedTextBox.Size = new System.Drawing.Size(70, 21);
            this.MiscMiscEndTimeMaskedTextBox.TabIndex = 19;
            this.MiscMiscEndTimeMaskedTextBox.Text = "000020";
            this.MiscMiscEndTimeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MiscMiscBeginTimeLabel
            // 
            this.MiscMiscBeginTimeLabel.AutoSize = true;
            this.MiscMiscBeginTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscBeginTimeLabel.Location = new System.Drawing.Point(92, 80);
            this.MiscMiscBeginTimeLabel.Name = "MiscMiscBeginTimeLabel";
            this.MiscMiscBeginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.MiscMiscBeginTimeLabel.TabIndex = 18;
            this.MiscMiscBeginTimeLabel.Text = "起始时刻";
            // 
            // MiscMiscEndTimeLabel
            // 
            this.MiscMiscEndTimeLabel.AutoSize = true;
            this.MiscMiscEndTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscEndTimeLabel.Location = new System.Drawing.Point(320, 79);
            this.MiscMiscEndTimeLabel.Name = "MiscMiscEndTimeLabel";
            this.MiscMiscEndTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.MiscMiscEndTimeLabel.TabIndex = 18;
            this.MiscMiscEndTimeLabel.Text = "结束时刻";
            // 
            // MiscMiscBeginTimeMaskedTextBox
            // 
            this.MiscMiscBeginTimeMaskedTextBox.Location = new System.Drawing.Point(185, 76);
            this.MiscMiscBeginTimeMaskedTextBox.Mask = "90:00:00";
            this.MiscMiscBeginTimeMaskedTextBox.Name = "MiscMiscBeginTimeMaskedTextBox";
            this.MiscMiscBeginTimeMaskedTextBox.Size = new System.Drawing.Size(70, 21);
            this.MiscMiscBeginTimeMaskedTextBox.TabIndex = 19;
            this.MiscMiscBeginTimeMaskedTextBox.Text = "000000";
            this.MiscMiscBeginTimeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MiscOnePicGroupBox
            // 
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationSecondsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationSecondsTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCrfNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCrfLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCopyAudioCheckBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicFpsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicFpsNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicKbpsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicBitrateLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicBitrateNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicOutputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicStartButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicAudioInputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicInputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicOutputTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicAudioInputTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicInputTextBox);
            this.MiscOnePicGroupBox.Location = new System.Drawing.Point(3, 3);
            this.MiscOnePicGroupBox.Name = "MiscOnePicGroupBox";
            this.MiscOnePicGroupBox.Size = new System.Drawing.Size(566, 163);
            this.MiscOnePicGroupBox.TabIndex = 22;
            this.MiscOnePicGroupBox.TabStop = false;
            this.MiscOnePicGroupBox.Text = "一图流";
            // 
            // MiscOnePicDurationSecondsLabel
            // 
            this.MiscOnePicDurationSecondsLabel.AutoSize = true;
            this.MiscOnePicDurationSecondsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicDurationSecondsLabel.Location = new System.Drawing.Point(226, 137);
            this.MiscOnePicDurationSecondsLabel.Name = "MiscOnePicDurationSecondsLabel";
            this.MiscOnePicDurationSecondsLabel.Size = new System.Drawing.Size(17, 12);
            this.MiscOnePicDurationSecondsLabel.TabIndex = 40;
            this.MiscOnePicDurationSecondsLabel.Text = "秒";
            // 
            // MiscOnePicDurationSecondsTextBox
            // 
            this.MiscOnePicDurationSecondsTextBox.Location = new System.Drawing.Point(158, 134);
            this.MiscOnePicDurationSecondsTextBox.Name = "MiscOnePicDurationSecondsTextBox";
            this.MiscOnePicDurationSecondsTextBox.Size = new System.Drawing.Size(62, 21);
            this.MiscOnePicDurationSecondsTextBox.TabIndex = 39;
            this.MiscOnePicDurationSecondsTextBox.Text = "120";
            // 
            // MiscOnePicDurationLabel
            // 
            this.MiscOnePicDurationLabel.AutoSize = true;
            this.MiscOnePicDurationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicDurationLabel.Location = new System.Drawing.Point(105, 137);
            this.MiscOnePicDurationLabel.Name = "MiscOnePicDurationLabel";
            this.MiscOnePicDurationLabel.Size = new System.Drawing.Size(29, 12);
            this.MiscOnePicDurationLabel.TabIndex = 38;
            this.MiscOnePicDurationLabel.Text = "时间";
            // 
            // MiscOnePicCrfNumericUpDown
            // 
            this.MiscOnePicCrfNumericUpDown.DecimalPlaces = 1;
            this.MiscOnePicCrfNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MiscOnePicCrfNumericUpDown.Location = new System.Drawing.Point(391, 107);
            this.MiscOnePicCrfNumericUpDown.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.MiscOnePicCrfNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiscOnePicCrfNumericUpDown.Name = "MiscOnePicCrfNumericUpDown";
            this.MiscOnePicCrfNumericUpDown.Size = new System.Drawing.Size(88, 21);
            this.MiscOnePicCrfNumericUpDown.TabIndex = 37;
            this.MiscOnePicCrfNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicCrfNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // MiscOnePicCrfLabel
            // 
            this.MiscOnePicCrfLabel.AutoSize = true;
            this.MiscOnePicCrfLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicCrfLabel.Location = new System.Drawing.Point(362, 109);
            this.MiscOnePicCrfLabel.Name = "MiscOnePicCrfLabel";
            this.MiscOnePicCrfLabel.Size = new System.Drawing.Size(23, 12);
            this.MiscOnePicCrfLabel.TabIndex = 36;
            this.MiscOnePicCrfLabel.Text = "CRF";
            // 
            // MiscOnePicCopyAudioCheckBox
            // 
            this.MiscOnePicCopyAudioCheckBox.AutoSize = true;
            this.MiscOnePicCopyAudioCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MiscOnePicCopyAudioCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicCopyAudioCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicCopyAudioCheckBox.Location = new System.Drawing.Point(390, 136);
            this.MiscOnePicCopyAudioCheckBox.Name = "MiscOnePicCopyAudioCheckBox";
            this.MiscOnePicCopyAudioCheckBox.Size = new System.Drawing.Size(74, 19);
            this.MiscOnePicCopyAudioCheckBox.TabIndex = 24;
            this.MiscOnePicCopyAudioCheckBox.Text = "复制音频";
            this.MiscOnePicCopyAudioCheckBox.UseVisualStyleBackColor = false;
            this.MiscOnePicCopyAudioCheckBox.CheckedChanged += new System.EventHandler(this.MiscOnePicCopyAudioCheckBox_CheckedChanged);
            // 
            // MiscOnePicFpsLabel
            // 
            this.MiscOnePicFpsLabel.AutoSize = true;
            this.MiscOnePicFpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicFpsLabel.Location = new System.Drawing.Point(275, 109);
            this.MiscOnePicFpsLabel.Name = "MiscOnePicFpsLabel";
            this.MiscOnePicFpsLabel.Size = new System.Drawing.Size(23, 12);
            this.MiscOnePicFpsLabel.TabIndex = 23;
            this.MiscOnePicFpsLabel.Text = "FPS";
            // 
            // MiscOnePicFpsNumericUpDown
            // 
            this.MiscOnePicFpsNumericUpDown.Location = new System.Drawing.Point(307, 107);
            this.MiscOnePicFpsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MiscOnePicFpsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiscOnePicFpsNumericUpDown.Name = "MiscOnePicFpsNumericUpDown";
            this.MiscOnePicFpsNumericUpDown.Size = new System.Drawing.Size(48, 21);
            this.MiscOnePicFpsNumericUpDown.TabIndex = 11;
            this.MiscOnePicFpsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicFpsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MiscOnePicKbpsLabel
            // 
            this.MiscOnePicKbpsLabel.AutoSize = true;
            this.MiscOnePicKbpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicKbpsLabel.Location = new System.Drawing.Point(226, 109);
            this.MiscOnePicKbpsLabel.Name = "MiscOnePicKbpsLabel";
            this.MiscOnePicKbpsLabel.Size = new System.Drawing.Size(29, 12);
            this.MiscOnePicKbpsLabel.TabIndex = 9;
            this.MiscOnePicKbpsLabel.Text = "Kbps";
            // 
            // MiscOnePicBitrateLabel
            // 
            this.MiscOnePicBitrateLabel.AutoSize = true;
            this.MiscOnePicBitrateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicBitrateLabel.Location = new System.Drawing.Point(12, 109);
            this.MiscOnePicBitrateLabel.Name = "MiscOnePicBitrateLabel";
            this.MiscOnePicBitrateLabel.Size = new System.Drawing.Size(53, 12);
            this.MiscOnePicBitrateLabel.TabIndex = 10;
            this.MiscOnePicBitrateLabel.Text = "音频码率";
            // 
            // MiscOnePicBitrateNumericUpDown
            // 
            this.MiscOnePicBitrateNumericUpDown.Location = new System.Drawing.Point(158, 107);
            this.MiscOnePicBitrateNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MiscOnePicBitrateNumericUpDown.Name = "MiscOnePicBitrateNumericUpDown";
            this.MiscOnePicBitrateNumericUpDown.Size = new System.Drawing.Size(62, 21);
            this.MiscOnePicBitrateNumericUpDown.TabIndex = 8;
            this.MiscOnePicBitrateNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicBitrateNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // MiscOnePicOutputButton
            // 
            this.MiscOnePicOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicOutputButton.Location = new System.Drawing.Point(484, 78);
            this.MiscOnePicOutputButton.Name = "MiscOnePicOutputButton";
            this.MiscOnePicOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicOutputButton.TabIndex = 3;
            this.MiscOnePicOutputButton.Text = "输出";
            this.MiscOnePicOutputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicOutputButton.Click += new System.EventHandler(this.MiscOnePicOutputButton_Click);
            // 
            // MiscOnePicStartButton
            // 
            this.MiscOnePicStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicStartButton.Location = new System.Drawing.Point(484, 107);
            this.MiscOnePicStartButton.Name = "MiscOnePicStartButton";
            this.MiscOnePicStartButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicStartButton.TabIndex = 2;
            this.MiscOnePicStartButton.Text = "压制";
            this.MiscOnePicStartButton.UseVisualStyleBackColor = true;
            this.MiscOnePicStartButton.Click += new System.EventHandler(this.MiscOnePicStartButton_Click);
            // 
            // MiscOnePicAudioInputButton
            // 
            this.MiscOnePicAudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicAudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicAudioInputButton.Location = new System.Drawing.Point(484, 49);
            this.MiscOnePicAudioInputButton.Name = "MiscOnePicAudioInputButton";
            this.MiscOnePicAudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicAudioInputButton.TabIndex = 2;
            this.MiscOnePicAudioInputButton.Text = "音频";
            this.MiscOnePicAudioInputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicAudioInputButton.Click += new System.EventHandler(this.MiscOnePicAudioInputButton_Click);
            // 
            // MiscOnePicInputButton
            // 
            this.MiscOnePicInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicInputButton.Location = new System.Drawing.Point(484, 20);
            this.MiscOnePicInputButton.Name = "MiscOnePicInputButton";
            this.MiscOnePicInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicInputButton.TabIndex = 2;
            this.MiscOnePicInputButton.Text = "图片";
            this.MiscOnePicInputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicInputButton.Click += new System.EventHandler(this.MiscOnePicInputButton_Click);
            // 
            // MiscOnePicOutputTextBox
            // 
            this.MiscOnePicOutputTextBox.AllowDrop = true;
            this.MiscOnePicOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicOutputTextBox.EmptyTextTip = null;
            this.MiscOnePicOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicOutputTextBox.Location = new System.Drawing.Point(10, 78);
            this.MiscOnePicOutputTextBox.Name = "MiscOnePicOutputTextBox";
            this.MiscOnePicOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicOutputTextBox.TabIndex = 1;
            // 
            // MiscOnePicAudioInputTextBox
            // 
            this.MiscOnePicAudioInputTextBox.AllowDrop = true;
            this.MiscOnePicAudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicAudioInputTextBox.EmptyTextTip = null;
            this.MiscOnePicAudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicAudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicAudioInputTextBox.Location = new System.Drawing.Point(10, 49);
            this.MiscOnePicAudioInputTextBox.Name = "MiscOnePicAudioInputTextBox";
            this.MiscOnePicAudioInputTextBox.ReadOnly = true;
            this.MiscOnePicAudioInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicAudioInputTextBox.TabIndex = 1;
            this.MiscOnePicAudioInputTextBox.TextChanged += new System.EventHandler(this.MiscOnePicAudioInputTextBox_TextChanged);
            // 
            // MiscOnePicInputTextBox
            // 
            this.MiscOnePicInputTextBox.AllowDrop = true;
            this.MiscOnePicInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicInputTextBox.EmptyTextTip = null;
            this.MiscOnePicInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicInputTextBox.Location = new System.Drawing.Point(10, 20);
            this.MiscOnePicInputTextBox.Name = "MiscOnePicInputTextBox";
            this.MiscOnePicInputTextBox.ReadOnly = true;
            this.MiscOnePicInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicInputTextBox.TabIndex = 0;
            // 
            // MiscUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MiscMiscGroupBox);
            this.Controls.Add(this.MiscOnePicGroupBox);
            this.Name = "MiscUserControl";
            this.Size = new System.Drawing.Size(566, 543);
            this.MiscMiscGroupBox.ResumeLayout(false);
            this.MiscMiscGroupBox.PerformLayout();
            this.MiscOnePicGroupBox.ResumeLayout(false);
            this.MiscOnePicGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicCrfNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicFpsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicBitrateNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MiscMiscGroupBox;
        private System.Windows.Forms.Label MiscMiscTransposeLabel;
        private System.Windows.Forms.ComboBox MiscMiscTransposeComboBox;
        private ControlExs.QQButton MiscMiscStartRotateButton;
        private ControlExs.QQTextBox MiscMiscVideoInputTextBox;
        private ControlExs.QQButton MiscMiscVideoInputButton;
        private ControlExs.QQButton MiscMiscVideoOutputButton;
        private ControlExs.QQButton MiscMiscStartClipButton;
        private ControlExs.QQTextBox MiscMiscVideoOutputTextBox;
        private System.Windows.Forms.MaskedTextBox MiscMiscEndTimeMaskedTextBox;
        private System.Windows.Forms.Label MiscMiscBeginTimeLabel;
        private System.Windows.Forms.Label MiscMiscEndTimeLabel;
        private System.Windows.Forms.MaskedTextBox MiscMiscBeginTimeMaskedTextBox;
        private System.Windows.Forms.GroupBox MiscOnePicGroupBox;
        private System.Windows.Forms.Label MiscOnePicDurationSecondsLabel;
        private System.Windows.Forms.TextBox MiscOnePicDurationSecondsTextBox;
        private System.Windows.Forms.Label MiscOnePicDurationLabel;
        private System.Windows.Forms.NumericUpDown MiscOnePicCrfNumericUpDown;
        private System.Windows.Forms.Label MiscOnePicCrfLabel;
        private ControlExs.QQCheckBox MiscOnePicCopyAudioCheckBox;
        private System.Windows.Forms.Label MiscOnePicFpsLabel;
        private System.Windows.Forms.NumericUpDown MiscOnePicFpsNumericUpDown;
        private System.Windows.Forms.Label MiscOnePicKbpsLabel;
        private System.Windows.Forms.Label MiscOnePicBitrateLabel;
        private System.Windows.Forms.NumericUpDown MiscOnePicBitrateNumericUpDown;
        private ControlExs.QQButton MiscOnePicOutputButton;
        private ControlExs.QQButton MiscOnePicStartButton;
        private ControlExs.QQButton MiscOnePicAudioInputButton;
        private ControlExs.QQButton MiscOnePicInputButton;
        private ControlExs.QQTextBox MiscOnePicOutputTextBox;
        private ControlExs.QQTextBox MiscOnePicAudioInputTextBox;
        private ControlExs.QQTextBox MiscOnePicInputTextBox;
    }
}
