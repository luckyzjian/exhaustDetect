using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Web;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using ini;
using System.Data;
using System.Collections;

namespace DlWebClient
{
    public class daliInterface
    {
        public enum DaliEquipName {测功机=0,废气仪=1,烟度计=2,电子环境信息仪=3,发动机转速仪=4,流量计=5 };
        public enum DaliEquipStatus { 正常 = 0, 故障 = 1 };

        IPAddress HostIP = IPAddress.Parse("192.168.1.5");
        int HostPort = 5464;
        IPEndPoint point;
        private static Socket socket;
        bool flag = true;
        Socket acceptedSocket;


        private string receivedString = "";
        private bool receivedFlag = false;
        Thread thread = null;

        private bool receivedflag = false;
        static int sendOutTime = 10;
        static int receiveOutTime = 100;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public Hashtable DL_CPYS = new Hashtable();
        public Hashtable DL_CLZL = new Hashtable();
        public Hashtable DL_CLLX = new Hashtable();
        public Hashtable DL_CZLB = new Hashtable();
        public Hashtable DL_SYXZ = new Hashtable();
        public Hashtable DL_YYXZ = new Hashtable();
        public Hashtable DL_YZZL = new Hashtable();
        public Hashtable DL_QDFS = new Hashtable();
        public Hashtable DL_BSQXS = new Hashtable();
        public Hashtable DL_GYFS = new Hashtable();
        public Hashtable DL_RLZL = new Hashtable();
        public Hashtable DL_JQFS = new Hashtable();
        public Hashtable DL_JHZZ = new Hashtable();
        public Hashtable DL_DPFS = new Hashtable();
        public Hashtable DL_ZRBZ = new Hashtable();
        public Hashtable DL_YQBF = new Hashtable();
        public Hashtable DL_JCLB = new Hashtable();
        public Hashtable DL_SCD = new Hashtable();

        public daliInterface()
        {
            DL_CPYS.Add("0", "蓝");
            DL_CPYS.Add("1", "黄");
            DL_CPYS.Add("2", "白");
            DL_CPYS.Add("3", "黑");

            DL_CLZL.Add("0", "客车");
            DL_CLZL.Add("1", "货车");

            DL_CLLX.Add("0", "微型客车");
            DL_CLLX.Add("1", "小型客车");
            DL_CLLX.Add("2", "中型客车");
            DL_CLLX.Add("3", "大型客车");
            DL_CLLX.Add("4", "微型货车");
            DL_CLLX.Add("5", "轻型货车");
            DL_CLLX.Add("6", "中型货车");
            DL_CLLX.Add("7", "重型货车");

            DL_CZLB.Add("0", "个人");
            DL_CZLB.Add("1", "单位");

            DL_SYXZ.Add("0", "营运");
            DL_SYXZ.Add("1", "非营运");

            DL_YYXZ.Add("0", "公交");
            DL_YYXZ.Add("1", "出租");
            DL_YYXZ.Add("2", "其他");

            DL_YZZL.Add("0", "载货");
            DL_YZZL.Add("1", "载客");

            DL_QDFS.Add("0", "前驱");
            DL_QDFS.Add("1", "后躯");
            DL_QDFS.Add("2", "全驱 ");

            DL_BSQXS.Add("0", "手动");
            DL_BSQXS.Add("1", "自动");
            DL_BSQXS.Add("2", "手自一体 ");

            DL_GYFS.Add("0", "电喷开环");
            DL_GYFS.Add("1", "电喷闭环");
            DL_GYFS.Add("2", "化油器 ");
            DL_GYFS.Add("3", "化油器改造 ");

            DL_RLZL.Add("0", "柴油");
            DL_RLZL.Add("1", "汽油");

            DL_JQFS.Add("0", "自然吸气");
            DL_JQFS.Add("1", "涡轮增压");

            DL_JHZZ.Add("0", "有");
            DL_JHZZ.Add("1", "无");

            DL_DPFS.Add("0", "开环");
            DL_DPFS.Add("1", "闭环");

            DL_ZRBZ.Add("0", "是");
            DL_ZRBZ.Add("1", "否");

            DL_YQBF.Add("0", "是");
            DL_YQBF.Add("1", "否");

            DL_JCLB.Add("0", "车辆年审检测");
            DL_JCLB.Add("1", "外地转入检测");
            DL_JCLB.Add("2", "其他检测 ");

            DL_SCD.Add("0", "进口");
            DL_SCD.Add("1", "国产");
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

        public void closeSocket()
        {
            try
            {
                socket.Close();
            }
            catch
            { }
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
                socket.Close();
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
                socket.Close();
                return "连接成功";
            }
            catch (Exception ey)
            {
                return ey.Message;
            }
        }
        private bool connectSocket(out string msg)
        {
            msg = "";
            try
            {
                point = new IPEndPoint(HostIP, HostPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                return true;
            }
            catch(Exception er)
            {
                msg = er.Message;
                return false;
            }
        }
        private bool closeSocket(out string msg)
        {
            msg = "";
            try
            {
                socket.Close();
                return true;
            }
            catch (Exception er)
            {
                msg = er.Message;
                return false;
            }
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
                        string s = System.Text.Encoding.UTF8.GetString(buffer, 0, hasRecv);
                        //string s = Encoding.gbk.GetString(buffer, 0, hasRecv);//将已接收到的转换化字符串，以"/Message"为结束判断
                        // 数据已经全部接收 
                        INIIO.saveSocketLogInf("Receive:\r\n" + s);
                        bool isReceiveFinished = (s.Trim()).EndsWith("/机动车尾气检测环保数据>");
                        if (isReceiveFinished)
                        {
                            string strMsg = s.Trim();
                            int iEnd = strMsg.ToString().IndexOf("/机动车尾气检测环保数据>");
                            int lastiEnd = strMsg.ToString().LastIndexOf("/机动车尾气检测环保数据>");
                            if (iEnd != lastiEnd)
                            {
                                ini.INIIO.saveLogInf("解析socket套接字信息出现多组返回信息");
                                strMsg = strMsg.Substring(0, iEnd + "/机动车尾气检测环保数据>".Length);
                                ini.INIIO.saveLogInf("仅截取第一条信息:" + strMsg);
                            }
                            receivedMessage = strMsg;
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"utf-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            //string newstring = xmlString.Replace("<xml version=\"1.0\">", "");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            //saveLogInf(newstring);
            byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        public bool sendLineInf(string stationid,string lineid, DataTable dt, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "5";
                XmlElement xe2 = xmldoc.CreateElement("检测站编号");
                xe2.InnerText = stationid;
                XmlElement xe3 = xmldoc.CreateElement("检测工位编号");
                xe3.InnerText = lineid;
                XmlElement xe4 = xmldoc.CreateElement("工位状态数据集");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        XmlElement xe41 = xmldoc.CreateElement("工位状态数据");
                        XmlElement xe411 = xmldoc.CreateElement("设备名称");
                        xe411.InnerText = dt.Rows[i]["设备名称"].ToString();
                        XmlElement xe412 = xmldoc.CreateElement("设备状态");
                        xe412.InnerText = dt.Rows[i]["设备状态"].ToString();
                        xe41.AppendChild(xe411);
                        xe41.AppendChild(xe412);
                        xe4.AppendChild(xe41);
                    }
                }
                XmlElement xe5 = xmldoc.CreateElement("同步时间");
                xe5.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                root.AppendChild(xe1);
                root.AppendChild(xe2);
                root.AppendChild(xe3);
                root.AppendChild(xe4);
                root.AppendChild(xe5);
                ack=connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                        byte[] buffer = new byte[10 * 1024];
                        string receivedString = "";
                        if (RecvData(socket, out receivedString) > 0)
                        {
                            DataSet ds = new DataSet();
                            StringReader stream = new StringReader(receivedString);
                            XmlTextReader reader = new XmlTextReader(stream);
                            ds.ReadXml(reader);
                            DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                            result = dt1.Rows[0]["返回值"].ToString();
                            errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendReportInf( Hashtable ht,out string reportID, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            reportID = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "1";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendTestPircture(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "11";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendTestData(Hashtable ht,int lx,DataTable dt, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "2";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                if (dt != null)
                {
                    XmlElement xe3 = xmldoc.CreateElement("过程数据集");
                    XmlElement xe31 = xmldoc.CreateElement("过程数据");
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        if (lx == 2)
                        {
                            XmlElement xe3101 = xmldoc.CreateElement("采样编号");
                            xe3101.InnerText = i.ToString();
                            XmlElement xe3102 = xmldoc.CreateElement("采样时间");
                            xe3102.InnerText = dt.Rows[i]["全程时序"].ToString();
                            XmlElement xe3103 = xmldoc.CreateElement("HC测量值");
                            xe3103.InnerText = dt.Rows[i]["HC实时值"].ToString();
                            XmlElement xe3104 = xmldoc.CreateElement("NO测量值");
                            xe3104.InnerText = dt.Rows[i]["NO实时值"].ToString();
                            XmlElement xe3105 = xmldoc.CreateElement("CO测量值");
                            xe3105.InnerText = dt.Rows[i]["CO实时值"].ToString();
                            XmlElement xe3106 = xmldoc.CreateElement("CO2测量值");
                            xe3106.InnerText = dt.Rows[i]["CO2实时值"].ToString();
                            XmlElement xe3107 = xmldoc.CreateElement("O2测量值");
                            xe3107.InnerText = dt.Rows[i]["O2实时值"].ToString();
                            XmlElement xe3108 = xmldoc.CreateElement("车速");
                            xe3108.InnerText = dt.Rows[i]["实时车速"].ToString();
                            XmlElement xe3109 = xmldoc.CreateElement("转速");
                            xe3109.InnerText = dt.Rows[i]["转速"].ToString();
                            XmlElement xe3110 = xmldoc.CreateElement("稀释修正系数");
                            xe3110.InnerText = dt.Rows[i]["稀释修正系数"].ToString();
                            XmlElement xe3111 = xmldoc.CreateElement("湿度修正系数");
                            xe3111.InnerText = dt.Rows[i]["湿度修正系数"].ToString();
                            XmlElement xe3112 = xmldoc.CreateElement("环境温度");
                            xe3112.InnerText = dt.Rows[i]["环境温度"].ToString();
                            XmlElement xe3113 = xmldoc.CreateElement("大气压力");
                            xe3113.InnerText = dt.Rows[i]["大气压力"].ToString();
                            XmlElement xe3114 = xmldoc.CreateElement("相对湿度");
                            xe3114.InnerText = dt.Rows[i]["相对湿度"].ToString();
                            xe31.AppendChild(xe3101);
                            xe31.AppendChild(xe3102);
                            xe31.AppendChild(xe3103);
                            xe31.AppendChild(xe3104);
                            xe31.AppendChild(xe3105);
                            xe31.AppendChild(xe3106);
                            xe31.AppendChild(xe3107);
                            xe31.AppendChild(xe3108);
                            xe31.AppendChild(xe3109);
                            xe31.AppendChild(xe3110);
                            xe31.AppendChild(xe3111);
                            xe31.AppendChild(xe3112);
                            xe31.AppendChild(xe3113);
                            xe31.AppendChild(xe3114);
                        }
                        else if (lx == 4)
                        {
                            XmlElement xe3101 = xmldoc.CreateElement("采样编号");
                            xe3101.InnerText = i.ToString();
                            XmlElement xe3102 = xmldoc.CreateElement("采样时间");
                            xe3102.InnerText = dt.Rows[i]["全程时序"].ToString();
                            XmlElement xe3103 = xmldoc.CreateElement("光吸收系数");
                            xe3103.InnerText = dt.Rows[i]["光吸收系数K"].ToString();
                            XmlElement xe3104 = xmldoc.CreateElement("不透光度");
                            xe3104.InnerText = dt.Rows[i]["不透光度"].ToString();
                            XmlElement xe3105 = xmldoc.CreateElement("指示功率");
                            xe3105.InnerText = dt.Rows[i]["指示功率"].ToString();
                            XmlElement xe3106 = xmldoc.CreateElement("车速");
                            xe3106.InnerText = dt.Rows[i]["车速"].ToString();
                            XmlElement xe3107 = xmldoc.CreateElement("转速");
                            xe3107.InnerText = dt.Rows[i]["转速"].ToString();
                            XmlElement xe3108 = xmldoc.CreateElement("环境温度");
                            xe3108.InnerText = dt.Rows[i]["环境温度"].ToString();
                            XmlElement xe3109 = xmldoc.CreateElement("大气压力");
                            xe3109.InnerText = dt.Rows[i]["大气压力"].ToString();
                            XmlElement xe3110 = xmldoc.CreateElement("相对湿度");
                            xe3110.InnerText = dt.Rows[i]["相对湿度"].ToString();
                            xe31.AppendChild(xe3101);
                            xe31.AppendChild(xe3102);
                            xe31.AppendChild(xe3103);
                            xe31.AppendChild(xe3104);
                            xe31.AppendChild(xe3105);
                            xe31.AppendChild(xe3106);
                            xe31.AppendChild(xe3107);
                            xe31.AppendChild(xe3108);
                            xe31.AppendChild(xe3109);
                            xe31.AppendChild(xe3110);
                        }
                    }
                    xe3.AppendChild(xe31);
                    root.AppendChild(xe3);
                }
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendCgjZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendFqyZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                /*XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);*/
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendYdjZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                XmlElement xe3 = xmldoc.CreateElement("不透光检查数据集");
                XmlElement xe31 = xmldoc.CreateElement("不透光检查数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendDzhjZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                /*XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);*/
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendZsjZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                /*XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);*/
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendLljZjData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "3";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                /*XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);*/
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendSpeedBdData(Hashtable ht, DataTable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                XmlElement xe3 = xmldoc.CreateElement("车速标定数据集");
                for (int i = 0; i < htdata.Rows.Count; i++)
                {
                    XmlElement xe31 = xmldoc.CreateElement("车速标定数据");
                    XmlElement xe311 = xmldoc.CreateElement("设定值");
                    XmlElement xe312= xmldoc.CreateElement("实测值");
                    XmlElement xe313 = xmldoc.CreateElement("偏差");
                    xe311.InnerText = htdata.Rows[i]["设定值"].ToString();
                    xe312.InnerText = htdata.Rows[i]["实测值"].ToString();
                    xe313.InnerText = htdata.Rows[i]["偏差"].ToString();
                    xe31.AppendChild(xe311);
                    xe31.AppendChild(xe312);
                    xe31.AppendChild(xe313);
                    xe3.AppendChild(xe31);
                }
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendForceBdData(Hashtable ht, DataTable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                XmlElement xe3 = xmldoc.CreateElement("扭力标定数据集");
                for (int i = 0; i < htdata.Rows.Count; i++)
                {
                    XmlElement xe31 = xmldoc.CreateElement("扭力标定数据");
                    XmlElement xe311 = xmldoc.CreateElement("设定值");
                    XmlElement xe312 = xmldoc.CreateElement("实测值");
                    XmlElement xe313 = xmldoc.CreateElement("偏差");
                    xe311.InnerText = htdata.Rows[i]["设定值"].ToString();
                    xe312.InnerText = htdata.Rows[i]["实测值"].ToString();
                    xe313.InnerText = htdata.Rows[i]["偏差"].ToString();
                    xe31.AppendChild(xe311);
                    xe31.AppendChild(xe312);
                    xe31.AppendChild(xe313);
                    xe3.AppendChild(xe31);
                }
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendFqyBdData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }

                XmlElement xe3 = xmldoc.CreateElement("废气仪标定数据集");
                XmlElement xe31 = xmldoc.CreateElement("废气仪标定数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendYdjBdData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }

                XmlElement xe3 = xmldoc.CreateElement("烟度计标定数据集");
                XmlElement xe31 = xmldoc.CreateElement("烟度计标定数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendJsglBdData(Hashtable ht, DataTable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }
                XmlElement xe3 = xmldoc.CreateElement("寄生功率数据集");
                for (int i = 0; i < htdata.Rows.Count; i++)
                {
                    XmlElement xe31 = xmldoc.CreateElement("寄生功率数据");
                    XmlElement xe311 = xmldoc.CreateElement("最小车速");
                    XmlElement xe312 = xmldoc.CreateElement("最大车速");
                    XmlElement xe313 = xmldoc.CreateElement("滑行时间");
                    XmlElement xe314 = xmldoc.CreateElement("寄生功率");
                    xe311.InnerText = htdata.Rows[i]["最小车速"].ToString();
                    xe312.InnerText = htdata.Rows[i]["最大车速"].ToString();
                    xe313.InnerText = htdata.Rows[i]["滑行时间"].ToString();
                    xe314.InnerText = htdata.Rows[i]["寄生功率"].ToString();
                    xe31.AppendChild(xe311);
                    xe31.AppendChild(xe312);
                    xe31.AppendChild(xe313);
                    xe31.AppendChild(xe314);
                    xe3.AppendChild(xe31);
                }
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool sendJzhxBdData(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            bool ack;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("数据类型");
                xe1.InnerText = "4";
                root.AppendChild(xe1);
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe2 = xmldoc.CreateElement((string)et.Key);
                    xe2.InnerText = (string)et.Value;
                    root.AppendChild(xe2);
                }

                XmlElement xe3 = xmldoc.CreateElement("加载滑行数据集");
                XmlElement xe31 = xmldoc.CreateElement("加载滑行数据");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe311 = xmldoc.CreateElement((string)et.Key);
                    xe311.InnerText = (string)et.Value;
                    xe31.AppendChild(xe311);
                }
                xe3.AppendChild(xe31);
                root.AppendChild(xe3);
                ack = connectSocket(out errMsg);
                if (ack)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (SendData(ConvertXmlToString(xmldoc)) < 0)
                        {
                            result = "-1";
                            errMsg = "发送失败";
                            if (i == 2)
                            {
                                ack = false;
                                break;
                            }
                            else
                                continue;
                        }
                        Thread.Sleep(100);
                    byte[] buffer = new byte[10 * 1024];
                    string receivedString = "";
                    if (RecvData(socket, out receivedString) > 0)
                    {
                        DataSet ds = new DataSet();
                        StringReader stream = new StringReader(receivedString);
                        XmlTextReader reader = new XmlTextReader(stream);
                        ds.ReadXml(reader);
                        DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                        result = dt1.Rows[0]["返回值"].ToString();
                        errMsg = dt1.Rows[0]["结果描述"].ToString();
                            if (result == "0")
                            {
                                ack = true;
                                break;
                            }
                            else
                            {
                                ack = false;
                                break;
                            }
                        }
                        else if (i == 2)
                        {
                            result = "-1";
                            errMsg = "未接收到返回数据";
                            ack = false;
                            break;
                        }
                        else continue;
                    }
                    closeSocket();
                    return ack;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }

        public bool 判断异站检测(string jczbh,string clhp,string hpys, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("查询类型");
                xe1.InnerText = "1";
                XmlElement xe2 = xmldoc.CreateElement("检测站编号");
                xe2.InnerText = jczbh;
                XmlElement xe3 = xmldoc.CreateElement("车牌号码");
                xe3.InnerText = clhp;
                XmlElement xe4 = xmldoc.CreateElement("车牌颜色");
                xe4.InnerText = hpys;
                XmlElement xe5 = xmldoc.CreateElement("同步时间");
                xe5.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                root.AppendChild(xe1);
                root.AppendChild(xe2);
                root.AppendChild(xe3);
                root.AppendChild(xe4);
                root.AppendChild(xe5);
                if (SendData(ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    errMsg = "发送失败";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                    result = dt1.Rows[0]["返回值"].ToString();
                    errMsg = dt1.Rows[0]["结果描述"].ToString();
                    if (result == "0")
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    result = "-1";
                    errMsg = "未接收到返回数据";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool 查询车牌号信息(string jczbh, string clhp, string hpys,out DataTable dtinf, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtinf = new DataTable();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "机动车尾气检测环保数据", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("机动车尾气检测环保数据");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("查询类型");
                xe1.InnerText = "2";
                XmlElement xe2 = xmldoc.CreateElement("检测站编号");
                xe2.InnerText = jczbh;
                XmlElement xe3 = xmldoc.CreateElement("车牌号码");
                xe3.InnerText = clhp;
                XmlElement xe4 = xmldoc.CreateElement("车牌颜色");
                xe4.InnerText = hpys;
                XmlElement xe5 = xmldoc.CreateElement("同步时间");
                xe5.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                root.AppendChild(xe1);
                root.AppendChild(xe2);
                root.AppendChild(xe3);
                root.AppendChild(xe4);
                root.AppendChild(xe5);
                if (SendData(ConvertXmlToString(xmldoc)) < 0)
                {
                    result = "-1";
                    errMsg = "发送失败";
                    return false;
                }
                Thread.Sleep(100);
                byte[] buffer = new byte[10 * 1024];
                string receivedString = "";
                if (RecvData(socket, out receivedString) > 0)
                {
                    DataSet ds = new DataSet();
                    StringReader stream = new StringReader(receivedString);
                    XmlTextReader reader = new XmlTextReader(stream);
                    ds.ReadXml(reader);
                    DataTable dt1 = ds.Tables["机动车尾气检测环保数据"];
                    dtinf = dt1;
                    return true;
                }
                else
                {
                    result = "-1";
                    errMsg = "未接收到返回数据";
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
    }
}
