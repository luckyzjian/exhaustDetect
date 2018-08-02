using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class selfcheckdal
    {
        #region 用检测编号和检测次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号和检测次数判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Have_SelfCheckData(string ID)
        {
            string sql = "select * from [自检记录] where ID=@ID";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",ID)
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
        public bool Delete_SelfCheckData(string ID)
        {
            string sql = "delete [自检记录] where ID=@ID";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",ID)
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

        #region 用Zyjs_Btg对象插入或更新条检测数据
        /// <summary>
        /// 用Zyjs_Btg对象插入或更新条检测数据
        /// </summary>
        /// <param name="zyjs">Zyjs_Btg</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_SelfCheckData(selfcheckdata zyjs)
        {
            string sqli = "insert into [自检记录](ID,WORKTIME,WORKER,ISQXZCHECK,ISFQYCHECK,ISBTGCHECK,ISCGJCHECK,ISLLJCHECK,ISZSJCHECK,TEMPOK,HUMIOK,AIRPOK,TEMP,HUMI,AIRP,FQYTX,FQYYR,FQYTL,FQYJL,FQYLC,FQYO2,BTGTX,BTGYR,BTGTL,BTGLC,BTGJZ,CGJTX,CGJYR,CGJQL,CGJJSGL,CGJJZHX,CGJEDGL,CGJSJGL,CGJGLWC,CGJVITRUALTIME,CGJREALTIME,CGJTIMEWC,LLJTX,LLJLL,ZSJTX,ZSJLC,"+
                "HSSlideBeginTime, HSSlideEndTime, HSSlideTheoreticalTime, HSSlideActualTime, HSSlideLoadPower, LSSlideBeginTime, LSSlideEndTime, LSSlideTheoreticalTime, LSSlideActualTime, LSSlideLoadPower,"+
            "WattlessMaxSpeed1,WattlessMinSpeed1,WattlessNorminalSpeed1,WattlessBeginTime1,WattlessEndTime1,WattlessOutput1,"+
            "WattlessMaxSpeed2,WattlessMinSpeed2,WattlessNorminalSpeed2,WattlessBeginTime2,WattlessEndTime2,WattlessOutput2,"+
            "WattlessMaxSpeed3,WattlessMinSpeed3,WattlessNorminalSpeed3,WattlessBeginTime3,WattlessEndTime3,WattlessOutput3,"+
            "WattlessMaxSpeed4,WattlessMinSpeed4,WattlessNorminalSpeed4,WattlessBeginTime4,WattlessEndTime4,WattlessOutput4,"+
            "O2MRBeginTime,O2MREndTime,WQBeginTime,WQEndTime,SlideJudge,WattlessJudge,O2MRJudge,WQJudge,AllJudge)" +
" values(@ID,@WORKTIME,@WORKER,@ISQXZCHECK,@ISFQYCHECK,@ISBTGCHECK,@ISCGJCHECK,@ISLLJCHECK,@ISZSJCHECK,@TEMPOK,@HUMIOK,@AIRPOK,@TEMP,@HUMI,@AIRP,@FQYTX,@FQYYR,@FQYTL,@FQYJL,@FQYLC,@FQYO2,@BTGTX,@BTGYR,@BTGTL,@BTGLC,@BTGJZ,@CGJTX,@CGJYR,@CGJQL,@CGJJSGL,@CGJJZHX,@CGJEDGL,@CGJSJGL,@CGJGLWC,@CGJVITRUALTIME,@CGJREALTIME,@CGJTIMEWC,@LLJTX,@LLJLL,@ZSJTX,@ZSJLC,"+
"@HSSlideBeginTime, @HSSlideEndTime, @HSSlideTheoreticalTime, @HSSlideActualTime, @HSSlideLoadPower, @LSSlideBeginTime, @LSSlideEndTime, @LSSlideTheoreticalTime, @LSSlideActualTime, @LSSlideLoadPower," +
            "@WattlessMaxSpeed1,@WattlessMinSpeed1,@WattlessNorminalSpeed1,@WattlessBeginTime1,@WattlessEndTime1,@WattlessOutput1," +
            "@WattlessMaxSpeed2,@WattlessMinSpeed2,@WattlessNorminalSpeed2,@WattlessBeginTime2,@WattlessEndTime2,@WattlessOutput2," +
            "@WattlessMaxSpeed3,@WattlessMinSpeed3,@WattlessNorminalSpeed3,@WattlessBeginTime3,@WattlessEndTime3,@WattlessOutput3," +
            "@WattlessMaxSpeed4,@WattlessMinSpeed4,@WattlessNorminalSpeed4,@WattlessBeginTime4,@WattlessEndTime4,@WattlessOutput4," +
            "@O2MRBeginTime,@O2MREndTime,@WQBeginTime,@WQEndTime,@SlideJudge,@WattlessJudge,@O2MRJudge,@WQJudge,@AllJudge" +
")";
            string sqlu = "update [自检记录] set WORKTIME=@WORKTIME,WORKER=@WORKER,ISQXZCHECK=@ISQXZCHECK,ISFQYCHECK=@ISFQYCHECK,ISBTGCHECK=@ISBTGCHECK,ISCGJCHECK=@ISCGJCHECK,ISLLJCHECK=@ISLLJCHECK,ISZSJCHECK=@ISZSJCHECK,TEMPOK=@TEMPOK,HUMIOK=@HUMIOK,AIRPOK=@AIRPOK,TEMP=@TEMP,HUMI=@HUMI,AIRP=@AIRP,FQYTX=@FQYTX,FQYYR=@FQYYR,FQYTL=@FQYTL,FQYJL=@FQYJL,FQYLC=@FQYLC,FQYO2=@FQYO2,BTGTX=@BTGTX,BTGYR=@BTGYR,BTGTL=@BTGTL,BTGLC=@BTGLC,BTGJZ=@BTGJZ,CGJTX=@CGJTX,CGJYR=@CGJYR,CGJQL=@CGJQL,CGJJSGL=@CGJJSGL,CGJJZHX=@CGJJZHX,CGJEDGL=@CGJEDGL,CGJSJGL=@CGJSJGL,CGJGLWC=@CGJGLWC,CGJVITRUALTIME=@CGJVITRUALTIME,CGJREALTIME=@CGJREALTIME,CGJTIMEWC=@CGJTIMEWC,LLJTX=@LLJTX,LLJLL=@LLJLL,ZSJTX=@ZSJTX,ZSJLC=@ZSJLC,"+
            "HSSlideBeginTime=@HSSlideBeginTime, HSSlideEndTime=@HSSlideEndTime, HSSlideTheoreticalTime=@HSSlideTheoreticalTime, HSSlideActualTime=@HSSlideActualTime, HSSlideLoadPower=@HSSlideLoadPower, LSSlideBeginTime=@LSSlideBeginTime, LSSlideEndTime=@LSSlideEndTime, LSSlideTheoreticalTime=@LSSlideTheoreticalTime, LSSlideActualTime=@LSSlideActualTime, LSSlideLoadPower=@LSSlideLoadPower," +
            "WattlessMaxSpeed1=@WattlessMaxSpeed1,WattlessMinSpeed1=@WattlessMinSpeed1,WattlessNorminalSpeed1=@WattlessNorminalSpeed1,WattlessBeginTime1=@WattlessBeginTime1,WattlessEndTime1=@WattlessEndTime1,WattlessOutput1=@WattlessOutput1," +
            "WattlessMaxSpeed2=@WattlessMaxSpeed2,WattlessMinSpeed2=@WattlessMinSpeed2,WattlessNorminalSpeed2=@WattlessNorminalSpeed2,WattlessBeginTime2=@WattlessBeginTime2,WattlessEndTime2=@WattlessEndTime2,WattlessOutput2=@WattlessOutput2," +
            "WattlessMaxSpeed3=@WattlessMaxSpeed3,WattlessMinSpeed3=@WattlessMinSpeed3,WattlessNorminalSpeed3=@WattlessNorminalSpeed3,WattlessBeginTime3=@WattlessBeginTime3,WattlessEndTime3=@WattlessEndTime3,WattlessOutput3=@WattlessOutput3," +
            "WattlessMaxSpeed4=@WattlessMaxSpeed4,WattlessMinSpeed4=@WattlessMinSpeed4,WattlessNorminalSpeed4=@WattlessNorminalSpeed4,WattlessBeginTime4=@WattlessBeginTime4,WattlessEndTime4=@WattlessEndTime4,WattlessOutput4=@WattlessOutput4," +
            "O2MRBeginTime=@O2MRBeginTime,O2MREndTime=@O2MREndTime,WQBeginTime=@WQBeginTime,WQEndTime=@WQEndTime,SlideJudge=@SlideJudge,WattlessJudge=@WattlessJudge,O2MRJudge=@O2MRJudge,WQJudge=@WQJudge,AllJudge=@AllJudge " +

                "where ID=@ID";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",zyjs.ID),
                                    new SqlParameter("@WORKTIME",zyjs.WORKTIME),
                                    new SqlParameter("@WORKER",zyjs.WORKER),
                                    new SqlParameter("@ISQXZCHECK",zyjs.ISQXZCHECK),
                                    new SqlParameter("@ISFQYCHECK",zyjs.ISFQYCHECK),
                                    new SqlParameter("@ISBTGCHECK",zyjs.ISBTGCHECK),
                                    new SqlParameter("@ISCGJCHECK",zyjs.ISCGJCHECK),
                                    new SqlParameter("@ISLLJCHECK",zyjs.ISLLJCHECK),
                                    new SqlParameter("@ISZSJCHECK",zyjs.ISZSJCHECK),
                                    new SqlParameter("@TEMPOK",zyjs.TEMPOK),
                                    new SqlParameter("@HUMIOK",zyjs.HUMIOK),
                                    new SqlParameter("@AIRPOK",zyjs.AIRPOK),
                                    new SqlParameter("@TEMP",zyjs.TEMP),
                                    new SqlParameter("@HUMI",zyjs.HUMI),
                                    new SqlParameter("@AIRP",zyjs.AIRP),
                                    new SqlParameter("@FQYTX",zyjs.FQYTX),
                                    new SqlParameter("@FQYYR",zyjs.FQYYR),
                                    new SqlParameter("@FQYTL",zyjs.FQYTL),
                                    new SqlParameter("@FQYJL",zyjs.FQYJL),
                                    new SqlParameter("@FQYLC",zyjs.FQYLC),
                                    new SqlParameter("@FQYO2",zyjs.FQYO2),
                                    new SqlParameter("@BTGTX",zyjs.BTGTX),
                                    new SqlParameter("@BTGYR",zyjs.BTGYR),
                                    new SqlParameter("@BTGTL",zyjs.BTGTL),
                                    new SqlParameter("@BTGLC",zyjs.BTGLC),
                                    new SqlParameter("@BTGJZ",zyjs.BTGJZ),
                                    new SqlParameter("@CGJTX",zyjs.CGJTX),
                                    new SqlParameter("@CGJYR",zyjs.CGJYR),
                                    new SqlParameter("@CGJQL",zyjs.CGJQL),
                                    new SqlParameter("@CGJJSGL",zyjs.CGJJSGL),
                                    new SqlParameter("@CGJJZHX",zyjs.CGJJZHX),
                                    new SqlParameter("@CGJEDGL",zyjs.CGJEDGL),
                                    new SqlParameter("@CGJSJGL",zyjs.CGJSJGL),
                                    new SqlParameter("@CGJGLWC",zyjs.CGJGLWC),
                                    new SqlParameter("@CGJVITRUALTIME",zyjs.CGJVITRUALTIME),
                                    new SqlParameter("@CGJREALTIME",zyjs.CGJREALTIME),
                                    new SqlParameter("@CGJTIMEWC",zyjs.CGJTIMEWC),
                                    new SqlParameter("@LLJTX",zyjs.LLJTX),
                                    new SqlParameter("@LLJLL",zyjs.LLJLL),
                                    new SqlParameter("@ZSJTX",zyjs.ZSJTX),
                                    new SqlParameter("@ZSJLC",zyjs.ZSJLC),

                                    new SqlParameter("@HSSlideActualTime",zyjs.HSSlideActualTime),
                                    new SqlParameter("@HSSlideTheoreticalTime",zyjs.HSSlideTheoreticalTime),
                                    new SqlParameter("@HSSlideLoadPower",zyjs.HSSlideLoadPower),
                                    new SqlParameter("@HSSlideBeginTime",zyjs.HSSlideBeginTime),
                                    new SqlParameter("@HSSlideEndTime",zyjs.HSSlideEndTime),
                                    new SqlParameter("@LSSlideActualTime",zyjs.LSSlideActualTime),
                                    new SqlParameter("@LSSlideTheoreticalTime",zyjs.LSSlideTheoreticalTime),
                                    new SqlParameter("@LSSlideLoadPower",zyjs.LSSlideLoadPower),
                                    new SqlParameter("@LSSlideBeginTime",zyjs.LSSlideBeginTime),
                                    new SqlParameter("@LSSlideEndTime",zyjs.LSSlideEndTime),
                                    new SqlParameter("@WattlessMaxSpeed1",zyjs.WattlessMaxSpeed1),
                                    new SqlParameter("@WattlessMinSpeed1",zyjs.WattlessMinSpeed1),
                                    new SqlParameter("@WattlessNorminalSpeed1",zyjs.WattlessNorminalSpeed1),
                                    new SqlParameter("@WattlessBeginTime1",zyjs.WattlessBeginTime1),
                                    new SqlParameter("@WattlessEndTime1",zyjs.WattlessEndTime1),
                                    new SqlParameter("@WattlessOutput1",zyjs.WattlessOutput1),
                                    new SqlParameter("@WattlessMaxSpeed2",zyjs.WattlessMaxSpeed2),
                                    new SqlParameter("@WattlessMinSpeed2",zyjs.WattlessMinSpeed2),
                                    new SqlParameter("@WattlessNorminalSpeed2",zyjs.WattlessNorminalSpeed2),
                                    new SqlParameter("@WattlessBeginTime2",zyjs.WattlessBeginTime2),
                                    new SqlParameter("@WattlessEndTime2",zyjs.WattlessEndTime2),
                                    new SqlParameter("@WattlessOutput2",zyjs.WattlessOutput2),
                                    new SqlParameter("@WattlessMaxSpeed3",zyjs.WattlessMaxSpeed3),
                                    new SqlParameter("@WattlessMinSpeed3",zyjs.WattlessMinSpeed3),
                                    new SqlParameter("@WattlessNorminalSpeed3",zyjs.WattlessNorminalSpeed3),
                                    new SqlParameter("@WattlessBeginTime3",zyjs.WattlessBeginTime3),
                                    new SqlParameter("@WattlessEndTime3",zyjs.WattlessEndTime3),
                                    new SqlParameter("@WattlessOutput3",zyjs.WattlessOutput3),
                                    new SqlParameter("@WattlessMaxSpeed4",zyjs.WattlessMaxSpeed4),
                                    new SqlParameter("@WattlessMinSpeed4",zyjs.WattlessMinSpeed4),
                                    new SqlParameter("@WattlessNorminalSpeed4",zyjs.WattlessNorminalSpeed4),
                                    new SqlParameter("@WattlessBeginTime4",zyjs.WattlessBeginTime4),
                                    new SqlParameter("@WattlessEndTime4",zyjs.WattlessEndTime4),
                                    new SqlParameter("@WattlessOutput4",zyjs.WattlessOutput4),
                                    new SqlParameter("@O2MRBeginTime",zyjs.O2MRBeginTime),
                                    new SqlParameter("@O2MREndTime",zyjs.O2MREndTime),
                                    new SqlParameter("@WQBeginTime",zyjs.WQBeginTime),
                                    new SqlParameter("@WQEndTime",zyjs.WQEndTime),
                                    new SqlParameter("@SlideJudge",zyjs.SlideJudge),
                                    new SqlParameter("@WattlessJudge",zyjs.WattlessJudge),
                                    new SqlParameter("@O2MRJudge",zyjs.O2MRJudge),
                                    new SqlParameter("@WQJudge",zyjs.WQJudge),
                                    new SqlParameter("@AllJudge",zyjs.AllJudge)
                               };
            try
            {
                if (Have_SelfCheckData(zyjs.ID))
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
            catch (Exception er)
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
        /// <returns>Zyjs_Btg检测数据Model</returns>
        public selfcheckdata Get_SelfCheckData(string ID)
        {
            DateTime a;
            string sql = "select * from [自检记录] where ID=@ID";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",ID)
                               };
            try
            {
                selfcheckdata zyjs = new selfcheckdata();
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    zyjs.ID = dt.Rows[0]["ID"].ToString();
                    zyjs.WORKTIME =DateTime.Parse( dt.Rows[0]["WORKTIME"].ToString());
                    zyjs.WORKER = dt.Rows[0]["WORKER"].ToString();
                    zyjs.ISQXZCHECK = dt.Rows[0]["ISQXZCHECK"].ToString();
                    zyjs.ISFQYCHECK = dt.Rows[0]["ISFQYCHECK"].ToString();
                    zyjs.ISBTGCHECK = dt.Rows[0]["ISBTGCHECK"].ToString();
                    zyjs.ISCGJCHECK = dt.Rows[0]["ISCGJCHECK"].ToString();
                    zyjs.ISLLJCHECK = dt.Rows[0]["ISLLJCHECK"].ToString();
                    zyjs.ISZSJCHECK = dt.Rows[0]["ISZSJCHECK"].ToString();
                    zyjs.TEMPOK = dt.Rows[0]["TEMPOK"].ToString();
                    zyjs.HUMIOK = dt.Rows[0]["HUMIOK"].ToString();
                    zyjs.AIRPOK = dt.Rows[0]["AIRPOK"].ToString();
                    zyjs.TEMP = dt.Rows[0]["TEMP"].ToString();
                    zyjs.HUMI = dt.Rows[0]["HUMI"].ToString();
                    zyjs.AIRP = dt.Rows[0]["AIRP"].ToString();
                    zyjs.FQYTX = dt.Rows[0]["FQYTX"].ToString();
                    zyjs.FQYYR = dt.Rows[0]["FQYYR"].ToString();
                    zyjs.FQYTL = dt.Rows[0]["FQYTL"].ToString();
                    zyjs.FQYJL = dt.Rows[0]["FQYJL"].ToString();
                    zyjs.FQYLC = dt.Rows[0]["FQYLC"].ToString();
                    zyjs.FQYO2 = dt.Rows[0]["FQYO2"].ToString();
                    zyjs.BTGTX = dt.Rows[0]["BTGTX"].ToString();
                    zyjs.BTGYR = dt.Rows[0]["BTGYR"].ToString();
                    zyjs.BTGTL = dt.Rows[0]["BTGTL"].ToString();
                    zyjs.BTGLC = dt.Rows[0]["BTGLC"].ToString();
                    zyjs.BTGJZ = dt.Rows[0]["BTGJZ"].ToString();
                    zyjs.CGJTX = dt.Rows[0]["CGJTX"].ToString();
                    zyjs.CGJYR = dt.Rows[0]["CGJYR"].ToString();
                    zyjs.CGJQL = dt.Rows[0]["CGJQL"].ToString();
                    zyjs.CGJJSGL = dt.Rows[0]["CGJJSGL"].ToString();
                    zyjs.CGJJZHX = dt.Rows[0]["CGJJZHX"].ToString();
                    zyjs.CGJEDGL = dt.Rows[0]["CGJEDGL"].ToString();
                    zyjs.CGJSJGL = dt.Rows[0]["CGJSJGL"].ToString();
                    zyjs.CGJGLWC = dt.Rows[0]["CGJGLWC"].ToString();
                    zyjs.CGJVITRUALTIME = dt.Rows[0]["CGJVITRUALTIME"].ToString();
                    zyjs.CGJREALTIME = dt.Rows[0]["CGJREALTIME"].ToString();
                    zyjs.CGJTIMEWC = dt.Rows[0]["CGJTIMEWC"].ToString();
                    zyjs.LLJTX = dt.Rows[0]["LLJTX"].ToString();
                    zyjs.LLJLL = dt.Rows[0]["LLJLL"].ToString();
                    zyjs.ZSJTX = dt.Rows[0]["ZSJTX"].ToString();
                    zyjs.ZSJLC = dt.Rows[0]["ZSJLC"].ToString();


                    zyjs.HSSlideActualTime = dt.Rows[0]["HSSlideActualTime"].ToString();
                    zyjs.HSSlideTheoreticalTime = dt.Rows[0]["HSSlideTheoreticalTime"].ToString();
                    zyjs.HSSlideLoadPower = dt.Rows[0]["HSSlideLoadPower"].ToString();
                    zyjs.HSSlideBeginTime = dt.Rows[0]["HSSlideBeginTime"].ToString();
                    zyjs.HSSlideEndTime = dt.Rows[0]["HSSlideEndTime"].ToString();
                    zyjs.LSSlideActualTime = dt.Rows[0]["LSSlideActualTime"].ToString();
                    zyjs.LSSlideTheoreticalTime = dt.Rows[0]["LSSlideTheoreticalTime"].ToString();
                    zyjs.LSSlideLoadPower = dt.Rows[0]["LSSlideLoadPower"].ToString();
                    zyjs.LSSlideBeginTime = dt.Rows[0]["LSSlideBeginTime"].ToString();
                    zyjs.LSSlideEndTime = dt.Rows[0]["LSSlideEndTime"].ToString();
                    zyjs.WattlessMaxSpeed1 = dt.Rows[0]["WattlessMaxSpeed1"].ToString();
                    zyjs.WattlessMinSpeed1 = dt.Rows[0]["WattlessMinSpeed1"].ToString();
                    zyjs.WattlessNorminalSpeed1 = dt.Rows[0]["WattlessNorminalSpeed1"].ToString();
                    zyjs.WattlessBeginTime1 = dt.Rows[0]["WattlessBeginTime1"].ToString();
                    zyjs.WattlessEndTime1 = dt.Rows[0]["WattlessEndTime1"].ToString();
                    zyjs.WattlessOutput1 = dt.Rows[0]["WattlessOutput1"].ToString();
                    zyjs.WattlessMaxSpeed2 = dt.Rows[0]["WattlessMaxSpeed2"].ToString();
                    zyjs.WattlessMinSpeed2 = dt.Rows[0]["WattlessMinSpeed2"].ToString();
                    zyjs.WattlessNorminalSpeed2 = dt.Rows[0]["WattlessNorminalSpeed2"].ToString();
                    zyjs.WattlessBeginTime2 = dt.Rows[0]["WattlessBeginTime2"].ToString();
                    zyjs.WattlessEndTime2 = dt.Rows[0]["WattlessEndTime2"].ToString();
                    zyjs.WattlessOutput2 = dt.Rows[0]["WattlessOutput2"].ToString();
                    zyjs.WattlessMaxSpeed3 = dt.Rows[0]["WattlessMaxSpeed3"].ToString();
                    zyjs.WattlessMinSpeed3 = dt.Rows[0]["WattlessMinSpeed3"].ToString();
                    zyjs.WattlessNorminalSpeed3 = dt.Rows[0]["WattlessNorminalSpeed3"].ToString();
                    zyjs.WattlessBeginTime3 = dt.Rows[0]["WattlessBeginTime3"].ToString();
                    zyjs.WattlessEndTime3 = dt.Rows[0]["WattlessEndTime3"].ToString();
                    zyjs.WattlessOutput3 = dt.Rows[0]["WattlessOutput3"].ToString();
                    zyjs.WattlessMaxSpeed4 = dt.Rows[0]["WattlessMaxSpeed4"].ToString();
                    zyjs.WattlessMinSpeed4 = dt.Rows[0]["WattlessMinSpeed4"].ToString();
                    zyjs.WattlessNorminalSpeed4 = dt.Rows[0]["WattlessNorminalSpeed4"].ToString();
                    zyjs.WattlessBeginTime4= dt.Rows[0]["WattlessBeginTime4"].ToString();
                    zyjs.WattlessEndTime4 = dt.Rows[0]["WattlessEndTime4"].ToString();
                    zyjs.WattlessOutput4 = dt.Rows[0]["WattlessOutput4"].ToString();
                    zyjs.O2MRBeginTime = dt.Rows[0]["O2MRBeginTime"].ToString();
                    zyjs.O2MREndTime = dt.Rows[0]["O2MREndTime"].ToString();
                    zyjs.WQBeginTime = dt.Rows[0]["WQBeginTime"].ToString();
                    zyjs.WQEndTime = dt.Rows[0]["WQEndTime"].ToString();
                    zyjs.SlideJudge = dt.Rows[0]["SlideJudge"].ToString();
                    zyjs.WattlessJudge = dt.Rows[0]["WattlessJudge"].ToString();
                    zyjs.O2MRJudge = dt.Rows[0]["O2MRJudge"].ToString();
                    zyjs.WQJudge = dt.Rows[0]["WQJudge"].ToString();
                    zyjs.AllJudge = dt.Rows[0]["AllJudge"].ToString();

                }
                else
                {
                    zyjs.ID = "-2";
                }
                return zyjs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
