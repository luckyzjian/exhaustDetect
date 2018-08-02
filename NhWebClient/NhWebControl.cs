using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using ini;
using System.Data;
using System.Collections;

namespace NhWebClient
{
    public class VehicleInfo
    {
        public string TestRunningNumber { set; get; }
        public string PlateNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string PlateType { set; get; }
        public DateTime RegistrationDate { set; get; }
        public string Owner { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string UseCharacter { set; get; }
        public string Manufacturer { set; get; }
        public string Brand { set; get; }
        public string Model { set; get; }
        public DateTime ProductionDate { set; get; }
        public string VIN { set; get; }
        public string ChassisModel { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string VehicleType { set; get; }
        public string MaximumTotalMass { set; get; }
        public string UnladenMass { set; get; }
        public string AxleMass { set; get; }
        public string RatedLoadingMass { set; get; }
        public string RatedPassengerCapacity { set; get; }
        public string TyrePressure { set; get; }
        public string TravelledDistance { set; get; }
        public string EngineManufacturer { set; get; }
        public string EngineModel { set; get; }
        public string EngineNumber { set; get; }
        public string EngineStroke { set; get; }
        public string Displacement { set; get; }
        public string CylinderNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string OilSupplyMode { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string AirIntakeMode { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string HasCatalyticConverter { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string FuelType { set; get; }
        public string FuelMark { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string DoubleFuel { set; get; }
        public string FuelType2 { set; get; }
        public string FuelMark2 { set; get; }
        public string RatedRev { set; get; }
        public string RatedPower { set; get; }
        public string MaximumNetPower { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string GearBoxType { set; get; }
        public string GearNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string DriverType { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string EPSign { set; get; }
        public string CertificateNumber { set; get; }
        public string ExhaustPipeNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string TCS { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string FuelPumpMode { set; get; }
        public string IsPassengerVehicle { set; get; }
        public string EmissionStandard { set; get; }
        public string EndTime { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string VerifyStatus { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Judge { set; get; }
    }
    public class VehicleInspection
    {
        public string TestSN { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string TestType { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string TestCharacter { set; get; }
        public string EntryClerk { set; get; }
        public string FirstTestDate { set; get; }
        /// <summary>
        /// 检测周期[天]
        /// </summary>
        public string TestPeriod { set; get; }
        public string EntryTime { set; get; }
        public string EntryPCIP { set; get; }
        public string PlateNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string PlateType { set; get; }
        public string RegistrationDate { set; get; }
        public string Owner { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string UseCharacter { set; get; }
        public string Manufacturer { set; get; }
        public string Brand { set; get; }
        public string Model { set; get; }
        public string ProductionDate { set; get; }
        public string VIN { set; get; }
        public string ChassisModel { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string VehicleType { set; get; }
        public string MaximumTotalMass { set; get; }
        public string UnladenMass { set; get; }
        public string AxleMass { set; get; }
        public string RatedLoadingMass { set; get; }
        public string RatedPassengerCapacity { set; get; }
        public string TyrePressure { set; get; }

        public string TravelledDistance { set; get; }
        public string EngineManufacturer { set; get; }
        public string EngineModel { set; get; }
        public string EngineNumber { set; get; }
        public string EngineStroke { set; get; }
        public string Displacement { set; get; }
        public string CylinderNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string OilSupplyMode { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string AirIntakeMode { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string HasCatalyticConverter { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string FuelType { set; get; }
        public string FuelMark { set; get; }
        public string DoubleFuel { set; get; }
        public string FuelType2 { set; get; }
        public string FuelMark2 { set; get; }
        public string RatedRev { set; get; }
        public string RatedPower { set; get; }
        public string MaximumNetPower { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string GearBoxType { set; get; }
        public string GearNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string DriverType { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string EPSign { set; get; }
        public string CertificateNumber { set; get; }
        public string ExhaustPipeNumber { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string TCS { set; get; }
        /// <summary>
        /// 汉字
        /// </summary>
        public string FuelPumpMode { set; get; }
        /// <summary>
        /// 代号
        /// </summary>
        public string IsPassengerVehicle { set; get; }
        public string EmissionStandard { set; get; }
    }
    public class NhWebControl
    {
        string stationID = "";
        string lineID = "";
        NhWebReference.NHDSWebService outlineservice = new NhWebReference.NHDSWebService();
        public Dictionary<string, string> NH_PlateType= new Dictionary<string, string>();
        public Dictionary<string, string> NH_UseCharacter = new Dictionary<string, string>();
        public Dictionary<string, string> NH_VehicleType = new Dictionary<string, string>();
        public Dictionary<string, string> NH_OilSupplyMode = new Dictionary<string, string>();
        public Dictionary<string, string> NH_AirIntakeMode = new Dictionary<string, string>();
        public Dictionary<string, string> NH_HasCatalyticConverter = new Dictionary<string, string>();
        public Dictionary<string, string> NH_FuelType = new Dictionary<string, string>();
        public Dictionary<string, string> NH_DoubleFuel = new Dictionary<string, string>();
        public Dictionary<string, string> NH_GearBoxType = new Dictionary<string, string>();
        public Dictionary<string, string> NH_DriveType = new Dictionary<string, string>();
        public Dictionary<string, string> NH_EPSign = new Dictionary<string, string>();
        public Dictionary<string, string> NH_TCS = new Dictionary<string, string>();
        public Dictionary<string, string> NH_FuelPumpMode = new Dictionary<string, string>();
        public Dictionary<string, string> NH_IsPassengerVehicle = new Dictionary<string, string>();
        public Dictionary<string, string> NH_VerifyStatus = new Dictionary<string, string>();
        public Dictionary<string, string> NH_Judge = new Dictionary<string, string>();
        public Dictionary<string, string> NH_TestType = new Dictionary<string, string>();
        public Dictionary<string, string> NH_TestCharacter = new Dictionary<string, string>();
        public Dictionary<string, string> NH_Status = new Dictionary<string, string>();
        public NhWebControl(string url, string stationID, string lineID)
        {
            outlineservice.Url = url;
            this.stationID = stationID;
            this.lineID = lineID;
            NH_PlateType.Add("1", "蓝牌");
            NH_PlateType.Add("2", "黄牌");
            NH_PlateType.Add("3", "黑牌");
            NH_PlateType.Add("4", "白牌");
            NH_PlateType.Add("5", "其他");
            NH_UseCharacter.Add("1", "营运");
            NH_UseCharacter.Add("2", "非营运");
            NH_VehicleType.Add("1", "摩托车");
            NH_VehicleType.Add("2", "轻便摩托车");
            NH_VehicleType.Add("3", "三轮汽车");
            NH_VehicleType.Add("4", "微型客车");
            NH_VehicleType.Add("5", "小型客车");
            NH_VehicleType.Add("6", "中型客车");
            NH_VehicleType.Add("7", "大型客车");
            NH_VehicleType.Add("8", "低速货车");
            NH_VehicleType.Add("9", "微型货车");
            NH_VehicleType.Add("10", "小型货车");
            NH_VehicleType.Add("11", "中型货车");
            NH_VehicleType.Add("12", "大型货车");
            NH_OilSupplyMode.Add("1", "化油器");
            NH_OilSupplyMode.Add("2", "化油器改造");
            NH_OilSupplyMode.Add("3", "开环电喷");
            NH_OilSupplyMode.Add("4", "闭环电喷");
            NH_OilSupplyMode.Add("5", "直喷");
            NH_OilSupplyMode.Add("6", "其它");
            NH_AirIntakeMode.Add("1", "自然吸气");
            NH_AirIntakeMode.Add("2", "机械增压");
            NH_AirIntakeMode.Add("3", "涡轮增压");
            NH_AirIntakeMode.Add("4", "涡轮增加中冷");
            NH_AirIntakeMode.Add("5", "其他");
            NH_HasCatalyticConverter.Add("1", "否");
            NH_HasCatalyticConverter.Add("2", "是");
            NH_FuelType.Add("1", "汽油");
            NH_FuelType.Add("2", "柴油");
            NH_FuelType.Add("3", "液化石油器");
            NH_FuelType.Add("4", "天然气");
            NH_FuelType.Add("5", "甲醇");
            NH_FuelType.Add("6", "乙醇");
            NH_FuelType.Add("7", "其他");
            NH_DoubleFuel.Add("1", "否");
            NH_DoubleFuel.Add("2", "是");
            NH_GearBoxType.Add("1", "手动");
            NH_GearBoxType.Add("2", "自动");
            NH_GearBoxType.Add("3", "手自一体");
            NH_GearBoxType.Add("4", "其他");
            NH_DriveType.Add("1", "前驱");
            NH_DriveType.Add("2", "后驱");
            NH_DriveType.Add("3", "分时四驱");
            NH_DriveType.Add("4", "全时四驱");
            NH_DriveType.Add("5", "其他");
            NH_EPSign.Add("1", "黄标");
            NH_EPSign.Add("2", "国I绿标");
            NH_EPSign.Add("3", "国II绿标");
            NH_EPSign.Add("4", "国III绿标");
            NH_EPSign.Add("5", "国IV绿标");
            NH_EPSign.Add("6", "国V绿标");
            NH_TCS.Add("0", "无");
            NH_TCS.Add("1", "可摘除");
            NH_TCS.Add("2", "不可摘除");
            NH_FuelPumpMode.Add("1", "机械");
            NH_FuelPumpMode.Add("2", "电子控制");
            NH_IsPassengerVehicle.Add("1", "否");
            NH_IsPassengerVehicle.Add("2", "是");
            NH_VerifyStatus.Add("0", "未审核");
            NH_VerifyStatus.Add("1", "已审核");
            NH_Judge.Add("0", "不合格");
            NH_Judge.Add("1", "合格");
            NH_TestType.Add("1", "稳态工况");
            NH_TestType.Add("2", "简易瞬态");
            NH_TestType.Add("3", "加载减速");
            NH_TestType.Add("4", "双怠速");
            NH_TestType.Add("5", "自由加速");
            NH_TestType.Add("6", "滤纸");
            NH_TestType.Add("7", "农用车自由加速");
            NH_TestType.Add("8", "摩托车怠速");
            NH_TestType.Add("9", "摩托车双怠速");
            NH_TestCharacter.Add("1", "出厂抽检");
            NH_TestCharacter.Add("2", "初次检测");
            NH_TestCharacter.Add("3", "道路检测");
            NH_TestCharacter.Add("4", "定期检测");
            NH_TestCharacter.Add("5", "举报冒烟检测");
            NH_TestCharacter.Add("6", "停车场地抽检");
            NH_TestCharacter.Add("7", "用车大户抽检");
            NH_Status.Add("1", "空闲");
            NH_Status.Add("2", "正在检测");
            NH_Status.Add("3", "正在自检");
            NH_Status.Add("4", "正在标定");
            NH_Status.Add("5", "设备故障");
            NH_Status.Add("6", "检测程序退出或设备关闭");

        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static string ConvertXmlToString(XmlDocument xmlDoc)
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"utf-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("发送:\r\n" + newstring);
            return newstring;
        }
        public DateTime GetTimeRequest(out int errorCode,out string ErrorMessage,out int exceptioncode,out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "GetTime");//设置该节点genre属性             
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.GetTime(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode==0)
            {
                DateTime datetimevalue = ReadDatatimeString(retval.Value, out exceptioncode, out ExceptionMessage);
                return datetimevalue;
            }
            else
            {
                return DateTime.Now;
            }
        }

        public static DateTime ReadDatatimeString(string xmlstring, out int result, out string info)
        {
            DateTime datetimevalue=DateTime.Now;
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            try
            {
                DataTable dt1 = ds.Tables["Respond"];
                datetimevalue =DateTime.Parse( dt1.Rows[0]["SysTime"].ToString());
                result = 0;
                info = "";
                return datetimevalue;
            }
            catch(Exception er)
            {
                result = -1;
                info = er.Message;
                return datetimevalue;
            }
        }
        public DataTable GetVehicleList(out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "GetVehicleList");//设置该节点genre属性             
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.GetVehicleList(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(retval.Value);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                try
                {
                    DataTable dt1 = ds.Tables["Row"];                    
                    return dt1;
                }
                catch (Exception er)
                {
                    exceptioncode = -1;
                    ExceptionMessage = er.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public VehicleInfo GetVehicleInfo(string hphm,string hpzl,string vin,out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "GetVehicleInfo");//设置该节点genre属性    
            XmlElement xe2 = xmldoc.CreateElement("VehicleInfo");//创建一个<Node>节点   
            XmlElement xe101 = xmldoc.CreateElement("PlateNumber");//创建一个<Node>节点 
            xe101.InnerText = hphm;
            XmlElement xe102 = xmldoc.CreateElement("PlateType");//创建一个<Node>节点 
            xe102.InnerText = hpzl;
            XmlElement xe103 = xmldoc.CreateElement("VIN");//创建一个<Node>节点 
            xe103.InnerText = vin;
            xe2.AppendChild(xe101);
            xe2.AppendChild(xe102);
            xe2.AppendChild(xe103);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.GetVehicleInfo(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(retval.Value);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                try
                {
                    DataTable dt1 = ds.Tables["VehicleInfo"];
                    vehiinfo = new VehicleInfo();
                    vehiinfo.TestRunningNumber = ds.Tables["NHMessage"].Rows[0]["TestRunningNumber"].ToString();
                    vehiinfo.PlateNumber = dt1.Rows[0]["PlateNumber"].ToString();

                    vehiinfo.PlateType = dt1.Rows[0]["PlateType"].ToString();

                    vehiinfo.RegistrationDate =DateTime.Parse(dt1.Rows[0]["RegistrationDate"].ToString());
                    vehiinfo.Owner = dt1.Rows[0]["Owner"].ToString();
                    vehiinfo.Phone = dt1.Rows[0]["Phone"].ToString();
                    vehiinfo.Address = dt1.Rows[0]["Address"].ToString();
                    vehiinfo.UseCharacter = dt1.Rows[0]["UseCharacter"].ToString();
                    vehiinfo.Manufacturer = dt1.Rows[0]["Manufacturer"].ToString();
                    vehiinfo.Brand = dt1.Rows[0]["Brand"].ToString();
                    vehiinfo.Model = dt1.Rows[0]["Model"].ToString();
                    vehiinfo.ProductionDate = DateTime.Parse(dt1.Rows[0]["ProductionDate"].ToString());
                    vehiinfo.VIN = dt1.Rows[0]["VIN"].ToString();
                    vehiinfo.ChassisModel = dt1.Rows[0]["ChassisModel"].ToString();
                    vehiinfo.VehicleType = dt1.Rows[0]["VehicleType"].ToString();
                    vehiinfo.MaximumTotalMass = dt1.Rows[0]["MaximumTotalMass"].ToString();
                    vehiinfo.UnladenMass = dt1.Rows[0]["UnladenMass"].ToString();
                    vehiinfo.AxleMass = dt1.Rows[0]["AxleMass"].ToString();
                    vehiinfo.RatedLoadingMass = dt1.Rows[0]["RatedLoadingMass"].ToString();
                    vehiinfo.RatedPassengerCapacity = dt1.Rows[0]["RatedPassengerCapacity"].ToString();
                    vehiinfo.TyrePressure = dt1.Rows[0]["TyrePressure"].ToString();
                    vehiinfo.TravelledDistance = dt1.Rows[0]["TravelledDistance"].ToString();
                    vehiinfo.EngineManufacturer = dt1.Rows[0]["EngineManufacturer"].ToString();
                    vehiinfo.EngineModel = dt1.Rows[0]["EngineModel"].ToString();
                    vehiinfo.EngineNumber = dt1.Rows[0]["EngineNumber"].ToString();
                    vehiinfo.EngineStroke = dt1.Rows[0]["EngineStroke"].ToString();
                    vehiinfo.Displacement = dt1.Rows[0]["Displacement"].ToString();
                    vehiinfo.CylinderNumber = dt1.Rows[0]["CylinderNumber"].ToString();
                    vehiinfo.OilSupplyMode = dt1.Rows[0]["OilSupplyMode"].ToString();
                    vehiinfo.AirIntakeMode = dt1.Rows[0]["AirIntakeMode"].ToString();
                    vehiinfo.HasCatalyticConverter = dt1.Rows[0]["HasCatalyticConverter"].ToString();
                    vehiinfo.FuelType = dt1.Rows[0]["FuelType"].ToString();
                    vehiinfo.FuelMark = dt1.Rows[0]["FuelMark"].ToString();
                    vehiinfo.DoubleFuel = dt1.Rows[0]["DoubleFuel"].ToString();
                    vehiinfo.FuelType2 = dt1.Rows[0]["FuelType2"].ToString();
                    vehiinfo.FuelMark2 = dt1.Rows[0]["FuelMark2"].ToString();
                    vehiinfo.RatedRev = dt1.Rows[0]["RatedRev"].ToString();
                    vehiinfo.RatedPower = dt1.Rows[0]["RatedPower"].ToString();
                    vehiinfo.MaximumNetPower = dt1.Rows[0]["MaximumNetPower"].ToString();
                    vehiinfo.GearBoxType = dt1.Rows[0]["GearBoxType"].ToString();
                    vehiinfo.GearNumber = dt1.Rows[0]["GearNumber"].ToString();
                    vehiinfo.DriverType = dt1.Rows[0]["DriveType"].ToString();
                    vehiinfo.EPSign = dt1.Rows[0]["EPSign"].ToString();
                    vehiinfo.CertificateNumber = dt1.Rows[0]["CertificateNumber"].ToString();
                    vehiinfo.ExhaustPipeNumber = dt1.Rows[0]["ExhaustPipeNumber"].ToString();
                    vehiinfo.TCS = dt1.Rows[0]["TCS"].ToString();
                    vehiinfo.FuelPumpMode = dt1.Rows[0]["FuelPumpMode"].ToString();
                    vehiinfo.IsPassengerVehicle = dt1.Rows[0]["IsPassengerVehicle"].ToString();
                    vehiinfo.EmissionStandard = dt1.Rows[0]["EmissionStandard"].ToString();
                    vehiinfo.EndTime = dt1.Rows[0]["EndTime"].ToString();
                    vehiinfo.VerifyStatus = dt1.Rows[0]["VerifyStatus"].ToString();
                    vehiinfo.Judge = dt1.Rows[0]["Judge"].ToString();
                    return vehiinfo;
                }
                catch (Exception er)
                {
                    exceptioncode = -1;
                    ExceptionMessage = er.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public string SendVehicleInspection(System.Collections.Hashtable ht, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "VehicleInspection");//设置该节点genre属性  
            XmlElement xe2 = xmldoc.CreateElement("VehicleInspection");//创建一个<Node>节点     
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe2.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.VehicleInspection(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return retval.Value;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 车辆取消待检
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="errorCode">0：数据正常；1：数据错误</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendVehicleInspectionCancel(string jylsh, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "VehicleInspectionCancel");//设置该节点genre属性              
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.VehicleInspectionCancel(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 开始检测
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="errorCode">0：数据正常；1：数据错误</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendStartTest(string jylsh, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "StartTest");//设置该节点genre属性              
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.StartTest(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="errorCode">0：数据正常；1：数据错误</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendTakePhoto(string jylsh, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "TakePhoto");//设置该节点genre属性              
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.TakePhoto(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 终止检测
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="errorCode">0：数据正常；1：数据错误</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendStopTest(string jylsh, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "StopTest");//设置该节点genre属性              
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.StopTest(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传稳态工况法检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadASMData(string jylsh,System.Collections.Hashtable ht,DataTable dataseconds, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadASMData");//设置该节点genre属性  
            XmlElement xe3 = xmldoc.CreateElement("ResultData"); 
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe3);
            XmlElement xe4 = xmldoc.CreateElement("ProcessData");
            if (dataseconds != null)
            {
                for (int i = 1; i < dataseconds.Rows.Count; i++)
                {
                    XmlElement xe5= xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = dataseconds.Rows[i];
                    XmlElement xe51 = xmldoc.CreateElement("TimeNumber");
                    xe51.InnerText = i.ToString();
                    XmlElement xe52 = xmldoc.CreateElement("SamplingTime");
                    xe52.InnerText = dr["全程时序"].ToString();
                    XmlElement xe53 = xmldoc.CreateElement("Status");
                    if (dr["时序类别"].ToString() == "0")
                    {
                        xe53.InnerText = "1";
                    }
                    else
                    {
                        xe53.InnerText = "2";
                    }
                    XmlElement xe54 = xmldoc.CreateElement("Velocity");
                    xe54.InnerText = dr["实时车速"].ToString();
                    XmlElement xe55 = xmldoc.CreateElement("Rev");
                    xe55.InnerText = dr["转速"].ToString();
                    XmlElement xe56 = xmldoc.CreateElement("Power");
                    xe56.InnerText = dr["加载功率"].ToString();
                    XmlElement xe57 = xmldoc.CreateElement("Force");
                    xe57.InnerText = dr["加载功率"].ToString();
                    XmlElement xe58 = xmldoc.CreateElement("CO");
                    xe58.InnerText = dr["CO实时值"].ToString();
                    XmlElement xe59 = xmldoc.CreateElement("CO2");
                    xe59.InnerText = dr["CO2实时值"].ToString();
                    XmlElement xe60 = xmldoc.CreateElement("HC");
                    xe60.InnerText = dr["HC实时值"].ToString();
                    XmlElement xe61 = xmldoc.CreateElement("NO");
                    xe61.InnerText = dr["NO实时值"].ToString();
                    XmlElement xe62 = xmldoc.CreateElement("O2");
                    xe62.InnerText = dr["O2实时值"].ToString();
                    XmlElement xe63 = xmldoc.CreateElement("Lambda");
                    xe63.InnerText = "1.00";
                    XmlElement xe64= xmldoc.CreateElement("DilutionCorrectionFactor");
                    xe64.InnerText = dr["稀释修正系数"].ToString();
                    XmlElement xe65 = xmldoc.CreateElement("HumidityCorrectionFactor");
                    xe65.InnerText = dr["湿度修正系数"].ToString();
                    XmlElement xe66= xmldoc.CreateElement("OilTemperature");
                    xe66.InnerText = dr["油温"].ToString();
                    XmlElement xe67 = xmldoc.CreateElement("EnvironmentalTemperature");
                    xe67.InnerText = dr["环境温度"].ToString();
                    XmlElement xe68 = xmldoc.CreateElement("AtmosphericPressure");
                    xe68.InnerText = dr["大气压力"].ToString();
                    XmlElement xe69 = xmldoc.CreateElement("RelativeHumidity");
                    xe69.InnerText = dr["相对湿度"].ToString();
                    xe5.AppendChild(xe51);
                    xe5.AppendChild(xe52);
                    xe5.AppendChild(xe53);
                    xe5.AppendChild(xe54);
                    xe5.AppendChild(xe55);
                    xe5.AppendChild(xe56);
                    xe5.AppendChild(xe57);
                    xe5.AppendChild(xe58);
                    xe5.AppendChild(xe59);
                    xe5.AppendChild(xe60);
                    xe5.AppendChild(xe61);
                    xe5.AppendChild(xe62);
                    xe5.AppendChild(xe63);
                    xe5.AppendChild(xe64);
                    xe5.AppendChild(xe65);
                    xe5.AppendChild(xe66);
                    xe5.AppendChild(xe67);
                    xe5.AppendChild(xe68);
                    xe5.AppendChild(xe69);
                    xe4.AppendChild(xe5);
                }
            }
            xe4.SetAttribute("EANS5025", "1");
            xe4.SetAttribute("EANS2540", "1");
            xe1.AppendChild(xe4);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadASMData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传简易瞬态工况法检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadVMASData(string jylsh, System.Collections.Hashtable ht, Hashtable ht_process, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadVMASData");//设置该节点genre属性   
            XmlElement xe3 = xmldoc.CreateElement("ResultData");
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe3);
            XmlElement xe4 = xmldoc.CreateElement("ProcessData");
            myEnumerator = ht_process.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe4.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe4);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadVMASData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传加载减速工况法检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadLUGDOWNData(string jylsh, System.Collections.Hashtable ht, DataTable dataseconds, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadLUGDOWNData");//设置该节点genre属性      
            XmlElement xe3 = xmldoc.CreateElement("ResultData");
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe3);
            XmlElement xe4 = xmldoc.CreateElement("ProcessData");
            if (dataseconds != null)
            {
                for (int i = 1; i < dataseconds.Rows.Count; i++)
                {
                    XmlElement xe5 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = dataseconds.Rows[i];
                    XmlElement xe51 = xmldoc.CreateElement("TimeNumber");
                    xe51.InnerText = i.ToString();
                    XmlElement xe52 = xmldoc.CreateElement("SamplingTime");
                    xe52.InnerText = dr["全程时序"].ToString();
                    XmlElement xe53 = xmldoc.CreateElement("Status");
                    xe53.InnerText = dr["时序类别"].ToString();
                    XmlElement xe54 = xmldoc.CreateElement("Velocity");
                    xe54.InnerText = dr["车速"].ToString();
                    XmlElement xe55 = xmldoc.CreateElement("Rev");
                    xe55.InnerText = dr["转速"].ToString();
                    XmlElement xe56 = xmldoc.CreateElement("Power");
                    xe56.InnerText = dr["功率"].ToString();
                    XmlElement xe57 = xmldoc.CreateElement("Force");
                    xe57.InnerText = dr["功率"].ToString();
                    XmlElement xe58 = xmldoc.CreateElement("K");
                    xe58.InnerText = dr["光吸收系数K"].ToString();
                    XmlElement xe59 = xmldoc.CreateElement("OilTemperature");
                    xe59.InnerText = dr["油温"].ToString();
                    XmlElement xe60 = xmldoc.CreateElement("EnvironmentalTemperature");
                    xe60.InnerText = dr["环境温度"].ToString();
                    XmlElement xe61 = xmldoc.CreateElement("AtmosphericPressure");
                    xe61.InnerText = dr["大气压力"].ToString();
                    XmlElement xe62 = xmldoc.CreateElement("RelativeHumidity");
                    xe62.InnerText = dr["相对湿度"].ToString();
                    XmlElement xe63 = xmldoc.CreateElement("PowerCorrectionFactor");
                    xe63.InnerText = dr["DCF"].ToString();
                    xe5.AppendChild(xe51);
                    xe5.AppendChild(xe52);
                    xe5.AppendChild(xe53);
                    xe5.AppendChild(xe54);
                    xe5.AppendChild(xe55);
                    xe5.AppendChild(xe56);
                    xe5.AppendChild(xe57);
                    xe5.AppendChild(xe58);
                    xe5.AppendChild(xe59);
                    xe5.AppendChild(xe60);
                    xe5.AppendChild(xe61);
                    xe5.AppendChild(xe62);
                    xe5.AppendChild(xe63);
                    xe4.AppendChild(xe5);
                }
            }
            xe1.AppendChild(xe4);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadLUGDOWNData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传双怠速检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadDISData(string jylsh, System.Collections.Hashtable ht, DataTable dataseconds, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadDISData");//设置该节点genre属性      
            XmlElement xe3 = xmldoc.CreateElement("ResultData");
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe3);
            XmlElement xe4 = xmldoc.CreateElement("ProcessData");
            if (dataseconds != null)
            {
                for (int i = 1; i < dataseconds.Rows.Count; i++)
                {
                    XmlElement xe5 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = dataseconds.Rows[i];
                    XmlElement xe51 = xmldoc.CreateElement("TimeNumber");
                    xe51.InnerText = i.ToString();
                    XmlElement xe52 = xmldoc.CreateElement("SamplingTime");
                    xe52.InnerText = dr["全程时序"].ToString();
                    XmlElement xe53 = xmldoc.CreateElement("Status");
                    if (dr["时序类别"].ToString() == "1" || dr["时序类别"].ToString() == "2")
                        xe53.InnerText = "1";
                    else
                        xe53.InnerText = "2";
                    XmlElement xe55 = xmldoc.CreateElement("Rev");
                    xe55.InnerText = dr["转速"].ToString();
                    XmlElement xe56 = xmldoc.CreateElement("CO");
                    xe56.InnerText = dr["CO"].ToString();
                    XmlElement xe57 = xmldoc.CreateElement("HC");
                    xe57.InnerText = dr["HC"].ToString();
                    XmlElement xe58 = xmldoc.CreateElement("NO");
                    xe58.InnerText ="0";
                    XmlElement xe59 = xmldoc.CreateElement("CO2");
                    xe59.InnerText = dr["CO2"].ToString();
                    XmlElement xe60 = xmldoc.CreateElement("O2");
                    xe60.InnerText = dr["O2"].ToString();
                    XmlElement xe61 = xmldoc.CreateElement("Lambda");
                    xe61.InnerText = dr["过量空气系数"].ToString();
                    XmlElement xe62 = xmldoc.CreateElement("OilTemperature");
                    xe62.InnerText = dr["油温"].ToString();
                    XmlElement xe63 = xmldoc.CreateElement("EnvironmentalTemperature");
                    xe63.InnerText = dr["环境温度"].ToString();
                    XmlElement xe64 = xmldoc.CreateElement("AtmosphericPressure");
                    xe64.InnerText = dr["大气压力"].ToString();
                    XmlElement xe65 = xmldoc.CreateElement("RelativeHumidity");
                    xe65.InnerText = dr["相对湿度"].ToString();
                    xe5.AppendChild(xe51);
                    xe5.AppendChild(xe52);
                    xe5.AppendChild(xe53);
                    xe5.AppendChild(xe55);
                    xe5.AppendChild(xe56);
                    xe5.AppendChild(xe57);
                    xe5.AppendChild(xe58);
                    xe5.AppendChild(xe59);
                    xe5.AppendChild(xe60);
                    xe5.AppendChild(xe61);
                    xe5.AppendChild(xe62);
                    xe5.AppendChild(xe63);
                    xe5.AppendChild(xe64);
                    xe5.AppendChild(xe65);
                    xe4.AppendChild(xe5);
                }
            }
            xe1.AppendChild(xe4);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadDISData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传不透光自由加速检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadFAOPAData(string jylsh, System.Collections.Hashtable ht, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadFAOPAData");//设置该节点genre属性  
            XmlElement xe3 = xmldoc.CreateElement("ResultData");
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }           
            xe1.AppendChild(xe3);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadFAOPAData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传滤纸式自由加速检测数据
        /// </summary>
        /// <param name="jylsh">检测流水号</param>
        /// <param name="ht">检测结果的哈希表</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadFASMOData(string jylsh, System.Collections.Hashtable ht, Hashtable ht_process, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmlelem.SetAttribute("TestRunningNumber", jylsh);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadFASMOData");//设置该节点genre属性    
            XmlElement xe3 = xmldoc.CreateElement("ResultData");
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe3.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe3);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadFASMOData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传标定数据
        /// </summary>
        /// <param name="ItemName">标定项目，UploadDynConstLoadData（测功机加载滑行检查），UploadDynPLHPData（寄生功率），UploadDynForceCalData（扭力标准），UploadDynForceChkData（扭力检查），UploadAnaGasCalData（分析仪校准），UploadAnaGasChkLoadData（分析仪检查），UploadOpaChkLoadData（不透光校准），UploadSmoChkLoadData（滤纸检查），UploadFloFluxChkLoadData（流量计检查）</param>
        /// <param name="ht"></param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadDermacateData(string ItemName, System.Collections.Hashtable ht, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", ItemName);//设置该节点genre属性  
            XmlElement xe2 = xmldoc.CreateElement("DemarcationData");//创建一个<Node>节点     
            
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe2.AppendChild(xe_ht);
            }            
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadDynConstLoadData(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传自检结果
        /// </summary>
        /// <param name="ItemName">UploadDynSelfTestData(测功机自检),UploadAnaSelfTestData(上传分析仪自检数据),UploadOpaSelfTestData(上传不透光度计自检数据),UploadFloSelfTestData(上传流量计自检数据),UploadTacSelfTestData(上传转速计自检数据),UploadEleEnvData(上传电子环境信息仪数据)</param>
        /// <param name="ht"></param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendSelfCheckData(string ItemName, System.Collections.Hashtable ht, out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", ItemName);//设置该节点genre属性  
            XmlElement xe2 = xmldoc.CreateElement("SelfTestLog");//创建一个<Node>节点     

            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())//遍历哈希表的值,生成xml节点
            {
                XmlElement xe_ht = xmldoc.CreateElement((string)(myEnumerator.Key));//创建一个<Node>节点 
                xe_ht.InnerText = (string)(myEnumerator.Value);
                xe2.AppendChild(xe_ht);
            }
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = new NhWebReference.RetVal();
            switch (ItemName)
            {
                case "UploadDynSelfTestData":
                    retval = outlineservice.UploadDynSelfTestData(ConvertXmlToString(xmldoc)); break;
                case "UploadAnaSelfTestData":
                    retval = outlineservice.UploadAnaSelfTestData(ConvertXmlToString(xmldoc)); break;
                case "UploadOpaSelfTestData":
                    retval = outlineservice.UploadOpaSelfTestData(ConvertXmlToString(xmldoc)); break;
                case "UploadFloSelfTestData":
                    retval = outlineservice.UploadFloSelfTestData(ConvertXmlToString(xmldoc)); break;
                case "UploadTacSelfTestData":
                    retval = outlineservice.UploadTacSelfTestData(ConvertXmlToString(xmldoc)); break;
                case "UploadEleEnvData":
                    retval = outlineservice.UploadEleEnvData(ConvertXmlToString(xmldoc)); break;
                default:break;
            }
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 上传设备状态
        /// </summary>
        /// <param name="Status">1:空闲，2:正在检测,3：正在自检,4：正在标定,5：设备故障,6：检测程序退出或设备关闭</param>
        /// <param name="errorCode"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="exceptioncode"></param>
        /// <param name="ExceptionMessage"></param>
        /// <returns></returns>
        public bool SendUploadEquipmentStatus(string Status,out int errorCode, out string ErrorMessage, out int exceptioncode, out string ExceptionMessage)
        {
            exceptioncode = 0;
            ExceptionMessage = "";
            VehicleInfo vehiinfo = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "NHMessage", "");
            xmlelem.SetAttribute("StationNumber", stationID);
            xmlelem.SetAttribute("LineNumber", lineID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("NHMessage");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "UploadEquipmentStatus");//设置该节点genre属性  
            XmlElement xe2 = xmldoc.CreateElement("Status");//创建一个<Node>节点     
            xe2.InnerText = Status;
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            NhWebReference.RetVal retval = outlineservice.UploadEquipmentStatus(ConvertXmlToString(xmldoc));
            ini.INIIO.saveSocketLogInf("接收：\r\ncode:" + retval.ErrorCode.ToString() + "\r\nmsg:" + retval.ErrorMessage + "\r\nvalue:" + retval.Value);
            errorCode = retval.ErrorCode;
            ErrorMessage = retval.ErrorMessage;
            if (errorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
