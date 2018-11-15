using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Xml;
using System.IO;
using carinfor;
using System.Linq;
using System.Reflection;
using ini;
using System.Collections;

namespace carinfo
{
    public class XB_AUTHENTCATION
    {
        public string cmd;
        public string version;
        public string certificate;
        public string station_id;
        public string detect_line_id;
        public string hd_seria_number;
    }
    public class XB_USER
    {
        public string name;
        public string emp_name;
        public string role;
    }
    public class XB_ENVIRONMENT
    {
        public double TEMPL;
        public double TEMPH;
        public double HUML;
        public double HUMH;
        public double ATML;
        public double ATMH;
        public XB_ENVIRONMENT()
        {
            TEMPL = 0;
            TEMPH = 0;
            HUML = 0;
            HUMH = 0;
            ATML = 0;
            ATMH = 0;
        }

    }
    public class XB_CARLIST
    {
        public string JCLSH;
        public string JCCS;
        public string HPHM;
        public string HPZLBH;
        public string HPZL;
        public string JCFFBH;
        public string JCFF;
        public string JCLB;
        public string JCRLZL;
        public string TMBH;
        public XB_CARLIST()
        {
            JCLSH = "";
        }
    }
    public class XB_CARINFO
    {
        public string JCLSH;
        public string JCCS;
        public string HPHM;
        public string HPZLBH;
        public string HPZL;
        public string JCFFBH;
        public string JCFF;
        public string CLLBBH;
        public string CLLB;
        public string CLLXBH;
        public string CLLX;
        public string FDJH;
        public string Vin;
        public string DJDate;
        public string MakeDate;
        public string ChangPH;
        public string XingHao;
        public string FDJXH;
        public string MakeFac;
        public string QDXS;
        public string ZZL;
        public string ZBZL;
        public string BSXLX;
        public string DWCount;
        public string QGS;
        public string PL;
        public string CH;
        public string RLStr;
        public string EDGL;
        public string EDGLRPM;
        public string GYTypeStr;
        public string PQGCount;
        public string ZKRS;
        public string ZYTypeStr;
        public string DW;
        public string DWTelephone;
        public string DWAddres;
        public string PQHCLZZ;

    }
    public class XB_SDSXZ
    {
        public double CO2Door;
        public double GDSHCStd;
        public double GDSCOStd;
        public double GDSHLStd;
        public double GDSLLStd;
        public double DSHCStd;
        public double DSCOStd;
        public bool CtrlRPM;
        public double CarRPMMin;
        public double CarRPMMax;

    }
    public class XB_ASMXZ
    {
        public double CO2Door;
        public double HC5025Std;
        public double CO5025Std;
        public double NO5025Std;
        public double HC2540Std;
        public double CO2540Std;
        public double NO2540Std;
        public double AsmQuick;
        public double AsmGri;

    }
    public class XB_VMASXZ
    {
        public double CO2Door;
        public double VmasHCStd;
        public double VmasCOStd;
        public double VmasNOStd;
        public double VmasHCNOStd;
        public double VmasPowerStd;
        public bool CtrlRPM;
        public double CarRPMMin;
        public double CarRPMMax;


    }
    public class XB_LUGDOWNXZ
    {
        public double LDSorbStd;
        public double LDMinPower;
        public double LDLRpmStd;
        public double LDHRpmStd;
        public bool CtrlRPMLUG;
    }
    public class XB_BTGXZ
    {
        public double SorbStd;
        public bool SorbRPM;
    }
    public class XB_LZXZ
    {
        public double TrayStd;
        public bool SorbRPM;
    }
    public class XB_SDSMXZ
    {
        public double CO2Door;
        public double DSHCStd;
        public double DSCOStd;
        public bool CtrlRPM;
        public double CarRPMMin;
        public double CarRPMMax;
    }
    public class XB_SDS_PROCESS_DATA
    {
        public string JCFFBH;
        public string JCLSH;
        public string SJXL;
        public string State;
        public string HC;
        public string CO;
        public string Lmd;
        public string O2;
        public string CO2;
        public string Rpm;
        public string JYWD;
    }
    public class XB_VMAS_PROCESS_DATA
    {
        public string JCFFBH;
        public string JCLSH;
        public string SJXL;
        public string State;
        public string HC;
        public string CO;
        public string NO;
        public string O2;
        public string CO2;
        public string Rpm;
        public string JYWD;
        public string Speed;
        public string Force;
        public string Power;
        public string IHP;
        public string PLHP;
        public string LTMCLP;
        public string WD;
        public string SD;
        public string DQY;
        public string KH;
        public string DF;
        public string LLO2;
        public string BJO2;
        public string XSB;
        public string LLJWD;
        public string LLJDQY;
        public string LL;
        public string BZLL;
        public string HCZL;
        public string COZL;
        public string NOZL;
    }
    public class XB_LUGDOWN_PROCESS_DATA
    {
        public string JCFFBH;
        public string JCLSH;
        public string SJXL;
        public string State;
        public string Sorb;
        public string Rpm;
        public string JYWD;
        public string Speed;
        public string Force;
        public string Power;
        public string IHP;
        public string PLHP;
        public string LTMCLP;
        public string WD;
        public string SD;
        public string DQY;
        public string PCof;
    }
    public class XB_RESULT_PUBLIC_DATA
    {
        public string JCFFBH { set; get; }
        public string JCLSH { set; get; }
        public string DLY { set; get; }
        public string YCY { set; get; }
        public string JCY { set; get; }
        public string WD { set; get; }
        public string DQY { set; get; }
        public string SD { set; get; }

    }
    public class XB_SDS_RESULT_DATA
    {
        public string SFZSKZ { set; get; }
        public string DSRpm { set; get; }
        public string GDSRpm { set; get; }
        public string DSHC { set; get; }
        public string GDSHC { set; get; }
        public string DSCO { set; get; }
        public string GDSCO { set; get; }
        public string GDSLmd { set; get; }
        public string DSCurveCount0 { set; get; }
        public string DSCurveCount1 { set; get; }
        public string GDSCurveCount0 { set; get; }
        public string GDSCurveCount1 { set; get; }
        public string DSHCCurve0 { set; get; }
        public string DSHCCurve1 { set; get; }
        public string GDSHCCurve0 { set; get; }
        public string GDSHCCurve1 { set; get; }
        public string DSCOCurve0 { set; get; }
        public string DSCOCurve1 { set; get; }
        public string GDSCOCurve0 { set; get; }
        public string GDSCOCurve1 { set; get; }
        public string DSCO2Curve0 { set; get; }
        public string DSCO2Curve1 { set; get; }
        public string GDSCO2Curve0{ set; get; }
        public string GDSCO2Curve1{ set; get; }
        public string DSO2Curve0{ set; get; }
        public string DSO2Curve1{ set; get; }
        public string GDSO2Curve0{ set; get; }
        public string GDSO2Curve1{ set; get; }
        public string GDSLmdCurve0{ set; get; }
        public string GDSLmdCurve1{ set; get; }
        public string DSRpmCurve0{ set; get; }
        public string DSRpmCurve1{ set; get; }
        public string GDSRpmCurve0{ set; get; }
        public string GDSRpmCurve1{ set; get; }
        public string DSJYWDCurve0{ set; get; }
        public string DSJYWDCurve1{ set; get; }
        public string GDSJYWDCurve0{ set; get; }
        public string GDSJYWDCurve1{ set; get; }

    }
    public class XB_VMAS_RESULT_DATA
    {
        
        public string VmasCO{set;get;}
        public string VmasHC{set;get;}
        public string VmasNO{set;get;}
        public string TestKilomter{set;get;}
        public string CurveCount{set;get;}
        public string BJO2{set;get;}
        public string COCurve{set;get;}
        public string HCCurve{set;get;}
        public string NOCurve{set;get;}
        public string CO2Curve{set;get;}
        public string YSO2Curve{set;get;}
        public string XSO2Curve{set;get;}
        public string XSBCurve{set;get;}
        public string LLCurve{set;get;}
        public string BZLLCurve{set;get;}
        public string SpeedCurve{set;get;}
        public string ForceCurve{set;get;}
        public string PowerCurve{set;get;}
        public string PLHPCurve{set;get;}
        public string LTMCLPCurve{set;get;}
        public string DIWLPCurve{set;get;}
        public string RpmCurve{set;get;}
        public string WDCurve{set;get;}
        public string SDCurve{set;get;}
        public string DQYCurve{set;get;}
        public string DFCCurve{set;get;}
        public string KHCurve{set;get;}
        public string LLJWDCurve{set;get;}
        public string LLJDQYCurve{set;get;}
        public string HCZLCurve{set;get;}
        public string COZLCurve{set;get;}
        public string NOZLCurve{set;get;}
        
    }
    public class XB_LUGDOWN_RESULT_DATA
    {
        
        public string SFZSKZ{set;get;}
        public string LugTime{set;get;}
        public string VelLugTime{set;get;}
        public string CalcVelMaxHP{set;get;}
        public string RealVelMaxHP{set;get;}
        public string RealMaxPower{set;get;}
        public string CalcMaxPower{set;get;}
        public string RealVelFDJRpm{set;get;}
        public string DSFDJRpm{set;get;}
        public string Sorb0{set;get;}
        public string Sorb1{set;get;}
        public string Sorb2{set;get;}
        public string NOND0{set;get;}
        public string NOND1{set;get;}
        public string NOND2{set;get;}
        public string NOZL0{set;get;}
        public string NOZL1{set;get;}
        public string NOZL2{set;get;}
        public string Kilometer0{set;get;}
        public string Kilometer1{set;get;}
        public string Kilometer2{set;get;}
        public string CurveCount{set;get;}
        public string VelCurveCount0{set;get;}
        public string VelCurveCount1{set;get;}
        public string VelCurveCount2{set;get;}
        public string SorbCurve{set;get;}
        public string SpeedCurve{set;get;}
        public string ForceCurve{set;get;}
        public string PowerCurve{set;get;}
        public string PLHPCurve{set;get;}
        public string RpmCurve{set;get;}
        public string WDCurve{set;get;}
        public string SDCurve{set;get;}
        public string DQYCurve{set;get;}
        public string NONDCurve{set;get;}
        public string NOZLCurve{set;get;}
        public string PCofCurve{set;get;}
        public string VelSorbCurve0{set;get;}
        public string VelSpeedCurve0{set;get;}
        public string VelForceCurve0{set;get;}
        public string VelPowerCurve0{set;get;}
        public string VelPLHPCurve0{set;get;}
        public string VelRpmCurve0{set;get;}
        public string VelWDCurve0{set;get;}
        public string VelSDCurve0{set;get;}
        public string VelDQYCurve0{set;get;}
        public string VelNONDCurve0{set;get;}
        public string VelNOZLCurve0{set;get;}
        public string VelPCofCurve0{set;get;}
        public string VelSorbCurve1{set;get;}
        public string VelSpeedCurve1{set;get;}
        public string VelForceCurve1{set;get;}
        public string VelPowerCurve1{set;get;}
        public string VelPLHPCurve1{set;get;}
        public string VelRpmCurve1{set;get;}
        public string VelWDCurve1{set;get;}
        public string VelSDCurve1{set;get;}
        public string VelDQYCurve1{set;get;}
        public string VelPCofCurve1{set;get;}
        public string VelNONDCurve1{set;get;}
        public string VelNOZLCurve1{set;get;}
        public string VelSorbCurve2{set;get;}
        public string VelSpeedCurve2{set;get;}
        public string VelForceCurve2{set;get;}
        public string VelPowerCurve2{set;get;}
        public string VelPLHPCurve2{set;get;}
        public string VelRpmCurve2{set;get;}
        public string VelWDCurve2{set;get;}
        public string VelSDCurve2{set;get;}
        public string VelDQYCurve2{set;get;}
        public string VelNONDCurve2{set;get;}
        public string VelNOZLCurve2{set;get;}
        public string VelPCofCurve2{set;get;}
    }
    public class XB_BTG_RESULT_DATA
    {
        
        public string JCCS{set;get;}
        public string AshSorb1{set;get;}
        public string AshSorb2{set;get;}
        public string AshSorb3{set;get;}
        public string AshSorb4{set;get;}
        public string AshSorb5{set;get;}
        public string AshSorb6{set;get;}
        public string AshSorbAge{set;get;}
        public string AshSorbRpm{set;get;}

    }
    public class XB_LZ_RESULT_DATA
    {
        
        public string AshTray1{set;get;}
        public string AshTray2{set;get;}
        public string AshTray3{set;get;}
        public string AshTray4{set;get;}
        public string AshTrayAge{set;get;}
        public string AshSorbRpm{set;get;}
    }
    public class XB_BD_PUBLIC_DATA
    {
        public string DevID { set; get; }
        public string Items { set; get; }
        public string BeginTime { set; get; }
        public string EndTime { set; get; }
        public string WD { set; get; }
        public string SD { set; get; }
        public string DQY { set; get; }
        public string Operator { set; get; }

    }
    public class XB_FORCE_BD_DATA
    {
        public string ForceCheckValue { set; get; }
        public string ForceValue { set; get; }
        public string ForceAverageValue { set; get; }
        public string ForceError { set; get; }
        public string AllowError { set; get; }
        public string ForceEvl { set; get; }

    }
    public class XB_PLHP_BD_DATA
    {
        public string BeginSpeed { set; get; }
        public string EndSpeed { set; get; }
        public string NominalSpeed { set; get; }
        public string SlideTime { set; get; }
        public string PLHP { set; get; }
        public string Force { set; get; }

    }
    public class XB_LOADEDCOASTDOWN_BD_DATA
    {
        public string Power { set; get; }
        public string DIW { set; get; }
        public string BeginSpeed { set; get; }
        public string EndSpeed { set; get; }
        public string NominalSpeed { set; get; }
        public string NominalTime { set; get; }
        public string SlideTime { set; get; }
        public string AllowError { set; get; }
        public string SlideError { set; get; }
        public string SlideEvl { set; get; }

    }
    public class XB_EXHAUSTGAS_BD_DATA
    {
        public string CabHCTag { set; get; }
        public string CabCOTag { set; get; }
        public string CabCO2Tag { set; get; }
        public string CabNOTag { set; get; }
        public string CheckHCTag { set; get; }
        public string CheckCOTag { set; get; }
        public string CheckCO2Tag { set; get; }
        public string CheckNOTag { set; get; }
        public string HCCabResult { set; get; }
        public string COCabResult { set; get; }
        public string CO2CabResult { set; get; }
        public string NOCabResult { set; get; }
        public string PEFCabResult { set; get; }
        public string HCCheckResult { set; get; }
        public string COCheckResult { set; get; }
        public string CO2CheckResult { set; get; }
        public string NOCheckResult { set; get; }
        public string PEFCheckResult { set; get; }
        public string HCCabAllowError { set; get; }
        public string COCabAllowError { set; get; }
        public string CO2CabAllowError { set; get; }
        public string NOCabAllowError { set; get; }
        public string HCCheckAllowError { set; get; }
        public string COCheckAllowError { set; get; }
        public string CO2CheckAllowError { set; get; }
        public string NOCheckAllowError { set; get; }
        public string HCCabError { set; get; }
        public string COCabError { set; get; }
        public string CO2CabError { set; get; }
        public string NOCabError { set; get; }
        public string HCCheckError { set; get; }
        public string COCheckError { set; get; }
        public string CO2CheckError { set; get; }
        public string NOCheckError { set; get; }
        public string HCCabAllowAbsError { set; get; }
        public string COCabAllowAbsError { set; get; }
        public string CO2CabAllowAbsError { set; get; }
        public string NOCabAllowAbsError { set; get; }
        public string HCCheckAllowAbsError { set; get; }
        public string COCheckAllowAbsError { set; get; }
        public string CO2CheckAllowAbsError { set; get; }
        public string NOCheckAllowAbsError { set; get; }
        public string HCCabAbsError { set; get; }
        public string COCabAbsError { set; get; }
        public string CO2CabAbsError { set; get; }
        public string NOCabAbsError { set; get; }
        public string HCCheckAbsError { set; get; }
        public string COCheckAbsError { set; get; }
        public string CO2CheckAbsError { set; get; }
        public string NOCheckAbsError { set; get; }
        public string HCCabEvl { set; get; }
        public string COCabEvl { set; get; }
        public string CO2CabEvl { set; get; }
        public string NOCabEvl { set; get; }
        public string HCCheckEvl { set; get; }
        public string COCheckEvl { set; get; }
        public string CO2CheckEvl { set; get; }
        public string NOCheckEvl { set; get; }
        public string GasCabEvl { set; get; }
        public string GasCheckEvl { set; get; }

    }
    public class XB_SEALCHECK_BD_DATA
    { public string Evl { set; get; } }
    public class XB_LLJ_BD_DATA
    {
        public string NominalLLValue { set; get; }
        public string LLValue { set; get; }
        public string LLAvgValue { set; get; }
        public string LLO2Value { set; get; }
        public string LLO2AvgValue { set; get; }
        public string AllowLLError { set; get; }
        public string LLError { set; get; }
        public string AllowLLO2Error { set; get; }
        public string LLEvl { set; get; }
        public string LLO2Evl { set; get; }

    }
    public class XB_YDJ_BD_DATA
    {
        public string StdValue { set; get; }
        public string Item1 { set; get; }
        public string Item2 { set; get; }
        public string Item3 { set; get; }
        public string SmokeAvgValue { set; get; }
        public string AllowSmokeError { set; get; }
        public string SmokeError { set; get; }
        public string SmokeEvl { set; get; }
    }
    public class xbSocketControl
    {

        public Dictionary<string, string> XB_JCFF = new Dictionary<string, string>();
        public Dictionary<string, string> XB_HPZL = new Dictionary<string, string>();
        public Dictionary<string, string> XB_SYXZ = new Dictionary<string, string>();
        public Dictionary<string, string> XB_RLZL = new Dictionary<string, string>();
        public Dictionary<string, string> XB_R_JCFF = new Dictionary<string, string>();
        public Dictionary<string, string> XB_R_HPZL = new Dictionary<string, string>();
        public Dictionary<string, string> XB_R_SYXZ = new Dictionary<string, string>();
        public Dictionary<string, string> XB_R_RLZL = new Dictionary<string, string>();
        IPAddress HostIP = IPAddress.Parse("192.168.1.5");
        IPEndPoint point;
        Socket socket;
        bool flag = true;
        Socket acceptedSocket;


        public string receivedString = "";
        public bool receivedFlag = false;
        Thread thread = null;

        public bool receivedflag = false;
        static int sendOutTime = 10;
        static int receiveOutTime = 500;
        static int frameHead = 58250;
        public xbSocketControl()
        {
            XB_JCFF.Add("S","SDS");
            XB_JCFF.Add("A", "ASM");
            XB_JCFF.Add("V", "VMAS");
            XB_JCFF.Add("L", "JZJS");
            XB_JCFF.Add("Y", "LZ");
            XB_JCFF.Add("B", "ZYJS");
            XB_R_JCFF.Add("SDS", "S");
            XB_R_JCFF.Add("SDSM", "S");
            XB_R_JCFF.Add("ASM", "A");
            XB_R_JCFF.Add("VMAS", "V");
            XB_R_JCFF.Add("JZJS", "L");
            XB_R_JCFF.Add("LZ", "Y");
            XB_R_JCFF.Add("ZYJS", "B");

            XB_HPZL.Add("01", "大型汽车");
            XB_HPZL.Add("02", "小型汽车");
            XB_HPZL.Add("03", "使馆汽车");
            XB_HPZL.Add("04", "领馆汽车");
            XB_HPZL.Add("05", "境外汽车");
            XB_HPZL.Add("06", "外籍汽车");
            XB_HPZL.Add("07", "两、三轮摩托车");
            XB_HPZL.Add("08", "轻便摩托车");
            XB_HPZL.Add("09", "使馆摩托车");
            XB_HPZL.Add("10", "领馆摩托车");
            XB_HPZL.Add("11", "境外摩托车");
            XB_HPZL.Add("12", "外籍摩托车");
            XB_HPZL.Add("13", "农用运输车");
            XB_HPZL.Add("14", "拖拉机");
            XB_HPZL.Add("15", "挂车");
            XB_HPZL.Add("16", "教练汽车");
            XB_HPZL.Add("17", "教练摩托车");
            XB_HPZL.Add("18", "试验汽车");
            XB_HPZL.Add("19", "试验摩托车");
            XB_HPZL.Add("20", "临时人境汽车");
            XB_HPZL.Add("21", "临时人境摩托车");
            XB_HPZL.Add("22", "临时行驶车");
            XB_HPZL.Add("23", "警用汽车");
            XB_HPZL.Add("24", "警用摩托");
            XB_HPZL.Add("99", "其他");

            XB_R_HPZL.Add("大型汽车", "01");
            XB_R_HPZL.Add("小型汽车", "02");
            XB_R_HPZL.Add("使馆汽车", "03");
            XB_R_HPZL.Add("领馆汽车", "04");
            XB_R_HPZL.Add("境外汽车", "05");
            XB_R_HPZL.Add("外籍汽车", "06");
            XB_R_HPZL.Add("两、三轮摩托车", "07");
            XB_R_HPZL.Add("轻便摩托车", "08");
            XB_R_HPZL.Add("使馆摩托车", "09");
            XB_R_HPZL.Add("领馆摩托车", "10");
            XB_R_HPZL.Add("境外摩托车", "11");
            XB_R_HPZL.Add("外籍摩托车", "12");
            XB_R_HPZL.Add("农用运输车", "13");
            XB_R_HPZL.Add("拖拉机", "14");
            XB_R_HPZL.Add("挂车", "15");
            XB_R_HPZL.Add("教练汽车", "16");
            XB_R_HPZL.Add("教练摩托车", "17");
            XB_R_HPZL.Add("试验汽车", "18");
            XB_R_HPZL.Add("试验摩托车", "19");
            XB_R_HPZL.Add("临时人境汽车", "20");
            XB_R_HPZL.Add("临时人境摩托车", "21");
            XB_R_HPZL.Add("临时行驶车", "22");
            XB_R_HPZL.Add("警用汽车", "23");
            XB_R_HPZL.Add("警用摩托", "24");
            XB_R_HPZL.Add("其他", "99");

            XB_RLZL.Add("A", "汽油");
            XB_RLZL.Add("B", "柴油");
            XB_RLZL.Add("C", "电");
            XB_RLZL.Add("D", "混合油");
            XB_RLZL.Add("E", "天然气");
            XB_RLZL.Add("F", "液化石油气");
            XB_RLZL.Add("L", "甲醇");
            XB_RLZL.Add("M", "乙醇");
            XB_RLZL.Add("N", "太阳能");
            XB_RLZL.Add("O", "混合动力");
            XB_RLZL.Add("X", "氢");
            XB_RLZL.Add("Y", "无");
            XB_RLZL.Add("Z", "其他");

            XB_R_RLZL.Add("汽油", "A");
            XB_R_RLZL.Add("柴油", "B");
            XB_R_RLZL.Add("电", "C");
            XB_R_RLZL.Add("混合油", "D");
            XB_R_RLZL.Add("天然气", "E");
            XB_R_RLZL.Add("液化石油气", "F");
            XB_R_RLZL.Add("甲醇", "L");
            XB_R_RLZL.Add("乙醇", "M");
            XB_R_RLZL.Add("太阳能", "N");
            XB_R_RLZL.Add("混合动力", "O");
            XB_R_RLZL.Add("氢", "X");
            XB_R_RLZL.Add("无", "Y");
            XB_R_RLZL.Add("其他", "Z");

            XB_SYXZ.Add("A", "非营运");
            XB_SYXZ.Add("B", "公路客运");
            XB_SYXZ.Add("C", "公交客运");
            XB_SYXZ.Add("D", "出租客运");
            XB_SYXZ.Add("E", "旅游客运");
            XB_SYXZ.Add("F", "货运");
            XB_SYXZ.Add("G", "租赁");
            XB_SYXZ.Add("H", "警用");
            XB_SYXZ.Add("I", "消防");
            XB_SYXZ.Add("J", "救护");
            XB_SYXZ.Add("K", "工程抢险");
            XB_SYXZ.Add("L", "营转非");
            XB_SYXZ.Add("M", "出租转非");
            XB_SYXZ.Add("N", "教练");
            XB_SYXZ.Add("O", "幼儿校车");
            XB_SYXZ.Add("P", "小学生校车");
            XB_SYXZ.Add("Q", "初中生校车");
            XB_SYXZ.Add("R", "危险品校车");
            XB_SYXZ.Add("S", "中小学生校车");

            XB_R_SYXZ.Add("非营运", "A");
            XB_R_SYXZ.Add("公路客运", "B");
            XB_R_SYXZ.Add("公交客运", "C");
            XB_R_SYXZ.Add("出租客运", "D");
            XB_R_SYXZ.Add("旅游客运", "E");
            XB_R_SYXZ.Add("货运", "F");
            XB_R_SYXZ.Add("租赁", "G");
            XB_R_SYXZ.Add("警用", "H");
            XB_R_SYXZ.Add("消防", "I");
            XB_R_SYXZ.Add("救护", "J");
            XB_R_SYXZ.Add("工程抢险", "K");
            XB_R_SYXZ.Add("营转非", "L");
            XB_R_SYXZ.Add("出租转非", "M");
            XB_R_SYXZ.Add("教练", "N");
            XB_R_SYXZ.Add("幼儿校车", "O");
            XB_R_SYXZ.Add("小学生校车", "P");
            XB_R_SYXZ.Add("初中生校车", "Q");
            XB_R_SYXZ.Add("危险品校车", "R");
            XB_R_SYXZ.Add("中小学生校车", "S");

        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            INIIO.saveSocketLogInf("[SEND]:" + xmlString);
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(xmlString);
            List<byte> listToSend = new List<byte>();

            listToSend.AddRange(BitConverter.GetBytes(frameHead));
            //listToSend.Add((byte)(frameHead >> 24));
            //listToSend.Add((byte)(frameHead >> 16));
            //listToSend.Add((byte)(frameHead >> 8));
            //listToSend.Add((byte)(frameHead));
            int length = bufferToSend.Length;
            listToSend.AddRange(BitConverter.GetBytes(length));
            listToSend.AddRange(BitConverter.GetBytes(frameHead));
            listToSend.AddRange(BitConverter.GetBytes(length));
            //listToSend.Add((byte)(length >> 24));
            //listToSend.Add((byte)(length >> 16));
            //listToSend.Add((byte)(length >> 8));
            //listToSend.Add((byte)(length));
            listToSend.AddRange(bufferToSend);
            return listToSend.ToArray();
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertTestStringToString(string teststring)
        {
            INIIO.saveSocketLogInf("SEND:" + teststring);
            string newstring = " /CtrlCenter/ASM?data=" + teststring.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);
            //byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        public bool init_equipment(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            try
            {
                point = new IPEndPoint(HostIP, Int32.Parse(port));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                //thread = new Thread(new ThreadStart(Proccess));
                //thread.Start();
                return true;
            }
            catch (Exception ey)
            {
                return false;
            }
        }
        public void close_equipment()
        {
            try
            {
                try
                {
                    thread.Abort();
                }
                catch
                { }
                socket.Close();
            }
            catch
            { }
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送数据</param>
        /// <param name="outTime">发送超时时长，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送成功；-1:超时；-2:出现错误；-3:出现异常</returns>
        public static int SendData(Socket socket, byte[] buffer)
        {
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("参数socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("参数buffer为null ,或者长度为 0");
            }

            int flag = 0;
            try
            {
                int left = buffer.Length;
                int sndLen = 0;
                int hasSend = 0;

                while (true)
                {
                    if ((socket.Poll(sendOutTime * 1000, SelectMode.SelectWrite) == true))
                    {
                        // 收集了足够多的传出数据后开始发送
                        sndLen = socket.Send(buffer, hasSend, left, SocketFlags.None);
                        left -= sndLen;
                        hasSend += sndLen;

                        // 数据已经全部发送
                        if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据部分已经被发送
                            if (sndLen > 0)
                            {
                                continue;
                            }
                            else // 发送数据发生错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        flag = -1;
                        break;
                    }
                }
            }
            catch (SocketException)
            {
                //Log
                flag = -3;
            }
            return flag;
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送的字符串</param>
        /// <param name="outTime">发送数据的超时时间，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送数据成功；-1:超时；-2:错误；-3:异常</returns>
        public static int SendData(Socket socket, string buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null或则长度为0.");
            }
            return SendData(socket, System.Text.Encoding.Default.GetBytes(buffer));
        }
        /// <summary>
        /// 接收远程主机发送的数据
        /// </summary>
        /// <param name="socket">要接收数据且已经连接到远程主机的</param>
        /// <param name="buffer">接收数据的缓冲区(需要接收的数据的长度，由 buffer 的长度决定)</param>
        /// <param name="outTime">接收数据的超时时间，单位秒(指定为-1时，将一直等待直到有数据需要接收)</param>
        /// <returns></returns>
        public static int RecvData(Socket socket, out string receivedMessage)
        {
            byte[] buffer = new byte[50 * 1024];
            receivedMessage = "";
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null ,或者长度为 0");
            }

            buffer.Initialize();
            int left = buffer.Length;
            int curRcv = 0;
            int hasRecv = 0;
            int flag = 0;
            int receiveOutCount = 0;
            try
            {
                while (true)
                {
                    if (socket.Poll(receiveOutTime * 1000, SelectMode.SelectRead) == true)
                    {
                        // 已经有数据等待接收
                        curRcv = socket.Receive(buffer, hasRecv, left, SocketFlags.None);
                        left -= curRcv;
                        hasRecv += curRcv;
                        string receivedstring = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer, 0, hasRecv);
                        INIIO.saveSocketLogInf("[RECEIVED]:" + receivedstring);
                        if (hasRecv > 16)//如果接收的长度超过8，则开始判断接收到的总长度是否是帧头长度+8
                        {
                            int length = (int)((buffer[15] << 24) | (buffer[14] << 16) | (buffer[13] << 8) | (buffer[12]));
                            if (hasRecv == length + 16)
                            {
                                string s = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer, 8, length);
                                INIIO.saveSocketLogInf("[MESSAGE]:" + s);
                                receivedMessage = s;
                                flag = 1;
                                break;
                            }
                        }                        
                        if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据已经部分接收
                            if (curRcv > 0)
                            {
                                continue;
                            }
                            else  // 出现错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        Thread.Sleep(100);
                        receiveOutCount++;
                        if (receiveOutCount >= receiveOutTime)
                        {
                            flag = -1;
                            break;
                        }
                    }
                }
            }
            catch (SocketException er)
            {
                //Log
                receivedMessage = er.Message;
                flag = -3;
            }
            //INIIO.saveSocketLogInf("RECEIVE:" + receivedMessage);
            return flag;
        }
        
        public bool Send_AUTHENTCATION(XB_AUTHENTCATION model,out string result ,out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "AUTHENTCATION";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("version");//创建一个<Node>节点
                XmlElement xe202 = xmldoc.CreateElement("certificate");//创建一个<Node>节点
                XmlElement xe203 = xmldoc.CreateElement("station_id");//创建一个<Node>节点
                XmlElement xe204 = xmldoc.CreateElement("detect_line_id");//创建一个<Node>节点
                XmlElement xe205 = xmldoc.CreateElement("hd_seria_number");//创建一个<Node>节点 
                xe201.InnerText = model.version;
                xe202.InnerText = model.certificate;
                xe203.InnerText = model.station_id;
                xe204.InnerText = model.detect_line_id;
                xe205.InnerText = model.hd_seria_number;
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                xe2.AppendChild(xe203);
                xe2.AppendChild(xe204);
                xe2.AppendChild(xe205);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch(Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_TIME_SYNC(out DateTime datetime, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            datetime = DateTime.Now;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TIME_SYNC";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
               
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                    {
                        dt1 = ds.Tables["body"];
                        datetime = DateTime.Parse(dt1.Rows[0]["Time"].ToString());
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_GET_USERS(out List<XB_USER> model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            model = new List<XB_USER>();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "GET_USERS";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 

                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                    {
                        dt1 = ds.Tables["user"];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            XB_USER user = new XB_USER();
                            user.name = dt1.Rows[i]["name"].ToString();
                            user.emp_name = dt1.Rows[i]["emp_name"].ToString();
                            user.role = "";
                            model.Add(user);
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_USER_LOGIN(string user_name,string password, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "USER_LOGIN";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("user_name");
                XmlElement xe202 = xmldoc.CreateElement("password");
                xe201.InnerText = user_name;
                xe202.InnerText = password;
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_USER_EXIT(string user_name, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "USER_EXIT";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("user_name");
                xe201.InnerText = user_name;
                xe2.AppendChild(xe201);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_MODIFY_PWD(string user_name, string old_pwd,string new_pwd, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "USER_LOGIN";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("user_name");
                XmlElement xe202 = xmldoc.CreateElement("old_pwd");
                XmlElement xe203 = xmldoc.CreateElement("new_pwd");
                xe201.InnerText = user_name;
                xe202.InnerText = old_pwd;
                xe203.InnerText = new_pwd;
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                xe2.AppendChild(xe203);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_GET_EVN_SET(out XB_ENVIRONMENT model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            model = new XB_ENVIRONMENT();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "GET_EVN_SET";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 

                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                    {
                        dt1 = ds.Tables["evn_set"];
                        model.TEMPL = double.Parse(dt1.Rows[0]["TEMPL"].ToString());
                        model.TEMPH = double.Parse(dt1.Rows[0]["TEMPH"].ToString());
                        model.HUML = double.Parse(dt1.Rows[0]["HUML"].ToString());
                        model.HUMH = double.Parse(dt1.Rows[0]["HUMH"].ToString());
                        model.ATML = double.Parse(dt1.Rows[0]["ATML"].ToString());
                        model.ATMH = double.Parse(dt1.Rows[0]["ATMH"].ToString());
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_GET_REG_CAR_LIST(int number,out List<XB_CARLIST> model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            model = new List<XB_CARLIST>();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "GET_REG_CAR_LIST";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("number");
                xe201.InnerText = number.ToString();
                xe2.AppendChild(xe201);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                    {
                        dt1 = ds.Tables["reg_car"];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            XB_CARLIST carlist = new XB_CARLIST();
                            carlist.JCLSH = dt1.Rows[i]["JCLSH"].ToString();
                            carlist.JCCS = dt1.Rows[i]["JCCS"].ToString();
                            carlist.HPHM = dt1.Rows[i]["HPHM"].ToString();
                            carlist.HPZLBH = dt1.Rows[i]["HPZLBH"].ToString();
                            carlist.HPZL = dt1.Rows[i]["HPZL"].ToString();
                            carlist.JCFFBH = XB_JCFF.GetValue(dt1.Rows[i]["JCFFBH"].ToString(), "");
                            carlist.JCFF = dt1.Rows[i]["JCFF"].ToString();
                            carlist.JCLB = dt1.Rows[i]["JCLB"].ToString();
                            carlist.JCRLZL = XB_RLZL.GetValue(dt1.Rows[i]["JCRLZL"].ToString(), "");
                            carlist.TMBH = dt1.Rows[i]["TMBH"].ToString();
                            model.Add(carlist);
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_QUERY_CAR_INFO(string tmbh,out XB_CARINFO model,out XB_SDSXZ sdsxz,out XB_VMASXZ vmasxz,
            out XB_LUGDOWNXZ lugdownxz,out XB_BTGXZ btgxz,out XB_LZXZ lzxz,
            out XB_SDSMXZ sdsmxz, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            model = new XB_CARINFO();
            sdsxz = null;
            vmasxz = null;
            lugdownxz = null;
            btgxz = null;
            lzxz = null;
            sdsmxz = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "QUERY_CAR_INFO";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("JCLSH");
                XmlElement xe202 = xmldoc.CreateElement("JCCS");
                XmlElement xe203 = xmldoc.CreateElement("TMBH");
                xe201.InnerText = tmbh.Split('_')[0];
                xe202.InnerText = tmbh.Split('_')[1];
                xe203.InnerText = "";
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                xe2.AppendChild(xe203);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();

                    if (result == "1")
                    {
                        dt1 = ds.Tables["evn_set"];
                        model.JCLSH = dt1.Rows[0]["JCLSH"].ToString();
                        model.JCCS = dt1.Rows[0]["JCCS"].ToString();
                        model.HPHM = dt1.Rows[0]["HPHM"].ToString();
                        model.HPZLBH = dt1.Rows[0]["HPZLBH"].ToString();
                        model.HPZL = dt1.Rows[0]["HPZL"].ToString();
                        model.JCFFBH = XB_JCFF.GetValue(dt1.Rows[0]["JCFFBH"].ToString(), "");
                        if (model.HPZL.Contains("摩托") && model.JCFFBH == "SDS")
                        {
                            model.JCFFBH = "SDSM";
                        }
                        model.JCFF = dt1.Rows[0]["JCFF"].ToString();
                        model.CLLBBH = dt1.Rows[0]["CLLBBH"].ToString();
                        model.CLLB = dt1.Rows[0]["CLLB"].ToString();
                        model.CLLXBH = dt1.Rows[0]["CLLXBH"].ToString();
                        model.CLLX = dt1.Rows[0]["CLLX"].ToString();
                        model.FDJH = dt1.Rows[0]["FDJH"].ToString();
                        model.Vin = dt1.Rows[0]["Vin"].ToString();
                        model.DJDate = dt1.Rows[0]["DJDate"].ToString();
                        model.MakeDate = dt1.Rows[0]["MakeDate"].ToString();
                        model.ChangPH = dt1.Rows[0]["ChangPH"].ToString();
                        model.XingHao = dt1.Rows[0]["XingHao"].ToString();
                        model.FDJXH = dt1.Rows[0]["FDJXH"].ToString();
                        model.MakeFac = dt1.Rows[0]["MakeFac"].ToString();
                        model.QDXS = dt1.Rows[0]["QDXS"].ToString();
                        model.ZZL = dt1.Rows[0]["ZZL"].ToString();
                        model.ZBZL = dt1.Rows[0]["ZBZL"].ToString();
                        model.BSXLX = dt1.Rows[0]["BSXLX"].ToString();
                        model.DWCount = dt1.Rows[0]["DWCount"].ToString();
                        model.QGS = dt1.Rows[0]["QGS"].ToString();
                        model.PL = dt1.Rows[0]["PL"].ToString();
                        model.CH = dt1.Rows[0]["CH"].ToString();
                        model.RLStr = dt1.Rows[0]["RLStr"].ToString();
                        model.EDGL = dt1.Rows[0]["EDGL"].ToString();
                        model.EDGLRPM = dt1.Rows[0]["EDGLRPM"].ToString();
                        model.GYTypeStr = dt1.Rows[0]["GYTypeStr"].ToString();
                        model.PQGCount = dt1.Rows[0]["PQGCount"].ToString();
                        model.ZKRS = dt1.Rows[0]["ZKRS"].ToString();
                        model.ZYTypeStr = dt1.Rows[0]["ZYTypeStr"].ToString();
                        model.DW = dt1.Rows[0]["DW"].ToString();
                        model.DWTelephone = dt1.Rows[0]["DWTelephone"].ToString();
                        model.DWAddres = dt1.Rows[0]["DWAddres"].ToString();
                        model.PQHCLZZ = dt1.Rows[0]["PQHCLZZ"].ToString();
                        switch (model.JCFFBH)
                        {
                            case "SDS"://双怠速
                                sdsxz = new XB_SDSXZ();
                                dt1 = ds.Tables["double_idle_speed"];
                                sdsxz.CO2Door = double.Parse(dt1.Rows[0]["CO2Door"].ToString());
                                sdsxz.GDSHCStd = double.Parse(dt1.Rows[0]["GDSHCStd"].ToString());
                                sdsxz.GDSCOStd = double.Parse(dt1.Rows[0]["GDSCOStd"].ToString());
                                sdsxz.GDSHLStd = double.Parse(dt1.Rows[0]["GDSHLStd"].ToString());
                                sdsxz.GDSLLStd = double.Parse(dt1.Rows[0]["GDSLLStd"].ToString());
                                sdsxz.DSHCStd = double.Parse(dt1.Rows[0]["DSHCStd"].ToString());
                                sdsxz.DSCOStd = double.Parse(dt1.Rows[0]["DSCOStd"].ToString());
                                sdsxz.CtrlRPM = dt1.Rows[0]["CtrlRPM"].ToString() == "1";
                                sdsxz.CarRPMMin = double.Parse(dt1.Rows[0]["CarRPMMin"].ToString());
                                sdsxz.CarRPMMax = double.Parse(dt1.Rows[0]["CarRPMMax"].ToString());
                                break;
                            case "ASM": break;
                            case "VMAS"://瞬态
                                vmasxz = new XB_VMASXZ();
                                vmasxz.CO2Door = double.Parse(dt1.Rows[0]["CO2Door"].ToString());
                                if (dt1.Rows[0]["VmasHCStd"].ToString() != "")
                                    vmasxz.VmasHCStd = double.Parse(dt1.Rows[0]["VmasHCStd"].ToString());
                                else
                                    vmasxz.VmasHCStd = 0;
                                vmasxz.VmasCOStd = double.Parse(dt1.Rows[0]["VmasCOStd"].ToString());
                                if (dt1.Rows[0]["VmasNOStd"].ToString() != "")
                                    vmasxz.VmasNOStd = double.Parse(dt1.Rows[0]["VmasNOStd"].ToString());
                                else
                                    vmasxz.VmasNOStd = 0;
                                if (dt1.Rows[0]["VmasHCNOStd"].ToString() != "")
                                    vmasxz.VmasHCNOStd = double.Parse(dt1.Rows[0]["VmasHCNOStd"].ToString());
                                else
                                    vmasxz.VmasHCNOStd = 0;
                                vmasxz.VmasPowerStd = double.Parse(dt1.Rows[0]["VmasPowerStd"].ToString());
                                vmasxz.CtrlRPM = dt1.Rows[0]["CtrlRPM"].ToString() == "1";
                                vmasxz.CarRPMMin = double.Parse(dt1.Rows[0]["CarRPMMin"].ToString());
                                vmasxz.CarRPMMax = double.Parse(dt1.Rows[0]["CarRPMMax"].ToString());
                                break;
                            case "LZ"://自由加速滤纸
                                lzxz = new XB_LZXZ();
                                lzxz.TrayStd = double.Parse(dt1.Rows[0]["TrayStd"].ToString());
                                lzxz.SorbRPM = dt1.Rows[0]["SorbRPM"].ToString() == "1";
                                break;
                            case "ZYJS"://自由加速不透光
                                btgxz = new XB_BTGXZ();
                                btgxz.SorbStd = double.Parse(dt1.Rows[0]["SorbStd"].ToString());
                                btgxz.SorbRPM = dt1.Rows[0]["SorbRPM"].ToString() == "1";
                                break;
                            case "JZJS"://lugdown
                                lugdownxz = new XB_LUGDOWNXZ();
                                lugdownxz.LDSorbStd = double.Parse(dt1.Rows[0]["LDSorbStd"].ToString());
                                lugdownxz.LDMinPower = double.Parse(dt1.Rows[0]["LDMinPower"].ToString());
                                lugdownxz.LDLRpmStd = double.Parse(dt1.Rows[0]["LDLRpmStd"].ToString());
                                lugdownxz.LDHRpmStd = double.Parse(dt1.Rows[0]["LDHRpmStd"].ToString());
                                lugdownxz.CtrlRPMLUG = dt1.Rows[0]["CtrlRPMLUG"].ToString() == "1";
                                break;
                            case "SDSM":
                                sdsmxz = new XB_SDSMXZ();
                                dt1 = ds.Tables["motorcycle_idle_speed"];
                                sdsmxz.CO2Door = double.Parse(dt1.Rows[0]["CO2Door"].ToString());
                                sdsmxz.DSHCStd = double.Parse(dt1.Rows[0]["DSHCStd"].ToString());
                                sdsmxz.DSCOStd = double.Parse(dt1.Rows[0]["DSCOStd"].ToString());
                                sdsmxz.CtrlRPM = dt1.Rows[0]["CtrlRPM"].ToString() == "1";
                                sdsmxz.CarRPMMin = double.Parse(dt1.Rows[0]["CarRPMMin"].ToString());
                                sdsmxz.CarRPMMax = double.Parse(dt1.Rows[0]["CarRPMMax"].ToString());
                                break;
                            default: break;
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_START_TEST(string JCLSH, string JCCS, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "START_TEST";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("JCLSH");
                XmlElement xe202 = xmldoc.CreateElement("JCCS");
                xe201.InnerText = JCLSH;
                xe202.InnerText = JCCS;
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_TEST_STOP(string JCLSH, string JCCS,string Reason, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TEST_STOP";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");//创建一个<Node>节点 
                XmlElement xe201 = xmldoc.CreateElement("JCLSH");
                XmlElement xe202 = xmldoc.CreateElement("JCCS");
                XmlElement xe203 = xmldoc.CreateElement("Reason");
                xe201.InnerText = JCLSH;
                xe202.InnerText = JCCS;
                xe203.InnerText = Reason;
                xe2.AppendChild(xe201);
                xe2.AppendChild(xe202);
                xe2.AppendChild(xe203);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }

        public bool Send_SDS_PROCESS_DATA(XB_SDS_PROCESS_DATA model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TEST_PROCESS_DATA";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");
                XmlElement xe21 = xmldoc.CreateElement("JCFFBH");//创建一个<Node>节点 
                XmlElement xe22 = xmldoc.CreateElement("JCLSH");
                XmlElement xe23 = xmldoc.CreateElement("SJXL");
                XmlElement xe24 = xmldoc.CreateElement("State");
                XmlElement xe25 = xmldoc.CreateElement("double_idle_speed");
                XmlElement xe2501 = xmldoc.CreateElement("HC");
                XmlElement xe2502 = xmldoc.CreateElement("CO");
                XmlElement xe2503 = xmldoc.CreateElement("Lmd");
                XmlElement xe2504 = xmldoc.CreateElement("O2");
                XmlElement xe2505 = xmldoc.CreateElement("CO2");
                XmlElement xe2506 = xmldoc.CreateElement("Rpm");
                XmlElement xe2507 = xmldoc.CreateElement("JYWD");
                xe2501.InnerText = model.HC;
                xe2502.InnerText = model.CO;
                xe2503.InnerText = model.Lmd;
                xe2504.InnerText = model.O2;
                xe2505.InnerText = model.CO2;
                xe2506.InnerText = model.Rpm;
                xe2507.InnerText = model.JYWD;
                xe25.AppendChild(xe2501);
                xe25.AppendChild(xe2502);
                xe25.AppendChild(xe2503);
                xe25.AppendChild(xe2504);
                xe25.AppendChild(xe2505);
                xe25.AppendChild(xe2506);
                xe25.AppendChild(xe2507);
                xe21.InnerText =XB_R_JCFF.GetValue( model.JCFFBH,"");
                xe22.InnerText = model.JCLSH;
                xe23.InnerText = model.SJXL;
                xe24.InnerText = model.State;
                xe2.AppendChild(xe21);
                xe2.AppendChild(xe22);
                xe2.AppendChild(xe23);
                xe2.AppendChild(xe24);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_VMAS_PROCESS_DATA(XB_VMAS_PROCESS_DATA model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TEST_PROCESS_DATA";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");
                XmlElement xe21 = xmldoc.CreateElement("JCFFBH");//创建一个<Node>节点 
                XmlElement xe22 = xmldoc.CreateElement("JCLSH");
                XmlElement xe23 = xmldoc.CreateElement("SJXL");
                XmlElement xe24 = xmldoc.CreateElement("State");
                XmlElement xe25 = xmldoc.CreateElement("vmas_data");
                XmlElement HC = xmldoc.CreateElement("HC");
                XmlElement CO = xmldoc.CreateElement("CO");
                XmlElement NO = xmldoc.CreateElement("NO");
                XmlElement O2 = xmldoc.CreateElement("O2");
                XmlElement CO2 = xmldoc.CreateElement("CO2");
                XmlElement Rpm = xmldoc.CreateElement("Rpm");
                XmlElement JYWD = xmldoc.CreateElement("JYWD");
                XmlElement Speed = xmldoc.CreateElement("Speed");
                XmlElement Force = xmldoc.CreateElement("Force");
                XmlElement Power = xmldoc.CreateElement("Power");
                XmlElement IHP = xmldoc.CreateElement("IHP");
                XmlElement PLHP = xmldoc.CreateElement("PLHP");
                XmlElement LTMCLP = xmldoc.CreateElement("LTMCLP");
                XmlElement WD = xmldoc.CreateElement("WD");
                XmlElement SD = xmldoc.CreateElement("SD");
                XmlElement DQY = xmldoc.CreateElement("DQY");
                XmlElement KH = xmldoc.CreateElement("KH");
                XmlElement DF = xmldoc.CreateElement("DF");
                XmlElement LLO2 = xmldoc.CreateElement("LLO2");
                XmlElement BJO2 = xmldoc.CreateElement("BJO2");
                XmlElement XSB = xmldoc.CreateElement("XSB");
                XmlElement LLJWD = xmldoc.CreateElement("LLJWD");
                XmlElement LLJDQY = xmldoc.CreateElement("LLJDQY");
                XmlElement LL = xmldoc.CreateElement("LL");
                XmlElement BZLL = xmldoc.CreateElement("BZLL");
                XmlElement HCZL = xmldoc.CreateElement("HCZL");
                XmlElement COZL = xmldoc.CreateElement("COZL");
                XmlElement NOZL = xmldoc.CreateElement("NOZL");
                HC.InnerText = model.HC;
                CO.InnerText = model.CO;
                NO.InnerText = model.NO;
                O2.InnerText = model.O2;
                CO2.InnerText = model.CO2;
                Rpm.InnerText = model.Rpm;
                JYWD.InnerText = model.JYWD;
                Speed.InnerText = model.Speed;
                Force.InnerText = model.Force;
                Power.InnerText = model.Power;
                IHP.InnerText = model.IHP;
                PLHP.InnerText = model.PLHP;
                LTMCLP.InnerText = model.LTMCLP;
                WD.InnerText = model.WD;
                SD.InnerText = model.SD;
                DQY.InnerText = model.DQY;
                KH.InnerText = model.KH;
                DF.InnerText = model.DF;
                LLO2.InnerText = model.LLO2;
                BJO2.InnerText = model.BJO2;
                XSB.InnerText = model.XSB;
                LLJWD.InnerText = model.LLJWD;
                LLJDQY.InnerText = model.LLJDQY;
                LL.InnerText = model.LL;
                BZLL.InnerText = model.BZLL;
                HCZL.InnerText = model.HCZL;
                COZL.InnerText = model.COZL;
                NOZL.InnerText = model.NOZL;
                xe25.AppendChild(HC);
                xe25.AppendChild(CO);
                xe25.AppendChild(NO);
                xe25.AppendChild(O2);
                xe25.AppendChild(CO2);
                xe25.AppendChild(Rpm);
                xe25.AppendChild(JYWD);
                xe25.AppendChild(Speed);
                xe25.AppendChild(Force);
                xe25.AppendChild(Power);
                xe25.AppendChild(IHP);
                xe25.AppendChild(PLHP);
                xe25.AppendChild(LTMCLP);
                xe25.AppendChild(WD);
                xe25.AppendChild(SD);
                xe25.AppendChild(DQY);
                xe25.AppendChild(KH);
                xe25.AppendChild(DF);
                xe25.AppendChild(LLO2);
                xe25.AppendChild(BJO2);
                xe25.AppendChild(XSB);
                xe25.AppendChild(LLJWD);
                xe25.AppendChild(LLJDQY);
                xe25.AppendChild(LL);
                xe25.AppendChild(BZLL);
                xe25.AppendChild(HCZL);
                xe25.AppendChild(COZL);
                xe25.AppendChild(NOZL);
                xe21.InnerText = XB_R_JCFF.GetValue(model.JCFFBH, "");
                xe22.InnerText = model.JCLSH;
                xe23.InnerText = model.SJXL;
                xe24.InnerText = model.State;
                xe2.AppendChild(xe21);
                xe2.AppendChild(xe22);
                xe2.AppendChild(xe23);
                xe2.AppendChild(xe24);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_LUGDOWN_PROCESS_DATA(XB_LUGDOWN_PROCESS_DATA model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TEST_PROCESS_DATA";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");
                XmlElement xe21 = xmldoc.CreateElement("JCFFBH");//创建一个<Node>节点 
                XmlElement xe22 = xmldoc.CreateElement("JCLSH");
                XmlElement xe23 = xmldoc.CreateElement("SJXL");
                XmlElement xe24 = xmldoc.CreateElement("State");
                XmlElement xe25 = xmldoc.CreateElement("lugdown_data");
                XmlElement Speed = xmldoc.CreateElement("Speed");
                XmlElement Force = xmldoc.CreateElement("Force");
                XmlElement Power = xmldoc.CreateElement("Power");
                XmlElement IHP = xmldoc.CreateElement("IHP");
                XmlElement PLHP = xmldoc.CreateElement("PLHP");
                XmlElement LTMCLP = xmldoc.CreateElement("LTMCLP");
                XmlElement WD = xmldoc.CreateElement("WD");
                XmlElement SD = xmldoc.CreateElement("SD");
                XmlElement DQY = xmldoc.CreateElement("DQY");
                XmlElement PCof = xmldoc.CreateElement("PCof");
                Speed.InnerText = model.Speed;
                Force.InnerText = model.Force;
                Power.InnerText = model.Power;
                IHP.InnerText = model.IHP;
                PLHP.InnerText = model.PLHP;
                LTMCLP.InnerText = model.LTMCLP;
                WD.InnerText = model.WD;
                SD.InnerText = model.SD;
                DQY.InnerText = model.DQY;
                PCof.InnerText = model.PCof;
                xe25.AppendChild(Speed);
                xe25.AppendChild(Force);
                xe25.AppendChild(Power);
                xe25.AppendChild(IHP);
                xe25.AppendChild(PLHP);
                xe25.AppendChild(LTMCLP);
                xe25.AppendChild(WD);
                xe25.AppendChild(SD);
                xe25.AppendChild(DQY);
                xe25.AppendChild(PCof);
                xe21.InnerText = XB_R_JCFF.GetValue(model.JCFFBH, "");
                xe22.InnerText = model.JCLSH;
                xe23.InnerText = model.SJXL;
                xe24.InnerText = model.State;
                xe2.AppendChild(xe21);
                xe2.AppendChild(xe22);
                xe2.AppendChild(xe23);
                xe2.AppendChild(xe24);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_TEST_RESULT_DATA<T>(XB_RESULT_PUBLIC_DATA pmodel,T model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "TEST_RESULT_DATA";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");
                
                XmlElement JCFFBH = xmldoc.CreateElement("JCFFBH");//创建一个<Node>节点 
                XmlElement JCLSH = xmldoc.CreateElement("JCLSH");
                XmlElement DLY = xmldoc.CreateElement("DLY");
                XmlElement YCY = xmldoc.CreateElement("YCY");
                XmlElement JCY = xmldoc.CreateElement("JCY");
                XmlElement WD = xmldoc.CreateElement("WD");
                XmlElement DQY = xmldoc.CreateElement("DQY");
                XmlElement SD = xmldoc.CreateElement("SD");
                string dataname = "";
                switch(pmodel.JCFFBH)
                {
                    case "SDS":
                        dataname = "double_idle_speed";break;
                    case "VMAS":
                        dataname = "vmas_speed"; break;
                    case "JZJS":
                        dataname = "lugdown_speed"; break;
                    case "ZYJS":
                        dataname = "free_acceleration_opaque"; break;
                    case "LZ":
                        dataname = "free_acceleration_filter_smoke"; break;
                    default:break;

                }
                XmlElement xe25 = xmldoc.CreateElement(dataname);
                List<string> namelist = new List<string>();
                List<string> valuelist = new List<string>();
                if (XmlBuilderHelper.GetPorperty(model, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        xe25.AppendChild(el);
                    }
                }                
                JCFFBH.InnerText =XB_R_JCFF.GetValue(pmodel.JCFFBH,"");
                JCLSH.InnerText = pmodel.JCLSH;
                DLY.InnerText = pmodel.DLY;
                YCY.InnerText = pmodel.YCY;
                JCY.InnerText = pmodel.JCY;
                WD.InnerText = pmodel.WD;
                DQY.InnerText = pmodel.DQY;
                SD.InnerText = pmodel.SD;
                xe2.AppendChild(JCFFBH);
                xe2.AppendChild(JCLSH);
                xe2.AppendChild(DLY);
                xe2.AppendChild(YCY);
                xe2.AppendChild(JCY);
                xe2.AppendChild(WD);
                xe2.AppendChild(DQY);
                xe2.AppendChild(SD);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_BD_RESULT_DATA<T>(XB_BD_PUBLIC_DATA pmodel, T model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "DAILY_CHECK_RESULT";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");

                List<string> namelist = new List<string>();
                List<string> valuelist = new List<string>();
                if (XmlBuilderHelper.GetPorperty(pmodel, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        xe2.AppendChild(el);
                    }
                }
                string dataname = "";
                switch (pmodel.Items)
                {
                    case "01":
                        dataname = "Force"; break;
                    case "02":
                        dataname = ""; break;
                    case "03":
                        dataname = "PLHP"; break;
                    case "04":
                        dataname = "LoadedCoastDown"; break;
                    case "05":
                        dataname = "SealCheck"; break;
                    case "06":
                        dataname = "ExhaustGas"; break;
                    case "07":
                        dataname = "ExhaustGas"; break;
                    case "08":
                        dataname = "YDJ"; break;
                    case "09":
                        dataname = "LLJ"; break;
                    case "10":
                        dataname = ""; break;
                    case "11":
                        dataname = ""; break;
                    default: break;

                }
                XmlElement xe25 = xmldoc.CreateElement(dataname);
                
                    if (XmlBuilderHelper.GetPorperty(model, out namelist, out valuelist))
                    {
                        for (int i = 0; i < namelist.Count; i++)
                        {
                            XmlElement el = xmldoc.CreateElement(namelist[i]);
                            el.InnerText = valuelist[i];
                            xe25.AppendChild(el);
                        }
                    }
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_YDJBD_RESULT_DATA(XB_BD_PUBLIC_DATA pmodel, XB_YDJ_BD_DATA model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "DAILY_CHECK_RESULT";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");

                List<string> namelist = new List<string>();
                List<string> valuelist = new List<string>();
                if (XmlBuilderHelper.GetPorperty(pmodel, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        xe2.AppendChild(el);
                    }
                }
                string dataname = "YDJ";               
                XmlElement xe25 = xmldoc.CreateElement(dataname);
                XmlElement StdValue = xmldoc.CreateElement("StdValue");
                StdValue.InnerText = model.StdValue;
                xe25.AppendChild(StdValue);
                XmlElement SmokeValue = xmldoc.CreateElement("SmokeValue");
                XmlElement Item1 = xmldoc.CreateElement("Item1");
                Item1.InnerText = model.Item1;
                SmokeValue.AppendChild(Item1);
                XmlElement Item2 = xmldoc.CreateElement("Item2");
                Item2.InnerText = model.Item2;
                SmokeValue.AppendChild(Item2);
                XmlElement Item3 = xmldoc.CreateElement("Item3");
                Item3.InnerText = model.Item3;
                SmokeValue.AppendChild(Item3);
                xe25.AppendChild(SmokeValue);
                XmlElement SmokeAvgValue = xmldoc.CreateElement("SmokeAvgValue");
                SmokeAvgValue.InnerText = model.SmokeAvgValue;
                xe25.AppendChild(SmokeAvgValue);
                XmlElement AllowSmokeError = xmldoc.CreateElement("AllowSmokeError");
                AllowSmokeError.InnerText = model.AllowSmokeError;
                xe25.AppendChild(AllowSmokeError);
                XmlElement SmokeError = xmldoc.CreateElement("SmokeError");
                SmokeError.InnerText = model.SmokeError;
                xe25.AppendChild(SmokeError);
                XmlElement SmokeEvl = xmldoc.CreateElement("SmokeEvl");
                SmokeEvl.InnerText = model.SmokeEvl;
                xe25.AppendChild(SmokeEvl);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
        public bool Send_PLHPBD_RESULT_DATA(XB_BD_PUBLIC_DATA pmodel, XB_PLHP_BD_DATA model, out string result, out string info)
        {
            //socket.Connect(point);
            result = "0";
            info = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("head");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("cmd");//创建一个<Node>节点 
                xe101.InnerText = "DAILY_CHECK_RESULT";
                xe1.AppendChild(xe101);
                root.AppendChild(xe1);
                XmlElement xe2 = xmldoc.CreateElement("body");

                List<string> namelist = new List<string>();
                List<string> valuelist = new List<string>();
                if (XmlBuilderHelper.GetPorperty(pmodel, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        xe2.AppendChild(el);
                    }
                }
                string dataname = "PLHP";
                XmlElement xe25 = xmldoc.CreateElement(dataname);
                XmlElement LugPLHP = xmldoc.CreateElement("LugPLHP");
                XmlElement VmasPLHP = xmldoc.CreateElement("VmasPLHP");
                if (XmlBuilderHelper.GetPorperty(model, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        LugPLHP.AppendChild(el);
                        VmasPLHP.AppendChild(el);
                    }
                }
                xe25.AppendChild(LugPLHP);
                xe25.AppendChild(VmasPLHP);
                xe2.AppendChild(xe25);
                root.AppendChild(xe2);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    info = "Send Failure";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["head"];
                    result = dt1.Rows[0]["code"].ToString();
                    info = dt1.Rows[0]["info"].ToString();
                    if (result == "1")
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    info = "no answer";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                info = er.Message;
                return false;
            }
        }
    }
    public class XmlBuilderHelper
    {
        
       
        /// <summary>
        /// 获得值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetPorperty<T>(T obj,out List<string> propertyName,out List<string> propertyValue)
        {
            propertyName = null;
            propertyValue = null;
            if (obj == null)
            {
                return false;
            }
            propertyName = new List<string>();
            propertyValue = new List<string>();
            Type t = obj.GetType();
            PropertyInfo[] PropertyList = t.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(obj, null);
                propertyName.Add(name);
                propertyValue.Add(value.ToString());
            }
            return true;
        }
    }

}
