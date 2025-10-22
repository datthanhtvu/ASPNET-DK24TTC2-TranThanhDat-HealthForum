using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MyWebSite
{
    public partial class EnquiryDetail : System.Web.UI.Page
    {
        static string TagEnquiry="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["DetailHoidap"] != null)
                {
                    TagEnquiry = Page.RouteData.Values["DetailHoidap"].ToString();
                 
                    View();
                    Business.EnquiryService.Enquiry_Update_Click(TagEnquiry);
                    //Download source code FREE tai Sharecode.vn
                }
            }
         
            ViewsComment();
            Page.Title = "Hỏi đáp/"+TagEnquiry+"";

        }


        private DataTable GetDataTable(string EnquiryId)//
        {
            
            List<Data.Comment> listcom = new List<Data.Comment>();
            listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + EnquiryId + " and [Active]=1", " [Date] asc");
           
            DataTable dtItems = new DataTable();

            DataColumn dcName = new DataColumn();
            dcName.ColumnName = "title";
            dcName.DataType = System.Type.GetType("System.String");
            dtItems.Columns.Add(dcName);
            //Download source code FREE tai Sharecode.vn
            DataRow row;
            if(listcom.Count>0)
            {
             for (int i = 0; i <listcom.Count; i++)
              {
             
                row = dtItems.NewRow();
                row["Title"] += "<span class=\"spdate\">Gửi bởi:&nbsp</span><span style=\"font-size:14px;font-weight:bold\">" + listcom[i].FullName + "</span> &nbsp" ;
                row["Title"] += "<span class=\"spdate\">" + listcom[i].Date + "</span> ";
                row["Title"] += "</br>";
                row["Title"] += "<span class=\"spdetail\">" + listcom[i].Detail + "</span> ";
                dtItems.Rows.Add(row); 
             }
          }
            listcom.Clear();
            listcom = null;
            return dtItems;
            
        }
        void View()
        {   
            string chuoiHTM="";
            if(TagEnquiry!="")
            {

            List<Data.Enquiry> listE = new List<Data.Enquiry>();
            listE = Business.EnquiryService.Enquiryt_GetByTop("", "Tag='" + TagEnquiry + "'", "");
            List<Data.GroupNews> listGr = new List<Data.GroupNews>();
            listGr = Business.GroupNewsService.GroupNews_GetByTop("","Id="+listE[0].GroupNewsId+"","");
            List<Data.Comment> listcom = new List<Data.Comment>();
            listcom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + listE[0].Id + " and Active=1", "");
            lbTenchuyenmuc.Text = listGr[0].Name;
            
             chuoiHTM += "<div class=\"items-row\">";
            chuoiHTM +="<h2 class=\"contentheading\">"+listE[0].NameEnquiry+" </h2>";
             chuoiHTM +="<div class=\"article-tools\">";
              chuoiHTM +=" "+listE[0].Date+"&nbsp &nbsp  Đã xem:"+listE[0].NumberView+"&nbsplần&nbsp &nbsp "+listcom.Count()+" Bình luận";
             chuoiHTM +="</div>";
             chuoiHTM +="<div class=\"article-content\">";
               chuoiHTM +=" <p style=\"text-align: justify;\">";
               chuoiHTM += " <em><img width=\"200\" height=\"150\" src=\"" + listE[0].Image + "\" alt=\"\" style=\"margin-right: 10px; float: left;/\">"+listE[0].Detail+"</em>";
               chuoiHTM+=" </p>";
               chuoiHTM+="</div>";
             chuoiHTM+="</div>";
         
             ltrDetail.Text = chuoiHTM;
          
             Page.Title = "Hỏi đáp/"+TagEnquiry+"";
             List<Data.Enquiry> listEOrther = Business.EnquiryService.Enquiryt_GetByTop("10", " Tag!='" + listE[0].Tag + "' and [Active]=1", "date desc");
              listE.Clear();
              listE=null;
                string chuoiEnquiryOrther="";
                if(listEOrther.Count>0)
                {
                    for(int i=0;i<listEOrther.Count;i++)
                    {
                    string NameShow=Common.StringClass.CatChuoi(listEOrther[i].NameEnquiry,200);
                    chuoiEnquiryOrther+="<table style=\" width:98%\">";
                    chuoiEnquiryOrther+="<tr>";
                    chuoiEnquiryOrther+="<td valign=\"top\" align=\"left\" style=\"width: 8px; padding-top: 5px; padding-left: 3px; padding-right: 5px\">";
                    chuoiEnquiryOrther+=" <img src=\"/App_Themes/Default/images/nut_tinnoibat1.png\"></td>";
                    chuoiEnquiryOrther+="<td align=\"left\" style=\"padding-right: 4px\">";
                    chuoiEnquiryOrther+="<a href=\"/Hoi-dap-moi/" + listEOrther[i].Tag + ".htm\" class=\"newother\">"+NameShow+"</a> <font style=\"font-weight: normal;font-size: 8pt; color: #2055c7; font-family: Tahoma\">("+listEOrther[i].Date+")</font>";
                    chuoiEnquiryOrther+="</td></tr></table>";
                    }
                    ltrEnquiryOther.Text = chuoiEnquiryOrther;
                    listEOrther.Clear();
                    listEOrther = null;
                }
            }
           
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Visible = true;
            List<Data.Enquiry> listE1 = new List<Data.Enquiry>();
            listE1 = Business.EnquiryService.Enquiryt_GetByTop("", "Tag='" + TagEnquiry + "'", "");
            if (txtfullname.Text == "")
            {
                
                lblResult.Text = "Bạn chưa nhập họ tênd!";
            }
            else
                if (txtemail.Text == "")
                {
                    lblResult.Text = "Bạn chưa nhập Email!";
                }
                else
                    if (Common.StringClass.IsValidEmail(txtemail.Text) == false)
                    {
                        lblResult.Text = "Email không hợp lệ!";
                    }
                    else
                        if(txtdetail.Text=="")
                        {
                            lblResult.Text = "Bạn chưa nhập nội dung!";
                        }
                        else

                        if (!recaptcha.IsValid)
                        {
                            
                            lblResult.Text = "Mã xác thực không đúng!";
                        }
                        else
                        {

                            Data.Comment obj = new Data.Comment();
                            obj.FullName = txtfullname.Text;
                            obj.Email = txtemail.Text;
                            obj.Date = Common.DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                            obj.EnquiryId = listE1[0].Id;
                            obj.Active = "0";
                            obj.Detail = txtdetail.Text;
                            obj.Point = "0";
                            Business.CommentService.Comment_Insert(obj);
                            Common.WebMsgBox.Show("Cảm ơn bạn đã gửi trả lời! Bình luận của bạn sẽ được đăng ngay sau khi chúng tôi kiểm duyệt!");
                            Common.ControlClass.ResetControlValues(this);
                        }
        }
        void ViewsComment()
        {
            List<Data.Enquiry> listE = new List<Data.Enquiry>();
            listE = Business.EnquiryService.Enquiryt_GetByTop("", "Tag='" + TagEnquiry + "'", "");
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = 6; // số items hiển thị trên một trang.
            CollectionPager1.DataSource = GetDataTable(listE[0].Id).DefaultView;
            CollectionPager1.BindToControl = lvDemo;
            lvDemo.DataSource = CollectionPager1.DataSourcePaged;
            lvDemo.DataBind();

        }
        //string show1(string EnquiyId, string TagEnquiry)
        //{
        //    string currentpage = "1";
        //    string chuoi = "";
        //    List<Data.Comment> listcom = new List<Data.Comment>();


        //    if (EnquiyId != "")
        //    {



        //        listcom = Business.CommentService.Comment_GetByTop("", "[Active]=0 and EnquiryId= " + EnquiyId + "", "[Date] Desc");
        //        //lblheader.Text = listcate[0].Name;
        //    }
        //    else
        //    {

        //        listcom = Business.CommentService.Comment_GetByTop("", "[Active]=0 and EnquiryId= " + EnquiyId + "", "[Date] Desc");
        //        //lblheader.Text = "Sản phẩm";
        //    }
        //    chuoi += "<ul>";
        //    if (listcom.Count > 6)
        //    {
        //        if ((listcom.Count) % 6 == 0)
        //        {
        //            if (Int32.Parse(currentpage) == 1)
        //            {
        //                chuoi += "<li><a  class='li_first' href='" + TagEnquiry + ".htm/page=1'>" + "Prev" + "</a></li>";
                    
        //            }
        //            else
        //            {
        //                chuoi += "<li><a class='li_first' href='" + TagEnquiry + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
                      
        //            }
        //            for (int i = 1; i <= (listcom.Count / 6); i++)
        //            {
        //                if (i.ToString().Equals(currentpage))
        //                {
        //                    chuoi += "<li><a class='selected tab' href='" + TagEnquiry + ".htm/page=" + i + "'>" + i + "</a></li>";
        //                }
        //                else
        //                {
        //                    chuoi += "<li><a class='tab' href='" + TagEnquiry + ".htm/page=" + i + "'>" + i + "</a></li>";
        //                }
        //            }
        //            if (Int32.Parse(currentpage) == ((listcom.Count / 6) + 1))
        //            {
        //                chuoi += "<li><a class='li_last' href='" + TagEnquiry + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
        //            }
        //            else
        //            {
        //                chuoi += "<li><a class='li_last' href='" + TagEnquiry + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
        //            }
        //        }
        //        else
        //        {
        //            if (Int32.Parse(currentpage) == 1)
        //            {
        //                chuoi += "<li><a class='li_first' href='" + TagEnquiry + ".htm/page=1'>" + "Prev" + "</a></li>";
        //            }
        //            else
        //            {
        //                chuoi += "<li><a class='li_first' href='" + TagEnquiry + ".htm/page=" + (Int32.Parse(currentpage) - 1).ToString() + "'>" + "Prev" + "</a></li>";
        //            }

        //            for (int i = 1; i <= (listcom.Count / 6) + 1; i++)
        //            {
        //                if (i.ToString().Equals(currentpage))
        //                {
        //                    chuoi += "<li><a class='selected tab' href='" + TagEnquiry + ".htm/page=" + i + "'>" + i + "</a></li>";
        //                }
        //                else
        //                {
        //                    chuoi += "<li><a class='tab' href='" + TagEnquiry + ".htm/page=" + i + "'>" + i + "</a></li>";
        //                }
        //            }
        //            if (Int32.Parse(currentpage) == ((listcom.Count / 6) + 1))
        //            {
        //                chuoi += "<li><a class='li_last' href='" + TagEnquiry + ".htm/page=" + currentpage + "'>" + "Next" + "</a></li>";
        //            }
        //            else
        //            {
        //                chuoi += "<li><a class='li_last' href='" + TagEnquiry + ".htm/page=" + (Int32.Parse(currentpage) + 1).ToString() + "'>" + "Next" + "</a></li>";
        //            }
        //        }

        //        //BindData(currentpage, "3");
        //    }
        //    else
        //    {
        //        string ChuoiHtmcom = "";
        //        if (listcom.Count > 0)
        //        {
        //            for (int i = 0; i < listcom.Count; i++)
        //            {
        //                ChuoiHtmcom += " <div class=\"comments\"  >";
        //                ChuoiHtmcom += "<span style=\"font-family:Arial;font-size:15px;font-weight:bold;\">" + listcom[i].FullName + "</span> <span style=\"font-size:13px;color:#808080\" >&nbsp" + listcom[i].Date + "</span> <br /> &nbsp&nbsp";
        //                ChuoiHtmcom += "  " + listcom[i].Detail + " </div>";
        //            }
        //            listcom.Clear();
        //            listcom = null;
        //            return ChuoiHtmcom;

        //        }


        //    }
        //    chuoi += "</ul>";
        //    return chuoi; ;

        //}
        //string ViewsComment(string currentpage, string pagesize, string EnquiryId)
        //{
        //    List<Data.Comment> listcom = new List<Data.Comment>();

        //    if (EnquiryId != "")
        //    {

        //        listcom = Business.CommentService.Comment_Paging(currentpage, pagesize, " EnquiryId=" + EnquiryId + " and [Active]=0", "");
        //    }
        //    else
        //    {
        //        listcom = Business.CommentService.Comment_Paging(currentpage, pagesize, "", " Id desc");
        //    }

        //    string ChuoiHtmcom = "";
        //    if (listcom.Count > 0)
        //    {

        //        for (int i = 0; i < listcom.Count; i++)
        //        {
        //            ChuoiHtmcom += " <div class=\"comments\"  >";
        //            ChuoiHtmcom += "<span style=\"font-family:Arial;font-size:15px;font-weight:bold;\">" + listcom[i].FullName + "</span> <span style=\"font-size:13px;color:#808080\" >&nbsp" + listcom[i].Date + "</span> <br /> &nbsp&nbsp";
        //            ChuoiHtmcom += "  " + listcom[i].Detail + " </div>";
        //        }
        //    }


        //    listcom.Clear();
        //    listcom = null;
        //    return ChuoiHtmcom;
        //}
    }
}