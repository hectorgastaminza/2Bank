/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 22:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ToBank
{
	/// <summary>
	/// This class allows converting a excel cell to a string
	/// There are some details related with every kind of register
	/// </summary>
	public class GenericRegister
	{
		private eRegisterId _Id = eRegisterId.ID_Undefined;
		private string _Info = string.Empty;
		private int _Length = 0;
		private eRegisterFormat _format = eRegisterFormat.Undefined;
		private int _start = 0;
		private int _end = 0;
		private string _value = string.Empty;
		
		public GenericRegister()
		{
		}
	}
}
