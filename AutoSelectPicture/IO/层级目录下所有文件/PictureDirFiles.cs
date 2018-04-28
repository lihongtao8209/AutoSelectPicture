using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoSelectPicture
{
    /*
     * PictureDirFiles pictureDirFiles = new PictureDirFiles();
     * pictureDirFiles.setPictureDirectory(@"D:\照片\刘亦菲");
     * List<string> pictureNameList=pictureDirFiles.getPictureDirFiles() 
     */
    class PictureDirFiles
    {
        private string pictureDirectory = "";
        private List<string> pictureNameList = null;
        public PictureDirFiles()
        {

        }
        public PictureDirFiles(string pictureDirectory)
        {
            setPictureDirectory(pictureDirectory);
        }
        //设置目录
        private void setPictureDirectory(string pictureDirectory)
        {
            this.pictureDirectory = pictureDirectory;
        }
        //得到目录下的文件名列表
        public List<string> getPictureDirFiles(string pictureDirectory)
        {
            this.pictureDirectory = pictureDirectory;
            //
            bool isDirExist = false;
            string[] pictureFiles = null;
            List<string> directoryList = null;
            this.pictureNameList = new List<string>();
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
                directoryList = pictureCollection.getCollection(pictureDirectory);
                //编历目录下的所有目录
                for (int i = 0; i < directoryList.Count; i++)
                {
                	//得到每个目录下的文件
                    pictureFiles = pictureDirFiles.getFiles(directoryList[i]);
                    //使正则表达式判断文件的后缀(而不是文件的格式)是否符合要求
                    pictureFileList = pictureDirFiles.getFilterFileName(pictureFiles);
                    if (pictureFileList.Count != 0)
                    {
                        this.pictureNameList.AddRange(pictureFileList);
                    }
                    //ConsoleWriter.write("目录:"+ directoryList[i]);
                    //ConsoleWriter.write("文件数:"+ pictureFileList.Count);
                    //ConsoleWriter.writeLineNo(pictureFileList);
                }
            }
            return this.pictureNameList;
        }
		/*
		 * 调用getPictureDirFiles方法后
		 * 可调用此方法
		 * 判断图片是否在磁盘上存在
		 */
        public List<string> getValidatePictureDirFiles()
        {
            bool isFileExist = false;
            string pictureName = "";
            this.pictureNameList = new List<string>();
            for(int i = 0; i < this.pictureNameList.Count; i++)
            {
                pictureName = this.pictureNameList[i];
                isFileExist = File.Exists(pictureName);
                if (isFileExist==false)
                {
                    this.pictureNameList.Remove(pictureName);
                }
            }
            return this.pictureNameList;
        }
    }
}
