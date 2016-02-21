using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Core.Video
{
    public enum AudioOption
    {
        WithAudio,
        NoAudio,
        CopyAudio
    }

    public enum Splitter
    {
        auto,
        ffms,
        lavf,
        avs,
        raw,
        y4m
    }

    public enum EncoderOption
    {
        CRF,
        TwoPass,
        Custom
    }
}
