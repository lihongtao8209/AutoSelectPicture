using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoSelectPicture.窗体;
using AutoSelectPicture.工具;
using AutoSelectPicture.IO.层级目录下所有文件;

namespace AutoSelectPicture
{
	public partial class Form1 : Form
	{
		//代理
		public delegate void InvokeUICtlTextDelegate(string text);
		//
		public delegate void InvokeUIControlDelegate(Control control, string text);
		//显示文字
		private object[] informatioinArray = null;
		//显示图片
		private object[] pictureNames = null;

		private List<String> pictureNameList = new List<string>();
		//
		PictureDirFiles pictureDirFiles = new PictureDirFiles();
		//
		RandomFiles randomfilesd = new RandomFiles();
		//
		private Boolean isAbortSelector = false;
		//
		AutoSelectPictureThread autoSelectPictureThread = null;
		//
		Dictionary<string,Control> formControlDictionary = new Dictionary<string,Control>();
		//
		SimpleMessageBox simpleMessageBox = new SimpleMessageBox();
		public Form1()
		{
			InitializeComponent();
			InitControl();
			//Init();
			InitPicturePath("");
			InitControlDictionary();

		}

		private void InitPicturePath(string path = "")
		{
			if (path == "") {
				PictureBoxDirectory = @"D:\照片\刘亦菲\";
			} else {
				PictureBoxDirectory = path;
			}
		}

		//初始化Form窗体及Form窗体的子控件
		private void InitControl()
		{
			//窗体、图片控件充许拖动
			this.AllowDrop=true;
			this.pictureBox1.AllowDrop=true;
		}
		
		private bool Init()
		{
			bool isSuccessful = true;
			try {
				this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

				string[] randomPictureNames = pictureDirFiles.getPictureDirFiles(PictureBoxDirectory).ToArray();

				randomPictureNames = randomfilesd.getFiles(randomPictureNames);

				pictureNames = randomPictureNames;

				informatioinArray = new Object[] { "刘亦菲" };
				
			} catch (Exception exception) {
				isSuccessful = false;
				simpleMessageBox.AppendInformation(exception.Message);
				simpleMessageBox.AppendInformation(exception.StackTrace);
				simpleMessageBox.ShowMessageBox();
			}
			return isSuccessful;
		}

		private void InitControlDictionary()
		{
			//添加控件
			formControlDictionary.Add(textBox1.Name, textBox1);
			formControlDictionary.Add(pictureBox1.Name, pictureBox1);
			formControlDictionary.Add(label2.Name, label2);
		}

		private String PictureBoxDirectory {
			get;
			set;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//如果没有得到存放图片的目录，不继续执行
			if (Init() == false) {
				return;
			}
			try {
				isAbortSelector = true;
				Arguments arguments = new Arguments();
				arguments.SetTextArray(informatioinArray);
				arguments.SetPictureFilePathArray(pictureNames);
				//
				InvokeUICtlTextDelegate textBoxDelegate = new InvokeUICtlTextDelegate(SetTextBoxText);
				InvokeUICtlTextDelegate pictureBoxDelegate = new InvokeUICtlTextDelegate(SetPictureBoxImage);
				//
				InvokeUIControlDelegate invokeTextBoxDelegate = new InvokeUIControlDelegate(SetTextBoxText);
				InvokeUIControlDelegate invokePictureBoxDelegate = new InvokeUIControlDelegate(SetPictureBoxImage);
				InvokeUIControlDelegate invokeControlDelegate = new InvokeUIControlDelegate(SetControlText);
				//
				autoSelectPictureThread = new AutoSelectPictureThread(1000);
				//autoSelectPictureThread.SetFormParameter(this, textBoxDelegate, pictureBoxDelegate);
				//autoSelectPictureThread.SetFormParameter(this, invokeTextBoxDelegate, invokePictureBoxDelegate);
				//autoSelectPictureThread.SetFormParameter(this, invokeControlDelegate, invokeControlDelegate);
				autoSelectPictureThread.SetFormParameter(this, invokeControlDelegate, invokeControlDelegate, invokeControlDelegate);
				autoSelectPictureThread.SetFormCtlDictionary(formControlDictionary);
				autoSelectPictureThread.SetArgument(arguments);
				autoSelectPictureThread.Run();
			} catch (Exception exception) {
				string functionName = System.Reflection.MethodBase.GetCurrentMethod().Name;
				isAbortSelector = false;
				throw new Exception(functionName, exception);
			}
		}
		private void SetControlText(Control control, string text)
		{
			if (control.GetType().UnderlyingSystemType.Name == ControlType.TextBox) {
				TextBox textBox = (TextBox)control;
				textBox.Text = text;
			} else if (control.GetType().UnderlyingSystemType.Name == ControlType.PictureBox) {
				PictureBox pictureBox = (PictureBox)control;
				string pictureName = text;
				pictureBox.ImageLocation = pictureName;
			} else if (control.GetType().UnderlyingSystemType.Name == ControlType.Label) {
				Label label = (Label)control;
				label.Text = text;
			} else {
				string functionName = System.Reflection.MethodBase.GetCurrentMethod().Name;
				throw new Exception(functionName + " " + "未得到正确的控件类型");
			}
		}
		private void SetTextBoxText(Control control, string text)
		{
			TextBox textBox = (TextBox)control;
			textBox.Text = text;
		}

		private void SetPictureBoxImage(Control control, string pictureName)
		{
			PictureBox pictureBox = (PictureBox)control;
			pictureBox.ImageLocation = pictureName;
		}

		private void SetTextBoxText(string text)
		{
			textBox1.Text = text;
		}

		private void SetPictureBoxImage(string pictureName)
		{
			this.pictureBox1.ImageLocation = pictureName;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Visible = false;
			button2.Visible = false;
			textBox1.Enabled = false;
			this.Focus();
            /*
            Control control = label1;
            Console.WriteLine("{0},{1}",control.GetType().FullName, control.GetType().UnderlyingSystemType.Name);
			 */
            //XmlWriter xmlWriter = new XmlWriter();
            CascadeDirFiles cascadeDir = new CascadeDirFiles();
            cascadeDir.GetDirFiles(@"D:\照片");

        }

		private void Button2_Click(object sender, EventArgs e)
		{
			if (autoSelectPictureThread != null) {
				autoSelectPictureThread.Stop();
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space) {
				if (isAbortSelector == true) {
					isAbortSelector = false;
					Button2_Click(sender, e);
				} else {
					isAbortSelector = true;
					Button1_Click(sender, e);
				}
			}
		}

		private void 路径ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Setting setting = new Setting();
			DialogResult dialogResult = setting.ShowDialog();
			InitPicturePath(setting.SelectedPath);
			Init();
		}
		
		//托动文件夹、文件
		void PictureBox1DragEnter(object sender, DragEventArgs e)
		{
			string path = "";
			//文件列表
			List<string> dragfileList = new List<string>();
			//目录列表
			List<string> dragDirectoryList = new List<string>();
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				int length = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).Length;
				for (int i = 0; i < length; i++) {
					path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(i).ToString();
					//如果是文件
					if (IOTools.isFile(path)) {
						dragfileList.Add(path);
					}
					//如果是文件夹
					if (IOTools.isDirectory(path)) {
						dragDirectoryList.Add(path);
					}
				}
			} else {
				MessageBox.Show(String.Format("无法识别."));
			}
			PictureDirFiles pictureDirFiles = new PictureDirFiles();
			for(int dirIndex=0;dirIndex<dragDirectoryList.Count;dirIndex++)
			{
				List<string> dirFiles=pictureDirFiles.getPictureDirFiles(dragDirectoryList[dirIndex]);
				dragfileList.AddRange(dirFiles);
			}			
			for(int dragfileIndex=0;dragfileIndex<dragfileList.Count;dragfileIndex++)
			{

			    string subDirectory=PathTools.GetSubDirectory(dragfileList[dragfileIndex]);
			    //File.Copy(dragfileList[dragfileIndex],String.Format("{0}\\",subDirectory));
			}
		}

	}
}
