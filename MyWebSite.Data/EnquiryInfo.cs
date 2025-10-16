using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MyWebSite.Data
{
  public  class Enquiry
  {
      #region[Declare Variables]
      private string _Id;
      private string _Name;
      private string _GroupNewsId;
      private string _EMail;
      private string _Tag;
      private string _NameEnquiry;
      private string _Detail;
      private string _Content;
      private string _Image;
      private string _Date;
      private string _NumberView;
      private string _Active;

     
     
    
      #endregion
      #region[Public Properties]
      public string Id
      {
          get { return _Id; }
          set { _Id = value; }
      }
      public string Name
      {
          get { return _Name; }
          set { _Name = value; }
      }
      public string GroupNewsId
      {
          get { return _GroupNewsId; }
          set { _GroupNewsId = value; }
      }
      public string EMail
      {
          get { return _EMail; }
          set { _EMail = value; }
      }
      public string Tag
      {
          get { return _Tag; }
          set { _Tag = value; }
      }
      public string NameEnquiry
      {
          get { return _NameEnquiry; }
          set { _NameEnquiry = value; }
      }
      public string Detail
      {
          get { return _Detail; }
          set { _Detail = value; }
      }
      public string Content
      {
          get { return _Content; }
          set { _Content = value; }
      }
      public string Image
      {
          get { return _Image; }
          set { _Image = value; }
      }
      public string Date
      {
          get { return _Date; }
          set { _Date = value; }
      }
      public string NumberView
      {
          get { return _NumberView; }
          set { _NumberView = value; }
      }

      public string Active
      {
          get { return _Active; }
          set { _Active = value; }
      }
      
     
     
      
      #endregion
      #region[Enquiry IDaraReader]
      public Enquiry EnquiryIDataReader(IDataReader dr)
      {
          Data.Enquiry obj =new Data.Enquiry();
          obj.Id=(dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
          obj.GroupNewsId = (dr["GroupNewsId"] is DBNull) ? string.Empty : dr["GroupNewsId"].ToString();
          obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
          obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
          obj.EMail = (dr["EMail"] is DBNull) ? string.Empty : dr["EMail"].ToString();
          obj.NameEnquiry = (dr["NameEnquiry"] is DBNull) ? string.Empty : dr["NameEnquiry"].ToString();
          obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
          obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
          obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
          obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
          obj.NumberView = (dr["NumberView"] is DBNull) ? string.Empty : dr["NumberView"].ToString();
          obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
          return obj;
      }
      #endregion
  }
}
