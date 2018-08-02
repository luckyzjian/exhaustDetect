using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class JZJSdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_JZJS(string CLID)
        {
            string sql = "select * from JZJS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
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
        public bool Delete_JZJS(string CLID)
        {
            string sql = "delete JZJS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
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

        #region 用JZJS对象插入或更新条检测数据
        /// <summary>
        /// 用JZJS对象插入或更新条检测数据
        /// </summary>
        /// <param name="JZJS">JZJS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_JZJS(JZJS jzjs)
        {
            string sqli = "insert into jzjs(GLXZXS,ACTMAXHP,REALVELMAXHP,VELMAXHP,VELMAXHPZS,RATEREVUP,RATEREVDOWN,JYLSH,JYCS,SBRZBM,CLID,CLPH,HK,NK,EK,HNO,NNO,ENO,YDXZ,HKPD,NKPD,EKPD,MAXLBGL,GLXZ,GLPD,MAXLBZS,ZSXZ,ZSPD,ZHPD,JCRQ,WD,SD,DQY,SBMC,SBXH,SBZZC,CGJXH,CGJBH,CGJZZC,YDJXH,YDJBH,YDJZZC,ZSJXH,ZSJBH,ZSJZZC) values(@GLXZXS,@ACTMAXHP,@REALVELMAXHP,@VELMAXHP,@VELMAXHPZS,@RATEREVUP,@RATEREVDOWN,@JYLSH,@JYCS,@SBRZBM,@CLID,@CLPH,@HK,@NK,@EK,@HNO,@NNO,@ENO,@YDXZ,@HKPD,@NKPD,@EKPD,@MAXLBGL,@GLXZ,@GLPD,@MAXLBZS,@ZSXZ,@ZSPD,@ZHPD,@JCRQ,@WD,@SD,@DQY,@SBMC,@SBXH,@SBZZC,@CGJXH,@CGJBH,@CGJZZC,@YDJXH,@YDJBH,@YDJZZC,@ZSJXH,@ZSJBH,@ZSJZZC)";
            string sqlu = "update jzjs set GLXZXS=@GLXZXS,ACTMAXHP=@ACTMAXHP,REALVELMAXHP=@REALVELMAXHP,VELMAXHP=@VELMAXHP,VELMAXHPZS=@VELMAXHPZS,RATEREVUP=@RATEREVUP,RATEREVDOWN=@RATEREVDOWN,JYLSH=@JYLSH,JYCS=@JYCS,SBRZBM=@SBRZBM,CLPH=@CLPH,HK=@HK,NK=@NK,EK=@EK,HNO=@HNO,NNO=@NNO,ENO=@ENO,YDXZ=@YDXZ,HKPD=@HKPD,NKPD=@NKPD,EKPD=@EKPD,MAXLBGL=@MAXLBGL,GLXZ=@GLXZ,GLPD=@GLPD,MAXLBZS=@MAXLBZS,ZSXZ=@ZSXZ,ZSPD=@ZSPD,ZHPD=@ZHPD,JCRQ=@JCRQ,WD=@WD,SD=@SD,DQY=@DQY,SBMC=@SBMC,SBXH=@SBXH,SBZZC=@SBZZC,CGJXH=@CGJXH,CGJBH=@CGJBH,CGJZZC=@CGJZZC,YDJXH=@YDJXH,YDJBH=@YDJBH,YDJZZC=@YDJZZC,ZSJXH=@ZSJXH,ZSJBH=@ZSJBH,ZSJZZC=@ZSJZZC where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@GLXZXS",jzjs.GLXZXS),
                                   new SqlParameter("@ACTMAXHP",jzjs.ACTMAXHP),
                                   new SqlParameter("@REALVELMAXHP",jzjs.REALVELMAXHP),
                                   new SqlParameter("@VELMAXHP",jzjs.VELMAXHP),
                                   new SqlParameter("@VELMAXHPZS",jzjs.VELMAXHPZS),
                                   new SqlParameter("@RATEREVUP",jzjs.RATEREVUP),
                                   new SqlParameter("@RATEREVDOWN",jzjs.RATEREVDOWN),
                                   new SqlParameter("@JYLSH",jzjs.JYLSH),
                                   new SqlParameter("@JYCS",jzjs.JYCS),
                                   new SqlParameter("@SBRZBM",jzjs.SBRZBM),

                                   new SqlParameter("@CLID",jzjs.CLID), //1
                                   new SqlParameter("@CLPH",jzjs.CLPH),
                                   new SqlParameter("@HK",jzjs.HK),
                                   new SqlParameter("@NK",jzjs.NK),
                                   new SqlParameter("@EK",jzjs.EK),
                                   new SqlParameter("@HNO",jzjs.HNO),
                                   new SqlParameter("@NNO",jzjs.NNO),
                                   new SqlParameter("@ENO",jzjs.ENO),
                                   new SqlParameter("@YDXZ",jzjs.YDXZ),//6
                                   new SqlParameter("@HKPD",jzjs.HKPD),
                                   new SqlParameter("@NKPD",jzjs.NKPD),
                                   new SqlParameter("@EKPD",jzjs.EKPD),
                                   new SqlParameter("@MAXLBGL",jzjs.MAXLBGL),
                                   new SqlParameter("@GLXZ",jzjs.GLXZ),
                                   new SqlParameter("@GLPD",jzjs.GLPD),
                                   new SqlParameter("@MAXLBZS",jzjs.MAXLBZS),//11
                                   new SqlParameter("@ZSXZ",jzjs.ZSXZ),
                                   new SqlParameter("@ZSPD",jzjs.ZSPD),
                                   new SqlParameter("@ZHPD",jzjs.ZHPD),
                                   new SqlParameter("@JCRQ",jzjs.JCRQ),
                                   new SqlParameter("@WD",jzjs.WD),
                                   new SqlParameter("@SD",jzjs.SD),
                                   new SqlParameter("@DQY",jzjs.DQY),//16
                                   new SqlParameter("@SBMC",jzjs.SBMC),
                                   new SqlParameter("@SBXH",jzjs.SBXH),
                                   new SqlParameter("@SBZZC",jzjs.SBZZC),
                                   new SqlParameter("@CGJXH",jzjs.CGJXH),
                                   new SqlParameter("@CGJBH",jzjs.CGJBH),//21
                                   new SqlParameter("@CGJZZC",jzjs.CGJZZC),
                                   new SqlParameter("@YDJXH",jzjs.YDJXH),
                                   new SqlParameter("@YDJBH",jzjs.YDJBH),
                                   new SqlParameter("@YDJZZC",jzjs.YDJZZC),
                                   new SqlParameter("@ZSJXH",jzjs.ZSJXH),
                                   new SqlParameter("@ZSJBH",jzjs.ZSJBH),
                                   new SqlParameter("@ZSJZZC",jzjs.ZSJZZC)//47
                               };
            try
            {
                if (Have_JZJS(jzjs.CLID))
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
        /// <returns>JZJS检测数据Model</returns>
        public JZJS Get_JZJS(string CLID)
        {
            DateTime a;
            string sql = "select * from JZJS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                JZJS JZJS = new JZJS();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    JZJS.CLID = dt.Rows[0]["CLID"].ToString();//1
                    JZJS.CLPH = dt.Rows[0]["CLPH"].ToString();
                    JZJS.HK = dt.Rows[0]["HK"].ToString();
                    JZJS.NK = dt.Rows[0]["NK"].ToString();
                    JZJS.EK = dt.Rows[0]["EK"].ToString();
                    JZJS.YDXZ = dt.Rows[0]["YDXZ"].ToString();//6
                    JZJS.HKPD = dt.Rows[0]["HKPD"].ToString();
                    JZJS.NKPD = dt.Rows[0]["NKPD"].ToString();
                    JZJS.EKPD = dt.Rows[0]["EKPD"].ToString();
                    JZJS.MAXLBGL = dt.Rows[0]["MAXLBGL"].ToString();
                    JZJS.GLXZ = dt.Rows[0]["GLXZ"].ToString();
                    JZJS.GLPD = dt.Rows[0]["GLPD"].ToString();
                    JZJS.MAXLBZS = dt.Rows[0]["MAXLBZS"].ToString();//11
                    JZJS.ZSXZ = dt.Rows[0]["ZSXZ"].ToString();//11
                    JZJS.ZSPD = dt.Rows[0]["ZSPD"].ToString();//11
                    JZJS.ZHPD = dt.Rows[0]["ZHPD"].ToString();
                    DateTime.TryParse(dt.Rows[0]["JCRQ"].ToString(), out a);
                    if (a != null)
                        JZJS.JCRQ = a;
                    else
                        JZJS.JCRQ = DateTime.Today;
                    JZJS.WD = dt.Rows[0]["WD"].ToString();
                    JZJS.SD = dt.Rows[0]["SD"].ToString();
                    JZJS.DQY = dt.Rows[0]["DQY"].ToString();//16
                    JZJS.SBMC = dt.Rows[0]["SBMC"].ToString();
                    JZJS.SBXH = dt.Rows[0]["SBXH"].ToString();
                    JZJS.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    JZJS.CGJXH = dt.Rows[0]["CGJXH"].ToString();
                    JZJS.CGJBH = dt.Rows[0]["CGJBH"].ToString();//21
                    JZJS.CGJZZC = dt.Rows[0]["CGJZZC"].ToString();
                    JZJS.YDJXH = dt.Rows[0]["YDJXH"].ToString();
                    JZJS.YDJBH = dt.Rows[0]["YDJBH"].ToString();
                    JZJS.YDJZZC = dt.Rows[0]["YDJZZC"].ToString();
                    JZJS.ZSJXH = dt.Rows[0]["ZSJXH"].ToString();
                    JZJS.ZSJBH = dt.Rows[0]["ZSJBH"].ToString();
                    JZJS.ZSJZZC = dt.Rows[0]["ZSJZZC"].ToString();
                }
                else
                {
                    JZJS.CLID = "-2";
                }
                return JZJS;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_JZJSseconds(string CLID)
        {
            string sql = "select * from JZJS_DATASECONDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
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

        #region 插入逐秒数据
        /// <summary>
        /// 用JZJS插入逐秒数据
        /// </summary>
        /// <param name="JZJS">JZJS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_JZJSseconds(JZJSseconds jzjs)
        {
            string sqli = "insert into JZJS_DATASECONDS(JYLSH,JYCS,CYDS,MMZS,MMZGL,MMZSGL,MMGLXZXS,MMJSGL,MMBTGD,MMDQYL,MMXDSD,MMHJWD,MMNL,CLID,CLHP,JCSJ,MMTIME,MMSX,MMLB,MMCS,MMGL,MMK,MMNO) values(@JYLSH,@JYCS,@CYDS,@MMZS,@MMZGL,@MMZSGL,@MMGLXZXS,@MMJSGL,@MMBTGD,@MMDQYL,@MMXDSD,@MMHJWD,@MMNL,@CLID,@CLHP,@JCSJ,@MMTIME,@MMSX,@MMLB,@MMCS,@MMGL,@MMK,@MMNO)";
            string sqlu = "update JZJS_DATASECONDS set JYLSH=@JYLSH,JYCS=@JYCS,CYDS=@CYDS,MMZS=@MMZS,MMZGL=@MMZGL,MMZSGL=@MMZSGL,MMGLXZXS=@MMGLXZXS,MMJSGL=@MMJSGL,MMBTGD=@MMBTGD,MMDQYL=@MMDQYL,MMXDSD=@MMXDSD,MMHJWD=@MMHJWD,MMNL=@MMNL,CLHP=@CLHP,JCSJ=@JCSJ,MMTIME=@MMTIME,MMSX=@MMSX,MMLB=@MMLB,MMCS=@MMCS,MMGL=@MMGL,MMK=@MMK,MMNO=@MMNO where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@JYLSH",jzjs.JYLSH), //1
                                   new SqlParameter("@JYCS",jzjs.JYCS), //1
                                   new SqlParameter("@CYDS",jzjs.CYDS), //1
                                   new SqlParameter("@MMZS",jzjs.MMZS), //1
                                   new SqlParameter("@MMZGL",jzjs.MMZGL), //1
                                   new SqlParameter("@MMZSGL",jzjs.MMZSGL), //1
                                   new SqlParameter("@MMGLXZXS",jzjs.MMGLXZXS), //1
                                   new SqlParameter("@MMJSGL",jzjs.MMJSGL), //1
                                   new SqlParameter("@MMBTGD",jzjs.MMBTGD), //1
                                   new SqlParameter("@MMDQYL",jzjs.MMDQYL), //1
                                   new SqlParameter("@MMXDSD",jzjs.MMXDSD), //1
                                   new SqlParameter("@MMHJWD",jzjs.MMHJWD), //1
                                   new SqlParameter("@MMNL",jzjs.MMNL), //1

                                   new SqlParameter("@CLID",jzjs.CLID), //1
                                   new SqlParameter("@CLHP",jzjs.CLHP),
                                   new SqlParameter("@JCSJ",jzjs.JCSJ),
                                   new SqlParameter("@MMTIME",jzjs.MMTIME),
                                   new SqlParameter("@MMSX",jzjs.MMSX),
                                   new SqlParameter("@MMLB",jzjs.MMLB),//6
                                   new SqlParameter("@MMCS",jzjs.MMCS),
                                   new SqlParameter("@MMGL",jzjs.MMGL),
                                   new SqlParameter("@MMK",jzjs.MMK),
                                   new SqlParameter("@MMNO",jzjs.MMNO)
                                   //47
                               };
            try
            {
                if (Have_JZJSseconds(jzjs.CLID))
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
                return 0;
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
        public JZJSseconds Get_JzjsDataSeconds(string CLID)
        {
            DateTime a;
            string sql = "select * from JZJS_DATASECONDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                JZJSseconds asm = new JZJSseconds();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.CLHP = dt.Rows[0]["CLHP"].ToString();
                    asm.JCSJ = DateTime.Parse(dt.Rows[0]["JCSJ"].ToString());
                    asm.MMTIME = dt.Rows[0]["MMTIME"].ToString();
                    asm.MMSX = dt.Rows[0]["MMSX"].ToString();
                    asm.MMLB = dt.Rows[0]["MMLB"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();//6
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();
                    asm.MMK = dt.Rows[0]["MMK"].ToString();
                    asm.MMNO = dt.Columns.Contains("MMNO") ? dt.Rows[0]["MMNO"].ToString() : "";

                }
                else
                {
                    asm.CLID = "-2";
                }
                return asm;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JZJSseconds Get_JzjsDataSeconds(string clhp,DateTime jcsj)
        {
            DateTime a;
            string sql = "select * from JZJS_DATASECONDS where clhp=@clhp and convert(varchar(50),jcsj,120)=convert(varchar(50),@jcsj,120)";
            SqlParameter[] spr ={
                                   new SqlParameter("@clhp",clhp),
                                   new SqlParameter("@jcsj",jcsj.ToString("yyyy-MM-dd HH:mm:ss"))
                               };
            try
            {
                JZJSseconds asm = new JZJSseconds();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.CLHP = dt.Rows[0]["CLHP"].ToString();
                    asm.JCSJ = DateTime.Parse(dt.Rows[0]["JCSJ"].ToString());
                    asm.MMTIME = dt.Rows[0]["MMTIME"].ToString();
                    asm.MMSX = dt.Rows[0]["MMSX"].ToString();
                    asm.MMLB = dt.Rows[0]["MMLB"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();//6
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();
                    asm.MMK = dt.Rows[0]["MMK"].ToString();
                    asm.MMNO =dt.Columns.Contains("MMNO")? dt.Rows[0]["MMNO"].ToString():"";

                }
                else
                {
                    asm.CLID = "-2";
                }
                return asm;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
