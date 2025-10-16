using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
  public  class Language
    {
        #region[Declare Variables]
        private string _Id;
        private string _Name;
        private string _Folder;
        private string _Default;
        private string _Image;
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
        public string Folder
        {
            get { return _Folder; }
            set { _Folder = value; }
        }
        public string Default
        {
            get { return _Default; }
            set { _Default = value; }
        }
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        #endregion
        #region[Language IDataReader]
        public Language LanguageIDataReader(IDataReader dr)
        {
            Data.Language obj = new Data.Language();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Folder = (dr["Folder"] is DBNull) ? string.Empty : dr["Folder"].ToString();
            obj.Default = (dr["Default"] is DBNull) ? string.Empty : dr["Default"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion
    }
}
