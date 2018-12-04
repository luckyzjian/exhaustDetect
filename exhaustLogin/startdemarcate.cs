using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using SYS_DAL;
using SYS_MODEL;
using SYS.Model;
using CSVcontrol;
using System.Collections;

namespace exhaustDetect
{
    public partial class startdemarcate : Form
    {
        public string BDLX_CSBD = "01";
        public string BDLX_NLBD = "02";
        public string BDLX_JSGLBD = "03";
        public string BDLX_JZHXBD = "04";
        public string BDLX_FXYBD = "05";
        public string BDLX_YDJBD = "06";
        public string BDLX_FXYJC = "07";
        public string BDLX_FXYLCJC = "08";
        public string BDLX_LLJJC = "09";
        public string BDLX_GLBD = "10";
        public string BDLX_XYSJBD = "11";
        public delegate void wtlsb(Label Msgowner, string Msgstr);                //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                              //委托
        public delegate void wtlm(Label Msgowner, string Msgstr);
        demarcateControl demarcatecontrol = new demarcateControl();
        CSVcontrol.csvReader csvreader = new CSVcontrol.csvReader();
        carinfor.analysismeterInidata analysismeterdata = new carinfor.analysismeterInidata();
        //carinfor.demacatefqy demacatefqydata = new carinfor.demacatefqy();
        carinfor.demacatefqyIni demacatefqyini = new carinfor.demacatefqyIni();
        carinfor.analysismeterIni analysismetercontrol = new carinfor.analysismeterIni();
        carinfor.Flowmeterdata flowmeterdata = new carinfor.Flowmeterdata();
        carinfor.flowmeterIni flowmetercontrol = new carinfor.flowmeterIni();
        carinfor.glideControl glidecontrol = new carinfor.glideControl();
        carinfor.glide glidedata = new carinfor.glide();
        carinfor.inertness inertnessdata = new carinfor.inertness();
        carinfor.inertnessControl inertnesscontrol = new carinfor.inertnessControl();
        carinfor.parasitic parasiticdata = new carinfor.parasitic();
        carinfor.parasiticControl parasiticcontrol = new carinfor.parasiticControl();
        carinfor.bzglide bzglidedata = new carinfor.bzglide();
        carinfor.bzglideControl bzglidecontrol = new carinfor.bzglideControl();
        carinfor.Smokemeterdata smokedata = new carinfor.Smokemeterdata();
        carinfor.SmokemeterIni smokeini = new carinfor.SmokemeterIni();
        carinfor.temperatureData tempdata = new carinfor.temperatureData();
        carinfor.temperatureIni tempini = new carinfor.temperatureIni();
        carinfor.xysjData xysjdata = new carinfor.xysjData();
        carinfor.xysjControl xysjcontrol = new carinfor.xysjControl();
        carinfor.workLogData worklogdata = new carinfor.workLogData();
        carinfor.selfCheckIni selfcheckini = new carinfor.selfCheckIni();

        selfcheckdal selfcheckcontrol = new selfcheckdal();
        string yuredata = "";
        carinfor.yureconfigIni yurecontrol = new carinfor.yureconfigIni();
        private string _bdnr;
        private string fqylx = "";
        private DateTime bdrq;
        public static NeusoftUtil.RespondCalStandard calstandarddata = new NeusoftUtil.RespondCalStandard();
        public startdemarcate()
        {
            InitializeComponent();
            
        }
        public startdemarcate(string bdnr)
        {
            InitializeComponent();
            _bdnr = bdnr;
            
        }
        public startdemarcate(string bdnr,string lx)
        {
            InitializeComponent();
            _bdnr = bdnr;
            fqylx = lx;

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
        private void waitTestFinished()
        {
            string newPath = "";
            string exename = "";
            switch (_bdnr)
            {
                case "变载荷滑行测试":
                    exename = "变载荷滑行";
                    newPath = "C://jcdatatxt/BzGlide.ini";
                    break;
                case "响应时间测试":
                    exename = "响应时间";
                    newPath = "C://jcdatatxt/xysjData.ini";
                    break;
                case "滑行测试":
                    exename = "加载滑行";
                    newPath = "C://jcdatatxt/Glide.ini";
                    break;
                case "寄生功率测试":
                    exename = "汽油寄生功率";
                    newPath = "C://jcdatatxt/Parasitic.ini";
                    break;
                case "惯量测试":
                    exename = "惯量标定";
                    newPath = "C://jcdatatxt/Inertness.ini";
                    break;
                case "废气仪检查":
                    exename = "废气仪标定";
                    newPath = "C://jcdatatxt/AnalysisMeter.ini";
                    break;
                case "废气仪标定":
                    exename = "废气仪标定";
                    newPath = "C://jcdatatxt/AnalysisMeter.ini";
                    break;
                case "流量计检测":
                    exename = "流量计标定";
                    newPath = "C://jcdatatxt/Flowmeter.ini";
                    break;
                case "预热":
                    exename = "预热";
                    newPath = "C://jcdatatxt/Yure.ini";
                    break;
                case "烟度计检查":
                    exename = "烟度计标定";
                    newPath = "C://jcdatatxt/Smokemeter.ini";
                    break;
                case "气象站校准":
                    exename = "气象站校准";
                    newPath = "C://jcdatatxt/temperatureCal.ini";
                    break;
                case "扭力标定":
                    exename = "扭力标定";
                    newPath = "C://jcdatatxt/TorqueCal.csv";
                    break;
                case "速度标定":
                    exename = "速度标定";
                    newPath = "C://jcdatatxt/SpeedCal.csv";
                    break;
                default: break;
            }
            while (true)
            {
                Thread.Sleep(1000);
                if (!IsProcessStarted(exename))
                {
                    if (File.Exists(newPath))
                    {
                        worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");
                        worklogdata.ProjectName = exename;
                        worklogdata.Stationid = mainPanel.stationid;
                        worklogdata.Lineid = mainPanel.lineid;
                        worklogdata.Czy = mainPanel.nowUser.userName;
                        worklogdata.Data = "完成标定或检查";
                        worklogdata.State = "完成";
                        worklogdata.Result = "标定完成";
                        worklogdata.Date = DateTime.Now;
                        worklogdata.Bzsm = "";
                        Thread.Sleep(500);//等待两秒以确保文件内容写完
                        carinfor.demarcateStart dmctstart = new carinfor.demarcateStart();
                        carinfor.demarcateStop dmctstop = new carinfor.demarcateStop();
                        string newCsvPath = "";
                        switch (_bdnr)
                        {
                            case "滑行测试":
                                #region 加载滑行
                                newCsvPath = "C://jcdatatxt/" + "glidedata.csv";
                                carinfor.JZHXdemarcate jzhxdmct = new carinfor.JZHXdemarcate();
                                glidedata = glidecontrol.readGlideData(newPath);
                                if (glidedata.Bdjg == "合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    demarcatecontrol.saveGlideDataByIni(glidedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                    Msg(label1, panel4, "加载滑行测试结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid,"HXDATE", DateTime.Now.ToString());
                                    if(mainPanel.linemodel.LOCKREASON=="加载滑行未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                }
                                else if (glidedata.Bdjg == "不合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    demarcatecontrol.saveGlideDataByIni(glidedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                    Msg(label1, panel4, "加载滑行测试结果不合格");
                                    if(mainPanel.linesbbd.Hxenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y","加载滑行未通过");
                                }
                                else
                                {
                                    Msg(label1, panel4, "加载滑行未完成退出");
                                    worklogdata.Result = "未完成";
                                } 
                                if (mainPanel.isNetUsed)
                                {
                                    if(mainPanel.NetMode==mainPanel.NEUSOFTNETMODE)
                                    {
                                        #region neusoft
                                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                                        {
                                            if ((glidedata.Bdjg == "合格" || glidedata.Bdjg == "不合格") && glidedata.NeuFinished == "Y")
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                    NeusoftUtil.Coastdown coastdowndata = new NeusoftUtil.Coastdown();
                                                    coastdowndata.OutlookID = mainPanel.equipmodel.CGJBH;
                                                    coastdowndata.StartTime = glidedata.Starttime;
                                                    coastdowndata.ACDT40 = glidedata.Acdt40;
                                                    coastdowndata.ACDT24 = glidedata.Acdt24;
                                                    coastdowndata.CCDT40 = glidedata.Ccdt40;
                                                    coastdowndata.CCDT24 = glidedata.Ccdt24;
                                                    coastdowndata.PLHP40 = glidedata.Plhp40;
                                                    coastdowndata.PLHP24 = glidedata.Plhp24;
                                                    coastdowndata.IHP40 = glidedata.Ihp40;
                                                    coastdowndata.IHP24 = glidedata.Ihp24;
                                                    coastdowndata.DIW = glidedata.Gxdl;
                                                    coastdowndata.Result40 = (glidedata.Result40 == "合格"?"1":"0");
                                                    coastdowndata.Result24 = (glidedata.Result24 == "合格" ? "1" : "0");
                                                    coastdowndata.Result = (glidedata.Bdjg == "合格" ? "1" : "0");


                                                    string result, inf;
                                                    DataTable dtack;
                                                    mainPanel.sysocket.UploadCoastdownRequest(coastdowndata, null, out result, out inf, out dtack);
                                            }
                                        }
                                        else
                                        {
                                            if ((glidedata.Bdjg == "合格" || glidedata.Bdjg == "不合格") && glidedata.NeuFinished == "Y")
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    isCsvAlive = "过程数据上传成功";
                                                    NeusoftUtil.Coastdown coastdowndata = new NeusoftUtil.Coastdown();
                                                    coastdowndata.StartTime = glidedata.Starttime;
                                                    coastdowndata.ACDT40 = glidedata.Acdt40;
                                                    coastdowndata.ACDT24 = glidedata.Acdt24;
                                                    coastdowndata.CCDT40 = glidedata.Ccdt40;
                                                    coastdowndata.CCDT24 = glidedata.Ccdt24;
                                                    coastdowndata.PLHP40 = glidedata.Plhp40;
                                                    coastdowndata.PLHP24 = glidedata.Plhp24;
                                                    coastdowndata.IHP40 = glidedata.Ihp40;
                                                    coastdowndata.IHP24 = glidedata.Ihp24;
                                                    coastdowndata.DIW = glidedata.Gxdl;
                                                    coastdowndata.Result40 = glidedata.Result40;
                                                    coastdowndata.Result24 = glidedata.Result24;
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    string ackresult, errormessage;
                                                    mainPanel.neusoftsocket.UploadCoastdownRequest(coastdowndata, dataseconds, out ackresult, out errormessage);
                                                }
                                                else
                                                {
                                                    isCsvAlive = "过程数据不存在";
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.加载滑行校准]);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", "48-32");
                                            hstb.Add("DATA2", "32-16");
                                            hstb.Add("DATA3", "");
                                            hstb.Add("DATA4", "");
                                            hstb.Add("DATA5", glidedata.Ihp40);
                                            hstb.Add("DATA6", glidedata.Ihp24);
                                            hstb.Add("DATA7", "");
                                            hstb.Add("DATA8", "");
                                            hstb.Add("DATA9", glidedata.Plhp40);
                                            hstb.Add("DATA10", glidedata.Plhp24);
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", glidedata.Acdt40);
                                            hstb.Add("DATA14", glidedata.Acdt24);
                                            hstb.Add("DATA15", "");
                                            hstb.Add("DATA16", "");
                                            hstb.Add("DATA17", glidedata.Ccdt40);
                                            hstb.Add("DATA18", glidedata.Ccdt24);
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", Math.Round((double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)) * 100.0 / double.Parse(glidedata.Ccdt40), 1).ToString("0.0"));
                                            hstb.Add("DATA22", Math.Round((double.Parse(glidedata.Acdt24) - double.Parse(glidedata.Ccdt24)) * 100.0 / double.Parse(glidedata.Ccdt24), 1).ToString("0.0"));
                                            hstb.Add("DATA23", "");
                                            hstb.Add("DATA24", "");
                                            hstb.Add("DATA25", glidedata.Gxdl);
                                            hstb.Add("DATA26", glidedata.Result40);
                                            hstb.Add("DATA27", glidedata.Result24);
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", "");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句失败");
                                            }
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_JZHXBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", "48-32");
                                            hstb.Add("DATA2", "32-16");
                                            hstb.Add("DATA3", "");
                                            hstb.Add("DATA4", "");
                                            hstb.Add("DATA5", glidedata.Ihp40);
                                            hstb.Add("DATA6", glidedata.Ihp24);
                                            hstb.Add("DATA7", "");
                                            hstb.Add("DATA8", "");
                                            hstb.Add("DATA9", glidedata.Plhp40);
                                            hstb.Add("DATA10", glidedata.Plhp24);
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", glidedata.Acdt40);
                                            hstb.Add("DATA14", glidedata.Acdt24);
                                            hstb.Add("DATA15", "");
                                            hstb.Add("DATA16", "");
                                            hstb.Add("DATA17", glidedata.Ccdt40);
                                            hstb.Add("DATA18", glidedata.Ccdt24);
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", Math.Round((double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)) * 100.0 / double.Parse(glidedata.Ccdt40), 1).ToString("0.0"));
                                            hstb.Add("DATA22", Math.Round((double.Parse(glidedata.Acdt24) - double.Parse(glidedata.Ccdt24)) * 100.0 / double.Parse(glidedata.Ccdt24), 1).ToString("0.0"));
                                            hstb.Add("DATA23", "");
                                            hstb.Add("DATA24", "");
                                            hstb.Add("DATA25", glidedata.Gxdl);
                                            hstb.Add("DATA26", glidedata.Result40);
                                            hstb.Add("DATA27", glidedata.Result24);
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", "");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_JZHXBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", "48-32");
                                            hstb.Add("DATA2", "32-16");
                                            hstb.Add("DATA3", "");
                                            hstb.Add("DATA4", "");
                                            hstb.Add("DATA5", glidedata.Ihp40);
                                            hstb.Add("DATA6", glidedata.Ihp24);
                                            hstb.Add("DATA7", "");
                                            hstb.Add("DATA8", "");
                                            hstb.Add("DATA9", glidedata.Plhp40);
                                            hstb.Add("DATA10", glidedata.Plhp24);
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", glidedata.Acdt40);
                                            hstb.Add("DATA14", glidedata.Acdt24);
                                            hstb.Add("DATA15", "");
                                            hstb.Add("DATA16", "");
                                            hstb.Add("DATA17", glidedata.Ccdt40);
                                            hstb.Add("DATA18", glidedata.Ccdt24);
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", Math.Round((double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)) * 100.0 / double.Parse(glidedata.Ccdt40), 1).ToString("0.0"));
                                            hstb.Add("DATA22", Math.Round((double.Parse(glidedata.Acdt24) - double.Parse(glidedata.Ccdt24)) * 100.0 / double.Parse(glidedata.Ccdt24), 1).ToString("0.0"));
                                            hstb.Add("DATA23", "");
                                            hstb.Add("DATA24", "");
                                            hstb.Add("DATA25", glidedata.Gxdl);
                                            hstb.Add("DATA26", glidedata.Result40);
                                            hstb.Add("DATA27", glidedata.Result24);
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", "");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存加载滑行标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "10");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "10");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "10");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "0" : "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("jzhxgxdl", glidedata.Gxdl);
                                        htdata.Add("jzhxbddsl", "2");
                                        htdata.Add("jzhxbdsj","#48#32#"+glidedata.Acdt40+"#"+glidedata.Plhp40+"#"+glidedata.Ccdt40+"#"+glidedata.Acdt40+"#"+ (double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)).ToString("0.000")+
                                            "#32#16#" + glidedata.Acdt24 + "#" + glidedata.Plhp24 + "#" + glidedata.Ccdt24 + "#" + glidedata.Acdt24 + "#" + (double.Parse(glidedata.Acdt24) - double.Parse(glidedata.Ccdt24)).ToString("0.000"));
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                    {
                                        #region 大理联网
                                        string code, msg;
                                        string reportID;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                        ht.Add("检测站编号", mainPanel.stationid);
                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                        ht.Add("设备类别", "3");
                                        ht.Add("设备名称", "加载滑行");
                                        ht.Add("设备型号", mainPanel.equipmodel.CGJXH);
                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("惯性当量", glidedata.Gxdl);                                        
                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                        ht2.Add("最小车速", "32");
                                        ht2.Add("最大车速", "48");
                                        ht2.Add("滑行时间", glidedata.Acdt40);
                                        ht2.Add("寄生功率", glidedata.Plhp40);
                                        ht2.Add("理论滑行时间", glidedata.Ccdt40);
                                        ht2.Add("实际滑行时间", glidedata.Acdt40);
                                        ht2.Add("偏差", Math.Round((double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)) * 100.0 / double.Parse(glidedata.Ccdt40), 1).ToString("0.0"));
                                        if (!mainPanel.daliinterface.sendJzhxBdData(ht, ht2, out code, out msg))
                                        {
                                            MessageBox.Show("发送加载滑行标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                            ini.INIIO.saveLogInf("发送加载滑行标定信息失败,code" + code + ",msg:" + msg);
                                            return;
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.GUILINNETMODE)
                                    {
                                        #region 桂林                        
                                        string result;
                                        string errmsg = "";
                                        DataTable dt = new DataTable();
                                        Hashtable ht2 = new Hashtable();
                                        ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                        ht2.Add("stationcode", mainPanel.stationid);
                                        ht2.Add("scenecode", mainPanel.lineid);
                                        ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                                        ht2.Add("checktimestart", DateTime.Parse(glidedata.Starttime).ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht2.Add("checktimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht2.Add("acdt40",(double.Parse(glidedata.Acdt40)*1000).ToString("0"));
                                        ht2.Add("acdt25", (double.Parse(glidedata.Acdt24) * 1000).ToString("0"));
                                        ht2.Add("plhp40", glidedata.Plhp40);
                                        ht2.Add("plhp25", glidedata.Plhp24);
                                        ht2.Add("diw", glidedata.Gxdl);                                        
                                        ht2.Add("remark", "");
                                        if (!mainPanel.gxinterface.uploadSelfCheckData(2, ht2, out result, out errmsg))
                                        {
                                            ini.INIIO.saveLogInf("上传自检数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                            //return;
                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("桂林联网信息：上传自检数据成功");
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                                    {
                                        #region ezhou
                                        try
                                        {
                                            string msg, code;
                                            EzWebClient.LoadSlideCheckData data = new EzWebClient.LoadSlideCheckData(
                                                glidedata.Acdt24,
                                                glidedata.Acdt40,
                                                glidedata.Ccdt24,
                                                glidedata.Ccdt40,
                                                glidedata.Gxdl,
                                                "",
                                                glidedata.Ihp24,
                                                glidedata.Ihp40,
                                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                                DateTime.Now.ToString("yyyyMMdd"),
                                                mainPanel.stationid+mainPanel.lineid,
                                                glidedata.Plhp24,
                                                glidedata.Plhp40,
                                                "",
                                                (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "0" : "1",
                                                (glidedata.Result24 == "不合格" || glidedata.Result24 == "0") ? "0" : "1",
                                                (glidedata.Result40 == "不合格" || glidedata.Result40 == "0") ? "0" : "1",
                                               DateTime.Parse( glidedata.Starttime).ToString("yyyyMMddHHmmss"),
                                               mainPanel.stationid,
                                               mainPanel.nowUser.userName,
                                               DateTime.Now.ToString("yyyyMMddHHmmss")
                                                );
                                            if (!mainPanel.ezinterface.uploadLoadSlideCheckData(data, out code, out msg))
                                            {
                                                ini.INIIO.saveLogInf("发送[自检/校准]命令失败,code" + code + ",msg:" + msg);
                                            }
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("发送[自检/校准]命令发生异常:" + er.Message);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        AhWebClient.ah_jzhx_caldata cdata1 = new AhWebClient.ah_jzhx_caldata();
                                        AhWebClient.ah_jzhx_caldata cdata2 = new AhWebClient.ah_jzhx_caldata();
                                        pdata.Type = "1";
                                        pdata.BeginTime = DateTime.Parse(glidedata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.Judge = (glidedata.Bdjg == "不合格" || glidedata.Bdjg == "0") ? "2" : "1";
                                        jdata.type = "1";
                                        jdata.InertiaEquivalent = glidedata.Gxdl;
                                        jdata.CalibrateCount = "2";
                                        List<AhWebClient.ah_jzhx_caldata> listc = new List<AhWebClient.ah_jzhx_caldata>();
                                        cdata1.FromSpeed = "48";
                                        cdata1.ToSpeed = "32";
                                        cdata1.TheoreticalTime = glidedata.Ccdt40;
                                        cdata1.ActualTime = glidedata.Acdt40;
                                        cdata1.Deviation = Math.Round((double.Parse(glidedata.Acdt40) - double.Parse(glidedata.Ccdt40)) * 100.0 / double.Parse(glidedata.Ccdt40), 1).ToString("0.0");
                                        cdata1.ErrorLimit = "7";
                                        cdata1.Result = glidedata.Result40 == "1" ? "1" : "2";
                                        listc.Add(cdata1);
                                        cdata2.FromSpeed = "32";
                                        cdata2.ToSpeed = "16";
                                        cdata2.TheoreticalTime = glidedata.Ccdt24;
                                        cdata2.ActualTime = glidedata.Acdt24;
                                        cdata2.Deviation = Math.Round((double.Parse(glidedata.Acdt24) - double.Parse(glidedata.Ccdt24)) * 100.0 / double.Parse(glidedata.Ccdt24), 1).ToString("0.0");
                                        cdata2.ErrorLimit = "7";
                                        cdata2.Result = glidedata.Result24 == "1" ? "1" : "2";
                                        listc.Add(cdata2);
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata,listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传加载滑行标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传加载滑行标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "寄生功率测试":
                                #region 寄生功率
                                newCsvPath = "C://jcdatatxt/" + "parasiticdata.csv";
                                carinfor.JSGLdemarcate jsgldmct = new carinfor.JSGLdemarcate();
                                parasiticdata = parasiticcontrol.readParasiticData(newPath);
                                demarcatecontrol.saveParasiticDataByIni(parasiticdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (parasiticdata.Bdjg == "不合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "寄生功率测试结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.linesbbd.Jsglenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "寄生功率未通过");
                                }
                                else if(parasiticdata.Bdjg == "合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "寄生功率测试结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "JSGLDATE", DateTime.Now.ToString());
                                    if (mainPanel.linemodel.LOCKREASON == "寄生功率未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                }
                                else
                                {
                                    Msg(label1, panel4, "寄生功率测试未完成退出");
                                }
                                if (mainPanel.isNetUsed)
                                {
                                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE )
                                    {
                                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                                        {
                                            if (parasiticdata.Bdjg == "合格" || parasiticdata.Bdjg == "不合格")
                                            {
                                                NeusoftUtil.ParasiticLose parasiticlosedata = new NeusoftUtil.ParasiticLose();
                                                parasiticlosedata.OutlookID = mainPanel.equipmodel.CGJBH;
                                                parasiticlosedata.StartTime = parasiticdata.Starttime;
                                                parasiticlosedata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                parasiticlosedata.ACDT40 = parasiticdata.Acdt40;
                                                parasiticlosedata.ACDT24 = parasiticdata.Acdt24;
                                                parasiticlosedata.PLHP40 = parasiticdata.Plhp40;
                                                parasiticlosedata.PLHP24 = parasiticdata.Plhp24;
                                                parasiticlosedata.IHP40 = "0";
                                                parasiticlosedata.IHP24 = "0";
                                                parasiticlosedata.DIW = parasiticdata.Diw;
                                                string result, inf;
                                                DataTable dtack;
                                                mainPanel.sysocket.UploadParasiticLoseRequest(parasiticlosedata, null, out result, out inf, out dtack);
                                            }
                                        }
                                        else
                                        {
                                            #region neusoft
                                            if (parasiticdata.Bdjg == "合格" || parasiticdata.Bdjg == "不合格")
                                            {
                                                ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    isCsvAlive = "过程数据上传成功";
                                                    NeusoftUtil.ParasiticLose parasiticlosedata = new NeusoftUtil.ParasiticLose();
                                                    parasiticlosedata.StartTime = parasiticdata.Starttime;
                                                    parasiticlosedata.ACDT40 = parasiticdata.Acdt40;
                                                    parasiticlosedata.ACDT24 = parasiticdata.Acdt24;
                                                    parasiticlosedata.PLHP40 = parasiticdata.Plhp40;
                                                    parasiticlosedata.PLHP24 = parasiticdata.Plhp24;
                                                    parasiticlosedata.DIW = parasiticdata.Diw;
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    string ackresult, errormessage;
                                                    mainPanel.neusoftsocket.UploadParasiticLoseRequest(parasiticlosedata, dataseconds, out ackresult, out errormessage);
                                                    Msg(label1, panel4, "附加损耗测试成功," + isCsvAlive);
                                                }
                                                else
                                                {
                                                    Msg(label1, panel4, "附加损耗测试失败,没有找到过程数据");
                                                }
                                            }
                                        }
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                            int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.寄生功率校准]);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", parasiticdata.Hxsj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA2", parasiticdata.Jsgl.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA3", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[0]);
                                            hstb.Add("DATA4", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[1]);
                                            hstb.Add("DATA5", parasiticdata.Mysd.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA6", parasiticdata.Diw);
                                            hstb.Add("DATA7", parasiticdata.kssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA8", parasiticdata.jssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA9", parasiticdata.Hxsj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA10", parasiticdata.Jsgl.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA11", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[0]);
                                            hstb.Add("DATA12", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[1]);
                                            hstb.Add("DATA13", parasiticdata.Mysd.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA14", parasiticdata.kssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA15", parasiticdata.jssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA16", parasiticdata.Hxsj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA17", parasiticdata.Jsgl.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA18", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[0]);
                                            hstb.Add("DATA19", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[1]);
                                            hstb.Add("DATA20", parasiticdata.Mysd.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA21", parasiticdata.kssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA22", parasiticdata.jssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA23", parasiticdata.Hxsj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA24", parasiticdata.Jsgl.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA25", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[0]);
                                            hstb.Add("DATA26", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[1]);
                                            hstb.Add("DATA27", parasiticdata.Mysd.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA28", parasiticdata.kssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA29", parasiticdata.jssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA30", "");
                                            hstb.Add("DATA31", "");
                                            hstb.Add("DATA32", "");
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句失败");
                                            }
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDLX", BDLX_JSGLBD);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", parasiticdata.Hxsj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA2", parasiticdata.Jsgl.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA3", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[0]);
                                            hstb.Add("DATA4", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[1]);
                                            hstb.Add("DATA5", parasiticdata.Mysd.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA6", parasiticdata.Diw);
                                            hstb.Add("DATA7", parasiticdata.kssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA8", parasiticdata.jssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA9", parasiticdata.Hxsj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA10", parasiticdata.Jsgl.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA11", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[0]);
                                            hstb.Add("DATA12", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[1]);
                                            hstb.Add("DATA13", parasiticdata.Mysd.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA14", parasiticdata.kssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA15", parasiticdata.jssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA16", parasiticdata.Hxsj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA17", parasiticdata.Jsgl.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA18", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[0]);
                                            hstb.Add("DATA19", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[1]);
                                            hstb.Add("DATA20", parasiticdata.Mysd.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA21", parasiticdata.kssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA22", parasiticdata.jssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA23", parasiticdata.Hxsj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA24", parasiticdata.Jsgl.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA25", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[0]);
                                            hstb.Add("DATA26", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[1]);
                                            hstb.Add("DATA27", parasiticdata.Mysd.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA28", parasiticdata.kssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA29", parasiticdata.jssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA30", "");
                                            hstb.Add("DATA31", "");
                                            hstb.Add("DATA32", "");
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDLX", BDLX_JSGLBD);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", parasiticdata.Hxsj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA2", parasiticdata.Jsgl.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA3", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[0]);
                                            hstb.Add("DATA4", parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[1]);
                                            hstb.Add("DATA5", parasiticdata.Mysd.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA6", parasiticdata.Diw);
                                            hstb.Add("DATA7", parasiticdata.kssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA8", parasiticdata.jssj.Split(',')[rowscount - 4]);
                                            hstb.Add("DATA9", parasiticdata.Hxsj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA10", parasiticdata.Jsgl.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA11", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[0]);
                                            hstb.Add("DATA12", parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[1]);
                                            hstb.Add("DATA13", parasiticdata.Mysd.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA14", parasiticdata.kssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA15", parasiticdata.jssj.Split(',')[rowscount - 3]);
                                            hstb.Add("DATA16", parasiticdata.Hxsj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA17", parasiticdata.Jsgl.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA18", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[0]);
                                            hstb.Add("DATA19", parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[1]);
                                            hstb.Add("DATA20", parasiticdata.Mysd.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA21", parasiticdata.kssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA22", parasiticdata.jssj.Split(',')[rowscount - 2]);
                                            hstb.Add("DATA23", parasiticdata.Hxsj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA24", parasiticdata.Jsgl.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA25", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[0]);
                                            hstb.Add("DATA26", parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[1]);
                                            hstb.Add("DATA27", parasiticdata.Mysd.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA28", parasiticdata.kssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA29", parasiticdata.jssj.Split(',')[rowscount - 1]);
                                            hstb.Add("DATA30", "");
                                            hstb.Add("DATA31", "");
                                            hstb.Add("DATA32", "");
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存寄生功率标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "9");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "9");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "9");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt",  "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("jsglgxdl", parasiticdata.Diw);
                                        htdata.Add("jsglbddsl", "4");
                                        int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                        htdata.Add("jsglbdsj", "#"+ parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[0]+"#"+ parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[1]+"#" + parasiticdata.Hxsj.Split(',')[rowscount - 4] + "#" + parasiticdata.Jsgl.Split(',')[rowscount - 4]+
                                            "#" + parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[0] + "#" + parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[1] + "#" + parasiticdata.Hxsj.Split(',')[rowscount - 3] + "#" + parasiticdata.Jsgl.Split(',')[rowscount - 3] +
                                            "#" + parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[0] + "#" + parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[1] + "#" + parasiticdata.Hxsj.Split(',')[rowscount - 2] + "#" + parasiticdata.Jsgl.Split(',')[rowscount - 2] +
                                            "#" + parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[0] + "#" + parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[1] + "#" + parasiticdata.Hxsj.Split(',')[rowscount - 1] + "#" + parasiticdata.Jsgl.Split(',')[rowscount - 1] );
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                    {
                                        #region 大理联网
                                        string code, msg;
                                        string reportID;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                        DataTable dt = new DataTable();
                                        ht.Add("检测站编号", mainPanel.stationid);
                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                        ht.Add("设备类别", "2");
                                        ht.Add("设备名称", "寄生功率");
                                        ht.Add("设备型号", mainPanel.equipmodel.CGJXH);
                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("惯性当量", parasiticdata.Diw);
                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                        dt.Columns.Add("最小车速");
                                        dt.Columns.Add("最大车速");
                                        dt.Columns.Add("滑行时间");
                                        dt.Columns.Add("寄生功率");
                                        DataRow dr = null;
                                        int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            dr = dt.NewRow();
                                            dr["最小车速"] = parasiticdata.Sdqj.Split(',')[rowscount - i].Split('-')[1];
                                            dr["最大车速"] = parasiticdata.Sdqj.Split(',')[rowscount - i].Split('-')[0];
                                            dr["滑行时间"] = parasiticdata.Hxsj.Split(',')[rowscount - i];
                                            dr["寄生功率"] = parasiticdata.Jsgl.Split(',')[rowscount - i];
                                            dt.Rows.Add(dr);
                                        }
                                        if (!mainPanel.daliinterface.sendJsglBdData(ht, dt, out code, out msg))
                                        {
                                            MessageBox.Show("发送寄生功率标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                            ini.INIIO.saveLogInf("发送寄生功率标定信息失败,code" + code + ",msg:" + msg);
                                            return;
                                        }
                                        #endregion
                                    }
                                    /*
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                                    {
                                        #region 中科宇图
                                        try
                                        {
                                            ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检");
                                            string ackresult, errormessage;
                                            mainPanel.xmlanalysis.ReadACKString(
                                                mainPanel.yichangInterface.cgjPLHPSelfcheck(
                                                    mainPanel.zkytwebinf.regcode,
                                                    parasiticdata.Sdqj.Split(',')[0],
                                                    double.Parse(parasiticdata.Mysd.Split(',')[0]),
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[0]),
                                                    parasiticdata.Sdqj.Split(',')[1],
                                                    double.Parse(parasiticdata.Mysd.Split(',')[1]),
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[1]),
                                                    parasiticdata.Sdqj.Split(',')[2],
                                                    double.Parse(parasiticdata.Mysd.Split(',')[2]),
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[2]),
                                                    parasiticdata.Sdqj.Split(',')[3],
                                                    double.Parse(parasiticdata.Mysd.Split(',')[3]),
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[3]),
                                                    96,
                                                    "1",
                                                    DateTime.Parse(parasiticdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss"),
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                    "",
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[1]),
                                                    double.Parse(parasiticdata.Jsgl.Split(',')[3]),
                                                    double.Parse(parasiticdata.Diw)),
                                                out ackresult,
                                                out errormessage);
                                            ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检成功:result=" + ackresult);
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检:" + er.Message);
                                        }
                                        #endregion
                                    }*/
                                }
                                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                {
                                    #region 安徽联网
                                    AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                    AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                    AhWebClient.ah_plhp_caldata cdata1 = new AhWebClient.ah_plhp_caldata();
                                    AhWebClient.ah_plhp_caldata cdata2 = new AhWebClient.ah_plhp_caldata();
                                    AhWebClient.ah_plhp_caldata cdata3 = new AhWebClient.ah_plhp_caldata();
                                    AhWebClient.ah_plhp_caldata cdata4 = new AhWebClient.ah_plhp_caldata();
                                    pdata.Type = "1";
                                    pdata.BeginTime = DateTime.Parse(parasiticdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                    pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    pdata.Judge = (parasiticdata.Bdjg == "不合格" || parasiticdata.Bdjg == "0") ? "2" : "1";
                                    jdata.type = "3";
                                    jdata.InertiaEquivalent = parasiticdata.Diw;
                                    jdata.CalibrateCount = "4";
                                    int rowscount = parasiticdata.Hxsj.Split(',').Count();
                                    List<AhWebClient.ah_plhp_caldata> listc = new List<AhWebClient.ah_plhp_caldata>();
                                    cdata1.FromSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[0];
                                    cdata1.ToSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 4].Split('-')[1];
                                    cdata1.NominalSpeed = parasiticdata.Mysd.Split(',')[rowscount - 4];
                                    cdata1.ActualTime = parasiticdata.Hxsj.Split(',')[rowscount - 4];
                                    cdata1.WattlessOutput = parasiticdata.Jsgl.Split(',')[rowscount - 4];                                    
                                    listc.Add(cdata1);
                                    cdata2.FromSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[0];
                                    cdata2.ToSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 3].Split('-')[1];
                                    cdata2.NominalSpeed = parasiticdata.Mysd.Split(',')[rowscount - 3];
                                    cdata2.ActualTime = parasiticdata.Hxsj.Split(',')[rowscount - 3];
                                    cdata2.WattlessOutput = parasiticdata.Jsgl.Split(',')[rowscount - 3];
                                    listc.Add(cdata2);
                                    cdata3.FromSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[0];
                                    cdata3.ToSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 2].Split('-')[1];
                                    cdata3.NominalSpeed = parasiticdata.Mysd.Split(',')[rowscount - 2];
                                    cdata3.ActualTime = parasiticdata.Hxsj.Split(',')[rowscount - 2];
                                    cdata3.WattlessOutput = parasiticdata.Jsgl.Split(',')[rowscount - 2];
                                    listc.Add(cdata3);
                                    cdata4.FromSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[0];
                                    cdata4.ToSpeed = parasiticdata.Sdqj.Split(',')[rowscount - 1].Split('-')[1];
                                    cdata4.NominalSpeed = parasiticdata.Mysd.Split(',')[rowscount - 1];
                                    cdata4.ActualTime = parasiticdata.Hxsj.Split(',')[rowscount - 1];
                                    cdata4.WattlessOutput = parasiticdata.Jsgl.Split(',')[rowscount - 1];
                                    listc.Add(cdata4);
                                    int ahresult = 0;
                                    string ahErrMsg = "";
                                    if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                    {
                                        ini.INIIO.saveLogInf("[上传寄生功率标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                    }
                                    else
                                    {
                                        ini.INIIO.saveLogInf("[上传寄生功率标定信息]:成功\r\n");
                                    }
                                    #endregion
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "惯量测试":
                                #region
                                inertnessdata = inertnesscontrol.readInertnessData(newPath);
                                demarcatecontrol.saveInertnessDataByIni(inertnessdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (inertnessdata.Bdjg == "不合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "惯量测试结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.linesbbd.Glenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "惯量测试未通过");
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        { }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_GLBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "0");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", inertnessdata.Diw_bc);
                                            hstb.Add("DATA2", inertnessdata.Diw_sc);
                                            hstb.Add("DATA3", inertnessdata.Wc);
                                            hstb.Add("DATA4", "0");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_GLBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "0");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", inertnessdata.Diw_bc);
                                            hstb.Add("DATA2", inertnessdata.Diw_sc);
                                            hstb.Add("DATA3", inertnessdata.Wc);
                                            hstb.Add("DATA4", "0");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                else if (inertnessdata.Bdjg == "合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "惯量测试结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "GLDATE", DateTime.Now.ToString());
                                    if (mainPanel.linemodel.LOCKREASON == "惯量测试未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_GLBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", inertnessdata.Diw_bc);
                                            hstb.Add("DATA2", inertnessdata.Diw_sc);
                                            hstb.Add("DATA3", inertnessdata.Wc);
                                            hstb.Add("DATA4", "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_GLBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", inertnessdata.Diw_bc);
                                            hstb.Add("DATA2", inertnessdata.Diw_sc);
                                            hstb.Add("DATA3", inertnessdata.Wc);
                                            hstb.Add("DATA4", "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存惯量标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    Msg(label1, panel4, "惯量测试未完成退出");
                                }
                                if(inertnessdata.Bdjg=="合格"||inertnessdata.Bdjg=="不合格")
                                {
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        AhWebClient.ah_gl_caldata cdata1 = new AhWebClient.ah_gl_caldata();
                                        AhWebClient.ah_gl_caldata cdata2 = new AhWebClient.ah_gl_caldata();
                                        AhWebClient.ah_gl_caldata cdata3 = new AhWebClient.ah_gl_caldata();
                                        pdata.Type = "1";
                                        pdata.BeginTime = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.Judge = (inertnessdata.Bdjg == "不合格" || inertnessdata.Bdjg == "0") ? "2" : "1";
                                        jdata.type = "6";
                                        jdata.CalibrateCount = "3";
                                        List<AhWebClient.ah_gl_caldata> listc = new List<AhWebClient.ah_gl_caldata>();
                                        cdata1.NominalValue = inertnessdata.Diw_bc;
                                        cdata1.FromSpeed = "48";
                                        cdata1.ToSpeed = "16";
                                        cdata1.ForceSettingValue1 = "0";
                                        cdata1.ActualTime1 = inertnessdata.Acd1_1;
                                        cdata1.ForceRealTime1 = inertnessdata.Acd1_1;
                                        cdata1.ForceSettingValue2 = "1170";
                                        cdata1.ActualTime2 = inertnessdata.Acd2_1;
                                        cdata1.ForceRealTime2 = inertnessdata.Acd2_1;
                                        cdata1.RealValue = inertnessdata.Diw_1;
                                        cdata1.Deviation = (double.Parse(inertnessdata.Diw_1) - double.Parse(inertnessdata.Diw_bc)).ToString("0.0");
                                        listc.Add(cdata1);
                                        cdata2.NominalValue = inertnessdata.Diw_bc;
                                        cdata2.FromSpeed = "48";
                                        cdata2.ToSpeed = "16";
                                        cdata2.ForceSettingValue1 = "0";
                                        cdata2.ActualTime1 = inertnessdata.Acd1_2;
                                        cdata2.ForceRealTime1 = inertnessdata.Acd1_2;
                                        cdata2.ForceSettingValue2 = "1170";
                                        cdata2.ActualTime2 = inertnessdata.Acd2_2;
                                        cdata2.ForceRealTime2 = inertnessdata.Acd2_2;
                                        cdata2.RealValue = inertnessdata.Diw_2;
                                        cdata2.Deviation = (double.Parse(inertnessdata.Diw_2) - double.Parse(inertnessdata.Diw_bc)).ToString("0.0");
                                        listc.Add(cdata2);
                                        cdata3.NominalValue = inertnessdata.Diw_bc;
                                        cdata3.FromSpeed = "48";
                                        cdata3.ToSpeed = "16";
                                        cdata3.ForceSettingValue1 = "0";
                                        cdata3.ActualTime1 = inertnessdata.Acd1_3;
                                        cdata3.ForceRealTime1 = inertnessdata.Acd1_3;
                                        cdata3.ForceSettingValue2 = "1170";
                                        cdata3.ActualTime2 = inertnessdata.Acd2_3;
                                        cdata3.ForceRealTime2 = inertnessdata.Acd2_3;
                                        cdata3.RealValue = inertnessdata.Diw_3;
                                        cdata3.Deviation = (double.Parse(inertnessdata.Diw_3) - double.Parse(inertnessdata.Diw_bc)).ToString("0.0");
                                        listc.Add(cdata3);
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_GL_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传惯量标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传惯量标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "废气仪标定":
                                #region 废气仪标定
                                newCsvPath = "C://jcdatatxt/" + "AnalyzerCalCheck.csv";
                                //carinfor.FQYdemarcate fqydmct = new carinfor.FQYdemarcate();
                                analysismeterdata = analysismetercontrol.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveAnalysisDemarcateDataByIni(analysismeterdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (analysismeterdata.Bdjg == "不合格")
                                {
                                    Msg(label1, panel4, "废气仪标定结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                }
                                else if (analysismeterdata.Bdjg == "合格")
                                {
                                    Msg(label1, panel4, "废气仪标定结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYBD", "0");
                                }
                                else
                                {
                                    Msg(label1, panel4, "废气仪未完成标定退出");
                                }
                                if (mainPanel.isNetUsed)
                                {
                                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE )
                                    {
                                        #region neusoft
                                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                                        {
                                            if (analysismeterdata.Bdjg == "合格" || analysismeterdata.Bdjg == "不合格")
                                            {
                                                NeusoftUtil.AnalyzerTest analyzercalcheckdata = new NeusoftUtil.AnalyzerTest();
                                                analyzercalcheckdata.OutlookID = mainPanel.equipmodel.FXYBH;
                                                analyzercalcheckdata.Type = (analysismeterdata.Gdjz == "0" ? "4" : "1");
                                                analyzercalcheckdata.BeginTime = analysismeterdata.Starttime;
                                                analyzercalcheckdata.STD_CH = analysismeterdata.c3h8;
                                                analyzercalcheckdata.STD_CO = analysismeterdata.Cobz.ToString("0.00");
                                                analyzercalcheckdata.STD_CO2 = analysismeterdata.Co2bz.ToString("0.00");
                                                analyzercalcheckdata.STD_NO = analysismeterdata.Nobz.ToString("0");
                                                analyzercalcheckdata.STD_O2 = "0";
                                                analyzercalcheckdata.MEA_HC = analysismeterdata.Hcclz.ToString("0");
                                                analyzercalcheckdata.MEA_CO = analysismeterdata.Coclz.ToString("0.00");
                                                analyzercalcheckdata.MEA_CO2 = analysismeterdata.Co2clz.ToString("0.00");
                                                analyzercalcheckdata.MEA_NO = analysismeterdata.Noclz.ToString("0");
                                                analyzercalcheckdata.MEA_O2 = "0";
                                                analyzercalcheckdata.PEF = analysismeterdata.Pef;
                                                analyzercalcheckdata.Result = (analysismeterdata.Bdjg == "合格"?"1":"0");
                                                string result, inf;
                                                DataTable dtack;
                                                mainPanel.sysocket.UploadAnalyzerTest(analyzercalcheckdata, null, out result, out inf, out dtack);
                                            }
                                        }
                                        else
                                        {
                                            if (analysismeterdata.Bdjg == "合格" || analysismeterdata.Bdjg == "不合格")
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    NeusoftUtil.AnalyzerCalCheck analyzercalcheckdata = new NeusoftUtil.AnalyzerCalCheck();
                                                    analyzercalcheckdata.StartTime = analysismeterdata.Starttime;
                                                    analyzercalcheckdata.HCTag = analysismeterdata.Hcbz.ToString();
                                                    analyzercalcheckdata.COTag = analysismeterdata.Cobz.ToString();
                                                    analyzercalcheckdata.CO2Tag = analysismeterdata.Co2bz.ToString();
                                                    analyzercalcheckdata.NOTag = analysismeterdata.Nobz.ToString();
                                                    analyzercalcheckdata.HCCheckResult = analysismeterdata.Hcclz.ToString();
                                                    analyzercalcheckdata.COCheckResult = analysismeterdata.Coclz.ToString();
                                                    analyzercalcheckdata.CO2CheckResult = analysismeterdata.Co2clz.ToString();
                                                    analyzercalcheckdata.NOCheckResult = analysismeterdata.Noclz.ToString();
                                                    analyzercalcheckdata.CheckHCTag = analysismeterdata.Hcbz.ToString();
                                                    analyzercalcheckdata.CheckCOTag = analysismeterdata.Cobz.ToString();
                                                    analyzercalcheckdata.CheckCO2Tag = analysismeterdata.Co2bz.ToString();
                                                    analyzercalcheckdata.CheckNOTag = analysismeterdata.Co2bz.ToString();
                                                    bool pdjg = true;
                                                    if (analysismeterdata.Gdjz == "0")//high check
                                                    {
                                                        if (Math.Abs(analysismeterdata.Hcbz - analysismeterdata.Hcclz) * 100.0 / analysismeterdata.Hcbz > float.Parse(calstandarddata.HCCalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Cobz - analysismeterdata.Coclz) * 100.0 / analysismeterdata.Cobz > float.Parse(calstandarddata.COCalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Co2bz - analysismeterdata.Coclz) * 100.0 / analysismeterdata.Co2bz > float.Parse(calstandarddata.CO2CalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Nobz - analysismeterdata.Noclz) * 100.0 / analysismeterdata.Nobz > float.Parse(calstandarddata.NOCalRel))
                                                            pdjg = false;
                                                    }
                                                    else
                                                    {
                                                        if (Math.Abs(analysismeterdata.Hcbz - analysismeterdata.Hcclz) > float.Parse(calstandarddata.HCCalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Cobz - analysismeterdata.Coclz) > float.Parse(calstandarddata.COCalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Co2bz - analysismeterdata.Coclz) > float.Parse(calstandarddata.CO2CalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Nobz - analysismeterdata.Noclz) > float.Parse(calstandarddata.NOCalAbs))
                                                            pdjg = false;
                                                    }
                                                    analyzercalcheckdata.COT10 = "1.2";
                                                    analyzercalcheckdata.HCT10 = "1.3";
                                                    analyzercalcheckdata.CO2T10 = "1.2";
                                                    analyzercalcheckdata.NOT10 = "2.3";
                                                    analyzercalcheckdata.O2T10 = "2.5";
                                                    analyzercalcheckdata.COT90 = "6.5";
                                                    analyzercalcheckdata.HCT90 = "6.4";
                                                    analyzercalcheckdata.CO2T90 = "6.5";
                                                    analyzercalcheckdata.NOT90 = "7.3";
                                                    analyzercalcheckdata.O2T90 = "8.6";
                                                    analyzercalcheckdata.PEF = analysismeterdata.Pef;
                                                    analyzercalcheckdata.Result = (analysismeterdata.Bdjg == "合格") ? "1" : "0";
                                                    NeusoftUtil.AnalyzerLeakTest analyzerleakdata = new NeusoftUtil.AnalyzerLeakTest();
                                                    analyzerleakdata.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    analyzerleakdata.Result = "1";
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    string ackresult, errormessage;
                                                    mainPanel.neusoftsocket.UploadAnalyzerLeakTestRequest(analyzerleakdata, out ackresult, out errormessage);
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    mainPanel.neusoftsocket.UploadAnalyzerCalCheckRequest(analyzercalcheckdata, dataseconds, out ackresult, out errormessage);
                                                    if (ackresult != "-1")
                                                    {
                                                        if (pdjg)
                                                            Msg(label1, panel4, "废气仪检查合格," + isCsvAlive);
                                                        else
                                                            Msg(label1, panel4, "废气仪检查不合格," + isCsvAlive);
                                                    }
                                                    else
                                                    {
                                                        Msg(label1, panel4, "检查失败，数据上传失败");
                                                        MessageBox.Show(errormessage, "警告");
                                                    }
                                                }
                                                else
                                                {
                                                    Msg(label1, panel4, "检查失败,没有找到过程数据");
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.废气校准]);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0" ? "3" : "1");
                                            hstb.Add("DATA2", analysismeterdata.c3h8);
                                            hstb.Add("DATA3",DateTime.Parse( analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA4", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA5", analysismeterdata.Hcbz.ToString("0"));
                                            hstb.Add("DATA6", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA7", analysismeterdata.hcabswc);
                                            hstb.Add("DATA8", analysismeterdata.hcpc);
                                            hstb.Add("DATA9", "");
                                            hstb.Add("DATA10", "");
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA14", analysismeterdata.Coclz.ToString("0.00"));
                                            hstb.Add("DATA15", analysismeterdata.coabswc);
                                            hstb.Add("DATA16", analysismeterdata.copc);
                                            hstb.Add("DATA17", "");
                                            hstb.Add("DATA18", "");
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA22", analysismeterdata.Co2clz.ToString("0.00"));
                                            hstb.Add("DATA23", analysismeterdata.co2abswc);
                                            hstb.Add("DATA24", analysismeterdata.co2pc);
                                            hstb.Add("DATA25", "");
                                            hstb.Add("DATA26", "");
                                            hstb.Add("DATA27", "");
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA30", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA31", analysismeterdata.noabswc);
                                            hstb.Add("DATA32", analysismeterdata.nopc);
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            hstb.Add("DATA37", analysismeterdata.Pef);
                                            hstb.Add("DATA38", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句失败");
                                            }
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_FXYBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0" ? "3" : "1");
                                            hstb.Add("DATA2", analysismeterdata.c3h8);
                                            hstb.Add("DATA3", analysismeterdata.Starttime);
                                            hstb.Add("DATA4", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA5", analysismeterdata.Hcbz.ToString("0"));
                                            hstb.Add("DATA6", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA7", analysismeterdata.hcabswc);
                                            hstb.Add("DATA8", analysismeterdata.hcpc);
                                            hstb.Add("DATA9", "");
                                            hstb.Add("DATA10", "");
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA14", analysismeterdata.Coclz.ToString("0.00"));
                                            hstb.Add("DATA15", analysismeterdata.coabswc);
                                            hstb.Add("DATA16", analysismeterdata.copc);
                                            hstb.Add("DATA17", "");
                                            hstb.Add("DATA18", "");
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA22", analysismeterdata.Co2clz.ToString("0.00"));
                                            hstb.Add("DATA23", analysismeterdata.co2abswc);
                                            hstb.Add("DATA24", analysismeterdata.co2pc);
                                            hstb.Add("DATA25", "");
                                            hstb.Add("DATA26", "");
                                            hstb.Add("DATA27", "");
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA30", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA31", analysismeterdata.noabswc);
                                            hstb.Add("DATA32", analysismeterdata.nopc);
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            hstb.Add("DATA37", analysismeterdata.Pef);
                                            hstb.Add("DATA38", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_FXYBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0" ? "3" : "1");
                                            hstb.Add("DATA2", analysismeterdata.c3h8);
                                            hstb.Add("DATA3", analysismeterdata.Starttime);
                                            hstb.Add("DATA4", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA5", analysismeterdata.Hcbz.ToString("0"));
                                            hstb.Add("DATA6", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA7", analysismeterdata.hcabswc);
                                            hstb.Add("DATA8", analysismeterdata.hcpc);
                                            hstb.Add("DATA9", "");
                                            hstb.Add("DATA10", "");
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA14", analysismeterdata.Coclz.ToString("0.00"));
                                            hstb.Add("DATA15", analysismeterdata.coabswc);
                                            hstb.Add("DATA16", analysismeterdata.copc);
                                            hstb.Add("DATA17", "");
                                            hstb.Add("DATA18", "");
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA22", analysismeterdata.Co2clz.ToString("0.00"));
                                            hstb.Add("DATA23", analysismeterdata.co2abswc);
                                            hstb.Add("DATA24", analysismeterdata.co2pc);
                                            hstb.Add("DATA25", "");
                                            hstb.Add("DATA26", "");
                                            hstb.Add("DATA27", "");
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA30", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA31", analysismeterdata.noabswc);
                                            hstb.Add("DATA32", analysismeterdata.nopc);
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            hstb.Add("DATA37", analysismeterdata.Pef);
                                            hstb.Add("DATA38", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("fqybqlx", analysismeterdata.Gdjz);
                                        htdata.Add("hcsdz", analysismeterdata.Hcbz.ToString("0"));
                                        htdata.Add("hcscz", analysismeterdata.Hcclz.ToString("0"));
                                        htdata.Add("hcwcz", analysismeterdata.hcabswc);
                                        htdata.Add("cosdz", analysismeterdata.Cobz.ToString("0.00"));
                                        htdata.Add("coscz", analysismeterdata.Coclz.ToString("0.00"));
                                        htdata.Add("cowcz", analysismeterdata.coabswc);
                                        htdata.Add("o2sdz", "");
                                        htdata.Add("o2scz", "");
                                        htdata.Add("o2wcz", "");
                                        htdata.Add("co2sdz", analysismeterdata.Co2bz.ToString("0.00"));
                                        htdata.Add("co2scz", analysismeterdata.Co2clz.ToString("0.00"));
                                        htdata.Add("co2wcz", analysismeterdata.co2abswc);
                                        htdata.Add("nosdz", analysismeterdata.Nobz.ToString("0"));
                                        htdata.Add("noscz", analysismeterdata.Noclz.ToString("0"));
                                        htdata.Add("nowcz", analysismeterdata.noabswc);
                                        htdata.Add("pef", analysismeterdata.Pef);
                                        htdata.Add("c3h8", analysismeterdata.c3h8);
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                    {
                                        #region 大理联网
                                        string code, msg;
                                        string reportID;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                        ht.Add("检测站编号", mainPanel.stationid);
                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                        ht.Add("设备类别", "4");
                                        ht.Add("设备名称", "废气仪标定");
                                        ht.Add("设备型号", mainPanel.equipmodel.FXYXH);
                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                        ht2.Add("HC设定值", analysismeterdata.Hcbz.ToString("0"));
                                        ht2.Add("HC实测值", analysismeterdata.Hcclz.ToString("0"));
                                        ht2.Add("HC偏差", analysismeterdata.hcabswc);
                                        ht2.Add("CO设定值", analysismeterdata.Cobz.ToString("0.00"));
                                        ht2.Add("CO实测值", analysismeterdata.Coclz.ToString("0.00"));
                                        ht2.Add("CO偏差", analysismeterdata.coabswc);
                                        ht2.Add("CO2设定值", analysismeterdata.Co2bz.ToString("0.00"));
                                        ht2.Add("CO2实测值", analysismeterdata.Co2clz.ToString("0.00"));
                                        ht2.Add("CO2偏差", analysismeterdata.co2abswc);
                                        ht2.Add("NO设定值", analysismeterdata.Nobz.ToString("0"));
                                        ht2.Add("NO实测值", analysismeterdata.Noclz.ToString("0"));
                                        ht2.Add("NO偏差", analysismeterdata.noabswc);
                                        if (!mainPanel.daliinterface.sendFqyBdData(ht, ht2, out code, out msg))
                                        {
                                            MessageBox.Show("发送废气仪标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                            ini.INIIO.saveLogInf("发送废气仪标定信息失败,code" + code + ",msg:" + msg);
                                            return;
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.GUILINNETMODE)
                                    {
                                        #region 桂林                        
                                        string result;
                                        string errmsg = "";
                                        DataTable dt = new DataTable();
                                        Hashtable ht2 = new Hashtable();
                                        if (analysismeterdata.Gdjz == "0")//高
                                        {
                                            ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                            ht2.Add("stationcode", mainPanel.stationid);
                                            ht2.Add("scenecode", mainPanel.lineid);
                                            ht2.Add("gastype", "1");
                                            ht2.Add("adjusttimestart", DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("adjusttimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("hcel", analysismeterdata.Hcbz.ToString("0"));
                                            ht2.Add("hcer", analysismeterdata.Hcclz.ToString("0"));
                                            ht2.Add("hced", "1");
                                            ht2.Add("coel", analysismeterdata.Cobz.ToString("0.00"));
                                            ht2.Add("coer", analysismeterdata.Coclz.ToString("0.00"));
                                            ht2.Add("coed", "1");
                                            ht2.Add("noel", analysismeterdata.Nobz.ToString("0"));
                                            ht2.Add("noer", analysismeterdata.Noclz.ToString("0"));
                                            ht2.Add("noed", "1");
                                            ht2.Add("co2el", analysismeterdata.Co2bz.ToString("0.00"));
                                            ht2.Add("co2er", analysismeterdata.Co2clz.ToString("0.00"));
                                            ht2.Add("co2ed", "1");
                                            ht2.Add("o2ed", "0");
                                            ht2.Add("o2ed", "0");
                                            ht2.Add("o2ed", "1");
                                            ht2.Add("pef", analysismeterdata.Pef);
                                            ht2.Add("c3h8", analysismeterdata.c3h8);
                                            ht2.Add("adjustresult", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            ht2.Add("remark", "");
                                            if (!mainPanel.gxinterface.uploadDemarcateData(4, ht2, out result, out errmsg))
                                            {
                                                ini.INIIO.saveLogInf("上传汽油线标定信息数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                                //return;
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("桂林联网信息：上传汽油线标定信息数据成功");
                                            }
                                        }
                                        else
                                        {
                                            ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                            ht2.Add("stationcode", mainPanel.stationid);
                                            ht2.Add("scenecode", mainPanel.lineid);
                                            ht2.Add("gastype", "2");
                                            ht2.Add("adjusttimestart", DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("adjusttimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("hcel", analysismeterdata.Hcbz.ToString("0"));
                                            ht2.Add("hcer", analysismeterdata.Hcclz.ToString("0"));
                                            ht2.Add("hced", "1");
                                            ht2.Add("coel", analysismeterdata.Cobz.ToString("0.00"));
                                            ht2.Add("coer", analysismeterdata.Coclz.ToString("0.00"));
                                            ht2.Add("coed", "1");
                                            ht2.Add("noel", analysismeterdata.Nobz.ToString("0"));
                                            ht2.Add("noer", analysismeterdata.Noclz.ToString("0"));
                                            ht2.Add("noed", "1");
                                            ht2.Add("co2el", analysismeterdata.Co2bz.ToString("0.00"));
                                            ht2.Add("co2er", analysismeterdata.Co2clz.ToString("0.00"));
                                            ht2.Add("co2ed", "1");
                                            ht2.Add("o2ed", "0");
                                            ht2.Add("o2ed", "0");
                                            ht2.Add("o2ed", "1");
                                            ht2.Add("pef", analysismeterdata.Pef);
                                            ht2.Add("c3h8", analysismeterdata.c3h8);
                                            ht2.Add("adjustresult", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            ht2.Add("remark", "");
                                            if (!mainPanel.gxinterface.uploadDemarcateData(4, ht2, out result, out errmsg))
                                            {
                                                ini.INIIO.saveLogInf("上传汽油线标定信息数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                                //return;
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("桂林联网信息：上传汽油线标定信息数据成功");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.PNNETMODE)
                                    {
                                        #region 平南
                                        string errmsg = "";
                                        Hashtable ht = new Hashtable();
                                        if (analysismeterdata.Gdjz == "0")//高
                                            ht.Add("GasType", "1");
                                        else
                                            ht.Add("GasType", "2");
                                        ht.Add("AdjustTimeStart", DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("AdjustTimeEnd", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("HCEL", analysismeterdata.Hcbz.ToString("0"));
                                        ht.Add("HCER", analysismeterdata.Hcclz.ToString("0"));
                                        ht.Add("HCED", "1");
                                        ht.Add("COEL", analysismeterdata.Cobz.ToString("0.00"));
                                        ht.Add("COER", analysismeterdata.Coclz.ToString("0.00"));
                                        ht.Add("COED", "1");
                                        ht.Add("NOEL", analysismeterdata.Nobz.ToString("0"));
                                        ht.Add("NOER", analysismeterdata.Noclz.ToString("0"));
                                        ht.Add("NOED", "1");
                                        ht.Add("CO2EL", analysismeterdata.Co2bz.ToString("0.00"));
                                        ht.Add("CO2ER", analysismeterdata.Co2clz.ToString("0.00"));
                                        ht.Add("CO2ED", "1");
                                        ht.Add("O2EL", "0");
                                        ht.Add("O2ER", "0");
                                        ht.Add("O2ED", "1");
                                        ht.Add("PEF", analysismeterdata.Pef);
                                        ht.Add("C3H8", analysismeterdata.c3h8);
                                        ht.Add("AdjustResult", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                        ht.Add("Remark", "");
                                        if (mainPanel.pninterface.UploadBdZjData(1, ht, out errmsg))
                                            ini.INIIO.saveLogInf("桂林联网信息：上传汽油线标定信息数据成功");
                                        else
                                            ini.INIIO.saveLogInf("上传汽油线标定信息数据失败\r\n" + "错误信息：" + errmsg);
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                                    {
                                        #region ezhou
                                        try
                                        {
                                            string msg, code;
                                            EzWebClient.AnalyzerInspectionData data = new EzWebClient.AnalyzerInspectionData(
                                                 analysismeterdata.Co2bz.ToString("0.00"),
                                                 analysismeterdata.Co2clz.ToString("0.00"),
                                                 analysismeterdata.Cobz.ToString("0.00"),
                                                 analysismeterdata.Coclz.ToString("0.00"),
                                                 (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1",
                                                 analysismeterdata.Hcbz.ToString("0"),
                                                 analysismeterdata.Hcclz.ToString("0"),
                                                 "",
                                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                                DateTime.Now.ToString("yyyyMMdd"), 
                                                DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"),
                                                mainPanel.stationid + mainPanel.lineid,
                                                analysismeterdata.Nobz.ToString("0"),
                                                analysismeterdata.Noclz.ToString("0"),
                                                "0",
                                                "0",
                                                analysismeterdata.Pef,
                                                "",
                                               mainPanel.stationid,
                                               "2",
                                               mainPanel.nowUser.userName,
                                                analysismeterdata.c3h8,
                                               DateTime.Now.ToString("yyyyMMddHHmmss")
                                                );
                                            if (!mainPanel.ezinterface.uploadAnalyzerInspectionData(data, out code, out msg))
                                            {
                                                ini.INIIO.saveLogInf("发送[自检/校准]命令失败,code" + code + ",msg:" + msg);
                                            }
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("发送[自检/校准]命令发生异常:" + er.Message);
                                        }
                                        #endregion
                                    }

                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        List<AhWebClient.ah_fxy_caldata> listc = new List<AhWebClient.ah_fxy_caldata>();
                                        AhWebClient.ah_fxy_caldata cdata = new AhWebClient.ah_fxy_caldata();
                                        pdata.Type = "4";
                                        
                                        pdata.BeginTime = DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        jdata.type = "1";
                                        jdata.CalibrateCount = "1";
                                        
                                        cdata.HCErrorLimit = "5";
                                        cdata.COErrorLimit = "5";
                                        cdata.CO2ErrorLimit = "5";
                                        cdata.NOErrorLimit = "8";
                                        cdata.ConcentrationType = (analysismeterdata.Gdjz == "0" ? "3" : "1");
                                        cdata.HCNominalValue = analysismeterdata.Hcbz.ToString("0");
                                        cdata.HCRealValue = analysismeterdata.Hcclz.ToString("0");
                                        cdata.HCDeviation = analysismeterdata.hcpc;

                                        cdata.CONominalValue = analysismeterdata.Cobz.ToString("0.00");
                                        cdata.CORealValue = analysismeterdata.Coclz.ToString("0.00");
                                        cdata.CODeviation = analysismeterdata.copc;

                                        cdata.CO2NominalValue = analysismeterdata.Co2bz.ToString("0.00");
                                        cdata.CO2RealValue = analysismeterdata.Co2clz.ToString("0.00");
                                        cdata.CO2Deviation = analysismeterdata.co2pc;

                                        cdata.NONominalValue = analysismeterdata.Nobz.ToString("0");
                                        cdata.NORealValue = analysismeterdata.Noclz.ToString("0");
                                        cdata.NODeviation = analysismeterdata.nopc;

                                        cdata.HCResult = (double.Parse(cdata.HCDeviation) > 5) ? "2" : "1";
                                        cdata.COResult = (double.Parse(cdata.CODeviation) > 5) ? "2" : "1";
                                        cdata.CO2Result = (double.Parse(cdata.CO2Deviation) > 5) ? "2" : "1";
                                        cdata.NOResult = (double.Parse(cdata.NODeviation) > 8) ? "2" : "1";

                                        cdata.O2NominalValue = "0";
                                        cdata.O2RealValue = "0";
                                        cdata.O2Deviation = "0";
                                        cdata.O2Result = "1";
                                        cdata.O2ErrorLimit = "5";
                                        cdata.PEF = analysismeterdata.Pef;
                                        listc.Add(cdata);
                                        if (cdata.HCResult == "1" && cdata.COResult == "1" && cdata.CO2Result == "1" && cdata.NOResult == "1")
                                            pdata.Judge = "1";
                                        else
                                            pdata.Judge = "2";
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata,jdata, listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "废气仪检查":
                                #region 废气仪检查
                                newCsvPath = "C://jcdatatxt/" + "AnalyzerCalCheck.csv";
                                //carinfor.FQYdemarcate fqydmct = new carinfor.FQYdemarcate();
                                analysismeterdata = analysismetercontrol.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveAnalysisDataByIni(analysismeterdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (analysismeterdata.Bdjg == "不合格")
                                {
                                    Msg(label1, panel4, "废气仪检查结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (analysismeterdata.Gdjz == "0")//high check
                                    {
                                        //mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYHIGHDATE", DateTime.Now.ToString());
                                        //if (mainPanel.linemodel.LOCKREASON == "废气仪高量程检查未通过")
                                        if (mainPanel.linesbbd.Fxyhighenable)
                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "废气仪高量程检查未通过");
                                    }
                                    else
                                    {
                                        // mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYLOWDATE", DateTime.Now.ToString());
                                        //if (mainPanel.linemodel.LOCKREASON == "废气仪低量程检查未通过")
                                        if (mainPanel.linesbbd.Fxylowenable)
                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "废气仪低量程检查未通过");
                                    }
                                }
                                else if(analysismeterdata.Bdjg == "合格")
                                {
                                    Msg(label1, panel4, "废气仪检查结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYBD", "0");
                                    if (analysismeterdata.Gdjz == "0")//high check
                                    {
                                        mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYHIGHDATE", DateTime.Now.ToString());
                                        if (mainPanel.linemodel.LOCKREASON == "废气仪高量程检查未通过")
                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                    }
                                    else
                                    {
                                        mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "FXYLOWDATE", DateTime.Now.ToString());
                                        if (mainPanel.linemodel.LOCKREASON == "废气仪低量程检查未通过")
                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                    }
                                }
                                else
                                {
                                    Msg(label1, panel4, "废气仪未完成标定退出");
                                }
                                if (mainPanel.isNetUsed&&(analysismeterdata.Bdjg == "合格"|| analysismeterdata.Bdjg == "不合格"))
                                {
                                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE )
                                    {
                                        #region neusoft
                                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                                        {
                                            if (analysismeterdata.Bdjg == "合格" || analysismeterdata.Bdjg == "不合格")
                                            {
                                                NeusoftUtil.AnalyzerLowGasTest analyzercalcheckdata = new NeusoftUtil.AnalyzerLowGasTest();
                                                analyzercalcheckdata.OutlookID = mainPanel.equipmodel.FXYBH;
                                                analyzercalcheckdata.BeginTime = analysismeterdata.Starttime;
                                                analyzercalcheckdata.STD_CH = analysismeterdata.c3h8;
                                                analyzercalcheckdata.STD_CO = analysismeterdata.Cobz.ToString("0.00");
                                                analyzercalcheckdata.STD_CO2 = analysismeterdata.Co2bz.ToString("0.00");
                                                analyzercalcheckdata.STD_NO = analysismeterdata.Nobz.ToString("0");
                                                analyzercalcheckdata.STD_O2 = "0";
                                                analyzercalcheckdata.MEA_HC = analysismeterdata.Hcclz.ToString("0");
                                                analyzercalcheckdata.MEA_CO = analysismeterdata.Coclz.ToString("0.00");
                                                analyzercalcheckdata.MEA_CO2 = analysismeterdata.Co2clz.ToString("0.00");
                                                analyzercalcheckdata.MEA_NO = analysismeterdata.Noclz.ToString("0");
                                                analyzercalcheckdata.MEA_O2 = "0";
                                                analyzercalcheckdata.PEF = analysismeterdata.Pef;
                                                analyzercalcheckdata.Result = (analysismeterdata.Bdjg == "合格" ? "1" : "0");
                                                string result, inf;
                                                DataTable dtack;
                                                mainPanel.sysocket.UploadAnalyzerLowGasTest(analyzercalcheckdata, null, out result, out inf, out dtack);
                                            }
                                        }
                                        else
                                        {
                                            if (analysismeterdata.Bdjg == "合格" || analysismeterdata.Bdjg == "不合格")
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    NeusoftUtil.AnalyzerCalCheck analyzercalcheckdata = new NeusoftUtil.AnalyzerCalCheck();
                                                    analyzercalcheckdata.StartTime = analysismeterdata.Starttime;
                                                    analyzercalcheckdata.HCTag = analysismeterdata.Hcbz.ToString();
                                                    analyzercalcheckdata.COTag = analysismeterdata.Cobz.ToString();
                                                    analyzercalcheckdata.CO2Tag = analysismeterdata.Co2bz.ToString();
                                                    analyzercalcheckdata.NOTag = analysismeterdata.Nobz.ToString();
                                                    analyzercalcheckdata.HCCheckResult = analysismeterdata.Hcclz.ToString();
                                                    analyzercalcheckdata.COCheckResult = analysismeterdata.Coclz.ToString();
                                                    analyzercalcheckdata.CO2CheckResult = analysismeterdata.Co2clz.ToString();
                                                    analyzercalcheckdata.NOCheckResult = analysismeterdata.Noclz.ToString();
                                                    analyzercalcheckdata.CheckHCTag = analysismeterdata.Hcbz.ToString();
                                                    analyzercalcheckdata.CheckCOTag = analysismeterdata.Cobz.ToString();
                                                    analyzercalcheckdata.CheckCO2Tag = analysismeterdata.Co2bz.ToString();
                                                    analyzercalcheckdata.CheckNOTag = analysismeterdata.Co2bz.ToString();
                                                    bool pdjg = true;
                                                    if (analysismeterdata.Gdjz == "0")//high check
                                                    {
                                                        if (Math.Abs(analysismeterdata.Hcbz - analysismeterdata.Hcclz) * 100.0 / analysismeterdata.Hcbz > float.Parse(calstandarddata.HCCalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Cobz - analysismeterdata.Coclz) * 100.0 / analysismeterdata.Cobz > float.Parse(calstandarddata.COCalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Co2bz - analysismeterdata.Coclz) * 100.0 / analysismeterdata.Co2bz > float.Parse(calstandarddata.CO2CalRel))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Nobz - analysismeterdata.Noclz) * 100.0 / analysismeterdata.Nobz > float.Parse(calstandarddata.NOCalRel))
                                                            pdjg = false;
                                                    }
                                                    else
                                                    {
                                                        if (Math.Abs(analysismeterdata.Hcbz - analysismeterdata.Hcclz) > float.Parse(calstandarddata.HCCalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Cobz - analysismeterdata.Coclz) > float.Parse(calstandarddata.COCalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Co2bz - analysismeterdata.Coclz) > float.Parse(calstandarddata.CO2CalAbs))
                                                            pdjg = false;
                                                        if (Math.Abs(analysismeterdata.Nobz - analysismeterdata.Noclz) > float.Parse(calstandarddata.NOCalAbs))
                                                            pdjg = false;
                                                    }
                                                    analyzercalcheckdata.COT10 = "1.2";
                                                    analyzercalcheckdata.HCT10 = "1.3";
                                                    analyzercalcheckdata.CO2T10 = "1.2";
                                                    analyzercalcheckdata.NOT10 = "2.3";
                                                    analyzercalcheckdata.O2T10 = "2.5";
                                                    analyzercalcheckdata.COT90 = "6.5";
                                                    analyzercalcheckdata.HCT90 = "6.4";
                                                    analyzercalcheckdata.CO2T90 = "6.5";
                                                    analyzercalcheckdata.NOT90 = "7.3";
                                                    analyzercalcheckdata.O2T90 = "8.6";
                                                    analyzercalcheckdata.PEF = analysismeterdata.Pef;
                                                    analyzercalcheckdata.Result = (analysismeterdata.Bdjg == "合格") ? "1" : "0";
                                                    NeusoftUtil.AnalyzerLeakTest analyzerleakdata = new NeusoftUtil.AnalyzerLeakTest();
                                                    analyzerleakdata.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    analyzerleakdata.Result = "1";
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    string ackresult, errormessage;
                                                    mainPanel.neusoftsocket.UploadAnalyzerLeakTestRequest(analyzerleakdata, out ackresult, out errormessage);
                                                    mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                    mainPanel.neusoftsocket.UploadAnalyzerCalCheckRequest(analyzercalcheckdata, dataseconds, out ackresult, out errormessage);
                                                    if (ackresult != "-1")
                                                    {
                                                        if (pdjg)
                                                            Msg(label1, panel4, "废气仪检查合格," + isCsvAlive);
                                                        else
                                                            Msg(label1, panel4, "废气仪检查不合格," + isCsvAlive);
                                                    }
                                                    else
                                                    {
                                                        Msg(label1, panel4, "检查失败，数据上传失败");
                                                        MessageBox.Show(errormessage, "警告");
                                                    }
                                                }
                                                else
                                                {
                                                    Msg(label1, panel4, "检查失败,没有找到过程数据");
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.分析仪检查]);
                                            hstb.Add("ZJSJ", DateTime.Now);
                                            hstb.Add("ZJJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0"?"3":"1");
                                            hstb.Add("DATA2", DateTime.Parse(analysismeterdata.Starttime).ToString("yyyyMMddHHmmss"));
                                            hstb.Add("DATA3", analysismeterdata.c3h8);
                                            hstb.Add("DATA4", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA5", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA6", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA7", "0.0");
                                            hstb.Add("DATA8", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA9", analysismeterdata.Coclz.ToString("0"));
                                            hstb.Add("DATA10", analysismeterdata.Co2clz.ToString("0"));
                                            hstb.Add("DATA11", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA12", "0.0");
                                            hstb.Add("DATA13", analysismeterdata.Pef);
                                            hstb.Add("DATA14", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");

                                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存分析仪检查自检信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存分析仪检查自检信息语句失败");
                                            }
                                            if (analysismeterdata.Gdjz == "1")
                                            {
                                                hstb.Clear();
                                                hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                                hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.低标气检查]);
                                                hstb.Add("ZJSJ", DateTime.Now);
                                                hstb.Add("ZJJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                                hstb.Add("JCZBH", mainPanel.stationid);
                                                hstb.Add("JCGWH", mainPanel.lineid);
                                                hstb.Add("ZT", "0");
                                                hstb.Add("DATA1",  "1");
                                                hstb.Add("DATA2", DateTime.Parse(analysismeterdata.Starttime).ToString("yyyyMMddHHmmss"));
                                                hstb.Add("DATA3", analysismeterdata.c3h8);
                                                hstb.Add("DATA4", analysismeterdata.Cobz.ToString("0.00"));
                                                hstb.Add("DATA5", analysismeterdata.Co2bz.ToString("0.00"));
                                                hstb.Add("DATA6", analysismeterdata.Nobz.ToString("0"));
                                                hstb.Add("DATA7", "0.0");
                                                hstb.Add("DATA8", analysismeterdata.Hcclz.ToString("0"));
                                                hstb.Add("DATA9", analysismeterdata.Coclz.ToString("0"));
                                                hstb.Add("DATA10", analysismeterdata.Co2clz.ToString("0"));
                                                hstb.Add("DATA11", analysismeterdata.Noclz.ToString("0"));
                                                hstb.Add("DATA12", "0.0");
                                                hstb.Add("DATA13", analysismeterdata.Pef);
                                                hstb.Add("DATA14", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");

                                                if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                                                {
                                                    ini.INIIO.saveLogInf("保存低标气检查自检信息语句成功");
                                                }
                                                else
                                                {
                                                    ini.INIIO.saveLogInf("保存低标气检查自检信息语句失败");
                                                }
                                            }
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_FXYBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0" ? "3" : "1");
                                            hstb.Add("DATA2", analysismeterdata.c3h8);
                                            hstb.Add("DATA3", analysismeterdata.Starttime);
                                            hstb.Add("DATA4", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA5", analysismeterdata.Hcbz.ToString("0"));
                                            hstb.Add("DATA6", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA7", analysismeterdata.hcabswc);
                                            hstb.Add("DATA8", analysismeterdata.hcpc);
                                            hstb.Add("DATA9", "");
                                            hstb.Add("DATA10", "");
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA14", analysismeterdata.Coclz.ToString("0.00"));
                                            hstb.Add("DATA15", analysismeterdata.coabswc);
                                            hstb.Add("DATA16", analysismeterdata.copc);
                                            hstb.Add("DATA17", "");
                                            hstb.Add("DATA18", "");
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA22", analysismeterdata.Co2clz.ToString("0.00"));
                                            hstb.Add("DATA23", analysismeterdata.co2abswc);
                                            hstb.Add("DATA24", analysismeterdata.co2pc);
                                            hstb.Add("DATA25", "");
                                            hstb.Add("DATA26", "");
                                            hstb.Add("DATA27", "");
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA30", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA31", analysismeterdata.noabswc);
                                            hstb.Add("DATA32", analysismeterdata.nopc);
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            hstb.Add("DATA37", analysismeterdata.Pef);
                                            hstb.Add("DATA38", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_FXYBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", analysismeterdata.Gdjz == "0" ? "3" : "1");
                                            hstb.Add("DATA2", analysismeterdata.c3h8);
                                            hstb.Add("DATA3", analysismeterdata.Starttime);
                                            hstb.Add("DATA4", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA5", analysismeterdata.Hcbz.ToString("0"));
                                            hstb.Add("DATA6", analysismeterdata.Hcclz.ToString("0"));
                                            hstb.Add("DATA7", analysismeterdata.hcabswc);
                                            hstb.Add("DATA8", analysismeterdata.hcpc);
                                            hstb.Add("DATA9", "");
                                            hstb.Add("DATA10", "");
                                            hstb.Add("DATA11", "");
                                            hstb.Add("DATA12", "");
                                            hstb.Add("DATA13", analysismeterdata.Cobz.ToString("0.00"));
                                            hstb.Add("DATA14", analysismeterdata.Coclz.ToString("0.00"));
                                            hstb.Add("DATA15", analysismeterdata.coabswc);
                                            hstb.Add("DATA16", analysismeterdata.copc);
                                            hstb.Add("DATA17", "");
                                            hstb.Add("DATA18", "");
                                            hstb.Add("DATA19", "");
                                            hstb.Add("DATA20", "");
                                            hstb.Add("DATA21", analysismeterdata.Co2bz.ToString("0.00"));
                                            hstb.Add("DATA22", analysismeterdata.Co2clz.ToString("0.00"));
                                            hstb.Add("DATA23", analysismeterdata.co2abswc);
                                            hstb.Add("DATA24", analysismeterdata.co2pc);
                                            hstb.Add("DATA25", "");
                                            hstb.Add("DATA26", "");
                                            hstb.Add("DATA27", "");
                                            hstb.Add("DATA28", "");
                                            hstb.Add("DATA29", analysismeterdata.Nobz.ToString("0"));
                                            hstb.Add("DATA30", analysismeterdata.Noclz.ToString("0"));
                                            hstb.Add("DATA31", analysismeterdata.noabswc);
                                            hstb.Add("DATA32", analysismeterdata.nopc);
                                            hstb.Add("DATA33", "");
                                            hstb.Add("DATA34", "");
                                            hstb.Add("DATA35", "");
                                            hstb.Add("DATA36", "");

                                            hstb.Add("DATA37", analysismeterdata.Pef);
                                            hstb.Add("DATA38", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存废气仪标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                                    {
                                        #region jiangxi
                                        if (analysismeterdata.Gdjz == "0")//高
                                        {
                                            JxWebClient.jxFqyBaseCheckdata jxdata = new JxWebClient.jxFqyBaseCheckdata();
                                            jxdata.testInstitutionId = mainPanel.stationid;
                                            jxdata.testLineId = mainPanel.jxwebinf.lineid;
                                            jxdata.checkType = "3";
                                            jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                                            jxdata.startTime = analysismeterdata.Starttime;
                                            jxdata.resultFlag = analysismeterdata.Bdjg == "合格" ? "1" : "0";
                                            jxdata.standardC3h8 = analysismeterdata.c3h8;
                                            jxdata.standardCo = analysismeterdata.Cobz.ToString("0.00");
                                            jxdata.standardCo2 = analysismeterdata.Co2bz.ToString("0.00");
                                            jxdata.standardNo = analysismeterdata.Nobz.ToString("0");
                                            jxdata.standardO2 = "";
                                            jxdata.actualHc = analysismeterdata.Hcclz.ToString("0");
                                            jxdata.actualCo = analysismeterdata.Coclz.ToString("0.00");
                                            jxdata.actualCo2 = analysismeterdata.Co2clz.ToString("0.00");
                                            jxdata.actualNo = analysismeterdata.Noclz.ToString("0");
                                            jxdata.actualO2 = "";
                                            jxdata.pefValue = analysismeterdata.Pef;
                                            string code, msg;
                                            if (!mainPanel.jxinterface.sendSelfCheckData(3, jxdata, out code, out msg))
                                            {
                                                MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                                                ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                                            }
                                        }
                                        else
                                        {
                                            JxWebClient.jxFqyLowCheckdata jxdata = new JxWebClient.jxFqyLowCheckdata();
                                            jxdata.testInstitutionId = mainPanel.stationid;
                                            jxdata.testLineId = mainPanel.jxwebinf.lineid;
                                            
                                            jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                                            jxdata.startTime = analysismeterdata.Starttime;
                                            jxdata.resultFlag = analysismeterdata.Bdjg == "合格" ? "1" : "0";
                                            jxdata.standardC3h8 = analysismeterdata.c3h8;
                                            jxdata.standardCo = analysismeterdata.Cobz.ToString("0.00");
                                            jxdata.standardCo2 = analysismeterdata.Co2bz.ToString("0.00");
                                            jxdata.standardNo = analysismeterdata.Nobz.ToString("0");
                                            jxdata.standardO2 = "";
                                            jxdata.actualHc = analysismeterdata.Hcclz.ToString("0");
                                            jxdata.actualCo = analysismeterdata.Coclz.ToString("0.00");
                                            jxdata.actualCo2 = analysismeterdata.Co2clz.ToString("0.00");
                                            jxdata.actualNo = analysismeterdata.Noclz.ToString("0");
                                            jxdata.actualO2 = "";
                                            jxdata.pefValue = analysismeterdata.Pef;
                                            string code, msg;
                                            if (!mainPanel.jxinterface.sendSelfCheckData(6, jxdata, out code, out msg))
                                            {
                                                MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                                                ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                                    {
                                        #region 中科宇图
                                        try
                                        {
                                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪校准");
                                            string ackresult = "", errormessage = "";

                                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                                            {
                                                mainPanel.xmlanalysis.ReadACKString(
                                                mainPanel.yichangInterface.wqfxyAdjust(
                                                    mainPanel.zkytwebinf.regcode,
                                                    analysismeterdata.Gdjz == "0" ? "1" : "2",
                                                     analysismeterdata.Co2bz,
                                                     analysismeterdata.Co2clz,
                                                     analysismeterdata.Cobz,
                                                     analysismeterdata.Coclz,
                                                     analysismeterdata.Nobz,
                                                      analysismeterdata.Noclz,
                                                      analysismeterdata.Hcbz,
                                                      analysismeterdata.Hcclz,
                                                      0.51,
                                                      0.50,
                                                      double.Parse(analysismeterdata.Pef),
                                                      double.Parse(analysismeterdata.c3h8),
                                                      analysismeterdata.Bdjg == "合格" ? "1" : "0",
                                                    DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss"),
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                    ""),
                                                out ackresult,
                                                out errormessage);
                                            }
                                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                                            {
                                                mainPanel.xmlanalysis.ReadACKString(
                                                mainPanel.yichangInterfaceOther.wqfxyAdjust(
                                                    mainPanel.zkytwebinf.regcode,
                                                    analysismeterdata.Gdjz == "0" ? "1" : "2",
                                                     analysismeterdata.Co2bz,
                                                     analysismeterdata.Co2clz,
                                                     analysismeterdata.Cobz,
                                                     analysismeterdata.Coclz,
                                                     analysismeterdata.Nobz,
                                                      analysismeterdata.Noclz,
                                                      analysismeterdata.Hcbz,
                                                      analysismeterdata.Hcclz,
                                                      0.51,
                                                      0.50,
                                                      double.Parse(analysismeterdata.Pef),
                                                      double.Parse(analysismeterdata.c3h8),
                                                      analysismeterdata.Bdjg == "合格" ? "1" : "0",
                                                    DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss"),
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                    ""),
                                                out ackresult,
                                                out errormessage);
                                            }
                                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                                            {
                                                mainPanel.xmlanalysis.ReadACKString(
                                                mainPanel.yichangInterfaceYnbs.wqfxybd(
                                                    mainPanel.zkytwebinf.regcode,
                                                    analysismeterdata.Gdjz == "0" ? "1" : "2",
                                                     analysismeterdata.Co2bz,
                                                     analysismeterdata.Co2clz,
                                                     analysismeterdata.Cobz,
                                                     analysismeterdata.Coclz,
                                                     analysismeterdata.Nobz,
                                                      analysismeterdata.Noclz,
                                                      analysismeterdata.Hcbz,
                                                      analysismeterdata.Hcclz,
                                                      0.51,
                                                      0.50,
                                                      double.Parse(analysismeterdata.Pef),
                                                      double.Parse(analysismeterdata.c3h8),
                                                      analysismeterdata.Bdjg == "合格" ? "1" : "0",
                                                    DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss"),
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                    ""),
                                                out ackresult,
                                                out errormessage);
                                            }
                                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪校准成功:result=" + ackresult);

                                            //ini.INIIO.saveLogInf("联网信息：上传五气分析仪校准成功:result=" + ackresult);
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪校准异常:" + er.Message);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "2");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("fqybqlx", analysismeterdata.Gdjz);
                                        htdata.Add("hcsdz", analysismeterdata.Hcbz.ToString("0"));
                                        htdata.Add("hcscz", analysismeterdata.Hcclz.ToString("0"));
                                        htdata.Add("hcwcz", analysismeterdata.hcabswc);
                                        htdata.Add("cosdz", analysismeterdata.Cobz.ToString("0.00"));
                                        htdata.Add("coscz", analysismeterdata.Coclz.ToString("0.00"));
                                        htdata.Add("cowcz", analysismeterdata.coabswc);
                                        htdata.Add("o2sdz", "");
                                        htdata.Add("o2scz", "");
                                        htdata.Add("o2wcz", "");
                                        htdata.Add("co2sdz", analysismeterdata.Co2bz.ToString("0.00"));
                                        htdata.Add("co2scz", analysismeterdata.Co2clz.ToString("0.00"));
                                        htdata.Add("co2wcz", analysismeterdata.co2abswc);
                                        htdata.Add("nosdz", analysismeterdata.Nobz.ToString("0"));
                                        htdata.Add("noscz", analysismeterdata.Noclz.ToString("0"));
                                        htdata.Add("nowcz", analysismeterdata.noabswc);
                                        htdata.Add("pef", analysismeterdata.Pef);
                                        htdata.Add("c3h8", analysismeterdata.c3h8);
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                    {
                                        #region 大理联网
                                        string code, msg;
                                        string reportID;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                        ht.Add("检测站编号", mainPanel.stationid);
                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                        ht.Add("设备类别", "4");
                                        ht.Add("设备名称", "废气仪标定");
                                        ht.Add("设备型号", mainPanel.equipmodel.FXYXH);
                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                        ht2.Add("HC设定值", analysismeterdata.Hcbz.ToString("0"));
                                        ht2.Add("HC实测值", analysismeterdata.Hcclz.ToString("0"));
                                        ht2.Add("HC偏差", analysismeterdata.hcabswc);
                                        ht2.Add("CO设定值", analysismeterdata.Cobz.ToString("0.00"));
                                        ht2.Add("CO实测值", analysismeterdata.Coclz.ToString("0.00"));
                                        ht2.Add("CO偏差", analysismeterdata.coabswc);
                                        ht2.Add("CO2设定值", analysismeterdata.Co2bz.ToString("0.00"));
                                        ht2.Add("CO2实测值", analysismeterdata.Co2clz.ToString("0.00"));
                                        ht2.Add("CO2偏差", analysismeterdata.co2abswc);
                                        ht2.Add("NO设定值", analysismeterdata.Nobz.ToString("0"));
                                        ht2.Add("NO实测值", analysismeterdata.Noclz.ToString("0"));
                                        ht2.Add("NO偏差", analysismeterdata.noabswc);
                                        if (!mainPanel.daliinterface.sendFqyBdData(ht, ht2, out code, out msg))
                                        {
                                            MessageBox.Show("发送废气仪标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                            ini.INIIO.saveLogInf("发送废气仪标定信息失败,code" + code + ",msg:" + msg);
                                            return;
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.GUILINNETMODE)
                                    {
                                        #region 桂林                        
                                        string result;
                                        string errmsg = "";
                                        DataTable dt = new DataTable();
                                        Hashtable ht2 = new Hashtable();
                                        if (analysismeterdata.Gdjz == "0")//高
                                        {
                                            ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                            ht2.Add("stationcode", mainPanel.stationid);
                                            ht2.Add("scenecode", mainPanel.lineid);
                                            ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                                            ht2.Add("checktype", "3");
                                            ht2.Add("checktimestart", DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("checktimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("bc3h8", analysismeterdata.c3h8);
                                            ht2.Add("bco", analysismeterdata.Cobz.ToString("0.00"));
                                            ht2.Add("bco2", analysismeterdata.Co2bz.ToString("0.00"));
                                            ht2.Add("bno", analysismeterdata.Nobz.ToString("0"));
                                            ht2.Add("bo2", "0");
                                            ht2.Add("hcer",analysismeterdata.Hcclz.ToString("0"));
                                            ht2.Add("coer", analysismeterdata.Coclz.ToString("0.00"));
                                            ht2.Add("co2er", analysismeterdata.Co2clz.ToString("0.00"));
                                            ht2.Add("noer", analysismeterdata.Noclz.ToString("0"));
                                            ht2.Add("o2","0");
                                            ht2.Add("pef", analysismeterdata.Pef);
                                            ht2.Add("checkresult", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            ht2.Add("remark", "");
                                            if (!mainPanel.gxinterface.uploadSelfCheckData(4, ht2, out result, out errmsg))
                                            {
                                                ini.INIIO.saveLogInf("上传自检数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                                //return;
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("桂林联网信息：上传自检数据成功");
                                            }
                                        }
                                        else
                                        {
                                            ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                            ht2.Add("stationcode", mainPanel.stationid);
                                            ht2.Add("scenecode", mainPanel.lineid);
                                            ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                                            ht2.Add("checktype", "1");
                                            ht2.Add("checktimestart", DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("checktimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("bc3h8", analysismeterdata.c3h8);
                                            ht2.Add("bco", analysismeterdata.Cobz.ToString("0.00"));
                                            ht2.Add("bco2", analysismeterdata.Co2bz.ToString("0.00"));
                                            ht2.Add("bno", analysismeterdata.Nobz.ToString("0"));
                                            ht2.Add("bo2", "0");
                                            ht2.Add("hcer", analysismeterdata.Hcclz.ToString("0"));
                                            ht2.Add("coer", analysismeterdata.Coclz.ToString("0.00"));
                                            ht2.Add("co2er", analysismeterdata.Co2clz.ToString("0.00"));
                                            ht2.Add("noer", analysismeterdata.Noclz.ToString("0"));
                                            ht2.Add("o2", "0");
                                            ht2.Add("pef", analysismeterdata.Pef);
                                            ht2.Add("checkresult", (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1");
                                            ht2.Add("remark", "");
                                            if (!mainPanel.gxinterface.uploadSelfCheckData(7, ht2, out result, out errmsg))
                                            {
                                                ini.INIIO.saveLogInf("上传自检数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                                //return;
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("桂林联网信息：上传自检数据成功");
                                            }
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                                    {
                                        #region ezhou
                                        try
                                        {
                                            string msg, code;
                                            EzWebClient.LowMarkGasData data = new EzWebClient.LowMarkGasData(
                                                 analysismeterdata.Co2bz.ToString("0.00"),
                                                 analysismeterdata.Co2clz.ToString("0.00"),
                                                 analysismeterdata.Cobz.ToString("0.00"),
                                                 analysismeterdata.Coclz.ToString("0.00"),
                                                 (analysismeterdata.Bdjg == "不合格" || analysismeterdata.Bdjg == "0") ? "0" : "1",
                                                 analysismeterdata.Hcbz.ToString("0"),
                                                 analysismeterdata.Hcclz.ToString("0"),
                                                 "",
                                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                                DateTime.Now.ToString("yyyyMMdd"),
                                                DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"),
                                                mainPanel.stationid + mainPanel.lineid,
                                                analysismeterdata.Nobz.ToString("0"),
                                                analysismeterdata.Noclz.ToString("0"),
                                                "0",
                                                "0",
                                                analysismeterdata.Pef,
                                                "",
                                               mainPanel.stationid,
                                               analysismeterdata.Gdjz == "0"?"3":"1",
                                               mainPanel.nowUser.userName,
                                                analysismeterdata.c3h8,
                                               DateTime.Now.ToString("yyyyMMddHHmmss")
                                                );
                                            if (!mainPanel.ezinterface.uploadLowMarkGasData(data, out code, out msg))
                                            {
                                                ini.INIIO.saveLogInf("发送[自检/校准]命令失败,code" + code + ",msg:" + msg);
                                            }
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("发送[自检/校准]命令发生异常:" + er.Message);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.XBNETMODE)
                                    {
                                        #region xibang
                                        string code, msg;
                                        try
                                        {
                                            carinfo.XB_BD_PUBLIC_DATA pdata = new carinfo.XB_BD_PUBLIC_DATA();
                                            pdata.DevID = mainPanel.equipmodel.FXYBH;
                                            pdata.Items = "06";
                                            pdata.BeginTime = DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                            pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                            pdata.WD = "0";
                                            pdata.SD = "0";
                                            pdata.DQY = "0";
                                            pdata.Operator = mainPanel.nowUser.userName;
                                            carinfo.XB_EXHAUSTGAS_BD_DATA data = new carinfo.XB_EXHAUSTGAS_BD_DATA();
                                            data.CabHCTag = ((int)(double.Parse(analysismeterdata.c3h8))).ToString("0");
                                            data.CabCOTag = analysismeterdata.Cobz.ToString("0.000");
                                            data.CabCO2Tag = analysismeterdata.Co2bz.ToString("0.00");
                                            data.CabNOTag = analysismeterdata.Nobz.ToString("0");
                                            data.CheckHCTag = ((int)(double.Parse(analysismeterdata.c3h8))).ToString("0");
                                            data.CheckCOTag = analysismeterdata.Cobz.ToString("0.000");
                                            data.CheckCO2Tag = analysismeterdata.Co2bz.ToString("0.00");
                                            data.CheckNOTag = analysismeterdata.Nobz.ToString("0");
                                            data.HCCabResult = analysismeterdata.Hcclz.ToString("0");
                                            data.COCabResult = analysismeterdata.Coclz.ToString("0.000");
                                            data.CO2CabResult = analysismeterdata.Co2clz.ToString("0.00");
                                            data.NOCabResult = analysismeterdata.Noclz.ToString("0");
                                            data.PEFCabResult = analysismeterdata.Pef;
                                            data.HCCheckResult = analysismeterdata.Hcclz.ToString("0");
                                            data.COCheckResult = analysismeterdata.Coclz.ToString("0.000");
                                            data.CO2CheckResult = analysismeterdata.Co2clz.ToString("0.00");
                                            data.NOCheckResult = analysismeterdata.Noclz.ToString("0");
                                            data.PEFCheckResult = analysismeterdata.Pef;
                                            data.HCCabError =(double.Parse( analysismeterdata.hcabswc) * 100 / analysismeterdata.Hcbz).ToString("0.0");
                                            data.COCabError = (double.Parse(analysismeterdata.coabswc) * 100 / analysismeterdata.Cobz).ToString("0.0");
                                            data.CO2CabError = (double.Parse(analysismeterdata.co2abswc) * 100 / analysismeterdata.Co2bz).ToString("0.0");
                                            data.NOCabError = (double.Parse(analysismeterdata.noabswc) * 100 / analysismeterdata.Nobz).ToString("0.0");
                                            data.HCCheckError = (double.Parse(analysismeterdata.hcabswc) * 100 / analysismeterdata.Hcbz).ToString("0.0");
                                            data.COCheckError = (double.Parse(analysismeterdata.coabswc) * 100 / analysismeterdata.Cobz).ToString("0.0");
                                            data.CO2CheckError = (double.Parse(analysismeterdata.co2abswc) * 100 / analysismeterdata.Co2bz).ToString("0.0");
                                            data.NOCheckError = (double.Parse(analysismeterdata.noabswc) * 100 / analysismeterdata.Nobz).ToString("0.0");
                                            data.HCCabAllowError = "5";
                                            data.COCabAllowError = "5";
                                            data.CO2CabAllowError = "5";
                                            data.NOCabAllowError = "8";
                                            data.HCCheckAllowError = "5";
                                            data.COCheckAllowError = "5";
                                            data.CO2CheckAllowError = "5";
                                            data.NOCheckAllowError = "8";
                                            data.HCCabAllowAbsError = "4";
                                            data.COCabAllowAbsError = "0.02";
                                            data.CO2CabAllowAbsError = "0.3";
                                            data.NOCabAllowAbsError = "25";
                                            data.HCCheckAllowAbsError = "4";
                                            data.COCheckAllowAbsError = "0.02";
                                            data.CO2CheckAllowAbsError = "0.3";
                                            data.NOCheckAllowAbsError = "25";
                                            data.HCCabAbsError = analysismeterdata.hcabswc;
                                            data.COCabAbsError = analysismeterdata.coabswc;
                                            data.CO2CabAbsError = analysismeterdata.co2abswc;
                                            data.NOCabAbsError = analysismeterdata.noabswc;
                                            data.HCCheckAbsError = analysismeterdata.hcabswc;
                                            data.COCheckAbsError = analysismeterdata.coabswc;
                                            data.CO2CheckAbsError = analysismeterdata.co2abswc;
                                            data.NOCheckAbsError = analysismeterdata.noabswc;
                                            if (analysismeterdata.Gdjz == "0")//高
                                            {
                                                data.HCCabEvl = (double.Parse(analysismeterdata.hcabswc) > double.Parse(data.HCCabAllowAbsError)) ? "F" : "T";
                                                data.COCabEvl = (double.Parse(analysismeterdata.coabswc) > double.Parse(data.COCabAllowAbsError)) ? "F" : "T";
                                                data.CO2CabEvl = (double.Parse(analysismeterdata.co2abswc) > double.Parse(data.CO2CabAllowAbsError)) ? "F" : "T";
                                                data.NOCabEvl = (double.Parse(analysismeterdata.noabswc) > double.Parse(data.NOCabAllowAbsError)) ? "F" : "T";
                                                data.HCCheckEvl = (double.Parse(analysismeterdata.hcabswc) > double.Parse(data.HCCabAllowAbsError)) ? "F" : "T";
                                                data.COCheckEvl = (double.Parse(analysismeterdata.coabswc) > double.Parse(data.COCabAllowAbsError)) ? "F" : "T";
                                                data.CO2CheckEvl = (double.Parse(analysismeterdata.co2abswc) > double.Parse(data.CO2CabAllowAbsError)) ? "F" : "T";
                                                data.NOCheckEvl = (double.Parse(analysismeterdata.noabswc) > double.Parse(data.NOCabAllowAbsError)) ? "F" : "T";
                                                if (data.HCCabEvl == "T" && data.COCabEvl == "T" && data.CO2CabEvl == "T" && data.NOCabEvl == "T")
                                                    data.GasCabEvl = "T";
                                                else
                                                    data.GasCabEvl = "F";
                                                data.GasCheckEvl = data.GasCabEvl;
                                            }
                                            else
                                            {
                                                data.HCCabEvl = (double.Parse(data.HCCabError) > double.Parse(data.HCCabAllowError)) ? "F" : "T";
                                                data.COCabEvl = (double.Parse(data.COCabError) > double.Parse(data.COCabAllowError)) ? "F" : "T";
                                                data.CO2CabEvl = (double.Parse(data.CO2CabError) > double.Parse(data.CO2CabAllowError)) ? "F" : "T";
                                                data.NOCabEvl = (double.Parse(data.NOCabError) > double.Parse(data.NOCabAllowError)) ? "F" : "T";
                                                data.HCCheckEvl = (double.Parse(data.HCCabError) > double.Parse(data.HCCabAllowError)) ? "F" : "T";
                                                data.COCheckEvl = (double.Parse(data.COCabError) > double.Parse(data.COCabAllowError)) ? "F" : "T";
                                                data.CO2CheckEvl = (double.Parse(data.CO2CabError) > double.Parse(data.CO2CabAllowError)) ? "F" : "T";
                                                data.NOCheckEvl = (double.Parse(data.NOCabError) > double.Parse(data.NOCabAllowError)) ? "F" : "T";
                                                if (data.HCCabEvl == "T" && data.COCabEvl == "T" && data.CO2CabEvl == "T" && data.NOCabEvl == "T")
                                                    data.GasCabEvl = "T";
                                                else
                                                    data.GasCabEvl = "F";
                                                data.GasCheckEvl = data.GasCabEvl;
                                            }
                                            if (!mainPanel.xbsocket.Send_BD_RESULT_DATA(pdata, data, out code, out msg))
                                            {
                                                ini.INIIO.saveLogInf("发送废气仪量程检查命令失败,code" + code + ",msg:" + msg);
                                            }
                                        }
                                        catch (Exception er)
                                        {
                                            ini.INIIO.saveLogInf("发送废气仪量程检查命令异常:" + er.Message);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽开始
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.BeginSelfTest(mainPanel.lineid, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("发送自检开始指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                                            //MessageBox.Show("发送自检开始指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                                            //return;
                                            //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_selfcheck_public_data pdata = new AhWebClient.ah_selfcheck_public_data();
                                        AhWebClient.ah_fxyjc_selfcheckdata cdata2 = new AhWebClient.ah_fxyjc_selfcheckdata();
                                        AhWebClient.ah_fxy_selfcheckdata cdata = new AhWebClient.ah_fxy_selfcheckdata();
                                        pdata.DeviceType = "2";
                                        pdata.BeginTime = DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        cdata.type = "1";
                                        cdata.CheckBeginTime = DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                        cdata.CommCheck ="1";
                                        cdata.PreheatInstrument = "1";
                                        cdata.Tightness ="1";
                                        cdata.InstrumentZero = "1";
                                        cdata.FlowResult = "1";
                                        cdata.ResidualHC = "0";
                                            cdata.HCErrorLimit = "5";
                                            cdata.COErrorLimit = "5";
                                            cdata.CO2ErrorLimit = "5";
                                            cdata.NOErrorLimit = "8";
                                        cdata.ConcentrationType = (analysismeterdata.Gdjz == "0" ? "3" : "1");
                                        cdata.HCNominalValue = analysismeterdata.Hcbz.ToString("0");
                                        cdata.HCRealValue = analysismeterdata.Hcclz.ToString("0");
                                        cdata.HCDeviation = analysismeterdata.hcpc;
                                        
                                        cdata.CONominalValue = analysismeterdata.Cobz.ToString("0.00");
                                        cdata.CORealValue = analysismeterdata.Coclz.ToString("0.00");
                                        cdata.CODeviation = analysismeterdata.copc;
                                        
                                        cdata.CO2NominalValue = analysismeterdata.Co2bz.ToString("0.00");
                                        cdata.CO2RealValue = analysismeterdata.Co2clz.ToString("0.00");
                                        cdata.CO2Deviation = analysismeterdata.co2pc;
                                        
                                        cdata.NONominalValue = analysismeterdata.Nobz.ToString("0");
                                        cdata.NORealValue = analysismeterdata.Noclz.ToString("0");
                                        cdata.NODeviation = analysismeterdata.nopc;

                                        cdata.HCResult = (double.Parse(cdata.HCDeviation) > 5) ? "2" : "1";
                                        cdata.COResult = (double.Parse(cdata.CODeviation) > 5) ? "2" : "1";
                                        cdata.CO2Result = (double.Parse(cdata.CO2Deviation) > 5) ? "2" : "1";
                                        cdata.NOResult = (double.Parse(cdata.NODeviation) > 8) ? "2" : "1";

                                        cdata.O2NominalValue = "0";
                                        cdata.O2RealValue = "0";
                                        cdata.O2Deviation = "0";
                                        cdata.O2Result = "1";
                                        cdata.O2ErrorLimit = "5";
                                        cdata.PEF = analysismeterdata.Pef;
                                        if (cdata.HCResult == "1" && cdata.COResult == "1" && cdata.CO2Result == "1" && cdata.NOResult == "1")
                                            pdata.Judge = "1";
                                        else
                                            pdata.Judge = "2";
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_SELFCHECK_RESULT_DATA(mainPanel.lineid, pdata, cdata, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪检查数据自检信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪检查数据自检信息]:成功\r\n");
                                        }
                                        cdata2.type = "2";
                                        cdata2.CheckBeginTime = DateTime.Parse(analysismeterdata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                       
                                        cdata2.HCErrorLimit = "5";
                                        cdata2.COErrorLimit = "5";
                                        cdata2.CO2ErrorLimit = "5";
                                        cdata2.NOErrorLimit = "8";
                                        cdata2.ConcentrationType = (analysismeterdata.Gdjz == "0" ? "3" : "1");
                                        cdata2.HCNominalValue = analysismeterdata.Hcbz.ToString("0");
                                        cdata2.HCRealValue = analysismeterdata.Hcclz.ToString("0");
                                        cdata2.HCDeviation = analysismeterdata.hcpc;

                                        cdata2.CONominalValue = analysismeterdata.Cobz.ToString("0.00");
                                        cdata2.CORealValue = analysismeterdata.Coclz.ToString("0.00");
                                        cdata2.CODeviation = analysismeterdata.copc;

                                        cdata2.CO2NominalValue = analysismeterdata.Co2bz.ToString("0.00");
                                        cdata2.CO2RealValue = analysismeterdata.Co2clz.ToString("0.00");
                                        cdata2.CO2Deviation = analysismeterdata.co2pc;

                                        cdata2.NONominalValue = analysismeterdata.Nobz.ToString("0");
                                        cdata2.NORealValue = analysismeterdata.Noclz.ToString("0");
                                        cdata2.NODeviation = analysismeterdata.nopc;

                                        cdata2.HCResult = (double.Parse(cdata2.HCDeviation) > 5) ? "2" : "1";
                                        cdata2.COResult = (double.Parse(cdata2.CODeviation) > 5) ? "2" : "1";
                                        cdata2.CO2Result = (double.Parse(cdata2.CO2Deviation) > 5) ? "2" : "1";
                                        cdata2.NOResult = (double.Parse(cdata2.NODeviation) > 8) ? "2" : "1";

                                        cdata2.O2NominalValue = "0";
                                        cdata2.O2RealValue = "0";
                                        cdata2.O2Deviation = "0";
                                        cdata2.O2Result = "1";
                                        cdata2.O2ErrorLimit = "5";
                                        cdata2.PEF = analysismeterdata.Pef;
                                        if (cdata2.HCResult == "1" && cdata2.COResult == "1" && cdata2.CO2Result == "1" && cdata2.NOResult == "1")
                                            pdata.Judge = "1";
                                        else
                                            pdata.Judge = "2";
                                        if (!mainPanel.ahinterface.Send_SELFCHECK_RESULT_DATA(mainPanel.lineid, pdata, cdata2, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪低量程检查自检信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传尾气分析仪低量程检查自检信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽结束
                                        selfcheckdata checkdata = new selfcheckdata();
                                        checkdata.TEMP = "0";
                                        checkdata.HUMI = "0";
                                        checkdata.AIRP = "0";
                                        string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                                        if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                                        {
                                            checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                                        }
                                        else
                                        {
                                            checkdata.TEMP = "0";
                                            checkdata.HUMI = "0";
                                            checkdata.AIRP = "0";
                                        }
                                        checkdata.AllJudge = analysismeterdata.Bdjg == "合格" ? "1" : "2";
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.EndSelfTest(mainPanel.lineid, checkdata, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("发送自检结束指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                                            //return;
                                            //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                                        }
                                        else
                                            ini.INIIO.saveLogInf("发送自检结束指令成功");
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "流量计检测":
                                #region 流量计检测 
                                flowmeterdata = flowmetercontrol.readFlowMeterData(newPath);
                                demarcatecontrol.saveFlowmeterDataByIni(flowmeterdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (flowmeterdata.Bdjg == "-1")
                                {
                                    Msg(label1, panel4, "流量计检测结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.linesbbd.Lljenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "流量计检查未通过");
                                }
                                else if (flowmeterdata.Bdjg == "-2")
                                {
                                    Msg(label1, panel4, "流量计未完成标定退出");
                                }
                                else
                                {
                                    Msg(label1, panel4, "流量计检测结果合格");
                                    //mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "LLJBD", "0");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "LLJDATE", DateTime.Now.ToString());
                                    if (mainPanel.linemodel.LOCKREASON == "流量计检查未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");

                                }
                                if (flowmeterdata.Bdjg != "-2")
                                {
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        { }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.LLJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_LLJJC);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (flowmeterdata.Bdjg == "不合格" || flowmeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA2", flowmeterdata.O2glcbz.ToString("0.0"));
                                            hstb.Add("DATA3", flowmeterdata.O2glcclz.ToString("0.0"));
                                            hstb.Add("DATA4", flowmeterdata.O2glcwc.ToString("0.0"));
                                            hstb.Add("DATA5", flowmeterdata.O2dlcbz.ToString("0.0"));
                                            hstb.Add("DATA6", flowmeterdata.O2dlcclz.ToString("0.0"));
                                            hstb.Add("DATA7", flowmeterdata.O2dlcwc.ToString("0.0"));
                                            hstb.Add("DATA8", (flowmeterdata.Bdjg == "不合格" || flowmeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存流量计标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存流量计标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.LLJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_LLJJC);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", (flowmeterdata.Bdjg == "不合格" || flowmeterdata.Bdjg == "0") ? "0" : "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                            hstb.Add("DATA2", flowmeterdata.O2glcbz.ToString("0.0"));
                                            hstb.Add("DATA3", flowmeterdata.O2glcclz.ToString("0.0"));
                                            hstb.Add("DATA4", flowmeterdata.O2glcwc.ToString("0.0"));
                                            hstb.Add("DATA5", flowmeterdata.O2dlcbz.ToString("0.0"));
                                            hstb.Add("DATA6", flowmeterdata.O2dlcclz.ToString("0.0"));
                                            hstb.Add("DATA7", flowmeterdata.O2dlcwc.ToString("0.0"));
                                            hstb.Add("DATA8", (flowmeterdata.Bdjg == "不合格" || flowmeterdata.Bdjg == "0") ? "0" : "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存流量计标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存流量计标定信息语句失败");
                                            }
                                        }
                                    }

                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                                    {
                                        JxWebClient.jxLljCheckdata jxdata = new JxWebClient.jxLljCheckdata();
                                        jxdata.testInstitutionId = mainPanel.stationid;
                                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                                        jxdata.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        jxdata.resultFlag = flowmeterdata.Bdjg == "0" ? "1" : "0";
                                        jxdata.o2HighGivenValue = flowmeterdata.O2glcbz.ToString("0.0");
                                        jxdata.o2HighMeasuredValue = flowmeterdata.O2glcclz.ToString("0.0");
                                        jxdata.o2HighErrorValue = flowmeterdata.O2glcwc.ToString("0.0");
                                        jxdata.o2LowGivenValue = flowmeterdata.O2dlcbz.ToString("0.0");
                                        jxdata.o2LowMeasuredValue = flowmeterdata.O2dlcclz.ToString("0.0");
                                        jxdata.o2LowErrorValue = flowmeterdata.O2dlcwc.ToString("0.0");
                                        string code, msg;
                                        if (!mainPanel.jxinterface.sendSelfCheckData(7, jxdata, out code, out msg))
                                        {
                                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                                        }
                                    }
                                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE)
                                    {
                                        #region neusoft
                                        if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                                        {
                                            NeusoftUtil.FlowMeterTest flowmetercheckdata = new NeusoftUtil.FlowMeterTest();
                                            flowmetercheckdata.OutlookID = mainPanel.equipmodel.LLJBH;
                                            flowmetercheckdata.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                            flowmetercheckdata.Result = ((flowmeterdata.Bdjg == "不合格" || flowmeterdata.Bdjg == "0") ? "0" : "1");
                                            flowmetercheckdata.STD_HRangeO2 = flowmeterdata.O2glcbz.ToString("0.0");
                                            flowmetercheckdata.MEA_HRangeO2 = flowmeterdata.O2glcclz.ToString("0.0");
                                            flowmetercheckdata.ERR_HRangeO2 = flowmeterdata.O2glcwc.ToString("0.0");
                                            flowmetercheckdata.STD_LRangeO2 = flowmeterdata.O2dlcbz.ToString("0.0");
                                            flowmetercheckdata.MEA_LRangeO2 = flowmeterdata.O2dlcclz.ToString("0.0");
                                            flowmetercheckdata.ERR_LRangeO2 = flowmeterdata.O2dlcwc.ToString("0.0");
                                            string result, inf;
                                            DataTable dtack;
                                            mainPanel.sysocket.UploadFlowMeterTest(flowmetercheckdata, out result, out inf, out dtack);
                                           
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "烟度计检查":
                                #region
                                smokedata = smokeini.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveSmokeDataByIni(smokedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (smokedata.Bdjg == "不合格")
                                {
                                    Msg(label1, panel4, "烟度计检查结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.linesbbd.Ydjenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "烟度计检查未通过");
                                }
                                else if(smokedata.Bdjg=="合格")
                                {
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "YDJDATE", DateTime.Now.ToString());
                                    Msg(label1, panel4, "烟度计检查结果合格");
                                    if (mainPanel.linemodel.LOCKREASON == "烟度计检查未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                }
                                else
                                {
                                    Msg(label1, panel4, "烟度计检查未完成退出");
                                }
                                if (mainPanel.isNetUsed)
                                {
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                    {
                                        #region 大理联网
                                        string code, msg;
                                        string reportID;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                        ht.Add("检测站编号", mainPanel.stationid);
                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                        ht.Add("设备类别", "5");
                                        ht.Add("设备名称", "烟度计标定");
                                        ht.Add("设备型号", mainPanel.equipmodel.YDJXH);
                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                        ht2.Add("不透光设定值", smokedata.Kbz.ToString("0.0"));
                                        ht2.Add("不透光实测值", smokedata.Kscz.ToString("0.0"));
                                        ht2.Add("不透光偏差", smokedata.Krelwc.ToString("0.0"));
                                        ht2.Add("光吸收数设定值", smokedata.Kbz.ToString("0.0"));
                                        ht2.Add("光吸收数实测值", smokedata.Kscz.ToString("0.0"));
                                        ht2.Add("光吸收数偏差", smokedata.Krelwc.ToString("0.0"));
                                        if (!mainPanel.daliinterface.sendYdjBdData(ht, ht2, out code, out msg))
                                        {
                                            MessageBox.Show("发送烟度计标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                            ini.INIIO.saveLogInf("发送烟度计标定信息失败,code" + code + ",msg:" + msg);
                                            return;
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.GUILINNETMODE)
                                    {
                                        #region 桂林                        
                                        string result;
                                        string errmsg = "";
                                        DataTable dt = new DataTable();
                                        Hashtable ht2 = new Hashtable();
                                            ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                                            ht2.Add("stationcode", mainPanel.stationid);
                                            ht2.Add("scenecode", mainPanel.lineid);
                                            ht2.Add("adjusttimestart", DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("adjusttimeend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            ht2.Add("el", smokedata.Kbz.ToString("0.0"));
                                            ht2.Add("er", smokedata.Kscz.ToString("0.0"));
                                            ht2.Add("ed", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                            ht2.Add("remark", "");
                                            if (!mainPanel.gxinterface.uploadDemarcateData(5, ht2, out result, out errmsg))
                                            {
                                                ini.INIIO.saveLogInf("上传柴油线标定信息数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                                                //return;
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("桂林联网信息：上传柴油线标定信息数据成功");
                                            }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.PNNETMODE)
                                    {
                                        #region 平南
                                        string errmsg = "";
                                        Hashtable ht = new Hashtable();
                                        ht.Add("EL", smokedata.Kbz.ToString("0.0"));
                                        ht.Add("ER", smokedata.Kscz.ToString("0.0"));
                                        ht.Add("ED", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                        ht.Add("AdjustTimeStart", DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("AdjustTimeEnd", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ht.Add("Remark", "");

                                        if (mainPanel.pninterface.UploadBdZjData(2, ht, out errmsg))
                                            ini.INIIO.saveLogInf("桂林联网信息：上传柴油线标定信息数据成功");
                                        else
                                            ini.INIIO.saveLogInf("上传柴油线标定信息数据失败\r\n" + "错误信息：" + errmsg);
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "3");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "3");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "3");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("btgsdz", smokedata.Kbz.ToString("0.0"));
                                        htdata.Add("btgscz", smokedata.Kscz.ToString("0.0"));
                                        htdata.Add("btgpc", smokedata.Krelwc.ToString("0.0"));
                                        htdata.Add("gxsxssdz", smokedata.Kbz.ToString("0.0"));
                                        htdata.Add("gxsxsscz", smokedata.Kscz.ToString("0.0"));
                                        htdata.Add("gxsxspc", smokedata.Krelwc.ToString("0.0"));
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        List<AhWebClient.ah_ydj_caldata> listc = new List<AhWebClient.ah_ydj_caldata>();
                                        AhWebClient.ah_ydj_caldata cdata = new AhWebClient.ah_ydj_caldata();
                                        pdata.Type = "5";

                                        pdata.BeginTime = DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        jdata.type = "1";
                                        jdata.CalibrateCount = "1";

                                        cdata.NominalValue = smokedata.Kbz.ToString("0.00");
                                        cdata.RealValue = smokedata.Kscz.ToString("0.00");
                                        cdata.Deviation = smokedata.Krelwc.ToString("0.00");
                                        cdata.ErrorLimit = "2";
                                        cdata.Result = smokedata.Bdjg == "不合格" ? "2" : "1";
                                        listc.Add(cdata);

                                        pdata.Judge = (smokedata.Bdjg == "不合格") ? "2" : "1";
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传烟度计标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传烟度计标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                    /*
                                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE && mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                                    {
                                        if (smokedata.Bdjg == "合格" || smokedata.Bdjg == "不合格")
                                        {
                                            newCsvPath = "C://jcdatatxt/" + "SmokemeterCal.csv";
                                            if (File.Exists(newCsvPath))
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    isCsvAlive = "过程数据上传成功";

                                                    if (mainPanel.isNetUsed)
                                                    {

                                                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                        string ackresult, errormessage;
                                                        mainPanel.neusoftsocket.UploadSmokemeterCalRequest(dataseconds, out ackresult, out errormessage);

                                                    }
                                                    Msg(label1, panel4, "烟度计标定成功," + isCsvAlive);
                                                }
                                            }
                                            else
                                            {
                                                Msg(label1, panel4, "烟度计标定失败,未找到过程数据");
                                            }
                                        }
                                    }*/
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (smokedata.Bdjg == "合格" || smokedata.Bdjg == "不合格")
                                        {
                                            newCsvPath = "C://jcdatatxt/" + "SmokemeterCal.csv";
                                            if (File.Exists(newCsvPath))
                                            {
                                                string isCsvAlive = "";
                                                DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                                if (dataseconds != null)
                                                {
                                                    if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                                    {
                                                        Hashtable hstb = new Hashtable();
                                                        hstb.Add("SBBH", mainPanel.equipmodel.YDJBH);
                                                        hstb.Add("BDR", mainPanel.nowUser.userName);
                                                        hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.烟度校准]);
                                                        hstb.Add("BDSJ", DateTime.Now);
                                                        hstb.Add("BDJG", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                                        hstb.Add("JCZBH", mainPanel.stationid);
                                                        hstb.Add("JCGWH", mainPanel.lineid);
                                                        hstb.Add("ZT", "0");
                                                        hstb.Add("DATA1", smokedata.Kbz.ToString("0.00"));
                                                        hstb.Add("DATA2", smokedata.Kscz.ToString("0.00"));
                                                        hstb.Add("DATA3", smokedata.Krelwc.ToString("0.00"));
                                                        hstb.Add("DATA4", "");
                                                        hstb.Add("DATA5", "");
                                                        hstb.Add("DATA6", "");
                                                        hstb.Add("DATA7", "");
                                                        hstb.Add("DATA8", "");
                                                        hstb.Add("DATA9", "");
                                                        if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句成功");
                                                        }
                                                        else
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句失败");
                                                        }
                                                    }
                                                    else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                                    {
                                                        Hashtable hstb = new Hashtable();
                                                        hstb.Add("SBBH", mainPanel.equipmodel.YDJBH);
                                                        hstb.Add("BDR", mainPanel.nowUser.userName);
                                                        hstb.Add("BDLX", BDLX_YDJBD);
                                                        hstb.Add("BDSJ", DateTime.Now);
                                                        hstb.Add("BDJG", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                                        hstb.Add("JCZBH", mainPanel.stationid);
                                                        hstb.Add("JCGWH", mainPanel.lineid);
                                                        hstb.Add("ZT", "0");
                                                        hstb.Add("DATA1", smokedata.Kbz.ToString("0.00"));
                                                        hstb.Add("DATA2", smokedata.Kscz.ToString("0.00"));
                                                        hstb.Add("DATA3", smokedata.Krelwc.ToString("0.00"));
                                                        hstb.Add("DATA4", "");
                                                        hstb.Add("DATA5", "");
                                                        hstb.Add("DATA6", "");
                                                        hstb.Add("DATA7", "");
                                                        hstb.Add("DATA8", "");
                                                        hstb.Add("DATA9", "");
                                                        if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句成功");
                                                        }
                                                        else
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句失败");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Hashtable hstb = new Hashtable();
                                                        hstb.Add("SBBH", mainPanel.equipmodel.YDJBH);
                                                        hstb.Add("BDR", mainPanel.nowUser.userName);
                                                        hstb.Add("BDLX", BDLX_YDJBD);
                                                        hstb.Add("BDSJ", DateTime.Now);
                                                        hstb.Add("BDJG", (smokedata.Bdjg == "不合格" || smokedata.Bdjg == "0") ? "0" : "1");
                                                        hstb.Add("JCZBH", mainPanel.stationid);
                                                        hstb.Add("JCGWH", mainPanel.lineid);
                                                        hstb.Add("ZT", "0");
                                                        hstb.Add("DATA1", smokedata.Kbz.ToString("0.00"));
                                                        hstb.Add("DATA2", smokedata.Kscz.ToString("0.00"));
                                                        hstb.Add("DATA3", smokedata.Krelwc.ToString("0.00"));
                                                        hstb.Add("DATA4", "");
                                                        hstb.Add("DATA5", "");
                                                        hstb.Add("DATA6", "");
                                                        hstb.Add("DATA7", "");
                                                        hstb.Add("DATA8", "");
                                                        hstb.Add("DATA9", "");
                                                        if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句成功");
                                                        }
                                                        else
                                                        {
                                                            ini.INIIO.saveLogInf("保存烟度计标定信息语句失败");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        Msg(label1, panel4, "烟度计标定完成");
                                    }
                                }
                                else
                                {
                                    Msg(label1, panel4, "烟度计标定完成");
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "气象站校准":
                                #region
                                tempdata = tempini.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveTemperatureDataByIni(tempdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (tempdata.Bdjg == "不合格")
                                {
                                    Msg(label1, panel4, "气象站检查结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.linesbbd.Hjcsenable)
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "气象站检查未通过");
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", "0" );
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("sjwd", tempdata.Wdbz.ToString("0.0"));
                                        htdata.Add("scwd", tempdata.Wdscz.ToString("0.0"));
                                        htdata.Add("wdpc", tempdata.Wdwc.ToString("0.0"));
                                        htdata.Add("sjsd", tempdata.Sdbz.ToString("0.0"));
                                        htdata.Add("scsd", tempdata.Sdscz.ToString("0.0"));
                                        htdata.Add("sdpc", tempdata.Sdwc.ToString("0.0"));
                                        htdata.Add("sjdqy", tempdata.Dqybz.ToString("0.0"));
                                        htdata.Add("scdqy", tempdata.Dqyscz.ToString("0.0"));
                                        htdata.Add("dqypc", tempdata.Dqywc.ToString("0.0"));
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                }
                                else if (tempdata.Bdjg == "-2")
                                {
                                    Msg(label1, panel4, "气象站检查未完成退出");
                                }
                                else
                                {
                                    Msg(label1, panel4, "气象站检查结果合格");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "HJCSDATE", DateTime.Now.ToString());

                                    if (mainPanel.linemodel.LOCKREASON == "气象站检查未通过")
                                        mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");

                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                    {
                                        #region hunan
                                        string code, msg;
                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                        }
                                        ht.Clear();
                                        ht.Add("jzxmid", "5");
                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        ht.Add("jzcs", "1");
                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                        ht.Add("jzzt", "1");
                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                        htdata.Add("sjwd", tempdata.Wdbz.ToString("0.0"));
                                        htdata.Add("scwd", tempdata.Wdscz.ToString("0.0"));
                                        htdata.Add("wdpc", tempdata.Wdwc.ToString("0.0"));
                                        htdata.Add("sjsd", tempdata.Sdbz.ToString("0.0"));
                                        htdata.Add("scsd", tempdata.Sdscz.ToString("0.0"));
                                        htdata.Add("sdpc", tempdata.Sdwc.ToString("0.0"));
                                        htdata.Add("sjdqy", tempdata.Dqybz.ToString("0.0"));
                                        htdata.Add("scdqy", tempdata.Dqyscz.ToString("0.0"));
                                        htdata.Add("dqypc", tempdata.Dqywc.ToString("0.0"));
                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                        }
                                        #endregion
                                    }
                                }
                                if(tempdata.Bdjg=="合格"||tempdata.Bdjg=="不合格")
                                {

                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        List<AhWebClient.ah_dzhj_caldata> listc = new List<AhWebClient.ah_dzhj_caldata>();
                                        AhWebClient.ah_dzhj_caldata cdata = new AhWebClient.ah_dzhj_caldata();
                                        pdata.Type = "3";

                                        pdata.BeginTime = DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        jdata.type = "1";
                                        jdata.CalibrateCount = "1";

                                        cdata.TemperatureNominalValue = tempdata.Wdbz.ToString("0.0");
                                        cdata.TemperatureRealValue = tempdata.Wdscz.ToString("0.0");
                                        cdata.TemperatureResult = tempdata.Bzsm.Split(';')[0] == "×" ? "2" : "1";

                                        cdata.HumidityNominalValue = tempdata.Sdbz.ToString("0.0");
                                        cdata.HumidityRealValue = tempdata.Sdscz.ToString("0.0");
                                        cdata.HumidityResult = tempdata.Bzsm.Split(';')[1] == "×" ? "2" : "1";

                                        cdata.BaroNominalValue = tempdata.Dqybz.ToString("0.0");
                                        cdata.BaroRealValue = tempdata.Dqyscz.ToString("0.0");
                                        cdata.BaroResult = tempdata.Bzsm.Split(';')[2] == "×" ? "2" : "1";
                                        
                                        listc.Add(cdata);

                                        pdata.Judge = (tempdata.Bdjg=="不合格")?"2":"1";
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传气象站标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传气象站标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                //writeExcel.writeSelfCheckData(tempdata);
                                return;
                                #endregion
                                break;
                            case "变载荷滑行测试":
                                #region
                                bzglidedata = bzglidecontrol.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveBzGlideDataByIni(bzglidedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (bzglidedata.Bdjg == "-1")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "变载荷滑行测试结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                }
                                else if (bzglidedata.Bdjg == "-2")
                                {
                                    Msg(label1, panel4, "变载荷滑行测试未完成退出");
                                }
                                else
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "变载荷滑行测试结果合格");
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "响应时间测试":
                                #region
                                xysjdata = xysjcontrol.readAnalysisMeterData(newPath);
                                demarcatecontrol.saveAnswerTimeByIni(xysjdata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (xysjdata.Bdjg == "不合格")
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "响应时间测试结果不合格，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        { }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_XYSJBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "0");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", xysjdata.XyTime);
                                            hstb.Add("DATA2", xysjdata.WdTime);
                                            hstb.Add("DATA3", xysjdata.StartForce);
                                            hstb.Add("DATA4", xysjdata.EndForce);
                                            hstb.Add("DATA5", xysjdata.Sd);
                                            hstb.Add("DATA6", "0");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_XYSJBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "0");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", xysjdata.XyTime);
                                            hstb.Add("DATA2", xysjdata.WdTime);
                                            hstb.Add("DATA3", xysjdata.StartForce);
                                            hstb.Add("DATA4", xysjdata.EndForce);
                                            hstb.Add("DATA5", xysjdata.Sd);
                                            hstb.Add("DATA6", "0");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                else if (xysjdata.Bdjg == "-2")
                                {
                                    Msg(label1, panel4, "响应时间测试未完成退出");
                                }
                                else
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "响应时间测试结果合格");
                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                    {
                                        #region general
                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                        {
                                        }
                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_XYSJBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", xysjdata.XyTime);
                                            hstb.Add("DATA2", xysjdata.WdTime);
                                            hstb.Add("DATA3", xysjdata.StartForce);
                                            hstb.Add("DATA4", xysjdata.EndForce);
                                            hstb.Add("DATA5", xysjdata.Sd);
                                            hstb.Add("DATA6", "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句失败");
                                            }
                                        }
                                        else
                                        {
                                            Hashtable hstb = new Hashtable();
                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                            hstb.Add("BDLX", BDLX_XYSJBD);
                                            hstb.Add("BDSJ", DateTime.Now);
                                            hstb.Add("BDJG", "1");
                                            hstb.Add("JCZBH", mainPanel.stationid);
                                            hstb.Add("JCGWH", mainPanel.lineid);
                                            hstb.Add("ZT", "0");
                                            hstb.Add("DATA1", xysjdata.XyTime);
                                            hstb.Add("DATA2", xysjdata.WdTime);
                                            hstb.Add("DATA3", xysjdata.StartForce);
                                            hstb.Add("DATA4", xysjdata.EndForce);
                                            hstb.Add("DATA5", xysjdata.Sd);
                                            hstb.Add("DATA6", "1");
                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句成功");
                                            }
                                            else
                                            {
                                                ini.INIIO.saveLogInf("保存响应时间标定信息语句失败");
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                if(xysjdata.Bdjg=="合格"||xysjdata.Bdjg=="不合格")
                                {

                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                    {
                                        #region 安徽联网
                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                        AhWebClient.ah_xysj_caldata cdata1 = new AhWebClient.ah_xysj_caldata();
                                        pdata.Type = "1";
                                        pdata.BeginTime = DateTime.Parse(glidedata.Starttime).ToString("yyyy-MM-dd HH:mm:ss");
                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        jdata.type = "7";
                                        jdata.CalibrateCount = "1";
                                        List<AhWebClient.ah_xysj_caldata> listc = new List<AhWebClient.ah_xysj_caldata>();
                                        cdata1.StartSpeed = "64.4";
                                        cdata1.MaxSpeed = xysjdata.Sd;
                                        cdata1.MinSpeed = "40";
                                        cdata1.ResponseTime = xysjdata.XyTime;
                                        cdata1.StabilizationTime = xysjdata.WdTime;
                                        pdata.Judge = (double.Parse(xysjdata.XyTime) > 300 || double.Parse(xysjdata.WdTime) > 600) ? "2" : "1";
                                        listc.Add(cdata1);
                                        int ahresult = 0;
                                        string ahErrMsg = "";
                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                        {
                                            ini.INIIO.saveLogInf("[上传响应时间标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("[上传响应时间标定信息]:成功\r\n");
                                        }
                                        #endregion
                                    }
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "预热":
                                #region
                                yuredata = yurecontrol.readYureData(newPath);
                                //demarcatecontrol.saveGlideDataByIni(glidedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                                if (yuredata == "0")
                                {
                                    Msg(label1, panel4, "预热未完成，请检查后再进行");
                                    worklogdata.Result = "未通过";
                                }
                                else
                                {
                                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                    Msg(label1, panel4, "预热完成");
                                    mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "YRDATE", DateTime.Now.ToString());

                                    
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "扭力标定":
                                #region 
                                if (true)
                                {
                                    if(true)
                                    {
                                        newCsvPath = "C://jcdatatxt/" + "TorqueCal.csv";
                                        if (File.Exists(newCsvPath))
                                        {
                                            
                                            string isCsvAlive = "";
                                            DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                            if (dataseconds != null)
                                            {
                                                isCsvAlive = "过程数据上传成功";
                                                carinfor.yljbddata yljdata = new carinfor.yljbddata();
                                                if (dataseconds.Rows.Count>1)
                                                {
                                                    yljdata.Bdds = (dataseconds.Rows.Count - 1).ToString();
                                                    yljdata.Bdjg = "合格";
                                                    yljdata.Bzsm = "";
                                                    yljdata.Bdrq = DateTime.Now;
                                                    for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                    {
                                                        try
                                                        {
                                                            DataRow dr = dataseconds.Rows[i];
                                                            double wc = 0;
                                                            double relwc = 0;

                                                            wc = Math.Abs(double.Parse(dr["标定点(N)"].ToString()) - double.Parse(dr["实测重量(N)"].ToString()));
                                                            relwc = Math.Round(wc * 100.0 / double.Parse(dr["标定点(N)"].ToString()), 1);
                                                            if (relwc > 1) yljdata.Bdjg = "不合格";
                                                            if (i == 1)
                                                            {
                                                                yljdata.Bz1 = dr["标定点(N)"].ToString();
                                                                yljdata.Clz1 = dr["实测重量(N)"].ToString();
                                                                yljdata.Wc1 = relwc.ToString("0.0");
                                                            }
                                                            else if (i == 2)
                                                            {
                                                                yljdata.Bz2 = dr["标定点(N)"].ToString();
                                                                yljdata.Clz2 = dr["实测重量(N)"].ToString();
                                                                yljdata.Wc2 = relwc.ToString("0.0");
                                                            }
                                                            else if (i == 3)
                                                            {
                                                                yljdata.Bz3 = dr["标定点(N)"].ToString();
                                                                yljdata.Clz3 = dr["实测重量(N)"].ToString();
                                                                yljdata.Wc3 = relwc.ToString("0.0");
                                                            }
                                                            else if (i == 4)
                                                            {
                                                                yljdata.Bz4 = dr["标定点(N)"].ToString();
                                                                yljdata.Clz4 = dr["实测重量(N)"].ToString();
                                                                yljdata.Wc4 = relwc.ToString("0.0");
                                                            }
                                                            else if (i == 5)
                                                            {
                                                                yljdata.Bz5 = dr["标定点(N)"].ToString();
                                                                yljdata.Clz5 = dr["实测重量(N)"].ToString();
                                                                yljdata.Wc5 = relwc.ToString("0.0");
                                                            }
                                                        }
                                                        catch
                                                        { }
                                                        
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                                    {
                                                        #region general
                                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.扭力校准]);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", "0.5");//备注说明注明系数
                                                            hstb.Add("DATA2", yljdata.Bz1);
                                                            hstb.Add("DATA3", yljdata.Clz1);
                                                            hstb.Add("DATA4", yljdata.Wc1);
                                                            hstb.Add("DATA5", yljdata.Bz2);
                                                            hstb.Add("DATA6", yljdata.Clz2);
                                                            hstb.Add("DATA7", yljdata.Wc2);
                                                            hstb.Add("DATA8", yljdata.Bz3);
                                                            hstb.Add("DATA9", yljdata.Clz3);
                                                            hstb.Add("DATA10", yljdata.Wc3);
                                                            hstb.Add("DATA11", yljdata.Bz4);
                                                            hstb.Add("DATA12", yljdata.Clz4);
                                                            hstb.Add("DATA13", yljdata.Wc4);
                                                            hstb.Add("DATA14", yljdata.Bz5);
                                                            hstb.Add("DATA15", yljdata.Clz5);
                                                            hstb.Add("DATA16", yljdata.Wc5);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句失败");
                                                            }
                                                        }
                                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", BDLX_NLBD);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", yljdata.Bz1);
                                                            hstb.Add("DATA2", yljdata.Clz1);
                                                            hstb.Add("DATA3", yljdata.Wc1);
                                                            hstb.Add("DATA4", yljdata.Bz2);
                                                            hstb.Add("DATA5", yljdata.Clz2);
                                                            hstb.Add("DATA6", yljdata.Wc2);
                                                            hstb.Add("DATA7", yljdata.Bz3);
                                                            hstb.Add("DATA8", yljdata.Clz3);
                                                            hstb.Add("DATA9", yljdata.Wc3);
                                                            hstb.Add("DATA10", yljdata.Bz4);
                                                            hstb.Add("DATA11", yljdata.Clz4);
                                                            hstb.Add("DATA12", yljdata.Wc4);
                                                            hstb.Add("DATA13", yljdata.Bz5);
                                                            hstb.Add("DATA14", yljdata.Clz5);
                                                            hstb.Add("DATA15", yljdata.Wc5);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句失败");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", BDLX_NLBD);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", yljdata.Bz1);
                                                            hstb.Add("DATA2", yljdata.Clz1);
                                                            hstb.Add("DATA3", yljdata.Wc1);
                                                            hstb.Add("DATA4", yljdata.Bz2);
                                                            hstb.Add("DATA5", yljdata.Clz2);
                                                            hstb.Add("DATA6", yljdata.Wc2);
                                                            hstb.Add("DATA7", yljdata.Bz3);
                                                            hstb.Add("DATA8", yljdata.Clz3);
                                                            hstb.Add("DATA9", yljdata.Wc3);
                                                            hstb.Add("DATA10", yljdata.Bz4);
                                                            hstb.Add("DATA11", yljdata.Clz4);
                                                            hstb.Add("DATA12", yljdata.Wc4);
                                                            hstb.Add("DATA13", yljdata.Bz5);
                                                            hstb.Add("DATA14", yljdata.Clz5);
                                                            hstb.Add("DATA15", yljdata.Wc5);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存扭力标定信息语句失败");
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                                    {
                                                        #region hunan
                                                        string code, msg;
                                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                                        ht.Add("jzxmid", "7");
                                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        ht.Clear();
                                                        ht.Add("jzxmid", "7");
                                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        ht.Clear();
                                                        ht.Add("jzxmid", "7");
                                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                                        ht.Add("jzzt", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0")?"0":"1");
                                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                                        htdata.Add("nlbddsl", (dataseconds.Rows.Count-1).ToString("0.0"));
                                                        string sdbdsj = "";
                                                        for(int i=1;i<dataseconds.Rows.Count;i++)
                                                        {
                                                            sdbdsj += "#" + dataseconds.Rows[i]["标定点(N)"].ToString() + "#" + dataseconds.Rows[i]["实测重量(N)"].ToString() + "#" + Math.Abs(double.Parse(dataseconds.Rows[i]["标定点(N)"].ToString()) - double.Parse(dataseconds.Rows[i]["实测重量(N)"].ToString()));
                                                        }
                                                        htdata.Add("nlbdsj", sdbdsj);

                                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                                    {
                                                        #region 大理联网
                                                        string code, msg;
                                                        string reportID;
                                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                                        DataTable dt = new DataTable();
                                                        ht.Add("检测站编号", mainPanel.stationid);
                                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                                        ht.Add("设备类别", "1");
                                                        ht.Add("设备名称", "扭力标定");
                                                        ht.Add("设备型号", mainPanel.equipmodel.CGJXH);
                                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                        
                                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                                        dt.Columns.Add("设定值");
                                                        dt.Columns.Add("实测值");
                                                        dt.Columns.Add("偏差");
                                                        DataRow dr = null;
                                                        for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                        {
                                                            dr = dt.NewRow();
                                                            dr["设定值"] = dataseconds.Rows[i]["标定点(N)"].ToString();
                                                            dr["实测值"] = dataseconds.Rows[i]["实测重量(N)"].ToString();
                                                            dr["偏差"] = Math.Abs(double.Parse(dataseconds.Rows[i]["标定点(N)"].ToString()) - double.Parse(dataseconds.Rows[i]["实测重量(N)"].ToString()));
                                                            dt.Rows.Add(dr);
                                                        }
                                                        if (!mainPanel.daliinterface.sendForceBdData(ht, dt, out code, out msg))
                                                        {
                                                            MessageBox.Show("发送扭力标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                                            ini.INIIO.saveLogInf("发送扭力标定信息失败,code" + code + ",msg:" + msg);
                                                            return;
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.XBNETMODE)
                                                    {
                                                        #region xibang
                                                        string code, msg;
                                                        try
                                                        {
                                                            carinfo.XB_BD_PUBLIC_DATA pdata = new carinfo.XB_BD_PUBLIC_DATA();
                                                            pdata.DevID = mainPanel.equipmodel.CGJBH;
                                                            pdata.Items = "01";
                                                            pdata.BeginTime = bdrq.ToString("yyyy-MM-dd HH:mm:ss");
                                                            pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            pdata.WD = "0";
                                                            pdata.SD = "0";
                                                            pdata.DQY = "0";
                                                            pdata.Operator = mainPanel.nowUser.userName;
                                                            carinfo.XB_FORCE_BD_DATA data = new carinfo.XB_FORCE_BD_DATA();
                                                            data.ForceCheckValue = yljdata.Bz1;
                                                            data.ForceValue =yljdata.Clz1+","+ yljdata.Clz1 + "," + yljdata.Clz1;
                                                            data.ForceAverageValue = yljdata.Clz1;
                                                            data.ForceError = yljdata.Wc1;
                                                            data.AllowError = "1";
                                                            data.ForceEvl =(Math.Abs(double.Parse(yljdata.Wc1))>1)?"F":"T";
                                                            
                                                            if (!mainPanel.xbsocket.Send_BD_RESULT_DATA(pdata, data, out code, out msg))
                                                            {
                                                                ini.INIIO.saveLogInf("发送扭力标定命令失败,code" + code + ",msg:" + msg);
                                                            }
                                                        }
                                                        catch (Exception er)
                                                        {
                                                            ini.INIIO.saveLogInf("发送扭力标定命令异常:" + er.Message);
                                                        }
                                                        #endregion
                                                    }

                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                                    {
                                                        #region 安徽联网
                                                        AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                                        AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                                        pdata.Type = "1";
                                                        pdata.BeginTime = DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss");
                                                        pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                        pdata.Judge =  "1";
                                                        jdata.type = "4";
                                                        jdata.CalibrateCount = (dataseconds.Rows.Count - 1).ToString();
                                                        List<AhWebClient.ah_force_caldata> listc = new List<AhWebClient.ah_force_caldata>();
                                                        for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                        {
                                                            AhWebClient.ah_force_caldata cdata = new AhWebClient.ah_force_caldata();
                                                            DataRow dr = dataseconds.Rows[i];
                                                            double wc = 0;
                                                            double relwc = 0;
                                                            wc = Math.Abs(double.Parse(dr["标定点(N)"].ToString()) - double.Parse(dr["实测重量(N)"].ToString()));
                                                            relwc = Math.Round(wc * 100.0 / double.Parse(dr["标定点(N)"].ToString()), 1);
                                                            cdata.NominalValue = dr["标定点(N)"].ToString();
                                                            cdata.RealValue= dr["实测重量(N)"].ToString();
                                                            cdata.ErrorLimit ="1";
                                                            cdata.Deviation = relwc.ToString("0.0");
                                                            cdata.Result = (relwc > 1 ? "2" : "1");
                                                            if (cdata.Result == "2") pdata.Judge = "2";
                                                            listc.Add(cdata);
                                                        }
                                                        int ahresult = 0;
                                                        string ahErrMsg = "";
                                                        if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                                        {
                                                            ini.INIIO.saveLogInf("[上传扭力标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                                        }
                                                        else
                                                        {
                                                            ini.INIIO.saveLogInf("[上传扭力标定信息]:成功\r\n");
                                                        }
                                                        #endregion
                                                    }
                                                    demarcatecontrol.saveYljDataByIni(yljdata, mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                                                    if (yljdata.Bdjg == "合格")
                                                    {
                                                        
                                                        Msg(label1, panel4, "压力计校准结果合格");
                                                        mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "YLJDATE", DateTime.Now.ToString());
                                                        if (mainPanel.linemodel.LOCKREASON == "压力计校准未通过")
                                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                                    }
                                                    else
                                                    {
                                                        Msg(label1, panel4, "压力计校准未通过，请检查后再进行");
                                                        worklogdata.Result = "未通过";
                                                        if (mainPanel.linesbbd.Yljenable)
                                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "压力计校准未通过");
                                                    }
                                                    
                                                }
                                                
                                                if (mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.NEUSOFTNETMODE)
                                                {

                                                    if (mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                                                    {
                                                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                        string ackresult, errormessage;
                                                        mainPanel.neusoftsocket.UploadTorqueCalRequest(dataseconds, out ackresult, out errormessage);
                                                    }

                                                }
                                                //Msg(label1, panel4, "扭矩标定成功," + isCsvAlive);
                                            }
                                        }
                                        else
                                        {
                                            Msg(label1, panel4, "扭矩标定失败,未找到过程数据");
                                        }
                                    }
                                    else
                                    {
                                        Msg(label1, panel4, "扭力标定完成");
                                    }
                                }
                                else
                                {
                                    Msg(label1, panel4, "扭力标定完成");
                                }
                                File.Delete(newPath);
                                mainPanel.check_linezt();
                                worklogdata.Result = "";
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            case "速度标定":
                                //mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "SDDATE", DateTime.Now.ToString());
                                #region 
                                if (true)
                                {
                                    if (true)
                                    {
                                        newCsvPath = "C://jcdatatxt/" + "SpeedCal.csv";
                                        if (File.Exists(newCsvPath))
                                        {
                                            string isCsvAlive = "";
                                            DataTable dataseconds = csvreader.readCsv(newCsvPath);
                                            if (dataseconds != null)
                                            {
                                                if (dataseconds.Rows.Count > 1)
                                                {
                                                    carinfor.sdbddata yljdata = new carinfor.sdbddata();
                                                    yljdata.Bdds = (dataseconds.Rows.Count - 1).ToString();
                                                    yljdata.Bdjg = "合格";
                                                    yljdata.Bzsm = "";
                                                    yljdata.Bdrq = DateTime.Now;
                                                    for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                    {
                                                        try
                                                        {
                                                            DataRow dr = dataseconds.Rows[i];
                                                            double wc = 0;
                                                            double relwc = 0;

                                                            wc = Math.Abs(double.Parse(dr["标准速度(Km/h)"].ToString()) - double.Parse(dr["实测速度(Km/h)"].ToString()));
                                                            relwc = Math.Round(wc * 100.0 / double.Parse(dr["标准速度(Km/h)"].ToString()), 1);
                                                            if (relwc > 0.5&&wc>0.2) yljdata.Bdjg = "不合格";
                                                            if (i == 1)
                                                            {
                                                                yljdata.Bz1 = dr["标准速度(Km/h)"].ToString();
                                                                yljdata.Clz1 = dr["实测速度(Km/h)"].ToString();
                                                                yljdata.Wc1 = wc.ToString("0.0")+" "+relwc.ToString("0.0");
                                                            }
                                                            else if (i == 2)
                                                            {
                                                                yljdata.Bz2 = dr["标准速度(Km/h)"].ToString();
                                                                yljdata.Clz2 = dr["实测速度(Km/h)"].ToString();
                                                                yljdata.Wc2 = wc.ToString("0.0") + " "+relwc.ToString("0.0");
                                                            }
                                                            else if (i == 3)
                                                            {
                                                                yljdata.Bz3 = dr["标准速度(Km/h)"].ToString();
                                                                yljdata.Clz3 = dr["实测速度(Km/h)"].ToString();
                                                                yljdata.Wc3 = wc.ToString("0.0") + " " +relwc.ToString("0.0");
                                                            }
                                                        }
                                                        catch
                                                        { }
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                                                    {
                                                        #region general
                                                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", mainPanel.acJzNoLn[(int)mainPanel.acJzNameLn.车速校准]);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", "1");
                                                            hstb.Add("DATA2", yljdata.Bz1);
                                                            hstb.Add("DATA3", yljdata.Clz1);
                                                            hstb.Add("DATA4", yljdata.Wc1.Split(' ')[0]);
                                                            hstb.Add("DATA5", yljdata.Wc1.Split(' ')[1]);
                                                            hstb.Add("DATA6", yljdata.Bz2);
                                                            hstb.Add("DATA7", yljdata.Clz2);
                                                            hstb.Add("DATA8", yljdata.Wc2.Split(' ')[0]);
                                                            hstb.Add("DATA9", yljdata.Wc2.Split(' ')[1]);
                                                            hstb.Add("DATA10", yljdata.Bz3);
                                                            hstb.Add("DATA11", yljdata.Clz3);
                                                            hstb.Add("DATA12", yljdata.Wc3.Split(' ')[0]);
                                                            hstb.Add("DATA13", yljdata.Wc3.Split(' ')[1]);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句失败");
                                                            }
                                                        }
                                                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", BDLX_CSBD);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", yljdata.Bz1);
                                                            hstb.Add("DATA2", yljdata.Clz1);
                                                            hstb.Add("DATA3", yljdata.Wc1.Split(' ')[0]);
                                                            hstb.Add("DATA4", yljdata.Wc1.Split(' ')[1]);
                                                            hstb.Add("DATA5", yljdata.Bz2);
                                                            hstb.Add("DATA6", yljdata.Clz2);
                                                            hstb.Add("DATA7", yljdata.Wc2.Split(' ')[0]);
                                                            hstb.Add("DATA8", yljdata.Wc2.Split(' ')[1]);
                                                            hstb.Add("DATA9", yljdata.Bz3);
                                                            hstb.Add("DATA10", yljdata.Clz3);
                                                            hstb.Add("DATA11", yljdata.Wc3.Split(' ')[0]);
                                                            hstb.Add("DATA12", yljdata.Wc3.Split(' ')[1]);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句失败");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Hashtable hstb = new Hashtable();
                                                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                                            hstb.Add("BDR", mainPanel.nowUser.userName);
                                                            hstb.Add("BDLX", BDLX_CSBD);
                                                            hstb.Add("BDSJ", DateTime.Now);
                                                            hstb.Add("BDJG", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                            hstb.Add("JCZBH", mainPanel.stationid);
                                                            hstb.Add("JCGWH", mainPanel.lineid);
                                                            hstb.Add("ZT", "0");
                                                            hstb.Add("DATA1", yljdata.Bz1);
                                                            hstb.Add("DATA2", yljdata.Clz1);
                                                            hstb.Add("DATA3", yljdata.Wc1.Split(' ')[0]);
                                                            hstb.Add("DATA4", yljdata.Wc1.Split(' ')[1]);
                                                            hstb.Add("DATA5", yljdata.Bz2);
                                                            hstb.Add("DATA6", yljdata.Clz2);
                                                            hstb.Add("DATA7", yljdata.Wc2.Split(' ')[0]);
                                                            hstb.Add("DATA8", yljdata.Wc2.Split(' ')[1]);
                                                            hstb.Add("DATA9", yljdata.Bz3);
                                                            hstb.Add("DATA10", yljdata.Clz3);
                                                            hstb.Add("DATA11", yljdata.Wc3.Split(' ')[0]);
                                                            hstb.Add("DATA12", yljdata.Wc3.Split(' ')[1]);
                                                            if (mainPanel.conforsql.Insert("设备标定数据", hstb) > 0)
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句成功");
                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("保存速度标定信息语句失败");
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                                                    {
                                                        #region hunan
                                                        string code, msg;
                                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                                        ht.Add("jzxmid", "8");
                                                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                                        if (!mainPanel.hninterface.startDemarcate(ht, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送开始标定命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        ht.Clear();
                                                        ht.Add("jzxmid", "8");
                                                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));

                                                        if (!mainPanel.hninterface.finishDemarcate(ht, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送结束标定命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        ht.Clear();
                                                        ht.Add("jzxmid", "8");
                                                        ht.Add("jzsj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                                                        ht.Add("jzcs", "1");
                                                        ht.Add("jznx", DateTime.Now.ToString("yyyy"));
                                                        ht.Add("jzzt", (yljdata.Bdjg == "不合格" || yljdata.Bdjg == "0") ? "0" : "1");
                                                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                                                        htdata.Add("SDBDDSL", (dataseconds.Rows.Count - 1).ToString("0.0"));
                                                        string sdbdsj = "";
                                                        for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                        {
                                                            sdbdsj += "#" + dataseconds.Rows[i]["标准速度(Km/h)"].ToString() + "#" + dataseconds.Rows[i]["实测速度(Km/h)"].ToString();
                                                        }
                                                        htdata.Add("SDBDSJ", sdbdsj);

                                                        if (!mainPanel.hninterface.writeDemarcate(ht, htdata, out code, out msg))
                                                        {
                                                            ini.INIIO.saveLogInf("发送标定数据命令失败,code" + code + ",msg:" + msg);
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                                                    {
                                                        #region 大理联网
                                                        string code, msg;
                                                        string reportID;
                                                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                                                        System.Collections.Hashtable ht2 = new System.Collections.Hashtable();
                                                        DataTable dt = new DataTable();
                                                        ht.Add("检测站编号", mainPanel.stationid);
                                                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                                                        ht.Add("设备类别", "0");
                                                        ht.Add("设备名称", "车速标定");
                                                        ht.Add("设备型号", mainPanel.equipmodel.CGJXH);
                                                        ht.Add("标定时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                                        dt.Columns.Add("设定值");
                                                        dt.Columns.Add("实测值");
                                                        dt.Columns.Add("偏差");
                                                        DataRow dr = null;
                                                        for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                        {
                                                            dr = dt.NewRow();
                                                            dr["设定值"] = dataseconds.Rows[i]["标准速度(Km/h)"].ToString();
                                                            dr["实测值"] = dataseconds.Rows[i]["实测速度(Km/h)"].ToString();
                                                            dr["偏差"] = Math.Abs(double.Parse(dataseconds.Rows[i]["标准速度(Km/h)"].ToString()) - double.Parse(dataseconds.Rows[i]["实测速度(Km/h)"].ToString()));
                                                            dt.Rows.Add(dr);
                                                        }
                                                        if (!mainPanel.daliinterface.sendSpeedBdData(ht, dt, out code, out msg))
                                                        {
                                                            MessageBox.Show("发送速度标定信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                                                            ini.INIIO.saveLogInf("发送速度标定信息失败,code" + code + ",msg:" + msg);
                                                            return;
                                                        }
                                                        #endregion
                                                    }
                                                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
                                                    {
                                                        #region 安徽联网
                                                        try
                                                        {
                                                            AhWebClient.ah_cal_public_data pdata = new AhWebClient.ah_cal_public_data();
                                                            AhWebClient.ah_cal_judge_data jdata = new AhWebClient.ah_cal_judge_data();
                                                            pdata.Type = "1";
                                                            pdata.BeginTime = DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss");
                                                            pdata.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            pdata.Judge = "1";
                                                            jdata.type = "5";
                                                            jdata.CalibrateCount = (dataseconds.Rows.Count - 1).ToString();
                                                            List<AhWebClient.ah_force_caldata> listc = new List<AhWebClient.ah_force_caldata>();
                                                            for (int i = 1; i < dataseconds.Rows.Count; i++)
                                                            {
                                                                AhWebClient.ah_force_caldata cdata = new AhWebClient.ah_force_caldata();
                                                                DataRow dr = dataseconds.Rows[i];
                                                                double wc = 0;
                                                                double relwc = 0;
                                                                wc = Math.Abs(double.Parse(dr["标准速度(Km/h)"].ToString()) - double.Parse(dr["实测速度(Km/h)"].ToString()));
                                                                relwc = Math.Round(wc * 100.0 / double.Parse(dr["标准速度(Km/h)"].ToString()), 1);
                                                                cdata.NominalValue = dr["标准速度(Km/h)"].ToString();
                                                                cdata.RealValue = dr["实测速度(Km/h)"].ToString();
                                                                cdata.Deviation = relwc.ToString("0.0");
                                                                cdata.ErrorLimit = "0.5";
                                                                cdata.Result = (relwc > 0.5 ? "2" : "1");
                                                                if (cdata.Result == "2") pdata.Judge = "2";
                                                                listc.Add(cdata);
                                                            }
                                                            int ahresult = 0;
                                                            string ahErrMsg = "";
                                                            if (!mainPanel.ahinterface.Send_CALIBRATION_RESULT_DATA(mainPanel.lineid, pdata, jdata, listc, out ahresult, out ahErrMsg))
                                                            {
                                                                ini.INIIO.saveLogInf("[上传速度标定信息]:失败\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);

                                                            }
                                                            else
                                                            {
                                                                ini.INIIO.saveLogInf("[上传速度标定信息]:成功\r\n");
                                                            }
                                                        }
                                                        catch(Exception er)
                                                        {
                                                            ini.INIIO.saveLogInf("[上传速度标定信息]:异常：\r\n"+er.Message);

                                                        }
                                                        #endregion
                                                    }
                                                    demarcatecontrol.saveSdDataByIni(yljdata, mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                                                    if (yljdata.Bdjg == "合格")
                                                    {
                                                        ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                                        Msg(label1, panel4, "速度传感器校准结果合格");
                                                        mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "SDDATE", DateTime.Now.ToString());
                                                        if (mainPanel.linemodel.LOCKREASON == "速度传感器校准未通过")
                                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                                                    }
                                                    else
                                                    {
                                                        ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                                                        Msg(label1, panel4, "速度传感器校准未通过，请检查后再进行");
                                                        worklogdata.Result = "未通过";
                                                        if (mainPanel.linesbbd.Sdenable)
                                                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "速度传感器校准未通过");
                                                    }
                                                }
                                                isCsvAlive = "过程数据上传成功";

                                                if (mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.NEUSOFTNETMODE)
                                                {
                                                    if (mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                                                    {
                                                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                                                        string ackresult, errormessage;
                                                        mainPanel.neusoftsocket.UploadSpeedCalRequest(dataseconds, out ackresult, out errormessage);
                                                    }
                                                }
                                                //Msg(label1, panel4, "速度标定成功," + isCsvAlive);
                                            }
                                        }
                                        else
                                        {
                                            Msg(label1, panel4, "速度标定失败,未找到过程数据");
                                        }
                                    }
                                    else
                                    {
                                        Msg(label1, panel4, "速度标定完成");
                                    }
                                }
                                else
                                {
                                    Msg(label1, panel4, "速度标定完成");
                                }
                                File.Delete(newPath);
                                worklogdata.Result = "";
                                mainPanel.check_linezt();
                                demarcatecontrol.saveWordLogByIni(worklogdata);
                                return;
                                #endregion
                                break;
                            default:
                                Msg(label1, panel4, "标定完成");
                                File.Delete(newPath);
                                return;
                                break;
                        }
                        return;

                    }
                    else//程序结束但没有结果文件
                    {
                        Msg(label1, panel4, "未完成标定退出");
                        ini.INIIO.deleteDir(@"C:\jcdatatxt");
                        worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");
                        worklogdata.ProjectName = exename;
                        worklogdata.Stationid = mainPanel.stationid;
                        worklogdata.Lineid = mainPanel.lineid;
                        worklogdata.Czy = mainPanel.nowUser.userName;
                        worklogdata.Data = "未完成标定或检查退出";
                        worklogdata.State = "未完成";
                        worklogdata.Result = "";
                        worklogdata.Date = DateTime.Now;
                        worklogdata.Bzsm = "";
                        demarcatecontrol.saveWordLogByIni(worklogdata);
                        return;
                    }
                }
            }
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

        private void startdemarcate_Load(object sender, EventArgs e)
        {
            ini.INIIO.deleteDir(mainPanel.directory);
            Msg(label1, panel4, "正在进行" + _bdnr);   
            if(mainPanel.isNetUsed)
            {
                if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE )
                {
                    if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_LNAS)
                    {
                        string result, inf, timestring;
                        if (!mainPanel.sysocket.loginUser(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "1", out result, out inf))
                        {
                            MessageBox.Show("异常:" + result + "|信息:" + inf, "错误");
                            return;
                        }
                        else
                        {
                            if (result != "0")
                            {
                                MessageBox.Show("代码:" + result + "|信息:" + inf, "登录失败");
                                return;
                            }
                        }
                    }
                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_FJS || mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_YNZT||mainPanel.neusoftsocketinf.AREA==mainPanel.NEU_YNKM|| mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_GZCJ)
                    {
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        string result = "";
                        string inf = "";
                        DataTable limiecalibration = mainPanel.neusoftsocket.loginUserCalibrationFj(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "1", out result, out inf);
                        switch (result)
                        {
                            case "0": MessageBox.Show("该用户不存在", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "1": MessageBox.Show("该用户无此操作权限", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "-1": MessageBox.Show("服务器故障", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            default: break;
                        }
                        calstandarddata.COChkAbs = limiecalibration.Rows[0]["COChkAbs"].ToString();
                        calstandarddata.HCChkAbs = limiecalibration.Rows[0]["HCChkAbs"].ToString();
                        calstandarddata.NOChkAbs = limiecalibration.Rows[0]["NOChkAbs"].ToString();
                        calstandarddata.CO2ChkAbs = limiecalibration.Rows[0]["CO2ChkAbs"].ToString();
                        calstandarddata.O2ChkAbs = limiecalibration.Rows[0]["O2ChkAbs"].ToString();
                        calstandarddata.COChkRel = limiecalibration.Rows[0]["COChkRel"].ToString();
                        calstandarddata.HCChkRel = limiecalibration.Rows[0]["HCChkRel"].ToString();
                        calstandarddata.NOChkRel = limiecalibration.Rows[0]["NOChkRel"].ToString();
                        calstandarddata.CO2ChkRel = limiecalibration.Rows[0]["CO2ChkRel"].ToString();
                        calstandarddata.O2ChkRel = limiecalibration.Rows[0]["O2ChkRel"].ToString();
                        calstandarddata.COCalAbs = limiecalibration.Rows[0]["COCalAbs"].ToString();
                        calstandarddata.HCCalAbs = limiecalibration.Rows[0]["HCCalAbs"].ToString();
                        calstandarddata.NOCalAbs = limiecalibration.Rows[0]["NOCalAbs"].ToString();
                        calstandarddata.CO2CalAbs = limiecalibration.Rows[0]["CO2CalAbs"].ToString();
                        calstandarddata.O2CalAbs = limiecalibration.Rows[0]["O2CalAbs"].ToString();
                        calstandarddata.COCalRel = limiecalibration.Rows[0]["COCalRel"].ToString();
                        calstandarddata.HCCalRel = limiecalibration.Rows[0]["HCCalRel"].ToString();
                        calstandarddata.NOCalRel = limiecalibration.Rows[0]["NOCalRel"].ToString();
                        calstandarddata.CO2CalRel = limiecalibration.Rows[0]["CO2CalRel"].ToString();
                        calstandarddata.O2CalRel = limiecalibration.Rows[0]["O2CalRel"].ToString();

                        calstandarddata.COT90 = limiecalibration.Rows[0]["COT90"].ToString();
                        calstandarddata.HCT90 = limiecalibration.Rows[0]["HCT90"].ToString();
                        calstandarddata.NOT90 = limiecalibration.Rows[0]["NOT90"].ToString();
                        calstandarddata.CO2T90 = limiecalibration.Rows[0]["CO2T90"].ToString();
                        calstandarddata.O2T90 = limiecalibration.Rows[0]["O2T90"].ToString();
                        calstandarddata.COT10 = limiecalibration.Rows[0]["COT10"].ToString();
                        calstandarddata.HCT10 = limiecalibration.Rows[0]["HCT10"].ToString();
                        calstandarddata.NOT10 = limiecalibration.Rows[0]["NOT10"].ToString();
                        calstandarddata.CO2T10 = limiecalibration.Rows[0]["CO2T10"].ToString();
                        calstandarddata.O2T10 = limiecalibration.Rows[0]["O2T10"].ToString();

                        calstandarddata.Smoke = limiecalibration.Rows[0]["Smoke"].ToString();
                        calstandarddata.Rev = limiecalibration.Rows[0]["Rev"].ToString();
                        calstandarddata.Temperature = limiecalibration.Rows[0]["Temperature"].ToString();
                        calstandarddata.Humidity = limiecalibration.Rows[0]["Humidity"].ToString();
                        calstandarddata.AirPressure = limiecalibration.Rows[0]["AirPressure"].ToString();
                        calstandarddata.Coastdown = limiecalibration.Rows[0]["Coastdown"].ToString();
                        calstandarddata.Torque = limiecalibration.Rows[0]["Torque"].ToString();
                        calstandarddata.Velocity = limiecalibration.Rows[0]["Velocity"].ToString();
                        calstandarddata.ParasiticLoss = limiecalibration.Rows[0]["ParasiticLoss"].ToString();
                    }
                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V202)
                    {
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        string result = "";
                        string inf = "";
                        DataTable limiecalibration = mainPanel.neusoftsocket.loginUserCalibrationV202(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "1", mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, out result, out inf);
                        switch (result)
                        {
                            case "0": MessageBox.Show("该用户不存在", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "1": MessageBox.Show("该用户无此操作权限", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "-1": MessageBox.Show("服务器故障", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            default: break;
                        }
                        calstandarddata.COChkAbs = limiecalibration.Rows[0]["COChkAbs"].ToString();
                        calstandarddata.HCChkAbs = limiecalibration.Rows[0]["HCChkAbs"].ToString();
                        calstandarddata.NOChkAbs = limiecalibration.Rows[0]["NOChkAbs"].ToString();
                        calstandarddata.CO2ChkAbs = limiecalibration.Rows[0]["CO2ChkAbs"].ToString();
                        calstandarddata.O2ChkAbs = limiecalibration.Rows[0]["O2ChkAbs"].ToString();
                        calstandarddata.COChkRel = limiecalibration.Rows[0]["COChkRel"].ToString();
                        calstandarddata.HCChkRel = limiecalibration.Rows[0]["HCChkRel"].ToString();
                        calstandarddata.NOChkRel = limiecalibration.Rows[0]["NOChkRel"].ToString();
                        calstandarddata.CO2ChkRel = limiecalibration.Rows[0]["CO2ChkRel"].ToString();
                        calstandarddata.O2ChkRel = limiecalibration.Rows[0]["O2ChkRel"].ToString();
                        calstandarddata.COCalAbs = limiecalibration.Rows[0]["COCalAbs"].ToString();
                        calstandarddata.HCCalAbs = limiecalibration.Rows[0]["HCCalAbs"].ToString();
                        calstandarddata.NOCalAbs = limiecalibration.Rows[0]["NOCalAbs"].ToString();
                        calstandarddata.CO2CalAbs = limiecalibration.Rows[0]["CO2CalAbs"].ToString();
                        calstandarddata.O2CalAbs = limiecalibration.Rows[0]["O2CalAbs"].ToString();
                        calstandarddata.COCalRel = limiecalibration.Rows[0]["COCalRel"].ToString();
                        calstandarddata.HCCalRel = limiecalibration.Rows[0]["HCCalRel"].ToString();
                        calstandarddata.NOCalRel = limiecalibration.Rows[0]["NOCalRel"].ToString();
                        calstandarddata.CO2CalRel = limiecalibration.Rows[0]["CO2CalRel"].ToString();
                        calstandarddata.O2CalRel = limiecalibration.Rows[0]["O2CalRel"].ToString();

                        calstandarddata.COT90 = limiecalibration.Rows[0]["COT90"].ToString();
                        calstandarddata.HCT90 = limiecalibration.Rows[0]["HCT90"].ToString();
                        calstandarddata.NOT90 = limiecalibration.Rows[0]["NOT90"].ToString();
                        calstandarddata.CO2T90 = limiecalibration.Rows[0]["CO2T90"].ToString();
                        calstandarddata.O2T90 = limiecalibration.Rows[0]["O2T90"].ToString();
                        calstandarddata.COT10 = limiecalibration.Rows[0]["COT10"].ToString();
                        calstandarddata.HCT10 = limiecalibration.Rows[0]["HCT10"].ToString();
                        calstandarddata.NOT10 = limiecalibration.Rows[0]["NOT10"].ToString();
                        calstandarddata.CO2T10 = limiecalibration.Rows[0]["CO2T10"].ToString();
                        calstandarddata.O2T10 = limiecalibration.Rows[0]["O2T10"].ToString();

                        calstandarddata.Smoke = limiecalibration.Rows[0]["Smoke"].ToString();
                        calstandarddata.Rev = limiecalibration.Rows[0]["Rev"].ToString();
                        calstandarddata.Temperature = limiecalibration.Rows[0]["Temperature"].ToString();
                        calstandarddata.Humidity = limiecalibration.Rows[0]["Humidity"].ToString();
                        calstandarddata.AirPressure = limiecalibration.Rows[0]["AirPressure"].ToString();
                        calstandarddata.Coastdown = limiecalibration.Rows[0]["Coastdown"].ToString();
                        calstandarddata.Torque = limiecalibration.Rows[0]["Torque"].ToString();
                        calstandarddata.Velocity = limiecalibration.Rows[0]["Velocity"].ToString();
                        calstandarddata.ParasiticLoss = limiecalibration.Rows[0]["ParasiticLoss"].ToString();
                    }
                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_SDRZ)
                    {
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        string result = "";
                        string inf = "";
                        DataTable limiecalibration = mainPanel.neusoftsocket.loginUserCalibration(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "1", mainPanel.nowUser.ycyuserName, mainPanel.nowUser.ycyuserPassword, out result, out inf);
                        switch (result)
                        {
                            case "0": MessageBox.Show("该用户不存在", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "1": MessageBox.Show("该用户无此操作权限", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "9": MessageBox.Show("该用户不存在", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            case "-1": MessageBox.Show("服务器故障", "警告"); Msg(label1, panel4, "用户登录未成功，请重新选择用户"); return; break;
                            default: break;
                        }
                        calstandarddata.COChkAbs = limiecalibration.Rows[0]["COChkAbs"].ToString();
                        calstandarddata.HCChkAbs = limiecalibration.Rows[0]["HCChkAbs"].ToString();
                        calstandarddata.NOChkAbs = limiecalibration.Rows[0]["NOChkAbs"].ToString();
                        calstandarddata.CO2ChkAbs = limiecalibration.Rows[0]["CO2ChkAbs"].ToString();
                        calstandarddata.O2ChkAbs = limiecalibration.Rows[0]["O2ChkAbs"].ToString();
                        calstandarddata.COChkRel = limiecalibration.Rows[0]["COChkRel"].ToString();
                        calstandarddata.HCChkRel = limiecalibration.Rows[0]["HCChkRel"].ToString();
                        calstandarddata.NOChkRel = limiecalibration.Rows[0]["NOChkRel"].ToString();
                        calstandarddata.CO2ChkRel = limiecalibration.Rows[0]["CO2ChkRel"].ToString();
                        calstandarddata.O2ChkRel = limiecalibration.Rows[0]["O2ChkRel"].ToString();
                        calstandarddata.COCalAbs = limiecalibration.Rows[0]["COCalAbs"].ToString();
                        calstandarddata.HCCalAbs = limiecalibration.Rows[0]["HCCalAbs"].ToString();
                        calstandarddata.NOCalAbs = limiecalibration.Rows[0]["NOCalAbs"].ToString();
                        calstandarddata.CO2CalAbs = limiecalibration.Rows[0]["CO2CalAbs"].ToString();
                        calstandarddata.O2CalAbs = limiecalibration.Rows[0]["O2CalAbs"].ToString();
                        calstandarddata.COCalRel = limiecalibration.Rows[0]["COCalRel"].ToString();
                        calstandarddata.HCCalRel = limiecalibration.Rows[0]["HCCalRel"].ToString();
                        calstandarddata.NOCalRel = limiecalibration.Rows[0]["NOCalRel"].ToString();
                        calstandarddata.CO2CalRel = limiecalibration.Rows[0]["CO2CalRel"].ToString();
                        calstandarddata.O2CalRel = limiecalibration.Rows[0]["O2CalRel"].ToString();

                        calstandarddata.COT90 = limiecalibration.Rows[0]["COT90"].ToString();
                        calstandarddata.HCT90 = limiecalibration.Rows[0]["HCT90"].ToString();
                        calstandarddata.NOT90 = limiecalibration.Rows[0]["NOT90"].ToString();
                        calstandarddata.CO2T90 = limiecalibration.Rows[0]["CO2T90"].ToString();
                        calstandarddata.O2T90 = limiecalibration.Rows[0]["O2T90"].ToString();
                        calstandarddata.COT10 = limiecalibration.Rows[0]["COT10"].ToString();
                        calstandarddata.HCT10 = limiecalibration.Rows[0]["HCT10"].ToString();
                        calstandarddata.NOT10 = limiecalibration.Rows[0]["NOT10"].ToString();
                        calstandarddata.CO2T10 = limiecalibration.Rows[0]["CO2T10"].ToString();
                        calstandarddata.O2T10 = limiecalibration.Rows[0]["O2T10"].ToString();

                        calstandarddata.Smoke = limiecalibration.Rows[0]["Smoke"].ToString();
                        calstandarddata.Rev = limiecalibration.Rows[0]["Rev"].ToString();
                        calstandarddata.Temperature = limiecalibration.Rows[0]["Temperature"].ToString();
                        calstandarddata.Humidity = limiecalibration.Rows[0]["Humidity"].ToString();
                        calstandarddata.AirPressure = limiecalibration.Rows[0]["AirPressure"].ToString();
                        calstandarddata.Coastdown = limiecalibration.Rows[0]["Coastdown"].ToString();
                        calstandarddata.Torque = limiecalibration.Rows[0]["Torque"].ToString();
                        calstandarddata.Velocity = limiecalibration.Rows[0]["Velocity"].ToString();
                        calstandarddata.ParasiticLoss = limiecalibration.Rows[0]["ParasiticLoss"].ToString();
                    }
                    else if (mainPanel.neusoftsocketinf.AREA == mainPanel.NEU_V301)
                    {
                        string result, info;
                        mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                        DataTable limiecalibration = mainPanel.neusoftsocket.loginUserCalibrationv301(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "1", mainPanel.nowUser.ycyuserName, mainPanel.nowUser.ycyuserPassword, out result, out info);
                        if (result != "1")
                            {
                                MessageBox.Show(info, "警告");
                                return;
                            }
                        calstandarddata.COChkAbs = limiecalibration.Rows[0]["COChkAbs"].ToString();
                        calstandarddata.HCChkAbs = limiecalibration.Rows[0]["HCChkAbs"].ToString();
                        calstandarddata.NOChkAbs = limiecalibration.Rows[0]["NOChkAbs"].ToString();
                        calstandarddata.CO2ChkAbs = limiecalibration.Rows[0]["CO2ChkAbs"].ToString();
                        calstandarddata.O2ChkAbs = limiecalibration.Rows[0]["O2ChkAbs"].ToString();
                        calstandarddata.COChkRel = limiecalibration.Rows[0]["COChkRel"].ToString();
                        calstandarddata.HCChkRel = limiecalibration.Rows[0]["HCChkRel"].ToString();
                        calstandarddata.NOChkRel = limiecalibration.Rows[0]["NOChkRel"].ToString();
                        calstandarddata.CO2ChkRel = limiecalibration.Rows[0]["CO2ChkRel"].ToString();
                        calstandarddata.O2ChkRel = limiecalibration.Rows[0]["O2ChkRel"].ToString();
                        calstandarddata.COCalAbs = limiecalibration.Rows[0]["COCalAbs"].ToString();
                        calstandarddata.HCCalAbs = limiecalibration.Rows[0]["HCCalAbs"].ToString();
                        calstandarddata.NOCalAbs = limiecalibration.Rows[0]["NOCalAbs"].ToString();
                        calstandarddata.CO2CalAbs = limiecalibration.Rows[0]["CO2CalAbs"].ToString();
                        calstandarddata.O2CalAbs = limiecalibration.Rows[0]["O2CalAbs"].ToString();
                        calstandarddata.COCalRel = limiecalibration.Rows[0]["COCalRel"].ToString();
                        calstandarddata.HCCalRel = limiecalibration.Rows[0]["HCCalRel"].ToString();
                        calstandarddata.NOCalRel = limiecalibration.Rows[0]["NOCalRel"].ToString();
                        calstandarddata.CO2CalRel = limiecalibration.Rows[0]["CO2CalRel"].ToString();
                        calstandarddata.O2CalRel = limiecalibration.Rows[0]["O2CalRel"].ToString();

                        calstandarddata.COT90 = limiecalibration.Rows[0]["COT90"].ToString();
                        calstandarddata.HCT90 = limiecalibration.Rows[0]["HCT90"].ToString();
                        calstandarddata.NOT90 = limiecalibration.Rows[0]["NOT90"].ToString();
                        calstandarddata.CO2T90 = limiecalibration.Rows[0]["CO2T90"].ToString();
                        calstandarddata.O2T90 = limiecalibration.Rows[0]["O2T90"].ToString();
                        calstandarddata.COT10 = limiecalibration.Rows[0]["COT10"].ToString();
                        calstandarddata.HCT10 = limiecalibration.Rows[0]["HCT10"].ToString();
                        calstandarddata.NOT10 = limiecalibration.Rows[0]["NOT10"].ToString();
                        calstandarddata.CO2T10 = limiecalibration.Rows[0]["CO2T10"].ToString();
                        calstandarddata.O2T10 = limiecalibration.Rows[0]["O2T10"].ToString();

                        calstandarddata.Smoke = limiecalibration.Rows[0]["Smoke"].ToString();
                        calstandarddata.Rev = limiecalibration.Rows[0]["Rev"].ToString();
                        calstandarddata.Temperature = limiecalibration.Rows[0]["Temperature"].ToString();
                        calstandarddata.Humidity = limiecalibration.Rows[0]["Humidity"].ToString();
                        calstandarddata.AirPressure = limiecalibration.Rows[0]["AirPressure"].ToString();
                        calstandarddata.Coastdown = limiecalibration.Rows[0]["Coastdown"].ToString();
                        calstandarddata.Torque = limiecalibration.Rows[0]["Torque"].ToString();
                        calstandarddata.Velocity = limiecalibration.Rows[0]["Velocity"].ToString();
                        calstandarddata.ParasiticLoss = limiecalibration.Rows[0]["ParasiticLoss"].ToString();
                    }
                }

            }         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                int nhcode, nhexpcode;
                string nhmsg, nhexpmsg;
                mainPanel.nhinterface.SendUploadEquipmentStatus("4", out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
            }
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
            {
                int ahresult = 0;
                string ahErrMsg = "";
                if (!mainPanel.ahinterface.BeginCalibrate(mainPanel.lineid, out ahresult, out ahErrMsg))
                {
                    ini.INIIO.saveLogInf("发送标定开始指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                    return;
                    //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                }
            }
            bdrq = DateTime.Now;
            switch (_bdnr)
            {
                case "滑行测试":
                    Process.Start("D://环保检测子程序/加载滑行.EXE");
                    break;
                case "变载荷滑行测试":
                    Process.Start("D://环保检测子程序/变载荷滑行.EXE");
                    break;
                case "响应时间测试":
                    Process.Start("D://环保检测子程序/响应时间.EXE");
                    break;
                case "寄生功率测试":
                    Process.Start("D://环保检测子程序/汽油寄生功率.EXE");
                    break;
                case "惯量测试":
                    Process.Start("D://环保检测子程序/惯量标定.EXE");
                    break;
                case "废气仪检查":                    
                    Process.Start("D://环保检测子程序/废气仪标定.EXE",fqylx);
                    break;
                case "废气仪标定":
                    Process.Start("D://环保检测子程序/废气仪标定.EXE", fqylx);
                    break;
                case "流量计检测":
                    Process.Start("D://环保检测子程序/流量计标定.EXE");
                    break;
                case "烟度计检查":
                    Process.Start("D://环保检测子程序/烟度计标定.EXE");
                    break;
                case "气象站校准":
                    if (mainPanel.equipconfig.isTpTempInstrument)
                    {
                        double wd = 0, sd = 0, dqy = 0;
                        DateTime datetime;
                        if (mainPanel.logininfcontrol.getTHP(out datetime, out wd, out sd, out dqy))
                        {
                            TimeSpan ts = DateTime.Now - datetime;
                            if (ts.TotalMinutes > 30)
                            {
                                if (MessageBox.Show("检测到统配温湿度计已经超过30分钟没有更新\r\n是否继续？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                {
                                    return;
                                }
                            }
                            selfcheckini.writeWSD(wd.ToString("0.0"), sd.ToString("0.0"), dqy.ToString("0.0"));
                        }
                    }
                    Process.Start("D://环保检测子程序/气象站校准.EXE");
                    break;
                case "扭力标定":
                    Process.Start("D://环保检测子程序/扭力标定.EXE");
                    break;
                case "速度标定":
                    Process.Start("D://环保检测子程序/速度标定.EXE");
                    break;
                case "预热":
                    Process.Start("D://环保检测子程序/预热.EXE");
                    break;
                default: break;
            }
            Thread th_wait = new Thread(waitTestFinished);
            th_wait.Start();
        }

        private void startdemarcate_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                int nhcode, nhexpcode;
                string nhmsg, nhexpmsg;
                mainPanel.nhinterface.SendUploadEquipmentStatus("1", out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
            }
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
            {
                int ahresult = 0;
                string ahErrMsg = "";
                if (!mainPanel.ahinterface.EndCalibrate(mainPanel.lineid,"1", out ahresult, out ahErrMsg))
                {
                    ini.INIIO.saveLogInf("发送标定结束指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                    //return;
                    //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                }
            }
        }
    }
}
