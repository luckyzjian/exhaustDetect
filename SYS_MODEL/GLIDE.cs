using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GLIDE
	{
        public GLIDE()
		{}
		#region Model
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
        private DateTime bdrq;

        public DateTime BDRQ
        {
            get { return bdrq; }
            set { bdrq = value; }
        }
        private string hxqj;

        public string HXQJ
        {
            get { return hxqj; }
            set { hxqj = value; }
        }
        private string qjmysd;

        public string QJMYSD
        {
            get { return qjmysd; }
            set { qjmysd = value; }
        }
        private string plhp;

        public string PLHP
        {
            get { return plhp; }
            set { plhp = value; }
        }
        private string ccdt;

        public string CCDT
        {
            get { return ccdt; }
            set { ccdt = value; }
        }
        private string acdt;

        public string ACDT
        {
            get { return acdt; }
            set { acdt = value; }
        }
        private string wc;

        public string WC
        {
            get { return wc; }
            set { wc = value; }
        }
        private string jzsdgl;

        public string JZSDGL
        {
            get { return jzsdgl; }
            set { jzsdgl = value; }
        }
        private string bzsm;

        public string BZSM
        {
            get { return bzsm; }
            set { bzsm = value; }
        }
        private string bdjg;

        public string BDJG
        {
            get { return bdjg; }
            set { bdjg = value; }
        }
		#endregion Model

	}
}

