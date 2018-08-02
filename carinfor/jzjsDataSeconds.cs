using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carinfor
{
    public class jzjsDataSeconds
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
        private string[] qcsx=new string[1024];//全程时序

        public string[] Qcsx
        {
            get { return qcsx; }
            set { qcsx = value; }
        }
        private string[] sxnb=new string[1024];//时序类别

        public string[] Sxnb
        {
            get { return sxnb; }
            set { sxnb = value; }
        }
        private int[] cysx = new int[1024];//采样时序

        public int[] Cysx
        {
            get { return cysx; }
            set { cysx = value; }
        }
        private float[] cs = new float[1024];//车速

        public float[] Cs
        {
            get { return cs; }
            set { cs = value; }
        }
        private float[] gl = new float[1024];//功率

        public float[] Gl
        {
            get { return gl; }
            set { gl = value; }
        }
        private float[] gxsxs = new float[1024];//光吸收系数

        public float[] Gxsxs
        {
            get { return gxsxs; }
            set { gxsxs = value; }
        }
        private float[] no = new float[1024];
        public float[] NO
        {
            get { return no; }
            set { no = value; }
        }
    }
    public class jzjsDataSecondsControl
    {
        CSVcontrol.CSVHelper jzjs_csv = null;
        public bool writeJzjsDataSeconds(jzjsDataSeconds jzjsdataseconds)
        {
            try
            {
                init_csv(jzjsdataseconds.CarID);
                jzjs_csv.openCsv();
                for (int i = 1; i < jzjsdataseconds.Gksj; i++)
                {
                    jzjs_csv.writeField(i+1, 1, jzjsdataseconds.Qcsx[i - 1]);
                    jzjs_csv.writeField(i + 1, 2, jzjsdataseconds.Sxnb[i - 1]);
                    jzjs_csv.writeField(i + 1, 3, jzjsdataseconds.Cysx[i - 1].ToString("0"));
                    jzjs_csv.writeField(i + 1, 4, jzjsdataseconds.Cs[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 5, jzjsdataseconds.Gl[i - 1].ToString("0.00"));
                    jzjs_csv.writeField(i + 1, 6, jzjsdataseconds.Gxsxs[i - 1].ToString("0.00"));
                    
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
            jzjs_csv.writeField(1, 4, "车速");
            jzjs_csv.writeField(1, 5, "功率");
            jzjs_csv.writeField(1, 6, "光吸收系数K");
            jzjs_csv.closeCsv();
        }
    }
}
