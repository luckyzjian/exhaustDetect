using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FLOWMETER
	{
        public FLOWMETER()
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
        private string o2glcbz;

        public string O2GLCBZ
        {
            get { return o2glcbz; }
            set { o2glcbz = value; }
        }
        private string o2glcclz;

        public string O2GLCCLZ
        {
            get { return o2glcclz; }
            set { o2glcclz = value; }
        }
        private string o2glcwc;

        public string O2GLCWC
        {
            get { return o2glcwc; }
            set { o2glcwc = value; }
        }
        private string o2dlcbz;

        public string O2DLCBZ
        {
            get { return o2dlcbz; }
            set { o2dlcbz = value; }
        }
        private string o2dlcclz;

        public string O2DLCCLZ
        {
            get { return o2dlcclz; }
            set { o2dlcclz = value; }
        }
        private string o2dlcwc;

        public string O2DLCWC
        {
            get { return o2dlcwc; }
            set { o2dlcwc = value; }
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

