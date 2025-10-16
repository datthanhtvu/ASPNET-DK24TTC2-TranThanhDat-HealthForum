using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MyWebSite.Data
{
   public class LanguageDAL:SqlDataProvider
   {
       #region[GetbyTop] 
       public List<Language> Language_GetByTop(string Top, string Where, string Order)
       { 
         List<Data.Language> list= new  List<Data.Language>();
         Data.Language obj =new Data.Language();
         DbCommand cmd =db.GetStoredProcCommand("sp_Language_GetByTop",Top,Where,Order);
           using( IDataReader dr =db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.LanguageIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
        }
       #endregion
       #region[GetbyId]
       public List<Language> Language_GetById(string Id)
       {
           List<Data.Language> list = new List<Data.Language>();
           Data.Language obj = new Data.Language();
           DbCommand cmd = db.GetStoredProcCommand("sp_Language_GetById", Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.LanguageIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[Insert]
       public bool Language_Insert(Language data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Language_Insert"))
           {
               cmd.Parameters.Add(new SqlParameter("@Name",data.Name));
               cmd.Parameters.Add(new SqlParameter("@Folder", data.Folder));
               cmd.Parameters.Add(new SqlParameter("@Default", data.Default));
               cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
               cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
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
       public bool Language_Update(Language data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Language_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Folder", data.Folder));
               cmd.Parameters.Add(new SqlParameter("@Default", data.Default));
               cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
               cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
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
       public bool Language_Delete(string Id)
       {
           DbCommand cmd = db.GetStoredProcCommand("sp_Language_Delete",Id);
          
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
   }
}
