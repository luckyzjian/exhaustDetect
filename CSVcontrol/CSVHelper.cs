using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace CSVcontrol
{
    public class CSVHelper
    {
        string strContent;
        MSExcel.Application excelApp;
        MSExcel.Workbook excelDoc;
        object filepath = null;
        MSExcel.Worksheet ws = null;
        public void CreateCsv(object path)
        {
            filepath = path;
            excelApp = new MSExcel.Application();
            if (File.Exists((string)filepath))
            {
                File.Delete((string)filepath);
            }
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks.Add(Nothing);
            object format = MSExcel.XlFileFormat.xlWorkbookDefault;
            excelDoc.SaveAs(filepath, Nothing, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);
            excelDoc.Close(Nothing, Nothing, Nothing);
            excelApp.Quit();
        }
        public void openCsv()
        {
            Object missing = Missing.Value;
            excelDoc = excelApp.Workbooks.Open((string)filepath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            ws = (MSExcel.Worksheet)excelDoc.Sheets[1];
            ws.Activate();
        }
        public void writeField(int line, int row,string content)
        {
            ws.Cells[line, row] = content;
            
        }
        public void closeCsv()
        {
            excelDoc.Save();
            ws = null;
            excelDoc = null;
            GcCollect();
            excelApp.Quit();
        }

        public void GcCollect()          
        {             
            GC.Collect();              
            GC.WaitForPendingFinalizers();             
            GC.Collect();              
            GC.WaitForPendingFinalizers();       
        }  
    }
}

