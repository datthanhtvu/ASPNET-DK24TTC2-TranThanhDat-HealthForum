using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite
{
    public partial class SearchResultNews : System.Web.UI.Page
    {
        string strSearch = "";
        string currentpage = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NameNews"] != null)
                {
                    strSearch = Session["NameNews"].ToString();
                }
                if (RouteData.Values["currentpage"] != null)
                {
                    currentpage = RouteData.Values["currentpage"].ToString();
                    BindDataNews(currentpage, "12", strSearch, "");
                }
                if (Session["NameNews"] == null)
                {
                    strSearch = txtkeyword.Text;

                }
                //đang lỗi  chưa chọn nhóm chuyên mục
                BindDataNews(currentpage, "12", strSearch, "");

            }

        }

        void showPageNews(string str_Search, string Where_GroupNewsId)
        {

            string chuoi = "";
            List<Data.News> listpage = new List<Data.News>();

            if (str_Search != "")
            {

                listpage = Business.NewsService.News_GetByTop("", " " + Where_GroupNewsId + " Name like N'%" + str_Search + "%' and [Active]=1", "[Date] desc");
                //lblheader.Text = listcate[0].Name;
            }
            else
            {
                listpage = Business.NewsService.News_GetByTop("12", "" + Where_GroupNewsId + " Name like N'%" + str_Search + "%' and [Active]=1", " Id desc");
                //lblheader.Text = "Sản phẩm";
            }
            chuoi += "<ul>";
            if (listpage.Count > 12)
            {
                if ((listpage.Count) % 12 == 0)
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a  class='li_first' href='SearchResultNews.aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='SearchResultNews.aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listpage.Count / 12); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='SearchResultNews.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='SearchResultNews.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='SearchResultNews.aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='SearchResultNews.aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='SearchResultNews.aspx/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='SearchResultNews.aspx/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (listpage.Count / 12) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='SearchResultNews.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='SearchResultNews.aspx/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listpage.Count / 12) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='SearchResultNews.aspx/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='SearchResultNews.aspx/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                //BindData(currentpage, "3");
            }
            else
            {
                string ChuoiNews = "";
                lbsearch.Text = "TIN TỨC:Kết quả với từ khóa'" + str_Search + "' - " + listpage.Count() + " kết quả";
                if (listpage.Count > 0)
                {

                    for (int i = 0; i < listpage.Count; i++)
                    {
                        string contentshow = Common.StringClass.CatChuoi(listpage[i].Content, 200);
                        ChuoiNews += "<div class=\"item-nhomtin\"> <table >";
                        ChuoiNews += "<tr > <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\" style=\"padding:0px\"><img alt=\"\" src=\"" + listpage[i].Image + "\" /></a></td><td class=\"tieude-item-nhomtin\"> <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\"> " + listpage[i].Name + " </a></td>";
                        ChuoiNews += " <td align=\"right\"> <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\" style=\"color:Red;font-size:13px\">Chi tiết</a> <a href=\"Tin-moi/" + listpage[i].Tag + ".htm\"><img src=\"../../Content/themes/base/images/icon-chitiet.jpg\" /></a> </td></tr> </table></div>";


                    }
                }

                listpage.Clear();
                listpage = null;

            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindDataNews(string currentpage, string pagesize, string str_Search, string Where_GroupNewsId)
        {
            List<Data.News> list = new List<Data.News>();

            if (str_Search != "")
            {

                list = Business.NewsService.News_Paging(currentpage, pagesize, "" + Where_GroupNewsId + "  Name like N'%" + str_Search + "%'  and [Active]=1", "");
            }
            else
            {

                list = Business.NewsService.News_Paging(currentpage, pagesize, "", " Id desc");
            }

            string ChuoiNews1 = "";
            lbsearch.Text = "TIN TỨC:Kết quả với từ khóa'" + str_Search + "' - " + list.Count() + " kết quả";
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    string nameshow = Common.StringClass.CatChuoi(list[i].Name, 110);
                    string contentshow = Common.StringClass.CatChuoi(list[i].Content, 200);
                    ChuoiNews1 += "<div class=\"item-nhomtin\"> <table >";
                    ChuoiNews1 += "<tr> <td rowspan=\"3\" class=\"img-nhomtin\" > <a href=\"Tin-moi/" + list[i].Tag + ".htm\" style=\"padding:0px\"><img alt=\"\" src=\"" + list[i].Image + "\" /></a></td><td> <a  style=\"font-size:15px;font-family:Arial; color:#003365;font-weight: bold;\" href=\"Tin-moi/" + list[i].Tag + ".htm\"> " + nameshow + " </a></td>";
                    ChuoiNews1 += "</tr> <tr><td class=\"tomtat-item-nhomtin\" >" + contentshow + "</td></tr> </table></div>";

                }
            }

            ltNews.Text = ChuoiNews1;
            list.Clear();
            list = null;
        }

        protected void rdGroupNews_CheckedChanged(object sender, EventArgs e)
        {
            //rdEnquiry.Checked = false;
            ddlNhomtin.Items.Clear();
            ddlNhomtin.Items.Add(new ListItem("--Tất cả--", ""));
            List<MyWebSite.Data.GroupNews> list = Business.GroupNewsService.GroupNews_GetByTop("", " left([Level],5)!=00040 ", " [Level], Ord, Id  ");
            for (int i = 0; i < list.Count; i++)
            {
                ddlNhomtin.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlNhomtin.DataBind();


        }

        protected void rdEnquiry_CheckedChanged(object sender, EventArgs e)
        {
            //rdGroupNews.Checked = false;
            ddlNhomtin.Items.Clear();
            List<Data.GroupNews> list = Business.GroupNewsService.GroupNews_GetByTop("50", "left([Level],5)=00040", "[Level],Id");
            ddlNhomtin.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[0].Name + " chung", list[0].Level), list[0].Id));
            for (int i = 1; i < list.Count; i++)
            {
                ddlNhomtin.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlNhomtin.DataBind();

        }
        //show Enquiry Resuilt
        void showpagEnquiry(string str_Search, string Where_GroupNewsId)
        {
            string chuoi = "";
            List<Data.Enquiry> listEn = new List<Data.Enquiry>();


            if (str_Search != "")
            {


                listEn = Business.EnquiryService.Enquiryt_GetByTop("", "" + Where_GroupNewsId + " NameEnquiry like N'%" + str_Search + "%' and [Active]=0 ", "[Date] Desc");
                //lblheader.Text = listcate[0].Name;
            }
            else
            {

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
                        chuoi += "<li><a  class='li_first' href='/Hoi-dap/.htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/.htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }
                    for (int i = 1; i <= (listEn.Count / 8); i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Hoi-dap/.htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Hoi-dap/.htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listEn.Count / 8) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/.htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/.htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }
                else
                {
                    if (Int32.Parse(currentpage) == 1)
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/.htm/page=1'>" + "Prev" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_first' href='/Hoi-dap/.htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                    }

                    for (int i = 1; i <= (listEn.Count / 8) + 1; i++)
                    {
                        if (i.ToString().Equals(currentpage))
                        {
                            chuoi += "<li><a class='selected tab' href='/Hoi-dap/.htm/page=" + i + "'>" + i + "</a></li>";
                        }
                        else
                        {
                            chuoi += "<li><a class='tab' href='/Hoi-dap/.htm/page=" + i + "'>" + i + "</a></li>";
                        }
                    }
                    if (Int32.Parse(currentpage) == ((listEn.Count / 8) + 1))
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/.htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
                    }
                    else
                    {
                        chuoi += "<li><a class='li_last' href='/Hoi-dap/.htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
                    }
                }

                //BindData(currentpage, "3");
            }
            else
            {
                string Chuoi = "";
                lbsearch.Text = "HỎI ĐÁP:Kết quả với từ khóa'" + str_Search + "' - " + listEn.Count() + " kết quả";
                if (listEn.Count > 0)
                {
                    List<Data.Comment> listcom = new List<Data.Comment>();

                    for (int i = 0; i < listEn.Count; i++)
                    {
                        string NameEnShow = Common.StringClass.CatChuoi(listEn[i].NameEnquiry, 130);
                        string ContentShow = Common.StringClass.CatChuoi(listEn[i].Detail, 320);
                        listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + listEn[i].Id + "", "");
                        Chuoi += " <div class=\"items-row\">";
                        Chuoi += "<h2 class=\"contentheading\"><a href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\">" + NameEnShow + "</a>";
                        Chuoi += " </h2><div class=\"article-tools\"> " + listEn[i].Date + " &nbsp &nbsp  Đã xem: " + listEn[i].NumberView + " lần&nbsp &nbsp " + listcom.Count() + " Bình luận </div>";
                        Chuoi += " <div class=\"article-content\">  <p style=\"text-align: justify;\"> <em>";
                        Chuoi += "<a href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\"><img width=\"200\" height=\"150\" src=\"" + listEn[i].Image + "\" alt=\"\" style=\"margin-right: 10px; float: left;/\"></a>" + ContentShow + "</em>";
                        Chuoi += "</p><div class=\"jcomments-links\"><a title=\"" + listEn[i].NameEnquiry + "\" href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\" class=\"readmore-link\">Đọc thêm...</a> <a class=\"comments-link\" href=\"/Hoi-dap-moi/" + listEn[i].Tag + ".htm\">Thêm bình luận mới</a> </div> </div></div>";
                    }
                    listEn.Clear();
                    listEn = null;
                    ltNews.Text = Chuoi;

                }


            }
            chuoi += "</ul>";
            ltrpaging.Text = chuoi;

        }
        void BindDataEnquiry(string currentpage, string pagesize, string str_Search, string Where_GroupNewsId)
        {
            List<Data.Enquiry> list = new List<Data.Enquiry>();

            List<Data.Comment> listcom = new List<Data.Comment>();
            if (str_Search != "")
            {

                list = Business.EnquiryService.Enquiry_Paging(currentpage, pagesize, " " + Where_GroupNewsId + " NameEnquiry like N'%" + str_Search + "%' and [Active]=0", "");

            }
            else
            {

                list = Business.EnquiryService.Enquiry_Paging(currentpage, pagesize, "", " Id desc");
            }

            string Chuoi1 = "";
            lbsearch.Text = "HỎI ĐÁP:Kết quả với từ khóa'" + str_Search + "' - " + list.Count() + " kết quả";
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    string NameEnShow = Common.StringClass.CatChuoi(list[i].NameEnquiry, 130);
                    string ContentShow = Common.StringClass.CatChuoi(list[i].Detail, 320);
                    listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + list[i].Id + "", "");
                    Chuoi1 += " <div class=\"items-row\">";
                    Chuoi1 += "<h2 class=\"contentheading\"><a href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\">" + NameEnShow + "</a>";
                    Chuoi1 += " </h2><div class=\"article-tools\"> " + list[i].Date + " &nbsp &nbsp  Đã xem: " + list[i].NumberView + " lần&nbsp &nbsp " + listcom.Count() + " Bình luận </div>";
                    Chuoi1 += " <div class=\"article-content\">  <p style=\"text-align: justify;\"> <em>";
                    Chuoi1 += "<a href=\"/Hoi-dap/" + list[i].Tag + ".htm\"><img width=\"200\" height=\"150\" src=\"" + list[i].Image + "\" alt=\"\" style=\"margin-right: 10px; float: left;/\"></a>" + ContentShow + "</em>";
                    Chuoi1 += "</p><div class=\"jcomments-links\"><a title=\"" + list[i].NameEnquiry + "\" href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\" class=\"readmore-link\">Đọc thêm...</a> <a class=\"comments-link\" href=\"/Hoi-dap-moi/" + list[i].Tag + ".htm\">Thêm bình luận mới</a> </div> </div></div>";
                }
            }

            ltNews.Text = Chuoi1;
            list.Clear();
            list = null;
        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {

            lbbaoloi.Visible = true;
            lbbaoloi.ForeColor = Color.Red;
            if (rdEnquiry.Checked == false && rdGroupNews.Checked == false)
            {
                lbbaoloi.Text = "Chọn chuyên mục Tin tức hoặc Hỏi đáp!";
            }

            else


                if (rdGroupNews.Checked == true)
                {
                    lbbaoloi.Visible = false;

                    if (txtkeyword.Text == "")
                    {
                        lbbaoloi.Visible = true;
                        lbbaoloi.Text = "Chưa nhập nội dung tìm kiếm!";
                        strSearch = "";
                    }
                    else

                        if (ddlNhomtin.SelectedValue == "")
                        {
                            strSearch = Common.StringClass.NameToLike(txtkeyword.Text);
                            BindDataNews(currentpage, "2", strSearch, "");
                            showPageNews(strSearch, "");
                        }
                        else
                        {
                            strSearch = Common.StringClass.NameToLike(txtkeyword.Text);
                            BindDataNews(currentpage, "2", strSearch, "GroupNewsId = " + ddlNhomtin.SelectedValue + " and");
                            showPageNews(strSearch, "GroupNewsId = " + ddlNhomtin.SelectedValue + " and");
                        }
                }
                else
                {
                    lbbaoloi.Visible = false;

                    if (txtkeyword.Text == "")
                    {
                        lbbaoloi.Visible = true;
                        lbbaoloi.Text = "Chưa nhập nội dung tìm kiếm!";
                        strSearch = "";
                    }
                    else

                        if (ddlNhomtin.SelectedValue == "")
                        {
                            strSearch = txtkeyword.Text;
                            BindDataEnquiry(currentpage, "8", strSearch, "");
                            showpagEnquiry(strSearch, ddlNhomtin.SelectedValue);
                        }
                        else
                        {
                            strSearch = txtkeyword.Text;
                            BindDataEnquiry(currentpage, "8", strSearch, "GroupNewsId = " + ddlNhomtin.SelectedValue + " and");
                            showpagEnquiry(strSearch, "GroupNewsId = " + ddlNhomtin.SelectedValue + " and");
                        }


                }

        }
    }
}