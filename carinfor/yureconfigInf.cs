using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class yureconfigInfdata
    {
        private int fqytime;

        public int Fqytime
        {
            get { return fqytime; }
            set { fqytime = value; }
        }
        private int ydjtime;

        public int Ydjtime
        {
            get { return ydjtime; }
            set { ydjtime = value; }
        }
        private int lljtime;

        public int Lljtime
        {
            get { return lljtime; }
            set { lljtime = value; }
        }
        private int cgjtime;

        public int Cgjtime
        {
            get { return cgjtime; }
            set { cgjtime = value; }
        }

    }
    public class yureconfigIni
    {
        public yureconfigInfdata getConfigIni()
        {
            int b = 0;
            yureconfigInfdata configinidata = new yureconfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("预热时间", "废气仪", "", temp, 2048, @".\Config.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Fqytime = b;
            else
                configinidata.Fqytime = 60;
            ini.INIIO.GetPrivateProfileString("预热时间", "烟度计", "", temp, 2048, @".\Config.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Ydjtime = b;
            else
                configinidata.Ydjtime = 60;
            ini.INIIO.GetPrivateProfileString("预热时间", "流量计", "", temp, 2048, @".\Config.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Lljtime = b;
            else
                configinidata.Lljtime = 60;
            ini.INIIO.GetPrivateProfileString("预热时间", "测功机", "", temp, 2048, @".\Config.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                configinidata.Cgjtime = b;
            else
                configinidata.Cgjtime = 60;
            return configinidata;
        }
        public string readYureData(string filePath)
        {
            string yujg = "0";
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("PARAM", "Status", "", temp, 2048, filePath);//、
                    yujg = temp.ToString();
                }
                else
                {
                    yujg = "0";
                }
                return yujg;
            }
            catch
            {
                return "0";
            }
        }

    }
     
}
