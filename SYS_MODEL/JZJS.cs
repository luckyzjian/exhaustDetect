using System;
namespace SYS.Model
{
	/// <summary>
	/// JZJS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JZJS
	{
		public JZJS()
        {
            JCBGBH = "";
            SHY = "";
            SynchDate = "";
            YW = "";
            JCKSSJ = "";
            JCJSSJ = "";
        }
		#region Model
        private string clid;

        public string CLID
        {
            get { return clid; }
            set { clid = value; }
        }
        private string clph;

        public string CLPH
        {
            get { return clph; }
            set { clph = value; }
        }
        private string hk;

        public string HK
        {
            get { return hk; }
            set { hk = value; }
        }
        private string nk;

        public string NK
        {
            get { return nk; }
            set { nk = value; }
        }
        private string ek;

        public string EK
        {
            get { return ek; }
            set { ek = value; }
        }
        private string ydxz;

        public string YDXZ
        {
            get { return ydxz; }
            set { ydxz = value; }
        }
        private string hkpd;

        public string HKPD
        {
            get { return hkpd; }
            set { hkpd = value; }
        }
        private string nkpd;

        public string NKPD
        {
            get { return nkpd; }
            set { nkpd = value; }
        }
        private string ekpd;

        public string EKPD
        {
            get { return ekpd; }
            set { ekpd = value; }
        }
        private string maxlbgl;

        public string MAXLBGL
        {
            get { return maxlbgl; }
            set { maxlbgl = value; }
        }
        private string glxz;

        public string GLXZ
        {
            get { return glxz; }
            set { glxz = value; }
        }
        private string glpd;

        public string GLPD
        {
            get { return glpd; }
            set { glpd = value; }
        }
        private string maxlbzs;

        public string MAXLBZS
        {
            get { return maxlbzs; }
            set { maxlbzs = value; }
        }
        private string zsxz;

        public string ZSXZ
        {
            get { return zsxz; }
            set { zsxz = value; }
        }
        private string zspd;

        public string ZSPD
        {
            get { return zspd; }
            set { zspd = value; }
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
        private string cgjxh;

        public string CGJXH
        {
            get { return cgjxh; }
            set { cgjxh = value; }
        }
        private string cgjbh;

        public string CGJBH
        {
            get { return cgjbh; }
            set { cgjbh = value; }
        }
        private string cgjzzc;

        public string CGJZZC
        {
            get { return cgjzzc; }
            set { cgjzzc = value; }
        }
        private string ydjxh;

        public string YDJXH
        {
            get { return ydjxh; }
            set { ydjxh = value; }
        }
        private string ydjbh;

        public string YDJBH
        {
            get { return ydjbh; }
            set { ydjbh = value; }
        }
        private string ydjzzc;

        public string YDJZZC
        {
            get { return ydjzzc; }
            set { ydjzzc = value; }
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
        public string GLXZXS { set; get; }
        public string ACTMAXHP { set; get; }
        public string REALVELMAXHP { set; get; }
        public string VELMAXHP { set; get; }
        public string VELMAXHPZS { set; get; }
        public string RATEREVUP { set; get; }
        public string RATEREVDOWN { set; get; }
        public string JYLSH { set; get; }
        public string JYCS { set; get; }
        public string SBRZBM { set; get; }
        public string JCBGBH { set; get; }
        public string SHY { set; get; }
        public string SynchDate { set; get; }
        public string YW { set; get; }
        public string JCKSSJ { set; get; }
        public string JCJSSJ { set; get; }
        public string HNO { set; get; }
        public string NNO { set; get; }
        public string ENO { set; get; }
        #endregion Model

    }
}

