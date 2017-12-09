namespace mp4box.UserCtrl
{
    partial class MediaInfoUserControl
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
            this.MediaInfoVideoInputButton = new ControlExs.QQButton();
            this.MediaInfoPlayVideoButton = new ControlExs.QQButton();
            this.MediaInfoCopyButton = new ControlExs.QQButton();
            this.MediaInfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MediaInfoVideoInputButton
            // 
            this.MediaInfoVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MediaInfoVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MediaInfoVideoInputButton.Location = new System.Drawing.Point(478, 558);
            this.MediaInfoVideoInputButton.Name = "MediaInfoVideoInputButton";
            this.MediaInfoVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MediaInfoVideoInputButton.TabIndex = 20;
            this.MediaInfoVideoInputButton.Text = "选择视频";
            this.MediaInfoVideoInputButton.UseVisualStyleBackColor = true;
            this.MediaInfoVideoInputButton.Click += new System.EventHandler(this.MediaInfoVideoInputButton_Click);
            // 
            // MediaInfoPlayVideoButton
            // 
            this.MediaInfoPlayVideoButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MediaInfoPlayVideoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MediaInfoPlayVideoButton.Location = new System.Drawing.Point(380, 558);
            this.MediaInfoPlayVideoButton.Name = "MediaInfoPlayVideoButton";
            this.MediaInfoPlayVideoButton.Size = new System.Drawing.Size(75, 23);
            this.MediaInfoPlayVideoButton.TabIndex = 21;
            this.MediaInfoPlayVideoButton.Text = "播放视频";
            this.MediaInfoPlayVideoButton.UseVisualStyleBackColor = true;
            this.MediaInfoPlayVideoButton.Click += new System.EventHandler(this.MediaInfoPlayVideoButton_Click);
            // 
            // MediaInfoCopyButton
            // 
            this.MediaInfoCopyButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MediaInfoCopyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MediaInfoCopyButton.Location = new System.Drawing.Point(280, 558);
            this.MediaInfoCopyButton.Name = "MediaInfoCopyButton";
            this.MediaInfoCopyButton.Size = new System.Drawing.Size(75, 23);
            this.MediaInfoCopyButton.TabIndex = 22;
            this.MediaInfoCopyButton.Text = "复制信息";
            this.MediaInfoCopyButton.UseVisualStyleBackColor = true;
            this.MediaInfoCopyButton.Click += new System.EventHandler(this.MediaInfoCopyButton_Click);
            // 
            // MediaInfoTextBox
            // 
            this.MediaInfoTextBox.AllowDrop = true;
            this.MediaInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MediaInfoTextBox.Font = new System.Drawing.Font("SimSun-ExtB", 9.75F);
            this.MediaInfoTextBox.Location = new System.Drawing.Point(3, 3);
            this.MediaInfoTextBox.Multiline = true;
            this.MediaInfoTextBox.Name = "MediaInfoTextBox";
            this.MediaInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MediaInfoTextBox.Size = new System.Drawing.Size(550, 549);
            this.MediaInfoTextBox.TabIndex = 19;
            this.MediaInfoTextBox.Text = "请把多媒体文件拖到这里";
            this.MediaInfoTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.MediaInfoTextBox_DragDrop);
            this.MediaInfoTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.MediaInfoTextBox_DragEnter);
            this.MediaInfoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MediaInfoTextBox_KeyDown);
            // 
            // MediaInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MediaInfoVideoInputButton);
            this.Controls.Add(this.MediaInfoPlayVideoButton);
            this.Controls.Add(this.MediaInfoCopyButton);
            this.Controls.Add(this.MediaInfoTextBox);
            this.Name = "MediaInfoUserControl";
            this.Size = new System.Drawing.Size(561, 588);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlExs.QQButton MediaInfoVideoInputButton;
        private ControlExs.QQButton MediaInfoPlayVideoButton;
        private ControlExs.QQButton MediaInfoCopyButton;
        private System.Windows.Forms.TextBox MediaInfoTextBox;
    }
}
