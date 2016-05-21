/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 16/05/2016
 * Time: 00:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using NUnit.Framework;
using App.Register;

namespace ToBank.test
{
	[TestFixture]
	public class Test_ComparerFactory
	{
		[Test]
		public void Test_ID_DatosBancarios_Proceso()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Proceso);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));

			Assert.IsTrue(comparer.IsMatch("Jubilados Poderdantes"));
			Assert.IsTrue(comparer.IsMatch("Uso Exclusivo del PAMI"));
			Assert.IsTrue(comparer.IsMatch("Acreditacion de Haberes"));
			Assert.IsTrue(comparer.IsMatch("Pagos a Terceros, Proveedores"));
			
			Assert.IsTrue(comparer.IsMatch("JP"));
			Assert.IsTrue(comparer.IsMatch("TR"));
			Assert.IsTrue(comparer.IsMatch("AH"));
			Assert.IsTrue(comparer.IsMatch("TF"));	
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Servicio()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Servicio);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsTrue(comparer.IsMatch("gato"));
			Assert.IsTrue(comparer.IsMatch("1234"));
			Assert.IsTrue(comparer.IsMatch("1a3b"));
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Sucursal()
		{
			// TODO: Add your test.
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Sucursal);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));

			Assert.IsTrue(comparer.IsMatch("0"));
			Assert.IsTrue(comparer.IsMatch("1"));
			Assert.IsTrue(comparer.IsMatch("2"));
			
			Assert.IsTrue(comparer.IsMatch("25"));
			Assert.IsTrue(comparer.IsMatch("481"));
			Assert.IsTrue(comparer.IsMatch("4789"));			
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Codigo_de_Agente()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Codigo_de_Agente);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));

			Assert.IsTrue(comparer.IsMatch("0"));
			Assert.IsTrue(comparer.IsMatch("13235"));
			Assert.IsTrue(comparer.IsMatch("29999"));
		}	

		[Test]
		public void Test_ID_DatosBancarios_Moneda_de_la_Cuenta()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Moneda_de_la_Cuenta);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));
			Assert.IsFalse(comparer.IsMatch("2"));

			Assert.IsTrue(comparer.IsMatch("P"));
			Assert.IsTrue(comparer.IsMatch("D"));
			Assert.IsTrue(comparer.IsMatch("3"));

			Assert.IsTrue(comparer.IsMatch("Pesos"));
			Assert.IsTrue(comparer.IsMatch("Dolares"));
			Assert.IsTrue(comparer.IsMatch("Lecop"));			
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Titularidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Titularidad);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));
			Assert.IsFalse(comparer.IsMatch("2"));

			Assert.IsTrue(comparer.IsMatch("sf"));
			Assert.IsTrue(comparer.IsMatch("sF"));
			Assert.IsTrue(comparer.IsMatch("SF"));
			Assert.IsTrue(comparer.IsMatch("OR"));

			Assert.IsTrue(comparer.IsMatch("Sola Firma"));
			Assert.IsTrue(comparer.IsMatch("Orden reciproca"));		
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Limite_de_Tarjeta()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Limite_de_Tarjeta);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));
			
			for (int i = 1; i < 17; i++) {
				Assert.IsTrue(comparer.IsMatch(i.ToString()));
			}
			
			Assert.IsFalse(comparer.IsMatch("9999"));
			
			Assert.IsTrue(comparer.IsMatch("300"));
			Assert.IsTrue(comparer.IsMatch("4000"));
			Assert.IsTrue(comparer.IsMatch("5000"));
			
			for (int i = 400; i < 3000; i += 200) 
			{
				if(i==2400)
					continue;
				Assert.IsTrue(comparer.IsMatch(i.ToString()));
			}			
		}
				
		[Test]
		public void Test_ID_DatosPersonales_Tipo_de_Persona()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Tipo_de_Persona);			
			Test_Personas_Fisicas(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Tipo_de_Persona()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Tipo_de_Persona);			
			Test_Personas_Fisicas(comparer);
		}		
		
		public void Test_Personas_Fisicas(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));
			
			Assert.IsTrue(comparer.IsMatch("F"));
		}
		
		
		[Test]
		public void Test_ID_DatosPersonales_Apellido()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Apellido);			
			Test_Nombre(comparer);
		}	
		[Test]
		public void Test_ID_DatosSdoTitular_Apellido()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Apellido);			
			Test_Nombre(comparer);
		}		

		[Test]
		public void Test_ID_DatosPersonales_Nombre()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Nombre);			
			Test_Nombre(comparer);
		}	
		[Test]
		public void Test_ID_DatosSdoTitular_Nombre()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Nombre);			
			Test_Nombre(comparer);
		}			
		
		public void Test_Nombre(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("Pedro"));
			Assert.IsTrue(comparer.IsMatch("José"));
			Assert.IsTrue(comparer.IsMatch("Garcia"));
			Assert.IsTrue(comparer.IsMatch("Ñandú"));
		}
		

		[Test]
		public void Test_ID_DatosPersonales_Tipo_de_Documento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Tipo_de_Documento);			
			Test_TipoDocumento(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Tipo_de_Documento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Tipo_de_Documento);			
			Test_TipoDocumento(comparer);
		}		
		
		public void Test_TipoDocumento(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("Cedula"));
			
			Assert.IsTrue(comparer.IsMatch("PA"));
			Assert.IsTrue(comparer.IsMatch("Pasaporte"));
			Assert.IsTrue(comparer.IsMatch("DU"));
			Assert.IsTrue(comparer.IsMatch("Documento Nacional de Identidad"));
			Assert.IsTrue(comparer.IsMatch("EX"));
			Assert.IsTrue(comparer.IsMatch("Documento Extranjero"));			
			Assert.IsTrue(comparer.IsMatch("LC"));
			Assert.IsTrue(comparer.IsMatch("Libreta Civica"));	
			Assert.IsTrue(comparer.IsMatch("LE"));
			Assert.IsTrue(comparer.IsMatch("le"));
			Assert.IsTrue(comparer.IsMatch("Libreta de Enrolamiento"));
		}	
		
		
		[Test]
		public void Test_ID_DatosPersonales_Numero_de_Documento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Numero_de_Documento);			
			Test_NumeroDocumento(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Numero_de_Documento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Numero_de_Documento);			
			Test_NumeroDocumento(comparer);
		}		
		
		public void Test_NumeroDocumento(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));			
			Assert.IsFalse(comparer.IsMatch("123"));
			
			Assert.IsTrue(comparer.IsMatch("123456"));
		}
		
		
		[Test]
		public void Test_ID_DatosPersonales_Posicion_ante_el_IVA()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Posicion_ante_el_IVA);			
			Test_Posicion_ante_el_IVA(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Posicion_ante_el_IVA()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Posicion_ante_el_IVA);			
			Test_Posicion_ante_el_IVA(comparer);
		}		
		
		public void Test_Posicion_ante_el_IVA(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));			
			Assert.IsFalse(comparer.IsMatch("123"));
			
			Assert.IsTrue(comparer.IsMatch("Consumidor Final"));
			Assert.IsTrue(comparer.IsMatch("CFI"));
			Assert.IsTrue(comparer.IsMatch("Exento"));
			Assert.IsTrue(comparer.IsMatch("EXE"));			
			Assert.IsTrue(comparer.IsMatch("Monotributo"));
			Assert.IsTrue(comparer.IsMatch("MOR"));
			Assert.IsTrue(comparer.IsMatch("No Responsable"));
			Assert.IsTrue(comparer.IsMatch("NOR"));		
			Assert.IsTrue(comparer.IsMatch("Responsable Inscripto"));
			Assert.IsTrue(comparer.IsMatch("RIN"));
			Assert.IsTrue(comparer.IsMatch("Responsable No Inscripto No Recategorizado"));
			Assert.IsTrue(comparer.IsMatch("RNI"));			
			Assert.IsTrue(comparer.IsMatch("Responsable No Inscripto Recategorizado"));
			Assert.IsTrue(comparer.IsMatch("RNR"));
		}
		

		[Test]
		public void Test_ID_DatosPersonales_Tipo_Clave_Tributaria()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Tipo_Clave_Tributaria);						
			Test_Tipo_Claver_Tributaria(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Tipo_Clave_Tributaria()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Tipo_Clave_Tributaria);						
			Test_Tipo_Claver_Tributaria(comparer);
		}		
		
		public void Test_Tipo_Claver_Tributaria(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));			
			Assert.IsFalse(comparer.IsMatch("123"));
			
			Assert.IsTrue(comparer.IsMatch("C.U.I.T"));
			Assert.IsTrue(comparer.IsMatch("1"));
			Assert.IsTrue(comparer.IsMatch("C.U.I.L."));
			Assert.IsTrue(comparer.IsMatch("2"));
			Assert.IsTrue(comparer.IsMatch("C.I.E."));
			Assert.IsTrue(comparer.IsMatch("3"));
			Assert.IsTrue(comparer.IsMatch("Juzgado"));
			Assert.IsTrue(comparer.IsMatch("6"));
			Assert.IsTrue(comparer.IsMatch("Exp."));
			Assert.IsTrue(comparer.IsMatch("7"));			
		}
		
		
		[Test]
		public void Test_ID_DatosPersonales_Fecha_de_Nacimiento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Fecha_de_Nacimiento);						
			Test_Fecha_de_Nacimiento(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Fecha_de_Nacimiento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Fecha_de_Nacimiento);						
			Test_Fecha_de_Nacimiento(comparer);
		}		

		public void Test_Fecha_de_Nacimiento(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));			
			Assert.IsFalse(comparer.IsMatch("123"));
			
			Assert.IsTrue(comparer.IsMatch(DateTime.Now.ToString()));
		}			
		
		
		[Test]
		public void Test_ID_DatosPersonales_Nacionalidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Nacionalidad);			
			Test_Nacionalidad(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Nacionalidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Nacionalidad);			
			Test_Nacionalidad(comparer);
		}		
		
		public void Test_Nacionalidad(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));			
			
			Assert.IsTrue(comparer.IsMatch("Burkina Faso"));
			Assert.IsTrue(comparer.IsMatch("Argentina"));
			Assert.IsTrue(comparer.IsMatch("AR"));
			Assert.IsTrue(comparer.IsMatch("Brasil"));
			Assert.IsTrue(comparer.IsMatch("BR"));
			Assert.IsTrue(comparer.IsMatch("Bolivia"));
			Assert.IsTrue(comparer.IsMatch("BV"));			
			Assert.IsTrue(comparer.IsMatch("Estados Unidos"));
			Assert.IsTrue(comparer.IsMatch("EU"));			
		}			
			
		
		[Test]
		public void Test_ID_DatosPersonales_Sexo()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Sexo);
			Test_Sexo(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Sexo()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Sexo);
			Test_Sexo(comparer);
		}		
		
		public void Test_Sexo(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));

			Assert.IsTrue(comparer.IsMatch("Masculino"));
			Assert.IsTrue(comparer.IsMatch("Femenino"));
			Assert.IsTrue(comparer.IsMatch("M"));
			Assert.IsTrue(comparer.IsMatch("F"));			
		}
		
		
		[Test]
		public void Test_ID_DatosPersonales_Estado_Civil()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Estado_Civil);			
			Test_Estado_Civil(comparer);
		}
		
		[Test]
		public void Test_ID_DatosSdoTitular_Estado_Civil()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DatosSdoTitular_Estado_Civil);			
			Test_Estado_Civil(comparer);
		}		
			
		public void Test_Estado_Civil(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));
			
			Assert.IsTrue(comparer.IsMatch("Casado"));
			Assert.IsTrue(comparer.IsMatch("Convivencia"));
			Assert.IsTrue(comparer.IsMatch("Divorciado"));
			Assert.IsTrue(comparer.IsMatch("Separado de Hecho"));
			Assert.IsTrue(comparer.IsMatch("Separado Legalmente"));
			Assert.IsTrue(comparer.IsMatch("Soltero"));
			Assert.IsTrue(comparer.IsMatch("Viudo"));
			Assert.IsTrue(comparer.IsMatch("C"));
			Assert.IsTrue(comparer.IsMatch("X"));
			Assert.IsTrue(comparer.IsMatch("D"));
			Assert.IsTrue(comparer.IsMatch("H"));
			Assert.IsTrue(comparer.IsMatch("L"));
			Assert.IsTrue(comparer.IsMatch("S"));
			Assert.IsTrue(comparer.IsMatch("V"));			
		}	
		
		
		[Test]
		public void Test_ID_DomPart_Calle()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Calle);			
			Test_Calle(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Calle()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Calle);			
			Test_Calle(comparer);
		}	

		[Test]
		public void Test_ID_DomPartSdoTitular_Calle()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Calle);			
			Test_Calle(comparer);
		}	

		[Test]
		public void Test_ID_DomLabSdoTitular_Calle()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Calle);			
			Test_Calle(comparer);
		}			
		
		public void Test_Calle(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("Bv. Chacabuco"));
			Assert.IsTrue(comparer.IsMatch("Av. Del Libertador"));
		}
		
		
		[Test]
		public void Test_ID_DomPart_Numero()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Numero);			
			Test_Numero(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Numero()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Numero);			
			Test_Numero(comparer);
		}		
		
		[Test]
		public void Test_ID_DomPartSdoTitular_Numero()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Numero);			
			Test_Numero(comparer);
		}
		
		[Test]
		public void Test_ID_DomLabSdoTitular_Numero()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Numero);			
			Test_Numero(comparer);
		}		
		
		public void Test_Numero(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("S/N"));
			Assert.IsTrue(comparer.IsMatch("s/n"));
			Assert.IsTrue(comparer.IsMatch("Bv. Chacabuco"));
			Assert.IsTrue(comparer.IsMatch("Av. Del Libertador"));
		}	


		[Test]
		public void Test_ID_DomPart_Piso()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Piso);			
			Test_Piso(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Piso()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Piso);			
			Test_Piso(comparer);
		}	

		[Test]
		public void Test_ID_DomPartSdoTitular_Piso()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Piso);			
			Test_Piso(comparer);
		}
		
		[Test]
		public void Test_ID_DomLabSdoTitular_Piso()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Piso);			
			Test_Piso(comparer);
		}		
		
		public void Test_Piso(App.Comparer.IComparer comparer)
		{
			Assert.IsTrue(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("S/N"));
			Assert.IsTrue(comparer.IsMatch("123"));
			Assert.IsTrue(comparer.IsMatch("Bv. Chacabuco"));
			Assert.IsTrue(comparer.IsMatch("Av. Del Libertador"));
		}


		[Test]
		public void Test_ID_DomPart_Departamento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Departamento);			
			Test_Departamento(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Departamento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Departamento);			
			Test_Departamento(comparer);
		}

		[Test]
		public void Test_ID_DomPartSdoTitular_Departamento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Departamento);			
			Test_Departamento(comparer);
		}
		
		[Test]
		public void Test_ID_DomLabSdoTitular_Departamento()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Departamento);			
			Test_Departamento(comparer);
		}		
		
		public void Test_Departamento(App.Comparer.IComparer comparer)
		{
			Assert.IsTrue(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("S/N"));
			Assert.IsTrue(comparer.IsMatch("123"));
			Assert.IsTrue(comparer.IsMatch("Bv. Chacabuco"));
			Assert.IsTrue(comparer.IsMatch("Av. Del Libertador"));
		}	


		[Test]
		public void Test_ID_DomPart_Codigo_Postal()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Codigo_Postal);			
			Test_Codigo_Postal(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Codigo_Postal()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Codigo_Postal);			
			Test_Codigo_Postal(comparer);
		}		
		
		[Test]
		public void Test_ID_DomPartSdoTitular_Codigo_Postal()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Codigo_Postal);			
			Test_Codigo_Postal(comparer);
		}
		
		[Test]
		public void Test_ID_DomLabSdoTitular_Codigo_Postal()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Codigo_Postal);			
			Test_Codigo_Postal(comparer);
		}		
		
		public void Test_Codigo_Postal(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("perro"));
			
			Assert.IsTrue(comparer.IsMatch("123"));
			Assert.IsTrue(comparer.IsMatch("4000"));
		}


		[Test]
		public void Test_ID_DomPart_Localidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Localidad);			
			Test_Localidad(comparer);
		}

		[Test]
		public void Test_ID_DomLab_Localidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Localidad);			
			Test_Localidad(comparer);
		}	

		[Test]
		public void Test_ID_DomPartSdoTitular_Localidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Localidad);			
			Test_Localidad(comparer);
		}

		[Test]
		public void Test_ID_DomLabSdoTitular_Localidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Localidad);			
			Test_Localidad(comparer);
		}		
		
		public void Test_Localidad(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("S/N"));
			Assert.IsTrue(comparer.IsMatch("123"));
			Assert.IsTrue(comparer.IsMatch("Bv. Chacabuco"));
			Assert.IsTrue(comparer.IsMatch("Av. Del Libertador"));
		}


		[Test]
		public void Test_ID_DomPart_Codigo_de_Provincia()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Codigo_de_Provincia);			
			Test_Codigo_de_Provincia(comparer);
		}
		
		[Test]
		public void ID_DomLab_Codigo_de_Provincia()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Codigo_de_Provincia);			
			Test_Codigo_de_Provincia(comparer);
		}	

		[Test]
		public void Test_ID_DomPartSdoTitular_Codigo_de_Provincia()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Codigo_de_Provincia);			
			Test_Codigo_de_Provincia(comparer);
		}
		
		[Test]
		public void ID_DomLabSdoTitular_Codigo_de_Provincia()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Codigo_de_Provincia);			
			Test_Codigo_de_Provincia(comparer);
		}		
		
		public void Test_Codigo_de_Provincia(App.Comparer.IComparer comparer)
		{
			Assert.IsFalse(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("Tucuman"));
			Assert.IsTrue(comparer.IsMatch("TC"));
			Assert.IsTrue(comparer.IsMatch("Buenos Aires"));
			Assert.IsTrue(comparer.IsMatch("BA"));
			Assert.IsTrue(comparer.IsMatch("Salta"));
			Assert.IsTrue(comparer.IsMatch("ST"));
			Assert.IsTrue(comparer.IsMatch("Jujuy"));
			Assert.IsTrue(comparer.IsMatch("JJ"));
			Assert.IsTrue(comparer.IsMatch("Santiago del Estero"));
			Assert.IsTrue(comparer.IsMatch("SE"));			
		}


		[Test]
		public void Test_ID_DomPart_Telefono()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Telefono);			
			Test_Telefono(comparer);
		}
		
		public void ID_DomLab_Telefono()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Telefono);			
			Test_Telefono(comparer);
		}		
		
		[Test]
		public void Test_ID_DomPart_Fax()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPart_Fax);			
			Test_Telefono(comparer);
		}
		
		[Test]
		public void Test_ID_DomLab_Fax()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLab_Fax);			
			Test_Telefono(comparer);
		}		
		
		[Test]
		public void Test_ID_DomPartSdoTitular_Telefono()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Telefono);			
			Test_Telefono(comparer);
		}
		
		public void ID_DomLabSdoTitular_Telefono()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Telefono);			
			Test_Telefono(comparer);
		}		
		
		[Test]
		public void Test_ID_DomPartSdoTitular_Fax()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomPartSdoTitular_Fax);			
			Test_Telefono(comparer);
		}
		
		[Test]
		public void Test_ID_DomLabSdoTitular_Fax()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_DomLabSdoTitular_Fax);			
			Test_Telefono(comparer);
		}			
		
		public void Test_Telefono(App.Comparer.IComparer comparer)
		{
			Assert.IsTrue(comparer.IsMatch(""));
			
			Assert.IsFalse(comparer.IsMatch("Tucuman"));
			Assert.IsTrue(comparer.IsMatch("(381)479856"));
			Assert.IsTrue(comparer.IsMatch("381 479856"));
			Assert.IsTrue(comparer.IsMatch("381-479856"));
			Assert.IsTrue(comparer.IsMatch("479856"));
			Assert.IsFalse(comparer.IsMatch("47985"));
		}			

		
		[Test]
		public void Test_ID_Convenio_Lecop()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_Convenio_Lecop);			
			Assert.IsTrue(comparer.IsMatch(""));
			
			Assert.IsTrue(comparer.IsMatch("Tucuman"));
			Assert.IsTrue(comparer.IsMatch("(381)479856"));
			Assert.IsTrue(comparer.IsMatch("381 479856"));
			Assert.IsTrue(comparer.IsMatch("381-479856"));
			Assert.IsTrue(comparer.IsMatch("479856"));
			Assert.IsTrue(comparer.IsMatch("47985"));
		}
		
		[Test]
		public void Test_ID_Ya_Existente()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_Ya_Existente);			
			Assert.IsFalse(comparer.IsMatch(""));		
			Assert.IsFalse(comparer.IsMatch("Tucuman"));
			Assert.IsFalse(comparer.IsMatch("47985"));
			
			Assert.IsTrue(comparer.IsMatch("S"));
			Assert.IsTrue(comparer.IsMatch("N"));
		}		
		
		[Test]
		public void Test_ID_CBU_Entidad()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Entidad);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}
		
		[Test]
		public void Test_ID_CBU_Sucursal()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Sucursal);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}		
		
		[Test]
		public void Test_ID_CBU_Verificador_B1()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Verificador_B1);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}	

		[Test]
		public void Test_ID_CBU_Tipo_Cuenta()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Tipo_Cuenta);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("Cuenta Corriente"));
			Assert.IsTrue(comparer.IsMatch("2"));
			Assert.IsTrue(comparer.IsMatch("Caja de Ahorros"));
			Assert.IsTrue(comparer.IsMatch("3"));
			Assert.IsTrue(comparer.IsMatch("Cuenta Corriente Especial"));
			Assert.IsTrue(comparer.IsMatch("4"));
		}		
		
		[Test]
		public void Test_ID_CBU_Moneda_Cuenta()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Moneda_Cuenta);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("Pesos"));
			Assert.IsTrue(comparer.IsMatch("0"));
			Assert.IsTrue(comparer.IsMatch("Dolares"));
			Assert.IsTrue(comparer.IsMatch("1"));
			Assert.IsTrue(comparer.IsMatch("Lecop"));
			Assert.IsTrue(comparer.IsMatch("3"));
		}			
		
		
		[Test]
		public void Test_ID_CBU_Numero_Cuenta()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Numero_Cuenta);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}	
		
		[Test]
		public void Test_ID_CBU_Verificador_B2()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_CBU_Verificador_B2);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}	
		
		[Test]
		public void Test_ID_Pago_Cuenta_Electronica()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_Pago_Cuenta_Electronica);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}	
		
		[Test]
		public void Test_ID_Pago_Tarjeta_titular()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_Pago_Tarjeta_titular);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}
		
		[Test]
		public void Test_ID_Pago_Tarjeta_segundo()
		{
			App.Comparer.IComparer comparer = App.Comparer.ComparerFactory.CreateComparer(eRegisterId.ID_Pago_Tarjeta_segundo);			
			Assert.IsFalse(comparer.IsMatch(""));	
			Assert.IsFalse(comparer.IsMatch("gato"));	
			
			Assert.IsTrue(comparer.IsMatch("47985"));			
		}
	}
}
