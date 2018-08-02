using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using ini;

namespace YichangInter
{
    public class xmlAnalysis
    {
        public  void ReadACKString(string xmlstring, out string result, out string info)
        {
            INIIO.saveLogInf("[返回消息]:"+xmlstring);
            if (xmlstring != "")
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                info = dt1.Rows[0]["info"].ToString();
            }
            else
            {
                result = "0";
                info = "上传过程中有异常发生，请查看日志";
            }
            
        }
        public void ReadStateString(string xmlstring, out string result,out string info, out string state, out string businessId,out string methodID)
        {
            info = "";
            result = "";
            state="";
            businessId="";
            methodID="";
            INIIO.saveLogInf("[读取状态]："+xmlstring);
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[0];
            result = dt1.Rows[0]["result"].ToString();
            if (result == "0")
                info = dt1.Rows[0]["info"].ToString();
            else
            {
                dt1 = ds.Tables[1];
                state = dt1.Rows[0]["state"].ToString();
                businessId = dt1.Rows[0]["businessId"].ToString();
                methodID = dt1.Rows[0]["methodId"].ToString();
            }

        }
        public void ReadCarInfoString(string xmlstring, out string result, out string info, out string carCardNumber, out string maxWeight, out string standardWeight,out string motorPower,out string motorRate,out string speedChanger,out string fuelType,out string airInflow,out string oilSupply,out string isSYJHQ)
        {
            info = "";
            result = "";
            carCardNumber = "";
            maxWeight = "";
            standardWeight = "";
            motorRate = "";
            motorPower = "";
            speedChanger = "";
            fuelType = "";
            airInflow = "";
            oilSupply = "";
            isSYJHQ = "";
            INIIO.saveLogInf("[读取车辆信息]：" + xmlstring);
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[0];
            result = dt1.Rows[0]["result"].ToString();
            if (result == "0")
                info = dt1.Rows[0]["info"].ToString();
            dt1 = ds.Tables[1];
            carCardNumber = dt1.Rows[0]["carCardNumber"].ToString();
            maxWeight = dt1.Rows[0]["maxWeight"].ToString();
            standardWeight = dt1.Rows[0]["standardWeight"].ToString();
            motorPower = dt1.Rows[0]["motorPower"].ToString();
            motorRate = dt1.Rows[0]["motorRate"].ToString();
            speedChanger = dt1.Rows[0]["speedChanger"].ToString();
            fuelType = dt1.Rows[0]["fuelType"].ToString();
            airInflow = dt1.Rows[0]["airInflow"].ToString();
            oilSupply = dt1.Rows[0]["oilSupply"].ToString();
            isSYJHQ = dt1.Rows[0]["isSYJHQ"].ToString();


        }
        public void ReadAsmLimitString(string xmlstring, out string result, out string info, out string co5025, out string hc5025, out string no5025, out string co2540, out string hc2540, out string no2540)
        {
            info = "";
            result = "";
            co5025 = "";
            hc5025 = "";
            no5025 = "";
            co2540 = "";
            hc2540 = "";
            no2540 = "";
            INIIO.saveLogInf(xmlstring);
            DataSet ds = new DataSet();
            StringReader stream = new StringReader(xmlstring);
            XmlTextReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            DataTable dt1 = ds.Tables[0];
            result = dt1.Rows[0]["result"].ToString();
            if (result == "0")
                info = dt1.Rows[0]["info"].ToString();
            else
            {
                dt1 = ds.Tables[1];
                co5025 = dt1.Rows[0]["co5025"].ToString();
                hc5025 = dt1.Rows[0]["hc5025"].ToString();
                no5025 = dt1.Rows[0]["no5025"].ToString();
                co2540 = dt1.Rows[0]["co2540"].ToString();
                hc2540 = dt1.Rows[0]["hc2540"].ToString();
                no2540 = dt1.Rows[0]["no2540"].ToString();
            }
        }
        public void ReadCheckResultString(string xmlstring, out string result, out string info,
            out string valueCO, out string valueHC, out string valueNO, out string valueHCNO, out string valueCOLimit, out string valueHCLimit, out string valueNOLimit, out string valueHCNOLimit,
            out string valueCOResult, out string valueHCResult, out string valueNOResult, out string valueHCNOResult, out string result1,
            out string smokeK100, out string smokeK90, out string smokeK80, out string power, out string mortorSpeed, out string smokeK100Limit, out string smokeK90Limit, out string smokeK80Limit, out string powerLimit, out string mortorSpeedLimit,
            out string smokeK100Result, out string smokeK90Result, out string smokeK80Result, out string powerResult, out string mortorSpeedResult, out string result2,
            out string coLowValue, out string hcLowValue, out string coHighValue, out string hcHighValue, out string lambdaValue, out string coLowValueLimit, out string hcLowValueLimit, out string coHighValueLimit,
            out string hcHighValueLimit, out string coLowValueResult, out string hcLowValueResult, out string coHighValueResult, out string hcHighValueResult, out string lambdaValueResult, out string result3,
            out string smokeValue1, out string smokeValue2, out string smokeValue3, out string avgSmoke, out string smokeLimit, out string result4
            )
        {

            info = "";
            result = "";
            valueCO = ""; valueHC = ""; valueNO = ""; valueHCNO = ""; valueCOLimit = ""; valueHCLimit = ""; valueNOLimit = "";
            valueHCNOLimit = ""; valueCOResult = ""; valueHCResult = ""; valueNOResult = ""; valueHCNOResult = ""; result1 = "";

            smokeK100 = ""; smokeK90 = ""; smokeK80 = ""; power = ""; mortorSpeed = ""; smokeK100Limit = ""; smokeK90Limit = "";
            smokeK80Limit = ""; powerLimit = ""; mortorSpeedLimit = ""; smokeK100Result = ""; smokeK90Result = ""; smokeK80Result = "";
            powerResult = ""; mortorSpeedResult = ""; result2 = "";

            coLowValue = ""; hcLowValue = ""; coHighValue = ""; hcHighValue = ""; lambdaValue = ""; coLowValueLimit = ""; hcLowValueLimit = ""; coHighValueLimit = ""; hcHighValueLimit = "";
            coLowValueResult = ""; hcLowValueResult = ""; coHighValueResult = ""; hcHighValueResult = ""; lambdaValueResult = ""; result3 = "";

            smokeValue1 = ""; smokeValue2 = ""; smokeValue3 = ""; avgSmoke = ""; smokeLimit = ""; result4 = "";

            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];
                    valueCO = dt1.Rows[0]["valueCO"].ToString();
                    valueHC = dt1.Rows[0]["valueHC"].ToString();
                    valueNO = dt1.Rows[0]["valueNO"].ToString();
                    valueHCNO = dt1.Rows[0]["valueHCNO"].ToString();
                    valueCOLimit = dt1.Rows[0]["valueCOLimit"].ToString();
                    valueHCLimit = dt1.Rows[0]["valueHCLimit"].ToString();
                    valueNOLimit = dt1.Rows[0]["valueNOLimit"].ToString();
                    valueHCNOLimit = dt1.Rows[0]["valueHCNOLimit"].ToString();
                    valueCOResult = dt1.Rows[0]["valueCOResult"].ToString();
                    valueHCResult = dt1.Rows[0]["valueHCResult"].ToString();
                    valueNOResult = dt1.Rows[0]["valueNOResult"].ToString();
                    valueHCNOResult = dt1.Rows[0]["valueHCNOResult"].ToString();
                    result1 = dt1.Rows[0]["result1"].ToString();

                    smokeK100 = dt1.Rows[0]["smokeK100"].ToString();
                    smokeK90 = dt1.Rows[0]["smokeK90"].ToString();
                    smokeK80 = dt1.Rows[0]["smokeK80"].ToString();
                    power = dt1.Rows[0]["power"].ToString();
                    mortorSpeed = dt1.Rows[0]["mortorSpeed"].ToString();
                    smokeK100Limit = dt1.Rows[0]["smokeK100Limit"].ToString();
                    smokeK90Limit = dt1.Rows[0]["smokeK90Limit"].ToString();
                    smokeK80Limit = dt1.Rows[0]["smokeK80Limit"].ToString();
                    powerLimit = dt1.Rows[0]["powerLimit"].ToString();
                    mortorSpeedLimit = dt1.Rows[0]["mortorSpeedLimit"].ToString();
                    smokeK100Result = dt1.Rows[0]["smokeK100Result"].ToString();
                    smokeK90Result = dt1.Rows[0]["smokeK90Result"].ToString();
                    smokeK80Result = dt1.Rows[0]["smokeK80Result"].ToString();
                    powerResult = dt1.Rows[0]["powerResult"].ToString();
                    mortorSpeedResult = dt1.Rows[0]["mortorSpeedResult"].ToString();
                    result2 = dt1.Rows[0]["result2"].ToString();

                    coLowValue = dt1.Rows[0]["coLowValue"].ToString();
                    hcLowValue = dt1.Rows[0]["hcLowValue"].ToString();
                    coHighValue = dt1.Rows[0]["coHighValue"].ToString();
                    hcHighValue = dt1.Rows[0]["hcHighValue"].ToString();
                    lambdaValue = dt1.Rows[0]["lambdaValue"].ToString();
                    coLowValueLimit = dt1.Rows[0]["coLowValueLimit"].ToString();
                    hcLowValueLimit = dt1.Rows[0]["hcLowValueLimit"].ToString();
                    coHighValueLimit = dt1.Rows[0]["coHighValueLimit"].ToString();
                    hcHighValueLimit = dt1.Rows[0]["hcHighValueLimit"].ToString();
                    coLowValueResult = dt1.Rows[0]["coLowValueResult"].ToString();
                    hcLowValueResult = dt1.Rows[0]["hcLowValueResult"].ToString();
                    coHighValueResult = dt1.Rows[0]["coHighValueResult"].ToString();
                    hcHighValueResult = dt1.Rows[0]["hcHighValueResult"].ToString();
                    lambdaValueResult = dt1.Rows[0]["lambdaValueResult"].ToString();
                    result3 = dt1.Rows[0]["result3"].ToString();

                    smokeValue1 = dt1.Rows[0]["smokeValue1"].ToString();
                    smokeValue2 = dt1.Rows[0]["smokeValue2"].ToString();
                    smokeValue3 = dt1.Rows[0]["smokeValue3"].ToString();
                    avgSmoke = dt1.Rows[0]["avgSmoke"].ToString();
                    smokeLimit = dt1.Rows[0]["smokeLimit"].ToString();
                    result4 = dt1.Rows[0]["result4"].ToString();
                }
            }
            catch(Exception er)
            {
                result = "";
                info = er.Message;
            }
         }
        public void ReadVmasCheckResultString(string xmlstring, out string result, out string info,
            out string valueCO, out string valueHC, out string valueNO, out string valueHCNO, out string valueCOLimit, out string valueHCLimit, out string valueNOLimit, out string valueHCNOLimit,
            out string valueCOResult, out string valueHCResult, out string valueNOResult, out string valueHCNOResult, out string result1,out string before
            
            )
        {

            info = "";
            result = "";
            valueCO = ""; valueHC = ""; valueNO = ""; valueHCNO = ""; valueCOLimit = ""; valueHCLimit = ""; valueNOLimit = "";
            valueHCNOLimit = ""; valueCOResult = ""; valueHCResult = ""; valueNOResult = ""; valueHCNOResult = ""; result1 = "";
            before = "N";



            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];
                    valueCO = dt1.Rows[0]["valueCO"].ToString();
                    if (dt1.Columns.Contains("valueHC"))
                    {
                        valueHC = dt1.Rows[0]["valueHC"].ToString();
                        valueNO = dt1.Rows[0]["valueNO"].ToString();
                        valueHCLimit = dt1.Rows[0]["valueHCLimit"].ToString();
                        valueNOLimit = dt1.Rows[0]["valueNOLimit"].ToString();
                        valueHCResult = dt1.Rows[0]["valueHCResult"].ToString();
                        valueNOResult = dt1.Rows[0]["valueNOResult"].ToString();
                        before = "Y";
                    }
                    if (dt1.Columns.Contains("valueHCNO"))
                    {
                        valueHCNO = dt1.Rows[0]["valueHCNO"].ToString();
                        valueHCNOLimit = dt1.Rows[0]["valueHCNOLimit"].ToString();
                        valueHCNOResult = dt1.Rows[0]["valueHCNOResult"].ToString();
                        before = "N";
                    }
                    valueCOLimit = dt1.Rows[0]["valueCOLimit"].ToString();
                    valueCOResult = dt1.Rows[0]["valueCOResult"].ToString();
                    result1 = dt1.Rows[0]["result1"].ToString();
                    
                }
            }
            catch (Exception er)
            {
                result = "";
                info = er.Message;
            }
        }
        public void ReadLudownCheckResultString(string xmlstring, out string result, out string info,
            out string smokeK100, out string smokeK90, out string smokeK80, out string power, out string mortorSpeed, out string smokeK100Limit, out string smokeK90Limit, out string smokeK80Limit, out string powerLimit, out string mortorSpeedLimit,
            out string smokeK100Result, out string smokeK90Result, out string smokeK80Result, out string powerResult, out string mortorSpeedResult, out string result2
            )
        {

            info = "";
            result = "";

            smokeK100 = ""; smokeK90 = ""; smokeK80 = ""; power = ""; mortorSpeed = ""; smokeK100Limit = ""; smokeK90Limit = "";
            smokeK80Limit = ""; powerLimit = ""; mortorSpeedLimit = ""; smokeK100Result = ""; smokeK90Result = ""; smokeK80Result = "";
            powerResult = ""; mortorSpeedResult = ""; result2 = "";

            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];

                    smokeK100 = dt1.Rows[0]["smokeK100"].ToString();
                    smokeK90 = dt1.Rows[0]["smokeK90"].ToString();
                    smokeK80 = dt1.Rows[0]["smokeK80"].ToString();
                    power = dt1.Rows[0]["power"].ToString();
                    mortorSpeed = dt1.Rows[0]["mortorSpeed"].ToString();
                    smokeK100Limit = dt1.Rows[0]["smokeK100Limit"].ToString();
                    smokeK90Limit = dt1.Rows[0]["smokeK90Limit"].ToString();
                    smokeK80Limit = dt1.Rows[0]["smokeK80Limit"].ToString();
                    powerLimit = dt1.Rows[0]["powerLimit"].ToString();
                    mortorSpeedLimit = dt1.Rows[0]["mortorSpeedLimit"].ToString();
                    smokeK100Result = dt1.Rows[0]["smokeK100Result"].ToString();
                    smokeK90Result = dt1.Rows[0]["smokeK90Result"].ToString();
                    smokeK80Result = dt1.Rows[0]["smokeK80Result"].ToString();
                    powerResult = dt1.Rows[0]["powerResult"].ToString();
                    mortorSpeedResult = dt1.Rows[0]["mortorSpeedResult"].ToString();
                    result2 = dt1.Rows[0]["result2"].ToString();
                }
            }
            catch (Exception er)
            {
                result = "";
                info = er.Message;
            }
        }
        public void ReadSdsCheckResultString(string xmlstring, out string result, out string info,
            out string coLowValue, out string hcLowValue, out string coHighValue, out string hcHighValue, out string lambdaValue, out string coLowValueLimit, out string hcLowValueLimit, out string coHighValueLimit,
            out string hcHighValueLimit, out string coLowValueResult, out string hcLowValueResult, out string coHighValueResult, out string hcHighValueResult, out string lambdaValueResult, out string result3
            )
        {

            info = "";
            result = "";
             coLowValue = ""; hcLowValue = ""; coHighValue = ""; hcHighValue = ""; lambdaValue = ""; coLowValueLimit = ""; hcLowValueLimit = ""; coHighValueLimit = ""; hcHighValueLimit = "";
            coLowValueResult = ""; hcLowValueResult = ""; coHighValueResult = ""; hcHighValueResult = ""; lambdaValueResult = ""; result3 = "";
            

            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];
                   

                    coLowValue = dt1.Rows[0]["coLowValue"].ToString();
                    hcLowValue = dt1.Rows[0]["hcLowValue"].ToString();
                    coHighValue = dt1.Rows[0]["coHighValue"].ToString();
                    hcHighValue = dt1.Rows[0]["hcHighValue"].ToString();
                    lambdaValue = dt1.Rows[0]["lambdaValue"].ToString();
                    coLowValueLimit = dt1.Rows[0]["coLowValueLimit"].ToString();
                    hcLowValueLimit = dt1.Rows[0]["hcLowValueLimit"].ToString();
                    coHighValueLimit = dt1.Rows[0]["coHighValueLimit"].ToString();
                    hcHighValueLimit = dt1.Rows[0]["hcHighValueLimit"].ToString();
                    coLowValueResult = dt1.Rows[0]["coLowValueResult"].ToString();
                    hcLowValueResult = dt1.Rows[0]["hcLowValueResult"].ToString();
                    coHighValueResult = dt1.Rows[0]["coHighValueResult"].ToString();
                    hcHighValueResult = dt1.Rows[0]["hcHighValueResult"].ToString();
                    lambdaValueResult = dt1.Rows[0]["lambdaValueResult"].ToString();
                    result3 = dt1.Rows[0]["result3"].ToString();
                    
                }
            }
            catch (Exception er)
            {
                result = "";
                info = er.Message;
            }
        }
        public void ReadBtgCheckResultString(string xmlstring, out string result, out string info,
            out string smokeValue1, out string smokeValue2, out string smokeValue3, out string avgSmoke, out string smokeLimit, out string result4
            )
        {

            info = "";
            result = "";
            smokeValue1 = ""; smokeValue2 = ""; smokeValue3 = ""; avgSmoke = ""; smokeLimit = ""; result4 = "";

            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];
                   
                    smokeValue1 = dt1.Rows[0]["smokeValue1"].ToString();
                    smokeValue2 = dt1.Rows[0]["smokeValue2"].ToString();
                    smokeValue3 = dt1.Rows[0]["smokeValue3"].ToString();
                    avgSmoke = dt1.Rows[0]["avgSmoke"].ToString();
                    smokeLimit = dt1.Rows[0]["smokeLimit"].ToString();
                    result4 = dt1.Rows[0]["result4"].ToString();
                }
            }
            catch (Exception er)
            {
                result = "";
                info = er.Message;
            }
        }
        public void ReadAsmCheckResultString(string xmlstring, out string result, out string info,
            out string co5025el, out string hc5025el, out string no5025el, out string co2540el, out string hc2540el, out string no2540el,
            out string co5025ed, out string hc5025ed, out string no5025ed, out string co2540ed, out string hc2540ed, out string no2540ed,
            out string co5025str, out string hc5025str, out string no5025str, out string co2540str, out string hc2540str, out string no2540str,
            out string result5
            )
        {

            info = "";
            result = "";
            co5025el = ""; hc5025el = ""; no5025el = ""; co2540el = ""; hc2540el = ""; no2540el = "";
            co5025ed = ""; hc5025ed = ""; no5025ed = ""; co2540ed = ""; hc2540ed = ""; no2540ed = "";
            co5025str = ""; hc5025str = ""; no5025str = ""; co2540str = ""; hc2540str = ""; no2540str = "";
            result5 = "";


            INIIO.saveLogInf(xmlstring);
            try
            {
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(xmlstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables[0];
                result = dt1.Rows[0]["result"].ToString();
                if (result == "0")
                    info = dt1.Rows[0]["info"].ToString();
                else
                {
                    dt1 = ds.Tables["info"];


                    co5025el = dt1.Rows[0]["co5025el"].ToString();
                    hc5025el = dt1.Rows[0]["hc5025el"].ToString();
                    no5025el = dt1.Rows[0]["no5025el"].ToString();
                    co2540el = dt1.Rows[0]["co2540el"].ToString();
                    hc2540el = dt1.Rows[0]["hc2540el"].ToString();
                    no2540el = dt1.Rows[0]["no2540el"].ToString();
                    co5025ed = dt1.Rows[0]["co5025ed"].ToString();
                    hc5025ed = dt1.Rows[0]["hc5025ed"].ToString();
                    no5025ed = dt1.Rows[0]["no5025ed"].ToString();
                    co2540ed = dt1.Rows[0]["co2540ed"].ToString();
                    hc2540ed = dt1.Rows[0]["hc2540ed"].ToString();
                    no2540ed = dt1.Rows[0]["no2540ed"].ToString();
                    co5025str = dt1.Rows[0]["co5025str"].ToString();
                    hc5025str = dt1.Rows[0]["hc5025str"].ToString();
                    no5025str = dt1.Rows[0]["no5025str"].ToString();
                    co2540str = dt1.Rows[0]["co2540str"].ToString();
                    hc2540str = dt1.Rows[0]["hc2540str"].ToString();
                    no2540str = dt1.Rows[0]["no2540str"].ToString();
                    result5 = dt1.Rows[0]["result5"].ToString();

                }
            }
            catch (Exception er)
            {
                result = "";
                info = er.Message;
            }
        }
    }
}
