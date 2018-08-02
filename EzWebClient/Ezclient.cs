using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ini;
using System.Net;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Threading;

namespace EzWebClient
{
    /// <summary>
    /// 附加功率损失检查记录(checked) POST /rest/additionalData/
    /// </summary>
    public class PowerLossData
    {
        public string path = "/rest/additionalData/";
        public string acdt25;
        public string acdt40;
        public string diw;
        public string endTime;
        public string id;
        public string insertTime;
        public string inspectionDate;
        public string lineNumber;
        public string plhp25;
        public string plhp40;
        public string remark;
        public string startTime;
        public string stationNumber;
        public string userId;
        public PowerLossData(string acdt25, string acdt40, string diw, string endTime, string id, string insertTime,
            string inspectionDate, string lineNumber, string plhp25, string plhp40, string remark, string startTime,
            string stationNumber, string userId)
        {
            this.acdt25 = acdt25;
            this.acdt40 = acdt40;
            this.diw = diw;
            this.endTime = endTime;
            this.id = id;
            this.insertTime = insertTime;
            this.inspectionDate = inspectionDate;
            this.lineNumber = lineNumber;
            this.plhp25 = plhp25;
            this.plhp40 = plhp40;
            this.remark = remark;
            this.startTime = startTime;
            this.stationNumber = stationNumber;
            this.userId = userId;
        }

    }
    /// <summary>
    /// 分析仪检查记录(checked) POST /rest/analyzerData/
    /// </summary>
    public class AnalyzerInspectionData
    {
        public string path = "/rest/analyzerData/";
        public string co2Concentration;
        public string co2Result;
        public string coConcentration;
        public string coResult;
        public string examinationResult;
        public string hcConcentration;
        public string hcResult;
        public string id;
        public string insertTime;
        public string inspectionDate;
        public string inspectionStartTime;
        public string lineNumber;
        public string noConcentration;
        public string noResult;
        public string o2Concentration;
        public string o2Result;
        public string pefValue;
        public string remark;
        public string stationNumber;
        public string type;
        public string userId;

        public string c3h8concentration;
        public string endtime;
        public AnalyzerInspectionData(string co2Concentration, string co2Result, string coConcentration, string coResult,
            string examinationResult, string hcConcentration, string hcResult, string id, string insertTime,
            string inspectionDate, string inspectionStartTime, string lineNumber, string noConcentration,
            string noResult, string o2Concentration, string o2Result, string pefValue, string remark,
            string stationNumber, string type, string userId,string c3h8concentration, string endtime)
        {
            this.co2Concentration = co2Concentration;
            this.co2Result = co2Result;
            this.coConcentration = coConcentration;
            this.coResult = coResult;
            this.examinationResult = examinationResult;
            this.hcConcentration = hcConcentration;
            this.hcResult = hcResult;
            this.id = id;
            this.insertTime = insertTime;
            this.inspectionDate = inspectionDate;
            this.inspectionStartTime = inspectionStartTime;
            this.lineNumber = lineNumber;
            this.noConcentration = noConcentration;
            this.noResult = noResult;
            this.o2Concentration = o2Concentration;
            this.o2Result = o2Result;
            this.pefValue = pefValue;
            this.remark = remark;
            this.stationNumber = stationNumber;
            this.type = type;
            this.userId = userId;
            this.c3h8concentration = c3h8concentration;
            this.endtime = endtime;
        }

    }
    /// <summary>
    /// 分析仪氧量程检查记录(checked)
    /// </summary>
    public class AnalyzerOxygenRangeData
    {
        public string path = "/rest/oxygenRangeData/";
        public string examinationResult;
        public string id;
        public string insertTime;
        public string inspectionDate;
        public string inspectionStartTime;
        public string lineNumber;
        public string oxygenRangeError;
        public string oxygenRangeMValue;
        public string oxygenRangeValue;
        public string remark;
        public string stationNumber;
        public string type;
        public string userId;

        public string endtime;
        public AnalyzerOxygenRangeData(string examinationResult, string id, string insertTime, string inspectionDate,
            string inspectionStartTime, string lineNumber, string oxygenRangeError, string oxygenRangeMValue, string oxygenRangeValue,
             string remark, string stationNumber, string type, string userId,string endtime)
        {
            this.examinationResult = examinationResult;
            this.id = id;
            this.insertTime = insertTime;
            this.inspectionDate = inspectionDate;
            this.inspectionStartTime = inspectionStartTime;
            this.lineNumber = lineNumber;
            this.oxygenRangeError = oxygenRangeError;
            this.oxygenRangeMValue = oxygenRangeMValue;
            this.oxygenRangeValue = oxygenRangeValue;
            this.inspectionStartTime = inspectionStartTime;
            this.remark = remark;
            this.stationNumber = stationNumber;
            this.type = type;
            this.userId = userId;
            this.endtime = endtime;
        }

    }
    /// <summary>
    /// 外检登录信息(checked)
    /// </summary>
    public class ExternalLoginInformation
    {
        public string path = "/rest/externalLoginInfos/";
        public string stationnumber;
        public string afterTreatmentEquipment;
        public string afterTreatmentType;
        public string cascadeExhaust;
        public string cylinders;
        public string driveMode;
        public string egr;
        public string electronicControl;
        public string emissionStandard;
        public string engineDisplacement;
        public string engineModel;
        public string engineNumber;
        public string exemption;
        public string fuelEvaporation;
        public string fuelSupply;
        public string fuelType;
        public string id;
        public string initialRegistrationDate;
        public string inspectionreport;
        public string intakeMode;
        public string licensePlateCategory;
        public string licensePlateColor;
        public string licensePlateNumber;
        public string liquidLeakage;
        public string maximumMass;
        public string mileageReading;
        public string obd;
        public string obdCommunication;
        public string obdFault;
        public string obdFaultCode;
        public string ownerAddress;
        public string ownerPhone;
        public string prisonSteering;
        public string ratedEnginePower;
        public string ratedEngineSpeed;
        public string referenceQuality;
        public string specialDevice;
        public string transmissionType;
        public string unitName;
        public string useProperties;
        public string vehicleIdentificationN;
        public string vehicleModel;
        public string vehicleType;
        public string visualInspectionResults;
        public ExternalLoginInformation(string stationnumber,string afterTreatmentEquipment, string afterTreatmentType, string cascadeExhaust,
            string cylinders, string driveMode, string egr, string electronicControl,
            string emissionStandard, string engineDisplacement, string engineModel,
            string engineNumber, string exemption, string fuelEvaporation, string fuelSupply,
            string fuelType, string id,string initialRegistrationDate, string inspectionreport, string intakeMode,
            string licensePlateCategory, string licensePlateColor, string licensePlateNumber,
            string liquidLeakage, string maximumMass, string mileageReading, string obd,
            string obdCommunication, string obdFault, string obdFaultCode, string ownerAddress,
            string ownerPhone, string prisonSteering, string ratedEnginePower, string ratedEngineSpeed,
            string referenceQuality, string specialDevice, string transmissionType, string unitName,
            string useProperties, string vehicleIdentificationN, string vehicleModel, string vehicleType,
            string visualInspectionResults)
        {
            this.stationnumber = stationnumber;
            this.afterTreatmentEquipment = afterTreatmentEquipment;
            this.afterTreatmentType = afterTreatmentType;
            this.cascadeExhaust = cascadeExhaust;
            this.cylinders = cylinders;
            this.driveMode = driveMode;
            this.egr = egr;
            this.electronicControl = electronicControl;
            this.emissionStandard = emissionStandard;
            this.engineDisplacement = engineDisplacement;
            this.engineModel = engineModel;
            this.engineNumber = engineNumber;
            this.exemption = exemption;
            this.fuelEvaporation = fuelEvaporation;
            this.fuelSupply = fuelSupply;
            this.fuelType = fuelType;
            this.id = id;
            this.initialRegistrationDate = initialRegistrationDate;
            this.inspectionreport = inspectionreport;
            this.intakeMode = intakeMode;
            this.licensePlateCategory = licensePlateCategory;
            this.licensePlateColor = licensePlateColor;
            this.licensePlateNumber = licensePlateNumber;
            this.liquidLeakage = liquidLeakage;
            this.maximumMass = maximumMass;
            this.mileageReading = mileageReading;
            this.obd = obd;
            this.obdCommunication = obdCommunication;
            this.obdFault = obdFault;
            this.obdFaultCode = obdFaultCode;
            this.ownerAddress = ownerAddress;
            this.ownerPhone = ownerPhone;
            this.prisonSteering = prisonSteering;
            this.ratedEnginePower = ratedEnginePower;
            this.ratedEngineSpeed = ratedEngineSpeed;
            this.referenceQuality = referenceQuality;
            this.specialDevice = specialDevice;
            this.transmissionType = transmissionType;
            this.unitName = unitName;
            this.useProperties = useProperties;
            this.vehicleIdentificationN = vehicleIdentificationN;
            this.vehicleModel = vehicleModel;
            this.vehicleType = vehicleType;
            this.visualInspectionResults = visualInspectionResults;
        }
    }
    /// <summary>
    ///    检测线信息
    /// </summary>
    public class EzBasCheckline
    {
        public string path = "/rest/checklines/";
        public string belongtoStation;        
        public string catharometerEq;        
        public string chassisEq;        
        public string effectiveDate;        
        public string flowmeterEq;        
        public string id;        
        public string lineName;        
        public string lineState;        
        public string lineType;        
        public string oilEq;        
        public string onlineDate;        
        public string smokemeterEq;        
        public string tachometerEq;        
        public string weatherEq;        
        public string workingSoftware;
        public EzBasCheckline(string belongtoStation, string catharometerEq, string chassisEq, 
            string effectiveDate, string flowmeterEq, string id, string lineName, 
            string lineState, string lineType, string oilEq, string onlineDate, 
            string smokemeterEq, string tachometerEq, string weatherEq, string workingSoftware)
        {
            this.belongtoStation = belongtoStation;            
            this.catharometerEq = catharometerEq;            
            this.chassisEq = chassisEq;            
            this.effectiveDate = effectiveDate;            
            this.flowmeterEq = flowmeterEq;
            this.id = id;            
            this.lineName = lineName;            
            this.lineState = lineState;            
            this.lineType = lineType;            
            this.oilEq = oilEq;            
            this.onlineDate = onlineDate;            
            this.smokemeterEq = smokemeterEq;            
            this.tachometerEq = tachometerEq;            
            this.weatherEq = weatherEq;            
            this.workingSoftware = workingSoftware;
        }
    }
    /// <summary>
    /// 检验机构信息
    /// </summary>
    public class EzBasCheckstation
    {
        public string path = "/rest/checkstations/";
        public string checklineNum;        
        public string fzrPhone;        
        public string hbjcfzr;        
        public string id;        
        public string legalPerson;        
        public string networkingDate;        
        public string permitNum;        
        public string qualificationValidDate;        
        public string registDate;        
        public string stationAddress;        
        public string stationName;        
        public string stationState;
        public EzBasCheckstation(string checklineNum, string fzrPhone, string hbjcfzr, 
            string id, string legalPerson, string networkingDate, 
            string permitNum, string qualificationValidDate, string registDate, 
            string stationAddress, string stationName, string stationState)
        {
            this.checklineNum = checklineNum;            
            this.fzrPhone = fzrPhone;            
            this.hbjcfzr = hbjcfzr;            
            this.id = id;            
            this.legalPerson = legalPerson;            
            this.networkingDate = networkingDate;            
            this.permitNum = permitNum;            
            this.qualificationValidDate = qualificationValidDate;            
            this.registDate = registDate;            
            this.stationAddress = stationAddress;            
            this.stationName = stationName;            
            this.stationState = stationState;
        }

    }
    /// <summary>
    /// 车辆信息
    /// </summary>
    public class EzCodModelslibrarycatalogue
    {
        public string path = "/rest/carInfos/";
        public string bsqxs;        
        public string carNum;        
        public string carcolor;        
        public string cllb;        
        public string edgl;        
        public string edglzs;        
        public string engineCylinder;        
        public string engineDisp;        
        public string engineFac;        
        public string enginenumber;        
        public string fdate;
        public string gkdate;        
        public string hasAftertreatmentDevice;        
        public string hasEgr;        
        public string hasElectronicControl;        
        public string hasEsp;
        public string hasFuelControlDevice;        
        public string hasObd;        
        public string id;        
        public string jqfs;        
        public string jzzl;        
        public string manufactureDate;        
        public string odometerValue;        
        public string operationnature;        
        public string ownerAddress;        
        public string ownerName;        
        public string ownerPhone;        
        public string pf;        
        public string plateType;        
        public string pqhclxs;        
        public string qdfs;
        public string qdltqy;     
        public string rlggxs;        
        public string rllx;        
        public string sb;        
        public string scqymc;        
        public string vId;        
        public string veModel;        
        public string vehicleSerialNumber;        
        public string vehicleState;        
        public string vin;
        public string xxgkbh;      
        public string zdzzl;
        public EzCodModelslibrarycatalogue(string bsqxs, string carNum, string carcolor, string cllb, string edgl, 
            string edglzs, string engineCylinder, string engineDisp, string engineFac, string enginenumber,
            string fdate,string gkdate, string hasAftertreatmentDevice, string hasEgr, string hasElectronicControl, 
            string hasEsp, string hasFuelControlDevice, string hasObd, string id, string jqfs, string jzzl, 
            string manufactureDate, string odometerValue, string operationnature, string ownerAddress, 
            string ownerName, string ownerPhone, string pf, string plateType, string pqhclxs, string qdfs,string qdltqy,
            string rlggxs, string rllx, string sb, string scqymc, string vId, string veModel, string vehicleSerialNumber,
            string vehicleState, string vin,string xxgkbh, string zdzzl)
        {
            this.bsqxs = bsqxs;            
            this.carNum = carNum;            
            this.carcolor = carcolor;            
            this.cllb = cllb;            
            this.edgl = edgl;            
            this.edglzs = edglzs;            
            this.engineCylinder = engineCylinder;            
            this.engineDisp = engineDisp;            
            this.engineFac = engineFac;            
            this.enginenumber = enginenumber;            
            this.fdate = fdate;
            this.gkdate = gkdate;            
            this.hasAftertreatmentDevice = hasAftertreatmentDevice;            
            this.hasEgr = hasEgr;            
            this.hasElectronicControl = hasElectronicControl;            
            this.hasEsp = hasEsp;            
            this.hasFuelControlDevice = hasFuelControlDevice;            
            this.hasObd = hasObd;            
            this.id = id;            
            this.jqfs = jqfs;            
            this.jzzl = jzzl;            
            this.manufactureDate = manufactureDate;            
            this.odometerValue = odometerValue;            
            this.operationnature = operationnature;            
            this.ownerAddress = ownerAddress;            
            this.ownerName = ownerName;            
            this.ownerPhone = ownerPhone;            
            this.pf = pf;            
            this.plateType = plateType;            
            this.pqhclxs = pqhclxs;            
            this.qdfs = qdfs;
            this.qdltqy = qdltqy;            
            this.rlggxs = rlggxs;            
            this.rllx = rllx;            
            this.sb = sb;            
            this.scqymc = scqymc;            
            this.vId = vId;            
            this.veModel = veModel;            
            this.vehicleSerialNumber = vehicleSerialNumber;            
            this.vehicleState = vehicleState;            
            this.vin = vin;
            this.xxgkbh = xxgkbh;            
            this.zdzzl = zdzzl;
        }


    }
    /// <summary>
    /// 双怠速法检验结果(checked)
    /// </summary>
    public class EzIfaJcDoubleidledata
    {
        public string path = "/rest/doubleIdleData/";
        public string airPressure;
        
        public string coHighDetermine;
        
        public string coHighLimitValue;
        
        public string coLowDetermine;
        
        public string coLowLimitValue;
        
        public string cohighValue;
        
        public string colowValue;
        
        public string excessAirCoefficientMax;
        
        public string excessAirCoefficientMin;
        
        public string excessAirCoefficientVal;
        
        public string hcHighDetermine;
        
        public string hcHighLimitValue;
        
        public string hcLowDetermine;
        
        public string hcLowLimitValue;
        
        public string hchighValue;
        
        public string hclowValue;
        
        public string hrotateSpeed;
        
        public string humidity;
        
        public string id;
        
        public string lambdaValue;
        
        public string lrotateSpeed;
        
        public string oilTemperature;
        
        public string tempreture;

        public string stationNumber;
        public string lineNumber;
        public string inspectionreport;
        public string checktimeStart;
        public string checktimeEnd;

        public EzIfaJcDoubleidledata(string airPressure, string coHighDetermine, string coHighLimitValue, 
            string coLowDetermine, string coLowLimitValue, string cohighValue, string colowValue, 
            string excessAirCoefficientMax, string excessAirCoefficientMin, string excessAirCoefficientVal, 
            string hcHighDetermine, string hcHighLimitValue, string hcLowDetermine, string hcLowLimitValue, 
            string hchighValue, string hclowValue, string hrotateSpeed, string humidity, string id, 
            string lambdaValue, string lrotateSpeed, string oilTemperature, string tempreture,
            string stationNumber, string lineNumber, string inspectionreport, string checktimeStart, string checktimeEnd)
        {
            this.airPressure = airPressure;
            
            this.coHighDetermine = coHighDetermine;
            
            this.coHighLimitValue = coHighLimitValue;
            
            this.coLowDetermine = coLowDetermine;
            
            this.coLowLimitValue = coLowLimitValue;
            
            this.cohighValue = cohighValue;
            
            this.colowValue = colowValue;
            
            this.excessAirCoefficientMax = excessAirCoefficientMax;
            
            this.excessAirCoefficientMin = excessAirCoefficientMin;
            
            this.excessAirCoefficientVal = excessAirCoefficientVal;
            
            this.hcHighDetermine = hcHighDetermine;
            
            this.hcHighLimitValue = hcHighLimitValue;
            
            this.hcLowDetermine = hcLowDetermine;
            
            this.hcLowLimitValue = hcLowLimitValue;
            
            this.hchighValue = hchighValue;
            
            this.hclowValue = hclowValue;
            
            this.hrotateSpeed = hrotateSpeed;
            
            this.humidity = humidity;
            
            this.id = id;
            
            this.lambdaValue = lambdaValue;
            
            this.lrotateSpeed = lrotateSpeed;
            
            this.oilTemperature = oilTemperature;
            
            this.tempreture = tempreture;
            this.stationNumber = stationNumber;
            this.lineNumber = lineNumber;
            this.inspectionreport = inspectionreport;
            this.checktimeStart = checktimeStart;
            this.checktimeEnd = checktimeEnd;

        }
    }
    /// <summary>
    /// 双怠速法检验过程数据(checked)
    /// </summary>
    public class EzIfaJcDoubleidlelog
    {
        public string path = "/rest/doubleIdleLog/";
        public string analysEro2;
        
        public string conditionType;
        
        public string excessAirCoefficientIn;
        
        public string flowCo;
        
        public string flowCo2;
        
        public string flowHc;
        
        public string id;
        
        public string rotateSpeed;
        
        public string samplingSequence;
        
        public string wholeTimeSequence;
        public string stationNumber;
        public string lineNumber;
        public string inspectionreport;
        public string oilTemperature;

        public EzIfaJcDoubleidlelog(string analysEro2, string conditionType, string excessAirCoefficientIn,
            string flowCo, string flowCo2, string flowHc, string id, string rotateSpeed,
            string samplingSequence, string wholeTimeSequence,string stationNumber, string lineNumber, string inspectionreport, string oilTemperature)
        {
            this.analysEro2 = analysEro2;
            
            this.conditionType = conditionType;
            
            this.excessAirCoefficientIn = excessAirCoefficientIn;
            
            this.flowCo = flowCo;
            
            this.flowCo2 = flowCo2;
            
            this.flowHc = flowHc;
            
            this.id = id;
            
            this.rotateSpeed = rotateSpeed;
            
            this.samplingSequence = samplingSequence;
            
            this.wholeTimeSequence = wholeTimeSequence;
            this.stationNumber = stationNumber;
            this.lineNumber = lineNumber;
            this.inspectionreport = inspectionreport;
            this.oilTemperature = oilTemperature;

        }
    }
    /// <summary>
    /// 自由加速滤纸烟度法检验数据
    /// </summary>
    public class FilterPaperMethodLog
    {
        public string path = "/rest/filterPaper/";
        public string averageValue;
        
        public string emissionLimits;
        
        public string id;
        
        public string insertTime;
        
        public string remark;
        
        public string result;
        
        public string userId;
        
        public string value1;
        
        public string value2;
        
        public string value3;
        
        public string value4;


        public string idleSpeed;



        public FilterPaperMethodLog(string averageValue, string emissionLimits, string id, 
            string insertTime, string remark, string result, string userId,
            string value1, string value2, string value3, string value4
            )
        {
            this.averageValue = averageValue;
            
            this.emissionLimits = emissionLimits;
            
            this.id = id;
            
            this.insertTime = insertTime;
            
            this.remark = remark;
            
            this.result = result;
            
            this.userId = userId;
            
            this.value1 = value1;
            
            this.value2 = value2;
            
            this.value3 = value3;
            
            this.value4 = value4;


        }
    }
    /// <summary>
    /// 自由加速不透光烟度法检验过程中采集的检验过程数据(checked)
    /// </summary>
    public class EzIfaJcLightproofdata
    {
        public string path = "/rest/lightProofData/";
        public string stationnumber;
        public string linenumber;
        public string checktimestart;
        public string checktimeend;
        public string inserttime;
        public string inspectionreport;
        public string wholetimesequence;
        public string engineSpeed;       
        public string id;       
        public string opacitySmokeValue;        
        public string samplingTiming;        
        public string userid;        
        public string workingClass;

        public EzIfaJcLightproofdata(string stationnumber, string linenumber, string checktimestart, 
            string checktimeend, string inserttime, string inspectionreport, string wholetimesequence,
            string engineSpeed, string id, string opacitySmokeValue,
            string samplingTiming, string userid, string workingClass)
        {
            this.stationnumber = stationnumber;
            this.linenumber = linenumber;
            this.checktimestart = checktimestart;
            this.checktimeend = checktimeend;
            this.inserttime = inserttime;
            this.inspectionreport = inspectionreport;
            this.wholetimesequence = wholetimesequence;
            this.engineSpeed = engineSpeed;            
            this.id = id;
            this.opacitySmokeValue = opacitySmokeValue;           
            this.samplingTiming = samplingTiming;            
            this.userid = userid;            
            this.workingClass = workingClass;
        }
    }
    /// <summary>
    /// 自由加速不透光烟度法检验数据(checked)
    /// </summary>
    public class LightProofSmokeLog
    {
        public string path = "/rest/lightProofSmokeLog/";
        public string averageValue;
        
        public string emissionLimits;
        
        public string id;
        
        public string idleSpeed;
        
        public string insertTime;
        
        public string remark;
        
        public string result;
        
        public string userId;
        
        public string value1;
        
        public string value2;
        
        public string value3;
        
        public string value4;

        public string stationnumber;
        public string linenumber;
        public string inspectionreport;
        public string wd;
        public string sd;
        public string qy;
        public string inspectionstartime;
        public string endtime;
        public LightProofSmokeLog(string averageValue, string emissionLimits, string id, string idleSpeed, 
            string insertTime, string remark, string result, string userId, string value1, 
            string value2, string value3, string value4,
            string stationnumber, string linenumber, string inspectionreport, string wd,
            string sd, string qy, string inspectionstartime, string endtime)
        {
            this.averageValue = averageValue;
            
            this.emissionLimits = emissionLimits;
            
            this.id = id;
            
            this.idleSpeed = idleSpeed;
            
            this.insertTime = insertTime;
            
            this.remark = remark;
            
            this.result = result;
            
            this.userId = userId;
            
            this.value1 = value1;
            
            this.value2 = value2;
            
            this.value3 = value3;
            
            this.value4 = value4;

            this.stationnumber = stationnumber;
            this.linenumber = linenumber;
            this.inspectionreport = inspectionreport;
            this.wd = wd;
            this.sd = sd;
            this.qy = qy;
            this.inspectionstartime = inspectionstartime;
            this.endtime = endtime;

        }
    }
    /// <summary>
    ///    检验信息(checked)
    /// </summary>
    public class InspectionInformation
    {
        public string path = "/rest/inspectionInfos/";
        public string examinationResult;        
        public string id;        
        public string inspectionEndTime;        
        public string inspectionMethod;        
        public string inspectionPersonnel;        
        public string inspectionReport;        
        public string inspectionStartTime;        
        public string inspectionTimes;        
        public string lineNumber;        
        public string stationNumber;        
        public string testType;
        public string carnum;
        public string carcolor;
        public string platetype;
        public string vin;
        public string cllb;
        public string operationnature;
        public string fdate;
        public string manufacturedate;
        public string vemodel;
        public string vid;
        public string enginefac;
        public string pf;
        public string rllx;
        public string bsqxs;
        public string jqfs;
        public string enginedisp;
        public string rlggxs;
        public string edglzs;
        public string edgl;
        public string qdfs;
        public string zdzzl;
        public string jzzl;
        public string odometervalue;
        public string enginecylinder;
        public string hasegr;
        public string hasfuelcontroldevice;
        public string hasaftertreatmentdevice;
        public string pqhclxs;
        public string hasobd;
        public string insertTime;
        public string cllx;
        public string remark;
        public string userId;

        public InspectionInformation(string examinationResult, string id, string inspectionEndTime, string inspectionMethod, 
            string inspectionPersonnel, string inspectionReport, string inspectionStartTime, string inspectionTimes, 
            string lineNumber, string stationNumber, string testType,
            string carNum, string carcolor, string plateType, string vin, string cllb, string operationnature,
            string fdate, string manufactureDate, string veModel, string vId, string engineFac,
            string pf, string rllx, string bsqxs, string jqfs, string engineDisp, string rlggxs,
            string edglzs, string edgl, string qdfs, string zdzzl, string jzzl, string odometerValue,
            string engineCylinder, string hasEgr, string hasFuelControlDevice,
            string hasAftertreatmentDevice, string pqhclxs, string hasObd,string insertTime,string cllx,string remark,string userId
            )
        {
            this.examinationResult = examinationResult;            
            this.id = id;            
            this.inspectionEndTime = inspectionEndTime;            
            this.inspectionMethod = inspectionMethod;            
            this.inspectionPersonnel = inspectionPersonnel;            
            this.inspectionReport = inspectionReport;            
            this.inspectionStartTime = inspectionStartTime;            
            this.inspectionTimes = inspectionTimes;            
            this.lineNumber = lineNumber;            
            this.stationNumber = stationNumber;            
            this.testType = testType;
            this.carnum = carNum;
            this.carcolor = carcolor;
            this.platetype = plateType;
            this.vin = vin;
            this.cllb = cllb;
            this.operationnature = operationnature;
            this.fdate = fdate;
            this.manufacturedate = manufactureDate;
            this.vemodel = veModel;
            this.vid = vId;
            this.enginefac = engineFac;
            this.pf = pf;
            this.rllx = rllx;
            this.bsqxs = bsqxs;
            this.jqfs = jqfs;
            this.enginedisp = engineDisp;
            this.rlggxs = rlggxs;
            this.edglzs = edglzs;
            this.edgl = edgl;
            this.qdfs = qdfs;
            this.zdzzl = zdzzl;
            this.jzzl = jzzl;
            this.odometervalue = odometerValue;
            this.enginecylinder = engineCylinder;
            this.hasegr = hasEgr;
            this.hasfuelcontroldevice = hasFuelControlDevice;
            this.hasaftertreatmentdevice = hasAftertreatmentDevice;
            this.pqhclxs = pqhclxs;
            this.hasobd = hasObd;
            this.insertTime = insertTime;
            this.cllx = cllx;
            this.remark = remark;
            this.userId = userId;

        }
    }
    /// <summary>
    /// 泄露检查记录(checked)
    /// </summary>
    public class LeakCheckData
    {
        public string path = "/rest/leakCheckData/";
        public string examinationResult;        
        public string id;        
        public string insertTime;        
        public string inspectionDate;        
        public string inspectionStartTime;        
        public string lineNumber;        
        public string remark;        
        public string stationNumber;        
        public string userId;
        public string endtime;
        public LeakCheckData(string examinationResult, string id, string insertTime, string inspectionDate,
            string inspectionStartTime, string lineNumber, string remark, string stationNumber, string userId,string endtime)
        {
            this.examinationResult = examinationResult;
            
            this.id = id;
            
            this.insertTime = insertTime;
            
            this.inspectionDate = inspectionDate;
            
            this.inspectionStartTime = inspectionStartTime;
            
            this.lineNumber = lineNumber;
            
            this.remark = remark;
            
            this.stationNumber = stationNumber;
            
            this.userId = userId;
            this.endtime = endtime;
        }
    }
    /// <summary>
    /// 加载减速工况法检验数据(checked)
    /// </summary>
    public class EzIfaJcLoaddowndata
    {
        public string path = "/rest/loadDownData/";
        public string inspectionreport;
        public string checktimeEnd;
        public string lineNumber;
        public string stationNumber;
        public string checktimeStart;
        public string airPressure;        
        public string emissionDetermination;        
        public string emissionLimit;        
        public string engineRatedLowLimit;        
        public string engineRatedSpeedLimit;        
        public string humidity;        
        public string id;        
        public string insertTime;        
        public string maximumWheelPowerLimit;        
        public string power;        
        public string ratedEngineSpeed;        
        public string remark;        
        public string smokek100;        
        public string smokek80;        
        public string smokek90;        
        public string tempreture;        
        public string userId;

        public EzIfaJcLoaddowndata(string inspectionreport, string checktimeEnd, string lineNumber, string stationNumber,string checktimeStart,
            string airPressure, string emissionDetermination, string emissionLimit, 
            string engineRatedLowLimit, string engineRatedSpeedLimit, string humidity, string id, string insertTime, 
            string maximumWheelPowerLimit, string power, string ratedEngineSpeed, string remark, string smokek100,
            string smokek80, string smokek90, string tempreture, string userId)
        {
            this.inspectionreport = inspectionreport;
            this.checktimeEnd = checktimeEnd;
            this.lineNumber = lineNumber;
            this.stationNumber = stationNumber;
            this.checktimeStart = checktimeStart;

            this.airPressure = airPressure;
            
            this.emissionDetermination = emissionDetermination;
            
            this.emissionLimit = emissionLimit;
            
            this.engineRatedLowLimit = engineRatedLowLimit;
            
            this.engineRatedSpeedLimit = engineRatedSpeedLimit;
            
            this.humidity = humidity;
            
            this.id = id;
            
            this.insertTime = insertTime;
            
            this.maximumWheelPowerLimit = maximumWheelPowerLimit;
            
            this.power = power;
            
            this.ratedEngineSpeed = ratedEngineSpeed;
            
            this.remark = remark;
            
            this.smokek100 = smokek100;
            
            this.smokek80 = smokek80;
            
            this.smokek90 = smokek90;
            
            this.tempreture = tempreture;
            
            this.userId = userId;
        }
    }
    /// <summary>
    /// 加载减速工况法检验过程中数据(checked)
    /// </summary>
    public class EzIfaJcLoaddownlog
    {
        public string path = "/rest/loadDownLog/";
        public string linenumber;
        public string envirairpressure;
        public string envirhumidity;
        public string envirtemperature;
        public string inspectionreport;
        public string cormaxpower;
        public string powercorrect;
        public string stationnumber;

        public string conditionType;        
        public string dynamometerLoad;        
        public string id;        
        public string inspectornum;        
        public string opticalAbsorptionCoefficient;
        public string remark;        
        public string rotatespeed;        
        public string speedpersec;        
        public string torsion;        
        public string wholeTimeSequence;

        public EzIfaJcLoaddownlog(string linenumber, string envirairpressure, string envirhumidity, string envirtemperature,
            string inspectionreport, string cormaxpower, string powercorrect, string stationnumber,
            string conditionType, string dynamometerLoad, string id, string inspectornum, 
            string opticalAbsorptionCoefficient, string remark, string rotatespeed, string speedpersec, 
            string torsion, string wholeTimeSequence)
        {
            this.linenumber = linenumber;
            this.envirairpressure = envirairpressure;
            this.envirhumidity = envirhumidity;
            this.envirtemperature = envirtemperature;
            this.inspectionreport = inspectionreport;
            this.cormaxpower = cormaxpower;
            this.powercorrect = powercorrect;
            this.stationnumber = stationnumber;

            this.conditionType = conditionType;
            
            this.dynamometerLoad = dynamometerLoad;
            
            this.id = id;
            
            this.inspectornum = inspectornum;
            
            this.opticalAbsorptionCoefficient = opticalAbsorptionCoefficient;
            
            this.remark = remark;
            
            this.rotatespeed = rotatespeed;
            
            this.speedpersec = speedpersec;
            
            this.torsion = torsion;
            
            this.wholeTimeSequence = wholeTimeSequence;

        }
    }
    /// <summary>
    /// 加载滑行检查记录(checked)
    /// </summary>
    public class LoadSlideCheckData
    {
        public string path="/rest/loadSlideCheckData/";
        public string acdt25;
        
        public string acdt40;
        
        public string ccdt25;
        
        public string ccdt40;
        
        public string diw;
        
        public string id;
        
        public string ihp25;
        
        public string ihp40;
        
        public string insertTime;
        
        public string inspectionDate;
        
        public string lineNumber;
        
        public string plhp25;
        
        public string plhp40;
        
        public string remark;
        
        public string result;
        
        public string result25;
        
        public string result40;
        
        public string startTime;
        
        public string stationNumber;
        
        public string userId;
        public string endtime;

        public LoadSlideCheckData(string acdt25, string acdt40, string ccdt25, string ccdt40, string diw, string id, 
            string ihp25, string ihp40, string insertTime, string inspectionDate, string lineNumber, string plhp25,
            string plhp40, string remark, string result, string result25, string result40, string startTime, 
            string stationNumber, string userId,string endtime)
        {
            this.acdt25 = acdt25;
            
            this.acdt40 = acdt40;
            
            this.ccdt25 = ccdt25;
            
            this.ccdt40 = ccdt40;
            
            this.diw = diw;
            
            this.id = id;
            
            this.ihp25 = ihp25;
            
            this.ihp40 = ihp40;
            
            this.insertTime = insertTime;
            
            this.inspectionDate = inspectionDate;
            
            this.lineNumber = lineNumber;
            
            this.plhp25 = plhp25;
            
            this.plhp40 = plhp40;
            
            this.remark = remark;
            
            this.result = result;
            
            this.result25 = result25;
            
            this.result40 = result40;
            
            this.startTime = startTime;
            
            this.stationNumber = stationNumber;
            
            this.userId = userId;
            this.endtime = endtime;

        }
    }
    /// <summary>
    /// 低标气检查记录(checked)
    /// </summary>
    public class LowMarkGasData
    {
        public string path = "/rest/lowMarkGasData/";
        public string co2Concentration;
        
        public string co2Result;
        
        public string coConcentration;
        
        public string coResult;
        
        public string examinationResult;
        
        public string hcConcentration;
        
        public string hcResult;
        
        public string id;
        
        public string insertTime;
        
        public string inspectionDate;
        
        public string inspectionStartTime;
        
        public string lineNumber;
        
        public string noConcentration;
        
        public string noResult;
        
        public string o2Concentration;
        
        public string o2Result;
        
        public string pefValue;
        
        public string remark;
        
        public string stationNumber;
        
        public string type;
        
        public string userId;

        public string c3h8concentration;
        public string endtime;

        public LowMarkGasData(string co2Concentration, string co2Result, string coConcentration, string coResult,
            string examinationResult, string hcConcentration, string hcResult, string id, string insertTime,
            string inspectionDate, string inspectionStartTime, string lineNumber, string noConcentration,
            string noResult, string o2Concentration, string o2Result, string pefValue, string remark,
            string stationNumber, string type, string userId,string c3h8concentration, string endtime)
        {
            this.co2Concentration = co2Concentration;
            
            this.co2Result = co2Result;
            
            this.coConcentration = coConcentration;
            
            this.coResult = coResult;
            
            this.examinationResult = examinationResult;
            
            this.hcConcentration = hcConcentration;
            
            this.hcResult = hcResult;
            
            this.id = id;
            
            this.insertTime = insertTime;
            
            this.inspectionDate = inspectionDate;
            
            this.inspectionStartTime = inspectionStartTime;
            
            this.lineNumber = lineNumber;
            
            this.noConcentration = noConcentration;
            
            this.noResult = noResult;
            
            this.o2Concentration = o2Concentration;
            
            this.o2Result = o2Result;
            
            this.pefValue = pefValue;
            
            this.remark = remark;
            
            this.stationNumber = stationNumber;
            
            this.type = type;
            
            this.userId = userId;
            this.c3h8concentration = c3h8concentration;
            this.endtime = endtime;

        }
    }
    /// <summary>
    /// 检验人员信息
    /// </summary>
    public class EzTestPerson
    {
        public string path = "/rest/persons/";
        public string belongtoStation;
        
        public string educationLevels;
        
        public string id;
        
        public string name;
        
        public string position;
        
        public string state;
        
        public string workingDate;

        public EzTestPerson(string belongtoStation, string educationLevels, string id, string name, string position,
            string state, string workingDate)
        {
            this.belongtoStation = belongtoStation;
            
            this.educationLevels = educationLevels;
            
            this.id = id;
            
            this.name = name;
            
            this.position = position;
            
            this.state = state;
            
            this.workingDate = workingDate;

        }
    }
    /// <summary>
    /// 稳态工况法检验数据(checked)
    /// </summary>
    public class SteadyStateMethodData
    {
        public string path = "/rest/steadyStateMethodData/";
        public string ambientTemperature;//环境温度
public string atmospheric;//大气压
public string coDetermineFive;//5025co排放判定
public string coDetermineTwo;//2540co排放判定
public string coLimitValueFive;//5025co排放限值
public string coLimitValueTwo;//2540co排放限值
public string coResultFive;//5025co排放结果
public string coResultTwo;//2540co排放结果
public string endtime;//结束时间
public string enginespeedfive;//5025工况发动机转速
public string enginespeedtwo;//2540工况发动机转速
public string hcDetermineFive;//5025HC排放判定
public string hcDetermineTwo;//2540HC排放判定
public string hcLimitValueFive;//5025HC排放限值
public string hcLimitValueTwo;//2540HC排放限值
public string hcResultFive;//5025HC排放结果
public string hcResultTwo;//2540HC排放结果
public string id;//主键
public string inspectionreport;//检测报告编号
public string inspectionstartime;//开始时间
public string linenumber;//检测线编号
public string noDetermineFive;//5025no排放判定
public string noDetermineTwo;//2540no排放判定
public string noLimitValueFive;//5025no排放限值
public string noLimitValueTwo;//2540no排放限值
public string noResultFive;//5025no排放结果
public string noResultTwo;//2540no排放结果
public string relativeHumidity;//相对湿度
public string stationnumber;//检测站编号
public string temperaturefive;//5025工况机油油温
public string temperaturetwo;//2540工况机油油温



        public SteadyStateMethodData(string stationNumber, string inspectionReport, string lineNumber, string hcResultFive, 
            string coResultFive, string noResultFive, string engineSpeedFive, string temperatureFive,string hcResultTwo,
            string coResultTwo, string noResultTwo, string engineSpeedTwo, string temperatureTwo,string hcLimitValueFive,
            string coLimitValueFive, string noLimitValueFive, string hcLimitValueTwo, string coLimitValueTwo, 
            string noLimitValueTwo, string hcDetermineFive, string coDetermineFive, string noDetermineFive, 
            string hcDetermineTwo, string coDetermineTwo, string noDetermineTwo, string ambientTemperature,
            string relativeHumidity, string atmospheric, string inspectionstartime, string endTime,string id)
        {
            this.stationnumber = stationNumber;
            this.inspectionreport = inspectionReport;
            this.linenumber = lineNumber;
            this.hcResultFive = hcResultFive;
            this.coResultFive = coResultFive;//
            this.noResultFive = noResultFive;
            this.enginespeedfive = engineSpeedFive;
            this.temperaturefive = temperatureFive;
            this.hcResultTwo = hcResultTwo;
            this.coResultTwo = coResultTwo;//
            this.noResultTwo = noResultTwo;
            this.enginespeedtwo = engineSpeedTwo;
            this.temperaturetwo = temperatureTwo;
            this.hcLimitValueFive = hcLimitValueFive;
            this.coLimitValueFive = coLimitValueFive;//
            this.noLimitValueFive = noLimitValueFive;
            this.hcLimitValueTwo = hcLimitValueTwo;
            this.coLimitValueTwo = coLimitValueTwo;
            this.noLimitValueTwo = noLimitValueTwo;
            this.hcDetermineFive = hcDetermineFive;//
            this.coDetermineFive = coDetermineFive;
            this.noDetermineFive = noDetermineFive;
            this.hcDetermineTwo = hcDetermineTwo;
            this.coDetermineTwo = coDetermineTwo;
            this.noDetermineTwo = noDetermineTwo;//
            this.ambientTemperature = ambientTemperature;
            this.relativeHumidity = relativeHumidity;
            this.atmospheric = atmospheric;
            this.inspectionstartime = inspectionstartime;
            this.endtime = endTime;//
            this.id = id;
        }
    }
    /// <summary>
    ///    稳态工况法检验过程数据(checked)
    /// </summary>
    public class SteadyStateMethodLog
    {
        public string path = "/rest/steadyStateMethodLog/";
        public string stationnumber;
        public string inspectionreport;
        public string linenumber;
        public string wholeTime;
        public string samplingSequence;
        public string caseType;
        public string hcValue;
        public string coValue;
        public string noValue;
        public string o2Value;
        public string co2Value;
        public string realTimeSpeed;
        public string engineSpeed;
        public string torsion;
        public string load;
        public string xsxzxs;
        public string sdxzxs;
        public string measuredLoadPower;
        public string csgkjsgl;
        public string csgkzsgl;
        public string wd;
        public string qy;
        public string sd;
        public string yw;
        public SteadyStateMethodLog(string stationNumber, string inspectionReport, string lineNumber, 
            string wholeTime, string samplingSequence, string caseType, string hcValue, 
            string coValue, string noValue, string o2Value, string co2Value, string realTimeSpeed,
            string engineSpeed, string torsion, string load, string xsxzxs, string sdxzxs, 
            string measuredLoadPower, string csgkjsgl, string csgkzsgl, 
            string wd, string qy, string sd, string yw )
        {
            this.stationnumber = stationNumber;
            this.inspectionreport = inspectionReport;
            this.linenumber = lineNumber;
            this.wholeTime = wholeTime;
            this.samplingSequence = samplingSequence;
            this.caseType = caseType;
            this.hcValue = hcValue;
            this.coValue = coValue;
            this.noValue = noValue;
            this.o2Value = o2Value;
            this.co2Value = co2Value;
            this.realTimeSpeed = realTimeSpeed;
            this.engineSpeed = engineSpeed;
            this.torsion = torsion;
            this.load = load;
            this.xsxzxs = xsxzxs;
            this.sdxzxs = sdxzxs;
            this.measuredLoadPower = measuredLoadPower;
            this.csgkjsgl = csgkjsgl;
            this.csgkzsgl = csgkzsgl;
            this.wd = wd;
            this.qy = qy;
            this.sd = sd;
            this.yw = yw;

        }
    }
    /// <summary>
    /// 主要用于上传检测过程图片(checked)
    /// </summary>
    public class DetProcessPic
    {
        public string path = "/rest/detProcessPic/";
        public string id;
        public string inspectionreport;
        public string linenumber;
        public string pzwz;
        public string stationnumber;
        public string zppssj;
        public string zpsj;
        public DetProcessPic(string id, string inspectionreport, string linenumber,
           string pzwz, string stationnumber, string zppssj, string zpsj)
        {
            this.id = id;
            this.inspectionreport = inspectionreport;
            this.linenumber = linenumber;
            this.pzwz = pzwz;
            this.stationnumber = stationnumber;
            this.zppssj = zppssj;
            this.zpsj = zpsj;
        }
    }
    public class eqLightTightRecord
    {
        public string path = "/rest/eqLightTightRecord/";
        public string lcjc;        //量程检查
        public string id;        //主键
        public string jcjssj;        //结束时间
        public string jckssj;        //开始时间
        public string jcz50;        //50%检查值
        public string jcz70;        //70%检查值
        public string jcjg;        //检查结果
        public string ldjc;        //零点检查
        public string lgpz50;        //50%滤光片值
        public string lgpz70;        //70%滤光片值
        public string linenumber;        //检测线编号
        public string stationnumber;        //检测机构编号
        public eqLightTightRecord(string lcjc, string id, string jcjssj, string jckssj, string jcz50, string jcz70,
            string jcjg, string ldjc, string lgpz50, string lgpz70,string linenumber, string stationnumber)
        {
            this.lcjc = lcjc;
            this.id = id;
            this.jcjssj = jcjssj;
            this.jckssj = jckssj;
            this.jcz50 = jcz50;
            this.jcz70 = jcz70;
            this.jcjg = jcjg;
            this.ldjc = ldjc;
            this.lgpz50 = lgpz50;
            this.lgpz70 = lgpz70;
            this.linenumber = linenumber;
            this.stationnumber = stationnumber;
        }
    }
    public class eqWaOutPowerRecord
    {
        public string path = "/rest/eqWaOutPowerRecord/";
        public string mysd1;        //名义速度1
        public string id;        //主键
        public string jcjssj;        //检测结束时间
        public string jckssj;        //检查开始时间
        public string jsgl1;        //寄生功率1
        public string jsgl2;        //寄生功率2
        public string jsgl3;        //寄生功率3
        public string jsgl4;        //寄生功率4
        public string linenumber;        //检测线编号
        public string jcjg;        //检查结果
        public string mysd2;        //名义速度2
        public string mysd3;        //名义速度3
        public string mysd4;        //名义速度4
        public string sdqj1;        //速度区间1
        public string sdqj2;        //速度区间2
        public string sdqj3;        //速度区间3
        public string sdqj4;        //速度区间4
        public string stationnumber;        //检测站编号
        public string zdsd;        //加载到的最大速度
        public eqWaOutPowerRecord(string mysd1, string id, string jcjssj, string jckssj, string jsgl1, string jsgl2,
            string jsgl3, string jsgl4, string linenumber, string jcjg, string mysd2, string mysd3,string mysd4,
            string sdqj1, string sdqj2, string sdqj3, string sdqj4, string stationnumber, string zdsd)
        {
            this.mysd1 = mysd1;
            this.id = id;
            this.jcjssj = jcjssj;
            this.jckssj = jckssj;
            this.jsgl1 = jsgl1;
            this.jsgl2 = jsgl2;
            this.jsgl3 = jsgl3;
            this.jsgl4 = jsgl4;
            this.linenumber = linenumber;
            this.jcjg = jcjg;
            this.mysd2 = mysd2;
            this.mysd3 = mysd3;
            this.mysd4 = mysd4;
            this.sdqj1 = sdqj1;
            this.sdqj2 = sdqj2;
            this.sdqj3 = sdqj3;
            this.sdqj4 = sdqj4;
            this.stationnumber = stationnumber;
            this.zdsd = zdsd;
        }
    }
    public class Ezclient
    {
        public Dictionary<string, string> EZ_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_licensePlateColor = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_licensePlateCategory = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_useProperties = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_emissionStandard = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_transmissionType = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_intakeMode = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_fuelSupply = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_driveMode = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_afterTreatmentType = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_fueltype = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_inspectionmethod = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_licensePlateColor = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_licensePlateCategory = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_useProperties = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_emissionStandard = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_transmissionType = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_intakeMode = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_fuelSupply = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_driveMode = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_afterTreatmentType = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_fueltype = new Dictionary<string, string>();
        public Dictionary<string, string> EZ_yn = new Dictionary<string, string>();
        public Dictionary<string, string> EZR_yn = new Dictionary<string, string>();
        private string url= "http://58.19.205.150:8081/jdcData";
        #region 路径
        const string PowerLossDataPath = "/rest/additionalData/";
        const string ezCodModelslibrarycataloguePath ="/rest/carInfos/";
        const string analyzerInspectionDataPath = "/rest/analyzerData/";
        const string ezBasChecklinePath = "/rest/checklines/";
        const string ezBasCheckstationPath = "/rest/checkstations/";
        const string ezIfaJcDoubleidledataPath = "/rest/doubleIdleData/";
        const string ezIfaJcDoubleidlelogPath = "/rest/doubleIdleLog/";
        const string externalLoginInformationPath = "/rest/externalLoginInfos/";
        const string filterPaperMethodPath = "/rest/filterPaper/";
        const string flowmeterDataPath = "/rest/flowmeterData/";
        const string inspectionInformationPath = "/rest/inspectionInfos/";
        const string leakCheckDataPath = "/rest/leakCheckData/";
        const string lightProofSmokeLogPath = "/rest/lightProofSmokeLog/";
        const string lightproofdataPath = "/rest/lightproof/";
        const string loadDownDataPath = "/rest/loadDownData/";
        const string loadSlideCheckDataPath = "/rest/loadSlideCheckData/";
        const string ezIfaJcLoaddownlogPath = "/rest/loaddownlog/";
        const string lowMarkGasDataPath = "/rest/lowMarkGasData/";
        const string oxygenRangeDataPath = "/rest/oxygenRangeData/";
        const string ezTestPersonPath = "/rest/persons/";
        const string steadyStateMethodDataPath = "/rest/steadyStateMethodData/";
        const string steadyStateMethodLogPath = "/rest/steadyStateMethodLog/";
        const string ifaJcVmasdataPath = "/rest/vmasData/";
        const string ifaJcVmaslogPath = "/rest/vmasLog/";
        const string detProcessPicPath = "/rest/detProcessPic/";
        #endregion
        public Ezclient(string url)
        {
            this.url = url;
            EZ_inspectionmethod.Add("1", "SDS");
            EZ_inspectionmethod.Add("2", "ASM");
            EZ_inspectionmethod.Add("3", "VMAS");
            EZ_inspectionmethod.Add("4", "JZJS");
            EZ_inspectionmethod.Add("5", "ZYJS");
            EZ_inspectionmethod.Add("6", "LZ");

            EZR_inspectionmethod.Add("SDS", "1");
            EZR_inspectionmethod.Add("ASM", "2");
            EZR_inspectionmethod.Add("VMAS", "3");
            EZR_inspectionmethod.Add("JZJS", "4");
            EZR_inspectionmethod.Add("ZYJS", "5");
            EZR_inspectionmethod.Add("LZ", "6");

            EZ_licensePlateColor.Add("1", "蓝牌");
            EZ_licensePlateColor.Add("2", "黄牌");
            EZ_licensePlateColor.Add("3", "白牌");
            EZ_licensePlateColor.Add("4", "黑牌");
            EZ_licensePlateColor.Add("5", "绿牌");

            EZR_licensePlateColor.Add("蓝牌", "1");
            EZR_licensePlateColor.Add("黄牌", "2");
            EZR_licensePlateColor.Add("白牌", "3");
            EZR_licensePlateColor.Add("黑牌", "4");
            EZR_licensePlateColor.Add("绿牌", "5");

            EZ_licensePlateCategory.Add("01", "大型汽车");
            EZ_licensePlateCategory.Add("02", "小型汽车");
            EZ_licensePlateCategory.Add("03", "使馆汽车");
            EZ_licensePlateCategory.Add("04", "领馆汽车");
            EZ_licensePlateCategory.Add("05", "境外汽车");
            EZ_licensePlateCategory.Add("06", "外籍汽车");
            EZ_licensePlateCategory.Add("07", "两、三轮摩托车");
            EZ_licensePlateCategory.Add("08", "轻便摩托车");
            EZ_licensePlateCategory.Add("09", "使馆摩托车");
            EZ_licensePlateCategory.Add("10", "领馆摩托车");
            EZ_licensePlateCategory.Add("11", "境外摩托车");
            EZ_licensePlateCategory.Add("12", "外籍摩托车");
            EZ_licensePlateCategory.Add("13", "农用运输车");
            EZ_licensePlateCategory.Add("14", "拖拉机");
            EZ_licensePlateCategory.Add("15", "挂车");
            EZ_licensePlateCategory.Add("16", "教练汽车");
            EZ_licensePlateCategory.Add("17", "教练摩托车");
            EZ_licensePlateCategory.Add("18", "试验汽车");
            EZ_licensePlateCategory.Add("19", "试验摩托车");
            EZ_licensePlateCategory.Add("20", "临时人境汽车");
            EZ_licensePlateCategory.Add("21", "临时人境摩托车");
            EZ_licensePlateCategory.Add("22", "临时行驶车");
            EZ_licensePlateCategory.Add("23", "警用汽车");
            EZ_licensePlateCategory.Add("24", "警用摩托");
            EZ_licensePlateCategory.Add("99", "其他");

            EZR_licensePlateCategory.Add("大型汽车", "01");
            EZR_licensePlateCategory.Add("小型汽车", "02");
            EZR_licensePlateCategory.Add("使馆汽车", "03");
            EZR_licensePlateCategory.Add("领馆汽车", "04");
            EZR_licensePlateCategory.Add("境外汽车", "05");
            EZR_licensePlateCategory.Add("外籍汽车", "06");
            EZR_licensePlateCategory.Add("两、三轮摩托车", "07");
            EZR_licensePlateCategory.Add("轻便摩托车", "08");
            EZR_licensePlateCategory.Add("使馆摩托车", "09");
            EZR_licensePlateCategory.Add("领馆摩托车", "10");
            EZR_licensePlateCategory.Add("境外摩托车", "11");
            EZR_licensePlateCategory.Add("外籍摩托车", "12");
            EZR_licensePlateCategory.Add("农用运输车", "13");
            EZR_licensePlateCategory.Add("拖拉机", "14");
            EZR_licensePlateCategory.Add("挂车", "15");
            EZR_licensePlateCategory.Add("教练汽车", "16");
            EZR_licensePlateCategory.Add("教练摩托车", "17");
            EZR_licensePlateCategory.Add("试验汽车", "18");
            EZR_licensePlateCategory.Add("试验摩托车", "19");
            EZR_licensePlateCategory.Add("临时人境汽车", "20");
            EZR_licensePlateCategory.Add("临时人境摩托车", "21");
            EZR_licensePlateCategory.Add("临时行驶车", "22");
            EZR_licensePlateCategory.Add("警用汽车", "23");
            EZR_licensePlateCategory.Add("警用摩托", "24");
            EZR_licensePlateCategory.Add("其他", "99");

            EZ_useProperties.Add("A", "非营运");
            EZ_useProperties.Add("B", "公路客运");
            EZ_useProperties.Add("C", "公交客运");
            EZ_useProperties.Add("D", "出租客运");
            EZ_useProperties.Add("E", "旅游客运");
            EZ_useProperties.Add("F", "货运");
            EZ_useProperties.Add("G", "租赁");
            EZ_useProperties.Add("H", "警用");
            EZ_useProperties.Add("I", "消防");
            EZ_useProperties.Add("J", "救护");
            EZ_useProperties.Add("K", "工程抢险");
            EZ_useProperties.Add("L", "营转非");
            EZ_useProperties.Add("M", "出租转非");
            EZ_useProperties.Add("N", "教练");
            EZ_useProperties.Add("O", "幼儿校车");
            EZ_useProperties.Add("P", "小学生校车");
            EZ_useProperties.Add("Q", "初中生校车");
            EZ_useProperties.Add("R", "危险品校车");
            EZ_useProperties.Add("S", "中小学生校车");

            EZR_useProperties.Add("非营运", "A");
            EZR_useProperties.Add("公路客运", "B");
            EZR_useProperties.Add("公交客运", "C");
            EZR_useProperties.Add("出租客运", "D");
            EZR_useProperties.Add("旅游客运", "E");
            EZR_useProperties.Add("货运", "F");
            EZR_useProperties.Add("租赁", "G");
            EZR_useProperties.Add("警用", "H");
            EZR_useProperties.Add("消防", "I");
            EZR_useProperties.Add("救护", "J");
            EZR_useProperties.Add("工程抢险", "K");
            EZR_useProperties.Add("营转非", "L");
            EZR_useProperties.Add("出租转非", "M");
            EZR_useProperties.Add("教练", "N");
            EZR_useProperties.Add("幼儿校车", "O");
            EZR_useProperties.Add("小学生校车", "P");
            EZR_useProperties.Add("初中生校车", "Q");
            EZR_useProperties.Add("危险品校车", "R");
            EZR_useProperties.Add("中小学生校车", "S");

            EZ_emissionStandard.Add("0", "国〇");
            EZ_emissionStandard.Add("1", "国Ⅰ");
            EZ_emissionStandard.Add("2", "国Ⅱ");
            EZ_emissionStandard.Add("3", "国Ⅲ");
            EZ_emissionStandard.Add("4", "国Ⅳ");
            EZ_emissionStandard.Add("5", "国Ⅴ");

            EZR_emissionStandard.Add("国〇","0");
            EZR_emissionStandard.Add("国Ⅰ", "1");
            EZR_emissionStandard.Add("国Ⅱ", "2");
            EZR_emissionStandard.Add("国Ⅲ", "3");
            EZR_emissionStandard.Add("国Ⅳ", "4");
            EZR_emissionStandard.Add("国Ⅴ", "5");

            EZ_transmissionType.Add("1", "手动");
            EZ_transmissionType.Add("2", "自动");
            EZ_transmissionType.Add("3", "手自一体");

            EZR_transmissionType.Add("手动", "1");
            EZR_transmissionType.Add("自动", "2");
            EZR_transmissionType.Add("手自一体", "3");

            EZ_intakeMode.Add("1", "自然进气");
            EZ_intakeMode.Add("2", "涡轮增压");

            EZR_intakeMode.Add("自然进气", "1");
            EZR_intakeMode.Add("涡轮增压", "2");

            EZ_fuelSupply.Add("1", "化油器");
            EZ_fuelSupply.Add("2", "化油器改造");
            EZ_fuelSupply.Add("3", "开环电喷");
            EZ_fuelSupply.Add("4", "闭环电喷");
            EZ_fuelSupply.Add("5", "高压共轨");
            EZ_fuelSupply.Add("6", "泵喷嘴");
            EZ_fuelSupply.Add("7", "单体泵");
            EZ_fuelSupply.Add("8", "直列泵");
            EZ_fuelSupply.Add("9", "机械泵");
            EZ_fuelSupply.Add("10", "其他");

            EZR_fuelSupply.Add("化油器", "1");
            EZR_fuelSupply.Add("化油器改造", "2");
            EZR_fuelSupply.Add("开环电喷", "3");
            EZR_fuelSupply.Add("闭环电喷", "4");
            EZR_fuelSupply.Add("高压共轨", "5");
            EZR_fuelSupply.Add("泵喷嘴", "6");
            EZR_fuelSupply.Add("单体泵", "7");
            EZR_fuelSupply.Add("直列泵", "8");
            EZR_fuelSupply.Add("机械泵", "9");
            EZR_fuelSupply.Add("其他", "10");

            EZ_driveMode.Add("1", "前驱");
            EZ_driveMode.Add("2", "后驱");
            EZ_driveMode.Add("3", "四驱");
            EZ_driveMode.Add("4", "全时四驱");

            EZR_driveMode.Add("前驱", "1");
            EZR_driveMode.Add("后驱", "2");
            EZR_driveMode.Add("四驱", "3");
            EZR_driveMode.Add("全时四驱", "4");

            EZ_afterTreatmentType.Add("0", "无");
            EZ_afterTreatmentType.Add("1", "三元催化");
            EZ_afterTreatmentType.Add("2", "DPF");
            EZ_afterTreatmentType.Add("3", "SCR");
            EZ_afterTreatmentType.Add("4", "DOC");
            EZ_afterTreatmentType.Add("5", "POC");
            EZ_afterTreatmentType.Add("6", "其他(如适用)");

            EZR_afterTreatmentType.Add("无", "0");
            EZR_afterTreatmentType.Add("三元催化", "1");
            EZR_afterTreatmentType.Add("DPF", "2");
            EZR_afterTreatmentType.Add("SCR", "3");
            EZR_afterTreatmentType.Add("DOC", "4");
            EZR_afterTreatmentType.Add("POC", "5");
            EZR_afterTreatmentType.Add("其他(如适用)", "6");


            EZ_fueltype.Add("A", "汽油");
            EZ_fueltype.Add("B", "柴油");
            EZ_fueltype.Add("C", "电");
            EZ_fueltype.Add("D", "混合油");
            EZ_fueltype.Add("E", "天然气");
            EZ_fueltype.Add("F", "液化石油气");
            EZ_fueltype.Add("L", "甲醇");
            EZ_fueltype.Add("M", "乙醇");
            EZ_fueltype.Add("N", "太阳能");
            EZ_fueltype.Add("O", "混合动力");
            EZ_fueltype.Add("P", "氢");
            EZ_fueltype.Add("Q", "生物燃料");
            EZ_fueltype.Add("Y", "无");
            EZ_fueltype.Add("Z", "其他");


            EZR_fueltype.Add("汽油", "A");
            EZR_fueltype.Add("柴油", "B");
            EZR_fueltype.Add("电", "C");
            EZR_fueltype.Add("混合油", "D");
            EZR_fueltype.Add("天然气", "E");
            EZR_fueltype.Add("液化石油气", "F");
            EZR_fueltype.Add("甲醇", "L");
            EZR_fueltype.Add("乙醇", "M");
            EZR_fueltype.Add("太阳能", "N");
            EZR_fueltype.Add("混合动力", "O");
            EZR_fueltype.Add("氢", "P");
            EZR_fueltype.Add("生物燃料", "Q");
            EZR_fueltype.Add("无", "Y");
            EZR_fueltype.Add("其他", "Z");

            EZ_yn.Add("Y", "是");
            EZ_yn.Add("N", "否");
            EZR_yn.Add("是", "Y");
            EZR_yn.Add("否", "N");
        }
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
        public bool JsonPost(string path, string jsonParas,out string responseStatus,out string responseDescription,out string code,out string message)
        {
            responseStatus = "";
            responseDescription = "";
            string strURL = url+path;
            //创建一个HTTP请求  
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 
            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;

            ini.INIIO.saveSocketLogInf("\r\n[POST]:\r\n" + "strURL=" + strURL + "\r\nrequest.Method=" + request.Method + "\r\nrequest.ContentType=" + request.ContentType + "\r\njsonParas="+ jsonParas);
            //发送请求，获得请求流 
            Stream newStream = request.GetRequestStream();
            newStream.Write(payload, 0, payload.Length);
            newStream.Close();
            
            HttpWebResponse response;           
            try
            {
                string result = "";
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    result = sr.ReadToEnd();
                    if (result != "")
                    {
                        //textBoxResult.Text = "GET:" + result;
                        Console.WriteLine("GET:" + result);
                    }
                    else
                    {
                       // textBoxResult.Text = "GET NONE";
                        Console.WriteLine("GET NONE");
                    }

                    responseStatus =((int)(response.StatusCode)).ToString();
                    responseDescription = result;
                    code = "1";
                    message = "";
                    ini.INIIO.saveSocketLogInf("\r\n[RESPONSE]:\r\nHTTPCODE=" + responseStatus + "\r\nDescription=" + responseDescription);
                    //在这里对接收到的页面内容进行处理
                }

                return true;//返回Json数据
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                code = "-1";
                message = "response失败";
                ini.INIIO.saveSocketLogInf("response失败");
                return false;
            }
        }
        public string jsonpoststringnowait = "";
        public string jsonpostpathnowait = "";
        public void JsonPostNotWaitAnswer()
        {
            string strURL = url + jsonpostpathnowait;
            //创建一个HTTP请求  
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 
            string paraUrlCoded = jsonpoststringnowait;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;

            ini.INIIO.saveSocketLogInf("\r\n[POST]:\r\n" + "strURL=" + strURL + "\r\nrequest.Method=" + request.Method + "\r\nrequest.ContentType=" + request.ContentType + "\r\njsonParas=" + jsonpoststringnowait);
            //发送请求，获得请求流 
            Stream newStream = request.GetRequestStream();
            newStream.Write(payload, 0, payload.Length);
            newStream.Close();
            //return true;
            /*HttpWebResponse response;
            try
            {
                string result = "";
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    result = sr.ReadToEnd();
                    if (result != "")
                    {
                        //textBoxResult.Text = "GET:" + result;
                        Console.WriteLine("GET:" + result);
                    }
                    else
                    {
                        // textBoxResult.Text = "GET NONE";
                        Console.WriteLine("GET NONE");
                    }

                    responseStatus = ((int)(response.StatusCode)).ToString();
                    responseDescription = result;
                    code = "1";
                    message = "";
                    ini.INIIO.saveSocketLogInf("\r\n[RESPONSE]:\r\nHTTPCODE=" + responseStatus + "\r\nDescription=" + responseDescription);
                    //在这里对接收到的页面内容进行处理
                }

                return true;//返回Json数据
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                code = "-1";
                message = "response失败";
                ini.INIIO.saveSocketLogInf("response失败");
                return false;
            }*/
        }
        /// <summary>
        /// 新增附加功率损失检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadPowerLossData(PowerLossData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring =  ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【uploadPowerLossData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200"|| responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" +code+"\r\nmessage="+message );
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增分析仪检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadAnalyzerInspectionData(AnalyzerInspectionData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【AnalyzerInspectionData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增分析仪氧量程检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadAnalyzerOxygenRangeData(AnalyzerOxygenRangeData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【AnalyzerOxygenRangeData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增外检登录信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadExternalLoginInformation(ExternalLoginInformation data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【ExternalLoginInformation】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增检测线信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzBasCheckline(EzBasCheckline data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzBasCheckline】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增检验机构信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzBasCheckstation(EzBasCheckstation data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzBasCheckstation】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增车辆信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzCodModelslibrarycatalogue(EzCodModelslibrarycatalogue data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzCodModelslibrarycatalogue】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增双怠速法检验结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzIfaJcDoubleidledata(EzIfaJcDoubleidledata data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzIfaJcDoubleidledata】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增双怠速法检验过程数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzIfaJcDoubleidlelog(EzIfaJcDoubleidlelog data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzIfaJcDoubleidlelog】");
                /*jsonpoststringnowait = jsonstring;
                jsonpostpathnowait = data.path;
                ThreadStart threadstart = new ThreadStart(JsonPostNotWaitAnswer);
                Thread thread = new Thread(threadstart);
                int alivetimecount = 0;
                int reSend = 0;
                thread.Start();
                while (thread.IsAlive && reSend < 1)
                {
                    Thread.Sleep(10);
                    alivetimecount++;
                    if (alivetimecount > 2)
                    {
                        reSend++;
                        try
                        {
                            thread.Abort();
                        }
                        catch
                        { }
                        if (reSend < 2)
                        {
                            alivetimecount = 0;
                            thread = new Thread(threadstart);
                            thread.Start();
                        }
                    }
                }
                if (reSend == 2)
                {
                    code = "-1";
                    message = "发送失败";
                    return false;
                }
                else
                {
                    code = "1";
                    message = "";
                    return true;
                }*/
                
                
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增自由加速不透光烟度法检验过程中采集的检验过程数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzIfaJcLightproofdata(EzIfaJcLightproofdata data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzIfaJcLightproofdata】");
                /*jsonpoststringnowait = jsonstring;
                jsonpostpathnowait = data.path;
                ThreadStart threadstart = new ThreadStart(JsonPostNotWaitAnswer);
                Thread thread = new Thread(threadstart);
                int alivetimecount = 0;
                int reSend = 0;
                thread.Start();
                while (thread.IsAlive && reSend < 1)
                {
                    Thread.Sleep(10);
                    alivetimecount++;
                    if (alivetimecount > 2)
                    {
                        reSend++;
                        try
                        {
                            thread.Abort();
                        }
                        catch
                        { }
                        if (reSend < 2)
                        {
                            alivetimecount = 0;
                            thread = new Thread(threadstart);
                            thread.Start();
                        }
                    }
                }
                if (reSend == 2)
                {
                    code = "-1";
                    message = "发送失败";
                    return false;
                }
                else
                {
                    code = "1";
                    message = "";
                    return true;
                }*/
                
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增自由加速不透光烟度法检验数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadLightProofSmokeLog(LightProofSmokeLog data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【LightProofSmokeLog】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增检验信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadInspectionInformation(InspectionInformation data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【InspectionInformation】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增泄露检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadLeakCheckData(LeakCheckData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【LeakCheckData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增加载减速工况法检验数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzIfaJcLoaddowndata(EzIfaJcLoaddowndata data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzIfaJcLoaddowndata】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增加载减速工况法检验过程中数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzIfaJcLoaddownlog(EzIfaJcLoaddownlog data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzIfaJcLoaddownlog】");
                /*jsonpoststringnowait = jsonstring;
                jsonpostpathnowait = data.path;
                ThreadStart threadstart = new ThreadStart(JsonPostNotWaitAnswer);
                Thread thread = new Thread(threadstart);
                int alivetimecount = 0;
                int reSend = 0;
                thread.Start();
                while (thread.IsAlive && reSend < 1)
                {
                    Thread.Sleep(10);
                    alivetimecount++;
                    if (alivetimecount > 2)
                    {
                        reSend++;
                        try
                        {
                            thread.Abort();
                        }
                        catch
                        { }
                        if (reSend < 2)
                        {
                            alivetimecount = 0;
                            thread = new Thread(threadstart);
                            thread.Start();
                        }
                    }
                }
                if (reSend == 2)
                {
                    code = "-1";
                    message = "发送失败";
                    return false;
                }
                else
                {
                    code = "1";
                    message = "";
                    return true;
                }*/
                
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 加载滑行检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadLoadSlideCheckData(LoadSlideCheckData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【LoadSlideCheckData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增低标气检查记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadLowMarkGasData(LowMarkGasData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【LowMarkGasData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增检验人员信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadEzTestPerson(EzTestPerson data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【EzTestPerson】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增稳态工况法检验数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadSteadyStateMethodData(SteadyStateMethodData data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【SteadyStateMethodData】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增稳态工况法检验过程数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadSteadyStateMethodLog(SteadyStateMethodLog data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【SteadyStateMethodLog】");
                /*jsonpoststringnowait = jsonstring;
                jsonpostpathnowait = data.path;
                ThreadStart threadstart = new ThreadStart(JsonPostNotWaitAnswer);
                Thread thread = new Thread(threadstart);
                int alivetimecount = 0;
                int reSend = 0;
                thread.Start();
                while (thread.IsAlive && reSend < 1)
                {
                    Thread.Sleep(10);
                    alivetimecount++;
                    if (alivetimecount > 2)
                    {
                        reSend++;
                        try
                        {
                            thread.Abort();
                        }
                        catch
                        { }
                        if (reSend < 2)
                        {
                            alivetimecount = 0;
                            thread = new Thread(threadstart);
                            thread.Start();
                        }
                    }
                }
                if (reSend == 2)
                {
                    code = "-1";
                    message = "发送失败";
                    return false;
                }
                else
                {
                    code = "1";
                    message = "";
                    return true;
                }*/
                
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 新增稳态工况法检验过程数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadDetPicture(DetProcessPic data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                //data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【uploadDetPicture】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 上传不透光自检信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadeqLightTightRecord(eqLightTightRecord data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【eqLightTightRecord】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 上传寄生 功率值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadeqWaOutPowerRecord(eqWaOutPowerRecord data, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
            try
            {
                data.id = guid;
                string jsonstring = ObjectToJson(data);
                ini.INIIO.saveSocketLogInf("【eqWaOutPowerRecord】");
                if (JsonPost(data.path, jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200" || responseStatus == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
    }
}
