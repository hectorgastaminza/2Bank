/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 11:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

 /// <summary>
 /// http://regexr.com/
 /// "JP|TR|AH|TF"
 /// http://www.dotnetperls.com/regex
 /// </summary>
 /// <param name="str"></param>
 /// <returns></returns>
namespace ToBank
{
	/// <summary>
	/// Description of RegexComparer.
	/// </summary>
	public class ComparerRegex : ComparerInterface
	{
		public ComparerRegex(string pattern)
		{
			_pattern = pattern;
		}
		
		public bool IsMatch(string value)
		{
			Match myMatch = Regex.Match(value, _pattern);
			
			if(myMatch.Success)
			{
				_output = myMatch.Value;
			}
			
			return (myMatch.Success);
		}
		
		public string GetString()
		{
			return _output;
		}
		
		private string _pattern = string.Empty;
		private string _output = string.Empty;
	}
}
