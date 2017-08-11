using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;

namespace mp4box
{
    public class UpdateChecker
    {
        private const string UpdateURL = "http://maruko.appinn.me/config/version.html";
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";

        public bool NewVersionFound;
        public string LatestVersionNumber;
        public string LatestVersionSuffix;
        public string LatestVersionName;
        public string LatestVersionURL;
        public string LatestVersionLocalName;
        public event EventHandler CheckUpdateCompleted;

        public const string Version = "1.0.0";

        public void CheckUpdate()
        {
            try
            {
                WebClient http = CreateWebClient();
                http.DownloadStringCompleted += Http_DownloadStringCompleted;
                http.DownloadStringAsync(new Uri(UpdateURL));
            }
            catch (Exception ex)
            {
            }
        }

        private static WebClient CreateWebClient()
        {
            WebClient http = new WebClient();
            http.Headers.Add("User-Agent", UserAgent);
            return http;
        }

        private void Http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string response = e.Result;

                // todo: logic to parse the result


                if (NewVersionFound)
                {
                    StartDownload();
                }
                else
                {
                    CheckUpdateCompleted?.Invoke(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void StartDownload()
        {
            try
            {
                //LatestVersionLocalName = Utils.GetTempPath(LatestVersionName);
                WebClient http = CreateWebClient();
                http.DownloadFileCompleted += Http_DownloadFileCompleted;
                http.DownloadFileAsync(new Uri(LatestVersionURL), LatestVersionLocalName);
            }
            catch (Exception ex)
            {
            }
        }


        private void Http_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    //log e.Error
                    return;
                }
                //Logging.Debug($"New version {LatestVersionNumber}{LatestVersionSuffix} found: {LatestVersionLocalName}");
                CheckUpdateCompleted?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
            }
        }
    }
}

