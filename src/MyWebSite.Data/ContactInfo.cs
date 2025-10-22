using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
   public class Contact
   {
       #region[Declare Variables]
       private string _Id;
       private string _Name;
       private string _Company;
       private string _Address;
       private string _Tel;
       private string _Mail;
       private string _Detail;
       private string _Date;
       private string _Active;
       private string _Lang;
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
       public string Company
       {
           get { return _Company; }
           set { _Company = value; }
       }
       public string Address
       {
           get { return _Address; }
           set { _Address = value; }
       }
       public string Tel
       {
           get { return _Tel; }
           set { _Tel = value; }
       }
       public string Mail
       {
           get { return _Mail; }
           set { _Mail = value; }
       }
       public string Detail
       {
           get { return _Detail; }
           set { _Detail = value; }
       }
       public string Date
       {
           get { return _Date; }
           set { _Date = value; }
       }
       public string Active
       {
           get { return _Active; }
           set { _Active = value; }
       }
       public string Lang
       {
           get { return _Lang; }
           set { _Lang = value; }
       }
       #endregion
       #region[Contact IDataReader]
       public Contact ContactIDataReader(IDataReader dr)
       {
           Data.Contact obj = new Data.Contact();
           obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
           obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
           obj.Company = (dr["Company"] is DBNull) ? string.Empty : dr["Company"].ToString();
           obj.Address = (dr["Address"] is DBNull) ? string.Empty : dr["Address"].ToString();
           obj.Tel = (dr["Tel"] is DBNull) ? string.Empty : dr["Tel"].ToString();
           obj.Mail = (dr["Mail"] is DBNull) ? string.Empty : dr["Mail"].ToString();
           obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
           obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
           obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
           obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
           return obj;
       }
       #endregion
   }
}
