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
    public class NeusoftSocket
    {

        public string EISID = "0000000016";
        HtmlExtractor.Gb2312Encoding encoding = new HtmlExtractor.Gb2312Encoding();
        IPAddress HostIP = IPAddress.Parse("192.168.1.5");
        IPEndPoint point;
        Socket socket;
        bool flag = true;
        Socket acceptedSocket;


        public string receivedString = "";
        public bool receivedFlag = false;
        Thread thread = null;

        public bool receivedflag = false;
        static int sendOutTime = 10;
        static int receiveOutTime = 500;

        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            // int versionindex=xmlString.IndexOf('>');
            //xmlString = xmlString.Remove(0, versionindex + 1);
            sr.Close();
            stream.Close();
            //xmlString = xmlString.Replace(" ", "");
            INIIO.saveSocketLogInf("SEND:" + xmlString);
            string newstring = " /CtrlCenter/ASM?data=" + xmlString.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);
            //byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertTestStringToString(string teststring)
        {
            INIIO.saveSocketLogInf("SEND:" + teststring);
            string newstring = " /CtrlCenter/ASM?data=" + teststring.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);
            //byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        public bool init_equipment(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            try
            {
                point = new IPEndPoint(HostIP, Int32.Parse(port));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                //thread = new Thread(new ThreadStart(Proccess));
                //thread.Start();
                return true;
            }
            catch (Exception ey)
            {
                return false;
            }
        }
        public void close_equipment()
        {
            try
            {
                try
                {
                    thread.Abort();
                }
                catch
                { }
                socket.Close();
            }
            catch
            { }
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送数据</param>
        /// <param name="outTime">发送超时时长，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送成功；-1:超时；-2:出现错误；-3:出现异常</returns>
        public static int SendData(Socket socket, byte[] buffer)
        {
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("参数socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("参数buffer为null ,或者长度为 0");
            }

            int flag = 0;
            try
            {
                int left = buffer.Length;
                int sndLen = 0;
                int hasSend = 0;

                while (true)
                {
                    if ((socket.Poll(sendOutTime * 1000, SelectMode.SelectWrite) == true))
                    {
                        // 收集了足够多的传出数据后开始发送
                        sndLen = socket.Send(buffer, hasSend, left, SocketFlags.None);
                        left -= sndLen;
                        hasSend += sndLen;

                        // 数据已经全部发送
                        if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据部分已经被发送
                            if (sndLen > 0)
                            {
                                continue;
                            }
                            else // 发送数据发生错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        flag = -1;
                        break;
                    }
                }
            }
            catch (SocketException)
            {
                //Log
                flag = -3;
            }
            return flag;
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送的字符串</param>
        /// <param name="outTime">发送数据的超时时间，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送数据成功；-1:超时；-2:错误；-3:异常</returns>
        public static int SendData(Socket socket, string buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null或则长度为0.");
            }
            return SendData(socket, System.Text.Encoding.Default.GetBytes(buffer));
        }
        /// <summary>
        /// 接收远程主机发送的数据
        /// </summary>
        /// <param name="socket">要接收数据且已经连接到远程主机的</param>
        /// <param name="buffer">接收数据的缓冲区(需要接收的数据的长度，由 buffer 的长度决定)</param>
        /// <param name="outTime">接收数据的超时时间，单位秒(指定为-1时，将一直等待直到有数据需要接收)</param>
        /// <returns></returns>
        public static int RecvData(Socket socket, out string receivedMessage)
        {
            byte[] buffer = new byte[50 * 1024];
            receivedMessage = "";
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null ,或者长度为 0");
            }

            buffer.Initialize();
            int left = buffer.Length;
            int curRcv = 0;
            int hasRecv = 0;
            int flag = 0;
            int receiveOutCount = 0;
            try
            {
                while (true)
                {
                    if (socket.Poll(receiveOutTime * 1000, SelectMode.SelectRead) == true)
                    {
                        // 已经有数据等待接收
                        curRcv = socket.Receive(buffer, hasRecv, left, SocketFlags.None);
                        left -= curRcv;
                        hasRecv += curRcv;
                        string s = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer, 0, hasRecv);
                        //string s = Encoding.gbk.GetString(buffer, 0, hasRecv);//将已接收到的转换化字符串，以"/Message"为结束判断
                        // 数据已经全部接收 
                        INIIO.saveSocketLogInf("socket received:" + s);
                        bool isReceiveFinished = (s.Trim()).EndsWith("/Message>");
                        if (isReceiveFinished)
                        {
                            receivedMessage = s;
                            flag = 1;
                            break;
                        }
                        else if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据已经部分接收
                            if (curRcv > 0)
                            {
                                continue;
                            }
                            else  // 出现错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        Thread.Sleep(100);
                        receiveOutCount++;
                        if (receiveOutCount >= receiveOutTime)
                        {
                            flag = -1;
                            break;
                        }
                    }
                }
            }
            catch (SocketException er)
            {
                //Log
                receivedMessage = er.Message;
                flag = -3;
            }
            INIIO.saveSocketLogInf("RECEIVE:" + receivedMessage);
            return flag;
        }
        public static void ReadDatatimeString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[2];
            result = dt1.Rows[0]["DateTime"].ToString();
            info = dt1.Rows[0][0].ToString();
        }
        public static void ReadDatatimeStringV21(string xmlstring,out string driverNameList, out string result, out string info)
        {
            driverNameList ="";
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[2];
            result = dt1.Rows[0]["DateTime"].ToString();
            info = dt1.Rows[0][0].ToString();
            driverNameList = dt1.Rows[1]["DriverUser"].ToString();
        }
        public static void ReadLoginUserString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[2];
            result = dt1.Rows[0]["Result"].ToString();
            info = dt1.Rows[0]["ErrorMessage"].ToString();
        }
        public static void ReadACKString(string xmlstring, out string result, out string info)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[2];
            result = dt1.Rows[0]["Result"].ToString();
            info = dt1.Rows[0]["ErrorMessage"].ToString();
        }
        public static DataTable ReadVehicleList(string xmlstring)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;

            dt1 = ds.Tables[1];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "Verify")
            {
                return null;
            }
            else
            {
                if (ds.Tables.Contains("Vehicle"))
                {
                    dt1 = ds.Tables["Vehicle"];
                    return dt1;
                }
                else
                    return null;
            }
        }
        public static DataTable ReadUsersList(string xmlstring)
        {
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = null;

            dt1 = ds.Tables[1];
            string respondName = dt1.Rows[0]["Name"].ToString();
            if (respondName == "GetUsers")
            {
                return null;
            }
            else
            {
                if (ds.Tables.Contains("User"))
                {
                    dt1 = ds.Tables["User"];
                    return dt1;
                }
                else
                    return null;
            }
        }
        //private void Proccess()
        //{
        //    if (socket.Connected)
        //    {
        //        while (flag)
        //        {
        //            //Thread.Sleep(10);
        //            byte[] buffer = new byte[10 * 1024];
        //            int n = socket.Receive(buffer);
        //            string s = Encoding.UTF8.GetString(buffer, 0, n);
        //            //s = s.Remove(0, 1);
        //            receivedString = s;//.Remove(s.Length - 1, 1);
        //            receivedflag = true;
        //            while (receivedflag) Thread.Sleep(10);

        //        }
        //    }
        //}
        public string SendTestXmlString(string testString)
        {
            if (SendData(socket, ConvertTestStringToString(testString)) < 0)
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:CLIENT:\r\n") + "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:SERVER:\r\n") + receivedString;
            }
            else
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:SERVER:\r\n") + "no ACK";
            }
        }
        public string GetTimeRequest()
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
            xe1.SetAttribute("Name", "GetTime");//设置该节点genre属性             
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                string info;
                ReadDatatimeString(receivedString, out datetimestring, out info);
                return datetimestring;
            }
            else
            {
                return "no ACK";
            }
        }
        public string GetTimeRequestV21(out string driverNamestring)
        {
            //socket.Connect(point);
            driverNamestring = "";
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
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                string info;
                ReadDatatimeStringV21(receivedString,out driverNamestring, out datetimestring, out info);
                return datetimestring;
            }
            else
            {
                return "no ACK";
            }
        }
        public DataTable GetVehicleList()
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
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadVehicleList(receivedString);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public DataTable GetUsers()
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
            xe1.SetAttribute("Name", "GetUsers");//设置该节点genre属性             
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadUsersList(receivedString);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public string VerifyRequest(EISVerify verifymodule)
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
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return receivedString;
            }
            else
            {
                return "no ACK";
            }
        }
        public string VehicleRequest(VehicleInfo vehicleinfmodule)
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
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return receivedString;
            }
            else
            {
                return "no ACK";
            }
        }
        public DataSet VehicleRequest(string vehicleplate, string licenseType, string vin, out string result, out string errorMessage, out string outlookID)
        {
            DataSet dt = null;
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errorMessage = "";
            outlookID = "";
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
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return null;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadVehicleInf(receivedString, out result, out errorMessage, out outlookID);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public static DataSet ReadVehicleInf(string xmlstring, out string result, out string errorMessage, out string outlookID)
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
        }
        public static DataTable ReadVmasResult(string xmlstring, out string result, out string errorMessage)
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
                    result = dt1.Rows[0]["Result"].ToString();
                    errorMessage = dt1.Rows[0]["ErrorMessage"].ToString();
                    if (result == "-1")
                        dt1 = null;
                    return dt1;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable ReadUsers(string xmlstring, out string result, out string errorMessage)
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
                    dt1 = ds.Tables["User"];
                    return dt1;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void ReadCalibration(string xmlstring, out string result, out string errorMessage)
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
        public DataTable readUsers( out string result, out string errorMessage)
        {
            result = "";
            errorMessage = "";
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
                xe1.SetAttribute("Name", "GetUsers");//设置该节点genre属性             
                root.AppendChild(xe1);
                //socket.Send(ConvertXmlToString(xmldoc));
                if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    errorMessage = "发送失败";
                    return null;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataTable dt = ReadUsers(receivedString, out result, out errorMessage);
                    return dt;
                }
                else
                {
                    result = "-1";
                    errorMessage = "无返回数据";
                    return null;
                }
            }
            catch(Exception er)
            {
                result = "-1";
                errorMessage = "异常:"+er.Message;
                return null;
            }
        }
        #region 福建登录
        public string loginUserFj(string czyname, string czypassword, string logintype, string ycyname, string ycypassword)
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
            XmlElement xe6 = xmldoc.CreateElement("User2");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                string info;
                ReadLoginUserString(receivedString, out datetimestring, out info);
                return datetimestring;
            }
            else
            {
                return "no ACK";
            }
        }
        #endregion
        #region
        public string loginUserYn(string czyname, string czypassword, string logintype, string ycyname)
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
            XmlElement xe6 = xmldoc.CreateElement("DriverUser");
            xe6.InnerText = ycyname;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                string info;
                ReadLoginUserString(receivedString, out datetimestring, out info);
                return datetimestring;
            }
            else
            {
                return "no ACK";
            }
        }
        #endregion
        #region 山东登录
        public string loginUser(string czyname, string czypassword, string logintype, string ycyname, string ycypassword)
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
            XmlElement xe6 = xmldoc.CreateElement("DriverUser");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                string info;
                ReadLoginUserString(receivedString, out datetimestring, out info);
                return datetimestring;
            }
            else
            {
                return "no ACK";
            }
        }
        #endregion
        #region 山东标定登录
        //如果成功，dt返回为标定限值
        //result 0：该用户不存在
        //result 1：该用户无此操作权限
        //result -1：服务器故障

        public DataTable loginUserCalibration(string czyname, string czypassword, string logintype, string ycyname, string ycypassword, out string result, out string inf)
        {
            //socket.Connect(point);
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
            xe1.SetAttribute("Name", "Verify");//设置该节点genre属性 

            XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe3 = xmldoc.CreateElement("User");
            xe3.InnerText = czyname;
            XmlElement xe4 = xmldoc.CreateElement("Pwd");
            xe4.InnerText = czypassword;
            XmlElement xe5 = xmldoc.CreateElement("LoginType");
            xe5.InnerText = logintype;
            XmlElement xe6 = xmldoc.CreateElement("DriverUser");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadCalStandard(receivedString, out result, out inf);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public DataTable loginUserCalibrationV202(string czyname, string czypassword, string logintype, string ycyname, string ycypassword, out string result, out string inf)
        {
            //socket.Connect(point);
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
            xe1.SetAttribute("Name", "Verify");//设置该节点genre属性 

            XmlElement xe2 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe3 = xmldoc.CreateElement("User");
            xe3.InnerText = czyname;
            XmlElement xe4 = xmldoc.CreateElement("Pwd");
            xe4.InnerText = czypassword;
            XmlElement xe5 = xmldoc.CreateElement("LoginType");
            xe5.InnerText = logintype;
            XmlElement xe6 = xmldoc.CreateElement("User2");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadCalStandard(receivedString, out result, out inf);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        #endregion

        #region V3.0
        public bool loginUserv301(string czyname, string czypassword, string logintype, string ycyname, string ycypassword,out string result,out string info)
        {
            //socket.Connect(point);
            result = "1";
            info = "";
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
            XmlElement xe6 = xmldoc.CreateElement("User2");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string datetimestring;
                ReadLoginUserString(receivedString, out result, out info);
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable loginUserCalibrationv301(string czyname, string czypassword, string logintype, string ycyname, string ycypassword, out string result, out string inf)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            result = "1";
            inf = "";
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
            XmlElement xe6 = xmldoc.CreateElement("User2");
            xe6.InnerText = ycyname;
            XmlElement xe7 = xmldoc.CreateElement("Pwd2");
            xe7.InnerText = ycypassword;
            xe2.AppendChild(xe3);
            xe2.AppendChild(xe4);
            xe2.AppendChild(xe5);
            xe2.AppendChild(xe6);
            xe2.AppendChild(xe7);
            xe1.AppendChild(xe2);
            root.AppendChild(xe1);

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadCalStandard(receivedString, out result, out inf);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        #endregion
        #region 福建标定登录
        //如果成功，dt返回为标定限值
        //result 0：该用户不存在
        //result 1：该用户无此操作权限
        //result -1：服务器故障

        public DataTable loginUserCalibrationFj(string czyname, string czypassword, string logintype, out string result, out string inf)
        {
            //socket.Connect(point);
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

            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {

                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                dt = ReadCalStandard(receivedString, out result, out inf);
                return dt;
            }
            else
            {
                return dt;
            }
        }
        #endregion
        public string SendTestStatus(string outlookID, string statusName, out string result, out string errorMessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errorMessage = "";
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
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadACKString(receivedString, out result, out errorMessage);
                return result;
            }
            else
            {
                return "no ACK";
            }
        }
        public string Testing5025Request(Testing5025 Testing5025Module)
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
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return receivedString;
            }
            else
            {
                return "no ACK";
            }
        }

        public DataTable UploadGasolineResultRequest(UploadGasolineResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string errormessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errormessage = "";
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
            XmlElement xe32 = xmldoc.CreateElement("AdjustZero");
            xe32.InnerText = gasolineresultmodule.AdjustZero;
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
            xe3.AppendChild(xe32);

            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);

            if (asmdataseconds != null)
            {
                XmlElement xe50 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                for (int i = 1; i < asmdataseconds.Rows.Count; i++)
                {
                    XmlElement xe51 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = asmdataseconds.Rows[i];
                    XmlElement xe52 = xmldoc.CreateElement("TimeCount");
                    xe52.InnerText =(i-1).ToString();
                    XmlElement xe53 = xmldoc.CreateElement("DataType");
                    xe53.InnerText = dr["时序类别"].ToString()=="1"?"0":(dr["时序类别"].ToString() == "2" ? "1":"3");
                    XmlElement xe54 = xmldoc.CreateElement("Velocity");
                    xe54.InnerText = dr["实时车速"].ToString();
                    XmlElement xe55 = xmldoc.CreateElement("Rev");
                    xe55.InnerText = dr["转速"].ToString();
                    XmlElement xe56 = xmldoc.CreateElement("Power");
                    xe56.InnerText = dr["加载功率"].ToString();
                    XmlElement xe57 = xmldoc.CreateElement("CO");
                    xe57.InnerText = dr["CO实时值"].ToString();
                    XmlElement xe58 = xmldoc.CreateElement("CO2");
                    xe58.InnerText = dr["CO2实时值"].ToString();
                    XmlElement xe59 = xmldoc.CreateElement("HC");
                    xe59.InnerText = dr["HC实时值"].ToString();
                    XmlElement xe60 = xmldoc.CreateElement("NO");
                    xe60.InnerText = dr["NO实时值"].ToString();
                    XmlElement xe61 = xmldoc.CreateElement("O2");
                    xe61.InnerText = dr["O2实时值"].ToString();
                    XmlElement xe62 = xmldoc.CreateElement("Force");
                    xe62.InnerText = dr["扭力"].ToString();
                    XmlElement xe63 = xmldoc.CreateElement("DynamometerLoad");
                    xe63.InnerText = "907";
                    XmlElement xe64 = xmldoc.CreateElement("LowFlowFlag");
                    xe64.InnerText = "0";
                    xe51.AppendChild(xe52);
                    xe51.AppendChild(xe53);
                    xe51.AppendChild(xe54);
                    xe51.AppendChild(xe55);
                    xe51.AppendChild(xe56);
                    xe51.AppendChild(xe57);
                    xe51.AppendChild(xe58);
                    xe51.AppendChild(xe59);
                    xe51.AppendChild(xe60);
                    xe51.AppendChild(xe61);
                    xe51.AppendChild(xe62);
                    xe51.AppendChild(xe63);
                    xe51.AppendChild(xe64);

                    xe50.AppendChild(xe51);
                }
                xe1.AppendChild(xe50);
            }
            else
            {
                XmlElement xe50 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                XmlElement xe51 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe52 = xmldoc.CreateElement("TimeCount");
                xe52.InnerText = "";
                XmlElement xe53 = xmldoc.CreateElement("DataType");
                xe53.InnerText = "";
                XmlElement xe54 = xmldoc.CreateElement("Velocity");
                xe54.InnerText = "";
                XmlElement xe55 = xmldoc.CreateElement("Rev");
                xe55.InnerText = "";
                XmlElement xe56 = xmldoc.CreateElement("Power");
                xe56.InnerText = "";
                XmlElement xe57 = xmldoc.CreateElement("CO");
                xe57.InnerText = "";
                XmlElement xe58 = xmldoc.CreateElement("CO2");
                xe58.InnerText = "";
                XmlElement xe59 = xmldoc.CreateElement("HC");
                xe59.InnerText = "";
                XmlElement xe60 = xmldoc.CreateElement("NO");
                xe60.InnerText = "";
                XmlElement xe61 = xmldoc.CreateElement("O2");
                xe61.InnerText = "";
                XmlElement xe62 = xmldoc.CreateElement("Force");
                xe62.InnerText = "";
                XmlElement xe63 = xmldoc.CreateElement("DynamometerLoad");
                xe63.InnerText = "";
                XmlElement xe64 = xmldoc.CreateElement("LowFlowFlag");
                xe64.InnerText = "";
                xe51.AppendChild(xe52);
                xe51.AppendChild(xe53);
                xe51.AppendChild(xe54);
                xe51.AppendChild(xe55);
                xe51.AppendChild(xe56);
                xe51.AppendChild(xe57);
                xe51.AppendChild(xe58);
                xe51.AppendChild(xe59);
                xe51.AppendChild(xe60);
                xe51.AppendChild(xe61);
                xe51.AppendChild(xe62);
                xe51.AppendChild(xe63);
                xe51.AppendChild(xe64);

                xe50.AppendChild(xe51);
                xe1.AppendChild(xe50);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                if (gasolineresultmodule.Result != "2")
                {
                    result = "";
                    errormessage = "";
                    dt = ReadVmasResult(receivedString, out result, out errormessage);
                    return dt;
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public DataTable UploadVmasResultRequest(UploadVmasResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string errormessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errormessage = "";
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
            XmlElement xe20 = xmldoc.CreateElement("AdjustZero");
            xe20.InnerText = gasolineresultmodule.AdjustZero;
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
            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);

            if (asmdataseconds != null)
            {
                XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
                for (int i = asmdataseconds.Rows.Count-195; i < asmdataseconds.Rows.Count; i++)
                {
                    XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                    DataRow dr = asmdataseconds.Rows[i];
                    XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                    xe34.InnerText = (i-(asmdataseconds.Rows.Count - 195)).ToString();
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
                    xe47.InnerText = dr["实际体积流量"].ToString();
                    XmlElement xe48 = xmldoc.CreateElement("StandardMPH");
                    xe48.InnerText = dr["标准时速"].ToString();
                    XmlElement xe49 = xmldoc.CreateElement("Force");
                    xe49.InnerText = dr["扭矩"].ToString();
                    XmlElement xe50 = xmldoc.CreateElement("Temperature");
                    xe50.InnerText = dr["环境温度"].ToString();
                    XmlElement xe51 = xmldoc.CreateElement("Humidit");
                    xe51.InnerText = dr["相对湿度"].ToString();
                    XmlElement xe52 = xmldoc.CreateElement("AirPressure");
                    xe52.InnerText = dr["大气压力"].ToString();
                    XmlElement xe53 = xmldoc.CreateElement("FlowTemperature");
                    xe53.InnerText = dr["流量计温度"].ToString();
                    XmlElement xe54 = xmldoc.CreateElement("VolumeFlow");
                    xe54.InnerText = dr["实际体积流量"].ToString();
                    XmlElement xe55 = xmldoc.CreateElement("StandardVolumeFlow");
                    xe55.InnerText = dr["标准体积流量"].ToString();
                    XmlElement xe56 = xmldoc.CreateElement("HumCoefficient");
                    xe56.InnerText = dr["湿度修正系数"].ToString();
                    XmlElement xe57 = xmldoc.CreateElement("DilutionCoefficient");
                    xe57.InnerText = dr["稀释修正系数"].ToString();
                    XmlElement xe58 = xmldoc.CreateElement("DilutionProportion");
                    xe58.InnerText = dr["稀释比"].ToString();
                    XmlElement xe59 = xmldoc.CreateElement("AnalyzerPressure");
                    xe59.InnerText = dr["分析仪管路压力"].ToString();
                    XmlElement xe60 = xmldoc.CreateElement("TestFlow");
                    xe60.InnerText = dr["尾气实际排放流量"].ToString();
                    XmlElement xe61 = xmldoc.CreateElement("LowFlowFlag");
                    xe61.InnerText = "0";
                    XmlElement xe62 = xmldoc.CreateElement("FlowPressure");
                    xe62.InnerText = dr["流量计压力"].ToString();
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
                    xe33.AppendChild(xe61);
                    xe33.AppendChild(xe62);
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
                XmlElement xe48 = xmldoc.CreateElement("StandardMPH");
                xe48.InnerText = "";
                XmlElement xe49 = xmldoc.CreateElement("Force");
                xe49.InnerText = "";
                XmlElement xe50 = xmldoc.CreateElement("Temperature");
                xe50.InnerText = "";
                XmlElement xe51 = xmldoc.CreateElement("Humidit");
                xe51.InnerText = "";
                XmlElement xe52 = xmldoc.CreateElement("AirPressure");
                xe52.InnerText = "";
                XmlElement xe53 = xmldoc.CreateElement("FlowTemperature");
                xe53.InnerText = "";
                XmlElement xe54 = xmldoc.CreateElement("VolumeFlow");
                xe54.InnerText = "";
                XmlElement xe55 = xmldoc.CreateElement("StandardVolumeFlow");
                xe55.InnerText = "";
                XmlElement xe56 = xmldoc.CreateElement("HumCoefficient");
                xe56.InnerText = "";
                XmlElement xe57 = xmldoc.CreateElement("DilutionCoefficient");
                xe57.InnerText = "";
                XmlElement xe58 = xmldoc.CreateElement("DilutionProportion");
                xe58.InnerText = "";
                XmlElement xe59 = xmldoc.CreateElement("AnalyzerPressure");
                xe59.InnerText = "";
                XmlElement xe60 = xmldoc.CreateElement("TestFlow");
                xe60.InnerText = "";
                XmlElement xe61 = xmldoc.CreateElement("LowFlowFlag");
                xe61.InnerText = "";
                XmlElement xe62 = xmldoc.CreateElement("FlowPressure");
                xe62.InnerText = "";
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
                xe33.AppendChild(xe61);
                xe33.AppendChild(xe62);
                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                if (gasolineresultmodule.Result != "2")
                {
                    result = "";
                    errormessage = "";
                    dt = ReadVmasResult(receivedString, out result, out errormessage);
                    return dt;
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }

        public DataTable UploadDieselResultRequest(UploadDieselResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string errormessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errormessage = "";
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
            if(gasolineresultmodule.K100=="")
                xe7.InnerText = "-1";
            else
                xe7.InnerText = gasolineresultmodule.K100;

            XmlElement xe8 = xmldoc.CreateElement("K90");
            if (gasolineresultmodule.K90 == "")
                xe8.InnerText = "-1";
            else
                xe8.InnerText = gasolineresultmodule.K90;
            //xe8.InnerText = gasolineresultmodule.K90;
            XmlElement xe9 = xmldoc.CreateElement("K80");
            if (gasolineresultmodule.K80 == "")
                xe9.InnerText = "-1";
            else
                xe9.InnerText = gasolineresultmodule.K80;
           // xe9.InnerText = gasolineresultmodule.K80;
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
                    xe34.InnerText = (i-1).ToString();
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
                    XmlElement xe40 = xmldoc.CreateElement("Force");
                    xe40.InnerText = dr["扭力"].ToString();
                    XmlElement xe41 = xmldoc.CreateElement("LowFlowFlag");
                    xe41.InnerText = "0";
                    xe33.AppendChild(xe34);
                    xe33.AppendChild(xe35);
                    xe33.AppendChild(xe36);
                    xe33.AppendChild(xe37);
                    xe33.AppendChild(xe38);
                    xe33.AppendChild(xe39);
                    xe33.AppendChild(xe40);
                    xe33.AppendChild(xe41);
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
                XmlElement xe40 = xmldoc.CreateElement("Force");
                xe40.InnerText = "";
                XmlElement xe41 = xmldoc.CreateElement("LowFlowFlag");
                xe41.InnerText = "";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe35);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe39);
                xe33.AppendChild(xe40);
                xe33.AppendChild(xe41);
                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                if (gasolineresultmodule.Result != "2")
                {
                    result = "";
                    errormessage = "";
                    dt = ReadVmasResult(receivedString, out result, out errormessage);
                    return dt;
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public DataTable UploadDIdleResultRequest(UploadDIdleResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string errormessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errormessage = "";
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
            XmlElement xe15 = xmldoc.CreateElement("IdleReason");
            xe15.InnerText = gasolineresultmodule.IdleReason;
            XmlElement xe16 = xmldoc.CreateElement("LowRev");
            xe16.InnerText = gasolineresultmodule.LowIdleRev;
            XmlElement xe17 = xmldoc.CreateElement("HighRev");
            xe17.InnerText = gasolineresultmodule.HighIdleRev;
            XmlElement xe18 = xmldoc.CreateElement("AdjustZero");
            xe18.InnerText = gasolineresultmodule.AdjustZero;
            XmlElement xe19 = xmldoc.CreateElement("LowIdleRev");
            xe19.InnerText = gasolineresultmodule.LowIdleRev;
            XmlElement xe20 = xmldoc.CreateElement("HighIdleRev");
            xe20.InnerText = gasolineresultmodule.HighIdleRev;
            XmlElement xe21 = xmldoc.CreateElement("OilTemperature");
            xe21.InnerText = gasolineresultmodule.OilTemperature;
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
                        xe34.InnerText =(i-1).ToString();
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
                        XmlElement xe43 = xmldoc.CreateElement("CO2");
                        xe43.InnerText = dr["CO2"].ToString();
                        XmlElement xe44 = xmldoc.CreateElement("LowFlowFlag");
                        xe44.InnerText ="0";
                        XmlElement xe45 = xmldoc.CreateElement("O2");
                        xe45.InnerText = dr["O2"].ToString();
                        xe33.AppendChild(xe34);
                        xe33.AppendChild(xe35);
                        xe33.AppendChild(xe37);
                        xe33.AppendChild(xe39);
                        xe33.AppendChild(xe41);
                        xe33.AppendChild(xe42);
                        xe33.AppendChild(xe43);
                        xe33.AppendChild(xe44);
                        xe33.AppendChild(xe45);
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
                XmlElement xe43 = xmldoc.CreateElement("CO2");
                xe43.InnerText = "";
                XmlElement xe44 = xmldoc.CreateElement("LowFlowFlag");
                xe44.InnerText = "";
                XmlElement xe45 = xmldoc.CreateElement("O2");
                xe45.InnerText = "";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe35);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe39);
                xe33.AppendChild(xe41);
                xe33.AppendChild(xe42);
                xe33.AppendChild(xe43);
                xe33.AppendChild(xe44);
                xe33.AppendChild(xe45);

                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                if (gasolineresultmodule.Result != "2")
                {
                    result = "";
                    errormessage = "";
                    dt = ReadVmasResult(receivedString, out result, out errormessage);
                    return dt;
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public DataTable UploadDieselFAResultRequest(UploadDieselFAResult gasolineresultmodule, DataTable asmdataseconds, out string result, out string errormessage)
        {
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            errormessage = "";
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
            XmlElement xe15 = xmldoc.CreateElement("Rev1");
            xe15.InnerText = gasolineresultmodule.Rev1;
            XmlElement xe16 = xmldoc.CreateElement("Rev2");
            xe16.InnerText = gasolineresultmodule.Rev2;
            XmlElement xe17 = xmldoc.CreateElement("Rev3");
            xe17.InnerText = gasolineresultmodule.Rev3;
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
                    xe34.InnerText =(i-1).ToString();//时间计数，从0开始，每100ms递增1
                    XmlElement xe37 = xmldoc.CreateElement("IdleRev");
                    xe37.InnerText = dr["发动机转速"].ToString();
                    XmlElement xe38 = xmldoc.CreateElement("Rev");
                    xe38.InnerText = dr["发动机转速"].ToString();
                    XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                    xe39.InnerText = dr["烟度值读数"].ToString();
                    XmlElement xe40 = xmldoc.CreateElement("LowFlowFlag");
                    xe40.InnerText = "0";
                    xe33.AppendChild(xe34);
                    xe33.AppendChild(xe37);
                    xe33.AppendChild(xe38);
                    xe33.AppendChild(xe39);
                    xe33.AppendChild(xe40);

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
                XmlElement xe38 = xmldoc.CreateElement("Rev");
                xe38.InnerText = "";
                XmlElement xe39 = xmldoc.CreateElement("SmokeK");
                xe39.InnerText = "";
                XmlElement xe40 = xmldoc.CreateElement("LowFlowFlag");
                xe40.InnerText = "";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe39);
                xe33.AppendChild(xe40);

                xe32.AppendChild(xe33);
                xe1.AppendChild(xe32);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return dt;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                if (gasolineresultmodule.Result != "2")
                {
                    result = "";
                    errormessage = "";
                    dt = ReadVmasResult(receivedString, out result, out errormessage);
                    return dt;
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public string StatusRequest(Status statusModule)
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
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return "Send Failure";
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                return receivedString;
            }
            else
            {
                return "no ACK";
            }
        }
        public static DataTable ReadCalStandard(string xmlstring, out string result, out string errorMessage)
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
                result = "1";
                errorMessage = "";
                dt1 = ds.Tables[2];
                return dt1;
            }
        }
        public void UploadCoastdownRequest(Coastdown gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf)
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
            XmlElement xe5 = xmldoc.CreateElement("ACDT40");
            xe5.InnerText = gasolineresultmodule.ACDT40;
            XmlElement xe6 = xmldoc.CreateElement("ACDT24");
            xe6.InnerText = gasolineresultmodule.ACDT24;
            XmlElement xe7 = xmldoc.CreateElement("PLHP40");
            xe7.InnerText = gasolineresultmodule.PLHP40;
            XmlElement xe8 = xmldoc.CreateElement("PLHP24");
            xe8.InnerText = gasolineresultmodule.PLHP24;
            XmlElement xe9 = xmldoc.CreateElement("CCDT40");
            xe9.InnerText = gasolineresultmodule.CCDT40;
            XmlElement xe10 = xmldoc.CreateElement("CCDT24");
            xe10.InnerText = gasolineresultmodule.CCDT24;
            XmlElement xe11 = xmldoc.CreateElement("IHP40");
            xe11.InnerText = gasolineresultmodule.IHP40;
            XmlElement xe12 = xmldoc.CreateElement("IHP24");
            xe12.InnerText = gasolineresultmodule.IHP24;
            XmlElement xe13 = xmldoc.CreateElement("DIW");
            xe13.InnerText = gasolineresultmodule.DIW;
            XmlElement xe14 = xmldoc.CreateElement("Result40");
            xe14.InnerText = gasolineresultmodule.Result40;
            XmlElement xe15 = xmldoc.CreateElement("Result24");
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


            XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                xe34.InnerText = dr["TimeCount"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("Velocity");
                xe36.InnerText = dr["Velocity"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("Torque");
                xe37.InnerText = dr["Torque"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Power");
                xe38.InnerText = dr["Power"].ToString();
                XmlElement xe39 = xmldoc.CreateElement("Force");
                xe39.InnerText = dr["Force"].ToString();//轮边力
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe39);
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
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadParasiticLoseRequest(ParasiticLose gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf)
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
            XmlElement xe5 = xmldoc.CreateElement("ACDT40");
            xe5.InnerText = gasolineresultmodule.ACDT40;
            XmlElement xe6 = xmldoc.CreateElement("ACDT24");
            xe6.InnerText = gasolineresultmodule.ACDT24;
            XmlElement xe7 = xmldoc.CreateElement("PLHP40");
            xe7.InnerText = gasolineresultmodule.PLHP40;
            XmlElement xe8 = xmldoc.CreateElement("PLHP24");
            xe8.InnerText = gasolineresultmodule.PLHP24;
            XmlElement xe13 = xmldoc.CreateElement("DIW");
            xe13.InnerText = gasolineresultmodule.DIW;
            xe3.AppendChild(xe4);
            xe3.AppendChild(xe5);
            xe3.AppendChild(xe6);
            xe3.AppendChild(xe7);
            xe3.AppendChild(xe8);
            xe3.AppendChild(xe13);

            xe2.AppendChild(xe3);
            xe1.AppendChild(xe2);


            XmlElement xe32 = xmldoc.CreateElement("ProcessData");//创建一个<Node>节点 
            for (int i = 1; i < asmdataseconds.Rows.Count; i++)
            {
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                DataRow dr = asmdataseconds.Rows[i];
                XmlElement xe34 = xmldoc.CreateElement("TimeCount");
                xe34.InnerText = dr["TimeCount"].ToString();
                XmlElement xe36 = xmldoc.CreateElement("Velocity");
                xe36.InnerText = dr["Velocity"].ToString();
                XmlElement xe37 = xmldoc.CreateElement("Torque");
                xe37.InnerText = dr["Torque"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Power");
                xe38.InnerText = dr["Power"].ToString();
                XmlElement xe39 = xmldoc.CreateElement("Force");
                xe39.InnerText = dr["Force"].ToString();//轮边力
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe39);
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
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadTorqueCalRequest(DataTable asmdataseconds, out string result, out string inf)
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
            byte[] buffer = new byte[10 * 1024];
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
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadAnalyzerCalCheckRequest(AnalyzerCalCheck gasolineresultmodule, DataTable asmdataseconds, out string result, out string inf)
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
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadAnalyzerLeakTestRequest(AnalyzerLeakTest leakdata, out string result, out string inf)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "AnalyzerLeakTest");//设置该节点genre属性  
            XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe4 = xmldoc.CreateElement("StartTime");
            xe4.InnerText = leakdata.StartTime;
            XmlElement xe5 = xmldoc.CreateElement("Result");
            xe5.InnerText = leakdata.Result;
            xe6.AppendChild(xe4);
            xe6.AppendChild(xe5);
            xe1.AppendChild(xe6);
            root.AppendChild(xe1);
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadAnalyzerO2RangeCheck(AnalyzerO2RangeCheck leakdata, out string result, out string inf)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "AnalyzerO2RangeCheck");//设置该节点genre属性  
            XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement jcrq = xmldoc.CreateElement("jcrq");
            jcrq.InnerText = leakdata.jcrq;
            XmlElement jckssj = xmldoc.CreateElement("jckssj");
            jckssj.InnerText = leakdata.jckssj;
            XmlElement o2lcbz = xmldoc.CreateElement("o2lcbz");
            o2lcbz.InnerText = leakdata.o2lcbz;
            XmlElement o2lcclz = xmldoc.CreateElement("o2lcclz");
            o2lcclz.InnerText = leakdata.o2lcclz;
            XmlElement o2lcwc = xmldoc.CreateElement("o2lcwc");
            o2lcwc.InnerText = leakdata.o2lcwc;
            XmlElement jcjg = xmldoc.CreateElement("jcjg");
            jcjg.InnerText = leakdata.jcjg;
            xe6.AppendChild(jcrq);
            xe6.AppendChild(jckssj);
            xe6.AppendChild(o2lcbz);
            xe6.AppendChild(o2lcclz);
            xe6.AppendChild(o2lcwc);
            xe6.AppendChild(jcjg);
            xe1.AppendChild(xe6);
            root.AppendChild(xe1);
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadLowStandardGasCheck(LowStandardGasCheck leakdata, out string result, out string inf)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "LowStandardGasCheck");//设置该节点genre属性  
            XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement jcrq = xmldoc.CreateElement("jcrq");
            jcrq.InnerText = leakdata.jcrq;
            XmlElement jckssj = xmldoc.CreateElement("jckssj");
            jckssj.InnerText = leakdata.jckssj;
            XmlElement c3h8nd = xmldoc.CreateElement("c3h8nd");
            c3h8nd.InnerText = leakdata.c3h8nd;
            XmlElement cond = xmldoc.CreateElement("cond");
            cond.InnerText = leakdata.cond;
            XmlElement co2nd = xmldoc.CreateElement("co2nd");
            co2nd.InnerText = leakdata.co2nd;
            XmlElement nond = xmldoc.CreateElement("nond");
            nond.InnerText = leakdata.nond;
            XmlElement o2nd = xmldoc.CreateElement("o2nd");
            o2nd.InnerText = leakdata.o2nd;
            XmlElement hcjcz = xmldoc.CreateElement("hcjcz");
            hcjcz.InnerText = leakdata.hcjcz;
            XmlElement cojcz = xmldoc.CreateElement("cojcz");
            cojcz.InnerText = leakdata.cojcz;
            XmlElement co2jcz = xmldoc.CreateElement("co2jcz");
            co2jcz.InnerText = leakdata.co2jcz;
            XmlElement nojcz = xmldoc.CreateElement("nojcz");
            nojcz.InnerText = leakdata.nojcz;
            XmlElement o2jcz = xmldoc.CreateElement("o2jcz");
            o2jcz.InnerText = leakdata.o2jcz;
            XmlElement pef = xmldoc.CreateElement("pef");
            pef.InnerText = leakdata.pef;
            XmlElement jcjg = xmldoc.CreateElement("jcjg");
            jcjg.InnerText = leakdata.jcjg;
            xe6.AppendChild(jcrq);
            xe6.AppendChild(jckssj);
            xe6.AppendChild(c3h8nd);
            xe6.AppendChild(cond);
            xe6.AppendChild(co2nd);
            xe6.AppendChild(nond);
            xe6.AppendChild(o2nd);
            xe6.AppendChild(hcjcz);
            xe6.AppendChild(cojcz);
            xe6.AppendChild(co2jcz);
            xe6.AppendChild(nojcz);
            xe6.AppendChild(o2jcz);
            xe6.AppendChild(pef);
            xe6.AppendChild(jcjg);
            xe1.AppendChild(xe6);
            root.AppendChild(xe1);
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadFlowO2Cal(FlowO2Cal leakdata, out string result, out string inf)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            result = "";
            inf = "";
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Message", "");
            xmlelem.SetAttribute("Device", EISID);
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Message");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Request");//创建一个<Node>节点 
            xe1.SetAttribute("Name", "FlowO2Cal");//设置该节点genre属性  
            XmlElement xe6 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement StartTime = xmldoc.CreateElement("StartTime");
            StartTime.InnerText = leakdata.StartTime;
            XmlElement O2HStandard = xmldoc.CreateElement("O2HStandard");
            O2HStandard.InnerText = leakdata.O2HStandard;
            XmlElement O2HMeasure = xmldoc.CreateElement("O2HMeasure");
            O2HMeasure.InnerText = leakdata.O2HMeasure;
            XmlElement O2HAccuracy = xmldoc.CreateElement("O2HAccuracy");
            O2HAccuracy.InnerText = leakdata.O2HAccuracy;
            XmlElement O2LStandard = xmldoc.CreateElement("O2LStandard");
            O2LStandard.InnerText = leakdata.O2LStandard;
            XmlElement O2LMeasure = xmldoc.CreateElement("O2LMeasure");
            O2LMeasure.InnerText = leakdata.O2LMeasure;
            XmlElement O2LAccuracy = xmldoc.CreateElement("O2LAccuracy");
            O2LAccuracy.InnerText = leakdata.O2LAccuracy;
            XmlElement Result = xmldoc.CreateElement("Result");
            Result.InnerText = leakdata.Result;
            xe6.AppendChild(StartTime);
            xe6.AppendChild(O2HStandard);
            xe6.AppendChild(O2HMeasure);
            xe6.AppendChild(O2HAccuracy);
            xe6.AppendChild(O2LStandard);
            xe6.AppendChild(O2LMeasure);
            xe6.AppendChild(O2LAccuracy);
            xe6.AppendChild(Result);
            xe1.AppendChild(xe6);
            root.AppendChild(xe1);
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
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
                XmlElement xe41 = xmldoc.CreateElement("Check1");//速度示值
                xe41.InnerText = dr["实测值(%)"].ToString();//扭矩
                XmlElement xe42 = xmldoc.CreateElement("Check2");//速度示值
                xe42.InnerText = dr["实测值(%)"].ToString();//扭矩
                XmlElement xe43 = xmldoc.CreateElement("Check3");//速度示值
                xe43.InnerText = dr["实测值(%)"].ToString();//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Result");//0=不合格 1=合格
                xe38.InnerText = (dr["判定"].ToString() == "不合格") ? "0" : "1";
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe41);
                xe33.AppendChild(xe42);
                xe33.AppendChild(xe43);
                xe1.AppendChild(xe33);
            }

            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }*/
        public void UploadSmokemeterCalRequest(UploadSmokemeterCal smokedata, out string result, out string inf)
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
                XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
                XmlElement xe34 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
                xe34.InnerText = smokedata.StartTime;
                XmlElement xe36 = xmldoc.CreateElement("Nominal");//名义速度
                xe36.InnerText =smokedata.Nominal;
                XmlElement xe37 = xmldoc.CreateElement("Check");//速度示值
                xe37.InnerText = smokedata.Check;//扭矩
                XmlElement xe41 = xmldoc.CreateElement("Check1");//速度示值
                xe41.InnerText = smokedata.Check;//扭矩
                XmlElement xe42 = xmldoc.CreateElement("Check2");//速度示值
                xe42.InnerText = smokedata.Check;//扭矩
                XmlElement xe43 = xmldoc.CreateElement("Check3");//速度示值
                xe43.InnerText = smokedata.Check;//扭矩
                XmlElement xe38 = xmldoc.CreateElement("Result");//0=不合格 1=合格
                xe38.InnerText = smokedata.Result;
                xe33.AppendChild(xe34);
                xe33.AppendChild(xe36);
                xe33.AppendChild(xe37);
                xe33.AppendChild(xe38);
                xe33.AppendChild(xe41);
                xe33.AppendChild(xe42);
                xe33.AppendChild(xe43);
                xe1.AppendChild(xe33);
            XmlElement xe50 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe51 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
            xe51.InnerText = smokedata.StartTime;
            XmlElement xe52 = xmldoc.CreateElement("Nominal");//名义速度
            xe52.InnerText = smokedata.Nominal2;
            XmlElement xe53 = xmldoc.CreateElement("Check");//速度示值
            xe53.InnerText = smokedata.Check2;//扭矩
            XmlElement xe54 = xmldoc.CreateElement("Check1");//速度示值
            xe54.InnerText = smokedata.Check2;//扭矩
            XmlElement xe55 = xmldoc.CreateElement("Check2");//速度示值
            xe55.InnerText = smokedata.Check2;//扭矩
            XmlElement xe56 = xmldoc.CreateElement("Check3");//速度示值
            xe56.InnerText = smokedata.Check2;//扭矩
            XmlElement xe57 = xmldoc.CreateElement("Result");//0=不合格 1=合格
            xe57.InnerText = smokedata.Result2;
            xe50.AppendChild(xe51);
            xe50.AppendChild(xe52);
            xe50.AppendChild(xe53);
            xe50.AppendChild(xe54);
            xe50.AppendChild(xe55);
            xe50.AppendChild(xe56);
            xe50.AppendChild(xe57);
            xe1.AppendChild(xe50);
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }
        public void UploadFlowO2CalRequest(UploadFlowO2Cal flowdata, out string result, out string inf)
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
            xe1.SetAttribute("Name", "FlowO2Cal");//设置该节点genre属性 
            XmlElement xe33 = xmldoc.CreateElement("Row");//创建一个<Node>节点 
            XmlElement xe34 = xmldoc.CreateElement("StartTime");//本标定点标定时的开始时间
            xe34.InnerText = flowdata.StartTime;
            XmlElement xe36 = xmldoc.CreateElement("Nominal");//名义速度
            xe36.InnerText = flowdata.Nominal;
            XmlElement xe37 = xmldoc.CreateElement("CheckFlow1");//速度示值
            xe37.InnerText = flowdata.CheckFlow;//扭矩
            XmlElement xe41 = xmldoc.CreateElement("CheckFlow2");//速度示值
            xe41.InnerText = flowdata.CheckFlow;//扭矩
            XmlElement xe42 = xmldoc.CreateElement("CheckFlow3");//速度示值
            xe42.InnerText = flowdata.CheckFlow;//扭矩
            XmlElement xe43 = xmldoc.CreateElement("CheckO21");//速度示值
            xe43.InnerText = flowdata.CheckO2;//扭矩
            XmlElement xe44 = xmldoc.CreateElement("CheckO22");//速度示值
            xe44.InnerText = flowdata.CheckO2;//扭矩
            XmlElement xe45 = xmldoc.CreateElement("CheckO23");//速度示值
            xe45.InnerText = flowdata.CheckO2;//扭矩
            XmlElement xe46 = xmldoc.CreateElement("Result");//0=不合格 1=合格
            xe46.InnerText = flowdata.Result;
            xe33.AppendChild(xe34);
            xe33.AppendChild(xe36);
            xe33.AppendChild(xe37);
            xe33.AppendChild(xe41);
            xe33.AppendChild(xe42);
            xe33.AppendChild(xe43);
            xe33.AppendChild(xe44);
            xe33.AppendChild(xe45);
            xe33.AppendChild(xe46);
            xe1.AppendChild(xe33);
            root.AppendChild(xe1);
            //socket.Send(ConvertXmlToString(xmldoc));
            if (SendData(socket, ConvertXmlToString(xmldoc)) < 0)
            {
                return;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[10 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                ReadCalibration(receivedString, out result, out inf);
            }
        }

    }

}
