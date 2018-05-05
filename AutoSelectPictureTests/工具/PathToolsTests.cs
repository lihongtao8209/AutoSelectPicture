using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSelectPicture.工具;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.工具.Tests
{
    [TestClass()]
    public class PathToolsTests
    {
        [TestMethod()]
        public void GetSubPathTest()
        {
            string subDirectory=PathTools.GetSubDirectory("c:\\test\test0\\test1\\1");
            Assert.Fail();
        }
    }
}