/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Schema;

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
			
			switch (id) 
			{
				/* Numeric */
				case eRegisterId.ID_DatosBancarios_Sucursal:
				case eRegisterId.ID_DatosBancarios_Código_de_Agente:
				case eRegisterId.ID_DatosPersonales_Numero_de_Documento:
				case eRegisterId.ID_DatosPersonales_Numero_Clave_Tributaria:
				case eRegisterId.ID_DatosPersonales_Fecha_de_Nacimiento:
				case eRegisterId.ID_DomPart_Codigo_Postal:
				case eRegisterId.ID_DomLab_Codigo_Postal:
				case eRegisterId.ID_DatosSdoTitular_Numero_de_Documento:
				case eRegisterId.ID_DatosSdoTitular_Numero_Clave_Tributaria:
				case eRegisterId.ID_DatosSdoTitular_Fecha_de_Nacimiento:
				case eRegisterId.ID_DomPartSdoTitular_Codigo_Postal:
				case eRegisterId.ID_DomLabSdoTitular_Codigo_Postal:
				case eRegisterId.ID_CBU_Entidad:
				case eRegisterId.ID_CBU_Sucursal:
				case eRegisterId.ID_CBU_Verificador_B1:
				case eRegisterId.ID_CBU_Numero_Cuenta:
				case eRegisterId.ID_CBU_Verificador_B2:
				case eRegisterId.ID_Pago_Cuenta_Electronica:
				case eRegisterId.ID_Pago_Tarjeta_titular:
				case eRegisterId.ID_Pago_Tarjeta_segundo:
					{
						const string pattern = @"\d*";
						ComparerRegex myComparer = new ComparerRegex(pattern);
						retval = myComparer;
					}
					break;
				/* Numeric & " " & "-" & "()" */
				case eRegisterId.ID_DomPart_Telefono:
				case eRegisterId.ID_DomPart_Fax:
				case eRegisterId.ID_DomLab_Telefono:
				case eRegisterId.ID_DomLab_Fax:
				case eRegisterId.ID_DomPartSdoTitular_Telefono:
				case eRegisterId.ID_DomPartSdoTitular_Fax:
				case eRegisterId.ID_DomLabSdoTitular_Telefono:
				case eRegisterId.ID_DomLabSdoTitular_Fax:
					{
						const string pattern = @"[0-9 |+|(|)|-]{6,}";
						ComparerRegex myComparer = new ComparerRegex(pattern);
						retval = myComparer;
					}
					break;
				
				/* AlphaNumeric */
				case eRegisterId.ID_DatosBancarios_Servicio:
				case eRegisterId.ID_DatosPersonales_Apellido:
				case eRegisterId.ID_DatosPersonales_Nombre:
				case eRegisterId.ID_DomPart_Calle:
				case eRegisterId.ID_DomPart_Localidad:
				case eRegisterId.ID_DomLab_Calle:
				case eRegisterId.ID_DomLab_Localidad:
				case eRegisterId.ID_DatosSdoTitular_Apellido:
				case eRegisterId.ID_DatosSdoTitular_Nombre:
				case eRegisterId.ID_DomPartSdoTitular_Calle:
				case eRegisterId.ID_DomPartSdoTitular_Localidad:
				case eRegisterId.ID_DomLabSdoTitular_Calle:
				case eRegisterId.ID_DomLabSdoTitular_Localidad:
					{
						const string pattern = @"[a-zA-Z0-9\s]+";
						ComparerRegex myComparer = new ComparerRegex(pattern);
						retval = myComparer;
					}
					break;
				/* AlphaNumeric & "" */	
				case eRegisterId.ID_DomPart_Piso:
				case eRegisterId.ID_DomPart_Departamento:
				case eRegisterId.ID_DomLab_Piso:
				case eRegisterId.ID_DomLab_Departamento:
				case eRegisterId.ID_DomPartSdoTitular_Piso:
				case eRegisterId.ID_DomPartSdoTitular_Departamento:
				case eRegisterId.ID_DomLabSdoTitular_Piso:
				case eRegisterId.ID_DomLabSdoTitular_Departamento:
				case eRegisterId.ID_Convenio_Lecop:
				case eRegisterId.ID_Ya_Existente:
				case eRegisterId.ID_Filler:
					{
						const string pattern = @"[a-zA-Z0-9\s]*";
						ComparerRegex myComparer = new ComparerRegex(pattern);
						retval = myComparer;
					}				
					break;
				/* AlphaNumeric: Just "F" */
				case eRegisterId.ID_DatosPersonales_Tipo_de_Persona:
				case eRegisterId.ID_DatosSdoTitular_Tipo_de_Persona:
					{
						const string pattern = @"[F]*";
						ComparerRegex myComparer = new ComparerRegex(pattern);
						retval = myComparer;				
					}
					break;
				/* AlphaNumeric & "S/N" */	
				case eRegisterId.ID_DomPart_Numero:
				case eRegisterId.ID_DomLab_Numero:
				case eRegisterId.ID_DomPartSdoTitular_Numero:
				case eRegisterId.ID_DomLabSdoTitular_Numero:
					break;
				
				/* Custom */
				case eRegisterId.ID_DatosBancarios_Proceso:
					break;
				case eRegisterId.ID_DatosBancarios_Moneda_de_la_Cuenta:
					break;
				case eRegisterId.ID_DatosBancarios_Titularidad:
					break;
				case eRegisterId.ID_DatosBancarios_Limite_de_Tarjeta:
					break;					
				case eRegisterId.ID_DatosPersonales_Tipo_de_Documento:
				case eRegisterId.ID_DatosSdoTitular_Tipo_de_Documento:
					break;
				case eRegisterId.ID_DatosPersonales_Posicion_ante_el_IVA:
				case eRegisterId.ID_DatosSdoTitular_Posicion_ante_el_IVA:
					break;
				case eRegisterId.ID_DatosPersonales_Tipo_Clave_Tributaria:
				case eRegisterId.ID_DatosSdoTitular_Tipo_Clave_Tributaria:
					break;
				case eRegisterId.ID_DatosPersonales_Nacionalidad:
				case eRegisterId.ID_DatosSdoTitular_Nacionalidad:					
					break;
				case eRegisterId.ID_DatosPersonales_Sexo:
				case eRegisterId.ID_DatosSdoTitular_Sexo:
					break;
				case eRegisterId.ID_DatosPersonales_Estado_Civil:
				case eRegisterId.ID_DatosSdoTitular_Estado_Civil:
					break;
				case eRegisterId.ID_DomPart_Codigo_de_Provincia:
				case eRegisterId.ID_DomLab_Codigo_de_Provincia:
				case eRegisterId.ID_DomPartSdoTitular_Codigo_de_Provincia:
				case eRegisterId.ID_DomLabSdoTitular_Codigo_de_Provincia:
					break;
				case eRegisterId.ID_CBU_Tipo_Cuenta:
					break;
				case eRegisterId.ID_CBU_Moneda_Cuenta:
					break;
			}
						
			return (retval);
		}		
	}
}
