﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ini;
using System.IO;

namespace carinfor
{
    public class analysismeterInidata
    {
        private float co2bz;//车辆ID

        public float Co2bz
        {
            get { return co2bz; }
            set { co2bz = value; }
        }
        private float co2clz;

        public float Co2clz
        {
            get { return co2clz; }
            set { co2clz = value; }
        }
        private float cobz;

        public float Cobz
        {
            get { return cobz; }
            set { cobz = value; }
        }
        private float coclz;

        public float Coclz
        {
            get { return coclz; }
            set { coclz = value; }
        }
        private float hcbz;

        public float Hcbz
        {
            get { return hcbz; }
            set { hcbz = value; }
        }
        private float hcclz;

        public float Hcclz
        {
            get { return hcclz; }
            set { hcclz = value; }
        }
        private float nobz;

        public float Nobz
        {
            get { return nobz; }
            set { nobz = value; }
        }
        private float noclz;

        public float Noclz
        {
            get { return noclz; }
            set { noclz = value; }
        }
        private int jzds;

        public int Jzds
        {
            get { return jzds; }
            set { jzds = value; }
        }
        private string gdjz;

        public string Gdjz
        {
            get { return gdjz; }
            set { gdjz = value; }
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

        public string Starttime
        {
            get
            {
                return starttime;
            }

            set
            {
                starttime = value;
            }
        }

        public string Pef
        {
            get
            {
                return pef;
            }

            set
            {
                pef = value;
            }
        }

        private string starttime;
        private string pef;

        public string c3h8 { set; get; }
        public string coabswc { set; get; }
        public string co2abswc { set; get; }
        public string hcabswc { set; get; }
        public string noabswc { set; get; }
        public string copc { set; get; }
        public string co2pc { set; get; }
        public string hcpc { set; get; }
        public string nopc { set; get; }
    }
    public class analysismeterIni
    {
        public bool writeanalysismeterIni(analysismeterInidata analysismeterdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("标定数据", "CO2标值", analysismeterdata.Co2bz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "CO2测量值", analysismeterdata.Co2clz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "CO标值", analysismeterdata.Cobz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "CO测量值", analysismeterdata.Coclz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "HC标值", analysismeterdata.Hcbz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "HC测量值", analysismeterdata.Hcclz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "NO标值", analysismeterdata.Nobz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "NO测量值", analysismeterdata.Noclz.ToString("0.00"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "校准点数", analysismeterdata.Jzds.ToString("0"), "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "高低校准", analysismeterdata.Gdjz, "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "备注说明", analysismeterdata.Bzsm, "C:/jcdatatxt/AnalysisMeter.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标定结果", analysismeterdata.Bdjg, "C:/jcdatatxt/AnalysisMeter.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public analysismeterInidata readAnalysisMeterData(string filePath)
        {
            analysismeterInidata vmas_data = new analysismeterInidata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO2标值", "", temp, 2048, filePath);//、
                    vmas_data.Co2bz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO2测量值", "", temp, 2048, filePath);
                    vmas_data.Co2clz = float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO标值", "", temp, 2048, filePath);
                    vmas_data.Cobz =  float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO测量值", "", temp, 2048, filePath);
                    vmas_data.Coclz =  float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "HC标值", "", temp, 2048, filePath);
                    vmas_data.Hcbz = float.Parse( temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "HC测量值", "", temp, 2048, filePath);
                    vmas_data.Hcclz = float.Parse( temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "NO标值", "", temp, 2048, filePath);
                    vmas_data.Nobz = float.Parse( temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "NO测量值", "", temp, 2048, filePath);
                    vmas_data.Noclz =  float.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "校准点数", "", temp, 2048, filePath);
                    vmas_data.Jzds = int.Parse(temp.ToString());
                    ini.INIIO.GetPrivateProfileString("标定数据", "高低校准", "", temp, 2048, filePath);
                    vmas_data.Gdjz = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "备注说明", "", temp, 2048, filePath);
                    vmas_data.Bzsm = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "标定结果", "", temp, 2048, filePath);
                    vmas_data.Bdjg = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "Pef", "", temp, 2048, filePath);
                    vmas_data.Pef = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "Starttime", "", temp, 2048, filePath);
                    vmas_data.Starttime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "c3h8", "", temp, 2048, filePath);
                    vmas_data.c3h8 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "coabswc", "", temp, 2048, filePath);
                    vmas_data.coabswc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "co2abswc", "", temp, 2048, filePath);
                    vmas_data.co2abswc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "hcabswc", "", temp, 2048, filePath);
                    vmas_data.hcabswc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "noabswc", "", temp, 2048, filePath);
                    vmas_data.noabswc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO偏差", "", temp, 2048, filePath);
                    vmas_data.copc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "CO2偏差", "", temp, 2048, filePath);
                    vmas_data.co2pc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "HC偏差", "", temp, 2048, filePath);
                    vmas_data.hcpc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "NO偏差", "", temp, 2048, filePath);
                    vmas_data.nopc = temp.ToString();
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
