using System;
using System.Collections.Generic;
using System.Text;

namespace App.IO
{
    /// <summary>
    /// Class define a filter for using on a common dialog
    /// </summary>
    public class FileFilter
    {
        /*
         * Properties
         */
        #region Properties

        /// <summary>
        /// Name of extension´s file which form part of the filter
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Extension´s file which form part of the filter
        /// </summary>
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }


        #endregion


        /*
         * Constructor
         */
        #region Constructor

        /// <summary>
        /// Constructor of FileFilter class
        /// </summary>
        /// <param name="name">Name or description of the extension</param>
        /// <param name="extension">Extension</param>
        public FileFilter(string name, string extension)
        {
            this.Name = name;
            this.Extension = extension;
        }

        /// <summary>
        /// Generic constructor of FileFilter class
        /// </summary>
        public FileFilter() { }

        #endregion


        /*
         * Fields
         */
        #region Fields

        private string _Name;
        private string _Extension;

        #endregion
    }
}
