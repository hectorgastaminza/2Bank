/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 22:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace App.Register
{
	/// <summary>
	/// Description of eRegisterId.
	/// </summary>
	public enum eRegisterId
	{
		ID_Undefined = 0,
		/* Datos bancarios */
		ID_DatosBancarios_Proceso,
		ID_DatosBancarios_Servicio,
		ID_DatosBancarios_Sucursal,
		ID_DatosBancarios_Codigo_de_Agente,
		ID_DatosBancarios_Moneda_de_la_Cuenta,
		ID_DatosBancarios_Titularidad,
		ID_DatosBancarios_Limite_de_Tarjeta,
		/* Datos personales */
		ID_DatosPersonales_Tipo_de_Persona,
		ID_DatosPersonales_Apellido,
		ID_DatosPersonales_Nombre,
		ID_DatosPersonales_Tipo_de_Documento,
		ID_DatosPersonales_Numero_de_Documento,
		ID_DatosPersonales_Posicion_ante_el_IVA,
		ID_DatosPersonales_Tipo_Clave_Tributaria,
		ID_DatosPersonales_Numero_Clave_Tributaria,
		ID_DatosPersonales_Fecha_de_Nacimiento,
		ID_DatosPersonales_Nacionalidad,
		ID_DatosPersonales_Sexo,
		ID_DatosPersonales_Estado_Civil,
		/* Domicilio particular */
		ID_DomPart_Calle,
		ID_DomPart_Numero,
		ID_DomPart_Piso,
		ID_DomPart_Departamento,
		ID_DomPart_Codigo_Postal,
		ID_DomPart_Localidad,
		ID_DomPart_Codigo_de_Provincia,
		ID_DomPart_Telefono,
		ID_DomPart_Fax,
		/* Domicilio laboral */
		ID_DomLab_Calle,
		ID_DomLab_Numero,
		ID_DomLab_Piso,
		ID_DomLab_Departamento,
		ID_DomLab_Codigo_Postal,
		ID_DomLab_Localidad,
		ID_DomLab_Codigo_de_Provincia,
		ID_DomLab_Telefono,
		ID_DomLab_Fax,
		/* Datos 2do Titular */
		ID_DatosSdoTitular_Tipo_de_Persona,
		ID_DatosSdoTitular_Apellido,
		ID_DatosSdoTitular_Nombre,
		ID_DatosSdoTitular_Tipo_de_Documento,
		ID_DatosSdoTitular_Numero_de_Documento,
		ID_DatosSdoTitular_Posicion_ante_el_IVA,
		ID_DatosSdoTitular_Tipo_Clave_Tributaria,
		ID_DatosSdoTitular_Numero_Clave_Tributaria,
		ID_DatosSdoTitular_Fecha_de_Nacimiento,
		ID_DatosSdoTitular_Nacionalidad,
		ID_DatosSdoTitular_Sexo,
		ID_DatosSdoTitular_Estado_Civil,
		/* Domicilio Particular 2do Titular */
		ID_DomPartSdoTitular_Calle,
		ID_DomPartSdoTitular_Numero,
		ID_DomPartSdoTitular_Piso,
		ID_DomPartSdoTitular_Departamento,
		ID_DomPartSdoTitular_Codigo_Postal,
		ID_DomPartSdoTitular_Localidad,
		ID_DomPartSdoTitular_Codigo_de_Provincia,
		ID_DomPartSdoTitular_Telefono,
		ID_DomPartSdoTitular_Fax,
		/* Domicilio Laboral 2do Titular */
		ID_DomLabSdoTitular_Calle,
		ID_DomLabSdoTitular_Numero,
		ID_DomLabSdoTitular_Piso,
		ID_DomLabSdoTitular_Departamento,
		ID_DomLabSdoTitular_Codigo_Postal,
		ID_DomLabSdoTitular_Localidad,
		ID_DomLabSdoTitular_Codigo_de_Provincia,
		ID_DomLabSdoTitular_Telefono,
		ID_DomLabSdoTitular_Fax,
		/* Otros */
		ID_Convenio_Lecop,
		ID_Ya_Existente,
		ID_Filler,
		/* Pagos */
		ID_CBU_Entidad,
		ID_CBU_Sucursal,
		ID_CBU_Verificador_B1,
		ID_CBU_Tipo_Cuenta,
		ID_CBU_Moneda_Cuenta,
		ID_CBU_Numero_Cuenta,
		ID_CBU_Verificador_B2,
		ID_Pago_Cuenta_Electronica,
		ID_Pago_Tarjeta_titular,
		ID_Pago_Tarjeta_segundo,		
	}
}
