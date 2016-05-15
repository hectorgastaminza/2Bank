/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 11:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ToBank
{
	/// <summary>
	/// Description of ComparerList.
	/// </summary>
	public class ComparerList : ComparerInterface
	{
		public ComparerList(List<ComparerGeneric> comparerGenericList)
		{
			_comparerGenericList = comparerGenericList;
		}
		
		bool IsMatch(string value)
		{
			bool retval = false;
			
			foreach (ComparerGeneric element in _comparerGenericList) 
			{
				if(element.IsMatch(value))
				{
					retval = true;
					_comparerGeneric = element;
					break;
				}
			}
			
			return (retval);
		}
		
		string GetString()
		{
			string retval = string.Empty;
			
			if(_comparerGeneric != null)				
			{
				retval = _comparerGeneric.GetString();
			}
			
			return (retval);
		}
		
		private List<ComparerGeneric> _comparerGenericList = null;
		private ComparerGeneric _comparerGeneric = null;		
	}
}
