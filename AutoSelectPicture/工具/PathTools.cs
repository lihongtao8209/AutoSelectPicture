/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/27
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoSelectPicture.工具
{
	/// <summary>
	/// Description of PathTools.
	/// </summary>
	public class PathTools : IToolsMessage
	{
		static string PATH_ROOT = "PATH_ROOT";
		static string PATH_DIRECTORY = "PATH_DIRECTORY";
		static string PATH_FILE_NAME ="PATH_FILE_NAME";
		static string PATH_FILE_NAME_SUFFIX = "PATH_FILE_NAME_SUFFIX";
		static string PATH_FILE_NAME_PREFIX = "PATH_FILE_NAME_PREFIX";
		static List<string> pathList = new List<string>();
		static List<string> directoryList = new List<string>();
		static Dictionary<string,string> pathDictionary=new Dictionary<string,string>();
		static Dictionary<int,string> directoryDictionary=new Dictionary<int, string>();
		public PathTools()
		{
		}
		
		
		private static void Clear(){
			pathList.Clear();
			pathDictionary.Clear();
		}
		
		//获得路径的根目录信息.如果不存在返回String.Empty
		 public static string GetPathRoot(string path){
			string pathRoot=Path.GetPathRoot(path);
			return pathRoot;
		}
		
		//获得路径的完整目录信息.如果不存在返回String.Empty
		public static string GetDirectoryName(string path){
			string directoryName=Path.GetDirectoryName(path);
			return directoryName;
		}
		
		//获得路径的文件名,包含文件扩展名.如果不存在返回String.Empty
		public static string GetFileName(string path){
			string fileName=Path.GetFileName(path);
			return fileName;
		}
		
		//获得文件的扩展名.如果不存在返回String.Empty
		public static string GetFileSuffixName(string path){
			string extension = Path.GetExtension(path);
			return extension;
		}
		
		//获得文件名但不包括扩展名.如果不存在返回String.Empty
		public static string GetFilePrefixName(string path){
			string fileNameWithoutExtension="";
			fileNameWithoutExtension=Path.GetFileNameWithoutExtension(path);
			return fileNameWithoutExtension;
		}
		
		public static Dictionary<string,string> GetPathDictionary(string path)
		{

			string pathRoot=Path.GetPathRoot(path);
			string directoryName=Path.GetDirectoryName(path);
			string fileName=Path.GetFileName(path);
			string extension = Path.GetExtension(path);
			string fileNameWithoutExtension=Path.GetFileNameWithoutExtension(path);
			
			if (!pathList.Contains(pathRoot)) {
				pathList.Add(pathRoot);
			}
			if (!pathList.Contains(directoryName)) {
				pathList.Add(directoryName);
			}
			if (!pathList.Contains(extension)) {
				pathList.Add(extension);
			}
			if (!pathList.Contains(fileNameWithoutExtension)) {
				pathList.Add(fileNameWithoutExtension);
			}
//			pathList.Add(directoryName);
//			pathList.Add(fileName);
//			pathList.Add(extension);
//			pathList.Add(fileNameWithoutExtension);
			
			if (!pathDictionary.ContainsKey(PATH_ROOT)) {
				pathDictionary.Add(PATH_ROOT, pathRoot);
			}
			if (!pathDictionary.ContainsKey(PATH_DIRECTORY)) {
				pathDictionary.Add(PATH_ROOT, pathRoot);
			}
			if (!pathDictionary.ContainsKey(PATH_FILE_NAME)) {
				pathDictionary.Add(PATH_ROOT, pathRoot);
			}
			if (!pathDictionary.ContainsKey(PATH_FILE_NAME_SUFFIX)) {
				pathDictionary.Add(PATH_ROOT, pathRoot);
			}			
			if (!pathDictionary.ContainsKey(PATH_FILE_NAME_PREFIX)) {
				pathDictionary.Add(PATH_ROOT, pathRoot);
			}
			
//			pathDictionary.Add(PATH_ROOT,pathRoot);
//			pathDictionary.Add(PATH_DIRECTORY,pathRoot);
//			pathDictionary.Add(PATH_FILE_NAME,pathRoot);
//			pathDictionary.Add(PATH_FILE_NAME_SUFFIX,pathRoot);
//			pathDictionary.Add(PATH_FILE_NAME_PREFIX,pathRoot);
			
			return pathDictionary;
		}
		
		public static List<string> GetDirectoryList(string path){
			string directoryName=Path.GetDirectoryName(path);
			string[] directorys=directoryName.Split(new char[]{'\\','/'});
			directoryList.AddRange(directorys);
			return directoryList;
		}
		
		public static Dictionary<int,string> GetDirectoryDictionary(string path){
			directoryDictionary.Clear();
			string directoryName=Path.GetDirectoryName(path);
			string[] directorys=directoryName.Split(new char[]{'\\','/'});
			for(int i=0;i<directorys.Length;i++){
				directoryDictionary.Add(i+1,directorys[i]);
			}
			return directoryDictionary;
		}
		/*
		 * 获得路径的子目录
		 * 举例 
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",0);
		 * 返回值:D:\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",1);
		 * 返回值:test\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",2);
		 * 返回值:test1\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",3);
		 * 返回值:test2
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",4);
		 * 返回值:file.txt
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",0);
		 * 返回值:file.txt
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",0);
		 * 返回值:file.txt
		 */
		public static string GetSubPath(string path,int index=-1){
			string subDirectory="";
			string directoryName=Path.GetFullPath(path);
			string[] directorys=directoryName.Split(new char[]{'\\','/'});
			if((index==-1) && (directorys.Length)>0 && (index<directorys.Length)){
				subDirectory=directorys[directorys.Length-1];
			}
			if((directorys.Length)>0 && (index>=0) && (index<directorys.Length)){
				subDirectory = directorys[index];
			}
			return subDirectory;
		}
		/*
		 * 获得路径的子目录
		 * 举例 
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",0);
		 * 返回值:D:\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",1);
		 * 返回值:test\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",2);
		 * 返回值:test1\
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt",3);
		 * 返回值:test2
		 * string subDirectory=GetDirectory(@"D:\test\test1\test2\file.txt");
		 * 返回值:test2
		 */
		public static string GetSubDirectory(string path,int index=-1){
			string subDirectory="";
			try{
				string directoryName=Path.GetDirectoryName(path);
				string[] directorys=directoryName.Split(new char[]{'\\','/'});
				var directorysWithoutEmpty = from dir in directorys
					where dir!= ""
					select dir;
				directorys=directorysWithoutEmpty.ToArray();
				if((index==-1) && (directorys.Length)>0 && (index<directorys.Length)){
					subDirectory=directorys[directorys.Length-1];
				}
				if((directorys.Length)>0 && (index>=0) && (index<directorys.Length)){
					subDirectory = directorys[index];
				}
			}catch(Exception exception)
			{
				subDirectory="";
				setMessage(exception.Message,exception.StackTrace);
				string functionName = System.Reflection.MethodBase.GetCurrentMethod().Name;
				throw new Exception(functionName,exception);
			}
			return subDirectory;
		}
		
	}
}
