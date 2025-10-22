using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_TopIndex : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
                DateTime day1 = DateTime.Now;
                int day = DateTime.Now.Day;
                int dayI = ((int)day1.DayOfWeek);
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;

                dayI = dayI + 1;
                if (dayI != 1)
                {
                    lbtime.Text = "Thứ " + Convert.ToString(dayI) + ", ngày " + Convert.ToString(day) + "/" + Convert.ToString(month) + "/" + Convert.ToString(year);
                }
                else
                {
                    lbtime.Text = "chủ nhật" +  ", ngày " + Convert.ToString(day) + "/" + Convert.ToString(month) + "/" + Convert.ToString(year);
                }

               
        }

       

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Session["NameNews"] = txtkeyword.Text;
            Response.Redirect("/SearchResultNews.aspx");
        }

        protected void txtkeyword_Click(object sender, ImageClickEventArgs e)
        {
            txtkeyword.Text = "";
        }

        
    }
}