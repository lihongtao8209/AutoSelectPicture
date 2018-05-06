using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSelectPicture.正则表达式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.正则表达式.Tests
{
    [TestClass()]
    public class RegexExpressTests
    {
        [TestMethod()]
        public void IsPatternMatchTest()
        {
            RegexExpress regexExpress = new RegexExpress();
            regexExpress.IsMatch(@"D:\test\test0\file.txt\测试文件.txt", @"\w:(\\[\w\d\._]+)+\\");
            // \" 对 " 转义  \\对  \ 转义
            regexExpress.IsMatch(@"D:\test\test0\file.txt\测试文件.txt", "\\w:(\\[^<>:\"/\\|?*]+)+\\");
            //Assert.Fail();
        }
    }
}