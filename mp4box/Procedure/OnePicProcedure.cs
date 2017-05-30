using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public class OnePicProcedure : ProcedureBase<OnePicProcedure>
    {
        public string imageFilePath { get; set; }
        public string audioFilePath { get; set; }
        public string outputFilePath { get; set; }
        public int audioBitrate { get; set; }
        public int fps { get; set; }
        public float crf { get; set; }
        public int duration { get; set; }
        public bool copyAudio { get; set; }

        string tempPic, workPath, batpath = "";
        [Obsolete("It should be no parameter. Currently is just used for refactor compatibility")]
        public OnePicProcedure(string tempPic, string workPath) : base()
        {
            this.tempPic = tempPic;
            this.workPath = workPath;
        }


        public override void GetDataFromUI(Action<OnePicProcedure> p)
        {
            p.Invoke(this);
        }


        public override void SetDataToUI(Action<OnePicProcedure> p)
        {
            p.Invoke(this);
        }


        public override void Execute()
        {
            Image img = Image.FromFile(imageFilePath);
            // if not even number, chop 1 pixel out
            if (img.Width % 2 != 0 || img.Height % 2 != 0)
            {
                int newWidth = (img.Width % 2 == 0 ? img.Width : img.Width - 1);
                int newHeight = (img.Height % 2 == 0 ? img.Height : img.Height - 1);
                Bitmap bmp = new Bitmap(img);
                Rectangle cropArea = new Rectangle(0, 0, newWidth, newHeight);
                img = bmp.Clone(cropArea, bmp.PixelFormat);
            }

            EncoderParameters eps = new EncoderParameters();
            eps.Param = new EncoderParameter[]
                        {
                            // set best quality
                            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L)
                        };
            ImageCodecInfo ImageCoderType = GetImageCoderInfo("image/jpeg");
            img.Save(tempPic, ImageCoderType, eps);
            //img.Save(tempPic, ImageFormat.Jpeg);

            // TODO: move this logic after select the Audio file.

            //获得音频时长
            //string audioDurationStr = new MediaInfoWrapper(audioFilePath).duration3;
            //if (!string.IsNullOrEmpty(audioDurationStr))
            //    duration = SecondsFromHHMMSS(audioDurationStr);

            //if (duration <= 0)
            //{
            //    ShowErrorMessage("未能获取正确时间，请手动输入秒数。");
            //    return;
            //}

            string ffPath = Path.Combine(workPath, "ffmpeg.exe");
            string neroPath = Util.FormatPath(Path.Combine(workPath, "neroaacenc.exe"));
            StringBuilder muxCommand = new StringBuilder();
            if (copyAudio)
            {
                muxCommand.AppendLine("\"" + ffPath + "\" -loop 1 -r " + fps + " -t " + duration.ToString() + " -f image2 -i \"" + tempPic + "\" -c:v libx264 -crf " + crf.ToString("0.0") + " -y SinglePictureVideo.mp4")
                          .AppendLine("\"" + ffPath + "\" -i SinglePictureVideo.mp4 -i \"" + audioFilePath + "\" -c:v copy -c:a copy -y \"" + outputFilePath + "\"")
                          .AppendLine("del SinglePictureVideo.mp4")
                          .AppendLine("cmd");
            }
            else
            {
                muxCommand.AppendLine("\"" + ffPath + "\" -i \"" + audioFilePath + "\" -f wav - |" + neroPath + " -br " + audioBitrate * 1000 + " -ignorelength -if - -of audio.mp4 -lc")
                          .AppendLine("\"" + ffPath + "\" -loop 1 -r " + fps + " -t " + duration.ToString() + " -f image2 -i \"" + tempPic + "\" -c:v libx264 -crf " + crf.ToString("0.0") + " -y SinglePictureVideo.mp4")
                          .AppendLine("\"" + ffPath + "\" -i SinglePictureVideo.mp4 -i audio.mp4 -c:v copy -c:a copy -y \"" + outputFilePath + "\"")
                          .AppendLine("del SinglePictureVideo.mp4")
                          .AppendLine("del audio.mp4")
                          .AppendLine("cmd");
            }

            batpath = Path.Combine(workPath, Path.GetRandomFileName() + ".bat");
            File.WriteAllText(batpath, muxCommand.ToString(), Encoding.Default);
            // TODO: log function
            //LogRecord(muxCommand.ToString());
            Process.Start(batpath);
        }


        /// <summary>
        /// 获取图片编码类型信息
        /// </summary>
        /// <param name="imageCoderType">编码类型</param>
        /// <returns>ImageCodecInfo</returns>
        private ImageCodecInfo GetImageCoderInfo(string imageCoderType)
        {
            return ImageCodecInfo.GetImageEncoders()?.FirstOrDefault(e => e.MimeType.Equals(imageCoderType));
        }


        /// <summary>
        /// Convert HHMMSS to seconds
        /// </summary>
        /// <param name="hhmmss">"99:59:59"</param>
        /// <returns>Converted seconds </returns>
        private int SecondsFromHHMMSS(string hhmmss)
        {
            int hh = int.Parse(hhmmss.Substring(0, 2));
            int mm = int.Parse(hhmmss.Substring(3, 2));
            int ss = int.Parse(hhmmss.Substring(6, 2));
            return hh * 3600 + mm * 60 + ss;
        }
    }
}
