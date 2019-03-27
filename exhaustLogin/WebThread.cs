using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace exhaustDetect
{
    public class WebThread
    {
        public string businessId { set; get; }
        public string registCode { set; get; }
        //sds
        public double lrotateSpeed { set; get; }
        public double hrotateSpeed { set; get; }
        public double coLowValue { set; get; }
        public double hcLowValue { set; get; }
        public double coHighValue { set; get; }
        public double hcHighValue { set; get; }
        public double lambdaValue { set; get; }
        //
        //sdsprocessdata
        public int inspectNum_sds { set; get; }
        public double flowHC_sds { set; get; }
        public double flowCO_sds { set; get; }
        public double flowCO2_sds { set; get; }
        public double analyserO2_sds { set; get; }
        public double oilTemperature_sds { set; get; }
        public string rotateSpeed_sds { set; get; }

        //

        //asm
        public double hc5025 { set; get; }
        public double co5025 { set; get; }
        public double no5025 { set; get; }
        public double fdjzs5025 { set; get; }
        public double fdjyw5025 { set; get; }
        public double hc2540 { set; get; }
        public double co2540 { set; get; }
        public double no2540 { set; get; }
        public double fdjzs2540 { set; get; }
        public double fdjyw2540 { set; get; }
        //
        //asmPROCESSDATA
        public int inspectNum_asm { set; get; }
        public double clzHC_asm { set; get; }
        public double clzCO_asm { set; get; }
        public double clzNO_asm { set; get; }
        public double cs_asm { set; get; }
        public double zs_asm { set; get; }
        public double clzO2_asm { set; get; }
        public double clzCO2_asm { set; get; }
        public double xsxzxs_asm { set; get; }
        public double sdxzxs_asm { set; get; }
        public double totalPower_asm { set; get; }
        public double parasPower_asm { set; get; }
        public double indicPower_asm { set; get; }
        public double envirTemperature_asm { set; get; }
        public double envirAirPressure_asm { set; get; }
        public double envirHumidity_asm { set; get; }
        public double yw_asm { set; get; }

        //
        //lugdown
        public double smokeK100 { set; get; }
        public double smokeK90 { set; get; }
        public double smokeK80 { set; get; }
        public double power { set; get; }
        public double speed { set; get; }
        public double mortorSpeed { set; get; }
        public double idleRotateSpeed { set; get; }
        //
        //lugdownprocessdata
        public int inspectorNum_lugdwon { set; get; }
        public double calVelMaxHp_lugdwon { set; get; }
        public double actVelMaxHp_lugdwon { set; get; }
        public double powerPerSec_lugdwon { set; get; }
        public double speedPerSec_lugdwon { set; get; }
        public double actMaxPower_lugdwon { set; get; }
        public double rotateSpeed_lugdwon { set; get; }
        public double envirTemperature_lugdwon { set; get; }
        public double envirAirPressure_lugdwon { set; get; }
        public double envirHumidity_lugdwon { set; get; }
        public double powerCorrect_lugdwon { set; get; }
        public double corMaxPower_lugdwon { set; get; }
        public double smokeK100_lugdwon { set; get; }
        public double smokeK90_lugdwon { set; get; }
        public double smokeK80_lugdwon { set; get; }
        public double speedK100_lugdwon { set; get; }
        public double speedK90_lugdwon { set; get; }
        public double speedK80_lugdwon { set; get; }

        //
        //btg
        public double smokeValue1 { set; get; }
        public double smokeValue2 { set; get; }
        public double smokeValue3 { set; get; }
        public string dszs { set; get; }
        //
        //general
        public double tempreture { set; get; }
        public double humidity { set; get; }
        public double airPressure { set; get; }
        public string timeStart { set; get; }
        public string timeEnd { set; get; }
        //
        //test
        public int delaytime { set; get; }
        //
        public string answerString { set; get; }


        public double bgCO { set; get; }
        public double bgNO { set; get; }
        public double bgHC { set; get; }
        public double canliuHC { set; get; }
        public string IFlowResult { set; get; }
        public double O2Avg { set; get; }
        public string checkResult { set; get; }
        public string checkTimeStart { set; get; }
        public string checkTimeEnd { set; get; }
        public string remark { set; get; }

        public WebThread()
        {
            answerString = "";
        }
        public void sendSdsResult()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.doubleIdleData(businessId, registCode, lrotateSpeed, hrotateSpeed, coLowValue, hcLowValue,
                coHighValue, hcHighValue, lambdaValue, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.doubleIdleData(businessId, registCode, lrotateSpeed, hrotateSpeed, coLowValue, hcLowValue,
                   coHighValue, hcHighValue, lambdaValue, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.doubleIdleData(businessId, registCode, lrotateSpeed, hrotateSpeed, coLowValue, hcLowValue,
                   coHighValue, hcHighValue, lambdaValue, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.doubleIdleData(businessId, registCode, lrotateSpeed, hrotateSpeed, coLowValue, hcLowValue,
                   coHighValue, hcHighValue, lambdaValue, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.sdsJgsj(businessId, registCode, lrotateSpeed, hrotateSpeed, coLowValue, hcLowValue,
                   coHighValue, hcHighValue, lambdaValue, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口doubleIdleData出现异常】：" + er.Message);
            }
        }
        /*
        public void sendSdsProcess()
        {
            answerString = "";
            try
            {
                answerString = mainPanel.yichangInterface.doubleIdleLog(businessId, registCode, inspectNum_sds, flowHC_sds, flowCO_sds, flowCO2_sds, analyserO2_sds, oilTemperature_sds, rotateSpeed_sds);
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口doubleIdleLog出现异常】：" + er.Message);
            }
        }*/
        public void sendLugdownResult()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.loadDownData(businessId, registCode, smokeK100, smokeK90, smokeK80, power,
                speed, mortorSpeed, idleRotateSpeed, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.loadDownData(businessId, registCode, smokeK100, smokeK90, smokeK80, power,
                speed, mortorSpeed, idleRotateSpeed, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.loadDownData(businessId, registCode, smokeK100, smokeK90, smokeK80, power,
                speed, mortorSpeed, idleRotateSpeed, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.loadDownData(businessId, registCode, smokeK100, smokeK90, smokeK80, power,
                speed, mortorSpeed, idleRotateSpeed, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.jzjsJgsj(businessId, registCode, smokeK100, smokeK90, smokeK80, power,
                speed, mortorSpeed, idleRotateSpeed, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口loadDownData出现异常】：" + er.Message);
            }
        }
        /*
        public void sendLugdownProcess()
        {
            answerString = "";
            try
            {
                answerString = mainPanel.yichangInterface.loadDownLog(businessId, registCode, inspectorNum_lugdwon, calVelMaxHp_lugdwon, actVelMaxHp_lugdwon, powerPerSec_lugdwon, speedPerSec_lugdwon, actMaxPower_lugdwon, rotateSpeed_lugdwon, envirTemperature_lugdwon,
                envirAirPressure_lugdwon, envirHumidity_lugdwon, powerCorrect_lugdwon, corMaxPower_lugdwon, smokeK100_lugdwon,
                smokeK90_lugdwon, smokeK80_lugdwon, speedK100_lugdwon, speedK90_lugdwon, speedK80_lugdwon);
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口loadDownLog出现异常】：" + er.Message);
            }
        }*/
        public void sendAsmResult()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.vasmData(businessId, registCode, hc5025, co5025, no5025, fdjzs5025, fdjyw5025, hc2540, co2540, no2540,
                fdjzs2540, fdjyw2540, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.vasmData(businessId, registCode, hc5025, co5025, no5025, fdjzs5025, fdjyw5025, hc2540, co2540, no2540,
                fdjzs2540, fdjyw2540, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.vasmData(businessId, registCode, hc5025, co5025, no5025, fdjzs5025, fdjyw5025, hc2540, co2540, no2540,
                fdjzs2540, fdjyw2540, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.vasmData(businessId, registCode, hc5025, co5025, no5025, fdjzs5025, fdjyw5025, hc2540, co2540, no2540,
                fdjzs2540, fdjyw2540, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.wtJgsj(businessId, registCode, hc5025, co5025, no5025, fdjzs5025, fdjyw5025, hc2540, co2540, no2540,
                fdjzs2540, fdjyw2540, tempreture, humidity, airPressure, timeStart, timeEnd);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口vasmData出现异常】：" + er.Message);
            }
        }
        public void sendAsmProcess()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.vasmLog(businessId, registCode, inspectNum_asm, clzHC_asm, clzCO_asm, clzNO_asm,
                cs_asm, zs_asm, clzO2_asm, clzCO2_asm, xsxzxs_asm, sdxzxs_asm, totalPower_asm, parasPower_asm, indicPower_asm,
                envirTemperature_asm, envirAirPressure_asm, envirHumidity_asm, yw_asm);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.vasmLog(businessId, registCode, inspectNum_asm, clzHC_asm, clzCO_asm, clzNO_asm,
                cs_asm, zs_asm, clzO2_asm, clzCO2_asm, xsxzxs_asm, sdxzxs_asm, totalPower_asm, parasPower_asm, indicPower_asm,
                envirTemperature_asm, envirAirPressure_asm, envirHumidity_asm, yw_asm);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.vasmLog(businessId, registCode, inspectNum_asm, clzHC_asm, clzCO_asm, clzNO_asm,
                cs_asm, zs_asm, clzO2_asm, clzCO2_asm, xsxzxs_asm, sdxzxs_asm, totalPower_asm, parasPower_asm, indicPower_asm,
                envirTemperature_asm, envirAirPressure_asm, envirHumidity_asm, yw_asm);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口vasmLog出现异常】：" + er.Message);
            }
        }
        public void sendBtgResult()
        {

            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.lightproofSmokeData(businessId, registCode, smokeValue1, smokeValue2, smokeValue3,
                    tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.lightproofSmokeData(businessId, registCode, smokeValue1, smokeValue2, smokeValue3,
                    tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.lightproofSmokeData(businessId, registCode, smokeValue1, smokeValue2, smokeValue3,
                    tempreture, humidity, airPressure, timeStart, timeEnd,dszs);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.lightproofSmokeData(businessId, registCode, smokeValue1, smokeValue2, smokeValue3,
                    tempreture, humidity, airPressure, timeStart, timeEnd);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.btgJgsj(businessId, registCode, smokeValue1, smokeValue2, smokeValue3,
                    tempreture, humidity, airPressure, timeStart, timeEnd);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口lightproofSmokeData出现异常】：" + er.Message);
            }

        }

        public void sendStart()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.sendMessage(businessId, registCode, "03", "");
                }
                else if(mainPanel.zkytwebinf.add==mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.sendMessage(businessId, registCode, "03", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.sendMessage(businessId, registCode, "03", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.sendMessage(businessId, registCode, "03", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.xxtz(businessId, registCode, "03", "");
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口sendMessage出现异常】：" + er.Message);
            }
        }
        public void sendFinish()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.sendMessage(businessId, registCode, "05", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.sendMessage(businessId, registCode, "05", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.sendMessage(businessId, registCode, "05", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.sendMessage(businessId, registCode, "05", "");
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_YNBS)
                {
                    answerString = mainPanel.yichangInterfaceYnbs.xxtz(businessId, registCode, "05", "");
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口sendMessage出现异常】：" + er.Message);
            }
        }
        public void sendAirHC()
        {
            answerString = "";
            try
            {
                if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_CD)
                {
                    answerString = mainPanel.yichangInterface.bgAirHC(businessId, registCode, bgCO, bgNO, bgHC, canliuHC, IFlowResult, O2Avg, checkResult, checkTimeStart, checkTimeEnd, remark);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_OTHER)
                {
                    answerString = mainPanel.yichangInterfaceOther.bgAirHC(businessId, registCode, bgCO, bgNO, bgHC, canliuHC, IFlowResult, O2Avg, checkResult, checkTimeStart, checkTimeEnd, remark);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_LNCY)
                {
                    answerString = mainPanel.yichangInterfaceLncy.bgAirHC(businessId, registCode, bgCO, bgNO, bgHC, canliuHC, IFlowResult, O2Avg, checkResult, checkTimeStart, checkTimeEnd, remark);
                }
                else if (mainPanel.zkytwebinf.add == mainPanel.ZKYTAREA_JZ)
                {
                    answerString = mainPanel.yichangInterfaceJz.bgAirHC(businessId, registCode, bgCO, bgNO, bgHC, canliuHC, IFlowResult, O2Avg, checkResult, checkTimeStart, checkTimeEnd, remark);
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("【调用接口bgAirHC出现异常】：" + er.Message);
            }
        }
        public void testMothod()
        {
            for (int i = 0; i < delaytime; i++)
            {
                Thread.Sleep(10);
            }
            answerString = "hello world";
        }
    }
}
