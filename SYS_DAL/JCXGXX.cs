using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class JCXGXX
    {
        #region 登陆,保存检测相关信息
        /// <summary>
        /// 登陆,保存检测相关信息
        /// </summary>
        /// <param name="xgxx">JCXGXXB 数据Model</param>
        /// <returns>bool</returns>
        public bool Save_Xgxx(SYS.Model.JCXGXXB xgxx)
        {
            string sqli = "insert into jcxgxxb(JCBH,JCCS,LSH,DLY,WGJCY,YCY,DPJCY,PFJCY,JCXBH,JCZBH,WGJCJG,JCJG,JCSJ,WQJCHG,CGJCHG) values (@JCBH,@JCCS,@LSH,@DLY,@WGJCY,@YCY,@DPJCY,@PFJCY,@JCXBH,@JCZBH,@WGJCJG,@JCJG,@JCSJ,@WQJCHG,@CGJCHG)";
            string sqlu = "update jcxgxxb set LSH=@LSH,DLY=@DLY,WGJCY=@WGJCY,YCY=@YCY,DPJCY=@DPJCY,PFJCY=@PFJCY,JCXBH=@JCXBH,JCZBH=@JCZBH,WGJCJG=@WGJCJG,JCJG=@JCJG,JCSJ=@JCSJ,WQJCHG=@WQJCHG,CGJCHG=@CGJCHG where JCBH=@JCBH";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCBH",xgxx.JCBH),
                                   new SqlParameter("@JCCS",xgxx.JCCS),
                                   new SqlParameter("@LSH",xgxx.LSH),
                                   new SqlParameter("@DLY",xgxx.DLY),
                                   new SqlParameter("@WGJCY",xgxx.WGJCY),
                                   new SqlParameter("@YCY",xgxx.YCY),
                                   new SqlParameter("@DPJCY",xgxx.DPJCY),
                                   new SqlParameter("@PFJCY",xgxx.PFJCY),
                                   new SqlParameter("@JCXBH",xgxx.JCXBH),
                                   new SqlParameter("@JCZBH",xgxx.JCZBH),
                                   new SqlParameter("@WGJCJG",xgxx.WGJCJG),
                                   new SqlParameter("@JCJG",xgxx.JCJG),
                                   new SqlParameter("@JCSJ",xgxx.JCSJ),
                                   new SqlParameter("@WQJCHG",xgxx.WQJCHG),
                                   new SqlParameter("@CGJCHG",xgxx.CGJCHG)
                               };
            try
            {
                if (DBHelperSQL.Execute(sqli, spr) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                if (DBHelperSQL.Execute(sqlu, spr) > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 用检测编号和检测次数查询检测相关信息Model
        /// <summary>
        /// 用检测编号和检测次数查询检测相关信息Model
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>JCXGXX Model</returns>
        public JCXGXXB Get_Xgxx(string jcbh)
        {
            string sql = "select * from jcxgxxb where jcbh=@jcbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcbh",jcbh)
                               };
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                JCXGXXB xgxx = new JCXGXXB();
                if (dt.Rows.Count > 0)
                {
                    xgxx.JCBH = dt.Rows[0]["JCBH"].ToString();
                    //xgxx.JCCS = int.Parse(dt.Rows[0]["JCCS"].ToString());
                    xgxx.LSH = dt.Rows[0]["LSH"].ToString();
                    xgxx.DLY = dt.Rows[0]["DLY"].ToString();
                    xgxx.WGJCY = dt.Rows[0]["WGJCY"].ToString();
                    xgxx.YCY = dt.Rows[0]["YCY"].ToString();
                    xgxx.DPJCY = dt.Rows[0]["DPJCY"].ToString();
                    xgxx.PFJCY = dt.Rows[0]["PFJCY"].ToString();
                    xgxx.JCXBH = dt.Rows[0]["JCXBH"].ToString();
                    xgxx.JCZBH = dt.Rows[0]["JCZBH"].ToString();
                    xgxx.WGJCJG = dt.Rows[0]["WGJCJG"].ToString();
                    xgxx.JCJG = dt.Rows[0]["JCJG"].ToString();
                    xgxx.JCSJ = DateTime.Parse(dt.Rows[0]["JCSJ"].ToString());
                    xgxx.WQJCHG = dt.Rows[0]["WQJCHG"].ToString();
                    xgxx.CGJCHG = dt.Rows[0]["CGJCHG"].ToString();
                }
                else
                {
                    xgxx.JCBH = "";
                    xgxx.JCCS = 0;
                    xgxx.LSH = "";
                    xgxx.DLY = "";
                    xgxx.WGJCY = "";
                    xgxx.YCY = "";
                    xgxx.DPJCY = "";
                    xgxx.PFJCY = "";
                    xgxx.JCXBH = "";
                    xgxx.JCZBH = "";
                    xgxx.WGJCJG = "";
                    xgxx.JCJG = "";
                    xgxx.JCSJ = DateTime.Now;
                    xgxx.WQJCHG = "";
                    xgxx.CGJCHG = "";
                }
                return xgxx;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 用检测编号和次数删除一个检测相关信息
        /// <summary>
        /// 用检测编号和次数删除一个检测相关信息
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Delete_Jcxgxx(string jcbh)
        {
            string sql = "select * from jcxgxx where jcbh=@jcbh";
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
    }
}
