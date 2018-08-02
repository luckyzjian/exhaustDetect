using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class ASMdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_ASM(string CARID)
        {
            string sql = "select * from asm where CLID=@CLID";
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
            string sql = "delete asm where CLID=@CLID";
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
        public int Save_ASM(ASM asm)
        {
            string sqli = "insert into asm(CLID,CLPH,CO25CLZ,CO25XZ,CO25PD,HC25CLZ,HC25XZ,HC25PD,NOX25CLZ,NOX25XZ,NOX25PD,CO40CLZ,CO40XZ,CO40PD,HC40CLZ,HC40XZ,HC40PD,NOX40CLZ,NOX40XZ,NOX40PD,ZHPD,JCRQ,WD,SD,DQY,SBMC,SBXH,SBZZC,CGJXH,CGJBH,CGJZZC,FXYXH,FXYBH,FXYZZC,FDJZS5025,FDJYW5025,FDJZS2540,FDJYW2540,JCBGBH,SHY,SYNCHDATE,YW,JCKSSJ,JCJSSJ,LAMBDA5025,LAMBDA2540,CO25025,O25025,CO22540,O22540,JYLSH,JYCS,JZZGL5025,JZZGL2540,SBRZBM) values(@CLID,@CLPH,@CO25CLZ,@CO25XZ,@CO25PD,@HC25CLZ,@HC25XZ,@HC25PD,@NOX25CLZ,@NOX25XZ,@NOX25PD,@CO40CLZ,@CO40XZ,@CO40PD,@HC40CLZ,@HC40XZ,@HC40PD,@NOX40CLZ,@NOX40XZ,@NOX40PD,@ZHPD,@JCRQ,@WD,@SD,@DQY,@SBMC,@SBXH,@SBZZC,@CGJXH,@CGJBH,@CGJZZC,@FXYXH,@FXYBH,@FXYZZC,@FDJZS5025,@FDJYW5025,@FDJZS2540,@FDJYW2540,@JCBGBH,@SHY,@SYNCHDATE,@YW,@JCKSSJ,@JCJSSJ,@LAMBDA5025,@LAMBDA2540,@CO25025,@O25025,@CO22540,@O22540,@JYLSH,@JYCS,@JZZGL5025,@JZZGL2540,@SBRZBM)";
            string sqlu = "update asm set CLPH=@CLPH,CO25CLZ=@CO25CLZ,CO25XZ=@CO25XZ,CO25PD=@CO25PD,HC25CLZ=@HC25CLZ,HC25XZ=@HC25XZ,HC25PD=@HC25PD,NOX25CLZ=@NOX25CLZ,NOX25XZ=@NOX25XZ,NOX25PD=@NOX25PD,CO40CLZ=@CO40CLZ,CO40XZ=@CO40XZ,CO40PD=@CO40PD,HC40CLZ=@HC40CLZ,HC40XZ=@HC40XZ,HC40PD=@HC40PD,NOX40CLZ=@NOX40CLZ,NOX40XZ=@NOX40XZ,NOX40PD=@NOX40PD,ZHPD=@ZHPD,JCRQ=@JCRQ,WD=@WD,SD=@SD,DQY=@DQY,SBMC=@SBMC,SBXH=@SBXH,SBZZC=@SBZZC,CGJXH=@CGJXH,CGJBH=@CGJBH,CGJZZC=@CGJZZC,FXYXH=@FXYXH,FXYBH=@FXYBH,FXYZZC=@FXYZZC,FDJZS5025=@FDJZS5025,FDJYW5025=@FDJYW5025,FDJZS2540=@FDJZS2540,FDJYW2540=@FDJYW2540,JCBGBH=@JCBGBH,SHY=@SHY,SYNCHDATE=@SYNCHDATE,YW=@YW,JCKSSJ=@JCKSSJ,JCJSSJ=@JCJSSJ,LAMBDA5025=@LAMBDA5025,LAMBDA2540=@LAMBDA2540,CO25025=@CO25025,O25025=@O25025,CO22540=@CO22540,O22540=@O22540,JYLSH=@JYLSH,JYCS=@JYCS,JZZGL5025=@JZZGL5025,JZZGL2540=@JZZGL2540,SBRZBM=@SBRZBM where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",asm.CLID), //1
                                   new SqlParameter("@CLPH",asm.CLPH), //1
                                   new SqlParameter("@CO25CLZ",asm.CO25CLZ),
                                   new SqlParameter("@CO25XZ",asm.CO25XZ),
                                   new SqlParameter("@CO25PD",asm.CO25PD),
                                   new SqlParameter("@HC25CLZ",asm.HC25CLZ),//6
                                   new SqlParameter("@HC25XZ",asm.HC25XZ),
                                   new SqlParameter("@HC25PD",asm.HC25PD),
                                   new SqlParameter("@NOX25CLZ",asm.NOX25CLZ),
                                   new SqlParameter("@NOX25XZ",asm.NOX25XZ),
                                   new SqlParameter("@NOX25PD",asm.NOX25PD),//11
                                   new SqlParameter("@CO40CLZ",asm.CO40CLZ),
                                   new SqlParameter("@CO40XZ",asm.CO40XZ),
                                   new SqlParameter("@CO40PD",asm.CO40PD),
                                   new SqlParameter("@HC40CLZ",asm.HC40CLZ),//6
                                   new SqlParameter("@HC40XZ",asm.HC40XZ),
                                   new SqlParameter("@HC40PD",asm.HC40PD),
                                   new SqlParameter("@NOX40CLZ",asm.NOX40CLZ),
                                   new SqlParameter("@NOX40XZ",asm.NOX40XZ),
                                   new SqlParameter("@NOX40PD",asm.NOX40PD),//11
                                   new SqlParameter("@ZHPD",asm.ZHPD),
                                   new SqlParameter("@JCRQ",asm.JCRQ),
                                   new SqlParameter("@WD",asm.WD),
                                   new SqlParameter("@SD",asm.SD),
                                   new SqlParameter("@DQY",asm.DQY),//16
                                   new SqlParameter("@SBMC",asm.SBMC),
                                   new SqlParameter("@SBXH",asm.SBXH),
                                   new SqlParameter("@SBZZC",asm.SBZZC),
                                   new SqlParameter("@CGJXH",asm.CGJXH),
                                   new SqlParameter("@CGJBH",asm.CGJBH),//21
                                   new SqlParameter("@CGJZZC",asm.CGJZZC),
                                   new SqlParameter("@FXYXH",asm.FXYXH),
                                   new SqlParameter("@FXYBH",asm.FXYBH),
                                   new SqlParameter("@FXYZZC",asm.FXYZZC),
                                   new SqlParameter("@FDJZS5025",asm.FDJZS5025),
                                   new SqlParameter("@FDJYW5025",asm.FDJYW5025),//21
                                   new SqlParameter("@FDJZS2540",asm.FDJZS2540),
                                   new SqlParameter("@FDJYW2540",asm.FDJYW2540),
                                   new SqlParameter("@JCBGBH",asm.JCBGBH),
                                   new SqlParameter("@SHY",asm.SHY),//21
                                   new SqlParameter("@SYNCHDATE",asm.SYNCHDATE),
                                   new SqlParameter("@YW",asm.YW),
                                   new SqlParameter("@JCKSSJ",asm.JCKSSJ),
                                   new SqlParameter("@JCJSSJ",asm.JCJSSJ),
                                   new SqlParameter("@LAMBDA5025",asm.LAMBDA5025),
                                   new SqlParameter("@LAMBDA2540",asm.LAMBDA2540),
                                   new SqlParameter("@CO25025",asm.CO25025),
                                   new SqlParameter("@O25025",asm.O25025),
                                   new SqlParameter("@CO22540",asm.CO22540),
                                   new SqlParameter("@O22540",asm.O22540),
                                   new SqlParameter("@JYLSH",asm.JYLSH),
                                   new SqlParameter("@JYCS",asm.JYCS),
                                   new SqlParameter("@JZZGL5025",asm.JZZGL5025),
                                   new SqlParameter("@JZZGL2540",asm.JZZGL2540),
                                   new SqlParameter("@SBRZBM",asm.SBRZBM)

                               };
            try
            {
                if (Have_ASM(asm.CLID))
                {
                    ini.INIIO.saveLogInf("Save_ASM()过程中发现ID号重复：" + asm.CLID);
                    if (DBHelperSQL.Execute(sqlu, spr) > 0)
                    {
                        ini.INIIO.saveLogInf("更新结果成功，ID号：" + asm.CLID);
                        return 2;
                    }
                    else
                    {
                        ini.INIIO.saveLogInf("更新结果失败，ID号：" + asm.CLID);
                        return 0;
                    }
                }
                else
                {
                    if (DBHelperSQL.Execute(sqli, spr) > 0)
                    {
                        ini.INIIO.saveLogInf("Save_ASM()成功，ID号：" + asm.CLID);
                        return 1;
                    }
                    else
                    {
                        ini.INIIO.saveLogInf("Save_ASM()失败，ID号：" + asm.CLID);
                        return 0;
                    }
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("Save_ASM()过程中出现异常：" + er.Message);
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
        public ASM Get_ASM(string CLID)
        {
            DateTime a;
            string sql = "select * from asm where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                ASM asm = new ASM();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.JCBGBH = dt.Rows[0]["JCBGBH"].ToString();
                    asm.CLPH = dt.Rows[0]["CLPH"].ToString();
                    asm.CO25CLZ = dt.Rows[0]["CO25CLZ"].ToString();
                    asm.CO25XZ = dt.Rows[0]["CO25XZ"].ToString();
                    asm.CO25PD = dt.Rows[0]["CO25PD"].ToString();
                    asm.HC25CLZ = dt.Rows[0]["HC25CLZ"].ToString();//6
                    asm.HC25XZ = dt.Rows[0]["HC25XZ"].ToString();
                    asm.HC25PD = dt.Rows[0]["HC25PD"].ToString();
                    asm.NOX25CLZ = dt.Rows[0]["NOX25CLZ"].ToString();
                    asm.NOX25XZ = dt.Rows[0]["NOX25XZ"].ToString();
                    asm.NOX25PD = dt.Rows[0]["NOX25PD"].ToString();//11
                    asm.CO40CLZ = dt.Rows[0]["CO40CLZ"].ToString();
                    asm.CO40XZ = dt.Rows[0]["CO40XZ"].ToString();
                    asm.CO40PD = dt.Rows[0]["CO40PD"].ToString();
                    asm.HC40CLZ = dt.Rows[0]["HC40CLZ"].ToString();//6
                    asm.HC40XZ = dt.Rows[0]["HC40XZ"].ToString();
                    asm.HC40PD = dt.Rows[0]["HC40PD"].ToString();
                    asm.NOX40CLZ = dt.Rows[0]["NOX40CLZ"].ToString();
                    asm.NOX40XZ = dt.Rows[0]["NOX40XZ"].ToString();
                    asm.NOX40PD = dt.Rows[0]["NOX40PD"].ToString();//11
                    asm.ZHPD = dt.Rows[0]["ZHPD"].ToString();
                    DateTime.TryParse(dt.Rows[0]["JCRQ"].ToString(), out a);
                    if (a != null)
                        asm.JCRQ = a;
                    else
                        asm.JCRQ = DateTime.Today;
                    asm.WD = dt.Rows[0]["WD"].ToString();
                    asm.SD = dt.Rows[0]["SD"].ToString();
                    asm.DQY = dt.Rows[0]["DQY"].ToString();//16
                    asm.SBMC = dt.Rows[0]["SBMC"].ToString();
                    asm.SBXH = dt.Rows[0]["SBXH"].ToString();
                    asm.SBZZC = dt.Rows[0]["SBZZC"].ToString();
                    asm.CGJXH = dt.Rows[0]["CGJXH"].ToString();
                    asm.CGJBH = dt.Rows[0]["CGJBH"].ToString();//21
                    asm.CGJZZC = dt.Rows[0]["CGJZZC"].ToString();
                    asm.FXYXH = dt.Rows[0]["FXYXH"].ToString();
                    asm.FXYBH = dt.Rows[0]["FXYBH"].ToString();
                    asm.FXYZZC = dt.Rows[0]["FXYZZC"].ToString();
                    asm.FDJZS5025 = dt.Rows[0]["FDJZS5025"].ToString();
                    asm.FDJYW5025 = dt.Rows[0]["FDJYW5025"].ToString();
                    asm.FDJZS2540 = dt.Rows[0]["FDJZS2540"].ToString();
                    asm.FDJYW5025 = dt.Rows[0]["FDJYW5025"].ToString();
                    asm.SHY = dt.Rows[0]["SHY"].ToString();
                    asm.SYNCHDATE = dt.Rows[0]["SYNCHDATE"].ToString();
                    asm.YW = dt.Rows[0]["YW"].ToString();
                    asm.JCKSSJ = dt.Rows[0]["JCKSSJ"].ToString();
                    asm.JCJSSJ = dt.Rows[0]["JCJSSJ"].ToString();
                    asm.CO25025 = dt.Rows[0]["CO25025"].ToString();
                    asm.O25025 = dt.Rows[0]["O25025"].ToString();
                    asm.CO22540 = dt.Rows[0]["CO22540"].ToString();
                    asm.O22540 = dt.Rows[0]["O22540"].ToString();
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
        #region 用检测编号和次数查询一条检测数据
        /// <summary>
        /// 用检测编号和次数查询一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>ASM检测数据Model</returns>
        public ASMseconds Get_ASMDataSeconds(string CLID)
        {
            DateTime a;
            string sql = "select * from ASM_DATASECONDS where CLID=@CLID";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLID",CLID)
                               };
            try
            {
                ASMseconds asm = new ASMseconds();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    asm.CLID = dt.Rows[0]["CLID"].ToString();//1
                    asm.CLHP = dt.Rows[0]["CLHP"].ToString();
                    asm.JCSJ = DateTime.Parse( dt.Rows[0]["JCSJ"].ToString());
                    asm.MMTIME = dt.Rows[0]["MMTIME"].ToString();
                    asm.MMSX = dt.Rows[0]["MMSX"].ToString();
                    asm.MMLB = dt.Rows[0]["MMLB"].ToString();
                    asm.MMHC = dt.Rows[0]["MMHC"].ToString();//6
                    asm.MMCO = dt.Rows[0]["MMCO"].ToString();
                    asm.MMO2 = dt.Rows[0]["MMO2"].ToString();
                    asm.MMCO2 = dt.Rows[0]["MMCO2"].ToString();
                    asm.MMNO = dt.Rows[0]["MMNO"].ToString();
                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();//6
                    asm.MMZS = dt.Rows[0]["MMZS"].ToString();
                    asm.MMXSXZ = dt.Rows[0]["MMXSXZ"].ToString();
                    asm.MMSDXZ = dt.Rows[0]["MMSDXZ"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
                    asm.MMJSGL = dt.Rows[0]["MMJSGL"].ToString();//11
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
        public ASMseconds Get_ASMDataSeconds(string clhp,DateTime jcsj)
        {
            DateTime a;
            string sql = "select * from ASM_DATASECONDS where clhp=@clhp and convert(varchar(50),jcsj,120)=convert(varchar(50),@jcsj,120)";
            SqlParameter[] spr ={
                                   new SqlParameter("@clhp",clhp),
                                   new SqlParameter("@jcsj",jcsj.ToString("yyyy-MM-dd HH:mm:ss"))
                               };
            try
            {
                ASMseconds asm = new ASMseconds();
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
                    asm.MMWD = dt.Rows[0]["MMWD"].ToString();//11
                    asm.MMSD = dt.Rows[0]["MMSD"].ToString();
                    asm.MMDQY = dt.Rows[0]["MMDQY"].ToString();
                    asm.MMCS = dt.Rows[0]["MMCS"].ToString();
                    asm.MMGL = dt.Rows[0]["MMGL"].ToString();//6
                    asm.MMZS = dt.Rows[0]["MMZS"].ToString();
                    asm.MMXSXZ = dt.Rows[0]["MMXSXZ"].ToString();
                    asm.MMSDXZ = dt.Rows[0]["MMSDXZ"].ToString();
                    asm.MMYW = dt.Rows[0]["MMYW"].ToString();
                    asm.MMJSGL = dt.Rows[0]["MMJSGL"].ToString();//11
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
        public int Save_ASMSseconds(ASMseconds asm)
        {
            string sqli = "insert into ASM_DATASECONDS(JYLSH,JYCS,CYDS,MMZSGL,CLID,CLHP,JCSJ,MMTIME,MMSX,MMLB,MMZT,MMHC,MMCO,MMO2,MMCO2,MMNO,MMWD,MMSD,MMDQY,MMCS,MMGL,MMZS,MMXSXZ,MMSDXZ,MMGLYL,MMYW,MMNL,MMJSGL) values(@JYLSH,@JYCS,@CYDS,@MMZSGL,@CLID,@CLHP,@JCSJ,@MMTIME,@MMSX,@MMLB,@MMZT,@MMHC,@MMCO,@MMO2,@MMCO2,@MMNO,@MMWD,@MMSD,@MMDQY,@MMCS,@MMGL,@MMZS,@MMXSXZ,@MMSDXZ,@MMGLYL,@MMYW,@MMNL,@MMJSGL)";
            string sqlu = "update ASM_DATASECONDS set JYLSH=@JYLSH,JYCS=@JYCS,CYDS=@CYDS,MMZSGL=@MMZSGL,CLHP=@CLHP,JCSJ=@JCSJ,MMTIME=@MMTIME,MMSX=@MMSX,MMLB=@MMLB,MMZT=@MMZT,MMHC=@MMHC,MMCO=@MMCO,MMO2=@MMO2,MMCO2=@MMCO2,MMNO=@MMNO,MMWD=@MMWD,MMSD=@MMSD,MMDQY=@MMDQY,MMCS=@MMCS,MMGL=@MMGL,MMZS=@MMZS,MMXSXZ=@MMXSXZ,MMSDXZ=@MMSDXZ,MMGLYL=@MMGLYL,MMYW=@MMYW,MMNL=@MMNL,MMJSGL=@MMJSGL where CLID=@CLID";
            SqlParameter[] spr ={
                new SqlParameter("@JYLSH",asm.JYLSH),
                new SqlParameter("@JYCS",asm.JYCS),
                new SqlParameter("@CYDS",asm.CYDS),
                new SqlParameter("@MMZSGL",asm.MMZSGL),
                                   new SqlParameter("@CLID",asm.CLID), //1
                                   new SqlParameter("@CLHP",asm.CLHP),
                                   new SqlParameter("@JCSJ",asm.JCSJ),
                                   new SqlParameter("@MMTIME",asm.MMTIME),
                                   new SqlParameter("@MMSX",asm.MMSX),
                                   new SqlParameter("@MMLB",asm.MMLB),//6
                                   new SqlParameter("@MMZT",asm.MMZT),//6
                                   new SqlParameter("@MMHC",asm.MMHC),
                                   new SqlParameter("@MMCO",asm.MMCO),
                                   new SqlParameter("@MMO2",asm.MMO2),
                                   new SqlParameter("@MMCO2",asm.MMCO2),
                                   new SqlParameter("@MMNO",asm.MMNO),
                                   new SqlParameter("@MMWD",asm.MMWD),
                                   new SqlParameter("@MMSD",asm.MMSD),
                                   new SqlParameter("@MMDQY",asm.MMDQY),
                                   new SqlParameter("@MMCS",asm.MMCS),
                                   new SqlParameter("@MMGL",asm.MMGL),
                                   new SqlParameter("@MMZS",asm.MMZS),//6
                                   new SqlParameter("@MMXSXZ",asm.MMXSXZ),
                                   new SqlParameter("@MMSDXZ",asm.MMSDXZ),//6
                                   new SqlParameter("@MMGLYL",asm.MMGLYL),
                                   new SqlParameter("@MMYW",asm.MMYW),
                                   new SqlParameter("@MMNL",asm.MMNL),
                                   new SqlParameter("@MMJSGL",asm.MMJSGL)
                                   //47
                               };
            try
            {
                if (Have_ASMseconds(asm.CLID))
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
        public bool Have_ASMseconds(string CLID)
        {
            string sql = "select * from ASM_DATASECONDS where CLID=@CLID";
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
