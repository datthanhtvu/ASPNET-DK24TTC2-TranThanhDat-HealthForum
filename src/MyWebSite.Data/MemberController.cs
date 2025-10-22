using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
namespace MyWebSite.Data
{
   public class MemberDAL:SqlDataProvider
   {
       #region[GetByTop]
       public List<Member> Member_GetByTop(string Top, string Where, string Order)
       {
           List<Data.Member> list = new List<Data.Member>();
           Data.Member obj = new Data.Member();
           DbCommand cmd = db.GetStoredProcCommand("sp_Member_GetByTop",Top,Where,Order);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.MemberIDataReader(dr));
               }
               dr.Close();
            dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[GetById]
       public List<Member> Member_GetById(string Id)
       {
           List<Data.Member> list = new List<Data.Member>();
           Data.Member obj = new Data.Member();
           DbCommand cmd = db.GetStoredProcCommand("sp_Member_GetById",Id);
           using (IDataReader dr = db.ExecuteReader(cmd))
           {
               while (dr.Read())
               {
                   list.Add(obj.MemberIDataReader(dr));
               }
               dr.Close();
               dr.Dispose();
           }
           return list;
       }
       #endregion
       #region[Insert]
       public bool Member_Insert(Member data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Member_Insert")) 
           {
               cmd.Parameters.Add(new SqlParameter("@Name",data.Name));
               cmd.Parameters.Add(new SqlParameter("@Email",data.Email));
               cmd.Parameters.Add(new SqlParameter("@UserName",data.UserName));
               cmd.Parameters.Add(new SqlParameter("@PassWord",data.PassWord));
               cmd.Parameters.Add(new SqlParameter("@Active",data.Active));
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
       #region[UpDate]
       public bool Member_Update(Member data)
       {
           using (DbCommand cmd = db.GetStoredProcCommand("sp_Member_Update"))
           {
               cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
               cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
               cmd.Parameters.Add(new SqlParameter("@Email", data.Email));
               cmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
               cmd.Parameters.Add(new SqlParameter("@PassWord", data.PassWord));
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
       public bool Member_Delete(string Id)
       {
        DbCommand cmd = db.GetStoredProcCommand("sp_Member_Delete",Id);
           
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

