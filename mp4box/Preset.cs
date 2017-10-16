using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace mp4box.Preset
{
    [XmlRoot("root")]
    public class Preset
    {
        const string XMLFileName = "preset.xml";
        //XDocument xdoc = new XDocument();

        [XmlElement("Video")]
        public Video video;
        [XmlElement("Audio")]
        public Audio audio;

        public Preset()
        {
        }

        public static Preset Load()
        {
            if (!File.Exists(XMLFileName))
                File.WriteAllText(XMLFileName, Properties.Resources.preset_xml);

            return Deserialize(XMLFileName);
        }

        static Preset Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Preset));

            using (TextReader reader = new StreamReader(fileName))
            {
                return (Preset)serializer.Deserialize(reader);
            }
        }

        public static void Save(Preset preset)
        {
            Serialize(preset, XMLFileName);
        }

        static void Serialize(Preset preset, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Preset));

            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, preset);
            }
        }

        


        //public XElement GetVideoPreset(string encType)
        //{
        //    return xdoc.Element("root").Element("Video").Element("VideoEncoder").Element(encType);
        //}

        //public XElement GetAudioPreset(string encType)
        //{
        //    return xdoc.Element("root").Element("Audio").Element("AudioEncoder").Element(encType);
        //}
    }



    public class Audio
    {
        [XmlElement("AudioEncoder")]
        public AudioEncoder audioEncoder;

        public Audio()
        {
        }
    }

    public class AudioEncoder
    {
        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> NeroAAC;

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> FDKAAC;

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> QAAC;

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> MP3;

        public AudioEncoder()
        {
        }
    }



    public class Video
    {
        [XmlElement("VideoEncoder")]
        public VideoEncoder videoEncoder;

        public Video()
        {
        }
    }

    public class VideoEncoder
    {
        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x264;

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x265;

        public VideoEncoder()
        {
        }
    }


    public class Parameter
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlText]
        public string value;

        public override string ToString()
        {
            return name;
        }
    }
}
