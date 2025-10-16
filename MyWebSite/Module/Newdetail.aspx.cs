using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.Module
{
    public partial class Newdetail : System.Web.UI.Page
    {
        static string TagNews = "";
        protected void Page_Load(object sender, EventArgs e)
        {
                
            if (Page.RouteData.Values["Hot"] != null)//tin nổi bật
            {
                TagNews = Page.RouteData.Values["Hot"].ToString();
            }
            if (!IsPostBack)
            {
                View();
            }

        }
        void View()
        {
            string Chuoi = "";
            List<Data.News> list = new List<Data.News>();
            list = Business.NewsService.News_GetByTop("1", "Tag='" + TagNews + "'", "");
            List<Data.GroupNews> NameNhomTin = new List<Data.GroupNews>();
            NameNhomTin = Business.GroupNewsService.News_GetName_GroupNews("'" + TagNews + "'");

            if (list.Count > 0)
            {
                List<Data.News> listNewsOther = new List<Data.News>();
                listNewsOther = Business.NewsService.News_GetByTop("10", "Active =1 and GroupNewsId=" + NameNhomTin[0].Id + " and Tag !='" + TagNews + "'", " [Date] desc");
                Chuoi += "<div class=\"head-item-right\">  <p>" + NameNhomTin[0].Name + "<p></div>";
                Chuoi += " <table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"background: #FFFFFF; padding: 10px 10px 10px 10px;\"><tr><td class=\"tddetail\" align=\"right\" colspan=\"2\"> " + list[0].Date + " </td></tr>";
                Chuoi += "<tr><td class=\"TitleDetail\" align=\"left\" style=\"padding-left: 8px; padding-bottom: 5px\" ><b>" + list[0].Name + "</b></td></tr>";
                Chuoi += "<tr><td align=\"left\"colspan=\"2\" style=\"padding-left: 4px; padding-right: 4px; font-family: Times New Roman; font-size: 12pt; font-weight: bold; color: #5f5f5f><div style=\"text-align: justify;\"><span style=\"color: rgb(0, 51, 102);font-size: 10pt;font-family: Arial;line-height: 15px;\">" + list[0].Content + " </span></div><td></tr>";
                Chuoi += "<tr style=\"padding-left: 4px; padding-right: 4px\"><td align=\"left\"colspan=\"2\" style=\"padding-left: 3px; padding-right: 3px\" >" + list[0].Detail + "</td></tr>";
                Chuoi += "<tr><td align=\"right\" colspan=\"2\" style=\"height: 1px; padding-right: 35px\"> <a style=\"color:#004F8B;font-family:Tahoma;font-size:9pt;font-weight:normal;text-decoration:none;\" href=\"javascript:history.go(-1)\" id=\"n_controls1_ctl00_n_Addcontrol1_ctl00_hpl_back\">[Quay lại]</a></td>";
                Chuoi += " </tr> <tr>   <td align=\"right\" style=\"height: 1px; padding-right: 10px\"> <img border=\"0\" src=\"/App_Themes/Default/images/printicon.gif\">&nbsp;<a href=\"javascript:window.print()\" style=\"font-size: 8pt; font-weight: normal; color: #FE9205; text-decoration: none\"><span style=\"font-family: Tahoma\">In trang</span></a>&nbsp;&nbsp;<img border=\"0\" src=\"/App_Themes/Default/images/top-1.gif\">&nbsp; <a href=\"#\" style=\"font-family: Tahoma; font-size: 8pt; font-weight: normal;color: #FF9900; text-decoration: none\">Đầu trang</a> </td>  </tr><tr style=\"height:  6px\">  <td> </td> </tr>  <tr></table>";
                Chuoi += "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"background: #FFFFFF ;padding-left: 10px;padding-right: 10px;\"> <tr>";
                Chuoi += "<td align=\"left\" style=\"padding-left: 8px; padding-bottom: 5px; font-family: Tahoma; font-size: 12px; font-weight: bold\" colspan=\"2\">  <b>Các tin cùng Chuyên mục</b> </td></tr> <tr style=\"height: 2px\"><td style=\"background: #0070b8\" colspan=\"2\"> </td></tr>";
                for (int i = 0; i < listNewsOther.Count; i++)
                {
                    Chuoi += "<tr><td valign=\"top\" align=\"left\" style=\"width: 8px; padding-top: 5px; padding-left: 3px; padding-right: 5px\"><img style=\"background: 0px\" src=\"/App_Themes/Default/images/nut_tinnoibat1.png\"> </td><td align=\"left\" style=\"padding-right: 4px\"><a href=\"" + listNewsOther[i].Tag + "\" class=\"newother\">" + listNewsOther[i].Name + "</a> <font style=\"font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma\">(" + listNewsOther[i].Date + ")</font></td></tr>";
                }
                Chuoi += "</table>";
            }
            list.Clear();
            list = null;
            ltviewNewsDetail.Text = Chuoi;

        }
    }
}