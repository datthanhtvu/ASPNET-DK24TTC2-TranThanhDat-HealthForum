using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
namespace MyWebSite.Control.Default
{
    public partial class My_U_Top3_News : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                View();
            }
        }
        void View()
        {
            string Chuoi = "";
            List<Data.News> list = new List<Data.News>();
            list = Business.NewsService.News_GetByTop("9","Active =1","[Date] desc");
            for (int i = 6; i < list.Count; i++)
            {
                string nameshow = Common.StringClass.CatChuoi(list[i].Name,60);
                Chuoi+="<td><div class=\"item-top3-news\"><div class=\"img-top3-news\">";
                Chuoi += "<a href=\"Tin-moi/" + list[i].Tag + ".htm\">  <img  alt=\"\" src=\"" + list[i].Image + "\" /> </a>";
                             Chuoi+="</div>";
                             Chuoi += "<a href=\"Tin-moi/" + list[i].Tag + ".htm\"><p >" + nameshow + "</p></a></div></td>";
            }
            list.Clear();
            list = null;
            ltView.Text = Chuoi;
        }
    }
}