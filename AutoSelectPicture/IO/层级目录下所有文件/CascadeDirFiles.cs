/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/27
 * Time: 20:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AutoSelectPicture.IO.层级目录下所有文件
{
	/// <summary>
	/// Description of CascadeDirFiles.
	/// </summary>
	public class CascadeDirFiles
	{
		private string pictureDirectory = "";
        private Dictionary<string, string[]> pictureDictionary = null;
		public CascadeDirFiles()
		{
		}
		 //得到目录下的文件名列表
        public void GetDirFiles(string pictureDirectory)
        {
            this.pictureDirectory = pictureDirectory;
            //
            bool isDirExist = false;
            List<string> pictureFileList = new List<string>();
            DirectoryCollection pictureCollection = new DirectoryCollection();
            DirectoryFiles pictureDirFiles = new DirectoryFiles();
            //
            isDirExist = Directory.Exists(pictureDirectory);
            if (isDirExist == false)
            {
                throw new Exception(string.Format("{0}目录不存在.", pictureDirectory));
            }
            else
            {
                #region
                /*
				 *得到父目录下的所有层级目录列表
				 *例如:目录层级如下
				 * D:\刘亦菲
				 *        |
				 *        --1
				 *        |
				 *        --2
				 * DirectoryCollection pictureCollection = new DirectoryCollection();
				 * List<string> directoryList=pictureCollection.getCollection(@"D:\刘亦菲");
				 * 
				 * 返回值:
				 * @"D:\刘亦菲"
				 * @"D:\刘亦菲\1"
				 * @"D:\刘亦菲\2"
				 * 
            	 */
                #endregion
                pictureDictionary = pictureCollection.getDictionary(pictureDirectory);
                //

                List<string>   keyList = new List<string>();
                List<string[]> valueList = new List<string[]>();

                Dictionary<string, string[]>.Enumerator enumerator = pictureDictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string key = enumerator.Current.Key;
                    //string[] value = enumerator.Current.Value;
                    keyList.Add(key);
                    //valueList.Add(value);
                }
                //如果目录后面没有斜杠:"\\" 则增加
                for (int i = 0; i < keyList.Count; i++)
                {
                    string key = keyList[i];
                    keyList[i] = key.EndsWith("\\") ? key : (Directory.Exists(key) ? key+ "\\" : Path.GetDirectoryName(key) + "\\");
                }
                //过滤非目录
                for (int i = 0; i < keyList.Count; i++)
                {
                    string key = keyList[i];
                    keyList[i] = Path.GetDirectoryName(key).EndsWith("\\") ? key : Path.GetDirectoryName(key) + "\\";
                }
                #region
                /*
                 * 遍历列表中的字符串，并按照字符串中路径的目录数量从小到大排序
                 * 举例:列表如下
                 *List<string> testList = new List<string>();
                 *testList.Add(@"D:\test\");
                 *testList.Add(@"D:\test\test1\file.txt");
                 *testList.Add(@"D:\test\test1");
                 *testList.Add(@"D:\test\test1\test0\file.txt");
                 *testList.Add(@"D:\test\");
                 *testList.Add(@"D:\test\test1\test0");
                 * 
                 * 片段1:
                 * Path.GetDirectoryName(key).Replace('/', '\\').Split(new char[] {'\\','/'})
                 * 将得到的目录分解成目录
                 * 举例:
                 * key值: D:\test\test1\test0\file.txt
                 * 通过片段1产生临时数组:
                 * {"D:","test","test1","test0",""}
                 * 
                 * 片段2:
                 * 去除片段1中产生的临时数组:
                 * Path.GetDirectoryName(key).Replace('/', '\\').Split(new char[] {'\\','/'}).Where(k=>k.Trim()!="")
                 * 通过片段2产生临时数组:
                 * {"D:","test","test1","test0}
                 * 
                 * 片段3:计算片段2中临数组的长度
                 * 对于临时数组:{"D:","test","test1","test0}
                 * 此数组的长度为4
                 * 
                 * 片段4:遍历List中的字符串，通过片段1，片段2，片段3计算临时数组的长度，并升序排列
                 * keyList.OrderBy(key=>...); 
                 * 其中...代码片段2
                 */
                #endregion
                IEnumerable<string> orderKeyList=keyList.OrderBy(key => Path.GetDirectoryName(key).Replace('/', '\\').Split(new char[] {'\\'}).Where(k=>k.Trim()!="").Count());
                keyList=orderKeyList.ToList();
                //去重复字符串
                IEnumerable<string> distinctKeyList= keyList.Distinct();
                keyList =distinctKeyList.ToList();
            }
            return;
        }
	}
}
