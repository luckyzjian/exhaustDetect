using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SYS_DAL
{
    public class YGBdal
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
            string sql = "select * from YGB";
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

        #region 用员工编号获取完整信息
        /// <summary>
        /// 用设备编号获取设备信息
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>DataTable</returns>
        public SYS.Model.YGB Get_ygxx_by_bh(string ygbh)
        {
            string sql = "select * from YGB where YGBH=@ygbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@ygbh",ygbh)
                               };
            try
            {
                SYS.Model.YGB sb = new SYS.Model.YGB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.YGBH = dt.Rows[0]["YGBH"].ToString();
                    sb.YGXM = dt.Rows[0]["YGXM"].ToString();
                    sb.DHHM = dt.Rows[0]["DHHM"].ToString();
                    sb.YGZWBH = int.Parse(dt.Rows[0]["YGZWBH"].ToString());
                    sb.YGSFZ = dt.Rows[0]["YGSFZ"].ToString();
                    sb.YGZT = dt.Rows[0]["YGZT"].ToString();
                    sb.User_Name = dt.Rows[0]["User_Name"].ToString();
                    sb.Password = dt.Rows[0]["Password"].ToString();
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
        public SYS.Model.YGB getXXbyuserName(string userName)
        {
            string sql = "select * from YGB where YGBH=@userName or User_Name=@userName";
            SqlParameter[] spr ={
                                   new SqlParameter("@userName",userName)
                               };
            try
            {
                SYS.Model.YGB sb = new SYS.Model.YGB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    sb.YGBH = dt.Rows[0]["YGBH"].ToString();
                    sb.YGXM = dt.Rows[0]["YGXM"].ToString();
                    sb.DHHM = dt.Rows[0]["DHHM"].ToString();
                    sb.YGZWBH = int.Parse(dt.Rows[0]["YGZWBH"].ToString());
                    sb.YGSFZ = dt.Rows[0]["YGSFZ"].ToString();
                    sb.YGZT = dt.Rows[0]["YGZT"].ToString();
                    sb.User_Name = dt.Rows[0]["User_Name"].ToString();
                    sb.Password = dt.Rows[0]["Password"].ToString();
                }
                return sb;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 用username/ygbh和password检测是否存在
        /// <summary>
        /// 用username和password检测是否存在
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>bool</returns>
        public bool checkIsRight(string userName, string password)
        {
            string sql = "select * from YGB where (YGBH=@userName or User_Name=@userName) and Password=@password";
            SqlParameter[] spr ={
                                   new SqlParameter("@userName",userName),
                                   new SqlParameter("@password",password)
                               };
            try
            {
                SYS.Model.YGB sb = new SYS.Model.YGB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region 用username检测是否存在
        /// <summary>
        /// 用username和password检测是否存在
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>bool</returns>
        public bool checkUserNameIsAlive(string userName)
        {
            string sql = "select * from YGB where User_Name=@userName";
            SqlParameter[] spr ={
                                   new SqlParameter("@userName",userName)
                               };
            try
            {
                SYS.Model.YGB sb = new SYS.Model.YGB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region 用ygbh检测是否存在
        /// <summary>
        /// 用username和password检测是否存在
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>bool</returns>
        public bool checkYgbhIsAlive(string ygbh)
        {
            string sql = "select * from YGB where YGBH=@ygbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@ygbh",ygbh)
                               };
            try
            {
                SYS.Model.YGB sb = new SYS.Model.YGB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        public bool AddNewUser(SYS.Model.YGB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ygb (");
            strSql.Append("YGBH,");//=@PZLX,");
            strSql.Append("YGXM,");//=@JCCLPH,");
            strSql.Append("DHHM,");//=@CLXHBH,");
            strSql.Append("YGZWBH,");//=@JCCS,");
            strSql.Append("YGSFZ,");//=@CCRQ,");
            strSql.Append("YGZT,");//=@DJRQ,"); 
            strSql.Append("User_Name,");//=@FDJH,");
            strSql.Append("Password)");//=@CJH,");
            strSql.Append("values (@YGBH,@YGXM,@DHHM,@YGZWBH,@YGSFZ,@YGZT,@User_Name,@Password)");
            SqlParameter[] parameters = {
					new SqlParameter("@YGBH", SqlDbType.VarChar,32),
					new SqlParameter("@YGXM", SqlDbType.VarChar,32),
					new SqlParameter("@DHHM", SqlDbType.VarChar,32),
					new SqlParameter("@YGZWBH", SqlDbType.Int,4),
					new SqlParameter("@YGSFZ", SqlDbType.VarChar,32),
                    new SqlParameter("@YGZT", SqlDbType.VarChar,32),
					new SqlParameter("@User_Name", SqlDbType.VarChar,32),
					new SqlParameter("@Password", SqlDbType.VarChar,32)
                    };
            parameters[0].Value = model.YGBH;
            parameters[1].Value = model.YGXM;
            parameters[2].Value = model.DHHM;
            parameters[3].Value = model.YGZWBH;
            parameters[4].Value = model.YGSFZ;
            parameters[5].Value = model.YGZT;
            parameters[6].Value = model.User_Name;
            parameters[7].Value = model.Password;
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
        public bool Update(SYS.Model.YGB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ygb set ");
            strSql.Append("YGBH=@YGBH,");//=@PZLX,");
            strSql.Append("YGXM=@YGXM,");//=@JCCLPH,");
            strSql.Append("DHHM=@DHHM,");//=@CLXHBH,");
            strSql.Append("YGZWBH=@YGZWBH,");//=@JCCS,");
            strSql.Append("YGSFZ=@YGSFZ,");//=@CCRQ,");
            strSql.Append("YGZT=@YGZT,");//=@DJRQ,"); 
            strSql.Append("User_Name=@User_Name,");//=@FDJH,");
            strSql.Append("Password=@Password ");//=@CJH,");
            strSql.Append("where ygbh=@YGBH or User_Name=@User_Name");
            SqlParameter[] parameters = {
					new SqlParameter("@YGBH", SqlDbType.VarChar,32),
					new SqlParameter("@YGXM", SqlDbType.VarChar,32),
					new SqlParameter("@DHHM", SqlDbType.VarChar,32),
					new SqlParameter("@YGZWBH", SqlDbType.Int,4),
					new SqlParameter("@YGSFZ", SqlDbType.VarChar,32),
                    new SqlParameter("@YGZT", SqlDbType.VarChar,32),
					new SqlParameter("@User_Name", SqlDbType.VarChar,32),
					new SqlParameter("@Password", SqlDbType.VarChar,32)
                    };
            parameters[0].Value = model.YGBH;
            parameters[1].Value = model.YGXM;
            parameters[2].Value = model.DHHM;
            parameters[3].Value = model.YGZWBH;
            parameters[4].Value = model.YGSFZ;
            parameters[5].Value = model.YGZT;
            parameters[6].Value = model.User_Name;
            parameters[7].Value = model.Password;
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
        #region 用检测线编号删除该检测线
        /// <summary>
        /// 用检测线编号删除该检测线
        /// </summary>
        /// <param name="jcbh">检测线编号</param>
        /// <returns>bool</returns>
        public bool deleteThisUser(string ygbh)
        {
            string sql = "delete from YGB where YGBH=" + "'" + ygbh + "'";
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
