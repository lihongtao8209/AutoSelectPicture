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
using AutoSelectPicture.工具;


namespace AutoSelectPicture
{
	/// <summary>
	/// Description of IOTools.
	/// </summary>
	public class IOTools : IToolsMessage
	{
		public IOTools()
		{
		}
		//如果是文件返回:true
		public static bool isFile(string path){
			return File.Exists(path);
		}
		//如果是目录返回:true
		public static bool isDirectory(string path)
		{
			return Directory.Exists(path);
		}
	}
}
