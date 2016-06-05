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
			
			lblVersion.Text = "V." + System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
		}
		
		void BtnOpenExcelClick(object sender, EventArgs e)
		{
			try {
				tsslStatus.Text = "";
				Result = false;
				Result = _altasPagos.OpenInput();
				
				tsslStatus.Text = "Carga de datos correcta";				
			} catch (Exception ex) {
				tsslStatus.Text = "Error en la carga de datos";
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
			            List<FileFilter> listFileFilter = new List<FileFilter>();
			            listFileFilter.Add(new FileFilter("txt", "*.txt"));						
						App.IO.FileText file = new FileText(listFileFilter);
						
						file.SaveDialog(datos, "SUELDOS.txt");
						
						tsslStatus.Text = "Guardado de datos correcto";
					}
				}
			} catch (Exception ex) {
				tsslStatus.Text = "Error en el guardado de datos";
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
			            List<FileFilter> listFileFilter = new List<FileFilter>();
			            listFileFilter.Add(new FileFilter("txt", "*.txt"));						
						App.IO.FileText file = new FileText(listFileFilter);
						
						file.SaveDialog(datos, "AMALTAS.txt");
						
						tsslStatus.Text = "Guardado de datos correcto";
					}
				}
			} catch (Exception ex) {
				tsslStatus.Text = "Error en el guardado de datos";
				_Log.HandlerException(ex);
			}				
		}	
		
		public bool Result { 
			get {return _result;} 
			set { 
				if(value != _result)
				{
					_result = value;
					btnAltas.Enabled = _result;
					btnPagos.Enabled = _result;
				}
			}
		}
		
		private bool _result = false;
		private App.Model.AltasPagos _altasPagos = null;
		private App.View.AppLog _Log = null;
	}
}
