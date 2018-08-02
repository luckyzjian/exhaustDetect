using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ini;
using System.IO;

namespace carinfor
{
    public class Smokemeterdata
    {
        private float kbz;

        public float Kbz
        {
            get { return kbz; }
            set { kbz = value; }
        }
        private float kscz;

        public float Kscz
        {
            get { return kscz; }
            set { kscz = value; }
        }
        private float kabswc;

        public float Kabswc
        {
            get { return kabswc; }
            set { kabswc = value; }
        }
        private float krelwc;

        public float Krelwc
        {
            get { return krelwc; }
            set { krelwc = value; }
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
    public class SmokemeterIni
    {
        public bool writeanalysismeterIni(Smokemeterdata flowmeterdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("标定数据", "K标定值", flowmeterdata.Kbz.ToString("0.00"), "C:/jcdatatxt/Smokemeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "K实测值", flowmeterdata.Kscz.ToString("0.00"), "C:/jcdatatxt/Smokemeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "K绝对误差", flowmeterdata.Kabswc.ToString("0.00"), "C:/jcdatatxt/Smokemeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "K相对误差", flowmeterdata.Krelwc.ToString("0.00"), "C:/jcdatatxt/Smokemeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "备注说明", flowmeterdata.Bzsm, "C:/jcdatatxt/Smokemeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标定结果", flowmeterdata.Bdjg, "C:/jcdatatxt/Smokemeter.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Smokemeterdata readAnalysisMeterData(string filePath)
        {
            Smokemeterdata vmas_data = new Smokemeterdata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("标定数据", "K标定值", "", temp, 2048, filePath);//、
                    vmas_data.Kbz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "K实测值", "", temp, 2048, filePath);
                    vmas_data.Kscz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "K绝对误差", "", temp, 2048, filePath);
                    vmas_data.Kabswc = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "K相对误差", "", temp, 2048, filePath);
                    vmas_data.Krelwc = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "备注说明", "", temp, 2048, filePath);
                    vmas_data.Bzsm =temp.ToString();
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
