using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class workLogData
    {
        private string projectID;

        public string ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string stationid;

        public string Stationid
        {
            get { return stationid; }
            set { stationid = value; }
        }
        private string lineid;

        public string Lineid
        {
            get { return lineid; }
            set { lineid = value; }
        }
        private string czy;

        public string Czy
        {
            get { return czy; }
            set { czy = value; }
        }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string bzsm;

        public string Bzsm
        {
            get { return bzsm; }
            set { bzsm = value; }
        }
    }
    
}
