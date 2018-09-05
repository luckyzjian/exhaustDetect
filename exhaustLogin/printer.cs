using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Threading;
using exhaustDetect;

namespace exhaustDetect
{
    public partial class printer : Form
    {
        public int Carwait_Scroll = 0;                                                  //待检车滚动条位置
        DataTable dt_wait = null;                                                         //等待车辆列表
        public string[] selectID = new string[1024];                                    //当前等待车辆选中的列表
        public bool ref_zt = true;
        private List<Stream> m_streams;
        //用来记录当前打印到第几页了 
        private int m_currentPageIndex;
        SYS.Model.CARDETECTED carbg = new SYS.Model.CARDETECTED();
        SYS.Model.VMAS vmasdata = new SYS.Model.VMAS();
        SYS.Model.ASM asmdata = new SYS.Model.ASM();
        SYS.Model.JZJS jzjsdata = new SYS.Model.JZJS();
        SYS.Model.SDS sdsdata = new SYS.Model.SDS();
        SYS.Model.Zyjs_Btg zyjsdata = new SYS.Model.Zyjs_Btg();
        SYS_DAL.VMASdal vmasdal = new SYS_DAL.VMASdal();
        SYS_DAL.ASMdal asmdal = new SYS_DAL.ASMdal();
        SYS_DAL.JZJSdal jzjsdal = new SYS_DAL.JZJSdal();
        SYS_DAL.Zyjsdal zyjsdal = new SYS_DAL.Zyjsdal();
        SYS_DAL.SDSdal sdsdal = new SYS_DAL.SDSdal();
        SYS_DAL.loginInfControl logininfcontrol = new SYS_DAL.loginInfControl();
        public SYS.Model.loginInfModel logininfmodel = new SYS.Model.loginInfModel();
        //private loginInfControl logininfcontrol = new loginInfControl();
        public struct wsd
        {
            public bool isUseWsd;
            public string wd;
            public string sd;
            public string dqy;
        }
        public static wsd wsdthisTime;
        public printer()
        {
            InitializeComponent();
        }

        private void printer_Load(object sender, EventArgs e)
        {
            init_datagrid();
            ref_WaitCar("当日");
            textBoxCopy.Text = "1";
            logininfmodel=logininfcontrol.getLoginDefaultInf();
            textBoxPlateAtWait.Text = logininfmodel.CLHP;
            if(mainPanel.NetMode==mainPanel.ACNETMODE&&mainPanel.isNetUsed)
            {
                补传检测数据ToolStripMenuItem.Visible = true;
            }
            else
                补传检测数据ToolStripMenuItem.Visible = false;

        }
        private void init_datagrid()
        {
            dt_wait = new DataTable();
            dt_wait.Columns.Add("项目");
            dt_wait.Columns.Add("检测编号");
            dt_wait.Columns.Add("车牌号");
            dt_wait.Columns.Add("车主");
            dt_wait.Columns.Add("联系电话");
            dt_wait.Columns.Add("检测方法");
            dt_wait.Columns.Add("检测时间");
            dt_wait.Columns.Add("检测结果");
            dt_wait.Columns.Add("费用");
            dt_wait.Columns.Add("状态");
            dataGrid_waitcar.DataSource = dt_wait;
            dataGrid_waitcar.Columns["检测编号"].Visible = false;
            dataGrid_waitcar.Columns["车主"].Visible = false;
            dataGrid_waitcar.Columns["联系电话"].Visible = false;
            dataGrid_waitcar.Columns["费用"].Visible = false;
        }
        
        public void ref_WaitCar(string lx)
        {
            try
            {
                dt_wait.Rows.Clear();
                    dataGrid_waitcar.Columns["车主"].Visible = checkBoxCZ.Checked;
                    dataGrid_waitcar.Columns["联系电话"].Visible = checkBoxCZ.Checked;
                if (checkBoxExhaust.Checked)
                {
                    DataTable dt = mainPanel.logininfcontrol.getAllCarDetected(lx);
                    DataRow dr = null;
                    if (dt != null)
                    {
                        foreach (DataRow dR in dt.Rows)
                        {
                            if (dR["SFJF"].ToString() == "Y" && checkBoxNoPrinted.Checked == true)
                                continue;
                            dr = dt_wait.NewRow();
                            dr["项目"] = "环保检查";
                            dr["检测编号"] = dR["CLID"].ToString();
                            dr["车牌号"] = dR["CLHP"].ToString();
                            dr["车主"] = dR["CZ"].ToString();
                            dr["联系电话"] = dR["LXDH"].ToString();
                            switch (dR["JCFF"].ToString())
                            {
                                case "ASM": dr["检测方法"] = "稳态工况"; break;
                                case "VMAS": dr["检测方法"] = "瞬态工况"; break;
                                case "JZJS": dr["检测方法"] = "加载减速"; break;
                                case "ZYJS": dr["检测方法"] = "自由加速"; break;
                                case "SDS": dr["检测方法"] = "双怠速"; break;
                                default: break;
                            }
                            dr["检测时间"] = dR["JCSJ"].ToString();
                            dr["检测结果"] = dR["JCJG"].ToString();
                            dr["费用"] = dR["JCFY"].ToString();
                            switch (dR["SFJF"].ToString())
                            {
                                case "Y":
                                    dr["状态"] = "已领取";
                                    break;
                                case "N":
                                    dr["状态"] = "未领取";
                                    break;
                                default:
                                    dr["状态"] = "未领取";
                                    break;
                            }
                            dt_wait.Rows.Add(dr);
                        }
                    }
                }
                
                ref_zt = false;
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测时间"], ListSortDirection.Descending);
                ref_zt = true;
            }
            catch (Exception)
            {

            }
        }
        public void ref_WaitCar(string lx,string plate)
        {
            try
            {
                dt_wait.Rows.Clear();
                dataGrid_waitcar.Columns["车主"].Visible = checkBoxCZ.Checked;
                dataGrid_waitcar.Columns["联系电话"].Visible = checkBoxCZ.Checked;
                DataTable dt = mainPanel.logininfcontrol.getCarDetectedByPlate(lx, plate);
                DataRow dr = null;
                if (dt != null)
                {
                    foreach (DataRow dR in dt.Rows)
                    {
                        if (dR["SFJF"].ToString() == "Y" && checkBoxNoPrinted.Checked == true)
                            continue;
                        dr = dt_wait.NewRow();
                        dr["项目"] = "环保检查";
                        dr["检测编号"] = dR["CLID"].ToString();
                        dr["车牌号"] = dR["CLHP"].ToString();
                        dr["车主"] = dR["CZ"].ToString();
                        dr["联系电话"] = dR["LXDH"].ToString();
                        switch (dR["JCFF"].ToString())
                        {
                            case "ASM": dr["检测方法"] = "稳态工况"; break;
                            case "VMAS": dr["检测方法"] = "瞬态工况"; break;
                            case "JZJS": dr["检测方法"] = "加载减速"; break;
                            case "ZYJS": dr["检测方法"] = "自由加速"; break;
                            case "SDS": dr["检测方法"] = "双怠速"; break;
                            case "LZ": dr["检测方法"] = "滤纸"; break;
                            default: break;
                        }
                        dr["检测时间"] = dR["JCSJ"].ToString();
                        dr["检测结果"] = dR["JCJG"].ToString();
                        dr["费用"] = dR["JCFY"].ToString();
                        switch (dR["SFJF"].ToString())
                        {
                            case "Y":
                                dr["状态"] = "已领取";
                                break;
                            case "N":
                                dr["状态"] = "未领取";
                                break;
                            default:
                                dr["状态"] = "未领取";
                                break;
                        }
                        dt_wait.Rows.Add(dr);
                    }
                }
                ref_zt = false;
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测时间"], ListSortDirection.Descending);
                ref_zt = true;
            }
            catch (Exception)
            {

            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (true)
            {
                if (dataGrid_waitcar.SelectedRows.Count > 0)
                {
                    if (dataGrid_waitcar.SelectedRows.Count == 1)
                    {
                        selectID = new string[1024];
                        for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                        {
                            selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                        }
                    }
                    else if (dataGrid_waitcar.SelectedRows.Count > 1)
                    {
                        selectID = new string[1024];
                        for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                        {
                            selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                        }
                    }
                    else
                    {
                        selectID = new string[1024];
                        for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                        {
                            selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                        }
                    }
                    switch (dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString())
                    {
                        case "环保检查":
                            标记为已缴费ToolStripMenuItem.Enabled = true;
                            标记未领ToolStripMenuItem.Enabled = true;
                            break;
                        case "安检待检":
                            标记为已缴费ToolStripMenuItem.Enabled = false;
                            标记未领ToolStripMenuItem.Enabled = false;
                            break;
                        case "安检完成":
                            标记为已缴费ToolStripMenuItem.Enabled = true;
                            标记未领ToolStripMenuItem.Enabled = true;
                            break;
                        default:
                            标记为已缴费ToolStripMenuItem.Enabled = false;
                            标记未领ToolStripMenuItem.Enabled = false;
                            break;
                    }
                }
                else
                {
                    selectID = new string[1024];
                    for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                    {
                        selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                    }
                    标记为已缴费ToolStripMenuItem.Enabled = false;
                    标记未领ToolStripMenuItem.Enabled = false;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string lx = "";
            if (radioButtonToday.Checked == true)
                lx = "当日";
            else if (radioButtonThisWeek.Checked == true)
                lx = "当周";
            else
                lx="当月";
            ref_WaitCar(lx);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectID[0] != ""&&dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString()=="环保检查")
            {
                carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                if (carbg.CLID == "-2")
                {
                    MessageBox.Show("查看报告失败", "系统错误!");
                }
                else
                {
                    switch (carbg.JCFF)
                    {
                        case "ASM":
                            reportViewASM childreportasm = new reportViewASM();
                            childreportasm.TopLevel = false;
                            ((Panel)this.Parent).Controls.Add(childreportasm);
                            childreportasm.Dock = DockStyle.Fill;
                            childreportasm.display_Asm(selectID[0]);
                            childreportasm.BringToFront();
                            childreportasm.Show();
                            break;
                        case "VMAS":
                            vmasdata=vmasdal.Get_VMAS(selectID[0]);
                            if (vmasdata.BEFORE == "Y")
                            {
                                reportViewVmasBefore childreportvmasbefore = new reportViewVmasBefore();
                                childreportvmasbefore.TopLevel = false;
                                ((Panel)this.Parent).Controls.Add(childreportvmasbefore);
                                childreportvmasbefore.Dock = DockStyle.Fill;
                                childreportvmasbefore.display_Vmas(selectID[0]);
                                childreportvmasbefore.BringToFront();
                                childreportvmasbefore.Show();
                            }
                            else
                            {
                                reportViewVmas childreportvmas = new reportViewVmas();
                                childreportvmas.TopLevel = false;
                                ((Panel)this.Parent).Controls.Add(childreportvmas);
                                childreportvmas.Dock = DockStyle.Fill;
                                childreportvmas.display_Vmas(selectID[0]);
                                childreportvmas.BringToFront();
                                childreportvmas.Show();
                            }
                            break;
                        case "JZJS":
                            reportViewJzjs childreportjzjs = new reportViewJzjs();
                            childreportjzjs.TopLevel = false;
                            ((Panel)this.Parent).Controls.Add(childreportjzjs);
                            childreportjzjs.Dock = DockStyle.Fill;
                            childreportjzjs.display_Vmas(selectID[0]);
                            childreportjzjs.BringToFront();
                            childreportjzjs.Show();
                            break;
                        case "SDS":
                            if (true)
                            {
                                reportViewSdsCH childreportsds = new reportViewSdsCH();
                                childreportsds.TopLevel = false;
                                ((Panel)this.Parent).Controls.Add(childreportsds);
                                childreportsds.Dock = DockStyle.Fill;
                                childreportsds.display_Vmas(selectID[0]);
                                childreportsds.BringToFront();
                                childreportsds.Show();
                            }
                            break;
                        case "ZYJS":
                            reportViewZyjs childreportzyjs = new reportViewZyjs();
                            childreportzyjs.TopLevel = false;
                            ((Panel)this.Parent).Controls.Add(childreportzyjs);
                            childreportzyjs.Dock = DockStyle.Fill;
                            childreportzyjs.display_Vmas(selectID[0]);
                            childreportzyjs.BringToFront();
                            childreportzyjs.Show();
                            break;
                        case "LZ":
                            reportViewLz childreportlz = new reportViewLz();
                            childreportlz.TopLevel = false;
                            ((Panel)this.Parent).Controls.Add(childreportlz);
                            childreportlz.Dock = DockStyle.Fill;
                            childreportlz.display_Vmas(selectID[0]);
                            childreportlz.BringToFront();
                            childreportlz.Show();
                            break;
                        default: break;
                    }
                    
                }
            }
        }

        private void buttonCheckToday_Click(object sender, EventArgs e)
        {
            ref_WaitCar("当日", textBoxPlateAtWait.Text);
        }

        private void buttonCheckInHistory_Click(object sender, EventArgs e)
        {
            string plate = textBoxPlateAtWait.Text;
            string cz = "0";
            string result = "0";
            ref_WaitCar(dateTimeStart.Value, dateTimeEnd.Value, result, plate, cz);
        }
        public void ref_WaitCar(DateTime starttime, DateTime endtime, string result, string plate, string cz)
        {
            try
            {
                dt_wait.Rows.Clear();
                dataGrid_waitcar.Columns["车主"].Visible = checkBoxCZ.Checked;
                dataGrid_waitcar.Columns["联系电话"].Visible = checkBoxCZ.Checked;
                DataTable dt = mainPanel.logininfcontrol.getCarDetectedByPlate(starttime, endtime, result, plate, cz);
                DataRow dr = null;
                if (dt != null)
                {
                    foreach (DataRow dR in dt.Rows)
                    {
                        if (dR["SFJF"].ToString() == "Y" && checkBoxNoPrinted.Checked == true)
                            continue;
                        dr = dt_wait.NewRow();
                        dr["项目"] = "环保检查";
                        dr["检测编号"] = dR["CLID"].ToString();
                        dr["车牌号"] = dR["CLHP"].ToString();
                        dr["车主"] = dR["CZ"].ToString();
                        dr["联系电话"] = dR["LXDH"].ToString();
                        switch (dR["JCFF"].ToString())
                        {
                            case "ASM": dr["检测方法"] = "稳态工况"; break;
                            case "VMAS": dr["检测方法"] = "瞬态工况"; break;
                            case "JZJS": dr["检测方法"] = "加载减速"; break;
                            case "ZYJS": dr["检测方法"] = "自由加速"; break;
                            case "SDS": dr["检测方法"] = "双怠速"; break;
                            case "LZ": dr["检测方法"] = "滤纸"; break;
                            default: break;
                        }
                        dr["检测时间"] = dR["JCSJ"].ToString();
                        dr["检测结果"] = dR["JCJG"].ToString();
                        dr["费用"] = dR["JCFY"].ToString();
                        switch (dR["SFJF"].ToString())
                        {
                            case "Y":
                                dr["状态"] = "已领取";
                                break;
                            case "N":
                                dr["状态"] = "未领取";
                                break;
                            default:
                                dr["状态"] = "未领取";
                                break;
                        }
                        dt_wait.Rows.Add(dr);
                    }
                }
                ref_zt = false;
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测时间"], ListSortDirection.Descending);
                ref_zt = true;
            }
            catch (Exception)
            {

            }
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (selectID[0] != "" && dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString() == "环保检查")
            {
                carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                SYS.Model.CARINF carinfo = mainPanel.logininfcontrol.getCarInfbyPlate(carbg.CLHP);
                if (carbg.CLID == "-2")
                {
                    MessageBox.Show("打印报告失败", "系统错误!");
                }
                //else if (carbg.SFJF == "N")
                //{
                //    MessageBox.Show("该车未缴费，请先缴费再打印报表", "系统提示!");
                //}
                else
                {
                    LocalReport report = new LocalReport();
                    switch (carbg.JCFF)
                    {
                        case "ASM":
                            asmdata = asmdal.Get_ASM(selectID[0]);
                            ReportParameter[] rptparaAsm =
                            {
                                new ReportParameter("parameterJCYJ","GB3847-2005"),
                                new ReportParameter("parameterJCFF","加载减速法"),
                                new ReportParameter("parameterLsh", carbg.LSH),
                                new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                                new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("yyyy-MM-dd hh:mm:ss")),
                                new ReportParameter("parameterCzy", carbg.CZY),
                                new ReportParameter("parameterJsy", carbg.JSY),
                                new ReportParameter("parameterClxh", carbg.XH),
                                new ReportParameter("parameterScqy",carbg.SCQY),
                                new ReportParameter("parameterJzzl", carbg.JZZL),
                                new ReportParameter("parameterZzl", carbg.ZZL),
                                new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                new ReportParameter("parameterJqfs",carbg.JQFS),
                                new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                new ReportParameter("parameterGyfs",carbg.GYFS),
                                new ReportParameter("parameterRlzl",carbg.RLZL),
                                new ReportParameter("parameterDws",carbg.DWS),
                                new ReportParameter("parameterQGS",carbg.QGS),
                                new ReportParameter("parameterFDJH",carbg.FDJHM),
                                new ReportParameter("parameterXslc",carbg.XSLC),
                                new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("yyyy-MM-dd")),
                                new ReportParameter("parameterCllx",carbg.CLLX),
                                new ReportParameter("parameterHpzl",carbg.CPYS),
                                new ReportParameter("parameterEdgl",carbg.EDGL),
                                new ReportParameter("parameterEdzs",carbg.EDZS),
                                new ReportParameter("parameterRylx",carinfo.RYPH),
                                new ReportParameter("parameterHbbz","有"),
                                new ReportParameter("parameterCzdz",""),
                                new ReportParameter("parameterCzdh",carbg.LXDH),
                                new ReportParameter("parameterQdfs",carbg.QDXS),
                                new ReportParameter("parameterChzz",(carbg.JHZZ=="是")?"有":"无"),
                                new ReportParameter("parameterClph",carbg.CLHP),
                                new ReportParameter("parameterCpys",carbg.CPYS),
                                new ReportParameter("parameterClsbm",carbg.CLSBM),
                                new ReportParameter("parameterCz",carbg.CZ),
                                new ReportParameter("parameterSbmc",asmdata.SBMC),
                                new ReportParameter("parameterSbbh",asmdata.CGJBH+"/"+asmdata.FXYBH),
                                new ReportParameter("parameterCgjxh",asmdata.CGJXH),
                                new ReportParameter("parameterCgjbh",asmdata.CGJBH),
                                new ReportParameter("parameterCgjcj",asmdata.CGJZZC),
                                new ReportParameter("parameterFxyxh",asmdata.FXYXH),
                                new ReportParameter("parameterFxybh",asmdata.FXYBH),
                                new ReportParameter("parameterFxycj",asmdata.FXYZZC),
                                new ReportParameter("parameterWd",asmdata.WD),
                                new ReportParameter("parameterDqy",asmdata.DQY),
                                new ReportParameter("parameterSd",asmdata.SD),
                    
                                new ReportParameter("parameterHC25CLZ",asmdata.HC25CLZ),
                                new ReportParameter("parameterCO25CLZ",asmdata.CO25CLZ),
                                new ReportParameter("parameterNOX25CLZ",asmdata.NOX25CLZ),
                                new ReportParameter("parameterHC40CLZ",asmdata.HC40CLZ),
                                new ReportParameter("parameterCO40CLZ",asmdata.CO40CLZ),
                                new ReportParameter("parameterNOX40CLZ",asmdata.NOX40CLZ),
                                new ReportParameter("parameterHC25PD",asmdata.HC25PD),
                                new ReportParameter("parameterCO25PD",asmdata.CO25PD),
                                new ReportParameter("parameterNOX25PD",asmdata.NOX25PD),
                                new ReportParameter("parameterHC40PD",asmdata.HC40PD),
                                new ReportParameter("parameterCO40PD",asmdata.CO40PD),
                                new ReportParameter("parameterNOX40PD",asmdata.NOX40PD),
                                new ReportParameter("parameterHC25XZ","≤"+asmdata.HC25XZ),
                                new ReportParameter("parameterCO25XZ","≤"+asmdata.CO25XZ),
                                new ReportParameter("parameterNOX25XZ","≤"+asmdata.NOX25XZ),
                                new ReportParameter("parameterHC40XZ","≤"+asmdata.HC40XZ),
                                new ReportParameter("parameterCO40XZ","≤"+asmdata.CO40XZ),
                                new ReportParameter("parameterNOX40XZ","≤"+asmdata.NOX40XZ),
                                new ReportParameter("parameterZHPD",(asmdata.ZHPD=="合格")?"通过":"未通过"),

                                new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),
                                new ReportParameter("parameterJczdz",mainPanel.stationinfmodel.STATIONADD),
                                new ReportParameter("parameterJczdh",mainPanel.stationinfmodel.STATIONPHONE),
                                new ReportParameter("parameterJCZMC",carbg.JCZMC.Split('_')[1])
                            };
                            report.ReportEmbeddedResource = "exhaustDetect.ReportBDAsm.rdlc";
                            report.SetParameters(rptparaAsm);
                            break;
                        case "VMAS":
                            vmasdata = vmasdal.Get_VMAS(selectID[0]);
                            if (vmasdata.BEFORE == "Y")
                            {
                                ReportParameter[] rptparaBefore =
                                {
                                    new ReportParameter("parameterLsh", carbg.LSH),
                                    new ReportParameter("parameterStationName", carbg.JCZMC),
                                    new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("G")),
                                    new ReportParameter("parameterCzy", carbg.CZY),
                                    new ReportParameter("parameterJsy", carbg.JSY),
                                    new ReportParameter("parameterClxh", carbg.XH),
                                    new ReportParameter("parameterScqy",carbg.SCQY),
                                    new ReportParameter("parameterJzzl", carbg.JZZL),
                                    new ReportParameter("parameterZzl", carbg.ZZL),
                                    new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                    new ReportParameter("parameterJqfs",carbg.JQFS),
                                    new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                    new ReportParameter("parameterGyfs",carbg.GYFS),
                                    new ReportParameter("parameterRlzl",carbg.RLZL),
                                    new ReportParameter("parameterDws",carbg.DWS),
                                    new ReportParameter("parameterXslc",carbg.XSLC+"km"),
                                    new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                    new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("D")),
                                    new ReportParameter("parameterCllx",carbg.CLLX),
                                    new ReportParameter("parameterQdfs",carbg.QDXS),
                                    new ReportParameter("parameterChzz",carbg.CHZZ),
                                    new ReportParameter("parameterClph",carbg.CLHP),
                                    new ReportParameter("parameterCpys",carbg.CPYS),
                                    new ReportParameter("parameterClsbm",carbg.CLSBM),
                                    new ReportParameter("parameterCz",carbg.CZ),
                                    new ReportParameter("parameterSbmc",vmasdata.SBZZC),
                                    new ReportParameter("parameterSbxh",vmasdata.SBXH),
                                    new ReportParameter("parameterCgjxh",vmasdata.CGJXH),
                                    new ReportParameter("parameterCgjbh",vmasdata.CGJBH),
                                    new ReportParameter("parameterFxyxh",vmasdata.FXYZZC+":"+vmasdata.FXYXH),
                                    new ReportParameter("parameterFxybh",vmasdata.FXYBH),
                                    new ReportParameter("parameterLLj",vmasdata.LLJZZC+":"+vmasdata.LLJXH),
                                    new ReportParameter("parameterLLjbh",vmasdata.LLJBH),
                                    new ReportParameter("parameterWd",vmasdata.WD+"℃"),
                                    new ReportParameter("parameterDqy",vmasdata.DQY+"KPa"),
                                    new ReportParameter("parameterSd",vmasdata.SD+"%"),
                                    new ReportParameter("parameterCOCLZ",vmasdata.COZL),
                                    new ReportParameter("parameterCOXZ","≤"+vmasdata.COXZ),
                                    new ReportParameter("parameterCOPD",vmasdata.COPD),
                                    new ReportParameter("parameterHCCLZ",vmasdata.HCZL),
                                    new ReportParameter("parameterHCXZ","≤"+vmasdata.HCXZ),
                                    new ReportParameter("parameterHCPD",vmasdata.HCPD),
                                    new ReportParameter("parameterNOXCLZ",vmasdata.NOXZL),
                                    new ReportParameter("parameterNOXXZ","≤"+vmasdata.NOXXZ),
                                    new ReportParameter("parameterNOXPD",vmasdata.NOXPD),
                                    new ReportParameter("parameterZHPD",(vmasdata.ZHPD=="合格")?"通过":"未通过"),
                                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),                             
                                    new ReportParameter("parameterJCZDZ", mainPanel.stationinfmodel.STATIONADD),
                                    new ReportParameter("parameterRZBH",""),
                                    new ReportParameter("parameterRZYXQ",""),
                                    new ReportParameter("parameterJCZMC",mainPanel.stationinfmodel.STATIONNAME)
                                };
                                report.ReportEmbeddedResource = "exhaustDetect.ReportVmasBefore.rdlc";
                                report.SetParameters(rptparaBefore);
                            }
                            else
                            {
                                ReportParameter[] rptpara =
                                {
                                    new ReportParameter("parameterLsh", carbg.LSH),
                                    new ReportParameter("parameterStationName", carbg.JCZMC),
                                    new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("G")),
                                    new ReportParameter("parameterCzy", carbg.CZY),
                                    new ReportParameter("parameterJsy", carbg.JSY),
                                    new ReportParameter("parameterClxh", carbg.XH),
                                    new ReportParameter("parameterScqy",carbg.SCQY),
                                    new ReportParameter("parameterJzzl", carbg.JZZL),
                                    new ReportParameter("parameterZzl", carbg.ZZL),
                                    new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                    new ReportParameter("parameterJqfs",carbg.JQFS),
                                    new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                    new ReportParameter("parameterGyfs",carbg.GYFS),
                                    new ReportParameter("parameterRlzl",carbg.RLZL),
                                    new ReportParameter("parameterDws",carbg.DWS),
                                    new ReportParameter("parameterXslc",carbg.XSLC+"km"),
                                    new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                    new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("D")),
                                    new ReportParameter("parameterCllx",carbg.CLLX),
                                    new ReportParameter("parameterQdfs",carbg.QDXS),
                                    new ReportParameter("parameterChzz",carbg.CHZZ),
                                    new ReportParameter("parameterClph",carbg.CLHP),
                                    new ReportParameter("parameterCpys",carbg.CPYS),
                                    new ReportParameter("parameterClsbm",carbg.CLSBM),
                                    new ReportParameter("parameterCz",carbg.CZ),
                                    new ReportParameter("parameterSbmc",vmasdata.SBZZC),
                                    new ReportParameter("parameterSbxh",vmasdata.SBXH),
                                    new ReportParameter("parameterCgjxh",vmasdata.CGJXH),
                                    new ReportParameter("parameterCgjbh",vmasdata.CGJBH),
                                    new ReportParameter("parameterFxyxh",vmasdata.FXYZZC+":"+vmasdata.FXYXH),
                                    new ReportParameter("parameterFxybh",vmasdata.FXYBH),
                                    new ReportParameter("parameterLLj",vmasdata.LLJZZC+":"+vmasdata.LLJXH),
                                    new ReportParameter("parameterLLjbh",vmasdata.LLJBH),
                                    new ReportParameter("parameterWd",vmasdata.WD+"℃"),
                                    new ReportParameter("parameterDqy",vmasdata.DQY+"KPa"),
                                    new ReportParameter("parameterSd",vmasdata.SD+"%"),
                                    new ReportParameter("parameterCOCLZ",vmasdata.COZL),
                                    new ReportParameter("parameterCOXZ","≤"+vmasdata.COXZ),
                                    new ReportParameter("parameterCOPD",vmasdata.COPD),
                                    new ReportParameter("parameterHCCLZ",(float.Parse(vmasdata.HCZL)).ToString("0.00")),
                                    new ReportParameter("parameterNOXCLZ",(float.Parse(vmasdata.NOXZL)).ToString("0.00")),
                                    new ReportParameter("parameterHCNOXXZ","HC+NOx≤"+vmasdata.HCXZ),
                                    new ReportParameter("parameterHCNOXPD",vmasdata.HCPD),
                                    new ReportParameter("parameterZHPD",(vmasdata.ZHPD=="合格")?"通过":"未通过"),
                                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),                             
                                    new ReportParameter("parameterJCZDZ", mainPanel.stationinfmodel.STATIONADD),
                                    new ReportParameter("parameterRZBH",""),
                                    new ReportParameter("parameterRZYXQ",""),
                                    new ReportParameter("parameterJCZMC",mainPanel.stationinfmodel.STATIONNAME)
                                };
                                report.ReportEmbeddedResource = "exhaustDetect.ReportVmas.rdlc";
                                report.SetParameters(rptpara);
                            }
                            break;
                        case "JZJS":
                            jzjsdata = jzjsdal.Get_JZJS(selectID[0]);
                            ReportParameter[] rptparaJzjs =
                            {
                                    new ReportParameter("parameterJCYJ","GB3847-2005"),
                                    new ReportParameter("parameterJCFF","加载减速法"),
                                    new ReportParameter("parameterLsh", carbg.LSH),
                                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                                    new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("yyyy-MM-dd hh:mm:ss")),
                                    new ReportParameter("parameterCzy", carbg.CZY),
                                    new ReportParameter("parameterJsy", carbg.JSY),
                                    new ReportParameter("parameterClxh", carbg.XH),
                                    new ReportParameter("parameterScqy",carbg.SCQY),
                                    new ReportParameter("parameterJzzl", carbg.JZZL),
                                    new ReportParameter("parameterZzl", carbg.ZZL),
                                    new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                    new ReportParameter("parameterJqfs",carbg.JQFS),
                                    new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                    new ReportParameter("parameterGyfs",carbg.GYFS),
                                    new ReportParameter("parameterRlzl",carbg.RLZL),
                                    new ReportParameter("parameterDws",carbg.DWS),
                                    new ReportParameter("parameterQGS",carbg.QGS),
                                    new ReportParameter("parameterFDJH",carbg.FDJHM),
                                    new ReportParameter("parameterXslc",carbg.XSLC),
                                    new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                    new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("yyyy-MM-dd")),
                                    new ReportParameter("parameterCllx",carbg.CLLX),
                                    new ReportParameter("parameterHpzl",carbg.CPYS),
                                    new ReportParameter("parameterEdgl",carbg.EDGL),
                                    new ReportParameter("parameterEdzs",carbg.EDZS),
                                    new ReportParameter("parameterHbbz","有"),
                                    new ReportParameter("parameterCzdz",""),
                                    new ReportParameter("parameterCzdh",carbg.LXDH),
                                    new ReportParameter("parameterQdfs",carbg.QDXS),
                                    new ReportParameter("parameterChzz",(carbg.JHZZ=="是")?"有":"无"),
                                    new ReportParameter("parameterClph",carbg.CLHP),
                                    new ReportParameter("parameterCpys",carbg.CPYS),
                                    new ReportParameter("parameterClsbm",carbg.CLSBM),
                                    new ReportParameter("parameterCz",carbg.CZ),
                                    new ReportParameter("parameterSbmc",jzjsdata.SBMC),
                                    new ReportParameter("parameterSbbh",jzjsdata.CGJBH+"/"+jzjsdata.YDJBH),
                                    new ReportParameter("parameterCgjxh",jzjsdata.CGJXH),
                                    new ReportParameter("parameterCgjbh",jzjsdata.CGJBH),
                                    new ReportParameter("parameterCgjcj",jzjsdata.CGJZZC),
                                    new ReportParameter("parameterFxyxh",jzjsdata.YDJXH),
                                    new ReportParameter("parameterFxybh",jzjsdata.YDJBH),
                                    new ReportParameter("parameterFxycj",jzjsdata.YDJZZC),
                                    new ReportParameter("parameterWd",jzjsdata.WD),
                                    new ReportParameter("parameterDqy",jzjsdata.DQY),
                                    new ReportParameter("parameterSd",jzjsdata.SD),
                    
                                    new ReportParameter("parameterHK",jzjsdata.HK),
                                    new ReportParameter("parameterNK",jzjsdata.NK),
                                    new ReportParameter("parameterEK",jzjsdata.EK),
                                    new ReportParameter("parameterJZJSKXZ","≤"+jzjsdata.YDXZ),
                                    new ReportParameter("parameterHKPD",jzjsdata.HKPD),
                                    new ReportParameter("parameterNKPD",jzjsdata.NKPD),
                                    new ReportParameter("parameterEKPD",jzjsdata.EKPD),
                                    new ReportParameter("parameterLBGL",jzjsdata.MAXLBGL),
                                    new ReportParameter("parameterGLXZ","≥"+jzjsdata.GLXZ),
                                    new ReportParameter("parameterGLPD",jzjsdata.GLPD),

                                    new ReportParameter("parameterZHPD",(jzjsdata.ZHPD=="合格")?"通过":"未通过"),
                                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),
                                    new ReportParameter("parameterJczdz",mainPanel.stationinfmodel.STATIONADD),
                                    new ReportParameter("parameterJczdh",mainPanel.stationinfmodel.STATIONPHONE),
                                    new ReportParameter("parameterJCZMC",carbg.JCZMC.Split('_')[1])
                            };
                            report.ReportEmbeddedResource = "exhaustDetect.ReportBDJzjs.rdlc";
                            report.SetParameters(rptparaJzjs);
                            break;
                        case "SDS":
                            sdsdata = sdsdal.Get_SDS(selectID[0]);
                            if (true)
                            {
                                ReportParameter[] rptparaSds =
                                {
                                    new ReportParameter("parameterJCYJ","GB3847-2005"),
                                    new ReportParameter("parameterJCFF","加载减速法"),
                                    new ReportParameter("parameterLsh", carbg.LSH),
                                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                                    new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("yyyy-MM-dd hh:mm:ss")),
                                    new ReportParameter("parameterCzy", carbg.CZY),
                                    new ReportParameter("parameterJsy", carbg.JSY),
                                    new ReportParameter("parameterClxh", carbg.XH),
                                    new ReportParameter("parameterScqy",carbg.SCQY),
                                    new ReportParameter("parameterJzzl", carbg.JZZL),
                                    new ReportParameter("parameterZzl", carbg.ZZL),
                                    new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                    new ReportParameter("parameterJqfs",carbg.JQFS),
                                    new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                    new ReportParameter("parameterGyfs",carbg.GYFS),
                                    new ReportParameter("parameterRlzl",carbg.RLZL),
                                    new ReportParameter("parameterDws",carbg.DWS),
                                    new ReportParameter("parameterQGS",carbg.QGS),
                                    new ReportParameter("parameterFDJH",carbg.FDJHM),
                                    new ReportParameter("parameterXslc",carbg.XSLC),
                                    new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                    new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("yyyy-MM-dd")),
                                    new ReportParameter("parameterCllx",carbg.CLLX),
                                    new ReportParameter("parameterHpzl",carbg.CPYS),
                                    new ReportParameter("parameterEdgl",carbg.EDGL),
                                    new ReportParameter("parameterEdzs",carbg.EDZS),
                                    new ReportParameter("parameterHbbz","有"),
                                    new ReportParameter("parameterCzdz",""),
                                    new ReportParameter("parameterCzdh",carbg.LXDH),
                                    new ReportParameter("parameterQdfs",carbg.QDXS),
                                    new ReportParameter("parameterChzz",(carbg.JHZZ=="是")?"有":"无"),
                                    new ReportParameter("parameterRylx",carinfo.RYPH),
                                    new ReportParameter("parameterClph",carbg.CLHP),
                                    new ReportParameter("parameterCpys",carbg.CPYS),
                                    new ReportParameter("parameterClsbm",carbg.CLSBM),
                                    new ReportParameter("parameterCz",carbg.CZ),
                                    new ReportParameter("parameterSbmc",sdsdata.SBMC),
                                    new ReportParameter("parameterSbbh","--"+"/"+sdsdata.FXYBH),
                                    new ReportParameter("parameterCgjxh","--"),
                                    new ReportParameter("parameterCgjbh","--"),
                                    new ReportParameter("parameterCgjcj","--"),
                                    new ReportParameter("parameterFxyxh",sdsdata.FXYXH),
                                    new ReportParameter("parameterFxybh",sdsdata.FXYBH),
                                    new ReportParameter("parameterFxycj",sdsdata.FXYZZC),
                                    new ReportParameter("parameterWd",sdsdata.WD),
                                    new ReportParameter("parameterDqy",sdsdata.DQY),
                                    new ReportParameter("parameterSd",sdsdata.SD),
                    
                                     new ReportParameter("parameterLOWHC",sdsdata.HCLOWCLZ),
                                    new ReportParameter("parameterLOWHCXZ","≤"+sdsdata.HCLOWXZ),
                                    new ReportParameter("parameterLOWCO",sdsdata.COLOWCLZ),
                                    new ReportParameter("parameterLOWCOXZ","≤"+sdsdata.COLOWXZ),
                                    new ReportParameter("parameterLOWPD",sdsdata.LOWPD),
                                    new ReportParameter("parameterHIGHCO",sdsdata.COHIGHCLZ),
                                    new ReportParameter("parameterHIGHCOXZ","≤"+sdsdata.COHIGHXZ),
                                    new ReportParameter("parameterHIGHHC",sdsdata.HCHIGHCLZ),
                                    new ReportParameter("parameterHIGHHCXZ","≤"+sdsdata.HCHIGHXZ),
                                    new ReportParameter("parameterLAMDA",sdsdata.LAMDAHIGHCLZ),
                                    new ReportParameter("parameterLAMDAXZ",sdsdata.LAMDAHIGHXZ),
                                    new ReportParameter("parameterLAMDAPD",sdsdata.LAMDAHIGHPD),
                                    new ReportParameter("parameterHIGHPD",sdsdata.HIGHPD),                    
                                    new ReportParameter("parameterZHPD",(sdsdata.ZHPD=="合格")?"通过":"未通过"),

                                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),
                                    new ReportParameter("parameterJczdz",mainPanel.stationinfmodel.STATIONADD),
                                    new ReportParameter("parameterJczdh",mainPanel.stationinfmodel.STATIONPHONE),
                                    new ReportParameter("parameterJCZMC",carbg.JCZMC.Split('_')[1])
                                };
                                report.ReportEmbeddedResource = "exhaustDetect.ReportBDSds.rdlc";
                                report.SetParameters(rptparaSds);
                            }
                            break;
                        case "ZYJS":
                            zyjsdata = zyjsdal.Get_Zyjs(selectID[0]);
                            ReportParameter[] rptparaZyjs =
                            {
                                 new ReportParameter("parameterJCYJ","GB3847-2005"),
                                    new ReportParameter("parameterJCFF","加载减速法"),
                                    new ReportParameter("parameterLsh", carbg.LSH),
                                    new ReportParameter("parameterStationName", mainPanel.stationinfmodel.STATIONNAME),
                                    new ReportParameter("parameterJcrq", carbg.JCSJ.ToString("yyyy-MM-dd hh:mm:ss")),
                                    new ReportParameter("parameterCzy", carbg.CZY),
                                    new ReportParameter("parameterJsy", carbg.JSY),
                                    new ReportParameter("parameterClxh", carbg.XH),
                                    new ReportParameter("parameterScqy",carbg.SCQY),
                                    new ReportParameter("parameterJzzl", carbg.JZZL),
                                    new ReportParameter("parameterZzl", carbg.ZZL),
                                    new ReportParameter("parameterBsqxs",carbg.BSQXS),
                                    new ReportParameter("parameterJqfs",carbg.JQFS),
                                    new ReportParameter("parameterFdjxh",carbg.FDJXH),
                                    new ReportParameter("parameterGyfs",carbg.GYFS),
                                    new ReportParameter("parameterRlzl",carbg.RLZL),
                                    new ReportParameter("parameterDws",carbg.DWS),
                                    new ReportParameter("parameterQGS",carbg.QGS),
                                    new ReportParameter("parameterFDJH",carbg.FDJHM),
                                    new ReportParameter("parameterXslc",carbg.XSLC),
                                    new ReportParameter("parameterFdjpl",carbg.FDJPL),
                                    new ReportParameter("parameterZcrq", carbg.ZCRQ.ToString("yyyy-MM-dd")),
                                    new ReportParameter("parameterCllx",carbg.CLLX),
                                    new ReportParameter("parameterHpzl",carbg.CPYS),
                                    new ReportParameter("parameterEdgl",carbg.EDGL),
                                    new ReportParameter("parameterEdzs",carbg.EDZS),
                                    new ReportParameter("parameterHbbz","有"),
                                    new ReportParameter("parameterCzdz",""),
                                    new ReportParameter("parameterCzdh",carbg.LXDH),
                                    new ReportParameter("parameterQdfs",carbg.QDXS),
                                    new ReportParameter("parameterChzz",(carbg.JHZZ=="是")?"有":"无"),
                                    new ReportParameter("parameterClph",carbg.CLHP),
                                    new ReportParameter("parameterCpys",carbg.CPYS),
                                    new ReportParameter("parameterClsbm",carbg.CLSBM),
                                    new ReportParameter("parameterCz",carbg.CZ),
                                    new ReportParameter("parameterSbmc",zyjsdata.SBMC),
                                    new ReportParameter("parameterSbbh","--"+"/"+zyjsdata.YDJBH),
                                    new ReportParameter("parameterCgjxh","--"),
                                    new ReportParameter("parameterCgjbh","--"),
                                    new ReportParameter("parameterCgjcj","--"),
                                    new ReportParameter("parameterFxyxh",zyjsdata.YDJXH),
                                    new ReportParameter("parameterFxybh",zyjsdata.YDJBH),
                                    new ReportParameter("parameterFxycj",zyjsdata.YDJZZC),
                                    new ReportParameter("parameterWd",zyjsdata.WD),
                                    new ReportParameter("parameterDqy",zyjsdata.DQY),
                                    new ReportParameter("parameterSd",zyjsdata.SD),
                    
                                    new ReportParameter("parameterDSZS",zyjsdata.DSZS),
                                    new ReportParameter("parameterFIRSTDATA",zyjsdata.FIRSTDATA),
                                    new ReportParameter("parameterSECONDDATA",zyjsdata.SECONDDATA),
                                    new ReportParameter("parameterTHIRDDATA",zyjsdata.THIRDDATA),
                                    new ReportParameter("parameterBTGXZ","≤"+zyjsdata.YDXZ),
                                    new ReportParameter("parameterPJZ",zyjsdata.AVERAGEDATA),
                                    new ReportParameter("parameterBTGPD",zyjsdata.ZHPD),
                                    new ReportParameter("parameterZHPD",(zyjsdata.ZHPD=="合格")?"通过":"未通过"),

                                    new ReportParameter("parameterJDTEL",mainPanel.otherinf.JDDH),
                                    new ReportParameter("parameterFWTEL",mainPanel.otherinf.FWDH),
                                    new ReportParameter("parameterBGRQ",DateTime.Now.ToString("D")),
                                    new ReportParameter("parameterJczdz",mainPanel.stationinfmodel.STATIONADD),
                                    new ReportParameter("parameterJczdh",mainPanel.stationinfmodel.STATIONPHONE),
                                    new ReportParameter("parameterJCZMC",carbg.JCZMC.Split('_')[1])
                            };
                            report.ReportEmbeddedResource = "exhaustDetect.ReportBDZyjs.rdlc";
                            report.SetParameters(rptparaZyjs);
                            break;
                        default: break;
                    }
                    report.DataSources.Clear();
                    string deviceInfo = "<DeviceInfo>" +
                        "  <OutputFormat>EMF</OutputFormat>" +
                        "  <PageWidth>8.27in</PageWidth>" +
                        "  <PageHeight>11.69in</PageHeight>" +
                        "  <MarginTop>0.25in</MarginTop>" +
                        "  <MarginLeft>0.25in</MarginLeft>" +
                        "  <MarginRight>0.25in</MarginRight>" +
                        "  <MarginBottom>0.25in</MarginBottom>" +
                        "</DeviceInfo>";
                    Warning[] warnings;
                    m_streams = new List<Stream>();
                    //m_streams.Clear();
                    //将报表的内容按照deviceInfo指定的格式输出到CreateStream函数提供的Stream中。  
                    report.Render("Image", deviceInfo, CreateStream, out warnings);
                    foreach (Stream stream in m_streams)
                        stream.Position = 0;
                    Print();
                    //Print();
                }
            }
        }
        //声明一个Stream对象的列表用来保存报表的输出数据 
        //LocalReport对象的Render方法会将报表按页输出为多个Stream对象。 
        
        //用来提供Stream对象的函数，用于LocalReport对象的Render方法的第三个参数。
        private Stream CreateStream(string name, string fileNameExtension,Encoding encoding, string mimeType, bool willSeek)  
        {  
            //如果需要将报表输出的数据保存为文件，请使用FileStream对象。  
            //Stream stream = new MemoryStream(); 
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream); 
            return stream; 
        }
         
        
        private void Print()  
        {   
            m_currentPageIndex = 0;  
            if (m_streams == null || m_streams.Count == 0) 
                return;  
            //声明PrintDocument对象用于数据的打印 
            PrintDocument printDoc = new PrintDocument();
            //printDoc.OriginAtMargins = false;
            //指定需要使用的打印机的名称，使用空字符串""来指定默认打印机 
            printDoc.PrinterSettings.PrinterName = mainPanel.linemodel.PRINTER; 
            //判断指定的打印机是否可用  
            if (!printDoc.PrinterSettings.IsValid) 
            {  
                MessageBox.Show("Can't find printer"); 
                return;  
            } 
            //声明PrintDocument对象的PrintPage事件，具体的打印操作需要在这个事件中处理。
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrinterSettings.Copies = short.Parse(textBoxCopy.Text);//设置打印份数
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
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);  
            m_streams[m_currentPageIndex].Close();  
            m_currentPageIndex++; 
            //设置是否需要继续打印  
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count); 
        }

        private void 标记为已缴费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //SYS.Model.CARSAFEDETECTED model = new SYS.Model.CARSAFEDETECTED();
            if (selectID[0] != "")
            {
                switch (dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString())
                {
                    case "环保检查":
                        carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                        if (carbg.CLID == "-2")
                        {
                            MessageBox.Show("车辆信息错误", "系统错误!");
                        }
                        else if (carbg.SFJF == "N")
                        {
                            if (MessageBox.Show("确认标记车辆" + carbg.CLHP + "已领取", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)//如果确认参检
                            {
                                logininfcontrol.setCarbjPayed(carbg.CLID, "Y");
                                string lx = "";
                                if (radioButtonToday.Checked == true)
                                    lx = "当日";
                                else if (radioButtonThisWeek.Checked == true)
                                    lx = "当周";
                                else
                                    lx = "当月";
                                ref_WaitCar(lx);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    
                    default:

                        break;
                }

            }
        }

        private void 标记未领ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (selectID[0] != "")
            {
                switch (dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString())
                {
                    case "环保检查":
                        carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                        if (carbg.CLID == "-2")
                        {
                            MessageBox.Show("车辆信息错误", "系统错误!");
                        }
                        else if (carbg.SFJF == "Y")
                        {
                            if (MessageBox.Show("确认标记车辆" + carbg.CLHP + "未领取", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)//如果确认参检
                            {
                                logininfcontrol.setCarbjPayed(carbg.CLID, "N");
                                string lx = "";
                                if (radioButtonToday.Checked == true)
                                    lx = "当日";
                                else if (radioButtonThisWeek.Checked == true)
                                    lx = "当周";
                                else
                                    lx = "当月";
                                ref_WaitCar(lx);
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    
                    default:
                        
                        break;
                }
                
            }
        }

        private void buttonDataseconds_Click(object sender, EventArgs e)
        {
            if (selectID[0] != "" && dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString() == "环保检查")
            {
                carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                if (carbg.JCFF == "ASM")
                {
                    SYS.Model.ASMseconds asmseconds = asmdal.Get_ASMDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        dataSecondsViewer childreportseconds = new dataSecondsViewer();
                        childreportseconds.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(childreportseconds);
                        childreportseconds.Dock = DockStyle.Fill;
                        childreportseconds.display_dataseconds(FillASMDataToReport(asmseconds, carbg.LSH, carbg.CLSBM), selectID[0]);
                        childreportseconds.BringToFront();
                        childreportseconds.Show();
                        
                    }
                }
                else if (carbg.JCFF == "VMAS")
                {
                    SYS.Model.VMASseconds asmseconds = vmasdal.Get_VMASDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        dataSecondsViewer childreportseconds = new dataSecondsViewer();
                        childreportseconds.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(childreportseconds);
                        childreportseconds.Dock = DockStyle.Fill;
                        childreportseconds.display_dataseconds(FillVMASDataToReport(asmseconds, carbg.LSH, carbg.CLSBM), selectID[0]);
                        childreportseconds.BringToFront();
                        childreportseconds.Show();
                    }
                }
                else if (carbg.JCFF == "SDS")
                {
                    SYS.Model.SDSseconds asmseconds = sdsdal.Get_SDSDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        dataSecondsViewer childreportseconds = new dataSecondsViewer();
                        childreportseconds.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(childreportseconds);
                        childreportseconds.Dock = DockStyle.Fill;
                        childreportseconds.display_dataseconds(FillSDSDataToReport(asmseconds, carbg.LSH, carbg.CLSBM), selectID[0]);
                        childreportseconds.BringToFront();
                        childreportseconds.Show();
                    }
                }
                else if (carbg.JCFF == "JZJS")
                {
                    SYS.Model.JZJSseconds asmseconds = jzjsdal.Get_JzjsDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        dataSecondsViewer childreportseconds = new dataSecondsViewer();
                        childreportseconds.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(childreportseconds);
                        childreportseconds.Dock = DockStyle.Fill;
                        childreportseconds.display_dataseconds(FillLugdownDataToReport(asmseconds, carbg.LSH, carbg.CLSBM), selectID[0]);
                        childreportseconds.BringToFront();
                        childreportseconds.Show();
                    }
                }
                else if (carbg.JCFF == "ZYJS")
                {
                    SYS.Model.ZYJSseconds asmseconds = zyjsdal.Get_ZyjsDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        dataSecondsViewer childreportseconds = new dataSecondsViewer();
                        childreportseconds.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(childreportseconds);
                        childreportseconds.Dock = DockStyle.Fill;
                        childreportseconds.display_dataseconds(FillZyjsDataToReport(asmseconds, carbg.LSH, carbg.CLSBM), selectID[0]);
                        childreportseconds.BringToFront();
                        childreportseconds.Show();
                    }
                }
                else
                {
                    MessageBox.Show("没有该方法的过程数据");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectID[0] != "" && dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString() == "环保检查")
            {
                carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                if (carbg.JCFF == "ASM")
                {
                    SYS.Model.ASMseconds asmseconds = asmdal.Get_ASMDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        过程数据查看 datasecondsshow = new 过程数据查看();
                        datasecondsshow.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(datasecondsshow);
                        datasecondsshow.Dock = DockStyle.Fill;
                        datasecondsshow.FillASMDataToReport(asmseconds, carbg.LSH, carbg.CLSBM);
                        datasecondsshow.BringToFront();
                        datasecondsshow.Show();
                    }
                }
                else if (carbg.JCFF == "VMAS")
                {
                    SYS.Model.VMASseconds asmseconds = vmasdal.Get_VMASDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        过程数据查看 datasecondsshow = new 过程数据查看();
                        datasecondsshow.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(datasecondsshow);
                        datasecondsshow.Dock = DockStyle.Fill;
                        datasecondsshow.FillVMASDataToReport(asmseconds, carbg.LSH, carbg.CLSBM);
                        datasecondsshow.BringToFront();
                        datasecondsshow.Show();
                    }
                }
                else if (carbg.JCFF == "SDS")
                {
                    SYS.Model.SDSseconds asmseconds = sdsdal.Get_SDSDataSeconds(carbg.CLHP,carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        过程数据查看 datasecondsshow = new 过程数据查看();
                        datasecondsshow.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(datasecondsshow);
                        datasecondsshow.Dock = DockStyle.Fill;
                        datasecondsshow.FillSDSDataToReport(asmseconds, carbg.LSH, carbg.CLSBM);
                        datasecondsshow.BringToFront();
                        datasecondsshow.Show();
                    }
                }
                else if (carbg.JCFF == "JZJS")
                {
                    SYS.Model.JZJSseconds asmseconds = jzjsdal.Get_JzjsDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        过程数据查看 datasecondsshow = new 过程数据查看();
                        datasecondsshow.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(datasecondsshow);
                        datasecondsshow.Dock = DockStyle.Fill;
                        datasecondsshow.FillLugdownDataToReport(asmseconds, carbg.LSH, carbg.CLSBM);
                        datasecondsshow.BringToFront();
                        datasecondsshow.Show();
                    }
                }
                else if (carbg.JCFF == "ZYJS")
                {
                    SYS.Model.ZYJSseconds asmseconds = zyjsdal.Get_ZyjsDataSeconds(carbg.CLHP, carbg.JCSJ);
                    if (asmseconds.CLID == "-2")
                    {
                        MessageBox.Show("未找到过程数据");
                    }
                    else
                    {
                        过程数据查看 datasecondsshow = new 过程数据查看();
                        datasecondsshow.TopLevel = false;
                        ((Panel)this.Parent).Controls.Add(datasecondsshow);
                        datasecondsshow.Dock = DockStyle.Fill;
                        datasecondsshow.FillZyjsDataToReport(asmseconds, carbg.LSH, carbg.CLSBM);
                        datasecondsshow.BringToFront();
                        datasecondsshow.Show();
                    }
                }
                else
                {
                    MessageBox.Show("没有该方法的过程数据");
                }
            }
        }

        public DataTable FillASMDataToReport(SYS.Model.ASMseconds dataseconds, string lsh, string vin)
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
            for (int i = 0; i < count - 1; i++)
            {
                dt.Rows.Add(mmsx[i], mmhc[i], mmco[i], mmnox[i], mmo2[i], mmco2[i], mmwd[i], mmsd[i], mmdqy[i], mmcs[i], mmgl[i], mmxzxs[i], mmkcf[i], mmjsgl[i], mmyw[i]);

            }
            return dt;
        }
        public DataTable FillVMASDataToReport(SYS.Model.VMASseconds dataseconds, string lsh, string vin)
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
            return dt;
        }
        public DataTable  FillLugdownDataToReport(SYS.Model.JZJSseconds dataseconds, string lsh, string vin)
        {

            DataTable dt = new DataTable();         //创建一个datatable  
            dt.Columns.Add("时间序列", typeof(string));
            dt.Columns.Add("采样时序", typeof(string));
            dt.Columns.Add("车速", typeof(string));
            dt.Columns.Add("功率", typeof(string));
            dt.Columns.Add("光吸收系数", typeof(string));
            dt.Columns.Add("时序类别", typeof(string));
            dt.Columns.Add("转速", typeof(string));
            string[] mmsj = dataseconds.MMTIME.Split(',');
            string[] mmsx = dataseconds.MMSX.Split(',');
            string[] mmcs = dataseconds.MMCS.Split(',');
            string[] mmgl = dataseconds.MMGL.Split(',');
            string[] mmk = dataseconds.MMK.Split(',');
            string[] mmlb = dataseconds.MMLB.Split(',');
            string[] mmzs = dataseconds.MMZS.Split(',');
            int count = mmsx.Count();
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
                dt.Rows.Add(mmsj[i], mmsx[i], double.Parse(mmcs[i]).ToString("0.0"), double.Parse(mmgl[i]).ToString("0.0"), mmk[i], lb,mmzs[i]);

            }return dt;
        }
        public DataTable FillZyjsDataToReport(SYS.Model.ZYJSseconds dataseconds, string lsh, string vin)
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
                string lb = "第" + mmlb[i] + "次测量";

                dt.Rows.Add(mmsj[i], mmsx[i], mmcs[i], mmk[i], lb);

            }return dt;
        }
        public DataTable FillSDSDataToReport(SYS.Model.SDSseconds dataseconds, string lsh, string vin)
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
                dt.Rows.Add(mmlb[i] == "0" ? "70%工况" : mmlb[i] == "1" ? "高怠速准备" : mmlb[i] == "2" ? "高怠速测量" : mmlb[i] == "3" ? "怠速准备" : "怠速测量", mmsx[i], mmsj[i], mmhc[i], mmco[i], mmo2[i], mmco2[i], mmlabmda[i], mmzs[i], mmyw[i], mmwd[i], mmsd[i], mmdqy[i]);

            }return dt;
        }

        private void 补传检测数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectID[0] != "" && dataGrid_waitcar.SelectedRows[0].Cells["项目"].Value.ToString() == "环保检查")
            {
                carbg = mainPanel.logininfcontrol.getCarbjbycarID(selectID[0]);
                SYS.Model.CARINF carinfo = mainPanel.logininfcontrol.getCarInfbyPlate(carbg.CLHP);
                if (carbg.CLID == "-2")
                {
                    MessageBox.Show("查看报告失败", "系统错误!");
                }
                else
                {
                    switch (carbg.JCFF)
                    {
                        case "ASM":
                            MessageBox.Show("该方法暂不提供该功能");
                            break;
                        case "VMAS":
                            SYS.Model.VMASseconds vmasseconds = vmasdal.Get_VMASDataSeconds(carbg.CLHP, carbg.JCSJ);
                            vmasdata = vmasdal.Get_VMAS(selectID[0]);
                            if (vmasseconds.CLID == "-2")
                            {
                                MessageBox.Show("未找到对应过程数据，不能补传");
                                return;
                            }
                            if (vmasdata.CLID == "-2")
                            {
                                MessageBox.Show("未找到对应结果数据，不能补传");
                                return;
                            }
                            #region 补传过程数据
                            carinfor.vmasProcessData processdata = new carinfor.vmasProcessData();
                            processdata.JCBGBH = carbg.LSH;
                            //asmprocessdata.DJCCY = model.MMSX.Remove(model.MMSX.Length-1);
                            processdata.DJCCY = "195";
                            processdata.SJXL = vmasseconds.MMTIME.Remove(vmasseconds.MMTIME.Length - 1);
                            processdata.HCCLZ = vmasseconds.MMHC.Remove(vmasseconds.MMHC.Length - 1);
                            processdata.NOCLZ = vmasseconds.MMNO.Remove(vmasseconds.MMNO.Length - 1);
                            processdata.COCLZ = vmasseconds.MMCO.Remove(vmasseconds.MMCO.Length - 1);
                            processdata.CO2CLZ = vmasseconds.MMCO2.Remove(vmasseconds.MMCO2.Length - 1);
                            processdata.O2CLZ = vmasseconds.MMO2.Remove(vmasseconds.MMO2.Length - 1);
                            processdata.CS = vmasseconds.MMCS.Remove(vmasseconds.MMCS.Length - 1);
                            processdata.ZS = vmasseconds.MMZS.Remove(vmasseconds.MMZS.Length - 1);
                            processdata.LLJO2 = vmasseconds.MMXSO2.Remove(vmasseconds.MMXSO2.Length - 1);
                            processdata.LLJSJLL = vmasseconds.MMSJLL.Remove(vmasseconds.MMSJLL.Length - 1);
                            processdata.LLJBZLL = vmasseconds.MMBZLL.Remove(vmasseconds.MMBZLL.Length - 1);
                            processdata.QCWQLL = vmasseconds.MMWQLL.Remove(vmasseconds.MMWQLL.Length - 1);
                            processdata.XSB = vmasseconds.MMXSB.Remove(vmasseconds.MMXSB.Length - 1);
                            processdata.LLJWD = vmasseconds.MMLLJWD.Remove(vmasseconds.MMLLJWD.Length - 1);
                            processdata.LLJQY = vmasseconds.MMLLJYL.Remove(vmasseconds.MMLLJYL.Length - 1);
                            processdata.HCPFZL = vmasseconds.MMHCZL.Remove(vmasseconds.MMHCZL.Length - 1);
                            processdata.NOPFZL = vmasseconds.MMNOZL.Remove(vmasseconds.MMNOZL.Length - 1);
                            processdata.COPFZL = vmasseconds.MMCOZL.Remove(vmasseconds.MMCOZL.Length - 1);

                            processdata.XSXZXS = vmasseconds.MMXSXZ.Remove(vmasseconds.MMXSXZ.Length - 1);
                            processdata.SDXZXS = vmasseconds.MMSDXZ.Remove(vmasseconds.MMSDXZ.Length - 1);
                            processdata.JSGL = vmasseconds.MMJSGL.Remove(vmasseconds.MMJSGL.Length - 1);
                            processdata.ZSGL = vmasseconds.MMGL.Remove(vmasseconds.MMGL.Length - 1);
                            processdata.HJWD = vmasseconds.MMWD.Remove(vmasseconds.MMWD.Length - 1);
                            processdata.DQYL = vmasseconds.MMDQY.Remove(vmasseconds.MMDQY.Length - 1);
                            processdata.XDSD = vmasseconds.MMSD.Remove(vmasseconds.MMSD.Length - 1);
                            processdata.YW = vmasseconds.MMYW.Remove(vmasseconds.MMYW.Length - 1);
                            processdata.JCZT = vmasseconds.MMLB.Remove(vmasseconds.MMLB.Length - 1);
                            if (processdata.writevmasProcessData() != "成功")
                            {
                                MessageBox.Show("过程数据上传环保局失败");
                                return;
                            }
                            #endregion
                            #region 上传结果数据
                            carinfor.VMASresultData asmresultdata = new carinfor.VMASresultData();
                            asmresultdata.JCBGBH = carbg.LSH;
                            asmresultdata.WD = vmasdata.WD;
                            asmresultdata.XDSD = vmasdata.SD;
                            asmresultdata.DQY = vmasdata.DQY;
                            asmresultdata.COXZ = vmasdata.COXZ;
                            asmresultdata.COCZL = vmasdata.COZL;
                            asmresultdata.COPDJG = vmasdata.COPD;
                            if (vmasdata.BEFORE == "Y")
                            {
                                asmresultdata.HCXZ = vmasdata.HCXZ;
                                asmresultdata.NOXZ = vmasdata.NOXXZ;
                                asmresultdata.HCPDJG = vmasdata.HCPD;
                                asmresultdata.NOPDJG = vmasdata.NOXPD;
                            }
                            else
                            {
                                asmresultdata.HCNOXZ = vmasdata.HCXZ;
                                asmresultdata.HCNOPDJG = vmasdata.HCPD;
                            }
                            asmresultdata.HCCLZ = vmasdata.HCZL;
                            asmresultdata.NOCLZ = vmasdata.NOXZL;
                            asmresultdata.HCNOCLZ = (Math.Round((double.Parse(vmasdata.HCZL) + double.Parse(vmasdata.NOXZL)), 2)).ToString("0.00");
                            asmresultdata.PDJG = vmasdata.ZHPD;
                            asmresultdata.SHY = mainPanel.shy;
                            asmresultdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            asmresultdata.CSLJCCSJ = vmasdata.CSLJCCSJ;
                            asmresultdata.YW = "";
                            asmresultdata.JCKSSJ = carbg.JCSJ.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            ;
                            asmresultdata.JCJSSJ = carbg.JCSJ.AddSeconds(200).ToString("yyyy-MM-dd HH:mm:ss.fff");
                            asmresultdata.XSLC = vmasdata.XSLC;
                            asmresultdata.CGJSDGL = "1.7";
                            if (asmresultdata.writeVMASresultData() != "成功")
                            {
                                MessageBox.Show("结果数据上传环保局失败");
                                return;
                            }
                            MessageBox.Show("补传数据完成");
                            #endregion
                            break;
                        case "SDS":
                            MessageBox.Show("该方法暂不提供该功能");
                            break;
                        case "JZJS":
                            MessageBox.Show("该方法暂不提供该功能");
                            break;
                        case "ZYJS":
                            MessageBox.Show("该方法暂不提供该功能");
                            break;
                    }
                }
            }
        }
    }
}
