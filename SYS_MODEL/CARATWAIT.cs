using System;
namespace SYS.Model
{
    /// <summary>
    /// BJCLXXB:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CARATWAIT
    {
        public CARATWAIT()
        {
            WXBJ = "";
            WXCD = "";
            WXSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            WXFY = "";
            GYXTXS = "";
            SFLJ = "";
            FWLX = "";
            ICCARDNO = "";
            DPFS = "";
            SOURCE = "";
    }
        #region Model
        private string clid;//clph+cpys+dlsj

        public string CLID
        {
            get { return clid; }
            set { clid = value; }
        }
        private DateTime dlsj;//登陆时间

        public DateTime DLSJ
        {
            get { return dlsj; }
            set { dlsj = value; }
        }
        private string clhp;

        public string CLHP
        {
            get { return clhp; }
            set { clhp = value; }
        }
        private string cpys;//车牌颜色

        public string CPYS
        {
            get { return cpys; }
            set { cpys = value; }
        }
        private string jcff;//检测方法

        public string JCFF
        {
            get { return jcff; }
            set { jcff = value; }
        }
        private string xslc;//行驶里程，检测完毕后存入已检车辆信息中

        public string XSLC
        {
            get { return xslc; }
            set { xslc = value; }
        }
        private string jccs;

        public string JCCS
        {
            get { return jccs; }
            set { jccs = value; }
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
        private string jcfy;

        public string JCFY
        {
            get { return jcfy; }
            set { jcfy = value; }
        }

        private string test;

        public string TEST
        {
            get { return test; }
            set { test = value; }
        }
        private string jcbgbh;
        public string JCBGBH
        {
            get { return jcbgbh; }
            set { jcbgbh = value; }
        }
        private string jcgwh;
        public string JCGWH
        {
            get { return jcgwh; }
            set { jcgwh = value; }
        }
        private string jczbh;
        public string JCZBH
        {
            get { return jczbh; }
            set { jczbh = value; }
        }
        private DateTime jcrq;
        public DateTime JCRQ
        {
            get { return jcrq; }
            set { jcrq = value; }
        }
        private string bgjcffyy;
        public string BGJCFFYY
        {
            get { return bgjcffyy; }
            set { bgjcffyy = value; }
        }
        private string sfcs;
        public string SFCS
        {
            get { return sfcs; }
            set { sfcs = value; }
        }
        private string ecrypt;

        public string ECRYPT
        {
            get { return ecrypt; }
            set { ecrypt = value; }
        }
        private string sfcj;

        public string SFCJ
        {
            get { return sfcj; }
            set { sfcj = value; }
        }
        private string jylsh;

        public string JYLSH
        {
            get { return jylsh; }
            set { jylsh = value; }
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
        public string ZT { set; get; }
        public string WXBJ { set; get; }
        public string WXCD { set; get; }
        public string WXSJ { set; get; }
        public string WXFY { set; get; }
        public string GYXTXS { set; get; }
        public string SFLJ { set; get; }
        public string FWLX { set; get; }
        public string ICCARDNO { set; get; }
        public string DPFS { set; get; }
        public string SOURCE { set; get; }
        #endregion Model
    }
}

