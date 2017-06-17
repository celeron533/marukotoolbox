using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Utility
{
    public static class DialogUtil
    {
        /// <summary>
        /// Consolidate the Filter settings for OpenFileDialog and SaveFileDialog
        /// </summary>
        public static class DialogFilter
        {
            //TODO: multi language support in the future
            private static string all = "所有文件";
            private static string avs = "AVS";
            private static string video = "视频";
            private static string audio = "音频";
            private static string image = "图片";
            private static string subtitle = "字幕";
            private static string program = "程序";
            private static string stream = "流";

            //all
            public static string ALL
                = String.Format("{0}(*.*)|*.*;", all);

            //video
            public static string VIDEO_1
                = String.Format("{0}(*.*)|*.*;", video);
            public static string VIDEO_2
                = String.Format("{0}(*.mkv)|*.mkv;", video);
            public static string VIDEO_3
                = String.Format("{0}(*.mp4)|*.mp4;", video);
            public static string VIDEO_4
                = String.Format("{0}(*.flv;*.hlv)|*.flv;*.hlv;", video);
            public static string VIDEO_5
                = String.Format("{0}(*.mp4)|*.mp4|{1}(*.*)|*.*;", video, all);
            public static string VIDEO_6
                = String.Format("{0}(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|{1}(*.*)|*.*;", video, all);
            public static string VIDEO_7
                = String.Format("{0}(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|{1}(*.*)|*.*;", video, all);
            public static string VIDEO_8
                = String.Format("{0}(*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs)|*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs|{1}(*.*)|*.*;", video, all);
            public static string VIDEO_9
                = String.Format("{0}(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|{1}(*.*)|*.*;", video, all);

            //video with detailed description
            public static string VIDEO_D_1
                = String.Format("FLV {0}(*.flv)|*.flv;", video);
            public static string VIDEO_D_2
                = String.Format("MP4 {0}(*.mp4)|*.mp4|FLV {0}(*.flv)|*.flv;", video);
            public static string VIDEO_D_3
                = String.Format("MPEG-4 {0}(*.mp4)|*.mp4|Flash {0}(*.flv)|*.flv|Matroska {0}(*.mkv)|*.mkv|AVI {0}(*.avi)|*.avi|H.264 {1}(*.raw)|*.raw;", video, stream);

            //audio
            public static string AUDIO_1
                = String.Format("{0}(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|{1}(*.*)|*.*;", audio, all);
            public static string AUDIO_2
                = String.Format("{0}(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|{1}(*.*)|*.*;", audio, all);
            public static string AUDIO_3
                = String.Format("{0}(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|{1}(*.*)|*.*;", audio, all);

            //others
            public static string AVS
                = String.Format("{0}(*.avs)|*.avs;", avs);
            public static string PROGRAM
                = String.Format("{0}(*.exe)|*.exe|{1}(*.*)|*.*;", program, all);
            public static string SUBTITLE_1
                = String.Format("{0}(*.ass;*.ssa;*.srt)|*.ass;*.ssa;*.srt|{1}(*.*)|*.*;", subtitle, all);
            public static string SUBTITLE_2
                = String.Format("{0}(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|{1}(*.*)|*.*;", subtitle, all);
            public static string IMAGE
                = String.Format("{0}(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|{1}(*.*)|*.*;", image, all);

        }
    }
}
