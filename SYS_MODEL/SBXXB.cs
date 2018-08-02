using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SBXXB
	{
		public SBXXB()
		{}
		#region Model
		private int _sbbh;
		private string _sblx;
		private string _sbmc;
		private string _sccj;
        private string _syzt;
        private string _xhtd;
        private string _gdtd;
        private string _cktd;
		private string _sbms;
        //private string _llj;
		/// <summary>
		/// 
		/// </summary>
		public int SBBH
		{
			set{ _sbbh=value;}
			get{return _sbbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SBLX
		{
			set{ _sblx=value;}
			get{return _sblx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SBMC
		{
			set{ _sbmc=value;}
			get{return _sbmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCCJ
		{
			set{ _sccj=value;}
			get{return _sccj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYZT
		{
			set{ _syzt=value;}
			get{return _syzt;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string XHTD
        {
            set { _xhtd = value; }
            get { return _xhtd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GDTD
        {
            set { _gdtd = value; }
            get { return _gdtd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CKTD
        {
            set { _cktd = value; }
            get { return _cktd; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string SBMS
		{
			set{ _sbms=value;}
			get{return _sbms;}
		}
		#endregion Model

	}
}

