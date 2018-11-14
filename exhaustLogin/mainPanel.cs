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
using System.IO;
using System.Management;
using ini;
using carinfor;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using NeusoftUtil;
using Dynamometer;
using AhWebClient;
using JHWebClient;
using NhWebClient;
using System.Runtime.InteropServices;
using JxWebClient;
using HnWebClient;
using DlWebClient;
using HhzWebClient;
using System.Collections;
using YichangInter;

namespace exhaustDetect
{
    public partial class mainPanel : Form
    {
        #region 检测状态
        public static string idleState = "0";//待检状态
        public static string queryStartTest = "1";//请求开始，等待服务端验证
        public static string queryStartTestOK = "2";//由后台程序写入，请求开始，验证通过
        public static string queryStartTestNotOk = "3";//由后台程序写入，请求开始，验证未通过，未通过原因写在字段BZ里
        public static string startTest = "4";//开始检测
        public static string stopTest = "5";//未完成检测退出
        public static string finishTest = "6";//完成检测
        public static string vmas15 = "31";
        public static string vmas32 = "32";
        public static string vmas50 = "33";
        public static string asm5025start = "21";
        public static string asm5025end = "22";
        public static string asm2540start = "23";
        public static string asm2540end = "24";
        public static string highIdlesStart = "11";
        public static string lowIdleStart = "12";
        public static string lugdown100Vel = "41";
        public static string lugdown90Vel = "42";
        public static string lugdown80Vel = "43";
        public static string btgFirst = "51";
        public static string btgSecond = "52";
        public static string btgThird = "53";
        public static string highIdlesStartM = "81";
        public static string lowIdleStartM = "82";
        #endregion
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
        public static equipmentConfigInfdata equipconfig = new equipmentConfigInfdata();
        public static stationControl stationcontrol = new stationControl();
        public static stationInfModel stationinfmodel = new stationInfModel();
        public static loginInfControl logininfcontrol = new loginInfControl();
        public static atsaControl atsacontrol = new atsaControl();
        public static lineModel linemodel = new lineModel();
        public static othersModel otherinf = new othersModel();
        public static lshModel lshmodel = new lshModel();
        public static equipmentModel equipmodel = new equipmentModel();
        public static BDSX bdsx = new BDSX();
        public static LINESBBD linesbbd = new LINESBBD();
        public static netLoginData netlogin = new netLoginData();
        public static netRegCarWait netregcarwait = new netRegCarWait();
        public static workLogData worklogdata = new workLogData();
        public static demarcateControl demarcatecontrol = new demarcateControl();
        public static SyncXml syncinf = new SyncXml();
        public static configIni configini = new configIni();
        public static YZTM yztm = null;

        //万国联网
        public static wanguoSocketControl wgsocket = null;
        public static chenChuangSocketControl ccsocket = null;
        public static WGSocketInf wgsocketinf = new WGSocketInf();
        public static CCSocketInf ccsocketinf = new CCSocketInf();
        public static ACSocketInf acsocketinf = new ACSocketInf();
        public static NeusoftSocketInf neusoftsocketinf = new NeusoftSocketInf();
        public static ortSocketControl ortsocket = null;
        public static OrtSocketInf ortsocketinf = new OrtSocketInf();
        public static NeusoftSocket neusoftsocket = new NeusoftSocket();
        public static JHWebInf jhwebinf=new JHWebInf();
        public static AHWebInf ahwebinf = new AHWebInf();
        public static NHWebInf nhwebinf = new NHWebInf();
        public static JXWebInf jxwebinf = new JXWebInf();
        public static HNHYWebInf hnhywebinf = new HNHYWebInf();
        public static EZWebInf ezwebinf = new EZWebInf();
        public static DALIWebInf daliwebinf = new DALIWebInf();
        public static GLWebInf glwebinf = new GLWebInf();
        public static XBWebInf xbwebinf = new XBWebInf();
        public static PNWebInf pnwebinf = new PNWebInf();
        
        public static carinfor.ZKYTWebInf zkytwebinf = new carinfor.ZKYTWebInf();
        public static carinfor.HHZWebInf hhzwebinf = new carinfor.HHZWebInf();
        public static YichangInter.DeviceSwapIfaceImplService yichangInterface = null;
        public static DeviceSwapIfaceImplServiceOther yichangInterfaceOther = null;
        public static DeviceSwapIfaceImplServiceYnBs yichangInterfaceYnbs = null;
        public static YichangInter.xmlAnalysis xmlanalysis = new YichangInter.xmlAnalysis();
        public static carinfo.xbSocketControl xbsocket =null;
        public static string xbLoginUserName="";
        public static WebThread webthread = null;
        //public static int waitUploadTime = 1000;


        public static carinfor.captureConfigData capturedata = new captureConfigData();



        public static JHinterface jhinterface = null;
        public static JHWebClient.MyOracle jhoracle = null;
        public static SyNeusoft sysocket = null;

        public static JHWebClient.JHdeviceInf jhcgjinf = null;
        public static JHWebClient.JHdeviceInf jhfqyinf = null;
        public static JHWebClient.JHdeviceInf jhydjinf = null;
        public static JHWebClient.JHdeviceInf jhdzhjinf = null;
        public static JHWebClient.JHdeviceInf jhzsjinf = null;
        public static JHWebClient.JHdeviceInf jhlljinf = null;
        public static JHWebClient.JHdeviceInf jhlzinf = null;
        public static JHWebClient.JHdeviceInf jhgkjinf = null;


        public static Ahinterface ahinterface = null;
        public static Ahinterface ahinterfaceV27 = null;
        public static NhWebControl nhinterface = null;//南华接口
        public static jxWebControl jxinterface = null;
        /*湖南衡阳联网*/
        public static hnWebControl hninterface = null;
        /*大理联网*/
        public static daliInterface daliinterface = null;
        /*鄂州联网*/
        public static EzWebClient.Ezclient ezinterface = null;
        /*桂林联网 */
        public static GxWebClient.GxInterface gxinterface = null;
        public static Hhzclient hhzinterface = null;
        public static List<hhzperson> hhzpersonlist = new List<HhzWebClient.hhzperson>();
        /************江苏联网***************/
        public static jsSocketControl jsinterface = null;
        public static JsVehicleInfo jsvehiclemodel = new JsVehicleInfo();
        public static JsCheckLimit jschecklimitmodel = new JsCheckLimit();
        public static JsDemarcateLimit jsdermarcatelimitmodel = new JsDemarcateLimit();
        public static SYS_DAL.ConnForSQL conforsql;
        /**************喜邦*****************/
        public static List<carinfo.XB_USER> xb_user_list = new List<carinfo.XB_USER>();
        /**************平南联网****************/
        public static GxWebClient.Pnservice pninterface = null;
        public static bool useHyDatabase = false;

        Thread threadClient = null; // 创建用于接收服务端消息的 线程；
        Socket sockClient = null;

        public static operatorMode opratormode = new operatorMode();
        
        public static int linesCount = 0;
        public static string stationid = "";
        public static string lineid = "";
        public static bool enableDynTest = false;
        public static bool shareYhy = false;
        public static string directory = @"C:\jcdatatxt";
        public static string xcdirectory = @"C:\xcdatatxt";//因为朝阳区联网也是写文件到jcdatatxt，所以在该联网模式下，我们的程序将文件信息位置改在xcdatatxt
        public static string thisLineName = "";
        private string physicalIP = "";
        private int labellinewidth, panellinewidth,labelx;
        public struct dbinf
        {
            public string ip;
            public string dbname;
            public string user;
            public string password;
        }
        public static dbinf localdb, atsadb;
        public struct bdzt
        {
            public bool linezt;
            public string lineLockReason;
            public bool hxzt;
            public DateTime hxsj;
            public int hxts;
            public bool glzt;
            public DateTime glsj;
            public int glts;
            public bool jsglzt;
            public DateTime jsglsj;
            public int jsglts;
            public bool fxylowzt;
            public DateTime fxylowsj;
            public int fxylowts;
            public bool fxyhighzt;
            public DateTime fxyhighsj;
            public int fxyhights;
            public bool fxymidzt;
            public DateTime fxymidsj;
            public int fxymidts;
            public bool fxylowmidzt;
            public DateTime fxylowmidsj;
            public int fxylowmidts;
            public bool fxyhighmidzt;
            public DateTime fxyhighmidsj;
            public int fxyhighmidts;
            public bool yrzt;
            public DateTime yrsj;
            public int yrts;
            public bool zjzt;
            public DateTime zjsj;
            public int zjts;
            public bool yljzt;
            public DateTime yljsj;
            public int yljts;
            public bool sdzt;
            public DateTime sdsj;
            public int sdts;
            public bool ydjzt;
            public DateTime ydjsj;
            public int ydjts;
            public bool lljzt;
            public DateTime lljsj;
            public int lljts;
            public bool hjcszt;
            public DateTime hjcssj;
            public int hjcsts;
            public bool zsjzt;
            public DateTime zsjsj;
            public int zsjts;
            public bool jlzt;
            public DateTime jlsj;
            public int jlts;
        }
        public static bdzt linebdzt = new bdzt();
        public struct user
        {
            public string userName;
            public string postID;
            public string userPassword;
            public string postName;
            public string ycyuserName;
            public string ycyuserPassword;
        }

        public static user nowUser = new user();
        public static bool userLoginSuccess=false;
        public static System.Windows.Forms.Screen[] sc;
        public static int sc_width = 0;
        public static int sc_height = 0;
        private DateTime startTime;
        private DateTime nowtime;
        private int actionTime;
        public static bool isNetUsed = false;
        public static string NetMode = "";
        public static string tynettype = "";
        public const string WGNETMODE = "万国联网";
        public const string CCNETMODE = "诚创联网";
        public const string ORTNETMODE = "欧润特联网";
        public const string ACNETMODE = "安车联网v133";
        public const string NEUSOFTNETMODE = "东软联网";
        public const string JINGHUANETMODE = "金华联网";
        public static DateTime jh_ydj_zjtime;
        public const string JIANGSHUNETMODE = "江苏联网";
        public const string AHNETMODE = "安徽联网";
        public const string CYNETMODE = "朝阳联网";
        public const string NHNETMODE = "南华联网";
        public const string JXNETMODE = "江西联网";
        public const string HNNETMODE = "湖南联网";
        public const string EZNETMODE = "鄂州联网";
        public const string DALINETMODE = "大理联网";
        public const string GUILINNETMODE = "桂林联网";
        public const string HHZNNETMODE = "红河州联网";
        public const string ZKYTNETMODE = "中科宇图联网";
        public const string XBNETMODE = "喜邦联网";
        public const string PNNETMODE = "平南联网";
        
        public const string TYNETMODE = "通用联网";

        public const string NEU_SDRZ = "山东日照";
        public const string NEU_FJS = "福建省";
        public const string NEU_YNZT = "云南昭通";
        public const string NEU_YNKM = "云南昆明";
        public const string NEU_LNAS = "辽宁鞍山";
        public const string NEU_GZCJ = "贵州从江";
        public const string NEU_V301 = "V3.01";
        public const string NEU_V202 = "V2.2";
        public const string NEU_GANSU = "甘肃";

        public const string ACAREA_NN = "辽宁";
        public const string ACAREA_OTHER = "其他";
        public const string ACAREA_v132 = "v1.3.2";

        public const string AHVERSION_V23 = "v2.3";
        public const string AHVERSION_V27 = "v2.7";

        public const string TYNETTYPE_SDYT = "安车烟台";
        public const string TYNETTYPE_NNDL = "安车大连";
        public const string TYNETTYPE_OTHER = "其他";

        public const string ZKYTAREA_CD = "成都";
        public const string ZKYTAREA_OTHER = "其他";
        public const string ZKYTAREA_YNBS = "云南保山";
        public struct neu_accountV301
        {
            public string account;
            public string name;
            public string usertype;
            public neu_accountV301(string account1, string name1, string usertype1)
            {
                account = account1;
                name = name1;
                usertype = usertype1;
            }
        }
        public static List<neu_accountV301> neu_ycylistv301 = new List<neu_accountV301>();
        public static List<neu_accountV301> neu_czylistv301 = new List<neu_accountV301>();
        public static neu_accountV301 neu_nowCzy;
        public static neu_accountV301 neu_nowYcy;

        public string serverIP = "";
        public int serverPort = 0;

        public const int USER = 0X500;
        public const int recvMsg = USER + 4;
        public const int conntMsg = USER + 2;
        public const int closeMsg = USER + 3;
        private bool isRegOk = false;
        private bool isRegSuccess = true;

        public static string shy = "";

        public static string ts1, ts2;
        string detectFileDir = @"D:\ExhaustConfigBackup\detect";
        string appFileDir = @"D:\ExhaustConfigBackup\app";

        public static List<string> NeusoftDriverNameList = new List<string>();
        public static List<string> NeusoftOperatorNameList = new List<string>();

        public static Dictionary<string, string> userGroupHy = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicJcff = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicClzl = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicHpzl = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicSyxz = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicSyxzRev = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicQdfs = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicBsqxs = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicRyxs = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicRlzl = new Dictionary<string, string>();
        /// <summary>
        /// 有无催化转换器
        /// </summary>
        public static Dictionary<string, string> acDicChzhq = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicJqfs = new Dictionary<string, string>();
        /// <summary>
        /// 催化转换器类型
        /// </summary>
        public static Dictionary<string, string> acDicPqhclzz = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicSfwdzr = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicSfyqbf = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicJcfs = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicSfcs = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicPfbz = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicBzlx = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicCpys = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicZjlx = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicJzlx = new Dictionary<string, string>();
        public static Dictionary<string, string> acDicJclx = new Dictionary<string, string>();
        /// <summary>
        /// 有无
        /// </summary>
        public static Dictionary<string, string> acDicYW = new Dictionary<string, string>();
        /// <summary>
        /// 是否
        /// </summary>
        public static Dictionary<string, string> acDicYN = new Dictionary<string, string>();
        public enum acJzNameLn { 车速校准,扭力校准,寄生功率校准,加载滑行校准,废气校准,烟度校准};
        public static string[] acJzNoLn = { "01", "02", "03", "04", "05", "06" };
        public enum acZjNameLn { 加载滑行检查, 附加功率损失检查, 分析仪检查, 泄露检查, 分析仪氧量程检查,低标气检查,流量计检查};
        public static string[] acZjNoLn = { "01", "02", "03", "04", "05", "06","07","08" };


        public static bool isStartTimerInCarlogin = false;
        public mainPanel()
        {
            InitializeComponent();
            //init_form();
        }
        private void initAcDlDic()
        {
            acDicJcff.Add("1", "SDS");
            acDicJcff.Add("2", "ASM");
            acDicJcff.Add("3", "VMAS");
            acDicJcff.Add("4", "JZJS");
            acDicJcff.Add("5", "ZYJS");
            acDicJcff.Add("6", "LZ");
            acDicPfbz.Add("0", "国〇");
            acDicPfbz.Add("1", "国Ⅰ");
            acDicPfbz.Add("2", "国Ⅱ");
            acDicPfbz.Add("3", "国Ⅲ");
            acDicPfbz.Add("4", "国Ⅳ");
            acDicPfbz.Add("5", "国Ⅴ");
            acDicPfbz.Add("6", "国Ⅵ");
            acDicBzlx.Add("0", "绿标");
            acDicBzlx.Add("1", "黄标");
            acDicCpys.Add("1", "蓝牌");
            acDicCpys.Add("2", "黄牌");
            acDicCpys.Add("3", "白牌");
            acDicCpys.Add("4", "黑牌");
            acDicClzl.Add("1", "客车");
            acDicClzl.Add("2", "货车");
            acDicClzl.Add("3", "摩托车");
            acDicHpzl.Add("01", "大型汽车");
            acDicHpzl.Add("02", "小型汽车");
            acDicHpzl.Add("03", "使馆汽车");
            acDicHpzl.Add("04", "领馆汽车");
            acDicHpzl.Add("05", "境外汽车");
            acDicHpzl.Add("06", "外籍汽车");
            acDicHpzl.Add("07", "两、三轮摩托车");
            acDicHpzl.Add("08", "轻便摩托车");
            acDicHpzl.Add("09", "使馆摩托车");
            acDicHpzl.Add("10", "领馆摩托车");
            acDicHpzl.Add("11", "境外摩托车");
            acDicHpzl.Add("12", "外籍摩托车");
            acDicHpzl.Add("13", "农用运输车");
            acDicHpzl.Add("14", "拖拉机");
            acDicHpzl.Add("15", "挂车");
            acDicHpzl.Add("16", "教练汽车");
            acDicHpzl.Add("17", "教练摩托车");
            acDicHpzl.Add("18", "试验汽车");
            acDicHpzl.Add("19", "试验摩托车");
            acDicHpzl.Add("20", "临时人境汽车");
            acDicHpzl.Add("21", "临时人境摩托车");
            acDicHpzl.Add("22", "临时行驶车");
            acDicHpzl.Add("23", "警用汽车");
            acDicHpzl.Add("24", "警用摩托");
            acDicHpzl.Add("99", "其他");
            acDicSyxz.Add("A", "非营运");
            acDicSyxz.Add("B", "公路客运");
            acDicSyxz.Add("C", "公交客运");
            acDicSyxz.Add("D", "出租客运");
            acDicSyxz.Add("E", "旅游客运");
            acDicSyxz.Add("F", "货运");
            acDicSyxz.Add("G", "租赁");
            acDicSyxz.Add("H", "警用");
            acDicSyxz.Add("I", "消防");
            acDicSyxz.Add("J", "救护");
            acDicSyxz.Add("K", "工程抢险");
            acDicSyxz.Add("L", "营转非");
            acDicSyxz.Add("M", "出租转非");
            acDicSyxz.Add("N", "教练");
            acDicSyxz.Add("O", "幼儿校车");
            acDicSyxz.Add("P", "小学生校车");
            acDicSyxz.Add("Q", "初中生校车");
            acDicSyxz.Add("R", "危险品运输");
            acDicSyxz.Add("S", "中小学生校车");
            acDicSyxz.Add("Z", "其他");
            acDicSyxzRev.Add("非营运", "A");
            acDicSyxzRev.Add("公路客运", "B");
            acDicSyxzRev.Add("公交客运", "C");
            acDicSyxzRev.Add("出租客运", "D");
            acDicSyxzRev.Add("旅游客运", "E");
            acDicSyxzRev.Add("货运", "F");
            acDicSyxzRev.Add("租赁", "G");
            acDicSyxzRev.Add("警用", "H");
            acDicSyxzRev.Add("消防", "I");
            acDicSyxzRev.Add("救护", "J");
            acDicSyxzRev.Add("工程抢险", "K");
            acDicSyxzRev.Add("营转非", "L");
            acDicSyxzRev.Add("出租转非", "M");
            acDicSyxzRev.Add("教练", "N");
            acDicSyxzRev.Add("幼儿校车", "O");
            acDicSyxzRev.Add("小学生校车", "P");
            acDicSyxzRev.Add("初中生校车", "Q");
            acDicSyxzRev.Add("危险品运输", "R");
            acDicSyxzRev.Add("中小学生校车", "S");
            acDicSyxzRev.Add("其他", "Z");
            acDicQdfs.Add("1", "前驱");
            acDicQdfs.Add("2", "后驱");
            acDicQdfs.Add("3", "四驱");
            acDicQdfs.Add("4", "全时四驱");
            acDicBsqxs.Add("1", "手动");
            acDicBsqxs.Add("2", "自动");
            acDicBsqxs.Add("3", "手自一体");
            acDicRyxs.Add("1", "化油器");
            acDicRyxs.Add("2", "化油器改造");
            acDicRyxs.Add("3", "开环电喷");
            acDicRyxs.Add("4", "闭环电喷");
            acDicRyxs.Add("5", "高压共轨");
            acDicRyxs.Add("6", "泵油嘴");
            acDicRyxs.Add("7", "单体泵");
            acDicRyxs.Add("8", "直列泵");
            acDicRyxs.Add("9", "机械泵");
            acDicRyxs.Add("10", "其他");
            acDicRlzl.Add("A", "汽油");
            acDicRlzl.Add("B", "柴油");
            acDicRlzl.Add("C", "电");
            acDicRlzl.Add("D", "混合油");
            acDicRlzl.Add("E", "天然气");
            acDicRlzl.Add("F", "液化石油气");
            acDicRlzl.Add("H", "汽液双燃料");
            acDicRlzl.Add("J", "柴天双燃料");
            acDicRlzl.Add("K", "柴液双燃料");
            acDicRlzl.Add("L", "甲醇");
            acDicRlzl.Add("M", "乙醇");
            acDicRlzl.Add("N", "太阳能");
            acDicRlzl.Add("O", "混合动力");
            acDicRlzl.Add("P", "氢");
            acDicRlzl.Add("Q", "生物燃料");
            acDicRlzl.Add("Y", "无");
            acDicRlzl.Add("Z", "其他");
            acDicRlzl.Add("A1", "油改气");
            acDicChzhq.Add("N", "无");
            acDicChzhq.Add("Y", "有");
            acDicJqfs.Add("1", "自然吸气");
            acDicJqfs.Add("2", "涡轮增压");
            acDicPqhclzz.Add("1", "三元催化");
            acDicPqhclzz.Add("2", "DPF");
            acDicPqhclzz.Add("3", "SCE");
            acDicPqhclzz.Add("4", "DOC");
            acDicPqhclzz.Add("5", "POC");
            acDicPqhclzz.Add("6", "其他");

            acDicSfwdzr.Add("0", "否");
            acDicSfwdzr.Add("1", "是");
            acDicSfyqbf.Add("0", "否");
            acDicSfyqbf.Add("1", "是");
            acDicJcfs.Add("0", "上线检测");
            acDicJcfs.Add("1", "路检");
            acDicJcfs.Add("2", "服务");
            acDicJcfs.Add("3", "抽检");
            acDicJclx.Add("1", "定期检验");
            acDicJclx.Add("2", "注册登记检验");
            acDicJclx.Add("3", "实验比对");
            acDicJclx.Add("4", "转入检验");
            acDicJclx.Add("5", "委托检验");
            acDicJclx.Add("6", "黄改绿检验");
            acDicSfcs.Add("0", "否");
            acDicSfcs.Add("1", "是");
            acDicYW.Add("Y", "有");
            acDicYW.Add("N", "无");
            acDicYN.Add("Y", "是");
            acDicYN.Add("N", "否");

        }
        private void initAcYtDic()
        {
            acDicJcff.Add("1", "SDS");
            acDicJcff.Add("2", "ASM");
            acDicJcff.Add("3", "VMAS");
            acDicJcff.Add("4", "JZJS");
            acDicJcff.Add("5", "ZYJS");
            acDicJcff.Add("6", "LZ");
            acDicPfbz.Add("0", "国〇");
            acDicPfbz.Add("1", "国Ⅰ");
            acDicPfbz.Add("2", "国Ⅱ");
            acDicPfbz.Add("3", "国Ⅲ");
            acDicPfbz.Add("4", "国Ⅳ");
            acDicPfbz.Add("5", "国Ⅴ");
            acDicPfbz.Add("6", "国Ⅵ");
            acDicBzlx.Add("0", "绿标");
            acDicBzlx.Add("1", "黄标");
            acDicCpys.Add("1", "蓝牌");
            acDicCpys.Add("2", "黄牌");
            acDicCpys.Add("3", "白牌");
            acDicCpys.Add("4", "黑牌");
            acDicClzl.Add("1", "客车");
            acDicClzl.Add("2", "货车");
            acDicClzl.Add("3", "摩托车");
            acDicHpzl.Add("01", "大型汽车");
            acDicHpzl.Add("02", "小型汽车");
            acDicHpzl.Add("03", "使馆汽车");
            acDicHpzl.Add("04", "领馆汽车");
            acDicHpzl.Add("05", "境外汽车");
            acDicHpzl.Add("06", "外籍汽车");
            acDicHpzl.Add("07", "两、三轮摩托车");
            acDicHpzl.Add("08", "轻便摩托车");
            acDicHpzl.Add("09", "使馆摩托车");
            acDicHpzl.Add("10", "领馆摩托车");
            acDicHpzl.Add("11", "境外摩托车");
            acDicHpzl.Add("12", "外籍摩托车");
            acDicHpzl.Add("13", "农用运输车");
            acDicHpzl.Add("14", "拖拉机");
            acDicHpzl.Add("15", "挂车");
            acDicHpzl.Add("16", "教练汽车");
            acDicHpzl.Add("17", "教练摩托车");
            acDicHpzl.Add("18", "试验汽车");
            acDicHpzl.Add("19", "试验摩托车");
            acDicHpzl.Add("20", "临时人境汽车");
            acDicHpzl.Add("21", "临时人境摩托车");
            acDicHpzl.Add("22", "临时行驶车");
            acDicHpzl.Add("23", "警用汽车");
            acDicHpzl.Add("24", "警用摩托");
            acDicHpzl.Add("99", "其他");
            acDicSyxz.Add("A", "非营运");
            acDicSyxz.Add("B", "公路客运");
            acDicSyxz.Add("C", "公交客运");
            acDicSyxz.Add("D", "出租客运");
            acDicSyxz.Add("E", "旅游客运");
            acDicSyxz.Add("F", "货运");
            acDicSyxz.Add("G", "租赁");
            acDicSyxz.Add("H", "警用");
            acDicSyxz.Add("I", "消防");
            acDicSyxz.Add("J", "救护");
            acDicSyxz.Add("K", "工程抢险");
            acDicSyxz.Add("L", "营转非");
            acDicSyxz.Add("M", "出租转非");
            acDicSyxz.Add("N", "教练");
            acDicSyxz.Add("O", "幼儿校车");
            acDicSyxz.Add("P", "小学生校车");
            acDicSyxz.Add("Q", "初中生校车");
            acDicSyxz.Add("R", "危险品运输");
            acDicSyxz.Add("S", "中小学生校车");
            acDicSyxz.Add("Z", "其他");
            acDicSyxzRev.Add("非营运", "A");
            acDicSyxzRev.Add("公路客运", "B");
            acDicSyxzRev.Add("公交客运", "C");
            acDicSyxzRev.Add("出租客运", "D");
            acDicSyxzRev.Add("旅游客运", "E");
            acDicSyxzRev.Add("货运", "F");
            acDicSyxzRev.Add("租赁", "G");
            acDicSyxzRev.Add("警用", "H");
            acDicSyxzRev.Add("消防", "I");
            acDicSyxzRev.Add("救护", "J");
            acDicSyxzRev.Add("工程抢险", "K");
            acDicSyxzRev.Add("营转非", "L");
            acDicSyxzRev.Add("出租转非", "M");
            acDicSyxzRev.Add("教练", "N");
            acDicSyxzRev.Add("幼儿校车", "O");
            acDicSyxzRev.Add("小学生校车", "P");
            acDicSyxzRev.Add("初中生校车", "Q");
            acDicSyxzRev.Add("危险品运输", "R");
            acDicSyxzRev.Add("中小学生校车", "S");
            acDicSyxzRev.Add("其他", "Z");
            acDicQdfs.Add("1", "前驱");
            acDicQdfs.Add("2", "后驱");
            acDicQdfs.Add("3", "四驱");
            acDicQdfs.Add("4", "全时四驱");
            acDicBsqxs.Add("1", "手动");
            acDicBsqxs.Add("2", "自动");
            acDicBsqxs.Add("3", "手自一体");
            acDicRyxs.Add("1", "化油器");
            acDicRyxs.Add("2", "化油器改造");
            acDicRyxs.Add("3", "开环电喷");
            acDicRyxs.Add("4", "闭环电喷");
            acDicRyxs.Add("5", "高压共轨");
            acDicRyxs.Add("6", "泵油嘴");
            acDicRyxs.Add("7", "单体泵");
            acDicRyxs.Add("8", "直列泵");
            acDicRyxs.Add("9", "机械泵");
            acDicRyxs.Add("10", "其他");
            acDicRlzl.Add("A", "汽油");
            acDicRlzl.Add("B", "柴油");
            acDicRlzl.Add("C", "电");
            acDicRlzl.Add("D", "混合油");
            acDicRlzl.Add("E", "天然气");
            acDicRlzl.Add("F", "液化石油气");
            acDicRlzl.Add("H", "汽液双燃料");
            acDicRlzl.Add("J", "柴天双燃料");
            acDicRlzl.Add("K", "柴液双燃料");
            acDicRlzl.Add("L", "甲醇");
            acDicRlzl.Add("M", "乙醇");
            acDicRlzl.Add("N", "太阳能");
            acDicRlzl.Add("O", "混合动力");
            acDicRlzl.Add("P", "氢");
            acDicRlzl.Add("Q", "生物燃料");
            acDicRlzl.Add("Y", "无");
            acDicRlzl.Add("Z", "其他");
            acDicRlzl.Add("A1", "油改气");
            acDicChzhq.Add("N", "无");
            acDicChzhq.Add("Y", "有");
            acDicJqfs.Add("1", "自然吸气");
            acDicJqfs.Add("2", "涡轮增压");
            acDicPqhclzz.Add("1", "三元催化");
            acDicPqhclzz.Add("2", "DPF");
            acDicPqhclzz.Add("3", "SCE");
            acDicPqhclzz.Add("4", "DOC");
            acDicPqhclzz.Add("5", "POC");
            acDicPqhclzz.Add("6", "其他");

            acDicSfwdzr.Add("0", "否");
            acDicSfwdzr.Add("1", "是");
            acDicSfyqbf.Add("0", "否");
            acDicSfyqbf.Add("1", "是");
            acDicJcfs.Add("0", "上线检测");
            acDicJcfs.Add("1", "路检");
            acDicJcfs.Add("2", "服务");
            acDicJcfs.Add("3", "抽检");
            acDicJclx.Add("1", "定期检验");
            acDicJclx.Add("2", "注册登记检验");
            acDicJclx.Add("3", "实验比对");
            acDicJclx.Add("4", "转入检验");
            acDicJclx.Add("5", "委托检验");
            acDicJclx.Add("6", "黄改绿检验");
            acDicSfcs.Add("0", "否");
            acDicSfcs.Add("1", "是");
            
            acDicYW.Add("Y", "有");
            acDicYW.Add("N", "无");
            acDicYN.Add("Y", "是");
            acDicYN.Add("N", "否");

        }
        private void initAcDic()
        {
            acDicJcff.Add("0", "SDS");
            acDicJcff.Add("1", "ASM");
            acDicJcff.Add("2", "VMAS");
            acDicJcff.Add("3", "JZJS");
            acDicJcff.Add("4", "ZYJS");
            acDicJcff.Add("5", "LZ");
            acDicClzl.Add("1", "客车");
            acDicClzl.Add("2", "货车");
            acDicClzl.Add("3", "摩托车");
            acDicHpzl.Add("01", "大型汽车");
            acDicHpzl.Add("02", "小型汽车");
            acDicHpzl.Add("03", "使馆汽车");
            acDicHpzl.Add("04", "领馆汽车");
            acDicHpzl.Add("05", "境外汽车");
            acDicHpzl.Add("06", "外籍汽车");
            acDicHpzl.Add("07", "两、三轮摩托车");
            acDicHpzl.Add("08", "轻便摩托车");
            acDicHpzl.Add("09", "使馆摩托车");
            acDicHpzl.Add("10", "领馆摩托车");
            acDicHpzl.Add("11", "境外摩托车");
            acDicHpzl.Add("12", "外籍摩托车");
            acDicHpzl.Add("13", "农用运输车");
            acDicHpzl.Add("14", "拖拉机");
            acDicHpzl.Add("15", "挂车");
            acDicHpzl.Add("16", "教练汽车");
            acDicHpzl.Add("17", "教练摩托车");
            acDicHpzl.Add("18", "试验汽车");
            acDicHpzl.Add("19", "试验摩托车");
            acDicHpzl.Add("20", "临时人境汽车");
            acDicHpzl.Add("21", "临时人境摩托车");
            acDicHpzl.Add("22", "临时行驶车");
            acDicHpzl.Add("23", "警用汽车");
            acDicHpzl.Add("24", "警用摩托");
            acDicHpzl.Add("99", "其他");
            acDicSyxz.Add("A", "非营运");
            acDicSyxz.Add("B", "公路客运");
            acDicSyxz.Add("C", "公交客运");
            acDicSyxz.Add("D", "出租客运");
            acDicSyxz.Add("E", "旅游客运");
            acDicSyxz.Add("F", "货运");
            acDicSyxz.Add("G", "租赁");
            acDicSyxz.Add("H", "警用");
            acDicSyxz.Add("I", "消防");
            acDicSyxz.Add("J", "救护");
            acDicSyxz.Add("K", "工程抢险");
            acDicSyxz.Add("L", "营转非");
            acDicSyxz.Add("M", "出租转非");
            acDicSyxz.Add("Z", "其他");
            acDicSyxzRev.Add("非营运", "A");
            acDicSyxzRev.Add("公路客运", "B");
            acDicSyxzRev.Add("公交客运", "C");
            acDicSyxzRev.Add("出租客运", "D");
            acDicSyxzRev.Add("旅游客运", "E");
            acDicSyxzRev.Add("货运", "F");
            acDicSyxzRev.Add("租赁", "G");
            acDicSyxzRev.Add("警用", "H");
            acDicSyxzRev.Add("消防", "I");
            acDicSyxzRev.Add("救护", "J");
            acDicSyxzRev.Add("工程抢险", "K");
            acDicSyxzRev.Add("营转非", "L");
            acDicSyxzRev.Add("出租转非", "M");
            acDicSyxzRev.Add("其他", "Z");
            acDicQdfs.Add("1", "前驱");
            acDicQdfs.Add("2", "后驱");
            acDicQdfs.Add("3", "全驱");
            acDicBsqxs.Add("1", "手动");
            acDicBsqxs.Add("2", "自动");
            acDicBsqxs.Add("3", "手自动一体");
            acDicRyxs.Add("1", "电喷");
            acDicRyxs.Add("2", "化油器");
            acDicRyxs.Add("3", "化油器改造");
            acDicRlzl.Add("A", "汽油");
            acDicRlzl.Add("B", "柴油");
            acDicRlzl.Add("C", "电");
            acDicRlzl.Add("D", "混合油");
            acDicRlzl.Add("E", "天然气");
            acDicRlzl.Add("F", "液化石油气");
            acDicRlzl.Add("H", "汽液双燃料");
            acDicRlzl.Add("J", "柴天双燃料");
            acDicRlzl.Add("K", "柴液双燃料");
            acDicRlzl.Add("L", "甲醇");
            acDicRlzl.Add("M", "乙醇");
            acDicRlzl.Add("N", "太阳能");
            acDicRlzl.Add("O", "混合动力");
            acDicRlzl.Add("Y", "无");
            acDicRlzl.Add("Z", "其他");
            acDicRlzl.Add("A1", "油改气");
            acDicChzhq.Add("0", "无");
            acDicChzhq.Add("1", "有");
            acDicJqfs.Add("1", "自然吸气");
            acDicJqfs.Add("2", "涡轮增压");
            acDicPqhclzz.Add("0", "无");
            acDicPqhclzz.Add("1", "有");
            acDicSfwdzr.Add("0", "否");
            acDicSfwdzr.Add("1", "是");
            acDicSfyqbf.Add("0", "否");
            acDicSfyqbf.Add("1", "是");
            acDicJcfs.Add("0", "上线检测");
            acDicJcfs.Add("1", "路检");
            acDicJcfs.Add("2", "服务");
            acDicJcfs.Add("3", "抽检");
            acDicSfcs.Add("0", "否");
            acDicSfcs.Add("1", "是");
        }
        private bool checkRegister()
        {
            string registerCode = "";
            string rightRegisterCode = "";
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("注册信息", "注册码", "", temp, 2048, @".\appConfig.ini");
            
            return true;
        }
        /// <summary>
        /// 获取网卡物理地址
        /// </summary>
        /// <returns></returns>
        public static string getMacAddr_Local()
        {
            string madAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    madAddr = mo["MacAddress"].ToString();
                    madAddr = madAddr.Replace(':', '-');
                }
                mo.Dispose();
            }
            return madAddr;
        }
        private void init_form()
        {
            
        }
        private void init_files()
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.CYNETMODE)
            {
                INIIO.createDir(xcdirectory);
                INIIO.deleteDir(xcdirectory);
            }
            else
            {
                INIIO.createDir(directory);
                INIIO.deleteDir(directory);
            }
        }
        public void Init_sc()
        {
            sc = System.Windows.Forms.Screen.AllScreens;
            sc_height = this.Height;
            sc_width = this.Width;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
            wgsocketinf.SBRZBH = temp.ToString().Trim();
            return true;
        }
        private bool init_ahinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("安徽联网", "WEBURL", "http://112.27.49.111/GCservice/Service.asmx", temp, 2048, @".\appConfig.ini");
            ahwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("安徽联网", "LINEID", "36,37,38,39", temp, 2048, @".\appConfig.ini");
            ahwebinf.lineid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("安徽联网", "VERSION", "v2.7", temp, 2048, @".\appConfig.ini");
            ahwebinf.version = temp.ToString().Trim();
            return true;
        }
        private bool init_nhinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("南华联网", "WEBURL", "http://localhost:50581/NHDSWebService.asmx", temp, 2048, @".\appConfig.ini");
            nhwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("南华联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            nhwebinf.lineid = temp.ToString().Trim();
            return true;
        }
        private bool init_jhinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("金华联网", "WEBURL", "http://10.33.139.24/services/inspService?wsdl", temp, 2048, @".\appConfig.ini");
            jhwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "SERVERIP", "10.33.139.24", temp, 2048, @".\appConfig.ini");
            jhwebinf.serverIP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "SAFEPWD", "webservicepwd", temp, 2048, @".\appConfig.ini");
            jhwebinf.safepwd = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "STATIONID", "33070102", temp, 2048, @".\appConfig.ini");
            jhwebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            jhwebinf.lineid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "AREA", "", temp, 2048, @".\appConfig.ini");
            jhwebinf.area = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "ORACLEIP", "10.33.139.23", temp, 2048, @".\appConfig.ini");
            jhwebinf.dbip = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "ORACLEUSER", "s33070106", temp, 2048, @".\appConfig.ini");
            jhwebinf.dbuser = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "ORACLECODE", "s33070106", temp, 2048, @".\appConfig.ini");
            jhwebinf.dbpassword = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("金华联网", "CHECKPRINT", "N", temp, 2048, @".\appConfig.ini");
            jhwebinf.checkprint = temp.ToString().Trim() == "Y";
            return true;
        }
        public static bool check_jh_ydjzj()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("金华联网", "烟度计自检记录", "", temp, 2048, @".\appConfig.ini");
            DateTime zjtimetemp;
            if (DateTime.TryParse(temp.ToString(), out zjtimetemp))
            {
                jh_ydj_zjtime = zjtimetemp;
                if (DateTime.Now.ToString("yyyyMMdd") != jh_ydj_zjtime.ToString("yyyyMMdd"))
                {
                    return false;
                }
                else if (DateTime.Now.Hour >= 12 && jh_ydj_zjtime.Hour < 12)
                {
                    return false;
                }
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
        private bool init_ccinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("诚创联网", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            ccsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("诚创联网", "服务器PORT", "7803", temp, 2048, @".\appConfig.ini");
            ccsocketinf.PORT = temp.ToString().Trim();
            return true;
        }
        private bool init_xbinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("喜邦联网", "ip", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.ip = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("喜邦联网", "port", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.port = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("喜邦联网", "certificateNo", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.certificateNo = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("喜邦联网", "version", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.version = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("喜邦联网", "diskNo", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.diskNo = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("喜邦联网", "lineid", "", temp, 2048, @".\appConfig.ini");
            xbwebinf.lineid = temp.ToString().Trim();
            return true;
        }
        private bool init_hnhyinf()
        {

            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "WEBURL", "http://192.168.1.230/jcz_jk/ExternalAccess.asmx", temp, 2048, @".\appConfig.ini");
            hnhywebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "STATIONID", "43042111", temp, 2048, @".\appConfig.ini");
            hnhywebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "LINEID", "4304211101", temp, 2048, @".\appConfig.ini");
            hnhywebinf.lineid = temp.ToString().Trim();
            return true;
        }
        private bool init_jxinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("江西联网", "账号", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.user = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("江西联网", "密码", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.password = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("江西联网", "检测线ID", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.lineid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("江西联网", "url", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.url = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("江西联网", "SOCKETIP", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.socketip = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("江西联网", "SOCKETPORT", "", temp, 2048, @".\appConfig.ini");
            jxwebinf.socketport = temp.ToString().Trim();
            return true;
        }
        private bool init_Acinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("联网信息", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            acsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网信息", "服务器PORT", "7803", temp, 2048, @".\appConfig.ini");
            acsocketinf.PORT = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网信息", "安车联网地区", "其他", temp, 2048, @".\appConfig.ini");
            acsocketinf.AREA = temp.ToString().Trim();
            carinfor.acNetInf.acArea = acsocketinf.AREA;
            return true;
        }
        private bool init_ortinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("欧润特联网", "服务器IP", "192.168.1.188", temp, 2048, @".\appConfig.ini");
            ortsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("欧润特联网", "服务器PORT", "6005", temp, 2048, @".\appConfig.ini");
            ortsocketinf.PORT = temp.ToString().Trim();
            return true;
        }
        private bool init_neusoftinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
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
            return true;
        }
        private bool init_daliinf()
        {

            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("大理联网", "LINEID", "532923001", temp, 2048, @".\appConfig.ini");
            daliwebinf.LINEID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("大理联网", "SERVERIP", "192.168.100.100", temp, 2048, @".\appConfig.ini");
            daliwebinf.SERVERIP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("大理联网", "SERVERPORT", "9800", temp, 2048, @".\appConfig.ini");
            daliwebinf.SERVERPORT = temp.ToString().Trim();
            return true;
        }
        private bool init_glinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("桂林联网", "WEBURL", "http://192.168.16.2:9903/HBService.asmx", temp, 2048, @".\appConfig.ini");
            glwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("桂林联网", "USER", "admin", temp, 2048, @".\appConfig.ini");
            glwebinf.user = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("桂林联网", "PASSWORD", "123456", temp, 2048, @".\appConfig.ini");
            glwebinf.password = temp.ToString().Trim();
            return true;
        }
        private bool init_pninf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("平南联网", "WebServiceUrl", "http://124.226.217.80:10014/VehicleInspectionService.asmx", temp, 2048, @".\appConfig.ini");
            pnwebinf.Url = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "WebServiceUser", "admin", temp, 2048, @".\appConfig.ini");
            pnwebinf.User = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "WebServicePwd", "123456", temp, 2048, @".\appConfig.ini");
            pnwebinf.Pwd = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "cityCode", "537300", temp, 2048, @".\appConfig.ini");
            pnwebinf.cityCode = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "stationCode", "53730001", temp, 2048, @".\appConfig.ini");
            pnwebinf.stationCode = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "lineCode", "01", temp, 2048, @".\appConfig.ini");
            pnwebinf.lineCode = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("平南联网", "factoryNo", "000000", temp, 2048, @".\appConfig.ini");
            pnwebinf.factoryNo = temp.ToString().Trim();
            return true;
        }
        private bool init_hhzinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("红河州联网", "WEBURL", "http://172.16.1.1:8088/hhapi/unit_task/", temp, 2048, @".\appConfig.ini");
            hhzwebinf.weburl = temp.ToString().Trim();
            return true;
        }
        private bool init_zkytinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("中科宇图联网", "WEBURL", "http://172.22.40.140:8095/jczjk/services/deviceSwap", temp, 2048, @".\appConfig.ini");
            zkytwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "ADD", "其他", temp, 2048, @".\appConfig.ini");
            zkytwebinf.add = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "上传超时时间", "10", temp, 2048, @".\appConfig.ini");
            try
            {
                zkytwebinf.waitUploadTime = int.Parse(temp.ToString().Trim());
            }
            catch
            {
                zkytwebinf.waitUploadTime = 10;
            }
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            zkytwebinf.lineID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "验证上传", "Y", temp, 2048, @".\appConfig.ini");
            zkytwebinf.checkUploadSuccess = (temp.ToString().Trim() == "Y");
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "显示结果", "Y", temp, 2048, @".\appConfig.ini");
            zkytwebinf.displayCheckResult = (temp.ToString().Trim() == "Y");
            return true;
        }
        public bool get_zkytRegCode()
        {

            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("中科宇图", "启动授权码", "", temp, 2048, @".\中科宇图授权码.ini");
            zkytwebinf.regcode = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图", "更新时间", "", temp, 2048, @".\中科宇图授权码.ini");
            if(!DateTime.TryParse(temp.ToString(),out zkytwebinf.regtime))
                zkytwebinf.regtime =DateTime.Now;
            ini.INIIO.GetPrivateProfileString("中科宇图", "状态", "", temp, 2048, @".\中科宇图授权码.ini");
            zkytwebinf.regsuccess = temp.ToString().Trim()=="成功";
            return zkytwebinf.regsuccess;
        }
        private bool init_ezinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("鄂州联网", "WEBURL", "http://58.19.205.150:8081/jdcData", temp, 2048, @".\appConfig.ini");
            ezwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("鄂州联网", "STATIONID", "CD", temp, 2048, @".\appConfig.ini");
            ezwebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("鄂州联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            ezwebinf.lineid = temp.ToString().Trim();
            return true;
        }
        private bool init_stationinf()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("数据", "服务器", "", temp, 2048, @".\appConfig.ini");
            localdb.ip = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("数据", "数据库", "", temp, 2048, @".\appConfig.ini");
            localdb.dbname = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("数据", "用户名", "", temp, 2048, @".\appConfig.ini");
            localdb.user = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("数据", "密码", "", temp, 2048, @".\appConfig.ini");
            localdb.password = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("ATSA数据", "服务器", "", temp, 2048, @".\appConfig.ini");
            atsadb.ip = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("ATSA数据", "数据库", "", temp, 2048, @".\appConfig.ini");
            atsadb.dbname = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("ATSA数据", "用户名", "", temp, 2048, @".\appConfig.ini");
            atsadb.user = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("ATSA数据", "密码", "", temp, 2048, @".\appConfig.ini");
            atsadb.password = temp.ToString().Trim();

            equipconfig = configini.getEquipConfigIni();

            if (DBHelperSQL.DB_Link_Test())
            {
                toolStripLabel1NetStatus.Text = "工作状态：本地模式，接到服务器成功";
            }
            else
            {
                if (DBHelperSQL.DB_Link_Test())
                {
                    toolStripLabel1NetStatus.Text = "工作状态：本地模式，接到服务器成功";
                }
                else
                {
                    if (DBHelperSQL.DB_Link_Test())
                    {
                        toolStripLabel1NetStatus.Text = "工作状态：本地模式，接到服务器成功";
                    }
                    else
                    {
                        toolStripLabel1NetStatus.Text = "工作状态：本地模式，接到服务器失败";
                        MessageBox.Show("连接本地数据库失败,请检查检测线配置相关信息");
                        return false;
                    }
                }
            }
            initEquipment();
            if(yztm!=null)
            {
                try
                {
                    if (!ATSADBHelperSQL.DB_Link_Test())
                    {
                        MessageBox.Show("连接条码数据库失败,请检查检测线配置相关信息");
                    }
                }
                catch(Exception er)
                {
                    MessageBox.Show("连接条码数据库失败:" + er.Message);
                }
            }
            ini.INIIO.GetPrivateProfileString("检测线", "线号", "", temp, 2048, @".\appConfig.ini");
            lineid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("报告单", "审核员", "", temp, 2048, @".\appConfig.ini");
            shy = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测线", "检综检", "N", temp, 2048, @".\appConfig.ini");
            enableDynTest = temp.ToString().Trim()=="Y";
            ini.INIIO.GetPrivateProfileString("检测线", "共用油耗", "N", temp, 2048, @".\appConfig.ini");
            shareYhy = temp.ToString().Trim()=="Y";
            if (enableDynTest) toolStripButtonZj.Visible = true;
             stationid = stationcontrol.getStationID();
            stationinfmodel = stationcontrol.getStationInf(stationid);
            linesCount = stationcontrol.getStationLineCount(stationid);
            linemodel = stationcontrol.getLineInf(stationid, lineid);
            lshmodel = stationcontrol.getLineLshInf(stationid, lineid);
            equipmodel = stationcontrol.getLineEquipInf(stationid, lineid);
            capturedata = configini.getCameraConfigIni();
            bdsx = stationcontrol.getDemarcateInf();
            ini.INIIO.GetPrivateProfileString("工作模式", "联网运行", "N", temp, 2048, @".\appConfig.ini");
            if (temp.ToString() == "Y")
                isNetUsed = true;
            else
                isNetUsed = false;
            ini.INIIO.GetPrivateProfileString("工作模式", "使用华燕数据库", "N", temp, 2048, @".\appConfig.ini");
            useHyDatabase= temp.ToString().Trim() == "Y";

            ini.INIIO.GetPrivateProfileString("通用联网模式", "联网模式", "其他", temp, 2048, @".\appConfig.ini");
            tynettype = temp.ToString().Trim();
            if (useHyDatabase)
            {
                if (hyDatabaseInter.initConn())
                {
                    DataTable dt = new DataTable();
                    if (hyDatabaseInter.readGroup(out dt))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            userGroupHy.Add(dt.Rows[i]["GroupName"].ToString(), dt.Rows[i]["GroupID"].ToString());
                        }
                    }
                    else
                    {
                        useHyDatabase = false;
                        MessageBox.Show("连接到华燕数据库失败，请检查相关配置");
                    }
                }
                else
                {
                    MessageBox.Show("初始化华燕数据库连接字体串出错，请检查相关配置");
                }
            }
            ini.INIIO.GetPrivateProfileString("联网模式", "模式", "万国联网", temp, 2048, @".\appConfig.ini");
            NetMode = temp.ToString().Trim();
            if (stationinfmodel.CLEARMODE == "M")//按月清流水号
            {
                if (stationinfmodel.STATIONCOUNTDATE.Month!= DateTime.Now.Month)//如果记录月份不等于当天月份
                {
                    stationcontrol.setStationLshDate(stationid, DateTime.Now.ToShortDateString());
                    mainPanel.stationcontrol.setStationLshCount(mainPanel.stationid, "1");
                }
            }
            else if(stationinfmodel.CLEARMODE=="Y")//按年清流水号
            {
                if (stationinfmodel.STATIONCOUNTDATE.Year != DateTime.Now.Year)//如果记录年份不等于当天年份
                {
                    stationcontrol.setStationLshDate(stationid, DateTime.Now.ToShortDateString());
                    mainPanel.stationcontrol.setStationLshCount(mainPanel.stationid, "1");
                }
            }
            else if (stationinfmodel.CLEARMODE == "D")//按年清流水号
            {
                if (stationinfmodel.STATIONCOUNTDATE.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))//如果记录年份不等于当天年份
                {
                    stationcontrol.setStationLshDate(stationid, DateTime.Now.ToShortDateString());
                    mainPanel.stationcontrol.setStationLshCount(mainPanel.stationid, "1");
                }
            }

            if (lshmodel.DATE.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                stationcontrol.setLineLshDate(stationid, lineid,DateTime.Now.ToShortDateString());
                stationcontrol.setLineLshCount(stationid, lineid, "1");

            }
            
            otherinf = stationcontrol.getOtherInf();
            thisLineName=stationinfmodel.STATIONNAME+"_"+lineid ;
            labelStationName.Text = thisLineName;
            /*labelLine.Text = "☆☆☆" + thisLineName + "☆☆☆";
            labellinewidth = labelLine.Width;
            panellinewidth = panelLineName.Width;*/
            labelx = panellinewidth;
            return true;
        }
        public static CapturePicture.captureControl capturecontrol =null;
        public static bool iscameraused = false;
        private void initCamera()
        {
            if (capturedata.ENABLEFRONT || capturedata.ENABLEFRONT)
            {
                capturecontrol = new CapturePicture.captureControl();
                iscameraused=capturecontrol.init_camera(capturedata);
            }
        }
        public void initEquipment()
        {
            bool Init_flag = true;
            string init_message = "";

            //这里只初始化了废气分析仪其他设备要继续初始化
            try
            {
                if (equipconfig.Tmqxh == "YZ_1")
                {
                    try
                    {
                        yztm = new Dynamometer.YZTM("BNTD");
                        if (yztm.Init_Comm(equipconfig.Tmqck, equipconfig.Tmqckpz) == false)
                        {
                            yztm = null;
                            Init_flag = false;
                            init_message += "条码枪串口打开失败.";
                        }
                    }
                    catch (Exception er)
                    {
                        yztm = null;
                        Init_flag = false;
                        MessageBox.Show(er.ToString(), "条码枪串口打开失败");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        protected override void WndProc(ref Message m)
        {
            char cmd = 'R';
            int ntype = 0;
            StringBuilder dataRec = new StringBuilder("", 500);
            dataRec.AppendFormat("");
            if(carinfor.acNetInf.acArea==acNetInf.acArea_NN)          
            {
                switch (m.Msg)
                {
                    case recvMsg:

                        if (SocketControlNn.RecvRemoteData((int)(m.LParam), ref cmd, ref ntype, dataRec))
                        {
                            switch (cmd)
                            {
                                case 'R':
                                    if (ntype == (int)'S')
                                    {
                                        toolStripLabelGW.Text = "工位注册成功";
                                        isRegSuccess = true;
                                    }
                                    else if (ntype == (int)'F')
                                    {
                                        toolStripLabelGW.Text = "工位注册失败";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    else if (ntype == (int)'P')
                                    {
                                        toolStripLabelGW.Text = "权限不够";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    else if (ntype == (int)'A')
                                    {
                                        toolStripLabelGW.Text = "系统已锁止";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    break;
                                case 'N':
                                    if (ntype == 3)
                                    {
                                        string[] datereceive = dataRec.ToString().Replace("\r\n", "").Split('=');
                                        string datetimereceive = datereceive[datereceive.Length - 1];
                                        string[] datetimearray = datetimereceive.Split(' ');
                                        datetimereceive = datetimearray[0] + " " + datetimearray[1] + "." + datetimearray[2];
                                        SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                    }
                                    break;
                                default: break;
                            }

                        }
                        break;
                    case closeMsg:
                        toolStripLabel1NetStatus.Text = "工作状态：服务器断开";
                        SocketControlNn.ReConnectToServer();
                        break;
                    case conntMsg:
                        toolStripLabel1NetStatus.Text = "工作状态：服务器已连接上";
                        if (!isRegOk)
                        {
                            if (init_regLine())
                            {
                                SocketControlNn.ReConnectToServer();
                                isRegOk = true;
                                //toolStripLabelGW.Text = "工位注册成功";
                            }
                            else
                            {
                                isRegOk = true;
                                toolStripLabel1NetStatus.Text = "工位注册发送失败";
                            }
                        }
                        //init_regLine();
                        break;
                    default: base.WndProc(ref m); break;
                }
            }
            else
            {
                switch (m.Msg)
                {
                    case recvMsg:

                        if (SocketControl.RecvRemoteData((int)(m.LParam), ref cmd, ref ntype, dataRec))
                        {
                            switch (cmd)
                            {
                                case 'R':
                                    if (ntype == (int)'S')
                                    {
                                        toolStripLabelGW.Text = "工位注册成功";
                                        isRegSuccess = true;
                                    }
                                    else if (ntype == (int)'F')
                                    {
                                        toolStripLabelGW.Text = "工位注册失败";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    else if (ntype == (int)'P')
                                    {
                                        toolStripLabelGW.Text = "权限不够";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    else if (ntype == (int)'A')
                                    {
                                        toolStripLabelGW.Text = "系统已锁止";
                                        //MessageBox.Show(dataRec.ToString(), "系统提示");
                                    }
                                    break;
                                case 'N':
                                    if (ntype == 3)
                                    {
                                        string[] datereceive = dataRec.ToString().Replace("\r\n", "").Split('=');
                                        string datetimereceive = datereceive[datereceive.Length - 1];
                                        string[] datetimearray = datetimereceive.Split(' ');
                                        datetimereceive = datetimearray[0] + " " + datetimearray[1] + "." + datetimearray[2];
                                        SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                    }
                                    break;
                                default: break;
                            }

                        }
                        break;
                    case closeMsg:
                        toolStripLabel1NetStatus.Text = "工作状态：服务器断开";
                        SocketControl.ReConnectToServer();
                        break;
                    case conntMsg:
                        toolStripLabel1NetStatus.Text = "工作状态：服务器已连接上";
                        if (!isRegOk)
                        {
                            if (init_regLine())
                            {
                                SocketControl.ReConnectToServer();
                                isRegOk = true;
                                //toolStripLabelGW.Text = "工位注册成功";
                            }
                            else
                            {
                                isRegOk = true;
                                toolStripLabel1NetStatus.Text = "工位注册发送失败";
                            }
                        }
                        //init_regLine();
                        break;
                    default: base.WndProc(ref m); break;
                }
            }


        }
        private bool init_regLine()
        {
            netlogin.JCGWH = lineid;
            netlogin.JCZBH = stationid;
            netlogin.STATION_PROGRAM = equipmodel.SBMC;
            if (linemodel.VMAS == "Y") netlogin.STATION_KIND += "1,";
            if (linemodel.ASM == "Y") netlogin.STATION_KIND += "2,";
            if (linemodel.SDS == "Y") netlogin.STATION_KIND += "3,";
            if (linemodel.JZJS_HEAVY == "Y" || linemodel.JZJS_LIGHT == "Y") netlogin.STATION_KIND += "4,";
            if (linemodel.ZYJS == "Y") netlogin.STATION_KIND += "5,";
            if (netlogin.STATION_KIND.Length >= 1)
                netlogin.STATION_KIND = netlogin.STATION_KIND.Remove(netlogin.STATION_KIND.Length - 1);
            netlogin.STATION_STATUS = "W";
            netlogin.OPERATOR_NO = "123";
            netlogin.OPERATOR_PSW = "123";
            netlogin.SynchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            if (netlogin.writeNetLoginData())
                return true;
            else
                return false;
        }

        private void initNetConfig()
        {
            if (isNetUsed)
            {
                if (NetMode == WGNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_wginf();
                    wgsocket = new wanguoSocketControl();
                    wgsocket.initSocket(wgsocketinf.IP, wgsocketinf.PORT);
                    string socketMsg = wgsocket.init_equipment();
                    if (socketMsg == "连接成功")
                    {
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接万国联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接万国联网服务器成功");

                    }
                    else
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接万国联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接万国联网服务器失败,将工作在单机模式");
                    }
                }
                if (NetMode == DALINETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_daliinf();
                    daliinterface = new daliInterface();
                    daliinterface.initSocket(daliwebinf.SERVERIP, daliwebinf.SERVERPORT);
                    string socketMsg = daliinterface.init_equipment();
                    if (socketMsg == "连接成功")
                    {
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接大理联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接大理联网服务器成功");

                    }
                    else
                    {
                        MessageBox.Show("连续服务端口失败:" + socketMsg);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接大理联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接大理联网服务器失败,将工作在单机模式");
                    }
                    if (isNetUsed)
                    {
                        DataTable dt = new DataTable();
                        DataRow dr = null;
                        dt.Columns.Add("设备名称");
                        dt.Columns.Add("设备状态");
                        if (equipconfig.Cgjifpz)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "0";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        if (equipconfig.Fqyifpz)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "1";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        if (equipconfig.Ydjifpz)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "2";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        if (true)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "3";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        if (true)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "4";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        if (equipconfig.Lljifpz)
                        {
                            dr = dt.NewRow();
                            dr["设备名称"] = "5";
                            dr["设备状态"] = "0";
                            dt.Rows.Add(dr);
                        }
                        string code, msg;
                        if (!daliinterface.sendLineInf(mainPanel.stationid, daliwebinf.LINEID, dt, out code, out msg))
                        {
                            MessageBox.Show("发送检测站上线信息失败\r\ncode=" + code + "\r\nmessage=" + msg);
                        }
                    }
                }
                else if (NetMode == CCNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_ccinf();
                    ccsocket = new chenChuangSocketControl();
                    ccsocket.initSocket(ccsocketinf.IP, ccsocketinf.PORT);
                    string socketMsg = ccsocket.init_equipment();
                    if (socketMsg == "连接成功")
                    {
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接诚创联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接诚创联网服务器成功");

                    }
                    else
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接诚创联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接诚创联网服务器失败,将工作在单机模式");
                    }

                }
                else if (NetMode == JINGHUANETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_jhinf();
                    try
                    {
                        string optime = "";
                        string opstime = "";
                        string opetime = "";
                        jhinterface = new JHWebClient.JHinterface(jhwebinf.weburl, jhwebinf.safepwd, jhwebinf.stationid, jhwebinf.lineid);
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接金华联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接金华联网服务器成功");
                        /*string resultno;
                        string resultdesc;
                        checkResultModel checkmodel = new checkResultModel();
                        jhinterface.CheckPrintIsEffective("0000001", out resultno, out resultdesc, out checkmodel);*/
                        string oracleConStr = "Data Source=" + jhwebinf.dbip + ";User ID=" + jhwebinf.dbuser + ";password=" + jhwebinf.dbpassword;
                        jhoracle = new MyOracle(oracleConStr);
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "1", out jhcgjinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "1", out jhcgjinf))
                                ini.INIIO.saveLogInf("获取测功机信息失败");
                            else
                                ini.INIIO.saveLogInf("获取测功机信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取测功机信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "2", out jhfqyinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "2", out jhfqyinf))
                                ini.INIIO.saveLogInf("获取废气仪信息失败");
                            else
                                ini.INIIO.saveLogInf("获取废气仪信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取废气仪信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "3", out jhydjinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "3", out jhydjinf))
                                ini.INIIO.saveLogInf("获取烟度计信息失败");
                            else
                                ini.INIIO.saveLogInf("获取烟度计信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取烟度计信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "4", out jhdzhjinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "4", out jhdzhjinf))
                            {
                                ini.INIIO.saveLogInf("获取电子环境信息仪信息失败");
                            }
                            else
                                ini.INIIO.saveLogInf("获取电子环境信息仪信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取电子环境信息仪信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "5", out jhzsjinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "5", out jhzsjinf))
                            {
                                ini.INIIO.saveLogInf("获取发动机转速仪信息失败");
                            }
                            else
                                ini.INIIO.saveLogInf("获取发动机转速仪信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取发动机转速仪信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "6", out jhlljinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "6", out jhlljinf))
                            {
                                ini.INIIO.saveLogInf("获取流量计信息失败");
                            }
                            else ini.INIIO.saveLogInf("获取流量计信息成功");
                        }
                        else ini.INIIO.saveLogInf("获取流量计信息成功");

                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "7", out jhlzinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "7", out jhlzinf))
                            {
                                ini.INIIO.saveLogInf("获取滤纸烟度计信息失败");
                            }
                            else
                                ini.INIIO.saveLogInf("获取滤纸烟度计信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取滤纸烟度计信息成功");
                        if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "8", out jhgkjinf))
                        {
                            if (!jhoracle.getDeviceInf(jhwebinf.stationid, jhwebinf.lineid, "8", out jhgkjinf))
                            {
                                ini.INIIO.saveLogInf("获取工控机信息失败");
                            }
                            else
                                ini.INIIO.saveLogInf("获取工控机信息成功");
                        }
                        else
                            ini.INIIO.saveLogInf("获取工控机信息成功");

                        string synctime = jhoracle.getSynTime();
                        string[] datetimearray = synctime.Split(' ');
                        string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                        optime = DateTime.Parse(synctime).ToString("yyyy-MM-dd HH:mm:ss");
                        opstime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                        opetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                        if (jhgkjinf != null)
                        {
                            jhoracle.writeSyncRecord(guid, jhwebinf.stationid, jhwebinf.lineid, nowUser.userName, optime, opstime, opetime, jhgkjinf);
                            ini.INIIO.saveLogInf("同步金华联网时间成功:" + datetimereceive);
                        }
                        thisLineName = stationinfmodel.STATIONNAME + "_" + jhwebinf.lineid;
                        labelStationName.Text = thisLineName;
                        /*labelLine.Text = "☆☆☆" + thisLineName + "☆☆☆";*/


                    }
                    catch (Exception er)
                    {
                        ini.INIIO.saveLogInf("发生异常：" + er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接金华联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接金华联网服务器失败,将工作在单机模式");
                    }
                }
                else if (NetMode == AHNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_ahinf();
                    try
                    {
                        
                        ahinterface = new AhWebClient.Ahinterface(ahwebinf.weburl,ahwebinf.version);
                        ahinterface.initLineId(ahwebinf.lineid);
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接安徽联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接安徽联网服务器成功");
                        int ahresult;
                        string ahErrMsg = "";
                        List<string> urllist = new List<string>();
                        List<string> messagelist = new List<string>();
                        if (ahinterface.Sync(out ahresult, out ahErrMsg, out syncinf, out urllist, out messagelist))
                        {
                            string noticemsg = "";
                            for (int i = 0; i < urllist.Count; i++)
                            {
                                noticemsg += urllist[i] + " " + messagelist[i] + "\r\n";
                            }
                            string[] datetimearray = syncinf.Time.Split(' ');
                            string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                            SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                            ini.INIIO.saveLogInf("同步安徽联网时间成功:" + datetimereceive);
                        }

                    }
                    catch
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接安徽联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接安徽联网服务器失败,将工作在单机模式");
                    }
                }
                else if (NetMode == NHNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_nhinf();
                    try
                    {
                        nhinterface = new NhWebControl(nhwebinf.weburl, stationid, nhwebinf.lineid);
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接南华联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接南华联网服务器成功");
                        int nhresult, nhexceptionCode;
                        string nhErrMsg = "", nhExpMsg = "";
                        DateTime syntime = nhinterface.GetTimeRequest(out nhresult, out nhErrMsg, out nhexceptionCode, out nhExpMsg);
                        if (nhresult == 0 && nhexceptionCode == 0)
                        {
                            SetSystemDateTime.SetLocalTimeByStr(syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                            ini.INIIO.saveLogInf("同步南华联网时间成功:" + syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        nhinterface.SendUploadEquipmentStatus("1", out nhresult, out nhErrMsg, out nhexceptionCode, out nhExpMsg);

                    }
                    catch
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接南华联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接南华联网服务器失败,将工作在单机模式");
                    }
                }
                else if (NetMode == ORTNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_ortinf();
                    ortsocket = new ortSocketControl();
                    ortsocket.initSocket(ortsocketinf.IP, ortsocketinf.PORT);
                    string socketMsg = ortsocket.init_equipment();
                    if (socketMsg == "连接成功")
                    {
                        bool connectsucces = true;
                        ortsocket.close_socket();
                        isNetUsed = true;
                        string msg = "";
                        msg += "工作状态：连接欧润特联网服务器成功";
                        isNetUsed = true;
                        string result, err, datetimeSyc, version;
                        if (ortsocket.SendConnectionTest(stationid, stationinfmodel.StationCompany + lineid, out result, out err, out version, out datetimeSyc))
                        {
                            if (result == "TRUE")
                            {
                                msg += ",获取版本号成功：" + version;
                                /*string[] datetimearray = DateTime.Parse(datetimeSyc).ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                                string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                msg += ",获取服务器同步时间成功：" + datetimeSyc;*/
                            }
                            else
                            {
                                msg += ",获取版本号失败：" + err;
                                connectsucces = false;
                            }
                        }
                        else
                        {
                            msg += ",获取版本号失败：" + err;
                            connectsucces = false;
                        }
                        if (ortsocket.SendGetDatatime(out result, out err, out datetimeSyc))
                        {
                            if (result == "TRUE")
                            {
                                string[] datetimearray = DateTime.Parse(datetimeSyc).ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                                string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                msg += ",获取服务器同步时间成功：" + datetimeSyc;
                            }
                            else
                            {
                                msg += ",获取服务器同步时间失败：" + err;
                                connectsucces = false;
                            }
                        }
                        else
                        {
                            msg += ",获取服务器同步时间失败：" + err;
                            connectsucces = false;
                        }
                        toolStripLabel1NetStatus.Text = msg;
                        ini.INIIO.saveLogInf(msg);
                        if (connectsucces == false)
                        {
                            isNetUsed = false;
                            MessageBox.Show("警告", msg + "\r\n" + "将工作在单机模式");
                            toolStripLabel1NetStatus.Text = "工作状态：连接欧润特联网服务器失败,将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接欧润特联网服务器失败,将工作在单机模式");
                        }

                    }
                    else
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接欧润特联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接欧润特联网服务器失败,将工作在单机模式");
                    }

                }
                else if (NetMode == ACNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_Acinf();
                    if (acsocketinf.AREA == ACAREA_NN)
                    {
                        SocketControlNn.init_socket(acsocketinf.IP, int.Parse(acsocketinf.PORT), this.Handle, recvMsg, conntMsg, closeMsg, 0);
                        if (SocketControlNn.CreateSocketClient(SocketControlNn.serverIP, SocketControlNn.serverPort, SocketControlNn.intptr, SocketControlNn.socketRecvMsg, SocketControlNn.nsocketConnectMsg, SocketControlNn.nsocketCloseMsg, 0))
                        {
                            isNetUsed = true;
                            toolStripLabel1NetStatus.Text = "工作状态：连接安车联网服务器成功";
                            ini.INIIO.saveLogInf("工作状态：连接安车服务器成功");

                        }
                        else
                        {
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接安车联网服务器失败,将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接安车联网服务器失败,将工作在单机模式");
                        }
                    }
                    else
                    {
                        SocketControl.init_socket(acsocketinf.IP, int.Parse(acsocketinf.PORT), this.Handle, recvMsg, conntMsg, closeMsg, 0);
                        if (SocketControl.CreateSocketClient(SocketControl.serverIP, SocketControl.serverPort, SocketControl.intptr, SocketControl.socketRecvMsg, SocketControl.nsocketConnectMsg, SocketControl.nsocketCloseMsg, 0))
                        {
                            isNetUsed = true;
                            toolStripLabel1NetStatus.Text = "工作状态：连接安车联网服务器成功";
                            ini.INIIO.saveLogInf("工作状态：连接安车服务器成功");

                        }
                        else
                        {
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接安车联网服务器失败,将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接安车联网服务器失败,将工作在单机模式");
                        }
                    }
                }
                else if (mainPanel.useHyDatabase)//仅对乌海某检测站有用，该站从华燕数据库读取车辆信息，且信息是按安车联网格式存放，所以这里对安车字典进行初始化
                {
                    init_Acinf();
                }
                else if (NetMode == NEUSOFTNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_neusoftinf();
                    if (neusoftsocketinf.AREA == NEU_LNAS)
                    {
                        sysocket = new SyNeusoft(neusoftsocketinf.IP, neusoftsocketinf.EISID);
                        string result, inf, timestring;
                        if (!sysocket.GetTimeRequest(out result, out inf, out timestring))
                        {
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接东软联网服务器失败,将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接东软联网服务器失败,将工作在单机模式");
                        }
                        else
                        {
                            string[] datetimearray = timestring.Split(' ');
                            string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                            SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                        }
                    }
                    else
                    {
                        neusoftsocket.EISID = neusoftsocketinf.EISID;
                        neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                        if (neusoftsocketinf.AREA == NEU_V301)
                        {
                            string drivername = "";
                            string timestring = neusoftsocket.GetTimeRequest();
                            if (timestring == "no ACK")
                            {
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接东软联网服务器失败,将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接东软联网服务器失败,将工作在单机模式");
                            }
                            else
                            {
                                try
                                {
                                    string[] datetimearray = timestring.Split(' ');
                                    string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                    SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                    neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                                    DataTable dtuser = neusoftsocket.GetUsers();
                                    if (dtuser != null)
                                    {
                                        for (int i = 0; i < dtuser.Rows.Count; i++)
                                        {
                                            if (dtuser.Rows[i]["UserType"].ToString() == "0")
                                            {
                                                NeusoftOperatorNameList.Add(dtuser.Rows[i]["Account"].ToString());
                                            }
                                            else
                                            {
                                                NeusoftDriverNameList.Add(dtuser.Rows[i]["Account"].ToString());
                                            }
                                        }
                                    }
                                    if (NeusoftDriverNameList.Count == 0)
                                    {
                                        MessageBox.Show("获取到引车员列表为空，不能进行联网检测");
                                        isNetUsed = false;
                                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                    }
                                    if (NeusoftOperatorNameList.Count == 0)
                                    {
                                        MessageBox.Show("获取到检测员列表为空，不能进行联网检测");
                                        isNetUsed = false;
                                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                    }
                                    mainPanel.nowUser.userName = NeusoftOperatorNameList[0];
                                    mainPanel.nowUser.userPassword = "111111";
                                    mainPanel.nowUser.ycyuserName = NeusoftDriverNameList[0];
                                    mainPanel.nowUser.ycyuserPassword = "111111";
                                }
                                catch (Exception er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else if (neusoftsocketinf.AREA == NEU_YNZT)
                        {
                            string drivername = "";
                            string timestring = neusoftsocket.GetTimeRequestV21(out drivername);
                            if (timestring == "no ACK")
                            {
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接东软联网服务器失败,将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接东软联网服务器失败,将工作在单机模式");
                            }
                            else
                            {
                                try
                                {
                                    string[] datetimearray = timestring.Split(' ');
                                    string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                    SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                    string[] drivernamearray = drivername.Split(',');
                                    if (drivernamearray.Length == 0)
                                    {
                                        NeusoftDriverNameList.Add("testjc");
                                        MessageBox.Show("获取到引车员ID为空,可能会导致检测无法进行", "警告");
                                    }
                                    else
                                    {
                                        for (int i = 0; i < drivernamearray.Length; i++)
                                        {
                                            NeusoftDriverNameList.Add(drivernamearray[i]);
                                        }
                                    }
                                }
                                catch (Exception er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else
                        {
                            string timestring = neusoftsocket.GetTimeRequest();
                            if (timestring == "no ACK")
                            {
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接东软联网服务器失败,将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接东软联网服务器失败,将工作在单机模式");
                            }
                            else
                            {
                                string[] datetimearray = timestring.Split(' ');
                                string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                            }
                        }
                    }
                }
                else if (NetMode == mainPanel.JIANGSHUNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    jsinterface = new jsSocketControl();
                    bool jsstatus;
                    string jserrMsg = "";
                    jsinterface.connectServer(out jsstatus, out jserrMsg);
                    if (jsstatus)
                    {
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：江苏联网模式";
                        ini.INIIO.saveLogInf("工作状态：江苏联网模式");
                    }
                    else
                    {
                        MessageBox.Show("ConnetServer失败", "连接联网服务器失败");
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                    }
                }
                else if (NetMode == mainPanel.JXNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    try
                    {
                        init_jxinf();
                        jxinterface = new jxWebControl(jxwebinf.url, jxwebinf.user, jxwebinf.password);
                        bool jxstatus;
                        string code, msg;
                        //string jserrMsg = "";
                        jxstatus = jxinterface.sendAuthorizationDataWithVersion();
                        if (jxinterface.fetchServerTime(out code, out msg))
                        {
                            string[] datetimearray = DateTime.Parse(msg).ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                            string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                            SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                        }
                        else
                        {
                            MessageBox.Show("fetchServerTime失败，code:" + code + "\r\nmessage:" + msg);
                        }
                        toolStripLabel1NetStatus.Text = "工作状态：连接平台服务器成功，将工作在联网模式";

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("连接到联网服务器失败", er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                    }
                }
                else if (NetMode == mainPanel.EZNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    try
                    {
                        isNetUsed = true;
                        init_ezinf();
                        ezinterface = new EzWebClient.Ezclient(ezwebinf.weburl);
                        toolStripLabel1NetStatus.Text = "工作状态：连接鄂州服务器成功，将工作在联网模式";
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("连接到联网服务器失败", er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");

                    }

                }
                else if (NetMode == mainPanel.HHZNNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器成功，将工作在联网模式";
                    try
                    {
                        isNetUsed = true;
                        init_hhzinf();
                        hhzinterface = new Hhzclient(hhzwebinf.weburl);
                        System.Collections.Hashtable hthhz1 = new System.Collections.Hashtable();
                        System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                        hthhz1.Add("tsno", mainPanel.stationid);
                        hthhz2.Add("type", "QUERY");
                        hthhz2.Add("filter", hthhz1);
                        string code, msg;
                        try
                        {
                            string jsonReturnString = "";
                            if (hhzinterface.queryData( hthhz2, HhzWebClient.Hhzclient.DATALX.JCRYJBXX, out code, out msg, out jsonReturnString))
                            {
                                try
                                {
                                    hhzpersonlist =Newtonsoft.Json.JsonConvert.DeserializeObject<List<hhzperson>>(jsonReturnString);
                                }
                                catch (Exception er)
                                {
                                    ini.INIIO.saveLogInf("解析人员信息出现异常：" + er.Message);
                                    MessageBox.Show("解析人员信息出现异常：" + er.Message);
                                    isNetUsed = false;
                                    toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                    ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                                }
                            }
                            else
                            {
                                MessageBox.Show("读取人员信息失败：\r\ncode="+code+"\r\nmsg=" + msg);
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("读取人员信息出现异常：" + er.Message);
                            MessageBox.Show("读取人员信息出现异常：" + er.Message);
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                        }
                        try
                        {
                            string jsonReturnString = "";
                            if (hhzinterface.queryData(hthhz2, HhzWebClient.Hhzclient.DATALX.JCXJBXX, out code, out msg, out jsonReturnString))
                            {
                                try
                                {
                                    List<hhzjcx> hhzjcxlist = new List<hhzjcx>();
                                    hhzjcxlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<hhzjcx>>(jsonReturnString);
                                    foreach(hhzjcx childjcxxx in hhzjcxlist)
                                    {
                                        if(childjcxxx.testlineno==mainPanel.lineid)
                                        {
                                            if(childjcxxx.status!="01")
                                            {
                                                ini.INIIO.saveLogInf("该检测线联网状态不正常：" + childjcxxx.status);
                                                MessageBox.Show("该检测线联网状态不正常：" + childjcxxx.status);
                                                isNetUsed = false;
                                                toolStripLabel1NetStatus.Text = "工作状态：该检测线联网状态不正常，将工作在单机模式";
                                                ini.INIIO.saveLogInf("工作状态：该检测线联网状态不正常，将工作在单机模式");
                                                break;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception er)
                                {
                                    ini.INIIO.saveLogInf("解析检测线信息出现异常：" + er.Message);
                                    MessageBox.Show("解析检测线信息出现异常：" + er.Message);
                                    isNetUsed = false;
                                    toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                    ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                                }
                            }
                            else
                            {
                                MessageBox.Show("读取检测线信息失败：\r\ncode=" + code + "\r\nmsg=" + msg);
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                            }
                        }
                        catch (Exception er)
                        {
                            ini.INIIO.saveLogInf("读取检测线信息失败：" + er.Message);
                            MessageBox.Show("读取检测线信息失败：" + er.Message); isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                        }
                        toolStripLabel1NetStatus.Text = "工作状态：连接红河州服务器成功，将工作在联网模式";
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("连接到红河州联网服务器失败", er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");

                    }

                }
                else if (NetMode == mainPanel.ZKYTNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    toolStripLabel1NetStatus.Text = "工作状态：工作在中科宇图联网模式";
                    try
                    {
                        isNetUsed = true;
                        init_zkytinf();
                        if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD || mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                        {
                            if (get_zkytRegCode())
                            {
                                if (zkytwebinf.regtime.Day != DateTime.Now.Day)
                                {
                                    MessageBox.Show("启动授权码上次更新非当日，建议重新在网页启动工控软件更新授权码");

                                }
                            }
                            else
                            {
                                MessageBox.Show("读取启动授权码失败，请在网页中启动工控软件更新授权码");
                            }
                        }
                        if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                        {
                            yichangInterface = new YichangInter.DeviceSwapIfaceImplService(zkytwebinf.weburl);
                        }
                        else if(mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                        {
                            yichangInterfaceOther = new DeviceSwapIfaceImplServiceOther(zkytwebinf.weburl);
                        }
                        else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                        {
                            string result = "";
                            string info = "";
                            string accesstoken = "";
                            yichangInterfaceYnbs = new DeviceSwapIfaceImplServiceYnBs(zkytwebinf.weburl);
                            mainPanel.xmlanalysis.ReadAccessTokenString(yichangInterfaceYnbs.getAccessToken(zkytwebinf.lineID),out result,out info,out accesstoken);
                            if (result == "0")
                            {
                                MessageBox.Show("调取访问令牌失败:"+info);
                            }
                            else
                            { zkytwebinf.regcode = accesstoken; }
                        }
                        webthread = new WebThread();
                    }
                    catch
                    { }

                }
                else if (NetMode == mainPanel.HNNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    try
                    {
                        init_hnhyinf();
                        hninterface = new hnWebControl(hnhywebinf.weburl, mainPanel.nowUser.userPassword);
                        bool hnstatus;
                        string code, msg;

                        hnstatus = hninterface.testConnect(out code, out msg);
                        if (!hnstatus)
                        {
                            MessageBox.Show("连接测试失败，code:" + code + "\r\nmessage:" + msg);
                        }
                        else
                        {
                            Hashtable ht = new Hashtable();
                            ht.Add("jczbh", hnhywebinf.stationid);
                            ht.Add("jcxbh", hnhywebinf.lineid);
                            ht.Add("dlzh", nowUser.userName);
                            ht.Add("dlkl", hninterface.md5key);
                            string forcekey = "";
                            if (hninterface.loginIn(ht, out forcekey, out code, out msg))
                            {
                                string datetimestring = "";
                                if (hninterface.queryTime(out datetimestring, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("同步时间:" + datetimestring);
                                    string[] datetimearray = DateTime.Parse(datetimestring).ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                                    string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                    SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                    ini.INIIO.saveLogInf("同步时间成功");
                                }
                                else
                                {
                                    ini.INIIO.saveLogInf("同步时间失败,code" + code + ",msg:" + msg);
                                }
                                toolStripLabel1NetStatus.Text = "工作状态：连接平台服务器成功，将工作在联网模式";
                            }
                            else if (msg.Contains("强制登录"))
                            {
                                if (MessageBox.Show(msg + "\r\n是否进行强制登录？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    Hashtable ht2 = new Hashtable();
                                    ht2.Add("jczbh", hnhywebinf.stationid);
                                    ht2.Add("jcxbh", hnhywebinf.lineid);
                                    ht2.Add("dlzh", nowUser.userName);
                                    ht2.Add("dlkl", hninterface.md5key);
                                    ht2.Add("qzdlsqm", hninterface.autoriseForceKey);
                                    if (hninterface.loginInForce(ht2, out code, out msg))
                                    {
                                        string datetimestring = "";
                                        if (hninterface.queryTime(out datetimestring, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("同步时间:" + datetimestring);
                                            string[] datetimearray = DateTime.Parse(datetimestring).ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                                            string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                                            SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                                            ini.INIIO.saveLogInf("同步时间成功");
                                        }
                                        else
                                        {
                                            ini.INIIO.saveLogInf("同步时间失败,code" + code + ",msg:" + msg);
                                        }
                                        toolStripLabel1NetStatus.Text = "工作状态：连接平台服务器成功，将工作在联网模式";
                                    }
                                    else
                                    {
                                        MessageBox.Show("从业人员强制登录失败，code:" + code + "\r\nmessage:" + msg);
                                        isNetUsed = false;
                                        toolStripLabel1NetStatus.Text = "工作状态：登录平台失败，将工作在单机模式";
                                        ini.INIIO.saveLogInf("工作状态：登录平台失败，将工作在单机模式");
                                    }
                                }
                                else
                                {
                                    isNetUsed = false;
                                    toolStripLabel1NetStatus.Text = "工作状态：登录平台失败，将工作在单机模式";
                                    ini.INIIO.saveLogInf("工作状态：登录平台失败，将工作在单机模式");
                                }
                            }
                            else
                            {
                                MessageBox.Show("从业人员登录失败，code:" + code + "\r\nmessage:" + msg);
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：登录平台失败，将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：登录平台失败，将工作在单机模式");
                            }
                        }

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("连接到联网服务器失败\r\nmsg:" + er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");
                    }
                }
                else if (NetMode == mainPanel.TYNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    if (mainPanel.tynettype == mainPanel.TYNETTYPE_NNDL)
                    {
                        initAcDlDic();
                    }
                    else if (mainPanel.tynettype == mainPanel.TYNETTYPE_SDYT)
                    {
                        initAcDlDic();
                    }
                    else
                    {
                        initAcDic();
                    }
                    try
                    {
                        DateTime synDatetime = logininfcontrol.getDateTime();
                        string[] datetimearray = synDatetime.ToString("yyyy-MM-dd HH:mm:ss.fff").Split(' ');
                        string datetimereceive = datetimearray[0] + " " + datetimearray[1];
                        SetSystemDateTime.SetLocalTimeByStr(datetimereceive);
                        conforsql = new ConnForSQL();
                        toolStripLabel1NetStatus.Text = "工作状态：通用联网模式(" + mainPanel.tynettype + ")";
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("同步时间失败", er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接联网服务器失败，将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接联网服务器失败，将工作在单机模式");

                    }
                }
                else if (NetMode == GUILINNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_glinf();
                    try
                    {
                        gxinterface = new GxWebClient.GxInterface(glwebinf.weburl, "GLSTVIM", glwebinf.user, glwebinf.password);
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接桂林联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接桂林联网服务器成功");
                        string result = "", errmsg = "";
                        if (gxinterface.Sync(stationid, out result, out errmsg))
                        {
                            DateTime syntime = DateTime.Parse(errmsg);
                            SetSystemDateTime.SetLocalTimeByStr(syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                            ini.INIIO.saveLogInf("同步服务器联网时间成功:" + syntime.ToString("yyyy-MM-dd HH:mm:ss"));

                        }
                        else
                        {
                            MessageBox.Show("同步时间失败：" + errmsg);
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接桂林联网服务器失败，将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接桂林联网服务器失败，将工作在单机模式");
                        }

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("初始化桂林联网接口失败：" + er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接桂林联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接桂林联网服务器失败,将工作在单机模式");
                    }
                }
                else if(NetMode == PNNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_pninf();
                    try
                    {
                        pninterface = new GxWebClient.Pnservice(pnwebinf.Url, pnwebinf.User, pnwebinf.Pwd, pnwebinf.cityCode, pnwebinf.stationCode, pnwebinf.lineCode, pnwebinf.factoryNo);
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接平南联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接平南联网服务器成功");
                        string sys_time = "", errmsg = "";
                        if (pninterface.GetSystemTime(ref sys_time, ref errmsg))
                        {
                            try
                            {
                                DateTime syntime = DateTime.Parse(sys_time);
                                SetSystemDateTime.SetLocalTimeByStr(syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                                ini.INIIO.saveLogInf("同步服务器联网时间成功:" + syntime.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            catch (Exception er)
                            {
                                MessageBox.Show("同步时间失败：" + er.Message);
                                isNetUsed = false;
                                toolStripLabel1NetStatus.Text = "工作状态：连接平南联网服务器失败，将工作在单机模式";
                                ini.INIIO.saveLogInf("工作状态：连接平南联网服务器失败，将工作在单机模式");
                            }
                        }
                        else
                        {
                            MessageBox.Show("同步时间失败：" + errmsg);
                            isNetUsed = false;
                            toolStripLabel1NetStatus.Text = "工作状态：连接平南联网服务器失败，将工作在单机模式";
                            ini.INIIO.saveLogInf("工作状态：连接平南联网服务器失败，将工作在单机模式");
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("初始化桂林联网接口失败：" + er.Message);
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接桂林联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接桂林联网服务器失败,将工作在单机模式");
                    }
                }
                else if (NetMode == XBNETMODE)
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "Y", @".\appConfig.ini");
                    init_xbinf();
                    xbsocket = new carinfo.xbSocketControl();
                    if(xbsocket.init_equipment(xbwebinf.ip, xbwebinf.port))
                    {
                        isNetUsed = true;
                        toolStripLabel1NetStatus.Text = "工作状态：连接喜邦联网服务器成功";
                        ini.INIIO.saveLogInf("工作状态：连接喜邦联网服务器成功");
                        string result = "", errmsg = "";
                        carinfo.XB_AUTHENTCATION xmodel = new carinfo.XB_AUTHENTCATION();
                        xmodel.version = xbwebinf.version;
                        xmodel.certificate = xbwebinf.certificateNo;
                        xmodel.station_id = stationid;
                        xmodel.detect_line_id = xbwebinf.lineid;
                        xmodel.hd_seria_number = xbwebinf.diskNo;
                        if (!xbsocket.Send_AUTHENTCATION(xmodel, out result, out errmsg))
                        {

                            MessageBox.Show("向检测站中心数据服务认证失败：" + errmsg);
                            isNetUsed = false;
                        }
                        DateTime syndatetime;
                        if (xbsocket.Send_TIME_SYNC(out syndatetime, out result, out errmsg))
                        {
                            SetSystemDateTime.SetLocalTimeByStr(syndatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                            ini.INIIO.saveLogInf("同步服务器联网时间成功:" + syndatetime.ToString("yyyy-MM-dd HH:mm:ss"));

                        }
                        else
                        {
                            MessageBox.Show("同步时间失败：" + errmsg);
                            isNetUsed = false;
                        }
                        if (!xbsocket.Send_GET_USERS(out xb_user_list, out result, out errmsg))
                        {
                            MessageBox.Show("获取用户列表失败：" + errmsg);
                            isNetUsed = false;
                        }

                    }
                    if (isNetUsed)
                    {
                        xbUserLogin xbuserlogin = new xbUserLogin();
                        xbuserlogin.ShowDialog();
                    }
                    if(!isNetUsed)
                    {
                        isNetUsed = false;
                        toolStripLabel1NetStatus.Text = "工作状态：连接喜邦联网服务器失败,将工作在单机模式";
                        ini.INIIO.saveLogInf("工作状态：连接喜邦联网服务器失败,将工作在单机模式");
                    }
                }
                else
                {
                    ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "N", @".\appConfig.ini");
                    isNetUsed = false;
                    toolStripLabel1NetStatus.Text = "工作状态：本地工作模式";
                    ini.INIIO.saveLogInf("工作状态：本地工作模式");
                }

            }
            else
            {
                ini.INIIO.WritePrivateProfileString("工作模式", "联网运行", "N", @".\appConfig.ini");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName")
                    panelMain.Controls.Remove(childpenal);
            }
            carLogin childcarlogin = new carLogin();
            childcarlogin.TopLevel = false;
            childcarlogin.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Show();
        }
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName")
                    panelMain.Controls.Remove(childpenal);
            }
            reportViewVmas childcarlogin = new reportViewVmas();
            childcarlogin.TopLevel = false;
            childcarlogin.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void testEz()
        {
            init_ezinf();
            ezinterface = new EzWebClient.Ezclient(ezwebinf.weburl);
            string code, msg;
            try
            {
                EzWebClient.PowerLossData data = new EzWebClient.PowerLossData("3.02", "6.05", "907", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    "", DateTime.Now.ToString("HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd"), ezwebinf.lineid, "0.32", "0.57", "", "2017-09-12 10:10:10", ezwebinf.stationid, "01");
                ezinterface.uploadPowerLossData(data, out code, out msg);
            }
            catch { }
        }
        private void testxb()
        {
            carinfo.xbSocketControl xbsocket = new carinfo.xbSocketControl();
            carinfo.XB_SDS_RESULT_DATA sdsdata = new carinfo.XB_SDS_RESULT_DATA();
            carinfo.XB_RESULT_PUBLIC_DATA publicdata = new carinfo.XB_RESULT_PUBLIC_DATA();
            publicdata.JCFFBH = "1";
            publicdata.JCLSH = "2";
            publicdata.DLY = "3";
            publicdata.YCY = "4";
            publicdata.JCY = "5";
            publicdata.WD = "6";
            publicdata.DQY = "7";
            publicdata.SD = "8";
            sdsdata.SFZSKZ = "0";
            sdsdata.DSRpm = "0";
            sdsdata.GDSRpm = "0";
            sdsdata.DSHC = "0";
            sdsdata.GDSHC = "0";
            sdsdata.DSCO = "0";
            sdsdata.GDSCO = "0";
            sdsdata.GDSLmd = "0";
            sdsdata.DSCurveCount0 = "0";
            sdsdata.DSCurveCount1 = "0";
            sdsdata.GDSCurveCount0 = "0";
            sdsdata.GDSCurveCount1 = "0";
            sdsdata.DSHCCurve0 = "0";
            sdsdata.DSHCCurve1 = "0";
            sdsdata.GDSHCCurve0 = "0";
            sdsdata.GDSHCCurve1 = "0";
            sdsdata.DSCOCurve0 = "0";
            sdsdata.DSCOCurve1 = "0";
            sdsdata.GDSCOCurve0 = "0";
            sdsdata.GDSCOCurve1 = "0";
            sdsdata.DSCO2Curve0 = "0";
            sdsdata.DSCO2Curve1 = "0";
            sdsdata.GDSCO2Curve0 = "0";
            sdsdata.GDSCO2Curve1 = "0";
            sdsdata.DSO2Curve0 = "0";
            sdsdata.DSO2Curve1 = "0";
            sdsdata.GDSO2Curve0 = "0";
            sdsdata.GDSO2Curve1 = "0";
            sdsdata.GDSLmdCurve0 = "0";
            sdsdata.GDSLmdCurve1 = "0";
            sdsdata.DSRpmCurve0 = "0";
            sdsdata.DSRpmCurve1 = "0";
            sdsdata.GDSRpmCurve0 = "0";
            sdsdata.GDSRpmCurve1 = "0";
            sdsdata.DSJYWDCurve0 = "0";
            sdsdata.DSJYWDCurve1 = "1";
            sdsdata.GDSJYWDCurve0 = "0";
            sdsdata.GDSJYWDCurve1 = "1";
            string result, msg;
            //xbsocket.Send_SDS_RESULT_DATA(publicdata, sdsdata, out result, out msg);

        }       
        private void mainPanel_Load(object sender, EventArgs e)
        {
            //testxb();
            INIIO.startpath = Application.StartupPath;
            /*init_ezinf();
            ezinterface = new EzWebClient.Ezclient(ezwebinf.weburl);
            EzWebClient.EzIfaJcDoubleidlelog data = new EzWebClient.EzIfaJcDoubleidlelog(
                                                                "0",
                                                                "1",
                                                               "1",
                                                                "1",
                                                               "1",
                                                                "1",
                                                                "1",
                                                               "1",
                                                                "1",
                                                                DateTime.Now.ToString("yyyyMMddHHmmss"),
                                                                mainPanel.stationid,
                                                                mainPanel.stationid + mainPanel.lineid,
                                                                "1",
                                                                "1"
                                                                );
            string code1, msg1;
            mainPanel.ezinterface.uploadEzIfaJcDoubleidlelog(data, out code1, out msg1);*/
            //carinfor.carIni carini = new carinfor.carIni();
            //string data = carini.readDataFormFile(@"C:\jcdatatxt\SpeedResult.ini");
            //testEz();
            Init_sc();
            
            nowUser.userName = "";
            disable_function("0");//登录前未获得权限
            if (checkRegister() == false)
            {
                labelStationName.Text = "该软件未注册";
                return;
            }
            //stafflogin.FormBorderStyle = FormBorderStyle.None;
            if (init_stationinf())
            {
                staffLogin stafflogin = new staffLogin();
                stafflogin.ShowDialog();                
                initNetConfig();
                if (userLoginSuccess)
                {
                    initCamera();
                    labelUserName.Text = nowUser.userName;
                    disable_function(nowUser.postID);
                    toolStripButtonGlwh.Enabled = (nowUser.postID == "6");
                    toolStripButtonXtcs.Enabled = ((nowUser.postID == "6")|| (nowUser.postID == "1"));
                    toolStripDropDownButtonPzgl.Enabled = (nowUser.postID == "6");
                    if (mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.NEUSOFTNETMODE)
                    {
                        
                        if (mainPanel.neusoftsocketinf.AREA == NEU_V301)
                        {
                            string result, info;
                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            if (neusoftsocket.loginUserv301(NeusoftOperatorNameList[0], "111111", "0", NeusoftDriverNameList[0],"111111", out result, out info))
                            {
                                if (result != "1")
                                {
                                    MessageBox.Show(info, "警告"); disable_function("0");
                                    disable_function("0");//登录前未获得权限
                                }
                            }
                            else
                            {
                                MessageBox.Show("登录指令发送失败和没有响应", "警告"); disable_function("0");
                                disable_function("0");//登录前未获得权限 }
                            }
                        }
                        else if (mainPanel.neusoftsocketinf.AREA == NEU_SDRZ)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            string loginresult = neusoftsocket.loginUser(nowUser.userName, nowUser.userPassword, "0", nowUser.ycyuserName, nowUser.ycyuserPassword);
                            if (loginresult != "3")
                            {
                                switch (loginresult)
                                {
                                    case "0": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "1": MessageBox.Show("该用户无此操作权限", "警告"); disable_function("0"); break;
                                    case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); disable_function("0"); break;
                                    case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); disable_function("0"); break;
                                    case "9": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); disable_function("0"); break;
                                    case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); disable_function("0"); break;
                                    case "-1": MessageBox.Show("服务器故障", "警告"); disable_function("0"); break;
                                    default: break;
                                }
                                disable_function("0");//登录前未获得权限
                            }
                        }
                        else if (mainPanel.neusoftsocketinf.AREA == NEU_FJS)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            string loginresult = neusoftsocket.loginUserFj(nowUser.userName, nowUser.userPassword, "0", "testjc", "111111");
                            if (loginresult != "3")
                            {
                                switch (loginresult)
                                {
                                    case "0": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "1": MessageBox.Show("该用户无此操作权限", "警告"); disable_function("0"); break;
                                    case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); disable_function("0"); break;
                                    case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); disable_function("0"); break;
                                    case "9": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); disable_function("0"); break;
                                    case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); disable_function("0"); break;
                                    case "-1": MessageBox.Show("服务器故障", "警告"); disable_function("0"); break;
                                    default: break;
                                }
                                disable_function("0");//登录前未获得权限
                            }
                        }
                        else if (mainPanel.neusoftsocketinf.AREA == NEU_V202)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            string loginresult = neusoftsocket.loginUserFj(nowUser.userName, nowUser.userPassword, "0", nowUser.userName, nowUser.userPassword);
                            if (loginresult != "3")
                            {
                                switch (loginresult)
                                {
                                    case "0": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "1": MessageBox.Show("该用户无此操作权限", "警告"); disable_function("0"); break;
                                    case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); disable_function("0"); break;
                                    case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); disable_function("0"); break;
                                    case "9": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); disable_function("0"); break;
                                    case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); disable_function("0"); break;
                                    case "-1": MessageBox.Show("服务器故障", "警告"); disable_function("0"); break;
                                    default: break;
                                }
                                disable_function("0");//登录前未获得权限
                            }
                        }
                        else if (mainPanel.neusoftsocketinf.AREA == NEU_YNKM || mainPanel.neusoftsocketinf.AREA == NEU_GZCJ)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            string loginresult = neusoftsocket.loginUserFj(nowUser.userName, nowUser.userPassword, "0", "testjc", "111111");
                            if (loginresult != "3")
                            {
                                switch (loginresult)
                                {
                                    case "0": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "1": MessageBox.Show("该用户无此操作权限", "警告"); disable_function("0"); break;
                                    case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); disable_function("0"); break;
                                    case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); disable_function("0"); break;
                                    case "9": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); disable_function("0"); break;
                                    case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); disable_function("0"); break;
                                    case "-1": MessageBox.Show("服务器故障", "警告"); disable_function("0"); break;
                                    default: break;
                                }
                                disable_function("0");//登录前未获得权限
                            }
                        }
                        else if (mainPanel.neusoftsocketinf.AREA == NEU_YNZT)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            neusoftsocket.init_equipment(neusoftsocketinf.IP, neusoftsocketinf.PORT);
                            string loginresult = neusoftsocket.loginUserYn(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", NeusoftDriverNameList[0]);
                            if (loginresult != "3")
                            {
                                switch (loginresult)
                                {
                                    case "0": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "1": MessageBox.Show("该用户无此操作权限", "警告"); disable_function("0"); break;
                                    case "2": MessageBox.Show("系统没有查到该车的车辆信息", "警告"); disable_function("0"); break;
                                    case "8": MessageBox.Show("外观检查不合格，不能检测！", "警告"); disable_function("0"); break;
                                    case "9": MessageBox.Show("该用户不存在", "警告"); disable_function("0"); break;
                                    case "10": MessageBox.Show("该车没有交费，不能检测！", "警告"); disable_function("0"); break;
                                    case "11": MessageBox.Show("该车已检测，不能再次检测！", "警告"); disable_function("0"); break;
                                    case "-1": MessageBox.Show("服务器故障", "警告"); disable_function("0"); break;
                                    default: break;
                                }
                                disable_function("0");//登录前未获得权限
                            }
                        }
                        else if (neusoftsocketinf.AREA == NEU_LNAS)
                        {
                            mainPanel.nowUser.ycyuserName = mainPanel.neusoftsocketinf.YCY;
                            mainPanel.nowUser.ycyuserPassword = logininfcontrol.requestUserPassword(mainPanel.nowUser.ycyuserName);

                            string result, inf, timestring;
                            if (!sysocket.loginUser(mainPanel.nowUser.userName, mainPanel.nowUser.userPassword, "0", out result, out inf))
                            {
                                MessageBox.Show("异常:" + result + "|信息:" + inf, "错误");
                                disable_function("0");
                            }
                            else
                            {
                                if (result != "0")
                                {
                                    MessageBox.Show("代码:" + result + "|信息:" + inf, "登录失败");
                                    disable_function("0");
                                }
                            }
                        }
                    }
                    else if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.JIANGSHUNETMODE)
                    {
                        bool jsstatus;
                        string jserrMsg = "";
                        string jsstationid, jslineid, jsinspectionId;
                        mainPanel.jsinterface.loginServer(mainPanel.nowUser.userName,mainPanel.nowUser.userPassword, out jsstatus, out jserrMsg);                        
                        if (!jsstatus)
                        {
                            MessageBox.Show(jserrMsg);
                            MessageBox.Show(jserrMsg, "登录失败");
                            ini.INIIO.saveLogInf("登录失败：" + jserrMsg);
                            disable_function("0");
                        }
                        else
                        {
                            ini.INIIO.saveLogInf("登录成功");
                            string ackstring = jsinterface.getBaseTypeInfo(out jsstatus, out jserrMsg);
                            if (ackstring != "")
                            {
                                MessageBox.Show("获取数据字典失败，内容："+ackstring,"获取字典失败");
                                ini.INIIO.saveLogInf("工作状态：获取数据字典失败");
                            }
                        }
                    }

                    worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    worklogdata.ProjectName = "操作日志";
                    worklogdata.Stationid = mainPanel.stationid;
                    worklogdata.Lineid = mainPanel.lineid;
                    worklogdata.Czy = mainPanel.nowUser.userName;
                    worklogdata.Data = "登录员" + nowUser.userName + "登录";
                    worklogdata.State = "成功";
                    worklogdata.Result = "";
                    worklogdata.Date = DateTime.Now;
                    worklogdata.Bzsm = "";
                    demarcatecontrol.saveWordLogByIni(worklogdata);
                }
                else
                {
                    labelUserName.Text = "未登录";
                    disable_function("0");
                    worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                    worklogdata.ProjectName = "操作日志";
                    worklogdata.Stationid = mainPanel.stationid;
                    worklogdata.Lineid = mainPanel.lineid;
                    worklogdata.Czy = mainPanel.nowUser.userName;
                    worklogdata.Data = "登录员" + nowUser.userName + "登录";
                    worklogdata.State = "失败";
                    worklogdata.Result = "";
                    worklogdata.Date = DateTime.Now;
                    worklogdata.Bzsm = "";
                    demarcatecontrol.saveWordLogByIni(worklogdata);
                }
                check_linezt();
                if (!linebdzt.linezt)
                {
                    toolStripButtonJC.Enabled = false;
                    foreach (Control childpenal in panelMain.Controls)
                    {
                        if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName")
                            panelMain.Controls.Remove(childpenal);
                    }
                    lineState childcarlogin = new lineState();
                    childcarlogin.TopLevel = false;
                    panelMain.Controls.Add(childcarlogin);
                    childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
                    childcarlogin.Show();
                }
                else
                {
                    toolStripButtonJC.Enabled = true;
                }
                init_files();
                startTime = DateTime.Now;
                actionTime = 0;
                ts1 = linemodel.LINEID + "号排放检测线";
                ts2 = "设备待命";
                if (equipconfig.DisplayMethod == "扩展")
                {
                    DriverShow showform = new DriverShow();
                    FormStartScreen(1, showform);
                    showform.Show();
                }
                timer1.Start();
            }
            else
            {
                toolStripButtonJcxpz.Enabled = true;
            }
        }
        /// 设置在第几个屏幕上启动。
        /// </summary>
        /// <param name="screen">屏幕(从0开始)</param>
        /// <param name="form">要启动的程序。</param>
        public void FormStartScreen(int screen, Form form)
        {
            if (Screen.AllScreens.Length <= 1)
                return;
            if (Screen.AllScreens.Length < screen)
                return;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(Screen.AllScreens[screen].Bounds.X, Screen.AllScreens[screen].Bounds.Y);
            form.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 默认在第1一个扩展屏幕上打开。
        /// </summary>
        /// <param name="form">要启动的程序。</param>
        public void FormStartScreen(Form form)
        {
            FormStartScreen(1, form);
        }
        public static void check_linezt()
        {
            linemodel = stationcontrol.getLineInf(stationid, lineid);
            linesbbd = stationcontrol.getLineDemarcateInf(stationid, lineid);
            linebdzt.lineLockReason = "";
            linebdzt.linezt = true;
            if (linemodel.ISLOCK)
            {
                linebdzt.linezt = false;
                linebdzt.lineLockReason += linemodel.LOCKREASON;
            }
            if (linesbbd.Yrenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Yrdate;
                linebdzt.yrts = int.Parse(bdsx.YRSX) - ts.Days;
                if (linebdzt.yrts<=0)
                {
                    linebdzt.yrzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "设备预热达到规定时限\r\n";
                }
                else
                {
                    linebdzt.yrzt = true;
                }
            }
            else
            {
                linebdzt.yrzt = true;
            }
            if (linesbbd.Zjenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Zjdate;
                int zjts = DateTime.Now.Day - linesbbd.Zjdate.Day;
                linebdzt.zjts = int.Parse(bdsx.ZJSX) - zjts;
                if (linebdzt.zjts <= 0)
                {
                    linebdzt.zjzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "设备自检达到规定时限\r\n";
                }
                else if(DateTime.Now.Day!=linesbbd.Zjdate.Day)
                {
                    linebdzt.zjts = 0;
                    linebdzt.zjzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "设备自检达到规定时限\r\n";
                }
                else
                {
                    linebdzt.zjzt = true;
                }
            }
            else
            {
                linebdzt.zjzt = true;
            }
            if (linesbbd.Hxenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Hxdate;
                linebdzt.hxts = int.Parse(bdsx.HXSX) -(ts.Days*24+ ts.Hours);
                if (linebdzt.hxts <= 0)
                {
                    linebdzt.hxzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "加载滑行测试达到规定时限\r\n";
                }
                else
                {
                    linebdzt.hxzt = true;
                }
            }
            else
            {
                linebdzt.hxzt = true;
            }
            if (linesbbd.Glenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Gldate;
                linebdzt.glts = int.Parse(bdsx.GLSX) - ts.Days;
                if (linebdzt.glts <= 0)
                {
                    linebdzt.glzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "惯量测试达到规定时限\r\n";
                }
                else
                {
                    linebdzt.glzt = true;
                }
            }
            else
            {
                linebdzt.glzt = true;
            }
            if (linesbbd.Jsglenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Jsgldate;
                linebdzt.jsglts = int.Parse(bdsx.JSGLSX) - (ts.Days * 24 + ts.Hours);
                if (linebdzt.jsglts <= 0)
                {
                    linebdzt.jsglzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "寄生功率测试达到规定时限\r\n";
                }
                else
                {
                    linebdzt.jsglzt = true;
                }
            }
            else
            {
                linebdzt.jsglzt = true;
            }
            if (linesbbd.Fxylowenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Fxylowdate;
                linebdzt.fxylowts = int.Parse(bdsx.FXYLOWSX) - (ts.Days * 24 + ts.Hours);
                if (linebdzt.fxylowts <= 0)
                {
                    linebdzt.fxylowzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪低量程检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.fxylowzt = true;
                }
            }
            else
            {
                linebdzt.fxylowzt = true;
            }

            if (linesbbd.Fxyhighenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Fxyhighdate;
                linebdzt.fxyhights = int.Parse(bdsx.FXYHIGHSX) - ts.Days;
                if (linebdzt.fxyhights <= 0)
                {
                    linebdzt.fxyhighzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪高量程检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.fxyhighzt = true;
                }
            }
            else
            {
                linebdzt.fxyhighzt = true;
            }

            if (linesbbd.Fxymidenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Fxymiddate;
                linebdzt.fxymidts = int.Parse(bdsx.FXYMIDSX) - ts.Days;
                if (linebdzt.fxymidts <= 0)
                {
                    linebdzt.fxymidzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪校准达到规定时限\r\n";
                }
                else
                {
                    linebdzt.fxymidzt = true;
                }
            }
            else
            {
                linebdzt.fxymidzt = true;
            }
            /*
            if (linesbbd.Fxylowmidenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Fxylowmiddate;
                linebdzt.fxylowmidts = int.Parse(bdsx.FXYLOWMIDSX) - ts.Days;
                if (linebdzt.fxylowmidts <= 0)
                {
                    linebdzt.fxylowmidzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪低中量程检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.fxylowmidzt = true;
                }
            }
            else
            {
                linebdzt.fxylowmidzt = true;
            }

            if (linesbbd.Fxyhighmidenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Fxyhighmiddate;
                linebdzt.fxyhighmidts = int.Parse(bdsx.FXYHIGHMIDSX) - ts.Days;
                if (linebdzt.fxyhighmidts <= 0)
                {
                    linebdzt.fxyhighmidzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪高中量程检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.fxyhighmidzt = true;
                }
            }
            else
            {
                linebdzt.fxyhighmidzt = true;
            }*/
            if (linesbbd.Ydjenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Ydjdate;
                linebdzt.ydjts = int.Parse(bdsx.YDJSX) - ts.Days;
                if (linebdzt.ydjts <= 0)
                {
                    linebdzt.ydjzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "烟度计日常检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.ydjzt = true;
                }
            }
            else
            {
                linebdzt.ydjzt = true;
            }
            if (linesbbd.Lljenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Lljdate;
                linebdzt.lljts = int.Parse(bdsx.LLJSX) - ts.Days;
                if (linebdzt.lljts <= 0)
                {
                    linebdzt.lljzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "流量计日常检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.lljzt = true;
                }
            }
            else
            {
                linebdzt.lljzt = true;
            }

            if (linesbbd.Yljenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Yljdate;
                linebdzt.yljts = int.Parse(bdsx.YLJSX) - ts.Days;
                if (linebdzt.yljts <= 0)
                {
                    linebdzt.yljzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "压力计静态校准达到规定时限\r\n";
                }
                else
                {
                    linebdzt.yljzt = true;
                }
            }
            else
            {
                linebdzt.yljzt = true;
            }
            if (linesbbd.Sdenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Sddate;
                linebdzt.sdts = int.Parse(bdsx.SDSX) - ts.Days;
                if (linebdzt.sdts <= 0)
                {
                    linebdzt.sdzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "速度校准达到规定时限\r\n";
                }
                else
                {
                    linebdzt.sdzt = true;
                }
            }
            else
            {
                linebdzt.sdzt = true;
            }

            if (linesbbd.Hjcsenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Hjcsdate;
                linebdzt.hjcsts = int.Parse(bdsx.HJCSSX) - ts.Days;
                if (linebdzt.hjcsts <= 0)
                {
                    linebdzt.hjcszt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "环境参数校准达到规定时限\r\n";
                }
                else
                {
                    linebdzt.hjcszt = true;
                }
            }
            else
            {
                linebdzt.hjcszt = true;
            }

            if (linesbbd.Zsjenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Zsjdate;
                linebdzt.zsjts = int.Parse(bdsx.ZSJSX) - ts.Days;
                if (linebdzt.zsjts <= 0)
                {
                    linebdzt.zsjzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "转速计校准达到规定时限\r\n";
                }
                else
                {
                    linebdzt.zsjzt = true;
                }
            }
            else
            {
                linebdzt.zsjzt = true;
            }
            if (linesbbd.Jlenable)
            {
                TimeSpan ts = DateTime.Now - linesbbd.Jldate;
                linebdzt.jlts = int.Parse(bdsx.JLSX) - (ts.Days * 24 + ts.Hours);
                if (linebdzt.jlts <= 0)
                {
                    linebdzt.jlzt = false;
                    linebdzt.linezt = false;
                    linebdzt.lineLockReason += "废气仪泄漏检查达到规定时限\r\n";
                }
                else
                {
                    linebdzt.jlzt = true;
                }
            }
            else
            {
                linebdzt.jlzt = true;
            }
        }
        private void disable_function(string quanxian)
        {
            if (quanxian != "0")
            {
                postModel postmodel = logininfcontrol.getPostQx(quanxian);
                toolStripButtonJC.Enabled = (postmodel.GONGWEIQX == "1") ? true : false;
                toolStripDropDownRcjc.Enabled = (postmodel.GONGWEIQX == "1") ? true : false;
                toolStripButtonDysz.Enabled = (postmodel.SETTINGSQX == "1") ? true : false;
                toolStripButtonSjcl.Enabled = (postmodel.PRINTQX == "1") ? true : false;
                toolStripButtonJcxpz.Enabled = (postmodel.SETTINGSQX == "1") ? true : false;
                toolStripButtonGlwh.Enabled = (quanxian=="6");
                toolStripButtonXtcs.Enabled = (quanxian == "6");
                toolStripDropDownButtonPzgl.Enabled = (postmodel.SETTINGSQX == "1") ? true : false;
            }
            else
            {
                toolStripButtonJC.Enabled =  false;
                toolStripDropDownRcjc.Enabled = false;
                toolStripButtonDysz.Enabled =  false;
                toolStripButtonSjcl.Enabled =false;
                toolStripButtonGlwh.Enabled = false;
                toolStripButtonXtcs.Enabled = false;
                toolStripDropDownButtonPzgl.Enabled = false;
                toolStripButtonJcxpz.Enabled = false;
            }
        }
        private void disable_button(Button button,string pictureName)
        {
            Image image=Image.FromFile("./png/"+pictureName+"2h.png");
            button.ForeColor=Color.Gray;
            button.Enabled = false;
            button.BackgroundImage = image;
        }
        private void enable_button(Button button, string pictureName)
        {
            Image image = Image.FromFile("./png/" + pictureName + "2.png");
            button.ForeColor = Color.RoyalBlue;
            button.Enabled = true;
            button.BackgroundImage = image;
        }
        int countgc = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int preActionTime;
            countgc++;
            if(countgc>=100)
            {
                ClearMemory();
                countgc = 0;
            }
            labelTime.Text = DateTime.Now.ToString();
            nowtime = DateTime.Now;
            TimeSpan timespan = nowtime - startTime;
            preActionTime = actionTime;
            actionTime = (int)(timespan.TotalMilliseconds / 60000f);
            if (labelx > -labellinewidth)
                labelx -= 5;
            else
                labelx = panellinewidth;
            /*labelLine.Location = new Point(labelx, 5);*/
            if (linebdzt.linezt)
            {
                toolStripButtonJC.Enabled = true;
            }
            else
            {
                toolStripButtonJC.Enabled = false;
            }
        }

        private void buttonReLogin_Click(object sender, EventArgs e)
        {
            staffLogin stafflogin = new staffLogin();
            stafflogin.ShowDialog();
            if (userLoginSuccess)
            {
                labelUserName.Text = nowUser.userName;
                disable_function("4");
            }
        }

        private void toolStripButtonJC_Click(object sender, EventArgs e)
        {
            if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.ZKYTNETMODE)
            {
                try
                {
                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD || mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                    {
                        if (get_zkytRegCode())
                        {
                            if (zkytwebinf.regtime.Day != DateTime.Now.Day)
                            {
                                MessageBox.Show("启动授权码上次更新非当日，重新在网页启动工控软件更新授权码后再进入车辆检测");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("读取启动授权码失败，请在网页中启动工控软件更新授权码后再进入车辆检测");
                            return;
                        }
                    }
                    string result="", info="";
                    INIIO.saveLogInf("初始化设备：AuthorizedID=" + zkytwebinf.regcode + ";设备型号：" + equipmodel.SBXH);

                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                    {
                        xmlanalysis.ReadACKString(yichangInterface.softVersion(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                    {
                        xmlanalysis.ReadACKString(yichangInterfaceOther.softVersion(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                    {
                        string accesstoken = "";
                        mainPanel.xmlanalysis.ReadAccessTokenString(yichangInterfaceYnbs.getAccessToken(zkytwebinf.lineID), out result, out info, out accesstoken);
                        if (result == "0")
                        {
                            MessageBox.Show("调取访问令牌失败:" + info);
                        }
                        else
                        {
                            mainPanel.zkytwebinf.regcode = accesstoken;
                        }
                        xmlanalysis.ReadACKString(yichangInterfaceYnbs.gkrjbbh(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    if (result == "0")
                    {
                        MessageBox.Show("向中心端发送工位软件版本号失败：\r\n" + zkytwebinf.regcode + "\r\n" + info);
                        return;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("调用接口发生异常：\r\n" + er.Message );
                    return;
                }
            }
            foreach (Control childpenal in panelMain.Controls)
            {
                if(childpenal.Name=="carLogin")
                {
                    try
                    {
                        childpenal.Controls.Remove(childpenal);
                        childpenal.Dispose();
                    }
                    catch
                    { }
                }
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName")
                {
                    panelMain.Controls.Remove(childpenal);
                }
            }
            isStartTimerInCarlogin = true;
            carLogin childcarlogin = new carLogin();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            printer childresult = new printer();
            childresult.TopLevel = false;
            childresult.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childresult);            
            childresult.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            systemConfig childconfig = new systemConfig();
            childconfig.TopLevel = false;
            panelMain.Controls.Add(childconfig);
            childconfig.Location = new Point(sc_width / 2 - childconfig.Width / 2, 20);
            childconfig.Show();

        }

        private void 本线状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_linezt();
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            lineState childcarlogin = new lineState();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void 惯量测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("惯量测试");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }
        private void 寄生滑行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("寄生功率测试");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 加载滑行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("滑行测试");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 废气仪标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("废气仪标定");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 流量计标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("流量计检测");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 设备预热ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("预热");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonReLogin_Click(object sender, EventArgs e)
        {
            staffLogin stafflogin = new staffLogin();
            stafflogin.ShowDialog();
            if (userLoginSuccess)
            {
                labelUserName.Text = nowUser.userName;
                disable_function(nowUser.postID);
                worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                worklogdata.ProjectName = "操作日志";
                worklogdata.Stationid = mainPanel.stationid;
                worklogdata.Lineid = mainPanel.lineid;
                worklogdata.Czy = mainPanel.nowUser.userName;
                worklogdata.Data = "登录员" + nowUser.userName + "登录";
                worklogdata.State = "成功";
                worklogdata.Result = "";
                worklogdata.Date = DateTime.Now;
                worklogdata.Bzsm = "";
                demarcatecontrol.saveWordLogByIni(worklogdata);
            }
            else
            {
                labelUserName.Text = "未登录";
                disable_function("0");
                worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
                worklogdata.ProjectName = "操作日志";
                worklogdata.Stationid = mainPanel.stationid;
                worklogdata.Lineid = mainPanel.lineid;
                worklogdata.Czy = mainPanel.nowUser.userName;
                worklogdata.Data = "登录员" + nowUser.userName + "登录";
                worklogdata.State = "失败";
                worklogdata.Result = "";
                worklogdata.Date = DateTime.Now;
                worklogdata.Bzsm = "";
                demarcatecontrol.saveWordLogByIni(worklogdata);
            }
        }
        public static bool processalive = true;

        private void mainPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            worklogdata.ProjectID = mainPanel.stationid + mainPanel.lineid + DateTime.Now.ToString("yyMMddHHmmss");//线号“00”代表为登录机进行的操作
            worklogdata.ProjectName = "操作日志";
            worklogdata.Stationid = mainPanel.stationid;
            worklogdata.Lineid = mainPanel.lineid;
            worklogdata.Czy = mainPanel.nowUser.userName;
            worklogdata.Data = "系统退出";
            worklogdata.State = "成功";
            worklogdata.Result = "";
            worklogdata.Date = DateTime.Now;
            worklogdata.Bzsm = "";
            processalive = false;//用以结束startTest和XNCarlogin里面的进程 
            demarcatecontrol.saveWordLogByIni(worklogdata);
            if (isNetUsed)
            {
                if (mainPanel.NetMode == mainPanel.ACNETMODE)
                {
                    if (acsocketinf.AREA == ACAREA_NN)
                        SocketControlNn.CloseSocketClient();
                    else
                        SocketControl.CloseSocketClient();
                }
                if(mainPanel.NetMode==mainPanel.DALINETMODE)
                {
                    mainPanel.daliinterface.closeSocket();
                }
                if (mainPanel.NetMode == mainPanel.HNNETMODE)
                {
                    string code, msg;                    
                    if (!mainPanel.hninterface.loginOut( out code, out msg))
                    {
                        MessageBox.Show("发送注销命令失败\r\ncode:" + code + "\r\nmsg:" + msg);
                        ini.INIIO.saveLogInf("发送注销命令失败,code" + code + ",msg:" + msg);
                    }
                }
                if (mainPanel.NetMode == mainPanel.ORTNETMODE)
                {
                    //mainPanel.ortsocket.close_socket();
                }
                if(mainPanel.NetMode==mainPanel.XBNETMODE)
                {
                    try
                    {
                        string result = "", errmsg = "";
                        mainPanel.xbsocket.Send_USER_EXIT(xbLoginUserName, out result, out errmsg);
                        mainPanel.xbsocket.close_equipment();
                    }
                    catch
                    { }

                }
            }
            try
            {
                if (yztm != null)
                    yztm.closeIgbt();
            }
            catch
            { }
        }

        private void 设备自检ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startSelfCheck childcarlogin = new startSelfCheck();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }
        public bool ping(string ip)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "Test data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;
            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }

        private void 扭力标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("扭力标定");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 速度标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("速度标定");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 变载恒滑行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("变载荷滑行测试");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 响应时间测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("响应时间测试");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();

        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("D://环保检测子程序/系统设置.EXE");
        }

        private void 烟度计标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("烟度计检查");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 备份配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要进行备份？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (ini.INIIO.createDir(appFileDir))
                    File.Copy(@".\appConfig.ini", appFileDir + "\\" + "appConfig" + DateTime.Now.ToString("yyMMddHHmmss") + ".ini", true);
                if (ini.INIIO.createDir(detectFileDir))
                    File.Copy(@".\detectConfig.ini", detectFileDir + "\\" + "detectConfig" + DateTime.Now.ToString("yyMMddHHmmss") + ".ini", true);
            }
            MessageBox.Show("备份成功");

        }

        private void 还原appConfiginiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认要进行appConfig.ini还原？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
                folderBrowserDialog1.DefaultExt = "配置文件(*.ini)|*.ini";
                folderBrowserDialog1.InitialDirectory = appFileDir;
                if (ini.INIIO.createDir(appFileDir))
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string selUrl = folderBrowserDialog1.FileName;
                        File.Copy(selUrl, @".\appConfig.ini", true);
                        MessageBox.Show("还原appConfig.ini成功");
                        //File.Copy(@".\detectConfig.ini", detectFileDir + "\\" + "detectConfig" + DateTime.Now.ToString("yyMMddHHmmss") + ".ini", true);
                    }
                }

            }
        }

        private void 还原detectConfiginiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要进行detectConfig.ini还原？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
                folderBrowserDialog1.DefaultExt = "配置文件(*.ini)|*.ini";
                folderBrowserDialog1.InitialDirectory = detectFileDir;
                if (ini.INIIO.createDir(detectFileDir))
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string selUrl = folderBrowserDialog1.FileName;
                        //File.Copy(selUrl, @".\detectConfig", true);
                        File.Copy(selUrl, @".\detectConfig.ini", true);
                        MessageBox.Show("detectConfig.ini成功");
                    }
                }

            }

        }

        private void toolStripButtonXtcs_Click(object sender, EventArgs e)
        {
            //isStartTimerInCarlogin = false;
            Process.Start("D://环保检测子程序/系统设置.EXE");
        }

        private void toolStripButtonGlwh_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            stationConfig childcarlogin = new stationConfig();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void toolStripButtonYxrz_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            demarcateItems childcarlogin = new demarcateItems();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void toolStripDropDownRcjc_Click(object sender, EventArgs e)
        {
            check_linezt();
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.ZKYTNETMODE)
            {
                try
                {
                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD || mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                    {
                        if (get_zkytRegCode())
                        {
                            if (zkytwebinf.regtime.Day != DateTime.Now.Day)
                            {
                                MessageBox.Show("启动授权码上次更新非当日，重新在网页启动工控软件更新授权码后再进入车辆检测");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("读取启动授权码失败，请在网页中启动工控软件更新授权码后再进入车辆检测");
                            return;
                        }
                    }
                    string result="", info="";
                    INIIO.saveLogInf("初始化设备：AuthorizedID=" + zkytwebinf.regcode + ";设备型号：" + equipmodel.SBXH);

                    if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                    {
                        xmlanalysis.ReadACKString(yichangInterface.softVersion(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                    {
                        xmlanalysis.ReadACKString(yichangInterfaceOther.softVersion(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                    {
                        string accesstoken = "";
                        mainPanel.xmlanalysis.ReadAccessTokenString(yichangInterfaceYnbs.getAccessToken(zkytwebinf.lineID), out result, out info, out accesstoken);
                        if (result == "0")
                        {
                            MessageBox.Show("调取访问令牌失败:" + info);
                        }
                        else
                        {
                            mainPanel.zkytwebinf.regcode = accesstoken;
                        }
                        xmlanalysis.ReadACKString(yichangInterfaceYnbs.gkrjbbh(zkytwebinf.regcode, equipmodel.SBXH), out result, out info);
                    }
                    if (result == "0")
                    {
                        MessageBox.Show("向中心端发送工位软件版本号失败：\r\n" + zkytwebinf.regcode + "\r\n" + info);
                        return;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("调用接口发生异常：\r\n" + er.Message);
                    return;
                }
            }
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            lineState childcarlogin = new lineState();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void toolStripButtonTJCX_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            dataQuery childresult = new dataQuery();
            childresult.TopLevel = false;
            //childresult.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childresult);
            childresult.Location = new Point(sc_width / 2 - childresult.Width / 2, 4);
            childresult.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName")
                    panelMain.Controls.Remove(childpenal);
            }
            XNCarLogin childcarlogin = new XNCarLogin();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void toolStripDropDownRcjc_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButtonJcxpz_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            检测线配置 childcarlogin = new 检测线配置();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void 气象站标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("气象站校准");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }

        private void 标定记录查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            demarcateItems childcarlogin = new demarcateItems();
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 4);
            childcarlogin.Show();
        }

        private void 废气仪检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStartTimerInCarlogin = false;
            foreach (Control childpenal in panelMain.Controls)
            {
                if (childpenal.Name != "panel11" && childpenal.Name != "panelLineName" )
                    panelMain.Controls.Remove(childpenal);
            }
            startdemarcate childcarlogin = new startdemarcate("废气仪检查");
            childcarlogin.TopLevel = false;
            panelMain.Controls.Add(childcarlogin);
            childcarlogin.Location = new Point(sc_width / 2 - childcarlogin.Width / 2, 100);
            childcarlogin.Show();
        }
        
    }
}
