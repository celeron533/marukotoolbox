using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.AVS
{
    public class AVSCriteria
    {
        #region Dll files
        public string VSFilterDll;  //normal subtitle
        public string SupTitleDll;  // .sup subtitle
        public string LSMASHSourceDll;  //.mp4 .mov .qt .3gp .3g2 : LSMASHVideoSource; others : LWLibavVideoSource
        public string UnDotDll;
        #endregion

        public string inputVideoFile;
        public string inputSubtitleFile;
        public string outputVideoFile;

        public UnDot unDot = new UnDot();
        public Tweak tweak = new Tweak();
        public LanczosResize lanczosResize = new LanczosResize();
        public Sharpen sharpen = new Sharpen();
        public Levels levels = new Levels();
        public Crop crop = new Crop();
        public Trim trim = new Trim();
        public List<string> externalFilters = new List<string>();


    }


}
