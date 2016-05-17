/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 11:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ToBank
{
	/// <summary>
	/// Description of ComparerInterface.
	/// </summary>
	public interface IComparer
	{
		bool IsMatch(string value);
		string GetOutput();
		string GetComparer();
	}
}
