using System;
namespace SYS.Model
{
    /// <summary>
    /// SDS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SDS
    {
        public SDS()
        {
            COLOWXXZ = "";
            COHIGHXXZ = "";
            COLOWXYZ = "";
            COHIGHXYZ = "";
            CO2LOWXYZ = "";
            CO2HIGHXYZ = "";
            HCLOWXYZ = "";
            HCHIGHXYZ = "";
        }
        #region Model
        private string clid;

        public string CLID
        {
            get { return clid; }
            set { clid = value; }
        }
        private string jcbgbh;

        public string JCBGBH
        {
            get { return jcbgbh; }
            set { jcbgbh = value; }
        }
        private string clph;

        public string CLPH
        {
            get { return clph; }
            set { clph = value; }
        }
        private string colowclz;

        public string COLOWCLZ
        {
            get { return colowclz; }
            set { colowclz = value; }
        }
        private string colowxz;

        public string COLOWXZ
        {
            get { return colowxz; }
            set { colowxz = value; }
        }
        private string colowpd;

        public string COLOWPD
        {
            get { return colowpd; }
            set { colowpd = value; }
        }
        private string hclowclz;

        public string HCLOWCLZ
        {
            get { return hclowclz; }
            set { hclowclz = value; }
        }
        private string hclowxz;

        public string HCLOWXZ
        {
            get { return hclowxz; }
            set { hclowxz = value; }
        }
        private string hclowpd;

        public string HCLOWPD
        {
            get { return hclowpd; }
            set { hclowpd = value; }
        }
        private string zslow;

        public string ZSLOW
        {
            get { return zslow; }
            set { zslow = value; }
        }
        private string jywdlow;

        public string JYWDLOW
        {
            get { return jywdlow; }
            set { jywdlow = value; }
        }
        private string cohighclz;

        public string COHIGHCLZ
        {
            get { return cohighclz; }
            set { cohighclz = value; }
        }
        private string cohighxz;

        public string COHIGHXZ
        {
            get { return cohighxz; }
            set { cohighxz = value; }
        }
        private string cohighpd;

        public string COHIGHPD
        {
            get { return cohighpd; }
            set { cohighpd = value; }
        }
        private string hchighclz;

        public string HCHIGHCLZ
        {
            get { return hchighclz; }
            set { hchighclz = value; }
        }
        private string hchighxz;

        public string HCHIGHXZ
        {
            get { return hchighxz; }
            set { hchighxz = value; }
        }
        private string hchighpd;

        public string HCHIGHPD
        {
            get { return hchighpd; }
            set { hchighpd = value; }
        }
        private string zshigh;

        public string ZSHIGH
        {
            get { return zshigh; }
            set { zshigh = value; }
        }
        private string jywdhigh;

        public string JYWDHIGH
        {
            get { return jywdhigh; }
            set { jywdhigh = value; }
        }
        private string lamdahighclz;

        public string LAMDAHIGHCLZ
        {
            get { return lamdahighclz; }
            set { lamdahighclz = value; }
        }
        private string lamdahighxz;

        public string LAMDAHIGHXZ
        {
            get { return lamdahighxz; }
            set { lamdahighxz = value; }
        }
        private string lamdahighpd;

        public string LAMDAHIGHPD
        {
            get { return lamdahighpd; }
            set { lamdahighpd = value; }
        }

        private string lowpd;

        public string LOWPD
        {
            get { return lowpd; }
            set { lowpd = value; }
        }
        private string highpd;

        public string HIGHPD
        {
            get { return highpd; }
            set { highpd = value; }
        }
        private string zhpd;

        public string ZHPD
        {
            get { return zhpd; }
            set { zhpd = value; }
        }
        private DateTime jcrq;

        public DateTime JCRQ
        {
            get { return jcrq; }
            set { jcrq = value; }
        }
        private string wd;

        public string WD
        {
            get { return wd; }
            set { wd = value; }
        }
        private string sd;

        public string SD
        {
            get { return sd; }
            set { sd = value; }
        }
        private string dqy;

        public string DQY
        {
            get { return dqy; }
            set { dqy = value; }
        }
        private string sbmc;

        public string SBMC
        {
            get { return sbmc; }
            set { sbmc = value; }
        }
        private string sbxh;

        public string SBXH
        {
            get { return sbxh; }
            set { sbxh = value; }
        }
        private string sbzzc;

        public string SBZZC
        {
            get { return sbzzc; }
            set { sbzzc = value; }
        }

        private string fxyxh;

        public string FXYXH
        {
            get { return fxyxh; }
            set { fxyxh = value; }
        }
        private string fxybh;

        public string FXYBH
        {
            get { return fxybh; }
            set { fxybh = value; }
        }
        private string fxyzzc;

        public string FXYZZC
        {
            get { return fxyzzc; }
            set { fxyzzc = value; }
        }
        private string zsjxh;

        public string ZSJXH
        {
            get { return zsjxh; }
            set { zsjxh = value; }
        }
        private string zsjbh;

        public string ZSJBH
        {
            get { return zsjbh; }
            set { zsjbh = value; }
        }
        private string zsjzzc;

        public string ZSJZZC
        {
            get { return zsjzzc; }
            set { zsjzzc = value; }
        }
        private string shy;
        public string SHY
        {
            get { return shy; }
            set { shy = value; }
        }
        private string synchdate;
        public string SYNCHDATE
        {
            get { return synchdate; }
            set { synchdate = value; }
        }
        private string yw;
        public string YW
        {
            get { return yw; }
            set { yw = value; }
        }
        private string glkqxssx;
        public string GLKQXSSX
        {
            get { return glkqxssx; }
            set { glkqxssx = value; }
        }
        private string glkqxsxx;
        public string GLKQXSXX
        {
            get { return glkqxsxx; }
            set { glkqxsxx = value; }
        }
        private string jckssj;
        public string JCKSSJ
        {
            get { return jckssj; }
            set { jckssj = value; }
        }
        private string jcjssj;
        public string JCJSSJ
        {
            get { return jcjssj; }
            set { jcjssj = value; }
        }
        private string co2_high;

        public string CO2HIGH
        {
            get { return co2_high; }
            set { co2_high = value; }
        }
        private string o2_high;

        public string O2HIGH
        {
            get { return o2_high; }
            set { o2_high = value; }
        }
        private string co2_low;

        public string CO2LOW
        {
            get { return co2_low; }
            set { co2_low = value; }
        }
        private string o2_low;

        public string O2LOW
        {
            get { return o2_low; }
            set { o2_low = value; }
        }
        public string JYLSH { set; get; }
        public string JYCS { set; get; }
        public string SBRZBM { set; get; }
        public string COLOWXXZ { set; get; }
        public string COHIGHXXZ { set; get; }
        public string COLOWXYZ { set; get; }
        public string COHIGHXYZ { set; get; }
        public string CO2LOWXYZ { set; get; }
        public string CO2HIGHXYZ { set; get; }
        public string HCLOWXYZ { set; get; }
        public string HCHIGHXYZ { set; get; }
        #endregion Model

    }
}

