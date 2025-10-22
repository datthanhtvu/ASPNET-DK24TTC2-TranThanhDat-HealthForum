using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
   public class Comment
   {
       #region[Declare Variables ]
       private string _Id;
       private string _EnquiryId;
       private string _FullName;
       private string _Email;
       private string _Date;
       private string _Point;
       private string _Detail;
       private string _Active;
      
       #endregion

       #region[Public Properties]
       public string Id
       {
           get { return _Id; }
           set { _Id = value; }
       }
       public string EnquiryId
       {
           get { return _EnquiryId; }
           set { _EnquiryId = value; }
       }
       public string FullName
       {
           get { return _FullName; }
           set { _FullName = value; }
       }
       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }


       public string Date
       {
           get { return _Date; }
           set { _Date = value; }
       }


       public string Point
       {
           get { return _Point; }
           set { _Point = value; }
       }
       public string Detail
       {
           get { return _Detail; }
           set { _Detail = value; }
       }

       public string Active
       {
           get { return _Active; }
           set { _Active = value; }
       }
       #endregion
       #region[Comment IDataReader]
       public Comment CommentIDataReder(IDataReader dr)
       {
           Data.Comment obj = new Data.Comment();
           obj.Id =(dr["Id"] is DBNull)? string.Empty:dr["Id"].ToString();
           obj.EnquiryId = (dr["EnquiryId"] is DBNull) ? string.Empty : dr["EnquiryId"].ToString();
           obj.FullName =(dr["FullName"] is DBNull)? string.Empty:dr["FullName"].ToString();
           obj.Email =(dr["Email"] is DBNull)? string.Empty:dr["Email"].ToString();
           obj.Date =(dr["Date"] is DBNull)? string.Empty:dr["Date"].ToString();
           obj.Point = (dr["Point"] is DBNull) ? string.Empty : dr["Point"].ToString();
           obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
           obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
           return obj;

       
       }
       #endregion
   }
}
