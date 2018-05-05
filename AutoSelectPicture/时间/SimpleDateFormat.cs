using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture.时间
{
    /*
     * 使用DateTime.Now.ToString()格式化
     * 格式化符号如下所示:
     * yy	年份后两位	                    DateTime.Now.ToString("yy")	    DateTime.Now.ToString("yy");   // => 16
　　 * yyyy	4位年份	                        DateTime.Now.ToString("yyyy")	DateTime.Now.ToString("yyyy"); // => 2016
　　 * MM	两位月份；单数月份前面用0填充	DateTime.Now.ToString("MM")	    DateTime.Now.ToString("MM");   // => 05
　　 * dd	日数	                        DateTime.Now.ToString("dd")	    DateTime.Now.ToString("dd");   // => 09
　　 * ddd	周几	                        DateTime.Now.ToString("ddd")	DateTime.Now.ToString("ddd");  // => 周一
　　 * dddd	星期几	                        DateTime.Now.ToString("dddd")	DateTime.Now.ToString("dddd"); // => 星期一
　　 * hh	12小时制的小时数	            DateTime.Now.ToString("hh") 	DateTime.Now.ToString("hh");   // => 01
　　 * HH	24小时制的小时数	            DateTime.Now.ToString("HH")	    DateTime.Now.ToString("HH");   // => 13
　　 * mm	分钟数	                        DateTime.Now.ToString("mm")	    DateTime.Now.ToString("mm");   // => 09
　　 * ss	秒数	                        DateTime.Now.ToString("ss")	    DateTime.Now.ToString("ss");   // => 55
　　 * ff	毫秒数前2位	                    DateTime.Now.ToString("ff")	    DateTime.Now.ToString("ff");   // => 23
　　 * fff	毫秒数前3位	                    DateTime.Now.ToString("fff")	DateTime.Now.ToString("fff");  // => 235
　　 * ffff	毫秒数前4位	                    DateTime.Now.ToString("ffff")	DateTime.Now.ToString("ffff"); // => 2350
     */
    class SimpleDateFormat
    {
        public SimpleDateFormat()
        {

        }
        static string GetCustomTimeStamp()
        {
            string customTimeStamp= string.Format("{0}{1}{2}_{3}{4}_{5}_{6}", GetYear(), GetMonth(), GettoDay(), GetHour(), GetMinute(), GetSecond(), GetMilliSecond());
            return customTimeStamp;
        }
        //年
        static string GetYear()
        {
            return DateTime.Now.ToString("yyyy");
        }
        //月
        static string GetMonth()
        {
            return DateTime.Now.ToString("MM");
        }
        //日
        static string GettoDay()
        {
            return DateTime.Now.ToString("dd");
        }
        //24小时制
        static string GetHour()
        {
            return DateTime.Now.ToString("HH");
        }
        //分
        static string GetMinute()
        {
            return DateTime.Now.ToString("mm");
        }
        //秒
        static string GetSecond()
        {
            return DateTime.Now.ToString("ss");
        }
        static string GetMilliSecond(int digit=2)
        {
            switch (digit)
            {
                case 2:
                    {
                        return DateTime.Now.ToString("ff"); 
                    }
                case 3:
                    {
                        return DateTime.Now.ToString("fff");
                    }
                case 4:
                    {
                        return DateTime.Now.ToString("ffff");
                    }
                default:
                    {
                        return DateTime.Now.ToString("ff");
                    }
            }

        }
    }
}
