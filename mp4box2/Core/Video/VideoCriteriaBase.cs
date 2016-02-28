using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.Video
{
    public abstract class VideoCriteriaBase
    {
        public string inputFile;
        public string outputFile;
        public string subtitleFile;

        public MediaInfo.MediaInfo mediaInfo;

        public AudioOption audioOption;

        public Splitter splitter;
        public int seek;
        public int frames;

        public EncoderOption encoderOptions;
        public float CRFValue;    //used when encoderOption = CRF
        public int bitRate; //used when encoderOption = TwoPass
        public string custom;   //used when encoderOption = Custom

        public bool useOriginalResolution;
        public int width, hight;

        public void LoadMediaInfo()
        {
            mediaInfo = new MediaInfo.MediaInfo();
            mediaInfo.LoadMediaInfo(inputFile);
        }
    }
}
