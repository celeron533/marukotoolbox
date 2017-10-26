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

        string batpath = "";

        public OnePicProcedure() : base()
        {
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
            ImageCodecInfo ImageCoderType = OtherUtil.GetImageCoderInfo("image/jpeg");
            img.Save(Global.Running.tempImgFile, ImageCoderType, eps);
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

            string neroPath = FileStringUtil.FormatPath(ToolsUtil.NEROAACENC.fullPath);
            StringBuilder muxCommand = new StringBuilder();
            if (copyAudio)
            {
                muxCommand.AppendLine("\"" + ToolsUtil.FFMPEG.fullPath + "\" -loop 1 -r " + fps + " -t " + duration.ToString() + " -f image2 -i \"" + Global.Running.tempImgFile + "\" -c:v libx264 -crf " + crf.ToString("0.0") + " -y SinglePictureVideo.mp4")
                          .AppendLine("\"" + ToolsUtil.FFMPEG.fullPath + "\" -i SinglePictureVideo.mp4 -i \"" + audioFilePath + "\" -c:v copy -c:a copy -y \"" + outputFilePath + "\"")
                          .AppendLine("del SinglePictureVideo.mp4")
                          .AppendLine("cmd");
            }
            else
            {
                muxCommand.AppendLine("\"" + ToolsUtil.FFMPEG.fullPath + "\" -i \"" + audioFilePath + "\" -f wav - |" + neroPath + " -br " + audioBitrate * 1000 + " -ignorelength -if - -of audio.mp4 -lc")
                          .AppendLine("\"" + ToolsUtil.FFMPEG.fullPath + "\" -loop 1 -r " + fps + " -t " + duration.ToString() + " -f image2 -i \"" + Global.Running.tempImgFile + "\" -c:v libx264 -crf " + crf.ToString("0.0") + " -y SinglePictureVideo.mp4")
                          .AppendLine("\"" + ToolsUtil.FFMPEG.fullPath + "\" -i SinglePictureVideo.mp4 -i audio.mp4 -c:v copy -c:a copy -y \"" + outputFilePath + "\"")
                          .AppendLine("del SinglePictureVideo.mp4")
                          .AppendLine("del audio.mp4")
                          .AppendLine("cmd");
            }

            batpath = Path.Combine(ToolsUtil.ToolsFolder, Path.GetRandomFileName() + ".bat");
            File.WriteAllText(batpath, muxCommand.ToString(), Encoding.Default);
            logger.Info(muxCommand.ToString());
            Process.Start(batpath);
        }
    }
}
