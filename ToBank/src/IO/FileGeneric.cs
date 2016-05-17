using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace App.IO
{
    /// <summary>
    /// Base class for open or save binary files.
    /// </summary>
    abstract public class FileGeneric
    {
        /*
         * Methods
         */
        #region Methods

        public string Path
        {
            get
            {
                string retString = "";
                if ((file != null) && (!string.IsNullOrEmpty(file)))
                {
                    retString = System.IO.Path.GetDirectoryName(file);
                }
                return retString;
            }
        }

        
        public string FileName
        {
            get 
            { 
                string retString = "";
                if ((file != null) && (!string.IsNullOrEmpty(file)))
                {
                    retString = System.IO.Path.GetFileName(file);
                }
                return retString;
            }
        }

        // Protected Methods (2) 

        /// <summary>
        /// Show the common dialog
        /// </summary>
        /// <returns>True if a filename is correct else the method return false</returns>
        protected bool Show(FileDialog fileDialog)
        {
            fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                file = fileDialog.FileName;
                filterIndex = fileDialog.FilterIndex - 1;
                fileDialog.Dispose();
                return true;
            }
            else
            {
                fileDialog.Dispose();
                return false;
            }
        }


        /// <summary>
        /// Devuelve el stream creado para grabar un archivo
        /// </summary>
        /// <exception cref="Exception">Si surge un error al intentar crear el FileStream lanza una excepcion</exception>
        /// <returns>Filestream creado</returns>
        protected FileStream GetStreamToSave()
        {
            return this.GetStreamToSave(FileMode.Create);
        }

        /// <summary>
        /// Devuelve el stream creado para grabar un archivo
        /// </summary>
        /// <param name="mode">modo de apertura para grabar el archivo</param>
        /// <exception cref="Exception">Si surge un error al intentar crear el FileStream lanza una excepcion</exception>
        /// <returns>Filestream creado</returns>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/ee433610.aspx"/>
        protected FileStream GetStreamToSave(System.IO.FileMode mode)
        {
            try
            {
                return new FileStream(file, mode, FileAccess.Write);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw (exception); // Rethrowing exception
            }
        }


        /// <summary>
        /// Devuelve el stream creado para abrir un archivo
        /// </summary>
        /// <exception cref="Exception">Si surge un error al intentar crear el FileStream lanza una excepcion</exception>
        /// <returns>Filestream creado</returns>
        protected FileStream GetStreamToOpen()
        {
            try
            {
                return new FileStream(file, FileMode.Open, FileAccess.Read);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw (exception); // Rethrowing exception
            }
        }

        /// <summary>
        /// Its generate a filter for using on a common dialog
        /// </summary>
        /// <param name="enumerableFilters">IEnumerable collection of FileFilter objects</param>
        protected void GenerateFilter(System.Collections.Generic.IEnumerable<FileFilter> enumerableFilters) 
        {
            filter = "";
            if (enumerableFilters != null)
            {
                foreach (FileFilter myFilter in enumerableFilters)
                {
                    if (!filter.Equals(""))
                        filter += "|";
                    filter += myFilter.Name + " files (" + myFilter.Extension + ")|" + myFilter.Extension;
                }
            }
        }

        #endregion


        /*
         * Fields
         */
        #region Fields

        /// <summary>
        /// File´s name and its location
        /// </summary>
        protected string file;

        /// <summary>
        /// Kind of file which you can open it or save it
        /// </summary>
        protected string filter;

        /// <summary>
        /// Index of file´s type selected
        /// </summary>
        protected int filterIndex;

        #endregion
    }
}
