using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
namespace carinfor
{
    public static class SocketControlNn
    {
        public static IntPtr intptr;
        public static string serverIP;
        public static int serverPort;
        public static int socketRecvMsg;
        public static int nsocketConnectMsg;
        public static int nsocketCloseMsg;
        public static int nConnectFlag;
        public static void init_socket(string server_IP, int server_Port, IntPtr intptrhandle, int socket_RecvMsg, int nsocket_ConnectMsg, int nsocket_CloseMsg, int nConnect_flag)
        {
            serverIP = server_IP;
            serverPort = server_Port;
            intptr = intptrhandle;
            socketRecvMsg = socket_RecvMsg;
            nsocketConnectMsg = nsocket_ConnectMsg;
            nsocketCloseMsg = nsocket_CloseMsg;
            nConnectFlag = nConnect_flag;
        }

        //函数名称 CreateSocketClient
        //函数功能 创建客户端socket
        //参数：
        //     pszIp 传入参数，服务ip
        //     nPort 传入参数，服务socket的端口
        //     hWnd  传入参数，接受socket消息的窗口句柄
        //     nSocketRecvMsg 传入参数，提示接收服务器返回数据的消息
        //     nSocketConnectMsg 传入参数，提示连接成功的消息
        //     nSocketCloseMsg 传入参数，提示socket断开消息
        //     nConnectFlag 传入参数，预留字段，可赋值为0
        //返回：TRUE表示调用成功，FALSE表示调用失败
        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]


        public static extern bool CreateSocketClient(string pszIp, int nPort, IntPtr hWnd, int nSocketRecvMsg,
                            int nSocketConnectMsg, int nSocketCloseMsg, int nConnectFlag);
        //函数名称 SetRegisterDataEx
        //函数功能 客户端调用设置注册信息，设置完毕才能注册到服务端，在调用ReConnectToServer前设置
        //参数：
        //	  cmd    注册命令’R’
        //	  type    类型
        //     pszData注册信息，程序保存以便网络断开重新连接后注册
        //返回：TRUE表示调用成功，FALSE表示调用失败
        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool SetRegisterDataEx(char cmd, int ntype, string data);
        //函数名称 SendToServerEx
        //函数功能 发送数据到服务端
        //参数：
        //     cmd		传入参数，命令字
        //     type	    传入参数，类型
        //     data		传入参数，发送的数据，字符串类型
        //返回：TRUE表示调用成功，FALSE表示调用失败
        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool SendToClientEx(IntPtr s, char cmd, int ntype, string data);
        //函数名称 ReConnectToServer
        //函数功能 重连服务器
        //参数：
        //     无
        //返回：TRUE表示调用成功，FALSE表示调用失败

        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool SendToServerEx(char cmd, int ntype, string data);//辽宁接口属于早期安车版本，此处返回值和其他 版本不一样，返回 的为bool类型

        //函数名称 ReConnectToServer
        //函数功能 重连服务器
        //参数：
        //     无
        //返回：TRUE表示调用成功，FALSE表示调用失败

        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool ReConnectToServer();

        //函数名称 RecvRemoteData
        //函数功能 当客户端收到服务端发来的数据时，会发送数据接收消息给指定的窗口，在消息响应函数中调用此函数获得相应的命令、类型和数据。
        //参数
        //     package  输入参数，固定为消息的lParam参数
        //     cmd     输出参数，命令字
        //     type     输出参数，类型
        //     data     输出参数，数据
        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool RecvRemoteData(int HWD, ref char command, ref int ntype, StringBuilder data);


        //函数名称 CloseSocketClient
        //函数功能 关闭socket
        //参数：
        //     
        //返回： TRUE表示调用成功，FALSE表示调用失败
        [DllImport(@".\acdll\辽宁\HuanbaoSocket.dll")]
        public static extern bool CloseSocketClient();

    }

}
