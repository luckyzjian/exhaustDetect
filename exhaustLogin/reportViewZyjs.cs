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

namespace exhaustDetect
{
    public partial class reportViewZyjs : Form
    {
        SYS_DAL.Zyjsdal vmasdal = new SYS_DAL.Zyjsdal();
        SYS_DAL.loginInfControl logininfcontrol = new SYS_DAL.loginInfControl();
        public reportViewZyjs()
        {
            InitializeComponent();
        }

        private void reportView_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
        private void init_wsd()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("环境", "温度", "", temp, 2048, @".\报表数据.ini");
            printer.wsdthisTime.wd = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("环境", "湿度", "", temp, 2048, @".\报表数据.ini");
            printer.wsdthisTime.sd = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("环境", "大气压", "", temp, 2048, @".\报表数据.ini");
            printer.wsdthisTime.dqy = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("环境", "是否应用", "", temp, 2048, @".\报表数据.ini");
            if (temp.ToString().Trim() == "是")
                printer.wsdthisTime.isUseWsd = true;
            else
                printer.wsdthisTime.isUseWsd = false;
        }
        public void display_Vmas(string clid)
        {
            SYS.Model.Zyjs_Btg asm_data = vmasdal.Get_Zyjs(clid);
            SYS.Model.CARDETECTED carinf = logininfcontrol.getCarbjbycarID(clid);
            init_wsd();
            if (printer.wsdthisTime.isUseWsd)
            {
                asm_data.WD = printer.wsdthisTime.wd;
                asm_data.SD = printer.wsdthisTime.sd;
                asm_data.DQY = printer.wsdthisTime.dqy;
            }
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            string teststring = DateTime.Now.ToShortDateString();
            try
            {
                ReportParameter[] rptpara =
                {
                    new ReportParameter("parameterJCYJ","GB3847-2005"),
                    new ReportParameter("parameterJCFF","加载减速法"),
                    new ReportParameter("parameterLsh", carinf.LSH),
                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                    new ReportParameter("parameterJcrq", carinf.JCSJ.ToString("yyyy-MM-dd hh:mm:ss")),
                    new ReportParameter("parameterCzy", carinf.CZY),
                    new ReportParameter("parameterJsy", carinf.JSY),
                    new ReportParameter("parameterClxh", carinf.XH),
                    new ReportParameter("parameterScqy",carinf.SCQY),
                    new ReportParameter("parameterJzzl", carinf.JZZL),
                    new ReportParameter("parameterZzl", carinf.ZZL),
                    new ReportParameter("parameterBsqxs",carinf.BSQXS),
                    new ReportParameter("parameterJqfs",carinf.JQFS),
                    new ReportParameter("parameterFdjxh",carinf.FDJXH),
                    new ReportParameter("parameterGyfs",carinf.GYFS),
                    new ReportParameter("parameterRlzl",carinf.RLZL),
                    new ReportParameter("parameterDws",carinf.DWS),
                    new ReportParameter("parameterQGS",carinf.QGS),
                    new ReportParameter("parameterFDJH",carinf.FDJHM),
                    new ReportParameter("parameterXslc",carinf.XSLC),
                    new ReportParameter("parameterFdjpl",carinf.FDJPL),
                    new ReportParameter("parameterZcrq", carinf.ZCRQ.ToString("yyyy-MM-dd")),
                    new ReportParameter("parameterCllx",carinf.CLLX),
                    new ReportParameter("parameterHpzl",carinf.CPYS),
                    new ReportParameter("parameterEdgl",carinf.EDGL),
                    new ReportParameter("parameterEdzs",carinf.EDZS),
                    new ReportParameter("parameterHbbz","有"),
                    new ReportParameter("parameterCzdz",""),
                    new ReportParameter("parameterCzdh",carinf.LXDH),
                    new ReportParameter("parameterQdfs",carinf.QDXS),
                    new ReportParameter("parameterChzz",(carinf.JHZZ=="是")?"有":"无"),
                    new ReportParameter("parameterClph",carinf.CLHP),
                    new ReportParameter("parameterCpys",carinf.CPYS),
                    new ReportParameter("parameterClsbm",carinf.CLSBM),
                    new ReportParameter("parameterCz",carinf.CZ),
                    new ReportParameter("parameterSbmc",asm_data.SBMC),
                    new ReportParameter("parameterSbbh","--"+"/"+asm_data.YDJBH),
                    new ReportParameter("parameterCgjxh","--"),
                    new ReportParameter("parameterCgjbh","--"),
                    new ReportParameter("parameterCgjcj","--"),
                    new ReportParameter("parameterFxyxh",asm_data.YDJXH),
                    new ReportParameter("parameterFxybh",asm_data.YDJBH),
                    new ReportParameter("parameterFxycj",asm_data.YDJZZC),
                    new ReportParameter("parameterWd",asm_data.WD),
                    new ReportParameter("parameterDqy",asm_data.DQY),
                    new ReportParameter("parameterSd",asm_data.SD),
                    
                    new ReportParameter("parameterDSZS",asm_data.DSZS),
                    new ReportParameter("parameterFIRSTDATA",asm_data.FIRSTDATA),
                    new ReportParameter("parameterSECONDDATA",asm_data.SECONDDATA),
                    new ReportParameter("parameterTHIRDDATA",asm_data.THIRDDATA),
                    new ReportParameter("parameterBTGXZ","≤"+asm_data.YDXZ),
                    new ReportParameter("parameterPJZ",asm_data.AVERAGEDATA),
                    new ReportParameter("parameterBTGPD",asm_data.ZHPD),
                    new ReportParameter("parameterZHPD",(asm_data.ZHPD=="合格")?"通过":"未通过"),

                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),
                    new ReportParameter("parameterJczdz",mainPanel.stationinfmodel.STATIONADD),
                    new ReportParameter("parameterJczdh",mainPanel.stationinfmodel.STATIONPHONE),
                    new ReportParameter("parameterJCZMC",carinf.JCZMC.Split('_')[1])
                };
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.SetParameters(rptpara);
            }
            catch
            {
                throw;
            }
            reportViewer1.RefreshReport();
        }
        
        private void reportView_panelFormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
