using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace carinfor
{
    public class zyjsBtgdata
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
        private string dszs;

        public string Dszs
        {
            get { return dszs; }
            set { dszs = value; }
        }
        private string firstData;

        public string FirstData
        {
            get { return firstData; }
            set { firstData = value; }
        }
        private string secondData;

        public string SecondData
        {
            get { return secondData; }
            set { secondData = value; }
        }
        private string thirdData;

        public string ThirdData
        {
            get { return thirdData; }
            set { thirdData = value; }
        }

        private string yw;
        public string Yw
        {
            get { return yw; }
            set { yw = value; }
        }

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
        private string crucialTime0;
        private string crucialTime1;
        private string crucialTime2;
        private string crucialTime3;
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

        private string smokeAvg;

        public string SmokeAvg
        {
            get { return smokeAvg; }
            set { smokeAvg = value; }
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
        public string PrepareData { set; get; }
        public string Rev1 { set; get; }
        public string Rev2 { set; get; }
        public string Rev3 { set; get; }

        public string prepareData1 { set; get; }
        public string prepareData2 { set; get; }
        public string prepareData3 { set; get; }
    }
    public class zyjsBtgdataControl
    {
        public bool writeJzjsData(zyjsBtgdata jzjs_data)
        {
            
            try
            {
                if (File.Exists("C:/jcdatatxt/" + jzjs_data.CarID + ".ini"))
                {
                    File.Delete("C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                }
                ini.INIIO.WritePrivateProfileString("检测结果", "车辆ID", jzjs_data.CarID, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "相对湿度", jzjs_data.Sd, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "环境温度", jzjs_data.Wd, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "大气压力", jzjs_data.Dqy, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值1", jzjs_data.Dszs, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值2", jzjs_data.FirstData, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值3", jzjs_data.SecondData, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值4", jzjs_data.ThirdData, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "数值5", jzjs_data.Yw, "C:/jcdatatxt/" + jzjs_data.CarID + ".ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public zyjsBtgdata readZyjsData(string filePath)
        {
            zyjsBtgdata zyjs_data = new zyjsBtgdata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("检测结果", "车辆ID", "", temp, 2048, filePath);
                    zyjs_data.CarID = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "相对湿度", "", temp, 2048, filePath);
                    zyjs_data.Sd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "环境温度", "", temp, 2048, filePath);
                    zyjs_data.Wd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "大气压力", "", temp, 2048, filePath);
                    zyjs_data.Dqy = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值1", "", temp, 2048, filePath);
                    zyjs_data.Dszs = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值2", "", temp, 2048, filePath);
                    zyjs_data.FirstData = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值3", "", temp, 2048, filePath);
                    zyjs_data.SecondData = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值4", "", temp, 2048, filePath);
                    zyjs_data.ThirdData = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值5", "", temp, 2048, filePath);
                    zyjs_data.Yw = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值6", "", temp, 2048, filePath);
                    zyjs_data.PrepareData = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime0", "", temp, 2048, filePath);
                    zyjs_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime1", "", temp, 2048, filePath);
                    zyjs_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime2", "", temp, 2048, filePath);
                    zyjs_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "CrucialTime3", "", temp, 2048, filePath);
                    zyjs_data.CrucialTime0 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "TestStartTime", "", temp, 2048, filePath);
                    zyjs_data.TestStartTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "TestEndTime", "", temp, 2048, filePath);
                    zyjs_data.TestEndTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StartTime", "", temp, 2048, filePath);
                    zyjs_data.StartTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StopReason", "", temp, 2048, filePath);
                    zyjs_data.StopReason = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "SmokeAvg", "", temp, 2048, filePath);
                    zyjs_data.SmokeAvg = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "Rev1", "", temp, 2048, filePath);
                    zyjs_data.Rev1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "Rev2", "", temp, 2048, filePath);
                    zyjs_data.Rev2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "Rev3", "", temp, 2048, filePath);
                    zyjs_data.Rev3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "prepareData1", "0.0", temp, 2048, filePath);
                    zyjs_data.prepareData1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "prepareData2", "0.0", temp, 2048, filePath);
                    zyjs_data.prepareData2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "prepareData3", "0.0", temp, 2048, filePath);
                    zyjs_data.prepareData3 = temp.ToString();
                }
                else
                {
                    zyjs_data.CarID = "-1";
                }
                return zyjs_data;
            }
            catch
            {
                zyjs_data.CarID = "-1";
                return zyjs_data;
            }
        }
    }
}
