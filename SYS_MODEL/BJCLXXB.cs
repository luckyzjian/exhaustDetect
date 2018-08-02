using System;
namespace SYS.Model
{
	/// <summary>
	/// BJCLXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BJCLXXB
	{
		public BJCLXXB()
		{}
		#region Model
		private string _jcbh;
		private string _pzlx;
		private string _jcclph;
        private string _clxhbh;
		private int _jccs;
        private int _lsh;
		private DateTime _ccrq;
        private DateTime _djrq;
		private string _fdjh;
		private string _cjh;
		private string _cz;
		private string _czdh;
		private string _czdz;
		private int _lcbds;
		private string _hbbz;
		private string _syqk;
        private string _jcbj;
        private string _jczt;
        private string _qrjcff;
        private string _rylx;
        private DateTime _jcrq;//检测日期
        private int _hdzk;//设计乘客数
        private string _jqxs;//进气形式

        

        public int HDZK
        {
            get { return _hdzk; }
            set { _hdzk = value; }
        }

        public DateTime JCRQ
        {
            get { return _jcrq; }
            set { _jcrq = value; }
        }
        

        public string RYLX
        {
            get { return _rylx; }
            set { _rylx = value; }
        }
        private string _gyff;

        public string GYFF
        {
            get { return _gyff; }
            set { _gyff = value; }
        }
        private string _bsxlx;

        public string BSXLX
        {
            get { return _bsxlx; }
            set { _bsxlx = value; }
        }
        private string _cllx;

        public string CLLX
        {
            get { return _cllx; }
            set { _cllx = value; }
        }
        private string _zbzl;

        public string ZBZL
        {
            get { return _zbzl; }
            set { _zbzl = value; }
        }
        private string _zdzzl;

        public string ZDZZL
        {
            get { return _zdzzl; }
            set { _zdzzl = value; }
        }
        private string _fdjpl;

        public string FDJPL
        {
            get { return _fdjpl; }
            set { _fdjpl = value; }
        }
        private string _fdjscs;

        public string FDJSCS
        {
            get { return _fdjscs; }
            set { _fdjscs = value; }
        }
        private string _jczh;

        public string JCZH
        {
            get { return _jczh; }
            set { _jczh = value; }
        }
        private string _dczz;

        public string DCZZ
        {
            get { return _dczz; }
            set { _dczz = value; }
        }
        private string _fdjedgl;

        public string FDJEDGL
        {
            get { return _fdjedgl; }
            set { _fdjedgl = value; }
        }
        private string _fdjedzs;

        public string FDJEDZS
        {
            get { return _fdjedzs; }
            set { _fdjedzs = value; }
        }
        private int _pqgsl;

        public int PQGSL
        {
            get { return _pqgsl; }
            set { _pqgsl = value; }
        }
        private string _pfbz;

        public string PFBZ
        {
            get { return _pfbz; }
            set { _pfbz = value; }
        }
        private string _zzcs;

        public string ZZCS
        {
            get { return _zzcs; }
            set { _zzcs = value; }
        }
        private int _qgs;

        public int QGS
        {
            get { return _qgs; }
            set { _qgs = value; }
        }
        private string _qdxs;

        public string QDXS
        {
            get { return _qdxs; }
            set { _qdxs = value; }
        }
        private string _qdlqy;

        public string QDLQY
        {
            get { return _qdlqy; }
            set { _qdlqy = value; }
        }
        private string _jcyh;

        public string JCYH
        {
            get { return _jcyh; }
            set { _jcyh = value; }
        }
        private int _dws;
		/// <summary>
		/// 
		/// </summary>
		

        public int DWS
        {
          get { return _dws; }
          set { _dws = value; }
        }
        public string JCBH
		{
			set{ _jcbh=value;}
			get{return _jcbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PZLX
		{
			set{ _pzlx=value;}
			get{return _pzlx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCCLPH
		{
			set{ _jcclph=value;}
			get{return _jcclph;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CLXHBH
		{
			set{ _clxhbh=value;}
			get{return _clxhbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JCCS
		{
			set{ _jccs=value;}
			get{return _jccs;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int LSH
        {
            set { _lsh = value; }
            get { return _lsh; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime CCRQ
		{
			set{ _ccrq=value;}
			get{return _ccrq;}
		}
        /// <summary>
        /// 
        /// </summary>
        public DateTime DJRQ
        {
            set { _djrq = value; }
            get { return _djrq; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string FDJH
		{
			set{ _fdjh=value;}
			get{return _fdjh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CJH
		{
			set{ _cjh=value;}
			get{return _cjh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZ
		{
			set{ _cz=value;}
			get{return _cz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZDH
		{
			set{ _czdh=value;}
			get{return _czdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZDZ
		{
			set{ _czdz=value;}
			get{return _czdz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LCBDS
		{
			set{ _lcbds=value;}
			get{return _lcbds;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HBBZ
		{
			set{ _hbbz=value;}
			get{return _hbbz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SYQK
		{
			set{ _syqk=value;}
			get{return _syqk;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string JCBJ
        {
            set { _jcbj = value; }
            get { return _jcbj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JCZT
        {
            set { _jczt = value; }
            get { return _jczt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QRJCFF
        {
            set { _qrjcff = value; }
            get { return _qrjcff; }
        }
		#endregion Model
        public string JQXS
        {
            get { return _jqxs; }
            set { _jqxs = value; }
        }
	}
}

