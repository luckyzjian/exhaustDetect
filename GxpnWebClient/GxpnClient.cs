using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using ini;

namespace GxpnWebClient
{
    public class GxpnClient
    {
        public bool JK_Status { get { return jk_status; } }

        private bool jk_status = false;
        private VIToken vit = new VIToken();
        private JkDemo webservices = null;
        private string cityCode = "", stationCode = "", lineCode = "", factoryNo = "";

        /// <summary>
        /// 联网接口初始化
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="user">接口用户名</param>
        /// <param name="pwd">接口用户密码</param>
        public GxpnClient(string url, string user, string pwd, string cityCode, string stationCode, string lineCode, string factoryNo)
        {
            this.cityCode = cityCode;
            this.stationCode = stationCode;
            this.lineCode = lineCode;
            this.factoryNo = factoryNo;
            webservices = new JkDemo(url);
            vit.GuidString = webservices.Login(user, pwd);
            if (vit.GuidString == "")
                jk_status = false;
            else
                jk_status = true;
        }

        public string GetSystemTime()
        {
            if (jk_status == false)
                return "";
            try
            {
                ResultData result = getUploadResult(webservices.GetDateTimeNow(vit), false);
                if (result != null && result.Success && result.Error == "")
                    return (string)result.Data;
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取受理信息（待检车辆列表）
        /// </summary>
        /// <param name="jcff">检测方法（ A双怠速/B稳态/C简易瞬态/D瞬态/E滤纸烟度/F不透光烟度/G加载减速/H怠速/I急加速）</param>
        /// <param name="dt_WaitCarList">输出待检车辆表</param>
        /// <param name="errorInf">输出错误信息</param>
        /// <returns>是否成功</returns>
        public bool GetVehicleList(string jcff, out DataTable dt_WaitCarList, out string errorInf)
        {
            dt_WaitCarList = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                ResultData result = getUploadResult(webservices.DownloadAcceptance(vit, cityCode, stationCode, lineCode, jcff, factoryNo), true);
                if (result != null)
                {
                    errorInf = "Success:" + result.Success + "|Error:" + result.Error;
                    if (result.Success && result.Error == "" && (DataTable)result.Data != null)
                    {
                        dt_WaitCarList = (DataTable)result.Data;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检测开始或结束
        /// </summary>
        /// <param name="isStart">true为开始、false为结束</param>
        /// <param name="jylsh">检测编号（检验流水号）</param>
        /// <param name="uniqueStr">车辆唯一标识（VIN）</param>
        /// <param name="errorInf">错误信息</param>
        /// <returns>是否成功</returns>
        public bool StartOrStopTest(bool isStart, string jylsh, string uniqueStr, out string errorInf)
        {
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {

                ResultData result = getUploadResult(webservices.UpInspectionSignal(vit, stationCode, jylsh, lineCode, uniqueStr, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), isStart ? "start" : "stop"), false);
                if (result != null)
                {
                    if (result.Success && result.Error == "")
                        return true;
                    else
                    {
                        errorInf = "Success:" + result.Success + "|Error:" + result.Error;
                        return false;
                    }
                }
                else
                {
                    errorInf = "返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool GetCarInfo(string jcff, string jylsh, out DataTable dt_CarInfo, out string errorInf)
        {
            dt_CarInfo = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                ResultData result = getUploadResult(webservices.DownloadVehicle(vit, stationCode, jylsh, lineCode, jcff), true);
                if (result != null)
                {
                    errorInf = "Success:" + result.Success + "|Error:" + result.Error;
                    if (result.Success && result.Error == "" && (DataTable)result.Data != null)
                    {
                        dt_CarInfo = (DataTable)result.Data;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UploadMainTestInfo()
        {
            return true;
        }

        #region 格式转换相关
        public string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"UTF-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            newstring = newstring.Replace("\r\n", "");
            newstring = Regex.Replace(newstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号            

            return newstring;
        }

        /// <summary>
        /// 解析收到的信息
        /// </summary>
        /// <param name="receive_Xml">收到的xml信息</param>
        /// <param name="is_dt">Data数据是否为表格</param>
        /// <returns>返回结果类（Data可能包含表信息（用Data.DataSet.Tables["表名"]取出数据，如待检车辆列表：DataTable dt = ResultData.Data.DataSet.Tables["AcceptanceType"]））</returns>
        public ResultData getUploadResult(string receive_Xml,bool is_dt)
        {
            ResultData results = new ResultData();
            if (receive_Xml == "")
                return null;
            try
            {
                string revXml = ini.INIIO.decodeUTF8(receive_Xml);
                INIIO.saveSocketLogInf("【已接收数据解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);

                results.Success = (bool)ds.Tables["ResultData"].Rows[0]["Success"];
                results.Error = ds.Tables["ResultData"].Rows[0]["Error"].ToString();
                if(is_dt)
                    results.Data = ds.Tables["Data"];
                else
                    results.Data = ds.Tables["ResultData"].Rows[0]["Data"].ToString();

                return results;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }

    public class VIToken
    {
        public string GuidString = "";
    }

    public class ResultData
    {
        public bool Success { get { return success; }set { success = value; } }
        public string Error { get { return error; } set { error = value; } }
        public object Data { get { return data; } set { data = value; } }

        private bool success = false;
        private string error = "";
        private object data = null;
    }

    public class JkDemo
    {
        private string url;
        public JkDemo(string url)
        {
            this.url = url;
        }
        public string Login(String userName, String password)
        {
            return "";
        }
        public string GetDateTimeNow(VIToken vit)
        {
            return "";
        }
        public string DownloadAcceptance(VIToken vit, String cityCode, String stationCode, String lineCode, String inspectionMethod, String factoryNo)
        { return ""; }
        public string UpInspectionSignal(VIToken vit, String stationCode, String inspectionNum, String lineCode, String uniqueString, String time, String startOrEnd)
        { return ""; }
        public string DownloadVehicle(VIToken vit, String stationCode, String inspectionNum, String lineCode, String inspectionMethod)
        { return ""; }
        public string UploadInspectionData(VIToken vit, String body)
        { return ""; }
        public string UploadASMData(VIToken vit, String body)
        { return ""; }
        public string UploadASMProcessData(VIToken vit, String body)
        { return ""; }
        public string UploadTSIData(VIToken vit, String body)
        { return ""; }
        public string UploadLDData(VIToken vit, String body)
        { return ""; }
        public string UploadLDProcessData(VIToken vit, String body)
        { return ""; }
        public string FilterSmokeData(VIToken vit, String body)
        { return ""; }
        public string UploadLightProofSmokeData(VIToken vit, String body)
        { return ""; }
        public string GetParamLimitData(VIToken vit, String stationCode, String inspectionNum, String lineCode, String inspectionMethod)
        { return ""; }
        public string DownloadAcceptanceData(VIToken vit, String cityCode, String stationCode, String lineCode, String inspectionMethod, String startTime, String endTime, int top, String factoryNo)
        { return ""; }
        public string UploadLineCheckPetrol(VIToken vit, String body)
        { return ""; }
        public string UpLoadLineCheckDiesel(VIToken vit, String body)
        { return ""; }
        public string DownloadStationStaff(VIToken vit, String cityCode, String stationCode)
        { return ""; }
        public string UploadStationDeviceStatus(VIToken vit, String body)
        { return ""; }
        public string UploadEnvParamSensor(VIToken vit, String body)
        { return ""; }
        public string UploadDynamometerSelfCheck(VIToken vit, String body)
        { return ""; }
        public string UploadParasiticPowerSelfCheck(VIToken vit, String body)
        { return ""; }
        public string UploadFlowmeterSelfCheck(VIToken vit, String body)
        { return ""; }
        public string UploadGasAnalyzerSelfCheck(VIToken vit, String body)
        { return ""; }
        public string UploadLightProofSmokeSelfCheck(VIToken vit, String body)
        { return ""; }
        public string UploadTSIGasAnalyzerSelfCheck(VIToken vit, String body)
        { return ""; }
    }
}
