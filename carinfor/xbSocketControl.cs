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

namespace carinfo
{
    public class xbSocketControl
    {
        
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
        static int frameHead = 58250;

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
            INIIO.saveSocketLogInf("[SEND]:" + xmlString);
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(xmlString);
            List<byte> listToSend = new List<byte>();
            listToSend.Add((byte)(frameHead >> 24));
            listToSend.Add((byte)(frameHead >> 16));
            listToSend.Add((byte)(frameHead >> 8));
            listToSend.Add((byte)(frameHead));
            int length = bufferToSend.Length;
            listToSend.Add((byte)(length >> 24));
            listToSend.Add((byte)(length >> 16));
            listToSend.Add((byte)(length >> 8));
            listToSend.Add((byte)(length));
            listToSend.AddRange(bufferToSend);
            return listToSend.ToArray();
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
                        string receivedstring = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer, 0, hasRecv);
                        INIIO.saveSocketLogInf("[RECEIVED]:" + receivedstring);
                        if (hasRecv > 8)//如果接收的长度超过8，则开始判断接收到的总长度是否是帧头长度+8
                        {
                            int length = (int)((buffer[4] << 24) | (buffer[4] << 16) | (buffer[4] << 8) | (buffer[4]));
                            if (hasRecv == length + 8)
                            {
                                string s = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer, 8, length);
                                INIIO.saveSocketLogInf("[MESSAGE]:" + s);
                                receivedMessage = s;
                                flag = 1;
                                break;
                            }
                        }                        
                        if (left == 0)
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
            //INIIO.saveSocketLogInf("RECEIVE:" + receivedMessage);
            return flag;
        }
    }

}
