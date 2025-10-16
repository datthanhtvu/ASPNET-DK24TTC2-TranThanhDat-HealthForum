using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Data;
using MyWebSite.Common;
using MyWebSite.Business;
using System.IO;
namespace MyWebSite.Admins
{
    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                view();
            }
        }
        void view()
        {
            
            grdCustomer.DataSource  = Session["Thongke"];
            grdCustomer.DataBind();
        }
      
        protected void lbt_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment; filename=Thongke"+DateTime.Now+".xls");
            StringWriter stringWriter = new StringWriter(); //System.IO namespace should be used
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            this.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistics.aspx");
        }
    }
}