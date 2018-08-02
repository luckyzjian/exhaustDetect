using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYS_DAL;
using SYS.Model;
using System.Data.SqlClient;
using System.Data;

namespace SYS_DAL
{
    public partial class BJCLXX
    {

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BJCLXXB GetModel(string JCBH)
        {

            string sql = "select * from BJCLXXB where JCBH=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",JCBH)
                                  // new SqlParameter("@jccs",JCCS),
                               };
            DataTable dt = null;
            BJCLXXB bjc_model = new BJCLXXB();
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    bjc_model.JCBH = dt.Rows[0]["JCBH"].ToString(); 
                    bjc_model.PZLX = dt.Rows[0]["PZLX"].ToString();
                    bjc_model.JCCLPH = dt.Rows[0]["JCCLPH"].ToString();
                    bjc_model.CLXHBH = dt.Rows[0]["CLXHBH"].ToString();
                    if (dt.Rows[0]["JCCS"].ToString().Trim() == "")
                        bjc_model.JCCS = 0;
                    else
                        bjc_model.JCCS = Convert.ToInt32(dt.Rows[0]["JCCS"].ToString());
                    //bjc_model.JCCS = Convert.ToInt32(dt.Rows[0]["JCCS"].ToString());
                    //bjc_model.LSH = Convert.ToInt32(dt.Rows[0]["LSH"].ToString());
                    bjc_model.CCRQ = (DateTime)dt.Rows[0]["CCRQ"];
                    bjc_model.DJRQ = (DateTime)dt.Rows[0]["DJRQ"];
                    bjc_model.FDJH = dt.Rows[0]["FDJH"].ToString();
                    bjc_model.CJH = dt.Rows[0]["CJH"].ToString();
                    bjc_model.CZ = dt.Rows[0]["CZ"].ToString();
                    bjc_model.CZDH = dt.Rows[0]["CZDH"].ToString();
                    bjc_model.CZDZ = dt.Rows[0]["CZDZ"].ToString();
                    if (dt.Rows[0]["LCBDS"].ToString().Trim() == "")
                        bjc_model.LCBDS = 0;
                    else
                        bjc_model.LCBDS = Convert.ToInt32(dt.Rows[0]["LCBDS"].ToString());
                    //bjc_model.LCBDS = Convert.ToInt32(dt.Rows[0]["LCBDS"].ToString());
                    bjc_model.HBBZ = dt.Rows[0]["HBBZ"].ToString();
                    bjc_model.SYQK = dt.Rows[0]["SYQK"].ToString();
                    bjc_model.JCBJ = dt.Rows[0]["JCBJ"].ToString();
                    bjc_model.JCZT = dt.Rows[0]["JCZT"].ToString();
                    bjc_model.QRJCFF = dt.Rows[0]["QRJCFF"].ToString();
                    bjc_model.RYLX = dt.Rows[0]["RYLX"].ToString();
                    bjc_model.GYFF = dt.Rows[0]["GYFF"].ToString();
                    bjc_model.BSXLX = dt.Rows[0]["BSXLX"].ToString();
                    bjc_model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    bjc_model.ZBZL = dt.Rows[0]["ZBZL"].ToString();
                    bjc_model.ZDZZL = dt.Rows[0]["ZDZZL"].ToString();
                    bjc_model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    bjc_model.FDJSCS = dt.Rows[0]["FDJSCS"].ToString();
                    bjc_model.JCZH = dt.Rows[0]["JCZH"].ToString();
                    bjc_model.DCZZ = dt.Rows[0]["DCZZ"].ToString();
                    bjc_model.FDJEDGL = dt.Rows[0]["FDJEDGL"].ToString();
                    bjc_model.FDJEDZS = dt.Rows[0]["FDJEDZS"].ToString();
                    if (dt.Rows[0]["PQGSL"].ToString().Trim() == "")
                        bjc_model.PQGSL = 0;
                    else
                        bjc_model.PQGSL = Convert.ToInt32(dt.Rows[0]["PQGSL"].ToString());
                    bjc_model.PFBZ = dt.Rows[0]["PFBZ"].ToString();
                    bjc_model.ZZCS = dt.Rows[0]["ZZCS"].ToString();
                    if (dt.Rows[0]["QGS"].ToString().Trim() == "")
                        bjc_model.QGS = 0;
                    else
                        bjc_model.QGS = Convert.ToInt32(dt.Rows[0]["QGS"].ToString());
                    //bjc_model.QGS = Convert.ToInt32(dt.Rows[0]["QGS"].ToString());
                    bjc_model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    bjc_model.QDLQY = dt.Rows[0]["QDLQY"].ToString();
                    bjc_model.JCYH = dt.Rows[0]["JCYH"].ToString();
                    if (dt.Rows[0]["DWS"].ToString().Trim() == "")
                        bjc_model.DWS = 0;
                    else
                        bjc_model.DWS = Convert.ToInt32(dt.Rows[0]["DWS"].ToString());
                    if (dt.Rows[0]["HDZK"].ToString().Trim() == "")
                        bjc_model.HDZK = 0;
                    else
                        bjc_model.HDZK = Convert.ToInt32(dt.Rows[0]["HDZK"].ToString());
                    if (dt.Rows[0]["JCRQ"].ToString().Trim() == "")
                        bjc_model.JCRQ =DateTime.Parse("1900-1-1"); 
                    else
                        bjc_model.JCRQ = (DateTime)dt.Rows[0]["JCRQ"];
                    bjc_model.JQXS = dt.Rows[0]["JQXS"].ToString();
                    //bjc_model.DWS = Convert.ToInt32(dt.Rows[0]["DWS"].ToString());
                    //bjc_model.HDZK = Convert.ToInt32(dt.Rows[0]["HDZK"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return bjc_model;
        }
        public BJCLXXB GetModel_by_jcclph(string jcclph)
        {

            string sql = "select * from BJCLXXB where jcclph=@jcclph";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcclph",jcclph)
                                  // new SqlParameter("@jccs",JCCS),
                               };
            DataTable dt = null;
            BJCLXXB bjc_model = new BJCLXXB();
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    bjc_model.JCBH = dt.Rows[0]["JCBH"].ToString();
                    bjc_model.PZLX = dt.Rows[0]["PZLX"].ToString();
                    bjc_model.JCCLPH = dt.Rows[0]["JCCLPH"].ToString();
                    bjc_model.CLXHBH = dt.Rows[0]["CLXHBH"].ToString();
                    if (dt.Rows[0]["JCCS"].ToString().Trim() == "")
                        bjc_model.JCCS = 0;
                    else
                        bjc_model.JCCS = Convert.ToInt32(dt.Rows[0]["JCCS"].ToString());
                    //bjc_model.JCCS = Convert.ToInt32(dt.Rows[0]["JCCS"].ToString());
                    //bjc_model.LSH = Convert.ToInt32(dt.Rows[0]["LSH"].ToString());
                    bjc_model.CCRQ = (DateTime)dt.Rows[0]["CCRQ"];
                    bjc_model.DJRQ = (DateTime)dt.Rows[0]["DJRQ"];
                    bjc_model.FDJH = dt.Rows[0]["FDJH"].ToString();
                    bjc_model.CJH = dt.Rows[0]["CJH"].ToString();
                    bjc_model.CZ = dt.Rows[0]["CZ"].ToString();
                    bjc_model.CZDH = dt.Rows[0]["CZDH"].ToString();
                    bjc_model.CZDZ = dt.Rows[0]["CZDZ"].ToString();
                    if (dt.Rows[0]["LCBDS"].ToString().Trim() == "")
                        bjc_model.LCBDS = 0;
                    else
                        bjc_model.LCBDS = Convert.ToInt32(dt.Rows[0]["LCBDS"].ToString());
                    //bjc_model.LCBDS = Convert.ToInt32(dt.Rows[0]["LCBDS"].ToString());
                    bjc_model.HBBZ = dt.Rows[0]["HBBZ"].ToString();
                    bjc_model.SYQK = dt.Rows[0]["SYQK"].ToString();
                    bjc_model.JCBJ = dt.Rows[0]["JCBJ"].ToString();
                    bjc_model.JCZT = dt.Rows[0]["JCZT"].ToString();
                    bjc_model.QRJCFF = dt.Rows[0]["QRJCFF"].ToString();
                    bjc_model.RYLX = dt.Rows[0]["RYLX"].ToString();
                    bjc_model.GYFF = dt.Rows[0]["GYFF"].ToString();
                    bjc_model.BSXLX = dt.Rows[0]["BSXLX"].ToString();
                    bjc_model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    bjc_model.ZBZL = dt.Rows[0]["ZBZL"].ToString();
                    bjc_model.ZDZZL = dt.Rows[0]["ZDZZL"].ToString();
                    bjc_model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    bjc_model.FDJSCS = dt.Rows[0]["FDJSCS"].ToString();
                    bjc_model.JCZH = dt.Rows[0]["JCZH"].ToString();
                    bjc_model.DCZZ = dt.Rows[0]["DCZZ"].ToString();
                    bjc_model.FDJEDGL = dt.Rows[0]["FDJEDGL"].ToString();
                    bjc_model.FDJEDZS = dt.Rows[0]["FDJEDZS"].ToString();
                    if (dt.Rows[0]["PQGSL"].ToString().Trim() == "")
                        bjc_model.PQGSL = 0;
                    else
                        bjc_model.PQGSL = Convert.ToInt32(dt.Rows[0]["PQGSL"].ToString());
                    bjc_model.PFBZ = dt.Rows[0]["PFBZ"].ToString();
                    bjc_model.ZZCS = dt.Rows[0]["ZZCS"].ToString();
                    if (dt.Rows[0]["QGS"].ToString().Trim() == "")
                        bjc_model.QGS = 0;
                    else
                        bjc_model.QGS = Convert.ToInt32(dt.Rows[0]["QGS"].ToString());
                    //bjc_model.QGS = Convert.ToInt32(dt.Rows[0]["QGS"].ToString());
                    bjc_model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    bjc_model.QDLQY = dt.Rows[0]["QDLQY"].ToString();
                    bjc_model.JCYH = dt.Rows[0]["JCYH"].ToString();
                    if (dt.Rows[0]["DWS"].ToString().Trim() == "")
                        bjc_model.DWS = 0;
                    else
                        bjc_model.DWS = Convert.ToInt32(dt.Rows[0]["DWS"].ToString());
                    if (dt.Rows[0]["HDZK"].ToString().Trim() == "")
                        bjc_model.HDZK = 0;
                    else
                        bjc_model.HDZK = Convert.ToInt32(dt.Rows[0]["HDZK"].ToString());
                    if (dt.Rows[0]["JCRQ"].ToString().Trim() == "")
                        bjc_model.JCRQ = DateTime.Parse("1900-1-1");
                    else
                        bjc_model.JCRQ = (DateTime)dt.Rows[0]["JCRQ"];
                    bjc_model.JQXS = dt.Rows[0]["JQXS"].ToString();
                    //bjc_model.DWS = Convert.ToInt32(dt.Rows[0]["DWS"].ToString());
                    //bjc_model.HDZK = Convert.ToInt32(dt.Rows[0]["HDZK"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return bjc_model;
        }
        /// <summary>
        /// 保存一条数据
        /// </summary>
      
        public bool Savedate(SYS.Model.BJCLXXB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BJCLXXB (");
            strSql.Append("PZLX,");//=@PZLX,");
            strSql.Append("JCBH,");//=@JCCLPH,");
            strSql.Append("CLXHBH,");//=@CLXHBH,");
            strSql.Append("JCCS,");//=@JCCS,");
            strSql.Append("CCRQ,");//=@CCRQ,");
            strSql.Append("DJRQ,");//=@DJRQ,"); 
            strSql.Append("FDJH,");//=@FDJH,");
            strSql.Append("CJH,");//=@CJH,");
            strSql.Append("CZ,");//=@CZ,");
            strSql.Append("CZDH,");//=@CZDH,");
            strSql.Append("CZDZ,");//=@CZDZ,");
            strSql.Append("LCBDS,");//=@LCBDS,");
            strSql.Append("HBBZ,");//=@HBBZ,");
            strSql.Append("SYQK,");//=@SYQK,");
            strSql.Append("JCBJ,");//=@JCBJ,");
            strSql.Append("JCZT,");//=@JCZT,");
            strSql.Append("QRJCFF,");//=@QRJCFF");
            strSql.Append("RYLX,");//=@RYLX,");
            strSql.Append("GYFF,");//=@GYFF,");
            strSql.Append("BSXLX,");//=@BSXLX,");
            strSql.Append("CLLX,");//=@CLLX,");
            strSql.Append("ZBZL,");//=@ZBZL,");
            strSql.Append("ZDZZL,");//=@ZDZZL,");
            strSql.Append("FDJPL,");//=@FDJPL,");
            strSql.Append("FDJSCS,");//=@FDJSCS,");
            strSql.Append("JCZH,");//=@JCZH,");
            strSql.Append("DCZZ,");//=@DCZZ,");
            strSql.Append("FDJEDGL,");//=@FDJEDGL,");
            strSql.Append("FDJEDZS,");//=@FDJEDZS,");
            strSql.Append("PQGSL,");//=@PQGSL,");
            strSql.Append("PFBZ,");//=@PFBZ,");
            strSql.Append("ZZCS,");//=@ZZCS,");
            strSql.Append("QGS,");//=@QGS,");
            strSql.Append("QDXS,");//=@QDXS");
            strSql.Append("QDLQY,");//=@QDLQY,");
            strSql.Append("JCYH,");//=@JCYH");
            strSql.Append("DWS,");//=@DWS");
            strSql.Append("HDZK,");//=@DWS");
            strSql.Append("JQXS,");//=@DWS");
            strSql.Append("JCCLPH)");//@JCBH and JCCS=@JCCS ");
            strSql.Append("values (@PZLX,@JCBH,@CLXHBH,@JCCS,@CCRQ,@DJRQ,@FDJH,@CJH,@CZ,@CZDH,@CZDZ,@LCBDS,@HBBZ,@SYQK,@JCBJ,@JCZT,@QRJCFF,@RYLX,@GYFF,@BSXLX,@CLLX,@ZBZL,@ZDZZL,@FDJPL,@FDJSCS,@JCZH,@DCZZ,@FDJEDGL,@FDJEDZS,@PQGSL,@PFBZ,@ZZCS,@QGS,@QDXS,@QDLQY,@JCYH,@DWS,@HDZK,@JQXS,@JCCLPH)");
            SqlParameter[] parameters = {
					new SqlParameter("@PZLX", SqlDbType.VarChar,32),
					new SqlParameter("@JCBH", SqlDbType.VarChar,16),
					new SqlParameter("@CLXHBH", SqlDbType.VarChar,32),
					new SqlParameter("@JCCS", SqlDbType.Int,4),
					new SqlParameter("@CCRQ", SqlDbType.DateTime),
                    new SqlParameter("@DJRQ", SqlDbType.DateTime),
					new SqlParameter("@FDJH", SqlDbType.VarChar,32),
					new SqlParameter("@CJH", SqlDbType.VarChar,32),
					new SqlParameter("@CZ", SqlDbType.VarChar,8),
					new SqlParameter("@CZDH", SqlDbType.VarChar,16),
					new SqlParameter("@CZDZ", SqlDbType.VarChar,32),
					new SqlParameter("@LCBDS", SqlDbType.Int,4),
					new SqlParameter("@HBBZ", SqlDbType.VarChar,4),
					new SqlParameter("@SYQK", SqlDbType.VarChar,4),
                    new SqlParameter("@JCBJ", SqlDbType.VarChar,32),
                    new SqlParameter("@JCZT", SqlDbType.VarChar,128),
                    new SqlParameter("@QRJCFF", SqlDbType.VarChar,128),
                    new SqlParameter("@RYLX", SqlDbType.VarChar,128),
					new SqlParameter("@GYFF", SqlDbType.VarChar,128),
					new SqlParameter("@BSXLX", SqlDbType.VarChar,128),
					new SqlParameter("@CLLX", SqlDbType.VarChar,128),
					new SqlParameter("@ZBZL", SqlDbType.VarChar,32),
					new SqlParameter("@ZDZZL", SqlDbType.VarChar,32),
					new SqlParameter("@FDJPL", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJSCS", SqlDbType.VarChar,32),
                    new SqlParameter("@JCZH", SqlDbType.VarChar,32),
                    new SqlParameter("@DCZZ", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJEDGL", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJEDZS", SqlDbType.VarChar,32),
					new SqlParameter("@PQGSL", SqlDbType.Int,4),
					new SqlParameter("@PFBZ", SqlDbType.VarChar,32),
					new SqlParameter("@ZZCS", SqlDbType.VarChar,32),
					new SqlParameter("@QGS", SqlDbType.Int,4),
					new SqlParameter("@QDXS", SqlDbType.VarChar,32),
					new SqlParameter("@QDLQY", SqlDbType.VarChar,32),
                    new SqlParameter("@JCYH", SqlDbType.VarChar,32),
                    new SqlParameter("@DWS", SqlDbType.Int,4),
                    new SqlParameter("@HDZK", SqlDbType.Int,4),
                    new SqlParameter("@JQXS", SqlDbType.VarChar,32),
					new SqlParameter("@JCCLPH", SqlDbType.VarChar,32)};
            parameters[0].Value = model.PZLX;
            parameters[1].Value = model.JCBH;
            parameters[2].Value = model.CLXHBH;
            parameters[3].Value = model.JCCS;
            parameters[4].Value = model.CCRQ;
            parameters[5].Value = model.DJRQ;
            parameters[6].Value = model.FDJH;
            parameters[7].Value = model.CJH;
            parameters[8].Value = model.CZ;
            parameters[9].Value = model.CZDH;
            parameters[10].Value = model.CZDZ;
            parameters[11].Value = model.LCBDS;
            parameters[12].Value = model.HBBZ;
            parameters[13].Value = model.SYQK;
            parameters[14].Value = model.JCBJ;
            parameters[15].Value = model.JCZT;
            parameters[16].Value = model.QRJCFF;
            parameters[17].Value = model.RYLX;
            parameters[18].Value = model.GYFF;
            parameters[19].Value = model.BSXLX;
            parameters[20].Value = model.CLLX;
            parameters[21].Value = model.ZBZL;
            parameters[22].Value = model.ZDZZL;
            parameters[23].Value = model.FDJPL;
            parameters[24].Value = model.FDJSCS;
            parameters[25].Value = model.JCZH;
            parameters[26].Value = model.DCZZ;
            parameters[27].Value = model.FDJEDGL;
            parameters[28].Value = model.FDJEDZS;
            parameters[29].Value = model.PQGSL;
            parameters[30].Value = model.PFBZ;
            parameters[31].Value = model.ZZCS;
            parameters[32].Value = model.QGS;
            parameters[33].Value = model.QDXS;
            parameters[34].Value = model.QDLQY;
            parameters[35].Value = model.JCYH;
            parameters[36].Value = model.DWS;
            parameters[37].Value = model.HDZK;
            parameters[38].Value = model.JQXS;
            parameters[39].Value = model.JCCLPH;
            try
            {
                if (Have_BjclInDaijian(model.JCCLPH))
                {
                    if (Update(model))
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
        #region 用车牌号检测该车的信息是否已经存在
        /// <summary>
        /// 用车牌号检测该车的信息是否已经存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_Bjcl(string jcclph)
        {
            string sql = "select * from BJCLXXB where JCCLPH=@jcclph";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcclph",jcclph)
                               };
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text, spr).Rows.Count > 0)
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
        #region 用车牌号检测该车是否已经在待检序列中
        /// <summary>
        /// 用车牌号检测该车的信息是否已经存在
        /// </summary>
        /// <param name="jcbh">汽车车牌</param>
        /// <param name="jccs">检测线编号</param>
        /// <returns>bool</returns>
        public bool Have_BjclInDaijian(string jcclph)
        {
            string sql = "select * from BJCLXXB where JCCLPH=@jcclph and (JCBJ>'0' or JCBJ='-1' or JCBJ='9999')";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcclph",jcclph)
                               };
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text, spr).Rows.Count > 0)
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SYS.Model.BJCLXXB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BJCLXXB set ");
            strSql.Append("PZLX=@PZLX,");
            strSql.Append("CLXHBH=@CLXHBH,");
            strSql.Append("JCCS=@JCCS,");
            strSql.Append("CCRQ=@CCRQ,");
            strSql.Append("DJRQ=@DJRQ,");
            strSql.Append("FDJH=@FDJH,");
            strSql.Append("CJH=@CJH,");
            strSql.Append("CZ=@CZ,");
            strSql.Append("CZDH=@CZDH,");
            strSql.Append("CZDZ=@CZDZ,");
            strSql.Append("LCBDS=@LCBDS,");
            strSql.Append("HBBZ=@HBBZ,");
            strSql.Append("SYQK=@SYQK,");
            strSql.Append("JCBJ=@JCBJ,");
            strSql.Append("JCZT=@JCZT,");
            strSql.Append("QRJCFF=@QRJCFF,");
            strSql.Append("RYLX=@RYLX,");
            strSql.Append("GYFF=@GYFF,");
            strSql.Append("BSXLX=@BSXLX,");
            strSql.Append("CLLX=@CLLX,");
            strSql.Append("ZBZL=@ZBZL,");
            strSql.Append("ZDZZL=@ZDZZL,");
            strSql.Append("FDJPL=@FDJPL,");
            strSql.Append("FDJSCS=@FDJSCS,");
            strSql.Append("JCZH=@JCZH,");
            strSql.Append("DCZZ=@DCZZ,");
            strSql.Append("FDJEDGL=@FDJEDGL,");
            strSql.Append("FDJEDZS=@FDJEDZS,");
            strSql.Append("PQGSL=@PQGSL,");
            strSql.Append("PFBZ=@PFBZ,");
            strSql.Append("ZZCS=@ZZCS,");
            strSql.Append("QGS=@QGS,");
            strSql.Append("QDXS=@QDXS,");
            strSql.Append("QDLQY=@QDLQY,");
            strSql.Append("JCYH=@JCYH,");
            strSql.Append("DWS=@DWS,");
            strSql.Append("HDZK=@HDZK,");
            strSql.Append("JQXS=@JQXS");
            strSql.Append(" where JCCLPH=@JCCLPH");
            SqlParameter[] parameters = {
					new SqlParameter("@PZLX", SqlDbType.VarChar,32),
					new SqlParameter("@CLXHBH", SqlDbType.VarChar,32),
					new SqlParameter("@JCCS", SqlDbType.Int,4),
					new SqlParameter("@CCRQ", SqlDbType.DateTime),
                    new SqlParameter("@DJRQ", SqlDbType.DateTime),
					new SqlParameter("@FDJH", SqlDbType.VarChar,32),
					new SqlParameter("@CJH", SqlDbType.VarChar,32),
					new SqlParameter("@CZ", SqlDbType.VarChar,32),
					new SqlParameter("@CZDH", SqlDbType.VarChar,32),
					new SqlParameter("@CZDZ", SqlDbType.VarChar,32),
					new SqlParameter("@LCBDS", SqlDbType.Int,32),
					new SqlParameter("@HBBZ", SqlDbType.VarChar,32),
					new SqlParameter("@SYQK", SqlDbType.VarChar,32),
                    new SqlParameter("@JCBJ", SqlDbType.VarChar,32),
                    new SqlParameter("@JCZT", SqlDbType.VarChar,128),
                    new SqlParameter("@QRJCFF", SqlDbType.VarChar,128),
                    new SqlParameter("@RYLX", SqlDbType.VarChar,128),
					new SqlParameter("@GYFF", SqlDbType.VarChar,128),
					new SqlParameter("@BSXLX", SqlDbType.VarChar,128),
					new SqlParameter("@CLLX", SqlDbType.VarChar,128),
					new SqlParameter("@ZBZL", SqlDbType.VarChar,32),
					new SqlParameter("@ZDZZL", SqlDbType.VarChar,32),
					new SqlParameter("@FDJPL", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJSCS", SqlDbType.VarChar,32),
                    new SqlParameter("@JCZH", SqlDbType.VarChar,32),
                    new SqlParameter("@DCZZ", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJEDGL", SqlDbType.VarChar,32),
                    new SqlParameter("@FDJEDZS", SqlDbType.VarChar,32),
					new SqlParameter("@PQGSL", SqlDbType.Int,4),
					new SqlParameter("@PFBZ", SqlDbType.VarChar,32),
					new SqlParameter("@ZZCS", SqlDbType.VarChar,32),
					new SqlParameter("@QGS", SqlDbType.Int,4),
					new SqlParameter("@QDXS", SqlDbType.VarChar,32),
					new SqlParameter("@QDLQY", SqlDbType.VarChar,32),
                    new SqlParameter("@JCYH", SqlDbType.VarChar,32),
                    new SqlParameter("@DWS", SqlDbType.Int,4),
                    new SqlParameter("@HDZK", SqlDbType.Int,4),
                    new SqlParameter("@JQXS", SqlDbType.VarChar,32),
                    new SqlParameter("@JCCLPH", SqlDbType.VarChar,32)};
            parameters[0].Value = model.PZLX;
            //parameters[1].Value = model.JCBH;
            parameters[1].Value = model.CLXHBH;
            parameters[2].Value = model.JCCS;
            parameters[3].Value = model.CCRQ;
            parameters[4].Value = model.DJRQ;
            parameters[5].Value = model.FDJH;
            parameters[6].Value = model.CJH;
            parameters[7].Value = model.CZ;
            parameters[8].Value = model.CZDH;
            parameters[9].Value = model.CZDZ;
            parameters[10].Value = model.LCBDS;
            parameters[11].Value = model.HBBZ;
            parameters[12].Value = model.SYQK;
            parameters[13].Value = model.JCBJ;
            parameters[14].Value = model.JCZT;
            parameters[15].Value = model.QRJCFF;
            parameters[16].Value = model.RYLX;
            parameters[17].Value = model.GYFF;
            parameters[18].Value = model.BSXLX;
            parameters[19].Value = model.CLLX;
            parameters[20].Value = model.ZBZL;
            parameters[21].Value = model.ZDZZL;
            parameters[22].Value = model.FDJPL;
            parameters[23].Value = model.FDJSCS;
            parameters[24].Value = model.JCZH;
            parameters[25].Value = model.DCZZ;
            parameters[26].Value = model.FDJEDGL;
            parameters[27].Value = model.FDJEDZS;
            parameters[28].Value = model.PQGSL;
            parameters[29].Value = model.PFBZ;
            parameters[30].Value = model.ZZCS;
            parameters[31].Value = model.QGS;
            parameters[32].Value = model.QDXS;
            parameters[33].Value = model.QDLQY;
            parameters[34].Value = model.JCYH;
            parameters[35].Value = model.DWS;
            parameters[36].Value = model.HDZK;
            parameters[37].Value = model.JQXS;
            parameters[38].Value = model.JCCLPH;
            try
            {
                int rows = DBHelperSQL.Execute(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region 用检测线编号得到准备检测车辆
        /// <summary>
        /// 得到准备检测车辆
        /// </summary>
        /// <param name="bjbh">本线编号</param>
        /// <returns>datatable</returns>
        public DataTable getCarWait(string bjbh)
        {
            //string sql = "select BJCLXXB.*,clxhxxb.jcff from BJCLXXB left join clxhxxb on clxhxxb.clxhbh=bjclxxb.clxhbh where JCBJ ='9999' or JCBJ='-1' or JCBJ=@bjbh  ORDER BY JCBJ";
            string sql = "select BJCLXXB.* from BJCLXXB where JCBJ ='9999' or JCBJ='-1' or JCBJ=@bjbh  ORDER BY JCBJ";
            SqlParameter[] spr ={
                                   new SqlParameter("@bjbh",bjbh)
                               };
            try
            {
                DataTable ds = new DataTable();
                ds = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        

        /// <summary>
        /// 得到一个准备检测车辆的对象实体
        /// </summary>
        public BJCLXXB GetBjCarModel(string ip)
        {

            StringBuilder strSql = new StringBuilder();
            string sql = "select  top 1 JCBH,PZLX,JCCLPH,CLXHBH,JCCS,CCRQ,FDJH,CJH,CZ,CZDH,CZDZ,LCBDS,HBBZ,SYQK,JCBJ,JCZT from BJCLXXB where JCBH=(select min(JCBH)  from BJCLXXB where JCBJ in (select JCXBH from JCXXXB where GYJSJIP="+"'"+ip+"'))";
         
            BJCLXXB model = new BJCLXXB();
            DataTable ds = DBHelperSQL.GetDataTable(sql);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["JCBH"] != null && ds.Rows[0]["JCBH"].ToString() != "")
                {
                    model.JCBH = ds.Rows[0]["JCBH"].ToString();
                }
                if (ds.Rows[0]["PZLX"] != null && ds.Rows[0]["PZLX"].ToString() != "")
                {
                    model.PZLX = ds.Rows[0]["PZLX"].ToString();
                }
                if (ds.Rows[0]["JCCLPH"] != null && ds.Rows[0]["JCCLPH"].ToString() != "")
                {
                    model.JCCLPH = ds.Rows[0]["JCCLPH"].ToString();
                }
                if (ds.Rows[0]["CLXHBH"] != null && ds.Rows[0]["CLXHBH"].ToString() != "")
                {
                    model.CLXHBH =ds.Rows[0]["CLXHBH"].ToString();
                }
                if (ds.Rows[0]["JCCS"] != null && ds.Rows[0]["JCCS"].ToString() != "")
                {
                    model.JCCS = int.Parse(ds.Rows[0]["JCCS"].ToString());
                }
                if (ds.Rows[0]["LSH"] != null && ds.Rows[0]["JCCS"].ToString() != "")
                {
                    model.LSH = int.Parse(ds.Rows[0]["LSH"].ToString());
                }
                if (ds.Rows[0]["CCRQ"] != null && ds.Rows[0]["CCRQ"].ToString() != "")
                {
                    model.CCRQ = DateTime.Parse(ds.Rows[0]["CCRQ"].ToString());
                }
                if (ds.Rows[0]["FDJH"] != null && ds.Rows[0]["FDJH"].ToString() != "")
                {
                    model.FDJH = ds.Rows[0]["FDJH"].ToString();
                }
                if (ds.Rows[0]["CJH"] != null && ds.Rows[0]["CJH"].ToString() != "")
                {
                    model.CJH = ds.Rows[0]["CJH"].ToString();
                }
                if (ds.Rows[0]["CZ"] != null && ds.Rows[0]["CZ"].ToString() != "")
                {
                    model.CZ = ds.Rows[0]["CZ"].ToString();
                }
                if (ds.Rows[0]["CZDH"] != null && ds.Rows[0]["CZDH"].ToString() != "")
                {
                    model.CZDH = ds.Rows[0]["CZDH"].ToString();
                }
                if (ds.Rows[0]["CZDZ"] != null && ds.Rows[0]["CZDZ"].ToString() != "")
                {
                    model.CZDZ = ds.Rows[0]["CZDZ"].ToString();
                }
                if (ds.Rows[0]["LCBDS"] != null && ds.Rows[0]["LCBDS"].ToString() != "")
                {
                    model.LCBDS = int.Parse(ds.Rows[0]["LCBDS"].ToString());
                }
                if (ds.Rows[0]["HBBZ"] != null && ds.Rows[0]["HBBZ"].ToString() != "")
                {
                    model.HBBZ = ds.Rows[0]["HBBZ"].ToString();
                }
                if (ds.Rows[0]["SYQK"] != null && ds.Rows[0]["SYQK"].ToString() != "")
                {
                    model.SYQK = ds.Rows[0]["SYQK"].ToString();
                }
                if (ds.Rows[0]["JCBJ"] != null && ds.Rows[0]["JCBJ"].ToString() != "")
                {
                    model.JCBJ = ds.Rows[0]["JCBJ"].ToString();
                }
                if (ds.Rows[0]["JCZT"] != null && ds.Rows[0]["JCZT"].ToString() != "")
                {
                    model.JCZT = ds.Rows[0]["JCZT"].ToString();
                }
                if (ds.Rows[0]["QRJCFF"] != null && ds.Rows[0]["QRJCFF"].ToString() != "")
                {
                    model.QRJCFF = ds.Rows[0]["QRJCFF"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改检测状态
        /// </summary>
        public int updateJcZt(string jcbh, string jczt)
        {
            string sql = "update BJCLXXB set JCZT=" + "'" + jczt + "'" + " where JCBH=" + "'" + jcbh + "'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }

        /// <summary>
        /// 检测完毕 修改检测次数和 检测标记
        /// </summary>
        public int updateJcXx(string jcbh,int jccs,string jczt)
        {
            string sql = "update BJCLXXB set JCCS="+(jccs+1)+",JCZT="+"'"+jczt+"'"+", JCBJ=0 where JCBH=" + "'"+jcbh+"'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }
        public int updateJcFf(string jcbh,string jcff)
        {
            string sql = "update BJCLXXB set QRJCFF=" + "'" + jcff + "'" + " where JCBH=" + "'" + jcbh + "'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }
        public int updateJcrq(string jcbh, string jcrq)
        {
            string sql = "update BJCLXXB set JCRQ=" + "'" + jcrq + "'" + " where JCBH=" + "'" + jcbh + "'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }
        #region 用检测编号获取检测车辆的所有信息包括车辆型号信息
        /// <summary>
        /// 用检测编号获取检测车辆的所有信息包括车辆型号信息
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>DataTable</returns>
        public DataTable Get_Carxx(string jcbh)
        {
            DataTable dt = new DataTable();
            string sql = "select * from BJCLXXB where JCBH=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh),
                               };
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 用车牌号获取检测车辆的所有信息包括车辆型号信息
        /// <summary>
        /// 用检测编号获取检测车辆的所有信息包括车辆型号信息
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>DataTable</returns>
        public DataTable Get_Carxx_byph(string jcclph)
        {
            DataTable dt = new DataTable();
            string sql = "select * from BJCLXXB where JCCLPH=@jcclph";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcclph",jcclph),
                               };
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 用车牌号删除该车辆信息
        /// <summary>
        /// 用车牌号删除该车辆信息
        /// </summary>
        /// <param name="jcbh">汽车车牌</param>
        /// <returns>bool</returns>
        public bool deleteThisCar(string jcclph)
        {
            string sql = "delete from BJCLXXB where JCCLPH=" + "'" + jcclph + "'" + " and (JCBJ>'0' or JCBJ='-1' or JCBJ='9999')";
            try
            {
                if (DBHelperSQL.Execute(sql) > 0)
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
    }


}
