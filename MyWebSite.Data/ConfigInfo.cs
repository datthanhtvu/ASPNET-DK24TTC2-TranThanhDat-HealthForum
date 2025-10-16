using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
   public class Config
   {
       #region[Declare Variables ]
       private string _Id;
       private string _Mail_Smtp;

       private string _Mail_Port;
       private string _Mail_Info;
       private string _Mail_Noreply;
       private string _Mail_Password;
       private string _PlaceBody;
       private string _GoogleId;
       private string _Contact;
       private string _DeliveryTerms;
       private string _PaymentTerms;
       private string _FreeShipping;
       private string _Coppyright;
       private string _Title;
       private string _Description;
       private string _Keyword;
       private string _Lang;
       private string _Helpsize;
       private string _Location;
       #endregion
       #region[Public Properties]
       public string Id
       {
           get { return _Id; }
           set { _Id = value; }
       }

       public string Mail_Smtp
       {
           get { return _Mail_Smtp; }
           set { _Mail_Smtp = value; }
       }
       public string Mail_Port
       {
           get { return _Mail_Port; }
           set { _Mail_Port = value; }
       }
       public string Mail_Info
       {
           get { return _Mail_Info; }
           set { _Mail_Info = value; }
       }
       public string Mail_Noreply
       {
           get { return _Mail_Noreply; }
           set { _Mail_Noreply = value; }
       }
       public string Mail_Password
       {
           get { return _Mail_Password; }
           set { _Mail_Password = value; }
       }
       public string PlaceBody
       {
           get { return _PlaceBody; }
           set { _PlaceBody = value; }
       }
       public string GoogleId
       {
           get { return _GoogleId; }
           set { _GoogleId = value; }
       }
       public string Contact
       {
           get { return _Contact; }
           set { _Contact = value; }
       }
       public string DeliveryTerms
       {
           get { return _DeliveryTerms; }
           set { _DeliveryTerms = value; }
       }
       public string PaymentTerms
       {
           get { return _PaymentTerms; }
           set { _PaymentTerms = value; }
       }
       public string FreeShipping
       {
           get { return _FreeShipping; }
           set { _FreeShipping = value; }
       }
       public string Coppyright
       {
           get { return _Coppyright; }
           set { _Coppyright = value; }
       }
       public string Title
       {
           get { return _Title; }
           set { _Title = value; }
       }
       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       public string Keyword
       {
           get { return _Keyword; }
           set { _Keyword = value; }
       }
       public string Lang
       {
           get { return _Lang; }
           set { _Lang = value; }
       }
        public string Helpsize
       {
           get { return _Helpsize; }
           set { _Helpsize = value; }
       }
       public string Location
       {
           get { return _Location; }
           set { _Location = value; }
       }
  
     
       #endregion
       #region[Config IDataReader]
       public Config ConfigIDataReader(IDataReader dr)
       {
           Data.Config obj = new Data.Config();
           obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
           obj.Mail_Smtp = (dr["Mail_Smtp"] is DBNull) ? string.Empty : dr["Mail_Smtp"].ToString();
           obj.Mail_Port = (dr["Mail_Port"] is DBNull) ? string.Empty : dr["Mail_Port"].ToString();
           obj.Mail_Info = (dr["Mail_Info"] is DBNull) ? string.Empty : dr["Mail_Info"].ToString();
           obj.Mail_Noreply = (dr["Mail_Noreply"] is DBNull) ? string.Empty : dr["Mail_Noreply"].ToString();
           obj.Mail_Password = (dr["Mail_Password"] is DBNull) ? string.Empty : dr["Mail_Password"].ToString();
           obj.PlaceBody = (dr["PlaceBody"] is DBNull) ? string.Empty : dr["PlaceBody"].ToString();
           obj.GoogleId = (dr["GoogleId"] is DBNull) ? string.Empty : dr["GoogleId"].ToString();
           obj.Contact = (dr["Contact"] is DBNull) ? string.Empty : dr["Contact"].ToString();
           obj.DeliveryTerms = (dr["DeliveryTerms"] is DBNull) ? string.Empty : dr["DeliveryTerms"].ToString();
           obj.PaymentTerms = (dr["PaymentTerms"] is DBNull) ? string.Empty : dr["PaymentTerms"].ToString();
           obj.FreeShipping = (dr["FreeShipping"] is DBNull) ? string.Empty : dr["FreeShipping"].ToString();
           obj.Coppyright = (dr["Coppyright"] is DBNull) ? string.Empty : dr["Coppyright"].ToString();
           obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
           obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
           obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
           obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
           obj.Helpsize = (dr["Helpsize"] is DBNull) ? string.Empty : dr["Helpsize"].ToString();
           obj.Location = (dr["Location"] is DBNull) ? string.Empty : dr["Location"].ToString();
           return obj;
       
       }
       #endregion
   }
}
