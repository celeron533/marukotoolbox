using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box
{
    public partial class MainForm
    {
        public enum MediaType
        {
            Audio,
            Video
        }

        public enum X264Mode
        {
            Custom,
            Crf,
            TwoPass
        }

        public enum AudioEncoder
        {
            // order sensitive
            NeroAAC = 0,
            QAAC,
            WAV,
            ALAC,
            FLAC,
            FDKAAC,
            AC3,
            MP3
        }
    }
}
