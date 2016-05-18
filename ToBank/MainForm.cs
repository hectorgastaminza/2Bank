/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using App.IO;

namespace ToBank
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnOpenExcelClick(object sender, EventArgs e)
		{
			_excel = new FileExcel();
			_result = _excel.Open();
		}
		
		void BtnPagosClick(object sender, EventArgs e)
		{
			if(_result)
			{
				GetRow(null, _excel.GetSheet(2), 10);
			}
		}
		
		void BtnAltasClick(object sender, EventArgs e)
		{
			if(_result)
			{
				GetAltas();
			}
		}
		
		
		private List<string> GetAltas()
		{
			List<string> retval = new List<string>();
			List<GenericRegister> _registers = new List<GenericRegister>();
			
			/* Genero la lista de registros de alta */
			/* Datos bancarios */
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Proceso, 2, 1, 2, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Servicio, 4, 3, 6, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Sucursal, 4, 7, 10, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Codigo_de_Agente, 20, 11, 30, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Moneda_de_la_Cuenta, 1, 31, 31, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Titularidad, 2, 32, 33, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosBancarios_Limite_de_Tarjeta, 2, 34, 35, eRegisterFormat.PadLeft, '0'));
			/* Datos personales */
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Tipo_de_Persona, 1, 36, 36, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Apellido, 40, 37, 76, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Nombre, 40, 77, 116, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Tipo_de_Documento, 2, 117, 118, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Numero_de_Documento, 8, 119, 126, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Posicion_ante_el_IVA, 3, 127, 129, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Tipo_Clave_Tributaria, 1, 130, 130, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Numero_Clave_Tributaria, 11, 131, 141, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Fecha_de_Nacimiento, 8, 142, 149, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Nacionalidad, 2, 150, 151, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Sexo, 1, 152, 152, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosPersonales_Estado_Civil, 1, 153, 153, eRegisterFormat.PadRight, ' '));
			/* Domicilio Particular */
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Calle, 30, 154, 183, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Numero, 6, 184, 189, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Piso, 3, 190, 192, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Departamento, 4, 193, 196, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Codigo_Postal, 5, 197, 201, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Localidad, 20, 202, 221, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Codigo_de_Provincia, 2, 222, 223, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Telefono, 15, 224, 238, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPart_Fax, 15, 239, 253, eRegisterFormat.PadRight, ' '));
			/* Domicilio Laboral */
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Calle, 30, 254, 283, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Numero, 6, 284, 289, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Piso, 3, 290, 292, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Departamento, 4, 293, 296, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Codigo_Postal, 5, 297, 301, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Localidad, 20, 302, 321, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Codigo_de_Provincia, 2, 322, 323, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Telefono, 15, 324, 338, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLab_Fax, 15, 339, 343, eRegisterFormat.PadRight, ' '));
			/* Datos 2do Titular */
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Tipo_de_Persona, 1, 354, 354, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Apellido, 40, 355, 394, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Nombre, 40, 395, 434, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Tipo_de_Documento, 2, 435, 436, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Numero_de_Documento, 8, 437, 444, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Posicion_ante_el_IVA, 3, 445, 447, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Tipo_Clave_Tributaria, 1, 448, 448, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Numero_Clave_Tributaria, 11, 449, 459, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Fecha_de_Nacimiento, 8, 460, 467, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Nacionalidad, 2, 468, 469, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Sexo, 1, 470, 470, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DatosSdoTitular_Estado_Civil, 1, 471, 471, eRegisterFormat.PadRight, ' '));
			/* Domicilio Particular 2do Titular */
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Calle, 30, 472, 501, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Numero, 6, 502, 507, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Piso, 3, 508, 510, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Departamento, 4, 511, 514, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Codigo_Postal, 5, 514, 519, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Localidad, 20, 520, 539, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Codigo_de_Provincia, 2, 540, 541, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Telefono, 15, 542, 556, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomPartSdoTitular_Fax, 15, 557, 571, eRegisterFormat.PadRight, ' '));
			/* Domicilio Laboral 2do Titular */
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Calle, 30, 572, 601, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Numero, 6, 602, 607, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Piso, 3, 608, 610, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Departamento, 4, 611, 614, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Codigo_Postal, 5, 615, 619, eRegisterFormat.PadLeft, '0'));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Localidad, 20, 620, 639, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Codigo_de_Provincia, 2, 640, 641, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Telefono, 15, 642, 656, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_DomLabSdoTitular_Fax, 15, 657, 671, eRegisterFormat.PadRight, ' '));
			/* Otros */
			_registers.Add(new GenericRegister(eRegisterId.ID_Filler, 23, 672, 694, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_Convenio_Lecop, 4, 695, 698, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_Filler, 1, 699, 699, eRegisterFormat.PadRight, ' '));
			_registers.Add(new GenericRegister(eRegisterId.ID_Ya_Existente, 1, 700, 700, eRegisterFormat.PadRight, ' '));
			
			/* Obtengo las filas */
			object[,] sheet = _excel.GetSheet(1);
			if(sheet.Rank >1)
			{			
				int rows_max = (sheet.GetLength(0) < 100) ? sheet.GetLength(0) : 100;
				
				for (int i = 10; i < rows_max; i++) {
					string aux = GetRow(_registers, sheet, i);
					retval.Add(aux);
				}
			}
			
			return (retval);
		}
		
		private string GetRow(List<GenericRegister> registers, object[,] sheet, int row)
		{
			StringBuilder strBuilder = new StringBuilder();
			
			if(sheet.Rank >1)
			{
				if(sheet.GetLength(0) > row)
				{
					int columns = (sheet.GetLength(1) > registers.Count) ? registers.Count : sheet.GetLength(1);
					
					for (int i = 0; i < columns; i++) {
						string aux = Convert.ToString(sheet[row,(i+1)]);
						if((i == 0) && (string.IsNullOrEmpty(aux)))
							break;
						strBuilder.Append(registers[i].GetValue(aux));
					}
				}
			}

			return (strBuilder.ToString());
		}
		
		bool _result;
		private FileExcel _excel;
	}
}
