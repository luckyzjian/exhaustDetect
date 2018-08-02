using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carinfor
{
    public class vmasDataSeconds
    {
        private string carID;

        public string CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private string[] qcsx=new string[210];//(YYYY-mm-DD HH:MM:SS)

        public string[] Qcsx
        {
            get { return qcsx; }
            set { qcsx = value; }
        }
        private string[] sxnb = new string[210];

        public string[] Sxnb
        {
            get { return sxnb; }
            set { sxnb = value; }
        }
        private int[] cysx = new int[210];

        public int[] Cysx
        {
            get { return cysx; }
            set { cysx = value; }
        }
        private float[] hcssz = new float[210];

        public float[] Hcssz
        {
            get { return hcssz; }
            set { hcssz = value; }
        }
        private float[] cossz = new float[210];

        public float[] Cossz
        {
            get { return cossz; }
            set { cossz = value; }
        }
        private float[] co2ssz = new float[210];

        public float[] Co2ssz
        {
            get { return co2ssz; }
            set { co2ssz = value; }
        }
        private float[] nossz = new float[210];

        public float[] Nossz
        {
            get { return nossz; }
            set { nossz = value; }
        }
        private float[] hjo2nd = new float[210];

        public float[] Hjo2nd
        {
            get { return hjo2nd; }
            set { hjo2nd = value; }
        }
        private float[] fxyo2ssz = new float[210];

        public float[] Fxyo2ssz
        {
            get { return fxyo2ssz; }
            set { fxyo2ssz = value; }
        }
        private float[] lljo2ssz = new float[210];

        public float[] Lljo2ssz
        {
            get { return lljo2ssz; }
            set { lljo2ssz = value; }
        }
        private float[] hcpfzl = new float[210];

        public float[] Hcpfzl
        {
            get { return hcpfzl; }
            set { hcpfzl = value; }
        }
        private float[] copfzl = new float[210];

        public float[] Copfzl
        {
            get { return copfzl; }
            set { copfzl = value; }
        }
        private float[] nopfzl = new float[210];

        public float[] Nopfzl
        {
            get { return nopfzl; }
            set { nopfzl = value; }
        }
        private float[] bzss= new float[210];

        public float[] Bzss
        {
            get { return bzss; }
            set { bzss = value; }
        }
        private float[] sscs= new float[210];

        public float[] Sscs
        {
            get { return sscs; }
            set { sscs = value; }
        }
        private float[] jzgl= new float[210];

        public float[] Jzgl
        {
            get { return jzgl; }
            set { jzgl = value; }
        }
        private float[] hjwd= new float[210];

        public float[] Hjwd
        {
            get { return hjwd; }
            set { hjwd = value; }
        }
        private float[] xdsd= new float[210];

        public float[] Xdsd
        {
            get { return xdsd; }
            set { xdsd = value; }
        }
        private float[] dqyl= new float[210];

        public float[] Dqyl
        {
            get { return dqyl; }
            set { dqyl = value; }
        }
        private float[] lljwd= new float[210];

        public float[] Lljwd
        {
            get { return lljwd; }
            set { lljwd = value; }
        }
        private float[] lljyl= new float[210];

        public float[] Lljyl
        {
            get { return lljyl; }
            set { lljyl = value; }
        }
        private float[] sjtjll= new float[210];

        public float[] Sjtjll
        {
            get { return sjtjll; }
            set { sjtjll = value; }
        }
        private float[] bztjll= new float[210];

        public float[] Bztjll
        {
            get { return bztjll; }
            set { bztjll = value; }
        }
        private float[] sdxzxs= new float[210];

        public float[] Sdxzxs
        {
            get { return sdxzxs; }
            set { sdxzxs = value; }
        }
        private float[] xsxzxs= new float[210];

        public float[] Xsxzxs
        {
            get { return xsxzxs; }
            set { xsxzxs = value; }
        }
        private float[] xsb= new float[210];

        public float[] Xsb
        {
            get { return xsb; }
            set { xsb = value; }
        }
        private float[] fxyglyl= new float[210];

        public float[] Fxyglyl
        {
            get { return fxyglyl; }
            set { fxyglyl = value; }
        }
        private float[] fxyssll= new float[210];

        public float[] Fxyssll
        {
            get { return fxyssll; }
            set { fxyssll = value; }
        }
    }
    public class vmasDataSecondsControl
    {
        CSVcontrol.CSVHelper vmas_csv = null;
        public bool writeVmasDataSeconds(vmasDataSeconds vmasdataseconds)
        {
            try
            {
                init_csv(vmasdataseconds.CarID);
                vmas_csv.openCsv();
                for (int i = 2; i <= 196; i++)
                {
                    vmas_csv.writeField(i, 1, vmasdataseconds.Qcsx[i - 2]);
                    vmas_csv.writeField(i, 2, vmasdataseconds.Sxnb[i - 2]);
                    vmas_csv.writeField(i, 3, vmasdataseconds.Cysx[i - 2].ToString("0"));
                    vmas_csv.writeField(i, 4, vmasdataseconds.Hcssz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 5, vmasdataseconds.Cossz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 6, vmasdataseconds.Co2ssz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 7, vmasdataseconds.Nossz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 8, vmasdataseconds.Hjo2nd[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 9, vmasdataseconds.Fxyo2ssz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 10, vmasdataseconds.Lljo2ssz[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 11, vmasdataseconds.Hcpfzl[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 12, vmasdataseconds.Copfzl[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 13, vmasdataseconds.Nopfzl[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 14, vmasdataseconds.Bzss[i - 2].ToString("0.0"));
                    vmas_csv.writeField(i, 15, vmasdataseconds.Sscs[i - 2].ToString("0.0"));
                    vmas_csv.writeField(i, 16, vmasdataseconds.Jzgl[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 17, vmasdataseconds.Hjwd[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 18, vmasdataseconds.Xdsd[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 19, vmasdataseconds.Dqyl[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 20, vmasdataseconds.Lljwd[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 21, vmasdataseconds.Lljyl[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 22, vmasdataseconds.Sjtjll[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 23, vmasdataseconds.Bztjll[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 24, vmasdataseconds.Sdxzxs[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 25, vmasdataseconds.Xsxzxs[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 26, vmasdataseconds.Xsb[i - 2].ToString("0.000"));
                    vmas_csv.writeField(i, 27, vmasdataseconds.Fxyglyl[i - 2].ToString("0.00"));
                    vmas_csv.writeField(i, 28, vmasdataseconds.Fxyssll[i - 2].ToString("0.00"));
                }
                vmas_csv.closeCsv();
                return true;
            }
            catch
            {
                return false;
            }
 
        }
        private void init_csv(string carID)
        {
            vmas_csv = new CSVcontrol.CSVHelper();
            vmas_csv.CreateCsv(@"C:\jcdatatxt\" + carID + ".csv");
            vmas_csv.openCsv();
            vmas_csv.writeField(1, 1, "全程时序");
            vmas_csv.writeField(1, 2, "时序类别");
            vmas_csv.writeField(1, 3, "采样时序");
            vmas_csv.writeField(1, 4, "HC实时值");
            vmas_csv.writeField(1, 5, "CO实时值");
            vmas_csv.writeField(1, 6, "CO2实时值");
            vmas_csv.writeField(1, 7, "NO实时值");
            vmas_csv.writeField(1, 8, "环境O2浓度");
            vmas_csv.writeField(1, 9, "分析仪O2实时值");
            vmas_csv.writeField(1, 10, "流量计O2实时值");
            vmas_csv.writeField(1, 11, "HC排放质量");
            vmas_csv.writeField(1, 12, "CO排放质量");
            vmas_csv.writeField(1, 13, "NO排放质量");
            vmas_csv.writeField(1, 14, "标准时速");
            vmas_csv.writeField(1, 15, "实时车速");
            vmas_csv.writeField(1, 16, "加载功率");
            vmas_csv.writeField(1, 17, "环境温度");
            vmas_csv.writeField(1, 18, "相对湿度");
            vmas_csv.writeField(1, 19, "大气压力");
            vmas_csv.writeField(1, 20, "流量计温度");
            vmas_csv.writeField(1, 21, "流量计压力");
            vmas_csv.writeField(1, 22, "实际体积流量");
            vmas_csv.writeField(1, 23, "标准体积流量");
            vmas_csv.writeField(1, 24, "湿度修正系数");
            vmas_csv.writeField(1, 25, "稀释修正系数");
            vmas_csv.writeField(1, 26, "稀释比");
            vmas_csv.writeField(1, 27, "分析仪管路压力");
            vmas_csv.writeField(1, 28, "分析仪实时流量");
            vmas_csv.closeCsv();
        }

    }
}
