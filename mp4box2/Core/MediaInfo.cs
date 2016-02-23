using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Wapper = mp4box2.Utility.MediaInfoWapper;

namespace mp4box2.Core
{
    public class MediaInfo
    {
        public MediaInfo()
        { }

        public string fileName;
        public General general;
        public Video video;
        public Audio audio;

        #region Classes: General, Video, Audio
        public class General
        {
            public string container;
            public string bitRate;
            public string duration;
            public string fileSize;
        }

        public class Video
        {
            public string id;
            public string format;
            public string bitRate;
            public string size;
            public string width;
            public string height;
            public string displayAspectRatio;
            public string displayAspectRatio2;
            public string frameRate;
            public string colorSpace;
            public string chromaSubsampling;
            public string bitDepth;
            public string scanType;
            public string pixelAspectRatio;
            public string encodedLibrary;
            public string encodingSettings;
            public string encodedTime;
            public string codecProfile;
            public string frameCount;
        }

        public class Audio
        {
            public string id;
            public string format;
            public string bitRate;
            public string samplingRate;
            public string channel;
            public string size;
        }
        #endregion

        public void LoadMediaInfo(string fileName)
        {
            this.fileName = fileName;
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            Wapper.MediaInfo MI = new Wapper.MediaInfo();
            MI.Open(fileName);
            //General
            general = new General();
            general.container = MI.Get(Wapper.StreamKind.General, 0, "Format");
            general.bitRate = MI.Get(Wapper.StreamKind.General, 0, "BitRate/String");
            general.duration = MI.Get(Wapper.StreamKind.General, 0, "Duration/String1");
            general.fileSize = MI.Get(Wapper.StreamKind.General, 0, "FileSize/String");

            //Video
            video = new Video();
            video.id = MI.Get(Wapper.StreamKind.Video, 0, "ID");
            video.format = MI.Get(Wapper.StreamKind.Video, 0, "Format");
            video.bitRate = MI.Get(Wapper.StreamKind.Video, 0, "BitRate/String");
            video.size = MI.Get(Wapper.StreamKind.Video, 0, "StreamSize/String");
            video.width = MI.Get(Wapper.StreamKind.Video, 0, "Width");
            video.height = MI.Get(Wapper.StreamKind.Video, 0, "Height");
            video.displayAspectRatio = MI.Get(Wapper.StreamKind.Video, 0, "DisplayAspectRatio/String");
            video.displayAspectRatio2 = MI.Get(Wapper.StreamKind.Video, 0, "DisplayAspectRatio");
            video.frameRate = MI.Get(Wapper.StreamKind.Video, 0, "FrameRate/String");
            video.colorSpace = MI.Get(Wapper.StreamKind.Video, 0, "ColorSpace");
            video.chromaSubsampling = MI.Get(Wapper.StreamKind.Video, 0, "ChromaSubsampling");
            video.bitDepth = MI.Get(Wapper.StreamKind.Video, 0, "BitDepth/String");
            video.scanType = MI.Get(Wapper.StreamKind.Video, 0, "ScanType/String");
            video.pixelAspectRatio = MI.Get(Wapper.StreamKind.Video, 0, "PixelAspectRatio");
            video.encodedLibrary = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Library/String");
            video.encodingSettings = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Library_Settings");
            video.encodedTime = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Date");
            video.codecProfile = MI.Get(Wapper.StreamKind.Video, 0, "Codec_Profile");
            video.frameCount = MI.Get(Wapper.StreamKind.Video, 0, "FrameCount");

            //Audio
            audio = new Audio();
            audio.id = MI.Get(Wapper.StreamKind.Audio, 0, "ID");
            audio.format = MI.Get(Wapper.StreamKind.Audio, 0, "Format");
            audio.bitRate = MI.Get(Wapper.StreamKind.Audio, 0, "BitRate/String");
            audio.samplingRate = MI.Get(Wapper.StreamKind.Audio, 0, "SamplingRate/String");
            audio.channel = MI.Get(Wapper.StreamKind.Audio, 0, "Channel(s)");
            audio.size = MI.Get(Wapper.StreamKind.Audio, 0, "StreamSize/String");

            //string audioInfo = MI.Get(Wapper.StreamKind.Audio, 0, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 1, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 2, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 3, "Inform");
            //string videoInfo = MI.Get(Wapper.StreamKind.Video, 0, "Inform");

            MI.Close();
        }


        public string GetSummary()
        {
            StringBuilder info = new StringBuilder();
            info = info.AppendLine(Path.GetFileName(fileName));
            if (general != null)
            {
                if (!string.IsNullOrEmpty(general.container))
                    info.AppendLine("容器：" + general.container);
                if (!string.IsNullOrEmpty(general.bitRate))
                    info.AppendLine("总码率：" + general.bitRate);
                if (!string.IsNullOrEmpty(general.fileSize))
                    info.AppendLine("大小：" + general.fileSize);
                if (!string.IsNullOrEmpty(general.duration))
                    info.AppendLine("时长：" + general.duration);
            }

            if (video != null)
            {
                if (!string.IsNullOrEmpty(video.format))
                    info.AppendLine("\r\n" + "视频(" + video.id + ")：" + video.format);
                if (!string.IsNullOrEmpty(video.codecProfile))
                    info.AppendLine("Profile：" + video.codecProfile);
                if (!string.IsNullOrEmpty(video.bitRate))
                    info.AppendLine("码率：" + video.bitRate);
                if (!string.IsNullOrEmpty(video.size))
                    info.AppendLine("文件大小：" + video.size);
                if (!string.IsNullOrEmpty(video.width) && !string.IsNullOrEmpty(video.height))
                    info.AppendLine("分辨率：" + video.width + "x" + video.height);
                if (!string.IsNullOrEmpty(video.displayAspectRatio) && !string.IsNullOrEmpty(video.displayAspectRatio2))
                    info.AppendLine("画面比例：" + video.displayAspectRatio + "(" + video.displayAspectRatio2 + ")");
                if (!string.IsNullOrEmpty(video.pixelAspectRatio))
                    info.AppendLine("像素宽高比：" + video.pixelAspectRatio);
                if (!string.IsNullOrEmpty(video.frameRate))
                    info.AppendLine("帧率：" + video.frameRate);
                if (!string.IsNullOrEmpty(video.colorSpace))
                    info.AppendLine("色彩空间：" + video.colorSpace);
                if (!string.IsNullOrEmpty(video.chromaSubsampling))
                    info.AppendLine("色度抽样：" + video.chromaSubsampling);
                if (!string.IsNullOrEmpty(video.bitDepth))
                    info.AppendLine("位深度：" + video.bitDepth);
                if (!string.IsNullOrEmpty(video.scanType))
                    info.AppendLine("扫描方式：" + video.scanType);
                if (!string.IsNullOrEmpty(video.encodedTime))
                    info.AppendLine("编码时间：" + video.encodedTime);
                if (!string.IsNullOrEmpty(video.frameCount))
                    info.AppendLine("总帧数：" + video.frameCount);
                if (!string.IsNullOrEmpty(video.encodedLibrary))
                    info.AppendLine("编码库：" + video.encodedLibrary);
                if (!string.IsNullOrEmpty(video.encodingSettings))
                    info.AppendLine("编码设置：" + video.encodingSettings);
            }

            if (audio != null)
            {
                if (!string.IsNullOrEmpty(audio.format))
                    info.AppendLine("\r\n" + "音频(" + audio.id + ")：" + audio.format);
                if (!string.IsNullOrEmpty(audio.size))
                    info.AppendLine("大小：" + audio.size);
                if (!string.IsNullOrEmpty(audio.bitRate))
                    info.AppendLine("码率：" + audio.bitRate);
                if (!string.IsNullOrEmpty(audio.samplingRate))
                    info.AppendLine("采样率：" + audio.samplingRate);
                if (!string.IsNullOrEmpty(audio.channel))
                    info.AppendLine("声道数：" + audio.channel);
            }
            //info.AppendLine("\r\n====详细信息====\r\n" + videoInfo + audioInfo);
            return info.ToString();
        }
    }
}
