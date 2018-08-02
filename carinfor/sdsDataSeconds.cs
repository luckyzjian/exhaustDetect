using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carinfor
{
    public class sdsDataSeconds
    {
        private string carID;//车辆ID

        public string CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private int gksj;

        public int Gksj
        {
            get { return gksj; }
            set { gksj = value; }
        }
        private string[] qcsx=new string[1000];//全程时序

        public string[] Qcsx
        {
            get { return qcsx; }
            set { qcsx = value; }
        }
        private string[] sxnb = new string[1000];//时序类别

        public string[] Sxnb
        {
            get { return sxnb; }
            set { sxnb = value; }
        }
        private int[] cysx = new int[1000];//采样时序

        public int[] Cysx
        {
            get { return cysx; }
            set { cysx = value; }
        }
        private float[] hc = new float[1000];//HC

        public float[] Hc
        {
            get { return hc; }
            set { hc = value; }
        }
        private float[] co = new float[1000];//CO

        public float[] Co
        {
            get { return co; }
            set { co = value; }
        }
        private float[] o2 = new float[1000];//O2

        public float[] O2
        {
            get { return o2; }
            set { o2 = value; }
        }
        private float[] co2 = new float[1000];//CO2

        public float[] Co2
        {
            get { return co2; }
            set { co2 = value; }
        }
        private float[] λ = new float[1000];//过量空气系数

        public float[] Λ
        {
            get { return λ; }
            set { λ = value; }
        }
        private float[] zs = new float[1000];//转速

        public float[] Zs
        {
            get { return zs; }
            set { zs = value; }
        }
        private float[] yw = new float[1000];//油温

        public float[] Yw
        {
            get { return yw; }
            set { yw = value; }
        }
        private float[] wd = new float[1000];//温度

        public float[] Wd
        {
            get { return wd; }
            set { wd = value; }
        }
        private float[] sd = new float[1000];//湿度

        public float[] Sd
        {
            get { return sd; }
            set { sd = value; }
        }
        private float[] dqy = new float[1000];//大气压

        public float[] Dqy
        {
            get { return dqy; }
            set { dqy = value; }
        }
    }
    public class sdsDataSecondsControl
    {
        CSVcontrol.CSVHelper jzjs_csv = null;
        public bool writeSdsDataSeconds(sdsDataSeconds sdsdataseconds)
        {
            try
            {
                init_csv(sdsdataseconds.CarID);
                jzjs_csv.openCsv();
                for (int i = 1; i < sdsdataseconds.Gksj; i++)
                {
                    jzjs_csv.writeField(i+1, 1, sdsdataseconds.Qcsx[i - 1]);
                    jzjs_csv.writeField(i + 1, 2, sdsdataseconds.Sxnb[i - 1]);
                    jzjs_csv.writeField(i + 1, 3, sdsdataseconds.Cysx[i - 1].ToString("0"));
                    jzjs_csv.writeField(i + 1, 4, sdsdataseconds.Hc[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 5, sdsdataseconds.Co[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 6, sdsdataseconds.O2[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 7, sdsdataseconds.Co2[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 8, sdsdataseconds.Λ[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 9, sdsdataseconds.Zs[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 10, sdsdataseconds.Yw[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 11, sdsdataseconds.Wd[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 12, sdsdataseconds.Sd[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 13, sdsdataseconds.Dqy[i - 1].ToString("0.00"));
                    
                }
                jzjs_csv.closeCsv();
                return true;
            }
            catch
            {
                return false;
            }

        }
        private void init_csv(string carID)
        {
            jzjs_csv = new CSVcontrol.CSVHelper();
            jzjs_csv.CreateCsv(@"C:\jcdatatxt\" + carID + ".csv");
            jzjs_csv.openCsv();
            jzjs_csv.writeField(1, 1, "全程时序");
            jzjs_csv.writeField(1, 2, "时序类别");
            jzjs_csv.writeField(1, 3, "采样时序");
            jzjs_csv.writeField(1, 4, "HC");
            jzjs_csv.writeField(1, 5, "CO");
            jzjs_csv.writeField(1, 6, "O2");
            jzjs_csv.writeField(1, 7, "CO2");
            jzjs_csv.writeField(1, 8, "过量空气系数");
            jzjs_csv.writeField(1, 9, "转速");
            jzjs_csv.writeField(1, 10, "油温");
            jzjs_csv.writeField(1,11, "环境温度");
            jzjs_csv.writeField(1,12, "相对湿度");
            jzjs_csv.writeField(1, 13, "大气压力");
            jzjs_csv.closeCsv();
        }
    }
}
