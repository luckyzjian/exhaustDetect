using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace JxWebClient
{
    public class jxcarinf
    {
        public string detectionId { set; get; }
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string testReportCode { set; get; }
        public string testCategory { set; get; }
        public string testType { set; get; }
        public string testTimes { set; get; }
        public string testPerson { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public string resultFlag { set; get; }
        public string detectionDate { set; get; }
        public string photoInfo { set; get; }
        public string statusFlag { set; get; }
        public string resultMemo { set; get; }
        public string logonPerson { set; get; }
        public string guidePerson { set; get; }
        public string processPhoto1 { set; get; }
        public string processPhoto2 { set; get; }
        public string processPhoto3 { set; get; }
        public string processPhoto4 { set; get; }
        public string detectionMemo { set; get; }
        public string appearanceTestId { set; get; }
        public string vehicleLicense { set; get; }
        public string vehicleLicenseType { set; get; }
        public string vehicleLicenseTypeGa247 { set; get; }
        public string vehicleVin { set; get; }
        public string engineIdentification { set; get; }
        public string vehicleType { set; get; }
        public string useType { set; get; }
        public string registerDate { set; get; }
        public string flagExempted { set; get; }
        public string odometerNumber { set; get; }
        public string ownerName { set; get; }
        public string ownerTel { set; get; }
        public string ownerAddress { set; get; }
        public string vehicleModel { set; get; }
        public string engineModel { set; get; }
        public string emissionStandard { set; get; }
        public string gearType { set; get; }
        public string airInType { set; get; }
        public string engineDisplacement { set; get; }
        public string fuelType { set; get; }
        public string fuelSupply { set; get; }
        public string engineRatedSpeed { set; get; }
        public string engineRatedPower { set; get; }
        public string driveMode { set; get; }
        public string massMax { set; get; }
        public string massReference { set; get; }
        public string cylindersNumber { set; get; }
        public string flagEgr { set; get; }
        public string flagTg { set; get; }
        public string flagHcl { set; get; }
        public string hclType { set; get; }
        public string flagDk { set; get; }
        public string flagObd { set; get; }
        public string flagObdAccess { set; get; }
        public string flagObdGood { set; get; }
        public string flagObdFailure { set; get; }
        public string flagTurn { set; get; }
        public string flagAirOut { set; get; }
        public string flagLeak { set; get; }
        public string flagCloseSpecial { set; get; }
        public string appearResultFlag { set; get; }
        public string picFront45 { set; get; }
        public string picBack45 { set; get; }
        public string picVin { set; get; }
        public string picEngine { set; get; }
        public string fuelSpec { set; get; }
        public string vehicleManufacturer { set; get; }
        public string manufacturingDate { set; get; }
        public string passengersCount { set; get; }
        public string picDashboard { set; get; }
        public string picExhaustEmissionDevice { set; get; }
        public string srhFrom { set; get; }
        public string srhTo { set; get; }
        public string srhResultIsNotNull { set; get; }
        public string srhStatus0or2 { set; get; }
        public string pager { set; get; }
        public string statusList { set; get; }
        public string btnConfirmShow { set; get; }
        public string modelTypeId { set; get; }
        public string year { set; get; }
        public string month { set; get; }
        public string percentOfPass { set; get; }
        public string passNum { set; get; }
        public string checkNum { set; get; }
        public string num { set; get; }


    }
    public class jxstartdetection
    {
        public string testLineId { set; get; }
        public string testType { set; get; }
        public string testPerson { set; get; }
        public string guidePerson { set; get; }
        public jxstartdetection(string testLineId,string testType,string testPerson,string guidePerson)
        {

            this.testLineId = testLineId;
            this.testType = testType;
            this.testPerson = testPerson;
            this.guidePerson = guidePerson;
        }
    }
    public class jxSdsProcessData
    {
        public string seqTime { set; get; }
        public string workingConditionType { set; get; }
        public string seqNumber { set; get; }
        public string hcValue { set; get; }
        public string coValue { set; get; }
        public string o2Value { set; get; }
        public string co2Value { set; get; }
        public string excessAirRatio { set; get; }
        public string actualSpeed { set; get; }
        public jxSdsProcessData(string seqTime,string workingConditionType,string seqNumber,string hcValue,string coValue,string o2Value,
            string co2Value,string excessAirRatio,string actualSpeed)
        {
            this.seqTime = seqTime;
            this.workingConditionType = workingConditionType;
            this.seqNumber = seqNumber;
            this.hcValue = hcValue;
            this.coValue = coValue;
            this.o2Value = o2Value;
            this.co2Value = co2Value;
            this.excessAirRatio = excessAirRatio;
            this.actualSpeed = actualSpeed;
        }
    }
    public class jxVmasProcessData
    {
        public string seqTime { set; get; }
        public string workingConditionType { set; get; }
        public string seqNumber { set; get; }
        public string engineActualSpeed { set; get; }
        public string hcValue { set; get; }
        public string coValue { set; get; }
        public string co2Value { set; get; }
        public string noValue { set; get; }
        public string o2Environment { set; get; }
        public string o2Analyser { set; get; }
        public string o2Flowmeter { set; get; }
        public string hcMgPerSecond { set; get; }
        public string coMgPerSecond { set; get; }
        public string noxMgPerSecond { set; get; }
        public string standardSpeed { set; get; }
        public string actualSpeed { set; get; }
        public string torqueForce { set; get; }
        public string actualPower { set; get; }
        public string weatherTemperature { set; get; }
        public string weatherHumidity { set; get; }
        public string weatherAtmospheric { set; get; }
        public string flowmeterTemperature { set; get; }
        public string flowmeterAtmospheric { set; get; }
        public string actualVolumeFlow { set; get; }
        public string standardVolumeFlow { set; get; }
        public string humidityCorrectionFactor { set; get; }
        public string dilutionCorrectionFactor { set; get; }
        public string dilutionRatio { set; get; }
        public string analyserPipePresure { set; get; }
        public string actualEmissionFlow { set; get; }
        public jxVmasProcessData(string seqTime, string workingConditionType, string seqNumber, string engineActualSpeed,
            string hcValue, string coValue, string co2Value, string noValue, string o2Environment,
            string o2Analyser, string o2Flowmeter, string hcMgPerSecond, string coMgPerSecond, string noxMgPerSecond,
            string standardSpeed, string actualSpeed, string torqueForce, string actualPower, string weatherTemperature,
            string weatherHumidity, string weatherAtmospheric, string flowmeterTemperature, string flowmeterAtmospheric, 
            string actualVolumeFlow,
            string standardVolumeFlow, string humidityCorrectionFactor, string dilutionCorrectionFactor, string dilutionRatio, string analyserPipePresure,
            string actualEmissionFlow
            )
        {
            this.seqTime = seqTime;
            this.workingConditionType = workingConditionType;
            this.seqNumber = seqNumber;
            this.engineActualSpeed = engineActualSpeed;
            this.hcValue = hcValue;
            this.coValue = coValue;
            this.co2Value = co2Value;
            this.noValue = noValue;
            this.o2Environment = o2Environment;
            this.o2Analyser = o2Analyser;
            this.o2Flowmeter = o2Flowmeter;
            this.hcMgPerSecond = hcMgPerSecond;
            this.coMgPerSecond = coMgPerSecond;
            this.noxMgPerSecond = noxMgPerSecond;
            this.standardSpeed = standardSpeed;
            this.actualSpeed = actualSpeed;
            this.torqueForce = torqueForce;
            this.actualPower = actualPower;
            this.weatherTemperature = weatherTemperature;
            this.weatherHumidity = weatherHumidity;
            this.weatherAtmospheric = weatherAtmospheric;
            this.flowmeterTemperature = flowmeterTemperature;
            this.flowmeterAtmospheric = flowmeterAtmospheric;
            this.actualVolumeFlow = actualVolumeFlow;
            this.standardVolumeFlow = standardVolumeFlow;
            this.humidityCorrectionFactor = humidityCorrectionFactor;
            this.dilutionCorrectionFactor = dilutionCorrectionFactor;
            this.dilutionRatio = dilutionRatio;
            this.analyserPipePresure = analyserPipePresure;
            this.actualEmissionFlow = actualEmissionFlow;
           

        }
    }
    public class jxLugdownProcessData
    {
        public string seqTime { set; get; }
        public string workingConditionType { set; get; }
        public string seqNumber { set; get; }
        public string actualSpeed { set; get; }
        public string torqueForce { set; get; }
        public string engineActualSpeed { set; get; }
        public string dynamometerLoad { set; get; }
        public string lightAbsorbRatio { set; get; }
        public jxLugdownProcessData(
            string seqTime, 
            string workingConditionType, 
            string seqNumber, 
            string actualSpeed,
            string torqueForce,
            string engineActualSpeed, 
            string dynamometerLoad,
            string lightAbsorbRatio)
        {
            this.seqTime = seqTime;
            this.workingConditionType = workingConditionType;
            this.seqNumber = seqNumber;
            this.actualSpeed = actualSpeed;
            this.torqueForce = torqueForce;
            this.engineActualSpeed = engineActualSpeed;
            this.dynamometerLoad = dynamometerLoad;
            this.lightAbsorbRatio = lightAbsorbRatio;

        }
    }
    public class jxBtgProcessData
    {
        public string seqTime { set; get; }
        public string workingConditionType { set; get; }
        public string seqNumber { set; get; }
        public string smokeValue { set; get; }
        public string engineActualSpeed { set; get; }
        public jxBtgProcessData(string seqTime,
            string workingConditionType,
            string seqNumber,
            string smokeValue,
            string engineActualSpeed
        )
        {
            this.seqTime = seqTime;
            this.workingConditionType = workingConditionType;
            this.seqNumber = seqNumber;
            this.smokeValue = smokeValue;
            this.engineActualSpeed = engineActualSpeed;

        }
    }
    public class jxSdsResultData
    {
        public string detectionId { set; get; }
        public string weatherTemperature { set; get; }
        public string weatherAtmospheric { set; get; }
        public string weatherHumidity { set; get; }
        public string oilTemperature { set; get; }
        public string lambdaLowerLimit { set; get; }
        public string lambdaUpperLimit { set; get; }
        public string lambdaResult { set; get; }
        public string lambdaJudge { set; get; }
        public string lowSpeedCoLimit { set; get; }
        public string lowSpeedCoResult { set; get; }
        public string lowSpeedCoJudge { set; get; }
        public string lowSpeedHcLimit { set; get; }
        public string lowSpeedHcResult { set; get; }
        public string lowSpeedHcJudge { set; get; }
        public string highSpeedCoLimit { set; get; }
        public string highSpeedCoResult { set; get; }
        public string highSpeedCoJudge { set; get; }
        public string highSpeedHcLimit { set; get; }
        public string highSpeedHcResult { set; get; }
        public string highSpeedHcJudge { set; get; }
        public string lowSpeed { set; get; }
        public string highSpeed { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public jxSdsResultData(string detectionId,
            string weatherTemperature,
            string weatherAtmospheric,
            string weatherHumidity,
            string oilTemperature,
            string lambdaLowerLimit,
            string lambdaUpperLimit,
            string lambdaResult,
            string lambdaJudge,
            string lowSpeedCoLimit,
            string lowSpeedCoResult,
            string lowSpeedCoJudge,
            string lowSpeedHcLimit,
            string lowSpeedHcResult,
            string lowSpeedHcJudge,
            string highSpeedCoLimit,
            string highSpeedCoResult,
            string highSpeedCoJudge,
            string highSpeedHcLimit,
            string highSpeedHcResult,
            string highSpeedHcJudge,
            string lowSpeed,
            string highSpeed,
            string startTime,
            string endTime
        )
        {
            this.detectionId = detectionId;
            this.weatherTemperature = weatherTemperature;
            this.weatherAtmospheric = weatherAtmospheric;
            this.weatherHumidity = weatherHumidity;
            this.oilTemperature = oilTemperature;
            this.lambdaLowerLimit = lambdaLowerLimit;
            this.lambdaUpperLimit = lambdaUpperLimit;
            this.lambdaResult = lambdaResult;
            this.lambdaJudge = lambdaJudge;
            this.lowSpeedCoLimit = lowSpeedCoLimit;
            this.lowSpeedCoResult = lowSpeedCoResult;
            this.lowSpeedCoJudge = lowSpeedCoJudge;
            this.lowSpeedHcLimit = lowSpeedHcLimit;
            this.lowSpeedHcResult = lowSpeedHcResult;
            this.lowSpeedHcJudge = lowSpeedHcJudge;
            this.highSpeedCoLimit = highSpeedCoLimit;
            this.highSpeedCoResult = highSpeedCoResult;
            this.highSpeedCoJudge = highSpeedCoJudge;
            this.highSpeedHcLimit = highSpeedHcLimit;
            this.highSpeedHcResult = highSpeedHcResult;
            this.highSpeedHcJudge = highSpeedHcJudge;
            this.lowSpeed = lowSpeed;
            this.highSpeed = highSpeed;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
    public class jxVmasResultData
    {
        public string detectionId { set; get; }
        public string weatherTemperature { set; get; }
        public string weatherAtmospheric { set; get; }
        public string weatherHumidity { set; get; }
        public string hcLimit { set; get; }
        public string coLimit { set; get; }
        public string noxLimit { set; get; }
        public string hcnoxLimit { set; get; }
        public string hcValue { set; get; }
        public string coValue { set; get; }
        public string noxValue { set; get; }
        public string hcnoxValue { set; get; }
        public string hcJudge { set; get; }
        public string coJudge { set; get; }
        public string noxJudge { set; get; }
        public string hcnoxJudge { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public jxVmasResultData(string detectionId , string weatherTemperature , string weatherAtmospheric , string weatherHumidity , string hcLimit , string coLimit , string noxLimit , string hcnoxLimit , string hcValue , string coValue , string noxValue , string hcnoxValue , string hcJudge , string coJudge , string noxJudge , string hcnoxJudge , string startTime , string endTime)
        {
            this.detectionId = detectionId;
            this.weatherTemperature = weatherTemperature;
            this.weatherAtmospheric = weatherAtmospheric;
            this.weatherHumidity = weatherHumidity;
            this.hcLimit = hcLimit;
            this.coLimit = coLimit;
            this.noxLimit = noxLimit;
            this.hcnoxLimit = hcnoxLimit;
            this.hcValue = hcValue;
            this.coValue = coValue;
            this.noxValue = noxValue;
            this.hcnoxValue = hcnoxValue;
            this.hcJudge = hcJudge;
            this.coJudge = coJudge;
            this.noxJudge = noxJudge;
            this.hcnoxJudge = hcnoxJudge;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
    public class jxLugdownResultData
    {
        public string detectionId { set; get; }
        public string weatherTemperature { set; get; }
        public string weatherAtmospheric { set; get; }
        public string weatherHumidity { set; get; }
        public string smokeLimit { set; get; }
        public string k100Value { set; get; }
        public string k90Value { set; get; }
        public string k80Value { set; get; }
        public string maxPowerLimit { set; get; }
        public string maxPowerValue { set; get; }
        public string engineRatedSpeedUpper { set; get; }
        public string engineRatedSpeedLower { set; get; }
        public string engineActualSpeed { set; get; }
        public string resultFlag { set; get; }
        public string maxPowerDevidePe { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public jxLugdownResultData(string detectionId,
            string weatherTemperature, 
            string weatherAtmospheric, 
            string weatherHumidity,
            string smokeLimit,
            string k100Value, 
            string k90Value, 
            string k80Value, 
            string maxPowerLimit,
            string maxPowerValue,
            string engineRatedSpeedUpper,
            string engineRatedSpeedLower, 
            string engineActualSpeed, 
            string resultFlag,
            string maxPowerDevidePe, 
            string startTime,
            string endTime)
        {
            this.detectionId = detectionId;
            this.weatherTemperature = weatherTemperature;
            this.weatherAtmospheric = weatherAtmospheric;
            this.weatherHumidity = weatherHumidity;
            this.smokeLimit = smokeLimit;
            this.k100Value = k100Value;
            this.k90Value = k90Value;
            this.k80Value = k80Value;
            this.maxPowerLimit = maxPowerLimit;
            this.maxPowerValue = maxPowerValue;
            this.engineRatedSpeedUpper = engineRatedSpeedUpper;
            this.engineRatedSpeedLower = engineRatedSpeedLower;
            this.engineActualSpeed = engineActualSpeed;
            this.resultFlag = resultFlag;
            this.maxPowerDevidePe = maxPowerDevidePe;
            this.startTime = startTime;
            this.endTime = endTime;
        }

    }
    public class jxBtgResultData
    {
        public string detectionId { set; get; }
        public string weatherTemperature { set; get; }
        public string weatherAtmospheric { set; get; }
        public string weatherHumidity { set; get; }
        public string idleRev { set; get; }
        public string smokeLimit { set; get; }
        public string smokeK1 { set; get; }
        public string smokeK2 { set; get; }
        public string smokeK3 { set; get; }
        public string smokeK4 { set; get; }
        public string smokeAvg { set; get; }
        public string resultFlag { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public jxBtgResultData(string detectionId,
            string weatherTemperature,
            string weatherHumidity,
            string weatherAtmospheric,
            string idleRev,
            string smokeLimit,
            string smokeK1,
            string smokeK2,
            string smokeK3,
            string smokeK4,
            string smokeAvg,
            string resultFlag,
            string startTime,
            string endTime
        )
        {
            this.detectionId = detectionId;
            this.weatherTemperature = weatherTemperature;
            this.weatherHumidity = weatherHumidity;
            this.weatherAtmospheric = weatherAtmospheric;
            this.idleRev = idleRev;
            this.smokeLimit = smokeLimit;
            this.smokeK1 = smokeK1;
            this.smokeK2 = smokeK2;
            this.smokeK3 = smokeK3;
            this.smokeK4 = smokeK4;
            this.smokeAvg = smokeAvg;
            this.resultFlag = resultFlag;
            this.startTime = startTime;
            this.endTime = endTime;

        }
    }
    public class jxLzResultData
    {
        public string detectionId { set; get; }
        public string rbLimit { set; get; }
        public string smokeRb1 { set; get; }
        public string smokeRb2 { set; get; }
        public string smokeRb3 { set; get; }
        public string smokeRbAvg { set; get; }
        public string resultFlag { set; get; }
        public string startTime { set; get; }
        public string endTime { set; get; }
        public jxLzResultData(string detectionId,
            string rbLimit,
            string smokeRb1,
            string smokeRb2,
            string smokeRb3,
            string smokeRbAvg,
            string resultFlag,
            string startTime,
            string endTime
        )
        {
            this.detectionId = detectionId;
            this.rbLimit = rbLimit;
            this.smokeRb1 = smokeRb1;
            this.smokeRb2 = smokeRb2;
            this.smokeRb3 = smokeRb3;
            this.smokeRbAvg = smokeRbAvg;
            this.resultFlag = resultFlag;
            this.startTime = startTime;
            this.endTime = endTime;

        }
    }
    public class jxJxhxdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string coastedStartTime { set; get; }
        public string coastedActualTime48to32 { set; get; }
        public string coastedActualTime32to16 { set; get; }
        public string loss40 { set; get; }
        public string loss25 { set; get; }
        public string coastedNominalTime48to32 { set; get; }
        public string coastedNominalTime32to16 { set; get; }
        public string coastedPower48to32 { set; get; }
        public string coastedPower32to16 { set; get; }
        public string basicInertia { set; get; }
        public string coastedResult48to32 { set; get; }
        public string coastedResult32to16 { set; get; }
        public string resultFlag { set; get; }

    }
    public class jxPlhpdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string coastedStartTime { set; get; }
        public string coastedEndTime { set; get; }
        public string coastedActualTime48to32 { set; get; }
        public string coastedActualTime32to16 { set; get; }
        public string loss40 { set; get; }
        public string loss25 { set; get; }
        public string basicInertia { set; get; }

    }
    public class jxFqyBaseCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string checkType { set; get; }
        public string startTime { set; get; }
        public string standardC3h8 { set; get; }
        public string standardCo { set; get; }
        public string standardCo2 { set; get; }
        public string standardNo { set; get; }
        public string standardO2 { set; get; }
        public string actualHc { set; get; }
        public string actualCo { set; get; }
        public string actualCo2 { set; get; }
        public string actualNo { set; get; }
        public string actualO2 { set; get; }
        public string pefValue { set; get; }
        public string resultFlag { set; get; }

    }
    public class jxFqyLeakCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string startTime { set; get; }
        public string resultFlag { set; get; }
    }
    public class jxFqyOxygenCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string startTime { set; get; }
        public string o2RangeGivenValue { set; get; }
        public string o2RangeMeasuredValue { set; get; }
        public string o2RangeErrorValue { set; get; }
        public string resultFlag { set; get; }

    }
    public class jxFqyLowCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string startTime { set; get; }
        public string standardC3h8 { set; get; }
        public string standardCo { set; get; }
        public string standardCo2 { set; get; }
        public string standardNo { set; get; }
        public string standardO2 { set; get; }
        public string actualHc { set; get; }
        public string actualCo { set; get; }
        public string actualCo2 { set; get; }
        public string actualNo { set; get; }
        public string actualO2 { set; get; }
        public string pefValue { set; get; }
        public string resultFlag { set; get; }
    }
    public class jxLljCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string startTime { set; get; }
        public string o2HighGivenValue { set; get; }
        public string o2HighMeasuredValue { set; get; }
        public string o2HighErrorValue { set; get; }
        public string o2LowGivenValue { set; get; }
        public string o2LowMeasuredValue { set; get; }
        public string o2LowErrorValue { set; get; }
        public string resultFlag { set; get; }

    }
    public class jxYdjCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string statusFlag { set; get; }
        public string resultFlag { set; get; }
        public string failureReason { set; get; }
        public string flagConnect { set; get; }
        public string flagPreheat { set; get; }
        public string flagZero { set; get; }
        public string flagRange { set; get; }
        public string checkNumber { set; get; }
        public string ratedValue1 { set; get; }
        public string actualValue1 { set; get; }
        public string errorValue1 { set; get; }
        public string ratedValue2 { set; get; }
        public string actualValue2 { set; get; }
        public string errorValue2 { set; get; }

    }
    public class jxQxzCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string statusFlag { set; get; }
        public string resultFlag { set; get; }
        public string failureReason { set; get; }
        public string flagConnect { set; get; }
        public string flagPreheat { set; get; }
        public string flagZero { set; get; }
        public string flagRange { set; get; }
        public string weatherHumidity { set; get; }
        public string deviceHumidity { set; get; }
        public string weatherAtmospheric { set; get; }
        public string deviceAtmospheric { set; get; }
        public string weatherTemperature { set; get; }
        public string deviceTemperature { set; get; }

    }
    public class jxZsjCheckdata
    {
        public string testInstitutionId { set; get; }
        public string testLineId { set; get; }
        public string checkDate { set; get; }
        public string statusFlag { set; get; }
        public string resultFlag { set; get; }
        public string failureReason { set; get; }
        public string flagConnect { set; get; }
        public string lowSpeed { set; get; }

    }
    public class jxWebControl
    {
        public Dictionary<string, string> JX_TESTCATEGORY = new Dictionary<string, string>();
        public Dictionary<string, string> JX_TESTTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_VEHICLELICENSETYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_USETYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGEXEMPTED = new Dictionary<string, string>();
        public Dictionary<string, string> JX_EMISSIONSTANDARD = new Dictionary<string, string>();
        public Dictionary<string, string> JX_GEARTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_AIRINTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FUELTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FUELSUPPLY = new Dictionary<string, string>();
        public Dictionary<string, string> JX_DRIVEMODE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGEGR = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGTG = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGHCL = new Dictionary<string, string>();
        public Dictionary<string, string> JX_HCLTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGDK = new Dictionary<string, string>();
        public Dictionary<string, string> JX_FLAGOBD = new Dictionary<string, string>();

        public Dictionary<string, string> RJX_TESTCATEGORY = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_TESTTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_VEHICLELICENSETYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_USETYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGEXEMPTED = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_EMISSIONSTANDARD = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_GEARTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_AIRINTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FUELTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FUELSUPPLY = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_DRIVEMODE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGEGR = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGTG = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGHCL = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_HCLTYPE = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGDK = new Dictionary<string, string>();
        public Dictionary<string, string> RJX_FLAGOBD = new Dictionary<string, string>();
        VersionControl.ExhaustMonitoring ex;//= new VersionControl.ExhaustMonitoring();
        string user, password,url;
        public jxWebControl(string url,string user,string password)
        {
            try
            {
                JX_VEHICLELICENSETYPE.Add("1", "蓝牌");
                JX_VEHICLELICENSETYPE.Add("2", "黄牌");
                JX_VEHICLELICENSETYPE.Add("3", "黑牌");
                JX_VEHICLELICENSETYPE.Add("4", "白牌");
                JX_TESTCATEGORY.Add("1", "定期检验");
                JX_TESTCATEGORY.Add("2", "注册登记检验");
                JX_TESTCATEGORY.Add("3", "实验对比");
                JX_TESTCATEGORY.Add("4", "监督抽测不合格复检");
                JX_TESTTYPE.Add("1", "双怠速");
                JX_TESTTYPE.Add("2", "稳态工况");
                JX_TESTTYPE.Add("3", "简易瞬态工况");
                JX_TESTTYPE.Add("4", "加载减速");
                JX_TESTTYPE.Add("5", "滤纸烟度");
                JX_TESTTYPE.Add("6", "不透光烟度");
                JX_USETYPE.Add("A", "非营运");
                JX_USETYPE.Add("B", "公路客运");
                JX_USETYPE.Add("C", "公交客运");
                JX_USETYPE.Add("D", "出租客运");
                JX_USETYPE.Add("E", "旅游客运");
                JX_USETYPE.Add("F", "货运");
                JX_USETYPE.Add("G", "租赁");
                JX_USETYPE.Add("H", "警用");
                JX_USETYPE.Add("I", "消防");
                JX_USETYPE.Add("J", "救护");
                JX_USETYPE.Add("K", "工程抢险");
                JX_USETYPE.Add("L", "营转非");
                JX_USETYPE.Add("M", "出租转非");
                JX_USETYPE.Add("Z", "其他");
                JX_FLAGEXEMPTED.Add("Y", "是");
                JX_FLAGEXEMPTED.Add("N", "否");
                JX_EMISSIONSTANDARD.Add("0", "国0");
                JX_EMISSIONSTANDARD.Add("1", "国I");
                JX_EMISSIONSTANDARD.Add("2", "国II");
                JX_EMISSIONSTANDARD.Add("3", "国III");
                JX_EMISSIONSTANDARD.Add("4", "国IV");
                JX_EMISSIONSTANDARD.Add("5", "国V");
                JX_GEARTYPE.Add("1", "手动");
                JX_GEARTYPE.Add("2", "自动");
                JX_GEARTYPE.Add("3", "手自一体");
                JX_AIRINTYPE.Add("1", "自然进气");
                JX_AIRINTYPE.Add("2", "涡轮增压");
                JX_FUELTYPE.Add("A", "汽油");
                JX_FUELTYPE.Add("B", "柴油");
                JX_FUELTYPE.Add("C", "电");
                JX_FUELTYPE.Add("D", "混合油");
                JX_FUELTYPE.Add("E", "天然气");
                JX_FUELTYPE.Add("F", "液化石油气");
                JX_FUELTYPE.Add("L", "甲醇");
                JX_FUELTYPE.Add("M", "乙醇");
                JX_FUELTYPE.Add("N", "太阳能");
                JX_FUELTYPE.Add("O", "混合动力");
                JX_FUELTYPE.Add("Y", "无");
                JX_FUELTYPE.Add("Z", "其他");
                JX_FUELSUPPLY.Add("1", "化油器");
                JX_FUELSUPPLY.Add("2", "化油器改造");
                JX_FUELSUPPLY.Add("3", "开环电喷");
                JX_FUELSUPPLY.Add("4", "闭环电喷");
                JX_FUELSUPPLY.Add("5", "高压共轨");
                JX_FUELSUPPLY.Add("6", "泵喷嘴");
                JX_FUELSUPPLY.Add("7", "单体泵");
                JX_FUELSUPPLY.Add("8", "直列泵");
                JX_FUELSUPPLY.Add("9", "机械泵");
                JX_FUELSUPPLY.Add("10", "其他");
                JX_DRIVEMODE.Add("1", "前驱");
                JX_DRIVEMODE.Add("2", "后驱");
                JX_DRIVEMODE.Add("3", "四驱");
                JX_DRIVEMODE.Add("4", "全时四驱");
                JX_FLAGEGR.Add("Y", "有");
                JX_FLAGEGR.Add("N", "无");
                JX_FLAGTG.Add("Y", "有");
                JX_FLAGTG.Add("N", "无");
                JX_FLAGHCL.Add("Y", "有");
                JX_FLAGHCL.Add("N", "无");
                JX_HCLTYPE.Add("1", "三元催化");
                JX_HCLTYPE.Add("2", "DPF");
                JX_HCLTYPE.Add("3", "SCR");
                JX_HCLTYPE.Add("4", "DOC");
                JX_HCLTYPE.Add("5", "POC");
                JX_HCLTYPE.Add("6", "其他");
                JX_HCLTYPE.Add("7", "无");
                JX_FLAGDK.Add("Y", "有");
                JX_FLAGDK.Add("N", "无");
                JX_FLAGOBD.Add("Y", "有");
                JX_FLAGOBD.Add("N", "无");

                RJX_VEHICLELICENSETYPE.Add("蓝牌", "1");
                RJX_VEHICLELICENSETYPE.Add("黄牌", "2");
                RJX_VEHICLELICENSETYPE.Add("黑牌", "3");
                RJX_VEHICLELICENSETYPE.Add("白牌", "4");
                RJX_TESTCATEGORY.Add("定期检验", "1");
                RJX_TESTCATEGORY.Add("注册登记检验", "2");
                RJX_TESTCATEGORY.Add("实验对比", "3");
                RJX_TESTCATEGORY.Add("监督抽测不合格复检", "4");
                RJX_TESTTYPE.Add("双怠速", "1");
                RJX_TESTTYPE.Add("稳态工况", "2");
                RJX_TESTTYPE.Add("简易瞬态工况", "3");
                RJX_TESTTYPE.Add("加载减速", "4");
                RJX_TESTTYPE.Add("滤纸烟度", "5");
                RJX_TESTTYPE.Add("不透光烟度", "6");
                RJX_USETYPE.Add("非营运", "A");
                RJX_USETYPE.Add("公路客运", "B");
                RJX_USETYPE.Add("公交客运", "C");
                RJX_USETYPE.Add("出租客运", "D");
                RJX_USETYPE.Add("旅游客运", "E");
                RJX_USETYPE.Add("货运", "F");
                RJX_USETYPE.Add("租赁", "G");
                RJX_USETYPE.Add("警用", "H");
                RJX_USETYPE.Add("消防", "I");
                RJX_USETYPE.Add("救护", "J");
                RJX_USETYPE.Add("工程抢险", "K");
                RJX_USETYPE.Add("营转非", "L");
                RJX_USETYPE.Add("出租转非", "M");
                RJX_USETYPE.Add("其他", "Z");
                RJX_FLAGEXEMPTED.Add("是", "Y");
                RJX_FLAGEXEMPTED.Add("否", "N");
                RJX_EMISSIONSTANDARD.Add("国0", "0");
                RJX_EMISSIONSTANDARD.Add("国I", "1");
                RJX_EMISSIONSTANDARD.Add("国II", "2");
                RJX_EMISSIONSTANDARD.Add("国III", "3");
                RJX_EMISSIONSTANDARD.Add("国IV", "4");
                RJX_EMISSIONSTANDARD.Add("国V", "5");
                RJX_GEARTYPE.Add("手动", "1");
                RJX_GEARTYPE.Add("自动", "2");
                RJX_GEARTYPE.Add("手自一体", "3");
                RJX_AIRINTYPE.Add("自然进气", "1");
                RJX_AIRINTYPE.Add("涡轮增压", "2");
                RJX_FUELTYPE.Add("汽油", "A");
                RJX_FUELTYPE.Add("柴油", "B");
                RJX_FUELTYPE.Add("电", "C");
                RJX_FUELTYPE.Add("混合油", "D");
                RJX_FUELTYPE.Add("天然气", "E");
                RJX_FUELTYPE.Add("液化石油气", "F");
                RJX_FUELTYPE.Add("甲醇", "L");
                RJX_FUELTYPE.Add("乙醇", "M");
                RJX_FUELTYPE.Add("太阳能", "N");
                RJX_FUELTYPE.Add("混合动力", "O");
                RJX_FUELTYPE.Add("无", "Y");
                RJX_FUELTYPE.Add("其他", "Z");
                RJX_FUELSUPPLY.Add("化油器", "1");
                RJX_FUELSUPPLY.Add("化油器改造", "2");
                RJX_FUELSUPPLY.Add("开环电喷", "3");
                RJX_FUELSUPPLY.Add("闭环电喷", "4");
                RJX_FUELSUPPLY.Add("高压共轨", "5");
                RJX_FUELSUPPLY.Add("泵喷嘴", "6");
                RJX_FUELSUPPLY.Add("单体泵", "7");
                RJX_FUELSUPPLY.Add("直列泵", "8");
                RJX_FUELSUPPLY.Add("机械泵", "9");
                RJX_FUELSUPPLY.Add("其他", "10");
                RJX_DRIVEMODE.Add("前驱", "1");
                RJX_DRIVEMODE.Add("后驱", "2");
                RJX_DRIVEMODE.Add("四驱", "3");
                RJX_DRIVEMODE.Add("全时四驱", "4");
                RJX_FLAGEGR.Add("有", "Y");
                RJX_FLAGEGR.Add("无", "N");
                RJX_FLAGTG.Add("有", "Y");
                RJX_FLAGTG.Add("无", "N");
                RJX_FLAGHCL.Add("有", "Y");
                RJX_FLAGHCL.Add("无", "N");
                RJX_HCLTYPE.Add("三元催化", "1");
                RJX_HCLTYPE.Add("DPF", "2");
                RJX_HCLTYPE.Add("SCR", "3");
                RJX_HCLTYPE.Add("DOC", "4");
                RJX_HCLTYPE.Add("POC", "5");
                RJX_HCLTYPE.Add("其他", "6");
                RJX_HCLTYPE.Add("无", "7");
                RJX_FLAGDK.Add("有", "Y");
                RJX_FLAGDK.Add("无", "N");
                RJX_FLAGOBD.Add("有", "Y");
                RJX_FLAGOBD.Add("无", "N");
                this.user = user;
                this.password = password;
                this.url = url;
                ex = new VersionControl.ExhaustMonitoring(url);
                ini.INIIO.saveSocketLogInf("江西联网接口初始化成功");
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("江西联网接口初始化发生异常:\r\n" + er.Message);
            }
        }
        public bool sendAuthorizationDataWithVersion()
        {
            //VersionControl.ExhaustMonitoring 
            ini.INIIO.saveSocketLogInf("SEND:\r\nsendAuthorizationData("+user+","+password+")");
            if (ex.sendAuthorizationData(user, password))
            {
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\nTRUE");
                return true;
            }
            else
            {
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\nFALSE");
                return false;
            }
        }
        public bool fetchServerTime(out string code,out string message)
        {
            //VersionControl.ExhaustMonitoring ex = new VersionControl.ExhaustMonitoring(url);
            message = "";
            try
            {
                ini.INIIO.saveSocketLogInf("SEND:\r\nfetchServerTime()");
                string ack = ex.fetchServerTime();
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.fetchServerTime();
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n"+ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch(Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n"+er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool fetchVehicles(out string code, out string message,out List<jxcarinf> carinflist)
        {
            message = "";
            carinflist = new List<jxcarinf>();
            try
            {
                ini.INIIO.saveSocketLogInf("SEND:\r\nfetchVehicles()");
                string ack = ex.fetchVehicles();
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.fetchVehicles();
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    carinflist = JsonConvert.DeserializeObject<List<jxcarinf>>(message);                    
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool logonAdditional(string detectionId,jxstartdetection data,string driveMode,out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject(
                    new JProperty("detectionData", new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data)))),
                    new JProperty("appDetectionData", new JObject(new JProperty("driveMode", driveMode)))
                    ).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nlogonAdditional(" + detectionId + "," + jsonstring + ")");
                string ack = ex.logonAdditional(detectionId,jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.logonAdditional(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool stop(string detectionId, out string code, out string message)
        {
            message = "";
            try
            {
                ini.INIIO.saveSocketLogInf("SEND:\r\nstop(" + detectionId + ")");
                string ack = ex.stop(detectionId);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.stop(detectionId);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool finish(string detectionId, out string code, out string message)
        {
            message = "";
            try
            {
                ini.INIIO.saveSocketLogInf("SEND:\r\nfinish(" + detectionId + ")");
                string ack = ex.finish(detectionId);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.finish(detectionId);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool cancel(string detectionId, out string code, out string message)
        {
            message = "";
            try
            {
                ini.INIIO.saveSocketLogInf("SEND:\r\ncancel(" + detectionId + ")");
                string ack = ex.cancel(detectionId);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.cancel(detectionId);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendIdleStateProcessData(string detectionId, jxSdsProcessData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendIdleStateProcessData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendIdleStateProcessData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendIdleStateProcessData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendSimpleTransientProcessData(string detectionId, jxVmasProcessData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendSimpleTransientProcessData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendSimpleTransientProcessData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendSimpleTransientProcessData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendLugDownProcessData(string detectionId, jxLugdownProcessData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendLugDownProcessData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendLugDownProcessData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendLugDownProcessData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendLightSmokeProcessData(string detectionId, jxBtgProcessData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendLightSmokeProcessData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendLightSmokeProcessData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendLightSmokeProcessData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendIdleStateResultData(string detectionId, jxSdsResultData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendIdleStateResultData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendIdleStateResultData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendIdleStateResultData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendSimpleTransientResultData(string detectionId, jxVmasResultData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendSimpleTransientResultData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendSimpleTransientResultData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendSimpleTransientResultData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendLugDownResultData(string detectionId, jxLugdownResultData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendLugDownResultData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendLugDownResultData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendLugDownResultData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendLightSmokeResultData(string detectionId, jxBtgResultData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendLightSmokeResultData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendLightSmokeResultData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendLightSmokeResultData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendFilterSmokeResultData(string detectionId, jxLzResultData data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                ini.INIIO.saveSocketLogInf("SEND:\r\nsendFilterSmokeResultData(" + detectionId + "," + jsonstring + ")");
                string ack = ex.sendFilterSmokeResultData(detectionId, jsonstring);
                if (ack == null)
                {
                    sendAuthorizationDataWithVersion();
                    ack = ex.sendFilterSmokeResultData(detectionId, jsonstring);
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public bool sendSelfCheckData(int lx,object data, out string code, out string message)
        {
            message = "";
            try
            {
                string jsonstring="", ack="";
                jsonstring = new JObject((JObject)JsonConvert.DeserializeObject(ObjectToJson(data))).ToString();
                switch (lx)
                {
                    case 1:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendCoastDownCheckData(" + jsonstring + ")");
                        ack = ex.sendCoastDownCheckData(jsonstring);
                        break;
                    case 2:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendCoastDownCheckData(" + jsonstring + ")");
                        ack = ex.sendAdditionalPowerLossCheckData(jsonstring);
                        break;
                    case 3:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendAnalyserBaseCheckData(" + jsonstring + ")");
                        ack = ex.sendAnalyserBaseCheckData(jsonstring);
                        break;
                    case 4:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendAnalyserLeakCheckData(" + jsonstring + ")");
                        ack = ex.sendAnalyserLeakCheckData(jsonstring);
                        break;
                    case 5:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendAnalyserOxygenCheckData(" + jsonstring + ")");
                        ack = ex.sendAnalyserOxygenCheckData(jsonstring);
                        break;
                    case 6:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendAnalyserLowGasCheckData(" + jsonstring + ")");
                        ack = ex.sendAnalyserLowGasCheckData(jsonstring);
                        break;
                    case 7:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendFlowmeterCheckData(" + jsonstring + ")");
                        ack = ex.sendFlowmeterCheckData(jsonstring);
                        break;
                    case 8:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendSmokemeterCheckData(" + jsonstring + ")");
                        ack = ex.sendSmokemeterCheckData(jsonstring);
                        break;
                    case 9:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendWeathermeterCheckData(" + jsonstring + ")");
                        ack = ex.sendWeathermeterCheckData(jsonstring);
                        break;
                    case 10:
                        ini.INIIO.saveSocketLogInf("SEND:\r\nsendTachometerCheckData(" + jsonstring + ")");
                        ack = ex.sendTachometerCheckData(jsonstring);
                        break;
                }
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ack);
                JObject ja = (JObject)JsonConvert.DeserializeObject(ack);
                code = ja["resultCode"].ToString();
                if (code == "0")
                {
                    message = ja["message"].ToString();
                    return true;
                }
                else if (code == "-1")
                {
                    message = ja["message"].ToString();
                    return false;
                }
                else
                {
                    message = "token值获取失败";
                    return false;
                };
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-2";
                message = er.Message;
                return false;
            }
        }
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
        public struct photoInf
        {
            public string ip;
            public string port;
            public string detectionID;
            public int lx;
            public photoInf(string ip1,string port1,string detectionID1,int lx1)
            {
                ip = ip1;
                port = port1;
                detectionID = detectionID1;
                lx = lx1;
            }
        }
        public void takePhotoJx(string ip,string port,string detectionID,int lx)
        {
            photoInf photoinf = new photoInf(ip,port,detectionID,lx);
            Thread captureFrontPicture = new Thread(new ParameterizedThreadStart(takephotopicturethread));
            captureFrontPicture.Start(photoinf);
        }
        public void takephotopicturethread(object Photoinf)
        {
            photoInf photoinf = (photoInf)Photoinf;
            try
            {
                IPAddress HostIP = IPAddress.Parse(photoinf.ip);
                IPEndPoint point;
                Socket socket;
                HostIP = IPAddress.Parse(photoinf.ip);
                point = new IPEndPoint(HostIP, Int32.Parse(photoinf.port));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                socket.Send(Encoding.ASCII.GetBytes(photoinf.detectionID + "," + photoinf.lx.ToString()));
                socket.Close();
                ini.INIIO.saveSocketLogInf("江西联网拍照指令发送成功:\r\ndetectionID=" + photoinf.detectionID +
                    "\r\nlx=" + photoinf.lx.ToString() + "\r\nIP=" + photoinf.ip + "\r\nPORT=" + photoinf.port);
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("江西联网拍照发生异常:" + er.Message + "\r\ndetectionID=" + photoinf.detectionID +
                    "\r\nlx=" + photoinf.lx.ToString() + "\r\nIP=" + photoinf.ip + "\r\nPORT=" + photoinf.port);
            }
        }

    }
}
