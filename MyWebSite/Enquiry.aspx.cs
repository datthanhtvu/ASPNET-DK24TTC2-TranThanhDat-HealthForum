using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Common;
namespace MyWebSite
{
    public partial class Enquiry : System.Web.UI.Page
    {
        string Tagchuyenmuc="";
        string currentpage = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Hỏi đáp";
                if (RouteData.Values["Enquiry"].ToString() != null)
                {
                    Tagchuyenmuc = RouteData.Values["Enquiry"].ToString();
                }
                if (RouteData.Values["currentpage"] != null)
                {
                    currentpage = RouteData.Values["currentpage"].ToString();
                    BindData(currentpage, "8");
                }
                BindData(currentpage, "8");
                //show();
                show1();
            }
        }
        //void View()
        //{
            //string Chuoi = "";
            //List<Data.GroupNews> listgn = new List<Data.GroupNews>();
            //listgn = Business.GroupNewsService.GroupNews_GetByTop("1","Tag='"+Tagchuyenmuc+"'","");
            //List<Data.Enquiry> listEn = new List<Data.Enquiry>();
            //lbTenchuyenmuc.Text = listgn[0].Name;
            //listEn = Business.EnquiryService.Enquiryt_GetByTop("8", "[Active]=0 and GroupNewsId=" + listgn[0].Id + "", "[Date] Desc");
            //for (int i = 0; i < listEn.Count; i++)
            //{   
            //    string NameEnShow= Common.StringClass.CatChuoi(listEn[i].NameEnquiry,130);
            //    string ContentShow=Common.StringClass.CatChuoi(listEn[i].Detail,320);
          
            //    Chuoi += " <div class=\"items-row\">";
            //  Chuoi+="<h2 class=\"contentheading\"><a href=\"\">"+NameEnShow+"</a>";
            //  Chuoi+=" </h2><div class=\"article-tools\"> "+listEn[i].Date+" &nbsp &nbsp  Đã xem: "+listEn[i].NumberView+" lần&nbsp &nbsp 3 Bình luận </div>";
            //  Chuoi+=" <div class=\"article-content\">  <p style=\"text-align: justify;\"> <em>";
            //    Chuoi+="<img width=\"200\" height=\"150\" src=\""+listEn[i].Image+"\" alt=\"\" style=\"margin-right: 10px; float: left;\">"+ContentShow+"</em>";
            //    Chuoi+="</p><div class=\"jcomments-links\"><a title=\""+listEn[i].NameEnquiry+"\" href=\"\" class=\"readmore-link\">Đọc thêm...</a> <a class=\"comments-link\" href=\"\">Thêm bình luận mới</a> </div> </div></div>";
            //}
            //    listEn.Clear();
            //listEn = null;
            //ltrShowEn.Text = Chuoi;

        
    //}
        void show1()
        {
            string chuoi = "";
            List<Data.Enquiry> listEn = new List<Data.Enquiry>();
            List<Data.GroupNews> listgn = new List<Data.GroupNews>();
            
            if (Tagchuyenmuc != "")
            {

                listgn = Business.GroupNewsService.GroupNews_GetByTop("1", "Tag='" + Tagchuyenmuc + "'", "");
                lbTenchuyenmuc.Text = listgn[0].Name;
                listEn = Business.EnquiryService.Enquiryt_GetByTop("", "[Active]=1 and GroupNewsId=" + listgn[0].Id + "", "[Date] Desc");
                //lblheader.Text = listcate[0].Name;
            }
            else
            {
                lbTenchuyenmuc.Text = listgn[0].Name;
                listEn = Business.EnquiryService.Enquiryt_GetByTop("8", "", "[Date] Desc");
                //lblheader.Text = "Sản phẩm";
            }
            chuoi += "<ul>";
            if (listEn.Count > 8)
            {
                if ((listEn.Count) % 8 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listEn.Count / 8); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listEn.Count / 8) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (listEn.Count / 8) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listEn.Count / 8) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/" + Tagchuyenmuc + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                
            }
            else
            { 
                string Chuoi = "";
                if (listEn.Count > 0)
                {
                    List<Data.Comment> listcom = new List<Data.Comment>();
                    for (int i = 0; i < listEn.Count; i++)
                    {
                        string NameEnShow = Common.StringClass.CatChuoi(listEn[i].NameEnquiry, 130);
                        string ContentShow = Common.StringClass.CatChuoi(listEn[i].Detail, 320);

                        listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + listEn[i].Id + " and [Active]=1", "");
                        Chuoi += " <div class=\"items-row\">";
                        Chuoi += "<h2 class=\"contentheading\"><a href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\">" + NameEnShow + "</a>";
                        Chuoi += " </h2><div class=\"article-tools\"> " + listEn[i].Date + " &nbsp &nbsp  Đã xem: " + listEn[i].NumberView + " lần&nbsp &nbsp " + listcom.Count() + " Bình luận </div>";
                        Chuoi += " <div class=\"article-content\">  <p style=\"text-align: justify;\"> <em>";
                        Chuoi += "<a href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\"><img width=\"200\" height=\"150\" src=\"" + listEn[i].Image + "\" alt=\"\" style=\"margin-right: 10px; float: left;/\"></a>" + ContentShow + "</em>";
                        Chuoi += "</p><div class=\"jcomments-links\"><a title=\"" + listEn[i].NameEnquiry + "\" href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\" class=\"readmore-link\">Đọc thêm...</a> <a class=\"comments-link\" href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\">Thêm bình luận mới</a> </div> </div></div>";
                    }
                    listEn.Clear();
                    listEn = null;
                    ltrShowEn.Text = Chuoi;
                   
                }

               
            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindData(string currentpage, string pagesize)
        {   
            List<Data.Enquiry> list = new List<Data.Enquiry>();
            List<Data.GroupNews> listca = new List<Data.GroupNews>();
            List<Data.Comment> listcom = new List<Data.Comment>();
            if (Tagchuyenmuc != "")
            {
                listca = Business.GroupNewsService.GroupNews_GetByTop("1", " Tag='" + Tagchuyenmuc + "'", "");
                list = Business.EnquiryService.Enquiry_Paging(currentpage, pagesize, " GroupNewsId=" + listca[0].Id + " and [Active]=1", "");
               
            }
            else
            {
                listca = Business.GroupNewsService.GroupNews_GetByTop("1", "", " Id desc");
                list = Business.EnquiryService.Enquiry_Paging(currentpage, pagesize, "", " Id desc");
            }

            string Chuoi1 = "";
            if (list.Count > 0)
            {
                
                for (int i = 0; i < list.Count; i++)
                {
                    string NameEnShow = Common.StringClass.CatChuoi(list[i].NameEnquiry, 130);
                    string ContentShow = Common.StringClass.CatChuoi(list[i].Detail, 320);
                    listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + list[i].Id + " and [Active]=1", "");
                    Chuoi1 += " <div class=\"items-row\">";
                    Chuoi1 += "<h2 class=\"contentheading\"><a href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\">" + NameEnShow + "</a>";
                    Chuoi1 += " </h2><div class=\"article-tools\"> " + list[i].Date + " &nbsp &nbsp  Đã xem: " + list[i].NumberView + " lần&nbsp &nbsp "+listcom.Count()+" Bình luận </div>";
                    Chuoi1 += " <div class=\"article-content\">  <p style=\"text-align: justify;\"> <em>";
                    Chuoi1 += "<a href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\"><img width=\"200\" height=\"150\" src=\"" + list[i].Image + "\" alt=\"\" style=\"margin-right: 10px; float: left;/\"></a>" + ContentShow + "</em>";
                    Chuoi1 += "</p><div class=\"jcomments-links\"><a title=\"" + list[i].NameEnquiry + "\" href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\" class=\"readmore-link\">Đọc thêm...</a> <a class=\"comments-link\" href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\">Thêm bình luận mới</a> </div> </div></div>";
                }
            }
            listca.Clear();
            listca = null;
            ltrShowEn.Text = Chuoi1;
            list.Clear();
            list = null;
        }

    }
}