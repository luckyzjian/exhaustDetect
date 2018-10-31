using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Xml;
using ini;
using System.IO;
/*32位系统注释*/
//using LineClient;
using SYS.Model;
using System.Text.RegularExpressions;

namespace carinfor
{

    public class JsBaseTypeInfo
    {
        public string IS_DELETE;//0:正常 1:删除
        public string OPERRATIONAL_STATE;//0:正常 1:故障
        public string GOVEMENCE_STATE;//0:待审批 1:正常 2:警告 3:过期 4:撤销
        public string SIGN_ISSUE_TYPE;//1:检测发标  0：新车发标
    }
    public class JsVehicleInfo
    {
        public string vehicleid;
        public string citycode;
        public string plate;
        public string plate_color;
        public string plate_type;
        public string vin;
        public DateTime manufacture_date;
        public string factory_name;
        public string clsb;
        public string clxh;
        public string fdjxh;
        public string engine_no;
        public DateTime register_date;
        public string check_period;
        public string vehicle_kind;
        public string vehicle_style;
        public string is_service_car;
        public string vehicle_state;
        public string vehicle_status;
        public string standard_id;
        public string inspection_type;
        public string odo_meter;
        public string maxweight;
        public string stdweight;
        public string drive_form;
        public string drive_mode;
        public string fuel_type;
        public string supply_mode;
        public string exhaust_quantity;
        public string rating_power;
        public string has_odb;
        public string has_purge;
        public string is_electronic_ctrl;
        public string seat_capacity;
        public string ordain_rev;
        public string cylinder;
        public string stroke;
        public string admission;
        public string is_rebuild;
        public string near_unit_id;
        public string near_check_date;
        public string sign_type;
        public string sign_state;
        public string vehicle_card_id;
        public string owner;
        public string owneraddress;
        public string phone;

    }
    public class JsCheckLimit
    {
        public string AmbientCOUp;
        public string AmbientCO2Up;
        public string AmbientHCUp;
        public string AmbientNOUp;
        public string BackgroundCOUp;
        public string BackgroundCO2Up;
        public string BackgroundHCUp;
        public string BackgroundNOUp;
        public string ResidualHCUp;
        public string COAndCO2;
        public string CO5025;
        public string HC5025;
        public string NO5025;
        public string CO2540;
        public string HC2540;
        public string NO2540;
        public string HighIdleCO;
        public string HighIdleHC;
        public string LowIdleCO;
        public string LowIdleHC;
        public string FASmokeK;
        public string FARev;
    }
    public class JsDemarcateLimit
    {
        public string COChkAbs;
        public string HCChkAbs;
        public string NOChkAbs;
        public string CO2ChkAbs;
        public string O2ChkAbs;
        public string COChkRel;
        public string HCChkRel;
        public string NOChkRel;
        public string CO2ChkRel;
        public string O2ChkRel;
        public string COCalAbs;
        public string HCCalAbs;
        public string NOCalAbs;
        public string CO2CalAbs;
        public string O2CalAbs;
        public string COCalRel;
        public string HCCalRel;
        public string NOCalRel;
        public string CO2CalRel;
        public string O2CalRel;
        public string HCT90;
        public string COT90;
        public string NOT90;
        public string CO2T90;
        public string O2T90;
        public string HCT10;
        public string COT10;
        public string NOT10;
        public string CO2T10;
        public string O2T10;
        public string Smoke;
        public string Rev;
        public string Temperature;
        public string Humidity;
        public string AirPressure;
        public string Coastdown;
        public string Torque;
        public string Velocity;
        public string ParasiticLoss;

    }
    public class JsUploadInspectionResult
    {
        public string COSet;
        public string HCSet;
        public string NOSet;
        public string CO2Set;
        public string O2Set;
        public string COChk;
        public string HCChk;
        public string NOChk;
        public string CO2Chk;
        public string O2Chk;
        public string ChkReslut;
        public string COCal;
        public string HCCal;
        public string NOCal;
        public string CO2Cal;
        public string O2Cal;
        public string CalReslut;
        public string SmokeSet;
        public string SmokeCal;
        public string SmokeResult;
        public string TemperatureSet;
        public string TemperatureReal;
        public string TemperatureResult;
        public string HumiditySet;
        public string HumidityReal;
        public string HumidityResult;
        public string AirPressureSet;
        public string AirPressureReal;
        public string AirPressureResult;
        public string Coastdown64SetTime;
        public string Coastdown64RealTime;
        public string Coastdown64Result;
        public string Coastdown48SetTime;
        public string Coastdown48RealTime;
        public string Coastdown48Result;
        public string ParasiticLossHiSpeed;
        public string ParasiticLossLowSpeed;
        public string ParasiticLossLowTime;
        public string Inertia;
        public string ParasiticPower;
    }
    public class JsAsmResultData
    {
        public string check_id;
        public string check_type;
        public string citycode;
        public string unit_id;
        public string device_id;
        public string vhicleid;
        public string odo_meter;
        public string check_data;
        public string starttime;
        public string end_time;
        public string temperature;
        public string pressure;
        public string humidity;
        public string kh_retouch;
        public string dcf_retouch_25;
        public string dcf_retouch_40;
        public string co_5025;
        public string co_5025_limit;
        public string co_5025_result;
        public string hc_5025;
        public string hc_5025_limit;
        public string hc_5025_result;
        public string no_5025;
        public string no_5025_limit;
        public string no_5025_result;
        public string power_5025;
        public string rev_5025;
        public string lambda_5025;
        public string co_2540;
        public string co_2540_limit;
        public string co_2540_result;
        public string hc_2540;
        public string hc_2540_limit;
        public string hc_2540_result;
        public string no_2540;
        public string no_2540_limit;
        public string no_2540_result;
        public string power_2540;
        public string rev_2540;
        public string lambda_2540;
        public string passed;
    }
    public class JsAsmProcessData
    {
        public string check_id;
        public string time_no;
        public string vehicle_speed;
        public string rpm;
        public string torque;
        public string power;
        public string hc;
        public string co;
        public string no;
        public string co2;
        public string o2;
    }
    public class JsSdsResultData
    {
        public string check_id;
        public string check_type;
        public string citycode;
        public string unit_id;
        public string device_id;
        public string vhicleid;
        public string odo_meter;
        public string check_data;
        public string starttime;
        public string end_time;
        public string temperature;
        public string pressure;
        public string humidity;
        public string lambda;
        public string lambda_limit;
        public string lambda_passed;

        public string lowidle_co;
        public string low_co_limit;
        public string lowidle_hc;
        public string low_hc_limit;
        public string low_passed;
        public string highidle_co;
        public string high_co_limit;
        public string highidle_hc;
        public string high_hc_limit;
        public string high_passed;
        public string passed;
    }
    public class JsSdsProcessData
    {
        public string check_id;
        public string time_no;
        public string is_high_idle;
        public string hc;
        public string co;
    }
    public class JsBtgResultData
    {
        public string check_id;
        public string check_type;
        public string citycode;
        public string unit_id;
        public string device_id;
        public string vhicleid;
        public string odo_meter;
        public string check_data;
        public string starttime;
        public string end_time;
        public string temperature;
        public string pressure;
        public string humidity;
        public string idle_rev;
        public string smoke_b1;
        public string smoke_b2;
        public string smoke_b3;
        public string smoke_avg;
        public string smoke_limit;
        public string passed;
    }
    public class jsSocketControl
    {
        /*32位系统注释*/
        //private LineClient.LineConnector lineclient = new LineConnector();
        public Dictionary<string, string> STANDARD_ID2 = new Dictionary<string, string>();
        public Dictionary<string, string> USER_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> USER_SEX = new Dictionary<string, string>();
        public Dictionary<string, string> CITYCODE_PROVINCE = new Dictionary<string, string>();
        public Dictionary<string, string> CITYCODE_PLATE = new Dictionary<string, string>();
        public Dictionary<string, string> IS_PRINT = new Dictionary<string, string>();
        public Dictionary<string, string> RE_SIGN_REASON = new Dictionary<string, string>();
        public Dictionary<string, string> CANCEL_REASON = new Dictionary<string, string>();
        public Dictionary<string, string> CARD_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> COLOR = new Dictionary<string, string>();
        public Dictionary<string, string> VIOLATION = new Dictionary<string, string>();
        public Dictionary<string, string> PICMARK = new Dictionary<string, string>();
        public Dictionary<string, string> IS_UPLOAD = new Dictionary<string, string>();
        public Dictionary<string, string> OPERRATIONAL_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> CLLB = new Dictionary<string, string>();
        public Dictionary<string, string> PLATE_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> GOVEMANCE_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> SIGN_ISSUE_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> STANDARD_ID = new Dictionary<string, string>();
        public Dictionary<string, string> INSPECTION_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> VEHICLE_BODY_COLOR = new Dictionary<string, string>();
        public Dictionary<string, string> EQUIP_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> IS_CHECK = new Dictionary<string, string>();
        public Dictionary<string, string> VIOLATE_REASON = new Dictionary<string, string>();
        public Dictionary<string, string> DRIVE_MODE = new Dictionary<string, string>();
        public Dictionary<string, string> CITYCODE_LOCAL = new Dictionary<string, string>();
        public Dictionary<string, string> IS_REBUILD = new Dictionary<string, string>();
        public Dictionary<string, string> PLATE_COLOR = new Dictionary<string, string>();
        public Dictionary<string, string> VEHICLE_KIND = new Dictionary<string, string>();
        public Dictionary<string, string> DRIVE_FORM = new Dictionary<string, string>();
        public Dictionary<string, string> FUEL_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> ADMISSION = new Dictionary<string, string>();
        public Dictionary<string, string> SUPPLY_MODE = new Dictionary<string, string>();
        public Dictionary<string, string> IS_ELECTRONIC_CTRL = new Dictionary<string, string>();
        public Dictionary<string, string> VEHICLE_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> VEHICLE_STYLE = new Dictionary<string, string>();
        public Dictionary<string, string> SIGN_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> DEVICETYPE = new Dictionary<string, string>();
        public Dictionary<string, string> STATE = new Dictionary<string, string>();
        public Dictionary<string, string> CHECK_PERIOD = new Dictionary<string, string>();
        public Dictionary<string, string> CHECK_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> PASSED = new Dictionary<string, string>();
        public Dictionary<string, string> CITYCODE_MAIN = new Dictionary<string, string>();
        public Dictionary<string, string> VEHICLE_STATUS = new Dictionary<string, string>();
        public Dictionary<string, string> DIRECTION = new Dictionary<string, string>();
        public Dictionary<string, string> EDUCATIONAL = new Dictionary<string, string>();
        public Dictionary<string, string> DUTY = new Dictionary<string, string>();
        public Dictionary<string, string> SPECIALTY = new Dictionary<string, string>();
        public Dictionary<string, string> IS_DELETE = new Dictionary<string, string>();
        public Dictionary<string, string> IS_CHECK_LOGIN = new Dictionary<string, string>();
        public Dictionary<string, string> IS_CANCEL = new Dictionary<string, string>();
        public Dictionary<string, string> SIGN_REASON = new Dictionary<string, string>();
        public Dictionary<string, string> IS_SERVICE_CAR = new Dictionary<string, string>();
        public Dictionary<string, string> APPROVAL_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> CARD_IS_UPLOAD = new Dictionary<string, string>();
        public Dictionary<string, string> APPLY_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> HAS_PURGE = new Dictionary<string, string>();
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertXmlToArray(XmlDocument xmlDoc)
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"gb2312\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            newstring = newstring.Replace("\"", "'");//将所有双引号换成单引号
            newstring += "\r\n\r\n\r\n";//在结尾处添加\r\n\r\n\r\n标志结尾
            saveLogInf(newstring);//保存日志
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);//按GB2312转化
            return bufferToSend;
        }
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
            saveLogInf(newstring);//保存日志
            newstring = newstring.Replace("\r\n", "");
            newstring = Regex.Replace(newstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
            return newstring;
        }
        /// <summary>  
        /// 将string转化为byte[],并加上头(0x02)和尾(0x03)  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertStringToByteArray(string sendstring)
        {
            ini.INIIO.saveLogInf("Send To CC server:\r\n" + sendstring);
            byte[] buffer = System.Text.Encoding.GetEncoding("gb2312").GetBytes(sendstring);
            byte[] bufferToSend = new byte[buffer.Length + 2];
            bufferToSend[0] = 0x02;
            for (int i = 0; i < buffer.Length; i++)
            {
                bufferToSend[i + 1] = buffer[i];
            }
            bufferToSend[buffer.Length + 1] = 0x03;
            return bufferToSend;
        }
        private void setXmlElementAttribute(XmlElement xe, string attributeName, string attributeValue)
        {
            xe.SetAttribute(attributeName, attributeValue);
        }
        private void setXmlElementInerText(XmlElement xe, string inertext)
        {
            xe.InnerText = inertext;
        }
        public void connectServer(out bool status, out string errMsg)
        {
            status = false;
            errMsg = "";
            string xmlstring = "";
            /*32位系统注释*/
            //lineclient.ConnectServer(out status, out errMsg);
        }

        public string getBaseTypeInfo(out bool status, out string errMsg)
        {
            string ack = "";
            status = false;
            errMsg = "";
            string xmlstring = "";
            /*32位系统注释*/
            //lineclient.GetBaseTypeInfo(out xmlstring, out status, out errMsg);
            if (status)
            {
                ini.INIIO.saveLogInf("GetBaseTypeInfo:\r\nXml:" + xmlstring + "\r\nstatus:" + status + "\r\nerrMsg:" + errMsg);
                ack = getDictionary(xmlstring);
            }
            return ack;
        }
        public void loginServer(string userName, string password, out bool status, out string errMsg)
        {
            status = false;
            errMsg = "";
            string xmlstring = "";
            /*32位系统注释*/
            //lineclient.LoginServer(userName, password, out status, out errMsg);
        }
        public void changePassword(string userName, string password, string newpassword, out bool status, out string errMsg)
        {
            status = false;
            errMsg = "";
            string xmlstring = "";
            /*32位系统注释*/
            //lineclient.ChangePassword(userName, password, newpassword, out status, out errMsg);
        }
        public string getveicleInfo(string plate, string plateColor, out JsVehicleInfo jsvehicleinfo, out CARINF vehicleinfo, out CARATWAIT waitmodel, out JsCheckLimit checklimit, out bool status, out string errMsg)
        {
            string ack = "";
            jsvehicleinfo = new JsVehicleInfo();
            vehicleinfo = new CARINF();
            waitmodel = new CARATWAIT();
            checklimit = new JsCheckLimit();
            status = false;
            errMsg = "";
            string vehicleinfoxmlstring = "", limitxmlstring = "";
            /*32位系统注释*/
            //lineclient.GetVehicleInfo(plate, plateColor, out vehicleinfoxmlstring, out limitxmlstring, out status, out errMsg);
            if (status)
            {
                ini.INIIO.saveLogInf("getveicleInfo:\r\nstatus:" + status + "\r\nerrMsg:" + errMsg + "\r\nvehicleinfoxmlstring:\r\nXml:" + vehicleinfoxmlstring + "\r\nlimitxmlstring:\r\nXml:" + limitxmlstring);
                ack += getJsVehicleInfo(vehicleinfoxmlstring, out jsvehicleinfo, out vehicleinfo, out waitmodel);
                ack += getJsCheckLimit(limitxmlstring, out checklimit);
            }
            return ack;
        }
        public string getWaitlistInfo(out List<CARATWAIT> waitlist, out bool status, out string errMsg)
        {
            string ack = "";
            waitlist = new List<CARATWAIT>();
            status = false;
            errMsg = "";
            string xmlstring = "";
            /*32位系统注释*/
            //lineclient.GetCheckList(out xmlstring, out status, out errMsg);
            if (status)
            {
                ini.INIIO.saveLogInf("getWaitlistInfo:\r\nstatus:" + status + "\r\nerrMsg:" + errMsg);
                ini.INIIO.saveLogInf("xmlstring:\r\nXml:" + xmlstring);
                ack += getJsCheckList(xmlstring, out waitlist);
            }
            return ack;
        }
        public string beginDemarcate(out JsDemarcateLimit demarcatelimit, out bool status, out string errMsg)
        {
            string ack = "";
            demarcatelimit = new JsDemarcateLimit();
            status = false;
            errMsg = "";
            string xmlstring = "";
            string stationId, lineId;
            /*32位系统注释*/
            //lineclient.BeginDemarcate(out stationId, out lineId, out xmlstring, out status, out errMsg);
            if (status)
            {
                ini.INIIO.saveLogInf("beginDemarcate:\r\nstatus:" + status + "\r\nerrMsg:" + errMsg);
                ini.INIIO.saveLogInf("xmlstring:\r\nXml:" + xmlstring);
                ack += getJsDemarcateLimit(xmlstring, out demarcatelimit);
            }
            return ack;
        }
        public string uploadDemarcateResult(JsUploadInspectionResult model, out bool status, out string errMsg)
        {
            string ack = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "DEMARCATE_RESULT", "");
            //setXmlElementAttribute(xmlelem, "Action", "CheckVehicle");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("DEMARCATE_RESULT");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("DEMARCATE_RESULT_CONTENT");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "COSet", model.COSet);
            setXmlElementAttribute(xe1, "HCSet", model.HCSet);
            setXmlElementAttribute(xe1, "NOSet", model.NOSet);
            setXmlElementAttribute(xe1, "CO2Set", model.CO2Set);
            setXmlElementAttribute(xe1, "O2Set", model.O2Set);
            setXmlElementAttribute(xe1, "COChk", model.COChk);
            setXmlElementAttribute(xe1, "HCChk", model.HCChk);
            setXmlElementAttribute(xe1, "NOChk", model.NOChk);
            setXmlElementAttribute(xe1, "CO2Chk", model.CO2Chk);
            setXmlElementAttribute(xe1, "O2Chk", model.O2Chk);
            setXmlElementAttribute(xe1, "ChkReslut", model.ChkReslut);
            setXmlElementAttribute(xe1, "COCal", model.COCal);
            setXmlElementAttribute(xe1, "HCCal", model.HCCal);
            setXmlElementAttribute(xe1, "NOCal", model.NOCal);
            setXmlElementAttribute(xe1, "CO2Cal", model.CO2Cal);
            setXmlElementAttribute(xe1, "O2Cal", model.O2Cal);
            setXmlElementAttribute(xe1, "CalReslut", model.CalReslut);
            setXmlElementAttribute(xe1, "SmokeSet", model.SmokeSet);
            setXmlElementAttribute(xe1, "SmokeCal", model.SmokeCal);
            setXmlElementAttribute(xe1, "SmokeResult", model.SmokeResult);
            setXmlElementAttribute(xe1, "TemperatureSet", model.TemperatureSet);
            setXmlElementAttribute(xe1, "TemperatureReal", model.TemperatureReal);
            setXmlElementAttribute(xe1, "TemperatureResult", model.TemperatureResult);
            setXmlElementAttribute(xe1, "HumiditySet", model.HumiditySet);
            setXmlElementAttribute(xe1, "HumidityReal", model.HumidityReal);
            setXmlElementAttribute(xe1, "HumidityResult", model.HumidityResult);
            setXmlElementAttribute(xe1, "AirPressureSet", model.AirPressureSet);
            setXmlElementAttribute(xe1, "AirPressureReal", model.AirPressureReal);
            setXmlElementAttribute(xe1, "AirPressureResult", model.AirPressureResult);
            setXmlElementAttribute(xe1, "Coastdown64SetTime", model.Coastdown64SetTime);
            setXmlElementAttribute(xe1, "Coastdown64RealTime", model.Coastdown64RealTime);
            setXmlElementAttribute(xe1, "Coastdown64Result", model.Coastdown64Result);
            setXmlElementAttribute(xe1, "Coastdown48SetTime", model.Coastdown48SetTime);
            setXmlElementAttribute(xe1, "Coastdown48RealTime ", model.Coastdown48RealTime);
            setXmlElementAttribute(xe1, "Coastdown48Result ", model.Coastdown48Result);
            setXmlElementAttribute(xe1, "ParasiticLossHiSpeed", model.ParasiticLossHiSpeed);
            setXmlElementAttribute(xe1, "ParasiticLossLowSpeed", model.ParasiticLossLowSpeed);
            setXmlElementAttribute(xe1, "ParasiticLossLowTime", model.ParasiticLossLowTime);
            setXmlElementAttribute(xe1, "Inertia", model.Inertia);
            setXmlElementAttribute(xe1, "ParasiticPower", model.ParasiticPower);
            root.AppendChild(xe1);
            status = true;errMsg = "";
            /*32位系统注释*/
            //lineclient.UploadDemarcateResult(ConvertXmlToString(xmldoc), out status, out errMsg);
            return "";
        }
        public string beginInspection(string inspType, out string stationId, out string lineId, out string inspectionId, out bool status, out string errMsg)
        {
            string ack = "";
            stationId = "";
            lineId = "";
            inspectionId = "";
            status = true; errMsg = "";
            /*32位系统注释*/
            //lineclient.BeginInspection(inspType, out stationId, out lineId, out inspectionId, out status, out errMsg);
            ini.INIIO.saveLogInf("BeginInspection:\r\nstatus:" + status + "\r\nerrMsg:" + errMsg);
            ini.INIIO.saveLogInf("BeginInspection:\r\ninspType:" + inspType + "\r\nstationId:" + stationId + "\r\nlineId:" + lineId);
            return "";
        }
        public string stopInspection(out bool status, out string errMsg)
        {
            string ack = "";
            status = true; errMsg = "";
            /*32位系统注释*/
            //lineclient.StopInspection(out status, out errMsg);
            ini.INIIO.saveLogInf("StopInspection:\r\nstatus:" + status + "\r\nerrMsg:" + errMsg);
            return "";
        }
        public string uploadInspectionResult(JsAsmResultData inspectionResult, DataTable asmdataseconds, out string finalResult, out bool status, out bool cardWriteStatus, out string errMsg)
        {
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "asm_result", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("asm_result");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("result_data");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("check_id");
                xe101.InnerText = inspectionResult.check_id;
                XmlElement xe102 = xmldoc.CreateElement("check_type");
                xe102.InnerText = inspectionResult.check_type;
                XmlElement xe103 = xmldoc.CreateElement("citycode");
                xe103.InnerText = inspectionResult.citycode;
                XmlElement xe104 = xmldoc.CreateElement("unit_id");
                xe104.InnerText = inspectionResult.unit_id;
                XmlElement xe105 = xmldoc.CreateElement("device_id");
                xe105.InnerText = inspectionResult.device_id;
                XmlElement xe106 = xmldoc.CreateElement("vehicleid");
                xe106.InnerText = inspectionResult.vhicleid;
                XmlElement xe107 = xmldoc.CreateElement("odo_meter");
                xe107.InnerText = inspectionResult.odo_meter;
                XmlElement xe108 = xmldoc.CreateElement("check_date");
                xe108.InnerText = inspectionResult.check_data;
                XmlElement xe109 = xmldoc.CreateElement("start_time");
                xe109.InnerText = inspectionResult.starttime;
                XmlElement xe110 = xmldoc.CreateElement("end_time");
                xe110.InnerText = inspectionResult.end_time;
                XmlElement xe111 = xmldoc.CreateElement("temperature");
                xe111.InnerText = inspectionResult.temperature;
                XmlElement xe112 = xmldoc.CreateElement("pressure");
                xe112.InnerText = inspectionResult.pressure;
                XmlElement xe113 = xmldoc.CreateElement("humidity");
                xe113.InnerText = inspectionResult.humidity;
                XmlElement xe114 = xmldoc.CreateElement("kh_retouch");
                xe114.InnerText = inspectionResult.kh_retouch;
                XmlElement xe115 = xmldoc.CreateElement("dcf_retouch_25");
                xe115.InnerText = inspectionResult.dcf_retouch_25;
                XmlElement xe116 = xmldoc.CreateElement("dcf_retouch_40");
                xe116.InnerText = inspectionResult.dcf_retouch_40;
                XmlElement xe117 = xmldoc.CreateElement("co_5025");
                xe117.InnerText = inspectionResult.co_5025;
                XmlElement xe118 = xmldoc.CreateElement("co_5025_limit");
                xe118.InnerText = inspectionResult.co_5025_limit;
                XmlElement xe119 = xmldoc.CreateElement("co_5025_result");
                xe119.InnerText = inspectionResult.co_5025_result;
                XmlElement xe120 = xmldoc.CreateElement("hc_5025");
                xe120.InnerText = inspectionResult.hc_5025;
                XmlElement xe121 = xmldoc.CreateElement("hc_5025_limit");
                xe121.InnerText = inspectionResult.hc_5025_limit;
                XmlElement xe122 = xmldoc.CreateElement("hc_5025_result");
                xe122.InnerText = inspectionResult.hc_5025_result;
                XmlElement xe123 = xmldoc.CreateElement("no_5025");
                xe123.InnerText = inspectionResult.no_5025;
                XmlElement xe124 = xmldoc.CreateElement("no_5025_limit");
                xe124.InnerText = inspectionResult.no_5025_limit;
                XmlElement xe125 = xmldoc.CreateElement("no_5025_result");
                xe125.InnerText = inspectionResult.no_5025_result;
                XmlElement xe126 = xmldoc.CreateElement("power_5025");
                xe126.InnerText = inspectionResult.power_5025;
                XmlElement xe127 = xmldoc.CreateElement("rev_5025");
                xe127.InnerText = inspectionResult.rev_5025;
                XmlElement xe128 = xmldoc.CreateElement("lambda_5025");
                xe128.InnerText = inspectionResult.lambda_5025;
                XmlElement xe129 = xmldoc.CreateElement("co_2540");
                xe129.InnerText = inspectionResult.co_2540;
                XmlElement xe130 = xmldoc.CreateElement("co_2540_limit");
                xe130.InnerText = inspectionResult.co_2540_limit;
                XmlElement xe131 = xmldoc.CreateElement("co_2540_result");
                xe131.InnerText = inspectionResult.co_2540_result;
                XmlElement xe132 = xmldoc.CreateElement("hc_2540");
                xe132.InnerText = inspectionResult.hc_2540;
                XmlElement xe133 = xmldoc.CreateElement("hc_2540_limit");
                xe133.InnerText = inspectionResult.hc_2540_limit;
                XmlElement xe134 = xmldoc.CreateElement("hc_2540_result");
                xe134.InnerText = inspectionResult.hc_2540_result;
                XmlElement xe135 = xmldoc.CreateElement("no_2540");
                xe135.InnerText = inspectionResult.no_2540;
                XmlElement xe136 = xmldoc.CreateElement("no_2540_limit");
                xe136.InnerText = inspectionResult.no_2540_limit;
                XmlElement xe137 = xmldoc.CreateElement("no_2540_result");
                xe137.InnerText = inspectionResult.no_2540_result;
                XmlElement xe138 = xmldoc.CreateElement("power_2540");
                xe138.InnerText = inspectionResult.power_2540;
                XmlElement xe139 = xmldoc.CreateElement("rev_2540");
                xe139.InnerText = inspectionResult.rev_2540;
                XmlElement xe140 = xmldoc.CreateElement("lambda_2540");
                xe140.InnerText = inspectionResult.lambda_2540;
                XmlElement xe141 = xmldoc.CreateElement("passed");
                xe141.InnerText = inspectionResult.passed;
                xe1.AppendChild(xe101);
                xe1.AppendChild(xe102);
                xe1.AppendChild(xe103);
                xe1.AppendChild(xe104);
                xe1.AppendChild(xe105);
                xe1.AppendChild(xe106);
                xe1.AppendChild(xe107);
                xe1.AppendChild(xe108);
                xe1.AppendChild(xe109);
                xe1.AppendChild(xe110);
                xe1.AppendChild(xe111);
                xe1.AppendChild(xe112);
                xe1.AppendChild(xe113);
                xe1.AppendChild(xe114);
                xe1.AppendChild(xe115);
                xe1.AppendChild(xe116);
                xe1.AppendChild(xe117);
                xe1.AppendChild(xe118);
                xe1.AppendChild(xe119);
                xe1.AppendChild(xe120);
                xe1.AppendChild(xe121);
                xe1.AppendChild(xe122);
                xe1.AppendChild(xe123);
                xe1.AppendChild(xe124);
                xe1.AppendChild(xe125);
                xe1.AppendChild(xe126);
                xe1.AppendChild(xe127);
                xe1.AppendChild(xe128);
                xe1.AppendChild(xe129);
                xe1.AppendChild(xe130);
                xe1.AppendChild(xe131);
                xe1.AppendChild(xe132);
                xe1.AppendChild(xe133);
                xe1.AppendChild(xe134);
                xe1.AppendChild(xe135);
                xe1.AppendChild(xe136);
                xe1.AppendChild(xe137);
                xe1.AppendChild(xe138);
                xe1.AppendChild(xe139);
                xe1.AppendChild(xe140);
                xe1.AppendChild(xe141);
                root.AppendChild(xe1);
                if (asmdataseconds != null)
                {
                    for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                    {
                        XmlElement xe2 = xmldoc.CreateElement("process_data");//创建一个<Node>节点 
                        DataRow dr = asmdataseconds.Rows[i];
                        XmlElement xe201 = xmldoc.CreateElement("check_id");
                        xe201.InnerText = inspectionResult.check_id;
                        XmlElement xe202 = xmldoc.CreateElement("time_no");
                        xe202.InnerText = i.ToString();
                        XmlElement xe203 = xmldoc.CreateElement("vehicle_speed");
                        xe203.InnerText = dr["实时车速"].ToString();
                        XmlElement xe204 = xmldoc.CreateElement("rpm");
                        xe204.InnerText = dr["转速"].ToString();
                        XmlElement xe205 = xmldoc.CreateElement("torque");
                        xe205.InnerText = dr["加载功率"].ToString();
                        XmlElement xe206 = xmldoc.CreateElement("power");
                        xe206.InnerText = dr["加载功率"].ToString();
                        XmlElement xe207 = xmldoc.CreateElement("hc");
                        xe207.InnerText = dr["HC实时值"].ToString();
                        XmlElement xe208 = xmldoc.CreateElement("co");
                        xe208.InnerText = dr["CO实时值"].ToString();
                        XmlElement xe209 = xmldoc.CreateElement("no");
                        xe209.InnerText = dr["NO实时值"].ToString();
                        XmlElement xe210 = xmldoc.CreateElement("co2");
                        xe210.InnerText = dr["CO2实时值"].ToString();
                        XmlElement xe211 = xmldoc.CreateElement("o2");
                        xe211.InnerText = dr["O2实时值"].ToString();
                        xe2.AppendChild(xe201);
                        xe2.AppendChild(xe202);
                        xe2.AppendChild(xe203);
                        xe2.AppendChild(xe204);
                        xe2.AppendChild(xe205);
                        xe2.AppendChild(xe206);
                        xe2.AppendChild(xe207);
                        xe2.AppendChild(xe208);
                        xe2.AppendChild(xe209);
                        xe2.AppendChild(xe210);
                        xe2.AppendChild(xe211);
                        root.AppendChild(xe2);
                    }
                }
                string inspectionResultString = ConvertXmlToString(xmldoc);
                ini.INIIO.saveXmlInf(inspectionResultString, inspectionResult.vhicleid);
                string ack = "";
                finalResult = "";
                cardWriteStatus = false;
                status = true; errMsg = "";
                /*32位系统注释*/
                //lineclient.UploadInspectionResult(inspectionResultString, out finalResult, out status, out cardWriteStatus, out errMsg);
                ini.INIIO.saveLogInf("UploadInspectionResult:\r\nfinalResult:" + finalResult + "\r\nstatus" + status + "\r\ncardWriteStatus" + cardWriteStatus + "\r\nerrMsg:" + errMsg);
                return "";
            }
            catch (Exception er)
            {
                finalResult = "";
                status = false;
                cardWriteStatus = false;
                errMsg = "";
                return er.Message;
            }
        }
        public string uploadInspectionResult(JsSdsResultData inspectionResult, DataTable asmdataseconds, out string finalResult, out bool status, out bool cardWriteStatus, out string errMsg)
        {
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "idle_result", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("idle_result");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("result_data");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("check_id");
                xe101.InnerText = inspectionResult.check_id;
                XmlElement xe102 = xmldoc.CreateElement("check_type");
                xe102.InnerText = inspectionResult.check_type;
                XmlElement xe103 = xmldoc.CreateElement("citycode");
                xe103.InnerText = inspectionResult.citycode;
                XmlElement xe104 = xmldoc.CreateElement("unit_id");
                xe104.InnerText = inspectionResult.unit_id;
                XmlElement xe105 = xmldoc.CreateElement("device_id");
                xe105.InnerText = inspectionResult.device_id;
                XmlElement xe106 = xmldoc.CreateElement("vehicleid");
                xe106.InnerText = inspectionResult.vhicleid;
                XmlElement xe107 = xmldoc.CreateElement("odo_meter");
                xe107.InnerText = inspectionResult.odo_meter;
                XmlElement xe108 = xmldoc.CreateElement("check_date");
                xe108.InnerText = inspectionResult.check_data;
                XmlElement xe109 = xmldoc.CreateElement("start_time");
                xe109.InnerText = inspectionResult.starttime;
                XmlElement xe110 = xmldoc.CreateElement("end_time");
                xe110.InnerText = inspectionResult.end_time;
                XmlElement xe111 = xmldoc.CreateElement("temperature");
                xe111.InnerText = inspectionResult.temperature;
                XmlElement xe112 = xmldoc.CreateElement("airpressure");
                xe112.InnerText = inspectionResult.pressure;
                XmlElement xe113 = xmldoc.CreateElement("humidity");
                xe113.InnerText = inspectionResult.humidity;
                XmlElement xe114 = xmldoc.CreateElement("lambda");
                xe114.InnerText = inspectionResult.lambda;
                XmlElement xe115 = xmldoc.CreateElement("lambda_limit");
                xe115.InnerText = inspectionResult.lambda_limit;
                XmlElement xe116 = xmldoc.CreateElement("lambda_passed");
                xe116.InnerText = inspectionResult.lambda_passed;
                XmlElement xe117 = xmldoc.CreateElement("lowidle_co");
                xe117.InnerText = inspectionResult.lowidle_co;
                XmlElement xe118 = xmldoc.CreateElement("low_co_limit");
                xe118.InnerText = inspectionResult.low_co_limit;
                XmlElement xe119 = xmldoc.CreateElement("lowidle_hc");
                xe119.InnerText = inspectionResult.lowidle_hc;
                XmlElement xe120 = xmldoc.CreateElement("low_hc_limit");
                xe120.InnerText = inspectionResult.low_hc_limit;
                XmlElement xe121 = xmldoc.CreateElement("low_passed");
                xe121.InnerText = inspectionResult.low_passed;
                XmlElement xe122 = xmldoc.CreateElement("highidle_co");
                xe122.InnerText = inspectionResult.highidle_co;
                XmlElement xe123 = xmldoc.CreateElement("high_co_limit");
                xe123.InnerText = inspectionResult.high_co_limit;
                XmlElement xe124 = xmldoc.CreateElement("highidle_hc");
                xe124.InnerText = inspectionResult.highidle_hc;
                XmlElement xe125 = xmldoc.CreateElement("high_hc_limit");
                xe125.InnerText = inspectionResult.high_hc_limit;
                XmlElement xe126 = xmldoc.CreateElement("high_passed");
                xe126.InnerText = inspectionResult.high_passed;
                XmlElement xe127 = xmldoc.CreateElement("passed");
                xe127.InnerText = inspectionResult.passed;
                xe1.AppendChild(xe101);
                xe1.AppendChild(xe102);
                xe1.AppendChild(xe103);
                xe1.AppendChild(xe104);
                xe1.AppendChild(xe105);
                xe1.AppendChild(xe106);
                xe1.AppendChild(xe107);
                xe1.AppendChild(xe108);
                xe1.AppendChild(xe109);
                xe1.AppendChild(xe110);
                xe1.AppendChild(xe111);
                xe1.AppendChild(xe112);
                xe1.AppendChild(xe113);
                xe1.AppendChild(xe114);
                xe1.AppendChild(xe115);
                xe1.AppendChild(xe116);
                xe1.AppendChild(xe117);
                xe1.AppendChild(xe118);
                xe1.AppendChild(xe119);
                xe1.AppendChild(xe120);
                xe1.AppendChild(xe121);
                xe1.AppendChild(xe122);
                xe1.AppendChild(xe123);
                xe1.AppendChild(xe124);
                xe1.AppendChild(xe125);
                xe1.AppendChild(xe126);
                xe1.AppendChild(xe127);
                root.AppendChild(xe1);
                if (asmdataseconds != null)
                {
                    int cysxcount = 1;
                    for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                    {
                        DataRow dr = asmdataseconds.Rows[i];
                        if (dr["时序类别"].ToString() != "0")
                        {
                            string sxnb = "1";
                            if (dr["时序类别"].ToString() == "1" || dr["时序类别"].ToString() == "2")
                                sxnb = "1";
                            else
                                sxnb = "0";
                            XmlElement xe2 = xmldoc.CreateElement("process_data");//创建一个<Node>节点 
                            XmlElement xe201 = xmldoc.CreateElement("check_id");
                            xe201.InnerText = inspectionResult.check_id;
                            XmlElement xe202 = xmldoc.CreateElement("time_no");
                            xe202.InnerText = (cysxcount++).ToString();
                            XmlElement xe203 = xmldoc.CreateElement("is_high_idel");
                            xe203.InnerText = sxnb;
                            XmlElement xe204 = xmldoc.CreateElement("hc");
                            xe204.InnerText = dr["HC"].ToString();
                            XmlElement xe205 = xmldoc.CreateElement("co");
                            xe205.InnerText = dr["CO"].ToString();
                            xe2.AppendChild(xe201);
                            xe2.AppendChild(xe202);
                            xe2.AppendChild(xe203);
                            xe2.AppendChild(xe204);
                            xe2.AppendChild(xe205);
                            root.AppendChild(xe2);
                        }
                    }
                }
                string inspectionResultString = ConvertXmlToString(xmldoc);
                ini.INIIO.saveXmlInf(inspectionResultString, inspectionResult.vhicleid);
                string ack = "";
                status = true; errMsg = "";
                finalResult = "";
                cardWriteStatus = false;
                /*32位系统注释*/
                //lineclient.UploadInspectionResult(inspectionResultString, out finalResult, out status, out cardWriteStatus, out errMsg);
                ini.INIIO.saveLogInf("UploadInspectionResult:\r\nfinalResult:" + finalResult + "\r\nstatus" + status + "\r\ncardWriteStatus" + cardWriteStatus + "\r\nerrMsg:" + errMsg);
                return "";
            }
            catch (Exception er)
            {
                finalResult = "";
                status = false;
                cardWriteStatus = false;
                errMsg = "";
                return er.Message;
            }
        }
        public string uploadInspectionResult(JsBtgResultData inspectionResult, out string finalResult, out bool status, out bool cardWriteStatus, out string errMsg)
        {
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "smoke_opacity_result", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("smoke_opacity_result");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("result_data");//创建一个<Node>节点 
                XmlElement xe101 = xmldoc.CreateElement("check_id");
                xe101.InnerText = inspectionResult.check_id;
                XmlElement xe102 = xmldoc.CreateElement("check_type");
                xe102.InnerText = inspectionResult.check_type;
                XmlElement xe103 = xmldoc.CreateElement("citycode");
                xe103.InnerText = inspectionResult.citycode;
                XmlElement xe104 = xmldoc.CreateElement("unit_id");
                xe104.InnerText = inspectionResult.unit_id;
                XmlElement xe105 = xmldoc.CreateElement("device_id");
                xe105.InnerText = inspectionResult.device_id;
                XmlElement xe106 = xmldoc.CreateElement("vehicleid");
                xe106.InnerText = inspectionResult.vhicleid;
                XmlElement xe107 = xmldoc.CreateElement("odo_meter");
                xe107.InnerText = inspectionResult.odo_meter;
                XmlElement xe108 = xmldoc.CreateElement("check_date");
                xe108.InnerText = inspectionResult.check_data;
                XmlElement xe109 = xmldoc.CreateElement("start_time");
                xe109.InnerText = inspectionResult.starttime;
                XmlElement xe110 = xmldoc.CreateElement("end_time");
                xe110.InnerText = inspectionResult.end_time;
                XmlElement xe111 = xmldoc.CreateElement("temperature");
                xe111.InnerText = inspectionResult.temperature;
                XmlElement xe112 = xmldoc.CreateElement("airpressure");
                xe112.InnerText = inspectionResult.pressure;
                XmlElement xe113 = xmldoc.CreateElement("humidity");
                xe113.InnerText = inspectionResult.humidity;
                XmlElement xe114 = xmldoc.CreateElement("idle_rev");
                xe114.InnerText = inspectionResult.idle_rev;
                XmlElement xe115 = xmldoc.CreateElement("smoke_b1");
                xe115.InnerText = inspectionResult.smoke_b1;
                XmlElement xe116 = xmldoc.CreateElement("smoke_b2");
                xe116.InnerText = inspectionResult.smoke_b2;
                XmlElement xe117 = xmldoc.CreateElement("smoke_b3");
                xe117.InnerText = inspectionResult.smoke_b3;
                XmlElement xe118 = xmldoc.CreateElement("smoke_avg");
                xe118.InnerText = inspectionResult.smoke_avg;
                XmlElement xe119 = xmldoc.CreateElement("smoke_limit");
                xe119.InnerText = inspectionResult.smoke_limit;
                XmlElement xe120 = xmldoc.CreateElement("passed");
                xe120.InnerText = inspectionResult.passed;
                xe1.AppendChild(xe101);
                xe1.AppendChild(xe102);
                xe1.AppendChild(xe103);
                xe1.AppendChild(xe104);
                xe1.AppendChild(xe105);
                xe1.AppendChild(xe106);
                xe1.AppendChild(xe107);
                xe1.AppendChild(xe108);
                xe1.AppendChild(xe109);
                xe1.AppendChild(xe110);
                xe1.AppendChild(xe111);
                xe1.AppendChild(xe112);
                xe1.AppendChild(xe113);
                xe1.AppendChild(xe114);
                xe1.AppendChild(xe115);
                xe1.AppendChild(xe116);
                xe1.AppendChild(xe117);
                xe1.AppendChild(xe118);
                xe1.AppendChild(xe119);
                xe1.AppendChild(xe120);
                root.AppendChild(xe1);
                string inspectionResultString = ConvertXmlToString(xmldoc);
                ini.INIIO.saveXmlInf(inspectionResultString, inspectionResult.vhicleid);
                string ack = "";
                status = true; errMsg = "";
                finalResult = "";
                cardWriteStatus = false;
                /*32位系统注释*/
                //lineclient.UploadInspectionResult(inspectionResultString, out finalResult, out status, out cardWriteStatus, out errMsg);
                ini.INIIO.saveLogInf("UploadInspectionResult:\r\nfinalResult:" + finalResult + "\r\nstatus" + status + "\r\ncardWriteStatus" + cardWriteStatus + "\r\nerrMsg:" + errMsg);
                return "";
            }
            catch (Exception er)
            {
                finalResult = "";
                status = false;
                cardWriteStatus = false;
                errMsg = "";
                return er.Message;
            }
        }
        public string uploadInspectionResult(string inspectionResult, out string finalResult, out bool status, out bool cardWriteStatus, out string errMsg)
        {
            try
            {
                string ack = "";
                status = true; errMsg = "";
                finalResult = "";
                cardWriteStatus = false;
                /*32位系统注释*/
                //lineclient.UploadInspectionResult(inspectionResult, out finalResult, out status, out cardWriteStatus, out errMsg);
                return "";
            }
            catch (Exception er)
            {
                finalResult = "";
                status = false;
                cardWriteStatus = false;
                errMsg = "";
                return er.Message;
            }
        }

        string getDictionary(string xmlstring)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);
                DataTable dt = ds.Tables["content"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["dic_code"].ToString() == "STANDARD_ID2")
                    {
                        if (!STANDARD_ID2.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            STANDARD_ID2.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "USER_TYPE")
                    {
                        if (!USER_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            USER_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "USER_SEX")
                    {
                        if (!USER_SEX.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            USER_SEX.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CITYCODE_PROVINCE")
                    {
                        if (!CITYCODE_PROVINCE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CITYCODE_PROVINCE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CITYCODE_PLATE")
                    {
                        if (!CITYCODE_PLATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CITYCODE_PLATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_PRINT")
                    {
                        if (!IS_PRINT.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_PRINT.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "RE_SIGN_REASON")
                    {
                        if (!RE_SIGN_REASON.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            RE_SIGN_REASON.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CANCEL_REASON")
                    {
                        if (!CANCEL_REASON.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CANCEL_REASON.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CARD_STATE")
                    {
                        if (!CARD_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CARD_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "COLOR")
                    {
                        if (!COLOR.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            COLOR.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VIOLATION")
                    {
                        if (!VIOLATION.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VIOLATION.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "PICMARK")
                    {
                        if (!PICMARK.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            PICMARK.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_UPLOAD")
                    {
                        if (!IS_UPLOAD.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_UPLOAD.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "OPERRATIONAL_STATE")
                    {
                        if (!OPERRATIONAL_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            OPERRATIONAL_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CLLB")
                    {
                        if (!CLLB.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CLLB.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "PLATE_TYPE")
                    {
                        if (!PLATE_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            PLATE_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "GOVEMANCE_STATE")
                    {
                        if (!GOVEMANCE_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            GOVEMANCE_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "SIGN_ISSUE_TYPE")
                    {
                        if (!SIGN_ISSUE_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            SIGN_ISSUE_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "STANDARD_ID")
                    {
                        if (!STANDARD_ID.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            STANDARD_ID.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "INSPECTION_TYPE")
                    {
                        if (!INSPECTION_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            INSPECTION_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VEHICLE_BODY_COLOR")
                    {
                        if (!VEHICLE_BODY_COLOR.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VEHICLE_BODY_COLOR.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "EQUIP_TYPE")
                    {
                        if (!EQUIP_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            EQUIP_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_CHECK")
                    {
                        if (!IS_CHECK.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_CHECK.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VIOLATE_REASON")
                    {
                        if (!VIOLATE_REASON.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VIOLATE_REASON.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "DRIVE_MODE")
                    {
                        if (!DRIVE_MODE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            DRIVE_MODE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CITYCODE_LOCAL")
                    {
                        if (!CITYCODE_LOCAL.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CITYCODE_LOCAL.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_REBUILD")
                    {
                        if (!IS_REBUILD.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_REBUILD.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "PLATE_COLOR")
                    {
                        if (!PLATE_COLOR.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            PLATE_COLOR.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VEHICLE_KIND")
                    {
                        if (!VEHICLE_KIND.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VEHICLE_KIND.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "DRIVE_FORM")
                    {
                        if (!DRIVE_FORM.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            DRIVE_FORM.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }


                    if (dt.Rows[i]["dic_code"].ToString() == "FUEL_TYPE")
                    {
                        if (!FUEL_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            FUEL_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "ADMISSION")
                    {
                        if (!ADMISSION.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            ADMISSION.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "SUPPLY_MODE")
                    {
                        if (!SUPPLY_MODE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            SUPPLY_MODE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_ELECTRONIC_CTRL")
                    {
                        if (!IS_ELECTRONIC_CTRL.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_ELECTRONIC_CTRL.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VEHICLE_STATE")
                    {
                        if (!VEHICLE_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VEHICLE_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VEHICLE_STYLE")
                    {
                        if (!VEHICLE_STYLE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VEHICLE_STYLE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "SIGN_TYPE")
                    {
                        if (!SIGN_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            SIGN_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "DEVICETYPE")
                    {
                        if (!DEVICETYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            DEVICETYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "STATE")
                    {
                        if (!STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CHECK_PERIOD")
                    {
                        if (!CHECK_PERIOD.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CHECK_PERIOD.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CHECK_TYPE")
                    {
                        if (!CHECK_TYPE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CHECK_TYPE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "PASSED")
                    {
                        if (!PASSED.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            PASSED.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CITYCODE_MAIN")
                    {
                        if (!CITYCODE_MAIN.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CITYCODE_MAIN.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "VEHICLE_STATUS")
                    {
                        if (!VEHICLE_STATUS.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            VEHICLE_STATUS.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "DIRECTION")
                    {
                        if (!DIRECTION.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            DIRECTION.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "EDUCATIONAL")
                    {
                        if (!EDUCATIONAL.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            EDUCATIONAL.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "DUTY")
                    {
                        if (!DUTY.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            DUTY.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "SPECIALTY")
                    {
                        if (!SPECIALTY.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            SPECIALTY.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_DELETE")
                    {
                        if (!IS_DELETE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_DELETE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_CHECK_LOGIN")
                    {
                        if (!IS_CHECK_LOGIN.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_CHECK_LOGIN.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_CANCEL")
                    {
                        if (!IS_CANCEL.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_CANCEL.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "SIGN_REASON")
                    {
                        if (!SIGN_REASON.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            SIGN_REASON.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "IS_SERVICE_CAR")
                    {
                        if (!IS_SERVICE_CAR.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            IS_SERVICE_CAR.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "APPROVAL_STATE")
                    {
                        if (!APPROVAL_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            APPROVAL_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "CARD_IS_UPLOAD")
                    {
                        if (!CARD_IS_UPLOAD.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            CARD_IS_UPLOAD.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                    if (dt.Rows[i]["dic_code"].ToString() == "APPLY_STATE")
                    {
                        if (!APPLY_STATE.ContainsKey(dt.Rows[i]["code_value"].ToString()) && dt.Rows[i]["code_value"].ToString() != "")
                        {
                            APPLY_STATE.Add(dt.Rows[i]["code_value"].ToString(), dt.Rows[i]["value_content"].ToString());
                        }
                    }
                }
                HAS_PURGE.Add("0", "否");
                HAS_PURGE.Add("1", "是");
                return "";
            }
            catch (Exception er)
            {
                return er.Message;
            }
        }
        string getJsCheckList(string xmlstring, out List<CARATWAIT> waitlist)
        {
            waitlist = new List<CARATWAIT>();
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);

                DataTable vehicletable = ds.Tables["check_list_content"];
                for (int i = 0; i < vehicletable.Rows.Count; i++)
                {
                    CARATWAIT waitmodel = new CARATWAIT();
                    /*JsVehicleInfo jsmodel = new JsVehicleInfo();
                    waitmodel.CLHP = vehicletable.Rows[i]["plate"].ToString();
                    waitmodel.CPYS = vehicletable.Rows[i]["plate_color"].ToString();
                    CARINF carinfo = new CARINF();
                    JsCheckLimit limitmodel = new JsCheckLimit();
                    bool status;
                    string errMsg;
                    string ackstring = getveicleInfo(waitmodel.CLHP, waitmodel.CPYS,out jsmodel, out carinfo, out waitmodel, out limitmodel, out status, out errMsg);
                    if(ackstring!="")
                    {
                        continue;
                    }
                    if(status)                    
                        waitlist.Add(waitmodel);*/
                    waitmodel.CLID = i.ToString();
                    waitmodel.CLHP = vehicletable.Rows[i]["plate"].ToString();
                    waitmodel.DLSJ = DateTime.Now;
                    waitmodel.CPYS = vehicletable.Rows[i]["plate_color"].ToString();
                    waitmodel.JCFF = "";
                    waitmodel.XSLC = "";
                    waitmodel.JCCS = "";
                    waitmodel.CZY = "";
                    waitmodel.JSY = "";
                    waitmodel.DLY = "";
                    waitmodel.TEST = "";
                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                    waitmodel.JCBGBH = "";
                    waitmodel.JCGWH = "";
                    waitmodel.JCZBH = "";
                    waitmodel.JCRQ = DateTime.Now;
                    waitmodel.BGJCFFYY = "";
                    waitmodel.SFCS = "";
                    waitmodel.ECRYPT = "";
                    waitmodel.SFCJ = "";
                    waitmodel.JYLSH = "";
                    waitmodel.HPZL = "";
                    waitlist.Add(waitmodel);
                }
                return "";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
        string getJsVehicleInfo(string xmlstring, out JsVehicleInfo jsvehicleinfo, out CARINF model, out CARATWAIT waitmodel)
        {
            model = new CARINF();
            jsvehicleinfo = new JsVehicleInfo();
            waitmodel = new CARATWAIT();
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);

                DataTable vehicletable = ds.Tables["vehicle_info_content"];
                int i = 0;
                jsvehicleinfo.vehicleid = vehicletable.Rows[i]["vehicleid"].ToString();
                jsvehicleinfo.citycode = vehicletable.Rows[i]["citycode"].ToString();
                jsvehicleinfo.plate = vehicletable.Rows[i]["plate"].ToString();
                jsvehicleinfo.plate_color = vehicletable.Rows[i]["plate_color"].ToString();
                jsvehicleinfo.plate_type = vehicletable.Rows[i]["plate_type"].ToString();
                jsvehicleinfo.vin = vehicletable.Rows[i]["vin"].ToString();
                jsvehicleinfo.manufacture_date = DateTime.Parse(vehicletable.Rows[i]["manufacture_date"].ToString());
                jsvehicleinfo.factory_name = vehicletable.Rows[i]["factory_name"].ToString();
                jsvehicleinfo.clsb = vehicletable.Rows[i]["clsb"].ToString();
                jsvehicleinfo.clxh = vehicletable.Rows[i]["clxh"].ToString();
                jsvehicleinfo.fdjxh = vehicletable.Rows[i]["fdjxh"].ToString();
                jsvehicleinfo.engine_no = vehicletable.Rows[i]["engine_no"].ToString();
                jsvehicleinfo.register_date = DateTime.Parse(vehicletable.Rows[i]["register_date"].ToString());
                jsvehicleinfo.check_period = vehicletable.Rows[i]["check_period"].ToString();
                jsvehicleinfo.vehicle_kind = vehicletable.Rows[i]["vehicle_kind"].ToString();
                jsvehicleinfo.vehicle_style = vehicletable.Rows[i]["vehicle_style"].ToString();
                jsvehicleinfo.is_service_car = vehicletable.Rows[i]["is_service_car"].ToString();
                jsvehicleinfo.vehicle_state = vehicletable.Rows[i]["vehicle_state"].ToString();
                jsvehicleinfo.vehicle_status = vehicletable.Rows[i]["vehicle_status"].ToString();
                jsvehicleinfo.standard_id = vehicletable.Rows[i]["standard_id"].ToString();
                jsvehicleinfo.inspection_type = vehicletable.Rows[i]["inspection_type"].ToString();
                jsvehicleinfo.odo_meter = vehicletable.Rows[i]["odo_meter"].ToString();
                jsvehicleinfo.maxweight = vehicletable.Rows[i]["maxweight"].ToString();
                jsvehicleinfo.stdweight = vehicletable.Rows[i]["stdweight"].ToString();
                jsvehicleinfo.drive_form = vehicletable.Rows[i]["drive_form"].ToString();
                jsvehicleinfo.drive_mode = vehicletable.Rows[i]["drive_mode"].ToString();
                jsvehicleinfo.fuel_type = vehicletable.Rows[i]["fuel_type"].ToString();
                jsvehicleinfo.supply_mode = vehicletable.Rows[i]["supply_mode"].ToString();
                jsvehicleinfo.exhaust_quantity = vehicletable.Rows[i]["exhaust_quantity"].ToString();
                jsvehicleinfo.rating_power = vehicletable.Rows[i]["rating_power"].ToString();
                jsvehicleinfo.has_odb = vehicletable.Rows[i]["has_odb"].ToString();
                jsvehicleinfo.has_purge = vehicletable.Rows[i]["has_purge"].ToString();
                jsvehicleinfo.is_electronic_ctrl = vehicletable.Rows[i]["is_electronic_ctrl"].ToString();
                jsvehicleinfo.seat_capacity = vehicletable.Rows[i]["seat_capacity"].ToString();
                jsvehicleinfo.ordain_rev = vehicletable.Rows[i]["ordain_rev"].ToString();
                jsvehicleinfo.cylinder = vehicletable.Rows[i]["cylinder"].ToString();
                jsvehicleinfo.stroke = vehicletable.Rows[i]["stroke"].ToString();
                jsvehicleinfo.admission = vehicletable.Rows[i]["admission"].ToString();
                jsvehicleinfo.is_rebuild = vehicletable.Rows[i]["is_rebuild"].ToString();
                jsvehicleinfo.near_unit_id = vehicletable.Rows[i]["near_unit_id"].ToString();
                jsvehicleinfo.near_check_date = vehicletable.Rows[i]["near_check_date"].ToString();
                jsvehicleinfo.sign_type = vehicletable.Rows[i]["sign_type"].ToString();
                jsvehicleinfo.sign_state = vehicletable.Rows[i]["sign_state"].ToString();
                jsvehicleinfo.vehicle_card_id = vehicletable.Rows[i]["vehicle_card_id"].ToString();
                jsvehicleinfo.owner = vehicletable.Rows[i]["owner"].ToString();
                jsvehicleinfo.owneraddress = vehicletable.Rows[i]["owneraddress"].ToString();
                jsvehicleinfo.phone = vehicletable.Rows[i]["phone"].ToString();

                string clid = jsvehicleinfo.vehicleid + "T" + DateTime.Now.ToString("yyMMddHHmmss");
                model.CLHP = vehicletable.Rows[i]["plate"].ToString();
                model.HPZL = vehicletable.Rows[i]["plate_type"].ToString();
                model.CPYS = vehicletable.Rows[i]["plate_color"].ToString();
                model.CLLX = vehicletable.Rows[i]["vehicle_kind"].ToString();
                model.CZ = vehicletable.Rows[i]["owner"].ToString();
                model.SYXZ = vehicletable.Rows[i]["is_service_car"].ToString();
                model.PP = vehicletable.Rows[i]["clsb"].ToString();
                model.XH = vehicletable.Rows[i]["clxh"].ToString();
                model.CLSBM = vehicletable.Rows[i]["vin"].ToString();
                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                model.FDJHM = vehicletable.Rows[i]["engine_no"].ToString();

                model.FDJXH = vehicletable.Rows[i]["fdjxh"].ToString();
                model.SCQY = vehicletable.Rows[i]["factory_name"].ToString();
                model.HDZK = vehicletable.Rows[i]["seat_capacity"].ToString();

                model.JSSZK = "0";
                model.ZZL = vehicletable.Rows[i]["maxweight"].ToString();
                model.HDZZL = "0";
                model.ZBZL = (int.Parse(vehicletable.Rows[i]["stdweight"].ToString()) - 100).ToString();
                model.JZZL = vehicletable.Rows[i]["stdweight"].ToString();
                model.ZCRQ = DateTime.Parse(vehicletable.Rows[i]["register_date"].ToString());
                model.SCRQ = DateTime.Parse(vehicletable.Rows[i]["manufacture_date"].ToString());

                model.FDJPL = vehicletable.Rows[i]["exhaust_quantity"].ToString();
                model.RLZL = vehicletable.Rows[i]["fuel_type"].ToString();
                model.EDGL = vehicletable.Rows[i]["rating_power"].ToString();
                model.EDZS = vehicletable.Rows[i]["ordain_rev"].ToString();
                model.BSQXS = vehicletable.Rows[i]["drive_form"].ToString();
                model.DWS = "5";
                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                model.GYFS = vehicletable.Rows[i]["supply_mode"].ToString();
                model.DPFS = "";
                model.JQFS = vehicletable.Rows[i]["admission"].ToString();
                model.QGS = vehicletable.Rows[i]["cylinder"].ToString();

                model.QDXS = vehicletable.Rows[i]["drive_mode"].ToString();
                model.CHZZ = "";
                model.DLSP = "";
                model.SFSRL = "";
                model.JHZZ = vehicletable.Rows[i]["has_purge"].ToString();
                model.OBD = vehicletable.Rows[i]["has_odb"].ToString();
                model.DKGYYB = vehicletable.Rows[i]["is_electronic_ctrl"].ToString();
                model.LXDH = vehicletable.Rows[i]["phone"].ToString();
                model.CLZL = vehicletable.Rows[i]["vehicle_state"].ToString();
                model.CZDZ = vehicletable.Rows[i]["owneraddress"].ToString();

                model.JCFS = "";
                model.JCLB = "";
                model.SSXQ = vehicletable.Rows[i]["citycode"].ToString();
                model.FDJSCQY = "";
                model.QDLTQY = "";
                model.RYPH = "";
                model.SFWDZR = "";
                model.SFYQBF = "";
                model.ZXBZ = "";
                model.CSYS = "";


                waitmodel.CLID = clid;
                waitmodel.CLHP = vehicletable.Rows[i]["plate"].ToString();
                waitmodel.DLSJ = DateTime.Now;
                waitmodel.CPYS = vehicletable.Rows[i]["plate_color"].ToString();
               
                switch (INSPECTION_TYPE[vehicletable.Rows[i]["inspection_type"].ToString()])
                {
                    case "稳态工况法检测":
                        waitmodel.JCFF = "ASM";
                        break;
                    case "双怠速法检测":
                        waitmodel.JCFF = "SDS";
                        break;
                    case "不透光烟度法检测":
                        waitmodel.JCFF = "ZYJS";
                        break;
                    default: waitmodel.JCFF = ""; break;
                }
                waitmodel.XSLC = vehicletable.Rows[i]["odo_meter"].ToString();
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
                waitmodel.HPZL = vehicletable.Rows[i]["plate_type"].ToString();
                return "";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
        string getJsCheckLimit(string xmlstring, out JsCheckLimit model)
        {
            model = new JsCheckLimit();
            try
            {
                if (xmlstring != "")
                {
                    DataSet ds = new DataSet();
                    ds = XmlToData.CXmlToDataSet(xmlstring);

                    DataTable vehicletable = ds.Tables["check_limit_content"];
                    int i = 0;
                    model.AmbientCOUp = vehicletable.Rows[i]["AmbientCOUp"].ToString();
                    model.AmbientCO2Up = vehicletable.Rows[i]["AmbientCO2Up"].ToString();
                    model.AmbientHCUp = vehicletable.Rows[i]["AmbientHCUp"].ToString();
                    model.AmbientNOUp = vehicletable.Rows[i]["AmbientNOUp"].ToString();
                    model.BackgroundCOUp = vehicletable.Rows[i]["BackgroundCOUp"].ToString();
                    model.BackgroundCO2Up = vehicletable.Rows[i]["BackgroundCO2Up"].ToString();
                    model.BackgroundHCUp = vehicletable.Rows[i]["BackgroundHCUp"].ToString();
                    model.BackgroundNOUp = vehicletable.Rows[i]["BackgroundNOUp"].ToString();
                    model.ResidualHCUp = vehicletable.Rows[i]["ResidualHCUp"].ToString();
                    model.COAndCO2 = vehicletable.Rows[i]["COAndCO2"].ToString();

                    model.CO5025 = vehicletable.Rows[i]["CO5025"].ToString();
                    model.HC5025 = vehicletable.Rows[i]["HC5025"].ToString();
                    model.NO5025 = vehicletable.Rows[i]["NO5025"].ToString();
                    model.CO2540 = vehicletable.Rows[i]["CO2540"].ToString();
                    model.HC2540 = vehicletable.Rows[i]["HC2540"].ToString();
                    model.NO2540 = vehicletable.Rows[i]["NO2540"].ToString();
                    model.HighIdleCO = vehicletable.Rows[i]["HighIdleCO"].ToString();
                    model.HighIdleHC = vehicletable.Rows[i]["HighIdleHC"].ToString();
                    model.LowIdleCO = vehicletable.Rows[i]["LowIdleCO"].ToString();
                    model.LowIdleHC = vehicletable.Rows[i]["LowIdleHC"].ToString();
                    model.FASmokeK = vehicletable.Rows[i]["FASmokeK"].ToString();
                    model.FARev = vehicletable.Rows[i]["FARev"].ToString();
                }
                else
                {
                    model = null;
                }
                return "";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
        string getJsDemarcateLimit(string xmlstring, out JsDemarcateLimit model)
        {
            model = new JsDemarcateLimit();
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);

                DataTable vehicletable = ds.Tables["DEMARCATE_LIMIT_CONTENT"];
                int i = 0;
                model.COChkAbs = vehicletable.Rows[i]["COChkAbs"].ToString();
                model.HCChkAbs = vehicletable.Rows[i]["HCChkAbs"].ToString();
                model.NOChkAbs = vehicletable.Rows[i]["NOChkAbs"].ToString();
                model.CO2ChkAbs = vehicletable.Rows[i]["CO2ChkAbs"].ToString();
                model.O2ChkAbs = vehicletable.Rows[i]["O2ChkAbs"].ToString();
                model.COChkRel = vehicletable.Rows[i]["COChkRel"].ToString();
                model.HCChkRel = vehicletable.Rows[i]["HCChkRel"].ToString();
                model.NOChkRel = vehicletable.Rows[i]["NOChkRel"].ToString();
                model.CO2ChkRel = vehicletable.Rows[i]["CO2ChkRel"].ToString();
                model.O2ChkRel = vehicletable.Rows[i]["O2ChkRel"].ToString();

                model.COCalAbs = vehicletable.Rows[i]["COCalAbs"].ToString();
                model.HCCalAbs = vehicletable.Rows[i]["HCCalAbs"].ToString();
                model.NOCalAbs = vehicletable.Rows[i]["NOCalAbs"].ToString();
                model.CO2CalAbs = vehicletable.Rows[i]["CO2CalAbs"].ToString();
                model.O2CalAbs = vehicletable.Rows[i]["O2CalAbs"].ToString();
                model.COCalRel = vehicletable.Rows[i]["COCalRel"].ToString();
                model.HCCalRel = vehicletable.Rows[i]["HCCalRel"].ToString();
                model.NOCalRel = vehicletable.Rows[i]["NOCalRel"].ToString();
                model.CO2CalRel = vehicletable.Rows[i]["CO2CalRel"].ToString();
                model.O2CalRel = vehicletable.Rows[i]["O2CalRel"].ToString();
                model.HCT90 = vehicletable.Rows[i]["HCT90"].ToString();
                model.COT90 = vehicletable.Rows[i]["COT90"].ToString();

                model.NOT90 = vehicletable.Rows[i]["NOT90"].ToString();
                model.CO2T90 = vehicletable.Rows[i]["CO2T90"].ToString();
                model.O2T90 = vehicletable.Rows[i]["O2T90"].ToString();
                model.HCT10 = vehicletable.Rows[i]["HCT10"].ToString();
                model.COT10 = vehicletable.Rows[i]["COT10"].ToString();
                model.NOT10 = vehicletable.Rows[i]["NOT10"].ToString();
                model.CO2T10 = vehicletable.Rows[i]["CO2T10"].ToString();
                model.O2T10 = vehicletable.Rows[i]["O2T10"].ToString();
                model.Smoke = vehicletable.Rows[i]["Smoke"].ToString();
                model.Rev = vehicletable.Rows[i]["Rev"].ToString();
                model.Temperature = vehicletable.Rows[i]["Temperature"].ToString();
                model.Humidity = vehicletable.Rows[i]["Humidity"].ToString();
                model.AirPressure = vehicletable.Rows[i]["AirPressure"].ToString();
                model.Coastdown = vehicletable.Rows[i]["Coastdown"].ToString();
                model.Torque = vehicletable.Rows[i]["Torque"].ToString();
                model.Velocity = vehicletable.Rows[i]["Velocity"].ToString();
                model.ParasiticLoss = vehicletable.Rows[i]["ParasiticLoss"].ToString();
                return "";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }

        public static bool saveLogInf(string inf)
        {
            string filepath = ".\\log\\" + DateTime.Now.ToString("yyMMdd");
            string pathname = filepath + "\\" + DateTime.Now.ToString("HH") + "report.log";
            if (createDir(filepath))
            {
                StreamWriter log = new StreamWriter(pathname, true);
                log.WriteLine("time:" + System.DateTime.Now.ToLongTimeString() + " content:" + inf);
                log.Close();
            }
            return true;
        }

        #region 创建文件夹
        public static bool createDir(string strPath)
        {
            try
            {
                //strPath = @strPath.Trim().ToString();
                Directory.CreateDirectory(strPath);
                return true;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Write(exp.Message.ToString());
                return false;
            }
        }
        #endregion
        #region 于文件夹下创建子文件
        public static bool createFile(string strPath, string filename)
        {
            try
            {
                //strPath = @strPath.Trim().ToString();
                string newPath = Path.Combine(strPath, filename);
                if (!File.Exists(newPath))
                {
                    File.Create(newPath);
                }
                Directory.CreateDirectory(strPath);
                return true;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Write(exp.Message.ToString());
                return false;
            }
        }
        #endregion
        #region 删除文件夹下所有文件
        public static bool deleteDir(string strPath)
        {
            try
            {
                //strPath = @strPath.Trim().ToString();
                if (Directory.Exists(strPath))
                {
                    string[] strDirs = Directory.GetDirectories(strPath);
                    string[] strFiles = Directory.GetFiles(strPath);
                    foreach (string strFile in strFiles)
                    {
                        File.Delete(strFile);
                    }
                    foreach (string strdir in strDirs)
                    {
                        Directory.Delete(strdir, true);
                    }
                }
                return true;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Write(exp.Message.ToString());
                return false;
            }
        }
        #endregion
    }
    public static class DictionaryExtensionMethodClass
    {
        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false)
                dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrPeplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

        /// <summary>
        /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary>
        /// 向字典中批量添加键值对
        /// </summary>
        /// <param name="replaceExisted">如果已存在，是否替换</param>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }


    }
}
