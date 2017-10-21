using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box
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
        NA = -1,
        NeroAAC = 0,
        QAAC,
        WAV,
        ALAC,
        FLAC,
        FDKAAC,
        AC3,
        MP3
    }

    public enum AudioMode
    {
        Custom,
        Bitrate
    }

    public enum VideoEncoder
    {
        NA = -1,
        X264 = 0,
        X265
    }
}
