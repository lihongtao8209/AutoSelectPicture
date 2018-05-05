/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/27
 * Time: 11:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoSelectPicture.工具
{
	/// <summary>
	/// Description of WRTools.
	/// 读写文件
	/// </summary>
	public class WRTools:IToolsMessage
	{
		private string fileName="";
		public WRTools()
		{
		}
		public void SetFileName(string fileName)
		{
			this.fileName=fileName;
		}
		public byte[] ReadBytes()
		{
			FileStream fileStream = null;
			System.IO.BinaryReader binaryReader = null;
			List<byte> byteList = new List<byte>();
			byte fileByte;
			try {
				if (File.Exists(this.fileName)) {
					fileStream = new FileStream(this.fileName, FileMode.Open, FileAccess.Read);
					binaryReader = new System.IO.BinaryReader(fileStream);
                    fileByte = binaryReader.ReadByte();
                    while ((int)fileByte != -1) {
						byteList.Add(fileByte);
                        fileByte = binaryReader.ReadByte();
                    }
				} 
			} catch (Exception exception) {
				SetMessage(exception.Message,exception.StackTrace);
			}finally{
				binaryReader.Close();
				fileStream.Close();
			}
			return byteList.ToArray();
		}
		
		public void WriteBytes(byte[] byteArray){
			FileStream fileStream = null;
			System.IO.BinaryWriter binaryWriter = null;
			try{
				if (File.Exists(this.fileName)) {
					fileStream = new FileStream(this.fileName, FileMode.CreateNew, FileAccess.Write);
					binaryWriter=new System.IO.BinaryWriter(fileStream);
					binaryWriter.Write(byteArray);
				}
			}catch(Exception exception){
				SetMessage(exception.Message,exception.StackTrace);
			}finally{
				binaryWriter.Close();
				fileStream.Close();
			}
		}
	}
}
