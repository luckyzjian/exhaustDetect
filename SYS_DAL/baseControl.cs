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
    public partial class baseControl
    {
        #region 通用根据ID获取该项的名称
        public string getNameByID(string id, string listName,string IDname)
        {
            string sql = "select * from [" + listName + "] where "+IDname+"='" + id+ "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MC"].ToString();
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
        #region 通用名称来获取该项的ID叼
        public string getIDByName(string name, string listName, string IDname)
        {
            string sql = "select * from [" + listName + "] where MC='" + name + "'";
            try
            {
                DataTable dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][IDname].ToString();
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
        public bool setKeyIsIdentity(string listname)
        {
            string sql = "";
            sql = "ALTER TABLE " + listname + " ADD ID int IDENTITY(1, 1)";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool testKeyIsExist(string listname, string keyname)
        {
            string sql = "";
            sql = "select * from [" + listname + "]";

            DataTable dt = null;
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Columns.Contains(keyname))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool addkeyInList(string listname, string keyname)
        {
            string sql = "";
            sql = "ALTER table [" + listname + "] ADD " + keyname + " varchar(50) null";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool addDateTimekeyInList(string listname, string keyname)
        {
            string sql = "";
            sql = "ALTER table [" + listname + "] ADD " + keyname + " DATETIME null";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool addkeyVacharMaxInList(string listname, string keyname)
        {
            string sql = "";
            sql = "ALTER table [" + listname + "] ADD " + keyname + " varchar(MAX) null";
            try
            {
                DBHelperSQL.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetSystemVersion()
        {

            string sql = "select * from systemConfig";
            DataTable dt = null;
            string systemversion = "";
            try
            {
                dt = DBHelperSQL.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    systemversion = dt.Rows[0]["SYSTEMVERSION"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return systemversion;
        }
        public bool UpdateSystemVersion(string systemversion)
        {
            string sql = "update systemConfig set SYSTEMVERSION='" + systemversion + "'";
            try
            {
                if (DBHelperSQL.Execute(sql) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool checkTableIsExist(string tablename)
        {
            string sql = "if object_id( '" + tablename + "') is not null select 1 else select 0";
            try
            {
                int i = DBHelperSQL.ExecuteScalar(sql);
                if (i > 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool createTalbe(string tablename,string addKeyString)
        {
            //添加表语句
            string add_table = "create table [" + tablename + "] ("+addKeyString+")";
            try
            {
                DBHelperSQL.ExecuteNonQuery(add_table);
                return true;
            }
            catch(Exception er)
            {
                ini.INIIO.saveLogInf("数据库语句异常:" + er.Message);
                return false;
            }
        }
        public bool createTalbe(string tablename)
        {
            //添加表语句
            string add_table = "create table [" + tablename + "] (ID varchar(50) not null primary key, modifycontent varchar(400), username varchar(50), LSH varchar(50), modifytime datetime)";
            try
            {
                DBHelperSQL.ExecuteNonQuery(add_table);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


