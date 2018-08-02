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
    public partial class loginInfControl
    {
        #region 设置数据库检测站编号
        public bool setThisStationID(string id)
        {
            string sql = "update thisStation set STATIONID='" + id+ "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;      
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测站信息检测站编号
        public bool setStationNormalInfStationID(string id)
        {
            string sql = "update stationNormalInf set STATIONID='" + id + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测线信息检测站编号
        public bool setStationLineStationID(string id)
        {
            string sql = "update stationLine set STATIONID='" + id + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测线设备检测站编号
        public bool setStationEquipmentStationID(string id)
        {
            string sql = "update [检测线设备] set STATIONID='" + id + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测线设备检测站编号
        public bool setStationLSHStationID(string id)
        {
            string sql = "update [流水号信息] set STATIONID='" + id + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测线设备检测站编号
        public bool setDermacateStationID(string id)
        {
            string sql = "update [设备标定] set STATIONID='" + id + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 设置数据库检测站信息
        public bool setThisStationInf(string name,string add,string tel,string jcff,string CMA,string COMPANYNAME,string SBHZBH,DateTime starttime,DateTime endtime,string jczxkzh,bool islock,string standard,string clearmode,string jjlx,string lxr,string fzr,DateTime zcsj,string jcxs,string lshrule)
        {
            string sql = "update stationNormalInf set STATIONNAME='" + name + "',STATIONADD='"+add+"',STATIONPHONE='"+tel+"',STATIONJCFF='"+jcff+"',STATIONDATE='"+CMA+"'" + ",STATIONCOMPANY='" + COMPANYNAME + "'"
                + ",SBHZBH='" + SBHZBH + "'" + ",JCZXKZH='" + jczxkzh + "'" + ",YXQSTARTTIME='" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",YXQENDTIME='" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",ISLOCK='" + (islock?"Y":"N") + "'" + ",STANDARD='" + standard + "'" + ",CLEARMODE='" + clearmode + "'"
                + ",JJLX='" + jjlx + "'" + ",LXR='" + lxr + "'" + ",FZR='" + fzr + "'" + ",ZCSJ='" + zcsj.ToString("yyyy-MM-dd HH:mm:ss") + "'" + ",JCXS='" + jcxs + "'" + ",LSHRULE='" + lshrule + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 检查是否存在该编号的线
        public bool checkLineIsAlive(string stationid, string lineid)
        {
            string sql = "select * from stationLine where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        public bool deleteLineInf(string project,string stationid,string lineid)
        {
            string sql = "delete  from ["+project+"] where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        #region 保存检测线配置信息
        public bool saveLineInf(lineModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stationLine (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("ASM,");//=@PZLX,");1
            strSql.Append("VMAS,");//=@PZLX,");1
            strSql.Append("SDS,");//=@PZLX,");1
            strSql.Append("JZJS_LIGHT,");//=@PZLX,");1
            strSql.Append("JZJS_HEAVY,");//=@PZLX,");1
            strSql.Append("ZYJS,");//=@PZLX,");1
            strSql.Append("LZ,");//=@PZLX,");1
            strSql.Append("PRINTER,");//=@PZLX,");1
            strSql.Append("AUTOPRINT,");//=@PZLX,");1
            strSql.Append("JCXXKZBH,");//=@PZLX,");1
            strSql.Append("YXQSTARTTIME,");//=@PZLX,");1
            strSql.Append("YXQENDTIME,");//=@PZLX,");1
            strSql.Append("ISLOCK,");//=@PZLX,");1
            strSql.Append("LOCKREASON)");//=@PZLX,");1
            strSql.Append("values (@STATIONID,@LINEID,@ASM,@VMAS,@SDS,@JZJS_LIGHT,@JZJS_HEAVY,@ZYJS,@LZ,@PRINTER,@AUTOPRINT,@JCXXKZBH,@YXQSTARTTIME,@YXQENDTIME,@ISLOCK,@LOCKREASON)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM", SqlDbType.VarChar,1),
                                            new SqlParameter("@VMAS", SqlDbType.VarChar,1),
                                            new SqlParameter("@SDS", SqlDbType.VarChar,1),
                                            new SqlParameter("@JZJS_LIGHT", SqlDbType.VarChar,1),
                                            new SqlParameter("@JZJS_HEAVY", SqlDbType.VarChar,1),
                                            new SqlParameter("@ZYJS", SqlDbType.VarChar,1),
                                            new SqlParameter("@LZ", SqlDbType.VarChar,1),
                                            new SqlParameter("@PRINTER", SqlDbType.VarChar,50),
					                        new SqlParameter("@AUTOPRINT", SqlDbType.VarChar,1),
                                            new SqlParameter("@JCXXKZBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YXQSTARTTIME", SqlDbType.DateTime),
                                            new SqlParameter("@YXQENDTIME", SqlDbType.DateTime),
                                            new SqlParameter("@ISLOCK", SqlDbType.VarChar,50),
                                            new SqlParameter("@LOCKREASON", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.StationID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.ASM;
            parameters[i++].Value = model.VMAS;
            parameters[i++].Value = model.SDS;
            parameters[i++].Value = model.JZJS_LIGHT;
            parameters[i++].Value = model.JZJS_HEAVY;
            parameters[i++].Value = model.ZYJS;
            parameters[i++].Value = model.LZ;
            parameters[i++].Value = model.PRINTER;
            parameters[i++].Value = model.AUTOPRINT;
            parameters[i++].Value = model.JCXXKZBH;
            parameters[i++].Value = model.YXQSTARTTIME;
            parameters[i++].Value = model.YXQENDTIME;
            parameters[i++].Value = (model.ISLOCK?"Y":"N");
            parameters[i++].Value = model.LOCKREASON;
            try
            {
                if (checkLineIsAlive(model.StationID, model.LINEID))
                {
                    if (updateLineInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 保存检测线配置信息
        public bool updateLineInf(lineModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stationLine set ");
            strSql.Append("ASM=@ASM,");//=@PZLX,");1
            strSql.Append("VMAS=@VMAS,");//=@PZLX,");1
            strSql.Append("SDS=@SDS,");//=@PZLX,");1
            strSql.Append("JZJS_LIGHT=@JZJS_LIGHT,");//=@PZLX,");1
            strSql.Append("JZJS_HEAVY=@JZJS_HEAVY,");//=@PZLX,");1
            strSql.Append("ZYJS=@ZYJS,");//=@PZLX,");1
            strSql.Append("LZ=@LZ,");//=@PZLX,");1
            strSql.Append("PRINTER=@PRINTER,");//=@PZLX,");1
            strSql.Append("JCXXKZBH=@JCXXKZBH,");//=@PZLX,");1
            strSql.Append("YXQSTARTTIME=@YXQSTARTTIME,");//=@PZLX,");1
            strSql.Append("YXQENDTIME=@YXQENDTIME,");//=@PZLX,");1
            strSql.Append("ISLOCK=@ISLOCK,");//=@PZLX,");1
            strSql.Append("LOCKREASON=@LOCKREASON,");//=@PZLX,");1
            strSql.Append("AUTOPRINT=@AUTOPRINT ");//=@PZLX,");1
            strSql.Append("where STATIONID='"+model.StationID+"' AND LINEID='"+model.LINEID+"'");
            SqlParameter[] parameters = {

                                            new SqlParameter("@ASM", SqlDbType.VarChar,1),
                                            new SqlParameter("@VMAS", SqlDbType.VarChar,1),
                                            new SqlParameter("@SDS", SqlDbType.VarChar,1),
                                            new SqlParameter("@JZJS_LIGHT", SqlDbType.VarChar,1),
                                            new SqlParameter("@JZJS_HEAVY", SqlDbType.VarChar,1),
                                            new SqlParameter("@ZYJS", SqlDbType.VarChar,1),
                                            new SqlParameter("@LZ", SqlDbType.VarChar,1),
                                            new SqlParameter("@PRINTER", SqlDbType.VarChar,50),
                                            new SqlParameter("@AUTOPRINT", SqlDbType.VarChar,1),
                                            new SqlParameter("@JCXXKZBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YXQSTARTTIME", SqlDbType.DateTime),
                                            new SqlParameter("@YXQENDTIME", SqlDbType.DateTime),
                                            new SqlParameter("@ISLOCK", SqlDbType.VarChar,50),
                                            new SqlParameter("@LOCKREASON", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.ASM;
            parameters[i++].Value = model.VMAS;
            parameters[i++].Value = model.SDS;
            parameters[i++].Value = model.JZJS_LIGHT;
            parameters[i++].Value = model.JZJS_HEAVY;
            parameters[i++].Value = model.ZYJS;
            parameters[i++].Value = model.LZ;
            parameters[i++].Value = model.PRINTER;
            parameters[i++].Value = model.AUTOPRINT;
            parameters[i++].Value = model.JCXXKZBH;
            parameters[i++].Value = model.YXQSTARTTIME;
            parameters[i++].Value = model.YXQENDTIME;
            parameters[i++].Value = (model.ISLOCK ? "Y" : "N");
            parameters[i++].Value = model.LOCKREASON;
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
        #region 检查是否存在该编号的线设备信息
        public bool checkLineEquipIsAlive(string stationid, string lineid)
        {
            string sql = "select * from [检测线设备] where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        #region 保存检测线设备信息
        public bool saveLineEquipInf(equipmentModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [检测线设备] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("SBMC,");//=@PZLX,");1
            strSql.Append("SBXH,");//=@PZLX,");1
            strSql.Append("SBZZC,");//=@PZLX,");1
            strSql.Append("CGJXH,");//=@PZLX,");1
            strSql.Append("CGJBH,");//=@PZLX,");1
            strSql.Append("CGJZZC,");//=@PZLX,");1
            strSql.Append("FXYXH,");//=@PZLX,");1
            strSql.Append("FXYBH,");//=@PZLX,");1
            strSql.Append("FXYZZC,");//=@PZLX,");1
            strSql.Append("LLJXH,");//=@PZLX,");1
            strSql.Append("LLJBH,");//=@PZLX,");1
            strSql.Append("LLJZZC,");//=@PZLX,");1
            strSql.Append("YDJXH,");//=@PZLX,");1
            strSql.Append("YDJBH,");//=@PZLX,");1
            strSql.Append("YDJZZC,");//=@PZLX,");1
            strSql.Append("LZYDJXH,");//=@PZLX,");1
            strSql.Append("LZYDJBH,");//=@PZLX,");1
            strSql.Append("LZYDJZZC,");//=@PZLX,");1
            strSql.Append("ZSJXH,");//=@PZLX,");1
            strSql.Append("ZSJBH,");//=@PZLX,");1
            strSql.Append("ZSJZZC)");//=@PZLX,");1
            strSql.Append("values (@STATIONID,@LINEID,@SBMC,@SBXH,@SBZZC,@CGJXH,@CGJBH,@CGJZZC,@FXYXH,@FXYBH,@FXYZZC,@LLJXH,@LLJBH,@LLJZZC,@YDJXH,@YDJBH,@YDJZZC,@LZYDJXH,@LZYDJBH,@LZYDJZZC,@ZSJXH,@ZSJBH,@ZSJZZC)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBMC", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJZZC", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.StationID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.SBMC;
            parameters[i++].Value = model.SBXH;
            parameters[i++].Value = model.SBZZC;
            parameters[i++].Value = model.CGJXH;
            parameters[i++].Value = model.CGJBH;
            parameters[i++].Value = model.CGJZZC;
            parameters[i++].Value = model.FXYXH;
            parameters[i++].Value = model.FXYBH;
            parameters[i++].Value = model.FXYZZC;
            parameters[i++].Value = model.LLJXH;
            parameters[i++].Value = model.LLJBH;
            parameters[i++].Value = model.LLJZZC;
            parameters[i++].Value = model.YDJXH;
            parameters[i++].Value = model.YDJBH;
            parameters[i++].Value = model.YDJZZC;
            parameters[i++].Value = model.LZYDJXH;
            parameters[i++].Value = model.LZYDJBH;
            parameters[i++].Value = model.LZYDJZZC;
            parameters[i++].Value = model.ZSJXH;
            parameters[i++].Value = model.ZSJBH;
            parameters[i++].Value = model.ZSJZZC;
            try
            {
                if (checkLineEquipIsAlive(model.StationID, model.LINEID))
                {
                    if (updateLineEquipInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region 保存检测线配置信息
        public bool updateLineEquipInf(equipmentModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [检测线设备] set ");
            strSql.Append("SBMC=@SBMC,");//=@PZLX,");1
            strSql.Append("SBXH=@SBXH,");//=@PZLX,");1
            strSql.Append("SBZZC=@SBZZC,");//=@PZLX,");1
            strSql.Append("CGJXH=@CGJXH,");//=@PZLX,");1
            strSql.Append("CGJBH=@CGJBH,");//=@PZLX,");1
            strSql.Append("CGJZZC=@CGJZZC,");//=@PZLX,");1
            strSql.Append("FXYXH=@FXYXH,");//=@PZLX,");1
            strSql.Append("FXYBH=@FXYBH,");//=@PZLX,");1
            strSql.Append("FXYZZC=@FXYZZC,");//=@PZLX,");1
            strSql.Append("LLJXH=@LLJXH,");//=@PZLX,");1
            strSql.Append("LLJBH=@LLJBH,");//=@PZLX,");1
            strSql.Append("LLJZZC=@LLJZZC,");//=@PZLX,");1
            strSql.Append("YDJXH=@YDJXH,");//=@PZLX,");1
            strSql.Append("YDJBH=@YDJBH,");//=@PZLX,");1
            strSql.Append("YDJZZC=@YDJZZC,");//=@PZLX,");1
            strSql.Append("LZYDJXH=@LZYDJXH,");//=@PZLX,");1
            strSql.Append("LZYDJBH=@LZYDJBH,");//=@PZLX,");1
            strSql.Append("LZYDJZZC=@LZYDJZZC,");//=@PZLX,");1
            strSql.Append("ZSJXH=@ZSJXH,");//=@PZLX,");1
            strSql.Append("ZSJBH=@ZSJBH,");//=@PZLX,");1
            strSql.Append("ZSJZZC=@ZSJZZC ");//=@PZLX,");1
            strSql.Append("where stationid=@STATIONID and lineid=@LINEID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBMC", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@SBZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@CGJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@LZYDJZZC", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJXH", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJBH", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJZZC", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.StationID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.SBMC;
            parameters[i++].Value = model.SBXH;
            parameters[i++].Value = model.SBZZC;
            parameters[i++].Value = model.CGJXH;
            parameters[i++].Value = model.CGJBH;
            parameters[i++].Value = model.CGJZZC;
            parameters[i++].Value = model.FXYXH;
            parameters[i++].Value = model.FXYBH;
            parameters[i++].Value = model.FXYZZC;
            parameters[i++].Value = model.LLJXH;
            parameters[i++].Value = model.LLJBH;
            parameters[i++].Value = model.LLJZZC;
            parameters[i++].Value = model.YDJXH;
            parameters[i++].Value = model.YDJBH;
            parameters[i++].Value = model.YDJZZC;
            parameters[i++].Value = model.LZYDJXH;
            parameters[i++].Value = model.LZYDJBH;
            parameters[i++].Value = model.LZYDJZZC;
            parameters[i++].Value = model.ZSJXH;
            parameters[i++].Value = model.ZSJBH;
            parameters[i++].Value = model.ZSJZZC;
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
        #region 检查是否存在该编号的线设备信息
        public bool checkLineCompenIsAlive(string lineid)
        {
            string sql = "select * from [补偿参数] where LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        #region 保存检测线设备信息
        public bool saveLineCompensationInf(compensationModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [补偿参数] (");
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("ASM_HC,");//=@PZLX,");1
            strSql.Append("ASM_CO,");//=@PZLX,");1
            strSql.Append("ASM_NO,");//=@PZLX,");1
            strSql.Append("VMAS_HC,");//=@PZLX,");1
            strSql.Append("VMAS_CO,");//=@PZLX,");1
            strSql.Append("VMAS_NO,");//=@PZLX,");1
            strSql.Append("SDS_HC,");//=@PZLX,");1
            strSql.Append("SDS_CO,");//=@PZLX,");1
            strSql.Append("ZYJS_K,");//=@PZLX,");1
            strSql.Append("JZJS_K,");//=@PZLX,");1
            strSql.Append("JZJS_GL,");//=@PZLX,");1
            strSql.Append("ISUSE)");//=@PZLX,");1
            strSql.Append("values (@LINEID,@ASM_HC,@ASM_CO,@ASM_NO,@VMAS_HC,@VMAS_CO,@VMAS_NO,@SDS_HC,@SDS_CO,@ZYJS_K,@JZJS_K,@JZJS_GL,@ISUSE)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_NO", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_NO", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDS_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDS_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZYJS_K", SqlDbType.VarChar,50),
                                            new SqlParameter("@JZJS_K", SqlDbType.VarChar,50),
                                            new SqlParameter("@JZJS_GL", SqlDbType.VarChar,50),
                                            new SqlParameter("@ISUSE", SqlDbType.VarChar,1)};
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.ASM_HC.ToString("0.000");
            parameters[i++].Value = model.ASM_CO.ToString("0.000");
            parameters[i++].Value = model.ASM_NO.ToString("0.000");
            parameters[i++].Value = model.VMAS_HC.ToString("0.000");
            parameters[i++].Value = model.VMAS_CO.ToString("0.000");
            parameters[i++].Value = model.VMAS_NO.ToString("0.000");
            parameters[i++].Value = model.SDS_HC.ToString("0.000");
            parameters[i++].Value = model.SDS_CO.ToString("0.000");
            parameters[i++].Value = model.ZYJS_K.ToString("0.000");
            parameters[i++].Value = model.JZJS_K.ToString("0.000");
            parameters[i++].Value = model.JZJS_GL.ToString("0.000");
            parameters[i++].Value = model.ISUSE?"Y":"N";
            try
            {
                if (checkLineCompenIsAlive(model.LINEID))
                {
                    if (updateLineCompenInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 保存检测线配置信息
        public bool updateLineCompenInf(compensationModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [补偿参数] set ");
            strSql.Append("ASM_HC=@ASM_HC,");//=@PZLX,");1
            strSql.Append("ASM_CO=@ASM_CO,");//=@PZLX,");1
            strSql.Append("ASM_NO=@ASM_NO,");//=@PZLX,");1
            strSql.Append("VMAS_HC=@VMAS_HC,");//=@PZLX,");1
            strSql.Append("VMAS_CO=@VMAS_CO,");//=@PZLX,");1
            strSql.Append("VMAS_NO=@VMAS_NO,");//=@PZLX,");1
            strSql.Append("SDS_HC=@SDS_HC,");//=@PZLX,");1
            strSql.Append("SDS_CO=@SDS_CO,");//=@PZLX,");1
            strSql.Append("ZYJS_K=@ZYJS_K,");//=@PZLX,");1
            strSql.Append("JZJS_K=@JZJS_K,");//=@PZLX,");1
            strSql.Append("JZJS_GL=@JZJS_GL,");//=@PZLX,");1
            strSql.Append("ISUSE=@ISUSE ");//=@PZLX,");1
            strSql.Append("where LINEID=@LINEID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@ASM_NO", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@VMAS_NO", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDS_HC", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDS_CO", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZYJS_K", SqlDbType.VarChar,50),
                                            new SqlParameter("@JZJS_K", SqlDbType.VarChar,50),
                                            new SqlParameter("@JZJS_GL", SqlDbType.VarChar,50),
                                            new SqlParameter("@ISUSE", SqlDbType.VarChar,1)};
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.ASM_HC.ToString("0.000");
            parameters[i++].Value = model.ASM_CO.ToString("0.000");
            parameters[i++].Value = model.ASM_NO.ToString("0.000");
            parameters[i++].Value = model.VMAS_HC.ToString("0.000");
            parameters[i++].Value = model.VMAS_CO.ToString("0.000");
            parameters[i++].Value = model.VMAS_NO.ToString("0.000");
            parameters[i++].Value = model.SDS_HC.ToString("0.000");
            parameters[i++].Value = model.SDS_CO.ToString("0.000");
            parameters[i++].Value = model.ZYJS_K.ToString("0.000");
            parameters[i++].Value = model.JZJS_K.ToString("0.000");
            parameters[i++].Value = model.JZJS_GL.ToString("0.000");
            parameters[i++].Value = model.ISUSE ? "Y" : "N";
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
        #region 根据车辆ID获取该车被检信息
        public compensationModel getLineCompensationData(string lineid)
        {
            DateTime a, b;
            compensationModel model = new compensationModel();
            string sql = "select * from [补偿参数] where LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.ASM_HC =Double.Parse( dt.Rows[0]["ASM_HC"].ToString());
                    model.ASM_CO = Double.Parse(dt.Rows[0]["ASM_CO"].ToString());
                    model.ASM_NO = Double.Parse(dt.Rows[0]["ASM_NO"].ToString());
                    model.VMAS_HC = Double.Parse(dt.Rows[0]["VMAS_HC"].ToString());
                    model.VMAS_CO = Double.Parse(dt.Rows[0]["VMAS_CO"].ToString());
                    model.VMAS_NO = Double.Parse(dt.Rows[0]["VMAS_NO"].ToString());
                    model.SDS_HC = Double.Parse(dt.Rows[0]["SDS_HC"].ToString());
                    model.SDS_CO = Double.Parse(dt.Rows[0]["SDS_CO"].ToString());
                    model.ZYJS_K = Double.Parse(dt.Rows[0]["ZYJS_K"].ToString());
                    model.JZJS_K = Double.Parse(dt.Rows[0]["JZJS_K"].ToString());
                    model.JZJS_GL = Double.Parse(dt.Rows[0]["JZJS_GL"].ToString());
                    model.ISUSE = (dt.Rows[0]["ISUSE"].ToString() == "Y");

                }
                else
                    model.ISUSE = false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                model.ISUSE = false;
            }
            return model;

        }
        #endregion
        #region 检查是否存在该编号的线标定信息
        public bool checkLineCalIsAlive(string stationid, string lineid)
        {
            string sql = "select * from [设备标定] where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        #region 保存检测线设备标定信息
        public bool saveLineCalInf(LINESBBD model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [设备标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("HXDATE,");//=@PZLX,");1
            strSql.Append("HXENABLE,");//=@PZLX,");1
            strSql.Append("YRDATE,");//=@PZLX,");1
            strSql.Append("YRENABLE,");//=@PZLX,");1
            strSql.Append("ZJDATE,");//=@PZLX,");1
            strSql.Append("ZJENABLE,");//=@PZLX,");1
            strSql.Append("JSGLDATE,");//=@PZLX,");1
            strSql.Append("JSGLENABLE,");//=@PZLX,");1
            strSql.Append("YLJDATE,");//=@PZLX,");1
            strSql.Append("YLJENABLE,");//=@PZLX,");1
            strSql.Append("SDDATE,");//=@PZLX,");1
            strSql.Append("SDENABLE,");//=@PZLX,");1
            strSql.Append("HJCSDATE,");//=@PZLX,");1
            strSql.Append("HJCSENABLE,");//=@PZLX,");1
            strSql.Append("ZSJDATE,");//=@PZLX,");1
            strSql.Append("ZSJENABLE,");//=@PZLX,");1
            strSql.Append("GLDATE,");//=@PZLX,");1
            strSql.Append("GLENABLE,");//=@PZLX,");1
            strSql.Append("FXYLOWDATE,");//=@PZLX,");1
            strSql.Append("FXYLOWENABLE,");//=@PZLX,");1
            strSql.Append("FXYHIGHDATE,");//=@PZLX,");1
            strSql.Append("FXYHIGHENABLE,");//=@PZLX,");1
            strSql.Append("FXYMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYMIDENABLE,");//=@PZLX,");1
            strSql.Append("FXYLOWMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYLOWMIDENABLE,");//=@PZLX,");1
            strSql.Append("FXYHIGHMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYHIGHMIDENABLE,");//=@PZLX,");1
            strSql.Append("YDJDATE,");//=@PZLX,");1
            strSql.Append("YDJENABLE,");//=@PZLX,");1
            strSql.Append("JLDATE,");//=@PZLX,");1
            strSql.Append("JLENABLE,");//=@PZLX,");1
            strSql.Append("LLJDATE,");//=@PZLX,");1
            strSql.Append("LLJENABLE)");//=@PZLX,");1
            strSql.Append("values (@STATIONID,@LINEID,@HXDATE,@HXENABLE,@YRDATE,@YRENABLE,@ZJDATE,@ZJENABLE,@JSGLDATE,@JSGLENABLE,@YLJDATE,@YLJENABLE,@SDDATE,@SDENABLE,"+
                "@HJCSDATE,@HJCSENABLE,@ZSJDATE,@ZSJENABLE,@GLDATE,@GLENABLE,@FXYLOWDATE,@FXYLOWENABLE,@FXYHIGHDATE,@FXYHIGHENABLE,@FXYMIDDATE,@FXYMIDENABLE,@FXYLOWMIDDATE,@FXYLOWMIDENABLE,@FXYHIGHMIDDATE,@FXYHIGHMIDENABLE,"+
                "@YDJDATE,@YDJENABLE,@JLDATE,@JLENABLE,@LLJDATE,@LLJENABLE)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@HXDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@HXENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YRDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YRENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@ZJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@JSGLDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@JSGLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YLJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YLJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@SDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@HJCSDATE", SqlDbType.DateTime),
                                            new SqlParameter("@HJCSENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@ZSJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@GLDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@GLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYLOWDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYLOWENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYHIGHDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYHIGHENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYMIDDATE", SqlDbType.DateTime),
                                            new SqlParameter("@FXYMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYLOWMIDDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYLOWMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYHIGHMIDDATE", SqlDbType.DateTime),
                                            new SqlParameter("@FXYHIGHMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YDJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@JLDATE", SqlDbType.DateTime),
                                            new SqlParameter("@JLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@LLJENABLE", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.STATIONID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.Hxdate;
            parameters[i++].Value = model.Hxenable?"Y":"N";
            parameters[i++].Value = model.Yrdate;
            parameters[i++].Value = model.Yrenable ? "Y" : "N";
            parameters[i++].Value = model.Zjdate;
            parameters[i++].Value = model.Zjenable ? "Y" : "N";
            parameters[i++].Value = model.Jsgldate;
            parameters[i++].Value = model.Jsglenable ? "Y" : "N";
            parameters[i++].Value = model.Yljdate;
            parameters[i++].Value = model.Yljenable ? "Y" : "N";
            parameters[i++].Value = model.Sddate;
            parameters[i++].Value = model.Sdenable ? "Y" : "N";
            parameters[i++].Value = model.Hjcsdate;
            parameters[i++].Value = model.Hjcsenable ? "Y" : "N";
            parameters[i++].Value = model.Zsjdate;
            parameters[i++].Value = model.Zsjenable ? "Y" : "N";
            parameters[i++].Value = model.Gldate;
            parameters[i++].Value = model.Glenable ? "Y" : "N";
            parameters[i++].Value = model.Fxylowdate;
            parameters[i++].Value = model.Fxylowenable ? "Y" : "N";
            parameters[i++].Value = model.Fxyhighdate;
            parameters[i++].Value = model.Fxyhighenable ? "Y" : "N";
            parameters[i++].Value = model.Fxymiddate;
            parameters[i++].Value = model.Fxymidenable ? "Y" : "N";
            parameters[i++].Value = model.Fxylowmiddate;
            parameters[i++].Value = model.Fxylowmidenable ? "Y" : "N";
            parameters[i++].Value = model.Fxyhighmiddate;
            parameters[i++].Value = model.Fxyhighmidenable ? "Y" : "N";
            parameters[i++].Value = model.Ydjdate;
            parameters[i++].Value = model.Ydjenable ? "Y" : "N";
            parameters[i++].Value = model.Jldate;
            parameters[i++].Value = model.Jlenable ? "Y" : "N";
            parameters[i++].Value = model.Lljdate;
            parameters[i++].Value = model.Lljenable ? "Y" : "N";
            try
            {
                if (checkLineCalIsAlive(model.STATIONID, model.LINEID))
                {
                    if (updateLineCalInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 保存检测线标定信息
        public bool updateLineCalInf(LINESBBD model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [设备标定] set ");
            strSql.Append("HXDATE=@HXDATE,");//=@PZLX,");1
            strSql.Append("HXENABLE=@HXENABLE,");//=@PZLX,");1
            strSql.Append("YRDATE=@YRDATE,");//=@PZLX,");1
            strSql.Append("YRENABLE=@YRENABLE,");//=@PZLX,");1
            strSql.Append("ZJDATE=@ZJDATE,");//=@PZLX,");1
            strSql.Append("ZJENABLE=@ZJENABLE,");//=@PZLX,");1
            strSql.Append("JSGLDATE=@JSGLDATE,");//=@PZLX,");1
            strSql.Append("JSGLENABLE=@JSGLENABLE,");//=@PZLX,");1
            strSql.Append("YLJDATE=@YLJDATE,");//=@PZLX,");1
            strSql.Append("YLJENABLE=@YLJENABLE,");//=@PZLX,");1
            strSql.Append("SDDATE=@SDDATE,");//=@PZLX,");1
            strSql.Append("SDENABLE=@SDENABLE,");//=@PZLX,");1
            strSql.Append("HJCSDATE=@HJCSDATE,");//=@PZLX,");1
            strSql.Append("HJCSENABLE=@HJCSENABLE,");//=@PZLX,");1
            strSql.Append("ZSJDATE=@ZSJDATE,");//=@PZLX,");1
            strSql.Append("ZSJENABLE=@ZSJENABLE,");//=@PZLX,");1
            strSql.Append("GLDATE=@GLDATE,");//=@PZLX,");1
            strSql.Append("GLENABLE=@GLENABLE,");//=@PZLX,");1
            strSql.Append("FXYLOWDATE=@FXYLOWDATE,");//=@PZLX,");1
            strSql.Append("FXYLOWENABLE=@FXYLOWENABLE,");//=@PZLX,");1
            strSql.Append("FXYHIGHDATE=@FXYHIGHDATE,");//=@PZLX,");1
            strSql.Append("FXYHIGHENABLE=@FXYHIGHENABLE,");//=@PZLX,");1
            strSql.Append("FXYMIDDATE=@FXYMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYMIDENABLE=@FXYMIDENABLE,");//=@PZLX,");1
            strSql.Append("FXYLOWMIDDATE=@FXYLOWMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYLOWMIDENABLE=@FXYLOWMIDENABLE,");//=@PZLX,");1
            strSql.Append("FXYHIGHMIDDATE=@FXYHIGHMIDDATE,");//=@PZLX,");1
            strSql.Append("FXYHIGHMIDENABLE=@FXYHIGHMIDENABLE,");//=@PZLX,");1
            strSql.Append("YDJDATE=@YDJDATE,");//=@PZLX,");1
            strSql.Append("YDJENABLE=@YDJENABLE,");//=@PZLX,");1
            strSql.Append("JLDATE=@JLDATE,");//=@PZLX,");1
            strSql.Append("JLENABLE=@JLENABLE,");//=@PZLX,");1
            strSql.Append("LLJDATE=@LLJDATE,");//=@PZLX,");1
            strSql.Append("LLJENABLE=@LLJENABLE ");//=@PZLX,");1
            strSql.Append("where stationid=@STATIONID and lineid=@LINEID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@HXDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@HXENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YRDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YRENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@ZJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@JSGLDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@JSGLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YLJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YLJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@SDDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@SDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@HJCSDATE", SqlDbType.DateTime),
                                            new SqlParameter("@HJCSENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZSJDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@ZSJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@GLDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@GLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYLOWDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYLOWENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYHIGHDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYHIGHENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYMIDDATE", SqlDbType.DateTime),
                                            new SqlParameter("@FXYMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYLOWMIDDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@FXYLOWMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@FXYHIGHMIDDATE", SqlDbType.DateTime),
                                            new SqlParameter("@FXYHIGHMIDENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@YDJDATE", SqlDbType.DateTime),
                                            new SqlParameter("@YDJENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@JLDATE", SqlDbType.DateTime),
                                            new SqlParameter("@JLENABLE", SqlDbType.VarChar,50),
                                            new SqlParameter("@LLJDATE",  SqlDbType.DateTime),
                                            new SqlParameter("@LLJENABLE", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.STATIONID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.Hxdate;
            parameters[i++].Value = model.Hxenable ? "Y" : "N";
            parameters[i++].Value = model.Yrdate;
            parameters[i++].Value = model.Yrenable ? "Y" : "N";
            parameters[i++].Value = model.Zjdate;
            parameters[i++].Value = model.Zjenable ? "Y" : "N";
            parameters[i++].Value = model.Jsgldate;
            parameters[i++].Value = model.Jsglenable ? "Y" : "N";
            parameters[i++].Value = model.Yljdate;
            parameters[i++].Value = model.Yljenable ? "Y" : "N";
            parameters[i++].Value = model.Sddate;
            parameters[i++].Value = model.Sdenable ? "Y" : "N";
            parameters[i++].Value = model.Hjcsdate;
            parameters[i++].Value = model.Hjcsenable ? "Y" : "N";
            parameters[i++].Value = model.Zsjdate;
            parameters[i++].Value = model.Zsjenable ? "Y" : "N";
            parameters[i++].Value = model.Gldate;
            parameters[i++].Value = model.Glenable ? "Y" : "N";
            parameters[i++].Value = model.Fxylowdate;
            parameters[i++].Value = model.Fxylowenable ? "Y" : "N";
            parameters[i++].Value = model.Fxyhighdate;
            parameters[i++].Value = model.Fxyhighenable ? "Y" : "N";
            parameters[i++].Value = model.Fxymiddate;
            parameters[i++].Value = model.Fxymidenable ? "Y" : "N";
            parameters[i++].Value = model.Fxylowmiddate;
            parameters[i++].Value = model.Fxylowmidenable ? "Y" : "N";
            parameters[i++].Value = model.Fxyhighmiddate;
            parameters[i++].Value = model.Fxyhighmidenable ? "Y" : "N";
            parameters[i++].Value = model.Ydjdate;
            parameters[i++].Value = model.Ydjenable ? "Y" : "N";
            parameters[i++].Value = model.Jldate;
            parameters[i++].Value = model.Jlenable ? "Y" : "N";
            parameters[i++].Value = model.Lljdate;
            parameters[i++].Value = model.Lljenable ? "Y" : "N";
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

        #region 检查是否存在该编号的线流水号信息
        public bool checkLineLSHIsAlive(string stationid, string lineid)
        {
            string sql = "select * from [流水号信息] where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        #region 保存检测线流水号信息
        public bool saveLineLSHInf(lshModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [流水号信息] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("DATE,");//=@PZLX,");1
            strSql.Append("COUNT)");//=@PZLX,");1
            strSql.Append("values (@STATIONID,@LINEID,@DATE,@COUNT)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@DATE", SqlDbType.DateTime),
                                            new SqlParameter("@COUNT", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.StationID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.DATE;
            parameters[i++].Value = model.COUNT;
            try
            {
                if (checkLineLSHIsAlive(model.StationID, model.LINEID))
                {
                    if (updateLineLSHInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 保存检测线流水号信息
        public bool updateLineLSHInf(lshModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [流水号信息] set ");
            strSql.Append("DATE=@DATE,");
            strSql.Append("COUNT=@COUNT ");
            strSql.Append("where stationid=@STATIONID and lineid=@LINEID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@DATE", SqlDbType.DateTime),
                                            new SqlParameter("@COUNT", SqlDbType.VarChar,50)};
            parameters[i++].Value = model.StationID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.DATE;
            parameters[i++].Value = model.COUNT;
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
        #region 获取该检测站某条检测线的某一项标定内容
        /// <summary>
        /// 获取所有检测线的信息
        /// stationid:站号，lineid:线号，0表示所有线，startTime:起始时间,endtime:终止时间,plate:车牌,jcff:0-不限,result:检测结果：-1—不合格，1-合格，0-不限,cllx:1-轻型车，2-中型车，3-重型车，0，不限
        /// </summary>
        public DataTable getStationLineInf( string project,string stationid)
        {
            string sql = "";
            sql = "select * from [" + project + "] where STATIONID='" + stationid  + "'";

            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                return dt;
                throw;
            }
        }
        #endregion
    }
}


