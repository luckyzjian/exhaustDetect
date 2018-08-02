using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.StubHelpers;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
using Detect;

namespace Daily
{
    public partial class Main : Form
    {
        MatchEvaluator me = delegate(Match m)
        {
            return "\n";
        };
        public delegate void wtgiss(DataGridView Grid, int Row, string Cell, string Content);          //委托
        public delegate void wtb(bool tf);                                                          //委托
        public delegate void wt_void();                                                             //委托
        public delegate void wtcs(Control controlname, string text);                                //委托
        public delegate void wtlsb(Label Msgowner, string Msgstr, bool Update_DB);                  //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                                 //委托
        public delegate void wtdd(DataGridView datagrid, DataTable dt);                             //委托
        
        public delegate void wtfs(float Data, string ChartName);                                    //委托
        public static float DIW = 907.2f;                                                           //DIW值
        public static float DIWF = 908f;                                                            //DIW飞轮等效惯量(由厂家提供)
        public Thread th_jsgcs = null;                                                              //寄生功率测试线程
        public Thread th_jzhx = null;                                                               //加载滑行测试线程
        public Thread th_gl = null;                                                                 //惯量测试线程
        public Thread th_bzhjz = null;                                                              //变载荷加载滑行测试线程
        public Thread th_xysj = null;                                                               //响应时间线程
        public Thread th_jzwc = null;                                                               //加载误差测试
        public Thread th_dglmn = null;                                                              //电惯量模拟误差测试
        public Thread th_jbglcs = null;                                                             //基本功能测试
        public bool Test_Flag = false;                                                              //是否有测试正在进行
        public static int Tscs = 0;                                                                 //提示次数
        public static Dynamometer.IGBT igbt = null;                                                 //测功机控制模块

        public TabPage page = null;                                                                 //当前激活的页   
        public float Speed = 0;                                                                     //车速
        public float Force = 0;                                                                     //扭矩
        public float Power = 0;                                                                     //功率
        public float Duty = 0;                                                                      //占空比
        public float Control_Speed = 0;                                                             //控制的速度
        public float Control_Force = 0;                                                             //控制的扭力
        public float Control_Power = 0;                                                             //控制的功率
        public static DataTable dt = null;                                                          //全局表
        public DataTable dt_bd = null;                                                              //标定时用的表
        public string pattern = @"^[0-9]*$";                                                        //正则表达式
        //说明文档
        public string File_Name1 = Application.StartupPath+ @"\Rem\寄生功率滑行测试.txt";
        public string File_Name2 = Application.StartupPath + @"\Rem\加载滑行测试.txt";
        public string File_Name3 = Application.StartupPath + @"\Rem\转动惯量等效汽车质量（DIW）测试.txt";
        public string File_Name4 = Application.StartupPath + @"\Rem\变载荷加载滑行测试.txt";
        public string File_Name5 = Application.StartupPath + @"\Rem\响应时间测试.txt";
        public string File_Name6 = Application.StartupPath + @"\Rem\电惯量准确度测试.txt";
        public string File_Name7 = Application.StartupPath + @"\Rem\加载误差测试.txt";
        public string File_Name8 = Application.StartupPath + @"\Rem\设备整体要求.txt";
        public string s;


        public System.IO.Ports.SerialPort ComPort_igbt;
        //public byte[] Send_Buffer;                                      //发送缓冲区
        public byte[] Read_Buffer;                                      //读取缓冲区
        public static string UseMK = "BNTD";                            //使用什么模块
        public string All_Content = "";                                   //没有解析过的返回数据
        public List<byte> All_Content_byte = new List<byte>();            //没有解析过的返回数据
        public string Speed_string = "0.0";                                    //实时速度
        public string Force_string = "0.0";                                    //实时扭矩
        public string Power_string = "0.0";                                    //实时功率
        public string Duty_string = "0.0";                                     //占空比(BNTD)
        public string Msg_received = "";                                         //消息
        public bool msg_back = false;

        //以下为新成BNTD专用变量
        public string Time_Vol_1 = "0.0";                               //实时电压值1通道(BNTD)
        public string Time_Vol_2 = "0.0";                               //实时电压值2通道(BNTD)
        public string Time_Vol_3 = "0.0";                               //实时电压值3通道(BNTD)
        public string Temperature = "0.0";                              //温度(BNTD)
        public string Humidity = "0.0";                                 //湿度(BNTD)
        public string ATM = "0.0";                                      //大气压(BNTD)
        public string b0 = "0.0";                                       //标定系数b0 1通道(BNTD)
        public string c0 = "0.0";                                       //标定系数c0 1通道(BNTD)
        public string b1 = "0.0";                                       //标定系数b1 2通道(BNTD)
        public string c1 = "0.0";                                       //标定系数c1 2通道(BNTD)
        public string b2 = "0.0";                                       //标定系数b2 3通道(BNTD)
        public string c2 = "0.0";                                       //标定系数c2 3通道(BNTD)
        public string kp = "0.0";                                       //速度PID参数P(BNTD)
        public string ki = "0.0";                                       //速度PID参数I(BNTD)
        public string kd = "0.0";                                       //速度PID参数D(BNTD)
        public string kp_force = "0.0";                                 //力PID参数P(BNTD)
        public string ki_force = "0.0";                                 //力PID参数I(BNTD)
        public string kd_force = "0.0";                                 //力PID参数D(BNTD)
        public string Speed_Diameter = "0.0";                           //滚筒直径
        public string Speed_Pusle = "0.0";                              //脉冲数
        

        bool Read_Flag = false;                                         //是否有数据可以读取
        private Thread Th_Lifter_Up = null;                             //举升上升线程
        public static Thread Th_Resolve = null;                         //解析线程
        public string Status = "time";                                  //IGBT状态 time——实时 Speed——恒速控制 Force——恒扭矩 Power——恒功率 Demarcate——标定 T——取环境参数(BNTD) F——取标定系数(BNTD) s——取速度PID控制参数(BNTD) f——取力PID控制参数(BNTD) S——取速度系数(BNTD) null——空闲
        public double sum = 0;
        enum testState
        {
            idle_state = 1, demarcate_state, hengding_state, jsgl_state
            ,jzhx_state,gl_state,bzhx_state,temp_state };
        private testState nowState = testState.idle_state;
        private testState preState = testState.idle_state;

        private bool timer_flag=false;//在惯量相关测试中用以标识速度已达最高点
        private bool testFinish = false;//用以判断惯量相关测试是否结束
        private double t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0;
        private double t11 = 0, t12 = 0, t13 = 0, t14 = 0, t15 = 0, t16 = 0, t17 = 0, t18 = 0, t19 = 0, t20 = 0;
        private double t21 = 0, t22 = 0, t23 = 0, t24 = 0, t25 = 0, t26 = 0, t27 = 0, t28 = 0, t29 = 0, t30 = 0;
        private double t31 = 0, t32 = 0, t33 = 0, t34 = 0, t35 = 0, t36 = 0, t37 = 0, t38 = 0, t39 = 0;
        private double t40 = 0, t41 = 0, t42 = 0, t43 = 0, t44 = 0;
        private byte glTestStep = 0;//在基本惯量测试中代表第glTestStep次滑行

     
        #region 初始化
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Init();
            //this.timer1.Enabled = true;
        }

        public void Init()
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            try
            {
                HJT291.Checked = true;
                radioButton_daily.Checked = true;
                string[] Com_Items = GetCommKeys();
                if (Com_Items != null)
                    comboBox_Comport.Items.AddRange(Com_Items);
                else
                    MessageBox.Show("没有发现本机串口", "初始化出错可能无法继续");
                ini.INIIO.GetPrivateProfileString("Com", "Comport", "Com1", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                comboBox_Comport.Text = temp.ToString();

                ini.INIIO.GetPrivateProfileString("Com", "Comstr", "9600,n,8,1", temp, 2048, @".\Config.ini");    //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                textBox_comstr.Text = temp.ToString();

                ini.INIIO.GetPrivateProfileString("DIW", "DIW", "907.2", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                textBox_zdgl.Text = temp.ToString();
                DIW = float.Parse(temp.ToString());

                ini.INIIO.GetPrivateProfileString("DIWF", "DIWF", "908", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                textBox__zdglf.Text = temp.ToString();
                DIWF = float.Parse(temp.ToString());

                ini.INIIO.GetPrivateProfileString("Tscs", "Tscs", "7", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                textBox11.Text = temp.ToString();
                Tscs = int.Parse(temp.ToString());

                ini.INIIO.GetPrivateProfileString("UseMK", "MK", "BNTD", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                UseMK = temp.ToString();
                switch (UseMK)
                {
                    case "IGBT":
                        break;
                    case "BNTD":
                        label1.Text = "占空";
                        break;
                    default:
                        break;
                }

                igbt = new Dynamometer.IGBT(UseMK);
                SerialPort ComPort_igbt = new SerialPort();
                ComPort_igbt.PortName = comboBox_Comport.Text.Trim();
                ComPort_igbt.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Ref_Readflag);
                igbt.Init_Comm(comboBox_Comport.Text.Trim(), textBox_comstr.Text.Trim());                           //初始化串口
                //timer2.Start();                                                                                     //实时刷新数据
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "初始化出错可能无法继续");
            }
        }
        #region 串口返回数据事件
        /// <summary>
        /// 当串口有返回数据事件时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Ref_Readflag(object sender, SerialDataReceivedEventArgs e)
        {
            ReadData();
            Resolve();
        }
        #endregion

        #region 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        public void ReadData()
        {
            try
            {
                Read_Buffer = new byte[ComPort_igbt.BytesToRead];
                ComPort_igbt.Read(Read_Buffer, 0, ComPort_igbt.BytesToRead);
                List<byte> buffer = Read_Buffer.ToList();
                All_Content_byte.AddRange(buffer.ToList());
                All_Content += Encoding.Default.GetString(buffer.ToArray());
            }
            catch (Exception)
            {
                ComPort_igbt.DiscardInBuffer();
            }
        }
        #endregion

        #region 串口返回数据解析
        /// <summary>
        /// 串口返回数据解析
        /// </summary>
        private void Resolve()
        {
            int start = 0;
            int end = 0;
            msg_back = false;
            float power = float.Parse(textBox_zsgl.Text);
            try
            {
                 if (All_Content_byte == null)
                 {
                      return;
                  }
                 if (All_Content_byte.Count > 0)
                 {
                     int temp_start1 = 0;
                     int temp_start2 = 0;
                            //bool msg_back = false;
                     temp_start1 = All_Content_byte.IndexOf(0x41);       //A
                     temp_start2 = All_Content_byte.IndexOf(0x44);       //D
                     if (temp_start2 < temp_start1 && temp_start2 != -1)
                     {
                            start = temp_start2;
                            msg_back = true;
                            end = All_Content_byte.IndexOf(0x43);//如果是调试信息，则以C结尾为结尾标志
                     }
                     else
                    {
                          start = temp_start1;
                          end = start + 16;
                    }
                    if (start == -1)
                    {
                         //没有开始符抛弃所有返回数据
                          All_Content_byte.Clear();
                          return;
                    }
                            //end = All_Content_byte.IndexOf(0x43);   //C
                            if (end == -1)
                                return;
                            if (end <= start)
                            {
                                All_Content_byte.RemoveRange(0, start + 1);
                                return;
                            }
                            if (msg_back)                   //解析的是消息
                            {
                                try
                                {
                                    Msg_received = Encoding.Default.GetString(All_Content_byte.ToArray(), start + 1, end - start - 1);
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    return;
                                }
                                catch (Exception)
                                {
                                }
                            }
                            string sd = Encoding.Default.GetString(All_Content_byte.ToArray(), start + 1, 2);
                            
                            switch (Encoding.Default.GetString(All_Content_byte.ToArray(), start + 1, 2))
                            {
                                case "DF":
                                    if (igbt.Status == "Demarcate")
                                    {
                                        Time_Vol_1 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                        Time_Vol_2 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                        Time_Vol_3 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString();
                                        All_Content_byte.RemoveRange(0, end + 1);
                                        switch (comboBox_bdtd.Text)
                                        {
                                            case "1":
                                                Msg(label_ad, panel_ad, igbt.Time_Vol_1, false);
                                                break;
                                            case "2":
                                                Msg(label_ad, panel_ad, igbt.Time_Vol_2, false);
                                                break;
                                            case "3":
                                                Msg(label_ad, panel_ad, igbt.Time_Vol_3, false);
                                                break;
                                        }
                                    }
                                    break;
                                case "BS":
                                    Speed_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Force_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    Duty_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    Power_string = ((float.Parse(Speed_string) / 3.6 * float.Parse(Force_string)) / 1000).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "BP":
                                    Speed_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Force_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    Duty_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    Power_string = ((float.Parse(Speed_string) / 3.6 * float.Parse(Force_string)) / 1000).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "BF":
                                    Speed_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Force_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    Duty_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    Power_string = ((float.Parse(Speed_string) / 3.6 * float.Parse(Force_string)) / 1000).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "BI":
                                    Speed_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Force_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    Duty_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    Power_string = ((float.Parse(Speed_string) / 3.6 * float.Parse(Force_string)) / 1000).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "II":
                                    byte[] ds = new byte[] { 0xff, 0xff, 0xff, 0xff };
                                    float sdd = BitConverter.ToSingle(ds, 0);
                                    Speed_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Force_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    Duty_string = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    Power_string = ((float.Parse(Speed_string) / 3.6 * float.Parse(Force_string)) / 1000).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "RT":
                                    Temperature = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                    Humidity = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                    ATM = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "Rs":
                                    kp = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                    ki = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                    kd = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString();
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "Rf":
                                    kp_force = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                    ki_force = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                    kd_force = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString();
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "RS":
                                    Speed_Diameter = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                    Speed_Pusle = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "RA":
                                    b0 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                    c0 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                    b1 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString();
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                case "RB":
                                    c1 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString();
                                    b2 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString();
                                    c2 = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString();
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                                default:
                                    try
                                    {
                                        //Speed = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 3).ToString("0.0");
                                        //Force = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 7).ToString("0.0");
                                        //Duty = BitConverter.ToSingle(All_Content_byte.ToArray(), start + 11).ToString("0.0");
                                        //Power = ((float.Parse(Speed) / 3.6 * float.Parse(Force)) / 1000).ToString("0.0");
                                        //All_Content_byte.RemoveRange(0, end + 1);
                                    }
                                    catch (Exception)
                                    {
                                        All_Content_byte.RemoveRange(0, end + 1);
                                    }
                                    //if (end - start == 32 || end - start == 33)
                                    //    Time_Results = All_Content.Substring(start, end - start);
                                    //if (All_Content.Substring(start, 1) == "@")
                                    //    Msg = All_Content.Substring(start, end - start);
                                    //if (All_Content.Substring(start, 1) == "#")
                                    //    Time_PID = All_Content.Substring(start, end - start);
                                    //All_Content_byte.RemoveRange(start, end);
                                    All_Content_byte.RemoveRange(0, end + 1);
                                    break;
                            }
                            Msg(Msg_cs, panel_cs, Speed_string, false);
                            Speed = (float)Convert.ToDouble(igbt.Speed);
                            Msg(Msg_nl, panel_nl, Force_string, false);
                            Force = (float)Convert.ToDouble(igbt.Force);
                            Msg(Msg_gl, panel_gl, Power_string, false);
                            Power = (float)Convert.ToDouble(igbt.Power);
                            Msg(Msg_dl, panel_cp, Duty_string, false);
                            Duty = (float)Convert.ToDouble(igbt.Duty);
                            Msg_toollabel(toolStripLabelMessage, panel_cs,Msg_received, false);
                            switch (nowState)
                            {
                                case testState.demarcate_state:
                                    switch (comboBox_bdtd.Text)
                                    {
                                         case "1":
                                             Msg(label_ad, panel_ad, igbt.Time_Vol_1, false);
                                             break;
                                         case "2":
                                             Msg(label_ad, panel_ad, igbt.Time_Vol_2, false);
                                             break;
                                         case "3":
                                             Msg(label_ad, panel_ad, igbt.Time_Vol_3, false);
                                             break;
                                    }
                                    break;
                                case testState.hengding_state:
                                    
                                    break;
                                case testState.jsgl_state:
                                    if (radioButton_check.Checked == true)
                                        {
                                            if (Speed > 96)
                                            {
                                                igbt.Motor_Close();
                                                timer_flag = true;
                                            }
                                            if (timer_flag == true)
                                            {
                                                if (Speed <= 92 && Speed >= 84)
                                                    t1 += 0.01;
                                                if (Speed < 84 && Speed >= 76)
                                                    t2 += 0.01;
                                                if (Speed < 76 && Speed >= 68)
                                                    t3 += 0.01;
                                                if (Speed < 68 && Speed >= 60)
                                                    t4 += 0.01;
                                                if (Speed < 60 && Speed >= 52)
                                                    t5 += 0.01;
                                                if (Speed < 52 && Speed >= 44)
                                                    t6 += 0.01;
                                                if (Speed < 44 && Speed >= 36)
                                                    t7 += 0.01;
                                                if (Speed < 36 && Speed >= 28)
                                                    t8 += 0.01;
                                                if (Speed < 28 && Speed >= 20)
                                                    t9 += 0.01;
                                                if (Speed < 20 && Speed >= 12)
                                                    t10 += 0.01;
                                                if (Speed < 12)
                                                {
                                                    testFinish = true;
                                                    nowState = testState.idle_state;
                                                    igbt.Exit_Control();
                                                }
                                            }

                                        }
                                    else
                                        {
                                            if (Speed > 56)
                                            {
                                                igbt.Motor_Close(); 
                                                timer_flag=true;
                                               
                                            }
                                            if (timer_flag == true)
                                            {
                                                if (Speed <= 51 && Speed >= 45)
                                                    t1 += 0.01;
                                                if (Speed <= 48 && Speed >= 32)
                                                    t2 += 0.01;
                                                if (Speed <= 40 && Speed >= 24)
                                                    t3 += 0.01;
                                                if (Speed <= 32 && Speed >= 16)
                                                    t4 += 0.01;
                                                if (Speed < 16)
                                                {
                                                    testFinish = true;
                                                    nowState = testState.idle_state;
                                                    igbt.Exit_Control();
                                                }

                                            }
                                       
                                        }
                                    break;
                                case testState.jzhx_state:
                                    if (radioButton_daily.Checked == true)
                                    {
                                        if(Speed>53)
                                        {
                                            timer_flag=true;
                                            igbt.Motor_Close();
                                        }
                                        if(timer_flag==true)
                                        {
                                            if (Speed <= 48 && Speed >= 32)
                                            {
                                                igbt.Set_Control_Power(power);
                                                //igbt.Start_Control_Power(); 
                                                t1 += 0.01;
                                            }
                                            if (Speed < 32 && Speed >= 16)
                                            {
                                                igbt.Set_Control_Power(power);
                                                t2 += 0.01;
                                            }
                                            if (Speed < 16) 
                                            {//区间记录完成
                                                testFinish=true;
                                                nowState=testState.idle_state;
                                                igbt.Exit_Control();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if(Speed>53)
                                        {
                                            timer_flag=true;
                                            igbt.Motor_Close();
                                        }
                                        if(timer_flag==true)
                                        {
                                            if (Speed <= 48 && Speed >= 32)
                                            {
                                                igbt.Set_Control_Power(power);
                                                //igbt.Start_Control_Power(); 
                                                t1 += 0.01;
                                            }
                                            if (Speed < 32 && Speed >= 16)
                                            {
                                                igbt.Set_Control_Power(power);
                                                t2 += 0.01;
                                            }
                                            if (Speed < 16) 
                                            {//区间记录完成
                                                testFinish=true;
                                                nowState=testState.idle_state;
                                                igbt.Exit_Control();
                                            }
                                        }
                                    }
                                    
                                    break;
                                case testState.gl_state:
                                    if (glTestStep < 7)
                                    {
                                        if (Speed >= 60)
                                        {
                                            igbt.Motor_Close();
                                            if (timer_flag == false) glTestStep++;
                                            timer_flag = true;
                                            igbt.Start_Control_Force();
                                        }
                                        if (timer_flag == true)
                                        {
                                            if (Speed >= 32.0 & Speed <= 48.0)
                                                t1 += 0.01;
                                            else if (Speed==0)//待到滚筒速度停下来
                                            {
                                                timer_flag = false;
                                                igbt.Exit_Control();
                                                switch (glTestStep)
                                                {
                                                    case 1:
                                                        t2 = t1;
                                                        igbt.Set_Control_Force(1170);
                                                        igbt.Motor_Open();
                                                        break;
                                                    case 2:
                                                        t3 = t1;
                                                        igbt.Set_Control_Force(540);
                                                        igbt.Motor_Open();
                                                        dataGrid_gl.Rows[0].Cells["6KW滑行时间(s)"].Value = t2.ToString();
                                                        dataGrid_gl.Rows[0].Cells["13KW滑行时间(s)"].Value = t3.ToString();
                                                        break;
                                                    case 3:
                                                        t4 = t1;
                                                        igbt.Set_Control_Force(1170);
                                                        igbt.Motor_Open();
                                                        break;
                                                    case 4:
                                                        t5 = t1;
                                                        igbt.Set_Control_Force(540);
                                                        igbt.Motor_Open();
                                                        dataGrid_gl.Rows[1].Cells["6KW滑行时间(s)"].Value = t2.ToString();
                                                        dataGrid_gl.Rows[1].Cells["13KW滑行时间(s)"].Value = t3.ToString();
                                                        break;
                                                    case 5:
                                                        t6 = t1;
                                                        igbt.Set_Control_Force(1170);
                                                        igbt.Motor_Open();
                                                        break;
                                                    case 6:
                                                        t7 = t1;
                                                        igbt.Set_Control_Force(0);
                                                        dataGrid_gl.Rows[2].Cells["6KW滑行时间(s)"].Value = t2.ToString();
                                                        dataGrid_gl.Rows[2].Cells["13KW滑行时间(s)"].Value = t3.ToString();
                                                        //igbt.Motor_Open();
                                                        nowState = testState.idle_state;
                                                        glTestStep = 0;
                                                        break;
                                                    default: break;
                                                }
                                                t1 = 0;
                                            }
                                        }
                                    }
                                    break;
                                case testState.bzhx_state:
                                    if(Speed>88.5)
                                    //while (true)                //等待达到预定速度
                                    {
                                       // if (Speed > 88.5)
                                        igbt.Motor_Close();
                                        timer_flag = true;
                                    }
                                    if(timer_flag==true)// igbt.Motor_Close();                         //达到速度关闭电机
                                    {
                                        if (Speed <= 80.5 && Speed >= 78.8)
                                        {
                                            igbt.Set_Control_Power(3.7f);
                                            t1 += 0.01;
                                        }
                                        if (Speed < 78.8 && Speed >= 77.2)
                                        {
                                            igbt.Set_Control_Power(4.4f);
                                            t2 += 0.01;
                                        }
                                        if (Speed < 77.2 && Speed >= 75.6)
                                        {
                                            igbt.Set_Control_Power(5.1f);
                                            t3 += 0.01;
                                        }
                                        if (Speed < 7.56 && Speed >= 74.0)
                                        {
                                            igbt.Set_Control_Power(5.9f);
                                            t4 += 0.01;
                                        }
                                        if (Speed < 74.0 && Speed >= 72.4)
                                        {
                                            igbt.Set_Control_Power(6.6f);
                                            t5 += 0.01;
                                        }
                                        if (Speed < 72.4 && Speed >= 70.8)
                                        {
                                            igbt.Set_Control_Power(7.4f);
                                            t6 += 0.01;
                                        }
                                        if (Speed < 70.8 && Speed >= 69.2)
                                        {
                                            igbt.Set_Control_Power(5.9f);
                                            t7 += 0.01;
                                        }
                                        if (Speed < 69.2 && Speed >= 67.6)
                                        {
                                            igbt.Set_Control_Power(7.4f);
                                            t8 += 0.01;
                                        }
                                        if (Speed < 67.6 && Speed >= 66.0)
                                        {
                                            igbt.Set_Control_Power(8.8f);
                                            t9 += 0.01;
                                        }
                                        if (Speed < 66.0 && Speed >= 64.4)
                                        {
                                            igbt.Set_Control_Power(10.3f);
                                            t10 += 0.01;
                                        }
                                        if (Speed < 64.4 && Speed >= 62.8)
                                        {
                                            igbt.Set_Control_Power(11.8f);
                                            t11 += 0.01;
                                        }
                                        if (Speed < 62.8 && Speed >= 61.1)
                                        {
                                            igbt.Set_Control_Power(13.2f);
                                            t12 += 0.01;
                                        }
                                        if (Speed < 61.1 && Speed >= 59.5)
                                        {
                                            igbt.Set_Control_Power(14.7f);
                                            t13 += 0.01;
                                        }
                                        if (Speed < 59.5 && Speed >= 57.9)
                                        {
                                            igbt.Set_Control_Power(15.4f);
                                            t14 += 0.01;
                                        }
                                        if (Speed < 57.9 && Speed >= 56.3)
                                        {
                                            igbt.Set_Control_Power(16.2f);
                                            t15 += 0.01;
                                        }
                                        if (Speed < 56.3 && Speed >= 54.7)
                                        {
                                            igbt.Set_Control_Power(16.9f);
                                            t16 += 0.01;
                                        }
                                        if (Speed < 54.7 && Speed >= 53.1)
                                        {
                                            igbt.Set_Control_Power(17.6f);
                                            t17 += 0.01;
                                        }
                                        if (Speed < 53.1 && Speed >= 51.5)
                                        {
                                            igbt.Set_Control_Power(18.4f);
                                            t18 += 0.1;
                                        }
                                        if (Speed < 51.5 && Speed >= 49.9)
                                        {
                                            igbt.Set_Control_Power(17.6f);
                                            t19 += 0.01;
                                        }
                                        if (Speed < 49.9 && Speed >= 48.3)
                                        {
                                            igbt.Set_Control_Power(16.9f);
                                            t20 += 0.1;
                                        }
                                        if (Speed < 48.3 && Speed >= 46.7)
                                        {
                                            igbt.Set_Control_Power(16.2f);
                                            t21 += 0.01;
                                        }
                                        if (Speed < 46.7 && Speed >= 45.1)
                                        {
                                            igbt.Set_Control_Power(15.4f);
                                            t22 += 0.01;
                                        }
                                        if (Speed < 45.1 && Speed >= 43.4)
                                        {
                                            igbt.Set_Control_Power(14.7f);
                                            t23 += 0.01;
                                        }
                                        if (Speed < 43.4 && Speed >= 41.8)
                                        {
                                            igbt.Set_Control_Power(13.2f);
                                            t24 += 0.01;
                                        }
                                        if (Speed < 41.8 && Speed >= 40.2)
                                        {
                                            igbt.Set_Control_Power(11.8f);
                                            t25 += 0.01;
                                        }
                                        if (Speed < 40.2 && Speed >= 38.6)
                                        {
                                            igbt.Set_Control_Power(10.3f);
                                            t26 += 0.01;
                                        }
                                        if (Speed < 38.6 && Speed >= 37.0)
                                        {
                                            igbt.Set_Control_Power(11.0f);
                                            t27 += 0.01;
                                        }
                                        if (Speed < 37.0 && Speed >= 35.4)
                                        {
                                            igbt.Set_Control_Power(11.8f);
                                            t28 += 0.01;
                                        }
                                        if (Speed < 35.4 && Speed >= 33.8)
                                        {
                                            igbt.Set_Control_Power(12.5f);
                                            t29 += 0.01;
                                        }
                                        if (Speed < 33.8 && Speed >= 32.2)
                                        {
                                            igbt.Set_Control_Power(13.2f);
                                            t30 += 0.01;
                                        }
                                        if (Speed < 32.2 && Speed >= 30.6)
                                        {
                                            igbt.Set_Control_Power(12.5f);
                                            t31 += 0.01;
                                        }
                                        if (Speed < 30.6 && Speed >= 29.0)
                                        {
                                            igbt.Set_Control_Power(11.8f);
                                            t32 += 0.01;
                                        }
                                        if (Speed < 29.0 && Speed >= 27.4)
                                        {
                                            igbt.Set_Control_Power(11.0f);
                                            t33 += 0.01;
                                        }
                                        if (Speed < 27.4 && Speed >= 25.7)
                                        {
                                            igbt.Set_Control_Power(10.3f);
                                            t34 += 0.01;
                                        }
                                        if (Speed < 25.7 && Speed >= 24.1)
                                        {
                                            igbt.Set_Control_Power(8.8f);
                                            t35 += 0.01;
                                        }
                                        if (Speed < 24.1 && Speed >= 22.5)
                                        {
                                            igbt.Set_Control_Power(7.4f);
                                            t36 += 0.01;
                                        }
                                        if (Speed < 22.5 && Speed >= 20.9)
                                        {
                                            igbt.Set_Control_Power(8.1f);
                                            t37 += 0.01;
                                        }
                                        if (Speed < 20.9 && Speed >= 19.3)
                                        {
                                            igbt.Set_Control_Power(8.8f);
                                            t33 += 0.01;
                                        }
                                        if (Speed < 19.3 && Speed >= 17.7)
                                        {
                                            igbt.Set_Control_Power(8.1f);
                                            t38 += 0.01;
                                        }
                                        if (Speed < 17.7 && Speed >= 16.1)
                                        {
                                            igbt.Set_Control_Power(7.4f);
                                            t39 += 0.01;
                                        }
                                        if (Speed < 16.1 && Speed >= 14.5)
                                        {
                                            igbt.Set_Control_Power(6.6f);
                                            t40 += 0.01;
                                        }
                                        if (Speed < 14.5 && Speed >= 12.9)
                                        {
                                            igbt.Set_Control_Power(5.9f);
                                            t41 += 0.01;
                                        }
                                        if (Speed < 12.9 && Speed >= 11.3)
                                        {
                                            igbt.Set_Control_Power(5.1f);
                                            t42 += 0.01;
                                        }
                                        if (Speed < 11.3 && Speed >= 9.7)
                                        {
                                            igbt.Set_Control_Power(4.4f);
                                            t43 += 0.01;
                                        }
                                        if (Speed < 9.7 && Speed >= 8.0)
                                        {
                                            igbt.Set_Control_Power(3.7f);
                                            t44 += 0.01;
                                        }
                                        if (Speed < 8.0)                                       //区间记录完成
                                        {
                                            testFinish = true;
                                            nowState = testState.idle_state;
                                            
                                        }
                                        igbt.Start_Control_Power();                            //启动功率控制
                                    }
                                    break;
                                default: break;

                            }
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            All_Content_byte.RemoveRange(0, end + 1);
                        }
                        catch (Exception)
                        {
                            All_Content_byte.Clear();
                        }
                    }

        }
        #endregion
        public static string[] GetCommKeys()
        {
            string[] values = null;
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey hs = hklm.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
                if (hs != null)
                {
                    values = new string[hs.ValueCount];
                    for (int i = 0; i < hs.ValueCount; i++)
                    {
                        values[i] = hs.GetValue(hs.GetValueNames()[i]).ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return values;
        }
        #endregion

        #region 信息显示
        /// <summary>
        /// 信息显示
        /// </summary>
        /// <param name="Msgowner">信息显示的Label控件</param>
        /// <param name="Msgfather">Label控件的父级Panel</param>
        /// <param name="Msgstr">要显示的信息</param>
        /// <param name="Update_DB">是不是要更新到检测状态</param>
        public void Msg(Label Msgowner, Panel Msgfather, string Msgstr, bool Update_DB)
        {
            BeginInvoke(new wtlsb(Msg_Show), Msgowner, Msgstr, Update_DB);
            BeginInvoke(new wtlp(Msg_Position), Msgowner, Msgfather);
        }
        public void Msg_toollabel(ToolStripLabel Msgowner, Panel Msgfather, string Msgstr, bool Update_DB)
        {
            Msgowner.Text = Msgstr;
            //BeginInvoke(new wtlsb(Msg_Show), Msgowner, Msgstr, Update_DB);
           // BeginInvoke(new wtlp(Msg_Position), Msgowner, Msgfather);
        }

        public void Msg_Show(Label Msgowner, string Msgstr, bool Update_DB)
        {
            Msgowner.Text = Msgstr;
            if (Update_DB)
            {
                //CarWait.bjcl.JCZT = Msgstr;
                //CarWait.bjclxx.Update(CarWait.bjcl);
            }
        }

        public void Msg_Position(Label Msgowner, Panel Msgfather)
        {
            if (Msgowner.Width < Msgfather.Width)
                Msgowner.Location = new Point((Msgfather.Width - Msgowner.Width) / 2, Msgowner.Location.Y);
            else
                Msgowner.Location = new Point(0, Msgowner.Location.Y);
        }

        /// <summary>
        /// 刷新控件的文字信息
        /// </summary>
        /// <param name="control">控件名称</param>
        /// <param name="text">文字信息</param>
        public void Ref_Control_Text(Control control, string text)
        {
            BeginInvoke(new wtcs(ref_Control_Text), control, text);
        }

        public void ref_Control_Text(Control control, string text)
        {
            control.Text = text;
        }
        #endregion

        #region 设置
        private void button_savepz_Click(object sender, EventArgs e)
        {
            if (ini.INIIO.WritePrivateProfileString("Com", "Comstr", textBox_comstr.Text.Trim(), @".\Config.ini") && ini.INIIO.WritePrivateProfileString("Com", "Comport", comboBox_Comport.Text.Trim(), @".\Config.ini"))
            {
                MessageBox.Show("保存成功", "系统提示");
                try
                {
                    igbt.Close_Com();
                    igbt.Init_Comm(comboBox_Comport.Text.Trim(), textBox_comstr.Text.Trim());         //重新初始化串口
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString(), "系统出错，可能无法继续");
                }
            }
        }

        private void button_savezdgl_Click(object sender, EventArgs e)
        {
            try
            {
                if ((ini.INIIO.WritePrivateProfileString("DIW", "DIW", textBox_zdgl.Text.Trim(), @".\Config.ini")) && (ini.INIIO.WritePrivateProfileString("DIWF", "DIWF", textBox__zdglf.Text.Trim(), @".\Config.ini")))
                {
                    DIW = float.Parse(textBox_zdgl.Text.Trim());
                    DIWF = float.Parse(textBox__zdglf.Text.Trim());
                    MessageBox.Show("保存成功", "系统提示");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString(), "出错");
            }
        }

        private void button_szcs_Click(object sender, EventArgs e)
        {
            try
            {
                if (ini.INIIO.WritePrivateProfileString("Tscs", "Tscs", textBox11.Text.Trim(), @".\Config.ini"))
                {
                    Tscs = int.Parse(textBox11.Text.Trim());
                    MessageBox.Show("保存成功", "系统提示");
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString(), "出错");
            }
        }
        #endregion

        #region 基本功能测试(Test Complete1)

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage_2_Enter(object sender, EventArgs e)
        {
            jbgl_exe();
            jbgl1_exe();
        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void jbgl_exe()
        {
            radioButton_gzms1.Checked = true;
            label72.Text = "km/h";
        }
        public void jbgl1_exe()
        {
            try
            {
                Random random = new Random();
                for (int pointIndex = 0; pointIndex < 10; pointIndex++)
                {
                    chart_jbgl.Series["功率"].Points.AddY(random.Next(45, 45));
                    chart_jbgl.Series["速度"].Points.AddY(random.Next(35, 35));
                    chart_jbgl.Series["扭力"].Points.AddY(random.Next(25, 25));
                }
                try
                {
                    th_jbglcs.Abort();
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("初始化错误", "系统提示");
            }
        }
        private void radioButton_gzms1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_gzms1.Checked)
            {
                label72.Text = "km/h";
                radioButton_gzms2.Checked = false;
                radioButton_gzms4.Checked = false;
            }
        }

        private void radioButton_gzms2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_gzms2.Checked)
            {
                label72.Text = "N";
                radioButton_gzms1.Checked = false;
                radioButton_gzms4.Checked = false;
            }
        }


        private void radioButton_gzms4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_gzms4.Checked)
            {
                label72.Text = "Kw";
                radioButton_gzms1.Checked = false;
                radioButton_gzms2.Checked = false;
            }
        }
        //每隔一定时间需要执行的函数体,timer start后每隔一秒就会执行该函数
        //Control.CheckForIllegalCrossThreadCalls = false;
        //chart_jbgl.Series["速度"].ChartType = SeriesChartType.Spline;
        //chart_jbgl.Series["扭力"].ChartType = SeriesChartType.Spline;
        //chart_jbgl.Series["功率"].ChartType = SeriesChartType.Spline;
        private void Ref_Chart_th()
        {
            while (true)
            {
                try
                {
                    Ref_Chart(Speed, "速度");
                    Ref_Chart(Force, "扭力");
                    Ref_Chart(Power, "功率");
                }
                catch (Exception)
                {
                    //MessageBox.Show("没有相关数据", "出错啦");
                    //return;
                }
                Thread.Sleep(100);
            }
        }

        //曲线暂停和曲线继续
        private void button_qxzt_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_qxzt.Text == "曲线暂停")
                {
                    try
                    {
                        th_jbglcs.Abort();
                    }
                    catch (Exception)
                    {
                    }
                    button_qxzt.Text = "曲线继续";
                }
                else if (button_qxzt.Text == "曲线继续")
                {
                    th_jbglcs = new Thread(Ref_Chart_th);
                    th_jbglcs.Start();
                    button_qxzt.Text = "曲线暂停";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("退出系统，重新启动", "系统提示");
            }
        }
        public void ref_chart_data(float Data, string SeriesName)
        {
            try
            {
                chart_jbgl.Series[SeriesName].Points.AddY(Data);
            }
            catch (Exception)
            {

            }
        }
        public void Ref_Chart(float Data, string SeriesName)
        {
            Invoke(new wtfs(ref_chart_data), Data, SeriesName);
        }

        public void clear_chart_data()
        {
            try
            {
                foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chart_jbgl.Series)
                    series.Points.Clear();
            }
            catch (Exception)
            {

            }
        }
        public void Clear_Chart()
        {
            BeginInvoke(new wt_void(clear_chart_data));
        }

        //开始发送参数
        private void button_csfs_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    float.Parse(textBox_cs.Text.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                th_jbglcs = new Thread(Ref_Chart_th);
                th_jbglcs.Start();
                Test_Flag = true;
                //确定恒速度
                chart_jbgl.Series["速度"].BorderWidth = 1;
                chart_jbgl.Series["扭力"].BorderWidth = 1;
                chart_jbgl.Series["功率"].BorderWidth = 1;
                if (radioButton_gzms1.Checked)
                {
                    chart_jbgl.Series["速度"].BorderWidth = 3;
                    Control_Speed = float.Parse(textBox_cs.Text.ToString());
                    igbt.Exit_Control();                                             //IGBT退出所有控制
                    igbt.Set_Speed(Control_Speed);                                   //设置恒速度值
                    igbt.Start_Control_Speed();                                      //启动恒速度控制
                        
                }
                if (radioButton_gzms2.Checked)
                {
                    chart_jbgl.Series["扭力"].BorderWidth = 3;
                    Control_Force = float.Parse(textBox_cs.Text.ToString());
                    igbt.Exit_Control();                                             //IGBT退出所有控制
                    igbt.Set_Speed(Control_Force);                                   //设置恒速度值
                    igbt.Start_Control_Force();                                      //启动恒速度控制
                }
                if (radioButton_gzms4.Checked)
                {
                    chart_jbgl.Series["功率"].BorderWidth = 3;
                    Control_Power = float.Parse(textBox_cs.Text.ToString());
                    igbt.Exit_Control();                                             //IGBT退出所有控制
                    igbt.Set_Control_Power(Control_Power);                                   //设置恒速度值
                    igbt.Start_Control_Power();                                      //启动恒速度控制
                }
                nowState = testState.hengding_state;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入参数", "系统提示");
            }
        }

        //清除曲线
        private void button_qcqx_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chart_jbgl.Series)        //清空
                {
                    series.Points.Clear();
                }
                button_csfs.Enabled = true;
                button_qxzt.Text = "曲线暂停";
                textBox_cs.Enabled = true;
                radioButton_gzms1.Enabled = true;
                radioButton_gzms2.Enabled = true;
                radioButton_gzms4.Enabled = true;
                textBox_cs.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("系统错误，请重新启动", "系统提示");
            }
        }
        #endregion

        #region 寄生功率测试(Test Complete1)


        private void tabPage_3_Enter(object sender, EventArgs e)
        {
            if (!Test_Flag)                               //判定是否有测试正在进行
            {
                if (page != tabPage_3)
                {
                    jsg_Init_Other();
                }
                jsg_Init_Limit();
                jsg_Init_Chart();
            }
            page = tabPage_3;
        }

        /// <summary>
        /// 初始化限值
        /// </summary>
        public void jsg_Init_Limit()
        {
        }

        /// <summary>
        /// 初始化图表
        /// </summary>
        public void jsg_Init_Chart()
        {
        }

        /// <summary>
        /// 初始化其他
        /// </summary>
        public void jsg_Init_Other()
        {
            dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("速度区间（Km/h）");
            dt.Columns.Add("名义速度（Km/h）");
            dt.Columns.Add("滑行时间（s）");
            dt.Columns.Add("寄生功率（Kw）");
            if (radioButton_daily.Checked == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    dr = dt.NewRow();
                    if (i == 0)
                    {
                        dr["速度区间（Km/h）"] = (51 - i * 8).ToString() + "-" + (53 - (i + 1) * 8).ToString();
                    }
                    else
                    {
                        dr["速度区间（Km/h）"] = (56 - i * 8).ToString() + "-" + (56 - (i + 2) * 8).ToString();
                    }
                    dr["名义速度（Km/h）"] = (48 - i * 8).ToString();
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    dr = dt.NewRow();
                    dr["速度区间（Km/h）"] = (92 - i * 8).ToString() + "-" + (92 - (i + 1) * 8).ToString();
                    dr["名义速度（Km/h）"] = (88 - i * 8).ToString();
                    dt.Rows.Add(dr);
                }
            }
            dataGrid_jsgl.DataSource = dt;

        }

        private void button_start_jsg_Click(object sender, EventArgs e)
        {
            if (!Test_Flag)                             //判断是不是有测试正在进行
            {
                th_jsgcs = new Thread(Jsgcs_exe);       //新建线程
                th_jsgcs.Start();                       //线程开始执行
                testFinish = false;                     //测试还未结束
                timer_flag = false;
                Test_Flag = true;                       //正在测试的标记置为true 表示有测试正在进行
                tabControl1.Enabled = false;            //设置不能在页面中切换
                button_start_jsg.Text = "重新开始";
                nowState = testState.jsgl_state;
            }
            else
                MessageBox.Show("有测试正在进行，无法开始测试", "系统提示");
        }

        private void button_JsglText_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name1);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");
            }
        }
        /// <summary>
        /// 寄生功率测试
        /// </summary>
        public void Jsgcs_exe()
        {
            
            double jsgl1 = 0, jsgl2 = 0, jsgl3 = 0, jsgl4 = 0, jsgl5 = 0, jsgl6 = 0, jsgl7 = 0, jsgl8 = 0, jsgl9 = 0, jsgl10 = 0;
            igbt.Lifter_Down();         //下降举升
            Thread.Sleep(2000);         //等待2秒
            igbt.Motor_Open();          //启动电机加速
            while (testFinish == false)
            {
                Thread.Sleep(100);         //等待2秒
            }
            igbt.Exit_Control();
           //计算
                if (radioButton_daily.Checked)
                {
                    jsgl1 = Math.Round(0.00123457 * 48 * DIW / t1, 1);
                    jsgl2 = Math.Round(0.00123457 * 40 * DIW / t2, 1);
                    jsgl3 = Math.Round(0.00123457 * 32 * DIW / t3, 1);
                    jsgl4 = Math.Round(0.00123457 * 24 * DIW / t4, 1);
                }
                else
                {
                    jsgl1 = Math.Round(0.00061728 * 88 * DIW / t1, 1);
                    jsgl2 = Math.Round(0.00061728 * 80 * DIW / t2, 1);
                    jsgl3 = Math.Round(0.00061728 * 72 * DIW / t3, 1);
                    jsgl4 = Math.Round(0.00061728 * 64 * DIW / t4, 1);
                    jsgl5 = Math.Round(0.00061728 * 56 * DIW / t5, 1);
                    jsgl6 = Math.Round(0.00061728 * 48 * DIW / t6, 1);
                    jsgl7 = Math.Round(0.00061728 * 40 * DIW / t7, 1);
                    jsgl8 = Math.Round(0.00061728 * 32 * DIW / t8, 1);
                    jsgl9 = Math.Round(0.00061728 * 24 * DIW / t9, 1);
                    jsgl10 = Math.Round(0.00061728 * 16 * DIW / t10, 1);
                }
                //显示和记录

                dataGrid_jsgl.Rows[0].Cells["滑行时间（s）"].Value = t1.ToString("0.00");
                dataGrid_jsgl.Rows[0].Cells["寄生功率（Kw）"].Value = jsgl1.ToString("0.00");
                dataGrid_jsgl.Rows[1].Cells["滑行时间（s）"].Value = t2.ToString("0.00");
                dataGrid_jsgl.Rows[1].Cells["寄生功率（Kw）"].Value = jsgl2.ToString("0.00");
                dataGrid_jsgl.Rows[2].Cells["滑行时间（s）"].Value = t3.ToString("0.00");
                dataGrid_jsgl.Rows[2].Cells["寄生功率（Kw）"].Value = jsgl3.ToString("0.00");
                dataGrid_jsgl.Rows[3].Cells["滑行时间（s）"].Value = t4.ToString("0.00");
                dataGrid_jsgl.Rows[3].Cells["寄生功率（Kw）"].Value = jsgl4.ToString("0.00");


                if (!radioButton_daily.Checked)
                {
                    dataGrid_jsgl.Rows[4].Cells["滑行时间（s）"].Value = t5.ToString("0.00");
                    dataGrid_jsgl.Rows[4].Cells["寄生功率（Kw）"].Value = jsgl5.ToString("0.00");
                    dataGrid_jsgl.Rows[5].Cells["滑行时间（s）"].Value = t6.ToString("0.00");
                    dataGrid_jsgl.Rows[5].Cells["寄生功率（Kw）"].Value = jsgl6.ToString("0.00");
                    dataGrid_jsgl.Rows[6].Cells["滑行时间（s）"].Value = t7.ToString("0.00");
                    dataGrid_jsgl.Rows[6].Cells["寄生功率（Kw）"].Value = jsgl7.ToString("0.00");
                    dataGrid_jsgl.Rows[7].Cells["滑行时间（s）"].Value = t8.ToString("0.00");
                    dataGrid_jsgl.Rows[7].Cells["寄生功率（Kw）"].Value = jsgl8.ToString("0.00");
                    dataGrid_jsgl.Rows[8].Cells["滑行时间（s）"].Value = t9.ToString("0.00");
                    dataGrid_jsgl.Rows[8].Cells["寄生功率（Kw）"].Value = jsgl9.ToString("0.00");
                    dataGrid_jsgl.Rows[9].Cells["滑行时间（s）"].Value = t10.ToString("0.00");
                    dataGrid_jsgl.Rows[9].Cells["寄生功率（Kw）"].Value = jsgl10.ToString("0.00");

                }
                if (radioButton_daily.Checked)
                {
                    Ref_Control_Text(label_24jsg, jsgl4.ToString("0.00"));
                    Ref_Control_Text(label_40jsg, jsgl2.ToString("0.00"));
                }
                else
                {
                    Ref_Control_Text(label_24jsg, jsgl9.ToString("0.00"));
                    Ref_Control_Text(label_40jsg, jsgl7.ToString("0.00"));
                }
                //写文件
                if (radioButton_daily.Checked)
                {
                    ini.INIIO.WritePrivateProfileString("寄生功率(日常测试)", "48Km/h", jsgl1.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(日常测试)", "40Km/h", jsgl2.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(日常测试)", "32Km/h", jsgl3.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(日常测试)", "24Km/h", jsgl4.ToString("0.00"), @".\Config.ini");
                }
                else
                {
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "88Km/h", jsgl1.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "80Km/h", jsgl2.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "72Km/h", jsgl3.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "64Km/h", jsgl4.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "56Km/h", jsgl5.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "48Km/h", jsgl6.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "40Km/h", jsgl7.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "32Km/h", jsgl8.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "24Km/h", jsgl9.ToString("0.00"), @".\Config.ini");
                    ini.INIIO.WritePrivateProfileString("寄生功率(核准)", "16Km/h", jsgl10.ToString("0.00"), @".\Config.ini");
                }
                Thread.Sleep(3000);         //等待滚筒停止
                igbt.Lifter_Up();           //测试完成举升上升
                this.BeginInvoke(new wtb(Set_tab_Enabled), true);       //设置能在页面中切换
                Test_Flag = false;          //重置正在测试的标记
         }




        private void button_jsgqx_Click(object sender, EventArgs e)
        {
            if (chart_jsg.Visible)
            {
                chart_jsg.Visible = false;
                button_jsgqx.Text = "寄生功曲线";
            }
            else
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chart_jsg.Series)        //清空
                {
                    series.Points.Clear();
                }

                System.Windows.Forms.DataVisualization.Charting.DataPoint jsg_point = null;
                if (radioButton_daily.Checked)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ini.INIIO.GetPrivateProfileString("寄生功率(日常测试)", (24 + 8 * i).ToString() + "Km/h", "Empty", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                        if (temp.ToString() == "Empty")
                        {
                            MessageBox.Show("没有相关数据", "出错啦");
                            return;
                        }
                        jsg_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24 + 8 * i, temp.ToString());
                        chart_jsg.Series["xsgl_qx"].Points.Add(jsg_point);
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ini.INIIO.GetPrivateProfileString("寄生功率(核准)", (16 + 8 * i).ToString() + "Km/h", "Empty", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                        if (temp.ToString() == "Empty")
                        {
                            MessageBox.Show("没有相关数据", "出错啦");
                            return;
                        }
                        jsg_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(16 + 8 * i, temp.ToString());
                        chart_jsg.Series["xsgl_qx"].Points.Add(jsg_point);
                    }
                }
                chart_jsg.Visible = true;
                button_jsgqx.Text = "隐藏曲线";
            }
        }
        #endregion

        #region 加载滑行试验(Test Complete1)
        private void tabPage_4_Enter(object sender, EventArgs e)
        {
            if (!Test_Flag)                               //判定是否有测试正在进行
            {
                if (page != tabPage_4)
                {
                    DataGridView_jzhx();
                }
            }
            page = tabPage_4;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void DataGridView_jzhx()
        {
            dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("速度区间(km/h)");
            dt.Columns.Add("名义速度(km/h)");
            dt.Columns.Add("寄生功率(Kw)");
            dt.Columns.Add("计算时间CCDT(s)");
            dt.Columns.Add("实测时间ACDT(s)");
            dt.Columns.Add("误差");
            dt.Columns.Add("判定");
            if (radioButton_daily.Checked == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    dr = dt.NewRow();
                    dr["速度区间（Km/h）"] = (48 - i * 16).ToString() + "-" + (48 - (i + 1) * 16).ToString();
                    dr["名义速度（Km/h）"] = (40 - i * 16).ToString();
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    dr = dt.NewRow();
                    dr["速度区间（Km/h）"] = (48 - i * 16).ToString() + "-" + (48 - (i + 1) * 16).ToString();
                    dr["名义速度（Km/h）"] = (40 - i * 16).ToString();
                    dt.Rows.Add(dr);
                }
            }
            dataGrid_jzhx.DataSource = dt;
        }

        /// <summary>
        /// 输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_zsgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsContaintDot = this.textBox_zsgl.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContaintDot && (e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 开始按钮
        /// </summary>
        private void button_jzks_Click(object sender, EventArgs e)
        {

            if (!Test_Flag)                                           //判断是不是有测试正在进行
            {
                th_jzhx = new Thread(Jzhx_exe);                       //新建线程
                th_jzhx.Start();                                      //线程开始执行
                testFinish = false;
                timer_flag = false;
                Test_Flag = true;                                     //正在测试的标记置为true 表示有测试正在进行
                tabControl1.Enabled = false;                          //设置不能在页面中切换
                button_jzks.Text = "重新开始";
                nowState = testState.jzhx_state;

            }
            else
                MessageBox.Show("有测试正在进行，无法开始测试", "系统提示");
        }

        private void button_JzhxText_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name2);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");
            }
        }
        /// <summary>
        /// 加载滑行测试
        /// </summary>
        /// 
        public void Jzhx_exe()
        {
            //double t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            double CCDT1 = 0, CCDT2 = 0, CCDT3 = 0, CCDT4 = 0;
            double PLHP1 = 0, PLHP2 = 0, PLHP3 = 0, PLHP4 = 0;
            double result1 = 0, result2 = 0, result3 = 0, result4 = 0;
            string r1 = "", r2 = "";
            
            igbt.Lifter_Down();         //下降举升
            Thread.Sleep(2000);         //等待2秒
            igbt.Motor_Open();          //启动电机加速
            
            while(testFinish == false)
            {
                Thread.Sleep(100);
            }
            igbt.Exit_Control();
            //testFinish = true;
            t1 = Math.Round(t1, 1);
            t2 = Math.Round(t2, 1);
            t3 = Math.Round(t3, 1);
            t4 = Math.Round(t4, 1);
            if (radioButton_daily.Checked == true)
            {
                    PLHP1 = Math.Round(0.00123457 * 40 * DIW / t1, 1);
                    PLHP2 = Math.Round(0.00123457 * 24 * DIW / t2, 1);
                }
                else
                {
                    PLHP3 = Math.Round(0.00061728 * 40 * DIW / t3, 1);
                    PLHP4 = Math.Round(0.00061728 * 24 * DIW / t4, 1);
                }
                //计算
                string d = textBox_zsgl.Text;  //指示功率
                try
                {
                    if (radioButton_daily.Checked == true)
                    {
                        CCDT1 = (Math.Round(DIW * (48 * 48 - 32 * 32) / (2000 * (Convert.ToDouble(d) + PLHP1)), 1)) / 10;
                        CCDT2 = (Math.Round((DIW * (32 * 32 - 16 * 16)) / (2000 * (Convert.ToDouble(d) + PLHP2)), 1)) / 10;

                        result1 = Math.Round(Math.Abs(CCDT1 - t1) / CCDT1, 2);
                        result2 = Math.Round(Math.Abs(CCDT2 - t2) / CCDT2, 2);

                    }
                    else
                    {
                        CCDT3 = (Math.Round((DIW * (48 * 48 - 32 * 32)) / (2000 * (Convert.ToDouble(d) + PLHP3)), 1)) / 10;
                        CCDT4 = (Math.Round((DIW * (32 * 32 - 16 * 16)) / (2000 * (Convert.ToDouble(d) + PLHP4)), 1)) / 10;

                        result3 = Math.Round(Math.Abs(t3 - CCDT3) / CCDT3, 2);
                        result4 = Math.Round(Math.Abs(t4 - CCDT4) / CCDT4, 2);

                    }
                    //误差可以扩大到10%
                    if (radioButton_daily.Checked == true)
                    {
                        if (result1 <= 0.1)
                        { r1 = "合格"; }
                        else
                        { r1 = "不合格"; }
                        if (result2 <= 0.1)
                        { r2 = "合格"; }
                        else
                        { r2 = "不合格"; }
                    }
                    else
                    {

                        if (result3 <= 0.1)
                        { r1 = "合格"; }
                        else
                        { r1 = "不合格"; }
                        if (result4 <= 0.1)
                        { r2 = "合格"; }
                        else
                        { r2 = "不合格"; }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString(), "出错啦");
                }

                //显示
                if (radioButton_daily.Checked == true)
                {
                    dataGrid_jzhx.Rows[0].Cells["寄生功率(Kw)"].Value = PLHP1.ToString();
                    dataGrid_jzhx.Rows[0].Cells["计算时间CCDT(s)"].Value = CCDT1.ToString();
                    dataGrid_jzhx.Rows[0].Cells["实测时间ACDT(s)"].Value = t1.ToString();
                    dataGrid_jzhx.Rows[0].Cells["误差"].Value = result1.ToString();
                    dataGrid_jzhx.Rows[0].Cells["判定"].Value = r1.ToString();

                    dataGrid_jzhx.Rows[1].Cells["寄生功率(Kw)"].Value = PLHP2.ToString();
                    dataGrid_jzhx.Rows[1].Cells["计算时间CCDT(s)"].Value = CCDT2.ToString();
                    dataGrid_jzhx.Rows[1].Cells["实测时间ACDT(s)"].Value = t2.ToString();
                    dataGrid_jzhx.Rows[1].Cells["误差"].Value = result2.ToString();
                    dataGrid_jzhx.Rows[1].Cells["判定"].Value = r2.ToString();
                }
                else
                {
                    dataGrid_jzhx.Rows[0].Cells["寄生功率(Kw)"].Value = PLHP3.ToString();
                    dataGrid_jzhx.Rows[0].Cells["计算时间CCDT(s)"].Value = CCDT3.ToString();
                    dataGrid_jzhx.Rows[0].Cells["实测时间ACDT(s)"].Value = t3.ToString();
                    dataGrid_jzhx.Rows[0].Cells["误差"].Value = result3.ToString();
                    dataGrid_jzhx.Rows[0].Cells["判定"].Value = r1.ToString();

                    dataGrid_jzhx.Rows[1].Cells["寄生功率(Kw)"].Value = PLHP4.ToString();
                    dataGrid_jzhx.Rows[1].Cells["计算时间CCDT(s)"].Value = CCDT4.ToString();
                    dataGrid_jzhx.Rows[1].Cells["实测时间ACDT(s)"].Value = t4.ToString();
                    dataGrid_jzhx.Rows[1].Cells["误差"].Value = result4.ToString();
                    dataGrid_jzhx.Rows[1].Cells["判定"].Value = r2.ToString();
                }
                Thread.Sleep(3000);         //等待滚筒停止
                igbt.Lifter_Up();           //测试完成举升上升
                igbt.Exit_Control();
                this.BeginInvoke(new wtb(Set_tab_Enabled), true);       //设置能在页面中切换
                Test_Flag = false;
                          //重置正在测试的标记 
                        
        }

        //判定是否合格
        //public string Pd_Exe(double result1, double result2, double result3, double result4)
        //{
        //    if (radioButton_daily.Checked == true)
        //    {
        //        if ((result1 <= 0.1) && (result2 <= 0.1))
        //              return "合格";                  
        //    }

        //    else
        //    {
        //        if ((result3 <= 0.1) && (result4 <= 0.1))
        //             return "合格";
        //    }
        //    return "";
        //}
        //调用到达一定次数后锁止程序
        public void Locked()
        {
            //锁止程序
        }
        #endregion

        #region 惯量测试(Test Complete1)

        //初始化
        private void tabPage_5_Enter(object sender, EventArgs e)
        {
            if (!Test_Flag)                               //判定是否有测试正在进行
            {
                if (page != tabPage_5)
                {
                    dataGridView_gl();
                }
            }
            page = tabPage_5;
        }

        public void dataGridView_gl()
        {
            dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("次数");
            dt.Columns.Add("滑行区间(km/h)");
            dt.Columns.Add("6KW滑行时间(s)");
            dt.Columns.Add("13KW滑行时间(s)");
            dt.Columns.Add("标称(kg)");
            dt.Columns.Add("实测(kg)");
            dt.Columns.Add("误差");
            dt.Columns.Add("判定");
            for (int i = 0; i < 3; i++)
            {
                dr = dt.NewRow();
                dr["标称(kg)"] = "907.2";
                dt.Rows.Add(dr);
                dr["滑行区间(km/h)"]="48~32";
                dt.Rows.Add(dr);
                dr["次数"]=Convert.ToString(i+1);
                dt.Rows.Add(dr);
            }
            dataGrid_gl.DataSource = dt;
        }

        //开始测试
        private void button_lgks_Click(object sender, EventArgs e)
        {
            if (radioButton_check.Checked == true)
            {
                if (!Test_Flag)                             //判断是不是有测试正在进行
                {
                    th_gl = new Thread(gl_exe);             //新建线程
                    th_gl.Start();                          //线程开始执行
                    testFinish = false;
                    nowState = testState.gl_state;
                    timer_flag = false;
                    Test_Flag = true;                       //正在测试的标记置为true 表示有测试正在进行
                    tabControl1.Enabled = false;            //设置不能在页面中切换
                    button_lgks.Text = "重新开始";
                }
                else
                    MessageBox.Show("有测试正在进行，无法开始测试", "系统提示");
            }
            else
            {
                MessageBox.Show("惯量测试是核准测试内容，请在“设置”页面的“测试类型设置”中选择“核准测试”", "系统提示");
            }
        }
        private void button_glText_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name3);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");
            }
        }

        //惯量测试
        public void gl_exe()
        {

            double limit_DIW_1 = 925.3;          //上限
            double limit_DIW_2 = 889.1;          //下限
            double DIW1 = 0;
            double wc = 0;
            string r1 = "";
            //double t1 = 0;                 //正常结构状态下（48-32）km/h滑行时间
            //double t2 = 0;                 //拆去飞轮结构状态下（48-32）km/h滑行时间
            igbt.Lifter_Down();         //下降举升
            Thread.Sleep(2000);         //等待2秒
            igbt.Motor_Open();          //启动电机加速
            igbt.Set_Control_Force(540);//第一次加载540N的力。
            while (testFinish == false)
            {
                Thread.Sleep(100);
            }
            igbt.Exit_Control();
            //计算
            try
            {
                //DIWF = float.Parse(textBox__zdglf.Text);                       //得到厂家提供的飞轮的转动惯量
                DIW1 = Math.Round(2000*7 *( t2+t4+t6)*(t3+t5+t7) / (9.0*98.765*(( t2+t4+46)-(t3+t5+t7))), 1);
                wc = Math.Round(DIW1 - DIW, 1);
                wc = Math.Abs(wc);
                if (DIW1 <= limit_DIW_1 && DIW1 >= limit_DIW_2 && wc <= 4.5)
                {
                    r1 = "合格";
                }
                else
                {
                    r1 = "不合格";
                }
                dataGrid_gl.Rows[2].Cells["实测(kg)"].Value = DIW1.ToString();
                dataGrid_gl.Rows[2].Cells["误差"].Value = wc.ToString();
                dataGrid_gl.Rows[2].Cells["判定"].Value = r1;

            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
            }
            //显示
            

           // Thread.Sleep(3000);         //等待滚筒停止
            igbt.Lifter_Up();           //测试完成举升上升
            this.BeginInvoke(new wtb(Set_tab_Enabled), true);       //设置能在页面中切换
            Test_Flag = false;          //重置正在测试的标记 
        }
        #endregion

        #region 变载荷加载滑行试验(Test Complete1)
        //初始化
        private void tabPage_6_Enter(object sender, EventArgs e)
        {
            if (!Test_Flag)                               //判定是否有测试正在进行
            {
                if (page != tabPage_6)
                {
                    Datagridview_bzhjzhx();
                }
            }
            page = tabPage_6;
        }

        public void Datagridview_bzhjzhx()
        {
            dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("初速度(km/h)");
            dt.Columns.Add("末速度(km/h)");
            dt.Columns.Add("名义时间(s)");
            dt.Columns.Add("实测时间(s)");
            dt.Columns.Add("误差");
            dt.Columns.Add("验收标准");
            dt.Columns.Add("结果");
            dr = dt.NewRow();
            dr["初速度(km/h）"] = 80.5.ToString();
            dr["末速度(km/h）"] = 8.ToString();
            dr["名义时间(s）"] = 25.77.ToString();
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["初速度(km/h）"] = 72.4.ToString();
            dr["末速度(km/h）"] = 16.1.ToString();
            dr["名义时间(s）"] = 15.54.ToString();
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["初速度(km/h）"] = 61.1.ToString();
            dr["末速度(km/h）"] = 43.4.ToString();
            dr["名义时间(s）"] = 3.98.ToString();
            dt.Rows.Add(dr);
            dataGrid_bzhjzhx.DataSource = dt;
        }

        //开始测试按钮
        private void button_bzhjz_Click(object sender, EventArgs e)
        {
            if (radioButton_check.Checked == true)
            {
                if (!Test_Flag)                             //判断是不是有测试正在进行
                {
                    th_bzhjz = new Thread(bzhjz_exe);       //新建线程
                    th_bzhjz.Start();                       //线程开始执行
                    timer_flag = false;
                    testFinish = false;
                    nowState = testState.bzhx_state;
                    Test_Flag = true;                       //正在测试的标记置为true 表示有测试正在进行
                    tabControl1.Enabled = false;            //设置不能在页面中切换
                    button_bzhjz.Text = "重新开始";
                }
                else
                    MessageBox.Show("有测试正在进行，无法开始测试", "系统提示");
            }
            else
            {
                MessageBox.Show("变载荷加载测试是核准测试内容，请在“设置”页面的“测试类型设置”中选择“核准测试”", "系统提示");
            }
        }

        private void button_bzhjzhxText_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name4);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");
            }
        }
        //变载荷加载滑行试验
        public void bzhjz_exe()
        {
            
            double tm1 = 25.77, tm2 = 15.54, tm3 = 3.98;           //标准
            double ts1 = 0, ts2 = 0, ts3 = 0;
            double result1 = 0, result2 = 0, result3 = 0;
            double Standard1 = 0.04, Standard2 = 0.02, Standard3 = 0.03;             //误差
            string r1 = "", r2 = "", r3 = "";
            //igbt.Exit_Control();        //退出所有控制
            igbt.Lifter_Down();         //下降举升
            Thread.Sleep(2000);         //等待2秒
            igbt.Motor_Open();          //启动电机加速
            while (testFinish == false)
            {
                Thread.Sleep(100);
            }
            igbt.Exit_Control();
            try
            {
                ts1 = t1 + t2 + t3 + t4 + t5 + t6 + t7 + t8 + t9 + t10 +
                   t11 + t12 + t13 + t14 + t15 + t16 + t17 + t18 + t19 + t20 +
                   t21 + t22 + t23 + t24 + t25 + t26 + t27 + t28 + t29 + t30 +
                   t31 + t32 + t33 + t34 + t35 + t36 + t37 + t38 + t39 +
                   t40 + t41 + t42 + t43 + t44;
                ts2 = t6 + t7 + t8 + t9 + t10 +
                    t11 + t12 + t13 + t14 + t15 + t16 + t17 + t18 + t19 + t20 +
                    t21 + t22 + t23 + t24 + t25 + t26 + t27 + t28 + t29 + t30 +
                    t31 + t32 + t33 + t34 + t35 + t36 + t37 + t38;
                ts3 = t13 + t14 + t15 + t16 + t17 + t18 + t19 + t20 +
                    t21 + t22;
                ts1 = Math.Round(ts1, 2) * 10;
                ts2 = Math.Round(ts2, 2) * 10;
                ts3 = Math.Round(ts3, 2) * 10;
                result1 = Math.Abs(ts1 - tm1) / ts1;
                result2 = Math.Abs(ts2 - tm2) / ts2;
                result3 = Math.Abs(ts3 - tm3) / ts3;

                result1 = Math.Round(result1, 2);
                result2 = Math.Round(result2, 2);
                result3 = Math.Round(result3, 2);

                if ((result1 <= Standard1))
                {
                    r1 = "合格";
                }
                else
                {
                    r1 = "不合格";
                }
                if ((result2 <= Standard2))
                {
                    r2 = "合格";
                }
                else
                {
                    r2 = "不合格";
                }
                if ((result3 <= Standard3))
                {
                    r3 = "合格";
                }
                else
                {
                    r3 = "不合格";
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            //显示和记录

            dataGrid_bzhjzhx.Rows[0].Cells["实测时间(s)"].Value = ts1.ToString();
            dataGrid_bzhjzhx.Rows[0].Cells["误差"].Value = result1.ToString();
            dataGrid_bzhjzhx.Rows[0].Cells["验收标准"].Value = 0.04;
            dataGrid_bzhjzhx.Rows[0].Cells["结果"].Value = r1.ToString();


            dataGrid_bzhjzhx.Rows[1].Cells["实测时间(s)"].Value = ts2.ToString();
            dataGrid_bzhjzhx.Rows[1].Cells["误差"].Value = result2.ToString();
            dataGrid_bzhjzhx.Rows[1].Cells["验收标准"].Value = 0.02;
            dataGrid_bzhjzhx.Rows[1].Cells["结果"].Value = r2.ToString();


            dataGrid_bzhjzhx.Rows[2].Cells["实测时间(s)"].Value = ts3.ToString();
            dataGrid_bzhjzhx.Rows[2].Cells["误差"].Value = result3.ToString();
            dataGrid_bzhjzhx.Rows[2].Cells["验收标准"].Value = 0.03;
            dataGrid_bzhjzhx.Rows[2].Cells["结果"].Value = r3.ToString();



            //写文件
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "80.5Km/h", 3.7f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "78.8Km/h", 4.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "77.2Km/h", 5.1f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "75.6Km/h", 5.9f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "74.1Km/h", 6.6f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "72.4Km/h", 7.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "70.8Km/h", 5.9f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "69.2Km/h", 7.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "67.6Km/h", 8.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "66.1Km/h", 10.3f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "64.4Km/h", 11.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "62.8Km/h", 13.2f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "61.1Km/h", 14.7f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "59.5Km/h", 15.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "57.9Km/h", 16.2f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "56.3Km/h", 16.9f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "54.7Km/h", 17.6f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "53.1Km/h", 18.4f.ToString(), @".\Config.ini");

            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "51.5Km/h", 17.6f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "49.9Km/h", 16.9f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "48.3Km/h", 16.2f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "46.7Km/h", 15.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "45.1Km/h", 14.7f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "43.4Km/h", 13.2f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "41.8Km/h", 11.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "40.2Km/h", 10.3f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "38.6Km/h", 11.0f.ToString(), @".\Config.ini");

            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "37.1Km/h", 11.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "35.4Km/h", 12.5f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "33.8Km/h", 13.2f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "32.2Km/h", 12.5f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "30.6Km/h", 11.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "29.1Km/h", 11.0f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "27.4Km/h", 10.3f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "25.7Km/h", 8.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "24.1Km/h", 7.4f.ToString(), @".\Config.ini");

            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "22.5Km/h", 8.1f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "20.9Km/h", 8.8f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "19.3Km/h", 8.1f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "17.7Km/h", 7.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "16.1Km/h", 6.6f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "14.5Km/h", 5.9f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "12.9Km/h", 5.1f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "11.3Km/h", 4.4f.ToString(), @".\Config.ini");
            ini.INIIO.WritePrivateProfileString("变载荷加载(核准)", "9.7Km/h", 3.7f.ToString(), @".\Config.ini");

            //结束操作
            Thread.Sleep(3000);         //等待滚筒停止
            igbt.Lifter_Up();           //测试完成举升上升
            //tabControl1.Enabled = true; //设置能在页面中切换
            this.BeginInvoke(new wtb(Set_tab_Enabled), true);       //设置能在页面中切换
            Test_Flag = false;          //重置正在测试的标记
        }

        //显示曲线
        private void button_xsqx_Click(object sender, EventArgs e)
        {
            if (chart_bzhjz.Visible)
            {
                chart_bzhjz.Visible = false;
                button_xsqx.Text = "显示曲线";
            }
            else
            {
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chart_bzhjz.Series)        //清空
                {
                    series.Points.Clear();
                }

                System.Windows.Forms.DataVisualization.Charting.DataPoint bzhjz_point = null;
                //public static extern int GetPrivateProfileString(string strAppName, string strKeyName, string strDefault, StringBuilder sbReturnString, int nSize, string strFileName);//读配置文件 string（段名，字段，默认值，保存的strbuilder，大小，路径）
                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (80.5).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");  //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(80.5, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (78.8).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(78.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (77.2).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(77.2, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (75.6).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(75.6, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (74.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(74.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (72.4).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(72.4, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (70.8).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(70.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (69.2).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(69.2, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (67.6).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(67.6, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (66.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(66.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (64.4).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(64.4, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (62.8).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(62.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (61.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(61.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (59.5).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(59.5, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (57.9).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(57.9, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (56.3).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(56.3, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (54.7).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(54.7, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (53.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(53.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (51.5).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(51.5, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (49.9).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(49.9, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (48.3).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(48.3, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (46.7).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(46.7, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (45.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (43.4).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(43.4, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (41.8).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (40.2).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40.2, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (38.6).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(38.6, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (37.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(37.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (35.4).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(35.4, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (33.8).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(33.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (32.2).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(32.2, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (30.6).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30.6, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (29.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(29.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (27.4).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(27.4, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (25.7).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25.7, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (24.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (22.5).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(22.5, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (20.9).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20.9, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (19.3).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(19.3, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (17.7).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(17.7, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (16.1).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(16.1, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (14.5).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(14.5, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (12.9).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(11.8, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (11.3).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(12.9, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                ini.INIIO.GetPrivateProfileString("变载荷加载(核准)", (9.7).ToString() + "km/h", "Empty", temp, 2048, @".\Config.ini");
                bzhjz_point = new System.Windows.Forms.DataVisualization.Charting.DataPoint(9.7, temp.ToString());
                chart_bzhjz.Series["bzhjz_qx"].Points.Add(bzhjz_point);

                if (temp.ToString() == "Empty")
                {
                    MessageBox.Show("没有相关数据", "出错啦");
                    return;
                }
                chart_bzhjz.Visible = true;
                button_xsqx.Text = "隐藏曲线";
            }

        }
        #endregion()

        #region 加载误差测试(Test Complete1)
        /// <summary>
        /// 初始化
        /// </summary>
        private void tabPage_9_Enter(object sender, EventArgs e)
        {
            if (!Test_Flag)                               //判定是否有测试正在进行
            {
                if (page != tabPage_9)
                {
                    Jzwc_Init();
                }
            }
            page = tabPage_9;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Jzwc_Init()
        {
            dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("编号");
            dt.Columns.Add("速度区间Km/h");
            dt.Columns.Add("名义速度Km/h");
            dt.Columns.Add("IHP(Kw)");
            dt.Columns.Add("PLHP(Kw)");
            dt.Columns.Add("CCDT(s)");
            dt.Columns.Add("ACDT(s)");
            dt.Columns.Add("误差");
            dt.Columns.Add("结果");
            for (int i = 0; i < 12; i++)
            {
                dr = dt.NewRow();
                dr["编号"] = (i + 1).ToString();
                dr["速度区间Km/h"] = "48 - 24";
                dr["名义速度Km/h"] = "36";
                dt.Rows.Add(dr);
            }
            dataGrid_jzwc.DataSource = dt;
        }

        /// <summary>
        /// 加载功率（IHP）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_IHP_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.textBox_IHP.Text, pattern);
            if (!m.Success)
            {
                MessageBox.Show("请输入数字！", "警告!!!");
                textBox_IHP.Text = "";
                return;
            }
        }

        //测试按钮
        private void button_jzwc_Click(object sender, EventArgs e)
        {
            if (radioButton_check.Checked)
            {
                if (!Test_Flag)                                           //判断是不是有测试正在进行
                {
                    th_jzwc = new Thread(Jzwc_exe);                        //新建线程  
                    th_jzwc.Start();                                      //线程开始执行
                    Test_Flag = true;                                     //正在测试的标记置为true 表示有测试正在进行
                    tabControl1.Enabled = false;                          //设置不能在页面中切换
                    button_jzwc.Text = "重新开始";
                }
                else
                    MessageBox.Show("有测试正在进行，无法开始测试", "系统提示");
            }
            else
            {
                MessageBox.Show("加载误差测试是核准测试内容，请在“设置”页面的“测试类型设置”中选择“核准测试”", "系统提示");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name7);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");

            }
        }
        public void Jzwc_exe()
        {
            //初始化
            double t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0, t12 = 0; ; ;                 //实际时间
            double CCDT1 = 0, CCDT2 = 0, CCDT3 = 0, CCDT4 = 0, CCDT5 = 0, CCDT6 = 0, CCDT7 = 0, CCDT8 = 0, CCDT9 = 0, CCDT10 = 0, CCDT11 = 0, CCDT12 = 0;              //计算时间 
            double PLHP1 = 0, PLHP2 = 0, PLHP3 = 0, PLHP4 = 0, PLHP5 = 0, PLHP6 = 0, PLHP7 = 0, PLHP8 = 0, PLHP9 = 0, PLHP10 = 0, PLHP11 = 0, PLHP12 = 0;              //寄生功率
            double result1 = 0, result2 = 0, result3 = 0, result4 = 0, result5 = 0, result6 = 0, result7 = 0, result8 = 0, result9 = 0, result10 = 0, result11 = 0, result12 = 0;            //误差
            string r1 = "";

            //启动仪器
            igbt.Lifter_Down();         //下降举升
            Thread.Sleep(2000);         //等待2秒
            igbt.Motor_Open();          //启动电机加速
            while (true)                //等待达到预定速度
            {
                if (Speed > 56.3)
                    break;
            }
            igbt.Motor_Close();
            while (true)
            {
                if (dataGrid_jzwc.CurrentCell.RowIndex == 0)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t1 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 1)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t2 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 2)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t3 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 3)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t4 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 4)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t5 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 5)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t6 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 6)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t7 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 7)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t8 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 8)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t9 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 9)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t10 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 10)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t11 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 11)
                {
                    if (Speed <= 48 && Speed >= 24)
                    {
                        igbt.Set_Control_Power(float.Parse(textBox_IHP.Text));
                        t12 += 0.1;
                    }
                    if (Speed < 20)                                       //区间记录完成
                    {
                        break;
                    }
                    igbt.Start_Control_Power();                           //启动功率控制
                    Thread.Sleep(100);
                }
            }
            PLHP1 = Math.Round(0.00061728 * 36 * DIW / t1, 1);
            PLHP2 = Math.Round(0.00061728 * 36 * DIW / t2, 1);
            PLHP3 = Math.Round(0.00061728 * 36 * DIW / t3, 1);
            PLHP4 = Math.Round(0.00061728 * 36 * DIW / t4, 1);
            PLHP5 = Math.Round(0.00061728 * 36 * DIW / t5, 1);
            PLHP6 = Math.Round(0.00061728 * 36 * DIW / t6, 1);
            PLHP7 = Math.Round(0.00061728 * 36 * DIW / t7, 1);
            PLHP8 = Math.Round(0.00061728 * 36 * DIW / t8, 1);
            PLHP9 = Math.Round(0.00061728 * 36 * DIW / t9, 1);
            PLHP10 = Math.Round(0.00061728 * 36 * DIW / t10, 1);
            PLHP11 = Math.Round(0.00061728 * 36 * DIW / t11, 1);
            PLHP12 = Math.Round(0.00061728 * 36 * DIW / t12, 1);
            //计算
            string f = textBox_IHP.Text.Trim();
            try
            {
                if (dataGrid_jzwc.CurrentCell.RowIndex == 0)
                {
                    CCDT1 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP1)), 1)) / 10; //计算时间
                    result1 = Math.Abs(CCDT1 - t1) / CCDT1;
                    result1 = Math.Round(result1, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result1 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result1 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result1 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[0].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[0].Cells["PLHP(Kw)"].Value = PLHP1.ToString();
                    dataGrid_jzwc.Rows[0].Cells["CCDT(s)"].Value = CCDT1.ToString();
                    dataGrid_jzwc.Rows[0].Cells["ACDT(s)"].Value = t1.ToString();
                    dataGrid_jzwc.Rows[0].Cells["误差"].Value = result1.ToString();
                    dataGrid_jzwc.Rows[0].Cells["结果"].Value = r1.ToString();
                }

                if (dataGrid_jzwc.CurrentCell.RowIndex == 1)
                {
                    CCDT2 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP2)), 1)) / 10; //计算时间
                    result2 = Math.Abs(CCDT2 - t2) / CCDT2;
                    result2 = Math.Round(result2, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result2 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result2 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result2 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[1].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[1].Cells["PLHP(Kw)"].Value = PLHP2.ToString();
                    dataGrid_jzwc.Rows[1].Cells["CCDT(s)"].Value = CCDT2.ToString();
                    dataGrid_jzwc.Rows[1].Cells["ACDT(s)"].Value = t2.ToString();
                    dataGrid_jzwc.Rows[1].Cells["误差"].Value = result2.ToString();
                    dataGrid_jzwc.Rows[1].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 2)
                {
                    CCDT3 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP3)), 1)) / 10; //计算时间
                    result3 = Math.Abs(CCDT3 - t3) / CCDT3;
                    result3 = Math.Round(result3, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result3 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result3 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result3 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[2].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[2].Cells["PLHP(Kw)"].Value = PLHP3.ToString();
                    dataGrid_jzwc.Rows[2].Cells["CCDT(s)"].Value = CCDT3.ToString();
                    dataGrid_jzwc.Rows[2].Cells["ACDT(s)"].Value = t3.ToString();
                    dataGrid_jzwc.Rows[2].Cells["误差"].Value = result3.ToString();
                    dataGrid_jzwc.Rows[2].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 3)
                {
                    CCDT4 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP4)), 1)) / 10; //计算时间
                    result4 = Math.Abs(CCDT4 - t4) / CCDT4;
                    result4 = Math.Round(result4, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result4 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result4 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result4 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[3].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[3].Cells["PLHP(Kw)"].Value = PLHP4.ToString();
                    dataGrid_jzwc.Rows[3].Cells["CCDT(s)"].Value = CCDT4.ToString();
                    dataGrid_jzwc.Rows[3].Cells["ACDT(s)"].Value = t4.ToString();
                    dataGrid_jzwc.Rows[3].Cells["误差"].Value = result4.ToString();
                    dataGrid_jzwc.Rows[3].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 4)
                {
                    CCDT5 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP5)), 1)) / 10; //计算时间
                    result5 = Math.Abs(CCDT5 - t5) / CCDT5;
                    result5 = Math.Round(result5, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result5 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result5 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result5 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[4].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[4].Cells["PLHP(Kw)"].Value = PLHP5.ToString();
                    dataGrid_jzwc.Rows[4].Cells["CCDT(s)"].Value = CCDT5.ToString();
                    dataGrid_jzwc.Rows[4].Cells["ACDT(s)"].Value = t5.ToString();
                    dataGrid_jzwc.Rows[4].Cells["误差"].Value = result5.ToString();
                    dataGrid_jzwc.Rows[4].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 5)
                {
                    CCDT6 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP6)), 1)) / 10; //计算时间
                    result6 = Math.Abs(CCDT6 - t6) / CCDT6;
                    result6 = Math.Round(result6, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result6 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result6 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result6 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[5].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[5].Cells["PLHP(Kw)"].Value = PLHP6.ToString();
                    dataGrid_jzwc.Rows[5].Cells["CCDT(s)"].Value = CCDT6.ToString();
                    dataGrid_jzwc.Rows[5].Cells["ACDT(s)"].Value = t6.ToString();
                    dataGrid_jzwc.Rows[5].Cells["误差"].Value = result6.ToString();
                    dataGrid_jzwc.Rows[5].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 6)
                {
                    CCDT7 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP7)), 1)) / 10; //计算时间
                    result7 = Math.Abs(CCDT7 - t7) / CCDT7;
                    result7 = Math.Round(result7, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result7 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result7 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result7 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[6].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[6].Cells["PLHP(Kw)"].Value = PLHP7.ToString();
                    dataGrid_jzwc.Rows[6].Cells["CCDT(s)"].Value = CCDT7.ToString();
                    dataGrid_jzwc.Rows[6].Cells["ACDT(s)"].Value = t7.ToString();
                    dataGrid_jzwc.Rows[6].Cells["误差"].Value = result7.ToString();
                    dataGrid_jzwc.Rows[6].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 7)
                {
                    CCDT8 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP8)), 1)) / 10; //计算时间
                    result8 = Math.Abs(CCDT8 - t8) / CCDT8;
                    result8 = Math.Round(result8, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result8 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result8 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result8 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[7].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[7].Cells["PLHP(Kw)"].Value = PLHP8.ToString();
                    dataGrid_jzwc.Rows[7].Cells["CCDT(s)"].Value = CCDT8.ToString();
                    dataGrid_jzwc.Rows[7].Cells["ACDT(s)"].Value = t8.ToString();
                    dataGrid_jzwc.Rows[7].Cells["误差"].Value = result8.ToString();
                    dataGrid_jzwc.Rows[7].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 8)
                {
                    CCDT9 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP9)), 1)) / 10; //计算时间
                    result9 = Math.Abs(CCDT9 - t9) / CCDT9;
                    result9 = Math.Round(result9, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result9 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result9 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result9 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[8].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[8].Cells["PLHP(Kw)"].Value = PLHP9.ToString();
                    dataGrid_jzwc.Rows[8].Cells["CCDT(s)"].Value = CCDT9.ToString();
                    dataGrid_jzwc.Rows[8].Cells["ACDT(s)"].Value = t9.ToString();
                    dataGrid_jzwc.Rows[8].Cells["误差"].Value = result9.ToString();
                    dataGrid_jzwc.Rows[8].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 9)
                {
                    CCDT10 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP10)), 1)) / 10; //计算时间
                    result10 = Math.Abs(CCDT10 - t10) / CCDT10;
                    result10 = Math.Round(result10, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result10 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result10 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result10 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[9].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[9].Cells["PLHP(Kw)"].Value = PLHP10.ToString();
                    dataGrid_jzwc.Rows[9].Cells["CCDT(s)"].Value = CCDT10.ToString();
                    dataGrid_jzwc.Rows[9].Cells["ACDT(s)"].Value = t10.ToString();
                    dataGrid_jzwc.Rows[9].Cells["误差"].Value = result10.ToString();
                    dataGrid_jzwc.Rows[9].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 10)
                {
                    CCDT11 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP11)), 1)) / 10; //计算时间
                    result11 = Math.Abs(CCDT11 - t11) / CCDT11;
                    result11 = Math.Round(result11, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result11 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result11 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result11 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[10].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[10].Cells["PLHP(Kw)"].Value = PLHP11.ToString();
                    dataGrid_jzwc.Rows[10].Cells["CCDT(s)"].Value = CCDT11.ToString();
                    dataGrid_jzwc.Rows[10].Cells["ACDT(s)"].Value = t11.ToString();
                    dataGrid_jzwc.Rows[10].Cells["误差"].Value = result11.ToString();
                    dataGrid_jzwc.Rows[10].Cells["结果"].Value = r1.ToString();
                }
                if (dataGrid_jzwc.CurrentCell.RowIndex == 11)
                {
                    CCDT12 = (Math.Round((DIW * 1728) / (2000 * (int.Parse(f) + PLHP12)), 1)) / 10; //计算时间
                    result12 = Math.Abs(CCDT12 - t12) / CCDT12;
                    result12 = Math.Round(result12, 2);
                    //条件
                    if (int.Parse(f) == 4)
                    {
                        if (result12 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 18)
                    {
                        if (result12 <= 0.04)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    else if (int.Parse(f) == 11)
                    {
                        if (result12 <= 0.02)
                        {
                            r1 = "合格";
                        }
                        else
                        {
                            r1 = "不合格";
                        }
                    }
                    dataGrid_jzwc.Rows[11].Cells["IHP(Kw)"].Value = textBox_IHP.Text.ToString();
                    dataGrid_jzwc.Rows[11].Cells["PLHP(Kw)"].Value = PLHP12.ToString();
                    dataGrid_jzwc.Rows[11].Cells["CCDT(s)"].Value = CCDT12.ToString();
                    dataGrid_jzwc.Rows[11].Cells["ACDT(s)"].Value = t12.ToString();
                    dataGrid_jzwc.Rows[11].Cells["误差"].Value = result12.ToString();
                    dataGrid_jzwc.Rows[11].Cells["结果"].Value = r1.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "出错");
            }
            //等待电机停止
            Thread.Sleep(3000);         //等待滚筒停止
            igbt.Lifter_Up();           //测试完成举升上升
            //tabControl1.Enabled = true; //设置能在页面中切换
            this.BeginInvoke(new wtb(Set_tab_Enabled), true);
            Test_Flag = false;          //重置正在测试的标记 
        }
        #endregion

        #region 变频器速度控制
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage_10_Enter(object sender, EventArgs e)
        {
            bpsd_exe();

        }
        public void bpsd_exe()
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "--请选择--";
            comboBox2.Items.Add("深蓝 SB60/61");
            comboBox2.Items.Add("广本 SB66/68");
            comboBox2.Items.Add("丰城 SG64/88");
            comboBox2.Items.Add("马瑞达 DG64/61");

            comboBox1.Items.Clear();
            comboBox1.Text = "--请选择--";
            comboBox1.Items.Add("COM1");
            comboBox1.Items.Add("COM3");
            comboBox1.Items.Add("COM4");

            comboBox3.Items.Clear();
            comboBox3.Text = "--请选择--";
            comboBox3.Items.Add("1200");
            comboBox3.Items.Add("2400");
            comboBox3.Items.Add("4800");
            comboBox3.Items.Add("9600");
            comboBox3.Items.Add("19200");

        }
        //单选控制禁用文本框
        private void radioButton_zd_CheckedChanged(object sender, EventArgs e)
        {
            textBox_sd.Enabled = true;
            textBox_pl.Enabled = false;
        }

        private void radioButton_sd_CheckedChanged(object sender, EventArgs e)
        {
            textBox_pl.Enabled = true;
            textBox_sd.Enabled = false;
        }
        //保存按钮
        private void button_bpqkz_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存后需要重新启动本系统才能生效");
        }
        #endregion

        #region 标定
        private void tabPage_11_Enter(object sender, EventArgs e)
        {
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            switch (UseMK)
            {
                case "BNTD":
                    button_read_speed_dp.Enabled = true;
                    label3.Text = "电压值";
                    panel14.Enabled = true;
                    panel13.Enabled = false;
                    dt_bd = null;
                    dt_bd = new DataTable();
                    dt_bd.Columns.Add("电压值");
                    dt_bd.Columns.Add("标定点");
                    dataGridView_bd.DataSource = dt_bd;
                    comboBox_bdtd.SelectedIndex = 0;
                    ini.INIIO.GetPrivateProfileString("UseMK", "使用通道", "1", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                    switch (temp.ToString())
                    {
                        case "1":
                            radioButton_td1.Checked = true;
                            break;
                        case "2":
                            radioButton_td2.Checked = true;
                            break;
                        case "3":
                            radioButton_td3.Checked = true;
                            break;
                    }
                    ini.INIIO.GetPrivateProfileString("UseMK", "BNTD标定说明", "无", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                    richTextBox_czts.Text = Regex.Replace(temp.ToString(), @"\\n", me);
                    igbt.Exit_Control();
                    Thread.Sleep(5);
                    igbt.Start_Demarcate_Force();
                    break;
                case "IGBT":
                    panel14.Enabled = false;
                    panel13.Enabled = true;
                    button_read_speed_dp.Enabled = false;
                    ini.INIIO.GetPrivateProfileString("UseMK", "IGBT标定说明", "无", temp, 2048, @".\Config.ini");          //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
                    richTextBox_czts.Text = Regex.Replace(temp.ToString(), @"\\n", me);
                    igbt.Exit_Control();
                    break;
            }
            //igbt.Start_Demarcate_Force();
            //timer1.Start();
        }

        private void button_demarcate_force_Click(object sender, EventArgs e)
        {
            string errorlist = "";
            if (textBox_Weight.Text.Trim() == "")
                errorlist += "请输入法码质量 ";
            if (textBox_modulus.Text.Trim() == "")
                errorlist += "请输入力臂比 ";
            if (errorlist == "")
            {
                try
                {
                    float.Parse(textBox_Weight.Text.Trim());
                }
                catch (Exception)
                {
                    errorlist += "输入的法码质量不合法 ";
                }
                try
                {
                    float.Parse(textBox_modulus.Text.Trim());
                }
                catch (Exception)
                {
                    errorlist += "输入的力臂比不合法 ";
                }
            }
            if (errorlist == "")
            {
                igbt.Demarcate_Force(comboBox_point.SelectedIndex, int.Parse((float.Parse(textBox_Weight.Text.Trim()) * float.Parse(textBox_modulus.Text.Trim()) * 9.8f).ToString()));
                if (comboBox_point.SelectedIndex < comboBox_point.Items.Count - 1)
                    comboBox_point.SelectedIndex += 1;
            }
            else
                MessageBox.Show(errorlist, "出错啦");
        }

        private void button_demarcate_speed_Click(object sender, EventArgs e)
        {
            string errorlist = "";
            if (textBox_diameter.Text.Trim() == "")
                errorlist += "请输入直径 ";
            if (textBox_pulse.Text.Trim() == "")
                errorlist += "请输入脉冲数 ";
            if (errorlist == "")
            {
                try
                {
                    int.Parse(textBox_diameter.Text.Trim());
                }
                catch (Exception)
                {
                    errorlist += "输入的直径不合法 ";
                }
                try
                {
                    int.Parse(textBox_pulse.Text.Trim());
                }
                catch (Exception)
                {
                    errorlist += "输入的脉冲数不合法 ";
                }
            }
            if (errorlist == "")
            {
                //igbt.Exit_Demarcate_Force();
                //Thread.Sleep(500);
                //igbt.Exit_Control();
                //Thread.Sleep(500);
                switch (UseMK)
                {
                    case "BNTD":
                        igbt.Demarcate_Speed((float.Parse(textBox_diameter.Text.Trim())/10).ToString(), textBox_pulse.Text.Trim());
                        break;
                    case "IGBT":
                        igbt.Demarcate_Speed(textBox_diameter.Text.Trim(), textBox_pulse.Text.Trim());
                        break;
                }
            }
            else
                MessageBox.Show(errorlist, "出错啦");
        }

        private void Demarcate_Load(object sender, EventArgs e)
        {
            comboBox_point.Text = "第一点";
            //timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Msg(label_ad, panel_ad, igbt.Time_AD, false);
            }
            catch (Exception)
            {
            }
        }

        private void tabPage_11_Leave(object sender, EventArgs e)
        {
            igbt.Exit_Demarcate_Force();
            igbt.Force_Zeroing();
            igbt.Exit_Control();
        }
        #endregion

        #region 控制
        /// <summary>
        /// 设置是否可以在页面中切换
        /// </summary>
        /// <param name="tf">bool</param>
        public void Set_tab_Enabled(bool tf)
        {
            tabControl1.Enabled = tf;         //设置能在页面中切换
        }

        private void button_ldcs_Click(object sender, EventArgs e)
        {
            igbt.Motor_Close();
            igbt.Exit_Control();
            if (Test_Flag)
            {
                try
                {
                    try
                    {
                        th_jbglcs.Abort();
                    }
                    catch (Exception)
                    {
                    }
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jsgcs.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jzhx.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_gl.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_bzhjz.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_xysj.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jzwc.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_dglmn.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                Test_Flag = false;
                tabControl1.Enabled = true;            //设置可以在页面中切换
            }
        }

        private void button_cgjql_Click(object sender, EventArgs e)
        {
            try
            {
                igbt.Force_Zeroing();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString(), "系统提示");
            }
        }

        private void button_jsss_Click(object sender, EventArgs e)
        {
            igbt.Lifter_Up();
        }

        private void button_jsxj_Click(object sender, EventArgs e)
        {
            igbt.Lifter_Down();
        }

        private void button_qddj_Click(object sender, EventArgs e)
        {
            igbt.Motor_Open();
        }

        private void button_gbdj_Click(object sender, EventArgs e)
        {
            igbt.Motor_Close();
        }

        private void button_tc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 截图
        private void button_jqpm_Click(object sender, EventArgs e)
        {
            Image img = Get_Image();
            if (img != null)
            {
                SaveFileDialog save1 = new SaveFileDialog();
                save1.Title = "文件保存在";
                save1.InitialDirectory = "%USERPROFILE%\\My Documents\\";
                save1.Filter = "JPG(*.JPG)|*.JPG|JPEG(*.JPEG)|*.JPEG|BMP(*.BMP)|*.BMP";
                //save1.RestoreDirectory = true;
                save1.FileName = "未命名";
                FileStream writer = null;
                if (save1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] buff = null;
                        MemoryStream Ms = new MemoryStream();
                        //将图像打入流
                        img.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        writer = new FileStream(save1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                        buff = Ms.GetBuffer();
                        writer.Write(buff, 0, buff.Length);
                        writer.Close();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.ToString(), "出错啦");
                    }
                }
            }
            else
                MessageBox.Show("获取图片失败", "出错啦");
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <returns>Image</returns>
        public Image Get_Image()
        {
            //创建一个跟屏幕大小一样的Image
            //Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Image img = new Bitmap(1024, 768);
            //创建GDI+ 用来DRAW屏幕
            Graphics g = Graphics.FromImage(img);
            //创建 图形大小
            Size s = new System.Drawing.Size(1024, 768);
            //将屏幕打入到Image中
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            g.CopyFromScreen(Location, new Point(0, 0), s);
            ////得到屏幕HDC句柄
            //IntPtr HDC = g.GetHdc();
            ////截图后释放该句柄
            //g.ReleaseHdc(HDC);
            return img;
        }
        #endregion
        #endregion

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = File.OpenText(File_Name8);
                s = sr.ReadToEnd();
                ShowText showtext = new ShowText(s);
                if (showtext.ShowDialog() == DialogResult.OK)
                {
                    s = showtext.RichTextValue;
                }
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文档不存在或者读取地址不对，请检查", "系统提示");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Control_TD control_ID = new Control_TD();
            control_ID.ShowDialog();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (textBox_cs.Text.Length < 4)
                {

                    bool IsContaintDot = this.textBox_cs.Text.Contains(".");
                    if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                    {
                        e.Handled = true;
                    }
                    else if (IsContaintDot && (e.KeyChar == 46))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("为了测试准确，输入的数字请不要大于1000", "系统提示");
                    textBox_cs.Text = "";
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("为了测试准确，输入的数字请不要大于100", "系统提示");
                textBox_cs.Text = "";
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Speed = (float)Convert.ToDouble(igbt.Speed);
            //meter1.ChangeValue = Speed;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //timer3.Enabled = (timer3.Enabled) ? false : true;
            igbt.Exit_Control();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Speed = (float)Convert.ToDouble(igbt.Speed);
            meter1.ChangeValue = Convert.ToDouble(Speed);

            tzMeterPanel1.wMaxMinValue = new SizeF(240, 0);//最大值
            tzMeterPanel1.wValue = (float)Speed;

            int sum = 0;
                sum +=Convert.ToInt32(Speed);
                tzMeterPanel1.wText = sum.ToString();
        }

        #region 输入字符合法性验证
        /// <summary>
        /// 输入字符合法性验证
        /// </summary>
        /// <param name="Ct">TextBox类型控件 名称</param>
        /// <param name="Regex">string 正则表达式(请勿带长度限制)</param>
        /// <param name="extent">int 允许输入的长度</param>
        /// <param name="Correct">bool 是否修正</param>
        /// <returns>bool 有错返回true</returns>
        public static bool Text_Verification(TextBox Ct, string Regex, int extent, bool Correct)
        {
            bool flag = false;
            try
            {
                if (Ct is TextBox)
                {
                    if (Ct.Text.Length > 0)
                    {
                        for (int i = Ct.Text.Length - 1; i >= 0; i--)
                        {
                            // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                            if (!System.Text.RegularExpressions.Regex.IsMatch(Ct.Text.Substring(i, 1), Regex) || Ct.Text.Length > extent)
                            {
                                if (Correct)
                                    Ct.Text = Ct.Text.Remove(i, 1);
                                flag = true;
                            }
                        }
                        Ct.SelectionStart = Ct.Text.Length;
                    }
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>
        /// 输入字符合法性验证
        /// </summary>
        /// <param name="Ct">ComboBox类型控件 名称</param>
        /// <param name="Regex">string 正则表达式(请勿带长度限制)</param>
        /// <param name="extent">int 允许输入的长度</param>
        /// <param name="Correct">bool 是否修正</param>
        /// <returns>bool 有错返回true</returns>
        public static bool Text_Verification(ComboBox Ct, string Regex, int extent, bool Correct)
        {
            bool flag = false;
            try
            {
                if (Ct is ComboBox)
                {
                    if (Ct.Text.Length > 0)
                    {
                        for (int i = Ct.Text.Length - 1; i >= 0; i--)
                        {
                            // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                            if (!System.Text.RegularExpressions.Regex.IsMatch(Ct.Text.Substring(i, 1), Regex) || Ct.Text.Length > extent)
                            {
                                if (Correct)
                                    Ct.Text = Ct.Text.Remove(i, 1);
                                flag = true;
                            }
                        }
                        Ct.SelectionStart = Ct.Text.Length;
                    }
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }
        #endregion

        private void button_read_speed_dp_Click(object sender, EventArgs e)
        {
            igbt.Get_Speed_DiameterandPusle();
            Thread.Sleep(100);
            textBox_diameter.Text = (float.Parse(igbt.Speed_Diameter)*10).ToString();
            textBox_pulse.Text = igbt.Speed_Pusle;
        }

        private void button_addbdd_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		        float.Parse(textBox_bdd.Text.Trim());
                if (comboBox_bdtd.Text == "")
                {
                    MessageBox.Show("请选择标定通道！", "系统提示");
                    return;
                }
                DataRow dr=dt_bd.NewRow();
                dr["电压值"] = label_ad.Text;
                dr["标定点"] = textBox_bdd.Text.Trim();
                dt_bd.Rows.Add(dr);
                dataGridView_bd.DataSource = dt_bd;
	        }
	        catch (Exception)
	        {
		        MessageBox.Show("标定点数据有误，请检查！","系统提示");
	        }
            
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Text_Verification(textBox_bdd, "[0-9\\.]", 12, true);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_bd = null;
            dt_bd = new DataTable();
            dt_bd.Columns.Add("电压值");
            dt_bd.Columns.Add("标定点");
            dataGridView_bd.DataSource = dt_bd;
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            string Aisle = "通道1";
            switch (comboBox_bdtd.Text)
            {
                case "1":
                    Aisle = "通道1";
                    break;
                case "2":
                    Aisle = "通道2";
                    break;
                case "3":
                    Aisle = "通道3";
                    break;
            }
            ini.INIIO.GetPrivateProfileString("UseMK", Aisle, "0.0", temp, 2048, @".\Config.ini");    //读配置文件（段名，字段，默认值，保存的strbuilder，大小，路径）
            textBox_xs.Text = temp.ToString();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataRow> drlist = new List<DataRow>();
                if (dataGridView_bd.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView_bd.SelectedRows.Count; i++)
                        foreach (DataRow dr in dt_bd.Rows)
                        {
                            if (dr["标定点"].ToString() == dataGridView_bd.SelectedRows[i].Cells["标定点"].Value.ToString())
                                drlist.Add(dr); 
                        }
                    if (drlist.Count != 0)
                        foreach(DataRow drd in drlist)
                            dt_bd.Rows.Remove(drd);
                    dataGridView_bd.DataSource = dt_bd;
                }
                else 
                {
                    MessageBox.Show("请选择要删除的点", "系统提示");
                }
            }
            catch (Exception)
            {
            }
        }

        private void button_scxs_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0;
                double d = 0;
                for (int i = 0; i < dataGridView_bd.Rows.Count; i++)
                {
                    v += float.Parse(dataGridView_bd.Rows[i].Cells["电压值"].Value.ToString());
                    d += float.Parse(dataGridView_bd.Rows[i].Cells["标定点"].Value.ToString());
                }
                textBox_xs.Text = float.Parse((d / v).ToString()).ToString();
            }
            catch (Exception)
            {
                dt_bd.Clear();
                dataGridView_bd.DataSource = dt_bd;
                MessageBox.Show("标定点可能有误,请重新操作。", "系统提示");
            }
        }

        private void button_write_Click(object sender, EventArgs e)
        {
            try
            {
                float xs=float.Parse(textBox_xs.Text);
                int td= int.Parse(comboBox_bdtd.Text);
                igbt.Solidify_Force_Modulus(td, xs);
            }
            catch (Exception)
            {
                MessageBox.Show("是不是没有生成系数？或者没有选择通道？请检查！", "系统提示");
            }
        }

        private void button_read_force_m_Click(object sender, EventArgs e)
        {
            try
            {
                igbt.Get_Force_Modulus();
                Thread.Sleep(100);
                switch (comboBox_bdtd.Text)
                {
                    case "1":
                        textBox_xs.Text = igbt.b0;
                        break;
                    case "2":
                        textBox_xs.Text = igbt.b1;
                        break;
                    case "3":
                        textBox_xs.Text = igbt.b2;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void radioButton_td_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_td1.Checked)
            {
                ini.INIIO.WritePrivateProfileString("UseMK", "使用通道", "1", @".\Config.ini");
                igbt.Select_Channel(1);
            }
            else if (radioButton_td2.Checked)
            {
                ini.INIIO.WritePrivateProfileString("UseMK", "使用通道", "2", @".\Config.ini");
                igbt.Select_Channel(2);
            }
            else if (radioButton_td3.Checked)
            {
                ini.INIIO.WritePrivateProfileString("UseMK", "使用通道", "3", @".\Config.ini");
                igbt.Select_Channel(3);
            }
        }

        private void toolStripButtonForceClear_Click(object sender, EventArgs e)
        {
            try
            {
                igbt.Force_Zeroing();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString(), "系统提示");
            }
        }

        private void toolStripButtonLiftUp_Click(object sender, EventArgs e)
        {
            igbt.Lifter_Up();
        }

        private void toolStripButtonLiftDown_Click(object sender, EventArgs e)
        {
            igbt.Lifter_Down();
        }

        private void toolStripButtonMotorOn_Click(object sender, EventArgs e)
        {
            igbt.Motor_Open();
        }

        private void toolStripButtonMotorOff_Click(object sender, EventArgs e)
        {
            igbt.Motor_Close();
        }

        private void toolStripButtonStopTest_Click(object sender, EventArgs e)
        {
            igbt.Motor_Close();
            igbt.Exit_Control();
            nowState = testState.idle_state;
            if (Test_Flag)
            {
                try
                {
                    try
                    {
                        th_jbglcs.Abort();
                    }
                    catch (Exception)
                    {
                    }
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jsgcs.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jzhx.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_gl.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_bzhjz.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_xysj.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_jzwc.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                try
                {
                    th_dglmn.Abort();
                    igbt.Exit_Control();
                }
                catch (Exception)
                {
                }
                Test_Flag = false;
                tabControl1.Enabled = true;            //设置可以在页面中切换
            }
        }

        private void toolStripButtonPrintScreen_Click(object sender, EventArgs e)
        {
            Image img = Get_Image();
            if (img != null)
            {
                SaveFileDialog save1 = new SaveFileDialog();
                save1.Title = "文件保存在";
                save1.InitialDirectory = "%USERPROFILE%\\My Documents\\";
                save1.Filter = "JPG(*.JPG)|*.JPG|JPEG(*.JPEG)|*.JPEG|BMP(*.BMP)|*.BMP";
                //save1.RestoreDirectory = true;
                save1.FileName = "未命名";
                FileStream writer = null;
                if (save1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] buff = null;
                        MemoryStream Ms = new MemoryStream();
                        //将图像打入流
                        img.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        writer = new FileStream(save1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                        buff = Ms.GetBuffer();
                        writer.Write(buff, 0, buff.Length);
                        writer.Close();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.ToString(), "出错啦");
                    }
                }
            }
            else
                MessageBox.Show("获取图片失败", "出错啦");
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

