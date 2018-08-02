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
using System.Collections;

namespace carinfor
{
    public class OrtSocketInf
    {
        public string IP;
        public string PORT;
    }

    public class OrtASMVehicleInfo
    {
        public string License;
        public string LicenseClass;
        public string Fuel;
        public string VLTID;
        public string Mileage;
        public string RegData;
        public string OwnerName;
        public string OwnerAddr;
        public string BodyColor;
        public string EngineID;
        public string VIN;
        public string Cleaners;
        public string Brand;
        public string Model;
        public string GATypeCode;
        public string UseType;
        public string Area;
        public string EngineModel;
        public string IsTurbo;
        public string DriveType;
        public string FactoryDate;
        public string IsClosedLoopEFI;
        public string Is3WCC;
        public string RateSpeed;
        public string NominalPower;
        public string Passengers;
        public string BaseWeight;
        public string Cylinders;
        public string IfGoIntoCity;
        public string Stage;
    }
    public class OrtASMResult
    {
        //ASMResult
        public string TestID;
        public string License;
        public string LicenseClass;
        public string VehicleType;
        public string TestType;
        public string Region;
        public string Phase;
        public string StationID;
        public string EISID;
        public string OperatorID;
        public string AmbientTemp;
        public string AmbientHum;
        public string Pressure;
        public string TestStartTime;
        public string TestEndTime;
        public string CrucialTime0;
        public string CrucialTime1;
        public string CrucialTime2;
        public string CrucialTime3;
        public string AmbientHC;
        public string AmbientCO;
        public string AmbientNO;
        public string ResidualHC;
        public string Is5024Done;
        public string HCCutpoint5024;//注意与协议节点名称不同
        public string COCutpoint5024;
        public string NOCutpoint5024;
        public string HC5024;
        public string CO5024;
        public string NO5024;
        public string Rotary5024;
        public string Result5024;
        public string Is2540Done;
        public string HCCutpoint2540;//注意与协议节点名称不同
        public string COCutpoint2540;
        public string NOCutpoint2540;
        public string HC2540;
        public string CO2540;
        public string NO2540;
        public string Rotary2540;
        public string Result2540;
        public string Result;
        public string IsGasCapTested;
        public string GasCapResult;
        public string OutlookResult;
        public string AbortReason;

    }
    public class OrtASMDataseconds
    {
        public string TestID;
        public string TickCount;
        public string Speed;
        public string Rotary;
        public string IHPWithPLHP;
        public string HC;
        public string CO;
        public string NO;
        public string CO2;
        public string O2;
        public string Torque;
    }
    public class OrtTSIVehicleInfo
    {
        public string License;
        public string LicenseClass;
        public string Fuel;
        public string VLTID;
        public string Mileage;
        public string RegData;
        public string OwnerName;
        public string OwnerAddr;
        public string BodyColor;
        public string EngineID;
        public string VIN;
        public string Cleaners;
        public string Brand;
        public string Model;
        public string GATypeCode;
        public string UseType;
        public string Area;
        public string EngineModel;
        public string IsTurbo;
        public string DriveType;
        public string FactoryDate;
        public string IsClosedLoopEFI;
        public string Is3WCC;
        public string RateSpeed;
        public string NominalPower;
        public string Passengers;
        public string BaseWeight;
        public string Cylinders;
        public string IfGoIntoCity;
        public string Stage;
    }
    public class OrtTSIResult
    {
        public string TestID;
        public string License;
        public string LicenseClass;
        public string VehicleType;
        public string TestType;
        public string Region;
        public string Phase;
        public string StationID;
        public string EISID;
        public string OperatorID;
        public string AmbientTemp;
        public string AmbientHum;
        public string Pressure;
        public string TestStartTime;
        public string TestEndTime;
        public string CrucialTime0;
        public string CrucialTime1;
        public string CrucialTime2;
        public string CrucialTime3;
        public string AmbientHC;
        public string AmbientCO;
        public string AmbientNO;
        public string ResidualHC;
        public string HCHigh;
        public string COHigh;
        public string HCLow;
        public string COLow;
        public string Result;
        public string Lumbda;
        public string HCHighCutpoint;
        public string COHighCutpoint;
        public string HCLowCutpoint;
        public string COLowCutpoint;
        public string LumbdaCutpoint;
        public string LumbdaResult;
        public string OutlookResult;
        public string AbortReason;

    }
    public class OrtFreeACCVehicleInfo
    {
        public string License;
        public string LicenseClass;
        public string Fuel;
        public string VLTID;
        public string Mileage;
        public string RegData;
        public string OwnerName;
        public string OwnerAddr;
        public string BodyColor;
        public string EngineID;
        public string VIN;
        public string Cleaners;
        public string Brand;
        public string Model;
        public string GATypeCode;
        public string UseType;
        public string Area;
        public string EngineModel;
        public string IsTurbo;
        public string DriveType;
        public string FactoryDate;
        public string IsClosedLoopEFI;
        public string Is3WCC;
        public string RateSpeed;
        public string NominalPower;
        public string Passengers;
        public string BaseWeight;
        public string Cylinders;
        public string IfGoIntoCity;
        public string Stage;
    }
    public class OrtFreeACCResult
    {
        public string TestID;
        public string License;
        public string LicenseClass;
        public string VehicleType;
        public string TestType;
        public string Region;
        public string Phase;
        public string StationID;
        public string EISID;
        public string OperatorID;
        public string AmbientTemp;
        public string AmbientHum;
        public string Pressure;
        public string TestStartTime;
        public string TestEndTime;
        public string CrucialTime0;
        public string CrucialTime1;
        public string CrucialTime2;
        public string CrucialTime3;
        public string IdleSpeed;
        public string Smoke1;
        public string Smoke2;
        public string Smoke3;
        public string SmokeAve;
        public string SmokeCutpoint;
        public string Result;
        public string OutlookResult;
        public string AbortReason;

    }
    public class OrtLDVehicleInfo
    {
        public string License;
        public string LicenseClass;
        public string Fuel;
        public string VLTID;
        public string Mileage;
        public string RegData;
        public string OwnerName;
        public string OwnerAddr;
        public string BodyColor;
        public string EngineID;
        public string VIN;
        public string Cleaners;
        public string Brand;
        public string Model;
        public string GATypeCode;
        public string UseType;
        public string Area;
        public string EngineModel;
        public string IsTurbo;
        public string DriveType;
        public string FactoryDate;
        public string IsClosedLoopEFI;
        public string Is3WCC;
        public string RateSpeed;
        public string NominalPower;
        public string Passengers;
        public string BaseWeight;
        public string Cylinders;
        public string IfGoIntoCity;
        public string Stage;
    }
    public class OrtLDResult
    {
        public string TestID;
        public string License;
        public string LicenseClass;
        public string VehicleType;
        public string TestType;
        public string Region;
        public string Phase;
        public string StationID;
        public string EISID;
        public string OperatorID;
        public string AmbientTemp;
        public string AmbientHum;
        public string Pressure;
        public string TestStartTime;
        public string TestEndTime;
        public string CrucialTime0;
        public string CrucialTime1;
        public string CrucialTime2;
        public string CrucialTime3;
        public string PowerMax;
        public string EngineSpeed;
        public string EngineSpeedMax;
        public string EngineSpeedMin;
        public string PowerSTD;
        public string Smoke100Power;
        public string Smoke90Power;
        public string Smoke80Power;
        public string SmokeAve;
        public string SmokeCutpoint;
        public string Result;
        public string OutlookResult;
        public string AbortReason;

    }
    public class ortSocketControl
    {
        public Dictionary<string, string> ORT_LicenseClass = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_Fuel = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_Cleaners = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_UseType = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_UseTypeR = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_isTurbo = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_DriveType = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_IsClosedLoopEFI = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_Is3WCC = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_IfGoIntoCity = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_Stage = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_VehicleType = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_TestType = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_Phase = new Dictionary<string, string>();
        public Dictionary<string, string> ORT_PhaseR = new Dictionary<string, string>();
        HtmlExtractor.Gb2312Encoding encoding = new HtmlExtractor.Gb2312Encoding();
        IPAddress HostIP = IPAddress.Parse("127.0.0.1");
        int HostPort = 6005;
        static IPEndPoint point;
        private static Socket socket;
        bool flag = true;
        Socket acceptedSocket;


        private string receivedString = "";
        private bool receivedFlag = false;
        Thread thread = null;

        private bool receivedflag = false;
        static int sendOutTime = 10;
        static int receiveOutTime = 10;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public ortSocketControl(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            HostPort = Int32.Parse(port);
        }

        public ortSocketControl()
        {
            ORT_LicenseClass.Add("1", "蓝牌");
            ORT_LicenseClass.Add("2", "黄牌");
            ORT_LicenseClass.Add("3", "黑牌");
            ORT_LicenseClass.Add("4", "白牌");
            ORT_Fuel.Add("1", "汽油");
            ORT_Fuel.Add("2", "柴油");
            ORT_Fuel.Add("3", "甲醇或乙醇");
            ORT_Fuel.Add("4", "LPG(液化石油气)");
            ORT_Fuel.Add("5", "CNG");
            ORT_Fuel.Add("6", "双燃料");
            ORT_Cleaners.Add("1", "电喷");
            ORT_Cleaners.Add("2", "三元催化");
            ORT_Cleaners.Add("3", "化油器");

            ORT_UseType.Add("A", "非营运");
            ORT_UseType.Add("B", "公路客运");
            ORT_UseType.Add("C", "公交客运");
            ORT_UseType.Add("D", "出租客运");
            ORT_UseType.Add("E", "旅游客运");
            ORT_UseType.Add("F", "货运");
            ORT_UseType.Add("G", "租赁");
            ORT_UseType.Add("H", "警用");
            ORT_UseType.Add("I", "消防");
            ORT_UseType.Add("J", "救护");
            ORT_UseType.Add("K", "工程抢险");
            ORT_UseType.Add("L", "营转非");
            ORT_UseType.Add("M", "出租转非");
            ORT_UseType.Add("Z", "其他");

            ORT_UseTypeR.Add("非营运", "A");
            ORT_UseTypeR.Add("公路客运", "B");
            ORT_UseTypeR.Add("公交客运", "C");
            ORT_UseTypeR.Add("出租客运", "D");
            ORT_UseTypeR.Add("旅游客运", "E");
            ORT_UseTypeR.Add("货运", "F");
            ORT_UseTypeR.Add("租赁", "G");
            ORT_UseTypeR.Add("警用", "H");
            ORT_UseTypeR.Add("消防", "I");
            ORT_UseTypeR.Add("救护", "J");
            ORT_UseTypeR.Add("工程抢险", "K");
            ORT_UseTypeR.Add("营转非", "L");
            ORT_UseTypeR.Add("出租转非", "M");
            ORT_UseTypeR.Add("其他", "Z");

            ORT_DriveType.Add("1", "前驱");
            ORT_DriveType.Add("2", "后驱");
            ORT_DriveType.Add("3", "全时四驱");
            ORT_DriveType.Add("4", "分时四驱");

            ORT_IsClosedLoopEFI.Add("1", "闭环电喷");
            ORT_IsClosedLoopEFI.Add("2", "非闭环电喷");

            ORT_IfGoIntoCity.Add("1", "是");
            ORT_IfGoIntoCity.Add("2", "否");

            ORT_Is3WCC.Add("1", "是");
            ORT_Is3WCC.Add("2", "否");


            ORT_Phase.Add("1", "国I");
            ORT_Phase.Add("2", "国II");
            ORT_Phase.Add("3", "国III");
            ORT_Phase.Add("4", "国IV");
            ORT_Phase.Add("5", "国V");
            ORT_PhaseR.Add("国I", "1");
            ORT_PhaseR.Add("国II", "2");
            ORT_PhaseR.Add("国III", "3");
            ORT_PhaseR.Add("国IV", "4");
            ORT_PhaseR.Add("国V", "5");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void initSocket(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            HostPort = Int32.Parse(port);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eisid"></param>
        /// <returns></returns>
        public string init_equipment(out string eisid)
        {
            eisid = "";
            try
            {
                point = new IPEndPoint(HostIP, HostPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                return "连接成功";
            }
            catch (Exception ey)
            {
                return ey.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string init_equipment()
        {
            try
            {
                point = new IPEndPoint(HostIP, HostPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                return "连接成功";
            }
            catch (Exception ey)
            {
                return ey.Message;
            }
        }
        private bool connectsocket()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                ini.INIIO.saveSocketLogInf("socket连接成功");
                return true;
            }
            catch(Exception er)
            {
                ini.INIIO.saveSocketLogInf("socket连接出现异常："+er.Message);
                return false;
            }
        }
        public void close_socket()
        {
            try
            {
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
        public static int SendData(byte[] buffer)
        {
            if (socket == null || socket.Connected == false)
            {
                ini.INIIO.saveSocketLogInf("socket已断开");
                try
                {
                    socket.Close();
                }
                catch
                { }
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(point);
                    ini.INIIO.saveSocketLogInf("socket重连成功");
                }
                catch (Exception er)
                {
                    ini.INIIO.saveSocketLogInf("socket重连失败:原因：" + er.Message);
                    throw new ArgumentException("参数socket为null，或者未连接到远程计算机");
                }
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
            return SendData(System.Text.Encoding.Default.GetBytes(buffer));
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
            byte[] buffer = new byte[1024 * 1024 * 2];
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
                        string s = System.Text.Encoding.GetEncoding("gb2312").GetString(buffer, 0, hasRecv);
                        ini.INIIO.saveSocketLogInf("【接收】：\r\n" + s);
                        bool isReceiveFinished = ((s.EndsWith("\r\n\r\n\r\n")) || (s.EndsWith("\n\n\n")));
                        if (isReceiveFinished)
                        {
                            //receivedMessage = s.Replace("'","\"");//将单引号替换回双引号
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
            catch (SocketException)
            {
                //Log
                flag = -3;
            }
            return flag;
        }

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
            sr.Close();
            stream.Close();
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"gb2312\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            newstring = newstring.Replace("\"", "'");//将所有双引号换成单引号
            newstring += "\r\n\r\n\r\n";//在结尾处添加\r\n\r\n\r\n标志结尾
            ini.INIIO.saveSocketLogInf("【发送】：\r\n" + newstring);//保存日志
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);//按GB2312转化
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
        public bool SendConnectionTest(string StationID, string EISID, out string Result, out string Err, out string Vertion, out string DatetimeString)
        {
            Result = "";
            Err = "";
            Vertion = "";
            DatetimeString = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "ConnectionTest");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("ConnectionTest");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "StationID", StationID);
            setXmlElementAttribute(xe1, "EISID", EISID);
            root.AppendChild(xe1);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr;
                if (ReadConnectionTestACKString(receivedString, out ackerr, out Vertion, out DatetimeString))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool SendGetDatatime(out string Result, out string Err, out string DatetimeString)
        {
            Result = "";
            Err = "";
            DatetimeString = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "DateTime");
            xmldoc.AppendChild(xmlelem);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr;
                if (ReadDateTimeACKString(receivedString, out ackerr, out DatetimeString))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }

        public bool SendLoginBegin(string License, string LicenseClass, string StationID, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "CheckVehicle");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("Condition");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "License", License);
            setXmlElementAttribute(xe1, "LicenseClass", LicenseClass);
            setXmlElementAttribute(xe1, "StationID", StationID);
            root.AppendChild(xe1);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "联网发送车辆检查信息失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadACKString(receivedString, out ackerr, out Result, out Err))
                {
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    if (Result == "TRUE")
                        return true;
                    else
                    {
                        if (Err == "")
                            Err = "该车已在其他检测站点检测，不能再在本检测站点检测";
                        return false;
                    }
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "联网发送车辆检查信息时无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool UploadAsmResult(OrtASMVehicleInfo vehicleinfo, OrtASMResult asmresult, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "UploadVMASResult");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("VehicleInfo");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "License", vehicleinfo.License);
            setXmlElementAttribute(xe1, "LicenseClass", vehicleinfo.LicenseClass);
            setXmlElementAttribute(xe1, "Fuel", vehicleinfo.Fuel);
            setXmlElementAttribute(xe1, "VLTID", vehicleinfo.VLTID);
            setXmlElementAttribute(xe1, "Mileage", vehicleinfo.Mileage);
            setXmlElementAttribute(xe1, "RegData", vehicleinfo.RegData);
            setXmlElementAttribute(xe1, "OwnerName", vehicleinfo.OwnerName);
            setXmlElementAttribute(xe1, "OwnerAddr", vehicleinfo.OwnerAddr);
            setXmlElementAttribute(xe1, "BodyColor", vehicleinfo.BodyColor);
            setXmlElementAttribute(xe1, "EngineID", vehicleinfo.EngineID);//10
            setXmlElementAttribute(xe1, "VIN", vehicleinfo.VIN);
            setXmlElementAttribute(xe1, "Cleaners", vehicleinfo.Cleaners);
            setXmlElementAttribute(xe1, "Brand", vehicleinfo.Brand);
            setXmlElementAttribute(xe1, "Model", vehicleinfo.Model);
            setXmlElementAttribute(xe1, "GATypeCode", vehicleinfo.GATypeCode);
            setXmlElementAttribute(xe1, "UseType", vehicleinfo.UseType);
            setXmlElementAttribute(xe1, "Area", vehicleinfo.Area);
            setXmlElementAttribute(xe1, "EngineModel", vehicleinfo.EngineModel);
            setXmlElementAttribute(xe1, "IsTurbo", vehicleinfo.IsTurbo);
            setXmlElementAttribute(xe1, "DriveType", vehicleinfo.DriveType);//20
            setXmlElementAttribute(xe1, "FactoryDate", vehicleinfo.FactoryDate);
            setXmlElementAttribute(xe1, "IsClosedLoopEFI", vehicleinfo.IsClosedLoopEFI);
            setXmlElementAttribute(xe1, "Is3WCC", vehicleinfo.Is3WCC);
            setXmlElementAttribute(xe1, "RateSpeed", vehicleinfo.RateSpeed);
            setXmlElementAttribute(xe1, "NominalPower", vehicleinfo.NominalPower);
            setXmlElementAttribute(xe1, "Passengers", vehicleinfo.Passengers);
            setXmlElementAttribute(xe1, "BaseWeight", vehicleinfo.BaseWeight);
            setXmlElementAttribute(xe1, "Cylinders", vehicleinfo.Cylinders);
            setXmlElementAttribute(xe1, "IfGoIntoCity", vehicleinfo.IfGoIntoCity);
            setXmlElementAttribute(xe1, "Stage", vehicleinfo.Stage);//30
            XmlElement xe2 = xmldoc.CreateElement("ASMResult");//创建一个<Node>节点 
            setXmlElementAttribute(xe2, "TestID", asmresult.TestID);
            setXmlElementAttribute(xe2, "License", asmresult.License);
            setXmlElementAttribute(xe2, "LicenseClass", asmresult.LicenseClass);
            setXmlElementAttribute(xe2, "VehicleType", asmresult.VehicleType);
            setXmlElementAttribute(xe2, "TestType", asmresult.TestType);
            setXmlElementAttribute(xe2, "Region", asmresult.Region);
            setXmlElementAttribute(xe2, "Phase", asmresult.Phase);
            setXmlElementAttribute(xe2, "StationID", asmresult.StationID);
            setXmlElementAttribute(xe2, "EISID", asmresult.EISID);
            setXmlElementAttribute(xe2, "OperatorID", asmresult.OperatorID);
            setXmlElementAttribute(xe2, "AmbientTemp", asmresult.AmbientTemp);
            setXmlElementAttribute(xe2, "AmbientHum", asmresult.AmbientHum);
            setXmlElementAttribute(xe2, "Pressure", asmresult.Pressure);
            setXmlElementAttribute(xe2, "TestStartTime", asmresult.TestStartTime);
            setXmlElementAttribute(xe2, "TestEndTime", asmresult.TestEndTime);
            setXmlElementAttribute(xe2, "CrucialTime0", asmresult.CrucialTime0);
            setXmlElementAttribute(xe2, "CrucialTime1", asmresult.CrucialTime1);
            setXmlElementAttribute(xe2, "CrucialTime2", asmresult.CrucialTime2);
            setXmlElementAttribute(xe2, "CrucialTime3", asmresult.CrucialTime3);
            setXmlElementAttribute(xe2, "AmbientHC", asmresult.AmbientHC);
            setXmlElementAttribute(xe2, "AmbientCO", asmresult.AmbientCO);
            setXmlElementAttribute(xe2, "AmbientNO", asmresult.AmbientNO);
            setXmlElementAttribute(xe2, "ResidualHC", asmresult.ResidualHC);
            setXmlElementAttribute(xe2, "Is5024Done", asmresult.Is5024Done);
            setXmlElementAttribute(xe2, "5024HCCutpoint", asmresult.HCCutpoint5024);
            setXmlElementAttribute(xe2, "5024COCutpoint", asmresult.COCutpoint5024);
            setXmlElementAttribute(xe2, "5024NOCutpoint", asmresult.NOCutpoint5024);
            setXmlElementAttribute(xe2, "5024HC", asmresult.HC5024);
            setXmlElementAttribute(xe2, "5024CO", asmresult.CO5024);
            setXmlElementAttribute(xe2, "5024NO", asmresult.NO5024);
            setXmlElementAttribute(xe2, "5024Rotary", asmresult.Rotary5024);
            setXmlElementAttribute(xe2, "5024Result", asmresult.Result5024);
            setXmlElementAttribute(xe2, "Is2540Done", asmresult.Is2540Done);
            setXmlElementAttribute(xe2, "2540HCCutpoint", asmresult.HCCutpoint2540);
            setXmlElementAttribute(xe2, "2540COCutpoint", asmresult.COCutpoint2540);
            setXmlElementAttribute(xe2, "2540NOCutpoint", asmresult.NOCutpoint2540);
            setXmlElementAttribute(xe2, "2540HC", asmresult.HC2540);
            setXmlElementAttribute(xe2, "2540CO", asmresult.CO2540);
            setXmlElementAttribute(xe2, "2540NO", asmresult.NO2540);
            setXmlElementAttribute(xe2, "2540Rotary", asmresult.Rotary2540);
            setXmlElementAttribute(xe2, "2540Result", asmresult.Result2540);
            setXmlElementAttribute(xe2, "Result", asmresult.Result);
            setXmlElementAttribute(xe2, "IsGasCapTested", asmresult.IsGasCapTested);
            setXmlElementAttribute(xe2, "GasCapResult", asmresult.GasCapResult);
            setXmlElementAttribute(xe2, "OutlookResult", asmresult.OutlookResult);
            setXmlElementAttribute(xe2, "AbortReason", asmresult.AbortReason);
            root.AppendChild(xe1);
            root.AppendChild(xe2);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadUploadACKString(receivedString, out ackerr))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool UploadAsmDataseconds(string testID, DataTable dt, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "UploadASMProcess");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlElement xe1 = xmldoc.CreateElement("ASMProcess");//创建一个<Node>节点 
                setXmlElementAttribute(xe1, "TestID", testID);
                setXmlElementAttribute(xe1, "TickCount", (i + 1).ToString());
                setXmlElementAttribute(xe1, "Speed", dt.Rows[i]["实时车速"].ToString());
                setXmlElementAttribute(xe1, "Rotary", dt.Rows[i]["转速"].ToString());
                setXmlElementAttribute(xe1, "IHPWithPLHP", dt.Rows[i]["加载功率"].ToString());
                setXmlElementAttribute(xe1, "HC", dt.Rows[i]["HC实时值"].ToString());
                setXmlElementAttribute(xe1, "CO", dt.Rows[i]["CO实时值"].ToString());
                setXmlElementAttribute(xe1, "NO", dt.Rows[i]["NO实时值"].ToString());
                setXmlElementAttribute(xe1, "CO2", dt.Rows[i]["CO2实时值"].ToString());
                setXmlElementAttribute(xe1, "O2", dt.Rows[i]["O2实时值"].ToString());//10
                setXmlElementAttribute(xe1, "Torque", dt.Rows[i]["加载功率"].ToString());
                root.AppendChild(xe1);
            }
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadUploadACKString(receivedString, out ackerr))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool UploadTSIResult(OrtTSIVehicleInfo vehicleinfo, OrtTSIResult asmresult, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "UploadTSIResult");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("VehicleInfo");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "License", vehicleinfo.License);
            setXmlElementAttribute(xe1, "LicenseClass", vehicleinfo.LicenseClass);
            setXmlElementAttribute(xe1, "Fuel", vehicleinfo.Fuel);
            setXmlElementAttribute(xe1, "VLTID", vehicleinfo.VLTID);
            setXmlElementAttribute(xe1, "Mileage", vehicleinfo.Mileage);
            setXmlElementAttribute(xe1, "RegData", vehicleinfo.RegData);
            setXmlElementAttribute(xe1, "OwnerName", vehicleinfo.OwnerName);
            setXmlElementAttribute(xe1, "OwnerAddr", vehicleinfo.OwnerAddr);
            setXmlElementAttribute(xe1, "BodyColor", vehicleinfo.BodyColor);
            setXmlElementAttribute(xe1, "EngineID", vehicleinfo.EngineID);//10
            setXmlElementAttribute(xe1, "VIN", vehicleinfo.VIN);
            setXmlElementAttribute(xe1, "Cleaners", vehicleinfo.Cleaners);
            setXmlElementAttribute(xe1, "Brand", vehicleinfo.Brand);
            setXmlElementAttribute(xe1, "Model", vehicleinfo.Model);
            setXmlElementAttribute(xe1, "GATypeCode", vehicleinfo.GATypeCode);
            setXmlElementAttribute(xe1, "UseType", vehicleinfo.UseType);
            setXmlElementAttribute(xe1, "Area", vehicleinfo.Area);
            setXmlElementAttribute(xe1, "EngineModel", vehicleinfo.EngineModel);
            setXmlElementAttribute(xe1, "IsTurbo", vehicleinfo.IsTurbo);
            setXmlElementAttribute(xe1, "DriveType", vehicleinfo.DriveType);//20
            setXmlElementAttribute(xe1, "FactoryDate", vehicleinfo.FactoryDate);
            setXmlElementAttribute(xe1, "IsClosedLoopEFI", vehicleinfo.IsClosedLoopEFI);
            setXmlElementAttribute(xe1, "Is3WCC", vehicleinfo.Is3WCC);
            setXmlElementAttribute(xe1, "RateSpeed", vehicleinfo.RateSpeed);
            setXmlElementAttribute(xe1, "NominalPower", vehicleinfo.NominalPower);
            setXmlElementAttribute(xe1, "Passengers", vehicleinfo.Passengers);
            setXmlElementAttribute(xe1, "BaseWeight", vehicleinfo.BaseWeight);
            setXmlElementAttribute(xe1, "Cylinders", vehicleinfo.Cylinders);
            setXmlElementAttribute(xe1, "IfGoIntoCity", vehicleinfo.IfGoIntoCity);
            setXmlElementAttribute(xe1, "Stage", vehicleinfo.Stage);//30
            XmlElement xe2 = xmldoc.CreateElement("TSIResult");//创建一个<Node>节点 
            setXmlElementAttribute(xe2, "TestID", asmresult.TestID);
            setXmlElementAttribute(xe2, "License", asmresult.License);
            setXmlElementAttribute(xe2, "LicenseClass", asmresult.LicenseClass);
            setXmlElementAttribute(xe2, "VehicleType", asmresult.VehicleType);
            setXmlElementAttribute(xe2, "TestType", asmresult.TestType);
            setXmlElementAttribute(xe2, "Region", asmresult.Region);
            setXmlElementAttribute(xe2, "Phase", asmresult.Phase);
            setXmlElementAttribute(xe2, "StationID", asmresult.StationID);
            setXmlElementAttribute(xe2, "EISID", asmresult.EISID);
            setXmlElementAttribute(xe2, "OperatorID", asmresult.OperatorID);
            setXmlElementAttribute(xe2, "AmbientTemp", asmresult.AmbientTemp);
            setXmlElementAttribute(xe2, "AmbientHum", asmresult.AmbientHum);
            setXmlElementAttribute(xe2, "Pressure", asmresult.Pressure);
            setXmlElementAttribute(xe2, "TestStartTime", asmresult.TestStartTime);
            setXmlElementAttribute(xe2, "TestEndTime", asmresult.TestEndTime);
            setXmlElementAttribute(xe2, "CrucialTime0", asmresult.CrucialTime0);
            setXmlElementAttribute(xe2, "CrucialTime1", asmresult.CrucialTime1);
            setXmlElementAttribute(xe2, "CrucialTime2", asmresult.CrucialTime2);
            setXmlElementAttribute(xe2, "CrucialTime3", asmresult.CrucialTime3);
            setXmlElementAttribute(xe2, "AmbientHC", asmresult.AmbientHC);
            setXmlElementAttribute(xe2, "AmbientCO", asmresult.AmbientCO);
            setXmlElementAttribute(xe2, "AmbientNO", asmresult.AmbientNO);
            setXmlElementAttribute(xe2, "ResidualHC", asmresult.ResidualHC);
            setXmlElementAttribute(xe2, "HCHigh", asmresult.HCHigh);
            setXmlElementAttribute(xe2, "COHigh", asmresult.COHigh);
            setXmlElementAttribute(xe2, "HCLow", asmresult.HCLow);
            setXmlElementAttribute(xe2, "COLow", asmresult.COLow);
            setXmlElementAttribute(xe2, "Result", asmresult.Result);
            setXmlElementAttribute(xe2, "Lumbda", asmresult.Lumbda);
            setXmlElementAttribute(xe2, "HCHighCutpoint", asmresult.HCHighCutpoint);
            setXmlElementAttribute(xe2, "COHighCutpoint", asmresult.COHighCutpoint);
            setXmlElementAttribute(xe2, "HCLowCutpoint", asmresult.HCLowCutpoint);
            setXmlElementAttribute(xe2, "COLowCutpoint", asmresult.COLowCutpoint);
            setXmlElementAttribute(xe2, "LumbdaCutpoint", asmresult.LumbdaCutpoint);
            setXmlElementAttribute(xe2, "LumbdaResult", asmresult.LumbdaResult);
            setXmlElementAttribute(xe2, "OutlookResult", asmresult.OutlookResult);
            setXmlElementAttribute(xe2, "AbortReason", asmresult.AbortReason);
            root.AppendChild(xe1);
            root.AppendChild(xe2);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadUploadACKString(receivedString, out ackerr))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool UploadFreeAccResult(OrtFreeACCVehicleInfo vehicleinfo, OrtFreeACCResult asmresult, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "UploadFreeAccResult");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("VehicleInfo");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "License", vehicleinfo.License);
            setXmlElementAttribute(xe1, "LicenseClass", vehicleinfo.LicenseClass);
            setXmlElementAttribute(xe1, "Fuel", vehicleinfo.Fuel);
            setXmlElementAttribute(xe1, "VLTID", vehicleinfo.VLTID);
            setXmlElementAttribute(xe1, "Mileage", vehicleinfo.Mileage);
            setXmlElementAttribute(xe1, "RegData", vehicleinfo.RegData);
            setXmlElementAttribute(xe1, "OwnerName", vehicleinfo.OwnerName);
            setXmlElementAttribute(xe1, "OwnerAddr", vehicleinfo.OwnerAddr);
            setXmlElementAttribute(xe1, "BodyColor", vehicleinfo.BodyColor);
            setXmlElementAttribute(xe1, "EngineID", vehicleinfo.EngineID);//10
            setXmlElementAttribute(xe1, "VIN", vehicleinfo.VIN);
            setXmlElementAttribute(xe1, "Cleaners", vehicleinfo.Cleaners);
            setXmlElementAttribute(xe1, "Brand", vehicleinfo.Brand);
            setXmlElementAttribute(xe1, "Model", vehicleinfo.Model);
            setXmlElementAttribute(xe1, "GATypeCode", vehicleinfo.GATypeCode);
            setXmlElementAttribute(xe1, "UseType", vehicleinfo.UseType);
            setXmlElementAttribute(xe1, "Area", vehicleinfo.Area);
            setXmlElementAttribute(xe1, "EngineModel", vehicleinfo.EngineModel);
            setXmlElementAttribute(xe1, "IsTurbo", vehicleinfo.IsTurbo);
            setXmlElementAttribute(xe1, "DriveType", vehicleinfo.DriveType);//20
            setXmlElementAttribute(xe1, "FactoryDate", vehicleinfo.FactoryDate);
            setXmlElementAttribute(xe1, "IsClosedLoopEFI", vehicleinfo.IsClosedLoopEFI);
            setXmlElementAttribute(xe1, "Is3WCC", vehicleinfo.Is3WCC);
            setXmlElementAttribute(xe1, "RateSpeed", vehicleinfo.RateSpeed);
            setXmlElementAttribute(xe1, "NominalPower", vehicleinfo.NominalPower);
            setXmlElementAttribute(xe1, "Passengers", vehicleinfo.Passengers);
            setXmlElementAttribute(xe1, "BaseWeight", vehicleinfo.BaseWeight);
            setXmlElementAttribute(xe1, "Cylinders", vehicleinfo.Cylinders);
            setXmlElementAttribute(xe1, "IfGoIntoCity", vehicleinfo.IfGoIntoCity);
            setXmlElementAttribute(xe1, "Stage", vehicleinfo.Stage);//30
            XmlElement xe2 = xmldoc.CreateElement("FreeAccResult");//创建一个<Node>节点 
            setXmlElementAttribute(xe2, "Device", "");//如果滤纸式传"FAFP",不透光传空字符串
            setXmlElementAttribute(xe2, "TestID", asmresult.TestID);
            setXmlElementAttribute(xe2, "License", asmresult.License);
            setXmlElementAttribute(xe2, "LicenseClass", asmresult.LicenseClass);
            setXmlElementAttribute(xe2, "VehicleType", asmresult.VehicleType);
            setXmlElementAttribute(xe2, "TestType", asmresult.TestType);
            setXmlElementAttribute(xe2, "Region", asmresult.Region);
            setXmlElementAttribute(xe2, "Phase", asmresult.Phase);
            setXmlElementAttribute(xe2, "StationID", asmresult.StationID);
            setXmlElementAttribute(xe2, "EISID", asmresult.EISID);
            setXmlElementAttribute(xe2, "OperatorID", asmresult.OperatorID);
            setXmlElementAttribute(xe2, "AmbientTemp", asmresult.AmbientTemp);
            setXmlElementAttribute(xe2, "AmbientHum", asmresult.AmbientHum);
            setXmlElementAttribute(xe2, "Pressure", asmresult.Pressure);
            setXmlElementAttribute(xe2, "TestStartTime", asmresult.TestStartTime);
            setXmlElementAttribute(xe2, "TestEndTime", asmresult.TestEndTime);
            setXmlElementAttribute(xe2, "CrucialTime0", asmresult.CrucialTime0);
            setXmlElementAttribute(xe2, "CrucialTime1", asmresult.CrucialTime1);
            setXmlElementAttribute(xe2, "CrucialTime2", asmresult.CrucialTime2);
            setXmlElementAttribute(xe2, "CrucialTime3", asmresult.CrucialTime3);
            setXmlElementAttribute(xe2, "IdleSpeed", asmresult.IdleSpeed);
            setXmlElementAttribute(xe2, "Smoke1", asmresult.Smoke1);
            setXmlElementAttribute(xe2, "Smoke2", asmresult.Smoke2);
            setXmlElementAttribute(xe2, "Smoke3", asmresult.Smoke3);
            setXmlElementAttribute(xe2, "SmokeAve", asmresult.SmokeAve);
            setXmlElementAttribute(xe2, "SmokeCutpoint", asmresult.SmokeCutpoint);
            setXmlElementAttribute(xe2, "Result", asmresult.Result);
            setXmlElementAttribute(xe2, "OutlookResult", asmresult.OutlookResult);
            setXmlElementAttribute(xe2, "AbortReason", asmresult.AbortReason);
            root.AppendChild(xe1);
            root.AppendChild(xe2);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadUploadACKString(receivedString, out ackerr))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public bool UploadLDResult(OrtLDVehicleInfo vehicleinfo, OrtLDResult asmresult, out string Result, out string Err)
        {
            Result = "";
            Err = "";
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "Connection", "");
            setXmlElementAttribute(xmlelem, "Action", "UploadLDResult");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("Connection");//查找<Employees> 
            XmlElement xe1 = xmldoc.CreateElement("VehicleInfo");//创建一个<Node>节点 
            setXmlElementAttribute(xe1, "License", vehicleinfo.License);
            setXmlElementAttribute(xe1, "LicenseClass", vehicleinfo.LicenseClass);
            setXmlElementAttribute(xe1, "Fuel", vehicleinfo.Fuel);
            setXmlElementAttribute(xe1, "VLTID", vehicleinfo.VLTID);
            setXmlElementAttribute(xe1, "Mileage", vehicleinfo.Mileage);
            setXmlElementAttribute(xe1, "RegData", vehicleinfo.RegData);
            setXmlElementAttribute(xe1, "OwnerName", vehicleinfo.OwnerName);
            setXmlElementAttribute(xe1, "OwnerAddr", vehicleinfo.OwnerAddr);
            setXmlElementAttribute(xe1, "BodyColor", vehicleinfo.BodyColor);
            setXmlElementAttribute(xe1, "EngineID", vehicleinfo.EngineID);//10
            setXmlElementAttribute(xe1, "VIN", vehicleinfo.VIN);
            setXmlElementAttribute(xe1, "Cleaners", vehicleinfo.Cleaners);
            setXmlElementAttribute(xe1, "Brand", vehicleinfo.Brand);
            setXmlElementAttribute(xe1, "Model", vehicleinfo.Model);
            setXmlElementAttribute(xe1, "GATypeCode", vehicleinfo.GATypeCode);
            setXmlElementAttribute(xe1, "UseType", vehicleinfo.UseType);
            setXmlElementAttribute(xe1, "Area", vehicleinfo.Area);
            setXmlElementAttribute(xe1, "EngineModel", vehicleinfo.EngineModel);
            setXmlElementAttribute(xe1, "IsTurbo", vehicleinfo.IsTurbo);
            setXmlElementAttribute(xe1, "DriveType", vehicleinfo.DriveType);//20
            setXmlElementAttribute(xe1, "FactoryDate", vehicleinfo.FactoryDate);
            setXmlElementAttribute(xe1, "IsClosedLoopEFI", vehicleinfo.IsClosedLoopEFI);
            setXmlElementAttribute(xe1, "Is3WCC", vehicleinfo.Is3WCC);
            setXmlElementAttribute(xe1, "RateSpeed", vehicleinfo.RateSpeed);
            setXmlElementAttribute(xe1, "NominalPower", vehicleinfo.NominalPower);
            setXmlElementAttribute(xe1, "Passengers", vehicleinfo.Passengers);
            setXmlElementAttribute(xe1, "BaseWeight", vehicleinfo.BaseWeight);
            setXmlElementAttribute(xe1, "Cylinders", vehicleinfo.Cylinders);
            setXmlElementAttribute(xe1, "IfGoIntoCity", vehicleinfo.IfGoIntoCity);
            setXmlElementAttribute(xe1, "Stage", vehicleinfo.Stage);//30
            XmlElement xe2 = xmldoc.CreateElement("LDResult");//创建一个<Node>节点 
            setXmlElementAttribute(xe2, "Device", "");
            setXmlElementAttribute(xe2, "TestID", asmresult.TestID);
            setXmlElementAttribute(xe2, "License", asmresult.License);
            setXmlElementAttribute(xe2, "LicenseClass", asmresult.LicenseClass);
            setXmlElementAttribute(xe2, "VehicleType", asmresult.VehicleType);
            setXmlElementAttribute(xe2, "TestType", asmresult.TestType);
            setXmlElementAttribute(xe2, "Region", asmresult.Region);
            setXmlElementAttribute(xe2, "Phase", asmresult.Phase);
            setXmlElementAttribute(xe2, "StationID", asmresult.StationID);
            setXmlElementAttribute(xe2, "EISID", asmresult.EISID);
            setXmlElementAttribute(xe2, "OperatorID", asmresult.OperatorID);
            setXmlElementAttribute(xe2, "AmbientTemp", asmresult.AmbientTemp);
            setXmlElementAttribute(xe2, "AmbientHum", asmresult.AmbientHum);
            setXmlElementAttribute(xe2, "Pressure", asmresult.Pressure);
            setXmlElementAttribute(xe2, "TestStartTime", asmresult.TestStartTime);
            setXmlElementAttribute(xe2, "TestEndTime", asmresult.TestEndTime);
            setXmlElementAttribute(xe2, "CrucialTime0", asmresult.CrucialTime0);
            setXmlElementAttribute(xe2, "CrucialTime1", asmresult.CrucialTime1);
            setXmlElementAttribute(xe2, "CrucialTime2", asmresult.CrucialTime2);
            setXmlElementAttribute(xe2, "CrucialTime3", asmresult.CrucialTime3);
            setXmlElementAttribute(xe2, "PowerMax", asmresult.PowerMax);
            setXmlElementAttribute(xe2, "EngineSpeed", asmresult.EngineSpeed);
            setXmlElementAttribute(xe2, "EngineSpeedMax", asmresult.EngineSpeedMax);
            setXmlElementAttribute(xe2, "EngineSpeedMin", asmresult.EngineSpeedMin);
            setXmlElementAttribute(xe2, "PowerSTD", asmresult.PowerSTD);
            setXmlElementAttribute(xe2, "Smoke100Power", asmresult.Smoke100Power);
            setXmlElementAttribute(xe2, "Smoke90Power", asmresult.Smoke90Power);
            setXmlElementAttribute(xe2, "Smoke80Power", asmresult.Smoke80Power);
            setXmlElementAttribute(xe2, "SmokeAve", asmresult.SmokeAve);
            setXmlElementAttribute(xe2, "SmokeCutpoint", asmresult.SmokeCutpoint);
            setXmlElementAttribute(xe2, "Result", asmresult.Result);
            setXmlElementAttribute(xe2, "OutlookResult", asmresult.OutlookResult);
            setXmlElementAttribute(xe2, "AbortReason", asmresult.AbortReason);
            root.AppendChild(xe1);
            root.AppendChild(xe2);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                Result = "FALSE";
                Err = "发送失败";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string ackerr = "";
                if (ReadUploadACKString(receivedString, out ackerr))
                {
                    Result = "TRUE";
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return true;
                }
                else
                {
                    Result = "FALSE";
                    Err = ackerr;
                    ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                    return false;
                }
            }
            else
            {
                Result = "FALSE";
                Err = "无返回数据";
                ini.INIIO.saveSocketLogInf("Result:" + Result + ";Err:" + Err);
                return false;
            }
        }
        public static bool ReadDateTimeACKString(string xmlstring, out string err, out string datetime)
        {
            err = "";
            try
            {
                ini.INIIO.saveSocketLogInf(xmlstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                datetime = dt1.Rows[0]["DateTime"].ToString();
                return true;
            }
            catch (Exception er)
            {
                err = er.Message;
                datetime = "";
                return false;
            }
        }
        public static bool ReadConnectionTestACKString(string xmlstring, out string err, out string vertion, out string datetime)
        {
            err = "";
            try
            {
                ini.INIIO.saveSocketLogInf(xmlstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                vertion = dt1.Rows[0]["Version"].ToString();
                datetime = dt1.Rows[0]["ReturnData_Text"].ToString();
                return true;
            }
            catch (Exception er)
            {
                err = er.Message;
                vertion = "";
                datetime = "";
                return false;
            }
        }
        public static bool ReadACKString(string xmlstring, out string err, out string result, out string info)
        {
            err = "";
            try
            {
                ini.INIIO.saveSocketLogInf(xmlstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["Result"].ToString();
                info = dt1.Rows[0]["Err"].ToString();
                return true;
            }
            catch (Exception er)
            {
                err = er.Message;
                result = "";
                info = "";
                return false;
            }
        }
        public static bool ReadUploadACKString(string xmlstring, out string err)
        {
            err = "";
            try
            {
                ini.INIIO.saveSocketLogInf(xmlstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                if (dt1.Columns.Contains("Err"))
                {
                    err = dt1.Rows[0]["Err"].ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception er)
            {
                err = er.Message;
                return false;
            }
        }
    }
}
