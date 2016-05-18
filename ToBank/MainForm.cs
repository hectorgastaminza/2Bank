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
			_altasPagos = new App.Model.AltasPagos();
		}
		
		void BtnOpenExcelClick(object sender, EventArgs e)
		{
			_result = _altasPagos.OpenInput();
		}
		
		void BtnPagosClick(object sender, EventArgs e)
		{
			if(_result)
			{
				List<string> datos = _altasPagos.GetPagos();
				if(datos != null)
				{
					App.IO.FileText file = new FileText();
					file.Save(datos);
				}
			}
		}
		
		void BtnAltasClick(object sender, EventArgs e)
		{
			if(_result)
			{
				List<string> datos = _altasPagos.GetAltas();
				if(datos != null)
				{
					App.IO.FileText file = new FileText();
					file.Save(datos);
				}
			}
		}		
		
		private bool _result = false;
		private App.Model.AltasPagos _altasPagos = null;

		
		/*
		
		#region Handler_Exception

        private void HandlerException(Exception ex)
        {
            LogEvent("App: " + ex.Message + " - " + ex.StackTrace);
        }

        #endregion Handler_Exception


        #region Log

        List<App.IO.FileLog> _Logs = new List<App.IO.FileLog>();
        App.IO.FileLog _Log = new App.IO.FileLog();

        private void LogInit()
        {
            string _LogPath = LogPath();

            if (!System.IO.Directory.Exists(_LogPath))
                System.IO.Directory.CreateDirectory(_LogPath);

            _Log.Path = _LogPath;
        }

        private void tsmiOpenLogFolder_Click(object sender, EventArgs e)
        {
            if (_Log != null)
            {
                System.Diagnostics.Process.Start(LogPath());
            }
        }

        private static string LogPath()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Log\";
        }

        private void LogEvent(string myEvent)
        {
            if (_Log != null)
            {
                _Log.Log_Event(myEvent);
            }
        }

        #endregion Log		
		
		*/
	}
}
