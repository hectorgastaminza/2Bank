using System;
using System.Collections.Generic;
using System.Text;

namespace App.IO
{
    public class FileLog
    {
        #region Constructors

        public FileLog(string logname, string extension, string id)
            : this(logname, extension)
        {
            this.LogId = id;
        }

        public FileLog(string logname, string extension)
        {
            this.LogName = logname;
            this.LogExtension = extension;
        }

        public FileLog()
            : this("Log", "log") { }

        #endregion Constructors


        #region Propierties

        public string LogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }

        public string LogName
        {
            get { return _LogName; }
            set { _LogName = value; }
        }

        public string LogExtension
        {
            get { return _LogExtension; }
            set { _LogExtension = value; }
        }

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        #endregion Propierties


        #region Methods

        public void Log_Event(string myEvent)
        {
            bool bHeader = false;
            string path = Log_GetFileName();
            System.IO.StreamWriter sw;

            lock (locker) // Thread Safe Implementacion
            {
                // Verifico si el archivo existe. Sino lo crea. Si existe lo abre para agregar un texto
                if (!System.IO.File.Exists(path))
                {
                    sw = System.IO.File.CreateText(path);
                    bHeader = true;
                }
                else
                {
                    sw = System.IO.File.AppendText(path);
                }
                // Genera el formato del evento
                string text = DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss,");
                if(!string.IsNullOrEmpty(LogId))
                    text += LogId + ",";
                text += myEvent;

                // Guarda el evento
                if (bHeader)
                    sw.WriteLine("Year,Month,Day,Hour,Minute,Second,Event");
                sw.WriteLine(text);
                
                // Libera el recurso
                sw.Dispose();
            }
        }

        /// <summary>
        /// Genera el nombre del archivo
        /// </summary>
        /// <returns></returns>
        public string Log_GetFileName()
        {
            string retval = Path
                + _LogName
                + "-"
                + DateTime.Now.ToString("yyyy-MM-dd")
                + "."
                + _LogExtension
                ;
            return retval;
        }

        #endregion Methods


        #region Fields

        private readonly object locker = new object(); // Thread Safe Implementacion

        private string _LogName = string.Empty;
        private string _LogExtension = string.Empty;
        private string _LogId = string.Empty;
        private string _Path = System.Environment.SpecialFolder.ApplicationData.ToString();

        #endregion Fields
    }
}
