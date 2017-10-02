using mp4box.Extension;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mp4box.Utility
{
    public class UpdateCheckerUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        const string UpdateURL = "http://maruko.appinn.me/config/version.html";
        Version currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        private readonly DateTime ReleaseDate = AssemblyUtil.GetAssemblyVersionTime();
        bool @explicit;

        /// <summary>
        /// Check for updates
        /// </summary>
        /// <param name="explicit"></param>
        public void CheckUpdate(bool @explicit = true)
        {
            this.@explicit = @explicit;

            if (NetworkUtil.IsConnectInternet())
            {
                try
                {
                    WebClient http = new WebClient();
                    http.DownloadStringCompleted += Http_DownloadStringCompleted;
                    http.DownloadStringAsync(new Uri(UpdateURL));
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }

            }
            else
            {
                if (@explicit)
                    MessageBoxExt.ShowErrorMessage("这台电脑似乎没有联网呢~");
            }
        }

        /// <summary>
        /// Parse the new release info from the target web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string response = e.Result;
            Regex dateReg = new Regex(@"Date20\S+Date");
            Regex VersionReg = new Regex(@"Version\d+Version");
            Match dateMatch = dateReg.Match(response);
            Match versionMatch = VersionReg.Match(response);
            DateTime newDate = DateTime.Parse("1990-03-08");//LOL

            if (dateMatch.Success)
            {
                string date = dateMatch.Value.Replace("Date", "");
                string version = versionMatch.Value.Replace("Version", "");

                newDate = DateTime.Parse(date);
                int minorVersion = int.Parse(version);
                bool isFullUpdate = (minorVersion > currentVersion.Minor);

                if (newDate > ReleaseDate)
                {
                    if (isFullUpdate)
                    {
                        if (DialogResult.Yes ==
                            MessageBoxExt.ShowQuestion($"新版已于{newDate.ToString("yyyy-MM-dd")}发布，是否前往官网下载？", "喜大普奔"))
                        {
                            Process.Start("http://maruko.appinn.me/");
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes ==
                            MessageBoxExt.ShowQuestion($"新版已于{newDate.ToString("yyyy-MM-dd")}发布，是否自动升级？（文件约1.5MB）", "喜大普奔"))
                        {
                            FormUpdater formUpdater = new FormUpdater(Global.Running.startPath, date);
                            formUpdater.ShowDialog();
                        }
                    }
                }
                else
                {
                    if (@explicit)
                        MessageBoxExt.ShowInfoMessage("已经是最新版了喵！");
                }
            }

        }
    }
}
