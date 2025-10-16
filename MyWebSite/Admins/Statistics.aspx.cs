using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
using MyWebSite.Business;
namespace MyWebSite.Admins
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)  
        {
            //string DateFrom = "10-06-2013 11:51:55 PM";
            //string DateTo = "11-06-2013 11:51:55 PM";
            string DateFrom = txtDatefrom.Text+" 00:00:00 AM";
            string DateTo = txtDateTo.Text + " 00:00:00 PM";
            List<Data.News> listTK = NewsService.News_ThongKe(DateFrom, DateTo);
            Session["Thongke"] = listTK;
            Response.Redirect("Export.aspx");
        }
    }
}