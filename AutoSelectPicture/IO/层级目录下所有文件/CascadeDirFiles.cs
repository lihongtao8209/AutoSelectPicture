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

namespace AutoSelectPicture.IO.层级目录下所有文件
{
	/// <summary>
	/// Description of CascadeDirFiles.
	/// </summary>
	public class CascadeDirFiles
	{
		private string pictureDirectory = "";
        private Dictionary<string, string[]> pictureDictionary = null;
        private Dictionary<Dictionary<int,string>,List<string>> cascadeDictionary=null;
		public CascadeDirFiles()
		{
		}
		 //得到目录下的文件名列表
        public void getDirFiles(string pictureDirectory)
        {
            this.pictureDirectory = pictureDirectory;
            //
            bool isDirExist = false;
            string[] pictureFiles = null;
            List<string> directoryList = null;
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
                pictureDictionary = pictureCollection.getDictionary(pictureDirectory);
                //
				foreach (KeyValuePair<string, string[]> pair in pictureDictionary) {
                	List<string> valueList=new List<string>();
                	for(int i=0;i<pictureDictionary.Values.Count;i++){
                		valueList.Add(pictureDictionary.Values[i]);
                	}
//                	if(valueList.Find(()=>pair.Key)){
//                		
//                	}
				}
            }
            return;
        }
	}
}
