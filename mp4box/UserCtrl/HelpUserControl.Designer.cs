namespace mp4box.UserCtrl
{
    partial class HelpUserControl
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
            this.HelpFeedbackButton = new ControlExs.QQButton();
            this.HelpContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.HelpReleaseDateLabel = new System.Windows.Forms.Label();
            this.HelpReleaseDateInfoLabel = new System.Windows.Forms.Label();
            this.HelpCheckUpdateButton = new ControlExs.QQButton();
            this.HelpHomepageButton = new ControlExs.QQButton();
            this.HelpAboutButton = new ControlExs.QQButton();
            this.SuspendLayout();
            // 
            // HelpFeedbackButton
            // 
            this.HelpFeedbackButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.HelpFeedbackButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpFeedbackButton.Location = new System.Drawing.Point(189, 556);
            this.HelpFeedbackButton.Name = "HelpFeedbackButton";
            this.HelpFeedbackButton.Size = new System.Drawing.Size(99, 23);
            this.HelpFeedbackButton.TabIndex = 50;
            this.HelpFeedbackButton.Text = "反馈问题";
            this.HelpFeedbackButton.UseVisualStyleBackColor = true;
            this.HelpFeedbackButton.Click += new System.EventHandler(this.HelpFeedbackButton_Click);
            // 
            // HelpContentRichTextBox
            // 
            this.HelpContentRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.HelpContentRichTextBox.Name = "HelpContentRichTextBox";
            this.HelpContentRichTextBox.ReadOnly = true;
            this.HelpContentRichTextBox.Size = new System.Drawing.Size(548, 547);
            this.HelpContentRichTextBox.TabIndex = 46;
            this.HelpContentRichTextBox.Text = "";
            this.HelpContentRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.HelpContentRichTextBox_LinkClicked);
            // 
            // HelpReleaseDateLabel
            // 
            this.HelpReleaseDateLabel.AutoSize = true;
            this.HelpReleaseDateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpReleaseDateLabel.Location = new System.Drawing.Point(82, 562);
            this.HelpReleaseDateLabel.Name = "HelpReleaseDateLabel";
            this.HelpReleaseDateLabel.Size = new System.Drawing.Size(0, 12);
            this.HelpReleaseDateLabel.TabIndex = 49;
            this.HelpReleaseDateLabel.DoubleClick += new System.EventHandler(this.HelpReleaseDateLabel_DoubleClick);
            // 
            // HelpReleaseDateInfoLabel
            // 
            this.HelpReleaseDateInfoLabel.AutoSize = true;
            this.HelpReleaseDateInfoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpReleaseDateInfoLabel.Location = new System.Drawing.Point(7, 562);
            this.HelpReleaseDateInfoLabel.Name = "HelpReleaseDateInfoLabel";
            this.HelpReleaseDateInfoLabel.Size = new System.Drawing.Size(53, 12);
            this.HelpReleaseDateInfoLabel.TabIndex = 48;
            this.HelpReleaseDateInfoLabel.Text = "发布日期";
            // 
            // HelpCheckUpdateButton
            // 
            this.HelpCheckUpdateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.HelpCheckUpdateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpCheckUpdateButton.Location = new System.Drawing.Point(294, 556);
            this.HelpCheckUpdateButton.Name = "HelpCheckUpdateButton";
            this.HelpCheckUpdateButton.Size = new System.Drawing.Size(116, 23);
            this.HelpCheckUpdateButton.TabIndex = 47;
            this.HelpCheckUpdateButton.Text = "检查更新";
            this.HelpCheckUpdateButton.UseVisualStyleBackColor = true;
            this.HelpCheckUpdateButton.Click += new System.EventHandler(this.HelpCheckUpdateButton_Click);
            // 
            // HelpHomepageButton
            // 
            this.HelpHomepageButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.HelpHomepageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpHomepageButton.Location = new System.Drawing.Point(416, 556);
            this.HelpHomepageButton.Name = "HelpHomepageButton";
            this.HelpHomepageButton.Size = new System.Drawing.Size(67, 23);
            this.HelpHomepageButton.TabIndex = 45;
            this.HelpHomepageButton.Text = "软件主页";
            this.HelpHomepageButton.UseVisualStyleBackColor = true;
            this.HelpHomepageButton.Click += new System.EventHandler(this.HelpHomepageButton_Click);
            // 
            // HelpAboutButton
            // 
            this.HelpAboutButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.HelpAboutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HelpAboutButton.Location = new System.Drawing.Point(489, 556);
            this.HelpAboutButton.Name = "HelpAboutButton";
            this.HelpAboutButton.Size = new System.Drawing.Size(62, 23);
            this.HelpAboutButton.TabIndex = 44;
            this.HelpAboutButton.Text = "关于";
            this.HelpAboutButton.UseVisualStyleBackColor = true;
            this.HelpAboutButton.Click += new System.EventHandler(this.HelpAboutButton_Click);
            // 
            // HelpUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HelpFeedbackButton);
            this.Controls.Add(this.HelpContentRichTextBox);
            this.Controls.Add(this.HelpReleaseDateLabel);
            this.Controls.Add(this.HelpReleaseDateInfoLabel);
            this.Controls.Add(this.HelpCheckUpdateButton);
            this.Controls.Add(this.HelpHomepageButton);
            this.Controls.Add(this.HelpAboutButton);
            this.Name = "HelpUserControl";
            this.Size = new System.Drawing.Size(556, 582);
            this.Load += new System.EventHandler(this.HelpUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlExs.QQButton HelpFeedbackButton;
        private System.Windows.Forms.RichTextBox HelpContentRichTextBox;
        private System.Windows.Forms.Label HelpReleaseDateLabel;
        private System.Windows.Forms.Label HelpReleaseDateInfoLabel;
        private ControlExs.QQButton HelpCheckUpdateButton;
        private ControlExs.QQButton HelpHomepageButton;
        private ControlExs.QQButton HelpAboutButton;
    }
}
