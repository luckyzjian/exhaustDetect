using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ini;


namespace CapturePicture
{

    public class captureControl
    {
        //cameraFront
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private Int32 m_lRealHandle = -1;
        private string str;
        private bool isFrontCaptured = false;
        private bool isLoadmeterThreadStart = false;
        private string FrontCapturePath = "";

        //cameraBack
        private uint iLastErrBack = 0;
        private Int32 m_lUserIDBack = -1;
        private bool m_bInitSDKBack = false;
        private bool m_bRecordBack = false;
        private Int32 m_lRealHandleBack = -1;
        private string strBack;
        private bool isBackCaptured = false;
        private string BackCapturePath = "";
        private int frontchanel = 1;
        private int backchanel = 1;
        public bool isCameraFrontReady = false;
        public bool isCameraBackReady = false;
        private int capmethod;
        private bool enablefront = false;
        private bool enableback = false;
        public bool init_camera(carinfor.captureConfigData camerainfdata)
        {
            capmethod = camerainfdata.captureMethod;
            enablefront = camerainfdata.ENABLEFRONT;
            enableback = camerainfdata.ENABLEBACK;
            if (camerainfdata.captureMethod == 0)
            {

                if (camerainfdata.ENABLEFRONT)
                {
                    if (camerainfdata.CAMERAFRONTIP == "" || camerainfdata.CAMERAFRONTPORT == 0 ||
                        camerainfdata.CAMERAFRONTUSER == "" || camerainfdata.CAMERAFRONTPASSWORD == "")
                    {
                        ini.INIIO.saveLogInf("Please input IP, Port, User name and Password!\r\n");
                        //return;
                    }
                    else if (m_lUserID < 0)
                    {
                        string DVRIPAddress = camerainfdata.CAMERAFRONTIP; //设备IP地址或者域名
                        Int16 DVRPortNumber = (Int16)camerainfdata.CAMERAFRONTPORT;//设备服务端口号
                        string DVRUserName = camerainfdata.CAMERAFRONTUSER;//设备登录用户名
                        string DVRPassword = camerainfdata.CAMERAFRONTPASSWORD;//设备登录密码

                        CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                        //登录设备 Login the device
                        m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                        if (m_lUserID < 0)
                        {
                            iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Login_V30 failed, error code= " + iLastErr + "\r\n");
                            //return;
                        }
                        else
                        {
                            //登录成功
                            //MessageBox.Show("Login Success!");
                            ini.INIIO.saveLogInf("Camera in front Login Success!" + "\r\n");
                            isCameraFrontReady = true;
                        }

                    }
                    else
                    {
                        //注销登录 Logout the device
                        if (m_lRealHandle >= 0)
                        {
                            ini.INIIO.saveLogInf("Please stop live view firstly" + "\r\n");
                        }

                        if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                        {
                            iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Logout failed, error code= " + iLastErr + "\r\n");
                            //return;
                        }
                        m_lUserID = -1;
                    }
                    //return;
                }
                else
                {
                    ini.INIIO.saveLogInf("Camera in front is disable!" + "\r\n");
                }
                if (camerainfdata.ENABLEBACK)
                {
                    if (camerainfdata.CAMERABACKIP == "" || camerainfdata.CAMERABACKPORT == 0 ||
                        camerainfdata.CAMERABACKUSER == "" || camerainfdata.CAMERABACKPASSWORD == "")
                    {
                        ini.INIIO.saveLogInf("Please input IP, Port, User name and Password!" + "\r\n");
                        //return;
                    }
                    else if (m_lUserIDBack < 0)
                    {
                        string DVRIPAddress = camerainfdata.CAMERABACKIP; //设备IP地址或者域名
                        Int16 DVRPortNumber = (Int16)camerainfdata.CAMERABACKPORT;//设备服务端口号
                        string DVRUserName = camerainfdata.CAMERABACKUSER;//设备登录用户名
                        string DVRPassword = camerainfdata.CAMERABACKPASSWORD;//设备登录密码

                        CHCNetSDKBack.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDKBack.NET_DVR_DEVICEINFO_V30();

                        //登录设备 Login the device
                        m_lUserIDBack = CHCNetSDKBack.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                        if (m_lUserIDBack < 0)
                        {
                            iLastErrBack = CHCNetSDKBack.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Login_V30 failed, error code= " + iLastErrBack + "\r\n");
                            //return;
                        }
                        else
                        {
                            //登录成功
                            //MessageBox.Show("Login Success!");
                            ini.INIIO.saveLogInf("Camera in Back Login Success!" + "\r\n");
                            isCameraBackReady = true;
                        }

                    }
                    else
                    {
                        //注销登录 Logout the device
                        if (m_lRealHandleBack >= 0)
                        {
                            ini.INIIO.saveLogInf("Please stop live view firstly" + "\r\n");
                        }

                        if (!CHCNetSDKBack.NET_DVR_Logout(m_lUserIDBack))
                        {
                            iLastErrBack = CHCNetSDKBack.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Logout failed, error code= " + iLastErrBack + "\r\n");
                            //return;
                        }
                        m_lUserIDBack = -1;
                    }
                    //return;
                }
                else
                {
                    ini.INIIO.saveLogInf("Camera in Back is disable!" + "\r\n");
                }
            }
            else
            {
                frontchanel = camerainfdata.NVRFRONTCHANEL;
                backchanel = camerainfdata.NVRBACKCHANEL;
                if(camerainfdata.ENABLEFRONT||camerainfdata.ENABLEBACK)
                {
                    if (camerainfdata.NVRIP == "" || camerainfdata.NVRPORT == 0 ||
                        camerainfdata.NVRUSER == "" || camerainfdata.NVRPASSWORD == "")
                    {
                        ini.INIIO.saveLogInf("Please input IP, Port, User name and Password!\r\n");
                        //return;
                    }
                    else if (m_lUserID < 0)
                    {
                        string DVRIPAddress = camerainfdata.NVRIP; //设备IP地址或者域名
                        Int16 DVRPortNumber = (Int16)camerainfdata.NVRPORT;//设备服务端口号
                        string DVRUserName = camerainfdata.NVRUSER;//设备登录用户名
                        string DVRPassword = camerainfdata.NVRPASSWORD;//设备登录密码

                        CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                        //登录设备 Login the device
                        m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                        if (m_lUserID < 0)
                        {
                            iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Login_V30 failed, error code= " + iLastErr + "\r\n");
                            //return;
                        }
                        else
                        {
                            //登录成功
                            //MessageBox.Show("Login Success!");
                            ini.INIIO.saveLogInf("Camera in front Login Success!" + "\r\n");
                            isCameraFrontReady = true;
                        }

                    }
                    else
                    {
                        //注销登录 Logout the device
                        if (m_lRealHandle >= 0)
                        {
                            ini.INIIO.saveLogInf("Please stop live view firstly" + "\r\n");
                        }

                        if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                        {
                            iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                            ini.INIIO.saveLogInf("NET_DVR_Logout failed, error code= " + iLastErr + "\r\n");
                            //return;
                        }
                        m_lUserID = -1;
                    }
                }
            }
            return isCameraFrontReady || isCameraBackReady;
        }
        public void stopLiveView(int cameraIndex)
        {
            if (cameraIndex == 1)
            {

                if (enablefront)
                {
                    if (capmethod == 0)
                    {
                        if (m_lUserID < 0)
                        {
                            return;
                        }
                        if (m_lRealHandle>=0)
                        {                            //停止预览 Stop live view 
                            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                            {
                                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                                return;
                            }
                            m_lRealHandle = -1;
                            //rectangleShape1.FillColor = Color.Red;
                            //rectangleShape2.FillColor = Color.Red;
                            //rectangleShape3.FillColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (m_lUserID < 0)
                        {
                            return;
                        }
                        if (m_lRealHandle>=0)
                        {
                            //停止预览 Stop live view 
                            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                            {
                                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                                return;
                            }
                            m_lRealHandle = -1;
                            //rectangleShape1.FillColor = Color.Red;
                            //rectangleShape2.FillColor = Color.Red;
                            //rectangleShape3.FillColor = Color.Red;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveLogInf("前摄像头未使能");
                }
            }
            else if (cameraIndex == 2)
            {
                if (enableback)
                {
                    if (capmethod == 0)
                    {
                        if (m_lUserIDBack < 0)
                        {
                            return;
                        }
                        if (m_lRealHandleBack >=0)
                        {
                            //停止预览 Stop live view 
                            if (!CHCNetSDKBack.NET_DVR_StopRealPlay(m_lRealHandleBack))
                            {
                                iLastErrBack = CHCNetSDKBack.NET_DVR_GetLastError();
                                strBack = "NET_DVR_StopRealPlay failed, error code= " + iLastErrBack;
                                return;
                            }
                            m_lRealHandleBack = -1;
                            //rectangleShape4.FillColor = Color.Red;
                            //rectangleShape5.FillColor = Color.Red;
                            //rectangleShape6.FillColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (m_lUserIDBack < 0)
                        {
                            return;
                        }
                        if (m_lRealHandleBack >=0)
                        {
                            //停止预览 Stop live view 
                            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandleBack))
                            {
                                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                                return;
                            }
                            m_lRealHandleBack = -1;
                            //rectangleShape1.FillColor = Color.Red;
                            //rectangleShape2.FillColor = Color.Red;
                            //rectangleShape3.FillColor = Color.Red;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveLogInf("后摄像头未使能");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cameraIndex">1,前摄像头 2,后摄像头</param>
        /// <param name="isTurnedOn"></param>
        /// <param name="handle"></param>
        public void openLiveView(int cameraIndex,IntPtr handle)
        {
            if (cameraIndex == 1)
            {

                if (enablefront)
                {
                    if (capmethod == 0)
                    {
                        if (m_lUserID < 0)
                        {
                            return;
                        }
                            if (m_lRealHandle < 0)
                            {
                                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                lpPreviewInfo.hPlayWnd = handle;//预览窗口
                                lpPreviewInfo.lChannel = 1;//预te览的设备通道
                                lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                                CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                                IntPtr pUser = new IntPtr();//用户数据

                                //打开预览 Start live view 
                                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                if (m_lRealHandle < 0)
                                {
                                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                                    return;
                                }
                                else
                                {
                                    //预览成功
                                    //rectangleShape1.FillColor = Color.Lime;
                                    //rectangleShape2.FillColor = Color.Lime;
                                    //rectangleShape3.FillColor = Color.Lime;
                                    //btnPreview.Text = "Stop Live View";
                                }
                            }
                    }
                    else
                    {
                        if (m_lUserID < 0)
                        {
                            return;
                        }
                            if (m_lRealHandle < 0)
                            {
                                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                lpPreviewInfo.hPlayWnd = handle;//预览窗口
                                lpPreviewInfo.lChannel = frontchanel;//预te览的设备通道
                                lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                                CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                                IntPtr pUser = new IntPtr();//用户数据

                                //打开预览 Start live view 
                                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                if (m_lRealHandle < 0)
                                {
                                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                                    return;
                                }
                                else
                                {
                                    //预览成功
                                    //rectangleShape1.FillColor = Color.Lime;
                                    //rectangleShape2.FillColor = Color.Lime;
                                    //rectangleShape3.FillColor = Color.Lime;
                                    //btnPreview.Text = "Stop Live View";
                                }
                            }
                    }
                }
                else
                {
                    ini.INIIO.saveLogInf("前摄像头未使能");
                }
            }
            else if (cameraIndex == 2)
            {
                if (enableback)
                {
                    if (capmethod == 0)
                    {
                        if (m_lUserIDBack < 0)
                        {
                            return;
                        }
                            if (m_lRealHandleBack < 0)
                            {
                                CHCNetSDKBack.NET_DVR_PREVIEWINFO lpPreviewInfoBack = new CHCNetSDKBack.NET_DVR_PREVIEWINFO();
                                lpPreviewInfoBack.hPlayWnd = handle;//预览窗口
                                lpPreviewInfoBack.lChannel = 1;//预te览的设备通道
                                lpPreviewInfoBack.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                lpPreviewInfoBack.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                lpPreviewInfoBack.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                                CHCNetSDKBack.REALDATACALLBACK RealDataBack = new CHCNetSDKBack.REALDATACALLBACK(RealDataCallBackBack);//预览实时流回调函数
                                IntPtr pUserBack = new IntPtr();//用户数据

                                //打开预览 Start live view 
                                m_lRealHandleBack = CHCNetSDKBack.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfoBack, null/*RealData*/, pUserBack);
                                if (m_lRealHandleBack < 0)
                                {
                                    iLastErrBack = CHCNetSDKBack.NET_DVR_GetLastError();
                                    strBack = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErrBack; //预览失败，输出错误号
                                    return;
                                }
                                else
                                {
                                    //预览成功
                                    //rectangleShape4.FillColor = Color.Lime;
                                    //rectangleShape5.FillColor = Color.Lime;
                                    //rectangleShape6.FillColor = Color.Lime;
                                    //btnPreview.Text = "Stop Live View";
                                }
                            }
                    }
                    else
                    {
                        if (m_lUserID < 0)
                        {
                            return;
                        }
                        if(m_lRealHandleBack < 0)
                            {
                                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                                lpPreviewInfo.hPlayWnd = handle;//预览窗口
                                lpPreviewInfo.lChannel = backchanel;//预te览的设备通道
                                lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                                CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                                IntPtr pUser = new IntPtr();//用户数据

                            //打开预览 Start live view 
                            m_lRealHandleBack = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                                if (m_lRealHandleBack < 0)
                                {
                                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                                    return;
                                }
                                else
                                {
                                    //预览成功
                                    //rectangleShape1.FillColor = Color.Lime;
                                    //rectangleShape2.FillColor = Color.Lime;
                                    //rectangleShape3.FillColor = Color.Lime;
                                    //btnPreview.Text = "Stop Live View";
                                }
                            }
                    }
                }
                else
                {
                    ini.INIIO.saveLogInf("后摄像头未使能");
                }
            }
        }

        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
        public void RealDataCallBackBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
        public captureControl()
        {
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Front\\", true);
            }
            m_bInitSDKBack = CHCNetSDKBack.NET_DVR_Init();
            if (m_bInitSDKBack == false)
            {
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDKBack.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\Back\\", true);
            }
            return;
        }
        private void capture_frontPictureToRam(ref object fileName)
        {
            if (enablefront)
            {
                if (capmethod == 0)
                {
                    int lChannel = 1; //通道号 Channel number

                    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档
                    uint ipSizeReturned = 0;
                    byte[] sJpegPicBuffer=new byte[1024*1000];
                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture_NEW(m_lUserID, lChannel, ref lpJpegPara, sJpegPicBuffer,(uint)sJpegPicBuffer.Length, ref ipSizeReturned))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "截取前摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                        //textBox1.AppendText(str + "\r\n");
                    }
                    else
                    {
                        
                        str = "截取前摄像头照片成功";
                        ini.INIIO.saveLogInf(str);
                    }
                }
            }
            else
            {
                str = "截取前摄像头照片失败,前摄像头未使能 ";
                ini.INIIO.saveLogInf(str);
            }
        }
        private void capture_frontPicture(object fileName)
        {
            if (enablefront)
            {
                if (capmethod == 0)
                {
                    string sJpegPicFileName;
                    //图片保存路径和文件名 the path and file name to save
                    sJpegPicFileName = (string)fileName;
                    //CreateVehiclePicturePath(ref sJpegPicFileName);
                    int lChannel = 1; //通道号 Channel number

                    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "截取前摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                        //textBox1.AppendText(str + "\r\n");
                    }
                    else
                    {
                        str = "截取前摄像头照片成功： " + sJpegPicFileName;
                        ini.INIIO.saveLogInf(str);
                    }
                }
                else
                {
                    string sJpegPicFileName;
                    //图片保存路径和文件名 the path and file name to save
                    sJpegPicFileName = (string)fileName;
                    //CreateVehiclePicturePath(ref sJpegPicFileName);
                    int lChannel = frontchanel; //通道号 Channel number

                    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "截取前摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                        //textBox1.AppendText(str + "\r\n");
                    }
                    else
                    {
                        str = "截取前摄像头照片成功： " + sJpegPicFileName;
                        ini.INIIO.saveLogInf(str);
                    }
                }
            }
            else
            {
                str = "截取前摄像头照片失败,前摄像头未使能 ";
                ini.INIIO.saveLogInf(str);
            }
        }
        private void capture_backPicture(object fileName)
        {
            if (enableback)
            {
                if (capmethod == 0)
                {
                    string sJpegPicFileName;
                    //图片保存路径和文件名 the path and file name to save
                    sJpegPicFileName = (string)fileName;
                    //CreateVehiclePicturePath(ref sJpegPicFileName);
                    int lChannel = 1; //通道号 Channel number

                    CHCNetSDKBack.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDKBack.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档


                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDKBack.NET_DVR_CaptureJPEGPicture(m_lUserIDBack, lChannel, ref lpJpegPara, sJpegPicFileName))
                    {
                        iLastErr = CHCNetSDKBack.NET_DVR_GetLastError();
                        str = "截取后摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                    }
                    else
                    {
                        str = "截取后摄像头照片成功： " + sJpegPicFileName;
                        ini.INIIO.saveLogInf(str);
                    }
                }
                else
                {
                    string sJpegPicFileName;
                    //图片保存路径和文件名 the path and file name to save
                    sJpegPicFileName = (string)fileName;
                    //CreateVehiclePicturePath(ref sJpegPicFileName);
                    int lChannel = backchanel; //通道号 Channel number

                    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "截取后摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                        //textBox1.AppendText(str + "\r\n");
                    }
                    else
                    {
                        str = "截取后摄像头照片成功： " + sJpegPicFileName;
                        ini.INIIO.saveLogInf(str);
                    }
                }
            }
            else
            {
                str = "截取后摄像头照片失败,后摄像头未使能 ";
                ini.INIIO.saveLogInf(str);
            }


        }
        public bool startFrontCaptureThreadToRam(ref byte[] buffer)
        {
            if (enablefront)
            {
                if (capmethod == 0)
                {
                    int lChannel = 1; //通道号 Channel number

                    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档
                    uint ipSizeReturned = 0;
                    byte[] sJpegPicBuffer = new byte[1024 * 1000];
                    //JPEG抓图 Capture a JPEG picture
                    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture_NEW(m_lUserID, lChannel, ref lpJpegPara, sJpegPicBuffer, (uint)sJpegPicBuffer.Length, ref ipSizeReturned))
                    {
                        buffer = null;
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "截取前摄像头照片失败, error code= " + iLastErr;
                        ini.INIIO.saveLogInf(str);
                        return false;
                        //textBox1.AppendText(str + "\r\n");
                    }
                    else
                    {
                        buffer = new byte[ipSizeReturned];
                        Array.Copy(sJpegPicBuffer, buffer, ipSizeReturned);
                        str = "截取前摄像头照片成功";
                        ini.INIIO.saveLogInf(str);
                        return true;
                    }
                }
                else
                {
                    buffer = null;
                    return false;
                }
            }
            else
            {
                buffer = null;
                return false;
            }

        }
        public bool startFrontCaptureThread(string fileName)
        {
            if (enablefront)
            {
                Thread captureFrontPicture = new Thread(new ParameterizedThreadStart(capture_frontPicture));
                captureFrontPicture.Start(fileName);
            }
            return true;

        }
        public bool startBackCaptureThread(string fileName)
        {
            if (enableback)
            {
                Thread captureFrontPicture = new Thread(new ParameterizedThreadStart(capture_backPicture));
                captureFrontPicture.Start(fileName);
            }
            return true;

        }
    }
}
