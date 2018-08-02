using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SYS_DAL;
using SYS.Model;
using SYS_MODEL;
using System.Data.SqlClient;
using System.Data;
using SYS;

namespace SYS_DAL
{
    public partial class stationControl
    {
        #region 获取该站的stationID
        public string getStationID()
        {
            string sql = "select * from thisStation";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["STATIONID"].ToString();
                }
                else
                    return "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 获取该站的信息
        public stationInfModel   getStationInf(string stationid)
        {
            stationInfModel model = new stationInfModel();
            string sql = "select * from stationNormalInf";
            DateTime datetimemodel;
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.STATIONID = dt.Rows[0]["STATIONID"].ToString();
                    model.STATIONADD = dt.Rows[0]["STATIONADD"].ToString();
                    model.STATIONNAME = dt.Rows[0]["STATIONNAME"].ToString();
                    model.STATIONPERSON = dt.Rows[0]["STATIONPERSON"].ToString();
                    model.STATIONPHONE = dt.Rows[0]["STATIONPHONE"].ToString();
                    model.STATIONDATE = dt.Rows[0]["STATIONDATE"].ToString();
                    model.STATIONJCFF = dt.Rows[0]["STATIONJCFF"].ToString();
                    model.STANDARD = dt.Rows[0]["STANDARD"].ToString();
                    model.STATIONNET = dt.Rows[0]["STATIONNET"].ToString();
                    model.StationCompany = dt.Rows[0]["STATIONCOMPANY"].ToString();

                    model.JCZXKZH = dt.Rows[0]["JCZXKZH"].ToString();
                    model.SBHZBH = dt.Rows[0]["SBHZBH"].ToString();
                    if (DateTime.TryParse(dt.Rows[0]["YXQSTARTTIME"].ToString(), out datetimemodel))
                        model.YXQSTARTTIME = datetimemodel;
                    else
                        model.YXQSTARTTIME = DateTime.Now;
                    if (DateTime.TryParse(dt.Rows[0]["YXQENDTIME"].ToString(), out datetimemodel))
                        model.YXQENDTIME = datetimemodel;
                    else
                        model.YXQENDTIME = DateTime.Now;
                    model.ISLOCK = (dt.Rows[0]["ISLOCK"].ToString() == "Y");
                    model.LOCKREASON = dt.Rows[0]["LOCKREASON"].ToString();
                    if (dt.Columns.Contains("CLEARMODE"))
                    {
                        model.CLEARMODE = dt.Rows[0]["CLEARMODE"].ToString() ;
                    }
                    else
                        model.CLEARMODE = "Y";
                    if (dt.Columns.Contains("JJLX"))
                    {
                        model.JJLX = dt.Rows[0]["JJLX"].ToString();
                        model.LXR = dt.Rows[0]["LXR"].ToString();
                        model.FZR = dt.Rows[0]["FZR"].ToString();
                        if (DateTime.TryParse(dt.Rows[0]["ZCSJ"].ToString(), out datetimemodel))
                            model.ZCSJ = datetimemodel;
                        else
                            model.ZCSJ = DateTime.Now;
                    }
                    else
                    {
                        model.JJLX = "";
                        model.LXR = "";
                        model.FZR = "";
                        model.ZCSJ = DateTime.Now;
                    }
                    if(dt.Columns.Contains("JCXS"))
                    {
                        model.JCXS = dt.Rows[0]["JCXS"].ToString();
                    }
                    else
                        model.JCXS = "";
                    if (dt.Columns.Contains("STATIONCOUNTDATE"))
                    {
                        if (DateTime.TryParse(dt.Rows[0]["STATIONCOUNTDATE"].ToString(), out datetimemodel))
                            model.STATIONCOUNTDATE = datetimemodel;
                        else
                            model.STATIONCOUNTDATE = DateTime.Now.AddDays(-1);
                        if (DateTime.TryParse(dt.Rows[0]["LOGINCOUNTDATE"].ToString(), out datetimemodel))
                            model.LOGINCOUNTDATE = datetimemodel;
                        else
                            model.LOGINCOUNTDATE = DateTime.Now.AddDays(-1);
                    }
                    else
                    {
                        model.STATIONCOUNTDATE = DateTime.Now.AddDays(-1);
                        model.LOGINCOUNTDATE = DateTime.Now.AddDays(-1);
                    }
                    if (dt.Columns.Contains("LSHRULE"))
                    {
                        model.LSHRULE = dt.Rows[0]["LSHRULE"].ToString();
                        if(model.LSHRULE=="")
                            model.LSHRULE = "通用";

                    }
                    else
                        model.LSHRULE = "通用";
                }
                else
                    model.STATIONID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取其他的信息
        public othersModel getOtherInf()
        {
            othersModel model = new othersModel();
            string sql = "select * from [其他信息]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.JDDH = dt.Rows[0]["JDDH"].ToString();
                    model.FWDH = dt.Rows[0]["FWDH"].ToString();
                }
                else
                    model.JDDH = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取该检测站的检测线数
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public int getStationLineCount(string stationid)
        {
            string sql = "select count(*) as number from stationLine" + " where STATIONID=" + "'" + stationid + "'";
            int count = 0;
            try
            {
                count = DBHelperSQL.ExecuteCount(sql);
                return count;
            }
            catch
            {
                return 0;
                throw;
            }
        }
        #endregion
        #region 更改检测站检测流水号的日期
        public int setStationLshDate(string station, string datestring)
        {
            string sql = "update stationNormalInf set STATIONCOUNTDATE=" + "'" + datestring + "'" + " where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改检测站登记流水号的日期
        public int setLoginLshDate(string station, string datestring)
        {
            string sql = "update stationNormalInf set LOGINCOUNTDATE=" + "'" + datestring + "'" + " where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 获取检测站线的配置
        public DataTable getStationLineInf(string station)
        {
            DataTable model = null;
            string sql = "select * from stationLine where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 更改某一条线的锁止状态
        public int updateLineLockState(string station, string line, string lockstrng, string lockreason)
        {
            string sql = "update stationLine set  ISLOCK='" + lockstrng + "',LOCKREASON='" + lockreason + "' where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 获取某一条线的信息
        public lineModel getLineInf(string station, string line)
        {
            lineModel model = new lineModel();
            string sql = "select * from stationLine where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.StationID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.ASM = dt.Rows[0]["ASM"].ToString();
                    model.VMAS = dt.Rows[0]["VMAS"].ToString();
                    model.SDS = dt.Rows[0]["SDS"].ToString();
                    model.JZJS_LIGHT = dt.Rows[0]["JZJS_LIGHT"].ToString();
                    model.JZJS_HEAVY = dt.Rows[0]["JZJS_HEAVY"].ToString();
                    model.ZYJS = dt.Rows[0]["ZYJS"].ToString();
                    model.LZ = dt.Rows[0]["LZ"].ToString();
                    model.PRINTER = dt.Rows[0]["PRINTER"].ToString();
                    model.AUTOPRINT = dt.Rows[0]["AUTOPRINT"].ToString();
                    model.JCXXKZBH= dt.Rows[0]["JCXXKZBH"].ToString();
                    model.YXQSTARTTIME = DateTime.Parse(dt.Rows[0]["YXQSTARTTIME"].ToString()); ;
                    model.YXQENDTIME = DateTime.Parse(dt.Rows[0]["YXQENDTIME"].ToString());
                    model.ISLOCK =( dt.Rows[0]["ISLOCK"].ToString()=="Y");
                    model.LOCKREASON = dt.Rows[0]["LOCKREASON"].ToString();

                }
                else
                    model.StationID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取某一条线的设备信息
        public equipmentModel getLineEquipInf(string station, string line)
        {
            equipmentModel model = new equipmentModel();
            string sql = "select * from [检测线设备] where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.StationID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.SBMC = dt.Rows[0]["SBMC"].ToString();
                    model.SBXH = dt.Rows[0]["SBXH"].ToString();
                    model.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    model.CGJXH = dt.Rows[0]["CGJXH"].ToString();
                    model.CGJBH = dt.Rows[0]["CGJBH"].ToString();//21
                    model.CGJZZC = dt.Rows[0]["CGJZZC"].ToString();
                    model.FXYXH = dt.Rows[0]["FXYXH"].ToString();
                    model.FXYBH = dt.Rows[0]["FXYBH"].ToString();
                    model.FXYZZC = dt.Rows[0]["FXYZZC"].ToString();
                    model.LLJXH = dt.Rows[0]["LLJXH"].ToString();
                    model.LLJBH = dt.Rows[0]["LLJBH"].ToString();
                    model.LLJZZC = dt.Rows[0]["LLJZZC"].ToString();
                    model.YDJXH = dt.Rows[0]["YDJXH"].ToString();
                    model.YDJBH = dt.Rows[0]["YDJBH"].ToString();
                    model.YDJZZC = dt.Rows[0]["YDJZZC"].ToString();
                    model.LZYDJXH = dt.Rows[0]["LZYDJXH"].ToString();
                    model.LZYDJBH = dt.Rows[0]["LZYDJBH"].ToString();
                    model.LZYDJZZC = dt.Rows[0]["LZYDJZZC"].ToString();
                    model.ZSJXH = dt.Rows[0]["ZSJXH"].ToString();
                    model.ZSJBH = dt.Rows[0]["ZSJBH"].ToString();
                    model.ZSJZZC = dt.Rows[0]["ZSJZZC"].ToString();

                }
                else
                    model.StationID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取某一条线的标定信息
        public LINESBBD getLineDemarcateInf(string station, string line)
        {
            LINESBBD model = new LINESBBD();
            string sql = "select * from [设备标定] where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.STATIONID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.Hxdate = DateTime.Parse(dt.Rows[0]["HXDATE"].ToString());
                    model.Hxenable = (dt.Rows[0]["HXENABLE"].ToString()=="Y");
                    model.Jsgldate = DateTime.Parse(dt.Rows[0]["JSGLDATE"].ToString());
                    model.Jsglenable = (dt.Rows[0]["JSGLENABLE"].ToString() == "Y");
                    model.Gldate = DateTime.Parse(dt.Rows[0]["GLDATE"].ToString());
                    model.Glenable = (dt.Rows[0]["GLENABLE"].ToString() == "Y");
                    model.Yrdate =DateTime.Parse(dt.Rows[0]["YRDATE"].ToString());
                    model.Yrenable =( dt.Rows[0]["YRENABLE"].ToString() == "Y");
                    model.Zjdate = DateTime.Parse(dt.Rows[0]["ZJDATE"].ToString());
                    model.Zjenable = (dt.Rows[0]["ZJENABLE"].ToString() == "Y");
                    model.Fxylowdate = DateTime.Parse(dt.Rows[0]["FXYLOWDATE"].ToString());
                    model.Fxylowenable = (dt.Rows[0]["FXYLOWENABLE"].ToString() == "Y");
                    model.Fxyhighdate = DateTime.Parse(dt.Rows[0]["FXYHIGHDATE"].ToString());
                    model.Fxyhighenable = (dt.Rows[0]["FXYHIGHENABLE"].ToString() == "Y");
                    model.Fxymiddate = DateTime.Parse(dt.Rows[0]["FXYMIDDATE"].ToString());
                    model.Fxymidenable = (dt.Rows[0]["FXYMIDENABLE"].ToString() == "Y");
                    model.Fxylowmiddate = DateTime.Parse(dt.Rows[0]["FXYLOWMIDDATE"].ToString());
                    model.Fxylowmidenable = (dt.Rows[0]["FXYLOWMIDENABLE"].ToString() == "Y");
                    model.Fxyhighmiddate = DateTime.Parse(dt.Rows[0]["FXYHIGHMIDDATE"].ToString());
                    model.Fxyhighmidenable = (dt.Rows[0]["FXYHIGHMIDENABLE"].ToString() == "Y");
                    model.Ydjdate = DateTime.Parse(dt.Rows[0]["YDJDATE"].ToString());
                    model.Ydjenable = (dt.Rows[0]["YDJENABLE"].ToString() == "Y");
                    model.Lljdate = DateTime.Parse(dt.Rows[0]["LLJDATE"].ToString());
                    model.Lljenable = (dt.Rows[0]["LLJENABLE"].ToString() == "Y");
                    model.Yljdate = DateTime.Parse(dt.Rows[0]["YLJDATE"].ToString());
                    model.Yljenable = (dt.Rows[0]["YLJENABLE"].ToString() == "Y");
                    model.Sddate = DateTime.Parse(dt.Rows[0]["SDDATE"].ToString());
                    model.Sdenable = (dt.Rows[0]["SDENABLE"].ToString() == "Y");
                    model.Hjcsdate = DateTime.Parse(dt.Rows[0]["HJCSDATE"].ToString());
                    model.Hjcsenable = (dt.Rows[0]["HJCSENABLE"].ToString() == "Y");
                    model.Zsjdate = DateTime.Parse(dt.Rows[0]["ZSJDATE"].ToString());
                    model.Zsjenable = (dt.Rows[0]["ZSJENABLE"].ToString() == "Y");
                    model.Jldate = DateTime.Parse(dt.Rows[0]["JLDATE"].ToString());
                    model.Jlenable = (dt.Rows[0]["JLENABLE"].ToString() == "Y");
                }
                else
                {
                    model.STATIONID = station;
                    model.LINEID = line;
                    model.Hxdate = DateTime.Now;
                    model.Hxenable = true;
                    model.Jsgldate = DateTime.Now;
                    model.Jsglenable = true;
                    model.Gldate = DateTime.Now;
                    model.Glenable = true;
                    model.Yrdate = DateTime.Now;
                    model.Yrenable = true;
                    model.Zjdate = DateTime.Now;
                    model.Zjenable = true;
                    model.Fxylowdate = DateTime.Now;
                    model.Fxylowenable = true;
                    model.Fxyhighdate = DateTime.Now;
                    model.Fxyhighenable = true;
                    model.Fxymiddate = DateTime.Now;
                    model.Fxymidenable = true;
                    model.Fxylowmiddate = DateTime.Now;
                    model.Fxylowmidenable = false;
                    model.Fxyhighmiddate = DateTime.Now;
                    model.Fxyhighmidenable = false;
                    model.Ydjdate = DateTime.Now;
                    model.Ydjenable = true;
                    model.Lljdate = DateTime.Now;
                    model.Lljenable = true;
                    model.Yljdate = DateTime.Now;
                    model.Yljenable = true;
                    model.Sddate = DateTime.Now;
                    model.Sdenable = true;
                    model.Hjcsdate = DateTime.Now;
                    model.Hjcsenable = true;
                    model.Zsjdate = DateTime.Now;
                    model.Zsjenable = true;
                    model.Jldate = DateTime.Now;
                    model.Jlenable = true;
                }
            }
            catch (Exception)
            {
                model.STATIONID = station;
                model.LINEID = line;
                model.Hxdate = DateTime.Now;
                model.Hxenable = true;
                model.Jsgldate = DateTime.Now;
                model.Jsglenable = true;
                model.Gldate = DateTime.Now;
                model.Glenable = true;
                model.Yrdate = DateTime.Now;
                model.Yrenable = true;
                model.Zjdate = DateTime.Now;
                model.Zjenable = true;
                model.Fxylowdate = DateTime.Now;
                model.Fxylowenable = true;
                model.Fxyhighdate = DateTime.Now;
                model.Fxyhighenable = true;
                model.Fxymiddate = DateTime.Now;
                model.Fxymidenable = true;
                model.Fxylowmiddate = DateTime.Now;
                model.Fxylowmidenable = false;
                model.Fxyhighmiddate = DateTime.Now;
                model.Fxyhighmidenable = false;
                model.Ydjdate = DateTime.Now;
                model.Ydjenable = true;
                model.Lljdate = DateTime.Now;
                model.Lljenable = true;
                model.Yljdate = DateTime.Now;
                model.Yljenable = true;
                model.Sddate = DateTime.Now;
                model.Sdenable = true;
                model.Hjcsdate = DateTime.Now;
                model.Hjcsenable = true;
                model.Zsjdate = DateTime.Now;
                model.Zsjenable = true;
                model.Jldate = DateTime.Now;
                model.Jlenable = true;
            }
            return model;
        }
        #endregion
        #region 更改某一条线的某一项标定项的时间
        public int setDemarcateTimebyName(string station, string line,string item, string time)
        {
            string sql = "update [设备标定] set "+item+"="+ "'" + time + "'" + " where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改某一条线的的预热时间
        public int setlineYureTime(string station, string line, DateTime time)
        {
            string sql = "update [设备标定] set YRDATE=" + "'" + time.ToShortDateString() + "'" + " where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改标定时限
        public bool updateBdsx(BDSX model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [设备标定时限] set ");
            strSql.Append("HXSX=@HXSX,");
            strSql.Append("JSGLSX=@JSGLSX,");
            strSql.Append("GLSX=@GLSX,");
            strSql.Append("LLJSX=@LLJSX,");
            strSql.Append("YDJSX=@YDJSX,");
            strSql.Append("FXYLOWSX=@FXYLOWSX,");
            strSql.Append("FXYHIGHSX=@FXYHIGHSX,");
            strSql.Append("FXYMIDSX=@FXYMIDSX,");
            strSql.Append("FXYLOWMIDSX=@FXYLOWMIDSX,");
            strSql.Append("FXYHIGHMIDSX=@FXYHIGHMIDSX,");
            strSql.Append("ZJSX=@ZJSX,");
            strSql.Append("YRSX=@YRSX,");
            strSql.Append("YLJSX=@YLJSX,");
            strSql.Append("SDSX=@SDSX,");
            strSql.Append("HJCSSX=@HJCSSX,");
            strSql.Append("ZSJSX=@ZSJSX,");
            strSql.Append("JLSX=@JLSX");
            SqlParameter[] parameters =
            {
                //new SqlParameter("@STAFFID", SqlDbType.VarChar,50),
                 new SqlParameter("@HXSX", SqlDbType.VarChar,50),
                new SqlParameter("@JSGLSX", SqlDbType.VarChar,50),
                new SqlParameter("@GLSX", SqlDbType.VarChar,50),
                 new SqlParameter("@LLJSX", SqlDbType.VarChar,50),
                new SqlParameter("@YDJSX", SqlDbType.VarChar,50),
                new SqlParameter("@FXYLOWSX", SqlDbType.VarChar,50),
                new SqlParameter("@FXYHIGHSX", SqlDbType.VarChar,50),
                 new SqlParameter("@FXYMIDSX", SqlDbType.VarChar,50),
                new SqlParameter("@FXYLOWMIDSX", SqlDbType.VarChar,50),
                new SqlParameter("@FXYHIGHMIDSX", SqlDbType.VarChar,50),
                new SqlParameter("@ZJSX", SqlDbType.VarChar,50),
                 new SqlParameter("@YRSX", SqlDbType.VarChar,50),
                new SqlParameter("@YLJSX", SqlDbType.VarChar,50),
                 new SqlParameter("@SDSX", SqlDbType.VarChar,50),
                new SqlParameter("@HJCSSX", SqlDbType.VarChar,50),
                new SqlParameter("@ZSJSX", SqlDbType.VarChar,50),
                new SqlParameter("@JLSX", SqlDbType.VarChar,50)
                };
            //parameters[i++].Value = model.STAFFID;
            parameters[i++].Value = model.HXSX;
            parameters[i++].Value = model.JSGLSX;
            parameters[i++].Value = model.GLSX;
            parameters[i++].Value = model.LLJSX;
            parameters[i++].Value = model.YDJSX;
            parameters[i++].Value = model.FXYLOWSX;
            parameters[i++].Value = model.FXYHIGHSX;
            parameters[i++].Value = model.FXYMIDSX;
            parameters[i++].Value = model.FXYLOWMIDSX;
            parameters[i++].Value = model.FXYHIGHMIDSX;
            parameters[i++].Value = model.ZJSX;
            parameters[i++].Value = model.YRSX;
            parameters[i++].Value = model.YLJSX;
            parameters[i++].Value = model.SDSX;
            parameters[i++].Value = model.HJCSSX;
            parameters[i++].Value = model.ZSJSX;
            parameters[i++].Value = model.JLSX;
            try
            {
                if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 获取标定时间限值信息
        public BDSX getDemarcateInf()
        {
            BDSX model = new BDSX();
            string sql = "select * from [设备标定时限]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.HXSX = ((dt.Rows[0]["HXSX"].ToString()=="")?"30":dt.Rows[0]["HXSX"].ToString());
                    model.JSGLSX = ((dt.Rows[0]["JSGLSX"].ToString() == "") ? "30" : dt.Rows[0]["JSGLSX"].ToString());
                    model.GLSX = ((dt.Rows[0]["GLSX"].ToString() == "") ? "30" : dt.Rows[0]["GLSX"].ToString());
                    model.LLJSX = ((dt.Rows[0]["LLJSX"].ToString() == "") ? "30" : dt.Rows[0]["LLJSX"].ToString());
                    model.YDJSX = ((dt.Rows[0]["YDJSX"].ToString() == "") ? "30" : dt.Rows[0]["YDJSX"].ToString());
                    model.FXYLOWSX = ((dt.Rows[0]["FXYLOWSX"].ToString() == "") ? "30" : dt.Rows[0]["FXYLOWSX"].ToString());
                    model.FXYHIGHSX = ((dt.Rows[0]["FXYHIGHSX"].ToString() == "") ? "30" : dt.Rows[0]["FXYHIGHSX"].ToString());
                    model.FXYMIDSX = ((dt.Rows[0]["FXYMIDSX"].ToString() == "") ? "30" : dt.Rows[0]["FXYMIDSX"].ToString());
                    model.FXYLOWMIDSX = ((dt.Rows[0]["FXYLOWMIDSX"].ToString() == "") ? "30" : dt.Rows[0]["FXYLOWMIDSX"].ToString());
                    model.FXYHIGHMIDSX = ((dt.Rows[0]["FXYHIGHMIDSX"].ToString() == "") ? "30" : dt.Rows[0]["FXYHIGHMIDSX"].ToString());
                    model.ZJSX = ((dt.Rows[0]["ZJSX"].ToString() == "") ? "30" : dt.Rows[0]["ZJSX"].ToString());
                    model.YRSX = ((dt.Rows[0]["YRSX"].ToString() == "") ? "30" : dt.Rows[0]["YRSX"].ToString());
                    model.YLJSX = ((dt.Rows[0]["YLJSX"].ToString() == "") ? "30" : dt.Rows[0]["YLJSX"].ToString());
                    model.SDSX = ((dt.Rows[0]["SDSX"].ToString() == "") ? "30" : dt.Rows[0]["SDSX"].ToString());
                    model.HJCSSX = ((dt.Rows[0]["HJCSSX"].ToString() == "") ? "30" : dt.Rows[0]["HJCSSX"].ToString());
                    model.ZSJSX = ((dt.Rows[0]["ZSJSX"].ToString() == "") ? "30" : dt.Rows[0]["ZSJSX"].ToString());
                    model.JLSX = ((dt.Rows[0]["JLSX"].ToString() == "") ? "30" : dt.Rows[0]["JLSX"].ToString());

                }
                else
                    model.HXSX = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取标定时间限值信息
        public BDSX getDemarcateInfString()
        {
            BDSX model = new BDSX();
            string sql = "select * from [设备标定时限]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.HXSX = dt.Rows[0]["HXSX"].ToString();
                    model.JSGLSX = dt.Rows[0]["JSGLSX"].ToString();
                    model.GLSX = dt.Rows[0]["GLSX"].ToString();
                    model.LLJSX = dt.Rows[0]["LLJSX"].ToString();
                    model.YDJSX = dt.Rows[0]["YDJSX"].ToString();
                    model.FXYLOWSX = dt.Rows[0]["FXYLOWSX"].ToString();
                    model.FXYHIGHSX = dt.Rows[0]["FXYHIGHSX"].ToString();
                    model.FXYMIDSX = dt.Rows[0]["FXYMIDSX"].ToString();
                    model.FXYLOWMIDSX = dt.Rows[0]["FXYLOWMIDSX"].ToString();
                    model.FXYHIGHMIDSX = dt.Rows[0]["FXYHIGHMIDSX"].ToString();
                    model.ZJSX = dt.Rows[0]["ZJSX"].ToString();
                    model.YRSX = dt.Rows[0]["YRSX"].ToString();
                    model.YLJSX = dt.Rows[0]["YLJSX"].ToString();
                    model.SDSX = dt.Rows[0]["SDSX"].ToString();
                    model.HJCSSX = dt.Rows[0]["HJCSSX"].ToString();
                    model.ZSJSX = dt.Rows[0]["ZSJSX"].ToString();
                    model.JLSX = dt.Rows[0]["JLSX"].ToString();

                }
                else
                    model.HXSX = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 更改某一条线的打印机
        public int setLinePrinter(string station, string line, string printer)
        {
            string sql = "update stationLine set PRINTER=" + "'" + printer + "'" + " where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改某一条线的自动打印机
        public int setLineAutoPrint(string station, string line, string autoprint)
        {
            string sql = "update stationLine set autoprint=" + "'" + autoprint + "'" + " where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 获取某一条线的流水号信息
        public lshModel getLineLshInf(string station, string line)
        {
            lshModel model = new lshModel();
            string sql = "select * from [流水号信息] where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.StationID = dt.Rows[0]["StationID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.DATE = DateTime.Parse(dt.Rows[0]["DATE"].ToString());
                    model.COUNT = dt.Rows[0]["COUNT"].ToString();
                }
                else
                    model.StationID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取整个站的流水号信息
        public int getStationLshInf(string station)
        {
            string sql = "select * from stationNormalInf where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["YWLSH"].ToString() == "")
                        return 0;
                    else
                        return int.Parse(dt.Rows[0]["YWLSH"].ToString());
                }
                else
                    return 0;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception er)
            {
                throw(new Exception(er.Message));
            }
        }
        public int getStationLoginLshInf(string station)
        {
            string sql = "select * from stationNormalInf where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["DJLSH"].ToString() == "")
                        return 0;
                    else
                        return int.Parse(dt.Rows[0]["DJLSH"].ToString());
                }
                else
                    return 0;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception er)
            {
                throw (new Exception(er.Message));
            }
        }
        #endregion
        #region 更改总站的流水号信息
        public int setStationLshCount(string station, string count)
        {
            string sql = "update stationNormalInf set YWLSH=" + "'" + count + "'" + " where STATIONID='" + station +  "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int setStationLoginLshCount(string station, string count)
        {
            string sql = "update stationNormalInf set DJLSH=" + "'" + count + "'" + " where STATIONID='" + station + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改某一条线的检测数
        public int setLineLshCount(string station, string line,string count)
        {
            string sql = "update [流水号信息] set count="+"'"+count+"'"+" where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 更改某一条线的日期
        public int setLineLshDate(string station, string line, string datestring)
        {
            string sql = "update [流水号信息] set DATE=" + "'" + datestring + "'" + " where STATIONID='" + station + "' and LINEID='" + line + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 获取某一条线的信息
        public string getLineByJCFF(string station, string jcff)
        {
            string linestring = "";
            string sql = "select * from stationLine where STATIONID='" + station + "' and "+jcff+"='Y'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        linestring += dt.Rows[i]["LINEID"].ToString() + ",";
                    }
                    return linestring;
                }
                else
                    return "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 获取某一种方法的费用
        public string getFYbyjcff(string jcff)
        {
            string sql = "select * from [费用] where MC='" + jcff + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["FY"].ToString();
                }
                else
                    return "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据工位ID获取该工位名称
        public string getGongweiNamef(int gongweiid)
        {
            string sql = "select * from gongweiInf where GONGWEIID='" + gongweiid.ToString() +"'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["GONGWEINAME"].ToString();
                }
                else
                    return "";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据台体获取串口配置信息
        public comModel getComInf(string machinename)
        {
            string sql = "select * from [串口配置] where MC='" + machinename + "'";
            try
            {
                comModel model = new comModel();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.Comname = dt.Rows[0]["COM"].ToString();
                    model.Comstring = dt.Rows[0]["COMCONFIG"].ToString();
                    model.IsEnable = (dt.Rows[0]["ENABLE"].ToString() == "1") ? true : false;
                }
                else
                    model.Comname = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public DataTable requerydata(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
    }
}


