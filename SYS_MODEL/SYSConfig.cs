using System;
namespace SYS.Model
{
	/// <summary>
	/// BDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYSConfig
	{
        public SYSConfig()
		{}
		#region Model
        private string _dysj;
        private int _dyjccs;
        private int _fcfs;
        private int _qxz;
        private int _interval;


        /// <summary>
        /// 
        /// </summary>
        public string DYSJ
        {
            set { _dysj = value; }
            get { return _dysj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DYJCCS
        {
            set { _dyjccs = value; }
            get { return _dyjccs; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int FCFS
		{
			set{ _fcfs=value;}
			get{return _fcfs;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int QXZ
        {
            set { _qxz = value; }
            get { return _qxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Interval
        {
            set { _interval = value; }
            get { return _interval; }
        }
		#endregion Model

	}
}

