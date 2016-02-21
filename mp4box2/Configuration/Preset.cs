using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace mp4box2.Configuration
{

    [Serializable]
    [XmlRoot("Preset")]
    public partial class Preset : PersistableObject
    {
        [XmlElement("Video")]
        public Video video = new Video();

        [XmlElement("Audio")]
        public Audio audio = new Audio();
    }

    //Preset/Video
    public class Video
    {
        [XmlElement("VideoEncoder")]
        public VideoEncoder videoEncoder = new VideoEncoder();
    }

    //Preset/Audio
    public class Audio
    {
        [XmlElement("AudioEncoder")]
        public AudioEncoder audioEncoder = new AudioEncoder();
    }


    //Preset/Video/VideoEncoder
    public class VideoEncoder
    {
        [XmlArray("X264")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x264 = new List<Parameter>();

        [XmlArray("X265")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x265 = new List<Parameter>();
    }


    //Preset/Audio/AudioEncoder
    public class AudioEncoder
    {
        [XmlArray("NeroAAC")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> NeroAAC = new List<Parameter>();

        [XmlArray("FDKAAC")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> FDKAAC = new List<Parameter>();

        [XmlArray("QAAC")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> QAAC = new List<Parameter>();
    }



    public class Parameter
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlText]
        public string value;

        public override string ToString()
        {
            return string.Format("name: {0}", name);
        }
    }


}
