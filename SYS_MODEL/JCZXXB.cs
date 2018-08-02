using System;
namespace SYS.Model
{
	/// <summary>
	/// JCZXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JCZXXB
	{
		public JCZXXB()
		{}
		#region Model
		private string _jczbh;
		private string _jczmc;
		private string _jczdz;
		private string _jczdh;
        private string _jczfzr;
		/// <summary>
		/// 
		/// </summary>
		public string JCZBH
		{
			set{ _jczbh=value;}
			get{return _jczbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCZMC
		{
			set{ _jczmc=value;}
			get{return _jczmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCZDZ
		{
			set{ _jczdz=value;}
			get{return _jczdz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCZDH
		{
			set{ _jczdh=value;}
			get{return _jczdh;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string JCZFZR
        {
            set { _jczfzr = value; }
            get { return _jczfzr; }
        }
		#endregion Model

	}
}

