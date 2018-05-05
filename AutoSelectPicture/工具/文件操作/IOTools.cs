/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/27
 * Time: 10:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;
using AutoSelectPicture.工具;


namespace AutoSelectPicture
{
	/// <summary>
	/// Description of IOTools.
	/// </summary>
	public class IOTools : IToolsMessage
	{
		/*
         * 存储含有点的文件夹的文件
         * 举例:
         * File.CopyFile(@"D:\temp\file.txt\1.txt", @"D:\test\test1\test0\file.txt");
         * 由于D:\temp\file.txt\1.txt目录含有file.txt目录
         * 此时File.CopyFile会失效,可能原因是file.txt目录与file.txt文件重名
         * 此时进行如下操作
         * File.CopyFile("D:\temp\file.txt\1.txt", @"D:\test\test1\test0\file.txt");
         */
		const string temporaryStoreDirectory = "temporaryStoreDirectory";
		public IOTools()
		{
		}
		//如果是文件返回:true
		public static bool IsFile(string path)
		{
			return File.Exists(path);
		}
		//如果是目录返回:true
		public static bool IsDirectory(string path)
		{
			return Directory.Exists(path);
		}
		//建立目录
		public static bool CreateDirectory(string path)
		{
			bool isAccessRulesProtected = false;
			//判断是否受保护
			DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
			isAccessRulesProtected = directoryInfo.GetAccessControl().AreAccessRulesProtected;
			//增加读写属性
			FileIOPermission fileIOPermission = new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, path);
			fileIOPermission.Demand();
			return isAccessRulesProtected;
		}
		//建立文件
		public static bool CreateFile(string path)
		{
			int fileReadOnlyFlag = 0;
			FileStream fileStream = null;
			try {
				FileInfo fileInfo = new FileInfo(path);
				FileAttributes fileAttributes = fileInfo.Attributes;
				fileReadOnlyFlag = ((int)fileAttributes & (int)(FileAttributes.ReadOnly));
				if ((fileInfo.Attributes & FileAttributes.ReadOnly) > 0) {
					//设置可写属性
					File.SetAttributes(path, FileAttributes.Normal);
				}
				//创建文件
				fileStream = File.Create(path);
				//恢复文件原来的属性
				File.SetAttributes(path, fileAttributes | FileAttributes.ReadOnly);
				//FileSecurity fileSecurity=File.GetAccessControl(path);
			} catch (UnauthorizedAccessException exception) {
				if (fileReadOnlyFlag > 0) {
					SetMessage(String.Format("文件{0}是只读的.{1}", path, exception.Message));
				} else {
					SetMessage(String.Format("创建{0}文件失败.{1}", path, exception.Message));
				}
				throw new Exception(GetMessage(), exception);
			} catch (Exception exception) {
				throw new Exception(exception.Message, exception);
			} finally {
				fileStream.Close();
			}
			return true;
		}
		//建立目录与文件
		public static bool CreatePath(string path)
		{
			bool isDirAccessRulesProtected = false;
			//1.分析路径
			string directory = "";
			string file = "";
			directory = Path.GetDirectoryName(path);
			file = Path.GetFileName(path);
			if (file == "") {
				return false;
			}
			//2.建立目录
			isDirAccessRulesProtected = CreateDirectory(directory);
			if (isDirAccessRulesProtected == true) {
				return false;
			}
			//3.建立文件
			CreateFile(path);
			return true;
		}
		//复制文件
		public static bool CopyFile(string sourceFilePath, string destFilePath)
		{
			//目录文件
			string destDirectory = "";
			//GUID文件
			string backupFile = "";
			//源文件路径是否存在		
			bool isFile = File.Exists(sourceFilePath);
			if (isFile == true) 
			{//目标路径是文件
				destDirectory = Path.GetDirectoryName(sourceFilePath);
			} 
			else 
			{
				//目标路径不是文件
				//目标路径是否是目录
				bool isDirectory = Directory.Exists(destDirectory);
				if (isDirectory == true) 
				{//目标路径是目录
					return false;
				} 
			}
			//目标文件
			isFile = File.Exists(destFilePath);
			if (isFile == true) 
			{//目标路径是文件
				destDirectory = Path.GetDirectoryName(destFilePath);
			} 
			else 
			{
				//目标路径不是文件
				//目标路径是否是目录
				bool isDirectory = Directory.Exists(destDirectory);
				if (isDirectory == false) 
				{//目标路径不是目录
					return false;
				} 
				else 
				{//如果路径是文件夹
					destDirectory=destFilePath;
				}
			}

			//源文件名称
			string sourceFileName = Path.GetFileName(sourceFilePath);

			//创建目标目录文件名
			string targetFilePath = string.Format("{0}\\{1}", destDirectory, sourceFileName);

			string currentDirectory = Directory.GetCurrentDirectory();
			string currentDirectoryPath = string.Format("{0}\\{1}", currentDirectory, temporaryStoreDirectory);
			//如果临时文件夹不存在,创建临时文件夹
			if (Directory.Exists(currentDirectoryPath) == false) {
				Directory.CreateDirectory(currentDirectoryPath);
			}
			//创建临时文件路径
			string tempDirectoryFile = string.Format("{0}\\{1}", currentDirectoryPath, sourceFileName);
            
			if (File.Exists(tempDirectoryFile) == true) {//如果临时文件存在
				backupFile = String.Format("{0}", tempDirectoryFile + "_" + Guid.NewGuid().ToString());
				File.Move(tempDirectoryFile, backupFile);
				File.Delete(tempDirectoryFile);
			} else {//如果临时文件不存在
				File.Copy(sourceFilePath, tempDirectoryFile);
			}
			//如果目标文件已经存在
			if (File.Exists(targetFilePath)) {
				backupFile = String.Format("{0}", targetFilePath + "_" + Guid.NewGuid().ToString());
				File.Move(targetFilePath, backupFile);
				File.Delete(targetFilePath);
			} else {//如果目标文件不存在
				backupFile = tempDirectoryFile;
			}
			File.Copy(backupFile, targetFilePath);
			return true;
		}
		//设置可写
		public static bool SetNormalWriteable(string path)
		{
			int fileReadOnlyFlag = 0;
			try {
				FileInfo fileInfo = new FileInfo(path);
				FileAttributes fileAttributes = fileInfo.Attributes;
				fileReadOnlyFlag = ((int)fileAttributes & (int)(FileAttributes.ReadOnly));
				if ((fileInfo.Attributes & FileAttributes.ReadOnly) > 0) {
					//设置可写属性
					File.SetAttributes(path, FileAttributes.Normal);
				}
				//创建文件
				//恢复文件原来的属性
				File.SetAttributes(path, fileAttributes | FileAttributes.ReadOnly);
			} catch (UnauthorizedAccessException exception) {
				if (fileReadOnlyFlag > 0) {
					SetMessage(String.Format("文件{0}是只读的.{1}", path, exception.Message));
				} else {
					SetMessage(String.Format("创建{0}文件失败.{1}", path, exception.Message));
				}
				throw new Exception(GetMessage(), exception);
			} catch (Exception exception) {
				throw new Exception(exception.Message, exception);
			}
			return true;
		}
	}
}
