/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ToBank
{
	/// <summary>
	/// Description of ComparerFactory.
	/// </summary>
	public class ComparerFactory
	{
		public IComparer CreateComparer(eRegisterId id)
		{
			IComparer retval = null;
			
			
			
			return (retval);
		}
		
		private eRegisterFormat GetFormat(eRegisterId id)
		{
			switch (id) 
			{
				case eRegisterId.ID_Convenio_Lecop:					
					break;
			}
		}
	}
}
