/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 10:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace App.Comparer
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
			string aux_value = value.ToLower();
			string aux_input = _input.ToLower();
			string aux_output = _output.ToLower();
			
			return (string.Equals(aux_value, aux_input) || string.Equals(aux_value, aux_output));
		}
		
		public string GetOutput()
		{
			return _output;
		}
		
		public string GetComparer()
		{
			return (": " + _output + ". o :" + _input);
		}
		
		private string _input = string.Empty;
		private string _output = string.Empty;
	}
}
