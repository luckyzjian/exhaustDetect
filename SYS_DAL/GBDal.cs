using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class GBDal
    {
        #region 判断一条检测数据是否存在
        /// <summary>
        /// 判断一条检测数据是否存在
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Have_GB(string Table)
        {
            string sql = "select * from " + Table;
            try
            {
                if (DBHelperSQL.GetDataTable(sql).Rows.Count > 0)
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
        #region 用ASM对象插入或者更新数据
        /// <summary>
        /// 用ASM对象插入或者更新数据
        /// </summary>
        /// <param name="asm"></param>
        /// <returns>int 0为失败，1为插入成功</returns>

        #endregion
        #region 用VMAS对象插入或者更新数据
        /// <summary>
        /// 用VMAS对象插入或者更新数据
        /// </summary>
        /// <param name="vmas"></param>
        /// <returns>int 0为失败，1为插入成功</returns>
        public int Save_VMAS_XZDB(VMAS_XZDB vmas)
        {
            string sqli = "insert into VMAS_XZDB (ID,S1020d120000701bhc, S1020d120000701bco,S1020d120000701bnox,S10201470d120000701bhc,S10201470d120000701bco,S10201470d120000701bnox,S14701930d120000701bhc,S14701930d120000701bco,S14701930d120000701bnox,S1930d120000701bhc,   S1930d120000701bco,S1930d120000701bnox, S1020d220011001bhc, S1020d220011001bco,S1020d220011001bnox, S10201470d220011001bhc, S10201470d220011001bco,S10201470d220011001bnox,S14701930d220011001bhc, S14701930d220011001bco,S14701930d220011001bnox, S1930d220011001bhc, S1930d220011001bco,S1930d220011001bnox,S1250d120000701ahcnox, S1250d120000701aco, S12501700d120000701ahcnox, S12501700d120000701aco, S1700d120000701ahcnox, S1700d120000701aco, S1250d220011001ahcnox, S1250d220011001aco,  S12501700d220011001ahcnox, S12501700d220011001aco, S1700d220011001ahcnox, S1700d220011001aco)" +
                " VALUES (@ID,@S1020d1date20000701bhc, @S1020d1date20000701bco,@S1020d1date20000701bno,@S10201470d1date20000701bhc,@S10201470d1date20000701bco,@S10201470d1date20000701bno,@S14701930d1date20000701bhc,@S14701930d1date20000701bco,@S14701930d1date20000701bno, @S1930d1date20000701bhc,   @S1930d1date20000701bco,@S1930d1date20000701bno, @S1020d2date20011001bhc, @S1020d2date20011001bco,@S1020d2date20011001bno, @S10201470d2date20011001bhc, @S10201470d2date20011001bco,@S10201470d2date20011001bno,@S14701930d2date20011001bhc, @S14701930d2date20011001bco,@S14701930d2date20011001bno, @S1930d2date20011001bhc, @S1930d2date20011001bco,@S1930d2date20011001bno,@S1250d1date20000701ahcnox, @S1250d1date20000701aco, @S12501700d1date20000701ahcnox, @S12501700d1date20000701aco, @S1700d1date20000701ahcnox, @S1700d1date20000701aco, @S1250d2date20011001ahcnox, @S1250d2date20011001aco,  @S12501700d2date20011001ahcnox, @S12501700d2date20011001aco, @S1700d2date20011001ahcnox, @S1700d2date20011001aco)";

            SqlParameter[] sqr ={
                    new SqlParameter("@ID", "山东省"),
                    new SqlParameter("@S1020d1date20000701bhc", vmas.S1020d1date20000701bhc),
                    new SqlParameter("@S1020d1date20000701bco", vmas.S1020d1date20000701bco),
                    new SqlParameter("@S1020d1date20000701bno", vmas.S1020d1date20000701bno),

                    new SqlParameter("@S10201470d1date20000701bhc", vmas.S10201470d1date20000701bhc),
                    new SqlParameter("@S10201470d1date20000701bco", vmas.S10201470d1date20000701bco),
                    new SqlParameter("@S10201470d1date20000701bno", vmas.S10201470d1date20000701bno),
                    new SqlParameter("@S14701930d1date20000701bhc", vmas.S14701930d1date20000701bhc),
                    new SqlParameter("@S14701930d1date20000701bco", vmas.S14701930d1date20000701bco),
                    new SqlParameter("@S14701930d1date20000701bno", vmas.S14701930d1date20000701bno),
                    new SqlParameter("@S1930d1date20000701bhc", vmas.S1930d1date20000701bhc),
                    new SqlParameter("@S1930d1date20000701bco", vmas.S1930d1date20000701bco),
                    new SqlParameter("@S1930d1date20000701bno", vmas.S1930d1date20000701bno),
                    new SqlParameter("@S1020d2date20011001bhc", vmas.S1020d2date20011001bhc),
                    new SqlParameter("@S1020d2date20011001bco", vmas.S1020d2date20011001bco),
                    new SqlParameter("@S1020d2date20011001bno", vmas.S1020d2date20011001bno),
                    new SqlParameter("@S10201470d2date20011001bhc", vmas.S10201470d2date20011001bhc),
                    new SqlParameter("@S10201470d2date20011001bco", vmas.S10201470d2date20011001bco),
                    new SqlParameter("@S10201470d2date20011001bno", vmas.S10201470d2date20011001bno),
                    new SqlParameter("@S14701930d2date20011001bhc", vmas.S14701930d2date20011001bhc),
                    new SqlParameter("@S14701930d2date20011001bco", vmas.S14701930d2date20011001bco),
                    new SqlParameter("@S14701930d2date20011001bno", vmas.S14701930d2date20011001bno),
                    new SqlParameter("@S1930d2date20011001bhc", vmas.S1930d2date20011001bhc),
                    new SqlParameter("@S1930d2date20011001bco", vmas.S1930d2date20011001bco),
                    new SqlParameter("@S1930d2date20011001bno", vmas.S1930d2date20011001bno),
                    new SqlParameter("@S1250d1date20000701ahcnox", vmas.S1250d1date20000701ahcnox),
                    new SqlParameter("@S1250d1date20000701aco", vmas.S1250d1date20000701aco),
                    new SqlParameter("@S12501700d1date20000701ahcnox", vmas.S12501700d1date20000701ahcnox),
                    new SqlParameter("@S12501700d1date20000701aco", vmas.S12501700d1date20000701aco),
                    new SqlParameter("@S1700d1date20000701ahcnox", vmas.S1700d1date20000701ahcnox),
                    new SqlParameter("@S1700d1date20000701aco", vmas.S1700d1date20000701aco),
                    new SqlParameter("@S1250d2date20011001ahcnox", vmas.S1250d2date20011001ahcnox),
                    new SqlParameter("@S1250d2date20011001aco", vmas.S1250d2date20011001aco),
                    new SqlParameter("@S12501700d2date20011001ahcnox", vmas.S12501700d2date20011001ahcnox),
                    new SqlParameter("@S12501700d2date20011001aco", vmas.S12501700d2date20011001aco),
                    new SqlParameter("@S1700d2date20011001ahcnox", vmas.S1700d2date20011001ahcnox),
                    new SqlParameter("@S1700d2date20011001aco", vmas.S1700d2date20011001aco)
                    };
            try
            {
                if (Have_GB("VMAS_XZDB"))
                {
                    //删除原来所有数据再插入新数据
                    string sql = "delete from VMAS_XZDB";
                    DBHelperSQL.Execute(sql);
                    //插入新数据
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
                        return 1;
                    else
                        return 0;
                }
                else
                {
                    //插入新数据
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
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
        #region 用SDS对象插入或更新数据
        /// <summary>
        /// 用SDS对象插入或更新数据
        /// </summary>
        /// <param name="sds"></param>
        /// <returns>int 0为失败，1为插入成功</returns>
        public int Save_SDS_XZGB(SDS_XZGB sds)
        {
            string sqli = "insert into SDS_XZGB(HNewd1HC,HNewd1CO,Newd1HC,Newd1CO,HNewd2HC,HNewd2CO,Newd2HC,Newd2CO,zxHNewHC,zxHNewCO,zxNewHC,zxNewCO,Hd1Date19950701qHC,Hd1Date19950701qCO,d1Date19950701qHC,d1Date19950701qCO,Hd1Date1995070120000701HC,Hd1Date1995070120000701CO,d1Date1995070120000701HC,d1Date1995070120000701CO,Hd1Date20000701HC,Hd1Date20000701CO,d1Date20000701HC,d1Date20000701CO,Hd2Date19950701qHC,Hd2Date19950701qCO,d2Date19950701qHC,d2Date19950701qCO,Hd2Date1995070120011001HC,Hd2Date1995070120011001CO,d2Date1995070120011001HC,d2Date1995070120011001CO,Hd2Date20011001HC,Hd2Date20011001CO,d2Date20011001HC,d2Date20011001CO,HzxDate19950701qHC,HzxDate19950701qCO,zxDate19950701qHC,zxDate19950701qCO,HzxDate1995070120040901HC,HzxDate1995070120040901CO,zxDate1995070120040901HC,zxDate1995070120040901CO,HzxDate20040901HC,HzxDate20040901CO,zxDate20040901HC,zxDate20040901CO) values(@HNewd1HC,@HNewd1CO,@Newd1HC,@Newd1CO,@HNewd2HC,@HNewd2CO,@Newd2HC,@Newd2CO,@zxHNewHC,@zxHNewCO,@zxNewHC,@zxNewCO,@Hd1Date19950701qHC,@Hd1Date19950701qCO,@d1Date19950701qHC,@d1Date19950701qCO,@Hd1Date1995070120000701HC,@Hd1Date1995070120000701CO,@d1Date1995070120000701HC,@d1Date1995070120000701CO,@Hd1Date20000701HC,@Hd1Date20000701CO,@d1Date20000701HC,@d1Date20000701CO,@Hd2Date19950701qHC,@Hd2Date19950701qCO,@d2Date19950701qHC,@d2Date19950701qCO,@Hd2Date1995070120011001HC,@Hd2Date1995070120011001CO,@d2Date1995070120011001HC,@d2Date1995070120011001CO,@Hd2Date20011001HC,@Hd2Date20011001CO,@d2Date20011001HC,@d2Date20011001CO,@HzxDate19950701qHC,@HzxDate19950701qCO,@zxDate19950701qHC,@zxDate19950701qCO,@HzxDate1995070120040901HC,@HzxDate1995070120040901CO,@zxDate1995070120040901HC,@zxDate1995070120040901CO,@HzxDate20040901HC,@HzxDate20040901CO,@zxDate20040901HC,@zxDate20040901CO)";
            SqlParameter[] sqr ={
                                   new SqlParameter("HNewd1HC",sds.HNewd1HC),
                                   new SqlParameter("HNewd1CO",sds.HNewd1CO),
                                   new SqlParameter("Newd1HC",sds.Newd1HC),
                                   new SqlParameter("Newd1CO",sds.Newd1CO),
                                   new SqlParameter("HNewd2HC",sds.HNewd2HC),
                                   new SqlParameter("HNewd2CO",sds.HNewd2CO),   
                                   new SqlParameter("Newd2HC",sds.Newd2HC), 
                                   new SqlParameter("Newd2CO",sds.Newd2CO), 
                                   new SqlParameter("zxHNewHC",sds.zxHNewHC), 
                                   new SqlParameter("zxHNewCO",sds.zxHNewCO),
                                   new SqlParameter("zxNewHC",sds.zxNewHC),
                                   new SqlParameter("zxNewCO",sds.zxNewCO),
                                   new SqlParameter("Hd1Date19950701qHC",sds.Hd1Date19950701qHC),
                                   new SqlParameter("Hd1Date19950701qCO",sds.Hd1Date19950701qCO), 
                                   new SqlParameter("d1Date19950701qHC",sds.d1Date19950701qHC), 
                                   new SqlParameter("d1Date19950701qCO",sds.d1Date19950701qCO),
                                   new SqlParameter("Hd1Date1995070120000701HC",sds.Hd1Date1995070120000701HC),
                                   new SqlParameter("Hd1Date1995070120000701CO",sds.Hd1Date1995070120000701CO),    
                                   new SqlParameter("d1Date1995070120000701HC",sds.d1Date1995070120000701HC),
                                   new SqlParameter("d1Date1995070120000701CO",sds.d1Date1995070120000701CO),
                                   new SqlParameter("Hd1Date20000701HC",sds.Hd1Date20000701HC),
                                   new SqlParameter("Hd1Date20000701CO",sds.Hd1Date20000701CO),
                                   new SqlParameter("d1Date20000701HC",sds.d1Date20000701HC),
                                   new SqlParameter("d1Date20000701CO",sds.d1Date20000701CO),
                                   new SqlParameter("Hd2Date19950701qHC",sds.Hd2Date19950701qHC),
                                   new SqlParameter("Hd2Date19950701qCO",sds.Hd2Date19950701qCO),
                                   new SqlParameter("d2Date19950701qHC",sds.d2Date19950701qHC),
                                   new SqlParameter("d2Date19950701qCO",sds.d2Date19950701qCO),
                                   new SqlParameter("Hd2Date1995070120011001HC",sds.Hd2Date1995070120011001HC),
                                   new SqlParameter("Hd2Date1995070120011001CO",sds.Hd2Date1995070120011001CO),
                                   new SqlParameter("d2Date1995070120011001HC",sds.d2Date1995070120011001HC),
                                   new SqlParameter("d2Date1995070120011001CO",sds.d2Date1995070120011001CO),
                                   new SqlParameter("Hd2Date20011001HC",sds.Hd2Date20011001HC),
                                   new SqlParameter("Hd2Date20011001CO",sds.Hd2Date20011001CO),
                                   new SqlParameter("d2Date20011001HC",sds.d2Date20011001HC),
                                   new SqlParameter("d2Date20011001CO",sds.d2Date20011001CO),
                                   new SqlParameter("HzxDate19950701qHC",sds.HzxDate19950701qHC),
                                   new SqlParameter("HzxDate19950701qCO",sds.HzxDate19950701qCO),
                                   new SqlParameter("zxDate19950701qHC",sds.zxDate19950701qHC),
                                   new SqlParameter("zxDate19950701qCO",sds.zxDate19950701qCO),
                                   new SqlParameter("HzxDate1995070120040901HC",sds.HzxDate1995070120040901HC),
                                   new SqlParameter("HzxDate1995070120040901CO",sds.HzxDate1995070120040901CO),
                                   new SqlParameter("zxDate1995070120040901HC",sds.zxDate1995070120040901HC),                                      
                                   new SqlParameter("zxDate1995070120040901CO",sds.zxDate1995070120040901CO),
                                   new SqlParameter("HzxDate20040901HC",sds.HzxDate20040901HC),
                                   new SqlParameter("HzxDate20040901CO",sds.HzxDate20040901CO),
                                   new SqlParameter("zxDate20040901HC",sds.zxDate20040901HC),
                                   new SqlParameter("zxDate20040901CO",sds.zxDate20040901CO),   

                               };
            try
            {
                if (Have_GB("SDS_XZGB"))
                {
                    string sql = "delete from SDS_XZGB";
                    DBHelperSQL.Execute(sql);
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
                        return 1;
                    else
                        return 0;
                }
                else
                {
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
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
        #region 用JZJS对象插入或更新数据
        /// <summary>
        /// 用JZJS对象插入或更新数据
        /// </summary>
        /// <param name="jzjs"></param>
        /// <returns>int 0为失败，1为插入成功</returns>
        public int Save_JZJS_XZDB(JZJS_XZDB jzjs)
        {
            string sqli = "insert into JZJS_XZDB(d1Date20000701b,d1Date2000070120050630,d1Date20050701,d2Date20011001b,d2Date2001100120060630,d2Date20060701,zxDate20010901b,zxDate2001090120040831,zxDate20040901) values(@d1Date20000701b,@d1Date2000070120050630,@d1Date20050701,@d2Date20011001b,@d2Date2001100120060630,@d2Date20060701,@zxDate20010901b,@zxDate2001090120040831,@zxDate20040901)";
            SqlParameter[] sqr ={
                               new SqlParameter("@d1Date20000701b",jzjs.d1Date20000701b),
                               new SqlParameter("@d1Date2000070120050630",jzjs.d1Date2000070120050630),
                               new SqlParameter("@d1Date20050701",jzjs.d1Date20050701),
                               new SqlParameter("@d2Date20011001b",jzjs.d2Date20011001b),
                               new SqlParameter("@d2Date2001100120060630",jzjs.d2Date2001100120060630),
                               new SqlParameter("@d2Date20060701",jzjs.d2Date20060701),
                               new SqlParameter("@zxDate20010901b",jzjs.zxDate20010901b),
                               new SqlParameter("@zxDate2001090120040831",jzjs.zxDate2001090120040831),
                               new SqlParameter("@zxDate20040901",jzjs.zxDate20040901)
                              };
            try
            {
                if (Have_GB("JZJS_XZDB"))
                {
                    string sql = "delete from JZJS_XZDB";
                    DBHelperSQL.Execute(sql);
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
                        return 1;
                    else
                        return 0;
                }
                else
                {
                    if (DBHelperSQL.Execute(sqli, sqr) > 0)
                        return 1;
                    else
                        return 0;
                }
            }
            catch (Exception)
            {
                throw ;
            }

        }

        #endregion
        
        #region 用ZYJS对象插入或更新条检测数据
        /// <summary>
        /// 用ZYJS对象插入或更新条检测数据
        /// </summary>
        /// <param name=""></param>
        /// <returns>int 0为失败，1为插入成功</returns>
        public int Save_ZYJS_XZGB(ZYJS_XZGB zyjs)
        {

            string sqli = "insert into ZYJS_XZGB(ZRDate20011001btgxz,WLDate20011001btgxz) values(@ZRDate20011001btgxz,@WLDate20011001btgxz)";
            SqlParameter[] spr ={
                                   new SqlParameter("@ZRDate20011001btgxz",zyjs.ZRDate20011001btgxz), 
                                   new SqlParameter("@WLDate20011001btgxz",zyjs.WLDate20011001btgxz),
                               };
            try
            {
                if (Have_GB("ZYJS_XZGB"))
                {
                    //删除原来所有数据再插入新数据
                    string sql = "delete from ZYJS_XZGB";
                    DBHelperSQL.Execute(sql);
                    //插入新数据
                    if (DBHelperSQL.Execute(sqli, spr) > 0)
                        return 1;
                    else
                        return 0;
                }
                else
                {
                    //插入新数据
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
        #region 查询一条SDS限值
        public SDS_XZGB Get_SDS_XZGB()
        {
            string sql = "select * from SDS_XZGB";
            SDS_XZGB sds_xzgb = new SDS_XZGB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    sds_xzgb.d1Date1995070120000701CO = dt.Rows[0]["d1Date1995070120000701CO"].ToString();
                    sds_xzgb.d1Date1995070120000701HC = dt.Rows[0]["d1Date1995070120000701HC"].ToString();
                    sds_xzgb.d1Date19950701qCO = dt.Rows[0]["d1Date19950701qCO"].ToString();
                    sds_xzgb.d1Date19950701qHC = dt.Rows[0]["d1Date19950701qHC"].ToString();
                    sds_xzgb.d1Date20000701CO = dt.Rows[0]["d1Date20000701CO"].ToString();
                    sds_xzgb.d1Date20000701HC = dt.Rows[0]["d1Date20000701HC"].ToString();
                    sds_xzgb.d2Date1995070120011001CO = dt.Rows[0]["d2Date1995070120011001CO"].ToString();
                    sds_xzgb.d2Date1995070120011001HC = dt.Rows[0]["d2Date1995070120011001HC"].ToString();

                    sds_xzgb.d2Date19950701qCO = dt.Rows[0]["d2Date19950701qCO"].ToString();
                    sds_xzgb.d2Date19950701qHC = dt.Rows[0]["d2Date19950701qHC"].ToString();
                    sds_xzgb.d2Date20011001CO = dt.Rows[0]["d2Date20011001CO"].ToString();
                    sds_xzgb.d2Date20011001HC = dt.Rows[0]["d2Date20011001HC"].ToString();
                    sds_xzgb.Hd1Date1995070120000701CO = dt.Rows[0]["Hd1Date1995070120000701CO"].ToString();
                    sds_xzgb.Hd1Date1995070120000701HC = dt.Rows[0]["Hd1Date1995070120000701HC"].ToString();
                    sds_xzgb.Hd1Date19950701qCO = dt.Rows[0]["Hd1Date19950701qCO"].ToString();
                    sds_xzgb.Hd1Date19950701qHC = dt.Rows[0]["Hd1Date19950701qHC"].ToString();

                    sds_xzgb.Hd1Date20000701CO = dt.Rows[0]["Hd1Date20000701CO"].ToString();
                    sds_xzgb.Hd1Date20000701HC = dt.Rows[0]["Hd1Date20000701HC"].ToString();
                    sds_xzgb.Hd2Date1995070120011001CO = dt.Rows[0]["Hd2Date1995070120011001CO"].ToString();
                    sds_xzgb.Hd2Date1995070120011001HC = dt.Rows[0]["Hd2Date1995070120011001HC"].ToString();
                    sds_xzgb.Hd2Date19950701qCO = dt.Rows[0]["Hd2Date19950701qCO"].ToString();
                    sds_xzgb.Hd2Date19950701qHC = dt.Rows[0]["Hd2Date19950701qHC"].ToString();
                    sds_xzgb.Hd2Date20011001CO = dt.Rows[0]["Hd2Date20011001CO"].ToString();
                    sds_xzgb.Hd2Date20011001HC = dt.Rows[0]["Hd2Date20011001HC"].ToString();

                    sds_xzgb.HNewd1CO = dt.Rows[0]["HNewd1CO"].ToString();
                    sds_xzgb.HNewd1HC = dt.Rows[0]["HNewd1HC"].ToString();
                    sds_xzgb.HNewd2CO = dt.Rows[0]["HNewd2CO"].ToString();
                    sds_xzgb.HNewd2HC = dt.Rows[0]["HNewd2HC"].ToString();
                    sds_xzgb.HzxDate1995070120040901CO = dt.Rows[0]["HzxDate1995070120040901CO"].ToString();
                    sds_xzgb.HzxDate1995070120040901HC = dt.Rows[0]["HzxDate1995070120040901HC"].ToString();
                    sds_xzgb.HzxDate19950701qCO = dt.Rows[0]["HzxDate19950701qCO"].ToString();
                    sds_xzgb.HzxDate19950701qHC = dt.Rows[0]["HzxDate19950701qHC"].ToString();

                    sds_xzgb.HzxDate20040901CO = dt.Rows[0]["HzxDate20040901CO"].ToString();
                    sds_xzgb.HzxDate20040901HC = dt.Rows[0]["HzxDate20040901HC"].ToString();
                    sds_xzgb.Newd1CO = dt.Rows[0]["Newd1CO"].ToString();
                    sds_xzgb.Newd1HC = dt.Rows[0]["Newd1HC"].ToString();
                    sds_xzgb.Newd2CO = dt.Rows[0]["Newd2CO"].ToString();
                    sds_xzgb.Newd2HC = dt.Rows[0]["Newd2HC"].ToString();
                    sds_xzgb.zxDate1995070120040901CO = dt.Rows[0]["zxDate1995070120040901CO"].ToString();
                    sds_xzgb.zxDate1995070120040901HC = dt.Rows[0]["zxDate1995070120040901HC"].ToString();

                    sds_xzgb.zxDate19950701qCO = dt.Rows[0]["zxDate19950701qCO"].ToString();
                    sds_xzgb.zxDate19950701qHC = dt.Rows[0]["zxDate19950701qHC"].ToString();
                    sds_xzgb.zxDate20040901CO = dt.Rows[0]["zxDate20040901CO"].ToString();
                    sds_xzgb.zxDate20040901HC = dt.Rows[0]["zxDate20040901HC"].ToString();
                    sds_xzgb.zxHNewCO = dt.Rows[0]["zxHNewCO"].ToString();
                    sds_xzgb.zxHNewHC = dt.Rows[0]["zxHNewHC"].ToString();
                    sds_xzgb.zxNewCO = dt.Rows[0]["zxNewCO"].ToString();
                    sds_xzgb.zxNewHC = dt.Rows[0]["zxNewHC"].ToString();

                }
                return sds_xzgb;
            }
            catch (Exception)
            { 
                throw;
            }
        }
        #endregion
        #region 查询一条广东ASM限值
        public ASM_GDXZ Get_GDXZ(String ID)
        {
            string sql = "select * from ASM_GDXZ where ID='"+ID+"'";
            ASM_GDXZ sds_xzgb = new ASM_GDXZ();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    sds_xzgb.ID = dt.Rows[0]["ID"].ToString();
                    sds_xzgb.CO25 = dt.Rows[0]["CO25"].ToString();
                    sds_xzgb.HC25 = dt.Rows[0]["HC25"].ToString();
                    sds_xzgb.NO25 = dt.Rows[0]["NO25"].ToString();
                    sds_xzgb.CO40 = dt.Rows[0]["CO40"].ToString();
                    sds_xzgb.HC40 = dt.Rows[0]["HC40"].ToString();
                    sds_xzgb.NO40 = dt.Rows[0]["NO40"].ToString();
                    return sds_xzgb;
                }
                else
                { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条甘肃ASM限值
        public ASM_GDXZ Get_GSXZ(string AREA,string PFBZ,int RM)
        {
            string sql = "select * from ASM_GSXZ where AREA='" + AREA + "' and PFBZ='"+PFBZ+"' AND MINRM<"+ RM + " AND MAXRM>="+ RM;
            ASM_GDXZ sds_xzgb = new ASM_GDXZ();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    sds_xzgb.ID = dt.Rows[0]["ID"].ToString();
                    sds_xzgb.CO25 = dt.Rows[0]["CO25"].ToString();
                    sds_xzgb.HC25 = dt.Rows[0]["HC25"].ToString();
                    sds_xzgb.NO25 = dt.Rows[0]["NO25"].ToString();
                    sds_xzgb.CO40 = dt.Rows[0]["CO40"].ToString();
                    sds_xzgb.HC40 = dt.Rows[0]["HC40"].ToString();
                    sds_xzgb.NO40 = dt.Rows[0]["NO40"].ToString();
                    return sds_xzgb;
                }
                else
                { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条ASM限值
        public ASM_XZDB Get_ASM_XZDB(string ID)
        {
            string sql = "select * from ASM_XZDB where id='"+ID+"'";
            ASM_XZDB asm_xzdb = new ASM_XZDB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    asm_xzdb.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    asm_xzdb.HC5025 = double.Parse(dt.Rows[0]["d1Date20000701qHC5025"].ToString());
                    asm_xzdb.CO5025 = double.Parse(dt.Rows[0]["d1Date20000701qCO5025"].ToString());
                    asm_xzdb.NO5025 = double.Parse(dt.Rows[0]["d1Date20000701qNO5025"].ToString());
                    asm_xzdb.HC2540 = double.Parse(dt.Rows[0]["d1Date20000701qHC2540"].ToString());
                    asm_xzdb.CO2540 = double.Parse(dt.Rows[0]["d1Date20000701qCO2540"].ToString());
                    asm_xzdb.NO2540 = double.Parse(dt.Rows[0]["d1Date20000701qNO2540"].ToString());
                    asm_xzdb.HC5025H = double.Parse(dt.Rows[0]["d1Date20000701HC5025"].ToString());
                    asm_xzdb.CO5025H = double.Parse(dt.Rows[0]["d1Date20000701CO5025"].ToString());
                    asm_xzdb.NO5025H = double.Parse(dt.Rows[0]["d1Date20000701NO5025"].ToString());
                    asm_xzdb.HC2540H = double.Parse(dt.Rows[0]["d1Date20000701HC2540"].ToString());
                    asm_xzdb.CO2540H = double.Parse(dt.Rows[0]["d1Date20000701CO2540"].ToString());
                    asm_xzdb.NO2540H = double.Parse(dt.Rows[0]["d1Date20000701NO2540"].ToString());
                    
                }
                return asm_xzdb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条VMAS限值
        public VMAS_XZDB Get_VMAS_XZDB()
        {
            string sql = "select * from VMAS_XZDB";
            VMAS_XZDB vmas_xzdb = new VMAS_XZDB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    vmas_xzdb.S1020d1date20000701bhc = dt.Rows[0]["S1020d120000701bhc"].ToString();
                    vmas_xzdb.S1020d1date20000701bco = dt.Rows[0]["S1020d120000701bco"].ToString();
                    vmas_xzdb.S1020d1date20000701bno = dt.Rows[0]["S1020d120000701bnox"].ToString();
                    vmas_xzdb.S10201470d1date20000701bhc = dt.Rows[0]["S10201470d120000701bhc"].ToString();
                    vmas_xzdb.S10201470d1date20000701bco = dt.Rows[0]["S10201470d120000701bco"].ToString();
                    vmas_xzdb.S10201470d1date20000701bno = dt.Rows[0]["S10201470d120000701bnox"].ToString();
                    vmas_xzdb.S14701930d1date20000701bhc = dt.Rows[0]["S14701930d120000701bhc"].ToString();
                    vmas_xzdb.S14701930d1date20000701bco = dt.Rows[0]["S14701930d120000701bco"].ToString();
                    vmas_xzdb.S14701930d1date20000701bno = dt.Rows[0]["S14701930d120000701bnox"].ToString();
                    vmas_xzdb.S1930d1date20000701bhc = dt.Rows[0]["S1930d120000701bhc"].ToString();
                    vmas_xzdb.S1930d1date20000701bco = dt.Rows[0]["S1930d120000701bco"].ToString();
                    vmas_xzdb.S1930d1date20000701bno = dt.Rows[0]["S1930d120000701bnox"].ToString();

                    vmas_xzdb.S1020d2date20011001bhc = dt.Rows[0]["S1020d220011001bhc"].ToString();
                    vmas_xzdb.S1020d2date20011001bco = dt.Rows[0]["S1020d220011001bco"].ToString();
                    vmas_xzdb.S1020d2date20011001bno = dt.Rows[0]["S1020d220011001bnox"].ToString();
                    vmas_xzdb.S10201470d2date20011001bhc = dt.Rows[0]["S10201470d220011001bhc"].ToString();
                    vmas_xzdb.S10201470d2date20011001bco = dt.Rows[0]["S10201470d220011001bco"].ToString();
                    vmas_xzdb.S10201470d2date20011001bno = dt.Rows[0]["S10201470d220011001bnox"].ToString();

                    vmas_xzdb.S14701930d2date20011001bhc = dt.Rows[0]["S14701930d220011001bhc"].ToString();
                    vmas_xzdb.S14701930d2date20011001bco = dt.Rows[0]["S14701930d220011001bco"].ToString();
                    vmas_xzdb.S14701930d2date20011001bno = dt.Rows[0]["S14701930d220011001bnox"].ToString();
                    vmas_xzdb.S1930d2date20011001bhc = dt.Rows[0]["S1930d220011001bhc"].ToString();
                    vmas_xzdb.S1930d2date20011001bco = dt.Rows[0]["S1930d220011001bco"].ToString();
                    vmas_xzdb.S1930d2date20011001bno = dt.Rows[0]["S1930d220011001bnox"].ToString();

                    vmas_xzdb.S1250d1date20000701ahcnox = dt.Rows[0]["S1250d120000701ahcnox"].ToString();
                    vmas_xzdb.S1250d1date20000701aco = dt.Rows[0]["S1250d120000701aco"].ToString();
                    vmas_xzdb.S12501700d1date20000701ahcnox = dt.Rows[0]["S12501700d120000701ahcnox"].ToString();
                    vmas_xzdb.S12501700d1date20000701aco = dt.Rows[0]["S12501700d120000701aco"].ToString();
                    vmas_xzdb.S1700d1date20000701ahcnox = dt.Rows[0]["S1700d120000701ahcnox"].ToString();
                    vmas_xzdb.S1700d1date20000701aco = dt.Rows[0]["S1700d120000701aco"].ToString();

                    vmas_xzdb.S1250d2date20011001ahcnox = dt.Rows[0]["S1250d220011001ahcnox"].ToString();
                    vmas_xzdb.S1250d2date20011001aco = dt.Rows[0]["S1250d220011001aco"].ToString();
                    vmas_xzdb.S12501700d2date20011001ahcnox = dt.Rows[0]["S12501700d220011001ahcnox"].ToString();
                    vmas_xzdb.S12501700d2date20011001aco = dt.Rows[0]["S12501700d220011001aco"].ToString();
                    vmas_xzdb.S1700d2date20011001ahcnox = dt.Rows[0]["S1700d220011001ahcnox"].ToString();
                    vmas_xzdb.S1700d2date20011001aco = dt.Rows[0]["S1700d220011001aco"].ToString();
                }
                return vmas_xzdb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据id号查询一条VMAS限值
        public VMAS_XZBZ Get_VMAS_XZBZ(string ID)
        {
            string sql = "select * from VMAS_XZBZ where id='"+ID+"'";
            VMAS_XZBZ vmas_xzdb = new VMAS_XZBZ();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    vmas_xzdb.S1020bco = dt.Rows[0]["S1020bco"].ToString();
                    vmas_xzdb.S10201470bco = dt.Rows[0]["S10201470bco"].ToString();
                    vmas_xzdb.S14701930bco = dt.Rows[0]["S14701930bco"].ToString();
                    vmas_xzdb.S1930bco = dt.Rows[0]["S1930bco"].ToString();
                    vmas_xzdb.S1020bhc = dt.Rows[0]["S1020bhc"].ToString();
                    vmas_xzdb.S10201470bhc = dt.Rows[0]["S10201470bhc"].ToString();
                    vmas_xzdb.S14701930bhc = dt.Rows[0]["S14701930bhc"].ToString();
                    vmas_xzdb.S1930bhc = dt.Rows[0]["S1930bhc"].ToString();
                    vmas_xzdb.S1020bno = dt.Rows[0]["S1020bno"].ToString();
                    vmas_xzdb.S10201470bno = dt.Rows[0]["S10201470bno"].ToString();
                    vmas_xzdb.S14701930bno = dt.Rows[0]["S14701930bno"].ToString();
                    vmas_xzdb.S1930bno = dt.Rows[0]["S1930bno"].ToString();

                    vmas_xzdb.Sg1d1co = dt.Rows[0]["Sg1d1co"].ToString();
                    vmas_xzdb.S1250g1d2co = dt.Rows[0]["S1250g1d2co"].ToString();
                    vmas_xzdb.S12501700g1d2co = dt.Rows[0]["S12501700g1d2co"].ToString();
                    vmas_xzdb.S1700g1d2co = dt.Rows[0]["S1700g1d2co"].ToString();
                    vmas_xzdb.Sg1d1hcnox = dt.Rows[0]["Sg1d1hcnox"].ToString();
                    vmas_xzdb.S1250g1d2hcnox = dt.Rows[0]["S1250g1d2hcnox"].ToString();
                    vmas_xzdb.S12501700g1d2hcnox = dt.Rows[0]["S12501700g1d2hcnox"].ToString();
                    vmas_xzdb.S1700g1d2hcnox = dt.Rows[0]["S1700g1d2hcnox"].ToString();

                    vmas_xzdb.Sg2d1co = dt.Rows[0]["Sg2d1co"].ToString();
                    vmas_xzdb.S1250g2d2co = dt.Rows[0]["S1250g2d2co"].ToString();
                    vmas_xzdb.S12501700g2d2co = dt.Rows[0]["S12501700g2d2co"].ToString();
                    vmas_xzdb.S1700g2d2co = dt.Rows[0]["S1700g2d2co"].ToString();
                    vmas_xzdb.Sg2d1hcnox = dt.Rows[0]["Sg2d1hcnox"].ToString();
                    vmas_xzdb.S1250g2d2hcnox = dt.Rows[0]["S1250g2d2hcnox"].ToString();
                    vmas_xzdb.S12501700g2d2hcnox = dt.Rows[0]["S12501700g2d2hcnox"].ToString();
                    vmas_xzdb.S1700g2d2hcnox = dt.Rows[0]["S1700g2d2hcnox"].ToString();

                    vmas_xzdb.Sg3d1co = dt.Rows[0]["Sg3d1co"].ToString();
                    vmas_xzdb.S1250g3d2co = dt.Rows[0]["S1250g3d2co"].ToString();
                    vmas_xzdb.S12501700g3d2co = dt.Rows[0]["S12501700g3d2co"].ToString();
                    vmas_xzdb.S1700g3d2co = dt.Rows[0]["S1700g3d2co"].ToString();
                    vmas_xzdb.Sg3d1hcnox = dt.Rows[0]["Sg3d1hcnox"].ToString();
                    vmas_xzdb.S1250g3d2hcnox = dt.Rows[0]["S1250g3d2hcnox"].ToString();
                    vmas_xzdb.S12501700g3d2hcnox = dt.Rows[0]["S12501700g3d2hcnox"].ToString();
                    vmas_xzdb.S1700g3d2hcnox = dt.Rows[0]["S1700g3d2hcnox"].ToString();

                    vmas_xzdb.Sg4d1co = dt.Rows[0]["Sg4d1co"].ToString();
                    vmas_xzdb.S1250g4d2co = dt.Rows[0]["S1250g4d2co"].ToString();
                    vmas_xzdb.S12501700g4d2co = dt.Rows[0]["S12501700g4d2co"].ToString();
                    vmas_xzdb.S1700g4d2co = dt.Rows[0]["S1700g4d2co"].ToString();
                    vmas_xzdb.Sg4d1hcnox = dt.Rows[0]["Sg4d1hcnox"].ToString();
                    vmas_xzdb.S1250g4d2hcnox = dt.Rows[0]["S1250g4d2hcnox"].ToString();
                    vmas_xzdb.S12501700g4d2hcnox = dt.Rows[0]["S12501700g4d2hcnox"].ToString();
                    vmas_xzdb.S1700g4d2hcnox = dt.Rows[0]["S1700g4d2hcnox"].ToString();
                }
                else
                {
                    vmas_xzdb.Id = "-2";
                }
                return vmas_xzdb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据id号查询一条VMAS限值
        public DataTable Get_ALL_VMAS_XZBZ()
        {
            string sql = "select * from VMAS_XZBZ";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);                
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据id号查询一条VMAS限值
        public DataTable Get_ALL_BTG_XZBZ(int btgxztable)
        {
            string sql = "";if (btgxztable == 0) sql = "select * from [不透光限值]"; else sql = "select * from [烟度限值数据]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 根据id号查询一条VMAS限值
        public DataTable Get_ALL_ASM_XZBZ()
        {
            string sql = "select * from ASM_XZDB";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据id号查询一条VMAS限值
        public DataTable Get_ALL_SDS_XZBZ()
        {
            string sql = "select * from SDS_XZGB";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 根据id号查询一条VMAS限值
        public DataTable Get_ALL_JZJS_XZBZ()
        {
            string sql = "select * from JZJS_XZDB";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条VMAS在50km/h等速时吸收驱动轮上的功率
        public VMAS_XSGLZ Get_VMAS_XSGL()
        {
            string sql = "select * from VMAS_XSGL";
            VMAS_XSGLZ vmas_xsglz = new VMAS_XSGLZ();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    vmas_xsglz.RM750 = float.Parse(dt.Rows[0]["RM750"].ToString());
                    vmas_xsglz.RM750850 = float.Parse(dt.Rows[0]["RM750850"].ToString());
                    vmas_xsglz.RM8501020 = float.Parse(dt.Rows[0]["RM8501020"].ToString());
                    vmas_xsglz.RM10201250 = float.Parse(dt.Rows[0]["RM10201250"].ToString());
                    vmas_xsglz.RM12501470 = float.Parse(dt.Rows[0]["RM12501470"].ToString());
                    vmas_xsglz.RM14701700 = float.Parse(dt.Rows[0]["RM14701700"].ToString());
                    vmas_xsglz.RM17001930 = float.Parse(dt.Rows[0]["RM17001930"].ToString());
                    vmas_xsglz.RM19302150 = float.Parse(dt.Rows[0]["RM19302150"].ToString());
                    vmas_xsglz.RM21502380 = float.Parse(dt.Rows[0]["RM21502380"].ToString());
                    vmas_xsglz.RM23802610 = float.Parse(dt.Rows[0]["RM23802610"].ToString());
                    vmas_xsglz.RM2610 = float.Parse(dt.Rows[0]["RM2610"].ToString());
                }
                return vmas_xsglz;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条加载减速限值地标
        /// <summary>
        /// 查询一条加载减速限值地标
        /// </summary>
        /// <returns>JZJS_XZDB</returns>
        public JZJS_XZDB Get_JZJS_XZDB()
        {
            string sql = "select * from JZJS_XZDB";
            JZJS_XZDB jzjs_xzdb = new JZJS_XZDB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    jzjs_xzdb.d1Date20000701b = dt.Rows[0]["d1Date20000701b"].ToString();
                    jzjs_xzdb.d1Date2000070120050630 = dt.Rows[0]["d1Date2000070120050630"].ToString();
                    jzjs_xzdb.d1Date20050701 = dt.Rows[0]["d1Date20050701"].ToString();
                    jzjs_xzdb.d2Date20011001b = dt.Rows[0]["d2Date20011001b"].ToString();
                    jzjs_xzdb.d2Date2001100120060630 = dt.Rows[0]["d2Date2001100120060630"].ToString();
                    jzjs_xzdb.d2Date20060701 = dt.Rows[0]["d2Date20060701"].ToString();
                    jzjs_xzdb.zxDate20010901b = dt.Rows[0]["zxDate20010901b"].ToString();
                    jzjs_xzdb.zxDate2001090120040831 = dt.Rows[0]["zxDate2001090120040831"].ToString();
                    jzjs_xzdb.zxDate20040901 = dt.Rows[0]["zxDate20040901"].ToString();
                }
                return jzjs_xzdb;
            }
            catch (Exception)
            {
                throw ;
            }

        }
        #endregion
        #region 查询一条加载减速限值地标
        /// <summary>
        /// 查询一条加载减速限值地标
        /// </summary>
        /// <returns>JZJS_XZDB</returns>
        public JZJS_XZBZ Get_JZJS_XZDB(string id)
        {
            string sql = "select * from JZJS_XZBZ where id='" + id + "'";
            JZJS_XZBZ jzjs_xzdb = new JZJS_XZBZ();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    jzjs_xzdb.G1XZ = dt.Rows[0]["G1XZ"].ToString();
                    jzjs_xzdb.G2XZ = dt.Rows[0]["G2XZ"].ToString();
                    jzjs_xzdb.G3XZ = dt.Rows[0]["G3XZ"].ToString();
                    jzjs_xzdb.G4XZ = dt.Rows[0]["G4XZ"].ToString();
                }
                else
                {
                    jzjs_xzdb.ID = "-2";
                }
                return jzjs_xzdb;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 查询一条自由加速限值国标
        /// <summary>
        /// 查询一条自由加速限值国标
        /// </summary>
        /// <returns>ZYJS_XZGB</returns>
        public ZYJS_XZGB Get_ZYJS_XZGB()
        {
            string sql = "select * from ZYJS_XZGB";
            ZYJS_XZGB zyjs_xzgb = new ZYJS_XZGB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    zyjs_xzgb.ZRDate20011001btgxz = dt.Rows[0]["ZRDate20011001btgxz"].ToString();
                    zyjs_xzgb.WLDate20011001btgxz = dt.Rows[0]["WLDate20011001btgxz"].ToString();
                    if (dt.Columns.Contains("ONLYTHIS"))
                    {
                        zyjs_xzgb.onlyUseThis = (dt.Rows[0]["ONLYTHIS"].ToString() == "Y");
                    }
                    else
                        zyjs_xzgb.onlyUseThis = true;
                    if (dt.Columns.Contains("XZTABLE"))
                    {
                        try
                        {
                            zyjs_xzgb.XZTABLE = int.Parse(dt.Rows[0]["XZTABLE"].ToString());
                        }
                        catch
                        { zyjs_xzgb.XZTABLE = 0; }
                    }
                    else
                        zyjs_xzgb.XZTABLE = 0;
                    if (dt.Columns.Contains("BTGXZBZ"))
                    {
                        try
                        {
                            zyjs_xzgb.BTGXZBZ = int.Parse(dt.Rows[0]["BTGXZBZ"].ToString());
                        }
                        catch
                        { zyjs_xzgb.BTGXZBZ = 0; }
                    }
                    else
                        zyjs_xzgb.BTGXZBZ = 0;
                }
                return zyjs_xzgb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 查询一条自由加速限值国标
        /// <summary>
        /// 查询一条自由加速限值国标
        /// </summary>
        /// <returns>ZYJS_XZGB</returns>
        public  bool updateZYJS_XZGB(ZYJS_XZGB model)
        {
            string sql = "update ZYJS_XZGB set ZRDate20011001btgxz=@ZRDate20011001btgxz,WLDate20011001btgxz=@WLDate20011001btgxz,ONLYTHIS=@ONLYTHIS,XZTABLE=@XZTABLE,BTGXZBZ=@BTGXZBZ";
            SqlParameter[] spr ={
                                   new SqlParameter("@ZRDate20011001btgxz",model.ZRDate20011001btgxz), //1
                                   new SqlParameter("@WLDate20011001btgxz",model.WLDate20011001btgxz),
                                   new SqlParameter("@ONLYTHIS",model.onlyUseThis?"Y":"N"),
                                   new SqlParameter("@XZTABLE",model.XZTABLE.ToString("0")),
                                   new SqlParameter("@BTGXZBZ",model.BTGXZBZ.ToString("0"))
                               };
            try
            {
                    if (DBHelperSQL.Execute(sql, spr) > 0)
                        return true;
                    else
                        return false;
                
            }            
            catch (Exception er)
            {
                throw;
            }
        }
        #endregion

        #region 按发动机型号查询一条自由加速限值国标
        /// <summary>
        /// 按条件匹配，取最小值
        /// </summary>
        /// <param name="fdjxh">发动机型号</param>
        /// <param name="clxh">车辆型号</param>
        /// <param name="lx">类型 0：联合查询 1：按发动机型号查询  2：按车辆型号查询  </param>
        /// <returns></returns>
        public bool Get_BTG_XZGB(String fdjxh,string clxh,int lx,out double xz)
        {
            xz = 0;
            string sql = "";
            if (lx == 0)
                sql = "select 限值 from [不透光限值] where UPPER(发动机型号)='" + fdjxh.ToUpper() + "' and UPPER(车辆型号)='" + clxh.ToUpper() + "'";
            else if (lx == 1)
                sql = "select 限值 from [不透光限值] where UPPER(发动机型号)='" + fdjxh.ToUpper() +"'";
            else
                sql = "select 限值 from [不透光限值] where UPPER(车辆型号)='" + clxh.ToUpper() + "'";
            ini.INIIO.saveLogInf("查询不透光限值语句：" + sql);
            BTG_XZGB zyjs_xzgb = new BTG_XZGB();
            try 
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    List<double> xzlist = new List<double>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xzlist.Add(double.Parse(dt.Rows[i]["限值"].ToString()));
                        ini.INIIO.saveLogInf("找到匹配限值" + i.ToString() + ":" + dt.Rows[i]["限值"].ToString());
                    }
                    xz = xzlist.Min();
                    ini.INIIO.saveLogInf("返回限值"+ ":" + xz.ToString());
                    return true;
                }
                else
                    return false;
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("查询限值过程发生异常" + ":" + er.Message);
                return false;
            }
        }
        #endregion
        #region 金华地区按发动机型号查询一条自由加速限值国标
        /// <summary>
        /// 按条件匹配，取最小值
        /// </summary>
        /// <param name="fdjxh">发动机型号</param>
        /// <param name="clxh">车辆型号</param>
        /// <param name="lx">类型 0：联合查询 1：按发动机型号查询  2：按车辆型号查询  </param>
        /// <returns></returns>
        public bool Get_BTG_XZGB_JH(String fdjxh, string clxh, int lx, int type,string edgl, out double xz)
        {
            xz = 0;
            string sql = "";
            if (lx == 0)
                sql = "select LIMITVALUE from [烟度限值数据] where UPPER(ENGINEMODEL)='" + fdjxh.ToUpper() + "' and UPPER(VEHICLEMODEL)='" + clxh.ToUpper() + "' and SMOKEVTYPE='" + type+"'";
            else if (lx == 1)
                sql = "select LIMITVALUE from [烟度限值数据] where UPPER(ENGINEMODEL)='" + fdjxh.ToUpper() + "' and SMOKEVTYPE='" + type + "'";
            else if (lx == 2)
                sql = "select LIMITVALUE from [烟度限值数据] where UPPER(ENGINEMODEL)='" + fdjxh.ToUpper() + "' and SMOKEVTYPE='" + type + "' and MAXNETPOWER=" + edgl;
            else
                sql = "select LIMITVALUE from [烟度限值数据] where UPPER(VEHICLEMODEL)='" + clxh.ToUpper() + "' and SMOKEVTYPE='" + type + "'";
            ini.INIIO.saveLogInf("查询不透光限值语句：" + sql);
            BTG_XZGB zyjs_xzgb = new BTG_XZGB();
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    List<double> xzlist = new List<double>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        xzlist.Add(double.Parse(dt.Rows[i]["LIMITVALUE"].ToString()));
                        ini.INIIO.saveLogInf("找到匹配限值" + i.ToString() + ":" + dt.Rows[i]["LIMITVALUE"].ToString());
                    }
                    xz = xzlist.Min();
                    ini.INIIO.saveLogInf("返回限值" + ":" + xz.ToString());
                    return true;
                }
                else
                    return false;
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("查询限值过程发生异常" + ":" + er.Message);
                return false;
            }
        }
        #endregion
        #region 保存废气仪检查
        public bool saveBtgXz(string clxh,string cllx,string fdjxh,string fdjscqy,string xshzz,string xz,string qcscqy)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [不透光限值] (");
            strSql.Append("车辆型号,");//=@PZLX,");1
            strSql.Append("车辆类型,");//=@JCCLPH,");2
            strSql.Append("发动机型号,");//=@CLXHBH,");3
            strSql.Append("发动机生产企业,");//=@CLXHBH,");3
            strSql.Append("形式核准值,");//=@JCCS,");4
            strSql.Append("限值,");//=@CCRQ,");5
            strSql.Append("汽车生产企业) ");//=@DJRQ,"); 6
            strSql.Append("values (@clxh,@cllx,@fdjxh,@fdjscqy,@xshzz,@xz,@qcscqy)");
            SqlParameter[] parameters = {
                    new SqlParameter("@clxh", SqlDbType.VarChar,255),
                    new SqlParameter("@cllx", SqlDbType.VarChar,255),
                    new SqlParameter("@fdjxh",SqlDbType.VarChar,255),
                    new SqlParameter("@fdjscqy",SqlDbType.VarChar,255),
                    new SqlParameter("@xshzz", SqlDbType.VarChar,50),
                    new SqlParameter("@xz", SqlDbType.VarChar,50),
                    new SqlParameter("@qcscqy", SqlDbType.VarChar,255)};
            parameters[i++].Value = clxh;
            parameters[i++].Value = cllx;
            parameters[i++].Value = fdjxh;
            parameters[i++].Value = fdjscqy;
            parameters[i++].Value = xshzz;
            parameters[i++].Value = xz;
            parameters[i++].Value = qcscqy;
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
        #endregion

    }
}
