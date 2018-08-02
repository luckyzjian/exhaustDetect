using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class ZYJS_jcxxdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_ZYJS_jcxx(string jcbh)
        {
            string sql = "select * from zyjs_jcxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
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

        #region 用检测编号和检测次数删除一条检测数据
        /// <summary>
        /// 用检测编号和检测次数删除一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Delete_ZYJS_jcxx(string jcbh)
        {
            string sql = "delete zyjs_jcxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
                               };
            try
            {
                if (DBHelperSQL.Execute(sql, spr) > 0)
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

        #region 用ASM对象插入或更新条检测数据
        /// <summary>
        /// 用ASM对象插入或更新条检测数据
        /// </summary>
        /// <param name="asm">ASM</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_ZYJS_jcxx(ZYJS_JCXXB vmas)
        {
            string sqli = "insert into zyjs_jcxxb(JCBH,JCZMC,JCRQ,CSYQXH,JCY,SHY,PZR) values(@JCBH,@JCZMC,@JCRQ,@CSYQXH,@JCY,@SHY,@PZR)";
            string sqlu = "update zyjs_jcxxb set JCZMC=@JCZMC,JCRQ=@JCRQ,CSYQXH=@CSYQXH,JCY=@JCY,SHY=@SHY,PZR=@PZR where JCBH=@JCBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCBH",vmas.JCBH), //1
                                   new SqlParameter("@JCZMC",vmas.JCZMC),
                                   new SqlParameter("@JCRQ",vmas.JCRQ),
                                   new SqlParameter("@CSYQXH",vmas.CSYQXH),//6
                                   new SqlParameter("@JCY",vmas.JCY),
                                   new SqlParameter("@SHY",vmas.SHY),
                                   new SqlParameter("@PZR",vmas.PZR)
                                                                   
                               };
            try
            {
                if (Have_ZYJS_jcxx(vmas.JCBH))
                {
                    if (DBHelperSQL.Execute(sqlu, spr) > 0)
                        return 2;
                    else
                        return 0;
                }
                else
                {
                    if (DBHelperSQL.Execute(sqli, spr) > 0)
                        return 1;
                    else
                        return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 用检测编号和次数查询一条检测数据
        /// <summary>
        /// 用检测编号和次数查询一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>ASM检测数据Model</returns>
        public ZYJS_JCXXB Get_ZYJS_jcxx(string jcbh)
        {
            string sql = "select * from zyjs_jcxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
                               };
            try
            {
                ZYJS_JCXXB vmas = new ZYJS_JCXXB();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    vmas.JCBH = dt.Rows[0]["JCBH"].ToString();//1
                    vmas.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    vmas.JCRQ = dt.Rows[0]["JCRQ"].ToString();
                    vmas.CSYQXH = dt.Rows[0]["CSYQXH"].ToString();//6
                    vmas.JCY = dt.Rows[0]["JCY"].ToString();
                    vmas.SHY = dt.Rows[0]["SHY"].ToString();
                    vmas.PZR = dt.Rows[0]["PZR"].ToString();
                }
                else 
                {
                    vmas.JCBH = jcbh;
                }
                return vmas;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
