using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MyWebSite.Data;
using MyWebSite.Business;
using MyWebSite.Common;

namespace MyWebSite.Admins
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogon_Click(object sender, EventArgs e)
        {
            string UId = txtUsername.Text;
            string PId = txtPassword.Text;
            List<Data.User> list = new List<Data.User>();
            list = UserService.User_Validate(UId, StringClass.Encrypt(PId));
            if (list.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(UId, false);
                Session["FullName"] = list[0].Name.Trim();
                Session["UserName"] = list[0].Username.Trim();
                Session["IsAdmin"] = list[0].RuleId;
                Session["UserId"] = list[0].Id;
                Response.Redirect("Default.aspx");
            }
          
            else
            {
                txtPassword.Text = "";
                txtPassword.Focus();
                ltrError.Text = "Đăng nhập không thành công!";
            }
        }
    }
}