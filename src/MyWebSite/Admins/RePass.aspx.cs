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
    public partial class RePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    txtUsername.Text = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("Logon.aspx");
                }
            }
        }
        protected void btnLogon_Click(object sender, EventArgs e)
        {
            string UId = txtUsername.Text;
            string PId = txtPassword.Text;
            List<Data.User> list = new List<Data.User>();
            list = UserService.User_Validate(UId, StringClass.Encrypt(PId));
            if (list.Count > 0)
            {
                if (txtPasswordNews.Text != txtPasswordNews2.Text)
                {
                    ltrError.Text = "Nhập lại mật khẩu không đúng đúng!";
                }
                else
                    if (txtPasswordNews.Text == txtPasswordNews2.Text &&txtPasswordNews.Text.Length<6)
                    {
                        ltrError.Text = "Độ dài mật khẩu phải >=6!";
                    }
                {
                    
                    UserService.User_ChangePass(txtUsername.Text,Common.StringClass.Encrypt(txtPasswordNews2.Text));
                   Common.WebMsgBox.Show ("Đổi mật khẩu thành công!");
                    Response.Redirect("Default.aspx");
                }
            }
          
            else
            {
                txtPassword.Text = "";
                txtPassword.Focus();
                ltrError.Text = "Mật khẩu cũ k đúng!";
            }
        }
    }
}