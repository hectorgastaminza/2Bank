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
using System.Collections.Generic;

 /// <summary>
 /// http://regexr.com/
 /// "JP|TR|AH|TF"
 /// http://www.dotnetperls.com/regex
 /// Numeric : @"[1-9][0-9]*|0"
 /// AlphaNumeric : @"[a-zA-Z0-9\s]*"
 /// </summary>
 /// <param name="str"></param>
 /// <returns></returns>
namespace ToBank
{
	/// <summary>
	/// Description of RegexComparer.
	/// </summary>
	public class ComparerRegex : IComparer
	{
		public ComparerRegex(String pattern, bool empty, List<string> commands)
			:this(pattern,empty)
		{
			_commands = commands;
		}
		
		public ComparerRegex(string pattern, bool empty)
			:this(pattern)
		{
			_empty = empty;
		}
		
		public ComparerRegex(string pattern)
		{
			_pattern = pattern;
		}
		
		public bool IsMatch(string value)
		{
			bool retval = false;
			
			if((_empty) && (string.IsNullOrEmpty(value)))
			{
			   	_output = string.Empty;
			   	retval = true;
			}
			
			if(!retval && (_commands != null) && (_commands.Count >0))
			{
				foreach (string element in _commands) 
				{
					if(value.Contains(element))
					{
						_output = element;
						retval = true;
					}
				}
			}
			
			if(!retval)
			{
				Match myMatch = Regex.Match(value, _pattern);
				
				if(myMatch.Success)
				{
					_output = myMatch.Value;
				}
				
				retval = myMatch.Success;
			}
			
			return (retval);
		}
		
		public string GetString()
		{
			return _output;
		}
		
		private string _pattern = string.Empty;
		private string _output = string.Empty;
		private bool _empty = false;
		private List<string> _commands = null;
	}
}
