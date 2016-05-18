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

namespace App.Comparer
{
	/// <summary>
	/// Description of ComparerList.
	/// </summary>
	public class ComparerList : IComparer
	{
		public ComparerList(List<ComparerGeneric> comparerGenericList)
		{
			_comparerGenericList = comparerGenericList;
		}
		
		public bool IsMatch(string value)
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
		
		public string GetOutput()
		{
			string retval = string.Empty;
			
			if(_comparerGeneric != null)				
			{
				retval = _comparerGeneric.GetOutput();
			}
			
			return (retval);
		}
		
		public string GetComparer()
		{
			string retval = string.Empty;
			
			if(_comparerGeneric != null)
			{
				retval = _comparerGeneric.GetComparer();
			}
			else
			{
				if((_comparerGenericList != null) && (_comparerGenericList.Count > 0))
				{
					System.Text.StringBuilder str_builder = new System.Text.StringBuilder();					
					bool nFirst = false;
					
					foreach (ComparerGeneric element in _comparerGenericList) 
					{
						if(nFirst) 
						{
							str_builder.Append("; o");
						}
						else
						{
							nFirst = true;
						}
							
						str_builder.Append(element.GetComparer());
					}
						
					retval = str_builder.ToString();				
				}
			}
			
			return (retval);
		}		
		
		private List<ComparerGeneric> _comparerGenericList = null;
		private ComparerGeneric _comparerGeneric = null;		
	}
}
