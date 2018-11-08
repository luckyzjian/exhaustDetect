using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using ini;

namespace GxpnWebClient
{
    public class GxpnClient
    {
        public Dictionary<string, string> PN_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> PNR_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> PN_vlpncolor = new Dictionary<string, string>();
        public Dictionary<string, string> PN_hpzl = new Dictionary<string, string>();
        public Dictionary<string, string> PN_vehiclebigtype = new Dictionary<string, string>();
        public Dictionary<string, string> PN_pg = new Dictionary<string, string>();
        public Dictionary<string, string> PN_vehicletype = new Dictionary<string, string>();
        public Dictionary<string, string> PN_variableform = new Dictionary<string, string>();
        public Dictionary<string, string> PN_ocha = new Dictionary<string, string>();
        public Dictionary<string, string> PN_useofauto = new Dictionary<string, string>();
        public Dictionary<string, string> PN_intakeway = new Dictionary<string, string>();
        public Dictionary<string, string> PN_fueltype = new Dictionary<string, string>();
        public Dictionary<string, string> PN_oilsupplyway = new Dictionary<string, string>();
        public Dictionary<string, string> PN_driveform = new Dictionary<string, string>();
        public Dictionary<string, string> PN_hascca = new Dictionary<string, string>();
        public Dictionary<string, string> PN_hasoxygensensor = new Dictionary<string, string>();
        public Dictionary<string, string> PN_hasobd = new Dictionary<string, string>();
        public Dictionary<string, string> PN_isdoublefuel = new Dictionary<string, string>();
        public Dictionary<string, string> PN_inspectionnature = new Dictionary<string, string>();

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
            #region 名称代码初始化
            PN_inspectionnature.Add("01", "初检");
            PN_inspectionnature.Add("02", "复检");
            PN_inspectionnature.Add("03", "多检");

            PN_inspectionmethod.Add("A", "SDS");
            PN_inspectionmethod.Add("B", "ASM");
            PN_inspectionmethod.Add("C", "VMAS");
            PN_inspectionmethod.Add("D", "瞬态");
            PN_inspectionmethod.Add("E", "LZ");
            PN_inspectionmethod.Add("F", "ZYJS");
            PN_inspectionmethod.Add("G", "JZJS");
            PN_inspectionmethod.Add("H", "怠速");
            PN_inspectionmethod.Add("I", "急加速");

            PNR_inspectionmethod.Add("SDS", "A");
            PNR_inspectionmethod.Add("ASM", "B");
            PNR_inspectionmethod.Add("VMAS", "C");
            PNR_inspectionmethod.Add("瞬态", "D");
            PNR_inspectionmethod.Add("LZ", "E");
            PNR_inspectionmethod.Add("ZYJS", "F");
            PNR_inspectionmethod.Add("JZJS", "G");
            PNR_inspectionmethod.Add("怠速", "H");
            PNR_inspectionmethod.Add("急加速", "I");

            PN_vlpncolor.Add("01", "蓝色");
            PN_vlpncolor.Add("02", "黄色");
            PN_vlpncolor.Add("03", "黑色");
            PN_vlpncolor.Add("04", "白色");
            PN_vlpncolor.Add("05", "无");


            PN_hpzl.Add("01", "大型汽车号牌");
            PN_hpzl.Add("02", "小型汽车号牌");
            PN_hpzl.Add("03", "使馆汽车号牌");
            PN_hpzl.Add("04", "领馆汽车号牌");
            PN_hpzl.Add("05", "境外汽车号牌");
            PN_hpzl.Add("06", "外籍汽车号牌");
            PN_hpzl.Add("07", "两、三轮摩托车号牌");
            PN_hpzl.Add("08", "轻便摩托车号牌");
            PN_hpzl.Add("09", "使馆摩托车号牌");
            PN_hpzl.Add("10", "领馆摩托车号牌");
            PN_hpzl.Add("11", "境外摩托车号牌");
            PN_hpzl.Add("12", "外籍摩托车号牌");
            PN_hpzl.Add("13", "农用运输车号牌");
            PN_hpzl.Add("14", "拖拉机号牌");
            PN_hpzl.Add("15", "挂车号牌");
            PN_hpzl.Add("16", "教练汽车号牌");
            PN_hpzl.Add("17", "教练摩托车号牌");
            PN_hpzl.Add("18", "试验汽车号牌");
            PN_hpzl.Add("19", "试验摩托车号牌");
            PN_hpzl.Add("20", "临时人境汽车号牌");
            PN_hpzl.Add("21", "临时人境摩托车号牌");
            PN_hpzl.Add("22", "临时行驶车号牌");
            PN_hpzl.Add("23", "警用汽车号牌");
            PN_hpzl.Add("24", "警用摩托号牌");
            PN_hpzl.Add("99", "其他号牌");

            PN_vehiclebigtype.Add("01", "汽车");
            PN_vehiclebigtype.Add("02", "摩托车");
            PN_vehiclebigtype.Add("03", "低速汽车");

            PN_pg.Add("01", "客车");
            PN_pg.Add("02", "货车");

            PN_vehicletype.Add("01", "微型");
            PN_vehicletype.Add("02", "小型(轻型)");
            PN_vehicletype.Add("03", "中型");
            PN_vehicletype.Add("04", "大型(重型)");
            PN_vehicletype.Add("05", "轻便型摩托车");
            PN_vehicletype.Add("06", "摩托车");
            PN_vehicletype.Add("07", "低速汽车");

            PN_variableform.Add("01", "手动");
            PN_variableform.Add("02", "自动");
            PN_variableform.Add("03", "手自一体");

            PN_ocha.Add("01", "运营");
            PN_ocha.Add("02", "非运营");

            PN_useofauto.Add("A", "非营运");
            PN_useofauto.Add("B", "公路客运");
            PN_useofauto.Add("C", "公交客运");
            PN_useofauto.Add("D", "出租客运");
            PN_useofauto.Add("E", "旅游客运");
            PN_useofauto.Add("F", "货运");
            PN_useofauto.Add("G", "租赁");
            PN_useofauto.Add("H", "警用");
            PN_useofauto.Add("I", "消防");
            PN_useofauto.Add("J", "救护");
            PN_useofauto.Add("K", "工程抢险");
            PN_useofauto.Add("L", "营转非");
            PN_useofauto.Add("M", "出租转非");
            PN_useofauto.Add("Z", "其他");

            PN_intakeway.Add("01", "自然吸气");
            PN_intakeway.Add("02", "涡轮增压");

            PN_fueltype.Add("A", "汽油");
            PN_fueltype.Add("B", "柴油");
            PN_fueltype.Add("C", "电");
            PN_fueltype.Add("D", "混合油");
            PN_fueltype.Add("E", "天然气");
            PN_fueltype.Add("F", "液化石油气");
            PN_fueltype.Add("L", "甲醇");
            PN_fueltype.Add("M", "乙醇");
            PN_fueltype.Add("N", "太阳能");
            PN_fueltype.Add("O", "混合动力");
            PN_fueltype.Add("Y", "无");
            PN_fueltype.Add("Z", "其他");
            PN_fueltype.Add("A1", "油改气");


            PN_oilsupplyway.Add("01", "化油器");
            PN_oilsupplyway.Add("02", "闭环电喷");
            PN_oilsupplyway.Add("03", "开环电喷");
            PN_oilsupplyway.Add("04", "直喷");
            PN_oilsupplyway.Add("05", "混合喷射");

            PN_driveform.Add("01", "前驱");
            PN_driveform.Add("02", "后驱");
            PN_driveform.Add("03", "四驱");

            PN_hascca.Add("1", "有");
            PN_hascca.Add("0", "没有");
            PN_hasoxygensensor.Add("1", "有");
            PN_hasoxygensensor.Add("0", "没有");
            PN_hasobd.Add("1", "有");
            PN_hasobd.Add("0", "没有");
            PN_isdoublefuel.Add("1", "有");
            PN_isdoublefuel.Add("0", "否");
            #endregion

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
                INIIO.saveSocketLogInf("【开始同步系统时间】\r\n");
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
                INIIO.saveSocketLogInf("【获取受理信息】：lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
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
        /// 根据时间段下载受理信息（默认下载该时间段的所有信息）
        /// </summary>
        /// <param name="StartTime">时间段起始时间</param>
        /// <param name="EndTime">时间段结束时间</param>
        /// <param name="jcff">检测方法</param>
        /// <param name="dt_WaitCarList">查询到的待检车辆信息</param>
        /// <param name="errorInf">查询错误信息</param>
        /// <returns></returns>
        public bool GetVehicleListByTime(DateTime StartTime, DateTime EndTime, string jcff, out DataTable dt_WaitCarList, out string errorInf)
        {
            dt_WaitCarList = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                INIIO.saveSocketLogInf("【获取受理信息】：lineCode:" + lineCode + "|jcff:" + jcff + "|StartTime:" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "|EndTime:" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                ResultData result = getUploadResult(webservices.DownloadAcceptanceData(vit, cityCode, stationCode, lineCode, jcff, StartTime.ToString("yyyy-MM-dd HH:mm:ss"), EndTime.ToString("yyyy-MM-dd HH:mm:ss"), 0, factoryNo), true);
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
                INIIO.saveSocketLogInf("【发送检测开始或结束信号】：jylsh:" + jylsh + "|lineCode:" + lineCode + "|uniqueStr:" + uniqueStr + "|" + (isStart ? "start" : "stop") + "\r\n");
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
                INIIO.saveSocketLogInf("【获取车辆信息】：jylsh:" + jylsh + "|lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
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

        public bool UploadMainTestInfo(Hashtable model, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe = xmldoc.CreateElement("Data");//创建一个<Node>节点
                XmlElement xe0 = xmldoc.CreateElement("InspectionData");//创建一个<Node>节点
                XmlElement xe1 = xmldoc.CreateElement("StationCode");
                xe1.InnerText = stationCode;
                XmlElement xe2 = xmldoc.CreateElement("CityCode");
                xe2.InnerText = cityCode;
                XmlElement xe3 = xmldoc.CreateElement("CountyCode");
                //xe3.InnerText = ;
                xe0.AppendChild(xe1);
                xe0.AppendChild(xe2);
                xe0.AppendChild(xe3);
                foreach (string key in model.Keys)
                {
                    XmlElement xe_n = xmldoc.CreateElement(key);
                    xe_n.InnerText = model[key].ToString();
                    xe0.AppendChild(xe_n);
                }
                xe.AppendChild(xe0);
                root.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_主检测信息上传(UploadInspectionData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadInspectionData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        /// <summary>
        /// 发送检测数据（含检测结果及检测过程数据）
        /// </summary>
        /// <param name="jcff">检测方法（ASM、SDS、JZJS、LZ、ZYJS）</param>
        /// <param name="r_or_p">true时为结果数据，false时为过程数据</param>
        /// <param name="hash_dt">哈希数据表（List<Hashtable> hash_dt为结果数据时只有一个元素、为过程数据时每个元素为一秒数据）</param>
        /// <param name="errorInf">发送后返回的错误信息</param>
        /// <returns></returns>
        public bool UploadTestData(string jcff, bool r_or_p, List<Hashtable> hash_dt, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                string bodyName = "";
                int interface_kind = 0;

                if (r_or_p)
                {
                    //r_or_p==true时，发送结果数据
                    switch (jcff)
                    {
                        case "ASM":
                            bodyName = "ASMType";
                            interface_kind = 1;
                            break;
                        case "SDS":
                            bodyName = "TSIType";
                            interface_kind = 2;
                            break;
                        case "JZJS":
                            bodyName = "LDType";
                            interface_kind = 3;
                            break;
                        case "LZ":
                            bodyName = "FilterSmokeData";
                            interface_kind = 4;
                            break;
                        case "ZYJS":
                            bodyName = "LightProofSmokeData";
                            interface_kind = 5;
                            break;
                        default:
                            errorInf = "不存在的结果数据上传接口";
                            return false;
                    }
                }
                else
                {
                    //r_or_p==true时，发送过程数据
                    switch (jcff)
                    {
                        case "ASM":
                            bodyName = "ASMProcessType";
                            interface_kind = 6;
                            break;
                        case "JZJS":
                            bodyName = "LDProcessType";
                            interface_kind = 7;
                            break;
                        default:
                            errorInf = "不存在的过程数据上传接口";
                            return false;
                    }
                }

                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees>
                XmlElement xe = xmldoc.CreateElement("Data");//创建一个<Node>节点
                for (int i = 0; i < hash_dt.Count; i++)
                {
                    XmlElement xe0 = xmldoc.CreateElement(bodyName);//创建一个<Node>节点
                    foreach (string key in hash_dt[i].Keys)
                    {
                        XmlElement xe_n = xmldoc.CreateElement(key);
                        xe_n.InnerText = hash_dt[i][key].ToString();
                        xe0.AppendChild(xe_n);
                    }
                    xe.AppendChild(xe0);
                }
                root.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_检测数据上传(" + bodyName + ")】\r\n" + xmlstring);
                ResultData result = null;
                switch (interface_kind)
                {
                    case 1://ASM_Result
                        result = getUploadResult(webservices.UploadASMData(vit, xmlstring), true);
                        break;
                    case 2://SDS_Result
                        result = getUploadResult(webservices.UploadTSIData(vit, xmlstring), true);
                        break;
                    case 3://JZJS_Result
                        result = getUploadResult(webservices.UploadLDData(vit, xmlstring), true);
                        break;
                    case 4://LZ_Result
                        result = getUploadResult(webservices.UploadFilterSmokeData(vit, xmlstring), true);
                        break;
                    case 5://ZYJS_Result
                        result = getUploadResult(webservices.UploadLightProofSmokeData(vit, xmlstring), true);
                        break;
                    case 6://ASM_Process
                        result = getUploadResult(webservices.UploadASMProcessData(vit, xmlstring), true);
                        break;
                    case 7://JZJS_Process
                        result = getUploadResult(webservices.UploadLDProcessData(vit, xmlstring), true);
                        break;
                }

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
            catch (Exception er)
            {
                errorInf = "执行上传检测数据错误：" + er.Message;
                return false;
            }
        }

        public bool GetXZ(string jcff, string jylsh, out DataTable dt_XZ, out string errorInf)
        {
            dt_XZ = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                INIIO.saveSocketLogInf("【获取检测限值】：jylsh:" + jylsh + "|lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
                ResultData result = getUploadResult(webservices.GetParamLimitData(vit, stationCode, jylsh, lineCode, jcff), true);
                if (result != null)
                {
                    errorInf = "Success:" + result.Success + "|Error:" + result.Error;
                    if (result.Success && result.Error == "" && (DataTable)result.Data != null)
                    {
                        dt_XZ = (DataTable)result.Data;
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

        public bool GetUsers(out DataTable dt_Users, out string errorInf)
        {
            dt_Users = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                INIIO.saveSocketLogInf("【获取人员信息】\r\n");
                ResultData result = getUploadResult(webservices.DownloadStationStaff(vit, cityCode, stationCode), true);
                if (result != null)
                {
                    errorInf = "Success:" + result.Success + "|Error:" + result.Error;
                    if (result.Success && result.Error == "" && (DataTable)result.Data != null)
                    {
                        dt_Users = (DataTable)result.Data;
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

        public bool UploadBdZjData(int ZjBdKind, Hashtable hash_dt, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成XML数据
                string bodyName = "", nodeName = "";
                switch (ZjBdKind)
                {
                    case 1://汽油线标定
                        bodyName = "LineCheckPetrols";
                        nodeName = "LineCheckPetrol";
                        break;
                    case 2://柴油线标定
                        bodyName = "LineCheckDiesels";
                        nodeName = "LineCheckDiesel";
                        break;
                    case 3://检测线设备状态
                        bodyName = "StationDeviceStatuss";
                        nodeName = "StationDeviceStatus";
                        break;
                    case 4://环境参数校准
                        bodyName = "EnvParamSensors";
                        nodeName = "EnvParamSensor";
                        break;
                    case 5://测功机自检
                        bodyName = "DynamometerSelfChecks";
                        nodeName = "DynamometerSelfCheck";
                        break;
                    case 6://寄生功率自检
                        bodyName = "ParasiticPowerSelfChecks";
                        nodeName = "ParasiticPowerSelfCheck";
                        break;
                    case 7://流量计自检
                        bodyName = "FlowmeterSelfChecks";
                        nodeName = "FlowmeterSelfCheck";
                        break;
                    case 8://五气分析仪自检
                        bodyName = "GasAnalyzerSelfChecks";
                        nodeName = "GasAnalyzerSelfCheck";
                        break;
                    case 9://烟度计自检
                        bodyName = "LightProofSmokeSelfChecks";
                        nodeName = "LightProofSmokeSelfCheck";
                        break;
                    case 10://双怠速气体分析仪自检
                        bodyName = "TSIGasAnalyzerSelfChecks";
                        nodeName = "TSIGasAnalyzerSelfCheck";
                        break;
                    default:
                        errorInf = "输入自检、标定类别有误";
                        return false;
                }

                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees>
                XmlElement xe = xmldoc.CreateElement(bodyName);//创建一个<Node>节点
                XmlElement xe0 = xmldoc.CreateElement(nodeName);//创建一个<Node>节点
                foreach (string key in hash_dt.Keys)
                {
                    XmlElement xe_n = xmldoc.CreateElement(key);
                    xe_n.InnerText = hash_dt[key].ToString();
                    xe0.AppendChild(xe_n);
                }
                xe.AppendChild(xe0);
                root.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_自检标定数据上传(" + bodyName + ")】\r\n" + xmlstring);
                ResultData result = null;
                switch (ZjBdKind)
                {
                    case 1:
                        result = getUploadResult(webservices.UploadLineCheckPetrol(vit, xmlstring), false);
                        break;
                    case 2:
                        result = getUploadResult(webservices.UpLoadLineCheckDiesel(vit, xmlstring), false);
                        break;
                    case 3:
                        result = getUploadResult(webservices.UploadStationDeviceStatus(vit, xmlstring), false);
                        break;
                    case 4:
                        result = getUploadResult(webservices.UploadEnvParamSensor(vit, xmlstring), false);
                        break;
                    case 5:
                        result = getUploadResult(webservices.UploadDynamometerSelfCheck(vit, xmlstring), false);
                        break;
                    case 6:
                        result = getUploadResult(webservices.UploadParasiticPowerSelfCheck(vit, xmlstring), false);
                        break;
                    case 7:
                        result = getUploadResult(webservices.UploadFlowmeterSelfCheck(vit, xmlstring), false);
                        break;
                    case 8:
                        result = getUploadResult(webservices.UploadGasAnalyzerSelfCheck(vit, xmlstring), false);
                        break;
                    case 9:
                        result = getUploadResult(webservices.UploadLightProofSmokeSelfCheck(vit, xmlstring), false);
                        break;
                    case 10:
                        result = getUploadResult(webservices.UploadTSIGasAnalyzerSelfCheck(vit, xmlstring), false);
                        break;
                }

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
            catch (Exception er)
            {
                errorInf = er.Message;
                return false;
            }
        }

        #region 放弃代码
        /*
        public bool UploadAsmResult(AsmResult model, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 
                XmlElement xe = xmldoc.CreateElement("ASMType");//创建一个<Node>节点
                XmlElement xe1 = xmldoc.CreateElement("StationCode");
                xe1.InnerText = stationCode;
                XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                xe2.InnerText = model.InspectionNum;
                XmlElement xe3 = xmldoc.CreateElement("HCEL5025");
                xe3.InnerText = model.HCEL5025;
                XmlElement xe4 = xmldoc.CreateElement("HCER5025");
                xe4.InnerText = model.HCER5025;
                XmlElement xe5 = xmldoc.CreateElement("HCED5025");
                xe5.InnerText = model.HCED5025;
                XmlElement xe6 = xmldoc.CreateElement("HCEL2540");
                xe6.InnerText = model.HCEL2540;
                XmlElement xe7 = xmldoc.CreateElement("HCER2540");
                xe7.InnerText = model.HCER2540;
                XmlElement xe8 = xmldoc.CreateElement("HCED2540");
                xe8.InnerText = model.HCED2540;
                XmlElement xe9 = xmldoc.CreateElement("COEL5025");
                xe9.InnerText = model.COEL5025;
                XmlElement xe10 = xmldoc.CreateElement("COER5025");
                xe10.InnerText = model.COER5025;
                XmlElement xe11 = xmldoc.CreateElement("COED5025");
                xe11.InnerText = model.COED5025;
                XmlElement xe12 = xmldoc.CreateElement("COEL2540");
                xe12.InnerText = model.COEL2540;
                XmlElement xe13 = xmldoc.CreateElement("COER2540");
                xe13.InnerText = model.COER2540;
                XmlElement xe14 = xmldoc.CreateElement("COED2540");
                xe14.InnerText = model.COED2540;
                XmlElement xe15 = xmldoc.CreateElement("NOEL5025");
                xe15.InnerText = model.NOEL5025;
                XmlElement xe16 = xmldoc.CreateElement("NOER5025");
                xe16.InnerText = model.NOER5025;
                XmlElement xe17 = xmldoc.CreateElement("NOED5025");
                xe17.InnerText = model.NOED5025;
                XmlElement xe18 = xmldoc.CreateElement("NOEL2540");
                xe18.InnerText = model.NOEL2540;
                XmlElement xe19 = xmldoc.CreateElement("NOER2540");
                xe19.InnerText = model.NOER2540;
                XmlElement xe20 = xmldoc.CreateElement("NOED2540");
                xe20.InnerText = model.NOED2540;

                xe.AppendChild(xe1);
                xe.AppendChild(xe2);
                xe.AppendChild(xe3);
                xe.AppendChild(xe4);
                xe.AppendChild(xe5);
                xe.AppendChild(xe6);
                xe.AppendChild(xe7);
                xe.AppendChild(xe8);
                xe.AppendChild(xe9);
                xe.AppendChild(xe10);
                xe.AppendChild(xe11);
                xe.AppendChild(xe12);
                xe.AppendChild(xe13);
                xe.AppendChild(xe14);
                xe.AppendChild(xe15);
                xe.AppendChild(xe16);
                xe.AppendChild(xe17);
                xe.AppendChild(xe18);
                xe.AppendChild(xe19);
                xe.AppendChild(xe20);
                data.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_ASM结果数据上传(UploadASMData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadASMData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        public bool UploadAsmProcess(string lsh, DataTable process_data, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 

                for (int i = 0; i < process_data.Rows.Count; i++)
                {
                    XmlElement xe = xmldoc.CreateElement("ASMProcessType");//创建一个<Node>节点
                    XmlElement xe1 = xmldoc.CreateElement("StationCode");
                    xe1.InnerText = stationCode;
                    XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                    xe2.InnerText = lsh;
                    XmlElement xe3 = xmldoc.CreateElement("Second_NO");
                    xe3.InnerText = process_data.Rows[i]["Second_NO"].ToString();
                    XmlElement xe4 = xmldoc.CreateElement("Flow_HC");
                    xe4.InnerText = process_data.Rows[i]["Flow_HC"].ToString();
                    XmlElement xe5 = xmldoc.CreateElement("Flow_CO");
                    xe5.InnerText = process_data.Rows[i]["Flow_CO"].ToString();
                    XmlElement xe6 = xmldoc.CreateElement("Flow_CO2");
                    xe6.InnerText = process_data.Rows[i]["Flow_CO2"].ToString();
                    XmlElement xe7 = xmldoc.CreateElement("Flow_NO");
                    xe7.InnerText = process_data.Rows[i]["Flow_NO"].ToString();
                    XmlElement xe8 = xmldoc.CreateElement("Analyser_O2");
                    xe8.InnerText = process_data.Rows[i]["Analyser_O2"].ToString();
                    XmlElement xe9 = xmldoc.CreateElement("Flowmeter_O2");
                    xe9.InnerText = process_data.Rows[i]["Flowmeter_O2"].ToString();
                    XmlElement xe10 = xmldoc.CreateElement("ActFlow");
                    xe10.InnerText = process_data.Rows[i]["ActFlow"].ToString();
                    XmlElement xe11 = xmldoc.CreateElement("StdFlow");
                    xe11.InnerText = process_data.Rows[i]["StdFlow"].ToString();
                    XmlElement xe12 = xmldoc.CreateElement("TailFlow");
                    xe12.InnerText = process_data.Rows[i]["TailFlow"].ToString();
                    XmlElement xe13 = xmldoc.CreateElement("Weight_HC");
                    xe13.InnerText = process_data.Rows[i]["Weight_HC"].ToString();
                    XmlElement xe14 = xmldoc.CreateElement("Weight_CO");
                    xe14.InnerText = process_data.Rows[i]["Weight_CO"].ToString();
                    XmlElement xe15 = xmldoc.CreateElement("Weight_NO");
                    xe15.InnerText = process_data.Rows[i]["Weight_NO"].ToString();
                    XmlElement xe16 = xmldoc.CreateElement("LineSpeed");
                    xe16.InnerText = process_data.Rows[i]["LineSpeed"].ToString();
                    XmlElement xe17 = xmldoc.CreateElement("RotateSpeed");
                    xe17.InnerText = process_data.Rows[i]["RotateSpeed"].ToString();
                    XmlElement xe18 = xmldoc.CreateElement("TotalPower");
                    xe18.InnerText = process_data.Rows[i]["TotalPower"].ToString();
                    XmlElement xe19 = xmldoc.CreateElement("ParasPower");
                    xe19.InnerText = process_data.Rows[i]["ParasPower"].ToString();
                    XmlElement xe20 = xmldoc.CreateElement("IndicPower");
                    xe20.InnerText = process_data.Rows[i]["IndicPower"].ToString();
                    XmlElement xe21 = xmldoc.CreateElement("FlowAirPressure");
                    xe21.InnerText = process_data.Rows[i]["FlowAirPressure"].ToString();
                    XmlElement xe22 = xmldoc.CreateElement("FlowTemperature");
                    xe22.InnerText = process_data.Rows[i]["FlowTemperature"].ToString();
                    XmlElement xe23 = xmldoc.CreateElement("EnvirTemperature");
                    xe23.InnerText = process_data.Rows[i]["EnvirTemperature"].ToString();
                    XmlElement xe24 = xmldoc.CreateElement("EnvirAirPressure");
                    xe24.InnerText = process_data.Rows[i]["EnvirAirPressure"].ToString();
                    XmlElement xe25 = xmldoc.CreateElement("EnvirHumidity");
                    xe25.InnerText = process_data.Rows[i]["EnvirHumidity"].ToString();
                    XmlElement xe26 = xmldoc.CreateElement("DiluteCorrect");
                    xe26.InnerText = process_data.Rows[i]["DiluteCorrect"].ToString();
                    XmlElement xe27 = xmldoc.CreateElement("HumidityCorrect");
                    xe27.InnerText = process_data.Rows[i]["HumidityCorrect"].ToString();
                    XmlElement xe28 = xmldoc.CreateElement("DiluteRatio");
                    xe28.InnerText = process_data.Rows[i]["DiluteRatio"].ToString();
                    XmlElement xe29 = xmldoc.CreateElement("ProcessTime");
                    xe29.InnerText = process_data.Rows[i]["ProcessTime"].ToString();
                    xe.AppendChild(xe1);
                    xe.AppendChild(xe2);
                    xe.AppendChild(xe3);
                    xe.AppendChild(xe4);
                    xe.AppendChild(xe5);
                    xe.AppendChild(xe6);
                    xe.AppendChild(xe7);
                    xe.AppendChild(xe8);
                    xe.AppendChild(xe9);
                    xe.AppendChild(xe10);
                    xe.AppendChild(xe11);
                    xe.AppendChild(xe12);
                    xe.AppendChild(xe13);
                    xe.AppendChild(xe14);
                    xe.AppendChild(xe15);
                    xe.AppendChild(xe16);
                    xe.AppendChild(xe17);
                    xe.AppendChild(xe18);
                    xe.AppendChild(xe19);
                    xe.AppendChild(xe20);
                    xe.AppendChild(xe21);
                    xe.AppendChild(xe22);
                    xe.AppendChild(xe23);
                    xe.AppendChild(xe24);
                    xe.AppendChild(xe25);
                    xe.AppendChild(xe26);
                    xe.AppendChild(xe27);
                    xe.AppendChild(xe28);
                    xe.AppendChild(xe29);
                    data.AppendChild(xe);
                }
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_ASM过程数据上传(UploadASMProcessData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadASMProcessData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        public bool UploadSdsResult(SdsResult model, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 
                XmlElement xe = xmldoc.CreateElement("TSIType");//创建一个<Node>节点
                XmlElement xe1 = xmldoc.CreateElement("StationCode");
                xe1.InnerText = stationCode;
                XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                xe2.InnerText = model.InspectionNum;
                XmlElement xe3 = xmldoc.CreateElement("EACL");
                xe3.InnerText = model.EACL;
                XmlElement xe4 = xmldoc.CreateElement("EACR");
                xe4.InnerText = model.EACR;
                XmlElement xe5 = xmldoc.CreateElement("EACD");
                xe5.InnerText = model.EACD;
                XmlElement xe6 = xmldoc.CreateElement("LICOL");
                xe6.InnerText = model.LICOL;
                XmlElement xe7 = xmldoc.CreateElement("LICOR");
                xe7.InnerText = model.LICOR;
                XmlElement xe8 = xmldoc.CreateElement("LICOD");
                xe8.InnerText = model.LICOD;
                XmlElement xe9 = xmldoc.CreateElement("LIHCL");
                xe9.InnerText = model.LIHCL;
                XmlElement xe10 = xmldoc.CreateElement("LIHCR");
                xe10.InnerText = model.LIHCR;
                XmlElement xe11 = xmldoc.CreateElement("LIHCD");
                xe11.InnerText = model.LIHCD;
                XmlElement xe12 = xmldoc.CreateElement("HICOL");
                xe12.InnerText = model.HICOL;
                XmlElement xe13 = xmldoc.CreateElement("HICOR");
                xe13.InnerText = model.HICOR;
                XmlElement xe14 = xmldoc.CreateElement("HICOD");
                xe14.InnerText = model.HICOD;
                XmlElement xe15 = xmldoc.CreateElement("HIHCL");
                xe15.InnerText = model.HIHCL;
                XmlElement xe16 = xmldoc.CreateElement("HIHCR");
                xe16.InnerText = model.HIHCR;
                XmlElement xe17 = xmldoc.CreateElement("HIHCD");
                xe17.InnerText = model.HIHCD;
                xe.AppendChild(xe1);
                xe.AppendChild(xe2);
                xe.AppendChild(xe3);
                xe.AppendChild(xe4);
                xe.AppendChild(xe5);
                xe.AppendChild(xe6);
                xe.AppendChild(xe7);
                xe.AppendChild(xe8);
                xe.AppendChild(xe9);
                xe.AppendChild(xe10);
                xe.AppendChild(xe11);
                xe.AppendChild(xe12);
                xe.AppendChild(xe13);
                xe.AppendChild(xe14);
                xe.AppendChild(xe15);
                xe.AppendChild(xe16);
                xe.AppendChild(xe17);
                data.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_SDS结果数据上传(UploadTSIData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadTSIData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        public bool UploadJzjsResult(JzjsResult model, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 
                XmlElement xe = xmldoc.CreateElement("LDType");//创建一个<Node>节点
                XmlElement xe1 = xmldoc.CreateElement("StationCode");
                xe1.InnerText = stationCode;
                XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                xe2.InnerText = model.InspectionNum;
                XmlElement xe3 = xmldoc.CreateElement("EL");
                xe3.InnerText = model.EL;
                XmlElement xe4 = xmldoc.CreateElement("ER100");
                xe4.InnerText = model.ER100;
                XmlElement xe5 = xmldoc.CreateElement("ER90");
                xe5.InnerText = model.ER90;
                XmlElement xe6 = xmldoc.CreateElement("ER80");
                xe6.InnerText = model.ER80;
                XmlElement xe7 = xmldoc.CreateElement("MWP");
                xe7.InnerText = model.MWP;
                XmlElement xe8 = xmldoc.CreateElement("ED");
                xe8.InnerText = model.ED;
                xe.AppendChild(xe1);
                xe.AppendChild(xe2);
                xe.AppendChild(xe3);
                xe.AppendChild(xe4);
                xe.AppendChild(xe5);
                xe.AppendChild(xe6);
                xe.AppendChild(xe7);
                xe.AppendChild(xe8);
                data.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_JZJS结果数据上传(UploadLDData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadLDData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        public bool UploadJzjsProcess(string lsh, DataTable process_data, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 

                for (int i = 0; i < process_data.Rows.Count; i++)
                {
                    XmlElement xe = xmldoc.CreateElement("LDProcessType");//创建一个<Node>节点
                    XmlElement xe1 = xmldoc.CreateElement("StationCode");
                    xe1.InnerText = stationCode;
                    XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                    xe2.InnerText = lsh;
                    XmlElement xe3 = xmldoc.CreateElement("Second_NO");
                    xe3.InnerText = process_data.Rows[i]["Second_NO"].ToString();
                    XmlElement xe4 = xmldoc.CreateElement("CalVelMaxHp");
                    xe4.InnerText = process_data.Rows[i]["CalVelMaxHp"].ToString();
                    XmlElement xe5 = xmldoc.CreateElement("ActVelMaxHp");
                    xe5.InnerText = process_data.Rows[i]["ActVelMaxHp"].ToString();
                    XmlElement xe6 = xmldoc.CreateElement("PowerPerSec");
                    xe6.InnerText = process_data.Rows[i]["PowerPerSec"].ToString();
                    XmlElement xe7 = xmldoc.CreateElement("SpeedPerSec");
                    xe7.InnerText = process_data.Rows[i]["SpeedPerSec"].ToString();
                    XmlElement xe8 = xmldoc.CreateElement("ActMaxPower");
                    xe8.InnerText = process_data.Rows[i]["ActMaxPower"].ToString();
                    XmlElement xe9 = xmldoc.CreateElement("RotateSpeed");
                    xe9.InnerText = process_data.Rows[i]["RotateSpeed"].ToString();
                    XmlElement xe10 = xmldoc.CreateElement("EnvirTemperature");
                    xe10.InnerText = process_data.Rows[i]["EnvirTemperature"].ToString();
                    XmlElement xe11 = xmldoc.CreateElement("EnvirAirPressure");
                    xe11.InnerText = process_data.Rows[i]["EnvirAirPressure"].ToString();
                    XmlElement xe12 = xmldoc.CreateElement("EnvirHumidity");
                    xe12.InnerText = process_data.Rows[i]["EnvirHumidity"].ToString();
                    XmlElement xe13 = xmldoc.CreateElement("PowerCorrect");
                    xe13.InnerText = process_data.Rows[i]["PowerCorrect"].ToString();
                    XmlElement xe14 = xmldoc.CreateElement("CorMaxPower");
                    xe14.InnerText = process_data.Rows[i]["CorMaxPower"].ToString();
                    XmlElement xe15 = xmldoc.CreateElement("Smoke_K100");
                    xe15.InnerText = process_data.Rows[i]["Smoke_K100"].ToString();
                    XmlElement xe16 = xmldoc.CreateElement("Smoke_K90");
                    xe16.InnerText = process_data.Rows[i]["Smoke_K90"].ToString();
                    XmlElement xe17 = xmldoc.CreateElement("Smoke_K80");
                    xe17.InnerText = process_data.Rows[i]["Smoke_K80"].ToString();
                    XmlElement xe18 = xmldoc.CreateElement("Speed_K100");
                    xe18.InnerText = process_data.Rows[i]["Speed_K100"].ToString();
                    XmlElement xe19 = xmldoc.CreateElement("Speed_K90");
                    xe19.InnerText = process_data.Rows[i]["Speed_K90"].ToString();
                    XmlElement xe20 = xmldoc.CreateElement("Speed_K80");
                    xe20.InnerText = process_data.Rows[i]["Speed_K80"].ToString();
                    XmlElement xe21 = xmldoc.CreateElement("IdleRotateSpeed");
                    xe21.InnerText = process_data.Rows[i]["IdleRotateSpeed"].ToString();
                    XmlElement xe22 = xmldoc.CreateElement("ProcessTime");
                    xe22.InnerText = process_data.Rows[i]["ProcessTime"].ToString();
                    xe.AppendChild(xe1);
                    xe.AppendChild(xe2);
                    xe.AppendChild(xe3);
                    xe.AppendChild(xe4);
                    xe.AppendChild(xe5);
                    xe.AppendChild(xe6);
                    xe.AppendChild(xe7);
                    xe.AppendChild(xe8);
                    xe.AppendChild(xe9);
                    xe.AppendChild(xe10);
                    xe.AppendChild(xe11);
                    xe.AppendChild(xe12);
                    xe.AppendChild(xe13);
                    xe.AppendChild(xe14);
                    xe.AppendChild(xe15);
                    xe.AppendChild(xe16);
                    xe.AppendChild(xe17);
                    xe.AppendChild(xe18);
                    xe.AppendChild(xe19);
                    xe.AppendChild(xe20);
                    xe.AppendChild(xe21);
                    xe.AppendChild(xe22);
                    data.AppendChild(xe);
                }
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_JZJS过程数据上传(UploadLDProcessData )】\r\n" + xmlstring);
                ResultData result = getUploadResult(webservices.UploadLDProcessData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }

        public bool UploadZyjsOrLzResult(bool is_zyjs, ZyjsOrLzResult model, out string errorInf)
        {
            errorInf = "";
            try
            {
                #region 生成待发送XML信息
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Data", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode data = xmldoc.SelectSingleNode("Data");//查找<Employees> 
                //根据是否为自由加速创建Xml
                XmlElement xe = is_zyjs ? xmldoc.CreateElement("LightProofSmokeData") : xmldoc.CreateElement("FilterSmokeData");//创建一个<Node>节点
                XmlElement xe1 = xmldoc.CreateElement("StationCode");
                xe1.InnerText = stationCode;
                XmlElement xe2 = xmldoc.CreateElement("InspectionNum");
                xe2.InnerText = model.InspectionNum;
                XmlElement xe3 = xmldoc.CreateElement("IRS");
                xe3.InnerText = model.IRS;
                XmlElement xe4 = xmldoc.CreateElement("EL");
                xe4.InnerText = model.EL;
                XmlElement xe5 = xmldoc.CreateElement("ER1");
                xe5.InnerText = model.ER1;
                XmlElement xe6 = xmldoc.CreateElement("ER2");
                xe6.InnerText = model.ER2;
                XmlElement xe7 = xmldoc.CreateElement("ER3");
                xe7.InnerText = model.ER3;
                XmlElement xe8 = xmldoc.CreateElement("ER4");
                xe8.InnerText = model.ER4;
                XmlElement xe9 = xmldoc.CreateElement("ERA");
                xe9.InnerText = model.ERA;
                XmlElement xe10 = xmldoc.CreateElement("ED");
                xe10.InnerText = model.ED;
                xe.AppendChild(xe1);
                xe.AppendChild(xe2);
                xe.AppendChild(xe3);
                xe.AppendChild(xe4);
                xe.AppendChild(xe5);
                xe.AppendChild(xe6);
                xe.AppendChild(xe7);
                xe.AppendChild(xe8);
                xe.AppendChild(xe9);
                xe.AppendChild(xe10);
                data.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_ZYJS/LZ结果数据上传(UploadLightProofSmokeData /UploadFilterSmokeData)】\r\n" + xmlstring);
                ResultData result = getUploadResult(is_zyjs ? webservices.UploadLightProofSmokeData(vit, xmlstring) : webservices.UploadFilterSmokeData(vit, xmlstring), true);

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
            catch (Exception er)
            {
                errorInf = "执行上传主检测信息错误：" + er.Message;
                return false;
            }
        }
        */
        #endregion

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
        /// <param name="is_dt">Data数据是否为表格(为true时解析为一个数据表，为false时解析为一个字段)</param>
        /// <returns>返回结果类（Data可能包含表信息（用Data.DataSet.Tables["表名"]取出数据，如待检车辆列表：DataTable dt = ResultData.Data.DataSet.Tables["AcceptanceType"]））</returns>
        public ResultData getUploadResult(string receive_Xml, bool is_dt)
        {
            ResultData results = new ResultData();
            if (receive_Xml == "")
                return null;
            try
            {
                string revXml = ini.INIIO.decodeUTF8(receive_Xml);
                INIIO.saveSocketLogInf("【RECEIVED_接收解码后数据】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);

                results.Success = (bool)ds.Tables["ResultData"].Rows[0]["Success"];
                results.Error = ds.Tables["ResultData"].Rows[0]["Error"].ToString();
                if (is_dt)
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

    #region 接口用数据
    public class MainTestInfo
    {
        public string InspectionNum { get; set; }
        public string UniqueString { get; set; }
        public string VLPN { get; set; }
        public string VIN { get; set; }
        public string InspectionOperator { get; set; }
        public string InspectionDriver { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string IUTID { get; set; }
        public string VDCT { get; set; }
        public string IUTYPE { get; set; }
        public string InspectionStandard { get; set; }
        public string InspectionWay { get; set; }
        public string InspectionNature { get; set; }
        public string InspectionTimes { get; set; }
        public string IUIDATE { get; set; }
        public string TSM { get; set; }
        public string SceneCode { get; set; }
        public string DetectStartTime { get; set; }
        public string DetectEndTime { get; set; }
        public string VinFlag { get; set; }
        public string EngineNumFlag { get; set; }
        public string ICheck { get; set; }
        public string CheckTime { get; set; }
        public string InspectionReportNo { get; set; }
    }
    public class AsmResult
    {
        public string InspectionNum { get; set; }
        public string HCEL5025 { get; set; }
        public string HCER5025 { get; set; }
        public string HCED5025 { get; set; }
        public string HCEL2540 { get; set; }
        public string HCER2540 { get; set; }
        public string HCED2540 { get; set; }
        public string COEL5025 { get; set; }
        public string COER5025 { get; set; }
        public string COED5025 { get; set; }
        public string COEL2540 { get; set; }
        public string COER2540 { get; set; }
        public string COED2540 { get; set; }
        public string NOEL5025 { get; set; }
        public string NOER5025 { get; set; }
        public string NOED5025 { get; set; }
        public string NOEL2540 { get; set; }
        public string NOER2540 { get; set; }
        public string NOED2540 { get; set; }
    }
    public class SdsResult
    {
        public string InspectionNum { get; set; }
        public string EACL { get; set; }
        public string EACR { get; set; }
        public string EACD { get; set; }
        public string LICOL { get; set; }
        public string LICOR { get; set; }
        public string LICOD { get; set; }
        public string LIHCL { get; set; }
        public string LIHCR { get; set; }
        public string LIHCD { get; set; }
        public string HICOL { get; set; }
        public string HICOR { get; set; }
        public string HICOD { get; set; }
        public string HIHCL { get; set; }
        public string HIHCR { get; set; }
        public string HIHCD { get; set; }
    }
    public class JzjsResult
    {
        public string InspectionNum { get; set; }
        public string EL { get; set; }
        public string ER100 { get; set; }
        public string ER90 { get; set; }
        public string ER80 { get; set; }
        public string MWP { get; set; }
        public string ED { get; set; }
    }
    public class ZyjsOrLzResult
    {
        public string InspectionNum { get; set; }
        public string IRS { get; set; }
        public string EL { get; set; }
        public string ER1 { get; set; }
        public string ER2 { get; set; }
        public string ER3 { get; set; }
        public string ER4 { get; set; }
        public string ERA { get; set; }
        public string ED { get; set; }
    }
    public class FqyBdData
    {
        public string GasType { get; set; }
        public string HCEL { get; set; }
        public string HCER { get; set; }
        public string HCED { get; set; }
        public string COEL { get; set; }
        public string COER { get; set; }
        public string COED { get; set; }
        public string NOEL { get; set; }
        public string NOER { get; set; }
        public string NOED { get; set; }
        public string CO2EL { get; set; }
        public string CO2ER { get; set; }
        public string CO2ED { get; set; }
        public string O2EL { get; set; }
        public string O2ER { get; set; }
        public string O2ED { get; set; }
        public string PEF { get; set; }
        public string C3H8 { get; set; }
        public string AdjustResult { get; set; }
        public string AdjustTimeStart { get; set; }
        public string AdjustTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class YdjBdData
    {
        public string EL { get; set; }
        public string ER { get; set; }
        public string ED { get; set; }
        public string AdjustTimeStart { get; set; }
        public string AdjustTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class WsdBdData
    {
        public string ActualTemperature { get; set; }
        public string Temperature { get; set; }
        public string ActualHumidity { get; set; }
        public string Humidity { get; set; }
        public string ActualAirPressure { get; set; }
        public string AirPressure { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class JzhxBdData
    {
        public string HVitualTime { get; set; }
        public string HFloatTime { get; set; }
        public string LvitualTime { get; set; }
        public string LFloatTime { get; set; }
        public string Hpower { get; set; }
        public string Lpower { get; set; }
        public string CheckResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class JsglBdData
    {
        public string SpeedQJ1 { get; set; }
        public string NameSpeed1 { get; set; }
        public string PLHP1 { get; set; }
        public string SpeedQJ2 { get; set; }
        public string NameSpeed2 { get; set; }
        public string PLHP2 { get; set; }
        public string SpeedQJ3 { get; set; }
        public string NameSpeed3 { get; set; }
        public string PLHP3 { get; set; }
        public string SpeedQJ4 { get; set; }
        public string NameSpeed4 { get; set; }
        public string PLHP4 { get; set; }
        public string MaxSpeed { get; set; }
        public string CheckResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class LljZjData
    {
        public string AvgFlow { get; set; }
        public string O2Avg { get; set; }
        public string CheckResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class XlZjData
    {
        public string TightnessResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class YdjZjData
    {
        public string ZeroResult { get; set; }
        public string LabelValueN50 { get; set; }
        public string LabelValueN70 { get; set; }
        public string N50 { get; set; }
        public string N70 { get; set; }
        public string Error50 { get; set; }
        public string Error70 { get; set; }
        public string CheckResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    public class FxyZjData
    {
        public string TightnessResult { get; set; }
        public string LFlowResult { get; set; }
        public string CanliuHC { get; set; }
        public string CheckResult { get; set; }
        public string CheckTimeStart { get; set; }
        public string CheckTimeEnd { get; set; }
        public string Remark { get; set; }
    }
    #endregion

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
        public string UploadFilterSmokeData(VIToken vit, String body)
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
