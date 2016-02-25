using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.AVS
{
    public class AVSCriteria
    {
        #region Dll files
        public string VSFilterDll;
        public string SupTitleDll;
        public string LSMASHSourceDll;
        public string UnDotDll;
        #endregion

        public string inputVideoFile;
        public string inputSubtitleFile;
        public string outputVideoFile;


        public UnDot unDot;

        public Tweak tweak;

        public LanczosResize lanczosResize;

        public Sharpen sharpen;

        public Levels levels;

        public Crop crop;

        public Trim trim;

    }

    
}
