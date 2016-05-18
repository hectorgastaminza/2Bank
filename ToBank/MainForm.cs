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
using System.Collections.Generic;
using App.IO;


namespace App
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
			_Log = new App.View.AppLog();
			_altasPagos = new App.Model.AltasPagos();
		}
		
		void BtnOpenExcelClick(object sender, EventArgs e)
		{
			try {
				_result = _altasPagos.OpenInput();
			} catch (Exception ex) {
				
				_Log.HandlerException(ex);
			}
		}
		
		void BtnPagosClick(object sender, EventArgs e)
		{
			try {
				if(_result)
				{
					List<string> datos = _altasPagos.GetPagos();
					if(datos != null)
					{
						App.IO.FileText file = new FileText();
						file.Save(datos);
					}
				}
			} catch (Exception ex) {
				
				_Log.HandlerException(ex);
			}			
		}
		
		void BtnAltasClick(object sender, EventArgs e)
		{
			try {			
				if(_result)
				{
					List<string> datos = _altasPagos.GetAltas();
					if(datos != null)
					{
						App.IO.FileText file = new FileText();
						file.Save(datos);
					}
				}
			} catch (Exception ex) {
				
				_Log.HandlerException(ex);
			}				
		}	
		
		private bool _result = false;
		private App.Model.AltasPagos _altasPagos = null;
		private App.View.AppLog _Log = null;
	}
}
