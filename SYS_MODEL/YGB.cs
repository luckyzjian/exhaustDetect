using System;
namespace SYS.Model
{
	/// <summary>
	/// YGB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YGB
	{
		public YGB()
		{}
		#region Model
		private string _ygbh;
		private string _ygxm;
        private string _dhhm;
		private int _ygzwbh;
		private string _ygsfz;
        private string _ygzt;
        private string _user_name;
        private string _password;
		/// <summary>
		/// 
		/// </summary>
        public string YGBH
		{
			set{ _ygbh=value;}
			get{return _ygbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YGXM
		{
			set{ _ygxm=value;}
			get{return _ygxm;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string DHHM
        {
            set { _dhhm = value; }
            get { return _dhhm; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int YGZWBH
		{
			set{ _ygzwbh=value;}
			get{return _ygzwbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YGSFZ
		{
			set{ _ygsfz=value;}
			get{return _ygsfz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YGZT
		{
			set{ _ygzt=value;}
			get{return _ygzt;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string User_Name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
		#endregion Model

	}
}

