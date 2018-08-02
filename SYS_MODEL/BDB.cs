using System;
namespace SYS.Model
{
	/// <summary>
	/// BDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BDB
	{
		public BDB()
		{}
		#region Model
		private int _hb;
		private int? _sbbh;
		private int? _tdh;
		private decimal? _bdz;
		/// <summary>
		/// 
		/// </summary>
		public int HB
		{
			set{ _hb=value;}
			get{return _hb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SBBH
		{
			set{ _sbbh=value;}
			get{return _sbbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TDH
		{
			set{ _tdh=value;}
			get{return _tdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BDZ
		{
			set{ _bdz=value;}
			get{return _bdz;}
		}
		#endregion Model

	}
}

