using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using ini;
using System.Web;
using SYS_MODEL;
using SYS.Model;
using System.Text.RegularExpressions;

namespace AhWebClient
{
    public class SyncXml
    {
        public struct leadDriver
        {
            public string drivername;
            public string driverID;
        }
        public struct Operator
        {
            public string operatorname;
            public string operatorID;
        }
        public string Time { set; get; }
        public string StationID { set; get; }
        public string LeadDriverCount { set; get; }
        public string OperatorCount { set; get; }
        public string ProtocolVersion { set; get; }
        public string ProtocolDate { set; get; }
        public List<leadDriver> leadDriverlist { set; get; }
        public List<Operator> operatorlist { set; get; }
        public void addLeadDriver(string name,string id)
        {
            leadDriver leaddriver = new leadDriver();
            leaddriver.drivername = name;
            leaddriver.driverID = id;
            this.leadDriverlist.Add(leaddriver);
        }
        public void addOperator(string name, string id)
        {
            Operator leaddriver = new Operator();
            leaddriver.operatorname = name;
            leaddriver.operatorID = id;
            this.operatorlist.Add(leaddriver);
        }
    }
    public class AhCarInfo
    {
        public string InspectID { set; get; }
        public string InspectMethod { set; get; }

        public string PlateID { set; get; }
        public string PlateType { set; get; }
        public string BrandName { set; get; }
        public string ModelName { set; get; }
        public string CarType { set; get; }
        public string IfGoIntoCity { set; get; }
        public string IsTurbo { set; get; }
        public string FuelType { set; get; }
        public string IsClosingEI { set; get; }
        public string Is3WCC { set; get; }
        public string RatedSpeed { set; get; }
        public string DeliveryCapacity { set; get; }
        public string Cylinders { set; get; }
        public string StrokeCycles { set; get; }
        public string NominalPower { set; get; }
        public string FactoryDate { set; get; }
        public string BaseWeight { set; get; }
        public string WholeWeight { set; get; }
        public string RegDate { set; get; }
        public string PassengerCount { set; get; }
        public string GearType { set; get; }
        public string InspectCount { set; get; }
        public string DriveType{ set; get; }
    }
    public class Ahlimit
    {
        public string HCLimit { set; get; }
        public string COLimit { set; get; }
        public string NOLimit { set; get; }
        public string HC_NOLimit { set; get; }
        public string LowCOLimit { set; get; }
        public string LowCO2Limit { set; get; }
        public string LowHCLimit { set; get; }
        public string HiCOLimit { set; get; }
        public string HiCO2Limit { set; get; }
        public string HiHCLimit { set; get; }
        public string LMDLimitMin { set; get; }
        public string LMDLimitMax { set; get; }
        public string BtgYDLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为YDLimit
        public string HC5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025HCLimit
        public string CO5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025COLimit
        public string NO5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025NOLimit
        public string HC2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540HCLimit
        public string CO2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540COLimit
        public string NO2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540NOLimit
        public string LugdownYDLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为YDLimit
        public string LugdownPowerLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为PowerLimit

    }

    public class AhVmasResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string HC { set; get; }
        public string CO { set; get; }
        public string NO { set; get; }
        public string HC_NO { set; get; }
        public string HCLimit { set; get; }
        public string COLimit { set; get; }
        public string NOLimit { set; get; }
        public string HC_NOLimit { set; get; }
    }
    public class AhSdsResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string CrucialTime2 { set; get; }
        public string LowRPM { set; get; }
        public string LowCO { set; get; }
        public string LowCO2 { set; get; }
        public string LowHC { set; get; }
        public string HiRPM { set; get; }
        public string HiCO { set; get; }
        public string HiCO2 { set; get; }
        public string HiHC { set; get; }
        public string LMD { set; get; }
        public string LowCOLimit { set; get; }
        public string LowHCLimit { set; get; }
        public string HiCOLimit { set; get; }
        public string HiHCLimit { set; get; }
        public string LMDLimitMin { set; get; }
        public string LMDLimitMax { set; get; }
    }
    public class AhBtgResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string YD0 { set; get; }
        public string YD1 { set; get; }
        public string YD2 { set; get; }
        public string YD3 { set; get; }
        public string YDAV { set; get; }
        public string YDLimit { set; get; }
    }
    public class AhAsmResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string CrucialTime2 { set; get; }
        public string HC5025 { set; get; }
        public string CO5025 { set; get; }
        public string NO5025 { set; get; }
        public string HC2540 { set; get; }
        public string CO2540 { set; get; }
        public string NO2540 { set; get; }
        public string HC5025Limit { set; get; }
        public string CO5025Limit { set; get; }
        public string NO5025Limit { set; get; }
        public string HC2540Limit { set; get; }
        public string CO2540Limit { set; get; }
        public string NO2540Limit { set; get; }
    }
    public class AhLugdownResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
         public string CrucialTime2 { set; get; }
         public string CrucialTime3 { set; get; }
         public string YD1 { set; get; }
         public string YD2 { set; get; }
         public string YD3 { set; get; }
         public string Power { set; get; }
         public string YDLimit { set; get; }
         public string PowerLimit { set; get; }
     }
    public class selfCheckRecord
    {
        public string AllResult { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string SlideJudge { set; get; }
        public string HSSlideBeginTime { set; get; }
        public string HSSlideEndTime { set; get; }
        public string HSSlideTheoreticalTime { set; get; }
        public string HSSlideActualTime { set; get; }
        public string HSSlideLoadPower { set; get; }
        public string LSSlideBeginTime { set; get; }
        public string LSSlideEndTime { set; get; }
        public string LSSlideTheoreticalTime { set; get; }
        public string LSSlideActualTime { set; get; }
        public string LSSlideLoadPower { set; get; }
        public string WattlessOutputJudge { set; get; }
        public string WattlessOutputMaxSpeed1 { set; get; }
        public string WattlessOutputMinSpeed1 { set; get; }
        public string WattlessOutputNominalSpeed1 { set; get; }
        public string WattlessOutputBeginTime1 { set; get; }
        public string WattlessOutputEndTime1 { set; get; }
        public string WattlessOutput1 { set; get; }
        public string WattlessOutputMaxSpeed2 { set; get; }
        public string WattlessOutputMinSpeed2 { set; get; }
        public string WattlessOutputNominalSpeed2 { set; get; }
        public string WattlessOutputBeginTime2 { set; get; }
        public string WattlessOutputEndTime2 { set; get; }
        public string WattlessOutput2{ set; get; }
        public string WattlessOutputMaxSpeed3 { set; get; }
        public string WattlessOutputMinSpeed3 { set; get; }
        public string WattlessOutputNominalSpeed3 { set; get; }
        public string WattlessOutputBeginTime3 { set; get; }
        public string WattlessOutputEndTime3 { set; get; }
        public string WattlessOutput3{ set; get; }
        public string WattlessOutputMaxSpeed4 { set; get; }
        public string WattlessOutputMinSpeed4{ set; get; }
        public string WattlessOutputNominalSpeed4 { set; get; }
        public string WattlessOutputBeginTime4 { set; get; }
        public string WattlessOutputEndTime4 { set; get; }
        public string WattlessOutput4{ set; get; }
        public string O2MRJudge { get; set; }
        public string O2MRO2 { get; set; }
        public string O2MRFlow { get; set; }
        public string O2MRBeginTime { get; set; }
        public string O2MREndTime { get; set; }
        public string WQJudge { get; set; }
        public string WQTightness { get; set; }
        public string WQResidualHC { get; set; }
        public string WQFlowResult { get; set; }
        public string WQBeginTime { get; set; }
        public string WQEndTime { get; set; }
    }
    public class Ahinterface
    {
        Service outlineservice = null;
        public Dictionary<string, string> AHLINEID = new Dictionary<string, string>();
        public Ahinterface(string url)
        {
            outlineservice = new Service(url);
        }
        public void initLineId(string lineid)
        {
            string[] lineidary = lineid.Split(',');
            for(int i=1;i<=lineidary.Count();i++)
            {
                AHLINEID.Add(i.ToString("00"), lineidary[i-1]);
            }
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"UTF-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            //string newstring = xmlString.Replace("<xml version=\"1.0\">", "");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }
        public bool Sync(out int result,out string errMsg,out SyncXml syncxml,out List<string> urllist,out List<string> Messagelist)
        {
            result = 0;
            errMsg = "";
            syncxml = new SyncXml();
            urllist = new List<string>();
            Messagelist = new List<string>();
            try
            {
                RetValue retvalue = outlineservice.Sync("");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("Sync\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    noticeString = "<body>" + noticeString + "</body>";
                    if (noticeString != "")
                    {

                        ds = XmlToData.CXmlToDataSet(noticeString);
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            DataTable dt = ds.Tables[i];
                            urllist.Add(dt.Rows[0]["URL"].ToString());
                            Messagelist.Add(dt.Rows[0]["Message"].ToString());
                        }
                    }
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    //DataTable valuedt = ds.Tables["body"];
                    syncxml.Time = ds.Tables["body"].Rows[0]["Time"].ToString();
                    syncxml.StationID = ds.Tables["body"].Rows[0]["StationID"].ToString();
                    syncxml.ProtocolVersion = ds.Tables["body"].Rows[0]["ProtocolVersion"].ToString();
                    syncxml.ProtocolDate = ds.Tables["body"].Rows[0]["ProtocolDate"].ToString();
                    syncxml.LeadDriverCount = ds.Tables["LeadDriver"].Rows[0]["Count"].ToString();
                    syncxml.OperatorCount = ds.Tables["Operator"].Rows[0]["Count"].ToString();
                    syncxml.leadDriverlist = new List<SyncXml.leadDriver>();
                    syncxml.operatorlist = new List<SyncXml.Operator>();
                    if (int.Parse(syncxml.LeadDriverCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.LeadDriverCount); i++)
                        {
                            if (ds.Tables.Contains("Driver" + i.ToString()))
                            {
                                syncxml.addLeadDriver(ds.Tables["Driver" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Driver" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    if (int.Parse(syncxml.OperatorCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.OperatorCount); i++)
                        {
                            if (ds.Tables.Contains("Operator" + i.ToString()))
                            {
                                syncxml.addOperator(ds.Tables["Operator" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Operator" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByDate(DateTime starttime,DateTime endtime,out int result, out string errMsg, out List<AhCarInfo> ahcarinflist, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByDate(starttime.ToString("yyyy-MM-dd HH:mm:ss"), endtime.ToString("yyyy-MM-dd HH:mm:ss"), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByDate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo carinfo = new AhCarInfo();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                if (ds.Tables["CarInfo"].Columns.Contains("NominalPower"))
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                else
                                    carinfo.NominalPower = "60";
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLLX = "载客"; break;
                                    case "2": model.CLLX = "载货或特殊用途车"; break;
                                    case "3": model.CLLX = "低速货车"; break;
                                    case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                    case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                    default:
                                        model.CLLX = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = "";
                                model.XH = "";
                                model.CLSBM = "";
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = "";

                                model.FDJXH = "";
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = "";

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";


                                model.CSYS = "";
                                model.ZXBZ = "";

                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = "1";
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByPlate(string  palteID, int plateType, out int result, out string errMsg, out List<AhCarInfo> ahcarinflist,out List<CARATWAIT> caratwaitlist,out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByPlateID(palteID, plateType, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByPlateID\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo carinfo = new AhCarInfo();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLLX = "载客"; break;
                                    case "2": model.CLLX = "载货或特殊用途车"; break;
                                    case "3": model.CLLX = "低速货车"; break;
                                    case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                    case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                    default:
                                        model.CLLX = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = "";
                                model.XH = "";
                                model.CLSBM = "";
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = "";

                                model.FDJXH = "";
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = "";

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";



                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = "1";
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginRecord(string lineID, string  InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginRecord(long.Parse(AHLINEID[lineID]), InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginInspect(string lineID, string InspectID,string DirverID,string OperatorID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginInspect(long.Parse(AHLINEID[lineID]), InspectID, long.Parse(DirverID), long.Parse(OperatorID), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool TakePhoto(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.TakePhoto( InspectID,"");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("TakePhoto\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadVmasRealtimeData(string InspectID,DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if(dtseconds!=null)
                {
                    if(dtseconds.Rows.Count>0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");                        
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("VMASCount");
                        xe1.InnerText ="195";
                        root.AppendChild(xe1);
                        if (dtseconds != null)
                        {
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("VMAS"+i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                xe36.InnerText = dr["实时车速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("RPM");
                                xe37.InnerText = dr["发动机转速"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("HC");
                                xe38.InnerText = dr["HC实时值"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("CO");
                                xe39.InnerText = dr["CO实时值"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("NO");
                                xe40.InnerText = dr["NO实时值"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("O2");
                                xe41.InnerText = dr["分析仪O2实时值"].ToString();
                                XmlElement xe42 = xmldoc.CreateElement("CO2");
                                xe42.InnerText = dr["CO2实时值"].ToString();
                                XmlElement xe43 = xmldoc.CreateElement("O2_Flow");
                                xe43.InnerText = dr["流量计O2实时值"].ToString();
                                XmlElement xe44 = xmldoc.CreateElement("Flow_Act");
                                xe44.InnerText = dr["实际体积流量"].ToString();
                                XmlElement xe45 = xmldoc.CreateElement("Flow_Std");
                                xe45.InnerText = dr["标准体积流量"].ToString();
                                XmlElement xe46 = xmldoc.CreateElement("Flow_Ex");
                                xe46.InnerText = dr["尾气实际排放流量"].ToString();
                                XmlElement xe47 = xmldoc.CreateElement("HCMass");
                                xe47.InnerText = dr["HC排放质量"].ToString();
                                XmlElement xe48 = xmldoc.CreateElement("COMass");
                                xe48.InnerText = dr["CO排放质量"].ToString();
                                XmlElement xe49 = xmldoc.CreateElement("NOMass");
                                xe49.InnerText = dr["NO排放质量"].ToString();
                                XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                xe50.InnerText = dr["加载功率"].ToString();
                                XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                xe51.InnerText = dr["环境温度"].ToString();
                                XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                xe52.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe53 = xmldoc.CreateElement("Baro");
                                xe53.InnerText = dr["大气压力"].ToString();
                                XmlElement xe54 = xmldoc.CreateElement("Press_Flow");
                                xe54.InnerText = dr["流量计压力"].ToString();
                                XmlElement xe55 = xmldoc.CreateElement("Temperature_Flow");
                                xe55.InnerText = dr["流量计温度"].ToString();
                                XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                xe56.InnerText = dr["湿度修正系数"].ToString();
                                XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                xe57.InnerText = dr["稀释修正系数"].ToString();
                                XmlElement xe58 = xmldoc.CreateElement("DilutionRate");
                                xe58.InnerText = dr["稀释比"].ToString();
                                XmlElement xe59 = xmldoc.CreateElement("OilTemperature");
                                xe59.InnerText = dr["环境温度"].ToString();
                                XmlElement xe60 = xmldoc.CreateElement("O2_Env");
                                xe60.InnerText = dr["环境O2浓度"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                xe33.AppendChild(xe42);
                                xe33.AppendChild(xe43);
                                xe33.AppendChild(xe44);
                                xe33.AppendChild(xe45);
                                xe33.AppendChild(xe46);
                                xe33.AppendChild(xe47);
                                xe33.AppendChild(xe48);
                                xe33.AppendChild(xe49);
                                xe33.AppendChild(xe50);
                                xe33.AppendChild(xe51);
                                xe33.AppendChild(xe52);
                                xe33.AppendChild(xe53);
                                xe33.AppendChild(xe54);
                                xe33.AppendChild(xe55);
                                xe33.AppendChild(xe56);
                                xe33.AppendChild(xe57);
                                xe33.AppendChild(xe58);
                                xe33.AppendChild(xe59);
                                xe33.AppendChild(xe60);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID,xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadAsmRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("ASM5025_Count");
                        xe1.InnerText = "90";

                        XmlElement xe2 = xmldoc.CreateElement("ASM2540_Count");
                        xe2.InnerText = "90";
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        int asm5025count = 0;
                        int asm2540count = 0;
                        if (dtseconds != null)
                        {
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                DataRow dr = dtseconds.Rows[i];
                                if (dr["时序类别"].ToString() == "0")
                                {
                                    asm5025count++;
                                    XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = asm5025count.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                    xe36.InnerText = dr["实时车速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("RPM");
                                    xe37.InnerText = dr["转速"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("HC");
                                    xe38.InnerText = dr["HC实时值"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO");
                                    xe39.InnerText = dr["CO实时值"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("NO");
                                    xe40.InnerText = dr["NO实时值"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("O2");
                                    xe41.InnerText = dr["O2实时值"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("CO2");
                                    xe42.InnerText = dr["CO2实时值"].ToString();
                                    XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                    xe50.InnerText = dr["加载功率"].ToString();
                                    XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                    xe51.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                    xe52.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe53 = xmldoc.CreateElement("Baro");
                                    xe53.InnerText = dr["大气压力"].ToString();
                                    XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                    xe56.InnerText = dr["湿度修正系数"].ToString();
                                    XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                    xe57.InnerText = dr["稀释修正系数"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);
                                    xe33.AppendChild(xe50);
                                    xe33.AppendChild(xe51);
                                    xe33.AppendChild(xe52);
                                    xe33.AppendChild(xe53);
                                    xe33.AppendChild(xe56);
                                    xe33.AppendChild(xe57);
                                    root.AppendChild(xe33);
                                }
                                else if (dr["时序类别"].ToString() == "1")
                                {
                                    asm2540count++;
                                    XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + asm2540count.ToString("000"));//创建一个<Node>节点 
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = asm2540count.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                    xe36.InnerText = dr["实时车速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("RPM");
                                    xe37.InnerText = dr["转速"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("HC");
                                    xe38.InnerText = dr["HC实时值"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO");
                                    xe39.InnerText = dr["CO实时值"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("NO");
                                    xe40.InnerText = dr["NO实时值"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("O2");
                                    xe41.InnerText = dr["O2实时值"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("CO2");
                                    xe42.InnerText = dr["CO2实时值"].ToString();
                                    XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                    xe50.InnerText = dr["加载功率"].ToString();
                                    XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                    xe51.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                    xe52.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe53 = xmldoc.CreateElement("Baro");
                                    xe53.InnerText = dr["大气压力"].ToString();
                                    XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                    xe56.InnerText = dr["湿度修正系数"].ToString();
                                    XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                    xe57.InnerText = dr["稀释修正系数"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);
                                    xe33.AppendChild(xe50);
                                    xe33.AppendChild(xe51);
                                    xe33.AppendChild(xe52);
                                    xe33.AppendChild(xe53);
                                    xe33.AppendChild(xe56);
                                    xe33.AppendChild(xe57);
                                    root.AppendChild(xe33);
                                }
                            }
                            for (int i = asm5025count + 1; i <= 90; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + i.ToString("000"));
                                root.AppendChild(xe33);
                            }
                            for (int i = asm2540count + 1; i <= 90; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + i.ToString("000"));
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadLugdownRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        
                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("LugDown_Count");
                            xe1.InnerText = (dtseconds.Rows.Count-1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("LugDown" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["转速"].ToString();
                                XmlElement xe37= xmldoc.CreateElement("AbsorbedPower");
                                xe37.InnerText = dr["功率"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("CarSpeed");
                                xe38.InnerText = dr["车速"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("YD");
                                xe39.InnerText = dr["光吸收系数K"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("Temperature");
                                xe40.InnerText = dr["环境温度"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("Humidity");
                                xe41.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe42 = xmldoc.CreateElement("Baro");
                                xe42.InnerText = dr["大气压力"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                xe33.AppendChild(xe42);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadSdsRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("GSICount");
                            xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("GSI" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["转速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("HC");
                                xe37.InnerText = dr["HC"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("CO");
                                xe38.InnerText = dr["CO"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("CO2");
                                xe39.InnerText = dr["CO2"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("LMD");
                                xe40.InnerText = dr["过量空气系数"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("OilTemperature");
                                xe41.InnerText = dr["油温"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadBtgRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("FACount");
                            xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("FA" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText =DateTime.Parse( dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = dr["采样时序"].ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["发动机转速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("YD");
                                xe37.InnerText = dr["烟度值读数"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("Temperature");
                                xe38.InnerText = dr["环境温度"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("Humidity");
                                xe39.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("Baro");
                                xe40.InnerText = dr["大气压力"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectASM(string InspectID, AhAsmResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("5025HC");
                    xe8.InnerText = inspectResult.HC5025;
                    XmlElement xe9 = xmldoc.CreateElement("5025CO");
                    xe9.InnerText = inspectResult.CO5025;
                    XmlElement xe10 = xmldoc.CreateElement("5025NO");
                    xe10.InnerText = inspectResult.NO5025;
                    XmlElement xe11 = xmldoc.CreateElement("2540HC");
                    xe11.InnerText = inspectResult.HC2540;
                    XmlElement xe12 = xmldoc.CreateElement("2540CO");
                    xe12.InnerText = inspectResult.CO2540;
                    XmlElement xe13 = xmldoc.CreateElement("2540NO");
                    xe13.InnerText = inspectResult.NO2540;
                    XmlElement xe14 = xmldoc.CreateElement("5025HCLimit");
                    xe14.InnerText = inspectResult.HC5025Limit;
                    XmlElement xe15 = xmldoc.CreateElement("5025COLimit");
                    xe15.InnerText = inspectResult.CO5025Limit;
                    XmlElement xe16 = xmldoc.CreateElement("5025NOLimit");
                    xe16.InnerText = inspectResult.NO5025Limit;
                    XmlElement xe17 = xmldoc.CreateElement("2540HCLimit");
                    xe17.InnerText = inspectResult.HC2540Limit;
                    XmlElement xe18 = xmldoc.CreateElement("2540COLimit");
                    xe18.InnerText = inspectResult.CO2540Limit;
                    XmlElement xe19 = xmldoc.CreateElement("2540NOLimit");
                    xe19.InnerText = inspectResult.NO2540Limit;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);
                    root.AppendChild(xe15);
                    root.AppendChild(xe16);
                    root.AppendChild(xe17);
                    root.AppendChild(xe18);
                    root.AppendChild(xe19);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectSDS(string InspectID, AhSdsResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("LowRPM");
                    xe8.InnerText = inspectResult.LowRPM;
                    XmlElement xe9 = xmldoc.CreateElement("LowCO");
                    xe9.InnerText = inspectResult.LowCO;
                    XmlElement xe10 = xmldoc.CreateElement("LowCO2");
                    xe10.InnerText = inspectResult.LowCO2;
                    XmlElement xe11 = xmldoc.CreateElement("LowHC");
                    xe11.InnerText = inspectResult.LowHC;
                    XmlElement xe12 = xmldoc.CreateElement("HiRPM");
                    xe12.InnerText = inspectResult.HiRPM;
                    XmlElement xe13 = xmldoc.CreateElement("HiCO");
                    xe13.InnerText = inspectResult.HiCO;
                    XmlElement xe14 = xmldoc.CreateElement("HiCO2");
                    xe14.InnerText = inspectResult.HiCO2;
                    XmlElement xe15 = xmldoc.CreateElement("HiHC");
                    xe15.InnerText = inspectResult.HiHC;
                    XmlElement xe16 = xmldoc.CreateElement("LMD");
                    xe16.InnerText = inspectResult.LMD;
                    XmlElement xe17 = xmldoc.CreateElement("LowCOLimit");
                    xe17.InnerText = inspectResult.LowCOLimit;
                    XmlElement xe18 = xmldoc.CreateElement("LowHCLimit");
                    xe18.InnerText = inspectResult.LowHCLimit;
                    XmlElement xe19 = xmldoc.CreateElement("HiCOLimit");
                    xe19.InnerText = inspectResult.HiCOLimit;
                    XmlElement xe20 = xmldoc.CreateElement("HiHCLimit");
                    xe20.InnerText = inspectResult.HiHCLimit;
                    XmlElement xe21= xmldoc.CreateElement("LMDLimitMin");
                    xe21.InnerText = inspectResult.LMDLimitMin;
                    XmlElement xe22 = xmldoc.CreateElement("LMDLimitMax");
                    xe22.InnerText = inspectResult.LMDLimitMax;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);
                    root.AppendChild(xe15);
                    root.AppendChild(xe16);
                    root.AppendChild(xe17);
                    root.AppendChild(xe18);
                    root.AppendChild(xe19);
                    root.AppendChild(xe20);
                    root.AppendChild(xe21);
                    root.AppendChild(xe22);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectLugdown(string InspectID, AhLugdownResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("CrucialTime3");
                    xe8.InnerText = inspectResult.CrucialTime3;
                    XmlElement xe9 = xmldoc.CreateElement("YD1");
                    xe9.InnerText = inspectResult.YD1;
                    XmlElement xe10 = xmldoc.CreateElement("YD2");
                    xe10.InnerText = inspectResult.YD2;
                    XmlElement xe11 = xmldoc.CreateElement("YD3");
                    xe11.InnerText = inspectResult.YD3;
                    XmlElement xe12 = xmldoc.CreateElement("Power");
                    xe12.InnerText = inspectResult.Power;
                    XmlElement xe13 = xmldoc.CreateElement("YDLimit");
                    xe13.InnerText = inspectResult.YDLimit;
                    XmlElement xe14 = xmldoc.CreateElement("PowerLimit");
                    xe14.InnerText = inspectResult.PowerLimit;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectBtg(string InspectID, AhBtgResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("YD0");
                    xe6.InnerText = inspectResult.YD0;
                    XmlElement xe7 = xmldoc.CreateElement("YD1");
                    xe7.InnerText = inspectResult.YD1;
                    XmlElement xe8 = xmldoc.CreateElement("YD2");
                    xe8.InnerText = inspectResult.YD2;
                    XmlElement xe9 = xmldoc.CreateElement("YD3");
                    xe9.InnerText = inspectResult.YD3;
                    XmlElement xe10 = xmldoc.CreateElement("YDAV");
                    xe10.InnerText = inspectResult.YDAV;
                    XmlElement xe11 = xmldoc.CreateElement("YDLimit");
                    xe11.InnerText = inspectResult.YDLimit;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool StopInspect(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.StopInspect(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("StopInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetSdsLimit(string InspectID,out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            try
            {
                RetValue retvalue = outlineservice.GetLimit(InspectID,"");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();                    
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    
                    ahlimit.LowCOLimit = ds.Tables["body"].Rows[0]["LowCOLimit"].ToString();
                    ahlimit.LowCO2Limit = "";
                    ahlimit.LowHCLimit = ds.Tables["body"].Rows[0]["LowHCLimit"].ToString();
                    ahlimit.HiCOLimit = ds.Tables["body"].Rows[0]["HiCOLimit"].ToString();
                    ahlimit.HiCO2Limit ="";
                    ahlimit.HiHCLimit = ds.Tables["body"].Rows[0]["HiHCLimit"].ToString();

                    ahlimit.LMDLimitMin = ds.Tables["body"].Rows[0]["LMDLimitMin"].ToString();
                    ahlimit.LMDLimitMax = ds.Tables["body"].Rows[0]["LMDLimitMax"].ToString();
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetASMLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            try
            {
                RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    xmlstring = xmlstring.Replace("5025", "Limit5025");
                    xmlstring = xmlstring.Replace("2540", "Limit2540");
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    
                    ahlimit.HC5025Limit = ds.Tables["body"].Rows[0]["Limit5025HCLimit"].ToString();
                    ahlimit.CO5025Limit = ds.Tables["body"].Rows[0]["Limit5025COLimit"].ToString();
                    ahlimit.NO5025Limit = ds.Tables["body"].Rows[0]["Limit5025NOLimit"].ToString();
                    ahlimit.HC2540Limit = ds.Tables["body"].Rows[0]["Limit2540HCLimit"].ToString();
                    ahlimit.CO2540Limit = ds.Tables["body"].Rows[0]["Limit2540COLimit"].ToString();
                    ahlimit.NO2540Limit = ds.Tables["body"].Rows[0]["Limit2540NOLimit"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetVMASLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            try
            {
                RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    //DataTable valuedt = ds.Tables["body"];
                    ahlimit.HCLimit = ds.Tables["body"].Rows[0]["HCLimit"].ToString();
                    ahlimit.COLimit = ds.Tables["body"].Rows[0]["COLimit"].ToString();
                    ahlimit.NOLimit = ds.Tables["body"].Rows[0]["NOLimit"].ToString();
                    ahlimit.HC_NOLimit = ds.Tables["body"].Rows[0]["HC_NOLimit"].ToString();
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetJZJSLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            try
            {
                RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    
                    ahlimit.LugdownYDLimit = ds.Tables["body"].Rows[0]["YDLimit"].ToString();
                    ahlimit.LugdownPowerLimit = ds.Tables["body"].Rows[0]["PowerLimit"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetBTGLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            try
            {
                RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    
                    ahlimit.BtgYDLimit = ds.Tables["body"].Rows[0]["YDLimit"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }

        public bool EndInspect(string InspectID,XmlDocument inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                string xmlstring = ConvertXmlToString(inspectResult);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID,xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndRecord(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.EndRecord(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginSelfTest(string LineID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginSelfTest(long.Parse(LineID), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndSelfTest(string LineID,selfcheckdata selfTestResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (selfTestResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("AllResult");
                    xe1.InnerText = selfTestResult.AllJudge;
                    XmlElement xe2 = xmldoc.CreateElement("Temperature");
                    xe2.InnerText = selfTestResult.TEMP;
                    XmlElement xe3 = xmldoc.CreateElement("Humidity");
                    xe3.InnerText = selfTestResult.HUMI;
                    XmlElement xe4 = xmldoc.CreateElement("Baro");
                    xe4.InnerText = selfTestResult.AIRP;

                    XmlElement xe5 = xmldoc.CreateElement("SlideResult");
                    XmlElement xe51 = xmldoc.CreateElement("Judge");
                    xe51.InnerText = selfTestResult.SlideJudge;
                    XmlElement xe52 = xmldoc.CreateElement("HSSlideResult");
                    XmlElement xe521 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe522 = xmldoc.CreateElement("EndTime");
                    XmlElement xe523 = xmldoc.CreateElement("TheoreticalTime");
                    XmlElement xe524 = xmldoc.CreateElement("ActualTime");
                    XmlElement xe525 = xmldoc.CreateElement("LoadPower");
                    xe521.InnerText = selfTestResult.HSSlideBeginTime;
                    xe522.InnerText = selfTestResult.HSSlideEndTime;
                    xe523.InnerText = selfTestResult.HSSlideTheoreticalTime;
                    xe524.InnerText = selfTestResult.HSSlideActualTime;
                    xe525.InnerText = selfTestResult.HSSlideLoadPower;
                    xe52.AppendChild(xe521);
                    xe52.AppendChild(xe522);
                    xe52.AppendChild(xe523);
                    xe52.AppendChild(xe524);
                    xe52.AppendChild(xe525);
                    XmlElement xe53 = xmldoc.CreateElement("LSSlideResult");
                    XmlElement xe531 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe532 = xmldoc.CreateElement("EndTime");
                    XmlElement xe533 = xmldoc.CreateElement("TheoreticalTime");
                    XmlElement xe534 = xmldoc.CreateElement("ActualTime");
                    XmlElement xe535 = xmldoc.CreateElement("LoadPower");
                    xe531.InnerText = selfTestResult.LSSlideBeginTime;
                    xe532.InnerText = selfTestResult.LSSlideEndTime;
                    xe533.InnerText = selfTestResult.LSSlideTheoreticalTime;
                    xe534.InnerText = selfTestResult.LSSlideActualTime;
                    xe535.InnerText = selfTestResult.LSSlideLoadPower;
                    xe53.AppendChild(xe531);
                    xe53.AppendChild(xe532);
                    xe53.AppendChild(xe533);
                    xe53.AppendChild(xe534);
                    xe53.AppendChild(xe535);
                    xe5.AppendChild(xe51);
                    xe5.AppendChild(xe52);
                    xe5.AppendChild(xe53);

                    XmlElement xe6 = xmldoc.CreateElement("WattlessOutputResult");
                    XmlElement xe61 = xmldoc.CreateElement("Judge");
                    xe61.InnerText = selfTestResult.WattlessJudge;
                    XmlElement xe62 = xmldoc.CreateElement("SpeedRange1");
                    XmlElement xe621 = xmldoc.CreateElement("MaxSpeed");
                    XmlElement xe622 = xmldoc.CreateElement("MinSpeed");
                    XmlElement xe623 = xmldoc.CreateElement("NominalSpeed");
                    XmlElement xe624 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe625 = xmldoc.CreateElement("EndTime");
                    XmlElement xe626 = xmldoc.CreateElement("WattlessOutput");
                    xe621.InnerText = selfTestResult.WattlessMaxSpeed1;
                    xe622.InnerText = selfTestResult.WattlessMinSpeed1;
                    xe623.InnerText = selfTestResult.WattlessNorminalSpeed1;
                    xe624.InnerText = selfTestResult.WattlessBeginTime1;
                    xe625.InnerText = selfTestResult.WattlessEndTime1;
                    xe626.InnerText = selfTestResult.WattlessOutput1;
                    xe62.AppendChild(xe621);
                    xe62.AppendChild(xe622);
                    xe62.AppendChild(xe623);
                    xe62.AppendChild(xe624);
                    xe62.AppendChild(xe625);
                    xe62.AppendChild(xe626);
                    XmlElement xe63= xmldoc.CreateElement("SpeedRange2");
                    XmlElement xe631 = xmldoc.CreateElement("MaxSpeed");
                    XmlElement xe632 = xmldoc.CreateElement("MinSpeed");
                    XmlElement xe633 = xmldoc.CreateElement("NominalSpeed");
                    XmlElement xe634 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe635 = xmldoc.CreateElement("EndTime");
                    XmlElement xe636 = xmldoc.CreateElement("WattlessOutput");
                    xe631.InnerText = selfTestResult.WattlessMaxSpeed2;
                    xe632.InnerText = selfTestResult.WattlessMinSpeed2;
                    xe633.InnerText = selfTestResult.WattlessNorminalSpeed2;
                    xe634.InnerText = selfTestResult.WattlessBeginTime2;
                    xe635.InnerText = selfTestResult.WattlessEndTime2;
                    xe636.InnerText = selfTestResult.WattlessOutput2;
                    xe63.AppendChild(xe631);
                    xe63.AppendChild(xe632);
                    xe63.AppendChild(xe633);
                    xe63.AppendChild(xe634);
                    xe63.AppendChild(xe635);
                    xe63.AppendChild(xe636);
                    XmlElement xe64 = xmldoc.CreateElement("SpeedRange3");
                    XmlElement xe641 = xmldoc.CreateElement("MaxSpeed");
                    XmlElement xe642 = xmldoc.CreateElement("MinSpeed");
                    XmlElement xe643 = xmldoc.CreateElement("NominalSpeed");
                    XmlElement xe644 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe645 = xmldoc.CreateElement("EndTime");
                    XmlElement xe646 = xmldoc.CreateElement("WattlessOutput");
                    xe641.InnerText = selfTestResult.WattlessMaxSpeed3;
                    xe642.InnerText = selfTestResult.WattlessMinSpeed3;
                    xe643.InnerText = selfTestResult.WattlessNorminalSpeed3;
                    xe644.InnerText = selfTestResult.WattlessBeginTime3;
                    xe645.InnerText = selfTestResult.WattlessEndTime3;
                    xe646.InnerText = selfTestResult.WattlessOutput3;
                    xe64.AppendChild(xe641);
                    xe64.AppendChild(xe642);
                    xe64.AppendChild(xe643);
                    xe64.AppendChild(xe644);
                    xe64.AppendChild(xe645);
                    xe64.AppendChild(xe646);
                    XmlElement xe65 = xmldoc.CreateElement("SpeedRange4");
                    XmlElement xe651 = xmldoc.CreateElement("MaxSpeed");
                    XmlElement xe652 = xmldoc.CreateElement("MinSpeed");
                    XmlElement xe653 = xmldoc.CreateElement("NominalSpeed");
                    XmlElement xe654 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe655 = xmldoc.CreateElement("EndTime");
                    XmlElement xe656 = xmldoc.CreateElement("WattlessOutput");
                    xe651.InnerText = selfTestResult.WattlessMaxSpeed4;
                    xe652.InnerText = selfTestResult.WattlessMinSpeed4;
                    xe653.InnerText = selfTestResult.WattlessNorminalSpeed4;
                    xe654.InnerText = selfTestResult.WattlessBeginTime4;
                    xe655.InnerText = selfTestResult.WattlessEndTime4;
                    xe656.InnerText = selfTestResult.WattlessOutput4;
                    xe65.AppendChild(xe651);
                    xe65.AppendChild(xe652);
                    xe65.AppendChild(xe653);
                    xe65.AppendChild(xe654);
                    xe65.AppendChild(xe655);
                    xe65.AppendChild(xe656);

                    xe6.AppendChild(xe61);
                    xe6.AppendChild(xe62);
                    xe6.AppendChild(xe63);
                    xe6.AppendChild(xe64);
                    xe6.AppendChild(xe65);

                    XmlElement xe7 = xmldoc.CreateElement("O2MR");
                    XmlElement xe71 = xmldoc.CreateElement("Judge");
                    XmlElement xe72 = xmldoc.CreateElement("O2");
                    XmlElement xe73 = xmldoc.CreateElement("Flow");
                    XmlElement xe74 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe75 = xmldoc.CreateElement("EndTime");
                    xe7.AppendChild(xe71);
                    xe7.AppendChild(xe72);
                    xe7.AppendChild(xe73);
                    xe7.AppendChild(xe74);
                    xe7.AppendChild(xe75);

                    XmlElement xe8 = xmldoc.CreateElement("WQResult");
                    XmlElement xe81 = xmldoc.CreateElement("Judge");
                    XmlElement xe82 = xmldoc.CreateElement("Tightness");
                    XmlElement xe83 = xmldoc.CreateElement("ResidualHC");
                    XmlElement xe84 = xmldoc.CreateElement("FlowResult");
                    XmlElement xe85 = xmldoc.CreateElement("BeginTime");
                    XmlElement xe86 = xmldoc.CreateElement("EndTime");
                    xe81.InnerText = selfTestResult.WQJudge;
                    xe82.InnerText = (selfTestResult.FQYJL=="Y"?"1":"2");
                    xe83.InnerText = "1";
                    xe84.InnerText = "1";
                    xe85.InnerText = selfTestResult.WQBeginTime;
                    xe86.InnerText = selfTestResult.WQEndTime;
                    xe8.AppendChild(xe81);
                    xe8.AppendChild(xe82);
                    xe8.AppendChild(xe83);
                    xe8.AppendChild(xe84);
                    xe8.AppendChild(xe85);
                    xe8.AppendChild(xe86);
                    
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndSelfTest(long.Parse(LineID), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskcount">0：表示所有待检及已发布的任务>0：表示按登记时间排序的车辆任务数</param>
        /// <returns></returns>
        public string getInspReg(int taskcount, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            string xmlstring = outlineservice.getInspReg(securitycode, inspstationcode, insplinecode, taskcount);
            INIIO.saveSocketLogInf("RECEIVE:\r\n" + xmlstring);
            string result = getCarWaitList(xmlstring, out carwaitlist, out carinflist);
            return result;
        }
        public string getInspReg2(string plateno, string platecolor, string vin8, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            string xmlstring = outlineservice.getInspReg2(securitycode, inspstationcode, plateno, platecolor, vin8);
            INIIO.saveSocketLogInf("RECEIVE:\r\n" + xmlstring);
            string result = getCarWaitList(xmlstring, out carwaitlist, out carinflist);
            return result;
        }

        private string getCarWaitList(string xmlstring, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);
                string errorinfo = ds.Tables[0].Rows[0]["errorinfo"].ToString();
                //Console.Write(errorinfo + "/r/n");
                switch (errorinfo)
                {
                    case "ERROR-001":
                        return "请求参数securitycode(安全码)不能为空";
                        break;
                    case "ERROR-002":
                        return "请求参数inspstationcode (检测站代码)不能为空";
                        break;
                    case "ERROR-003":
                        return "请求参数taskcount(检测登记任务数)值需>=0";
                        break;
                    case "ERROR-004":
                        return "该检测站代码对应的安全码验证失败";
                        break;
                    case "ERROR-005":
                        return "请求参数insplinecode(检测线代码)不能为空";
                        break;
                    default: break;
                }
                DataTable vehicletable = ds.Tables["vehicle"];
                DataTable ownertable = ds.Tables["owner"];
                DataTable regtable = ds.Tables["reg"];

                for (int i = 0; i < vehicletable.Rows.Count; i++)
                {
                    CARINF model = new CARINF();
                    model.CLHP = vehicletable.Rows[i]["PLATENO"].ToString();
                    model.HPZL = vehicletable.Rows[i]["PLATECLASS"].ToString();
                    model.CPYS = vehicletable.Rows[i]["PLATECOLOR"].ToString();
                    model.CLLX = vehicletable.Rows[i]["GAVTYPE"].ToString();
                    model.CZ = vehicletable.Rows[i]["OWNERNAME"].ToString();
                    model.SYXZ = vehicletable.Rows[i]["GAUSEC"].ToString();
                    model.PP = vehicletable.Rows[i]["BRAND"].ToString();
                    model.XH = vehicletable.Rows[i]["MODEL"].ToString();
                    model.CLSBM = vehicletable.Rows[i]["VIN"].ToString();
                    model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                    //model.FDJHM = "";

                    model.FDJXH = vehicletable.Rows[i]["ENGINEMODEL"].ToString();
                    model.SCQY = vehicletable.Rows[i]["MANUFNAME"].ToString();
                    model.HDZK = vehicletable.Rows[i]["PASSCAP"].ToString();
                    model.JSSZK = "0";
                    model.ZZL = vehicletable.Rows[i]["GROSSWEIGHT"].ToString();
                    model.HDZZL = vehicletable.Rows[i]["REATEDWEIGHT"].ToString();
                    model.ZBZL = vehicletable.Rows[i]["CURBWEIGHT"].ToString();
                    model.JZZL = vehicletable.Rows[i]["RMWEIGHT"].ToString();
                    model.ZCRQ = DateTime.Parse(vehicletable.Rows[i]["FIRSTREGDATE"].ToString());
                    model.SCRQ = DateTime.Parse(vehicletable.Rows[i]["EXFACTORYDATE"].ToString());

                    model.FDJPL = vehicletable.Rows[i]["DISPLACEMENT"].ToString();
                    model.RLZL = vehicletable.Rows[i]["FUELTYPE"].ToString();
                    model.EDGL = vehicletable.Rows[i]["REATEDPOWER"].ToString();
                    model.EDZS = vehicletable.Rows[i]["REATEDSPEED"].ToString();
                    model.BSQXS = vehicletable.Rows[i]["GEARBOXTYPE"].ToString();
                    model.DWS = vehicletable.Rows[i]["GEARNUM"].ToString();
                    model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                    //model.GYFS = "";
                    model.DPFS = "";
                    model.JQFS = vehicletable.Rows[i]["AIRSUCTION"].ToString();
                    model.QGS = vehicletable.Rows[i]["CLINDYERNUM"].ToString();

                    model.QDXS = vehicletable.Rows[i]["DRIVEMODE"].ToString();
                    model.CHZZ = "";
                    model.DLSP = "";
                    model.SFSRL = "";
                    if (model.RLZL == "B")
                        model.JHZZ = vehicletable.Rows[i]["OXYGENSENSOR"].ToString();
                    else
                        model.JHZZ = vehicletable.Rows[i]["EXHAUSTDISPOSAL"].ToString();
                    model.OBD = "";
                    model.DKGYYB = "";
                    model.LXDH = ownertable.Rows[i]["TELNO"].ToString();
                    model.CLZL = "";
                    model.CZDZ = ownertable.Rows[i]["ADDRESS"].ToString();

                    model.JCFS = "";
                    model.JCLB = "";
                    model.SSXQ = vehicletable.Rows[i]["PLATECOLOR"].ToString();
                    model.FDJSCQY = "";
                    model.QDLTQY = "";
                    model.RYPH = "";
                    model.SFWDZR = "";
                    model.SFYQBF = "";
                    CARATWAIT waitmodel = new CARATWAIT();
                    waitmodel.CLID = vehicletable.Rows[i]["ID"].ToString();
                    waitmodel.CLHP = regtable.Rows[i]["PLATENO"].ToString();
                    waitmodel.DLSJ = DateTime.Now;
                    waitmodel.CPYS = regtable.Rows[i]["PLATECOLOR"].ToString();
                    switch (regtable.Rows[i]["TESTMETHOD"].ToString())
                    {
                        case "1":
                            waitmodel.JCFF = "DS";
                            break;
                        case "2":
                            waitmodel.JCFF = "SDS";
                            break;
                        case "3":
                            waitmodel.JCFF = "LZ";
                            break;
                        case "4":
                            waitmodel.JCFF = "ZYJS";
                            break;
                        case "5":
                            waitmodel.JCFF = "ASM";
                            break;
                        case "6":
                            waitmodel.JCFF = "VMAS";
                            break;
                        case "7":
                            waitmodel.JCFF = "JZJS";
                            break;
                        case "8":
                            waitmodel.JCFF = "MAS";
                            break;
                        case "9":
                            waitmodel.JCFF = "LS";
                            break;
                        default: break;
                    }
                    waitmodel.XSLC = regtable.Rows[i]["TRAVELMILES"].ToString();
                    waitmodel.JCCS = regtable.Rows[i]["INSPTIMES"].ToString();
                    waitmodel.CZY = "";
                    waitmodel.JSY = "";
                    waitmodel.DLY = regtable.Rows[i]["REGUSERID"].ToString();
                    waitmodel.TEST = "";
                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                    waitmodel.JCBGBH = "";
                    waitmodel.JCGWH = "";
                    waitmodel.JCZBH = regtable.Rows[i]["INSPSTATIONCODE"].ToString();
                    waitmodel.JCRQ = DateTime.Now;
                    waitmodel.BGJCFFYY = "";
                    waitmodel.SFCS = "";
                    waitmodel.ECRYPT = "";
                    waitmodel.SFCJ = (int.Parse(regtable.Rows[i]["INSPTIMES"].ToString()) > 1 ? "复检" : "初检");
                    waitmodel.JYLSH = "";
                    waitmodel.HPZL = regtable.Rows[i]["PLATECLASS"].ToString();
                    carinflist.Add(model);
                    carwaitlist.Add(waitmodel);
                }
                return "获取成功";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }*/
    }
}
