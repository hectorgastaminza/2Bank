/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 16/05/2016
 * Time: 00:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace ToBank.test
{
	[TestFixture]
	public class Test_ComparerFactory
	{
		[Test]
		public void Test_ID_DatosPersonales_Sexo()
		{
			// TODO: Add your test.
			IComparer comparer = ComparerFactory.CreateComparer(eRegisterId.ID_DatosPersonales_Sexo);
			Assert.IsFalse(comparer.IsMatch(""));			
			Assert.IsFalse(comparer.IsMatch("gato"));

			Assert.IsTrue(comparer.IsMatch("Masculino"));
			Assert.IsTrue(comparer.IsMatch("Femenino"));
			Assert.IsTrue(comparer.IsMatch("M"));
			Assert.IsTrue(comparer.IsMatch("F"));			
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Proceso()
		{
			// TODO: Add your test.
			IComparer comparer = ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Proceso);
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
			// TODO: Add your test.
			IComparer comparer = ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Servicio);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsTrue(comparer.IsMatch("gato"));
			Assert.IsTrue(comparer.IsMatch("1234"));
			Assert.IsTrue(comparer.IsMatch("1a3b"));
		}
		
		[Test]
		public void Test_ID_DatosBancarios_Sucursal()
		{
			// TODO: Add your test.
			IComparer comparer = ComparerFactory.CreateComparer(eRegisterId.ID_DatosBancarios_Sucursal);
			Assert.IsFalse(comparer.IsMatch(""));
			Assert.IsFalse(comparer.IsMatch("gato"));
			
			Assert.IsTrue(comparer.IsMatch("BNA"));
			Assert.IsTrue(comparer.IsMatch("ANSES"));
			Assert.IsTrue(comparer.IsMatch("BCRA"));

			Assert.IsTrue(comparer.IsMatch("0"));
			Assert.IsTrue(comparer.IsMatch("1"));
			Assert.IsTrue(comparer.IsMatch("2"));
		}
	}
}
