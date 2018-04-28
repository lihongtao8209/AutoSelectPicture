using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoSelectPicture
{
	public partial class Setting : Form
	{
		//选择的目录
		private string selectedPath = "";
		//选择的图片类型
		private string selectedStyle = "";
		//写XML
		private XmlWriter xmlWriter=new XmlWriter();
		//窗体标题
		private string formText="";

		public Setting()
		{
			InitializeComponent();
		}

		private void Setting_Load(object sender, EventArgs e)
		{
			InitControl();
		}

		void InitControl()
		{
			textBox1.Enabled = false;
			textBox2.Enabled = false;
			button3.Enabled = false;
			//信息
			label_info.Text="信息";
			//扩展
			label_infoExtend.Text="扩展";
		}
		
		
		//选择目录
		private void Button3_selectedDir(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult dilogResult = folderBrowserDialog.ShowDialog();
			if (dilogResult == DialogResult.OK)
			{
				this.selectedPath = folderBrowserDialog.SelectedPath; ;
				textBox1.Text = folderBrowserDialog.SelectedPath;
			}
			button3.Enabled = false;
			this.Visible = true;
		}
		
		//写XML文件
		private void Button3_writeXml(object sender, EventArgs e)
		{
			selectedStyle = textBox1.Text;
			xmlWriter.UpdateNodes("pictureStyle",selectedStyle);
			button3.Enabled = false;
			this.Visible = true;
		}
		
		//选择目录
		private void Button_dir_Click(object sender, EventArgs e)
		{
			InitControl();
			if (formText.Contains(button_directory.Text) == false)
			{
				label_info.Text = "请选择目录";
				formText = this.Text + button_directory.Text;
				textBox1.Text="";
				textBox1.Enabled=true;
				button3.Enabled = true;
				button3.Text="选择";
			}
			else
			{
				textBox1.Enabled=true;
				textBox2.Enabled=false;
				button3.Enabled = true;
			}
			
			button3.Click -= new System.EventHandler(Button3_writeXml);
			button3.Click += new System.EventHandler(Button3_selectedDir);
			textBox1.TextChanged -= new System.EventHandler(TextBox1_pictureStyle);
			/*
			button3.Click += (object objectSender, EventArgs eventArgs) =>
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				DialogResult dilogResult = folderBrowserDialog.ShowDialog();
				if (dilogResult == DialogResult.OK)
				{
					this.selectedPath = folderBrowserDialog.SelectedPath; ;
					textBox1.Text = folderBrowserDialog.SelectedPath;
				}
				button3.Enabled = false;
				this.Visible = true;
			};
			 */
		}

		void TextBox1_pictureStyle(object sender, EventArgs e)
		{
			TextBox textBoxPictureStyle=(TextBox)sender;
			if(textBoxPictureStyle.Text.Trim()=="")
			{
				button3.Enabled=false;
			}
			else
			{
				string text=textBoxPictureStyle.Text.Trim();
				textBoxPictureStyle.Text=text;
				button3.Enabled=true;
			}
		}
		
		
		
		//选择图片类型
		private void Button_picture_Click(object sender, EventArgs e)
		{
			InitControl();
			if (formText.Contains(button_picture.Text) == false)
			{
				label_info.Text = "请设置图片类型";
				label_infoExtend.Text = label_info.Text+"举例";
				formText = this.Text + button_picture.Text;
				textBox1.Enabled=true;
				textBox1.Text="";
				textBox2.Text = "JPG|";
				button3.Enabled=true;
				button3.Text="保存";
			}
			else
			{
				textBox1.Enabled=true;
				textBox1.Enabled=true;
				button3.Enabled=true;
			}
			
			button3.Click -= new System.EventHandler(Button3_selectedDir);
			button3.Click += new System.EventHandler(Button3_writeXml);
			textBox1.TextChanged+=new EventHandler(TextBox1_pictureStyle);
			/*
			button3.Click += (Button3_writeXml) =>
			{
				selectedStyle = textBox1.Text;
				xmlWriter.UpdateNodes("pictureStyle",selectedStyle);
				button3.Enabled = false;
				this.Visible = true;
			};
			 */
		}

		public string SelectedPath
		{
			get
			{
				return this.selectedPath;
			}
		}

		public string SelectedStyle
		{
			get
			{
				return this.selectedStyle;
			}
		}
		
		//点击确定键
		private void Button_ok_Click(object sender, EventArgs e)
		{
			//如果选择的是：目录
			if(formText.Contains(button_directory.Text)==true){
				xmlWriter.UpdateNodes("pictureDir",textBox1.Text);
			}
			//如果选择的是：图片
			if(formText.Contains(button_picture.Text) == true)
			{
				selectedStyle = textBox1.Text;
				xmlWriter.UpdateNodes("pictureStyle",selectedStyle);
			}
			
			this.FormClosing += (object objectSender, FormClosingEventArgs eventArgs) =>
			{
				eventArgs.Cancel = false;
			};
			this.DialogResult = DialogResult.OK;
			this.Close();

		}
		//点击取消键
		private void Button_cnacel_Click(object sender, EventArgs e)
		{
			this.FormClosing += (object objectSender, FormClosingEventArgs eventArgs) =>
			{
				eventArgs.Cancel = false;
			};
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


	}
}
