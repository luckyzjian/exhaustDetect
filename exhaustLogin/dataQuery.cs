using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using SYS_DAL;
using SYS_MODEL;
using SYS.Model;
using Microsoft.Reporting.WinForms;
using Microsoft.Office.Interop;

namespace exhaustDetect
{
    public partial class dataQuery : Form
    {
        public int Carwait_Scroll = 0;                                                  //待检车滚动条位置
        DataTable dt_wait = null;                                                         //等待车辆列表
        public string[] selectID = new string[1024];                                    //当前等待车辆选中的列表
        public bool ref_zt = true;
        int linesCount = 0;
        int sdsTotalCarCount = 0, sdsTotalTestCount = 0, sdsCjCount = 0, sdsFirstFjCount = 0, sdsSecondFjCount = 0, sdsFjCount = 0, sdsPassCount = 0;
        int sdsCjPassCount = 0, sdsFirstFjPassCount = 0, sdsSecondFjPassCount = 0;

        double sdsCjPassPercent = 0, sdsFirstFjPassPercent = 0, sdsSecondFjPassPercent = 0, sdsTotalPassPercent = 0;
        int asmTotalCarCount = 0, asmTotalTestCount = 0, asmCjCount = 0, asmFirstFjCount = 0, asmFjCount = 0, asmSecondFjCount = 0, asmPassCount = 0;
        int asmCjPassCount = 0, asmFirstFjPassCount = 0, asmSecondFjPassCount = 0;
        double asmCjPassPercent = 0, asmFirstFjPassPercent = 0, asmSecondFjPassPercent = 0, asmTotalPassPercent = 0;
        int btgTotalCarCount = 0, btgTotalTestCount = 0, btgCjCount = 0, btgFirstFjCount = 0, btgFjCount = 0, btgSecondFjCount = 0, btgPassCount = 0;
        int btgCjPassCount = 0, btgFirstFjPassCount = 0, btgSecondFjPassCount = 0;
        double btgCjPassPercent = 0, btgFirstFjPassPercent = 0, btgSecondFjPassPercent = 0, btgTotalPassPercent = 0;
        int lugdownTotalCarCount = 0, lugdownTotalTestCount = 0, lugdownCjCount = 0, lugdownFirstFjCount = 0, lugdownFjCount = 0, lugdownSecondFjCount = 0, lugdownPassCount = 0;
        int lugdownCjPassCount = 0, lugdownFirstFjPassCount = 0, lugdownSecondFjPassCount = 0;
        double lugdownCjPassPercent = 0, lugdownFirstFjPassPercent = 0, lugdownSecondFjPassPercent = 0, lugdownTotalPassPercent = 0;
        int TotalCarCount = 0, TotalTestCount = 0, CjCount = 0, FirstFjCount = 0, FjCount = 0, SecondFjCount = 0, PassCount = 0;
        int TotalCjPassCount = 0, TotalFirstFjPassCount = 0, TotalSecondFjPassCount = 0;
        double CjPassPercent = 0, FirstFjPassPercent = 0, SecondFjPassPercent = 0, TotalPassPercent = 0;
        string kgjcff,GKJCFFNAME,GKJCFFJC, lineid;
        DateTime starttime, endtime;
        int linestart = 0, linestop = 0;
        ReportParameter[] rptpara;


        private loginInfModel logininfmodel = new loginInfModel();
        private loginInfControl logininfcontrol = new loginInfControl();
        private stationControl stationcontrol = new stationControl();
        private baseControl basecontrol = new baseControl();

        public struct staffInf
        {
            public string name;
            public string id;
            public int asmcj;
            public int asmfj1;
            public int asmfj2;
            public double asmcjpassrate;
            public double asmfj1passrate;
            public double asmfj2passrate;
            public int sdscj;
            public int sdsfj1;
            public int sdsfj2;
            public double sdscjpassrate;
            public double sdsfj1passrate;
            public double sdsfj2passrate;
            public int jzjscj;
            public int jzjsfj1;
            public int jzjsfj2;
            public double jzjscjpassrate;
            public double jzjsfj1passrate;
            public double jzjsfj2passrate;
            public int btgcj;
            public int btgfj1;
            public int btgfj2;
            public double btgcjpassrate;
            public double btgfj1passrate;
            public double btgfj2passrate;
            public double cjpassrate;
            public double fj1passrate;
            public double fj2passrate;
            public int totalcount;
            public double totalpassrate;
        }
        private List<staffInf> staffinflist = new List<staffInf>();
        //private List<Stream> m_streams;
        //用来记录当前打印到第几页了 
        //private int m_currentPageIndex;

        /// <summary>
        /// 用来记录当前打印到第几页了
        /// </summary>
        private int m_currentPageIndex;

        /// <summary>
        /// 声明一个Stream对象的列表用来保存报表的输出数据,LocalReport对象的Render方法会将报表按页输出为多个Stream对象。
        /// </summary>
        private IList<Stream> m_streams;

        private bool isLandSapces = false;
        private void init_data()
        {
            sdsTotalCarCount = 0; sdsTotalTestCount = 0; sdsCjCount = 0; sdsFirstFjCount = 0; sdsSecondFjCount = 0; sdsFjCount = 0; sdsPassCount = 0;
            sdsCjPassCount = 0; sdsFirstFjPassCount = 0; sdsSecondFjPassCount = 0;

            sdsCjPassPercent = 0; sdsFirstFjPassPercent = 0; sdsSecondFjPassPercent = 0; sdsTotalPassPercent = 0;
            asmTotalCarCount = 0; asmTotalTestCount = 0; asmCjCount = 0; asmFirstFjCount = 0; asmFjCount = 0; asmSecondFjCount = 0; asmPassCount = 0;
            asmCjPassCount = 0; asmFirstFjPassCount = 0; asmSecondFjPassCount = 0;
            asmCjPassPercent = 0; asmFirstFjPassPercent = 0; asmSecondFjPassPercent = 0; asmTotalPassPercent = 0;
            btgTotalCarCount = 0; btgTotalTestCount = 0; btgCjCount = 0; btgFirstFjCount = 0; btgFjCount = 0; btgSecondFjCount = 0; btgPassCount = 0;
            btgCjPassCount = 0; btgFirstFjPassCount = 0; btgSecondFjPassCount = 0;
            btgCjPassPercent = 0; btgFirstFjPassPercent = 0; btgSecondFjPassPercent = 0; btgTotalPassPercent = 0;
            lugdownTotalCarCount = 0; lugdownTotalTestCount = 0; lugdownCjCount = 0; lugdownFirstFjCount = 0; lugdownFjCount = 0; lugdownSecondFjCount = 0; lugdownPassCount = 0;
            lugdownCjPassCount = 0; lugdownFirstFjPassCount = 0; lugdownSecondFjPassCount = 0;
            lugdownCjPassPercent = 0; lugdownFirstFjPassPercent = 0; lugdownSecondFjPassPercent = 0; lugdownTotalPassPercent = 0;
            TotalCarCount = 0; TotalTestCount = 0; CjCount = 0; FirstFjCount = 0; FjCount = 0; SecondFjCount = 0; PassCount = 0;
            TotalCjPassCount = 0; TotalFirstFjPassCount = 0; TotalSecondFjPassCount = 0;
            CjPassPercent = 0; FirstFjPassPercent = 0; SecondFjPassPercent = 0; TotalPassPercent = 0;
        }
        public dataQuery()
        {
            InitializeComponent();
        }

        private void dataQuery_Load(object sender, EventArgs e)
        {
            reportViewer2.LocalReport.ReleaseSandboxAppDomain();
            reportViewer2.LocalReport.Dispose();
            linesCount = mainPanel.stationcontrol.getStationLineCount(mainPanel.stationid);
            DataTable lineinfdt = mainPanel.stationcontrol.getStationLineInf(mainPanel.stationid);
            comboBoxJCXH.Items.Add("所有");
            for (int i = 1; i <= lineinfdt.Rows.Count; i++)
            {
                comboBoxJCXH.Items.Add(lineinfdt.Rows[i - 1]["LINEID"].ToString());
            }
            comboBoxJCXH.SelectedIndex = 0;
            //comboBox1.SelectedIndex = 0;
            //chart1.Series["Series1"].Label = "#PERCENT{P}";
            //chart1.Series["Series1"].LegendText = "#VALX";
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"]["PieLabelStyle"] = "Inside";//

            //chart2.Series["Series1"].Label = "#PERCENT{P}";
            //chart2.Series["Series1"].LegendText = "#VALX";
            chart2.Series["Series1"].IsValueShownAsLabel = true;
            chart2.Series["Series1"]["PieLabelStyle"] = "Inside";//

            //chart3.Series["Series1"].Label = "#PERCENT{P}";
            //chart3.Series["Series1"].LegendText = "#VALX";
            chart3.Series["Series1"].IsValueShownAsLabel = true;
            chart3.Series["Series1"]["PieLabelStyle"] = "Inside";//

            //chart4.Series["Series1"].Label = "#PERCENT{P}";
            //chart4.Series["Series1"].LegendText = "#VALX";
            chart4.Series["Series1"].IsValueShownAsLabel = true;
            chart4.Series["Series1"]["PieLabelStyle"] = "Inside";//

            //chart5.Series["Series1"].Label = "#PERCENT{P}";
            //chart5.Series["Series1"].LegendText = "#VALX";
            chart5.Series["Series1"].IsValueShownAsLabel = true;
            chart5.Series["Series1"]["PieLabelStyle"] = "Inside";//

            //chart6.Series["Series1"].Label = "#PERCENT{P}";
            //chart6.Series["Series1"].LegendText = "#VALX";
            chart6.Series["Series1"].IsValueShownAsLabel = true;
            chart6.Series["Series1"]["PieLabelStyle"] = "Inside";//
            init_report();
            comboBoxJCXH.SelectedIndex = 0;
            comboBox1.Text = "操作日志";
            textBox1.Text = "";
            kgjcff = mainPanel.stationinfmodel.STATIONJCFF;
            GKJCFFNAME = mainPanel.stationinfmodel.STATIONJCFF == "ASM" ? "稳态" : "简易瞬态";
            GKJCFFJC= (mainPanel.stationinfmodel.STATIONJCFF == "ASM" ? "稳态" : "瞬态");
            labelGKJCFF.Text = GKJCFFNAME + "统计";
            //button2_Click(sender, e);
            //ref_Money();

        }

        private void init_staffStastic()
        {
            staffinflist.Clear();
            string postid = basecontrol.getIDByName("引车员", "职位", "POSTID");
            DataTable dt = logininfcontrol.getStaffByPost(postid);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                staffInf thisstaff = new staffInf();
                thisstaff.name = dt.Rows[j]["NAME"].ToString();
                thisstaff.id = dt.Rows[j]["STAFFID"].ToString();
                int asmcjpass = 0;
                int asmcjnotpass = 0;
                int asmfj1pass = 0;
                int asmfj1notpass = 0;
                int asmfj2pass = 0;
                int asmfj2notpass = 0;
                double asmcjpassrate = 0;
                double asmfj1passrate = 0;
                double asmfj2passrate = 0;
                int sdscjpass = 0;
                int sdscjnotpass = 0;
                int sdsfj1pass = 0;
                int sdsfj1notpass = 0;
                int sdsfj2pass = 0;
                int sdsfj2notpass = 0;
                double sdscjpassrate = 0;
                double sdsfj1passrate = 0;
                double sdsfj2passrate = 0;
                int jzjscjpass = 0;
                int jzjscjnotpass = 0;
                int jzjsfj1pass = 0;
                int jzjsfj1notpass = 0;
                int jzjsfj2pass = 0;
                int jzjsfj2notpass = 0;
                double jzjscjpassrate = 0;
                double jzjsfj1passrate = 0;
                double jzjsfj2passrate = 0;
                int btgcjpass = 0;
                int btgcjnotpass = 0;
                int btgfj1pass = 0;
                int btgfj1notpass = 0;
                int btgfj2pass = 0;
                int btgfj2notpass = 0;
                double btgcjpassrate = 0;
                double btgfj1passrate = 0;
                double btgfj2passrate = 0;
                double totalcjpassrate = 0;
                double totalfj1passrate = 0;
                double totalfj2passrate = 0;
                double totalpassrate = 0;
                if (comboBoxJCXH.SelectedIndex == 0)
                {
                    string lineid = "";

                    for (int i = 1; i < comboBoxJCXH.Items.Count; i++)
                    {
                        lineid = comboBoxJCXH.Items[i].ToString();
                        asmcjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "1", thisstaff.name);
                        asmcjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "1", thisstaff.name);
                        asmfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "2", thisstaff.name);
                        asmfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "2", thisstaff.name);
                        asmfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "3", thisstaff.name);
                        asmfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "3", thisstaff.name);
                        sdscjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "1", thisstaff.name);
                        sdscjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "1", thisstaff.name);
                        sdsfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "2", thisstaff.name);
                        sdsfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "2", thisstaff.name);
                        sdsfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "3", thisstaff.name);
                        sdsfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "3", thisstaff.name);
                        jzjscjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "1", thisstaff.name);
                        jzjscjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "1", thisstaff.name);
                        jzjsfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "2", thisstaff.name);
                        jzjsfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "2", thisstaff.name);
                        jzjsfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "3", thisstaff.name);
                        jzjsfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "3", thisstaff.name);
                        btgcjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "1", thisstaff.name);
                        btgcjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "1", thisstaff.name);
                        btgfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "2", thisstaff.name);
                        btgfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "2", thisstaff.name);
                        btgfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "3", thisstaff.name);
                        btgfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "3", thisstaff.name);
                    }
                }
                else
                {
                    lineid = comboBoxJCXH.Text;
                    asmcjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ASM", "1", thisstaff.name);
                    asmcjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ASM", "1", thisstaff.name);
                    asmfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ASM", "2", thisstaff.name);
                    asmfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ASM", "2", thisstaff.name);
                    asmfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ASM", "3", thisstaff.name);
                    asmfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ASM", "3", thisstaff.name);
                    sdscjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "1", thisstaff.name);
                    sdscjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "1", thisstaff.name);
                    sdsfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "2", thisstaff.name);
                    sdsfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "2", thisstaff.name);
                    sdsfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "3", thisstaff.name);
                    sdsfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "3", thisstaff.name);
                    jzjscjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "1", thisstaff.name);
                    jzjscjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "1", thisstaff.name);
                    jzjsfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "2", thisstaff.name);
                    jzjsfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "2", thisstaff.name);
                    jzjsfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "3", thisstaff.name);
                    jzjsfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "3", thisstaff.name);
                    btgcjpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "1", thisstaff.name);
                    btgcjnotpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "1", thisstaff.name);
                    btgfj1pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "2", thisstaff.name);
                    btgfj1notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "2", thisstaff.name);
                    btgfj2pass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "3", thisstaff.name);
                    btgfj2notpass += logininfcontrol.getCarCountByStaff(lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "3", thisstaff.name);

                }
                thisstaff.asmcj = asmcjpass + asmcjnotpass;
                thisstaff.asmfj1 = asmfj1pass + asmfj1notpass;
                thisstaff.asmfj2 = asmfj2pass + asmfj2notpass;
                if (thisstaff.asmcj > 0)
                    asmcjpassrate = Math.Round(asmcjpass * 100.0 / (asmcjpass + asmcjnotpass), 1);
                if (thisstaff.asmfj1 > 0)
                    asmfj1passrate = Math.Round(asmfj1pass * 100.0 / (asmfj1pass + asmfj1notpass), 1);
                if (thisstaff.asmfj2 > 0)
                    asmfj2passrate = Math.Round(asmfj2pass * 100.0 / (asmfj2pass + asmfj2notpass), 1);
                thisstaff.asmcjpassrate = asmcjpassrate;
                thisstaff.asmfj1passrate = asmfj1passrate;
                thisstaff.asmfj2passrate = asmfj2passrate;

                thisstaff.sdscj = sdscjpass + sdscjnotpass;
                thisstaff.sdsfj1 = sdsfj1pass + sdsfj1notpass;
                thisstaff.sdsfj2 = sdsfj2pass + sdsfj2notpass;
                if (thisstaff.sdscj > 0)
                    sdscjpassrate = Math.Round(sdscjpass * 100.0 / (sdscjpass + sdscjnotpass), 1);
                if (thisstaff.sdsfj1 > 0)
                    sdsfj1passrate = Math.Round(sdsfj1pass * 100.0 / (sdsfj1pass + sdsfj1notpass), 1);
                if (thisstaff.sdsfj2 > 0)
                    sdsfj2passrate = Math.Round(sdsfj2pass * 100.0 / (sdsfj2pass + sdsfj2notpass), 1);
                thisstaff.sdscjpassrate = sdscjpassrate;
                thisstaff.sdsfj1passrate = sdsfj1passrate;
                thisstaff.sdsfj2passrate = sdsfj2passrate;

                thisstaff.jzjscj = jzjscjpass + jzjscjnotpass;
                thisstaff.jzjsfj1 = jzjsfj1pass + jzjsfj1notpass;
                thisstaff.jzjsfj2 = jzjsfj2pass + jzjsfj2notpass;
                if (thisstaff.jzjscj > 0)
                    jzjscjpassrate = Math.Round(jzjscjpass * 100.0 / (jzjscjpass + jzjscjnotpass), 1);
                if (thisstaff.jzjsfj1 > 0)
                    jzjsfj1passrate = Math.Round(jzjsfj1pass * 100.0 / (jzjsfj1pass + jzjsfj1notpass), 1);
                if (thisstaff.jzjsfj2 > 0)
                    jzjsfj2passrate = Math.Round(jzjsfj2pass * 100.0 / (jzjsfj2pass + jzjsfj2notpass), 1);
                thisstaff.jzjscjpassrate = jzjscjpassrate;
                thisstaff.jzjsfj1passrate = jzjsfj1passrate;
                thisstaff.jzjsfj2passrate = jzjsfj2passrate;

                thisstaff.btgcj = btgcjpass + btgcjnotpass;
                thisstaff.btgfj1 = btgfj1pass + btgfj1notpass;
                thisstaff.btgfj2 = btgfj2pass + btgfj2notpass;
                if (thisstaff.btgcj > 0)
                    btgcjpassrate = Math.Round(btgcjpass * 100.0 / (btgcjpass + btgcjnotpass), 1);
                if (thisstaff.btgfj1 > 0)
                    btgfj1passrate = Math.Round(btgfj1pass * 100.0 / (btgfj1pass + btgfj1notpass), 1);
                if (thisstaff.btgfj2 > 0)
                    btgfj2passrate = Math.Round(btgfj2pass * 100.0 / (btgfj2pass + btgfj2notpass), 1);
                thisstaff.btgcjpassrate = btgcjpassrate;
                thisstaff.btgfj1passrate = btgfj1passrate;
                thisstaff.btgfj2passrate = btgfj2passrate;


                thisstaff.totalcount = thisstaff.asmcj + thisstaff.asmfj1 + thisstaff.asmfj2 + thisstaff.sdscj + thisstaff.sdsfj1 + thisstaff.sdsfj2
                    + thisstaff.jzjscj + thisstaff.jzjsfj1 + thisstaff.jzjsfj2 + thisstaff.btgcj + thisstaff.btgfj1 + thisstaff.btgfj2;
                if (thisstaff.asmcj + thisstaff.sdscj + thisstaff.jzjscj + thisstaff.btgcj > 0)
                    totalcjpassrate = Math.Round((asmcjpass + sdscjpass + jzjscjpass + btgcjpass) * 100.0 / (double)(thisstaff.asmcj + thisstaff.sdscj + thisstaff.jzjscj + thisstaff.btgcj), 1);
                if (thisstaff.asmfj1 + thisstaff.sdsfj1 + thisstaff.jzjsfj1 + thisstaff.btgfj1 > 0)
                    totalfj1passrate = Math.Round((asmfj1pass + sdsfj1pass + jzjsfj1pass + btgfj1pass) * 100.0 / (double)(thisstaff.asmfj1 + thisstaff.sdsfj1 + thisstaff.jzjsfj1 + thisstaff.btgfj1), 1);

                if (thisstaff.asmfj2 + thisstaff.sdsfj2 + thisstaff.jzjsfj2 + thisstaff.btgfj2 > 0)
                    totalfj2passrate = Math.Round((asmfj2pass + sdsfj2pass + jzjsfj2pass + btgfj2pass) * 100.0 / (double)(thisstaff.asmfj2 + thisstaff.sdsfj2 + thisstaff.jzjsfj2 + thisstaff.btgfj2), 1);
                thisstaff.cjpassrate = totalcjpassrate;
                thisstaff.fj1passrate = totalfj1passrate;
                thisstaff.fj2passrate = totalfj2passrate;
                if (thisstaff.totalcount > 0)
                    totalpassrate = Math.Round((asmcjpass + sdscjpass + jzjscjpass + btgcjpass + asmfj1pass + sdsfj1pass + jzjsfj1pass + btgfj1pass + asmfj2pass + sdsfj2pass + jzjsfj2pass + btgfj2pass) * 100.0 / (thisstaff.totalcount), 1);
                thisstaff.totalpassrate = totalpassrate;
                staffinflist.Add(thisstaff);
            }
            DataTable dtstastic = new DataTable();         //创建一个datatable  
            dtstastic.Columns.Add("姓名", typeof(string));
            dtstastic.Columns.Add("编号", typeof(string));
            dtstastic.Columns.Add("稳态初检", typeof(int));
            dtstastic.Columns.Add("稳态1次复检", typeof(int));
            dtstastic.Columns.Add("稳态2次复检及以上", typeof(int));
            dtstastic.Columns.Add("稳态初检合格率", typeof(double));
            dtstastic.Columns.Add("稳态1次复检合格率", typeof(double));
            dtstastic.Columns.Add("稳态2次复检及以上合格率", typeof(double));
            dtstastic.Columns.Add("双怠速初检", typeof(int));
            dtstastic.Columns.Add("双怠速1次复检", typeof(int));
            dtstastic.Columns.Add("双怠速2次复检及以上", typeof(int));
            dtstastic.Columns.Add("双怠速初检合格率", typeof(double));
            dtstastic.Columns.Add("双怠速1次复检合格率", typeof(double));
            dtstastic.Columns.Add("双怠速2次复检及以上合格率", typeof(double));
            dtstastic.Columns.Add("加载减速初检", typeof(int));
            dtstastic.Columns.Add("加载减速1次复检", typeof(int));
            dtstastic.Columns.Add("加载减速2次复检及以上", typeof(int));
            dtstastic.Columns.Add("加载减速初检合格率", typeof(double));
            dtstastic.Columns.Add("加载减速1次复检合格率", typeof(double));
            dtstastic.Columns.Add("加载减速2次复检及以上合格率", typeof(double));
            dtstastic.Columns.Add("不透光初检", typeof(int));
            dtstastic.Columns.Add("不透光1次复检", typeof(int));
            dtstastic.Columns.Add("不透光2次复检及以上", typeof(int));
            dtstastic.Columns.Add("不透光初检合格率", typeof(double));
            dtstastic.Columns.Add("不透光1次复检合格率", typeof(double));
            dtstastic.Columns.Add("不透光2次复检及以上合格率", typeof(double));
            dtstastic.Columns.Add("总检次数", typeof(int));
            dtstastic.Columns.Add("总初检合格率", typeof(double));
            dtstastic.Columns.Add("总1次复检合格率", typeof(double));
            dtstastic.Columns.Add("总2次复检及以上合格率", typeof(double));
            dtstastic.Columns.Add("总合格率", typeof(double));
            int count = staffinflist.Count;
            for (int i = 0; i < count; i++)
            {
                dtstastic.Rows.Add(staffinflist[i].name, staffinflist[i].id,
                    staffinflist[i].asmcj, staffinflist[i].asmfj1, staffinflist[i].asmfj2,
                    staffinflist[i].asmcjpassrate, staffinflist[i].asmfj1passrate, staffinflist[i].asmfj2passrate,
                    staffinflist[i].sdscj, staffinflist[i].sdsfj1, staffinflist[i].sdsfj2,
                     staffinflist[i].sdscjpassrate, staffinflist[i].sdsfj1passrate, staffinflist[i].sdsfj2passrate,
                    staffinflist[i].jzjscj, staffinflist[i].jzjsfj1, staffinflist[i].jzjsfj2,
                     staffinflist[i].jzjscjpassrate, staffinflist[i].jzjsfj1passrate, staffinflist[i].jzjsfj2passrate,
                    staffinflist[i].btgcj, staffinflist[i].btgfj1, staffinflist[i].btgfj2,
                     staffinflist[i].btgcjpassrate, staffinflist[i].btgfj1passrate, staffinflist[i].btgfj2passrate,
                    staffinflist[i].totalcount,
                     staffinflist[i].cjpassrate, staffinflist[i].fj1passrate, staffinflist[i].fj2passrate,
                     staffinflist[i].totalpassrate
                    );

            }
            //reportViewer2.LocalReport.ReleaseSandboxAppDomain();
            //reportViewer2.LocalReport.Dispose();
            //reportViewer2.Visible = true;
            ReportParameter[] rptpara =
            {
                    new ReportParameter("parameterJcrq",dateTimeStartTime.Value.ToString("yyyy-MM-dd")+"~"+dateTimeEndtTime.Value.ToString("yyyy-MM-dd")),
                    new ReportParameter("parameterGKJCFF",GKJCFFJC),
                    new ReportParameter("parameterTjxh",comboBoxJCXH.Text)
            };
            this.reportViewer2.LocalReport.ReportPath = @".\ReportStaff.rdlc";  //查找要绑定的报表  
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.SetParameters(rptpara);
            this.reportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dtstastic));  //绑定数据源 
            reportViewer2.RefreshReport();
        }
        private void init_report()
        {
            //reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer1.LocalReport.Dispose();
            reportViewer1.Visible = true;
            string teststring = DateTime.Now.ToShortDateString();
            try
            {
                rptpara = new ReportParameter[]
                {
                    new ReportParameter("parameterStationName",mainPanel.stationinfmodel.STATIONNAME),
                    new ReportParameter("parameterTjrq",DateTime.Now.ToString("yyyy年MM月dd日")),
                    new ReportParameter("parameterTjtj", dateTimeStartTime.Value.ToString("yyyy年MM月dd日")+"-"+dateTimeEndtTime.Value.ToString("yyyy年MM月dd日")),
                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                    new ReportParameter("parameterJcxh", comboBoxJCXH.Text),
                    new ReportParameter("parameterSdsSxzs",sdsTotalCarCount.ToString()),
                    new ReportParameter("parameterSdsClzs", sdsTotalTestCount.ToString()),
                    new ReportParameter("parameterSdsCjcls", sdsCjCount.ToString()),
                    new ReportParameter("parameterSdsCjhgl",(sdsCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsFjccs",sdsFjCount.ToString()),
                    new ReportParameter("parameterSdsDycfjcls",sdsFirstFjCount.ToString()),
                    new ReportParameter("parameterSdsDycfjhgl", (sdsFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsDecfjcls", sdsSecondFjCount.ToString()),
                    new ReportParameter("parameterSdsDecfjhgl",(sdsSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsZzhgcls",sdsPassCount.ToString()),
                    new ReportParameter("parameterSdsZzhgl",(sdsTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterAsmSxzs",asmTotalCarCount.ToString()),
                    new ReportParameter("parameterAsmClzs", asmTotalTestCount.ToString()),
                    new ReportParameter("parameterAsmCjcls", asmCjCount.ToString()),
                    new ReportParameter("parameterAsmCjhgl",(asmCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmFjccs",asmFjCount.ToString()),
                    new ReportParameter("parameterAsmDycfjcls",asmFirstFjCount.ToString()),
                    new ReportParameter("parameterAsmDycfjhgl", (asmFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmDecfjcls", asmSecondFjCount.ToString()),
                    new ReportParameter("parameterAsmDecfjhgl",(asmSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmZzhgcls",asmPassCount.ToString()),
                    new ReportParameter("parameterAsmZzhgl",(asmTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterBtgSxzs",btgTotalCarCount.ToString()),
                    new ReportParameter("parameterBtgClzs", btgTotalTestCount.ToString()),
                    new ReportParameter("parameterBtgCjcls", btgCjCount.ToString()),
                    new ReportParameter("parameterBtgCjhgl",(btgCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgFjccs",btgFjCount.ToString()),
                    new ReportParameter("parameterBtgDycfjcls",btgFirstFjCount.ToString()),
                    new ReportParameter("parameterBtgDycfjhgl", (btgFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgDecfjcls", btgSecondFjCount.ToString()),
                    new ReportParameter("parameterBtgDecfjhgl",(btgSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgZzhgcls",btgPassCount.ToString()),
                    new ReportParameter("parameterBtgZzhgl",(btgTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterLugdownSxzs",lugdownTotalCarCount.ToString()),
                    new ReportParameter("parameterLugdownClzs", lugdownTotalTestCount.ToString()),
                    new ReportParameter("parameterLugdownCjcls", lugdownCjCount.ToString()),
                    new ReportParameter("parameterLugdownCjhgl",(lugdownCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownFjccs",lugdownFjCount.ToString()),
                    new ReportParameter("parameterLugdownDycfjcls",lugdownFirstFjCount.ToString()),
                    new ReportParameter("parameterLugdownDycfjhgl", (lugdownFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownDecfjcls", lugdownSecondFjCount.ToString()),
                    new ReportParameter("parameterLugdownDecfjhgl",(lugdownSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownZzhgcls",lugdownPassCount.ToString()),
                    new ReportParameter("parameterLugdownZzhgl",(lugdownTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterTotalSxzs",TotalCarCount.ToString()),
                    new ReportParameter("parameterTotalClzs", TotalTestCount.ToString()),
                    new ReportParameter("parameterTotalCjcls", CjCount.ToString()),
                    new ReportParameter("parameterTotalCjhgl",(CjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalFjccs",FjCount.ToString()),
                    new ReportParameter("parameterTotalDycfjcls",FirstFjCount.ToString()),
                    new ReportParameter("parameterTotalDycfjhgl", (FirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalDecfjcls", SecondFjCount.ToString()),
                    new ReportParameter("parameterTotalDecfjhgl",(SecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalZzhgcls",PassCount.ToString()),
                    new ReportParameter("parameterTotalZzhgl",(TotalPassPercent*100).ToString("0.0")+"%")
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

        private void dataQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            demarcateControl demarcatecontrol = new demarcateControl();
            DataTable datagrid = demarcatecontrol.getAllDemarcateLog(dateTimePickerStart.Value, dateTimePickerEnd.Value, mainPanel.stationid, textBox1.Text, comboBox1.Text);
            if (datagrid.Rows.Count > 0)
            {
                //datagrid.Rows.RemoveAt(0);
                //setDataGridView(datagrid);
                dataGridView1.DataSource = datagrid;
                switch (comboBox1.Text)
                {
                    case "废气仪检查":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["CO2BZ"].HeaderText = "CO2标值";
                        dataGridView1.Columns["CO2CLZ"].HeaderText = "CO2测量值";
                        dataGridView1.Columns["COBZ"].HeaderText = "CO标值";
                        dataGridView1.Columns["COCLZ"].HeaderText = "CO测量值";
                        dataGridView1.Columns["HCBZ"].HeaderText = "HC标值";
                        dataGridView1.Columns["HCCLZ"].HeaderText = "HC测量值";
                        dataGridView1.Columns["NOBZ"].HeaderText = "NO标值";
                        dataGridView1.Columns["NOCLZ"].HeaderText = "NO测量值";
                        dataGridView1.Columns["JZDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["GDJZ"].HeaderText = "高低校准";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;

                    case "废气仪标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["CO2BZ"].HeaderText = "CO2标值";
                        dataGridView1.Columns["CO2CLZ"].HeaderText = "CO2测量值";
                        dataGridView1.Columns["COBZ"].HeaderText = "CO标值";
                        dataGridView1.Columns["COCLZ"].HeaderText = "CO测量值";
                        dataGridView1.Columns["HCBZ"].HeaderText = "HC标值";
                        dataGridView1.Columns["HCCLZ"].HeaderText = "HC测量值";
                        dataGridView1.Columns["NOBZ"].HeaderText = "NO标值";
                        dataGridView1.Columns["NOCLZ"].HeaderText = "NO测量值";
                        dataGridView1.Columns["JZDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["GDJZ"].HeaderText = "高低校准";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "流量计标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["O2GLCBZ"].HeaderText = "O2高量程浓度";
                        dataGridView1.Columns["O2GLCCLZ"].HeaderText = "O2高量程测量值";
                        dataGridView1.Columns["O2GLCWC"].HeaderText = "O2高量程误差";
                        dataGridView1.Columns["O2DLCBZ"].HeaderText = "O2低量程浓度";
                        dataGridView1.Columns["O2DLCCLZ"].HeaderText = "O2低量程测量值";
                        dataGridView1.Columns["O2DLCWC"].HeaderText = "O2低量程误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "烟度计标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["KBZ"].HeaderText = "K标值";
                        dataGridView1.Columns["KSCZ"].HeaderText = "K测量值";
                        dataGridView1.Columns["KABSWC"].HeaderText = "K绝对误差";
                        dataGridView1.Columns["KRELWC"].HeaderText = "K相对误差";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "气象站校准":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["WDBZ"].HeaderText = "温度标值";
                        dataGridView1.Columns["WDSCZ"].HeaderText = "温度测量值";
                        dataGridView1.Columns["SDBZ"].HeaderText = "湿度标值";
                        dataGridView1.Columns["SDSCZ"].HeaderText = "湿度实测值";
                        dataGridView1.Columns["DQYBZ"].HeaderText = "大气压标值";
                        dataGridView1.Columns["DQYSCZ"].HeaderText = "大气压实测值";
                        dataGridView1.Columns["WDWC"].HeaderText = "湿度误差";
                        dataGridView1.Columns["SDWC"].HeaderText = "湿度误差";
                        dataGridView1.Columns["DQYWC"].HeaderText = "大气压误差";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "惯量测试试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["T1POWER"].HeaderText = "f1";
                        dataGridView1.Columns["T2POWER"].HeaderText = "f2";
                        dataGridView1.Columns["STARTSPEED"].HeaderText = "初速度";
                        dataGridView1.Columns["ENDSPEED"].HeaderText = "末速度";
                        dataGridView1.Columns["ACD1_1"].HeaderText = "t1_1";
                        dataGridView1.Columns["ACD1_2"].HeaderText = "t1_2";
                        dataGridView1.Columns["ACD1_3"].HeaderText = "t1_3";
                        dataGridView1.Columns["ACD1"].HeaderText = "t1";
                        dataGridView1.Columns["ACD2_1"].HeaderText = "t2_1";
                        dataGridView1.Columns["ACD2_2"].HeaderText = "t2_2";
                        dataGridView1.Columns["ACD2_3"].HeaderText = "t2_3";
                        dataGridView1.Columns["ACD2"].HeaderText = "t2";
                        dataGridView1.Columns["DIW_1"].HeaderText = "DIW1";
                        dataGridView1.Columns["DIW_2"].HeaderText = "DIW2";
                        dataGridView1.Columns["DIW_3"].HeaderText = "DIW3";
                        dataGridView1.Columns["DIW"].HeaderText = "DIW";
                        dataGridView1.Columns["DIW_BC"].HeaderText = "标称DIW";
                        dataGridView1.Columns["DIW_SC"].HeaderText = "实测DIW";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["PD"].HeaderText = "判定";
                        dataGridView1.Columns["HXSJ"].HeaderText = "滑行时间";
                        dataGridView1.Columns["BZ"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "寄生功率试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["SDQJ"].HeaderText = "速度区间";
                        dataGridView1.Columns["MYSD"].HeaderText = "名义速度";
                        dataGridView1.Columns["HXSJ"].HeaderText = "滑行时间";
                        dataGridView1.Columns["JSGL"].HeaderText = "寄生功率";
                        dataGridView1.Columns["LJHXSJ"].HeaderText = "累计滑行时间";
                        dataGridView1.Columns["BZ"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "加载滑行试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["HXQJ"].HeaderText = "滑行区间";
                        dataGridView1.Columns["QJMYSD"].HeaderText = "区间名义速度";
                        dataGridView1.Columns["CCDT"].HeaderText = "理论滑行时间";
                        dataGridView1.Columns["PLHP"].HeaderText = "寄生功率";
                        dataGridView1.Columns["ACDT"].HeaderText = "实际滑行时间";
                        dataGridView1.Columns["JZSDGL"].HeaderText = "加载功率(kW)";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "变载荷滑行测试":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["HXQJ"].HeaderText = "滑行区间";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["CCDT"].HeaderText = "理论滑行时间";
                        dataGridView1.Columns["ACDT"].HeaderText = "实际滑行时间";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "响应时间测试":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["SPEED"].HeaderText = "速度点";
                        dataGridView1.Columns["STARTPOWER"].HeaderText = "初功率";
                        dataGridView1.Columns["STARTFORCE"].HeaderText = "初扭力";
                        dataGridView1.Columns["ENDPOWER"].HeaderText = "末功率";
                        dataGridView1.Columns["ENDFORCE"].HeaderText = "末扭力";
                        dataGridView1.Columns["XYTIME"].HeaderText = "响应时间";
                        dataGridView1.Columns["WDTIME"].HeaderText = "稳定时间";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "扭力标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["BZ1"].HeaderText = "标值1";
                        dataGridView1.Columns["CLZ1"].HeaderText = "测量值1";
                        dataGridView1.Columns["BZ2"].HeaderText = "标值2";
                        dataGridView1.Columns["CLZ2"].HeaderText = "测量值2";
                        dataGridView1.Columns["BZ3"].HeaderText = "标值3";
                        dataGridView1.Columns["CLZ3"].HeaderText = "测量值31";
                        dataGridView1.Columns["BZ4"].HeaderText = "标值4";
                        dataGridView1.Columns["CLZ4"].HeaderText = "测量值4";
                        dataGridView1.Columns["BZ5"].HeaderText = "标值5";
                        dataGridView1.Columns["CLZ5"].HeaderText = "测量值5";
                        dataGridView1.Columns["WC1"].HeaderText = "误差1";
                        dataGridView1.Columns["WC2"].HeaderText = "误差2";
                        dataGridView1.Columns["WC3"].HeaderText = "误差3";
                        dataGridView1.Columns["WC4"].HeaderText = "误差4";
                        dataGridView1.Columns["WC5"].HeaderText = "误差5";
                        dataGridView1.Columns["BDDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "速度标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["BZ1"].HeaderText = "标值1";
                        dataGridView1.Columns["CLZ1"].HeaderText = "测量值1";
                        dataGridView1.Columns["BZ2"].HeaderText = "标值2";
                        dataGridView1.Columns["CLZ2"].HeaderText = "测量值2";
                        dataGridView1.Columns["BZ3"].HeaderText = "标值3";
                        dataGridView1.Columns["CLZ3"].HeaderText = "测量值31";
                        dataGridView1.Columns["WC1"].HeaderText = "误差1";
                        dataGridView1.Columns["WC2"].HeaderText = "误差2";
                        dataGridView1.Columns["WC3"].HeaderText = "误差3";
                        dataGridView1.Columns["BDDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "操作日志":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["PROID"].HeaderText = "操作编号";
                        dataGridView1.Columns["PRONAME"].HeaderText = "操作项目";
                        dataGridView1.Columns["DATA"].HeaderText = "数据";
                        dataGridView1.Columns["STATE"].HeaderText = "状态";
                        dataGridView1.Columns["RESULT"].HeaderText = "结果";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    default: break;
                }
            }
            else
            {
                MessageBox.Show("没有找到相关记录");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loginInfControl logininfcontrol = new loginInfControl();
            bool up = radioButton1.Checked;
            DataTable dtcarinf = logininfcontrol.getAllCarInf("已检车辆信息", dateTimePicker1.Value, dateTimePicker2.Value, up);
            setDataGridView(dtcarinf);
        }
        public void setDataGridView(DataTable dt)
        {
            dataGridView2.DataSource = dt;
            int count = dataGridView2.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dtToSave = new DataTable();
            dtToSave.Columns.Add("CLHP");
            dtToSave.Columns.Add("JCSJ");
            dtToSave.Columns.Add("LINEID");
            dtToSave.Columns.Add("JCFF");
            dtToSave.Columns.Add("LSH");
            dtToSave.Columns.Add("ZXBZ");
            dtToSave.Columns.Add("CPYS");
            dtToSave.Columns.Add("HDZK");
            dtToSave.Columns.Add("ZZL");
            dtToSave.Columns.Add("RLZL");
            dtToSave.Columns.Add("ZCRQ");
            dtToSave.Columns.Add("XH");
            dtToSave.Columns.Add("XSLC");
            dtToSave.Columns.Add("CZ");
            dtToSave.Columns.Add("PP");
            dtToSave.Columns.Add("SYXZ");
            dtToSave.Columns.Add("SCQY");
            dtToSave.Columns.Add("CLSBM");
            dtToSave.Columns.Add("SCRQ");
            dtToSave.Columns.Add("CLLX");
            dtToSave.Columns.Add("FDJHM");
            DataRow dr = null;
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dr = dtToSave.NewRow();
                    dr["CLHP"] = dataGridView2.Rows[i].Cells["CLHP"].Value.ToString();
                    dr["JCSJ"] = dataGridView2.Rows[i].Cells["JCSJ"].Value.ToString();
                    dr["LINEID"] = dataGridView2.Rows[i].Cells["LINEID"].Value.ToString();
                    dr["JCFF"] = dataGridView2.Rows[i].Cells["JCFF"].Value.ToString();
                    dr["LSH"] = dataGridView2.Rows[i].Cells["LSH"].Value.ToString();
                    dr["ZXBZ"] = dataGridView2.Rows[i].Cells["ZXBZ"].Value.ToString();
                    dr["CPYS"] = dataGridView2.Rows[i].Cells["CPYS"].Value.ToString();
                    dr["HDZK"] = dataGridView2.Rows[i].Cells["HDZK"].Value.ToString();
                    dr["ZZL"] = dataGridView2.Rows[i].Cells["ZZL"].Value.ToString();
                    dr["RLZL"] = dataGridView2.Rows[i].Cells["RLZL"].Value.ToString();
                    dr["ZCRQ"] = dataGridView2.Rows[i].Cells["ZCRQ"].Value.ToString();
                    dr["XH"] = dataGridView2.Rows[i].Cells["XH"].Value.ToString();
                    dr["XSLC"] = dataGridView2.Rows[i].Cells["XSLC"].Value.ToString();
                    dr["CZ"] = dataGridView2.Rows[i].Cells["CZ"].Value.ToString();
                    dr["PP"] = dataGridView2.Rows[i].Cells["PP"].Value.ToString();
                    dr["SYXZ"] = dataGridView2.Rows[i].Cells["SYXZ"].Value.ToString();
                    dr["SCQY"] = dataGridView2.Rows[i].Cells["SCQY"].Value.ToString();
                    dr["CLSBM"] = dataGridView2.Rows[i].Cells["CLSBM"].Value.ToString();
                    dr["SCRQ"] = dataGridView2.Rows[i].Cells["SCRQ"].Value.ToString();
                    dr["CLLX"] = dataGridView2.Rows[i].Cells["CLLX"].Value.ToString();
                    dr["FDJHM"] = dataGridView2.Rows[i].Cells["FDJHM"].Value.ToString();
                    dtToSave.Rows.Add(dr);
                }
                writeExcel.writeDatatableToElt(dtToSave);
            }
            else
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "操作日志")
            {
                DataTable dtToSave = new DataTable();
                dtToSave.Columns.Add("PRONAME");
                dtToSave.Columns.Add("STATIONID");
                dtToSave.Columns.Add("LINEID");
                dtToSave.Columns.Add("CZY");
                dtToSave.Columns.Add("DATA");
                dtToSave.Columns.Add("STATE");
                dtToSave.Columns.Add("RESULT");
                dtToSave.Columns.Add("BDRQ");
                dtToSave.Columns.Add("BZSM");
                DataRow dr = null;
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dr = dtToSave.NewRow();
                        dr["PRONAME"] = dataGridView1.Rows[i].Cells["PRONAME"].Value.ToString();
                        dr["STATIONID"] = dataGridView1.Rows[i].Cells["STATIONID"].Value.ToString();
                        dr["LINEID"] = dataGridView1.Rows[i].Cells["LINEID"].Value.ToString();
                        dr["CZY"] = dataGridView1.Rows[i].Cells["CZY"].Value.ToString();
                        dr["DATA"] = dataGridView1.Rows[i].Cells["DATA"].Value.ToString();
                        dr["STATE"] = dataGridView1.Rows[i].Cells["STATE"].Value.ToString();
                        dr["RESULT"] = dataGridView1.Rows[i].Cells["RESULT"].Value.ToString();
                        dr["BDRQ"] = dataGridView1.Rows[i].Cells["BDRQ"].Value.ToString();
                        dr["BZSM"] = dataGridView1.Rows[i].Cells["BZSM"].Value.ToString();
                        dtToSave.Rows.Add(dr);
                    }
                    writeExcel.writelogDatatableToElt(dtToSave);
                }
                else
                { }
            }
            else
            {
                demarcateControl demarcatecontrol = new demarcateControl();
                DataTable datagrid = demarcatecontrol.getAllDemarcateLog(dateTimePickerStart.Value, dateTimePickerEnd.Value, mainPanel.stationid, textBox1.Text, comboBox1.Text);
                if (datagrid.Rows.Count > 0)
                {
                    //datagrid.Rows.RemoveAt(0);
                    //setDataGridView(datagrid);
                    DataTable dtToSave = new DataTable();
                    DataRow dr = null;
                    //dataGridView1.DataSource = datagrid;
                    switch (comboBox1.Text)
                    {
                        case "废气仪检查":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("CO2BZ");
                            dtToSave.Columns.Add("CO2CLZ");
                            dtToSave.Columns.Add("COBZ");
                            dtToSave.Columns.Add("COCLZ");
                            dtToSave.Columns.Add("HCBZ");
                            dtToSave.Columns.Add("HCCLZ");
                            dtToSave.Columns.Add("NOBZ");
                            dtToSave.Columns.Add("NOCLZ");
                            dtToSave.Columns.Add("JZDS");
                            dtToSave.Columns.Add("GDJZ");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["CO2BZ"] = "CO2标值";
                            dr["CO2CLZ"] = "CO2测量值";
                            dr["COBZ"] = "CO标值";
                            dr["COCLZ"] = "CO测量值";
                            dr["HCBZ"] = "HC标值";
                            dr["HCCLZ"] = "HC测量值";
                            dr["NOBZ"] = "NO标值";
                            dr["NOCLZ"] = "NO测量值";
                            dr["JZDS"] = "校准点数";
                            dr["GDJZ"] = "高低校准";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["CO2BZ"] = datagrid.Rows[i]["CO2BZ"].ToString();
                                    dr["CO2CLZ"] = datagrid.Rows[i]["CO2CLZ"].ToString();
                                    dr["COBZ"] = datagrid.Rows[i]["COBZ"].ToString();
                                    dr["COCLZ"] = datagrid.Rows[i]["COCLZ"].ToString();
                                    dr["HCBZ"] = datagrid.Rows[i]["HCBZ"].ToString();
                                    dr["HCCLZ"] = datagrid.Rows[i]["HCCLZ"].ToString();
                                    dr["NOBZ"] = datagrid.Rows[i]["NOBZ"].ToString();
                                    dr["NOCLZ"] = datagrid.Rows[i]["NOCLZ"].ToString();
                                    dr["JZDS"] = datagrid.Rows[i]["JZDS"].ToString();
                                    dr["GDJZ"] = datagrid.Rows[i]["GDJZ"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "废气仪检查");
                            }
                            break;

                        case "烟度计标定":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("KBZ");
                            dtToSave.Columns.Add("KSCZ");
                            dtToSave.Columns.Add("KABSWC");
                            dtToSave.Columns.Add("KRELWC");
                            dtToSave.Columns.Add("CZY");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["KBZ"] = "K标值";
                            dr["KSCZ"] = "K测量值";
                            dr["KABSWC"] = "K绝对误差";
                            dr["KRELWC"] = "K相对误差";
                            dr["CZY"] = "操作员";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["KBZ"] = datagrid.Rows[i]["KBZ"].ToString();
                                    dr["KSCZ"] = datagrid.Rows[i]["KSCZ"].ToString();
                                    dr["KABSWC"] = datagrid.Rows[i]["KABSWC"].ToString();
                                    dr["KRELWC"] = datagrid.Rows[i]["KRELWC"].ToString();
                                    dr["CZY"] = datagrid.Rows[i]["CZY"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "烟度计标定");
                            }
                            break;
                        case "废气仪标定":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("CO2BZ");
                            dtToSave.Columns.Add("CO2CLZ");
                            dtToSave.Columns.Add("COBZ");
                            dtToSave.Columns.Add("COCLZ");
                            dtToSave.Columns.Add("HCBZ");
                            dtToSave.Columns.Add("HCCLZ");
                            dtToSave.Columns.Add("NOBZ");
                            dtToSave.Columns.Add("NOCLZ");
                            dtToSave.Columns.Add("JZDS");
                            dtToSave.Columns.Add("GDJZ");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["CO2BZ"] = "CO2标值";
                            dr["CO2CLZ"] = "CO2测量值";
                            dr["COBZ"] = "CO标值";
                            dr["COCLZ"] = "CO测量值";
                            dr["HCBZ"] = "HC标值";
                            dr["HCCLZ"] = "HC测量值";
                            dr["NOBZ"] = "NO标值";
                            dr["NOCLZ"] = "NO测量值";
                            dr["JZDS"] = "校准点数";
                            dr["GDJZ"] = "高低校准";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["CO2BZ"] = datagrid.Rows[i]["CO2BZ"].ToString();
                                    dr["CO2CLZ"] = datagrid.Rows[i]["CO2CLZ"].ToString();
                                    dr["COBZ"] = datagrid.Rows[i]["COBZ"].ToString();
                                    dr["COCLZ"] = datagrid.Rows[i]["COCLZ"].ToString();
                                    dr["HCBZ"] = datagrid.Rows[i]["HCBZ"].ToString();
                                    dr["HCCLZ"] = datagrid.Rows[i]["HCCLZ"].ToString();
                                    dr["NOBZ"] = datagrid.Rows[i]["NOBZ"].ToString();
                                    dr["NOCLZ"] = datagrid.Rows[i]["NOCLZ"].ToString();
                                    dr["JZDS"] = datagrid.Rows[i]["JZDS"].ToString();
                                    dr["GDJZ"] = datagrid.Rows[i]["GDJZ"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "废气仪标定");
                            }
                            break;
                        case "流量计标定":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("O2GLCBZ");
                            dtToSave.Columns.Add("O2GLCCLZ");
                            dtToSave.Columns.Add("O2GLCWC");
                            dtToSave.Columns.Add("O2DLCBZ");
                            dtToSave.Columns.Add("O2DLCCLZ");
                            dtToSave.Columns.Add("O2DLCWC");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["O2GLCBZ"] = "O2高量程浓度";
                            dr["O2GLCCLZ"] = "O2高量程测量值";
                            dr["O2GLCWC"] = "O2高量程误差";
                            dr["O2DLCBZ"] = "O2低量程浓度";
                            dr["O2DLCCLZ"] = "O2低量程测量值";
                            dr["O2DLCWC"] = "O2低量程误差";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["O2GLCBZ"] = datagrid.Rows[i]["O2GLCBZ"].ToString();
                                    dr["O2GLCCLZ"] = datagrid.Rows[i]["O2GLCCLZ"].ToString();
                                    dr["O2GLCWC"] = datagrid.Rows[i]["O2GLCWC"].ToString();
                                    dr["O2DLCBZ"] = datagrid.Rows[i]["O2DLCBZ"].ToString();
                                    dr["O2DLCCLZ"] = datagrid.Rows[i]["O2DLCCLZ"].ToString();
                                    dr["O2DLCWC"] = datagrid.Rows[i]["O2DLCWC"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "流量计标定");
                            }
                            break;
                        case "气象站校准":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("WDBZ");
                            dtToSave.Columns.Add("WDSCZ");
                            dtToSave.Columns.Add("SDBZ");
                            dtToSave.Columns.Add("SDSCZ");
                            dtToSave.Columns.Add("DQYBZ");
                            dtToSave.Columns.Add("DQYSCZ");
                            dtToSave.Columns.Add("WDWC");
                            dtToSave.Columns.Add("SDWC");
                            dtToSave.Columns.Add("DQYWC");
                            dtToSave.Columns.Add("CZY");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["WDBZ"] = "温度标值";
                            dr["WDSCZ"] = "温度测量值";
                            dr["SDBZ"] = "湿度标值";
                            dr["SDSCZ"] = "湿度实测值";
                            dr["DQYBZ"] = "大气压标值";
                            dr["DQYSCZ"] = "大气压实测值";
                            dr["WDWC"] = "湿度误差";
                            dr["SDWC"] = "湿度误差";
                            dr["DQYWC"] = "大气压误差";
                            dr["CZY"] = "操作员";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["WDBZ"] = datagrid.Rows[i]["WDBZ"].ToString();
                                    dr["WDSCZ"] = datagrid.Rows[i]["WDSCZ"].ToString();
                                    dr["SDBZ"] = datagrid.Rows[i]["SDBZ"].ToString();
                                    dr["SDSCZ"] = datagrid.Rows[i]["SDSCZ"].ToString();
                                    dr["DQYBZ"] = datagrid.Rows[i]["DQYBZ"].ToString();
                                    dr["DQYSCZ"] = datagrid.Rows[i]["DQYSCZ"].ToString();
                                    dr["WDWC"] = datagrid.Rows[i]["WDWC"].ToString();
                                    dr["SDWC"] = datagrid.Rows[i]["SDWC"].ToString();
                                    dr["DQYWC"] = datagrid.Rows[i]["DQYWC"].ToString();
                                    dr["CZY"] = datagrid.Rows[i]["CZY"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "气象站标定");
                            }
                            break;
                        case "惯量测试试验":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("T1POWER");
                            dtToSave.Columns.Add("T2POWER");
                            dtToSave.Columns.Add("STARTSPEED");
                            dtToSave.Columns.Add("ENDSPEED");
                            dtToSave.Columns.Add("ACD1_1");
                            dtToSave.Columns.Add("ACD1_2");
                            dtToSave.Columns.Add("ACD1_3");
                            dtToSave.Columns.Add("ACD1");
                            dtToSave.Columns.Add("ACD2_1");
                            dtToSave.Columns.Add("ACD2_2");
                            dtToSave.Columns.Add("ACD2_3");
                            dtToSave.Columns.Add("ACD2");
                            dtToSave.Columns.Add("DIW_1");
                            dtToSave.Columns.Add("DIW_2");
                            dtToSave.Columns.Add("DIW_3");
                            dtToSave.Columns.Add("DIW");
                            dtToSave.Columns.Add("DIW_BC");
                            dtToSave.Columns.Add("DIW_SC");
                            dtToSave.Columns.Add("WC");
                            dtToSave.Columns.Add("PD");
                            dtToSave.Columns.Add("HXSJ");
                            dtToSave.Columns.Add("BZ");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["T1POWER"] = "f1";
                            dr["T2POWER"] = "f2";
                            dr["STARTSPEED"] = "初速度";
                            dr["ENDSPEED"] = "末速度";
                            dr["ACD1_1"] = "t1_1";
                            dr["ACD1_2"] = "t1_2";
                            dr["ACD1_3"] = "t1_3";
                            dr["ACD1"] = "t1";
                            dr["ACD2_1"] = "t2_1";
                            dr["ACD2_2"] = "t2_2";
                            dr["ACD2_3"] = "t2_3";
                            dr["ACD2"] = "t2";
                            dr["DIW_1"] = "DIW1";
                            dr["DIW_2"] = "DIW2";
                            dr["DIW_3"] = "DIW3";
                            dr["DIW"] = "DIW";
                            dr["DIW_BC"] = "标称DIW";
                            dr["DIW_SC"] = "实测DIW";
                            dr["WC"] = "误差";
                            dr["PD"] = "判定";
                            dr["HXSJ"] = "滑行时间";
                            dr["BZ"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["T1POWER"] = datagrid.Rows[i]["T1POWER"].ToString();
                                    dr["T2POWER"] = datagrid.Rows[i]["T2POWER"].ToString();
                                    dr["STARTSPEED"] = datagrid.Rows[i]["STARTSPEED"].ToString();
                                    dr["ENDSPEED"] = datagrid.Rows[i]["ENDSPEED"].ToString();
                                    dr["ACD1_1"] = datagrid.Rows[i]["ACD1_1"].ToString();
                                    dr["ACD1_2"] = datagrid.Rows[i]["ACD1_2"].ToString();
                                    dr["ACD1_3"] = datagrid.Rows[i]["ACD1_3"].ToString();
                                    dr["ACD1"] = datagrid.Rows[i]["ACD1"].ToString();
                                    dr["ACD2_1"] = datagrid.Rows[i]["ACD2_1"].ToString();
                                    dr["ACD2_2"] = datagrid.Rows[i]["ACD2_2"].ToString();
                                    dr["ACD2_3"] = datagrid.Rows[i]["ACD2_3"].ToString();
                                    dr["ACD2"] = datagrid.Rows[i]["ACD2"].ToString();
                                    dr["DIW_1"] = datagrid.Rows[i]["DIW_1"].ToString();
                                    dr["DIW_2"] = datagrid.Rows[i]["DIW_2"].ToString();
                                    dr["DIW_3"] = datagrid.Rows[i]["DIW_3"].ToString();
                                    dr["DIW"] = datagrid.Rows[i]["DIW"].ToString();
                                    dr["DIW_BC"] = datagrid.Rows[i]["DIW_BC"].ToString();
                                    dr["DIW_SC"] = datagrid.Rows[i]["DIW_SC"].ToString();
                                    dr["WC"] = datagrid.Rows[i]["WC"].ToString();
                                    dr["PD"] = datagrid.Rows[i]["PD"].ToString();
                                    dr["HXSJ"] = datagrid.Rows[i]["HXSJ"].ToString();
                                    dr["BZ"] = datagrid.Rows[i]["BZ"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "惯量标定");
                            }
                            break;
                        case "寄生功率试验":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("SDQJ");
                            dtToSave.Columns.Add("MYSD");
                            dtToSave.Columns.Add("HXSJ");
                            dtToSave.Columns.Add("JSGL");
                            dtToSave.Columns.Add("LJHXSJ");
                            dtToSave.Columns.Add("BZ");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["SDQJ"] = "速度区间";
                            dr["MYSD"] = "名义速度";
                            dr["HXSJ"] = "滑行时间";
                            dr["JSGL"] = "寄生功率";
                            dr["LJHXSJ"] = "累计滑行时间";
                            dr["BZ"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["SDQJ"] = datagrid.Rows[i]["SDQJ"].ToString();
                                    dr["MYSD"] = datagrid.Rows[i]["MYSD"].ToString();
                                    dr["HXSJ"] = datagrid.Rows[i]["HXSJ"].ToString();
                                    dr["JSGL"] = datagrid.Rows[i]["JSGL"].ToString();
                                    dr["LJHXSJ"] = datagrid.Rows[i]["LJHXSJ"].ToString();
                                    dr["BZ"] = datagrid.Rows[i]["BZ"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "寄生功率检查");
                            }
                            break;
                        case "加载滑行试验":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("HXQJ");
                            dtToSave.Columns.Add("QJMYSD");
                            dtToSave.Columns.Add("CCDT");
                            dtToSave.Columns.Add("PLHP");
                            dtToSave.Columns.Add("ACDT");
                            dtToSave.Columns.Add("JZSDGL");
                            dtToSave.Columns.Add("WC");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["HXQJ"] = "滑行区间";
                            dr["QJMYSD"] = "区间名义速度";
                            dr["CCDT"] = "理论滑行时间";
                            dr["PLHP"] = "寄生功率";
                            dr["ACDT"] = "实际滑行时间";
                            dr["JZSDGL"] = "加载功率(kW)";
                            dr["WC"] = "误差";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["HXQJ"] = datagrid.Rows[i]["HXQJ"].ToString();
                                    dr["QJMYSD"] = datagrid.Rows[i]["QJMYSD"].ToString();
                                    dr["CCDT"] = datagrid.Rows[i]["CCDT"].ToString();
                                    dr["PLHP"] = datagrid.Rows[i]["PLHP"].ToString();
                                    dr["ACDT"] = datagrid.Rows[i]["ACDT"].ToString();
                                    dr["JZSDGL"] = datagrid.Rows[i]["JZSDGL"].ToString();
                                    dr["WC"] = datagrid.Rows[i]["WC"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "加载滑行试验");
                            }
                            break;
                        case "变载荷滑行测试":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("HXQJ");
                            dtToSave.Columns.Add("CZY");
                            dtToSave.Columns.Add("CCDT");
                            dtToSave.Columns.Add("ACDT");
                            dtToSave.Columns.Add("WC");
                            dtToSave.Columns.Add("BZSM");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["HXQJ"] = "滑行区间";
                            dr["CZY"] = "操作员";
                            dr["CCDT"] = "理论滑行时间";
                            dr["ACDT"] = "实际滑行时间";
                            dr["WC"] = "误差";
                            dr["BZSM"] = "备注";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["HXQJ"] = datagrid.Rows[i]["HXQJ"].ToString();
                                    dr["CZY"] = datagrid.Rows[i]["CZY"].ToString();
                                    dr["CCDT"] = datagrid.Rows[i]["CCDT"].ToString();
                                    dr["ACDT"] = datagrid.Rows[i]["ACDT"].ToString();
                                    dr["WC"] = datagrid.Rows[i]["WC"].ToString();
                                    dr["BZSM"] = datagrid.Rows[i]["BZSM"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "变载荷滑行试验");
                            }
                            break;
                        case "响应时间测试":
                            dtToSave.Columns.Add("STATIONID");
                            dtToSave.Columns.Add("LINEID");
                            dtToSave.Columns.Add("SPEED");
                            dtToSave.Columns.Add("STARTPOWER");
                            dtToSave.Columns.Add("STARTFORCE");
                            dtToSave.Columns.Add("ENDPOWER");
                            dtToSave.Columns.Add("ENDFORCE");
                            dtToSave.Columns.Add("XYTIME");
                            dtToSave.Columns.Add("WDTIME");
                            dtToSave.Columns.Add("CZY");
                            dtToSave.Columns.Add("BDJG");
                            dtToSave.Columns.Add("BDRQ");
                            dr = dtToSave.NewRow();
                            dr["STATIONID"] = "检测站编号";
                            dr["LINEID"] = "检测线号";
                            dr["SPEED"] = "速度点";
                            dr["STARTPOWER"] = "初功率";
                            dr["STARTFORCE"] = "初扭力";
                            dr["ENDPOWER"] = "末功率";
                            dr["ENDFORCE"] = "末扭力";
                            dr["XYTIME"] = "响应时间";
                            dr["WDTIME"] = "稳定时间";
                            dr["CZY"] = "操作员";
                            dr["BDJG"] = "判定结果";
                            dr["BDRQ"] = "操作时间";
                            dtToSave.Rows.Add(dr);
                            if (datagrid.Rows.Count > 0)
                            {
                                for (int i = 0; i < datagrid.Rows.Count; i++)
                                {
                                    dr = dtToSave.NewRow();
                                    dr["STATIONID"] = datagrid.Rows[i]["STATIONID"].ToString();
                                    dr["LINEID"] = datagrid.Rows[i]["LINEID"].ToString();
                                    dr["SPEED"] = datagrid.Rows[i]["SPEED"].ToString();
                                    dr["STARTPOWER"] = datagrid.Rows[i]["STARTPOWER"].ToString();
                                    dr["STARTFORCE"] = datagrid.Rows[i]["STARTFORCE"].ToString();
                                    dr["ENDPOWER"] = datagrid.Rows[i]["ENDPOWER"].ToString();
                                    dr["ENDFORCE"] = datagrid.Rows[i]["ENDFORCE"].ToString();
                                    dr["XYTIME"] = datagrid.Rows[i]["XYTIME"].ToString();
                                    dr["WDTIME"] = datagrid.Rows[i]["WDTIME"].ToString();
                                    dr["CZY"] = datagrid.Rows[i]["CZY"].ToString();
                                    dr["BDJG"] = datagrid.Rows[i]["BDJG"].ToString();
                                    dr["BDRQ"] = DateTime.Parse(datagrid.Rows[i]["BDRQ"].ToString()).ToString("yyyy-MM-dd");
                                    dtToSave.Rows.Add(dr);
                                }
                                writeExcel.writeDemarcateDatatableToElt(dtToSave, "响应时间测试");
                            }
                            break;
                        default: break;
                    }
                }
                else
                {
                    MessageBox.Show("没有找到相关记录");
                }
            }
        }

        private void buttonQuery_Click_1(object sender, EventArgs e)
        {
            init_staffStastic();
            init_data();
            if (comboBoxJCXH.SelectedIndex == 0)
            {
                string lineid = "";
                for (int i = 1; i < comboBoxJCXH.Items.Count; i++)
                {
                    lineid = comboBoxJCXH.Items[i].ToString();
                    sdsCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "1");
                    sdsCjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "1");
                    sdsFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "2");
                    sdsFirstFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "2");
                    sdsSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "3");
                    sdsSecondFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "3");
                    sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "0");
                    sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "0");

                    asmCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "1");
                    asmCjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "1");
                    asmFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "2");
                    asmFirstFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "2");
                    asmSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "3");
                    asmSecondFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "3");
                    asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "0");
                    asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "0");

                    btgCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "1");
                    btgCjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "1");
                    btgFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "2");
                    btgFirstFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "2");
                    btgSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "3");
                    btgSecondFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "3");
                    btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "0");
                    btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "0");

                    lugdownCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "1");
                    lugdownCjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "1");
                    lugdownFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "2");
                    lugdownFirstFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "2");
                    lugdownSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "3");
                    lugdownSecondFjCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "3");
                    lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "0");
                    lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "0");
                }
                sdsCjCount += sdsCjPassCount;
                sdsFirstFjCount += sdsFirstFjPassCount;
                sdsSecondFjCount += sdsSecondFjPassCount;
                asmCjCount += asmCjPassCount;
                asmFirstFjCount += asmFirstFjPassCount;
                asmSecondFjCount += asmSecondFjPassCount;
                btgCjCount += btgCjPassCount;
                btgFirstFjCount += btgFirstFjPassCount;
                btgSecondFjCount += btgSecondFjPassCount;
                lugdownCjCount += lugdownCjPassCount;
                lugdownFirstFjCount += lugdownFirstFjPassCount;
                lugdownSecondFjCount += lugdownSecondFjPassCount;
            }
            else
            {
                string lineid = comboBoxJCXH.Items[comboBoxJCXH.SelectedIndex].ToString();
                sdsCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "1");
                sdsCjCount += sdsCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "1");
                sdsFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "2");
                sdsFirstFjCount += sdsFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "2");
                sdsSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "3");
                sdsSecondFjCount += sdsSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "3");
                sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "0");
                sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "0");

                asmCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "1");
                asmCjCount += asmCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "1");
                asmFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "2");
                asmFirstFjCount += asmFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "2");
                asmSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "3");
                asmSecondFjCount += asmSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "3");
                asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "0");
                asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "0");

                btgCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "1");
                btgCjCount += btgCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "1");
                btgFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "2");
                btgFirstFjCount += btgFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "2");
                btgSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "3");
                btgSecondFjCount += btgSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "3");
                btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "0");
                btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "0");

                lugdownCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "1");
                lugdownCjCount += lugdownCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "1");
                lugdownFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "2");
                lugdownFirstFjCount += lugdownFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "2");
                lugdownSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "3");
                lugdownSecondFjCount += lugdownSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "3");
                lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "0");
                lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "0");
            }
            /*for (int i = linestart; i <= linestop; i++)
            {
                lineid = "0" + i.ToString();
                sdsCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "1");
                sdsCjCount += sdsCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "1");
                sdsFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "2");
                sdsFirstFjCount += sdsFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "2");
                sdsSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "3");
                sdsSecondFjCount += sdsSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "3");
                sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "SDS", "0");
                sdsTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "SDS", "0");

                asmCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "1");
                asmCjCount += asmCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "1");
                asmFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "2");
                asmFirstFjCount += asmFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "2");
                asmSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "3");
                asmSecondFjCount += asmSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "3");
                asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", kgjcff, "0");
                asmTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", kgjcff, "0");

                btgCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "1");
                btgCjCount += btgCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "1");
                btgFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "2");
                btgFirstFjCount += btgFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "2");
                btgSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "3");
                btgSecondFjCount += btgSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "3");
                btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "ZYJS", "0");
                btgTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "ZYJS", "0");

                lugdownCjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "1");
                lugdownCjCount += lugdownCjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "1");
                lugdownFirstFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "2");
                lugdownFirstFjCount += lugdownFirstFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "2");
                lugdownSecondFjPassCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "3");
                lugdownSecondFjCount += lugdownSecondFjPassCount + mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "3");
                lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "合格", "JZJS", "0");
                lugdownTotalTestCount += mainPanel.logininfcontrol.getStationLineCarCount(mainPanel.stationid, lineid, dateTimeStartTime.Value, dateTimeEndtTime.Value, "不合格", "JZJS", "0");
            }*/
            sdsFjCount = sdsFirstFjCount + sdsSecondFjCount;
            sdsTotalCarCount = sdsCjCount + sdsFjCount;
            sdsPassCount = sdsCjPassCount + sdsFirstFjPassCount + sdsSecondFjPassCount;
            if (sdsCjCount != 0)
            {
                sdsCjPassPercent = (double)sdsCjPassCount / (double)sdsCjCount;
            }
            if (sdsFirstFjCount != 0)
            {
                sdsFirstFjPassPercent = (double)sdsFirstFjPassCount / (double)sdsFirstFjCount;
            }
            if (sdsSecondFjCount != 0)
            {
                sdsSecondFjPassPercent = (double)sdsSecondFjPassCount / (double)sdsSecondFjCount;
            }
            if (sdsTotalCarCount != 0)
            {
                sdsTotalPassPercent = (double)sdsPassCount / (double)sdsTotalCarCount;
            }

            asmFjCount = asmFirstFjCount + asmSecondFjCount;
            asmTotalCarCount = asmCjCount + asmFjCount;
            asmPassCount = asmCjPassCount + asmFirstFjPassCount + asmSecondFjPassCount;
            if (asmCjCount != 0)
            {
                asmCjPassPercent = (double)asmCjPassCount / (double)asmCjCount;
            }
            if (asmFirstFjCount != 0)
            {
                asmFirstFjPassPercent = (double)asmFirstFjPassCount / (double)asmFirstFjCount;
            }
            if (asmSecondFjCount != 0)
            {
                asmSecondFjPassPercent = (double)asmSecondFjPassCount / (double)asmSecondFjCount;
            }
            if (asmTotalCarCount != 0)
            {
                asmTotalPassPercent = (double)asmPassCount / (double)asmTotalCarCount;
            }

            btgFjCount = btgFirstFjCount + btgSecondFjCount;
            btgTotalCarCount = btgCjCount + btgFjCount;
            btgPassCount = btgCjPassCount + btgFirstFjPassCount + btgSecondFjPassCount;
            if (btgCjCount != 0)
            {
                btgCjPassPercent = (double)btgCjPassCount / (double)btgCjCount;
            }
            if (btgFirstFjCount != 0)
            {
                btgFirstFjPassPercent = (double)btgFirstFjPassCount / (double)btgFirstFjCount;
            }
            if (btgSecondFjCount != 0)
            {
                btgSecondFjPassPercent = (double)btgSecondFjPassCount / (double)btgSecondFjCount;
            }
            if (sdsTotalCarCount != 0)
            {
                btgTotalPassPercent = (double)btgPassCount / (double)btgTotalCarCount;
            }

            lugdownFjCount = lugdownFirstFjCount + lugdownSecondFjCount;
            lugdownTotalCarCount = lugdownCjCount + lugdownFjCount;
            lugdownPassCount = lugdownCjPassCount + lugdownFirstFjPassCount + lugdownSecondFjPassCount;
            if (lugdownCjCount != 0)
            {
                lugdownCjPassPercent = (double)lugdownCjPassCount / (double)lugdownCjCount;
            }
            if (lugdownFirstFjCount != 0)
            {
                lugdownFirstFjPassPercent = (double)lugdownFirstFjPassCount / (double)lugdownFirstFjCount;
            }
            if (lugdownSecondFjCount != 0)
            {
                lugdownSecondFjPassPercent = (double)lugdownSecondFjPassCount / (double)lugdownSecondFjCount;
            }
            if (lugdownTotalCarCount != 0)
            {
                lugdownTotalPassPercent = (double)lugdownPassCount / (double)lugdownTotalCarCount;
            }
            //TotalCarCount = sdsTotalCarCount + asmTotalCarCount + btgTotalCarCount + lugdownTotalCarCount;
            TotalTestCount = sdsTotalTestCount + asmTotalTestCount + btgTotalTestCount + lugdownTotalTestCount;
            CjCount = sdsCjCount + asmCjCount + btgCjCount + lugdownCjCount;
            TotalCjPassCount = sdsCjPassCount + asmCjPassCount + btgCjPassCount + lugdownCjPassCount;
            FirstFjCount = sdsFirstFjCount + asmFirstFjCount + btgFirstFjCount + lugdownFirstFjCount;
            TotalFirstFjPassCount = sdsFirstFjPassCount + asmFirstFjPassCount + btgFirstFjPassCount + lugdownFirstFjPassCount;
            SecondFjCount = sdsSecondFjCount + asmSecondFjCount + btgSecondFjCount + lugdownSecondFjCount;
            TotalSecondFjPassCount = sdsSecondFjPassCount + btgSecondFjPassCount + asmSecondFjPassCount + lugdownSecondFjPassCount;
            TotalCarCount = CjCount + FirstFjCount + SecondFjCount;
            PassCount = TotalCjPassCount + TotalFirstFjPassCount + TotalSecondFjPassCount;
            if (CjCount != 0)
            {
                CjPassPercent = (double)TotalCjPassCount / (double)CjCount;
            }
            if (FirstFjCount != 0)
            {
                FirstFjPassPercent = (double)TotalFirstFjPassCount / (double)FirstFjCount;
            }
            if (SecondFjCount != 0)
            {
                SecondFjPassPercent = (double)TotalSecondFjPassCount / (double)SecondFjCount;
            }
            if (TotalCarCount != 0)
            {
                TotalPassPercent = (double)PassCount / (double)TotalCarCount;
            }
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart5.Series[0].Points.Clear();
            chart6.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(GKJCFFNAME, asmTotalCarCount);
            chart1.Series[0].Points.AddXY("双怠速", sdsTotalCarCount);
            chart1.Series[0].Points.AddXY("加载减速", lugdownTotalCarCount);
            chart1.Series[0].Points.AddXY("自由加速", btgTotalCarCount);
            chart2.Series[0].Points.AddXY("初检", CjCount);
            chart2.Series[0].Points.AddXY("一次复检", FirstFjCount);
            chart2.Series[0].Points.AddXY("二次以上", SecondFjCount);
            chart3.Series[0].Points.AddXY("初检", asmCjCount);
            chart3.Series[0].Points.AddXY("一次复检", asmFirstFjCount);
            chart3.Series[0].Points.AddXY("二次以上", asmSecondFjCount);
            chart4.Series[0].Points.AddXY("初检", sdsCjCount);
            chart4.Series[0].Points.AddXY("一次复检", sdsFirstFjCount);
            chart4.Series[0].Points.AddXY("二次以上", sdsSecondFjCount);
            chart5.Series[0].Points.AddXY("初检", lugdownCjCount);
            chart5.Series[0].Points.AddXY("一次复检", lugdownFirstFjCount);
            chart5.Series[0].Points.AddXY("二次以上", lugdownSecondFjCount);
            chart6.Series[0].Points.AddXY("初检", btgCjCount);
            chart6.Series[0].Points.AddXY("一次复检", btgFirstFjCount);
            chart6.Series[0].Points.AddXY("二次以上", btgSecondFjCount);

            rptpara = new ReportParameter[]
                {
                    new ReportParameter("parameterStationName",mainPanel.stationinfmodel.STATIONNAME),
                    new ReportParameter("parameterTjrq",DateTime.Now.ToString("yyyy年MM月dd日")),
                    new ReportParameter("parameterTjtj", dateTimeStartTime.Value.ToString("yyyy年MM月dd日")+"-"+dateTimeEndtTime.Value.ToString("yyyy年MM月dd日")),
                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),

                    new ReportParameter("parameterGKJCFF",GKJCFFNAME),
                    new ReportParameter("parameterJcxh", comboBoxJCXH.Text),
                    new ReportParameter("parameterSdsSxzs",sdsTotalCarCount.ToString()),
                    new ReportParameter("parameterSdsClzs", sdsTotalTestCount.ToString()),
                    new ReportParameter("parameterSdsCjcls", sdsCjCount.ToString()),
                    new ReportParameter("parameterSdsCjhgl",(sdsCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsFjccs",sdsFjCount.ToString()),
                    new ReportParameter("parameterSdsDycfjcls",sdsFirstFjCount.ToString()),
                    new ReportParameter("parameterSdsDycfjhgl", (sdsFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsDecfjcls", sdsSecondFjCount.ToString()),
                    new ReportParameter("parameterSdsDecfjhgl",(sdsSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterSdsZzhgcls",sdsPassCount.ToString()),
                    new ReportParameter("parameterSdsZzhgl",(sdsTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterAsmSxzs",asmTotalCarCount.ToString()),
                    new ReportParameter("parameterAsmClzs", asmTotalTestCount.ToString()),
                    new ReportParameter("parameterAsmCjcls", asmCjCount.ToString()),
                    new ReportParameter("parameterAsmCjhgl",(asmCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmFjccs",asmFjCount.ToString()),
                    new ReportParameter("parameterAsmDycfjcls",asmFirstFjCount.ToString()),
                    new ReportParameter("parameterAsmDycfjhgl", (asmFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmDecfjcls", asmSecondFjCount.ToString()),
                    new ReportParameter("parameterAsmDecfjhgl",(asmSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterAsmZzhgcls",asmPassCount.ToString()),
                    new ReportParameter("parameterAsmZzhgl",(asmTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterBtgSxzs",btgTotalCarCount.ToString()),
                    new ReportParameter("parameterBtgClzs", btgTotalTestCount.ToString()),
                    new ReportParameter("parameterBtgCjcls", btgCjCount.ToString()),
                    new ReportParameter("parameterBtgCjhgl",(btgCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgFjccs",btgFjCount.ToString()),
                    new ReportParameter("parameterBtgDycfjcls",btgFirstFjCount.ToString()),
                    new ReportParameter("parameterBtgDycfjhgl", (btgFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgDecfjcls", btgSecondFjCount.ToString()),
                    new ReportParameter("parameterBtgDecfjhgl",(btgSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterBtgZzhgcls",btgPassCount.ToString()),
                    new ReportParameter("parameterBtgZzhgl",(btgTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterLugdownSxzs",lugdownTotalCarCount.ToString()),
                    new ReportParameter("parameterLugdownClzs", lugdownTotalTestCount.ToString()),
                    new ReportParameter("parameterLugdownCjcls", lugdownCjCount.ToString()),
                    new ReportParameter("parameterLugdownCjhgl",(lugdownCjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownFjccs",lugdownFjCount.ToString()),
                    new ReportParameter("parameterLugdownDycfjcls",lugdownFirstFjCount.ToString()),
                    new ReportParameter("parameterLugdownDycfjhgl", (lugdownFirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownDecfjcls", lugdownSecondFjCount.ToString()),
                    new ReportParameter("parameterLugdownDecfjhgl",(lugdownSecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterLugdownZzhgcls",lugdownPassCount.ToString()),
                    new ReportParameter("parameterLugdownZzhgl",(lugdownTotalPassPercent*100).ToString("0.0")+"%"),

                    new ReportParameter("parameterTotalSxzs",TotalCarCount.ToString()),
                    new ReportParameter("parameterTotalClzs", TotalTestCount.ToString()),
                    new ReportParameter("parameterTotalCjcls", CjCount.ToString()),
                    new ReportParameter("parameterTotalCjhgl",(CjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalFjccs",FjCount.ToString()),
                    new ReportParameter("parameterTotalDycfjcls",FirstFjCount.ToString()),
                    new ReportParameter("parameterTotalDycfjhgl", (FirstFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalDecfjcls", SecondFjCount.ToString()),
                    new ReportParameter("parameterTotalDecfjhgl",(SecondFjPassPercent*100).ToString("0.0")+"%"),
                    new ReportParameter("parameterTotalZzhgcls",PassCount.ToString()),
                    new ReportParameter("parameterTotalZzhgl",(TotalPassPercent*100).ToString("0.0")+"%")
                };

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptpara);
            reportViewer1.RefreshReport();
        }
        //声明一个Stream对象的列表用来保存报表的输出数据 
        //LocalReport对象的Render方法会将报表按页输出为多个Stream对象。 

        //用来提供Stream对象的函数，用于LocalReport对象的Render方法的第三个参数。
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //如果需要将报表输出的数据保存为文件，请使用FileStream对象。  
            //Stream stream = new MemoryStream(); 
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }


        private void Print()
        {
            //m_currentPageIndex = 0;

            if (m_streams == null || m_streams.Count == 0)
                return;
            //声明PrintDocument对象用于数据的打印 
            PrintDocument printDoc = new PrintDocument();
            //指定需要使用的打印机的名称，使用空字符串""来指定默认打印机 
            printDoc.PrinterSettings.PrinterName = mainPanel.linemodel.PRINTER;
            //printDoc.OriginAtMargins = false;

            //判断指定的打印机是否可用  
            if (!printDoc.PrinterSettings.IsValid)
            {
                MessageBox.Show("Can't find printer");
                return;
            }
            //声明PrintDocument对象的PrintPage事件，具体的打印操作需要在这个事件中处理。
            PrinterSettings.PaperSizeCollection papersize = printDoc.PrinterSettings.PaperSizes;
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("票据", 748, 366);
            //printDoc.PrinterSettings.PaperSizes  = new PrinterSettings.PaperSizeCollection("A4");
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrinterSettings.Copies = 1;//设置打印份数
            //执行打印操作，Print方法将触发PrintPage事件。 
            printDoc.Print();
            //printDoc.Print(); 
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {

            //Metafile对象用来保存EMF或WMF格式的图形， 
            //我们在前面将报表的内容输出为EMF图形格式的数据流。
            m_streams[m_currentPageIndex].Position = 0;
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //指定是否横向打印  
            ev.PageSettings.Landscape = false;
            //这里的Graphics对象实际指向了打印机  
            System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            m_streams[m_currentPageIndex].Close();
            m_currentPageIndex++;
            //设置是否需要继续打印  
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

        }
        /*private void buttonCheckInHistory_Click(object sender, EventArgs e)
        {
            ref_Money();
        }*/
    }
}
