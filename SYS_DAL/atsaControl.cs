using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SYS_DAL;
using SYS.Model;
using SYS_MODEL;
using System.Data.SqlClient;
using System.Data;
using SYS;

namespace SYS_DAL
{
    public partial class atsaControl
    {
        
        #region 根据车牌号检查该车信息是否存在
        public bool checkCarInfIsAlive(string VID)
        {
            string sql = "select * from vehicle_info where VID='" + VID + "'";
            try
            {
                DataTable dt = ATSADBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #endregion
        #region 根据车牌号获取该车信息
        public string getCarInfbyPlate(string vid)
        {
            DateTime a, b;
            string PLATE = "";
            string sql = "select * from vehicle_info where VID='" + vid + "'";
            try
            {
                DataTable dt = ATSADBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    PLATE = dt.Rows[0]["车牌号码"].ToString();//1
                }
                else
                    PLATE = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return PLATE;

        }
        #endregion
        
        public DataTable requerydata(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = ATSADBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }


        
    }
}


