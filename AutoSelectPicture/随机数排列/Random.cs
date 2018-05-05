using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSelectPicture
{
    class RandomFiles
    {
        private List<string> randomFilesList = null;
        public string[] getFiles(string[] files)
        {
            Random random = new Random();
            List<int> numberArray = new List<int>();
            randomFilesList = new List<string>();
            while (numberArray.Count < files.Length)
            {
                int number = random.Next(files.Length);
                if(numberArray.Contains(number)==false)
                {
                    numberArray.Add(number);
                }                
            }
            for(int i=0;i< numberArray.Count; i++)
            {
                int index = numberArray[i];
                randomFilesList.Add(files[index]);
            }
            return randomFilesList.ToArray();
        }
    }
}
