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
   public class ContactDAL:SqlDataProvider
   {
       #region[GetByTop]
       public List<Contact> Contact_GetByTop(string Top, string Where, string Order)
       {
           List<Data.Contact> list = new List<Data.Contact>();
           Data.Contact obj = new Data.Contact();
           DbCommand cmd = db.GetStoredProcCommand("sp_Contact_GetByTop",Top,Where,Order);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.ContactIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();

           }
           return list;
       }
       #endregion
       #region[GetById]
       public List<Contact> Contact_GetById(string Id)
       {
           List<Data.Contact> list = new List<Data.Contact>();
           Data.Contact obj = new Data.Contact();
           DbCommand cmd = db.GetStoredProcCommand("sp_Contact_GetById",Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.ContactIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();

           }
           return list;
       }
       #endregion
       #region[Insert]
       public bool Contact_Insert(Contact data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Contact_Insert"))
           {
               cmd.Parameters.Add(new SqlParameter("@Name",data.Name));
               cmd.Parameters.Add(new SqlParameter("@Company", data.Company));
               cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
               cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
               cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
               cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
               cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
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
       public bool Contact_Update(Contact data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Contact_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Company", data.Company));
               cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
               cmd.Parameters.Add(new SqlParameter("@Tel", data.Tel));
               cmd.Parameters.Add(new SqlParameter("@Mail", data.Mail));
               cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
               cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
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
       public bool Contact_Delete(string Id)
       {
           DbCommand cmd = db.GetStoredProcCommand("sp_Contact_Delete",Id);
          
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
