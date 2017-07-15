using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Utility
{
    public static class ToolsUtil
    {
        // Best way to get the application foldre path (as known as workPath)
        // https://stackoverflow.com/questions/6041332/best-way-to-get-application-folder-path
        public static string ToolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"tools");

        public static List<ToolInfo> ToolList = new List<ToolInfo>(
            new ToolInfo[]
            {
                AVS4X26X,
                FDKAAC,
                FFMPEG,
                FLAC,
                FLVEXTRACTCL,
                GMKVEXTRACTGUI,
                LAME,
                MKVMERGE,
                MP4BOX,
                NEROAACENC,
                QAAC,
                REFALAC,
                X264_32_10,
                X264_32_8,
                X264_64_10,
                X264_64_8,
                X265_32,
                X265_64
            }
        );

        #region ToolInfo instances

        public static ToolInfo AVS4X26X = new ToolInfo("avs4x26x.exe")
        {
            description = "avs4x26x"
        };

        public static ToolInfo FDKAAC = new ToolInfo("fdkaac.exe")
        {
            description = "fdkaac"
        };

        public static ToolInfo FFMPEG = new ToolInfo("ffmpeg.exe")
        {
            description = "ffmpeg"
        };

        public static ToolInfo FLAC = new ToolInfo("flac.exe")
        {
            description = "flac"
        };

        public static ToolInfo FLVEXTRACTCL = new ToolInfo("FLVExtractCL.exe")
        {
            description = "FLVExtractCL"
        };

        public static ToolInfo GMKVEXTRACTGUI = new ToolInfo("gMKVExtractGUI.exe")
        {
            description = "gMKVExtractGUI"
        };

        public static ToolInfo LAME = new ToolInfo("lame.exe")
        {
            description = "lame"
        };

        public static ToolInfo MKVMERGE = new ToolInfo("mkvmerge.exe")
        {
            description = "mkvmerge"
        };

        public static ToolInfo MP4BOX = new ToolInfo("MP4Box.exe")
        {
            description = "MP4Box"
        };

        public static ToolInfo NEROAACENC = new ToolInfo("neroAacEnc.exe")
        {
            description = "neroAacEnc"
        };

        public static ToolInfo QAAC = new ToolInfo("qaac.exe")
        {
            description = "qaac"
        };

        public static ToolInfo REFALAC = new ToolInfo("refalac.exe")
        {
            description = "refalac"
        };

        public static ToolInfo X264_32_10 = new ToolInfo("x264_32-10bit.exe")
        {
            description = "x264_32-10bit"
        };

        public static ToolInfo X264_32_8 = new ToolInfo("x264_32-8bit.exe")
        {
            description = "x264_32-8bit"
        };

        public static ToolInfo X264_64_10 = new ToolInfo("x264_64-10bit.exe")
        {
            description = "x264_64-10bit"
        };

        public static ToolInfo X264_64_8 = new ToolInfo("x264_64-8bit.exe")
        {
            description = "x264_64-8bit"
        };

        public static ToolInfo X265_32 = new ToolInfo("x265_32.exe")
        {
            description = "x265_32"
        };

        public static ToolInfo X265_64 = new ToolInfo("x265_64.exe")
        {
            description = "x265_64"
        };

        #endregion ToolInfo instances


        public class ToolInfo
        {
            public ToolInfo(string fileName)
            {
                this.fileName = fileName;
            }

            public string fileName { get; private set; }
            public string description { get; set; }
            public string fullPath { get { return Path.Combine(ToolsDir, fileName); } }
            public bool exists { get { return File.Exists(fullPath); } }
        }

    }


}
