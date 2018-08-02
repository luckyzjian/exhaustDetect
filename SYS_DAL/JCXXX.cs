using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYS_DAL;
using SYS.Model;
using System.Data.SqlClient;
using System.Data;
using SYS;

namespace SYS_DAL
{
    public partial class JCXXX
    {
        #region 用本机IP获取本检测线信息
        /// <summary>
        /// 用本机IP获取本检测线信息
        /// </summary>
        /// <param name="IP">本机IP</param>
        /// <returns>JCXXXB Model</returns>
        public JCXXXB GetModel(string IP)
        {
            JCXXXB model = new JCXXXB();
            string sql = "select * from JCXXXB where GYJSJIP=@ip";
            SqlParameter[] spr ={
                                    new SqlParameter("@ip",IP)
                                };
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {

                    model.JCXBH = dt.Rows[0]["JCXBH"].ToString();
                    model.GYJSJIP = dt.Rows[0]["GYJSJIP"].ToString();
                    model.JCXMC = dt.Rows[0]["JCXMC"].ToString();
                    model.JCFFLX = int.Parse(dt.Rows[0]["JCFFLX"].ToString());
                    model.DPCGJBH = int.Parse(dt.Rows[0]["DPCGJBH"].ToString());
                    int a;
                    int.TryParse(dt.Rows[0]["FQFXYBH"].ToString(), out a);
                    model.FQFXYBH = a;
                    int b;
                    int.TryParse(dt.Rows[0]["BTGYDJBH"].ToString(), out b);
                    model.BTGYDJBH = b;
                    int c;
                    int.TryParse(dt.Rows[0]["LLJBH"].ToString(), out c);
                    model.LLJBH = c;
                    int d;
                    int.TryParse(dt.Rows[0]["HJZBH"].ToString(), out d);
                    model.HJZBH = d;
                    int e;
                    int.TryParse(dt.Rows[0]["PCBH"].ToString(), out e);
                    model.PCBH = e;
                    model.WYZSBBH = int.Parse(dt.Rows[0]["WYZSBBH"].ToString());
                    model.QTLLFXYBH = int.Parse(dt.Rows[0]["QTLLFXYBH"].ToString());
                    model.LEDDPBH = int.Parse(dt.Rows[0]["LEDDPBH"].ToString());
                    model.LJSYS = int.Parse(dt.Rows[0]["LJSYS"].ToString());
                    model.DPCGJPZ = dt.Rows[0]["DPCGJPZ"].ToString();
                    model.FQFXYPZ = dt.Rows[0]["FQFXYPZ"].ToString();
                    model.BTGYDJPZ = dt.Rows[0]["BTGYDJPZ"].ToString();
                    model.LLJPZ = dt.Rows[0]["LLJPZ"].ToString();
                    model.LEDPZ = dt.Rows[0]["LEDPZ"].ToString();
                    model.RZBH = dt.Rows[0]["RZBH"].ToString();
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.ZZCS = dt.Rows[0]["ZZCS"].ToString();
                }
                else
                    model.JCXBH = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 修改检测线的累计试验数(IP,累计试验次数)
        /// <summary>
        /// 修改检测线的累计试验数
        /// </summary>
        public int updateJcxLjsycs(string IP, int ljsycs)
        {
            string sql = "update JCXXXB set LJSYS=" + "'" + ljsycs + "'" + " where GYJSJIP=" + "'" + IP + "'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }
        #endregion
        #region 修改检测线的IP地址(IP,新的IP)
        /// <summary>
        /// 修改检测线的IP地址
        /// </summary>
        public int updateJcxLjsycs(string IP, string newIP)
        {
            string sql = "update JCXXXB set GYJSJIP=" + "'" + newIP + "'" + " where GYJSJIP=" + "'" + IP + "'";
            int rows = DBHelperSQL.Execute(sql);
            return rows;

        }
        #endregion
        #region 修改检测线的设备接口配置(IP,测功机配置，废气分析仪配置，不透光烟度计配置，流量计配置)
        /// <summary>
        /// 修改检测线的设备接口配置
        /// </summary>
        public int updateJcxSerialConfig(string IP, string dpcgjpz, string fqfxypz, string btgydjpz, string lljpz)
        {
            string sql = "update JCXXXB set DPCGJPZ=@DPCGJPZ,FQFXYPZ=@FQFXYPZ,BTGYDJPZ=@BTGYDJPZ,LLJPZ=@LLJPZ" + " where GYJSJIP=" + "'" + IP + "'";
            SqlParameter[] spr ={
                                   new SqlParameter("@DPCGJPZ",dpcgjpz), 
                                   new SqlParameter("@FQFXYPZ",fqfxypz),
                                   new SqlParameter("@BTGYDJPZ",btgydjpz),
                                   new SqlParameter("@LLJPZ",lljpz)
                                };
            int rows = DBHelperSQL.Execute(sql, spr);
            return rows;
        }
        #endregion
        #region 获取所有检测线的信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllJiancexian()
        {
            string sql = "select * from JCXXXB";
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
        #region 根据检测线名称来获取检测线编号
        public string Get_jcxbh_by_jcxmc(string jcxmc)
        {
            string sql = "select * from JCXXXB where JCXMC=@jcxmc";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcxmc",jcxmc)
                               };
            try
            {
                SYS.Model.JCXXXB sb = new SYS.Model.JCXXXB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.JCXBH = dt.Rows[0]["JCXBH"].ToString();
                }
                return sb.JCXBH;
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
        public bool AddLine(SYS.Model.JCXXXB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JCXXXB (");
            strSql.Append("JCXBH,");//=@PZLX,");
            strSql.Append("GYJSJIP,");//=@JCCLPH,");
            strSql.Append("JCXMC,");//=@CLXHBH,");
            strSql.Append("JCFFLX,");//=@JCCS,");
            strSql.Append("DPCGJBH,");//=@CCRQ,");
            strSql.Append("FQFXYBH,");//=@DJRQ,"); 
            strSql.Append("BTGYDJBH,");//=@FDJH,");
            strSql.Append("WYZSBBH,");//=@CJH,");
            strSql.Append("QTLLFXYBH,");//=@CZ,");
            strSql.Append("LEDDPBH,");//=@CZDH,");
            strSql.Append("LEDPZ,");//=@CZDH,");
            strSql.Append("XH,");//=@CZDZ,");
            strSql.Append("RZBH,");//=@LCBDS,");
            strSql.Append("ZZCS,");//=@HBBZ,");
            strSql.Append("LLJBH,");//=@SYQK,");
            strSql.Append("LJSYS)");
            strSql.Append("values (@JCXBH,@GYJSJIP,@JCXMC,@JCFFLX,@DPCGJBH,@FQFXYBH,@BTGYDJBH,@WYZSBBH,@QTLLFXYBH,@LEDDPBH,@LEDPZ,@XH,@RZBH,@ZZCS,@LLJBH,@LJSYS)");
            SqlParameter[] parameters = {
					new SqlParameter("@JCXBH", SqlDbType.VarChar,32),
					new SqlParameter("@GYJSJIP", SqlDbType.VarChar,16),
					new SqlParameter("@JCXMC", SqlDbType.VarChar,64),
					new SqlParameter("@JCFFLX", SqlDbType.Int,4),
					new SqlParameter("@DPCGJBH", SqlDbType.Int,4),
                    new SqlParameter("@FQFXYBH", SqlDbType.Int,4),
					new SqlParameter("@BTGYDJBH", SqlDbType.Int,4),
					new SqlParameter("@WYZSBBH", SqlDbType.Int,4),
					new SqlParameter("@QTLLFXYBH", SqlDbType.Int,4),
					new SqlParameter("@LEDDPBH", SqlDbType.Int,4),
                    new SqlParameter("@LEDPZ", SqlDbType.VarChar,32),
					new SqlParameter("@XH", SqlDbType.VarChar,32),
					new SqlParameter("@RZBH", SqlDbType.VarChar,64),
					new SqlParameter("@ZZCS", SqlDbType.VarChar,64),
					new SqlParameter("@LLJBH", SqlDbType.Int,4),
                    new SqlParameter("@LJSYS", SqlDbType.Int,4)
                    };
            parameters[0].Value = model.JCXBH;
            parameters[1].Value = model.GYJSJIP;
            parameters[2].Value = model.JCXMC;
            parameters[3].Value = model.JCFFLX;
            parameters[4].Value = model.DPCGJBH;
            parameters[5].Value = model.FQFXYBH;
            parameters[6].Value = model.BTGYDJBH;
            parameters[7].Value = model.WYZSBBH;
            parameters[8].Value = model.QTLLFXYBH;
            parameters[9].Value = model.LEDDPBH;
            parameters[10].Value = model.LEDPZ;
            parameters[11].Value = model.XH;
            parameters[12].Value = model.RZBH;
            parameters[13].Value = model.ZZCS;
            parameters[14].Value = model.LLJBH;
            parameters[15].Value = model.LJSYS;
            try
            {
                if (Have_ThisLine(model.JCXBH, model.JCXMC, model.GYJSJIP))
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
        #region 用检测线编号删除该检测线
        /// <summary>
        /// 用检测线编号删除该检测线
        /// </summary>
        /// <param name="jcbh">检测线编号</param>
        /// <returns>bool</returns>
        public bool deleteThisLine(string jcxbh)
        {
            string sql = "delete from JCXXXB where JCXBH=" + "'" + jcxbh + "'";
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
        #region 用检测线编号查询该检测线是否存在
        /// <summary>
        /// 用检测线编号查询该检测线是否存在
        /// </summary>
        /// <param name="jccs">检测线编号</param>
        /// <returns>bool</returns>
        public bool Have_ThisLine(string jcxbh, string jcxmc, string gyjsjip)
        {
            string sql = "select * from JCXXXB where jcxbh=@jcxbh or jcxmc=@jcxmc or gyjsjip=@gyjsjip";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcxbh",jcxbh),
                                   new SqlParameter("@jcxmc",jcxmc),
                                   new SqlParameter("@gyjsjip",gyjsjip),
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
        #region 用检测线编号获取该检测线信息
        public JCXXXB GetModelbyJcxbh(string JCXBH)
        {
            JCXXXB model = new JCXXXB();
            string sql = "select * from JCXXXB where JCXBH=@JCXBH";
            SqlParameter[] spr ={
                                    new SqlParameter("@JCXBH",JCXBH)
                                };
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {

                    model.JCXBH = dt.Rows[0]["JCXBH"].ToString();
                    model.GYJSJIP = dt.Rows[0]["GYJSJIP"].ToString();
                    model.JCXMC = dt.Rows[0]["JCXMC"].ToString();
                    model.JCFFLX = int.Parse(dt.Rows[0]["JCFFLX"].ToString());
                    model.DPCGJBH = int.Parse(dt.Rows[0]["DPCGJBH"].ToString());
                    int a;
                    int.TryParse(dt.Rows[0]["FQFXYBH"].ToString(), out a);
                    model.FQFXYBH = a;
                    int b;
                    int.TryParse(dt.Rows[0]["BTGYDJBH"].ToString(), out b);
                    model.BTGYDJBH = b;
                    int c;
                    int.TryParse(dt.Rows[0]["LLJBH"].ToString(), out c);
                    model.LLJBH = c;
                    if (int.TryParse(dt.Rows[0]["WYZSBBH"].ToString(), out c))
                        model.WYZSBBH = c;
                    if (int.TryParse(dt.Rows[0]["QTLLFXYBH"].ToString(), out c))
                        model.QTLLFXYBH = c;
                    if (int.TryParse(dt.Rows[0]["LEDDPBH"].ToString(), out c))
                        model.LEDDPBH = c;
                    if (int.TryParse(dt.Rows[0]["LJSYS"].ToString(), out c))
                        model.LJSYS = c;
                    if (int.TryParse(dt.Rows[0]["PCBH"].ToString(), out c))
                        model.PCBH = c;
                    if (int.TryParse(dt.Rows[0]["HJZBH"].ToString(), out c))
                        model.HJZBH = c;
                    model.ZZCS = dt.Rows[0]["ZZCS"].ToString();
                    model.RZBH = dt.Rows[0]["RZBH"].ToString();
                    model.DPCGJPZ = dt.Rows[0]["DPCGJPZ"].ToString();
                    model.FQFXYPZ = dt.Rows[0]["FQFXYPZ"].ToString();
                    model.BTGYDJPZ = dt.Rows[0]["BTGYDJPZ"].ToString();
                    model.LLJPZ = dt.Rows[0]["LLJPZ"].ToString();
                    model.XH = dt.Rows[0]["XH"].ToString();

                }
                else
                    model.JCXBH = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SYS.Model.JCXXXB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JCXXXB set");
            //strSql.Append("JCXBH=@JCXBH,");
            strSql.Append(" GYJSJIP=@GYJSJIP,");
            strSql.Append("JCXMC=@JCXMC,");
            strSql.Append("JCFFLX=@JCFFLX,");
            strSql.Append("DPCGJBH=@DPCGJBH,");
            strSql.Append("FQFXYBH=@FQFXYBH,");
            strSql.Append("BTGYDJBH=@BTGYDJBH,");
            strSql.Append("WYZSBBH=@WYZSBBH,");
            strSql.Append("QTLLFXYBH=@QTLLFXYBH,");
            strSql.Append("LEDDPBH=@LEDDPBH,");
            strSql.Append("LEDPZ=@LEDPZ,");
            strSql.Append("XH=@XH,");
            strSql.Append("RZBH=@RZBH,");
            strSql.Append("ZZCS=@ZZCS,");
            strSql.Append("LLJBH=@LLJBH,");
            strSql.Append("DPCGJPZ=@DPCGJPZ,");
            strSql.Append("FQFXYPZ=@FQFXYPZ,");
            strSql.Append("BTGYDJPZ=@BTGYDJPZ,");
            strSql.Append("LLJPZ=@LLJPZ,");
            strSql.Append("PCBH=@PCBH,");
            strSql.Append("HJZBH=@HJZBH ");
            //strSql.Append("LJSYS=@LJSYS");//更新时不改变累计试验数
            strSql.Append(" where JCXBH=@JCXBH");
            //strSql.Append("values (@JCXBH,@GYJSJIP,@JCXMC,@JCFFLX,@DPCGJBH,@FQFXYBH,@BTGYDJBH,@WYZSBBH,@QTLLFXYBH,@LEDDPBH,@XH,@RZBH,@ZZCS,@LLJBH,@LJSYS)");
            SqlParameter[] parameters = {
					//new SqlParameter("@JCXBH", SqlDbType.VarChar,32),
					new SqlParameter("@GYJSJIP", SqlDbType.VarChar,16),
					new SqlParameter("@JCXMC", SqlDbType.VarChar,64),
					new SqlParameter("@JCFFLX", SqlDbType.Int,4),
					new SqlParameter("@DPCGJBH", SqlDbType.Int,4),
                    new SqlParameter("@FQFXYBH", SqlDbType.Int,4),
					new SqlParameter("@BTGYDJBH", SqlDbType.Int,4),
					new SqlParameter("@WYZSBBH", SqlDbType.Int,4),
					new SqlParameter("@QTLLFXYBH", SqlDbType.Int,4),
					new SqlParameter("@LEDDPBH", SqlDbType.Int,4),
                    new SqlParameter("@LEDPZ", SqlDbType.VarChar,32),
					new SqlParameter("@XH", SqlDbType.VarChar,32),
					new SqlParameter("@RZBH", SqlDbType.VarChar,64),
					new SqlParameter("@ZZCS", SqlDbType.VarChar,64),
					new SqlParameter("@LLJBH", SqlDbType.Int,4),
                    new SqlParameter("@DPCGJPZ", SqlDbType.VarChar,64),
                    new SqlParameter("@FQFXYPZ", SqlDbType.VarChar,64),
                    new SqlParameter("@BTGYDJPZ", SqlDbType.VarChar,64),
                    new SqlParameter("@LLJPZ", SqlDbType.VarChar,64),
                    new SqlParameter("@PCBH", SqlDbType.Int,4),
                    new SqlParameter("@HJZBH", SqlDbType.Int,4),
                    //new SqlParameter("@LJSYS", SqlDbType.Int,4),
                    new SqlParameter("@JCXBH", SqlDbType.VarChar,32)
                    };
            //parameters[0].Value = model.JCXBH;
            parameters[0].Value = model.GYJSJIP;
            parameters[1].Value = model.JCXMC;
            parameters[2].Value = model.JCFFLX;
            parameters[3].Value = model.DPCGJBH;
            parameters[4].Value = model.FQFXYBH;
            parameters[5].Value = model.BTGYDJBH;
            parameters[6].Value = model.WYZSBBH;
            parameters[7].Value = model.QTLLFXYBH;
            parameters[8].Value = model.LEDDPBH;
            parameters[9].Value = model.LEDPZ;
            parameters[10].Value = model.XH;
            parameters[11].Value = model.RZBH;
            parameters[12].Value = model.ZZCS;
            parameters[13].Value = model.LLJBH;
            parameters[14].Value = model.DPCGJPZ;
            parameters[15].Value = model.FQFXYPZ;
            parameters[16].Value = model.BTGYDJPZ;
            parameters[17].Value = model.LLJPZ;
            parameters[18].Value = model.PCBH;
            parameters[19].Value = model.HJZBH;
            //parameters[14].Value = model.LJSYS;
            parameters[20].Value = model.JCXBH;
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
    }
}


