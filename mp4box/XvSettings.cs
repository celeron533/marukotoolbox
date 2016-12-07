namespace mp4box
{
    public class XvSettings
    {
        public int V_width { get; set; }

        public int V_high { get; set; }

        public string Subtitle { get; set; }

        public bool IsResizeChecked { get; set; }

        public int X26xSeek { get; set; }

        public int X26xFrames { get; set; }

        public int X26xBitrate { get; set; }

        public string X26xDemuxer { get; set; }

        public string X26xThreads { get; set; }

        public string ExtParameter { get; set; }

        public decimal CrfValue { get; set; }

        public string CustomParameter { get; set; }
    }
}