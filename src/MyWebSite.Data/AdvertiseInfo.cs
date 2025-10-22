using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace MyWebSite.Data
{
   public class Advertise
    {
#region[Declare variables ]
        private string _Id;
        private string _Name;
        private string _Image;  
        private string _Link;
        private string _Target;
        private string _Position;
        private string _Content;
        private string _MenuID;
        private string _Click;
        private string _Ord;
        private string _Active;
        private string _Lang;
      
#endregion
#region [Public Properties]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Image  { get { return _Image; }  set { _Image = value; }     }
        public string Link { get{return _Link ;} set{_Link=value;} }
        public string Target { get { return _Target; } set { _Target = value; } }
        public string Position { get { return _Position; } set { _Position = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public string MenuID { get { return _MenuID; } set { _MenuID = value; } }
        public string Click { get { return _Click; } set { _Click = value; } }
        public string Ord { get { return _Ord; } set { _Ord = value; } }
        public string Active { get { return _Active; } set { _Active = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
            
#endregion
#region  [ Advertise IDataReader]
        public Advertise AdvertiseIDataReader(IDataReader dr)
        {
            Data.Advertise obj = new Data.Advertise();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
            obj.Target = (dr["Target"] is DBNull) ? string.Empty: dr["Target"].ToString();
            obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();
            obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
            obj.MenuID = (dr["MenuID"] is DBNull) ? string.Empty : dr["MenuID"].ToString();
            obj.Click = (dr["Click"] is DBNull) ? string.Empty : dr["Click"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            return obj;
         
        }
#endregion
    }
}
