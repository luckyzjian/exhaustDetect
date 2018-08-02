using System;
namespace SYS.Model
{
	/// <summary>
	/// XXXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class XXXXB
	{
		public XXXXB()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private string _other;
		private string _comefrom;
		private string _getto;
        private string _message_type;
		private string _flag;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Other
		{
			set{ _other=value;}
			get{return _other;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comefrom
		{
			set{ _comefrom=value;}
			get{return _comefrom;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Getto
        {
            set { _getto = value; }
            get { return _getto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message_Type
        {
            set { _message_type = value; }
            get { return _message_type; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}

