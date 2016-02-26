using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.AVS
{
    //Base
    public class EnableStatus
    {
        public bool enabled;
    }

    public class UnDot : EnableStatus
    {
        public bool unDot;
    }

    //http://avisynth.nl/index.php/Tweak
    public class Tweak : EnableStatus
    {
        public float chroma;
        public float saturation;
        public float brightness;
        public float contrast;
    }

    //http://avisynth.nl/index.php/LanczosResize
    public class LanczosResize : EnableStatus
    {
        public int width;
        public int height;
    }

    //http://avisynth.nl/index.php/Levels
    public class Levels : EnableStatus
    {
        public int inputLow;
        public float gamma;
        public int inputHigh;
        public int outputLow;
        public int outputHigh;
    }

    //http://avisynth.nl/index.php/Sharpen
    public class Sharpen : EnableStatus
    {
        public bool sharpen;
    }

    //http://avisynth.nl/index.php/Crop
    public class Crop : EnableStatus
    {
        public int left;
        public int top;
        public int width;  //right if <0
        public int height; //bottom if <0
    }

    public class AddBorders : EnableStatus
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    //http://avisynth.nl/index.php/Trim
    public class Trim : EnableStatus
    {
        public int startFrame;
        public int endFrame;
    }
}
