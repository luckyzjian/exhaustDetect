using System;
namespace SYS.Model
{
	/// <summary>
	/// JZJS_XZDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JZJS_XZBZ
	{
        public JZJS_XZBZ()
		{}
		#region Model
		private string _id;
		private string _g1xz;
		private string _g2xz;
		private string _g3xz;
		private string _g4xz;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G1XZ
		{
            set { _g1xz = value; }
            get { return _g1xz; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string G2XZ
		{
            set { _g2xz = value; }
            get { return _g2xz; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string G3XZ
		{
            set { _g3xz = value; }
            get { return _g3xz; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string G4XZ
		{
            set { _g4xz = value; }
            get { return _g4xz; }
		}
		
		#endregion Model

	}
}

