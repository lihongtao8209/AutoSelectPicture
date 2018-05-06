/*
 * Created by SharpDevelop.
 * User: work
 * Date: 2018/5/4
 * Time: 19:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AutoSelectPicture.正则表达式
{
	/// <summary>
	/// Description of RegexExpress.
	/// </summary>
	public class RegexExpress
	{
		//忽略大小写
		public const int IgnoreCase=(int)RegexOptions.IgnoreCase;
		public const int None=(int)RegexOptions.None;
		private int regexOption= None;
        //
        List<string> matchList = new List<string>();
        //
		public RegexExpress()
		{
			regexOption = None;
		}
		//设置属性
		public int RegexOption {
			get {
				return regexOption;
			}
			set {
				regexOption = value;
			}
		}
		//
		public string IsMatch(string input, string pattern)
		{
			bool isMatchInput = false;
            isMatchInput = IsPatternMatch(input, pattern);
			if (isMatchInput == true) {
				return input;
			} else {
				return "";
			}
		}
		//
		private bool IsPatternMatch(string input, string pattern)
		{
			bool isMatch = false;
            string outPut = "";
			switch (RegexOption) {
				case None:
					{
                        isMatch = Regex.IsMatch(input, pattern, RegexOptions.None);
                        break;
					}
				default:
					{
                        isMatch = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
                        break;
                    }
            }
            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            IEnumerator enumerator = matchCollection.GetEnumerator();
            while (enumerator.MoveNext() == true)
            {
                outPut = enumerator.Current.ToString();
                matchList.Add(outPut);
            }
            if (matchList.Count != 0)
            {
                isMatch = true;
            }
            return isMatch;
		}
	}
}
