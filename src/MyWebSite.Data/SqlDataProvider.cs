using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyWebSite.Data
{
    public class SqlDataProvider
    {
        static string strConStr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        /// <summary>
        /// Global SQL server connection
        /// </summary>
        public static SqlConnection connection;
        public SqlDataProvider()
        {
            if (connection == null) { connection = new SqlConnection(strConStr); }
            //if (connection.State != ConnectionState.Open) { connection.Open(); }
        }
        public static SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                //connection.Close();
                connection.Open();
                return connection;
            }
            else
                return connection;
        }
        public Database db = DatabaseFactory.CreateDatabase();
        public void ExecuteNonQuery(string sql) 
        {
            DbCommand cmd = db.GetSqlStringCommand(sql);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        public string MaxId(string Table, string ColId)
        {
            object strReturn = "";
            DbCommand cmd = db.GetSqlStringCommand("SELECT max(" + ColId + ") as maxid FROM " + Table);
            try
            {
                strReturn = db.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
            return strReturn.ToString();
        }
    }
    }

