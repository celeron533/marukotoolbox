using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text.Tests
{
    [TestClass()]
    public class StringBuilderExtensionTests
    {
        [TestMethod()]
        public void AppendParameterTest()
        {
            // start with empty
            StringBuilder sb = new StringBuilder();
            sb.AppendParameters("aaa");
            Assert.AreEqual("aaa", sb.ToString());
        }

        [TestMethod()]
        public void AppendParameterTest2()
        {
            // start with existing parameter
            StringBuilder sb = new StringBuilder();
            sb.Append("bbb");
            sb.AppendParameters("ccc");
            Assert.AreEqual("bbb ccc", sb.ToString());
        }

        [TestMethod()]
        public void AppendParameterTest3()
        {
            // start with existing parameter
            // also append multiple parameters
            StringBuilder sb = new StringBuilder();
            sb.Append("ddd");
            sb.AppendParameters("eee","fff");
            Assert.AreEqual("ddd eee fff", sb.ToString());
        }

        [TestMethod()]
        public void AppendParameterTest4()
        {
            // start with existing parameter contans space
            StringBuilder sb = new StringBuilder();
            sb.Append("ggg ");
            sb.AppendParameters("hhh");
            Assert.AreEqual("ggg hhh", sb.ToString());
        }

        [TestMethod()]
        public void AppendParameterTest5()
        {
            // start with existing parameter contans space
            // add a number
            StringBuilder sb = new StringBuilder();
            sb.Append("iii ");
            sb.AppendParameters(444);
            Assert.AreEqual("iii 444", sb.ToString());
        }
    }
}