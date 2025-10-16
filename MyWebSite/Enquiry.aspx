<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Enquiry.aspx.cs" Inherits="MyWebSite.Enquiry" %>

<%@ Register Src="Control/Default/My_U_Ky_Yeu.ascx" TagName="My_U_Ky_Yeu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:My_U_Ky_Yeu ID="My_U_Ky_Yeu1" runat="server" />
    <div class="nhomtin">
        <div class="head-item-right">
            <asp:Label ID="lbTenchuyenmuc" Text="" runat="server"></asp:Label><a class="uploadCauhoi" href="/Gui-cau-hoi/EnquiryUp.htm">Gửi câu hỏi </a></div>

        <%-- <div class="item-hoidap"  style="border-bottom:2px dotted #ff6a00;width:98%;margin-top:15px">
             <table >
                <tr> <td><img style="width:30px;height:30px;" alt="" src="Content/themes/base/images/icon-question.jpg" /></td><td colspan="2" ><a style="color:#26185f;font-size:16px;font-weight:bold;font-family:Tahoma;" href="" title=""> shdvbfhd hbvfdjhbv fhvbfdv fvbhf fhvbf fhbvf fhbf fhfb fhbf sdb fhbf fhbgf fhbf fvfhb fbgf fjbggh dfgd fbdf ffdh fdhg</a> </td></tr>
                 <tr><td  colspan="3"><span style="color:#3c3434 ;font-family:Tahoma;font-size:13px;padding-left:7px;text-align:justify;" > gái tôi hơn 11 tháng tuổi. Hàng ngày ngoài cho ăn 3 bữa, tôi cho cháu uống khoảng 500ml sữa, trong đó sữa mẹ được 400ml (khi đi làm tôi vắt sữa mang về nhà) và sữa ngoài 100ml. </span></td></tr>
                <tr><td></td><td align:left> <span style="font-size:13px;color:#808080;padding-left:10px">24/04/2013 </span> <span style="font-size:13px;color:#808080;padding-left:10px">Người gửi:</span><span style="font-size:14px;color:#050527;font-weight:bold;padding-left:10px">Nguyễn Thanh Tâm</span></td><td><span style="font-size:13px;color:#808080;padding-left:10px">0 trả lời</span></td></tr>
            </table>   
        </div>--%>
        <asp:Literal ID="ltrShowEn" runat="server"></asp:Literal>
        <div id="dv_111">
            <div class="dv_paging">
                <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>

            </div>
        </div>
        <%-- <div class="items-row">
            <h2 class="contentheading"><a href="/hoi-dap-chuyen-de-suc-khoe-gia-dinh/mau-nguyet-san-mau-den-vi-thuoc-tranh-thai.ncsk">máu nguyệt san màu đen vì thuốc tránh thai</a>
            </h2>
            <div class="article-tools">
                22 November 2012 &nbsp &nbsp  Đã xem: 213 lần&nbsp &nbsp 3 Bình luận 
            </div>
            <div class="article-content">
                <p style="text-align: justify;">
                    <em>
                        <img width="200" height="150" src="http://nhipcausuckhoe.com.vn/images/stories/NGOCPHUONG/NAM2012/THANG12/1212/lam-sao-de-nhu-hoa-nho-ra-1.jpg" alt="mau-nguyet-san-mau-den-co-the-do-thuoc-tranh-thai" style="margin-right: 10px; float: left;">Em năm nay 24 tuổi. Em lập gia đình được 2 năm. Vì chưa muốn có em bé sớm nên em sử dụng thuốc tránh thai hàng ngày. Khi sử dụng thuốc thì chu kì kinh nguyệt của em rất đều. Nhưng khoảng 4 tháng gần</em>
                </p>
                <div class="jcomments-links"><a title="máu nguyệt san màu đen vì thuốc tránh thai" href="/hoi-dap-chuyen-de-suc-khoe-gia-dinh/mau-nguyet-san-mau-den-vi-thuoc-tranh-thai.ncsk" class="readmore-link">Đọc thêm...</a> <a class="comments-link" href="/hoi-dap-chuyen-de-suc-khoe-gia-dinh/mau-nguyet-san-mau-den-vi-thuoc-tranh-thai.ncsk#addcomments">Thêm bình luận mới</a> </div>
            </div>
        </div>--%>
    </div>

</asp:Content>
