using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaInfoLib
{
    public class MediaInfoWrapper
    {
        #region Variables

        public string fileName { get; private set; }
        //全局
        public string container { get; private set; }
        public string bitRate { get; private set; }
        public string bitRate1 { get; private set; }
        public string duration { get; private set; }
        public string duration3 { get; private set; }
        public string fileSize { get; private set; }
        //视频
        public string v_id { get; private set; }
        public string v_format { get; private set; }
        public string v_bitRate { get; private set; }
        public string v_size { get; private set; }
        public string v_width { get; private set; }
        public string v_height { get; private set; }
        public string v_displayAspectRatio { get; private set; }
        public string v_displayAspectRatio2 { get; private set; }
        public string v_frameRate { get; private set; }
        public string v_frameRate2 { get; private set; }
        public string v_colorSpace { get; private set; }
        public string v_chromaSubsampling { get; private set; }
        public string v_bitDepth { get; private set; }
        public string v_scanType { get; private set; }
        public string v_pixelAspectRatio { get; private set; }
        public string v_encodedLibrary { get; private set; }
        public string v_encodingSettings { get; private set; }
        public string v_encodedTime { get; private set; }
        public string v_codecProfile { get; private set; }
        public string v_frameCount { get; private set; }
        //音频
        public string a_id { get; private set; }
        public string a_format { get; private set; }
        public string a_formatProfile { get; private set; }
        public string a_bitRate { get; private set; }
        public string a_samplingRate { get; private set; }
        public string a_channel { get; private set; }
        public string a_size { get; private set; }

        public string audioInfo0 { get; private set; }
        public string audioInfo1 { get; private set; }
        public string audioInfo2 { get; private set; }
        public string audioInfo3 { get; private set; }

        public string videoInfo { get; private set; }

        #endregion

        public MediaInfoWrapper(string fileName)
        {
            this.fileName = fileName;
            if (File.Exists(fileName))
            {
                MediaInfo MI = new MediaInfo();
                MI.Open(fileName);

                //全局
                container = MI.Get(StreamKind.General, 0, "Format");
                bitRate = MI.Get(StreamKind.General, 0, "BitRate/String");
                bitRate1 = MI.Get(StreamKind.General, 0, "BitRate");
                duration = MI.Get(StreamKind.General, 0, "Duration/String1");
                duration3 = MI.Get(StreamKind.General, 0, "Duration/String3");
                fileSize = MI.Get(StreamKind.General, 0, "FileSize/String");
                //视频
                v_id = MI.Get(StreamKind.Video, 0, "ID");
                v_format = MI.Get(StreamKind.Video, 0, "Format");
                v_bitRate = MI.Get(StreamKind.Video, 0, "BitRate/String");
                v_size = MI.Get(StreamKind.Video, 0, "StreamSize/String");
                v_width = MI.Get(StreamKind.Video, 0, "Width");
                v_height = MI.Get(StreamKind.Video, 0, "Height");
                v_displayAspectRatio = MI.Get(StreamKind.Video, 0, "DisplayAspectRatio/String");
                v_displayAspectRatio2 = MI.Get(StreamKind.Video, 0, "DisplayAspectRatio");
                v_frameRate = MI.Get(StreamKind.Video, 0, "FrameRate/String");
                v_frameRate2 = MI.Get(StreamKind.Video, 0, "FrameRate");
                v_colorSpace = MI.Get(StreamKind.Video, 0, "ColorSpace");
                v_chromaSubsampling = MI.Get(StreamKind.Video, 0, "ChromaSubsampling");
                v_bitDepth = MI.Get(StreamKind.Video, 0, "BitDepth/String");
                v_scanType = MI.Get(StreamKind.Video, 0, "ScanType/String");
                v_pixelAspectRatio = MI.Get(StreamKind.Video, 0, "PixelAspectRatio");
                v_encodedLibrary = MI.Get(StreamKind.Video, 0, "Encoded_Library/String");
                v_encodingSettings = MI.Get(StreamKind.Video, 0, "Encoded_Library_Settings");
                v_encodedTime = MI.Get(StreamKind.Video, 0, "Encoded_Date");
                v_codecProfile = MI.Get(StreamKind.Video, 0, "Codec_Profile");
                v_frameCount = MI.Get(StreamKind.Video, 0, "FrameCount");
                //音频
                a_id = MI.Get(StreamKind.Audio, 0, "ID");
                a_format = MI.Get(StreamKind.Audio, 0, "Format");
                a_formatProfile = MI.Get(StreamKind.Audio, 0, "Format_Profile");

                a_bitRate = MI.Get(StreamKind.Audio, 0, "BitRate/String");
                a_samplingRate = MI.Get(StreamKind.Audio, 0, "SamplingRate/String");
                a_channel = MI.Get(StreamKind.Audio, 0, "Channel(s)");
                a_size = MI.Get(StreamKind.Audio, 0, "StreamSize/String");

                audioInfo0 = MI.Get(StreamKind.Audio, 0, "Inform");
                audioInfo1 = MI.Get(StreamKind.Audio, 1, "Inform");
                audioInfo2 = MI.Get(StreamKind.Audio, 2, "Inform");
                audioInfo3 = MI.Get(StreamKind.Audio, 3, "Inform");

                videoInfo = MI.Get(StreamKind.Video, 0, "Inform");

                MI.Close();
            }
            else
            {
                // "文件不存在、非有效文件或者文件夹 无视频信息"
                throw new FileNotFoundException("Could not find the file.", fileName);
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(Path.GetFileName(fileName));

            if (!string.IsNullOrEmpty(container))
                info.AppendLine("容器：" + container);
            if (!string.IsNullOrEmpty(bitRate))
                info.AppendLine("总码率：" + bitRate);
            //if (!string.IsNullOrEmpty(bitRate1))
            //    info.AppendLine("总码率1：" + bitRate1);
            if (!string.IsNullOrEmpty(fileSize))
                info.AppendLine("大小：" + fileSize);
            if (!string.IsNullOrEmpty(duration))
                info.AppendLine("时长：" + duration);
            //if (!string.IsNullOrEmpty(duration3))
            //    info.AppendLine("时长3：" + duration3);

            info.AppendLine();
            if (!string.IsNullOrEmpty(v_format))
                info.AppendLine("视频(" + v_id + ")：" + v_format);
            if (!string.IsNullOrEmpty(v_codecProfile))
                info.AppendLine("Profile：" + v_codecProfile);
            if (!string.IsNullOrEmpty(v_bitRate))
                info.AppendLine("码率：" + v_bitRate);
            if (!string.IsNullOrEmpty(v_size))
                info.AppendLine("文件大小：" + v_size);
            if (!string.IsNullOrEmpty(v_width) && !string.IsNullOrEmpty(v_height))
                info.AppendLine("分辨率：" + v_width + "x" + v_height);
            if (!string.IsNullOrEmpty(v_displayAspectRatio) && !string.IsNullOrEmpty(v_displayAspectRatio2))
                info.AppendLine("画面比例：" + v_displayAspectRatio + "(" + v_displayAspectRatio2 + ")");
            if (!string.IsNullOrEmpty(v_pixelAspectRatio))
                info.AppendLine("像素宽高比：" + v_pixelAspectRatio);
            if (!string.IsNullOrEmpty(v_frameRate))
                info.AppendLine("帧率：" + v_frameRate);
            //if (!string.IsNullOrEmpty(v_frameRate2))
            //    info.AppendLine("帧率2：" + v_frameRate2);
            if (!string.IsNullOrEmpty(v_colorSpace))
                info.AppendLine("色彩空间：" + v_colorSpace);
            if (!string.IsNullOrEmpty(v_chromaSubsampling))
                info.AppendLine("色度抽样：" + v_chromaSubsampling);
            if (!string.IsNullOrEmpty(v_bitDepth))
                info.AppendLine("位深度：" + v_bitDepth);
            if (!string.IsNullOrEmpty(v_scanType))
            {
                if (v_scanType.ToLower() == "progressive")
                    info.AppendLine("扫描方式：逐行扫描");
                else if (v_scanType.ToLower() == "interlaced")
                    info.AppendLine("扫描方式：隔行扫描");
                else
                    info.AppendLine("扫描方式：" + v_scanType);
            }
            if (!string.IsNullOrEmpty(v_encodedTime))
                info.AppendLine("编码时间：" + v_encodedTime);
            if (!string.IsNullOrEmpty(v_frameCount))
                info.AppendLine("总帧数：" + v_frameCount);
            if (!string.IsNullOrEmpty(v_encodedLibrary))
                info.AppendLine("编码库：" + v_encodedLibrary);
            if (!string.IsNullOrEmpty(v_encodingSettings))
                info.AppendLine("编码设置：" + v_encodingSettings);

            info.AppendLine();
            if (!string.IsNullOrEmpty(a_format))
                info.AppendLine("音频(" + a_id + ")：" + a_format);
            //if (!string.IsNullOrEmpty(a_formatProfile))
            //    info.AppendLine("Profile：" + a_formatProfile);
            if (!string.IsNullOrEmpty(a_size))
                info.AppendLine("大小：" + a_size);
            if (!string.IsNullOrEmpty(a_bitRate))
                info.AppendLine("码率：" + a_bitRate);
            if (!string.IsNullOrEmpty(a_samplingRate))
                info.AppendLine("采样率：" + a_samplingRate);
            if (!string.IsNullOrEmpty(a_channel))
                info.AppendLine("声道数：" + a_channel);
            info.AppendLine();
            info.AppendLine("====详细信息====");
            info.AppendLine(videoInfo);
            info.AppendLine(audioInfo0 + audioInfo1 + audioInfo2 + audioInfo3);

            return info.ToString();
        }

    }
}
