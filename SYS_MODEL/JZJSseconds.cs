using System;
namespace SYS.Model
{
	/// <summary>
	/// JZJS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JZJSseconds
	{
        public JZJSseconds()
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
        private string mmcs;

        public string MMCS
        {
            get { return mmcs; }
            set { mmcs = value; }
        }
        private string mmgl;

        public string MMGL
        {
            get { return mmgl; }
            set { mmgl = value; }
        }
        private string mmk;

        public string MMK
        {
            get { return mmk; }
            set { mmk = value; }
        }
        public string MMZS { set; get; }
        public string MMZGL { set; get; }
        public string MMZSGL { set; get; }
        public string MMGLXZXS { set; get; }
        public string MMJSGL { set; get; }
        public string MMBTGD { set; get; }
        public string MMDQYL { set; get; }
        public string MMXDSD { set; get; }
        public string MMHJWD { set; get; }
        public string MMNL { set; get; }
        public string JYLSH { set; get; }
        public string JYCS { set; get; }
        public string CYDS { set; get; }
        public string MMNO { set; get; }

        private string mmyw;
        public string MMYW
        {
            get { return mmyw; }
            set { mmyw = value; }
        }
        #endregion Model

    }
}

