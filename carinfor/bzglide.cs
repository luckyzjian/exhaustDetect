using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class bzglide
    {
        private string hxqj;

        public string Hxqj
        {
            get { return hxqj; }
            set { hxqj = value; }
        }
        private string ccdt;

        public string Ccdt
        {
            get { return ccdt; }
            set { ccdt = value; }
        }
        private string acdt;

        public string Acdt
        {
            get { return acdt; }
            set { acdt = value; }
        }
        private string wc;

        public string Wc
        {
            get { return wc; }
            set { wc = value; }
        }
        
        private string bzsm;

        public string Bzsm
        {
            get { return bzsm; }
            set { bzsm = value; }
        }
        private string bdjg;

        public string Bdjg
        {
            get { return bdjg; }
            set { bdjg = value; }
        }
    }
    public class bzglideControl
    {
        public bool writeBzGlideIni(bzglide glidedata)
        {
            try
            {
                if (File.Exists("C:/jcdatatxt/BzGlide.ini"))
                {
                    File.Delete("C:/jcdatatxt/BzGlide.ini");
                }
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("标定数据", "滑行区间", glidedata.Hxqj, "C:/jcdatatxt/BzGlide.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "CCDT", glidedata.Ccdt, "C:/jcdatatxt/BzGlide.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "ACDT", glidedata.Acdt, "C:/jcdatatxt/BzGlide.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "误差", glidedata.Wc, "C:/jcdatatxt/BzGlide.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "备注说明", glidedata.Bzsm, "C:/jcdatatxt/BzGlide.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标定结果", glidedata.Bdjg, "C:/jcdatatxt/BzGlide.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bzglide readAnalysisMeterData(string filePath)
        {
            bzglide vmas_data = new bzglide();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("标定数据", "滑行区间", "", temp, 2048, filePath);//、
                    vmas_data.Hxqj = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "CCDT", "", temp, 2048, filePath);
                    vmas_data.Ccdt = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "ACDT", "", temp, 2048, filePath);
                    vmas_data.Acdt = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "误差", "", temp, 2048, filePath);
                    vmas_data.Wc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "备注说明", "", temp, 2048, filePath);
                    vmas_data.Bzsm = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "标定结果", "", temp, 2048, filePath);
                    vmas_data.Bdjg =temp.ToString();
                }
                else
                {
                    vmas_data.Bdjg = "-1";
                }
                return vmas_data;
            }
            catch
            {
                vmas_data.Bdjg = "-1";
                return vmas_data;
            }
        }
    }
}
