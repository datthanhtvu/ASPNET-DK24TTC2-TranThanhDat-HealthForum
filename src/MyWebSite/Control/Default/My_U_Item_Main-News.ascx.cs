using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
namespace MyWebSite.Control.Default
{
    public partial class My_U_Item_Main_News : System.Web.UI.UserControl
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
            List<Data.GroupNews> list = new List<Data.GroupNews>();
            list = Business.GroupNewsService.GroupNews_GetByTop("8","Active=1"," Position asc");
            
            for(int i=0;i<list.Count;i++)
            {  string strmargin="";
                if(i % 2==0)
                {
                    strmargin = "margin-left:0px;";
                }
                if (i % 2 != 0)
                {
                    strmargin = "margin-left:30px;";
                }
                List<Data.News> listtindau = new List<Data.News>();
                listtindau = Business.NewsService.News_GetByTop("1","[Active] =1 and GroupNewsId="+list[i].Id+"","[Date] desc");
                List<Data.News> listtinlienquan = new List<Data.News>();
                listtinlienquan = Business.NewsService.News_GetByTop("6","[Active]=1 and GroupNewsId="+list[i].Id+"" ,"[Date] desc");
                Chuoi += "<div  class=\"item-news-index\" style=\"" + strmargin + " \"> ";
                 Chuoi +="<div class=\"head-main-news\">";
                 Chuoi += "<a href=\"Tin-tuc/" + list[i].Tag + ".htm\" Title=\""+list[i].Name+"\"  style=\"position:absolute;bottom:12px;left:20px;\"> <span style=\"color:#fff;font-size:13px;font-weight:bold;\" >" + list[i].Name + "</span></a>";

                   Chuoi +="</div>";
                   for (int j = 0; j < listtindau.Count; j++)
                   {
                       string nameshow = Common.StringClass.CatChuoi(listtindau[0].Name, 100);//tên tin

                       string contentshow = Common.StringClass.CatChuoi(listtindau[0].Content, 100);
                       Chuoi += "<div class=\"content-item-main-news\" >";
                       Chuoi += "<div class=\"img-main-news\"><a href=\"Tin-moi/"+listtindau[0].Tag+".htm\" Title=\""+listtindau[0].Name+"\">";
                       Chuoi += " <img src=\" " + listtindau[j].Image + "\" />";
                       Chuoi += "</a></div>";
                       Chuoi += "<div class=\"tieudetin\">";
                       Chuoi += "<a href=\"Tin-moi/" + listtindau[0].Tag + ".htm\" style=\"font-size:14px;font-weight:bold;color:#006db2;\">" + nameshow + " </a>";
                       Chuoi += "<p style=\" width:235px;  padding:0px; margin-top:5px;font-size:14px; font-family:Times New Roman; color: #013368;height: 47px; line-height: 16px;overflow: hidden;  text-align: justify; \">" + contentshow + " </p>";
                       Chuoi += "</div>";
                       Chuoi += "<div id=\"chitiet\"> <a href=\"Tin-moi/" + listtindau[0].Tag + ".htm\" style=\"color:Red;font-size:12px;\"> Chi tiết</a></div>";
                      
                       Chuoi += "<div class=\"tinlienquan\">";
                       Chuoi += "<table>";
                       //
                       for (int k = 1; k < listtinlienquan.Count; k++)
                       {
                           string nametinlienquan = Common.StringClass.CatChuoi(listtinlienquan[k].Name, 50);
                           Chuoi += "<tr>";
                           Chuoi += "<td> <img src=\"../../Content/themes/base/images/nut_tinnoibat1.png\"/> <a  href=\"Tin-moi/" + listtinlienquan[k].Tag + ".htm\"> " + nametinlienquan + "</a> </td>";
                           Chuoi += "</tr>";



                       }

                       Chuoi += "</table>";
                       Chuoi += "</div>";
                       Chuoi += "</div>";
                   }
             Chuoi +=" </div>";
                
            }
            list.Clear();
            list = null;
            ltView.Text=Chuoi;
        }
    }
}