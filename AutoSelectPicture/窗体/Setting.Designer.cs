namespace AutoSelectPicture
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.button_picture = new System.Windows.Forms.Button();
        	this.button_directory = new System.Windows.Forms.Button();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.button_cnacel = new System.Windows.Forms.Button();
        	this.button_ok = new System.Windows.Forms.Button();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.label_infoExtend = new System.Windows.Forms.Label();
        	this.button3 = new System.Windows.Forms.Button();
        	this.label_info = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.panel1.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.button_picture);
        	this.panel1.Controls.Add(this.button_directory);
        	this.panel1.Location = new System.Drawing.Point(6, 9);
        	this.panel1.Margin = new System.Windows.Forms.Padding(2);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(60, 200);
        	this.panel1.TabIndex = 0;
        	// 
        	// button_picture
        	// 
        	this.button_picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button_picture.Location = new System.Drawing.Point(2, 26);
        	this.button_picture.Margin = new System.Windows.Forms.Padding(2);
        	this.button_picture.Name = "button_picture";
        	this.button_picture.Size = new System.Drawing.Size(56, 22);
        	this.button_picture.TabIndex = 1;
        	this.button_picture.Text = "图片";
        	this.button_picture.UseVisualStyleBackColor = true;
        	this.button_picture.Click += new System.EventHandler(this.Button_picture_Click);
        	// 
        	// button_directory
        	// 
        	this.button_directory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button_directory.Location = new System.Drawing.Point(2, 2);
        	this.button_directory.Margin = new System.Windows.Forms.Padding(2);
        	this.button_directory.Name = "button_directory";
        	this.button_directory.Size = new System.Drawing.Size(56, 22);
        	this.button_directory.TabIndex = 0;
        	this.button_directory.Text = "目录";
        	this.button_directory.UseVisualStyleBackColor = true;
        	this.button_directory.Click += new System.EventHandler(this.Button_dir_Click);
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.button_cnacel);
        	this.panel2.Controls.Add(this.button_ok);
        	this.panel2.Controls.Add(this.textBox2);
        	this.panel2.Controls.Add(this.label_infoExtend);
        	this.panel2.Controls.Add(this.button3);
        	this.panel2.Controls.Add(this.label_info);
        	this.panel2.Controls.Add(this.textBox1);
        	this.panel2.Location = new System.Drawing.Point(75, 9);
        	this.panel2.Margin = new System.Windows.Forms.Padding(2);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(252, 199);
        	this.panel2.TabIndex = 1;
        	// 
        	// button_cnacel
        	// 
        	this.button_cnacel.Location = new System.Drawing.Point(187, 177);
        	this.button_cnacel.Margin = new System.Windows.Forms.Padding(2);
        	this.button_cnacel.Name = "button_cnacel";
        	this.button_cnacel.Size = new System.Drawing.Size(56, 18);
        	this.button_cnacel.TabIndex = 6;
        	this.button_cnacel.Text = "取消";
        	this.button_cnacel.UseVisualStyleBackColor = true;
        	this.button_cnacel.Click += new System.EventHandler(this.Button_cnacel_Click);
        	// 
        	// button_ok
        	// 
        	this.button_ok.Location = new System.Drawing.Point(126, 177);
        	this.button_ok.Margin = new System.Windows.Forms.Padding(2);
        	this.button_ok.Name = "button_ok";
        	this.button_ok.Size = new System.Drawing.Size(56, 18);
        	this.button_ok.TabIndex = 5;
        	this.button_ok.Text = "确定";
        	this.button_ok.UseVisualStyleBackColor = true;
        	this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(3, 57);
        	this.textBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox2.Multiline = true;
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(247, 116);
        	this.textBox2.TabIndex = 4;
        	// 
        	// label_infoExtend
        	// 
        	this.label_infoExtend.AutoSize = true;
        	this.label_infoExtend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.label_infoExtend.Location = new System.Drawing.Point(3, 41);
        	this.label_infoExtend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label_infoExtend.Name = "label_infoExtend";
        	this.label_infoExtend.Size = new System.Drawing.Size(31, 14);
        	this.label_infoExtend.TabIndex = 3;
        	this.label_infoExtend.Text = "扩展";
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(208, 18);
        	this.button3.Margin = new System.Windows.Forms.Padding(2);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(40, 22);
        	this.button3.TabIndex = 2;
        	this.button3.Text = "...";
        	this.button3.UseVisualStyleBackColor = true;
        	// 
        	// label_info
        	// 
        	this.label_info.AutoSize = true;
        	this.label_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.label_info.Location = new System.Drawing.Point(3, 2);
        	this.label_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label_info.Name = "label_info";
        	this.label_info.Size = new System.Drawing.Size(31, 14);
        	this.label_info.TabIndex = 1;
        	this.label_info.Text = "信息";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(3, 18);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(206, 21);
        	this.textBox1.TabIndex = 0;
        	// 
        	// Setting
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(336, 214);
        	this.Controls.Add(this.panel2);
        	this.Controls.Add(this.panel1);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Setting";
        	this.ShowIcon = false;
        	this.Text = "Setting";
        	this.Load += new System.EventHandler(this.Setting_Load);
        	this.panel1.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.panel2.PerformLayout();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_picture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_cnacel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label_infoExtend;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_directory;
    }
}