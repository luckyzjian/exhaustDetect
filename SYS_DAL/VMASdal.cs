using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class VMASdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_VMAS(string CARID)
        {
            string sql = "select * from vmas where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CARID)
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
        public bool Delete_ASM(string CARID)
        {
            string sql = "delete vmas where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CARID)
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
        public int Save_VMAS(VMAS vmas)
        {
            string sqli = "insert into vmas(CSLJCCSJ,XSLC,JYLSH,JYCS,SBRZBM,CLID,CLPH,COZL,COXZ,COPD,NOXZL,NOXXZ,NOXPD,HCZL,HCXZ,HCPD,ZHPD,JCRQ,WD,SD,DQY,SBMC,SBXH,SBZZC,CGJXH,CGJBH,CGJZZC,FXYXH,FXYBH,FXYZZC,LLJXH,LLJBH,LLJZZC,BEFORE) values(@CSLJCCSJ,@XSLC,@JYLSH,@JYCS,@SBRZBM,@CLID,@CLPH,@COZL,@COXZ,@COPD,@NOXZL,@NOXXZ,@NOXPD,@HCZL,@HCXZ,@HCPD,@ZHPD,@JCRQ,@WD,@SD,@DQY,@SBMC,@SBXH,@SBZZC,@CGJXH,@CGJBH,@CGJZZC,@FXYXH,@FXYBH,@FXYZZC,@LLJXH,@LLJBH,@LLJZZC,@BEFORE)";
            string sqlu = "update vmas set CSLJCCSJ=@CSLJCCSJ,XSLC=@XSLC,JYLSH=@JYLSH,JYCS=@JYCS,SBRZBM=@SBRZBM,CLPH=@CLPH,COZL=@COZL,COXZ=@COXZ,COPD=@COPD,NOXZL=@NOXZL,NOXXZ=@NOXXZ,NOXPD=@NOXPD,HCZL=@HCZL,HCXZ=@HCXZ,HCPD=@HCPD,ZHPD=@ZHPD,JCRQ=@JCRQ,WD=@WD,SD=@SD,DQY=@DQY,SBMC=@SBMC,SBXH=@SBXH,SBZZC=@SBZZC,CGJXH=@CGJXH,CGJBH=@CGJBH,CGJZZC=@CGJZZC,FXYXH=@FXYXH,FXYBH=@FXYBH,FXYZZC=@FXYZZC,LLJXH=@LLJXH,LLJBH=@LLJBH,LLJZZC=@LLJZZC,BEFORE=@BEFORE where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CSLJCCSJ",vmas.CSLJCCSJ),
                                   new SqlParameter("@XSLC",vmas.XSLC),
                                   new SqlParameter("@JYLSH",vmas.JYLSH),
                                   new SqlParameter("@JYCS",vmas.JYCS),
                                   new SqlParameter("@SBRZBM",vmas.SBRZBM),
                                   new SqlParameter("@CLID",vmas.CLID), //1
                                   new SqlParameter("@CLPH",vmas.CLPH),
                                   new SqlParameter("@COZL",vmas.COZL),
                                   new SqlParameter("@COXZ",vmas.COXZ),
                                   new SqlParameter("@COPD",vmas.COPD),
                                   new SqlParameter("@NOXZL",vmas.NOXZL),//6
                                   new SqlParameter("@NOXXZ",vmas.NOXXZ),
                                   new SqlParameter("@NOXPD",vmas.NOXPD),
                                   new SqlParameter("@HCZL",vmas.HCZL),
                                   new SqlParameter("@HCXZ",vmas.HCXZ),
                                   new SqlParameter("@HCPD",vmas.HCPD),//11
                                   new SqlParameter("@ZHPD",vmas.ZHPD),
                                   new SqlParameter("@JCRQ",vmas.JCRQ),
                                   new SqlParameter("@WD",vmas.WD),
                                   new SqlParameter("@SD",vmas.SD),
                                   new SqlParameter("@DQY",vmas.DQY),//16
                                   new SqlParameter("@SBMC",vmas.SBMC),
                                   new SqlParameter("@SBXH",vmas.SBXH),
                                   new SqlParameter("@SBZZC",vmas.SBZZC),
                                   new SqlParameter("@CGJXH",vmas.CGJXH),
                                   new SqlParameter("@CGJBH",vmas.CGJBH),//21
                                   new SqlParameter("@CGJZZC",vmas.CGJZZC),
                                   new SqlParameter("@FXYXH",vmas.FXYXH),
                                   new SqlParameter("@FXYBH",vmas.FXYBH),
                                   new SqlParameter("@FXYZZC",vmas.FXYZZC),//47
                                   new SqlParameter("@LLJXH",vmas.LLJXH),
                                   new SqlParameter("@LLJBH",vmas.LLJBH),
                                   new SqlParameter("@LLJZZC",vmas.LLJZZC),//47
                                   new SqlParameter("@BEFORE",vmas.BEFORE)
                                                                   
                               };
            try
            {
                if (Have_VMAS(vmas.CLID))
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
        public VMAS Get_VMAS(string CLID)
        {
            DateTime a;
            string sql = "select * from vmas where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                VMAS vmas = new VMAS();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    vmas.CLID = dt.Rows[0]["CLID"].ToString();//1
                    vmas.CLPH = dt.Rows[0]["CLPH"].ToString();
                    vmas.COZL = dt.Rows[0]["COZL"].ToString();
                    vmas.COXZ = dt.Rows[0]["COXZ"].ToString();
                    vmas.COPD = dt.Rows[0]["COPD"].ToString();
                    vmas.NOXZL = dt.Rows[0]["NOXZL"].ToString();//6
                    vmas.NOXXZ = dt.Rows[0]["NOXXZ"].ToString();
                    vmas.NOXPD = dt.Rows[0]["NOXPD"].ToString();
                    vmas.HCZL = dt.Rows[0]["HCZL"].ToString();
                    vmas.HCXZ = dt.Rows[0]["HCXZ"].ToString();
                    vmas.HCPD = dt.Rows[0]["HCPD"].ToString();//11
                    vmas.ZHPD = dt.Rows[0]["ZHPD"].ToString();
                    DateTime.TryParse(dt.Rows[0]["JCRQ"].ToString(), out a);
                    if (a != null)
                        vmas.JCRQ = a;
                    else
                        vmas.JCRQ = DateTime.Today;
                    vmas.WD = dt.Rows[0]["WD"].ToString();
                    vmas.SD = dt.Rows[0]["SD"].ToString();
                    vmas.DQY = dt.Rows[0]["DQY"].ToString();//16
                    vmas.SBMC = dt.Rows[0]["SBMC"].ToString();
                    vmas.SBXH = dt.Rows[0]["SBXH"].ToString();
                    vmas.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    vmas.CGJXH = dt.Rows[0]["CGJXH"].ToString();
                    vmas.CGJBH = dt.Rows[0]["CGJBH"].ToString();//21
                    vmas.CGJZZC = dt.Rows[0]["CGJZZC"].ToString();
                    vmas.FXYXH = dt.Rows[0]["FXYXH"].ToString();
                    vmas.FXYBH = dt.Rows[0]["FXYBH"].ToString();
                    vmas.FXYZZC = dt.Rows[0]["FXYZZC"].ToString();
                    vmas.LLJXH = dt.Rows[0]["LLJXH"].ToString();
                    vmas.LLJBH = dt.Rows[0]["LLJBH"].ToString();
                    vmas.LLJZZC = dt.Rows[0]["LLJZZC"].ToString();
                    vmas.BEFORE = dt.Rows[0]["BEFORE"].ToString();
                }
                else
                {
                    vmas.CLID = "-2";
                }
                return vmas;
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
        public VMASseconds Get_VMASDataSeconds(string CLID)
        {
            DateTime a;
            string sql = "select * from VMAS_DATASECONDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                VMASseconds asm = new VMASseconds();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.CLHP = dt.Rows[0]["CLHP"].ToString();
                    asm.JCSJ = DateTime.Parse(dt.Rows[0]["JCSJ"].ToString());
                    asm.MMTIME = dt.Rows[0]["MMTIME"].ToString();
                    asm.MMSX = dt.Rows[0]["MMSX"].ToString();
                    asm.MMLB = dt.Rows[0]["MMLB"].ToString();
                    asm.MMHC = dt.Rows[0]["MMHC"].ToString();//6
                    asm.MMCO = dt.Rows[0]["MMCO"].ToString();
                    asm.MMO2 = dt.Rows[0]["MMO2"].ToString();
                    asm.MMCO2 = dt.Rows[0]["MMCO2"].ToString();
                    asm.MMNO = dt.Rows[0]["MMNO"].ToString();
                    asm.MMCOZL = dt.Rows[0]["MMCOZL"].ToString();
                    asm.MMHCZL = dt.Rows[0]["MMHCZL"].ToString();
                    asm.MMNOZL = dt.Rows[0]["MMNOZL"].ToString();
                    asm.MMXSO2 = dt.Rows[0]["MMXSO2"].ToString();
                    asm.MMHJO2 = dt.Rows[0]["MMHJO2"].ToString();
                    asm.MMSJLL = dt.Rows[0]["MMSJLL"].ToString();
                    asm.MMBZLL = dt.Rows[0]["MMBZLL"].ToString();
                    asm.MMWQLL = dt.Rows[0]["MMWQLL"].ToString();
                    asm.MMXSB = dt.Rows[0]["MMXSB"].ToString();

                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMLLJWD = dt.Rows[0]["MMLLJWD"].ToString();
                    asm.MMLLJYL = dt.Rows[0]["MMLLJYL"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();
                    asm.MMBZCS = dt.Rows[0]["MMBZCS"].ToString();
                    asm.MMXSXZ = dt.Rows[0]["MMXSXZ"].ToString();
                    asm.MMSDXZ = dt.Rows[0]["MMSDXZ"].ToString();
                    asm.MMGLYL = dt.Rows[0]["MMGLYL"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
                    asm.MMJSGL = dt.Rows[0]["MMJSGL"].ToString();//11
                    asm.MMNJ = dt.Rows[0]["MMNJ"].ToString();
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();
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
        public VMASseconds Get_VMASDataSeconds(string clhp,DateTime jcsj)
        {
            DateTime a;
            string sql = "select * from VMAS_DATASECONDS where clhp=@clhp and convert(varchar(50),jcsj,120)=convert(varchar(50),@jcsj,120)";
            SqlParameter[] spr ={
                                   new SqlParameter("@clhp",clhp),
                                   new SqlParameter("@jcsj",jcsj.ToString("yyyy-MM-dd HH:mm:ss"))
                               };
            try
            {
                VMASseconds asm = new VMASseconds();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.CLHP = dt.Rows[0]["CLHP"].ToString();
                    asm.JCSJ = DateTime.Parse(dt.Rows[0]["JCSJ"].ToString());
                    asm.MMTIME = dt.Rows[0]["MMTIME"].ToString();
                    asm.MMSX = dt.Rows[0]["MMSX"].ToString();
                    asm.MMLB = dt.Rows[0]["MMLB"].ToString();
                    asm.MMHC = dt.Rows[0]["MMHC"].ToString();//6
                    asm.MMCO = dt.Rows[0]["MMCO"].ToString();
                    asm.MMO2 = dt.Rows[0]["MMO2"].ToString();
                    asm.MMCO2 = dt.Rows[0]["MMCO2"].ToString();
                    asm.MMNO = dt.Rows[0]["MMNO"].ToString();
                    asm.MMCOZL = dt.Rows[0]["MMCOZL"].ToString();
                    asm.MMHCZL = dt.Rows[0]["MMHCZL"].ToString();
                    asm.MMNOZL = dt.Rows[0]["MMNOZL"].ToString();
                    asm.MMXSO2 = dt.Rows[0]["MMXSO2"].ToString();
                    asm.MMHJO2 = dt.Rows[0]["MMHJO2"].ToString();
                    asm.MMSJLL = dt.Rows[0]["MMSJLL"].ToString();
                    asm.MMBZLL = dt.Rows[0]["MMBZLL"].ToString();
                    asm.MMWQLL = dt.Rows[0]["MMWQLL"].ToString();
                    asm.MMXSB = dt.Rows[0]["MMXSB"].ToString();

                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMLLJWD = dt.Rows[0]["MMLLJWD"].ToString();
                    asm.MMLLJYL = dt.Rows[0]["MMLLJYL"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();
                    asm.MMBZCS = dt.Rows[0]["MMBZCS"].ToString();
                    asm.MMXSXZ = dt.Rows[0]["MMXSXZ"].ToString();
                    asm.MMSDXZ = dt.Rows[0]["MMSDXZ"].ToString();
                    asm.MMGLYL = dt.Rows[0]["MMGLYL"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
                    asm.MMJSGL = dt.Rows[0]["MMJSGL"].ToString();//11
                    asm.MMNJ = dt.Rows[0]["MMNJ"].ToString();
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();
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
        #region 插入逐秒数据
        /// <summary>
        /// 用JZJS插入逐秒数据
        /// </summary>
        /// <param name="JZJS">JZJS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_VMASSseconds(VMASseconds asm)
        {
            string sqli = "insert into VMAS_DATASECONDS(JYLSH,JYCS,CYDS,MMZS,MMZSGL,MMJZGL,MMCO2ZL,CLID,CLHP,JCSJ,MMTIME,MMSX,MMLB,MMHC,MMCO,MMO2,MMCO2,MMNO,MMCOZL,MMHCZL,MMNOZL,MMXSO2,MMHJO2,MMSJLL,MMBZLL,MMWQLL,MMXSB,MMWD,MMSD,MMDQY,MMLLJWD,MMLLJYL,MMCS,MMBZCS,MMGL,MMNJ,MMXSXZ,MMSDXZ,MMGLYL,MMYW,MMJSGL) values(@JYLSH,@JYCS,@CYDS,@MMZS,@MMZSGL,@MMJZGL,@MMCO2ZL,@CLID,@CLHP,@JCSJ,@MMTIME,@MMSX,@MMLB,@MMHC,@MMCO,@MMO2,@MMCO2,@MMNO,@MMCOZL,@MMHCZL,@MMNOZL,@MMXSO2,@MMHJO2,@MMSJLL,@MMBZLL,@MMWQLL,@MMXSB,@MMWD,@MMSD,@MMDQY,@MMLLJWD,@MMLLJYL,@MMCS,@MMBZCS,@MMGL,@MMNJ,@MMXSXZ,@MMSDXZ,@MMGLYL,@MMYW,@MMJSGL)";
            string sqlu = "update VMAS_DATASECONDS set JYLSH=@JYLSH,JYCS=@JYCS,CYDS=@CYDS,MMZS=@MMZS,MMZSGL=@MMZSGL,MMJZGL=@MMJZGL,MMCO2ZL=@MMCO2ZL,CLHP=@CLHP,JCSJ=@JCSJ,MMTIME=@MMTIME,MMSX=@MMSX,MMLB=@MMLB,MMHC=@MMHC,MMCO=@MMCO,MMO2=@MMO2,MMCO2=@MMCO2,MMNO=@MMNO,MMCOZL=@MMCOZL,MMHCZL=@MMHCZL,MMNOZL=@MMNOZL,MMXSO2=@MMXSO2,MMHJO2=@MMHJO2,MMSJLL=@MMSJLL,MMBZLL=@MMBZLL,MMWQLL=@MMWQLL,MMXSB=@MMXSB,MMWD=@MMWD,MMSD=@MMSD,MMDQY=@MMDQY,MMLLJWD=@MMLLJWD,MMLLJYL=@MMLLJYL,MMCS=@MMCS,MMBZCS=@MMBZCS,MMGL=@MMGL,MMNJ=@MMNJ,MMXSXZ=@MMXSXZ,MMSDXZ=@MMSDXZ,MMGLYL=@MMGLYL,MMYW=@MMYW,MMJSGL=@MMJSGL where CLID=@CLID";
            SqlParameter[] spr ={
                new SqlParameter("@JYLSH",asm.JYLSH),
                new SqlParameter("@JYCS",asm.JYCS),
                new SqlParameter("@CYDS",asm.CYDS),
                new SqlParameter("@MMZS",asm.MMZS),
                new SqlParameter("@MMZSGL",asm.MMZSGL),
                new SqlParameter("@MMJZGL",asm.MMJZGL),
                new SqlParameter("@MMCO2ZL",asm.MMCO2ZL),
                                   new SqlParameter("@CLID",asm.CLID), //1
                                   new SqlParameter("@CLHP",asm.CLHP),
                                   new SqlParameter("@JCSJ",asm.JCSJ),
                                   new SqlParameter("@MMTIME",asm.MMTIME),
                                   new SqlParameter("@MMSX",asm.MMSX),
                                   new SqlParameter("@MMLB",asm.MMLB),//6
                                   new SqlParameter("@MMHC",asm.MMHC),
                                   new SqlParameter("@MMCO",asm.MMCO),
                                   new SqlParameter("@MMO2",asm.MMO2),
                                   new SqlParameter("@MMCO2",asm.MMCO2),
                                   new SqlParameter("@MMNO",asm.MMNO),
                                   new SqlParameter("@MMCOZL",asm.MMCOZL),
                                   new SqlParameter("@MMHCZL",asm.MMHCZL),
                                   new SqlParameter("@MMNOZL",asm.MMNOZL),
                                   new SqlParameter("@MMXSO2",asm.MMXSO2),//6
                                   new SqlParameter("@MMHJO2",asm.MMHJO2),
                                   new SqlParameter("@MMSJLL",asm.MMSJLL),
                                   new SqlParameter("@MMBZLL",asm.MMBZLL),
                                   new SqlParameter("@MMWQLL",asm.MMWQLL),
                                   new SqlParameter("@MMXSB",asm.MMXSB),

                                   new SqlParameter("@MMWD",asm.MMWD),
                                   new SqlParameter("@MMSD",asm.MMSD),
                                   new SqlParameter("@MMDQY",asm.MMDQY),
                                   new SqlParameter("@MMLLJWD",asm.MMLLJWD),
                                   new SqlParameter("@MMLLJYL",asm.MMLLJYL),

                                   new SqlParameter("@MMCS",asm.MMCS),
                                   new SqlParameter("@MMBZCS",asm.MMBZCS),
                                   new SqlParameter("@MMXSXZ",asm.MMXSXZ),
                                   new SqlParameter("@MMSDXZ",asm.MMSDXZ),//6
                                   new SqlParameter("@MMGLYL",asm.MMGLYL),
                                   new SqlParameter("@MMYW",asm.MMYW),
                                   new SqlParameter("@MMJSGL",asm.MMJSGL),
                                   new SqlParameter("@MMGL",asm.MMGL),
                                   new SqlParameter("@MMNJ",asm.MMNJ)//6
                                   //47
                               };
            try
            {
                if (Have_VMASseconds(asm.CLID))
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
                //throw;
                return 0;
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
        public bool Have_VMASseconds(string CLID)
        {
            string sql = "select * from VMAS_DATASECONDS where CLID=@CLID";
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
    }
}
