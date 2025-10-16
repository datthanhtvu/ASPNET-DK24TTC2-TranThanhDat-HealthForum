using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWebSite.Data
{
  public  class User
    { 
        #region[Declare Variables  ]
        private string _Id;
        private string _RuleId;
            
        private string _Name;
        private string _Username;
        private string _Password;
        private string _Level;
        private string _Admin;
        private string _Ord;
        private string _Active;
   
        #endregion
        #region[ Public  Properties ]
        public string Id       { get { return _Id;      } set { _Id = value; } }
        public string RuleId      {
            get { return _RuleId; }
            set { _RuleId = value; }
        }
      
        public string Name     { get { return _Name;    } set { _Name = value; } }
        public string Username { get { return _Username;} set { _Username = value; } }
        public string Password { get { return _Password;} set { _Password = value; } }
        public string Level { get { return _Level; } set { _Level = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Admin {  get { return _Admin; }  set { _Admin = value; }  }
        public string Active { get { return _Active; } set { _Active = value; } }

        #endregion
        #region[User IDataReader]
        public User UserIDataReader(IDataReader dr)
        {
            Data.User obj = new Data.User();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.RuleId = (dr["RuleId"] is DBNull) ? string.Empty : dr["RuleId"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Username = (dr["UserName"] is DBNull) ? string.Empty : dr["Username"].ToString();
            obj.Password = (dr["Password"] is DBNull) ? string.Empty : dr["Password"].ToString();
            obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Admin = (dr["Admin"] is DBNull) ? string.Empty : dr["Admin"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
          
            return obj;
        }
#endregion


    }
}
