using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SYS_DAL
{
    public class JCZdal
    {
        #region 获取检测站信息
        /// <summary>
        /// 获取检测站信息
        /// </summary>
        public SYS.Model.JCZXXB Get_jczxx()
        {
            string sql = "select * from jczxxb";
            try
            {
                SYS.Model.JCZXXB sb = new SYS.Model.JCZXXB();
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    sb.JCZBH = dt.Rows[0]["JCZBH"].ToString();
                    sb.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    sb.JCZDH = dt.Rows[0]["JCZDH"].ToString();
                    sb.JCZDZ = dt.Rows[0]["JCZDZ"].ToString();
                    sb.JCZFZR = dt.Rows[0]["JCZFZR"].ToString();
                }
                return sb;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
