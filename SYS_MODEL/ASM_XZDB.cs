using System;
namespace SYS.Model
{
    /// <summary>
    /// ASM_XZDB:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ASM_GDXZ
    {
        public string ID { set; get; }
        public string CO25 { set; get; }
        public string HC25 { set; get; }
        public string NO25 { set; get; }
        public string CO40 { set; get; }
        public string HC40 { set; get; }
        public string NO40 { set; get; }
    }
    public partial class ASM_XZDB
    {
        public ASM_XZDB()
        { }
        #region Model
        private int _id;
        private double _5025hc;

        public double HC5025
        {
            get { return _5025hc; }
            set { _5025hc = value; }
        }
        private double _5025co;

        public double CO5025
        {
            get { return _5025co; }
            set { _5025co = value; }
        }
        private double _5025no;

        public double NO5025
        {
            get { return _5025no; }
            set { _5025no = value; }
        }
        private double _2540hc;

        public double HC2540
        {
            get { return _2540hc; }
            set { _2540hc = value; }
        }
        private double _2540co;

        public double CO2540
        {
            get { return _2540co; }
            set { _2540co = value; }
        }
        private double _2540no;

        public double NO2540
        {
            get { return _2540no; }
            set { _2540no = value; }
        }
        private double _5025hcH;

        public double HC5025H
        {
            get { return _5025hcH; }
            set { _5025hcH = value; }
        }
        private double _5025coH;

        public double CO5025H
        {
            get { return _5025coH; }
            set { _5025coH = value; }
        }
        private double _5025noH;

        public double NO5025H
        {
            get { return _5025noH; }
            set { _5025noH = value; }
        }
        private double _2540hcH;

        public double HC2540H
        {
            get { return _2540hcH; }
            set { _2540hcH = value; }
        }
        private double _2540coH;

        public double CO2540H
        {
            get { return _2540coH; }
            set { _2540coH = value; }
        }
        private double _2540noH;

        public double NO2540H
        {
            get { return _2540noH; }
            set { _2540noH = value; }
        }
        private double qxco5025;

        public double Qxco5025
        {
            get { return qxco5025; }
            set { qxco5025 = value; }
        }
        private double qxhc5025;

        public double Qxhc5025
        {
            get { return qxhc5025; }
            set { qxhc5025 = value; }
        }
        private double qxno5025;

        public double Qxno5025
        {
            get { return qxno5025; }
            set { qxno5025 = value; }
        }
        private double qxco2540;

        public double Qxco2540
        {
            get { return qxco2540; }
            set { qxco2540 = value; }
        }
        private double qxhc2540;

        public double Qxhc2540
        {
            get { return qxhc2540; }
            set { qxhc2540 = value; }
        }
        private double qxno2540;

        public double Qxno2540
        {
            get { return qxno2540; }
            set { qxno2540 = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        #endregion Model

    }
}

