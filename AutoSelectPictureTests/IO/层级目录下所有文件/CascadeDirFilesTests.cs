using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSelectPicture.IO.层级目录下所有文件;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.IO.层级目录下所有文件.Tests
{
    [TestClass()]
    public class CascadeDirFilesTests
    {
        [TestMethod()]
        public void CascadeDirFilesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDirFilesTest()
        {
            //Assert.Fail();
           List<string> testList = new List<string>();
           testList.Add(@"D:\test\");
           testList.Add(@"D:\test\test1\file.txt");
           testList.Add(@"D:\test\test1");
           testList.Add(@"D:\test\test1\test0\file.txt");
           testList.Add(@"D:\test\");
           testList.Add(@"D:\test\test1\test0");
            CascadeDirFiles cascadeDirFiles = new CascadeDirFiles();
            List<string> resultList=cascadeDirFiles.GetDirFiles(testList);
        }
    }
}