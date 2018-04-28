using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoSelectPicture
{
    class AutoSelectPictureThread
    {
        private AutoResetEvent exitEvent;
        private Thread thread;
        private int waitTime;
        private Form1 form;
        private Arguments arguments;
        public Form1.InvokeUICtlTextDelegate textBoxDelegate = null;
        public Form1.InvokeUICtlTextDelegate pictureBoxDelegate = null;
        //
        public Form1.InvokeUIControlDelegate InvokeTextBoxDelegate = null;
        public Form1.InvokeUIControlDelegate InvokePictureBoxDelegate = null;
        public Form1.InvokeUIControlDelegate InvokeLabelDelegate = null;
        //
        public Form1.InvokeUIControlDelegate[] invokeUIControlDelegate=null;
        //
        Dictionary<string, Control> formControlDictionary;
        //
        public AutoSelectPictureThread(int time)
        {
            try
            {
                exitEvent = new AutoResetEvent(false);
                waitTime = time;
                thread = new Thread(new ParameterizedThreadStart(ThreadProcess));
            }
            catch(Exception exception)
            {
                string functionName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(functionName, exception);
            }

        }
        public void SetFormParameter(Form1 form, Form1.InvokeUICtlTextDelegate textBoxDelegate, Form1.InvokeUICtlTextDelegate pictureBoxDelegate)
        {
            this.form = form;
            this.textBoxDelegate = textBoxDelegate;
            this.pictureBoxDelegate = pictureBoxDelegate;
        }
        public void SetFormParameter(Form1 form, Form1.InvokeUIControlDelegate InvokeTextBoxDelegate, Form1.InvokeUIControlDelegate InvokePictureBoxDelegate)
        {
            this.form = form;
            invokeUIControlDelegate = new Form1.InvokeUIControlDelegate[] { InvokeTextBoxDelegate, InvokePictureBoxDelegate };
        }

        public void SetFormParameter(Form1 form, Form1.InvokeUIControlDelegate InvokeTextBoxDelegate, Form1.InvokeUIControlDelegate InvokePictureBoxDelegate, Form1.InvokeUIControlDelegate InvokeLabelDelegate)
        {
            this.form = form;
            invokeUIControlDelegate = new Form1.InvokeUIControlDelegate[] { InvokeTextBoxDelegate, InvokePictureBoxDelegate , InvokeLabelDelegate };
        }

        public void SetFormCtlDictionary(Dictionary<string,Control> formControlDictionary)
        {
            this.formControlDictionary = formControlDictionary;
        }
        public void SetArgument(Arguments arguments)
        {
            this.arguments = arguments;
        }
        public void Run()
        {
            thread.Start(this.arguments);
        }
        public void Stop()
        {
            /*
             * 此处只用到AutoResetEvent事件功能
             * exitEvent.Set()语句执行后,会跳转到if (exitEvent.WaitOne(waitTime))语句
             */
            exitEvent.Set();
            thread.Join();
        }
        //宿主线程函数
        private void ThreadProcess(object information)
        {
            int count = 0;
            Arguments arguments = (Arguments)information;
            //文本框控件信息
            string[] textArray = arguments.GetTextArray();
            //图片框图片路径信息
            string[] pictureFilePathArray = arguments.GetPictureFilePathArray();
            //图像数组的长度
            count = pictureFilePathArray.Length;
            //存储TextBox控件、PictureBox控件
            List<Control> formControlList = new List<Control>();
            //存储textArray pictureFilePathArray
            List<string[]> informationList = null; 
            /*
             * 遍历TextBox控件、PictureBox控件字典
             * 加入formControlList列表中
             */
            foreach (KeyValuePair<string, Control> keyValuePair in formControlDictionary)
            {
                formControlList.Add(keyValuePair.Value);
            }
            //
            string[] labelInfoArray = new string[count];
            for (int index = 0; index < count; index++)
            {
                labelInfoArray[index] = string.Format("{0}/{1} {2}",(index + 1),count, pictureFilePathArray[index]);
            }
            /*
             * 初始化 informationList
             * 分别对应:textBox1 pictureBox1 label2
             */
            informationList = new List<string[]> { textArray, pictureFilePathArray, labelInfoArray };
            //遍历所有图像
            for (int i = 0; i < count; i++)
            {
                /*1.AutoResetEvent是一个事件,此事件的流程大致如下:
                 * 1.如果没有执行exitEvent.Set(),exitEvent.WaitOne(waitTime) == false
                 * 2.因为exitEvent.WaitOne(waitTime)==false,语句段(if语句段)不会执行,一直等待exitEvent.Set() 
                 * 3.如果调用exitEvent.Set(),会立即跳转并设置WaitOne返回值为true,即:exitEvent.WaitOne(waitTime)==true
                 * 4.因为exitEvent.WaitOne(waitTime)==true,exitEvent.WaitOne(waitTime)语句段(if语句段)会执行
                 * 5.执行exitEvent.WaitOne之后,WaitOne返回值会立即变为false,即:exitEvent.WaitOne(waitTime)==false
                 * 6.执行exitEvent.WaitOne(waitTime)语句段(if语句段)之后,跳出宿主线程循环,然后立即跳转回exitEvent.Set()
                 * 7.继续执行exitEvent.Set()之后的代码
                 * 
                 * 2.AutoResetEvent WaitOne 有阻止宿主线启动的当前线的功能。
                 *  this.thread 为宿主进程
                 *  this.form.Invoke 启动的线程(在这里Invoke的是窗体线程)为当前线程
                 *  当使用了exitEvent.Set()之后,this.form.Invoke(当前线程)会被阻止
                 *  this.form.Invoke(当前线程)被阻止的表现为:窗体无法响应事件，窗体无法移动
                 *  这说明this.form.Invoke调用的窗体线程
                 *  可以通过this.form.Invoke介入已经启动的窗体线程
                 */
                if (exitEvent.WaitOne(waitTime))
                {
                    break;
                }
                /* formControlList数组存储TextBox控件、PictureBox控件
                 * 通过invokeUIControlDelegate代理数组:
                 * 1.将图片路径添加到文本框 
                 * 2.将图片路径添加到图像框
                 */
                int length = invokeUIControlDelegate.Length;
                int inforListLength = 0;
                for (int n = 0; n < length; n++)
                {
                    //如果list中的数组小于遍历下标(这里指循环变量i)那么默认取第一个(下标为0)的元素
                    inforListLength = i<informationList[n].Length?i:0;
                    this.form.Invoke(invokeUIControlDelegate[n], formControlList[n], informationList[n][inforListLength]);
                }
                Thread.Sleep(1000);
            }
            //退出循环进而退出线程，最好不要加入其它代码
        }

    }
}
