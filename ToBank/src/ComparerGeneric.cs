/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 10:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ToBank
{
	/// <summary>
	/// Description of GenericComparer.
	/// </summary>
	public class ComparerGeneric : IComparer 
	{
		public ComparerGeneric(string input, string output)
		{
			_input = input;
			_output = output;
		}
		
		public bool IsMatch(string value)
		{
			return (value.Contains(_input));
		}
		
		public string GetString()
		{
			return _output;
		}
		
		private string _input = string.Empty;
		private string _output = string.Empty;
	}
}
