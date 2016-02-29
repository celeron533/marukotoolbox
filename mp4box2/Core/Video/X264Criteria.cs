using mp4box2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace mp4box2.Core.Video
{
    public class X264Criteria : VideoCriteriaBase
    {
        //todo: add any specifications to x264 encoder
        public int threads = 0;



        public string BuildCommand()
        {
            ParameterBuilder command = new ParameterBuilder();
            if (mediaInfo == null)
                return string.Empty;

            //todo: if input file is avs

            //Append("\"" + workPath + "\\avs4x26x.exe\"" + " -L ");
            //sAppend("\"" + Path.Combine(workPath, x264ExeComboBox.SelectedItem.ToString()) + "\"");


            //set keyint as 10 times as fps
            double frameRate;
            int keyint = -1;
            if (double.TryParse(mediaInfo.video.frameRate, out frameRate))
            {
                keyint = (int)(Math.Round(frameRate) * 10);
            }

            switch (encoderOptions)
            {
                case EncoderOption.Custom:
                    //Append(" " + x264CustomParameterTextBox.Text);
                    command.Add(customStr);
                    break;
                case EncoderOption.CRF:
                    //Append(" --crf " + x264CRFNum.Value);
                    command.Add("--crf", CRFValue.ToString("0.0"));
                    break;
                case EncoderOption.TwoPass:
                    //Append(" --pass " + pass + " --bitrate " + x264BitrateNum.Value + " --stats \"" + Path.Combine(tempfilepath, Path.GetFileNameWithoutExtension(output)) + ".stats\"");
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (encoderOptions != EncoderOption.Custom)
            {
                if (demuxer != Demuxer.auto)
                    command.Add("--demuxer", demuxer.ToString());

                if (threads > 0)    // 0 means auto
                    command.Add("--threads", threads.ToString());

                string x264extraCommand = "";//temp
                if (!string.IsNullOrEmpty(x264extraCommand))
                    command.Add(x264extraCommand);
                else
                    command.Add("--preset 8")
                        .Add("-I" + keyint.ToString())
                        .Add("-r 4 -b 3 --me umh -i 1 --scenecut 60 -f 1:1 --qcomp 0.5 --psy-rd 0.3:0 --aq-mode 2 --aq-strength 0.8");
                if (!useOriginalResolution && height > 0 && width > 0)
                    command.Add(string.Format("--vf resize:{0},{1},,,,lanczos", width, height));
            }

            //If have Subtitle

            //if (!string.IsNullOrEmpty(sub))
            //{
            //    string x264tmpline = sb.ToString();
            //    if (x264tmpline.IndexOf("--vf") == -1)
            //        sb.Append(" --vf subtitles --sub \"" + sub + "\"");
            //    else
            //    {
            //        Regex r = new Regex("--vf\\s\\S*");
            //        Match m = r.Match(x264tmpline);
            //        sb.Insert(m.Index + 5, "subtitles/").Append(" --sub \"" + sub + "\"");
            //    }
            //}


            //general

            //if (x264SeekNumericUpDown.Value != 0)
            //    sb.Append(" --seek " + x264SeekNumericUpDown.Value.ToString());
            //if (x264FramesNumericUpDown.Value != 0)
            //    sb.Append(" --frames " + x264FramesNumericUpDown.Value.ToString());
            //if (x264mode == 2 && pass == 1)
            //    sb.Append(" -o NUL");
            //else if (!string.IsNullOrEmpty(output))
            //    sb.Append(" -o " + "\"" + output + "\"");
            //if (!string.IsNullOrEmpty(input))
            //    sb.Append(" \"" + input + "\"");

            return command.Build().ToString();
        }

    }
}
