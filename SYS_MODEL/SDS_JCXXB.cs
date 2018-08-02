using System;
namespace SYS.Model
{
	/// <summary>
	/// ASM:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SDS_JCXXB
	{
        public SDS_JCXXB()
		{}
        private string _jcbh;

        public string JCBH
        {
            get { return _jcbh; }
            set { _jcbh = value; }
        }
        private string _jczmc;

        public string JCZMC
        {
            get { return _jczmc; }
            set { _jczmc = value; }
        }

        private string _jcrq;

        public string JCRQ
        {
            get { return _jcrq; }
            set { _jcrq = value; }
        }
        private string _sbrzbh;

        private string _jcczy;

        public string JCCZY
        {
            get { return _jcczy; }
            set { _jcczy = value; }
        }
        private string _jcjsy;

        public string JCJSY
        {
            get { return _jcjsy; }
            set { _jcjsy = value; }
        }

        public string SBRZBH
        {
            get { return _sbrzbh; }
            set { _sbrzbh = value; }
        }
        private string _sbmc;

        public string SBMC
        {
            get { return _sbmc; }
            set { _sbmc = value; }
        }
        private string _sbxh;

        public string SBXH
        {
            get { return _sbxh; }
            set { _sbxh = value; }
        }
        private string _sbzzc;

        public string SBZZC
        {
            get { return _sbzzc; }
            set { _sbzzc = value; }
        }
    }
}

