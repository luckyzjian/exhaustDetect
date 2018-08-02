using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace carinfor
{
    public class jzjsdata
    {
        private string carID;

        public string CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private string sd;

        public string Sd
        {
            get { return sd; }
            set { sd = value; }
        }
        private string wd;

        public string Wd
        {
            get { return wd; }
            set { wd = value; }
        }
        private string dqy;

        public string Dqy
        {
            get { return dqy; }
            set { dqy = value; }
        }
        private string gxsxs_100;

        public string Gxsxs_100
        {
            get { return gxsxs_100; }
            set { gxsxs_100 = value; }
        }
        private string gxsxs_90;

        public string Gxsxs_90
        {
            get { return gxsxs_90; }
            set { gxsxs_90 = value; }
        }
        private string gxsxs_80;

        public string Gxsxs_80
        {
            get { return gxsxs_80; }
            set { gxsxs_80 = value; }
        }
        private string lbgl;
        /// <summary>
        /// 修正最大轮边功率
        /// </summary>
        public string Lbgl
        {
            get { return lbgl; }
            set { lbgl = value; }
        }
        private string lbzs;

        public string Lbzs
        {
            get { return lbzs; }
            set { lbzs = value; }
        }
        private string velmaxhp;
        /// <summary>
        /// 实际MAXHP时滚筒线速度
        /// </summary>
        public string Velmaxhp
        {
            get { return velmaxhp; }
            set { velmaxhp = value; }
        }
        private string velmaxhpzs;
        /// <summary>
        /// 轮边功率转速
        /// </summary>
        public string Velmaxhpzs
        {
            get { return velmaxhpzs; }
            set { velmaxhpzs = value; }
        }
        private string realVelmaxhp;
        /// <summary>
        /// 计算MAXHP时滚筒线速度
        /// </summary>
        public string RealVelmaxhp
        {
            get { return realVelmaxhp; }
            set { realVelmaxhp = value; }
        }
        private string rev100;

        public string Rev100
        {
            get { return rev100; }
            set { rev100 = value; }
        }
        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        /// <summary>
        /// 功率修正系数
        /// </summary>
        public string glxzxs { set; get; }
        /// <summary>
        /// 实测最大轮边功率
        /// </summary>
        public string actualmaxhp { set; get; }
        private string stopReason;

        public string StopReason
        {
            get { return stopReason; }
            set { stopReason = value; }
        }
        public string hno { set; get; }
        public string nno { set; get; }
        public string eno { set; get; }
    }
    public class jzjsdataControl
    {
        
        public jzjsdata readJzjsData(string filePath)
        {
            jzjsdata jzjs_data = new jzjsdata();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("检测结果", "车辆ID", "", temp, 2048, filePath);
                    jzjs_data.CarID = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "相对湿度", "", temp, 2048, filePath);
                    jzjs_data.Sd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "环境温度", "", temp, 2048, filePath);
                    jzjs_data.Wd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "大气压力", "", temp, 2048, filePath);
                    jzjs_data.Dqy = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值1", "", temp, 2048, filePath);
                    jzjs_data.Gxsxs_100 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值2", "", temp, 2048, filePath);
                    jzjs_data.Gxsxs_90 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值3", "", temp, 2048, filePath);
                    jzjs_data.Gxsxs_80 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值4", "", temp, 2048, filePath);
                    jzjs_data.Lbgl = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "数值5", "", temp, 2048, filePath);
                    jzjs_data.Lbzs = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "actualmaxhp", "", temp, 2048, filePath);
                    jzjs_data.actualmaxhp = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "VELMAXHP", "", temp, 2048, filePath);
                    jzjs_data.Velmaxhp = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "REALVELMAXHP", "", temp, 2048, filePath);
                    jzjs_data.RealVelmaxhp = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "VELMAXHPZS", "", temp, 2048, filePath);
                    jzjs_data.Velmaxhpzs = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "GLXZXS", "", temp, 2048, filePath);
                    jzjs_data.glxzxs = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "Rev100", "", temp, 2048, filePath);
                    jzjs_data.Rev100 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StartTime", "", temp, 2048, filePath);
                    jzjs_data.StartTime = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "StopReason", "", temp, 2048, filePath);
                    jzjs_data.StopReason = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "hno", "0", temp, 2048, filePath);
                    jzjs_data.hno = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "nno", "0", temp, 2048, filePath);
                    jzjs_data.nno = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("检测结果", "eno", "0", temp, 2048, filePath);
                    jzjs_data.eno = temp.ToString();
                }
                else
                {
                    jzjs_data.CarID = "-1";
                }
                return jzjs_data;
            }
            catch
            {
                jzjs_data.CarID = "-1";
                return jzjs_data;
            }
        }
    }
    
}
