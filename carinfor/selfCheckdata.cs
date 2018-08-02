using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ini;
using System.IO;

namespace carinfor
{
    public class CGJselfCheckdata
    {


        private double hvitualtime;

        public double Hvitualtime
        {
            get { return hvitualtime; }
            set { hvitualtime = value; }
        }
        private double hrealtime;

        public double Hrealtime
        {
            get { return hrealtime; }
            set { hrealtime = value; }
        }
        private double lvitualtime;

        public double Lvitualtime
        {
            get { return lvitualtime; }
            set { lvitualtime = value; }
        }
        private double lrealtime;

        public double Lrealtime
        {
            get { return lrealtime; }
            set { lrealtime = value; }
        }
        private double hpower;

        public double Hpower
        {
            get { return hpower; }
            set { hpower = value; }
        }
        private double lpower;

        public double Lpower
        {
            get { return lpower; }
            set { lpower = value; }
        }
        private string checckResult;

        public string ChecckResult
        {
            get { return checckResult; }
            set { checckResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string Gxdl
        {
            get
            {
                return gxdl;
            }

            set
            {
                gxdl = value;
            }
        }

        public string Jzhxds
        {
            get
            {
                return jzhxds;
            }

            set
            {
                jzhxds = value;
            }
        }

        public string Cs1
        {
            get
            {
                return cs1;
            }

            set
            {
                cs1 = value;
            }
        }

        public string Pc1
        {
            get
            {
                return pc1;
            }

            set
            {
                pc1 = value;
            }
        }

        public string Jsgl1
        {
            get
            {
                return jsgl1;
            }

            set
            {
                jsgl1 = value;
            }
        }

        public string Cs2
        {
            get
            {
                return cs2;
            }

            set
            {
                cs2 = value;
            }
        }

        public string Pc2
        {
            get
            {
                return pc2;
            }

            set
            {
                pc2 = value;
            }
        }

        public string Jsgl2
        {
            get
            {
                return jsgl2;
            }

            set
            {
                jsgl2 = value;
            }
        }

        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }

        private string gxdl;
        private string jzhxds;
        private string cs1;
        private string pc1;
        private string jsgl1;
        private string cs2;
        private string pc2;
        private string jsgl2;
        private string zjjg;

        public string kssj1 { set; get; }
        public string kssj2 { set; get; }
        public string jssj1 { set; get; }
        public string jssj2 { set; get; }
    }
    public class cgjPLHPSelfcheck
    {
        private string speedQJ1;

        public string SpeedQJ1
        {
            get { return speedQJ1; }
            set { speedQJ1 = value; }
        }
        private double nameSpeed1;

        public double NameSpeed1
        {
            get { return nameSpeed1; }
            set { nameSpeed1 = value; }
        }
        private double plhp1;

        public double Plhp1
        {
            get { return plhp1; }
            set { plhp1 = value; }
        }
        private string speedQJ2;

        public string SpeedQJ2
        {
            get { return speedQJ2; }
            set { speedQJ2 = value; }
        }
        private double nameSpeed2;

        public double NameSpeed2
        {
            get { return nameSpeed2; }
            set { nameSpeed2 = value; }
        }
        private double plhp2;

        public double Plhp2
        {
            get { return plhp2; }
            set { plhp2 = value; }
        }
        private string speedQJ3;

        public string SpeedQJ3
        {
            get { return speedQJ3; }
            set { speedQJ3 = value; }
        }
        private double nameSpeed3;

        public double NameSpeed3
        {
            get { return nameSpeed3; }
            set { nameSpeed3 = value; }
        }
        private double plhp3;

        public double Plhp3
        {
            get { return plhp3; }
            set { plhp3 = value; }
        }
        private string speedQJ4;

        public string SpeedQJ4
        {
            get { return speedQJ4; }
            set { speedQJ4 = value; }
        }
        private double nameSpeed4;

        public double NameSpeed4
        {
            get { return nameSpeed4; }
            set { nameSpeed4 = value; }
        }
        private double plhp4;

        public double Plhp4
        {
            get { return plhp4; }
            set { plhp4 = value; }
        }
        private double maxSpeed;

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        private string checckResult;

        public string ChecckResult
        {
            get { return checckResult; }
            set { checckResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string hxsj1 { set; get; }
        public string kssj1 { set; get; }
        public string jssj1 { set; get; }
        public string hxsj2 { set; get; }
        public string kssj2 { set; get; }
        public string jssj2 { set; get; }
        public string hxsj3 { set; get; }
        public string kssj3 { set; get; }
        public string jssj3 { set; get; }
        public string hxsj4 { set; get; }
        public string kssj4 { set; get; }
        public string jssj4 { set; get; }
    }
    public class wqfxySelfcheck
    {
        private string tightnessResult;

        public string TightnessResult
        {
            get { return tightnessResult; }
            set { tightnessResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string Yqll
        {
            get
            {
                return yqll;
            }

            set
            {
                yqll = value;
            }
        }

        public string Yqyq
        {
            get
            {
                return yqyq;
            }

            set
            {
                yqyq = value;
            }
        }

        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }

        private string yqll;
        private string yqyq;
        private string zjjg;
    }
    public class ydjSelfcheck
    {
        private string zeroResult;

        public string ZeroResult
        {
            get { return zeroResult; }
            set { zeroResult = value; }
        }
        private double labelValueN50;

        public double LabelValueN50
        {
            get { return labelValueN50; }
            set { labelValueN50 = value; }
        }
        private double labelValueN70;

        public double LabelValueN70
        {
            get { return labelValueN70; }
            set { labelValueN70 = value; }
        }
        private double N50;

        public double N501
        {
            get { return N50; }
            set { N50 = value; }
        }
        private double N70;

        public double N701
        {
            get { return N70; }
            set { N70 = value; }
        }
        private double Error50;

        public double Error501
        {
            get { return Error50; }
            set { Error50 = value; }
        }
        private double Error70;

        public double Error701
        {
            get { return Error70; }
            set { Error70 = value; }
        }
        private string CheckResult;

        public string CheckResult1
        {
            get { return CheckResult; }
            set { CheckResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string Jcds
        {
            get
            {
                return jcds;
            }

            set
            {
                jcds = value;
            }
        }

        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }

        private string jcds;
        private string zjjg;

        private double nZero;

        public double NZero
        {
            get { return nZero; }
            set { nZero = value; }
        }

        private double N90;

        public double N901
        {
            get { return N90; }
            set { N90 = value; }
        }
        private double Error90;

        public double Error901
        {
            get { return Error90; }
            set { Error90 = value; }
        }
        private double labelValueN90;

        public double LabelValueN90
        {
            get { return labelValueN90; }
            set { labelValueN90 = value; }
        }
    }
    public class sdsqtfxySelfcheck
    {
        private string tightnessResult;

        public string TightnessResult
        {
            get { return tightnessResult; }
            set { tightnessResult = value; }
        }
        private string lFlowResult;

        public string LFlowResult
        {
            get { return lFlowResult; }
            set { lFlowResult = value; }
        }
        private double canliuHC;

        public double CanliuHC
        {
            get { return canliuHC; }
            set { canliuHC = value; }
        }
        private string checkResult;

        public string CheckResult
        {
            get { return checkResult; }
            set { checkResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string Yqll
        {
            get
            {
                return yqll;
            }

            set
            {
                yqll = value;
            }
        }

        public string Yqyq
        {
            get
            {
                return yqyq;
            }

            set
            {
                yqyq = value;
            }
        }

        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }

        private string yqll;
        private string yqyq;
        private string zjjg;
    }
    public class lljSelfcheck
    {
        private string txJc;

        public string TxJc
        {
            get { return txJc; }
            set { txJc = value; }
        }
        private string lljll;

        public string Lljll
        {
            get { return lljll; }
            set { lljll = value; }
        }
        private string lljo2;

        public string Lljo2
        {
            get { return lljo2; }
            set { lljo2 = value; }
        }
        private string checkResult;

        public string CheckResult
        {
            get { return checkResult; }
            set { checkResult = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public double lljsjll { set; get; }
        public double lljmyll { set; get; }
        public double lljsjllwc { set; get; }
    }
    public class hjcsgyqSelfcheck
    {
        private double actualTemperature;

        public double ActualTemperature
        {
            get { return actualTemperature; }
            set { actualTemperature = value; }
        }
        private double temperature;

        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        private double actualHumidity;

        public double ActualHumidity
        {
            get { return actualHumidity; }
            set { actualHumidity = value; }
        }
        private double humidity;

        public double Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }
        private double actualAirPressure;

        public double ActualAirPressure
        {
            get { return actualAirPressure; }
            set { actualAirPressure = value; }
        }
        private double airPressure;

        public double AirPressure
        {
            get { return airPressure; }
            set { airPressure = value; }
        }
        private string checkTimeStart;

        public string CheckTimeStart
        {
            get { return checkTimeStart; }
            set { checkTimeStart = value; }
        }
        private string checkTimeEnd;

        public string CheckTimeEnd
        {
            get { return checkTimeEnd; }
            set { checkTimeEnd = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private bool tempok;

        public bool Tempok
        {
            get { return tempok; }
            set { tempok = value; }
        }
        private bool humiok;

        public bool Humiok
        {
            get { return humiok; }
            set { humiok = value; }
        }
        private bool airpok;

        public bool Airpok
        {
            get { return airpok; }
            set { airpok = value; }
        }


        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }

        private string zjjg;
    }

    public class fdjzsSelfCheck
    {
        private string dszs;
        private string zjjg;

        public string Dszs
        {
            get
            {
                return dszs;
            }

            set
            {
                dszs = value;
            }
        }

        public string Zjjg
        {
            get
            {
                return zjjg;
            }

            set
            {
                zjjg = value;
            }
        }
    }
    public class selfCheckState
    {
        private string chCmd;
        private string nType;
        private string sjxl;
        private string sbbh;

        public string ChCmd
        {
            get
            {
                return chCmd;
            }

            set
            {
                chCmd = value;
            }
        }

        public string NType
        {
            get
            {
                return nType;
            }

            set
            {
                nType = value;
            }
        }

        public string Sjxl
        {
            get
            {
                return sjxl;
            }

            set
            {
                sjxl = value;
            }
        }

        public string Sbbh
        {
            get
            {
                return sbbh;
            }

            set
            {
                sbbh = value;
            }
        }
    }

    public class wqfxyAdjust
    {
        private string gasType;
        private double labelValueCO2;
        private double detectValueCO2;
        private double labelValueCO;
        private double detectValueCO;
        private double labelValueNO;
        private double detectValueNO;
        private double labelValueHC;
        private double detectValueHC;
        private double labelValueO2;
        private double detectValueO2;
        private double labelValuePEF;
        private double labelValueC3H8;
        private string adjustResult;
        private string adjustTimeStart;
        private string adjustTimeEnd;
        private string remark;

    }

    public class selfCheckIni
    {
        public bool writeCGJcheckIni(CGJselfCheckdata cgjcheckdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("自检数据", "HVitualTime", cgjcheckdata.Hvitualtime.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "HrealTime", cgjcheckdata.Hrealtime.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "LvitualTime", cgjcheckdata.Lvitualtime.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "LrealTime", cgjcheckdata.Lrealtime.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "Hpower", cgjcheckdata.Hpower.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "Lpower", cgjcheckdata.Lpower.ToString(), "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkResult", cgjcheckdata.ChecckResult, "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeStart", cgjcheckdata.CheckTimeStart, "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeEnd", cgjcheckdata.CheckTimeEnd, "C:/jcdatatxt/CGJcheckdata.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "remark", cgjcheckdata.Remark, "C:/jcdatatxt/CGJcheckdata.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public CGJselfCheckdata readCGJcheckIni()
        {
            try
            {
                double a = 0;
                CGJselfCheckdata configinidata = new CGJselfCheckdata();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("自检数据", "jzhxds", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Jzhxds = temp.ToString().Trim();
                ini.INIIO.GetPrivateProfileString("自检数据", "HVitualTime", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Hvitualtime = a;
                else
                    configinidata.Hvitualtime = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "HrealTime", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Hrealtime = a;
                else
                    configinidata.Hrealtime = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "LvitualTime", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Lvitualtime = a;
                else
                    configinidata.Lvitualtime = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "LrealTime", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Lrealtime = a;
                else
                    configinidata.Lrealtime = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "Hpower", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Hpower = a;
                else
                    configinidata.Hpower = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "Lpower", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Lpower = a;
                else
                    configinidata.Lpower = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "checkResult", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.ChecckResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "gxdl", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Gxdl = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "cs1", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Cs1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "pc1", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Pc1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jsgl1", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Jsgl1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "cs2", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Cs2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "pc2", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Pc2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jsgl2", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Jsgl2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "zjjg", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.Zjjg = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj1", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.kssj1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj1", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.jssj1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj2", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.kssj2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj2", "", temp, 2048, "C:/jcdatatxt/CGJcheckdata.ini");
                configinidata.jssj2 = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public bool writecgjPLHPSelfcheck(cgjPLHPSelfcheck cgjcheckdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("自检数据", "speedQJ1", cgjcheckdata.SpeedQJ1, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "nameSpeed1", cgjcheckdata.NameSpeed1.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "plhp1", cgjcheckdata.Plhp1.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "speedQJ2", cgjcheckdata.SpeedQJ2, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "nameSpeed2", cgjcheckdata.NameSpeed2.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "plhp2", cgjcheckdata.Plhp2.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "speedQJ3", cgjcheckdata.SpeedQJ3, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "nameSpeed3", cgjcheckdata.NameSpeed3.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "plhp3", cgjcheckdata.Plhp3.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "speedQJ4", cgjcheckdata.SpeedQJ4, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "nameSpeed4", cgjcheckdata.NameSpeed4.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "plhp4", cgjcheckdata.Plhp4.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");

                ini.INIIO.WritePrivateProfileString("自检数据", "maxSpeed", cgjcheckdata.MaxSpeed.ToString(), "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkResult", cgjcheckdata.ChecckResult, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeStart", cgjcheckdata.CheckTimeStart, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeEnd", cgjcheckdata.CheckTimeEnd, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "remark", cgjcheckdata.Remark, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public cgjPLHPSelfcheck readcgjPLHPSelfcheck()
        {
            try
            {
                double a = 0;
                cgjPLHPSelfcheck configinidata = new cgjPLHPSelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("自检数据", "nameSpeed1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.NameSpeed1 = a;
                else
                    configinidata.NameSpeed1 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "nameSpeed2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.NameSpeed2 = a;
                else
                    configinidata.NameSpeed2 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "nameSpeed3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.NameSpeed3 = a;
                else
                    configinidata.NameSpeed3 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "nameSpeed4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.NameSpeed4 = a;
                else
                    configinidata.NameSpeed4 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "plhp1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Plhp1 = a;
                else
                    configinidata.Plhp1 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "plhp2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Plhp2 = a;
                else
                    configinidata.Plhp2 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "plhp3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Plhp3 = a;
                else
                    configinidata.Plhp3 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "plhp4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Plhp4 = a;
                else
                    configinidata.Plhp4 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "speedQJ1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.SpeedQJ1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "speedQJ2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.SpeedQJ2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "speedQJ3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.SpeedQJ3 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "speedQJ4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.SpeedQJ4 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "maxSpeed", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.MaxSpeed = a;
                else
                    configinidata.MaxSpeed = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "checkResult", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.ChecckResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "hxsj1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.hxsj1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.kssj1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj1", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.jssj1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "hxsj2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.hxsj2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.kssj2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj2", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.jssj2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "hxsj3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.hxsj3 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.kssj3 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj3", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.jssj3= temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "hxsj4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.hxsj4 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "kssj4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.kssj4 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jssj4", "", temp, 2048, "C:/jcdatatxt/cgjPLHPSelfcheck.ini");
                configinidata.jssj4 = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public bool writewqfxySelfcheck(wqfxySelfcheck cgjcheckdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("自检数据", "tightnessResult", cgjcheckdata.TightnessResult, "C:/jcdatatxt/wqfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeStart", cgjcheckdata.CheckTimeStart, "C:/jcdatatxt/wqfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeEnd", cgjcheckdata.CheckTimeEnd, "C:/jcdatatxt/wqfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "remark", cgjcheckdata.Remark, "C:/jcdatatxt/wqfxySelfcheck.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool writeWSD(string wd,string sd,string dqy)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("环境数据", "wd", wd, "C:/jcdatatxt/环境数据.ini");
                ini.INIIO.WritePrivateProfileString("环境数据", "sd", sd, "C:/jcdatatxt/环境数据.ini");
                ini.INIIO.WritePrivateProfileString("环境数据", "dqy", dqy, "C:/jcdatatxt/环境数据.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public wqfxySelfcheck readwqfxySelfcheck()
        {
            try
            {
                wqfxySelfcheck configinidata = new wqfxySelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("自检数据", "tightnessResult", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.TightnessResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Yqll", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.Yqll = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Yqyq", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.Yqyq = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Zjjg", "", temp, 2048, "C:/jcdatatxt/wqfxySelfcheck.ini");
                configinidata.Zjjg = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public bool writeydjSelfcheck(ydjSelfcheck cgjcheckdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("自检数据", "zeroResult", cgjcheckdata.ZeroResult, "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "labelValueN50", cgjcheckdata.LabelValueN50.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "labelValueN70", cgjcheckdata.LabelValueN70.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "N50", cgjcheckdata.N501.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "N70", cgjcheckdata.N701.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "Error50", cgjcheckdata.Error501.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "Error70", cgjcheckdata.Error701.ToString(), "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "CheckResult", cgjcheckdata.CheckResult1, "C:/jcdatatxt/ydjSelfcheck.ini");

                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeStart", cgjcheckdata.CheckTimeStart, "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeEnd", cgjcheckdata.CheckTimeEnd, "C:/jcdatatxt/ydjSelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "remark", cgjcheckdata.Remark, "C:/jcdatatxt/ydjSelfcheck.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ydjSelfcheck readydjSelfcheck()
        {
            try
            {
                double a = 0;
                ydjSelfcheck configinidata = new ydjSelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;

                ini.INIIO.GetPrivateProfileString("自检数据", "zeroResult", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.ZeroResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "labelValueN50", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.LabelValueN50 = a;
                else
                    configinidata.LabelValueN50 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "labelValueN70", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.LabelValueN70 = a;
                else
                    configinidata.LabelValueN70 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "N50", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.N501 = a;
                else
                    configinidata.N501 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "N70", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.N701 = a;
                else
                    configinidata.N701 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "Error50", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Error501 = a;
                else
                    configinidata.Error501 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "Error70", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Error701 = a;
                else
                    configinidata.Error701 = 0;

                ini.INIIO.GetPrivateProfileString("自检数据", "NZero", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.NZero = a;
                else
                    configinidata.NZero = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "labelValueN90", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.LabelValueN90 = a;
                else
                    configinidata.LabelValueN90 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "N90", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.N901 = a;
                else
                    configinidata.N901 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "Error90", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Error901 = a;
                else
                    configinidata.Error901 = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "CheckResult", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.CheckResult1 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "jcds", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.Jcds = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "zjjg", "", temp, 2048, "C:/jcdatatxt/ydjSelfcheck.ini");
                configinidata.Zjjg = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public lljSelfcheck readLljSelfcheck()
        {
            try
            {
                double a = 0;
                lljSelfcheck configinidata = new lljSelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;

                ini.INIIO.GetPrivateProfileString("自检数据", "Lljsjll", "0", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.lljsjll = double.Parse(temp.ToString());
                ini.INIIO.GetPrivateProfileString("自检数据", "Lljmyll", "0", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.lljmyll = double.Parse(temp.ToString());
                ini.INIIO.GetPrivateProfileString("自检数据", "Lljsjllwc", "0", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.lljsjllwc = double.Parse(temp.ToString());

                ini.INIIO.GetPrivateProfileString("自检数据", "Lljll", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.Lljll = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Lljo2", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.Lljo2 = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Lljtx", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.TxJc = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkResult", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.CheckResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/LLJcheckdata.ini");
                configinidata.Remark = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public bool writesdsqtfxySelfcheck(sdsqtfxySelfcheck cgjcheckdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("自检数据", "tightnessResult", cgjcheckdata.TightnessResult, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "lFlowResult", cgjcheckdata.LFlowResult, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "canliuHC", cgjcheckdata.CanliuHC.ToString(), "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkResult", cgjcheckdata.CheckResult, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeStart", cgjcheckdata.CheckTimeStart, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "checkTimeEnd", cgjcheckdata.CheckTimeEnd, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                ini.INIIO.WritePrivateProfileString("自检数据", "remark", cgjcheckdata.Remark, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public sdsqtfxySelfcheck readsdsqtfxySelfcheck()
        {
            try
            {
                double a = 0;
                sdsqtfxySelfcheck configinidata = new sdsqtfxySelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("自检数据", "tightnessResult", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.TightnessResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "lFlowResult", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.LFlowResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "canliuHC", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.CanliuHC = a;
                else
                    configinidata.CanliuHC = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "CheckResult", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.CheckResult = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Yqll", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.Yqll = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Yqyq", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.Yqyq = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Zjjg", "", temp, 2048, "C:/jcdatatxt/sdsqtfxySelfcheck.ini");
                configinidata.Zjjg = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }

        public hjcsgyqSelfcheck readdzhjSelfcheck()
        {
            try
            {
                double a = 0;
                hjcsgyqSelfcheck configinidata = new hjcsgyqSelfcheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;

                ini.INIIO.GetPrivateProfileString("自检数据", "actualTemperature", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.ActualTemperature = a;
                else
                    configinidata.ActualTemperature = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "temperature", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Temperature = a;
                else
                    configinidata.Temperature = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "actualHumidity", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.ActualHumidity = a;
                else
                    configinidata.ActualHumidity = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "humidity", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.Humidity = a;
                else
                    configinidata.Humidity = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "actualAirPressure", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.ActualAirPressure = a;
                else
                    configinidata.ActualAirPressure = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "airPressure", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                if (double.TryParse(temp.ToString().Trim(), out a))
                    configinidata.AirPressure = a;
                else
                    configinidata.AirPressure = 0;
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeStart", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.CheckTimeStart = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "checkTimeEnd", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.CheckTimeEnd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "remark", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.Remark = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "tempok", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.Tempok = (temp.ToString() == "Y");
                ini.INIIO.GetPrivateProfileString("自检数据", "humiok", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.Humiok = (temp.ToString() == "Y");
                ini.INIIO.GetPrivateProfileString("自检数据", "airpok", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.Airpok = (temp.ToString() == "Y");
                ini.INIIO.GetPrivateProfileString("自检数据", "zjjg", "", temp, 2048, "C:/jcdatatxt/hjcsgyqSelfcheck.ini");
                configinidata.Zjjg = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public fdjzsSelfCheck readfdjzsSelfcheck()
        {
            try
            {
                double a = 0;
                fdjzsSelfCheck configinidata = new fdjzsSelfCheck();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;

                
                ini.INIIO.GetPrivateProfileString("自检数据", "Dszs", "", temp, 2048, "C:/jcdatatxt/fdjzsSelfcheck.ini");
                configinidata.Dszs = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "Zjjg", "", temp, 2048, "C:/jcdatatxt/fdjzsSelfcheck.ini");
                configinidata.Zjjg = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }
        public selfCheckState readSelfcheckState()
        {
            try
            {
                selfCheckState configinidata = new selfCheckState();
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("自检数据", "chCmd", "", temp, 2048, "C:/jcdatatxt/checkstatedata.ini");
                configinidata.ChCmd = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "nType", "", temp, 2048, "C:/jcdatatxt/checkstatedata.ini");
                configinidata.NType = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "sjxl", "", temp, 2048, "C:/jcdatatxt/checkstatedata.ini");
                configinidata.Sjxl = temp.ToString();
                ini.INIIO.GetPrivateProfileString("自检数据", "sbbh", "", temp, 2048, "C:/jcdatatxt/checkstatedata.ini");
                configinidata.Sbbh = temp.ToString();
                return configinidata;
            }
            catch
            {
                return null;
            }
        }

    }
}
