using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoSelectPicture
{
	/*
	 * 功能 查询一个目录下的所有目录 
	 */
    class DirectoryCollection
    {
        Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
        List<string> directoryListKey = new List<string>();
        List<string[]> directoryListValue = new List<string[]>();
		/*
		 * 功能 得到一个目录下的所有目录 
		 * 例如:目录层级如下
	     * D:\刘亦菲
	     *        |
	     *        --1
	     *        |
	     *        --2
	     * 
	     * List<string> result=getCollection(@"D:\刘亦菲");
	     * 返回值:
	     * D:\刘亦菲
		 * D:\刘亦菲\1 
		 * D:\刘亦菲\2
	     * 
	     * 注以上返回形式都为字符串
		 * 举列: D:\刘亦菲 在程序中的表现形式: "D:\\刘亦菲" 或 @"D:\刘亦菲"
		 */ 
        public List<string> getCollection(string parentDirectory)
        {
            bool isDirExist = Directory.Exists(parentDirectory);
            if(isDirExist == true)
            {
                try
                {
                    findDirectory(parentDirectory);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.StackTrace); 
                }
                 
            }
            return directoryListKey;
        }
		
        /*
		 * 功能 得到一个字典
		 *      键值对为:{目录,该目录的子目录集合}
		 * 例如:目录层级如下
	     * D:\刘亦菲
	     *        |
	     *        --1
	     *        |
	     *        --2
	     * 
	     * Dictionary<string, string[]> result=getDictionary(@"D:\刘亦菲");
	     * 返回值:
	     * "D:\\刘亦菲"    {"D:\\刘亦菲\\1",D:\\刘亦菲\\2}
	     * "D:\\刘亦菲\1"  {""} 
	     * "D:\\刘亦菲\2"  {""}
	     * 
		 */ 
        public Dictionary<string, string[]> getDictionary(string parentDirectory)
        {
            getCollection(parentDirectory);
            for(int i = 0; i < directoryListKey.Count; i++)
            {
                dictionary.Add(directoryListKey[i], directoryListValue[i]);
            }
            return dictionary;
        }
		/*
		 * 功能:查找文件的层级目录
		 */
        private void findDirectory(string parentDirectory)
        {
            string[] subDirectorys = Directory.GetDirectories(parentDirectory);
            if (subDirectorys.Length!=0)
            {//如果有子目录
                directoryListKey.Add(parentDirectory);
                directoryListValue.Add(subDirectorys);
                for (int i = 0; i < subDirectorys.Length; i++)
                {
                    findDirectory(subDirectorys[i]);
                }
            }
            else
            {
                directoryListKey.Add(parentDirectory);
                directoryListValue.Add(subDirectorys);
            }
            return;
        }

        
    }

    class Collection
    {
        protected List<string> directoryListKey = null;
        protected List<string[]> directoryListValue = null;
        public Collection(List<string> key,List<string[]> value)
        {
            directoryListKey = key;
            directoryListValue = value;
        }
        public int length()
        {
            return directoryListKey.Count;
        }
        //目录集合
        public List<string> DirectoryList
        {
            get
            {
                return directoryListKey;
            }
        }
        //子目录集合
        public List<string[]> SubDirectoryList
        {
            get
            {
                return directoryListValue;
            }
        }
    }
}
