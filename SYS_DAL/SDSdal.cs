using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class SDSdal
    {
        #region 用检测编号判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>bool</returns>
        public bool Have_SDS(string CLID)
        {
            string sql = "select * from SDS where CLID=@CLID";
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

        #region 用检测编号删除一条检测数据
        /// <summary>
        /// 用检测编号删除一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>bool</returns>
        public bool Delete_SDS(string CLID)
        {
            string sql = "delete SDS where CLID=@CLID";
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

        #region 用SDS对象插入或更新条检测数据
        /// <summary>
        /// 用SDS对象插入或更新条检测数据
        /// </summary>
        /// <param name="SDS">SDS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_SDS(SDS SDS)
        {
            string sqli = "insert into SDS(JYLSH,JYCS,SBRZBM,CLID,JCBGBH,CLPH,COLOWCLZ,COLOWXZ,HCLOWCLZ,HCLOWXZ,COHIGHCLZ,COHIGHXZ,HCHIGHCLZ,HCHIGHXZ,LAMDAHIGHCLZ,LAMDAHIGHXZ,LAMDAHIGHPD,LOWPD,HIGHPD,ZHPD,JCRQ,WD,SD,DQY,SBMC,SBXH,SBZZC,FXYXH,FXYBH,FXYZZC,ZSJXH,ZSJBH,ZSJZZC,COLOWPD,HCLOWPD,ZSLOW,JYWDLOW,COHIGHPD,HCHIGHPD,ZSHIGH,JYWDHIGH,SHY,SYNCHDATE,YW,GLKQXSSX,GLKQXSXX,JCKSSJ,JCJSSJ,CO2HIGH,O2HIGH,CO2LOW,O2LOW,COLOWXXZ,COHIGHXXZ,COLOWXYZ,COHIGHXYZ,CO2LOWXYZ,CO2HIGHXYZ,HCLOWXYZ,HCHIGHXYZ) values(@JYLSH,@JYCS,@SBRZBM,@CLID,@JCBGBH,@CLPH,@COLOWCLZ,@COLOWXZ,@HCLOWCLZ,@HCLOWXZ,@COHIGHCLZ,@COHIGHXZ,@HCHIGHCLZ,@HCHIGHXZ,@LAMDAHIGHCLZ,@LAMDAHIGHXZ,@LAMDAHIGHPD,@LOWPD,@HIGHPD,@ZHPD,@JCRQ,@WD,@SD,@DQY,@SBMC,@SBXH,@SBZZC,@FXYXH,@FXYBH,@FXYZZC,@ZSJXH,@ZSJBH,@ZSJZZC,@COLOWPD,@HCLOWPD,@ZSLOW,@JYWDLOW,@COHIGHPD,@HCHIGHPD,@ZSHIGH,@JYWDHIGH,@SHY,@SYNCHDATE,@YW,@GLKQXSSX,@GLKQXSXX,@JCKSSJ,@JCJSSJ,@CO2HIGH,@O2HIGH,@CO2LOW,@O2LOW,@COLOWXXZ,@COHIGHXXZ,@COLOWXYZ,@COHIGHXYZ,@CO2LOWXYZ,@CO2HIGHXYZ,@HCLOWXYZ,@HCHIGHXYZ)";
            string sqlu = "update SDS set JYLSH=@JYLSH,JYCS=@JYCS,SBRZBM=@SBRZBM,CLPH=@CLPH,JCBGBH=@JCBGBH,COLOWCLZ=@COLOWCLZ,COLOWXZ=@COLOWXZ,HCLOWCLZ=@HCLOWCLZ,HCLOWXZ=@HCLOWXZ,COHIGHCLZ=@COHIGHCLZ,COHIGHXZ=@COHIGHXZ,HCHIGHCLZ=@HCHIGHCLZ,HCHIGHXZ=@HCHIGHXZ,LAMDAHIGHCLZ=@LAMDAHIGHCLZ,LAMDAHIGHXZ=@LAMDAHIGHXZ,LAMDAHIGHPD=@LAMDAHIGHPD,LOWPD=@LOWPD,HIGHPD=@HIGHPD,ZHPD=@ZHPD,JCRQ=@JCRQ,WD=@WD,SD=@SD,DQY=@DQY,SBMC=@SBMC,SBXH=@SBXH,SBZZC=@SBZZC,FXYXH=@FXYXH,FXYBH=@FXYBH,FXYZZC=@FXYZZC,ZSJXH=@ZSJXH,ZSJBH=@ZSJBH,ZSJZZC=@ZSJZZC,COLOWPD=@COLOWPD,HCLOWPD=@HCLOWPD,ZSLOW=@ZSLOW,JYWDLOW=@JYWDLOW,COHIGHPD=@COHIGHPD,HCHIGHPD=@HCHIGHPD,ZSHIGH=@ZSHIGH,JYWDHIGH=@JYWDHIGH,SHY=@SHY,SYNCHDATE=@SYNCHDATE,YW=@YW,GLKQXSSX=@GLKQXSSX,GLKQXSXX=@GLKQXSXX,JCKSSJ=@JCKSSJ,JCJSSJ=@JCJSSJ,CO2HIGH=@CO2HIGH,O2HIGH=@O2HIGH,CO2LOW=@CO2LOW,O2LOW=@O2LOW,COLOWXXZ=@COLOWXXZ,COHIGHXXZ=@COHIGHXXZ,COLOWXYZ=@COLOWXYZ,COHIGHXYZ=@COHIGHXYZ,CO2LOWXYZ=@CO2LOWXYZ,CO2HIGHXYZ=@CO2HIGHXYZ,HCLOWXYZ=@HCLOWXYZ,HCHIGHXYZ=@HCHIGHXYZ where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@JYLSH",SDS.JYLSH),
                                   new SqlParameter("@JYCS",SDS.JYCS),
                                   new SqlParameter("@SBRZBM",SDS.SBRZBM),
                                   new SqlParameter("@CLID",SDS.CLID), //1
                                   new SqlParameter("@JCBGBH",SDS.JCBGBH), //1
                                   new SqlParameter("@CLPH",SDS.CLPH),
                                   new SqlParameter("@COLOWCLZ",SDS.COLOWCLZ),
                                   new SqlParameter("@COLOWXZ",SDS.COLOWXZ),
                                   new SqlParameter("@HCLOWCLZ",SDS.HCLOWCLZ),
                                   new SqlParameter("@HCLOWXZ",SDS.HCLOWXZ),
                                   new SqlParameter("@COHIGHCLZ",SDS.COHIGHCLZ),//6
                                   new SqlParameter("@COHIGHXZ",SDS.COHIGHXZ),
                                   new SqlParameter("@HCHIGHCLZ",SDS.HCHIGHCLZ),
                                   new SqlParameter("@HCHIGHXZ",SDS.HCHIGHXZ),
                                   new SqlParameter("@LAMDAHIGHCLZ",SDS.LAMDAHIGHCLZ),
                                   new SqlParameter("@LAMDAHIGHXZ",SDS.LAMDAHIGHXZ),//11
                                   new SqlParameter("@LAMDAHIGHPD",SDS.LAMDAHIGHPD),//11                                   
                                   new SqlParameter("@LOWPD",SDS.LOWPD),
                                   new SqlParameter("@HIGHPD",SDS.HIGHPD),//11
                                   new SqlParameter("@ZHPD",SDS.ZHPD),
                                   new SqlParameter("@JCRQ",SDS.JCRQ),
                                   new SqlParameter("@WD",SDS.WD),
                                   new SqlParameter("@SD",SDS.SD),
                                   new SqlParameter("@DQY",SDS.DQY),//16
                                   new SqlParameter("@SBMC",SDS.SBMC),
                                   new SqlParameter("@SBXH",SDS.SBXH),
                                   new SqlParameter("@SBZZC",SDS.SBZZC),
                                   new SqlParameter("@ZSJXH",SDS.ZSJXH),
                                   new SqlParameter("@ZSJBH",SDS.ZSJBH),//21
                                   new SqlParameter("@ZSJZZC",SDS.ZSJZZC),
                                   new SqlParameter("@FXYXH",SDS.FXYXH),
                                   new SqlParameter("@FXYBH",SDS.FXYBH),
                                   new SqlParameter("@FXYZZC",SDS.FXYZZC),//47

                                   new SqlParameter("@COLOWPD",SDS.COLOWPD),
                                   new SqlParameter("@HCLOWPD",SDS.HCLOWPD),
                                   new SqlParameter("@ZSLOW",SDS.ZSLOW),//21
                                   new SqlParameter("@JYWDLOW",SDS.JYWDLOW),
                                    new SqlParameter("@COHIGHPD",SDS.COHIGHPD),
                                   new SqlParameter("@HCHIGHPD",SDS.HCHIGHPD),
                                   new SqlParameter("@ZSHIGH",SDS.ZSHIGH),//21
                                   new SqlParameter("@JYWDHIGH",SDS.JYWDHIGH),
                                    new SqlParameter("@SHY",SDS.SHY),
                                   new SqlParameter("@SYNCHDATE",SDS.SYNCHDATE),
                                   new SqlParameter("@YW",SDS.YW),//21
                                   new SqlParameter("@GLKQXSSX",SDS.GLKQXSSX),
                                   new SqlParameter("@GLKQXSXX",SDS.GLKQXSXX),
                                   new SqlParameter("@JCKSSJ",SDS.JCKSSJ),
                                   new SqlParameter("@JCJSSJ",SDS.JCJSSJ),
                                   new SqlParameter("@CO2HIGH",SDS.CO2HIGH),
                                   new SqlParameter("@O2HIGH",SDS.O2HIGH),
                                   new SqlParameter("@CO2LOW",SDS.CO2LOW),
                                   new SqlParameter("@O2LOW",SDS.O2LOW),
                                   new SqlParameter("@COLOWXXZ",SDS.COLOWXXZ),
                                   new SqlParameter("@COHIGHXXZ",SDS.COHIGHXXZ),
                                   new SqlParameter("@COLOWXYZ",SDS.COLOWXYZ),
                                   new SqlParameter("@COHIGHXYZ",SDS.COHIGHXYZ),
                                   new SqlParameter("@CO2LOWXYZ",SDS.CO2LOWXYZ),
                                   new SqlParameter("@CO2HIGHXYZ",SDS.CO2HIGHXYZ),
                                   new SqlParameter("@HCLOWXYZ",SDS.HCLOWXYZ),
                                   new SqlParameter("@HCHIGHXYZ",SDS.HCHIGHXYZ)
                                   //47
                               };
            try
            {
                if (Have_SDS(SDS.CLID))
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
        /// <returns>SDS检测数据Model</returns>
        public SDS Get_SDS(string CLID)
        {
            DateTime a;
            string sql = "select * from SDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                SDS SDS = new SDS();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    SDS.CLID = dt.Rows[0]["CLID"].ToString();//1
                    SDS.JCBGBH = dt.Rows[0]["JCBGBH"].ToString();//1
                    SDS.CLPH = dt.Rows[0]["CLPH"].ToString();
                    SDS.COLOWCLZ = dt.Rows[0]["COLOWCLZ"].ToString();
                    SDS.COLOWXZ = dt.Rows[0]["COLOWXZ"].ToString();
                    SDS.HCLOWCLZ = dt.Rows[0]["HCLOWCLZ"].ToString();
                    SDS.HCLOWXZ = dt.Rows[0]["HCLOWXZ"].ToString();//6
                    SDS.COHIGHCLZ = dt.Rows[0]["COHIGHCLZ"].ToString();
                    SDS.COHIGHXZ = dt.Rows[0]["COHIGHXZ"].ToString();
                    SDS.HCHIGHCLZ = dt.Rows[0]["HCHIGHCLZ"].ToString();
                    SDS.HCHIGHXZ = dt.Rows[0]["HCHIGHXZ"].ToString();
                    SDS.LAMDAHIGHCLZ = dt.Rows[0]["LAMDAHIGHCLZ"].ToString();//11
                    SDS.LAMDAHIGHXZ = dt.Rows[0]["LAMDAHIGHXZ"].ToString();//11
                    SDS.LAMDAHIGHPD = dt.Rows[0]["LAMDAHIGHPD"].ToString();//11
                    SDS.LOWPD = dt.Rows[0]["LOWPD"].ToString();//11
                    SDS.HIGHPD = dt.Rows[0]["HIGHPD"].ToString();//11
                    SDS.ZHPD = dt.Rows[0]["ZHPD"].ToString();
                    DateTime.TryParse(dt.Rows[0]["JCRQ"].ToString(), out a);
                    if (a != null)
                        SDS.JCRQ = a;
                    else
                        SDS.JCRQ = DateTime.Today;
                    SDS.WD = dt.Rows[0]["WD"].ToString();
                    SDS.SD = dt.Rows[0]["SD"].ToString();
                    SDS.DQY = dt.Rows[0]["DQY"].ToString();//16
                    SDS.SBMC = dt.Rows[0]["SBMC"].ToString();
                    SDS.SBXH = dt.Rows[0]["SBXH"].ToString();
                    SDS.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    SDS.ZSJXH = dt.Rows[0]["ZSJXH"].ToString();
                    SDS.ZSJBH = dt.Rows[0]["ZSJBH"].ToString();//21
                    SDS.ZSJZZC = dt.Rows[0]["ZSJZZC"].ToString();
                    SDS.FXYXH = dt.Rows[0]["FXYXH"].ToString();
                    SDS.FXYBH = dt.Rows[0]["FXYBH"].ToString();
                    SDS.FXYZZC = dt.Rows[0]["FXYZZC"].ToString();

                    SDS.COLOWPD = dt.Rows[0]["COLOWPD"].ToString();
                    SDS.HCLOWPD = dt.Rows[0]["HCLOWPD"].ToString();
                    SDS.ZSLOW = dt.Rows[0]["ZSLOW"].ToString();
                    SDS.JYWDLOW = dt.Rows[0]["JYWDLOW"].ToString();
                    SDS.COHIGHPD = dt.Rows[0]["COHIGHPD"].ToString();
                    SDS.HCHIGHPD = dt.Rows[0]["HCHIGHPD"].ToString();
                    SDS.ZSHIGH = dt.Rows[0]["ZSHIGH"].ToString();
                    SDS.JYWDHIGH = dt.Rows[0]["JYWDHIGH"].ToString();

                    SDS.SHY = dt.Rows[0]["SHY"].ToString();
                    SDS.SYNCHDATE = dt.Rows[0]["SYNCHDATE"].ToString();
                    SDS.YW = dt.Rows[0]["YW"].ToString();
                    SDS.GLKQXSSX = dt.Rows[0]["GLKQXSSX"].ToString();
                    SDS.GLKQXSXX = dt.Rows[0]["GLKQXSXX"].ToString();
                    SDS.JCKSSJ = dt.Rows[0]["JCKSSJ"].ToString();
                    SDS.JCJSSJ = dt.Rows[0]["JCJSSJ"].ToString();
                    SDS.CO2HIGH = dt.Rows[0]["CO2HIGH"].ToString();
                    SDS.O2HIGH = dt.Rows[0]["O2HIGH"].ToString();
                    SDS.CO2LOW = dt.Rows[0]["CO2LOW"].ToString();
                    SDS.O2LOW = dt.Rows[0]["O2LOW"].ToString();
                    SDS.COLOWXXZ = dt.Rows[0]["COLOWXXZ"].ToString();
                    SDS.COHIGHXXZ = dt.Rows[0]["COHIGHXXZ"].ToString();
                    SDS.COLOWXYZ = dt.Rows[0]["COLOWXYZ"].ToString();
                    SDS.COHIGHXYZ = dt.Rows[0]["COHIGHXYZ"].ToString();
                    SDS.CO2LOWXYZ = dt.Rows[0]["CO2LOWXYZ"].ToString();
                    SDS.CO2HIGHXYZ = dt.Rows[0]["CO2HIGHXYZ"].ToString();
                    SDS.HCLOWXYZ = dt.Rows[0]["HCLOWXYZ"].ToString();
                    SDS.HCHIGHXYZ = dt.Rows[0]["HCHIGHXYZ"].ToString();
                }
                else
                {
                    SDS.CLID = "-2";
                }
                return SDS;
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
        public SDSseconds Get_SDSDataSeconds(string CLID)
        {
            DateTime a;
            string sql = "select * from SDS_DATASECONDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                SDSseconds asm = new SDSseconds();
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
                    asm.MMLAMDA = dt.Rows[0]["MMLAMDA"].ToString();
                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMZS = dt.Rows[0]["MMZS"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
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
        public SDSseconds Get_SDSDataSeconds(string clhp,DateTime jcsj)
        {
            DateTime a;
            string sql = "select * from SDS_DATASECONDS where clhp=@clhp and convert(varchar(50),jcsj,120)=convert(varchar(50),@jcsj,120)";
            SqlParameter[] spr ={
                                   new SqlParameter("@clhp",clhp),
                                   new SqlParameter("@jcsj",jcsj.ToString("yyyy-MM-dd HH:mm:ss"))
                               };
            try
            {
                SDSseconds asm = new SDSseconds();
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
                    asm.MMLAMDA = dt.Rows[0]["MMLAMDA"].ToString();
                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMZS = dt.Rows[0]["MMZS"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
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
        public int Save_SDSSseconds(SDSseconds sds)
        {
            string sqli = "insert into SDS_DATASECONDS(JYLSH,JYCS,CYDS,CLID,CLHP,JCSJ,MMTIME,MMSX,MMLB,MMHC,MMCO,MMO2,MMCO2,MMLAMDA,MMZS,MMYW,MMWD,MMSD,MMDQY) values(@JYLSH,@JYCS,@CYDS,@CLID,@CLHP,@JCSJ,@MMTIME,@MMSX,@MMLB,@MMHC,@MMCO,@MMO2,@MMCO2,@MMLAMDA,@MMZS,@MMYW,@MMWD,@MMSD,@MMDQY)";
            string sqlu = "update SDS_DATASECONDS set JYLSH=@JYLSH,JYCS=@JYCS,CYDS=@CYDS,CLHP=@CLHP,JCSJ=@JCSJ,MMTIME=@MMTIME,MMSX=@MMSX,MMLB=@MMLB,MMHC=@MMHC,MMCO=@MMCO,MMO2=@MMO2,MMCO2=@MMCO2,MMLAMDA=@MMLAMDA,MMZS=@MMZS,MMYW=@MMYW,MMWD=@MMWD,MMSD=@MMSD,MMDQY=@MMDQY where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@JYLSH",sds.JYLSH), //1
                                   new SqlParameter("@JYCS",sds.JYCS), //1
                                   new SqlParameter("@CYDS",sds.CYDS), //1
                                   new SqlParameter("@CLID",sds.CLID), //1
                                   new SqlParameter("@CLHP",sds.CLHP),
                                   new SqlParameter("@JCSJ",sds.JCSJ),
                                   new SqlParameter("@MMTIME",sds.MMTIME),
                                   new SqlParameter("@MMSX",sds.MMSX),
                                   new SqlParameter("@MMLB",sds.MMLB),//6
                                   new SqlParameter("@MMHC",sds.MMHC),
                                   new SqlParameter("@MMCO",sds.MMCO),
                                   new SqlParameter("@MMO2",sds.MMO2),
                                   new SqlParameter("@MMCO2",sds.MMCO2),
                                   new SqlParameter("@MMLAMDA",sds.MMLAMDA),
                                   new SqlParameter("@MMZS",sds.MMZS),//6
                                   new SqlParameter("@MMYW",sds.MMYW),
                                   new SqlParameter("@MMWD",sds.MMWD),
                                   new SqlParameter("@MMSD",sds.MMSD),
                                   new SqlParameter("@MMDQY",sds.MMDQY)
                                   //47
                               };
            try
            {
                if (Have_SDSseconds(sds.CLID))
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
        public bool Have_SDSseconds(string CLID)
        {
            string sql = "select * from SDS_DATASECONDS where CLID=@CLID";
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
