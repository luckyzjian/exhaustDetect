using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Detect
{
    public class shuju
    {
        string KList = "";
        string FdjSpeedList = "";
        string CarPowerList = "";   
        string ZgSpeedList = "";
        string ZgLiList = "";

        string KList90 = "";
        string FdjSpeedList90 = "";
        string CarPowerList90 = "";
        string ZgSpeedList90 = "";

        string KList80 = "";
        string FdjSpeedList80 = "";
        string CarPowerList80 = "";
        string ZgSpeedList80 = "";

        string CgjPowerList = "";
        string HCList = "";
        string COList = "";
        string NOList = "";

        /// <summary>
        /// 获取温度值
        /// </summary>
        /// <returns>某温度值</returns>
        public float getWENDU()
        {
            Random rd = new Random();
            float i = rd.Next(18, 30);
            return i;
        }
        /// <summary>
        /// 获取湿度值
        /// </summary>
        /// <returns>某湿度值</returns>
        public float getSHIDU()
        {
            Random rd = new Random();
            float i = rd.Next(60, 80);
            return i;
        }

        /// <summary>
        /// 获取气压值
        /// </summary>
        /// <returns>某气压值</returns>
        public float getQIYA()
        {
            Random rd = new Random();
            float i = rd.Next(25, 30);
            return i;
        }
        /// <summary>
        /// 获取工况某一秒钟HC值
        /// </summary>
        /// <returns>某一秒HC值</returns>
        public float getHC()
        {
            Random rd = new Random();
            float i = rd.Next(1, 30);
            return i;
        }


        /// <summary>
        /// 获取工况某一秒钟CO值
        /// </summary>
        /// <returns>某一秒CO值</returns>
        public float getCO()
        {
            Random rd = new Random();
            float i = rd.Next(1, 10);
            i = 1 / 10;
            return i;
        }


        /// <summary>
        /// 获取工况某一秒钟CO2值
        /// </summary>
        /// <returns>某一秒CO2值</returns>
        public float getCO2()
        {
            Random rd = new Random();
            float i = rd.Next(1, 2);
           
            return i;
        }


        /// <summary>
        /// 获取工况某一秒钟NO值
        /// </summary>
        /// <returns>某一秒NO值</returns>
        public float getNO()
        {
            Random rd = new Random();
            float i = rd.Next(1, 2);
            return i;
        }

        /// <summary>
        /// 获取工况每秒钟HC值
        /// </summary>
        /// <returns>每秒HC值拼接的字符串</returns>
        public string getHCList()
        {
           
            float i = getHC();
            HCList = HCList + "," + i.ToString();
            return HCList;
        }
        /// <summary>
        /// 获取工况每秒钟CO值
        /// </summary>
        /// <returns>每秒CO值拼接的字符串</returns>
        public string getCOList()
        {
           
            float i = getCO();
            COList = COList + "," + i.ToString();
            return COList;
        }
        /// <summary>
        /// 获取工况每秒钟NO值
        /// </summary>
        /// <returns>每秒NO值拼接的字符串</returns>
        public string getNOList()
        {
            
            float i = getNO();
            NOList = NOList + "," + i.ToString();
            return NOList;
        }


        /// <summary>
        /// 获取工况某一秒钟车速值
        /// </summary>
        /// <returns>某一秒车速值</returns>
        public float getCarSpeed()
        {
            Random rd = new Random();
            float i = rd.Next(2, 180);
            return i;
        }

        /// <summary>
        /// 获取工况某一秒发动机转速值
        /// </summary>
        /// <returns>某一秒发动机转速值</returns>
        public float getFdjSpeed()
        {
            Random rd = new Random();
            float i = rd.Next(1, 180);
            return i;
        }
        /// <summary>
        /// 获取工况某一秒发动机转速集合
        /// </summary>
        /// <returns>发动机转速集合的字符串</returns>
        public string getFdjSpeedList()
        {

            float i = getFdjSpeed();
            FdjSpeedList = FdjSpeedList + "," + i.ToString();
            return FdjSpeedList;
        }
        public string getFdjSpeedList90()
        {

            float i = getFdjSpeed();
            FdjSpeedList90 = FdjSpeedList90 + "," + i.ToString();
            return FdjSpeedList90;
        }
        public string getFdjSpeedList80()
        {

            float i = getFdjSpeed();
            FdjSpeedList80 = FdjSpeedList80 + "," + i.ToString();
            return FdjSpeedList80;
        }


 
        /// <summary>
        /// 获取工况某一秒钟车辆功率值
        /// </summary>
        /// <returns>某一秒车辆功率值</returns>
        public float getCarPower()
        {
            Random rd = new Random();
            float i = rd.Next(20, 80);
            return i;
        }

        /// <summary>
        /// 获取工况车辆功率集合
        /// </summary>
        /// <returns>车辆功率集合</returns>
        public string getCarPowerList()
        {

            float i = getCarPower();
            CarPowerList = CarPowerList + "," + i.ToString();
            return CarPowerList;
        }
        public string getCarPowerList90()
        {

            float i = getCarPower();
            CarPowerList90 = CarPowerList90 + "," + i.ToString();
            return CarPowerList90;
        }
        public string getCarPowerList80()
        {

            float i = getCarPower();
            CarPowerList80 = CarPowerList80 + "," + i.ToString();
            return CarPowerList80;
        }

    
        /// <summary>
        /// 获取工况某一秒测功机功率
        /// </summary>
        /// <returns>某一秒测功机功率</returns>
        public float getCgjPower()
        {
            Random rd = new Random();
            float i = rd.Next(23, 121);
            return i;
        }

        /// <summary>
        /// 获取工况某段时间测功机功率集合
        /// </summary>
        /// <returns>测功机功率集合</returns>
        public string getCgjPowerList()
        {

            float i = getCgjPower();
            CgjPowerList = CgjPowerList + "," + i.ToString();
            return CgjPowerList;
        }
  

        /// <summary>
        /// 获取工况某一秒转鼓线速度
        /// </summary>
        /// <returns>某一秒转鼓线速度</returns>
        public float getZgSpeed()
        {
            Random rd = new Random();
            float i = rd.Next(20, 120);
            return i;
        }


        /// <summary>
        /// 获取工况转鼓线速度集合
        /// </summary>
        /// <returns>鼓线速度集合</returns>
        public string getZgSpeedList()
        {

            float i = getZgSpeed();
            ZgSpeedList = ZgSpeedList + "," + i.ToString();
            return ZgSpeedList;
        }
        public string getZgSpeedList90()
        {

            float i = getZgSpeed();
            ZgSpeedList90 = ZgSpeedList90 + "," + i.ToString();
            return ZgSpeedList90;
        }
        public string getZgSpeedList80()
        {

            float i = getZgSpeed();
            ZgSpeedList80 = ZgSpeedList80 + "," + i.ToString();
            return ZgSpeedList80;
        }

        /// <summary>
        /// 获取工况转鼓表面制动力
        /// </summary>
        /// <returns>制动力</returns>
        public float getZgLi()
        {
            Random rd = new Random();
            float i = rd.Next(50, 200);
            return i;
        }
        public string getZgLiList()
        {
            float i = getZgLi();
            ZgLiList = ZgLiList + "," + i.ToString();
            return ZgLiList;
        }
        /// <summary>
        /// 获取工况某一秒光吸收系数K
        /// </summary>
        /// <returns>某一秒K</returns>
        public float getK()
        {
            Random rd = new Random();
            float i = rd.Next(50, 89);
            return i;
        }

        /// <summary>
        /// 获取工况某时段光吸收系数K集合
        /// </summary>
        /// <returns>某时段K的集合</returns>
        public string getKList()
        {
            float i = getFdjSpeed();
            KList = KList + "," + i.ToString();
            return KList;
        }
        public string getKList90()
        {
            float i = getFdjSpeed();
            KList90 = KList90 + "," + i.ToString();
            return KList90;
        }
        public string getKList80()
        {
            float i = getFdjSpeed();
            KList80 = KList80 + "," + i.ToString();
            return KList80;
        }
   
    }
    
}
