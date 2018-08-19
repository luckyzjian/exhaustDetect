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
    public class operatorMode
    {
        public string ID { set; get; }
        public string CLHP { set; get; }
        public string STATUS { set; get; }
        public string UPDATETIME { set; get; }
        public string LINEID { set; get; }
        public string YL1 { set; get; }
        public string YL2 { set; get; }
        public string YL3 { set; get; }
        public string YL4 { set; get; }

    }
    public partial class loginInfControl
    {

        #region 用车号插入一条运行记录数据
        /// <summary>
        /// 用检测编号和检测次数删除一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>bool</returns>
        public bool Delete_OperateRecord(string clhp)
        {
            string sql = "delete [运行状态] where CLHP=@CLHP";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLHP",clhp)
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

        #region 用检测编号和次数查询一条检测数据
        /// <summary>
        /// 用检测编号和次数查询一条检测数据
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <param name="jccs">检测次数</param>
        /// <returns>JZJS检测数据Model</returns>
        public bool Have_OperatorRecord(string CLHP)
        {
            string sql = "select * from [运行状态] where CLHP=@CLHP";
            SqlParameter[] spr ={
                                   new SqlParameter("@CLHP",CLHP)
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

        #region 用车辆号牌插入一条运行状态记录
        /// <summary>
        /// 用JZJS对象插入或更新条检测数据
        /// </summary>
        /// <param name="JZJS">JZJS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_OperateRecord(operatorMode model)
        {
            string sqli = "insert into [运行状态](ID,UPDATETIME,CLHP,LINEID,STATUS,YL1,YL2,YL3,YL4) values(@ID,@UPDATETIME,@CLHP,@LINEID,@STATUS,@YL1,@YL2,@YL3,@YL4)";
            string sqlu = "update [运行状态] set ID=@ID,UPDATETIME=@UPDATETIME,LINEID=@LINEID,STATUS=@STATUS,YL1=@YL1,YL2=@YL2,YL3=@YL3,YL4=@YL4 where CLHP=@CLHP";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",model.ID), //1
                                   new SqlParameter("@UPDATETIME",model.UPDATETIME),
                                   new SqlParameter("@CLHP",model.CLHP),
                                   new SqlParameter("@LINEID",model.LINEID),
                                   new SqlParameter("@STATUS",model.STATUS),
                                   new SqlParameter("@YL1",model.YL1),//6
                                   new SqlParameter("@YL2",model.YL2),
                                   new SqlParameter("@YL3",model.YL3),
                                   new SqlParameter("@YL4",model.YL4)
                               };
            try
            {
                if (Have_OperatorRecord(model.CLHP))
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
        #region 获取登陆界面的默认信息
        public bool getTHP(out DateTime updatetime, out double wd,out double sd,out double dqy)
        {
            string sql = "select * from [温湿度共享]";
            wd = 0;
            sd = 0;
            dqy = 0;
            updatetime = DateTime.Now;
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    wd = double.Parse(dt.Rows[0]["WD"].ToString());
                    sd = double.Parse(dt.Rows[0]["SD"].ToString());
                    dqy = double.Parse(dt.Rows[0]["DQY"].ToString());
                    updatetime=DateTime.Parse(dt.Rows[0]["UPDATETIME"].ToString());
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region 获取登陆界面的默认信息
        public loginInfModel getLoginDefaultInf()
        {
            DateTime a,b;
            loginInfModel model = new loginInfModel();
            string sql = "select * from [登录默认]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    model.CZ = dt.Rows[0]["CZ"].ToString();
                    model.SYXZ = dt.Rows[0]["SYXZ"].ToString();
                    model.PP = dt.Rows[0]["PP"].ToString();
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.CLSBM = dt.Rows[0]["CLSBM"].ToString();
                    model.FDJHM = dt.Rows[0]["FDJHM"].ToString();
                    model.FDJXH = dt.Rows[0]["FDJXH"].ToString();
                    model.SCQY = dt.Rows[0]["SCQY"].ToString();
                    model.HDZK = dt.Rows[0]["HDZK"].ToString();
                    model.JSSZK = dt.Rows[0]["JSSZK"].ToString();
                    model.ZZL = dt.Rows[0]["ZZL"].ToString();
                    model.HDZZL = dt.Rows[0]["HDZZL"].ToString();
                    model.ZBZL = dt.Rows[0]["ZBZL"].ToString();
                    model.JZZL = dt.Rows[0]["JZZL"].ToString();
                    DateTime.TryParse(dt.Rows[0]["ZCRQ"].ToString(),out a);
                    if (a != null)
                        model.ZCRQ = a;
                    else
                        model.ZCRQ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["SCRQ"].ToString(), out b);
                    if (a != null)
                        model.SCRQ = b;
                    else
                        model.SCRQ = DateTime.Today;
                    model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    model.RLZL = dt.Rows[0]["RLZL"].ToString();
                    model.EDGL = dt.Rows[0]["EDGL"].ToString();
                    model.EDZS = dt.Rows[0]["EDZS"].ToString();
                    model.BSQXS = dt.Rows[0]["BSQXS"].ToString();
                    model.DWS = dt.Rows[0]["DWS"].ToString();
                    model.GYFS = dt.Rows[0]["GYFS"].ToString();
                    model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    model.JQFS = dt.Rows[0]["JQFS"].ToString();
                    model.QGS = dt.Rows[0]["QGS"].ToString();
                    model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    model.CHZZ = dt.Rows[0]["CHZZ"].ToString();
                    model.DLSP = dt.Rows[0]["DLSP"].ToString();
                    model.SFSRL = dt.Rows[0]["SFSRL"].ToString();
                    model.JHZZ = dt.Rows[0]["JHZZ"].ToString();
                    model.OBD = dt.Rows[0]["OBD"].ToString();
                    model.DKGYYB = dt.Rows[0]["DKGYYB"].ToString();
                    model.LXDH = dt.Rows[0]["LXDH"].ToString();
                }
                else
                    model.CLHP = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取comBoBox的Items值
        public DataTable getComBoBoxItemsInf(string comboboxName)
        {
            string sql = "select * from" + " [" + comboboxName + "]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                    return null;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        #endregion
        #region 根据comBoBox的Items值获得对应的ID值
        public string  getComBoBoxItemsID(string comboboxName,string itemName)
        {
            string sql = "select * from" + " [" + comboboxName + "]"+" where MC='"+itemName+"'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID"].ToString();
                }
                else
                    return "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 根据comBoBox的ID值获得对应的items值
        public string getComBoBoxItemsNAME(string comboboxName, string itemID)
        {
            string sql = "select * from" + " [" + comboboxName + "]" + " where ID='" + itemID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MC"].ToString();
                }
                else
                    return " ";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 根据STAFFID值获得对应的员工名
        public string getNAMEByID(string ID)
        {
            string sql = "select * from" + " [员工]" + " where STAFFID='" + ID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["NAME"].ToString();
                }
                else
                    return "";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 根据员工名获取对应的STAFFID
        public string getStaffIDbyName(string name)
        {
            string sql = "select STAFFID from [员工] where NAME='" + name + "'";
            string postid = "";
            try
            {

                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    postid = dt.Rows[0]["STAFFID"].ToString();

                }
                else
                    postid = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return postid;
        }
        #endregion
        #region 获取所有的员工
        public DataTable getAllStaff()
        {
            string sql = "select * from [员工]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 检查员工是否存在
        public bool checkUserIsAlive(string userName,string password)
        {
            string sql = "select * from [员工] where NAME='" + userName + "' and PASSWORD='"+password+"'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
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
        #region 获取员工的密码
        public string requestUserPassword(string userName)
        {
            string sql = "select PASSWORD from [员工] where NAME='" + userName + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["PASSWORD"].ToString();
                }
                else
                    return "";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                return "";
                throw;
            }

        }
        #endregion
        
        public bool saveStaffInf(staffModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [员工] (");
            strSql.Append("STAFFID,");
            strSql.Append("NAME,");
            strSql.Append("POSTID,");
            strSql.Append("SEX,");
            strSql.Append("BIRTHDAY,");
            strSql.Append("AGE,");
            strSql.Append("ID,");
            strSql.Append("EDUCATION,");
            strSql.Append("MARRIED,");
            strSql.Append("ADDRESS,");
            strSql.Append("PHONE,");
            strSql.Append("QQ,");
            strSql.Append("EMAIL,");

            strSql.Append("CZRYXKZH,");
            strSql.Append("YXQSTARTTIME,");
            strSql.Append("YXQENDTIME,");
            strSql.Append("ISLOCK,");
            strSql.Append("LOCKREASON,");

            strSql.Append("PASSWORD)");
            strSql.Append("values (@STAFFID,@NAME,@POSTID,@SEX,@BIRTHDAY,@AGE,@ID,@EDUCATION,@MARRIED,@ADDRESS,@PHONE,@QQ,@EMAIL,@CZRYXKZH,@YXQSTARTTIME,@YXQENDTIME,@ISLOCK,@LOCKREASON,@PASSWORD)");
            SqlParameter[] parameters =
            {
                new SqlParameter("@STAFFID", SqlDbType.VarChar,50),
                 new SqlParameter("@NAME", SqlDbType.VarChar,50),
                new SqlParameter("@POSTID", SqlDbType.VarChar,50),
                new SqlParameter("@SEX", SqlDbType.VarChar,50),
                new SqlParameter("@BIRTHDAY", SqlDbType.VarChar,50),
                 new SqlParameter("@AGE", SqlDbType.VarChar,50),
                new SqlParameter("@ID", SqlDbType.VarChar,50),
                new SqlParameter("@EDUCATION", SqlDbType.VarChar,50),
                new SqlParameter("@MARRIED", SqlDbType.VarChar,50),
                 new SqlParameter("@ADDRESS", SqlDbType.VarChar,50),
                new SqlParameter("@PHONE", SqlDbType.VarChar,50),
                new SqlParameter("@QQ", SqlDbType.VarChar,50),
                new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
                 new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
                 new SqlParameter("@CZRYXKZH", SqlDbType.VarChar,50),
                new SqlParameter("@YXQSTARTTIME", SqlDbType.DateTime),
                new SqlParameter("@YXQENDTIME", SqlDbType.DateTime),
                new SqlParameter("@ISLOCK", SqlDbType.VarChar,50),
                 new SqlParameter("@LOCKREASON", SqlDbType.VarChar,50)
                };
            parameters[i++].Value = model.STAFFID;
            parameters[i++].Value = model.NAME;
            parameters[i++].Value = model.POSTID;
            parameters[i++].Value = model.SEX;
            parameters[i++].Value = model.BIRTHDAY;
            parameters[i++].Value = model.AGE;
            parameters[i++].Value = model.ID;
            parameters[i++].Value = model.EDUCATION;
            parameters[i++].Value = model.MARRIED;
            parameters[i++].Value = model.ADDRESS;
            parameters[i++].Value = model.PHONE;
            parameters[i++].Value = model.QQ;
            parameters[i++].Value = model.EMAIL;
            parameters[i++].Value = model.PASSWORD;
            parameters[i++].Value = model.CZRYXKZH;
            parameters[i++].Value = model.YXQSTARTTIME;
            parameters[i++].Value = model.YXQENDTIME;
            parameters[i++].Value = model.ISLOCK?"Y":"N";
            parameters[i++].Value = model.LOCKREASON;
            try
            {
                if (checkUserIsAlive(model.STAFFID))
                {
                    if (updateStaffInf(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region 检查员工是否存在
        public bool checkUserIsAlive(string USERID)
        {
            string sql = "select * from [员工] where STAFFID='" + USERID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
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
        public bool updateStaffInf(staffModel model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [员工] set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("POSTID=@POSTID,");
            strSql.Append("SEX=@SEX,");
            strSql.Append("BIRTHDAY=@BIRTHDAY,");
            strSql.Append("AGE=@AGE,");
            strSql.Append("ID=@ID,");
            strSql.Append("EDUCATION=@EDUCATION,");
            strSql.Append("MARRIED=@MARRIED,");
            strSql.Append("ADDRESS=@ADDRESS,");
            strSql.Append("PHONE=@PHONE,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("PASSWORD=@PASSWORD");
            strSql.Append(" where STAFFID='" + model.STAFFID + "'");
            SqlParameter[] parameters =
            {
                //new SqlParameter("@STAFFID", SqlDbType.VarChar,50),
                 new SqlParameter("@NAME", SqlDbType.VarChar,50),
                new SqlParameter("@POSTID", SqlDbType.VarChar,50),
                new SqlParameter("@SEX", SqlDbType.VarChar,50),
                new SqlParameter("@BIRTHDAY", SqlDbType.VarChar,50),
                 new SqlParameter("@AGE", SqlDbType.VarChar,50),
                new SqlParameter("@ID", SqlDbType.VarChar,50),
                new SqlParameter("@EDUCATION", SqlDbType.VarChar,50),
                new SqlParameter("@MARRIED", SqlDbType.VarChar,50),
                 new SqlParameter("@ADDRESS", SqlDbType.VarChar,50),
                new SqlParameter("@PHONE", SqlDbType.VarChar,50),
                new SqlParameter("@QQ", SqlDbType.VarChar,50),
                new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
                 new SqlParameter("@PASSWORD", SqlDbType.VarChar,50)
                };
            //parameters[i++].Value = model.STAFFID;
            parameters[i++].Value = model.NAME;
            parameters[i++].Value = model.POSTID;
            parameters[i++].Value = model.SEX;
            parameters[i++].Value = model.BIRTHDAY;
            parameters[i++].Value = model.AGE;
            parameters[i++].Value = model.ID;
            parameters[i++].Value = model.EDUCATION;
            parameters[i++].Value = model.MARRIED;
            parameters[i++].Value = model.ADDRESS;
            parameters[i++].Value = model.PHONE;
            parameters[i++].Value = model.QQ;
            parameters[i++].Value = model.EMAIL;
            parameters[i++].Value = model.PASSWORD;
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
        public bool deleteOnePerson(string carID)
        {
            string sql = "delete from [员工] where STAFFID='" + carID + "'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        public staffModel GetStaffInf(string clid)
        {
            int i = 0;
            staffModel model = new staffModel();
            StringBuilder strSql = new StringBuilder();
            string sql = "select * from [员工] where STAFFID='" + clid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    DateTime datetime;
                    model.STAFFID = dt.Rows[0]["STAFFID"].ToString();
                    model.NAME = dt.Rows[0]["NAME"].ToString();
                    model.POSTID = dt.Rows[0]["POSTID"].ToString();
                    model.SEX = dt.Rows[0]["SEX"].ToString();
                    model.BIRTHDAY = dt.Rows[0]["BIRTHDAY"].ToString();
                    model.AGE = dt.Rows[0]["AGE"].ToString();
                    model.ID = dt.Rows[0]["ID"].ToString();
                    model.EDUCATION = dt.Rows[0]["EDUCATION"].ToString();
                    model.MARRIED = dt.Rows[0]["MARRIED"].ToString();
                    model.ADDRESS = dt.Rows[0]["ADDRESS"].ToString();
                    model.PHONE = dt.Rows[0]["PHONE"].ToString();
                    model.QQ = dt.Rows[0]["QQ"].ToString();
                    model.EMAIL = dt.Rows[0]["EMAIL"].ToString();
                    model.PASSWORD = dt.Rows[0]["PASSWORD"].ToString();
                    model.CZRYXKZH = dt.Rows[0]["CZRYXKZH"].ToString();
                    if (DateTime.TryParse(dt.Rows[0]["YXQSTARTTIME"].ToString(), out datetime))
                    { model.YXQSTARTTIME = datetime; }
                    else
                    { model.YXQSTARTTIME = DateTime.Now; }
                    if (DateTime.TryParse(dt.Rows[0]["YXQENDTIME"].ToString(), out datetime))
                    { model.YXQENDTIME = datetime; }
                    else
                    { model.YXQENDTIME = DateTime.Now; }
                    model.ISLOCK =( dt.Rows[0]["ISLOCK"].ToString()=="Y");
                    model.LOCKREASON = dt.Rows[0]["LOCKREASON"].ToString();
                }
                else
                    model.STAFFID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                return model;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool reWritePassword(string clid, string newpassword)
        {
            string sql = "update [员工] set PASSWORD=" + "'" + newpassword + "'" + " where STAFFID='" + clid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        #region 检查员工是否存在
        public DataTable getStaffByPost(string postID)
        {
            string sql = "select * from [员工] where postid='" + postID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 检查员工是否存在
        public DataTable getStaffByName(string postID)
        {
            string sql = "select * from [员工] where NAME='" + postID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 获取职位对应的权限
        public postModel getPostQx(string postID)
        {
            SYS_MODEL.postModel model = new SYS_MODEL.postModel();
            string sql = "select * from [职位] where POSTID='"+postID+"'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.POSTID = dt.Rows[0]["POSTID"].ToString();
                    model.MC = dt.Rows[0]["MC"].ToString();
                    model.POSTRIGHT = dt.Rows[0]["POSTRIGHT"].ToString();
                    model.LOGINQX = dt.Rows[0]["LOGINQX"].ToString();
                    model.GONGWEIQX = dt.Rows[0]["GONGWEIQX"].ToString();
                    model.PRINTQX = dt.Rows[0]["PRINTQX"].ToString();
                    model.SETTINGSQX = dt.Rows[0]["SETTINGSQX"].ToString();
                    model.CHECKQX = dt.Rows[0]["CHECKQX"].ToString();
                    
                }
                else
                    model.POSTID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion

        #region 获取职位对应的ID
        public string getPostIDbyPostName(string postName)
        {
            string sql = "select POSTID from [职位] where MC='" + postName + "'";
            string postid = "";
            try
            {

                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    postid = dt.Rows[0]["POSTID"].ToString();

                }
                else
                    postid = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return postid;
        }
        #endregion

        #region 获取职位对应的ID
        public string getPostNamebyPostID(string postID)
        {
            string sql = "select MC from [职位] where POSTID='" + postID + "'";
            string postid = "";
            try
            {

                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    postid = dt.Rows[0]["MC"].ToString();

                }
                else
                    postid = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return postid;
        }
        #endregion
        
        #region 根据车牌号检查该车信息是否存在
        public bool checkCarInfIsAlive(string plateNumber)
        {
            string sql = "select * from [车辆信息] where CLHP='" + plateNumber + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
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
        public CARINF getCarInfbyPlate(string plateNumber)
        {
            DateTime a, b;
            CARINF model = new CARINF();
            string sql = "select * from [车辆信息] where CLHP='" + plateNumber + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();//1
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.HPZL = dt.Rows[0]["HPZL"].ToString();
                    model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    model.CZ = dt.Rows[0]["CZ"].ToString();
                    model.SYXZ = dt.Rows[0]["SYXZ"].ToString();
                    model.PP = dt.Rows[0]["PP"].ToString();//5
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.CLSBM = dt.Rows[0]["CLSBM"].ToString();
                    model.FDJHM = dt.Rows[0]["FDJHM"].ToString();
                    model.FDJXH = dt.Rows[0]["FDJXH"].ToString();
                    model.SCQY = dt.Rows[0]["SCQY"].ToString();//10
                    model.HDZK = dt.Rows[0]["HDZK"].ToString();
                    model.JSSZK = dt.Rows[0]["JSSZK"].ToString();
                    model.ZZL = dt.Rows[0]["ZZL"].ToString();
                    model.HDZZL = dt.Rows[0]["HDZZL"].ToString();
                    model.ZBZL = dt.Rows[0]["ZBZL"].ToString();//15
                    model.JZZL = dt.Rows[0]["JZZL"].ToString();
                    DateTime.TryParse(dt.Rows[0]["ZCRQ"].ToString(), out a);
                    if (a != null)
                        model.ZCRQ = a;
                    else
                        model.ZCRQ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["SCRQ"].ToString(), out b);
                    if (a != null)
                        model.SCRQ = b;
                    else
                        model.SCRQ = DateTime.Today;
                    model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    model.RLZL = dt.Rows[0]["RLZL"].ToString();//20
                    model.EDGL = dt.Rows[0]["EDGL"].ToString();
                    model.EDZS = dt.Rows[0]["EDZS"].ToString();
                    model.BSQXS = dt.Rows[0]["BSQXS"].ToString();
                    model.DWS = dt.Rows[0]["DWS"].ToString();
                    model.GYFS = dt.Rows[0]["GYFS"].ToString();//25
                    model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    model.JQFS = dt.Rows[0]["JQFS"].ToString();
                    model.QGS = dt.Rows[0]["QGS"].ToString();
                    model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    model.CHZZ = dt.Rows[0]["CHZZ"].ToString();//30
                    model.DLSP = dt.Rows[0]["DLSP"].ToString();
                    model.SFSRL = dt.Rows[0]["SFSRL"].ToString();
                    model.JHZZ = dt.Rows[0]["JHZZ"].ToString();
                    model.OBD = dt.Rows[0]["OBD"].ToString();
                    model.DKGYYB = dt.Rows[0]["DKGYYB"].ToString();//35
                    model.LXDH = dt.Rows[0]["LXDH"].ToString();
                    model.CZDZ = dt.Rows[0]["CZDZ"].ToString();
                    model.JCFS = dt.Rows[0]["JCFS"].ToString();
                    model.JCLB = dt.Rows[0]["JCLB"].ToString();
                    model.CLZL = dt.Rows[0]["CLZL"].ToString();
                    model.SSXQ = dt.Rows[0]["SSXQ"].ToString();
                    model.SFWDZR = dt.Rows[0]["SFWDZR"].ToString();
                    model.SFYQBF = dt.Rows[0]["SFYQBF"].ToString();
                    model.FDJSCQY = dt.Rows[0]["FDJSCQY"].ToString();
                    model.QDLTQY = dt.Rows[0]["QDLTQY"].ToString();
                    model.RYPH = dt.Rows[0]["RYPH"].ToString();
                    if (dt.Columns.Contains("ZXBZ"))
                        model.ZXBZ = dt.Rows[0]["ZXBZ"].ToString();
                    else
                        model.ZXBZ = "";

                    if (dt.Columns.Contains("CSYS"))
                        model.CSYS = dt.Rows[0]["CSYS"].ToString();
                    else
                        model.CSYS = "";
                    if (dt.Columns.Contains("CCS"))
                        model.CCS = dt.Rows[0]["CCS"].ToString();
                    else
                        model.CCS = "2";
                }
                else
                    model.CLHP = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;

        }
        #endregion
        #region 保存车辆信息
        public bool saveCarInfbyPlate(CARINF model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [车辆信息] (");
            strSql.Append("CLHP,");//=@PZLX,");1
            strSql.Append("CPYS,");//=@JCCLPH,");2
            strSql.Append("CLLX,");//=@CLXHBH,");3
            strSql.Append("CZ,");//=@CLXHBH,");3
            strSql.Append("SYXZ,");//=@JCCS,");4
            strSql.Append("PP,");//=@CCRQ,");5
            strSql.Append("XH,");//=@DJRQ,"); 6
            strSql.Append("CLSBM,");//=@FDJH,");7
            strSql.Append("FDJHM,");//=@CJH,");8
            strSql.Append("FDJXH,");//=@CZ,");9
            strSql.Append("SCQY,");//=@CZDH,");10
            strSql.Append("HDZK,");//=@CZDZ,");11
            strSql.Append("JSSZK,");//=@LCBDS,");12
            strSql.Append("ZZL,");//=@HBBZ,");13
            strSql.Append("HDZZL,");//=@SYQK,");14
            strSql.Append("ZBZL,");//=@JCBJ,");15
            strSql.Append("JZZL,");//=@JCZT,");16
            strSql.Append("ZCRQ,");//=@QRJCFF");17
            strSql.Append("SCRQ,");//=@RYLX,");18
            strSql.Append("FDJPL,");//=@GYFF,");19
            strSql.Append("RLZL,");//=@BSXLX,");20
            strSql.Append("EDGL,");//=@CLLX,");21
            strSql.Append("EDZS,");//=@ZBZL,");22
            strSql.Append("BSQXS,");//=@ZDZZL,");23
            strSql.Append("DWS,");//=@FDJPL,");24
            strSql.Append("GYFS,");//=@FDJSCS,");25
            strSql.Append("DPFS,");//=@JCZH,");26
            strSql.Append("JQFS,");//=@DCZZ,");27
            strSql.Append("QGS,");//=@FDJEDGL,");28
            strSql.Append("QDXS,");//=@FDJEDZS,");29
            strSql.Append("CHZZ,");//=@PQGSL,");30
            strSql.Append("DLSP,");//=@PFBZ,");31
            strSql.Append("SFSRL,");//=@ZZCS,");32
            strSql.Append("JHZZ,");//=@QGS,");33
            strSql.Append("OBD,");//=@QDLQY,");34
            strSql.Append("DKGYYB,");//=@QDLQY,");35

            strSql.Append("CZDZ,");//=@QDLQY,");35
            strSql.Append("JCFS,");//=@QDLQY,");35
            strSql.Append("JCLB,");//=@QDLQY,");35
            strSql.Append("CLZL,");//=@QDLQY,");35
            strSql.Append("SSXQ,");//=@QDLQY,");35
            strSql.Append("SFWDZR,");//=@QDLQY,");35
            strSql.Append("SFYQBF,");//=@QDLQY,");35
            strSql.Append("FDJSCQY,");//=@QDLQY,");35
            strSql.Append("QDLTQY,");//=@QDLQY,");35
            strSql.Append("RYPH,");//=@QDLQY,");35

            strSql.Append("LXDH)");//=@QDLQY,");36
            strSql.Append("values (@CLHP,@CPYS,@CLLX,@CZ,@SYXZ,@PP,@XH,@CLSBM,@FDJHM,@FDJXH,@SCQY,@HDZK,@JSSZK,@ZZL,@HDZZL,@ZBZL,@JZZL,@ZCRQ,@SCRQ,@FDJPL,@RLZL,@EDGL,@EDZS,@BSQXS,@DWS,@GYFS,@DPFS,@JQFS,@QGS,@QDXS,@CHZZ,@DLSP,@SFSRL,@JHZZ,@OBD,@DKGYYB,@CZDZ,@JCFS,@JCLB,@CLZL,@SSXQ,@SFWDZR,@SFYQBF,@FDJSCQY,@QDLTQY,@RYPH,@LXDH)");
            SqlParameter[] parameters = {
					new SqlParameter("@CLHP", SqlDbType.VarChar,50),
					new SqlParameter("@CPYS", SqlDbType.VarChar,50),
					new SqlParameter("@CLLX",SqlDbType.VarChar,50),
                    new SqlParameter("@CZ",SqlDbType.VarChar,100),
					new SqlParameter("@SYXZ", SqlDbType.VarChar,50),
					new SqlParameter("@PP", SqlDbType.VarChar,50),
                    new SqlParameter("@XH", SqlDbType.VarChar,50),
					new SqlParameter("@CLSBM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJHM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJXH", SqlDbType.VarChar,50),
					new SqlParameter("@SCQY", SqlDbType.VarChar,50),
					new SqlParameter("@HDZK", SqlDbType.VarChar,50),
					new SqlParameter("@JSSZK", SqlDbType.VarChar,50),
					new SqlParameter("@ZZL", SqlDbType.VarChar,50),
					new SqlParameter("@HDZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZBZL", SqlDbType.VarChar,50),
                    new SqlParameter("@JZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZCRQ", SqlDbType.DateTime),
                    new SqlParameter("@SCRQ", SqlDbType.DateTime),
                    new SqlParameter("@FDJPL", SqlDbType.VarChar,50),
					new SqlParameter("@RLZL", SqlDbType.VarChar,50),
					new SqlParameter("@EDGL", SqlDbType.VarChar,50),
					new SqlParameter("@EDZS", SqlDbType.VarChar,50),
					new SqlParameter("@BSQXS",SqlDbType.VarChar,50),
					new SqlParameter("@DWS", SqlDbType.VarChar,50),
					new SqlParameter("@GYFS", SqlDbType.VarChar,50),
                    new SqlParameter("@DPFS", SqlDbType.VarChar,50),
                    new SqlParameter("@JQFS", SqlDbType.VarChar,50),
                    new SqlParameter("@QGS", SqlDbType.VarChar,50),
                    new SqlParameter("@QDXS", SqlDbType.VarChar,50),
                    new SqlParameter("@CHZZ", SqlDbType.VarChar,50),
                    new SqlParameter("@DLSP", SqlDbType.VarChar,50),
					new SqlParameter("@SFSRL", SqlDbType.VarChar,50),
					new SqlParameter("@JHZZ",SqlDbType.VarChar,50),
					new SqlParameter("@OBD",SqlDbType.VarChar,50),
                    new SqlParameter("@DKGYYB",SqlDbType.VarChar,50),
                    new SqlParameter("@CZDZ",SqlDbType.VarChar,100),
                    new SqlParameter("@JCFS",SqlDbType.VarChar,50),
                    new SqlParameter("@JCLB",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZL",SqlDbType.VarChar,50),
                    new SqlParameter("@SSXQ",SqlDbType.VarChar,50),
                    new SqlParameter("@SFWDZR",SqlDbType.VarChar,50),
                    new SqlParameter("@SFYQBF",SqlDbType.VarChar,50),
                    new SqlParameter("@FDJSCQY",SqlDbType.VarChar,100),
                    new SqlParameter("@QDLTQY",SqlDbType.VarChar,50),
                    new SqlParameter("@RYPH",SqlDbType.VarChar,50),
                    new SqlParameter("@LXDH",SqlDbType.VarChar,50)};
            parameters[i++].Value = model.CLHP;
            parameters[i++].Value = model.CPYS;
            parameters[i++].Value = model.CLLX;
            parameters[i++].Value = model.CZ;
            parameters[i++].Value = model.SYXZ;
            parameters[i++].Value = model.PP;
            parameters[i++].Value = model.XH;
            parameters[i++].Value = model.CLSBM;
            parameters[i++].Value = model.FDJHM;
            parameters[i++].Value = model.FDJXH;
            parameters[i++].Value = model.SCQY;
            parameters[i++].Value = model.HDZK;
            parameters[i++].Value = model.JSSZK;
            parameters[i++].Value = model.ZZL;
            parameters[i++].Value = model.HDZZL;
            parameters[i++].Value = model.ZBZL;
            parameters[i++].Value = model.JZZL;
            parameters[i++].Value = model.ZCRQ;
            parameters[i++].Value = model.SCRQ;
            parameters[i++].Value = model.FDJPL;
            parameters[i++].Value = model.RLZL;
            parameters[i++].Value = model.EDGL;
            parameters[i++].Value = model.EDZS;
            parameters[i++].Value = model.BSQXS;
            parameters[i++].Value = model.DWS;
            parameters[i++].Value = model.GYFS;
            parameters[i++].Value = model.DPFS;
            parameters[i++].Value = model.JQFS;
            parameters[i++].Value = model.QGS;
            parameters[i++].Value = model.QDXS;
            parameters[i++].Value = model.CHZZ;
            parameters[i++].Value = model.DLSP;
            parameters[i++].Value = model.SFSRL;
            parameters[i++].Value = model.JHZZ;
            parameters[i++].Value = model.OBD;
            parameters[i++].Value = model.DKGYYB;
            parameters[i++].Value = model.CZDZ;
            parameters[i++].Value = model.JCFS;
            parameters[i++].Value = model.JCLB;
            parameters[i++].Value = model.CLZL;
            parameters[i++].Value = model.SSXQ;
            parameters[i++].Value = model.SFWDZR;
            parameters[i++].Value = model.SFYQBF;
            parameters[i++].Value = model.FDJSCQY;
            parameters[i++].Value = model.QDLTQY;
            parameters[i++].Value = model.RYPH;
            parameters[i++].Value = model.LXDH;
            try
            {
                if (checkCarInfIsAlive(model.CLHP))
                {
                    if (Update(model))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 更新车辆信息
        public bool Update(CARINF model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [车辆信息] set ");
            //strSql.Append("CLHP,");//=@PZLX,");
            strSql.Append("CPYS=@CPYS,");//=@JCCLPH,");2
            strSql.Append("CLLX=@CLLX,");//=@CLXHBH,");3
            strSql.Append("CZ=@CZ,");//=@CLXHBH,");3
            strSql.Append("SYXZ=@SYXZ,");//=@JCCS,");4
            strSql.Append("PP=@PP,");//=@CCRQ,");5
            strSql.Append("XH=@XH,");//=@DJRQ,"); 6
            strSql.Append("CLSBM=@CLSBM,");//=@FDJH,");7
            strSql.Append("FDJHM=@FDJHM,");//=@CJH,");8
            strSql.Append("FDJXH=@FDJXH,");//=@CZ,");9
            strSql.Append("SCQY=@SCQY,");//=@CZDH,");10
            strSql.Append("HDZK=@HDZK,");//=@CZDZ,");11
            strSql.Append("JSSZK=@JSSZK,");//=@LCBDS,");12
            strSql.Append("ZZL=@ZZL,");//=@HBBZ,");13
            strSql.Append("HDZZL=@HDZZL,");//=@SYQK,");14
            strSql.Append("ZBZL=@ZBZL,");//=@JCBJ,");15
            strSql.Append("JZZL=@JZZL,");//=@JCZT,");16
            strSql.Append("ZCRQ=@ZCRQ,");//=@QRJCFF");17
            strSql.Append("SCRQ=@SCRQ,");//=@RYLX,");18
            strSql.Append("FDJPL=@FDJPL,");//=@GYFF,");19
            strSql.Append("RLZL=@RLZL,");//=@BSXLX,");20
            strSql.Append("EDGL=@EDGL,");//=@CLLX,");21
            strSql.Append("EDZS=@EDZS,");//=@ZBZL,");22
            strSql.Append("BSQXS=@BSQXS,");//=@ZDZZL,");23
            strSql.Append("DWS=@DWS,");//=@FDJPL,");24
            strSql.Append("GYFS=@GYFS,");//=@FDJSCS,");25
            strSql.Append("DPFS=@DPFS,");//=@JCZH,");26
            strSql.Append("JQFS=@JQFS,");//=@DCZZ,");27
            strSql.Append("QGS=@QGS,");//=@FDJEDGL,");28
            strSql.Append("QDXS=@QDXS,");//=@FDJEDZS,");29
            strSql.Append("CHZZ=@CHZZ,");//=@PQGSL,");30
            strSql.Append("DLSP=@DLSP,");//=@PFBZ,");31
            strSql.Append("SFSRL=@SFSRL,");//=@ZZCS,");32
            strSql.Append("JHZZ=@JHZZ,");//=@QGS,");33
            strSql.Append("OBD=@OBD,");//=@QDLQY,");34
            strSql.Append("DKGYYB=@DKGYYB,");//=@QDLQY,");35

            strSql.Append("CZDZ=@CZDZ,");//=@QDLQY,");35
            strSql.Append("JCFS=@JCFS,");//=@QDLQY,");35
            strSql.Append("JCLB=@JCLB,");//=@QDLQY,");35
            strSql.Append("CLZL=@CLZL,");//=@QDLQY,");35
            strSql.Append("SSXQ=@SSXQ,");//=@QDLQY,");35
            strSql.Append("SFWDZR=@SFWDZR,");//=@QDLQY,");35
            strSql.Append("SFYQBF=@SFYQBF,");//=@QDLQY,");35
            strSql.Append("FDJSCQY=@FDJSCQY,");//=@QDLQY,");35
            strSql.Append("QDLTQY=@QDLTQY,");//=@QDLQY,");35
            strSql.Append("RYPH=@RYPH,");//=@QDLQY,");35

            strSql.Append("LXDH=@LXDH");//=@QDLQY,");36
            strSql.Append(" where CLHP='" + model.CLHP + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@CPYS", SqlDbType.VarChar,50),
					new SqlParameter("@CLLX",SqlDbType.VarChar,50),
                    new SqlParameter("@CZ",SqlDbType.VarChar,100),
					new SqlParameter("@SYXZ", SqlDbType.VarChar,50),
					new SqlParameter("@PP", SqlDbType.VarChar,50),
                    new SqlParameter("@XH", SqlDbType.VarChar,50),
					new SqlParameter("@CLSBM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJHM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJXH", SqlDbType.VarChar,50),
					new SqlParameter("@SCQY", SqlDbType.VarChar,50),
					new SqlParameter("@HDZK", SqlDbType.VarChar,50),
					new SqlParameter("@JSSZK", SqlDbType.VarChar,50),
					new SqlParameter("@ZZL", SqlDbType.VarChar,50),
					new SqlParameter("@HDZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZBZL", SqlDbType.VarChar,50),
                    new SqlParameter("@JZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZCRQ", SqlDbType.DateTime),
                    new SqlParameter("@SCRQ", SqlDbType.DateTime),
                    new SqlParameter("@FDJPL", SqlDbType.VarChar,50),
					new SqlParameter("@RLZL", SqlDbType.VarChar,50),
					new SqlParameter("@EDGL", SqlDbType.VarChar,50),
					new SqlParameter("@EDZS", SqlDbType.VarChar,50),
					new SqlParameter("@BSQXS",SqlDbType.VarChar,50),
					new SqlParameter("@DWS", SqlDbType.VarChar,50),
					new SqlParameter("@GYFS", SqlDbType.VarChar,50),
                    new SqlParameter("@DPFS", SqlDbType.VarChar,50),
                    new SqlParameter("@JQFS", SqlDbType.VarChar,50),
                    new SqlParameter("@QGS", SqlDbType.VarChar,50),
                    new SqlParameter("@QDXS", SqlDbType.VarChar,50),
                    new SqlParameter("@CHZZ", SqlDbType.VarChar,50),
                    new SqlParameter("@DLSP", SqlDbType.VarChar,50),
					new SqlParameter("@SFSRL", SqlDbType.VarChar,50),
					new SqlParameter("@JHZZ",SqlDbType.VarChar,50),
					new SqlParameter("@OBD",SqlDbType.VarChar,50),
                    new SqlParameter("@DKGYYB",SqlDbType.VarChar,50),
                    new SqlParameter("@CZDZ",SqlDbType.VarChar,100),
                    new SqlParameter("@JCFS",SqlDbType.VarChar,50),
                    new SqlParameter("@JCLB",SqlDbType.VarChar,50),
                    new SqlParameter("@CLZL",SqlDbType.VarChar,50),
                    new SqlParameter("@SSXQ",SqlDbType.VarChar,50),
                    new SqlParameter("@SFWDZR",SqlDbType.VarChar,50),
                    new SqlParameter("@SFYQBF",SqlDbType.VarChar,50),
                    new SqlParameter("@FDJSCQY",SqlDbType.VarChar,100),
                    new SqlParameter("@QDLTQY",SqlDbType.VarChar,50),
                    new SqlParameter("@RYPH",SqlDbType.VarChar,50),
                    new SqlParameter("@LXDH",SqlDbType.VarChar,50)};
            parameters[i++].Value = model.CPYS;
            parameters[i++].Value = model.CLLX;
            parameters[i++].Value = model.CZ;
            parameters[i++].Value = model.SYXZ;
            parameters[i++].Value = model.PP;
            parameters[i++].Value = model.XH;
            parameters[i++].Value = model.CLSBM;
            parameters[i++].Value = model.FDJHM;
            parameters[i++].Value = model.FDJXH;
            parameters[i++].Value = model.SCQY;
            parameters[i++].Value = model.HDZK;
            parameters[i++].Value = model.JSSZK;
            parameters[i++].Value = model.ZZL;
            parameters[i++].Value = model.HDZZL;
            parameters[i++].Value = model.ZBZL;
            parameters[i++].Value = model.JZZL;
            parameters[i++].Value = model.ZCRQ;
            parameters[i++].Value = model.SCRQ;
            parameters[i++].Value = model.FDJPL;
            parameters[i++].Value = model.RLZL;
            parameters[i++].Value = model.EDGL;
            parameters[i++].Value = model.EDZS;
            parameters[i++].Value = model.BSQXS;
            parameters[i++].Value = model.DWS;
            parameters[i++].Value = model.GYFS;
            parameters[i++].Value = model.DPFS;
            parameters[i++].Value = model.JQFS;
            parameters[i++].Value = model.QGS;
            parameters[i++].Value = model.QDXS;
            parameters[i++].Value = model.CHZZ;
            parameters[i++].Value = model.DLSP;
            parameters[i++].Value = model.SFSRL;
            parameters[i++].Value = model.JHZZ;
            parameters[i++].Value = model.OBD;
            parameters[i++].Value = model.DKGYYB;
            parameters[i++].Value = model.CZDZ;
            parameters[i++].Value = model.JCFS;
            parameters[i++].Value = model.JCLB;
            parameters[i++].Value = model.CLZL;
            parameters[i++].Value = model.SSXQ;
            parameters[i++].Value = model.SFWDZR;
            parameters[i++].Value = model.SFYQBF;
            parameters[i++].Value = model.FDJSCQY;
            parameters[i++].Value = model.QDLTQY;
            parameters[i++].Value = model.RYPH;
            parameters[i++].Value = model.LXDH;
            try
            {
                int rows = DBHelperSQL.Execute(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 保存车辆被检信息
        public bool saveCarbj(CARDETECTED model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [已检车辆信息] (");
            strSql.Append("CLID,");//=@PZLX,");1
            strSql.Append("STATIONID,");//=@PZLX,");1
            strSql.Append("LINEID,");//=@PZLX,");1
            strSql.Append("ZXBZ,");//=@PZLX,");1
            strSql.Append("DLSJ,");//=@PZLX,");1
            strSql.Append("JCSJ,");//=@PZLX,");1
            strSql.Append("JCFF,");//=@PZLX,");1
            strSql.Append("XSLC,");//=@PZLX,");1
            strSql.Append("JCJG,");//=@PZLX,");1
            strSql.Append("JCCS,");//=@PZLX,");1
            strSql.Append("LSH,");//=@PZLX,");1
            strSql.Append("CLHP,");//=@PZLX,");1
            strSql.Append("CPYS,");//=@JCCLPH,");2
            strSql.Append("CLLX,");//=@CLXHBH,");3
            strSql.Append("CZ,");//=@CLXHBH,");3
            strSql.Append("SYXZ,");//=@JCCS,");4
            strSql.Append("PP,");//=@CCRQ,");5
            strSql.Append("XH,");//=@DJRQ,"); 6
            strSql.Append("CLSBM,");//=@FDJH,");7
            strSql.Append("FDJHM,");//=@CJH,");8
            strSql.Append("FDJXH,");//=@CZ,");9
            strSql.Append("SCQY,");//=@CZDH,");10
            strSql.Append("HDZK,");//=@CZDZ,");11
            strSql.Append("JSSZK,");//=@LCBDS,");12
            strSql.Append("ZZL,");//=@HBBZ,");13
            strSql.Append("HDZZL,");//=@SYQK,");14
            strSql.Append("ZBZL,");//=@JCBJ,");15
            strSql.Append("JZZL,");//=@JCZT,");16
            strSql.Append("ZCRQ,");//=@QRJCFF");17
            strSql.Append("SCRQ,");//=@RYLX,");18
            strSql.Append("FDJPL,");//=@GYFF,");19
            strSql.Append("RLZL,");//=@BSXLX,");20
            strSql.Append("EDGL,");//=@CLLX,");21
            strSql.Append("EDZS,");//=@ZBZL,");22
            strSql.Append("BSQXS,");//=@ZDZZL,");23
            strSql.Append("DWS,");//=@FDJPL,");24
            strSql.Append("GYFS,");//=@FDJSCS,");25
            strSql.Append("DPFS,");//=@JCZH,");26
            strSql.Append("JQFS,");//=@DCZZ,");27
            strSql.Append("QGS,");//=@FDJEDGL,");28
            strSql.Append("QDXS,");//=@FDJEDZS,");29
            strSql.Append("CHZZ,");//=@PQGSL,");30
            strSql.Append("DLSP,");//=@PFBZ,");31
            strSql.Append("SFSRL,");//=@ZZCS,");32
            strSql.Append("JHZZ,");//=@QGS,");33
            strSql.Append("OBD,");//=@QDLQY,");34
            strSql.Append("DKGYYB,");//=@QDLQY,");35
            strSql.Append("LXDH,");//=@QDLQY,");36
            strSql.Append("CZY,");//=@PZLX,");1
            strSql.Append("JSY,");//=@PZLX,");1
            strSql.Append("DLY,");//=@PZLX,");1
            strSql.Append("JCFY,");//=@PZLX,");1
            strSql.Append("SFJF,");//=@PZLX,");1
            strSql.Append("TEST,");//=@PZLX,");1
            strSql.Append("QDLTQY,");//=@PZLX,");1
            strSql.Append("RYPH,");//=@PZLX,");1
            strSql.Append("HPZL,");//=@PZLX,");1
            strSql.Append("JCGCSJ,");//=@PZLX,");1
            strSql.Append("WJY,");//=@PZLX,");1
            strSql.Append("BGFFYY,");//=@PZLX,");1
            strSql.Append("CCS,");//=@PZLX,");1
            strSql.Append("JYLSH,");//=@PZLX,");1
            strSql.Append("JCZMC)");//=@PZLX,");1
            strSql.Append("values (@CLID,@STATIONID,@LINEID,@ZXBZ,@DLSJ,@JCSJ,@JCFF,@XSLC,@JCJG,@JCCS,@LSH,@CLHP,@CPYS,@CLLX,@CZ,@SYXZ,@PP,@XH,@CLSBM,@FDJHM,@FDJXH,@SCQY,@HDZK,@JSSZK,@ZZL,@HDZZL,@ZBZL,@JZZL,@ZCRQ,@SCRQ,@FDJPL,@RLZL,@EDGL,@EDZS,@BSQXS,@DWS,@GYFS,@DPFS,@JQFS,@QGS,@QDXS,@CHZZ,@DLSP,@SFSRL,@JHZZ,@OBD,@DKGYYB,@LXDH,@CZY,@JSY,@DLY,@JCFY,@SFJF,@TEST,@QDLTQY,@RYPH,@HPZL,@JCGCSJ,@WJY,@BGFFYY,@CCS,@JYLSH,@JCZMC)");
            SqlParameter[] parameters = {
                                            new SqlParameter("@CLID", SqlDbType.VarChar,50),
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZXBZ", SqlDbType.VarChar,50),
                                            new SqlParameter("@DLSJ", SqlDbType.DateTime),
                                            new SqlParameter("@JCSJ", SqlDbType.DateTime),
                                            new SqlParameter("@JCFF", SqlDbType.VarChar,50),
                                            new SqlParameter("@XSLC", SqlDbType.VarChar,50),
                                            new SqlParameter("@JCJG", SqlDbType.VarChar,50),
                                            new SqlParameter("@JCCS", SqlDbType.VarChar,50),
                                            new SqlParameter("@LSH", SqlDbType.VarChar,50),
					new SqlParameter("@CLHP", SqlDbType.VarChar,50),
					new SqlParameter("@CPYS", SqlDbType.VarChar,50),
					new SqlParameter("@CLLX",SqlDbType.VarChar,50),
                    new SqlParameter("@CZ",SqlDbType.VarChar,100),
					new SqlParameter("@SYXZ", SqlDbType.VarChar,50),
					new SqlParameter("@PP", SqlDbType.VarChar,50),
                    new SqlParameter("@XH", SqlDbType.VarChar,50),
					new SqlParameter("@CLSBM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJHM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJXH", SqlDbType.VarChar,50),
					new SqlParameter("@SCQY", SqlDbType.VarChar,50),
					new SqlParameter("@HDZK", SqlDbType.VarChar,50),
					new SqlParameter("@JSSZK", SqlDbType.VarChar,50),
					new SqlParameter("@ZZL", SqlDbType.VarChar,50),
					new SqlParameter("@HDZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZBZL", SqlDbType.VarChar,50),
                    new SqlParameter("@JZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZCRQ", SqlDbType.DateTime),
                    new SqlParameter("@SCRQ", SqlDbType.DateTime),
                    new SqlParameter("@FDJPL", SqlDbType.VarChar,50),
					new SqlParameter("@RLZL", SqlDbType.VarChar,50),
					new SqlParameter("@EDGL", SqlDbType.VarChar,50),
					new SqlParameter("@EDZS", SqlDbType.VarChar,50),
					new SqlParameter("@BSQXS",SqlDbType.VarChar,50),
					new SqlParameter("@DWS", SqlDbType.VarChar,50),
					new SqlParameter("@GYFS", SqlDbType.VarChar,50),
                    new SqlParameter("@DPFS", SqlDbType.VarChar,50),
                    new SqlParameter("@JQFS", SqlDbType.VarChar,50),
                    new SqlParameter("@QGS", SqlDbType.VarChar,50),
                    new SqlParameter("@QDXS", SqlDbType.VarChar,50),
                    new SqlParameter("@CHZZ", SqlDbType.VarChar,50),
                    new SqlParameter("@DLSP", SqlDbType.VarChar,50),
					new SqlParameter("@SFSRL", SqlDbType.VarChar,50),
					new SqlParameter("@JHZZ",SqlDbType.VarChar,50),
					new SqlParameter("@OBD",SqlDbType.VarChar,50),
                    new SqlParameter("@DKGYYB",SqlDbType.VarChar,50),
                    new SqlParameter("@LXDH",SqlDbType.VarChar,50),
                                        new SqlParameter("@CZY",SqlDbType.VarChar,50),
                                        new SqlParameter("@JSY",SqlDbType.VarChar,50),
                                        new SqlParameter("@DLY",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCFY",SqlDbType.VarChar,50),
                                        new SqlParameter("@SFJF",SqlDbType.VarChar,50),
                                        new SqlParameter("@TEST",SqlDbType.VarChar,50),
                                        new SqlParameter("@QDLTQY",SqlDbType.VarChar,50),
                                        new SqlParameter("@RYPH",SqlDbType.VarChar,50),
                                        new SqlParameter("@HPZL",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCGCSJ",SqlDbType.VarChar,50),
                                        new SqlParameter("@WJY",SqlDbType.VarChar,50),
                                        new SqlParameter("@BGFFYY",SqlDbType.VarChar,50),
                                        new SqlParameter("@CCS",SqlDbType.VarChar,50),
                                        new SqlParameter("@JYLSH",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCZMC",SqlDbType.VarChar,100)};
            parameters[i++].Value = model.CLID;
            parameters[i++].Value = model.STATIONID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.ZXBZ;
            parameters[i++].Value = model.DLSJ;
            parameters[i++].Value = model.JCSJ;
            parameters[i++].Value = model.JCFF;
            parameters[i++].Value = model.XSLC;
            parameters[i++].Value = model.JCJG;
            parameters[i++].Value = model.JCCS;
            parameters[i++].Value = model.LSH;
            parameters[i++].Value = model.CLHP;
            parameters[i++].Value = model.CPYS;
            parameters[i++].Value = model.CLLX;
            parameters[i++].Value = model.CZ;
            parameters[i++].Value = model.SYXZ;
            parameters[i++].Value = model.PP;
            parameters[i++].Value = model.XH;
            parameters[i++].Value = model.CLSBM;
            parameters[i++].Value = model.FDJHM;
            parameters[i++].Value = model.FDJXH;
            parameters[i++].Value = model.SCQY;
            parameters[i++].Value = model.HDZK;
            parameters[i++].Value = model.JSSZK;
            parameters[i++].Value = model.ZZL;
            parameters[i++].Value = model.HDZZL;
            parameters[i++].Value = model.ZBZL;
            parameters[i++].Value = model.JZZL;
            parameters[i++].Value = model.ZCRQ;
            parameters[i++].Value = model.SCRQ;
            parameters[i++].Value = model.FDJPL;
            parameters[i++].Value = model.RLZL;
            parameters[i++].Value = model.EDGL;
            parameters[i++].Value = model.EDZS;
            parameters[i++].Value = model.BSQXS;
            parameters[i++].Value = model.DWS;
            parameters[i++].Value = model.GYFS;
            parameters[i++].Value = model.DPFS;
            parameters[i++].Value = model.JQFS;
            parameters[i++].Value = model.QGS;
            parameters[i++].Value = model.QDXS;
            parameters[i++].Value = model.CHZZ;
            parameters[i++].Value = model.DLSP;
            parameters[i++].Value = model.SFSRL;
            parameters[i++].Value = model.JHZZ;
            parameters[i++].Value = model.OBD;
            parameters[i++].Value = model.DKGYYB;
            parameters[i++].Value = model.LXDH;
            parameters[i++].Value = model.CZY;
            parameters[i++].Value = model.JSY;
            parameters[i++].Value = model.DLY;
            parameters[i++].Value = model.JCFY;
            parameters[i++].Value = model.SFJF;
            parameters[i++].Value = model.TEST;
            parameters[i++].Value = model.QDLTQY;
            parameters[i++].Value = model.RYPH;
            parameters[i++].Value = model.HPZL;
            parameters[i++].Value = model.jcgcsj;
            parameters[i++].Value = model.wjy;
            parameters[i++].Value = model.BGFFYY;
            parameters[i++].Value = model.CCS;
            parameters[i++].Value = model.JYLSH;
            parameters[i++].Value = model.JCZMC;
            try
            {
                if (checkIsAlive(model.CLID, "已检车辆信息"))
                {
                    deleteCarBj(model.CLID);
                }
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
        public bool deleteCarBj(string clid)
        {
            string sql = "delete from [已检车辆信息] where CLID='" + clid + "'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        #region 更新车辆被检信息
        public bool UpdateCarBj(CARDETECTED model)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [已检车辆信息] set ");
            strSql.Append("DLSJ=@DLSJ");
            strSql.Append("STATIONID=@STATIONID,");
            strSql.Append("LINEID=@LINEID,");
            strSql.Append("ZXBZ=@ZXBZ,");
            strSql.Append("JCSJ=@JCSJ,");
            strSql.Append("JCFF=@JCFF,");
            strSql.Append("XSLC=@XSLC,");
            strSql.Append("JCJG=@JCJG,");
            strSql.Append("JCCS=@JCCS,");
            strSql.Append("LSH=@LSH,");
            strSql.Append("CLHP=@CLHP,");//=@PZLX,");
            strSql.Append("CPYS=@CPYS,");//=@JCCLPH,");2
            strSql.Append("CLLX=@CLLX,");//=@CLXHBH,");3
            strSql.Append("CZ=@CZ,");//=@CLXHBH,");3
            strSql.Append("SYXZ=@SYXZ,");//=@JCCS,");4
            strSql.Append("PP=@PP,");//=@CCRQ,");5
            strSql.Append("XH=@XH,");//=@DJRQ,"); 6
            strSql.Append("CLSBM=@CLSBM,");//=@FDJH,");7
            strSql.Append("FDJHM=@FDJHM,");//=@CJH,");8
            strSql.Append("FDJXH=@FDJXH,");//=@CZ,");9
            strSql.Append("SCQY=@SCQY,");//=@CZDH,");10
            strSql.Append("HDZK=@HDZK,");//=@CZDZ,");11
            strSql.Append("JSSZK=@JSSZK,");//=@LCBDS,");12
            strSql.Append("ZZL=@ZZL,");//=@HBBZ,");13
            strSql.Append("HDZZL=@HDZZL,");//=@SYQK,");14
            strSql.Append("ZBZL=@ZBZL,");//=@JCBJ,");15
            strSql.Append("JZZL=@JZZL,");//=@JCZT,");16
            strSql.Append("ZCRQ=@ZCRQ,");//=@QRJCFF");17
            strSql.Append("SCRQ=@SCRQ,");//=@RYLX,");18
            strSql.Append("FDJPL=@FDJPL,");//=@GYFF,");19
            strSql.Append("RLZL=@RLZL,");//=@BSXLX,");20
            strSql.Append("EDGL=@EDGL,");//=@CLLX,");21
            strSql.Append("EDZS=@EDZS,");//=@ZBZL,");22
            strSql.Append("BSQXS=@BSQXS,");//=@ZDZZL,");23
            strSql.Append("DWS=@DWS,");//=@FDJPL,");24
            strSql.Append("GYFS=@GYFS,");//=@FDJSCS,");25
            strSql.Append("DPFS=@DPFS,");//=@JCZH,");26
            strSql.Append("JQFS=@JQFS,");//=@DCZZ,");27
            strSql.Append("QGS=@QGS,");//=@FDJEDGL,");28
            strSql.Append("QDXS=@QDXS,");//=@FDJEDZS,");29
            strSql.Append("CHZZ=@CHZZ,");//=@PQGSL,");30
            strSql.Append("DLSP=@DLSP,");//=@PFBZ,");31
            strSql.Append("SFSRL=@SFSRL,");//=@ZZCS,");32
            strSql.Append("JHZZ=@JHZZ,");//=@QGS,");33
            strSql.Append("OBD=@OBD,");//=@QDLQY,");34
            strSql.Append("DKGYYB=@DKGYYB,");//=@QDLQY,");35
            strSql.Append("LXDH=@LXDH,");//=@QDLQY,");36
            strSql.Append("CZY=@CZY,");//=@QDLQY,");36
            strSql.Append("JSY=@JSY,");//=@QDLQY,");36
            strSql.Append("DLY=@DLY,");//=@QDLQY,");36
            strSql.Append("JCFY=@JCFY,");//=@QDLQY,");36
            strSql.Append("SFJF=@SFJF,");//=@QDLQY,");36
            strSql.Append("TEST=@TEST,");//=@QDLQY,");36
            strSql.Append("QDLTQY=@QDLTQY,");//=@QDLQY,");36
            strSql.Append("RYPH=@RYPH,");//=@QDLQY,");36
            strSql.Append("HPZL=@HPZL,");//=@QDLQY,");36
            strSql.Append("JCGCSJ=@JCGCSJ,");//=@QDLQY,");36
            strSql.Append("WJY=@WJY,");//=@QDLQY,");36
            strSql.Append("CCS=@CCS,");//=@QDLQY,");36
            strSql.Append("JYLSH=@JYLSH,");//=@QDLQY,");36
            strSql.Append("JCZMC=@JCZMC");//=@QDLQY,");36
            strSql.Append(" where CLID='" + model.CLID + "'");
            SqlParameter[] parameters = {
                                            new SqlParameter("@DLSJ", SqlDbType.DateTime),
                                            new SqlParameter("@STATIONID", SqlDbType.VarChar,50),
                                            new SqlParameter("@LINEID", SqlDbType.VarChar,50),
                                            new SqlParameter("@ZXBZ", SqlDbType.VarChar,50),
                                            new SqlParameter("@JCSJ", SqlDbType.DateTime),
                                            new SqlParameter("@JCFF", SqlDbType.VarChar,50),
                                            new SqlParameter("@XSLC", SqlDbType.VarChar,50),
                                            new SqlParameter("@JCJG", SqlDbType.VarChar,50),
                                            new SqlParameter("@JCCS", SqlDbType.VarChar,50),
                                            new SqlParameter("@LSH", SqlDbType.VarChar,50),
					new SqlParameter("@CLHP", SqlDbType.VarChar,50),
					new SqlParameter("@CPYS", SqlDbType.VarChar,50),
					new SqlParameter("@CLLX",SqlDbType.VarChar,50),
                    new SqlParameter("@CZ",SqlDbType.VarChar,100),
					new SqlParameter("@SYXZ", SqlDbType.VarChar,50),
					new SqlParameter("@PP", SqlDbType.VarChar,50),
                    new SqlParameter("@XH", SqlDbType.VarChar,50),
					new SqlParameter("@CLSBM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJHM", SqlDbType.VarChar,50),
					new SqlParameter("@FDJXH", SqlDbType.VarChar,50),
					new SqlParameter("@SCQY", SqlDbType.VarChar,50),
					new SqlParameter("@HDZK", SqlDbType.VarChar,50),
					new SqlParameter("@JSSZK", SqlDbType.VarChar,50),
					new SqlParameter("@ZZL", SqlDbType.VarChar,50),
					new SqlParameter("@HDZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZBZL", SqlDbType.VarChar,50),
                    new SqlParameter("@JZZL", SqlDbType.VarChar,50),
                    new SqlParameter("@ZCRQ", SqlDbType.DateTime),
                    new SqlParameter("@SCRQ", SqlDbType.DateTime),
                    new SqlParameter("@FDJPL", SqlDbType.VarChar,50),
					new SqlParameter("@RLZL", SqlDbType.VarChar,50),
					new SqlParameter("@EDGL", SqlDbType.VarChar,50),
					new SqlParameter("@EDZS", SqlDbType.VarChar,50),
					new SqlParameter("@BSQXS",SqlDbType.VarChar,50),
					new SqlParameter("@DWS", SqlDbType.VarChar,50),
					new SqlParameter("@GYFS", SqlDbType.VarChar,50),
                    new SqlParameter("@DPFS", SqlDbType.VarChar,50),
                    new SqlParameter("@JQFS", SqlDbType.VarChar,50),
                    new SqlParameter("@QGS", SqlDbType.VarChar,50),
                    new SqlParameter("@QDXS", SqlDbType.VarChar,50),
                    new SqlParameter("@CHZZ", SqlDbType.VarChar,50),
                    new SqlParameter("@DLSP", SqlDbType.VarChar,50),
					new SqlParameter("@SFSRL", SqlDbType.VarChar,50),
					new SqlParameter("@JHZZ",SqlDbType.VarChar,50),
					new SqlParameter("@OBD",SqlDbType.VarChar,50),
                    new SqlParameter("@DKGYYB",SqlDbType.VarChar,50),
                    new SqlParameter("@LXDH",SqlDbType.VarChar,50),
                                        new SqlParameter("@CZY",SqlDbType.VarChar,50),
                                        new SqlParameter("@JSY",SqlDbType.VarChar,50),
                                        new SqlParameter("@DLY",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCFY",SqlDbType.VarChar,50),
                                        new SqlParameter("@SFJF",SqlDbType.VarChar,50),
                                        new SqlParameter("@TEST",SqlDbType.VarChar,50),
                                        new SqlParameter("@QDLTQY",SqlDbType.VarChar,50),
                                        new SqlParameter("@RYPH",SqlDbType.VarChar,50),
                                        new SqlParameter("@HPZL",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCGCSJ",SqlDbType.VarChar,50),
                                        new SqlParameter("@WJY",SqlDbType.VarChar,50),
                                        new SqlParameter("@CCS",SqlDbType.VarChar,50),
                                        new SqlParameter("@JYLSH",SqlDbType.VarChar,50),
                                        new SqlParameter("@JCZMC",SqlDbType.VarChar,50)};
            parameters[i++].Value = model.DLSJ;
            parameters[i++].Value = model.STATIONID;
            parameters[i++].Value = model.LINEID;
            parameters[i++].Value = model.ZXBZ;
            parameters[i++].Value = model.JCSJ;
            parameters[i++].Value = model.JCFF;
            parameters[i++].Value = model.XSLC;
            parameters[i++].Value = model.JCJG;
            parameters[i++].Value = model.JCCS;
            parameters[i++].Value = model.LSH;
            parameters[i++].Value = model.CLHP;
            parameters[i++].Value = model.CPYS;
            parameters[i++].Value = model.CLLX;
            parameters[i++].Value = model.CZ;
            parameters[i++].Value = model.SYXZ;
            parameters[i++].Value = model.PP;
            parameters[i++].Value = model.XH;
            parameters[i++].Value = model.CLSBM;
            parameters[i++].Value = model.FDJHM;
            parameters[i++].Value = model.FDJXH;
            parameters[i++].Value = model.SCQY;
            parameters[i++].Value = model.HDZK;
            parameters[i++].Value = model.JSSZK;
            parameters[i++].Value = model.ZZL;
            parameters[i++].Value = model.HDZZL;
            parameters[i++].Value = model.ZBZL;
            parameters[i++].Value = model.JZZL;
            parameters[i++].Value = model.ZCRQ;
            parameters[i++].Value = model.SCRQ;
            parameters[i++].Value = model.FDJPL;
            parameters[i++].Value = model.RLZL;
            parameters[i++].Value = model.EDGL;
            parameters[i++].Value = model.EDZS;
            parameters[i++].Value = model.BSQXS;
            parameters[i++].Value = model.DWS;
            parameters[i++].Value = model.GYFS;
            parameters[i++].Value = model.DPFS;
            parameters[i++].Value = model.JQFS;
            parameters[i++].Value = model.QGS;
            parameters[i++].Value = model.QDXS;
            parameters[i++].Value = model.CHZZ;
            parameters[i++].Value = model.DLSP;
            parameters[i++].Value = model.SFSRL;
            parameters[i++].Value = model.JHZZ;
            parameters[i++].Value = model.OBD;
            parameters[i++].Value = model.DKGYYB;
            parameters[i++].Value = model.LXDH;
            parameters[i++].Value = model.CZY;
            parameters[i++].Value = model.JSY;
            parameters[i++].Value = model.DLY;
            parameters[i++].Value = model.JCFY;
            parameters[i++].Value = model.SFJF;
            parameters[i++].Value = model.TEST;
            parameters[i++].Value = model.QDLTQY;
            parameters[i++].Value = model.RYPH;
            parameters[i++].Value = model.HPZL;
            parameters[i++].Value = model.jcgcsj;
            parameters[i++].Value = model.wjy;
            parameters[i++].Value = model.CCS;
            parameters[i++].Value = model.JYLSH;
            parameters[i++].Value = model.JCZMC;
            try
            {
                int rows = DBHelperSQL.Execute(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 获取所有被检车辆信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllCarDetected()
        {
            string sql = "select * from [已检车辆信息] order by JCSJ desc";
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        
        #region 获取某一辆车的所有检测信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getCarDetectedByPlate(string lx,string plate)
        {
            string sql="";
            switch(lx)
            {
                case "当日":
                    sql = "select * from [已检车辆信息] where CLHP=" + "'" + plate + "'" + " and DATEPART(dd, JCSJ)=DATEPART(dd, GETDATE()) and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE()) order by JCSJ desc";
                    break;
                case "所有":
                    sql = "select * from [已检车辆信息] where CLHP="+"'"+plate+"'"+" order by JCSJ desc";
                    break;
            }
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 获取该检测站的已检车辆
        /// <summary>
        /// 获取所有检测线的信息
        /// stationid:站号，lineid:线号，0表示所有线，startTime:起始时间,endtime:终止时间,plate:车牌,jcff:0-不限,result:检测结果：-1—不合格，1-合格，0-不限,cllx:1-轻型车，2-中型车，3-重型车，0，不限
        /// </summary>
        public DataTable getCarDetectedByPlate(DateTime starttime, DateTime endtime, string result, string plate, string cz)
        {
            string sql = "";
            sql = "select * from [已检车辆信息] where";//+ "' and CLHP LIKE '" + plate + "'";
            sql += " JCSJ>='" + starttime.ToShortDateString() + " 00:00:00" + "' and JCSJ<='" + endtime.ToShortDateString() + " 23:59:59" + "'";
            switch (result)
            {
                case "0": break;
                case "-1": sql += " and PDJG='不合格'"; break;
                case "1": sql += " and PDJG='合格'"; break;
                default: break;
            }
            if (plate != "0")
                sql += " and CLHP like" + "'%" + plate + "%'";
            if (cz != "0")
            {
                sql += " and CZ like '%" + cz + "%'";
            }
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                return dt;
                throw;
            }
        }
        #endregion
        #region 获取所有已检车辆信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllCarDetected(string lx)
        {
            string sql="";
            switch(lx)
            {
                case "当日":
                    sql = "select * from [已检车辆信息] where DATEPART(dd, JCSJ)=DATEPART(dd, GETDATE()) and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    //sql = "select * from [已检车辆信息] where JCSJ>="+DateTime.Now.ToShortDateString()+"order by JCSJ desc";
                    break;
                case "当月":
                    sql = "select * from [已检车辆信息] where DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                case "当周":
                    sql = "select * from [已检车辆信息] where DATEPART(wk, JCSJ) = DATEPART(wk, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                default:
                    sql = "select * from [已检车辆信息] where DATEPART(dd, JCSJ)=DATEPART(dd, GETDATE()) and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
            }
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 根据车辆ID获取该车被检信息
        public CARDETECTED getCarbjbycarID(string carID)
        {
            DateTime a, b;
            CARDETECTED model = new CARDETECTED();
            string sql = "select * from [已检车辆信息] where CLID='" + carID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLID = dt.Rows[0]["CLID"].ToString();
                    model.STATIONID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.ZXBZ = dt.Rows[0]["ZXBZ"].ToString();
                    DateTime.TryParse(dt.Rows[0]["DLSJ"].ToString(), out a);
                    if (a != null)
                        model.DLSJ = a;
                    else
                        model.DLSJ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["JCSJ"].ToString(), out b);
                    if (b != null)
                        model.JCSJ = b;
                    else
                        model.JCSJ = DateTime.Today;
                    model.JCFF = dt.Rows[0]["JCFF"].ToString();
                    model.XSLC = dt.Rows[0]["XSLC"].ToString();
                    model.JCJG = dt.Rows[0]["JCJG"].ToString();
                    model.JCCS = dt.Rows[0]["JCCS"].ToString();
                    model.LSH = dt.Rows[0]["LSH"].ToString();
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();//1
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    model.CZ = dt.Rows[0]["CZ"].ToString();
                    model.SYXZ = dt.Rows[0]["SYXZ"].ToString();
                    model.PP = dt.Rows[0]["PP"].ToString();//5
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.CLSBM = dt.Rows[0]["CLSBM"].ToString();
                    model.FDJHM = dt.Rows[0]["FDJHM"].ToString();
                    model.FDJXH = dt.Rows[0]["FDJXH"].ToString();
                    model.SCQY = dt.Rows[0]["SCQY"].ToString();//10
                    model.HDZK = dt.Rows[0]["HDZK"].ToString();
                    model.JSSZK = dt.Rows[0]["JSSZK"].ToString();
                    model.ZZL = dt.Rows[0]["ZZL"].ToString();
                    model.HDZZL = dt.Rows[0]["HDZZL"].ToString();
                    model.ZBZL = dt.Rows[0]["ZBZL"].ToString();//15
                    model.JZZL = dt.Rows[0]["JZZL"].ToString();
                    DateTime.TryParse(dt.Rows[0]["ZCRQ"].ToString(), out a);
                    if (a != null)
                        model.ZCRQ = a;
                    else
                        model.ZCRQ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["SCRQ"].ToString(), out b);
                    if (b != null)
                        model.SCRQ = b;
                    else
                        model.SCRQ = DateTime.Today;
                    model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    model.RLZL = dt.Rows[0]["RLZL"].ToString();//20
                    model.EDGL = dt.Rows[0]["EDGL"].ToString();
                    model.EDZS = dt.Rows[0]["EDZS"].ToString();
                    model.BSQXS = dt.Rows[0]["BSQXS"].ToString();
                    model.DWS = dt.Rows[0]["DWS"].ToString();
                    model.GYFS = dt.Rows[0]["GYFS"].ToString();//25
                    model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    model.JQFS = dt.Rows[0]["JQFS"].ToString();
                    model.QGS = dt.Rows[0]["QGS"].ToString();
                    model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    model.CHZZ = dt.Rows[0]["CHZZ"].ToString();//30
                    model.DLSP = dt.Rows[0]["DLSP"].ToString();
                    model.SFSRL = dt.Rows[0]["SFSRL"].ToString();
                    model.JHZZ = dt.Rows[0]["JHZZ"].ToString();
                    model.OBD = dt.Rows[0]["OBD"].ToString();
                    model.DKGYYB = dt.Rows[0]["DKGYYB"].ToString();//35
                    model.LXDH = dt.Rows[0]["LXDH"].ToString();
                    model.CZY = dt.Rows[0]["CZY"].ToString();
                    model.JSY = dt.Rows[0]["JSY"].ToString();
                    model.DLY = dt.Rows[0]["DLY"].ToString();//35
                    model.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    model.JCFY = dt.Rows[0]["JCFY"].ToString();
                    model.SFJF = dt.Rows[0]["SFJF"].ToString();
                    model.TEST = dt.Rows[0]["TEST"].ToString();
                    model.QDLTQY = dt.Rows[0]["QDLTQY"].ToString();
                    model.RYPH = dt.Rows[0]["RYPH"].ToString();
                    model.HPZL = dt.Rows[0]["HPZL"].ToString();
                    model.jcgcsj = dt.Rows[0]["JCGCSJ"].ToString();
                    model.wjy = dt.Rows[0]["WJY"].ToString();
                    if (dt.Columns.Contains("CCS"))
                        model.CCS = dt.Rows[0]["CCS"].ToString();
                    else
                        model.CCS = "2";
                    if (dt.Columns.Contains("JYLSH"))
                        model.JYLSH = dt.Rows[0]["JYLSH"].ToString();
                    else
                        model.JYLSH = "";
                }
                else
                    model.CLID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;

        }
        #endregion
        #region 获取车辆的上次检测记录
        public CARDETECTED getPreTestDatebyPlate(string clph, string hpys)
        {
            DateTime a, b;
            CARDETECTED model = new CARDETECTED();
            string sql = "select * from [已检车辆信息] where CLHP='" + clph + "' and CPYS='" + hpys + "' order by JCSJ desc";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLID = dt.Rows[0]["CLID"].ToString();
                    model.STATIONID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.ZXBZ = dt.Rows[0]["ZXBZ"].ToString();
                    DateTime.TryParse(dt.Rows[0]["DLSJ"].ToString(), out a);
                    if (a != null)
                        model.DLSJ = a;
                    else
                        model.DLSJ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["JCSJ"].ToString(), out b);
                    if (b != null)
                        model.JCSJ = b;
                    else
                        model.JCSJ = DateTime.Today;
                    model.JCFF = dt.Rows[0]["JCFF"].ToString();
                    model.XSLC = dt.Rows[0]["XSLC"].ToString();
                    model.JCJG = dt.Rows[0]["JCJG"].ToString();
                    model.JCCS = dt.Rows[0]["JCCS"].ToString();
                    model.LSH = dt.Rows[0]["LSH"].ToString();
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();//1
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    model.CZ = dt.Rows[0]["CZ"].ToString();
                    model.SYXZ = dt.Rows[0]["SYXZ"].ToString();
                    model.PP = dt.Rows[0]["PP"].ToString();//5
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.CLSBM = dt.Rows[0]["CLSBM"].ToString();
                    model.FDJHM = dt.Rows[0]["FDJHM"].ToString();
                    model.FDJXH = dt.Rows[0]["FDJXH"].ToString();
                    model.SCQY = dt.Rows[0]["SCQY"].ToString();//10
                    model.HDZK = dt.Rows[0]["HDZK"].ToString();
                    model.JSSZK = dt.Rows[0]["JSSZK"].ToString();
                    model.ZZL = dt.Rows[0]["ZZL"].ToString();
                    model.HDZZL = dt.Rows[0]["HDZZL"].ToString();
                    model.ZBZL = dt.Rows[0]["ZBZL"].ToString();//15
                    model.JZZL = dt.Rows[0]["JZZL"].ToString();
                    DateTime.TryParse(dt.Rows[0]["ZCRQ"].ToString(), out a);
                    if (a != null)
                        model.ZCRQ = a;
                    else
                        model.ZCRQ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["SCRQ"].ToString(), out b);
                    if (b != null)
                        model.SCRQ = b;
                    else
                        model.SCRQ = DateTime.Today;
                    model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    model.RLZL = dt.Rows[0]["RLZL"].ToString();//20
                    model.EDGL = dt.Rows[0]["EDGL"].ToString();
                    model.EDZS = dt.Rows[0]["EDZS"].ToString();
                    model.BSQXS = dt.Rows[0]["BSQXS"].ToString();
                    model.DWS = dt.Rows[0]["DWS"].ToString();
                    model.GYFS = dt.Rows[0]["GYFS"].ToString();//25
                    model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    model.JQFS = dt.Rows[0]["JQFS"].ToString();
                    model.QGS = dt.Rows[0]["QGS"].ToString();
                    model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    model.CHZZ = dt.Rows[0]["CHZZ"].ToString();//30
                    model.DLSP = dt.Rows[0]["DLSP"].ToString();
                    model.SFSRL = dt.Rows[0]["SFSRL"].ToString();
                    model.JHZZ = dt.Rows[0]["JHZZ"].ToString();
                    model.OBD = dt.Rows[0]["OBD"].ToString();
                    model.DKGYYB = dt.Rows[0]["DKGYYB"].ToString();//35
                    model.LXDH = dt.Rows[0]["LXDH"].ToString();
                    model.CZY = dt.Rows[0]["CZY"].ToString();
                    model.JSY = dt.Rows[0]["JSY"].ToString();
                    model.DLY = dt.Rows[0]["DLY"].ToString();//35
                    model.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    model.JCFY = dt.Rows[0]["JCFY"].ToString();
                    model.SFJF = dt.Rows[0]["SFJF"].ToString();
                    model.TEST = dt.Rows[0]["TEST"].ToString();
                    model.QDLTQY = dt.Rows[0]["QDLTQY"].ToString();
                    model.RYPH = dt.Rows[0]["RYPH"].ToString();
                    model.jcgcsj = dt.Rows[0]["JCGCSJ"].ToString();
                    model.wjy = dt.Rows[0]["WJY"].ToString();
                    if (dt.Columns.Contains("CCS"))
                        model.CCS = dt.Rows[0]["CCS"].ToString();
                    else
                        model.CCS = "2";
                    if (dt.Columns.Contains("JYLSH"))
                        model.JYLSH = dt.Rows[0]["JYLSH"].ToString();
                    else
                        model.JYLSH = "";
                }
                else
                    model.CLID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 获取车辆的上次检测记录
        public CARDETECTED getPreTestDatebyPlate(string clph)
        {
            DateTime a, b;
            CARDETECTED model = new CARDETECTED();
            string sql = "select * from [已检车辆信息] where CLHP='" + clph + "' order by JCSJ desc";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLID = dt.Rows[0]["CLID"].ToString();
                    model.STATIONID = dt.Rows[0]["STATIONID"].ToString();
                    model.LINEID = dt.Rows[0]["LINEID"].ToString();
                    model.ZXBZ = dt.Rows[0]["ZXBZ"].ToString();
                    DateTime.TryParse(dt.Rows[0]["DLSJ"].ToString(), out a);
                    if (a != null)
                        model.DLSJ = a;
                    else
                        model.DLSJ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["JCSJ"].ToString(), out b);
                    if (b != null)
                        model.JCSJ = b;
                    else
                        model.JCSJ = DateTime.Today;
                    model.JCFF = dt.Rows[0]["JCFF"].ToString();
                    model.XSLC = dt.Rows[0]["XSLC"].ToString();
                    model.JCJG = dt.Rows[0]["JCJG"].ToString();
                    model.JCCS = dt.Rows[0]["JCCS"].ToString();
                    model.LSH = dt.Rows[0]["LSH"].ToString();
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();//1
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.CLLX = dt.Rows[0]["CLLX"].ToString();
                    model.CZ = dt.Rows[0]["CZ"].ToString();
                    model.SYXZ = dt.Rows[0]["SYXZ"].ToString();
                    model.PP = dt.Rows[0]["PP"].ToString();//5
                    model.XH = dt.Rows[0]["XH"].ToString();
                    model.CLSBM = dt.Rows[0]["CLSBM"].ToString();
                    model.FDJHM = dt.Rows[0]["FDJHM"].ToString();
                    model.FDJXH = dt.Rows[0]["FDJXH"].ToString();
                    model.SCQY = dt.Rows[0]["SCQY"].ToString();//10
                    model.HDZK = dt.Rows[0]["HDZK"].ToString();
                    model.JSSZK = dt.Rows[0]["JSSZK"].ToString();
                    model.ZZL = dt.Rows[0]["ZZL"].ToString();
                    model.HDZZL = dt.Rows[0]["HDZZL"].ToString();
                    model.ZBZL = dt.Rows[0]["ZBZL"].ToString();//15
                    model.JZZL = dt.Rows[0]["JZZL"].ToString();
                    DateTime.TryParse(dt.Rows[0]["ZCRQ"].ToString(), out a);
                    if (a != null)
                        model.ZCRQ = a;
                    else
                        model.ZCRQ = DateTime.Today;
                    DateTime.TryParse(dt.Rows[0]["SCRQ"].ToString(), out b);
                    if (b != null)
                        model.SCRQ = b;
                    else
                        model.SCRQ = DateTime.Today;
                    model.FDJPL = dt.Rows[0]["FDJPL"].ToString();
                    model.RLZL = dt.Rows[0]["RLZL"].ToString();//20
                    model.EDGL = dt.Rows[0]["EDGL"].ToString();
                    model.EDZS = dt.Rows[0]["EDZS"].ToString();
                    model.BSQXS = dt.Rows[0]["BSQXS"].ToString();
                    model.DWS = dt.Rows[0]["DWS"].ToString();
                    model.GYFS = dt.Rows[0]["GYFS"].ToString();//25
                    model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    model.JQFS = dt.Rows[0]["JQFS"].ToString();
                    model.QGS = dt.Rows[0]["QGS"].ToString();
                    model.QDXS = dt.Rows[0]["QDXS"].ToString();
                    model.CHZZ = dt.Rows[0]["CHZZ"].ToString();//30
                    model.DLSP = dt.Rows[0]["DLSP"].ToString();
                    model.SFSRL = dt.Rows[0]["SFSRL"].ToString();
                    model.JHZZ = dt.Rows[0]["JHZZ"].ToString();
                    model.OBD = dt.Rows[0]["OBD"].ToString();
                    model.DKGYYB = dt.Rows[0]["DKGYYB"].ToString();//35
                    model.LXDH = dt.Rows[0]["LXDH"].ToString();
                    model.CZY = dt.Rows[0]["CZY"].ToString();
                    model.JSY = dt.Rows[0]["JSY"].ToString();
                    model.DLY = dt.Rows[0]["DLY"].ToString();//35
                    model.JCZMC = dt.Rows[0]["JCZMC"].ToString();
                    model.JCFY = dt.Rows[0]["JCFY"].ToString();
                    model.SFJF = dt.Rows[0]["SFJF"].ToString();
                    model.TEST = dt.Rows[0]["TEST"].ToString();
                    model.QDLTQY = dt.Rows[0]["QDLTQY"].ToString();
                    model.RYPH = dt.Rows[0]["RYPH"].ToString();
                    model.HPZL = dt.Rows[0]["HPZL"].ToString();
                    model.jcgcsj = dt.Rows[0]["JCGCSJ"].ToString();
                    model.wjy = dt.Rows[0]["WJY"].ToString();
                    if (dt.Columns.Contains("CCS"))
                        model.CCS = dt.Rows[0]["CCS"].ToString();
                    else
                        model.CCS = "2";
                    if (dt.Columns.Contains("JYLSH"))
                        model.JYLSH = dt.Rows[0]["JYLSH"].ToString();
                    else
                        model.JYLSH = "";
                }
                else
                    model.CLID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        #endregion
        #region 删除被检数据
        public bool deleteDatabj(string carID)
        {
            string sql = "delete from [已检车辆信息] where CLID='" + carID + "'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 获取该车在今年的检测次数
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public int getJccsbyClph(string clph)
        {
            string year = DateTime.Now.Year.ToString();
            int count = 0;
            string sql = "select count(*) as number from [已检车辆信息] where CLHP='" + clph + "'" + " and JCSJ>" + "'" + year + "-01-01 00:00:00.000" + "'" + " and JCSJ<" + "'" + year + "-12-31 23:59:59.000'";
            try
            {
                count = DBHelperSQL.ExecuteCount(sql);
                return count;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 用车牌号检测该车是否已经在待检序列中
        /// <summary>
        /// 用车牌号检测该车的信息是否已经存在
        /// </summary>
        /// <param name="jcbh">汽车车牌</param>
        /// <param name="jccs">检测线编号</param>
        /// <returns>bool</returns>
        public bool checkCarIsAtWait(string jcclph)
        {
            string sql = "select * from [待检车辆] where CLHP="+"'"+jcclph+"'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 添加车辆到待检列表
        public CARATWAIT getDataWaitbyCarID(string carID)
        {
            CARATWAIT model = new CARATWAIT();
            string sql = "select * from [待检车辆] where CLID='" + carID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLID = dt.Rows[0]["CLID"].ToString();
                    model.DLSJ = DateTime.Parse(dt.Rows[0]["DLSJ"].ToString());
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.JCFF = dt.Rows[0]["JCFF"].ToString();
                    model.XSLC = dt.Rows[0]["XSLC"].ToString();
                    model.JCCS = dt.Rows[0]["JCCS"].ToString();
                    model.CZY = dt.Rows[0]["CZY"].ToString();
                    model.JSY = dt.Rows[0]["JSY"].ToString();
                    model.DLY = dt.Rows[0]["DLY"].ToString();
                    model.JCFY = dt.Rows[0]["JCFY"].ToString();
                    model.TEST = dt.Rows[0]["TEST"].ToString();
                    model.JCBGBH = dt.Rows[0]["JCBGBH"].ToString();
                    model.JCGWH = dt.Rows[0]["JCGWH"].ToString();
                    model.JCZBH = dt.Rows[0]["JCZBH"].ToString();
                    model.JCRQ = DateTime.Parse(dt.Rows[0]["JCRQ"].ToString());
                    model.BGJCFFYY = dt.Rows[0]["BGJCFFYY"].ToString();
                    model.SFCS = dt.Rows[0]["SFCS"].ToString();
                    model.ECRYPT = dt.Rows[0]["ECRYPT"].ToString();
                }
                else
                    model.CLID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;

        }
        public string addCarToWaitList(CARATWAIT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [待检车辆] (");
            strSql.Append("CLID,");//=@PZLX,");
            strSql.Append("DLSJ,");//=@JCCLPH,");
            strSql.Append("CLHP,");//=@CLXHBH,");
            strSql.Append("CPYS,");//=@JCCS,");
            strSql.Append("JCFF,");//=@JCCS,");
            strSql.Append("XSLC,");
            strSql.Append("JCCS,");
            strSql.Append("CZY,");//=@JCCS,");
            strSql.Append("JSY,");
            strSql.Append("JCFY,");//=@JCCS,");
            strSql.Append("TEST,");
            strSql.Append("JCBGBH,");
            strSql.Append("JCGWH,");
            strSql.Append("JCZBH,");
            strSql.Append("JCRQ,");
            strSql.Append("BGJCFFYY,");
            strSql.Append("SFCS,");
            strSql.Append("ECRYPT,");
            strSql.Append("DLY)");

            strSql.Append("values (@CLID,@DLSJ,@CLHP,@CPYS,@JCFF,@XSLC,@JCCS,@CZY,@JSY,@JCFY,@TEST,@JCBGBH,@JCGWH,@JCZBH,@JCRQ,@BGJCFFYY,@SFCS,@ECRYPT,@DLY)");
            SqlParameter[] parameters = {
					new SqlParameter("@CLID", SqlDbType.VarChar,50),
					new SqlParameter("@DLSJ", SqlDbType.DateTime),
					new SqlParameter("@CLHP",SqlDbType.VarChar,50),
					new SqlParameter("@CPYS", SqlDbType.VarChar,50),
                    new SqlParameter("@JCFF", SqlDbType.VarChar,50),
                    new SqlParameter("@XSLC", SqlDbType.VarChar,50),
                    new SqlParameter("@JCCS", SqlDbType.VarChar,50),
                    new SqlParameter("@CZY", SqlDbType.VarChar,50),
                    new SqlParameter("@JSY", SqlDbType.VarChar,50),
                    new SqlParameter("@JCFY", SqlDbType.VarChar,50),
                    new SqlParameter("@TEST", SqlDbType.VarChar,50),
                    new SqlParameter("@JCBGBH", SqlDbType.VarChar,50),
                    new SqlParameter("@JCGWH", SqlDbType.VarChar,50),
                    new SqlParameter("@JCZBH", SqlDbType.VarChar,50),
                    new SqlParameter("@JCRQ", SqlDbType.DateTime),
                    new SqlParameter("@BGJCFFYY", SqlDbType.VarChar,100),
                    new SqlParameter("@SFCS", SqlDbType.VarChar,50),
                    new SqlParameter("@ECRYPT", SqlDbType.VarChar,100),
                    new SqlParameter("@DLY", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CLID;
            parameters[1].Value = model.DLSJ;
            parameters[2].Value = model.CLHP;
            parameters[3].Value = model.CPYS;
            parameters[4].Value = model.JCFF;
            parameters[5].Value = model.XSLC;
            parameters[6].Value = model.JCCS;
            parameters[7].Value = model.CZY;
            parameters[8].Value = model.JSY;
            parameters[9].Value = model.JCFY;
            parameters[10].Value = model.TEST;
            parameters[11].Value = model.JCBGBH;
            parameters[12].Value = model.JCGWH;
            parameters[13].Value = model.JCZBH;
            parameters[14].Value = model.JCRQ;
            parameters[15].Value = model.BGJCFFYY;
            parameters[16].Value = model.SFCS;
            parameters[17].Value = model.ECRYPT;
            parameters[18].Value = model.DLY;
            try
            {
                if (checkCarIsAtWait(model.CLHP))
                {
                    return "环检添加失败，该车已在待检序列中";
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return "环检添加成功";
                    else
                        return "环检添加失败";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region 获取所有待检车辆信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllCarAtWait()
        {
            string sql = "select * from [待检车辆] order by DLSJ desc";
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 获取所有待检车辆信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllCarAtWait(string isNet)
        {
            string sql = "select * from [待检车辆] where TEST='" + isNet + "' order by DLSJ desc";
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 获取待检列表中某一辆车的检测信息
        public CARATWAIT getCarInfatWaitList(string clhp)
        {
            CARATWAIT model = new CARATWAIT();
            string sql = "select * from [待检车辆] where CLHP='" + clhp + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    model.CLID = dt.Rows[0]["CLID"].ToString();
                    model.DLSJ = DateTime.Parse(dt.Rows[0]["DLSJ"].ToString());
                    model.CLHP = dt.Rows[0]["CLHP"].ToString();
                    model.HPZL = dt.Rows[0]["HPZL"].ToString();
                    model.CPYS = dt.Rows[0]["CPYS"].ToString();
                    model.JCFF = dt.Rows[0]["JCFF"].ToString();
                    model.XSLC = dt.Rows[0]["XSLC"].ToString();
                    model.JCCS = dt.Rows[0]["JCCS"].ToString();
                    model.CZY = dt.Rows[0]["CZY"].ToString();
                    model.JSY = dt.Rows[0]["JSY"].ToString();
                    model.DLY = dt.Rows[0]["DLY"].ToString();
                    model.JCFY = dt.Rows[0]["JCFY"].ToString();
                    model.TEST = dt.Rows[0]["TEST"].ToString();
                    model.JCBGBH = dt.Rows[0]["JCBGBH"].ToString();
                    model.JCGWH = dt.Rows[0]["JCGWH"].ToString();
                    model.JCZBH = dt.Rows[0]["JCZBH"].ToString();
                    model.JCRQ = DateTime.Parse(dt.Rows[0]["JCRQ"].ToString());
                    model.BGJCFFYY = dt.Rows[0]["BGJCFFYY"].ToString();
                    model.SFCS = dt.Rows[0]["SFCS"].ToString();
                    model.ECRYPT = dt.Rows[0]["ECRYPT"].ToString();
                    model.JYLSH = dt.Rows[0]["JYLSH"].ToString();
                    model.SFCJ = dt.Rows[0]["SFCJ"].ToString();
                    if(dt.Columns.Contains("WXBJ"))
                    {
                        model.WXBJ= dt.Rows[0]["WXBJ"].ToString();
                        model.WXCD = dt.Rows[0]["WXCD"].ToString();
                        model.WXSJ = dt.Rows[0]["WXSJ"].ToString();
                        model.WXFY = dt.Rows[0]["WXFY"].ToString();
                        model.GYXTXS = dt.Rows[0]["GYXTXS"].ToString();
                        model.SFLJ = dt.Rows[0]["SFLJ"].ToString();
                        model.FWLX = dt.Rows[0]["FWLX"].ToString();
                        model.ICCARDNO = dt.Rows[0]["ICCARDNO"].ToString();
                        model.DPFS = dt.Rows[0]["DPFS"].ToString();
                    }
                    if(dt.Columns.Contains("SOURCE"))
                        model.SOURCE = dt.Rows[0]["SOURCE"].ToString();
                }
                else
                    model.CLID = "-2";       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception)
            {
                throw;
            }
            return model;

        }
        #endregion
        #region 获取该号牌待检车的车辆ID
        public string getCarIDatWaitbyPlate(string plate)
        {
            string sql = "select CLID from [待检车辆] where CLHP='"+plate+"'";
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CLID"].ToString();
                }
                else
                {
                    return "-2";
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 删除该号牌的待检车辆
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public bool deleteCarAtWaitbyPlate(string plate)
        {
            string sql = "delete from [待检车辆] where CLHP='"+plate+"'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 更改某一辆待检车的报告编号
        public int writeJcbgbhByPlate(string plate, string jcbgbh)
        {
            string sql = "update [待检车辆] set JCBGBH=" + "'" + jcbgbh + "'" + " where CLHP='" + plate + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region 检测数据是否存在
        public bool checkIsAlive(string carID, string listName)
        {
            string sql = "select * from [" + listName + "] where CLID=" + "'" + carID + "'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 检测数据是否存在
        public bool checkLSHIsAlive(string lsh, string listName)
        {
            string sql = "select * from [" + listName + "] where LSH=" + "'" + lsh + "'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region 更改某一检测是否缴费
        public int setCarbjPayed(string carID, string isPayed)
        {
            string sql = "update [已检车辆信息] set SFJF=" + "'" + isPayed + "'" + " where CLID='" + carID + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                int rows = DBHelperSQL.Execute(sql);
                return rows;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region 获取所有车辆信息
        /// <summary>
        /// 获取所有检测线的信息
        /// </summary>
        public DataTable getAllCarInf(string sqlname, DateTime starttime, DateTime endtime, bool up)
        {
            string sql = "";
            if (up)
                sql = "select lineid,clhp,jcsj,lsh,jcff,zxbz,cpys,hdzk,zzl,rlzl,zcrq,xh,xslc,cz,pp,syxz,scqy,clsbm,scrq,cllx,fdjhm from [" + sqlname + "] where jcsj>'" + starttime.ToShortDateString() + " 00:00:00" + "' and jcsj<'" + endtime.ToShortDateString() + " 23:59:59" + "' and jcjg='合格' order by jcsj";
            else
                sql = "select lineid,clhp,jcsj,lsh,jcff,zxbz,cpys,hdzk,zzl,rlzl,zcrq,xh,xslc,cz,pp,syxz,scqy,clsbm,scrq,cllx,fdjhm from [" + sqlname + "] where jcsj>'" + starttime.ToShortDateString() + " 00:00:00" + "' and jcsj<'" + endtime.ToShortDateString() + " 23:59:59" + "' and jcjg='合格' order by jcsj DESC";
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 获取该检测站的已检车辆数
        /// <summary>
        /// 获取所有检测线的信息
        /// stationid:站号，lineid:线号，0表示所有线，lx:0——全部，1——当年，2——当月，3——当天
        /// </summary>
        public int getStationLineDetectedCount(string stationid,string lineid,string lx)
        {
            string sql = "";
            if (lineid == "0") 
                sql = "select count(*) as number from [已检车辆信息]" + " where STATIONID=" + "'" + stationid + "'";
            else
                sql = "select count(*) as number from [已检车辆信息]" + " where STATIONID=" + "'" + stationid + "' and LINEID='"+lineid+"'";
            switch (lx)
            {
                case "0":
                    break;
                case "1":
                    sql += " and DATEPART(yy, JCSJ)=DATEPART(yy, GETDATE())";
                    break;
                case "2":
                    sql += " and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                case "3":
                    sql += " and DATEPART(dd, JCSJ)=DATEPART(dd, GETDATE()) and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                default: break;
            }
            int count = 0;
            try
            {
                count = DBHelperSQL.ExecuteCount(sql);
                return count;
            }
            catch
            {
                return 0;
                throw;
            }
        }
        public int getStationLineDetectedCount(string stationid, string lineid, string lx,string plate)
        {
            string sql = "";
            if (lineid == "0")
                sql = "select count(*) as number from [已检车辆信息]" + " where STATIONID=" + "'" + stationid + "' and CLHP LIKE'"+plate+"'";
            else
                sql = "select count(*) as number from [已检车辆信息]" + " where STATIONID=" + "'" + stationid + "' and LINEID='" + lineid + "' and CLHP LIKE'" + plate + "'";
            switch (lx)
            {
                case "0":
                    break;
                case "1":
                    sql += " and DATEPART(yy, JCSJ)=DATEPART(yy, GETDATE())";
                    break;
                case "2":
                    sql += " and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                case "3":
                    sql += " and DATEPART(dd, JCSJ)=DATEPART(dd, GETDATE()) and DATEPART(mm, JCSJ)=DATEPART(mm, GETDATE()) and DATEPART(yy, JCSJ) = DATEPART(yy, GETDATE())";
                    break;
                default: break;
            }
            int count = 0;
            try
            {
                count = DBHelperSQL.ExecuteCount(sql);
                return count;
            }
            catch
            {
                return 0;
                throw;
            }
        }
        #endregion

        #region 获取该检测站的上线车辆数
        /// <summary>
        /// 获取该检测站的上线车辆数
        /// </summary>
        /// <param name="stationid">检测站编号</param>
        /// <param name="lineid">线号</param>
        /// <param name="starttime">统计开始时间</param>
        /// <param name="endtime">统计结束时间</param>
        /// <param name="pdjg">判定结果</param>
        /// <param name="jcff">检测方法</param>
        /// <param name="jccs">检测次数</param>
        /// <returns></returns>
        public int getStationLineCarCount(string stationid, string lineid, DateTime starttime, DateTime endtime, string pdjg, string jcff, string jccs)
        {
            string sql = "";
            sql = "select count(clhp) as number from [已检车辆信息]" + " where STATIONID='" + stationid + "' and LINEID='" + lineid + "'";// and CLHP LIKE '" + plate + "'";
            sql += " and JCSJ>='" + starttime.ToShortDateString() + " 00:00:00" + "' and JCSJ<='" + endtime.ToShortDateString() + " 23:59:59" + "'";
            sql += " and JCJG='" + pdjg + "'";
            sql += " and JCFF='" + jcff + "'";
            switch (jccs)
            {
                case "1":
                    sql += " and JCCS='1'"; break;
                case "2":
                    sql += " and JCCS='2'"; break;
                case "3":
                    sql += " and JCCS>'2'"; break;
                default: break;
            }
            int dt = 0;
            try
            {
                dt = DBHelperSQL.ExecuteCount(sql);
                return dt;
            }
            catch
            {
                return dt;
                throw;
            }
        }
        #endregion
        public DataTable requerydata(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch
            {
                throw;
            }
        }


        #region 根据JYLSH和JYCS插入或更新条检测状态数据
        /// <summary>
        /// 用SDS对象插入或更新条检测数据
        /// </summary>
        /// <param name="SDS">SDS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_TestStateFirst(车辆检测状态 SDS)
        {
            string sqli = "insert into [车辆检测状态](JCZBH,LINEID,JYLSH,JYCS,JCSJ,CLHP,HPZL,ZT,JCFF,JCCZY,YCY,DLY) values(@JCZBH,@LINEID,@JYLSH,@JYCS,@JCSJ,@CLHP,@HPZL,@ZT,@JCFF,@JCCZY,@YCY,@DLY)";
            string sqlu = "update [车辆检测状态] set JCZBH=@JCZBH,LINEID=@LINEID,JCSJ=@JCSJ,CLHP=@CLHP,HPZL=@HPZL,ZT=@ZT,JCFF=@JCFF,JCCZY=@JCCZY,YCY=@YCY,DLY=@DLY where JYLSH=@JYLSH and JYCS=@JYCS";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCZBH",SDS.JCZBH),
                                   new SqlParameter("@LINEID",SDS.LINEID),
                                   new SqlParameter("@JYLSH",SDS.JYLSH),
                                   new SqlParameter("@JYCS",SDS.JYCS), //1
                                   new SqlParameter("@JCSJ",SDS.JCSJ), //1
                                   new SqlParameter("@CLHP",SDS.CLHP),
                                   new SqlParameter("@HPZL",SDS.HPZL),
                                   new SqlParameter("@ZT",SDS.ZT),
                                   new SqlParameter("@JCFF",SDS.JCFF),
                                   new SqlParameter("@JCCZY",SDS.JCCZY),
                                   new SqlParameter("@YCY",SDS.YCY),
                                   new SqlParameter("@DLY",SDS.DLY)
                                   //47
                               };
            try
            {
                if (Have_TestState(SDS.JYLSH,SDS.JYCS))
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

                throw(new ApplicationException(er.Message));
            }
        }
        #endregion
        #region 根据JYLSH和JYCS插入或更新条检测状态数据
        /// <summary>
        /// 用SDS对象插入或更新条检测数据
        /// </summary>
        /// <param name="SDS">SDS</param>
        /// <returns>int 0为失败，1为插入成功，2为更新成功</returns>
        public int Save_TestState(车辆检测状态 SDS)
        {
            string sqli = "insert into [车辆检测状态](JCZBH,LINEID,JYLSH,JYCS,JCSJ,ZT) values(@JCZBH,@LINEID,@JYLSH,@JYCS,@JCSJ,@ZT)";
            string sqlu = "update [车辆检测状态] set JCZBH=@JCZBH,LINEID=@LINEID,JCSJ=@JCSJ,ZT=@ZT where JYLSH=@JYLSH and JYCS=@JYCS";
            SqlParameter[] spr ={
                                   new SqlParameter("@JCZBH",SDS.JCZBH),
                                   new SqlParameter("@LINEID",SDS.LINEID),
                                   new SqlParameter("@JYLSH",SDS.JYLSH),
                                   new SqlParameter("@JYCS",SDS.JYCS), //1
                                   new SqlParameter("@JCSJ",SDS.JCSJ), //1
                                   new SqlParameter("@ZT",SDS.ZT)
                                   //47
                               };
            try
            {
                if (Have_TestState(SDS.JYLSH, SDS.JYCS))
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

                throw (new ApplicationException(er.Message));
            }
        }
        #endregion
        #region 用检验流水号和检验次数判断一条检测数据是否存在
        /// <summary>
        /// 用检测编号判断一条检测数据是否存在
        /// </summary>
        /// <param name="jcbh">检测编号</param>
        /// <returns>bool</returns>
        public bool Have_TestState(string JYLSH, string JYCS)
        {
            string sql = "select * from [车辆检测状态] where JYLSH=@JYLSH and JYCS=@JYCS";
            SqlParameter[] spr ={
                                   new SqlParameter("@JYLSH",JYLSH),
                                   new SqlParameter("@JYCS",JYCS)
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

        public DateTime getDateTime()
        {
            string sql = "SELECT CONVERT(varchar(100), GETDATE(), 25)";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                    return Convert.ToDateTime(dt.Rows[0][0].ToString());
                else
                    return DateTime.Now;
            }
            catch (Exception er)
            {
                throw(new ApplicationException(er.Message));
            }
        }
        public DataTable getTestState(string JYLSH,string JYCS)
        {
            string sql = "SELECT * from [车辆检测状态] where JYLSH='"+JYLSH+"' AND JYCS='"+JYCS+"'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception er)
            {
                throw (new ApplicationException(er.Message));
            }
        }
        #region 检查SpecialList是否有该车辆的匹配信息
        public bool checkCLHPIsInSpecialList(string clhp, DateTime jcsj)
        {
            string sql = "select * from [SpecialVehicleList] where CLPH='" + clhp + "' and datediff(d, JCSJ,'"+ jcsj.ToString("yyyy-MM-dd")+ "')>-30 and  datediff(d, JCSJ,'" + jcsj.ToString("yyyy-MM-dd") + "')<30";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                ini.INIIO.saveLogInf("执行SQL语句："+sql);
                if (dt.Rows.Count > 0)
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回true");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回false");
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + sql);
                return false;
                throw;
            }

        }
        #endregion
        #region 获取specialXz
        public DataTable getSpecialXz()
        {
            string sql = "select * from [SpecialVehicleXz]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                if (dt.Rows.Count > 0)
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回结果");
                    return dt;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回null");
                    return null;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + sql);
                return null;
                throw;
            }

        }
        #endregion
        #region 检查驱动轴重量表是否有该车辆的匹配信息
        public bool checkQDZZLisAlive(string clhp,string hpzl, DateTime jcsj)
        {
            string sql = "select * from [驱动轴重量] where CLHP='" + clhp + "' and HPZL='"+hpzl+"' and datediff(d, JCSJ,'" + jcsj.ToString("yyyy-MM-dd") + "')>-30 and  datediff(d, JCSJ,'" + jcsj.ToString("yyyy-MM-dd") + "')<30";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                if (dt.Rows.Count > 0)
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回true");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回false");
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + sql);
                return false;
                throw;
            }

        }
        #endregion
        /// <summary>
        /// 由车辆号牌来查询驱动轴称重记录
        /// </summary>
        /// <param name="clhp">车辆号牌</param>
        /// <param name="hpzl">号牌种类</param>
        /// <returns></returns>
        public DataTable getQdzzlbyclhp(string clhp, string hpzl)
        {
            string sql = "SELECT * from [驱动轴重量] where CLHP='" + clhp + "' AND HPZL='" + hpzl + "' order by jcsj desc";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception er)
            {
                throw (new ApplicationException(er.Message));
            }
        }
        #region 检查除本线外是否有其他线在使用油耗仪
        public bool checkYhyIsUsed(string lineid,out string usedlineid)
        {
            usedlineid = "";
            string sql = "select * from [油耗仪状态] where LINEID!='" + lineid + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                if (dt.Rows.Count > 0)
                {
                    usedlineid = dt.Rows[0]["LINEID"].ToString();
                    ini.INIIO.saveLogInf("执行SQL语句：返回true");
                    return true;
                }
                else
                {
                    ini.INIIO.saveLogInf("执行SQL语句：返回false");
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + sql);
                return false;
                throw;
            }

        }
        #endregion
        #region 删除油耗仪状态使用状况
        public bool deleteYhyZt()
        {
            string sql = "delete from [油耗仪状态]";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                    ini.INIIO.saveLogInf("执行SQL语句：返回true");
                    return true;
                
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + er.Message);
                return false;
                throw;
            }

        }
        #endregion
        #region 写入油耗仪状态
        public bool writeYhyZt(string LINEID)
        {
            string sql = "insert into [油耗仪状态] (ZT, LINEID, UPDATETIME) VALUES ('Y','"+LINEID+"','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                
                    return true;
                
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + er.Message);
                return false;
                throw;
            }

        }
        #endregion
        #region 写入驱动轴称重结果值
        public bool writeQdzzl(string clhp,string hpzl,string value)
        {
            string sql = "insert into [驱动轴重量] (CLHP, HPZL, QDZKZZL, JCSJ) VALUES ('"+clhp+"','" + hpzl + "','"+value+"','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);                
                return true;                
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + er.Message);
                return false;
                throw;
            }

        }
        #endregion
        /// <summary>
        /// 写入综检检测结果
        /// </summary>
        /// <param name="jylsh"></param>
        /// <param name="clhp"></param>
        /// <param name="hpzl"></param>
        /// <param name="jyxm"></param>
        /// <param name="resultxml"></param>
        /// <returns></returns>
        public bool writeXNresult(string jylsh,string clhp,string hpzl, string jyxm, string resultxml)
        {
            string sql = "insert into [综检检测结果] (JYLSH, CLHP, HPZL, JYXM, RESULTXML, JCSJ) VALUES ('" + jylsh + "','" + clhp + "','" + hpzl + "','" + jyxm + "','" + resultxml + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                ini.INIIO.saveLogInf("执行SQL语句：" + sql);
                return true;
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("执行SQL语句异常：" + er.Message);
                return false;
                throw;
            }
        }
        #region 获取该检测站的上线车辆数
        /// <summary>
        /// 获取该检测站的上线车辆数
        /// </summary>
        /// <param name="stationid">检测站编号</param>
        /// <param name="lineid">线号</param>
        /// <param name="starttime">统计开始时间</param>
        /// <param name="endtime">统计结束时间</param>
        /// <param name="pdjg">判定结果</param>
        /// <param name="jcff">检测方法</param>
        /// <param name="jccs">检测次数</param>
        /// <returns></returns>
        public int getCarCountByStaff(string lineid, DateTime starttime, DateTime endtime, string pdjg, string jcff, string jccs, string staffname)
        {
            string sql = "";
            sql = "select count(clhp) as number from [已检车辆信息]" + " where LINEID='" + lineid + "'";// and CLHP LIKE '" + plate + "'";
            sql += " and JCSJ>='" + starttime.ToShortDateString() + " 00:00:00" + "' and JCSJ<='" + endtime.ToShortDateString() + " 23:59:59" + "'";
            sql += " and JCJG='" + pdjg + "'";
            sql += " and JCFF='" + jcff + "'";
            sql += " and JSY='" + staffname + "'";
            switch (jccs)
            {
                case "1":
                    sql += " and JCCS='1'"; break;
                case "2":
                    sql += " and JCCS='2'"; break;
                case "3":
                    sql += " and JCCS>'2'"; break;
                default: break;
            }
            int dt = 0;
            try
            {
                dt = DBHelperSQL.ExecuteCount(sql);
                return dt;
            }
            catch
            {
                return dt;
                throw;
            }
        }
        #endregion




        #region 获取所有的山东济宁限值
        public DataTable getAllSdJnXz()
        {
            string sql = "select * from [山东烟度限值]";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region 检查山东济宁限值是否存在
        public bool checkSdJnXzAlive(string cx, string pfbz)
        {
            string sql = "select * from [山东烟度限值] where CX='" + cx + "' and PFBZ='" + pfbz + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
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
        #region 查询山东济宁限值
        public bool getSdJnXz(string cx, string pfbz,out double xz)
        {
            xz = 0;
            string sql = "select * from [山东烟度限值] where CX='" + cx + "' and PFBZ='" + pfbz + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    xz = double.Parse(dt.Rows[0]["XZ"].ToString());
                    return true;
                }
                else
                    return false;       //当服务器上没有找到本线时，本线编号置为-2，以免为0
            }
            catch (Exception er)
            {
                ini.INIIO.saveLogInf("查询限值时发生异常：" + er.Message);
                return false;
            }

        }
        #endregion
        public bool saveSdjnxz(string cx, string pfbz, string xz)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [山东烟度限值] (");
            strSql.Append("CX,");
            strSql.Append("PFBZ,");
            strSql.Append("XZ)");
            strSql.Append(" values (@CX,@PFBZ,@XZ)");
            SqlParameter[] parameters =
            {
                new SqlParameter("@CX", SqlDbType.VarChar,50),
                 new SqlParameter("@PFBZ", SqlDbType.VarChar,50),
                new SqlParameter("@XZ", SqlDbType.VarChar,50)
                };
            parameters[i++].Value = cx;
            parameters[i++].Value = pfbz;
            parameters[i++].Value = xz;
            try
            {
                if (checkSdJnXzAlive(cx, pfbz))
                {
                    if (updateSdydxz(cx, pfbz,xz))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DBHelperSQL.Execute(strSql.ToString(), parameters) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public bool updateSdydxz(string cx,string pfbz,string xz)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [山东烟度限值] set ");
            strSql.Append("XZ='"+xz+"'");
            strSql.Append(" where CX='" + cx + "' and PFBZ='" + pfbz + "'");
            
            try
            {
                if (DBHelperSQL.Execute(strSql.ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool deleteOneSdjnXz(string cx,string pfbz)
        {
            string sql = "delete from [山东烟度限值] where CX='" + cx + "' and PFBZ='"+pfbz+"'";
            try
            {
                if (DBHelperSQL.GetDataTable(sql, CommandType.Text).Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
    }
}


