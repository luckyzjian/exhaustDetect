using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class JZJS_jcxxdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_JZJS_jcxx(string jcbh)
        {
            string sql = "select * from jzjs_jcxxb where jcbh=@jcbh";
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
        public bool Delete_jzjs_jcxx(string jcbh)
        {
            string sql = "delete jzjs_jcxxb where jcbh=@jcbh";
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
        public int Save_jzjs_jcxx(JZJS_JCXXB vmas)
        {
            string sqli = "insert into jzjs_jcxxb(JCBH,JCZMC,JCRQ,SBHZH,CGJXH,CGJZZC,YDJXH,YDJZZC,ZSJXH,ZSJZZC,HJZXH,HJZZZC,PCXH,PCZZC,JCY,SHY,PZR,ZCY) values(@JCBH,@JCZMC,@JCRQ,@SBHZH,@CGJXH,@CGJZZC,@YDJXH,@YDJZZC,@ZSJXH,@ZSJZZC,@HJZXH,@HJZZZC,@PCXH,@PCZZC,@JCY,@SHY,@PZR,@ZCY)";
            string sqlu = "update jzjs_jcxxb set JCZMC=@JCZMC,JCRQ=@JCRQ,SBHZH=@SBHZH,CGJXH=@CGJXH,CGJZZC=@CGJZZC,YDJXH=@YDJXH,YDJZZC=@YDJZZC,ZSJXH=@ZSJXH,ZSJZZC=@ZSJZZC,HJZXH=@HJZXH,HJZZZC=@HJZZZC,PCXH=@PCXH,PCZZC=@PCZZC,JCY=@JCY,SHY=@SHY,PZR=@PZR,ZCY=@ZCY where JCBH=@JCBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCBH",vmas.JCBH), //1
                                   new SqlParameter("@JCZMC",vmas.JCZMC),
                                   new SqlParameter("@JCRQ",vmas.JCRQ),
                                   new SqlParameter("@SBHZH",vmas.SBHZH),
                                   new SqlParameter("@CGJXH",vmas.CGJXH),//6
                                   new SqlParameter("@CGJZZC",vmas.CGJZZC),
                                   new SqlParameter("@YDJXH",vmas.YDJXH),
                                   new SqlParameter("@YDJZZC",vmas.YDJZZC),
                                   new SqlParameter("@ZSJXH",vmas.ZSJXH),
                                   new SqlParameter("@ZSJZZC",vmas.ZSJZZC),//11
                                   new SqlParameter("@HJZXH",vmas.HJZXH), //1
                                   new SqlParameter("@HJZZZC",vmas.HJZZZC),
                                   new SqlParameter("@PCXH",vmas.PCXH),
                                   new SqlParameter("@PCZZC",vmas.PCZZC),
                                   new SqlParameter("@JCY",vmas.JCY),
                                   new SqlParameter("@SHY",vmas.SHY),//6
                                   new SqlParameter("@PZR",vmas.PZR),
                                   new SqlParameter("@ZCY",vmas.ZCY)
                                                                   
                               };
            try
            {
                if (Have_JZJS_jcxx(vmas.JCBH))
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
        public JZJS_JCXXB Get_JZJS_jcxx(string jcbh)
        {
            string sql = "select * from jzjs_jcxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
                               };
            try
            {
                JZJS_JCXXB vmas = new JZJS_JCXXB();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    vmas.JCBH = dt.Rows[0]["JCBH"].ToString();//1
                    vmas.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    vmas.JCRQ = dt.Rows[0]["JCRQ"].ToString();
                    vmas.SBHZH = dt.Rows[0]["SBHZH"].ToString();
                    vmas.CGJXH = dt.Rows[0]["CGJXH"].ToString();
                    vmas.CGJZZC = dt.Rows[0]["CGJZZC"].ToString();//6
                    vmas.YDJXH = dt.Rows[0]["YDJXH"].ToString();
                    vmas.YDJZZC = dt.Rows[0]["YDJZZC"].ToString();
                    vmas.ZSJXH = dt.Rows[0]["ZSJXH"].ToString();
                    vmas.ZSJZZC = dt.Rows[0]["ZSJZZC"].ToString();
                    vmas.HJZXH = dt.Rows[0]["HJZXH"].ToString();//11
                    vmas.HJZZZC = dt.Rows[0]["HJZZZC"].ToString();
                    vmas.PCXH = dt.Rows[0]["PCXH"].ToString();
                    vmas.PCZZC = dt.Rows[0]["PCZZC"].ToString();//6
                    vmas.JCY = dt.Rows[0]["JCY"].ToString();
                    vmas.SHY = dt.Rows[0]["SHY"].ToString();
                    vmas.PZR = dt.Rows[0]["PZR"].ToString();
                    vmas.ZCY = dt.Rows[0]["ZCY"].ToString();
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
