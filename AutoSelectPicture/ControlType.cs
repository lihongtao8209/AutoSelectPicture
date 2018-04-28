using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoSelectPicture
{
    class ControlType
    {
        const string ButtonName  = "Button";
        const string TextBoxName = "TextBox";
        const string PictureBoxName = "PictureBox";
        const string LabelName = "Label";
        public static string Button
        {
            get
            {
                return ButtonName;
            }
        }
        public static string TextBox
        {
            get
            {
                return TextBoxName;
            }
        }
        public static string PictureBox
        {
            get
            {
                return PictureBoxName;
            }
        }
        public static string Label
        {
            get
            {
                return LabelName;
            }
        }
        public static string TypeName(Control control)
        {
            return control.GetType().UnderlyingSystemType.Name;
        }
        public static string TypeFullName(Control control)
        {
            return control.GetType().FullName;
        }
    }
}
