using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ANALYSISMETER
	{
        public ANALYSISMETER()
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
        private string co2bz;

        public string CO2BZ
        {
            get { return co2bz; }
            set { co2bz = value; }
        }
        private string co2clz;

        public string CO2CLZ
        {
            get { return co2clz; }
            set { co2clz = value; }
        }
        private string cobz;

        public string COBZ
        {
            get { return cobz; }
            set { cobz = value; }
        }
        private string coclz;

        public string COCLZ
        {
            get { return coclz; }
            set { coclz = value; }
        }
        private string hcbz;

        public string HCBZ
        {
            get { return hcbz; }
            set { hcbz = value; }
        }
        private string hcclz;

        public string HCCLZ
        {
            get { return hcclz; }
            set { hcclz = value; }
        }
        private string nobz;

        public string NOBZ
        {
            get { return nobz; }
            set { nobz = value; }
        }
        private string noclz;

        public string NOCLZ
        {
            get { return noclz; }
            set { noclz = value; }
        }
        private string jzds;

        public string JZDS
        {
            get { return jzds; }
            set { jzds = value; }
        }
        private string gdjz;

        public string GDJZ
        {
            get { return gdjz; }
            set { gdjz = value; }
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

