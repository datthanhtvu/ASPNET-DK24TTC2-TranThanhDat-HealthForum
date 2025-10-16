using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite
{
    public partial class Category : System.Web.UI.Page
    {
        string TagNhomtin = "";
        string currentpage = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Hỏi đáp";
                if (RouteData.Values["Tag"] != null)
                {
                    TagNhomtin = RouteData.Values["Tag"].ToString();
                }
                if (RouteData.Values["currentpage"] != null)
                {
                    currentpage = RouteData.Values["currentpage"].ToString();
                    BindData(currentpage, "12");
                }
                BindData(currentpage, "12");
                show1();
            }
            //Download source code FREE tai Sharecode.vn
        }
        //void View()
        //{
        //    string Chuoi = "";
        //    List<Data.GroupNews> Nhomtin = new List<Data.GroupNews>();
        //    Nhomtin = Business.GroupNewsService.GroupNews_GetByTop("1"," Tag='"+TagNhomtin+"'","");
        //    List<Data.News> listNews = new List<Data.News>();
        //    listNews = Business.NewsService.News_GetByTop("20", "GroupNewsId=" + Nhomtin[0].Id + " and [Active]=1", "[Date] desc");
            
        //    //listTennhomtin = Business.GroupNewsService.News_GetName_GroupNews("'" + list[0].Tag + "'");
        //    Chuoi += " <div class=\"head-item-right\"><p>" + Nhomtin[0].Name + "<p> </div>";
        //    for (int i = 0; i < listNews.Count; i++)
        //    {
        //        string contentshow = Common.StringClass.CatChuoi(listNews[i].Content, 200);
        //        Chuoi += "<div class=\"item-nhomtin\"> <table >";
        //        Chuoi += "<tr> <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"Tin-moi/" + listNews[i].Tag + ".htm\" style=\"padding:0px\"><img alt=\"\" src=\"" + listNews[i].Image + "\" /></a></td><td class=\"tieude-item-nhomtin\"> <a href=\"Tin-moi/" + listNews[i].Tag + ".htm\"> " + listNews[i].Name + " </a></td>";
        //        Chuoi += "</tr><tr><td class=\"tomtat-item-nhomtin\" >" + contentshow + "</td></tr><tr>";
        //        Chuoi += " <td align=\"right\"> <a href=\"Tin-moi/" + listNews[i].Tag + ".htm\" style=\"color:Red;font-size:13px\">Chi tiết</a> <a href=\"Tin-moi/" + listNews[i].Tag + ".htm\"><img src=\"../../Content/themes/base/images/icon-chitiet.jpg\" /></a> </td></tr> </table></div>";

        //    }
        //    Nhomtin.Clear();
        //    Nhomtin = null;
        //    listNews.Clear();
        //    listNews = null;
        //    ltView.Text = Chuoi;
        //}
        void show1()
        {
            string chuoi = "";
            List<Data.News> listpage = new List<Data.News>();
            List<Data.GroupNews> listcate = new List<Data.GroupNews>();
            if (TagNhomtin != "")
            {
                listcate = Business.GroupNewsService.GroupNews_GetByTop("1", " Tag='" + TagNhomtin + "'", "");
                listpage = Business.NewsService.News_GetByTop("20", "GroupNewsId=" + listcate[0].Id + " and [Active]=1", "[Date] desc");
                //lblheader.Text = listcate[0].Name;
            }
            else
            {
                listpage = Business.NewsService.News_GetByTop("12", " ", " Id desc");
                //lblheader.Text = "Sản phẩm";
            }
            chuoi += "<ul>";
            if (listpage.Count > 12)
            {
                if ((listpage.Count) % 12 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/Tin-tuc/" + TagNhomtin + ".htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listpage.Count / 12); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/Tin-tuc/" + TagNhomtin + ".htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    //Download source code FREE tai Sharecode.vn
                    for (int i = 1; i <= (listpage.Count / 12) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Tin-tuc/" + TagNhomtin + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                //BindData(currentpage, "3");
            }
            else
            {
                string ChuoiNews = "";
                if (listpage.Count > 0)
                {
                    ChuoiNews += " <div class=\"head-item-right\"><p>" + listcate[0].Name + "<p> </div>";
                    for (int i = 0; i < listpage.Count; i++)
                    {


                        string contentshow = Common.StringClass.CatChuoi(listpage[i].Content, 200);
                        ChuoiNews += "<div class=\"item-nhomtin\"> <table >";
                        ChuoiNews += "<tr > <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"/Tin-moi/" + listpage[i].Tag + ".htm\" style=\"padding:0px\"><img alt=\"\" src=\"" + listpage[i].Image + "\" /></a></td><td class=\"tieude-item-nhomtin\"> <a href=\"/Tin-moi/" + listpage[i].Tag + ".htm\"> " + listpage[i].Name + " </a></td>";
                        ChuoiNews += " <td align=\"right\"> <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\" style=\"color:Red;font-size:13px\">Chi tiết</a> <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\"><img src=\"../../Content/themes/base/images/icon-chitiet.jpg\" /></a> </td></tr> </table></div>";

                        
                    }
                }
               
                listpage.Clear();
                listpage = null;
                listcate.Clear();
                listcate = null;
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindData(string currentpage, string pagesize)
        {
            List<Data.News> list = new List<Data.News>();
            List<Data.GroupNews> listca = new List<Data.GroupNews>();
            if (TagNhomtin != "")
            {
                listca = Business.GroupNewsService.GroupNews_GetByTop("1", " Tag='" + TagNhomtin + "'", "");
                list = Business.NewsService.News_Paging(currentpage, pagesize, " GroupNewsId=" + listca[0].Id + " and [Active]=1", "");
            }
            else
            {
                listca = Business.GroupNewsService.GroupNews_GetByTop("1", "", " Id desc");
                list = Business.NewsService.News_Paging(currentpage, pagesize, "", " Id desc");
            }
           
            string ChuoiNews1 = "";
            if (list.Count > 0)
            {
                ChuoiNews1 += " <div class=\"head-item-right\"><p>" + listca[0].Name + "<p> </div>";
                for (int i = 0; i < list.Count; i++)
                {
                    string nameshow = Common.StringClass.CatChuoi(list[i].Name, 110);
                    string contentshow = Common.StringClass.CatChuoi(list[i].Content, 200);
                    ChuoiNews1 += "<div class=\"item-nhomtin\"> <table >";
                    ChuoiNews1 += "<tr> <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"/Tin-moi/" + list[i].Tag + ".htm\" style=\"padding:0px\"><img alt=\"\" src=\"" + list[i].Image + "\" /></a></td><td> <a  style=\"font-size:15px;font-family:Arial; color:#003365;font-weight: bold;\" href=\"/Tin-moi/" + list[i].Tag + ".htm\"> " + nameshow + " </a></td>";
                    ChuoiNews1 += "</tr> <tr><td class=\"tomtat-item-nhomtin\" >" + contentshow+ "</td></tr> </table></div>";
                }
            }
            listca.Clear();
            listca = null;
            ltNews.Text = ChuoiNews1;
            list.Clear();
            list = null;
        }
    }
}