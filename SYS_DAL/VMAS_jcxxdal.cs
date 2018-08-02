using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class VMAS_jcxxdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_VMAS_jcxx(string jcbh)
        {
            string sql = "select * from vmas_jcxxb where jcbh=@jcbh";
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
        public bool Delete_VMAS_jcxx(string jcbh)
        {
            string sql = "delete vmas_jcxxb where jcbh=@jcbh";
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
        public int Save_VMAS_jcxx(VMAS_JCXXB vmas)
        {
            string sqli = "insert into vmas_jcxxb(JCBH,JCZMC,JCCZY,JCJSY,JCRQ,SBRZBH,SBMC,SBXH,SBZZC,DPCGJ,PQFXY) values(@JCBH,@JCZMC,@JCCZY,@JCJSY,@JCRQ,@SBRZBH,@SBMC,@SBXH,@SBZZC,@DPCGJ,@PQFXY)";
            string sqlu = "update vmas_jcxxb set JCZMC=@JCZMC,JCCZY=@JCCZY,JCJSY=@JCJSY,JCRQ=@JCRQ,SBRZBH=@SBRZBH,SBMC=@SBMC,SBXH=@SBXH,SBZZC=@SBZZC,DPCGJ=@DPCGJ,PQFXY=@PQFXY where JCBH=@JCBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCBH",vmas.JCBH), //1
                                   new SqlParameter("@JCZMC",vmas.JCZMC),
                                   new SqlParameter("@JCCZY",vmas.JCCZY),
                                   new SqlParameter("@JCJSY",vmas.JCJSY),
                                   new SqlParameter("@JCRQ",vmas.JCRQ),
                                   new SqlParameter("@SBRZBH",vmas.SBRZBH),//6
                                   new SqlParameter("@SBMC",vmas.SBMC),
                                   new SqlParameter("@SBXH",vmas.SBXH),
                                   new SqlParameter("@SBZZC",vmas.SBZZC),
                                   new SqlParameter("@DPCGJ",vmas.DPCGJ),
                                   new SqlParameter("@PQFXY",vmas.PQFXY)//11
                                                                   
                               };
            try
            {
                if (Have_VMAS_jcxx(vmas.JCBH))
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
        public VMAS_JCXXB Get_VMAS_jcxx(string jcbh)
        {
            string sql = "select * from vmas_jcxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
                               };
            try
            {
                VMAS_JCXXB vmas = new VMAS_JCXXB();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    vmas.JCBH = dt.Rows[0]["JCBH"].ToString();//1
                    vmas.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    vmas.JCCZY = dt.Rows[0]["JCCZY"].ToString();
                    vmas.JCJSY = dt.Rows[0]["JCJSY"].ToString();
                    vmas.JCRQ = dt.Rows[0]["JCRQ"].ToString();
                    vmas.SBRZBH = dt.Rows[0]["SBRZBH"].ToString();//6
                    vmas.SBMC = dt.Rows[0]["SBMC"].ToString();
                    vmas.SBXH = dt.Rows[0]["SBXH"].ToString();
                    vmas.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    vmas.DPCGJ = dt.Rows[0]["DPCGJ"].ToString();
                    vmas.PQFXY = dt.Rows[0]["PQFXY"].ToString();//11
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
