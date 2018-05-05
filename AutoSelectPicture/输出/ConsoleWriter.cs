using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture
{
    class ConsoleWriter
    {
        public ConsoleWriter()
        {
            
        }
        static public void write(string[] info)
        {
            for(int i = 0; i < info.Length; i++)
            {
                Console.WriteLine(info[i]);
            }
        }
        static public void write(List<string> info)
        {
            for(int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(info[i]);
            }
        }
        static public void write(string info)
        {
            Console.WriteLine(info);
        }
        static public void write(int info)
        {
            Console.WriteLine(info);
        }

        static public void writeLineNo(string[] info,bool startZero=true)
        { 
            for (int i = 0; i < info.Length; i++)
            {
                Console.WriteLine(startZero==true?(i+":"+info[i]):(i+1+":"+info[i]));
            }
        }
        static public void writeLineNo(List<string> info, bool startZero = true)
        {
            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine(startZero == true ? (i + ":" + info[i]) : (i + 1 + ":" + info[i]));
            }
        }
    }
}
