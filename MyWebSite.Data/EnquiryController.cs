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
    public class EnquiryDAL : SqlDataProvider
    {
        #region[Enquiry_Paging]
        public List<Enquiry> Enquiry_Paging(string CurentPage, string PageSize, string Where, string Order)
        {
            List<Data.Enquiry> list = new List<Data.Enquiry>();
            Data.Enquiry obj = new Data.Enquiry();
            DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_Paging", CurentPage, PageSize, Where, Order);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.EnquiryIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }

        #endregion
      #region[GetByTop]

        public List<Enquiry> Enquiry_GetByTop(string Top, string Where, string Order)
      {
          List<Data.Enquiry> list = new List<Data.Enquiry>();
          Data.Enquiry obj = new Data.Enquiry();
          DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_GetbyTop", Top, Where, Order);
          using (IDataReader dr = db.ExecuteReader(cmd))
          {
              while (dr.Read())
              {
                  list.Add(obj.EnquiryIDataReader(dr));
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
        public bool Enquiry_Insert(Enquiry data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_Insert"))
            {
                cmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@EMail", data.EMail));
                cmd.Parameters.Add(new SqlParameter("@NameEnquiry", data.NameEnquiry));
                cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@NumberView", data.NumberView));
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
        public bool Enquiry_Update(Enquiry data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_Update"))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@EMail", data.EMail));
                cmd.Parameters.Add(new SqlParameter("@NameEnquiry", data.NameEnquiry));
                cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@NumberView", data.NumberView));
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
        public bool Enquiry_Delete(string Id)
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_Delete", Id);

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
        #region[Enquiry_Update_Click]
        public bool Enquiry_Update_Click(string Tag)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_Enquiry_Update_Click"))
            {
                cmd.Parameters.Add(new SqlParameter("@Tag", Tag)); 
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
