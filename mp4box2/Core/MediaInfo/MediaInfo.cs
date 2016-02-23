using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Wapper = mp4box2.Utility.MediaInfoWapper;

namespace mp4box2.Core.MediaInfo
{
    public class MediaInfo
    {
        public MediaInfo()
        { }

        public string fileName;
        public General general;
        public Video video;
        public Audio audio;

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
            general.bitRateStr = MI.Get(Wapper.StreamKind.General, 0, "BitRate/String");
            general.durationStr = MI.Get(Wapper.StreamKind.General, 0, "Duration/String1");
            general.fileSizeStr = MI.Get(Wapper.StreamKind.General, 0, "FileSize/String");

            //Video
            video = new Video();
            video.id = MI.Get(Wapper.StreamKind.Video, 0, "ID");
            video.format = MI.Get(Wapper.StreamKind.Video, 0, "Format");
            video.bitRateStr = MI.Get(Wapper.StreamKind.Video, 0, "BitRate/String");
            video.sizeStr = MI.Get(Wapper.StreamKind.Video, 0, "StreamSize/String");
            video.width = MI.Get(Wapper.StreamKind.Video, 0, "Width");
            video.height = MI.Get(Wapper.StreamKind.Video, 0, "Height");
            video.displayAspectRatio = MI.Get(Wapper.StreamKind.Video, 0, "DisplayAspectRatio");
            video.displayAspectRatioStr = MI.Get(Wapper.StreamKind.Video, 0, "DisplayAspectRatio/String");
            video.frameRate = MI.Get(Wapper.StreamKind.Video, 0, "FrameRate");
            video.frameRateStr = MI.Get(Wapper.StreamKind.Video, 0, "FrameRate/String");
            video.colorSpace = MI.Get(Wapper.StreamKind.Video, 0, "ColorSpace");
            video.chromaSubsampling = MI.Get(Wapper.StreamKind.Video, 0, "ChromaSubsampling");
            video.bitDepthStr = MI.Get(Wapper.StreamKind.Video, 0, "BitDepth/String");
            video.scanTypeStr = MI.Get(Wapper.StreamKind.Video, 0, "ScanType/String");
            video.pixelAspectRatio = MI.Get(Wapper.StreamKind.Video, 0, "PixelAspectRatio");
            video.encodedLibraryStr = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Library/String");
            video.encodingSettings = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Library_Settings");
            video.encodedTime = MI.Get(Wapper.StreamKind.Video, 0, "Encoded_Date");
            video.codecProfile = MI.Get(Wapper.StreamKind.Video, 0, "Codec_Profile");
            video.frameCount = MI.Get(Wapper.StreamKind.Video, 0, "FrameCount");

            //Audio
            audio = new Audio();
            audio.id = MI.Get(Wapper.StreamKind.Audio, 0, "ID");
            audio.format = MI.Get(Wapper.StreamKind.Audio, 0, "Format");
            audio.formatProfile = MI.Get(Wapper.StreamKind.Audio, 0, "Format_Profile");
            audio.durationStr = MI.Get(Wapper.StreamKind.General, 0, "Duration/String3");
            audio.bitRateStr = MI.Get(Wapper.StreamKind.Audio, 0, "BitRate/String");
            audio.samplingRateStr = MI.Get(Wapper.StreamKind.Audio, 0, "SamplingRate/String");
            audio.channel = MI.Get(Wapper.StreamKind.Audio, 0, "Channel(s)");
            audio.sizeStr = MI.Get(Wapper.StreamKind.Audio, 0, "StreamSize/String");

            //string audioInfo = MI.Get(Wapper.StreamKind.Audio, 0, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 1, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 2, "Inform")
            //    + MI.Get(Wapper.StreamKind.Audio, 3, "Inform");
            //string videoInfo = MI.Get(Wapper.StreamKind.Video, 0, "Inform");

            MI.Close();
        }


        public string GetSummaryString()
        {
            StringBuilder info = new StringBuilder();
            info = info.AppendLine(Path.GetFileName(fileName));
            if (general != null)
            {
                if (!string.IsNullOrEmpty(general.container))
                    info.AppendLine("容器：" + general.container);
                if (!string.IsNullOrEmpty(general.bitRateStr))
                    info.AppendLine("总码率：" + general.bitRateStr);
                if (!string.IsNullOrEmpty(general.fileSizeStr))
                    info.AppendLine("大小：" + general.fileSizeStr);
                if (!string.IsNullOrEmpty(general.durationStr))
                    info.AppendLine("时长：" + general.durationStr);
            }

            if (video != null)
            {
                if (!string.IsNullOrEmpty(video.format))
                    info.AppendLine("\r\n" + "视频(" + video.id + ")：" + video.format);
                if (!string.IsNullOrEmpty(video.codecProfile))
                    info.AppendLine("Profile：" + video.codecProfile);
                if (!string.IsNullOrEmpty(video.bitRateStr))
                    info.AppendLine("码率：" + video.bitRateStr);
                if (!string.IsNullOrEmpty(video.sizeStr))
                    info.AppendLine("文件大小：" + video.sizeStr);
                if (!string.IsNullOrEmpty(video.width) && !string.IsNullOrEmpty(video.height))
                    info.AppendLine("分辨率：" + video.width + "x" + video.height);
                if (!string.IsNullOrEmpty(video.displayAspectRatioStr) && !string.IsNullOrEmpty(video.displayAspectRatio))
                    info.AppendLine("画面比例：" + video.displayAspectRatioStr + "(" + video.displayAspectRatio + ")");
                if (!string.IsNullOrEmpty(video.pixelAspectRatio))
                    info.AppendLine("像素宽高比：" + video.pixelAspectRatio);
                if (!string.IsNullOrEmpty(video.frameRate))
                    info.AppendLine("帧率：" + video.frameRate);
                if (!string.IsNullOrEmpty(video.colorSpace))
                    info.AppendLine("色彩空间：" + video.colorSpace);
                if (!string.IsNullOrEmpty(video.chromaSubsampling))
                    info.AppendLine("色度抽样：" + video.chromaSubsampling);
                if (!string.IsNullOrEmpty(video.bitDepthStr))
                    info.AppendLine("位深度：" + video.bitDepthStr);
                if (!string.IsNullOrEmpty(video.scanTypeStr))
                    info.AppendLine("扫描方式：" + video.scanTypeStr);
                if (!string.IsNullOrEmpty(video.encodedTime))
                    info.AppendLine("编码时间：" + video.encodedTime);
                if (!string.IsNullOrEmpty(video.frameCount))
                    info.AppendLine("总帧数：" + video.frameCount);
                if (!string.IsNullOrEmpty(video.encodedLibraryStr))
                    info.AppendLine("编码库：" + video.encodedLibraryStr);
                if (!string.IsNullOrEmpty(video.encodingSettings))
                    info.AppendLine("编码设置：" + video.encodingSettings);
            }

            if (audio != null)
            {
                if (!string.IsNullOrEmpty(audio.format))
                    info.AppendLine("\r\n" + "音频(" + audio.id + ")：" + audio.format);
                if (!string.IsNullOrEmpty(audio.sizeStr))
                    info.AppendLine("大小：" + audio.sizeStr);
                if (!string.IsNullOrEmpty(audio.bitRateStr))
                    info.AppendLine("码率：" + audio.bitRateStr);
                if (!string.IsNullOrEmpty(audio.samplingRateStr))
                    info.AppendLine("采样率：" + audio.samplingRateStr);
                if (!string.IsNullOrEmpty(audio.channel))
                    info.AppendLine("声道数：" + audio.channel);
            }
            //info.AppendLine("\r\n====详细信息====\r\n" + videoInfo + audioInfo);
            return info.ToString();
        }
    }
}
