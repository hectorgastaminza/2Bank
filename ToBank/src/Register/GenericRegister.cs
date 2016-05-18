/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 22:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using App.Comparer;

namespace App.Register
{
	public delegate bool DelegateRegisterOpcionalCheck();
	
	/// <summary>
	/// This class allows converting a excel cell to a string
	/// There are some details related with every kind of register
	/// </summary>
	public class GenericRegister
	{
		private eRegisterId _Id = eRegisterId.ID_Undefined;
		private uint _length = 0;
		private uint _start = 0;
		private uint _end = 0;
		private IComparer _Comparer = null;
		
		private char _pad = ' ';
		private eRegisterFormat _format = eRegisterFormat.PadRight;
		
		private bool _opcional = false;
		private DelegateRegisterOpcionalCheck RegisterOpcionalCheck = null;
		
		public GenericRegister(eRegisterId id, uint lenght, uint start, uint end, eRegisterFormat format, char filler)
		{
			_Id = id;
			_length = lenght;
			_start = start;
			_start = end;
			_format = format;
			_pad = filler;
			
			_Comparer = ComparerFactory.CreateComparer(_Id);
		}
		
		public void SetRegisterOpcionalCheck(DelegateRegisterOpcionalCheck check)
		{
			if(check != null)
			{
				_opcional = true;
				RegisterOpcionalCheck = check;
			}
		}
		
		public string GetValue(string input)
		{
			string retval = string.Empty;
			
			if((_Id != eRegisterId.ID_Filler) && (_Comparer.IsMatch(input)))
			{
				retval = _Comparer.GetOutput();
			}
			else
			{
				// Comprobar si es opcional, y casos de error
			}
			
			// Recortar cadena
			if(retval.Length > _length)
			{
				retval = retval.Substring(0, (int)_length);
			}
			else
			{
				if(retval.Length < _length)
				{
					char aux_pad = (retval.Length < 1) ? ' ' : _pad;
					// Padding
					if(_format == eRegisterFormat.PadRight)
						retval = retval.PadRight((int)_length, aux_pad);
					else
						retval = retval.PadLeft((int)_length, aux_pad);
				}
			}
			
			return (retval);
		}
	}
}
