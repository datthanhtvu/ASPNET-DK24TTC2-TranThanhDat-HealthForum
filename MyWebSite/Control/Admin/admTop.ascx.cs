using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
using System.Web.Security;
namespace MyWebSite.Control.Admin
{
    public partial class admTop : System.Web.UI.UserControl
    {
        public static CookieClass Cookie = new CookieClass();
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Global.GetLang();
            if (!IsPostBack){
               
                          
                
                
            }
        }

          

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["FullName"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["IsAdmin"] = string.Empty;
            Session.Abandon();
            FormsAuthentication.SetAuthCookie(string.Empty, false);
            Response.Redirect("/");

        }
    }
}