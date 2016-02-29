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

        public Demuxer demuxer;
        public int seek;
        public int frames;

        public EncoderOption encoderOptions;
        public float CRFValue;    //used when encoderOption = CRF
        public int bitRate; //used when encoderOption = TwoPass
        public string customStr;   //used when encoderOption = Custom

        public bool useOriginalResolution;
        public int width, height;

        public void LoadMediaInfo()
        {
            mediaInfo = new MediaInfo.MediaInfo();
            mediaInfo.LoadMediaInfo(inputFile);
        }
    }
}
