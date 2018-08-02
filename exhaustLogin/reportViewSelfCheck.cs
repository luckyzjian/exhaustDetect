using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using exhaustDetect;
using System.IO;

namespace exhaustDetect
{
    public partial class reportViewSelfCheck : Form
    {
        SYS_DAL.selfcheckdal vmasdal = new SYS_DAL.selfcheckdal();
        SYS_DAL.loginInfControl logininfcontrol = new SYS_DAL.loginInfControl();
        public reportViewSelfCheck()
        {
            InitializeComponent();
        }

        private void reportView_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
        public void display_Vmas(string clid)
        {
            SYS.Model.selfcheckdata vmas_data = vmasdal.Get_SelfCheckData(clid);
            
        }
        private void reportView_panelFormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clid = mainPanel.stationid + mainPanel.lineid + "_" +dateTimePicker1.Value.ToString("yyyyMMdd");
            if (vmasdal.Have_SelfCheckData(clid))
            {
                SYS.Model.selfcheckdata checkdata = vmasdal.Get_SelfCheckData(clid);
                writeExcel.writeSelfCheckData(checkdata);
            }
            else
            {
                MessageBox.Show("没有检测到该日期的自检记录", "提示！");
            }
                    //string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
        }
    }
    public class writeExcel
    {
        public static void saveExcel(DataTable dt, SaveFileDialog file)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();

            SaveFileDialog savefiledialog = file;

            System.Reflection.Missing miss = System.Reflection.Missing.Value;

            appexcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbookdata;

            Microsoft.Office.Interop.Excel.Worksheet worksheetdata;

            Microsoft.Office.Interop.Excel.Range rangedata;

            //设置对象不可见

            appexcel.Visible = false;

            System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

            workbookdata = appexcel.Workbooks.Add(miss);

            worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

            //给工作表赋名称

            worksheetdata.Name = "已检车辆统计信息";

            for (int i = 0; i < dt.Columns.Count; i++)
            {

                worksheetdata.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();

            }

            //因为第一行已经写了表头，所以所有数据都应该从a2开始

            rangedata = worksheetdata.get_Range("a2", miss);

            Microsoft.Office.Interop.Excel.Range xlrang = null;

            //irowcount为实际行数，最大行

            int irowcount = dt.Rows.Count;

            int iparstedrow = 0, icurrsize = 0;

            //ieachsize为每次写行的数值，可以自己设置

            int ieachsize = 1000;

            //icolumnaccount为实际列数，最大列数

            int icolumnaccount = dt.Columns.Count;

            //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数

            object[,] objval = new object[ieachsize, icolumnaccount];

            icurrsize = ieachsize;





            while (iparstedrow < irowcount)
            {

                if ((irowcount - iparstedrow) < ieachsize)

                    icurrsize = irowcount - iparstedrow;

                //用for循环给数组赋值

                for (int i = 0; i < icurrsize; i++)
                {

                    for (int j = 0; j < icolumnaccount; j++)

                        objval[i, j] = dt.Rows[i + iparstedrow][j].ToString();

                    System.Windows.Forms.Application.DoEvents();

                }

                string X = "A" + ((int)(iparstedrow + 2)).ToString();

                string col = "";

                if (icolumnaccount <= 26)
                {

                    col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

                }

                else
                {

                    col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

                }

                xlrang = worksheetdata.get_Range(X, col);

                // 调用range的value2属性，把内存中的值赋给excel

                xlrang.Value2 = objval;

                iparstedrow = iparstedrow + icurrsize;

            }

            //保存工作表

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlrang);

            xlrang = null;

            //调用方法关闭excel进程

            appexcel.Visible = true;

        }

        public static bool writeSelfCheckData(SYS.Model.selfcheckdata cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[2, 2] = cgjdata.WORKTIME.ToString("yyyy-MM-dd");
                objsheet.Cells[2, 4] = cgjdata.WORKTIME.ToString("HH:mm:ss");
                objsheet.Cells[2, 6] = cgjdata.WORKER;
                if (cgjdata.ISCGJCHECK == "Y")
                {
                    objsheet.Cells[18, 3] = (cgjdata.CGJTX == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[18, 4] = (cgjdata.CGJTX == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[19, 3] = (cgjdata.CGJYR == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[19, 4] = (cgjdata.CGJYR == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[20, 3] = (cgjdata.CGJQL == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[20, 4] = (cgjdata.CGJQL == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[21, 3] = (cgjdata.CGJJSGL == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[21, 4] = (cgjdata.CGJJSGL == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[24, 3] = (cgjdata.CGJJZHX == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[24, 4] = (cgjdata.CGJJZHX == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[21, 6] = cgjdata.CGJEDGL;
                    objsheet.Cells[22, 6] = cgjdata.CGJSJGL;
                    objsheet.Cells[23, 6] = cgjdata.CGJGLWC;
                    
                    objsheet.Cells[24, 6] = cgjdata.CGJVITRUALTIME;
                    objsheet.Cells[25, 6] = cgjdata.CGJREALTIME;
                    objsheet.Cells[26, 6] = cgjdata.CGJTIMEWC;
                }
                if (cgjdata.ISQXZCHECK == "Y")
                {
                    objsheet.Cells[5, 3] = (cgjdata.TEMPOK == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[5, 4] = (cgjdata.TEMPOK == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[6, 3] = (cgjdata.HUMIOK == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[6, 4] = (cgjdata.HUMIOK == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[7, 3] = (cgjdata.AIRPOK == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[7, 4] = (cgjdata.AIRPOK == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[5, 6] = cgjdata.TEMP;
                    objsheet.Cells[6, 6] = cgjdata.HUMI;
                    objsheet.Cells[7, 6] = cgjdata.AIRP;
                }
                if (cgjdata.ISFQYCHECK == "Y")
                {
                    objsheet.Cells[8, 3] = (cgjdata.FQYTX == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[8, 4] = (cgjdata.FQYTX == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[9, 3] = (cgjdata.FQYYR == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[9, 4] = (cgjdata.FQYYR == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[10, 3] = (cgjdata.FQYTL == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[10, 4] = (cgjdata.FQYTL == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[11, 3] = (cgjdata.FQYJL == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[11, 4] = (cgjdata.FQYJL == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[12, 3] = (cgjdata.FQYLC == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[12, 4] = (cgjdata.FQYLC == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[12, 6] = cgjdata.FQYO2;
                }
                if (cgjdata.ISBTGCHECK == "Y")
                {
                    objsheet.Cells[13, 3] = (cgjdata.BTGTX == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[13, 4] = (cgjdata.BTGTX == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[14, 3] = (cgjdata.BTGYR == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[14, 4] = (cgjdata.BTGYR == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[15, 3] = (cgjdata.BTGTL == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[15, 4] = (cgjdata.BTGTL == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[16, 3] = (cgjdata.BTGLC == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[16, 4] = (cgjdata.BTGLC == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[17, 3] = (cgjdata.BTGJZ == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[17, 4] = (cgjdata.BTGJZ == "Y") ? "□不正常" : "√不正常";
                }
                if (cgjdata.ISZSJCHECK == "Y")
                {
                    objsheet.Cells[29, 3] = (cgjdata.ZSJTX == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[29, 4] = (cgjdata.ZSJTX == "Y") ? "□不正常" : "√不正常";
                    objsheet.Cells[30, 3] = (cgjdata.ZSJLC == "Y") ? "√正常" : "□正常";
                    objsheet.Cells[30, 4] = (cgjdata.ZSJLC == "Y") ? "□不正常" : "√不正常";
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                //objbook.Save();
                //appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.wqfxySelfcheck cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[8, 3] = "√正常";
                objsheet.Cells[9, 3] = "√正常";
                objsheet.Cells[10, 3] = "√正常";
                if (cgjdata.TightnessResult == "0")
                {
                    objsheet.Cells[11, 4] = "√不正常";
                    objsheet.Cells[11, 3] = "□正常";
                }
                else
                {
                    objsheet.Cells[11, 4] = "□不正常";
                    objsheet.Cells[11, 3] = "√正常";
                }
                objsheet.Cells[21, 4] = "□不正常";
                objsheet.Cells[22, 3] = "√正常";
                objsheet.Cells[12, 6] = "20.68";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.sdsqtfxySelfcheck cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[8, 3] = "√正常";
                objsheet.Cells[9, 3] = "√正常";
                objsheet.Cells[10, 3] = "√正常";
                if (cgjdata.TightnessResult == "0")
                {
                    objsheet.Cells[11, 4] = "√不正常";
                    objsheet.Cells[11, 3] = "□正常";
                }
                else
                {
                    objsheet.Cells[11, 4] = "□不正常";
                    objsheet.Cells[11, 3] = "√正常";
                }
                objsheet.Cells[21, 4] = "□不正常";
                objsheet.Cells[22, 3] = "√正常";
                objsheet.Cells[12, 6] = "20.68";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.ydjSelfcheck cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[13, 3] = "√正常";
                objsheet.Cells[14, 3] = "√正常";
                objsheet.Cells[15, 3] = "√正常";
                objsheet.Cells[16, 3] = "√正常";
                objsheet.Cells[17, 3] = "√正常";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.temperatureData cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[5, 6] = cgjdata.Wdscz.ToString("0.0");
                objsheet.Cells[6, 6] = cgjdata.Sdscz.ToString("0.0");
                objsheet.Cells[7, 6] = cgjdata.Dqyscz.ToString("0.0");
                objsheet.Cells[5, 3] = "√正常";
                objsheet.Cells[6, 3] = "√正常";
                objsheet.Cells[7, 3] = "√正常";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.zsjSelfDetecInf cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[29, 3] = "√正常";
                objsheet.Cells[30, 3] = "√正常";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeSelfCheckData(carinfor.lljSelfDetectInf cgjdata)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\自检日志.xls"))
            {
                string filename = Application.StartupPath + "\\bk\\检测信息" + DateTime.Now.ToString("yyMMdd") + ".xls";
                if (!File.Exists(filename))
                    File.Copy(Application.StartupPath + "\\bk\\自检日志.xls", filename, true);
                appworkbook.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "F30");
                objsheet.Cells[27, 3] = "√正常";
                objsheet.Cells[28, 3] = "√正常";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                objbook.Save();
                appworkbook.Close();
                //调用方法关闭excel进程
                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writelogDatatableToElt(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\操作日志.xls"))
            {
                File.Copy(Application.StartupPath + "\\bk\\操作日志.xls", Application.StartupPath + "\\操作日志.xls", true);
                appworkbook.Open(Application.StartupPath + "\\操作日志.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "D5");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objsheet.Cells[i + 4, 1] = (i + 1).ToString();
                    objsheet.Cells[i + 4, 2] = "孝感市";
                    objsheet.Cells[i + 4, 3] = mainPanel.stationinfmodel.STATIONNAME;
                    objsheet.Cells[i + 4, 4] = dt.Rows[i]["LINEID"].ToString();
                    objsheet.Cells[i + 4, 5] = dt.Rows[i]["PRONAME"].ToString();
                    objsheet.Cells[i + 4, 6] = dt.Rows[i]["CZY"].ToString();
                    objsheet.Cells[i + 4, 7] = dt.Rows[i]["DATA"].ToString();
                    objsheet.Cells[i + 4, 8] = dt.Rows[i]["STATE"].ToString();
                    objsheet.Cells[i + 4, 9] = dt.Rows[i]["RESULT"].ToString();
                    objsheet.Cells[i + 4, 10] = DateTime.Parse(dt.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd HH:mm");
                    objsheet.Cells[i + 4, 11] = dt.Rows[i]["BZSM"].ToString();
                }
                //保存工作表

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                //调用方法关闭excel进程

                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeDemarcateDatatableToElt(DataTable dt, string proname)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\标定项目明细表.xls"))
            {
                File.Copy(Application.StartupPath + "\\bk\\标定项目明细表.xls", Application.StartupPath + "\\标定项目明细表.xls", true);
                appworkbook.Open(Application.StartupPath + "\\标定项目明细表.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "D5");
                objsheet.Cells[3, 1] = "序号";
                objsheet.Cells[3, 2] = "市县";
                objsheet.Cells[3, 3] = "检测机构名称";
                objsheet.Cells[3, 4] = "项目";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    objsheet.Cells[3, 5 + i] = dt.Rows[0][i].ToString();
                }
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    objsheet.Cells[i + 3, 1] = i.ToString();
                    objsheet.Cells[i + 3, 2] = "孝感市";
                    objsheet.Cells[i + 3, 3] = mainPanel.stationinfmodel.STATIONNAME;
                    objsheet.Cells[i + 3, 4] = proname;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        objsheet.Cells[i + 3, 5 + j] = dt.Rows[i][j].ToString();
                    }
                }
                //保存工作表

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                //调用方法关闭excel进程

                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeDatatableToElt(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\检测信息.xls"))
            {
                File.Copy(Application.StartupPath + "\\bk\\检测信息.xls", Application.StartupPath + "\\检测信息.xls", true);
                appworkbook.Open(Application.StartupPath + "\\检测信息.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "D5");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objsheet.Cells[i + 4, 1] = (i + 1).ToString();
                    objsheet.Cells[i + 4, 2] = "";
                    objsheet.Cells[i + 4, 3] = mainPanel.stationinfmodel.STATIONNAME;
                    objsheet.Cells[i + 4, 4] = dt.Rows[i]["LINEID"].ToString();
                    objsheet.Cells[i + 4, 5] = DateTime.Parse(dt.Rows[i]["JCSJ"].ToString()).ToString("yyyy-MM-dd HH:mm");
                    objsheet.Cells[i + 4, 6] = dt.Rows[i]["CLHP"].ToString();
                    objsheet.Cells[i + 4, 7] = dt.Rows[i]["PP"].ToString() + dt.Rows[i]["XH"].ToString();
                    objsheet.Cells[i + 4, 8] = dt.Rows[i]["SYXZ"].ToString();
                    objsheet.Cells[i + 4, 9] = dt.Rows[i]["CLLX"].ToString();
                    objsheet.Cells[i + 4, 10] = "'" + dt.Rows[i]["CLSBM"].ToString();
                    objsheet.Cells[i + 4, 11] = DateTime.Parse(dt.Rows[i]["ZCRQ"].ToString()).ToString("yyyy/MM/dd");
                    objsheet.Cells[i + 4, 12] = dt.Rows[i]["RLZL"].ToString();
                    objsheet.Cells[i + 4, 13] = "'" + dt.Rows[i]["LSH"].ToString();
                    switch (dt.Rows[i]["JCFF"].ToString())
                    {
                        case "ASM": objsheet.Cells[i + 4, 14] = "稳态工况法"; break;
                        case "SDS": objsheet.Cells[i + 4, 14] = "双怠速法"; break;
                        case "JZJS": objsheet.Cells[i + 4, 14] = "加载减速法"; break;
                        case "ZYJS": objsheet.Cells[i + 4, 14] = "自由加速法"; break;
                        case "VMAS": objsheet.Cells[i + 4, 14] = "简易瞬态法"; break;
                        case "LZ": objsheet.Cells[i + 4, 14] = "滤纸法"; break;
                        default: break;

                    }
                }
                //保存工作表

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                //调用方法关闭excel进程

                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        /*public static bool writelogDatatableToElt(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\操作日志.xls"))
            {
                File.Copy(Application.StartupPath + "\\bk\\操作日志.xls", Application.StartupPath + "\\操作日志.xls", true);
                appworkbook.Open(Application.StartupPath + "\\操作日志.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "D5");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objsheet.Cells[i + 4, 1] = (i + 1).ToString();
                    objsheet.Cells[i + 4, 2] = mainPanel.addname;
                    objsheet.Cells[i + 4, 3] = mainPanel.stationinfmodel.STATIONNAME;
                    objsheet.Cells[i + 4, 4] = dt.Rows[i]["LINEID"].ToString();
                    objsheet.Cells[i + 4, 5] = dt.Rows[i]["PRONAME"].ToString();
                    objsheet.Cells[i + 4, 6] = dt.Rows[i]["CZY"].ToString();
                    objsheet.Cells[i + 4, 7] = dt.Rows[i]["DATA"].ToString();
                    objsheet.Cells[i + 4, 8] = dt.Rows[i]["STATE"].ToString();
                    objsheet.Cells[i + 4, 9] = dt.Rows[i]["RESULT"].ToString();
                    objsheet.Cells[i + 4, 10] = DateTime.Parse(dt.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd HH:mm");
                    objsheet.Cells[i + 4, 11] = dt.Rows[i]["BZSM"].ToString();
                }
                //保存工作表

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                //调用方法关闭excel进程

                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }
        public static bool writeDemarcateDatatableToElt(DataTable dt, string proname)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks appworkbook = (Microsoft.Office.Interop.Excel.Workbooks)appexcel.Workbooks;
            if (File.Exists(Application.StartupPath + "\\bk\\标定项目明细表.xls"))
            {
                File.Copy(Application.StartupPath + "\\bk\\标定项目明细表.xls", Application.StartupPath + "\\标定项目明细表.xls", true);
                appworkbook.Open(Application.StartupPath + "\\标定项目明细表.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Workbook objbook = appworkbook.get_Item(1);
                Microsoft.Office.Interop.Excel.Sheets msheets = (Microsoft.Office.Interop.Excel.Sheets)objbook.Worksheets;
                Microsoft.Office.Interop.Excel._Worksheet objsheet = (Microsoft.Office.Interop.Excel._Worksheet)msheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range m_objRange = (Microsoft.Office.Interop.Excel.Range)objsheet.get_Range("A1", "D5");
                objsheet.Cells[3, 1] = "序号";
                objsheet.Cells[3, 2] = "市县";
                objsheet.Cells[3, 3] = "检测机构名称";
                objsheet.Cells[3, 4] = "项目";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    objsheet.Cells[3, 5 + i] = dt.Rows[0][i].ToString();
                }
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    objsheet.Cells[i + 3, 1] = i.ToString();
                    objsheet.Cells[i + 3, 2] = mainPanel.addname;
                    objsheet.Cells[i + 3, 3] = mainPanel.stationinfmodel.STATIONNAME;
                    objsheet.Cells[i + 3, 4] = proname;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        objsheet.Cells[i + 3, 5 + j] = dt.Rows[i][j].ToString();
                    }
                }
                //保存工作表

                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);

                m_objRange = null;
                //调用方法关闭excel进程

                appexcel.Visible = true;
                return true;
            }
            else
                return false;
        }*/
    }

}
