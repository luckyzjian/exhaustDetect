using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using ini;
using SYS.Model;
using System.Net;
using System.Collections;
using carinfor;

namespace JHWebClient
{
    public class JHdeviceInf
    {
        public string ID { set; get; }
        public string STMLINEID { set; get; }
        public string STMSTATIONCODE { set; get; }
        public string STMLINECODE { set; get; }
        public string CODE { set; get; }
        public string NAME { set; get; }
        public string TESTDEVICETYPE { set; get; }
        public string SERIES { set; get; }
        public string MODEL { set; get; }
        public string SPEC { set; get; }
        public string LOCKDESC { set; get; }
        public string MANUFCODE { set; get; }
        public string MANUFNAME { set; get; }
        public string MANUFDATE { set; get; }
        public string VENDORCODE { set; get; }
        public string VENDORNAME { set; get; }
        public string BOUGHTDATE { set; get; }
        public string KEEPER { set; get; }
        public string CERTCODE { set; get; }
        public string CERTDATE { set; get; }
        public string VALIDDATE { set; get; }
        public string STATUS { set; get; }
        public string SCORE { set; get; }
        public string RCREATETIME { set; get; }
        public string RUPDATETIME { set; get; }
        public string RMEMO { set; get; }
        public string RSTATUS { set; get; }
        public string IFCHECK { set; get; }
    }
    public class checkResultModel
    {
        public string testmethod { set; get; }
        public string testresult { set; get; }
        public string value01 { set; get; }
        public string value02 { set; get; }
        public string value03 { set; get; }
        public string value04 { set; get; }
        public string value05 { set; get; }
        public string value06 { set; get; }
        public string limit01 { set; get; }
        public string limit02 { set; get; }
        public string limit03 { set; get; }
        public string limit04 { set; get; }
        public string limit05 { set; get; }
        public string limit06 { set; get; }
        public string judge01 { set; get; }
        public string judge02 { set; get; }
        public string judge03 { set; get; }
        public string judge04 { set; get; }
        public string judge05 { set; get; }
        public string judge06 { set; get; }
        public string parame01 { set; get; }
        public string parame02{ set; get; }
        public string parame03 { set; get; }
        public string parame04 { set; get; }
        public string parame05 { set; get; }
        public string parame06{ set; get; }
    }
    public class MyOracle
    {
        public string sdsResultTableName = "intf_result_didle";
        public string asmResultTableName = "intf_result_asm";
        public string vmasResultTableName = "intf_result_vmas";
        public string lzResultTableName = "intf_result_smoke";
        public string btgResultTableName = "intf_result_lightproof";
        public string lugdownResultTableName = "intf_result_lugdown";
        public string sdsProcessTableName = "intf_test_didle";
        public string asmProcessTableName = "intf_test_asm";
        public string vmasProcessTableName = "intf_test_vmas";
        public string lugdownProcessTableName = "intf_test_lugdown";
        public string btgProcessTableName = "INTF_TEST_LIGHTPROOF";
        public string deivceTableName = "intf_devicerec";
        public ConnForOracle oralcon = null;
        public MyOracle(string connstr)
        {
            try
            {
                oralcon = new ConnForOracle(connstr);
                //oralcon.OpenConn();
            }
            catch(Exception er)
            {
                ini.INIIO.saveLogInf(er.Message);
            }
        }
        
        public string getGUID()
        {
            try
            {
                string guid="";
                string sqlStr = "select sys_guid() from dual connect by rownum<10";
                guid = oralcon.ReturnDataReader(sqlStr);
                return guid;
            }
            catch(Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public string getSynTime()
        {
            try
            {
                string sqlStr = "select to_char(sysdate,'YYYY-MM-DD HH24:MI:SS') from dual";
                DataSet giudmodel = oralcon.ReturnDataSet(sqlStr, "GUID");
                return giudmodel.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public bool getDeviceInf(string stationID,string LineID,string SBLX,out JHdeviceInf jhdeviceinf)
        {
            try
            {
                string sqlStr = "select * from INTF_DEVICE where STMSTATIONCODE='"+stationID+ "' and STMLINECODE='"+LineID+ "' and TESTDEVICETYPE='"+SBLX+"'";
                jhdeviceinf = new JHdeviceInf();
                DataSet giudmodel = oralcon.ReturnDataSet(sqlStr, "DATASET");
                DataTable dt = giudmodel.Tables[0];
                if(dt!= null)
                {
                    if(dt.Rows.Count>0)
                    {
                        jhdeviceinf.ID = dt.Rows[0]["ID"].ToString();
                        jhdeviceinf.STMLINEID = dt.Rows[0]["STMLINEID"].ToString();
                        jhdeviceinf.STMSTATIONCODE = dt.Rows[0]["STMSTATIONCODE"].ToString();
                        jhdeviceinf.STMLINECODE = dt.Rows[0]["STMLINECODE"].ToString();
                        jhdeviceinf.CODE = dt.Rows[0]["CODE"].ToString();
                        jhdeviceinf.NAME = dt.Rows[0]["NAME"].ToString();
                        jhdeviceinf.TESTDEVICETYPE = dt.Rows[0]["TESTDEVICETYPE"].ToString();
                        jhdeviceinf.SERIES = dt.Rows[0]["SERIES"].ToString();
                        jhdeviceinf.MODEL = dt.Rows[0]["MODEL"].ToString();
                        jhdeviceinf.SPEC = dt.Rows[0]["SPEC"].ToString();
                        jhdeviceinf.LOCKDESC = dt.Rows[0]["LOCKDESC"].ToString();
                        jhdeviceinf.MANUFCODE = dt.Rows[0]["MANUFCODE"].ToString();
                        jhdeviceinf.MANUFNAME = dt.Rows[0]["MANUFNAME"].ToString();
                        jhdeviceinf.MANUFDATE = dt.Rows[0]["MANUFDATE"].ToString();
                        jhdeviceinf.VENDORCODE = dt.Rows[0]["VENDORCODE"].ToString();
                        jhdeviceinf.VENDORNAME = dt.Rows[0]["VENDORNAME"].ToString();
                        jhdeviceinf.BOUGHTDATE = dt.Rows[0]["BOUGHTDATE"].ToString();
                        jhdeviceinf.KEEPER = dt.Rows[0]["KEEPER"].ToString();
                        jhdeviceinf.CERTCODE = dt.Rows[0]["CERTCODE"].ToString();
                        jhdeviceinf.CERTDATE = dt.Rows[0]["CERTDATE"].ToString();
                        jhdeviceinf.VALIDDATE = dt.Rows[0]["VALIDDATE"].ToString();

                        jhdeviceinf.VENDORCODE = dt.Rows[0]["STATUS"].ToString();
                        jhdeviceinf.VENDORNAME = dt.Rows[0]["SCORE"].ToString();
                        jhdeviceinf.BOUGHTDATE = dt.Rows[0]["RCREATETIME"].ToString();
                        jhdeviceinf.KEEPER = dt.Rows[0]["RUPDATETIME"].ToString();
                        jhdeviceinf.CERTCODE = dt.Rows[0]["RMEMO"].ToString();
                        jhdeviceinf.CERTDATE = dt.Rows[0]["RSTATUS"].ToString();
                        jhdeviceinf.VALIDDATE = dt.Rows[0]["IFCHECK"].ToString();
                        return true;
                    }
                    else
                    {
                        jhdeviceinf = null;
                        return false;
                    }
                }
                else
                {
                    jhdeviceinf = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public bool writeCgjZjRecord(string stationID,string LineID,string czy,string optime,CGJselfCheckdata zjdata,JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename",deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.ChecckResult=="1"?"1":"0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", zjdata.Jzhxds);
                resulttable.Add("exti04", "");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", zjdata.Gxdl);
                resulttable.Add("extn02", zjdata.Jzhxds);
                resulttable.Add("extn03", "48.0");
                resulttable.Add("extn04", "32.0");
                resulttable.Add("extn05", zjdata.Lpower);
                resulttable.Add("extn06", zjdata.Jsgl2);
                resulttable.Add("extn07", zjdata.Lvitualtime);
                resulttable.Add("extn08", zjdata.Lrealtime);
                resulttable.Add("extn09", zjdata.Pc2);
                resulttable.Add("extn10", zjdata.Jzhxds=="2"?"64.0":"");
                resulttable.Add("extn11", zjdata.Jzhxds == "2" ? "48.0":"" );
                resulttable.Add("extn12", zjdata.Jzhxds == "2" ? zjdata.Hpower.ToString() : "");
                resulttable.Add("extn13", zjdata.Jzhxds == "2" ? zjdata.Jsgl1.ToString() : "");
                resulttable.Add("extn14", zjdata.Jzhxds == "2" ? zjdata.Hvitualtime.ToString() : "");
                resulttable.Add("extn15", zjdata.Jzhxds == "2" ? zjdata.Hrealtime.ToString() : "");
                resulttable.Add("extn16", zjdata.Jzhxds == "2" ? zjdata.Pc1.ToString() : "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeFqyZjRecord(string stationID, string LineID, string czy, string optime, wqfxySelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Remark == "1" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", zjdata.TightnessResult);
                resulttable.Add("exti04", "1");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", zjdata.Yqll);
                resulttable.Add("extn02", zjdata.Yqyq);
                resulttable.Add("extn03", "");
                resulttable.Add("extn04", "");
                resulttable.Add("extn05", "");
                resulttable.Add("extn06", "");
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeSdsFqyZjRecord(string stationID, string LineID, string czy, string optime, sdsqtfxySelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Remark == "1" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", zjdata.TightnessResult);
                resulttable.Add("exti04", "1");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", zjdata.Yqll);
                resulttable.Add("extn02", zjdata.Yqyq);
                resulttable.Add("extn03", "");
                resulttable.Add("extn04", "");
                resulttable.Add("extn05", "");
                resulttable.Add("extn06", "");
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeyYdjZjRecord(string stationID, string LineID, string czy, string optime, ydjSelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Zjjg == "通过" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", "1");
                resulttable.Add("exti04", "1");
                resulttable.Add("exti05", "2");
                resulttable.Add("extn01", zjdata.LabelValueN50);
                resulttable.Add("extn02", zjdata.N501);
                resulttable.Add("extn03", zjdata.N501-zjdata.LabelValueN50);
                resulttable.Add("extn04", zjdata.LabelValueN70);
                resulttable.Add("extn05", zjdata.N701);
                resulttable.Add("extn06", zjdata.N701 - zjdata.LabelValueN70);
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeyYdjZjRecordJH(string stationID, string LineID, string czy, string optime, ydjSelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Zjjg == "通过" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", "1");
                resulttable.Add("exti04", "1");
                resulttable.Add("exti05", "2");
                resulttable.Add("extn01",0);
                resulttable.Add("extn02", zjdata.NZero);
                resulttable.Add("extn03", zjdata.NZero);
                resulttable.Add("extn04", zjdata.LabelValueN50);
                resulttable.Add("extn05", zjdata.N501);
                resulttable.Add("extn06", zjdata.N501 - zjdata.LabelValueN50);
                resulttable.Add("extn07", zjdata.LabelValueN70);
                resulttable.Add("extn08", zjdata.N701);
                resulttable.Add("extn09", zjdata.N701 - zjdata.LabelValueN70);                
                resulttable.Add("extn10", zjdata.LabelValueN90);
                resulttable.Add("extn11", zjdata.N901);
                resulttable.Add("extn12", zjdata.N901 - zjdata.LabelValueN90);
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeyDzhjZjRecord(string stationID, string LineID, string czy, string optime, hjcsgyqSelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Zjjg == "通过" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", "");
                resulttable.Add("exti04", "");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", zjdata.ActualTemperature);
                resulttable.Add("extn02", zjdata.Temperature);
                resulttable.Add("extn03", zjdata.ActualHumidity);
                resulttable.Add("extn04", zjdata.Humidity);
                resulttable.Add("extn05", zjdata.ActualAirPressure);
                resulttable.Add("extn06", zjdata.AirPressure);
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeyZsjZjRecord(string stationID, string LineID, string czy, string optime, fdjzsSelfCheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.Zjjg == "通过" ? "1" : "0");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", zjdata.Dszs);
                resulttable.Add("exti03", "");
                resulttable.Add("exti04", "");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01","");
                resulttable.Add("extn02", "");
                resulttable.Add("extn03", "");
                resulttable.Add("extn04", "");
                resulttable.Add("extn05", "");
                resulttable.Add("extn06", "");
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeyLljZjRecord(string stationID, string LineID, string czy, string optime, lljSelfcheck zjdata, JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                resulttable.Add("id", guid);
                resulttable.Add("typecode", "1");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", deviceinf.NAME);
                resulttable.Add("opcode", "0");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DateTimeE");
                resulttable.Add("optime", "DateTimeS" + optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + zjdata.CheckTimeStart.Split('.')[0] + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + zjdata.CheckTimeEnd.Split('.')[0] + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", zjdata.CheckResult);
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "1");
                resulttable.Add("exti02", "1");
                resulttable.Add("exti03", "");
                resulttable.Add("exti04", "");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", "");
                resulttable.Add("extn02", "");
                resulttable.Add("extn03", "");
                resulttable.Add("extn04", "");
                resulttable.Add("extn05", "");
                resulttable.Add("extn06", "");
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool writeSyncRecord(string GUID,string stationID,string LineID,string czy,string optime,string opstime,string opetime,JHdeviceInf deviceinf)
        {
            try
            {
                Hashtable resulttable = new Hashtable();
                resulttable.Add("id", GUID);
                resulttable.Add("typecode", "3");
                resulttable.Add("stationcode", stationID);
                resulttable.Add("testline", LineID);
                resulttable.Add("testdeviceid", deviceinf.ID);
                resulttable.Add("testdevicecode", deviceinf.CODE);
                resulttable.Add("testdevicetype", deviceinf.TESTDEVICETYPE);
                resulttable.Add("testdevicename", "时间同步");
                resulttable.Add("opcode", "9");
                resulttable.Add("operator", czy);
                resulttable.Add("reporttime", "DateTimeS" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"DateTimeE");
                resulttable.Add("optime", "DateTimeS"+optime + "DateTimeE");
                resulttable.Add("opstime", "DateTimeS" + opstime + "DateTimeE");
                resulttable.Add("opetime", "DateTimeS" + opetime + "DateTimeE");
                resulttable.Add("status", "1");
                resulttable.Add("result", "1");
                resulttable.Add("score", "");
                resulttable.Add("memo", "");
                resulttable.Add("extnum", "");
                resulttable.Add("exti01", "");
                resulttable.Add("exti02", "");
                resulttable.Add("exti03", "");
                resulttable.Add("exti04", "");
                resulttable.Add("exti05", "");
                resulttable.Add("extn01", "");
                resulttable.Add("extn02", "");
                resulttable.Add("extn03", "");
                resulttable.Add("extn04", "");
                resulttable.Add("extn05", "");
                resulttable.Add("extn06", "");
                resulttable.Add("extn07", "");
                resulttable.Add("extn08", "");
                resulttable.Add("extn09", "");
                resulttable.Add("extn10", "");
                resulttable.Add("extn11", "");
                resulttable.Add("extn12", "");
                resulttable.Add("extn13", "");
                resulttable.Add("extn14", "");
                resulttable.Add("extn15", "");
                resulttable.Add("extn16", "");
                resulttable.Add("extn17", "");
                resulttable.Add("extn18", "");
                resulttable.Add("extn19", "");
                resulttable.Add("extn20", "");
                resulttable.Add("RMEMO", "");
                if (oralcon.Insert(deivceTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行intf_devicerec语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("intf_devicerec发生异常：" + er.Message);
                return false;
            }
        }
        public bool insertSds(string stationid,string lineid,string czy,string jsy,string jcjg,SDS sdsresult,JHvehicleInf jhvehilce,string jckssj,string jcjssj,out string TESTINGID)
        {
            try
            {
                TESTINGID = "";
                string sqlStr = "";
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                TESTINGID = guid;
                resulttable.Add("ID", guid);
                resulttable.Add("INSPREGID", jhvehilce.REGID);
                resulttable.Add("VEHICLEID", jhvehilce.ID);
                resulttable.Add("plateno", jhvehilce.PLATENO);
                resulttable.Add("plateclass", jhvehilce.PLATECLASS);
                resulttable.Add("VIN", jhvehilce.VIN);
                resulttable.Add("INSPSTATIONCODE", stationid);
                resulttable.Add("FUELTYPE", jhvehilce.FUELTYPE);
                resulttable.Add("INSPLINECODE", lineid);
                resulttable.Add("operatorid", czy);
                resulttable.Add("driverid", jsy);
                resulttable.Add("teststime", "DateTimeS"+jckssj+"DateTimeE");
                resulttable.Add("testetime", "DateTimeS" + jcjssj + "DateTimeE");
                resulttable.Add("testresult", jcjg);
                resulttable.Add("samplingdepth", "400");
                resulttable.Add("TEMPERATURE", sdsresult.WD);
                resulttable.Add("HUMIDITY", sdsresult.SD);
                resulttable.Add("PRESSURE", sdsresult.DQY);
                resulttable.Add("ENGINESPEED", "3500");
                resulttable.Add("HIGHSPEED", sdsresult.ZSHIGH);
                resulttable.Add("LOWSPEED", sdsresult.ZSLOW);
                resulttable.Add("LAMBDA", sdsresult.LAMDAHIGHCLZ);
                resulttable.Add("LOWIDLECO", sdsresult.COLOWCLZ);
                resulttable.Add("LOWIDLEHC", sdsresult.HCLOWCLZ);
                resulttable.Add("HIGHIDLECO", sdsresult.COHIGHCLZ);
                resulttable.Add("HIGHIDLEHC", sdsresult.HCHIGHCLZ);
                resulttable.Add("LAMBDAUP", "1.03");
                resulttable.Add("LAMBDADOWN", "0.97");
                resulttable.Add("LOWIDLECOLIMIT", sdsresult.COLOWXZ);
                resulttable.Add("LOWIDLEHCLIMIT", sdsresult.HCLOWXZ);
                resulttable.Add("HIGHIDLECOLIMIT", sdsresult.COHIGHXZ);
                resulttable.Add("HIGHIDLEHCLIMIT", sdsresult.HCHIGHXZ);
                resulttable.Add("LAMBDAJUDGE", sdsresult.LAMDAHIGHPD == "合格" ? "1" : "0");
                resulttable.Add("LOWIDLECOJUDGE", sdsresult.COLOWPD == "合格" ? "1" : "0");
                resulttable.Add("LOWIDLEHCJUDGE", sdsresult.HCLOWPD == "合格" ? "1" : "0");
                resulttable.Add("HIGHIDLECOJUDGE", sdsresult.COHIGHPD == "合格" ? "1" : "0");
                resulttable.Add("HIGHIDLEHCJUDGE", sdsresult.HCHIGHPD == "合格" ? "1" : "0");
                if(oralcon.Insert(sdsResultTableName,resulttable)>0)
                {
                    ini.INIIO.saveLogInf("执行InsertSds语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行InsertSds语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch(Exception er)
            {
                TESTINGID = "";
                ini.INIIO.saveLogInf("InsertSds发生异常：" + er.Message);
                return false;
            }
        }
        public bool insertSdsDataSeconds(string testingid,string jcjg, SDS sdsresult, JHvehicleInf jhvehilce, DataTable dtseconds)
        {
            try
            {
                string sqlStr = "";
                if (dtseconds != null)
                {
                    int opno = 1;
                    int gdscount = 1, dscount = 1;
                    bool columnscontainsno = dtseconds.Columns.Contains("NO");
                    for (int i = 1; i < dtseconds.Rows.Count; i++)
                    {
                        DataRow dr = dtseconds.Rows[i];
                        if (dr["时序类别"].ToString() == "2" || dr["时序类别"].ToString() == "1")
                        {
                            Hashtable resulttable = new Hashtable();
                            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                            resulttable.Add("ID", guid);
                            resulttable.Add("TESTINGID", testingid);
                            resulttable.Add("SERIALNO", (opno++).ToString());
                            resulttable.Add("OPNO", (gdscount++).ToString());
                            resulttable.Add("OPCODE", "2" );
                            resulttable.Add("SAMPLINGDEPTH", "400");
                            resulttable.Add("OPTIME", "DateTimeS" + dr["全程时序"].ToString().Split('.')[0] + "DateTimeE");
                            resulttable.Add("POSNO", "0");
                            resulttable.Add("VEHICLESPEED", "0");
                            resulttable.Add("ENGINESPEED", dr["转速"].ToString());
                            resulttable.Add("VOLCO", dr["CO"].ToString());
                            resulttable.Add("VOLCO2", dr["CO2"].ToString());
                            resulttable.Add("VOLHC", dr["HC"].ToString());
                            resulttable.Add("VOLNOX", columnscontainsno? dr["NO"].ToString():"1");
                            resulttable.Add("VOLO2", dr["O2"].ToString());
                            resulttable.Add("TEMPERATURE", dr["环境温度"].ToString());
                            resulttable.Add("HUMIDITY", dr["相对湿度"].ToString());
                            resulttable.Add("PRESSURE", dr["大气压力"].ToString());
                            resulttable.Add("KJUDGE", jcjg);
                            oralcon.Insert(sdsProcessTableName, resulttable);

                        }
                        else if (dr["时序类别"].ToString() == "3" || dr["时序类别"].ToString() == "4")
                        {
                            Hashtable resulttable = new Hashtable();
                            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                            resulttable.Add("ID", guid);
                            resulttable.Add("TESTINGID", testingid);
                            resulttable.Add("SERIALNO", (opno++).ToString());
                            resulttable.Add("OPNO", (dscount++).ToString());
                            resulttable.Add("OPCODE",  "1" );
                            resulttable.Add("SAMPLINGDEPTH", "400");
                            resulttable.Add("OPTIME", "DateTimeS" + dr["全程时序"].ToString().Split('.')[0] + "DateTimeE");
                            resulttable.Add("POSNO", "0");
                            resulttable.Add("VEHICLESPEED", "0");
                            resulttable.Add("ENGINESPEED", dr["转速"].ToString());
                            resulttable.Add("VOLCO", dr["CO"].ToString());
                            resulttable.Add("VOLCO2", dr["CO2"].ToString());
                            resulttable.Add("VOLHC", dr["HC"].ToString());
                            resulttable.Add("VOLNOX", columnscontainsno ? dr["NO"].ToString() : "1");
                            resulttable.Add("VOLO2", dr["O2"].ToString());
                            resulttable.Add("TEMPERATURE", dr["环境温度"].ToString());
                            resulttable.Add("HUMIDITY", dr["相对湿度"].ToString());
                            resulttable.Add("PRESSURE", dr["大气压力"].ToString());
                            resulttable.Add("KJUDGE", jcjg);
                            oralcon.Insert(sdsProcessTableName, resulttable);

                        }
                    }
                    ini.INIIO.saveLogInf("InsertSdsPocess成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("InsertSdsPocess失败:dataseconds为null");
                    return false;
                }
                
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("InsertSdsPocess发生异常：" + er.Message);
                return false;
            }
        }

        public bool insertVmas(string stationid, string lineid, string czy, string jsy, string jcjg, VMAS sdsresult, JHvehicleInf jhvehilce, string jckssj, string jcjssj,bool isbefore, out string TESTINGID)
        {
            try
            {
                TESTINGID = "";
                string sqlStr = "";
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                TESTINGID = guid;
                resulttable.Add("ID", guid);
                resulttable.Add("INSPREGID", jhvehilce.REGID);
                resulttable.Add("VEHICLEID", jhvehilce.ID);
                resulttable.Add("plateno", jhvehilce.PLATENO);
                resulttable.Add("plateclass", jhvehilce.PLATECLASS);
                resulttable.Add("VIN", jhvehilce.VIN);
                resulttable.Add("INSPSTATIONCODE", stationid);
                resulttable.Add("FUELTYPE", jhvehilce.FUELTYPE);
                resulttable.Add("INSPLINECODE", lineid);
                resulttable.Add("operatorid", czy);
                resulttable.Add("driverid", jsy);
                resulttable.Add("teststime", "DateTimeS" + jckssj + "DateTimeE");
                resulttable.Add("testetime", "DateTimeS" + jcjssj + "DateTimeE");
                resulttable.Add("testresult", jcjg);
                resulttable.Add("samplingdepth", "400");
                resulttable.Add("lambda", sdsresult.LAMBDA);
                resulttable.Add("TEMPERATURE", sdsresult.WD);
                resulttable.Add("HUMIDITY", sdsresult.SD);
                resulttable.Add("PRESSURE", sdsresult.DQY);
                resulttable.Add("HC", sdsresult.HCZL);
                resulttable.Add("CO", sdsresult.COZL);
                resulttable.Add("NOX", sdsresult.NOXZL);
                resulttable.Add("HCNOX", (double.Parse(sdsresult.HCZL)+double.Parse(sdsresult.NOXZL)).ToString("0.00"));
                resulttable.Add("HCLIMIT", isbefore?sdsresult.HCXZ:"");
                resulttable.Add("COLIMIT", sdsresult.COXZ);
                resulttable.Add("NOXLIMIT", isbefore ? sdsresult.NOXXZ : "");
                resulttable.Add("HCNOXLIMIT", !isbefore ? sdsresult.HCXZ : "");
                resulttable.Add("HCJUDGE", isbefore ? (sdsresult.HCPD=="合格"?"1":"0") : "");
                resulttable.Add("COJUDGE", sdsresult.COPD == "合格" ? "1" : "0");
                resulttable.Add("NOXJUDGE", isbefore ? (sdsresult.NOXPD == "合格" ? "1" : "0") : "");
                resulttable.Add("HCNOXJUDGE", !isbefore ? (sdsresult.HCPD == "合格" ? "1" : "0") : "");
                
                if (oralcon.Insert(vmasResultTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行InsertVmas语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行InsertVmas语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                TESTINGID = "";
                ini.INIIO.saveLogInf("InsertVmas发生异常：" + er.Message);
                return false;
            }
        }
        public bool insertVmasDataSeconds(string testingid, string jcjg, VMAS sdsresult, JHvehicleInf jhvehilce, DataTable dtseconds)
        {
            try
            {
                string sqlStr = "";
                if (dtseconds != null)
                {
                    int totalcount = dtseconds.Rows.Count-1;
                    int fqydelaytime = totalcount - 195;
                    for (int i = 1; i < 196; i++)
                    {
                        DataRow dr = dtseconds.Rows[i+fqydelaytime];
                        if (true)
                        {
                            Hashtable resulttable = new Hashtable();
                            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                            resulttable.Add("ID", guid);
                            resulttable.Add("TESTINGID", testingid);
                            resulttable.Add("SERIALNO", i.ToString());
                            int opno, opcode;
                            if(i<=11)
                            {
                                opno = 1;
                                opcode = 1;
                            }
                            else if(i<=15)
                            {
                                opno = 2;
                                opcode = 2;
                            }
                            else if (i <= 23)
                            {
                                opno = 3;
                                opcode = 3;
                            }
                            else if (i <= 25)
                            {
                                opno = 4;
                                opcode =4;
                            }
                            else if (i <= 28)
                            {
                                opno = 5;
                                opcode = 4;
                            }
                            else if (i <= 49)
                            {
                                opno = 6;
                                opcode =5;
                            }
                            else if (i <= 54)
                            {
                                opno = 7;
                                opcode = 6;
                            }
                            else if (i <= 56)
                            {
                                opno = 8;
                                opcode = 6;
                            }
                            else if (i <= 61)
                            {
                                opno = 9;
                                opcode = 6;
                            }
                            else if (i <= 85)
                            {
                                opno = 10;
                                opcode = 7;
                            }
                            else if (i <= 93)
                            {
                                opno = 11;
                                opcode = 8;
                            }
                            else if (i <= 96)
                            {
                                opno = 12;
                                opcode = 8;
                            }
                            else if (i <= 117)
                            {
                                opno = 13;
                                opcode = 9;
                            }
                            else if (i <= 122)
                            {
                                opno = 14;
                                opcode = 10;
                            }
                            else if (i <= 124)
                            {
                                opno = 15;
                                opcode = 10;
                            }
                            else if (i <= 133)
                            {
                                opno = 16;
                                opcode = 10;
                            }
                            else if (i <= 135)
                            {
                                opno = 17;
                                opcode =10;
                            }
                            else if (i <= 143)
                            {
                                opno = 18;
                                opcode = 10;
                            }
                            else if (i <= 155)
                            {
                                opno = 19;
                                opcode = 11;
                            }
                            else if (i <= 163)
                            {
                                opno = 20;
                                opcode =12;
                            }
                            else if (i <= 176)
                            {
                                opno = 21;
                                opcode = 13;
                            }
                            else if (i <= 178)
                            {
                                opno = 22;
                                opcode =14;
                            }
                            else if (i <= 185)
                            {
                                opno = 23;
                                opcode = 14;
                            }
                            else if (i <= 188)
                            {
                                opno = 24;
                                opcode =14;
                            }
                            else if (i <= 195)
                            {
                                opno = 25;
                                opcode = 15;
                            }
                            else
                            {
                                continue;
                            }
                            resulttable.Add("OPNO", opno.ToString());
                            resulttable.Add("OPCODE", opcode.ToString());
                            resulttable.Add("SAMPLINGDEPTH", "400");
                            resulttable.Add("OPTIME", "DateTimeS" + dr["全程时序"].ToString().Split('.')[0] + "DateTimeE");
                            resulttable.Add("POSNO", "0");
                            resulttable.Add("VEHICLESPEED", dr["实时车速"].ToString());
                            resulttable.Add("ENGINESPEED", dr["发动机转速"].ToString());
                            resulttable.Add("VOLCO", dr["CO实时值"].ToString());
                            resulttable.Add("VOLCO2", dr["CO2实时值"].ToString());
                            resulttable.Add("VOLHC", dr["HC实时值"].ToString());
                            resulttable.Add("VOLNOX", dr["NO实时值"].ToString());
                            resulttable.Add("VOLO2RAW", dr["分析仪O2实时值"].ToString());
                            resulttable.Add("VOLO2DIL", dr["流量计O2实时值"].ToString());
                            resulttable.Add("VOLO2AMB", dr["环境O2浓度"].ToString());
                            resulttable.Add("FLOWACTUAL", dr["实际体积流量"].ToString());
                            resulttable.Add("FLOWEXHAUST", dr["尾气实际排放流量"].ToString());
                            resulttable.Add("FLOWSTD", dr["标准体积流量"].ToString());
                            resulttable.Add("TEMPERATURE", dr["环境温度"].ToString());
                            resulttable.Add("HUMIDITY", dr["相对湿度"].ToString());
                            resulttable.Add("PRESSURE", dr["大气压力"].ToString());
                            resulttable.Add("FLOWMETERT", dr["流量计温度"].ToString());
                            resulttable.Add("FLOWMETERP", dr["流量计压力"].ToString());
                            resulttable.Add("DYNPA", dr["加载功率"].ToString());
                             resulttable.Add("DYNPLHP", dr["寄生功率"].ToString());
                            resulttable.Add("DYNIHP", dr["指示功率"].ToString());
                            resulttable.Add("DYNN", dr["扭矩"].ToString());
                            resulttable.Add("DCF", dr["稀释修正系数"].ToString());
                            resulttable.Add("KH", dr["湿度修正系数"].ToString());
                            resulttable.Add("DR", dr["稀释比"].ToString());
                            resulttable.Add("MASSCO", dr["CO排放质量"].ToString());
                            resulttable.Add("MASSCO2", dr["CO2排放质量"].ToString());
                            resulttable.Add("MASSHC", dr["HC排放质量"].ToString());
                            resulttable.Add("MASSNOX", dr["NO排放质量"].ToString());
                            resulttable.Add("lambda", dr["lambda"].ToString());
                            resulttable.Add("KJUDGE", jcjg);
                            oralcon.Insert(vmasProcessTableName, resulttable);

                        }
                    }
                    ini.INIIO.saveLogInf("InsertvmasPocess成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("InsertvmasPocess失败:dataseconds为null");
                    return false;
                }

                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("InsertvmasPocess发生异常：" + er.Message);
                return false;
            }
        }
        public bool insertLugdown(string stationid, string lineid, string czy, string jsy, string jcjg,JZJS sdsresult,string maxvelhp,  JHvehicleInf jhvehilce, string jckssj, string jcjssj, out string TESTINGID)
        {
            try
            {
                TESTINGID = "";
                string sqlStr = "";
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                TESTINGID = guid;
                resulttable.Add("ID", guid);
                resulttable.Add("INSPREGID", jhvehilce.REGID);
                resulttable.Add("VEHICLEID", jhvehilce.ID);
                resulttable.Add("plateno", jhvehilce.PLATENO);
                resulttable.Add("plateclass", jhvehilce.PLATECLASS);
                resulttable.Add("VIN", jhvehilce.VIN);
                resulttable.Add("INSPSTATIONCODE", stationid);
                resulttable.Add("FUELTYPE", jhvehilce.FUELTYPE);
                resulttable.Add("INSPLINECODE", lineid);
                resulttable.Add("operatorid", czy);
                resulttable.Add("driverid", jsy);
                resulttable.Add("teststime", "DateTimeS" + jckssj + "DateTimeE");
                resulttable.Add("testetime", "DateTimeS" + jcjssj + "DateTimeE");
                resulttable.Add("testresult", jcjg);
                resulttable.Add("samplingdepth", "400");
                resulttable.Add("TEMPERATURE", sdsresult.WD);
                resulttable.Add("HUMIDITY", sdsresult.SD);
                resulttable.Add("PRESSURE", sdsresult.DQY);
                resulttable.Add("MAXRPM", sdsresult.MAXLBZS);
                resulttable.Add("ACTUALMAXHP", sdsresult.ACTMAXHP);
                resulttable.Add("POWERCORRECTION", sdsresult.GLXZXS);
                resulttable.Add("CORRECTMAXHP", sdsresult.MAXLBGL);
                resulttable.Add("CALCVELMAXHP", sdsresult.REALVELMAXHP);
                resulttable.Add("ACTUALVELMAXHP", sdsresult.VELMAXHP);
                resulttable.Add("K100",sdsresult.HK);
                resulttable.Add("K90", sdsresult.NK);
                resulttable.Add("K80", sdsresult.EK);
                resulttable.Add("REATEDSPEEDUP", sdsresult.RATEREVUP);
                resulttable.Add("REATEDSPEEDDOWN", sdsresult.RATEREVDOWN);
                resulttable.Add("MINHP",sdsresult.GLXZ);
                resulttable.Add("KLIMIT", sdsresult.YDXZ);
                resulttable.Add("SPEEDJUDGE","1");
                resulttable.Add("MAXHPJUDGE", sdsresult.GLPD == "合格" ? "1" : "0");
                resulttable.Add("KJUDGE", (sdsresult.HKPD == "合格"&& sdsresult.NKPD == "合格" && sdsresult.EKPD == "合格") ? "1" : "0");

                if (oralcon.Insert(lugdownResultTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行Insertlugdown语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行Insertlugdown语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                TESTINGID = "";
                ini.INIIO.saveLogInf("InsertVmas发生异常：" + er.Message);
                return false;
            }
        }

        public bool insertLugdownDataSeconds(string testingid, string jcjg, JZJS sdsresult, JHvehicleInf jhvehilce, DataTable dtseconds)
        {
            try
            {
                string sqlStr = "";
                if (dtseconds != null)
                {
                    int count = 1;
                    for (int i = 1; i < dtseconds.Rows.Count; i++)
                    {
                        DataRow dr = dtseconds.Rows[i];
                        if (true)
                        {
                            Hashtable resulttable = new Hashtable();
                            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                            if (dr["OPNO"].ToString() == "1")
                            {
                                continue;
                            }
                            resulttable.Add("ID", guid);
                            resulttable.Add("TESTINGID", testingid);
                            resulttable.Add("SERIALNO", count.ToString());
                            count++;                         
                            resulttable.Add("OPNO", dr["OPNO"].ToString());
                            resulttable.Add("OPCODE", dr["OPCODE"].ToString());
                            resulttable.Add("SAMPLINGDEPTH", "400");
                            resulttable.Add("OPTIME", "DateTimeS" + dr["全程时序"].ToString().Split('.')[0] + "DateTimeE");
                            resulttable.Add("POSNO", "0");
                            resulttable.Add("VEHICLESPEED", dr["车速"].ToString());
                            resulttable.Add("ENGINESPEED", dr["转速"].ToString());
                            resulttable.Add("ENGINEPOWER", dr["功率"].ToString());
                            resulttable.Add("SFK", dr["光吸收系数K"].ToString());
                            resulttable.Add("SFN", dr["不透光度"].ToString());
                            resulttable.Add("TEMPERATURE", dr["环境温度"].ToString());
                            resulttable.Add("HUMIDITY", dr["相对湿度"].ToString());
                            resulttable.Add("PRESSURE", dr["大气压力"].ToString());
                            resulttable.Add("DYNPA", dr["功率"].ToString());
                            resulttable.Add("DYNPLHP", dr["寄生功率"].ToString());
                            resulttable.Add("DYNIHP", dr["指示功率"].ToString());
                            resulttable.Add("DYNN", dr["DYNN"].ToString());
                            resulttable.Add("PCF", dr["DCF"].ToString());
                            resulttable.Add("KJUDGE", jcjg);
                            oralcon.Insert(lugdownProcessTableName, resulttable);

                        }
                    }
                    ini.INIIO.saveLogInf("InsertlugdownPocess成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("InsertlugdownPocess失败:dataseconds为null");
                    return false;
                }

                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("InsertlugdownPocess发生异常：" + er.Message);
                return false;
            }
        }

        public bool insertBtgdown(string stationid, string lineid, string czy, string jsy, string jcjg, Zyjs_Btg sdsresult, JHvehicleInf jhvehilce, string jckssj, string jcjssj, out string TESTINGID)
        {
            try
            {
                TESTINGID = "";
                string sqlStr = "";
                Hashtable resulttable = new Hashtable();
                string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                TESTINGID = guid;
                resulttable.Add("ID", guid);
                resulttable.Add("INSPREGID", jhvehilce.REGID);
                resulttable.Add("VEHICLEID", jhvehilce.ID);
                resulttable.Add("plateno", jhvehilce.PLATENO);
                resulttable.Add("plateclass", jhvehilce.PLATECLASS);
                resulttable.Add("VIN", jhvehilce.VIN);
                resulttable.Add("INSPSTATIONCODE", stationid);
                resulttable.Add("FUELTYPE", jhvehilce.FUELTYPE);
                resulttable.Add("INSPLINECODE", lineid);
                resulttable.Add("operatorid", czy);
                resulttable.Add("driverid", jsy);
                resulttable.Add("teststime", "DateTimeS" + jckssj + "DateTimeE");
                resulttable.Add("testetime", "DateTimeS" + jcjssj + "DateTimeE");
                resulttable.Add("testresult", jcjg);
                resulttable.Add("samplingdepth", "400");
                resulttable.Add("TEMPERATURE", sdsresult.WD);
                resulttable.Add("HUMIDITY", sdsresult.SD);
                resulttable.Add("PRESSURE", sdsresult.DQY);
                resulttable.Add("ENGINESPEED", sdsresult.DSZS);

                //resulttable.Add("K4", (double.Parse(sdsresult.AVERAGEDATA)+(double)(DateTime.Now.Second)/100.0).ToString("0.00"));//金华
                resulttable.Add("K4", "0");//衢州
                resulttable.Add("K3", sdsresult.FIRSTDATA);
                resulttable.Add("K2", sdsresult.SECONDDATA);
                resulttable.Add("K1", sdsresult.THIRDDATA);
                resulttable.Add("KAVG", sdsresult.AVERAGEDATA);
                resulttable.Add("KLIMIT", sdsresult.YDXZ);
                resulttable.Add("KJUDGE", jcjg);

                if (oralcon.Insert(btgResultTableName, resulttable) > 0)
                {
                    ini.INIIO.saveLogInf("执行Insertbtg语句成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行Insertbtg语句成功，影响行数为0");
                    return false;
                }
                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                TESTINGID = "";
                ini.INIIO.saveLogInf("Insertbtg发生异常：" + er.Message);
                return false;
            }
        }
        public bool insertBtgDataSeconds(string testingid, string jcjg, Zyjs_Btg sdsresult, JHvehicleInf jhvehilce, DataTable dtseconds)
        {
            try
            {
                string sqlStr = "";
                if (dtseconds != null)
                {
                    int count1 = 1;
                    int count2 = 1;
                    int count3 = 1;
                    int count4 = 1;
                    for (int i = 1; i < dtseconds.Rows.Count; i++)
                    {
                        DataRow dr = dtseconds.Rows[i];
                        if (true)
                        {
                            Hashtable resulttable = new Hashtable();
                            string guid = System.Guid.NewGuid().ToString().Replace("-", "");
                            resulttable.Add("ID", guid);
                            resulttable.Add("TESTINGID", testingid);
                            resulttable.Add("SERIALNO", i.ToString());
                            if (dr["时序类别"].ToString() == "1")
                            {
                                count1++;
                                resulttable.Add("OPNO", count1.ToString());
                            }
                            else if (dr["时序类别"].ToString() == "2")
                            {
                                count2++;
                                resulttable.Add("OPNO", count2.ToString());
                            }
                            else if (dr["时序类别"].ToString() == "3")
                            {
                                count3++;
                                resulttable.Add("OPNO", count3.ToString());
                            }
                            else if (dr["时序类别"].ToString() == "4")
                            {
                                count4++;
                                resulttable.Add("OPNO", count4.ToString());
                            }
                            else
                                continue;
                            resulttable.Add("OPCODE", (int.Parse(dr["时序类别"].ToString())-1).ToString());
                            resulttable.Add("SAMPLINGDEPTH", "400");
                            resulttable.Add("OPTIME", "DateTimeS" + dr["全程时序"].ToString().Split('.')[0] + "DateTimeE");
                            resulttable.Add("POSNO", "0");
                            resulttable.Add("VEHICLESPEED","0");
                            resulttable.Add("ENGINESPEED", dr["发动机转速"].ToString());
                            resulttable.Add("ENGINEPOWER", "0");
                            resulttable.Add("SFK", dr["烟度值读数"].ToString());
                            resulttable.Add("SFN", dr["SFN"].ToString());
                            resulttable.Add("TEMPERATURE", dr["环境温度"].ToString());
                            resulttable.Add("HUMIDITY", dr["相对湿度"].ToString());
                            resulttable.Add("PRESSURE", dr["大气压力"].ToString());
                            resulttable.Add("KJUDGE", jcjg);
                            oralcon.Insert(btgProcessTableName, resulttable);

                        }
                    }
                    ini.INIIO.saveLogInf("InsertbtgPocess成功");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("InsertbtgPocess失败:dataseconds为null");
                    return false;
                }

                //sqlStr = "insert into intf_result_didle(ID, INSPREGID, VEHICLEID, plateno, plateclass, VIN, INSPSTATIONCODE, FUELTYPE, INSPLINECODE, operatorid, driverid, teststime, testetime, testresult, samplingdepth, temperature, humidity, pressure, ENGINESPEED, HIGHSPEED, LOWSPEED, lambda, lowidleco, lowidlehc, highidleco, highidlehc, lambdaup, lambdadown, lowidlecolimit, lowidlehclimit, highidlecolimit, highidlehclimit, LAMBDAJUDGE, LOWIDLECOJUDGE, LOWIDLEHCJUDGE, HIGHIDLECOJUDGE, HIGHIDLEHCJUDGE) values('15FB81B88F3E4cfe85D174F4BD2CB9F6', '1ed03394f1614b229f0047dd9a3ff0f2', '6EA83AC062D54E76BC10BD756422F55D', '浙G0190Y', '02', 'LFV2A1150B3502796', '33070102', 'A', '03', '宗承', '钱航吉', to_date('2017-01-07 11:09:24', 'yyyy-mm-dd hh24:mi:ss'), to_date('2017-01-07 11:12:42', 'yyyy-mm-dd hh24:mi:ss'), '1', 400, 7.6, 47.0, 102.0, 3500, 29, 34, 1.09, 0.040, 13, 0.040, 13, 1.03, 0.97, 0.8, 150, 0.3, 100, 1, 1, 1, 1, 1)";
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("InsertlugdownPocess发生异常：" + er.Message);
                return false;
            }
        }

    }
    public class JHvehicleInf
    {
        public string ID { set; get; }
        public string GAXH { set; get; }
        public string PLATENO { set; get; }
        public string PLATECLASS { set; get; }
        public string PLATECOLOR { set; get; }
        public string GAVTYPE { set; get; }
        public string EPVTYPE { set; get; }
        public string STVTYPE { set; get; }
        public string GAUSEC { set; get; }
        public string EPUSEC { set; get; }
        public string PREVDISTRICT { set; get; }
        public string CURDISTRICT { set; get; }
        public string FIRSTREGDATE { set; get; }
        public string SCRAPLIMITDATE { set; get; }
        public string EMISSION { set; get; }
        public string EPRANK { set; get; }
        public string VIN { set; get; }
        public string VIN8 { set; get; }
        public string BRAND { set; get; }
        public string MODEL { set; get; }
        public string SALETYPE { set; get; }
        public string MANUFCOUNTRY { set; get; }
        public string MANUFNAME { set; get; }
        public string ENGINENO { set; get; }
        public string ENGINEMODEL { set; get; }
        public string FUELTYPE { set; get; }
        public string DISPLACEMENT { set; get; }
        public string POWER { set; get; }
        public string REATEDPOWER { set; get; }
        public string REATEDSPEED { set; get; }
        public string AIRSUCTION { set; get; }
        public string BODYCOLOR { set; get; }
        public string BODYLENGTH { set; get; }
        public string BODYWIDTH { set; get; }
        public string BODYHEIGHT { set; get; }
        public string GROSSWEIGHT { set; get; }
        public string REATEDWEIGHT { set; get; }
        public string CURBWEIGHT { set; get; }
        public string PASSCAP { set; get; }
        public string TIRECOUNT { set; get; }
        public string TRAVELMILES { set; get; }
        public string DRIVEMODE { set; get; }
        public string GEARBOXTYPE { set; get; }
        public string EXFACTORYDATE { set; get; }
        public string GASTATUS { set; get; }
        public string EPSTATUS { set; get; }
        public string OWNERID { set; get; }
        public string OWNERNAME { set; get; }
        public string PROPRIGHT { set; get; }
        public string INSPLASTDATE { set; get; }
        public string INSPVALIDDATE { set; get; }
        public string TESTMETHOD { set; get; }
        public string ISOBD { set; get; }
        public string VEHICLEDESC { set; get; }
        public string TECHIDENTSTATUS { set; get; }
        public string CLINDYERNUM { set; get; }
        public string GEARNUM { set; get; }
        public string RMWEIGHT { set; get; }
        public string AXLEWEIGHT { set; get; }
        public string FUELWAY { set; get; }
        public string EXHAUSTDISPOSAL { set; get; }
        public string OXYGENSENSOR { set; get; }
        public string ENGINEMANUF { set; get; }

        public string OWNERPROPRIGHT { set; get; }
        public string OWNERCERTTYPE { set; get; }
        public string OWNERCERTNO { set; get; }
        public string OWNERTELNO { set; get; }
        public string OWNERADDRESS { set; get; }
        public string OWNERDISTRICT { set; get; }
        public string OWNERPOSTCODE { set; get; }

        public string REGID { set; get; }
        public string REGVEHICLEID { set; get; }
        public string REGPLATENO { set; get; }
        public string REGPLATECLASS { set; get; }
        public string REGPLATECOLOR { set; get; }
        public string REGVIN { set; get; }
        public string REGVIN8 { set; get; }
        public string REGEXFACTORYDATE { set; get; }
        public string REGVEHREGDATE { set; get; }
        public string REGVEHICLEMODEL { set; get; }
        public string REGFUELTYPE { set; get; }
        public string REGINSPFUELTYPE { set; get; }
        public string REGCLINDYERNUM { set; get; }
        public string REGTRAVELMILES { set; get; }
        public string REGVEHICLEDESC { set; get; }
        public string REGINSPTYPE { set; get; }
        public string REGINSPPERIOD { set; get; }
        public string REGINSPTIMES { set; get; }
        public string REGDISTRICT { set; get; }
        public string REGINSPSTATIONCODE { set; get; }
        public string REGINSPLINECODE { set; get; }
        public string REGTSNO { set; get; }
        public string REGTESTMETHOD { set; get; }
        public string REGREGUSERID { set; get; }
        public string REGREGTIME { set; get; }
        public string REGAPPOINTTESTTIME { set; get; }
        public string REGTESTNO { set; get; }
        public string REGRESULT { set; get; }
        public string REGAPPEARANCERESULT { set; get; }
        public string REGAPPEARANCECODE { set; get; }
        public string REGAPPEARANCEPERSON { set; get; }
        public string REGRECEIVABLES { set; get; }
        public string REGPROCEEDS { set; get; }
        public string REGINVOICENUM { set; get; }
        public string REGTOLLCOLLECTOR { set; get; }
        public string REGREGSTATUS { set; get; }
        

    }
    public class JHinterface
    {
        string securitycode = "";
        string inspstationcode = "";
        string insplinecode = "";
        IInspService outlineservice = null;
        public JHinterface(string url, string securitycode, string inspstationcode,string insplinecode)
        {
            outlineservice = new IInspService(url);
            this.securitycode = securitycode;
            this.inspstationcode = inspstationcode;
            this.insplinecode = insplinecode;
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
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }
        public bool CheckPrintIsEffective(string webadd,string testingid,out string testno, out string resultno, out string resultdesc, out checkResultModel checkmodel)
        {
            bool checkresult = false;
            resultno = "";
            resultdesc = "";
            testno = "";
            checkmodel = new checkResultModel();
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://"+ webadd + "/struts/intf/stationIntf!testingCheck.action?testingid=" + testingid);
            req.Method = "GET";
            string result = "";
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader sr = new StreamReader(wr.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd();
                INIIO.saveSocketLogInf("验证返回信息:\r\n" + result);
                if (result != "")
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        ds = XmlToData.CXmlToDataSet(result);
                        DataTable checkinfo = ds.Tables["checkinfo"];
                        resultno = ds.Tables["resultno"].Rows[0]["resultno_Text"].ToString();
                        resultdesc = ds.Tables["resultdesc"].Rows[0]["resultdesc_Text"].ToString();
                        if(ds.Tables.Contains("testno"))
                            testno = ds.Tables["testno"].Rows[0]["testno_Text"].ToString();
                        if (int.Parse(resultno) > 0)
                        {
                            checkmodel.testmethod = checkinfo.Rows[0]["testmethod"].ToString();
                            checkmodel.testresult = checkinfo.Rows[0]["testresult"].ToString();
                            checkmodel.value01 = checkinfo.Rows[0]["value01"].ToString();
                            checkmodel.value02 = checkinfo.Rows[0]["value02"].ToString();
                            checkmodel.value03 = checkinfo.Rows[0]["value03"].ToString();
                            checkmodel.value04 = checkinfo.Rows[0]["value04"].ToString();
                            checkmodel.value05 = checkinfo.Rows[0]["value05"].ToString();
                            checkmodel.value06 = checkinfo.Rows[0]["value06"].ToString();
                            checkmodel.limit01 = checkinfo.Rows[0]["limit01"].ToString();
                            checkmodel.limit02 = checkinfo.Rows[0]["limit02"].ToString();
                            checkmodel.limit03 = checkinfo.Rows[0]["limit03"].ToString();
                            checkmodel.limit04 = checkinfo.Rows[0]["limit04"].ToString();
                            checkmodel.limit05 = checkinfo.Rows[0]["limit05"].ToString();
                            checkmodel.limit06 = checkinfo.Rows[0]["limit06"].ToString();
                            checkmodel.judge01 = checkinfo.Rows[0]["judge01"].ToString();
                            checkmodel.judge02 = checkinfo.Rows[0]["judge02"].ToString();
                            checkmodel.judge03 = checkinfo.Rows[0]["judge03"].ToString();
                            checkmodel.judge04 = checkinfo.Rows[0]["judge04"].ToString();
                            checkmodel.judge05 = checkinfo.Rows[0]["judge05"].ToString();
                            checkmodel.judge06 = checkinfo.Rows[0]["judge06"].ToString();
                            checkmodel.parame01 = checkinfo.Rows[0]["parame01"].ToString();
                            checkmodel.parame02 = checkinfo.Rows[0]["parame02"].ToString();
                            checkmodel.parame03 = checkinfo.Rows[0]["parame03"].ToString();
                            checkmodel.parame04 = checkinfo.Rows[0]["parame04"].ToString();
                            checkmodel.parame05 = checkinfo.Rows[0]["parame05"].ToString();
                            checkmodel.parame06 = checkinfo.Rows[0]["parame06"].ToString();
                        }
                        checkresult = true;
                    }
                    catch (Exception er)
                    {
                        resultno = "-1";
                        resultdesc = er.Message;
                    }
                }
                //在这里对接收到的页面内容进行处理
            }
            return checkresult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskcount">0：表示所有待检及已发布的任务>0：表示按登记时间排序的车辆任务数</param>
        /// <returns></returns>
        public string getInspReg(int taskcount, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist,out List<JHvehicleInf> jhvehiclelist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            jhvehiclelist = new List<JHvehicleInf>();
            string xmlstring = outlineservice.getInspReg(securitycode, inspstationcode, insplinecode, taskcount);
            INIIO.saveSocketLogInf("RECEIVE:\r\n" + xmlstring);
            string result = getCarWaitList(xmlstring, out carwaitlist, out carinflist,out jhvehiclelist);
            return result;
        }
        public string getInspReg2(string plateno,string platecolor,string vin8, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist, out List<JHvehicleInf> jhvehiclelist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            //jhvehiclelist = new List<JHvehicleInf>();
            string xmlstring = outlineservice.getInspReg2(securitycode, inspstationcode, plateno, platecolor, vin8);
            INIIO.saveSocketLogInf("RECEIVE:\r\n" + xmlstring);
            string result = getCarWaitList(xmlstring, out carwaitlist, out carinflist, out jhvehiclelist);
            return result;
        }

        private string getCarWaitList(string xmlstring, out List<CARATWAIT> carwaitlist, out List<CARINF> carinflist,out List<JHvehicleInf> jhvehiclelist)
        {
            carwaitlist = new List<CARATWAIT>();
            carinflist = new List<CARINF>();
            jhvehiclelist = new List<JHvehicleInf>();
            try
            {
                DataSet ds = new DataSet();
                ds = XmlToData.CXmlToDataSet(xmlstring);
                string errorinfo = ds.Tables[0].Rows[0]["errorinfo"].ToString();
                //Console.Write(errorinfo + "/r/n");
                switch (errorinfo)
                {
                    case "ERROR-001":
                        return "请求参数securitycode(安全码)不能为空";
                        break;
                    case "ERROR-002":
                        return "请求参数inspstationcode (检测站代码)不能为空";
                        break;
                    case "ERROR-003":
                        return "请求参数taskcount(检测登记任务数)值需>=0";
                        break;
                    case "ERROR-004":
                        return "该检测站代码对应的安全码验证失败";
                        break;
                    case "ERROR-005":
                        return "请求参数insplinecode(检测线代码)不能为空";
                        break;
                    default: break;
                }
                DataTable vehicletable = ds.Tables["vehicle"];
                DataTable ownertable = ds.Tables["owner"];
                DataTable regtable = ds.Tables["reg"];
                if (vehicletable != null)
                {
                    for (int i = 0; i < vehicletable.Rows.Count; i++)
                    {
                        JHvehicleInf jhvehiclemodel = new JHvehicleInf();
                        jhvehiclemodel.ID = vehicletable.Rows[i]["ID"].ToString();
                        jhvehiclemodel.GAXH = vehicletable.Rows[i]["GAXH"].ToString();
                        jhvehiclemodel.PLATENO = vehicletable.Rows[i]["PLATENO"].ToString();
                        jhvehiclemodel.PLATECLASS = vehicletable.Rows[i]["PLATECLASS"].ToString();
                        jhvehiclemodel.PLATECOLOR = vehicletable.Rows[i]["PLATECOLOR"].ToString();
                        jhvehiclemodel.GAVTYPE = vehicletable.Rows[i]["GAVTYPE"].ToString();
                        jhvehiclemodel.EPVTYPE = vehicletable.Rows[i]["EPVTYPE"].ToString();
                        jhvehiclemodel.PLATENO = vehicletable.Rows[i]["PLATENO"].ToString();
                        jhvehiclemodel.STVTYPE = vehicletable.Rows[i]["STVTYPE"].ToString();
                        jhvehiclemodel.GAUSEC = vehicletable.Rows[i]["GAUSEC"].ToString();
                        jhvehiclemodel.EPUSEC = vehicletable.Rows[i]["EPUSEC"].ToString();
                        jhvehiclemodel.PREVDISTRICT = vehicletable.Rows[i]["PREVDISTRICT"].ToString();
                        jhvehiclemodel.CURDISTRICT = vehicletable.Rows[i]["CURDISTRICT"].ToString();
                        jhvehiclemodel.FIRSTREGDATE = vehicletable.Rows[i]["FIRSTREGDATE"].ToString();
                        jhvehiclemodel.SCRAPLIMITDATE = vehicletable.Rows[i]["SCRAPLIMITDATE"].ToString();
                        jhvehiclemodel.EMISSION = vehicletable.Rows[i]["EMISSION"].ToString();
                        jhvehiclemodel.EPRANK = vehicletable.Rows[i]["EPRANK"].ToString();
                        jhvehiclemodel.VIN = vehicletable.Rows[i]["VIN"].ToString();
                        jhvehiclemodel.VIN8 = vehicletable.Rows[i]["VIN8"].ToString();
                        jhvehiclemodel.BRAND = vehicletable.Rows[i]["BRAND"].ToString();

                        jhvehiclemodel.MODEL = vehicletable.Rows[i]["MODEL"].ToString();
                        jhvehiclemodel.SALETYPE = vehicletable.Rows[i]["SALETYPE"].ToString();
                        jhvehiclemodel.MANUFCOUNTRY = vehicletable.Rows[i]["MANUFCOUNTRY"].ToString();
                        jhvehiclemodel.MANUFNAME = vehicletable.Rows[i]["MANUFNAME"].ToString();
                        jhvehiclemodel.ENGINENO = vehicletable.Rows[i]["ENGINENO"].ToString();
                        jhvehiclemodel.ENGINEMODEL = vehicletable.Rows[i]["ENGINEMODEL"].ToString();
                        jhvehiclemodel.FUELTYPE = vehicletable.Rows[i]["FUELTYPE"].ToString();
                        jhvehiclemodel.DISPLACEMENT = vehicletable.Rows[i]["DISPLACEMENT"].ToString();
                        jhvehiclemodel.POWER = vehicletable.Rows[i]["POWER"].ToString();
                        jhvehiclemodel.REATEDPOWER = vehicletable.Rows[i]["REATEDPOWER"].ToString();
                        jhvehiclemodel.REATEDSPEED = vehicletable.Rows[i]["REATEDSPEED"].ToString();
                        jhvehiclemodel.AIRSUCTION = vehicletable.Rows[i]["AIRSUCTION"].ToString();
                        jhvehiclemodel.BODYCOLOR = vehicletable.Rows[i]["BODYCOLOR"].ToString();
                        jhvehiclemodel.BODYLENGTH = vehicletable.Rows[i]["BODYLENGTH"].ToString();
                        jhvehiclemodel.BODYWIDTH = vehicletable.Rows[i]["BODYWIDTH"].ToString();
                        jhvehiclemodel.BODYHEIGHT = vehicletable.Rows[i]["BODYHEIGHT"].ToString();
                        jhvehiclemodel.GROSSWEIGHT = vehicletable.Rows[i]["GROSSWEIGHT"].ToString();
                        jhvehiclemodel.REATEDWEIGHT = vehicletable.Rows[i]["REATEDWEIGHT"].ToString();
                        jhvehiclemodel.CURBWEIGHT = vehicletable.Rows[i]["CURBWEIGHT"].ToString();
                        jhvehiclemodel.PASSCAP = vehicletable.Rows[i]["PASSCAP"].ToString();
                        jhvehiclemodel.TIRECOUNT = vehicletable.Rows[i]["TIRECOUNT"].ToString();
                        jhvehiclemodel.TRAVELMILES = vehicletable.Rows[i]["TRAVELMILES"].ToString();
                        jhvehiclemodel.DRIVEMODE = vehicletable.Rows[i]["DRIVEMODE"].ToString();
                        jhvehiclemodel.GEARBOXTYPE = vehicletable.Rows[i]["GEARBOXTYPE"].ToString();
                        jhvehiclemodel.EXFACTORYDATE = vehicletable.Rows[i]["EXFACTORYDATE"].ToString();
                        jhvehiclemodel.OWNERID = vehicletable.Rows[i]["OWNERID"].ToString();
                        jhvehiclemodel.OWNERNAME = vehicletable.Rows[i]["OWNERNAME"].ToString();
                        jhvehiclemodel.PROPRIGHT = vehicletable.Rows[i]["PROPRIGHT"].ToString();
                        jhvehiclemodel.INSPLASTDATE = vehicletable.Rows[i]["INSPLASTDATE"].ToString();
                        jhvehiclemodel.INSPVALIDDATE = vehicletable.Rows[i]["INSPVALIDDATE"].ToString();
                        jhvehiclemodel.TESTMETHOD = vehicletable.Rows[i]["TESTMETHOD"].ToString();
                        jhvehiclemodel.ISOBD = vehicletable.Rows[i]["ISOBD"].ToString();
                        jhvehiclemodel.VEHICLEDESC = vehicletable.Rows[i]["VEHICLEDESC"].ToString();
                        jhvehiclemodel.TECHIDENTSTATUS = vehicletable.Rows[i]["TECHIDENTSTATUS"].ToString();
                        jhvehiclemodel.CLINDYERNUM = vehicletable.Rows[i]["CLINDYERNUM"].ToString();
                        jhvehiclemodel.GEARNUM = vehicletable.Rows[i]["GEARNUM"].ToString();
                        jhvehiclemodel.RMWEIGHT = vehicletable.Rows[i]["RMWEIGHT"].ToString();
                        jhvehiclemodel.AXLEWEIGHT = vehicletable.Rows[i]["AXLEWEIGHT"].ToString();
                        jhvehiclemodel.FUELWAY = vehicletable.Rows[i]["FUELWAY"].ToString();
                        jhvehiclemodel.EXHAUSTDISPOSAL = vehicletable.Rows[i]["EXHAUSTDISPOSAL"].ToString();
                        jhvehiclemodel.OXYGENSENSOR = vehicletable.Rows[i]["OXYGENSENSOR"].ToString();
                        jhvehiclemodel.ENGINEMANUF = vehicletable.Rows[i]["ENGINEMANUF"].ToString();

                        jhvehiclemodel.OWNERPROPRIGHT = ownertable.Rows[i]["PROPRIGHT"].ToString();
                        jhvehiclemodel.OWNERCERTTYPE = ownertable.Rows[i]["CERTTYPE"].ToString();
                        jhvehiclemodel.OWNERCERTNO = ownertable.Rows[i]["CERTNO"].ToString();
                        jhvehiclemodel.OWNERTELNO = ownertable.Rows[i]["TELNO"].ToString();
                        jhvehiclemodel.OWNERADDRESS = ownertable.Rows[i]["ADDRESS"].ToString();
                        jhvehiclemodel.OWNERDISTRICT = ownertable.Rows[i]["DISTRICT"].ToString();
                        jhvehiclemodel.OWNERPOSTCODE = ownertable.Rows[i]["POSTCODE"].ToString();

                        jhvehiclemodel.REGID = regtable.Rows[i]["ID"].ToString();
                        jhvehiclemodel.REGVEHICLEID = regtable.Rows[i]["VEHICLEID"].ToString();
                        jhvehiclemodel.REGPLATENO = regtable.Rows[i]["PLATENO"].ToString();
                        jhvehiclemodel.REGPLATECLASS = regtable.Rows[i]["PLATECLASS"].ToString();
                        jhvehiclemodel.REGPLATECOLOR = regtable.Rows[i]["PLATECOLOR"].ToString();
                        jhvehiclemodel.REGVIN = regtable.Rows[i]["VIN"].ToString();
                        jhvehiclemodel.REGVIN8 = regtable.Rows[i]["VIN8"].ToString();
                        jhvehiclemodel.REGEXFACTORYDATE = regtable.Rows[i]["EXFACTORYDATE"].ToString();
                        jhvehiclemodel.REGVEHREGDATE = regtable.Rows[i]["VEHREGDATE"].ToString();
                        jhvehiclemodel.REGVEHICLEMODEL = regtable.Rows[i]["VEHICLEMODEL"].ToString();
                        jhvehiclemodel.REGFUELTYPE = regtable.Rows[i]["FUELTYPE"].ToString();
                        jhvehiclemodel.REGINSPFUELTYPE = regtable.Rows[i]["INSPFUELTYPE"].ToString();
                        jhvehiclemodel.REGCLINDYERNUM = regtable.Rows[i]["CLINDYERNUM"].ToString();
                        jhvehiclemodel.REGTRAVELMILES = regtable.Rows[i]["TRAVELMILES"].ToString();
                        jhvehiclemodel.REGVEHICLEDESC = regtable.Rows[i]["VEHICLEDESC"].ToString();
                        jhvehiclemodel.REGINSPTYPE = regtable.Rows[i]["INSPTYPE"].ToString();
                        jhvehiclemodel.REGINSPPERIOD = regtable.Rows[i]["INSPPERIOD"].ToString();
                        jhvehiclemodel.REGINSPTIMES = regtable.Rows[i]["INSPTIMES"].ToString();
                        jhvehiclemodel.REGDISTRICT = regtable.Rows[i]["DISTRICT"].ToString();
                        jhvehiclemodel.REGINSPSTATIONCODE = regtable.Rows[i]["INSPSTATIONCODE"].ToString();
                        jhvehiclemodel.REGINSPLINECODE = regtable.Rows[i]["INSPLINECODE"].ToString();
                        jhvehiclemodel.REGTSNO = regtable.Rows[i]["TSNO"].ToString();
                        jhvehiclemodel.REGTESTMETHOD = regtable.Rows[i]["TESTMETHOD"].ToString();
                        jhvehiclemodel.REGREGUSERID = regtable.Rows[i]["REGUSERID"].ToString();
                        jhvehiclemodel.REGREGTIME = regtable.Rows[i]["REGTIME"].ToString();
                        jhvehiclemodel.REGAPPOINTTESTTIME = regtable.Rows[i]["APPOINTTESTTIME"].ToString();
                        jhvehiclemodel.REGTESTNO = regtable.Rows[i]["TESTNO"].ToString();
                        jhvehiclemodel.REGRESULT = regtable.Rows[i]["RESULT"].ToString();
                        jhvehiclemodel.REGAPPEARANCERESULT = regtable.Rows[i]["APPEARANCERESULT"].ToString();
                        jhvehiclemodel.REGAPPEARANCECODE = regtable.Rows[i]["APPEARANCECODE"].ToString();
                        jhvehiclemodel.REGAPPEARANCEPERSON = regtable.Rows[i]["APPEARANCEPERSON"].ToString();
                        jhvehiclemodel.REGRECEIVABLES = regtable.Rows[i]["RECEIVABLES"].ToString();
                        jhvehiclemodel.REGPROCEEDS = regtable.Rows[i]["PROCEEDS"].ToString();
                        jhvehiclemodel.REGINVOICENUM = regtable.Rows[i]["INVOICENUM"].ToString();
                        jhvehiclemodel.REGTOLLCOLLECTOR = regtable.Rows[i]["TOLLCOLLECTOR"].ToString();
                        jhvehiclemodel.REGREGSTATUS = regtable.Rows[i]["REGSTATUS"].ToString();

                        CARINF model = new CARINF();
                        model.CLHP = vehicletable.Rows[i]["PLATENO"].ToString();
                        switch(vehicletable.Rows[i]["PLATECLASS"].ToString())
                        {
                            case "01":model.HPZL = "大型汽车号牌";break;
                            case "02": model.HPZL = "小型汽车号牌"; break;
                            case "03": model.HPZL = "使馆汽车号牌"; break;
                            case "04": model.HPZL = "领馆汽车号牌"; break;
                            case "05": model.HPZL = "境外汽车号牌"; break;
                            case "06": model.HPZL = "外籍汽车号牌"; break;
                            case "07": model.HPZL = "两、三轮摩托车号牌"; break;
                            case "08": model.HPZL = "轻便摩托车号牌"; break;
                            case "09": model.HPZL = "使馆摩托车号牌"; break;
                            case "10": model.HPZL = "领馆摩托车号牌"; break;
                            case "11": model.HPZL = "境外摩托车号牌"; break;
                            case "12": model.HPZL = "外籍摩托车号牌"; break;
                            case "13": model.HPZL = "农用运输车号牌"; break;
                            case "14": model.HPZL = "拖拉机号牌"; break;
                            case "15": model.HPZL = "挂车号牌"; break;
                            case "16": model.HPZL = "教练汽车号牌"; break;
                            case "17": model.HPZL = "教练摩托车号牌"; break;
                            case "18": model.HPZL = "试验汽车号牌"; break;
                            case "19": model.HPZL = "试验摩托车号牌"; break;
                            case "20": model.HPZL = "临时人境汽车号牌"; break;
                            case "21": model.HPZL = "临时人境摩托车号牌"; break;
                            case "22": model.HPZL = "临时行驶车号牌"; break;
                            case "23": model.HPZL = "警用汽车号牌"; break;
                            case "24": model.HPZL = "警用摩托号牌"; break;
                            case "99": model.HPZL = "其他号牌"; break;
                            default: model.HPZL = ""; break;

                        }
                        //model.CPYS = vehicletable.Rows[i]["PLATECOLOR"].ToString();
                        switch (vehicletable.Rows[i]["PLATECOLOR"].ToString())
                        {
                            case "1": model.CPYS = "蓝牌"; break;
                            case "2": model.CPYS = "黄牌"; break;
                            case "3": model.CPYS = "黑牌"; break;
                            case "4": model.CPYS = "白牌"; break;
                            case "0": model.CPYS = "未知"; break;
                            default:
                                model.CPYS = ""; break;

                        }
                        model.CLLX = vehicletable.Rows[i]["GAVTYPE"].ToString();
                        model.CZ = vehicletable.Rows[i]["OWNERNAME"].ToString();
                        //model.SYXZ = vehicletable.Rows[i]["GAUSEC"].ToString();
                        switch (vehicletable.Rows[i]["GAUSEC"].ToString())
                        {
                            case "A": model.SYXZ = "非营运"; break;
                            case "B": model.SYXZ = "公路客运"; break;
                            case "C": model.SYXZ = "公交客运"; break;
                            case "D": model.SYXZ = "出租客运"; break;
                            case "E": model.SYXZ = "旅游客运"; break;
                            case "F": model.SYXZ = "货运"; break;
                            case "G": model.SYXZ = "租赁"; break;
                            case "H": model.SYXZ = "警用"; break;
                            case "I": model.SYXZ = "消防"; break;
                            case "J": model.SYXZ = "救护"; break;
                            case "K": model.SYXZ = "工程抢险"; break;
                            case "L": model.SYXZ = "营转非"; break;
                            case "M": model.SYXZ = "出租转非"; break;
                            case "N": model.SYXZ = "教练"; break;
                            case "O": model.SYXZ = "幼儿校车"; break;
                            case "P": model.SYXZ = "小学生校车"; break;
                            case "Q": model.SYXZ = "其他校车"; break;
                            case "R": model.SYXZ = "危化品运输"; break;
                            case "Z": model.SYXZ = "其他"; break;
                            default:
                                model.SYXZ = ""; break;

                        }
                        model.PP = vehicletable.Rows[i]["BRAND"].ToString();
                        model.XH = vehicletable.Rows[i]["MODEL"].ToString();
                        model.CLSBM = vehicletable.Rows[i]["VIN"].ToString();
                        model.FDJHM = vehicletable.Rows[i]["ENGINENO"].ToString();
                        //model.FDJHM = "";

                        model.FDJXH = vehicletable.Rows[i]["ENGINEMODEL"].ToString();
                        model.SCQY = vehicletable.Rows[i]["MANUFNAME"].ToString();
                        model.HDZK = vehicletable.Rows[i]["PASSCAP"].ToString();
                        model.JSSZK = "0";
                        model.ZZL = vehicletable.Rows[i]["GROSSWEIGHT"].ToString();
                        model.HDZZL = vehicletable.Rows[i]["REATEDWEIGHT"].ToString();
                        model.ZBZL = vehicletable.Rows[i]["CURBWEIGHT"].ToString();
                        model.JZZL = vehicletable.Rows[i]["RMWEIGHT"].ToString();
                        model.ZCRQ = DateTime.Parse(vehicletable.Rows[i]["FIRSTREGDATE"].ToString());
                        model.SCRQ = DateTime.Parse(vehicletable.Rows[i]["EXFACTORYDATE"].ToString());

                        model.FDJPL = vehicletable.Rows[i]["DISPLACEMENT"].ToString();
                        //model.RLZL = vehicletable.Rows[i]["FUELTYPE"].ToString();
                        switch (vehicletable.Rows[i]["FUELTYPE"].ToString())
                        {
                            case "A": model.RLZL = "汽油"; break;
                            case "B": model.RLZL = "柴油"; break;
                            case "C": model.RLZL = "电"; break;
                            case "D": model.RLZL = "混合油"; break;
                            case "E": model.RLZL = "天然气"; break;
                            case "F": model.RLZL = "液化石油气"; break;                            
                            case "L": model.RLZL = "甲醇"; break;
                            case "M": model.RLZL = "乙醇"; break;
                            case "N": model.RLZL = "太阳能"; break;
                            case "O": model.RLZL = "混合动力"; break;
                            case "Y": model.RLZL = "无"; break;
                            case "Z": model.RLZL = "其它"; break;
                            case "A1": model.RLZL = "油改气"; break;
                            default:
                                model.RLZL = ""; break;

                        }
                        model.EDGL = vehicletable.Rows[i]["REATEDPOWER"].ToString();
                        model.EDZS = vehicletable.Rows[i]["REATEDSPEED"].ToString();
                        //model.BSQXS = vehicletable.Rows[i]["GEARBOXTYPE"].ToString();
                        switch (vehicletable.Rows[i]["GEARBOXTYPE"].ToString())
                        {
                            case "1": model.BSQXS = "手动"; break;
                            case "2": model.BSQXS = "自动"; break;
                            default:
                                model.BSQXS = ""; break;

                        }
                        model.DWS = vehicletable.Rows[i]["GEARNUM"].ToString();
                        //model.GYFS = vehicletable.Rows[i]["FUELWAY"].ToString();
                        switch (vehicletable.Rows[i]["FUELWAY"].ToString())
                        {
                            case "1": model.GYFS = "开环电喷"; break;
                            case "2": model.GYFS = "闭环电喷"; break;
                            case "3": model.GYFS = "直喷"; break;
                            case "9": model.GYFS = "化油器"; break;
                            default:
                                model.GYFS = ""; break;

                        }
                        //model.GYFS = "";
                        model.DPFS = "";
                        //model.JQFS = vehicletable.Rows[i]["AIRSUCTION"].ToString();
                        switch (vehicletable.Rows[i]["AIRSUCTION"].ToString())
                        {
                            case "1": model.JQFS = "自然吸气"; break;
                            case "2": model.JQFS = "涡轮增压"; break;
                            case "9": model.JQFS = "其他"; break;
                            default:
                                model.JQFS = ""; break;

                        }
                        model.QGS = vehicletable.Rows[i]["CLINDYERNUM"].ToString();

                        //model.QDXS = vehicletable.Rows[i]["DRIVEMODE"].ToString();
                        switch (vehicletable.Rows[i]["DRIVEMODE"].ToString())
                        {
                            case "1": model.QDXS = "前驱"; break;
                            case "2": model.QDXS = "后驱"; break;
                            case "3": model.QDXS = "四驱"; break;
                            case "4": model.QDXS = "全时四驱"; break;
                            default:
                                model.QDXS = ""; break;

                        }
                        model.CHZZ = "";
                        model.DLSP = "";
                        model.SFSRL = "";
                        switch (vehicletable.Rows[i]["EXHAUSTDISPOSAL"].ToString())
                        {
                            case "1": model.JHZZ = "有三元催化器"; break;
                            case "2": model.JHZZ = "有尾气过滤装置"; break;
                            default:
                                model.JHZZ = ""; break;

                        }
                        model.OBD = "";
                        model.DKGYYB = "";
                        model.LXDH = ownertable.Rows[i]["TELNO"].ToString();
                        model.CLZL = "";
                        model.CZDZ = ownertable.Rows[i]["ADDRESS"].ToString();

                        model.JCFS = "";
                        model.JCLB = "";
                        model.SSXQ = vehicletable.Rows[i]["PLATECOLOR"].ToString();
                        model.FDJSCQY = "";
                        model.QDLTQY = "";
                        model.RYPH = "";
                        model.SFWDZR = "";
                        model.SFYQBF = "";
                        model.ZXBZ = "";
                        model.CSYS = "";
                        CARATWAIT waitmodel = new CARATWAIT();
                        waitmodel.CLID = vehicletable.Rows[i]["ID"].ToString();
                        waitmodel.CLHP = vehicletable.Rows[i]["PLATENO"].ToString();
                        waitmodel.DLSJ = DateTime.Now;
                        waitmodel.CPYS = regtable.Rows[i]["PLATECOLOR"].ToString();
                        switch (regtable.Rows[i]["TESTMETHOD"].ToString())
                        {
                            case "1":
                                waitmodel.JCFF = "DS";
                                break;
                            case "2":
                                waitmodel.JCFF = "SDS";
                                break;
                            case "3":
                                waitmodel.JCFF = "LZ";
                                break;
                            case "4":
                                waitmodel.JCFF = "ZYJS";
                                break;
                            case "5":
                                waitmodel.JCFF = "ASM";
                                break;
                            case "6":
                                waitmodel.JCFF = "VMAS";
                                break;
                            case "7":
                                waitmodel.JCFF = "JZJS";
                                break;
                            case "8":
                                waitmodel.JCFF = "MAS";
                                break;
                            case "9":
                                waitmodel.JCFF = "LS";
                                break;
                            default: break;
                        }
                        waitmodel.XSLC = regtable.Rows[i]["TRAVELMILES"].ToString();
                        waitmodel.JCCS = regtable.Rows[i]["INSPTIMES"].ToString();
                        waitmodel.CZY = "";
                        waitmodel.JSY = "";
                        waitmodel.DLY = regtable.Rows[i]["REGUSERID"].ToString();
                        waitmodel.JCFY = "";
                        waitmodel.TEST = "";
                        //waitmodel.JCBGBH = regtable.Rows[i]["TESTNO"].ToString();
                        waitmodel.JCBGBH = "";
                        waitmodel.JCGWH = "";
                        waitmodel.JCZBH = regtable.Rows[i]["INSPSTATIONCODE"].ToString();
                        waitmodel.JCRQ = DateTime.Now;
                        waitmodel.BGJCFFYY = "";
                        waitmodel.SFCS = "";
                        waitmodel.ECRYPT = "";
                        waitmodel.SFCJ = (int.Parse(regtable.Rows[i]["INSPTIMES"].ToString()) > 1 ? "复检" : "初检");
                        waitmodel.JYLSH = "";
                        waitmodel.HPZL = regtable.Rows[i]["PLATECLASS"].ToString();
                        carinflist.Add(model);
                        carwaitlist.Add(waitmodel);
                        jhvehiclelist.Add(jhvehiclemodel);
                    }
                }
                return "获取成功";
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
    }
}
