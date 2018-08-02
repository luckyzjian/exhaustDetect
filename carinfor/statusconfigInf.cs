using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class statusconfigInfdata
    {
        private string ntype;

        public string nType
        {
            get { return ntype; }
            set { ntype = value; }
        }
        private string sjxl;

        public string SJXL
        {
            get { return sjxl; }
            set { sjxl = value; }
        }
        

    }
    public class statusconfigIni
    {
        public statusconfigInfdata getConfigIni()
        {
            int b = 0;
            statusconfigInfdata configinidata = new statusconfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("检测设备", "设备状态", "", temp, 2048, "C://jcdatatxt/statusConfig.ini");
            configinidata.nType =temp.ToString();
            ini.INIIO.GetPrivateProfileString("检测设备", "时间序列", "", temp, 2048, "C://jcdatatxt/statusConfig.ini");
            configinidata.SJXL = temp.ToString();            
            return configinidata;
        }
        public bool writeStatusData(statusconfigInfdata statusconfigdata)
        {
            try
            {
                if (File.Exists("C://jcdatatxt/statusConfig.ini"))
                {
                    File.Delete("C://jcdatatxt/statusConfig.ini");
                }
                ini.INIIO.WritePrivateProfileString("检测结果", "设备状态", statusconfigdata.nType, "C://jcdatatxt/statusConfig.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "时间序列", statusconfigdata.SJXL, "C://jcdatatxt/statusConfig.ini");
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public statusconfigInfdata getNeuConfigIni()
        {
            int b = 0;
            statusconfigInfdata configinidata = new statusconfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("检测设备", "设备状态", "", temp, 2048, "C://jcdatatxt/neustatusConfig.ini");
            configinidata.nType = temp.ToString();
            ini.INIIO.GetPrivateProfileString("检测设备", "时间序列", "", temp, 2048, "C://jcdatatxt/neustatusConfig.ini");
            configinidata.SJXL = temp.ToString();
            return configinidata;
        }
        public bool writeNeuStatusData(statusconfigInfdata statusconfigdata)
        {
            try
            {
                if (File.Exists("C://jcdatatxt/neustatusConfig.ini"))
                {
                    File.Delete("C://jcdatatxt/neustatusConfig.ini");
                }
                ini.INIIO.WritePrivateProfileString("检测结果", "设备状态", statusconfigdata.nType, "C://jcdatatxt/neustatusConfig.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "时间序列", statusconfigdata.SJXL, "C://jcdatatxt/neustatusConfig.ini");
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
     
}
