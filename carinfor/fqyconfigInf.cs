using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carinfor
{
    public class fqyconfigInfdata
    {
        private float co_high;

        public float Co_high
        {
            get { return co_high; }
            set { co_high = value; }
        }
        private float co2_high;

        public float Co2_high
        {
            get { return co2_high; }
            set { co2_high = value; }
        }
        private float hc_high;

        public float Hc_high
        {
            get { return hc_high; }
            set { hc_high = value; }
        }
        private float no_high;

        public float No_high
        {
            get { return no_high; }
            set { no_high = value; }
        }
        private float o2_high;

        public float O2_high
        {
            get { return o2_high; }
            set { o2_high = value; }
        }
        private float co_low;

        public float Co_low
        {
            get { return co_low; }
            set { co_low = value; }
        }
        private float co2_low;

        public float Co2_low
        {
            get { return co2_low; }
            set { co2_low = value; }
        }
        private float hc_low;

        public float Hc_low
        {
            get { return hc_low; }
            set { hc_low = value; }
        }
        private float no_low;

        public float No_low
        {
            get { return no_low; }
            set { no_low = value; }
        }
        private float o2_low;

        public float O2_low
        {
            get { return o2_low; }
            set { o2_low = value; }
        }
        private float co_zero;

        public float Co_zero
        {
            get { return co_zero; }
            set { co_zero = value; }
        }
        private float co2_zero;

        public float Co2_zero
        {
            get { return co2_zero; }
            set { co2_zero = value; }
        }
        private float hc_zero;

        public float Hc_zero
        {
            get { return hc_zero; }
            set { hc_zero = value; }
        }
        private float no_zero;

        public float No_zero
        {
            get { return no_zero; }
            set { no_zero = value; }
        }
        private float o2_zero;

        public float O2_zero
        {
            get { return o2_zero; }
            set { o2_zero = value; }
        }

    }
    public class fqyconfigIni
    {
        public fqyconfigInfdata getfqyConfigIni()
        {
            float a = 0;
            int b = 0;
            fqyconfigInfdata fqyconfiginidata = new fqyconfigInfdata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "高标气CO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co_high = a;
            else
                fqyconfiginidata.Co_high = 8.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "高标气CO2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co2_high = a;
            else
                fqyconfiginidata.Co2_high =12.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "高标气NO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.No_high = a;
            else
                fqyconfiginidata.No_high = 3000.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "高标气HC", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Hc_high = a;
            else
                fqyconfiginidata.Hc_high = 3200.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "高标气O2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.O2_high = a;
            else
                fqyconfiginidata.O2_high = 0.0f;

            ini.INIIO.GetPrivateProfileString("废气仪标定", "低标气CO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co_low = a;
            else
                fqyconfiginidata.Co_low = 0.5f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "低标气CO2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co2_low = a;
            else
                fqyconfiginidata.Co2_low = 3.6f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "低标气NO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.No_low = a;
            else
                fqyconfiginidata.No_low = 300.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "低标气HC", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Hc_low = a;
            else
                fqyconfiginidata.Hc_low = 200.0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "低标气O2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.O2_low = a;
            else
                fqyconfiginidata.O2_low = 0.0f;

            ini.INIIO.GetPrivateProfileString("废气仪标定", "零气CO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co_zero = a;
            else
                fqyconfiginidata.Co_zero = 0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "零气CO2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Co2_zero = a;
            else
                fqyconfiginidata.Co2_zero = 0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "零气NO", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.No_zero = a;
            else
                fqyconfiginidata.No_zero = 00f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "零气HC", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.Hc_zero = a;
            else
                fqyconfiginidata.Hc_zero = 0f;
            ini.INIIO.GetPrivateProfileString("废气仪标定", "零气O2", "", temp, 2048, @".\Config.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                fqyconfiginidata.O2_zero = a;
            else
                fqyconfiginidata.O2_zero = 20.9f;

            return fqyconfiginidata;
        }

    }
}
