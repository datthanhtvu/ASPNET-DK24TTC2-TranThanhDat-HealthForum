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
  public  class CommentDAL:SqlDataProvider
  {
      #region[GetByTop]
      public List<Comment> Comment_GetByTop(string Top, string Where, string Order)
      {
          List<Data.Comment> list = new List<Data.Comment>();
          Data.Comment obj = new Data.Comment();
          DbCommand cmd = db.GetStoredProcCommand("sp_Comment_GetByTop",Top,Where,Order);
          using (IDataReader dr = db.ExecuteReader(cmd))
          {
              while (dr.Read())
              {
                  list.Add(obj.CommentIDataReder(dr));
              }
              dr.Close();
              dr.Dispose();
          }
          return list;
      }
      #endregion
      #region[GetById]
      public List<Comment> Comment_GetById(string Id)
      {
          List<Data.Comment> list = new List<Data.Comment>();
          Data.Comment obj = new Data.Comment();
          DbCommand cmd = db.GetStoredProcCommand("sp_Comment_GetById", Id);
          using (IDataReader dr = db.ExecuteReader(cmd))
          {
              while (dr.Read())
              {
                  list.Add(obj.CommentIDataReder(dr));
              }
              dr.Close();
              dr.Dispose();
          }
          return list;
      }
      #endregion
      #region[Insert]
      public bool Comment_Insert(Comment data)
      {
          using (DbCommand cmd = db.GetStoredProcCommand("sp_Comment_Insert"))
          {
              cmd.Parameters.Add(new SqlParameter("@EnquiryId", data.EnquiryId));
              cmd.Parameters.Add(new SqlParameter("@FullName", data.FullName));
              cmd.Parameters.Add(new SqlParameter("@Email", data.Email));
              cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
              cmd.Parameters.Add(new SqlParameter("@Point", data.Point));
              cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
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
      public bool Comment_Update(Comment data)
      {
          using (DbCommand cmd = db.GetStoredProcCommand("sp_Comment_Update"))
          {
              cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
              cmd.Parameters.Add(new SqlParameter("@EnquiryId", data.EnquiryId));
              cmd.Parameters.Add(new SqlParameter("@FullName", data.FullName));
              cmd.Parameters.Add(new SqlParameter("@Email", data.Email));
              cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
              cmd.Parameters.Add(new SqlParameter("@Point", data.Point));
              cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
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
      public bool Comment_Delete(string Id)
      {
          DbCommand cmd = db.GetStoredProcCommand("sp_Comment_Delete", Id);
         
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
      #region[Comment_Paging]
      public List<Comment> Comment_Paging(string CurentPage, string PageSize, string Where, string Order)
      {
          List<Data.Comment> list = new List<Data.Comment>();
          Data.Comment obj = new Data.Comment();
          DbCommand cmd = db.GetStoredProcCommand("sp_Comment_Paging", CurentPage, PageSize, Where, Order);
          using (IDataReader dr = db.ExecuteReader(cmd))
          {
              while (dr.Read())
              {
                  list.Add(obj.CommentIDataReder(dr));
              }
              dr.Close();
              dr.Dispose();
          }
          return list;
      }

      #endregion
  }
}
