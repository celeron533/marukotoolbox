using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace mp4box.Configurations
{
    [Serializable]
    [XmlRoot("root")]
    public class Preset : PersistableObject
    {
        [XmlElement("Video")]
        public Video video = new Video();

        [XmlElement("Audio")]
        public Audio audio = new Audio();

    }

    //root/Video
    public class Video
    {
        [XmlElement("VideoEncoder")]
        public VideoEncoder videoEncoder = new VideoEncoder();
    }

    //root/Audio
    public class Audio
    {
        [XmlElement("AudioEncoder")]
        public AudioEncoder audioEncoder = new AudioEncoder();
    }


    //root/Video/VideoEncoder
    public class VideoEncoder
    {
        [XmlArray("X264")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x264 = new List<Parameter>();

        [XmlArray("X265")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> x265 = new List<Parameter>();
    }


    //root/Audio/AudioEncoder
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
    }

}
