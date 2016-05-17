/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
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
			bool result = _excel.Open();
			System.Windows.Forms.MessageBox.Show("prueba: " + result.ToString());
		}
		void BtnPagosClick(object sender, EventArgs e)
		{
	
		}
		void BtnAltasClick(object sender, EventArgs e)
		{
	
		}
		
		FileExcel _excel;
	}
}
