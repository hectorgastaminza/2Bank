/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 18/05/2016
 * Time: 00:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace App.Comparer
{
	/// <summary>
	/// Description of GenericComparer.
	/// </summary>
	public class ComparerDate : IComparer 
	{
		public ComparerDate()
		{
		}
		
		public bool IsMatch(string value)
		{
			return (DateTime.TryParse(value, out _date));
		}
		
		public string GetOutput()
		{
			return _date.ToString("yyyyMMdd");
		}
		
		public string GetComparer()
		{
			return (": fecha valida");
		}

		DateTime _date;
	}
}
