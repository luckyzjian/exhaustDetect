using System;
using System.Data;
//using Oracle.DataAccess.Client;
using System.Collections;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;
namespace JHWebClient
{
    /// ConnDbForOracle 的摘要说明。
    public class ConnForOracle
    {
        OracleConnection Connection;


        #region 带参数的构造函数 
        /// 带参数的构造函数
        /// 数据库联接字符串
        public ConnForOracle(string ConnString)
        {
            string connStr;
            connStr = ConnString;
            Connection = new OracleConnection();
            Connection.ConnectionString = connStr;
            //Connection.Open();
        }
        #endregion

        #region 打开数据库 
        /// 打开数据库
        public void OpenConn()
        {
            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
        }
        #endregion
        #region 关闭数据库联接 
        /// 关闭数据库联接
        public void CloseConn()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        #endregion

        #region 执行SQL语句，返回数据到DataSet中
        /// 执行SQL语句，返回数据到DataSet中
        /// sql语句
        /// 自定义返回的DataSet表名
        /// 返回DataSet
        public DataSet ReturnDataSet(string sql, string DataSetName)
        {
            DataSet dataSet = new DataSet();
            OpenConn();
            OracleDataAdapter OraDA = new OracleDataAdapter(sql, Connection);
            OraDA.Fill(dataSet, DataSetName);
            CloseConn();
            return dataSet;
        }
        #endregion

        #region 执行SQL语句，返回数据到DataSet中
        /// 执行SQL语句，返回数据到DataSet中
        /// sql语句
        /// 自定义返回的DataSet表名
        /// 返回DataSet
        public DataSet ReturnDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            OpenConn();
            OracleDataAdapter OraDA = new OracleDataAdapter(sql, Connection);
            OraDA.Fill(dataSet);
            CloseConn();
            return dataSet;
        }
        #endregion

        #region 执行Sql语句,返回带分页功能的dataset 
        /// 执行Sql语句,返回带分页功能的dataset
        /// Sql语句
        /// 每页显示记录数
        /// <当前页/param>
        /// 返回dataset表名
        /// 返回DataSet
        public DataSet ReturnDataSet(string sql, int PageSize, int CurrPageIndex, string DataSetName)
        {
            DataSet dataSet = new DataSet();
            OpenConn();
            OracleDataAdapter OraDA = new OracleDataAdapter(sql, Connection);
            OraDA.Fill(dataSet, PageSize * (CurrPageIndex - 1), PageSize, DataSetName);
              CloseConn();
            return dataSet;
        }
        #endregion

        #region 执行SQL语句，返回 DataReader,用之前一定要先.read()打开,然后才能读到数据
        /// 执行SQL语句，返回 DataReader,用之前一定要先.read()打开,然后才能读到数据 
        /// sql语句
        /// 返回一个OracleDataReader
        public string ReturnDataReader(String sql)
        {
             
            string datareaderstring = "";
            try
            {
                OpenConn();
                OracleCommand command = new OracleCommand(sql, Connection);
                OracleDataReader datareader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (datareader.Read())
                {
                    datareaderstring =System.Text.Encoding.GetEncoding("GB2312").GetString((byte[])datareader[0]);
                }
                CloseConn();
            }
            catch(Exception er)
            {
            }
            return datareaderstring;
        }
        #endregion
        

        #region 执行SQL语句，返回记录总数数
        /// 执行SQL语句，返回记录总数数
        /// sql语句
        /// 返回记录总条数
        public int GetRecordCount(string sql)
        {
            int recordCount = 0;
            OpenConn();
            OracleCommand command = new OracleCommand(sql, Connection);
            OracleDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                recordCount++;
            }
            dataReader.Close();
            CloseConn();
            return recordCount;
        }
        #endregion

        #region 取当前序列,条件为seq.nextval或seq.currval
        /// 
        /// 取当前序列
        public decimal GetSeq(string seqstr)
        {
            decimal seqnum = 0;
            string sql = "select " + seqstr + " from dual";
            OpenConn();
            OracleCommand command = new OracleCommand(sql, Connection);
            OracleDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                seqnum = decimal.Parse(dataReader[0].ToString());
            }
            dataReader.Close();
            CloseConn();
            return seqnum;
        }
        #endregion
        #region 执行SQL语句,返回所影响的行数
        /// 执行SQL语句,返回所影响的行数
        public int ExecuteSQL(string sql)
        {
            int Cmd = 0;
            OpenConn();
            OracleCommand command = new OracleCommand(sql, Connection);
            try
            {
                Cmd = command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                CloseConn();
            }
            return Cmd;
        }
        #endregion

        //＝＝用hashTable对数据库进行insert,update,del操作,注意此时只能用默认的数据库连接"connstr"
        #region 根据表名及哈稀表自动插入数据库 用法：Insert("test",ht)
        public int Insert(string TableName, Hashtable ht)
        {
            OracleParameter[] Parms = new OracleParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            DataTable dt = GetTabType(TableName);
            
            OracleDbType otype;
            
            int size = 0;
            int i = 0;
            while (et.MoveNext()) // 作哈希表循环
            {
                GetoType(et.Key.ToString(), dt, out otype, out size);
                OracleParameter op = MakeParam(":" + et.Key.ToString(), otype, size, et.Value.ToString());
                Parms[i] = op; // 添加SqlParameter对象
                i = i + 1;
            }
            string str_Sql = GetInsertSqlbyHt(TableName, ht); // 获得插入sql语句
            int val = ExecuteNonQuery(str_Sql);
            ini.INIIO.saveLogInf(str_Sql);
            return val;
        }
        #endregion

        #region 根据相关条件对数据库进行更新操作 用法：Update("test","Id=:Id",ht); 
        public int Update(string TableName, string ht_Where, Hashtable ht)
        {
            OracleParameter[] Parms = new OracleParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            DataTable dt = GetTabType(TableName);
            OracleDbType otype;
            int size = 0;
            int i = 0;
            // 作哈希表循环
            while (et.MoveNext())
            {
                GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
                OracleParameter op = MakeParam(":" + et.Key.ToString(), otype, size, et.Value.ToString());
                Parms[i] = op; // 添加SqlParameter对象
                i = i + 1;
            }
            string str_Sql = GetUpdateSqlbyHt(TableName, ht_Where, ht); // 获得插入sql语句
            int val = ExecuteNonQuery(str_Sql, Parms);
            return val;
        }
        #endregion

        #region del操作,注意此处条件个数与hash里参数个数应该一致 用法：Del("test","Id=:Id",ht)
        public int Del(string TableName, string ht_Where, Hashtable ht)
        {
            OracleParameter[] Parms = new OracleParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            DataTable dt = GetTabType(TableName);
            OracleDbType otype;
            int i = 0;
            int size = 0;
            // 作哈希表循环
            while (et.MoveNext())
            {
                GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
                OracleParameter op = MakeParam(":" + et.Key.ToString(), et.Value.ToString());
                Parms[i] = op; // 添加SqlParameter对象
                i = i + 1;
            }
            string str_Sql = GetDelSqlbyHt(TableName, ht_Where, ht); // 获得删除sql语句
            int val = ExecuteNonQuery(str_Sql, Parms);
            return val;
        }
        #endregion

        //　＝＝＝＝＝＝＝＝上面三个操作的内部调用函数＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        #region 根据哈稀表及表名自动生成相应insert语句(参数类型的)
        /// 根据哈稀表及表名自动生成相应insert语句 
        /// 要插入的表名
        /// 哈稀表
        /// 返回sql语句
        public static string GetInsertSqlbyHt(string TableName, Hashtable ht)
        {
            string str_Sql = "";
            int i = 0;
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            string before = "";
            string behide = "";
            while (myEnumerator.MoveNext())
            {
                if (i == 0)
                {
                    before = "(" + myEnumerator.Key;
                }
                else if (i + 1 == ht_Count)
                {
                    before = before + "," + myEnumerator.Key + ")";
                }
                else
                {
                    before = before + "," + myEnumerator.Key;
                }
                i = i + 1;
            }
            myEnumerator = ht.GetEnumerator();
            i = 0;
            while (myEnumerator.MoveNext())
            {
                if (i == 0)
                {
                    behide = "('" + myEnumerator.Value+"'";
                }
                else if (i + 1 == ht_Count)
                {
                    behide = behide + ",'" + myEnumerator.Value + "')";
                }
                else
                {
                    behide = behide + ",'" + myEnumerator.Value+"'";
                }
                i = i + 1;
            }
            behide = behide.Replace("'DateTimeS", "to_date('").Replace("DateTimeE'", "','yyyy-MM-dd hh24:mi:ss')");
            behide = " Values" + behide;
            str_Sql = "Insert into " + TableName + before + behide;
            return str_Sql;
        }
        #endregion

        #region 根据表名，where条件，哈稀表自动生成更新语句(参数类型的)
        public static string GetUpdateSqlbyHt(string Table, string ht_Where, Hashtable ht)
        {
            string str_Sql = "";
            int i = 0;
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (i == 0)
                {
                    if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key + "=:" + myEnumerator.Key).ToLower()) == -1)
                    {
                        str_Sql = myEnumerator.Key + "=:" + myEnumerator.Key;
                    }
                }
                else
                {
                    if (ht_Where.ToString().ToLower().IndexOf((":" + myEnumerator.Key + " ").ToLower()) == -1)
                    {
                        str_Sql = str_Sql + "," + myEnumerator.Key + "=:" + myEnumerator.Key;
                    }
                }
                i = i + 1;
            }
            if (ht_Where == null || ht_Where.Replace(" ", "") == "") // 更新时候没有条件
            {
                str_Sql = "update " + Table + " set " + str_Sql;
            }
            else
            {
                str_Sql = "update " + Table + " set " + str_Sql + " where " + ht_Where;
            }
            str_Sql = str_Sql.Replace("set ,", "set ").Replace("update ,", "update ");
            return str_Sql;
        }
        #endregion

        #region 根据表名，where条件，哈稀表自动生成del语句(参数类型的)
        public static string GetDelSqlbyHt(string Table, string ht_Where, Hashtable ht)
        {
            string str_Sql = "";
            int i = 0;

            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (i == 0)
                {
                    if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key + "=:" + myEnumerator.Key).ToLower()) == -1)
                    {
                        str_Sql = myEnumerator.Key + "=:" + myEnumerator.Key;
                    }
                }
                else
                {
                    if (ht_Where.ToString().ToLower().IndexOf((":" + myEnumerator.Key + " ").ToLower()) == -1)
                    {
                        str_Sql = str_Sql + "," + myEnumerator.Key + "=:" + myEnumerator.Key;
                    }
                }
                i = i + 1;
            }
            if (ht_Where == null || ht_Where.Replace(" ", "") == "") // 更新时候没有条件
            {
                str_Sql = "Delete " + Table;
            }
            else
            {
                str_Sql = "Delete " + Table + " where " + ht_Where;
            }
            return str_Sql;
        }
        #endregion

        #region 生成oracle参数
        /// 
        /// 生成oracle参数
        /// 字段名
        /// 数据类型
        /// 数据大小
        /// 值
        public static OracleParameter MakeParam(string ParamName, OracleDbType otype, int size, Object Value)
        {
            OracleParameter para = new OracleParameter(ParamName, Value);
            para.OracleDbType = otype;
            para.Size = size;
            return para;
        }
        #endregion
        #region 生成oracle参数
        public static OracleParameter MakeParam(string ParamName, string Value)
        {
            return new OracleParameter(ParamName, Value);
        }
        #endregion
        #region 根据表结构字段的类型和长度拼装oracle sql语句参数
        public static void GetoType(string key, DataTable dt, out OracleDbType otype, out int size)
        {
            try
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "column_name='" + key + "'";
                string fType = dv[0]["data_type"].ToString().ToUpper();
                switch (fType)
                {
                    case "DATE":
                        otype = OracleDbType.Date;
                        size = int.Parse(dv[0]["data_length"].ToString());
                        break;
                    case "CHAR":
                        otype = OracleDbType.Char;
                        size = int.Parse(dv[0]["data_length"].ToString());
                        break;
                    case "LONG":
                        otype = OracleDbType.Long;
                        size = int.Parse(dv[0]["data_length"].ToString());
                        break;
                    case "NVARCHAR2":
                        otype = OracleDbType.NVarchar2;
                        size = int.Parse(dv[0]["data_length"].ToString());
                        break;
                    case "VARCHAR2":
                        otype = OracleDbType.Varchar2;
                        size = int.Parse(dv[0]["data_length"].ToString());
                        break;
                    default:
                        otype = OracleDbType.NVarchar2;
                        size = 100;
                        break;
                }
            }
            catch
            {
                otype = OracleDbType.NVarchar2;
                size = 100;
            }
        }
        #endregion
        #region 动态 取表里字段的类型和长度,此处没有动态用到connstr,是默认的！by/文少
        public System.Data.DataTable GetTabType(string tabnale)
        {
            string sql = "select column_name,data_type,data_length from all_tab_columns where table_name='" + tabnale.ToUpper() + "'";
            OpenConn();
            return (ReturnDataSet(sql, "dv")).Tables[0];
        }
        #endregion
        #region 执行sql语句 
        public int ExecuteNonQuery(string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OpenConn();
            cmd.Connection = Connection;
            cmd.CommandText = cmdText;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            CloseConn();
            return val;
        }
        #endregion
    }
}

