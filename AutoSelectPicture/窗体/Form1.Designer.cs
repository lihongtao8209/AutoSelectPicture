﻿namespace AutoSelectPicture
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.label2 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.menuStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(66, 25);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(357, 21);
        	this.textBox1.TabIndex = 1;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(11, 27);
        	this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(53, 12);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "显示文本";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(305, 518);
        	this.button1.Margin = new System.Windows.Forms.Padding(2);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(56, 18);
        	this.button1.TabIndex = 1;
        	this.button1.Text = "开始";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pictureBox1.Location = new System.Drawing.Point(9, 48);
        	this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(414, 468);
        	this.pictureBox1.TabIndex = 3;
        	this.pictureBox1.TabStop = false;
        	this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox1DragEnter);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(366, 518);
        	this.button2.Margin = new System.Windows.Forms.Padding(2);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(56, 18);
        	this.button2.TabIndex = 2;
        	this.button2.Text = "停止";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2_Click);
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.设置ToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
        	this.menuStrip1.Size = new System.Drawing.Size(431, 25);
        	this.menuStrip1.TabIndex = 4;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// 设置ToolStripMenuItem
        	// 
        	this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.路径ToolStripMenuItem});
        	this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
        	this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
        	this.设置ToolStripMenuItem.Text = "设置";
        	// 
        	// 路径ToolStripMenuItem
        	// 
        	this.路径ToolStripMenuItem.Name = "路径ToolStripMenuItem";
        	this.路径ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
        	this.路径ToolStripMenuItem.Text = "图片目录";
        	this.路径ToolStripMenuItem.Click += new System.EventHandler(this.路径ToolStripMenuItem_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(9, 522);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(29, 12);
        	this.label2.TabIndex = 5;
        	this.label2.Text = "信息";
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(431, 540);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.menuStrip1);
        	this.MainMenuStrip = this.menuStrip1;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "Form1";
        	this.Text = "测试";
        	this.Load += new System.EventHandler(this.Form1_Load);
        	this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路径ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}

