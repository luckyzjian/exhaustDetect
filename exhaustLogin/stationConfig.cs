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

namespace exhaustDetect
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
        public static carinfor.AHWebInf ahwebinf = new carinfor.AHWebInf();
        public static carinfor.NHWebInf nhwebinf = new carinfor.NHWebInf();
        public static carinfor.JXWebInf jxwebinf = new carinfor.JXWebInf();
        public static carinfor.HNHYWebInf hnhywebinf = new carinfor.HNHYWebInf();
        public static carinfor.EZWebInf ezwebinf = new carinfor.EZWebInf();
        public static carinfor.HHZWebInf hhzwebinf = new carinfor.HHZWebInf();
        public static carinfor.ZKYTWebInf zkytwebinf = new carinfor.ZKYTWebInf();
        public static carinfor.GLWebInf glwebinf = new carinfor.GLWebInf();
        public static carinfor.DALIWebInf daliwebinf = new carinfor.DALIWebInf();
        public static carinfor.OrtSocketInf ortwebinf = new carinfor.OrtSocketInf();
        public static carinfor.NeusoftSocketInf neusoftsocketinf = new carinfor.NeusoftSocketInf();
        public static carinfor.XBWebInf xbwebinf = new carinfor.XBWebInf();
        public static carinfor.JXPNWebInf jxpnwebinf = new carinfor.JXPNWebInf();
        public static baseControl basecontrol = new baseControl();


        public static int linesCount = 0;
        public static string stationid = "";
        List<string> linelist = new List<string>();
        private string netmode = "";
        private string tynettype = "";

        DataTable dt_vmasxz1 = null, dt_vmasxz2 = null;
        VMAS_XZDB vmas_xzdb = new SYS.Model.VMAS_XZDB();
        GBDal gbdal = new GBDal();
        string thissystemversion = "v180716";


        public stationConfig()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panelMain.Enabled = false;
            init_stationinf();
            init_staff();
            init_StationStaff();
            showVmasXzInf();
            showbBTGXzInf();
            showASMXzInf();
            showSDSXzInf();
            showLugdownXzInf();
            showASMGDInf();
            init_sdjn_btgxz();
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

            ini.INIIO.GetPrivateProfileString("欧润特联网", "服务器IP", "192.168.1.188", temp, 2048, @".\appConfig.ini");
            ortwebinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("欧润特联网", "服务器PORT", "6005", temp, 2048, @".\appConfig.ini");
            ortwebinf.PORT = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("安徽联网", "WEBURL", "http://112.27.49.111/GCservice/Service.asmx", temp, 2048, @".\appConfig.ini");
            ahwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("安徽联网", "LINEID", "36,37,38,39", temp, 2048, @".\appConfig.ini");
            ahwebinf.lineid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("安徽联网", "VERSION", "v2.7", temp, 2048, @".\appConfig.ini");
            ahwebinf.version = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("金华联网", "WEBURL", "http://10.33.139.24/services/inspService", temp, 2048, @".\appConfig.ini");
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

            ini.INIIO.GetPrivateProfileString("联网信息", "服务器IP", "127.0.0.1", temp, 2048, @".\appConfig.ini");
            acsocketinf.IP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网信息", "服务器PORT", "7803", temp, 2048, @".\appConfig.ini");
            acsocketinf.PORT = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网信息", "安车联网地区", "其他", temp, 2048, @".\appConfig.ini");
            acsocketinf.AREA = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("工作模式", "使用华燕数据库", "N", temp, 2048, @".\appConfig.ini");
            checkBoxUseHyDb.Checked = temp.ToString().Trim() == "Y";


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

            ini.INIIO.GetPrivateProfileString("南华联网", "WEBURL", "http://localhost:50581/NHDSWebService.asmx", temp, 2048, @".\appConfig.ini");
            nhwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("南华联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            nhwebinf.lineid = temp.ToString().Trim();

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

            ini.INIIO.GetPrivateProfileString("广西平南联网", "WebServiceUrl", "", temp, 2048, @".\appConfig.ini");
            jxpnwebinf.Url = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("广西平南联网", "WebServiceUser", "", temp, 2048, @".\appConfig.ini");
            jxpnwebinf.User = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("广西平南联网", "WebServicePwd", "", temp, 2048, @".\appConfig.ini");
            jxpnwebinf.Pwd = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("大理联网", "LINEID", "532923001", temp, 2048, @".\appConfig.ini");
            daliwebinf.LINEID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("大理联网", "SERVERIP", "192.168.100.100", temp, 2048, @".\appConfig.ini");
            daliwebinf.SERVERIP = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("大理联网", "SERVERPORT", "9800", temp, 2048, @".\appConfig.ini");
            daliwebinf.SERVERPORT = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "WEBURL", "http://192.168.1.230/jcz_jk/ExternalAccess.asmx", temp, 2048, @".\appConfig.ini");
            hnhywebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "STATIONID", "43042111", temp, 2048, @".\appConfig.ini");
            hnhywebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("湖南衡阳联网", "LINEID", "4304211101", temp, 2048, @".\appConfig.ini");
            hnhywebinf.lineid = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("鄂州联网", "WEBURL", "http://58.19.205.150:8081/jdcData", temp, 2048, @".\appConfig.ini");
            ezwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("鄂州联网", "STATIONID", "CD", temp, 2048, @".\appConfig.ini");
            ezwebinf.stationid = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("鄂州联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            ezwebinf.lineid = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("红河州联网", "WEBURL", "http://172.16.1.1:8088/hhapi/unit_task/", temp, 2048, @".\appConfig.ini");
            hhzwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "WEBURL", "http://172.22.40.140:8095/jczjk/services/deviceSwap", temp, 2048, @".\appConfig.ini");
            zkytwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "ADD", "其他", temp, 2048, @".\appConfig.ini");
            zkytwebinf.add = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "LINEID", "01", temp, 2048, @".\appConfig.ini");
            zkytwebinf.lineID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "上传超时时间", "10", temp, 2048,  @".\appConfig.ini");
            try
            {
                zkytwebinf.waitUploadTime = int.Parse(temp.ToString().Trim());
            }
            catch
            {
                zkytwebinf.waitUploadTime = 10;
            }
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "验证上传", "Y", temp, 2048,  @".\appConfig.ini");
            zkytwebinf.checkUploadSuccess = (temp.ToString().Trim() == "Y");
            ini.INIIO.GetPrivateProfileString("中科宇图联网", "显示结果", "Y", temp, 2048,  @".\appConfig.ini");
            zkytwebinf.displayCheckResult = (temp.ToString().Trim() == "Y");

            ini.INIIO.GetPrivateProfileString("桂林联网", "WEBURL", "http://192.168.16.2:9903/HBService.asmx", temp, 2048, @".\appConfig.ini");
            glwebinf.weburl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("桂林联网", "USER", "admin", temp, 2048, @".\appConfig.ini");
            glwebinf.user = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("桂林联网", "PASSWORD", "123456", temp, 2048, @".\appConfig.ini");
            glwebinf.password = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("联网模式", "模式", "万国联网", temp, 2048, @".\appConfig.ini");
            netmode = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("通用联网模式", "联网模式", "其他", temp, 2048, @".\appConfig.ini");
            tynettype = temp.ToString().Trim();

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

            textBoxXB_IP.Text = xbwebinf.ip;
            textBoxXB_PORT.Text = xbwebinf.port;
            textBoxXB_RZBH.Text = xbwebinf.certificateNo;
            textBoxXB_VERSION.Text = xbwebinf.version;
            textBoxXB_DISKNO.Text = xbwebinf.diskNo;
            textBoxXB_LINEID.Text = xbwebinf.lineid;

            wgsocketinf.SBRZBH = temp.ToString().Trim();
            textBoxWGFWQIP.Text = wgsocketinf.IP;
            textBoxWGFWQPORT.Text = wgsocketinf.PORT;
            textBoxWGJCZBH.Text = wgsocketinf.JCZBH;
            textBoxWGJCZJC.Text = wgsocketinf.JCZJC;
            textBoxWGSBRZBH.Text = wgsocketinf.SBRZBH;
            textBoxCCFWQIP.Text = ccsocketinf.IP;
            textBoxCCFWQPORT.Text = ccsocketinf.PORT;

            textBoxOrtIp.Text = ortwebinf.IP;
            textBoxOrtPort.Text = ortwebinf.PORT;

            textBoxAcIP.Text = acsocketinf.IP;
            textBoxAcPort.Text = acsocketinf.PORT;
            comboBoxAcArea.Text = acsocketinf.AREA;
            textBoxNeusoftIP.Text = neusoftsocketinf.IP;
            textBoxNeusoftPort.Text = neusoftsocketinf.PORT;
            textBoxEISID.Text = neusoftsocketinf.EISID;

            textBoxJHWEBURL.Text = jhwebinf.weburl;
            textBoxJHSTATIONID.Text = jhwebinf.stationid;
            textBoxJHSAFEPWD.Text = jhwebinf.safepwd;
            textBoxJHLINEID.Text = jhwebinf.lineid;
            textBoxJHDBIP.Text = jhwebinf.dbip;
            textBoxJHDBUSER.Text = jhwebinf.dbuser;
            textBoxJHDBCODE.Text = jhwebinf.dbpassword;
            textBoxJHWEBADD.Text = jhwebinf.serverIP;
            checkBoxJHCHECKPRINT.Checked = jhwebinf.checkprint;
            comboBoxJHAREA.Text = jhwebinf.area;

            comboBoxNeusoftArea.Text = neusoftsocketinf.AREA;
            comboBoxNETMODE.Text = netmode;

            textBoxAhUrl.Text = ahwebinf.weburl;
            textBoxAHLINEID.Text = ahwebinf.lineid;
            comboBoxAHVERSION.Text = ahwebinf.version;

            textBoxNhWsdl.Text = nhwebinf.weburl;
            textBoxNhLineID.Text = nhwebinf.lineid;

            textBoxJXUSER.Text = jxwebinf.user;
            textBoxJXPASSWORD.Text = jxwebinf.password;
            textBoxJXLINEID.Text = jxwebinf.lineid;
            textBoxJXurl.Text = jxwebinf.url;
            textBoxJXSOCKETIP.Text = jxwebinf.socketip;
            textBoxJXSOCKETPORT.Text = jxwebinf.socketport;

            textBoxGxpnUrl.Text = jxpnwebinf.Url;
            textBoxGxpnUser.Text = jxpnwebinf.User;
            textBoxGxpnPwd.Text = jxpnwebinf.Pwd;

            textBoxHNHYURL.Text = hnhywebinf.weburl;
            textBoxHNHYJCZBH.Text = hnhywebinf.stationid;
            textBoxHNHYJCXBH.Text = hnhywebinf.lineid;

            textBoxEzUrl.Text = ezwebinf.weburl;
            //textBoxEzStationID.Text = ezwebinf.stationid;
            //textBoxEzLineID.Text = ezwebinf.lineid;
            textBoxHhzUrl.Text = hhzwebinf.weburl;

            textBoxGlWeb.Text = glwebinf.weburl;
            textBoxGLUSER.Text = glwebinf.user;
            textBoxGLPASSWORD.Text = glwebinf.password;

            textBoxDALIJCXBH.Text = daliwebinf.LINEID;
            textBoxDALISERVERIP.Text = daliwebinf.SERVERIP;
            textBoxDALISERVERPORT.Text = daliwebinf.SERVERPORT;

            textBoxZKYTWEB.Text = zkytwebinf.weburl;
            comboBoxZkytAdd.Text = zkytwebinf.add;
            numericUpDownWaitUploadTime.Value = zkytwebinf.waitUploadTime;
            checkBoxCheckUploadSuccess.Checked = zkytwebinf.checkUploadSuccess;
            checkBoxDISPLAYRESULT.Checked = zkytwebinf.displayCheckResult;
            textBoxZkytLineID.Text = zkytwebinf.lineID;

            comboBoxTYNETTYPE.Text = tynettype;

            comboBoxCapMethod.SelectedIndex = mainPanel.capturedata.captureMethod;
            textBoxNVRIP.Text = mainPanel.capturedata.NVRIP;
            textBoxNVRPORT.Text = mainPanel.capturedata.NVRPORT.ToString();
            textBoxNVRUSER.Text = mainPanel.capturedata.NVRUSER;
            textBoxNVRPASSWORD.Text = mainPanel.capturedata.NVRPASSWORD;
            textBoxNVRFRONTCHANEL.Text = mainPanel.capturedata.NVRFRONTCHANEL.ToString();
            textBoxNVRBACKCHANEL.Text = mainPanel.capturedata.NVRBACKCHANEL.ToString();
            textBoxCAMFRONTIP.Text = mainPanel.capturedata.CAMERAFRONTIP;
            textBoxCAMFRONTPORT.Text = mainPanel.capturedata.CAMERAFRONTPORT.ToString();
            textBoxCAMFRONTUSER.Text = mainPanel.capturedata.CAMERAFRONTUSER;
            textBoxCAMFRONTPASSWORD.Text = mainPanel.capturedata.CAMERAFRONTPASSWORD;
            textBoxCAMBACKIP.Text = mainPanel.capturedata.CAMERABACKIP;
            textBoxCAMBACKPORT.Text = mainPanel.capturedata.CAMERABACKPORT.ToString();
            textBoxCAMBACKUSER.Text = mainPanel.capturedata.CAMERABACKUSER;
            textBoxCAMBACKPASSWORD.Text = mainPanel.capturedata.CAMERABACKPASSWORD;
            checkBoxFrontCam.Checked = mainPanel.capturedata.ENABLEFRONT;
            checkBoxBackCam.Checked = mainPanel.capturedata.ENABLEBACK;
            checkBoxCAP_VMAS_START.Checked = mainPanel.capturedata.cap_vmas_start;
            checkBoxCAP_VMAS_15.Checked = mainPanel.capturedata.cap_vmas_15;
            checkBoxCAP_VMAS_32.Checked = mainPanel.capturedata.cap_vmas_32;
            checkBoxCAP_VMAS_50.Checked = mainPanel.capturedata.cap_vmas_50;
            checkBoxCAP_ASM_START.Checked = mainPanel.capturedata.cap_asm_start;
            checkBoxCAP_ASM_5025.Checked = mainPanel.capturedata.cap_asm_5025;
            checkBoxCAP_ASM_2540.Checked = mainPanel.capturedata.cap_asm_2540;
            checkBoxCAP_SDS_START.Checked = mainPanel.capturedata.cap_sds_start;
            checkBoxCAP_SDS_HIGH.Checked = mainPanel.capturedata.cap_sds_high;
            checkBoxCAP_SDS_LOW.Checked = mainPanel.capturedata.cap_sds_low;
            checkBoxCAP_LUGDOWN_START.Checked = mainPanel.capturedata.cap_lugdown_start;
            checkBoxCAP_LUGDOWN_100.Checked = mainPanel.capturedata.cap_lugdown_100;
            checkBoxCAP_LUGDOWN_90.Checked = mainPanel.capturedata.cap_lugdown_90;
            checkBoxCAP_LUGDOWN_80.Checked = mainPanel.capturedata.cap_lugdown_80;
            checkBoxCAP_BTG_START.Checked = mainPanel.capturedata.cap_btg_start;
            checkBoxCAP_BTG_FIRST.Checked = mainPanel.capturedata.cap_btg_first;
            checkBoxCAP_BTG_SECOND.Checked = mainPanel.capturedata.cap_btg_second;
            checkBoxCAP_BTG_THIRD.Checked = mainPanel.capturedata.cap_btg_third;
            checkBoxCAP_XN_START.Checked = mainPanel.capturedata.cap_xn_start;
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
            else if(comboBoxNeuYcy.Items.Count>0)
                comboBoxNeuYcy.SelectedIndex = 0;
        }
        private void init_stationinf()
        {
            init_wginf();
            stationid = stationcontrol.getStationID();
            initLinesList();
            stationinfmodel = stationcontrol.getStationInf(stationid);
            bdsx = stationcontrol.getDemarcateInfString();
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
            comboBoxXZYJ.Text = stationinfmodel.STANDARD;
            dateTimePicker1.Value = stationinfmodel.YXQSTARTTIME;
            dateTimePicker2.Value = stationinfmodel.YXQENDTIME;
            checkBoxIsLock.Checked = stationinfmodel.ISLOCK;
            textBoxLinesCount.Text = linesCount.ToString();
            radioButtonLineConfig.Checked = true;
            textBoxJCZJCXS.Text = stationinfmodel.JCXS;
            textBoxJCZFZR.Text = stationinfmodel.FZR;
            textBoxJCZLXR.Text = stationinfmodel.LXR;
            comboBoxJCZJJLX.Text = stationinfmodel.JJLX;
            dateTimePickerJCZZCSJ.Value = stationinfmodel.ZCSJ;
            comboBoxLshRule.Text = stationinfmodel.LSHRULE;


            if (stationinfmodel.CLEARMODE == "M") radioButtonCLEARMODE_MONTH.Checked = true;
            else if (stationinfmodel.CLEARMODE == "Y") radioButtonCLEARMODE_YEAR.Checked = true;
            else if (stationinfmodel.CLEARMODE == "D") radioButtonCLEARMODE_DAY.Checked = true;
            else radioButtonCLEARMODE_FOREVER.Checked = true;

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
            textBoxFXYJL.Text = bdsx.JLSX;

            initLineDataGridView("stationLine");
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
        private void showVmasXzInf()
        {
            DataTable vmasxzdt = gbdal.Get_ALL_VMAS_XZBZ();
            if (vmasxzdt != null)
            {
                dataGridViewVmasXz1.DataSource = vmasxzdt;
                dataGridViewVmasXz1.Columns["ID"].HeaderText = "号牌前缀";
                dataGridViewVmasXz1.Columns["S1020bco"].HeaderText = "排放限值I-CO(RM≤1020)";
                dataGridViewVmasXz1.Columns["S10201470bco"].HeaderText = "排放限值I-CO(1020＜RM≤1470)";
                dataGridViewVmasXz1.Columns["S14701930bco"].HeaderText = "排放限值I-CO(1470＜RM≤1930)";
                dataGridViewVmasXz1.Columns["S1930bco"].HeaderText = "排放限值I-CO(1930＜RM)";
                dataGridViewVmasXz1.Columns["S1020bhc"].HeaderText = "排放限值I-HC(RM≤1020)";
                dataGridViewVmasXz1.Columns["S10201470bhc"].HeaderText = "排放限值I-HC(1020＜RM≤1470)";
                dataGridViewVmasXz1.Columns["S14701930bhc"].HeaderText = "排放限值I-HC(1470＜RM≤1930)";
                dataGridViewVmasXz1.Columns["S1930bhc"].HeaderText = "排放限值I-HC(1930＜RM)";
                dataGridViewVmasXz1.Columns["S1020bno"].HeaderText = "排放限值I-NOx(RM≤1020)";
                dataGridViewVmasXz1.Columns["S10201470bno"].HeaderText = "排放限值I-NOx(1020＜RM≤1470)";
                dataGridViewVmasXz1.Columns["S14701930bno"].HeaderText = "排放限值I-NOx(1470＜RM≤1930)";
                dataGridViewVmasXz1.Columns["S1930bno"].HeaderText = "排放限值I-NOx(1930＜RM)";
                dataGridViewVmasXz1.Columns["Sg1d1co"].HeaderText = "排放限值II-一类车CO(全部)";
                dataGridViewVmasXz1.Columns["S1250g1d2co"].HeaderText = "排放限值II-二类车CO(RM≤1250)";
                dataGridViewVmasXz1.Columns["S12501700g1d2co"].HeaderText = "排放限值II-二类车CO(1250＜RM≤1700)";
                dataGridViewVmasXz1.Columns["S1700g1d2co"].HeaderText = "排放限值II-二类车CO(1700＜RM)";
                dataGridViewVmasXz1.Columns["Sg1d1hcnox"].HeaderText = "排放限值II-一类车HC+NOx(全部)";
                dataGridViewVmasXz1.Columns["S1250g1d2hcnox"].HeaderText = "排放限值II-二类车HC+NOx(RM≤1250)";
                dataGridViewVmasXz1.Columns["S12501700g1d2hcnox"].HeaderText = "排放限值II-二类车HC+NOx(1250＜RM≤1700)";
                dataGridViewVmasXz1.Columns["S1700g1d2hcnox"].HeaderText = "排放限值II-二类车HC+NOx(1700＜RM)";


                dataGridViewVmasXz1.Columns["Sg2d1co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g2d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g2d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g2d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["Sg2d1hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g2d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g2d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g2d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["Sg3d1co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g3d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g3d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g3d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["Sg3d1hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g3d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g3d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g3d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["Sg4d1co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g4d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g4d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g4d2co"].Visible = false;
                dataGridViewVmasXz1.Columns["Sg4d1hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1250g4d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S12501700g4d2hcnox"].Visible = false;
                dataGridViewVmasXz1.Columns["S1700g4d2hcnox"].Visible = false;
            }
        }
        private void showSDSXzInf()
        {
            DataTable vmasxzdt = gbdal.Get_ALL_SDS_XZBZ();
            if (vmasxzdt != null)
            {
                dataGridViewSDSXZ.DataSource = vmasxzdt;
                dataGridViewSDSXZ.Columns["ID"].Visible = false;
                dataGridViewSDSXZ.Columns["Hd1Date19950701qHC"].HeaderText = "95年7月1日前第一类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd1Date19950701qCO"].HeaderText = "95年7月1日前第一类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d1Date19950701qHC"].HeaderText = "95年7月1日前第一类车-怠速HC";
                dataGridViewSDSXZ.Columns["d1Date19950701qCO"].HeaderText = "95年7月1日前第一类车-怠速CO";
                dataGridViewSDSXZ.Columns["Hd1Date1995070120000701HC"].HeaderText = "95年7月1日~00年7月1日第一类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd1Date1995070120000701CO"].HeaderText = "95年7月1日~00年7月1日第一类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d1Date1995070120000701HC"].HeaderText = "95年7月1日~00年7月1日第一类车-怠速HC";
                dataGridViewSDSXZ.Columns["d1Date1995070120000701CO"].HeaderText = "95年7月1日~00年7月1日第一类车-怠速CO";
                dataGridViewSDSXZ.Columns["Hd1Date20000701HC"].HeaderText = "00年7月1日后第一类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd1Date20000701CO"].HeaderText = "00年7月1日后第一类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d1Date20000701HC"].HeaderText = "00年7月1日后第一类车-怠速HC";
                dataGridViewSDSXZ.Columns["d1Date20000701CO"].HeaderText = "00年7月1日后第一类车-怠速CO";
                dataGridViewSDSXZ.Columns["Hd2Date19950701qHC"].HeaderText = "95年7月1日前第二类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd2Date19950701qCO"].HeaderText = "95年7月1日前第二类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d2Date19950701qHC"].HeaderText = "95年7月1日前第二类车-怠速HC";
                dataGridViewSDSXZ.Columns["d2Date19950701qCO"].HeaderText = "95年7月1日前第二类车-怠速CO";
                dataGridViewSDSXZ.Columns["Hd2Date1995070120011001HC"].HeaderText = "95年7月1日~01年10月1日第二类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd2Date1995070120011001CO"].HeaderText = "95年7月1日~01年10月1日第二类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d2Date1995070120011001HC"].HeaderText = "95年7月1日~01年10月1日第二类车-怠速HC";
                dataGridViewSDSXZ.Columns["d2Date1995070120011001CO"].HeaderText = "95年7月1日~01年10月1日第二类车-怠速CO";
                dataGridViewSDSXZ.Columns["Hd2Date20011001HC"].HeaderText = "01年10月1日后第二类车-高怠速HC";
                dataGridViewSDSXZ.Columns["Hd2Date20011001CO"].HeaderText = "01年10月1日后第二类车-高怠速CO";
                dataGridViewSDSXZ.Columns["d2Date20011001HC"].HeaderText = "01年10月1日后第二类车-怠速HC";
                dataGridViewSDSXZ.Columns["d2Date20011001CO"].HeaderText = "01年10月1日后第二类车-怠速CO";
                dataGridViewSDSXZ.Columns["HzxDate19950701qHC"].HeaderText = "95年7月1日前重型车-高怠速HC";
                dataGridViewSDSXZ.Columns["HzxDate19950701qCO"].HeaderText = "95年7月1日前重型车-高怠速CO";
                dataGridViewSDSXZ.Columns["zxDate19950701qHC"].HeaderText = "95年7月1日前重型车-怠速HC";
                dataGridViewSDSXZ.Columns["zxDate19950701qCO"].HeaderText = "95年7月1日前重型车-怠速CO";
                dataGridViewSDSXZ.Columns["HzxDate1995070120040901HC"].HeaderText = "95年7月1日~04年9月1日重型车-高怠速HC";
                dataGridViewSDSXZ.Columns["HzxDate1995070120040901CO"].HeaderText = "95年7月1日~04年9月1日重型车-高怠速CO";
                dataGridViewSDSXZ.Columns["zxDate1995070120040901HC"].HeaderText = "95年7月1日~04年9月1日重型车-怠速HC";
                dataGridViewSDSXZ.Columns["zxDate1995070120040901CO"].HeaderText = "95年7月1日~04年9月1日重型车-怠速CO";
                dataGridViewSDSXZ.Columns["HzxDate20040901HC"].HeaderText = "04年9月1日后重型车-高怠速HC";
                dataGridViewSDSXZ.Columns["HzxDate20040901CO"].HeaderText = "04年9月1日后重型车-高怠速CO";
                dataGridViewSDSXZ.Columns["zxDate20040901HC"].HeaderText = "04年9月1日后重型车-怠速HC";
                dataGridViewSDSXZ.Columns["zxDate20040901CO"].HeaderText = "04年9月1日后重型车-怠速CO";

                dataGridViewSDSXZ.Columns["HNewd1HC"].Visible = false;
                dataGridViewSDSXZ.Columns["HNewd1CO"].Visible = false;
                dataGridViewSDSXZ.Columns["Newd1HC"].Visible = false;
                dataGridViewSDSXZ.Columns["Newd1CO"].Visible = false;
                dataGridViewSDSXZ.Columns["HNewd2HC"].Visible = false;
                dataGridViewSDSXZ.Columns["HNewd2CO"].Visible = false;
                dataGridViewSDSXZ.Columns["Newd2HC"].Visible = false;
                dataGridViewSDSXZ.Columns["Newd2CO"].Visible = false;
                dataGridViewSDSXZ.Columns["zxHNewHC"].Visible = false;
                dataGridViewSDSXZ.Columns["zxHNewCO"].Visible = false;
                dataGridViewSDSXZ.Columns["zxNewHC"].Visible = false;
                dataGridViewSDSXZ.Columns["zxNewCO"].Visible = false;
            }
        }
        private void showLugdownXzInf()
        {
            DataTable vmasxzdt = gbdal.Get_ALL_JZJS_XZBZ();
            if (vmasxzdt != null)
            {
                dataGridViewLUGDOWNXZ.DataSource = vmasxzdt;
                dataGridViewLUGDOWNXZ.Columns["ID"].Visible = false;
                dataGridViewLUGDOWNXZ.Columns["d1Date20000701b"].HeaderText = "2000年7月1日前第一类车";
                dataGridViewLUGDOWNXZ.Columns["d1Date2000070120050630"].HeaderText = "2001年7月1日~2005年6月30日第一类车";
                dataGridViewLUGDOWNXZ.Columns["d1Date20050701"].HeaderText = "2005年7月1日起第一类车";
                dataGridViewLUGDOWNXZ.Columns["d2Date20011001b"].HeaderText = "2001年10月1日前第二类车";
                dataGridViewLUGDOWNXZ.Columns["d2Date2001100120060630"].HeaderText = "2001年10月1日~2006年6月30日第二类车";
                dataGridViewLUGDOWNXZ.Columns["d2Date20060701"].HeaderText = "2006年7月1日起第二类车";
                dataGridViewLUGDOWNXZ.Columns["zxDate20010901b"].HeaderText = "2001年1月以前生产的重型车";
                dataGridViewLUGDOWNXZ.Columns["zxDate2001090120040831"].HeaderText = "2001年1月~2004年9月生产的重型车";
                dataGridViewLUGDOWNXZ.Columns["zxDate20040901"].HeaderText = "2004年9月起生产的重型车";
            }
        }
        private void showASMXzInf()
        {
            DataTable vmasxzdt = gbdal.Get_ALL_ASM_XZBZ();
            if (vmasxzdt != null)
            {
                dataGridViewASMXZ.DataSource = vmasxzdt;
                dataGridViewASMXZ.Columns["ID"].HeaderText = "号牌前缀";
                dataGridViewASMXZ.Columns["d1Date20000701qHC5025"].HeaderText = "排放限值I-HC(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701qCO5025"].HeaderText = "排放限值I-CO(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701qNO5025"].HeaderText = "排放限值I-NO(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701qHC2540"].HeaderText = "排放限值I-HC(ASM2540)";
                dataGridViewASMXZ.Columns["d1Date20000701qCO2540"].HeaderText = "排放限值I-CO(ASM2540)";
                dataGridViewASMXZ.Columns["d1Date20000701qNO2540"].HeaderText = "排放限值I-NO(ASM2540)";
                dataGridViewASMXZ.Columns["d1Date20000701HC5025"].HeaderText = "排放限值II-HC(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701CO5025"].HeaderText = "排放限值II-CO(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701NO5025"].HeaderText = "排放限值II-NO(ASM5025)";
                dataGridViewASMXZ.Columns["d1Date20000701HC2540"].HeaderText = "排放限值II-HC(ASM2540)";
                dataGridViewASMXZ.Columns["d1Date20000701CO2540"].HeaderText = "排放限值II-CO(ASM2540)";
                dataGridViewASMXZ.Columns["d1Date20000701NO2540"].HeaderText = "排放限值II-NO(ASM2540)";
                dataGridViewASMXZ.Columns["d2Date20011001qHC5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001qCO5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001qNO5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001qHC2540"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001qCO2540"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001qNO2540"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001HC5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001CO5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001NO5025"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001HC2540"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001CO2540"].Visible = false;
                dataGridViewASMXZ.Columns["d2Date20011001NO2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qHC5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qCO5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qNO5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qHC2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qCO2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901qNO2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901HC5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901CO5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901NO5025"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901HC2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901CO2540"].Visible = false;
                dataGridViewASMXZ.Columns["zxDate20040901NO2540"].Visible = false;
            }
        }
        private void showASMGDInf()
        {
            try
            {
                dataGridViewASM_GD_I.Rows.Add(3);
                dataGridViewASM_GD_II.Rows.Add(3);
                dataGridViewASM_GD_III.Rows.Add(3);
                ASM_GDXZ vmasxzdt = new ASM_GDXZ();
                vmasxzdt = gbdal.Get_GDXZ("I-I");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_I.Rows[0].Cells[0].Value = "RM<=1250";
                    dataGridViewASM_GD_I.Rows[0].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_I.Rows[0].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_I.Rows[0].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_I.Rows[0].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_I.Rows[0].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_I.Rows[0].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("I-II");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_I.Rows[1].Cells[0].Value = "1250<RM<=1700";
                    dataGridViewASM_GD_I.Rows[1].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_I.Rows[1].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_I.Rows[1].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_I.Rows[1].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_I.Rows[1].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_I.Rows[1].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("I-III");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_I.Rows[2].Cells[0].Value = "1700<RM";
                    dataGridViewASM_GD_I.Rows[2].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_I.Rows[2].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_I.Rows[2].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_I.Rows[2].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_I.Rows[2].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_I.Rows[2].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("II-I");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_II.Rows[0].Cells[0].Value = "RM<=1250";
                    dataGridViewASM_GD_II.Rows[0].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_II.Rows[0].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_II.Rows[0].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_II.Rows[0].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_II.Rows[0].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_II.Rows[0].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("II-II");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_II.Rows[1].Cells[0].Value = "1250<RM<=1700";
                    dataGridViewASM_GD_II.Rows[1].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_II.Rows[1].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_II.Rows[1].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_II.Rows[1].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_II.Rows[1].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_II.Rows[1].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("II-III");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_II.Rows[2].Cells[0].Value = "1700<RM";
                    dataGridViewASM_GD_II.Rows[2].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_II.Rows[2].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_II.Rows[2].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_II.Rows[2].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_II.Rows[2].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_II.Rows[2].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("III-I");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_III.Rows[0].Cells[0].Value = "RM<=1305";
                    dataGridViewASM_GD_III.Rows[0].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_III.Rows[0].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_III.Rows[0].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_III.Rows[0].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_III.Rows[0].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_III.Rows[0].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("III-II");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_III.Rows[1].Cells[0].Value = "1305<RM<=1760";
                    dataGridViewASM_GD_III.Rows[1].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_III.Rows[1].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_III.Rows[1].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_III.Rows[1].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_III.Rows[1].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_III.Rows[1].Cells[6].Value = vmasxzdt.NO40;
                }
                vmasxzdt = gbdal.Get_GDXZ("III-III");
                if (vmasxzdt != null)
                {
                    dataGridViewASM_GD_III.Rows[2].Cells[0].Value = "1760<RM";
                    dataGridViewASM_GD_III.Rows[2].Cells[1].Value = vmasxzdt.CO25;
                    dataGridViewASM_GD_III.Rows[2].Cells[2].Value = vmasxzdt.HC25;
                    dataGridViewASM_GD_III.Rows[2].Cells[3].Value = vmasxzdt.NO25;
                    dataGridViewASM_GD_III.Rows[2].Cells[4].Value = vmasxzdt.CO40;
                    dataGridViewASM_GD_III.Rows[2].Cells[5].Value = vmasxzdt.HC40;
                    dataGridViewASM_GD_III.Rows[2].Cells[6].Value = vmasxzdt.NO40;
                }
            }
            catch
            { }
        }
        private void showbBTGXzInf()
        {
            try
            {
                ZYJS_XZGB zyjs_xzgb = gbdal.Get_ZYJS_XZGB();
                textBoxBTGZRXQ.Text = zyjs_xzgb.ZRDate20011001btgxz;
                textBoxBTGWLZY.Text = zyjs_xzgb.WLDate20011001btgxz;
                checkBoxBtgXz.Checked = zyjs_xzgb.onlyUseThis;
                comboBoxBTGXZTABLE.SelectedIndex = zyjs_xzgb.XZTABLE;
                comboBoxBTG_XZBZ.SelectedIndex = zyjs_xzgb.BTGXZBZ;
            }
            catch(Exception er)
            {
                MessageBox.Show("异常：" + er.Message);
            }
        }
        private bool isdatagridviewinit = true;
        
        private void initLineDataGridView(string projectname)
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridViewStaff.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            DataGridViewButtonColumn btnsave = new DataGridViewButtonColumn();
            btnsave.Name = "btnsave";
            btnsave.DefaultCellStyle.NullValue = "上传";
            btnsave.HeaderText = "上传";
            btnsave.Width = 100;
            DataGridViewComboBoxColumn colcomboboxASMYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxVMASYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxSDSYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxLJZJSYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxHJZJSYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxZYJSYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxLZYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxAUTOPRINTYN = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn colcomboboxISLOCKYN = new DataGridViewComboBoxColumn();
            colcomboboxASMYN.Items.Add("Y");
            colcomboboxASMYN.Items.Add("N");
            colcomboboxVMASYN.Items.Add("Y");
            colcomboboxVMASYN.Items.Add("N");
            colcomboboxSDSYN.Items.Add("Y");
            colcomboboxSDSYN.Items.Add("N");
            colcomboboxLJZJSYN.Items.Add("Y");
            colcomboboxLJZJSYN.Items.Add("N");
            colcomboboxHJZJSYN.Items.Add("Y");
            colcomboboxHJZJSYN.Items.Add("N");
            colcomboboxZYJSYN.Items.Add("Y");
            colcomboboxZYJSYN.Items.Add("N");
            colcomboboxLZYN.Items.Add("Y");
            colcomboboxLZYN.Items.Add("N");
            colcomboboxAUTOPRINTYN.Items.Add("Y");
            colcomboboxAUTOPRINTYN.Items.Add("N");
            colcomboboxISLOCKYN.Items.Add("Y");
            colcomboboxISLOCKYN.Items.Add("N");
            //colcomboboxedu.HeaderText = "学历";
            //colcomboboxedu.Width = 100;

            DataTable datagrid = logininfcontrol.getStationLineInf(projectname, stationid);
            if (datagrid.Rows.Count > 0)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
                if (radioButtonLineConfig.Checked)
                {
                    this.dataGridView1.Columns.Add("1", "检测站编号");
                    this.dataGridView1.Columns.Add("2", "检测线号");
                    this.dataGridView1.Columns.Add(colcomboboxASMYN);
                    dataGridView1.Columns[2].HeaderText = "稳态工况";
                    this.dataGridView1.Columns.Add(colcomboboxVMASYN);
                    dataGridView1.Columns[3].HeaderText = "简易瞬态";
                    this.dataGridView1.Columns.Add(colcomboboxSDSYN);
                    dataGridView1.Columns[4].HeaderText = "双怠速";
                    this.dataGridView1.Columns.Add(colcomboboxLJZJSYN);
                    dataGridView1.Columns[5].HeaderText = "轻柴Lugdown";
                    this.dataGridView1.Columns.Add(colcomboboxHJZJSYN);
                    dataGridView1.Columns[6].HeaderText = "重柴Lugdown";
                    this.dataGridView1.Columns.Add(colcomboboxZYJSYN);
                    dataGridView1.Columns[7].HeaderText = "自由加速";
                    this.dataGridView1.Columns.Add(colcomboboxLZYN);
                    dataGridView1.Columns[8].HeaderText = "滤纸";
                    this.dataGridView1.Columns.Add("10", "打印机");
                    this.dataGridView1.Columns.Add(colcomboboxAUTOPRINTYN);
                    dataGridView1.Columns[10].HeaderText = "自动打印";
                    dataGridView1.Columns[10].ReadOnly = true;
                    this.dataGridView1.Columns.Add("12", "检测线许可证编号");
                    this.dataGridView1.Columns.Add("13", "创建日期");
                    this.dataGridView1.Columns.Add("14", "标定有效期");
                    this.dataGridView1.Columns.Add(colcomboboxISLOCKYN);
                    dataGridView1.Columns[14].HeaderText = "是否锁止";
                    this.dataGridView1.Columns.Add("16", "锁止原因");
                    this.dataGridView1.Columns.Add(btnsave);
                    dataGridView1.Columns["1"].ReadOnly = true;
                    dataGridView1.Columns["2"].ReadOnly = true;
                    foreach (DataRow dR in datagrid.Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        foreach (DataGridViewColumn c in this.dataGridView1.Columns)
                        {
                            dr1.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                        }
                        dr1.Cells[0].Value = dR["STATIONID"].ToString();
                        dr1.Cells[1].Value = dR["LINEID"].ToString();
                        dr1.Cells[2].Value = dR["ASM"].ToString();
                        dr1.Cells[3].Value = dR["VMAS"].ToString();
                        dr1.Cells[4].Value = dR["SDS"].ToString();
                        dr1.Cells[5].Value = dR["JZJS_LIGHT"].ToString();
                        dr1.Cells[6].Value = dR["JZJS_HEAVY"].ToString();
                        dr1.Cells[7].Value = dR["ZYJS"].ToString();
                        dr1.Cells[8].Value = dR["LZ"].ToString();
                        dr1.Cells[9].Value = dR["PRINTER"].ToString();
                        dr1.Cells[10].Value = dR["AUTOPRINT"].ToString();
                        dr1.Cells[11].Value = dR["JCXXKZBH"].ToString();
                        dr1.Cells[12].Value = DateTime.Parse(dR["YXQSTARTTIME"].ToString()).ToString("yyyy-MM-dd");
                        dr1.Cells[13].Value = DateTime.Parse(dR["YXQENDTIME"].ToString()).ToString("yyyy-MM-dd");
                        dr1.Cells[14].Value = dR["ISLOCK"].ToString();
                        dr1.Cells[15].Value = dR["LOCKREASON"].ToString();
                        this.dataGridView1.Rows.Add(dr1);
                    }
                }
                else if (radioButtonLineCalInf.Checked)
                {
                    dataGridView1.DataSource = datagrid;
                    dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                    dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                    dataGridView1.Columns["STATIONID"].ReadOnly = true;
                    dataGridView1.Columns["LINEID"].ReadOnly = true;
                    dataGridView1.Columns["YRENABLE"].HeaderText = "设备预热";
                    dataGridView1.Columns["ZJENABLE"].HeaderText = "设备自检";
                    dataGridView1.Columns["HXENABLE"].HeaderText = "加载滑行";
                    dataGridView1.Columns["GLENABLE"].HeaderText = "惯量测试";
                    dataGridView1.Columns["JSGLENABLE"].HeaderText = "寄生功率";
                    dataGridView1.Columns["YLJENABLE"].HeaderText = "压力计校准";
                    dataGridView1.Columns["SDENABLE"].HeaderText = "转速传感器校准";
                    dataGridView1.Columns["FXYLOWENABLE"].HeaderText = "废气分析仪低量程检查";
                    dataGridView1.Columns["FXYHIGHENABLE"].HeaderText = "废气分析仪高量程检查";
                    dataGridView1.Columns["FXYMIDENABLE"].HeaderText = "废气分析仪校准";
                    dataGridView1.Columns["YDJENABLE"].HeaderText = "烟度计日常检查";
                    dataGridView1.Columns["LLJENABLE"].HeaderText = "流量计日常检查";
                    dataGridView1.Columns["HJCSENABLE"].HeaderText = "环境参数校准";
                    dataGridView1.Columns["ZSJENABLE"].HeaderText = "发动机转速计校准";
                    dataGridView1.Columns["JLENABLE"].HeaderText = "废气仪泄漏检查";

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
                    //dataGridView1.Columns["FXYMIDENABLE"].Visible = false;
                    dataGridView1.Columns["FXYLOWMIDENABLE"].Visible = false;
                    dataGridView1.Columns["FXYLOWMIDDATE"].Visible = false;
                    dataGridView1.Columns["FXYHIGHMIDENABLE"].Visible = false;
                    dataGridView1.Columns["FXYHIGHMIDDATE"].Visible = false;
                    dataGridView1.Columns["JLDATE"].Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = datagrid;
                    dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                    dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                    dataGridView1.Columns["STATIONID"].ReadOnly = true;
                    dataGridView1.Columns["LINEID"].ReadOnly = true;
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
                if (isdatagridviewinit)
                {
                    isdatagridviewinit = false;
                    DataGridViewButtonColumn btnsave = new DataGridViewButtonColumn();
                    btnsave.Name = "btnsave";
                    btnsave.DefaultCellStyle.NullValue = "保存";
                    btnsave.HeaderText = "保存";
                    btnsave.Width = 50;
                    dataGridView1.Columns.Add(btnsave);
                }
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
                        dataGridView1.Columns["YXQSTARTTIME"].HeaderText = "创建日期";
                        dataGridView1.Columns["YXQENDTIME"].HeaderText = "标定有效期";
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
                        dataGridView1.Columns["FXYMIDENABLE"].HeaderText = "废气分析仪校准";
                        dataGridView1.Columns["YDJENABLE"].HeaderText = "烟度计日常检查";
                        dataGridView1.Columns["LLJENABLE"].HeaderText = "流量计日常检查";
                        dataGridView1.Columns["HJCSENABLE"].HeaderText = "环境参数校准";
                        dataGridView1.Columns["ZSJENABLE"].HeaderText = "发动机转速计校准";
                        dataGridView1.Columns["JLENABLE"].HeaderText = "废气仪泄漏检查";

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
                        //dataGridView1.Columns["FXYMIDENABLE"].Visible = false;
                        dataGridView1.Columns["FXYLOWMIDENABLE"].Visible = false;
                        dataGridView1.Columns["FXYLOWMIDDATE"].Visible = false;
                        dataGridView1.Columns["FXYHIGHMIDENABLE"].Visible = false;
                        dataGridView1.Columns["FXYHIGHMIDDATE"].Visible = false;
                        dataGridView1.Columns["JLDATE"].Visible = false;
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

        private void radioButtonLineCalInf_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineCalInf.Checked)
            {
                initLineDataGridView("设备标定");
            }
        }

        private void radioButtonLineConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineConfig.Checked)
                initLineDataGridView("stationLine");
        }

        private void radioButtonLineEquipment_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLineEquipment.Checked)
                initLineDataGridView("检测线设备");

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
            model.STANDARD = comboBoxXZYJ.Text;
            model.LOCKREASON = "";
            model.CLEARMODE = radioButtonCLEARMODE_YEAR.Checked ? "Y" : (radioButtonCLEARMODE_MONTH.Checked ? "M" : (radioButtonCLEARMODE_DAY.Checked ? "D" : "F"));
            model.JJLX = comboBoxJCZJJLX.Text;
            model.LXR = textBoxJCZLXR.Text;
            model.FZR = textBoxJCZFZR.Text;
            model.ZCSJ = dateTimePickerJCZZCSJ.Value;
            model.JCXS = textBoxJCZJCXS.Text;
            model.LSHRULE = comboBoxLshRule.Text;
            logininfcontrol.setThisStationID(model.STATIONID);
            logininfcontrol.setStationLineStationID(model.STATIONID);
            logininfcontrol.setStationLSHStationID(model.STATIONID);
            logininfcontrol.setStationNormalInfStationID(model.STATIONID);
            logininfcontrol.setDermacateStationID(model.STATIONID);
            logininfcontrol.setStationEquipmentStationID(model.STATIONID);
            logininfcontrol.setThisStationInf(model.STATIONNAME, model.STATIONADD, model.STATIONPHONE, model.STATIONJCFF, model.STATIONDATE, model.StationCompany, model.SBHZBH, model.YXQSTARTTIME, model.YXQENDTIME, model.JCZXKZH, model.ISLOCK, model.STANDARD, model.CLEARMODE, model.JJLX, model.LXR, model.FZR, model.ZCSJ, model.JCXS,model.LSHRULE);
            init_stationinf();
            /*
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
            {
                #region 红河州联网上传检测站信息
                System.Collections.Hashtable hthhz = new System.Collections.Hashtable();
                System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                hthhz.Add("JCZBM", model.STATIONID);
                hthhz.Add("JCZJC", model.StationCompany);
                hthhz.Add("JCZDZ", model.STATIONADD);
                hthhz.Add("JCZMC", model.STATIONNAME);
                hthhz.Add("JJLX", mainPanel.hhzinterface.HhzR_JCZ_JJLX.GetValue(model.JJLX, ""));//5
                hthhz.Add("JCXSL", model.JCXS);
                hthhz.Add("SZDS", "1");
                hthhz.Add("SZQX", "1");
                hthhz.Add("LXDH", model.STATIONPHONE);
                hthhz.Add("LXR", model.LXR);//10
                hthhz.Add("FZR", model.FZR);
                hthhz.Add("JLRZZH", model.SBHZBH);
                hthhz.Add("ZZXKZH", "1");
                hthhz.Add("GDZC", "1");
                hthhz.Add("ZCZJ", "1");//15
                hthhz.Add("YZBM", "1");
                hthhz.Add("JYXKZH", "1");
                hthhz.Add("CDMJ", "1");
                hthhz.Add("ZGZS", "1");
                hthhz.Add("GJGCSRS", "1");//20
                hthhz.Add("ZLGCSRS", "1");
                hthhz.Add("JSFZR", "1");
                hthhz.Add("KHHGRS", "1");
                hthhz.Add("GCSRS", "1");
                hthhz.Add("ZLFZR", "1");//25
                hthhz.Add("JSRRS", "1");
                hthhz.Add("JCZJD", "1");
                hthhz.Add("JCZWD", "1");
                hthhz.Add("SFAJ", "1");
                hthhz.Add("SFZJ", "1");
                hthhz.Add("ZCSJ", model.ZCSJ.ToString("yyyy-MM-dd"));//30
                hthhz.Add("JZJCCL", "1");
                hthhz.Add("JCZDKH", "1");
                hthhz.Add("JCZIPDZ", "1");
                hthhz.Add("SFZX", mainPanel.hhzinterface.HhzR_JCZ_YESORNO.GetValue("否", ""));
                hthhz.Add("BZ", "");//35
                hthhz.Add("LXJIPDZ", "1");
                hthhz.Add("LXJDKH", "1");
                hthhz.Add("SFYXFJ", "1");
                hthhz.Add("SFSZ", "1");
                hthhz.Add("QYCGKJCFF", mainPanel.hhzinterface.HhzR_JCZ_VMASORASM.GetValue(model.STATIONJCFF, ""));//40
                hthhz.Add("FR", "1");
                hthhz.Add("SCSJ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//42
                hthhz2.Clear();
                hthhz2.Add("type", "UPLOAD");
                hthhz2.Add("data", hthhz);
                try
                {
                    string code, msg;
                    if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZXX, out code, out msg))
                    {
                        ini.INIIO.saveLogInf("上传检测站信息至联网平台成功");
                    }
                    else
                    {
                        if (msg.Contains("already exists"))
                        {
                            hthhz2["type"] = "UPDATE";
                            if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZXX, out code, out msg))
                            {
                                ini.INIIO.saveLogInf("更新检测站信息至联网平台成功");
                            }
                            else
                            {
                                MessageBox.Show("更新检测站信息至联网平台失败:code=" + code + ",msg=" + msg);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("上传检测站信息至联网平台失败:code=" + code + ",msg=" + msg);
                            return;
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("上传或更新检测站信息至联网平台发生异常:" + er.Message);
                    return;
                }
                #endregion
            }*/
            MessageBox.Show("检测站信息更改成功");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int linescountToSave = int.Parse(textBoxLinesCount.Text);
            for (int i = 1; i <= linescountToSave; i++)
            {
                string lineid = i.ToString("00");
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
                    linemodel.JCXXKZBH = "";
                    linemodel.YXQSTARTTIME = DateTime.Now;
                    linemodel.YXQENDTIME = DateTime.Now;
                    linemodel.ISLOCK = false;
                    linemodel.LOCKREASON = "";
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
                    linemodel.Hxenable = false;
                    linemodel.Gldate = DateTime.Now;
                    linemodel.Glenable = false;
                    linemodel.Jsgldate = DateTime.Now;
                    linemodel.Jsglenable = false;
                    linemodel.Yljdate = DateTime.Now;
                    linemodel.Yljenable = false;
                    linemodel.Sddate = DateTime.Now;
                    linemodel.Sdenable = false;
                    linemodel.Fxylowdate = DateTime.Now;
                    linemodel.Fxylowenable = false;
                    linemodel.Fxyhighdate = DateTime.Now;
                    linemodel.Fxyhighenable = false;
                    linemodel.Fxymiddate = DateTime.Now;
                    linemodel.Fxymidenable = false;
                    linemodel.Fxylowmiddate = DateTime.Now;
                    linemodel.Fxylowmidenable = false;
                    linemodel.Fxyhighmiddate = DateTime.Now;
                    linemodel.Fxyhighmidenable = false;
                    linemodel.Ydjdate = DateTime.Now;
                    linemodel.Ydjenable = false;
                    linemodel.Lljdate = DateTime.Now;
                    linemodel.Lljenable = false;
                    linemodel.Hjcsdate = DateTime.Now;
                    linemodel.Hjcsenable = false;
                    linemodel.Zsjdate = DateTime.Now;
                    linemodel.Zsjenable = false;
                    linemodel.Yrdate = DateTime.Now;
                    linemodel.Yrenable = false;
                    linemodel.Zjdate = DateTime.Now;
                    linemodel.Zjenable = true;
                    linemodel.Jldate = DateTime.Now;
                    linemodel.Jlenable = false;
                    logininfcontrol.saveLineCalInf(linemodel);
                }
                if (!logininfcontrol.checkLineCompenIsAlive(lineid))
                {
                    compensationModel linemodel = new compensationModel();
                    linemodel.LINEID = lineid;
                    linemodel.ASM_HC = 1;
                    linemodel.ASM_CO = 1;
                    linemodel.ASM_NO = 1;
                    linemodel.VMAS_HC = 1;
                    linemodel.VMAS_CO = 1;
                    linemodel.VMAS_NO = 1;
                    linemodel.SDS_CO = 1;
                    linemodel.SDS_HC = 1;
                    linemodel.ZYJS_K = 1;
                    linemodel.JZJS_K = 1;
                    linemodel.JZJS_GL = 1;
                    linemodel.ISUSE = false;
                    logininfcontrol.saveLineCompensationInf(linemodel);
                }
            }
            for (int i = linescountToSave + 1; i < 20; i++)
            {
                string lineid =  i.ToString("00");
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
                    linemodeltoSave.StationID = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    linemodeltoSave.LINEID = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    linemodeltoSave.ASM = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    linemodeltoSave.VMAS = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    linemodeltoSave.SDS = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    linemodeltoSave.JZJS_LIGHT = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    linemodeltoSave.JZJS_HEAVY = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    linemodeltoSave.ZYJS = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    linemodeltoSave.LZ = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    linemodeltoSave.PRINTER = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    linemodeltoSave.AUTOPRINT = dataGridView1.Rows[i].Cells[10].Value.ToString();
                    linemodeltoSave.JCXXKZBH = dataGridView1.Rows[i].Cells[11].Value.ToString();
                    linemodeltoSave.YXQSTARTTIME = DateTime.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                    linemodeltoSave.YXQENDTIME = DateTime.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                    linemodeltoSave.ISLOCK = (dataGridView1.Rows[i].Cells[14].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.LOCKREASON = dataGridView1.Rows[i].Cells[15].Value.ToString();
                    logininfcontrol.saveLineInf(linemodeltoSave);
                }
                MessageBox.Show("success to update!");

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
                    linemodeltoSave.Jlenable = (dataGridView1.Rows[i].Cells["JLENABLE"].Value.ToString().ToUpper() == "Y");
                    logininfcontrol.saveLineCalInf(linemodeltoSave);
                }
                MessageBox.Show("success to update!");

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
                }
                MessageBox.Show("success to update!");

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
            ini.INIIO.WritePrivateProfileString("联网信息", "安车联网地区", comboBoxAcArea.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "服务器IP", textBoxNeusoftIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "服务器PORT", textBoxNeusoftPort.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "EISID", textBoxEISID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "地区", comboBoxNeusoftArea.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("东软联网", "登录用引车员", comboBoxNeuYcy.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "WEBURL", textBoxJHWEBURL.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "SERVERIP", textBoxJHWEBADD.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "SAFEPWD", textBoxJHSAFEPWD.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "STATIONID", textBoxJHSTATIONID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "LINEID", textBoxJHLINEID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "AREA", comboBoxJHAREA.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "ORACLEIP", textBoxJHDBIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "ORACLEUSER", textBoxJHDBUSER.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "ORACLECODE", textBoxJHDBCODE.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("金华联网", "CHECKPRINT", checkBoxJHCHECKPRINT.Checked ? "Y" : "N", @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("安徽联网", "WEBURL", textBoxAhUrl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("安徽联网", "LINEID", textBoxAHLINEID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("安徽联网", "VERSION", comboBoxAHVERSION.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("联网模式", "模式", comboBoxNETMODE.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("通用联网模式", "联网模式", comboBoxTYNETTYPE.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("南华联网", "WEBURL", textBoxNhWsdl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("南华联网", "LINEID", textBoxNhLineID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "账号", textBoxJXUSER.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "密码", textBoxJXPASSWORD.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "检测线ID", textBoxJXLINEID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "url", textBoxJXurl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "SOCKETIP", textBoxJXSOCKETIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("江西联网", "SOCKETPORT", textBoxJXSOCKETPORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("湖南衡阳联网", "WEBURL", textBoxHNHYURL.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("湖南衡阳联网", "STATIONID", textBoxHNHYJCZBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("湖南衡阳联网", "LINEID", textBoxHNHYJCXBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("大理联网", "LINEID", textBoxDALIJCXBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("大理联网", "SERVERIP", textBoxDALISERVERIP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("大理联网", "SERVERPORT", textBoxDALISERVERPORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("鄂州联网", "WEBURL", textBoxEzUrl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("鄂州联网", "STATIONID", "", @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("鄂州联网", "LINEID", "", @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("红河州联网", "WEBURL", textBoxHhzUrl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("桂林联网", "WEBURL", textBoxGlWeb.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("桂林联网", "USER", textBoxGLUSER.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("桂林联网", "PASSWORD", textBoxGLPASSWORD.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "WEBURL", textBoxZKYTWEB.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "ADD", comboBoxZkytAdd.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "LINEID", textBoxZkytLineID.Text, @".\appConfig.ini");

            mainPanel.zkytwebinf.waitUploadTime = (int)numericUpDownWaitUploadTime.Value;
            mainPanel.zkytwebinf.checkUploadSuccess = checkBoxCheckUploadSuccess.Checked;
            mainPanel.zkytwebinf.displayCheckResult = checkBoxDISPLAYRESULT.Checked;
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "上传超时时间", mainPanel.zkytwebinf.waitUploadTime.ToString(),  @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "验证上传", mainPanel.zkytwebinf.checkUploadSuccess ? "Y" : "N",  @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("中科宇图联网", "显示结果", mainPanel.zkytwebinf.displayCheckResult ? "Y" : "N",  @".\appConfig.ini");

            ini.INIIO.WritePrivateProfileString("广西平南联网", "WebServiceUrl", textBoxGxpnUrl.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("广西平南联网", "WebServiceUser", textBoxGxpnUser.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("广西平南联网", "WebServicePwd", textBoxGxpnPwd.Text, @".\appConfig.ini");

            ini.INIIO.WritePrivateProfileString("喜邦联网", "ip", textBoxXB_IP.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("喜邦联网", "port", textBoxXB_PORT.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("喜邦联网", "certificateNo", textBoxXB_RZBH.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("喜邦联网", "version", textBoxXB_VERSION.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("喜邦联网", "diskNo", textBoxXB_DISKNO.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("喜邦联网", "lineid", textBoxXB_LINEID.Text, @".\appConfig.ini");

            ini.INIIO.WritePrivateProfileString("工作模式", "使用华燕数据库", checkBoxUseHyDb.Checked ? "Y" : "N", @".\appConfig.ini");
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
            string[] addkeyarraycarInf = { "HPZL", "CSYS", "ZXBZ","CCS","ZDJGL","CYXZ" };
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
            listname = "stationNormalInf ";
            string[] addkeyarrayStationNormalInf = { "YWLSH", "CLEARMODE", "JJLX", "LXR", "FZR", "ZCSJ","JCSJ","DJLSH","JCXS","LSHRULE"};
            //keyname = "FOURTHDATA";
            foreach (string keyname in addkeyarrayStationNormalInf)
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
            string[] addkeyarrayStationNormalInf2 = { "STATIONCOUNTDATE", "LOGINCOUNTDATE" };
            foreach (string keyname in addkeyarrayStationNormalInf2)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (basecontrol.addDateTimekeyInList(listname, keyname))
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                    else
                        textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                }
            }
            listname = "Zyjs_Btg";
            string[] addkeyarray = { "FOURTHDATA", "JCFF", "JYLSH", "JYCS", "SBRZBM" };
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
            listname = "ZYJS_XZGB";
            string[] addkeyarrayBTG = { "ONLYTHIS","XZTABLE", "USESDJNXZ", "BTGXZBZ" };
            //keyname = "FOURTHDATA";
            foreach (string keyname in addkeyarrayBTG)
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
            string[] addkeyarray2 = { "CO25025", "O25025", "CO22540", "O22540", "JYLSH", "JYCS", "SBRZBM", "LAMBDA5025", "LAMBDA2540", "JZZGL5025", "JZZGL2540" };
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
            string[] addkeyarraySDS = { "CO2HIGH", "O2HIGH", "CO2LOW", "O2LOW", "JYLSH", "JYCS", "SBRZBM", "COLOWXXZ", "COHIGHXXZ", "COLOWXYZ", "COHIGHXYZ", "CO2LOWXYZ", "CO2HIGHXYZ", "HCLOWXYZ", "HCHIGHXYZ" };
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
            listname = "JZJS";
            string[] addkeyarrayJZJS = { "GLXZXS", "ACTMAXHP", "REALVELMAXHP", "VELMAXHP", "VELMAXHPZS", "RATEREVUP", "RATEREVDOWN", "JYLSH", "JYCS", "SBRZBM", "HNO", "NNO", "ENO" };
            foreach (string keyname in addkeyarrayJZJS)
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
            listname = "VMAS";
            string[] addkeyarrayVMAS = { "CSLJCCSJ", "XSLC", "JYLSH", "JYCS", "SBRZBM" };
            foreach (string keyname in addkeyarrayVMAS)
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
            string[] addkeyarray3 = { "SFCJ", "JYLSH", "HPZL", "ZT", "WXBJ", "WXCD", "WXSJ", "WXFY", "GYXTXS", "SFLJ", "FWLX", "ICCARDNO", "DPFS","SOURCE" };
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
            string[] addkeyarray4 = { "QDLTQY", "RYPH", "HPZL", "JCGCSJ", "WJY", "YWLSH", "BGFFYY","CCS" ,"JYLSH", "ZDJGL", "CYXZ" };
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

            listname = "自检记录";
            string[] addkeyarray5 = { "HSSlideBeginTime", "HSSlideEndTime", "HSSlideTheoreticalTime", "HSSlideActualTime", "HSSlideLoadPower", "LSSlideBeginTime", "LSSlideEndTime", "LSSlideTheoreticalTime", "LSSlideActualTime", "LSSlideLoadPower",
            "WattlessMaxSpeed1","WattlessMinSpeed1","WattlessNorminalSpeed1","WattlessBeginTime1","WattlessEndTime1","WattlessOutput1",
            "WattlessMaxSpeed2","WattlessMinSpeed2","WattlessNorminalSpeed2","WattlessBeginTime2","WattlessEndTime2","WattlessOutput2",
            "WattlessMaxSpeed3","WattlessMinSpeed3","WattlessNorminalSpeed3","WattlessBeginTime3","WattlessEndTime3","WattlessOutput3",
            "WattlessMaxSpeed4","WattlessMinSpeed4","WattlessNorminalSpeed4","WattlessBeginTime4","WattlessEndTime4","WattlessOutput4",
            "O2MRBeginTime","O2MREndTime","WQBeginTime","WQEndTime","SlideJudge","WattlessJudge","O2MRJudge","WQJudge","AllJudge"};
            foreach (string keyname in addkeyarray5)
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
            textBoxUpdate.AppendText("检查表[运行状态]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("运行状态"))
            {
                textBoxUpdate.AppendText("表[运行状态]不存在\r\n");
                basecontrol.createTalbe("运行状态", "CLHP varchar(50) not null primary key, UPDATETIME datetime, ID varchar(50), LINEID varchar(50), STATUS varchar(50), YL1 varchar(50), YL2 varchar(50), YL3 varchar(50), YL4 varchar(50)");
                textBoxUpdate.AppendText("表[运行状态]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[运行状态]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[温湿度共享]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("温湿度共享"))
            {
                textBoxUpdate.AppendText("表[温湿度共享]不存在\r\n");
                basecontrol.createTalbe("温湿度共享", "ID varchar(50) not null primary key, UPDATETIME datetime, WD varchar(50), SD varchar(50), DQY varchar(50)");
                textBoxUpdate.AppendText("表[温湿度共享]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[温湿度共享]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[ZYJS_DATASECONDS]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("ZYJS_DATASECONDS"))
            {
                textBoxUpdate.AppendText("表[ZYJS_DATASECONDS]不存在\r\n");
                basecontrol.createTalbe("ZYJS_DATASECONDS", "CLID varchar(50) not null primary key, CLHP varchar(50), JCSJ datetime, MMTIME varchar(8000), MMSX varchar(8000), MMLB varchar(8000), MMK varchar(8000), MMZS varchar(8000)");
                textBoxUpdate.AppendText("表[ZYJS_DATASECONDS]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[ZYJS_DATASECONDS]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[VMAS_DATASECONDS]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("VMAS_DATASECONDS"))
            {
                textBoxUpdate.AppendText("表[VMAS_DATASECONDS]不存在\r\n");
                basecontrol.createTalbe("VMAS_DATASECONDS", "CLID varchar(50) not null primary key, CLHP varchar(50), JCSJ datetime, MMTIME varchar(8000), MMSX varchar(8000), MMLB varchar(8000), MMCO varchar(8000), MMHC varchar(8000), MMNO varchar(8000), MMCO2 varchar(8000), MMO2 varchar(8000), MMCOZL varchar(8000), MMHCZL varchar(8000), MMNOZL varchar(8000), MMXSO2 varchar(8000), MMHJO2 varchar(8000), MMSJLL varchar(8000), MMBZLL varchar(8000), MMWQLL varchar(8000), MMXSB varchar(8000), MMWD varchar(8000), MMSD varchar(8000), MMDQY varchar(8000), MMLLJWD varchar(8000), MMLLJYL varchar(8000), MMCS varchar(8000), MMBZCS varchar(8000), MMXSXZ varchar(8000), MMSDXZ varchar(8000), MMGLYL varchar(8000), MMYW varchar(8000), MMJSGL varchar(8000), MMNJ varchar(8000), MMGL varchar(8000)");
                textBoxUpdate.AppendText("表[VMAS_DATASECONDS]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[VMAS_DATASECONDS]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[ASM_GDXZ]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("ASM_GDXZ"))
            {
                textBoxUpdate.AppendText("表[ASM_GDXZ]不存在\r\n");
                basecontrol.createTalbe("ASM_GDXZ", "ID varchar(50) not null primary key, CO25 varchar(50), HC25 varchar(50), NO25 varchar(50), CO40 varchar(50), HC40 varchar(50), NO40 varchar(50)");
                textBoxUpdate.AppendText("表[ASM_GDXZ]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[ASM_GDXZ]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[补偿参数]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("补偿参数"))
            {
                textBoxUpdate.AppendText("表[补偿参数]不存在\r\n");
                basecontrol.createTalbe("补偿参数", "LINEID varchar(50), ASM_HC varchar(50), ASM_CO varchar(50), ASM_NO varchar(50), VMAS_CO varchar(50), VMAS_HC varchar(50), VMAS_NO varchar(50), SDS_CO varchar(50), SDS_HC varchar(50), ZYJS_K varchar(50), JZJS_K varchar(50), JZJS_GL varchar(50), ISUSE varchar(1)");
                textBoxUpdate.AppendText("表[补偿参数]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[ASM_GDXZ]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[设备自检数据]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("设备自检数据"))
            {
                textBoxUpdate.AppendText("表[设备自检数据]不存在\r\n");
                basecontrol.createTalbe("设备自检数据", "JCZBH varchar(50), JCGWH varchar(50), SBBH varchar(50), ZJLX varchar(50), ZJSJ datetime," +
                    " DATA1 varchar(50), DATA2 varchar(50), DATA3 varchar(50), DATA4 varchar(50), DATA5 varchar(50), DATA6 varchar(50)," +
                    " DATA7 varchar(50), DATA8 varchar(50), DATA9 varchar(50), DATA10 varchar(50), DATA11 varchar(50), DATA12 varchar(50)," +
                    " DATA13 varchar(50), DATA14 varchar(50), DATA15 varchar(50), DATA16 varchar(50), DATA17 varchar(50), DATA18 varchar(50)," +
                    " DATA19 varchar(50), DATA20 varchar(50), DATA21 varchar(50), DATA22 varchar(50), DATA23 varchar(50), DATA24 varchar(50)," +
                    " DATA25 varchar(50), DATA26 varchar(50), DATA27 varchar(50), DATA28 varchar(50), DATA29 varchar(50), DATA30 varchar(50)," +
                    " DATA31 varchar(50), DATA32 varchar(50), DATA33 varchar(50), DATA34 varchar(50), DATA35 varchar(50), DATA36 varchar(50)," +
                    " DATA37 varchar(50), DATA38 varchar(50), DATA39 varchar(50), DATA40 varchar(50), DATA41 varchar(50), DATA42 varchar(50)," +
                    " ZJJG varchar(50), ZT varchar(50)");
                textBoxUpdate.AppendText("表[设备自检数据]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[设备自检数据]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[设备标定数据]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("设备标定数据"))
            {
                textBoxUpdate.AppendText("表[设备标定数据]不存在\r\n");
                basecontrol.createTalbe("设备标定数据", "JCZBH varchar(50), JCGWH varchar(50), SBBH varchar(50), BDR varchar(50), BDLX varchar(50), BDSJ datetime," +
                    " DATA1 varchar(50), DATA2 varchar(50), DATA3 varchar(50), DATA4 varchar(50), DATA5 varchar(50), DATA6 varchar(50)," +
                    " DATA7 varchar(50), DATA8 varchar(50), DATA9 varchar(50), DATA10 varchar(50), DATA11 varchar(50), DATA12 varchar(50)," +
                    " DATA13 varchar(50), DATA14 varchar(50), DATA15 varchar(50), DATA16 varchar(50), DATA17 varchar(50), DATA18 varchar(50)," +
                    " DATA19 varchar(50), DATA20 varchar(50), DATA21 varchar(50), DATA22 varchar(50), DATA23 varchar(50), DATA24 varchar(50)," +
                    " DATA25 varchar(50), DATA26 varchar(50), DATA27 varchar(50), DATA28 varchar(50), DATA29 varchar(50), DATA30 varchar(50)," +
                    " DATA31 varchar(50), DATA32 varchar(50), DATA33 varchar(50), DATA34 varchar(50), DATA35 varchar(50), DATA36 varchar(50)," +
                    " DATA37 varchar(50), DATA38 varchar(50), DATA39 varchar(50), DATA40 varchar(50), DATA41 varchar(50), DATA42 varchar(50)," +
                    " BDJG varchar(50), ZT varchar(50)");
                textBoxUpdate.AppendText("表[设备标定数据]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[设备标定数据]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[车辆检测状态]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("车辆检测状态"))
            {
                textBoxUpdate.AppendText("表[车辆检测状态]不存在\r\n");
                basecontrol.createTalbe("车辆检测状态", "JCZBH varchar(50), LINEID varchar(50), JYLSH varchar(50), JYCS varchar(50), JCSJ datetime," +
                    " CLHP varchar(50), HPZL varchar(50), ZT varchar(50), YCLZT varchar(50), JCFF varchar(50), BZ varchar(50)");
                textBoxUpdate.AppendText("表[车辆检测状态]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[车辆检测状态]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[不透光限值]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("不透光限值"))
            {
                textBoxUpdate.AppendText("表[不透光限值]不存在\r\n");
                basecontrol.createTalbe("不透光限值", "ID int not null primary key, 车辆型号 varchar(255), 车辆类型 varchar(255), 发动机型号 varchar(255)," +
                    " 发动机生产企业 varchar(255), 形式核准值 varchar(50), 限值 varchar(50), 汽车生产企业 varchar(255)");
                textBoxUpdate.AppendText("表[不透光限值]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[不透光限值]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[ASM_GSXZ]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("ASM_GSXZ"))
            {
                textBoxUpdate.AppendText("表[ASM_GSXZ]不存在\r\n");
                basecontrol.createTalbe("ASM_GSXZ", "ID int not null primary key IDENTITY(1, 1), AREA varchar(50), PFBZ varchar(50), MINRM int, MAXRM int, CO25 varchar(50), HC25 varchar(50), NO25 varchar(50), CO40 varchar(50), HC40 varchar(50), NO40 varchar(50)");
                textBoxUpdate.AppendText("表[ASM_GSXZ]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[ASM_GSXZ]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[综检待检车辆]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("综检待检车辆"))
            {
                textBoxUpdate.AppendText("表[综检待检车辆]不存在\r\n");
                basecontrol.createTalbe("综检待检车辆", "ID int not null primary key IDENTITY(1, 1), JYLSH varchar(50), HPZL varchar(50), JCXZ varchar(50), JCXM varchar(50), SFGC varchar(50),"
                    + " SFKC varchar(50), CLLX varchar(50), SYXZ varchar(50), ZZL varchar(50), ZBZL varchar(50), JGL varchar(50), EDGL varchar(50), EDZS varchar(50), EDNJ varchar(50), EDNJZS varchar(50),"
                    + " EDYH varchar(50), PL varchar(50), LTLX varchar(50), LTDMKD varchar(50), QCGD varchar(50), QLJ varchar(50), QCCD varchar(50), KCDJ varchar(50), HCCSXS varchar(50), QDZKZZL varchar(50),"
                    + " QYCMZZL varchar(50), DLXPJBZ varchar(50), CSBXX varchar(50), CSBSX varchar(50), YHXZ varchar(50), YHCS varchar(50), QDXS varchar(50), BSXStr varchar(50), DWCount varchar(50), QGS varchar(50),"
                    + " CH varchar(50), PQHCLZZ varchar(50), DCZZ varchar(50), RLZL varchar(50), GYTypeID varchar(50), GYTypeStr varchar(50), PQGCount varchar(50), ZKRS varchar(50), ZYTypeID varchar(50), ZYTypeStr varchar(50),"
                    + " DW varchar(50), DWTelephone varchar(50), DWAddres varchar(50)");
                textBoxUpdate.AppendText("表[综检待检车辆]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[综检待检车辆]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[综检已检车辆]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("综检已检车辆"))
            {
                textBoxUpdate.AppendText("表[综检已检车辆]不存在\r\n");
                basecontrol.createTalbe("综检已检车辆", "ID int not null primary key IDENTITY(1, 1), JYLSH varchar(50), HPZL varchar(50), JCXZ varchar(50), JCXM varchar(50), SFGC varchar(50),"
                    + " SFKC varchar(50), CLLX varchar(50), SYXZ varchar(50), ZZL varchar(50), ZBZL varchar(50), JGL varchar(50), EDGL varchar(50), EDZS varchar(50), EDNJ varchar(50), EDNJZS varchar(50),"
                    + " EDYH varchar(50), PL varchar(50), LTLX varchar(50), LTDMKD varchar(50), QCGD varchar(50), QLJ varchar(50), QCCD varchar(50), KCDJ varchar(50), HCCSXS varchar(50), QDZKZZL varchar(50),"
                    + " QYCMZZL varchar(50), DLXPJBZ varchar(50), CSBXX varchar(50), CSBSX varchar(50), YHXZ varchar(50), YHCS varchar(50), QDXS varchar(50), BSXStr varchar(50), DWCount varchar(50), QGS varchar(50),"
                    + " CH varchar(50), PQHCLZZ varchar(50), DCZZ varchar(50), RLZL varchar(50), GYTypeID varchar(50), GYTypeStr varchar(50), PQGCount varchar(50), ZKRS varchar(50), ZYTypeID varchar(50), ZYTypeStr varchar(50),"
                    + " DW varchar(50), DWTelephone varchar(50), DWAddres varchar(50), JCSJ datetime");
                textBoxUpdate.AppendText("表[综检已检车辆]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[综检已检车辆]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[综检待检车辆状态]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("综检待检车辆状态"))
            {
                textBoxUpdate.AppendText("表[综检待检车辆状态]不存在\r\n");
                basecontrol.createTalbe("综检待检车辆状态", "ID int not null primary key IDENTITY(1, 1), JYLSH varchar(50), CSZT varchar(50), YHZT varchar(50), DLZT varchar(50)");
                textBoxUpdate.AppendText("表[综检待检车辆状态]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[综检待检车辆状态]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[综检检测结果]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("综检检测结果"))
            {
                textBoxUpdate.AppendText("表[综检检测结果]不存在\r\n");
                basecontrol.createTalbe("综检检测结果", "ID int not null primary key IDENTITY(1, 1), JYLSH varchar(50), CLHP varchar(50), HPZL varchar(50), DLZT varchar(50), JYXM varchar(50)"
                    + ", RESULTXML varchar(MAX), JCSJ datetime");
                textBoxUpdate.AppendText("表[综检检测结果]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[综检检测结果]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[驱动轴重量]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("驱动轴重量"))
            {
                textBoxUpdate.AppendText("表[驱动轴重量]不存在\r\n");
                basecontrol.createTalbe("驱动轴重量", "ID int not null primary key IDENTITY(1, 1), CLHP varchar(50), HPZL varchar(50), QDZKZZL varchar(50), YL varchar(50), JCSJ datetime");
                textBoxUpdate.AppendText("表[驱动轴重量]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[驱动轴重量]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[油耗仪状态]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("油耗仪状态"))
            {
                textBoxUpdate.AppendText("表[油耗仪状态]不存在\r\n");
                basecontrol.createTalbe("油耗仪状态", "ZT varchar(50), LINEID varchar(50), UPDATETIME datetime");
                textBoxUpdate.AppendText("表[油耗仪状态]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[油耗仪状态]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[SpecialVehicleList]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("SpecialVehicleList"))
            {
                textBoxUpdate.AppendText("表[SpecialVehicleList]不存在\r\n");
                basecontrol.createTalbe("SpecialVehicleList", "ID int not null primary key IDENTITY(1, 1), CLPH varchar(50), HPZL varchar(50), CPYS varchar(50), ZT varchar(50), JCJG varchar(50), JCSJ datetime");
                textBoxUpdate.AppendText("表[SpecialVehicleList]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[SpecialVehicleList]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[SpecialVehicleXz]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("SpecialVehicleXz"))
            {
                textBoxUpdate.AppendText("表[SpecialVehicleXz]不存在\r\n");
                basecontrol.createTalbe("SpecialVehicleXz", "ID int not null primary key IDENTITY(1, 1), VMAS_CO varchar(50), VMAS_HC varchar(50), VMAS_NOX varchar(50), VMAS_HCNOX varchar(50)");
                textBoxUpdate.AppendText("表[SpecialVehicleXz]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[SpecialVehicleXz]已存在\r\n");
            }
            textBoxUpdate.AppendText("检查表[山东烟度限值]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("山东烟度限值"))
            {
                textBoxUpdate.AppendText("表[山东烟度限值]不存在\r\n");
                basecontrol.createTalbe("山东烟度限值", "ID int not null primary key IDENTITY(1, 1), CX varchar(50), PFBZ varchar(50), XZ varchar(50), YL1 varchar(50)");
                textBoxUpdate.AppendText("表[山东烟度限值]已创建\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("表[山东烟度限值]已存在\r\n");
            }
            listname = "车辆检测状态";
            string[] addkeyarrayTestState = { "JCCZY", "YCY", "DLY" };
            foreach (string keyname in addkeyarrayTestState)
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
            if (basecontrol.setKeyIsIdentity(listname))
            {
                textBoxUpdate.AppendText("List:" + listname + "添加identity ID成功\r\n");
            }
            else
            {
                textBoxUpdate.AppendText("List:" + listname + "添加identity ID失败\r\n");
            }
            listname = "ASM_DATASECONDS";
            string[] addkeyarrayASMD = { "MMZSGL","MMNL","MMZT", "JYLSH", "JYCS", "CYDS" };
            foreach (string keyname in addkeyarrayASMD)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (keyname.Contains("MM"))
                    {
                        if (basecontrol.addkeyVacharMaxInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                    else
                    {
                        if (basecontrol.addkeyInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                }
            }
            listname = "VMAS_DATASECONDS";
            string[] addkeyarrayVMASD = { "MMZS", "MMZSGL", "MMJZGL", "MMCO2ZL", "JYLSH", "JYCS", "CYDS" };
            foreach (string keyname in addkeyarrayVMASD)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (keyname.Contains("MM"))
                    {
                        if (basecontrol.addkeyVacharMaxInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                    else
                    {
                        if (basecontrol.addkeyInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                }
            }
            listname = "SDS_DATASECONDS";
            string[] addkeyarraySDSD = { "JYLSH", "JYCS", "CYDS" };
            foreach (string keyname in addkeyarraySDSD)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (keyname.Contains("MM"))
                    {
                        if (basecontrol.addkeyVacharMaxInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                    else
                    {
                        if (basecontrol.addkeyInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                }
            }
            listname = "JZJS_DATASECONDS";
            string[] addkeyarrayJZJSD = { "JYLSH", "JYCS", "CYDS", "MMZS", "MMZGL", "MMZSGL", "MMGLXZXS", "MMJSGL", "MMBTGD", "MMDQYL", "MMXDSD", "MMHJWD", "MMNL", "MMNO" ,"MMYW"};
            foreach (string keyname in addkeyarrayJZJSD)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (keyname.Contains("MM"))
                    {
                        if (basecontrol.addkeyVacharMaxInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                    else
                    {
                        if (basecontrol.addkeyInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                }
            }
            listname = "ZYJS_DATASECONDS";
            string[] addkeyarrayZYJSD = { "JYLSH", "JYCS", "CYDS", "MMYW" };
            foreach (string keyname in addkeyarrayZYJSD)
            {
                if (basecontrol.testKeyIsExist(listname, keyname))
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 已存在\r\n");
                }
                else
                {
                    textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 不存在\r\n");
                    if (keyname.Contains("MM"))
                    {
                        if (basecontrol.addkeyVacharMaxInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                    else
                    {
                        if (basecontrol.addkeyInList(listname, keyname))
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加成功\r\n");
                        else
                            textBoxUpdate.AppendText("List:" + listname + " Key:" + keyname + " 添加失败\r\n");
                    }
                }
            }
            textBoxUpdate.AppendText("检查表[烟度限值数据]是否存在？\r\n");
            if (!basecontrol.checkTableIsExist("烟度限值数据"))
            {
                textBoxUpdate.AppendText("表[烟度限值数据]不存在，请打开sql server maganement studio导入'烟度限值数据.mdb'\r\n");
                
            }
            else
            {
                textBoxUpdate.AppendText("表[烟度限值数据]已存在\r\n");
            }
            basecontrol.UpdateSystemVersion(thissystemversion);

            textBoxUpdate.AppendText("升级完毕\r\n");
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
            bdsxtosave.JLSX = textBoxFXYJL.Text;
            if (stationcontrol.updateBdsx(bdsxtosave))
                MessageBox.Show("保存成功");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cllx, clxh, fdjxh, fdjcj, xshzz, xz, qccj;
            cllx = textBoxBTGCLLX.Text;
            clxh = textBoxBTGCLXH.Text;
            fdjcj = textBoxBTGFDJSCQY.Text;
            fdjxh = textBoxBTGFDJXH.Text;
            xshzz = textBoxBTGFDJXSHZZ.Text;
            qccj = textBoxBTGCLSCQY.Text;
            if (cllx == "")
            {
                MessageBox.Show("请填写车辆类型");
                return;
            }
            if (clxh == "")
            {
                MessageBox.Show("请填写车辆型号");
                return;
            }
            if (fdjcj == "")
            {
                MessageBox.Show("请填写车辆发动机厂家");
                return;
            }
            if (fdjxh == "")
            {
                MessageBox.Show("请填写发动机型号");
                return;
            }
            if (qccj == "")
            {
                MessageBox.Show("请填写车辆生产厂家");
                return;
            }
            if (xshzz == "")
            {
                MessageBox.Show("请填写形式核准值");
                return;
            }
            double xshzzd = 0, xzd = 0;
            if (!double.TryParse(xshzz, out xshzzd))
            {
                MessageBox.Show("形式核准值不是有效数,请检查");
                return;
            }
            xshzz = xshzzd.ToString("0.00");
            xz = (xshzzd + 0.5).ToString("0.00");
            gbdal.saveBtgXz(clxh, cllx, fdjxh, fdjcj, xshzz, xz, qccj);
            showbBTGXzInf();
            MessageBox.Show("添加成功");
        }

        private void buttonSaveBtg_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                carinfor.captureConfigData capturedata = new carinfor.captureConfigData();
                capturedata.captureMethod = comboBoxCapMethod.SelectedIndex;
                capturedata.NVRIP = textBoxNVRIP.Text;
                capturedata.NVRPORT = int.Parse(textBoxNVRPORT.Text);
                capturedata.NVRUSER = textBoxNVRUSER.Text;
                capturedata.NVRPASSWORD = textBoxNVRPASSWORD.Text;
                capturedata.NVRFRONTCHANEL = int.Parse(textBoxNVRFRONTCHANEL.Text);
                capturedata.NVRBACKCHANEL = int.Parse(textBoxNVRBACKCHANEL.Text);
                capturedata.CAMERAFRONTIP = textBoxCAMFRONTIP.Text;
                capturedata.CAMERAFRONTPORT = int.Parse(textBoxCAMFRONTPORT.Text);
                capturedata.CAMERAFRONTUSER = textBoxCAMFRONTUSER.Text;
                capturedata.CAMERAFRONTPASSWORD = textBoxCAMFRONTPASSWORD.Text;
                capturedata.CAMERABACKIP = textBoxCAMBACKIP.Text;
                capturedata.CAMERABACKPORT = int.Parse(textBoxCAMBACKPORT.Text);
                capturedata.CAMERABACKUSER = textBoxCAMBACKUSER.Text;
                capturedata.CAMERABACKPASSWORD = textBoxCAMBACKPASSWORD.Text;
                capturedata.ENABLEFRONT = checkBoxFrontCam.Checked;
                capturedata.ENABLEBACK = checkBoxBackCam.Checked;
                capturedata.cap_vmas_start = checkBoxCAP_VMAS_START.Checked;
                capturedata.cap_vmas_15 = checkBoxCAP_VMAS_15.Checked;
                capturedata.cap_vmas_32 = checkBoxCAP_VMAS_32.Checked;
                capturedata.cap_vmas_50 = checkBoxCAP_VMAS_50.Checked;
                capturedata.cap_asm_start = checkBoxCAP_ASM_START.Checked;
                capturedata.cap_asm_5025 = checkBoxCAP_ASM_5025.Checked;
                capturedata.cap_asm_2540 = checkBoxCAP_ASM_2540.Checked;
                capturedata.cap_sds_start = checkBoxCAP_SDS_START.Checked;
                capturedata.cap_sds_high = checkBoxCAP_SDS_HIGH.Checked;
                capturedata.cap_sds_low = checkBoxCAP_SDS_LOW.Checked;
                capturedata.cap_lugdown_start = checkBoxCAP_LUGDOWN_START.Checked;
                capturedata.cap_lugdown_100 = checkBoxCAP_LUGDOWN_100.Checked;
                capturedata.cap_lugdown_90 = checkBoxCAP_LUGDOWN_90.Checked;
                capturedata.cap_lugdown_80 = checkBoxCAP_LUGDOWN_80.Checked;
                capturedata.cap_btg_start = checkBoxCAP_BTG_START.Checked;
                capturedata.cap_btg_first = checkBoxCAP_BTG_FIRST.Checked;
                capturedata.cap_btg_second = checkBoxCAP_BTG_SECOND.Checked;
                capturedata.cap_btg_third = checkBoxCAP_BTG_THIRD.Checked;
                capturedata.cap_xn_start = checkBoxCAP_XN_START.Checked;
                mainPanel.configini.writeCameraConfigIni(capturedata);
                mainPanel.capturedata = capturedata;
                MessageBox.Show("保存成功.", "系统提示");
            }
            catch
            {
                MessageBox.Show("保存失败，输入格式有误.", "系统提示");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请注意该操作不可恢复，是否确定要将业务流水号清零？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                mainPanel.stationcontrol.setStationLshCount(mainPanel.stationid, "0");
                MessageBox.Show("业务流水号已清零.", "系统提示");
            }
        }

        DataTable dt_wait = null;
        private void init_StationStaff()
        {
            radioButtonMALE.Checked = true;
            init_datagrid();
            init_comboboxstaff();
            ref_Staff();
        }
        private void init_comboboxstaff()
        {
            DataTable dt = null;
            dt = mainPanel.logininfcontrol.getComBoBoxItemsInf("职位");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBoxSTAFFClass.Items.Add(dt.Rows[i]["MC"].ToString());
            }
            comboBoxSTAFFClass.SelectedIndex = 0;
            comboBoxEDUCATION.Items.Add("大专以下");
            comboBoxEDUCATION.Items.Add("大专");
            comboBoxEDUCATION.Items.Add("本科");
            comboBoxEDUCATION.Items.Add("研究生");
            comboBoxEDUCATION.Items.Add("博士");
            comboBoxEDUCATION.Items.Add("大学学历");
            comboBoxEDUCATION.SelectedIndex = 0;
        }
        private void init_sdjn_btgxz()
        {
            init_sdjn_datagrid();
            comboBoxBtg_Cx.SelectedIndex = 0;
            comboBoxBtg_PFBZ.SelectedIndex = 0;
            textBoxBtg_xz.Text = "1.0";
            ref_SdjnBtgXz();
        }
        private void init_sdjn_datagrid()
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridViewStaff.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            DataGridViewButtonColumn btnsave = new DataGridViewButtonColumn();
            btnsave.Name = "btnsave";
            btnsave.DefaultCellStyle.NullValue = "保存";
            btnsave.HeaderText = "保存";
            btnsave.Width = 50;
            DataGridViewButtonColumn btndelete = new DataGridViewButtonColumn();
            btndelete.Name = "btndelete";
            btndelete.DefaultCellStyle.NullValue = "删除";
            btndelete.HeaderText = "删除";
            btndelete.Width = 50;
            DataGridViewComboBoxColumn colcomboboxcx = new DataGridViewComboBoxColumn();
            colcomboboxcx.Items.Add("轻型车");
            colcomboboxcx.Items.Add("重型车");
            DataGridViewComboBoxColumn colcomboboxpfbz = new DataGridViewComboBoxColumn();
            colcomboboxpfbz.Items.Add("国〇");
            colcomboboxpfbz.Items.Add("国Ⅰ");
            colcomboboxpfbz.Items.Add("国Ⅱ");
            colcomboboxpfbz.Items.Add("国Ⅲ");
            colcomboboxpfbz.Items.Add("国Ⅳ");
            colcomboboxpfbz.Items.Add("国Ⅴ");
            colcomboboxpfbz.Items.Add("国Ⅵ");
            colcomboboxcx.HeaderText = "车型";
            colcomboboxcx.Width = 80;
            colcomboboxpfbz.HeaderText = "排放标准";
            colcomboboxpfbz.Width = 80;
            this.dataGridViewBtg_SDJN_XZ.Columns.Add("1", "编号");
            this.dataGridViewBtg_SDJN_XZ.Columns.Add(colcomboboxcx);
            this.dataGridViewBtg_SDJN_XZ.Columns.Add(colcomboboxpfbz);
            this.dataGridViewBtg_SDJN_XZ.Columns.Add("4", "限值");
            this.dataGridViewBtg_SDJN_XZ.Columns.Add(btnsave);
            this.dataGridViewBtg_SDJN_XZ.Columns.Add(btndelete);
            dataGridViewBtg_SDJN_XZ.Columns[0].ReadOnly = true;
            dataGridViewBtg_SDJN_XZ.Columns[1].ReadOnly = true;
            dataGridViewBtg_SDJN_XZ.Columns[2].ReadOnly = true;
        }
        public void ref_SdjnBtgXz()
        {
            try
            {
                DataTable dt = mainPanel.logininfcontrol.getAllSdJnXz();
                DataRow dr = null;
                if (dt != null)
                {
                    this.dataGridViewBtg_SDJN_XZ.Rows.Clear();
                    foreach (DataRow dR in dt.Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        foreach (DataGridViewColumn c in this.dataGridViewBtg_SDJN_XZ.Columns)
                        {
                            dr1.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                        }
                        dr1.Cells[0].Value = dR["ID"].ToString();
                        dr1.Cells[1].Value = dR["CX"].ToString();
                        dr1.Cells[2].Value = dR["PFBZ"].ToString();
                        dr1.Cells[3].Value = dR["XZ"].ToString();
                        this.dataGridViewBtg_SDJN_XZ.Rows.Add(dr1);

                    }
                }
                //dataGridViewStaff.DataSource = dt_wait;
                //dataGridViewStaff.Sort(dataGridViewStaff.Columns["职务ID"], ListSortDirection.Ascending);
            }
            catch (Exception)
            {

            }
        }
        private void init_datagrid()
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridViewStaff.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            DataGridViewButtonColumn btnsave = new DataGridViewButtonColumn();
            btnsave.Name = "btnsave";
            btnsave.DefaultCellStyle.NullValue = "保存";
            btnsave.HeaderText = "保存";
            btnsave.Width = 50;
            DataGridViewButtonColumn btnupload = new DataGridViewButtonColumn();
            btnupload.Name = "btnupload";
            btnupload.DefaultCellStyle.NullValue = "上传";
            btnupload.HeaderText = "上传";
            btnupload.Width = 50;
            DataGridViewButtonColumn btndelete = new DataGridViewButtonColumn();
            btndelete.Name = "btndelete";
            btndelete.DefaultCellStyle.NullValue = "删除";
            btndelete.HeaderText = "删除";
            btndelete.Width = 50;
            DataGridViewComboBoxColumn colcomboboxpost = new DataGridViewComboBoxColumn();
            DataTable dt = null;
            dt = mainPanel.logininfcontrol.getComBoBoxItemsInf("职位");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                colcomboboxpost.Items.Add(dt.Rows[i]["MC"].ToString());
            }
            colcomboboxpost.HeaderText = "职务";
            colcomboboxpost.Width = 150;
            DataGridViewComboEditBoxColumn colcomboboxsex = new DataGridViewComboEditBoxColumn();
            colcomboboxsex.Items.Add("女");
            colcomboboxsex.Items.Add("男");
            colcomboboxsex.HeaderText = "性别";
            colcomboboxsex.Width = 50;
            DataGridViewComboEditBoxColumn colcomboboxedu = new DataGridViewComboEditBoxColumn();
            colcomboboxedu.Items.Add("大专以下");
            colcomboboxedu.Items.Add("大专");
            colcomboboxedu.Items.Add("本科");
            colcomboboxedu.Items.Add("研究生");
            colcomboboxedu.Items.Add("博士");
            colcomboboxedu.Items.Add("大学学历");
            colcomboboxedu.HeaderText = "学历";
            colcomboboxedu.Width = 120;
            //colcomboboxedu.HeaderText = "学历";
            //colcomboboxedu.Width = 100;


            this.dataGridViewStaff.Columns.Add("1", "编号");
            this.dataGridViewStaff.Columns.Add("2", "姓名");
            this.dataGridViewStaff.Columns.Add("3", "职务ID");
            this.dataGridViewStaff.Columns.Add(colcomboboxpost);
            this.dataGridViewStaff.Columns.Add(colcomboboxsex);
            this.dataGridViewStaff.Columns.Add("6", "生日");
            this.dataGridViewStaff.Columns.Add("7", "电话");
            this.dataGridViewStaff.Columns.Add(colcomboboxedu);
            this.dataGridViewStaff.Columns.Add("9", "地址");
            this.dataGridViewStaff.Columns.Add(btnsave);
            this.dataGridViewStaff.Columns.Add(btnupload);
            this.dataGridViewStaff.Columns.Add(btndelete);
            dataGridViewStaff.Columns["3"].Visible = false;
            dataGridViewStaff.Columns["1"].Width = 50;
            dataGridViewStaff.Columns["2"].Width = 80;
            //dataGridViewStaff.Columns["4"].Width = 100;
            //dataGridViewStaff.Columns["5"].Width = 100;
            dataGridViewStaff.Columns["6"].Width = 100;
            dataGridViewStaff.Columns["7"].Width = 100;
            //dataGridViewStaff.Columns["8"].Width = 100;
            dataGridViewStaff.Columns["9"].Width = 250;
            dataGridViewStaff.Columns["1"].ReadOnly = true;
            dataGridViewStaff.Columns["2"].ReadOnly = true;
            dataGridViewStaff.Columns[10].Visible = false;
        }
        private bool checkInfIsRight()
        {
            if (textBoxSTAFFID.Text.Length != 3)
            {
                MessageBox.Show("员工编号必须为3位有效数字，不足3位请在前补0，如001", "系统提示");
                return false;
            }
            if (textBoxSTAFFNAME.Text == "")
            {
                MessageBox.Show("请填写用户姓名", "系统提示");
                return false;
            }
            if (comboBoxSTAFFClass.Text == "")
            {
                MessageBox.Show("请选择用户职位", "系统提示");
                return false;
            }
            if (textBoxNEWPASSWORD.Text == "")
            {
                MessageBox.Show("请输入初始密码", "系统提示");
                return false;
            }
            if (textBoxNEWPASSWORD.Text != textBoxNEWPASSWORD2.Text)
            {
                MessageBox.Show("两次密码输入不一致", "系统提示");
                return false;
            }
            return true;
        }
        public void ref_Staff()
        {
            try
            {
                DataTable dt = mainPanel.logininfcontrol.getAllStaff();
                DataRow dr = null;
                if (dt != null)
                {
                    this.dataGridViewStaff.Rows.Clear();
                    foreach (DataRow dR in dt.Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        foreach (DataGridViewColumn c in this.dataGridViewStaff.Columns)
                        {
                            dr1.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                        }
                        dr1.Cells[0].Value = dR["STAFFID"].ToString();
                        dr1.Cells[1].Value = dR["NAME"].ToString();
                        dr1.Cells[2].Value = dR["POSTID"].ToString();
                        dr1.Cells[3].Value = mainPanel.logininfcontrol.getPostNamebyPostID(dR["POSTID"].ToString());
                        dr1.Cells[4].Value = dR["SEX"].ToString();
                        dr1.Cells[5].Value = DateTime.Parse(dR["BIRTHDAY"].ToString()).ToString("yyyy-MM-dd");
                        dr1.Cells[6].Value = dR["PHONE"].ToString();
                        dr1.Cells[7].Value = dR["EDUCATION"].ToString();
                        dr1.Cells[8].Value = dR["ADDRESS"].ToString();
                        this.dataGridViewStaff.Rows.Add(dr1);

                    }
                }
                //dataGridViewStaff.DataSource = dt_wait;
                //dataGridViewStaff.Sort(dataGridViewStaff.Columns["职务ID"], ListSortDirection.Ascending);
            }
            catch (Exception)
            {

            }
        }
        private void buttonSAVEINF_Click(object sender, EventArgs e)
        {
            if (!checkInfIsRight()) return;
            SYS_MODEL.staffModel staffmodel = new SYS_MODEL.staffModel();
            staffmodel.STAFFID = textBoxSTAFFID.Text;
            staffmodel.NAME = textBoxSTAFFNAME.Text;
            staffmodel.ID = textBoxSTAFFID.Text;
            staffmodel.POSTID = mainPanel.logininfcontrol.getPostIDbyPostName(comboBoxSTAFFClass.Text);
            staffmodel.BIRTHDAY = dateBIRTHDAY.Value.ToString("yyyy-MM-dd");
            staffmodel.ADDRESS = textBoxSTAFFADDRESS.Text;
            staffmodel.AGE = "";
            staffmodel.PHONE = textBoxSTAFFTEL.Text;
            staffmodel.QQ = "";
            staffmodel.EMAIL = "";
            staffmodel.EDUCATION = comboBoxEDUCATION.Text;
            staffmodel.PASSWORD = textBoxNEWPASSWORD.Text;
            staffmodel.CZRYXKZH = "";
            staffmodel.YXQSTARTTIME = DateTime.Now;
            staffmodel.YXQENDTIME = DateTime.Now;
            staffmodel.ISLOCK = false;
            staffmodel.LOCKREASON = "";
            if (radioButtonMALE.Checked) staffmodel.SEX = "男";
            else staffmodel.SEX = "女";
            staffmodel.MARRIED = "";
            if (mainPanel.logininfcontrol.checkUserIsAlive(staffmodel.STAFFID))
            {
                MessageBox.Show("该编号已存在，不能重复注册", "系统提示");
                return;
            }
            if (mainPanel.logininfcontrol.saveStaffInf(staffmodel))
            {
                /*
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                {
                    #region 红河州联网上传检测站信息
                    System.Collections.Hashtable hthhz = new System.Collections.Hashtable();
                    System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                    hthhz.Add("JCRYBM", stationinfmodel.STATIONID+staffmodel.STAFFID);
                    hthhz.Add("YHM",staffmodel.NAME);
                    hthhz.Add("PSN_PWD","");
                    hthhz.Add("XM", staffmodel.NAME);
                    hthhz.Add("PSN_DESC", "");// mainPanel.hhzinterface.HhzR_JCZ_JJLX.GetValue(model.JJLX, ""));//5
                    hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                    hthhz.Add("SGSJ", DateTime.Now.ToString("yyyy-MM-dd"));
                    hthhz.Add("DPASSDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    hthhz.Add("NADVICE","");
                    hthhz.Add("BISPASS", "");//10
                    hthhz.Add("EXT_COLI", "0");
                    hthhz2.Clear();
                    hthhz2.Add("type", "UPLOAD");
                    hthhz2.Add("data", hthhz);
                    try
                    {
                        string code, msg;
                        if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRY, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("上传人员信息至联网平台成功");
                        }
                        else
                        {
                            if (msg.Contains("already exists"))
                            {
                                hthhz2["type"] = "UPDATE";
                                if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRY, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("更新人员信息至联网平台成功");
                                }
                                else
                                {
                                    MessageBox.Show("更新人员信息至联网平台失败:code=" + code + ",msg=" + msg);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("上传人员信息至联网平台失败:code=" + code + ",msg=" + msg);
                                return;
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("上传或更新人员信息至联网平台发生异常:" + er.Message);
                        return;
                    }
                    hthhz.Clear();
                    hthhz2.Clear();
                    hthhz.Add("JCZRYBM", stationinfmodel.STATIONID + staffmodel.STAFFID);
                    hthhz.Add("XB", mainPanel.hhzinterface.HhzR_PERSON_SEX.GetValue(staffmodel.SEX,"1"));
                    hthhz.Add("CSRQ",staffmodel.BIRTHDAY);
                    hthhz.Add("ZW", "");
                    hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                    hthhz.Add("RZRQ", DateTime.Now.ToString("yyyy-MM-dd"));
                    hthhz.Add("SCSJ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    hthhz.Add("SFZH", "");
                    hthhz.Add("XL", mainPanel.hhzinterface.HhzR_PERSON_EDUCATION.GetValue(staffmodel.EDUCATION, "2"));//10
                    hthhz.Add("ZT", "0");
                    hthhz.Add("BZ", "");//10
                    hthhz.Add("DZYX", "");//10
                    hthhz2.Clear();
                    hthhz2.Add("type", "UPLOAD");
                    hthhz2.Add("data", hthhz);
                    try
                    {
                        string code, msg;
                        if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRYKZ, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("上传人员扩展信息至联网平台成功");
                        }
                        else
                        {
                            if (msg.Contains("already exists"))
                            {
                                hthhz2["type"] = "UPDATE";
                                if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRYKZ, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("更新人员扩展信息至联网平台成功");
                                }
                                else
                                {
                                    MessageBox.Show("更新人员扩展信息至联网平台失败:code=" + code + ",msg=" + msg);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("上传人员扩展信息至联网平台失败:code=" + code + ",msg=" + msg);
                                return;
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("上传或更新人员扩展信息至联网平台发生异常:" + er.Message);
                        return;
                    }
                    #endregion
                }*/
                MessageBox.Show("用户注册成功", "系统提示");
            }
            else
                MessageBox.Show("未知原因导致用户注册失败", "系统提示");
            ref_Staff();
        }

        private void dataGridViewStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewStaff.Columns["btnsave"].Index)
                {
                    int index = e.RowIndex;
                    if (dataGridViewStaff.Rows[index].Cells[1].Value.ToString() == "admin")
                    {
                        MessageBox.Show("禁止修改管理员用户", "系统提示");
                        return;
                    }
                    staffModel staffmodel = new staffModel();
                    DateTime birthday = DateTime.Now;
                    if (DateTime.TryParse(dataGridViewStaff.Rows[index].Cells[5].Value.ToString(), out birthday))
                    {
                        staffmodel.BIRTHDAY = birthday.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBox.Show("生日格式不规范:1988-07-28");
                        return;
                    }
                    staffmodel = mainPanel.logininfcontrol.GetStaffInf(dataGridViewStaff.Rows[index].Cells[0].Value.ToString());
                    //staffmodel.STAFFID = dataGridViewStaff.Rows[index].Cells[0].Value.ToString();
                    //staffmodel.NAME = dataGridViewStaff.Rows[index].Cells[1].Value.ToString();
                    //staffmodel.ID = dataGridViewStaff.Rows[index].Cells[0].Value.ToString();
                    staffmodel.POSTID = mainPanel.logininfcontrol.getPostIDbyPostName(dataGridViewStaff.Rows[index].Cells[3].Value.ToString());
                    staffmodel.ADDRESS = dataGridViewStaff.Rows[index].Cells[8].Value.ToString();
                    //staffmodel.AGE = "";
                    staffmodel.PHONE = dataGridViewStaff.Rows[index].Cells[6].Value.ToString();
                    //staffmodel.QQ = "";
                    //staffmodel.EMAIL = "";
                    staffmodel.EDUCATION = dataGridViewStaff.Rows[index].Cells[7].Value.ToString();
                    staffmodel.SEX = dataGridViewStaff.Rows[index].Cells[4].Value.ToString();
                    //staffmodel.MARRIED = "";
                    //staffmodel.CZRYXKZH = "";
                    //staffmodel.YXQSTARTTIME = DateTime.Now;
                    //staffmodel.YXQENDTIME = DateTime.Now;
                    // staffmodel.ISLOCK = false;
                    //staffmodel.LOCKREASON = "";

                    if (mainPanel.logininfcontrol.updateStaffInf(staffmodel))
                    {
                        /*
                        if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                        {
                            #region 红河州联网上传检测站信息
                            System.Collections.Hashtable hthhz = new System.Collections.Hashtable();
                            System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                            hthhz.Add("JCRYBM", stationinfmodel.STATIONID + staffmodel.STAFFID);
                            hthhz.Add("YHM", staffmodel.NAME);
                            hthhz.Add("PSN_PWD", "");
                            hthhz.Add("XM", staffmodel.NAME);
                            hthhz.Add("PSN_DESC", "");// mainPanel.hhzinterface.HhzR_JCZ_JJLX.GetValue(model.JJLX, ""));//5
                            hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                            hthhz.Add("SGSJ", DateTime.Now.ToString("yyyy-MM-dd"));
                            hthhz.Add("DPASSDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                            hthhz.Add("NADVICE", "");
                            hthhz.Add("BISPASS", "");//10
                            hthhz.Add("EXT_COLI", "0");
                            hthhz2.Clear();
                            hthhz2.Add("type", "UPLOAD");
                            hthhz2.Add("data", hthhz);
                            try
                            {
                                string code, msg;
                                if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRY, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("上传人员信息至联网平台成功");
                                }
                                else
                                {
                                    if (msg.Contains("already exists"))
                                    {
                                        hthhz2["type"] = "UPDATE";
                                        if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRY, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("更新人员信息至联网平台成功");
                                        }
                                        else
                                        {
                                            MessageBox.Show("更新人员信息至联网平台失败:code=" + code + ",msg=" + msg);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("上传人员信息至联网平台失败:code=" + code + ",msg=" + msg);
                                        return;
                                    }
                                }
                            }
                            catch (Exception er)
                            {
                                MessageBox.Show("上传或更新人员信息至联网平台发生异常:" + er.Message);
                                return;
                            }

                            hthhz.Clear();
                            hthhz2.Clear();
                            hthhz.Add("JCZRYBM", stationinfmodel.STATIONID + staffmodel.STAFFID);
                            hthhz.Add("XB", mainPanel.hhzinterface.HhzR_PERSON_SEX.GetValue(staffmodel.SEX, "1"));
                            hthhz.Add("CSRQ",DateTime.Parse( staffmodel.BIRTHDAY).ToString("yyyy-MM-dd"));
                            hthhz.Add("ZW", "");
                            hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                            hthhz.Add("RZRQ", DateTime.Now.ToString("yyyy-MM-dd"));
                            hthhz.Add("SCSJ", DateTime.Now.ToString("yyyy-MM-dd"));
                            hthhz.Add("SFZH", "");
                            hthhz.Add("XL", mainPanel.hhzinterface.HhzR_PERSON_EDUCATION.GetValue(staffmodel.EDUCATION, "2"));//10
                            hthhz.Add("ZT", "0");
                            hthhz.Add("BZ", "");//10
                            hthhz.Add("DZYX", "");//10
                            hthhz2.Clear();
                            hthhz2.Add("type", "UPLOAD");
                            hthhz2.Add("data", hthhz);
                            try
                            {
                                string code, msg;
                                if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRYKZ, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("上传人员扩展信息至联网平台成功");
                                }
                                else
                                {
                                    if (msg.Contains("already exists"))
                                    {
                                        hthhz2["type"] = "UPDATE";
                                        if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCZRYKZ, out code, out msg))
                                        {
                                            ini.INIIO.saveLogInf("更新人员扩展信息至联网平台成功");
                                        }
                                        else
                                        {
                                            MessageBox.Show("更新人员扩展信息至联网平台失败:code=" + code + ",msg=" + msg);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("上传人员扩展信息至联网平台失败:code=" + code + ",msg=" + msg);
                                        return;
                                    }
                                }
                            }
                            catch (Exception er)
                            {
                                MessageBox.Show("上传或更新人员扩展信息至联网平台发生异常:" + er.Message);
                                return;
                            }
                            #endregion
                        }*/
                        MessageBox.Show("用户信息更改成功", "系统提示");
                    }
                    else
                        MessageBox.Show("未知原因导致用户信息更改失败", "系统提示");
                }
                else if (e.ColumnIndex == dataGridViewStaff.Columns["btnupload"].Index)
                { MessageBox.Show("上传" + e.RowIndex.ToString()); }
                else if (e.ColumnIndex == dataGridViewStaff.Columns["btndelete"].Index)
                {
                    int index = e.RowIndex;
                    if (dataGridViewStaff.Rows[index].Cells[1].Value.ToString() == "admin")
                    {
                        MessageBox.Show("禁止删除管理员用户", "系统提示");
                        return;
                    }
                    mainPanel.logininfcontrol.deleteOnePerson(dataGridViewStaff.Rows[index].Cells[0].Value.ToString());
                    MessageBox.Show("删除成功", "系统提示");
                    ref_Staff();
                }
            }
            catch
            { }
        }

        private void buttonHHZ_UPLOADJCZ_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["btnsave"].Index)
                {
                    int index = e.RowIndex;
                    lineModel linemodeltoSave = new lineModel();
                    linemodeltoSave.StationID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    linemodeltoSave.LINEID = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    linemodeltoSave.ASM = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    linemodeltoSave.VMAS = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    linemodeltoSave.SDS = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    linemodeltoSave.JZJS_LIGHT = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    linemodeltoSave.JZJS_HEAVY = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    linemodeltoSave.ZYJS = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    linemodeltoSave.LZ = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    linemodeltoSave.PRINTER = dataGridView1.Rows[index].Cells[9].Value.ToString();
                    linemodeltoSave.AUTOPRINT = dataGridView1.Rows[index].Cells[10].Value.ToString();
                    linemodeltoSave.JCXXKZBH = dataGridView1.Rows[index].Cells[11].Value.ToString();
                    linemodeltoSave.YXQSTARTTIME = DateTime.Parse(dataGridView1.Rows[index].Cells[12].Value.ToString());
                    linemodeltoSave.YXQENDTIME = DateTime.Parse(dataGridView1.Rows[index].Cells[13].Value.ToString());
                    linemodeltoSave.ISLOCK = (dataGridView1.Rows[index].Cells[14].Value.ToString().ToUpper() == "Y");
                    linemodeltoSave.LOCKREASON = dataGridView1.Rows[index].Cells[15].Value.ToString();

                    logininfcontrol.saveLineInf(linemodeltoSave);
                    string jcxlx = "";
                    if (linemodeltoSave.JZJS_HEAVY == "Y" || linemodeltoSave.JZJS_LIGHT == "Y" || linemodeltoSave.ZYJS == "Y")
                    {
                        if (linemodeltoSave.SDS == "Y" || linemodeltoSave.ASM == "Y" || linemodeltoSave.VMAS == "Y")
                            jcxlx = "汽柴混合";
                        else if (linemodeltoSave.JZJS_HEAVY == "Y"||linemodeltoSave.ZYJS=="Y")
                            jcxlx = "重柴";
                        else
                            jcxlx = "轻柴";
                    }
                    else
                    {
                        if (linemodeltoSave.SDS == "Y")
                            jcxlx = "重汽";
                        else
                            jcxlx = "轻汽";
                    }
                    /*
                    if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                    {
                        #region 红河州联网上传检测线信息
                        equipmentModel lineequip = mainPanel.stationcontrol.getLineEquipInf(linemodeltoSave.StationID, linemodeltoSave.LINEID);
                        System.Collections.Hashtable hthhz = new System.Collections.Hashtable();
                        System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                        hthhz.Add("JCXBM", linemodeltoSave.StationID + linemodeltoSave.LINEID);
                        hthhz.Add("JCXMC", lineequip.SBMC);
                        hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                        hthhz.Add("JCXLX", mainPanel.hhzinterface.HhzR_LINE_TYPE.GetValue(jcxlx,"0"));
                        hthhz.Add("JCXSBCS", lineequip.SBZZC);
                        hthhz.Add("CJRQ", linemodeltoSave.YXQSTARTTIME.ToString("yyyy-MM-dd"));
                        hthhz.Add("JCXZT", "1");// mainPanel.hhzinterface.HhzR_JCZ_JJLX.GetValue(model.JJLX, ""));//5
                        hthhz.Add("JCXSZ", "0");
                        hthhz.Add("BZ", "");
                        hthhz.Add("EISBBH", "0");
                        hthhz.Add("EISBH", "0");
                        hthhz.Add("CZRYBM", "0");
                        hthhz.Add("HHZSFQY", "0");
                        hthhz.Add("DXQSFQY", "0");
                        hthhz.Add("CGJHXJCCYZQ", "24");
                        hthhz.Add("DPCGJ", lineequip.CGJXH);
                        hthhz.Add("PQFXYQ", lineequip.FXYXH);
                        hthhz.Add("SBRZBM", linemodeltoSave.JCXXKZBH);
                        hthhz.Add("SBMC", lineequip.SBMC);
                        hthhz.Add("XH", lineequip.SBXH);
                        hthhz.Add("JCXNBGWH", linemodeltoSave.LINEID);
                        hthhz.Add("JCXYFFZDBZH", "");
                        hthhz.Add("GJCXZHYCFBSJ", "");
                        hthhz.Add("SCSJ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        hthhz.Add("JCXSBJDYXQ", linemodeltoSave.YXQENDTIME.ToString("yyyy-MM-dd"));
                        hthhz2.Clear();
                        hthhz2.Add("type", "UPLOAD");
                        hthhz2.Add("data", hthhz);
                        try
                        {
                            string code, msg;
                            if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCXXX, out code, out msg))
                            {
                                ini.INIIO.saveLogInf("上传检测线信息至联网平台成功");
                            }
                            else
                            {
                                if (msg.Contains("already exists"))
                                {
                                    hthhz2["type"] = "UPDATE";
                                    if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.JCXXX, out code, out msg))
                                    {
                                        ini.INIIO.saveLogInf("更新检测线信息至联网平台成功");
                                    }
                                    else
                                    {
                                        MessageBox.Show("更新检测线信息至联网平台失败:code=" + code + ",msg=" + msg);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("上传检测线信息至联网平台失败:code=" + code + ",msg=" + msg);
                                    return;
                                }
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("上传或更新检测线信息至联网平台发生异常:" + er.Message);
                            return;
                        }
                        #endregion
                    }*/
                    MessageBox.Show("保存成功!");
                }
            }
            catch
            { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.HHZNNETMODE)
                {
                    #region 红河州联网上传摄像信息
                    System.Collections.Hashtable hthhz = new System.Collections.Hashtable();
                    System.Collections.Hashtable hthhz2 = new System.Collections.Hashtable();
                    hthhz.Add("SXTBM", stationinfmodel.STATIONID+ mainPanel.lineid+"01");
                    hthhz.Add("JCZBM", stationinfmodel.STATIONID);
                    hthhz.Add("JCZQHDM", "");
                    hthhz.Add("JCZMC",stationinfmodel.STATIONNAME);
                    hthhz.Add("JCXBM", stationinfmodel.STATIONID + mainPanel.lineid);
                    hthhz.Add("SXSBMC", "");
                    hthhz.Add("XH", "1");// mainPanel.hhzinterface.HhzR_JCZ_JJLX.GetValue(model.JJLX, ""));//5
                    hthhz.Add("SXSBSCCS", "海康威视");
                    hthhz.Add("SXSBZT", "0");
                    hthhz.Add("IPC_H", textBoxCAMFRONTIP.Text);
                    hthhz.Add("IPC_E", textBoxCAMBACKIP.Text);
                    hthhz.Add("NVR_H_CH", textBoxNVRFRONTCHANEL.Text);
                    hthhz.Add("NVR_E_CH",textBoxNVRBACKCHANEL.Text);
                    hthhz.Add("NVR_URL", textBoxNVRIP.Text);
                    hthhz.Add("USR", textBoxNVRUSER.Text);
                    hthhz.Add("PWD", textBoxNVRPASSWORD.Text);
                    hthhz.Add("SCSJ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    hthhz2.Clear();
                    hthhz2.Add("type", "UPLOAD");
                    hthhz2.Add("data", hthhz);
                    try
                    {
                        string code, msg;
                        if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.SXJLSB, out code, out msg))
                        {
                            ini.INIIO.saveLogInf("上传摄像记录信息至联网平台成功");
                        }
                        else
                        {
                            if (msg.Contains("already exists"))
                            {
                                hthhz2["type"] = "UPDATE";
                                if (mainPanel.hhzinterface.uploadJsonArray(hthhz2, HhzWebClient.Hhzclient.DATALX.SXJLSB, out code, out msg))
                                {
                                    ini.INIIO.saveLogInf("更新摄像记录信息至联网平台成功");
                                }
                                else
                                {
                                    MessageBox.Show("更新摄像记录信息至联网平台失败:code=" + code + ",msg=" + msg);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("上传摄像记录信息至联网平台失败:code=" + code + ",msg=" + msg);
                                return;
                            }
                        }
                        MessageBox.Show("上传成功!");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("上传或更新摄像记录信息至联网平台发生异常:" + er.Message);
                        return;
                    }
                    #endregion
                }

                else
                {
                    MessageBox.Show("该模式下没有上传相关操作!");
                }*/
            }
            catch
            { }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请注意该操作不可恢复，是否确定要将登记流水号清零？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                mainPanel.stationcontrol.setStationLshCount(mainPanel.stationid, "0");
                MessageBox.Show("业务流水号已清零.", "系统提示");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            ZYJS_XZGB btgxz = new ZYJS_XZGB();
            btgxz.WLDate20011001btgxz = textBoxBTGWLZY.Text;
            btgxz.ZRDate20011001btgxz = textBoxBTGZRXQ.Text;
            btgxz.onlyUseThis = checkBoxBtgXz.Checked;
            btgxz.XZTABLE = comboBoxBTGXZTABLE.SelectedIndex;
            btgxz.BTGXZBZ = comboBoxBTG_XZBZ.SelectedIndex;
            if (gbdal.updateZYJS_XZGB(btgxz))
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败");
        }

        private void comboBoxBTGXZTABLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable vmasxzdt = gbdal.Get_ALL_BTG_XZBZ(comboBoxBTGXZTABLE.SelectedIndex);
                if (vmasxzdt != null)
                {
                    dataGridViewBTGXZ.DataSource = vmasxzdt;
                    //dataGridViewVmasXz1.DataSource = vmasxzdt;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("读取限值表出现异常：" + er.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string cx, pfbz, xz;
            double xz_temp;
            cx = comboBoxBtg_Cx.Text;
            pfbz = comboBoxBtg_PFBZ.Text;
            xz = textBoxBtg_xz.Text;
            if (!double.TryParse(xz, out xz_temp))
            {
                MessageBox.Show("限值格式不正确" );
                return;
            }
            if (mainPanel.logininfcontrol.checkSdJnXzAlive(cx,pfbz))
            {
                MessageBox.Show("该项限值已存在，不能重复添加", "系统提示");
                return;
            }
            if (mainPanel.logininfcontrol.saveSdjnxz(cx, pfbz,xz))
            {                
                MessageBox.Show("添加成功", "系统提示");
            }
            else
                MessageBox.Show("添加失败", "系统提示");
            ref_SdjnBtgXz();
        }

        private void dataGridViewBtg_SDJN_XZ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cx, pfbz, xz;
                double xz_temp;
                if (e.ColumnIndex == dataGridViewBtg_SDJN_XZ.Columns["btnsave"].Index)
                {
                    int index = e.RowIndex;
                    cx = dataGridViewBtg_SDJN_XZ.Rows[index].Cells[1].Value.ToString();
                    pfbz = dataGridViewBtg_SDJN_XZ.Rows[index].Cells[2].Value.ToString();
                    xz = dataGridViewBtg_SDJN_XZ.Rows[index].Cells[3].Value.ToString();
                    if (!double.TryParse(xz, out xz_temp))
                    {
                        MessageBox.Show("限值格式不正确");
                        return;
                    }
                    if (mainPanel.logininfcontrol.updateSdydxz(cx,pfbz,xz))
                    {
                        MessageBox.Show("信息更改成功", "系统提示");
                    }
                    else
                        MessageBox.Show("未知原因导致信息更改失败", "系统提示");
                }
                else if (e.ColumnIndex == dataGridViewBtg_SDJN_XZ.Columns["btndelete"].Index)
                {
                    int index = e.RowIndex;
                    cx = dataGridViewBtg_SDJN_XZ.Rows[index].Cells[1].Value.ToString();
                    pfbz = dataGridViewBtg_SDJN_XZ.Rows[index].Cells[2].Value.ToString();

                    mainPanel.logininfcontrol.deleteOneSdjnXz(cx, pfbz);
                    MessageBox.Show("删除成功", "系统提示");
                    ref_SdjnBtgXz();
                }
            }
            catch
            { }
        }

        private void label74_Click(object sender, EventArgs e)
        {

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
    public class DataGridViewComboEditBoxColumn : DataGridViewComboBoxColumn
    {

        public DataGridViewComboEditBoxColumn()
        {

            DataGridViewComboEditBoxCell obj = new DataGridViewComboEditBoxCell(); this.CellTemplate = obj;
        }
    }

    //要加入的类

    public class DataGridViewComboEditBoxCell : DataGridViewComboBoxCell
    {

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {

            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ComboBox comboBox = (ComboBox)base.DataGridView.EditingControl;

            if (comboBox != null)
            {

                comboBox.DropDownStyle = ComboBoxStyle.DropDown; comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;

                comboBox.Validating += new CancelEventHandler(comboBox_Validating);
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {

            if (value != null)
            {

                if (value.ToString().Trim() != string.Empty)
                {

                    if (Items.IndexOf(value) == -1)
                    {

                        Items.Add(value);

                        DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)OwningColumn; col.Items.Add(value);
                    }
                }
            }

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            DataGridViewComboBoxEditingControl cbo = (DataGridViewComboBoxEditingControl)sender; if (cbo.Text.Trim() == string.Empty) return;

            DataGridView grid = cbo.EditingControlDataGridView; object value = cbo.Text;

            // Add value to list if not there if (cbo.Items.IndexOf(value) == -1) {

            DataGridViewComboBoxColumn cboCol = (DataGridViewComboBoxColumn)grid.Columns[grid.CurrentCell.ColumnIndex]; // Must add to both the current combobox as well as the template, to avoid duplicate entries cbo.Items.Add(value); cboCol.Items.Add(value); grid.CurrentCell.Value = value; } } }
        }

    }
}
