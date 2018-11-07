using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using ini;

namespace GxWebClient
{
    /// <summary>
    /// 广西平南联网接口
    /// </summary>
    public class Pnservice
    {
        public bool JK_Status { get { return jk_status; } }

        private bool jk_status = false;
        private VehicleInspectionService webservices = null;
        public VIToken vit = null;
        private string cityCode = "", stationCode = "", lineCode = "", factoryNo = "";

        #region 名称代码对应字典
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
        #endregion

        /// <summary>
        /// 联网接口初始化
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="user">接口用户名</param>
        /// <param name="pwd">接口用户密码</param>
        public Pnservice(string url, string user, string pwd, string cityCode, string stationCode, string lineCode, string factoryNo)
        {
            #region 名称代码初始化
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

            PN_inspectionnature.Add("01", "初检");
            PN_inspectionnature.Add("02", "复检");
            PN_inspectionnature.Add("03", "多检");

            PN_vlpncolor.Add("01", "蓝色");
            PN_vlpncolor.Add("02", "黄色");
            PN_vlpncolor.Add("03", "黑色");
            PN_vlpncolor.Add("04", "白色");
            PN_vlpncolor.Add("05", "无");

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
            PN_useofauto.Add("N", "教练");
            PN_useofauto.Add("O", "幼儿校车");
            PN_useofauto.Add("P", "小学生校车");
            PN_useofauto.Add("Q", "其他校车");
            PN_useofauto.Add("R", "危化品运输");
            PN_useofauto.Add("Z", "其他");

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
            PN_fueltype.Add("P", "氢");
            PN_fueltype.Add("Q", "生物燃料");
            PN_fueltype.Add("Y", "无");
            
            PN_oilsupplyway.Add("01", "化油器");
            PN_oilsupplyway.Add("02", "闭环电喷");
            PN_oilsupplyway.Add("03", "开环电喷");
            PN_oilsupplyway.Add("04", "自然吸气");
            PN_oilsupplyway.Add("05", "涡轮增压");

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
            webservices = new VehicleInspectionService(url);
            vit = new VIToken();
            vit.GuidString = webservices.Login(user, pwd);
            if (vit.GuidString == "")
                jk_status = false;
            else
            {
                webservices.VITokenValue = vit;
                jk_status = true;
            }
        }

        /// <summary>
        /// 系统时间同步
        /// </summary>
        /// <returns></returns>
        public string GetSystemTime()
        {
            if (jk_status == false)
                return "";
            try
            {
                INIIO.saveSocketLogInf("【开始同步系统时间】\r\n");
                DataSet result = getUploadResult(webservices.GetDateTimeNow());
                if (result != null && (bool)result.Tables["ResultData"].Rows[0]["Success"] && result.Tables["ResultData"].Rows[0]["Data"].ToString() != "")
                    return result.Tables["ResultData"].Rows[0]["Data"].ToString();
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
            {
                errorInf = "接口未正常初始化";
                return false;
            }
            try
            {
                INIIO.saveSocketLogInf("【获取受理信息】：lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
                DataSet result = getUploadResult(webservices.DownloadAcceptance(cityCode, stationCode, lineCode, jcff, factoryNo));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    errorInf = "Success:" + success.ToString() + "|Error:" + error;
                    if (success && error == "" && result.Tables["AcceptanceType"] != null)
                    {
                        dt_WaitCarList = result.Tables["AcceptanceType"];
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
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
            {
                errorInf = "接口未正常初始化";
                return false;
            }
            try
            {
                INIIO.saveSocketLogInf("【获取受理信息】：lineCode:" + lineCode + "|jcff:" + jcff + "|StartTime:" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "|EndTime:" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                DataSet result = getUploadResult(webservices.DownloadAcceptanceData(cityCode, stationCode, lineCode, jcff, StartTime.ToString("yyyy-MM-dd HH:mm:ss"), EndTime.ToString("yyyy-MM-dd HH:mm:ss"), 0, factoryNo));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    errorInf = "Success:" + success.ToString() + "|Error:" + error;
                    if (success && error == "" && result.Tables["AcceptanceType"] != null)
                    {
                        dt_WaitCarList = result.Tables["AcceptanceType"];
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
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
                DataSet result = getUploadResult(webservices.UpInspectionSignal(stationCode, jylsh, lineCode, uniqueStr, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), isStart ? "start" : "stop"));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();

                    if (success && error == "")
                        return true;
                    else
                    {
                        errorInf = "Success:" + success.ToString() + "|Error:" + error;
                        return false;
                    }
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <param name="jcff">检测方法</param>
        /// <param name="jylsh">检测编号</param>
        /// <param name="dt_CarInfo">查到的车辆信息</param>
        /// <param name="errorInf">上传错误信息</param>
        /// <returns></returns>
        public bool GetCarInfo(string jcff, string jylsh, out DataTable dt_CarInfo, out string errorInf)
        {
            dt_CarInfo = null;
            errorInf = "";
            if (jk_status == false)
                return false;
            try
            {
                INIIO.saveSocketLogInf("【获取车辆信息】：jylsh:" + jylsh + "|lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
                DataSet result = getUploadResult(webservices.DownloadVehicle(stationCode, jylsh, lineCode, jcff));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    errorInf = "Success:" + success.ToString() + "|Error:" + error;
                    
                    if (success && error == "" && result.Tables["Vehicle"] != null)
                    {
                        dt_CarInfo = result.Tables["Vehicle"];
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检测主信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorInf"></param>
        /// <returns></returns>
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
                DataSet result = getUploadResult(webservices.UploadInspectionData(xmlstring));

                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    if (success && error == "")
                        return true;
                    else
                    {
                        errorInf = "Success:" + success.ToString() + "|Error:" + error;
                        return false;
                    }
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
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
                XmlDocument xmldoc;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees>
                XmlElement xe = xmldoc.CreateElement("Data");//创建一个<Node>节点

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
                    XmlElement xe_r = xmldoc.CreateElement(bodyName);//创建一个<Node>节点
                    foreach (string key in hash_dt[0].Keys)
                    {
                        XmlElement xe_n = xmldoc.CreateElement(key);
                        xe_n.InnerText = hash_dt[0][key].ToString();
                        xe_r.AppendChild(xe_n);
                    }
                    xe.AppendChild(xe_r);
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
                    for (int i = 0; i < hash_dt.Count; i++)
                    {
                        XmlElement xe_p = xmldoc.CreateElement(bodyName);//创建一个<Node>节点
                        foreach (string key in hash_dt[i].Keys)
                        {
                            XmlElement xe_n = xmldoc.CreateElement(key);
                            xe_n.InnerText = hash_dt[i][key].ToString();
                            xe_p.AppendChild(xe_n);
                        }
                        xe.AppendChild(xe_p);
                    }
                }
                root.AppendChild(xe);
                #endregion

                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【SEND_检测数据上传(" + bodyName + ")】\r\n" + xmlstring);
                DataSet result = null;
                switch (interface_kind)
                {
                    case 1://ASM_Result
                        result = getUploadResult(webservices.UploadASMData(xmlstring));
                        break;
                    case 2://SDS_Result
                        result = getUploadResult(webservices.UploadTSIData(xmlstring));
                        break;
                    case 3://JZJS_Result
                        result = getUploadResult(webservices.UploadLDData(xmlstring));
                        break;
                    case 4://LZ_Result
                        result = getUploadResult(webservices.UploadFilterSmokeData(xmlstring));
                        break;
                    case 5://ZYJS_Result
                        result = getUploadResult(webservices.UploadLightProofSmokeData(xmlstring));
                        break;
                    case 6://ASM_Process
                        result = getUploadResult(webservices.UploadASMProcessData(xmlstring));
                        break;
                    case 7://JZJS_Process
                        result = getUploadResult(webservices.UploadLDProcessData(xmlstring));
                        break;
                }

                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    if (success && error == "")
                        return true;
                    else
                    {
                        errorInf = "Success:" + success.ToString() + "|Error:" + error;
                        return false;
                    }
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch (Exception er)
            {
                errorInf = "执行上传检测数据错误：" + er.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取检测限值
        /// </summary>
        /// <param name="jcff">检测方法</param>
        /// <param name="jylsh">检测编号</param>
        /// <param name="dt_XZ">限值数据</param>
        /// <param name="errorInf">上传错误信息</param>
        /// <returns></returns>
        public bool GetXZ(string jcff, string jylsh, out DataTable dt_XZ, out string errorInf)
        {
            dt_XZ = null;
            errorInf = "";
            if (jk_status == false)
            {
                errorInf = "接口未正常初始化";
                return false;
            }
            try
            {
                INIIO.saveSocketLogInf("【获取检测限值】：jylsh:" + jylsh + "|lineCode:" + lineCode + "|jcff:" + jcff + "\r\n");
                DataSet result = getUploadResult(webservices.GetParamLimitData(stationCode, jylsh, lineCode, jcff));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    errorInf = "Success:" + success.ToString() + "|Error:" + error;
                    if (success && error == "" && result.Tables["Limit"] != null)
                    {
                        dt_XZ = result.Tables["Limit"];
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="dt_Users">返回人员信息表</param>
        /// <param name="errorInf">上传错误信息</param>
        /// <returns></returns>
        public bool GetUsers(out DataTable dt_Users, out string errorInf)
        {
            dt_Users = null;
            errorInf = "";
            if (jk_status == false)
            {
                errorInf = "接口未正常初始化";
                return false;
            }
            try
            {
                INIIO.saveSocketLogInf("【获取人员信息】\r\n");
                DataSet result = getUploadResult(webservices.DownloadStationStaff(cityCode, stationCode));
                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    errorInf = "Success:" + success.ToString() + "|Error:" + error;
                    if (success && error == "" && result.Tables["StationStaffType"] != null)
                    {
                        dt_Users = result.Tables["StationStaffType"];
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 上传标定或自检数据
        /// </summary>
        /// <param name="ZjBdKind">标定或自检数据类型(1、汽油线标定;2、柴油线标定;3、设备状态;4、环境参数校准;5、测功机自检;6、寄生功率自检;7、流量计自检;8、五气分析仪自检;9、烟度计自检;10、双怠速气体分析仪自检;)</param>
        /// <param name="hash_dt">标定或自检数据哈希表</param>
        /// <param name="errorInf">上传错误信息</param>
        /// <returns></returns>
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
                //添加固定信息
                XmlElement xe01 = xmldoc.CreateElement("CityCode");
                xe01.InnerText = cityCode;
                XmlElement xe02 = xmldoc.CreateElement("StationCode");
                xe02.InnerText = stationCode;
                XmlElement xe03 = xmldoc.CreateElement("SceneCode");
                xe03.InnerText = lineCode;
                xe0.AppendChild(xe01);
                xe0.AppendChild(xe02);
                xe0.AppendChild(xe03);
                //添加动态信息
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
                DataSet result = null;
                switch (ZjBdKind)
                {
                    case 1:
                        result = getUploadResult(webservices.UploadLineCheckPetrol(xmlstring));
                        break;
                    case 2:
                        result = getUploadResult(webservices.UpLoadLineCheckDiesel(xmlstring));
                        break;
                    case 3:
                        result = getUploadResult(webservices.UploadStationDeviceStatus(xmlstring));
                        break;
                    case 4:
                        result = getUploadResult(webservices.UploadEnvParamSensor(xmlstring));
                        break;
                    case 5:
                        result = getUploadResult(webservices.UploadDynamometerSelfCheck(xmlstring));
                        break;
                    case 6:
                        result = getUploadResult(webservices.UploadParasiticPowerSelfCheck(xmlstring));
                        break;
                    case 7:
                        result = getUploadResult(webservices.UploadFlowmeterSelfCheck(xmlstring));
                        break;
                    case 8:
                        result = getUploadResult(webservices.UploadGasAnalyzerSelfCheck(xmlstring));
                        break;
                    case 9:
                        result = getUploadResult(webservices.UploadLightProofSmokeSelfCheck(xmlstring));
                        break;
                    case 10:
                        result = getUploadResult(webservices.UploadTSIGasAnalyzerSelfCheck(xmlstring));
                        break;
                }

                if (result != null)
                {
                    bool success = (bool)result.Tables["ResultData"].Rows[0]["Success"];
                    string error = result.Tables["ResultData"].Rows[0]["Error"].ToString();
                    if (success && error == "")
                        return true;
                    else
                    {
                        errorInf = "Success:" + success.ToString() + "|Error:" + error;
                        return false;
                    }
                }
                else
                {
                    errorInf = "无返回消息或返回信息解析失败";
                    return false;
                }
            }
            catch (Exception er)
            {
                errorInf = er.Message;
                return false;
            }
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
        /// <param name="receive_Xml">接口返回消息</param>
        /// <param name="ds">消息解析得到的DataSet</param>
        /// <returns>收到并解析得到成功时返回true，其他返回false</returns>
        public DataSet getUploadResult(string receiveXml)
        {
            if (receiveXml == "")
            {
                INIIO.saveSocketLogInf("【接收的待解析数据为空】");
                return null;
            }
            try
            {
                string revXml = ini.INIIO.decodeUTF8(receiveXml);
                INIIO.saveSocketLogInf("【RECEIVED_接收解码后数据】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);

                return ds;
            }
            catch (Exception er)
            {
                INIIO.saveSocketLogInf("【接收数据解析出错】\r\n" + er.Message);
                return null;
            }
        }
        #endregion
    }
}
