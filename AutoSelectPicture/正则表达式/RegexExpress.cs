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
		//
		private int regexOption=0;
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
		public bool IsPatternMatch(string input, string pattern, RegexOptions options)
		{
			bool isMatch = Regex.IsMatch(input, pattern, options);
			return isMatch;
		}
		//
		public bool IsPatternMatch(string input, string pattern)
		{
			bool isMatch = false;
			switch (RegexOption) {
				case IgnoreCase:
					{
						isMatch = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
                        //MatchCollection matchCollection=Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
                        //IEnumerator enumerator= matchCollection.GetEnumerator();
                        break;
					}
				default:
					{
						isMatch = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
                        break;
					}
			}

            return isMatch;
		}
	}
}
