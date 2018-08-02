using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
    public class Main_dal
    {
        #region 测试数据库连接状态
        /// <summary>
        /// 测试数据库连接状态
        /// </summary>
        /// <returns>bool</returns>
        public bool DB_Link_Test()
        {
            if (DBHelperSQL.DB_Link_Test())
                return true;
            else
                return false;
        }
        #endregion

        #region 获取本站所有检测线信息
        /// <summary>
        /// 获取本站所有检测线信息
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetGCXXXB()
        {
            string sql = "select * from jcxxxb";
            DataTable dt = new DataTable();
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        #endregion

        #region 用检测线新建检测线
        /// <summary>
        /// 用检测线新建检测线
        /// </summary>
        /// <param name="jcx">jcxxxb Model</param>
        /// <returns>bool</returns>
        public bool Save_jcx(JCXXXB jcx)
        {
            string sql = "insert into jcxxxb values(@gyjsjip,@jcxmc,@jcfflx,@dpcgjbh,@fqfxybh,@btgydjbh,@wyzsbbh,@qtllfxybh,@LEDDPBH)";
            SqlParameter[] spr ={
                                   new SqlParameter("@gyjsjip",jcx.GYJSJIP),
                                   new SqlParameter("@jcxmc",jcx.JCXMC),
                                   new SqlParameter("@jcfflx",jcx.JCFFLX),
                                   new SqlParameter("@dpcgjbh",jcx.DPCGJBH),
                                   new SqlParameter("@fqfxybh",jcx.FQFXYBH),
                                   new SqlParameter("@btgydjbh",jcx.BTGYDJBH),
                                   new SqlParameter("@wyzsbbh",jcx.WYZSBBH),
                                   new SqlParameter("@qtllfxybh",jcx.QTLLFXYBH),
                                   new SqlParameter("@LEDDPBH",jcx.LEDDPBH)
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

        #region 用检测线更新检测线
        /// <summary>
        /// 用检测线更新检测线
        /// </summary>
        /// <param name="jcx">jcxxxb Model</param>
        /// <returns>bool</returns>
        public bool Update_jcx(JCXXXB jcx)
        {
            string sql = "update jcxxxb set gyjsjip=@gyjsjip,jcxmc=@jcxmc,jcfflx=@jcfflx,dpcgjbh=@dpcgjbh,fqfxybh=@fqfxybh,btgydjbh=@btgydjbh,wyzsbbh=@wyzsbbh,qtllfxybh=@qtllfxybh,LEDDPBH=@LEDDPBH where jcxbh=@jcxbh";
            SqlParameter[] spr ={  new SqlParameter("@jcxbh",jcx.JCXBH),
                                   new SqlParameter("@gyjsjip",jcx.GYJSJIP),
                                   new SqlParameter("@jcxmc",jcx.JCXMC),
                                   new SqlParameter("@jcfflx",jcx.JCFFLX),
                                   new SqlParameter("@dpcgjbh",jcx.DPCGJBH),
                                   new SqlParameter("@fqfxybh",jcx.FQFXYBH),
                                   new SqlParameter("@btgydjbh",jcx.BTGYDJBH),
                                   new SqlParameter("@wyzsbbh",jcx.WYZSBBH),
                                   new SqlParameter("@qtllfxybh",jcx.QTLLFXYBH),
                                   new SqlParameter("@LEDDPBH",jcx.LEDDPBH)
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

        #region 用检测线编号删除一条检测线
        /// <summary>
        /// 用检测线编号删除一条检测线
        /// </summary>
        /// <param name="jcxbh">检测线编号</param>
        /// <returns>bool</returns>
        public bool Delete_jcx(int jcxbh)
        {
            string sql = "delete from jcxxxb where jcxbh=@jcxbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcxbh",jcxbh)
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

        #region 用检测线编号获当前在线车辆数
        /// <summary>
        /// 用检测线编号获当前在线车辆数
        /// </summary>
        /// <param name="JCX">检测线编号</param>
        /// <returns>车辆数 int</returns>
        public int Get_CLS(int JCX)
        {
            int cls = 0;
            string sql = "select COUNT(JCBH) from BJCLXXB where JCBJ=@jcx";
            SqlParameter[] spr ={
                                   new SqlParameter("@jcx",JCX)
                               };
            try
            {
                cls = (int)DBHelperSQL.GetOnline(sql, CommandType.Text, spr);
                return cls;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 获取系统配置
        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <returns>SYS.Model.SYSConfig 系统配置表Model</returns>
        public SYS.Model.SYSConfig Get_SYSConfig()
        {
            string sql = "select * from sysconfig";
            SYS.Model.SYSConfig sys=new SYSConfig();
            DataTable dt = new DataTable();
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    sys.DYSJ = dt.Rows[0]["DYSJ"].ToString();
                    int a=0;
                    int.TryParse(dt.Rows[0]["FCFS"].ToString(), out a);
                    sys.FCFS = a;
                    a=0;
                    int.TryParse(dt.Rows[0]["QXZ"].ToString(), out a);
                    sys.QXZ = a;
                    a=0;
                    int.TryParse(dt.Rows[0]["DYJCCS"].ToString(), out a);
                    sys.DYJCCS = a;
                    a = 0;
                    int.TryParse(dt.Rows[0]["Interval"].ToString(), out a);
                    if (a == 0)
                        sys.Interval = 100;
                    else
                        sys.Interval = a;
                }
                return sys;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 更新保存系统设置
        /// <summary>
        /// 更新保存系统设置
        /// </summary>
        /// <param name="sys">SYS.Model.SYSConfig Model</param>
        /// <returns>bool</returns>
        public bool Save_Sys_Config(SYS.Model.SYSConfig sys)
        {
            string sql = "update SYSConfig set DYSJ=@dysj,DYJCCS=@dyjccs,FCFS=@fcfs,QXZ=@qxz,Interval=@Interval";
            SqlParameter[] spr ={
                                    new SqlParameter("@dysj",sys.DYSJ),
                                    new SqlParameter("@dyjccs",sys.DYJCCS),
                                    new SqlParameter("@fcfs",sys.FCFS),
                                    new SqlParameter("@qxz",sys.QXZ),
                                    new SqlParameter("@Interval",sys.Interval)
                               };
            try
            {
                int i = DBHelperSQL.Execute(sql, spr);
                if (i > 0)
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

        #region 用用户名和密码登陆获取用户所有信息
        /// <summary>
        /// 用用户名和密码登陆获取用户所有信息
        /// </summary>
        /// <param name="user">string 用户名</param>
        /// <returns>datatable 用户表和职位表</returns>
        public DataTable User_Login(string user)
        {
            string sqluser = "select * from YGB left join zwb on zwbh=YGZWBH where user_name=@user";
            DataTable dt=null;
            SqlParameter[] spr={
                                   new SqlParameter("@user",user)
                               };
            try
            {
                dt = DBHelperSQL.GetDataTable(sqluser, CommandType.Text, spr);
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }
        #endregion

        #region 获取职位列表并按职位编号排序
        /// <summary>
        /// 获取职位列表并按职位编号排序
        /// </summary>
        /// <returns>List泛型</returns>
        public List<string> Get_ygzw()
        {
            List<string> a = new List<string>();
            string sql = "select zwmc from ZWB order by zwbh desc";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a.Add(dt.Rows[i]["ZWMC"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return a;
        }
        #endregion

        #region 用职位名称获取一个职位
        /// <summary>
        /// 用职位名称获取一个职位
        /// </summary>
        /// <param name="ZWMC">string 职位名称</param>
        /// <returns>ZWB Model</returns>
        public ZWB Get_ZWBH(string ZWMC)
        {
            string sql = "select * from zwb where zwmc=@zwmc";
            SqlParameter[] spr ={
                                   new SqlParameter("@zwmc",ZWMC)
                               };
            ZWB zw = new ZWB();
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                {
                    zw.ZWBH = Convert.ToInt32(dt.Rows[0]["ZWBH"].ToString());
                    zw.ZWMC = dt.Rows[0]["ZWMC"].ToString();
                    zw.ZWQX = Convert.ToInt32(dt.Rows[0]["ZWQX"].ToString());
                    zw.ZWSM = dt.Rows[0]["ZWSM"].ToString();
                }
                return zw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 获取所有员工
        /// <summary>
        /// 获取所有员工
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable Get_yg()
        {
            string sql = "select YGBH,YGXM,DHHM,(select ZWMC from ZWB where ZWBH=YGZWBH)as zw,YGSFZ,YGZT,User_Name,Password from ygb";
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 获取所有员工list 泛型
        /// <summary>
        /// 获取所有员工list 泛型
        /// </summary>
        /// <returns>list 泛型</returns>
        public List<string> Get_yg_list()
        {
            string sql = "select YGBH,YGXM,DHHM,(select ZWMC from ZWB where ZWBH=YGZWBH)as zw,YGSFZ,YGZT,User_Name,Password from ygb";
            try
            {
                DataTable dt = new DataTable();
                List<string> result = new List<string>();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr[1].ToString());
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 验证用户名是否可用
        /// <summary>
        /// 验证用户名是否可用
        /// </summary>
        /// <param name="User_Name">用户名</param>
        /// <returns>bool</returns>
        public bool Find_User(string User_Name)
        {
            string sql = "select * from ygb where user_name=@user_name";
            SqlParameter[] spr ={
                                   new SqlParameter("@user_name",User_Name)
                               };
            DataTable dt = new DataTable();
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                if (dt.Rows.Count > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 用YGB Model保存一个员工
        /// <summary>
        /// 用YGB Model保存一个员工
        /// </summary>
        /// <param name="yg">YGB Model</param>
        /// <returns>bool</returns>
        public bool Save_YG(YGB yg)
        {
            string sql = "insert into YGB values(@ygxm,@dhhm,@ygzwbh,@ygsfz,@ygzt,@user_name,@password)";
            SqlParameter[] spr ={
                                   new SqlParameter("@ygxm",yg.YGXM),
                                   new SqlParameter("@dhhm",yg.DHHM),
                                   new SqlParameter("@ygzwbh",yg.YGZWBH),
                                   new SqlParameter("@ygzt",yg.YGZT),
                                   new SqlParameter("@ygsfz",yg.YGSFZ),
                                   new SqlParameter("@user_name",yg.User_Name),
                                   new SqlParameter("@password",yg.Password)
                               };
            try
            {
                int i = DBHelperSQL.Execute(sql, spr);
                if (i > 0)
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
        
        #region 用YGB Model更新一个员工
        /// <summary>
        /// 用YGB Model更新一个员工
        /// </summary>
        /// <param name="yg">YGB Model</param>
        /// <returns>bool</returns>
        public bool Update_YG(YGB yg)
        {
            string sql = "update YGB set YGXM=@YGXM,DHHM=@DHHM,YGZWBH=@YGZWBH,YGSFZ=@YGSFZ,YGZT=@YGZT,USER_NAME=@USER_NAME,PASSWORD=@PASSWORD where ygbh=@ygbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@YGXM",yg.YGXM),
                                   new SqlParameter("@DHHM",yg.DHHM),
                                   new SqlParameter("@YGZWBH",yg.YGZWBH),
                                   new SqlParameter("@YGSFZ",yg.YGSFZ),
                                   new SqlParameter("@YGZT",yg.YGZT),
                                   new SqlParameter("@USER_NAME",yg.User_Name),
                                   new SqlParameter("@PASSWORD",yg.Password),
                                   new SqlParameter("@ygbh",yg.YGBH)
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

        #region 用用户编号删除员工
        /// <summary>
        /// 用用户编号删除员工
        /// </summary>
        /// <param name="YGBH">int 员工编号</param>
        /// <returns>bool</returns>
        public bool Delete_YG(int YGBH)
        {
            string sql = "delete ygb where ygbh=@ygbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@ygbh",YGBH)
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

        #region 获取检测站设置
        /// <summary>
        /// 获取检测站设置
        /// </summary>
        /// <returns>JCZXXB</returns>
        public JCZXXB Get_JCZ()
        {
            string sql = "select * from jczxxb";
            try
            {
                DataTable dt = new DataTable();
                JCZXXB jcz = new JCZXXB();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    jcz.JCZBH = dt.Rows[0]["JCZBH"].ToString();
                    jcz.JCZMC=dt.Rows[0]["JCZMC"].ToString();
                    jcz.JCZDZ = dt.Rows[0]["JCZDZ"].ToString();
                    jcz.JCZDH = dt.Rows[0]["JCZDH"].ToString();
                    jcz.JCZFZR = dt.Rows[0]["JCZFZR"].ToString();
                }
                return jcz;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 更新检测站设置
        /// <summary>
        /// 更新检测站设置
        /// </summary>
        /// <param name="jcz">JCZXXB</param>
        /// <returns>bool</returns>
        public bool Update_jcz(JCZXXB jcz)
        {
            string sql = "update jczxxb set jczbh=@jczbh,jczmc=@jczmc,jczdh=@jczdh,jczdz=@jczdz,jczfzr=@jczfzr";
            SqlParameter[] spr ={
                                   new SqlParameter("@jczbh",jcz.JCZBH),
                                   new SqlParameter("@jczmc",jcz.JCZMC),
                                   new SqlParameter("@jczdh",jcz.JCZDH),
                                   new SqlParameter("@jczdz",jcz.JCZDZ),
                                   new SqlParameter("@jczfzr",jcz.JCZFZR)
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

        #region 获取所有设备
        /// <summary>
        /// 获取所有设备
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable Get_sb()
        {
            string sql = "select * from sbxxb";
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql,CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 用设备信息保存设备
        /// <summary>
        /// 用设备信息保存设备
        /// </summary>
        /// <param name="sb">SBXXB</param>
        /// <returns>bool</returns>
        public bool Save_sb(SBXXB sb)
        {
            string sql = "insert into sbxxb values(@sblx,@sbmc,@sccj,@syzt,@xhtd,@gdtd,@cktd,@sbms)";
            SqlParameter[] spr ={
                                   new SqlParameter("@sblx",sb.SBLX),
                                   new SqlParameter("@sbmc",sb.SBMC),
                                   new SqlParameter("@sccj",sb.SCCJ),
                                   new SqlParameter("@syzt",sb.SYZT),
                                   new SqlParameter("@xhtd",sb.XHTD),
                                   new SqlParameter("@gdtd",sb.GDTD),
                                   new SqlParameter("@cktd",sb.CKTD),
                                   new SqlParameter("@sbms",sb.SBMS)
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

        #region 用设备信息更新设备
        /// <summary>
        /// 用设备信息更新设备
        /// </summary>
        /// <param name="sb">SBXXB</param>
        /// <returns>bool</returns>
        public bool Update_sb(SBXXB sb)
        {
            string sql = "update sbxxb set sblx=@sblx,sbmc=@sbmc,sccj=@sccj,syzt=@syzt,sbms=@sbms,xhtd=@xhtd,gdtd=@gdtd,cktd=@cktd where sbbh=@sbbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbbh",sb.SBBH),
                                   new SqlParameter("@sblx",sb.SBLX),
                                   new SqlParameter("@sbmc",sb.SBMC),
                                   new SqlParameter("@sccj",sb.SCCJ),
                                   new SqlParameter("@syzt",sb.SYZT),
                                   new SqlParameter("@xhtd",sb.XHTD),
                                   new SqlParameter("@gdtd",sb.GDTD),
                                   new SqlParameter("@cktd",sb.CKTD),
                                   new SqlParameter("@sbms",sb.SBMS)
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

        #region 用设备编号删除一个设备
        /// <summary>
        /// 用设备编号删除一个设备
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>bool</returns>
        public bool Delete_sb(int sbbh)
        {
            string sql = "delete from sbxxb where sbbh=@sbbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbbh",sbbh)
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

        #region 用设备名称获取设备编号
        /// <summary>
        ///用设备名称获取设备编号
        /// </summary>
        /// <param name="sbmc">设备名称</param>
        /// <returns>int</returns>
        public int Get_Sbbh(string sbmc)
        {
            string sql = "select sbbh from sbxxb where sbmc=@sbmc";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbmc",sbmc)
                               };
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                int i = 0;
                if (dt.Rows.Count > 0)
                    i = int.Parse(dt.Rows[0][0].ToString());
                return i;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 用设备编号获取设备信息
        /// <summary>
        /// 用设备编号获取设备信息
        /// </summary>
        /// <param name="sbbh">设备编号</param>
        /// <returns>DataTable</returns>
        public DataTable Get_sb_by_bh(int sbbh)
        {
            string sql = "select * from sbxxb where sbbh=@sbbh";
            SqlParameter[] spr ={
                                   new SqlParameter("@sbbh",sbbh)
                               };
            try
            {
                DataTable dt = new DataTable();
                dt=DBHelperSQL.GetDataTable(sql,CommandType.Text,spr);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
