using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Windows.Xps.Packaging;
using Action = System.Action;

namespace HOYA_IOT.Control
{
    public class ExcelFileParse
    {
        #region Model
        public static System.Data.DataTable _exceltable;
        public static System.Data.DataTable ExcelTable
        {
            get => _exceltable;
            set => _exceltable = value;
        }
        public static List<string> _listSheet;
        public static List<string> ListSheet
        {
            get => _listSheet;
            set => _listSheet = value;
        }
        public static DataTableCollection DataTableCollection { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// Open And Parse File To DataGrid
        /// </summary>
        public static void Openfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|Excel Comma Seprate|*.csv" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".csv")
                {
                    ExcelTable = ReadCsvFile(openFileDialog.FileName);
                }
                else
                {
                    Get_excel(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void Get_excel(string path)
        {
            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    DataTableCollection = dataSet.Tables;
                    if (ListSheet != null)
                    {
                        ListSheet.Clear();
                    }
                    else
                    {
                        ListSheet = new List<string>();
                    }
                    ListSheet.AddRange(DataTableCollection.Cast<System.Data.DataTable>().Select(t => t.TableName).ToArray());
                }
            }
        }
        /// <summary>
        /// Conver File .CSV to Datatable
        /// </summary>
        /// <param name="FileSaveWithPath"></param>
        /// <returns></returns>
        public static System.Data.DataTable ReadCsvFile(string FileSaveWithPath)
        {
            System.Data.DataTable dtCsv = new System.Data.DataTable();
            string Fulltext;
            using (StreamReader sr = new StreamReader(FileSaveWithPath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString();
                    string[] rows = Fulltext.Split(new char[] { '\r', '\n' });
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(',');
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j]);
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<System.Windows.Documents.FixedDocumentSequence> BrowseFile()
        {
            //Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //openFileDialog.DefaultExt = ".xls|.xlsx";
            //openFileDialog.Filter = "(.xls)|*.xls|(.xlsx)|*xlsx";
            //Nullable<bool> result = openFileDialog.ShowDialog();
            //if (result == true)
            //{
            //    if (openFileDialog.FileName.Length > 0)
            //    {
            //        string newXSPDocumentName = string.Concat(Path.GetDirectoryName(ApplicationConfig.ApplicationConfig.ProcessExcelFile), "\\", Path.GetFileNameWithoutExtension(ApplicationConfig.ApplicationConfig.ProcessExcelFile), ".xps");
            //        System.Windows.Documents.FixedDocumentSequence a = ConvertExcelToXPSDoc(ApplicationConfig.ApplicationConfig.ProcessExcelFile, newXSPDocumentName).GetFixedDocumentSequence();
            //        return a;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}
            System.Windows.Documents.FixedDocumentSequence doc = new System.Windows.Documents.FixedDocumentSequence();
            void act()
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate {
                    string newXSPDocumentName = string.Concat(Path.GetDirectoryName(ApplicationConfig.ApplicationConfig.ProcessExcelFile), "\\", Path.GetFileNameWithoutExtension(ApplicationConfig.ApplicationConfig.ProcessExcelFile), ".xps");
                    doc = ConvertExcelToXPSDoc(ApplicationConfig.ApplicationConfig.ProcessExcelFile, newXSPDocumentName).GetFixedDocumentSequence();
                });
            };
            Task a = new Task(act);
            a.Start();
            await a;
            return doc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelDocName"></param>
        /// <param name="xpsDocName"></param>
        /// <returns></returns>
        private static XpsDocument ConvertExcelToXPSDoc(string excelDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = excelApplication.Workbooks.Open(excelDocName);
            try
            {
                excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypeXPS, Filename: xpsDocName, OpenAfterPublish: false);
                
                XpsDocument xpsDoc = new XpsDocument(xpsDocName, FileAccess.Read, compressionOption: System.IO.Packaging.CompressionOption.Maximum);
                
                excelApplication.Quit();
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
                Console.WriteLine(exp.Message);
            }
            return null;
        }
        #endregion
        public ExcelFileParse()
        {

        }
    }
}
