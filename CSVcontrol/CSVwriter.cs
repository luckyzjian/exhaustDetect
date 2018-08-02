using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CSVcontrol
{
    public class CSVwriter
    {
        /// <summary>
      /// 将DataTable中数据写入到CSV文件中
      /// </summary>
      /// <param name="dt">提供保存数据的DataTable</param>
      /// <param name="fileName">CSV的文件路径</param>
      public void SaveCSV(DataTable dt, string fullPath)
      {
          FileInfo fi = new FileInfo(fullPath);
          if (!fi.Directory.Exists)
          {
              fi.Directory.Create();
          }
         FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
          //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
          StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
          string data = "";
          //写出列名称
          for (int i = 0; i < dt.Columns.Count; i++)
          {
              data += dt.Columns[i].ColumnName.ToString();
              if (i < dt.Columns.Count - 1)
              {
                  data += ",";
              }
          }
          sw.WriteLine(data);
          //写出各行数据
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              data = "";
              for (int j = 0; j < dt.Columns.Count; j++)
              {
                  string str = dt.Rows[i][j].ToString();
                  str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                  if (str.Contains(',') || str.Contains('"') 
                      || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                  {
                      str = string.Format("\"{0}\"", str);
                  }
  
                  data += str;
                  if (j < dt.Columns.Count - 1)
                  {
                      data += ",";
                  }
              }
              sw.WriteLine(data);
          }
          sw.Close();
          fs.Close();
      }

    }
}
