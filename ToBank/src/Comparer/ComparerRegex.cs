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
namespace App.Comparer
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
			
			if(string.IsNullOrEmpty(value))
			{
				if(_empty)
				{
				   	retval = true;					
				}
				_output = string.Empty;
			}
			else
			{
				if((_commands != null) && (_commands.Count >0))
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
			}
			
			return (retval);
		}
		
		public string GetOutput()
		{
			return _output;
		}
		
		public string GetComparer()
		{
			System.Text.StringBuilder str_builder = new System.Text.StringBuilder();
			bool nFirst = false;
				
			if(_empty)
			{
				str_builder.Append(": ");
				nFirst = true;
			}
				
			if((_commands != null) && (_commands.Count >0))
			{
				foreach (string element in _commands) 
				{
					if(nFirst)
					{
						str_builder.Append(". o ");
					}
					else
					{
						nFirst = true;
					}
								
					str_builder.Append(": " + element);
				}
			}
				
			if(nFirst)
			{
				str_builder.Append(". o pattern: ");
			}
			str_builder.Append(_pattern + ".");
			
			return (str_builder.ToString());
		}	
		
		private string _pattern = string.Empty;
		private string _output = string.Empty;
		private bool _empty = false;
		private List<string> _commands = null;
	}
}
