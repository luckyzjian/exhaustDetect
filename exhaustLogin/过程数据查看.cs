using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace exhaustDetect
{
    public partial class 过程数据查看 : Form
    {
        public 过程数据查看()
        {
            InitializeComponent();
        }

        private void 过程数据查看_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }
        public void FillASMDataToReport(SYS.Model.ASMseconds dataseconds,string lsh,string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("HC", typeof(string));
            dt.Columns.Add("CO", typeof(string));
            dt.Columns.Add("NOx", typeof(string));
            dt.Columns.Add("O2", typeof(string));
            dt.Columns.Add("CO2", typeof(string));
            dt.Columns.Add("温度", typeof(string));
            dt.Columns.Add("湿度", typeof(string));
            dt.Columns.Add("大气压", typeof(string));
            dt.Columns.Add("车速", typeof(string));
            dt.Columns.Add("加载功率", typeof(string));
            dt.Columns.Add("稀释修正系数", typeof(string));
            dt.Columns.Add("湿度修正系数", typeof(string));
            dt.Columns.Add("寄生功率", typeof(string));
            dt.Columns.Add("油温", typeof(string));
            string[] mmsx = dataseconds.MMSX.Split(',');
            string[] mmhc = dataseconds.MMHC.Split(',');
            string[] mmco = dataseconds.MMCO.Split(',');
            string[] mmnox = dataseconds.MMNO.Split(',');
            string[] mmo2 = dataseconds.MMO2.Split(',');
            string[] mmco2 = dataseconds.MMCO2.Split(',');
            string[] mmwd = dataseconds.MMWD.Split(',');
            string[] mmsd = dataseconds.MMSD.Split(',');
            string[] mmdqy = dataseconds.MMDQY.Split(',');
            string[] mmcs = dataseconds.MMCS.Split(',');
            string[] mmgl = dataseconds.MMGL.Split(',');
            string[] mmxzxs = dataseconds.MMXSXZ.Split(',');
            string[] mmkcf = dataseconds.MMSDXZ.Split(',');
            string[] mmjsgl = dataseconds.MMJSGL.Split(',');
            string[] mmyw = dataseconds.MMYW.Split(',');
            int count = mmsx.Count();
            for (int i=0;i<count-1;i++)
            {
                dt.Rows.Add(mmsx[i], mmhc[i], mmco[i], mmnox[i], mmo2[i], mmco2[i], mmwd[i], mmsd[i], mmdqy[i], mmcs[i], mmgl[i], mmxzxs[i], mmkcf[i], mmjsgl[i], mmyw[i]);
                
            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq", dataseconds.JCSJ.ToString("yyyy-MM-dd HH:mm:ss")),
                    new ReportParameter("parameterClph",dataseconds.CLHP),
                    new ReportParameter("parameterLsh",lsh),
                    new ReportParameter("parameterClsbm",vin)
            };
            this.reportViewer1.LocalReport.ReportPath = @".\ReportAsmDataseconds.rdlc";  //查找要绑定的报表  
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));  //绑定数据源 
            reportViewer1.RefreshReport();
        }
        public void FillVMASDataToReport(SYS.Model.VMASseconds dataseconds, string lsh, string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("HC", typeof(string));
            dt.Columns.Add("CO", typeof(string));
            dt.Columns.Add("NOx", typeof(string));
            dt.Columns.Add("O2", typeof(string));
            dt.Columns.Add("CO2", typeof(string));
            dt.Columns.Add("稀释O2", typeof(string));
            dt.Columns.Add("环境O2", typeof(string));
            dt.Columns.Add("温度", typeof(string));
            dt.Columns.Add("湿度", typeof(string));
            dt.Columns.Add("大气压", typeof(string));
            dt.Columns.Add("标准流量", typeof(string));
            dt.Columns.Add("实际流量", typeof(string));
            dt.Columns.Add("尾气实际流量", typeof(string));
            dt.Columns.Add("HC质量", typeof(string));
            dt.Columns.Add("CO质量", typeof(string));
            dt.Columns.Add("NO质量", typeof(string));
            dt.Columns.Add("流量计压力", typeof(string));
            dt.Columns.Add("流量计温度", typeof(string));
            dt.Columns.Add("车速", typeof(string));
            dt.Columns.Add("加载功率", typeof(string));
            dt.Columns.Add("稀释修正系数", typeof(string));
            dt.Columns.Add("湿度修正系数", typeof(string));
            dt.Columns.Add("寄生功率", typeof(string));
            dt.Columns.Add("油温", typeof(string));
            string[] mmsx = dataseconds.MMSX.Split(',');
            string[] mmhc = dataseconds.MMHC.Split(',');
            string[] mmco = dataseconds.MMCO.Split(',');
            string[] mmnox = dataseconds.MMNO.Split(',');
            string[] mmo2 = dataseconds.MMO2.Split(',');
            string[] mmco2 = dataseconds.MMCO2.Split(',');
            string[] mmxso2 = dataseconds.MMXSO2.Split(',');
            string[] mmbjo2 = dataseconds.MMHJO2.Split(',');
            string[] mmwd = dataseconds.MMWD.Split(',');
            string[] mmsd = dataseconds.MMSD.Split(',');
            string[] mmdqy = dataseconds.MMDQY.Split(',');
            string[] mmbzll = dataseconds.MMBZLL.Split(',');
            string[] mmfbzll = dataseconds.MMSJLL.Split(',');
            string[] mmfqll = dataseconds.MMWQLL.Split(',');
            string[] mmhczl = dataseconds.MMHCZL.Split(',');
            string[] mmcozl = dataseconds.MMCOZL.Split(',');
            string[] mmnozl = dataseconds.MMNOZL.Split(',');
            string[] mmlljyl = dataseconds.MMLLJYL.Split(',');
            string[] mmlljwd = dataseconds.MMLLJWD.Split(',');
            string[] mmcs = dataseconds.MMCS.Split(',');
            string[] mmgl = dataseconds.MMGL.Split(',');
            string[] mmxzxs = dataseconds.MMXSXZ.Split(',');
            string[] mmkcf = dataseconds.MMSDXZ.Split(',');
            string[] mmjsgl = dataseconds.MMJSGL.Split(',');
            string[] mmyw = dataseconds.MMYW.Split(',');
            int count = mmsx.Count();
            for (int i = 0; i < count - 1; i++)
            {
                dt.Rows.Add(mmsx[i], mmhc[i], mmco[i], mmnox[i], mmo2[i], mmco2[i], mmxso2[i], mmbjo2[i], mmwd[i], mmsd[i], mmdqy[i],
                     mmbzll[i], mmfbzll[i], mmfqll[i], mmhczl[i], mmcozl[i], mmnozl[i], mmlljyl[i], mmlljwd[i], mmcs[i], mmgl[i], mmxzxs[i], mmkcf[i], mmjsgl[i], mmyw[i]);

            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq", dataseconds.JCSJ.ToString("yyyy-MM-dd HH:mm:ss")),
                    new ReportParameter("parameterClph",dataseconds.CLHP),
                    new ReportParameter("parameterLsh",lsh),
                    new ReportParameter("parameterClsbm",vin)
            };
            this.reportViewer1.LocalReport.ReportPath = @".\ReportVmasDataseconds.rdlc";  //查找要绑定的报表  
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));  //绑定数据源 
            reportViewer1.RefreshReport();
        }
        public void FillLugdownDataToReport(SYS.Model.JZJSseconds dataseconds, string lsh, string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("采样时序", typeof(string));            
            dt.Columns.Add("车速", typeof(string));
            dt.Columns.Add("功率", typeof(string));
            dt.Columns.Add("光吸收系数", typeof(string));
            dt.Columns.Add("时序类别", typeof(string));
            dt.Columns.Add("NO", typeof(string));
            string[] mmsj = dataseconds.MMTIME.Split(',');
            string[] mmsx = dataseconds.MMSX.Split(',');           
            string[] mmcs = dataseconds.MMCS.Split(',');
            string[] mmgl = dataseconds.MMGL.Split(',');
            string[] mmk = dataseconds.MMK.Split(',');
            string[] mmlb = dataseconds.MMLB.Split(',');
            string[] mmno= dataseconds.MMNO.Split(',');
            int count = mmsx.Count();
            if (dataseconds.MMNO == "")
            {
                for (int i = 0; i < count - 1; i++)
                {
                    string lb = "";
                    switch (mmlb[i])
                    {
                        case "0": lb = "加速中"; break;
                        case "1": lb = "功率扫描中"; break;
                        case "2": lb = "100%velMaxHp测试中"; break;
                        case "3": lb = "90%velMaxHp测试中"; break;
                        case "4": lb = "80%velMaxHp测试中"; break;
                        default: break;
                    }
                    dt.Rows.Add(mmsj[i], mmsx[i], double.Parse(mmcs[i]).ToString("0.0"), double.Parse(mmgl[i]).ToString("0.0"), mmk[i], lb,"-");

                }
            }
            else
            {
                for (int i = 0; i < count - 1; i++)
                {
                    string lb = "";
                    switch (mmlb[i])
                    {
                        case "0": lb = "加速中"; break;
                        case "1": lb = "功率扫描中"; break;
                        case "2": lb = "100%velMaxHp测试中"; break;
                        case "3": lb = "90%velMaxHp测试中"; break;
                        case "4": lb = "80%velMaxHp测试中"; break;
                        default: break;
                    }
                    dt.Rows.Add(mmsj[i], mmsx[i], double.Parse(mmcs[i]).ToString("0.0"), double.Parse(mmgl[i]).ToString("0.0"), mmk[i], lb,mmno[i]);

                }
            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq", dataseconds.JCSJ.ToString("yyyy-MM-dd HH:mm:ss")),
                    new ReportParameter("parameterClph",dataseconds.CLHP),
                    new ReportParameter("parameterLsh",lsh),
                    new ReportParameter("parameterClsbm",vin)
            };
            this.reportViewer1.LocalReport.ReportPath = @".\ReportJzjsDataseconds.rdlc";  //查找要绑定的报表  
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));  //绑定数据源 
            reportViewer1.RefreshReport();
        }
        public void FillZyjsDataToReport(SYS.Model.ZYJSseconds dataseconds, string lsh, string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("采样时序", typeof(string));
            dt.Columns.Add("发动机转速", typeof(string));
            dt.Columns.Add("光吸收系数", typeof(string));
            dt.Columns.Add("时序类别", typeof(string));
            string[] mmsj = dataseconds.MMTIME.Split(',');
            string[] mmsx = dataseconds.MMSX.Split(',');
            string[] mmcs = dataseconds.MMZS.Split(',');
            string[] mmk = dataseconds.MMK.Split(',');
            string[] mmlb = dataseconds.MMLB.Split(',');
            int count = mmsx.Count();
            for (int i = 0; i < count - 1; i++)
            {
                string lb = "第"+mmlb[i]+"次测量";
                
                dt.Rows.Add(mmsj[i], mmsx[i], mmcs[i], mmk[i], lb);

            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq", dataseconds.JCSJ.ToString("yyyy-MM-dd HH:mm:ss")),
                    new ReportParameter("parameterClph",dataseconds.CLHP),
                    new ReportParameter("parameterLsh",lsh),
                    new ReportParameter("parameterClsbm",vin)
            };
            this.reportViewer1.LocalReport.ReportPath = @".\ReportZyjsDataseconds.rdlc";  //查找要绑定的报表  
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));  //绑定数据源 
            reportViewer1.RefreshReport();
        }
        public void FillSDSDataToReport(SYS.Model.SDSseconds dataseconds, string lsh, string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("工况状态", typeof(string));
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("采样时间", typeof(string));
            dt.Columns.Add("HC", typeof(string));
            dt.Columns.Add("CO", typeof(string));
            dt.Columns.Add("O2", typeof(string));
            dt.Columns.Add("CO2", typeof(string));
            dt.Columns.Add("过量空气系数", typeof(string));
            dt.Columns.Add("发动机转速", typeof(string));
            dt.Columns.Add("油温", typeof(string));
            dt.Columns.Add("温度", typeof(string));
            dt.Columns.Add("湿度", typeof(string));
            dt.Columns.Add("大气压", typeof(string));
            string[] mmlb = dataseconds.MMLB.Split(',');
            string[] mmsx = dataseconds.MMSX.Split(',');
            string[] mmsj = dataseconds.MMTIME.Split(',');
            string[] mmhc = dataseconds.MMHC.Split(',');
            string[] mmco = dataseconds.MMCO.Split(',');
            string[] mmo2 = dataseconds.MMO2.Split(',');
            string[] mmco2 = dataseconds.MMCO2.Split(',');
            string[] mmlabmda = dataseconds.MMLAMDA.Split(',');
            string[] mmzs = dataseconds.MMZS.Split(',');
            string[] mmyw = dataseconds.MMYW.Split(',');
            string[] mmwd = dataseconds.MMWD.Split(',');
            string[] mmsd = dataseconds.MMSD.Split(',');
            string[] mmdqy = dataseconds.MMDQY.Split(',');
            int count = mmsx.Count();
            for (int i = 0; i < count - 1; i++)
            {
                dt.Rows.Add(mmlb[i]=="0"?"70%工况":mmlb[i]=="1"?"高怠速准备":mmlb[i]=="2"?"高怠速测量": mmlb[i] == "3" ? "怠速准备":"怠速测量", mmsx[i],mmsj[i], mmhc[i], mmco[i],  mmo2[i], mmco2[i], mmlabmda[i], mmzs[i], mmyw[i], mmwd[i], mmsd[i], mmdqy[i]);

            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq", dataseconds.JCSJ.ToString("yyyy-MM-dd HH:mm:ss")),
                    new ReportParameter("parameterClph",dataseconds.CLHP),
                    new ReportParameter("parameterLsh",lsh),
                    new ReportParameter("parameterClsbm",vin)
            };
            this.reportViewer1.LocalReport.ReportPath = @".\ReportSdsDataseconds.rdlc";  //查找要绑定的报表  
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));  //绑定数据源 
            reportViewer1.RefreshReport();
        }
    }
}
