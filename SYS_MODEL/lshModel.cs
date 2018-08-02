using System;
using System.Collections.Generic;
using System.Text;

namespace SYS_MODEL
{
    public partial class lshModel
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
        private DateTime date;

        public DateTime DATE
        {
            get { return date; }
            set { date = value; }
        }
        private string count;

        public string COUNT
        {
            get { return count; }
            set { count = value; }
        }
        
        #endregion
    }
}
