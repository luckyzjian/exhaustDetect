using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carinfor
{
    public class equipmentConfigInfdata
    {

        private string cgjck;

        public string Cgjck
        {
            get { return cgjck; }
            set { cgjck = value; }
        }
        private string fqyck;

        public string Fqyck
        {
            get { return fqyck; }
            set { fqyck = value; }
        }
        private string lljck;

        public string Lljck
        {
            get { return lljck; }
            set { lljck = value; }
        }
        private string ydjck;

        public string Ydjck
        {
            get { return ydjck; }
            set { ydjck = value; }
        }

        private string ledck;

        public string Ledck
        {
            get { return ledck; }
            set { ledck = value; }
        }
        private string xce100ck;

        public string Xce100ck
        {
            get { return xce100ck; }
            set { xce100ck = value; }
        }
        private bool cgjifpz;

        public bool Cgjifpz
        {
            get { return cgjifpz; }
            set { cgjifpz = value; }
        }
        private bool fqyifpz;

        public bool Fqyifpz
        {
            get { return fqyifpz; }
            set { fqyifpz = value; }
        }
        private bool lljifpz;

        public bool Lljifpz
        {
            get { return lljifpz; }
            set { lljifpz = value; }
        }
        private bool ydjifpz;

        public bool Ydjifpz
        {
            get { return ydjifpz; }
            set { ydjifpz = value; }
        }
        private bool ledifpz;

        public bool Ledifpz
        {
            get { return ledifpz; }
            set { ledifpz = value; }
        }
        private string cgjxh;

        public string Cgjxh
        {
            get { return cgjxh; }
            set { cgjxh = value; }
        }
        private string fqyxh;

        public string Fqyxh
        {
            get { return fqyxh; }
            set { fqyxh = value; }
        }
        private string lljxh;

        public string Lljxh
        {
            get { return lljxh; }
            set { lljxh = value; }
        }
        private string ydjxh;

        public string Ydjxh
        {
            get { return ydjxh; }
            set { ydjxh = value; }
        }

        private string[] powerSet;

        public string[] PowerSet
        {
            get { return powerSet; }
            set { powerSet = value; }
        }
        private string lzydjxh;

        public string Lzydjxh
        {
            get { return lzydjxh; }
            set { lzydjxh = value; }
        }
        private bool lzydjifpz;

        public bool Lzydjifpz
        {
            get { return lzydjifpz; }
            set { lzydjifpz = value; }
        }
        private string lzydjck;

        public string Lzydjck
        {
            get { return lzydjck; }
            set { lzydjck = value; }
        }
        private string tempInstrument;

        public string TempInstrument
        {
            get { return tempInstrument; }
            set { tempInstrument = value; }
        }
        private string displayMethod;

        public string DisplayMethod
        {
            get { return displayMethod; }
            set { displayMethod = value; }
        }
        private int mainDislpay;

        public int MainDislpay
        {
            get { return mainDislpay; }
            set { mainDislpay = value; }
        }
        private int driverDisplay;

        public int DriverDisplay
        {
            get { return driverDisplay; }
            set { driverDisplay = value; }
        }

        private bool workAutomaticMode;
        public bool WorkAutomaticMode
        {
            get
            {
                return workAutomaticMode;
            }

            set
            {
                workAutomaticMode = value;
            }
        }

        private string tmqxh;

        public string Tmqxh
        {
            get { return tmqxh; }
            set { tmqxh = value; }
        }
        private string tmqck;

        public string Tmqck
        {
            get { return tmqck; }
            set { tmqck = value; }
        }
        private string tmqckpz;

        public string Tmqckpz
        {
            get { return tmqckpz; }
            set { tmqckpz = value; }
        }

        public bool isTpTempInstrument { set; get; }
        public bool isFdjzsJudge { set; get; }
        public bool displayJudge { set; get; }
    }
    public class VmasConfigInfdata
    {
        private bool speedMonitor;

        public bool SpeedMonitor
        {
            get { return speedMonitor; }
            set { speedMonitor = value; }
        }
        private bool powerMonitor;

        public bool PowerMonitor
        {
            get { return powerMonitor; }
            set { powerMonitor = value; }
        }
        private bool concentrationMonitor;

        public bool ConcentrationMonitor
        {
            get { return concentrationMonitor; }
            set { concentrationMonitor = value; }
        }
        private bool flowMonitorr;

        public bool FlowMonitorr
        {
            get { return flowMonitorr; }
            set { flowMonitorr = value; }
        }
        private bool thinnerratioMonitor;

        public bool ThinnerratioMonitor
        {
            get { return thinnerratioMonitor; }
            set { thinnerratioMonitor = value; }
        }
        private bool huanjingo2Monitor;

        public bool Huanjingo2Monitor
        {
            get { return huanjingo2Monitor; }
            set { huanjingo2Monitor = value; }
        }
        private bool remainedMonitor;

        public bool RemainedMonitor
        {
            get { return remainedMonitor; }
            set { remainedMonitor = value; }
        }



        private bool ifFqyTl;

        public bool IfFqyTl
        {
            get { return ifFqyTl; }
            set { ifFqyTl = value; }
        }

        private bool flowback;

        public bool Flowback
        {
            get { return flowback; }
            set { flowback = value; }
        }

        private bool ifSureTemp;

        public bool IfSureTemp
        {
            get { return ifSureTemp; }
            set { ifSureTemp = value; }
        }
        private bool ifDisplayData;

        public bool IfDisplayData
        {
            get { return ifDisplayData; }
            set { ifDisplayData = value; }
        }
        private float ndz;

        public float Ndz
        {
            get { return ndz; }
            set { ndz = value; }
        }
        private float lljll;

        public float Lljll
        {
            get { return lljll; }
            set { lljll = value; }
        }
        private float wqll;

        public float Wqll
        {
            get { return wqll; }
            set { wqll = value; }
        }
        private float xsb;

        public float Xsb
        {
            get { return xsb; }
            set { xsb = value; }
        }
        private float gljz;

        public float Gljz
        {
            get { return gljz; }
            set { gljz = value; }
        }

        private float lxcc;


        public float Lxcc
        {
            get { return lxcc; }
            set { lxcc = value; }
        }
        private float ljcc;

        public float Ljcc
        {
            get { return ljcc; }
            set { ljcc = value; }
        }

        private int dssj;

        public int Dssj
        {
            get { return dssj; }
            set { dssj = value; }
        }


        private int flowTime;


        public int FlowTime
        {
            get { return flowTime; }
            set { flowTime = value; }
        }


    }
    public class AsmConfigInfdata
    {
        private bool speedMonitor;

        public bool SpeedMonitor
        {
            get { return speedMonitor; }
            set { speedMonitor = value; }
        }
        private bool powerMonitor;

        public bool PowerMonitor
        {
            get { return powerMonitor; }
            set { powerMonitor = value; }
        }
        private bool concentrationMonitor;

        public bool ConcentrationMonitor
        {
            get { return concentrationMonitor; }
            set { concentrationMonitor = value; }
        }
        private bool remainedMonitor;

        public bool RemainedMonitor
        {
            get { return remainedMonitor; }
            set { remainedMonitor = value; }
        }



        private bool ifFqyTl;

        public bool IfFqyTl
        {
            get { return ifFqyTl; }
            set { ifFqyTl = value; }
        }

        private bool flowback;

        public bool Flowback
        {
            get { return flowback; }
            set { flowback = value; }
        }

        private bool ifSureTemp;

        public bool IfSureTemp
        {
            get { return ifSureTemp; }
            set { ifSureTemp = value; }
        }
        private bool ifDisplayData;

        public bool IfDisplayData
        {
            get { return ifDisplayData; }
            set { ifDisplayData = value; }
        }
        private float ndz;

        public float Ndz
        {
            get { return ndz; }
            set { ndz = value; }
        }

        private float gljz;

        public float Gljz
        {
            get { return gljz; }
            set { gljz = value; }
        }

        private float lxcc;


        public float Lxcc
        {
            get { return lxcc; }
            set { lxcc = value; }
        }

        private int flowTime;


        public int FlowTime
        {
            get { return flowTime; }
            set { flowTime = value; }
        }


    }
    public class SdsConfigInfdata
    {
        private bool rotateSpeedMonitor;

        public bool RotateSpeedMonitor
        {
            get { return rotateSpeedMonitor; }
            set { rotateSpeedMonitor = value; }
        }

        private bool concentrationMonitor;

        public bool ConcentrationMonitor
        {
            get { return concentrationMonitor; }
            set { concentrationMonitor = value; }
        }

        private bool ifFqyTl;

        public bool IfFqyTl
        {
            get { return ifFqyTl; }
            set { ifFqyTl = value; }
        }

        private bool flowback;

        public bool Flowback
        {
            get { return flowback; }
            set { flowback = value; }
        }


        private float ndz;

        public float Ndz
        {
            get { return ndz; }
            set { ndz = value; }
        }

        private int zscc;

        public int Zscc
        {
            get { return zscc; }
            set { zscc = value; }
        }

        private int flowTime;


        public int FlowTime
        {
            get { return flowTime; }
            set { flowTime = value; }
        }

        private string zsj;

        public string Zsj
        {
            get { return zsj; }
            set { zsj = value; }
        }

        private string zsjck;

        public string Zsjck
        {
            get { return zsjck; }
            set { zsjck = value; }
        }


    }
    public class BtgConfigInfdata
    {
        private bool rotateSpeedMonitor;

        public bool RotateSpeedMonitor
        {
            get { return rotateSpeedMonitor; }
            set { rotateSpeedMonitor = value; }
        }


        private int dyzs;

        public int Dyzs
        {
            get { return dyzs; }
            set { dyzs = value; }
        }

        private string zsj;

        public string Zsj
        {
            get { return zsj; }
            set { zsj = value; }
        }

        private string zsjck;

        public string Zsjck
        {
            get { return zsjck; }
            set { zsjck = value; }
        }


    }
    public class LugdownConfigInfdata
    {
        private float minSpeed;

        public float MinSpeed
        {
            get { return minSpeed; }
            set { minSpeed = value; }
        }
        private bool ifSureTemp;

        public bool IfSureTemp
        {
            get { return ifSureTemp; }
            set { ifSureTemp = value; }
        }

        private float maxSpeed;

        public float MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        private string zsj;

        public string Zsj
        {
            get { return zsj; }
            set { zsj = value; }
        }

        private string zsjck;

        public string Zsjck
        {
            get { return zsjck; }
            set { zsjck = value; }
        }

        private string glsmms;

        public string Glsmms
        {
            get { return glsmms; }
            set { glsmms = value; }
        }
        private float smpl;

        public float Smpl
        {
            get { return smpl; }
            set { smpl = value; }
        }


    }
    public class captureConfigData
    {
        public int captureMethod { set; get; }
        public string NVRIP { set; get; }
        public int NVRPORT { set; get; }
        public string NVRUSER { set; get; }
        public string NVRPASSWORD { set; get; }
        public int NVRFRONTCHANEL { set; get; }
        public int NVRBACKCHANEL { set; get; }
        public string CAMERAFRONTIP { set; get; }
        public int CAMERAFRONTPORT { set; get; }
        public string CAMERAFRONTUSER { set; get; }
        public string CAMERAFRONTPASSWORD { set; get; }
        public string CAMERABACKIP { set; get; }
        public int CAMERABACKPORT { set; get; }
        public string CAMERABACKUSER { set; get; }
        public string CAMERABACKPASSWORD { set; get; }
        public bool ENABLEFRONT { set; get; }
        public bool ENABLEBACK { set; get; }
        public bool cap_vmas_start { set; get; }
        public bool cap_vmas_15 { set; get; }
        public bool cap_vmas_32 { set; get; }
        public bool cap_vmas_50 { set; get; }
        public bool cap_asm_start { set; get; }
        public bool cap_asm_5025 { set; get; }
        public bool cap_asm_2540 { set; get; }
        public bool cap_sds_start { set; get; }
        public bool cap_sds_high { set; get; }
        public bool cap_sds_low { set; get; }
        public bool cap_lugdown_start { set; get; }
        public bool cap_lugdown_100 { set; get; }
        public bool cap_lugdown_90 { set; get; }
        public bool cap_lugdown_80 { set; get; }
        public bool cap_btg_start { set; get; }
        public bool cap_btg_first { set; get; }
        public bool cap_btg_second { set; get; }
        public bool cap_btg_third { set; get; }
        public bool cap_xn_start { set; get; }

    }
    public class configIni
    {
        public equipmentConfigInfdata getEquipConfigIni()
        {
            float a = 0;
            int b = 0;
            equipmentConfigInfdata configinidata = new equipmentConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("配置参数", "测功机串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Cgjck = temp.ToString().Trim().Split('/')[0];
            configinidata.Cgjxh = temp.ToString().Trim().Split('/')[1];
            ini.INIIO.GetPrivateProfileString("配置参数", "滤纸烟度计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            try
            {
                configinidata.Lzydjck = temp.ToString().Trim().Split('/')[0];
                configinidata.Lzydjxh = temp.ToString().Trim().Split('/')[1];
            }
            catch
            { }
            ini.INIIO.GetPrivateProfileString("配置参数", "废气仪串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Fqyck = temp.ToString().Trim().Split('/')[0];
            configinidata.Fqyxh = temp.ToString().Trim().Split('/')[1];
            ini.INIIO.GetPrivateProfileString("配置参数", "流量计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Lljck = temp.ToString().Trim().Split('/')[0];
            configinidata.Lljxh = temp.ToString().Trim().Split('/')[1];
            ini.INIIO.GetPrivateProfileString("配置参数", "烟度计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Ydjck = temp.ToString().Trim().Split('/')[0];
            configinidata.Ydjxh = temp.ToString().Trim().Split('/')[1];
            ini.INIIO.GetPrivateProfileString("配置参数", "LED串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Ledck = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("配置参数", "XCE100串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Xce100ck = temp.ToString().Trim();



            ini.INIIO.GetPrivateProfileString("配置参数", "条码枪型号", "无", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Tmqxh = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("配置参数", "条码枪串口", "COM1", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Tmqck = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("配置参数", "条码枪串口配置", "9600,N,8,1", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Tmqckpz = temp.ToString().Trim();


            ini.INIIO.GetPrivateProfileString("配置参数", "测功机", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Cgjifpz = true;
            else
                configinidata.Cgjifpz = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "滤纸烟度计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Lzydjifpz = true;
            else
                configinidata.Lzydjifpz = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "废气仪", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Fqyifpz = true;
            else
                configinidata.Fqyifpz = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "流量计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Lljifpz = true;
            else
                configinidata.Lljifpz = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "烟度计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Ydjifpz = true;
            else
                configinidata.Ydjifpz = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "LED屏", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Ledifpz = true;
            else
                configinidata.Ledifpz = false;

            ini.INIIO.GetPrivateProfileString("配置参数", "统配温湿度计", "N", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "Y")
                configinidata.isTpTempInstrument = true;
            else
                configinidata.isTpTempInstrument = false;

            ini.INIIO.GetPrivateProfileString("吸收功率", "功率", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.PowerSet = temp.ToString().Trim().Split(',');

            ini.INIIO.GetPrivateProfileString("配置参数", "温湿度计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.TempInstrument = temp.ToString();
            ini.INIIO.GetPrivateProfileString("配置参数", "显示方式", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.DisplayMethod = temp.ToString();
            ini.INIIO.GetPrivateProfileString("配置参数", "主显示", "0", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
            try
            {
                configinidata.MainDislpay = int.Parse(temp.ToString());
            }
            catch
            {
                configinidata.MainDislpay = 0;
            }
            ini.INIIO.GetPrivateProfileString("配置参数", "司机助", "1", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
            try
            {
                configinidata.DriverDisplay = int.Parse(temp.ToString());
            }
            catch
            {
                configinidata.DriverDisplay = 1;
            }
            ini.INIIO.GetPrivateProfileString("配置参数", "全自动工作模式", "N", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "Y")
                configinidata.WorkAutomaticMode = true;
            else
                configinidata.WorkAutomaticMode = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "是否评价发动机转速", "false", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.isFdjzsJudge = true;
            else
                configinidata.isFdjzsJudge = false;
            ini.INIIO.GetPrivateProfileString("配置参数", "显示评价结果", "Y", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "Y")
                configinidata.displayJudge = true;
            else
                configinidata.displayJudge = false;
            return configinidata;
        }
        public bool writeEquipmentConfig(equipmentConfigInfdata equipconfig)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("配置参数", "测功机串口", equipconfig.Cgjck + "/" + equipconfig.Cgjxh, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "滤纸烟度计串口", equipconfig.Lzydjck + "/" + equipconfig.Lzydjxh, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "滤纸烟度计", equipconfig.Lzydjifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "废气仪串口", equipconfig.Fqyck + "/" + equipconfig.Fqyxh, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "流量计串口", equipconfig.Lljck + "/" + equipconfig.Lljxh, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "烟度计串口", equipconfig.Ydjck + "/" + equipconfig.Ydjxh, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "LED串口", equipconfig.Ledck.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "XCE100串口", equipconfig.Xce100ck.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "测功机", equipconfig.Cgjifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "废气仪", equipconfig.Fqyifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "流量计", equipconfig.Lljifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "烟度计", equipconfig.Ydjifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "LED屏", equipconfig.Ledifpz.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("吸收功率", "功率", equipconfig.PowerSet[0] + "," + equipconfig.PowerSet[1] + "," + equipconfig.PowerSet[2] + "," + equipconfig.PowerSet[3] + "," +
                equipconfig.PowerSet[4] + "," + equipconfig.PowerSet[5] + "," + equipconfig.PowerSet[6] + "," + equipconfig.PowerSet[7] + "," + equipconfig.PowerSet[8] + "," + equipconfig.PowerSet[9] + "," + equipconfig.PowerSet[10], @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "温湿度计", equipconfig.TempInstrument.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "显示方式", equipconfig.DisplayMethod.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "司机助", equipconfig.DriverDisplay.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("配置参数", "全自动工作模式", equipconfig.WorkAutomaticMode ? "Y" : "N", @"D:\环保检测子程序\detectConfig.ini");
                //ini.INIIO.WritePrivateProfileString("配置参数", "显示方式", equipconfig.DisplayMethod.ToString(), @"D:\环保检测子程序\detectConfig.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public VmasConfigInfdata getVmasConfigIni()
        {
            float a = 0;
            int b = 0;
            VmasConfigInfdata configinidata = new VmasConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("VMAS", "速度监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.SpeedMonitor = true;
            else
                configinidata.SpeedMonitor = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "加载功率监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.PowerMonitor = true;
            else
                configinidata.PowerMonitor = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "浓度监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.ConcentrationMonitor = true;
            else
                configinidata.ConcentrationMonitor = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "流量监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.FlowMonitorr = true;
            else
                configinidata.FlowMonitorr = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "稀释比监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.ThinnerratioMonitor = true;
            else
                configinidata.ThinnerratioMonitor = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "环境氧监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Huanjingo2Monitor = true;
            else
                configinidata.Huanjingo2Monitor = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "残余量监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.RemainedMonitor = true;
            else
                configinidata.RemainedMonitor = false;


            ini.INIIO.GetPrivateProfileString("VMAS", "是否调零", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfFqyTl = true;
            else
                configinidata.IfFqyTl = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "是否反吹", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Flowback = true;
            else
                configinidata.Flowback = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "是否确认温湿度", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfSureTemp = true;
            else
                configinidata.IfSureTemp = false;
            ini.INIIO.GetPrivateProfileString("VMAS", "是否显示过程数据", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfDisplayData = true;
            else
                configinidata.IfDisplayData = false;

            ini.INIIO.GetPrivateProfileString("VMAS", "浓度值", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Ndz = a;
            else
                configinidata.Ndz = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "流量计流量值", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Lljll = a;
            else
                configinidata.Lljll = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "尾气流量值", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Wqll = a;
            else
                configinidata.Wqll = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "稀释比", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Xsb = a;
            else
                configinidata.Xsb = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "功率加载", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Gljz = a;
            else
                configinidata.Gljz = 3f;

            ini.INIIO.GetPrivateProfileString("VMAS", "连续超差", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Lxcc = a;
            else
                configinidata.Lxcc = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "累计超差", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Ljcc = a;
            else
                configinidata.Ljcc = 3f;
            ini.INIIO.GetPrivateProfileString("VMAS", "怠速时间", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Dssj = b;
            else
                configinidata.Dssj = 40;
            ini.INIIO.GetPrivateProfileString("VMAS", "反吹时间", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.FlowTime = b;
            else
                configinidata.FlowTime = 30;
            return configinidata;
        }

        public bool writeVmasConfigIni(VmasConfigInfdata configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("VMAS", "速度监测", configinidata.SpeedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "加载功率监测", configinidata.PowerMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "浓度监测", configinidata.ConcentrationMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "流量监测", configinidata.FlowMonitorr.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "稀释比监测", configinidata.ThinnerratioMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "环境氧监测", configinidata.Huanjingo2Monitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "残余量监测", configinidata.RemainedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("VMAS", "是否反吹", configinidata.Flowback.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "是否调零", configinidata.IfFqyTl.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "是否确认温湿度", configinidata.IfSureTemp.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "是否显示过程数据", configinidata.IfDisplayData.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("VMAS", "浓度值", configinidata.Ndz.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "流量计流量值", configinidata.Lljll.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "尾气流量值", configinidata.Wqll.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "稀释比", configinidata.Xsb.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "功率加载", configinidata.Gljz.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "连续超差", configinidata.Lxcc.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "累计超差", configinidata.Ljcc.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "怠速时间", configinidata.Dssj.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("VMAS", "反吹时间", configinidata.FlowTime.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");

                return true;
            }
            catch
            {
                return false;
            }
        }
        public AsmConfigInfdata getAsmConfigIni()
        {
            float a = 0;
            int b = 0;
            AsmConfigInfdata configinidata = new AsmConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("ASM", "速度监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.SpeedMonitor = true;
            else
                configinidata.SpeedMonitor = false;
            ini.INIIO.GetPrivateProfileString("ASM", "加载功率监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.PowerMonitor = true;
            else
                configinidata.PowerMonitor = false;
            ini.INIIO.GetPrivateProfileString("ASM", "浓度监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.ConcentrationMonitor = true;
            else
                configinidata.ConcentrationMonitor = false;

            ini.INIIO.GetPrivateProfileString("ASM", "残余量监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.RemainedMonitor = true;
            else
                configinidata.RemainedMonitor = false;


            ini.INIIO.GetPrivateProfileString("ASM", "是否调零", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfFqyTl = true;
            else
                configinidata.IfFqyTl = false;
            ini.INIIO.GetPrivateProfileString("ASM", "是否反吹", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Flowback = true;
            else
                configinidata.Flowback = false;
            ini.INIIO.GetPrivateProfileString("ASM", "是否确认温湿度", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfSureTemp = true;
            else
                configinidata.IfSureTemp = false;
            ini.INIIO.GetPrivateProfileString("ASM", "是否显示过程数据", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfDisplayData = true;
            else
                configinidata.IfDisplayData = false;

            ini.INIIO.GetPrivateProfileString("ASM", "浓度值", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Ndz = a;
            else
                configinidata.Ndz = 3f;

            ini.INIIO.GetPrivateProfileString("ASM", "功率加载", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Gljz = a;
            else
                configinidata.Gljz = 3f;

            ini.INIIO.GetPrivateProfileString("ASM", "连续超差", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Lxcc = a;
            else
                configinidata.Lxcc = 3f;

            ini.INIIO.GetPrivateProfileString("ASM", "反吹时间", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.FlowTime = b;
            else
                configinidata.FlowTime = 30;
            return configinidata;
        }

        public bool writeAsmConfigIni(AsmConfigInfdata configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("ASM", "速度监测", configinidata.SpeedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "加载功率监测", configinidata.PowerMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "浓度监测", configinidata.ConcentrationMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "残余量监测", configinidata.RemainedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("ASM", "是否反吹", configinidata.Flowback.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "是否调零", configinidata.IfFqyTl.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "是否确认温湿度", configinidata.IfSureTemp.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "是否显示过程数据", configinidata.IfDisplayData.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("ASM", "浓度值", configinidata.Ndz.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "功率加载", configinidata.Gljz.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "连续超差", configinidata.Lxcc.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("ASM", "反吹时间", configinidata.FlowTime.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public SdsConfigInfdata getSdsConfigIni()
        {
            float a = 0;
            int b = 0;
            SdsConfigInfdata configinidata = new SdsConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("SDS", "转速监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.RotateSpeedMonitor = true;
            else
                configinidata.RotateSpeedMonitor = false;
            ini.INIIO.GetPrivateProfileString("SDS", "浓度监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.ConcentrationMonitor = true;
            else
                configinidata.ConcentrationMonitor = false;

            ini.INIIO.GetPrivateProfileString("SDS", "是否调零", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfFqyTl = true;
            else
                configinidata.IfFqyTl = false;
            ini.INIIO.GetPrivateProfileString("SDS", "是否反吹", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.Flowback = true;
            else
                configinidata.Flowback = false;

            ini.INIIO.GetPrivateProfileString("SDS", "浓度值", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Ndz = a;
            else
                configinidata.Ndz = 3f;

            ini.INIIO.GetPrivateProfileString("SDS", "转速超差", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Zscc = b;
            else
                configinidata.Zscc = 100;

            ini.INIIO.GetPrivateProfileString("SDS", "反吹时间", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.FlowTime = b;
            else
                configinidata.FlowTime = 30;

            ini.INIIO.GetPrivateProfileString("SDS", "转速计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsj = temp.ToString();

            ini.INIIO.GetPrivateProfileString("SDS", "转速计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsjck = temp.ToString();
            return configinidata;
        }

        public bool writeSdsConfigIni(SdsConfigInfdata configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("SDS", "转速监测", configinidata.RotateSpeedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "浓度监测", configinidata.ConcentrationMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("SDS", "是否反吹", configinidata.Flowback.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "是否调零", configinidata.IfFqyTl.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");

                ini.INIIO.WritePrivateProfileString("SDS", "浓度值", configinidata.Ndz.ToString("0.0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "转速超差", configinidata.Zscc.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "反吹时间", configinidata.FlowTime.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "转速计", configinidata.Zsj, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("SDS", "转速计串口", configinidata.Zsjck, @"D:\环保检测子程序\detectConfig.ini");

                return true;
            }
            catch
            {
                return false;
            }
        }
        public BtgConfigInfdata getBtgConfigIni()
        {
            float a = 0;
            int b = 0;
            BtgConfigInfdata configinidata = new BtgConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("BTG", "转速监测", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.RotateSpeedMonitor = true;
            else
                configinidata.RotateSpeedMonitor = false;


            ini.INIIO.GetPrivateProfileString("BTG", "断油转速", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Dyzs = b;
            else
                configinidata.Dyzs = 100;

            ini.INIIO.GetPrivateProfileString("BTG", "转速计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsj = temp.ToString();

            ini.INIIO.GetPrivateProfileString("BTG", "转速计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsjck = temp.ToString();
            return configinidata;
        }

        public bool writeBtgConfigIni(BtgConfigInfdata configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("BTG", "转速监测", configinidata.RotateSpeedMonitor.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("BTG", "断油转速", configinidata.Dyzs.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("BTG", "转速计", configinidata.Zsj, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("BTG", "转速计串口", configinidata.Zsjck, @"D:\环保检测子程序\detectConfig.ini");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public LugdownConfigInfdata getLugdownConfigIni()
        {
            float a = 0;
            int b = 0;
            LugdownConfigInfdata configinidata = new LugdownConfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("LUGDOWN", "扫描最低速度", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.MinSpeed = b;
            else
                configinidata.MinSpeed = 50;

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "是否确认温湿度", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (temp.ToString().Trim() == "true")
                configinidata.IfSureTemp = true;
            else
                configinidata.IfSureTemp = false;

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "扫描最高速度", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.MaxSpeed = b;
            else
                configinidata.MaxSpeed = 100;

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "转速计", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsj = temp.ToString();

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "转速计串口", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Zsjck = temp.ToString();

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "功率扫描模式", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            configinidata.Glsmms = temp.ToString();

            ini.INIIO.GetPrivateProfileString("LUGDOWN", "扫描频率", "", temp, 2048, @"D:\环保检测子程序\detectConfig.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                configinidata.Smpl = a;
            else
                configinidata.Smpl = 100f;
            return configinidata;
        }

        public bool writeLugdownConfigIni(LugdownConfigInfdata configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "扫描最低速度", configinidata.MinSpeed.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "扫描最高速度", configinidata.MaxSpeed.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "是否确认温湿度", configinidata.IfSureTemp.ToString().ToLower(), @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "转速计", configinidata.Zsj, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "转速计串口", configinidata.Zsjck, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "功率扫描模式", configinidata.Glsmms, @"D:\环保检测子程序\detectConfig.ini");
                ini.INIIO.WritePrivateProfileString("LUGDOWN", "扫描频率", configinidata.Smpl.ToString("0"), @"D:\环保检测子程序\detectConfig.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public captureConfigData getCameraConfigIni()
        {
            int b = 0;
            captureConfigData configinidata = new captureConfigData();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "captureMethod", "1", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.captureMethod = b;
            else
                configinidata.captureMethod = 1;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRIP", "", temp, 2048, @".\appConfig.ini");
            configinidata.NVRIP = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRPORT", "9008", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.NVRPORT = b;
            else
                configinidata.NVRPORT = 9008;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRUSER", "", temp, 2048, @".\appConfig.ini");
            configinidata.NVRUSER = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRPASSWORD", "", temp, 2048, @".\appConfig.ini");
            configinidata.NVRPASSWORD = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRFRONTCHANEL", "1", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.NVRFRONTCHANEL = b;
            else
                configinidata.NVRFRONTCHANEL = 1;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "NVRBACKCHANEL", "2", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.NVRBACKCHANEL = b;
            else
                configinidata.NVRBACKCHANEL = 2;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERAFRONTIP", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERAFRONTIP = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERAFRONTPORT", "9008", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.CAMERAFRONTPORT = b;
            else
                configinidata.CAMERAFRONTPORT = 9008;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERAFRONTUSER", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERAFRONTUSER = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERAFRONTPASSWORD", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERAFRONTPASSWORD = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERABACKIP", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERABACKIP = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERABACKPORT", "9008", temp, 2048, @".\appConfig.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.CAMERABACKPORT = b;
            else
                configinidata.CAMERABACKPORT = 9008;
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERABACKUSER", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERABACKUSER = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "CAMERABACKPASSWORD", "", temp, 2048, @".\appConfig.ini");
            configinidata.CAMERABACKPASSWORD = temp.ToString();
            ini.INIIO.GetPrivateProfileString("摄像头参数", "ENABLEFRONT", "N", temp, 2048, @".\appConfig.ini");
            configinidata.ENABLEFRONT = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "ENABLEBACK", "N", temp, 2048, @".\appConfig.ini");
            configinidata.ENABLEBACK = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "VMAS_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_vmas_start = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "VMAS_15", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_vmas_15 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "VMAS_32", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_vmas_32 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "VMAS_50", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_vmas_50 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "ASM_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_asm_start = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "ASM_5025", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_asm_5025 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "ASM_2540", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_asm_2540 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "SDS_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_sds_start = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "SDS_HIGH", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_sds_high = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "SDS_LOW", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_sds_low = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "LUGDOWN_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_lugdown_start = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "LUGDOWN_100", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_lugdown_100 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "LUGDOWN_90", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_lugdown_90 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "LUGDOWN_80", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_lugdown_80 = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "BTG_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_btg_start = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "BTG_FIRST", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_btg_first = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "BTG_SECOND", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_btg_second = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "BTG_THIRD", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_btg_third = temp.ToString() == "Y";
            ini.INIIO.GetPrivateProfileString("摄像头参数", "XN_START", "N", temp, 2048, @".\appConfig.ini");
            configinidata.cap_xn_start = temp.ToString() == "Y";
            return configinidata;
        }
        public bool writeCameraConfigIni(captureConfigData configinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("摄像头参数", "captureMethod", configinidata.captureMethod.ToString("0"), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRIP", configinidata.NVRIP, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRPORT", configinidata.NVRPORT.ToString(), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRUSER", configinidata.NVRUSER, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRPASSWORD", configinidata.NVRPASSWORD, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRFRONTCHANEL", configinidata.NVRFRONTCHANEL.ToString(), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "NVRBACKCHANEL", configinidata.NVRBACKCHANEL.ToString(), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERAFRONTIP", configinidata.CAMERAFRONTIP, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERAFRONTPORT", configinidata.CAMERAFRONTPORT.ToString(), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERAFRONTUSER", configinidata.CAMERAFRONTUSER, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERAFRONTPASSWORD", configinidata.CAMERAFRONTPASSWORD, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERABACKIP", configinidata.CAMERABACKIP, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERABACKPORT", configinidata.CAMERABACKPORT.ToString(), @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERABACKUSER", configinidata.CAMERABACKUSER, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "CAMERABACKPASSWORD", configinidata.CAMERABACKPASSWORD, @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "ENABLEFRONT", configinidata.ENABLEFRONT ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "ENABLEBACK", configinidata.ENABLEBACK ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "VMAS_START", configinidata.cap_vmas_start ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "VMAS_15", configinidata.cap_vmas_15 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "VMAS_32", configinidata.cap_vmas_32 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "VMAS_50", configinidata.cap_vmas_50 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "ASM_START", configinidata.cap_asm_start ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "ASM_5025", configinidata.cap_asm_5025 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "ASM_2540", configinidata.cap_asm_2540 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "SDS_START", configinidata.cap_sds_start ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "SDS_HIGH", configinidata.cap_sds_high ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "SDS_LOW", configinidata.cap_sds_low ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "LUGDOWN_START", configinidata.cap_lugdown_start ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "LUGDOWN_100", configinidata.cap_lugdown_100 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "LUGDOWN_90", configinidata.cap_lugdown_90 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "LUGDOWN_80", configinidata.cap_lugdown_80 ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "BTG_START", configinidata.cap_btg_start ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "BTG_FIRST", configinidata.cap_btg_first ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "BTG_SECOND", configinidata.cap_btg_second ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "BTG_THIRD", configinidata.cap_btg_third ? "Y" : "N", @".\appConfig.ini");
                ini.INIIO.WritePrivateProfileString("摄像头参数", "XN_START", configinidata.cap_xn_start ? "Y" : "N", @".\appConfig.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
