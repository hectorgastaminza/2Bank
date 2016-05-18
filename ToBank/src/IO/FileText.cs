using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace App.IO
{
    /// <summary>
    /// Class for open or/and save a text file.
    /// </summary>
    public class FileText : FileGeneric
    {
        
        /*
         * Constructors
         */ 
        #region Constructors (2) 
        
        /// <summary>
        /// Generic constructor of class for open binary files
        /// </summary>
        public FileText() 
            : base() 
        {
            List<FileFilter> listFileFilter = new List<FileFilter>();
            listFileFilter.Add(new FileFilter("all", "*.*"));
            this.GenerateFilter(listFileFilter);
        }

        /// <summary>
        /// Constructor of class for open binary files
        /// </summary>
        /// <param name="enumerableFilters">IEnumerable collection of FileFilter</param>
        public FileText(System.Collections.Generic.IEnumerable<FileFilter> enumerableFilters)
            : base()
        {
            this.GenerateFilter(enumerableFilters);
        }

        #endregion Constructors


        /*
         * Methods
         */
        #region Methods (2)

        // Public Methods (2) 

        /// <summary>
        /// Open a text file
        /// </summary>
        /// <returns>List of string which contain the file information</returns>
        public List<string> Open()
        {
            if (!this.Show(new OpenFileDialog()))
                return null;
            else
                return Open(file);
        }

        /// <summary>
        /// Open a text file
        /// </summary>
        /// <returns>List of string which contain the file information</returns>
        public List<string> Open(string filename)
        {
            file = filename;

            if (!System.IO.File.Exists(file))
                return null;

            try
            {
                StreamReader reader = new StreamReader(GetStreamToOpen());

                List<string> lines = new List<string>();

                string aux = reader.ReadLine();
                while (aux != null)
                {
                    lines.Add(aux);
                    aux = reader.ReadLine();
                }

                reader.Close();

                return lines;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Save a text file
        /// </summary>
        /// <param name="lines">List of strings which contain the information to save in a file</param>
        public void SaveDialog(List<string> lines, string filename)
        {
        	SaveFileDialog dialog = new SaveFileDialog();
        	dialog.FileName = filename;
            if (!this.Show(dialog))
                return;
            else
                Save(file, lines);
        }
        
        /// <summary>
        /// Save a text file
        /// </summary>
        /// <param name="lines">List of strings which contain the information to save in a file</param>
        public void SaveDialog(List<string> lines)
        {
            if (!this.Show(new SaveFileDialog()))
                return;
            else
                Save(file, lines);
        }


        /// <summary>
        /// Save a text file
        /// </summary>
        /// <param name="lines">List of strings which contain the information to save in a file</param>
        public void Save(string filename, List<string> lines)
        {
            file = filename;

            try
            {
                StreamWriter writer = new StreamWriter(GetStreamToSave());

                foreach (string var in lines)
                {
                    writer.WriteLine(var);
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion Methods
    }
}