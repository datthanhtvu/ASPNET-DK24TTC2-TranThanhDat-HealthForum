using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MyWebSite.Data
{
  public class RuleDAL:SqlDataProvider
    {
        #region[GetById]
      public List<Rule> Rule_GetById(string Id)
        {
            List<Data.Rule> list = new List<Data.Rule>();
            Data.Rule obj = new Data.Rule();
            DbCommand cmd = db.GetStoredProcCommand("sp_Rule_GetById", Id);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.RuleIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        #region[GetByTop]
      public List<Rule> Rule_GetByTop(string Top, string Where, string Order)
        {
            List<Data.Rule> list = new List<Data.Rule>();
            Data.Rule obj = new Data.Rule();
            DbCommand cmd = db.GetStoredProcCommand("sp_Rule_GetByTop", Top, Where, Order);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.RuleIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
      
        #region[Insert]
      public bool Rule_Insert(Rule data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_Rule_Insert"))
            {
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Description));
               
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
      #region[Rule_Update]
      public bool Rule_Update(Rule data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_Rule_Update"))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Description));
               
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
        #region[Delete]
      public bool Rule_Delete(string Id)
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Rule_Delete", Id);
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
