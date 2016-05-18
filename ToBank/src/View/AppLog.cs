/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 18/05/2016
 * Time: 19:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace App.View
{
	/// <summary>
	/// Description of AppLog.
	/// </summary>
	public class AppLog
	{
		public AppLog()
		{
			_Log = new App.IO.FileLog();
			
			LogInit();
		}

		#region Handler_Exception

        public void HandlerException(Exception ex)
        {
            LogEvent("App: " + ex.Message + " - " + ex.StackTrace);
        }

        #endregion Handler_Exception

        #region Log

        private void LogInit()
        {
            string _LogPath = LogPath();

            if (!System.IO.Directory.Exists(_LogPath))
                System.IO.Directory.CreateDirectory(_LogPath);

            _Log.Path = _LogPath;
        }

        private static string LogPath()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Log\";
        }
        
        public void tsmiOpenLogFolder_Click(object sender, EventArgs e)
        {
            if (_Log != null)
            {
                System.Diagnostics.Process.Start(LogPath());
            }
        }        

        public void LogEvent(string myEvent)
        {
            if (_Log != null)
            {
                _Log.Log_Event(myEvent);
            }
        }

        #endregion Log	

        App.IO.FileLog _Log = null;        	
	}
}
