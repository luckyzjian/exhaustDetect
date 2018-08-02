using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ini;

namespace carinfor
{

    public class yhcarInidata
    {
        public yhcarInidata()
        {
            检测流水号 = "";
            检测类型 = 0;
            动力检测类型 = 0;
            车辆号牌 = "";
            号牌种类 = "";
            车辆型号 = "";
            发动机型号 = "";
            油耗限值依据 = 0;
            油耗限值 = 0;
            油耗检测加载力 = 0;
            油耗检测工况速度 = 0;
            燃料种类 = 0;
            子午胎轮胎断面宽度 = 0;
            汽车前轮距 = 0;
            汽车高度 = 0;
            客车车长 = 0;
            客车等级 = 0;
            汽车类型 = 0;
            货车车身型式 = 0;
            额定总质量 = 0;
            是否危险货物运输车辆 = 0;
            动力性检测加载力 = 0;
            加载力计算方式 = 1;
            驱动轴数 = 1;
            轮胎类型 = 0;
            压燃式功率参数类型 = 0;
            压燃式额定功率 = 0;
            点燃式额定扭矩 = 0;
            驱动轴空载质量 = 0;
            牵引车满载总质量 = 0;
            加载力比例 = 1;
            驱动轴质量方式 = 0;
            油耗车速方式 = 0;
            是否检测动力性 = false;
            是否检测油耗 = false;
            是否检测车速 = false;
        }
        public string 检测流水号 { set; get; }
        /// <summary>
        ///调用动力性检测时用 0:只检测动力性 1：只检测车速 2：车速与动力性均检测
        /// </summary>
        public int 检测类型 { set; get; }

        /// <summary>
        /// 0-达标检测 1-自动进行等级评定 2-单做二级评定 3-单做一级评定
        /// </summary>
        public int 动力检测类型 { set; get; }
        public string 检测性质 { set; get; }
        public string 车辆号牌 { set; get; }
        public string 号牌种类 { set; get; }

        public string 车辆型号 { set; get; }
        public string 发动机型号 { set; get; }

        //油耗定义
        /// <summary>
        /// 0:子程序根据车型判断 1:由“油耗限值”指定
        /// </summary>
        public int 油耗限值依据 { set; get; }
        public double 油耗限值 { set; get; }
        public double 油耗检测加载力 { set; get; }
        public double 油耗检测工况速度 { set; get; }
        /// <summary>
        /// 0:汽油 1：柴油
        /// </summary>
        public int 燃料种类 { set; get; }
        /// <summary>
        /// 单位：in
        /// </summary>
        public double 子午胎轮胎断面宽度 { set; get; }
        /// <summary>
        /// 单位：mm
        /// </summary>
        public double 汽车前轮距 { set; get; }
        /// <summary>
        /// 单位：mm
        /// </summary>
        public double 汽车高度 { set; get; }
        public double 客车车长 { set; get; }
        /// <summary>
        /// 0:高级 1：中级 2：普通级
        /// </summary>
        public int 客车等级 { set; get; }
        /// <summary>
        /// 0:营运客车  1:营运货车
        /// </summary>
        public int 汽车类型 { set; get; }

        /// <summary>
        /// 0-拦板车 1-自卸车 2-牵引车 3-仓栅车 4-厢式车 5-罐车
        /// </summary>
        public int 货车车身型式 { set; get; }
        public double 额定总质量 { set; get; }
        //功率定义
        /// <summary>
        /// 0:否 1：是
        /// </summary>
        public int 是否危险货物运输车辆 { set; get; } //是否危险品

        public double 动力性检测加载力 { set; get; }
        /// <summary>
        /// 0:上层传入加载力值  1:根据车辆信息计算加载力
        /// </summary>
        public int 加载力计算方式 { set; get; }
        /// <summary>
        /// 1:单驱动轴 2;双驱动轴
        /// </summary>
        public int 驱动轴数 { set; get; }
        /// <summary>
        /// 0:子午线轮胎  1:斜交轮胎
        /// </summary>
        public int 轮胎类型 { set; get; }

        /// <summary>
        /// 0:发动机铭牌以额定功率表示 1:发动机铭牌以最大净功率表征
        /// </summary>
        public int 压燃式功率参数类型 { set; get; }
        /// <summary>
        /// 压燃式发动机需要
        /// </summary>
        public double 压燃式额定功率 { set; get; }
        /// <summary>
        /// 点燃式发动机需要
        /// </summary>
        public double 点燃式额定扭矩 { set; get; }
        /// <summary>
        /// 点燃式发动机需要,当额定扭矩转速为nm1~nm2时，取其均值
        /// </summary>
        public double 点燃式额定扭矩转速 { set; get; }
        /// <summary>
        /// 驱动轴重量方式 0：文本文件传入 1：称重台称重
        /// </summary>
        public int 驱动轴质量方式 { set; get; }
        /// <summary>
        /// 油耗车速方式 0：子程序自动根据车辆信息确定 1：由文本文件传入
        /// </summary>
        public int 油耗车速方式 { set; get; }
        public bool 是否检测动力性 { set; get; }
        public bool 是否检测车速 { set; get; }
        public bool 是否检测油耗 { set; get; }
        public double 驱动轴空载质量 { set; get; }
        public double 牵引车满载总质量 { set; get; }
        public double 加载力比例 { set; get; }
    }
    public class SpeedResult
    {
        public double 车速;
        public int 车速判定结果;
    }
    public class fuelResult
    {
        public fuelResult()
        {
            this.速度曲线 = "";
            this.扭力曲线 = "";
            this.功率曲线 = "";
            this.油耗曲线 = "";
        }
        public double 检测速度;
        public double 台架加载阻力;
        public double 燃料总消耗量;
        public double 总行驶里程;
        public double 百公里燃料消耗量;
        public double 限值;
        /// <summary>
        /// 0-列入交通运输主管部门公布的车辆 1-未列入交通运输主管部门公布的车辆 2-牵引车按牵引车满载总质量进行检测时
        /// </summary>
        public int 限值依据;
        /// <summary>
        /// 0-合格 1-不合格
        /// </summary>
        public int 判定结果;
        public double 汽车滚动阻力;
        public double 空气阻力;
        public double 滚动阻力系数;
        public double 迎风面积;
        public double 空气阻力系数;
        public double 台架运转阻力;
        public double 台架滚动阻力;
        public double 台架滚动阻力系数;
        public double 台架内阻;
        public string 速度曲线;
        public string 扭力曲线;
        public string 功率曲线;
        public string 油耗曲线;
    }
    public class DieselDynamicResult
    {
        public DieselDynamicResult()
        {
            this.速度曲线 = "";
            this.扭力曲线 = "";
            this.功率曲线 = "";
        }
        public int 检测类型;
        public double 车速;
        public int 车速判定结果;
        public double 功率比值系数;//η
        public double 额定功率;//Pe
        public double 额定功率车速;//Ve
        public double 稳定车速;//Vw
        public double 台架滚动阻力;//Fe
        public double 加载力;//FE
        public double 测功机内阻;//Ftc
        public double 轮胎滚动阻力;//Fc
        public double 发动机附件阻力;//Ff
        public double 车辆传动系允许阻力;//Ft
        public double 功率校正系数;//αd
        public double 台架滚动阻力系数;//fc
        public double 温度;
        public double 湿度;
        public double 大气压;
        public int 判定结果;
        /// <summary>
        /// 0-未评定 1-1级 2-2级
        /// </summary>
        public int 等级评定结果;
        public string 速度曲线;
        public string 扭力曲线;
        public string 功率曲线;
    }
    public class GasolineDynamicResult
    {
        public GasolineDynamicResult()
        {
            this.速度曲线 = "";
            this.扭力曲线 = "";
            this.功率曲线 = "";
        }
        public int 检测类型;
        public double 车速;
        public int 车速判定结果;
        public double 功率比值系数;//η
        public double 发动机额定扭矩;//Mm
        public double 额定扭矩车速;//Vm
        public double 额定扭矩转速;//nm
        public double 稳定车速;//Vw
        public double 加载力;//FM
        public double 发动机达标扭矩驱动力;//Fm
        public double 测功机内阻;//Ftc
        public double 轮胎滚动阻力;//Fc
        public double 发动机附件阻力;//Ff
        public double 车辆传动系允许阻力;//Ft
        public double 功率校正系数;//αa
        public double 台架滚动阻力系数;//fc
        public double 温度;
        public double 湿度;
        public double 大气压;
        /// <summary>
        /// 0-合格 1-不合格
        /// </summary>
        public int 判定结果;
        /// <summary>
        /// 0-未评定 1-1级 2-2级
        /// </summary>
        public int 等级评定结果;
        public string 速度曲线;
        public string 扭力曲线;
        public string 功率曲线;
    }
    public class carInidata
    {
        public carInidata()
        {
            scrq = DateTime.Now;
        }
        private string carID;//车辆ID

        public string CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private string carPH;//车辆牌号

        public string CarPH
        {
            get { return carPH; }
            set { carPH = value; }
        }
        public string jqfs { set; get; }
        private double carJzzl;//基准质量

        public double CarJzzl
        {
            get { return carJzzl; }
            set { carJzzl = value; }
        }
        private string carRlzl;//燃料类型

        public string CarRlzl
        {
            get { return carRlzl; }
            set { carRlzl = value; }
        }
        private double carEdgl;//额定功率

        public double CarEdgl
        {
            get { return carEdgl; }
            set { carEdgl = value; }
        }
        private double carEdzs;//额定转速

        public double CarEdzs
        {
            get { return carEdzs; }
            set { carEdzs = value; }
        }
        private string carBsxlx;//变速箱类型

        public string CarBsxlx
        {
            get { return carBsxlx; }
            set { carBsxlx = value; }
        }
        private double carLxcc;//连续超差时限

        public double CarLxcc
        {
            get { return carLxcc; }
            set { carLxcc = value; }
        }
        private double carLjcc;//累计超差时限

        public double CarLjcc
        {
            get { return carLjcc; }
            set { carLjcc = value; }
        }
        private double carNdz;//浓度限值

        public double CarNdz
        {
            get { return carNdz; }
            set { carNdz = value; }
        }
        private string carCc;//冲程

        public string CarCc
        {
            get { return carCc; }
            set { carCc = value; }
        }
        private double xz1;//hc 5025

        public double Xz1
        {
            get { return xz1; }
            set { xz1 = value; }
        }
        private double xz2;//co 5025

        public double Xz2
        {
            get { return xz2; }
            set { xz2 = value; }
        }
        private double xz3;//no 5025

        public double Xz3
        {
            get { return xz3; }
            set { xz3 = value; }
        }
        private double xz4;//hc 2540

        public double Xz4
        {
            get { return xz4; }
            set { xz4 = value; }
        }
        private double xz5;//co 2540

        public double Xz5
        {
            get { return xz5; }
            set { xz5 = value; }
        }
        private double xz6;//no 2540

        public double Xz6
        {
            get { return xz6; }
            set { xz6 = value; }
        }
        private int carZzl;

        public int CarZzl
        {
            get { return carZzl; }
            set { carZzl = value; }
        }

        private float ambientCOUp;

        public float AmbientCOUp
        {
            get { return ambientCOUp; }
            set { ambientCOUp = value; }
        }
        private float ambientCO2Up;

        public float AmbientCO2Up
        {
            get { return ambientCO2Up; }
            set { ambientCO2Up = value; }
        }
        private float ambientHCUp;

        public float AmbientHCUp
        {
            get { return ambientHCUp; }
            set { ambientHCUp = value; }
        }
        private float ambientNOUp;

        public float AmbientNOUp
        {
            get { return ambientNOUp; }
            set { ambientNOUp = value; }
        }
        private float backgroundCOUp;

        public float BackgroundCOUp
        {
            get { return backgroundCOUp; }
            set { backgroundCOUp = value; }
        }
        private float backgroundCO2Up;

        public float BackgroundCO2Up
        {
            get { return backgroundCO2Up; }
            set { backgroundCO2Up = value; }
        }
        private float backgroundHCUp;

        public float BackgroundHCUp
        {
            get { return backgroundHCUp; }
            set { backgroundHCUp = value; }
        }
        private float backgroundNOUp;

        public float BackgroundNOUp
        {
            get { return backgroundNOUp; }
            set { backgroundNOUp = value; }
        }
        private float residualHCUp;

        public float ResidualHCUp
        {
            get { return residualHCUp; }
            set { residualHCUp = value; }
        }
        private float cOAndCO2;

        public float COAndCO2
        {
            get { return cOAndCO2; }
            set { cOAndCO2 = value; }
        }

        public double ASM_HC { set; get; }
        public double ASM_CO { set; get; }
        public double ASM_NO { set; get; }
        public double VMAS_HC { set; get; }
        public double VMAS_CO { set; get; }
        public double VMAS_NO { set; get; }
        public double SDS_HC { set; get; }
        public double SDS_CO { set; get; }
        public double ZYJS_K { set; get; }
        public double JZJS_K { set; get; }
        public double JZJS_GL { set; get; }
        public bool ISUSE { set; get; }
        public bool ISMOTO { set; get; }
        public DateTime scrq { set; get; }
    }
    public class resultData
    {
        private string clhp;

        public string Clhp
        {
            get { return clhp; }
            set { clhp = value; }
        }
        private string jcsj;

        public string Jcsj
        {
            get { return jcsj; }
            set { jcsj = value; }
        }
        private string jcjg;

        public string Jcjg
        {
            get { return jcjg; }
            set { jcjg = value; }
        }
    }
    public class cycarinf
    {
        public string 车辆ID { set; get; }// = 辽A12345A20010101 //辽A12345为车牌号 A为车牌颜色,20010101为登记期
        public string 检测流水号 { set; get; }// = M00201305080001
        public int 检测次数 { set; get; }//= 1
        public string 车辆牌照号 { set; get; }// = 辽A12345
        public string 车牌颜色 { set; get; }// = 黄牌
        public string 车辆类别 { set; get; }// = K33         //详见车辆信息代码表
        public string 厂牌名称 { set; get; }// = 江淮(JAC)
        public string 厂牌型号 { set; get; }// = HFC5080CCYK4R1T
        public string 发动机型号 { set; get; }// = CY4102 - E3D
        public string 使用情况 { set; get; }//= 2           //详见车辆信息代码表
        public string 使用性质 { set; get; }// = A           //详见车辆信息代码表
        public string 驱动形式 { set; get; }// = 0           // 详见车辆信息代码表
        public int 整车质量 { set; get; }// = 1500
        public int 整备质量 { set; get; }//= 1000
        public int 核准载客 { set; get; }// = 5
        public int 基准质量 { set; get; }// = 1000
        public string 燃料种类 { set; get; }// = A         // 详见车辆信息代码表
        public string 发动机排量 { set; get; }// = 1.0
        public double 额定功率 { set; get; }// = 100
        public int 额定转速 { set; get; }// = 2000
        public string 进气方式 { set; get; }// =            // 详见车辆信息代码表
        public string 冲程数 { set; get; }// = 4             //冲程数
        public string 初次登记日期 { set; get; }//= 2010-05-01
        public string 生产日期 { set; get; }//= 2010-03-01
        public string 变速箱 { set; get; }// = 0             // 详见车辆信息代码表
        public string 双排气管 { set; get; }// =
        public string 是否有三元催化转化器 { set; get; }// = 0           //0-无  1-有
        public string 供油方式 { set; get; }// = 0                       //详见车辆信息代码表  
        public string 是否有排气后处理装置 { set; get; }// = 0           //0-无  1-有
        public string 车主 { set; get; }//=
        public string 电话 { set; get; }// =
        public string 检测类别 { set; get; }// = 01          //详见车辆信息代码表
        public string 检测方法 { set; get; }// = A           //详见车辆信息代码表
        public double 连续超差 { set; get; }// = 2 //控制连接超差，如超过此数值检测程序重新检测车辆
        public double 累计超差 { set; get; }// = 10 //控制累计超差，如超过此数值检测程序重新检测车辆
        public double 浓度值 { set; get; }// = 2   //根据提供浓度值进行车辆检测
    }
    public class carIni
    {
        public carInidata getCarIni()
        {
            float a=0;
            carInidata carinidata=new carInidata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆ID", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.CarID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆牌照号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.CarPH = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "基准质量", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarJzzl=a;
            else
                carinidata.CarJzzl=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "燃料种类", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.CarRlzl = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "额定功率", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarEdgl=a;
            else
                carinidata.CarEdgl=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "额定转速", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarEdzs=a;
            else
                carinidata.CarEdzs=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "变速箱", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.CarBsxlx = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "连续超差", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarLxcc=a;
            else
                carinidata.CarLxcc=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "累计超差", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarLjcc=a;
            else
                carinidata.CarLjcc=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "浓度值", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if(float.TryParse(temp.ToString().Trim(),out a))
                carinidata.CarNdz=a;
            else
                carinidata.CarNdz=0;
            ini.INIIO.GetPrivateProfileString("检测信息", "冲程", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.CarCc = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "限值1", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz1 = a;
            else
                carinidata.Xz1 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "限值2", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz2 = a;
            else
                carinidata.Xz2 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "限值3", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz3 = a;
            else
                carinidata.Xz3 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "限值4", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz4 = a;
            else
                carinidata.Xz4 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "限值5", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz5 = a;
            else
                carinidata.Xz5 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "限值6", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.Xz6 = a;
            else
                carinidata.Xz6 = 0;

            ini.INIIO.GetPrivateProfileString("检测信息", "AmbientCOUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.AmbientCOUp = a;
            else
                carinidata.AmbientCOUp = 0;
            //return carinidata;
            ini.INIIO.GetPrivateProfileString("检测信息", "AmbientHCUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.AmbientHCUp = a;
            else
                carinidata.AmbientHCUp = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "AmbientNOUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.AmbientNOUp = a;
            else
                carinidata.AmbientNOUp = 0;

            //return carinidata;
            ini.INIIO.GetPrivateProfileString("检测信息", "BackgroundCO2Up", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.BackgroundCO2Up = a;
            else
                carinidata.BackgroundCO2Up = 0;

            ini.INIIO.GetPrivateProfileString("检测信息", "BackgroundCOUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.BackgroundCOUp = a;
            else
                carinidata.BackgroundCOUp = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "BackgroundHCUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.BackgroundHCUp = a;
            else
                carinidata.BackgroundHCUp = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "BackgroundNOUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.BackgroundNOUp = a;
            else
                carinidata.BackgroundNOUp = 0;

            ini.INIIO.GetPrivateProfileString("检测信息", "ResidualHCUp", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (float.TryParse(temp.ToString().Trim(), out a))
                carinidata.ResidualHCUp = a;
            else
                carinidata.ResidualHCUp = 0;
            return carinidata;
        }
        public cycarinf getCyCarIni()
        {
            double a = 0;
            int b = 0;
            cycarinf carinidata = new cycarinf();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆ID", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车辆ID = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "检测流水号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.检测流水号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "检测次数", "1", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.检测次数 = b;
            else
                carinidata.检测次数 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆牌照号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车辆牌照号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "车牌颜色", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车牌颜色 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆类别", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车辆类别 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "厂牌名称", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.厂牌名称 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "厂牌型号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.厂牌型号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "发动机型号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.发动机型号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "使用情况", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.使用情况 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "使用性质", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.使用性质 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "驱动形式", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.驱动形式 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "整车质量", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.整车质量 = b;
            else
                carinidata.整车质量 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "整备质量", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.整备质量 = b;
            else
                carinidata.整备质量 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "核准载客", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.核准载客 = b;
            else
                carinidata.核准载客 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "基准质量", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.基准质量 = b;
            else
                carinidata.基准质量 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "燃料种类", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.燃料种类 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "发动机排量", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.发动机排量 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "额定功率", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.额定功率 = a;
            else
                carinidata.额定功率 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "额定转速", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.额定转速 = b;
            else
                carinidata.额定转速 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "进气方式", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.进气方式 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "冲程数", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.冲程数 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "初次登记日期", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.初次登记日期 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "生产日期", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.生产日期 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "变速箱", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.变速箱 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "双排气管", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.双排气管 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "是否有三元催化转化器", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.是否有三元催化转化器 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "供油方式", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.供油方式 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "是否有排气后处理装置", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.是否有排气后处理装置 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "车主", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车主 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "电话", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.电话 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "检测类别", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.检测类别 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "检测方法", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.检测方法 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "连续超差", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.连续超差 = a;
            else
                carinidata.连续超差 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "累计超差", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.累计超差 = a;
            else
                carinidata.累计超差 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "浓度值", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.浓度值 = a;
            else
                carinidata.浓度值 = 0;

            return carinidata;
        }
        public bool writeCarIni(carInidata carinidata,string fileDir,string dircectDir)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆ID", carinidata.CarID, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆牌照号", carinidata.CarPH, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "进气方式", carinidata.jqfs, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "生产日期", carinidata.scrq.ToString("yyyy-MM-dd"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "基准质量", carinidata.CarJzzl.ToString("0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "总质量", carinidata.CarZzl.ToString("0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "燃料种类", carinidata.CarRlzl, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "额定功率", carinidata.CarEdgl.ToString("0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "额定转速", carinidata.CarEdzs.ToString("0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "变速箱", carinidata.CarBsxlx, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "连续超差", carinidata.CarLxcc.ToString("0.0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "累计超差", carinidata.CarLjcc.ToString("0.0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "浓度值", carinidata.CarNdz.ToString("0.0"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "冲程", carinidata.CarCc, fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值1", carinidata.Xz1.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值2", carinidata.Xz2.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值3", carinidata.Xz3.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值4", carinidata.Xz4.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值5", carinidata.Xz5.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "限值6", carinidata.Xz6.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ASM_CO", carinidata.ASM_CO.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ASM_HC", carinidata.ASM_HC.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ASM_NO", carinidata.ASM_NO.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "VMAS_CO", carinidata.VMAS_CO.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "VMAS_HC", carinidata.VMAS_HC.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "VMAS_NO", carinidata.VMAS_NO.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "SDS_CO", carinidata.SDS_CO.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "SDS_HC", carinidata.SDS_HC.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ZYJS_K", carinidata.ZYJS_K.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "JZJS_K", carinidata.JZJS_K.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "JZJS_GL", carinidata.JZJS_GL.ToString("0.000"), fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ISUSE", carinidata.ISUSE?"Y":"N", fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "ISMOTO", carinidata.ISMOTO ? "Y" : "N", fileDir);
                ini.INIIO.WritePrivateProfileString("检测信息", "目标文件夹", dircectDir, fileDir);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool writeResultData(resultData result_data)
        {

            try
            {
                if (File.Exists("C:/resultdatatxt/result.ini"))
                {
                    File.Delete("C:/resultdatatxt/result.ini");
                }
                ini.INIIO.WritePrivateProfileString("检测结果", "车辆号牌", result_data.Clhp, "C:/resultdatatxt/result.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "检测结果", result_data.Jcjg, "C:/resultdatatxt/result.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "检测时间", result_data.Jcsj, "C:/resultdatatxt/result.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool writeYhCarIni(yhcarInidata carinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("检测信息", "检测流水号", carinidata.检测流水号, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "检测类型", carinidata.检测类型.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "检测性质", carinidata.检测性质, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "动力检测类型", carinidata.动力检测类型.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆号牌", carinidata.车辆号牌, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "号牌种类", carinidata.号牌种类, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆型号", carinidata.车辆型号, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "发动机型号", carinidata.发动机型号, @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗限值依据", carinidata.油耗限值依据.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗限值", carinidata.油耗限值.ToString("0.00"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗检测加载力", carinidata.油耗检测加载力.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗检测工况速度", carinidata.油耗检测工况速度.ToString("0.0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "燃料种类", carinidata.燃料种类.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "子午胎轮胎断面宽度", carinidata.子午胎轮胎断面宽度.ToString("0.000"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车前轮距", carinidata.汽车前轮距.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车高度", carinidata.汽车高度.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "客车车长", carinidata.客车车长.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "客车等级", carinidata.客车等级.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车类型", carinidata.汽车类型.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "货车车身型式", carinidata.货车车身型式.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "额定总质量", carinidata.额定总质量.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否危险货物运输车辆", carinidata.是否危险货物运输车辆.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "动力性检测加载力", carinidata.动力性检测加载力.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "加载力计算方式", carinidata.加载力计算方式.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴数", carinidata.驱动轴数.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "轮胎类型", carinidata.轮胎类型.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "压燃式功率参数类型", carinidata.压燃式功率参数类型.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "压燃式额定功率", carinidata.压燃式额定功率.ToString("0.0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "点燃式额定扭矩", carinidata.点燃式额定扭矩.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "点燃式额定扭矩转速", carinidata.点燃式额定扭矩转速.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴空载质量", carinidata.驱动轴空载质量.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "牵引车满载总质量", carinidata.牵引车满载总质量.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴质量方式", carinidata.驱动轴质量方式.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗车速方式", carinidata.油耗车速方式.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测车速", carinidata.是否检测车速?"Y":"N", @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测动力性", carinidata.是否检测动力性 ? "Y" : "N", @"C:\jcdatatxt\carinfo.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测油耗", carinidata.是否检测油耗 ? "Y" : "N", @"C:\jcdatatxt\carinfo.ini");
                //ini.INIIO.WritePrivateProfileString("检测信息", "加载力比例", carinidata.加载力比例.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool writeYhCarIniXn(yhcarInidata carinidata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("检测信息", "检测流水号", carinidata.检测流水号, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "检测类型", carinidata.检测类型.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "检测性质", carinidata.检测性质, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "动力检测类型", carinidata.动力检测类型.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆号牌", carinidata.车辆号牌, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "号牌种类", carinidata.号牌种类, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "车辆型号", carinidata.车辆型号, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "发动机型号", carinidata.发动机型号, @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗限值依据", carinidata.油耗限值依据.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗限值", carinidata.油耗限值.ToString("0.00"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗检测加载力", carinidata.油耗检测加载力.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗检测工况速度", carinidata.油耗检测工况速度.ToString("0.0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "燃料种类", carinidata.燃料种类.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "子午胎轮胎断面宽度", carinidata.子午胎轮胎断面宽度.ToString("0.000"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车前轮距", carinidata.汽车前轮距.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车高度", carinidata.汽车高度.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "客车车长", carinidata.客车车长.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "客车等级", carinidata.客车等级.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "汽车类型", carinidata.汽车类型.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "货车车身型式", carinidata.货车车身型式.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "额定总质量", carinidata.额定总质量.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否危险货物运输车辆", carinidata.是否危险货物运输车辆.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "动力性检测加载力", carinidata.动力性检测加载力.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "加载力计算方式", carinidata.加载力计算方式.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴数", carinidata.驱动轴数.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "轮胎类型", carinidata.轮胎类型.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "压燃式功率参数类型", carinidata.压燃式功率参数类型.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "压燃式额定功率", carinidata.压燃式额定功率.ToString("0.0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "点燃式额定扭矩", carinidata.点燃式额定扭矩.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "点燃式额定扭矩转速", carinidata.点燃式额定扭矩转速.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴空载质量", carinidata.驱动轴空载质量.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "牵引车满载总质量", carinidata.牵引车满载总质量.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "驱动轴质量方式", carinidata.驱动轴质量方式.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "油耗车速方式", carinidata.油耗车速方式.ToString("0"), @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测车速", carinidata.是否检测车速 ? "Y" : "N", @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测动力性", carinidata.是否检测动力性 ? "Y" : "N", @"C:\jcdatatxt\carinfoXn.ini");
                ini.INIIO.WritePrivateProfileString("检测信息", "是否检测油耗", carinidata.是否检测油耗 ? "Y" : "N", @"C:\jcdatatxt\carinfoXn.ini");
                //ini.INIIO.WritePrivateProfileString("检测信息", "加载力比例", carinidata.加载力比例.ToString("0"), @"C:\jcdatatxt\carinfo.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public yhcarInidata getYhCarIni()
        {
            double a = 0;
            int b = 0;
            yhcarInidata carinidata = new yhcarInidata();
            StringBuilder temp = new StringBuilder();
            temp.Length = 2048;

            ini.INIIO.GetPrivateProfileString("检测信息", "检测流水号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.检测流水号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆型号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车辆型号 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "发动机型号", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.发动机型号 = temp.ToString().Trim();

            ini.INIIO.GetPrivateProfileString("检测信息", "检测类型", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.检测类型 = b;
            else
                carinidata.检测类型 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "动力检测类型", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.动力检测类型 = b;
            else
                carinidata.动力检测类型 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "油耗限值依据", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.油耗限值依据 = b;
            else
                carinidata.油耗限值依据 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "油耗限值", "30", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.油耗限值 = a;
            else
                carinidata.油耗限值 = 30;
            ini.INIIO.GetPrivateProfileString("检测信息", "车辆号牌", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.车辆号牌 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "号牌种类", "", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.号牌种类 = temp.ToString().Trim();
            ini.INIIO.GetPrivateProfileString("检测信息", "油耗检测加载力", "200", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.油耗检测加载力 = a;
            else
                carinidata.油耗检测加载力 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "油耗检测工况速度", "50", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.油耗检测工况速度 = b;
            else
                carinidata.油耗检测工况速度 = 50;
            ini.INIIO.GetPrivateProfileString("检测信息", "燃料种类", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.燃料种类 = b;
            else
                carinidata.燃料种类 = 0;

            ini.INIIO.GetPrivateProfileString("检测信息", "子午胎轮胎断面宽度", "8.25", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.子午胎轮胎断面宽度 = a;
            else
                carinidata.子午胎轮胎断面宽度 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "汽车前轮距", "1000", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.汽车前轮距 = a;
            else
                carinidata.汽车前轮距 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "汽车高度", "1500", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.汽车高度 = a;
            else
                carinidata.汽车高度 = 1500;
            ini.INIIO.GetPrivateProfileString("检测信息", "客车车长", "5500", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.客车车长 = a;
            else
                carinidata.客车车长 = 5500;

            ini.INIIO.GetPrivateProfileString("检测信息", "客车等级", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.客车等级 = b;
            else
                carinidata.客车等级 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "汽车类型", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.汽车类型 = b;
            else
                carinidata.汽车类型 = 0;

            ini.INIIO.GetPrivateProfileString("检测信息", "货车车身型式", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.货车车身型式 = b;
            else
                carinidata.货车车身型式 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "额定总质量", "3500", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.额定总质量 = a;
            else
                carinidata.额定总质量 = 3500;
            ini.INIIO.GetPrivateProfileString("检测信息", "是否危险货物运输车辆", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.是否危险货物运输车辆 = b;
            else
                carinidata.是否危险货物运输车辆 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "动力性检测加载力", "200", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.动力性检测加载力 = a;
            else
                carinidata.动力性检测加载力 = 200;

            ini.INIIO.GetPrivateProfileString("检测信息", "加载力计算方式", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.加载力计算方式 = b;
            else
                carinidata.加载力计算方式 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "驱动轴数", "1", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.驱动轴数 = b;
            else
                carinidata.驱动轴数 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "轮胎类型", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.轮胎类型 = b;
            else
                carinidata.轮胎类型 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "压燃式功率参数类型", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.压燃式功率参数类型 = b;
            else
                carinidata.压燃式功率参数类型 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "压燃式额定功率", "200", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.压燃式额定功率 = a;
            else
                carinidata.压燃式额定功率 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "点燃式额定扭矩", "200", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.点燃式额定扭矩 = a;
            else
                carinidata.点燃式额定扭矩 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "点燃式额定扭矩转速", "4000", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.点燃式额定扭矩转速 = a;
            else
                carinidata.点燃式额定扭矩转速 = 4000;
            ini.INIIO.GetPrivateProfileString("检测信息", "驱动轴空载质量", "1000", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.驱动轴空载质量 = a;
            else
                carinidata.驱动轴空载质量 = 1000;
            ini.INIIO.GetPrivateProfileString("检测信息", "牵引车满载总质量", "200", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.牵引车满载总质量 = a;
            else
                carinidata.牵引车满载总质量 = 200;
            ini.INIIO.GetPrivateProfileString("检测信息", "加载力比例", "1", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (double.TryParse(temp.ToString().Trim(), out a))
                carinidata.加载力比例 = a;
            else
                carinidata.加载力比例 = 1;
            ini.INIIO.GetPrivateProfileString("检测信息", "驱动轴质量方式", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.驱动轴质量方式 = b;
            else
                carinidata.驱动轴质量方式 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "油耗车速方式", "0", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            if (int.TryParse(temp.ToString().Trim(), out b))
                carinidata.油耗车速方式 = b;
            else
                carinidata.油耗车速方式 = 0;
            ini.INIIO.GetPrivateProfileString("检测信息", "是否检测车速", "N", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.是否检测车速 = temp.ToString().Trim()=="Y";
            ini.INIIO.GetPrivateProfileString("检测信息", "是否检测动力性", "N", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.是否检测动力性 = temp.ToString().Trim() == "Y";
            ini.INIIO.GetPrivateProfileString("检测信息", "是否检测油耗", "N", temp, 2048, @"C:\jcdatatxt\carinfo.ini");
            carinidata.是否检测油耗 = temp.ToString().Trim() == "Y";
            return carinidata;
        }
        public bool writeYhyResultIni(fuelResult resultdata)
        {
            try
            {
                //configInfdata preConfigData = getConfigIni();
                ini.INIIO.WritePrivateProfileString("检测结果", "检测速度", resultdata.检测速度.ToString("0.0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架加载阻力", resultdata.台架加载阻力.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "燃料总消耗量", resultdata.燃料总消耗量.ToString("0.0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "总行驶里程", resultdata.总行驶里程.ToString("0.0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "百公里燃料消耗量", resultdata.百公里燃料消耗量.ToString("0.0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "限值", resultdata.限值.ToString("0.0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "限值依据", resultdata.限值依据.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "判定结果", resultdata.判定结果.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "汽车滚动阻力", resultdata.汽车滚动阻力.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "空气阻力", resultdata.空气阻力.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "滚动阻力系数", resultdata.滚动阻力系数.ToString("0.000"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "迎风面积", resultdata.迎风面积.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "空气阻力系数", resultdata.空气阻力系数.ToString("0.000"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架运转阻力", resultdata.台架运转阻力.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架滚动阻力", resultdata.台架滚动阻力.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架滚动阻力系数", resultdata.台架滚动阻力系数.ToString("0.000"), @"C:\jcdatatxt\fuelResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架内阻", resultdata.台架内阻.ToString("0"), @"C:\jcdatatxt\fuelResult.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool writeDieselDynamicResult(DieselDynamicResult resultdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("检测结果", "检测类型", resultdata.检测类型.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车速", resultdata.车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车速判定结果", resultdata.车速判定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "功率比值系数", resultdata.功率比值系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "额定功率", resultdata.额定功率.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "额定功率车速", resultdata.额定功率车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "稳定车速", resultdata.稳定车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架滚动阻力", resultdata.台架滚动阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "加载力", resultdata.加载力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "测功机内阻", resultdata.测功机内阻.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "轮胎滚动阻力", resultdata.轮胎滚动阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "发动机附件阻力", resultdata.发动机附件阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车辆传动系允许阻力", resultdata.车辆传动系允许阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "功率校正系数", resultdata.功率校正系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架滚动阻力系数", resultdata.台架滚动阻力系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "温度", resultdata.温度.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "湿度", resultdata.湿度.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "大气压", resultdata.大气压.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "判定结果", resultdata.判定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "等级评定结果", resultdata.等级评定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool writeGasolineDynamicResult(GasolineDynamicResult resultdata)
        {
            try
            {
                ini.INIIO.WritePrivateProfileString("检测结果", "检测类型", resultdata.检测类型.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车速", resultdata.车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车速判定结果", resultdata.车速判定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "功率比值系数", resultdata.功率比值系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "发动机额定扭矩", resultdata.发动机额定扭矩.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "额定扭矩车速", resultdata.额定扭矩车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "额定扭矩转速", resultdata.额定扭矩转速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "稳定车速", resultdata.稳定车速.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "加载力", resultdata.加载力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "发动机达标扭矩驱动力", resultdata.发动机达标扭矩驱动力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "测功机内阻", resultdata.测功机内阻.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "轮胎滚动阻力", resultdata.轮胎滚动阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "发动机附件阻力", resultdata.发动机附件阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "车辆传动系允许阻力", resultdata.车辆传动系允许阻力.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "功率校正系数", resultdata.功率校正系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "台架滚动阻力系数", resultdata.台架滚动阻力系数.ToString("0.000"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "温度", resultdata.温度.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "湿度", resultdata.湿度.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "大气压", resultdata.大气压.ToString("0.0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "判定结果", resultdata.判定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                ini.INIIO.WritePrivateProfileString("检测结果", "等级评定结果", resultdata.等级评定结果.ToString("0"), @"C:\jcdatatxt\DynamicResult.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string readDataFormFile(string filename)
        {
            StreamReader sr = new StreamReader(filename, Encoding.UTF8);
            String line;
            string jsonstring = "";
            while ((line = sr.ReadLine()) != null)
            {
                jsonstring += line.ToString();
            }
            sr.Close();
            /*
            byte[] byData = new byte[500];
            char[] charData = new char[1000];
            FileStream fs = new FileStream(filename, FileMode.Open);
            Decoder d = Encoding.Default.GetDecoder();
            fs.Read(byData, 0, 500); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
            d.GetChars(byData, 0, byData.Length, charData, 0);  */          
            return jsonstring;
        }
    }
}
