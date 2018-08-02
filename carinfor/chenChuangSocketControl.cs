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

namespace carinfor
{
    public class CcSocketInf
    {
        public string IP;	//检测工位号
        public string PORT;	//设备名称
        public string JCZJC;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string SBRZBH;
    }
    public class CcVehicleInf
    {
        public string UniqueString;
        public string VLPN;
        public string VLPNColor;
        public string VehicleColor;
        public string VLPNType;//5
        public string VIN;
        public string IUVTYPE;
        public string VehicleBigType;
        public string PG;
        public string VehicleType;//10
        public string GAVType;
        public string VariableForm;
        public string KerbMass;
        public string BenchmarkMass;
        public string VML;//15
        public string VLDATE;
        public string RatedSeats;
        public string FactoryPlateModel;
        public string Mileage;
        public string OCHA;//20
        public string UseOfAuto;
        public string RegistDate;
        public string VRDATE;
        public string AbandonedYear;
        public string EngineNum;//25
        public string IUETYPE;
        public string EDSPL;
        public string IntakeWay;
        public string FuelType;
        public string OilSupplyWay;//30
        public string EngineRatedSpeed;
        public string EnginePower;
        public string ProductDate;
        public string ChassisType;
        public string GearCount;//35
        public string DriveForm;
        public string TyreType;
        public string IUVMANU;
        public string AxleWeight;
        public string StrokeCount;//40
        public string IUEMANU;
        public string CylinderCount;
        public string HasCCA;
        public string HasOxygenSensor;
        public string CatalyticConvertersAndCorp;//45
        public string GasVentCount;
        public string InspectionPeriod;
        public string HasOBD;
        public string IsDoubleFuel;
        public string EnvironmentalInfoCard;//50
        public string BZTYPE;
        public string Province;
        public string City;
        public string County;
        public string OwnerName;//55
        public string Sex;
        public string Tel;
        public string CredentialsType;
        public string CredentialsNum;
        public string ZipCode;//60
        public string Address;
        public string Remarks;
        public string ESignNo;
        public string EmissionStandard;
        public string ExceedTimeLimit;//65
        public string VehicleKind;
        public string IsLocalInspection;
        public string EStatus;
        public string PriCode;
        public string CityCode;//70
        public string RatioKey;
        public string VStatus;
        public string DateOfPurchase;
        public string SyncFlag;
        public string IsInValid;//75
        public string NewVehicleYear;
        public string SecondVehicleYear;
        public string UsedingVehicleYear;
        public string HisUniqueString;//79
        public CcVehicleInf()
        {
            this.UniqueString ="";
            this.VLPN = "";
            this.VLPNColor = "";
            this.VehicleColor = "";
            this.VLPNType = "";
            this.VIN = "";
            this.IUVTYPE = "";
            this.VehicleBigType = "";
            this.PG = "";
            this.VehicleType = "";
            this.GAVType = "";
            this.VariableForm = "";
            this.KerbMass = "";
            this.BenchmarkMass = "";
            this.VML = "";
            this.VLDATE = "";
            this.RatedSeats = "";
            this.FactoryPlateModel = "";
            this.Mileage = "";
            this.OCHA = "";
            this.UseOfAuto = "";
            this.RegistDate = "";
            this.VRDATE = "";
            this.AbandonedYear = "";
            this.EngineNum = "";
            this.IUETYPE = "";
            this.EDSPL = "";
            this.IntakeWay = "";
            this.FuelType = "";
            this.OilSupplyWay = "";
            this.EngineRatedSpeed = "";
            this.EnginePower = "";
            this.ProductDate = "";
            this.ChassisType = "";
            this.GearCount = "";
            this.DriveForm = "";
            this.TyreType = "";
            this.IUVMANU = "";
            this.AxleWeight = "";
            this.StrokeCount = "";
            this.IUEMANU = "";
            this.CylinderCount = "";
            this.HasCCA = "";
            this.HasOxygenSensor = "";
            this.CatalyticConvertersAndCorp = "";
            this.GasVentCount = "";
            this.InspectionPeriod = "";
            this.HasOBD = "";
            this.IsDoubleFuel = "";
            this.EnvironmentalInfoCard = "";
            this.BZTYPE = "";
            this.Province = "";
            this.City = "";
            this.County = "";
            this.OwnerName = "";
            this.Sex = "";
            this.Tel = "";
            this.CredentialsType = "";
            this.CredentialsNum = "";
            this.ZipCode = "";
            this.Address = "";
            this.Remarks = "";
            this.ESignNo = "";
            this.EmissionStandard = "";
            this.ExceedTimeLimit = "";
            this.VehicleKind = "";
            this.IsLocalInspection = "";
            this.EStatus = "";
            this.PriCode = "";
            this.CityCode = "";
            this.RatioKey = "";
            this.VStatus = "";
            this.DateOfPurchase = "";
            this.SyncFlag = "";
            this.IsInValid = "";
            this.NewVehicleYear = "";
            this.SecondVehicleYear = "";
            this.UsedingVehicleYear = "";
            this.HisUniqueString = "";
        }

    }
    public class dataMainTxt
    {
        public string jcbh;
        public string clhp;
        public string hpzl;
        public string vin;
        public string czy;
        public string jsy;
        public string wd;
        public string dqy;
        public string sd;
        public string jcsxh;
        public string cj;
        public string jccs;
        public string ljsxlc;
        public string lsh;
        public string jckssj;
        public string jcjssj;
        public string jyr;
        public string jcbgbh;
        public string fdjh;
        public string zbzl;
    }
    public class DataResultAsmTxt
    {
        public string jcbh;
        public string hc5025;
        public string co5025;
        public string no5025;
        public string hc2540;
        public string co2540;
        public string no2540;
        public string hc5025xz;
        public string co5025xz;
        public string no5025xz;
        public string hc2540xz;
        public string co2540xz;
        public string no2540xz; 
        public string hc5025pd;
        public string co5025pd;
        public string no5025pd;
        public string hc2540pd;
        public string co2540pd;
        public string no2540pd;
    }
    public class DataResultSds
    {
        public string jcbh;
        public string lambdaxz;
        public string lambda;
        public string lambdapd;
        public string colow;
        public string hclow;
        public string cohigh;
        public string hchigh;
        public string colowxz;
        public string hclowxz;
        public string cohighxz;
        public string hchighxz;
        public string colowpd;
        public string hclowpd;
        public string cohighpd;
        public string hchighpd;
    }
    public class DataResultLugdown
    {
        public string jcbh;
        public string ydxz;
        public string hk;
        public string nk;
        public string ek;
        public string lbgl;
        public string pd;
    }
    public class DataResultLz
    {
        public string jcbh;
        public string dszs;
        public string ydxz;
        public string firstdata;
        public string seconddata;
        public string thirddata;
        public string forthdata;
        public string averagedata;
        public string pd;
    }
    public class DataResultBtg
    {
        public string jcbh;
        public string dszs;
        public string ydxz;
        public string firstdata;
        public string seconddata;
        public string thirddata;
        public string averagedata;
        public string pd;
    }
    public class DataSecondsAsm
    {
        public string jcbh;
        public string mmsx;
        public string mmhc;
        public string mmco;
        public string mmco2;
        public string mmno;
        public string mmfxyo2;
        public string mmlljo2;
        public string mmsjll;
        public string mmbzll;
        public string mmwqll;
        public string mmhczl;
        public string mmcozl;
        public string mmnozl;
        public string mmcs;
        public string mmfdjzs;
        public string mmzjzgl;
        public string mmjsgl;
        public string mmzsgl;
        public string mmlljyl;
        public string mmlljwd;
        public string mmwd;
        public string mmdqy;
        public string mmsd;
        public string mmxsxzxs;
        public string mmsdxzxs;
        public string mmsxb;
        public string mmjcsj;
        public string jsjcff;//5025/2540
        public string ksgkjs;// 1 是， 0 否

    }
    public class DataSecondLugdown
    {
        public string jcbh;
        public string mmsx;
        public string CacuVelMaxHp;
        public string RealVelMaxHp;
        public string glsmmmgl;
        public string glsmmmcs;
        public string maxlbgl;
        public string mmfdjzs;
        public string mmwd;
        public string mmdqy;
        public string mmsd;
        public string glxzsx;
        public string xzzdlbgl;
        public string mmhk;
        public string mmnk;
        public string mmek;
        public string mmhkcs;
        public string mmnkcs;
        public string mmekcs;
        public string dszs;
        public string mmjcsj;
        public string sjtb;//数据同步，1 同步 0 未同步

    }
    public class limitAsm
    {
        public double hc5025;
        public double co5025;
        public double no5025;
        public double hc2540;
        public double co2540;
        public double no2540;

    }
    public class limitSds
    {
        public double lowCo;
        public double lowHc;
        public double highCo;
        public double highHc;
    }
    public class limitLugdown
    {
        public double ydxz;
    }
    public class limitBtg
    {
        public double ydxz;
    }
    public class chenChuangSocketControl
    {
        HtmlExtractor.Gb2312Encoding encoding = new HtmlExtractor.Gb2312Encoding();
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
        static int receiveOutTime = 10;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public chenChuangSocketControl(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            HostPort = Int32.Parse(port);
        }

        public chenChuangSocketControl()
        {
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
                        bool isReceiveFinished = ((buffer[hasRecv - 1] == 0x03) || (s.Trim().EndsWith("0x0003")));
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
            // int versionindex=xmlString.IndexOf('>');
            //xmlString = xmlString.Remove(0, versionindex + 1);
            sr.Close();
            stream.Close();
            //xmlString = xmlString.Replace(" ", "");
            string newstring = xmlString.Replace("\r\n", "");
            newstring = newstring.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"gb2312\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveLogInf("SEND:\r\n" + newstring);
            //saveLogInf(newstring);
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);
            //byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        /// <summary>  
        /// 将string转化为byte[],并加上头(0x02)和尾(0x03)  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertStringToByteArray(string sendstring)
        {
            ini.INIIO.saveLogInf("Send To CC server:\r\n" + sendstring);
            byte[] buffer = System.Text.Encoding.Default.GetBytes(sendstring);
            byte[] bufferToSend = new byte[buffer.Length+2];
            bufferToSend[0] = 0x02;
            for (int i = 0; i < buffer.Length; i++)
            {
                bufferToSend[i + 1] = buffer[i];
            }
            bufferToSend[buffer.Length + 1] = 0x03;
            return bufferToSend;
        }
        public bool SendLoginBegin(string clhp,string hpzl,out string code,out string message,out CcVehicleInf vehicleInfArray)
        {
            vehicleInfArray = new CcVehicleInf();
            code="";
            message="";
            string sendString = ",Login Begin,"+clhp+","+hpzl+",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 82)
                {
                    code = "1";
                    message = "读取数据成功";
                    vehicleInfArray.UniqueString = vehicleInf[2];
                    vehicleInfArray.VLPN = vehicleInf[3];
                    vehicleInfArray.VLPNColor = vehicleInf[4];
                    vehicleInfArray.VehicleColor = vehicleInf[5];
                    vehicleInfArray.VLPNType = vehicleInf[6];
                    vehicleInfArray.VIN = vehicleInf[7];
                    vehicleInfArray.IUVTYPE = vehicleInf[8];
                    vehicleInfArray.VehicleBigType = vehicleInf[9];
                    vehicleInfArray.PG = vehicleInf[10];
                    vehicleInfArray.VehicleType = vehicleInf[11];
                    vehicleInfArray.GAVType = vehicleInf[12];
                    vehicleInfArray.VariableForm = vehicleInf[13];
                    vehicleInfArray.KerbMass = vehicleInf[14];
                    vehicleInfArray.BenchmarkMass = vehicleInf[15];
                    vehicleInfArray.VML = vehicleInf[16];
                    vehicleInfArray.VLDATE = vehicleInf[17];
                    vehicleInfArray.RatedSeats = vehicleInf[18];
                    vehicleInfArray.FactoryPlateModel = vehicleInf[19];
                    vehicleInfArray.Mileage = vehicleInf[20];
                    vehicleInfArray.OCHA = vehicleInf[21];
                    vehicleInfArray.UseOfAuto = vehicleInf[22];
                    vehicleInfArray.RegistDate = vehicleInf[23];
                    vehicleInfArray.VRDATE = vehicleInf[24];
                    vehicleInfArray.AbandonedYear = vehicleInf[25];
                    vehicleInfArray.EngineNum = vehicleInf[26];
                    vehicleInfArray.IUETYPE = vehicleInf[27];
                    vehicleInfArray.EDSPL = vehicleInf[28];
                    vehicleInfArray.IntakeWay = vehicleInf[29];
                    vehicleInfArray.FuelType = vehicleInf[30];
                    vehicleInfArray.OilSupplyWay = vehicleInf[31];
                    vehicleInfArray.EngineRatedSpeed = vehicleInf[32];
                    vehicleInfArray.EnginePower = vehicleInf[33];
                    vehicleInfArray.ProductDate = vehicleInf[34];
                    vehicleInfArray.ChassisType = vehicleInf[35];
                    vehicleInfArray.GearCount = vehicleInf[36];
                    vehicleInfArray.DriveForm = vehicleInf[37];
                    vehicleInfArray.TyreType = vehicleInf[38];
                    vehicleInfArray.IUVMANU = vehicleInf[39];
                    vehicleInfArray.AxleWeight = vehicleInf[40];
                    vehicleInfArray.StrokeCount = vehicleInf[41];
                    vehicleInfArray.IUEMANU = vehicleInf[42];
                    vehicleInfArray.CylinderCount = vehicleInf[43];
                    vehicleInfArray.HasCCA = vehicleInf[44];
                    vehicleInfArray.HasOxygenSensor = vehicleInf[45];
                    vehicleInfArray.CatalyticConvertersAndCorp = vehicleInf[46];
                    vehicleInfArray.GasVentCount = vehicleInf[47];
                    vehicleInfArray.InspectionPeriod = vehicleInf[48];
                    vehicleInfArray.HasOBD = vehicleInf[49];
                    vehicleInfArray.IsDoubleFuel = vehicleInf[50];
                    vehicleInfArray.EnvironmentalInfoCard = vehicleInf[51];
                    vehicleInfArray.BZTYPE = vehicleInf[52];
                    vehicleInfArray.Province = vehicleInf[53];
                    vehicleInfArray.City = vehicleInf[54];
                    vehicleInfArray.County = vehicleInf[55];
                    vehicleInfArray.OwnerName = vehicleInf[56];
                    vehicleInfArray.Sex = vehicleInf[57];
                    vehicleInfArray.Tel = vehicleInf[58];
                    vehicleInfArray.CredentialsType = vehicleInf[59];
                    vehicleInfArray.CredentialsNum = vehicleInf[60];
                    vehicleInfArray.ZipCode = vehicleInf[61];
                    vehicleInfArray.Address = vehicleInf[62];
                    vehicleInfArray.Remarks = vehicleInf[63];
                    vehicleInfArray.ESignNo = vehicleInf[64];
                    vehicleInfArray.EmissionStandard = vehicleInf[65];
                    vehicleInfArray.ExceedTimeLimit = vehicleInf[66];
                    vehicleInfArray.VehicleKind = vehicleInf[67];
                    vehicleInfArray.IsLocalInspection = vehicleInf[68];
                    vehicleInfArray.EStatus = vehicleInf[69];
                    vehicleInfArray.PriCode = vehicleInf[70];
                    vehicleInfArray.CityCode = vehicleInf[71];
                    vehicleInfArray.RatioKey = vehicleInf[72];
                    vehicleInfArray.VStatus = vehicleInf[73];
                    vehicleInfArray.DateOfPurchase = vehicleInf[74];
                    vehicleInfArray.SyncFlag = vehicleInf[75];
                    vehicleInfArray.IsInValid = vehicleInf[76];
                    vehicleInfArray.NewVehicleYear = vehicleInf[77];
                    vehicleInfArray.SecondVehicleYear = vehicleInf[78];
                    vehicleInfArray.UsedingVehicleYear = vehicleInf[79];
                    vehicleInfArray.HisUniqueString = vehicleInf[80];
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool SendLoginOk(string clhp, string hpzl,string jcbh,string jccs, out string code, out string message)
        {
            code = "";
            message = "";
            string sendString = ",Login OK," + clhp + "," + hpzl + ","+jcbh+","+jccs+",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool GetLimit(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message,out limitAsm limitasm)
        {
            limitasm = new limitAsm();
            limitasm.hc5025 = 0;
            limitasm.co5025 = 0;
            limitasm.no5025 = 0;
            limitasm.hc2540 = 0;
            limitasm.co2540 = 0;
            limitasm.no2540 = 0;
            code = "";
            message = "";
            string sendString = ",Limit," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 9)
                {
                    try
                    {
                        limitasm.hc5025 = double.Parse(vehicleInf[2]);
                        limitasm.co5025 = double.Parse(vehicleInf[3]);
                        limitasm.no5025 = double.Parse(vehicleInf[4]);
                        limitasm.no2540 = double.Parse(vehicleInf[5]);
                        limitasm.hc2540 = double.Parse(vehicleInf[6]);
                        limitasm.co2540 = double.Parse(vehicleInf[7]);
                    }
                    catch
                    {
                        code = "0";
                        message = "数据格式有误";
                        return false;
                    }
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool GetLimit(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message, out limitSds limitsds)
        {
            limitsds = new limitSds();
            limitsds.lowCo = 0f;
            limitsds.lowHc = 0f;
            limitsds.highCo = 0f;
            limitsds.highHc = 0f;
            code = "";
            message = "";
            string sendString = ",Limit," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    try
                    {
                        limitsds.lowCo = double.Parse(vehicleInf[2]);
                        limitsds.lowHc = double.Parse(vehicleInf[3]);
                        limitsds.highCo = double.Parse(vehicleInf[4]);
                        limitsds.highHc = double.Parse(vehicleInf[5]);
                    }
                    catch
                    {
                        code = "0";
                        message = "数据格式有误";
                        return false;
                    }
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool GetLimit(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message, out limitLugdown limitlugdown)
        {
            limitlugdown = new limitLugdown();
            limitlugdown.ydxz = 0f;
            code = "";
            message = "";
            string sendString = ",Limit," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 5)
                {
                    try
                    {
                        limitlugdown.ydxz = double.Parse(vehicleInf[3]);
                    }
                    catch
                    {
                        code = "0";
                        message = "数据格式有误";
                        return false;
                    }
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool GetLimit(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message, out limitBtg limitbtg)
        {
            limitbtg = new limitBtg();
            limitbtg.ydxz = 0f;
            code = "";
            message = "";
            string sendString = ",Limit," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 5)
                {
                    try
                    {
                        limitbtg.ydxz = double.Parse(vehicleInf[3]);
                    }
                    catch
                    {
                        code = "0";
                        message = "数据格式有误";
                        return false;
                    }
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool SendInspectionBegin(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message)
        {
            code = "";
            message = "";
            string sendString = ",Inspection Begin," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool SendLimit(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message)
        {
            code = "";
            message = "";
            string sendString = ",Limit," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool SendInspectionEnd(string clhp, string hpzl, string jcbh, string jccs, out string code, out string message)
        {
            code = "";
            message = "";
            string sendString = ",Inspection End," + clhp + "," + hpzl + "," + jcbh + "," + jccs + ",";
            if (SendData(ConvertStringToByteArray(sendString)) < 0)
            {
                code = "0";
                message = "发送失败";
                return false;
            }
            Thread.Sleep(100);
            byte[] buffer = new byte[1024 * 1024];
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    code = "1";
                    message = "读取数据成功";
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        public bool WaitUploadFinish(out string code, out string message,out bool uploadOK)
        {
            code = "";
            message = "";
            uploadOK = false;
            string receivedString = "";
            if (RecvData(socket, out receivedString) > 0)
            {
                string[] vehicleInf = receivedString.Split(',');
                if (vehicleInf.Length >= 7)
                {
                    code = "1";
                    message = "读取数据成功";
                    if (vehicleInf[1] == "Upload OK")
                    {
                        uploadOK = true;
                    }
                    else
                    {
                        uploadOK = false;
                    }
                    return true;
                }
                else
                {
                    code = "0";
                    message = "返回数据不完整";
                    return false;
                }
            }
            else
            {
                code = "0";
                message = "无返回数据";
                return false;
            }
        }
        #region 创建文件夹
        public bool createDir(string strPath)
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
        public bool createFile(string strPath, string filename)
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
        public bool deleteDir(string strPath)
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
        public bool Write(string path,string filename,string content)
        {
            if (createDir(path))
            {
                FileStream fs = new FileStream(path+"\\"+filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.WriteLine(content);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                return true;
            }
            else
                return false;
        }
        public bool writeDataMainTxt(dataMainTxt datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.clhp + "\r\n";
            contentstring += datamaintxt.hpzl + "\r\n";
            contentstring += datamaintxt.vin + "\r\n";
            contentstring += datamaintxt.czy + "\r\n";
            contentstring += datamaintxt.jsy + "\r\n";
            contentstring += datamaintxt.wd + "\r\n";
            contentstring += datamaintxt.dqy + "\r\n";
            contentstring += datamaintxt.sd + "\r\n";
            contentstring += datamaintxt.jcsxh + "\r\n";
            contentstring += datamaintxt.cj + "\r\n";
            contentstring += datamaintxt.jccs + "\r\n";
            contentstring += datamaintxt.ljsxlc + "\r\n";
            contentstring += datamaintxt.lsh + "\r\n";
            contentstring += datamaintxt.jckssj + "\r\n";
            contentstring += datamaintxt.jcjssj + "\r\n";
            contentstring += datamaintxt.jyr+ "\r\n";
            contentstring += datamaintxt.jcbgbh + "\r\n";
            contentstring += datamaintxt.fdjh + "\r\n";
            contentstring += datamaintxt.zbzl + "\r\n";
            if (Write(@"D:\Exchange", "DataMain.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataMain.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDataResult(DataResultAsmTxt datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.hc5025xz + "\r\n";
            contentstring += datamaintxt.hc5025 + "\r\n";
            contentstring += datamaintxt.hc5025pd + "\r\n";
            contentstring += datamaintxt.hc2540xz + "\r\n";
            contentstring += datamaintxt.hc2540 + "\r\n";
            contentstring += datamaintxt.hc2540pd + "\r\n";
            contentstring += datamaintxt.co5025xz + "\r\n";
            contentstring += datamaintxt.co5025 + "\r\n";
            contentstring += datamaintxt.co5025pd + "\r\n";
            contentstring += datamaintxt.co2540xz + "\r\n";
            contentstring += datamaintxt.co2540 + "\r\n";
            contentstring += datamaintxt.co2540pd + "\r\n";
            contentstring += datamaintxt.no5025xz + "\r\n";
            contentstring += datamaintxt.no5025 + "\r\n";
            contentstring += datamaintxt.no5025pd + "\r\n";
            contentstring += datamaintxt.no2540xz + "\r\n";
            contentstring += datamaintxt.no2540 + "\r\n";
            contentstring += datamaintxt.no2540pd + "\r\n";
            if (Write(@"D:\Exchange", "DataResult.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataResult.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDataResult(DataResultSds datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.lambdaxz + "\r\n";
            contentstring += datamaintxt.lambda + "\r\n";
            contentstring += datamaintxt.lambdapd + "\r\n";
            contentstring += datamaintxt.colowxz + "\r\n";
            contentstring += datamaintxt.colow + "\r\n";
            contentstring += datamaintxt.colowpd + "\r\n";
            contentstring += datamaintxt.hclowxz + "\r\n";
            contentstring += datamaintxt.hclow + "\r\n";
            contentstring += datamaintxt.hclowpd + "\r\n";
            contentstring += datamaintxt.cohighxz + "\r\n";
            contentstring += datamaintxt.cohigh + "\r\n";
            contentstring += datamaintxt.cohighpd + "\r\n";
            contentstring += datamaintxt.hchighxz + "\r\n";
            contentstring += datamaintxt.hchigh + "\r\n";
            contentstring += datamaintxt.hchighpd + "\r\n";
            if (Write(@"D:\Exchange", "DataResult.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataResult.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDataResult(DataResultLugdown datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.ydxz + "\r\n";
            contentstring += datamaintxt.hk + "\r\n";
            contentstring += datamaintxt.nk + "\r\n";
            contentstring += datamaintxt.ek + "\r\n";
            contentstring += datamaintxt.lbgl + "\r\n";
            contentstring += datamaintxt.pd + "\r\n";
            if (Write(@"D:\Exchange", "DataResult.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataResult.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDataResult(DataResultLz datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.dszs + "\r\n";
            contentstring += datamaintxt.ydxz + "\r\n";
            contentstring += datamaintxt.firstdata + "\r\n";
            contentstring += datamaintxt.seconddata + "\r\n";
            contentstring += datamaintxt.thirddata + "\r\n";
            contentstring += datamaintxt.forthdata + "\r\n";
            contentstring += datamaintxt.averagedata + "\r\n";
            contentstring += datamaintxt.pd + "\r\n";
            if (Write(@"D:\Exchange", "DataResult.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataResult.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDataResult(DataResultBtg datamaintxt)
        {
            string contentstring = "";
            contentstring += datamaintxt.jcbh + "\r\n";
            contentstring += datamaintxt.dszs + "\r\n";
            contentstring += datamaintxt.ydxz + "\r\n";
            contentstring += datamaintxt.firstdata + "\r\n";
            contentstring += datamaintxt.seconddata + "\r\n";
            contentstring += datamaintxt.thirddata + "\r\n";
            contentstring += datamaintxt.averagedata + "\r\n";
            contentstring += datamaintxt.pd + "\r\n";
            if (Write(@"D:\Exchange", "DataResult.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = datamaintxt.jcbh + "_dataResult.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDatasecondsTxt(DataSecondsAsm dataseconds)
        {
            string contentstring = "";
            contentstring += dataseconds.jcbh + "\r\n";
            contentstring += dataseconds.mmsx + "\r\n";
            contentstring += dataseconds.mmhc + "\r\n";
            contentstring += dataseconds.mmco + "\r\n";
            contentstring += dataseconds.mmco2 + "\r\n";
            contentstring += dataseconds.mmno + "\r\n";
            contentstring += dataseconds.mmfxyo2 + "\r\n";
            contentstring += dataseconds.mmlljo2 + "\r\n";
            contentstring += dataseconds.mmsjll + "\r\n";
            contentstring += dataseconds.mmbzll + "\r\n";
            contentstring += dataseconds.mmwqll + "\r\n";
            contentstring += dataseconds.mmhczl + "\r\n";
            contentstring += dataseconds.mmcozl + "\r\n";
            contentstring += dataseconds.mmnozl + "\r\n";
            contentstring += dataseconds.mmcs + "\r\n";
            contentstring += dataseconds.mmfdjzs + "\r\n";
            contentstring += dataseconds.mmzjzgl + "\r\n";
            contentstring += dataseconds.mmjsgl + "\r\n";
            contentstring += dataseconds.mmzsgl + "\r\n";
            contentstring += dataseconds.mmlljyl + "\r\n";
            contentstring += dataseconds.mmlljwd + "\r\n";
            contentstring += dataseconds.mmwd + "\r\n";
            contentstring += dataseconds.mmdqy + "\r\n";
            contentstring += dataseconds.mmsd + "\r\n";
            contentstring += dataseconds.mmxsxzxs + "\r\n";
            contentstring += dataseconds.mmsdxzxs + "\r\n";
            contentstring += dataseconds.mmsxb + "\r\n";
            contentstring += dataseconds.mmjcsj + "\r\n";
            contentstring += dataseconds.jsjcff + "\r\n";
            contentstring += dataseconds.ksgkjs + "\r\n";
            if (Write(@"D:\Exchange", "DataSeconds.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = dataseconds.jcbh + "_dataSeconds.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
        public bool writeDatasecondsTxt(DataSecondLugdown dataseconds)
        {
            string contentstring = "";
            contentstring += dataseconds.jcbh + "\r\n";
            contentstring += dataseconds.mmsx + "\r\n";
            contentstring += dataseconds.CacuVelMaxHp + "\r\n";
            contentstring += dataseconds.RealVelMaxHp + "\r\n";
            contentstring += dataseconds.glsmmmgl + "\r\n";
            contentstring += dataseconds.glsmmmcs + "\r\n";
            contentstring += dataseconds.maxlbgl + "\r\n";
            contentstring += dataseconds.mmfdjzs + "\r\n";
            contentstring += dataseconds.mmwd + "\r\n";
            contentstring += dataseconds.mmdqy + "\r\n";
            contentstring += dataseconds.mmsd + "\r\n";
            contentstring += dataseconds.glxzsx + "\r\n";
            contentstring += dataseconds.xzzdlbgl + "\r\n";
            contentstring += dataseconds.mmhk + "\r\n";
            contentstring += dataseconds.mmnk + "\r\n";
            contentstring += dataseconds.mmek + "\r\n";
            contentstring += dataseconds.mmhkcs + "\r\n";
            contentstring += dataseconds.mmnkcs + "\r\n";
            contentstring += dataseconds.mmekcs + "\r\n";
            contentstring += dataseconds.dszs + "\r\n";
            contentstring += dataseconds.mmjcsj + "\r\n";
            contentstring += dataseconds.sjtb + "\r\n";
            if (Write(@"D:\Exchange", "DataSeconds.txt", contentstring))
            {
                try
                {
                    string filepath = "D:\\datarecords\\" + DateTime.Now.ToString("yyMMdd");
                    string pathname = dataseconds.jcbh + "_dataSeconds.txt";
                    Write(filepath, pathname, contentstring);
                }
                catch
                { }
                return true;
            }
            else
                return false;
        }
    }
}
