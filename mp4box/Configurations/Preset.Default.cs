using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Configurations
{
    public partial class Preset
    {
        /// <summary>
        /// Load the default preset. Should be called when Load() fail.
        /// </summary>
        public static Preset LoadDefault()
        {
            Preset preset = new Preset();

            //x264
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "default",
                value = "--crf 24 --preset 8 -r 6 -b 6 -i 1 --scenecut 60 -f 1:1 --qcomp 0.5 --psy-rd 0.3:0 --aq-mode 2 --aq-strength 0.8 --vf resize:960,540,,,,lanczos"
            });
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "DVDRIP不切边,16:9",
                value = "-p1 --crf 20 --aq-mode 2 --sar 32:27 --vf yadif:, --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10"
            });
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "DVDRIP不切边,sar40:33",
                value = "-p1 --crf 20 --aq-mode 2 --sar 40:33 --vf yadif:, --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10"
            });

            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "DVDRIP切边,sar40:33",
                value = "-p1 --crf 20 --aq-mode 2 --sar 40:33 --vf yadif:,/crop:8,0,8,0 --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10"
            });
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "iOS",
                value = "--profile high --level 3.1 --level-force  --device iphone"
            });
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "MAD",
                value = "--crf 25 --preset placebo --subme 10 --ref 7 --bframes 7 --qcomp 0.75 --psy-rd 0:0 --keyint infinite --min-keyint 1"
            });
            preset.video.videoEncoder.x264.Add(new Parameter
            {
                name = "PSP",
                value = "--profile main --level 3.0 --ref 3 --b-pyramid none --weightp 1 --vbv-maxrate 10000 --vbv-bufsize 10000   --vf resize:480,272,,,,lanczos  --device psp"
            });

            //x265
            preset.video.videoEncoder.x265.Add(new Parameter
            {
                name = "x265default",
                value = ""
            });

            //NeroAAC
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_HE-32Kbps",
                value = "-he -br 32000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_HE-48Kbps",
                value = "-he -br 48000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_HE-64Kbps",
                value = "-he -br 64000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_LC-128Kbps",
                value = "-lc -br 128000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_LC-192Kbps",
                value = "-lc -br 192000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_LC-256Kbps",
                value = "-lc -br 256000"
            });
            preset.audio.audioEncoder.NeroAAC.Add(new Parameter
            {
                name = "NeroAAC_LC-Q1",
                value = "-q 1 -lc"
            });

            //FDKAAC
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_VBR1",
                value = "-m 1"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_VBR2",
                value = "-m 2"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_VBR3",
                value = "-m 3"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_VBR4",
                value = "-m 4"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_VBR5",
                value = "-m 5"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_HE-_CBR64Kbps",
                value = "-p 5 -b 64"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_LC-_CBR128Kbps",
                value = "-b 128"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_LC-_CBR192Kbps",
                value = "-b 192"
            });
            preset.audio.audioEncoder.FDKAAC.Add(new Parameter
            {
                name = "FDKAAC_LC-_CBR256Kbps",
                value = "-b 256"
            });

            //QAAC
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_HE-CBR64Kbps",
                value = "--he -c 64 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_HE-CVBR64Kbps",
                value = "--he -v 64 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_LC-CBR128Kbps",
                value = "-c 128 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_LC-CVBR128Kbps",
                value = "-v 128 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_LC-CBR256Kbps",
                value = "-c 256 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_LC-CVBR256Kbps",
                value = "-v 256 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_TVBR_V90",
                value = "-V 90 -q 2 --no-optimize"
            });
            preset.audio.audioEncoder.QAAC.Add(new Parameter
            {
                name = "QAAC_TVBR_V127",
                value = "-V 127 -q 2 --no-optimize"
            });

            return preset;
        }
    }
}
