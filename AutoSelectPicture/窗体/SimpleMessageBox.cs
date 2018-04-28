/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/4/26
 * Time: 19:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSelectPicture.窗体
{
	/// <summary>
	/// Description of SimpleMessageBox
	/// </summary>
	public partial class SimpleMessageBox : Form
	{
		string messagBoxInformation="";
		public SimpleMessageBox()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void SimpleMessageBoxMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(this.WindowState==System.Windows.Forms.FormWindowState.Minimized)
			{
				this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			}
			
			if(this.WindowState==System.Windows.Forms.FormWindowState.Maximized)
			{
				this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			}
		}
		public void setInformation(string information)
		{
			this.textBox1.Text=information;
		}
		public string getInformation()
		{
			return this.textBox1.Text;
		}
		public void SetMessagBoxInformation(string information)
		{
			this.messagBoxInformation=information;
		}
		public string GetMessagBoxInformation()
		{
			return this.messagBoxInformation;
		}
		public void AppendInformation(string information)
		{
			messagBoxInformation+=information+"\r\n";
		}
		//显示对话框
		public void ShowMessageBox(string infomation)
		{
			setInformation(infomation);
			this.ShowDialog();
		}
		//显示对话框
		public void ShowMessageBox()
		{
			setInformation(messagBoxInformation);
			this.ShowDialog();
			setInformation("");
		}
	}
}
