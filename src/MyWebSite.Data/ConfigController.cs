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
  public  class ConfigDAL:SqlDataProvider
  {
      #region[GetByTop]
      public List<Config> Config_GetByTop(string Top, string Where, string Order)
      {
          List<Data.Config> list = new List<Data.Config>();
          Data.Config obj = new Data.Config();
          DbCommand cmd = db.GetStoredProcCommand("sp_Config_GetByTop",Top,Where,Order);
          using (IDataReader dr = db.ExecuteReader(cmd))
          { 
           while(dr.Read())
              {
               list.Add(obj.ConfigIDataReader(dr));
              }
           dr.Close();
           dr.Dispose();
          }
          return list;
      }
      #endregion
      #region[GetById]
      public List<Config> Config_GetById(string Id)
      {
          List<Data.Config> list = new List<Data.Config>();
          Data.Config obj = new Data.Config();
          DbCommand cmd = db.GetStoredProcCommand("sp_Config_GetById", Id);
          using (IDataReader dr = db.ExecuteReader(cmd))
          {
              while (dr.Read())
              {
                  list.Add(obj.ConfigIDataReader(dr));
              }
              dr.Close();
              dr.Dispose();
          }
          return list;
      }
      #endregion
      #region[Insert]
      public bool Config_Insert(Config data)
      {
          using (DbCommand cmd = db.GetStoredProcCommand("sp_Config_Insert"))
          {
              cmd.Parameters.Add(new SqlParameter("@Mail_Smtp",data.Mail_Smtp));
              cmd.Parameters.Add(new SqlParameter("@Mail_Port", data.Mail_Port));
              cmd.Parameters.Add(new SqlParameter("@Mail_Info", data.Mail_Info));
              cmd.Parameters.Add(new SqlParameter("@Mail_Noreply", data.Mail_Noreply));
              cmd.Parameters.Add(new SqlParameter("@Mail_Password", data.Mail_Password));
              cmd.Parameters.Add(new SqlParameter("@PlaceBody", data.PlaceBody));
              cmd.Parameters.Add(new SqlParameter("@GoogleId", data.GoogleId));
              cmd.Parameters.Add(new SqlParameter("@Contact", data.Contact));
              cmd.Parameters.Add(new SqlParameter("@DeliveryTerms", data.DeliveryTerms));
              cmd.Parameters.Add(new SqlParameter("@PaymentTerms", data.PaymentTerms));
              cmd.Parameters.Add(new SqlParameter("@FreeShipping", data.FreeShipping));
              cmd.Parameters.Add(new SqlParameter("@Coppyright", data.Coppyright));
              cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
              cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
              cmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
              cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
              cmd.Parameters.Add(new SqlParameter("@Helpsize", data.Helpsize));
              cmd.Parameters.Add(new SqlParameter("@Location", data.Location));
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
      public bool Config_Update(Config data)
      {
          using (DbCommand cmd = db.GetStoredProcCommand("sp_Config_Update"))
          {
              cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
              cmd.Parameters.Add(new SqlParameter("@Mail_Smtp", data.Mail_Smtp));
              cmd.Parameters.Add(new SqlParameter("@Mail_Port", data.Mail_Port));
              cmd.Parameters.Add(new SqlParameter("@Mail_Info", data.Mail_Info));
              cmd.Parameters.Add(new SqlParameter("@Mail_Noreply", data.Mail_Noreply));
              cmd.Parameters.Add(new SqlParameter("@Mail_Password", data.Mail_Password));
              cmd.Parameters.Add(new SqlParameter("@PlaceBody", data.PlaceBody));
              cmd.Parameters.Add(new SqlParameter("@GoogleId", data.GoogleId));
              cmd.Parameters.Add(new SqlParameter("@Contact", data.Contact));
              cmd.Parameters.Add(new SqlParameter("@DeliveryTerms", data.DeliveryTerms));
              cmd.Parameters.Add(new SqlParameter("@PaymentTerms", data.PaymentTerms));
              cmd.Parameters.Add(new SqlParameter("@FreeShipping", data.FreeShipping));
              cmd.Parameters.Add(new SqlParameter("@Coppyright", data.Coppyright));
              cmd.Parameters.Add(new SqlParameter("@Title", data.Title));
              cmd.Parameters.Add(new SqlParameter("@Description", data.Description));
              cmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
              cmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
              cmd.Parameters.Add(new SqlParameter("@Helpsize", data.Helpsize));
              cmd.Parameters.Add(new SqlParameter("@Location", data.Location));
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
      public bool Config_Delete(string Id)
      {
          DbCommand cmd = db.GetStoredProcCommand("sp_Config_Delete",Id);
         
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
