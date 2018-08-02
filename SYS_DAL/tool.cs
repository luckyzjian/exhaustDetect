using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;
using System.Net;

namespace SYS_DAL
{
    public class tool
    {
        /// <summary>
        ///根据快速工况10s内HC数据取平均值
        /// </summary>
        ///  <param name="list">快速工况每秒数据集合</param>
        /// <returns>10sHC的平均值</returns>
        public float getHCAverage(string list)
        {
            string[] s = list.Split(new char[] { ',' });
            float sum = 0;
            float av = 0;
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    string strhc = s[i];
                    float flohc = float.Parse(strhc);
                    sum += flohc;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        
            av = sum / 10;
            string strav = av.ToString("0.0");
            float floav = float.Parse(strav);
            return floav;

        }

        /// <summary>
        ///快速工况某一秒稀释修正HC数据
        /// </summary>
        ///  <param name="co2">某一秒co2数据</param>
        ///  <param name="co">某一秒co数据</param>
        ///  <param name="hc">某一秒hc数据</param>
        ///  <param name="you">燃油类型</param>
        /// <returns>某一秒HC的修正结果值</returns>
        public float getChcAv(float co2, float co, float hc, string you)
        {
            double a = 0;//燃料计算系数
            double x = 0;
            double Cco2 = 0;//修正后的co2
            double DF = 0;//稀释系数
            double Rshc = 0;//某一秒计算后的测量结果
            x = co2 / (co2 + co);
            if (you == "汽油")
            {
                a = 4.644;
            }
            if (you == "天然气")
            {
                a = 6.64;
            }
            if (you == "液化石油气")
            {
                a = 5.39;
            }
            Cco2 = (x / (a + (1.88 * x))) * 100;
            DF = Cco2 / co2;
            Rshc = hc * DF;
            float flo = float.Parse(Rshc.ToString("0.0"));
            return flo;
        }

        /// <summary>
        ///快速工况某一秒稀释修正co数据
        /// </summary>
        ///  <param name="co2">某一秒co2数据</param>
        ///  <param name="co">某一秒co数据</param>
        ///   <param name="you">燃油类型</param>
        /// <returns>某一秒co的修正结果值</returns>
        public float getCcoAv(float co2, float co, string you)
        {
            double a = 0;//燃料计算系数
            double x = 0;
            double Cco2 = 0;//修正后的co2
            double DF = 0;//稀释系数
            double Rsco = 0;//某一秒计算后的测量结果
            x = co2 / (co2 + co);
            if (you == "汽油")
            {
                a = 4.644;
            }
            if (you == "天然气")
            {
                a = 6.64;
            }
            if (you == "液化石油气")
            {
                a = 5.39;
            }

            Cco2 = (x / (a + (1.88 * x))) * 100;
            DF = Cco2 / co2;
            Rsco = co * DF;
            float flo = float.Parse(Rsco.ToString("0.0"));
            return flo;
        }

        /// <summary>
        ///快速工况某一秒稀释修正no数据
        /// </summary>
        ///  <param name="co2">某一秒co2数据</param>
        ///  <param name="co">某一秒co数据</param>
        ///  <param name="no">某一秒no数据</param>
        ///  <param name="shidu">某一秒湿度数据</param>
        ///  <param name="daqiya">某一秒大气压数据</param>
        ///  <param name="zhen">某一秒蒸气压数据</param>
        ///  <param name="you">燃油类型</param>
        /// <returns>某一秒no的修正结果值</returns>
        public float getCnoAv(float co2, float co, float no, double shidu, double daqiya, double zheng, string you)
        {
            double a = 0;//燃料计算系数
            double x = 0;
            double Cco2 = 0;//修正后的co2
            double DF = 0;//稀释系数
            double Rsno = 0;//某一秒计算后的测量结果
            double Kh = 0;//湿度校正系数
            double H = 0;//绝对湿度
            x = co2 / (co2 + co);
            if (you =="汽油")
            {
                a = 4.644;
            }
            if (you =="天然气")
            {
                a = 6.64;
            }
            if (you == "液化石油气")
            {
                a = 5.39;
            }
            Cco2 = (x / (a + (1.88 * x))) * 100;
            DF = Cco2 / co2;
            H = (43.478 * shidu * zheng) / (daqiya - zheng * shidu / 100);
            Kh = 1 / (1 - 0.0047 * (H - 75));

            Rsno = no * DF * Kh;
            float flo = float.Parse(Rsno.ToString("0.0"));
            return flo;
        }


        /// <summary>
        ///工况任意10s的数据平均值
        /// </summary>
        ///  <param name="list">工况每秒数据集合</param>
        /// <returns>工况任意10s的数据平均值</returns>
        public string getav(string[] list)
        {
            //string[] s = list.Split(new char[] { ',' });
            //string[] s1 = list.Split(new char[] { ',' }, 5);

            float sum = 0;
            float av = 0;
            String strsum = null;
            try
            {
                for (int i = 0; i < list.Length-10; i++)
                {
                    sum = 0;
                    for (int j = i; j < i + 10; j++)
                    {

                        string strhc = list[j];
                        float flohc = float.Parse(strhc);
                        sum += flohc;

                    }

                    av = sum / 10;
                    string strav = av.ToString("0.00");
                    strsum = strsum + "," + av;
                    

                }
            }
            catch (Exception e){
                throw e;
            }

            return strsum;
        }

        /// <summary>
        ///测功机加载
        /// </summary>
        ///  <param name="power">车辆输出功率</param>     
        public void cgjJz(float power)
        {
          

        }
        /// <summary>
        ///工况任意连续10s的HC数据平均值是否达标
        /// </summary>
        ///  <param name="list">工况10s的HC数据平均值集合</param>
        ///  <param name="max">限值</param>
        /// <returns>合格值或0</returns>
        

        public float isOk(string strsum, float max)
        {
            float b = 0;
            string[] s = strsum.Split(new char[] { ',' });
            try {
                for (int i = 1; i <= s.Length - 1; i++)
                {
                    string st = s[i];

                    float flo = float.Parse(st);
                    if (flo <= max)
                    {

                        b = flo;
                        i++;
                    }

                    if (flo > max)
                    {
                        b = flo;
                    }
                }
            
            }
            catch(Exception e) 
            {
                throw e;
            }
         
            string str = b.ToString("0.0");
            float last = float.Parse(str);
            return last;

        }
        /// <summary>
        ///工况任意连续10s的HC数据平均值是否超标500%
        /// </summary>
        ///  <param name="list">工况10s的数据平均值</param>
        ///  <param name="list">限值</param>
        /// <returns>超值或0</returns>
       

        public float isHigh(string strsum, float max)
        {
            float b = 0;
            string[] s = strsum.Split(new char[] { ',' });
            try
            {
                for (int i = 1; i <= s.Length - 1; i++)
                {
                    string st = s[i];

                    float flo = float.Parse(st);
                    if (flo > max * 5)
                    {

                        b = flo;
                    }
                }

            }
            catch(Exception e)
            {
                throw e;
            }
         
            string str = b.ToString("0.0");
            float last = float.Parse(str);
            return last;

        }

        /// <summary>
        ///计算最大功率下的转鼓线速度VelMaxHP
        /// </summary>
        ///  <param name="ZgSpeed">转鼓线速度</param>
        ///  <param name="FdjSpeed">发动机额定转速</param>
        ///  <param name="FdjMaxSpeed">发动机最大转速</param>
        /// <returns>最大功率下的转鼓线速度VelMaxHP</returns>


        public float getVelMaxHP(float ZgSpeed, float FdjSpeed,float FdjMaxSpeed)
        {
            float vel = 0;
            vel = ZgSpeed * FdjSpeed / FdjMaxSpeed;
            string str = vel.ToString("0.0");
            float last = float.Parse(str);

            return last;

        }

        /// <summary>
        ///计算所需最小轮边功率
        /// </summary>
        ///  <param name="FdjSpeed">发动机额定转速</param>     
        /// <returns>最小轮边功率</returns>


        public float getMinVelPower( float FdjEdPower)
        {
            float vel = 0;
            vel = FdjEdPower / 2;
            string str = vel.ToString("0.0");
            float last = float.Parse(str);
            return last;

        }


        /// <summary>
        ///测功机加载减速
        /// </summary>
        ///  <param name="speed">转鼓速度</param>     
        public void cgjJzJs(float speed)
        {


        }

        /// <summary>
        ///加载减速5s数据取平均值
        /// </summary>
        ///  <param name="list">加载减速每秒数据集合</param>
        /// <returns>5s的平均值</returns>
        public float getAverage(string list)
        {
            string[] s = list.Split(new char[] { ',' });
            float sum = 0;
            float av = 0;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    string strhc = s[i];
                    float flohc = float.Parse(strhc);
                    sum += flohc;
                }
               
            }
            catch(Exception e)
            {
                throw e;
            }
            av = sum / 5;
            string strav = av.ToString("0.0");
            float floav = float.Parse(strav);
            return floav;

        }



        /// <summary>
        ///计算吸收功率的修正
        /// </summary>
        ///  <param name="wendu">温度</param>     
        ///  <param name="qiya">气压</param>  
        ///  <param name="power">功率</param>  
        ///   <param name="type">进气方式</param> 
        /// <returns>修正后的吸收功率</returns>
        public float getUpdatePower(float wendu, float qiya, float power, string type)
        {
            double updateP = 0;//修正功率
            double Fa = 0;//大气修正系数
            double Fm = 1.2;//发动机系数
            double a= 99 / qiya;
            double b= (wendu + 273) / 298;
            
            if (type == "自然吸气" || type == "机械增压")
            {
                ;
                Fa = a * Math.Pow(b, 0.7);
                updateP = Math.Pow(Fa, Fm) * power;
            } 
            else
                if (type == "涡轮增压" || type == "涡轮增压中冷")
               {
                   Fa = Math.Pow(a, 0.7) * Math.Pow(b, 1.5);
                    updateP = Math.Pow(Fa, Fm) * power;
                }

            string str= updateP.ToString("0.0");
            float last = float.Parse(str);
            return last;

        }
        /// <summary>
        /// 获取字符串最大值
        /// </summary>
        /// <returns>字符串最大值</returns>
        public float getMax(string list)
        {
            float Max = 0;
            string[] s = list.Split(new char[] { ',' });

            for (int i = 1; i < s.Length - 1; i++)
            {

                if (float.Parse(s[i]) > Max)
                {
                    Max = float.Parse(s[i]);
                }
            }

            return Max;

        }


        /// <summary>
        ///计算最大轮边功率时的转鼓线速度作为真实的VelMaxHP
        /// </summary>
        ///  <param name="fdjSpeedlist">发动机转速集合</param>     
        ///  <param name="zgSpeedlist">转鼓速度集合</param>   
        /// <returns>真实的VelMaxHP</returns>
        public float getTrueMaxVelHP(string fdjSpeedlist,string zgSpeedlist)
        {
            float last = 0;
            float max = 0;
            int j = 0;
            string[] s = fdjSpeedlist.Split(new char[] { ',' });
            string[] s2 = zgSpeedlist.Split(new char[] { ',' });
            try
            {
                for (int i = 1; i <= s.Length-1; i++)
                {
                    string strhc = s[i];
                    float flohc = float.Parse(strhc);
                    if (flohc > max)
                    {
                        max = flohc;
                        j = i;

                    }
                }
                last = float.Parse(s2[j]);

            }
            catch (Exception e)
            {
                throw e;
            }
            return last;

        }
        public string getIp()
        {
            string strHostName = Dns.GetHostName(); //得到本机的主机名 
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP  
            foreach (IPAddress ip in ipEntry.AddressList)
            {
                if (ip.ToString().StartsWith("192") == true)
                    return ip.ToString();
            }
            //IPAddress ip = ipEntry.AddressList[ipEntry.AddressList.Count()-1];
            return "0.0.0.0";
        }
    }
}
