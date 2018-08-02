using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SYS_DAL
{
    public class ZWBdal
    {
        #region 获取所有用户信息
        /// <summary>
        /// 用检测编号获取检测车辆的所有信息包括车辆型号信息
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>DataTable</returns>
        public DataTable Get_AllUser()
        {
            DataTable dt = new DataTable();
            string sql = "select * from ZWB";
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 用职位编号获取完整信息
        /// <summary>
        /// 用职位编号获取设备信息
        /// </summary>
        /// <param name="sbbh">职位编号</param>
        /// <returns>DataTable</returns>
        public SYS.Model.ZWB Get_zwxx_by_bh(int zwbh)
        {
            string sql = "select * from ZWB where zwbh=@zwbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@zwbh",zwbh)
                               };
            try
            {
                SYS.Model.ZWB sb = new SYS.Model.ZWB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.ZWBH = int.Parse(dt.Rows[0]["ZWBH"].ToString());
                    sb.ZWQX = int.Parse(dt.Rows[0]["ZWQX"].ToString());
                    sb.ZWMC = dt.Rows[0]["ZWMC"].ToString();
                    sb.ZWSM = dt.Rows[0]["ZWSM"].ToString();
                }
                return sb;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用username/ygbh获取信息
        /// <summary>
        /// 用username/ygbh获取信息
        /// </summary>
        /// <param name="sbbh">username/ygbh</param>
        /// <returns>bool</returns>
        public string getZwmcbyZwbh(int zwbh)
        {
            string sql = "select * from ZWB where ZWBH=@ZWBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@ZWBH",zwbh)
                               };
            try
            {
                SYS.Model.ZWB sb = new SYS.Model.ZWB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.ZWMC = dt.Rows[0]["ZWMC"].ToString();
                }
                return sb.ZWMC;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用username/ygbh获取信息
        /// <summary>
        /// 用username/ygbh获取信息
        /// </summary>
        /// <param name="sbbh">username/ygbh</param>
        /// <returns>bool</returns>
        public int getZwbhbyZwmc(string zwmc)
        {
            string sql = "select * from ZWB where ZWMC=@ZWMC";
            SqlParameter[] spr ={
                                   new SqlParameter("@ZWMC",zwmc)
                               };
            try
            {
                SYS.Model.ZWB sb = new SYS.Model.ZWB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.ZWBH = int.Parse(dt.Rows[0]["ZWBH"].ToString());
                }
                return sb.ZWBH;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用username/ygbh获取信息
        /// <summary>
        /// 用username/ygbh获取信息
        /// </summary>
        /// <param name="sbbh">username/ygbh</param>
        /// <returns>bool</returns>
        public int getZwqxbyZwbh(int zwbh)
        {
            string sql = "select * from ZWB where ZWBH=@ZWBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@ZWBH",zwbh)
                               };
            try
            {
                SYS.Model.ZWB sb = new SYS.Model.ZWB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.ZWQX = int.Parse(dt.Rows[0]["ZWQX"].ToString());
                }
                return sb.ZWQX;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        
    }
}
