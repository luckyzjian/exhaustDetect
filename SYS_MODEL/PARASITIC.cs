using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PARASITIC
	{
        public PARASITIC()
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
        private string sdqj;

        public string SDQJ
        {
            get { return sdqj; }
            set { sdqj = value; }
        }
        private string mysd;

        public string MYSD
        {
            get { return mysd; }
            set { mysd = value; }
        }
        private string hxsj;

        public string HXSJ
        {
            get { return hxsj; }
            set { hxsj = value; }
        }
        private string jsgl;

        public string JSGL
        {
            get { return jsgl; }
            set { jsgl = value; }
        }
        private string ljhxsj;

        public string LJHXSJ
        {
            get { return ljhxsj; }
            set { ljhxsj = value; }
        }
        private string bz;

        public string BZ
        {
            get { return bz; }
            set { bz = value; }
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

