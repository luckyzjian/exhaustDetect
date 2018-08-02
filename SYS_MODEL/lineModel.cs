using System;
using System.Collections.Generic;
using System.Text;

namespace SYS_MODEL
{
    public partial class lineModel
    {
        #region model
        private string stationID;

        public string StationID
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
        private string asm;

        public string ASM
        {
            get { return asm; }
            set { asm = value; }
        }
        private string vmas;

        public string VMAS
        {
            get { return vmas; }
            set { vmas = value; }
        }
        private string sds;

        public string SDS
        {
            get { return sds; }
            set { sds = value; }
        }
        private string jzjs_light;

        public string JZJS_LIGHT
        {
            get { return jzjs_light; }
            set { jzjs_light = value; }
        }
        private string jzjs_heavy;

        public string JZJS_HEAVY
        {
            get { return jzjs_heavy; }
            set { jzjs_heavy = value; }
        }
        private string zyjs;

        public string ZYJS
        {
            get { return zyjs; }
            set { zyjs = value; }
        }
        private string lz;

        public string LZ
        {
            get { return lz; }
            set { lz = value; }
        }
        private string printer;

        public string PRINTER
        {
            get { return printer; }
            set { printer = value; }
        }
        private string autoprint;

        public string AUTOPRINT
        {
            get { return autoprint; }
            set { autoprint = value; }
        }

        public string JCXXKZBH
        {
            get
            {
                return jcxxkzbh;
            }

            set
            {
                jcxxkzbh = value;
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

        private string jcxxkzbh;
        private DateTime yxqstarttime;
        private DateTime yxqendtime;
        private bool islock;
        private string lockreason;    
        #endregion
    }
}
