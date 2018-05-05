using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture
{
    class Arguments
    {
        private string[] textArray = null;
        private string[] pictureFilePathArray=null;
        public void SetTextArray(object[] value)
        {
            textArray = new string[value.Length];
            for(int i = 0; i < value.Length; i++)
            {
                textArray[i] = (string)value[i];
            }       
        }
        public string[] GetTextArray()
        {
            return textArray;
        }
        public void SetPictureFilePathArray(object[] value)
        {
            pictureFilePathArray = new string[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                pictureFilePathArray[i] = (string)value[i];
            }
        }
        public string[] GetPictureFilePathArray()
        {
            return pictureFilePathArray;
        }
    }
}
