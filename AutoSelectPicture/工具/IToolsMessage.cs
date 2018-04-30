/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/27
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AutoSelectPicture.工具
{
	/// <summary>
	/// Description of Interface1.
	/// </summary>
	public class IToolsMessage
	{
		protected static string messageInfo = "";
		protected static string GetMessage()
		{
			return messageInfo;
		}
		protected static void SetMessage(string message)
		{
            messageInfo = message;
		}
		protected static void SetMessage(string message, string messageTrace)
		{
            messageInfo = message + "\r\n" + messageTrace;
		}
	}
}
