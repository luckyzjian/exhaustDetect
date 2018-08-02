using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ini;

namespace 中科宇图启动端
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirpath = AppDomain.CurrentDomain.BaseDirectory;

            foreach (string childarg in args)
            {
                Console.WriteLine("[启动参数]：" + childarg);
                ini.INIIO.saveLogInf("[启动参数]："+childarg);
            }
            if (args.Count() > 0)
            {
                Console.WriteLine("[中科宇图启动端消息]：网页启动，获取到启动授权码=" + args[0]);
                ini.INIIO.WritePrivateProfileString("中科宇图", "启动授权码", args[0], dirpath + "中科宇图授权码.ini");
                ini.INIIO.WritePrivateProfileString("中科宇图", "更新时间",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dirpath + "中科宇图授权码.ini");
                ini.INIIO.WritePrivateProfileString("中科宇图", "状态", "成功", dirpath + "中科宇图授权码.ini");
                ini.INIIO.saveLogInf("[中科宇图启动端消息]：网页启动，获取到启动授权码="+args[0]);
            }
            else
            {
                Console.WriteLine("[中科宇图启动端消息]：未获取到启动授权码");
                ini.INIIO.WritePrivateProfileString("中科宇图", "启动授权码", "", dirpath + "中科宇图授权码.ini");
                ini.INIIO.WritePrivateProfileString("中科宇图", "更新时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dirpath + "中科宇图授权码.ini");
                ini.INIIO.WritePrivateProfileString("中科宇图", "状态", "失败", dirpath + "中科宇图授权码.ini");

                ini.INIIO.saveLogInf("[中科宇图启动端消息]：未网页启动，未获取到启动授权码");
            }
            System.Threading.Thread.Sleep(5000);
            return;
        }
    }
}
