using System;
namespace SYS.Model
{
	/// <summary>
	/// SBXXB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LINESBBD
	{
        public LINESBBD()
		{}
		#region Model
        private string stationID;

        public string STATIONID
        {
            get { return stationID; }
            set { stationID = value; }
        }
        private string lineID;

        public string LINEID
        {
            get { return lineID; }
            set { lineID = value; }
        }

        public DateTime Hxdate
        {
            get
            {
                return hxdate;
            }

            set
            {
                hxdate = value;
            }
        }

        public bool Hxenable
        {
            get
            {
                return hxenable;
            }

            set
            {
                hxenable = value;
            }
        }

        public DateTime Gldate
        {
            get
            {
                return gldate;
            }

            set
            {
                gldate = value;
            }
        }

        public bool Glenable
        {
            get
            {
                return glenable;
            }

            set
            {
                glenable = value;
            }
        }

        public DateTime Jsgldate
        {
            get
            {
                return jsgldate;
            }

            set
            {
                jsgldate = value;
            }
        }

        public bool Jsglenable
        {
            get
            {
                return jsglenable;
            }

            set
            {
                jsglenable = value;
            }
        }

        public DateTime Fxylowdate
        {
            get
            {
                return fxylowdate;
            }

            set
            {
                fxylowdate = value;
            }
        }

        public bool Fxylowenable
        {
            get
            {
                return fxylowenable;
            }

            set
            {
                fxylowenable = value;
            }
        }

        public DateTime Fxyhighdate
        {
            get
            {
                return fxyhighdate;
            }

            set
            {
                fxyhighdate = value;
            }
        }

        public bool Fxyhighenable
        {
            get
            {
                return fxyhighenable;
            }

            set
            {
                fxyhighenable= value;
            }
        }
        
        public DateTime Fxymiddate
        {
            get
            {
                return fxymiddate;
            }

            set
            {
                fxymiddate = value;
            }
        }

        public bool Fxymidenable
        {
            get
            {
                return fxymidenable;
            }

            set
            {
                fxymidenable = value;
            }
        }

        public DateTime Fxylowmiddate
        {
            get
            {
                return fxylowmiddate;
            }

            set
            {
                fxylowmiddate = value;
            }
        }

        public bool Fxylowmidenable
        {
            get
            {
                return fxylowmidenable;
            }

            set
            {
                fxylowmidenable = value;
            }
        }

        public DateTime Fxyhighmiddate
        {
            get
            {
                return fxyhighmiddate;
            }

            set
            {
                fxyhighmiddate = value;
            }
        }

        public bool Fxyhighmidenable
        {
            get
            {
                return fxyhighmidenable;
            }

            set
            {
                fxyhighmidenable = value;
            }
        }

        public DateTime Yrdate
        {
            get
            {
                return yrdate;
            }

            set
            {
                yrdate = value;
            }
        }

        public bool Yrenable
        {
            get
            {
                return yrenable;
            }

            set
            {
                yrenable = value;
            }
        }

        public DateTime Zjdate
        {
            get
            {
                return zjdate;
            }

            set
            {
                zjdate = value;
            }
        }

        public bool Zjenable
        {
            get
            {
                return zjenable;
            }

            set
            {
                zjenable = value;
            }
        }

        public DateTime Ydjdate
        {
            get
            {
                return ydjdate;
            }

            set
            {
                ydjdate = value;
            }
        }

        public bool Ydjenable
        {
            get
            {
                return ydjenable;
            }

            set
            {
                ydjenable = value;
            }
        }

        public DateTime Sddate
        {
            get
            {
                return sddate;
            }

            set
            {
                sddate = value;
            }
        }

        public bool Sdenable
        {
            get
            {
                return sdenable;
            }

            set
            {
                sdenable = value;
            }
        }

        public DateTime Hjcsdate
        {
            get
            {
                return hjcsdate;
            }

            set
            {
                hjcsdate = value;
            }
        }

        public bool Hjcsenable
        {
            get
            {
                return hjcsenable;
            }

            set
            {
                hjcsenable = value;
            }
        }

        public DateTime Zsjdate
        {
            get
            {
                return zsjdate;
            }

            set
            {
                zsjdate = value;
            }
        }

        public bool Zsjenable
        {
            get
            {
                return zsjenable;
            }

            set
            {
                zsjenable = value;
            }
        }

        public DateTime Lljdate
        {
            get
            {
                return lljdate;
            }

            set
            {
                lljdate = value;
            }
        }

        public bool Lljenable
        {
            get
            {
                return lljenable;
            }

            set
            {
                lljenable = value;
            }
        }

        public DateTime Yljdate
        {
            get
            {
                return yljdate;
            }

            set
            {
                yljdate = value;
            }
        }

        public bool Yljenable
        {
            get
            {
                return yljenable;
            }

            set
            {
                yljenable = value;
            }
        }

        public DateTime Jldate
        {
            get
            {
                return jldate;
            }

            set
            {
                jldate = value;
            }
        }

        public bool Jlenable
        {
            get
            {
                return jlenable;
            }

            set
            {
                jlenable = value;
            }
        }

        private DateTime hxdate;
        private bool hxenable;
        private DateTime gldate;
        private bool glenable;
        private DateTime jsgldate;
        private bool jsglenable;
        private DateTime fxylowdate;
        private bool fxylowenable;
        private DateTime fxyhighdate;
        private bool fxyhighenable;
        private DateTime fxymiddate;
        private bool fxymidenable;
        private DateTime fxylowmiddate;
        private bool fxylowmidenable;
        private DateTime fxyhighmiddate;
        private bool fxyhighmidenable;
        private DateTime yrdate;
        private bool yrenable;
        private DateTime zjdate;
        private bool zjenable;
        private DateTime ydjdate;
        private bool ydjenable;
        private DateTime lljdate;
        private bool lljenable;
        private DateTime sddate;
        private bool sdenable;
        private DateTime hjcsdate;
        private bool hjcsenable;
        private DateTime zsjdate;
        private bool zsjenable;
        private DateTime yljdate;
        private bool yljenable;
        private DateTime jldate;
        private bool jlenable;
        #endregion Model

    }
}

