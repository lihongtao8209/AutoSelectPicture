using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSelectPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.Tests
{
    [TestClass()]
    public class IOToolsTests
    {
        [TestMethod()]
        public void CreateDirectoryTest()
        {
            // IOTools.CreatePath(@"D:\test\test1\test0\file.txt");
            IOTools.CopyFile(@"D:\temp\file.txt\1.txt", @"D:\test\test1\test0\file.txt");
            //Assert.Fail();
        }
    }
}