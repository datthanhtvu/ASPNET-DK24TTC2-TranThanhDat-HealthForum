using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite.Data
{
  public  class News{
    
    //    #region[Declare varibles]
    //  private string _Id;
    //  private string _Name;
    //  private string _GroupNewsId;
    //  private string _Tag;
    //  private string _Title;
    //  private string _Content;
    //  private string _Image;
    //  private string _Description;
    //  private string _KeyWord;
    //  private string _Detail;
    //  private string _Date;
    //  private string _Index;
    //  private string _Priority;
    //  private string _Active;
    //  private string _Lang;
    //     #endregion
    //    #region[Public Properties]
    //  public string Id { get { return _Id; } set { _Id = value; } }
    //  public string Name { get { return _Name; } set { _Name = value; } }
    //  public string GroupNewsId { get { return _GroupNewsId; } set { _GroupNewsId = value; } }
    //  public string Tag { get { return _Tag; } set { _Tag = value; } }
    //  public string Title { get { return _Title; } set { _Title = value; } }
    //  public string Content { get { return _Content; } set { _Content = value; } }
    //  public string Image { get { return _Image; } set { _Image = value; } }
    //  public string Description { get { return _Description; } set { _Description = value; } }
    //  public string KeyWord { get { return _KeyWord; } set { _KeyWord = value; } }
    //  public string Detail { get { return _Detail; } set { _Detail = value; } }
    //  public string Date { get { return _Date; } set { _Date = value; } }
    //  public string Index { get { return _Index; } set { _Index = value; } }
    //  public string Priority { get { return _Priority; } set { _Priority = value; } }
    //  public string Active { get { return _Active; } set { _Active = value; } }
    //  public string Lang { get { return _Lang; } set { _Lang = value; } }
    //    #endregion
    //    #region[News IDataReader]
    //  public News NewsIDataReader(IDataReader dr)
    //  {
    //      Data.News obj = new Data.News();
    //      obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
    //      obj.Id = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
    //      obj.Id = (dr["GroupNewsId"] is DBNull) ? string.Empty : dr["GroupNewsId"].ToString();
    //      obj.Id = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
    //      obj.Id = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
    //      obj.Id = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
    //      obj.Id = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
    //      obj.Id = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
    //      obj.Id = (dr["KeyWord"] is DBNull) ? string.Empty : dr["KeyWord"].ToString();
    //      obj.Id = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
    //      obj.Id = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
    //      obj.Id = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();
    //      obj.Id = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();
    //      obj.Id = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
    //      obj.Id = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
    //      return obj;
      
    //  }

    //    #endregion
      
		#region[Declare variables]
		private string  _Id;
		private string  _Name;
		private string  _Tag;
		private string  _Image;
		private string  _Content;
		private string  _Detail;
		private string  _Date;
		private string  _Title;
		private string  _Description;
		private string  _Keyword;
		private string  _Priority;
		private string  _Index;
		private string  _Active;
		private string  _GroupNewsId;
		private string  _Lang;
        private string _UserId;
        private string _FullNameUser;//

        public string FullNameUser
        {
            get { return _FullNameUser; }
            set { _FullNameUser = value; }
        }
        private string _UserName;//

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Sobaidang;//

        public string Sobaidang//
        {
            get { return _Sobaidang; }
            set { _Sobaidang = value; }
        }
       
		#endregion
		#region[Public Properties]
		public string Id{ get { return _Id; } set { _Id = value; } }
		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Tag{ get { return _Tag; } set { _Tag = value; } }
		public string Image{ get { return _Image; } set { _Image = value; } }
		public string Content{ get { return _Content; } set { _Content = value; } }
		public string Detail{ get { return _Detail; } set { _Detail = value; } }
		public string Date{ get { return _Date; } set { _Date = value; } }
		public string Title{ get { return _Title; } set { _Title = value; } }
		public string Description{ get { return _Description; } set { _Description = value; } }
		public string Keyword{ get { return _Keyword; } set { _Keyword = value; } }
		public string Priority{ get { return _Priority; } set { _Priority = value; } }
		public string Index{ get { return _Index; } set { _Index = value; } }
		public string Active{ get { return _Active; } set { _Active = value; } }
		public string GroupNewsId{ get { return _GroupNewsId; } set { _GroupNewsId = value; } }
		public string Lang{ get { return _Lang; } set { _Lang = value; } }
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
		#endregion
		#region[News IDataReader]
		public News NewsIDataReader(IDataReader dr)
		{
			Data.News obj = new Data.News();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
			obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
			obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
			obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
			obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
			obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
			obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
			obj.Priority = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();
			obj.Index = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.GroupNewsId = (dr["GroupNewsId"] is DBNull) ? string.Empty : dr["GroupNewsId"].ToString();
			obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            obj.UserId = (dr["UserId"] is DBNull) ? string.Empty : dr["UserId"].ToString();
			return obj;
		}
        public News NewsThongKeIDataReader(IDataReader dr)
        {  Data.News obj = new Data.News();
           obj.Name=(dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
           obj.UserName = (dr["Username"] is DBNull) ? string.Empty : dr["Username"].ToString();
           obj.Sobaidang = (dr["Sobaidang"] is DBNull) ? string.Empty : dr["Sobaidang"].ToString();
           return obj;

        }
		#endregion



    }
}
