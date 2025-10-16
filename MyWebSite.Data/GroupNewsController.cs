using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MyWebSite.Data
{
    public class GroupNewsDAL : SqlDataProvider
   {
        #region[GetByNewsTag]
        public List<GroupNews> GroupNews_GetByNewsTag(string Tag)
        {
            List<Data.GroupNews> list = new List<Data.GroupNews>();
            Data.GroupNews obj = new Data.GroupNews();
            DbCommand cmd = db.GetStoredProcCommand("sp_News_GetNameGroupNews", Tag);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.GroupNewsIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
       #region[GetByTop]

       public List<GroupNews> GroupNews_GetByTop(string Top, string Where, string Order)
       {
           List<Data.GroupNews> list = new List<Data.GroupNews>();
           Data.GroupNews obj = new Data.GroupNews();
           DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_GetbyTop", Top, Where, Order);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.GroupNewsIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[GetById]
       public List<GroupNews> GroupNews_GetById(string Id)
       {
           List<Data.GroupNews> list = new List<Data.GroupNews>();
           Data.GroupNews obj = new Data.GroupNews();
           DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_GetbyId", Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.GroupNewsIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[Insert]
       public bool GroupNews_Insert(GroupNews data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_Insert"))
           {
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Level", data.Level));
               cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
               cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
               cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
               cmd.Parameters.Add(new SqlParameter("@KeyWord", data.KeyWord));
               cmd.Parameters.Add(new SqlParameter("@Position", data.Position));
               cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
               cmd.Parameters.Add(new SqlParameter("@Index", data.Index));
               cmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
               cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
               cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
               try
               {
                   db.ExecuteNonQuery(cmd);
                   return true;
               }
               catch (Exception ex)
               {
                   return false;
               }
               finally
               {
                   if (cmd != null) cmd.Dispose();
               }
           } 
       }
       #endregion
       #region[Update]
       public bool GroupNews_Update(GroupNews data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Level", data.Level));
               cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
               cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
               cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
               cmd.Parameters.Add(new SqlParameter("@KeyWord", data.KeyWord));
               cmd.Parameters.Add(new SqlParameter("@Position", data.Position));
               cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
               cmd.Parameters.Add(new SqlParameter("@Index", data.Index));
               cmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
               cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
               cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
               try
               {
                   db.ExecuteNonQuery(cmd);
                   return true;
               }
               catch (Exception ex)
               {
                   return false;
               }
               finally
               {
                   if (cmd != null) cmd.Dispose();
               }
           }
       }
       #endregion
       #region[Delete]
       public bool GroupNews_Delete(string Id)
       {
           DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_Delete", Id);
          
               try
               {
                   db.ExecuteNonQuery(cmd);
                   return true;
               }
               catch (Exception ex)
               {
                   return false;
               }
               finally
               {
                   if (cmd != null) cmd.Dispose();
               }
           }
    
       #endregion

       #region[GroupNews_Update_Ord]
       public bool GroupNews_Update_Ord(GroupNews data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_GroupNews_Update_Ord"))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
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
   }
}
