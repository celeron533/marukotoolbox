using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Utility
{
    public static class Dialog
    {
        /// <summary>
        /// Consolidate the Filter settings for OpenFileDialog & SaveFileDialog
        /// </summary>
        /// <param name="type">DialogFilterTypes</param>
        /// <returns>string</returns>
        public static string GetDialogFilter(DialogFilterTypes type)
        {
            string filterString;
            //TODO: multi language support in the future
            string all = "所有文件";
            string avs = "AVS";
            string video = "视频";
            string audio = "音频";
            string image = "图片";
            string subtitle = "字幕";
            string program = "程序";
            string stream = "流";

            switch (type)
            {
                //all
                case DialogFilterTypes.ALL:
                    filterString = String.Format("{0}(*.*)|*.*;", all); break;

                //video
                case DialogFilterTypes.VIDEO_1:
                    filterString = String.Format("{0}(*.*)|*.*;", video); break;
                case DialogFilterTypes.VIDEO_2:
                    filterString = String.Format("{0}(*.mkv)|*.mkv;", video); break;
                case DialogFilterTypes.VIDEO_3:
                    filterString = String.Format("{0}(*.mp4)|*.mp4;", video); break;
                case DialogFilterTypes.VIDEO_4:
                    filterString = String.Format("{0}(*.flv;*.hlv)|*.flv;*.hlv;", video); break;
                case DialogFilterTypes.VIDEO_5:
                    filterString = String.Format("{0}(*.mp4)|*.mp4|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_6:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_7:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_8:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs)|*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_9:
                    filterString = String.Format("{0}(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|{1}(*.*)|*.*;", video, all); break;

                //video with detailed description
                case DialogFilterTypes.VIDEO_D_1:
                    filterString = String.Format("FLV {0}(*.flv)|*.flv;", video); break;
                case DialogFilterTypes.VIDEO_D_2:
                    filterString = String.Format("MP4 {0}(*.mp4)|*.mp4|FLV {0}(*.flv)|*.flv;", video); break;
                case DialogFilterTypes.VIDEO_D_3:
                    filterString = String.Format("MPEG-4 {0}(*.mp4)|*.mp4|Flash {0}(*.flv)|*.flv|Matroska {0}(*.mkv)|*.mkv|AVI {0}(*.avi)|*.avi|H.264 {1}(*.raw)|*.raw;", video, stream); break;

                //audio
                case DialogFilterTypes.AUDIO_1:
                    filterString = String.Format("{0}(*.mp3)|*.mp3|{0}(*.aac)|*.aac|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_2:
                    filterString = String.Format("{0}(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_3:
                    filterString = String.Format("{0}(*.aac;*.wav;*.m4a;*.flac)|*.aac;*.wav;*.m4a;*.flac;", audio); break;
                case DialogFilterTypes.AUDIO_4:
                    filterString = String.Format("{0}(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_5:
                    filterString = String.Format("{0}(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|{1}(*.*)|*.*;", audio, all); break;

                //others
                case DialogFilterTypes.AVS:
                    filterString = String.Format("{0}(*.avs)|*.avs;", avs); break;
                case DialogFilterTypes.PROGRAM:
                    filterString = String.Format("{0}(*.exe)|*.exe|{1}(*.*)|*.*;", program, all); break;
                case DialogFilterTypes.SUBTITLE_1:
                    filterString = String.Format("{0}(*.ass;*.ssa;*.srt)|*.ass;*.ssa;*.srt|{1}(*.*)|*.*;", subtitle, all); break;
                case DialogFilterTypes.SUBTITLE_2:
                    filterString = String.Format("{0}(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|{1}(*.*)|*.*;", subtitle, all); break;
                case DialogFilterTypes.IMAGE:
                    filterString = String.Format("{0}(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|{1}(*.*)|*.*;", image, all); break;

                default:
                    filterString = String.Format("{0}(*.*)|*.*;", all); break;
            }
            return filterString;
        }

        public enum DialogFilterTypes
        {
            ALL,
            VIDEO_1, VIDEO_2, VIDEO_3, VIDEO_4, VIDEO_5, VIDEO_6, VIDEO_7, VIDEO_8, VIDEO_9,
            VIDEO_D_1, VIDEO_D_2, VIDEO_D_3,
            AUDIO_1, AUDIO_2, AUDIO_3, AUDIO_4, AUDIO_5,
            AVS,
            PROGRAM,
            SUBTITLE_1, SUBTITLE_2,
            IMAGE,
        }
    }
}
