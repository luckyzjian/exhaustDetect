using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace SYS_DAL
{
    public class DBHelperSQL
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string constr = Init_DBlink();
        public static SqlConnection conn_test = new SqlConnection(constr);
        public static DataTable test_dt = new DataTable();
        public static SqlDataAdapter test_adp = new SqlDataAdapter();
        public static bool DB_Status = true;

        /// <summary>
        /// 初始化数据库连接字符串
        /// </summary>
        /// <returns>string</returns>
        public static string Init_DBlink()
        {
            string constr_temp = "";
            try
            {
                Thread Th_DBlink_Test = new Thread(DB_Link_Test_DAL);
                StringBuilder temp = new StringBuilder();
                temp.Length = 2048;
                ini.INIIO.GetPrivateProfileString("数据", "服务器", "", temp, 2048, @".\appConfig.ini");
                string ServerName = temp.ToString().Trim();
                ini.INIIO.GetPrivateProfileString("数据", "数据库", "", temp, 2048, @".\appConfig.ini");
                string DBName = temp.ToString().Trim();
                ini.INIIO.GetPrivateProfileString("数据", "用户名", "", temp, 2048, @".\appConfig.ini");
                string UserName = temp.ToString().Trim();
                ini.INIIO.GetPrivateProfileString("数据", "密码", "", temp, 2048, @".\appConfig.ini");
                string Password = temp.ToString().Trim();
                if (ServerName == "" || DBName == "" || UserName == "" || Password == "")
                    throw new Exception("数据库服务器配置不正确或未配置");
                constr_temp = "Data Source=" + ServerName + ";Initial Catalog=" + DBName + ";Persist Security Info=True;User ID=" + UserName + ";password=" + Password;
                Th_DBlink_Test.Start();
            }
            catch (Exception)
            {
                throw new Exception("数据库服务器配置不正确或未配置");
            }
            return constr_temp;
        }

        /// <summary>
        /// 测试数据库连接状态DBHelper用
        /// </summary>
        public static void DB_Link_Test_DAL()
        {
            using (SqlConnection conn_test = new SqlConnection(constr))
            {
                try
                {
                    conn_test.Open();
                    SqlCommand cmd = conn_test.CreateCommand();
                    cmd.CommandText = "select * from SYSConfig";        //查询这张表 如果没有异常则连接正常
                    test_adp = new SqlDataAdapter(cmd);
                    test_adp.Fill(test_dt);
                    conn_test.Close();
                    DB_Status = true;
                }
                catch (Exception)
                {
                    conn_test.Close();
                    DB_Status = false;
                }
            }
        }

        /// <summary>
        /// 测试数据库连接状态
        /// </summary>
        /// <returns>bool</returns>
        public static bool DB_Link_Test()
        {
            try
            {
                SqlCommand cmd = conn_test.CreateCommand();
                cmd.CommandText = "select * from stationNormalInf";
                test_adp = new SqlDataAdapter(cmd);
                test_adp.Fill(test_dt);
                return true;
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("连接数据库失败：" + er.Message);
                return false;
            }
        }

        /// <summary>
        /// 通用方法 查询返回（带参数）
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <param name="spr">参数 数组</param>
        /// <returns>查询出来的数据表</returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] spr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(spr);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    try
                    {
                        conn.Open();
                        adp.Fill(dt);
                        conn.Close();
                        return dt;

                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 通用方法 查询返回（带参数）
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <param name="cmdtype">执行类型</param>
        /// <param name="spr">参数 数组</param>
        /// <returns>查询出来的数据表</returns>
        public static DataTable GetDataTable(string sql, CommandType cmdtype, SqlParameter[] spr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.CommandType = cmdtype;
                    cmd.Parameters.AddRange(spr);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        adp.Fill(dt);
                        conn.Close();
                        return dt;

                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 通用方法 查询返回（不带参数）
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="cmdtype">查询语句类型</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(string sql, CommandType cmdtype)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.CommandType = cmdtype;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        adp.Fill(dt);
                        conn.Close();
                        return dt;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        public static DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql; ;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();

                        adp.Fill(dt);
                        conn.Close();
                        return dt;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 通用方法  查询返回第一行第一列 Object类型
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <param name="cmdtype">执行类型</param>
        /// <param name="spr">参数 数组</param>
        /// <returns>查询出来的第一行第一列  Object类型</returns>
        public static object GetOnline(string sql, CommandType cmdtype, SqlParameter[] spr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // conn.Open();
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdtype;
                    cmd.Parameters.AddRange(spr);
                    try
                    {
                        conn.Open();
                        Object obj = cmd.ExecuteScalar();
                        conn.Close();
                        return obj;

                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }

                }

            }
        }

        /// <summary>
        /// 通用方法  查询返回第一行第一列 Object类型
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <returns>查询出来的第一行第一列  Object类型</returns>
        public static object GetOnline(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    try
                    {
                        conn.Open();
                        Object obj = cmd.ExecuteScalar();
                        conn.Close();
                        return obj;

                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }

                }

            }
        }

        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <param name="cmdtype">执行类型</param>
        /// <param name="spr">参数 数组</param>
        /// <returns>受影响的行数</returns>
        public static int Execute(string sql, CommandType cmdtype, SqlParameter[] spr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdtype;
                    cmd.Parameters.AddRange(spr);

                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        return i;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <param name="spr">参数 数组</param>
        /// <returns>受影响的行数</returns>
        public static int Execute(string sql, SqlParameter[] spr)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(spr);
                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        return i;
                    }
                    catch (Exception e)
                    {
                        cmd.Parameters.Clear();
                        conn.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <returns>受影响的行数</returns>
        public static int Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        return i;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteCount(string sql)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    try
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            i = int.Parse(dr["number"].ToString());
                        }
                        else
                        {
                            i = 0;
                        }
                        dr.Close();
                        //int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        return i;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <returns>受影响的行数</returns>
        public static void ExecuteNonQuery(string sql)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    try
                    {
                        SqlCommand com = new SqlCommand(sql, conn);
                        conn.Open();//打开数据库
                        com.ExecuteNonQuery();//执行语句
                        conn.Close();
                        return;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">查询语句或存储过程名</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    try
                    {
                        conn.Open();
                        int i = (int)(cmd.ExecuteScalar());
                        conn.Close();
                        return i;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        throw e;
                    }
                }
            }
        }
    }
}
