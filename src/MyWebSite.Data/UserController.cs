using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MyWebSite.Data
{
    public class UserDAL :SqlDataProvider
    {
        #region[User_GetById]
        public List<User> User_GetById(string Id)
        {
            List<Data.User> list = new List<Data.User>();
            Data.User obj = new Data.User();
            DbCommand cmd = db.GetStoredProcCommand("sp_User_GetById", Id);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.UserIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        #region[User_GetByTop]
        public List<User> User_GetByTop(string Top, string Where, string Order)
        {
            List<Data.User> list = new List<Data.User>();
            Data.User obj = new Data.User();
            DbCommand cmd = db.GetStoredProcCommand("sp_User_GetByTop", Top, Where, Order);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.UserIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
     
        #region[User_Paging]
        public List<User> User_Paging(string CurentPage, string PageSize)
        {
            List<Data.User> list = new List<Data.User>();
            Data.User obj = new Data.User();
            DbCommand cmd = db.GetStoredProcCommand("sp_User_Paging", CurentPage, PageSize);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.UserIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        #region[User_Insert]
        public bool User_Insert(User data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_User_Insert"))
            {
                cmd.Parameters.Add(new SqlParameter("@RuleId", data.RuleId == "" || data.RuleId == "0" ? DBNull.Value : (object)data.RuleId));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                cmd.Parameters.Add(new SqlParameter("@Level", data.Level));
                cmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
                cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                try
                {
                    db.ExecuteNonQuery(cmd);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    //throw ex;
                }
                finally
                {
                    if (cmd != null) cmd.Dispose();
                }
            }
        }
        #endregion
        #region[User_Update]
        public bool User_Update(User data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_User_Update"))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@RuleId", data.RuleId));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                cmd.Parameters.Add(new SqlParameter("@Level", data.Level));
                cmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
                cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                try
                {
                    db.ExecuteNonQuery(cmd);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    //throw ex;
                }
                finally
                {
                    if (cmd != null) cmd.Dispose();
                }
            }
        }
        #endregion
        #region[User_Delete]
        public bool User_Delete(string Id)
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_User_Delete", Id);
            try
            {
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        #endregion
        #region[User_ChangePass]
        public bool User_ChangePass(string UserName, string NewPassword)
        {
            DbCommand cmd = db.GetSqlStringCommand("Update [user] set [password]='" + NewPassword + "' where Username= '" + UserName + "'");
            try
            {
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }
        #endregion										
    }

}