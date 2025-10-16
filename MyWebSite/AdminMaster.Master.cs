using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Data;
using MyWebSite.Business;
using MyWebSite.Common;

namespace MyWebSite
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                

                    Session["FullName"] = Session["FullName"].ToString();
                    Session["UserName"] = Session["UserName"].ToString();
                    Session["IsAdmin"] = Session["IsAdmin"];
                    Session["UserId"]  = Session["UserId"];
                    
                
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            int i = 1;
            string JavaScript = "";
            while (i <= 10)
            {
                if (Session["currentPanel"] != null && Session["currentPanel"].ToString() == "div" + i)
                {
                }
                else
                {
                    JavaScript = JavaScript + "<script type=\"text/javascript\"> toggleXPMenu('div" + i + "'); </script>";
                }
                i++;
            }
            //ltrJavaScript.Text = JavaScript;
        }
    }
}