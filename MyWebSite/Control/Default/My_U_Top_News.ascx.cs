using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
namespace MyWebSite.Control.Default
{
    public partial class My_U_Top_News : System.Web.UI.UserControl
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

            list = Business.NewsService.News_GetByTop("4", " [Active] = 1", " [Date] desc, Id desc");
            for (int i = 0; i < list.Count; i++)
            {

                string nameshow = Common.StringClass.CatChuoi(list[i].Name,40);
                 string contentshow = Common.StringClass.CatChuoi(list[i].Content, 85);
             
                              Chuoi+="<div class=\"item-top-news\">";
             Chuoi += " <table style=\"width:100%; \">";
                        Chuoi+="<tr><td  style=\"width:5px; padding-left:1px; padding-top: 2px ;\"><img src=\"../../Content/themes/base/images/ico_new.gif\"></td>";
                        Chuoi += "<td  style=\" padding-top: 1px; padding-left: 5px;\"><a id=\"titeltopnews\" href=\"Tin-noi-bat/" + list[i].Tag + ".htm\" alt=\"" + list[i].Title + "\" title=\"" + list[i].Name + "\">" + nameshow + "</a></td>";
                        Chuoi+="</tr>";
                    Chuoi+="</table>";

                 Chuoi+="<div class=\"img-top-new\">";
                           Chuoi+="<a href=\"Tin-noi-bat/" + list[i].Tag + ".htm\" Title=\""+list[i].Name+"\">";
                                   Chuoi+=" <img  alt=\"\"src=\""+list[i].Image+"\" />";
                           Chuoi+="</a>";
                 Chuoi+="</div>";
                 Chuoi+="<div class=\"tomtat\">"+contentshow+" </div>";
               Chuoi += "</div>";

             }
               
            list.Clear();
            list = null;
          
            ltView.Text = Chuoi;
     
        }
    }
}