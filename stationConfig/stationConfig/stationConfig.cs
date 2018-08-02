using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SYS_DAL;
using SYS_MODEL;
using SYS.Model;
using ini;

namespace stationConfig
{
    public partial class stationConfig : Form
    {
        public static stationControl stationcontrol = new stationControl();
        public static stationInfModel stationinfmodel = new stationInfModel();
        public static loginInfControl logininfcontrol = new loginInfControl();
        public static lineModel linemodel = new lineModel();
        public static BDSX bdsx = new BDSX();
        public static othersModel otherinf = new othersModel();
        public static lshModel lshmodel = new lshModel();
        public static equipmentModel equipmodel = new equipmentModel();
        public static carinfor.WGSocketInf wgsocketinf = new carinfor.WGSocketInf();
        public static carinfor.CcSocketInf ccsocketinf = new carinfor.CcSocketInf();
        public static carinfor.ACSocketInf acsocketinf = new carinfor.ACSocketInf();
        public static carinfor.JHWebInf jhwebinf = new carinfor.JHWebInf();
        public static carinfor.NeusoftSocketInf neusoftsocketinf = new carinfor.NeusoftSocketInf();
        public static baseControl basecontrol = new baseControl();


        public static int linesCount = 0;
        public static string stationid = "";
        List<string> linelist = new List<string>();
        private string netmode = "";

        DataTable dt_vmasxz1 = null, dt_vmasxz2 = null;
        VMAS_XZDB vmas_xzdb = new SYS.Model.VMAS_XZDB();
        GBDal gbdal = new GBDal();
        string thissystemversion = "v161010";


        public stationConfig()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panelMain.Enabled = false;
            init_stationinf();
            init_staff();
        }
        private bool init_wginf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("万国联网", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            wgsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("万国联网", "服务器PORT", "6061", temp, 2048, @".\appConfig.ini");
            wgsocketinf.PORT = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("万国联网", "检测站简称", "RD", temp, 2048, @".\appConfig.ini");
            wgsocketinf.JCZJC = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("万国联网", "检测站编号", "06", temp, 2048, @".\appConfig.ini");
            wgsocketinf.JCZBH = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("万国联网", "设备认证编号", "01", temp, 2048, @".\appConfig.ini");

            ini.INIIO.GetPrivateProfileString("诚创联网", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            ccsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("诚创联网", "服务器PORT", "7803", temp, 2048, @".\appConfig.ini");
            ccsocketinf.PORT = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("金华联网", "WEBURL", "http://10.33.139.24/services/inspService?wsdl", temp, 2048, @".\appConfig.ini");
            jhwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "SAFEPWD", "webservicepwd", temp, 2048, @".\appConfig.ini");
            jhwebinf.safepwd = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "STATIONID", "33070102", temp, 2048, @".\appConfig.ini");
            jhwebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            jhwebinf.lineid = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("联网信息", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            acsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网信息", "服务器PORT", "7803", temp, 2048, @".\appConfig.ini");
            acsocketinf.PORT = temp.ToString().Trim();


            ini.INIIO.GetPrivateProfileString("东软联网", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            neusoftsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("东软联网", "服务器PORT", "8081", temp, 2048, @".\appConfig.ini");
            neusoftsocketinf.PORT = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("东软联网", "EISID", "0000000049", temp, 2048, @".\appConfig.ini");
            neusoftsocketinf.EISID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("东软联网", "地区", "福建省", temp, 2048, @".\appConfig.ini");
            neusoftsocketinf.AREA = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("东软联网", "登录用引车员", "", temp, 2048, @".\appConfig.ini");
            neusoftsocketinf.YCY = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("联网模式", "模式", "万国联网", temp, 2048, @".\appConfig.ini");
            netmode = temp.ToString().Trim();
            wgsocketinf.SBRZBH = temp.ToString().Trim();
            textBoxWGFWQIP.Text = wgsocketinf.IP;
            textBoxWGFWQPORT.Text = wgsocketinf.PORT;
            textBoxWGJCZBH.Text = wgsocketinf.JCZBH;
            textBoxWGJCZJC.Text = wgsocketinf.JCZJC;
            textBoxWGSBRZBH.Text = wgsocketinf.SBRZBH;
            textBoxCCFWQIP.Text = ccsocketinf.IP;
            textBoxCCFWQPORT.Text = ccsocketinf.PORT;
            textBoxAcIP.Text = acsocketinf.IP;
            textBoxAcPort.Text = acsocketinf.PORT;
            textBoxNeusoftIP.Text = neusoftsocketinf.IP;
            textBoxNeusoftPort.Text = neusoftsocketinf.PORT;
            textBoxEISID.Text = neusoftsocketinf.EISID;

            textBoxJHWEBURL.Text = jhwebinf.weburl;
            textBoxJHSTATIONID.Text = jhwebinf.stationid;
            textBoxJHSAFEPWD.Text = jhwebinf.safepwd;
            textBoxJHLINEID.Text = jhwebinf.lineid;

            comboBoxNeusoftArea.Text = neusoftsocketinf.AREA;
            comboBoxNETMODE.Text = netmode;
            return true;
        }

        private void init_staff()
        {
            DataTable dt = null;
            string postid = basecontrol.getIDByName("引车员", "职位", "POSTID");
            dt = logininfcontrol.getStaffByPost(postid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBoxNeuYcy.Items.Add(dt.Rows[i]["NAME"].ToString());
            }
            if (comboBoxNeuYcy.Items.Contains(neusoftsocketinf.YCY))
                comboBoxNeuYcy.Text = neusoftsocketinf.YCY;
            else
                comboBoxNeuYcy.SelectedIndex = 0;
        }
        private void init_stationinf()
        {
            init_wginf();
            stationid = stationcontrol.getStationID();
            initLinesList();
            stationinfmodel = stationcontrol.getStationInf(stationid);
            bdsx = stationcontrol.getDemarcateInf();
            linesCount = stationcontrol.getStationLineCount(stationid);
            //linemodel = stationcontrol.getLineInf(stationid, lineid);
            //lshmodel = stationcontrol.getLineLshInf(stationid, lineid);
            //equipmodel = stationcontrol.getLineEquipInf(stationid, lineid);           
            otherinf = stationcontrol.getOtherInf();
            textBoxSTATIONID.Text = stationid;
            textBoxNAME.Text = stationinfmodel.STATIONNAME;
            textBoxADD.Text = stationinfmodel.STATIONADD;
            textBoxTEL.Text = stationinfmodel.STATIONPHONE;
            textBoxCMA.Text = stationinfmodel.STATIONDATE;
            comboBoxJCFF.Text = (stationinfmodel.STATIONJCFF == "ASM") ? "稳态工况法" : "简易瞬态工况法";
            textBoxCOMPANYNAME.Text = stationinfmodel.StationCompany;
            textBoxJCZXKZH.Text = stationinfmodel.JCZXKZH;
            dateTimePicker1.Value = stationinfmodel.YXQSTARTTIME;
            dateTimePicker2.Value = stationinfmodel.YXQENDTIME;
            checkBoxIsLock.Checked = stationinfmodel.ISLOCK;
            textBoxLinesCount.Text = linesCount.ToString();
            radioButtonLineConfig.Checked = true;

            textBoxHX.Text = bdsx.HXSX;
            textBoxGL.Text = bdsx.GLSX;
            textBoxJSGL.Text = bdsx.JSGLSX;
            textBoxYR.Text = bdsx.YRSX;
            textBoxZJ.Text = bdsx.ZJSX;
            textBoxYLJ.Text = bdsx.YLJSX;
            textBoxSD.Text = bdsx.SDSX;
            textBoxHJCS.Text = bdsx.HJCSSX;
            textBoxZSJ.Text = bdsx.ZSJSX;
            textBoxFXYLOW.Text = bdsx.FXYLOWSX;
            textBoxFXYMID.Text = bdsx.FXYMIDSX;
            textBoxFXYHIGH.Text = bdsx.FXYHIGHSX;
            textBoxYDJ.Text = bdsx.YDJSX;
            textBoxLLJ.Text = bdsx.LLJSX;

            showLineEquiInf("stationLine");
        }
        private void initLinesList()
        {
            linelist.Clear();
            DataTable datagrid = logininfcontrol.getStationLineInf("stationLine", stationid);
            if (datagrid.Rows.Count > 0)
            {
                for (int i = 0; i < datagrid.Rows.Count; i++)
                    linelist.Add(datagrid.Rows[i]["LINEID"].ToString());
            }
        }
        private void showLineEquiInf(string projectname)
        {
            DataTable datagrid = logininfcontrol.getStationLineInf(projectname, stationid);
            if (datagrid.Rows.Count > 0)
            {
                //datagrid.Rows.RemoveAt(0);
                //setDataGridView(datagrid);
                for (int i = 0; i < datagrid.Rows.Count; i++)
                {
                    if (!linelist.Contains(datagrid.Rows[i]["LINEID"].ToString()))
                    {
                        datagrid.Rows.RemoveAt(i);
                        i--;
                    }
                }
                dataGridView1.DataSource = datagrid;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                    dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                    dataGridView1.Columns["STATIONID"].ReadOnly = true;
                    dataGridView1.Columns["LINEID"].ReadOnly = true;
                    if (radioButtonLineConfig.Checked)
                    {
                        dataGridView1.Columns["ASM"].HeaderText = "稳态工况";
                        dataGridView1.Columns["VMAS"].HeaderText = "简易瞬态";
                        dataGridView1.Columns["SDS"].HeaderText = "双怠速";
                        dataGridView1.Columns["JZJS_LIGHT"].HeaderText = "轻柴Lugdown";
                        dataGridView1.Columns["JZJS_HEAVY"].HeaderText = "重柴Lugdown";
                        dataGridView1.Columns["ZYJS"].HeaderText = "自由加速";
                        dataGridView1.Columns["LZ"].HeaderText = "滤纸";
                        dataGridView1.Columns["PRINTER"].HeaderText = "打印机";
                        dataGridView1.Columns["AUTOPRINT"].HeaderText = "自动打印";
                        dataGridView1.Columns["AUTOPRINT"].ReadOnly = true;
                        dataGridView1.Columns["JCXXKZBH"].HeaderText = "检测线许可证编号";
                        dataGridView1.Columns["YXQSTARTTIME"].HeaderText = "有效期起始日期";
                        dataGridView1.Columns["YXQENDTIME"].HeaderText = "有效期终止日期";
                        dataGridView1.Columns["ISLOCK"].HeaderText = "是否锁止";
                        dataGridView1.Columns["LOCKREASON"].HeaderText = "锁止原因";
                    }
                    else if (radioButtonLineCalInf.Checked)
                    {
                        dataGridView1.Columns["YRENABLE"].HeaderText = "设备预热";
                        dataGridView1.Columns["ZJENABLE"].HeaderText = "设备自检";
                        dataGridView1.Columns["HXENABLE"].HeaderText = "加载滑行";
                        dataGridView1.Columns["GLENABLE"].HeaderText = "惯量测试";
                        dataGridView1.Columns["JSGLENABLE"].HeaderText = "寄生功率";
                        dataGridView1.Columns["YLJENABLE"].HeaderText = "压力计校准";
                        dataGridView1.Columns["SDENABLE"].HeaderText = "转速传感器校准";
                        dataGridView1.Columns["FXYLOWENABLE"].HeaderText = "废气分析仪低量程检查";
                        dataGridView1.Columns["FXYHIGHENABLE"].HeaderText = "废气分析仪高量程检查";
                        dataGridView1.Columns["FXYMIDENABLE"].HeaderText = "废气分析仪中量程检查";
                        dataGridView1.Columns["YDJENABLE"].HeaderText = "烟度计日常检查";
                        dataGridView1.Columns["LLJENABLE"].HeaderText = "流量计日常检查";
                        dataGridView1.Columns["HJCSENABLE"].HeaderText = "环境参数校准";
                        dataGridView1.Columns["ZSJENABLE"].HeaderText = "发动机转速计校准";

                        dataGridView1.Columns["YRDATE"].Visible = false;
                        dataGridView1.Columns["ZJDATE"].Visible = false;
                        dataGridView1.Columns["HXDATE"].Visible = false;
                        dataGridView1.Columns["GLDATE"].Visible = false;
                        dataGridView1.Columns["JSGLDATE"].Visible = false;
                        dataGridView1.Columns["YLJDATE"].Visible = false;
                        dataGridView1.Columns["SDDATE"].Visible = false;
                        dataGridView1.Columns["FXYLOWDATE"].Visible = false;
                        dataGridView1.Columns["FXYHIGHDATE"].Visible = false;
                        dataGridView1.Columns["FXYMIDDATE"].Visible = false;
                        dataGridView1.Columns["YDJDATE"].Visible = false;
                        dataGridView1.Columns["LLJDATE"].Visible = false;
                        dataGridView1.Columns["HJCSDATE"].Visible = false;
                        dataGridView1.Columns["ZSJDATE"].Visible = false;
                    }
                    else
                    {
                        dataGridView1.Columns["SBMC"].HeaderText = "设备名称";
                        dataGridView1.Columns["SBXH"].HeaderText = "设备型号";
                        dataGridView1.Columns["SBZZC"].HeaderText = "设备制造厂";
                        dataGridView1.Columns["CGJXH"].HeaderText = "测功机型号";
                        dataGridView1.Columns["CGJBH"].HeaderText = "测功机编号";
                        dataGridView1.Columns["CGJZZC"].HeaderText = "测功机制造厂";
                        dataGridView1.Columns["FXYXH"].HeaderText = "废气仪型号";
                        dataGridView1.Columns["FXYBH"].HeaderText = "废气仪编号";
                        dataGridView1.Columns["FXYZZC"].HeaderText = "废气仪制造厂";
                        dataGridView1.Columns["LLJXH"].HeaderText = "流量计型号";
                        dataGridView1.Columns["LLJBH"].HeaderText = "流量计编号";
                        dataGridView1.Columns["LLJZZC"].HeaderText = "流量计制造厂";
                        dataGridView1.Columns["YDJXH"].HeaderText = "烟度计型号";
                        dataGridView1.Columns["YDJBH"].HeaderText = "烟度计编号";
                        dataGridView1.Columns["YDJZZC"].HeaderText = "烟度计制造厂";
                        dataGridView1.Columns["LZYDJXH"].HeaderText = "滤纸烟度计型号";
                        dataGridView1.Columns["LZYDJBH"].HeaderText = "滤纸烟度计编号";
                        dataGridView1.Columns["LZYDJZZC"].HeaderText = "滤纸烟度计制造厂";
                        dataGridView1.Columns["ZSJXH"].HeaderText = "转速计型号";
                        dataGridView1.Columns["ZSJBH"].HeaderText = "转速计编号";
                        dataGridView1.Columns["ZSJZZC"].HeaderText = "转速计制造厂";
                    }
                }
            }
        }

        private void init_vmasxzdatagrid()
        {
            vmas_xzdb = gbdal.Get_VMAS_XZDB();
            DataRow dr = null;
            dt_vmasxz1 = new DataTable();
            dt_vmasxz1.Columns.Add("基准质量(kg)");
            dt_vmasxz1.Columns.Add("CO(g/km)");
            dt_vmasxz1.Columns.Add("HC(g/km)");
            dt_vmasxz1.Columns.Add("NOx(g/km)");
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第一类车(RM≤1020)";
            dr["CO(g/km)"] = vmas_xzdb.S1020d1date20000701bco;
            dr["HC(g/km)"] = vmas_xzdb.S1020d1date20000701bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S1020d1date20000701bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第一类车(1020<RM≤1470)";
            dr["CO(g/km)"] = vmas_xzdb.S10201470d1date20000701bco;
            dr["HC(g/km)"] = vmas_xzdb.S10201470d1date20000701bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S10201470d1date20000701bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第一类车(1470<RM≤1930)";
            dr["CO(g/km)"] = vmas_xzdb.S14701930d1date20000701bco;
            dr["HC(g/km)"] = vmas_xzdb.S14701930d1date20000701bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S14701930d1date20000701bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第一类车(1930<RM)";
            dr["CO(g/km)"] = vmas_xzdb.S1930d1date20000701bco;
            dr["HC(g/km)"] = vmas_xzdb.S1930d1date20000701bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S1930d1date20000701bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第二类车(RM≤1020)";
            dr["CO(g/km)"] = vmas_xzdb.S1020d2date20011001bco;
            dr["HC(g/km)"] = vmas_xzdb.S1020d2date20011001bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S1020d2date20011001bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第二类车(1020<RM≤1470)";
            dr["CO(g/km)"] = vmas_xzdb.S10201470d2date20011001bco;
            dr["HC(g/km)"] = vmas_xzdb.S10201470d2date20011001bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S10201470d2date20011001bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第二类车(1470<RM≤1930)";
            dr["CO(g/km)"] = vmas_xzdb.S14701930d2date20011001bco;
            dr["HC(g/km)"] = vmas_xzdb.S14701930d2date20011001bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S14701930d2date20011001bno;
            dt_vmasxz1.Rows.Add(dr);
            dr = dt_vmasxz1.NewRow();
            dr["基准质量(kg)"] = "第二类车(1930<RM)";
            dr["CO(g/km)"] = vmas_xzdb.S1930d2date20011001bco;
            dr["HC(g/km)"] = vmas_xzdb.S1930d2date20011001bhc;
            dr["NOx(g/km)"] = vmas_xzdb.S1930d2date20011001bno;
            dt_vmasxz1.Rows.Add(dr);
            dataGridViewVmasXz1.DataSource = dt_vmasxz1;
            dt_vmasxz2 = new DataTable();
            dt_vmasxz2.Columns.Add("基准质量(kg)");
            dt_vmasxz2.Columns.Add("CO(g/km)");
            dt_vmasxz2.Columns.Add("HC+NOx(g/km)");
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第一类车(RM≤1250)";
            dr["CO(g/km)"] = vmas_xzdb.S1250d1date20000701aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S1250d1date20000701ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第一类车(1250<RM≤1700)";
            dr["CO(g/km)"] = vmas_xzdb.S12501700d1date20000701aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S12501700d1date20000701ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第一类车(1700<RM)";
            dr["CO(g/km)"] = vmas_xzdb.S1700d1date20000701aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S1700d1date20000701ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第二类车(RM≤1250)";
            dr["CO(g/km)"] = vmas_xzdb.S1250d2date20011001aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S1250d2date20011001ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第二类车(1250<RM≤1700)";
            dr["CO(g/km)"] = vmas_xzdb.S12501700d2date20011001aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S12501700d2date20011001ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dr = dt_vmasxz2.NewRow();
            dr["基准质量(kg)"] = "第二类车(1700<RM)";
            dr["CO(g/km)"] = vmas_xzdb.S1700d2date20011001aco;
            dr["HC+NOx(g/km)"] = vmas_xzdb.S1700d2date20011001ahcnox;
            dt_vmasxz2.Rows.Add(dr);
            dataGridViewVmasXz2.DataSource = dt_vmasxz2;
            for (int i = 0; i < this.dataGridViewVmasXz1.Columns.Count; i++)
            {
                this.dataGridViewVmasXz1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < this.dataGridViewVmasXz2.Columns.Count; i++)
            {
                this.dataGridViewVmasXz2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewVmasXz1.Columns["基准质量(kg)"].ReadOnly = true;
            dataGridViewVmasXz2.Columns["基准质量(kg)"].ReadOnly = true;

        }
        private void radioButtonLineCalInf_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineCalInf.Checked)
            {
                showLineEquiInf("设备标定");
            }
        }

        private void radioButtonLineConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineConfig.Checked)
                showLineEquiInf("stationLine");
        }

        private void radioButtonLineEquipment_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineEquipment.Checked)
                showLineEquiInf("检测线设备");

        }

        private void buttonSaveStatonInf_Click(object sender, EventArgs e)
        {
            stationInfModel model = stationinfmodel;
            model.STATIONID = textBoxSTATIONID.Text;
            model.STATIONNAME = textBoxNAME.Text;
            model.STATIONADD = textBoxADD.Text;
            model.STATIONPHONE = textBoxTEL.Text;
            model.STATIONJCFF = (comboBoxJCFF.Text == "稳态工况法") ? "ASM" : "VMAS";
            model.STATIONDATE = textBoxCMA.Text;
            model.StationCompany = textBoxCOMPANYNAME.Text;
            model.SBHZBH = textBoxCMA.Text;
            model.JCZXKZH = textBoxJCZXKZH.Text;
            model.ISLOCK = checkBoxIsLock.Checked;
            model.LOCKREASON = "";
            logininfcontrol.setThisStationID(model.STATIONID);
            logininfcontrol.setStationLineStationID(model.STATIONID);
            logininfcontrol.setStationLSHStationID(model.STATIONID);
            logininfcontrol.setStationNormalInfStationID(model.STATIONID);
            logininfcontrol.setDermacateStationID(model.STATIONID);
            logininfcontrol.setStationEquipmentStationID(model.STATIONID);
            logininfcontrol.setThisStationInf(model.STATIONNAME, model.STATIONADD, model.STATIONPHONE, model.STATIONJCFF, model.STATIONDATE, model.StationCompany, model.SBHZBH, model.YXQSTARTTIME, model.YXQENDTIME, model.JCZXKZH, model.ISLOCK,model.STANDARD);
            init_stationinf();
            MessageBox.Show("检测站信息更改成功");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int linescountToSave = int.Parse(textBoxLinesCount.Text);
            for (int i = 1; i <= linescountToSave; i++)
            {
                string lineid = "0" + i.ToString();
                if (!logininfcontrol.checkLineIsAlive(stationid, lineid))
                {
                    lineModel linemodel = new lineModel();
                    linemodel.StationID = stationid;
                    linemodel.LINEID = lineid;
                    linemodel.ASM = "N";
                    linemodel.VMAS = "N";
                    linemodel.JZJS_LIGHT = "N";
                    linemodel.JZJS_HEAVY = "N";
                    linemodel.LZ = "N";
                    linemodel.SDS = "N";
                    linemodel.ZYJS = "N";
                    linemodel.PRINTER = "";
                    linemodel.AUTOPRINT = "N";
                    logininfcontrol.saveLineInf(linemodel);
                }
                if (!logininfcontrol.checkLineLSHIsAlive(stationid, lineid))
                {
                    lshModel linemodel = new lshModel();
                    linemodel.StationID = stationid;
                    linemodel.LINEID = lineid;
                    linemodel.DATE = DateTime.Now;
                    linemodel.COUNT = "1";
                    logininfcontrol.saveLineLSHInf(linemodel);
                }
                if (!logininfcontrol.checkLineEquipIsAlive(stationid, lineid))
                {
                    equipmentModel linemodel = new equipmentModel();
                    linemodel.StationID = stationid;
                    linemodel.LINEID = lineid;
                    linemodel.SBMC = "排放检测系统";
                    linemodel.SBXH = "CG-GK-V/A";
                    linemodel.SBZZC = "";
                    linemodel.CGJXH = "DCG-10B";
                    linemodel.CGJBH = "151001001";
                    linemodel.CGJZZC = "成都新成";
                    linemodel.FXYXH = "MQW_50A";
                    linemodel.FXYBH = "151001001";
                    linemodel.FXYZZC = "浙大鸣泉";
                    linemodel.LLJXH = "MQL-100";
                    linemodel.LLJBH = "151001001";
                    linemodel.LLJZZC = "浙大鸣泉";
                    linemodel.YDJXH = "MQY-200";
                    linemodel.YDJBH = "151001001";
                    linemodel.YDJZZC = "浙大鸣泉";
                    linemodel.LZYDJXH = "YD-1";
                    linemodel.LZYDJBH = "151001001";
                    linemodel.LZYDJZZC = "浙大鸣泉";
                    linemodel.ZSJXH = "MQZ-3";
                    linemodel.ZSJBH = "151001001";
                    linemodel.ZSJZZC = "浙大鸣泉";
                    logininfcontrol.saveLineEquipInf(linemodel);
                }
                if (!logininfcontrol.checkLineCalIsAlive(stationid, lineid))
                {
                    LINESBBD linemodel = new LINESBBD();
                    linemodel.STATIONID = stationid;
                    linemodel.LINEID = lineid;
                    linemodel.Hxdate = DateTime.Now;
                    linemodel.Hxenable = true;
                    linemodel.Gldate = DateTime.Now;
                    linemodel.Glenable = true;
                    linemodel.Jsgldate = DateTime.Now;
                    linemodel.Jsglenable = true;
                    linemodel.Yljdate = DateTime.Now;
                    linemodel.Yljenable = true;
                    linemodel.Sddate = DateTime.Now;
                    linemodel.Sdenable = true;
                    linemodel.Fxylowdate = DateTime.Now;
                    linemodel.Fxylowenable = true;
                    linemodel.Fxyhighdate = DateTime.Now;
                    linemodel.Fxyhighenable = true;
                    linemodel.Fxymiddate = DateTime.Now;
                    linemodel.Fxymidenable = true;
                    linemodel.Fxylowmiddate = DateTime.Now;
                    linemodel.Fxylowmidenable = true;
                    linemodel.Fxyhighmiddate = DateTime.Now;
                    linemodel.Fxyhighmidenable = true;
                    linemodel.Ydjdate = DateTime.Now;
                    linemodel.Ydjenable = true;
                    linemodel.Lljdate = DateTime.Now;
                    linemodel.Lljenable = true;
                    linemodel.Hjcsdate = DateTime.Now;
                    linemodel.Hjcsenable = true;
                    linemodel.Zsjdate = DateTime.Now;
                    linemodel.Zsjenable = true;
                    linemodel.Yrdate = DateTime.Now;
                    linemodel.Yrenable = true;
                    linemodel.Zjdate = DateTime.Now;
                    linemodel.Zjenable = true;
                    logininfcontrol.saveLineCalInf(linemodel);
                }
            }
            for (int i = linescountToSave + 1; i < 10; i++)
            {
                string lineid = "0" + i.ToString();
                logininfcontrol.deleteLineInf("stationLine", stationid, lineid);
                logininfcontrol.deleteLineInf("设备标定", stationid, lineid);
                logininfcontrol.deleteLineInf("流水号信息", stationid, lineid);
                logininfcontrol.deleteLineInf("检测线设备", stationid, lineid);
            }
            init_stationinf();
            MessageBox.Show("保存成功");
        }


        private void buttonCancelStationInf_Click(object sender, EventArgs e)
        {
            init_stationinf();
        }

        private void buttonCancelLineCount_Click(object sender, EventArgs e)
        {
            init_stationinf();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            init_stationinf();
        }

        private void buttonLineInf_Click(object sender, EventArgs e)
        {
            if (radioButtonLineConfig.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    lineModel linemodeltoSave = new lineModel();
                    linemodeltoSave.StationID = dataGridView1.Rows[i].Cells["STATIONID"].Value.ToString();
                    linemodeltoSave.LINEID = dataGridView1.Rows[i].Cells["LINEID"].Value.ToString();
                    linemodeltoSave.ASM = dataGridView1.Rows[i].Cells["ASM"].Value.ToString();
                    linemodeltoSave.VMAS = dataGridView1.Rows[i].Cells["VMAS"].Value.ToString();
                    linemodeltoSave.SDS = dataGridView1.Rows[i].Cells["SDS"].Value.ToString();
                    linemodeltoSave.JZJS_LIGHT = dataGridView1.Rows[i].Cells["JZJS_LIGHT"].Value.ToString();
                    linemodeltoSave.JZJS_HEAVY = dataGridView1.Rows[i].Cells["JZJS_HEAVY"].Value.ToString();
                    linemodeltoSave.ZYJS = dataGridView1.Rows[i].Cells["ZYJS"].Value.ToString();
                    linemodeltoSave.LZ = dataGridView1.Rows[i].Cells["LZ"].Value.ToString();
                    linemodeltoSave.PRINTER = dataGridView1.Rows[i].Cells["PRINTER"].Value.ToString();
                    linemodeltoSave.AUTOPRINT = dataGridView1.Rows[i].Cells["AUTOPRINT"].Value.ToString();
                    linemodeltoSave.JCXXKZBH = dataGridView1.Rows[i].Cells["JCXXKZBH"].Value.ToString();
                    linemodeltoSave.YXQSTARTTIME = DateTime.Parse(dataGridView1.Rows[i].Cells["YXQSTARTTIME"].Value.ToString());
                    linemodeltoSave.YXQENDTIME = DateTime.Parse(dataGridView1.Rows[i].Cells["YXQENDTIME"].Value.ToString());
                    linemodeltoSave.ISLOCK = (dataGridView1.Rows[i].Cells["ISLOCK"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.LOCKREASON = dataGridView1.Rows[i].Cells["LOCKREASON"].Value.ToString();
                    logininfcontrol.saveLineInf(linemodeltoSave);
                    MessageBox.Show("success to update!");
                }

            }
            else if (radioButtonLineCalInf.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    LINESBBD linemodeltoSave = new LINESBBD();
                    linemodeltoSave.STATIONID = dataGridView1.Rows[i].Cells["STATIONID"].Value.ToString();
                    linemodeltoSave.LINEID = dataGridView1.Rows[i].Cells["LINEID"].Value.ToString();
                    linemodeltoSave = stationcontrol.getLineDemarcateInf(linemodeltoSave.STATIONID, linemodeltoSave.LINEID);
                    linemodeltoSave.Yrenable = (dataGridView1.Rows[i].Cells["YRENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Zjenable = (dataGridView1.Rows[i].Cells["ZJENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Hxenable = (dataGridView1.Rows[i].Cells["HXENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Glenable = (dataGridView1.Rows[i].Cells["GLENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Jsglenable = (dataGridView1.Rows[i].Cells["JSGLENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Yljenable = (dataGridView1.Rows[i].Cells["YLJENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Sdenable = (dataGridView1.Rows[i].Cells["SDENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Hjcsenable = (dataGridView1.Rows[i].Cells["HJCSENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Zsjenable = (dataGridView1.Rows[i].Cells["ZSJENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Fxylowenable = (dataGridView1.Rows[i].Cells["FXYLOWENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Fxyhighenable = (dataGridView1.Rows[i].Cells["FXYHIGHENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Fxymidenable = (dataGridView1.Rows[i].Cells["FXYMIDENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Fxylowmidenable = (dataGridView1.Rows[i].Cells["FXYLOWMIDENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Fxyhighmidenable = (dataGridView1.Rows[i].Cells["FXYHIGHMIDENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Ydjenable = (dataGridView1.Rows[i].Cells["YDJENABLE"].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.Lljenable = (dataGridView1.Rows[i].Cells["LLJENABLE"].Value.ToString().ToUpper() == "Y");
                    logininfcontrol.saveLineCalInf(linemodeltoSave);
                    MessageBox.Show("success to update!");
                }

            }
            else if (radioButtonLineEquipment.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    equipmentModel linemodeltoSave = new equipmentModel();
                    linemodeltoSave.StationID = dataGridView1.Rows[i].Cells["STATIONID"].Value.ToString();
                    linemodeltoSave.LINEID = dataGridView1.Rows[i].Cells["LINEID"].Value.ToString();
                    linemodeltoSave.SBMC = dataGridView1.Rows[i].Cells["SBMC"].Value.ToString();
                    linemodeltoSave.SBXH = dataGridView1.Rows[i].Cells["SBXH"].Value.ToString();
                    linemodeltoSave.SBZZC = dataGridView1.Rows[i].Cells["SBZZC"].Value.ToString();
                    linemodeltoSave.CGJXH = dataGridView1.Rows[i].Cells["CGJXH"].Value.ToString();
                    linemodeltoSave.CGJBH = dataGridView1.Rows[i].Cells["CGJBH"].Value.ToString();
                    linemodeltoSave.CGJZZC = dataGridView1.Rows[i].Cells["CGJZZC"].Value.ToString();
                    linemodeltoSave.FXYXH = dataGridView1.Rows[i].Cells["FXYXH"].Value.ToString();
                    linemodeltoSave.FXYBH = dataGridView1.Rows[i].Cells["FXYBH"].Value.ToString();
                    linemodeltoSave.FXYZZC = dataGridView1.Rows[i].Cells["FXYZZC"].Value.ToString();
                    linemodeltoSave.LLJXH = dataGridView1.Rows[i].Cells["LLJXH"].Value.ToString();
                    linemodeltoSave.LLJBH = dataGridView1.Rows[i].Cells["LLJBH"].Value.ToString();
                    linemodeltoSave.LLJZZC = dataGridView1.Rows[i].Cells["LLJZZC"].Value.ToString();
                    linemodeltoSave.YDJXH = dataGridView1.Rows[i].Cells["YDJXH"].Value.ToString();
                    linemodeltoSave.YDJBH = dataGridView1.Rows[i].Cells["YDJBH"].Value.ToString();
                    linemodeltoSave.YDJZZC = dataGridView1.Rows[i].Cells["YDJZZC"].Value.ToString();
                    linemodeltoSave.LZYDJXH = dataGridView1.Rows[i].Cells["LZYDJXH"].Value.ToString();
                    linemodeltoSave.LZYDJBH = dataGridView1.Rows[i].Cells["LZYDJBH"].Value.ToString();
                    linemodeltoSave.LZYDJZZC = dataGridView1.Rows[i].Cells["LZYDJZZC"].Value.ToString();
                    linemodeltoSave.ZSJXH = dataGridView1.Rows[i].Cells["ZSJXH"].Value.ToString();
                    linemodeltoSave.ZSJBH = dataGridView1.Rows[i].Cells["ZSJBH"].Value.ToString();
                    linemodeltoSave.ZSJZZC = dataGridView1.Rows[i].Cells["ZSJZZC"].Value.ToString();
                    logininfcontrol.saveLineEquipInf(linemodeltoSave);
                    MessageBox.Show("success to update!");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ini.INIIO.WritePrivateProfileString("万国联网", "服务器IP", textBoxWGFWQIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("万国联网", "服务器PORT", textBoxWGFWQPORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("万国联网", "检测站简称", textBoxWGJCZJC.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("万国联网", "检测站编号", textBoxWGJCZBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("万国联网", "设备认证编号", textBoxWGSBRZBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("诚创联网", "服务器IP", textBoxCCFWQIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("诚创联网", "服务器PORT", textBoxCCFWQPORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("诚创联网", "服务器IP", textBoxCCFWQIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("诚创联网", "服务器PORT", textBoxCCFWQPORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("欧润特联网", "服务器IP", textBoxOrtIp.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("欧润特联网", "服务器PORT", textBoxOrtPort.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("联网信息", "服务器IP", textBoxAcIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("联网信息", "服务器PORT", textBoxAcPort.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "服务器IP", textBoxNeusoftIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "服务器PORT", textBoxNeusoftPort.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "EISID", textBoxEISID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "地区", comboBoxNeusoftArea.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "登录用引车员", comboBoxNeuYcy.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "WEBURL", textBoxJHWEBURL.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "SAFEPWD", textBoxJHSAFEPWD.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "STATIONID", textBoxJHSTATIONID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "LINEID", textBoxJHLINEID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("联网模式", "模式", comboBoxNETMODE.Text, @".\appConfig.ini");
            MessageBox.Show("success to update!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            init_stationinf();
        }
        private void createTable(string TableName)
        {
            if (!basecontrol.checkTableIsExist(TableName))
                basecontrol.createTalbe(TableName);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string listname;
            listname = "车辆信息";
            string[] addkeyarraycarInf = { "HPZL" };
            //keyname = "FOURTHDATA";
            foreach (string keyname in addkeyarraycarInf)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "Zyjs_Btg";
            string[] addkeyarray = { "FOURTHDATA", "JCFF" };
            //keyname = "FOURTHDATA";
            foreach (string keyname in addkeyarray)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "ASM";
            string[] addkeyarray2 = { "CO25025", "O25025", "CO22540", "O22540" };
            foreach (string keyname in addkeyarray2)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "SDS";
            string[] addkeyarraySDS = { "CO2HIGH", "O2HIGH", "CO2LOW", "O2LOW" };
            foreach (string keyname in addkeyarraySDS)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "检测线设备";
            string[] addkeyarrayLZ = { "LZYDJXH", "LZYDJBH", "LZYDJZZC" };
            foreach (string keyname in addkeyarrayLZ)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "待检车辆";
            string[] addkeyarray3 = { "SFCJ", "JYLSH", "HPZL" };
            foreach (string keyname in addkeyarray3)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "已检车辆信息";
            string[] addkeyarray4 = { "QDLTQY", "RYPH", "HPZL" };
            foreach (string keyname in addkeyarray4)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addkeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            textBoxUpdate.AppendText("检查表[变载荷滑行测试]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("变载荷滑行测试"))
            {
                textBoxUpdate.AppendText("表[变载荷滑行测试]不存在\r\n");
                basecontrol.createTalbe("变载荷滑行测试", "STATIONID varchar(50) not null, LINEID varchar(50) not null, HXQJ varchar(50), CCDT varchar(50), ACDT varchar(50), WC varchar(50), BDJG varchar(50), BZSM varchar(50), CZY varchar(50), BDRQ datetime");
                textBoxUpdate.AppendText("表[变载荷滑行测试]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[变载荷滑行测试]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[操作日志]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("操作日志"))
            {
                textBoxUpdate.AppendText("表[操作日志]不存在\r\n");
                basecontrol.createTalbe("操作日志", "PROID varchar(50) not null primary key, PRONAME varchar(50),STATIONID varchar(50), LINEID varchar(50), CZY varchar(50), DATA varchar(100), STATE varchar(50), RESULT varchar(50), BZSM varchar(100), BDRQ datetime");
                textBoxUpdate.AppendText("表[操作日志]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[操作日志]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[废气仪检查]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("废气仪检查"))
            {
                textBoxUpdate.AppendText("表[废气仪检查]不存在\r\n");
                basecontrol.createTalbe("废气仪检查", "STATIONID varchar(50), LINEID varchar(50), CO2BZ varchar(50), CO2CLZ varchar(50), COBZ varchar(50), COCLZ varchar(50), HCBZ varchar(50), HCCLZ varchar(50), NOBZ varchar(50), NOCLZ varchar(50), JZDS varchar(50), GDJZ varchar(50), BZSM varchar(50), BDJG varchar(50), BDRQ datetime");
                textBoxUpdate.AppendText("表[废气仪检查]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[废气仪检查]已存在\r\n");
            }


            textBoxUpdate.AppendText("检查表[气象站校准]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("气象站校准"))
            {
                textBoxUpdate.AppendText("表[气象站校准]不存在\r\n");
                basecontrol.createTalbe("气象站校准", "STATIONID varchar(50), LINEID varchar(50), WDBZ varchar(50), WDSCZ varchar(50), SDBZ varchar(50), SDSCZ varchar(50), DQYBZ varchar(50), DQYSCZ varchar(50), WDWC varchar(50), SDWC varchar(50), DQYWC varchar(50), BZSM varchar(50), BDJG varchar(50), CZY varchar(50), BDRQ datetime");
                textBoxUpdate.AppendText("表[气象站校准]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[气象站校准]已存在\r\n");
            }

            textBoxUpdate.AppendText("检查表[认证信息]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("认证信息"))
            {
                textBoxUpdate.AppendText("表[认证信息]不存在\r\n");
                basecontrol.createTalbe("认证信息", "ID varchar(50) not null primary key, RZBH varchar(50), RZYXQ varchar(50)");
                textBoxUpdate.AppendText("表[认证信息]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[认证信息]已存在\r\n");
            }

            textBoxUpdate.AppendText("检查表[响应时间测试]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("响应时间测试"))
            {
                textBoxUpdate.AppendText("表[响应时间测试]不存在\r\n");
                basecontrol.createTalbe("响应时间测试", "STATIONID varchar(50) not null, LINEID varchar(50) not null, SPEED varchar(50), STARTPOWER varchar(50), STARTFORCE varchar(50), ENDPOWER varchar(50), ENDFORCE varchar(50), XYTIME varchar(50), WDTIME varchar(50), BDJG varchar(50), CZY varchar(50), BDRQ datetime");
                textBoxUpdate.AppendText("表[响应时间测试]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[响应时间测试]已存在\r\n");
            }

            textBoxUpdate.AppendText("检查表[烟度计标定]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("烟度计标定"))
            {
                textBoxUpdate.AppendText("表[烟度计标定]不存在\r\n");
                basecontrol.createTalbe("烟度计标定", "STATIONID varchar(50) not null, LINEID varchar(50) not null, KBZ varchar(50), KSCZ varchar(50), KABSWC varchar(50), KRELWC varchar(50), BDJG varchar(50), BZSM varchar(50), CZY varchar(50), BDRQ datetime");
                textBoxUpdate.AppendText("表[烟度计标定]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[烟度计标定]已存在\r\n");
            }

            textBoxUpdate.AppendText("检查表[自检记录]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("自检记录"))
            {
                textBoxUpdate.AppendText("表[自检记录]不存在\r\n");
                basecontrol.createTalbe("自检记录", "ID varchar(50) not null primary key, WORKTIME datetime, WORKER varchar(50), ISQXZCHECK varchar(1), ISFQYCHECK varchar(1), ISBTGCHECK varchar(1), ISCGJCHECK varchar(1), ISLLJCHECK varchar(1), ISZSJCHECK varchar(1), TEMPOK varchar(1), HUMIOK varchar(1), AIRPOK varchar(1), TEMP varchar(50), HUMI varchar(50), AIRP varchar(50), FQYTX varchar(1), FQYYR varchar(1), FQYTL varchar(1), FQYJL varchar(1), FQYLC varchar(1), FQYO2 varchar(50), BTGTX varchar(1), BTGYR varchar(1), BTGTL varchar(1), BTGLC varchar(1), BTGJZ varchar(1), CGJTX varchar(1), CGJYR varchar(1), CGJQL varchar(1), CGJJSGL varchar(1), CGJJZHX varchar(1), CGJEDGL varchar(50), CGJSJGL varchar(50), CGJGLWC varchar(50), CGJVITRUALTIME varchar(50), CGJREALTIME varchar(50), CGJTIMEWC varchar(50), LLJTX varchar(1), LLJLL varchar(1), ZSJTX varchar(1), ZSJLC varchar(1)");
                textBoxUpdate.AppendText("表[自检记录]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[自检记录]已存在\r\n");
            }
            basecontrol.UpdateSystemVersion(thissystemversion);
            textBoxUpdate.AppendText("升级完毕\r\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VMAS_XZDB xztosave = new VMAS_XZDB();
            xztosave.S1020d1date20000701bco = dataGridViewVmasXz1.Rows[0].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1020d1date20000701bhc = dataGridViewVmasXz1.Rows[0].Cells["HC(g/km)"].Value.ToString();
            xztosave.S1020d1date20000701bno = dataGridViewVmasXz1.Rows[0].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S10201470d1date20000701bco = dataGridViewVmasXz1.Rows[1].Cells["CO(g/km)"].Value.ToString();
            xztosave.S10201470d1date20000701bhc = dataGridViewVmasXz1.Rows[1].Cells["HC(g/km)"].Value.ToString();
            xztosave.S10201470d1date20000701bno = dataGridViewVmasXz1.Rows[1].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S14701930d1date20000701bco = dataGridViewVmasXz1.Rows[2].Cells["CO(g/km)"].Value.ToString();
            xztosave.S14701930d1date20000701bhc = dataGridViewVmasXz1.Rows[2].Cells["HC(g/km)"].Value.ToString();
            xztosave.S14701930d1date20000701bno = dataGridViewVmasXz1.Rows[2].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S1930d1date20000701bco = dataGridViewVmasXz1.Rows[3].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1930d1date20000701bhc = dataGridViewVmasXz1.Rows[3].Cells["HC(g/km)"].Value.ToString();
            xztosave.S1930d1date20000701bno = dataGridViewVmasXz1.Rows[3].Cells["NOx(g/km)"].Value.ToString();

            xztosave.S1020d2date20011001bco = dataGridViewVmasXz1.Rows[4].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1020d2date20011001bhc = dataGridViewVmasXz1.Rows[4].Cells["HC(g/km)"].Value.ToString();
            xztosave.S1020d2date20011001bno = dataGridViewVmasXz1.Rows[4].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S10201470d2date20011001bco = dataGridViewVmasXz1.Rows[5].Cells["CO(g/km)"].Value.ToString();
            xztosave.S10201470d2date20011001bhc = dataGridViewVmasXz1.Rows[5].Cells["HC(g/km)"].Value.ToString();
            xztosave.S10201470d2date20011001bno = dataGridViewVmasXz1.Rows[5].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S14701930d2date20011001bco = dataGridViewVmasXz1.Rows[6].Cells["CO(g/km)"].Value.ToString();
            xztosave.S14701930d2date20011001bhc = dataGridViewVmasXz1.Rows[6].Cells["HC(g/km)"].Value.ToString();
            xztosave.S14701930d2date20011001bno = dataGridViewVmasXz1.Rows[6].Cells["NOx(g/km)"].Value.ToString();
            xztosave.S1930d2date20011001bco = dataGridViewVmasXz1.Rows[7].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1930d2date20011001bhc = dataGridViewVmasXz1.Rows[7].Cells["HC(g/km)"].Value.ToString();
            xztosave.S1930d2date20011001bno = dataGridViewVmasXz1.Rows[7].Cells["NOx(g/km)"].Value.ToString();


            xztosave.S1250d1date20000701aco = dataGridViewVmasXz2.Rows[0].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1250d1date20000701ahcnox = dataGridViewVmasXz2.Rows[0].Cells["HC+NOx(g/km)"].Value.ToString();
            xztosave.S12501700d1date20000701aco = dataGridViewVmasXz2.Rows[1].Cells["CO(g/km)"].Value.ToString();
            xztosave.S12501700d1date20000701ahcnox = dataGridViewVmasXz2.Rows[1].Cells["HC+NOx(g/km)"].Value.ToString();
            xztosave.S1700d1date20000701aco = dataGridViewVmasXz2.Rows[2].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1700d1date20000701ahcnox = dataGridViewVmasXz2.Rows[2].Cells["HC+NOx(g/km)"].Value.ToString();
            xztosave.S1250d2date20011001aco = dataGridViewVmasXz2.Rows[3].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1250d2date20011001ahcnox = dataGridViewVmasXz2.Rows[3].Cells["HC+NOx(g/km)"].Value.ToString();
            xztosave.S12501700d2date20011001aco = dataGridViewVmasXz2.Rows[4].Cells["CO(g/km)"].Value.ToString();
            xztosave.S12501700d2date20011001ahcnox = dataGridViewVmasXz2.Rows[4].Cells["HC+NOx(g/km)"].Value.ToString();
            xztosave.S1700d2date20011001aco = dataGridViewVmasXz2.Rows[5].Cells["CO(g/km)"].Value.ToString();
            xztosave.S1700d2date20011001ahcnox = dataGridViewVmasXz2.Rows[5].Cells["HC+NOx(g/km)"].Value.ToString();
            if (gbdal.Save_VMAS_XZDB(xztosave) > 0)
                MessageBox.Show("success to update!");
            else
                MessageBox.Show("update failed!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BDSX bdsxtosave = new BDSX();
            bdsxtosave = bdsx;
            bdsxtosave.HXSX = textBoxHX.Text;
            bdsxtosave.HXSX = textBoxHX.Text;
            bdsxtosave.GLSX = textBoxGL.Text;
            bdsxtosave.JSGLSX = textBoxJSGL.Text;
            bdsxtosave.YRSX = textBoxYR.Text;
            bdsxtosave.ZJSX = textBoxZJ.Text;
            bdsxtosave.YLJSX = textBoxYLJ.Text;
            bdsxtosave.SDSX = textBoxSD.Text;
            bdsxtosave.HJCSSX = textBoxHJCS.Text;
            bdsxtosave.ZSJSX = textBoxZSJ.Text;
            bdsxtosave.FXYLOWSX = textBoxFXYLOW.Text;
            bdsxtosave.FXYMIDSX = textBoxFXYMID.Text;
            bdsxtosave.FXYHIGHSX = textBoxFXYHIGH.Text;
            bdsxtosave.YDJSX = textBoxYDJ.Text;
            bdsxtosave.LLJSX = textBoxLLJ.Text;
            if (stationcontrol.updateBdsx(bdsxtosave))
                MessageBox.Show("保存成功");
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string presystemversion = basecontrol.GetSystemVersion();
            if (basecontrol.GetSystemVersion() != thissystemversion)
            {
                textBoxCheck.AppendText("当前版本：" + presystemversion + "\r\n");
                textBoxCheck.AppendText("不是最新版本，请进行升级" + "\r\n");
            }
            else
            {
                textBoxCheck.AppendText("当前版本：" + presystemversion + "\r\n");
                textBoxCheck.AppendText("已是最新版本" + "\r\n");

            }
        }
    }
}
