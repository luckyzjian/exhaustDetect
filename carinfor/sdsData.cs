using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace carinfor
{
    public class sdsdata
    {
        private string carID;

        public string CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private string sd;

        public string Sd
        {
            get { return sd; }
            set { sd = value; }
        }
        private string wd;

        public string Wd
        {
            get { return wd; }
            set { wd = value; }
        }
        private string dqy;

        public string Dqy
        {
            get { return dqy; }
            set { dqy = value; }
        }
        private string λ;

        public string λ_value
        {
            get { return λ; }
            set { λ = value; }
        }
        private string co_low;

        public string Co_low
        {
            get { return co_low; }
            set { co_low = value; }
        }
        private string hc_low;

        public string Hc_low
        {
            get { return hc_low; }
            set { hc_low = value; }
        }
        private string co_high;

        public string Co_high
        {
            get { return co_high; }
            set { co_high = value; }
        }
        private string hc_high;

        public string Hc_high
        {
            get { return hc_high; }
            set { hc_high = value; }
        }
        private string co2_high;

        public string Co2_high
        {
            get { return co2_high; }
            set { co2_high = value; }
        }
        private string o2_high;

        public string O2_high
        {
            get { return o2_high; }
            set { o2_high = value; }
        }
        private string co2_low;

        public string Co2_low
        {
            get { return co2_low; }
            set { co2_low = value; }
        }
        private string o2_low;

        public string O2_low
        {
            get { return o2_low; }
            set { o2_low = value; }
        }
        private string crucialTime0;
        private string crucialTime1;
        private string crucialTime2;
        private string crucialTime3;
        private string ambientHC;
        private string ambientCO;
        private string ambientNO;
        private string residualHC;
        public string CrucialTime0
        {
            get
            {
                return crucialTime0;
            }

            set
            {
                crucialTime0 = value;
            }
        }

        public string CrucialTime1
        {
            get
            {
                return crucialTime1;
            }

            set
            {
                crucialTime1 = value;
            }
        }

        public string CrucialTime2
        {
            get
            {
                return crucialTime2;
            }

            set
            {
                crucialTime2 = value;
            }
        }

        public string CrucialTime3
        {
            get
            {
                return crucialTime3;
            }

            set
            {
                crucialTime3 = value;
            }
        }

        public string AmbientHC
        {
            get
            {
                return ambientHC;
            }

            set
            {
                ambientHC = value;
            }
        }

        public string AmbientCO
        {
            get
            {
                return ambientCO;
            }

            set
            {
                ambientCO = value;
            }
        }

        public string AmbientNO
        {
            get
            {
                return ambientNO;
            }

            set
            {
                ambientNO = value;
            }
        }

        public string ResidualHC
        {
            get
            {
                return residualHC;
            }

            set
            {
                residualHC = value;
            }
        }
        private string testStartTime;
        private string testEndTime;

        public string TestStartTime
        {
            get
            {
                return testStartTime;
            }

            set
            {
                testStartTime = value;
            }
        }

        public string TestEndTime
        {
            get
            {
                return testEndTime;
            }

            set
            {
                testEndTime = value;
            }
        }

        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string stopReason;

        public string StopReason
        {
            get { return stopReason; }
            set { stopReason = value; }
        }
    }
    public class sdsdataControl
    {
        public bool writeSdsData(sdsdata sds_data)
        {

            try
            {
                if (File.Exists("C:/jcdatatxt/" + sds_data.CarID + ".ini"))
                {
                    File.Delete("C:/jcdatatxt/" + sds_data.CarID + ".ini");
                }
                ini.INIIO.WritePrivateProfileString("检测结果", "车辆ID", sds_data.CarID, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "相对湿度", sds_data.Sd, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "环境温度", sds_data.Wd, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "大气压力", sds_data.Dqy, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值1", sds_data.λ_value, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值2", sds_data.Co_low, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值3", sds_data.Hc_low, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值4", sds_data.Co_high, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值5", sds_data.Hc_high, "C:/jcdatatxt/" + sds_data.CarID + ".ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public sdsdata readSdsData(string filePath)
        {
            sdsdata sds_data = new sdsdata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("检测结果", "车辆ID", "", temp, 2048, filePath);
                    sds_data.CarID = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "相对湿度", "", temp, 2048, filePath);
                    sds_data.Sd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "环境温度", "", temp, 2048, filePath);
                    sds_data.Wd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "大气压力", "", temp, 2048, filePath);
                    sds_data.Dqy = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值1", "", temp, 2048, filePath);
                    sds_data.λ_value = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值2", "", temp, 2048, filePath);
                    sds_data.Co_low = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值3", "", temp, 2048, filePath);
                    sds_data.Hc_low = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值4", "", temp, 2048, filePath);
                    sds_data.Co_high = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值5", "", temp, 2048, filePath);
                    sds_data.Hc_high = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CO2HIGH", "", temp, 2048, filePath);
                    sds_data.Co2_high = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "O2HIGH", "", temp, 2048, filePath);
                    sds_data.O2_high = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CO2LOW", "", temp, 2048, filePath);
                    sds_data.Co2_low = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "O2LOW", "", temp, 2048, filePath);
                    sds_data.O2_low = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime0", "", temp, 2048, filePath);
                    sds_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime1", "", temp, 2048, filePath);
                    sds_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime2", "", temp, 2048, filePath);
                    sds_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime3", "", temp, 2048, filePath);
                    sds_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "AmbientCO", "0", temp, 2048, filePath);
                    sds_data.AmbientCO = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "AmbientHC", "0", temp, 2048, filePath);
                    sds_data.AmbientHC = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "AmbientNO", "0", temp, 2048, filePath);
                    sds_data.AmbientNO = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "ResidualHC", "0", temp, 2048, filePath);
                    sds_data.ResidualHC = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "TestStartTime", "", temp, 2048, filePath);
                    sds_data.TestStartTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "TestEndTime", "", temp, 2048, filePath);
                    sds_data.TestEndTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StartTime", "", temp, 2048, filePath);
                    sds_data.StartTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StopReason", "", temp, 2048, filePath);
                    sds_data.StopReason = temp.ToString();
                }
                else
                {
                    sds_data.CarID = "-1";
                }
                return sds_data;
            }
            catch
            {
                sds_data.CarID = "-1";
                return sds_data;
            }
        }
    }
}
