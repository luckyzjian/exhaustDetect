using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace carinfor
{
    public class inertness
    {
        private string testMethod;//测试方法  0恒力 1 恒功率

        public string TestMethod
        {
            get { return testMethod; }
            set { testMethod = value; }
        }
        private string t1power;//T1加载功率

        public string T1power
        {
            get { return t1power; }
            set { t1power = value; }
        }
        private string t2power;//T2加载功率

        public string T2power
        {
            get { return t2power; }
            set { t2power = value; }
        }
        private string startSpeed;//开始速度

        public string StartSpeed
        {
            get { return startSpeed; }
            set { startSpeed = value; }
        }
        private string endSpeed;//终止速度

        public string EndSpeed
        {
            get { return endSpeed; }
            set { endSpeed = value; }
        }
        private string acd1_1;

        public string Acd1_1
        {
            get { return acd1_1; }
            set { acd1_1 = value; }
        }
        private string acd1_2;

        public string Acd1_2
        {
            get { return acd1_2; }
            set { acd1_2 = value; }
        }
        private string acd1_3;

        public string Acd1_3
        {
            get { return acd1_3; }
            set { acd1_3 = value; }
        }
        private string acd1;

        public string Acd1
        {
            get { return acd1; }
            set { acd1 = value; }
        }
        private string acd2_1;

        public string Acd2_1
        {
            get { return acd2_1; }
            set { acd2_1 = value; }
        }
        private string acd2_2;

        public string Acd2_2
        {
            get { return acd2_2; }
            set { acd2_2 = value; }
        }
        private string acd2_3;

        public string Acd2_3
        {
            get { return acd2_3; }
            set { acd2_3 = value; }
        }
        private string acd2;

        public string Acd2
        {
            get { return acd2; }
            set { acd2 = value; }
        }
        private string diw_1;

        public string Diw_1
        {
            get { return diw_1; }
            set { diw_1 = value; }
        }
        private string diw_2;

        public string Diw_2
        {
            get { return diw_2; }
            set { diw_2 = value; }
        }
        private string diw_3;

        public string Diw_3
        {
            get { return diw_3; }
            set { diw_3 = value; }
        }
        private string diw;//DIW平均值

        public string Diw
        {
            get { return diw; }
            set { diw = value; }
        }
        private string diw_bc;//DIW标称

        public string Diw_bc
        {
            get { return diw_bc; }
            set { diw_bc = value; }
        }
        private string diw_sc;//DIW实测

        public string Diw_sc
        {
            get { return diw_sc; }
            set { diw_sc = value; }
        }
        private string wc;//误差

        public string Wc
        {
            get { return wc; }
            set { wc = value; }
        }
        private string pd;//判定

        public string Pd
        {
            get { return pd; }
            set { pd = value; }
        }
        private string hxsj;//滑行时间

        public string Hxsj
        {
            get { return hxsj; }
            set { hxsj = value; }
        }
        private string bz;//备注

        public string Bz
        {
            get { return bz; }
            set { bz = value; }
        }
        private string bdjg;//0成功，1失败

        public string Bdjg
        {
            get { return bdjg; }
            set { bdjg = value; }
        }

        public string force1_1 { set; get; }
        public string force1_2 { set; get; }
        public string force1_3 { set; get; }
        public string force2_1 { set; get; }
        public string force2_2 { set; get; }
        public string force2_3 { set; get; }
    }
    public class inertnessControl
    {
        public bool writeInertnessIni(inertness inertnessdata)
        {
            try
            {
                if (File.Exists("C:/jcdatatxt/Inertness.ini"))
                {
                    File.Delete("C:/jcdatatxt/Inertness.ini");
                }
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("标定数据", "测试方法", inertnessdata.TestMethod, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "T1加载功率", inertnessdata.T1power, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "T2加载功率", inertnessdata.T2power, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "开始滑行区间", inertnessdata.StartSpeed, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "结束滑行区间", inertnessdata.EndSpeed, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第一次ACD1", inertnessdata.Acd1_1, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第二次ACD1", inertnessdata.Acd1_2, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第三次ACD1", inertnessdata.Acd1_3, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "平均值ACD1", inertnessdata.Acd1, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第一次ACD2", inertnessdata.Acd2_1, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第二次ACD2", inertnessdata.Acd2_2, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第三次ACD2", inertnessdata.Acd2_3, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "平均值ACD2", inertnessdata.Acd2, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第一次DIW", inertnessdata.Diw_1, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第二次DIW", inertnessdata.Diw_2, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "第三次DIW", inertnessdata.Diw_3, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "平均值DIW", inertnessdata.Diw, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标称", inertnessdata.Diw_bc, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "实测", inertnessdata.Diw_sc, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "误差", inertnessdata.Wc, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "判定", inertnessdata.Pd, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "滑行时间", inertnessdata.Hxsj, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "备注说明", inertnessdata.Bz, "C:/jcdatatxt/Inertness.ini");
                ini.INIIO.WritePrivateProfileString("标定数据", "标定结果", inertnessdata.Bdjg, "C:/jcdatatxt/Inertness.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public inertness readInertnessData(string filePath)
        {
            inertness vmas_data = new inertness();
            try
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                if (File.Exists(filePath))
                {
                    ini.INIIO.GetPrivateProfileString("标定数据", "测试方法", "", temp, 2048, filePath);//、
                    vmas_data.TestMethod = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "T1加载功率", "", temp, 2048, filePath);
                    vmas_data.T1power = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "T2加载功率", "", temp, 2048, filePath);
                    vmas_data.T2power = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "开始滑行区间", "", temp, 2048, filePath);
                    vmas_data.StartSpeed = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "结束滑行区间", "", temp, 2048, filePath);
                    vmas_data.EndSpeed = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第一次ACD1", "", temp, 2048, filePath);
                    vmas_data.Acd1_1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第二次ACD1", "", temp, 2048, filePath);
                    vmas_data.Acd1_2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第三次ACD1", "", temp, 2048, filePath);
                    vmas_data.Acd1_3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "平均值ACD1", "", temp, 2048, filePath);
                    vmas_data.Acd1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第一次ACD2", "", temp, 2048, filePath);
                    vmas_data.Acd2_1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第二次ACD2", "", temp, 2048, filePath);
                    vmas_data.Acd2_2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第三次ACD2", "", temp, 2048, filePath);
                    vmas_data.Acd2_3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "平均值ACD2", "", temp, 2048, filePath);
                    vmas_data.Acd2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第一次DIW", "", temp, 2048, filePath);
                    vmas_data.Diw_1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第二次DIW", "", temp, 2048, filePath);
                    vmas_data.Diw_2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "第三次DIW", "", temp, 2048, filePath);
                    vmas_data.Diw_3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "平均值DIW", "", temp, 2048, filePath);
                    vmas_data.Diw = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force11", "", temp, 2048, filePath);
                    vmas_data.force1_1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force12", "", temp, 2048, filePath);
                    vmas_data.force1_2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force13", "", temp, 2048, filePath);
                    vmas_data.force1_3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force21", "", temp, 2048, filePath);
                    vmas_data.force2_1 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force22", "", temp, 2048, filePath);
                    vmas_data.force2_2 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "force23", "", temp, 2048, filePath);
                    vmas_data.force2_3 = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "标称", "", temp, 2048, filePath);
                    vmas_data.Diw_bc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "实测", "", temp, 2048, filePath);
                    vmas_data.Diw_sc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "误差", "", temp, 2048, filePath);
                    vmas_data.Wc = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "判定", "", temp, 2048, filePath);
                    vmas_data.Pd = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "滑行时间", "", temp, 2048, filePath);
                    vmas_data.Hxsj = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "备注说明", "", temp, 2048, filePath);
                    vmas_data.Bz = temp.ToString();
                    ini.INIIO.GetPrivateProfileString("标定数据", "标定结果", "", temp, 2048, filePath);
                    vmas_data.Bdjg = temp.ToString();
                }
                else
                {
                    vmas_data.Bdjg = "-1";
                }
                return vmas_data;
            }
            catch
            {
                vmas_data.Bdjg = "-1";
                return vmas_data;
            }
        }
    }
}
