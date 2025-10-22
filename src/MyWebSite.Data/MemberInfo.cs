using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
   public class Member
   {
       #region[Declare Variable]
       private string _Id;
       private string _Name;
       private string _Email;
       private string _UserName;
       private string _PassWord;
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
       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }
       public string UserName
       {
           get { return _UserName; }
           set { _UserName = value; }
       }
       public string PassWord
       {
           get { return _PassWord; }
           set { _PassWord = value; }
       }
       public string Active
       {
           get { return _Active; }
           set { _Active = value; }
       }
       #endregion
       #region[Member IDatareader]
       public Member MemberIDataReader(IDataReader dr)
       {
           Data.Member obj = new Data.Member();
           obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
           obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
           obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();
           obj.UserName = (dr["UserName"] is DBNull) ? string.Empty : dr["UserName"].ToString();
           obj.PassWord = (dr["PassWord"] is DBNull) ? string.Empty : dr["PassWord"].ToString();
           obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
           return obj;
       }
       
       #endregion

   }
}
