using System;
namespace SYS.Model
{
    /// <summary>
    /// BJCLXXB:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CARDETECTED
    {
        public CARDETECTED()
        {
            CCS = "2";
            JYLSH = "";
            ZDJGL = "";
            CYXZ = "";
        }
        #region Model
        private string clid;//车辆ID

        public string CLID
        {
            get { return clid; }
            set { clid = value; }
        }
        private string stationID;

        public string STATIONID
        {
            get { return stationID; }
            set { stationID = value; }
        }
        private string lineID;

        public string LINEID
        {
            get { return lineID; }
            set { lineID = value; }
        }
        private string zxbz;

        public string ZXBZ
        {
            get { return zxbz; }
            set { zxbz = value; }
        }
        private DateTime dlsj;//登录时间

        public DateTime DLSJ
        {
            get { return dlsj; }
            set { dlsj = value; }
        }

        private DateTime jcsj;//登录时间

        public DateTime JCSJ
        {
            get { return jcsj; }
            set { jcsj = value; }
        }

        private string jcff;//检测方法

        public string JCFF
        {
            get { return jcff; }
            set { jcff = value; }
        }
        private string xslc;//行驶里程

        public string XSLC
        {
            get { return xslc; }
            set { xslc = value; }
        }
        private string jcjg;//检测结题

        public string JCJG
        {
            get { return jcjg; }
            set { jcjg = value; }
        }
        private string jccs;//检测次数

        public string JCCS
        {
            get { return jccs; }
            set { jccs = value; }
        }
        private string lsh;//流水号

        public string LSH
        {
            get { return lsh; }
            set { lsh = value; }
        }
        private string clhp;

        public string CLHP
        {
            get { return clhp; }
            set { clhp = value; }
        }
        private string cpys;

        public string CPYS
        {
            get { return cpys; }
            set { cpys = value; }
        }
        private string cllx;

        public string CLLX
        {
            get { return cllx; }
            set { cllx = value; }
        }
        private string cz;

        public string CZ
        {
            get { return cz; }
            set { cz = value; }
        }
        private string syxz;

        public string SYXZ
        {
            get { return syxz; }
            set { syxz = value; }
        }
        private string pp;

        public string PP
        {
            get { return pp; }
            set { pp = value; }
        }
        private string xh;

        public string XH
        {
            get { return xh; }
            set { xh = value; }
        }
        private string clsbm;

        public string CLSBM
        {
            get { return clsbm; }
            set { clsbm = value; }
        }
        private string fdjhm;

        public string FDJHM
        {
            get { return fdjhm; }
            set { fdjhm = value; }
        }
        private string fdjxh;

        public string FDJXH
        {
            get { return fdjxh; }
            set { fdjxh = value; }
        }
        private string scqy;

        public string SCQY
        {
            get { return scqy; }
            set { scqy = value; }
        }
        private string hdzk;

        public string HDZK
        {
            get { return hdzk; }
            set { hdzk = value; }
        }
        private string jsszk;

        public string JSSZK
        {
            get { return jsszk; }
            set { jsszk = value; }
        }
        private string zzl;

        public string ZZL
        {
            get { return zzl; }
            set { zzl = value; }
        }
        private string hdzzl;

        public string HDZZL
        {
            get { return hdzzl; }
            set { hdzzl = value; }
        }
        private string zbzl;

        public string ZBZL
        {
            get { return zbzl; }
            set { zbzl = value; }
        }
        private string jzzl;

        public string JZZL
        {
            get { return jzzl; }
            set { jzzl = value; }
        }
        private DateTime zcrq;

        public DateTime ZCRQ
        {
            get { return zcrq; }
            set { zcrq = value; }
        }
        private DateTime scrq;

        public DateTime SCRQ
        {
            get { return scrq; }
            set { scrq = value; }
        }
        private string fdjpl;

        public string FDJPL
        {
            get { return fdjpl; }
            set { fdjpl = value; }
        }
        private string rlzl;

        public string RLZL
        {
            get { return rlzl; }
            set { rlzl = value; }
        }
        private string edgl;

        public string EDGL
        {
            get { return edgl; }
            set { edgl = value; }
        }
        private string edzs;

        public string EDZS
        {
            get { return edzs; }
            set { edzs = value; }
        }
        private string bsqxs;

        public string BSQXS
        {
            get { return bsqxs; }
            set { bsqxs = value; }
        }
        private string dws;

        public string DWS
        {
            get { return dws; }
            set { dws = value; }
        }
        private string gyfs;

        public string GYFS
        {
            get { return gyfs; }
            set { gyfs = value; }
        }
        private string dpfs;

        public string DPFS
        {
            get { return dpfs; }
            set { dpfs = value; }
        }
        private string jqfs;

        public string JQFS
        {
            get { return jqfs; }
            set { jqfs = value; }
        }
        private string qgs;

        public string QGS
        {
            get { return qgs; }
            set { qgs = value; }
        }
        private string qdxs;

        public string QDXS
        {
            get { return qdxs; }
            set { qdxs = value; }
        }
        private string chzz;

        public string CHZZ
        {
            get { return chzz; }
            set { chzz = value; }
        }
        private string dlsp;

        public string DLSP
        {
            get { return dlsp; }
            set { dlsp = value; }
        }
        private string sfsrl;

        public string SFSRL
        {
            get { return sfsrl; }
            set { sfsrl = value; }
        }
        private string jhzz;

        public string JHZZ
        {
            get { return jhzz; }
            set { jhzz = value; }
        }
        private string obd;

        public string OBD
        {
            get { return obd; }
            set { obd = value; }
        }
        private string dkgyyb;

        public string DKGYYB
        {
            get { return dkgyyb; }
            set { dkgyyb = value; }
        }
        private string lxdh;

        public string LXDH
        {
            get { return lxdh; }
            set { lxdh = value; }
        }
        private string czy;
        public string CZY
        {
            get { return czy; }
            set { czy = value; }
        }
        private string jsy;

        public string JSY
        {
            get { return jsy; }
            set { jsy = value; }
        }
        private string dly;

        public string DLY
        {
            get { return dly; }
            set { dly = value; }
        }
        private string jczmc;

        public string JCZMC
        {
            get { return jczmc; }
            set { jczmc = value; }
        }
        private string jcfy;

        public string JCFY
        {
            get { return jcfy; }
            set { jcfy = value; }
        }
        private string sfjf;

        public string SFJF
        {
            get { return sfjf; }
            set { sfjf = value; }
        }
        private string test;

        public string TEST
        {
            get { return test; }
            set { test = value; }
        }
        private string qdltqy;

        public string QDLTQY
        {
            get { return qdltqy; }
            set { qdltqy = value; }
        }
        private string ryph;

        public string RYPH
        {
            get { return ryph; }
            set { ryph = value; }
        }

        public string HPZL
        {
            get
            {
                return hpzl;
            }

            set
            {
                hpzl = value;
            }
        }

        private string hpzl;
        public string jcgcsj { set; get; }
        public string wjy { set; get; }
        public string BGFFYY { set; get; }
        public string CCS { set; get; }
        public string JYLSH { set; get; }
        public string ZDJGL { set; get; }
        public string CYXZ { set; get; }
        #endregion Model
    }
}

