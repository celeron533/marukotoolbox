// ------------------------------------------------------------------
// Copyright (C) 2015-2016 Maruko Toolbox Project
//
//  Authors: komaruchan <sandy_0308@hotmail.com>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied.
// See the License for the specific language governing permissions
// and limitations under the License.
// -------------------------------------------------------------------
//

using ControlExs;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp4box
{
    public partial class FeedbackForm : FormBase
    {
        public FeedbackForm()
        {
            InitializeComponent();
        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {

        }

        private string ReadLogFile(string logPath)
        {
            string logContent = File.ReadAllText(logPath, Encoding.Default);
            //logContent = logContent.Replace("\r\n", "<br /");
            return logContent;
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            string name = UserNameTextBox.Text;
            string qq = QQTextBox.Text;
            string email = EmailTextBox.Text;
            string title = TitleTextBox.Text;
            string msg = GetSystemInfo() + MessageTextBox.Text;
            string log = string.Empty;
            if (!string.IsNullOrEmpty(LogPathTextBox.Text))
            {
                if (File.Exists(LogPathTextBox.Text))
                {
                    log = ReadLogFile(LogPathTextBox.Text);
                }
                else
                {
                    ShowErrorMessage("请输入正确的日志文件路径!");
                    return;
                }
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(msg))
            {
                ShowWarningMessage("请填写以上必填项后再提交!");
                return;
            }

            ServiceReference.WebServiceSoapClient service = new ServiceReference.WebServiceSoapClient();
            bool flag = service.PostFeedback(name, qq, email, title, msg, log);

            if (flag)
            {
                ShowInfoMessage("提交成功，感谢反馈!");
            }
            else
            {
                ShowErrorMessage("提交失败!");
            }
            TitleTextBox.Clear();
            MessageTextBox.Clear();
        }

        private void LogFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "日志文件(*.log)|*.log|所有文件(*.*)|*.*";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                LogPathTextBox.Text = ofd.FileName;
            }
        }

        private static string GetSystemInfo()
        {
            var sb = new StringBuilder();
            var version4 = OSInfo.GetDotNetVersion("4.0");
            var version = OSInfo.GetDotNetVersion();
            sb.Append(string.Format("小丸工具箱 版本: {0}", AssemblyInfo.GetAssemblyFileVersion()));
            sb.Append(string.Format("\r\n操作系统: {0}{1} ({2}.{3}.{4}.{5})",
                OSInfo.GetOSName(), OSInfo.GetOSServicePack(), OSInfo.OSMajorVersion, OSInfo.OSMinorVersion,
                OSInfo.OSRevisionVersion, OSInfo.OSBuildVersion));
            if (string.IsNullOrEmpty(version4))
                sb.Append("\r\n.NET Framework 4.0 未安装");
            else
                sb.Append(string.Format("\r\nMicrosoft .NET Framework: {0}", version4));
            if (!string.IsNullOrEmpty(version) && !version4.Equals(version))
                sb.Append(string.Format("\r\nMicrosoft .NET Framework: {0}", version));
            if (!string.IsNullOrEmpty(FileString.CheckAviSynth()))
                sb.Append("\r\n" + FileString.CheckAviSynth());
            else if (!string.IsNullOrEmpty(FileString.CheckinternalAviSynth()))
                sb.Append("\r\n" + FileString.CheckinternalAviSynth() + " (本地内置的绿色版本)");
            else
                sb.Append("\r\nAvisynth 未安装");
            sb.Append("\r\n------------------------------以上信息为自动检测-----------------------------\r\n\r\n");
            return sb.ToString();
        }
    }
}
