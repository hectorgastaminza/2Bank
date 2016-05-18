/*
 * Created by SharpDevelop.
 * User: hector.gastaminza
 * Date: 16/05/2016
 * Time: 03:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

/// <summary>
/// http://www.dotnetperls.com/excel
/// https://msdn.microsoft.com/en-us/library/15s06t57%28v=vs.100%29.aspx
/// Microsoft Office 2010: Primary Interop Assemblies Redistributable
/// https://www.microsoft.com/en-us/download/details.aspx?id=3508
/// </summary>
namespace App.IO
{
	/// <summary>
	/// Description of ExcelWraper.
	/// </summary>
	public class FileExcel : FileGeneric
	{
		private Application _excelApp = null;
		private List<object[,]> _sheets = null;
		
		public FileExcel()
			:base()
		{
			List<FileFilter> listFileFilter = new List<FileFilter>();
			listFileFilter.Add(new FileFilter("excel", "*.xlsx"));
			listFileFilter.Add(new FileFilter("excel", "*.xls"));
            listFileFilter.Add(new FileFilter("all", "*.*"));
            this.GenerateFilter(listFileFilter);			
			
			_excelApp = new Application();
		}
		
        /// <summary>
        /// Open a text file
        /// </summary>
        /// <returns>List of string which contain the file information</returns>
        public bool Open()
        {
            if (!this.Show(new System.Windows.Forms.OpenFileDialog()))
                return false;
            else
                return ExcelOpenSpreadsheets(file);
        }
		
		/// <summary>
		/// Open the file path received in Excel. Then, open the workbook
		/// within the file. Send the workbook to the next function, the internal scan
		/// function. Will throw an exception if a file cannot be found or opened.
		/// </summary>
		public bool ExcelOpenSpreadsheets(string thisFileName)
		{
			bool retval = false;
			
			try
			{
				//
				// This mess of code opens an Excel workbook. I don't know what all
				// those arguments do, but they can be changed to influence behavior.
				//
				Workbook workBook = _excelApp.Workbooks.Open(thisFileName,
				                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				                                             Type.Missing, Type.Missing);
				
				//
				// Pass the workbook to a separate function. This new function
				// will iterate through the worksheets in the workbook.
				//
				ExcelScanIntenal(workBook);
				
				//
				// Clean up.
				//
				workBook.Close(false, thisFileName, null);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
				
				retval = true;
			}
			catch(Exception ex)
			{
				//
				// Deal with exceptions.
				//
				throw(ex);
			}
			
			return (retval);
		}
		
		/// <summary>
		/// Scan the selected Excel workbook and store the information in the cells
		/// for this workbook in an object[,] array. Then, call another method
		/// to process the data.
		/// </summary>
		private void ExcelScanIntenal(Workbook workBookIn)
		{
			//
			// Get sheet Count and store the number of sheets.
			//
			int numSheets = workBookIn.Sheets.Count;
			
			_sheets = new List<object[,]>(numSheets);
			
			//
			// Iterate through the sheets. They are indexed starting at 1.
			//
			for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
			{
				Worksheet sheet = (Worksheet)workBookIn.Sheets[sheetNum];
				
				//
				// Take the used range of the sheet. Finally, get an object array of all
				// of the cells in the sheet (their values). You can do things with those
				// values. See notes about compatibility.
				//
				Range excelRange = sheet.UsedRange;
				object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
				_sheets.Insert(sheetNum - 1, valueArray);
				
				// Desde A:10 hasta BS:100, 71 columnas				
				
				//
				// Do something with the data in the array with a custom method.
				//
				//ProcessObjects(valueArray);
			}
		}

		/// <summary>
		/// Gets the sheet number received by param
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public object[,] GetSheet(int number)
		{
			object[,] retval = null;
			
			if(number>0)
				number--;
					
			if(number < _sheets.Count)
			{
				retval = _sheets[number];
			}
			
			return (retval);
		}
	}
}
