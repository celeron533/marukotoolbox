using MediaInfoLib;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp4box.Procedure
{
    public class BlackProcedure : ProcedureBase<BlackProcedure>
    {
        public string inputVideoFile { get; set; }
        public string outputVideoFile { get; set; }
        public string inputImageFile { get; set; }
        public string durationStr { get; set; }
        public int fps { get; set; }
        public float crf { get; set; }
        public int targetBitrate { get; set; }
        public bool doNotUseImg { get; set; }

        string tempPic, batpath = "";

        public BlackProcedure(string tempPic) : base()
        {
            this.tempPic = tempPic;
        }

        public override void GetDataFromUI(Action<BlackProcedure> p)
        {
            p.Invoke(this);
        }

        public override void SetDataToUI(Action<BlackProcedure> p)
        {
            p.Invoke(this);
        }

        public override void Execute()
        {
            MediaInfoWrapper MIW = new MediaInfoWrapper(inputVideoFile);
            float videoBitrate = float.Parse(MIW.bitRate1);

            if (videoBitrate < 1000 * 1000)
            {
                MessageBoxExt.ShowInfoMessage("此视频不需要后黑。");
                return;
            }
            else if (videoBitrate > 5000 * 1000)
            {
                MessageBoxExt.ShowInfoMessage("此视频码率过大，请先压制再后黑。");
                return;
            }

            //计算后黑时长
            int blackDuration;
            if (durationStr == "auto")
            {
                int duration = OtherUtil.SecondsFromHHMMSS(MIW.duration3);
                var s = videoBitrate / 1000.0 * (float)duration / targetBitrate - (float)duration;
                blackDuration = (int)s;
            }
            else
            {
                int.TryParse(durationStr, out blackDuration);
                if (blackDuration <= 0)
                    blackDuration = 300;
            }
            // Note: variable durationStr should be sent back to UI
            durationStr = blackDuration.ToString();

            //处理图片
            int videoWidth = int.Parse(MIW.v_width);
            int videoHeight = int.Parse(MIW.v_height);
            if (doNotUseImg)
            {
                Bitmap bmp = new Bitmap(videoWidth, videoHeight);
                Graphics g = Graphics.FromImage(bmp);
                //g.FillRectangle(Brushes.White, new Rectangle(0, 0, 800, 600));
                g.Clear(Color.Black);
                bmp.Save(tempPic, ImageFormat.Jpeg);
            }
            else
            {
                Image img = Image.FromFile(inputImageFile);
                Bitmap resized = new Bitmap(img, new Size(videoWidth, videoHeight));

                EncoderParameters eps = new EncoderParameters();
                eps.Param = new EncoderParameter[]
                        {
                            // set best quality
                            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L)
                        };
                ImageCodecInfo ImageCoderType = OtherUtil.GetImageCoderInfo("image/jpeg");
                img.Save(tempPic, ImageCoderType, eps);
            }


            //批处理
            string mux = "\"" + ToolsUtil.FFMPEG.fullPath + "\" -loop 1 -r " + fps + " -t " + blackDuration + " -f image2 -i \"" + tempPic + "\" -c:v libx264 -crf " + crf.ToString("0.0") + " -y black.flv\r\n";
            mux += string.Format("\"{0}\\flvbind\" \"{1}\"  \"{2}\"  black.flv\r\n", ToolsUtil.ToolsFolder, outputVideoFile, inputVideoFile);
            mux += "del black.flv\r\n";

            batpath = Path.Combine(ToolsUtil.ToolsFolder, Path.GetRandomFileName() + ".bat");
            File.WriteAllText(batpath, mux, Encoding.Default);
            logger.Info(mux);
            Process.Start(batpath);
        }
    }
}
