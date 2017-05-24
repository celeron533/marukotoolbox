using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace mp4box
{
    public class Preset
    {
        const string XMLFileName = "preset.xml";
        XDocument xdoc = new XDocument();

        public Preset()
        {
            Load();
        }

        public void Load()
        {
            if (!File.Exists(XMLFileName))
                CreateDefaultAndSave();
            else
                xdoc = XDocument.Load(XMLFileName);
        }

        public void Save()
        {
            xdoc.Save(XMLFileName);
        }

        #region Create Default

        public void CreateDefaultAndSave()
        {
            CreateDefault();
            Save();
        }

        public void CreateDefault()
        {
            xdoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("root",
                        new XElement("Video",
                            new XElement("VideoEncoder",
                                new XElement("x264",
                                    new XElement("Parameter", "--crf 24 --preset 8 -r 6 -b 6 -i 1 --scenecut 60 -f 1:1 --qcomp 0.5 --psy-rd 0.3:0 --aq-mode 2 --aq-strength 0.8 --vf resize:960,540,,,,lanczos", new XAttribute("Name", "default")),
                                    new XElement("Parameter", "-p1 --crf 20 --aq-mode 2 --sar 32:27 --vf yadif:, --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10", new XAttribute("Name", "DVDRIP不切边,16:9")),
                                    new XElement("Parameter", "-p1 --crf 20 --aq-mode 2 --sar 40:33 --vf yadif:, --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10", new XAttribute("Name", "DVDRIP不切边,sar40:33")),
                                    new XElement("Parameter", "-p1 --crf 20 --aq-mode 2 --sar 40:33 --vf yadif:,/crop:8,0,8,0 --stat \"TEMP.stat\" --slow-firstpass --ref 8 --preset 8 --subme 10", new XAttribute("Name", "DVDRIP切边,sar40:33")),
                                    new XElement("Parameter", "--profile high --level 3.1 --level-force  --device iphone", new XAttribute("Name", "iOS")),
                                    new XElement("Parameter", "--crf 25 --preset placebo --subme 10 --ref 7 --bframes 7 --qcomp 0.75 --psy-rd 0:0 --keyint infinite --min-keyint 1", new XAttribute("Name", "MAD")),
                                    new XElement("Parameter", "--profile main --level 3.0 --ref 3 --b-pyramid none --weightp 1 --vbv-maxrate 10000 --vbv-bufsize 10000   --vf resize:480,272,,,,lanczos  --device psp", new XAttribute("Name", "PSP"))
                                    ),
                                new XElement("x265",
                                    new XElement("Parameter", "", new XAttribute("Name", "x265default"))
                                    )
                                )
                            ),
                        new XElement("Audio",
                            new XElement("AudioEncoder",
                                new XElement("NeroAAC",
                                    new XElement("Parameter", "-he -br 32000", new XAttribute("Name", "NeroAAC_HE-32Kbps")),
                                    new XElement("Parameter", "-he -br 48000", new XAttribute("Name", "NeroAAC_HE-48Kbps")),
                                    new XElement("Parameter", "-he -br 64000", new XAttribute("Name", "NeroAAC_HE-64Kbps")),
                                    new XElement("Parameter", "-lc -br 128000", new XAttribute("Name", "NeroAAC_LC-128Kbps")),
                                    new XElement("Parameter", "-lc -br 192000", new XAttribute("Name", "NeroAAC_LC-192Kbps")),
                                    new XElement("Parameter", "-lc -br 256000", new XAttribute("Name", "NeroAAC_LC-256Kbps")),
                                    new XElement("Parameter", "-q 1 -lc", new XAttribute("Name", "NeroAAC_LC-Q1"))
                                    ),
                                new XElement("FDKAAC",
                                     new XElement("Parameter", "-m 1", new XAttribute("Name", "FDKAAC_VBR1")),
                                     new XElement("Parameter", "-m 2", new XAttribute("Name", "FDKAAC_VBR2")),
                                     new XElement("Parameter", "-m 3", new XAttribute("Name", "FDKAAC_VBR3")),
                                     new XElement("Parameter", "-m 4", new XAttribute("Name", "FDKAAC_VBR4")),
                                     new XElement("Parameter", "-m 5", new XAttribute("Name", "FDKAAC_VBR5")),
                                     new XElement("Parameter", "-p 5 -b 64", new XAttribute("Name", "FDKAAC_HE-_CBR64Kbps")),
                                     new XElement("Parameter", "-b 128", new XAttribute("Name", "FDKAAC_LC-_CBR128Kbps")),
                                     new XElement("Parameter", "-b 192", new XAttribute("Name", "FDKAAC_LC-_CBR192Kbps")),
                                     new XElement("Parameter", "-b 256", new XAttribute("Name", "FDKAAC_LC-_CBR256Kbps"))
                                     ),
                                new XElement("QAAC",
                                    new XElement("Parameter", "--he -c 64 -q 2 --no-optimize", new XAttribute("Name", "QAAC_HE-CBR64Kbps")),
                                    new XElement("Parameter", "--he -v 64 -q 2 --no-optimize", new XAttribute("Name", "QAAC_HE-CVBR64Kbps")),
                                    new XElement("Parameter", "-c 128 -q 2 --no-optimize", new XAttribute("Name", "QAAC_LC-CBR128Kbps")),
                                    new XElement("Parameter", "-v 128 -q 2 --no-optimize", new XAttribute("Name", "QAAC_LC-CVBR128Kbps")),
                                    new XElement("Parameter", "-c 256 -q 2 --no-optimize", new XAttribute("Name", "QAAC_LC-CBR256Kbps")),
                                    new XElement("Parameter", "-v 256 -q 2 --no-optimize", new XAttribute("Name", "QAAC_LC-CVBR256Kbps")),
                                    new XElement("Parameter", "-V 90 -q 2 --no-optimize", new XAttribute("Name", "QAAC_TVBR_V90")),
                                    new XElement("Parameter", "-V 127 -q 2 --no-optimize", new XAttribute("Name", "QAAC_TVBR_V127"))
                                    ),
                                new XElement("MP3",
                                    new XElement("Parameter", "--alt-preset extreme", new XAttribute("Name", "extreme")),
                                    new XElement("Parameter", "--preset insane", new XAttribute("Name", "insane")),
                                    new XElement("Parameter", "--preset standard", new XAttribute("Name", "standard")),
                                    new XElement("Parameter", "--preset medium ", new XAttribute("Name", "medium"))
                                    )
                                )
                            )
                        )
                );
        }

        #endregion


        public XElement GetVideoPreset(string encType)
        {
            return xdoc.Element("root").Element("Video").Element("VideoEncoder").Element(encType);
        }

        public XElement GetAudioPreset(string encType)
        {
            return xdoc.Element("root").Element("Audio").Element("AudioEncoder").Element(encType);
        }

    }
}
