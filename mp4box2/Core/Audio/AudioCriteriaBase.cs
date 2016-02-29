﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.Audio
{
    public abstract class AudioCriteriaBase
    {
        public string inputFile;
        public string outputFile;

        public MediaInfo.MediaInfo mediaInfo;

        public EncoderOption encoderOption;
        public int bitRate; //used when encoderOption = BitRate
        public string custom;   //used when encoderOption = Custom

        public void LoadMediaInfo()
        {
            mediaInfo = new MediaInfo.MediaInfo();
            mediaInfo.LoadMediaInfo(inputFile);
        }
    }
}