using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite
{
    public partial class Contact : System.Web.UI.Page
    {
        private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lang = Global.GetLang();
            //Literal ltrNav = (Literal)Common.PageHelper.FindControl(this.Master, "ltrNavContent");
            ltrContact.Text = Common.GlobalClass.Contact;
            //ltrNav.Text = "Liên hệ";
            Page.Title = "Liên hệ";
        }

        protected void btnContact_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblResult.Visible = true;
                lblResult.ForeColor = Color.Red;
                Data.Contact obj = new Data.Contact();
                obj.Name = txtName.Text;
                if (txtCompany.Text == "")
                {
                    obj.Company = "";
                }
                if (txtCompany.Text != "")
                {
                    obj.Company = txtCompany.Text;
                }
                if (!recaptcha.IsValid)
                {
                    lblResult.Text = "Mã bảo vệ không đúng!";
                    //Download source code FREE tai Sharecode.vn
                }
                else
                {
                    obj.Address = txtAddress.Text;
                    obj.Tel = txtTel.Text;
                    obj.Mail = txtMail.Text;
                    obj.Detail = txtcontents.Text;
                    obj.Date = Common.DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                    obj.Active = "1";
                    obj.Lang = "vi";
                    Business.ContactService.Contact_Insert(obj);
                    Common.ControlClass.ResetControlValues(this);
                    lblResult.Text = "Thông tin đã được gửi!";
                }
            }
        }
    }
}