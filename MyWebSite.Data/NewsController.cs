using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace MyWebSite.Data
{
    public class NewsDAL:SqlDataProvider
    {
       
        #region[News_GetById]
        public List<News> News_GetById(string Id)
        {
            List<Data.News> list = new List<Data.News>();
            Data.News obj = new Data.News();
            DbCommand cmd = db.GetStoredProcCommand("sp_News_GetById", Id);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.NewsIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        //thống kê
        #region[News_ThongKe]
        public List<News> News_ThongKe(string Datefrom ,string Dateto)
        {
            List<Data.News> list = new List<Data.News>();
            Data.News obj = new Data.News();
            DbCommand cmd = db.GetStoredProcCommand("thongke", Datefrom, Dateto);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.NewsThongKeIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        #region[News_Get-NameUser]
        public List<News> News_User()
        {
            List<Data.News> list = new List<Data.News>();
            Data.News obj = new Data.News();
            DbCommand cmd = db.GetStoredProcCommand("sp_News_Get_UserName");
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.NewsIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion

        #region[News_GetByTop]
        public List<News> News_GetByTop(string Top, string Where, string Order)
        {
            List<Data.News> list = new List<Data.News>();
            Data.News obj = new Data.News();
            DbCommand cmd = db.GetStoredProcCommand("sp_News_GetByTop", Top, Where, Order);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.NewsIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }
        #endregion
        
        #region[News_Insert]
        public bool News_Insert(News data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_News_Insert"))
            {
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
                cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
                cmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
                cmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
                cmd.Parameters.Add(new SqlParameter("@Index", data.Index));
                cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                cmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId == "" || data.GroupNewsId == "0" ? DBNull.Value : (object)data.GroupNewsId));
                cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                cmd.Parameters.Add(new SqlParameter("@UserId", data.UserId));
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
        #region[News_Update]
        public bool News_Update(News data)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_News_Update"))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                cmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
                cmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                cmd.Parameters.Add(new SqlParameter("@Content", data.Content));
                cmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
                cmd.Parameters.Add(new SqlParameter("@Date", data.Date));
                cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
                cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
                cmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
                cmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
                cmd.Parameters.Add(new SqlParameter("@Index", data.Index));
                cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                cmd.Parameters.Add(new SqlParameter("@GroupNewsId", data.GroupNewsId == "" || data.GroupNewsId == "0" ? DBNull.Value : (object)data.GroupNewsId));
                cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                cmd.Parameters.Add(new SqlParameter("@UserId", data.UserId == "" || data.UserId == "0" ? DBNull.Value : (object)data.UserId));
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
        #region[News_Update_Click]
        public bool News_Update_Click(string Tag)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_News_Update_Click"))
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
        #region[News_Delete]
        public bool News_Delete(string Id)
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_News_Delete", Id);
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
        #region[News_Paging]
        public List<News> News_Paging(string CurentPage, string PageSize, string Where, string Order)
        {
            List<Data.News> list = new List<Data.News>();
            Data.News obj = new Data.News();
            DbCommand cmd = db.GetStoredProcCommand("sp_News_Paging", CurentPage, PageSize, Where, Order);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    list.Add(obj.NewsIDataReader(dr));
                }
                dr.Close();
                dr.Dispose();
            }
            return list;
        }

        #endregion
	}
    }

