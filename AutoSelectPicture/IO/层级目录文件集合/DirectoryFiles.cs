using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoSelectPicture
{
    class DirectoryFiles
    {
        //存放图片文件的目录
        private string directoryPath= "";
        //图片文件
        private string[] pictureFiles = null;
        //
        public string[] getFiles(string path)
        {
            setDirectory(path);
            return getPictureFiles();
        }
        //设置存放文件的目录
        private void setDirectory(string path)
        {
            this.directoryPath = path;
        }
        //得到目录的文件
        private string[] getPictureFiles()
        {
            if (directoryPath == "") {
                throw new Exception("未设置文件目录");
            } else
            {
                pictureFiles = Directory.GetFiles(directoryPath);
            }
            return pictureFiles;
        }
        //过滤文件后缀名
        public List<string> getFilterFileName(string[] fileNameArray,string[] fileSuffix=null)
        {
            bool isMatch = false;
            char[] trimChars = new char[]{' '};
            string fileName = "";
            List<string> filterFileNameList =new List<string>();
            for (int i = 0; i < fileNameArray.Length; i++)
            {
                fileName = fileNameArray[i].Trim(trimChars);
                isMatch =Regex.IsMatch(fileName, @".*\.jpg", RegexOptions.IgnoreCase);
                if (isMatch == true)
                {
                    filterFileNameList.Add(fileNameArray[i]);
                }
            }
            return filterFileNameList;
        }
    }
}
