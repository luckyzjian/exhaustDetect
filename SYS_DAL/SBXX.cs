using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SYS_DAL
{
    public class SBXX
    {
        #region 用设备编号获取设备信息
        /// <summary>
        /// 用设备编号获取设备信息
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>DataTable</returns>
        public SYS.Model.SBXXB Get_sb_by_bh(int sbbh)
        {
            string sql = "select * from sbxxb where sbbh=@sbbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbbh",sbbh)
                               };
            try
            {
                SYS.Model.SBXXB sb = new SYS.Model.SBXXB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.SBBH = int.Parse(dt.Rows[0]["SBBH"].ToString());
                    sb.SBLX = dt.Rows[0]["SBLX"].ToString();
                    sb.SBMC = dt.Rows[0]["SBMC"].ToString();
                    sb.SCCJ = dt.Rows[0]["SCCJ"].ToString();
                    sb.SYZT = dt.Rows[0]["SYZT"].ToString();
                    sb.XHTD = dt.Rows[0]["XHTD"].ToString();
                    sb.GDTD = dt.Rows[0]["GDTD"].ToString();
                    sb.CKTD = dt.Rows[0]["CKTD"].ToString();
                    sb.SBMS = dt.Rows[0]["SBMS"].ToString();
                }
                return sb;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用设备类型获取可选择的设备
        /// <summary>
        /// 用设备类型获取可选择的设备
        /// </summary>
        /// <param name="sbbh">设备类型</param>
        /// <returns>DataTable</returns>
        public DataTable Get_sb_by_lx(string sblx)
        {
            string sql = "select * from sbxxb where sblx=@sblx";
            SqlParameter[] spr ={
                                   new SqlParameter("@sblx",sblx)
                               };
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用设备名称获得该设备的编号
        /// <summary>
        /// 用设备名称获得该设备的编号
        /// </summary>
        /// <param name="sbbh">设备名称</param>
        /// <returns>DataTable</returns>
        public int Get_sbbh_by_sbmc(string sbmc)
        {
            string sql = "select * from sbxxb where sbmc=@sbmc";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbmc",sbmc)
                               };
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                    return int.Parse(dt.Rows[0]["SBBH"].ToString());
                else
                    return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
