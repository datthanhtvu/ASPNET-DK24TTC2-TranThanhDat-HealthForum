using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
 public   class Link
    {
        #region[Declare Variables]
        private string _Id;
        private string _Name;
        private string _Link;
        private string _Type;
        private string _Ord;
        private string _Lang;
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
        public string Link1
        {
            get { return _Link; }
            set { _Link = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Ord
        {
            get { return _Ord; }
            set { _Ord = value; }
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
        #region[Link IDataReader]
        public Link LinkIDataReader(IDataReader dr)
        {
            Data.Link obj = new Data.Link();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Link1 = (dr["Link1"] is DBNull) ? string.Empty : dr["Link1"].ToString();
            obj.Type = (dr["Type"] is DBNull) ? string.Empty : dr["Type"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            return obj;

        
        }
        
        #endregion
    }
}
