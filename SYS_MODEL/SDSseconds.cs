using System;
namespace SYS.Model
{
	/// <summary>
	/// JZJS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SDSseconds
	{
        public SDSseconds()
		{}
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
        private string mmhc;

        public string MMHC
        {
            get { return mmhc; }
            set { mmhc = value; }
        }
        private string mmco;

        public string MMCO
        {
            get { return mmco; }
            set { mmco = value; }
        }
        private string mmo2;

        public string MMO2
        {
            get { return mmo2; }
            set { mmo2 = value; }
        }
        private string mmco2;
        public string MMCO2
        {
            get { return mmco2; }
            set { mmco2 = value; }
        }
        private string mmlamda;
        public string MMLAMDA
        {
            get { return mmlamda; }
            set { mmlamda = value; }
        }
        private string mmzs;
        public string MMZS
        {
            get { return mmzs; }
            set { mmzs = value; }
        }
        private string mmyw;
        public string MMYW
        {
            get { return mmyw; }
            set { mmyw = value; }
        }
        private string mmwd;
        public string MMWD
        {
            get { return mmwd; }
            set { mmwd = value; }
        }
        private string mmsd;
        public string MMSD
        {
            get { return mmsd; }
            set { mmsd = value; }
        }
        private string mmdqy;
        public string MMDQY
        {
            get { return mmdqy; }
            set { mmdqy = value; }
        }
        public string JYLSH { set; get; }
        public string JYCS { set; get; }
        public string CYDS { set; get; }
        #endregion Model

    }
}

