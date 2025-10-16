using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;

namespace MyWebSite.Control.Admin
{
    public partial class admLeft : System.Web.UI.UserControl
    {
        string admin = "0";
        //private const string default_path_file = "/Admins/Default.aspx";  
        private const string default_path_file = "/Admins/Default.aspx";  
        public string LastLoadedPage
        {
            get {  return ViewState["LastLoaded"] as string; }
            set { ViewState["LastLoaded"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LastLoadedPage = default_path_file;
                //if (Session["IsAdmin"].ToString() == "3" )
                //{
                //    lbtGroupNews.Visible = false;
                //    div1.Visible = false;
                //}
                //if (Session["IsAdmin"].ToString() == "2")
                //{
                //    lbtConfig.Visible = false;
                //    lbtGroupNews.Visible = false;
                //    lbtPage.Visible = false;
                //    lbtUser.Visible = false;

                //}
                
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            string strPage = lbt.ID.Replace("lbt", "/Admins/") + ".aspx";
            if (System.IO.File.Exists(GlobalClass.PhysicalApplicationPath(LastLoadedPage)))
            {
                LastLoadedPage = strPage;
            }
            Panel currentPanel = (Panel)lbt.Parent;
            Session["currentPanel"] = currentPanel.ID;
            if (Session["IsAdmin"].ToString() == "3")
            {
                if (LastLoadedPage == "/Admins/GroupNews.aspx" || LastLoadedPage == "/Admins/User.aspx" || LastLoadedPage == "/Admins/Page.aspx" || LastLoadedPage == "/Admins/Advertise.aspx" || LastLoadedPage == "/Admins/Contact.aspx")
                {
                    WebMsgBox.Show("Bạn không đủ quyền hạn để thực hiện chức năng này");
                }
                else
                {
                    Response.Redirect(LastLoadedPage);
                }
            }
            if (Session["IsAdmin"].ToString() == "2")
            {
                if (LastLoadedPage == "/Admins/User.aspx" || LastLoadedPage == "/Admins/Advertise.aspx" || LastLoadedPage == "/Admins/Contact.aspx")
                {
                    WebMsgBox.Show("Bạn không đủ quyền hạn để thực hiện chức năng này");
                }
                else
                {
                    Response.Redirect(LastLoadedPage);
                }
            }
            if (Session["IsAdmin"].ToString() == "1")
            {
                Response.Redirect(LastLoadedPage);
            }
        }
    }
}