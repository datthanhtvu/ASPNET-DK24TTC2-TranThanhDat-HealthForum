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
   public class MenuDAL:SqlDataProvider
   {
       #region[Menu_GetByTop]
       public List<Menu> Menu_GetByTop(string Top,string Where,string Order)
       {
           List<Data.Menu> list = new List<Menu>();
           Data.Menu obj = new Data.Menu();
          DbCommand cmd = db.GetStoredProcCommand("sp_Menu_GetByTop");
          db.AddInParameter(cmd, "@Top", DbType.String, Top);
          db.AddInParameter(cmd, "@Where", DbType.String, Where);
          db.AddInParameter(cmd, "@Order", DbType.String, Order);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.MenuIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;

       }
       #endregion
       #region[GetById]
       public List<Menu> Menu_GetById(string Id)
       {
           List<Data.Menu> list = new List<Data.Menu>();
           Data.Menu obj = new Data.Menu();
           DbCommand cmd = db.GetStoredProcCommand("sp_Menu_GetById",Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.MenuIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
                  
       }
       #endregion
       #region[Menu Insert]
       public bool Menu_Insert(Menu data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Menu_Insert"))
           {
               cmd.Parameters.Add(new SqlParameter("@Name",data.Name));
               cmd.Parameters.Add(new SqlParameter("@Tag",data.Tag));
               cmd.Parameters.Add(new SqlParameter("@Content",data.Content));
               cmd.Parameters.Add(new SqlParameter("@Detail",data.Detail));
               cmd.Parameters.Add(new SqlParameter ("@Level",data.Level));
               cmd.Parameters.Add(new SqlParameter("@Title",data.Title));
               cmd.Parameters.Add(new SqlParameter("@Type", data.Type));
               cmd.Parameters.Add(new SqlParameter("@Description",data.Description));
               cmd.Parameters.Add(new SqlParameter ("@KeyWord",data.KeyWord));
               cmd.Parameters.Add(new SqlParameter("@Index",data.Index));
               cmd.Parameters.Add(new SqlParameter("@Target",data.Target));
               cmd.Parameters.Add(new SqlParameter("@Position",data.Position));
               cmd.Parameters.Add(new SqlParameter ("@Ord",data.Ord));
               cmd.Parameters.Add(new SqlParameter ("@Link",data.Link));
               cmd.Parameters.Add(new SqlParameter("@Active",data.Active));
               cmd.Parameters.Add(new SqlParameter("@Lang",data.Lang));
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
       #region[Menu Update]
       public bool Menu_Update(Menu data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Menu_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
               cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
               cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
               cmd.Parameters.Add(new SqlParameter("@Level", data.Level));
               cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
               cmd.Parameters.Add(new SqlParameter("@Type", data.Type));
               cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
               cmd.Parameters.Add(new SqlParameter("@KeyWord", data.KeyWord));
               cmd.Parameters.Add(new SqlParameter("@Index", data.Index));
               cmd.Parameters.Add(new SqlParameter("@Target", data.Target));
               cmd.Parameters.Add(new SqlParameter("@Position", data.Position));
               cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
               cmd.Parameters.Add(new SqlParameter("@Link", data.Link));
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
       #region[Menu Delete]
       public bool Menu_Delete(string Id)
       {
           DbCommand cmd = db.GetStoredProcCommand("sp_Menu_Delete",Id);
          
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
    

}

