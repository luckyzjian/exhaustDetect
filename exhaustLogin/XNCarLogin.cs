using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;
using carinfor;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SYS_DAL;
using SYS_MODEL;
using SYS.Model;

namespace exhaustDetect
{

    public partial class XNCarLogin : Form
    {
        ASM_XZDB asm_xzdb = new ASM_XZDB();
        VMAS_XZBZ vmas_xzdb = new SYS.Model.VMAS_XZBZ();                                 //VMAS限值地标
        JZJS_XZBZ jzjs_xzdb = new SYS.Model.JZJS_XZBZ();
        ZYJS_XZGB zyjs_xzgb = new SYS.Model.ZYJS_XZGB();//被检测车辆的限值国标Model层
        SDS_XZGB sds_xzgb = new SDS_XZGB();
        compensationModel compendata = new compensationModel();
        GBDal gbdal = new GBDal();
        CSVcontrol.csvReader csvreader = new CSVcontrol.csvReader();
        carinfor.jzjsdata jzjs_data = new carinfor.jzjsdata();
        carinfor.jzjsdataControl jzjsdatacontrol = new carinfor.jzjsdataControl();
        carinfor.sdsdata sds_data = new carinfor.sdsdata();
        carinfor.sdsdataControl sdsdatacontrol = new carinfor.sdsdataControl();
        carinfor.zyjsBtgdata zyjs_data = new carinfor.zyjsBtgdata();
        carinfor.zyjsBtgdataControl zyjsdatacontrol = new carinfor.zyjsBtgdataControl();
        carinfor.vmasdata vmas_data = new carinfor.vmasdata();
        carinfor.vmasdataControl vmasdatacontrol = new carinfor.vmasdataControl();
        carinfor.asmdata asm_data = new carinfor.asmdata();
        carinfor.asmdataControl asmdatacontrol = new carinfor.asmdataControl();

        VMASdal vmasdal = new VMASdal();
        VMAS vmasdata = new VMAS();
        ASMdal asmdal = new ASMdal();
        ASM asmdata = new ASM();
        JZJSdal jzjsdal = new JZJSdal();
        JZJS jzjsdata = new JZJS();
        SDSdal sdsdal = new SDSdal();
        SDS sdsdata = new SDS();
        Zyjsdal zyjsdal = new Zyjsdal();
        Zyjs_Btg zyjsdata = new Zyjs_Btg();
        carinfor.selfCheckIni selfcheckini = new carinfor.selfCheckIni();

        CARATWAIT carbj = new CARATWAIT();
        DateTime hjjcsj, hjjssj;
        string jcbgbh;

        private carinfor.carInidata carinidata = new carinfor.carInidata();
        private carinfor.statusconfigIni statusini = new carinfor.statusconfigIni();

        public carIni carini = new carIni();
        Thread th_wait = null;
        Thread th_hjwait = null;
        public delegate void wtlsb(Label Msgowner, string Msgstr);                //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                              //委托
        public delegate void wtlm(Label Msgowner, string Msgstr);
        public delegate void wtbe(Button button, bool buttonEnable);
        public delegate void wtSetDataGridValue(DataGridView dgv, int row, int column, string value);
        private XNCarInf carAtWait = new XNCarInf();
        private string exeName= "动力油耗";
        private string hjexeName = "";
        private string asmName = "ASMtest", sdsName = "sds", vmasName = "Vmastest", jzjsName = "lugdowm", zyjsName = "zyjsTest", lzName = "lztest";
        string speedFileName = @"C:\jcdatatxt\SpeedResult.ini";
        string fuelFileName = @"C:\jcdatatxt\fuelResult.ini";
        string dynFileName = @"C:\jcdatatxt\DynamicResult.ini";
        string qdzzlFileName = @"C:\jcdatatxt\QdzzlResult.ini";

        private string zxbz = "";
        bool beforedate = false;
        string Cllx = "";
        string CLSYQK = "";
        string jcsxh = "";//诚创联网时需要，站编号+线编号+累积号
        //asm标准
        public static float hc5025 = 0;
        public static float co5025 = 0;
        public static float no5025 = 0;
        public static float hc2540 = 0;
        public static float co2540 = 0;
        public static float no2540 = 0;
        string jsgk = "2540";
        string ksgkjs = "0";
        //老车标准
        public static float Limit_HC_BEBORE = 1;
        public static float Limit_CO_BEBORE = 1;
        public static float Limit_NO_BEBORE = 1;
        //新车标准
        public static float Limit_HCNOX_AFTER = 1;
        public static float Limit_CO_AFTER = 1;

        public float GXXZ = 0;                                                                      //光吸收系数限值
        public float GLXZ = 0;                                                                      //功率限值                                                               //功率限值
        public float ZSXZ_LOW = 0;
        public float ZSXZ_HIGH = 0;
        //功率限值

        public double btgxz = 0.0;
        public float btgzsxz = 0;

        public double lzxz = 0.0;//滤纸烟度法限值
        public string lzbz = "";

        public float H_HC_XZ = 0;                                                               //高怠速HC限值
        public float H_CO_XZ = 0;                                                               //高怠速CO限值
        public string λ_XZ = "1.00±0.03";                                                     //λ限值
        public float L_HC_XZ = 0;                                                               //怠速HC限值
        public float L_CO_XZ = 0;                                                               //怠速CO限值

        public XNCarLogin()
        {
            InitializeComponent();
        }

        private void XNCarLogin_Load(object sender, EventArgs e)
        {
            if (mainPanel.iscameraused)
            {
                //panelVideo.Visible = true;
                mainPanel.capturecontrol.stopLiveView(1);
                mainPanel.capturecontrol.openLiveView(1, pictureBoxFrontCamera.Handle);
            }
            clearTempPic();
            initDataGrid();
            timer1.Start();
        }
        private void clearTempPic()
        {
            ini.INIIO.createDir(@".\capPic");
            ini.INIIO.deleteDir(@".\capPic");//删除诚创联网文件交互文件夹内的所有文件
        }
        enum dynItemEnum { Dyn_Pe, Dyn_η, Dyn_Fe, Dyn_FE, Dyn_nm, Dyn_Ve, Dyn_Vw, Dyn_Ftc, Dyn_Fc, Dyn_Ff, Dyn_Ft, Dyn_αa, Dyn_温度, Dyn_湿度, Dyn_大气压, Dyn_评价, Dyn_ItemCount };
        string[] dynItem = { "Pe(kW)/Mm(N·m)", "功率比值系数η", "Fe/Fm(N)", "FE/FM(N)", "nm(r/min)", "Ve/Vm(km/h)", "Vw(km/h)", "Ftc(N)", "Fc(N)", "Ff(N)", "Ft(N)", "αa/αd", "温度(℃)", "湿度(%)", "大气压(kPa)", "评价" };
        enum fuelItemEnum { 检测速度, 台架加载阻力, 燃料总消耗量, 总行驶里程, 百公里油耗, 限值, 限值依据, 汽车滚动阻力, 空气阻力, 滚动阻力系数, 迎风面积, 空气阻力系数, 台架运转阻力, 台架滚动阻力, 台架滚动阻力系数, 台架内阻, 评价, ItemCount };
        string[] fuelItem = { "检测速度(km/h)", "FTC-台架加载阻力(N)", "燃料总消耗量(mL)", "总行驶里程(km)", "百公里油耗(L/100km)", "限值(L/100km)", "限值依据", "Ff-汽车滚动阻力(N)", "FW-空气阻力(N)", "f-滚动阻力系数", "A-迎风面积", "CD-空气阻力系数", "FC-台架运转阻力", "Ffc-台架滚动阻力", "fc-台架滚动阻力系数", "Ftc-台架内阻", "评价" };
        private void initDataGrid()
        {
            dataGridViewSd.Rows.Add(1);
            dataGridViewSd.Rows[0].Cells[0].Value = "速度值(km/h)";
            for (int i = 0; i < (int)(dynItemEnum.Dyn_ItemCount); i++)
            {
                dataGridViewDyn.Rows.Add(1);
                dataGridViewDyn.Rows[i].Cells[0].Value = dynItem[i];
            }
            for (int i = 0; i < (int)(fuelItemEnum.ItemCount); i++)
            {
                dataGridViewFuel.Rows.Add(1);
                dataGridViewFuel.Rows[i].Cells[0].Value = fuelItem[i];
            }

        }
        private void initDataGrid(int lx, string status)
        {
            if (lx == 1)
            {
                dataGridViewSd.Rows.Clear();
                dataGridViewSd.Rows.Add(1);
                dataGridViewSd.Rows[0].Cells[0].Value = "速度值(km/h)";
                labelSd.Text = status;
            }
            else if (lx == 2)
            {
                dataGridViewDyn.Rows.Clear();
                for (int i = 0; i < (int)(dynItemEnum.Dyn_ItemCount); i++)
                {
                    dataGridViewDyn.Rows.Add(1);
                    dataGridViewDyn.Rows[i].Cells[0].Value = dynItem[i];
                }
                labelDyn.Text = status;
            }
            else if (lx == 3)
            {
                dataGridViewFuel.Rows.Clear();
                for (int i = 0; i < (int)(fuelItemEnum.ItemCount); i++)
                {
                    dataGridViewFuel.Rows.Add(1);
                    dataGridViewFuel.Rows[i].Cells[0].Value = fuelItem[i];
                }
                labelFuel.Text = status;
            }
            else if(lx==4)
            {
                labelWq.Text = status;
            }
        }

        private void checkBoxCS_CheckedChanged(object sender, EventArgs e)
        {
            panelSpeed.Enabled = checkBoxCS.Checked;
            initDataGrid(1, checkBoxCS.Checked ? "待检" : "非检测项");
        }

        private void checkBoxDYN_CheckedChanged(object sender, EventArgs e)
        {
            panelDyn.Enabled = checkBoxDYN.Checked;
            initDataGrid(2, checkBoxDYN.Checked ? "待检" : "非检测项");
        }

        private void checkBoxFUEL_CheckedChanged(object sender, EventArgs e)
        {
            panelFuel.Enabled = checkBoxFUEL.Checked;
            initDataGrid(3, checkBoxFUEL.Checked ? "待检" : "非检测项");
        }
        private void checkBoxWq_CheckedChanged(object sender, EventArgs e)
        {
            panelWq.Enabled = checkBoxWq.Checked;
            initDataGrid(4, checkBoxWq.Checked ? "待检" : "非检测项");
        }
        public static bool isStartListen = true;
        public static bool isCarWaiting = false;
        public int searchingstep = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStartListen)
            {
                if (File.Exists(@"D:\DYN\TestVeh.xml")&&File.Exists(@"D:\DYN\TestStart.ini"))
                {
                    ini.INIIO.saveLogInf("查询到文件TestVeh.xml存在");
                    Thread.Sleep(300);
                    try
                    {
                        FileStream fs = new FileStream(@"D:\DYN\TestVeh.xml", FileMode.Open);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                        string filecontent = sr.ReadToEnd();
                        ini.INIIO.saveLogInf("TestVeh.xml：\r\n" + filecontent);
                        sr.Close();
                        try
                        {
                            string result, message;
                            DataTable vehinfdt = ReadVehicleInf(filecontent, out result, out message);
                            if (vehinfdt == null)
                            {
                                isStartListen = false;
                                MessageBox.Show("解析车辆信息出错：" + message);
                                return;
                            }
                            XNCarInf thiscarinf = getCarInfFromDatatable(vehinfdt);
                            showCarInf(thiscarinf);
                            carAtWait = thiscarinf;
                            isStartListen = false;
                        }
                        catch (Exception er)
                        {
                            isStartListen = false;
                            carAtWait = null;
                            buttonOK.Enabled = false;
                            MessageBox.Show("解析vehicleInf结构出错：" + er.Message);
                            return;
                        }
                    }
                    catch (Exception er)
                    {
                        isStartListen = false;
                        carAtWait = null;
                        buttonOK.Enabled = false;
                        ini.INIIO.saveLogInf("读取文件内容出现异常:" + er.Message);
                        MessageBox.Show("读取文件内容出现异常：" + er.Message);
                        return;
                    }

                }
                else
                {
                    searchingstep++;
                    if (searchingstep > 3) searchingstep = 0;
                    string ts = "等待待检车辆";
                    for (int i = 0; i <= searchingstep; i++)
                        ts += "..";
                    labelTS.Text = ts;
                    //Msg(labelTS, panelTS, ts);
                    showCarInf(null);
                    carAtWait = null;
                    buttonOK.Enabled = false;
                }

            }
        }
        public DataTable ReadVehicleInf(string xmlstring, out string result, out string errorMessage)
        {
            result = "1";
            errorMessage = "";
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = null;
                if (ds.Tables.Contains("VEHINFO"))
                {
                    dt1 = ds.Tables["VEHINFO"];
                }
                return dt1;
            }
            catch (Exception er)
            {
                result = "-1";
                errorMessage = er.Message;
                return null;
            }
        }
        public XNCarInf getCarInfFromDatatable(DataTable dt)
        {
            double a;
            DateTime scrq;
            XNCarInf carinf = new XNCarInf();
            carinf.jclsh = dt.Rows[0]["JYLSH"].ToString();
            carinf.clhp = dt.Rows[0]["HPHM"].ToString();
            carinf.hpzl = dt.Rows[0]["HPZL"].ToString();
            carinf.sfkc = dt.Rows[0]["SFKC"].ToString() == "1";
            carinf.cllx = dt.Rows[0]["CLLX"].ToString();
            carinf.syxz = dt.Rows[0]["SYXZ"].ToString();
            carinf.jcxz = dt.Rows[0]["JCXZ"].ToString();
            if (DateTime.TryParse(dt.Rows[0]["CCRQ"].ToString(), out scrq))
            { carinf.scrq = scrq; }
            else
            {
                carinf.scrq = DateTime.Now;
                ini.INIIO.saveLogInf("解析VEHINFO中CCRQ非有效日期格式：" + dt.Rows[0]["CCRQ"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["ZZL"].ToString(), out a))
            { carinf.zzl = a; }
            else
            {
                carinf.zzl = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中ZZL非数字：" + dt.Rows[0]["ZZL"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["ZBZL"].ToString(), out a))
            { carinf.zbzl = a; }
            else
            {
                carinf.zbzl = 1100;
                ini.INIIO.saveLogInf("解析VEHINFO中ZBZL非数字：" + dt.Rows[0]["ZBZL"].ToString());
            }
            carinf.jzzl =(int)( carinf.zbzl + 100);
            if (double.TryParse(dt.Rows[0]["JGL"].ToString(), out a))
            { carinf.jgl = a; }
            else
            {
                carinf.jgl = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中JGL非数字：" + dt.Rows[0]["JGL"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["EDGL"].ToString(), out a))
            { carinf.edgl = a; }
            else
            {
                carinf.edgl = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中EDGL非数字：" + dt.Rows[0]["EDGL"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["EDNJZS"].ToString(), out a))
            { carinf.edzs = a; }
            else
            {
                carinf.edzs = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中EDNJZS非数字：" + dt.Rows[0]["EDNJZS"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["EDNJ"].ToString(), out a))
            { carinf.ednj = a; }
            else
            {
                carinf.ednj = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中EDNJ非数字：" + dt.Rows[0]["EDNJ"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["EDYH"].ToString(), out a))
            { carinf.edyh = a; }
            else
            {
                carinf.edyh = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中EDYH非数字：" + dt.Rows[0]["EDYH"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["ZKRS"].ToString(), out a))
            { carinf.zkrs =(int)a; }
            else
            {
                carinf.zkrs = 5;
                ini.INIIO.saveLogInf("解析VEHINFO中ZKRS非数字：" + dt.Rows[0]["ZKRS"].ToString());
            }
            switch (dt.Rows[0]["LTLX"].ToString())
            {
                case "0":
                    carinf.ltlx = "子午胎"; break;
                case "1":
                    carinf.ltlx = "斜交胎"; break;
                case "9":
                    carinf.ltlx = "其他"; break;
            }
            switch (dt.Rows[0]["ZYTypeID"].ToString())
            {
                case "0":
                    carinf.jqfs = "自然吸气"; break;
                case "1":
                    carinf.jqfs = "机械增压"; break;
                case "2":
                    carinf.jqfs = "涡轮增压"; break;
                case "3":
                    carinf.jqfs = "涡轮增压中冷"; break;
                default:
                    carinf.jqfs = "自然吸气"; break;

            }
            if (double.TryParse(dt.Rows[0]["LTDMKD"].ToString(), out a))
            { carinf.ltdmkd = a; }
            else
            {
                carinf.ltdmkd = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中LTDMKD非数字：" + dt.Rows[0]["LTDMKD"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["QCGD"].ToString(), out a))
            { carinf.qcgd = a; }
            else
            {
                carinf.qcgd = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中QCGD非数字：" + dt.Rows[0]["QCGD"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["QLJ"].ToString(), out a))
            { carinf.qlj = a; }
            else
            {
                carinf.qlj = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中QLJ非数字：" + dt.Rows[0]["QLJ"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["QCCD"].ToString(), out a))
            { carinf.qccd = a; }
            else
            {
                carinf.qccd = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中QCCD非数字：" + dt.Rows[0]["QCCD"].ToString());
            }
            carinf.kcdj = dt.Rows[0]["KCDJ"].ToString();
            switch (dt.Rows[0]["HCCSXS"].ToString())
            {
                case "1":
                    carinf.hccsxs = "拦板"; break;
                case "2":
                    carinf.hccsxs = "自卸"; break;
                case "3":
                    carinf.hccsxs = "牵引"; break;
                case "4":
                    carinf.hccsxs = "仓栅"; break;
                case "5":
                    carinf.hccsxs = "厢式"; break;
                case "6":
                    carinf.hccsxs = "罐式"; break;
            }
            if (double.TryParse(dt.Rows[0]["QDZKZZL"].ToString(), out a))
            { carinf.qdzkzzl = a; }
            else
            {
                carinf.qdzkzzl = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中QDZKZZL非数字：" + dt.Rows[0]["QDZKZZL"].ToString());
            }
            if (mainPanel.logininfcontrol.checkQDZZLisAlive(carinf.clhp, carinf.hpzl, DateTime.Now))
            {
                DataTable qdzzlrecord = mainPanel.logininfcontrol.getQdzzlbyclhp(carinf.clhp, carinf.hpzl);
                if (qdzzlrecord != null)
                {
                    ini.INIIO.saveLogInf("在数据库里匹配车辆驱动轴重量成功："+ qdzzlrecord.Rows[0]["QDZKZZL"].ToString());
                    carinf.qdzkzzl = double.Parse(qdzzlrecord.Rows[0]["QDZKZZL"].ToString());
                    carinf.isQdzzlAlive = true;
                }
                else
                {
                    ini.INIIO.saveLogInf("在数据库里匹配车辆驱动轴重量失败");
                    carinf.isQdzzlAlive = false;
                }
            }
            else
            {
                ini.INIIO.saveLogInf("在数据库里匹配车辆驱动轴重量失败");
                carinf.isQdzzlAlive = false;
            }
            if (double.TryParse(dt.Rows[0]["QYCMZZL"].ToString(), out a))
            { carinf.qycmzzl = a; }
            else
            {
                carinf.qycmzzl = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中QYCMZZL非数字：" + dt.Rows[0]["QYCMZZL"].ToString());
            }
            switch (dt.Rows[0]["DLXPJBZ"].ToString())
            {
                case "1":
                    carinf.dlxpjdj = "一级"; break;
                case "2":
                    carinf.dlxpjdj = "二级"; break;
            }
            if (double.TryParse(dt.Rows[0]["YHXZ"].ToString(), out a))
            { carinf.yhxz = a; }
            else
            {
                carinf.yhxz = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中YHXZ非数字：" + dt.Rows[0]["YHXZ"].ToString());
            }
            if (double.TryParse(dt.Rows[0]["YHCS"].ToString(), out a))
            { carinf.yhcs = a; }
            else
            {
                carinf.yhcs = 0;
                ini.INIIO.saveLogInf("解析VEHINFO中YHCS非数字：" + dt.Rows[0]["YHCS"].ToString());
            }
            carinf.rlzl = dt.Rows[0]["RLZL"].ToString();
            carinf.sfjccs = dt.Rows[0]["JCXM"].ToString().Contains("S1");
            carinf.sfjcdyn = dt.Rows[0]["JCXM"].ToString().Contains("EP");
            carinf.sfjcfuel = dt.Rows[0]["JCXM"].ToString().Contains("OC");
            carinf.sfjcwq = dt.Rows[0]["JCXM"].ToString().Contains("X");
            carinf.pqhclzz = (dt.Rows[0]["CH"].ToString() == "1");
            if (carinf.sfjcwq)
            {
                if (dt.Rows[0]["JCXM"].ToString().Contains("X1")) carinf.wqjcff = "SDS";
                else if (dt.Rows[0]["JCXM"].ToString().Contains("X2")) carinf.wqjcff = "ASM";
                else if (dt.Rows[0]["JCXM"].ToString().Contains("X3")) carinf.wqjcff = "JZJS";
                else if (dt.Rows[0]["JCXM"].ToString().Contains("X4")) carinf.wqjcff = "ZYJS";
                else if (dt.Rows[0]["JCXM"].ToString().Contains("X5")) carinf.wqjcff = "LZ";
                else if (dt.Rows[0]["JCXM"].ToString().Contains("X6")) carinf.wqjcff = "VMAS";
                else { carinf.wqjcff = "—"; carinf.sfjcwq = false; }
            }
            else
                carinf.wqjcff = "—";
            carinf.qdzs = dt.Rows[0]["QDXS"].ToString().Contains("×4") ? 2 : 1;
            return carinf;
        }

        private void showCarInf(XNCarInf carinf)
        {
            if (carinf == null)
            {
                labelJCLSH.Text = "—";
                labelHPZL.Text = "—";
                labelCLHP.Text = "—";
                labelSFKC.Text = "—";
                labelCLLX.Text = "—";
                labelSYXZ.Text = "—";
                labelZZL.Text = "—";
                labelZBZL.Text = "—";
                labelJGL.Text = "—";
                labelEDGL.Text = "—";
                labelEDNJ.Text = "—";
                labelEDZS.Text = "—";
                labelEDYH.Text = "—";
                labelLTLX.Text = "—";
                labelDMKD.Text = "—";
                labelQCGD.Text = "—";
                labelQLJ.Text = "—";
                labelQCCD.Text = "—";
                labelKCDJ.Text = "—";
                labelHCCSXS.Text = "—";
                labelQDZKZZL.Text = "—";
                labelQYCMZZL.Text = "—";
                labelDLXPJBZ.Text = "—";
                labelYHXZ.Text = "—";
                labelYHCS.Text = "—";
                labelRLZL.Text = "—";
                labelQDZS.Text = "—";
                labelJCXZ.Text = "—";
                labelwqjcff.Text = "—";
                checkBoxCS.Checked = false;
                checkBoxDYN.Checked = false;
                checkBoxFUEL.Checked = false;
                checkBoxQDZKZZL.Checked = false;
                checkBoxWq.Checked = false;
            }
            else
            {
                Msg(labelTS, panelTS, carinf.clhp + "待检");
                labelJCLSH.Text = carinf.jclsh;
                labelHPZL.Text = carinf.hpzl;
                labelCLHP.Text = carinf.clhp;
                labelJCXZ.Text = carinf.jcxz;
                labelSFKC.Text = carinf.sfkc ? "是" : "否";
                labelCLLX.Text = carinf.cllx;
                labelSYXZ.Text = carinf.syxz;
                labelZZL.Text = carinf.zzl.ToString("0");
                labelZBZL.Text = carinf.zbzl.ToString("0");
                labelJGL.Text = carinf.jgl.ToString("0.0");
                labelEDGL.Text = carinf.edgl.ToString("0.0");
                labelEDNJ.Text = carinf.ednj.ToString("0");
                labelEDZS.Text = carinf.edzs.ToString("0");
                labelEDYH.Text = carinf.edyh.ToString("0.0");
                labelLTLX.Text = carinf.ltlx;
                labelDMKD.Text = carinf.ltdmkd.ToString("0.00");
                labelQCGD.Text = carinf.qcgd.ToString("0");
                labelQLJ.Text = carinf.qlj.ToString("0");
                labelQCCD.Text = carinf.qccd.ToString("0");
                labelKCDJ.Text = carinf.kcdj;
                labelHCCSXS.Text = carinf.hccsxs;
                if (!carinf.isQdzzlAlive)
                {
                    labelQDZKZZL.Text = "待称重";
                    labelQDZKZZL.ForeColor = Color.Red;
                    checkBoxQDZKZZL.Checked = false;
                    checkBoxQDZKZZL.Enabled = false;
                }
                else
                {
                    labelQDZKZZL.Text = carinf.qdzkzzl.ToString("0");
                    labelQDZKZZL.ForeColor = Color.Black;
                    checkBoxQDZKZZL.Checked = false;
                    checkBoxQDZKZZL.Enabled = true;
                }
                labelQYCMZZL.Text = carinf.qycmzzl.ToString("0");
                labelDLXPJBZ.Text = carinf.dlxpjdj;
                labelYHXZ.Text = carinf.yhxz.ToString("0.0");
                labelYHCS.Text = carinf.yhcs.ToString("0.0");
                labelRLZL.Text = carinf.rlzl;
                labelQDZS.Text = carinf.qdzs.ToString("0");
                labelwqjcff.Text = carinf.wqjcff;
                checkBoxCS.Checked = carinf.sfjccs;
                checkBoxDYN.Checked = carinf.sfjcdyn;
                checkBoxFUEL.Checked = carinf.sfjcfuel;
                checkBoxWq.Checked = carinf.sfjcwq;
                isWqFinished = !carinf.sfjcwq;
                isSpeedFinished = !carinf.sfjccs;
                isDynFinished = !carinf.sfjcdyn;
                isFuelFinished = !carinf.sfjcfuel;
                starttime = DateTime.Now;
                buttonStartWqTest.Enabled = carinf.sfjcwq;
                buttonOK.Enabled = (carinf.sfjccs||carinf.sfjcdyn||carinf.sfjcfuel);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            isStartListen = true;
        }
        /// <summary>
        /// 信息显示
        /// </summary>
        /// <param name="Msgowner">信息显示的Label控件</param>
        /// <param name="Msgfather">Label控件的父级Panel</param>
        /// <param name="Msgstr">要显示的信息</param>
        /// <param name="Update_DB">是不是要更新到检测状态</param>
        public void Msg(Label Msgowner, Panel Msgfather, string Msgstr)
        {
            BeginInvoke(new wtlsb(Msg_Show), Msgowner, Msgstr);
            BeginInvoke(new wtlp(Msg_Position), Msgowner, Msgfather);
        }
        public void Label_Msg(Label Msgowner, string Msgstr)
        {
            BeginInvoke(new wtlm(Label_Show), Msgowner, Msgstr);
        }
        public void Label_Show(Label Msgowner, string Msgstr)
        {
            Msgowner.Text = Msgstr;
        }
        public void Msg_Show(Label Msgowner, string Msgstr)
        {
            Msgowner.Text = Msgstr;
        }

        public void Msg_Position(Label Msgowner, Panel Msgfather)
        {
            if (Msgowner.Width < Msgfather.Width)
                Msgowner.Location = new Point((Msgfather.Width - Msgowner.Width) / 2, Msgowner.Location.Y);
            else
                Msgowner.Location = new Point(0, Msgowner.Location.Y);
        }
        public void enableButton(Button button, bool buttonEnable)
        {
            BeginInvoke(new wtbe(button_enable), button, buttonEnable);
        }
        public void button_enable(Button button, bool buttonEnable)
        {
            button.Enabled = buttonEnable;
        }
        public void SetDataGridViewValue(DataGridView dgv,int row,int column,string value)
        {
            BeginInvoke(new wtSetDataGridValue(Set_DataGridView_Value), dgv, row, column, value);
        }
        public void Set_DataGridView_Value(DataGridView dgv, int row, int column, string value)
        {
            dgv.Rows[row].Cells[column].Value = value;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (carAtWait != null)
            {
                if (IsProcessStarted(exeName))
                {
                    MessageBox.Show("已有检测程序在运行，不能开始检测");
                    return;
                }
                if(carAtWait.sfjcfuel)
                {
                    if(mainPanel.shareYhy)
                    {
                        string SHAREDLINEID="";
                        if (mainPanel.logininfcontrol.checkYhyIsUsed(mainPanel.lineid,out SHAREDLINEID))
                        {
                            if (MessageBox.Show("系统显示"+SHAREDLINEID+"号线正在使用共用油耗仪\r\n是否继续检测？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                        mainPanel.logininfcontrol.deleteYhyZt();
                        mainPanel.logininfcontrol.writeYhyZt(mainPanel.lineid);
                    }
                }
                double a = 0;
                yhcarInidata carinidata = new yhcarInidata();
                carinidata.检测流水号 = carAtWait.jclsh;
                carinidata.检测类型 = 0;
                if (carAtWait.jcxz.Contains("等级评定"))
                {
                    carinidata.动力检测类型 = 1;
                }
                else
                {
                    if (carAtWait.dlxpjdj=="1")
                        carinidata.动力检测类型 = 3;
                    else
                        carinidata.动力检测类型 = 2;
                }
                carinidata.是否检测车速 = carAtWait.sfjccs;
                carinidata.是否检测动力性 = carAtWait.sfjcdyn;
                carinidata.是否检测油耗 = carAtWait.sfjcfuel;
                carinidata.车辆号牌 = carAtWait.clhp;
                carinidata.号牌种类 = carAtWait.hpzl;
                carinidata.车辆型号 = "";
                carinidata.发动机型号 = "";
                carinidata.燃料种类 = carAtWait.rlzl.Contains("柴油") ? 1 : 0;
                carinidata.加载力计算方式 = 1;
                carinidata.额定总质量 = carAtWait.zzl;
                carinidata.驱动轴空载质量 = carAtWait.qdzkzzl;
                if(carAtWait.isQdzzlAlive)
                    carinidata.驱动轴质量方式 = checkBoxQDZKZZL.Checked?1:0;
                else
                    carinidata.驱动轴质量方式 = 1;
                carinidata.汽车类型 = carAtWait.sfkc ? 0 : 1;
                carinidata.油耗限值 = carAtWait.yhxz;
                carinidata.油耗检测加载力 = 0;
                carinidata.油耗检测工况速度 = carAtWait.yhcs;
                carinidata.油耗车速方式 = 1;
                carinidata.驱动轴数 = carAtWait.qdzs;
                carinidata.轮胎类型 = carAtWait.ltlx.Contains("子午") ? 0 : 1;
                carinidata.子午胎轮胎断面宽度 = carAtWait.ltdmkd;
                carinidata.汽车前轮距 = carAtWait.qlj;
                carinidata.汽车高度 = carAtWait.qcgd;
                carinidata.客车车长 = carAtWait.qccd;
                switch (carAtWait.hccsxs)
                {
                    case "拦板":
                        carinidata.货车车身型式 = 0; break;
                    case "自卸":
                        carinidata.货车车身型式 = 1; break;
                    case "牵引":
                        carinidata.货车车身型式 = 2; break;
                    case "仓栅":
                        carinidata.货车车身型式 = 3; break;
                    case "厢式":
                        carinidata.货车车身型式 = 4; break;
                    case "罐式":
                        carinidata.货车车身型式 = 5; break;
                }
                carinidata.牵引车满载总质量 = carAtWait.qycmzzl;
                carinidata.动力性检测加载力 = 0;
                carinidata.点燃式额定扭矩 = carAtWait.ednj;
                carinidata.点燃式额定扭矩转速 = carAtWait.edzs;
                carinidata.是否危险货物运输车辆 = checkBoxIsDanger.Checked ? 1 : 0;
                carinidata.压燃式功率参数类型 = 0;
                carinidata.压燃式额定功率 = carAtWait.edgl;
                if (!carini.writeYhCarIniXn(carinidata))
                {
                    MessageBox.Show("发送车辆检测信息有误，不能开始检测");
                }
                else
                {
                    try
                    {
                        isSpeedFinished = !carinidata.是否检测车速;
                        isDynFinished = !carinidata.是否检测动力性;
                        isFuelFinished = !carinidata.是否检测油耗;
                        capimage = null;
                        File.Delete(speedFileName);
                        File.Delete(fuelFileName);
                        File.Delete(dynFileName);
                        File.Delete(qdzzlFileName);
                        File.Delete(@"D:\DYN\TestResult.xml");
                       // starttime = DateTime.Now;
                        Process.Start("D://环保检测子程序/动力油耗.EXE", "auto");
                        th_wait = new Thread(waitTestFinished);
                        th_wait.Start();
                        buttonOK.Enabled = false;
                        File.Delete(@"D:\DYN\TestVeh.xml");
                        File.Delete(@"D:\DYN\TestStart.ini");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("打开检测子程序出现异常：" + er.Message);
                    }
                }

            }
        }
        /// <summary>

        /// 此函数用于判断某一外部进程是否打开

        /// </summary>

        /// <param name="processName">参数为进程名</param>

        /// <returns>如果打开了，就返回true，没打开，就返回false</returns>

        private bool IsProcessStarted(string processName)
        {

            Process[] temp = Process.GetProcessesByName(processName);

            if (temp.Length > 0) return true;

            else

                return false;

        }
        bool isSpeedFinished = false;
        bool isDynFinished = false;
        bool isFuelFinished = false;
        bool isWqFinished = false;
        //public static bool processalive = true;
        DateTime clickstarttime = DateTime.Now.AddSeconds(-2);
        DateTime starttime, endtime;
        SpeedResult speedresult = new SpeedResult();
        GasolineDynamicResult gasdynresult = new GasolineDynamicResult();
        DieselDynamicResult diesresult = new DieselDynamicResult();
        fuelResult fuelresult = new fuelResult();
        string xn_speedcurve = "";
        string xn_forcecurve = "";
        private void waitTestFinished()
        {
            try
            {
                while (mainPanel.processalive)
                {
                    Thread.Sleep(500);
                    if (IsProcessStarted(exeName))
                    {
                        if (File.Exists(qdzzlFileName))//东软平台状态字处理
                        {
                            Thread.Sleep(500);
                            string data = carini.readDataFormFile(qdzzlFileName);
                            ini.INIIO.saveLogInf("接收到驱动轴质量检验结果数据:\r\n" + data);
                            JObject ja = (JObject)JsonConvert.DeserializeObject(data);
                            double qdzzl = double.Parse(ja["驱动轴空载质量"].ToString());
                            Label_Msg(labelQDZKZZL, qdzzl.ToString("0"));
                            mainPanel.logininfcontrol.writeQdzzl(carAtWait.clhp, carAtWait.hpzl, qdzzl.ToString("0"));
                            File.Delete(qdzzlFileName);
                        }
                        if (File.Exists(speedFileName))//东软平台状态字处理
                        {
                            Thread.Sleep(500);
                            string data = carini.readDataFormFile(speedFileName);
                            ini.INIIO.saveLogInf("接收到车速检验结果数据:\r\n" + data);
                            JObject ja = (JObject)JsonConvert.DeserializeObject(data);
                            speedresult.车速 = double.Parse(ja["车速"].ToString());
                            speedresult.车速判定结果 = int.Parse(ja["车速判定结果"].ToString());
                            Label_Msg(labelSd, "完成");
                            SetDataGridViewValue(dataGridViewSd, 0, 1, speedresult.车速.ToString("0.0"));
                            File.Delete(speedFileName);
                            isSpeedFinished = true;
                        }
                        if (File.Exists(dynFileName))//东软平台状态字处理
                        {
                            Thread.Sleep(500);
                            string data = carini.readDataFormFile(dynFileName);
                            ini.INIIO.saveLogInf("接收到动力性检验结果数据:\r\n" + data);
                            JObject ja = (JObject)JsonConvert.DeserializeObject(data);
                            if (data.Contains("额定扭矩"))
                            {
                                gasdynresult.检测类型 = int.Parse(ja["检测类型"].ToString());
                                gasdynresult.功率比值系数 = double.Parse(ja["功率比值系数"].ToString());
                                gasdynresult.发动机额定扭矩 = double.Parse(ja["发动机额定扭矩"].ToString());
                                gasdynresult.额定扭矩车速 = double.Parse(ja["额定扭矩车速"].ToString());
                                gasdynresult.额定扭矩转速 = double.Parse(ja["额定扭矩转速"].ToString());
                                gasdynresult.稳定车速 = double.Parse(ja["稳定车速"].ToString());
                                gasdynresult.加载力 = double.Parse(ja["加载力"].ToString());
                                gasdynresult.发动机达标扭矩驱动力 = double.Parse(ja["发动机达标扭矩驱动力"].ToString());
                                gasdynresult.测功机内阻 = double.Parse(ja["测功机内阻"].ToString());
                                gasdynresult.轮胎滚动阻力 = double.Parse(ja["轮胎滚动阻力"].ToString());
                                gasdynresult.发动机附件阻力 = double.Parse(ja["发动机附件阻力"].ToString());
                                gasdynresult.车辆传动系允许阻力 = double.Parse(ja["车辆传动系允许阻力"].ToString());
                                gasdynresult.功率校正系数 = double.Parse(ja["功率校正系数"].ToString());
                                gasdynresult.台架滚动阻力系数 = double.Parse(ja["台架滚动阻力系数"].ToString());
                                gasdynresult.温度 = double.Parse(ja["温度"].ToString());
                                gasdynresult.湿度 = double.Parse(ja["湿度"].ToString());
                                gasdynresult.大气压 = double.Parse(ja["大气压"].ToString());
                                gasdynresult.判定结果 = int.Parse(ja["判定结果"].ToString());
                                gasdynresult.等级评定结果 = int.Parse(ja["等级评定结果"].ToString());
                                gasdynresult.速度曲线 =ja["速度曲线"].ToString();
                                gasdynresult.扭力曲线 = ja["扭力曲线"].ToString();
                                gasdynresult.功率曲线 = ja["功率曲线"].ToString();
                                xn_speedcurve = gasdynresult.速度曲线;
                                xn_forcecurve = gasdynresult.扭力曲线;
                                Label_Msg(labelDyn, "完成");
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Pe), 1, gasdynresult.发动机额定扭矩.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_η), 1, gasdynresult.功率比值系数.ToString("0.000"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Fe), 1, gasdynresult.发动机达标扭矩驱动力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_FE), 1, gasdynresult.加载力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_nm), 1, gasdynresult.额定扭矩转速.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ve), 1, gasdynresult.额定扭矩车速.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Vw), 1, gasdynresult.稳定车速.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ftc), 1, gasdynresult.测功机内阻.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Fc), 1, gasdynresult.轮胎滚动阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ff), 1, gasdynresult.发动机附件阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ft), 1, gasdynresult.车辆传动系允许阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_αa), 1, gasdynresult.功率校正系数.ToString("0.000"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_温度), 1, gasdynresult.温度.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_湿度), 1, gasdynresult.湿度.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_大气压), 1, gasdynresult.大气压.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_评价), 1, gasdynresult.判定结果 == 0 ? "合格" : "不合格");
                                
                            }
                            else
                            {
                                diesresult.检测类型 = int.Parse(ja["检测类型"].ToString());
                                diesresult.功率比值系数 = double.Parse(ja["功率比值系数"].ToString());
                                diesresult.额定功率 = double.Parse(ja["额定功率"].ToString());
                                diesresult.额定功率车速 = double.Parse(ja["额定功率车速"].ToString());
                                diesresult.稳定车速 = double.Parse(ja["稳定车速"].ToString());
                                diesresult.台架滚动阻力 = double.Parse(ja["台架滚动阻力"].ToString());
                                diesresult.加载力 = double.Parse(ja["加载力"].ToString());
                                diesresult.测功机内阻 = double.Parse(ja["测功机内阻"].ToString());
                                diesresult.轮胎滚动阻力 = double.Parse(ja["轮胎滚动阻力"].ToString());
                                diesresult.发动机附件阻力 = double.Parse(ja["发动机附件阻力"].ToString());
                                diesresult.车辆传动系允许阻力 = double.Parse(ja["车辆传动系允许阻力"].ToString());
                                diesresult.功率校正系数 = double.Parse(ja["功率校正系数"].ToString());
                                diesresult.台架滚动阻力系数 = double.Parse(ja["台架滚动阻力系数"].ToString());
                                diesresult.温度 = double.Parse(ja["温度"].ToString());
                                diesresult.湿度 = double.Parse(ja["湿度"].ToString());
                                diesresult.大气压 = double.Parse(ja["大气压"].ToString());
                                diesresult.判定结果 = int.Parse(ja["判定结果"].ToString());
                                diesresult.等级评定结果 = int.Parse(ja["等级评定结果"].ToString());
                                diesresult.速度曲线 = ja["速度曲线"].ToString();
                                diesresult.扭力曲线 = ja["扭力曲线"].ToString();
                                diesresult.功率曲线 = ja["功率曲线"].ToString();
                                xn_speedcurve = gasdynresult.速度曲线;
                                xn_forcecurve = gasdynresult.扭力曲线;

                                Label_Msg(labelDyn, "完成");
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Pe), 1, diesresult.额定功率.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_η), 1, diesresult.功率比值系数.ToString("0.000"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Fe), 1, diesresult.台架滚动阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_FE), 1, diesresult.加载力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_nm), 1, "—");
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ve), 1, diesresult.额定功率车速.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Vw), 1, diesresult.稳定车速.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ftc), 1, diesresult.测功机内阻.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Fc), 1, diesresult.轮胎滚动阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ff), 1, diesresult.发动机附件阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_Ft), 1, diesresult.车辆传动系允许阻力.ToString("0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_αa), 1, diesresult.功率校正系数.ToString("0.000"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_温度), 1, diesresult.温度.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_湿度), 1, diesresult.湿度.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_大气压), 1, diesresult.大气压.ToString("0.0"));
                                SetDataGridViewValue(dataGridViewDyn, (int)(dynItemEnum.Dyn_评价), 1, diesresult.判定结果 == 0 ? "合格" : "不合格");
                            }
                            File.Delete(dynFileName);
                            isDynFinished = true;
                            if (mainPanel.iscameraused && mainPanel.capturecontrol != null && mainPanel.capturedata.cap_xn_start)
                            {
                                byte[] imagebuffer = new byte[1];
                                mainPanel.capturecontrol.startFrontCaptureThreadToRam(ref imagebuffer);
                                if (imagebuffer != null)
                                {
                                    capimage = BytesToImage(imagebuffer);
                                    pictureBoxCapPicture.Image = capimage;
                                }
                            }
                        }
                        if (File.Exists(fuelFileName))//东软平台状态字处理
                        {
                            Thread.Sleep(500);
                            string data = carini.readDataFormFile(fuelFileName);
                            ini.INIIO.saveLogInf("接收到油耗检验结果数据:\r\n" + data);
                            JObject ja = (JObject)JsonConvert.DeserializeObject(data);
                            fuelresult.检测速度 = double.Parse(ja["检测速度"].ToString());
                            fuelresult.台架加载阻力 = double.Parse(ja["台架加载阻力"].ToString());
                            fuelresult.燃料总消耗量 = double.Parse(ja["燃料总消耗量"].ToString());
                            fuelresult.总行驶里程 = double.Parse(ja["总行驶里程"].ToString());
                            fuelresult.百公里燃料消耗量 = double.Parse(ja["百公里燃料消耗量"].ToString());
                            fuelresult.限值 = double.Parse(ja["限值"].ToString());
                            fuelresult.限值依据 = int.Parse(ja["限值依据"].ToString());
                            fuelresult.判定结果 = int.Parse(ja["判定结果"].ToString());
                            fuelresult.汽车滚动阻力 = double.Parse(ja["汽车滚动阻力"].ToString());
                            fuelresult.空气阻力 = double.Parse(ja["空气阻力"].ToString());
                            fuelresult.滚动阻力系数 = double.Parse(ja["滚动阻力系数"].ToString());
                            fuelresult.迎风面积 = double.Parse(ja["迎风面积"].ToString());
                            fuelresult.空气阻力系数 = double.Parse(ja["空气阻力系数"].ToString());
                            fuelresult.台架运转阻力 = double.Parse(ja["台架运转阻力"].ToString());
                            fuelresult.台架滚动阻力 = double.Parse(ja["台架滚动阻力"].ToString());
                            fuelresult.台架滚动阻力系数 = double.Parse(ja["台架滚动阻力系数"].ToString());
                            fuelresult.台架内阻 = int.Parse(ja["台架内阻"].ToString());
                            fuelresult.速度曲线 = ja["速度曲线"].ToString();
                            fuelresult.扭力曲线 = ja["扭力曲线"].ToString();
                            fuelresult.油耗曲线 = ja["油耗曲线"].ToString();
                            Label_Msg(labelFuel, "完成");
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.检测速度), 1, fuelresult.检测速度.ToString("0.0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.台架加载阻力), 1, fuelresult.台架加载阻力.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.燃料总消耗量), 1, fuelresult.燃料总消耗量.ToString("0.0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.总行驶里程), 1, fuelresult.总行驶里程.ToString("0.0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.百公里油耗), 1, fuelresult.百公里燃料消耗量.ToString("0.00"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.限值), 1, fuelresult.限值.ToString("0.00"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.限值依据), 1, "—");
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.汽车滚动阻力), 1, fuelresult.汽车滚动阻力.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.空气阻力), 1, fuelresult.空气阻力.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.滚动阻力系数), 1, fuelresult.滚动阻力系数.ToString("0.000"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.迎风面积), 1, fuelresult.迎风面积.ToString("0.000"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.空气阻力系数), 1, fuelresult.空气阻力系数.ToString("0.000"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.台架运转阻力), 1, fuelresult.台架运转阻力.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.台架滚动阻力), 1, fuelresult.台架滚动阻力.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.台架滚动阻力系数), 1, fuelresult.台架滚动阻力系数.ToString("0.000"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.台架内阻), 1, fuelresult.台架内阻.ToString("0"));
                            SetDataGridViewValue(dataGridViewFuel, (int)(fuelItemEnum.评价), 1, fuelresult.判定结果 == 0 ? "合格" : "不合格");
                            File.Delete(fuelFileName);
                            isFuelFinished = true;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                endtime = DateTime.Now;
                string finishedstring = "";
                if (!isSpeedFinished)
                    finishedstring += " 车速检测未完成";
                if (!isDynFinished)
                    finishedstring += " 动力性检测未完成";
                if (!isFuelFinished)
                    finishedstring += " 油耗检测未完成";
                if(!isWqFinished)
                    finishedstring += " 尾气还未检测，请进行尾气检测";
                if (isSpeedFinished && isDynFinished && isFuelFinished&isWqFinished)
                    finishedstring = "检测完成";
                Msg(labelTS, panelTS, finishedstring);
                if (finishedstring == "检测完成")
                {
                    writeResultFile();
                    //File.Delete(@"D:\DYN\TestVeh.xml");//删除安车车辆信息
                    File.Delete(@"C:\jcdatatxt\carinfoXn.ini");//删除本地车辆信息
                }
                else
                {
                    enableButton(buttonOK, true);
                }
            }
            catch(Exception er)
            {
                ini.INIIO.saveLogInf("waitfinieshid process exception:" + er.Message);
                this.Close();
            }
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting =System.Xml.Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"GB2312\"");
            return newstring;
        }
        
        public void Init_ZyjsLimit()
        {
            try
            {
                

                zyjs_xzgb = gbdal.Get_ZYJS_XZGB();
                
                        if (carAtWait.jqfs.Contains("自然"))
                        {
                            ini.INIIO.saveLogInf("进气方式：自然吸气");
                            btgxz = Convert.ToDouble(zyjs_xzgb.ZRDate20011001btgxz);
                            ini.INIIO.saveLogInf("光吸收系数:" + btgxz.ToString());
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("进气方式：增压");
                            btgxz = Convert.ToDouble(zyjs_xzgb.WLDate20011001btgxz);
                            ini.INIIO.saveLogInf("光吸收系数:" + btgxz.ToString());
                        }
                   

            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("初始化排放限值异常：" + er.Message);
                Msg(labelTS, panelTS, "初始化排放限值出错，请检查被检车辆信息是否正确！");
                buttonOK.Enabled = false;
            }

        }

        public void Init_SdsLimit()
        {
            try
            {
                
                sds_xzgb = gbdal.Get_SDS_XZGB();
                
                    if (carAtWait.zkrs <= 6 && carAtWait.jzzl<= 2500)     //第一类轻型汽车
                        Cllx = "第一类轻型汽车";
                    else if (carAtWait.zzl <= 3500)       //第二类轻型汽车
                        Cllx = "第二类轻型汽车";
                    else
                        Cllx = "重型汽车";              //重型汽车
                ini.INIIO.saveLogInf("车辆类型：" + Cllx);
                switch (Cllx)
                {
                    case "第一类轻型汽车":
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) < 0)    //1995年7月1日前生产的第一类轻型汽车
                        {
                            //H_HC_XZ = 900;
                            //H_CO_XZ = 3.0f;
                            //L_HC_XZ = 1200;
                            //L_CO_XZ = 4.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd1Date19950701qHC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd1Date19950701qCO);
                            L_HC_XZ = float.Parse(sds_xzgb.d1Date19950701qHC);
                            L_CO_XZ = float.Parse(sds_xzgb.d1Date19950701qCO);
                        }
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) >= 0 && DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("2000-07-01")) < 0)    //1995年7月1日到2000年7月1日生产的第一类轻型汽车
                        {
                            //H_HC_XZ = 900;
                            //H_CO_XZ = 3.0f;
                            //L_HC_XZ = 900;
                            //L_CO_XZ = 4.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd1Date1995070120000701HC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd1Date1995070120000701CO);
                            L_HC_XZ = float.Parse(sds_xzgb.d1Date1995070120000701HC);
                            L_CO_XZ = float.Parse(sds_xzgb.d1Date1995070120000701CO);
                        }
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("2000-07-01")) >= 0)    //2000年7月1日起生产的第一类轻型汽车
                        {
                            //H_HC_XZ = 100;
                            //H_CO_XZ = 0.3f;
                            //L_HC_XZ = 150;
                            //L_CO_XZ = 0.8f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd1Date20000701HC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd1Date20000701CO);
                            L_HC_XZ = float.Parse(sds_xzgb.d1Date20000701HC);
                            L_CO_XZ = float.Parse(sds_xzgb.d1Date20000701CO);
                        }
                        break;
                    case "第二类轻型汽车":
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) < 0)    //1995年7月1日前生产的第二类轻型汽车
                        {
                            //H_HC_XZ = 900;
                            //H_CO_XZ = 3.0f;
                            //L_HC_XZ = 1200;
                            //L_CO_XZ = 4.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd2Date19950701qHC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd2Date19950701qCO);
                            L_HC_XZ = float.Parse(sds_xzgb.d2Date19950701qHC);
                            L_CO_XZ = float.Parse(sds_xzgb.d2Date19950701qCO);
                        }
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) >= 0 && DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("2001-10-01")) < 0)    //1995年7月1日到2001年10月1日生产的第二类轻型汽车
                        {
                            //H_HC_XZ = 900;
                            //H_CO_XZ = 3.0f;
                            //L_HC_XZ = 900;
                            //L_CO_XZ = 4.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd2Date1995070120011001HC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd2Date1995070120011001CO);
                            L_HC_XZ = float.Parse(sds_xzgb.d2Date1995070120011001HC);
                            L_CO_XZ = float.Parse(sds_xzgb.d2Date1995070120011001CO);
                        }
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("2001-10-01")) >= 0)    //2001年10月1日起生产的第二类轻型汽车
                        {
                            //H_HC_XZ = 150;
                            //H_CO_XZ = 0.5f;
                            //L_HC_XZ = 200;
                            //L_CO_XZ = 1.0f;
                            H_HC_XZ = float.Parse(sds_xzgb.Hd2Date20011001HC);
                            H_CO_XZ = float.Parse(sds_xzgb.Hd2Date20011001CO);
                            L_HC_XZ = float.Parse(sds_xzgb.d2Date20011001HC);
                            L_CO_XZ = float.Parse(sds_xzgb.d2Date20011001CO);
                        }
                        break;
                    case "重型汽车":
                        if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) < 0)    //1995年7月1日前生产的重型汽车
                        {
                            //H_HC_XZ = 1200;
                            //H_CO_XZ = 3.5f;
                            //L_HC_XZ = 2000;
                            //L_CO_XZ = 5.0f;
                            H_HC_XZ = float.Parse(sds_xzgb.HzxDate19950701qHC);
                            H_CO_XZ = float.Parse(sds_xzgb.HzxDate19950701qCO);
                            L_HC_XZ = float.Parse(sds_xzgb.zxDate19950701qHC);
                            L_CO_XZ = float.Parse(sds_xzgb.zxDate19950701qCO);
                        }
                        else if (DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("1995-07-01")) >= 0 && DateTime.Compare(carAtWait.scrq, Convert.ToDateTime("2004-09-01")) < 0)   //1995年7月1日生产到2004年9月1日生产的重型汽车
                        {
                            //H_HC_XZ = 900;
                            //H_CO_XZ = 3.0f;
                            //L_HC_XZ = 1200;
                            //L_CO_XZ = 4.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.HzxDate1995070120040901HC);
                            H_CO_XZ = float.Parse(sds_xzgb.HzxDate1995070120040901CO);
                            L_HC_XZ = float.Parse(sds_xzgb.zxDate1995070120040901HC);
                            L_CO_XZ = float.Parse(sds_xzgb.zxDate1995070120040901CO);
                        }
                        else
                        {
                            //H_HC_XZ = 200;
                            //H_CO_XZ = 0.7f;
                            //L_HC_XZ = 250;
                            //L_CO_XZ = 1.5f;
                            H_HC_XZ = float.Parse(sds_xzgb.HzxDate20040901HC);
                            H_CO_XZ = float.Parse(sds_xzgb.HzxDate20040901CO);
                            L_HC_XZ = float.Parse(sds_xzgb.zxDate20040901HC);
                            L_CO_XZ = float.Parse(sds_xzgb.zxDate20040901CO);
                        }
                        break;
                }
                λ_XZ = "1.00±0.03";
                ini.INIIO.saveLogInf("车辆限值：HC_HIGH:" + H_HC_XZ.ToString() + "|CO_HIGH:" + H_CO_XZ.ToString() + "|HC_LOW:" + L_HC_XZ.ToString() + "|CO_LOW:" + L_CO_XZ.ToString());
                
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("初始化排放限值异常：" + er.Message);
                Msg(labelTS, panelTS, "初始化排放限值出错，请检查被检车辆信息是否正确！");
            }
        }
        private void buttonStartWqTest_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime nowtime = DateTime.Now;
                TimeSpan timespan = nowtime - clickstarttime;
                if (timespan.TotalSeconds > 2)
                {
                    /*if (carAtWait.sfjccs)
                    {
                        if (!isSpeedFinished)
                        {
                            MessageBox.Show("该车车速还未检测,请先进行车速检测", "系统提示");
                            return;
                        }
                    }
                    if (carAtWait.sfjcdyn)
                    {
                        if (!isDynFinished)
                        {
                            MessageBox.Show("该车动力性还未检测,请先进行动力性检测", "系统提示");
                            return;
                        }
                    }
                    if (carAtWait.sfjcfuel)
                    {
                        if (!isFuelFinished)
                        {
                            MessageBox.Show("该车油耗还未检测,请先进行油耗检测", "系统提示");
                            return;
                        }
                    }*/
                    clickstarttime = nowtime;
                    ini.INIIO.saveLogInf(carAtWait.clhp + "将进行" + carAtWait.wqjcff + "检测");
                    switch (carAtWait.wqjcff)
                    {
                        case "ZYJS":
                            Init_ZyjsLimit();
                            break;
                        case "SDS":
                            Init_SdsLimit();
                            break;
                        default: break;
                    }
                    init_CarConfig();
                    ini.INIIO.saveLogInf("点击开始测量");
                    hjjcsj = DateTime.Now;
                    carbj.JCRQ = hjjcsj;
                    carbj.JCGWH = mainPanel.lineid;
                    carbj.JCZBH = mainPanel.stationinfmodel.STATIONID;
                    jcbgbh = carbj.JCBGBH;
                    ini.INIIO.saveLogInf("流水号：" + jcbgbh);
                    switch (carbj.JCFF)
                    {
                        case "ZYJS":
                            Process.Start("D://环保检测子程序/zyjsTest.EXE", "auto");
                            hjexeName = "zyjsTest";
                            break;
                        case "SDS":
                            Process.Start("D://环保检测子程序/sds.EXE", "auto");
                            hjexeName = "sds";
                            break;
                        default: break;
                    }

                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "操作日志";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "开始检测车辆" + carbj.CLHP + ",驾控员:" + carbj.JSY + ",检测方法：" + carbj.JCFF;
                    mainPanel.worklogdata.State = "成功";
                    mainPanel.worklogdata.Result = "";
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    ini.INIIO.saveLogInf("检测方法：" + carbj.JCFF);
                    th_hjwait = new Thread(waitHjTestFinished);
                    th_hjwait.Start();
                    ini.INIIO.saveLogInf("开始检测");
                    File.Delete(@"D:\DYN\TestVeh.xml");
                    File.Delete(@"D:\DYN\TestStart.ini");
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("点击开始测量时出现异常:" + er.Message);
            }


        }
        private string saveZyjsDataSeconds(DataTable dtSeconds, string dt_clid, string dt_clhp, DateTime dt_hjjcsj, out double fdjyw)
        {
            try
            {
                BTGseconds model = new BTGseconds();

                model.JYLSH = carbj.JYLSH;
                model.JYCS = carbj.JCCS;
                model.CYDS = (dtSeconds.Rows.Count - 1).ToString();
                model.CLID = dt_clid;
                model.CLHP = dt_clhp;
                model.JCSJ = dt_hjjcsj;
                double yw = 0;
                int count = 0;
                for (int i = 1; i < dtSeconds.Rows.Count; i++)
                {
                    DataRow dr = dtSeconds.Rows[i];
                    model.MMTIME += dr["全程时序"].ToString() + ",";
                    model.MMSX += dr["采样时序"].ToString() + ",";
                    model.MMLB += dr["时序类别"].ToString() + ",";
                    model.MMYDZDS += dr["烟度值读数"].ToString() + ",";
                    model.MMFDJZS += dr["发动机转速"].ToString() + ",";
                    model.MMYW += dr["油温"].ToString() + ",";
                    yw += double.Parse(dr["油温"].ToString());
                    count++;
                }
                if (count > 0)
                    yw = yw / count;
                fdjyw = yw;
                ZYJSseconds zyjsmodel = new ZYJSseconds();
                zyjsmodel.JYLSH = carbj.JYLSH;
                zyjsmodel.JYCS = carbj.JCCS;
                zyjsmodel.CYDS = (dtSeconds.Rows.Count - 1).ToString();
                zyjsmodel.CLID = model.CLID;
                zyjsmodel.CLHP = model.CLHP;
                zyjsmodel.JCSJ = dt_hjjcsj;
                zyjsmodel.MMTIME = model.MMTIME.Remove(model.MMTIME.Length - 1);
                zyjsmodel.MMSX = model.MMSX.Remove(model.MMSX.Length - 1);
                zyjsmodel.MMLB = model.MMLB.Remove(model.MMLB.Length - 1);
                zyjsmodel.MMZS = model.MMFDJZS.Remove(model.MMFDJZS.Length - 1);
                zyjsmodel.MMK = model.MMYDZDS.Remove(model.MMYDZDS.Length - 1);
                if (zyjsdal.Save_ZYJSseconds(zyjsmodel) > 0)
                    ini.INIIO.saveLogInf("过程数据保存本地成功");
                else
                    ini.INIIO.saveLogInf("过程数据保存本地失败");
                return "过程数据上传环保局成功";
                
            }
            catch (Exception er)
            {
                fdjyw = 0;
                ini.INIIO.saveLogInf("处理BTG过程数据时发生异常：" + er.Message);
                return "过程数据上传发生异常";
            }
            //if (zyjsdal.Save_BTGSseconds(model) > 0)
            //    return "过程数据上传成功";
            //else
            //    return "过程数据上传服务器失败";
        }
        private string saveSdsDataSeconds(DataTable dtSeconds, string dt_clid, string dt_clhp, DateTime dt_hjjcsj, out string fdjdszs, out string ddsjywd, out string gdszs, out string gdsjywd, out string yw)
        {
            try
            {
                SDSseconds model = new SDSseconds();

                model.JYLSH = carbj.JYLSH;
                model.JYCS = carbj.JCCS;
                model.CYDS = (dtSeconds.Rows.Count - 1).ToString();
                model.CLID = dt_clid;
                model.CLHP = dt_clhp;
                model.JCSJ = dt_hjjcsj;
                string mmco = "";
                string mmhc = "";
                string mmco2 = "";
                string mmo2 = "";
                string mmlamda = "";
                string mmzs = "";
                string mmgklx = "";
                string mmyw = "";
                string mmsxlb = "";
                string mmdjccy = "";
                int count = 0;
                float fdjdszsf = 0, ddsjywdf = 0, gdszsf = 0, gdsjywdf = 0, ywf = 0;
                for (int i = 1; i < dtSeconds.Rows.Count; i++)
                {
                    DataRow dr = dtSeconds.Rows[i];
                    model.MMTIME += dr["全程时序"].ToString() + ",";
                    model.MMSX += dr["采样时序"].ToString() + ",";
                    model.MMLB += dr["时序类别"].ToString() + ",";
                    model.MMHC += dr["HC"].ToString() + ",";
                    model.MMCO += dr["CO"].ToString() + ",";
                    model.MMCO2 += dr["CO2"].ToString() + ",";
                    model.MMO2 += dr["O2"].ToString() + ",";
                    model.MMLAMDA += dr["过量空气系数"].ToString() + ",";
                    model.MMWD += dr["环境温度"].ToString() + ",";
                    model.MMSD += dr["相对湿度"].ToString() + ",";
                    model.MMDQY += dr["大气压力"].ToString() + ",";
                    model.MMZS += dr["转速"].ToString() + ",";
                    model.MMYW += dr["油温"].ToString() + ",";
                    if (dr["时序类别"].ToString() == "2")
                    {
                        count++;
                        gdszsf += float.Parse(dr["转速"].ToString());
                        gdsjywdf += float.Parse(dr["油温"].ToString());
                        mmhc += dr["HC"].ToString() + ",";
                        mmco += dr["CO"].ToString() + ",";
                        mmzs += dr["转速"].ToString() + ",";
                        mmlamda += dr["过量空气系数"].ToString() + ",";
                        mmyw += dr["油温"].ToString() + ",";
                        mmsxlb += "1,";
                    }
                    else if (dr["时序类别"].ToString() == "4")
                    {
                        fdjdszsf += float.Parse(dr["转速"].ToString());
                        ddsjywdf += float.Parse(dr["油温"].ToString());
                        count++;
                        gdsjywdf += float.Parse(dr["油温"].ToString());
                        mmhc += dr["HC"].ToString() + ",";
                        mmco += dr["CO"].ToString() + ",";
                        mmzs += dr["转速"].ToString() + ",";
                        mmlamda += dr["过量空气系数"].ToString() + ",";
                        mmyw += dr["油温"].ToString() + ",";
                        mmsxlb += "0,";
                    }
                    else
                        mmsxlb += "0,";

                }
                gdszsf = gdszsf / 30;
                fdjdszsf = fdjdszsf / 30f;
                gdsjywdf = gdsjywdf / 30;
                ddsjywdf = ddsjywdf / 30f;
                ywf = (gdsjywdf + ddsjywdf) / 2f;
                gdszs = gdszsf.ToString("0");
                fdjdszs = fdjdszsf.ToString("0");
                gdsjywd = gdsjywdf.ToString("0.0");
                ddsjywd = ddsjywdf.ToString("0.0");
                yw = ywf.ToString("0.0");
                
                if (sdsdal.Save_SDSSseconds(model) > 0)
                    return "过程数据上传成功";
                else
                    return "过程数据上传服务器失败";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("处理SDS过程数据时发生异常：" + er.Message);
                throw;
            }
        }

        private bool zyjsResultPd(carinfor.zyjsBtgdata zyjs_data)
        {
            zyjsdata.CLID = carbj.CLID;//1
            zyjsdata.CLPH = carbj.CLHP;
            zyjsdata.FIRSTDATA = zyjs_data.FirstData;
            zyjsdata.SECONDDATA = zyjs_data.SecondData;
            zyjsdata.THIRDDATA = zyjs_data.ThirdData;
            zyjsdata.FOURTHDATA = zyjs_data.PrepareData;
            zyjsdata.AVERAGEDATA = ((float.Parse(zyjs_data.FirstData) + float.Parse(zyjs_data.SecondData) + float.Parse(zyjs_data.ThirdData)) / 3f).ToString("0.00");//6
            zyjsdata.YDXZ = btgxz.ToString("0.00");
            zyjsdata.DSZS = zyjs_data.Dszs;
            zyjsdata.YW = zyjs_data.Yw;
            zyjsdata.JCRQ = hjjcsj;
            zyjsdata.WD = zyjs_data.Wd;
            zyjsdata.SD = zyjs_data.Sd;
            zyjsdata.DQY = zyjs_data.Dqy;//16
            zyjsdata.SBMC = mainPanel.equipmodel.SBMC;
            zyjsdata.SBXH = mainPanel.equipmodel.SBXH;
            zyjsdata.SBZZC = mainPanel.equipmodel.SBZZC;
            zyjsdata.YDJXH = mainPanel.equipmodel.YDJXH;
            zyjsdata.YDJBH = mainPanel.equipmodel.YDJBH;
            zyjsdata.YDJZZC = mainPanel.equipmodel.YDJZZC;
            zyjsdata.ZSJXH = mainPanel.equipmodel.ZSJXH;
            zyjsdata.ZSJBH = mainPanel.equipmodel.ZSJBH;
            zyjsdata.ZSJZZC = mainPanel.equipmodel.ZSJZZC;
            zyjsdata.JYLSH = carbj.JYLSH;
            zyjsdata.JYCS = carbj.JCCS;
            zyjsdata.SBRZBM = mainPanel.linemodel.JCXXKZBH;
            if ((float.Parse(zyjs_data.FirstData) + float.Parse(zyjs_data.SecondData) + float.Parse(zyjs_data.ThirdData)) / 3.0f > btgxz)
            {
                zyjsdata.YDPD = "不合格";
                zyjsdata.ZHPD = "不合格";//11
                return false;
            }
            else
            {
                zyjsdata.YDPD = "合格";
                zyjsdata.ZHPD = "合格";//11
                return true;
            }
        }
        private bool sdsResultPd(carinfor.sdsdata sds_data, out string nhlambdapd)
        {

            sdsdata.CLID = carbj.CLID;//1
            sdsdata.CLPH = carbj.CLHP;
            sdsdata.COLOWCLZ = sds_data.Co_low;
            sdsdata.COLOWXZ = L_CO_XZ.ToString("0.00");
            sdsdata.HCLOWCLZ = float.Parse(sds_data.Hc_low).ToString("0");
            sdsdata.HCLOWXZ = L_HC_XZ.ToString("0");
            sdsdata.COHIGHCLZ = sds_data.Co_high;
            sdsdata.COHIGHXZ = H_CO_XZ.ToString("0.00");
            sdsdata.HCHIGHCLZ = float.Parse(sds_data.Hc_high).ToString("0");
            sdsdata.HCHIGHXZ = H_HC_XZ.ToString("0");
            sdsdata.LAMDAHIGHCLZ = sds_data.λ_value;//11
            sdsdata.LAMDAHIGHXZ = λ_XZ;//11            
            sdsdata.JCRQ = hjjcsj;
            sdsdata.WD = sds_data.Wd;
            sdsdata.SD = sds_data.Sd;
            sdsdata.DQY = sds_data.Dqy;//16
            sdsdata.SBMC = mainPanel.equipmodel.SBMC;
            sdsdata.SBXH = mainPanel.equipmodel.SBXH;
            sdsdata.SBZZC = mainPanel.equipmodel.SBZZC;
            sdsdata.ZSJXH = mainPanel.equipmodel.ZSJXH;
            sdsdata.ZSJBH = mainPanel.equipmodel.ZSJBH;
            sdsdata.ZSJZZC = mainPanel.equipmodel.ZSJZZC;
            sdsdata.FXYXH = mainPanel.equipmodel.FXYXH;
            sdsdata.FXYBH = mainPanel.equipmodel.FXYBH;
            sdsdata.FXYZZC = mainPanel.equipmodel.FXYZZC;
            sdsdata.CO2HIGH = sds_data.Co2_high;
            sdsdata.O2HIGH = sds_data.O2_high;
            sdsdata.CO2LOW = sds_data.Co2_low;
            sdsdata.O2LOW = sds_data.O2_low;
            sdsdata.JYLSH = carbj.JYLSH;
            sdsdata.JYCS = carbj.JCCS;
            sdsdata.SBRZBM = mainPanel.linemodel.JCXXKZBH;
            if (float.Parse(sds_data.Co_low) <= L_CO_XZ)
            {
                sdsdata.COLOWPD = "合格";
            }
            else
            {
                sdsdata.COLOWPD = "不合格";
            }
            if (float.Parse(sds_data.Hc_low) <= L_HC_XZ)
            {
                sdsdata.HCLOWPD = "合格";
            }
            else
            {
                sdsdata.HCLOWPD = "不合格";
            }
            if (sdsdata.COLOWPD == "合格" && sdsdata.HCLOWPD == "合格")
                sdsdata.LOWPD = "合格";
            else
                sdsdata.LOWPD = "不合格";
            if (float.Parse(sds_data.Co_high) <= H_CO_XZ)
            {
                sdsdata.COHIGHPD = "合格";
            }
            else
            {
                sdsdata.COHIGHPD = "不合格";
            }
            if (float.Parse(sds_data.Hc_high) <= H_HC_XZ)
            {
                sdsdata.HCHIGHPD = "合格";
            }
            else
            {
                sdsdata.HCHIGHPD = "不合格";
            }
            if (sdsdata.COHIGHPD == "合格" && sdsdata.HCHIGHPD == "合格")
                sdsdata.HIGHPD = "合格";
            else
                sdsdata.HIGHPD = "不合格";
            if (float.Parse(sds_data.λ_value) <= 1.03f && float.Parse(sds_data.λ_value) >= 0.97f)
                sdsdata.LAMDAHIGHPD = "合格";
            else
                sdsdata.LAMDAHIGHPD = "不合格";
            nhlambdapd = sdsdata.LAMDAHIGHPD;
            
                if (carAtWait.pqhclzz)
                {

                    if (sdsdata.LOWPD == "合格" && sdsdata.HIGHPD == "合格" && sdsdata.LAMDAHIGHPD == "合格")
                    {
                        sdsdata.ZHPD = "合格";
                        return true;
                    }
                    else
                    {
                        sdsdata.ZHPD = "不合格";
                        return false;
                    }

                }
                else
                {
                    sdsdata.LAMDAHIGHPD = "";
                    if (sdsdata.LOWPD == "合格" && sdsdata.HIGHPD == "合格")
                    {
                        sdsdata.ZHPD = "合格";
                        return true;
                    }
                    else
                    {
                        sdsdata.ZHPD = "不合格";
                        return false;
                    }
                }
        }
        private bool saveBjclInf( CARATWAIT modelWait, string jcjg)
        {
            try
            {
                //mainPanel.lshmodel = mainPanel.stationcontrol.getLineLshInf(mainPanel.stationid, mainPanel.lineid);
                //int lshcount = int.Parse(mainPanel.lshmodel.COUNT);
                CARDETECTED model = new CARDETECTED();
                carinfor.resultData resultdata = new carinfor.resultData();
                string jcgcsj = hjjcsj.ToString("yyyy-MM-dd HH:mm:ss") + "-" + hjjssj.ToString("HH:mm:ss");
                model.jcgcsj = jcgcsj;
                model.wjy = "";
                
                {
                    model.CLID = modelWait.CLID;
                    model.STATIONID = mainPanel.stationid;
                    model.LINEID = mainPanel.lineid;
                    model.ZXBZ = zxbz;
                    model.DLSJ = modelWait.DLSJ;
                    model.JCSJ = hjjcsj;
                    model.JCFF = modelWait.JCFF;
                    model.XSLC = modelWait.XSLC;
                    model.JCJG = jcjg;
                    model.JCCS = modelWait.JCCS;
                    model.LSH = modelWait.JCBGBH;
                    model.CLHP = modelWait.CLHP;//1
                    model.CPYS = modelWait.CPYS;
                    model.CLLX = carAtWait.cllx;// modelInf.CLLX;
                    model.CZ ="";
                    model.SYXZ = carAtWait.syxz; //modelInf.SYXZ;
                    model.PP ="";//5
                    model.XH ="";
                    model.CLSBM = "";
                    model.FDJHM = "";
                    model.FDJXH = "";
                    model.SCQY = "";
                    model.HDZK = carAtWait.zkrs.ToString();
                    model.JSSZK = "";
                    model.ZZL = carAtWait.zzl.ToString();
                    model.HDZZL = "";
                    model.ZBZL = carAtWait.zbzl.ToString();
                    model.JZZL = carAtWait.jzzl.ToString();
                    model.ZCRQ = carAtWait.scrq;
                    model.SCRQ =carAtWait.scrq;
                    model.FDJPL = "";
                    model.RLZL = carAtWait.rlzl; //modelInf.RLZL;//20
                    model.EDGL =carAtWait.edgl.ToString();
                    model.EDZS = carAtWait.edzs.ToString();
                    model.BSQXS = ""; //modelInf.BSQXS;
                    model.DWS = "";
                    model.GYFS = ""; //modelInf.GYFS;//25
                    model.DPFS = "";
                    model.JQFS = carAtWait.jqfs;
                    model.QGS = "";
                    model.QDXS = "";
                    model.CHZZ = "";
                    model.DLSP = "";
                    model.SFSRL = "";
                    model.JHZZ = carAtWait.pqhclzz ? "有" : "无";
                    model.OBD = "";
                    model.DKGYYB = "";
                    model.LXDH = "";
                    model.CZY = modelWait.CZY;
                    model.JSY = modelWait.JSY;
                    model.DLY = modelWait.DLY;//35
                    model.JCZMC = mainPanel.thisLineName;
                    model.JCFY = modelWait.JCFY;
                    model.SFJF = "N";
                    model.TEST = modelWait.TEST;
                    model.HPZL = modelWait.HPZL;
                    model.QDLTQY = "";
                    model.RYPH = "";
                }
                model.BGFFYY = modelWait.BGJCFFYY;
                resultdata.Clhp = model.CLHP;
                resultdata.Jcsj = model.JCSJ.ToString("yyyy年MM月dd日 HH:mm:SS");
                resultdata.Jcjg = jcjg;
                carini.writeResultData(resultdata);
                mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                mainPanel.worklogdata.ProjectName = "操作日志";
                mainPanel.worklogdata.Stationid = mainPanel.stationid;
                mainPanel.worklogdata.Lineid = mainPanel.lineid;
                mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                mainPanel.worklogdata.Data = "车辆" + carbj.CLHP + "检测完毕(" + model.JCJG + ")" + ",驾控员:" + carbj.JSY + ",检测方法：" + carbj.JCFF;
                mainPanel.worklogdata.State = "成功";
                mainPanel.worklogdata.Result = "";
                mainPanel.worklogdata.Date = DateTime.Now;
                mainPanel.worklogdata.Bzsm = "";
                mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                return (mainPanel.logininfcontrol.saveCarbj(model));
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("保存车辆检测信息异常：" + er.Message);
                return false;
            }
        }
        private void waitHjTestFinished()
        {
            try
            {
                string CrucialTime0 = "";
                string CrucialTime1 = "";
                string CrucialTime2 = "";
                string CrucialTime3 = "";
                string CrucialTime4 = "";
                string newPath = "C://jcdatatxt/" + carbj.CLID + ".ini";
                string newCsvPath = "C://jcdatatxt/" + carbj.CLID + ".csv";
                string newStatusPath = "C://jcdatatxt/statusConfig.ini";//安车及其他平台上的状态文件
                string neuStatusPath = "C://jcdatatxt/neustatusConfig.ini";//东软平台上的状态文件
                string newAhCsvPath = "C://jcdatatxt/" + carbj.CLID + "ah.csv";
               
                while (mainPanel.processalive)
                {
                    Thread.Sleep(200);

                    if (IsProcessStarted(hjexeName))
                    {
                        if (File.Exists(newPath))
                        {

                            #region 查询到数据文件
                            ini.INIIO.saveLogInf("waitTestFinished()进程中查询到\"" + newPath + "\"存在");
                            Thread.Sleep(500);//等待两秒以确保文件内容写完
                            hjjssj = DateTime.Now;
                            switch (carbj.JCFF)
                            {
                                case "ZYJS":
                                    #region 自由加速
                                    ini.INIIO.saveLogInf("将结果文件复制到位置：" + "D://dataseconds/" + carbj.CLID + ".ini");
                                    string btginifileDir = "D://dataseconds/" + DateTime.Now.ToString("yyMMdd");
                                    if (ini.INIIO.createDir(btginifileDir))
                                        File.Copy(newPath, btginifileDir + "/" + carbj.CLID + ".ini", true);
                                    zyjs_data = zyjsdatacontrol.readZyjsData(newPath);
                                    if (zyjs_data.FirstData == "-1")
                                    {
                                        #region 检测终止
                                        ini.INIIO.saveLogInf("设备未完成检测退出,无检测结果数据");
                                        mainPanel.ts1 = "设备未完成检测退出";
                                        mainPanel.ts2 = "无检测结果数据";
                                        Msg(labelTS, panelTS, "设备未完成检测退出,无检测结果数据");
                                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                                        mainPanel.worklogdata.ProjectName = "操作日志";
                                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                                        mainPanel.worklogdata.Data = "车辆" + carbj.CLHP + "检测中止" + ",驾控员:" + carbj.JSY + ",检测方法：" + carbj.JCFF;
                                        mainPanel.worklogdata.State = "中止";
                                        mainPanel.worklogdata.Result = "";
                                        mainPanel.worklogdata.Date = DateTime.Now;
                                        mainPanel.worklogdata.Bzsm = "";
                                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                                        #endregion
                                    }
                                    else
                                    {
                                        #region 检测有效
                                        ini.INIIO.saveLogInf("检测完成，检测结果数据有效");
                                        mainPanel.ts1 = "检测完成";
                                        string isCsvAlive = "";
                                        double fdjyw = 0;
                                        string pdjg = "";
                                        DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                        if (dataseconds != null)
                                        {
                                            string fileDir = "D://dataseconds/" + DateTime.Now.ToString("yyMMdd");
                                            if (ini.INIIO.createDir(fileDir))
                                                File.Copy(newCsvPath, fileDir + "/" + carbj.CLID + ".csv", true);
                                            ini.INIIO.saveLogInf("过程数据复制到位置：" + fileDir + "/" + carbj.CLID + ".csv");
                                            isCsvAlive = saveZyjsDataSeconds(dataseconds, carbj.CLID, carbj.CLHP, hjjcsj, out fdjyw);
                                            ini.INIIO.saveLogInf("过程数据保存到数据库成功");

                                            {
                                                #region 其他
                                                ini.INIIO.saveLogInf("判定检测结果");
                                                string hjjg = "";
                                                if (zyjsResultPd(zyjs_data) == true)
                                                {
                                                    ini.INIIO.saveLogInf("检测结果：合格");
                                                    mainPanel.ts2 = mainPanel.equipconfig.displayJudge ? "车辆检测合格" : "车辆驶离";
                                                    Msg(labelTS, panelTS, "车辆检测合格");
                                                    hjjg = "合格";
                                                    saveBjclInf(carbj, "合格");
                                                }
                                                else
                                                {
                                                    ini.INIIO.saveLogInf("检测结果：不合格");
                                                    mainPanel.ts2 = mainPanel.equipconfig.displayJudge ? "车辆检测不合格" : "车辆驶离";
                                                    Msg(labelTS, panelTS, "车辆检测不合格");
                                                    hjjg = "不合格";
                                                    saveBjclInf(carbj, "不合格");
                                                }
                                                zyjsdata.JCBGBH = jcbgbh;
                                                zyjsdata.SHY = mainPanel.shy;
                                                zyjsdata.SYNCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                zyjsdata.JCKSSJ = hjjcsj.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                zyjsdata.JCJSSJ = hjjssj.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                zyjsdata.JCFF = "GB3847-2005";
                                                ini.INIIO.saveLogInf("保存BTG检测结果到数据库");
                                                zyjsdal.Save_Zyjs_Btg(zyjsdata);
                                                ini.INIIO.saveLogInf("车辆检测结果保存成功");
                                                isWqFinished = true;
                                                Label_Msg(labelWq, "完成");
                                                if (isSpeedFinished&&isFuelFinished&&isDynFinished)
                                                {
                                                    Msg(labelTS, panelTS, "检测完成");
                                                    writeResultFile();
                                                    //File.Delete(@"D:\DYN\TestVeh.xml");//删除安车车辆信息
                                                    File.Delete(@"C:\jcdatatxt\carinfo.ini");//删除本地车辆信息
                                                }
                                                else
                                                {
                                                    Msg(labelTS, panelTS, "环检检测完成：" + hjjg + "，请继续检测其他项目");
                                                    File.Delete(@"C:\jcdatatxt\carinfo.ini");//删除本地车辆信息 }

                                                }
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("逐秒数据读取失败");
                                            isCsvAlive = "逐秒数据读取失败";
                                            Msg(labelTS, panelTS, "未找到过程数据，检测无效");
                                        }
                                        #endregion
                                    }
                                    File.Delete(newPath);
                                    ini.INIIO.saveLogInf("删除结果文件：" + newPath);
                                    break;
                                #endregion
                                case "SDS":
                                    #region 双怠速
                                    ini.INIIO.saveLogInf("将结果文件复制到位置：" + "D://dataseconds/" + carbj.CLID + ".ini");
                                    string sdsinifileDir = "D://dataseconds/" + DateTime.Now.ToString("yyMMdd");
                                    if (ini.INIIO.createDir(sdsinifileDir))
                                        File.Copy(newPath, sdsinifileDir + "/" + carbj.CLID + ".ini", true);
                                    sds_data = sdsdatacontrol.readSdsData(newPath);
                                    if (sds_data.Co_low == "-1")
                                    {
                                        #region 检测中止
                                        ini.INIIO.saveLogInf("设备未完成检测退出,无检测结果数据");
                                        mainPanel.ts1 = "设备未完成检测退出";
                                        mainPanel.ts2 = "无检测结果数据";
                                        if (mainPanel.isNetUsed)

                                            Msg(labelTS, panelTS, "设备未完成检测退出,无检测结果数据");
                                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                                        mainPanel.worklogdata.ProjectName = "操作日志";
                                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                                        mainPanel.worklogdata.Data = "车辆" + carbj.CLHP + "检测中止" + ",驾控员:" + carbj.JSY + ",检测方法：" + carbj.JCFF;
                                        mainPanel.worklogdata.State = "中止";
                                        mainPanel.worklogdata.Result = "";
                                        mainPanel.worklogdata.Date = DateTime.Now;
                                        mainPanel.worklogdata.Bzsm = "";
                                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                                        #endregion
                                    }
                                    else
                                    {
                                        #region 检测有效

                                        ini.INIIO.saveLogInf("检测完成，检测结果数据有效");
                                        mainPanel.ts1 = "检测完成";
                                        string isCsvAlive = "";
                                        DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                        string fdjdszs = "0";
                                        string ddsjywd = "0";
                                        string gdszs = "0";
                                        string gdsjywd = "0";
                                        string yw = "0";
                                        string pdjg = "";
                                        string nhlambdapd = "";
                                        if (dataseconds != null)
                                        {
                                            ini.INIIO.saveLogInf("查询到过程数据");
                                            string fileDir = "D://dataseconds/" + DateTime.Now.ToString("yyMMdd");
                                            if (ini.INIIO.createDir(fileDir))
                                                File.Copy(newCsvPath, fileDir + "/" + carbj.CLID + ".csv", true);
                                            ini.INIIO.saveLogInf("过程数据复制到位置：" + fileDir + "/" + carbj.CLID + ".csv");
                                            isCsvAlive = saveSdsDataSeconds(dataseconds, carbj.CLID, carbj.CLHP, hjjcsj, out fdjdszs, out ddsjywd, out gdszs, out gdsjywd, out yw);
                                            ini.INIIO.saveLogInf("过程数据保存到数据库成功");

                                            #region 其他
                                            ini.INIIO.saveLogInf("判定检测结果");
                                            string hjjg;
                                            if (sdsResultPd(sds_data, out nhlambdapd) == true)
                                            {
                                                ini.INIIO.saveLogInf("检测结果：合格");
                                                mainPanel.ts2 = mainPanel.equipconfig.displayJudge ? "车辆检测合格" : "车辆驶离";
                                                Msg(labelTS, panelTS, "车辆检测合格" + isCsvAlive);
                                                hjjg = "合格";
                                                saveBjclInf(carbj, "合格");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("检测结果：不合格");
                                                mainPanel.ts2 = mainPanel.equipconfig.displayJudge ? "车辆检测不合格" : "车辆驶离";
                                                Msg(labelTS, panelTS, "车辆检测不合格" + isCsvAlive);
                                                saveBjclInf(carbj, "不合格");
                                                hjjg = "不合格";
                                            }
                                            sdsdata.ZSLOW = fdjdszs;
                                            sdsdata.ZSHIGH = gdszs;
                                            sdsdata.JYWDLOW = ddsjywd;
                                            sdsdata.JYWDHIGH = gdsjywd;
                                            sdsdata.YW = yw;
                                            sdsdata.GLKQXSSX = "1.03";
                                            sdsdata.GLKQXSXX = "0.97";
                                            sdsdata.JCBGBH = jcbgbh;
                                            sdsdata.SHY = mainPanel.shy;
                                            sdsdata.SYNCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            sdsdata.JCKSSJ = hjjcsj.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            sdsdata.JCJSSJ = hjjssj.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            ini.INIIO.saveLogInf("保存SDS检测结果到数据库");
                                            sdsdal.Save_SDS(sdsdata);
                                            isWqFinished = true;
                                            Label_Msg(labelWq, "完成");
                                            if (isSpeedFinished && isFuelFinished && isDynFinished)
                                            {
                                                Msg(labelTS, panelTS, "检测完成");
                                                writeResultFile();
                                                //File.Delete(@"D:\DYN\TestVeh.xml");//删除安车车辆信息
                                                File.Delete(@"C:\jcdatatxt\carinfo.ini");//删除本地车辆信息
                                            }
                                            else
                                            {
                                                Msg(labelTS, panelTS, "环检检测完成：" + hjjg + "，请继续检测其他项目");
                                                File.Delete(@"C:\jcdatatxt\carinfo.ini");//删除本地车辆信息 }

                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("逐秒数据读取失败");
                                            isCsvAlive = "逐秒数据读取失败";
                                            Msg(labelTS, panelTS, "没有找到过程数据，检测无效");
                                        }
                                        #endregion
                                    }
                                    File.Delete(newPath);
                                    ini.INIIO.saveLogInf("删除结果文件：" + newPath);
                                    break;
                                #endregion
                                default: break;
                            }

                            #endregion

                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("处理检测结果进行过程出现异常：" + er.Message);
                //mainPanel.ts2 = "发生";
                //this.Close();
            }
        }
        private void init_CarConfig()
        {
            float a = 0;
            int b = 0;
            compendata = mainPanel.logininfcontrol.getLineCompensationData(mainPanel.lineid);
            if (mainPanel.logininfcontrol.checkCLHPIsInSpecialList(carAtWait.clhp, DateTime.Now))
            {
                ini.INIIO.saveLogInf("该车在SpecialVehicleList中");
                carinidata.ASM_CO = 0.5;
                carinidata.ASM_HC = 0.5;
                carinidata.ASM_NO = 0.5;
                carinidata.VMAS_CO = 0.5;
                carinidata.VMAS_HC = 0.5;
                carinidata.VMAS_NO = 0.5;
                carinidata.SDS_CO = 0.5;
                carinidata.SDS_HC = 0.5;
                carinidata.ZYJS_K = 0.3;
                carinidata.JZJS_K = 0.3;
                carinidata.JZJS_GL = 1.3;
                carinidata.ISUSE = true;
            }
            else if (compendata.ISUSE)
            {
                ini.INIIO.saveLogInf("该线为设置为SpecialLine");
                carinidata.ASM_CO = compendata.ASM_CO;
                carinidata.ASM_HC = compendata.ASM_HC;
                carinidata.ASM_NO = compendata.ASM_NO;
                carinidata.VMAS_CO = compendata.VMAS_CO;
                carinidata.VMAS_HC = compendata.VMAS_HC;
                carinidata.VMAS_NO = compendata.VMAS_NO;
                carinidata.SDS_CO = compendata.SDS_CO;
                carinidata.SDS_HC = compendata.SDS_HC;
                carinidata.ZYJS_K = compendata.ZYJS_K;
                carinidata.JZJS_K = compendata.JZJS_K;
                carinidata.JZJS_GL = compendata.JZJS_GL;
                carinidata.ISUSE = true;
            }
            else
            {
                ini.INIIO.saveLogInf("该线正常");
                carinidata.ASM_CO = 1;
                carinidata.ASM_HC = 1;
                carinidata.ASM_NO = 1;
                carinidata.VMAS_CO = 1;
                carinidata.VMAS_HC = 1;
                carinidata.VMAS_NO = 1;
                carinidata.SDS_CO = 1;
                carinidata.SDS_HC = 1;
                carinidata.ZYJS_K = 1;
                carinidata.JZJS_K = 1;
                carinidata.JZJS_GL = 1;
                carinidata.ISUSE = false;
            }
            carinidata.CarID = carAtWait.jclsh;
            carinidata.CarPH = carAtWait.clhp;
            if (carAtWait.jqfs.Contains("自然") )
            {
                carinidata.jqfs = "0";
            }
            else
            {
                carinidata.jqfs = "1";
            }
                carinidata.CarJzzl = carAtWait.jzzl;
            carinidata.CarZzl =(int)( carAtWait.zzl);
            if (carAtWait.rlzl.Contains("汽油"))
                carinidata.CarRlzl = "1";
            else if (carAtWait.rlzl.Contains("柴油"))
                carinidata.CarRlzl = "2";
            else if (carAtWait.rlzl.Contains("液化石油气"))
                carinidata.CarRlzl = "3";
            else if (carAtWait.rlzl.Contains("天然气"))
                carinidata.CarRlzl = "4";
            else
                carinidata.CarRlzl = "1";
            carinidata.CarEdgl = (float)carAtWait.edgl;
            carinidata.CarEdzs = (float)carAtWait.edzs;
            carinidata.CarBsxlx = "1";
            carinidata.CarLxcc = 3;
            carinidata.CarLjcc = 15;

            carinidata.CarNdz = 6;
            carinidata.CarCc = "2";
            if (carbj.JCFF == "ASM")
            {
                carinidata.Xz1 = hc5025;
                carinidata.Xz2 = co5025;
                carinidata.Xz3 = no5025;
                carinidata.Xz4 = hc2540;
                carinidata.Xz5 = co2540;
                carinidata.Xz6 = no2540;
            }
            else if (carbj.JCFF == "VMAS")
            {
                if (beforedate)
                {
                    carinidata.Xz1 = 1;
                    carinidata.Xz2 = Limit_CO_BEBORE;
                    carinidata.Xz3 = Limit_HC_BEBORE;
                    carinidata.Xz4 = Limit_NO_BEBORE;
                    carinidata.Xz5 = 0;
                    carinidata.Xz6 = 0;
                }
                else
                {
                    carinidata.Xz1 = 0;
                    carinidata.Xz2 = Limit_CO_AFTER;
                    carinidata.Xz3 = Limit_HCNOX_AFTER;
                    carinidata.Xz4 = 0;
                    carinidata.Xz5 = 0;
                    carinidata.Xz6 = 0;
                }
            }
            else if (carbj.JCFF == "JZJS")
            {
                carinidata.Xz1 = GLXZ;
                carinidata.Xz2 = GXXZ;
                carinidata.Xz3 = 0;
                carinidata.Xz4 = 0;
                carinidata.Xz5 = 0;
                carinidata.Xz6 = 0;
            }
            else if (carbj.JCFF == "SDS")
            {
                carinidata.Xz1 = H_CO_XZ;
                carinidata.Xz2 = H_HC_XZ;
                carinidata.Xz3 = L_CO_XZ;
                carinidata.Xz4 = L_HC_XZ;
                carinidata.Xz5 = 0;
                carinidata.Xz6 = 0;
            }
            else if (carbj.JCFF == "ZYJS")
            {
                carinidata.Xz1 = (float)btgxz;
                carinidata.Xz2 = 0;
                carinidata.Xz3 = 0;
                carinidata.Xz4 = 0;
                carinidata.Xz5 = 0;
                carinidata.Xz6 = 0;
            }
            else
            {
                carinidata.Xz1 = 0;
                carinidata.Xz2 = 0;
                carinidata.Xz3 = 0;
                carinidata.Xz4 = 0;
                carinidata.Xz5 = 0;
                carinidata.Xz6 = 0;
            }
            if (carbj.JCFF == "ASM" || carbj.JCFF == "VMAS")
            {
                
                    carinidata.AmbientCO2Up = 1f;
                    carinidata.AmbientCOUp = 1f;
                    carinidata.AmbientHCUp = 7f;
                    carinidata.AmbientNOUp = 25f;
                    carinidata.BackgroundCO2Up = 1f;
                    carinidata.BackgroundCOUp = 1f;
                    carinidata.BackgroundHCUp = 7f;
                    carinidata.BackgroundNOUp = 25f;
                    carinidata.ResidualHCUp = 7f;
            }
            else
            {
                carinidata.AmbientCO2Up = 1f;
                carinidata.AmbientCOUp = 1f;
                carinidata.AmbientHCUp = 7f;
                carinidata.AmbientNOUp = 25f;
                carinidata.BackgroundCO2Up = 1f;
                carinidata.BackgroundCOUp = 1f;
                carinidata.BackgroundHCUp = 7f;
                carinidata.BackgroundNOUp = 25f;
                carinidata.ResidualHCUp = 7f;
            }
            carbj.CLID = carAtWait.jclsh;//联网时，用外观检验号做车辆ID号
            carbj.DLSJ = DateTime.Now;
            carbj.CLHP = carAtWait.clhp;
            carbj.CPYS = carAtWait.hpzl;
            carbj.HPZL = carAtWait.hpzl;
            carbj.XSLC = "";
            carbj.JCCS = "1";
            carbj.CZY = mainPanel.nowUser.userName;
            carbj.JSY = "";
            carbj.DLY = "";
            carbj.JCFY = "";
            carbj.TEST = "";
            carbj.JCBGBH = carAtWait.jclsh;
            carbj.JCGWH = mainPanel.lineid;
            carbj.JCZBH = mainPanel.stationid; ;
            carbj.JCRQ = DateTime.Now;
            carbj.BGJCFFYY = "";
            carbj.SFCS = "";
            carbj.ECRYPT = "";
            carbj.JYLSH = "";
            carbj.SFCJ = "";
            carbj.JCFF = carAtWait.wqjcff;
            ini.INIIO.deleteDir(mainPanel.directory);
                ini.INIIO.deleteDir(@"D:\Exchange");//删除诚创联网文件交互文件夹内的所有文件
                carini.writeCarIni(carinidata, @"C:\jcdatatxt\carinfo.ini", mainPanel.directory);
        }
        public bool writeResultFile()
        {
            DataSet dt = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "RESULT", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("RESULT");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("JYLSH");//创建一个<Node>节点 
            XmlElement xe2 = xmldoc.CreateElement("HPZL");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("HPHM");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("KSSJ");//创建一个<Node>节点  
            XmlElement xe5 = xmldoc.CreateElement("JSSJ");//创建一个<Node>节点
            xe1.InnerText = carAtWait.jclsh;
            xe2.InnerText = carAtWait.hpzl;
            xe3.InnerText = carAtWait.clhp;
            xe4.InnerText = starttime.ToString("yyyy-MM-dd HH:mm:ss");
            xe5.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //xe5.InnerText = vehicleinfmodule.VIN;
            root.AppendChild(xe1);
            root.AppendChild(xe2);
            root.AppendChild(xe3);
            root.AppendChild(xe4);
            root.AppendChild(xe5);
            /************************SDS*******************/
            if (carAtWait.sfjcwq && carAtWait.wqjcff == "SDS")
            {
                XmlElement HC0 = xmldoc.CreateElement("HC0");
                HC0.InnerText = sdsdata.HCLOWCLZ;
                 XmlElement HC1 = xmldoc.CreateElement("HC1");
                HC1.InnerText = sdsdata.HCHIGHCLZ;
                XmlElement StdHC0 = xmldoc.CreateElement("StdHC0");
                StdHC0.InnerText = sdsdata.HCLOWXZ;
                XmlElement StdHC1 = xmldoc.CreateElement("StdHC1");
                StdHC1.InnerText = sdsdata.HCHIGHXZ;
                XmlElement HCEvl0 = xmldoc.CreateElement("HCEvl0");
                HCEvl0.InnerText = sdsdata.HCLOWPD=="合格"?"T":"F";
                XmlElement HCEvl1 = xmldoc.CreateElement("HCEvl1");
                HCEvl1.InnerText = sdsdata.HCHIGHPD == "合格" ? "T" : "F";
                XmlElement CO0 = xmldoc.CreateElement("CO0");
                CO0.InnerText = sdsdata.COLOWCLZ;
                XmlElement CO1 = xmldoc.CreateElement("CO1");
                CO1.InnerText = sdsdata.COHIGHCLZ;
                XmlElement StdCO0 = xmldoc.CreateElement("StdCO0");
                StdCO0.InnerText = sdsdata.COLOWXZ;
                XmlElement StdCO1 = xmldoc.CreateElement("StdCO1");
                StdCO1.InnerText = sdsdata.COHIGHXZ;
                XmlElement COEvl0 = xmldoc.CreateElement("COEvl0");
                COEvl0.InnerText = sdsdata.COLOWPD == "合格" ? "T" : "F";
                XmlElement COEvl1 = xmldoc.CreateElement("COEvl1");
                COEvl1.InnerText = sdsdata.COHIGHPD == "合格" ? "T" : "F";
                XmlElement RPM0 = xmldoc.CreateElement("RPM0");
                RPM0.InnerText = sdsdata.ZSLOW;
                XmlElement RPM1 = xmldoc.CreateElement("RPM1");
                RPM1.InnerText = sdsdata.ZSHIGH;
                XmlElement LMD = xmldoc.CreateElement("LMD");
                LMD.InnerText = sdsdata.LAMDAHIGHCLZ;
                XmlElement StdLMD0 = xmldoc.CreateElement("StdLMD0");
                StdLMD0.InnerText = "0.97";
                XmlElement StdLMD1 = xmldoc.CreateElement("StdLMD1");
                StdLMD1.InnerText = "1.03";
                XmlElement LmdEvl = xmldoc.CreateElement("LmdEvl");
                LmdEvl.InnerText =( sdsdata.LAMDAHIGHPD == "合格" ? "T" : (sdsdata.LAMDAHIGHPD == "不合格" ?"F":"-"));
                XmlElement Evl = xmldoc.CreateElement("Evl");
                Evl.InnerText = sdsdata.ZHPD == "合格" ? "T" : "F";
                root.AppendChild(HC0);
                root.AppendChild(HC1);
                root.AppendChild(StdHC0);
                root.AppendChild(StdHC1);
                root.AppendChild(HCEvl0);
                root.AppendChild(HCEvl1);
                root.AppendChild(CO0);
                root.AppendChild(CO1);
                root.AppendChild(StdCO0);
                root.AppendChild(StdCO1);
                root.AppendChild(COEvl0);
                root.AppendChild(COEvl1);
                root.AppendChild(RPM0);
                root.AppendChild(RPM1);
                root.AppendChild(LMD);
                root.AppendChild(StdLMD0);
                root.AppendChild(StdLMD1);
                root.AppendChild(LmdEvl);
                root.AppendChild(Evl);
            }
            /************************BTG*******************/
            if (carAtWait.sfjcwq && carAtWait.wqjcff == "ZYJS")
            {
                XmlElement AshSorb0 = xmldoc.CreateElement("AshSorb0");
                AshSorb0.InnerText =zyjsdata.FIRSTDATA;
                XmlElement AshSorb1 = xmldoc.CreateElement("AshSorb1");
                AshSorb1.InnerText = zyjsdata.SECONDDATA;
                XmlElement AshSorb2 = xmldoc.CreateElement("AshSorb2");
                AshSorb2.InnerText = zyjsdata.THIRDDATA;
                XmlElement AshSorbAvg = xmldoc.CreateElement("AshSorbAvg");
                AshSorbAvg.InnerText = zyjsdata.AVERAGEDATA;
                XmlElement StdSorb = xmldoc.CreateElement("StdSorb");
                StdSorb.InnerText = zyjsdata.YDXZ;
                XmlElement Evl = xmldoc.CreateElement("Evl");
                Evl.InnerText = zyjsdata.ZHPD == "合格" ? "T" : "F";
                XmlElement FDJMaxRpm = xmldoc.CreateElement("FDJMaxRpm");
                FDJMaxRpm.InnerText = zyjsdata.DSZS;
                XmlElement FDJDSRpm = xmldoc.CreateElement("FDJDSRpm");
                FDJDSRpm.InnerText = zyjsdata.DSZS;
                root.AppendChild(AshSorb0);
                root.AppendChild(AshSorb1);
                root.AppendChild(AshSorb2);
                root.AppendChild(AshSorbAvg);
                root.AppendChild(StdSorb);
                root.AppendChild(Evl);
                root.AppendChild(FDJMaxRpm);
                root.AppendChild(FDJDSRpm);
            }
            /****************speed*************************/
            XmlElement XN_Speed = xmldoc.CreateElement("XN_Speed");
            if (carAtWait.sfjccs && isSpeedFinished)
            {
                XN_Speed.InnerText = speedresult.车速.ToString("0.0");
            }
            root.AppendChild(XN_Speed);
            /****************speed end*********************/
            /****************dyn*************************/
            XmlElement XN_Pe = xmldoc.CreateElement("XN_Pe");
            XmlElement XN_n = xmldoc.CreateElement("XN_n");
            XmlElement XN_Ve_m = xmldoc.CreateElement("XN_Ve_m");
            XmlElement XN_Fe_m = xmldoc.CreateElement("XN_Fe_m");
            XmlElement XN_FE_M1 = xmldoc.CreateElement("XN_FE_M1");
            XmlElement XN_Vw = xmldoc.CreateElement("XN_Vw");
            XmlElement XN_Ftc = xmldoc.CreateElement("XN_Ftc");
            XmlElement XN_Fc = xmldoc.CreateElement("XN_Fc");
            XmlElement XN_Ff = xmldoc.CreateElement("XN_Ff");
            XmlElement XN_aa_ad = xmldoc.CreateElement("XN_aa_ad");
            XmlElement XN_WenDu = xmldoc.CreateElement("XN_WenDu");
            XmlElement XN_ShiDu = xmldoc.CreateElement("XN_ShiDu");
            XmlElement XN_DaQiYa = xmldoc.CreateElement("XN_DaQiYa");
            XmlElement XN_SpeedCurve = xmldoc.CreateElement("XN_SpeedCurve");
            XmlElement XN_ForceCurve = xmldoc.CreateElement("XN_ForceCurve");
            if (carAtWait.sfjcdyn && isDynFinished)
            {
                if (capimage!=null)//如果存在照片，则拷贝到指定的位置上
                {
                    capimage.Save("D:\\Dyn\\" + carAtWait.clhp + "_" + carAtWait.hpzl + "_" + carAtWait.jclsh + ".jpg");
                    //File.Copy(frontpic1,"D:\\Dyn\\"+carAtWait.clhp+"_"+carAtWait.hpzl+"_"+carAtWait.jclsh+".jpg"); 
                }
                XN_Pe.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Pe)].Cells[1].Value.ToString();
                XN_n.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_η)].Cells[1].Value.ToString();
                XN_Ve_m.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Ve)].Cells[1].Value.ToString();
                XN_Fe_m.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Fe)].Cells[1].Value.ToString();
                XN_FE_M1.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_FE)].Cells[1].Value.ToString();
                XN_Vw.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Vw)].Cells[1].Value.ToString();
                XN_Ftc.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Ftc)].Cells[1].Value.ToString();
                XN_Fc.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Fc)].Cells[1].Value.ToString();
                XN_Ff.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_Ff)].Cells[1].Value.ToString();
                XN_aa_ad.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_αa)].Cells[1].Value.ToString();
                XN_WenDu.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_温度)].Cells[1].Value.ToString();
                XN_ShiDu.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_湿度)].Cells[1].Value.ToString();
                XN_DaQiYa.InnerText = dataGridViewDyn.Rows[(int)(dynItemEnum.Dyn_大气压)].Cells[1].Value.ToString();
                XN_SpeedCurve.InnerText = xn_speedcurve;
                XN_ForceCurve.InnerText = xn_forcecurve;
            }

            root.AppendChild(XN_Pe);
            root.AppendChild(XN_n);
            root.AppendChild(XN_Ve_m);
            root.AppendChild(XN_Fe_m);
            root.AppendChild(XN_FE_M1);
            root.AppendChild(XN_Vw);
            root.AppendChild(XN_Ftc);
            root.AppendChild(XN_Fc);
            root.AppendChild(XN_Ff);
            root.AppendChild(XN_aa_ad);
            root.AppendChild(XN_WenDu);
            root.AppendChild(XN_ShiDu);
            root.AppendChild(XN_DaQiYa);
            root.AppendChild(XN_SpeedCurve);
            root.AppendChild(XN_ForceCurve);
            /****************dyn end*************************/

            /****************fuel*************************/
            XmlElement XN_Oil = xmldoc.CreateElement("XN_Oil");
            XmlElement XN_Oila = xmldoc.CreateElement("XN_Oila");
            XmlElement XN_Oila_Std = xmldoc.CreateElement("XN_Oila_Std");
            XmlElement XN_Oila_Evl = xmldoc.CreateElement("XN_Oila_Evl");
            if (carAtWait.sfjcfuel && isFuelFinished)
            {
                XN_Oil.InnerText = dataGridViewFuel.Rows[(int)(fuelItemEnum.百公里油耗)].Cells[1].Value.ToString();
                XN_Oila.InnerText = "";
                XN_Oila_Std.InnerText = dataGridViewFuel.Rows[(int)(fuelItemEnum.限值)].Cells[1].Value.ToString();
                XN_Oila_Evl.InnerText = dataGridViewFuel.Rows[(int)(fuelItemEnum.评价)].Cells[1].Value.ToString()=="合格"?"T":"F";
            }
            root.AppendChild(XN_Oil);
            root.AppendChild(XN_Oila);
            root.AppendChild(XN_Oila_Std);
            root.AppendChild(XN_Oila_Evl);
            /****************fuel end*************************/
            /******************else not use*******************/

            XmlElement XN_AddJuLi = xmldoc.CreateElement("XN_AddJuLi");
            XmlElement XN_AddTime = xmldoc.CreateElement("XN_AddTime");
            XmlElement XN_HuaXingJuLi = xmldoc.CreateElement("XN_HuaXingJuLi");
            XmlElement XN_HuaXingTime = xmldoc.CreateElement("XN_HuaXingTime");
            XmlElement XN_Kilom = xmldoc.CreateElement("XN_Kilom");
            root.AppendChild(XN_AddJuLi);
            root.AppendChild(XN_AddTime);
            root.AppendChild(XN_HuaXingJuLi);
            root.AppendChild(XN_HuaXingTime);
            root.AppendChild(XN_Kilom);
            /**********************end*************************/

            string xmlstring = ConvertXmlToString(xmldoc);
            ini.INIIO.saveLogInf("【生成结果文件】:\r\n"+ xmlstring);
            if (ini.INIIO.saveDynResultToXmlFile(xmlstring, "TestResult"))
            {
                mainPanel.logininfcontrol.writeXNresult(carAtWait.jclsh, carAtWait.clhp, carAtWait.hpzl, (carAtWait.sfjccs ? "Y" : "N") + "|" + (carAtWait.sfjccs ? "Y" : "N") + "|" + (carAtWait.sfjccs ? "Y" : "N"), xmlstring);
                ini.INIIO.saveLogInf("【保存结果文件成功】");
                ini.INIIO.saveDynFile("TestFinished", "TestOver");
            }
            else
            {
                ini.INIIO.saveLogInf("【保存结果文件失败】");
            }
            return true;
        }

        private string frontpic1 = @".\capPic\frontpic1.jpg";
        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        Image capimage;
        private void button1_Click(object sender, EventArgs e)
        {
            if (mainPanel.iscameraused && mainPanel.capturecontrol != null && mainPanel.capturedata.cap_xn_start)
            {
                byte[] imagebuffer=new byte[1];
                mainPanel.capturecontrol.startFrontCaptureThreadToRam(ref imagebuffer);
                if (imagebuffer != null)
                {
                    capimage = BytesToImage(imagebuffer);
                    pictureBoxCapPicture.Image = capimage;
                }
            }
        }

        private void XNCarLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (th_wait != null)
                    th_wait.Abort();
            }
            catch
            { }
            try
            {
                if (th_hjwait != null)
                    th_hjwait.Abort();
            }
            catch
            { }
            Thread.Sleep(1000);
            if (mainPanel.iscameraused)
            {
                mainPanel.capturecontrol.stopLiveView(1);
            }
        }
    }
    public class XNCarInf
    {
        public string jclsh { set; get; }
        public string clhp { set; get; }
        public string hpzl { set; get; }
        public string jcxz { set; get; }
        public bool sfkc { set; get; }
        public string cllx { set; get; }
        public string syxz { set; get; }
        public double zzl { set; get; }
        public double zbzl { set; get; }
        public double jgl { set; get; }
        public double edgl { set; get; }
        public double edzs { set; get; }
        public double ednj { set; get; }
        public double edyh { set; get; }
        public string ltlx { set; get; }
        public double ltdmkd { set; get; }
        public double qcgd { set; get; }
        public double qlj { set; get; }
        public double qccd { set; get; }
        public string kcdj { set; get; }
        public string hccsxs { set; get; }
        public double qdzkzzl { set; get; }
        public double qycmzzl { set; get; }
        public string dlxpjdj { set; get; }
        public double yhxz { set; get; }
        public double yhcs { set; get; }
        public string rlzl { set; get; }
        public bool sfjccs { set; get; }
        public bool sfjcdyn { set; get; }
        public bool sfjcfuel { set; get; }
        public bool sfjcwq { set; get; }
        public string wqjcff { set; get; }
        public int qdzs { set; get; }
        public bool isQdzzlAlive { set; get; }
        public DateTime scrq { set; get; }
        public string jqfs { set; get; }
        public bool pqhclzz { set; get; }
        public int zkrs { set; get; }
        public int jzzl { set; get; }
    }
}
