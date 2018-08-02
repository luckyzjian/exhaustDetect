using System;
namespace SYS.Model
{
	/// <summary>
	/// ZWB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ZWB
	{
		public ZWB()
		{}
		#region Model
        private int _zwqx;
		private int _zwbh;
		private string _zwmc;
		private string _zwsm;
        /// <summary>
        /// 
        /// </summary>
        public int ZWQX
        {
            set { _zwqx = value; }
            get { return _zwqx; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ZWBH
		{
			set{ _zwbh=value;}
			get{return _zwbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZWMC
		{
			set{ _zwmc=value;}
			get{return _zwmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZWSM
		{
			set{ _zwsm=value;}
			get{return _zwsm;}
		}
		#endregion Model

	}
}

