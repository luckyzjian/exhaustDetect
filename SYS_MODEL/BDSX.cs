using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BDSX
	{
        public BDSX()
		{}
		#region Model
        private string hxsx;//加载滑行标定时限

        public string HXSX
        {
            get { return hxsx; }
            set { hxsx = value; }
        }
        private string jsglsx;//寄生功率标定时限

        public string JSGLSX
        {
            get { return jsglsx; }
            set { jsglsx = value; }
        }
        private string glsx;//惯量标定时限

        public string GLSX
        {
            get { return glsx; }
            set { glsx = value; }
        }
        private string fxysx;//废气仪标定时限

        public string FXYSX
        {
            get { return fxysx; }
            set { fxysx = value; }
        }
        private string lljsx;//流量计标定时限

        public string LLJSX
        {
            get { return lljsx; }
            set { lljsx = value; }
        }

        public string YLJSX
        {
            get
            {
                return yljsx;
            }

            set
            {
                yljsx = value;
            }
        }

        public string SDSX
        {
            get
            {
                return sdsx;
            }

            set
            {
                sdsx = value;
            }
        }

        public string YDJSX
        {
            get
            {
                return ydjsx;
            }

            set
            {
                ydjsx = value;
            }
        }

        public string FXYLOWSX
        {
            get
            {
                return fxylowsx;
            }

            set
            {
                fxylowsx = value;
            }
        }

        public string FXYMIDSX
        {
            get
            {
                return fxymidsx;
            }

            set
            {
                fxymidsx = value;
            }
        }

        public string FXYHIGHSX
        {
            get
            {
                return fxyhighsx;
            }

            set
            {
                fxyhighsx = value;
            }
        }

        public string FXYLOWMIDSX
        {
            get
            {
                return fxylowmidsx;
            }

            set
            {
                fxylowmidsx = value;
            }
        }

        public string FXYHIGHMIDSX
        {
            get
            {
                return fxyhighmidsx;
            }

            set
            {
                fxyhighmidsx = value;
            }
        }

        public string YRSX
        {
            get
            {
                return yrsx;
            }

            set
            {
                yrsx = value;
            }
        }

        public string ZJSX
        {
            get
            {
                return zjsx;
            }

            set
            {
                zjsx = value;
            }
        }

        public string HJCSSX
        {
            get
            {
                return hjcssx;
            }

            set
            {
                hjcssx = value;
            }
        }

        public string ZSJSX
        {
            get
            {
                return zsjsx;
            }

            set
            {
                zsjsx = value;
            }
        }

        public string JLSX
        {
            get
            {
                return jlsx;
            }

            set
            {
                jlsx = value;
            }
        }

        private string yljsx;
        private string sdsx;
        private string ydjsx;
        private string fxylowsx;
        private string fxymidsx;
        private string fxyhighsx;
        private string fxylowmidsx;
        private string fxyhighmidsx;
        private string yrsx;
        private string zjsx;
        private string hjcssx;
        private string zsjsx;
        private string jlsx;
		#endregion Model

	}
}

