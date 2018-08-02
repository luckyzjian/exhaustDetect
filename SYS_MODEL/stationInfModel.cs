using System;
using System.Collections.Generic;
using System.Text;

namespace SYS_MODEL
{
    public partial class stationInfModel
    {
        #region model
        private string stationid;

        public string STATIONID
        {
            get { return stationid; }
            set { stationid = value; }
        }
        private string stationname;

        public string STATIONNAME
        {
            get { return stationname; }
            set { stationname = value; }
        }
        private string stationadd;

        public string STATIONADD
        {
            get { return stationadd; }
            set { stationadd = value; }
        }
        private string stationphone;

        public string STATIONPHONE
        {
            get { return stationphone; }
            set { stationphone = value; }
        }
        private string stationperson;

        public string STATIONPERSON
        {
            get { return stationperson; }
            set { stationperson = value; }
        }
        private string stationCompany;
        private string stationdate;

        public string STATIONDATE
        {
            get { return stationdate; }
            set { stationdate = value; }
        }
        private string stationjcff;

        public string STATIONJCFF
        {
            get { return stationjcff; }
            set { stationjcff = value; }
        }
        private string standard;

        public string STANDARD
        {
            get { return standard; }
            set { standard = value; }
        }
        private string stationnet;
        public string STATIONNET
        {
            get { return stationnet; }
            set { stationnet = value; }
        }

        public string StationCompany
        {
            get
            {
                return stationCompany;
            }

            set
            {
                stationCompany = value;
            }
        }

        public string JCZXKZH
        {
            get
            {
                return jczxkzh;
            }

            set
            {
                jczxkzh = value;
            }
        }

        public DateTime YXQSTARTTIME
        {
            get
            {
                return yxqstarttime;
            }

            set
            {
                yxqstarttime = value;
            }
        }

        public DateTime YXQENDTIME
        {
            get
            {
                return yxqendtime;
            }

            set
            {
                yxqendtime = value;
            }
        }

        public bool ISLOCK
        {
            get
            {
                return islock;
            }

            set
            {
                islock = value;
            }
        }

        public string LOCKREASON
        {
            get
            {
                return lockreason;
            }

            set
            {
                lockreason = value;
            }
        }

        public string SBHZBH
        {
            get
            {
                return sbhzbh;
            }

            set
            {
                sbhzbh = value;
            }
        }

        public string CLEARMODE
        {
            get
            {
                return clearmode;
            }

            set
            {
                clearmode = value;
            }
        }

        private string sbhzbh;
        private string jczxkzh;
        private DateTime yxqstarttime;
        private DateTime yxqendtime;
        public DateTime STATIONCOUNTDATE { set; get; }
        public DateTime LOGINCOUNTDATE { set; get; }
        private bool islock;
        private string lockreason;
        private string clearmode;
        //"JJLX","LXR","FZR","ZCSJ"
        public string JJLX { set; get; }
        public string LXR { set; get; }
        public string FZR { set; get; }
        public DateTime ZCSJ { set; get; }
        public string JCXS { set; get; }
        public string LSHRULE { set; get; }
        #endregion
    }
}
