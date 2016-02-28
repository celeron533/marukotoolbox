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
        public string BuildCommand()
        {
            StringBuilder command = new StringBuilder();
            if (mediaInfo == null)
                return string.Empty;

            //todo: if input file is avs

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
                    break;
                case EncoderOption.CRF:
                    break;
                case EncoderOption.TwoPass:
                    break;
                default:
                    break;
            }

            //todo: generate command parameters
            return command.ToString();
        }
    }
}
