using System;
namespace SYS.Model
{
	/// <summary>
	/// ZYJS_XZGB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ZYJS_XZGB
	{
		public ZYJS_XZGB()
		{}
		#region Model
		private int _id;
		private string _zrdate20011001btgxz;
		private string _wldate20011001btgxz;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZRDate20011001btgxz
		{
			set{ _zrdate20011001btgxz=value;}
			get{return _zrdate20011001btgxz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WLDate20011001btgxz
		{
			set{ _wldate20011001btgxz=value;}
			get{return _wldate20011001btgxz;}
		}
        public bool onlyUseThis { set; get; }
        public int XZTABLE { set; get; }
        public int BTGXZBZ { set; get; }
		#endregion Model

	}
    public partial class BTG_XZGB
    {
        public BTG_XZGB()
        { }
        #region Model
        public  string id { set; get; }
        public string 车辆型号 { set; get; }
        public string 车辆类型 { set; get; }
        public string 发动机型号 { set; get; }
        public string 型式核准值 { set; get; }
        public string 限值 { set; get; }
        public string 发动机生产企业 { set; get; }
        public string 汽车生产企业 { set; get; }
        #endregion Model

    }
}

