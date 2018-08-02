using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
   public class XTKXGCS
    {
        /// <summary>
        ///获取系统可修改参数对象 获取排放限量值
        /// </summary>
        ///  
        /// <returns>系统可修改参数对象</returns>
        public XTKXGCSB getXTCS()
        {
            XTKXGCSB xtkxgcs = new XTKXGCSB();

            string sql = "select  top 1 BH,MMJXCS,HC50PFXZ,NO50PFXZ,CO50PFXZ,HC25PFXZ,NO25PFXZ,CO25PFXZ,FXYXYSJ,QYWDSJ,QYCJSJ,KXZ,XTS from XTKXGCSB ";
            DataTable dt = DBHelperSQL.GetDataTable(sql);
            if (dt.Rows[0]["HC50PFXZ"] != null && dt.Rows[0]["HC50PFXZ"].ToString() != "")
            {
                xtkxgcs.HC50PFXZ = int.Parse(dt.Rows[0]["HC50PFXZ"].ToString());
            }
            if (dt.Rows[0]["NO50PFXZ"] != null && dt.Rows[0]["NO50PFXZ"].ToString() != "")
            {
                xtkxgcs.NO50PFXZ = int.Parse(dt.Rows[0]["NO50PFXZ"].ToString());
            }
            if (dt.Rows[0]["CO50PFXZ"] != null && dt.Rows[0]["CO50PFXZ"].ToString() != "")
            {
                xtkxgcs.CO50PFXZ = decimal.Parse(dt.Rows[0]["CO50PFXZ"].ToString());
            }
            if (dt.Rows[0]["HC25PFXZ"] != null && dt.Rows[0]["HC25PFXZ"].ToString() != "")
            {
                xtkxgcs.HC25PFXZ = int.Parse(dt.Rows[0]["HC25PFXZ"].ToString());
            }
            if (dt.Rows[0]["NO25PFXZ"] != null && dt.Rows[0]["NO25PFXZ"].ToString() != "")
            {
                xtkxgcs.NO25PFXZ = int.Parse(dt.Rows[0]["NO25PFXZ"].ToString());
            }
            if (dt.Rows[0]["CO25PFXZ"] != null && dt.Rows[0]["CO25PFXZ"].ToString() != "")
            {
                xtkxgcs.CO25PFXZ = decimal.Parse(dt.Rows[0]["CO25PFXZ"].ToString());
            }
            if (dt.Rows[0]["KXZ"] != null && dt.Rows[0]["KXZ"].ToString() != "")
            {
                xtkxgcs.KXZ = decimal.Parse(dt.Rows[0]["KXZ"].ToString());
            }
            if (dt.Rows[0]["FXYXYSJ"] != null && dt.Rows[0]["FXYXYSJ"].ToString() != "")
            {
                xtkxgcs.FXYXYSJ = int.Parse(dt.Rows[0]["FXYXYSJ"].ToString());
            }
            if (dt.Rows[0]["QYWDSJ"] != null && dt.Rows[0]["QYWDSJ"].ToString() != "")
            {
                xtkxgcs.QYWDSJ = int.Parse(dt.Rows[0]["QYWDSJ"].ToString());
            }
            if (dt.Rows[0]["QYCJSJ"] != null && dt.Rows[0]["QYCJSJ"].ToString() != "")
            {
                xtkxgcs.QYCJSJ = int.Parse(dt.Rows[0]["QYCJSJ"].ToString());
            }



            return xtkxgcs;
        }
    }
}
