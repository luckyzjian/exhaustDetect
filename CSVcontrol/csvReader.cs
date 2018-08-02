using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CSVcontrol
{
    public class csvReader
    {
        public DataTable readCsv(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            if (!fi.Exists)
            {
                return null;
            }
            DataTable dt = new DataTable("NewTable");
            DataRow row;
            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            string[] head = lines[0].Split(',');
            int cnt = head.Length;
            for (int i = 0; i < cnt; i++)
            {
                dt.Columns.Add(head[i]);
            }
            for (int i = 0; i < lines.Length; i++)
            {
                if ((string.IsNullOrWhiteSpace(lines[i])))
                {
                    continue;
                }
                try
                {
                    row = dt.NewRow();
                    row.ItemArray = GetRow(lines[i], cnt);
                    dt.Rows.Add(row);
                }
                catch { }

            }
            return dt;
        }
        ///<summary>
        ///解析字符串
        ///</summary>
        static private string[] GetRow(string line, int cnt)
        {
            line.Replace("\"\"", "\"");
            string[] strs = line.Split(',');
            if (strs.Length == cnt)
            {
                return strs;
            }
            List<string> list = new List<string>();
            int n = 0, begin = 0;
            bool flag = false;
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].IndexOf("\"") == -1 || (flag == false && strs[i][0] == '\"'))
                {
                    list.Add(strs[i]);
                    continue;
                }
                n = 0;
                foreach (char ch in strs[i])
                {
                    if (ch == '\"')
                    {
                        n++;
                    }
                }
                if (n % 2 == 0)
                {
                    list.Add(strs[i]);
                    continue;
                }
                flag = true;
                begin = i;
                i++;
                for (i = begin + 1; i < strs.Length; i++)
                {
                    foreach (char ch in strs[i])
                    {
                        if (ch == '\"')
                        {
                            n++;
                        }
                    
                    }
                    if (strs[i][strs[i].Length - 1] == '\"' && n % 2 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        for(;begin<=i;begin++)
                        {
                            sb.Append(strs[begin]);
                            if(begin!=i)
                            {
                                sb.Append(",");
                            }
                        }
                        list.Add(sb.ToString());
                        break;
                    }
                }
            }
            return list.ToArray();
        }
    }
}