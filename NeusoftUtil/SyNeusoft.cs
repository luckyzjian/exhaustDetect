using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Xml;
using System.IO;
using carinfor;
using ini;

namespace NeusoftUtil
{
    public class SyNeusoft
    {
        public string EISID = "0000000016";
        WebReference.WebCtrlCenter webctrlcenter = new WebReference.WebCtrlCenter();
        public SyNeusoft(string url, string eisid)
        {
            webctrlcenter.Url = url;
            EISID = eisid;
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
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }

        public void ReadDatatimeString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables["Row"];
            result = dt1.Rows[0]["DateTime"].ToString();
            info = dt1.Rows[0][0].ToString();
        }
        public void ReadDatatimeStringV21(string xmlstring, out string driverNameList, out string result, out string info)
        {
            driverNameList = "";
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables["Row"];
            result = dt1.Rows[0]["DateTime"].ToString();
            info = dt1.Rows[0][0].ToString();
            driverNameList = dt1.Rows[1]["DriverUser"].ToString();
        }
        public void ReadLoginUserString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables["Row"];
            result = dt1.Rows[0]["Result"].ToString();
            info = dt1.Rows[0][0].ToString();
        }
        public void ReadACKString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables["Row"];
            result = dt1.Rows[0]["Result"].ToString();
            info = dt1.Rows[0]["ErrorMessage"].ToString();
        }
        public DataTable ReadVehicleList(string xmlstring)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;

            dt1 = ds.Tables["Respond"];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "Verify")
            {
                return null;
            }
            else
            {
                dt1 = ds.Tables["Vehicle"];
                return dt1;
            }
        }
        //private void Proccess()
        //{
        //    if (socket.Connected)
        //    {
        //        while (flag)
        //        {
        //            //Thread.Sleep(10);
        //            byte[] buffer = new byte[1024 * 1024];
        //            int n = socket.Receive(buffer);
        //            string s = Encoding.UTF8.GetString(buffer, 0, n);
        //            //s = s.Remove(0, 1);
        //            receivedString = s;//.Remove(s.Length - 1, 1);
        //            receivedflag = true;
        //            while (receivedflag) Thread.Sleep(10);

        //        }
        //    }
        //}

        public bool  GetTimeRequest(out string result,out string inf,out string datetimestring)
        {
            //socket.Connect(point);
            result = "";
            inf = "";
            datetimestring = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", "GetTime");//设置该节点genre属性             
                root.AppendChild(xe1);

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                datetimestring = dt1.Rows[0]["DateTime"].ToString();                
                return true;
            }
            catch(Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
            
        }
        public bool GetVehicleList(out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = new DataTable();
            try
            {
                //socket.Connect(point);
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", "VehicleList");//设置该节点genre属性             
                root.AppendChild(xe1);

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = null;
                dt1 = ds.Tables["Respond"];
                string respondName = dt1.Rows[0]["Name"].ToString();
                if (respondName == "Verify")
                {
                    result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                    inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                    ack =null;
                }
                else
                {
                    result = "0";
                    inf ="";
                    dt1 = ds.Tables["Vehicle"];
                    ack=dt1;
                }
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool loginUser(string czyname, string czypassword, string logintype, out string result, out string inf)
        {
            result = "";
            inf = "";
            try
            {
                //socket.Connect(point);
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", "Verify");//设置该节点genre属性 

                XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe3 = xmldoc.CreateElement("User");
                xe3.InnerText = czyname;
                XmlElement xe4 = xmldoc.CreateElement("Pwd");
                xe4.InnerText = czypassword;
                XmlElement xe5 = xmldoc.CreateElement("LoginType");
                xe5.InnerText = logintype;
                xe2.AppendChild(xe3);
                xe2.AppendChild(xe4);
                xe2.AppendChild(xe5);
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);


                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool VerifyRequest(EISVerify verifymodule, out string result, out string inf)
        {
            result = "";
            inf = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", verifymodule.name);//设置该节点genre属性
                XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("User");//创建一个<Node>节点 
                xe3.InnerText = verifymodule.staffID;
                XmlElement xe4 = xmldoc.CreateElement("Pwd");//创建一个<Node>节点  
                xe4.InnerText = verifymodule.staffPassword;
                XmlElement xe5 = xmldoc.CreateElement("LoginType");//创建一个<Node>节点
                xe5.InnerText = verifymodule.loginType;
                xe2.AppendChild(xe3);
                xe2.AppendChild(xe4);
                xe2.AppendChild(xe5);
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        /*public string VehicleRequest(VehicleInfo vehicleinfmodule)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", vehicleinfmodule.name);//设置该节点genre属性
            XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("License");//创建一个<Node>节点 
            xe3.InnerText = vehicleinfmodule.License;
            XmlElement xe4 = xmldoc.CreateElement("LicenseType");//创建一个<Node>节点  
            xe4.InnerText = vehicleinfmodule.LicenseType;
            XmlElement xe5 = xmldoc.CreateElement("VIN");//创建一个<Node>节点
            xe5.InnerText = vehicleinfmodule.VIN;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return receivedString;
            }
            else
            {
                return "no ACK";
            }
        }*/
        public bool VehicleRequest(string vehicleplate, string licenseType, string vin, out string result, out string inf, out string outlookID,out DataSet ack)
        {
            result = "";
            inf = "";
            outlookID = "";
            ack =null;
            try
            {
                DataSet dt = null;
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;

                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", "VehicleInfo");//设置该节点genre属性
                XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("License");//创建一个<Node>节点 
                xe3.InnerText = vehicleplate;
                XmlElement xe4 = xmldoc.CreateElement("LicenseType");//创建一个<Node>节点  
                xe4.InnerText = licenseType;
                XmlElement xe5 = xmldoc.CreateElement("VIN");//创建一个<Node>节点
                xe5.InnerText = vin;
                //xe5.InnerText = vehicleinfmodule.VIN;
                xe2.AppendChild(xe3);
                xe2.AppendChild(xe4);
                xe2.AppendChild(xe5);
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);


                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = null;
                dt1 = ds.Tables["Respond"];
                string respondName = dt1.Rows[0]["Name"].ToString();
                if (respondName == "Verify")
                {
                    result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                    inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                    ack = null;
                }
                else
                {
                    result = "0";
                    inf = "";      
                    outlookID = ds.Tables["Message"].Rows[0]["OutlookID"].ToString();
                    ack = ds;
                }
                return true;
                
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        /*public static DataSet ReadVehicleInf(string xmlstring, out string result, out string errorMessage, out string outlookID)
        {
            result = "";
            errorMessage = "";
            outlookID = "";
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;
            dt1 = ds.Tables[1];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "Verify")
            {
                ReadACKString(xmlstring, out result, out errorMessage);
                return null;
            }
            else
            {
                dt1 = ds.Tables[0];
                outlookID = dt1.Rows[0]["OutlookID"].ToString();
                dt1 = ds.Tables[3];
                return ds;
            }
        }*/
        /*public static DataTable ReadVmasResult(string xmlstring, out string result, out string errorMessage)
        {
            result = "";
            errorMessage = "";
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;
            dt1 = ds.Tables[1];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "Verify")
            {
                ReadACKString(xmlstring, out result, out errorMessage);
                return null;
            }
            else
            {
                try
                {
                    dt1 = ds.Tables[2];
                    return dt1;
                }
                catch
                {
                    return null;
                }
            }
        }*/
        public void ReadCalibration(string xmlstring, out string result, out string errorMessage)
        {
            result = "";
            errorMessage = "";
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;
            dt1 = ds.Tables[1];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "Calibration")
            {
                ReadACKString(xmlstring, out result, out errorMessage);
            }
        }
        public bool SendTestStatus(string outlookID, string statusName, out string result, out string inf)
        {

            result = "";
            inf = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", outlookID);//设置该节点genre属性  
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", statusName);//设置该节点genre属性
                                                     //xe1.SetAttribute("OutlookID", starttestModule.OutlookID);//设置该节点genre属性    
                root.AppendChild(xe1);


                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool Testing5025Request(Testing5025 Testing5025Module, out string result, out string inf)
        {
            result = "";
            inf = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("OutlookID", Testing5025Module.OutlookID);//设置该节点genre属性  
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", Testing5025Module.name);//设置该节点genre属性 
                //xe1.SetAttribute("OutlookID", Testing5025Module.OutlookID);//设置该节点genre属性    
                root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }

        public bool UploadGasolineResultRequest(UploadGasolineResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf,out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe4 = xmldoc.CreateElement("Temperature");
                xe4.InnerText = gasolineresultmodule.Temperature;
                XmlElement xe5 = xmldoc.CreateElement("AirPressure");
                xe5.InnerText = gasolineresultmodule.AirPressure;
                XmlElement xe6 = xmldoc.CreateElement("Humidity");
                xe6.InnerText = gasolineresultmodule.Humidity;
                XmlElement xe7 = xmldoc.CreateElement("AmbientCO");
                xe7.InnerText = gasolineresultmodule.AmbientCO;
                XmlElement xe8 = xmldoc.CreateElement("AmbientCO2");
                xe8.InnerText = gasolineresultmodule.AmbientCO2;
                XmlElement xe9 = xmldoc.CreateElement("AmbientHC");
                xe9.InnerText = gasolineresultmodule.AmbientHC;
                XmlElement xe10 = xmldoc.CreateElement("AmbientNO");
                xe10.InnerText = gasolineresultmodule.AmbientNO;
                XmlElement xe11 = xmldoc.CreateElement("AmbientO2");
                xe11.InnerText = gasolineresultmodule.AmbientO2;
                XmlElement xe12 = xmldoc.CreateElement("BackgroundCO");
                xe12.InnerText = gasolineresultmodule.BackgroundCO;
                XmlElement xe13 = xmldoc.CreateElement("BackgroundCO2");
                xe13.InnerText = gasolineresultmodule.BackgroundCO2;
                XmlElement xe14 = xmldoc.CreateElement("BackgroundHC");
                xe14.InnerText = gasolineresultmodule.BackgroundHC;
                XmlElement xe15 = xmldoc.CreateElement("BackgroundNO");
                xe15.InnerText = gasolineresultmodule.BackgroundNO;
                XmlElement xe16 = xmldoc.CreateElement("BackgroundO2");
                xe16.InnerText = gasolineresultmodule.BackgroundO2;
                XmlElement xe17 = xmldoc.CreateElement("ResidualHC");
                xe17.InnerText = gasolineresultmodule.ResidualHC;
                XmlElement xe18 = xmldoc.CreateElement("CO5025");
                xe18.InnerText = gasolineresultmodule.CO5025;
                XmlElement xe19 = xmldoc.CreateElement("HC5025");
                xe19.InnerText = gasolineresultmodule.HC5025;
                XmlElement xe20 = xmldoc.CreateElement("NO5025");
                xe20.InnerText = gasolineresultmodule.NO5025;
                XmlElement xe21 = xmldoc.CreateElement("Power5025");
                xe21.InnerText = gasolineresultmodule.Power5025;
                XmlElement xe22 = xmldoc.CreateElement("Rev5025");
                xe22.InnerText = gasolineresultmodule.Rev5025;
                XmlElement xe44 = xmldoc.CreateElement("Lambda5025");
                xe44.InnerText = gasolineresultmodule.Lambda5025;
                XmlElement xe23 = xmldoc.CreateElement("CO2540");
                xe23.InnerText = gasolineresultmodule.CO2540;
                XmlElement xe24 = xmldoc.CreateElement("HC2540");
                xe24.InnerText = gasolineresultmodule.HC2540;
                XmlElement xe25 = xmldoc.CreateElement("NO2540");
                xe25.InnerText = gasolineresultmodule.NO2540;
                XmlElement xe26 = xmldoc.CreateElement("Power2540");
                xe26.InnerText = gasolineresultmodule.Power2540;
                XmlElement xe45 = xmldoc.CreateElement("Rev2540");
                xe45.InnerText = gasolineresultmodule.Rev2540;
                XmlElement xe46 = xmldoc.CreateElement("Lambda2540");
                xe46.InnerText = gasolineresultmodule.Lambda2540;
                XmlElement xe27 = xmldoc.CreateElement("Result");
                xe27.InnerText = gasolineresultmodule.Result;
                XmlElement xe28 = xmldoc.CreateElement("StartTime");
                xe28.InnerText = gasolineresultmodule.StartTime;
                XmlElement xe29 = xmldoc.CreateElement("Has5025Tested");
                xe29.InnerText = gasolineresultmodule.Has5025Tested;
                XmlElement xe30 = xmldoc.CreateElement("Has2540Tested");
                xe30.InnerText = gasolineresultmodule.Has2540Tested;
                XmlElement xe31 = xmldoc.CreateElement("StopReason");
                xe31.InnerText = gasolineresultmodule.StopReason;
                xe3.AppendChild(xe4);
                xe3.AppendChild(xe5);
                xe3.AppendChild(xe6);
                xe3.AppendChild(xe7);
                xe3.AppendChild(xe8);
                xe3.AppendChild(xe9);
                xe3.AppendChild(xe10);
                xe3.AppendChild(xe11);
                xe3.AppendChild(xe12);
                xe3.AppendChild(xe13);
                xe3.AppendChild(xe14);
                xe3.AppendChild(xe15);
                xe3.AppendChild(xe16);
                xe3.AppendChild(xe17);
                xe3.AppendChild(xe18);
                xe3.AppendChild(xe19);
                xe3.AppendChild(xe20);
                xe3.AppendChild(xe21);
                xe3.AppendChild(xe22);
                xe3.AppendChild(xe44);
                xe3.AppendChild(xe23);
                xe3.AppendChild(xe24);
                xe3.AppendChild(xe25);
                xe3.AppendChild(xe26);
                xe3.AppendChild(xe45);
                xe3.AppendChild(xe46);
                xe3.AppendChild(xe27);
                xe3.AppendChild(xe28);
                xe3.AppendChild(xe29);
                xe3.AppendChild(xe30);
                xe3.AppendChild(xe31);

                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);

                if (asmdataseconds != null)
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                    {
                        XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                        DataRow dr = asmdataseconds.Rows[i];
                        XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                        xe34.InnerText = dr["采样时序"].ToString();
                        XmlElement xe35 = xmldoc.CreateElement("DataType");
                        xe35.InnerText = dr["时序类别"].ToString();
                        XmlElement xe36 = xmldoc.CreateElement("Velocity");
                        xe36.InnerText = dr["实时车速"].ToString();
                        XmlElement xe37 = xmldoc.CreateElement("Rev");
                        xe37.InnerText = dr["转速"].ToString();
                        XmlElement xe38 = xmldoc.CreateElement("Power");
                        xe38.InnerText = dr["加载功率"].ToString();
                        XmlElement xe39 = xmldoc.CreateElement("CO");
                        xe39.InnerText = dr["CO实时值"].ToString();
                        XmlElement xe40 = xmldoc.CreateElement("CO2");
                        xe40.InnerText = dr["CO2实时值"].ToString();
                        XmlElement xe41 = xmldoc.CreateElement("HC");
                        xe41.InnerText = dr["HC实时值"].ToString();
                        XmlElement xe42 = xmldoc.CreateElement("NO");
                        xe42.InnerText = dr["NO实时值"].ToString();
                        XmlElement xe43 = xmldoc.CreateElement("O2");
                        xe43.InnerText = dr["O2实时值"].ToString();
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

                        xe32.AppendChild(xe33);
                    }
                    xe1.AppendChild(xe32);
                }
                else
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                    xe34.InnerText = "";
                    XmlElement xe35 = xmldoc.CreateElement("DataType");
                    xe35.InnerText = "";
                    XmlElement xe36 = xmldoc.CreateElement("Velocity");
                    xe36.InnerText = "";
                    XmlElement xe37 = xmldoc.CreateElement("Rev");
                    xe37.InnerText = "";
                    XmlElement xe38 = xmldoc.CreateElement("Power");
                    xe38.InnerText = "";
                    XmlElement xe39 = xmldoc.CreateElement("CO");
                    xe39.InnerText = "";
                    XmlElement xe40 = xmldoc.CreateElement("CO2");
                    xe40.InnerText = "";
                    XmlElement xe41 = xmldoc.CreateElement("HC");
                    xe41.InnerText = "";
                    XmlElement xe42 = xmldoc.CreateElement("NO");
                    xe42.InnerText = "";
                    XmlElement xe43 = xmldoc.CreateElement("O2");
                    xe43.InnerText = "";
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
                    xe32.AppendChild(xe33);
                    xe1.AppendChild(xe32);
                }

                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                    result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                    inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                    ack = null;
                
                return true;

            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }

        }
        public bool UploadVmasResultRequest(UploadVmasResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe4 = xmldoc.CreateElement("Temperature");
                xe4.InnerText = gasolineresultmodule.Temperature;
                XmlElement xe5 = xmldoc.CreateElement("AirPressure");
                xe5.InnerText = gasolineresultmodule.AirPressure;
                XmlElement xe6 = xmldoc.CreateElement("Humidity");
                xe6.InnerText = gasolineresultmodule.Humidity;
                XmlElement xe7 = xmldoc.CreateElement("AmbientO2");
                xe7.InnerText = gasolineresultmodule.AmbientO2;
                XmlElement xe8 = xmldoc.CreateElement("ResidualHC");
                xe8.InnerText = gasolineresultmodule.ResidualHC;
                XmlElement xe9 = xmldoc.CreateElement("TestTime");
                xe9.InnerText = gasolineresultmodule.TestTime;
                XmlElement xe10 = xmldoc.CreateElement("AirFlowAll");
                xe10.InnerText = gasolineresultmodule.AirFlowAll;
                XmlElement xe11 = xmldoc.CreateElement("CO");
                xe11.InnerText = gasolineresultmodule.CO;
                XmlElement xe12 = xmldoc.CreateElement("CO2");
                xe12.InnerText = gasolineresultmodule.CO2;
                XmlElement xe13 = xmldoc.CreateElement("HC");
                xe13.InnerText = gasolineresultmodule.HC;
                XmlElement xe14 = xmldoc.CreateElement("NOX");
                xe14.InnerText = gasolineresultmodule.NOX;
                XmlElement xe15 = xmldoc.CreateElement("HCNOX");
                xe15.InnerText = gasolineresultmodule.HCNOX;
                XmlElement xe16 = xmldoc.CreateElement("Power");
                xe16.InnerText = gasolineresultmodule.Power;
                XmlElement xe17 = xmldoc.CreateElement("Result");
                xe17.InnerText = gasolineresultmodule.Result;
                XmlElement xe18 = xmldoc.CreateElement("StartTime");
                xe18.InnerText = gasolineresultmodule.StartTime;
                XmlElement xe19 = xmldoc.CreateElement("StopReason");
                xe19.InnerText = gasolineresultmodule.StopReason;
                xe3.AppendChild(xe4);
                xe3.AppendChild(xe5);
                xe3.AppendChild(xe6);
                xe3.AppendChild(xe7);
                xe3.AppendChild(xe8);
                xe3.AppendChild(xe9);
                xe3.AppendChild(xe10);
                xe3.AppendChild(xe11);
                xe3.AppendChild(xe12);
                xe3.AppendChild(xe13);
                xe3.AppendChild(xe14);
                xe3.AppendChild(xe15);
                xe3.AppendChild(xe16);
                xe3.AppendChild(xe17);
                xe3.AppendChild(xe18);
                xe3.AppendChild(xe19);
                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);

                if (asmdataseconds != null)
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    int timercount = 0;
                    for (int i = asmdataseconds.Rows.Count-195; i < asmdataseconds.Rows.Count; i++)
                    {
                        XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                        DataRow dr = asmdataseconds.Rows[i];
                        XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                        xe34.InnerText = (timercount++).ToString();
                        XmlElement xe35 = xmldoc.CreateElement("DataType");
                        xe35.InnerText = dr["时序类别"].ToString();
                        XmlElement xe36 = xmldoc.CreateElement("Torque");
                        xe36.InnerText = dr["扭矩"].ToString();
                        XmlElement xe37 = xmldoc.CreateElement("Velocity");
                        xe37.InnerText = dr["实时车速"].ToString();
                        XmlElement xe38 = xmldoc.CreateElement("Rev");
                        xe38.InnerText = dr["发动机转速"].ToString();
                        XmlElement xe39 = xmldoc.CreateElement("Power");
                        xe39.InnerText = dr["加载功率"].ToString();
                        XmlElement xe40 = xmldoc.CreateElement("CO");
                        xe40.InnerText = dr["CO实时值"].ToString();
                        XmlElement xe41 = xmldoc.CreateElement("CO2");
                        xe41.InnerText = dr["CO2实时值"].ToString();
                        XmlElement xe42 = xmldoc.CreateElement("HC");
                        xe42.InnerText = dr["HC实时值"].ToString();
                        XmlElement xe43 = xmldoc.CreateElement("NOX");
                        xe43.InnerText = dr["NO实时值"].ToString();
                        XmlElement xe44 = xmldoc.CreateElement("HCNOX");
                        xe44.InnerText = (float.Parse(dr["NO实时值"].ToString()) + float.Parse(dr["HC实时值"].ToString())).ToString();
                        XmlElement xe45 = xmldoc.CreateElement("O2");
                        xe45.InnerText = dr["分析仪O2实时值"].ToString();
                        XmlElement xe46 = xmldoc.CreateElement("AirFlowO2");
                        xe46.InnerText = dr["流量计O2实时值"].ToString();
                        XmlElement xe47 = xmldoc.CreateElement("AirFlow");
                        xe47.InnerText = dr["标准体积流量"].ToString();
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
                        xe32.AppendChild(xe33);
                    }
                    xe1.AppendChild(xe32);
                }
                else
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                    xe34.InnerText = "";
                    XmlElement xe35 = xmldoc.CreateElement("DataType");
                    xe35.InnerText = "";
                    XmlElement xe36 = xmldoc.CreateElement("Torque");
                    xe36.InnerText = "";
                    XmlElement xe37 = xmldoc.CreateElement("Velocity");
                    xe37.InnerText = "";
                    XmlElement xe38 = xmldoc.CreateElement("Rev");
                    xe38.InnerText = "";
                    XmlElement xe39 = xmldoc.CreateElement("Power");
                    xe39.InnerText = "";
                    XmlElement xe40 = xmldoc.CreateElement("CO");
                    xe40.InnerText = "";
                    XmlElement xe41 = xmldoc.CreateElement("CO2");
                    xe41.InnerText = "";
                    XmlElement xe42 = xmldoc.CreateElement("HC");
                    xe42.InnerText = "";
                    XmlElement xe43 = xmldoc.CreateElement("NOX");
                    xe43.InnerText = "";
                    XmlElement xe44 = xmldoc.CreateElement("HCNOX");
                    xe44.InnerText = "";
                    XmlElement xe45 = xmldoc.CreateElement("O2");
                    xe45.InnerText = "";
                    XmlElement xe46 = xmldoc.CreateElement("AirFlowO2");
                    xe46.InnerText = "";
                    XmlElement xe47 = xmldoc.CreateElement("AirFlow");
                    xe47.InnerText = "";
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
                    xe32.AppendChild(xe33);
                    xe1.AppendChild(xe32);
                }

                root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }

        public bool UploadDieselResultRequest(UploadDieselResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe4 = xmldoc.CreateElement("Temperature");
                xe4.InnerText = gasolineresultmodule.Temperature;
                XmlElement xe5 = xmldoc.CreateElement("AirPressure");
                xe5.InnerText = gasolineresultmodule.AirPressure;
                XmlElement xe6 = xmldoc.CreateElement("Humidity");
                xe6.InnerText = gasolineresultmodule.Humidity;
                XmlElement xe7 = xmldoc.CreateElement("K100");
                xe7.InnerText = gasolineresultmodule.K100;
                XmlElement xe8 = xmldoc.CreateElement("K90");
                xe8.InnerText = gasolineresultmodule.K90;
                XmlElement xe9 = xmldoc.CreateElement("K80");
                xe9.InnerText = gasolineresultmodule.K80;
                XmlElement xe10 = xmldoc.CreateElement("MaxPower");
                xe10.InnerText = gasolineresultmodule.MaxPower;
                XmlElement xe11 = xmldoc.CreateElement("Rev100");
                xe11.InnerText = gasolineresultmodule.Rev100;
                XmlElement xe12 = xmldoc.CreateElement("StartTime");
                xe12.InnerText = gasolineresultmodule.StartTime;
                XmlElement xe13 = xmldoc.CreateElement("Result");
                xe13.InnerText = gasolineresultmodule.Result;
                XmlElement xe14 = xmldoc.CreateElement("StopReason");
                xe14.InnerText = gasolineresultmodule.StopReason;
                xe3.AppendChild(xe4);
                xe3.AppendChild(xe5);
                xe3.AppendChild(xe6);
                xe3.AppendChild(xe7);
                xe3.AppendChild(xe8);
                xe3.AppendChild(xe9);
                xe3.AppendChild(xe10);
                xe3.AppendChild(xe11);
                xe3.AppendChild(xe12);
                xe3.AppendChild(xe13);
                xe3.AppendChild(xe14);
                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);
                if (asmdataseconds != null)
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                    {
                        XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                        DataRow dr = asmdataseconds.Rows[i];
                        XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                        xe34.InnerText = dr["采样时序"].ToString();
                        XmlElement xe35 = xmldoc.CreateElement("DataType");
                        xe35.InnerText = dr["时序类别"].ToString();
                        XmlElement xe36 = xmldoc.CreateElement("Velocity");
                        xe36.InnerText = dr["车速"].ToString();
                        XmlElement xe37 = xmldoc.CreateElement("Rev");
                        xe37.InnerText = dr["转速"].ToString();
                        XmlElement xe38 = xmldoc.CreateElement("Power");
                        xe38.InnerText = dr["功率"].ToString();
                        XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                        xe39.InnerText = dr["光吸收系数K"].ToString();
                        xe33.AppendChild(xe34);
                        xe33.AppendChild(xe35);
                        xe33.AppendChild(xe36);
                        xe33.AppendChild(xe37);
                        xe33.AppendChild(xe38);
                        xe33.AppendChild(xe39);
                        xe32.AppendChild(xe33);
                    }
                    xe1.AppendChild(xe32);
                }
                else
                {
                    XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                    XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                    xe34.InnerText = "";
                    XmlElement xe35 = xmldoc.CreateElement("DataType");
                    xe35.InnerText = "";
                    XmlElement xe36 = xmldoc.CreateElement("Velocity");
                    xe36.InnerText = "";
                    XmlElement xe37 = xmldoc.CreateElement("Rev");
                    xe37.InnerText = "";
                    XmlElement xe38 = xmldoc.CreateElement("Power");
                    xe38.InnerText = "";
                    XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                    xe39.InnerText = "";
                    xe33.AppendChild(xe34);
                    xe33.AppendChild(xe35);
                    xe33.AppendChild(xe36);
                    xe33.AppendChild(xe37);
                    xe33.AppendChild(xe38);
                    xe33.AppendChild(xe39);
                    xe32.AppendChild(xe33);
                    xe1.AppendChild(xe32);
                }

                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadDIdleResultRequest(UploadDIdleResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
            XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("Temperature");
            xe4.InnerText = gasolineresultmodule.Temperature;
            XmlElement xe5 = xmldoc.CreateElement("AirPressure");
            xe5.InnerText = gasolineresultmodule.AirPressure;
            XmlElement xe6 = xmldoc.CreateElement("Humidity");
            xe6.InnerText = gasolineresultmodule.Humidity;
            XmlElement xe7 = xmldoc.CreateElement("LowIdleCO");
            xe7.InnerText = gasolineresultmodule.LowIdleCO;
            XmlElement xe8 = xmldoc.CreateElement("LowIdleHC");
            xe8.InnerText = gasolineresultmodule.LowIdleHC;
            XmlElement xe9 = xmldoc.CreateElement("HighIdleCO");
            xe9.InnerText = gasolineresultmodule.HighIdleCO;
            XmlElement xe10 = xmldoc.CreateElement("HighIdleHC");
            xe10.InnerText = gasolineresultmodule.HighIdleHC;
            XmlElement xe11 = xmldoc.CreateElement("Lambda");
            xe11.InnerText = gasolineresultmodule.Lambda;
            XmlElement xe12 = xmldoc.CreateElement("Result");
            xe12.InnerText = gasolineresultmodule.Result;
            XmlElement xe13 = xmldoc.CreateElement("StartTime");
            xe13.InnerText = gasolineresultmodule.StartTime;
            XmlElement xe14 = xmldoc.CreateElement("StopReason");
            xe14.InnerText = gasolineresultmodule.StopReason;
                XmlElement xe15 = xmldoc.CreateElement("LowIdleRev");
                xe15.InnerText = gasolineresultmodule.LowIdleRev;
                XmlElement xe16 = xmldoc.CreateElement("HighIdleRev");
                xe16.InnerText = gasolineresultmodule.HighIdleRev;
            xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
            xe3.AppendChild(xe9);
            xe3.AppendChild(xe10);
            xe3.AppendChild(xe11);
            xe3.AppendChild(xe12);
            xe3.AppendChild(xe13);
            xe3.AppendChild(xe14);
                xe3.AppendChild(xe15);
                xe3.AppendChild(xe16);


                xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);
            if (asmdataseconds != null)
            {

                XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                int cysxcount = 0;
                for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                {
                    DataRow dr = asmdataseconds.Rows[i];
                    if (dr["时序类别"].ToString() != "0")
                    {
                        string sxnb = "1";
                        if (dr["时序类别"].ToString() == "1" || dr["时序类别"].ToString() == "2")
                            sxnb = "1";
                        else
                            sxnb = "2";
                        XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                        XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                        xe34.InnerText = cysxcount.ToString();
                        XmlElement xe35 = xmldoc.CreateElement("DataType");
                        xe35.InnerText = sxnb;
                        XmlElement xe37 = xmldoc.CreateElement("Rev");
                        xe37.InnerText = dr["转速"].ToString();
                        XmlElement xe39 = xmldoc.CreateElement("CO");
                        xe39.InnerText = dr["CO"].ToString();
                        XmlElement xe41 = xmldoc.CreateElement("HC");
                        xe41.InnerText = dr["HC"].ToString();
                        XmlElement xe42 = xmldoc.CreateElement("Lambda");
                        xe42.InnerText = dr["过量空气系数"].ToString();
                        xe33.AppendChild(xe34);
                        xe33.AppendChild(xe35);
                        xe33.AppendChild(xe37);
                        xe33.AppendChild(xe39);
                        xe33.AppendChild(xe41);
                        xe33.AppendChild(xe42);
                        xe32.AppendChild(xe33);
                        cysxcount++;
                    }
                }
                xe1.AppendChild(xe32);
            }
            else
            {

                XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                xe34.InnerText = "";
                XmlElement xe35 = xmldoc.CreateElement("DataType");
                xe35.InnerText = "";
                XmlElement xe37 = xmldoc.CreateElement("Rev");
                xe37.InnerText = "";
                XmlElement xe39 = xmldoc.CreateElement("CO");
                xe39.InnerText = "";
                XmlElement xe41 = xmldoc.CreateElement("HC");
                xe41.InnerText = "";
                XmlElement xe42 = xmldoc.CreateElement("Lambda");
                xe42.InnerText = "";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe35);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe39);
                xe33.AppendChild(xe41);
                xe33.AppendChild(xe42);

                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;

            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }

        }
        public bool UploadDieselFAResultRequest(UploadDieselFAResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
            XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("Temperature");
            xe4.InnerText = gasolineresultmodule.Temperature;
            XmlElement xe5 = xmldoc.CreateElement("AirPressure");
            xe5.InnerText = gasolineresultmodule.AirPressure;
            XmlElement xe6 = xmldoc.CreateElement("Humidity");
            xe6.InnerText = gasolineresultmodule.Humidity;
            XmlElement xe7 = xmldoc.CreateElement("SmokeK1");
            xe7.InnerText = gasolineresultmodule.SmokeK1;
            XmlElement xe8 = xmldoc.CreateElement("SmokeK2");
            xe8.InnerText = gasolineresultmodule.SmokeK2;
            XmlElement xe9 = xmldoc.CreateElement("SmokeK3");
            xe9.InnerText = gasolineresultmodule.SmokeK3;
            XmlElement xe10 = xmldoc.CreateElement("SmokeAvg");
            xe10.InnerText = gasolineresultmodule.SmokeAvg;
            XmlElement xe11 = xmldoc.CreateElement("IdleRev");
            xe11.InnerText = gasolineresultmodule.IdleRev;
            XmlElement xe12 = xmldoc.CreateElement("Result");
            xe12.InnerText = gasolineresultmodule.Result;
            XmlElement xe13 = xmldoc.CreateElement("StartTime");
            xe13.InnerText = gasolineresultmodule.StartTime;
            XmlElement xe14 = xmldoc.CreateElement("StopReason");
            xe14.InnerText = gasolineresultmodule.StopReason;
            xe3.AppendChild(xe4);
            xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
            xe3.AppendChild(xe9);
            xe3.AppendChild(xe10);
            xe3.AppendChild(xe11);
            xe3.AppendChild(xe12);
            xe3.AppendChild(xe13);
            xe3.AppendChild(xe14);


            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);

            if (asmdataseconds != null)
            {
                XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                int timercount = 0;
                for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                {
                    XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = asmdataseconds.Rows[i];
                    if (int.Parse(dr["时序类别"].ToString()) == 0)
                         continue;
                    XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                    xe34.InnerText = (timercount++).ToString();//时间计数，从0开始，每100ms递增1
                    XmlElement xe37 = xmldoc.CreateElement("IdleRev");
                    xe37.InnerText = dr["发动机转速"].ToString();
                    XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                    xe39.InnerText = dr["烟度值读数"].ToString();
                    xe33.AppendChild(xe34);
                    xe33.AppendChild(xe37);
                    xe33.AppendChild(xe39);

                    xe32.AppendChild(xe33);
                }
                xe1.AppendChild(xe32);
            }
            else
            {
                XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                xe34.InnerText = "";
                XmlElement xe37 = xmldoc.CreateElement("IdleRev");
                xe37.InnerText = "";
                XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                xe39.InnerText = "";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe39);

                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));

                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;

            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool StatusRequest(Status statusModule,out string result,out string inf)
        {
            result = "";
            inf = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", statusModule.name);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Row");
                XmlElement xe3 = xmldoc.CreateElement("Status");
                xe3.InnerText = statusModule.EquiStatus;
                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["Row"];
                result = dt1.Rows[0]["Result"].ToString();
                inf = dt1.Rows[0]["ErrorMessage"].ToString();
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        /*
        public static bool ReadCalStandard(string xmlstring, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                result = "";
                inf = "";
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;
                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }*/
        public bool UploadCoastdownRequest(Coastdown gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", gasolineresultmodule.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", gasolineresultmodule.namesy);//设置该节点genre属性 
            XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("BeginTime");
            xe4.InnerText = gasolineresultmodule.StartTime;
            XmlElement xe5 = xmldoc.CreateElement("ACDT40");
            xe5.InnerText = gasolineresultmodule.ACDT40;
            XmlElement xe6 = xmldoc.CreateElement("ACDT25");
            xe6.InnerText = gasolineresultmodule.ACDT24;
            XmlElement xe7 = xmldoc.CreateElement("PLHP40");
            xe7.InnerText = gasolineresultmodule.PLHP40;
            XmlElement xe8 = xmldoc.CreateElement("PLHP25");
            xe8.InnerText = gasolineresultmodule.PLHP24;
            XmlElement xe9 = xmldoc.CreateElement("CCDT40");
            xe9.InnerText = gasolineresultmodule.CCDT40;
            XmlElement xe10 = xmldoc.CreateElement("CCDT25");
            xe10.InnerText = gasolineresultmodule.CCDT24;
            XmlElement xe11 = xmldoc.CreateElement("IHP40");
            xe11.InnerText = gasolineresultmodule.IHP40;
            XmlElement xe12 = xmldoc.CreateElement("IHP25");
            xe12.InnerText = gasolineresultmodule.IHP24;
            XmlElement xe13 = xmldoc.CreateElement("DIW");
            xe13.InnerText = gasolineresultmodule.DIW;
            XmlElement xe14 = xmldoc.CreateElement("Result40");
            xe14.InnerText = gasolineresultmodule.Result40;
            XmlElement xe15 = xmldoc.CreateElement("Result25");
            xe15.InnerText = gasolineresultmodule.Result24;
            xe3.AppendChild(xe4);
            xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
            xe3.AppendChild(xe9);
            xe3.AppendChild(xe10);
            xe3.AppendChild(xe11);
            xe3.AppendChild(xe12);
            xe3.AppendChild(xe13);
            xe3.AppendChild(xe14);
            xe3.AppendChild(xe15);

            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);


            root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadParasiticLoseRequest(ParasiticLose gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", gasolineresultmodule.namesy);//设置该节点genre属性 
            XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("BeginTime");
            xe4.InnerText = gasolineresultmodule.StartTime;
                XmlElement xe11 = xmldoc.CreateElement("EndTime");
                xe11.InnerText = gasolineresultmodule.EndTime;
                XmlElement xe5 = xmldoc.CreateElement("ACDT40");
            xe5.InnerText = gasolineresultmodule.ACDT40;
            XmlElement xe6 = xmldoc.CreateElement("ACDT25");
            xe6.InnerText = gasolineresultmodule.ACDT24;
            XmlElement xe7 = xmldoc.CreateElement("PLHP40");
            xe7.InnerText = gasolineresultmodule.PLHP40;
            XmlElement xe8 = xmldoc.CreateElement("PLHP25");
            xe8.InnerText = gasolineresultmodule.PLHP24;
                XmlElement xe9= xmldoc.CreateElement("IHP40");
                xe9.InnerText = gasolineresultmodule.IHP40;
                XmlElement xe10 = xmldoc.CreateElement("IHP25");
                xe10.InnerText = gasolineresultmodule.IHP24;
                XmlElement xe13 = xmldoc.CreateElement("DIW");
            xe13.InnerText = gasolineresultmodule.DIW;
            xe3.AppendChild(xe4);
                xe3.AppendChild(xe11);
                xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
                xe3.AppendChild(xe9);
                xe3.AppendChild(xe10);
                xe3.AppendChild(xe13);

            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);



            root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadAnalyzerTest(AnalyzerTest gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                result = "";
                inf = "";
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", gasolineresultmodule.namesy);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement Type = xmldoc.CreateElement("Type");
                Type.InnerText = gasolineresultmodule.Type;
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");
                BeginTime.InnerText = gasolineresultmodule.BeginTime;
                XmlElement STD_CH = xmldoc.CreateElement("STD_CH");
                STD_CH.InnerText = gasolineresultmodule.STD_CH;
                XmlElement STD_CO = xmldoc.CreateElement("STD_CO");
                STD_CO.InnerText = gasolineresultmodule.STD_CO;
                XmlElement STD_CO2 = xmldoc.CreateElement("STD_CO2");
                STD_CO2.InnerText = gasolineresultmodule.STD_CO2;
                XmlElement STD_NO = xmldoc.CreateElement("STD_NO");
                STD_NO.InnerText = gasolineresultmodule.STD_NO;
                XmlElement STD_O2 = xmldoc.CreateElement("STD_O2");
                STD_O2.InnerText = gasolineresultmodule.STD_O2;
                XmlElement MEA_HC = xmldoc.CreateElement("MEA_HC");
                MEA_HC.InnerText = gasolineresultmodule.MEA_HC;
                XmlElement MEA_CO = xmldoc.CreateElement("MEA_CO");
                MEA_CO.InnerText = gasolineresultmodule.MEA_CO;
                XmlElement MEA_CO2 = xmldoc.CreateElement("MEA_CO2");
                MEA_CO2.InnerText = gasolineresultmodule.MEA_CO2;
                XmlElement MEA_NO = xmldoc.CreateElement("MEA_NO");
                MEA_NO.InnerText = gasolineresultmodule.MEA_NO;
                XmlElement MEA_O2 = xmldoc.CreateElement("MEA_O2");
                MEA_O2.InnerText = gasolineresultmodule.MEA_O2;
                XmlElement PEF = xmldoc.CreateElement("PEF");
                PEF.InnerText = gasolineresultmodule.PEF;
                XmlElement Result = xmldoc.CreateElement("Result");
                Result.InnerText = gasolineresultmodule.Result;
                xe3.AppendChild(Type);
                xe3.AppendChild(BeginTime);
                xe3.AppendChild(STD_CH);
                xe3.AppendChild(STD_CO);
                xe3.AppendChild(STD_CO2);
                xe3.AppendChild(STD_NO);
                xe3.AppendChild(STD_O2);
                xe3.AppendChild(MEA_HC);
                xe3.AppendChild(MEA_CO);
                xe3.AppendChild(MEA_CO2);
                xe3.AppendChild(MEA_NO);
                xe3.AppendChild(MEA_O2);
                xe3.AppendChild(PEF);
                xe3.AppendChild(Result);

                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);



                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadAnalyzerLowGasTest(AnalyzerLowGasTest gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                result = "";
                inf = "";
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", gasolineresultmodule.namesy);//设置该节点genre属性 
                XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
                XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");
                BeginTime.InnerText = gasolineresultmodule.BeginTime;
                XmlElement STD_CH = xmldoc.CreateElement("STD_CH");
                STD_CH.InnerText = gasolineresultmodule.STD_CH;
                XmlElement STD_CO = xmldoc.CreateElement("STD_CO");
                STD_CO.InnerText = gasolineresultmodule.STD_CO;
                XmlElement STD_CO2 = xmldoc.CreateElement("STD_CO2");
                STD_CO2.InnerText = gasolineresultmodule.STD_CO2;
                XmlElement STD_NO = xmldoc.CreateElement("STD_NO");
                STD_NO.InnerText = gasolineresultmodule.STD_NO;
                XmlElement STD_O2 = xmldoc.CreateElement("STD_O2");
                STD_O2.InnerText = gasolineresultmodule.STD_O2;
                XmlElement MEA_HC = xmldoc.CreateElement("MEA_HC");
                MEA_HC.InnerText = gasolineresultmodule.MEA_HC;
                XmlElement MEA_CO = xmldoc.CreateElement("MEA_CO");
                MEA_CO.InnerText = gasolineresultmodule.MEA_CO;
                XmlElement MEA_CO2 = xmldoc.CreateElement("MEA_CO2");
                MEA_CO2.InnerText = gasolineresultmodule.MEA_CO2;
                XmlElement MEA_NO = xmldoc.CreateElement("MEA_NO");
                MEA_NO.InnerText = gasolineresultmodule.MEA_NO;
                XmlElement MEA_O2 = xmldoc.CreateElement("MEA_O2");
                MEA_O2.InnerText = gasolineresultmodule.MEA_O2;
                XmlElement PEF = xmldoc.CreateElement("PEF");
                PEF.InnerText = gasolineresultmodule.PEF;
                XmlElement Result = xmldoc.CreateElement("Result");
                Result.InnerText = gasolineresultmodule.Result;
                xe3.AppendChild(BeginTime);
                xe3.AppendChild(STD_CH);
                xe3.AppendChild(STD_CO);
                xe3.AppendChild(STD_CO2);
                xe3.AppendChild(STD_NO);
                xe3.AppendChild(STD_O2);
                xe3.AppendChild(MEA_HC);
                xe3.AppendChild(MEA_CO);
                xe3.AppendChild(MEA_CO2);
                xe3.AppendChild(MEA_NO);
                xe3.AppendChild(MEA_O2);
                xe3.AppendChild(PEF);
                xe3.AppendChild(Result);

                xe2.AppendChild(xe3);
                xe1.AppendChild(xe2);



                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        /*public void UploadTorqueCalRequest(DataTable asmdataseconds, out string result, out string inf)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "TorqueCal");//设置该节点genre属性 
            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
                xe34.InnerText = dr["开始时间"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("Nominal");//名义扭矩
                xe36.InnerText = dr["标定点(N)"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("Check");//扭矩示值
                xe37.InnerText = dr["实测重量(N)"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Result");//0=不合格 1=合格
                xe38.InnerText = (dr["判定"].ToString() == "不合格") ? "0" : "1";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe1.AppendChild(xe33);
            }
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadSpeedCalRequest(DataTable asmdataseconds, out string result, out string inf)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "SpeedCal");//设置该节点genre属性 

            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
                xe34.InnerText = dr["开始时间"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("Nominal");//名义速度
                xe36.InnerText = dr["标准速度(Km/h)"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("Check");//速度示值
                xe37.InnerText = dr["实测速度(Km/h)"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Result");//0=不合格 1=合格
                xe38.InnerText = (dr["判定"].ToString() == "不合格") ? "0" : "1";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe1.AppendChild(xe33);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }*/
        /*public void UploadAnalyzerCalCheckRequest(AnalyzerCalCheck gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", gasolineresultmodule.name);//设置该节点genre属性 
            XmlElement xe2 = xmldoc.CreateElement("Result");//创建一个<Node>节点           
            XmlElement xe3 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("StartTime");
            xe4.InnerText = gasolineresultmodule.StartTime;
            XmlElement xe5 = xmldoc.CreateElement("HCTag");
            xe5.InnerText = gasolineresultmodule.HCTag;
            XmlElement xe6 = xmldoc.CreateElement("COTag");
            xe6.InnerText = gasolineresultmodule.COTag;
            XmlElement xe7 = xmldoc.CreateElement("CO2Tag");
            xe7.InnerText = gasolineresultmodule.CO2Tag;
            XmlElement xe8 = xmldoc.CreateElement("NOTag");
            xe8.InnerText = gasolineresultmodule.NOTag;
            XmlElement xe9 = xmldoc.CreateElement("CheckHCTag");
            xe9.InnerText = gasolineresultmodule.CheckHCTag;
            XmlElement xe10 = xmldoc.CreateElement("CheckCOTag");
            xe10.InnerText = gasolineresultmodule.CheckCOTag;
            XmlElement xe11 = xmldoc.CreateElement("CheckCO2Tag");
            xe11.InnerText = gasolineresultmodule.CheckCO2Tag;
            XmlElement xe12 = xmldoc.CreateElement("CheckNOTag");
            xe12.InnerText = gasolineresultmodule.CheckNOTag;
            XmlElement xe13 = xmldoc.CreateElement("HCCheckResult");
            xe13.InnerText = gasolineresultmodule.HCCheckResult;
            XmlElement xe14 = xmldoc.CreateElement("COCheckResult");
            xe14.InnerText = gasolineresultmodule.COCheckResult;
            XmlElement xe15 = xmldoc.CreateElement("CO2CheckResult");
            xe15.InnerText = gasolineresultmodule.CO2CheckResult;
            XmlElement xe16 = xmldoc.CreateElement("NOCheckResult");
            xe16.InnerText = gasolineresultmodule.NOCheckResult;
            XmlElement xe17 = xmldoc.CreateElement("HCT90");
            xe17.InnerText = gasolineresultmodule.HCT90;
            XmlElement xe18 = xmldoc.CreateElement("COT90");
            xe18.InnerText = gasolineresultmodule.COT90;
            XmlElement xe19 = xmldoc.CreateElement("CO2T90");
            xe19.InnerText = gasolineresultmodule.CO2T90;
            XmlElement xe20 = xmldoc.CreateElement("NOT90");
            xe20.InnerText = gasolineresultmodule.NOT90;
            XmlElement xe21 = xmldoc.CreateElement("O2T90");
            xe21.InnerText = gasolineresultmodule.O2T90;
            XmlElement xe22 = xmldoc.CreateElement("HCT10");
            xe22.InnerText = gasolineresultmodule.HCT10;
            XmlElement xe23 = xmldoc.CreateElement("COT10");
            xe23.InnerText = gasolineresultmodule.COT10;
            XmlElement xe24 = xmldoc.CreateElement("CO2T10");
            xe24.InnerText = gasolineresultmodule.CO2T10;
            XmlElement xe25 = xmldoc.CreateElement("NOT10");
            xe25.InnerText = gasolineresultmodule.NOT10;
            XmlElement xe26 = xmldoc.CreateElement("O2T10");
            xe26.InnerText = gasolineresultmodule.O2T10;
            XmlElement xe27 = xmldoc.CreateElement("PEF");
            xe27.InnerText = gasolineresultmodule.PEF;
            XmlElement xe28 = xmldoc.CreateElement("Result");
            xe28.InnerText = gasolineresultmodule.Result;
            xe3.AppendChild(xe4);
            xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
            xe3.AppendChild(xe9);
            xe3.AppendChild(xe10);
            xe3.AppendChild(xe11);
            xe3.AppendChild(xe12);
            xe3.AppendChild(xe13);
            xe3.AppendChild(xe14);
            xe3.AppendChild(xe15);
            xe3.AppendChild(xe16);
            xe3.AppendChild(xe17);
            xe3.AppendChild(xe18);
            xe3.AppendChild(xe19);
            xe3.AppendChild(xe20);
            xe3.AppendChild(xe21);
            xe3.AppendChild(xe22);
            xe3.AppendChild(xe23);
            xe3.AppendChild(xe24);
            xe3.AppendChild(xe25);
            xe3.AppendChild(xe26);
            xe3.AppendChild(xe27);
            xe3.AppendChild(xe28);
            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);

            XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                xe34.InnerText = dr["TimeCount"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("HC");
                xe36.InnerText = dr["HC"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("CO");
                xe37.InnerText = dr["CO"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("CO2");
                xe38.InnerText = dr["CO2"].ToString();
                XmlElement xe39 = xmldoc.CreateElement("O2");
                xe39.InnerText = dr["O2"].ToString();//轮边力
                XmlElement xe40 = xmldoc.CreateElement("NO");
                xe40.InnerText = dr["NO"].ToString();//扭矩
                XmlElement xe41 = xmldoc.CreateElement("PEF");
                xe41.InnerText = dr["PEF"].ToString();
                XmlElement xe42 = xmldoc.CreateElement("STATUS");
                xe42.InnerText = dr["STATUS"].ToString();//轮边力
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe39);
                xe33.AppendChild(xe40);
                xe33.AppendChild(xe41);
                xe33.AppendChild(xe42);
                xe32.AppendChild(xe33);
            }
            xe1.AppendChild(xe32);

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }*/
        public bool UploadAnalyzerLeakTestRequest(AnalyzerLeakTest leakdata, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {//socket.Connect(point);
                XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmlelem.SetAttribute("OutlookID", leakdata.OutlookID);//设置该节点genre属性
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "Leak");//设置该节点genre属性  
            XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("BeginTime");
            xe4.InnerText = leakdata.StartTime;
            XmlElement xe5 = xmldoc.CreateElement("Result");
            xe5.InnerText = leakdata.Result;
            xe6.AppendChild(xe4);
            xe6.AppendChild(xe5);
            xe1.AppendChild(xe6);
            root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadAnalyzerO2Test(AnalyzerO2Test leakdata, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {//socket.Connect(point);
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", leakdata.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", leakdata.namesy);//设置该节点genre属性  
                XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");
                BeginTime.InnerText = leakdata.BeginTime;
                XmlElement STD_RangeO2 = xmldoc.CreateElement("STD_RangeO2");
                STD_RangeO2.InnerText = leakdata.STD_RangeO2;
                XmlElement MEA_RangeO2 = xmldoc.CreateElement("MEA_RangeO2");
                MEA_RangeO2.InnerText = leakdata.MEA_RangeO2;
                XmlElement ERR_RangeO2 = xmldoc.CreateElement("ERR_RangeO2");
                ERR_RangeO2.InnerText = leakdata.ERR_RangeO2;
                XmlElement Result = xmldoc.CreateElement("Result");
                Result.InnerText = leakdata.Result;
                xe6.AppendChild(BeginTime);
                xe6.AppendChild(STD_RangeO2);
                xe6.AppendChild(MEA_RangeO2);
                xe6.AppendChild(ERR_RangeO2);
                xe6.AppendChild(Result);
                xe1.AppendChild(xe6);
                root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        public bool UploadFlowMeterTest(FlowMeterTest leakdata, out string result, out string inf, out DataTable ack)
        {
            result = "";
            inf = "";
            ack = null;
            try
            {//socket.Connect(point);
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                result = "";
                inf = "";
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "Message", "");
                xmlelem.SetAttribute("Device", EISID);
                xmlelem.SetAttribute("OutlookID", leakdata.OutlookID);//设置该节点genre属性
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
                xe1.SetAttribute("Name", leakdata.namesy);//设置该节点genre属性  
                XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");
                BeginTime.InnerText = leakdata.BeginTime;
                XmlElement STD_HRangeO2 = xmldoc.CreateElement("STD_HRangeO2");
                STD_HRangeO2.InnerText = leakdata.STD_HRangeO2;
                XmlElement MEA_HRangeO2 = xmldoc.CreateElement("MEA_HRangeO2");
                MEA_HRangeO2.InnerText = leakdata.MEA_HRangeO2;
                XmlElement ERR_HRangeO2 = xmldoc.CreateElement("ERR_HRangeO2");
                ERR_HRangeO2.InnerText = leakdata.ERR_HRangeO2;
                XmlElement STD_LRangeO2 = xmldoc.CreateElement("STD_LRangeO2");
                STD_LRangeO2.InnerText = leakdata.STD_LRangeO2;
                XmlElement MEA_LRangeO2 = xmldoc.CreateElement("MEA_LRangeO2");
                MEA_LRangeO2.InnerText = leakdata.MEA_LRangeO2;
                XmlElement ERR_LRangeO2 = xmldoc.CreateElement("ERR_LRangeO2");
                ERR_LRangeO2.InnerText = leakdata.ERR_LRangeO2;
                XmlElement Result = xmldoc.CreateElement("Result");
                Result.InnerText = leakdata.Result;
                xe6.AppendChild(BeginTime);
                xe6.AppendChild(STD_HRangeO2);
                xe6.AppendChild(MEA_HRangeO2);
                xe6.AppendChild(ERR_HRangeO2);
                xe6.AppendChild(STD_LRangeO2);
                xe6.AppendChild(MEA_LRangeO2);
                xe6.AppendChild(ERR_LRangeO2);
                xe6.AppendChild(Result);
                xe1.AppendChild(xe6);
                root.AppendChild(xe1);
                string receivedString = webctrlcenter.Request(ConvertXmlToString(xmldoc));
                ini.INIIO.saveSocketLogInf(receivedString);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(receivedString);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                result = ds.Tables["Row"].Rows[0]["Result"].ToString();
                inf = ds.Tables["Row"].Rows[0]["ErrorMessage"].ToString();
                ack = null;

                return true;
            }
            catch (Exception er)
            {
                result = "-1";
                inf = er.Message;
                return false;
            }
        }
        /*
        public void UploadSmokemeterCalRequest(DataTable asmdataseconds, out string result, out string inf)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "SmokemeterCal");//设置该节点genre属性 

            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
                xe34.InnerText = dr["开始时间"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("Nominal");//名义速度
                xe36.InnerText = dr["标准值(%)"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("Check");//速度示值
                xe37.InnerText = dr["实测值(%)"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Result");//0=不合格 1=合格
                xe38.InnerText = (dr["判定"].ToString() == "不合格") ? "0" : "1";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe1.AppendChild(xe33);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }*/
    }
}
