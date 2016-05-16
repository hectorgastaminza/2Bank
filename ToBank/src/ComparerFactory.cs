/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 15/05/2016
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
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
				case eRegisterId.ID_DatosBancarios_Codigo_de_Agente:
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
						const string pattern = @"[0-9 +()-]{6,}";
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
						const string pattern = @"[a-zA-Z0-9 .]*";
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
						const string pattern = @"[a-zA-Z0-9 .]*";
						ComparerRegex myComparer = new ComparerRegex(pattern, true);
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
					{
						const string pattern = @"[a-zA-Z0-9 .]*";
						ComparerRegex myComparer = new ComparerRegex(pattern, true);
						retval = myComparer;				
					}
					break;
				
				/* Custom */
				case eRegisterId.ID_DatosBancarios_Proceso:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();		
						auxList.Add(new ComparerGeneric("Jubilados Poderdantes" , "JP"));
						auxList.Add(new ComparerGeneric("Uso Exclusivo del PAMI" , "TR"));
						auxList.Add(new ComparerGeneric("Acreditacion de Haberes" , "AH."));
						auxList.Add(new ComparerGeneric("Pagos a Terceros, Proveedores" , "TF"));						

						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}
					break;
					
				case eRegisterId.ID_DatosBancarios_Moneda_de_la_Cuenta:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Pesos" , "P"));
						auxList.Add(new ComparerGeneric("Dolares" , "D"));
						auxList.Add(new ComparerGeneric("Lecop" , "3"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}
					break;
					
				case eRegisterId.ID_DatosBancarios_Titularidad:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Sola Firma" , "SF"));
						auxList.Add(new ComparerGeneric("Orden reciproca" , "NR"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
				
				case eRegisterId.ID_DatosBancarios_Limite_de_Tarjeta:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();					
						auxList.Add(new ComparerGeneric("300" , "16"));
						auxList.Add(new ComparerGeneric("400" , "14"));
						auxList.Add(new ComparerGeneric("600" , "13"));
						auxList.Add(new ComparerGeneric("800" , "12"));
						auxList.Add(new ComparerGeneric("1000" , "11"));
						auxList.Add(new ComparerGeneric("1200" , "10"));
						auxList.Add(new ComparerGeneric("1400" , "9"));
						auxList.Add(new ComparerGeneric("1600" , "8"));
						auxList.Add(new ComparerGeneric("1800" , "7"));
						auxList.Add(new ComparerGeneric("2000" , "6"));
						auxList.Add(new ComparerGeneric("2200" , "5"));
						auxList.Add(new ComparerGeneric("2600" , "3"));
						auxList.Add(new ComparerGeneric("2800" , "2"));
						auxList.Add(new ComparerGeneric("3000" , "4"));
						auxList.Add(new ComparerGeneric("4000" , "15"));
						auxList.Add(new ComparerGeneric("5000" , "1"));

						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;					
					
				case eRegisterId.ID_DatosPersonales_Tipo_de_Documento:
				case eRegisterId.ID_DatosSdoTitular_Tipo_de_Documento:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Documento Nacional de Identidad" , "DU"));
						auxList.Add(new ComparerGeneric("Libreta Civica" , "LC"));
						auxList.Add(new ComparerGeneric("Libreta de Enrolamiento" , "LE"));
						auxList.Add(new ComparerGeneric("Pasaporte" , "PA"));
						auxList.Add(new ComparerGeneric("Documento Extranjero" , "EX"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Tucuman" , "TC"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Santiago del Estero" , "SE"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Jujuy" , "JJ"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Salta" , "ST"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Buenos Aires" , "BA"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Capital Federal" , "CF"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Catamarca" , "CT"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Chaco" , "CC"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Chubut" , "CH"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Cordoba" , "CD"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Corrientes" , "CR"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Entre Rios" , "ER"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Formosa" , "FM"));
						auxList.Add(new ComparerGeneric("Cedula de identidad La Pampa" , "LP"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad La Rioja" , "LR"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Mendoza" , "MZ"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Misiones" , "MS"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Neuquen" , "NQ"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Rio Negro" , "RN"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad San Juan" , "SJ"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad San Luis" , "SL"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Santa Cruz" , "SC"));
						auxList.Add(new ComparerGeneric("Cedula de Identidad Santa Fe" , "SF"));
						auxList.Add(new ComparerGeneric("Cedula de identidad Tierra del Fuego" , "TF"));
							
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_DatosPersonales_Posicion_ante_el_IVA:
				case eRegisterId.ID_DatosSdoTitular_Posicion_ante_el_IVA:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Consumidor Final" , "CFI"));
						auxList.Add(new ComparerGeneric("Exento" , "EXE"));
						auxList.Add(new ComparerGeneric("Monotributo" , "MOR"));
						auxList.Add(new ComparerGeneric("No Responsable" , "NOR"));
						auxList.Add(new ComparerGeneric("Responsable Inscripto" , "RIN"));
						auxList.Add(new ComparerGeneric("Responsable No Inscripto No Recategorizado" , "RNI"));
						auxList.Add(new ComparerGeneric("Responsable No Inscripto Recategorizado" , "RNR"));

						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_DatosPersonales_Tipo_Clave_Tributaria:
				case eRegisterId.ID_DatosSdoTitular_Tipo_Clave_Tributaria:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("C.U.I.T" , "1"));
						auxList.Add(new ComparerGeneric("C.U.I.L." , "2"));
						auxList.Add(new ComparerGeneric("C.I.E." , "3"));
						auxList.Add(new ComparerGeneric("Juzgado" , "6"));
						auxList.Add(new ComparerGeneric("Exp." , "7"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_DatosPersonales_Sexo:
				case eRegisterId.ID_DatosSdoTitular_Sexo:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Femenino" , "F"));
						auxList.Add(new ComparerGeneric("Masculino" , "M"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_DatosPersonales_Estado_Civil:
				case eRegisterId.ID_DatosSdoTitular_Estado_Civil:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Casado" , "C"));
						auxList.Add(new ComparerGeneric("Convivencia" , "X"));
						auxList.Add(new ComparerGeneric("Divorciado " , "D"));
						auxList.Add(new ComparerGeneric("Separado de Hecho" , "H"));
						auxList.Add(new ComparerGeneric("Separado Legalmente" , "L"));
						auxList.Add(new ComparerGeneric("Soltero" , "S"));
						auxList.Add(new ComparerGeneric("Viudo" , "V"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_DomPart_Codigo_de_Provincia:
				case eRegisterId.ID_DomLab_Codigo_de_Provincia:
				case eRegisterId.ID_DomPartSdoTitular_Codigo_de_Provincia:
				case eRegisterId.ID_DomLabSdoTitular_Codigo_de_Provincia:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Tucuman" , "TC"));
						auxList.Add(new ComparerGeneric("Santiago del Estero" , "SE"));
						auxList.Add(new ComparerGeneric("Salta" , "ST"));
						auxList.Add(new ComparerGeneric("Jujuy" , "JJ"));
						auxList.Add(new ComparerGeneric("Buenos Aires" , "BA"));
						auxList.Add(new ComparerGeneric("Capital Federal" , "CF"));
						auxList.Add(new ComparerGeneric("Catamarca" , "CT"));
						auxList.Add(new ComparerGeneric("Chaco" , "CC"));
						auxList.Add(new ComparerGeneric("Chubut" , "CH"));
						auxList.Add(new ComparerGeneric("Cordoba" , "CD"));
						auxList.Add(new ComparerGeneric("Corrientes" , "CR"));
						auxList.Add(new ComparerGeneric("Entre Rios" , "ER"));
						auxList.Add(new ComparerGeneric("Formosa" , "FM"));
						auxList.Add(new ComparerGeneric("La Pampa" , "LP"));
						auxList.Add(new ComparerGeneric("La Rioja" , "LR"));
						auxList.Add(new ComparerGeneric("Mendoza" , "MZ"));
						auxList.Add(new ComparerGeneric("Misiones" , "MS"));
						auxList.Add(new ComparerGeneric("Neuquen" , "NQ"));
						auxList.Add(new ComparerGeneric("Rio Negro" , "RN"));
						auxList.Add(new ComparerGeneric("San Juan" , "SJ"));
						auxList.Add(new ComparerGeneric("San Luis" , "SL"));
						auxList.Add(new ComparerGeneric("Santa Cruz" , "SC"));
						auxList.Add(new ComparerGeneric("Santa Fe" , "SF"));
						auxList.Add(new ComparerGeneric("Tierra del Fuego" , "TF"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_CBU_Tipo_Cuenta:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Cuenta Corriente" , "2"));
						auxList.Add(new ComparerGeneric("Caja de Ahorros" , "3"));
						auxList.Add(new ComparerGeneric("Cuenta Corriente Especial" , "4"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;
					
				case eRegisterId.ID_CBU_Moneda_Cuenta:
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Pesos" , "0"));
						auxList.Add(new ComparerGeneric("Dolares" , "1"));
						auxList.Add(new ComparerGeneric("Lecop" , "3"));
						
						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}					
					break;					
					
				case eRegisterId.ID_DatosPersonales_Nacionalidad:
				case eRegisterId.ID_DatosSdoTitular_Nacionalidad:					
					{
						List<ComparerGeneric> auxList = new List<ComparerGeneric>();
						
						auxList.Add(new ComparerGeneric("Argentina" , "AR"));
						auxList.Add(new ComparerGeneric("Bolivia" , "BV"));
						auxList.Add(new ComparerGeneric("Brasil " , "BR"));
						auxList.Add(new ComparerGeneric("Chile" , "CH"));
						auxList.Add(new ComparerGeneric("Colombia" , "CO"));
						auxList.Add(new ComparerGeneric("Ecuador" , "EC"));
						auxList.Add(new ComparerGeneric("Paraguay" , "PG"));
						auxList.Add(new ComparerGeneric("Peru" , "PE"));
						auxList.Add(new ComparerGeneric("Uruguay" , "UR"));
						auxList.Add(new ComparerGeneric("Venezuela" , "VN"));
						auxList.Add(new ComparerGeneric("Mexico" , "MX"));
						auxList.Add(new ComparerGeneric("Estados Unidos" , "EU"));
						auxList.Add(new ComparerGeneric("Canada" , "CA"));
						auxList.Add(new ComparerGeneric("Espana" , "EP"));
						auxList.Add(new ComparerGeneric("Italia" , "IT"));
						auxList.Add(new ComparerGeneric("Costa Rica" , "CR"));
						auxList.Add(new ComparerGeneric("Cuba" , "CU"));
						auxList.Add(new ComparerGeneric("Republica Dominicana" , "RD"));
						auxList.Add(new ComparerGeneric("El Salvador" , "ES"));
						auxList.Add(new ComparerGeneric("Guatemala" , "GT"));
						auxList.Add(new ComparerGeneric("Barbados" , "BB"));
						auxList.Add(new ComparerGeneric("Guyana" , "GY"));
						auxList.Add(new ComparerGeneric("Haiti" , "HT"));
						auxList.Add(new ComparerGeneric("Honduras" , "HD"));
						auxList.Add(new ComparerGeneric("Jamaica" , "JM"));
						auxList.Add(new ComparerGeneric("Nicaragua" , "NC"));
						auxList.Add(new ComparerGeneric("Panama" , "PM"));
						auxList.Add(new ComparerGeneric("Puerto Rico" , "PR"));
						auxList.Add(new ComparerGeneric("Trinidad y Tobago" , "TT"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Reino Unido America" , "AU"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Dinamarca America" , "AD"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Francia America" , "AF"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Paises Bajos America" , "AB"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Estados Unidos America" , "AE"));
						auxList.Add(new ComparerGeneric("Suriname" , "SE"));
						auxList.Add(new ComparerGeneric("Dominicia" , "DM"));
						auxList.Add(new ComparerGeneric("Santa Lucia" , "SN"));
						auxList.Add(new ComparerGeneric("San Vicente y Las Granadinas" , "SV"));
						auxList.Add(new ComparerGeneric("Belice" , "BE"));
						auxList.Add(new ComparerGeneric("Antigua y Barbuda" , "AY"));
						auxList.Add(new ComparerGeneric("San Cristobal  y Nevis" , "SC"));
						auxList.Add(new ComparerGeneric("Bahamas" , "BM"));
						auxList.Add(new ComparerGeneric("Grenada" , "GD"));
						auxList.Add(new ComparerGeneric("Otros Paises Americanos" , "OA"));
						auxList.Add(new ComparerGeneric("Armenia" , "AM"));
						auxList.Add(new ComparerGeneric("Azerbaidzhan" , "AZ"));
						auxList.Add(new ComparerGeneric("Georgia" , "GG"));
						auxList.Add(new ComparerGeneric("Kazajstan" , "KZ"));
						auxList.Add(new ComparerGeneric("Kirguistan" , "KG"));
						auxList.Add(new ComparerGeneric("Tayikistan" , "TY"));
						auxList.Add(new ComparerGeneric("Turkmenistan" , "TK"));
						auxList.Add(new ComparerGeneric("Uzbekistan" , "UK"));
						auxList.Add(new ComparerGeneric("Ter. Aut. Palestina Gaza y Jerico" , "SJ"));
						auxList.Add(new ComparerGeneric("Otros Paises Asiaticos" , "OS"));
						auxList.Add(new ComparerGeneric("Albania" , "AA"));
						auxList.Add(new ComparerGeneric("Andorra" , "AN"));
						auxList.Add(new ComparerGeneric("Austria" , "AI"));
						auxList.Add(new ComparerGeneric("Belgica" , "BL"));
						auxList.Add(new ComparerGeneric("Bulgaria" , "BG"));
						auxList.Add(new ComparerGeneric("Dinamarca" , "DN"));
						auxList.Add(new ComparerGeneric("Finlandia" , "FN"));
						auxList.Add(new ComparerGeneric("Francia" , "FA"));
						auxList.Add(new ComparerGeneric("Grecia" , "GR"));
						auxList.Add(new ComparerGeneric("Hungria" , "HG"));
						auxList.Add(new ComparerGeneric("Irlanda" , "IR"));
						auxList.Add(new ComparerGeneric("Islandia" , "IL"));
						auxList.Add(new ComparerGeneric("Liechtenstein" , "LC"));
						auxList.Add(new ComparerGeneric("Luxemburgo" , "LX"));
						auxList.Add(new ComparerGeneric("Malta" , "MA"));
						auxList.Add(new ComparerGeneric("Monaco" , "MN"));
						auxList.Add(new ComparerGeneric("Noruega" , "NR"));
						auxList.Add(new ComparerGeneric("Paises Bajos" , "PB"));
						auxList.Add(new ComparerGeneric("Polonia" , "PL"));
						auxList.Add(new ComparerGeneric("Portugal" , "PO"));
						auxList.Add(new ComparerGeneric("Reino Unido" , "RU"));
						auxList.Add(new ComparerGeneric("Rumania" , "RM"));
						auxList.Add(new ComparerGeneric("San Marino" , "SI"));
						auxList.Add(new ComparerGeneric("Suecia" , "SU"));
						auxList.Add(new ComparerGeneric("Suiza" , "SZ"));
						auxList.Add(new ComparerGeneric("Santa Sede" , "SS"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Reino Unido Europa" , "ER"));
						auxList.Add(new ComparerGeneric("Chipre" , "CP"));
						auxList.Add(new ComparerGeneric("Turquia" , "TQ"));
						auxList.Add(new ComparerGeneric("Rep. Fed. Alemania" , "RA"));
						auxList.Add(new ComparerGeneric("Bielorusia" , "BI"));
						auxList.Add(new ComparerGeneric("Estonia " , "EM"));
						auxList.Add(new ComparerGeneric("Letonia" , "LT"));
						auxList.Add(new ComparerGeneric("Lituania" , "LU"));
						auxList.Add(new ComparerGeneric("Moldova" , "MO"));
						auxList.Add(new ComparerGeneric("Rusia" , "RS"));
						auxList.Add(new ComparerGeneric("Ucrania" , "UC"));
						auxList.Add(new ComparerGeneric("Bosnia Herzegovina" , "BS"));
						auxList.Add(new ComparerGeneric("Croacia" , "CT"));
						auxList.Add(new ComparerGeneric("Eslovaquia" , "EQ"));
						auxList.Add(new ComparerGeneric("Eslovena" , "EL"));
						auxList.Add(new ComparerGeneric("Macedonia" , "MD"));
						auxList.Add(new ComparerGeneric("Republica Checa" , "RH"));
						auxList.Add(new ComparerGeneric("Yugoslavia- Serbia Montenegro" , "YG"));
						auxList.Add(new ComparerGeneric("Otros Paises Europeos" , "OE"));
						auxList.Add(new ComparerGeneric("Australia" , "AO"));
						auxList.Add(new ComparerGeneric("Burkina Faso" , "BK"));
						auxList.Add(new ComparerGeneric("Argelia" , "AL"));
						auxList.Add(new ComparerGeneric("Botswana" , "BW"));
						auxList.Add(new ComparerGeneric("Burundi" , "BD"));
						auxList.Add(new ComparerGeneric("Camerun" , "CM"));
						auxList.Add(new ComparerGeneric("Republica Centroafricana" , "RC"));
						auxList.Add(new ComparerGeneric("Congo" , "CG"));
						auxList.Add(new ComparerGeneric("Zaire" , "ZR"));
						auxList.Add(new ComparerGeneric("Costa de Marfil" , "CF"));
						auxList.Add(new ComparerGeneric("Chad" , "CD"));
						auxList.Add(new ComparerGeneric("Benin" , "NN"));
						auxList.Add(new ComparerGeneric("Egipto" , "EG"));
						auxList.Add(new ComparerGeneric("Gabon" , "GN"));
						auxList.Add(new ComparerGeneric("Gambia" , "GA"));
						auxList.Add(new ComparerGeneric("Ghana" , "GH"));
						auxList.Add(new ComparerGeneric("Guinea" , "GU"));
						auxList.Add(new ComparerGeneric("Guinea Ecuatorial" , "GE"));
						auxList.Add(new ComparerGeneric("Kenya" , "KY"));
						auxList.Add(new ComparerGeneric("Lesotho" , "LH"));
						auxList.Add(new ComparerGeneric("Liberia" , "LR"));
						auxList.Add(new ComparerGeneric("Libia" , "LB"));
						auxList.Add(new ComparerGeneric("Madagascar" , "MG"));
						auxList.Add(new ComparerGeneric("Malawi" , "MW"));
						auxList.Add(new ComparerGeneric("Mali" , "ML"));
						auxList.Add(new ComparerGeneric("Marruecos" , "MR"));
						auxList.Add(new ComparerGeneric("Mauricio" , "MC"));
						auxList.Add(new ComparerGeneric("Mauritania" , "MT"));
						auxList.Add(new ComparerGeneric("Nigeria" , "NG"));
						auxList.Add(new ComparerGeneric("Zimbabwe" , "ZW"));
						auxList.Add(new ComparerGeneric("Rwanda" , "RW"));
						auxList.Add(new ComparerGeneric("Senegal" , "SG"));
						auxList.Add(new ComparerGeneric("Sierra Leona" , "SL"));
						auxList.Add(new ComparerGeneric("Somalia" , "SM"));
						auxList.Add(new ComparerGeneric("Swazilandia" , "SW"));
						auxList.Add(new ComparerGeneric("Sudan" , "SD"));
						auxList.Add(new ComparerGeneric("Tanzania" , "TA"));
						auxList.Add(new ComparerGeneric("Tongo" , "TO"));
						auxList.Add(new ComparerGeneric("Tunez " , "TZ"));
						auxList.Add(new ComparerGeneric("Uganda" , "UG"));
						auxList.Add(new ComparerGeneric("Zambia" , "ZA"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Reino Unido Africa" , "FR"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Espana Africa" , "FE"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Francia Africa" , "FF"));
						auxList.Add(new ComparerGeneric("Angola" , "AG"));
						auxList.Add(new ComparerGeneric("Cabo Verde" , "CV"));
						auxList.Add(new ComparerGeneric("Mozambique" , "MZ"));
						auxList.Add(new ComparerGeneric("Seychelles" , "SY"));
						auxList.Add(new ComparerGeneric("Djibouti" , "DJ"));
						auxList.Add(new ComparerGeneric("Comoras" , "CS"));
						auxList.Add(new ComparerGeneric("Guinea Bissau" , "GB"));
						auxList.Add(new ComparerGeneric("Santo Tome y Principe" , "ST"));
						auxList.Add(new ComparerGeneric("Namibia" , "MB"));
						auxList.Add(new ComparerGeneric("Sudafrica" , "SF"));
						auxList.Add(new ComparerGeneric("Eritorea" , "EN"));
						auxList.Add(new ComparerGeneric("Etiopia" , "ET"));
						auxList.Add(new ComparerGeneric("Otros Paises Africanos" , "OF"));
						auxList.Add(new ComparerGeneric("Afganistan" , "AT"));
						auxList.Add(new ComparerGeneric("Arabia Saudita" , "AS"));
						auxList.Add(new ComparerGeneric("Bahrein" , "BH"));
						auxList.Add(new ComparerGeneric("Myanmar ( Ex Birmania) " , "MY"));
						auxList.Add(new ComparerGeneric("Butan" , "BT"));
						auxList.Add(new ComparerGeneric("Cambodya" , "DY"));
						auxList.Add(new ComparerGeneric("Sri Lanka" , "SK"));
						auxList.Add(new ComparerGeneric("Corea Democratica" , "CE"));
						auxList.Add(new ComparerGeneric("Corea Republicana" , "CC"));
						auxList.Add(new ComparerGeneric("China" , "CI"));
						auxList.Add(new ComparerGeneric("Filipinas" , "FL"));
						auxList.Add(new ComparerGeneric("Taiwan" , "TW"));
						auxList.Add(new ComparerGeneric("India" , "IN"));
						auxList.Add(new ComparerGeneric("Indonesia" , "ID"));
						auxList.Add(new ComparerGeneric("Iraq" , "IQ"));
						auxList.Add(new ComparerGeneric("Iran" , "II"));
						auxList.Add(new ComparerGeneric("Israel" , "IS"));
						auxList.Add(new ComparerGeneric("Japon" , "JP"));
						auxList.Add(new ComparerGeneric("Jordania" , "JD"));
						auxList.Add(new ComparerGeneric("Qatar" , "QA"));
						auxList.Add(new ComparerGeneric("Kuwait" , "KW"));
						auxList.Add(new ComparerGeneric("Laos" , "LO"));
						auxList.Add(new ComparerGeneric("Libano" , "LI"));
						auxList.Add(new ComparerGeneric("Malasia" , "MS"));
						auxList.Add(new ComparerGeneric("Maldivas" , "MV"));
						auxList.Add(new ComparerGeneric("Oman" , "OM"));
						auxList.Add(new ComparerGeneric("Mongolia" , "MI"));
						auxList.Add(new ComparerGeneric("Nepal" , "NP"));
						auxList.Add(new ComparerGeneric("Emiratos Arabes Unidos" , "EA"));
						auxList.Add(new ComparerGeneric("Paquistan" , "PQ"));
						auxList.Add(new ComparerGeneric("Singapur" , "SR"));
						auxList.Add(new ComparerGeneric("Siria" , "SA"));
						auxList.Add(new ComparerGeneric("Tailandia" , "TL"));
						auxList.Add(new ComparerGeneric("Vietnam" , "VT"));
						auxList.Add(new ComparerGeneric("Hong Kong" , "HK"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Portugal Asia" , "SP"));
						auxList.Add(new ComparerGeneric("Bangladesh" , "BA"));
						auxList.Add(new ComparerGeneric("Brunei" , "BN"));
						auxList.Add(new ComparerGeneric("Republica de Yemen" , "RY"));
						auxList.Add(new ComparerGeneric("Nauru" , "UN"));
						auxList.Add(new ComparerGeneric("Nueva Zelanda" , "NZ"));
						auxList.Add(new ComparerGeneric("Vanuatu" , "VA"));
						auxList.Add(new ComparerGeneric("Samoa Occidental" , "SO"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Australia Oceania" , "OU"));
						auxList.Add(new ComparerGeneric("Ter. Vinc. Reino Unido Oceania" , "OR"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Francia Oceania" , "OC"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. Nueva Zelanda Oceania" , "OZ"));
						auxList.Add(new ComparerGeneric("Terc. Vinc. EE.UU. En Oceania" , "OT"));
						auxList.Add(new ComparerGeneric("Fiji" , "FJ"));
						auxList.Add(new ComparerGeneric("Papua Nueva Guinea" , "PU"));
						auxList.Add(new ComparerGeneric("Kiribati" , "KB"));
						auxList.Add(new ComparerGeneric("Micronesia Estados Federados" , "MF"));
						auxList.Add(new ComparerGeneric("Palau" , "PA"));
						auxList.Add(new ComparerGeneric("Tuvalu" , "TU"));
						auxList.Add(new ComparerGeneric("Islas Salomon" , "IO"));
						auxList.Add(new ComparerGeneric("Tonga" , "TG"));
						auxList.Add(new ComparerGeneric("Islas Marshall" , "IH"));
						auxList.Add(new ComparerGeneric("Islas Marianas" , "IM"));
						auxList.Add(new ComparerGeneric("Otros Paises de Oceania" , "OO"));

						ComparerList myComparer = new ComparerList(auxList);
						retval = myComparer;
					}
					break;										
			}
						
			return (retval);
		}		
	}
}
