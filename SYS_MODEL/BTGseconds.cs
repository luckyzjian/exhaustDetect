using System;
namespace SYS.Model
{
    /// <summary>
    /// JZJS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BTGseconds
    {
        public BTGseconds()
        { }
        #region Model
        private string clid;

        public string CLID
        {
            get { return clid; }
            set { clid = value; }
        }
        private string clhp;

        public string CLHP
        {
            get { return clhp; }
            set { clhp = value; }
        }

        private DateTime jcsj;

        public DateTime JCSJ
        {
            get { return jcsj; }
            set { jcsj = value; }
        }
        private string mmitme;

        public string MMTIME
        {
            get { return mmitme; }
            set { mmitme = value; }
        }
        private string mmsx;

        public string MMSX
        {
            get { return mmsx; }
            set { mmsx = value; }
        }
        private string mmlb;

        public string MMLB
        {
            get { return mmlb; }
            set { mmlb = value; }
        }
        private string mmydzds;

        public string MMYDZDS
        {
            get { return mmydzds; }
            set { mmydzds = value; }
        }
        private string mmfdjzs;

        public string MMFDJZS
        {
            get { return mmfdjzs; }
            set { mmfdjzs = value; }
        }
        private string mmyw;

        public string MMYW
        {
            get { return mmyw; }
            set { mmyw = value; }
        }

        public string JYLSH { set; get; }
        public string JYCS { set; get; }
        public string CYDS { set; get; }
        #endregion Model

    }
}

