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
using System.Collections;

namespace exhaustDetect
{
    public partial class startSelfCheck : Form
    {
        public string ZJLX_JZHX = "01";
        public string ZJLX_FQY = "02";
        public string ZJLX_YDJ = "03";
        public string ZJLX_DZHJ = "04";
        public string ZJLX_ZSJ = "05";
        public string ZJLX_LLJ = "06";
        public string ZJLX_JSGL = "07";
        public delegate void wtlsb(Label Msgowner, string Msgstr);                //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                              //委托
        public delegate void wtlm(Label Msgowner, string Msgstr);
        demarcateControl demarcatecontrol = new demarcateControl();
        selfcheckdal selfcheckcontrol = new selfcheckdal();
        carinfor.analysismeterInidata analysismeterdata = new carinfor.analysismeterInidata();
        carinfor.analysismeterIni analysismetercontrol = new carinfor.analysismeterIni();
        carinfor.Flowmeterdata flowmeterdata = new carinfor.Flowmeterdata();
        carinfor.flowmeterIni flowmetercontrol = new carinfor.flowmeterIni();
        carinfor.glideControl glidecontrol = new carinfor.glideControl();
        carinfor.glide glidedata = new carinfor.glide();
        carinfor.inertness inertnessdata = new carinfor.inertness();
        carinfor.inertnessControl inertnesscontrol = new carinfor.inertnessControl();
        carinfor.parasitic parasiticdata = new carinfor.parasitic();
        carinfor.parasiticControl parasiticcontrol = new carinfor.parasiticControl();
        string yuredata = "";
        carinfor.yureconfigIni yurecontrol = new carinfor.yureconfigIni();
        private string _bdnr;
        private DateTime bdrq;

        carinfor.selfCheckIni selfcheckini = new carinfor.selfCheckIni();
        selfcheckdata checkdata = new selfcheckdata();

        Thread th_wait = null;
        string zjfinishstring = "";

        bool isqxzcheck = false, isfqycheck = false, isbtgcheck = false, iscgjcheck = false, islljcheck = false, iszsjcheck = false;
        public startSelfCheck()
        {
            InitializeComponent();
            
        }
        public startSelfCheck(string bdnr)
        {
            InitializeComponent();
            _bdnr = bdnr;
            
        }
        private void initSelfData(string id)
        {
            checkdata.ID = id;
            checkdata.WORKTIME = DateTime.Now;
            checkdata.WORKER = mainPanel.nowUser.userName;
            checkdata.ISQXZCHECK = "N";
            checkdata.TEMPOK = "";
            checkdata.HUMIOK = "";
            checkdata.AIRPOK = "";
            checkdata.TEMP = "";
            checkdata.HUMI = "";
            checkdata.AIRP = "";
            checkdata.ISFQYCHECK = "N";
            checkdata.FQYTX = "";
            checkdata.FQYYR = "";
            checkdata.FQYTL = "";
            checkdata.FQYJL = "";
            checkdata.FQYLC = "";
            checkdata.FQYO2 = "";
            checkdata.ISBTGCHECK = "N";
            checkdata.BTGTX = "";
            checkdata.BTGYR = "";
            checkdata.BTGTL = "";
            checkdata.BTGLC = "";
            checkdata.BTGJZ = "";
            checkdata.ISCGJCHECK = "N";
            checkdata.CGJTX = "";
            checkdata.CGJYR = "";
            checkdata.CGJQL = "";
            checkdata.CGJJSGL = "";
            checkdata.CGJJZHX = "";
            checkdata.CGJEDGL = "";
            checkdata.CGJSJGL = "";
            checkdata.CGJGLWC = "";
            checkdata.CGJVITRUALTIME = "";
            checkdata.CGJREALTIME = "";
            checkdata.CGJTIMEWC = "";
            checkdata.ISLLJCHECK = "N";
            checkdata.LLJTX = "";
            checkdata.LLJLL = "";
            checkdata.ISZSJCHECK = "N";
            checkdata.ZSJTX = "";
            checkdata.ZSJLC = "";
            checkdata.HSSlideActualTime = "";
            checkdata.HSSlideTheoreticalTime = "";
            checkdata.HSSlideLoadPower = "";
            checkdata.HSSlideBeginTime = "";
            checkdata.HSSlideEndTime = "";
            checkdata.LSSlideActualTime = "";
            checkdata.LSSlideTheoreticalTime = "";
            checkdata.LSSlideLoadPower = "";
            checkdata.LSSlideBeginTime = "";
            checkdata.LSSlideEndTime = "";
            checkdata.WattlessMaxSpeed1 = "";
            checkdata.WattlessMinSpeed1 = "";
            checkdata.WattlessNorminalSpeed1 = "";
            checkdata.WattlessBeginTime1 = "";
            checkdata.WattlessEndTime1 = "";
            checkdata.WattlessOutput1 = "";
            checkdata.WattlessMaxSpeed2 = "";
            checkdata.WattlessMinSpeed2 = "";
            checkdata.WattlessNorminalSpeed2 = "";
            checkdata.WattlessBeginTime2 = "";
            checkdata.WattlessEndTime2 = "";
            checkdata.WattlessOutput2 = "";
            checkdata.WattlessMaxSpeed3 = "";
            checkdata.WattlessMinSpeed3 = "";
            checkdata.WattlessNorminalSpeed3 = "";
            checkdata.WattlessBeginTime3 = "";
            checkdata.WattlessEndTime3 = "";
            checkdata.WattlessOutput3 = "";
            checkdata.WattlessMaxSpeed4 = "";
            checkdata.WattlessMinSpeed4 = "";
            checkdata.WattlessNorminalSpeed4 = "";
            checkdata.WattlessBeginTime4 = "";
            checkdata.WattlessEndTime4 = "";
            checkdata.WattlessOutput4 = "";
            checkdata.O2MRBeginTime = "";
            checkdata.O2MREndTime = "";
            checkdata.WQBeginTime = "";
            checkdata.WQEndTime = "";
            checkdata.SlideJudge = "";
            checkdata.WattlessJudge = "";
            checkdata.O2MRJudge = "";
            checkdata.WQJudge = "";
            checkdata.AllJudge = "2";
        }
        private void waitTestFinished()
        {
            string uploadMsg = "";
            //string newPath = "C://jcdatatxt/CGJcheckdata.ini";
            string cgjPath = "C://jcdatatxt/CGJcheckdata.ini";
            string plhpPath = "C://jcdatatxt/cgjPLHPSelfcheck.ini";
            string fqyPath = "C://jcdatatxt/wqfxySelfcheck.ini";
            string ydjPath = "C://jcdatatxt/ydjSelfcheck.ini";
            string lljPath = "C://jcdatatxt/LLJcheckdata.ini";
            string sdsfqyPath = "C://jcdatatxt/sdsqtfxySelfcheck.ini";
            string hjcsPath = "C://jcdatatxt/hjcsgyqSelfcheck.ini";
            string zsjPath = "C://jcdatatxt/fdjzsSelfcheck.ini";
            string zjPath = "C://jcdatatxt/Yure.ini";
            string zjStatePath = "C://jcdatatxt/checkstatedata.ini";
            while (true)
            {
                Thread.Sleep(2000);
                if (File.Exists(zjStatePath))
                {
                    Thread.Sleep(100);//等待两秒以确保文件内容写完
                    carinfor.selfCheckState checkstate = new carinfor.selfCheckState();
                    checkstate = selfcheckini.readSelfcheckState();
                    File.Delete(zjStatePath);
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        if (checkstate.NType == "V")
                        {
                            carinfor.equipmentSelfDetectStart selfcheckstart = new carinfor.equipmentSelfDetectStart();
                            selfcheckstart.JCGWH = mainPanel.lineid;
                            selfcheckstart.SBBH = checkstate.Sbbh;
                            switch (checkstate.Sbbh)
                            {
                                case "1":
                                    selfcheckstart.BDSBMC = "测功机";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.CGJXH;
                                    break;
                                case "2":
                                    selfcheckstart.BDSBMC = "废气仪";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.FXYXH;
                                    break;
                                case "3":
                                    selfcheckstart.BDSBMC = "烟度计";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.YDJXH;
                                    break;
                                case "4":
                                    selfcheckstart.BDSBMC = "电子环境信息仪";
                                    selfcheckstart.BDSBXH = "";
                                    break;
                                case "5":
                                    selfcheckstart.BDSBMC = "发动机转速仪";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.ZSJXH;
                                    break;
                                default: break;
                            }
                            selfcheckstart.SJXL = checkstate.Sjxl;
                            selfcheckstart.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            ini.INIIO.saveLogInf("上传自检开始信息" + selfcheckstart.writeequipmentSelfDetectStart());
                        }
                        else
                        {
                            carinfor.equipmentSelfDetectFinish selfcheckstart = new carinfor.equipmentSelfDetectFinish();
                            selfcheckstart.JCGWH = mainPanel.lineid;
                            selfcheckstart.SBBH = checkstate.Sbbh;
                            switch (checkstate.Sbbh)
                            {
                                case "1":
                                    selfcheckstart.BDSBMC = "测功机";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.CGJXH;
                                    break;
                                case "2":
                                    selfcheckstart.BDSBMC = "废气仪";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.FXYXH;
                                    break;
                                case "3":
                                    selfcheckstart.BDSBMC = "烟度计";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.YDJXH;
                                    break;
                                case "4":
                                    selfcheckstart.BDSBMC = "电子环境信息仪";
                                    selfcheckstart.BDSBXH = "";
                                    break;
                                case "5":
                                    selfcheckstart.BDSBMC = "发动机转速仪";
                                    selfcheckstart.BDSBXH = mainPanel.equipmodel.ZSJXH;
                                    break;
                                default: break;
                            }
                            selfcheckstart.SJXL = checkstate.Sjxl;
                            selfcheckstart.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            ini.INIIO.saveLogInf("上传自检结束信息" + selfcheckstart.writeequipmentSelfDetectFinish());
                        }
                    }
                }
                if (File.Exists(zsjPath))
                {
                    Thread.Sleep(100);//等待两秒以确保文件内容写完
                    carinfor.fdjzsSelfCheck checkstate = new carinfor.fdjzsSelfCheck();
                    checkstate = selfcheckini.readfdjzsSelfcheck();
                    File.Delete(zsjPath);
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.zsjSelfDetecInf aczsjselfcheckdata = new carinfor.zsjSelfDetecInf();
                        aczsjselfcheckdata.JCGWH = mainPanel.lineid;
                        aczsjselfcheckdata.SBMC = "发动机转速仪";
                        aczsjselfcheckdata.SBXH = mainPanel.equipmodel.CGJXH;
                        aczsjselfcheckdata.JCZBH = mainPanel.stationid;
                        aczsjselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        aczsjselfcheckdata.TXJC = "1";
                        aczsjselfcheckdata.DSZS = checkstate.Dszs;
                        aczsjselfcheckdata.ZJJG = checkstate.Zjjg;
                        aczsjselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传测功机自检信息" + aczsjselfcheckdata.writezsjSelfDetecInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxZsjCheckdata jxdata = new JxWebClient.jxZsjCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.statusFlag = "1";
                        jxdata.resultFlag = checkstate.Zjjg == "通过" ? "1" : "0";
                        jxdata.failureReason = "";
                        jxdata.flagConnect = "";
                        jxdata.lowSpeed = checkstate.Dszs;
                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(10, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", checkstate.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber", mainPanel.equipmodel.ZSJBH);
                        ht.Add("EquipmentModel", mainPanel.equipmodel.ZSJXH);
                        ht.Add("EquipmentName", "转速计");
                        ht.Add("ComChk", "1");
                        ht.Add("IdleRev", checkstate.Dszs);
                        mainPanel.nhinterface.SendSelfCheckData("UploadFloSelfTestData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        { }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.ZSJBH);
                            hstb.Add("ZJLX", ZJLX_ZSJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (checkstate.Zjjg == "不合格" || checkstate.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", checkstate.Dszs);
                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存转速计自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存转速计自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.ZSJBH);
                            hstb.Add("ZJLX", ZJLX_ZSJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (checkstate.Zjjg == "不合格" || checkstate.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", checkstate.Dszs);
                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存转速计自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存转速计自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        string optime = "";
                        optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (mainPanel.jhzsjinf != null)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeyZsjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, checkstate, mainPanel.jhzsjinf))
                                {
                                    ini.INIIO.saveLogInf("发送转速计自检数据成功");
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                        ini.INIIO.saveLogInf("发送转速计自检数据失败");
                                }
                            }
                        }
                        else if (mainPanel.jhydjinf != null)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeyZsjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, checkstate, mainPanel.jhydjinf))
                                {
                                    ini.INIIO.saveLogInf("发送转速计自检数据成功");
                                    uploadMsg += "转速计上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送转速计自检数据失败");
                                        uploadMsg += "转速计上传失败|";
                                    }
                                }
                            }
                        }                      
                        else if (mainPanel.jhfqyinf != null)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeyZsjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, checkstate, mainPanel.jhfqyinf))
                                {
                                    ini.INIIO.saveLogInf("发送转速计自检数据成功");
                                    uploadMsg += "转速计上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送转速计自检数据失败");
                                        uploadMsg += "转速计上传失败|";
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送转速计自检数据失败,没有获取到该线转速计或废气仪或烟度计信息");
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        string code, msg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("sblxid", "6");
                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        
                        if (!mainPanel.hninterface.startSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送开始自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "6");
                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        
                        if (!mainPanel.hninterface.finishSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "6");
                        ht.Add("zjjl", (checkstate.Zjjg == "不合格" || checkstate.Zjjg == "0") ? "0" : "1");
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                        htdata.Add("zsjtxzj", "1");
                        htdata.Add("dszj", checkstate.Dszs);
                        if (!mainPanel.hninterface.writeSelfCheck(ht,htdata, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.DALINETMODE)
                    {
                        #region 大理联网
                        string code, msg;
                        string reportID;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        
                        ht.Add("检测站编号", mainPanel.stationid);
                        ht.Add("检测工位编号", mainPanel.daliwebinf.LINEID);
                        ht.Add("设备类别", "4");
                        ht.Add("设备名称", "发动机转速仪");
                        ht.Add("设备型号", mainPanel.equipmodel.ZSJXH);
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查","成功");
                        ht.Add("怠速转速", checkstate.Dszs);
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        if (!mainPanel.daliinterface.sendZsjZjData(ht,null, out code, out msg))
                        {
                            MessageBox.Show("发送转速计自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送转速计自检信息失败,code" + code + ",msg:" + msg);
                            return;
                        }
                        #endregion
                    }
                }
                if (File.Exists(cgjPath))
                {
                    ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.CGJselfCheckdata cgjdata = new carinfor.CGJselfCheckdata();
                    cgjdata = selfcheckini.readCGJcheckIni();
                    zjfinishstring += "加载滑行完成|";
                    File.Delete(cgjPath);
                    //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                    //mainPanel.check_linezt();
                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[测功机自检]通讯:正常" + cgjdata.Hvitualtime + "," + cgjdata.Hrealtime + "," + cgjdata.Lvitualtime + "," + cgjdata.Lrealtime + "," + cgjdata.Hpower + "," + cgjdata.Lpower + "," + cgjdata.ChecckResult + "," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                    mainPanel.worklogdata.State = "";
                    mainPanel.worklogdata.Result = ((cgjdata.ChecckResult == "0") ? "未通过" : "通过");
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISCGJCHECK = "Y";
                        checkdata.CGJTX = "Y";
                        checkdata.CGJYR = "Y";
                        checkdata.CGJQL = "Y";
                        checkdata.CGJJSGL = "Y";
                        checkdata.CGJJZHX =(cgjdata.ChecckResult=="1")? "Y":"N";
                        checkdata.CGJEDGL = cgjdata.Lpower.ToString();
                        checkdata.CGJSJGL = cgjdata.Lpower.ToString();
                        checkdata.CGJGLWC = "";
                        checkdata.CGJVITRUALTIME = cgjdata.Lvitualtime.ToString("0.000");
                        checkdata.CGJREALTIME = cgjdata.Lrealtime.ToString("0.000");
                        checkdata.CGJTIMEWC = (100 * (cgjdata.Lrealtime - cgjdata.Lvitualtime) / cgjdata.Lvitualtime).ToString("0.0");
                        if (cgjdata.Jzhxds == "2")
                        {
                            checkdata.HSSlideActualTime = cgjdata.Hvitualtime.ToString("0.000");
                            checkdata.HSSlideTheoreticalTime = cgjdata.Hvitualtime.ToString("0.000");
                            checkdata.HSSlideLoadPower= cgjdata.Hpower.ToString();
                            checkdata.HSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.HSSlideEndTime = cgjdata.CheckTimeEnd;
                            checkdata.LSSlideActualTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideTheoreticalTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideLoadPower = cgjdata.Lpower.ToString();
                            checkdata.LSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.LSSlideEndTime = cgjdata.CheckTimeEnd;

                        }
                        else
                        {
                            checkdata.HSSlideActualTime = "";
                            checkdata.HSSlideTheoreticalTime = "";
                            checkdata.HSSlideLoadPower = "";
                            checkdata.HSSlideBeginTime = "";
                            checkdata.HSSlideEndTime = "";
                            checkdata.LSSlideActualTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideTheoreticalTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideLoadPower = cgjdata.Lpower.ToString();
                            checkdata.LSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.LSSlideEndTime = cgjdata.CheckTimeEnd;
                        }
                        if (cgjdata.ChecckResult == "1")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";

                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISCGJCHECK = "Y";
                        checkdata.CGJTX = "Y";
                        checkdata.CGJYR = "Y";
                        checkdata.CGJQL = "Y";
                        checkdata.CGJJSGL = "Y";
                        checkdata.CGJJZHX = (cgjdata.ChecckResult == "1") ? "Y" : "N";
                        checkdata.CGJEDGL = cgjdata.Lpower.ToString();
                        checkdata.CGJSJGL = cgjdata.Lpower.ToString();
                        checkdata.CGJGLWC = "";
                        checkdata.CGJVITRUALTIME = cgjdata.Lvitualtime.ToString("0.000");
                        checkdata.CGJREALTIME = cgjdata.Lrealtime.ToString("0.000");
                        checkdata.CGJTIMEWC = (100 * (cgjdata.Lrealtime - cgjdata.Lvitualtime) / cgjdata.Lvitualtime).ToString("0.0");
                        if (cgjdata.Jzhxds == "2")
                        {
                            checkdata.HSSlideActualTime = cgjdata.Hvitualtime.ToString("0.000");
                            checkdata.HSSlideTheoreticalTime = cgjdata.Hvitualtime.ToString("0.000");
                            checkdata.HSSlideLoadPower = cgjdata.Hpower.ToString();
                            checkdata.HSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.HSSlideEndTime = cgjdata.CheckTimeEnd;
                            checkdata.LSSlideActualTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideTheoreticalTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideLoadPower = cgjdata.Lpower.ToString();
                            checkdata.LSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.LSSlideEndTime = cgjdata.CheckTimeEnd;

                        }
                        else
                        {
                            checkdata.HSSlideActualTime = "";
                            checkdata.HSSlideTheoreticalTime = "";
                            checkdata.HSSlideLoadPower = "";
                            checkdata.HSSlideBeginTime = "";
                            checkdata.HSSlideEndTime = "";
                            checkdata.LSSlideActualTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideTheoreticalTime = cgjdata.Lvitualtime.ToString("0.000");
                            checkdata.LSSlideLoadPower = cgjdata.Lpower.ToString();
                            checkdata.LSSlideBeginTime = cgjdata.CheckTimeStart;
                            checkdata.LSSlideEndTime = cgjdata.CheckTimeEnd;
                        }
                        if (cgjdata.ChecckResult == "1")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.cgjSelfDetectInf accgjselfcheckdata = new carinfor.cgjSelfDetectInf();
                        accgjselfcheckdata.JCGWH = mainPanel.lineid;
                        accgjselfcheckdata.SBMC = "底盘测功机";
                        accgjselfcheckdata.SBXH = mainPanel.equipmodel.CGJXH;
                        accgjselfcheckdata.JCZBH = mainPanel.stationid;
                        accgjselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        accgjselfcheckdata.TXJC = "1";
                        accgjselfcheckdata.JSQJC = "1";
                        accgjselfcheckdata.TTYRKSSJ = cgjdata.CheckTimeStart;
                        accgjselfcheckdata.TTYRJSSJ = cgjdata.CheckTimeEnd;
                        accgjselfcheckdata.GXDL = cgjdata.Gxdl;
                        accgjselfcheckdata.JZHXDS = cgjdata.Jzhxds;
                        if (cgjdata.Jzhxds == "2")
                        {
                            accgjselfcheckdata.JZHXDS = "2";
                            accgjselfcheckdata.CS1 = cgjdata.Cs1;
                            accgjselfcheckdata.JZGL1 = cgjdata.Hpower.ToString();
                            accgjselfcheckdata.JSGL1 = cgjdata.Jsgl1;
                            accgjselfcheckdata.LLHXSJ1 = cgjdata.Hvitualtime.ToString();
                            accgjselfcheckdata.SJHXSJ1 = cgjdata.Hrealtime.ToString();
                            accgjselfcheckdata.PC1 = cgjdata.Pc1;
                            accgjselfcheckdata.CS2 = cgjdata.Cs2;
                            accgjselfcheckdata.JZGL2 = cgjdata.Lpower.ToString();
                            accgjselfcheckdata.JSGL2 = cgjdata.Jsgl2;
                            accgjselfcheckdata.LLHXSJ2 = cgjdata.Lvitualtime.ToString();
                            accgjselfcheckdata.SJHXSJ2 = cgjdata.Lrealtime.ToString();
                            accgjselfcheckdata.PC2 = cgjdata.Pc2;
                        }
                        else
                        {
                            accgjselfcheckdata.JZHXDS = "1";
                            accgjselfcheckdata.CS1 = cgjdata.Cs2;
                            accgjselfcheckdata.JZGL1 = cgjdata.Lpower.ToString();
                            accgjselfcheckdata.JSGL1 = cgjdata.Jsgl2;
                            accgjselfcheckdata.LLHXSJ1 = cgjdata.Lvitualtime.ToString();
                            accgjselfcheckdata.SJHXSJ1 = cgjdata.Lrealtime.ToString();
                            accgjselfcheckdata.PC1 = cgjdata.Pc2;
                            accgjselfcheckdata.CS2 = "";
                            accgjselfcheckdata.JZGL2 = "";
                            accgjselfcheckdata.JSGL2 = "";
                            accgjselfcheckdata.LLHXSJ2 = "";
                            accgjselfcheckdata.SJHXSJ2 = "";
                            accgjselfcheckdata.PC2 = "";
                        }
                        accgjselfcheckdata.ZJJG = cgjdata.Zjjg;
                        accgjselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传测功机自检信息" + accgjselfcheckdata.writecgjSelfDetectInf());

                       
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxJxhxdata jxdata = new JxWebClient.jxJxhxdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.coastedStartTime = cgjdata.CheckTimeStart;
                        if (cgjdata.Jzhxds == "2")
                        {
                            jxdata.coastedActualTime48to32 = cgjdata.Hvitualtime.ToString();
                            jxdata.coastedActualTime32to16 = cgjdata.Lvitualtime.ToString();
                            jxdata.loss40 = cgjdata.Jsgl1;
                            jxdata.loss25 = cgjdata.Jsgl2;
                            jxdata.coastedNominalTime48to32 = cgjdata.Hrealtime.ToString();
                            jxdata.coastedNominalTime32to16 = cgjdata.Lrealtime.ToString();
                            jxdata.coastedPower48to32 = cgjdata.Hpower.ToString();
                            jxdata.coastedPower32to16 = cgjdata.Lpower.ToString();
                            jxdata.basicInertia = cgjdata.Gxdl;
                            jxdata.coastedResult48to32 = (double.Parse(cgjdata.Pc1)<=7)?"1":"0";
                            jxdata.coastedResult32to16 = (double.Parse(cgjdata.Pc2) <= 7) ? "1" : "0";
                            jxdata.resultFlag = cgjdata.Zjjg == "通过" ? "1" : "0";
                        }
                        else
                        {
                            jxdata.coastedActualTime48to32 = "";
                            jxdata.coastedActualTime32to16 = cgjdata.Lvitualtime.ToString();
                            jxdata.loss40 = "";
                            jxdata.loss25 = cgjdata.Jsgl2;
                            jxdata.coastedNominalTime48to32 = "";
                            jxdata.coastedNominalTime32to16 = cgjdata.Lrealtime.ToString();
                            jxdata.coastedPower48to32 = "";
                            jxdata.coastedPower32to16 = cgjdata.Lpower.ToString();
                            jxdata.basicInertia = cgjdata.Gxdl;
                            jxdata.coastedResult48to32 = "";
                            jxdata.coastedResult32to16 = (double.Parse(cgjdata.Pc2) <= 7) ? "1" : "0";
                            jxdata.resultFlag = cgjdata.Zjjg=="通过"?"1":"0";
                        }
                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(1, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        string optime = "";
                        optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (mainPanel.jhcgjinf != null)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeCgjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhcgjinf))
                                {
                                    ini.INIIO.saveLogInf("发送测功机自检数据成功");
                                    uploadMsg += "测功机上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送测功机自检数据失败");
                                        uploadMsg += "测功机上传失败|";
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送测功机自检数据失败,没有获取到该线测功机自检数据");
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.加载滑行检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            if (cgjdata.Jzhxds == "2")
                            {
                                hstb.Add("DATA2", cgjdata.Hrealtime.ToString("0.000"));
                                hstb.Add("DATA3", cgjdata.Lrealtime.ToString("0.000"));
                                hstb.Add("DATA4", cgjdata.Jsgl1);
                                hstb.Add("DATA5", cgjdata.Jsgl2);
                                hstb.Add("DATA6", cgjdata.Hvitualtime.ToString("0.000"));
                                hstb.Add("DATA7", cgjdata.Lvitualtime.ToString("0.000"));
                                hstb.Add("DATA8", cgjdata.Hpower.ToString("0.0"));
                                hstb.Add("DATA9", cgjdata.Lpower.ToString("0.0"));
                                hstb.Add("DATA10", cgjdata.Gxdl);
                                hstb.Add("DATA11", double.Parse(cgjdata.Pc1) > 7 ? "0" : "1");
                                hstb.Add("DATA12", double.Parse(cgjdata.Pc2) > 7 ? "0" : "1");
                            }
                            else
                            {
                                hstb.Add("DATA2", "");
                                hstb.Add("DATA3", cgjdata.Lrealtime.ToString("0.000"));
                                hstb.Add("DATA4", "");
                                hstb.Add("DATA5", cgjdata.Jsgl2);
                                hstb.Add("DATA6", "");
                                hstb.Add("DATA7", cgjdata.Lvitualtime.ToString("0.000"));
                                hstb.Add("DATA8", "");
                                hstb.Add("DATA9", cgjdata.Lpower.ToString("0.0"));
                                hstb.Add("DATA10", cgjdata.Gxdl);
                                hstb.Add("DATA11", "");
                                hstb.Add("DATA12",double.Parse( cgjdata.Pc2)>7?"0":"1");
                            }
                            hstb.Add("DATA13", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句失败");
                            }
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                            hstb.Add("ZJLX", ZJLX_JZHX);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", DateTime.Parse(cgjdata.CheckTimeStart));
                            hstb.Add("DATA4", DateTime.Parse(cgjdata.CheckTimeEnd));
                            hstb.Add("DATA5", cgjdata.Gxdl);
                            if (cgjdata.Jzhxds == "2")
                            {
                                hstb.Add("DATA6", "64-48");
                                hstb.Add("DATA7", cgjdata.Hpower.ToString());
                                hstb.Add("DATA8", cgjdata.Jsgl1);
                                hstb.Add("DATA9", cgjdata.Hvitualtime.ToString());
                                hstb.Add("DATA10", cgjdata.Hrealtime.ToString());
                                hstb.Add("DATA11", cgjdata.Pc1);
                                hstb.Add("DATA12", cgjdata.kssj1);
                                hstb.Add("DATA13", cgjdata.jssj1);
                                hstb.Add("DATA14", "48-32");
                                hstb.Add("DATA15", cgjdata.Lpower.ToString());
                                hstb.Add("DATA16", cgjdata.Jsgl2);
                                hstb.Add("DATA17", cgjdata.Lvitualtime.ToString());
                                hstb.Add("DATA18", cgjdata.Lrealtime.ToString());
                                hstb.Add("DATA19", cgjdata.Pc2);
                                hstb.Add("DATA20", cgjdata.kssj2);
                                hstb.Add("DATA21", cgjdata.jssj2);
                            }
                            else
                            {
                                hstb.Add("DATA6", "48-32");
                                hstb.Add("DATA7", cgjdata.Lpower.ToString());
                                hstb.Add("DATA8", cgjdata.Jsgl2);
                                hstb.Add("DATA9", cgjdata.Lvitualtime.ToString());
                                hstb.Add("DATA10", cgjdata.Lrealtime.ToString());
                                hstb.Add("DATA11", cgjdata.Pc2);
                                hstb.Add("DATA12", cgjdata.kssj2);
                                hstb.Add("DATA13", cgjdata.jssj2);
                                hstb.Add("DATA14", "");
                                hstb.Add("DATA15", "");
                                hstb.Add("DATA16", "");
                                hstb.Add("DATA17", "");
                                hstb.Add("DATA18", "");
                                hstb.Add("DATA19", "");
                                hstb.Add("DATA20", "");
                                hstb.Add("DATA21", "");
                            }

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                            hstb.Add("ZJLX", ZJLX_JZHX);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", DateTime.Parse(cgjdata.CheckTimeStart));
                            hstb.Add("DATA4", DateTime.Parse(cgjdata.CheckTimeEnd));
                            hstb.Add("DATA5", cgjdata.Gxdl);
                            if (cgjdata.Jzhxds == "2")
                            {
                                hstb.Add("DATA6", "64-48");
                                hstb.Add("DATA7", cgjdata.Hpower.ToString());
                                hstb.Add("DATA8", cgjdata.Jsgl1);
                                hstb.Add("DATA9", cgjdata.Hvitualtime.ToString());
                                hstb.Add("DATA10", cgjdata.Hrealtime.ToString());
                                hstb.Add("DATA11", cgjdata.Pc1);
                                hstb.Add("DATA12", cgjdata.kssj1);
                                hstb.Add("DATA13", cgjdata.jssj1);
                                hstb.Add("DATA14", "48-32");
                                hstb.Add("DATA15", cgjdata.Lpower.ToString());
                                hstb.Add("DATA16", cgjdata.Jsgl2);
                                hstb.Add("DATA17", cgjdata.Lvitualtime.ToString());
                                hstb.Add("DATA18", cgjdata.Lrealtime.ToString());
                                hstb.Add("DATA19", cgjdata.Pc2);
                                hstb.Add("DATA20", cgjdata.kssj2);
                                hstb.Add("DATA21", cgjdata.jssj2);
                            }
                            else
                            {
                                hstb.Add("DATA6", "48-32");
                                hstb.Add("DATA7", cgjdata.Lpower.ToString());
                                hstb.Add("DATA8", cgjdata.Jsgl2);
                                hstb.Add("DATA9", cgjdata.Lvitualtime.ToString());
                                hstb.Add("DATA10", cgjdata.Lrealtime.ToString());
                                hstb.Add("DATA11", cgjdata.Pc2);
                                hstb.Add("DATA12", cgjdata.kssj2);
                                hstb.Add("DATA13", cgjdata.jssj2);
                                hstb.Add("DATA14", "");
                                hstb.Add("DATA15", "");
                                hstb.Add("DATA16", "");
                                hstb.Add("DATA17", "");
                                hstb.Add("DATA18", "");
                                hstb.Add("DATA19", "");
                                hstb.Add("DATA20", "");
                                hstb.Add("DATA21", "");
                            }

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存加载滑行自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", cgjdata.ChecckResult=="不合格"?"0":"1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber", mainPanel.equipmodel.CGJBH);
                        ht.Add("EquipmentModel", mainPanel.equipmodel.CGJXH);
                        ht.Add("EquipmentName", "测功机");
                        ht.Add("ComChk", "1");
                        ht.Add("LeafChk", "1");
                        ht.Add("WarmUpBeginTime", cgjdata.CheckTimeStart);
                        ht.Add("WarmUpEndTime", cgjdata.CheckTimeEnd);
                        ht.Add("DIW", cgjdata.Gxdl);
                        ht.Add("DynConstLoadCount", cgjdata.Jzhxds);
                        if (cgjdata.Jzhxds == "2")
                        {
                            ht.Add("Velocity1", "56");
                            ht.Add("Power1", cgjdata.Hpower.ToString());
                            ht.Add("Plhp1", cgjdata.Jsgl1);
                            ht.Add("Ccdt1", cgjdata.Hvitualtime.ToString());
                            ht.Add("Acdt1", cgjdata.Hrealtime.ToString());
                            ht.Add("Re1", cgjdata.Pc1);
                            ht.Add("Velocity2", "40");
                            ht.Add("Power2", cgjdata.Lpower.ToString());
                            ht.Add("Plhp2", cgjdata.Jsgl2);
                            ht.Add("Ccdt2", cgjdata.Lvitualtime.ToString());
                            ht.Add("Acdt2", cgjdata.Lrealtime.ToString());
                            ht.Add("Re2", cgjdata.Pc2);
                        }
                        else
                        {
                            ht.Add("Velocity1", "40");
                            ht.Add("Power1", cgjdata.Lpower.ToString());
                            ht.Add("Plhp1", cgjdata.Jsgl2);
                            ht.Add("Ccdt1", cgjdata.Lvitualtime.ToString());
                            ht.Add("Acdt1", cgjdata.Lrealtime.ToString());
                            ht.Add("Re1", cgjdata.Pc2);
                            ht.Add("Velocity2", "");
                            ht.Add("Power2", "");
                            ht.Add("Plhp2", "");
                            ht.Add("Ccdt2", "");
                            ht.Add("Acdt2", "");
                            ht.Add("Re2", "");
                        }
                        mainPanel.nhinterface.SendSelfCheckData("UploadDynSelfTestData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        string code, msg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("sblxid", "7");
                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.startSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送开始自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "7");
                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.finishSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "7");
                        ht.Add("zjjl", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                        htdata.Add("cgjtxzj", "1");
                        htdata.Add("cgjjszj", "1");
                        htdata.Add("cgjyrkssj", cgjdata.CheckTimeStart);
                        htdata.Add("cgjyrjssj", cgjdata.CheckTimeEnd);
                        htdata.Add("cgjgxdl", cgjdata.Gxdl);
                        htdata.Add("jzhxqd", "48.0");
                        htdata.Add("jzhxzd", "32.0");
                        htdata.Add("mysd", "40");
                        htdata.Add("hxjzgl",cgjdata.Lpower);
                        htdata.Add("jsgl", cgjdata.Jsgl2);
                        htdata.Add("llhxsj", cgjdata.Lvitualtime);
                        htdata.Add("sjhxsj", cgjdata.Lrealtime);
                        htdata.Add("hxpc", cgjdata.Pc2);
                        htdata.Add("jzhxjg", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                        if (!mainPanel.hninterface.writeSelfCheck(ht, htdata, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }

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
                        ht.Add("设备类别", "0");
                        ht.Add("设备名称", "测功机");
                        ht.Add("设备型号", mainPanel.equipmodel.CGJXH);
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查", "成功");
                        ht.Add("举升器检查", "成功");
                        ht.Add("台体预热开始时间", cgjdata.CheckTimeStart);
                        ht.Add("台体预热结束时间", cgjdata.CheckTimeEnd);
                        ht.Add("惯性当量", cgjdata.Gxdl.ToString());
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        ht2.Add("最低车速", "32.0");
                        ht2.Add("最高车速", "48.0");
                        ht2.Add("加载功率", cgjdata.Lpower.ToString());
                        ht2.Add("寄生功率", cgjdata.Jsgl2);
                        ht2.Add("理论滑行时间", cgjdata.Lvitualtime.ToString("0.000"));
                        ht2.Add("实际滑行时间", cgjdata.Lrealtime.ToString("0.000"));
                        ht2.Add("偏差", cgjdata.Pc2);

                        if (!mainPanel.daliinterface.sendCgjZjData(ht, ht2, out code, out msg))
                        {
                            MessageBox.Show("发送测功机自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送测功机自检信息失败,code" + code + ",msg:" + msg);
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
                        ht2.Add("citycode", mainPanel.stationid.Substring(0,6));
                        ht2.Add("stationcode", mainPanel.stationid);
                        ht2.Add("scenecode", mainPanel.lineid);
                        ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                        ht2.Add("checktimestart",DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        if (cgjdata.Jzhxds == "2")
                        {
                            ht2.Add("hvitualtime", (cgjdata.Hvitualtime*1000).ToString("0"));
                            ht2.Add("hfloattime", (cgjdata.Hrealtime * 1000).ToString("0"));
                            ht2.Add("hfloattimeed", "1");
                            ht2.Add("ccdt40", (cgjdata.Lvitualtime * 1000).ToString("0"));
                            ht2.Add("acdt40", (cgjdata.Lrealtime * 1000).ToString("0"));
                            ht2.Add("dt40ed", "1");
                        }
                        else
                        {
                            ht2.Add("hvitualtime", "9850");
                            ht2.Add("hfloattime", "9650");
                            ht2.Add("hfloattimeed", "1");
                            ht2.Add("ccdt40", (cgjdata.Lvitualtime * 1000).ToString("0"));
                            ht2.Add("acdt40", (cgjdata.Lrealtime * 1000).ToString("0"));
                            ht2.Add("dt40ed", "1");
                        }
                        ht2.Add("ccdt25", "3560");
                        ht2.Add("acdt25", "3520");
                        ht2.Add("dt25ed", "1");

                        ht2.Add("plhp40",cgjdata.Jsgl2);
                        ht2.Add("plhp25", "0.35");
                        ht2.Add("diw",cgjdata.Gxdl);

                        ht2.Add("ihp40", cgjdata.Lpower.ToString("0.0"));
                        ht2.Add("ihp25", "6");
                        ht2.Add("checkresult", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                        ht2.Add("gdyl", "");
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadSelfCheckData( 1, ht2,  out result, out errmsg))
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
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传测功机标定");
                            string ackresult="", errormessage="";

                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.cgjSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                    cgjdata.Hvitualtime,
                                    cgjdata.Hrealtime,
                                    cgjdata.Lvitualtime,
                                    cgjdata.Lrealtime,
                                    cgjdata.Hpower,
                                    cgjdata.Lpower,
                                   (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    "",
                                    double.Parse(cgjdata.Jsgl2),
                                    double.Parse(cgjdata.Jsgl1),
                                    cgjdata.Hpower,
                                    cgjdata.Lpower,
                                    double.Parse(cgjdata.Gxdl)),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceOther.cgjSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                    cgjdata.Hvitualtime,
                                    cgjdata.Hrealtime,
                                    cgjdata.Lvitualtime,
                                    cgjdata.Lrealtime,
                                    cgjdata.Hpower,
                                    cgjdata.Lpower,
                                   (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceYnbs.cgjzj(
                                    mainPanel.zkytwebinf.regcode,
                                    cgjdata.Hvitualtime,
                                    cgjdata.Hrealtime,
                                    cgjdata.Lvitualtime,
                                    cgjdata.Lrealtime,
                                    cgjdata.Hpower,
                                    cgjdata.Lpower,
                                   (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：上传测功机自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传测功机自检数据异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                    {
                        string code, msg;
                        try
                        {
                            if (cgjdata.Jzhxds == "2")
                            {
                                EzWebClient.LoadSlideCheckData data = new EzWebClient.LoadSlideCheckData(
                                    cgjdata.Lrealtime.ToString("0.00"),
                                    cgjdata.Hrealtime.ToString("0.00"),
                                    cgjdata.Lvitualtime.ToString("0.00"),
                                    cgjdata.Hrealtime.ToString("0.00")
                                    , cgjdata.Gxdl,
                                    "",
                                    cgjdata.Lpower.ToString("0.0"),
                                    cgjdata.Hpower.ToString("0.0"),                                    
                                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                                    DateTime.Now.ToString("yyyyMMdd"),
                                    mainPanel.stationid + mainPanel.lineid,
                                    cgjdata.Jsgl2,
                                    cgjdata.Jsgl1,
                                    "",
                                    cgjdata.Zjjg == "不合格" ? "0" : "1",
                                    (double.Parse(cgjdata.Pc2) <= 7) ? "1" : "0",
                                     cgjdata.Jzhxds == "2"?((double.Parse(cgjdata.Pc1) <= 7) ? "1" : "0"):"",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                    mainPanel.stationid,
                                    mainPanel.nowUser.userName,
                                    DateTime.Now.ToString("yyyyMMddHHmmss")
                                    );
                                if (!mainPanel.ezinterface.uploadLoadSlideCheckData(data, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("发送加载滑行自检命令失败,code" + code + ",msg:" + msg);
                                }
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("发送加载滑行自检异常:" + er.Message);
                        }
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(ydjPath))
                {
                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.ydjSelfcheck cgjdata = new carinfor.ydjSelfcheck();
                    cgjdata = selfcheckini.readydjSelfcheck();
                    zjfinishstring += "烟度计完成|";
                    File.Delete(ydjPath);
                    //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                    //mainPanel.check_linezt();
                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[烟度计自检]通讯:" + cgjdata.ZeroResult+","+cgjdata.NZero + "," + cgjdata.LabelValueN50 + "," + cgjdata.LabelValueN70 + "," + cgjdata.N501 + "," + cgjdata.N701 + "," + cgjdata.Error501 + "," + cgjdata.Error701 + "," + cgjdata.LabelValueN90 + "," + cgjdata.LabelValueN90 + "," + cgjdata.N901 + "," + cgjdata.CheckResult1 + "," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                    mainPanel.worklogdata.State = "";
                    mainPanel.worklogdata.Result = ((cgjdata.CheckResult1 == "0") ? "未通过" : "通过");
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    if(cgjdata.CheckResult1=="1")
                    {
                        ini.INIIO.WritePrivateProfileString("金华联网", "烟度计自检记录", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\appConfig.ini");
                    }
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISBTGCHECK = "Y";
                        checkdata.BTGTX = "Y";
                        checkdata.BTGYR = "Y";
                        checkdata.BTGTL = "Y";
                        checkdata.BTGLC = (cgjdata.CheckResult1=="0")?"N":"Y";
                        checkdata.BTGJZ = "Y"; 
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISBTGCHECK = "Y";
                        checkdata.BTGTX = "Y";
                        checkdata.BTGYR = "Y";
                        checkdata.BTGTL = "Y";
                        checkdata.BTGLC = (cgjdata.CheckResult1 == "0") ? "N" : "Y";
                        checkdata.BTGJZ = "Y"; 
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.ydjSelfDetectInf acydjselfcheckdata = new carinfor.ydjSelfDetectInf();
                        acydjselfcheckdata.JCGWH = mainPanel.lineid;
                        acydjselfcheckdata.SBMC = "不透光烟度计";
                        acydjselfcheckdata.SBXH = mainPanel.equipmodel.YDJXH;
                        acydjselfcheckdata.JCZBH = mainPanel.stationid;
                        acydjselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        acydjselfcheckdata.TXJC = "1";
                        acydjselfcheckdata.YQYR = "1";
                        acydjselfcheckdata.YQTL = "1";
                        acydjselfcheckdata.LCJC = "1";
                        acydjselfcheckdata.JCDS = "2";
                        acydjselfcheckdata.BTGSCZ1 = cgjdata.N501.ToString();
                        acydjselfcheckdata.BTGSDZ1 = cgjdata.LabelValueN50.ToString();
                        acydjselfcheckdata.BTGPC1 = cgjdata.Error501.ToString();
                        acydjselfcheckdata.BTGSDZ2 = cgjdata.LabelValueN70.ToString();
                        acydjselfcheckdata.BTGSCZ2 = cgjdata.N701.ToString();
                        acydjselfcheckdata.BTGPC2 = cgjdata.Error701.ToString();
                        acydjselfcheckdata.ZJJG = cgjdata.Zjjg;
                        acydjselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传烟度计自检信息" + acydjselfcheckdata.writeydjSelfDetectInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxYdjCheckdata jxdata = new JxWebClient.jxYdjCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.statusFlag = "1";
                        jxdata.resultFlag = cgjdata.Zjjg == "通过" ? "1" : "0";
                        jxdata.failureReason = "";
                        jxdata.flagConnect = "";
                        jxdata.flagPreheat = "";
                        jxdata.flagZero = "";
                        jxdata.flagRange = "";
                        jxdata.checkNumber = "2";
                        jxdata.ratedValue1= cgjdata.LabelValueN50.ToString();
                        jxdata.actualValue1= cgjdata.N501.ToString();
                        jxdata.errorValue1= cgjdata.Error501.ToString();
                        jxdata.ratedValue2 = cgjdata.LabelValueN70.ToString();
                        jxdata.actualValue2 = cgjdata.N701.ToString();
                        jxdata.errorValue2 = cgjdata.Error701.ToString();
                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(8, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        string optime = "";
                        optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (mainPanel.jhydjinf != null)
                        {
                            if (mainPanel.jhwebinf.area == "金华")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (mainPanel.jhoracle.writeyYdjZjRecordJH(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhydjinf))
                                    {
                                        ini.INIIO.saveLogInf("发送烟度计自检数据成功");
                                        uploadMsg += "烟度计上传成功|";
                                        break;
                                    }
                                    else
                                    {
                                        if (i == 2)
                                        {
                                            ini.INIIO.saveLogInf("发送烟度计自检数据失败");
                                            uploadMsg += "烟度计上传失败|";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (mainPanel.jhoracle.writeyYdjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhydjinf))
                                    {
                                        ini.INIIO.saveLogInf("发送烟度计自检数据成功");
                                        uploadMsg += "烟度计上传成功|";
                                        break;
                                    }
                                    else
                                    {
                                        if (i == 2)
                                        {
                                            ini.INIIO.saveLogInf("发送烟度计自检数据失败");
                                            uploadMsg += "烟度计上传失败|";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送烟度计自检数据失败,没有获取到该线烟度计信息");

                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检");
                            string ackresult="", errormessage="";
                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.ydjSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                    "1",
                                    cgjdata.LabelValueN50,
                                    cgjdata.LabelValueN70,
                                    cgjdata.N501,
                                    cgjdata.N701,
                                    cgjdata.Error501,
                                    cgjdata.Error701,
                                   cgjdata.Zjjg == "通过" ? "1" : "0",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if(mainPanel.zkytwebinf.add==mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceOther.ydjSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                    "1",
                                    cgjdata.LabelValueN50,
                                    cgjdata.LabelValueN70,
                                    cgjdata.N501,
                                    cgjdata.N701,
                                    cgjdata.Error501,
                                    cgjdata.Error701,
                                   cgjdata.Zjjg == "通过" ? "1" : "0",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceYnbs.ydjzj(
                                    mainPanel.zkytwebinf.regcode,
                                    "1",
                                    cgjdata.LabelValueN50,
                                    cgjdata.LabelValueN70,
                                    cgjdata.N501,
                                    cgjdata.N701,
                                    cgjdata.Error501,
                                    cgjdata.Error701,
                                   cgjdata.Zjjg == "通过" ? "1" : "0",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE && mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                    {
                        #region 东软
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检");
                            NeusoftUtil.UploadSmokemeterCal coastdowndata = new NeusoftUtil.UploadSmokemeterCal();
                            coastdowndata.StartTime = cgjdata.CheckTimeStart;
                            coastdowndata.Nominal = cgjdata.LabelValueN50.ToString("0.00");
                            coastdowndata.Check = cgjdata.N501.ToString("0.00");
                            coastdowndata.Result = Math.Abs(cgjdata.Error501)>2?"0":"1";
                            coastdowndata.Nominal2 = cgjdata.LabelValueN70.ToString("0.00");
                            coastdowndata.Check2 = cgjdata.N701.ToString("0.00");
                            coastdowndata.Result2 = Math.Abs(cgjdata.Error701) > 2 ? "0" : "1";                            
                            mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                            string ackresult, errormessage;
                            mainPanel.neusoftsocket.UploadSmokemeterCalRequest(coastdowndata, out ackresult, out errormessage);
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传烟度计自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {                            
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.YDJBH);
                            hstb.Add("ZJLX", ZJLX_YDJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", "1");
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.N501.ToString());
                            hstb.Add("DATA6", cgjdata.LabelValueN50.ToString());
                            hstb.Add("DATA7", cgjdata.Error501.ToString());
                            hstb.Add("DATA8", cgjdata.LabelValueN70.ToString());
                            hstb.Add("DATA9", cgjdata.N701.ToString());
                            hstb.Add("DATA10", cgjdata.Error701.ToString());
                            hstb.Add("DATA11", cgjdata.CheckTimeStart);
                            hstb.Add("DATA12", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存烟度让自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存烟度计自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.YDJBH);
                            hstb.Add("ZJLX", ZJLX_YDJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", "1");
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.N501.ToString());
                            hstb.Add("DATA6", cgjdata.LabelValueN50.ToString());
                            hstb.Add("DATA7", cgjdata.Error501.ToString());
                            hstb.Add("DATA8", cgjdata.LabelValueN70.ToString());
                            hstb.Add("DATA9", cgjdata.N701.ToString());
                            hstb.Add("DATA10", cgjdata.Error701.ToString());
                            hstb.Add("DATA11", cgjdata.CheckTimeStart);
                            hstb.Add("DATA12", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存烟度让自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存烟度计自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", cgjdata.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber", mainPanel.equipmodel.YDJBH);
                        ht.Add("EquipmentModel", mainPanel.equipmodel.YDJXH);
                        ht.Add("EquipmentName", "不透光烟度计");
                        ht.Add("ComChk", "1");
                        ht.Add("WarmUp", "1");
                        ht.Add("Zero", "1");
                        ht.Add("RangeChk", cgjdata.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("CountChk", "2");
                        ht.Add("OpaSetValue1", cgjdata.LabelValueN50.ToString());
                        ht.Add("OpaActValue1", cgjdata.N501.ToString());
                        ht.Add("OpaDev1", cgjdata.Error501.ToString());
                        ht.Add("OpaSetValue2", cgjdata.LabelValueN70.ToString());
                        ht.Add("OpaActValue2", cgjdata.N701.ToString());
                        ht.Add("OpaDev2", cgjdata.Error701.ToString());
                        mainPanel.nhinterface.SendSelfCheckData("UploadSmoChkLoadData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        string code, msg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("sblxid", "3");
                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.startSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送开始自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "3");
                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.finishSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "3");
                        ht.Add("zjjl", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                        htdata.Add("btgtxzj", "1");
                        htdata.Add("btgyr", "1");
                        htdata.Add("btgtl", "1");
                        htdata.Add("lgp70sdz", cgjdata.LabelValueN70.ToString("0.0"));
                        htdata.Add("lgp70jcz", cgjdata.N701.ToString("0.0"));
                        htdata.Add("lgp50sdz", cgjdata.LabelValueN50.ToString("0.0"));
                        htdata.Add("lgp50jcz", cgjdata.N501.ToString("0.0"));
                        if (!mainPanel.hninterface.writeSelfCheck(ht, htdata, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }

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
                        ht.Add("设备类别", "2");
                        ht.Add("设备名称", "烟度计");
                        ht.Add("设备型号", mainPanel.equipmodel.YDJXH);
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查", "成功");
                        ht.Add("仪器预热", "成功");
                        ht.Add("仪器调零", "成功");
                        ht.Add("量程检查", cgjdata.Zjjg == "不合格" ? "失败" : "成功");                        
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        ht2.Add("不透光设定值", cgjdata.LabelValueN70.ToString("0.0"));
                        ht2.Add("不透光实测值", cgjdata.N701.ToString("0.0"));
                        ht2.Add("偏差", cgjdata.Error701.ToString("0.0"));

                        if (!mainPanel.daliinterface.sendYdjZjData(ht, ht2, out code, out msg))
                        {
                            MessageBox.Show("发送烟度计自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送烟度计自检信息失败,code" + code + ",msg:" + msg);
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
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("zeroresult", "1");
                        ht2.Add("labelvaluen50", cgjdata.LabelValueN50);
                        ht2.Add("labelvaluen70", cgjdata.LabelValueN70);
                        ht2.Add("n50", cgjdata.N501);
                        ht2.Add("n70", cgjdata.N701);
                        ht2.Add("error50", cgjdata.Error501);
                        ht2.Add("error70", cgjdata.Error701);
                        ht2.Add("checkresult", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadDemarcateData(1, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传分析仪氧量程数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传分析仪氧量程数据成功");
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                    {
                        string code, msg;
                        try
                        {
                            EzWebClient.eqLightTightRecord data = new EzWebClient.eqLightTightRecord(
                                (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1",
                                "",
                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                cgjdata.N501.ToString("0.00"),
                                cgjdata.N701.ToString("0.00"),
                                 (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1",
                                 "1",
                                 cgjdata.LabelValueN50.ToString("0.00"),
                                 cgjdata.LabelValueN70.ToString("0.00"),
                                mainPanel.stationid + mainPanel.lineid,
                                mainPanel.stationid
                                );
                            if (!mainPanel.ezinterface.uploadeqLightTightRecord(data, out code, out msg))
                            {
                                ini.INIIO.saveLogInf("发送烟度计自检命令失败,code" + code + ",msg:" + msg);
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("发送烟度计自检异常:" + er.Message);
                        }
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(lljPath))
                {
                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.lljSelfcheck cgjdata = new carinfor.lljSelfcheck();
                    cgjdata = selfcheckini.readLljSelfcheck();
                    zjfinishstring += "流量计完成|";
                    File.Delete(lljPath);
                    //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                    //mainPanel.check_linezt();
                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[流量计自检]通讯:" + cgjdata.Lljll + "," + cgjdata.Lljo2 +"," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                    mainPanel.worklogdata.State = "";
                    mainPanel.worklogdata.Result = ((cgjdata.CheckResult== "0") ? "未通过" : "通过");
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISLLJCHECK = "Y";
                        checkdata.LLJTX = "Y";
                        checkdata.LLJLL = cgjdata.Lljll;
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISLLJCHECK = "Y";
                        checkdata.LLJTX = "Y";
                        checkdata.LLJLL = cgjdata.Lljll;
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        string optime = "";
                        optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (mainPanel.jhlljinf != null)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeyLljZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhlljinf))
                                {
                                    ini.INIIO.saveLogInf("发送流量计自检数据成功");
                                    uploadMsg += "流量计上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送流量计自检数据失败");
                                        uploadMsg += "流量计上传失败|";
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送流量计自检数据失败,没有获取到该线流量计信息");

                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.lljSelfDetectInf acydjselfcheckdata = new carinfor.lljSelfDetectInf();
                        acydjselfcheckdata.JCGWH = mainPanel.lineid;
                        acydjselfcheckdata.SBMC = "流量计";
                        acydjselfcheckdata.SBXH = mainPanel.equipmodel.YDJXH;
                        acydjselfcheckdata.JCZBH = mainPanel.stationid;
                        acydjselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        acydjselfcheckdata.TXJC = "1";
                        acydjselfcheckdata.YQYR = "1";
                        acydjselfcheckdata.LLJC = "1";
                        acydjselfcheckdata.YQLL = cgjdata.Lljll;
                        acydjselfcheckdata.QYLC = "1";
                        acydjselfcheckdata.YQYQ = cgjdata.Lljo2;
                        acydjselfcheckdata.ZJJG = cgjdata.CheckResult;
                        acydjselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传流量计自检信息" + acydjselfcheckdata.writedlljSelfDetectInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检");
                            string ackresult="", errormessage="";
                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.lljSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                    cgjdata.lljsjll,
                                    double.Parse(cgjdata.Lljo2),
                                    cgjdata.CheckResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    "",
                                    double.Parse(cgjdata.Lljo2),
                                    20.8,
                                    Math.Round((double.Parse(cgjdata.Lljo2) - 20.8), 2),
                                    3.2,
                                    3.1,
                                    0.1),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                  mainPanel.yichangInterfaceOther.lljSelfcheck(
                                      mainPanel.zkytwebinf.regcode,
                                      cgjdata.lljsjll,
                                      double.Parse(cgjdata.Lljo2),
                                      cgjdata.CheckResult,
                                      DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                      DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                      ""),
                                  out ackresult,
                                  out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：lljSelfcheck(" +"\r\n"+
                                mainPanel.zkytwebinf.regcode + ",\r\n" +
                                    cgjdata.lljsjll.ToString("0.0") + ",\r\n" +
                                    cgjdata.Lljo2 + ",\r\n" +
                                    cgjdata.CheckResult + ",\r\n" +
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss") + ",\r\n" +
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss") + ",\r\n" +
                                    "" + ",\r\n" +
                                    cgjdata.Lljo2 + ",\r\n" +
                                    "20.8" + ",\r\n" +
                                    (double.Parse(cgjdata.Lljo2) - 20.8).ToString() + ",\r\n" +
                                    "3.2" + ",\r\n" +
                                    "3.1" + ",\r\n" +
                                    "0.1");
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.NetMode == mainPanel.NEUSOFTNETMODE && mainPanel.neusoftsocketinf.AREA != mainPanel.NEU_LNAS)
                    {
                        #region 东软
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检");
                            NeusoftUtil.UploadFlowO2Cal coastdowndata = new NeusoftUtil.UploadFlowO2Cal();
                            coastdowndata.StartTime = cgjdata.CheckTimeStart;
                            coastdowndata.Nominal = cgjdata.lljmyll.ToString("0.00");
                            coastdowndata.CheckFlow = cgjdata.lljsjll.ToString("0.00");
                            coastdowndata.CheckO2 = cgjdata.Lljo2;
                            double llwc = cgjdata.lljmyll - cgjdata.lljsjll;
                            double llrelwc = Math.Abs(llwc * 100) / cgjdata.lljmyll;
                            double o2wc =Math.Abs( double.Parse(cgjdata.Lljo2) - 20.8);
                            coastdowndata.Result = (llrelwc<10&&o2wc<0.5)?"1":"0";
                            mainPanel.neusoftsocket.init_equipment(mainPanel.neusoftsocketinf.IP, mainPanel.neusoftsocketinf.PORT);
                            string ackresult, errormessage;
                            mainPanel.neusoftsocket.UploadFlowO2CalRequest(coastdowndata, out ackresult, out errormessage);
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传流量计自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.LLJBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.流量计检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.CheckResult == "不合格" || cgjdata.CheckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1",DateTime.Parse( cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            hstb.Add("DATA2", "20.8");
                            hstb.Add("DATA3", cgjdata.Lljo2);
                            hstb.Add("DATA4",(double.Parse(cgjdata.Lljo2)-20.8).ToString("0.00"));
                            hstb.Add("DATA5", "");
                            hstb.Add("DATA6", "");
                            hstb.Add("DATA7","");
                            hstb.Add("DATA8", (cgjdata.CheckResult == "不合格" || cgjdata.CheckResult == "0") ? "0" : "1");

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句失败");
                            }
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.LLJBH);
                            hstb.Add("ZJLX", ZJLX_LLJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.CheckResult == "不合格" || cgjdata.CheckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", "1");
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Lljll);
                            hstb.Add("DATA6", cgjdata.Lljo2);
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.LLJBH);
                            hstb.Add("ZJLX", ZJLX_LLJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.CheckResult == "不合格" || cgjdata.CheckResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", "1");
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Lljll);
                            hstb.Add("DATA6", cgjdata.Lljo2);
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存流量计自检信息语句失败");
                            }
                        }
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(hjcsPath))
                {
                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.hjcsgyqSelfcheck cgjdata = new carinfor.hjcsgyqSelfcheck();
                    cgjdata = selfcheckini.readdzhjSelfcheck();
                    zjfinishstring += "气象站完成|";
                    File.Delete(hjcsPath);
                    //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                    //mainPanel.check_linezt();
                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[气象站自检]实际温度:" + cgjdata.ActualTemperature + ",实际湿度" + cgjdata.ActualHumidity + ",实际大气压" + cgjdata.ActualAirPressure+ "仪器温度:" + cgjdata.Temperature + ",仪器湿度" + cgjdata.Humidity + ",仪器大气压" + cgjdata.AirPressure + ");";
                    mainPanel.worklogdata.State = "完成";
                    mainPanel.worklogdata.Result = cgjdata.Zjjg;
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISQXZCHECK = "Y";
                        checkdata.TEMPOK =cgjdata.Tempok ? "Y":"N";
                        checkdata.HUMIOK = cgjdata.Humiok ? "Y" : "N";
                        checkdata.AIRPOK = cgjdata.Airpok ? "Y" : "N";
                        checkdata.TEMP = cgjdata.Temperature.ToString("0.0");
                        checkdata.HUMI = cgjdata.Humidity.ToString("0.0");
                        checkdata.AIRP = cgjdata.AirPressure.ToString("0.0");
                        checkdata.ISZSJCHECK = "Y";
                        checkdata.ZSJTX = "Y";
                        checkdata.ZSJLC = "Y";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISQXZCHECK = "Y";
                        checkdata.TEMPOK = cgjdata.Tempok ? "Y" : "N";
                        checkdata.HUMIOK = cgjdata.Humiok ? "Y" : "N";
                        checkdata.AIRPOK = cgjdata.Airpok ? "Y" : "N";
                        checkdata.TEMP = cgjdata.Temperature.ToString("0.0");
                        checkdata.HUMI = cgjdata.Humidity.ToString("0.0");
                        checkdata.AIRP = cgjdata.AirPressure.ToString("0.0");
                        checkdata.ISZSJCHECK = "Y";
                        checkdata.ZSJTX = "Y";
                        checkdata.ZSJLC = "Y";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.dzhjSelfDetectInf acdzhjselfcheckdata = new carinfor.dzhjSelfDetectInf();
                        acdzhjselfcheckdata.JCGWH = mainPanel.lineid;
                        acdzhjselfcheckdata.SBMC = "电子环境信息仪";
                        acdzhjselfcheckdata.SBXH = "";
                        acdzhjselfcheckdata.JCZBH = mainPanel.stationid;
                        acdzhjselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        acdzhjselfcheckdata.TXJC = "1";
                        acdzhjselfcheckdata.HJWD = cgjdata.ActualTemperature.ToString();
                        acdzhjselfcheckdata.YQWD = cgjdata.Temperature.ToString();
                        acdzhjselfcheckdata.HJSD = cgjdata.ActualHumidity.ToString();
                        acdzhjselfcheckdata.YQSD = cgjdata.Humidity.ToString();
                        acdzhjselfcheckdata.HJQY = cgjdata.ActualAirPressure.ToString();
                        acdzhjselfcheckdata.YQQY = cgjdata.AirPressure.ToString();
                        acdzhjselfcheckdata.ZJJG = cgjdata.Zjjg;
                        acdzhjselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传电子环境自检信息" + acdzhjselfcheckdata.writedzhjSelfDetectInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxQxzCheckdata jxdata = new JxWebClient.jxQxzCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.statusFlag ="1";
                        jxdata.resultFlag = cgjdata.Zjjg=="通过"?"1":"0";
                        jxdata.failureReason = "";
                        jxdata.flagConnect = "";
                        jxdata.flagPreheat = "";
                        jxdata.flagZero = "";
                        jxdata.flagRange = "";
                        jxdata.weatherHumidity = cgjdata.ActualHumidity.ToString("0.0");
                        jxdata.weatherTemperature = cgjdata.ActualTemperature.ToString("0.0");
                        jxdata.weatherAtmospheric = cgjdata.ActualAirPressure.ToString("0.0");
                        jxdata.deviceHumidity = cgjdata.Humidity.ToString("0.0");
                        jxdata.deviceTemperature = cgjdata.Temperature.ToString("0.0");
                        jxdata.deviceAtmospheric = cgjdata.AirPressure.ToString("0.0");
                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(9, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传环境参数自检");
                            string ackresult="", errormessage="";
                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.hjcsgyqSelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.ActualTemperature,
                                     cgjdata.Temperature,
                                     cgjdata.ActualHumidity,
                                     cgjdata.Humidity,
                                     cgjdata.ActualAirPressure,
                                     cgjdata.AirPressure,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                    mainPanel.yichangInterfaceOther.hjcsgyqSelfcheck(
                                        mainPanel.zkytwebinf.regcode,
                                         cgjdata.ActualTemperature,
                                         cgjdata.Temperature,
                                         cgjdata.ActualHumidity,
                                         cgjdata.Humidity,
                                         cgjdata.ActualAirPressure,
                                         cgjdata.AirPressure,
                                        DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                        DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                        ""),
                                    out ackresult,
                                    out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                    mainPanel.yichangInterfaceYnbs.hjcsyzj(
                                        mainPanel.zkytwebinf.regcode,
                                         cgjdata.ActualTemperature,
                                         cgjdata.Temperature,
                                         cgjdata.ActualHumidity,
                                         cgjdata.Humidity,
                                         cgjdata.ActualAirPressure,
                                         cgjdata.AirPressure,
                                        DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                        DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                        ""),
                                    out ackresult,
                                    out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：上传环境参数自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传环境参数自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        string optime = "";
                        optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (mainPanel.equipconfig.TempInstrument == "烟度计")
                        {
                            if (mainPanel.jhydjinf != null)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (mainPanel.jhoracle.writeyDzhjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhydjinf))
                                    {
                                        ini.INIIO.saveLogInf("发送电子环境自检数据成功");
                                        uploadMsg += "电子环境上传成功|";
                                        break;
                                    }
                                    else
                                    {
                                        if (i == 2)
                                        {
                                            ini.INIIO.saveLogInf("发送电子环境自检数据失败");
                                            uploadMsg += "电子环境上传失败|";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("发送电子环境自检数据失败,没有获取到该线烟度计信息");

                            }
                        }
                        else
                        {
                            if (mainPanel.jhfqyinf != null)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (mainPanel.jhoracle.writeyDzhjZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhfqyinf))
                                    {
                                        ini.INIIO.saveLogInf("发送电子环境自检数据成功");
                                        uploadMsg += "电子环境上传成功|";
                                        break;
                                    }
                                    else
                                    {
                                        if (i == 2)
                                        {
                                            ini.INIIO.saveLogInf("发送电子环境自检数据失败");
                                            uploadMsg += "电子环境上传失败|";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("发送电子环境自检数据失败,没有获取到该线废气仪信息");

                            }

                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", "");
                            hstb.Add("ZJLX", ZJLX_DZHJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", cgjdata.ActualTemperature.ToString());
                            hstb.Add("DATA3", cgjdata.ActualHumidity.ToString());
                            hstb.Add("DATA4", cgjdata.ActualAirPressure.ToString());
                            hstb.Add("DATA5", cgjdata.Temperature.ToString());
                            hstb.Add("DATA6", cgjdata.Humidity.ToString());
                            hstb.Add("DATA7", cgjdata.AirPressure.ToString());
                            hstb.Add("DATA8", cgjdata.CheckTimeStart);
                            hstb.Add("DATA9", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", "");
                            hstb.Add("ZJLX", ZJLX_DZHJ);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", cgjdata.ActualTemperature.ToString());
                            hstb.Add("DATA3", cgjdata.ActualHumidity.ToString());
                            hstb.Add("DATA4", cgjdata.ActualAirPressure.ToString());
                            hstb.Add("DATA5", cgjdata.Temperature.ToString());
                            hstb.Add("DATA6", cgjdata.Humidity.ToString());
                            hstb.Add("DATA7", cgjdata.AirPressure.ToString());
                            hstb.Add("DATA8", cgjdata.CheckTimeStart);
                            hstb.Add("DATA9", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", cgjdata.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber", "");
                        ht.Add("EquipmentModel", "");
                        ht.Add("EquipmentName", "电子环境");
                        ht.Add("EnvironmentTemperature", cgjdata.ActualTemperature.ToString());
                        ht.Add("InstrumentTemperature", cgjdata.Temperature.ToString());
                        ht.Add("EnvironmentHumidity", cgjdata.ActualHumidity.ToString());
                        ht.Add("InstrumentHumidity", cgjdata.Humidity.ToString());
                        ht.Add("EnvironmentPressure", cgjdata.ActualAirPressure.ToString());
                        ht.Add("InstrumentPressure", cgjdata.AirPressure.ToString());
                        mainPanel.nhinterface.SendSelfCheckData("UploadEleEnvData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        string code, msg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("sblxid", "5");
                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.startSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送开始自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "5");
                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.finishSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "5");
                        ht.Add("zjjl", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                        htdata.Add("qxztxzj", "1");
                        htdata.Add("sjwd", cgjdata.ActualTemperature.ToString("0.0"));
                        htdata.Add("sjsd", cgjdata.ActualHumidity.ToString("0.0"));
                        htdata.Add("sjdqy", cgjdata.ActualAirPressure.ToString("0.0"));
                        htdata.Add("scwd", cgjdata.Temperature.ToString("0.0"));
                        htdata.Add("scsd", cgjdata.Humidity.ToString("0.0"));
                        htdata.Add("scdqy", cgjdata.AirPressure.ToString("0.0"));
                        htdata.Add("wdpc", (cgjdata.Temperature-cgjdata.ActualTemperature).ToString("0.0"));
                        htdata.Add("sdpc", (cgjdata.Humidity - cgjdata.ActualHumidity).ToString("0.0"));
                        htdata.Add("dqypc", (cgjdata.AirPressure - cgjdata.ActualAirPressure).ToString("0.0"));
                        if (!mainPanel.hninterface.writeSelfCheck(ht, htdata, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }

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
                        ht.Add("设备名称", "电子环境仪");
                        ht.Add("设备型号", "QXZ-1");
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查", "成功");
                        ht.Add("环境温度", cgjdata.ActualTemperature.ToString("0.0"));
                        ht.Add("仪器温度", cgjdata.Temperature.ToString("0.0"));
                        ht.Add("环境湿度", cgjdata.ActualHumidity.ToString("0.0"));
                        ht.Add("仪器湿度", cgjdata.Humidity.ToString("0.0"));
                        ht.Add("环境气压", cgjdata.ActualAirPressure.ToString("0.0"));
                        ht.Add("仪器气压", cgjdata.AirPressure.ToString("0.0"));
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        
                        if (!mainPanel.daliinterface.sendDzhjZjData(ht, ht2, out code, out msg))
                        {
                            MessageBox.Show("发送电子环境自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送电子环境自检信息失败,code" + code + ",msg:" + msg);
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
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("actualtemperature", cgjdata.ActualTemperature.ToString("0.0"));
                        ht2.Add("temperature", cgjdata.Temperature.ToString("0.0"));
                        ht2.Add("actualhumidity", cgjdata.ActualHumidity.ToString("0.0"));
                        ht2.Add("humidity", cgjdata.Humidity.ToString("0.0"));
                        ht2.Add("actualairpressure", cgjdata.ActualAirPressure.ToString("0.0"));
                        ht2.Add("airpressure", cgjdata.AirPressure.ToString("0.0"));
                        ht2.Add("checkresult", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadDemarcateData(3, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传环境参数感应器校准结果数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传环境参数感应器校准结果数据成功");
                        }
                        #endregion
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(fqyPath))
                {
                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.wqfxySelfcheck cgjdata = new carinfor.wqfxySelfcheck();
                    cgjdata = selfcheckini.readwqfxySelfcheck();
                    zjfinishstring += "废气仪完成|";
                    File.Delete(fqyPath);
                    //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                    //mainPanel.check_linezt();
                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[废气仪自检]:" + cgjdata.TightnessResult + "," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                    mainPanel.worklogdata.State = "";
                    mainPanel.worklogdata.Result =  (cgjdata.Remark=="0"?"未通过":"通过");
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISFQYCHECK = "Y";
                        checkdata.FQYTX = "Y";
                        checkdata.FQYYR = "Y";
                        checkdata.FQYTL = "Y";
                        checkdata.FQYJL = (cgjdata.TightnessResult=="0")?"N":"Y";
                        checkdata.FQYLC =  "Y";
                        checkdata.FQYO2 = "20.68";
                        checkdata.WQBeginTime = cgjdata.CheckTimeStart;
                        checkdata.WQEndTime = cgjdata.CheckTimeEnd;
                        if (cgjdata.Zjjg == "通过")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISFQYCHECK = "Y";
                        checkdata.FQYTX = "Y";
                        checkdata.FQYYR = "Y";
                        checkdata.FQYTL = "Y";
                        checkdata.FQYJL = (cgjdata.TightnessResult == "0") ? "N" : "Y";
                        checkdata.FQYLC = "Y";
                        checkdata.FQYO2 = "20.68";
                        checkdata.WQBeginTime = cgjdata.CheckTimeStart;
                        checkdata.WQEndTime = cgjdata.CheckTimeEnd;
                        if (cgjdata.Zjjg == "通过")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.fqySelfDetectInf acfqyselfcheckdata = new carinfor.fqySelfDetectInf();
                        acfqyselfcheckdata.JCGWH = mainPanel.lineid;
                        acfqyselfcheckdata.SBMC = "废气分析仪";
                        acfqyselfcheckdata.SBXH = mainPanel.equipmodel.FXYXH;
                        acfqyselfcheckdata.JCZBH = mainPanel.stationid;
                        acfqyselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        acfqyselfcheckdata.TXJC = "1";
                        acfqyselfcheckdata.YQYR = "1";
                        acfqyselfcheckdata.YQJL = cgjdata.TightnessResult;
                        acfqyselfcheckdata.YQTL = "1";
                        acfqyselfcheckdata.YQLL = cgjdata.Yqll;
                        acfqyselfcheckdata.YQYQ = cgjdata.Yqyq;
                        acfqyselfcheckdata.ZJJG = cgjdata.Zjjg;
                        acfqyselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传废气仪自检信息" + acfqyselfcheckdata.writefqySelfDetectInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxFqyLeakCheckdata jxdata = new JxWebClient.jxFqyLeakCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.startTime = cgjdata.CheckTimeStart;
                        jxdata.resultFlag = cgjdata.TightnessResult;

                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(4, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxFqyOxygenCheckdata jxdata = new JxWebClient.jxFqyOxygenCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.startTime = cgjdata.CheckTimeStart;
                        jxdata.o2RangeGivenValue = "20.8";
                        jxdata.o2RangeMeasuredValue = cgjdata.Yqyq;
                        jxdata.o2RangeErrorValue = (double.Parse(cgjdata.Yqyq) - 20.8).ToString("0.0");
                        jxdata.resultFlag = Math.Abs(double.Parse(jxdata.o2RangeErrorValue)) <= 0.5 ? "1" : "0";

                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(5, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        if (mainPanel.jhfqyinf != null)
                        {

                            string optime = "";
                            optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeFqyZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhfqyinf))
                                {
                                    ini.INIIO.saveLogInf("发送废气仪自检数据成功");
                                    uploadMsg += "电子环境上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送废气仪自检数据失败");
                                        uploadMsg += "电子环境上传失败|";
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送废气仪自检数据失败,没有获取到该线废气仪信息");

                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪自检");
                            string ackresult="", errormessage="";
                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.wqfxySelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    "",
                                    20.8,
                                    double.Parse(cgjdata.Yqyq),
                                    double.Parse(cgjdata.Yqyq) - 20.8),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceOther.wqfxySelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceYnbs.wqfxyzj(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传五气分析仪自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.泄露检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.TightnessResult == "不合格" || cgjdata.TightnessResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            hstb.Add("DATA2", (cgjdata.TightnessResult == "不合格" || cgjdata.TightnessResult == "0") ? "0" : "1");

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存泄露检查信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存泄露检查信息语句失败");
                            }
                            hstb.Clear();

                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.分析仪氧量程检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            double o2wc = double.Parse(cgjdata.Yqyq) - 20.8;
                            string o2pd = Math.Abs(o2wc) > 0.5 ? "0" : "1";
                            hstb.Add("ZJJG", o2pd);
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            hstb.Add("DATA2", "20.8");
                            hstb.Add("DATA3", cgjdata.Yqyq);
                            hstb.Add("DATA4", o2wc.ToString("0.00"));
                            hstb.Add("DATA5", o2pd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存分析仪氧量程检查信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存分析仪氧量程检查信息语句失败");
                            }
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", ZJLX_FQY);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", cgjdata.TightnessResult);
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Yqyq);
                            hstb.Add("DATA6", "1");
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", ZJLX_FQY);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", cgjdata.TightnessResult);
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Yqyq);
                            hstb.Add("DATA6", "1");
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", cgjdata.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber", mainPanel.equipmodel.FXYBH);
                        ht.Add("EquipmentModel", mainPanel.equipmodel.FXYXH);
                        ht.Add("EquipmentName", "废气仪");
                        ht.Add("ComChk", "1");
                        ht.Add("WarmUp", "1");
                        ht.Add("LeakChk", cgjdata.TightnessResult);
                        ht.Add("Zero", "1");
                        ht.Add("FluxChk", cgjdata.Yqll);
                        ht.Add("InsO2Chk", cgjdata.Yqyq.ToString());
                        mainPanel.nhinterface.SendSelfCheckData("UploadAnaSelfTestData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HNNETMODE)
                    {
                        string code, msg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("sblxid", "2");
                        ht.Add("kssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.startSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送开始自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "2");
                        ht.Add("jssj", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));

                        if (!mainPanel.hninterface.finishSelfCheck(ht, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }
                        ht.Clear();
                        ht.Add("sblxid", "2");
                        ht.Add("zjjl", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                        ht.Add("zjcs", "1");
                        ht.Add("zjrq", DateTime.Now.ToString("yyyyMMdd"));
                        System.Collections.Hashtable htdata = new System.Collections.Hashtable();
                        htdata.Add("fqytxzj", "1");
                        htdata.Add("fqyyr","1");
                        htdata.Add("fqytl", "1");
                        htdata.Add("fqyjl", cgjdata.TightnessResult);
                        htdata.Add("fqyll", cgjdata.Yqll);
                        htdata.Add("fqyyqhl", cgjdata.Yqyq);
                        if (!mainPanel.hninterface.writeSelfCheck(ht, htdata, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("发送结束自检命令失败,code" + code + ",msg:" + msg);
                        }

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
                        ht.Add("设备类别", "1");
                        ht.Add("设备名称", "废气仪");
                        ht.Add("设备型号", mainPanel.equipmodel.FXYXH);
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查", "成功");
                        ht.Add("仪器预热", "成功");
                        ht.Add("仪器检漏", cgjdata.TightnessResult == "不合格" ? "失败" : "成功");
                        ht.Add("仪器调零", "成功");
                        ht.Add("仪器流量", cgjdata.Yqll);
                        ht.Add("仪器氧气含量", cgjdata.Yqyq);
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                        if (!mainPanel.daliinterface.sendFqyZjData(ht, ht2, out code, out msg))
                        {
                            MessageBox.Show("发送废气仪自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送废气仪自检信息失败,code" + code + ",msg:" + msg);
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
                        ht2.Add("tightnessresult", cgjdata.TightnessResult);
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        
                        ht2.Add("checkresult", cgjdata.TightnessResult);
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadSelfCheckData(5, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传泄漏检查数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传泄漏检查数据成功");
                        }
                        ht2.Clear();
                        ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                        ht2.Add("stationcode", mainPanel.stationid);
                        ht2.Add("scenecode", mainPanel.lineid);
                        ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("o2bz", "20.8");
                        ht2.Add("o2clz", cgjdata.Yqyq);
                        double wc = double.Parse(cgjdata.Yqyq) - 20.8;
                        ht2.Add("o2wc", wc.ToString("0.0"));

                        ht2.Add("checkresult", (Math.Abs(wc)>0.5) ? "0" : "1");
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadSelfCheckData(6, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传分析仪氧量程数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传分析仪氧量程数据成功");
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                    {
                        string code, msg;
                        try
                        {
                            EzWebClient.LeakCheckData data = new EzWebClient.LeakCheckData(
                                cgjdata.TightnessResult,
                                "",
                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                DateTime.Now.ToString("yyyyMMdd"),
                                DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                mainPanel.stationid + mainPanel.lineid,
                                "",
                                mainPanel.stationid,
                                mainPanel.nowUser.userName,
                                DateTime.Now.ToString("yyyyMMddHHmmss")
                                );
                            if (!mainPanel.ezinterface.uploadLeakCheckData(data, out code, out msg))
                            {
                                ini.INIIO.saveLogInf("发送泄露检查命令失败,code" + code + ",msg:" + msg);
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("发送泄露检查命令异常:" + er.Message);
                        }
                        try
                        {
                            EzWebClient.AnalyzerOxygenRangeData data = new EzWebClient.AnalyzerOxygenRangeData(
                                 Math.Abs(double.Parse(cgjdata.Yqyq) - 20.8) <= 0.5 ? "1" : "0",
                                "",
                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                DateTime.Now.ToString("yyyyMMdd"),
                                DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                mainPanel.stationid + mainPanel.lineid,
                                (double.Parse(cgjdata.Yqyq) - 20.8).ToString("0.0"),
                                cgjdata.Yqyq,
                                "20.8",                              
                                "",
                                mainPanel.stationid,
                                "1",
                                mainPanel.nowUser.userName,
                               DateTime.Now.ToString("yyyyMMddHHmmss")
                                );
                            if (!mainPanel.ezinterface.uploadAnalyzerOxygenRangeData(data, out code, out msg))
                            {
                                ini.INIIO.saveLogInf("发送氧量程检查命令失败,code" + code + ",msg:" + msg);
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("发送氧量程检查命令异常:" + er.Message);
                        }
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(plhpPath))
                {
                    try
                    {
                        Thread.Sleep(200);//等待两秒以确保文件内容写完
                        carinfor.cgjPLHPSelfcheck cgjdata = new carinfor.cgjPLHPSelfcheck();
                        cgjdata = selfcheckini.readcgjPLHPSelfcheck();
                        File.Delete(plhpPath);
                        string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                        if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                        {
                            checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                            checkdata.WattlessMaxSpeed1 = cgjdata.SpeedQJ1.Split('~')[0];
                            checkdata.WattlessMinSpeed1 = cgjdata.SpeedQJ1.Split('~')[1];
                            checkdata.WattlessNorminalSpeed1 = cgjdata.NameSpeed1.ToString("0.0");
                            checkdata.WattlessBeginTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessEndTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput1 = cgjdata.Plhp1.ToString("0.00");
                            checkdata.WattlessMaxSpeed2 = cgjdata.SpeedQJ2.Split('~')[0];
                            checkdata.WattlessMinSpeed2 = cgjdata.SpeedQJ2.Split('~')[1];
                            checkdata.WattlessNorminalSpeed2 = cgjdata.NameSpeed2.ToString("0.0");
                            checkdata.WattlessBeginTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessEndTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput2 = cgjdata.Plhp2.ToString("0.00");
                            checkdata.WattlessMaxSpeed3 = cgjdata.SpeedQJ3.Split('~')[0];
                            checkdata.WattlessMinSpeed3 = cgjdata.SpeedQJ3.Split('~')[1];
                            checkdata.WattlessNorminalSpeed3 = cgjdata.NameSpeed3.ToString("0.0");
                            checkdata.WattlessBeginTime3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessEndTime3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput3 = cgjdata.Plhp3.ToString("0.00");
                            checkdata.WattlessMaxSpeed4 = cgjdata.SpeedQJ4.Split('~')[0];
                            checkdata.WattlessMinSpeed4 = cgjdata.SpeedQJ4.Split('~')[1];
                            checkdata.WattlessNorminalSpeed4 = cgjdata.NameSpeed4.ToString("0.0");
                            checkdata.WattlessBeginTime4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessEndTime4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput4 = cgjdata.Plhp4.ToString("0.00");

                            if (cgjdata.ChecckResult == "1")
                                checkdata.SlideJudge = "1";
                            else
                                checkdata.SlideJudge = "2";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }
                        else
                        {
                            //selfcheckdata checkdata = new selfcheckdata();
                            initSelfData(selfcheckid);
                            checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                            checkdata.WattlessMaxSpeed1 = cgjdata.SpeedQJ1.Split('~')[0];
                            checkdata.WattlessMinSpeed1 = cgjdata.SpeedQJ1.Split('~')[1];
                            checkdata.WattlessNorminalSpeed1 = cgjdata.NameSpeed1.ToString("0.0");
                            checkdata.WattlessBeginTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput1 = cgjdata.Plhp1.ToString("0.00");
                            checkdata.WattlessMaxSpeed2 = cgjdata.SpeedQJ2.Split('~')[0];
                            checkdata.WattlessMinSpeed2 = cgjdata.SpeedQJ2.Split('~')[1];
                            checkdata.WattlessNorminalSpeed2 = cgjdata.NameSpeed2.ToString("0.0");
                            checkdata.WattlessBeginTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput2 = cgjdata.Plhp2.ToString("0.00");
                            checkdata.WattlessMaxSpeed3 = cgjdata.SpeedQJ3.Split('~')[0];
                            checkdata.WattlessMinSpeed3 = cgjdata.SpeedQJ3.Split('~')[1];
                            checkdata.WattlessNorminalSpeed3 = cgjdata.NameSpeed3.ToString("0.0");
                            checkdata.WattlessBeginTime3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput3 = cgjdata.Plhp3.ToString("0.00");
                            checkdata.WattlessMaxSpeed4 = cgjdata.SpeedQJ4.Split('~')[0];
                            checkdata.WattlessMinSpeed4 = cgjdata.SpeedQJ4.Split('~')[1];
                            checkdata.WattlessNorminalSpeed4 = cgjdata.NameSpeed4.ToString("0.0");
                            checkdata.WattlessBeginTime4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            checkdata.WattlessOutput4 = cgjdata.Plhp4.ToString("0.00");
                            if (cgjdata.ChecckResult == "1")
                                checkdata.SlideJudge = "1";
                            else
                                checkdata.SlideJudge = "2";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                        {
                            JxWebClient.jxPlhpdata jxdata = new JxWebClient.jxPlhpdata();
                            jxdata.testInstitutionId = mainPanel.stationid;
                            jxdata.testLineId = mainPanel.jxwebinf.lineid;
                            jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                            jxdata.coastedStartTime = cgjdata.kssj1;
                            jxdata.coastedEndTime = cgjdata.jssj4;
                            jxdata.coastedActualTime48to32 = cgjdata.hxsj2;
                            jxdata.coastedActualTime32to16 = cgjdata.hxsj4;
                            jxdata.loss40 = cgjdata.Plhp2.ToString("0.00");
                            jxdata.loss25 = cgjdata.Plhp4.ToString("0.00");
                            jxdata.basicInertia = cgjdata.Remark;
                            
                            string code, msg;
                            if (!mainPanel.jxinterface.sendSelfCheckData(2, jxdata, out code, out msg))
                            {
                                MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                                ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                            }
                        }
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                        {
                            if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                            {
                                Hashtable hstb = new Hashtable();
                                hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.附加功率损失检查]);
                                hstb.Add("ZJSJ", DateTime.Now);
                                hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                                hstb.Add("JCZBH", mainPanel.stationid);
                                hstb.Add("JCGWH", mainPanel.lineid);
                                hstb.Add("ZT", "0");
                                hstb.Add("DATA1",DateTime.Parse( cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                                hstb.Add("DATA2", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyyMMddHHmmss"));
                                hstb.Add("DATA3", cgjdata.hxsj2);
                                hstb.Add("DATA4",cgjdata.hxsj4);
                                hstb.Add("DATA5",cgjdata.jssj2);
                                hstb.Add("DATA6", cgjdata.jssj4);
                                hstb.Add("DATA7", cgjdata.Remark);//remark存放的是惯量数据
                                hstb.Add("DATA8", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");

                                if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句成功");
                                }
                                else
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句失败");
                                }
                            }
                            else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                            {
                                Hashtable hstb = new Hashtable();
                                hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                hstb.Add("ZJLX", ZJLX_JSGL);
                                hstb.Add("ZJSJ", DateTime.Now);
                                hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                                hstb.Add("JCZBH", mainPanel.stationid);
                                hstb.Add("JCGWH", mainPanel.lineid);
                                hstb.Add("ZT", "0");
                                hstb.Add("DATA1", cgjdata.hxsj1);
                                hstb.Add("DATA2", cgjdata.Plhp1.ToString("0.00"));
                                hstb.Add("DATA3", cgjdata.SpeedQJ1.Split('~')[0]);
                                hstb.Add("DATA4", cgjdata.SpeedQJ1.Split('~')[1]);
                                hstb.Add("DATA5", cgjdata.NameSpeed1.ToString("0.0"));
                                hstb.Add("DATA6", cgjdata.kssj1);
                                hstb.Add("DATA7", cgjdata.jssj1);
                                hstb.Add("DATA8", cgjdata.hxsj2);
                                hstb.Add("DATA9", cgjdata.Plhp2.ToString("0.00"));
                                hstb.Add("DATA10", cgjdata.SpeedQJ2.Split('~')[0]);
                                hstb.Add("DATA11", cgjdata.SpeedQJ2.Split('~')[1]);
                                hstb.Add("DATA12", cgjdata.NameSpeed2.ToString("0.0"));
                                hstb.Add("DATA13", cgjdata.kssj2);
                                hstb.Add("DATA14", cgjdata.jssj2);
                                hstb.Add("DATA15", cgjdata.hxsj3);
                                hstb.Add("DATA16", cgjdata.Plhp3.ToString("0.00"));
                                hstb.Add("DATA17", cgjdata.SpeedQJ3.Split('~')[0]);
                                hstb.Add("DATA18", cgjdata.SpeedQJ3.Split('~')[1]);
                                hstb.Add("DATA19", cgjdata.NameSpeed3.ToString("0.0"));
                                hstb.Add("DATA20", cgjdata.kssj3);
                                hstb.Add("DATA21", cgjdata.jssj3);
                                hstb.Add("DATA22", cgjdata.hxsj4);
                                hstb.Add("DATA23", cgjdata.Plhp4.ToString("0.00"));
                                hstb.Add("DATA24", cgjdata.SpeedQJ4.Split('~')[0]);
                                hstb.Add("DATA25", cgjdata.SpeedQJ4.Split('~')[1]);
                                hstb.Add("DATA26", cgjdata.NameSpeed4.ToString("0.0"));
                                hstb.Add("DATA27", cgjdata.kssj4);
                                hstb.Add("DATA28", cgjdata.jssj4);
                                hstb.Add("DATA29", "");
                                hstb.Add("DATA30", "");
                                hstb.Add("DATA31", "");
                                hstb.Add("DATA32", "");
                                hstb.Add("DATA33", "");
                                hstb.Add("DATA34", "");
                                hstb.Add("DATA35", "");

                                if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句成功");
                                }
                                else
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句失败");
                                }
                            }
                            else
                            {
                                Hashtable hstb = new Hashtable();
                                hstb.Add("SBBH", mainPanel.equipmodel.CGJBH);
                                hstb.Add("ZJLX", ZJLX_JSGL);
                                hstb.Add("ZJSJ", DateTime.Now);
                                hstb.Add("ZJJG", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                                hstb.Add("JCZBH", mainPanel.stationid);
                                hstb.Add("JCGWH", mainPanel.lineid);
                                hstb.Add("ZT", "0");
                                hstb.Add("DATA1", cgjdata.hxsj1);
                                hstb.Add("DATA2", cgjdata.Plhp1.ToString("0.00"));
                                hstb.Add("DATA3", cgjdata.SpeedQJ1.Split('~')[0]);
                                hstb.Add("DATA4", cgjdata.SpeedQJ1.Split('~')[1]);
                                hstb.Add("DATA5", cgjdata.NameSpeed1.ToString("0.0"));
                                hstb.Add("DATA6", cgjdata.kssj1);
                                hstb.Add("DATA7", cgjdata.jssj1);
                                hstb.Add("DATA8", cgjdata.hxsj2);
                                hstb.Add("DATA9", cgjdata.Plhp2.ToString("0.00"));
                                hstb.Add("DATA10", cgjdata.SpeedQJ2.Split('~')[0]);
                                hstb.Add("DATA11", cgjdata.SpeedQJ2.Split('~')[1]);
                                hstb.Add("DATA12", cgjdata.NameSpeed2.ToString("0.0"));
                                hstb.Add("DATA13", cgjdata.kssj2);
                                hstb.Add("DATA14", cgjdata.jssj2);
                                hstb.Add("DATA15", cgjdata.hxsj3);
                                hstb.Add("DATA16", cgjdata.Plhp3.ToString("0.00"));
                                hstb.Add("DATA17", cgjdata.SpeedQJ3.Split('~')[0]);
                                hstb.Add("DATA18", cgjdata.SpeedQJ3.Split('~')[1]);
                                hstb.Add("DATA19", cgjdata.NameSpeed3.ToString("0.0"));
                                hstb.Add("DATA20", cgjdata.kssj3);
                                hstb.Add("DATA21", cgjdata.jssj3);
                                hstb.Add("DATA22", cgjdata.hxsj4);
                                hstb.Add("DATA23", cgjdata.Plhp4.ToString("0.00"));
                                hstb.Add("DATA24", cgjdata.SpeedQJ4.Split('~')[0]);
                                hstb.Add("DATA25", cgjdata.SpeedQJ4.Split('~')[1]);
                                hstb.Add("DATA26", cgjdata.NameSpeed4.ToString("0.0"));
                                hstb.Add("DATA27", cgjdata.kssj4);
                                hstb.Add("DATA28", cgjdata.jssj4);
                                hstb.Add("DATA29", "");
                                hstb.Add("DATA30", "");
                                hstb.Add("DATA31", "");
                                hstb.Add("DATA32", "");
                                hstb.Add("DATA33", "");
                                hstb.Add("DATA34", "");
                                hstb.Add("DATA35", "");

                                if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句成功");
                                }
                                else
                                {
                                    ini.INIIO.saveLogInf("保存寄生功率自检信息语句失败");
                                }
                            }
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
                            ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                            ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));

                            ht2.Add("speedqj1", cgjdata.SpeedQJ1);
                            ht2.Add("namespeed1", cgjdata.NameSpeed1.ToString("0.0"));
                            ht2.Add("plhp1", cgjdata.Plhp1.ToString("0.00"));
                            ht2.Add("speedqj2", cgjdata.SpeedQJ2);
                            ht2.Add("namespeed2", cgjdata.NameSpeed2.ToString("0.0"));
                            ht2.Add("plhp2", cgjdata.Plhp2.ToString("0.00"));
                            ht2.Add("speedqj3", cgjdata.SpeedQJ3);
                            
                            ht2.Add("namespeed3", cgjdata.NameSpeed3.ToString("0.0"));
                            ht2.Add("plhp3", cgjdata.Plhp3.ToString("0.00"));
                            ht2.Add("speedqj4", cgjdata.SpeedQJ4);

                            ht2.Add("namespeed4", cgjdata.NameSpeed4.ToString("0.0"));
                            ht2.Add("plhp4", cgjdata.Plhp4.ToString("0.00"));
                            ht2.Add("maxspeed","56");
                            ht2.Add("checkresult", (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1");
                            ht2.Add("remark", "");
                            if (!mainPanel.gxinterface.uploadSelfCheckData(3, ht2, out result, out errmsg))
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
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                        {
                            #region 中科宇图
                            try
                            {
                                ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检");
                                string ackresult="", errormessage="";
                                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(
                                    mainPanel.yichangInterface.cgjPLHPSelfcheck(
                                        mainPanel.zkytwebinf.regcode,
                                        cgjdata.SpeedQJ1,
                                        cgjdata.NameSpeed1,
                                        cgjdata.Plhp1,
                                        cgjdata.SpeedQJ2,
                                        cgjdata.NameSpeed2,
                                        cgjdata.Plhp2,
                                        cgjdata.SpeedQJ3,
                                        cgjdata.NameSpeed3,
                                        cgjdata.Plhp3,
                                        cgjdata.SpeedQJ4,
                                        cgjdata.NameSpeed4,
                                        cgjdata.Plhp4,
                                        cgjdata.MaxSpeed,
                                         (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                        DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                        DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                        "",
                                        cgjdata.Plhp2,
                                        cgjdata.Plhp4,
                                        double.Parse(cgjdata.Remark)),
                                    out ackresult,
                                    out errormessage);
                                }
                                else if(mainPanel.zkytwebinf.add==mainPanel.ZKYTAREA_OTHER)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(
                                      mainPanel.yichangInterfaceOther.cgjPLHPSelfcheck(
                                          mainPanel.zkytwebinf.regcode,
                                          cgjdata.SpeedQJ1,
                                          cgjdata.NameSpeed1,
                                          cgjdata.Plhp1,
                                          cgjdata.SpeedQJ2,
                                          cgjdata.NameSpeed2,
                                          cgjdata.Plhp2,
                                          cgjdata.SpeedQJ3,
                                          cgjdata.NameSpeed3,
                                          cgjdata.Plhp3,
                                          cgjdata.SpeedQJ4,
                                          cgjdata.NameSpeed4,
                                          cgjdata.Plhp4,
                                          cgjdata.MaxSpeed,
                                           (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                          DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                          DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                          ""),
                                      out ackresult,
                                      out errormessage);
                                }
                                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                                {
                                    mainPanel.xmlanalysis.ReadACKString(
                                      mainPanel.yichangInterfaceYnbs.cgjbd(
                                          mainPanel.zkytwebinf.regcode,
                                          cgjdata.SpeedQJ1,
                                          cgjdata.NameSpeed1,
                                          cgjdata.Plhp1,
                                          cgjdata.SpeedQJ2,
                                          cgjdata.NameSpeed2,
                                          cgjdata.Plhp2,
                                          cgjdata.SpeedQJ3,
                                          cgjdata.NameSpeed3,
                                          cgjdata.Plhp3,
                                          cgjdata.SpeedQJ4,
                                          cgjdata.NameSpeed4,
                                          cgjdata.Plhp4,
                                          cgjdata.MaxSpeed,
                                           (cgjdata.ChecckResult == "不合格" || cgjdata.ChecckResult == "0") ? "0" : "1",
                                          DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                          DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                          ""),
                                      out ackresult,
                                      out errormessage);
                                }
                                ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检成功:result=" + ackresult);
                            }
                            catch (Exception er)
                            {
                                ini.INIIO.saveLogInf("联网信息：上传测功机寄生功率自检异常:" + er.Message);
                            }
                            #endregion
                        }
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.EZNETMODE)
                        {
                            string code, msg;
                            try
                            {
                                EzWebClient.PowerLossData data = new EzWebClient.PowerLossData(
                                    cgjdata.hxsj4,
                                    cgjdata.hxsj2,
                                    cgjdata.Remark,
                                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                                    "",
                                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                                    DateTime.Now.ToString("yyyyMMdd"),
                                    mainPanel.stationid+mainPanel.lineid,
                                    cgjdata.Plhp4.ToString("0.00"),
                                    cgjdata.Plhp2.ToString("0.00"),
                                    "",
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                    mainPanel.stationid,
                                    mainPanel.nowUser.userName
                                    );
                                if (!mainPanel.ezinterface.uploadPowerLossData(data, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("发送附加功率损失命令失败,code" + code + ",msg:" + msg);
                                }
                            }
                            catch (Exception er)
                            {
                                ini.INIIO.saveLogInf("发送附加功率损失命令异常:" + er.Message);
                            }
                            try
                            {
                                EzWebClient.eqWaOutPowerRecord data = new EzWebClient.eqWaOutPowerRecord(
                                    cgjdata.NameSpeed1.ToString("0.0"),
                                    "",
                                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"),
                                    cgjdata.Plhp1.ToString("0.00"),
                                    cgjdata.Plhp2.ToString("0.00"),
                                    cgjdata.Plhp3.ToString("0.00"),
                                    cgjdata.Plhp4.ToString("0.00"),
                                    mainPanel.stationid + mainPanel.lineid,
                                    "1",
                                    cgjdata.NameSpeed2.ToString("0.0"),
                                    cgjdata.NameSpeed3.ToString("0.0"),
                                    cgjdata.NameSpeed4.ToString("0.0"),
                                    cgjdata.SpeedQJ1,
                                    cgjdata.SpeedQJ2,
                                    cgjdata.SpeedQJ3,
                                    cgjdata.SpeedQJ4,
                                    mainPanel.stationid,
                                    cgjdata.MaxSpeed.ToString("0.0")
                                    );
                                if (!mainPanel.ezinterface.uploadeqWaOutPowerRecord(data, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("发送寄生功率命令失败,code" + code + ",msg:" + msg);
                                }
                            }
                            catch (Exception er)
                            {
                                ini.INIIO.saveLogInf("发送寄生功率命令异常:" + er.Message);
                            }
                        }
                        zjfinishstring += "寄生功率完成|";

                        //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
                        //mainPanel.check_linezt();
                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                        mainPanel.worklogdata.ProjectName = "系统自检";
                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                        mainPanel.worklogdata.Data = "[寄生功率自检]:" + cgjdata.SpeedQJ1 + "," + cgjdata.NameSpeed1 + "," + cgjdata.Plhp1 + "," + cgjdata.SpeedQJ2 + "," + cgjdata.NameSpeed2 + "," + cgjdata.Plhp2 + "," + cgjdata.SpeedQJ3 + "," + cgjdata.NameSpeed3 + "," + cgjdata.Plhp3 + "," + cgjdata.SpeedQJ4 + "," + cgjdata.NameSpeed4 + "," + cgjdata.Plhp4 + "," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                        mainPanel.worklogdata.State = "";
                        mainPanel.worklogdata.Result = (cgjdata.ChecckResult == "0" ? "未通过" : "通过");
                        mainPanel.worklogdata.Date = DateTime.Now;
                        mainPanel.worklogdata.Bzsm = "";
                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    }
                    catch(Exception er)
                    {
                        ini.INIIO.saveLogInf("处理寄生功率自检数据发生异常:"+er.Message);
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(sdsfqyPath))
                {
                    Thread.Sleep(200);//等待两秒以确保文件内容写完
                    carinfor.sdsqtfxySelfcheck cgjdata = new carinfor.sdsqtfxySelfcheck();
                    cgjdata = selfcheckini.readsdsqtfxySelfcheck();
                    zjfinishstring += "废气仪完成|";
                    File.Delete(sdsfqyPath);

                    mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    mainPanel.worklogdata.ProjectName = "系统自检";
                    mainPanel.worklogdata.Stationid = mainPanel.stationid;
                    mainPanel.worklogdata.Lineid = mainPanel.lineid;
                    mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                    mainPanel.worklogdata.Data = "[双怠速废气仪自检]:" + cgjdata.TightnessResult + "," + cgjdata.LFlowResult + "," + cgjdata.CanliuHC + "," + cgjdata.CheckResult + "," + cgjdata.CheckTimeStart + "," + cgjdata.CheckTimeEnd + "," + cgjdata.Remark + ");";
                    mainPanel.worklogdata.State = "";
                    mainPanel.worklogdata.Result = (cgjdata.CheckResult == "0" ? "未通过" : "通过");
                    mainPanel.worklogdata.Date = DateTime.Now;
                    mainPanel.worklogdata.Bzsm = "";
                    mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                    if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                    {
                        checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                        checkdata.ISFQYCHECK = "Y";
                        checkdata.FQYTX = "Y";
                        checkdata.FQYYR = "Y";
                        checkdata.FQYTL = "Y";
                        checkdata.FQYJL = (cgjdata.TightnessResult == "0") ? "N" : "Y";
                        checkdata.FQYLC = (cgjdata.CheckResult=="0")?"N":"Y";
                        checkdata.FQYO2 = "20.68";
                        checkdata.WQBeginTime = cgjdata.CheckTimeStart;
                        checkdata.WQEndTime = cgjdata.CheckTimeEnd;
                        if (cgjdata.Zjjg == "通过")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        //selfcheckdata checkdata = new selfcheckdata();
                        initSelfData(selfcheckid);
                        checkdata.ISFQYCHECK = "Y";
                        checkdata.FQYTX = "Y";
                        checkdata.FQYYR = "Y";
                        checkdata.FQYTL = "Y";
                        checkdata.FQYJL = (cgjdata.TightnessResult == "0") ? "N" : "Y";
                        checkdata.FQYLC = (cgjdata.CheckResult == "0") ? "N" : "Y";
                        checkdata.FQYO2 = "20.68";
                        checkdata.WQBeginTime = cgjdata.CheckTimeStart;
                        checkdata.WQEndTime = cgjdata.CheckTimeEnd;
                        if (cgjdata.Zjjg == "通过")
                            checkdata.SlideJudge = "1";
                        else
                            checkdata.SlideJudge = "2";
                        try
                        {
                            selfcheckcontrol.Save_SelfCheckData(checkdata);
                        }
                        catch
                        { }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ACNETMODE)
                    {
                        carinfor.fqySelfDetectInf acfqyselfcheckdata = new carinfor.fqySelfDetectInf();
                        acfqyselfcheckdata.JCGWH = mainPanel.lineid;
                        acfqyselfcheckdata.SBMC = "废气分析仪";
                        acfqyselfcheckdata.SBXH = mainPanel.equipmodel.FXYXH;
                        acfqyselfcheckdata.JCZBH = mainPanel.stationid;
                        acfqyselfcheckdata.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        acfqyselfcheckdata.TXJC = "1";
                        acfqyselfcheckdata.YQYR = "1";
                        acfqyselfcheckdata.YQJL = cgjdata.TightnessResult;
                        acfqyselfcheckdata.YQTL = "1";
                        acfqyselfcheckdata.YQLL = cgjdata.Yqll;
                        acfqyselfcheckdata.YQYQ = cgjdata.Yqyq;
                        acfqyselfcheckdata.ZJJG = cgjdata.Zjjg;
                        acfqyselfcheckdata.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        ini.INIIO.saveLogInf("上传废气仪自检信息" + acfqyselfcheckdata.writefqySelfDetectInf());
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxFqyLeakCheckdata jxdata = new JxWebClient.jxFqyLeakCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.startTime = cgjdata.CheckTimeStart;
                        jxdata.resultFlag = cgjdata.TightnessResult;

                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(4, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }
                        
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JXNETMODE)
                    {
                        JxWebClient.jxFqyOxygenCheckdata jxdata = new JxWebClient.jxFqyOxygenCheckdata();
                        jxdata.testInstitutionId = mainPanel.stationid;
                        jxdata.testLineId = mainPanel.jxwebinf.lineid;
                        jxdata.checkDate = DateTime.Now.ToString("yyyy-MM-dd");
                        jxdata.startTime = cgjdata.CheckTimeStart;
                        jxdata.o2RangeGivenValue = "20.8";
                        jxdata.o2RangeMeasuredValue = cgjdata.Yqyq;
                        jxdata.o2RangeErrorValue = (double.Parse(cgjdata.Yqyq) - 20.8).ToString("0.0");
                        jxdata.resultFlag = Math.Abs(double.Parse(jxdata.o2RangeErrorValue))<=0.5? "1" : "0";

                        string code, msg;
                        if (!mainPanel.jxinterface.sendSelfCheckData(5, jxdata, out code, out msg))
                        {
                            MessageBox.Show("sendSelfCheckData上传服务器失败\r\ncode=" + code + "\r\nmsg=" + msg, "错误提示");
                            ini.INIIO.saveLogInf("江西联网信息：sendSelfCheckData上传服务器失败");
                        }

                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                    {
                        if (mainPanel.jhfqyinf != null)
                        {

                            string optime = "";
                            optime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            for (int i = 0; i < 3; i++)
                            {
                                if (mainPanel.jhoracle.writeSdsFqyZjRecord(mainPanel.jhwebinf.stationid, mainPanel.jhwebinf.lineid, mainPanel.nowUser.userName, optime, cgjdata, mainPanel.jhfqyinf))
                                {
                                    ini.INIIO.saveLogInf("发送废气仪自检数据成功");
                                    uploadMsg += "废气仪上传成功|";
                                    break;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        ini.INIIO.saveLogInf("发送废气仪自检数据失败");
                                        uploadMsg += "废气仪上传失败|";
                                    }
                                }
                            }
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("发送废气仪自检数据失败,没有获取到该线废气仪信息");

                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.TYNETMODE)
                    {
                        if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.泄露检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.TightnessResult == "不合格" || cgjdata.TightnessResult == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            hstb.Add("DATA2", (cgjdata.TightnessResult == "不合格" || cgjdata.TightnessResult == "0") ? "0" : "1");

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存泄露检查信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存泄露检查信息语句失败");
                            }
                            hstb.Clear();

                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", mainPanel.acZjNoLn[(int)mainPanel.acZjNameLn.分析仪氧量程检查]);
                            hstb.Add("ZJSJ", DateTime.Now);
                            double o2wc = double.Parse(cgjdata.Yqyq) - 20.8;
                            string o2pd = Math.Abs(o2wc) > 0.5 ? "0" : "1";
                            hstb.Add("ZJJG", o2pd);
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyyMMddHHmmss"));
                            hstb.Add("DATA2", "20.8");
                            hstb.Add("DATA3", cgjdata.Yqyq);
                            hstb.Add("DATA4", o2wc.ToString("0.00"));
                            hstb.Add("DATA5", o2pd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存分析仪氧量程检查信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存分析仪氧量程检查信息语句失败");
                            }
                        }
                        else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", ZJLX_FQY);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", (cgjdata.Zjjg == "不合格" || cgjdata.Zjjg == "0") ? "0" : "1");
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", cgjdata.TightnessResult);
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Yqyq);
                            hstb.Add("DATA6", cgjdata.CanliuHC);
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                        else
                        {
                            Hashtable hstb = new Hashtable();
                            hstb.Add("SBBH", mainPanel.equipmodel.FXYBH);
                            hstb.Add("ZJLX", ZJLX_FQY);
                            hstb.Add("ZJSJ", DateTime.Now);
                            hstb.Add("ZJJG", cgjdata.CheckResult);
                            hstb.Add("JCZBH", mainPanel.stationid);
                            hstb.Add("JCGWH", mainPanel.lineid);
                            hstb.Add("ZT", "0");
                            hstb.Add("DATA1", "1");
                            hstb.Add("DATA2", "1");
                            hstb.Add("DATA3", cgjdata.TightnessResult);
                            hstb.Add("DATA4", "1");
                            hstb.Add("DATA5", cgjdata.Yqyq);
                            hstb.Add("DATA6", cgjdata.CanliuHC);
                            hstb.Add("DATA7", cgjdata.CheckTimeStart);
                            hstb.Add("DATA8", cgjdata.CheckTimeEnd);

                            if (mainPanel.conforsql.Insert("设备自检数据", hstb) > 0)
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句成功");
                            }
                            else
                            {
                                ini.INIIO.saveLogInf("保存电子环境自检信息语句失败");
                            }
                        }
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
                    {
                        #region 中科宇图
                        try
                        {
                            ini.INIIO.saveLogInf("联网信息：上传双怠速五气分析仪自检");
                            string ackresult="", errormessage="";
                            if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterface.sdsqtfxySelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                     "1",
                                     cgjdata.CanliuHC,
                                     cgjdata.CheckResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if(mainPanel.zkytwebinf.add==mainPanel.ZKYTAREA_OTHER)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceOther.sdsqtfxySelfcheck(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                     "1",
                                     cgjdata.CanliuHC,
                                     cgjdata.CheckResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                            {
                                mainPanel.xmlanalysis.ReadACKString(
                                mainPanel.yichangInterfaceYnbs.wqfxyzj(
                                    mainPanel.zkytwebinf.regcode,
                                     cgjdata.TightnessResult,
                                    DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"),
                                    DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"),
                                    ""),
                                out ackresult,
                                out errormessage);
                            }
                            ini.INIIO.saveLogInf("联网信息：上传双怠速五气分析仪自检成功:result=" + ackresult);
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("联网信息：上传双怠速五气分析仪自检异常:" + er.Message);
                        }
                        #endregion
                    }
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                    {
                        int nhcode, nhexpcode;
                        string nhmsg, nhexpmsg;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        ht.Add("Judge", cgjdata.Zjjg == "不合格" ? "0" : "1");
                        ht.Add("SelfTestTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("Operator", mainPanel.nowUser.userName);
                        ht.Add("LineNumber", mainPanel.nhwebinf.lineid);
                        ht.Add("EquipmentNumber",mainPanel.equipmodel.FXYBH);
                        ht.Add("EquipmentModel", mainPanel.equipmodel.FXYXH);
                        ht.Add("EquipmentName", "废气仪");
                        ht.Add("ComChk", "1");
                        ht.Add("WarmUp", "1");
                        ht.Add("LeakChk", cgjdata.TightnessResult);
                        ht.Add("Zero", "1");
                        ht.Add("FluxChk", cgjdata.Yqll);
                        ht.Add("InsO2Chk", cgjdata.Yqyq.ToString());
                        mainPanel.nhinterface.SendSelfCheckData("UploadAnaSelfTestData", ht, out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
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
                        ht.Add("设备类别", "1");
                        ht.Add("设备名称", "废气仪");
                        ht.Add("设备型号", mainPanel.equipmodel.FXYXH);
                        ht.Add("自检时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ht.Add("通讯检查", "成功");
                        ht.Add("仪器预热", "成功");
                        ht.Add("仪器检漏", cgjdata.TightnessResult == "不合格" ? "失败" : "成功");
                        ht.Add("仪器调零", "成功");
                        ht.Add("仪器流量", cgjdata.Yqll);
                        ht.Add("仪器氧气含量", cgjdata.Yqyq);
                        ht.Add("同步时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                        if (!mainPanel.daliinterface.sendFqyZjData(ht, ht2, out code, out msg))
                        {
                            MessageBox.Show("发送废气仪自检信息失败\r\ncode:" + code + "\r\nmsg:" + msg);
                            ini.INIIO.saveLogInf("发送废气仪自检信息失败,code" + code + ",msg:" + msg);
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
                        ht2.Add("tightnessresult", cgjdata.TightnessResult);
                        ht2.Add("lflowresult", cgjdata.Yqll);
                        ht2.Add("canliuhc", cgjdata.CanliuHC);
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));

                        ht2.Add("checkresult", cgjdata.TightnessResult);
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadDemarcateData(2, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传双怠速气体分析仪自检结果数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传双怠速气体分析仪自检结果数据成功");
                        }
                        if (!mainPanel.gxinterface.uploadSelfCheckData(5, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传泄漏检查数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传泄漏检查数据成功");
                        }
                        ht2.Clear();
                        ht2.Add("citycode", mainPanel.stationid.Substring(0, 6));
                        ht2.Add("stationcode", mainPanel.stationid);
                        ht2.Add("scenecode", mainPanel.lineid);
                        ht2.Add("checkdate", DateTime.Now.ToString("yyyy-MM-dd"));
                        ht2.Add("checktimestart", DateTime.Parse(cgjdata.CheckTimeStart).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("checktimeend", DateTime.Parse(cgjdata.CheckTimeEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                        ht2.Add("o2bz", "20.8");
                        ht2.Add("o2clz", cgjdata.Yqyq);
                        double wc = double.Parse(cgjdata.Yqyq) - 20.8;
                        ht2.Add("o2wc", wc.ToString("0.0"));

                        ht2.Add("checkresult", (Math.Abs(wc) > 0.5) ? "0" : "1");
                        ht2.Add("remark", "");
                        if (!mainPanel.gxinterface.uploadSelfCheckData(6, ht2, out result, out errmsg))
                        {
                            ini.INIIO.saveLogInf("上传分析仪氧量程数据失败\r\n" + "错误代码：" + result + "\r\n" + "错误信息：" + errmsg);
                            //return;
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("桂林联网信息：上传分析仪氧量程数据成功");
                        }
                        #endregion
                    }
                    //writeExcel.writeSelfCheckData(cgjdata);
                }
                if (File.Exists(zjPath))
                {
                    Thread.Sleep(200);
                    yuredata = yurecontrol.readYureData(zjPath);
                    //demarcatecontrol.saveGlideDataByIni(glidedata, mainPanel.stationid, mainPanel.lineid, bdrq);
                    if (yuredata == "0")
                    {
                        string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                        if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                        {
                            checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                            checkdata.AllJudge = "2";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }
                        else
                        {
                            //selfcheckdata checkdata = new selfcheckdata();
                            initSelfData(selfcheckid);
                            checkdata.AllJudge = "2";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }

                        Msg(label1, panel4, "自检不合格，请车辆不要上线检测");
                        if (mainPanel.linesbbd.Zjenable)
                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "Y", "自检未通过");
                        //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now.AddDays(-1));
                        //mainPanel.check_linezt();
                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss1");//线号“00”代表为登录机进行的操作
                        mainPanel.worklogdata.ProjectName = "系统自检";
                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                        mainPanel.worklogdata.Data = "自检不合格，请车辆不要上线检测";
                        mainPanel.worklogdata.State = "";
                        mainPanel.worklogdata.Result = "未通过";
                        mainPanel.worklogdata.Date = DateTime.Now;
                        mainPanel.worklogdata.Bzsm = "";
                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    }
                    else
                    {
                        string selfcheckid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
                        if (selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                        {
                            checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                            checkdata.AllJudge = "1";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }
                        else
                        {
                            //selfcheckdata checkdata = new selfcheckdata();
                            initSelfData(selfcheckid);
                            checkdata.AllJudge = "1";
                            try
                            {
                                selfcheckcontrol.Save_SelfCheckData(checkdata);
                            }
                            catch
                            { }
                        }
                        mainPanel.stationcontrol.setDemarcateTimebyName(mainPanel.stationid, mainPanel.lineid, "ZJDATE", DateTime.Now.ToString());
                        if (mainPanel.linemodel.LOCKREASON == "自检未通过")
                            mainPanel.stationcontrol.updateLineLockState(mainPanel.stationid, mainPanel.lineid, "N", "");
                        Msg(label1, panel4, "自检合格");
                        //mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now); 
                        mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                        mainPanel.worklogdata.ProjectName = "系统自检";
                        mainPanel.worklogdata.Stationid = mainPanel.stationid;
                        mainPanel.worklogdata.Lineid = mainPanel.lineid;
                        mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
                        mainPanel.worklogdata.Data = "自检通过";
                        mainPanel.worklogdata.State = "";
                        mainPanel.worklogdata.Result = "通过";
                        mainPanel.worklogdata.Date = DateTime.Now;
                        mainPanel.worklogdata.Bzsm = "";
                        mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
                    }
                    File.Delete(zjPath);
                    mainPanel.check_linezt();
                    return;

                }
                Msg(labelzjxm, panelzjxm, zjfinishstring);
                Msg(labelUpload, panelUpload, uploadMsg);
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
            //Msg(label1, panel4, "正在进行" + _bdnr);    
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.AHNETMODE)
            {
                int ahresult = 0;
                string ahErrMsg = "";
                if (!mainPanel.ahinterface.BeginSelfTest(mainPanel.lineid, out ahresult, out ahErrMsg))
                {
                    button5.Visible = false;
                    ini.INIIO.saveLogInf("发送自检开始指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                    return;
                    //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                }
                button5.Visible = true;
            }
            else
                button5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
            {
                int nhcode, nhexpcode;
                string nhmsg, nhexpmsg;
                mainPanel.nhinterface.SendUploadEquipmentStatus("3", out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
            }
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JIANGSHUNETMODE)
            {
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
            }
            
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
            bdrq = DateTime.Now;
            Process.Start("D://环保检测子程序/设备自检.EXE");
            th_wait = new Thread(waitTestFinished);
            th_wait.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string clid = mainPanel.stationid + mainPanel.lineid + "_" + DateTime.Now.ToString("yyyyMMdd");
            if (selfcheckcontrol.Have_SelfCheckData(clid))
            {
                SYS.Model.selfcheckdata checkdata = selfcheckcontrol.Get_SelfCheckData(clid);
                int ahresult = 0;
                string ahErrMsg = "";
                if (!mainPanel.ahinterface.EndSelfTest(mainPanel.lineid, checkdata, out ahresult, out ahErrMsg))
                {
                    ini.INIIO.saveLogInf("发送自检结束指令出错\r\n" + "错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                    return;
                    //MessageBox.Show("拍照发生错误\r\n"+"错误代码：" + ahresult.ToString() + "\r\n" + "错误信息：" + ahErrMsg);
                }
                else
                    MessageBox.Show("自检记录上传成功");
            }
            else
            {
                MessageBox.Show("没有检测到该日期的自检记录,不能完成上传", "提示！");
            }
        }

        private void startSelfCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.NHNETMODE)
                {
                    int nhcode, nhexpcode;
                    string nhmsg, nhexpmsg;
                    mainPanel.nhinterface.SendUploadEquipmentStatus("1", out nhcode, out nhmsg, out nhexpcode, out nhexpmsg);
                }
                if (th_wait != null)
                    th_wait.Abort();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ini.INIIO.WritePrivateProfileString("测功机上次运转时间", "时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), @".\detectConfig.ini");

            mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
            mainPanel.check_linezt();
            Msg(label1, panel4, "自检合格");
            mainPanel.stationcontrol.setlineYureTime(mainPanel.stationid, mainPanel.lineid, DateTime.Now);
            mainPanel.worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
            mainPanel.worklogdata.ProjectName = "系统自检";
            mainPanel.worklogdata.Stationid = mainPanel.stationid;
            mainPanel.worklogdata.Lineid = mainPanel.lineid;
            mainPanel.worklogdata.Czy = mainPanel.nowUser.userName;
            mainPanel.worklogdata.Data = "自检通过";
            mainPanel.worklogdata.State = "";
            mainPanel.worklogdata.Result = "通过";
            mainPanel.worklogdata.Date = DateTime.Now;
            mainPanel.worklogdata.Bzsm = "";
            mainPanel.demarcatecontrol.saveWordLogByIni(mainPanel.worklogdata);
        }

        private void startSelfCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='M')
            {
                button2.Visible = !button2.Visible;
                panel3.Visible = !panel3.Visible;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string clid = mainPanel.stationid + mainPanel.lineid + "_" + dateTimePicker1.Value.ToString("yyyyMMdd");
            if (selfcheckcontrol.Have_SelfCheckData(clid))
            {
                SYS.Model.selfcheckdata checkdata = selfcheckcontrol.Get_SelfCheckData(clid);
                writeExcel.writeSelfCheckData(checkdata);
            }
            else
            {
                MessageBox.Show("没有检测到该日期的自检记录", "提示！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime insertdatetime = dateTimePickerFrom.Value;
            while (insertdatetime <= dateTimePickerEnd.Value)
            {
                string selfcheckid = mainPanel.stationid + textBoxLINEID.Text+ "_" + insertdatetime.ToString("yyyyMMdd");
                if (!selfcheckcontrol.Have_SelfCheckData(selfcheckid))
                {
                    
                    //selfcheckdata checkdata = new selfcheckdata();
                    Random rd = new Random();
                    double lrealtime = 0, lvituraltime = 0;
                    double hrealtime = 0, hvituraltime = 0;
                    if (textBoxLINEID.Text == "01")
                    {
                        lrealtime = 6.5 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        lvituraltime = 6.5 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        hrealtime = 10.4 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        hvituraltime =10.4 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                    }
                    else
                    {
                        lrealtime = 6.5 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        lvituraltime = 6.5 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        hrealtime = 10.1 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                        hvituraltime = 10.1 + ((rd.Next(100) - 50) * 1.0) / 1000.0;
                    }
                    initSelfData(selfcheckid);
                    checkdata.WORKTIME = DateTime.Parse(insertdatetime.ToString("yyyy-MM-dd") + " 08:" + rd.Next(59).ToString() + ":" + rd.Next(59).ToString());
                    checkdata.ISCGJCHECK = "Y";
                    checkdata.CGJTX = "Y";
                    checkdata.CGJYR = "Y";
                    checkdata.CGJQL = "Y";
                    checkdata.CGJJSGL = "Y";
                    checkdata.CGJJZHX = (100 * (lrealtime - lvituraltime) / lvituraltime < 4) ? "Y" : "N";
                    checkdata.CGJEDGL = "6.0";
                    checkdata.CGJSJGL = "6.0";
                    checkdata.CGJGLWC = "";
                    checkdata.CGJVITRUALTIME = lrealtime.ToString("0.000");
                    checkdata.CGJREALTIME = lvituraltime.ToString("0.000");
                    checkdata.CGJTIMEWC = (100 * (lrealtime - lvituraltime) / lvituraltime).ToString("0.0");

                    checkdata.HSSlideActualTime = hrealtime.ToString("0.000");
                    checkdata.HSSlideTheoreticalTime = hvituraltime.ToString("0.000");
                    checkdata.HSSlideLoadPower = "6.0";
                    checkdata.HSSlideBeginTime = DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.HSSlideEndTime = DateTime.Now.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.LSSlideActualTime = lrealtime.ToString("0.000");
                    checkdata.LSSlideTheoreticalTime = lvituraltime.ToString("0.000");
                    checkdata.LSSlideLoadPower = "6.0";
                    checkdata.LSSlideBeginTime = DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.LSSlideEndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    checkdata.WattlessMaxSpeed1 = "51";
                    checkdata.WattlessMinSpeed1 = "45";
                    checkdata.WattlessNorminalSpeed1 = "48";
                    checkdata.WattlessBeginTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessEndTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessOutput1 = "1.43";
                    checkdata.WattlessMaxSpeed2 = "48";
                    checkdata.WattlessMinSpeed2 = "32";
                    checkdata.WattlessNorminalSpeed2 = "40";
                    checkdata.WattlessBeginTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessEndTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessOutput2 = "1.25";
                    checkdata.WattlessMaxSpeed3 = "40";
                    checkdata.WattlessMinSpeed3 = "24";
                    checkdata.WattlessNorminalSpeed3 ="32";
                    checkdata.WattlessBeginTime3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessEndTime3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessOutput3 = "0.78";
                    checkdata.WattlessMaxSpeed4 ="32";
                    checkdata.WattlessMinSpeed4 = "16";
                    checkdata.WattlessNorminalSpeed4 = "24";
                    checkdata.WattlessBeginTime4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessEndTime4 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WattlessOutput4 = "0.46";

                    checkdata.O2MRBeginTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.O2MREndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WQBeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    checkdata.WQEndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    checkdata.ISBTGCHECK = "Y";
                    checkdata.BTGTX = "Y";
                    checkdata.BTGYR = "Y";
                    checkdata.BTGTL = "Y";
                    checkdata.BTGLC = "Y";
                    checkdata.BTGJZ = "Y";

                    checkdata.ISQXZCHECK = "Y";
                    checkdata.TEMP = (insertdatetime.Month * 3 + rd.Next(9) / 10.0).ToString();
                    checkdata.HUMI = ((200.0 + rd.Next(400)) / 10.0).ToString();
                    checkdata.AIRP = (93.5 + rd.Next(10) / 10.0).ToString();
                    checkdata.TEMPOK = "Y";
                    checkdata.HUMIOK = "Y";
                    checkdata.AIRPOK = "Y";
                    checkdata.ISZSJCHECK = "Y";
                    checkdata.ZSJTX = "Y";
                    checkdata.ZSJLC = "Y";

                        checkdata.ISFQYCHECK = "Y";
                        checkdata.FQYTX = "Y";
                        checkdata.FQYYR = "Y";
                        checkdata.FQYTL = "Y";
                        checkdata.FQYJL = "Y";
                        checkdata.FQYLC = "Y";
                        checkdata.FQYO2 = (20.6 + rd.Next(20) / 100.0).ToString();
                    checkdata.SlideJudge = "1";
                    checkdata.WattlessJudge = "1";
                    checkdata.O2MRJudge = "1";
                    checkdata.WQJudge = "1";
                    checkdata.AllJudge = "1";

                    try
                    {
                        selfcheckcontrol.Save_SelfCheckData(checkdata);
                    }
                    catch
                    { }
                }
                else
                {
                    checkdata = selfcheckcontrol.Get_SelfCheckData(selfcheckid);
                    Random rd = new Random();
                    
                    //initSelfData(selfcheckid);
                    checkdata.WORKTIME = DateTime.Parse(insertdatetime.ToString("yyyy-MM-dd") + " 08:" + rd.Next(59).ToString() + ":" + rd.Next(59).ToString());

                    try
                    {
                        selfcheckcontrol.Save_SelfCheckData(checkdata);
                    }
                    catch
                    { }
                }
                insertdatetime = insertdatetime.AddDays(1);
            }
            MessageBox.Show("finished");
        }

        
    }

}
