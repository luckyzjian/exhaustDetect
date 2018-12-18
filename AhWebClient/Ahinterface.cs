using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using ini;
using System.Web;
using SYS_MODEL;
using SYS.Model;
using System.Text.RegularExpressions;

namespace AhWebClient
{
    public class SyncXml
    {
        public struct leadDriver
        {
            public string drivername;
            public string driverID;
        }
        public struct Operator
        {
            public string operatorname;
            public string operatorID;
        }
        public string Time { set; get; }
        public string StationID { set; get; }
        public string LeadDriverCount { set; get; }
        public string OperatorCount { set; get; }
        public string ProtocolVersion { set; get; }
        public string ProtocolDate { set; get; }
        public List<leadDriver> leadDriverlist { set; get; }
        public List<Operator> operatorlist { set; get; }
        public void addLeadDriver(string name,string id)
        {
            leadDriver leaddriver = new leadDriver();
            leaddriver.drivername = name;
            leaddriver.driverID = id;
            this.leadDriverlist.Add(leaddriver);
        }
        public void addOperator(string name, string id)
        {
            Operator leaddriver = new Operator();
            leaddriver.operatorname = name;
            leaddriver.operatorID = id;
            this.operatorlist.Add(leaddriver);
        }
    }
    public class AhCarInfo
    {
        public string InspectID { set; get; }
        public string InspectMethod { set; get; }

        public string PlateID { set; get; }
        public string PlateType { set; get; }
        public string BrandName { set; get; }
        public string ModelName { set; get; }
        public string CarType { set; get; }
        public string IfGoIntoCity { set; get; }
        public string IsTurbo { set; get; }
        public string FuelType { set; get; }
        public string IsClosingEI { set; get; }
        public string Is3WCC { set; get; }
        public string RatedSpeed { set; get; }
        public string DeliveryCapacity { set; get; }
        public string Cylinders { set; get; }
        public string StrokeCycles { set; get; }
        public string NominalPower { set; get; }
        public string FactoryDate { set; get; }
        public string BaseWeight { set; get; }
        public string WholeWeight { set; get; }
        public string RegDate { set; get; }
        public string PassengerCount { set; get; }
        public string GearType { set; get; }
        public string InspectCount { set; get; }
        public string DriveType{ set; get; }
    }

    public class AhCarInfo_V27
    {
        public string InspectID { set; get; }
        public string InspectMethod { set; get; }

        public string VIN { set; get; }
        public string PlateID { set; get; }
        public string PlateType { set; get; }
        public string BrandName { set; get; }
        public string ModelName { set; get; }
        public string EngineModel { set; get; }
        public string EngineSN { set; get; }
        public string CarType { set; get; }
        public string VehicleTypeCode { set; get; }
        public string IfHGL { set; get; }
        public string IfGoIntoCity { set; get; }
        public string IsTurbo { set; get; }
        public string FuelType { set; get; }
        public string FuelSupplyID { set; get; }
        public string Is3WCC { set; get; }
        public string RatedSpeed { set; get; }
        public string DeliveryCapacity { set; get; }
        public string Cylinders { set; get; }
        public string StrokeCycles { set; get; }
        public string NominalPower { set; get; }
        public string FactoryDate { set; get; }
        public string BaseWeight { set; get; }
        public string WholeWeight { set; get; }
        public string RegDate { set; get; }
        public string PassengerCount { set; get; }
        public string GearType { set; get; }
        public string InspectCount { set; get; }
        public string DriveType { set; get; }
        public string EPStage { set; get; }
    }
    public class Ahlimit
    {
        public string HCLimit { set; get; }
        public string COLimit { set; get; }
        public string NOLimit { set; get; }
        public string HC_NOLimit { set; get; }
        public string LowCOLimit { set; get; }
        public string LowCO2Limit { set; get; }
        public string LowHCLimit { set; get; }
        public string HiCOLimit { set; get; }
        public string HiCO2Limit { set; get; }
        public string HiHCLimit { set; get; }
        public string LMDLimitMin { set; get; }
        public string LMDLimitMax { set; get; }
        public string BtgYDLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为YDLimit
        public string HC5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025HCLimit
        public string CO5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025COLimit
        public string NO5025Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为5025NOLimit
        public string HC2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540HCLimit
        public string CO2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540COLimit
        public string NO2540Limit{ set; get; }//跟协议中xml的节点名称不一样，节点中为2540NOLimit
        public string LugdownYDLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为YDLimit
        public string LugdownPowerLimit { set; get; }//跟协议中xml的节点名称不一样，节点中为PowerLimit

    }

    public class AhVmasResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string HC { set; get; }
        public string CO { set; get; }
        public string NO { set; get; }
        public string HC_NO { set; get; }
        public string HCLimit { set; get; }
        public string COLimit { set; get; }
        public string NOLimit { set; get; }
        public string HC_NOLimit { set; get; }
    }
    public class AhSdsResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string CrucialTime2 { set; get; }
        public string LowRPM { set; get; }
        public string LowCO { set; get; }
        public string LowCO2 { set; get; }
        public string LowHC { set; get; }
        public string HiRPM { set; get; }
        public string HiCO { set; get; }
        public string HiCO2 { set; get; }
        public string HiHC { set; get; }
        public string LMD { set; get; }
        public string LowCOLimit { set; get; }
        public string LowHCLimit { set; get; }
        public string HiCOLimit { set; get; }
        public string HiHCLimit { set; get; }
        public string LMDLimitMin { set; get; }
        public string LMDLimitMax { set; get; }
        public string HiCOResult { set; get; }//v2.7
        public string HiHCResult { set; get; }//v2.7
        public string LowCOResult { set; get; }//v2.7
        public string LowHCResult { set; get; }//v2.7
        public string LMDResult { set; get; }//v2.7
    }
    public class AhBtgResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string YD0 { set; get; }
        public string YD1 { set; get; }
        public string YD2 { set; get; }
        public string YD3 { set; get; }
        public string YDAV { set; get; }
        public string YDLimit { set; get; }
        public string IdleSpeed { set; get; }//v2.7
    }
    public class AhAsmResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
        public string CrucialTime2 { set; get; }
        public string HC5025 { set; get; }
        public string CO5025 { set; get; }
        public string NO5025 { set; get; }
        public string HC2540 { set; get; }
        public string CO2540 { set; get; }
        public string NO2540 { set; get; }
        public string HC5025Limit { set; get; }
        public string CO5025Limit { set; get; }
        public string NO5025Limit { set; get; }
        public string HC2540Limit { set; get; }
        public string CO2540Limit { set; get; }
        public string NO2540Limit { set; get; }

        public string HC5025Result { set; get; }//v2.7
        public string CO5025Result { set; get; }//v2.7
        public string NO5025Result { set; get; }//v2.7
        public string HC2540Result { set; get; }//v2.7
        public string CO2540Result { set; get; }//v2.7
        public string NO2540Result { set; get; }//v2.7
    }
    public class AhLugdownResult
    {
        public string Result { set; get; }
        public string CrucialTime0 { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string CrucialTime1 { set; get; }
         public string CrucialTime2 { set; get; }
         public string CrucialTime3 { set; get; }
         public string YD1 { set; get; }
         public string YD2 { set; get; }
         public string YD3 { set; get; }
         public string Power { set; get; }
         public string YDLimit { set; get; }
         public string PowerLimit { set; get; }


        public string RateSpeedUp { set; get; }//v2.7
        public string RateSpeedDown { set; get; }//v2.7
        public string RealRateSpeed { set; get; }//v2.7
        public string YDResult { set; get; }//v2.7
        public string PowerResult { set; get; }//v2.7
    }
    public class selfCheckRecord
    {
        public string AllResult { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
        public string SlideJudge { set; get; }
        public string HSSlideBeginTime { set; get; }
        public string HSSlideEndTime { set; get; }
        public string HSSlideTheoreticalTime { set; get; }
        public string HSSlideActualTime { set; get; }
        public string HSSlideLoadPower { set; get; }
        public string LSSlideBeginTime { set; get; }
        public string LSSlideEndTime { set; get; }
        public string LSSlideTheoreticalTime { set; get; }
        public string LSSlideActualTime { set; get; }
        public string LSSlideLoadPower { set; get; }
        public string WattlessOutputJudge { set; get; }
        public string WattlessOutputMaxSpeed1 { set; get; }
        public string WattlessOutputMinSpeed1 { set; get; }
        public string WattlessOutputNominalSpeed1 { set; get; }
        public string WattlessOutputBeginTime1 { set; get; }
        public string WattlessOutputEndTime1 { set; get; }
        public string WattlessOutput1 { set; get; }
        public string WattlessOutputMaxSpeed2 { set; get; }
        public string WattlessOutputMinSpeed2 { set; get; }
        public string WattlessOutputNominalSpeed2 { set; get; }
        public string WattlessOutputBeginTime2 { set; get; }
        public string WattlessOutputEndTime2 { set; get; }
        public string WattlessOutput2{ set; get; }
        public string WattlessOutputMaxSpeed3 { set; get; }
        public string WattlessOutputMinSpeed3 { set; get; }
        public string WattlessOutputNominalSpeed3 { set; get; }
        public string WattlessOutputBeginTime3 { set; get; }
        public string WattlessOutputEndTime3 { set; get; }
        public string WattlessOutput3{ set; get; }
        public string WattlessOutputMaxSpeed4 { set; get; }
        public string WattlessOutputMinSpeed4{ set; get; }
        public string WattlessOutputNominalSpeed4 { set; get; }
        public string WattlessOutputBeginTime4 { set; get; }
        public string WattlessOutputEndTime4 { set; get; }
        public string WattlessOutput4{ set; get; }
        public string O2MRJudge { get; set; }
        public string O2MRO2 { get; set; }
        public string O2MRFlow { get; set; }
        public string O2MRBeginTime { get; set; }
        public string O2MREndTime { get; set; }
        public string WQJudge { get; set; }
        public string WQTightness { get; set; }
        public string WQResidualHC { get; set; }
        public string WQFlowResult { get; set; }
        public string WQBeginTime { get; set; }
        public string WQEndTime { get; set; }
    }
    public class selfCheckRecord_v27
    {
        public string AllResult { set; get; }
        public string Temperature { set; get; }
        public string Humidity { set; get; }
        public string Baro { set; get; }
    }
    public class ah_selfcheck_public_data
    {
        public string DeviceType { set; get; }// Int 设备类型 1：底盘测功机 2：废气仪 3：烟度计 4：电子环境参数测试仪 5：发动机转速仪 6：流量计
        public string BeginTime { set; get; }// Datetime 开始检测时间
        public string EndTime { set; get; }// Datetime 结束检测时间 
        public string Judge { set; get; }// Int 检查结果（数字，1 表示通过，2 表示未通过） 
        //public string type { set; get; }// <type>1</type>（V2.6.2 新增）
    }
    public class ah_cgj_selfcheckdata
    {
        //public string DeviceType { set; get; }// Int 设备类型 1：底盘测功机 2：废气仪 3：烟度计 4：电子环境参数测试仪 5：发动机转速仪 6：流量计
        //public string BeginTime { set; get; }// Datetime 开始检测时间
        //public string EndTime { set; get; }// Datetime 结束检测时间 
        //public string Judge { set; get; }// Int 检查结果（数字，1 表示通过，2 表示未通过） 
        public string type { set; get; }// <type>1</type>（V2.6.2 新增）
        public string CommCheck { set; get; }// <CommCheck>通讯检查（数字，1 表示成功，2 表示失败） </CommCheck>
        public string LifterCheck { set; get; }// <LifterCheck>举升器检查（数字，1 表示成功，2 表示失败） </LifterCheck>
        public string PreheatBeginTime { set; get; }// <PreheatBeginTime>台体预热开始时间(格式：YYYY-MM-DD        HH:mm:ss)</PreheatBeginTime>
        public string PreheatEndTime { set; get; }// <PreheatEndTime>台体预热结束时间(格式：YYYY-MM-DD        HH:mm:ss)</PreheatEndTime>
        public string InertiaEquivalent { set; get; }// <InertiaEquivalent>基本惯性(单位 KG)</InertiaEquivalent>
        public string SlideBeginTime { set; get; }// <SlideBeginTime> 开始时间是滚筒转速下降到 48km/h 开 始 的 时 间 ， 格 式 为 YYYYMMDD24hmmss</SlideBeginTime>(v2.7 新增) 
        public string QRealSlideTime1 { set; get; }// <QRealSlideTime1>汽油车 48-32km/h 实际滑行时间（数 值，单位 ms）</QRealSlideTime1>(v2.7 新增) 
        public string QRealSlideTime2 { set; get; }//    <QRealSlideTime2>汽油车 32-16km/h 实际滑行时间（数 值，单位 ms）</QRealSlideTime2>(v2.7 新增)
        public string CRealSlideTime1 { set; get; }//     <CRealSlideTime1>柴油车 64-48km/h 实际滑行时间（数 值，单位 ms）</CRealSlideTime1>(v2.7 新增)
        public string CRealSlideTime2 { set; get; }//     <CRealSlideTime2>柴油车 48-32km/h 实际滑行时间（数 值，单位 ms）</CRealSlideTime2>(v2.7 新增) 
        public string Loss1 { set; get; }//     <Loss1>40km/h 时 的 内 损(数 值 ， 单 位 KW)</Loss1>(v2.7 新增) 
        public string Loss2 { set; get; }//     <Loss2>25km/h 时 的 内 损(数 值 ， 单 位 KW)</Loss2>(v2.7 新增) 
        public string NormalSlideTime1 { set; get; }//     <NormalSlideTime1>48-32km/h 名义滑行时间（数值， 单位 ms）</NormalSlideTime1>(v2.7 新增) 
        public string NormalSlideTime2 { set; get; }//     <NormalSlideTime2>32-16km/h 名义滑行时间（数值， 单位 ms）</NormalSlideTime2>(v2.7 新增) 
        public string IndicatedPower1 { set; get; }//     <IndicatedPower1>48-32km/h 滑行指示功率(数值，单 位 KW)</IndicatedPower1>(v2.7 新增) 
        public string IndicatedPower2 { set; get; }//     <IndicatedPower2>32-16km/h 滑行指示功率(数值，单 位 KW)</IndicatedPower2>(v2.7 新增) 
        public string CheckResult1 { set; get; }//     <CheckResult1>48-32km/h 滑行检查结果(数字，1 表 示通过，2 表示未通过)</CheckResult1>(v2.7 新增) 
        public string CheckResult2 { set; get; }//    <CheckResult2>48-32km/h 滑行检查结果(数字，1 表 示通过，2 表示未通过)</CheckResult2>(v2.7 新增) 
    }
    public class ah_cgj_plhp_selfcheckdata
    {
        //public string DeviceType { set; get; }// Int 设备类型 1：底盘测功机 2：废气仪 3：烟度计 4：电子环境参数测试仪 5：发动机转速仪 6：流量计
        //public string BeginTime { set; get; }// Datetime 开始检测时间
        //public string EndTime { set; get; }// Datetime 结束检测时间 
        //public string Judge { set; get; }// Int 检查结果（数字，1 表示通过，2 表示未通过） 
        public string type { set; get; }// <type>1</type>（V2.6.2 新增）
        public string InertiaEquivalent { set; get; }// <CommCheck>通讯检查（数字，1 表示成功，2 表示失败） </CommCheck>
        public string SlideBeginTime { set; get; }// <LifterCheck>举升器检查（数字，1 表示成功，2 表示失败） </LifterCheck>
        public string SlideEndTime { set; get; }// <PreheatBeginTime>台体预热开始时间(格式：YYYY-MM-DD        HH:mm:ss)</PreheatBeginTime>
        public string RealSlideTime1 { set; get; }// <PreheatEndTime>台体预热结束时间(格式：YYYY-MM-DD        HH:mm:ss)</PreheatEndTime>
        public string RealSlideTime2 { set; get; }// <InertiaEquivalent>基本惯性(单位 KG)</InertiaEquivalent>
        public string Loss1 { set; get; }// <SlideBeginTime> 开始时间是滚筒转速下降到 48km/h 开 始 的 时 间 ， 格 式 为 YYYYMMDD24hmmss</SlideBeginTime>(v2.7 新增) 
        public string Loss2 { set; get; }// <QRealSlideTime1>汽油车 48-32km/h 实际滑行时间（数 值，单位 ms）</QRealSlideTime1>(v2.7 新增) 
    }
    public class ah_fxy_selfcheckdata
    {
        //public string DeviceType { set; get; }// Int 设备类型 1：底盘测功机 2：废气仪 3：烟度计 4：电子环境参数测试仪 5：发动机转速仪 6：流量计
        //public string BeginTime { set; get; }// Datetime 开始检测时间
        //public string EndTime { set; get; }// Datetime 结束检测时间 
        //public string Judge { set; get; }// Int 检查结果（数字，1 表示通过，2 表示未通过） 
        public string type { set; get; }// <type>1</type>（V2.6.2 新增）
        public string CheckBeginTime { set; get; }//<CheckBeginTime> 检 查 开 始 时 间 ， 格 式 为 YYYYMMDD24hmmss</CheckBeginTime>（v2.7 新增） 
        public string CommCheck { set; get; }//                                            <CommCheck>通讯检查（数字，1 表示成功，2 表示失败）</CommCheck>
        public string PreheatInstrument { set; get; }//<PreheatInstrument>仪器预热（数字，1 表示成功，2 表示失败）</PreheatInstrument>
        public string Tightness { set; get; }//<Tightness>密封性检查结果（1 表示通过，2 表示未通过）</Tightness>
        public string InstrumentZero { set; get; }//<InstrumentZero>仪器调零（1 表示通过，2 表示未通过）</InstrumentZero>
        public string FlowResult { set; get; }//<FlowResult>低流量检测结果（1 表示通过，2 表示未通过）</FlowResult>
        public string ResidualHC { set; get; }//                                             <ResidualHC>残留 HC 浓度（单位：10-6）</ResidualHC>
        public string ConcentrationType { set; get; }//                                            <ConcentrationType>浓度类型（1-低浓度，2-中低浓度 ， 3- 中 高 浓 度 ， 5- 零 度 ， 6- 五 点 较 准 气 ）</ConcentrationType>（v2.7 新增）
        public string HCNominalValue { set; get; }//<HCNominalValue>HC 标称值</HCNomisnalValue>(v2.7 新增)
        public string HCRealValue { set; get; }//<HCRealValue>HC 实测值</HCRealValue>(v2.7 新增)
        public string HCDeviation { set; get; }//    <HCDeviation>HC 误差(单位：%)</HCDeviation>(v2.7新增)
        public string HCErrorLimit { set; get; }//<HCErrorLimit>误差限值(单位：%)</HCErrorLimit>(v2.7 新增)
        public string HCResult { set; get; }//<HCResult>结果(数字，1 表示通过，2 表示未通过)</HCResult>(v2.7 新增)
        public string CONominalValue { set; get; }//<CONominalValue>CO 标称值</CONominalValue>(v2.7 新增)
        public string CORealValue { set; get; }//<CORealValue>CO 实测值</CORealValue>(v2.7 新增)
        public string CODeviation { set; get; }//<CODeviation>CO 误差(单位：%)</CODeviation>(v2.7新增)
        public string COErrorLimit { set; get; }//<COErrorLimit>误差限值(单位：%)</COErrorLimit>(v2.7 新增)
        public string COResult { set; get; }//<COResult>结果(数字，1 表示通过，2 表示未通过)</COResult>(v2.7 新增)
        public string CO2NominalValue { set; get; }//<CO2NominalValue>CO2 标称值</CO2NominalValue>(v2.7 新增)
        public string CO2RealValue { set; get; }//<CO2RealValue>CO2 实测值</CO2RealValue >
        public string CO2Deviation { set; get; }// <CO2Deviation>CO2 误差(单位：%)</CO2Deviation >(v2.7 新增)
        public string CO2ErrorLimit { set; get; }//<CO2ErrorLimit>误差限值(单位：%)</CO2ErrorLimit>(v2.7 新增)
        public string CO2Result { set; get; }//<CO2Result>结果(数字，1 表示通过，2 表示未通过)</CO2Result>(v2.7 新增)
        public string NONominalValue { set; get; }//<NONominalValue>NO 标称值</NONominalValue>(v2.7 新增)
        public string NORealValue { set; get; }//<NORealValue>NO 实测值</NORealValue>(v2.7 新增)
        public string NODeviation { set; get; }//<NODeviation>NO 误差(单位：%)</NODeviation>(v2.7新增)
        public string NOErrorLimit { set; get; }//<NOErrorLimit>误差限值(单位：%)</NOErrorLimit>(v2.7 新增)
        public string NOResult { set; get; }//<NOResult>结果(数字，1 表示通过，2 表示未通过)</NOResult>(v2.7 新增)
        public string O2NominalValue { set; get; }//<O2NominalValue>O2 标称值</O2NominalValue>(v2.7 新增)
        public string O2RealValue { set; get; }//<O2RealValue>O2 实测值</O2RealValue>(v2.7 新增)
        public string O2Deviation { set; get; }//<O2Deviation>O2 误差(单位：%)</O2Deviation>(v2.7新增)
        public string O2ErrorLimit { set; get; }//<O2ErrorLimit>误差限值(单位：%)</O2ErrorLimit>(v2.7 新增)
        public string O2Result { set; get; }//<O2Result>结果(数字，1 表示通过，2 表示未通过)</O2Result>(v2.7 新增)
        public string PEF { set; get; }//<PEF> PEF 值</PEF> (v2.7 新增)

    }
    public class ah_fxyjc_selfcheckdata
    {
        public string type { set; get; }//<type>2</type>
        public string CheckBeginTime { set; get; }//     <CheckBeginTime> 检 查 开 始 时 间 ， 格 式 为 YYYYMMDD24hmmss</CheckBeginTime>（v2.7 新增） 
        public string ConcentrationType { set; get; }//             <ConcentrationType>浓度类型（1-低浓度，2-中低浓度 ， 3- 中 高 浓 度 ， 5- 零 度 ， 6- 五 点 较 准 气 ）</ConcentrationType>（v2.7 新增）
        public string HCNominalValue { set; get; }//<HCNominalValue>HC 标称值</HCNomisnalValue>
        public string HCRealValue { set; get; }//<HCRealValue>HC 实测值</HCRealValue>
        public string HCDeviation { set; get; }//<HCDeviation>HC 误差(单位：%)</HCDeviation>
        public string HCErrorLimit { set; get; }//<HCErrorLimit>误差限值(单位：%)</HCErrorLimit>
        public string HCResult { set; get; }//<HCResult>结果(数字，1 表示通过，2 表示未通过)</HCResult>
        public string CONominalValue { set; get; }//<CONominalValue>CO 标称值</CONominalValue>
        public string CORealValue { set; get; }//<CORealValue>CO 实测值</CORealValue>
        public string CODeviation { set; get; }//<CODeviation>CO 误差(单位：%)</CODeviation>
        public string COErrorLimit { set; get; }//<COErrorLimit>误差限值(单位：%)</COErrorLimit>
        public string COResult { set; get; }//<COResult>结果(数字，1 表示通过，2 表示未通过)</COResult>
        public string CO2NominalValue { set; get; }//<CO2NominalValue>CO2 标称值</CO2NominalValue>
        public string CO2RealValue { set; get; }//<CO2RealValue>CO2 实测值</CO2RealValue >
        public string CO2Deviation { set; get; }//<CO2Deviation>CO2 误差(单位：%)</CO2Deviation >
        public string CO2ErrorLimit { set; get; }//<CO2ErrorLimit>误差限值(单位：%)</CO2ErrorLimit>
        public string CO2Result { set; get; }//<CO2Result>结果(数字，1 表示通过，2 表示未通过)</CO2Result>
        public string NONominalValue { set; get; }//<NONominalValue>NO 标称值</NONominalValue>
        public string NORealValue { set; get; }//<NORealValue>NO 实测值</NORealValue>
        public string NODeviation { set; get; }//<NODeviation>NO 误差(单位：%)</NODeviation>
        public string NOErrorLimit { set; get; }//<NOErrorLimit>误差限值(单位：%)</NOErrorLimit>
        public string NOResult { set; get; }//<NOResult>结果(数字，1 表示通过，2 表示未通过)</NOResult>
        public string O2NominalValue { set; get; }//<O2NominalValue>O2 标称值</O2NominalValue>
        public string O2RealValue { set; get; }//<O2RealValue>O2 实测值</O2RealValue>
        public string O2Deviation { set; get; }//<O2Deviation>O2 误差(单位：%)</O2Deviation>
        public string O2ErrorLimit { set; get; }//<O2ErrorLimit>误差限值(单位：%)</O2ErrorLimit>
        public string O2Result { set; get; }//<O2Result>结果(数字，1 表示通过，2 表示未通过)</O2Result>(v2.7 新增)
        public string PEF { set; get; }//<PEF> PEF 值</PEF>

    }
    public class ah_fxyo2_selfcheckdata
    {
        public string type { set; get; }//<type>3</type>
        public string NominalValue { set; get; }//    <NominalValue>氧气量程标值(数值)</NominalValue> 
        public string RealValue { set; get; }//    <RealValue>氧气量程测量值(数值)</RealValue> 
        public string Deviation { set; get; }//     <Deviation>氧气量程误差(数值)</Deviation>(v2.7 新 增)

    }
    public class ah_fxyleak_selfcheckdata
    {
        public string type { set; get; }//<type>4</type>
        public string CheckBeginTime { set; get; }//    <CheckBeginTime> 检 查 开 始 时 间 ， 格 式 为 YYYYMMDD24hmmss</CheckBeginTime> 

    }
    public class ah_ydj_selfcheckdata
    {
        public string type { set; get; }//<type>1</type>（V2.6.2 新增）
        public string CommCheck { set; get; }//<CommCheck>通讯检查（数字，1 表示成功，2 表示失败）</CommCheck>
        public string PreheatInstrument { set; get; }//<PreheatInstrument>仪器预热（数字，1 表示成功，2 表示失败）</PreheatInstrument>
        public string InstrumentZero { set; get; }//<InstrumentZero>仪器调零（1 表示通过，2 表示未通过）</InstrumentZero>
        public string RangeCheck { set; get; }//<RangeCheck>量程检查（1 表示通过，2 表示未通过）</RangeCheck>
        public string CheckCount { set; get; }//<CheckCount>检查点数（数字）</CheckCount>
        public string SettingValue1 { set; get; }//<SettingValue1> 不 透 光 设 定 值 1 （ 单 位 ： % ）</SettingValue1>
        public string RealValue1 { set; get; }//<RealValue1>不透光实测值 1（单位：%）</RealValue1>
        public string Deviation1 { set; get; }//<Deviation1>不透光偏差 1</Deviation1>
        public string SettingValue2 { set; get; }//<SettingValue2> 不 透 光 设 定 值 2 （ 单 位 ： % ）</SettingValue2>
        public string RealValue2 { set; get; }//<RealValue2>不透光实测值 2（单位：%）</RealValue2>
        public string Deviation2 { set; get; }//<Deviation2>不透光偏差 2</Deviation2>

    }
    public class ah_dzhj_selfcheckdata
    {
        public string type { set; get; }//<type>1</type>（V2.6.2 新增）
        public string CommCheck { set; get; }//<CommCheck>通讯检查（数字，1 表示成功，2 表示失败）</CommCheck>
        public string EnvTemperature { set; get; }//<EnvTemperature>环境温度（单位：℃）</EnvTemperature>
        public string InstrumentTemperature { set; get; }//<InstrumentTemperature> 仪 器 温 度 （ 单 位 ： ℃ ）</InstrumentTemperature>
        public string EnvHumidity { set; get; }//<EnvHumidity>环境湿度（单位：%）</EnvHumidity>
        public string InstrumentHumidity { set; get; }//<InstrumentHumidity> 仪 器 湿 度 （ 单 位 ： % ）</InstrumentHumidity>
        public string EnvPressure { set; get; }//<EnvPressure>环境气压（单位：kpa）</EnvPressure>
        public string InstrumentPressure { set; get; }//<InstrumentPressure> 仪 器 气 压 （ 单 位 ： kpa ）</InstrumentPressure>

    }
    public class ah_zsj_selfcheckdata
    {
        public string type { set; get; }//<type>1</type>（V2.6.2 新增）
        public string CommCheck { set; get; }//<CommCheck>通讯检查（数字，1 表示成功，2 表示失败）</CommCheck>
        public string IdleSpeed { set; get; }//<IdleSpeed>怠速转速</IdleSpeed> 
    }
    public class ah_endselfcheck
    {
        public string type { set; get; }//AllResult int        是否全项合格。可以是下列值。1: 合格 2: 不是全项合格
        public string tyTemperaturepe { set; get; }//Temperature string 自检时的环境温度(单位为℃)
        public string Humidity { set; get; }//        Humidity string 自检时的环境湿度(%)
        public string Baro { set; get; }//Baro string 自检时的环境气压(kPa)

    }

    public class ah_cal_public_data
    {

        public string Type { set; get; }// Int 设备类型 1：底盘测功机 2：流量计 3：电子环境参数测试仪 4：废气仪标定 5：不透光烟度计标定 6：滤纸式烟度计标定
        public string BeginTime { set; get; }// Datetime 开始检测时间
        public string EndTime { set; get; }// Datetime 结束检测时间 
        public string Judge { set; get; }// Int 检查结果（数字，1 表示通过，2 表示未通过） 
    }
    public class ah_cal_judge_data
    {
        public string type { set; get; }//<type>1</type>
        public string InertiaEquivalent { set; get; }//<InertiaEquivalent>基本惯量(单位：Kg)</InertiaEquivalent>
        public string CalibrateCount { set; get; }//<CalibrateCount>标定点数</CalibrateCount>

    }
    public class ah_jzhx_caldata
    {
        public string FromSpeed { set; get; }// <FromSpeed>速度区间的开始速度（km/h）</FromSpeed>
        public string ToSpeed { set; get; }// <ToSpeed>速度区间的截止速度（km/h）</ToSpeed> 
        public string TheoreticalTime { set; get; }//     <TheoreticalTime>理论滑行时间 1(单位：s) </TheoreticalTime>
        public string ActualTime { set; get; }//     <ActualTime>实际滑行时间 1(单位：s)</ActualTime>
        public string Deviation { set; get; }// <Deviation>误差(单位：%)</Deviation>
        public string ErrorLimit { set; get; }// <ErrorLimit>误差限值(单位：%)</ErrorLimit>
        public string Result { set; get; }// <Result>结果(数字，1 表示通过，2 表示未通过)</Result>

    }
    public class ah_plhp_caldata
    {
        public string FromSpeed { set; get; }//<FromSpeed>速度区间的开始速度（km/h）</FromSpeed>
        public string ToSpeed { set; get; }//<ToSpeed>速度区间的截止速度（km/h）</ToSpeed>
        public string NominalSpeed { set; get; }//<NominalSpeed>名义速度（km/h）</NominalSpeed>
        public string ActualTime { set; get; }//<ActualTime>滑行时间</ActualTime>
        public string WattlessOutput { set; get; }//<WattlessOutput>寄生功率</WattlessOutput>

    }
    public class ah_force_caldata
    {
        public string NominalValue { set; get; }//<NominalValue>标称值</NominalValue>
        public string RealValue { set; get; }//<RealValue>实测值</RealValue>
        public string Deviation { set; get; }//<Deviation>误差(单位：%)</Deviation>
        public string ErrorLimit { set; get; }//<ErrorLimit>误差限值(单位：%)</ErrorLimit>
        public string Result { set; get; }//<Result>结果(数字，1 表示通过，2 表示未通过)</Result>

    }
    public class ah_gl_caldata
    {
        public string NominalValue { set; get; }//<NominalValue>标称值</NominalValue>
        public string FromSpeed { set; get; }//<FromSpeed>速度区间的开始速度（km/h）/</FromSpeed>
        public string ToSpeed { set; get; }//<ToSpeed>速度区间的截止速度（km/h）</ToSpeed>
        public string ForceSettingValue1 { set; get; }//<ForceSettingValue>加载力</ForceSettingValue>
        public string ActualTime1 { set; get; }//<ActualTime>滑行时间</ActualTime>
        public string ForceRealTime1 { set; get; }//<ForceRealTime>实测值</ForceRealTime>
        public string ForceSettingValue2 { set; get; }//<ForceSettingValue>加载力</ForceSettingValue>
        public string ActualTime2 { set; get; }//<ActualTime>滑行时间</ActualTime>
        public string ForceRealTime2 { set; get; }//<ForceRealTime>实测值</ForceRealTime>
        public string RealValue { set; get; }//<RealValue>实测值</RealValue>
        public string Deviation { set; get; }//<Deviation>误差(单位：%)</Deviation>

    }
    public class ah_xysj_caldata
    {
        public string StartSpeed { set; get; }//<StartSpeed>开始滑行速度点（km/h）</StartSpeed>
        public string MaxSpeed { set; get; }//<MaxSpeed>高速点速度（km/h）</MaxSpeed>
        public string MinSpeed { set; get; }//<MinSpeed>低速点速度（km/h）</MinSpeed>
        public string ResponseTime { set; get; }//<ResponseTime>响应时间</ResponseTime>
        public string StabilizationTime { set; get; }//<StabilizationTime>稳定时间</StabilizationTime>

    }
    public class ah_fxy_caldata
    {
        public string ConcentrationType { set; get; }//<ConcentrationType>浓度类型（1-低浓度，2-中低浓度，3-中高浓度，5-零度，6-五点较准气）</ConcentrationType>（v2.7 新增）
        public string HCNominalValue { set; get; }//<HCNominalValue>HC 标称值</HCNominalValue>
        public string HCRealValue { set; get; }//<HCRealValue>HC 实测值</HCRealValue>
        public string HCDeviation { set; get; }//<HCDeviation>HC 误差(单位：%)</HCDeviation>
        public string HCErrorLimit { set; get; }//<HCErrorLimit>误差限值(单位：%)</HCErrorLimit>
        public string HCResult { set; get; }//<HCResult>结果(数字，1 表示通过，2 表示未通过)</HCResult>
        public string CONominalValue { set; get; }//<CONominalValue>CO 标称值</CONominalValue>
        public string CORealValue { set; get; }//<CORealValue>CO 实测值</CORealValue>
        public string CODeviation { set; get; }//<CODeviation>CO 误差(单位：%)</CODeviation>
        public string COErrorLimit { set; get; }//<COErrorLimit>误差限值(单位：%)</COErrorLimit>
        public string COResult { set; get; }//<COResult> 结果(数字，1 表示通过，2 表示未通过)</COResult>
        public string CO2NominalValue { set; get; }//<CO2NominalValue>CO2 标称值</CO2NominalValue>
        public string CO2RealValue { set; get; }//<CO2RealValue>CO2 实测值</CO2RealValue >
        public string CO2Deviation { set; get; }//<CO2Deviation>CO2 误差(单位：%)</CO2Deviation >
        public string CO2ErrorLimit { set; get; }//<CO2ErrorLimit>误差限值(单位：%)</CO2ErrorLimit>
        public string CO2Result { set; get; }//<CO2Result>结果(数字， 1 表示通过， 2 表示未通过)</CO2Result>
        public string NONominalValue { set; get; }//<NONominalValue>NO 标称值</NONominalValue>
        public string NORealValue { set; get; }//<NORealValue>NO 实测值</NORealValue>
        public string NODeviation { set; get; }//<NODeviation>NO 误差(单位：%)</NODeviation>
        public string NOErrorLimit { set; get; }//<NOErrorLimit>误差限值(单位：%)</NOErrorLimit>
        public string NOResult { set; get; }//<NOResult>结果(数字，1 表示通过，2 表示未通过)</NOResult>
        public string O2NominalValue { set; get; }//<O2NominalValue>O2 标 称 值</O2NominalValue>（V2.7 新增）
        public string O2RealValue { set; get; }//<O2RealValue>O2 实测值</O2RealValue>（V2.7 新增）
        public string O2Deviation { set; get; }//<O2Deviation>O2 误差(单位：%)</O2Deviation>（V2.7 新增）
        public string O2ErrorLimit { set; get; }//<O2ErrorLimit> 误 差 限 值(单 位 ： %)</O2ErrorLimit>（V2.7 新增）
        public string O2Result { set; get; }//<O2Result>结果(数字，1 表示通过，2 表示未通过)</O2Result>（V2.7 新增）
        public string PEF { set; get; }//<PEF> PEF 值</PEF> （V2.6.2 新增）

    }
    public class ah_ydj_caldata
    {
        public string NominalValue { set; get; }//<NominalValue>不透光度标称值</NominalValue>
        public string RealValue { set; get; }//<RealValue>不透光度实测值</RealValue>
        public string Deviation { set; get; }//<Deviation> 不透光度误差(单位：%)</Deviation>
        public string ErrorLimit { set; get; }//<ErrorLimit>误差限值(单位：%)</ErrorLimit>
        public string Result { set; get; }//<Result>结果(数字，1 表示通过，2 表示未通过)</Result>

    }
    public class ah_dzhj_caldata
    {
        public string TemperatureNominalValue { set; get; }//<TemperatureNominalValue> 温 度 标 称 值(单位：℃)</TemperatureNominalValue>
        public string TemperatureRealValue { set; get; }//<TemperatureRealValue>温度实测值(单位：℃)</TemperatureRealValue>
        public string TemperatureResult { set; get; }//<TemperatureResult>温度结果(数字，1 表示通过，2 表示未通过)</TemperatureResult>
        public string HumidityNominalValue { set; get; }//<HumidityNominalValue>湿度标称值(单位：%)</HumidityNominalValue>
        public string HumidityRealValue { set; get; }//<HumidityRealValue>湿度实测值(单位：%)</HumidityRealValue>
        public string HumidityResult { set; get; }//<HumidityResult>湿度结果(数字，1 表示通过，2表示未通过)</HumidityResult>
        public string BaroNominalValue { set; get; }//<BaroNominalValue>大气压标称值(单位：kPa)</BaroNominalValue>
        public string BaroRealValue { set; get; }//<BaroRealValue>大气压实测值(单位：kPa)</BaroRealValue>
        public string BaroResult { set; get; }//<BaroResult>大气压结果(数字，1 表示通过，2表示未通过)</BaroResult>

    }
    public class Ahinterface
    {
        Service outlineservice = null;
        public Dictionary<string, string> AHLINEID = new Dictionary<string, string>();
        const string version_V23 = "v2.3";
        const string version_V27 = "v2.7";
        private string version = "v2.3";
        public Ahinterface(string url,string version)
        {
            this.version = version;
            outlineservice = new Service(url);
        }
        public void initLineId(string lineid)
        {
            string[] lineidary = lineid.Split(',');
            for(int i=1;i<=lineidary.Count();i++)
            {
                AHLINEID.Add(i.ToString("00"), lineidary[i-1]);
            }
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static string ConvertXmlToString(XmlDocument xmlDoc)
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"UTF-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            //string newstring = xmlString.Replace("<xml version=\"1.0\">", "");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }
        public bool Sync(out int result,out string errMsg,out SyncXml syncxml,out List<string> urllist,out List<string> Messagelist)
        {
            result = 0;
            errMsg = "";
            syncxml = new SyncXml();
            urllist = new List<string>();
            Messagelist = new List<string>();
            try
            {
                RetValue retvalue = outlineservice.Sync("");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("Sync\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    noticeString = "<body>" + noticeString + "</body>";
                    if (noticeString != "")
                    {

                        ds = XmlToData.CXmlToDataSet(noticeString);
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            DataTable dt = ds.Tables[i];
                            urllist.Add(dt.Rows[0]["URL"].ToString());
                            Messagelist.Add(dt.Rows[0]["Message"].ToString());
                        }
                    }
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    //DataTable valuedt = ds.Tables["body"];
                    syncxml.Time = ds.Tables["body"].Rows[0]["Time"].ToString();
                    syncxml.StationID = ds.Tables["body"].Rows[0]["StationID"].ToString();
                    syncxml.ProtocolVersion = ds.Tables["body"].Rows[0]["ProtocolVersion"].ToString();
                    syncxml.ProtocolDate = ds.Tables["body"].Rows[0]["ProtocolDate"].ToString();
                    syncxml.LeadDriverCount = ds.Tables["LeadDriver"].Rows[0]["Count"].ToString();
                    syncxml.OperatorCount = ds.Tables["Operator"].Rows[0]["Count"].ToString();
                    syncxml.leadDriverlist = new List<SyncXml.leadDriver>();
                    syncxml.operatorlist = new List<SyncXml.Operator>();
                    if (int.Parse(syncxml.LeadDriverCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.LeadDriverCount); i++)
                        {
                            if (ds.Tables.Contains("Driver" + i.ToString()))
                            {
                                syncxml.addLeadDriver(ds.Tables["Driver" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Driver" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    if (int.Parse(syncxml.OperatorCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.OperatorCount); i++)
                        {
                            if (ds.Tables.Contains("Operator" + i.ToString()))
                            {
                                syncxml.addOperator(ds.Tables["Operator" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Operator" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        /*
        public bool getInSpectQueueByDate(DateTime starttime,DateTime endtime,out int result, out string errMsg, out List<AhCarInfo> ahcarinflist, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByDate(starttime.ToString("yyyy-MM-dd HH:mm:ss"), endtime.ToString("yyyy-MM-dd HH:mm:ss"), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByDate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo carinfo = new AhCarInfo();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                if (ds.Tables["CarInfo"].Columns.Contains("NominalPower"))
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                else
                                    carinfo.NominalPower = "60";
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLLX = "载客"; break;
                                    case "2": model.CLLX = "载货或特殊用途车"; break;
                                    case "3": model.CLLX = "低速货车"; break;
                                    case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                    case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                    default:
                                        model.CLLX = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = "";
                                model.XH = "";
                                model.CLSBM = "";
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = "";

                                model.FDJXH = "";
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = "";

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";


                                model.CSYS = "";
                                model.ZXBZ = "";

                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = "1";
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByPlate(string  palteID, int plateType, out int result, out string errMsg, out List<AhCarInfo> ahcarinflist,out List<CARATWAIT> caratwaitlist,out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByPlateID(palteID, plateType, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByPlateID\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo carinfo = new AhCarInfo();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLLX = "载客"; break;
                                    case "2": model.CLLX = "载货或特殊用途车"; break;
                                    case "3": model.CLLX = "低速货车"; break;
                                    case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                    case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                    default:
                                        model.CLLX = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = "";
                                model.XH = "";
                                model.CLSBM = "";
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = "";

                                model.FDJXH = "";
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = "";

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";



                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = "1";
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }*/
        public bool getInSpectQueueByDate(DateTime starttime, DateTime endtime, out int result, out string errMsg, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByDate(starttime.ToString("yyyy-MM-dd HH:mm:ss"), endtime.ToString("yyyy-MM-dd HH:mm:ss"), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByDate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                if (version == version_V23)
                                {
                                    AhCarInfo carinfo = new AhCarInfo();
                                    carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                    carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                    carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                    carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                    carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                    carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                    carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                    carinfo.IfGoIntoCity = "";
                                    carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                    carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                    carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                    carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                    carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                    carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                    carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                    carinfo.StrokeCycles = "";
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                    carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                    carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                    carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                    carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                    carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                    carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                    carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                    carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                    CARINF model = new CARINF();
                                    CARATWAIT waitmodel = new CARATWAIT();
                                    model.CLHP = carinfo.PlateID;
                                    model.HPZL = carinfo.PlateType;
                                    model.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.CarType)
                                    {
                                        case "1": model.CLLX = "载客"; break;
                                        case "2": model.CLLX = "载货或特殊用途车"; break;
                                        case "3": model.CLLX = "低速货车"; break;
                                        case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                        case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                        default:
                                            model.CLLX = ""; break;
                                    }
                                    model.CZ = "";
                                    model.SYXZ = "";
                                    model.PP = "";
                                    model.XH = "";
                                    model.CLSBM = "";
                                    //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                    model.FDJHM = "";

                                    model.FDJXH = "";
                                    model.SCQY = "";
                                    model.HDZK = carinfo.PassengerCount;

                                    model.JSSZK = "0";
                                    model.ZZL = carinfo.WholeWeight;
                                    model.HDZZL = "0";
                                    model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                    model.JZZL = carinfo.BaseWeight;
                                    model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                    model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                    model.FDJPL = carinfo.DeliveryCapacity;
                                    model.RLZL = "";
                                    switch (carinfo.FuelType)
                                    {
                                        case "1": model.RLZL = "汽油"; break;
                                        case "2": model.RLZL = "柴油"; break;
                                        case "3": model.RLZL = "天燃气"; break;
                                        case "4": model.RLZL = "液化石油气"; break;
                                        case "5": model.RLZL = "甲醇"; break;
                                        case "6": model.RLZL = "乙醇"; break;
                                        default: break;
                                    }
                                    model.EDGL = carinfo.NominalPower;
                                    model.EDZS = carinfo.RatedSpeed;
                                    model.BSQXS = "";
                                    switch (carinfo.GearType)
                                    {
                                        case "1": model.BSQXS = "手动档"; break;
                                        case "2": model.BSQXS = "自动档"; break;
                                        case "3": model.BSQXS = "手自一体"; break;
                                        default: break;
                                    }
                                    model.DWS = "5";
                                    //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                    model.GYFS = "";
                                    model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                    model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                    model.QGS = "";

                                    model.QDXS = "";
                                    switch (carinfo.DriveType)
                                    {
                                        case "1": model.QDXS = "前驱"; break;
                                        case "2": model.QDXS = "后驱"; break;
                                        case "3": model.QDXS = "分时四驱"; break;
                                        case "4": model.QDXS = "全时四驱"; break;
                                        default: break;
                                    }
                                    model.CHZZ = "";
                                    model.DLSP = "";
                                    model.SFSRL = "";
                                    model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                    model.OBD = "";
                                    model.DKGYYB = "";
                                    model.LXDH = "";
                                    model.CLZL = "";
                                    model.CZDZ = "";

                                    model.JCFS = "";
                                    model.JCLB = "";
                                    model.SSXQ = "";
                                    model.FDJSCQY = "";
                                    model.QDLTQY = "";
                                    model.RYPH = "";
                                    model.SFWDZR = "";
                                    model.SFYQBF = "";



                                    waitmodel.CLID = carinfo.InspectID;
                                    waitmodel.CLHP = carinfo.PlateID;
                                    waitmodel.DLSJ = DateTime.Now;
                                    waitmodel.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.InspectMethod)
                                    {
                                        case "4":
                                            waitmodel.JCFF = "ASM";
                                            break;
                                        case "1":
                                            waitmodel.JCFF = "VMAS";
                                            break;
                                        case "5":
                                            waitmodel.JCFF = "JZJS";
                                            break;
                                        case "3":
                                            waitmodel.JCFF = "ZYJS";
                                            break;
                                        case "2":
                                            waitmodel.JCFF = "SDS";
                                            break;
                                        default: waitmodel.JCFF = ""; break;
                                    }
                                    waitmodel.XSLC = "";
                                    waitmodel.JCCS = "1";
                                    waitmodel.CZY = "";
                                    waitmodel.JSY = "";
                                    waitmodel.DLY = "";
                                    waitmodel.JCFY = "";
                                    waitmodel.TEST = "";
                                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                    waitmodel.JCBGBH = "";
                                    waitmodel.JCGWH = "";
                                    waitmodel.JCZBH = "";
                                    waitmodel.JCRQ = DateTime.Now;
                                    waitmodel.BGJCFFYY = "";
                                    waitmodel.SFCS = "";
                                    waitmodel.ECRYPT = "";
                                    waitmodel.SFCJ = "初检";
                                    waitmodel.JYLSH = "";
                                    waitmodel.HPZL = carinfo.PlateType;
                                    carinflist.Add(model);
                                    caratwaitlist.Add(waitmodel);
                                }
                                else if (version == version_V27)
                                {
                                    AhCarInfo_V27 carinfo = new AhCarInfo_V27();
                                    carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                    carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                    carinfo.InspectCount = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectCount"].ToString();//太湖用的
                                    //carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();//定远用的
                                    carinfo.VIN = ds.Tables["CarInfo"].Rows[i - 1]["VIN"].ToString();
                                    carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                    carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                    carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                    carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                    carinfo.EngineModel = ds.Tables["CarInfo"].Rows[i - 1]["EngineModel"].ToString();
                                    carinfo.EngineSN = ds.Tables["CarInfo"].Rows[i - 1]["EngineSN"].ToString();
                                    carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                    carinfo.VehicleTypeCode = ds.Tables["CarInfo"].Rows[i - 1]["VehicleTypeCode"].ToString();
                                    carinfo.IfHGL = ds.Tables["CarInfo"].Rows[i - 1]["IfHGL"].ToString();
                                    carinfo.IfGoIntoCity = "";
                                    carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                    carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                    carinfo.FuelSupplyID = ds.Tables["CarInfo"].Rows[i - 1]["FuelSupplyID"].ToString();
                                    carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                    carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                    carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                    carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                    carinfo.StrokeCycles = "";
                                    if (ds.Tables["CarInfo"].Columns.Contains("NorminalPower"))
                                        carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NorminalPower"].ToString();
                                    else
                                        carinfo.NominalPower = "60";
                                    carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                    carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                    carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                    carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                    carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                    carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                    carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                    carinfo.EPStage = ds.Tables["CarInfo"].Rows[i - 1]["EPStage"].ToString();
                                    //carinfo.EPStage = "";
                                    CARINF model = new CARINF();
                                    CARATWAIT waitmodel = new CARATWAIT();
                                    model.CLHP = carinfo.PlateID;
                                    model.HPZL = carinfo.PlateType;
                                    model.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    model.CLLX = carinfo.VehicleTypeCode;
                                    switch (carinfo.CarType)
                                    {
                                        case "1": model.CLZL = "常规载客"; break;
                                        case "2": model.CLZL = "常规载货"; break;
                                        case "3": model.CLZL = "低速货车"; break;
                                        case "4": model.CLZL = "三轮汽车"; break;
                                        case "5": model.CLZL = "专项作业车"; break;
                                        case "6": model.CLZL = "三轮摩托车"; break;
                                        case "7": model.CLZL = "二轮摩托车"; break;
                                        case "8": model.CLZL = "校车"; break;
                                        case "9": model.CLZL = "其他"; break;
                                        default:
                                            model.CLZL = ""; break;
                                    }
                                    model.CZ = "";
                                    model.SYXZ = "";
                                    model.PP = carinfo.BrandName;
                                    model.XH = carinfo.ModelName;
                                    model.CLSBM = carinfo.VIN;
                                    //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                    model.FDJHM = carinfo.EngineSN;

                                    model.FDJXH = carinfo.EngineModel;
                                    model.SCQY = "";
                                    model.HDZK = carinfo.PassengerCount;

                                    model.JSSZK = "0";
                                    model.ZZL = carinfo.WholeWeight;
                                    model.HDZZL = "0";
                                    model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                    model.JZZL = carinfo.BaseWeight;
                                    model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                    model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                    model.FDJPL = carinfo.DeliveryCapacity;
                                    model.RLZL = "";
                                    switch (carinfo.FuelType)
                                    {
                                        case "1": model.RLZL = "汽油"; break;
                                        case "2": model.RLZL = "柴油"; break;
                                        case "3": model.RLZL = "天燃气"; break;
                                        case "4": model.RLZL = "液化石油气"; break;
                                        case "5": model.RLZL = "甲醇"; break;
                                        case "6": model.RLZL = "乙醇"; break;
                                        default: break;
                                    }
                                    model.EDGL = carinfo.NominalPower;
                                    model.EDZS = carinfo.RatedSpeed;
                                    model.BSQXS = "";
                                    switch (carinfo.GearType)
                                    {
                                        case "1": model.BSQXS = "手动档"; break;
                                        case "2": model.BSQXS = "自动档"; break;
                                        case "3": model.BSQXS = "手自一体"; break;
                                        default: break;
                                    }
                                    model.DWS = "5";
                                    //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                    model.GYFS = "";
                                    switch (carinfo.FuelSupplyID)
                                    {
                                        case "1": model.GYFS = "闭环电喷"; break;
                                        case "2": model.GYFS = "开环电喷"; break;
                                        case "3": model.GYFS = "化油器"; break;
                                        case "4": model.GYFS = "化油器改造"; break;
                                        case "5": model.GYFS = "高压共轨"; break;
                                        case "7": model.GYFS = "泵喷嘴"; break;
                                        case "8": model.GYFS = "单体泵"; break;
                                        case "9": model.GYFS = "直列泵"; break;
                                        case "10": model.GYFS = "机械泵"; break;
                                        case "11": model.GYFS = "其他"; break;
                                        default: break;
                                    }
                                    model.DPFS = (model.GYFS == "闭环电喷" ? "闭环电喷" : "开环电喷");

                                    model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                    model.QGS = carinfo.Cylinders;

                                    model.QDXS = "";
                                    switch (carinfo.DriveType)
                                    {
                                        case "1": model.QDXS = "前驱"; break;
                                        case "2": model.QDXS = "后驱"; break;
                                        case "3": model.QDXS = "分时四驱"; break;
                                        case "4": model.QDXS = "全时四驱"; break;
                                        default: break;
                                    }
                                    model.CHZZ = "";
                                    model.DLSP = "";
                                    model.SFSRL = "";
                                    model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                    model.OBD = "";
                                    model.DKGYYB = "";
                                    model.LXDH = "";
                                    //model.CLZL = "";
                                    model.CZDZ = "";

                                    model.JCFS = "";
                                    model.JCLB = "";
                                    model.SSXQ = "";
                                    model.FDJSCQY = "";
                                    model.QDLTQY = "";
                                    model.RYPH = "";
                                    model.SFWDZR = "";
                                    model.SFYQBF = "";


                                    model.CSYS = "";
                                    model.ZXBZ = "";
                                    switch (carinfo.EPStage)
                                    {
                                        case "1": model.ZXBZ = "国I"; break;
                                        case "2": model.ZXBZ = "国II"; break;
                                        case "3": model.ZXBZ = "国III"; break;
                                        case "4": model.ZXBZ = "国IV"; break;
                                        case "5": model.ZXBZ = "国V"; break;
                                        case "6": model.ZXBZ = "国VI"; break;
                                        case "7": model.ZXBZ = "国VII"; break;
                                        case "0": model.ZXBZ = "国0"; break;
                                        default: break;
                                    }
                                    waitmodel.CLID = carinfo.InspectID;
                                    waitmodel.CLHP = carinfo.PlateID;
                                    waitmodel.DLSJ = DateTime.Now;
                                    waitmodel.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.InspectMethod)
                                    {
                                        case "4":
                                            waitmodel.JCFF = "ZYJS";
                                            break;
                                        case "1":
                                            waitmodel.JCFF = "VMAS";
                                            break;
                                        case "5":
                                            waitmodel.JCFF = "JZJS";
                                            break;
                                        case "3":
                                            waitmodel.JCFF = "LZ";
                                            break;
                                        case "2":
                                            waitmodel.JCFF = "SDS";
                                            break;
                                        case "6":
                                            waitmodel.JCFF = "ASM";
                                            break;
                                        default: waitmodel.JCFF = ""; break;
                                    }
                                    waitmodel.XSLC = "";
                                    waitmodel.JCCS = carinfo.InspectCount;
                                    waitmodel.CZY = "";
                                    waitmodel.JSY = "";
                                    waitmodel.DLY = "";
                                    waitmodel.JCFY = "";
                                    waitmodel.TEST = "";
                                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                    waitmodel.JCBGBH = "";
                                    waitmodel.JCGWH = "";
                                    waitmodel.JCZBH = "";
                                    waitmodel.JCRQ = DateTime.Now;
                                    waitmodel.BGJCFFYY = "";
                                    waitmodel.SFCS = "";
                                    waitmodel.ECRYPT = "";
                                    waitmodel.SFCJ = "初检";
                                    waitmodel.JYLSH = "";
                                    waitmodel.HPZL = carinfo.PlateType;
                                    carinflist.Add(model);
                                    caratwaitlist.Add(waitmodel);
                                }
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByPlate(string palteID, int plateType, out int result, out string errMsg, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByPlateID(palteID, plateType, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByPlateID\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                if (version == version_V23)
                                {
                                    AhCarInfo carinfo = new AhCarInfo();
                                    carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                    carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                    carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                    carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                    carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                    carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                    carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                    carinfo.IfGoIntoCity = "";
                                    carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                    carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                    carinfo.IsClosingEI = ds.Tables["CarInfo"].Rows[i - 1]["IsClosingEI"].ToString();
                                    carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                    carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                    carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                    carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                    carinfo.StrokeCycles = "";
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                    carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                    carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                    carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                    carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                    carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                    carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                    carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                    carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                    CARINF model = new CARINF();
                                    CARATWAIT waitmodel = new CARATWAIT();
                                    model.CLHP = carinfo.PlateID;
                                    model.HPZL = carinfo.PlateType;
                                    model.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.CarType)
                                    {
                                        case "1": model.CLLX = "载客"; break;
                                        case "2": model.CLLX = "载货或特殊用途车"; break;
                                        case "3": model.CLLX = "低速货车"; break;
                                        case "4": model.CLLX = "二轮摩托或二轮轻便摩托"; break;
                                        case "5": model.CLLX = "三轮摩托或三轮轻便摩托"; break;
                                        default:
                                            model.CLLX = ""; break;
                                    }
                                    model.CZ = "";
                                    model.SYXZ = "";
                                    model.PP = "";
                                    model.XH = "";
                                    model.CLSBM = "";
                                    //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                    model.FDJHM = "";

                                    model.FDJXH = "";
                                    model.SCQY = "";
                                    model.HDZK = carinfo.PassengerCount;

                                    model.JSSZK = "0";
                                    model.ZZL = carinfo.WholeWeight;
                                    model.HDZZL = "0";
                                    model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                    model.JZZL = carinfo.BaseWeight;
                                    model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                    model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                    model.FDJPL = carinfo.DeliveryCapacity;
                                    model.RLZL = "";
                                    switch (carinfo.FuelType)
                                    {
                                        case "1": model.RLZL = "汽油"; break;
                                        case "2": model.RLZL = "柴油"; break;
                                        case "3": model.RLZL = "天燃气"; break;
                                        case "4": model.RLZL = "液化石油气"; break;
                                        case "5": model.RLZL = "甲醇"; break;
                                        case "6": model.RLZL = "乙醇"; break;
                                        default: break;
                                    }
                                    model.EDGL = carinfo.NominalPower;
                                    model.EDZS = carinfo.RatedSpeed;
                                    model.BSQXS = "";
                                    switch (carinfo.GearType)
                                    {
                                        case "1": model.BSQXS = "手动档"; break;
                                        case "2": model.BSQXS = "自动档"; break;
                                        case "3": model.BSQXS = "手自一体"; break;
                                        default: break;
                                    }
                                    model.DWS = "5";
                                    //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                    model.GYFS = "";
                                    model.DPFS = (carinfo.IsClosingEI == "true" ? "闭环电喷" : "开环电喷");

                                    model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                    model.QGS = "";

                                    model.QDXS = "";
                                    switch (carinfo.DriveType)
                                    {
                                        case "1": model.QDXS = "前驱"; break;
                                        case "2": model.QDXS = "后驱"; break;
                                        case "3": model.QDXS = "分时四驱"; break;
                                        case "4": model.QDXS = "全时四驱"; break;
                                        default: break;
                                    }
                                    model.CHZZ = "";
                                    model.DLSP = "";
                                    model.SFSRL = "";
                                    model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                    model.OBD = "";
                                    model.DKGYYB = "";
                                    model.LXDH = "";
                                    model.CLZL = "";
                                    model.CZDZ = "";

                                    model.JCFS = "";
                                    model.JCLB = "";
                                    model.SSXQ = "";
                                    model.FDJSCQY = "";
                                    model.QDLTQY = "";
                                    model.RYPH = "";
                                    model.SFWDZR = "";
                                    model.SFYQBF = "";



                                    waitmodel.CLID = carinfo.InspectID;
                                    waitmodel.CLHP = carinfo.PlateID;
                                    waitmodel.DLSJ = DateTime.Now;
                                    waitmodel.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.InspectMethod)
                                    {
                                        case "4":
                                            waitmodel.JCFF = "ASM";
                                            break;
                                        case "1":
                                            waitmodel.JCFF = "VMAS";
                                            break;
                                        case "5":
                                            waitmodel.JCFF = "JZJS";
                                            break;
                                        case "3":
                                            waitmodel.JCFF = "ZYJS";
                                            break;
                                        case "2":
                                            waitmodel.JCFF = "SDS";
                                            break;
                                        default: waitmodel.JCFF = ""; break;
                                    }
                                    waitmodel.XSLC = "";
                                    waitmodel.JCCS = "1";
                                    waitmodel.CZY = "";
                                    waitmodel.JSY = "";
                                    waitmodel.DLY = "";
                                    waitmodel.JCFY = "";
                                    waitmodel.TEST = "";
                                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                    waitmodel.JCBGBH = "";
                                    waitmodel.JCGWH = "";
                                    waitmodel.JCZBH = "";
                                    waitmodel.JCRQ = DateTime.Now;
                                    waitmodel.BGJCFFYY = "";
                                    waitmodel.SFCS = "";
                                    waitmodel.ECRYPT = "";
                                    waitmodel.SFCJ = "初检";
                                    waitmodel.JYLSH = "";
                                    waitmodel.HPZL = carinfo.PlateType;
                                    carinflist.Add(model);
                                    caratwaitlist.Add(waitmodel);
                                }
                                else if (version == version_V27)
                                {
                                    AhCarInfo_V27 carinfo = new AhCarInfo_V27();
                                    carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                    carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                    carinfo.InspectCount = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectCount"].ToString();//太湖用的
                                    //carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();//定远用的
                                    carinfo.VIN = ds.Tables["CarInfo"].Rows[i - 1]["VIN"].ToString();
                                    carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                    carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                    carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                    carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                    carinfo.EngineModel = ds.Tables["CarInfo"].Rows[i - 1]["EngineModel"].ToString();
                                    carinfo.EngineSN = ds.Tables["CarInfo"].Rows[i - 1]["EngineSN"].ToString();
                                    carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                    carinfo.VehicleTypeCode = ds.Tables["CarInfo"].Rows[i - 1]["VehicleTypeCode"].ToString();
                                    carinfo.IfHGL = ds.Tables["CarInfo"].Rows[i - 1]["IfHGL"].ToString();
                                    carinfo.IfGoIntoCity = "";
                                    carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                    carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                    carinfo.FuelSupplyID = ds.Tables["CarInfo"].Rows[i - 1]["FuelSupplyID"].ToString();
                                    carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                    carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                    carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                    carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                    carinfo.StrokeCycles = "";
                                    if (ds.Tables["CarInfo"].Columns.Contains("NorminalPower"))
                                        carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NorminalPower"].ToString();
                                    else
                                        carinfo.NominalPower = "60";
                                    carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                    carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                    carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                    carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                    carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                    carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                    //carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                    carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                    carinfo.EPStage = ds.Tables["CarInfo"].Rows[i - 1]["EPStage"].ToString();

                                    //carinfo.EPStage = "";
                                    CARINF model = new CARINF();
                                    CARATWAIT waitmodel = new CARATWAIT();
                                    model.CLHP = carinfo.PlateID;
                                    model.HPZL = carinfo.PlateType;
                                    model.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    model.CLLX = carinfo.VehicleTypeCode;
                                    switch (carinfo.CarType)
                                    {
                                        case "1": model.CLZL = "常规载客"; break;
                                        case "2": model.CLZL = "常规载货"; break;
                                        case "3": model.CLZL = "低速货车"; break;
                                        case "4": model.CLZL = "三轮汽车"; break;
                                        case "5": model.CLZL = "专项作业车"; break;
                                        case "6": model.CLZL = "三轮摩托车"; break;
                                        case "7": model.CLZL = "二轮摩托车"; break;
                                        case "8": model.CLZL = "校车"; break;
                                        case "9": model.CLZL = "其他"; break;
                                        default:
                                            model.CLZL = ""; break;
                                    }
                                    model.CZ = "";
                                    model.SYXZ = "";
                                    model.PP = carinfo.BrandName;
                                    model.XH = carinfo.ModelName;
                                    model.CLSBM = carinfo.VIN;
                                    //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                    model.FDJHM = carinfo.EngineSN;

                                    model.FDJXH = carinfo.EngineModel;
                                    model.SCQY = "";
                                    model.HDZK = carinfo.PassengerCount;

                                    model.JSSZK = "0";
                                    model.ZZL = carinfo.WholeWeight;
                                    model.HDZZL = "0";
                                    model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                    model.JZZL = carinfo.BaseWeight;
                                    model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                    model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                    model.FDJPL = carinfo.DeliveryCapacity;
                                    model.RLZL = "";
                                    switch (carinfo.FuelType)
                                    {
                                        case "1": model.RLZL = "汽油"; break;
                                        case "2": model.RLZL = "柴油"; break;
                                        case "3": model.RLZL = "天燃气"; break;
                                        case "4": model.RLZL = "液化石油气"; break;
                                        case "5": model.RLZL = "甲醇"; break;
                                        case "6": model.RLZL = "乙醇"; break;
                                        default: break;
                                    }
                                    model.EDGL = carinfo.NominalPower;
                                    model.EDZS = carinfo.RatedSpeed;
                                    model.BSQXS = "";
                                    switch (carinfo.GearType)
                                    {
                                        case "1": model.BSQXS = "手动档"; break;
                                        case "2": model.BSQXS = "自动档"; break;
                                        case "3": model.BSQXS = "手自一体"; break;
                                        default: break;
                                    }
                                    model.DWS = "5";
                                    //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                    model.GYFS = "";
                                    switch (carinfo.FuelSupplyID)
                                    {
                                        case "1": model.GYFS = "闭环电喷"; break;
                                        case "2": model.GYFS = "开环电喷"; break;
                                        case "3": model.GYFS = "化油器"; break;
                                        case "4": model.GYFS = "化油器改造"; break;
                                        case "5": model.GYFS = "高压共轨"; break;
                                        case "7": model.GYFS = "泵喷嘴"; break;
                                        case "8": model.GYFS = "单体泵"; break;
                                        case "9": model.GYFS = "直列泵"; break;
                                        case "10": model.GYFS = "机械泵"; break;
                                        case "11": model.GYFS = "其他"; break;
                                        default: break;
                                    }
                                    model.DPFS = (model.GYFS == "闭环电喷" ? "闭环电喷" : "开环电喷");

                                    model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                    model.QGS = carinfo.Cylinders;

                                    model.QDXS = "";
                                    switch (carinfo.DriveType)
                                    {
                                        case "1": model.QDXS = "前驱"; break;
                                        case "2": model.QDXS = "后驱"; break;
                                        case "3": model.QDXS = "分时四驱"; break;
                                        case "4": model.QDXS = "全时四驱"; break;
                                        default: break;
                                    }
                                    model.CHZZ = "";
                                    model.DLSP = "";
                                    model.SFSRL = "";
                                    model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                    model.OBD = "";
                                    model.DKGYYB = "";
                                    model.LXDH = "";
                                    //model.CLZL = "";
                                    model.CZDZ = "";

                                    model.JCFS = "";
                                    model.JCLB = "";
                                    model.SSXQ = "";
                                    model.FDJSCQY = "";
                                    model.QDLTQY = "";
                                    model.RYPH = "";
                                    model.SFWDZR = "";
                                    model.SFYQBF = "";


                                    model.CSYS = "";
                                    model.ZXBZ = "";
                                    switch (carinfo.EPStage)
                                    {
                                        case "1": model.ZXBZ = "国I"; break;
                                        case "2": model.ZXBZ = "国II"; break;
                                        case "3": model.ZXBZ = "国III"; break;
                                        case "4": model.ZXBZ = "国IV"; break;
                                        case "5": model.ZXBZ = "国V"; break;
                                        case "6": model.ZXBZ = "国VI"; break;
                                        case "7": model.ZXBZ = "国VII"; break;
                                        case "0": model.ZXBZ = "国0"; break;
                                        default: break;
                                    }
                                    waitmodel.CLID = carinfo.InspectID;
                                    waitmodel.CLHP = carinfo.PlateID;
                                    waitmodel.DLSJ = DateTime.Now;
                                    waitmodel.CPYS = "";
                                    switch (carinfo.PlateType)
                                    {
                                        case "1": model.CPYS = "蓝牌"; break;
                                        case "2": model.CPYS = "黄牌"; break;
                                        case "3": model.CPYS = "白牌"; break;
                                        case "4": model.CPYS = "黑牌"; break;
                                        case "5": model.CPYS = "绿牌"; break;
                                        case "6": model.CPYS = "小黄牌"; break;
                                        default:
                                            model.CPYS = ""; break;
                                    }
                                    switch (carinfo.InspectMethod)
                                    {
                                        case "4":
                                            waitmodel.JCFF = "ZYJS";
                                            break;
                                        case "1":
                                            waitmodel.JCFF = "VMAS";
                                            break;
                                        case "5":
                                            waitmodel.JCFF = "JZJS";
                                            break;
                                        case "3":
                                            waitmodel.JCFF = "LZ";
                                            break;
                                        case "2":
                                            waitmodel.JCFF = "SDS";
                                            break;
                                        case "6":
                                            waitmodel.JCFF = "ASM";
                                            break;
                                        default: waitmodel.JCFF = ""; break;
                                    }
                                    waitmodel.XSLC = "";
                                    waitmodel.JCCS = carinfo.InspectCount;
                                    waitmodel.CZY = "";
                                    waitmodel.JSY = "";
                                    waitmodel.DLY = "";
                                    waitmodel.JCFY = "";
                                    waitmodel.TEST = "";
                                    //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                    waitmodel.JCBGBH = "";
                                    waitmodel.JCGWH = "";
                                    waitmodel.JCZBH = "";
                                    waitmodel.JCRQ = DateTime.Now;
                                    waitmodel.BGJCFFYY = "";
                                    waitmodel.SFCS = "";
                                    waitmodel.ECRYPT = "";
                                    waitmodel.SFCJ = "初检";
                                    waitmodel.JYLSH = "";
                                    waitmodel.HPZL = carinfo.PlateType;
                                    carinflist.Add(model);
                                    caratwaitlist.Add(waitmodel);
                                }
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginRecord(string lineID, string  InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginRecord(long.Parse(AHLINEID[lineID]), InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginInspect(string lineID, string InspectID,string DirverID,string OperatorID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                ini.INIIO.saveSocketLogInf("BeginInspect\r\n" + "lineID:" + AHLINEID[lineID] + "\r\n" 
                    + "InspectID:" + InspectID + "\r\n" 
                    + "DriverID:" + DirverID + "\r\n"
                    + "OperatorID:" + OperatorID);
                RetValue retvalue = outlineservice.BeginInspect(long.Parse(AHLINEID[lineID]), InspectID, long.Parse(DirverID), long.Parse(OperatorID),0, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool TakePhoto(string lineID, string InspectID,int PicCode, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.TakePhoto(long.Parse(AHLINEID[lineID]), InspectID, PicCode,"");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("TakePhoto\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadVmasRealtimeData(string InspectID,DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if(dtseconds!=null)
                {
                    if(dtseconds.Rows.Count>0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");                        
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("VMASCount");
                        xe1.InnerText ="195";
                        root.AppendChild(xe1);
                        if (dtseconds != null)
                        {
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("VMAS"+i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                xe36.InnerText = dr["实时车速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("RPM");
                                xe37.InnerText = dr["发动机转速"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("HC");
                                xe38.InnerText = dr["HC实时值"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("CO");
                                xe39.InnerText = dr["CO实时值"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("NO");
                                xe40.InnerText = dr["NO实时值"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("O2");
                                xe41.InnerText = dr["分析仪O2实时值"].ToString();
                                XmlElement xe42 = xmldoc.CreateElement("CO2");
                                xe42.InnerText = dr["CO2实时值"].ToString();
                                XmlElement xe43 = xmldoc.CreateElement("O2_Flow");
                                xe43.InnerText = dr["流量计O2实时值"].ToString();
                                XmlElement xe44 = xmldoc.CreateElement("Flow_Act");
                                xe44.InnerText = dr["实际体积流量"].ToString();
                                XmlElement xe45 = xmldoc.CreateElement("Flow_Std");
                                xe45.InnerText = dr["标准体积流量"].ToString();
                                XmlElement xe46 = xmldoc.CreateElement("Flow_Ex");
                                xe46.InnerText = dr["尾气实际排放流量"].ToString();
                                XmlElement xe47 = xmldoc.CreateElement("HCMass");
                                xe47.InnerText = dr["HC排放质量"].ToString();
                                XmlElement xe48 = xmldoc.CreateElement("COMass");
                                xe48.InnerText = dr["CO排放质量"].ToString();
                                XmlElement xe49 = xmldoc.CreateElement("NOMass");
                                xe49.InnerText = dr["NO排放质量"].ToString();
                                XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                xe50.InnerText = dr["加载功率"].ToString();
                                XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                xe51.InnerText = dr["环境温度"].ToString();
                                XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                xe52.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe53 = xmldoc.CreateElement("Baro");
                                xe53.InnerText = dr["大气压力"].ToString();
                                XmlElement xe54 = xmldoc.CreateElement("Press_Flow");
                                xe54.InnerText = dr["流量计压力"].ToString();
                                XmlElement xe55 = xmldoc.CreateElement("Temperature_Flow");
                                xe55.InnerText = dr["流量计温度"].ToString();
                                XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                xe56.InnerText = dr["湿度修正系数"].ToString();
                                XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                xe57.InnerText = dr["稀释修正系数"].ToString();
                                XmlElement xe58 = xmldoc.CreateElement("DilutionRate");
                                xe58.InnerText = dr["稀释比"].ToString();
                                XmlElement xe59 = xmldoc.CreateElement("OilTemperature");
                                xe59.InnerText = dr["环境温度"].ToString();
                                XmlElement xe60 = xmldoc.CreateElement("O2_Env");
                                xe60.InnerText = dr["环境O2浓度"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                xe33.AppendChild(xe42);
                                xe33.AppendChild(xe43);
                                xe33.AppendChild(xe44);
                                xe33.AppendChild(xe45);
                                xe33.AppendChild(xe46);
                                xe33.AppendChild(xe47);
                                xe33.AppendChild(xe48);
                                xe33.AppendChild(xe49);
                                xe33.AppendChild(xe50);
                                xe33.AppendChild(xe51);
                                xe33.AppendChild(xe52);
                                xe33.AppendChild(xe53);
                                xe33.AppendChild(xe54);
                                xe33.AppendChild(xe55);
                                xe33.AppendChild(xe56);
                                xe33.AppendChild(xe57);
                                xe33.AppendChild(xe58);
                                xe33.AppendChild(xe59);
                                xe33.AppendChild(xe60);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID,xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadAsmRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("ASM5025_Count");
                        xe1.InnerText = "90";

                        XmlElement xe2 = xmldoc.CreateElement("ASM2540_Count");
                        xe2.InnerText = "90";
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        int asmprecount = 0;
                        int asmacc5025count = 0;
                        int asmacc2540count = 0;
                        int asmtest5025count = 0;
                        int asmtest2540count = 0;
                        int asm5025count = 0;
                        int asm2540count = 0;
                        if (dtseconds != null)
                        {
                            if (version == version_V23)
                            {
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "1")
                                    {
                                        asm5025count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm5025count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        root.AppendChild(xe33);
                                    }
                                    else if (dr["时序类别"].ToString() == "2")
                                    {
                                        asm2540count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + asm2540count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm2540count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        root.AppendChild(xe33);
                                    }
                                }
                                for (int i = asm5025count + 1; i <= 90; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + i.ToString("000"));
                                    root.AppendChild(xe33);
                                }
                                for (int i = asm2540count + 1; i <= 90; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + i.ToString("000"));
                                    root.AppendChild(xe33);
                                }
                            }
                            else if (version == version_V27)
                            {
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "0")
                                    {
                                        asm5025count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement DataType = xmldoc.CreateElement("DataType");
                                        DataType.InnerText = "0";//v2.7
                                        XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                        Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                        XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                        DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm5025count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                        WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                        XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                        IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                        XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                        OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        xe33.AppendChild(DataType);
                                        xe33.AppendChild(Torsion);
                                        xe33.AppendChild(DymoLoad);
                                        xe33.AppendChild(WattlessOutput);
                                        xe33.AppendChild(IndicatedPower);
                                        xe33.AppendChild(OilTemperature);
                                        root.AppendChild(xe33);
                                    }
                                }
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "3")
                                    {
                                        asm5025count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement DataType = xmldoc.CreateElement("DataType");
                                        DataType.InnerText = "3";//v2.7
                                        XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                        Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                        XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                        DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm5025count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                        WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                        XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                        IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                        XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                        OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        xe33.AppendChild(DataType);
                                        xe33.AppendChild(Torsion);
                                        xe33.AppendChild(DymoLoad);
                                        xe33.AppendChild(WattlessOutput);
                                        xe33.AppendChild(IndicatedPower);
                                        xe33.AppendChild(OilTemperature);
                                        root.AppendChild(xe33);
                                    }
                                }

                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "1")
                                    {
                                        asm5025count++;
                                        asmtest5025count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement DataType = xmldoc.CreateElement("DataType");
                                        DataType.InnerText = "1";//v2.7
                                        XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                        Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                        XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                        DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm5025count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                        WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                        XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                        IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                        XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                        OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        xe33.AppendChild(DataType);
                                        xe33.AppendChild(Torsion);
                                        xe33.AppendChild(DymoLoad);
                                        xe33.AppendChild(WattlessOutput);
                                        xe33.AppendChild(IndicatedPower);
                                        xe33.AppendChild(OilTemperature);
                                        root.AppendChild(xe33);
                                    }
                                }

                                for (int i = asmtest5025count + 1; i <= 90; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + (asm5025count + i - asmtest5025count).ToString("000"));
                                    root.AppendChild(xe33);
                                }

                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "4")
                                    {
                                        asm5025count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + asm2540count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement DataType = xmldoc.CreateElement("DataType");
                                        DataType.InnerText = "3";//v2.7
                                        XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                        Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                        XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                        DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm5025count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                        WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                        XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                        IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                        XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                        OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        xe33.AppendChild(DataType);
                                        xe33.AppendChild(Torsion);
                                        xe33.AppendChild(DymoLoad);
                                        xe33.AppendChild(WattlessOutput);
                                        xe33.AppendChild(IndicatedPower);
                                        xe33.AppendChild(OilTemperature);
                                        root.AppendChild(xe33);
                                    }
                                }

                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    DataRow dr = dtseconds.Rows[i];
                                    if (dr["时序类别"].ToString() == "2")
                                    {
                                        asm2540count++;
                                        asmtest2540count++;
                                        XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + asm2540count.ToString("000"));//创建一个<Node>节点 
                                        XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                        xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                        XmlElement DataType = xmldoc.CreateElement("DataType");
                                        DataType.InnerText = "2";//2.7
                                        XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                        Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                        XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                        DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                        XmlElement xe35 = xmldoc.CreateElement("Time");
                                        xe35.InnerText = asm2540count.ToString();
                                        XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                        xe36.InnerText = dr["实时车速"].ToString();
                                        XmlElement xe37 = xmldoc.CreateElement("RPM");
                                        xe37.InnerText = dr["转速"].ToString();
                                        XmlElement xe38 = xmldoc.CreateElement("HC");
                                        xe38.InnerText = dr["HC实时值"].ToString();
                                        XmlElement xe39 = xmldoc.CreateElement("CO");
                                        xe39.InnerText = dr["CO实时值"].ToString();
                                        XmlElement xe40 = xmldoc.CreateElement("NO");
                                        xe40.InnerText = dr["NO实时值"].ToString();
                                        XmlElement xe41 = xmldoc.CreateElement("O2");
                                        xe41.InnerText = dr["O2实时值"].ToString();
                                        XmlElement xe42 = xmldoc.CreateElement("CO2");
                                        xe42.InnerText = dr["CO2实时值"].ToString();
                                        XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                        xe50.InnerText = dr["加载功率"].ToString();
                                        XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                        WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                        XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                        IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                        XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                        OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                        XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                        xe51.InnerText = dr["环境温度"].ToString();
                                        XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                        xe52.InnerText = dr["相对湿度"].ToString();
                                        XmlElement xe53 = xmldoc.CreateElement("Baro");
                                        xe53.InnerText = dr["大气压力"].ToString();
                                        XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                        xe56.InnerText = dr["湿度修正系数"].ToString();
                                        XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                        xe57.InnerText = dr["稀释修正系数"].ToString();
                                        xe33.AppendChild(xe34);
                                        xe33.AppendChild(xe35);
                                        xe33.AppendChild(xe36);
                                        xe33.AppendChild(xe37);
                                        xe33.AppendChild(xe38);
                                        xe33.AppendChild(xe39);
                                        xe33.AppendChild(xe40);
                                        xe33.AppendChild(xe41);
                                        xe33.AppendChild(xe42);
                                        xe33.AppendChild(xe50);
                                        xe33.AppendChild(xe51);
                                        xe33.AppendChild(xe52);
                                        xe33.AppendChild(xe53);
                                        xe33.AppendChild(xe56);
                                        xe33.AppendChild(xe57);
                                        xe33.AppendChild(DataType);
                                        xe33.AppendChild(Torsion);
                                        xe33.AppendChild(DymoLoad);
                                        xe33.AppendChild(WattlessOutput);
                                        xe33.AppendChild(IndicatedPower);
                                        xe33.AppendChild(OilTemperature);
                                        root.AppendChild(xe33);
                                    }
                                }
                                for (int i = asmtest2540count + 1; i <= 90; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + (asm2540count + i - asmtest2540count).ToString("000"));
                                    root.AppendChild(xe33);
                                }
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadLugdownRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        
                        if (dtseconds != null)
                        {
                            if (version == version_V23)
                            {
                                XmlElement xe1 = xmldoc.CreateElement("LugDown_Count");
                                xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("LugDown" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = i.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["转速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("AbsorbedPower");
                                    xe37.InnerText = dr["功率"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("CarSpeed");
                                    xe38.InnerText = dr["车速"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("YD");
                                    xe39.InnerText = dr["光吸收系数K"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("Temperature");
                                    xe40.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("Humidity");
                                    xe41.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("Baro");
                                    xe42.InnerText = dr["大气压力"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);
                                    root.AppendChild(xe33);
                                }
                            }
                            else if (version == version_V27)
                            {
                                XmlElement xe1 = xmldoc.CreateElement("LugDown_Count");
                                xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("LugDown" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement DataType = xmldoc.CreateElement("DataType");
                                    DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = i.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["转速"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("CarSpeed");
                                    xe38.InnerText = dr["车速"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("YD");
                                    xe39.InnerText = dr["光吸收系数K"].ToString();
                                    XmlElement K = xmldoc.CreateElement("K");
                                    K.InnerText = dr["光吸收系数K"].ToString();
                                    XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                    WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                    XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                    IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                    XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                    OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                    XmlElement Power_Modify = xmldoc.CreateElement("Power_Modify");
                                    Power_Modify.InnerText = dr["DCF"].ToString();//v2.7
                                    XmlElement xe40 = xmldoc.CreateElement("Temperature");
                                    xe40.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("Humidity");
                                    xe41.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("Baro");
                                    xe42.InnerText = dr["大气压力"].ToString();
                                    XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                    Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                    XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                    DymoLoad.InnerText = dr["功率"].ToString();//v2.7
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    //xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);

                                    xe33.AppendChild(DataType);
                                    xe33.AppendChild(K);
                                    xe33.AppendChild(WattlessOutput);
                                    xe33.AppendChild(IndicatedPower);
                                    xe33.AppendChild(OilTemperature);
                                    xe33.AppendChild(Power_Modify);
                                    xe33.AppendChild(Torsion);
                                    xe33.AppendChild(DymoLoad);
                                    root.AppendChild(xe33);
                                }
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadSdsRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            if (version == version_V23)
                            {
                                XmlElement xe1 = xmldoc.CreateElement("GSICount");
                                xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("GSI" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = i.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["转速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("HC");
                                    xe37.InnerText = dr["HC"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("CO");
                                    xe38.InnerText = dr["CO"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO2");
                                    xe39.InnerText = dr["CO2"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("LMD");
                                    xe40.InnerText = dr["过量空气系数"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("OilTemperature");
                                    xe41.InnerText = dr["油温"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    root.AppendChild(xe33);
                                }
                            }
                            else if (version == version_V27)
                            {
                                XmlElement xe1 = xmldoc.CreateElement("GSICount");
                                xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("GSI" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement DataType = xmldoc.CreateElement("DataType");
                                    DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = i.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["转速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("HC");
                                    xe37.InnerText = dr["HC"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("CO");
                                    xe38.InnerText = dr["CO"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO2");
                                    xe39.InnerText = dr["CO2"].ToString();
                                    XmlElement O2 = xmldoc.CreateElement("O2");
                                    O2.InnerText = dr["O2"].ToString();
                                    XmlElement NO = xmldoc.CreateElement("NO");
                                    NO.InnerText = dr["NO"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("LMD");
                                    xe40.InnerText = dr["过量空气系数"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("OilTemperature");
                                    xe41.InnerText = dr["油温"].ToString();
                                    XmlElement Temperature = xmldoc.CreateElement("Temperature");
                                    Temperature.InnerText = dr["环境温度"].ToString();
                                    XmlElement Humidity = xmldoc.CreateElement("Humidity");
                                    Humidity.InnerText = dr["相对湿度"].ToString();
                                    XmlElement Baro = xmldoc.CreateElement("Baro");
                                    Baro.InnerText = dr["大气压力"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);

                                    xe33.AppendChild(DataType);
                                    xe33.AppendChild(O2);
                                    xe33.AppendChild(NO);
                                    xe33.AppendChild(Temperature);
                                    xe33.AppendChild(Humidity);
                                    xe33.AppendChild(Baro);

                                    root.AppendChild(xe33);
                                }
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadBtgRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            if (version == version_V23)
                            {

                                XmlElement xe1 = xmldoc.CreateElement("FACount");
                                xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("FA" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = dr["采样时序"].ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["发动机转速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("YD");
                                    xe37.InnerText = dr["烟度值读数"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("Temperature");
                                    xe38.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("Humidity");
                                    xe39.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("Baro");
                                    xe40.InnerText = dr["大气压力"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    root.AppendChild(xe33);
                                }
                            }
                            else if (version == version_V27)
                            {
                                    XmlElement xe1 = xmldoc.CreateElement("FACount");
                                    xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                                    root.AppendChild(xe1);
                                for (int i = 1; i < dtseconds.Rows.Count; i++)
                                {
                                    XmlElement xe33 = xmldoc.CreateElement("FA" + i.ToString("000"));//创建一个<Node>节点 
                                    DataRow dr = dtseconds.Rows[i];
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement DataType = xmldoc.CreateElement("DataType");
                                    DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = i.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("RPM");
                                    xe36.InnerText = dr["发动机转速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("YD");
                                    xe37.InnerText = dr["烟度值读数"].ToString();
                                    XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                    OilTemperature.InnerText = dr["油温"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(DataType);
                                    xe33.AppendChild(OilTemperature);
                                    root.AppendChild(xe33);
                                }
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectASM(string InspectID, AhAsmResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    if (version == version_V23)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("5025HC");
                        xe8.InnerText = inspectResult.HC5025;
                        XmlElement xe9 = xmldoc.CreateElement("5025CO");
                        xe9.InnerText = inspectResult.CO5025;
                        XmlElement xe10 = xmldoc.CreateElement("5025NO");
                        xe10.InnerText = inspectResult.NO5025;
                        XmlElement xe11 = xmldoc.CreateElement("2540HC");
                        xe11.InnerText = inspectResult.HC2540;
                        XmlElement xe12 = xmldoc.CreateElement("2540CO");
                        xe12.InnerText = inspectResult.CO2540;
                        XmlElement xe13 = xmldoc.CreateElement("2540NO");
                        xe13.InnerText = inspectResult.NO2540;
                        XmlElement xe14 = xmldoc.CreateElement("5025HCLimit");
                        xe14.InnerText = inspectResult.HC5025Limit;
                        XmlElement xe15 = xmldoc.CreateElement("5025COLimit");
                        xe15.InnerText = inspectResult.CO5025Limit;
                        XmlElement xe16 = xmldoc.CreateElement("5025NOLimit");
                        xe16.InnerText = inspectResult.NO5025Limit;
                        XmlElement xe17 = xmldoc.CreateElement("2540HCLimit");
                        xe17.InnerText = inspectResult.HC2540Limit;
                        XmlElement xe18 = xmldoc.CreateElement("2540COLimit");
                        xe18.InnerText = inspectResult.CO2540Limit;
                        XmlElement xe19 = xmldoc.CreateElement("2540NOLimit");
                        xe19.InnerText = inspectResult.NO2540Limit;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);
                        root.AppendChild(xe15);
                        root.AppendChild(xe16);
                        root.AppendChild(xe17);
                        root.AppendChild(xe18);
                        root.AppendChild(xe19);
                    }
                    else if (version == version_V27)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("HC5025");
                        xe8.InnerText = inspectResult.HC5025;
                        XmlElement xe9 = xmldoc.CreateElement("CO5025");
                        xe9.InnerText = inspectResult.CO5025;
                        XmlElement xe10 = xmldoc.CreateElement("NO5025");
                        xe10.InnerText = inspectResult.NO5025;
                        XmlElement xe11 = xmldoc.CreateElement("HC2540");
                        xe11.InnerText = inspectResult.HC2540;
                        XmlElement xe12 = xmldoc.CreateElement("CO2540");
                        xe12.InnerText = inspectResult.CO2540;
                        XmlElement xe13 = xmldoc.CreateElement("NO2540");
                        xe13.InnerText = inspectResult.NO2540;
                        XmlElement xe14 = xmldoc.CreateElement("HC5025Limit");
                        xe14.InnerText = inspectResult.HC5025Limit;
                        XmlElement xe15 = xmldoc.CreateElement("CO5025Limit");
                        xe15.InnerText = inspectResult.CO5025Limit;
                        XmlElement xe16 = xmldoc.CreateElement("NO5025Limit");
                        xe16.InnerText = inspectResult.NO5025Limit;
                        XmlElement xe17 = xmldoc.CreateElement("HC2540Limit");
                        xe17.InnerText = inspectResult.HC2540Limit;
                        XmlElement xe18 = xmldoc.CreateElement("CO2540Limit");
                        xe18.InnerText = inspectResult.CO2540Limit;
                        XmlElement xe19 = xmldoc.CreateElement("NO2540Limit");
                        xe19.InnerText = inspectResult.NO2540Limit;

                        XmlElement HC5025Result = xmldoc.CreateElement("HC5025Result");
                        HC5025Result.InnerText = inspectResult.HC5025Result;
                        XmlElement CO5025Result = xmldoc.CreateElement("CO5025Result");
                        CO5025Result.InnerText = inspectResult.CO5025Result;
                        XmlElement NO5025Result = xmldoc.CreateElement("NO5025Result");
                        NO5025Result.InnerText = inspectResult.NO5025Result;
                        XmlElement HC2540Result = xmldoc.CreateElement("HC2540Result");
                        HC2540Result.InnerText = inspectResult.HC2540Result;
                        XmlElement HC25405Result = xmldoc.CreateElement("HC25405Result");
                        HC25405Result.InnerText = inspectResult.HC2540Result;
                        XmlElement CO2540Result = xmldoc.CreateElement("CO2540Result");
                        CO2540Result.InnerText = inspectResult.CO2540Result;
                        XmlElement NO2540Result = xmldoc.CreateElement("NO2540Result");
                        NO2540Result.InnerText = inspectResult.NO2540Result;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);
                        root.AppendChild(xe15);
                        root.AppendChild(xe16);
                        root.AppendChild(xe17);
                        root.AppendChild(xe18);
                        root.AppendChild(xe19);

                        root.AppendChild(HC5025Result);
                        root.AppendChild(CO5025Result);
                        root.AppendChild(NO5025Result);
                        root.AppendChild(HC2540Result);
                        root.AppendChild(HC25405Result);
                        root.AppendChild(CO2540Result);
                        root.AppendChild(NO2540Result);
                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectSDS(string InspectID, AhSdsResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    if (version == version_V23)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("LowRPM");
                        xe8.InnerText = inspectResult.LowRPM;
                        XmlElement xe9 = xmldoc.CreateElement("LowCO");
                        xe9.InnerText = inspectResult.LowCO;
                        XmlElement xe10 = xmldoc.CreateElement("LowCO2");
                        xe10.InnerText = inspectResult.LowCO2;
                        XmlElement xe11 = xmldoc.CreateElement("LowHC");
                        xe11.InnerText = inspectResult.LowHC;
                        XmlElement xe12 = xmldoc.CreateElement("HiRPM");
                        xe12.InnerText = inspectResult.HiRPM;
                        XmlElement xe13 = xmldoc.CreateElement("HiCO");
                        xe13.InnerText = inspectResult.HiCO;
                        XmlElement xe14 = xmldoc.CreateElement("HiCO2");
                        xe14.InnerText = inspectResult.HiCO2;
                        XmlElement xe15 = xmldoc.CreateElement("HiHC");
                        xe15.InnerText = inspectResult.HiHC;
                        XmlElement xe16 = xmldoc.CreateElement("LMD");
                        xe16.InnerText = inspectResult.LMD;
                        XmlElement xe17 = xmldoc.CreateElement("LowCOLimit");
                        xe17.InnerText = inspectResult.LowCOLimit;
                        XmlElement xe18 = xmldoc.CreateElement("LowHCLimit");
                        xe18.InnerText = inspectResult.LowHCLimit;
                        XmlElement xe19 = xmldoc.CreateElement("HiCOLimit");
                        xe19.InnerText = inspectResult.HiCOLimit;
                        XmlElement xe20 = xmldoc.CreateElement("HiHCLimit");
                        xe20.InnerText = inspectResult.HiHCLimit;
                        XmlElement xe21 = xmldoc.CreateElement("LMDLimitMin");
                        xe21.InnerText = inspectResult.LMDLimitMin;
                        XmlElement xe22 = xmldoc.CreateElement("LMDLimitMax");
                        xe22.InnerText = inspectResult.LMDLimitMax;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);
                        root.AppendChild(xe15);
                        root.AppendChild(xe16);
                        root.AppendChild(xe17);
                        root.AppendChild(xe18);
                        root.AppendChild(xe19);
                        root.AppendChild(xe20);
                        root.AppendChild(xe21);
                        root.AppendChild(xe22);
                    }
                    else if (version == version_V27)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("LowRPM");
                        xe8.InnerText = inspectResult.LowRPM;
                        XmlElement xe9 = xmldoc.CreateElement("LowCO");
                        xe9.InnerText = inspectResult.LowCO;
                        XmlElement xe10 = xmldoc.CreateElement("LowCO2");
                        xe10.InnerText = inspectResult.LowCO2;
                        XmlElement xe11 = xmldoc.CreateElement("LowHC");
                        xe11.InnerText = inspectResult.LowHC;
                        XmlElement xe12 = xmldoc.CreateElement("HiRPM");
                        xe12.InnerText = inspectResult.HiRPM;
                        XmlElement xe13 = xmldoc.CreateElement("HiCO");
                        xe13.InnerText = inspectResult.HiCO;
                        XmlElement xe14 = xmldoc.CreateElement("HiCO2");
                        xe14.InnerText = inspectResult.HiCO2;
                        XmlElement xe15 = xmldoc.CreateElement("HiHC");
                        xe15.InnerText = inspectResult.HiHC;
                        XmlElement xe16 = xmldoc.CreateElement("LMD");
                        xe16.InnerText = inspectResult.LMD;
                        XmlElement xe17 = xmldoc.CreateElement("LowCOLimit");
                        xe17.InnerText = inspectResult.LowCOLimit;
                        XmlElement xe18 = xmldoc.CreateElement("LowHCLimit");
                        xe18.InnerText = inspectResult.LowHCLimit;
                        XmlElement xe19 = xmldoc.CreateElement("HiCOLimit");
                        xe19.InnerText = inspectResult.HiCOLimit;
                        XmlElement xe20 = xmldoc.CreateElement("HiHCLimit");
                        xe20.InnerText = inspectResult.HiHCLimit;
                        XmlElement xe21 = xmldoc.CreateElement("LMDLimitMin");
                        xe21.InnerText = inspectResult.LMDLimitMin;
                        XmlElement xe22 = xmldoc.CreateElement("LMDLimitMax");
                        xe22.InnerText = inspectResult.LMDLimitMax;

                        XmlElement HiCOResult = xmldoc.CreateElement("HiCOResult");
                        HiCOResult.InnerText = inspectResult.HiCOResult;
                        XmlElement HiHCResult = xmldoc.CreateElement("HiHCResult");
                        HiHCResult.InnerText = inspectResult.HiHCResult;
                        XmlElement LowCOResult = xmldoc.CreateElement("LowCOResult");
                        LowCOResult.InnerText = inspectResult.LowCOResult;
                        XmlElement LowHCResult = xmldoc.CreateElement("LowHCResult");
                        LowHCResult.InnerText = inspectResult.LowHCResult;
                        XmlElement LMDResult = xmldoc.CreateElement("LMDResult");
                        LMDResult.InnerText = inspectResult.LMDResult;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);
                        root.AppendChild(xe15);
                        root.AppendChild(xe16);
                        root.AppendChild(xe17);
                        root.AppendChild(xe18);
                        root.AppendChild(xe19);
                        root.AppendChild(xe20);
                        root.AppendChild(xe21);
                        root.AppendChild(xe22);
                        root.AppendChild(HiCOResult);
                        root.AppendChild(HiHCResult);
                        root.AppendChild(LowCOResult);
                        root.AppendChild(LowHCResult);
                        root.AppendChild(LMDResult);
                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectLugdown(string InspectID, AhLugdownResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    if (version == version_V23)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("CrucialTime3");
                        xe8.InnerText = inspectResult.CrucialTime3;
                        XmlElement xe9 = xmldoc.CreateElement("YD1");
                        xe9.InnerText = inspectResult.YD1;
                        XmlElement xe10 = xmldoc.CreateElement("YD2");
                        xe10.InnerText = inspectResult.YD2;
                        XmlElement xe11 = xmldoc.CreateElement("YD3");
                        xe11.InnerText = inspectResult.YD3;
                        XmlElement xe12 = xmldoc.CreateElement("Power");
                        xe12.InnerText = inspectResult.Power;
                        XmlElement xe13 = xmldoc.CreateElement("YDLimit");
                        xe13.InnerText = inspectResult.YDLimit;
                        XmlElement xe14 = xmldoc.CreateElement("PowerLimit");
                        xe14.InnerText = inspectResult.PowerLimit;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);
                    }
                    else if (version == version_V27)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                        xe6.InnerText = inspectResult.CrucialTime1;
                        XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                        xe7.InnerText = inspectResult.CrucialTime2;
                        XmlElement xe8 = xmldoc.CreateElement("CrucialTime3");
                        xe8.InnerText = inspectResult.CrucialTime3;
                        XmlElement xe9 = xmldoc.CreateElement("YD1");
                        xe9.InnerText = inspectResult.YD1;
                        XmlElement xe10 = xmldoc.CreateElement("YD2");
                        xe10.InnerText = inspectResult.YD2;
                        XmlElement xe11 = xmldoc.CreateElement("YD3");
                        xe11.InnerText = inspectResult.YD3;
                        XmlElement xe12 = xmldoc.CreateElement("Power");
                        xe12.InnerText = inspectResult.Power;
                        XmlElement xe13 = xmldoc.CreateElement("YDLimit");
                        xe13.InnerText = inspectResult.YDLimit;
                        XmlElement xe14 = xmldoc.CreateElement("PowerLimit");
                        xe14.InnerText = inspectResult.PowerLimit;

                        XmlElement RateSpeedUp = xmldoc.CreateElement("RateSpeedUp");
                        RateSpeedUp.InnerText = inspectResult.RateSpeedUp;
                        XmlElement RateSpeedDown = xmldoc.CreateElement("RateSpeedDown");
                        RateSpeedDown.InnerText = inspectResult.RateSpeedDown;
                        XmlElement RealRateSpeed = xmldoc.CreateElement("RealRateSpeed");
                        RealRateSpeed.InnerText = inspectResult.RealRateSpeed;
                        XmlElement YDResult = xmldoc.CreateElement("YDResult");
                        YDResult.InnerText = inspectResult.YDResult;
                        XmlElement PowerResult = xmldoc.CreateElement("PowerResult");
                        PowerResult.InnerText = inspectResult.PowerResult;

                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(xe12);
                        root.AppendChild(xe13);
                        root.AppendChild(xe14);

                        root.AppendChild(RateSpeedUp);
                        root.AppendChild(RateSpeedDown);
                        root.AppendChild(RealRateSpeed);
                        root.AppendChild(YDResult);
                        root.AppendChild(PowerResult);
                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectBtg(string InspectID, AhBtgResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    if (version == version_V23)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("YD0");
                        xe6.InnerText = inspectResult.YD0;
                        XmlElement xe7 = xmldoc.CreateElement("YD1");
                        xe7.InnerText = inspectResult.YD1;
                        XmlElement xe8 = xmldoc.CreateElement("YD2");
                        xe8.InnerText = inspectResult.YD2;
                        XmlElement xe9 = xmldoc.CreateElement("YD3");
                        xe9.InnerText = inspectResult.YD3;
                        XmlElement xe10 = xmldoc.CreateElement("YDAV");
                        xe10.InnerText = inspectResult.YDAV;
                        XmlElement xe11 = xmldoc.CreateElement("YDLimit");
                        xe11.InnerText = inspectResult.YDLimit;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                    }
                    else if (version == version_V27)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("Result");
                        xe1.InnerText = inspectResult.Result;
                        XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                        xe2.InnerText = inspectResult.CrucialTime0;
                        XmlElement xe3 = xmldoc.CreateElement("Temperature");
                        xe3.InnerText = inspectResult.Temperature;
                        XmlElement xe4 = xmldoc.CreateElement("Humidity");
                        xe4.InnerText = inspectResult.Humidity;
                        XmlElement xe5 = xmldoc.CreateElement("Baro");
                        xe5.InnerText = inspectResult.Baro;
                        XmlElement xe6 = xmldoc.CreateElement("YD0");
                        xe6.InnerText = inspectResult.YD0;
                        XmlElement xe7 = xmldoc.CreateElement("YD1");
                        xe7.InnerText = inspectResult.YD1;
                        XmlElement xe8 = xmldoc.CreateElement("YD2");
                        xe8.InnerText = inspectResult.YD2;
                        XmlElement xe9 = xmldoc.CreateElement("YD3");
                        xe9.InnerText = inspectResult.YD3;
                        XmlElement xe10 = xmldoc.CreateElement("YDAV");
                        xe10.InnerText = inspectResult.YDAV;
                        XmlElement xe11 = xmldoc.CreateElement("YDLimit");
                        xe11.InnerText = inspectResult.YDLimit;
                        XmlElement IdleSpeed = xmldoc.CreateElement("IdleSpeed");
                        IdleSpeed.InnerText = inspectResult.IdleSpeed;
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                        root.AppendChild(xe9);
                        root.AppendChild(xe10);
                        root.AppendChild(xe11);
                        root.AppendChild(IdleSpeed);
                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool StopInspect(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.StopInspect(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("StopInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool GetSdsLimit(string InspectID,out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            if (version == version_V23)
            {
                /*
                try
                {
                    RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        string noticeString = retvalue.TipMessage;
                        string xmlstring = retvalue.Value;
                        DataSet ds = new DataSet();
                        xmlstring = "<body>" + xmlstring + "</body>";
                        ds = XmlToData.CXmlToDataSet(xmlstring);

                        ahlimit.LowCOLimit = ds.Tables["body"].Rows[0]["LowCOLimit"].ToString();
                        ahlimit.LowCO2Limit = "";
                        ahlimit.LowHCLimit = ds.Tables["body"].Rows[0]["LowHCLimit"].ToString();
                        ahlimit.HiCOLimit = ds.Tables["body"].Rows[0]["HiCOLimit"].ToString();
                        ahlimit.HiCO2Limit = "";
                        ahlimit.HiHCLimit = ds.Tables["body"].Rows[0]["HiHCLimit"].ToString();

                        ahlimit.LMDLimitMin = ds.Tables["body"].Rows[0]["LMDLimitMin"].ToString();
                        ahlimit.LMDLimitMax = ds.Tables["body"].Rows[0]["LMDLimitMax"].ToString();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    return false;
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
                */
                return false;
            }
            else
                return false;
        }
        public bool GetASMLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            if (version == version_V23)
            {
                /*
                try
                {
                    RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        string noticeString = retvalue.TipMessage;
                        string xmlstring = retvalue.Value;
                        xmlstring = xmlstring.Replace("5025", "Limit5025");
                        xmlstring = xmlstring.Replace("2540", "Limit2540");
                        DataSet ds = new DataSet();
                        xmlstring = "<body>" + xmlstring + "</body>";
                        ds = XmlToData.CXmlToDataSet(xmlstring);

                        ahlimit.HC5025Limit = ds.Tables["body"].Rows[0]["Limit5025HCLimit"].ToString();
                        ahlimit.CO5025Limit = ds.Tables["body"].Rows[0]["Limit5025COLimit"].ToString();
                        ahlimit.NO5025Limit = ds.Tables["body"].Rows[0]["Limit5025NOLimit"].ToString();
                        ahlimit.HC2540Limit = ds.Tables["body"].Rows[0]["Limit2540HCLimit"].ToString();
                        ahlimit.CO2540Limit = ds.Tables["body"].Rows[0]["Limit2540COLimit"].ToString();
                        ahlimit.NO2540Limit = ds.Tables["body"].Rows[0]["Limit2540NOLimit"].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }*/
                return false;
            }
            else
                return false;
        }
        public bool GetVMASLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            if (version == version_V23)
            {
                /*
                try
                {
                    RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        string noticeString = retvalue.TipMessage;
                        string xmlstring = retvalue.Value;
                        DataSet ds = new DataSet();
                        xmlstring = "<body>" + xmlstring + "</body>";
                        ds = XmlToData.CXmlToDataSet(xmlstring);
                        //DataTable valuedt = ds.Tables["body"];
                        ahlimit.HCLimit = ds.Tables["body"].Rows[0]["HCLimit"].ToString();
                        ahlimit.COLimit = ds.Tables["body"].Rows[0]["COLimit"].ToString();
                        ahlimit.NOLimit = ds.Tables["body"].Rows[0]["NOLimit"].ToString();
                        ahlimit.HC_NOLimit = ds.Tables["body"].Rows[0]["HC_NOLimit"].ToString();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
                */
                return false;
            }
            else
                return false;
        }
        public bool GetJZJSLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            if (version == version_V23)
            {
                /*
                try
                {
                    RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        string noticeString = retvalue.TipMessage;
                        string xmlstring = retvalue.Value;
                        DataSet ds = new DataSet();
                        xmlstring = "<body>" + xmlstring + "</body>";
                        ds = XmlToData.CXmlToDataSet(xmlstring);

                        ahlimit.LugdownYDLimit = ds.Tables["body"].Rows[0]["YDLimit"].ToString();
                        ahlimit.LugdownPowerLimit = ds.Tables["body"].Rows[0]["PowerLimit"].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }*/
                return false;
            }
            else
                return false;
        }
        public bool GetBTGLimit(string InspectID, out int result, out string errMsg, out Ahlimit ahlimit)
        {
            result = 0;
            errMsg = "";
            ahlimit = new Ahlimit();
            if (version == version_V23)
            {
                /*
                try
                {
                    RetValue retvalue = outlineservice.GetLimit(InspectID, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("GetLimit\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        string noticeString = retvalue.TipMessage;
                        string xmlstring = retvalue.Value;
                        DataSet ds = new DataSet();
                        xmlstring = "<body>" + xmlstring + "</body>";
                        ds = XmlToData.CXmlToDataSet(xmlstring);

                        ahlimit.BtgYDLimit = ds.Tables["body"].Rows[0]["YDLimit"].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }*/
                return false;
            }
            else
                return false;
        }

        public bool EndInspect(string InspectID,XmlDocument inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                string xmlstring = ConvertXmlToString(inspectResult);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID,xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndRecord(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.EndRecord(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginSelfTest(string LineID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginSelfTest(long.Parse(AHLINEID[LineID]), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndSelfTest(string LineID,selfcheckdata selfTestResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (selfTestResult != null)
                {

                    if (version == version_V23)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("AllResult");
                        xe1.InnerText = selfTestResult.AllJudge;
                        XmlElement xe2 = xmldoc.CreateElement("Temperature");
                        xe2.InnerText = selfTestResult.TEMP;
                        XmlElement xe3 = xmldoc.CreateElement("Humidity");
                        xe3.InnerText = selfTestResult.HUMI;
                        XmlElement xe4 = xmldoc.CreateElement("Baro");
                        xe4.InnerText = selfTestResult.AIRP;

                        XmlElement xe5 = xmldoc.CreateElement("SlideResult");
                        XmlElement xe51 = xmldoc.CreateElement("Judge");
                        xe51.InnerText = selfTestResult.SlideJudge;
                        XmlElement xe52 = xmldoc.CreateElement("HSSlideResult");
                        XmlElement xe521 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe522 = xmldoc.CreateElement("EndTime");
                        XmlElement xe523 = xmldoc.CreateElement("TheoreticalTime");
                        XmlElement xe524 = xmldoc.CreateElement("ActualTime");
                        XmlElement xe525 = xmldoc.CreateElement("LoadPower");
                        xe521.InnerText = selfTestResult.HSSlideBeginTime;
                        xe522.InnerText = selfTestResult.HSSlideEndTime;
                        xe523.InnerText = selfTestResult.HSSlideTheoreticalTime;
                        xe524.InnerText = selfTestResult.HSSlideActualTime;
                        xe525.InnerText = selfTestResult.HSSlideLoadPower;
                        xe52.AppendChild(xe521);
                        xe52.AppendChild(xe522);
                        xe52.AppendChild(xe523);
                        xe52.AppendChild(xe524);
                        xe52.AppendChild(xe525);
                        XmlElement xe53 = xmldoc.CreateElement("LSSlideResult");
                        XmlElement xe531 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe532 = xmldoc.CreateElement("EndTime");
                        XmlElement xe533 = xmldoc.CreateElement("TheoreticalTime");
                        XmlElement xe534 = xmldoc.CreateElement("ActualTime");
                        XmlElement xe535 = xmldoc.CreateElement("LoadPower");
                        xe531.InnerText = selfTestResult.LSSlideBeginTime;
                        xe532.InnerText = selfTestResult.LSSlideEndTime;
                        xe533.InnerText = selfTestResult.LSSlideTheoreticalTime;
                        xe534.InnerText = selfTestResult.LSSlideActualTime;
                        xe535.InnerText = selfTestResult.LSSlideLoadPower;
                        xe53.AppendChild(xe531);
                        xe53.AppendChild(xe532);
                        xe53.AppendChild(xe533);
                        xe53.AppendChild(xe534);
                        xe53.AppendChild(xe535);
                        xe5.AppendChild(xe51);
                        xe5.AppendChild(xe52);
                        xe5.AppendChild(xe53);

                        XmlElement xe6 = xmldoc.CreateElement("WattlessOutputResult");
                        XmlElement xe61 = xmldoc.CreateElement("Judge");
                        xe61.InnerText = selfTestResult.WattlessJudge;
                        XmlElement xe62 = xmldoc.CreateElement("SpeedRange1");
                        XmlElement xe621 = xmldoc.CreateElement("MaxSpeed");
                        XmlElement xe622 = xmldoc.CreateElement("MinSpeed");
                        XmlElement xe623 = xmldoc.CreateElement("NominalSpeed");
                        XmlElement xe624 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe625 = xmldoc.CreateElement("EndTime");
                        XmlElement xe626 = xmldoc.CreateElement("WattlessOutput");
                        xe621.InnerText = selfTestResult.WattlessMaxSpeed1;
                        xe622.InnerText = selfTestResult.WattlessMinSpeed1;
                        xe623.InnerText = selfTestResult.WattlessNorminalSpeed1;
                        xe624.InnerText = selfTestResult.WattlessBeginTime1;
                        xe625.InnerText = selfTestResult.WattlessEndTime1;
                        xe626.InnerText = selfTestResult.WattlessOutput1;
                        xe62.AppendChild(xe621);
                        xe62.AppendChild(xe622);
                        xe62.AppendChild(xe623);
                        xe62.AppendChild(xe624);
                        xe62.AppendChild(xe625);
                        xe62.AppendChild(xe626);
                        XmlElement xe63 = xmldoc.CreateElement("SpeedRange2");
                        XmlElement xe631 = xmldoc.CreateElement("MaxSpeed");
                        XmlElement xe632 = xmldoc.CreateElement("MinSpeed");
                        XmlElement xe633 = xmldoc.CreateElement("NominalSpeed");
                        XmlElement xe634 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe635 = xmldoc.CreateElement("EndTime");
                        XmlElement xe636 = xmldoc.CreateElement("WattlessOutput");
                        xe631.InnerText = selfTestResult.WattlessMaxSpeed2;
                        xe632.InnerText = selfTestResult.WattlessMinSpeed2;
                        xe633.InnerText = selfTestResult.WattlessNorminalSpeed2;
                        xe634.InnerText = selfTestResult.WattlessBeginTime2;
                        xe635.InnerText = selfTestResult.WattlessEndTime2;
                        xe636.InnerText = selfTestResult.WattlessOutput2;
                        xe63.AppendChild(xe631);
                        xe63.AppendChild(xe632);
                        xe63.AppendChild(xe633);
                        xe63.AppendChild(xe634);
                        xe63.AppendChild(xe635);
                        xe63.AppendChild(xe636);
                        XmlElement xe64 = xmldoc.CreateElement("SpeedRange3");
                        XmlElement xe641 = xmldoc.CreateElement("MaxSpeed");
                        XmlElement xe642 = xmldoc.CreateElement("MinSpeed");
                        XmlElement xe643 = xmldoc.CreateElement("NominalSpeed");
                        XmlElement xe644 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe645 = xmldoc.CreateElement("EndTime");
                        XmlElement xe646 = xmldoc.CreateElement("WattlessOutput");
                        xe641.InnerText = selfTestResult.WattlessMaxSpeed3;
                        xe642.InnerText = selfTestResult.WattlessMinSpeed3;
                        xe643.InnerText = selfTestResult.WattlessNorminalSpeed3;
                        xe644.InnerText = selfTestResult.WattlessBeginTime3;
                        xe645.InnerText = selfTestResult.WattlessEndTime3;
                        xe646.InnerText = selfTestResult.WattlessOutput3;
                        xe64.AppendChild(xe641);
                        xe64.AppendChild(xe642);
                        xe64.AppendChild(xe643);
                        xe64.AppendChild(xe644);
                        xe64.AppendChild(xe645);
                        xe64.AppendChild(xe646);
                        XmlElement xe65 = xmldoc.CreateElement("SpeedRange4");
                        XmlElement xe651 = xmldoc.CreateElement("MaxSpeed");
                        XmlElement xe652 = xmldoc.CreateElement("MinSpeed");
                        XmlElement xe653 = xmldoc.CreateElement("NominalSpeed");
                        XmlElement xe654 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe655 = xmldoc.CreateElement("EndTime");
                        XmlElement xe656 = xmldoc.CreateElement("WattlessOutput");
                        xe651.InnerText = selfTestResult.WattlessMaxSpeed4;
                        xe652.InnerText = selfTestResult.WattlessMinSpeed4;
                        xe653.InnerText = selfTestResult.WattlessNorminalSpeed4;
                        xe654.InnerText = selfTestResult.WattlessBeginTime4;
                        xe655.InnerText = selfTestResult.WattlessEndTime4;
                        xe656.InnerText = selfTestResult.WattlessOutput4;
                        xe65.AppendChild(xe651);
                        xe65.AppendChild(xe652);
                        xe65.AppendChild(xe653);
                        xe65.AppendChild(xe654);
                        xe65.AppendChild(xe655);
                        xe65.AppendChild(xe656);

                        xe6.AppendChild(xe61);
                        xe6.AppendChild(xe62);
                        xe6.AppendChild(xe63);
                        xe6.AppendChild(xe64);
                        xe6.AppendChild(xe65);

                        XmlElement xe7 = xmldoc.CreateElement("O2MR");
                        XmlElement xe71 = xmldoc.CreateElement("Judge");
                        XmlElement xe72 = xmldoc.CreateElement("O2");
                        XmlElement xe73 = xmldoc.CreateElement("Flow");
                        XmlElement xe74 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe75 = xmldoc.CreateElement("EndTime");
                        xe7.AppendChild(xe71);
                        xe7.AppendChild(xe72);
                        xe7.AppendChild(xe73);
                        xe7.AppendChild(xe74);
                        xe7.AppendChild(xe75);

                        XmlElement xe8 = xmldoc.CreateElement("WQResult");
                        XmlElement xe81 = xmldoc.CreateElement("Judge");
                        XmlElement xe82 = xmldoc.CreateElement("Tightness");
                        XmlElement xe83 = xmldoc.CreateElement("ResidualHC");
                        XmlElement xe84 = xmldoc.CreateElement("FlowResult");
                        XmlElement xe85 = xmldoc.CreateElement("BeginTime");
                        XmlElement xe86 = xmldoc.CreateElement("EndTime");
                        xe81.InnerText = selfTestResult.WQJudge;
                        xe82.InnerText = (selfTestResult.FQYJL == "Y" ? "1" : "2");
                        xe83.InnerText = "1";
                        xe84.InnerText = "1";
                        xe85.InnerText = selfTestResult.WQBeginTime;
                        xe86.InnerText = selfTestResult.WQEndTime;
                        xe8.AppendChild(xe81);
                        xe8.AppendChild(xe82);
                        xe8.AppendChild(xe83);
                        xe8.AppendChild(xe84);
                        xe8.AppendChild(xe85);
                        xe8.AppendChild(xe86);

                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);
                        root.AppendChild(xe5);
                        root.AppendChild(xe6);
                        root.AppendChild(xe7);
                        root.AppendChild(xe8);
                    }
                    else if(version==version_V27)
                    {
                        XmlElement xe1 = xmldoc.CreateElement("AllResult");
                        xe1.InnerText = selfTestResult.AllJudge;
                        XmlElement xe2 = xmldoc.CreateElement("Temperature");
                        xe2.InnerText = selfTestResult.TEMP;
                        XmlElement xe3 = xmldoc.CreateElement("Humidity");
                        xe3.InnerText = selfTestResult.HUMI;
                        XmlElement xe4 = xmldoc.CreateElement("Baro");
                        xe4.InnerText = selfTestResult.AIRP;


                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        root.AppendChild(xe3);
                        root.AppendChild(xe4);

                    }
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndSelfTest(long.Parse(AHLINEID[LineID]), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool Send_SELFCHECK_RESULT_DATA<T>(string LineID, ah_selfcheck_public_data pmodel, T model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            if (version == version_V23)
            {
                errMsg = "该版本不支持该接口";
                return false;
            }
            else
            {
                try
                {
                    XmlDocument xmldoc, xlmrecivedoc;
                    XmlNode xmlnode;
                    XmlElement xmlelem;
                    xmldoc = new XmlDocument();
                    xmlelem = xmldoc.CreateElement("", "body", "");
                    xmldoc.AppendChild(xmlelem);
                    XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                    XmlElement DeviceType = xmldoc.CreateElement("DeviceType");//创建一个<Node>节点 
                    XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                    XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                    XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                    DeviceType.InnerText = pmodel.DeviceType;
                    BeginTime.InnerText = pmodel.BeginTime;
                    EndTime.InnerText = pmodel.EndTime;
                    Judge.InnerText = pmodel.Judge;
                    XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                    List<string> namelist = new List<string>();
                    List<string> valuelist = new List<string>();
                    if (carinfo.XmlBuilderHelper.GetPorperty(model, out namelist, out valuelist))
                    {
                        for (int i = 0; i < namelist.Count; i++)
                        {
                            XmlElement el = xmldoc.CreateElement(namelist[i]);
                            el.InnerText = valuelist[i];
                            JudgeData.AppendChild(el);
                        }
                    }
                    root.AppendChild(DeviceType);
                    root.AppendChild(BeginTime);
                    root.AppendChild(EndTime);
                    root.AppendChild(Judge);
                    root.AppendChild(JudgeData);
                    string xmlstring = ConvertXmlToString(xmldoc);
                    xmlstring = xmlstring.Replace("<body>", "");
                    xmlstring = xmlstring.Replace("</body>", "");
                    xmlstring = xmlstring.Replace("\r\n", "");
                    xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    RetValue retvalue = outlineservice.UploadSelfTestData(long.Parse(AHLINEID[LineID]), xmlstring, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("UploadSelfTestData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
            }
        }
        public bool BeginCalibrate(string LineID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            if (version == version_V23)
                return true;
            else
            {
                try
                {
                    RetValue retvalue = outlineservice.BeginCalibrate(long.Parse(AHLINEID[LineID]), "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("BeginCalibrate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
            }
        }
        public bool EndCalibrate(string LineID, string selfTestResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            if (version == version_V23)
                return true;
            else
            {
                try
                {

                    RetValue retvalue = outlineservice.EndCalibrate(long.Parse(AHLINEID[LineID]), selfTestResult, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("EndCalibrate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
            }
        }

        public bool Send_CALIBRATION_RESULT_DATA<T>(string LineID, ah_cal_public_data pmodel, ah_cal_judge_data jdata, List<T> model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            if (version == version_V23)
                return true;
            else
            {
                try
                {
                    XmlDocument xmldoc, xlmrecivedoc;
                    XmlNode xmlnode;
                    XmlElement xmlelem;
                    xmldoc = new XmlDocument();
                    xmlelem = xmldoc.CreateElement("", "body", "");
                    xmldoc.AppendChild(xmlelem);
                    XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                    XmlElement DeviceType = xmldoc.CreateElement("Type");//创建一个<Node>节点 
                    XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                    XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                    XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                    DeviceType.InnerText = pmodel.Type;
                    BeginTime.InnerText = pmodel.BeginTime;
                    EndTime.InnerText = pmodel.EndTime;
                    Judge.InnerText = pmodel.Judge;
                    XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                    XmlElement type = xmldoc.CreateElement("type");//创建一个<Node>节点 
                                                                   //XmlElement InertiaEquivalent = xmldoc.CreateElement("InertiaEquivalent");//创建一个<Node>节点 
                    XmlElement CalibrateCount = xmldoc.CreateElement("CalibrateCount");//创建一个<Node>节点 
                    type.InnerText = jdata.type;
                    //InertiaEquivalent.InnerText = jdata.InertiaEquivalent;
                    CalibrateCount.InnerText = jdata.CalibrateCount;
                    JudgeData.AppendChild(type);
                    //JudgeData.AppendChild(InertiaEquivalent);
                    JudgeData.AppendChild(CalibrateCount);
                    if (typeof(T) == typeof(ah_jzhx_caldata) || typeof(T) == typeof(ah_plhp_caldata))
                    {
                        XmlElement InertiaEquivalent = xmldoc.CreateElement("InertiaEquivalent");//创建一个<Node>节点 
                        InertiaEquivalent.InnerText = jdata.InertiaEquivalent;
                        JudgeData.AppendChild(InertiaEquivalent);
                    }
                    if (typeof(T) != typeof(ah_gl_caldata))
                    {
                        for (int pointIndex = 1; pointIndex <= model.Count; pointIndex++)
                        {
                            XmlElement Point = xmldoc.CreateElement("Point_" + pointIndex.ToString());//创建一个<Node>节点 
                            List<string> namelist = new List<string>();
                            List<string> valuelist = new List<string>();
                            if (carinfo.XmlBuilderHelper.GetPorperty(model[pointIndex - 1], out namelist, out valuelist))
                            {
                                for (int i = 0; i < namelist.Count; i++)
                                {
                                    XmlElement el = xmldoc.CreateElement(namelist[i]);
                                    el.InnerText = valuelist[i];
                                    Point.AppendChild(el);
                                }
                            }
                            JudgeData.AppendChild(Point);
                        }
                    }
                    root.AppendChild(DeviceType);
                    root.AppendChild(BeginTime);
                    root.AppendChild(EndTime);
                    root.AppendChild(Judge);
                    root.AppendChild(JudgeData);
                    string xmlstring = ConvertXmlToString(xmldoc);
                    xmlstring = xmlstring.Replace("<body>", "");
                    xmlstring = xmlstring.Replace("</body>", "");
                    xmlstring = xmlstring.Replace("\r\n", "");
                    xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    RetValue retvalue = outlineservice.UploadCalibrateData(long.Parse(AHLINEID[LineID]), xmlstring, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("UploadCalibrateData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
            }
        }
        public bool Send_CALIBRATION_GL_RESULT_DATA(string LineID, ah_cal_public_data pmodel, ah_cal_judge_data jdata, List<ah_gl_caldata> model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            if (version == version_V23)
                return true;
            else
            {
                try
                {
                    XmlDocument xmldoc, xlmrecivedoc;
                    XmlNode xmlnode;
                    XmlElement xmlelem;
                    xmldoc = new XmlDocument();
                    xmlelem = xmldoc.CreateElement("", "body", "");
                    xmldoc.AppendChild(xmlelem);
                    XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                    XmlElement DeviceType = xmldoc.CreateElement("Type");//创建一个<Node>节点 
                    XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                    XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                    XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                    DeviceType.InnerText = pmodel.Type;
                    BeginTime.InnerText = pmodel.BeginTime;
                    EndTime.InnerText = pmodel.EndTime;
                    Judge.InnerText = pmodel.Judge;
                    XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                    XmlElement type = xmldoc.CreateElement("type");//创建一个<Node>节点 
                    XmlElement CalibrateCount = xmldoc.CreateElement("CalibrateCount");//创建一个<Node>节点 
                    type.InnerText = jdata.type;
                    CalibrateCount.InnerText = jdata.CalibrateCount;
                    JudgeData.AppendChild(type);
                    JudgeData.AppendChild(CalibrateCount);

                    for (int pointIndex = 1; pointIndex <= model.Count; pointIndex++)
                    {
                        XmlElement Point = xmldoc.CreateElement("Point_" + pointIndex.ToString());//创建一个<Node>节点 

                        XmlElement NominalValue = xmldoc.CreateElement("NominalValue");
                        NominalValue.InnerText = model[pointIndex - 1].NominalValue;
                        XmlElement FromSpeed = xmldoc.CreateElement("FromSpeed");
                        FromSpeed.InnerText = model[pointIndex - 1].FromSpeed;
                        XmlElement ToSpeed = xmldoc.CreateElement("ToSpeed");
                        ToSpeed.InnerText = model[pointIndex - 1].ToSpeed;

                        XmlElement LoadingForce = xmldoc.CreateElement("LoadingForce");
                        XmlElement Count = xmldoc.CreateElement("Count");
                        Count.InnerText = "2";
                        XmlElement Force_1 = xmldoc.CreateElement("Force_1");
                        XmlElement ForceSettingValue1 = xmldoc.CreateElement("ForceSettingValue");
                        XmlElement ActualTime1 = xmldoc.CreateElement("ActualTime");
                        XmlElement ForceRealTime1 = xmldoc.CreateElement("ForceRealTime");
                        ForceSettingValue1.InnerText = model[pointIndex - 1].ForceSettingValue1;
                        ActualTime1.InnerText = model[pointIndex - 1].ActualTime1;
                        ForceRealTime1.InnerText = model[pointIndex - 1].ForceRealTime1;
                        Force_1.AppendChild(ForceSettingValue1);
                        Force_1.AppendChild(ActualTime1);
                        Force_1.AppendChild(ForceRealTime1);
                        XmlElement Force_2 = xmldoc.CreateElement("Force_2");
                        XmlElement ForceSettingValue2 = xmldoc.CreateElement("ForceSettingValue");
                        XmlElement ActualTime2 = xmldoc.CreateElement("ActualTime");
                        XmlElement ForceRealTime2 = xmldoc.CreateElement("ForceRealTime");
                        ForceSettingValue2.InnerText = model[pointIndex - 1].ForceSettingValue2;
                        ActualTime2.InnerText = model[pointIndex - 1].ActualTime2;
                        ForceRealTime2.InnerText = model[pointIndex - 1].ForceRealTime2;
                        Force_2.AppendChild(ForceSettingValue2);
                        Force_2.AppendChild(ActualTime2);
                        Force_2.AppendChild(ForceRealTime2);
                        LoadingForce.AppendChild(Count);
                        LoadingForce.AppendChild(Force_1);
                        LoadingForce.AppendChild(Force_2);

                        XmlElement RealValue = xmldoc.CreateElement("RealValue");
                        RealValue.InnerText = model[pointIndex - 1].RealValue;
                        XmlElement Deviation = xmldoc.CreateElement("Deviation");
                        Deviation.InnerText = model[pointIndex - 1].Deviation;

                        Point.AppendChild(NominalValue);
                        Point.AppendChild(FromSpeed);
                        Point.AppendChild(ToSpeed);
                        Point.AppendChild(LoadingForce);
                        Point.AppendChild(RealValue);
                        Point.AppendChild(Deviation);

                        JudgeData.AppendChild(Point);
                    }
                    root.AppendChild(DeviceType);
                    root.AppendChild(BeginTime);
                    root.AppendChild(EndTime);
                    root.AppendChild(Judge);
                    root.AppendChild(JudgeData);
                    string xmlstring = ConvertXmlToString(xmldoc);
                    xmlstring = xmlstring.Replace("<body>", "");
                    xmlstring = xmlstring.Replace("</body>", "");
                    xmlstring = xmlstring.Replace("\r\n", "");
                    xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    RetValue retvalue = outlineservice.UploadCalibrateData(long.Parse(AHLINEID[LineID]), xmlstring, "");
                    result = retvalue.ErrNum;
                    errMsg = retvalue.ErrMsg;
                    ini.INIIO.saveSocketLogInf("UploadCalibrateData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception er)
                {
                    errMsg = er.Message;
                    return false;
                }
            }
        }

    }
    /*public class Ahinterface_v27
    {
        Service outlineservice = null;
        public Dictionary<string, string> AHLINEID = new Dictionary<string, string>();
        public Ahinterface_v27(string url)
        {
            outlineservice = new Service(url);
        }
        public void initLineId(string lineid)
        {
            string[] lineidary = lineid.Split(',');
            for (int i = 1; i <= lineidary.Count(); i++)
            {
                AHLINEID.Add(i.ToString("00"), lineidary[i - 1]);
            }
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static string ConvertXmlToString(XmlDocument xmlDoc)
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
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"UTF-8\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            //string newstring = xmlString.Replace("<xml version=\"1.0\">", "");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }
        public bool Sync(out int result, out string errMsg, out SyncXml syncxml, out List<string> urllist, out List<string> Messagelist)
        {
            result = 0;
            errMsg = "";
            syncxml = new SyncXml();
            urllist = new List<string>();
            Messagelist = new List<string>();
            try
            {
                RetValue retvalue = outlineservice.Sync("");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("Sync\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    noticeString = "<body>" + noticeString + "</body>";
                    if (noticeString != "")
                    {

                        ds = XmlToData.CXmlToDataSet(noticeString);
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            DataTable dt = ds.Tables[i];
                            urllist.Add(dt.Rows[0]["URL"].ToString());
                            Messagelist.Add(dt.Rows[0]["Message"].ToString());
                        }
                    }
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    //DataTable valuedt = ds.Tables["body"];
                    syncxml.Time = ds.Tables["body"].Rows[0]["Time"].ToString();
                    syncxml.StationID = ds.Tables["body"].Rows[0]["StationID"].ToString();
                    syncxml.ProtocolVersion = ds.Tables["body"].Rows[0]["ProtocolVersion"].ToString();
                    syncxml.ProtocolDate = ds.Tables["body"].Rows[0]["ProtocolDate"].ToString();
                    syncxml.LeadDriverCount = ds.Tables["LeadDriver"].Rows[0]["Count"].ToString();
                    syncxml.OperatorCount = ds.Tables["Operator"].Rows[0]["Count"].ToString();
                    syncxml.leadDriverlist = new List<SyncXml.leadDriver>();
                    syncxml.operatorlist = new List<SyncXml.Operator>();
                    if (int.Parse(syncxml.LeadDriverCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.LeadDriverCount); i++)
                        {
                            if (ds.Tables.Contains("Driver" + i.ToString()))
                            {
                                syncxml.addLeadDriver(ds.Tables["Driver" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Driver" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    if (int.Parse(syncxml.OperatorCount) > 0)
                    {
                        for (int i = 1; i <= int.Parse(syncxml.OperatorCount); i++)
                        {
                            if (ds.Tables.Contains("Operator" + i.ToString()))
                            {
                                syncxml.addOperator(ds.Tables["Operator" + i.ToString()].Rows[0]["Name"].ToString(), ds.Tables["Operator" + i.ToString()].Rows[0]["ID"].ToString());
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByDate(DateTime starttime, DateTime endtime, out int result, out string errMsg, out List<AhCarInfo_V27> ahcarinflist, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo_V27>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByDate(starttime.ToString("yyyy-MM-dd HH:mm:ss"), endtime.ToString("yyyy-MM-dd HH:mm:ss"), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByDate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo_V27 carinfo = new AhCarInfo_V27();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.VIN = ds.Tables["CarInfo"].Rows[i - 1]["VIN"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.EngineModel = ds.Tables["CarInfo"].Rows[i - 1]["EngineModel"].ToString();
                                carinfo.EngineSN = ds.Tables["CarInfo"].Rows[i - 1]["EngineSN"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.VehicleTypeCode = ds.Tables["CarInfo"].Rows[i - 1]["VehicleTypeCode"].ToString();
                                carinfo.IfHGL = ds.Tables["CarInfo"].Rows[i - 1]["IfHGL"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.FuelSupplyID = ds.Tables["CarInfo"].Rows[i - 1]["FuelSupplyID "].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                if (ds.Tables["CarInfo"].Columns.Contains("NominalPower"))
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                else
                                    carinfo.NominalPower = "60";
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                carinfo.EPStage = ds.Tables["CarInfo"].Rows[i - 1]["EPStage"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                model.CLLX = carinfo.VehicleTypeCode;
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLZL = "常规载客"; break;
                                    case "2": model.CLZL = "常规载货"; break;
                                    case "3": model.CLZL = "低速货车"; break;
                                    case "4": model.CLZL = "三轮汽车"; break;
                                    case "5": model.CLZL = "专项作业车"; break;
                                    case "6": model.CLZL = "三轮摩托车"; break;
                                    case "7": model.CLZL = "二轮摩托车"; break;
                                    case "8": model.CLZL = "校车"; break;
                                    case "9": model.CLZL = "其他"; break;
                                    default:
                                        model.CLZL = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = carinfo.BrandName;
                                model.XH = carinfo.ModelName;
                                model.CLSBM = carinfo.VIN;
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = carinfo.EngineSN;

                                model.FDJXH = carinfo.EngineModel;
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                switch (carinfo.FuelSupplyID)
                                {
                                    case "1": model.GYFS = "闭环电喷"; break;
                                    case "2": model.GYFS = "开环电喷"; break;
                                    case "3": model.GYFS = "化油器"; break;
                                    case "4": model.GYFS = "化油器改造"; break;
                                    case "5": model.GYFS = "高压共轨"; break;
                                    case "7": model.GYFS = "泵喷嘴"; break;
                                    case "8": model.GYFS = "单体泵"; break;
                                    case "9": model.GYFS = "直列泵"; break;
                                    case "10": model.GYFS = "机械泵"; break;
                                    case "11": model.GYFS = "其他"; break;
                                    default: break;
                                }
                                model.DPFS = (model.GYFS == "闭环电喷" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = carinfo.Cylinders;

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                //model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";


                                model.CSYS = "";
                                model.ZXBZ = "";
                                switch (carinfo.EPStage)
                                {
                                    case "1": model.ZXBZ = "国I"; break;
                                    case "2": model.ZXBZ = "国II"; break;
                                    case "3": model.ZXBZ = "国III"; break;
                                    case "4": model.ZXBZ = "国IV"; break;
                                    case "5": model.ZXBZ = "国V"; break;
                                    case "6": model.ZXBZ = "国VI"; break;
                                    case "7": model.ZXBZ = "国VII"; break;
                                    case "0": model.ZXBZ = "国0"; break;
                                    default: break;
                                }
                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "LZ";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    case "6":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = carinfo.InspectCount;
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool getInSpectQueueByPlate(string palteID, int plateType, out int result, out string errMsg, out List<AhCarInfo_V27> ahcarinflist, out List<CARATWAIT> caratwaitlist, out List<CARINF> carinflist)
        {
            result = 0;
            errMsg = "";
            ahcarinflist = new List<AhCarInfo_V27>();
            carinflist = new List<CARINF>();
            caratwaitlist = new List<CARATWAIT>();
            try
            {
                RetValue retvalue = outlineservice.GetInspectQueueByPlateID(palteID, plateType, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("GetInspectQueueByPlateID\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    string noticeString = retvalue.TipMessage;
                    string xmlstring = retvalue.Value;
                    DataSet ds = new DataSet();
                    xmlstring = "<body>" + xmlstring + "</body>";
                    ds = XmlToData.CXmlToDataSet(xmlstring);
                    int carCount = int.Parse(ds.Tables["body"].Rows[0]["Count"].ToString());
                    if (carCount > 0)
                    {
                        for (int i = 1; i <= carCount; i++)
                        {
                            if (ds.Tables.Contains("Inspect_" + i.ToString()))
                            {
                                AhCarInfo_V27 carinfo = new AhCarInfo_V27();
                                carinfo.InspectID = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectID"].ToString();
                                carinfo.InspectMethod = ds.Tables["Inspect_" + i.ToString()].Rows[0]["InspectMethod"].ToString();
                                carinfo.VIN = ds.Tables["CarInfo"].Rows[i - 1]["VIN"].ToString();
                                carinfo.PlateID = ds.Tables["CarInfo"].Rows[i - 1]["PlateID"].ToString();
                                carinfo.PlateType = ds.Tables["CarInfo"].Rows[i - 1]["PlateType"].ToString();
                                carinfo.BrandName = ds.Tables["CarInfo"].Rows[i - 1]["BrandName"].ToString();
                                carinfo.ModelName = ds.Tables["CarInfo"].Rows[i - 1]["ModelName"].ToString();
                                carinfo.EngineModel = ds.Tables["CarInfo"].Rows[i - 1]["EngineModel"].ToString();
                                carinfo.EngineSN = ds.Tables["CarInfo"].Rows[i - 1]["EngineSN"].ToString();
                                carinfo.CarType = ds.Tables["CarInfo"].Rows[i - 1]["CarType"].ToString();
                                carinfo.VehicleTypeCode = ds.Tables["CarInfo"].Rows[i - 1]["VehicleTypeCode"].ToString();
                                carinfo.IfHGL = ds.Tables["CarInfo"].Rows[i - 1]["IfHGL"].ToString();
                                carinfo.IfGoIntoCity = "";
                                carinfo.IsTurbo = ds.Tables["CarInfo"].Rows[i - 1]["IsTurbo"].ToString();
                                carinfo.FuelType = ds.Tables["CarInfo"].Rows[i - 1]["FuelType"].ToString();
                                carinfo.FuelSupplyID = ds.Tables["CarInfo"].Rows[i - 1]["FuelSupplyID "].ToString();
                                carinfo.Is3WCC = ds.Tables["CarInfo"].Rows[i - 1]["Is3WCC"].ToString();
                                carinfo.RatedSpeed = ds.Tables["CarInfo"].Rows[i - 1]["RatedSpeed"].ToString();
                                carinfo.DeliveryCapacity = ds.Tables["CarInfo"].Rows[i - 1]["DeliveryCapacity"].ToString();
                                carinfo.Cylinders = ds.Tables["CarInfo"].Rows[i - 1]["Cylinders"].ToString();
                                carinfo.StrokeCycles = "";
                                if (ds.Tables["CarInfo"].Columns.Contains("NominalPower"))
                                    carinfo.NominalPower = ds.Tables["CarInfo"].Rows[i - 1]["NominalPower"].ToString();
                                else
                                    carinfo.NominalPower = "60";
                                carinfo.FactoryDate = ds.Tables["CarInfo"].Rows[i - 1]["FactoryDate"].ToString();
                                carinfo.BaseWeight = ds.Tables["CarInfo"].Rows[i - 1]["BaseWeight"].ToString();
                                carinfo.WholeWeight = ds.Tables["CarInfo"].Rows[i - 1]["WholeWeight"].ToString();
                                carinfo.RegDate = ds.Tables["CarInfo"].Rows[i - 1]["RegDate"].ToString();
                                carinfo.PassengerCount = ds.Tables["CarInfo"].Rows[i - 1]["PassengerCount"].ToString();
                                carinfo.GearType = ds.Tables["CarInfo"].Rows[i - 1]["GearType"].ToString();
                                carinfo.InspectCount = ds.Tables["CarInfo"].Rows[i - 1]["InspectCount"].ToString();
                                carinfo.DriveType = ds.Tables["CarInfo"].Rows[i - 1]["DriveType"].ToString();
                                carinfo.EPStage = ds.Tables["CarInfo"].Rows[i - 1]["EPStage"].ToString();
                                CARINF model = new CARINF();
                                CARATWAIT waitmodel = new CARATWAIT();
                                model.CLHP = carinfo.PlateID;
                                model.HPZL = carinfo.PlateType;
                                model.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                model.CLLX = carinfo.VehicleTypeCode;
                                switch (carinfo.CarType)
                                {
                                    case "1": model.CLZL = "常规载客"; break;
                                    case "2": model.CLZL = "常规载货"; break;
                                    case "3": model.CLZL = "低速货车"; break;
                                    case "4": model.CLZL = "三轮汽车"; break;
                                    case "5": model.CLZL = "专项作业车"; break;
                                    case "6": model.CLZL = "三轮摩托车"; break;
                                    case "7": model.CLZL = "二轮摩托车"; break;
                                    case "8": model.CLZL = "校车"; break;
                                    case "9": model.CLZL = "其他"; break;
                                    default:
                                        model.CLZL = ""; break;
                                }
                                model.CZ = "";
                                model.SYXZ = "";
                                model.PP = carinfo.BrandName;
                                model.XH = carinfo.ModelName;
                                model.CLSBM = carinfo.VIN;
                                //model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                                model.FDJHM = carinfo.EngineSN;

                                model.FDJXH = carinfo.EngineModel;
                                model.SCQY = "";
                                model.HDZK = carinfo.PassengerCount;

                                model.JSSZK = "0";
                                model.ZZL = carinfo.WholeWeight;
                                model.HDZZL = "0";
                                model.ZBZL = (int.Parse(carinfo.BaseWeight) - 100).ToString();
                                model.JZZL = carinfo.BaseWeight;
                                model.ZCRQ = DateTime.Parse(carinfo.RegDate);
                                model.SCRQ = DateTime.Parse(carinfo.FactoryDate);

                                model.FDJPL = carinfo.DeliveryCapacity;
                                model.RLZL = "";
                                switch (carinfo.FuelType)
                                {
                                    case "1": model.RLZL = "汽油"; break;
                                    case "2": model.RLZL = "柴油"; break;
                                    case "3": model.RLZL = "天燃气"; break;
                                    case "4": model.RLZL = "液化石油气"; break;
                                    case "5": model.RLZL = "甲醇"; break;
                                    case "6": model.RLZL = "乙醇"; break;
                                    default: break;
                                }
                                model.EDGL = carinfo.NominalPower;
                                model.EDZS = "";
                                model.BSQXS = "";
                                switch (carinfo.GearType)
                                {
                                    case "1": model.BSQXS = "手动档"; break;
                                    case "2": model.BSQXS = "自动档"; break;
                                    case "3": model.BSQXS = "手自一体"; break;
                                    default: break;
                                }
                                model.DWS = "5";
                                //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                                model.GYFS = "";
                                switch (carinfo.FuelSupplyID)
                                {
                                    case "1": model.GYFS = "闭环电喷"; break;
                                    case "2": model.GYFS = "开环电喷"; break;
                                    case "3": model.GYFS = "化油器"; break;
                                    case "4": model.GYFS = "化油器改造"; break;
                                    case "5": model.GYFS = "高压共轨"; break;
                                    case "7": model.GYFS = "泵喷嘴"; break;
                                    case "8": model.GYFS = "单体泵"; break;
                                    case "9": model.GYFS = "直列泵"; break;
                                    case "10": model.GYFS = "机械泵"; break;
                                    case "11": model.GYFS = "其他"; break;
                                    default: break;
                                }
                                model.DPFS = (model.GYFS == "闭环电喷" ? "闭环电喷" : "开环电喷");

                                model.JQFS = (carinfo.IsTurbo == "true" ? "涡轮增压" : "自然进气");
                                model.QGS = carinfo.Cylinders;

                                model.QDXS = "";
                                switch (carinfo.DriveType)
                                {
                                    case "1": model.QDXS = "前驱"; break;
                                    case "2": model.QDXS = "后驱"; break;
                                    case "3": model.QDXS = "分时四驱"; break;
                                    case "4": model.QDXS = "全时四驱"; break;
                                    default: break;
                                }
                                model.CHZZ = "";
                                model.DLSP = "";
                                model.SFSRL = "";
                                model.JHZZ = (carinfo.Is3WCC == "true" ? "使用" : "未使用");
                                model.OBD = "";
                                model.DKGYYB = "";
                                model.LXDH = "";
                                //model.CLZL = "";
                                model.CZDZ = "";

                                model.JCFS = "";
                                model.JCLB = "";
                                model.SSXQ = "";
                                model.FDJSCQY = "";
                                model.QDLTQY = "";
                                model.RYPH = "";
                                model.SFWDZR = "";
                                model.SFYQBF = "";


                                model.CSYS = "";
                                model.ZXBZ = "";
                                switch (carinfo.EPStage)
                                {
                                    case "1": model.ZXBZ = "国I"; break;
                                    case "2": model.ZXBZ = "国II"; break;
                                    case "3": model.ZXBZ = "国III"; break;
                                    case "4": model.ZXBZ = "国IV"; break;
                                    case "5": model.ZXBZ = "国V"; break;
                                    case "6": model.ZXBZ = "国VI"; break;
                                    case "7": model.ZXBZ = "国VII"; break;
                                    case "0": model.ZXBZ = "国0"; break;
                                    default: break;
                                }
                                waitmodel.CLID = carinfo.InspectID;
                                waitmodel.CLHP = carinfo.PlateID;
                                waitmodel.DLSJ = DateTime.Now;
                                waitmodel.CPYS = "";
                                switch (carinfo.PlateType)
                                {
                                    case "1": model.CPYS = "蓝牌"; break;
                                    case "2": model.CPYS = "黄牌"; break;
                                    case "3": model.CPYS = "白牌"; break;
                                    case "4": model.CPYS = "黑牌"; break;
                                    case "5": model.CPYS = "绿牌"; break;
                                    case "6": model.CPYS = "小黄牌"; break;
                                    default:
                                        model.CPYS = ""; break;
                                }
                                switch (carinfo.InspectMethod)
                                {
                                    case "4":
                                        waitmodel.JCFF = "ZYJS";
                                        break;
                                    case "1":
                                        waitmodel.JCFF = "VMAS";
                                        break;
                                    case "5":
                                        waitmodel.JCFF = "JZJS";
                                        break;
                                    case "3":
                                        waitmodel.JCFF = "LZ";
                                        break;
                                    case "2":
                                        waitmodel.JCFF = "SDS";
                                        break;
                                    case "6":
                                        waitmodel.JCFF = "ASM";
                                        break;
                                    default: waitmodel.JCFF = ""; break;
                                }
                                waitmodel.XSLC = "";
                                waitmodel.JCCS = carinfo.InspectCount;
                                waitmodel.CZY = "";
                                waitmodel.JSY = "";
                                waitmodel.DLY = "";
                                waitmodel.JCFY = "";
                                waitmodel.TEST = "";
                                //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                                waitmodel.JCBGBH = "";
                                waitmodel.JCGWH = "";
                                waitmodel.JCZBH = "";
                                waitmodel.JCRQ = DateTime.Now;
                                waitmodel.BGJCFFYY = "";
                                waitmodel.SFCS = "";
                                waitmodel.ECRYPT = "";
                                waitmodel.SFCJ = "初检";
                                waitmodel.JYLSH = "";
                                waitmodel.HPZL = carinfo.PlateType;
                                carinflist.Add(model);
                                caratwaitlist.Add(waitmodel);
                                ahcarinflist.Add(carinfo);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginRecord(string lineID, string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginRecord(long.Parse(AHLINEID[lineID]), InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginInspect(string lineID, string InspectID, string DirverID, string OperatorID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginInspect(long.Parse(AHLINEID[lineID]), InspectID, long.Parse(DirverID), long.Parse(OperatorID), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool TakePhoto(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.TakePhoto(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("TakePhoto\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadVmasRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("VMASCount");
                        xe1.InnerText = "195";
                        root.AppendChild(xe1);
                        if (dtseconds != null)
                        {
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("VMAS" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                xe36.InnerText = dr["实时车速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("RPM");
                                xe37.InnerText = dr["发动机转速"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("HC");
                                xe38.InnerText = dr["HC实时值"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("CO");
                                xe39.InnerText = dr["CO实时值"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("NO");
                                xe40.InnerText = dr["NO实时值"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("O2");
                                xe41.InnerText = dr["分析仪O2实时值"].ToString();
                                XmlElement xe42 = xmldoc.CreateElement("CO2");
                                xe42.InnerText = dr["CO2实时值"].ToString();
                                XmlElement xe43 = xmldoc.CreateElement("O2_Flow");
                                xe43.InnerText = dr["流量计O2实时值"].ToString();
                                XmlElement xe44 = xmldoc.CreateElement("Flow_Act");
                                xe44.InnerText = dr["实际体积流量"].ToString();
                                XmlElement xe45 = xmldoc.CreateElement("Flow_Std");
                                xe45.InnerText = dr["标准体积流量"].ToString();
                                XmlElement xe46 = xmldoc.CreateElement("Flow_Ex");
                                xe46.InnerText = dr["尾气实际排放流量"].ToString();
                                XmlElement xe47 = xmldoc.CreateElement("HCMass");
                                xe47.InnerText = dr["HC排放质量"].ToString();
                                XmlElement xe48 = xmldoc.CreateElement("COMass");
                                xe48.InnerText = dr["CO排放质量"].ToString();
                                XmlElement xe49 = xmldoc.CreateElement("NOMass");
                                xe49.InnerText = dr["NO排放质量"].ToString();
                                XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                xe50.InnerText = dr["加载功率"].ToString();
                                XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                xe51.InnerText = dr["环境温度"].ToString();
                                XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                xe52.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe53 = xmldoc.CreateElement("Baro");
                                xe53.InnerText = dr["大气压力"].ToString();
                                XmlElement xe54 = xmldoc.CreateElement("Press_Flow");
                                xe54.InnerText = dr["流量计压力"].ToString();
                                XmlElement xe55 = xmldoc.CreateElement("Temperature_Flow");
                                xe55.InnerText = dr["流量计温度"].ToString();
                                XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                xe56.InnerText = dr["湿度修正系数"].ToString();
                                XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                xe57.InnerText = dr["稀释修正系数"].ToString();
                                XmlElement xe58 = xmldoc.CreateElement("DilutionRate");
                                xe58.InnerText = dr["稀释比"].ToString();
                                XmlElement xe59 = xmldoc.CreateElement("OilTemperature");
                                xe59.InnerText = dr["环境温度"].ToString();
                                XmlElement xe60 = xmldoc.CreateElement("O2_Env");
                                xe60.InnerText = dr["环境O2浓度"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                xe33.AppendChild(xe42);
                                xe33.AppendChild(xe43);
                                xe33.AppendChild(xe44);
                                xe33.AppendChild(xe45);
                                xe33.AppendChild(xe46);
                                xe33.AppendChild(xe47);
                                xe33.AppendChild(xe48);
                                xe33.AppendChild(xe49);
                                xe33.AppendChild(xe50);
                                xe33.AppendChild(xe51);
                                xe33.AppendChild(xe52);
                                xe33.AppendChild(xe53);
                                xe33.AppendChild(xe54);
                                xe33.AppendChild(xe55);
                                xe33.AppendChild(xe56);
                                xe33.AppendChild(xe57);
                                xe33.AppendChild(xe58);
                                xe33.AppendChild(xe59);
                                xe33.AppendChild(xe60);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadAsmRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 
                        XmlElement xe1 = xmldoc.CreateElement("ASM5025_Count");
                        xe1.InnerText = "90";

                        XmlElement xe2 = xmldoc.CreateElement("ASM2540_Count");
                        xe2.InnerText = "90";
                        root.AppendChild(xe1);
                        root.AppendChild(xe2);
                        int asm5025count = 0;
                        int asm2540count = 0;
                        if (dtseconds != null)
                        {
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                DataRow dr = dtseconds.Rows[i];
                                if (dr["时序类别"].ToString() == "1")
                                {
                                    asm5025count++;
                                    XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + asm5025count.ToString("000"));//创建一个<Node>节点 
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement DataType = xmldoc.CreateElement("DataType");
                                    DataType.InnerText ="1";//v2.7
                                    XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                    Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                    XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                    DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = asm5025count.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                    xe36.InnerText = dr["实时车速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("RPM");
                                    xe37.InnerText = dr["转速"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("HC");
                                    xe38.InnerText = dr["HC实时值"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO");
                                    xe39.InnerText = dr["CO实时值"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("NO");
                                    xe40.InnerText = dr["NO实时值"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("O2");
                                    xe41.InnerText = dr["O2实时值"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("CO2");
                                    xe42.InnerText = dr["CO2实时值"].ToString();
                                    XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                    xe50.InnerText = dr["加载功率"].ToString();
                                    XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                    WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                    XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                    IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                    XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                    OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                    XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                    xe51.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                    xe52.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe53 = xmldoc.CreateElement("Baro");
                                    xe53.InnerText = dr["大气压力"].ToString();
                                    XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                    xe56.InnerText = dr["湿度修正系数"].ToString();
                                    XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                    xe57.InnerText = dr["稀释修正系数"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);
                                    xe33.AppendChild(xe50);
                                    xe33.AppendChild(xe51);
                                    xe33.AppendChild(xe52);
                                    xe33.AppendChild(xe53);
                                    xe33.AppendChild(xe56);
                                    xe33.AppendChild(xe57);
                                    xe33.AppendChild(DataType);
                                    xe33.AppendChild(Torsion);
                                    xe33.AppendChild(DymoLoad);
                                    xe33.AppendChild(WattlessOutput);
                                    xe33.AppendChild(IndicatedPower);
                                    xe33.AppendChild(OilTemperature);
                                    root.AppendChild(xe33);
                                }
                                else if (dr["时序类别"].ToString() == "2")
                                {
                                    asm2540count++;
                                    XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + asm2540count.ToString("000"));//创建一个<Node>节点 
                                    XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                    xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    XmlElement DataType = xmldoc.CreateElement("DataType");
                                    DataType.InnerText = "2";//2.7
                                    XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                    Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                    XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                    DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                    XmlElement xe35 = xmldoc.CreateElement("Time");
                                    xe35.InnerText = asm2540count.ToString();
                                    XmlElement xe36 = xmldoc.CreateElement("CarSpeed");
                                    xe36.InnerText = dr["实时车速"].ToString();
                                    XmlElement xe37 = xmldoc.CreateElement("RPM");
                                    xe37.InnerText = dr["转速"].ToString();
                                    XmlElement xe38 = xmldoc.CreateElement("HC");
                                    xe38.InnerText = dr["HC实时值"].ToString();
                                    XmlElement xe39 = xmldoc.CreateElement("CO");
                                    xe39.InnerText = dr["CO实时值"].ToString();
                                    XmlElement xe40 = xmldoc.CreateElement("NO");
                                    xe40.InnerText = dr["NO实时值"].ToString();
                                    XmlElement xe41 = xmldoc.CreateElement("O2");
                                    xe41.InnerText = dr["O2实时值"].ToString();
                                    XmlElement xe42 = xmldoc.CreateElement("CO2");
                                    xe42.InnerText = dr["CO2实时值"].ToString();
                                    XmlElement xe50 = xmldoc.CreateElement("LoadPower");
                                    xe50.InnerText = dr["加载功率"].ToString();
                                    XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                    WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                    XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                    IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                    XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                    OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                    XmlElement xe51 = xmldoc.CreateElement("Temperature");
                                    xe51.InnerText = dr["环境温度"].ToString();
                                    XmlElement xe52 = xmldoc.CreateElement("Humidity");
                                    xe52.InnerText = dr["相对湿度"].ToString();
                                    XmlElement xe53 = xmldoc.CreateElement("Baro");
                                    xe53.InnerText = dr["大气压力"].ToString();
                                    XmlElement xe56 = xmldoc.CreateElement("Humidity_Modify");
                                    xe56.InnerText = dr["湿度修正系数"].ToString();
                                    XmlElement xe57 = xmldoc.CreateElement("Dilution_Modify");
                                    xe57.InnerText = dr["稀释修正系数"].ToString();
                                    xe33.AppendChild(xe34);
                                    xe33.AppendChild(xe35);
                                    xe33.AppendChild(xe36);
                                    xe33.AppendChild(xe37);
                                    xe33.AppendChild(xe38);
                                    xe33.AppendChild(xe39);
                                    xe33.AppendChild(xe40);
                                    xe33.AppendChild(xe41);
                                    xe33.AppendChild(xe42);
                                    xe33.AppendChild(xe50);
                                    xe33.AppendChild(xe51);
                                    xe33.AppendChild(xe52);
                                    xe33.AppendChild(xe53);
                                    xe33.AppendChild(xe56);
                                    xe33.AppendChild(xe57);
                                    xe33.AppendChild(DataType);
                                    xe33.AppendChild(Torsion);
                                    xe33.AppendChild(DymoLoad);
                                    xe33.AppendChild(WattlessOutput);
                                    xe33.AppendChild(IndicatedPower);
                                    xe33.AppendChild(OilTemperature);
                                    root.AppendChild(xe33);
                                }
                            }
                            for (int i = asm5025count + 1; i <= 90; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("ASM5025_" + i.ToString("000"));
                                root.AppendChild(xe33);
                            }
                            for (int i = asm2540count + 1; i <= 90; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("ASM2540_" + i.ToString("000"));
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadLugdownRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("LugDown_Count");
                            xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("LugDown" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement DataType = xmldoc.CreateElement("DataType");
                                DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["转速"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("CarSpeed");
                                xe38.InnerText = dr["车速"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("YD");
                                xe39.InnerText = dr["光吸收系数K"].ToString();
                                XmlElement K = xmldoc.CreateElement("K");
                                K.InnerText = dr["光吸收系数K"].ToString();
                                XmlElement WattlessOutput = xmldoc.CreateElement("WattlessOutput");
                                WattlessOutput.InnerText = dr["寄生功率"].ToString();//v2.7
                                XmlElement IndicatedPower = xmldoc.CreateElement("IndicatedPower");
                                IndicatedPower.InnerText = dr["指示功率"].ToString();//v2.7
                                XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                OilTemperature.InnerText = dr["油温"].ToString();//v2.7
                                XmlElement Power_Modify = xmldoc.CreateElement("Power_Modify");
                                Power_Modify.InnerText = dr["DCF"].ToString();//v2.7
                                XmlElement xe40 = xmldoc.CreateElement("Temperature");
                                xe40.InnerText = dr["环境温度"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("Humidity");
                                xe41.InnerText = dr["相对湿度"].ToString();
                                XmlElement xe42 = xmldoc.CreateElement("Baro");
                                xe42.InnerText = dr["大气压力"].ToString();
                                XmlElement Torsion = xmldoc.CreateElement("Torsion");
                                Torsion.InnerText = dr["扭力"].ToString();//v2.7
                                XmlElement DymoLoad = xmldoc.CreateElement("DymoLoad");
                                DymoLoad.InnerText = dr["加载功率"].ToString();//v2.7
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                //xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);
                                xe33.AppendChild(xe42);

                                xe33.AppendChild(DataType);
                                xe33.AppendChild(K);
                                xe33.AppendChild(WattlessOutput);
                                xe33.AppendChild(IndicatedPower);
                                xe33.AppendChild(OilTemperature);
                                xe33.AppendChild(Power_Modify);
                                xe33.AppendChild(Torsion);
                                xe33.AppendChild(DymoLoad);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadSdsRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("GSICount");
                            xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("GSI" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement DataType = xmldoc.CreateElement("DataType");
                                DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = i.ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["转速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("HC");
                                xe37.InnerText = dr["HC"].ToString();
                                XmlElement xe38 = xmldoc.CreateElement("CO");
                                xe38.InnerText = dr["CO"].ToString();
                                XmlElement xe39 = xmldoc.CreateElement("CO2");
                                xe39.InnerText = dr["CO2"].ToString();
                                XmlElement O2 = xmldoc.CreateElement("O2");
                                O2.InnerText = dr["O2"].ToString();
                                XmlElement NO = xmldoc.CreateElement("NO");
                                NO.InnerText = dr["NO"].ToString();
                                XmlElement xe40 = xmldoc.CreateElement("LMD");
                                xe40.InnerText = dr["过量空气系数"].ToString();
                                XmlElement xe41 = xmldoc.CreateElement("OilTemperature");
                                xe41.InnerText = dr["油温"].ToString();
                                XmlElement Temperature = xmldoc.CreateElement("Temperature");
                                Temperature.InnerText = dr["环境温度"].ToString();
                                XmlElement Humidity = xmldoc.CreateElement("Humidity");
                                Humidity.InnerText = dr["相对湿度"].ToString();
                                XmlElement Baro = xmldoc.CreateElement("Baro");
                                Baro.InnerText = dr["大气压力"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(xe38);
                                xe33.AppendChild(xe39);
                                xe33.AppendChild(xe40);
                                xe33.AppendChild(xe41);

                                xe33.AppendChild(DataType);
                                xe33.AppendChild(O2);
                                xe33.AppendChild(NO);
                                xe33.AppendChild(Temperature);
                                xe33.AppendChild(Humidity);
                                xe33.AppendChild(Baro);

                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool UploadBtgRealtimeData(string InspectID, DataTable dtseconds, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            string xmlstring = "";
            try
            {
                if (dtseconds != null)
                {
                    if (dtseconds.Rows.Count > 0)
                    {
                        XmlDocument xmldoc, xlmrecivedoc;
                        XmlNode xmlnode;
                        XmlElement xmlelem;
                        DataTable dt = null;
                        xmldoc = new XmlDocument();
                        xmlelem = xmldoc.CreateElement("", "body", "");
                        xmldoc.AppendChild(xmlelem);
                        XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                        if (dtseconds != null)
                        {
                            XmlElement xe1 = xmldoc.CreateElement("FACount");
                            xe1.InnerText = (dtseconds.Rows.Count - 1).ToString();
                            root.AppendChild(xe1);
                            for (int i = 1; i < dtseconds.Rows.Count; i++)
                            {
                                XmlElement xe33 = xmldoc.CreateElement("FA" + i.ToString("000"));//创建一个<Node>节点 
                                DataRow dr = dtseconds.Rows[i];
                                XmlElement xe34 = xmldoc.CreateElement("TimeStamp");
                                xe34.InnerText = DateTime.Parse(dr["全程时序"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                XmlElement DataType = xmldoc.CreateElement("DataType");
                                DataType.InnerText = dr["时序类别"].ToString();//v2.7
                                XmlElement xe35 = xmldoc.CreateElement("Time");
                                xe35.InnerText = dr["采样时序"].ToString();
                                XmlElement xe36 = xmldoc.CreateElement("RPM");
                                xe36.InnerText = dr["发动机转速"].ToString();
                                XmlElement xe37 = xmldoc.CreateElement("YD");
                                xe37.InnerText = dr["烟度值读数"].ToString();
                                XmlElement OilTemperature = xmldoc.CreateElement("OilTemperature");
                                OilTemperature.InnerText = dr["油温"].ToString();
                                xe33.AppendChild(xe34);
                                xe33.AppendChild(xe35);
                                xe33.AppendChild(xe36);
                                xe33.AppendChild(xe37);
                                xe33.AppendChild(DataType);
                                xe33.AppendChild(OilTemperature);
                                root.AppendChild(xe33);
                            }
                        }
                        xmlstring = ConvertXmlToString(xmldoc);
                        xmlstring = xmlstring.Replace("<body>", "");
                        xmlstring = xmlstring.Replace("</body>", "");
                        xmlstring = xmlstring.Replace("\r\n", "");
                        xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                    }
                    else
                    {
                        errMsg = "dtseconds has no rows";
                        return false;
                    }
                }
                else
                {
                    errMsg = "dtseconds is null";
                    return false;
                }
                RetValue retvalue = outlineservice.UploadRealtimeData(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadRealtimeData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectASM(string InspectID, AhAsmResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("5025HC");
                    xe8.InnerText = inspectResult.HC5025;
                    XmlElement xe9 = xmldoc.CreateElement("5025CO");
                    xe9.InnerText = inspectResult.CO5025;
                    XmlElement xe10 = xmldoc.CreateElement("5025NO");
                    xe10.InnerText = inspectResult.NO5025;
                    XmlElement xe11 = xmldoc.CreateElement("2540HC");
                    xe11.InnerText = inspectResult.HC2540;
                    XmlElement xe12 = xmldoc.CreateElement("2540CO");
                    xe12.InnerText = inspectResult.CO2540;
                    XmlElement xe13 = xmldoc.CreateElement("2540NO");
                    xe13.InnerText = inspectResult.NO2540;
                    XmlElement xe14 = xmldoc.CreateElement("5025HCLimit");
                    xe14.InnerText = inspectResult.HC5025Limit;
                    XmlElement xe15 = xmldoc.CreateElement("5025COLimit");
                    xe15.InnerText = inspectResult.CO5025Limit;
                    XmlElement xe16 = xmldoc.CreateElement("5025NOLimit");
                    xe16.InnerText = inspectResult.NO5025Limit;
                    XmlElement xe17 = xmldoc.CreateElement("2540HCLimit");
                    xe17.InnerText = inspectResult.HC2540Limit;
                    XmlElement xe18 = xmldoc.CreateElement("2540COLimit");
                    xe18.InnerText = inspectResult.CO2540Limit;
                    XmlElement xe19 = xmldoc.CreateElement("2540NOLimit");
                    xe19.InnerText = inspectResult.NO2540Limit;

                    XmlElement HC5025Result = xmldoc.CreateElement("HC5025Result");
                    HC5025Result.InnerText = inspectResult.HC5025Result;
                    XmlElement CO5025Result = xmldoc.CreateElement("CO5025Result");
                    CO5025Result.InnerText = inspectResult.CO5025Result;
                    XmlElement NO5025Result = xmldoc.CreateElement("NO5025Result");
                    NO5025Result.InnerText = inspectResult.NO5025Result;
                    XmlElement HC2540Result = xmldoc.CreateElement("HC2540Result");
                    HC2540Result.InnerText = inspectResult.HC25405Result;
                    XmlElement CO2540Result = xmldoc.CreateElement("CO2540Result");
                    CO2540Result.InnerText = inspectResult.CO2540Result;
                    XmlElement NO2540Result = xmldoc.CreateElement("NO2540Result");
                    NO2540Result.InnerText = inspectResult.NO2540Result;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);
                    root.AppendChild(xe15);
                    root.AppendChild(xe16);
                    root.AppendChild(xe17);
                    root.AppendChild(xe18);
                    root.AppendChild(xe19);

                    root.AppendChild(HC5025Result);
                    root.AppendChild(CO5025Result);
                    root.AppendChild(NO5025Result);
                    root.AppendChild(HC2540Result);
                    root.AppendChild(CO2540Result);
                    root.AppendChild(NO2540Result);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectSDS(string InspectID, AhSdsResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("LowRPM");
                    xe8.InnerText = inspectResult.LowRPM;
                    XmlElement xe9 = xmldoc.CreateElement("LowCO");
                    xe9.InnerText = inspectResult.LowCO;
                    XmlElement xe10 = xmldoc.CreateElement("LowCO2");
                    xe10.InnerText = inspectResult.LowCO2;
                    XmlElement xe11 = xmldoc.CreateElement("LowHC");
                    xe11.InnerText = inspectResult.LowHC;
                    XmlElement xe12 = xmldoc.CreateElement("HiRPM");
                    xe12.InnerText = inspectResult.HiRPM;
                    XmlElement xe13 = xmldoc.CreateElement("HiCO");
                    xe13.InnerText = inspectResult.HiCO;
                    XmlElement xe14 = xmldoc.CreateElement("HiCO2");
                    xe14.InnerText = inspectResult.HiCO2;
                    XmlElement xe15 = xmldoc.CreateElement("HiHC");
                    xe15.InnerText = inspectResult.HiHC;
                    XmlElement xe16 = xmldoc.CreateElement("LMD");
                    xe16.InnerText = inspectResult.LMD;
                    XmlElement xe17 = xmldoc.CreateElement("LowCOLimit");
                    xe17.InnerText = inspectResult.LowCOLimit;
                    XmlElement xe18 = xmldoc.CreateElement("LowHCLimit");
                    xe18.InnerText = inspectResult.LowHCLimit;
                    XmlElement xe19 = xmldoc.CreateElement("HiCOLimit");
                    xe19.InnerText = inspectResult.HiCOLimit;
                    XmlElement xe20 = xmldoc.CreateElement("HiHCLimit");
                    xe20.InnerText = inspectResult.HiHCLimit;
                    XmlElement xe21 = xmldoc.CreateElement("LMDLimitMin");
                    xe21.InnerText = inspectResult.LMDLimitMin;
                    XmlElement xe22 = xmldoc.CreateElement("LMDLimitMax");
                    xe22.InnerText = inspectResult.LMDLimitMax;

                    XmlElement HiCOResult = xmldoc.CreateElement("HiCOResult");
                    HiCOResult.InnerText = inspectResult.HiCOResult;
                    XmlElement HiHCResult = xmldoc.CreateElement("HiHCResult");
                    HiHCResult.InnerText = inspectResult.HiHCResult;
                    XmlElement LowCOResult = xmldoc.CreateElement("LowCOResult");
                    LowCOResult.InnerText = inspectResult.LowCOResult;
                    XmlElement LowHCResult = xmldoc.CreateElement("LowHCResult");
                    LowHCResult.InnerText = inspectResult.LowHCResult;
                    XmlElement LMDResult = xmldoc.CreateElement("LMDResult");
                    LMDResult.InnerText = inspectResult.LMDResult;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);
                    root.AppendChild(xe15);
                    root.AppendChild(xe16);
                    root.AppendChild(xe17);
                    root.AppendChild(xe18);
                    root.AppendChild(xe19);
                    root.AppendChild(xe20);
                    root.AppendChild(xe21);
                    root.AppendChild(xe22);
                    root.AppendChild(HiCOResult);
                    root.AppendChild(HiHCResult);
                    root.AppendChild(LowCOResult);
                    root.AppendChild(LowHCResult);
                    root.AppendChild(LMDResult);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectLugdown(string InspectID, AhLugdownResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("CrucialTime1");
                    xe6.InnerText = inspectResult.CrucialTime1;
                    XmlElement xe7 = xmldoc.CreateElement("CrucialTime2");
                    xe7.InnerText = inspectResult.CrucialTime2;
                    XmlElement xe8 = xmldoc.CreateElement("CrucialTime3");
                    xe8.InnerText = inspectResult.CrucialTime3;
                    XmlElement xe9 = xmldoc.CreateElement("YD1");
                    xe9.InnerText = inspectResult.YD1;
                    XmlElement xe10 = xmldoc.CreateElement("YD2");
                    xe10.InnerText = inspectResult.YD2;
                    XmlElement xe11 = xmldoc.CreateElement("YD3");
                    xe11.InnerText = inspectResult.YD3;
                    XmlElement xe12 = xmldoc.CreateElement("Power");
                    xe12.InnerText = inspectResult.Power;
                    XmlElement xe13 = xmldoc.CreateElement("YDLimit");
                    xe13.InnerText = inspectResult.YDLimit;
                    XmlElement xe14 = xmldoc.CreateElement("PowerLimit");
                    xe14.InnerText = inspectResult.PowerLimit;

                    XmlElement RateSpeedUp = xmldoc.CreateElement("RateSpeedUp");
                    RateSpeedUp.InnerText = inspectResult.RateSpeedUp;
                    XmlElement RateSpeedDown = xmldoc.CreateElement("RateSpeedDown");
                    RateSpeedDown.InnerText = inspectResult.RateSpeedDown;
                    XmlElement RealRateSpeed = xmldoc.CreateElement("RealRateSpeed");
                    RealRateSpeed.InnerText = inspectResult.RealRateSpeed;
                    XmlElement YDResult = xmldoc.CreateElement("YDResult");
                    YDResult.InnerText = inspectResult.YDResult;
                    XmlElement PowerResult = xmldoc.CreateElement("PowerResult");
                    PowerResult.InnerText = inspectResult.PowerResult;

                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(xe12);
                    root.AppendChild(xe13);
                    root.AppendChild(xe14);

                    root.AppendChild(RateSpeedUp);
                    root.AppendChild(RateSpeedDown);
                    root.AppendChild(RealRateSpeed);
                    root.AppendChild(YDResult);
                    root.AppendChild(PowerResult);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndInspectBtg(string InspectID, AhBtgResult inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (inspectResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("Result");
                    xe1.InnerText = inspectResult.Result;
                    XmlElement xe2 = xmldoc.CreateElement("CrucialTime0");
                    xe2.InnerText = inspectResult.Result;
                    XmlElement xe3 = xmldoc.CreateElement("Temperature");
                    xe3.InnerText = inspectResult.Temperature;
                    XmlElement xe4 = xmldoc.CreateElement("Humidity");
                    xe4.InnerText = inspectResult.Humidity;
                    XmlElement xe5 = xmldoc.CreateElement("Baro");
                    xe5.InnerText = inspectResult.Baro;
                    XmlElement xe6 = xmldoc.CreateElement("YD0");
                    xe6.InnerText = inspectResult.YD0;
                    XmlElement xe7 = xmldoc.CreateElement("YD1");
                    xe7.InnerText = inspectResult.YD1;
                    XmlElement xe8 = xmldoc.CreateElement("YD2");
                    xe8.InnerText = inspectResult.YD2;
                    XmlElement xe9 = xmldoc.CreateElement("YD3");
                    xe9.InnerText = inspectResult.YD3;
                    XmlElement xe10 = xmldoc.CreateElement("YDAV");
                    xe10.InnerText = inspectResult.YDAV;
                    XmlElement xe11 = xmldoc.CreateElement("YDLimit");
                    xe11.InnerText = inspectResult.YDLimit;
                    XmlElement IdleSpeed = xmldoc.CreateElement("IdleSpeed");
                    IdleSpeed.InnerText = inspectResult.IdleSpeed;
                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                    root.AppendChild(xe5);
                    root.AppendChild(xe6);
                    root.AppendChild(xe7);
                    root.AppendChild(xe8);
                    root.AppendChild(xe9);
                    root.AppendChild(xe10);
                    root.AppendChild(xe11);
                    root.AppendChild(IdleSpeed);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool StopInspect(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.StopInspect(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("StopInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        
        public bool EndInspect(string InspectID, XmlDocument inspectResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                string xmlstring = ConvertXmlToString(inspectResult);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndInspect(InspectID, xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndInspect\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndRecord(string InspectID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.EndRecord(InspectID, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndRecord\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginSelfTest(string LineID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginSelfTest(long.Parse(LineID), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndSelfTest(string LineID, selfCheckRecord_v27 selfTestResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                if (selfTestResult != null)
                {
                    XmlElement xe1 = xmldoc.CreateElement("AllResult");
                    xe1.InnerText = selfTestResult.AllResult;
                    XmlElement xe2 = xmldoc.CreateElement("Temperature");
                    xe2.InnerText = selfTestResult.Temperature;
                    XmlElement xe3 = xmldoc.CreateElement("Humidity");
                    xe3.InnerText = selfTestResult.Humidity;
                    XmlElement xe4 = xmldoc.CreateElement("Baro");
                    xe4.InnerText = selfTestResult.Baro;
                    

                    root.AppendChild(xe1);
                    root.AppendChild(xe2);
                    root.AppendChild(xe3);
                    root.AppendChild(xe4);
                }
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.EndSelfTest(long.Parse(LineID), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndSelfTest\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }

        public bool Send_SELFCHECK_RESULT_DATA<T>(string LineID, ah_selfcheck_public_data pmodel, T model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                XmlElement DeviceType = xmldoc.CreateElement("DeviceType");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                DeviceType.InnerText = pmodel.DeviceType;
                BeginTime.InnerText = pmodel.BeginTime;
                EndTime.InnerText = pmodel.EndTime;
                Judge.InnerText = pmodel.Judge;
                XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                List<string> namelist = new List<string>();
                List<string> valuelist = new List<string>();
                if (carinfo.XmlBuilderHelper.GetPorperty(model, out namelist, out valuelist))
                {
                    for (int i = 0; i < namelist.Count; i++)
                    {
                        XmlElement el = xmldoc.CreateElement(namelist[i]);
                        el.InnerText = valuelist[i];
                        JudgeData.AppendChild(el);
                    }
                }
                root.AppendChild(DeviceType);
                root.AppendChild(BeginTime);
                root.AppendChild(EndTime);
                root.AppendChild(Judge);
                root.AppendChild(JudgeData);
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.UploadSelfTestData(long.Parse(LineID), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadSelfTestData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool BeginCalibrate(string LineID, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                RetValue retvalue = outlineservice.BeginCalibrate(long.Parse(LineID), "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("BeginCalibrate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool EndCalibrate(string LineID, string selfTestResult, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                
                RetValue retvalue = outlineservice.EndCalibrate(long.Parse(LineID), selfTestResult, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("EndCalibrate\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }

        public bool Send_CALIBRATION_RESULT_DATA<T>(string LineID, ah_cal_public_data pmodel,ah_cal_judge_data jdata, List<T> model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                XmlElement DeviceType = xmldoc.CreateElement("Type");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                DeviceType.InnerText = pmodel.Type;
                BeginTime.InnerText = pmodel.BeginTime;
                EndTime.InnerText = pmodel.EndTime;
                Judge.InnerText = pmodel.Judge;
                XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                XmlElement type = xmldoc.CreateElement("type");//创建一个<Node>节点 
                //XmlElement InertiaEquivalent = xmldoc.CreateElement("InertiaEquivalent");//创建一个<Node>节点 
                XmlElement CalibrateCount = xmldoc.CreateElement("CalibrateCount");//创建一个<Node>节点 
                type.InnerText = jdata.type;
                //InertiaEquivalent.InnerText = jdata.InertiaEquivalent;
                CalibrateCount.InnerText = jdata.CalibrateCount;
                JudgeData.AppendChild(type);
                //JudgeData.AppendChild(InertiaEquivalent);
                JudgeData.AppendChild(CalibrateCount);
                if (typeof(T)==typeof(ah_jzhx_caldata)|| typeof(T) == typeof(ah_plhp_caldata))
                {
                    XmlElement InertiaEquivalent = xmldoc.CreateElement("InertiaEquivalent");//创建一个<Node>节点 
                    InertiaEquivalent.InnerText = jdata.InertiaEquivalent;
                    JudgeData.AppendChild(InertiaEquivalent);
                }
                if (typeof(T) != typeof(ah_gl_caldata))                
                {
                    for (int pointIndex = 1; pointIndex <= model.Count; pointIndex++)
                    {
                        XmlElement Point = xmldoc.CreateElement("Point_" + pointIndex.ToString());//创建一个<Node>节点 
                        List<string> namelist = new List<string>();
                        List<string> valuelist = new List<string>();
                        if (carinfo.XmlBuilderHelper.GetPorperty(model[pointIndex - 1], out namelist, out valuelist))
                        {
                            for (int i = 0; i < namelist.Count; i++)
                            {
                                XmlElement el = xmldoc.CreateElement(namelist[i]);
                                el.InnerText = valuelist[i];
                                Point.AppendChild(el);
                            }
                        }
                        JudgeData.AppendChild(Point);
                    }
                }
                root.AppendChild(DeviceType);
                root.AppendChild(BeginTime);
                root.AppendChild(EndTime);
                root.AppendChild(Judge);
                root.AppendChild(JudgeData);
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.UploadCalibrateData(long.Parse(LineID), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadCalibrateData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }
        public bool Send_CALIBRATION_GL_RESULT_DATA<T>(string LineID, ah_cal_public_data pmodel, ah_cal_judge_data jdata, List<ah_gl_caldata> model, out int result, out string errMsg)
        {
            result = 0;
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "body", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("body");//查找<Employees> 

                XmlElement DeviceType = xmldoc.CreateElement("Type");//创建一个<Node>节点 
                XmlElement BeginTime = xmldoc.CreateElement("BeginTime");//创建一个<Node>节点 
                XmlElement EndTime = xmldoc.CreateElement("EndTime");//创建一个<Node>节点 
                XmlElement Judge = xmldoc.CreateElement("Judge");//创建一个<Node>节点 
                DeviceType.InnerText = pmodel.Type;
                BeginTime.InnerText = pmodel.BeginTime;
                EndTime.InnerText = pmodel.EndTime;
                Judge.InnerText = pmodel.Judge;
                XmlElement JudgeData = xmldoc.CreateElement("JudgeData");
                XmlElement type = xmldoc.CreateElement("type");//创建一个<Node>节点 
                XmlElement CalibrateCount = xmldoc.CreateElement("CalibrateCount");//创建一个<Node>节点 
                type.InnerText = jdata.type;
                CalibrateCount.InnerText = jdata.CalibrateCount;
                JudgeData.AppendChild(type);
                JudgeData.AppendChild(CalibrateCount);
                
                for (int pointIndex = 1; pointIndex <= model.Count; pointIndex++)
                {
                    XmlElement Point = xmldoc.CreateElement("Point_" + pointIndex.ToString());//创建一个<Node>节点 

                    XmlElement NominalValue = xmldoc.CreateElement("NominalValue");
                    NominalValue.InnerText = model[pointIndex - 1].NominalValue;
                    XmlElement FromSpeed = xmldoc.CreateElement("FromSpeed");
                    FromSpeed.InnerText = model[pointIndex - 1].FromSpeed;
                    XmlElement ToSpeed = xmldoc.CreateElement("ToSpeed");
                    ToSpeed.InnerText = model[pointIndex - 1].ToSpeed;

                    XmlElement LoadingForce = xmldoc.CreateElement("LoadingForce");
                    XmlElement Count = xmldoc.CreateElement("Count");
                    Count.InnerText = "2";
                    XmlElement Force_1 = xmldoc.CreateElement("Force_1");
                    XmlElement ForceSettingValue1 = xmldoc.CreateElement("ForceSettingValue");
                    XmlElement ActualTime1 = xmldoc.CreateElement("ActualTime");
                    XmlElement ForceRealTime1 = xmldoc.CreateElement("ForceRealTime");
                    ForceSettingValue1.InnerText = model[pointIndex - 1].ForceSettingValue1;
                    ActualTime1.InnerText= model[pointIndex - 1].ActualTime1;
                    ForceRealTime1.InnerText = model[pointIndex - 1].ForceRealTime1;
                    Force_1.AppendChild(ForceSettingValue1);
                    Force_1.AppendChild(ActualTime1);
                    Force_1.AppendChild(ForceRealTime1);
                    XmlElement Force_2 = xmldoc.CreateElement("Force_2");
                    XmlElement ForceSettingValue2 = xmldoc.CreateElement("ForceSettingValue");
                    XmlElement ActualTime2 = xmldoc.CreateElement("ActualTime");
                    XmlElement ForceRealTime2 = xmldoc.CreateElement("ForceRealTime");
                    ForceSettingValue2.InnerText = model[pointIndex - 1].ForceSettingValue2;
                    ActualTime2.InnerText = model[pointIndex - 1].ActualTime2;
                    ForceRealTime2.InnerText = model[pointIndex - 1].ForceRealTime2;
                    Force_2.AppendChild(ForceSettingValue2);
                    Force_2.AppendChild(ActualTime2);
                    Force_2.AppendChild(ForceRealTime2);
                    LoadingForce.AppendChild(Count);
                    LoadingForce.AppendChild(Force_1);
                    LoadingForce.AppendChild(Force_2);

                    XmlElement RealValue = xmldoc.CreateElement("RealValue");
                    RealValue.InnerText = model[pointIndex - 1].RealValue;
                    XmlElement Deviation = xmldoc.CreateElement("Deviation");
                    Deviation.InnerText = model[pointIndex - 1].Deviation;

                    Point.AppendChild(NominalValue);
                    Point.AppendChild(FromSpeed);
                    Point.AppendChild(ToSpeed);
                    Point.AppendChild(LoadingForce);
                    Point.AppendChild(RealValue);
                    Point.AppendChild(Deviation);

                    JudgeData.AppendChild(Point);
                }
                root.AppendChild(DeviceType);
                root.AppendChild(BeginTime);
                root.AppendChild(EndTime);
                root.AppendChild(Judge);
                root.AppendChild(JudgeData);
                string xmlstring = ConvertXmlToString(xmldoc);
                xmlstring = xmlstring.Replace("<body>", "");
                xmlstring = xmlstring.Replace("</body>", "");
                xmlstring = xmlstring.Replace("\r\n", "");
                xmlstring = Regex.Replace(xmlstring, @">\s+<", "><");//去除节点之间所有的空格，回车及其他符号
                RetValue retvalue = outlineservice.UploadCalibrateData(long.Parse(LineID), xmlstring, "");
                result = retvalue.ErrNum;
                errMsg = retvalue.ErrMsg;
                ini.INIIO.saveSocketLogInf("UploadCalibrateData\r\n" + "ErrNum:" + retvalue.ErrNum + "\r\n" + "ErrMsg:" + retvalue.ErrMsg + "\r\n" + "Value:" + retvalue.Value);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                errMsg = er.Message;
                return false;
            }
        }

    }*/
}
