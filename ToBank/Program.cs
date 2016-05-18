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

namespace App
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
            // Exceptions
            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //// Set the unhandled exception mode to force all Windows Forms errors to go through
            //// our handler.
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
/// <summary>
        /// Occurs when an exception is not caught.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.appdomain.unhandledexception.aspx</remarks>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;

                string title = "Fatal Error";
                string message = "Whoops! Please contact us with the following information:\n\n"
                    + ex.Message + "\n\n"
                    + ex.StackTrace;

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// This event allows your Windows Forms application to handle otherwise unhandled exceptions that occur in Windows Forms threads. 
        /// Attach your event handlers to the ThreadException event to deal with these exceptions, which will leave your application in an unknown state. 
        /// Where possible, exceptions should be handled by a structured exception handling block.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>http://msdn.microsoft.com/en-us/library/system.windows.forms.application.threadexception.aspx</remarks>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Abort;
            try
            {
                Exception ex = e.Exception;

                string title = "Application Error";
                string message = "Whoops! Please contact us with the following information:\n\n"
                    + ex.Message + "\n\n"
                    + ex.StackTrace;

                result = MessageBox.Show(message, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                if (result == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }


        #region Log

        //private App.IO.FileLog _LogHandler;

        private void Log_Event(string myEvent)
        {
        	/*
            if (_LogHandler != null)
            {
                try
                {
                    _LogHandler.Log_Event(myEvent);
                }
                catch (Exception ex)
                {
                    HandlerException(ex);
                }
            }
            */
        }

        #endregion Log		
		
	}
}
