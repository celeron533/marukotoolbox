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

    public enum AudioEncoderType
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

    public enum VideoEncoderType
    {
        NA = -1,
        X264 = 0,
        X265
    }

    public enum AvsLocationType
    {
        Embedded,
        System32,
        SysWOW64
    }
    
    public enum ProcessPriority
    {
        //todo: remove or merge it to standard ProcessPriorityClass
        //Sequence is mapping from ConfigX264PriorityComboBox.SelectedIndex
        Idle=0,
        BelowNormal,
        Normal,
        AboveNormal,
        High,
        RealTime,
    }
}
