using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
    public class Menu
    {
        #region[Declare Variables]
        private string _Id;
        private string _Name;
        private string _Tag;
        private string _Content;
        private string _Detail;
        private string _Level;
        private string _Title;
        private string _Type;
        private string _Sum;
        private string _Description;
        private string _KeyWord;
        private string _Index;
        private string _Target;
        private string _Position;
        private string _Ord;
        private string _Link;
                private string _Active;
        private string _Lang;
           #endregion
        #region[Pulic properties]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Tag { get { return _Tag; } set { _Tag = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        public string Level { get { return _Level; } set { _Level = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public string KeyWord { get{return _KeyWord;} set {_KeyWord=value;} }
        public string Index { get { return _Index; } set { _Index = value; } }
        public string Target { get { return _Target; } set { _Target = value; } }
        public string Position { get { return _Position; } set { _Position = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Link  { get { return _Link; }  set { _Link = value; }      }
        public string Active { get { return _Active; } set { _Active = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        #endregion
        #region[Menu IDataReader]

        public Menu MenuIDataReader(IDataReader dr)
        {
            Data.Menu obj = new Data.Menu();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
            obj.Content=(dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
            obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
            obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
            obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
            obj.Type = (dr["Type"] is DBNull) ? string.Empty : dr["Type"].ToString();
            obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
            obj.KeyWord = (dr["KeyWord"] is DBNull) ? string.Empty : dr["KeyWord"].ToString();
            obj.Index = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();
            obj.Target = (dr["Target"] is DBNull) ? string.Empty : dr["Target"].ToString();
            obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            return obj;
        
        }
        #endregion

    }
}
