using System;
namespace SYS.Model
{

	public partial class ZYJSseconds
	{
        public ZYJSseconds()
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
        private string mmzs;

        public string MMZS
        {
            get { return mmzs; }
            set { mmzs = value; }
        }
        private string mmk;

        public string MMK
        {
            get { return mmk; }
            set { mmk = value; }
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

