using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ini;
using System.IO;

namespace carinfor
{
    public class Flowmeterdata
    {
        private float o2glcbz;

        public float O2glcbz
        {
            get { return o2glcbz; }
            set { o2glcbz = value; }
        }

        private float o2glcclz;

        public float O2glcclz
        {
            get { return o2glcclz; }
            set { o2glcclz = value; }
        }
        private float o2glcwc;

        public float O2glcwc
        {
            get { return o2glcwc; }
            set { o2glcwc = value; }
        }
        private float o2dlcbz;

        public float O2dlcbz
        {
            get { return o2dlcbz; }
            set { o2dlcbz = value; }
        }
        private float o2dlcclz;

        public float O2dlcclz
        {
            get { return o2dlcclz; }
            set { o2dlcclz = value; }
        }
        private float o2dlcwc;

        public float O2dlcwc
        {
            get { return o2dlcwc; }
            set { o2dlcwc = value; }
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
    public class flowmeterIni
    {
        public bool writeanalysismeterIni(Flowmeterdata flowmeterdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气高量程标值", flowmeterdata.O2glcbz.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气高量程测量值", flowmeterdata.O2glcclz.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气高量程误差", flowmeterdata.O2glcwc.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气低量程标值", flowmeterdata.O2dlcbz.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气低量程测量值", flowmeterdata.O2dlcclz.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "氧气低量程误差", flowmeterdata.O2dlcwc.ToString("0.00"), "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "备注说明", flowmeterdata.Bzsm, "C:/jcdatatxt/Flowmeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标定结果", flowmeterdata.Bdjg, "C:/jcdatatxt/Flowmeter.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Flowmeterdata readFlowMeterData(string filePath)
        {
            Flowmeterdata vmas_data = new Flowmeterdata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气高量程标值", "", temp, 2048, filePath);//、
                    vmas_data.O2glcbz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气高量程测量值", "", temp, 2048, filePath);
                    vmas_data.O2glcclz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气高量程误差", "", temp, 2048, filePath);
                    vmas_data.O2glcwc = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气低量程标值", "", temp, 2048, filePath);
                    vmas_data.O2dlcbz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气低量程测量值", "", temp, 2048, filePath);
                    vmas_data.O2dlcclz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "氧气低量程误差", "", temp, 2048, filePath);
                    vmas_data.O2dlcwc = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "备注说明", "", temp, 2048, filePath);
                    vmas_data.Bzsm = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "标定结果", "", temp, 2048, filePath);
                    vmas_data.Bdjg = temp.ToString();
                    
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
