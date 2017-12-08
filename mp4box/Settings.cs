using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace mp4box
{
    public class Settings
    {
        Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #region Members
        public int VideoEncoderIndex;
        public string AudioBitrateComboText;    // this is a string
        public int AudioEncoderIndex;
        public string AvsScriptText;
        public bool ConfigFunctionAutoCheckUpdateCheck;
        public bool ConfigFunctionDeleteTempFileCheck;
        public bool ConfigFunctionEnableX265Check;
        public string ConfigFunctionVideoPlayerText;
        public bool ConfigUiSplashScreenCheck;
        public bool ConfigUiTrayModeCheck;
        public int ConfigUiLanguageIndex;
        public string ConfigX264ExtraParameterText;
        public int ConfigX264Priority;  //Cast as ProcessPriorityClass
        public int ConfigX264Threads;
        public decimal MiscBlackBitrateValue;
        public decimal MiscBlackCrfValue;
        public decimal MiscBlackFpsValue;
        public decimal MiscOnePicBitrateValue;
        public decimal MiscOnePicCrfValue;
        public decimal MiscOnePicFpsValue;
        public int MuxConvertFormatIndex;
        public int VideoAudioModeIndex;
        public string VideoAudioParameterText;
        public string VideoBatchSubtitleLanguage;
        public decimal VideoBitrateValue;
        public decimal VideoCrfValue;
        public string VideoCustomParameterText;
        public int VideoDemuxerIndex;
        public decimal VideoHeightValue;
        public decimal VideoWidthValue;

        #endregion Members End

        public Settings()
        {
            Load();
        }

        public void Load()
        {
            GetValue(out AudioBitrateComboText, "AudioBitrate");
            GetValue(out AudioEncoderIndex, "AudioEncoder");
            GetValue(out AvsScriptText, "AVSScript");
            GetValue(out ConfigFunctionAutoCheckUpdateCheck, "CheckUpdate");
            GetValue(out ConfigFunctionDeleteTempFileCheck, "SetupDeleteTempFile");
            GetValue(out ConfigFunctionEnableX265Check, "x265Enable");
            GetValue(out ConfigFunctionVideoPlayerText, "PreviewPlayer");
            GetValue(out ConfigUiLanguageIndex, "LanguageIndex");
            GetValue(out ConfigUiSplashScreenCheck, "SplashScreen");
            GetValue(out ConfigUiTrayModeCheck, "TrayMode");
            GetValue(out ConfigX264ExtraParameterText, "x264ExtraParameter");
            GetValue(out ConfigX264Priority, "x264Priority");
            GetValue(out ConfigX264Threads, "x264Threads");
            GetValue(out MiscBlackBitrateValue, "BlackBitrate");
            GetValue(out MiscBlackCrfValue, "BlackCRF");
            GetValue(out MiscBlackFpsValue, "BlackFPS");
            GetValue(out MiscOnePicBitrateValue, "OnePicAudioBitrate");
            GetValue(out MiscOnePicCrfValue, "OnePicCRF");
            GetValue(out MiscOnePicFpsValue, "OnePicFPS");
            GetValue(out MuxConvertFormatIndex, "MuxFormat");
            GetValue(out VideoAudioModeIndex, "x264AudioMode");
            GetValue(out VideoAudioParameterText, "x264AudioParameter");
            GetValue(out VideoBitrateValue, "x264Bitrate");
            GetValue(out VideoCrfValue, "x264CRF");
            GetValue(out VideoCustomParameterText, "x264CustomParameter");
            GetValue(out VideoDemuxerIndex, "x264Demuxer");
            GetValue(out VideoEncoderIndex, "x264Exe");
            GetValue(out VideoHeightValue, "x264Height");
            GetValue(out VideoWidthValue, "x264Width");
            GetValue(out VideoBatchSubtitleLanguage, "SubLanguageExtension");
        }

        public void Save()
        {
            SetValue("AudioBitrate", AudioBitrateComboText);
            SetValue("AudioEncoder", AudioEncoderIndex);
            SetValue("AVSScript", AvsScriptText);
            SetValue("BlackBitrate", MiscBlackBitrateValue);
            SetValue("BlackCRF", MiscBlackCrfValue);
            SetValue("BlackFPS", MiscBlackFpsValue);
            SetValue("CheckUpdate", ConfigFunctionAutoCheckUpdateCheck);
            SetValue("LanguageIndex", ConfigUiLanguageIndex);
            SetValue("MuxFormat", MuxConvertFormatIndex);
            SetValue("OnePicAudioBitrate", MiscOnePicBitrateValue);
            SetValue("OnePicCRF", MiscOnePicCrfValue);
            SetValue("OnePicFPS", MiscOnePicFpsValue);
            SetValue("PreviewPlayer", ConfigFunctionVideoPlayerText);
            SetValue("SetupDeleteTempFile", ConfigFunctionDeleteTempFileCheck);
            SetValue("SplashScreen", ConfigUiSplashScreenCheck);
            SetValue("TrayMode", ConfigUiTrayModeCheck);
            SetValue("x264AudioMode", VideoAudioModeIndex);
            SetValue("x264AudioParameter", VideoAudioParameterText);
            SetValue("x264Bitrate", VideoBitrateValue);
            SetValue("x264CRF", VideoCrfValue);
            SetValue("x264CustomParameter", VideoCustomParameterText);
            SetValue("x264Demuxer", VideoDemuxerIndex);
            SetValue("x264Exe", VideoEncoderIndex);
            SetValue("x264ExtraParameter", ConfigX264ExtraParameterText);
            SetValue("x264Height", VideoHeightValue);
            SetValue("x264Priority", ConfigX264Priority);
            SetValue("x264Threads", ConfigX264Threads);
            SetValue("x264Width", VideoWidthValue);
            SetValue("x265Enable", ConfigFunctionEnableX265Check);
            SetValue("SubLanguageExtension", VideoBatchSubtitleLanguage);

            cfa.Save();
        }

        // Get Set for int
        private void GetValue(out int value, string key, int defaultValue = 0)
        {
            try
            {
                value = int.Parse(cfa.AppSettings.Settings[key].Value);
            }
            catch
            {
                value = defaultValue;
            }
        }

        private void SetValue(string key, int value)
        {
            cfa.AppSettings.Settings[key].Value = Convert.ToString(value.ToString());
        }

        // Get Set for bool
        private void GetValue(out bool value, string key, bool defaultValue = false)
        {
            try
            {
                value = bool.Parse(cfa.AppSettings.Settings[key].Value);
            }
            catch
            {
                value = defaultValue;
            }
        }

        private void SetValue(string key, bool value)
        {
            cfa.AppSettings.Settings[key].Value = Convert.ToString(value.ToString());
        }

        // Get Set for decimal
        private void GetValue(out decimal value, string key, decimal defaultValue = 0)
        {
            try
            {
                value = decimal.Parse(cfa.AppSettings.Settings[key].Value);
            }
            catch
            {
                value = defaultValue;
            }
        }

        private void SetValue(string key, decimal value)
        {
            cfa.AppSettings.Settings[key].Value = Convert.ToString(value.ToString());
        }

        // Get Set for string
        private void GetValue(out string value, string key, string defaultValue = "")
        {
            try
            {
                value = cfa.AppSettings.Settings[key].Value;
            }
            catch
            {
                value = defaultValue;
            }
        }

        private void SetValue(string key, string value)
        {
            cfa.AppSettings.Settings[key].Value = value;
        }
    }
}
