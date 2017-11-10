using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ControlExs;
using System.Diagnostics;

namespace mp4box.UserCtrl
{
    public partial class HelpUserControl : UserControl
    {
        public HelpUserControl()
        {
            InitializeComponent();
        }

        private void HelpUserControl_Load(object sender, EventArgs e)
        {
            HelpReleaseDateLabel.Text = Global.ReleaseDate.ToString("yyyy-M-d");

            // load Help Text
            if (File.Exists(Global.Running.startPath + "\\help.rtf"))
            {
                HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help.rtf");
            }
            else
            {
                HelpContentRichTextBox.Text = "help.rtf is not found.";
            }
        }

        private void HelpFeedbackButton_Click(object sender, EventArgs e)
        {
            new FeedbackForm().ShowDialog();
        }

        private void HelpReleaseDateLabel_DoubleClick(object sender, EventArgs e)
        {
            new SplashForm() { Owner = ParentForm }.Show();
        }

        private void HelpCheckUpdateButton_Click(object sender, EventArgs e)
        {
            new UpdateCheckerUtil().CheckUpdate();
        }

        private void HelpHomepageButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://maruko.appinn.me/");
        }

        private void HelpAboutButton_Click(object sender, EventArgs e)
        {
            DateTime CompileDate = File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
            QQMessageBox.Show(
                ParentForm,
                "主页：http://maruko.appinn.me/ \r\n编译日期：" + Global.ReleaseDate.ToString() + "\r\n作者：小七、月儿、小丸",
                "关于",
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
        }

        private void HelpContentRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
