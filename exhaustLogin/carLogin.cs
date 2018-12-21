using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SYS_DAL;
using SYS_MODEL;
using SYS.Model;
using carinfor;
using System.Diagnostics;
using System.Threading;
using static carinfor.DictionaryExtensionMethodClass;
using JxWebClient;
using System.Collections;

namespace exhaustDetect
{
    public partial class carLogin : Form
    {
        BardCodeHooK BarCode = new BardCodeHooK();
        public bool ref_zt = true;
        public static bool checkTM = true;
        private loginInfModel logininfmodel = new loginInfModel();
        private loginInfControl logininfcontrol = new loginInfControl();
        private stationControl stationcontrol = new stationControl();
        private baseControl basecontrol = new baseControl();
        public static CARATWAIT carbj = new CARATWAIT();
        public static JHWebClient.JHvehicleInf carbjJh = new JHWebClient.JHvehicleInf();
        private carInidata carinidata = new carInidata();
        public static carinfor.limitdata limitdatainf = new carinfor.limitdata();
        public static string outLookID = "";
        private carIni carini = new carIni();
        public static CARINF modelbj = new CARINF();
        public int Carwait_Scroll = 0;                                                  //待检车滚动条位置
        DataTable dt_wait = null;                                                         //等待车辆列表
        public string[] selectID = new string[1024];                                    //当前等待车辆选中的列表
        public static string wxbj = "";
        public static string wxcd = "";
        public static string wxsj = "";
        public static string wxfy = "";
        public static string bgffyy = "";
        public bool iswxok = false;
        public bool iswxinfok = false;
        public static List<CARATWAIT> jhwaitlist = new List<CARATWAIT>();
        public static List<CARINF> jhcarinflist = new List<CARINF>();
        public static List<JHWebClient.JHvehicleInf> jhvehicleinflist = new List<JHWebClient.JHvehicleInf>();
        public static List<CARATWAIT> jhwaitlistOnthisLine = new List<CARATWAIT>();
        public static List<CARINF> jhcarinflistOnthisLine = new List<CARINF>();
        public static List<JHWebClient.JHvehicleInf> jhvehicleinflistOnthisLine = new List<JHWebClient.JHvehicleInf>();
        public static NhWebClient.VehicleInfo vehicleinfo = new NhWebClient.VehicleInfo();

        //public static List<AhWebClient.AhCarInfo> ahvehicleinflist = new List<AhWebClient.AhCarInfo>();
        public static List<CARATWAIT> ahwaitlist = new List<CARATWAIT>();
        public static List<CARINF> ahcarinflist = new List<CARINF>();
        public static List<CARATWAIT> ahwaitlistOnthisLine = new List<CARATWAIT>();
        public static List<CARINF> ahcarinflistOnthisLine = new List<CARINF>();
        //public static List<AhWebClient.AhCarInfo> ahvehicleinflistOnthisline = new List<AhWebClient.AhCarInfo>();

        public static List<CARATWAIT> jswaitlist = new List<CARATWAIT>();
        public static List<CARATWAIT> jswaitlistOnthisLine = new List<CARATWAIT>();


        public static List<jxcarinf> jxcarlist = new List<jxcarinf>();
        public static jxcarinf jxthiscarinf;

        public static  bool isDriverOK = false;
        public static bool isCarOK = false;
        public int tmcount = 0;

        public static string neusoft_idlereason="";
        public struct carAtWaitInf
        {
            public string plate;
            public string loginTime;
            public string jccs;
        };

        public static string jsqdltqy="正常";
        public static string jsqdfs = "前驱";
        public static string jsryph = "单燃料:汽油";    
        
        private List<carAtWaitInf> carAtWaitlist = new List<carAtWaitInf>();

        public static string ahDriverID = "";
        public static string ahOperatorID = "";
        public static string hhzDriverID = "";
        public static string hhzOperatorID = "";


        public static carinfo.XB_CARINFO xbcarinfo = new carinfo.XB_CARINFO();
        public static carinfo.XB_SDSXZ xbsdsxz = new carinfo.XB_SDSXZ();
        public static carinfo.XB_VMASXZ xbvmasxz = new carinfo.XB_VMASXZ();
        public static carinfo.XB_LUGDOWNXZ xblugdownxz = new carinfo.XB_LUGDOWNXZ();
        public static carinfo.XB_BTGXZ xbbtgxz = new carinfo.XB_BTGXZ();
        public static carinfo.XB_LZXZ xblzxz = new carinfo.XB_LZXZ();
        public static carinfo.XB_SDSMXZ xbsdsmxz = new carinfo.XB_SDSMXZ();
        public carLogin()
        {
            InitializeComponent();
            BarCode.BarCodeEvent += new BardCodeHooK.BardCodeDeletegate(BarCode_BarCodeEvent);
        }
        private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);
        private void ShowInfo(BardCodeHooK.BarCodes barCode)
        {
            label1.Focus();
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
            }
            else
            {
                //richTextBox1.Focus();
                //textBox1.Text = barCode.KeyName;
                //textBox2.Text = barCode.VirtKey.ToString();
                //textBox3.Text = barCode.ScanCode.ToString();
                //textBox4.Text = barCode.Ascll.ToString();
                //textBox5.Text = barCode.Chr.ToString();
                //textBox6.Text = barCode.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入
                //textBox7.Text += barCode.KeyName; 
                if (barCode.IsValid &&mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.TYNETMODE)
                {
                    //LogMessage("条码内容：" + barCode.BarCode);
                    textBoxPlateAtWait.Text = barCode.BarCode;
                    Application.DoEvents();
                    if (textBoxPlateAtWait.Text.Trim().Length >=19)
                    {
                        searchPlate(1);
                    }
                    else
                    {
                        MessageBox.Show("JYLSH长度错误，规定长度为19" + ",读取长度为" + textBoxPlateAtWait.Text.Length.ToString());
                        //("VIN码长度错误，规定长度为" + thisSysConfig.BarCodeLength.ToString() + ",该车VIN长度为" + textBoxCLHP.Text.Length.ToString());
                    }
                }
            }
        }
        void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        {
            ShowInfo(barCode);
        }

        private void carLogin_Load(object sender, EventArgs e)
        {
            init_datagrid();
            logininfmodel = logininfcontrol.getLoginDefaultInf();
            textBoxPlateAtWait.Text = logininfmodel.CLHP;
            
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                textBoxNhPlate.Text = logininfmodel.CLHP;
                textBoxNhPlateType.SelectedIndex = 0;
                panelNhCar.Visible = true;
            }
            if ((mainPanel.NetMode == mainPanel.CCNETMODE||mainPanel.NetMode==mainPanel.JINGHUANETMODE||mainPanel.NetMode==mainPanel.JIANGSHUNETMODE||mainPanel.NetMode==mainPanel.AHNETMODE||mainPanel.NetMode==mainPanel.NHNETMODE ||mainPanel.NetMode==mainPanel.JXNETMODE|| mainPanel.NetMode == mainPanel.TYNETMODE||mainPanel.NetMode==mainPanel.GUILINNETMODE || mainPanel.NetMode == mainPanel.PNNETMODE) && mainPanel.isNetUsed)
            {
                labelBgff.Visible = false;
                comboBoxBgff.Visible = false;
                panel3.Size = new Size(293,410);
            }
            if ((mainPanel.NetMode == mainPanel.NEUSOFTNETMODE && (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS||mainPanel.neusoftsocketinf.AREA==mainPanel.NEU_V301)) && mainPanel.isNetUsed)
            {
                labelBgff.Visible = false;
                comboBoxBgff.Visible = false;
                panel3.Size = new Size(293, 410);
            }
            if (mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.GUILINNETMODE || mainPanel.NetMode == mainPanel.PNNETMODE))
            {
                tabControl1.Size = new Size(289, 241);
                dateTimeInput1.Value = DateTime.Now;
                dateTimeInput2.Value = DateTime.Now;
                if (mainPanel.linemodel.ASM == "Y") radioButtonASM.Checked = true;
                else if (mainPanel.linemodel.SDS == "Y") radioButtonSDS.Checked = true;
                else if (mainPanel.linemodel.JZJS_HEAVY == "Y" || mainPanel.linemodel.JZJS_LIGHT == "Y") radioButtonLUG.Checked = true;
                else if (mainPanel.linemodel.ZYJS == "Y") radioButtonZYJS.Checked = true;
                else radioButtonASM.Checked = true;
            }
            if (mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.JIANGSHUNETMODE)
            {
                panelJs.Visible = true;
                comboBoxRLZL.Enabled = false;
                checkBoxSRL.Checked = false;
                comboBoxQdxs.SelectedIndex = 0;
                comboBoxQdltqy.SelectedIndex = 0;
                panel3.Size = new Size(293, 307);
            }
            if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.XBNETMODE)
            {
                labelBgff.Visible = false;
                comboBoxBgff.Visible = false;
                panel3.Size = new Size(293, 410);
            }
            if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.ZKYTNETMODE)
            {
                labelBgff.Visible = false;
                comboBoxBgff.Visible = false;
                panel3.Size = new Size(293, 410);
            }
            else
            {
                panelJs.Visible = false;
                panel3.Size = new Size(293, 410);
            }
            if(mainPanel.yztm==null)
            {
                labelTmState.Text = "未配置该功能";
            }
            else if(mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.CYNETMODE)
            {
                labelTmState.Text = "正在扫描";
            }
            else if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.ZKYTNETMODE)
            {
                labelTmState.Text = "正在扫描";
            }
            else
            {
                labelTmState.Text = "正在扫描";
            }
            ref_WaitCar();
            init_staff();
            comboBoxBgff.SelectedIndex = 0;
            mainPanel.isStartTimerInCarlogin = true;
            BarCode.Start();
            timer1.Start();
        }
        private void init_staff()
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NEUSOFTNETMODE&&(mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT|| mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301) )
            {
                if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT)
                {
                    for (int i = 0; i < mainPanel.NeusoftDriverNameList.Count; i++)
                    {
                        comboBoxJGY.Items.Add(mainPanel.NeusoftDriverNameList[i]);
                    }
                    comboBoxCzy.Visible = false;
                    labelCzy.Visible = false;
                }
                else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)
                {
                    for (int i = 0; i < mainPanel.NeusoftDriverNameList.Count; i++)
                    {
                        comboBoxJGY.Items.Add(mainPanel.NeusoftDriverNameList[i]);
                    }
                    for (int i = 0; i < mainPanel.NeusoftOperatorNameList.Count; i++)
                    {
                        comboBoxCzy.Items.Add(mainPanel.NeusoftOperatorNameList[i]);
                    }
                    comboBoxCzy.Visible = true;
                    labelCzy.Visible = true;
                }
            }
            else if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.AHNETMODE)
            {
                for(int i=0;i<mainPanel.syncinf.leadDriverlist.Count;i++)
                {
                    comboBoxJGY.Items.Add(mainPanel.syncinf.leadDriverlist[i].drivername);
                }
                for (int i = 0; i < mainPanel.syncinf.operatorlist.Count; i++)
                {
                    comboBoxCzy.Items.Add(mainPanel.syncinf.operatorlist[i].operatorname);
                }
            }
            else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
            {
                for (int i = 0; i < mainPanel.hhzpersonlist.Count; i++)
                {
                    comboBoxJGY.Items.Add(mainPanel.hhzpersonlist[i].name);
                    comboBoxCzy.Items.Add(mainPanel.hhzpersonlist[i].name);
                }
            }
            else
            {
                if (!mainPanel.useHyDatabase)
                {
                    string postid = basecontrol.getIDByName("引车员", "职位", "POSTID");
                    DataTable dt = logininfcontrol.getStaffByPost(postid);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBoxJGY.Items.Add(dt.Rows[i]["NAME"].ToString());
                    }
                }
                else
                {
                    string postid = mainPanel.userGroupHy["引车员"];
                    DataTable dt = new DataTable();
                    hyDatabaseInter.readUserByGourpID(postid, out dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBoxJGY.Items.Add(dt.Rows[i]["EMP_NAME"].ToString());
                    }
                    if(comboBoxJGY.Items.Count>0)
                         comboBoxJGY.SelectedIndex =0;
                }
                comboBoxCzy.Visible = false;
                labelCzy.Visible = false;
            }
        }
        private void init_datagrid()
        {
            dt_wait = new DataTable();
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NEUSOFTNETMODE)//东软联网下没有检测方式,根据车辆信息自己判断
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("燃油");
                dt_wait.Columns.Add("车牌颜色");
                dt_wait.Columns.Add("检测方法");
                dataGrid_waitcar.DataSource = dt_wait;
                if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                {
                    dataGrid_waitcar.Columns["车牌号"].Width = 110;
                    //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                    dataGrid_waitcar.Columns["燃油"].Width = 60;
                    dataGrid_waitcar.Columns["车牌颜色"].Width = 60;
                    dataGrid_waitcar.Columns["检测方法"].Width = 100;
                    dataGrid_waitcar.Columns["燃油"].Visible = false;
                }
                else
                {
                    dataGrid_waitcar.Columns["车牌号"].Width = 100;
                    //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                    dataGrid_waitcar.Columns["燃油"].Width = 80;
                    dataGrid_waitcar.Columns["车牌颜色"].Width = 90;
                    dataGrid_waitcar.Columns["检测方法"].Visible = false;
                }
            }
            else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("车牌颜色");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 140;
                dataGrid_waitcar.Columns["车牌颜色"].Width = 130;
            }
            else if (mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.NHNETMODE||mainPanel.NetMode==mainPanel.JXNETMODE))
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("车牌颜色");
                dt_wait.Columns.Add("检测方法");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 120;
                //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                dataGrid_waitcar.Columns["检测方法"].Width = 150;
            }
            else if (mainPanel.isNetUsed &&  mainPanel.NetMode == mainPanel.XBNETMODE)
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("号牌种类");
                dt_wait.Columns.Add("检测方法");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 120;
                //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                dataGrid_waitcar.Columns["检测方法"].Width = 150;
            }
            else if(mainPanel.isNetUsed&&(mainPanel.NetMode==mainPanel.GUILINNETMODE))
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("检测类型");
                dt_wait.Columns.Add("检测方法");
                dt_wait.Columns.Add("检测方法代号");
                dt_wait.Columns.Add("登录时间");
                dt_wait.Columns.Add("登录员");
                //dt_wait.Columns.Add("登录时间");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 120;
                //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                dataGrid_waitcar.Columns["检测方法"].Width = 150;
                dataGrid_waitcar.Columns["检测编号"].Visible = false;
                dataGrid_waitcar.Columns["检测方法代号"].Visible = false;
                dataGrid_waitcar.Columns["登录时间"].Visible = false;
                dataGrid_waitcar.Columns["登录员"].Visible = false;
            }
            else if (mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.PNNETMODE))
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("检测类型");
                dt_wait.Columns.Add("检测方法");
                dt_wait.Columns.Add("检测方法代号");
                dt_wait.Columns.Add("登录时间");
                dt_wait.Columns.Add("登录员");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 120;
                dataGrid_waitcar.Columns["检测方法"].Width = 150;
                dataGrid_waitcar.Columns["检测编号"].Visible = false;
                dataGrid_waitcar.Columns["检测方法代号"].Visible = false;
                dataGrid_waitcar.Columns["登录时间"].Visible = false;
                dataGrid_waitcar.Columns["登录员"].Visible = false;
            }
            else
            {
                dt_wait.Columns.Add("检测编号");
                dt_wait.Columns.Add("车牌号");
                dt_wait.Columns.Add("登录时间");
                dt_wait.Columns.Add("检测方法");
                dataGrid_waitcar.DataSource = dt_wait;
                dataGrid_waitcar.Columns["车牌号"].Width = 120;
                //dataGrid_waitcar.Columns["登录时间"].Width = 120;
                dataGrid_waitcar.Columns["检测方法"].Width = 150;
            }
            dataGrid_waitcar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void ref_WaitCar()
        {
            try
            {
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NEUSOFTNETMODE)
                {
                    #region 东软

                    if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)//v3.0协议要求检完车后必须重新登录才能获取到车辆的详细信息
                    {
                        string result, info;
                        //mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                        //mainPanel.nowUser.ycyuserPassword = (mainPanel.logininfcontrol.getStaffByName(mainPanel.nowUser.ycyuserName)).Rows[0]["PASSWORD"].ToString();
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        if (mainPanel.neusoftsocket.loginUserv301(mainPanel.NeusoftOperatorNameList[0], "111111", "0", mainPanel.NeusoftDriverNameList[0], "111111", out result, out info))
                        {
                            if (result != "1")
                            {
                                MessageBox.Show(info, "警告");
                            }
                        }
                        else
                        {
                            MessageBox.Show("登录指令发送失败和没有响应", "警告");
                        }
                    }
                    if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                    {
                        DataTable vehicleList = null;
                        string result, inf, timestring;
                        if (!mainPanel.sysocket.GetVehicleList(out result, out inf, out vehicleList))
                        {
                            MessageBox.Show("异常:" + result + "|信息:" + inf, "错误");
                        }
                        else
                        {
                            dt_wait.Rows.Clear();
                            DataRow dr = null;
                            if (vehicleList != null)
                            {
                                int i = 1;
                                foreach (DataRow dR in vehicleList.Rows)
                                {
                                    dr = dt_wait.NewRow();
                                    dr["检测编号"] = i++.ToString();
                                    dr["车牌号"] = dR["License"].ToString();
                                    switch (dR["VehicleKind"].ToString())
                                    {
                                        case "0":
                                            if (mainPanel.linemodel.ASM == "N" && mainPanel.linemodel.SDS == "N" && mainPanel.linemodel.VMAS == "N") continue;
                                            dr["燃油"] = "汽油车";
                                            break;
                                        case "1":
                                            if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N" && mainPanel.linemodel.ZYJS == "N") continue;
                                            dr["燃油"] = "柴油车";
                                            break;

                                        default: break;
                                    }
                                    switch (dR["LicenseType"].ToString())
                                    {
                                        case "0":
                                            dr["车牌颜色"] = "蓝牌";
                                            break;
                                        case "1":
                                            dr["车牌颜色"] = "黄牌";
                                            break;
                                        case "2":
                                            dr["车牌颜色"] = "黑牌";
                                            break;
                                        case "3":
                                            dr["车牌颜色"] = "白牌";
                                            break;
                                        default: break;
                                    }
                                    switch (dR["CheckType"].ToString())
                                    {
                                        case "0":
                                            dr["检测方法"] = "稳态工况";
                                            break;
                                        case "1":
                                            dr["检测方法"] = "双怠速";
                                            break;
                                        case "2":
                                            dr["检测方法"] = "简易瞬态";
                                            break;
                                        case "3":
                                            dr["检测方法"] = "加载减速";
                                            break;
                                        case "4":
                                            dr["检测方法"] = "滤纸";
                                            break;
                                        case "5":
                                            dr["检测方法"] = "自由加速";
                                            break;
                                        default: break;
                                    }
                                    dt_wait.Rows.Add(dr);
                                }
                            }
                            //ref_zt = false;
                            dataGrid_waitcar.DataSource = dt_wait;
                            dataGrid_waitcar.Columns["检测编号"].Visible = false;
                            //dataGrid_waitcar.Columns["登录时间"].Visible = false;
                            if (dataGrid_waitcar.Rows.Count > 0)
                                dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                            dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                            ref_zt = true;
                            if (dataGrid_waitcar.Rows.Count > 0)
                            {
                                dataGrid_waitcar.Rows[0].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        DataTable vehicleList = mainPanel.neusoftsocket.GetVehicleList();
                        dt_wait.Rows.Clear();
                        DataRow dr = null;
                        if (vehicleList != null)
                        {
                            int i = 1;
                            foreach (DataRow dR in vehicleList.Rows)
                            {
                                dr = dt_wait.NewRow();
                                dr["检测编号"] = i++.ToString();
                                dr["车牌号"] = dR["License"].ToString();
                                switch (dR["VehicleKind"].ToString())
                                {
                                    case "0":
                                        if (mainPanel.linemodel.ASM == "N" && mainPanel.linemodel.SDS == "N" && mainPanel.linemodel.VMAS == "N") continue;
                                        dr["燃油"] = "汽油车";
                                        break;
                                    case "1":
                                        if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N" && mainPanel.linemodel.ZYJS == "N") continue;
                                        dr["燃油"] = "柴油车";
                                        break;

                                    default: break;
                                }
                                switch (dR["LicenseType"].ToString())
                                {
                                    case "0":
                                        dr["车牌颜色"] = "蓝牌";
                                        break;
                                    case "1":
                                        dr["车牌颜色"] = "黄牌";
                                        break;
                                    case "2":
                                        dr["车牌颜色"] = "黑牌";
                                        break;
                                    case "3":
                                        dr["车牌颜色"] = "白牌";
                                        break;
                                    default: break;
                                }
                                dr["检测方法"] = "";
                                dt_wait.Rows.Add(dr);
                            }
                        }
                        //ref_zt = false;
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        //dataGrid_waitcar.Columns["登录时间"].Visible = false;
                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }
                    }
                    #endregion 
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                {
                    #region 安徽
                    ahwaitlistOnthisLine.Clear();
                    ahcarinflistOnthisLine.Clear();
                    //ahvehicleinflistOnthisline.Clear();
                    int ahresult;
                    string ahErrMsg;
                    if (mainPanel.ahinterface.getInSpectQueueByDate(DateTime.Parse("2000-01-01 00:00:00"), DateTime.Now, out ahresult, out ahErrMsg, out ahwaitlist, out ahcarinflist))
                    {
                        dt_wait.Rows.Clear();
                        DataRow dr = null;
                        for (int i = 0; i < ahwaitlist.Count; i++)
                        {
                            dr = dt_wait.NewRow();
                            dr["检测编号"] = ahwaitlist[i].CLID;
                            dr["车牌号"] = ahwaitlist[i].CLHP;
                            dr["登录时间"] = ahwaitlist[i].DLSJ.ToString("yyyy-MM-dd HH:mm:ss");
                            switch (ahwaitlist[i].JCFF)
                            {
                                case "ASM":
                                    if (mainPanel.linemodel.ASM == "N") continue;
                                    dr["检测方法"] = "稳态工况法";
                                    break;
                                case "VMAS":
                                    if (mainPanel.linemodel.VMAS == "N") continue;
                                    dr["检测方法"] = "简易瞬态工况法";
                                    break;
                                case "JZJS":
                                    if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                    dr["检测方法"] = "加载减速法";
                                    break;
                                case "ZYJS":
                                    if (mainPanel.linemodel.ZYJS == "N") continue;
                                    dr["检测方法"] = "自由加速法";
                                    break;
                                case "SDS":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法";
                                    break;
                                case "LZ":
                                    if (mainPanel.linemodel.LZ == "N") continue;
                                    dr["检测方法"] = "滤纸烟度法";
                                    break;
                                default: dr["检测方法"] = "其他方法"; break;
                            }

                            ahwaitlistOnthisLine.Add(ahwaitlist[i]);
                            ahcarinflistOnthisLine.Add(ahcarinflist[i]);
                            //ahvehicleinflistOnthisline.Add(ahvehicleinflist[i]);
                            dt_wait.Rows.Add(dr);
                        }
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        dataGrid_waitcar.Columns["登录时间"].Visible = false;
                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        for (int i = 0; i < this.dataGrid_waitcar.Columns.Count; i++)
                        {

                            this.dataGrid_waitcar.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                        }
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("result:" + ahresult + "\r\n" + "ErrMsg:" + ahErrMsg);
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                {
                    #region 南华
                    int nhcode, nhexpcode;
                    string nhmsg, nhexpmsg;
                    DataTable vehicleList = mainPanel.nhinterface.GetVehicleList(out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    if (nhcode == 0 && nhexpcode == 0)
                    {
                        dt_wait.Rows.Clear();
                        DataRow dr = null;
                        if (vehicleList != null)
                        {
                            int i = 1;
                            foreach (DataRow dR in vehicleList.Rows)
                            {
                                dr = dt_wait.NewRow();
                                dr["检测编号"] = dR["TestRunningNumber"].ToString();
                                dr["车牌号"] = dR["PlateNumber"].ToString();
                                dr["车牌颜色"] = dR["PlateType"].ToString();
                                dr["检测方法"] = mainPanel.nhinterface.NH_TestType.GetValue(dR["TestType"].ToString(), "");
                                dt_wait.Rows.Add(dr);
                            }
                        }
                        //ref_zt = false;
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        //dataGrid_waitcar.Columns["登录时间"].Visible = false;
                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }
                    }
                    else
                    {
                        if (nhcode != 0)
                            MessageBox.Show(nhmsg);
                        if (nhexpcode != 0)
                            MessageBox.Show(nhexpmsg);
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                {
                    #region 金华
                    jhwaitlistOnthisLine.Clear();
                    jhcarinflistOnthisLine.Clear();
                    jhvehicleinflistOnthisLine.Clear();
                    string getreaulst = mainPanel.jhinterface.getInspReg(0, out jhwaitlist, out jhcarinflist, out jhvehicleinflist);
                    if (getreaulst != "获取成功")
                    {
                        MessageBox.Show(getreaulst);
                        return;
                    }
                    dt_wait.Rows.Clear();
                    DataRow dr = null;
                    for (int i = 0; i < jhwaitlist.Count; i++)
                    {
                        dr = dt_wait.NewRow();
                        dr["检测编号"] = jhwaitlist[i].CLID;
                        dr["车牌号"] = jhwaitlist[i].CLHP;
                        dr["登录时间"] = jhwaitlist[i].DLSJ.ToString("yyyy-MM-dd HH:mm:ss");
                        switch (jhwaitlist[i].JCFF)
                        {
                            case "ASM":
                                if (mainPanel.linemodel.ASM == "N") continue;
                                dr["检测方法"] = "稳态工况法";
                                break;
                            case "VMAS":
                                if (mainPanel.linemodel.VMAS == "N") continue;
                                dr["检测方法"] = "简易瞬态工况法";
                                break;
                            case "JZJS":
                                if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                dr["检测方法"] = "加载减速法";
                                break;
                            case "ZYJS":
                                if (mainPanel.linemodel.ZYJS == "N") continue;
                                dr["检测方法"] = "自由加速法";
                                break;
                            case "SDS":
                                if (mainPanel.linemodel.SDS == "N") continue;
                                dr["检测方法"] = "双怠速法";
                                break;
                            case "LZ":
                                if (mainPanel.linemodel.LZ == "N") continue;
                                dr["检测方法"] = "滤纸烟度法";
                                break;
                            default: dr["检测方法"] = "其他方法"; break;
                        }
                        jhcarinflist[i].CLLX = logininfcontrol.getComBoBoxItemsNAME("车辆类型", jhcarinflist[i].CLLX);
                        jhwaitlistOnthisLine.Add(jhwaitlist[i]);
                        jhcarinflistOnthisLine.Add(jhcarinflist[i]);
                        jhvehicleinflistOnthisLine.Add(jhvehicleinflist[i]);
                        dt_wait.Rows.Add(dr);
                    }
                    dataGrid_waitcar.DataSource = dt_wait;
                    dataGrid_waitcar.Columns["检测编号"].Visible = false;
                    dataGrid_waitcar.Columns["登录时间"].Visible = false;
                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    //dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    for (int i = 0; i < this.dataGrid_waitcar.Columns.Count; i++)
                    {

                        this.dataGrid_waitcar.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                    }
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
                {
                    #region 江苏
                    bool jsstatus;
                    string jserrMsg = "";
                    mainPanel.jsinterface.connectServer(out jsstatus, out jserrMsg);
                    if (!jsstatus)
                    {
                        MessageBox.Show("ConnetServer失败：" + jserrMsg, "连接联网服务器失败");
                        return;
                    }
                    mainPanel.jsinterface.loginServer(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, out jsstatus, out jserrMsg);
                    if (!jsstatus)
                    {
                        MessageBox.Show(jserrMsg, "登录失败");
                        ini.INIIO.saveLogInf("登录失败：" + jserrMsg);
                        return;
                    }
                    else
                    {
                        ini.INIIO.saveLogInf("登录成功");
                    }
                    string ackstring = mainPanel.jsinterface.getWaitlistInfo(out jswaitlist, out jsstatus, out jserrMsg);
                    if (ackstring != "")
                    {
                        MessageBox.Show(ackstring, "获取待检列表失败");
                        ini.INIIO.saveLogInf("获取待检列表失败：" + ackstring);
                        return;
                    }
                    else
                    {
                        if (!jsstatus)
                        {
                            MessageBox.Show(jserrMsg);
                            MessageBox.Show(jserrMsg, "获取待检列表失败");
                            ini.INIIO.saveLogInf("获取待检列表失败：" + jserrMsg);
                            return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("获取待检列表成功");
                        }
                    }


                    dt_wait.Rows.Clear();
                    DataRow dr = null;
                    for (int i = 0; i < jswaitlist.Count; i++)
                    {
                        dr = dt_wait.NewRow();
                        dr["检测编号"] = jswaitlist[i].CLID;
                        dr["车牌号"] = jswaitlist[i].CLHP;
                        dr["车牌颜色"] = jswaitlist[i].CPYS;
                        dt_wait.Rows.Add(dr);
                    }
                    dataGrid_waitcar.DataSource = dt_wait;
                    dataGrid_waitcar.Columns["检测编号"].Visible = false;
                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                {
                    #region 江西
                    string code, msg;
                    dt_wait.Rows.Clear();
                    if (mainPanel.jxinterface.fetchVehicles(out code, out msg, out jxcarlist))
                    {
                        DataRow dr = null;
                        if (jxcarlist.Count >= 0)
                        {
                            foreach (jxcarinf jxcarchild in jxcarlist)
                            {
                                dr = dt_wait.NewRow();
                                dr["检测编号"] = jxcarchild.detectionId;
                                dr["车牌号"] = jxcarchild.vehicleLicense;
                                switch (jxcarchild.vehicleLicenseType)
                                {
                                    case "1":
                                        dr["车牌颜色"] = "蓝牌"; break;
                                    case "2":
                                        dr["车牌颜色"] = "黄牌"; break;
                                    case "3":
                                        dr["车牌颜色"] = "白牌"; break;
                                    case "4":
                                        dr["车牌颜色"] = "黑牌"; break;
                                    default: break;
                                }
                                switch (jxcarchild.testType)
                                {
                                    case "2":
                                        if (mainPanel.linemodel.ASM == "N") continue;
                                        dr["检测方法"] = "稳态工况法";
                                        break;
                                    case "3":
                                        if (mainPanel.linemodel.VMAS == "N") continue;
                                        dr["检测方法"] = "简易瞬态工况法";
                                        break;
                                    case "4":
                                        if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                        dr["检测方法"] = "加载减速法";
                                        break;
                                    case "6":
                                        if (mainPanel.linemodel.ZYJS == "N") continue;
                                        dr["检测方法"] = "自由加速法";
                                        break;
                                    case "1":
                                        if (mainPanel.linemodel.SDS == "N") continue;
                                        dr["检测方法"] = "双怠速法";
                                        break;
                                    case "5":
                                        if (mainPanel.linemodel.LZ == "N") continue;
                                        dr["检测方法"] = "滤纸烟度法";
                                        break;
                                    default: break;
                                }
                                dt_wait.Rows.Add(dr);
                            }
                        }
                        //ref_zt = false;
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        for (int i = 0; i < this.dataGrid_waitcar.Columns.Count; i++)
                        {

                            this.dataGrid_waitcar.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                        }
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }


                    }
                    else
                    {
                        MessageBox.Show("fetchVehicle失败，code:" + code + "\r\nmessage:" + msg);
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.XBNETMODE)
                {
                    #region 喜邦
                    string code, msg;
                    dt_wait.Rows.Clear();
                    List<carinfo.XB_CARLIST> xbcarlist = new List<carinfo.XB_CARLIST>();
                    if (mainPanel.xbsocket.Send_GET_REG_CAR_LIST(1000, out xbcarlist, out code, out msg))
                    {
                        DataRow dr = null;
                        if (jxcarlist.Count >= 0)
                        {
                            foreach (carinfo.XB_CARLIST carchild in xbcarlist)
                            {
                                dr = dt_wait.NewRow();
                                dr["检测编号"] = carchild.JCLSH+"_"+carchild.JCCS;
                                dr["车牌号"] = carchild.HPHM;
                                dr["号牌种类"] = carchild.HPZL;
                                dr["检测方法"] = carchild.JCFF;
                                dt_wait.Rows.Add(dr);
                            }
                        }
                        //ref_zt = false;
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        for (int i = 0; i < this.dataGrid_waitcar.Columns.Count; i++)
                        {

                            this.dataGrid_waitcar.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                        }
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }


                    }
                    else
                    {
                        MessageBox.Show("获取待检列表失败，code:" + code + "\r\nmessage:" + msg);
                    }
                    #endregion
                }
                else if (mainPanel.useHyDatabase)
                {
                    #region 华燕数据库
                    dt_wait.Rows.Clear();
                    DataTable dt = null;
                    if(hyDatabaseInter.readRegTeam(out dt))
                    {
                        DataRow dr = null;
                        if (dt != null)
                        {
                            foreach (DataRow dR in dt.Rows)
                            {
                                dr = dt_wait.NewRow();
                                dr["检测编号"] = dR["Reg_ID"].ToString();
                                dr["车牌号"] = dR["Reg_CPH"].ToString();
                                dr["登录时间"] = dR["Reg_Date"].ToString();
                                switch (mainPanel.acDicJcff.GetValue(dR["Reg_TestType"].ToString(), ""))
                                {
                                    case "ASM":
                                        if (mainPanel.linemodel.ASM == "N") continue;
                                        dr["检测方法"] = "稳态工况法";
                                        break;
                                    case "VMAS":
                                        if (mainPanel.linemodel.VMAS == "N") continue;
                                        dr["检测方法"] = "简易瞬态工况法";
                                        break;
                                    case "JZJS":
                                        if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                        dr["检测方法"] = "加载减速法";
                                        break;
                                    case "ZYJS":
                                        if (mainPanel.linemodel.ZYJS == "N") continue;
                                        dr["检测方法"] = "自由加速法";
                                        break;
                                    case "SDS":
                                        if (mainPanel.linemodel.SDS == "N") continue;
                                        dr["检测方法"] = "双怠速法";
                                        break;
                                    case "LZ":
                                        if (mainPanel.linemodel.LZ == "N") continue;
                                        dr["检测方法"] = "滤纸烟度法";
                                        break;
                                    default: break;
                                }
                                dt_wait.Rows.Add(dr);
                            }
                        }
                        //ref_zt = false;
                        dataGrid_waitcar.DataSource = dt_wait;
                        dataGrid_waitcar.Columns["检测编号"].Visible = false;
                        dataGrid_waitcar.Columns["登录时间"].Visible = false;

                        if (dataGrid_waitcar.Rows.Count > 0)
                            dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                        dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                        ref_zt = true;
                        if (dataGrid_waitcar.Rows.Count > 0)
                        {
                            dataGrid_waitcar.Rows[0].Selected = true;
                        }
                    }
                    #endregion
                }
                else if(mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.GUILINNETMODE))
                {
                    #region 桂林
                    string result, errmsg;
                    dt_wait.Rows.Clear();
                    DataTable dt = new DataTable();
                    Hashtable ht2 = new Hashtable();
                    string inspectionmethod = "";
                    if (radioButtonASM.Checked) inspectionmethod =mainPanel.gxinterface.GLR_inspectionmethod.GetValue("ASM","");
                    else if (radioButtonSDS.Checked) inspectionmethod = mainPanel.gxinterface.GLR_inspectionmethod.GetValue("SDS", "");
                    else if (radioButtonLUG.Checked) inspectionmethod = mainPanel.gxinterface.GLR_inspectionmethod.GetValue("JZJS", "");
                    else if (radioButtonZYJS.Checked) inspectionmethod = mainPanel.gxinterface.GLR_inspectionmethod.GetValue("ZYJS", "");
                    ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                    ht2.Add("stationcode", mainPanel.stationid);
                    ht2.Add("linecode", mainPanel.lineid);
                    ht2.Add("inspectionmethod", inspectionmethod);
                    ht2.Add("starttime", dateTimeInput1.Value.ToString("yyyy-MM-dd")+" 00:00:00");
                    ht2.Add("endtime", dateTimeInput2.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                    ht2.Add("factoryno", "");
                    if(!mainPanel.gxinterface.GetVehicleList(ht2, out dt, out result, out errmsg))
                    {
                        MessageBox.Show("获取待检车辆列表失败:" + errmsg);
                        return;
                    }
                    DataRow dr = null;
                    if (dt != null)
                    {
                        foreach (DataRow dR in dt.Rows)
                        {
                            dr = dt_wait.NewRow();
                            dr["检测编号"] = dR["inspectionnum"].ToString();
                            dr["车牌号"] = dR["vlpn"].ToString();
                            dr["检测类型"] = mainPanel.gxinterface.GL_inspectionnature.GetValue( dt.Rows[0]["inspectionnature"].ToString(),"");
                            dr["登录时间"] = dR["acceptancedate"].ToString();
                            dr["登录员"] = dR["operator"].ToString();
                            switch (mainPanel.gxinterface.GL_inspectionmethod.GetValue(dR["inspectionmethod"].ToString(),""))
                            {
                                case "ASM":
                                    if (mainPanel.linemodel.ASM == "N") continue;
                                    dr["检测方法"] = "稳态工况法";
                                    break;
                                case "VMAS":
                                    if (mainPanel.linemodel.VMAS == "N") continue;
                                    dr["检测方法"] = "简易瞬态工况法";
                                    break;
                                case "JZJS":
                                    if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                    dr["检测方法"] = "加载减速法";
                                    break;
                                case "ZYJS":
                                    if (mainPanel.linemodel.ZYJS == "N") continue;
                                    dr["检测方法"] = "自由加速法";
                                    break;
                                case "SDS":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法";
                                    break;
                                case "LZ":
                                    if (mainPanel.linemodel.LZ == "N") continue;
                                    dr["检测方法"] = "滤纸烟度法";
                                    break;
                                default: break;
                            }
                            dr["检测方法代号"] = dR["inspectionmethod"].ToString();
                            dt_wait.Rows.Add(dr);
                        }
                    }
                    //ref_zt = false;
                    dataGrid_waitcar.DataSource = dt_wait;
                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.PNNETMODE))
                {
                    #region 平南(获取待检车辆列表)
                    string errmsg;
                    dt_wait.Rows.Clear();
                    DataTable dt = new DataTable();
                    string inspectionmethod = "";
                    if (radioButtonASM.Checked)
                        inspectionmethod = mainPanel.pninterface.PNR_inspectionmethod.GetValue("ASM", "");
                    else if(radioButtonSDS.Checked)
                        inspectionmethod = mainPanel.pninterface.PNR_inspectionmethod.GetValue("SDS", "");
                    else if(radioButtonLUG.Checked)
                        inspectionmethod = mainPanel.pninterface.PNR_inspectionmethod.GetValue("JZJS", "");
                    else if(radioButtonZYJS.Checked)
                        inspectionmethod = mainPanel.pninterface.PNR_inspectionmethod.GetValue("ZYJS", "");

                    //if (!mainPanel.pninterface.GetVehicleListByTime(DateTime.Parse(dateTimeInput1.Value.ToString("yyyy-MM-dd") + " 00:00:00"), DateTime.Parse(dateTimeInput2.Value.ToString("yyyy-MM-dd") + " 23:59:59"), inspectionmethod, out dt, out errmsg))
                    if (!mainPanel.pninterface.GetVehicleList(inspectionmethod, out dt, out errmsg))
                    {
                        MessageBox.Show("获取待检车辆列表失败:" + errmsg);
                        return;
                    }
                    if (dt != null)
                    {
                        DataRow dr = null;
                        foreach (DataRow dR in dt.Rows)
                        {
                            dr = dt_wait.NewRow();
                            dr["检测编号"] = dR["InspectionNum"].ToString();
                            dr["车牌号"] = dR["VLPN"].ToString();
                            dr["检测类型"] = mainPanel.pninterface.PN_inspectionnature.GetValue(dt.Rows[0]["InspectionNature"].ToString(), "");
                            dr["登录时间"] = dR["AcceptanceDate"].ToString();
                            dr["登录员"] = dR["Operator"].ToString();
                            switch (mainPanel.pninterface.PN_inspectionmethod.GetValue(dR["InspectionMethod"].ToString(), ""))
                            {
                                case "ASM":
                                    if (mainPanel.linemodel.ASM == "N") continue;
                                    dr["检测方法"] = "稳态工况法";
                                    break;
                                case "VMAS":
                                    if (mainPanel.linemodel.VMAS == "N") continue;
                                    dr["检测方法"] = "简易瞬态工况法";
                                    break;
                                case "JZJS":
                                    if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                    dr["检测方法"] = "加载减速法";
                                    break;
                                case "ZYJS":
                                    if (mainPanel.linemodel.ZYJS == "N") continue;
                                    dr["检测方法"] = "自由加速法";
                                    break;
                                case "SDS":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法";
                                    break;
                                case "LZ":
                                    if (mainPanel.linemodel.LZ == "N") continue;
                                    dr["检测方法"] = "滤纸烟度法";
                                    break;
                                default: break;
                            }
                            dr["检测方法代号"] = dR["InspectionMethod"].ToString();
                            dt_wait.Rows.Add(dr);
                        }
                    }
                    //ref_zt = false;
                    dataGrid_waitcar.DataSource = dt_wait;
                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
                else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                {
                    #region 通用联网
                    dt_wait.Rows.Clear();
                    DataTable dt = null;
                    dt = logininfcontrol.getAllCarAtWait("Y");
                    DataRow dr = null;
                    if (dt != null)
                    {
                        foreach (DataRow dR in dt.Rows)
                        {
                            dr = dt_wait.NewRow();
                            dr["检测编号"] = dR["JYLSH"].ToString();
                            dr["车牌号"] = dR["CLHP"].ToString();
                            dr["登录时间"] = dR["DLSJ"].ToString();
                            switch (dR["JCFF"].ToString())
                            {
                                case "ASM":
                                    if (mainPanel.linemodel.ASM == "N") continue;
                                    dr["检测方法"] = "稳态工况法";
                                    break;
                                case "VMAS":
                                    if (mainPanel.linemodel.VMAS == "N") continue;
                                    dr["检测方法"] = "简易瞬态工况法";
                                    break;
                                case "JZJS":
                                    if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                    dr["检测方法"] = "加载减速法";
                                    break;
                                case "ZYJS":
                                    if (mainPanel.linemodel.ZYJS == "N") continue;
                                    dr["检测方法"] = "自由加速法";
                                    break;
                                case "SDS":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法";
                                    break;
                                case "SDSM":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法(摩)";
                                    break;
                                case "LZ":
                                    if (mainPanel.linemodel.LZ == "N") continue;
                                    dr["检测方法"] = "滤纸烟度法";
                                    break;
                                default: break;
                            }
                            dt_wait.Rows.Add(dr);
                        }
                    }
                    //ref_zt = false;
                    dataGrid_waitcar.DataSource = dt_wait;
                    //dataGrid_waitcar.Columns["检测编号"].Visible = true;
                    dataGrid_waitcar.Columns["登录时间"].Visible = false;

                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
                else
                {
                    #region 从本地数据库获取待检列表
                    dt_wait.Rows.Clear();
                    DataTable dt = null;
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.CCNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ORTNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.CYNETMODE)
                    {
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                    {
                        dt = logininfcontrol.getAllCarAtWait("Y");
                    }
                    else
                    {
                        dt = logininfcontrol.getAllCarAtWait("N");
                    }
                    DataRow dr = null;
                    if (dt != null)
                    {
                        foreach (DataRow dR in dt.Rows)
                        {
                            dr = dt_wait.NewRow();
                            dr["检测编号"] = dR["CLID"].ToString();
                            dr["车牌号"] = dR["CLHP"].ToString();
                            dr["登录时间"] = dR["DLSJ"].ToString();
                            switch (dR["JCFF"].ToString())
                            {
                                case "ASM":
                                    if (mainPanel.linemodel.ASM == "N") continue;
                                    dr["检测方法"] = "稳态工况法";
                                    break;
                                case "VMAS":
                                    if (mainPanel.linemodel.VMAS == "N") continue;
                                    dr["检测方法"] = "简易瞬态工况法";
                                    break;
                                case "JZJS":
                                    if (mainPanel.linemodel.JZJS_HEAVY == "N" && mainPanel.linemodel.JZJS_LIGHT == "N") continue;
                                    dr["检测方法"] = "加载减速法";
                                    break;
                                case "ZYJS":
                                    if (mainPanel.linemodel.ZYJS == "N") continue;
                                    dr["检测方法"] = "自由加速法";
                                    break;
                                case "SDS":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法";
                                    break;
                                case "SDSM":
                                    if (mainPanel.linemodel.SDS == "N") continue;
                                    dr["检测方法"] = "双怠速法(摩)";
                                    break;
                                case "LZ":
                                    if (mainPanel.linemodel.LZ == "N") continue;
                                    dr["检测方法"] = "滤纸烟度法";
                                    break;
                                default: break;
                            }
                            dt_wait.Rows.Add(dr);
                        }
                    }
                    //ref_zt = false;
                    dataGrid_waitcar.DataSource = dt_wait;
                    dataGrid_waitcar.Columns["检测编号"].Visible = false;
                    dataGrid_waitcar.Columns["登录时间"].Visible = false;

                    if (dataGrid_waitcar.Rows.Count > 0)
                        dataGrid_waitcar.FirstDisplayedScrollingRowIndex = Carwait_Scroll;
                    dataGrid_waitcar.Sort(dataGrid_waitcar.Columns["检测编号"], ListSortDirection.Ascending);
                    ref_zt = true;
                    if (dataGrid_waitcar.Rows.Count > 0)
                    {
                        dataGrid_waitcar.Rows[0].Selected = true;
                    }
                    #endregion
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            logininfcontrol.deleteCarAtWaitbyPlate(carbj.CLHP);
            ref_WaitCar();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ref_WaitCar();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (ref_zt)
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
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NEUSOFTNETMODE)
                        {
                            #region neusoft
                            DataSet vehicledataset = null;
                            string result, inf;
                            int checktimes = 0;
                            CK:
                            checktimes++;
                            string cpys="";
                            if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                            {
                                mainPanel.sysocket.loginUser(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", out result, out inf);
                                //string cpys = "";
                                switch (dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString())
                                {
                                    case "蓝牌": cpys = "0"; break;
                                    case "黄牌": cpys = "1"; break;
                                    case "黑牌": cpys = "2"; break;
                                    case "白牌": cpys = "3"; break;
                                    case "小黄牌": cpys = "4"; break;
                                    default: break;
                                }
                                if (!mainPanel.sysocket.VehicleRequest(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString(), cpys, "", out result, out inf, out outLookID, out vehicledataset))
                                {
                                    MessageBox.Show("异常:" + result + "|信息:" + inf, "错误");
                                    return;
                                }
                            }
                            else
                            {
                                mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                //string cpys = "";
                                switch (dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString())
                                {
                                    case "蓝牌": cpys = "0"; break;
                                    case "黄牌": cpys = "1"; break;
                                    case "黑牌": cpys = "2"; break;
                                    case "白牌": cpys = "3"; break;
                                    case "小黄牌": cpys = "4"; break;
                                    default: break;
                                }
                                vehicledataset = mainPanel.neusoftsocket.VehicleRequest(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString(), cpys, "", out result, out inf, out outLookID);
                            }
                            if (vehicledataset != null)
                            {
                                DataTable dtinf = vehicledataset.Tables["Vehicle"];
                                DataTable limitinf = vehicledataset.Tables["LimitValue"];
                                if (dtinf != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = outLookID;//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = dtinf.Rows[0]["License"].ToString();
                                    carbj.CPYS = dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString();
                                    carbj.HPZL = "";
                                    carbj.XSLC = dtinf.Rows[0]["Odometer"].ToString();
                                    string cjcpys = carbj.CPYS;
                                    string cjclph = carbj.CLHP;
                                    CARDETECTED latestRecord = logininfcontrol.getPreTestDatebyPlate(cjclph, cjcpys);
                                    if (latestRecord.CLID == "-2")//如果没有记录，则提示为初检
                                    {
                                        carbj.JCCS = "1";
                                    }
                                    else//如果有环保记录，则判定记录内容
                                    {
                                        int latestMonths = caculateMonth(latestRecord.JCSJ, DateTime.Now);//计算最近的检测记录距离此次的时间
                                        if (latestMonths > 9)//如果距离超过9个月，则认为达到检测时间
                                        {
                                            carbj.JCCS = "1";
                                            carbj.SFCJ = "初检";
                                        }
                                        else
                                        {
                                            int lastrecordjccs = 0;
                                            if (!int.TryParse(latestRecord.JCCS, out lastrecordjccs))
                                                lastrecordjccs = 0;
                                            int jccs = lastrecordjccs + 1;
                                            carbj.JCCS = jccs.ToString();
                                            carbj.SFCJ = "复检";
                                        }
                                    }
                                    carbj.JCCS = carbj.JCCS;
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = "";
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = "";
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = "";
                                    carbj.JYLSH = "";
                                    //carbj.SFCJ = "";
                                    //CARINF model = new CARINF();
                                    modelbj.CLHP = dtinf.Rows[0]["License"].ToString();//1
                                    DateTime.TryParse(dtinf.Rows[0]["RegisterDate"].ToString(), out a);
                                    if (a != null)
                                        modelbj.ZCRQ = a;
                                    else
                                        modelbj.ZCRQ = DateTime.Today;
                                    modelbj.CLSBM = dtinf.Rows[0]["Vin"].ToString();

                                    modelbj.CPYS = dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString();
                                    modelbj.HPZL = "";
                                    if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)
                                    {
                                        switch (dtinf.Rows[0]["VehicleType"].ToString())
                                        {
                                            case "K1": modelbj.CLLX = "大型客车"; break;
                                            case "K2": modelbj.CLLX = "中型客车"; break;
                                            case "K3": modelbj.CLLX = "小型客车"; break;
                                            case "K4": modelbj.CLLX = "微型客车"; break;
                                            case "H1": modelbj.CLLX = "重型货车"; break;
                                            case "H2": modelbj.CLLX = "中型货车"; break;
                                            case "H3": modelbj.CLLX = "轻型货车"; break;
                                            case "H4": modelbj.CLLX = "微型货车"; break;
                                            case "H5": modelbj.CLLX = "低速货车"; break;
                                            case "M1": modelbj.CLLX = "三轮摩托车"; break;
                                            case "M2": modelbj.CLLX = "二轮摩托车"; break;
                                            case "N1": modelbj.CLLX = "三轮汽车"; break;
                                            default:modelbj.CLLX = "";break;
                                        }
                                    }
                                    else
                                    {
                                        switch (dtinf.Rows[0]["VehicleType"].ToString())
                                        {
                                            case "0": modelbj.CLLX = "6座以下小型客车"; break;
                                            case "1": modelbj.CLLX = "6座以上小型客车"; break;
                                            case "2": modelbj.CLLX = "大型客车"; break;
                                            case "3": modelbj.CLLX = "小型货车"; break;
                                            case "4": modelbj.CLLX = "大型货车"; break;
                                            case "5": modelbj.CLLX = "三轮汽车和低速汽车"; break;
                                            case "6": modelbj.CLLX = "摩托车"; break;
                                            case "7": modelbj.CLLX = "三轮摩托车"; break;
                                            default: modelbj.CLLX = ""; break;
                                        }
                                    }
                                    modelbj.CZ = dtinf.Rows[0]["Owner"].ToString();
                                    switch (dtinf.Rows[0]["CarOrTruck"].ToString())
                                    {
                                        case "0": modelbj.SYXZ = "客车"; break;
                                        case "1": modelbj.SYXZ = "货车"; break;
                                    }
                                    modelbj.PP = dtinf.Rows[0]["Model"].ToString();//5
                                    modelbj.XH = dtinf.Rows[0]["Model"].ToString();
                                    modelbj.FDJHM = "";
                                    modelbj.FDJXH = "";
                                    modelbj.SCQY = "";//10
                                    modelbj.HDZK = dtinf.Rows[0]["MaxLoad"].ToString();
                                    modelbj.JSSZK = "";
                                    modelbj.ZZL = dtinf.Rows[0]["MaxMass"].ToString();
                                    modelbj.HDZZL = "";
                                    modelbj.ZBZL = "";//15
                                    modelbj.JZZL = dtinf.Rows[0]["RefMass"].ToString();

                                    DateTime.TryParse(dtinf.Rows[0]["RegisterDate"].ToString(), out b);
                                    if (a != null)
                                        modelbj.SCRQ = b;
                                    else
                                        modelbj.SCRQ = DateTime.Today;
                                    modelbj.FDJPL = dtinf.Rows[0]["Volume"].ToString();
                                    switch (dtinf.Rows[0]["FuelType"].ToString())
                                    {
                                        case "0": modelbj.RLZL = "汽油"; break;
                                        case "1": modelbj.RLZL = "柴油"; break;
                                        case "2": modelbj.RLZL = "LPG"; break;
                                        case "3": modelbj.RLZL = "CNG"; break;
                                        case "4": modelbj.RLZL = "双燃料"; break;
                                        case "5": modelbj.RLZL = "乙醇"; break;
                                        case "6": modelbj.RLZL = "其他"; break;
                                    }
                                    modelbj.EDGL = dtinf.Rows[0]["RatedPower"].ToString();
                                    modelbj.EDZS = dtinf.Rows[0]["RatedRev"].ToString();
                                    modelbj.BSQXS = dtinf.Rows[0]["GearBoxType"].ToString();
                                    modelbj.DWS = "";
                                    modelbj.GYFS = "";//25
                                    switch (dtinf.Rows[0]["SupplyMode"].ToString())
                                    {
                                        case "0": modelbj.DPFS = "化油器"; break;
                                        case "1": modelbj.DPFS = "开环电喷"; break;
                                        case "2": modelbj.DPFS = "闭环电喷"; break;
                                        case "3": modelbj.DPFS = "直喷"; break;
                                    }
                                    modelbj.JQFS = dtinf.Rows[0]["AdmissionMode"].ToString();
                                    modelbj.QGS = dtinf.Rows[0]["Cylinder"].ToString();
                                    switch (dtinf.Rows[0]["DriveMode"].ToString())
                                    {
                                        case "0": modelbj.QDXS = "前驱"; break;
                                        case "1": modelbj.QDXS = "后驱"; break;
                                        case "2": modelbj.QDXS = "四驱"; break;
                                        case "3": modelbj.QDXS = "全时四驱"; break;
                                    }
                                    modelbj.CHZZ = "";//30
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = "";
                                    if (dtinf.Rows[0]["HasPurge"].ToString() == "1" && dtinf.Rows[0]["SupplyMode"].ToString() == "2")//有三元催化且闭环电喷
                                    {
                                        modelbj.JHZZ = "有";
                                    }
                                    else
                                    {
                                        modelbj.JHZZ = "无";
                                    }
                                    modelbj.OBD = "";
                                    switch (dtinf.Rows[0]["IsEFI"].ToString())
                                    {
                                        case "0": modelbj.DKGYYB = "否"; break;
                                        case "1": modelbj.DKGYYB = "有"; break;
                                    }
                                    modelbj.LXDH = dtinf.Rows[0]["Phone"].ToString();
                                    modelbj.CZDZ = dtinf.Rows[0]["Address"].ToString();
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";
                                    modelbj.CLZL = "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY = "";
                                    modelbj.RYPH = "";
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)//福建省平台指令检测方法
                                    {
                                        switch (dataGrid_waitcar.SelectedRows[0].Cells["检测方法"].Value.ToString())
                                        {
                                            case "稳态工况": carbj.JCFF = "ASM"; break;
                                            case "双怠速": carbj.JCFF = "SDS"; break;
                                            case "简易瞬态": carbj.JCFF = "VMAS"; break;
                                            case "加载减速": carbj.JCFF = "JZJS"; break;
                                            case "滤纸": carbj.JCFF = "LZ"; break;
                                            case "自由加速": carbj.JCFF = "ZYJS"; break;
                                            default: carbj.JCFF = ""; break;
                                        }

                                    }
                                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_FJS || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_SDRZ)//福建省和山东日照平台指令检测方法
                                    {
                                        //补充说明：设备商要根据服务器返回的检测方法要求进行检测（YellowToGreen的值）, 在正式检测之前一定要给检测人员确认提示"该车用XXX检测方法检测",操作人员可以取消本次检测.但是检测人员不能选择用哪种检测方法检测。

                                        switch (dtinf.Rows[0]["YellowToGreen"].ToString())
                                        {
                                            case "0":
                                                carbj.JCFF = judgeTestMethod(modelbj);
                                                break;
                                            case "1": carbj.JCFF = "VMAS"; break;
                                            case "2": carbj.JCFF = "SDS"; break;
                                            case "3": carbj.JCFF = "JZJS"; break;
                                            case "4": carbj.JCFF = "ZYJS"; break;
                                            case "5": carbj.JCFF = "LZ"; break;
                                            case "6": carbj.JCFF = "ASM"; break;
                                        }
                                    }
                                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301|| mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V202)//福建省和山东日照平台指令检测方法
                                    {
                                        //补充说明：设备商要根据服务器返回的检测方法要求进行检测（YellowToGreen的值）, 在正式检测之前一定要给检测人员确认提示"该车用XXX检测方法检测",操作人员可以取消本次检测.但是检测人员不能选择用哪种检测方法检测。

                                        switch (dtinf.Rows[0]["YellowToGreen"].ToString())
                                        {
                                            case "":
                                                carbj.JCFF = judgeTestMethod(modelbj);
                                                break;
                                            case "0":
                                                carbj.JCFF = judgeTestMethod(modelbj);
                                                break;
                                            case "C": carbj.JCFF = "VMAS"; break;
                                            case "A": carbj.JCFF = "SDS"; break;
                                            case "G": carbj.JCFF = "JZJS"; break;
                                            case "F": carbj.JCFF = "ZYJS"; break;
                                            case "E": carbj.JCFF = "LZ"; break;
                                            case "B": carbj.JCFF = "ASM"; break;
                                        }
                                    }
                                    else//其他地区需要自己判定方法
                                    {
                                        carbj.JCFF = judgeTestMethod(modelbj);
                                    }

                                    limitdatainf.IsUsed = limitinf.Rows[0]["IsUsed"].ToString();
                                    /*
                                    limitdatainf.AmbientCOUp = limitinf.Rows[0]["AmbientCOUp"].ToString();
                                    limitdatainf.AmbientCO2Up = limitinf.Rows[0]["AmbientCO2Up"].ToString();
                                    limitdatainf.AmbientHCUp = limitinf.Rows[0]["AmbientHCUp"].ToString();
                                    limitdatainf.AmbientNOUp = limitinf.Rows[0]["AmbientNOUp"].ToString();
                                    limitdatainf.BackgroundCOUp = limitinf.Rows[0]["BackgroundCOUp"].ToString();
                                    limitdatainf.BackgroundCO2Up = limitinf.Rows[0]["BackgroundCO2Up"].ToString();
                                    limitdatainf.BackgroundHCUp = limitinf.Rows[0]["BackgroundHCUp"].ToString();
                                    limitdatainf.BackgroundNOUp = limitinf.Rows[0]["BackgroundNOUp"].ToString();
                                    limitdatainf.ResidualHCUp = limitinf.Rows[0]["ResidualHCUp"].ToString();*/
                                    if (dtinf.Rows[0]["FuelType"].ToString() != "1")
                                    {
                                        if (!limitinf.Columns.Contains("COAndCO2") && checktimes <= 3)
                                        {
                                            goto CK;
                                        }
                                        limitdatainf.COAndCO2 = limitinf.Rows[0]["COAndCO2"].ToString();
                                        limitdatainf.CO5025 = limitinf.Rows[0]["CO5025"].ToString();
                                        limitdatainf.HC5025 = limitinf.Rows[0]["HC5025"].ToString();
                                        limitdatainf.NO5025 = limitinf.Rows[0]["NO5025"].ToString();
                                        limitdatainf.CO2540 = limitinf.Rows[0]["CO2540"].ToString();
                                        limitdatainf.HC2540 = limitinf.Rows[0]["HC2540"].ToString();
                                        limitdatainf.NO2540 = limitinf.Rows[0]["NO2540"].ToString();
                                        limitdatainf.VmasCO = limitinf.Rows[0]["VmasCO"].ToString();
                                        limitdatainf.VmasHC = limitinf.Rows[0]["VmasHC"].ToString();
                                        limitdatainf.VmasNOx = limitinf.Rows[0]["VmasNOx"].ToString();
                                        if (limitinf.Columns.Contains("VmasHCNOx"))
                                        {
                                            limitdatainf.VmasHCNOx = limitinf.Rows[0]["VmasHCNOx"].ToString();
                                            if (limitdatainf.VmasHCNOx == "0")
                                                limitdatainf.VmasHCNOx = "";
                                        }
                                        else
                                        {
                                            limitdatainf.VmasHCNOx = "";
                                        }
                                        limitdatainf.HighIdleCO = limitinf.Rows[0]["HighIdleCO"].ToString();
                                        limitdatainf.HighIdleHC = limitinf.Rows[0]["HighIdleHC"].ToString();
                                        limitdatainf.LowIdleHC = limitinf.Rows[0]["LowIdleHC"].ToString();
                                        limitdatainf.LowIdleCO = limitinf.Rows[0]["LowIdleCO"].ToString();
                                    }
                                    else
                                    {
                                        if (!limitinf.Columns.Contains("SmokeK") && checktimes <= 3)
                                        {
                                            goto CK;
                                        }
                                        limitdatainf.SmokeK = limitinf.Rows[0]["SmokeK"].ToString();
                                        limitdatainf.SmokeHSU = limitinf.Rows[0]["SmokeHSU"].ToString();
                                        limitdatainf.DieselRevUp = limitinf.Rows[0]["DieselRevUp"].ToString();
                                        limitdatainf.DieselRevBelow = limitinf.Rows[0]["DieselRevBelow"].ToString();

                                        limitdatainf.MaxPower = limitinf.Rows[0]["MaxPower"].ToString();
                                        limitdatainf.FASmokeK = limitinf.Rows[0]["FASmokeK"].ToString();
                                        limitdatainf.FARev = limitinf.Rows[0]["FARev"].ToString();
                                        if (limitinf.Columns.Contains("SmokeRb"))
                                            limitdatainf.SmokeRb = limitinf.Rows[0]["SmokeRb"].ToString();
                                        else
                                            limitdatainf.SmokeRb = "";
                                    }
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;
                                }
                                else
                                {
                                    labelCLPH.Text = dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString();

                                    MessageBox.Show("代码:" + result + "|信息:" + inf, "报检失败");
                                    return;
                                }
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                        {
                            #region nh
                            int nhcode, nhexpcode;
                            string nhmsg, nhexpmsg;
                            string platenumber = dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString();
                            string platetype = dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString();
                            string vin = "";
                            CARATWAIT carwait = logininfcontrol.getCarInfatWaitList(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString());
                            vehicleinfo = mainPanel.nhinterface.GetVehicleInfo(platenumber, platetype, vin, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);

                            if (nhcode == 0 && nhexpcode == 0)
                            {
                                if (vehicleinfo != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = vehicleinfo.TestRunningNumber;//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = vehicleinfo.PlateNumber;
                                    carbj.CPYS = vehicleinfo.PlateType;
                                    carbj.HPZL = vehicleinfo.PlateType;
                                    carbj.XSLC = vehicleinfo.TravelledDistance;
                                    if (carwait.CLID != "-2")
                                    {
                                        carbj.JCCS = carwait.JCCS;
                                    }
                                    else
                                    {
                                        carbj.JCCS = "";
                                    }
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = carwait.DLY;
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString();
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = carwait.BGJCFFYY;
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = "";
                                    carbj.JYLSH = dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString();
                                    //CARINF model = new CARINF();
                                    modelbj.CLHP = vehicleinfo.PlateNumber;
                                    modelbj.ZCRQ = vehicleinfo.RegistrationDate;
                                    modelbj.CLSBM = vehicleinfo.VIN;

                                    modelbj.CPYS = vehicleinfo.PlateType;
                                    modelbj.HPZL = vehicleinfo.PlateType;
                                    modelbj.CLLX = vehicleinfo.VehicleType;

                                    modelbj.CZ = vehicleinfo.Owner;
                                    modelbj.SYXZ = vehicleinfo.UseCharacter;
                                    modelbj.PP = vehicleinfo.Brand;//5
                                    modelbj.XH = vehicleinfo.Model;
                                    modelbj.FDJHM = vehicleinfo.EngineNumber;
                                    modelbj.FDJXH = vehicleinfo.EngineModel;
                                    modelbj.SCQY = vehicleinfo.Manufacturer;//10
                                    modelbj.HDZK = vehicleinfo.RatedPassengerCapacity;
                                    modelbj.JSSZK = "";
                                    modelbj.ZZL = vehicleinfo.MaximumTotalMass;
                                    modelbj.HDZZL = vehicleinfo.RatedLoadingMass;
                                    modelbj.ZBZL = vehicleinfo.UnladenMass;//15
                                    modelbj.JZZL = (int.Parse(modelbj.ZBZL) + 100).ToString();

                                    modelbj.SCRQ = vehicleinfo.ProductionDate;
                                    modelbj.FDJPL = vehicleinfo.Displacement;
                                    modelbj.RLZL = vehicleinfo.FuelType;
                                    modelbj.EDGL = vehicleinfo.RatedPower;
                                    modelbj.EDZS = vehicleinfo.RatedRev;
                                    modelbj.BSQXS = vehicleinfo.GearBoxType;
                                    modelbj.DWS = vehicleinfo.GearNumber;
                                    modelbj.GYFS = vehicleinfo.OilSupplyMode;
                                    modelbj.DPFS = vehicleinfo.OilSupplyMode;
                                    modelbj.JQFS = vehicleinfo.AirIntakeMode;
                                    modelbj.QGS = vehicleinfo.CylinderNumber;
                                    modelbj.QDXS = vehicleinfo.DriverType;
                                    modelbj.CHZZ = vehicleinfo.TCS;
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = vehicleinfo.FuelMark;
                                    modelbj.JHZZ = (vehicleinfo.HasCatalyticConverter == "0" ? "否" : "是");

                                    modelbj.OBD = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.LXDH = vehicleinfo.Phone;
                                    modelbj.CZDZ = vehicleinfo.Address;
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";
                                    modelbj.CLZL = "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = vehicleinfo.EngineManufacturer;
                                    modelbj.QDLTQY = vehicleinfo.TyrePressure;
                                    modelbj.RYPH = vehicleinfo.FuelMark;
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    switch (dataGrid_waitcar.SelectedRows[0].Cells["检测方法"].Value.ToString())
                                    {
                                        case "稳态工况": carbj.JCFF = "ASM"; break;
                                        case "简易瞬态": carbj.JCFF = "VMAS"; break;
                                        case "加载减速": carbj.JCFF = "JZJS"; break;
                                        case "双怠速": carbj.JCFF = "SDS"; break;
                                        case "自由加速": carbj.JCFF = "ZYJS"; break;
                                        case "滤纸": carbj.JCFF = "LZ"; break;
                                        case "其他": carbj.JCFF = ""; break;
                                        default: carbj.JCFF = ""; break;
                                    }
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;

                                }
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.XBNETMODE)
                        {
                            #region 喜邦
                            string code, msg;
                            string tmbh = dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString();
                            //CARATWAIT carwait = logininfcontrol.getCarInfatWaitList(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString());
                            //vehicleinfo = mainPanel.nhinterface.GetVehicleInfo(platenumber, platetype, vin, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);

                            if (mainPanel.xbsocket.Send_QUERY_CAR_INFO(tmbh,out xbcarinfo,out xbsdsxz,out xbvmasxz,out xblugdownxz,out xbbtgxz,out xblzxz,out xbsdsmxz,out code,out msg ))
                            {
                                if (vehicleinfo != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = tmbh;//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = xbcarinfo.HPHM;
                                    carbj.CPYS = xbcarinfo.HPZL;
                                    carbj.HPZL = xbcarinfo.HPZL;
                                    carbj.XSLC = "";
                                    carbj.JCCS = xbcarinfo.JCCS;
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = mainPanel.nowUser.userName;
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH =xbcarinfo.JCLSH;
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = "";
                                    carbj.JYLSH = xbcarinfo.JCLSH;
                                    //CARINF model = new CARINF();
                                    modelbj.CLHP = xbcarinfo.HPHM;
                                    modelbj.ZCRQ =DateTime.Parse( xbcarinfo.DJDate);
                                    modelbj.CLSBM = xbcarinfo.Vin;

                                    modelbj.CPYS = xbcarinfo.HPZL;
                                    modelbj.HPZL = xbcarinfo.HPZL;
                                    modelbj.CLLX = xbcarinfo.CLLX;

                                    modelbj.CZ = xbcarinfo.DW;
                                    modelbj.SYXZ = "";
                                    modelbj.PP = xbcarinfo.ChangPH;//5
                                    modelbj.XH = xbcarinfo.XingHao;
                                    modelbj.FDJHM = "";
                                    modelbj.FDJXH = xbcarinfo.FDJXH;
                                    modelbj.SCQY = xbcarinfo.MakeFac;
                                    modelbj.HDZK = xbcarinfo.ZKRS;
                                    modelbj.JSSZK = "";
                                    modelbj.ZZL = xbcarinfo.ZZL;
                                    modelbj.HDZZL = "";
                                    modelbj.ZBZL = xbcarinfo.ZBZL;//15
                                    modelbj.JZZL = (int.Parse(modelbj.ZBZL) + 100).ToString();

                                    modelbj.SCRQ = DateTime.Parse(xbcarinfo.MakeDate);
                                    modelbj.FDJPL = xbcarinfo.PL;
                                    modelbj.RLZL = xbcarinfo.RLStr;
                                    modelbj.EDGL = xbcarinfo.EDGL;
                                    modelbj.EDZS = xbcarinfo.EDGLRPM;
                                    modelbj.BSQXS = xbcarinfo.BSXLX;
                                    modelbj.DWS = "";
                                    modelbj.GYFS = xbcarinfo.GYTypeStr;
                                    modelbj.DPFS = "";
                                    modelbj.JQFS = xbcarinfo.ZYTypeStr;
                                    modelbj.QGS = xbcarinfo.QGS;
                                    modelbj.QDXS = xbcarinfo.QDXS;
                                    modelbj.CHZZ = "";
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL ="";
                                    modelbj.JHZZ = (xbcarinfo.CH == "0" ? "无" : "有");

                                    modelbj.OBD = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.LXDH = xbcarinfo.DWTelephone;
                                    modelbj.CZDZ = xbcarinfo.DWAddres;
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";
                                    modelbj.CLZL = "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY ="";
                                    modelbj.RYPH ="";
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    carbj.JCFF = xbcarinfo.JCFFBH;
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;

                                }
                            }
                            else
                            {
                                MessageBox.Show("获取车辆信息失败:" + msg);
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                        {
                            #region 江西
                            int seletedindex = dataGrid_waitcar.SelectedRows[0].Index;
                            if (seletedindex >= 0)
                            {
                                jxthiscarinf = jxcarlist[seletedindex];
                                if (vehicleinfo != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = jxthiscarinf.detectionId;//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = jxthiscarinf.vehicleLicense;
                                    carbj.CPYS = mainPanel.jxinterface.JX_VEHICLELICENSETYPE.GetValue(jxthiscarinf.vehicleLicenseType, "");
                                    carbj.HPZL = logininfcontrol.getComBoBoxItemsNAME("号牌种类", jxthiscarinf.vehicleLicenseTypeGa247);
                                    carbj.XSLC = jxthiscarinf.odometerNumber == null ? "" : jxthiscarinf.odometerNumber;
                                    if (carbj.CLID != "-2")
                                    {
                                        carbj.JCCS = jxthiscarinf.testTimes;
                                    }
                                    else
                                    {
                                        carbj.JCCS = "";
                                    }
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = jxthiscarinf.logonPerson == null ? "" : jxthiscarinf.logonPerson;
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = "";
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = "";
                                    carbj.JYLSH = "";
                                    //CARINF model = new CARINF();
                                    modelbj.CLHP = jxthiscarinf.vehicleLicense == null ? "" : jxthiscarinf.vehicleLicense;
                                    modelbj.ZCRQ = DateTime.Parse(jxthiscarinf.registerDate);
                                    modelbj.CLSBM = jxthiscarinf.vehicleVin == null ? "" : jxthiscarinf.vehicleVin;

                                    modelbj.CPYS = carbj.CPYS;
                                    modelbj.HPZL = carbj.HPZL;
                                    modelbj.CLLX = jxthiscarinf.vehicleType == null ? "" : jxthiscarinf.vehicleType;

                                    modelbj.CZ = jxthiscarinf.ownerName == null ? "" : jxthiscarinf.ownerName;
                                    modelbj.SYXZ = mainPanel.jxinterface.JX_USETYPE.GetValue(jxthiscarinf.useType == null ? "" : jxthiscarinf.useType, "");


                                    modelbj.PP = jxthiscarinf.vehicleModel == null ? "" : jxthiscarinf.vehicleModel;//5
                                    modelbj.XH = jxthiscarinf.vehicleModel == null ? "" : jxthiscarinf.vehicleModel;
                                    modelbj.FDJHM = jxthiscarinf.engineIdentification == null ? "" : jxthiscarinf.engineIdentification;
                                    modelbj.FDJXH = jxthiscarinf.engineModel == null ? "" : jxthiscarinf.engineModel;
                                    modelbj.SCQY = jxthiscarinf.vehicleManufacturer == null ? "" : jxthiscarinf.vehicleManufacturer;//10
                                    modelbj.HDZK = jxthiscarinf.passengersCount == null ? "" : jxthiscarinf.passengersCount;
                                    modelbj.JSSZK = "";
                                    modelbj.ZZL = jxthiscarinf.massMax == null ? "" : jxthiscarinf.massMax;
                                    modelbj.HDZZL = "";
                                    modelbj.JZZL = jxthiscarinf.massReference == null ? "" : jxthiscarinf.massReference;//15
                                    modelbj.ZBZL = (int.Parse(modelbj.JZZL) - 100).ToString();

                                    modelbj.SCRQ = DateTime.Parse(jxthiscarinf.manufacturingDate);
                                    modelbj.FDJPL = jxthiscarinf.engineDisplacement == null ? "" : jxthiscarinf.engineDisplacement;
                                    modelbj.RLZL = mainPanel.jxinterface.JX_FUELTYPE.GetValue(jxthiscarinf.fuelType == null ? "" : jxthiscarinf.fuelType, "");
                                    modelbj.EDGL = jxthiscarinf.engineRatedPower == null ? "" : jxthiscarinf.engineRatedPower;
                                    modelbj.EDZS = jxthiscarinf.engineRatedSpeed == null ? "" : jxthiscarinf.engineRatedSpeed;
                                    modelbj.BSQXS = mainPanel.jxinterface.JX_GEARTYPE.GetValue(jxthiscarinf.gearType == null ? "" : jxthiscarinf.gearType, "");
                                    modelbj.DWS = "";
                                    modelbj.GYFS = mainPanel.jxinterface.JX_FUELSUPPLY.GetValue(jxthiscarinf.fuelSupply == null ? "" : jxthiscarinf.fuelSupply, "");
                                    modelbj.DPFS = "";
                                    modelbj.JQFS = mainPanel.jxinterface.JX_AIRINTYPE.GetValue(jxthiscarinf.airInType == null ? "" : jxthiscarinf.airInType, "");
                                    modelbj.QGS = jxthiscarinf.cylindersNumber == null ? "" : jxthiscarinf.cylindersNumber;
                                    modelbj.QDXS = mainPanel.jxinterface.JX_DRIVEMODE.GetValue(jxthiscarinf.driveMode == null ? "" : jxthiscarinf.driveMode, "");
                                    modelbj.CHZZ = "无";
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = "否";
                                    modelbj.JHZZ = mainPanel.jxinterface.JX_FLAGHCL.GetValue(jxthiscarinf.flagHcl == null ? "" : jxthiscarinf.flagHcl, "");
                                    modelbj.OBD = mainPanel.jxinterface.JX_FLAGOBD.GetValue(jxthiscarinf.flagObd == null ? "" : jxthiscarinf.flagObd, ""); //(jxthiscarinf.flagObd == "N" ? "无" : "有");
                                    modelbj.DKGYYB = mainPanel.jxinterface.JX_FLAGDK.GetValue(jxthiscarinf.flagDk == null ? "" : jxthiscarinf.flagDk, "");// (jxthiscarinf.flagDk == "N" ? "无" : "有");
                                    modelbj.LXDH = jxthiscarinf.ownerTel == null ? "" : jxthiscarinf.ownerTel;
                                    modelbj.CZDZ = jxthiscarinf.ownerAddress == null ? "" : jxthiscarinf.ownerAddress;
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = mainPanel.jxinterface.JX_TESTCATEGORY.GetValue(jxthiscarinf.testCategory == null ? "" : jxthiscarinf.testCategory, "");// (jxthiscarinf.flagDk == "N" ? "无" : "有");

                                    modelbj.CLZL = "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY = "";

                                    modelbj.RYPH = jxthiscarinf.fuelSpec == null ? "" : jxthiscarinf.fuelSpec;
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    switch (jxthiscarinf.testType)
                                    {
                                        case "2":
                                            carbj.JCFF = "ASM";
                                            break;
                                        case "3":
                                            carbj.JCFF = "VMAS";
                                            break;
                                        case "4":
                                            carbj.JCFF = "JZJS";
                                            break;
                                        case "6":
                                            carbj.JCFF = "ZYJS";
                                            break;
                                        case "1":
                                            carbj.JCFF = "SDS";
                                            break;
                                        case "5":
                                            carbj.JCFF = "LZ";
                                            break;
                                        default: break;
                                    }
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;

                                }
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                        {
                            #region 金华
                            carbj = jhwaitlistOnthisLine[dataGrid_waitcar.SelectedRows[0].Index];
                            carbjJh = jhvehicleinflistOnthisLine[dataGrid_waitcar.SelectedRows[0].Index];
                            ref_carInf(carbj);
                            buttonStart.Enabled = true;
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
                        {
                            #region 江苏
                            comboBoxRLZL.Enabled = false;
                            checkBoxSRL.Checked = false;
                            comboBoxQdxs.SelectedIndex = 0;
                            comboBoxQdltqy.SelectedIndex = 0;
                            string jsclhp = dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString();
                            string jshpys = dataGrid_waitcar.SelectedRows[0].Cells["车牌颜色"].Value.ToString();
                            bool jsstatus;
                            string jserrMsg = "";
                            mainPanel.jsinterface.loginServer(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, out jsstatus, out jserrMsg);
                            if (!jsstatus)
                            {
                                MessageBox.Show(jserrMsg);
                                MessageBox.Show(jserrMsg, "登录失败");
                                ini.INIIO.saveLogInf("登录失败：" + jserrMsg);
                                return;
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("登录成功");
                            }
                            string ackstring = mainPanel.jsinterface.getveicleInfo(jsclhp, jshpys, out mainPanel.jsvehiclemodel, out modelbj, out carbj, out mainPanel.jschecklimitmodel, out jsstatus, out jserrMsg);
                            if (ackstring != "")
                            {
                                MessageBox.Show(ackstring, "获取车辆信息");
                                ini.INIIO.saveLogInf("获取车辆信息：" + ackstring);
                                return;
                            }
                            else
                            {
                                if (!jsstatus)
                                {
                                    MessageBox.Show(jserrMsg);
                                    MessageBox.Show(jserrMsg, "获取车辆信息");
                                    ini.INIIO.saveLogInf("获取车辆信息：" + jserrMsg);
                                    return;
                                }
                                else
                                {
                                    ini.INIIO.saveLogInf("获取车辆信息成功");
                                }
                            }
                            string cjcpys = carinfor.DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.PLATE_COLOR, carbj.CLHP, "");
                            string cjclph = carbj.CLHP;
                            CARDETECTED latestRecord = logininfcontrol.getPreTestDatebyPlate(cjclph, cjcpys);
                            if (latestRecord.CLID == "-2")//如果没有记录，则提示为初检
                            {
                                carbj.JCCS = "1";
                                comboBoxCheckType.Items.Remove("复检");
                            }
                            else//如果有环保记录，则判定记录内容
                            {
                                int latestMonths = caculateMonth(latestRecord.JCSJ, DateTime.Now);//计算最近的检测记录距离此次的时间
                                if (latestMonths > 9)//如果距离超过9个月，则认为达到检测时间
                                {
                                    carbj.JCCS = "1";
                                    carbj.SFCJ = "初检";
                                }
                                else
                                {
                                    int jccs = int.Parse(latestRecord.JCCS) + 1;
                                    carbj.JCCS = jccs.ToString();
                                    carbj.SFCJ = "复检";
                                }
                            }
                            carbj.JCCS = carbj.JCCS;
                            if (carbj.JCCS != "1")
                            {
                                comboBoxCheckType.Items.Clear();
                                foreach (string childcontent in mainPanel.jsinterface.CHECK_TYPE.Values)
                                {
                                    comboBoxCheckType.Items.Add(childcontent);
                                }
                                comboBoxCheckType.Items.Remove("年检");
                                comboBoxCheckType.Text = "复检";
                            }
                            else
                            {
                                comboBoxCheckType.Items.Clear();
                                foreach (string childcontent in mainPanel.jsinterface.CHECK_TYPE.Values)
                                {
                                    comboBoxCheckType.Items.Add(childcontent);
                                }
                                comboBoxCheckType.Items.Remove("复检");
                                comboBoxCheckType.Items.Remove("复检-路检");
                                comboBoxCheckType.Text = "年检";
                            }
                            ref_carInf(modelbj, carbj);
                            buttonStart.Enabled = true;
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                        {
                            #region 安徽
                            modelbj = ahcarinflistOnthisLine[dataGrid_waitcar.SelectedRows[0].Index];
                            carbj = ahwaitlistOnthisLine[dataGrid_waitcar.SelectedRows[0].Index];
                            carbj.JCCS = carbj.JCCS;
                            carbj.SFCJ = "";
                            ref_carInf(modelbj, carbj);
                            buttonStart.Enabled = true;
                            #endregion
                        }
                        else if (mainPanel.useHyDatabase)
                        {
                            #region 华燕数据库
                            if (hyDatabaseInter.readCarBjByRegID(dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString(),out carbj,out modelbj))
                            {
                                carbj.JCZBH = mainPanel.stationid;
                                carbj.JCGWH = mainPanel.lineid;
                                carbj.CLHP = carbj.CPYS + carbj.CLHP;
                                modelbj.CLHP = carbj.CLHP;
                                ref_carInf(modelbj,carbj);
                                buttonStart.Enabled = true;
                            }
                            else
                            {
                                buttonStart.Enabled = false;
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.GUILINNETMODE)
                        {
                            #region 桂林
                            int seletedindex = dataGrid_waitcar.SelectedRows[0].Index;
                            if (seletedindex >= 0)
                            {
                                string inspectionnum = dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString();
                                string inspectionmethod = dataGrid_waitcar.SelectedRows[0].Cells["检测方法代号"].Value.ToString();
                                string acceptancedate= dataGrid_waitcar.SelectedRows[0].Cells["登录时间"].Value.ToString();
                                string dlygl= dataGrid_waitcar.SelectedRows[0].Cells["登录员"].Value.ToString();
                                string jccsgl = "";
                                if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "初检")
                                    jccsgl = "1";
                                else if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "复检")
                                    jccsgl = "2";
                                else if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "多检")
                                    jccsgl = "3";
                                string result;
                                string errmsg = "";
                                DataTable dt = new DataTable();
                                Hashtable ht2 = new Hashtable();
                                ht2.Add("stationcode", mainPanel.stationid);
                                ht2.Add("linecode", mainPanel.lineid);
                                ht2.Add("inspectionnum", inspectionnum);
                                ht2.Add("inspectionmethod", inspectionmethod);
                                if(!mainPanel.gxinterface.GetVehicleInf(ht2, out dt, out result, out errmsg))
                                {
                                    MessageBox.Show("获取待检车辆"+ inspectionnum + "信息失败:" + errmsg);
                                    return;
                                }
                                if (dt != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = dt.Rows[0]["vlpn"].ToString()+"T"+DateTime.Now.ToString("yyyyMMddHHmmss");//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Parse(acceptancedate);
                                    carbj.CLHP = dt.Rows[0]["vlpn"].ToString();
                                    carbj.CPYS = dt.Columns.Contains("vlpncolor") ?mainPanel.gxinterface.GL_vlpncolor.GetValue(dt.Rows[0]["vlpncolor"].ToString(), ""):"";
                                    carbj.HPZL = dt.Columns.Contains("hpzl") ? mainPanel.gxinterface.GL_hpzl.GetValue(dt.Rows[0]["hpzl"].ToString(), "") : "";
                                    carbj.XSLC = dt.Columns.Contains("mileage") ? dt.Rows[0]["mileage"].ToString() : "";
                                    carbj.JCCS = jccsgl;                                  
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = dlygl;
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = "";
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = dt.Rows[0]["uniquestring"].ToString();//在桂林联网 中用作uniquestring,作唯一标识一辆车
                                    carbj.JYLSH = inspectionnum;
                                    //CARINF model = new CARINF();
                                    modelbj.CLHP = dt.Rows[0]["vlpn"].ToString();
                                    modelbj.ZCRQ = dt.Columns.Contains("vrdate") ? DateTime.Parse(dt.Rows[0]["vrdate"].ToString()) : DateTime.Now;
                                    modelbj.CLSBM = dt.Columns.Contains("vin") ? dt.Rows[0]["vin"].ToString() : "";

                                    modelbj.CPYS = dt.Columns.Contains("vlpncolor") ? mainPanel.gxinterface.GL_vlpncolor.GetValue(dt.Rows[0]["vlpncolor"].ToString(), "") : "";
                                    modelbj.HPZL = dt.Columns.Contains("hpzl") ? mainPanel.gxinterface.GL_hpzl.GetValue(dt.Rows[0]["hpzl"].ToString(), "") : "";
                                    modelbj.CLLX = dt.Columns.Contains("gavtype") ? mainPanel.logininfcontrol.getComBoBoxItemsNAME("车辆类型", dt.Rows[0]["gavtype"].ToString()) : "";

                                    modelbj.CZ = dt.Columns.Contains("ownername") ? dt.Rows[0]["ownername"].ToString() : "";
                                    modelbj.SYXZ = dt.Columns.Contains("useofauto") ? mainPanel.gxinterface.GL_useofauto.GetValue( dt.Rows[0]["useofauto"].ToString(),"") : "";


                                    modelbj.PP = dt.Columns.Contains("factoryplatemodel") ? dt.Rows[0]["factoryplatemodel"].ToString() : "";
                                    modelbj.XH = dt.Columns.Contains("factoryplatemodel") ? dt.Rows[0]["factoryplatemodel"].ToString() : "";
                                    modelbj.FDJHM = dt.Columns.Contains("enginenum") ? dt.Rows[0]["enginenum"].ToString() : "";
                                    modelbj.FDJXH = dt.Columns.Contains("iuetype") ? dt.Rows[0]["iuetype"].ToString() : "";
                                    modelbj.SCQY = dt.Columns.Contains("iuvmanu") ? dt.Rows[0]["iuvmanu"].ToString() : "";
                                    modelbj.HDZK = dt.Columns.Contains("ratedseats") ? dt.Rows[0]["ratedseats"].ToString() : "";
                                    modelbj.JSSZK ="1";
                                    modelbj.ZZL = dt.Columns.Contains("vml") ? dt.Rows[0]["vml"].ToString() : "";
                                    modelbj.HDZZL = "";
                                    modelbj.JZZL = dt.Columns.Contains("benchmarkmass") ? dt.Rows[0]["benchmarkmass"].ToString() : "";
                                    modelbj.ZBZL = dt.Columns.Contains("kerbmass") ? dt.Rows[0]["kerbmass"].ToString() : "";

                                    modelbj.SCRQ = dt.Columns.Contains("productdate") ? DateTime.Parse(dt.Rows[0]["productdate"].ToString()) : DateTime.Now;
                                    modelbj.FDJPL = dt.Columns.Contains("edspl") ? dt.Rows[0]["edspl"].ToString() : "";
                                    modelbj.RLZL= dt.Columns.Contains("fueltype") ? mainPanel.gxinterface.GL_fueltype.GetValue(dt.Rows[0]["fueltype"].ToString(),"") : "";
                                    modelbj.EDGL = dt.Columns.Contains("enginepower") ? dt.Rows[0]["enginepower"].ToString() : "";
                                    modelbj.EDZS = dt.Columns.Contains("engineratedspeed") ? dt.Rows[0]["engineratedspeed"].ToString() : "";
                                    if (modelbj.EDZS == "") modelbj.EDZS = "3500";
                                    modelbj.BSQXS = dt.Columns.Contains("variableform") ? mainPanel.gxinterface.GL_variableform.GetValue(dt.Rows[0]["variableform"].ToString(),"") : "";
                                    modelbj.DWS = dt.Columns.Contains("gearcount") ? dt.Rows[0]["gearcount"].ToString() : "";
                                    modelbj.GYFS = dt.Columns.Contains("oilsupplyway") ? mainPanel.gxinterface.GL_oilsupplyway.GetValue(dt.Rows[0]["oilsupplyway"].ToString(),"") : "";
                                    modelbj.DPFS = "";
                                    modelbj.JQFS = dt.Columns.Contains("intakeway") ? mainPanel.gxinterface.GL_intakeway.GetValue(dt.Rows[0]["intakeway"].ToString(),"") : "";
                                    modelbj.QGS = dt.Columns.Contains("cylindercount") ? dt.Rows[0]["cylindercount"].ToString():"";
                                    modelbj.QDXS = dt.Columns.Contains("driveform") ? mainPanel.gxinterface.GL_driveform.GetValue(dt.Rows[0]["driveform"].ToString(),"") : "";
                                    modelbj.CHZZ = "";
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = dt.Columns.Contains("isdoublefuel") ? mainPanel.gxinterface.GL_isdoublefuel.GetValue(dt.Rows[0]["isdoublefuel"].ToString(),"") : "";
                                    if (dt.Rows[0]["hascca"].ToString() == "0" && dt.Rows[0]["hasoxygensensor"].ToString() == "0")
                                        modelbj.JHZZ = "没有";
                                    else
                                        modelbj.JHZZ = "有";
                                    modelbj.OBD = dt.Columns.Contains("hasobd") ? mainPanel.gxinterface.GL_hasobd.GetValue(dt.Rows[0]["hasobd"].ToString(), "") : "";//(jxthiscarinf.flagObd == "N" ? "无" : "有");
                                    modelbj.DKGYYB = "";// (jxthiscarinf.flagDk == "N" ? "无" : "有");
                                    modelbj.LXDH ="";
                                    modelbj.CZDZ = dt.Columns.Contains("address") ? dt.Rows[0]["address"].ToString() : "";
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";// (jxthiscarinf.flagDk == "N" ? "无" : "有");

                                    modelbj.CLZL = dt.Columns.Contains("vehicletype") ? mainPanel.gxinterface.GL_vehicletype.GetValue(dt.Rows[0]["vehicletype"].ToString(),"") : "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY = "";

                                    modelbj.RYPH = "";
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    
                                    carbj.JCFF= mainPanel.gxinterface.GL_inspectionmethod.GetValue(inspectionmethod,"");
                                    
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;

                                }
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.PNNETMODE)
                        {
                            #region 平南（获取车辆信息）
                            int seletedindex = dataGrid_waitcar.SelectedRows[0].Index;
                            if (seletedindex >= 0)
                            {
                                string inspectionnum = dataGrid_waitcar.SelectedRows[0].Cells["检测编号"].Value.ToString();
                                string inspectionmethod = dataGrid_waitcar.SelectedRows[0].Cells["检测方法代号"].Value.ToString();
                                string acceptancedate = dataGrid_waitcar.SelectedRows[0].Cells["登录时间"].Value.ToString();
                                string dlygl = dataGrid_waitcar.SelectedRows[0].Cells["登录员"].Value.ToString();
                                string jccsgl = "";
                                if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "初检")
                                    jccsgl = "1";
                                else if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "复检")
                                    jccsgl = "2";
                                else if (dataGrid_waitcar.SelectedRows[0].Cells["检测类型"].Value.ToString() == "多检")
                                    jccsgl = "3";
                                string errmsg = "";
                                DataTable dt = new DataTable();
                                if (!mainPanel.pninterface.GetCarInfo(inspectionmethod, inspectionnum, out dt, out errmsg))
                                {
                                    MessageBox.Show("获取待检车辆" + inspectionnum + "信息失败:" + errmsg);
                                    return;
                                }
                                if (dt != null)
                                {
                                    DateTime a, b;
                                    carbj.CLID = dt.Rows[0]["VLPN"].ToString() + "T" + DateTime.Now.ToString("yyyyMMddHHmmss");//联网时，用外观检验号做车辆ID号
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = dt.Rows[0]["VLPN"].ToString();
                                    carbj.CPYS = dt.Columns.Contains("VLPNColor") ? mainPanel.pninterface.PN_vlpncolor.GetValue(dt.Rows[0]["VLPNColor"].ToString(), "") : "";
                                    carbj.HPZL = dt.Columns.Contains("HPZL") ? mainPanel.pninterface.PN_hpzl.GetValue(dt.Rows[0]["HPZL"].ToString(), "") : "";
                                    carbj.XSLC = dt.Columns.Contains("Mileage") ? dt.Rows[0]["Mileage"].ToString() : "";
                                    carbj.JCCS = jccsgl;
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = dlygl;
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = "";
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = dt.Rows[0]["UniqueString"].ToString();//在桂林联网 中用作uniquestring,作唯一标识一辆车
                                    carbj.JYLSH = inspectionnum;

                                    modelbj.CLHP = dt.Rows[0]["VLPN"].ToString();
                                    modelbj.ZCRQ = dt.Columns.Contains("VRDATE") ? DateTime.Parse(dt.Rows[0]["VRDATE"].ToString()) : DateTime.Now;
                                    modelbj.CLSBM = dt.Columns.Contains("VIN") ? dt.Rows[0]["VIN"].ToString() : "";
                                    modelbj.CPYS = dt.Columns.Contains("VLPNColor") ? mainPanel.pninterface.PN_vlpncolor.GetValue(dt.Rows[0]["VLPNColor"].ToString(), "") : "";
                                    modelbj.HPZL = dt.Columns.Contains("HPZL") ? mainPanel.pninterface.PN_hpzl.GetValue(dt.Rows[0]["HPZL"].ToString(), "") : "";
                                    modelbj.CLLX = dt.Columns.Contains("GAVType") ? mainPanel.logininfcontrol.getComBoBoxItemsNAME("车辆类型", dt.Rows[0]["GAVType"].ToString()) : "";
                                    modelbj.CZ = dt.Columns.Contains("OwnerName") ? dt.Rows[0]["OwnerName"].ToString() : "";
                                    modelbj.SYXZ = dt.Columns.Contains("UseOfAuto") ? mainPanel.pninterface.PN_useofauto.GetValue(dt.Rows[0]["UseOfAuto"].ToString(), "") : "";
                                    modelbj.PP = dt.Columns.Contains("FactoryPlateModel") ? dt.Rows[0]["FactoryPlateModel"].ToString() : "";
                                    modelbj.XH = dt.Columns.Contains("FactoryPlateModel") ? dt.Rows[0]["FactoryPlateModel"].ToString() : "";
                                    modelbj.FDJHM = dt.Columns.Contains("EngineNum") ? dt.Rows[0]["EngineNum"].ToString() : "";
                                    modelbj.FDJXH = dt.Columns.Contains("IUETYPE") ? dt.Rows[0]["IUETYPE"].ToString() : "";
                                    modelbj.SCQY = dt.Columns.Contains("IUVMANU") ? dt.Rows[0]["IUVMANU"].ToString() : "";
                                    modelbj.HDZK = dt.Columns.Contains("RatedSeats") ? dt.Rows[0]["RatedSeats"].ToString() : "";
                                    modelbj.JSSZK = "1";
                                    modelbj.ZZL = dt.Columns.Contains("VML") ? dt.Rows[0]["VML"].ToString() : "";
                                    modelbj.HDZZL = "";
                                    modelbj.JZZL = dt.Columns.Contains("BenchmarkMass") ? dt.Rows[0]["BenchmarkMass"].ToString() : "";
                                    modelbj.ZBZL = dt.Columns.Contains("KerbMass") ? dt.Rows[0]["KerbMass"].ToString() : "";
                                    modelbj.SCRQ = dt.Columns.Contains("ProductDate") ? DateTime.Parse(dt.Rows[0]["ProductDate"].ToString()) : DateTime.Now;
                                    modelbj.FDJPL = dt.Columns.Contains("EDSPL") ? dt.Rows[0]["EDSPL"].ToString() : "";
                                    modelbj.RLZL = dt.Columns.Contains("FuelType") ? mainPanel.pninterface.PN_fueltype.GetValue(dt.Rows[0]["FuelType"].ToString(), "") : "";
                                    modelbj.EDGL = dt.Columns.Contains("EnginePower") ? dt.Rows[0]["EnginePower"].ToString() : "";
                                    modelbj.EDZS = dt.Columns.Contains("EngineRatedSpeed") ? dt.Rows[0]["EngineRatedSpeed"].ToString() : "";
                                    if (modelbj.EDZS == "") modelbj.EDZS = "3500";
                                    modelbj.BSQXS = dt.Columns.Contains("VariableForm") ? mainPanel.pninterface.PN_variableform.GetValue(dt.Rows[0]["VariableForm"].ToString(), "") : "";
                                    modelbj.DWS = dt.Columns.Contains("GearCount") ? dt.Rows[0]["GearCount"].ToString() : "";
                                    modelbj.GYFS = dt.Columns.Contains("OilSupplyWay") ? mainPanel.pninterface.PN_oilsupplyway.GetValue(dt.Rows[0]["OilSupplyWay"].ToString(), "") : "";
                                    modelbj.DPFS = "";
                                    modelbj.JQFS = dt.Columns.Contains("IntakeWay") ? mainPanel.pninterface.PN_intakeway.GetValue(dt.Rows[0]["IntakeWay"].ToString(), "") : "";
                                    modelbj.QGS = dt.Columns.Contains("CylinderCount") ? dt.Rows[0]["CylinderCount"].ToString() : "";
                                    modelbj.QDXS = dt.Columns.Contains("DriveForm") ? mainPanel.pninterface.PN_driveform.GetValue(dt.Rows[0]["DriveForm"].ToString(), "") : "";
                                    modelbj.CHZZ = "";
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = dt.Columns.Contains("IsDoubleFuel") ? mainPanel.pninterface.PN_isdoublefuel.GetValue(dt.Rows[0]["IsDoubleFuel"].ToString(), "") : "";
                                    if (dt.Columns.Contains("HasCCA") && dt.Columns.Contains("HasOxygenSensor") && dt.Rows[0]["HasCCA"].ToString() == "0" && dt.Rows[0]["HasOxygenSensor"].ToString() == "0")
                                        modelbj.JHZZ = "没有";
                                    else
                                        modelbj.JHZZ = "有";
                                    modelbj.OBD = dt.Columns.Contains("HasOBD") ? mainPanel.pninterface.PN_hasobd.GetValue(dt.Rows[0]["HasOBD"].ToString(), "") : "";//(jxthiscarinf.flagObd == "N" ? "无" : "有");
                                    modelbj.DKGYYB = "";
                                    modelbj.LXDH = "";
                                    modelbj.CZDZ = dt.Columns.Contains("Address") ? dt.Rows[0]["Address"].ToString() : "";
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";
                                    modelbj.CLZL = dt.Columns.Contains("VehicleType") ? mainPanel.pninterface.PN_vehicletype.GetValue(dt.Rows[0]["VehicleType"].ToString(), "") : "";
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY = "";
                                    modelbj.RYPH = "";
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";

                                    carbj.JCFF = mainPanel.pninterface.PN_inspectionmethod.GetValue(inspectionmethod, "");

                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;

                                }
                            }
                            #endregion
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE&&(mainPanel.tynettype==mainPanel.TYNETTYPE_NNDL||mainPanel.tynettype==mainPanel.TYNETTYPE_SDYT))
                        {
                            #region 大连安车联网
                            int seletedindex = dataGrid_waitcar.SelectedRows[0].Index;
                            if (seletedindex >= 0)
                            {
                                carbj = logininfcontrol.getCarInfatWaitList(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString());
                                if (carbj.CLID != "-2")
                                {
                                    carbj.CPYS = mainPanel.acDicCpys.GetValue(carbj.CPYS, "");
                                    carbj.HPZL = mainPanel.acDicHpzl.GetValue(carbj.HPZL, "");
                                    modelbj = logininfcontrol.getCarInfbyPlate(carbj.CLHP);
                                    modelbj.CPYS = mainPanel.acDicCpys.GetValue(modelbj.CPYS, "");
                                    modelbj.HPZL = mainPanel.acDicHpzl.GetValue(modelbj.HPZL, "");
                                    modelbj.CLLX = modelbj.CLLX + "_" + mainPanel.logininfcontrol.getComBoBoxItemsNAME("车辆类型", modelbj.CLLX);
                                    modelbj.SYXZ = mainPanel.acDicSyxz.GetValue(modelbj.SYXZ, "");
                                    modelbj.RLZL = mainPanel.acDicRlzl.GetValue(modelbj.RLZL, "");
                                    modelbj.BSQXS = mainPanel.acDicBsqxs.GetValue(modelbj.BSQXS, "");
                                    modelbj.GYFS = mainPanel.acDicRyxs.GetValue(modelbj.GYFS, "");
                                    modelbj.JQFS = mainPanel.acDicJqfs.GetValue(modelbj.JQFS, "");
                                    modelbj.QDXS = mainPanel.acDicQdfs.GetValue(modelbj.QDXS, "");
                                    modelbj.JHZZ = mainPanel.acDicChzhq.GetValue(modelbj.JHZZ, "无");
                                    modelbj.OBD = mainPanel.acDicYW.GetValue(modelbj.OBD, "");
                                    modelbj.CHZZ = mainPanel.acDicYW.GetValue(modelbj.CHZZ, "");
                                    modelbj.JCLB = mainPanel.acDicJclx.GetValue(modelbj.JCLB, "");
                                    modelbj.ZXBZ = mainPanel.acDicPfbz.GetValue(modelbj.ZXBZ, "");
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;
                                }                           
                            }
                            #endregion
                        }
                        else
                        {
                            #region 单机及其他
                            carbj = logininfcontrol.getCarInfatWaitList(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString());
                            ref_carInf(carbj);
                            buttonStart.Enabled = true;
                            #endregion
                        }
                    }
                    else if (dataGrid_waitcar.SelectedRows.Count > 1)
                    {
                        selectID = new string[1024];
                        for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                        {
                            selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                        }
                        buttonStart.Enabled = false;
                    }
                    else
                    {
                        selectID = new string[1024];
                        for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                        {
                            selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                        }
                        buttonStart.Enabled = false;
                    }
                }
                else
                {
                    selectID = new string[1024];
                    for (int i = 0; i < dataGrid_waitcar.SelectedRows.Count; i++)
                    {
                        selectID[i] = dataGrid_waitcar.SelectedRows[i].Cells["检测编号"].Value.ToString();
                    }
                    buttonStart.Enabled = false;
                }
            }
        }

        private int caculateMonth(DateTime datetime1, DateTime datetime2)
        {
            int year1 = datetime1.Year;
            int year2 = datetime2.Year;
            int month1 = datetime1.Month;
            int month2 = datetime2.Month;
            int months = 12 * (year2 - year1) + (month2 - month1);
            return months;
        }
        private int caculateDays(DateTime datetime1, DateTime datetime2)
        {
            int year1 = datetime1.Year;
            int year2 = datetime2.Year;
            int month1 = datetime1.Month;
            int month2 = datetime2.Month;
            int day1 = datetime1.Day;
            int day2 = datetime2.Day;
            int days = 365 * (year2 - year1) + 30 * (month2 - month1) + day2 - day1;
            return days;
        }
        private void ref_carInf(CARATWAIT caratwait)
        {
            try
            {
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                {
                    modelbj = jhcarinflistOnthisLine[dataGrid_waitcar.SelectedRows[0].Index];
                }
                else
                {
                    modelbj = logininfcontrol.getCarInfbyPlate(caratwait.CLHP);
                }
                if (modelbj.CLHP != "-2")
                {
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;

                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;


                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;

                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;

                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.CPYS;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;

                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;

                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ORTNETMODE)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.CPYS;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;

                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;

                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                            labelCLPH.Text = modelbj.CLHP;
                            labelCPYS.Text = mainPanel.acDicHpzl.GetValue(modelbj.HPZL, "");
                            labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                            comboBoxBgff.SelectedIndex = 0;
                            switch (caratwait.JCFF)
                            {
                                case "ASM":
                                    labelJCFF.Text = "稳态工况";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "VMAS":
                                    labelJCFF.Text = "简易瞬态";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "JZJS":
                                    labelJCFF.Text = "加载减速";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "ZYJS":
                                    labelJCFF.Text = "自由加速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDS":
                                    labelJCFF.Text = "双怠速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDSM":
                                    labelJCFF.Text = "双怠速(犘)";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "LZ":
                                    labelJCFF.Text = "滤纸";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "无要求":
                                    labelJCFF.Text = "无要求";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                default: break;
                            }
                            labelJCCS.Text = caratwait.JCCS;
                            labelCLLX.Text = modelbj.CLLX;
                            labelCZ.Text = modelbj.CZ;
                            labelSYXZ.Text = modelbj.SYXZ;
                            labelPP.Text = modelbj.PP;
                            labelXH.Text = modelbj.XH;
                            labelDPHM.Text = modelbj.CLSBM;
                            labelFDJH.Text = modelbj.FDJHM;
                            labelFDJXH.Text = modelbj.FDJXH;
                            labelSCS.Text = modelbj.SCQY;
                            labelHDZK.Text = modelbj.HDZK;
                            labelJSSZK.Text = modelbj.JSSZK;
                            labelZZL.Text = modelbj.ZZL;
                            labelHDZZL.Text = modelbj.HDZZL;
                            labelZBZL.Text = modelbj.ZBZL;
                            labelJZZL.Text = modelbj.JZZL;
                            labelFDJPL.Text = modelbj.FDJPL;
                            labelRLZL.Text = modelbj.RLZL;
                            labelEDGL.Text = modelbj.EDGL;
                            labelEDZS.Text = modelbj.EDZS;
                            labelDPXS.Text = modelbj.DPFS;
                            labelCHZZ.Text = modelbj.CHZZ;
                            labelBSQXS.Text = modelbj.BSQXS;
                            labelDWS.Text = modelbj.DWS;
                            labelGYFS.Text = modelbj.GYFS;
                            labelJQFS.Text = modelbj.JQFS;
                            labelQGS.Text = modelbj.QGS;
                            labelQDXS.Text = modelbj.QDXS;
                            labelDLSP.Text = modelbj.DLSP;
                            labelSRL.Text = modelbj.SFSRL;
                            labelJHZZ.Text = modelbj.JHZZ;
                            labelDLY.Text = caratwait.DLY;
                            textBoxWXBJ.Text = caratwait.WXBJ;
                            textBoxWXCD.Text = caratwait.WXCD;
                            DateTime wxsj = DateTime.Now;

                            if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                                dateTimePickerWXSJ.Value = wxsj;
                            else
                                dateTimePickerWXSJ.Value = DateTime.Now;
                            dateTimePickerWXSJ.Value = wxsj;
                            textBoxWXFY.Text = caratwait.WXFY;
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            labelCLPH.Text = modelbj.CLHP;
                            labelCPYS.Text = mainPanel.acDicHpzl.GetValue(modelbj.HPZL, "");
                            labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                            comboBoxBgff.SelectedIndex = 0;
                            switch (caratwait.JCFF)
                            {
                                case "ASM":
                                    labelJCFF.Text = "稳态工况";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "VMAS":
                                    labelJCFF.Text = "简易瞬态";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "JZJS":
                                    labelJCFF.Text = "加载减速";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "ZYJS":
                                    labelJCFF.Text = "自由加速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDS":
                                    labelJCFF.Text = "双怠速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDSM":
                                    labelJCFF.Text = "双怠速(犘)";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "LZ":
                                    labelJCFF.Text = "滤纸";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "无要求":
                                    labelJCFF.Text = "无要求";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                default: break;
                            }
                            labelJCCS.Text = caratwait.JCCS;
                            labelCLLX.Text = modelbj.CLLX;
                            labelCZ.Text = modelbj.CZ;
                            labelSYXZ.Text = modelbj.SYXZ;
                            labelPP.Text = modelbj.PP;
                            labelXH.Text = modelbj.XH;
                            labelDPHM.Text = modelbj.CLSBM;
                            labelFDJH.Text = modelbj.FDJHM;
                            labelFDJXH.Text = modelbj.FDJXH;
                            labelSCS.Text = modelbj.SCQY;
                            labelHDZK.Text = modelbj.HDZK;
                            labelJSSZK.Text = modelbj.JSSZK;
                            labelZZL.Text = modelbj.ZZL;
                            labelHDZZL.Text = modelbj.HDZZL;
                            labelZBZL.Text = modelbj.ZBZL;
                            labelJZZL.Text = modelbj.JZZL;
                            labelFDJPL.Text = modelbj.FDJPL;
                            labelRLZL.Text = modelbj.RLZL;
                            labelEDGL.Text = modelbj.EDGL;
                            labelEDZS.Text = modelbj.EDZS;
                            labelDPXS.Text = modelbj.DPFS;
                            labelCHZZ.Text = modelbj.CHZZ;
                            labelBSQXS.Text = modelbj.BSQXS;
                            labelDWS.Text = modelbj.DWS;
                            labelGYFS.Text = modelbj.GYFS;
                            labelJQFS.Text = modelbj.JQFS;
                            labelQGS.Text = modelbj.QGS;
                            labelQDXS.Text = modelbj.QDXS;
                            labelDLSP.Text = modelbj.DLSP;
                            labelSRL.Text = modelbj.SFSRL;
                            labelJHZZ.Text = modelbj.JHZZ;
                            labelDLY.Text = caratwait.DLY;
                            textBoxWXBJ.Text = caratwait.WXBJ;
                            textBoxWXCD.Text = caratwait.WXCD;
                            DateTime wxsj = DateTime.Now;

                            if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                                dateTimePickerWXSJ.Value = wxsj;
                            else
                                dateTimePickerWXSJ.Value = DateTime.Now;
                            dateTimePickerWXSJ.Value = wxsj;
                            textBoxWXFY.Text = caratwait.WXFY;
                        }
                        else
                        {
                            labelCLPH.Text = modelbj.CLHP;
                            labelCPYS.Text = modelbj.HPZL;
                            labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                            comboBoxBgff.SelectedIndex = 0;
                            switch (caratwait.JCFF)
                            {
                                case "ASM":
                                    labelJCFF.Text = "稳态工况";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "VMAS":
                                    labelJCFF.Text = "简易瞬态";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "JZJS":
                                    labelJCFF.Text = "加载减速";
                                    comboBoxBgff.Enabled = true;
                                    break;
                                case "ZYJS":
                                    labelJCFF.Text = "自由加速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDS":
                                    labelJCFF.Text = "双怠速";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "SDSM":
                                    labelJCFF.Text = "双怠速(犘)";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "LZ":
                                    labelJCFF.Text = "滤纸";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                case "无要求":
                                    labelJCFF.Text = "无要求";
                                    comboBoxBgff.Enabled = false;
                                    break;
                                default: break;
                            }
                            labelJCCS.Text = caratwait.JCCS;
                            labelCLLX.Text = modelbj.CLLX;
                            labelCZ.Text = modelbj.CZ;
                            labelSYXZ.Text = modelbj.SYXZ;
                            labelPP.Text = modelbj.PP;
                            labelXH.Text = modelbj.XH;
                            labelDPHM.Text = modelbj.CLSBM;
                            labelFDJH.Text = modelbj.FDJHM;
                            labelFDJXH.Text = modelbj.FDJXH;
                            labelSCS.Text = modelbj.SCQY;
                            labelHDZK.Text = modelbj.HDZK;
                            labelJSSZK.Text = modelbj.JSSZK;
                            labelZZL.Text = modelbj.ZZL;
                            labelHDZZL.Text = modelbj.HDZZL;
                            labelZBZL.Text = modelbj.ZBZL;
                            labelJZZL.Text = modelbj.JZZL;
                            labelFDJPL.Text = modelbj.FDJPL;
                            labelRLZL.Text = modelbj.RLZL;
                            labelEDGL.Text = modelbj.EDGL;
                            labelEDZS.Text = modelbj.EDZS;
                            labelDPXS.Text = modelbj.DPFS;
                            labelCHZZ.Text = modelbj.CHZZ;
                            labelBSQXS.Text = modelbj.BSQXS;
                            labelDWS.Text = modelbj.DWS;
                            labelGYFS.Text = modelbj.GYFS;
                            labelJQFS.Text = modelbj.JQFS;
                            labelQGS.Text = modelbj.QGS;
                            labelQDXS.Text = modelbj.QDXS;
                            labelDLSP.Text = modelbj.DLSP;
                            labelSRL.Text = modelbj.SFSRL;
                            labelJHZZ.Text = modelbj.JHZZ;
                            labelDLY.Text = caratwait.DLY;
                            textBoxWXBJ.Text = caratwait.WXBJ;
                            textBoxWXCD.Text = caratwait.WXCD;
                            DateTime wxsj = DateTime.Now;

                            if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                                dateTimePickerWXSJ.Value = wxsj;
                            else
                                dateTimePickerWXSJ.Value = DateTime.Now;
                            dateTimePickerWXSJ.Value = wxsj;
                            textBoxWXFY.Text = caratwait.WXFY;
                        }
                    }

                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;
                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;

                    }
                    else if ((mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)||caratwait.SOURCE=="1")//如果是红河州联网或者由web接口登录 的车
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ+"("+modelbj.SFYQBF+")";
                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        dateTimePickerWXSJ.Value = wxsj;
                        textBoxWXFY.Text = caratwait.WXFY;

                    }
                    else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE && mainPanel.acsocketinf.AREA == mainPanel.ACAREA_NN)
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = modelbj.CLLX;
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = modelbj.SYXZ;
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = modelbj.RLZL;
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = modelbj.DPFS;
                        labelCHZZ.Text = modelbj.CHZZ;
                        labelBSQXS.Text = modelbj.BSQXS;
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = modelbj.GYFS;
                        labelJQFS.Text = modelbj.JQFS;
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = modelbj.QDXS;
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        labelJHZZ.Text = modelbj.JHZZ;
                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;
                        textBoxWXFY.Text = caratwait.WXFY;
                        int jccs = 1;
                        if (int.TryParse(caratwait.JCCS, out jccs))
                        {
                            if (jccs > 1)
                            {
                                panelwx.Visible = true;
                            }
                            else
                            {
                                panelwx.Visible = false;
                            }
                        }

                    }
                    else
                    {
                        labelCLPH.Text = modelbj.CLHP;
                        labelCPYS.Text = modelbj.HPZL;
                        labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                        comboBoxBgff.SelectedIndex = 0;
                        switch (caratwait.JCFF)
                        {
                            case "ASM":
                                labelJCFF.Text = "稳态工况";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "VMAS":
                                labelJCFF.Text = "简易瞬态";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "JZJS":
                                labelJCFF.Text = "加载减速";
                                comboBoxBgff.Enabled = true;
                                break;
                            case "ZYJS":
                                labelJCFF.Text = "自由加速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDS":
                                labelJCFF.Text = "双怠速";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "SDSM":
                                labelJCFF.Text = "双怠速(犘)";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "LZ":
                                labelJCFF.Text = "滤纸";
                                comboBoxBgff.Enabled = false;
                                break;
                            case "无要求":
                                labelJCFF.Text = "无要求";
                                comboBoxBgff.Enabled = false;
                                break;
                            default: break;
                        }
                        labelJCCS.Text = caratwait.JCCS;
                        labelCLLX.Text = logininfcontrol.getComBoBoxItemsNAME("车辆类型", modelbj.CLLX);
                        labelCZ.Text = modelbj.CZ;
                        labelSYXZ.Text = logininfcontrol.getComBoBoxItemsNAME("使用性质", modelbj.SYXZ);
                        labelPP.Text = modelbj.PP;
                        labelXH.Text = modelbj.XH;
                        labelDPHM.Text = modelbj.CLSBM;
                        labelFDJH.Text = modelbj.FDJHM;
                        labelFDJXH.Text = modelbj.FDJXH;
                        labelSCS.Text = modelbj.SCQY;
                        labelHDZK.Text = modelbj.HDZK;
                        labelJSSZK.Text = modelbj.JSSZK;
                        labelZZL.Text = modelbj.ZZL;
                        labelHDZZL.Text = modelbj.HDZZL;
                        labelZBZL.Text = modelbj.ZBZL;
                        labelJZZL.Text = modelbj.JZZL;
                        labelFDJPL.Text = modelbj.FDJPL;
                        labelRLZL.Text = logininfcontrol.getComBoBoxItemsNAME("燃料种类", modelbj.RLZL);
                        labelEDGL.Text = modelbj.EDGL;
                        labelEDZS.Text = modelbj.EDZS;
                        labelDPXS.Text = logininfcontrol.getComBoBoxItemsNAME("电喷方式", modelbj.DPFS);
                        labelCHZZ.Text = logininfcontrol.getComBoBoxItemsNAME("侧滑装置", modelbj.CHZZ);
                        labelBSQXS.Text = logininfcontrol.getComBoBoxItemsNAME("变速器形式", modelbj.BSQXS);
                        labelDWS.Text = modelbj.DWS;
                        labelGYFS.Text = logininfcontrol.getComBoBoxItemsNAME("供油方式", modelbj.GYFS);
                        labelJQFS.Text = logininfcontrol.getComBoBoxItemsNAME("进气方式", modelbj.JQFS);
                        labelQGS.Text = modelbj.QGS;
                        labelQDXS.Text = logininfcontrol.getComBoBoxItemsNAME("驱动形式", modelbj.QDXS);
                        labelDLSP.Text = modelbj.DLSP;
                        labelSRL.Text = modelbj.SFSRL;
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                        {
                            if (modelbj.JHZZ == "0") labelJHZZ.Text = "无";
                            else labelJHZZ.Text = "有";
                            //labelJHZZ.Text = logininfcontrol.getComBoBoxItemsNAME("催化转化器", modelbj.JHZZ);
                        }
                        else
                        {
                            if (labelRLZL.Text.Contains("柴油"))
                                labelJHZZ.Text = logininfcontrol.getComBoBoxItemsNAME("排气后处理装置", modelbj.JHZZ);
                            else
                                labelJHZZ.Text = logininfcontrol.getComBoBoxItemsNAME("催化转化器", modelbj.JHZZ);
                        }
                        labelDLY.Text = caratwait.DLY;
                        textBoxWXBJ.Text = caratwait.WXBJ;
                        textBoxWXCD.Text = caratwait.WXCD;
                        DateTime wxsj = DateTime.Now;

                        if (DateTime.TryParse(caratwait.WXSJ, out wxsj))
                            dateTimePickerWXSJ.Value = wxsj;
                        else
                            dateTimePickerWXSJ.Value = DateTime.Now;

                        textBoxWXFY.Text = caratwait.WXFY;
                        int jccs = 1;
                        if (int.TryParse(caratwait.JCCS, out jccs))
                        {
                            if (jccs > 1)
                            {
                                panelwx.Visible = true;
                            }
                            else
                            {
                                panelwx.Visible = false;
                            }
                        }
                    }

                }
            }
            catch
            { }
        }
        private string judgeTestMethod(CARINF model)
        {
            string jcff;
            if (model.RLZL.Contains("柴油"))
            {
                if (model.QDXS != "全时四驱")//2001年10月1日 起生产的汽车，轻型车额定功率不超过150KW，重型车额定功率不超过350KW
                {
                    if (double.Parse(model.ZZL) > 10000 && double.Parse(model.EDGL) <= 350)
                    {
                        if(mainPanel.neusoftsocketinf.AREA==mainPanel.NEU_YNZT|| mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_GZCJ||mainPanel.neusoftsocketinf.AREA==mainPanel.NEU_V301)//昆明没有重柴
                            jcff = "JZJS";
                        else
                            jcff = "ZYJS";

                    }
                    else if (double.Parse(model.ZZL) > 3500 && double.Parse(model.ZZL) <= 10000 && double.Parse(model.EDGL) <= 150)
                    {
                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT|| mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNKM || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_GZCJ || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)//昆明没有重柴
                            jcff = "JZJS";
                        else
                            jcff = "ZYJS";

                    }
                    else if (double.Parse(model.ZZL) <= 3500 && double.Parse(model.EDGL) <= 150)
                    {
                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNKM || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_GZCJ || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)
                            jcff = "JZJS";
                        else
                            jcff = "ZYJS";
                    }
                    else
                    {
                        jcff = "ZYJS";
                    }
                }
                else
                {
                    jcff = "ZYJS";
                }
            }
            else
            {
                if (model.QDXS != "全时四驱")
                {
                    if (double.Parse(model.ZZL) > 3500)
                    {
                        neusoft_idlereason = "2";
                           jcff = "SDS";
                    }
                    else
                    {
                        if (mainPanel.stationinfmodel.STATIONJCFF == "ASM")
                            jcff = "ASM";
                        else
                            jcff = "VMAS";
                    }
                }
                else
                {
                    neusoft_idlereason = "0";
                    jcff = "SDS";
                }
            }
            return jcff;
        }
        private void clear_carinf()
        {
            labelCLPH.Text ="";
            labelCPYS.Text = "";
            labelZCRQ.Text = "";
            comboBoxBgff.SelectedIndex = 0;
                    labelJCFF.Text = "";
            labelJCCS.Text = "";
            labelCLLX.Text = ""; ;
            labelCZ.Text = "";
            labelSYXZ.Text = "";
            labelPP.Text = "";
            labelXH.Text = "";
            labelDPHM.Text = "";
            labelFDJH.Text = "";
            labelFDJXH.Text = "";
            labelSCS.Text = "";
            labelHDZK.Text = "";
            labelJSSZK.Text = "";
            labelZZL.Text = "";
            labelHDZZL.Text = "";
            labelZBZL.Text = "";
            labelJZZL.Text = "";
            labelFDJPL.Text = "";
            labelRLZL.Text = "";
            labelEDGL.Text = "";
            labelEDZS.Text = "";
            labelDPXS.Text = "";
            labelCHZZ.Text = "";
            labelBSQXS.Text = "";
            labelDWS.Text = "";
            labelGYFS.Text = "";
            labelJQFS.Text = "";
            labelQGS.Text = "";
            labelQDXS.Text = ""; ;
            labelDLSP.Text = "";
            labelSRL.Text = "";
            labelJHZZ.Text = "";
            labelDLY.Text = "";
            labelCJTS.Text = "";
        }
        private void ref_carInf(CARINF modelbj, CARATWAIT caratwait)
        {
            //modelbj = logininfcontrol.getCarInfbyPlate(caratwait.CLHP);
            if (modelbj.CLHP != "-2")
            {
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
                {
                    labelCLPH.Text = modelbj.CLHP;
                    labelCPYS.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.PLATE_TYPE, modelbj.HPZL, "");
                    labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                    comboBoxBgff.SelectedIndex = 0;
                    switch (caratwait.JCFF)
                    {
                        case "ASM":
                            labelJCFF.Text = "稳态工况";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "VMAS":
                            labelJCFF.Text = "简易瞬态";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "JZJS":
                            labelJCFF.Text = "加载减速";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "ZYJS":
                            labelJCFF.Text = "自由加速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDS":
                            labelJCFF.Text = "双怠速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDSM":
                            labelJCFF.Text = "双怠速(犘)";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "LZ":
                            labelJCFF.Text = "滤纸";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "无要求":
                            labelJCFF.Text = "无要求";
                            comboBoxBgff.Enabled = false;
                            break;
                        default: break;
                    }
                    labelJCCS.Text = caratwait.JCCS;
                    labelCLLX.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.VEHICLE_KIND, modelbj.CLLX, "");
                    labelCZ.Text = modelbj.CZ;
                    labelSYXZ.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.IS_SERVICE_CAR, modelbj.SYXZ, "");
                    labelPP.Text = modelbj.PP;
                    labelXH.Text = modelbj.XH;
                    labelDPHM.Text = modelbj.CLSBM;
                    labelFDJH.Text = modelbj.FDJHM;
                    labelFDJXH.Text = modelbj.FDJXH;
                    labelSCS.Text = modelbj.SCQY;
                    labelHDZK.Text = modelbj.HDZK;
                    labelJSSZK.Text = modelbj.JSSZK;
                    labelZZL.Text = modelbj.ZZL;
                    labelHDZZL.Text = modelbj.HDZZL;
                    labelZBZL.Text = modelbj.ZBZL;
                    labelJZZL.Text = modelbj.JZZL;
                    labelFDJPL.Text = modelbj.FDJPL;
                    labelRLZL.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.FUEL_TYPE, modelbj.RLZL, "");
                    labelEDGL.Text = modelbj.EDGL;
                    labelEDZS.Text = modelbj.EDZS;
                    labelDPXS.Text = modelbj.DPFS;
                    labelCHZZ.Text = modelbj.CHZZ;
                    labelBSQXS.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.DRIVE_FORM, modelbj.BSQXS, "");
                    labelDWS.Text = modelbj.DWS;
                    labelGYFS.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.SUPPLY_MODE, modelbj.GYFS, "");
                    labelJQFS.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.ADMISSION, modelbj.JQFS, "");
                    labelQGS.Text = modelbj.QGS;
                    labelQDXS.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.DRIVE_MODE, modelbj.QDXS, "");
                    labelDLSP.Text = modelbj.DLSP;
                    labelSRL.Text = modelbj.SFSRL;
                    labelJHZZ.Text = DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.HAS_PURGE, modelbj.JHZZ, "");
                    labelDLY.Text = caratwait.DLY;
                    labelCJTS.Text = "可以参检";
                }
                else if (mainPanel.isNetUsed && (mainPanel.NetMode == mainPanel.NHNETMODE || mainPanel.NetMode == mainPanel.JXNETMODE||mainPanel.NetMode==mainPanel.GUILINNETMODE||mainPanel.NetMode==mainPanel.ZKYTNETMODE || mainPanel.NetMode == mainPanel.PNNETMODE))
                {
                    labelCLPH.Text = modelbj.CLHP;
                    labelCPYS.Text = modelbj.CPYS;
                    labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                    comboBoxBgff.SelectedIndex = 0;
                    switch (caratwait.JCFF)
                    {
                        case "ASM":
                            labelJCFF.Text = "稳态工况";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "VMAS":
                            labelJCFF.Text = "简易瞬态";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "JZJS":
                            labelJCFF.Text = "加载减速";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "ZYJS":
                            labelJCFF.Text = "自由加速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDS":
                            labelJCFF.Text = "双怠速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDSM":
                            labelJCFF.Text = "双怠速(犘)";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "LZ":
                            labelJCFF.Text = "滤纸";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "无要求":
                            labelJCFF.Text = "无要求";
                            comboBoxBgff.Enabled = false;
                            break;
                        default: break;
                    }

                    labelJCCS.Text = caratwait.JCCS;
                    labelCLLX.Text = modelbj.CLLX;
                    labelCZ.Text = modelbj.CZ;
                    labelSYXZ.Text = modelbj.SYXZ;
                    labelPP.Text = modelbj.PP;
                    labelXH.Text = modelbj.XH;
                    labelDPHM.Text = modelbj.CLSBM;
                    labelFDJH.Text = modelbj.FDJHM;
                    labelFDJXH.Text = modelbj.FDJXH;
                    labelSCS.Text = modelbj.SCQY;
                    labelHDZK.Text = modelbj.HDZK;
                    labelJSSZK.Text = modelbj.JSSZK;
                    labelZZL.Text = modelbj.ZZL;
                    labelHDZZL.Text = modelbj.HDZZL;
                    labelZBZL.Text = modelbj.ZBZL;
                    labelJZZL.Text = modelbj.JZZL;
                    labelFDJPL.Text = modelbj.FDJPL;
                    labelRLZL.Text = modelbj.RLZL;
                    labelEDGL.Text = modelbj.EDGL;
                    labelEDZS.Text = modelbj.EDZS;
                    labelDPXS.Text = modelbj.DPFS;
                    labelCHZZ.Text = modelbj.CHZZ;
                    labelBSQXS.Text = modelbj.BSQXS;
                    labelDWS.Text = modelbj.DWS;
                    labelGYFS.Text = modelbj.GYFS;
                    labelJQFS.Text = modelbj.JQFS;
                    labelQGS.Text = modelbj.QGS;
                    labelQDXS.Text = modelbj.QDXS;
                    labelDLSP.Text = modelbj.DLSP;
                    labelSRL.Text = modelbj.SFSRL;
                    labelJHZZ.Text = modelbj.JHZZ;
                    labelDLY.Text = caratwait.DLY;
                    labelCJTS.Text = "可以参检";
                }
                else if (mainPanel.useHyDatabase)
                {

                    labelCLPH.Text = modelbj.CLHP;
                    labelCPYS.Text = modelbj.CPYS;
                    labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                    comboBoxBgff.SelectedIndex = 0;
                    switch (caratwait.JCFF)
                    {
                        case "ASM":
                            labelJCFF.Text = "稳态工况";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "VMAS":
                            labelJCFF.Text = "简易瞬态";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "JZJS":
                            labelJCFF.Text = "加载减速";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "ZYJS":
                            labelJCFF.Text = "自由加速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDS":
                            labelJCFF.Text = "双怠速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDSM":
                            labelJCFF.Text = "双怠速(犘)";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "LZ":
                            labelJCFF.Text = "滤纸";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "无要求":
                            labelJCFF.Text = "无要求";
                            comboBoxBgff.Enabled = false;
                            break;
                        default: break;
                    }
                    labelJCCS.Text = caratwait.JCCS;
                    labelCLLX.Text = logininfcontrol.getComBoBoxItemsNAME("车辆类型", modelbj.CLLX);
                    labelCZ.Text = modelbj.CZ;
                    labelSYXZ.Text = mainPanel.acDicSyxz.GetValue(modelbj.SYXZ, "");
                    labelPP.Text = modelbj.PP;
                    labelXH.Text = modelbj.XH;
                    labelDPHM.Text = modelbj.CLSBM;
                    labelFDJH.Text = modelbj.FDJHM;
                    labelFDJXH.Text = modelbj.FDJXH;
                    labelSCS.Text = modelbj.SCQY;
                    labelHDZK.Text = modelbj.HDZK;
                    labelJSSZK.Text = modelbj.JSSZK;
                    labelZZL.Text = modelbj.ZZL;
                    labelHDZZL.Text = modelbj.HDZZL;
                    labelZBZL.Text = modelbj.ZBZL;
                    labelJZZL.Text = modelbj.JZZL;
                    labelFDJPL.Text = modelbj.FDJPL;
                    labelRLZL.Text = mainPanel.acDicRlzl.GetValue(modelbj.RLZL,"");
                    labelEDGL.Text = modelbj.EDGL;
                    labelEDZS.Text = modelbj.EDZS;
                    labelDPXS.Text = logininfcontrol.getComBoBoxItemsNAME("电喷方式", modelbj.DPFS);
                    labelCHZZ.Text = logininfcontrol.getComBoBoxItemsNAME("侧滑装置", modelbj.CHZZ);
                    labelBSQXS.Text = mainPanel.acDicBsqxs.GetValue(modelbj.BSQXS, "");
                    labelDWS.Text = modelbj.DWS;
                    labelGYFS.Text = mainPanel.acDicRyxs.GetValue(modelbj.GYFS, "");
                    labelJQFS.Text = mainPanel.acDicJqfs.GetValue(modelbj.JQFS, "");
                    labelQGS.Text = modelbj.QGS;
                    labelQDXS.Text = mainPanel.acDicQdfs.GetValue(modelbj.QDXS, "");
                    labelDLSP.Text = modelbj.DLSP;
                    labelSRL.Text = modelbj.SFSRL;
                    labelJHZZ.Text = mainPanel.acDicPqhclzz.GetValue(modelbj.JHZZ, "");                    
                    labelDLY.Text = caratwait.DLY;
                    if (int.Parse(caratwait.JCCS) > 1)
                    {
                        textBoxWXBJ.Text = "";
                        textBoxWXCD.Text = "";
                        textBoxWXFY.Text = "";
                        dateTimePickerWXSJ.Value = DateTime.Now;
                        panelwx.Visible = true;
                    }
                    else
                    {
                        panelwx.Visible = false;
                    }
                }
                else
                {
                    labelCLPH.Text = modelbj.CLHP;
                    labelCPYS.Text = modelbj.CPYS;
                    labelZCRQ.Text = modelbj.ZCRQ.ToShortDateString();
                    comboBoxBgff.SelectedIndex = 0;
                    switch (caratwait.JCFF)
                    {
                        case "ASM":
                            labelJCFF.Text = "稳态工况";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "VMAS":
                            labelJCFF.Text = "简易瞬态";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "JZJS":
                            labelJCFF.Text = "加载减速";
                            comboBoxBgff.Enabled = true;
                            break;
                        case "ZYJS":
                            labelJCFF.Text = "自由加速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDS":
                            labelJCFF.Text = "双怠速";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "SDSM":
                            labelJCFF.Text = "双怠速(犘)";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "LZ":
                            labelJCFF.Text = "滤纸";
                            comboBoxBgff.Enabled = false;
                            break;
                        case "无要求":
                            labelJCFF.Text = "无要求";
                            comboBoxBgff.Enabled = false;
                            break;
                        default: break;
                    }

                    labelJCCS.Text = caratwait.JCCS;
                    labelCLLX.Text = modelbj.CLLX;
                    labelCZ.Text = modelbj.CZ;
                    labelSYXZ.Text = modelbj.SYXZ;
                    labelPP.Text = modelbj.PP;
                    labelXH.Text = modelbj.XH;
                    labelDPHM.Text = modelbj.CLSBM;
                    labelFDJH.Text = modelbj.FDJHM;
                    labelFDJXH.Text = modelbj.FDJXH;
                    labelSCS.Text = modelbj.SCQY;
                    labelHDZK.Text = modelbj.HDZK;
                    labelJSSZK.Text = modelbj.JSSZK;
                    labelZZL.Text = modelbj.ZZL;
                    labelHDZZL.Text = modelbj.HDZZL;
                    labelZBZL.Text = modelbj.ZBZL;
                    labelJZZL.Text = modelbj.JZZL;
                    labelFDJPL.Text = modelbj.FDJPL;
                    labelRLZL.Text = modelbj.RLZL;
                    labelEDGL.Text = modelbj.EDGL;
                    labelEDZS.Text = modelbj.EDZS;
                    labelDPXS.Text = modelbj.DPFS;
                    labelCHZZ.Text = modelbj.CHZZ;
                    labelBSQXS.Text = modelbj.BSQXS;
                    labelDWS.Text = modelbj.DWS;
                    labelGYFS.Text = modelbj.GYFS;
                    labelJQFS.Text = modelbj.JQFS;
                    labelQGS.Text = modelbj.QGS;
                    labelQDXS.Text = modelbj.QDXS;
                    labelDLSP.Text = modelbj.DLSP;
                    //labelSRL.Text = modelbj.SFSRL;
                    labelJHZZ.Text = modelbj.JHZZ;
                    labelDLY.Text = caratwait.DLY;
                    labelCJTS.Text = "可以参检";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style">0-按号牌查找，1-按检验流水号查找</param>
        void searchPlate(int style)
        {
            string daijian_bjclpz = textBoxPlateAtWait.Text.Trim();
           
            if (daijian_bjclpz == "")
            {
                MessageBox.Show("请输入车牌号.", "系统提示");
            }
            else
            {
                ref_WaitCar();
                if (style==1)
                {
                    if (daijian_bjclpz.Length > 19)
                        daijian_bjclpz = daijian_bjclpz.Substring(0, 19);
                    for (int i = 0; i < dataGrid_waitcar.Rows.Count; i++)
                    {
                        if (dataGrid_waitcar.Rows[i].Cells["检测编号"].Value.ToString().Trim().Contains(daijian_bjclpz))
                        {
                            dataGrid_waitcar.Rows[i].Selected = true;
                            //foreach (DataGridViewRow dr in dataGrid_waitcar.SelectedRows)
                            //{
                            //    foreach (DataGridViewCell drcellselected in dr.Cells)
                            //    {
                            //        drcellselected.Selected = false;

                            //    }
                            //}
                            //foreach (DataGridViewCell drcell in dataGrid_waitcar.Rows[i].Cells)
                            //{
                            //    drcell.Selected = true;
                            //}
                            //dataGrid_waitcar.FirstDisplayedScrollingRowIndex = i;
                            //dataGrid_waitcar.Visible=
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dataGrid_waitcar.Rows.Count; i++)
                    {
                        if (dataGrid_waitcar.Rows[i].Cells["车牌号"].Value.ToString().Trim().Contains(daijian_bjclpz))
                        {
                            dataGrid_waitcar.Rows[i].Selected = true;
                            //foreach (DataGridViewRow dr in dataGrid_waitcar.SelectedRows)
                            //{
                            //    foreach (DataGridViewCell drcellselected in dr.Cells)
                            //    {
                            //        drcellselected.Selected = false;

                            //    }
                            //}
                            //foreach (DataGridViewCell drcell in dataGrid_waitcar.Rows[i].Cells)
                            //{
                            //    drcell.Selected = true;
                            //}
                            //dataGrid_waitcar.FirstDisplayedScrollingRowIndex = i;
                            //dataGrid_waitcar.Visible=
                            return;
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            searchPlate(1);
        }

        private void textBoxPlateAtWait_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxPlateAtWait.Text = textBoxPlateAtWait.Text.ToUpper();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                wxbj = "";
                wxcd = "";
                wxsj = "";
                wxfy = "";
                if (mainPanel.NetMode==mainPanel.WGNETMODE&&mainPanel.isNetUsed)
                {
                    if (int.Parse(carbj.JCCS) > 1)
                    {
                        wxbj = textBoxWXBJ.Text;
                        wxcd = textBoxWXCD.Text;
                        wxsj = dateTimePickerWXSJ.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        wxfy = textBoxWXFY.Text;
                        if (wxbj == "" || wxcd == "" || wxfy == "")
                        {
                            MessageBox.Show("复检车辆请录入维修信息", "系统提示!");
                            return;
                        }
                    }
                }
                if(mainPanel.NetMode==mainPanel.JINGHUANETMODE&&mainPanel.jhwebinf.area=="金华"&&mainPanel.isNetUsed&&mainPanel.equipconfig.Ydjifpz)
                //if ( mainPanel.equipconfig.Ydjifpz)
                {
                    if (!mainPanel.check_jh_ydjzj())
                    {
                        MessageBox.Show("自检-烟度计项目要求每半天进行校准，上次自检时间为"+mainPanel.jh_ydj_zjtime.ToString("yyyy-MM-dd HH:mm:ss")+"，请先进行自检", "系统提示!");
                        return;
                    }
                }
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                {
                    carbj.JSY = comboBoxJGY.Text;
                    carbj.CZY = mainPanel.nowUser.userName;
                }
                else
                {
                    if (comboBoxJGY.Text == "")
                    {
                        MessageBox.Show("请选择驾控员", "系统提示!");
                        comboBoxJGY.Capture = true;
                        return;
                    }
                    else
                    {
                        carbj.CZY = mainPanel.nowUser.userName;
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                        {
                            if (comboBoxCzy.Text == "")
                            {
                                MessageBox.Show("请选择操作员", "系统提示!");
                                comboBoxCzy.Capture = true;
                                return;
                            }
                            carbj.CZY = comboBoxCzy.Text;
                            ahOperatorID = mainPanel.syncinf.operatorlist[comboBoxCzy.SelectedIndex].operatorID;
                            ahDriverID = mainPanel.syncinf.leadDriverlist[comboBoxJGY.SelectedIndex].driverID;
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                        {
                            if (comboBoxCzy.Text == "")
                            {
                                MessageBox.Show("请选择操作员", "系统提示!");
                                comboBoxCzy.Capture = true;
                                return;
                            }
                            carbj.CZY = comboBoxCzy.Text;
                            hhzOperatorID = mainPanel.hhzpersonlist[comboBoxCzy.SelectedIndex].testpersonno;
                            hhzDriverID = mainPanel.hhzpersonlist[comboBoxJGY.SelectedIndex].testpersonno;
                        }
                        carbj.JSY = comboBoxJGY.Text;

                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NEUSOFTNETMODE && mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                        {
                            if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT)
                            {
                                mainPanel.nowUser.ycyuserName = comboBoxJGY.Text;
                                //mainPanel.nowUser.ycyuserPassword = (mainPanel.logininfcontrol.getStaffByName(mainPanel.nowUser.ycyuserName)).Rows[0]["PASSWORD"].ToString();
                                mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                string loginresult = mainPanel.neusoftsocket.loginUserYn(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", mainPanel.nowUser.ycyuserName);
                                if (loginresult != "3")
                                {
                                    switch (loginresult)
                                    {
                                        case "0": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "1": MessageBox.Show("该用户无此操作权限", "警告"); return; break;
                                        case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); return; break;
                                        case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); return; break;
                                        case "9": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); return; break;
                                        case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); return; break;
                                        case "-1": MessageBox.Show("服务器故障", "警告"); return; break;
                                        default: break;
                                    }
                                    return;
                                }
                            }
                            else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_FJS||mainPanel.neusoftsocketinf.AREA==mainPanel.NEU_V202)
                            {
                                mainPanel.nowUser.ycyuserName = comboBoxJGY.Text;
                                mainPanel.nowUser.ycyuserPassword = (mainPanel.logininfcontrol.getStaffByName(mainPanel.nowUser.ycyuserName)).Rows[0]["PASSWORD"].ToString();
                                mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                string loginresult = mainPanel.neusoftsocket.loginUserFj(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", mainPanel.nowUser.ycyuserName, mainPanel.nowUser.ycyuserPassword);
                                if (loginresult != "3")
                                {
                                    switch (loginresult)
                                    {
                                        case "0": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "1": MessageBox.Show("该用户无此操作权限", "警告"); return; break;
                                        case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); return; break;
                                        case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); return; break;
                                        case "9": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); return; break;
                                        case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); return; break;
                                        case "-1": MessageBox.Show("服务器故障", "警告"); return; break;
                                        default: break;
                                    }
                                    return;
                                }
                            }
                            else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)
                            {
                                string result, info;
                                mainPanel.nowUser.userName = comboBoxCzy.Text;
                                mainPanel.nowUser.userPassword = "111111";
                                mainPanel.nowUser.ycyuserName = comboBoxJGY.Text;
                                mainPanel.nowUser.ycyuserPassword = "111111";
                                mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                if (mainPanel.neusoftsocket.loginUserv301(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", mainPanel.nowUser.ycyuserName, mainPanel.nowUser.ycyuserPassword, out result, out info))
                                {
                                    if (result != "1")
                                    {
                                            MessageBox.Show(info, "警告");
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("登录指令发送失败和没有响应", "警告"); return;
                                }
                            }
                            else
                            {

                                mainPanel.nowUser.ycyuserName = comboBoxJGY.Text;
                                mainPanel.nowUser.ycyuserPassword = (mainPanel.logininfcontrol.getStaffByName(mainPanel.nowUser.ycyuserName)).Rows[0]["PASSWORD"].ToString();
                                mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                string loginresult = mainPanel.neusoftsocket.loginUser(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", mainPanel.nowUser.ycyuserName, mainPanel.nowUser.ycyuserPassword);
                                if (loginresult != "3")
                                {
                                    switch (loginresult)
                                    {
                                        case "0": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "1": MessageBox.Show("该用户无此操作权限", "警告"); return; break;
                                        case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); return; break;
                                        case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); return; break;
                                        case "9": MessageBox.Show("该用户不存在", "警告"); return; break;
                                        case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); return; break;
                                        case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); return; break;
                                        case "-1": MessageBox.Show("服务器故障", "警告"); return; break;
                                        default: break;
                                    }
                                    return;
                                }
                            }
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
                        {
                            var findKey = "";
                            foreach (var kv in mainPanel.jsinterface.CHECK_TYPE)
                            {
                                if (kv.Value == comboBoxCheckType.Text)
                                {
                                    findKey = kv.Key;
                                    break;
                                }
                            }
                            modelbj.JCLB = findKey;
                            modelbj.QDLTQY = comboBoxQdltqy.Text;
                            modelbj.QDXS = comboBoxQdxs.Text;
                            if (checkBoxSRL.Checked)
                            {
                                modelbj.RYPH = "双燃料:" + comboBoxRLZL.Text;
                            }
                            else
                            {
                                modelbj.RYPH = "单燃料:" + carinfor.DictionaryExtensionMethodClass.GetValue(mainPanel.jsinterface.FUEL_TYPE, modelbj.RLZL, "");
                            }
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                        {
                            string code, msg;
                            Hashtable ht = new Hashtable();
                            DataTable dtinf = new DataTable();
                            if (!mainPanel.hninterface.queryTestItemInf(ht, out dtinf, out code, out msg))
                            {
                                MessageBox.Show("获取检测线项目状态时出错\r\ncode:" + code + "\r\nmsg:" + msg);
                                ini.INIIO.saveLogInf("获取检测线项目状态时出错,code" + code + ",msg:" + msg);
                                return;
                            }
                        }
                        else if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                        {
                            车辆检测状态 teststate = new 车辆检测状态();
                            teststate.JCZBH = mainPanel.stationid;
                            teststate.LINEID = mainPanel.lineid;
                            teststate.JYLSH = carLogin.carbj.JYLSH;
                            teststate.JYCS = carLogin.carbj.JCCS;
                            teststate.JCSJ = DateTime.Now;
                            teststate.CLHP = carLogin.carbj.CLHP;
                            teststate.HPZL = carLogin.carbj.HPZL;
                            teststate.ZT = "1";
                            teststate.JCFF = carLogin.carbj.JCFF;
                            teststate.JCCZY = carLogin.carbj.CZY;
                            teststate.YCY = carLogin.carbj.JSY;
                            teststate.DLY = carLogin.carbj.DLY;
                            mainPanel.logininfcontrol.Save_TestStateFirst(teststate);
                        }

                    }
                }
                bgffyy = "";
                if (comboBoxBgff.SelectedIndex > 0)
                {
                    if (carbj.JCFF == "VMAS" || carbj.JCFF == "ASM")
                    {
                        carbj.JCFF = "SDS";
                        bgffyy = comboBoxBgff.Text;
                        if (comboBoxBgff.SelectedIndex == 1)
                            carbj.BGJCFFYY = "0";
                        else if (comboBoxBgff.SelectedIndex == 2)
                            carbj.BGJCFFYY = "1";
                        else
                            carbj.BGJCFFYY = "3";
                        neusoft_idlereason = carbj.BGJCFFYY;
                    }
                    else if (carbj.JCFF == "JZJS")
                    {
                        carbj.JCFF = "ZYJS";
                        bgffyy = comboBoxBgff.Text;
                    }
                    if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.ACNETMODE)
                    {
                        carbj.BGJCFFYY = comboBoxBgff.Text;
                    }
                }
                if (carbj.JCFF != "VMAS" && carbj.JCFF != "ASM" && carbj.JCFF != "JZJS" && carbj.JCFF != "ZYJS" && carbj.JCFF != "SDS" && carbj.JCFF != "SDSM" && carbj.JCFF != "LZ")
                {
                    MessageBox.Show("该系统不提供此类检测方法", "警告");
                    return;
                }
                switch (carbj.JCFF)
                {
                    case "VMAS":
                        if (mainPanel.linemodel.VMAS != "Y")
                        {
                            MessageBox.Show("该线不能检测瞬态，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableVMAS)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前瞬态不允许检测，原因:"+mainPanel.hninterface.vmasyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "ASM":
                        if (mainPanel.linemodel.ASM != "Y")
                        {
                            MessageBox.Show("该线不能检测稳态，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableASM)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前稳态不允许检测，原因:" + mainPanel.hninterface.asmyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "SDS":
                        if (mainPanel.linemodel.SDS != "Y")
                        {
                            MessageBox.Show("该线不能检测双怠速，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableSDS)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前双怠速不允许检测，原因:" + mainPanel.hninterface.sdsyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "SDSM":
                        if (mainPanel.linemodel.SDS != "Y")
                        {
                            MessageBox.Show("该线不能检测双怠速，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableSDS)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前双怠速不允许检测，原因:" + mainPanel.hninterface.sdsyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "JZJS":
                        if (mainPanel.NetMode == mainPanel.ACNETMODE && mainPanel.isNetUsed)
                        {
                            if (int.Parse(modelbj.ZZL) >= 3500)
                            {
                                if (mainPanel.linemodel.JZJS_HEAVY != "Y")
                                {
                                    MessageBox.Show("该线未配置重柴加载减速，请重新选择上线", "警告");
                                    return;
                                }
                            }
                            else
                            {
                                if (mainPanel.linemodel.JZJS_LIGHT != "Y")
                                {
                                    MessageBox.Show("该线未配置轻柴加载减速，请重新选择上线", "警告");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (mainPanel.linemodel.JZJS_HEAVY != "Y"&&mainPanel.linemodel.JZJS_LIGHT != "Y")
                            {
                                MessageBox.Show("该线未配置加载减速，请重新选择上线", "警告");
                                return;
                            }
                        }
                        if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableLUGDOWN)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前加载减速不允许检测，原因:" + mainPanel.hninterface.lugdownyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "ZYJS":
                        if (mainPanel.linemodel.ZYJS != "Y")
                        {
                            MessageBox.Show("该线不能检测自由加速，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableZYJS)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前不透光自由加速不允许检测，原因:" + mainPanel.hninterface.zyjsyy, "警告");
                                return;
                            }
                        }
                        break;
                    case "LZ":
                        if (mainPanel.linemodel.LZ != "Y")
                        {
                            MessageBox.Show("该线不能滤纸烟度法，请重新选择上线", "警告");
                            return;
                        }
                        else if (mainPanel.NetMode == mainPanel.HNNETMODE && mainPanel.isNetUsed)
                        {
                            if (!mainPanel.hninterface.enableLZ)
                            {
                                MessageBox.Show("联网平台返回消息:该线目前滤纸不允许检测，原因:" + mainPanel.hninterface.lzyy, "警告");
                                return;
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("该系统不提供此类检测方法", "警告");
                        return;
                        break;
                }
                mainPanel.ts1 = carbj.CLHP + "(" + carbj.JCFF + ")";
                mainPanel.ts2 = "驾控员：" + carbj.JSY;
                if (mainPanel.yztm != null)
                {
                    startTest starttest = new startTest("auto");
                    starttest.TopLevel = false;
                    ((Panel)this.Parent).Controls.Add(starttest);
                    starttest.Location = new Point(mainPanel.sc_width / 2 - starttest.Width / 2, 4);
                    starttest.BringToFront();
                    starttest.Show();
                }
                else
                {
                    startTest starttest = new startTest();
                    starttest.TopLevel = false;
                    ((Panel)this.Parent).Controls.Add(starttest);
                    starttest.Location = new Point(mainPanel.sc_width / 2 - starttest.Width / 2, 4);
                    starttest.BringToFront();
                    starttest.Show();
                }
                mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                mainPanel.worklogdata.ProjectName = "操作日志";
                mainPanel.worklogdata.Stationid = mainPanel.stationid;
                mainPanel.worklogdata.Lineid = mainPanel.lineid;
                mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                mainPanel.worklogdata.Data = "发送待检车辆" + carbj.CLHP + ",驾控员:" + carbj.JSY;
                mainPanel.worklogdata.State = "成功";
                mainPanel.worklogdata.Result = "";
                mainPanel.worklogdata.Date = DateTime.Now;
                mainPanel.worklogdata.Bzsm = "";
                mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                checkTM = false;
            }
            catch
            {
 
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wxbj = textBoxWXBJ.Text;
            wxcd = textBoxWXCD.Text;
            wxsj = dateTimePickerWXSJ.Value.ToString("yyyy-MM-dd HH:mm:ss");
            wxfy = textBoxWXFY.Text;
            if (wxbj == "" || wxcd == "" || wxsj == "" || wxfy == "")
            {
                MessageBox.Show("维修信息不完整，请填写完毕后再提交");
            }
            else
            {
                iswxinfok = true;
                iswxok = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iswxinfok = false;
            iswxok = true;
            panelwx.Visible = false;
        }

        private void carLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainPanel.ts1 = mainPanel.linemodel.LINEID + "号排放检测线";
            mainPanel.ts2 = "设备待命";
            mainPanel.isStartTimerInCarlogin = false;
        }

        private void checkBoxSRL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSRL.Checked)
                comboBoxRLZL.Enabled = true;
            else
                comboBoxRLZL.Enabled = false;
        }
        public static cycarinf cycarinfdata = new cycarinf();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mainPanel.isStartTimerInCarlogin)
            {
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                {
                    try
                    {
                        tmcount++;
                        if (tmcount == 2)//闪烁代表正在扫描
                        {
                            tmcount = 0;
                            if (panelTmState.BackColor == Color.Yellow)
                                panelTmState.BackColor = Color.Lime;
                            else
                                panelTmState.BackColor = Color.Yellow;
                        }
                        string result = "";
                        string info = "";
                        string state = "";
                        string bussnessId = "";
                        string methodId = "";
                        if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                        {
                            mainPanel.xmlanalysis.ReadStateString(mainPanel.yichangInterface.getSatate(mainPanel.zkytwebinf.regcode), out result, out info, out state, out bussnessId, out methodId);
                        }
                        else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                        {
                            mainPanel.xmlanalysis.ReadStateString(mainPanel.yichangInterfaceOther.getSatate(mainPanel.zkytwebinf.regcode), out result, out info, out state, out bussnessId, out methodId);
                        }
                        else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                        {
                            
                            mainPanel.xmlanalysis.ReadDjztString(mainPanel.yichangInterfaceYnbs.getDjzt(mainPanel.zkytwebinf.regcode), out result, out info, out state, out bussnessId, out methodId);
                        }
                        if (result == "1")
                        {
                            if (state == "0")
                            {
                                buttonStart.Enabled = false;
                                labelTmState.Text = "设备开始监听";
                                return;
                            }
                            else if (state == "1")
                            {
                                mainPanel.isStartTimerInCarlogin = false;
                                buttonStart.Enabled = true;

                                string carCardNumber = "";
                                string maxWeight = "";
                                string standardWeight = "";
                                string motorRate = "";
                                string motorPower = "";
                                string speedChanger = "";
                                string fuelType = "A";
                                string airInflow = "";
                                string oilSupply = "";
                                string isSYJHQ = "";
                                string ccdjrq = "";
                                string clzl = "";
                                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                                {
                                    mainPanel.xmlanalysis.ReadCarInfoString(mainPanel.yichangInterface.getCarInfo(bussnessId, mainPanel.zkytwebinf.regcode), out result, out info, out carCardNumber, out maxWeight, out standardWeight, out motorPower, out motorRate, out speedChanger, out fuelType, out airInflow, out oilSupply, out isSYJHQ);
                                }
                                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                                {
                                    mainPanel.xmlanalysis.ReadCarInfoString(mainPanel.yichangInterfaceOther.getCarInfo(bussnessId, mainPanel.zkytwebinf.regcode), out result, out info, out carCardNumber, out maxWeight, out standardWeight, out motorPower, out motorRate, out speedChanger, out fuelType, out airInflow, out oilSupply, out isSYJHQ);
                                }
                                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                                {
                                    mainPanel.xmlanalysis.ReadDjclxxString(mainPanel.yichangInterfaceYnbs.getDjclxx(bussnessId, mainPanel.zkytwebinf.regcode), out result, out info, out carCardNumber, out maxWeight, out standardWeight, out motorPower, out motorRate, out speedChanger, out fuelType, out airInflow, out oilSupply, out isSYJHQ,out ccdjrq,out clzl);
                                }
                                if (result == "1")
                                {
                                    DateTime a, b;
                                    carbj.CLID = carCardNumber + "T" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                                    carbj.DLSJ = DateTime.Now;
                                    carbj.CLHP = carCardNumber;
                                    carbj.CPYS = "";
                                    carbj.HPZL = "";
                                    carbj.XSLC = "";
                                    string cjcpys = carbj.CPYS;
                                    string cjclph = carbj.CLHP;
                                    CARDETECTED latestRecord = logininfcontrol.getPreTestDatebyPlate(cjclph, cjcpys);
                                    if (latestRecord.CLID == "-2")//如果没有记录，则提示为初检
                                    {
                                        carbj.JCCS = "1";
                                    }
                                    else//如果有环保记录，则判定记录内容
                                    {
                                        int latestMonths = caculateMonth(latestRecord.JCSJ, DateTime.Now);//计算最近的检测记录距离此次的时间
                                        if (latestMonths > 9)//如果距离超过9个月，则认为达到检测时间
                                        {
                                            carbj.JCCS = "1";
                                            carbj.SFCJ = "初检";
                                        }
                                        else
                                        {
                                            int lastrecordjccs = 0;
                                            if (!int.TryParse(latestRecord.JCCS, out lastrecordjccs))
                                                lastrecordjccs = 0;
                                            int jccs = lastrecordjccs + 1;
                                            carbj.JCCS = jccs.ToString();
                                            carbj.SFCJ = "复检";
                                        }
                                    }
                                    carbj.JCCS = carbj.JCCS;
                                    carbj.CZY = "";
                                    carbj.JSY = "";
                                    carbj.DLY = "";
                                    carbj.JCFY = "";
                                    carbj.TEST = "";
                                    carbj.JCBGBH = "";
                                    carbj.JCGWH = "";
                                    carbj.JCZBH = "";
                                    carbj.JCRQ = DateTime.Now;
                                    carbj.BGJCFFYY = "";
                                    carbj.SFCS = "";
                                    carbj.ECRYPT = "";
                                    carbj.JYLSH = bussnessId;
                                    modelbj.CLHP = carCardNumber;
                                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                                    {
                                        DateTime tempdate = DateTime.Now;
                                        if (DateTime.TryParse(ccdjrq, out tempdate))
                                        {
                                            modelbj.ZCRQ = tempdate;
                                            modelbj.SCRQ = tempdate;
                                        }
                                        else
                                        {
                                            modelbj.ZCRQ = DateTime.Now;
                                            modelbj.SCRQ = DateTime.Now;
                                        }
                                    }
                                    else
                                    {
                                        modelbj.ZCRQ = DateTime.Now;
                                        modelbj.SCRQ = DateTime.Now;
                                    }
                                    modelbj.CLSBM = "";
                                    modelbj.CPYS = "";
                                    modelbj.HPZL = "";
                                    modelbj.CLLX = "";
                                    modelbj.CZ = "";
                                    modelbj.SYXZ = "";
                                    modelbj.PP = "";
                                    modelbj.XH = "";
                                    modelbj.FDJHM = "";
                                    modelbj.FDJXH = "";
                                    modelbj.SCQY = "";
                                    modelbj.HDZK = "";
                                    modelbj.JSSZK = "";
                                    modelbj.ZZL = maxWeight;
                                    modelbj.HDZZL = "";
                                    modelbj.ZBZL = "";//15
                                    modelbj.JZZL = standardWeight;
                                    modelbj.SCRQ = DateTime.Now;
                                    modelbj.FDJPL = "";
                                    if (fuelType == "A")
                                        modelbj.RLZL = "汽油";
                                    else if (fuelType == "B")
                                        modelbj.RLZL = "柴油";
                                    else if (fuelType == "C")
                                        modelbj.RLZL = "电";
                                    else if (fuelType == "D")
                                        modelbj.RLZL = "混合油";
                                    else if (fuelType == "E")
                                        modelbj.RLZL = "天然气";
                                    else if (fuelType == "F")
                                        modelbj.RLZL = "液化石油气";
                                    else if (fuelType == "L")
                                        modelbj.RLZL = "甲醇";
                                    else if (fuelType == "M")
                                        modelbj.RLZL = "乙醇";
                                    else if (fuelType == "N")
                                        modelbj.RLZL = "太阳能";
                                    else if (fuelType == "O")
                                        modelbj.RLZL = "混合动力";
                                    else if (fuelType == "Y")
                                        modelbj.RLZL = "无";
                                    else
                                        modelbj.RLZL = "其他";
                                    modelbj.EDGL = motorPower;
                                    modelbj.EDZS = motorRate;
                                    switch (speedChanger)
                                    {
                                        case "01": modelbj.BSQXS = "手动"; break;
                                        case "02": modelbj.BSQXS = "自动"; break;
                                        default: modelbj.BSQXS = ""; break;
                                    }
                                    modelbj.DWS = "";
                                    switch (oilSupply)
                                    {
                                        case "01": modelbj.GYFS = "化油器"; break;
                                        case "02": modelbj.GYFS = "化油器改造"; break;
                                        case "03": modelbj.GYFS = "开环电喷"; break;
                                        case "04": modelbj.GYFS = "闭环电喷"; break;
                                        default: modelbj.GYFS = ""; break;
                                    }
                                    switch (airInflow)
                                    {
                                        case "01": modelbj.JQFS = "涡轮增压"; break;
                                        case "02": modelbj.JQFS = "自然吸气"; break;
                                        case "03": modelbj.JQFS = "机械增压"; break;
                                        default: modelbj.JQFS = ""; break;
                                    }
                                    modelbj.DPFS = "";//25
                                    modelbj.QGS = "";
                                    modelbj.QDXS = "";
                                    modelbj.CHZZ = "";
                                    modelbj.DLSP = "";
                                    modelbj.SFSRL = "";
                                    switch (isSYJHQ)
                                    {
                                        case "0": modelbj.JHZZ = "无"; break;
                                        case "1": modelbj.JHZZ = "有"; break;
                                        default: modelbj.JHZZ = ""; break;
                                    }
                                    modelbj.OBD = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.LXDH = "";
                                    modelbj.CZDZ = "";
                                    modelbj.JCFS = "";
                                    modelbj.JCLB = "";
                                    modelbj.CLZL = clzl;
                                    modelbj.SSXQ = "";
                                    modelbj.SFWDZR = "";
                                    modelbj.SFYQBF = "";
                                    modelbj.DKGYYB = "";
                                    modelbj.FDJSCQY = "";
                                    modelbj.QDLTQY = "";
                                    modelbj.RYPH = "";
                                    modelbj.ZXBZ = "";
                                    modelbj.CSYS = "";
                                    switch (methodId)
                                    {
                                        case "DB": carbj.JCFF = "SDS"; break;
                                        case "IG": carbj.JCFF = "VMAS"; break;
                                        case "LD": carbj.JCFF = "JZJS"; break;
                                        case "LZ": carbj.JCFF = "LZ"; break;
                                        case "TG": carbj.JCFF = "ZYJS"; break;
                                        case "WT": carbj.JCFF = "ASM"; break;
                                        case "MD": carbj.JCFF = "MD"; break;
                                        default: carbj.JCFF = methodId; break;
                                    }

                                    labelTmState.Text = carbj.CLHP;
                                    ref_carInf(modelbj, carbj);
                                    buttonStart.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("获取车辆信息失败\r\n" + info);
                                }
                            }
                            else if (state == "-1")
                            {
                                mainPanel.isStartTimerInCarlogin = false;
                                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterface.sendMessage("", mainPanel.zkytwebinf.regcode, "02", ""), out result, out info);
                                }
                                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceOther.sendMessage("", mainPanel.zkytwebinf.regcode, "02", ""), out result, out info);
                                }
                                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceYnbs.xxtz("", mainPanel.zkytwebinf.regcode, "02", ""), out result, out info);
                                }
                                if (result == "1")
                                {
                                    MessageBox.Show("设备不正常，请关闭系统");
                                    buttonStartSm.Enabled = false;
                                    buttonStopListen.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show(info);
                                }
                            }
                        }
                        else
                        {
                            labelTmState.Text = info;
                        }
                    }
                    catch(Exception er)
                    {
                        ini.INIIO.saveLogInf("[获取车辆信息发生异常]：" + er.Message);
                    }
                }
                if (mainPanel.NetMode == mainPanel.CYNETMODE && mainPanel.isNetUsed)
                {
                    if (System.IO.File.Exists(@"C:\jcdatatxt\carinfo.ini"))
                    {
                        Thread.Sleep(500);//wait for half a second to make sure car infomation finish writting
                        cycarinfdata = carini.getCyCarIni();
                        ini.INIIO.saveLogInf("读取到车辆信息：" + cycarinfdata.车辆牌照号);
                        labelTmState.Text = "找到车辆" + cycarinfdata.车辆牌照号;
                        DateTime a, b;
                        carbj.CLID = cycarinfdata.车辆ID;//联网时，用外观检验号做车辆ID号
                        carbj.DLSJ = DateTime.Now;
                        carbj.CLHP = cycarinfdata.车辆牌照号;
                        carbj.CPYS = cycarinfdata.车牌颜色;
                        carbj.HPZL = "";
                        carbj.XSLC = "";
                        carbj.JCCS = cycarinfdata.检测次数.ToString();
                        carbj.CZY = "";
                        carbj.JSY = "";
                        carbj.DLY = "";
                        carbj.JCFY = "";
                        carbj.TEST = "";
                        carbj.JCBGBH = "";
                        carbj.JCGWH = "";
                        carbj.JCZBH = "";
                        carbj.JCRQ = DateTime.Now;
                        carbj.BGJCFFYY = "";
                        carbj.SFCS = "";
                        carbj.ECRYPT = "";
                        carbj.JYLSH = cycarinfdata.检测流水号;
                        carbj.SFCJ = "";
                        //CARINF model = new CARINF();
                        modelbj.CLHP = cycarinfdata.车辆牌照号;
                        DateTime.TryParse(cycarinfdata.初次登记日期, out a);
                        if (a != null)
                            modelbj.ZCRQ = a;
                        else
                            modelbj.ZCRQ = DateTime.Today;
                        modelbj.CLSBM = "";

                        modelbj.CPYS = cycarinfdata.车牌颜色;
                        modelbj.HPZL = "";
                        modelbj.CLLX = cycarinfdata.车辆类别 + "_" + mainPanel.logininfcontrol.getComBoBoxItemsNAME("车辆类型", cycarinfdata.车辆类别);

                        modelbj.CZ = cycarinfdata.车主;
                        switch (cycarinfdata.使用性质)
                        {
                            case "3": modelbj.SYXZ = "非营运"; break;
                            case "A": modelbj.SYXZ = "公路客运"; break;
                            case "B": modelbj.SYXZ = "公交客运"; break;
                            case "C": modelbj.SYXZ = "出租客运"; break;
                            case "D": modelbj.SYXZ = "旅游客运"; break;
                            case "E": modelbj.SYXZ = "货运"; break;
                            case "F": modelbj.SYXZ = "租赁"; break;
                            case "G": modelbj.SYXZ = "警用"; break;
                            case "H": modelbj.SYXZ = "消防"; break;
                            case "I": modelbj.SYXZ = "救护"; break;
                            case "J": modelbj.SYXZ = "工程抢险"; break;
                            case "K": modelbj.SYXZ = "营转非"; break;
                            case "L": modelbj.SYXZ = "出租转非"; break;
                            case "M": modelbj.SYXZ = "其他"; break;
                        }
                        modelbj.PP = cycarinfdata.厂牌名称;//5
                        modelbj.XH = cycarinfdata.厂牌型号;
                        modelbj.FDJHM = "";
                        modelbj.FDJXH = cycarinfdata.发动机型号;
                        modelbj.SCQY = "";//10
                        modelbj.HDZK = cycarinfdata.核准载客.ToString();
                        modelbj.JSSZK = "";
                        modelbj.ZZL = cycarinfdata.整车质量.ToString();
                        modelbj.HDZZL = "";
                        modelbj.ZBZL = cycarinfdata.整备质量.ToString();
                        modelbj.JZZL = cycarinfdata.基准质量.ToString();

                        DateTime.TryParse(cycarinfdata.生产日期, out b);
                        if (a != null)
                            modelbj.SCRQ = b;
                        else
                            modelbj.SCRQ = DateTime.Today;
                        modelbj.FDJPL = cycarinfdata.发动机排量;
                        switch (cycarinfdata.燃料种类)
                        {
                            case "A": modelbj.RLZL = "汽油"; break;
                            case "B": modelbj.RLZL = "柴油"; break;
                            case "C": modelbj.RLZL = "电"; break;
                            case "D": modelbj.RLZL = "混合油"; break;
                            case "E": modelbj.RLZL = "天然气"; break;
                            case "F": modelbj.RLZL = "液化石油气"; break;
                            case "L": modelbj.RLZL = "甲醉"; break;
                            case "M": modelbj.RLZL = "乙醇"; break;
                            case "N": modelbj.RLZL = "太阳能"; break;
                            case "O": modelbj.RLZL = "混合动力"; break;
                            case "X": modelbj.RLZL = "双燃料"; break;
                            case "Y": modelbj.RLZL = "无"; break;
                            case "Z": modelbj.RLZL = "其他"; break;
                            default: modelbj.RLZL = ""; break;
                        }
                        modelbj.EDGL = cycarinfdata.额定功率.ToString();
                        modelbj.EDZS = cycarinfdata.额定转速.ToString();
                        modelbj.BSQXS = "";
                        switch (cycarinfdata.变速箱)
                        {
                            case "0": modelbj.BSQXS = "手动档"; break;
                            case "1": modelbj.BSQXS = "自动档"; break;
                            case "2": modelbj.BSQXS = "手自一体"; break;
                        }
                        modelbj.DWS = "";
                        modelbj.GYFS = "";//25
                        switch (cycarinfdata.供油方式)
                        {
                            case "0": modelbj.GYFS = "化油器"; break;
                            case "1": modelbj.GYFS = "开环电喷"; break;
                            case "2": modelbj.GYFS = "闭环电喷"; break;
                            case "3": modelbj.GYFS = "喷油泵"; break;
                        }
                        modelbj.DPFS = "";
                        modelbj.JQFS = "";
                        switch (cycarinfdata.进气方式)
                        {
                            case "0": modelbj.JQFS = "涡轮增压"; break;
                            case "1": modelbj.JQFS = "机械增压"; break;
                            case "2": modelbj.JQFS = "自然进气"; break;
                        }
                        modelbj.QGS = "";
                        modelbj.QDXS = "";
                        switch (cycarinfdata.驱动形式)
                        {
                            case "0": modelbj.QDXS = "前驱"; break;
                            case "1": modelbj.QDXS = "后驱"; break;
                            case "2": modelbj.QDXS = "全时四驱"; break;
                            case "3": modelbj.QDXS = "全时四驱"; break;
                        }
                        modelbj.CHZZ = "";//30
                        modelbj.DLSP = "";
                        modelbj.SFSRL = "";
                        if (cycarinfdata.是否有三元催化转化器 == "1" || cycarinfdata.是否有排气后处理装置 == "1")//有三元催化且闭环电喷
                        {
                            modelbj.JHZZ = "有";
                        }
                        else
                        {
                            modelbj.JHZZ = "无";
                        }
                        modelbj.OBD = "";
                        modelbj.DKGYYB = "";
                        modelbj.LXDH = cycarinfdata.电话;
                        modelbj.CZDZ = "";
                        modelbj.JCFS = "";
                        modelbj.JCLB = "";
                        switch (cycarinfdata.检测类别)
                        {
                            case "3": modelbj.JCLB = "新车检测"; break;
                            case "00": modelbj.JCLB = "在用车检测"; break;
                            case "01": modelbj.JCLB = "委托检测"; break;
                            case "02": modelbj.JCLB = "转入检测"; break;
                            case "03": modelbj.JCLB = "延期检测"; break;
                            case "04": modelbj.JCLB = "变更检测"; break;
                            case "05": modelbj.JCLB = "春运检测"; break;
                            case "06": modelbj.JCLB = "技术检测"; break;
                            case "07": modelbj.JCLB = "临时检测"; break;
                            case "08": modelbj.JCLB = "其他检测"; break;
                        }
                        modelbj.CLZL = "";
                        modelbj.SSXQ = "";
                        modelbj.SFWDZR = "";
                        modelbj.SFYQBF = "";
                        modelbj.DKGYYB = "";
                        modelbj.FDJSCQY = "";
                        modelbj.QDLTQY = "";
                        modelbj.RYPH = "";

                        switch (cycarinfdata.检测方法)
                        {
                            case "G": carbj.JCFF = "怠速"; break;
                            case "H": carbj.JCFF = "急加速"; break;
                            case "C": carbj.JCFF = "瞬态"; break;
                            case "B": carbj.JCFF = "VMAS"; break;
                            case "Z": carbj.JCFF = "SDS"; break;
                            case "F": carbj.JCFF = "JZJS"; break;
                            case "E": carbj.JCFF = "ZYJS"; break;
                            case "D": carbj.JCFF = "LZ"; break;
                            case "A": carbj.JCFF = "ASM"; break;
                        }

                        limitdatainf.SmokeRb = "";
                        ref_carInf(modelbj, carbj);
                        buttonStart.Enabled = true;
                        timer1.Stop();
                    }
                }
                if (mainPanel.yztm != null && checkTM)
                {
                    tmcount++;
                    if (tmcount == 10)//闪烁代表正在扫描
                    {
                        tmcount = 0;
                        if (panelTmState.BackColor == Color.Yellow)
                            panelTmState.BackColor = Color.Lime;
                        else
                            panelTmState.BackColor = Color.Yellow;
                    }
                    if (mainPanel.yztm.iseffective)
                    {
                        mainPanel.yztm.iseffective = false;
                        string tmid = mainPanel.yztm.tmcontent.Trim();
                        ini.INIIO.saveLogInf("接收到条码器内容：" + tmid + "length:" + tmid.Length.ToString());
                        if (tmid.Length == 8)
                        {
                            ini.INIIO.saveLogInf("接收到车辆信息条码器内容");
                            if (!mainPanel.atsacontrol.checkCarInfIsAlive(tmid))
                            {
                                ini.INIIO.saveLogInf("在条码数据库中未找到信息");
                                labelTmState.Text = "在条码数据库中未找到信息";
                                return;
                            }
                            string platenumber = mainPanel.atsacontrol.getCarInfbyPlate(tmid);
                            ref_WaitCar();
                            Application.DoEvents();
                            bool findsuccess = false;
                            for (int i = 0; i < dataGrid_waitcar.Rows.Count; i++)
                            {
                                if (dataGrid_waitcar.Rows[i].Cells["车牌号"].Value.ToString().Trim().Contains(platenumber))
                                {
                                    labelTmState.Text = "找到车辆" + platenumber;
                                    ini.INIIO.saveLogInf("找到该车信息");
                                    findsuccess = true;
                                    dataGrid_waitcar.Rows[i].Selected = true;
                                    Application.DoEvents();
                                    isCarOK = true;
                                    isDriverOK = false;
                                    mainPanel.ts1 = carbj.CLHP + "(" + carbj.JCFF + ")";
                                    mainPanel.ts2 = "引车员";
                                    /*if (isDriverOK == true)
                                    {
                                        checkTM = false;
                                        isCarOK = false;
                                        isDriverOK = false;
                                        Thread.Sleep(2000);
                                        try
                                        {
                                            carbj.JSY = comboBoxJGY.Text;
                                            carbj.CZY = mainPanel.nowUser.userName;
                                            if (comboBoxBgff.SelectedIndex > 0)
                                            {
                                                if (carbj.JCFF == "VMAS" || carbj.JCFF == "ASM")
                                                    carbj.JCFF = "SDS";
                                                else if (carbj.JCFF == "JZJS")
                                                    carbj.JCFF = "ZYJS";
                                            }
                                            startTest starttest = new startTest("auto");
                                            starttest.TopLevel = false;
                                            ((Panel)this.Parent).Controls.Add(starttest);
                                            starttest.Location = new Point(mainPanel.sc_width / 2 - starttest.Width / 2, 4);
                                            starttest.BringToFront();
                                            starttest.Show();
                                            mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                                            mainPanel.worklogdata.ProjectName = "操作日志";
                                            mainPanel.worklogdata.Stationid = mainPanel.stationid;
                                            mainPanel.worklogdata.Lineid = mainPanel.lineid;
                                            mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                                            mainPanel.worklogdata.Data = "发送待检车辆" + carbj.CLHP + ",驾控员:" + carbj.JSY;
                                            mainPanel.worklogdata.State = "成功";
                                            mainPanel.worklogdata.Result = "";
                                            mainPanel.worklogdata.Date = DateTime.Now;
                                            mainPanel.worklogdata.Bzsm = "";
                                            mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                                        }
                                        catch
                                        {

                                        }
                                    }*/
                                    break;
                                }
                            }
                            if (!findsuccess)
                            {
                                labelTmState.Text = "未找到车辆" + platenumber;
                                ini.INIIO.saveLogInf("未找到该车待检信息");
                                mainPanel.ts1 = "未找到该车待检信息";
                                //Thread.Sleep(2000);
                                //mainPanel.ts1 =mainPanel.linemodel.LINEID + "号排放检测线";
                                isCarOK = false;
                            }
                        }
                        else if (tmid.Length == 6 && isCarOK)
                        {
                            ini.INIIO.saveLogInf("接收到引车员条码器内容");
                            string username = mainPanel.logininfcontrol.getNAMEByID(tmid);
                            if (username != "")
                            {
                                //if (comboBoxJGY.Items.Contains(username))
                                //{
                                ini.INIIO.saveLogInf("找到该引车员信息");
                                isDriverOK = true;
                                mainPanel.ts2 = "引车员:" + username;
                                if (isCarOK)
                                {
                                    checkTM = false;
                                    isCarOK = false;
                                    isDriverOK = false;
                                    Thread.Sleep(2000);
                                    try
                                    {
                                        //comboBoxJGY.Text = username;
                                        //Application.DoEvents();
                                        carbj.JSY = username;
                                        carbj.CZY = mainPanel.nowUser.userName;
                                        /*if (comboBoxBgff.SelectedIndex > 0)
                                        {
                                            if (carbj.JCFF == "VMAS" || carbj.JCFF == "ASM")
                                                carbj.JCFF = "SDS";
                                            else if (carbj.JCFF == "JZJS")
                                                carbj.JCFF = "ZYJS";
                                        }*/
                                        startTest starttest = new startTest("auto");
                                        starttest.TopLevel = false;
                                        ((Panel)this.Parent).Controls.Add(starttest);
                                        starttest.Location = new Point(mainPanel.sc_width / 2 - starttest.Width / 2, 4);
                                        starttest.BringToFront();
                                        starttest.Show();
                                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                                        mainPanel.worklogdata.ProjectName = "操作日志";
                                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                                        mainPanel.worklogdata.Data = "发送待检车辆" + carbj.CLHP + ",驾控员:" + carbj.JSY;
                                        mainPanel.worklogdata.State = "成功";
                                        mainPanel.worklogdata.Result = "";
                                        mainPanel.worklogdata.Date = DateTime.Now;
                                        mainPanel.worklogdata.Bzsm = "";
                                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                                    }
                                    catch
                                    {

                                    }
                                }
                                /*}
                                else
                                {
                                    ini.INIIO.saveLogInf("未找到该引车员信息");
                                    mainPanel.ts2 = "未找到该引车员信息";
                                    //Thread.Sleep(2000);
                                    //mainPanel.ts2 = "设备待命";
                                    isDriverOK = false;
                                }*/
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("未找到该引车员信息");
                                mainPanel.ts2 = "未找到该引车员信息";
                                //Thread.Sleep(2000);
                                //mainPanel.ts2 = "设备待命";
                                isDriverOK = false;
                            }
                        }
                        else if (tmid.Length == 4 && isCarOK)
                        {
                            ini.INIIO.saveLogInf("接收到更改检测方法条码器内容");
                            string changeffid = tmid;
                            if ((carbj.JCFF == "VMAS" || carbj.JCFF == "ASM") && isCarOK)
                            {
                                if (changeffid == "0001")
                                {
                                    //comboBoxBgff.SelectedIndex = 1;
                                    mainPanel.ts1 = carbj.CLHP + "(SDS)";
                                }
                                else if (changeffid == "0002")
                                {
                                    //comboBoxBgff.SelectedIndex = 2;
                                    mainPanel.ts1 = carbj.CLHP + "(SDS)";
                                }
                                else if (changeffid == "0003")
                                {
                                    //comboBoxBgff.SelectedIndex = 3;
                                    mainPanel.ts1 = carbj.CLHP + "(SDS)";
                                }
                                else if (changeffid == "0004")
                                {
                                    //comboBoxBgff.SelectedIndex = 4;
                                    mainPanel.ts1 = carbj.CLHP + "(SDS)";
                                }
                                else
                                {
                                    //comboBoxBgff.SelectedIndex = 0;
                                    mainPanel.ts1 = carbj.CLHP + "(" + carbj.JCFF + ")";
                                }
                                carbj.JCFF = "SDS";
                            }
                            else if (carbj.JCFF == "JZJS" && isCarOK)
                            {
                                if (changeffid == "0001")
                                {
                                    //comboBoxBgff.SelectedIndex = 1;
                                    mainPanel.ts1 = carbj.CLHP + "(BTG)";
                                }
                                else if (changeffid == "0002")
                                {
                                    //comboBoxBgff.SelectedIndex = 2;
                                    mainPanel.ts1 = carbj.CLHP + "(BTG)";
                                }
                                else if (changeffid == "0003")
                                {
                                    //comboBoxBgff.SelectedIndex = 3;
                                    mainPanel.ts1 = carbj.CLHP + "(BTG)";
                                }
                                else if (changeffid == "0004")
                                {
                                    //comboBoxBgff.SelectedIndex = 4;
                                    mainPanel.ts1 = carbj.CLHP + "(BTG)";
                                }
                                else
                                {
                                    //comboBoxBgff.SelectedIndex = 0;
                                    mainPanel.ts1 = carbj.CLHP + "(" + carbj.JCFF + ")";
                                }
                                carbj.JCFF = "ZYJS";
                            }
                        }
                    }
                }
            }
        }

       // public static bool mainPanel.isStartTimerInCarlogin = true;
        private void buttonStartSm_Click(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
            {
                if (!mainPanel.isStartTimerInCarlogin)
                {
                    clear_carinf();
                    string result="", info="";
                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                    {
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterface.sendMessage("", mainPanel.zkytwebinf.regcode, "07", ""), out result, out info);
                    }
                    else if(mainPanel.zkytwebinf.add==mainPanel.ZKYTAREA_OTHER)
                    {
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceOther.sendMessage("", mainPanel.zkytwebinf.regcode, "07", ""), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                    {
                        string accesstoken = "";
                        mainPanel.xmlanalysis.ReadAccessTokenString(mainPanel.yichangInterfaceYnbs.getAccessToken(mainPanel.zkytwebinf.lineID), out result, out info, out accesstoken);
                        if (result == "0")
                        {
                            MessageBox.Show("调取访问令牌失败:" + info);
                        }
                        else
                        {
                            mainPanel.zkytwebinf.regcode = accesstoken;
                        }
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceYnbs.xxtz("", mainPanel.zkytwebinf.regcode, "07", ""), out result, out info);
                    }
                    if (result == "1")
                    {
                        mainPanel.isStartTimerInCarlogin = true;
                        labelTmState.Text="设备开始监听";
                        //buttonStartSm.Enabled = false;
                        //buttonStopListen.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(info);
                    }
                }
            }
            else
            {
                mainPanel.isStartTimerInCarlogin = true;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                int nhcode, nhexpcode;
                string nhmsg, nhexpmsg;
                string platenumber =textBoxNhPlate.Text;
                string platetype = textBoxNhPlateType.Text;
                string vin = "";
                //CARATWAIT carwait = logininfcontrol.getCarInfatWaitList(dataGrid_waitcar.SelectedRows[0].Cells["车牌号"].Value.ToString());
                vehicleinfo = mainPanel.nhinterface.GetVehicleInfo(platenumber, platetype, vin, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);

                if (nhcode == 0 && nhexpcode == 0)
                {
                    if (vehicleinfo != null)
                    {
                        textBoxJclsh.Text = vehicleinfo.TestRunningNumber;
                    }
                    else
                    {
                        textBoxJclsh.Text = "未查询到车辆信息";
                    }
                }
                else
                {
                    textBoxJclsh.Text = "未查询到车辆信息";
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                if (textBoxJclsh.Text != "" && textBoxJclsh.Text != "未查询到车辆信息")
                {
                    int nhcode, nhexpcode;
                    string nhmsg, nhexpmsg;
                    if(mainPanel.nhinterface.SendStopTest(textBoxJclsh.Text,out nhcode,out nhmsg,out nhexpcode,out nhexpmsg))
                    {
                        textBoxStatus.Text = "终止成功";
                    }
                    else
                    {
                        textBoxStatus.Text = "终止失败:nhmsg"+nhmsg+";"+"expmsg:"+nhexpmsg;
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                if (textBoxJclsh.Text != "" && textBoxJclsh.Text != "未查询到车辆信息")
                {
                    int nhcode, nhexpcode;
                    string nhmsg, nhexpmsg;
                    if (mainPanel.nhinterface.SendVehicleInspectionCancel(textBoxJclsh.Text, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg))
                    {
                        textBoxStatus.Text = "删除成功";
                        mainPanel.logininfcontrol.deleteCarAtWaitbyPlate(textBoxNhPlate.Text);
                    }
                    else
                    {
                        textBoxStatus.Text = "删除失败:nhmsg" + nhmsg + ";" + "expmsg:" + nhexpmsg;
                    }

                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string code, msg;
            Hashtable ht = new Hashtable();
            ht.Add("hphm", textBoxXHNPLATE.Text);
            ht.Add("hpzl",mainPanel.hninterface.RHN_HPZL.GetValue(comboBoxExHNHPZL.Text,""));
            ht.Add("clsbdh",textBoxXHPVIN.Text);
            ht.Add("jczl", comboBoxExHNJYZL.Text);
            DataTable dtinf = new DataTable();
            if (mainPanel.hninterface.queryVehicleInf(ht, out dtinf, out code, out msg))
            {
                if(dtinf!=null)
                {
                    try
                    {
                        DateTime a, b;
                        carbj.CLID = dtinf.Rows[0]["XH"].ToString();//联网时，用外观检验号做车辆ID号
                        carbj.DLSJ = DateTime.Now;
                        carbj.CLHP = dtinf.Rows[0]["HPHM"].ToString();
                        carbj.CPYS = "";
                        carbj.HPZL = mainPanel.hninterface.HN_HPZL.GetValue(dtinf.Rows[0]["HPZL"].ToString(), "");
                        carbj.XSLC = "";
                        carbj.JCCS = "";
                        carbj.CZY = "";
                        carbj.JSY = "";
                        carbj.DLY = "";
                        carbj.JCFY = "";
                        carbj.TEST = "";
                        carbj.JCBGBH = "";
                        carbj.JCGWH = "";
                        carbj.JCZBH = "";
                        carbj.JCRQ = DateTime.Now;
                        carbj.BGJCFFYY = "";
                        carbj.SFCS = "";
                        carbj.ECRYPT = "";
                        carbj.JYLSH = "";
                        carbj.SFCJ = "";
                        //CARINF model = new CARINF();
                        modelbj.CLHP = dtinf.Rows[0]["HPHM"].ToString();//1
                        DateTime.TryParse(dtinf.Rows[0]["CCDJRQ"].ToString(), out a);
                        if (a != null)
                            modelbj.ZCRQ = a;
                        else
                            modelbj.ZCRQ = DateTime.Today;
                        modelbj.CLSBM = dtinf.Rows[0]["CLSBDH"].ToString();

                        modelbj.CPYS = "";
                        modelbj.HPZL = mainPanel.hninterface.HN_HPZL.GetValue(dtinf.Rows[0]["HPZL"].ToString(), "");
                        modelbj.CLLX = mainPanel.logininfcontrol.getComBoBoxItemsNAME("车辆类型", dtinf.Rows[0]["CLLX"].ToString());
                        modelbj.CZ = dtinf.Rows[0]["SYR"].ToString();
                        modelbj.SYXZ = mainPanel.hninterface.HN_SYXZ.GetValue(dtinf.Rows[0]["SYXZ"].ToString(), "");
                        modelbj.PP = dtinf.Rows[0]["CLXH"].ToString();//5
                        modelbj.XH = dtinf.Rows[0]["CLXH"].ToString();
                        modelbj.FDJHM = dtinf.Rows[0]["FDJH"].ToString();
                        modelbj.FDJXH = dtinf.Rows[0]["FDJXH"].ToString();
                        modelbj.SCQY = "";//10
                        modelbj.HDZK = "2";
                        modelbj.JSSZK = "";
                        modelbj.ZZL = dtinf.Rows[0]["ZZL"].ToString();
                        modelbj.HDZZL = "";
                        modelbj.ZBZL = dtinf.Rows[0]["ZBZL"].ToString();//15
                        modelbj.JZZL = (100 + int.Parse(dtinf.Rows[0]["ZBZL"].ToString())).ToString();

                        DateTime.TryParse(dtinf.Rows[0]["CCRQ"].ToString(), out b);
                        if (a != null)
                            modelbj.SCRQ = b;
                        else
                            modelbj.SCRQ = DateTime.Today;
                        modelbj.FDJPL = dtinf.Rows[0]["PL"].ToString();
                        modelbj.RLZL = mainPanel.hninterface.HN_RLZL.GetValue(dtinf.Rows[0]["RLZL"].ToString(), "");

                        modelbj.EDGL = dtinf.Rows[0]["GL"].ToString();
                        modelbj.EDZS = "4000";
                        modelbj.BSQXS = "";
                        modelbj.DWS = "";
                        modelbj.GYFS = "";//25
                        modelbj.DPFS = "闭环电喷";
                        modelbj.JQFS = "";
                        modelbj.QGS = "";
                        modelbj.QDXS = "";

                        modelbj.CHZZ = "";//30
                        modelbj.DLSP = "";
                        modelbj.SFSRL = "";
                        modelbj.JHZZ = "有";
                        modelbj.OBD = "";
                        modelbj.DKGYYB = "否";
                        modelbj.LXDH = "";
                        modelbj.CZDZ = "";
                        modelbj.JCFS = "";
                        modelbj.JCLB = "";
                        modelbj.CLZL = "";
                        modelbj.SSXQ = "";
                        modelbj.SFWDZR = "";
                        modelbj.SFYQBF = "";
                        modelbj.DKGYYB = "";
                        modelbj.FDJSCQY = "";
                        modelbj.QDLTQY = "";
                        modelbj.RYPH = "";
                        carbj.JCFF = judgeTestMethod(modelbj);
                        ref_carInf(modelbj, carbj);
                        buttonStart.Enabled = true;
                    }
                    catch (Exception er)
                    { }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("获取车辆注册信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                ini.INIIO.saveLogInf("获取车辆注册信息失败,code" + code + ",msg:" + msg);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonASM.Checked)
                ref_WaitCar();
        }

        private void radioButtonSDS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSDS.Checked)
                ref_WaitCar();

        }

        private void radioButtonLUG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLUG.Checked)
                ref_WaitCar();

        }

        private void radioButtonZYJS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonZYJS.Checked)
                ref_WaitCar();

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
                ref_WaitCar();

        }

        private void buttonStopListen_Click(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
            {
                if (mainPanel.isStartTimerInCarlogin)
                {
                    string result="", info="";
                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                    {
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterface.sendMessage("", mainPanel.zkytwebinf.regcode, "06", ""), out result, out info);
                    }
                    else if(mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                    {
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceOther.sendMessage("", mainPanel.zkytwebinf.regcode, "06", ""), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                    {
                        mainPanel.xmlanalysis.ReadACKString(mainPanel.yichangInterfaceYnbs.xxtz("", mainPanel.zkytwebinf.regcode, "06", ""), out result, out info);
                    }
                    if (result == "1")
                    {
                        mainPanel.isStartTimerInCarlogin = false;
                        labelTmState.Text= "设备停止监听";
                       // buttonStartSm.Enabled = true;
                        //buttonStopListen.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(info);
                    }
                }
            }
            else
            {
                mainPanel.isStartTimerInCarlogin = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchPlate(0);
        }
    }
}
