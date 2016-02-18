using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box.Configurations;

namespace mp4boxTests
{
    [TestClass]
    public class PresetTests
    {
        [TestMethod]
        public void Save()
        {
            var preset = new Preset();

            preset.video.videoEncoder.x264.Add(new Parameter() { name = "n", value = "v" });

            preset.Save<Preset>("d:\\preset.xml");

            Preset.Load<Preset>("d:\\preset.xml");
        }


        [TestMethod]
        public void Default()
        {
            var preset = Preset.LoadDefault();
            preset.Save<Preset>("d:\\preset.xml");
        }


        [TestMethod]
        public void Load()
        {
            Preset.Load<Preset>("d:\\notExist.xml");
        }
    }
}
