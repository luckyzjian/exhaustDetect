using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace exhaustDetect
{
    public class hyDatabaseInter
    {
        public static string strConn="";
        public static bool initConn()
        {
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                string udl = AppDomain.CurrentDomain.BaseDirectory + "\\华燕数据库.udl";
                StreamReader sr = new StreamReader(udl, Encoding.Default);
                for (int i = 0; i < 3; i++)
                {
                    strConn = sr.ReadLine();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool readGroup(out DataTable dt)
        {
            dt = null;
            try
            {
                OleDbConnection adoConn = new OleDbConnection();                
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "select * from UserGrant";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(checksql, adoConn);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "table");
                    dt = dataSet.Tables["table"];
                    return true;

                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("读取UserGrant发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到UserGrant失败:" + er.Message);
                return false;
            }
        }
        public static bool readUserByGourpID(string groupID,out DataTable dt)
        {
            dt = null;
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "select * from Employee where GroupID='"+groupID+"'";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(checksql, adoConn);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "table");
                    dt = dataSet.Tables["table"];
                    return true;
                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("读取Employee发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到Employee失败:" + er.Message);
                return false;
            }
        }
        public static bool checkUserIsAlive(string username,string password)
        {
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "select count(*) from Employee where EMP_NAME='" + username + "' and (PassWordStr='"+password+"' or PassWordStr is null)";
                    OleDbCommand dataAdapter = new OleDbCommand(checksql, adoConn);
                    int count=Convert.ToInt32(dataAdapter.ExecuteScalar());
                    return (count > 0);
                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("读取Employee发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到Employee失败:" + er.Message);
                return false;
            }
        }
        public static bool deleteCarWaitByRegID(string reg_ID)
        {
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "delete from RegTeam where Reg_ID='" + reg_ID + "'";
                    OleDbCommand dataAdapter = new OleDbCommand(checksql, adoConn);
                    int count = Convert.ToInt32(dataAdapter.ExecuteScalar());
                    return (count > 0);
                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("删除RegTeam发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到RegTeam失败:" + er.Message);
                return false;
            }
        }
        public static bool readRegTeam(out DataTable dt)
        {
            dt = null;
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "select * from RegTeam";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(checksql, adoConn);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "table");
                     dt = dataSet.Tables["table"];
                    return true;

                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("读取RegTeam发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到RegTeam失败:" + er.Message);
                return false;
            }
        }
        public static bool readCarBjByRegID(string regid, out SYS.Model.CARATWAIT model,out SYS.Model.CARINF modelbj)
        {
            model = new SYS.Model.CARATWAIT();
            modelbj = new SYS.Model.CARINF();
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                try
                {
                    ini.INIIO.saveLogInf("连接数据库成功");
                    string checksql = "select * from RegTeam a, CarInfo b where a.Reg_ID = '"+ regid+"' and b.Car_ID = a.Car_ID";//联合查询
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(checksql, adoConn);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "table");
                    DataTable dt = dataSet.Tables["table"];
                    if (dt.Rows.Count > 0)
                    {
                        DateTime a;
                        model.CLID = dt.Rows[0]["Reg_ID"].ToString();
                        model.DLSJ = DateTime.Parse(dt.Rows[0]["Reg_Date"].ToString());
                        model.CLHP = dt.Rows[0]["Reg_CPH"].ToString();
                        model.HPZL = dt.Rows[0]["Reg_PZLBID"].ToString();
                        model.CPYS = dt.Rows[0]["PZLBStrY1"].ToString();
                        model.JCFF = mainPanel.acDicJcff.GetValue(dt.Rows[0]["Reg_TestType"].ToString(),"");
                        model.XSLC = dt.Rows[0]["Reg_Kilometer"].ToString();
                        model.JCCS = dt.Rows[0]["RegBYI1"].ToString();
                        model.CZY = dt.Rows[0]["Reg_JCY"].ToString();
                        model.JSY = dt.Rows[0]["Reg_YCY"].ToString();
                        model.DLY = dt.Rows[0]["Reg_DLY"].ToString();
                        model.JCFY = "0";
                        model.TEST = "Y";
                        model.JCBGBH = dt.Rows[0]["CarBYS2"].ToString();
                        model.JCGWH = "";
                        model.JCZBH = "";
                        model.JCRQ =DateTime.Now;
                        model.BGJCFFYY = "";
                        model.SFCS ="0";
                        model.ECRYPT = dt.Rows[0]["CarBYS6"].ToString();
                        model.JYLSH = dt.Rows[0]["CarBYS2"].ToString();
                        model.SFCJ = dt.Rows[0]["CarBYS3"].ToString();

                        modelbj.CLHP = dt.Rows[0]["Reg_CPH"].ToString();//1
                        modelbj.CPYS = dt.Rows[0]["PZLBStrY1"].ToString();
                        modelbj.HPZL = dt.Rows[0]["Reg_PZLBID"].ToString();
                        modelbj.CLLX = dt.Rows[0]["Car_CLLxID"].ToString();
                        modelbj.CZ = dt.Rows[0]["Car_DW"].ToString();
                        modelbj.SYXZ =mainPanel.acDicSyxzRev.GetValue(dt.Rows[0]["CarYongtu"].ToString(),"");
                        modelbj.PP = dt.Rows[0]["Car_ChangPH"].ToString();//5
                        modelbj.XH = dt.Rows[0]["Car_XingHao"].ToString();
                        modelbj.CLSBM = dt.Rows[0]["Car_Vin"].ToString();
                        modelbj.FDJHM = dt.Rows[0]["Car_FDJXH"].ToString();
                        modelbj.FDJXH = dt.Rows[0]["Car_FDJXH"].ToString();
                        modelbj.SCQY = dt.Rows[0]["Car_MakeFac"].ToString();//10
                        modelbj.HDZK = dt.Rows[0]["Car_ZKRS"].ToString();
                        modelbj.JSSZK = "1";
                        modelbj.ZZL = dt.Rows[0]["Car_ZZL"].ToString();
                        modelbj.HDZZL ="0";
                        modelbj.ZBZL = dt.Rows[0]["Car_ZBZL"].ToString();//15
                        modelbj.JZZL =(int.Parse(dt.Rows[0]["Car_ZBZL"].ToString())+100).ToString();
                        DateTime.TryParse(dt.Rows[0]["Car_DjDate"].ToString(), out a);
                        if (a != null)
                            modelbj.ZCRQ = a;
                        else
                            modelbj.ZCRQ = DateTime.Today;
                        DateTime.TryParse(dt.Rows[0]["Car_MakeDate"].ToString(), out a);
                        if (a != null)
                            modelbj.SCRQ = a;
                        else
                            modelbj.SCRQ = DateTime.Today;
                        modelbj.FDJPL = dt.Rows[0]["Car_PL"].ToString();
                        modelbj.RLZL = dt.Rows[0]["Car_RLTypeStr"].ToString();//20
                        modelbj.EDGL = dt.Rows[0]["Car_EDGL"].ToString();
                        modelbj.EDZS = dt.Rows[0]["Car_EDGLRPM"].ToString();
                        modelbj.BSQXS = dt.Rows[0]["Car_BSXID"].ToString();
                        modelbj.DWS = dt.Rows[0]["Car_DWCount"].ToString();
                        modelbj.GYFS = dt.Rows[0]["Car_GYTypeID"].ToString();//25
                        modelbj.DPFS = dt.Rows[0]["Car_GYTypeID"].ToString();
                        modelbj.JQFS = dt.Rows[0]["Car_ZYTypeID"].ToString();
                        modelbj.QGS = dt.Rows[0]["Car_QGS"].ToString();
                        modelbj.QDXS = dt.Rows[0]["Car_QDXSID"].ToString();
                        modelbj.CHZZ = "";//30
                        modelbj.DLSP ="";
                        modelbj.SFSRL = "";
                        modelbj.JHZZ = dt.Rows[0]["Car_PQHCLZZ"].ToString();
                        modelbj.OBD = "";
                        modelbj.DKGYYB = "";//35
                        modelbj.LXDH = dt.Rows[0]["Car_DWTelephone"].ToString();
                        modelbj.CZDZ = dt.Rows[0]["Car_DWAddres"].ToString();
                        modelbj.JCFS = "0";
                        modelbj.JCLB = "01";
                        modelbj.CLZL = dt.Rows[0]["Car_CLLbID"].ToString();
                        modelbj.SSXQ = dt.Rows[0]["SSQY"].ToString();
                        modelbj.SFWDZR = dt.Rows[0]["Car_IsWDZR"].ToString();
                        modelbj.SFYQBF = "0";
                        modelbj.FDJSCQY = dt.Rows[0]["EngineFac"].ToString();
                        modelbj.QDLTQY = dt.Rows[0]["Car_TyreRadi"].ToString();
                        modelbj.RYPH = "";
                        modelbj.ZXBZ = dt.Rows[0]["PFStd"].ToString();
                        modelbj.CSYS = "";
                        return true;
                    }
                    else
                    {
                        model.CLID = "-2";
                        return false;
                    }
                }
                catch (Exception er)
                {
                    ini.INIIO.saveLogInf("读取RegTeam发生异常:" + er.Message);
                    return false;
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("链接到RegTeam失败:" + er.Message);
                return false;
            }
        }
    }

    public static class DictionaryExtensionMethodClass
    {
        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false)
                dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrPeplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

        /// <summary>
        /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary>
        /// 向字典中批量添加键值对
        /// </summary>
        /// <param name="replaceExisted">如果已存在，是否替换</param>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }


    }
}
