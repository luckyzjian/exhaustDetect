using System;
using System.Data;
using System.Data.SqlClient;
using SYS.Model;

namespace SYS_DAL
{
	/// <summary>
	/// 数据访问类:XXXXB
    /// </summary>
    
    public class XXXXB
	{
        #region 得到消息列表的最大ID
        /// <summary>
        /// 得到消息列表的最大ID
        /// </summary>
        /// <returns>int 最大ID</returns>
		public int GetMaxId()
		{
            string sql = "select max(id) from xxxxb";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                    return int.Parse(dt.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception)
            {
                throw;
            }
		}
        #endregion

        #region 查询一条数据是否存在
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        /// <returns>bool</returns>
		public bool Exists(int ID)
		{
            string sql="select * from xxxxb where ID=@ID";
            SqlParameter[] spr={
                                   new SqlParameter("@ID",ID)
                               };
            DataTable dt= DBHelperSQL.GetDataTable(sql,CommandType.Text ,spr);
            if(dt.Rows.Count>0)
                return true;
            else
                return false;
		}
	    #endregion

        #region 保存一条消息数据
        /// <summary>
        /// 保存一条消息数据
        /// </summary>
        /// <param name="xxxxb">SYS.Model.XXXXB</param>
        /// <returns>bool</returns>
		 public bool Save(SYS.Model.XXXXB xxxxb)
		{
            string sqli = "insert into xxxxb(Title,Content,Other,Comefrom,Getto,Message_Message_Type,Flag) values(@Title,@Content,@Other,@Comefrom,@Getto,@Message_Message_Type,@Flag)";
            string sqlu="update xxxxb set Title=@Title,Content=@Content,Other=@Other,Comefrom=@Comefrom,Getto=@Getto,Message_Type=@Message_Type,Flag=@Flag where ID=@ID";
            SqlParameter[] spr = {
                                     new SqlParameter("@Title", xxxxb.Title),
                                     new SqlParameter("@Content", xxxxb.Content),
					                 new SqlParameter("@Other", xxxxb.Other),
					                 new SqlParameter("@Comefrom", xxxxb.Comefrom),
					                 new SqlParameter("@Getto", xxxxb.Getto),
					                 new SqlParameter("@Flag", xxxxb.Flag),
                                     new SqlParameter("@Message_Type", xxxxb.Message_Type),
					                 new SqlParameter("@ID", xxxxb.ID)
                                 };
            if(xxxxb.ID!=0)
            {
                if(Exists(xxxxb.ID))
                    if(DBHelperSQL.Execute(sqlu,spr)>0)
                        return true;
                    else
                        return false;
                else
                    if( DBHelperSQL.Execute(sqli,spr)>0)
                        return true;
                    else
                        return false;
            }
            else
                if( DBHelperSQL.Execute(sqli,spr)>0)
                    return true;
                else
                    return false;
		}
	    #endregion

        #region 删除一条消息数据
        /// <summary>
        /// 删除一条消息数据
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <returns>bool</returns>
		public bool Delete(int ID)
        {
		    string sql="delete from XXXXB where ID=@ID";
		    SqlParameter[] spr = {
				    new SqlParameter("@ID", ID)
		                        };
		    int rows=DBHelperSQL.Execute(sql,spr);
		    if (rows > 0)
			    return true;
		    else
			    return false;
        }
	    #endregion

        #region 删除所有消息数据
        /// <summary>
        /// 删除所有消息数据
        /// </summary>
        /// <returns>bool</returns>
		public bool DeleteAll()
        {
            string sql= "delete * from xxxxb";
            if(DBHelperSQL.Execute(sql)>0)
                return true;
            else 
                return false;
        }
	    #endregion

        #region 得到一条消息数据
        /// <summary>
        /// 得到一条消息数据
        /// </summary>
        /// <param name="Getto">到达</param>
        /// <param name="Message_Type">类型</param>
        /// <param name="flag">状态</param>
        /// <returns>SYS.Model</returns>
        public SYS.Model.XXXXB GetModel(string Getto, string Message_Type, string flag)
        {
            string sql = "select top 1 ID,* from xxxxb where Getto=@Getto and Message_Type=@Message_Type and Flag=@Flag";
            SqlParameter[] spr = {
					new SqlParameter("@Getto", Getto),
                    new SqlParameter("@Message_Type", Message_Type),
                    new SqlParameter("@Flag", flag)
			};
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                SYS.Model.XXXXB xxxb = null;
                if (dt.Rows.Count > 0)
                {
                    xxxb = new SYS.Model.XXXXB();
                    xxxb.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    xxxb.Title = dt.Rows[0]["Title"].ToString();
                    xxxb.Content = dt.Rows[0]["Content"].ToString();
                    xxxb.Comefrom = dt.Rows[0]["Comefrom"].ToString();
                    xxxb.Other = dt.Rows[0]["Other"].ToString();
                    xxxb.Message_Type = dt.Rows[0]["Message_Type"].ToString();
                    xxxb.Flag = dt.Rows[0]["Flag"].ToString();
                }
                return xxxb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 得到一条消息数据
        /// <summary>
        /// 得到一条消息数据
        /// </summary>
        /// <param name="Getto">目的地</param>
        /// <param name="flag">标记</param>
        /// <returns>SYS.Model.XXXXB</returns>
        public SYS.Model.XXXXB GetModel(string Getto, string flag)
        {
            string sql = "select top 1 ID,* from xxxxb where Getto=@Getto and Flag=@Flag";
            SqlParameter[] spr = {
					new SqlParameter("@Getto", Getto),
                    new SqlParameter("@Flag", flag)
			};
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                SYS.Model.XXXXB xxxb = null;
                if (dt.Rows.Count > 0)
                {
                    xxxb = new SYS.Model.XXXXB();
                    xxxb.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    xxxb.Title = dt.Rows[0]["Title"].ToString();
                    xxxb.Content = dt.Rows[0]["Content"].ToString();
                    xxxb.Comefrom = dt.Rows[0]["Comefrom"].ToString();
                    xxxb.Other = dt.Rows[0]["Other"].ToString();
                    xxxb.Message_Type = dt.Rows[0]["Message_Message_Type"].ToString();
                    xxxb.Flag = dt.Rows[0]["Flag"].ToString();
                }
                return xxxb;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 得到所有消息
        /// <summary>
        /// 得到所有消息
        /// </summary>
        /// <param name="Getto">目的地</param>
        /// <param name="flag">标记</param>
        /// <returns>datatable</returns>
        public DataTable GetAll(string Getto, string flag)
        {
            string sql = "select * from xxxxb where Getto=@Getto and Flag=@Flag";
            SqlParameter[] spr = {
					new SqlParameter("@Getto", Getto),
                    new SqlParameter("@Flag", flag)
			};
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 得到所有消息
        /// <summary>
        /// 得到所有消息
        /// </summary>
        /// <param name="Getto">到达</param>
        /// <param name="Message_Type">类型</param>
        /// <param name="flag">状态</param>
        /// <returns>datatable</returns>
        public DataTable GetAll(string Getto, string Message_Type, string flag)
        {
            string sql = "select * from xxxxb where Getto=@Getto and Message_Type=@Message_Type and Flag=@Flag";
            SqlParameter[] spr = {
					new SqlParameter("@Getto", Getto),
                    new SqlParameter("@Message_Type", Message_Type),
                    new SqlParameter("@Flag", flag)
			};
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text, spr);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 修改消息状态
        /// <summary>
        /// 修改消息状态
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <param name="flag">消息状态</param>
        /// <returns>bool</returns>
        public bool Set_Read(int ID, string flag)
        {
            string sql = "Update xxxxb set flag=@flag where ID=@ID";
            SqlParameter[] spr ={
                                   new SqlParameter("@ID",ID),
                                   new SqlParameter("@flag",flag)
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
	}
}

