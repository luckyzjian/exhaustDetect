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
using carinfor;

namespace SYS_DAL
{
    public partial class demarcateControl
    {
        #region 保存废气仪标定信息
        public bool saveAnalysisDemarcateDataByIni(analysismeterInidata model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [废气仪标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("CO2BZ,");//=@CLXHBH,");3
            strSql.Append("CO2CLZ,");//=@CLXHBH,");3
            strSql.Append("COBZ,");//=@JCCS,");4
            strSql.Append("COCLZ,");//=@CCRQ,");5
            strSql.Append("HCBZ,");//=@DJRQ,"); 6
            strSql.Append("HCCLZ,");//=@FDJH,");7
            strSql.Append("NOBZ,");//=@CJH,");8
            strSql.Append("NOCLZ,");//=@CZ,");9
            strSql.Append("JZDS,");//=@CZDH,");10
            strSql.Append("GDJZ,");//=@CZDZ,");11
            strSql.Append("BZSM,");//=@LCBDS,");12
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@CO2BZ,@CO2CLZ,@COBZ,@COCLZ,@HCBZ,@HCCLZ,@NOBZ,@NOCLZ,@JZDS,@GDJZ,@BZSM,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@CO2BZ",SqlDbType.VarChar,50),
                    new SqlParameter("@CO2CLZ",SqlDbType.VarChar,100),
					new SqlParameter("@COBZ", SqlDbType.VarChar,50),
					new SqlParameter("@COCLZ", SqlDbType.VarChar,50),
                    new SqlParameter("@HCBZ", SqlDbType.VarChar,50),
					new SqlParameter("@HCCLZ", SqlDbType.VarChar,50),
					new SqlParameter("@NOBZ", SqlDbType.VarChar,50),
					new SqlParameter("@NOCLZ", SqlDbType.VarChar,50),
					new SqlParameter("@JZDS", SqlDbType.VarChar,50),
					new SqlParameter("@GDJZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Co2bz.ToString("0.00");
            parameters[i++].Value = model.Co2clz.ToString("0.00");
            parameters[i++].Value = model.Cobz.ToString("0.00");
            parameters[i++].Value = model.Coclz.ToString("0.00");
            parameters[i++].Value = model.Hcbz.ToString("0.00");
            parameters[i++].Value = model.Hcclz.ToString("0.00");
            parameters[i++].Value = model.Nobz.ToString("0.00");
            parameters[i++].Value = model.Noclz.ToString("0.00");
            parameters[i++].Value = model.Jzds.ToString();
            parameters[i++].Value = model.Gdjz;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有废气标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllAnalysisDemarcateData()
        {
            string sql = "select * from [废气仪标定] order by BDRQ desc";
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
        #endregion
        #region 保存废气仪检查
        public bool saveAnalysisDataByIni(analysismeterInidata model,string stationid,string lineid,DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [废气仪检查] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("CO2BZ,");//=@CLXHBH,");3
            strSql.Append("CO2CLZ,");//=@CLXHBH,");3
            strSql.Append("COBZ,");//=@JCCS,");4
            strSql.Append("COCLZ,");//=@CCRQ,");5
            strSql.Append("HCBZ,");//=@DJRQ,"); 6
            strSql.Append("HCCLZ,");//=@FDJH,");7
            strSql.Append("NOBZ,");//=@CJH,");8
            strSql.Append("NOCLZ,");//=@CZ,");9
            strSql.Append("JZDS,");//=@CZDH,");10
            strSql.Append("GDJZ,");//=@CZDZ,");11
            strSql.Append("BZSM,");//=@LCBDS,");12
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@CO2BZ,@CO2CLZ,@COBZ,@COCLZ,@HCBZ,@HCCLZ,@NOBZ,@NOCLZ,@JZDS,@GDJZ,@BZSM,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@CO2BZ",SqlDbType.VarChar,50),
                    new SqlParameter("@CO2CLZ",SqlDbType.VarChar,100),
					new SqlParameter("@COBZ", SqlDbType.VarChar,50),
					new SqlParameter("@COCLZ", SqlDbType.VarChar,50),
                    new SqlParameter("@HCBZ", SqlDbType.VarChar,50),
					new SqlParameter("@HCCLZ", SqlDbType.VarChar,50),
					new SqlParameter("@NOBZ", SqlDbType.VarChar,50),
					new SqlParameter("@NOCLZ", SqlDbType.VarChar,50),
					new SqlParameter("@JZDS", SqlDbType.VarChar,50),
					new SqlParameter("@GDJZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Co2bz.ToString("0.00");
            parameters[i++].Value = model.Co2clz.ToString("0.00");
            parameters[i++].Value = model.Cobz.ToString("0.000");
            parameters[i++].Value = model.Coclz.ToString("0.000");
            parameters[i++].Value = model.Hcbz.ToString("0");
            parameters[i++].Value = model.Hcclz.ToString("0");
            parameters[i++].Value = model.Nobz.ToString("0");
            parameters[i++].Value = model.Noclz.ToString("0");
            parameters[i++].Value = model.Jzds.ToString();
            parameters[i++].Value = model.Gdjz;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有废气检查信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllAnalysisData()
        {
            string sql = "select * from [废气仪检查] order by BDRQ desc";
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
        #endregion

        #region 保存流量计检查
        public bool saveFlowmeterDataByIni(Flowmeterdata model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [流量计标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("O2GLCBZ,");//=@CLXHBH,");3
            strSql.Append("O2GLCCLZ,");//=@CLXHBH,");3
            strSql.Append("O2GLCWC,");//=@JCCS,");4
            strSql.Append("O2DLCBZ,");//=@CCRQ,");5
            strSql.Append("O2DLCCLZ,");//=@DJRQ,"); 6
            strSql.Append("O2DLCWC,");//=@FDJH,");7
            strSql.Append("BZSM,");//=@LCBDS,");12
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@O2GLCBZ,@O2GLCCLZ,@O2GLCWC,@O2DLCBZ,@O2DLCCLZ,@O2DLCWC,@BZSM,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@O2GLCBZ",SqlDbType.VarChar,50),
                    new SqlParameter("@O2GLCCLZ",SqlDbType.VarChar,100),
					new SqlParameter("@O2GLCWC", SqlDbType.VarChar,50),
					new SqlParameter("@O2DLCBZ", SqlDbType.VarChar,50),
                    new SqlParameter("@O2DLCCLZ", SqlDbType.VarChar,50),
					new SqlParameter("@O2DLCWC", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.O2glcbz.ToString("0.00");
            parameters[i++].Value = model.O2glcclz.ToString("0.00");
            parameters[i++].Value = model.O2glcwc.ToString("0.00");
            parameters[i++].Value = model.O2dlcbz.ToString("0.00");
            parameters[i++].Value = model.O2dlcclz.ToString("0.00");
            parameters[i++].Value = model.O2dlcwc.ToString("0.00");
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有流量计标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllFlowmeterData()
        {
            string sql = "select * from [流量计标定] order by BDRQ desc";
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
        #endregion

        #region 保存寄生功率试验
        public bool saveParasiticDataByIni(parasitic model,string stationid,string lineid,DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [寄生功率试验] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("SDQJ,");//=@CLXHBH,");3
            strSql.Append("MYSD,");//=@CLXHBH,");3
            strSql.Append("HXSJ,");//=@JCCS,");4
            strSql.Append("JSGL,");//=@CCRQ,");5
            strSql.Append("LJHXSJ,");//=@DJRQ,"); 6
            strSql.Append("BZ,");//=@FDJH,");7
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@SDQJ,@MYSD,@HXSJ,@JSGL,@LJHXSJ,@BZ,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@SDQJ",SqlDbType.VarChar,50),
                    new SqlParameter("@MYSD",SqlDbType.VarChar,100),
					new SqlParameter("@HXSJ", SqlDbType.VarChar,50),
					new SqlParameter("@JSGL", SqlDbType.VarChar,50),
                    new SqlParameter("@LJHXSJ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Sdqj;
            parameters[i++].Value = model.Mysd;
            parameters[i++].Value = model.Hxsj;
            parameters[i++].Value = model.Jsgl;
            parameters[i++].Value = model.Ljhxsj;
            parameters[i++].Value = model.Bz;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有寄生功率试验信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllParasiticData()
        {
            string sql = "select * from [寄生功率试验] order by BDRQ desc";
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
        #endregion

        #region 保存加载滑行试验检查
        public bool saveGlideDataByIni(glide model,string stationid,string lineid,DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [加载滑行试验] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("HXQJ,");//=@CLXHBH,");3
            strSql.Append("QJMYSD,");//=@CLXHBH,");3
            strSql.Append("PLHP,");//=@JCCS,");4
            strSql.Append("CCDT,");//=@CCRQ,");5
            strSql.Append("ACDT,");//=@DJRQ,"); 6
            strSql.Append("WC,");//=@FDJH,");7
            strSql.Append("JZSDGL,");//=@CJH,");8
            strSql.Append("BZSM,");//=@LCBDS,");12
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@HXQJ,@QJMYSD,@PLHP,@CCDT,@ACDT,@WC,@JZSDGL,@BZSM,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@HXQJ",SqlDbType.VarChar,50),
                    new SqlParameter("@QJMYSD",SqlDbType.VarChar,100),
					new SqlParameter("@PLHP", SqlDbType.VarChar,50),
					new SqlParameter("@CCDT", SqlDbType.VarChar,50),
                    new SqlParameter("@ACDT", SqlDbType.VarChar,50),
					new SqlParameter("@WC", SqlDbType.VarChar,50),
					new SqlParameter("@JZSDGL", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Hxqj;
            parameters[i++].Value = model.Qjmysd;
            parameters[i++].Value = model.Plhp;
            parameters[i++].Value = model.Ccdt;
            parameters[i++].Value = model.Acdt;
            parameters[i++].Value = model.Wc;
            parameters[i++].Value = model.Jzsdgl;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllGlideData()
        {
            string sql = "select * from [加载滑行试验] order by BDRQ desc";
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
        #endregion

     
        #region 保存惯量测试
        public bool saveInertnessDataByIni(inertness model,string stationid,string lineid,DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [惯量测试试验] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("T1POWER,");//=@CLXHBH,");3
            strSql.Append("T2POWER,");//=@CLXHBH,");3
            strSql.Append("STARTSPEED,");//=@JCCS,");4
            strSql.Append("ENDSPEED,");//=@CCRQ,");5
            strSql.Append("ACD1_1,");//=@DJRQ,"); 6
            strSql.Append("ACD1_2,");//=@FDJH,");7
            strSql.Append("ACD1_3,");//=@CJH,");8
            strSql.Append("ACD1,");//=@CZ,");9
            strSql.Append("ACD2_1,");//=@DJRQ,"); 6
            strSql.Append("ACD2_2,");//=@FDJH,");7
            strSql.Append("ACD2_3,");//=@CJH,");8
            strSql.Append("ACD2,");//=@CZ,");9
            strSql.Append("DIW_1,");//=@DJRQ,"); 6
            strSql.Append("DIW_2,");//=@FDJH,");7
            strSql.Append("DIW_3,");//=@CJH,");8
            strSql.Append("DIW,");//=@CZ,");9
            strSql.Append("DIW_BC,");//=@CZDH,");10
            strSql.Append("DIW_SC,");//=@CZDZ,");11
            strSql.Append("WC,");//=@CZ,");9
            strSql.Append("PD,");//=@CZDH,");10
            strSql.Append("HXSJ,");//=@CZDZ,");11
            strSql.Append("BZ,");//=@LCBDS,");12
            strSql.Append("BDJG,");//=@HBBZ,");13
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@T1POWER,@T2POWER,@STARTSPEED,@ENDSPEED,@ACD1_1,@ACD1_2,@ACD1_3,@ACD1,@ACD2_1,@ACD2_2,@ACD2_3,@ACD2,@DIW_1,@DIW_2,@DIW_3,@DIW,@DIW_BC,@DIW_SC,@WC,@PD,@HXSJ,@BZ,@BDJG,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@T1POWER",SqlDbType.VarChar,50),
                    new SqlParameter("@T2POWER",SqlDbType.VarChar,100),
					new SqlParameter("@STARTSPEED", SqlDbType.VarChar,50),
					new SqlParameter("@ENDSPEED", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD1_1", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD1_2", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD1_3", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD1", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD2_1", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD2_2", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD2_3", SqlDbType.VarChar,50),
                    new SqlParameter("@ACD2", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW_1", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW_2", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW_3", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW_BC", SqlDbType.VarChar,50),
                    new SqlParameter("@DIW_SC", SqlDbType.VarChar,50),
                    new SqlParameter("@WC", SqlDbType.VarChar,50),
					new SqlParameter("@PD", SqlDbType.VarChar,50),
					new SqlParameter("@HXSJ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.T1power;
            parameters[i++].Value = model.T2power;
            parameters[i++].Value = model.StartSpeed;
            parameters[i++].Value = model.EndSpeed;
            parameters[i++].Value = model.Acd1_1;
            parameters[i++].Value = model.Acd1_2;
            parameters[i++].Value = model.Acd1_3;
            parameters[i++].Value = model.Acd1;
            parameters[i++].Value = model.Acd2_1;
            parameters[i++].Value = model.Acd2_2;
            parameters[i++].Value = model.Acd2_3;
            parameters[i++].Value = model.Acd2;
            parameters[i++].Value = model.Diw_1;
            parameters[i++].Value = model.Diw_2;
            parameters[i++].Value = model.Diw_3;
            parameters[i++].Value = model.Diw;
            parameters[i++].Value = model.Diw_bc;
            parameters[i++].Value = model.Diw_sc;
            parameters[i++].Value = model.Wc;
            parameters[i++].Value = model.Pd;
            parameters[i++].Value = model.Hxsj;
            parameters[i++].Value = model.Bz;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = bdrq;
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
        #region 获取所有标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllInertnessData()
        {
            string sql = "select * from [惯量测试试验] order by BDRQ desc";
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
        #endregion

       
        #region 保存变载荷检查
        public bool saveBzGlideDataByIni(bzglide model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [变载荷滑行测试] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("HXQJ,");//=@CLXHBH,");3
            strSql.Append("CCDT,");//=@CLXHBH,");3
            strSql.Append("ACDT,");//=@JCCS,");4
            strSql.Append("WC,");//=@CCRQ,");5
            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("BZSM,");//=@FDJH,");7
            strSql.Append("CZY,");//=@LCBDS,");12
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@HXQJ,@CCDT,@ACDT,@WC,@BDJG,@BZSM,@CZY,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@HXQJ",SqlDbType.VarChar,50),
                    new SqlParameter("@CCDT",SqlDbType.VarChar,50),
					new SqlParameter("@ACDT", SqlDbType.VarChar,50),
					new SqlParameter("@WC", SqlDbType.VarChar,50),
                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@CZY", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Hxqj;
            parameters[i++].Value = model.Ccdt;
            parameters[i++].Value = model.Acdt;
            parameters[i++].Value = model.Wc;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = "";
            parameters[i++].Value = bdrq;
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
        #region 保存变载荷检查
        public bool saveYljDataByIni(yljbddata model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [扭力标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("BZ1,");//=@CLXHBH,");3
            strSql.Append("CLZ1,");//=@CLXHBH,");3
            strSql.Append("WC1,");//=@JCCS,");4
            strSql.Append("BZ2,");//=@CLXHBH,");3
            strSql.Append("CLZ2,");//=@CLXHBH,");3
            strSql.Append("WC2,");//=@JCCS,");4
            strSql.Append("BZ3,");//=@CLXHBH,");3
            strSql.Append("CLZ3,");//=@CLXHBH,");3
            strSql.Append("WC3,");//=@JCCS,");4
            strSql.Append("BZ4,");//=@CLXHBH,");3
            strSql.Append("CLZ4,");//=@CLXHBH,");3
            strSql.Append("WC4,");//=@JCCS,");4
            strSql.Append("BZ5,");//=@CLXHBH,");3
            strSql.Append("CLZ5,");//=@CLXHBH,");3
            strSql.Append("WC5,");//=@JCCS,");4
            strSql.Append("BDDS,");//=@CCRQ,");5
            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("BZSM,");//=@FDJH,");7
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@BZ1,@CLZ1,@WC1,@BZ2,@CLZ2,@WC2,@BZ3,@CLZ3,@WC3,@BZ4,@CLZ4,@WC4,@BZ5,@CLZ5,@WC5,@BDDS,@BDJG,@BZSM,@BDRQ)");
            SqlParameter[] parameters = {
                    new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                    new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ1",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ1",SqlDbType.VarChar,50),
                    new SqlParameter("@WC1", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ2",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ2",SqlDbType.VarChar,50),
                    new SqlParameter("@WC2", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ3",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ3",SqlDbType.VarChar,50),
                    new SqlParameter("@WC3", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ4",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ4",SqlDbType.VarChar,50),
                    new SqlParameter("@WC4", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ5",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ5",SqlDbType.VarChar,50),
                    new SqlParameter("@WC5", SqlDbType.VarChar,50),
                    new SqlParameter("@BDDS", SqlDbType.VarChar,50),
                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
                    new SqlParameter("@BZSM", SqlDbType.VarChar,50),
                    new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Bz1;
            parameters[i++].Value = model.Clz1;
            parameters[i++].Value = model.Wc1;
            parameters[i++].Value = model.Bz2;
            parameters[i++].Value = model.Clz2;
            parameters[i++].Value = model.Wc2;
            parameters[i++].Value = model.Bz3;
            parameters[i++].Value = model.Clz3;
            parameters[i++].Value = model.Wc3;
            parameters[i++].Value = model.Bz4;
            parameters[i++].Value = model.Clz4;
            parameters[i++].Value = model.Wc4;
            parameters[i++].Value = model.Bz5;
            parameters[i++].Value = model.Clz5;
            parameters[i++].Value = model.Wc5;
            parameters[i++].Value = model.Bdds;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = bdrq;
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
        #region 保存变载荷检查
        public bool saveSdDataByIni(sdbddata model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [速度标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("BZ1,");//=@CLXHBH,");3
            strSql.Append("CLZ1,");//=@CLXHBH,");3
            strSql.Append("WC1,");//=@JCCS,");4
            strSql.Append("BZ2,");//=@CLXHBH,");3
            strSql.Append("CLZ2,");//=@CLXHBH,");3
            strSql.Append("WC2,");//=@JCCS,");4
            strSql.Append("BZ3,");//=@CLXHBH,");3
            strSql.Append("CLZ3,");//=@CLXHBH,");3
            strSql.Append("WC3,");//=@JCCS,");4
            strSql.Append("BDDS,");//=@CCRQ,");5
            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("BZSM,");//=@FDJH,");7
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@BZ1,@CLZ1,@WC1,@BZ2,@CLZ2,@WC2,@BZ3,@CLZ3,@WC3,@BDDS,@BDJG,@BZSM,@BDRQ)");
            SqlParameter[] parameters = {
                    new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                    new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ1",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ1",SqlDbType.VarChar,50),
                    new SqlParameter("@WC1", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ2",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ2",SqlDbType.VarChar,50),
                    new SqlParameter("@WC2", SqlDbType.VarChar,50),
                    new SqlParameter("@BZ3",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZ3",SqlDbType.VarChar,50),
                    new SqlParameter("@WC3", SqlDbType.VarChar,50),                    
                    new SqlParameter("@BDDS", SqlDbType.VarChar,50),
                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
                    new SqlParameter("@BZSM", SqlDbType.VarChar,50),
                    new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Bz1;
            parameters[i++].Value = model.Clz1;
            parameters[i++].Value = model.Wc1;
            parameters[i++].Value = model.Bz2;
            parameters[i++].Value = model.Clz2;
            parameters[i++].Value = model.Wc2;
            parameters[i++].Value = model.Bz3;
            parameters[i++].Value = model.Clz3;
            parameters[i++].Value = model.Wc3;
            parameters[i++].Value = model.Bdds;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = bdrq;
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
        #region 获取所有变载荷标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllbzGlideData()
        {
            string sql = "select * from [变载荷滑行测试] order by BDRQ desc";
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
        #endregion

        #region 保存烟度计检查
        public bool saveSmokeDataByIni(Smokemeterdata model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [烟度计标定] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("KBZ,");//=@CLXHBH,");3
            strSql.Append("KSCZ,");//=@CLXHBH,");3
            strSql.Append("KABSWC,");//=@JCCS,");4
            strSql.Append("KRELWC,");//=@CCRQ,");5
            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("BZSM,");//=@FDJH,");7
            strSql.Append("CZY,");//=@LCBDS,");12
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@KBZ,@KSCZ,@KABSWC,@KRELWC,@BDJG,@BZSM,@CZY,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@KBZ",SqlDbType.VarChar,50),
                    new SqlParameter("@KSCZ",SqlDbType.VarChar,50),
					new SqlParameter("@KABSWC", SqlDbType.VarChar,50),
					new SqlParameter("@KRELWC", SqlDbType.VarChar,50),
                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@CZY", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Kbz.ToString("0.00");
            parameters[i++].Value = model.Kscz.ToString("0.00");
            parameters[i++].Value = model.Kabswc.ToString("0.00");
            parameters[i++].Value = model.Krelwc.ToString("0.000");
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = "";
            parameters[i++].Value = bdrq;
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
        #region 获取所有烟度计标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllSmokeData()
        {
            string sql = "select * from [烟度计标定] order by BDRQ desc";
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
        #endregion

        #region 保存响应时间检查
        public bool saveAnswerTimeByIni(xysjData model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [响应时间测试] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("SPEED,");//=@CLXHBH,");3
            strSql.Append("STARTPOWER,");//=@CLXHBH,");3
            strSql.Append("STARTFORCE,");//=@JCCS,");4
            strSql.Append("ENDPOWER,");//=@CCRQ,");5
            strSql.Append("ENDFORCE,");//=@CCRQ,");5
            strSql.Append("XYTIME,");//=@CCRQ,");5
            strSql.Append("WDTIME,");//=@CCRQ,");5
            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("CZY,");//=@LCBDS,");12
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@SPEED,@STARTPOWER,@STARTFORCE,@ENDPOWER,@ENDFORCE,@XYTIME,@WDTIME,@BDJG,@CZY,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@SPEED",SqlDbType.VarChar,50),
                    new SqlParameter("@STARTPOWER",SqlDbType.VarChar,50),
					new SqlParameter("@STARTFORCE", SqlDbType.VarChar,50),
					new SqlParameter("@ENDPOWER", SqlDbType.VarChar,50),
                    new SqlParameter("@ENDFORCE",SqlDbType.VarChar,50),
					new SqlParameter("@XYTIME", SqlDbType.VarChar,50),
					new SqlParameter("@WDTIME", SqlDbType.VarChar,50),
                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@CZY", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Sd;
            parameters[i++].Value = model.StartPower;
            parameters[i++].Value = model.StartForce;
            parameters[i++].Value = model.EndPower;
            parameters[i++].Value = model.EndForce;
            parameters[i++].Value = model.XyTime;
            parameters[i++].Value = model.WdTime;
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = "";
            parameters[i++].Value = bdrq;
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
        #region 获取所有响应时间信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllAnswerData()
        {
            string sql = "select * from [响应时间测试] order by BDRQ desc";
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
        #endregion

        #region 保存气象站检查
        public bool saveTemperatureDataByIni(temperatureData model, string stationid, string lineid, DateTime bdrq)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [气象站校准] (");
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@JCCLPH,");2
            strSql.Append("WDBZ,");//=@CLXHBH,");3
            strSql.Append("WDSCZ,");//=@CLXHBH,");3
            strSql.Append("SDBZ,");//=@JCCS,");4
            strSql.Append("SDSCZ,");//=@CCRQ,");5

            strSql.Append("DQYBZ,");//=@CLXHBH,");3
            strSql.Append("DQYSCZ,");//=@CLXHBH,");3
            strSql.Append("WDWC,");//=@JCCS,");4
            strSql.Append("SDWC,");//=@CCRQ,");5
            strSql.Append("DQYWC,");//=@CCRQ,");5

            strSql.Append("BDJG,");//=@DJRQ,"); 6
            strSql.Append("BZSM,");//=@FDJH,");7
            strSql.Append("CZY,");//=@LCBDS,");12
            strSql.Append("BDRQ) ");//=@SYQK,");14
            strSql.Append("values (@STATIONID,@LINEID,@WDBZ,@WDSCZ,@SDBZ,@SDSCZ,@DQYBZ,@DQYSCZ,@WDWC,@SDWC,@DQYWC,@BDJG,@BZSM,@CZY,@BDRQ)");
            SqlParameter[] parameters = {
					new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
					new SqlParameter("@LINEID", SqlDbType.VarChar,50),
					new SqlParameter("@WDBZ",SqlDbType.VarChar,50),
                    new SqlParameter("@WDSCZ",SqlDbType.VarChar,50),
					new SqlParameter("@SDBZ", SqlDbType.VarChar,50),
					new SqlParameter("@SDSCZ", SqlDbType.VarChar,50),

                    new SqlParameter("@DQYBZ", SqlDbType.VarChar,50),
					new SqlParameter("@DQYSCZ",SqlDbType.VarChar,50),
                    new SqlParameter("@WDWC",SqlDbType.VarChar,50),
					new SqlParameter("@SDWC", SqlDbType.VarChar,50),
					new SqlParameter("@DQYWC", SqlDbType.VarChar,50),

                    new SqlParameter("@BDJG", SqlDbType.VarChar,50),
					new SqlParameter("@BZSM", SqlDbType.VarChar,50),
					new SqlParameter("@CZY", SqlDbType.VarChar,50),
					new SqlParameter("@BDRQ", SqlDbType.DateTime)};
            parameters[i++].Value = stationid;
            parameters[i++].Value = lineid;
            parameters[i++].Value = model.Wdbz.ToString("0.00");
            parameters[i++].Value = model.Wdscz.ToString("0.00");
            parameters[i++].Value = model.Sdbz.ToString("0.00");
            parameters[i++].Value = model.Sdscz.ToString("0.00");
            parameters[i++].Value = model.Dqybz.ToString("0.00");
            parameters[i++].Value = model.Dqyscz.ToString("0.00");
            parameters[i++].Value = model.Wdwc.ToString("0.00");
            parameters[i++].Value = model.Sdwc.ToString("0.00");
            parameters[i++].Value = model.Dqywc.ToString("0.00");
            parameters[i++].Value = model.Bdjg;
            parameters[i++].Value = model.Bzsm;
            parameters[i++].Value = "";
            parameters[i++].Value = bdrq;
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
        #region 获取所有烟度计标定信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllTemperatureData()
        {
            string sql = "select * from [气象站校准] order by BDRQ desc";
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
        #endregion

        

        #region 保存工作日志
        public bool saveWordLogByIni(workLogData model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [操作日志] (");
            strSql.Append("PROID,");//=@PZLX,");1
            strSql.Append("PRONAME,");//=@JCCLPH,");2
            strSql.Append("STATIONID,");//=@CLXHBH,");3
            strSql.Append("LINEID,");//=@CLXHBH,");3
            strSql.Append("CZY,");//=@JCCS,");4
            strSql.Append("DATA,");//=@CCRQ,");5

            strSql.Append("STATE,");//=@CLXHBH,");3
            strSql.Append("RESULT,");//=@CLXHBH,");3
            strSql.Append("BDRQ,");//=@JCCS,");4
            strSql.Append("BZSM) ");//=@SYQK,");14
            strSql.Append("values (@PROID,@PRONAME,@STATIONID,@LINEID,@CZY,@DATA,@STATE,@RESULT,@BDRQ,@BZSM)");
            SqlParameter[] parameters = {
					new SqlParameter("@PROID", SqlDbType.VarChar,50),
					new SqlParameter("@PRONAME", SqlDbType.VarChar,50),
					new SqlParameter("@STATIONID",SqlDbType.VarChar,50),
                    new SqlParameter("@LINEID",SqlDbType.VarChar,50),
					new SqlParameter("@CZY", SqlDbType.VarChar,50),
					new SqlParameter("@DATA", SqlDbType.VarChar,1000),

                    new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@RESULT",SqlDbType.VarChar,50),
                    new SqlParameter("@BDRQ",SqlDbType.DateTime),
					new SqlParameter("@BZSM", SqlDbType.VarChar,100)};
            parameters[i++].Value = model.ProjectID;
            parameters[i++].Value = model.ProjectName;
            parameters[i++].Value = model.Stationid;
            parameters[i++].Value = model.Lineid;
            parameters[i++].Value = model.Czy;
            parameters[i++].Value = model.Data;
            parameters[i++].Value = model.State;
            parameters[i++].Value = model.Result;
            parameters[i++].Value = model.Date;
            parameters[i++].Value = model.Bzsm;
            try
            {
                if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        #endregion
        #region 获取所有工作日志信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllWorkLogData()
        {
            string sql = "select * from [操作日志] order by BDRQ desc";
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
        #endregion
        #region 获取该检测站某条检测线的某一项标定内容
        /// <summary>
        /// 获取所有检测线的信息
        /// stationid:站号，lineid:线号，0表示所有线，startTime:起始时间,endtime:终止时间,plate:车牌,jcff:0-不限,result:检测结果：-1—不合格，1-合格，0-不限,cllx:1-轻型车，2-中型车，3-重型车，0，不限
        /// </summary>
        public DataTable getAllDemarcateLog(DateTime starttime, DateTime endtime, string stationid, string lineid, string project)
        {
            string sql = "";
            sql = "select * from [" + project + "] where STATIONID='" + stationid + "' and LINEID='" + lineid + "' and";//+ "' and CLHP LIKE '" + plate + "'";
            sql += " BDRQ>='" + starttime.ToShortDateString() + " 00:00:00" + "' and BDRQ<='" + endtime.ToShortDateString() + " 23:59:59" + "' order by bdrq desc";

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


