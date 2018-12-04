using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace NeusoftUtil
{
    public class EISRequestGetTime
    {
        public string EISID;
        public string name = "GetTime";
    }
    public class RespondGetTime
    {
        public string EISID;
        public string name;
        public DateTime scydatetime;
        public string result;
        //Result代表服务器状态：
        //-1代表服务器异常
        //其他值（0或1）代表服务器正常工作。
        public string ErrorMessage;
    }
    public class EISVerify
    //loginType:
    //0为检测登录
    //1为标定登录
    {
        public string EISID;
        public string name = "Verify";
        public string staffID;
        public string staffPassword;
        public string loginType;
    }
    public class VehicleInfo//如果没VIN号，则License和LicenseType必须同时存在，如果有VIN号，则License和LicenseType可以没有
    {
        public string EISID;
        public string name = "VehicleInfo";
        public string License;//车牌号码
        public string LicenseType;//车牌类别（0=蓝牌 1=黄牌 2=黑牌 3=白牌）
        public string VIN;
    }
    public class RespondVerify
    //result:
    //0：该用户不存在
    //1：该用户无此操作权限
    //2：该检测线被锁
    //3：检测登陆成功，请输入车牌号或者车架号查询被检车辆！
    //8：系统没有查到该车的车辆信息，请确认车牌或VIN是否正确！
    //9：外观检查不合格，不能检测！
    //10：该车没有交费，不能检测！
    //11：该车已检测，不能再次检测！
    //-1：服务器故障

    {
        public string EISID;
        public string name;
        public string result;
        public string ErrorMessage;
    }
    public class RespondVehicleInfo
    {
        public string EISID;
        public string OutlookID;//外观检验号
        public string name;
        public string License;//车辆牌号
        public string Vin;//VIN号
        public string RegisterDate;//车辆登记日期 Yyyy-mm-dd
        public string VehicleType;//0=6座以下小型客车 1=6座以上小型客车 2= 大型客车 3=小型货车 4=大型货车 5=三轮汽车和低速汽车 6=摩托车 7=三轮摩托车
        public string Model;//厂牌型号
        public string GearBoxType;//变速箱形式 0=手动 1=自动 2=手自一体 
        public string AdmissionMode;//进气方式 0=自然进气 1=涡轮增压
        public string Volume;//发动机排量
        public string Odometer;//里程表读数
        public string FuelType;//燃油类型 0=汽油 1=柴油 2=LPG 3=CNG 4=双燃料 5=乙醇 6=其他
        public string SupplyMode;//供油方式 0=化油器 1=化油器改造 2=开环电喷 3=闭环电喷
        public string RateRev;//发动机额定转速
        public string RatedPower;//发动机额定功率
        public string DriveMode;//驱动方式 0=前驱 1=后驱 2= 四驱 3=全时四驱
        public string Owner;//车主姓名
        public string Phone;//车主电话
        public string Address;//车主地址
        public string MaxMass;//最大总质量
        public string RefMass;//基准质量
        public string HasPurge;//是否有净化装置 0=否 1=是
        public string IsEFI;//是否是电喷发动机（采用电控高压柴油机）0=否 1=是
        public string MaxLoad;//客车：准乘人数 货车：额定载重
        public string CarOrTruck;//0=客车 1=货车
        public string Cylinder;//汽缸数
        public string YellowToGreen;//黄改绿设置 0：无改造 1：已改造 2：改造首检
        public string SignType;//0：黄票 1：绿无星 2：绿一星 3：绿二星 4：绿三星 5：绿四星
        /*************************LimitValue***************************/
        public string IsUsed;//是否使用改限值  0：不使用 1：使用
        public string AmbientCOUp;//环境CO上限
        public string AmbientCO2Up;//环境CO2上限
        public string AmbientHCUp;//环境 HC上限
        public string AmbientNOUp;//环境NO上限
        public string BackgroundCOUp;//背景CO上限
        public string BackgroundCO2Up;//背景CO2上限
        public string BackgroundHCUp;//背景HC上限
        public string BackgroundNOUp;//背景NO上限
        public string ResidualHCUp;//残留HC上限
        public string COAndCO2;//检测过程中CO+CO2浓度下限
        public string CO5025;
        public string HC5025;
        public string NO5025;
        public string CO2540;
        public string HC2540;
        public string NO2540;
        public string SmokeK;//Lugdown光吸收系统限值
        public string SmokeHSU;//Lugdown烟度限值
        public string DieselRevUp;//柴油车转速不得低于标定转速的百分比
        public string DieselRevBelow;//柴油车转速不得高于标定转速的百分比
        public string MaxPower;//Lugdown最大轮边功率不得低于发动机额定功率的百分比
        public string HighIdleCO;
        public string HighIdleHC;
        public string LowIdleCO;
        public string LowIdleHC;
        public string FASmokeK;//自由加速法光吸收系数限值
        public string FARev;//自由加速法发动机转速限值
    }
    public class StartTest
    {
        public string EISID;
        public string OutlookID;
        public string name = "StartTest";
    }
    public class RespondStartTest
    {
        public string EISID;
        public string name = "StartTest";
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class Testing5025
    {
        public string EISID;
        public string OutlookID;
        public string name = "Testing5025";
    }
    public class RespondTesting5025
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class Testing2540
    {
        public string EISID;
        public string OutlookID;
        public string name = "Testing2540";
    }
    public class RespondTesting2540
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class UploadGasolineResult
    {
        public string EISID;
        public string OutlookID;
        public string name = "UploadGasolineResult";
        public string Temperature;
        public string AirPressure;
        public string Humidity;
        public string AmbientCO;
        public string AmbientCO2;
        public string AmbientHC;
        public string AmbientNO;
        public string AmbientO2;
        public string BackgroundCO;
        public string BackgroundCO2;
        public string BackgroundHC;
        public string BackgroundNO;
        public string BackgroundO2;
        public string ResidualHC;
        public string CO5025;
        public string HC5025;
        public string NO5025;
        public string Power5025;
        public string Rev5025;
        public string Lambda5025;
        public string CO2540;
        public string HC2540;
        public string NO2540;
        public string Power2540;//2540加载总功率
        public string Rev2540;//2540转速结果
        public string Lambda2540;
        public string Result;//0:不合格 1：合格 2：中止 3：无效
        public string StartTime;//YYYY-MM-DD HH:mm:SS
        public string Has5025Tested;//是否做了5025工况 1：是 0：否
        public string Has2540Tested;//是否做了2540工况 1：是 0：否
        public string StopReason;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string AdjustZero;//是否调零标识 0-未调零 1-已调零
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始
        //public string DataType;//工况类型：0：5025检测中；1：2540检测中；3：加速过程或速度/转速稳定过程
        //public string Velocity;//滚筒线速度
        //public string Rev;//发动机转速
        //public string Power;//功率
        //public string CO;//CO测量值，未经修正
        //public string CO2;//CO2测量值，未经修正
        //public string HC;//HC测量值，未经修正
        //public string NO;//NO测量值，未经修正
        //public string O2;//O2测量值，未经修正
    }
    public class UploadVmasResult
    {
        public string OutlookID;
        public string name = "UploadGasVmasResult";
        public string Temperature;
        public string AirPressure;
        public string Humidity;
        public string AmbientO2;//流量分析仪环境O2（%）
        public string ResidualHC;//残留HC（10-6）
        public string TestTime;//有效测试时间(s)
        public string AirFlowAll;//流量分析仪稀释排放气体总流量(m3/min)
        public string CO;
        public string CO2;
        public string HC;
        public string NOX;
        public string HCNOX;
        public string Power;//测功机设定功率(kW)
        public string Result;//结果： 
                             //0：不合格
                             //1：合格
                             //2：中止
                             //3：无效

        public string StartTime;//YYYY-MM-DD HH:mm:SS 取过程数据时间
        public string StopReason;//引起检测中止或无效的原因：
                                 //0 = 无故障，检测正常
                                 //1 = 底盘测功机故障
                                 //2 = 废气分析仪故障
                                 //3 = 烟度计故障
                                 //4 = 转速计故障
                                 //5 = 超过允许重检次数
                                 //6 = 气体稀释
                                 //7 = 采样管被堵
                                 //8 = 车辆故障
                                 //9 = 用户主动终止
                                 //10 = 其他设备故障
                                 //11 = 其他原因
        public string AdjustZero;
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始
        //public string DataType;//工况类型：0：5025检测中；1：2540检测中；3：加速过程或速度/转速稳定过程
        //public string Velocity;//滚筒线速度
        //public string Rev;//发动机转速
        //public string Power;//功率
        //public string CO;//CO测量值，未经修正
        //public string CO2;//CO2测量值，未经修正
        //public string HC;//HC测量值，未经修正
        //public string NO;//NO测量值，未经修正
        //public string O2;//O2测量值，未经修正
    }
    public class RespondASMResultUpload
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
        public string CO5025;
        public string HC5025;
        public string NO5025;
        public string CO2540;
        public string HC2540;
        public string NO2540;
        public string TestResult;//0:不合格 1：合格 2：中止 3：无效
    }
    public class K100Testing
    {
        public string EISID;
        public string OutlookID;
        public string name = "K100Testing";
    }
    public class RespondK100Testing
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class K90Testing
    {
        public string EISID;
        public string OutlookID;
        public string name = "K90Testing";
    }
    public class RespondK90Testing
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class K80Testing
    {
        public string EISID;
        public string OutlookID;
        public string name = "K80Testing";
    }
    public class RespondK80Testing
    {
        public string EISID;
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
    }
    public class UploadDieselResult
    {
        public string OutlookID;
        public string name = "UploadDieselResult";
        public string Temperature;
        public string AirPressure;
        public string Humidity;
        public string K100;
        public string K90;
        public string K80;
        public string MaxPower;//实测最大轮边功率，修正后的
        public string Rev100;//100%VelMaxHP点的发动机转速（r/min）

        public string Result;//0:不合格 1：合格 2：中止 3：无效
        public string StartTime;//YYYY-MM-DD HH:mm:SS
        public string StopReason;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因

        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string DataType;//工况类型：0：功率扫描中；1：恢复到100%VelMaxHP过程中；2：100%VelMaxHP点检测过程；3：90%VelMaxHP点检测过程 4；80%VelMaxHP点检测过程 80%速度点以后的数据不要
        //public string Velocity;//滚筒线速度
        //public string Rev;//发动机转速
        //public string Power;//功率
        //public string SmokeK;//CO测量值，未经修正
    }
    public class UploadDIdleResult
    {
        public string OutlookID;
        public string name = "UploadDIdleResult";
        public string Temperature;
        public string AirPressure;
        public string Humidity;
        public string LowIdleCO;
        public string LowIdleHC;
        public string HighIdleCO;
        public string HighIdleHC;
        public string LowIdleRev;
        public string HighIdleRev;
        public string OilTemperature;
        public string Lambda;


        public string Result;//0:不合格 1：合格 2：中止 3：无效
        public string StartTime;//YYYY-MM-DD HH:mm:SS
        public string IdleReason;
        public string StopReason;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因

        public string LowRev;
        public string HighRev;
        public string AdjustZero;
        ///*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每1s递增1
        //public string DataType;//工况类型：0：低怠速检测中；1：高怠速检测中
        //public string Rev;//发动机转速
        //public string CO;//    
        //public string HC;//
        //public string Lambda;//
    }
    public class RespondSDSResultUpload
    {
        public string name;
        public string result;//1=正常检测  0=外观ID不正确 -1=服务器工作异常
        public string ErrorMessage;
        public string LowIdleCO;
        public string LowIdleHC;
        public string HighIdleCO;
        public string HighIdleHC;
        public string Lambda;
        public string LambdaResult;//0:不合格 1：合格
        public string LowIdleResult;
        public string HighIdleResult;
        public string TestResult;//0:不合格 1：合格 2：中止 3：无效
    }
    public class UploadDieselFAResult
    {
        public string OutlookID;
        public string name = "UploadDieselFAResult";
        public string Temperature;
        public string AirPressure;
        public string Humidity;
        public string SmokeK1;
        public string SmokeK2;
        public string SmokeK3;
        public string Rev1;
        public string Rev2;
        public string Rev3;
        public string SmokeAvg;
        public string IdleRev;



        public string Result;//0:不合格 1：合格 2：中止 3：无效
        public string StartTime;//YYYY-MM-DD HH:mm:SS
        public string StopReason;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string IdleRev;//
        //public string SmokeK;//发动机转速
    }
    public struct UploadSmokemeterCal
    {
        public string StartTime;
        public string Nominal;
        public string Check;
        public string Result;
        public string Nominal2;
        public string Check2;
        public string Result2;

    }
    public struct UploadFlowO2Cal
    {
        public string StartTime;
        public string Nominal;
        public string CheckFlow;
        public string Result;
        public string CheckO2;

    }
    public class Status
    {
        public string EISID;
        public string name = "Status";
        public string EquiStatus;//0=设备空闲  -1=设备故障
    }

    public class RespondCalStandard
    {
        public string COChkAbs;//低气检测CO绝对误
        public string HCChkAbs;//低气检测HC绝对误
        public string NOChkAbs;//低气检测NO绝对误
        public string CO2ChkAbs;//低气检测CO2绝对误
        public string O2ChkAbs;//低气检测O2绝对误
        public string COChkRel;//低气检测CO相对误差
        public string HCChkRel;//低气检测HC相对误差
        public string NOChkRel;//低气检测NO相对误差
        public string CO2ChkRel;//低气检测CO2相对误差
        public string O2ChkRel;//低气检测O2相对误差
        public string COCalAbs;//五气标定CO绝对误差
        public string HCCalAbs;//五气标定HC绝对误差
        public string NOCalAbs;//五气标定NO绝对误差
        public string CO2CalAbs;//五气标定CO2绝对误差
        public string O2CalAbs;//五气标定O2绝对误差
        public string COCalRel;//五气标定CO相对误差
        public string HCCalRel;//五气标定HC相对误差
        public string NOCalRel;//五气标定NO相对误差
        public string CO2CalRel;//五气标定CO2相对误差
        public string O2CalRel;//五气标定O2相对误差
        public string HCT90;//废气仪HC T90响应时间
        public string COT90;
        public string NOT90;
        public string CO2T90;
        public string O2T90;
        public string HCT10;//废气仪HC T10响应时间
        public string COT10;
        public string NOT10;
        public string CO2T10;
        public string O2T10;
        public string Smoke;//烟度计误差
        public string Rev;//转速计误差
        public string Temperature;//温度传感器误
        public string Humidity;//相对湿度误差
        public string AirPressure;//大气压误差
        public string Coastdown;//底盘测功机滑行检查误差（%）
        public string Torque;//底盘测功机扭矩标定（%）
        public string Velocity;//底盘测功机滚筒速度标定误差（km/h）
        public string ParasiticLoss;//底盘测功机内损限值（%）
    }

    public class Coastdown
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "Skidding";
        public string name = "Coastdown";
        public string StartTime;
        public string ACDT40;
        public string ACDT24;
        public string PLHP40;
        public string PLHP24;
        public string CCDT40;
        public string CCDT24;//实测最大轮边功率，修正后的
        public string IHP40;//100%VelMaxHP点的发动机转速（r/min）

        public string IHP24;//0:不合格 1：合格 2：中止 3：无效
        public string DIW;//YYYY-MM-DD HH:mm:SS
        public string Result40;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string Result24;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string Result;
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string Velocity;//工况类型：0：功率扫描中；1：恢复到100%VelMaxHP过程中；2：100%VelMaxHP点检测过程；3：90%VelMaxHP点检测过程 4；80%VelMaxHP点检测过程 80%速度点以后的数据不要
        //public string Torque;//滚筒线速度
        //public string Power;//发动机转速
        //public string Force;//功率
    }
    

    public class ParasiticLose
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "Loss";
        public string name = "ParasiticLose";
        public string StartTime;
        public string EndTime;
        public string ACDT40;
        public string ACDT24;
        public string PLHP40;
        public string PLHP24;
        public string IHP40;
        public string IHP24;
        public string DIW;
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string Velocity;//工况类型：0：功率扫描中；1：恢复到100%VelMaxHP过程中；2：100%VelMaxHP点检测过程；3：90%VelMaxHP点检测过程 4；80%VelMaxHP点检测过程 80%速度点以后的数据不要
        //public string Torque;//滚筒线速度
        //public string Power;//发动机转速
        //public string Force;//功率
    }
    public class TorqueCal
    {
        public string EISID;
        public string name = "TorqueCal";
        public string StartTime;
        public string Nominal;//名义扭矩
        public string Check;//扭矩示值
        public string Result;//0= 不合格 1=合格

    }
    public class SpeedCal
    {
        public string EISID;
        public string name = "SpeedCal";
        public string StartTime;
        public string Nominal;//名义速度
        public string Check;//速度示值
        public string Result;//0= 不合格 1=合格

    }
    public class AnalyzerLeakTest
    {
        public string OutlookID;
        public string StartTime;
        public string Result;//0= 失败 1=成功

    }
    public class AnalyzerTest
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "Analyser";
        public string Type;
        public string BeginTime;
        public string STD_CH;
        public string STD_CO;
        public string STD_CO2;
        public string STD_NO;
        public string STD_O2;
        public string MEA_HC;
        public string MEA_CO;
        public string MEA_CO2;
        public string MEA_NO;
        public string MEA_O2;
        public string PEF;
        public string Result;//0= 失败 1=成功

    }
    public class AnalyzerLowGasTest
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "LowGas";
        public string BeginTime;
        public string STD_CH;
        public string STD_CO;
        public string STD_CO2;
        public string STD_NO;
        public string STD_O2;
        public string MEA_HC;
        public string MEA_CO;
        public string MEA_CO2;
        public string MEA_NO;
        public string MEA_O2;
        public string PEF;
        public string Result;//0= 失败 1=成功

    }
    public class AnalyzerO2Test
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "RangeO2";
        public string BeginTime;
        public string STD_RangeO2;
        public string MEA_RangeO2;
        public string ERR_RangeO2;
        public string Result;
    }
    public class FlowMeterTest
    {
        public string EISID;
        public string OutlookID;
        public string namesy = "Flowmeter";
        public string BeginTime;
        public string STD_HRangeO2;
        public string MEA_HRangeO2;
        public string ERR_HRangeO2;
        public string STD_LRangeO2;
        public string MEA_LRangeO2;
        public string ERR_LRangeO2;
        public string Result;//0= 失败 1=成功

    }
    public class AnalyzerCalCheck
    {
        public string EISID;
        public string name = "AnalyzerCalCheck";
        public string StartTime;
        public string HCTag;
        public string COTag;
        public string CO2Tag;
        public string NOTag;
        public string CheckHCTag;
        public string CheckCOTag;//实测最大轮边功率，修正后的
        public string CheckCO2Tag;//100%VelMaxHP点的发动机转速（r/min）

        public string CheckNOTag;//0:不合格 1：合格 2：中止 3：无效
        public string HCCheckResult;//YYYY-MM-DD HH:mm:SS
        public string COCheckResult;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string CO2CheckResult;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string NOCheckResult;
        public string HCT90;
        public string COT90;
        public string CO2T90;
        public string NOT90;
        public string O2T90;
        public string HCT10;
        public string COT10;
        public string CO2T10;
        public string NOT10;
        public string O2T10;
        public string PEF;
        public string Result;
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string HC;//工况类型：0：功率扫描中；1：恢复到100%VelMaxHP过程中；2：100%VelMaxHP点检测过程；3：90%VelMaxHP点检测过程 4；80%VelMaxHP点检测过程 80%速度点以后的数据不要
        //public string CO;//滚筒线速度
        //public string CO2;//发动机转速
        //public string O2;//功率
        //public string NO;//功率
        //public string PEF;//功率
        //public string STATUS;//状态码 0-通高气 1-量距点标定 2-通环境空气 3-低气检查准备 4-低气检查
    }
    public class AnalyzerFullCal
    {
        public string EISID;
        public string name = "AnalyzerFullCal";
        public string StartTime;
        public string HCTag;
        public string COTag;
        public string CO2Tag;
        public string NOTag;
        public string HCCheckResult;
        public string COCheckResult;//实测最大轮边功率，修正后的
        public string NOCheckResult;//100%VelMaxHP点的发动机转速（r/min）

        public string CheckNOTag;//0:不合格 1：合格 2：中止 3：无效
        //public string HCCheckResult;//YYYY-MM-DD HH:mm:SS
        //public string COCheckResult;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
        public string CO2CheckResult;//引起检测中止或者无效的原因 0=无故障 1=底盘测功机故障 2=底气分析仪故障 3=烟度计故障 4=转速计故障 5=超过允许重检次数 6=气体稀释 7=采样管被堵 8=车辆故障 9=用户主动终止 10=其他设备故障 11=其他原因
                                     // public string NOCheckResult;
        public string HCT90;
        public string COT90;
        public string CO2T90;
        public string NOT90;
        public string O2T90;
        public string HCT10;
        public string COT10;
        public string CO2T10;
        public string NOT10;
        public string O2T10;
        public string PEF;
        public string Result;
        /*********************************ProcessData*******************************/
        //public string TimeCount;//从0开始，每100ms递增1
        //public string HC;//工况类型：0：功率扫描中；1：恢复到100%VelMaxHP过程中；2：100%VelMaxHP点检测过程；3：90%VelMaxHP点检测过程 4；80%VelMaxHP点检测过程 80%速度点以后的数据不要
        //public string CO;//滚筒线速度
        //public string CO2;//发动机转速
        //public string O2;//功率
        //public string NO;//功率
        //public string PEF;//功率
        //public string STATUS;//状态码 0-通高气 1-量距点标定 2-通环境空气 3-低气检查准备 4-低气检查
    }
}
