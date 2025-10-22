using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Control.Default
{
    public partial class My_U_Nhom_Tin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void View()
        {
            string Chuoi="";
            List<Data.News> list = new List<Data.News>();
            list = Business.NewsService.News_GetByTop("20"," GroupNewsId= 29 and [Active]=1","[Date] desc");
           List<Data.GroupNews> listTennhomtin =new List<Data.GroupNews>();
            listTennhomtin=Business.GroupNewsService.News_GetName_GroupNews("'"+list[0].Tag+"'");
            for (int i = 0; i < list.Count; i++)
            {
                string contentshow=Common.StringClass.CatChuoi(list[i].Content,200);
                Chuoi+="<div class=\"head-item-right\"><p>"+listTennhomtin[0].Name+"<p> </div><div class=\"item-nhomtin\"> <table >";
                    Chuoi+="<tr> <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"\" style=\"padding:0px\"><img alt=\"\" src=\""+list[i].Image+"\" /></a></td><td class=\"tieude-item-nhomtin\"> <a href=\"\"> "+list[i].Name+" </a></td>";
                       Chuoi+="</tr><tr><td class=\"tomtat-item-nhomtin\" >"+contentshow+"</td></tr><tr>";
                       Chuoi += " <td align=\"right\"> <a href=\"\" style=\"color:Red;font-size:13px\">Chi tiết</a> <a href=\"\"><img src=\"../../Content/themes/base/images/icon-chitiet.jpg\" /></a> </td></tr> </table></div>";

            }
        }
    }
}