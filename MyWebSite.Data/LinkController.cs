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
   public class LinkDAL:SqlDataProvider
   {
       #region[GetByTop]
       public List<Link> Link_GetByTop(string Top, string Where, string Order)
       {
           List<Data.Link> list = new List<Data.Link>();
           Data.Link obj = new Data.Link();
           DbCommand cmd = db.GetStoredProcCommand("sp_Link_GetByTop", Top, Where, Order);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.LinkIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[GetById]
       public List<Link> Link_GetById(string Id)
       {
           List<Data.Link> list = new List<Data.Link>();
           Data.Link obj = new Data.Link();
           DbCommand cmd = db.GetStoredProcCommand("sp_Link_GetById",Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.LinkIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       
       }
       #endregion
       #region [Insert]
       public bool Link_Insert(Link data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Link_Insert"))
           {
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Link",data.Link1));
               cmd.Parameters.Add(new SqlParameter("@Type",data.Type));
               cmd.Parameters.Add(new SqlParameter ("@Ord",data.Ord));
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
       #region [Update]
       public bool Link_Update(Link data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Link_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id",data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Link", data.Link1));
               cmd.Parameters.Add(new SqlParameter("@Type", data.Type));
               cmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
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
       #region [Delete]
       public bool Link_Delete(string Id )
       {
           DbCommand cmd = db.GetStoredProcCommand("sp_Link_Delete",Id);
         
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

