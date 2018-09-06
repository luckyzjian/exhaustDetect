using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using ini;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace GxWebClient
{

    public class GxInterface
    {
        public Dictionary<string, string> GL_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> GLR_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> GL_vlpncolor = new Dictionary<string, string>();
        public Dictionary<string, string> GL_hpzl = new Dictionary<string, string>();
        public Dictionary<string, string> GL_vehiclebigtype = new Dictionary<string, string>();
        public Dictionary<string, string> GL_pg = new Dictionary<string, string>();
        public Dictionary<string, string> GL_vehicletype = new Dictionary<string, string>();
        public Dictionary<string, string> GL_variableform = new Dictionary<string, string>();
        public Dictionary<string, string> GL_ocha = new Dictionary<string, string>();
        public Dictionary<string, string> GL_useofauto = new Dictionary<string, string>();
        public Dictionary<string, string> GL_intakeway = new Dictionary<string, string>();
        public Dictionary<string, string> GL_fueltype = new Dictionary<string, string>();
        public Dictionary<string, string> GL_oilsupplyway = new Dictionary<string, string>();
        public Dictionary<string, string> GL_driveform = new Dictionary<string, string>();
        public Dictionary<string, string> GL_hascca = new Dictionary<string, string>();
        public Dictionary<string, string> GL_hasoxygensensor = new Dictionary<string, string>();
        public Dictionary<string, string> GL_hasobd = new Dictionary<string, string>();
        public Dictionary<string, string> GL_isdoublefuel = new Dictionary<string, string>();
        public Dictionary<string, string> GL_inspectionnature = new Dictionary<string, string>();
        //GxWebClient.GxServiceReference.HBServiceSoapClient service =null;
        HBService service = null;
        string xtlb, yhdh;
        string jmmm = "GLStation))$)#";//加密串
        public GxInterface(string url,string xtlb,string yhdh,string jmmm)
        {
            this.xtlb = xtlb;
            this.yhdh = yhdh;
            this.jmmm = jmmm;
            GL_inspectionnature.Add("01", "初检");
            GL_inspectionnature.Add("02", "复检");
            GL_inspectionnature.Add("03", "多检");

            GL_inspectionmethod.Add("A","SDS");
            GL_inspectionmethod.Add("B", "ASM");
            GL_inspectionmethod.Add("C", "VMAS");
            GL_inspectionmethod.Add("D", "瞬态");
            GL_inspectionmethod.Add("E", "LZ");
            GL_inspectionmethod.Add("F", "ZYJS");
            GL_inspectionmethod.Add("G", "JZJS");
            GL_inspectionmethod.Add("H", "怠速");
            GL_inspectionmethod.Add("I", "急加速");

            GLR_inspectionmethod.Add("SDS", "A");
            GLR_inspectionmethod.Add("ASM", "B");
            GLR_inspectionmethod.Add("VMAS", "C");
            GLR_inspectionmethod.Add("瞬态", "D");
            GLR_inspectionmethod.Add("LZ", "E");
            GLR_inspectionmethod.Add("ZYJS", "F");
            GLR_inspectionmethod.Add("JZJS", "G");
            GLR_inspectionmethod.Add("怠速", "H");
            GLR_inspectionmethod.Add("急加速", "I");

            GL_vlpncolor.Add("01", "蓝色");
            GL_vlpncolor.Add("02", "黄色");
            GL_vlpncolor.Add("03", "黑色");
            GL_vlpncolor.Add("04", "白色");
            GL_vlpncolor.Add("05", "无");


            GL_hpzl.Add("01", "大型汽车号牌");
            GL_hpzl.Add("02", "小型汽车号牌");
            GL_hpzl.Add("03", "使馆汽车号牌");
            GL_hpzl.Add("04", "领馆汽车号牌");
            GL_hpzl.Add("05", "境外汽车号牌");
            GL_hpzl.Add("06", "外籍汽车号牌");
            GL_hpzl.Add("07", "两、三轮摩托车号牌");
            GL_hpzl.Add("08", "轻便摩托车号牌");
            GL_hpzl.Add("09", "使馆摩托车号牌");
            GL_hpzl.Add("10", "领馆摩托车号牌");
            GL_hpzl.Add("11", "境外摩托车号牌");
            GL_hpzl.Add("12", "外籍摩托车号牌");
            GL_hpzl.Add("13", "农用运输车号牌");
            GL_hpzl.Add("14", "拖拉机号牌");
            GL_hpzl.Add("15", "挂车号牌");
            GL_hpzl.Add("16", "教练汽车号牌");
            GL_hpzl.Add("17", "教练摩托车号牌");
            GL_hpzl.Add("18", "试验汽车号牌");
            GL_hpzl.Add("19", "试验摩托车号牌");
            GL_hpzl.Add("20", "临时人境汽车号牌");
            GL_hpzl.Add("21", "临时人境摩托车号牌");
            GL_hpzl.Add("22", "临时行驶车号牌");
            GL_hpzl.Add("23", "警用汽车号牌");
            GL_hpzl.Add("24", "警用摩托号牌");
            GL_hpzl.Add("99", "其他号牌");

            GL_vehiclebigtype.Add("01", "汽车");
            GL_vehiclebigtype.Add("02", "摩托车");
            GL_vehiclebigtype.Add("03", "低速汽车");

            GL_pg.Add("01", "客车");
            GL_pg.Add("02", "货车");

            GL_vehicletype.Add("01", "微型");
            GL_vehicletype.Add("02", "小型(轻型)");
            GL_vehicletype.Add("03", "中型");
            GL_vehicletype.Add("04", "大型(重型)");
            GL_vehicletype.Add("05", "轻便型摩托车");
            GL_vehicletype.Add("06", "摩托车");
            GL_vehicletype.Add("07", "低速汽车");

            GL_variableform.Add("01", "手动");
            GL_variableform.Add("02", "自动");
            GL_variableform.Add("03", "手自一体");

            GL_ocha.Add("01", "运营");
            GL_ocha.Add("02", "非运营");

            GL_useofauto.Add("A", "非营运");
            GL_useofauto.Add("B", "公路客运");
            GL_useofauto.Add("C", "公交客运");
            GL_useofauto.Add("D", "出租客运");
            GL_useofauto.Add("E", "旅游客运");
            GL_useofauto.Add("F", "货运");
            GL_useofauto.Add("G", "租赁");
            GL_useofauto.Add("H", "警用");
            GL_useofauto.Add("I", "消防");
            GL_useofauto.Add("J", "救护");
            GL_useofauto.Add("K", "工程抢险");
            GL_useofauto.Add("L", "营转非");
            GL_useofauto.Add("M", "出租转非");
            GL_useofauto.Add("Z", "其他");

            GL_intakeway.Add("01", "自然吸气");
            GL_intakeway.Add("02", "涡轮增压");

            GL_fueltype.Add("A", "汽油");
            GL_fueltype.Add("B", "柴油");
            GL_fueltype.Add("C", "电");
            GL_fueltype.Add("D", "混合油");
            GL_fueltype.Add("E", "天然气");
            GL_fueltype.Add("F", "液化石油气");
            GL_fueltype.Add("L", "甲醇");
            GL_fueltype.Add("M", "乙醇");
            GL_fueltype.Add("N", "太阳能");
            GL_fueltype.Add("O", "混合动力");
            GL_fueltype.Add("Y", "无");
            GL_fueltype.Add("Z", "其他");
            GL_fueltype.Add("A1", "油改气");


            GL_oilsupplyway.Add("01", "化油器");
            GL_oilsupplyway.Add("02", "闭环电喷");
            GL_oilsupplyway.Add("03", "开环电喷");
            GL_oilsupplyway.Add("04", "直喷");
            GL_oilsupplyway.Add("05", "混合喷射");

            GL_driveform.Add("01", "前驱");
            GL_driveform.Add("02", "后驱");
            GL_driveform.Add("03", "四驱");

            GL_hascca.Add("1", "有");
            GL_hascca.Add("0", "没有");
            GL_hasoxygensensor.Add("1", "有");
            GL_hasoxygensensor.Add("0", "没有");
            GL_hasobd.Add("1", "有");
            GL_hasobd.Add("0", "没有");
            GL_isdoublefuel.Add("1", "有");
            GL_isdoublefuel.Add("0", "否");
            //string code,msg;
            //Sync("",out code,out msg);
            //service = new GxServiceReference.HBServiceSoapClient();
            service = new HBService(url);
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

            //newstring = newstring.Replace("\r\n", "");
            //newstring = Regex.Replace(newstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号            
            return newstring;
        }
        public bool Sync(string stationcode,out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("QueryCondition");
                XmlElement xe1 = xmldoc.CreateElement("stationcode");
                xe1.InnerText = stationcode;
                queryroot.AppendChild(xe1);
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行Sync】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm="";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm=ini.INIIO.md5low( mm+ jmmm,32);
                string revXml = service.QueryObject(xtlb, "ST101", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result =dt1.Rows[0]["code"].ToString();
                errMsg = ini.INIIO.decodeUTF8(dt1.Rows[0]["message"].ToString());
                INIIO.saveSocketLogInf("【result】"+result);
                INIIO.saveSocketLogInf("【errMsg】"+errMsg);
                if (result == "1")
                {
                    dt1 = ds.Tables["servertime"];
                    errMsg = dt1.Rows[0]["time"].ToString();
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool GetVehicleList(Hashtable ht,out DataTable dt, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            dt = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("QueryCondition");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);

                INIIO.saveSocketLogInf("【执行GetVehicleList】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.QueryObject(xtlb, "ST102", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    dt1 = ds.Tables["acceptancetype"];
                    dt = dt1;
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool GetVehicleInf(Hashtable ht, out DataTable dt, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            dt = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("QueryCondition");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行GetVehicleInf】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.QueryObject(xtlb, "ST103", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    dt1 = ds.Tables["vehicle"];
                    dt = dt1;
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool GetVehicleXz(Hashtable ht, out DataTable dt, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            dt = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("QueryCondition");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行GetVehicleXz】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.QueryObject(xtlb, "ST104", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg =dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    dt1 = ds.Tables["limit"];
                    dt = dt1;
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool GetPersonInf(Hashtable ht, out DataTable dt, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            dt = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("QueryCondition");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行GetPersonInf】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.QueryObject(xtlb, "ST105", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    dt1 = ds.Tables["stationstafftype"];
                    dt = dt1;
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool startTest(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("signal");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行startTest】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST201", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool finishTest(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("signal");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行finishTest】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST202", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool chaGuanFinish(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("signal");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行chaGuanFinish】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST701", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool startDataSample(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("signal");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行startDataSample】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST701", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool stopDataSample(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("signal");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行stopDataSample】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST702", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jcff">SDS ASM VMAS JZJS ZYJS LZ</param>
        /// <param name="lx">0-data 1-processdata</param>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool uploadTestData(string jcff,int lx, Hashtable ht,List<Hashtable> htpro, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                string rootname = "";
                string jkbs = "";
                if (lx == 0)
                {
                    switch (jcff)
                    {
                        case "SDS":
                            rootname = "tsidata"; jkbs = "ST203";
                            break;
                        case "ASM":
                            rootname = "asmdata"; jkbs = "ST205"; break;
                        case "JZJS":
                            rootname = "lddata"; jkbs = "ST207"; break;
                        case "ZYJS":
                            rootname = "lfdata"; jkbs = "ST209"; break;
                        case "LZ":
                            rootname = "fsdata"; jkbs = "ST211"; break;
                    }
                }
                else
                {
                    switch (jcff)
                    {
                        case "SDS":
                            rootname = "tsiprocdata"; jkbs = "ST204";
                            break;
                        case "ASM":
                            rootname = "asmprocdata"; jkbs = "ST206"; break;
                        case "JZJS":
                            rootname = "ldprocdata"; jkbs = "ST208"; break;
                        case "ZYJS":
                            rootname = "lfprocdata"; jkbs = "ST210"; break;
                        case "LZ":
                            rootname = "fsprocdata"; jkbs = "ST212"; break;
                    }
                }
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                if (lx == 0)
                {
                    XmlElement queryroot = xmldoc.CreateElement(rootname);
                    IDictionaryEnumerator et = ht.GetEnumerator();
                    while (et.MoveNext()) // 作哈希表循环
                    {
                        XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                        xe1.InnerText = (string)et.Value;
                        queryroot.AppendChild(xe1);
                    }
                    root.AppendChild(queryroot);
                }
                else
                {
                    for (int i = 0; i < htpro.Count; i++)
                    {
                        XmlElement queryroot = xmldoc.CreateElement(rootname);
                        IDictionaryEnumerator et = htpro[i].GetEnumerator();
                        while (et.MoveNext()) // 作哈希表循环
                        {
                            XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                            xe1.InnerText = (string)et.Value;
                            queryroot.AppendChild(xe1);
                        }
                        root.AppendChild(queryroot);
                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行uploadTestData】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, jkbs, xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        public bool uploadLineStatus(Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement("stationdevicestatus");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行uploadLineStatus】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, "ST411", xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lx">1-加载滑行 2-附加功率损失 3-寄生功率 4-分析仪检查 5-泄露检查 6-氧量程检查 7-低标气检查 8-流量计</param>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool uploadSelfCheckData( int lx, Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                string rootname = "";
                string jkbs = "";
                switch (lx)
                {
                    case 1:
                        rootname = "dynamometerloadcheck"; jkbs = "ST412";
                        break;
                    case 2:
                        rootname = "additionalpowerlosscheck"; jkbs = "ST413"; break;
                    case 3:
                        rootname = "parasiticpowerselfcheck"; jkbs = "ST414"; break;
                    case 4:
                        rootname = "analyzercheckdata"; jkbs = "ST415"; break;
                    case 5:
                        rootname = "leakcheckdata"; jkbs = "ST416"; break;
                    case 6:
                        rootname = "analyzero2checkdata"; jkbs = "ST417";
                        break;
                    case 7:
                        rootname = "lowgascheckdata"; jkbs = "ST418"; break;
                    case 8:
                        rootname = "flowmetercheckdata"; jkbs = "ST419"; break;
                }
                
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement(rootname);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行uploadSelfCheckData】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, jkbs, xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lx">1-不透光 2-双怠速气体分析仪 3-环境参数 4-汽油线标定 5-柴油线标定</param>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool uploadDemarcateData(int lx, Hashtable ht, out string result, out string errMsg)
        {
            result = "1";
            errMsg = "";
            bool ack;
            try
            {
                string rootname = "";
                string jkbs = "";
                switch (lx)
                {
                    case 1:
                        rootname = "lightproofsmokeselfcheck"; jkbs = "ST420";
                        break;
                    case 2:
                        rootname = "tsigasanalyzerselfcheck"; jkbs = "ST421"; break;
                    case 3:
                        rootname = "envparamsensor"; jkbs = "ST422"; break;
                    case 4:
                        rootname = "linecheckpetrol"; jkbs = "ST423"; break;
                    case 5:
                        rootname = "linecheckdiesel"; jkbs = "ST424"; break;
                }

                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement queryroot = xmldoc.CreateElement(rootname);
                
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe1 = xmldoc.CreateElement((string)et.Key);
                    xe1.InnerText = (string)et.Value;
                    queryroot.AppendChild(xe1);
                }
                root.AppendChild(queryroot);
                string xmlstring = ConvertXmlToString(xmldoc);
                INIIO.saveSocketLogInf("【执行uploadDemarcateData】");
                INIIO.saveSocketLogInf("【发送】:\r\n" + xmlstring);
                string mm = "";
                if (xmlstring.Length >= 96)
                    mm = xmlstring.Substring(62, 34);
                mm = ini.INIIO.md5low(mm + jmmm, 32);
                string revXml = service.WriteObject(xtlb, jkbs, xmlstring, yhdh, mm);
                INIIO.saveSocketLogInf("【接收】:\r\n" + revXml);
                revXml = ini.INIIO.decodeUTF8(revXml);
                INIIO.saveSocketLogInf("【接收解码后】:\r\n" + revXml);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(revXml);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg =dt1.Rows[0]["message"].ToString();
                INIIO.saveSocketLogInf("【result】" + result);
                INIIO.saveSocketLogInf("【errMsg】" + errMsg);
                if (result == "1")
                {
                    INIIO.saveSocketLogInf("【成功】");
                    return true;
                }
                else
                {
                    INIIO.saveSocketLogInf("【失败】");
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                INIIO.saveSocketLogInf("【异常】:\r\n" + er.Message);
                return false;
            }
        }
    }
}
