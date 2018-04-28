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
		protected static string message = "";
		protected static string getMessage()
		{
			return message;
		}
		protected static void setMessage(string message)
		{
			message = message;
		}
		protected static void setMessage(string message, string messageTrace)
		{
			message = message + "\r\n" + messageTrace;
		}
	}
}
