<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EnquiryDetail.aspx.cs" Inherits="MyWebSite.EnquiryDetail" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>
<%@ Register src="Control/Default/My_U_Ky_Yeu.ascx" tagname="My_U_Ky_Yeu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:My_U_Ky_Yeu ID="My_U_Ky_Yeu1" runat="server" />
     <div class="nhomtin">
        <div class="head-item-right">
            <asp:Label Id="lbTenchuyenmuc" Text="" runat="server"></asp:Label><a class="uploadCauhoi" href="/Gui-cau-hoi/EnquiryUp.htm">Gửi câu hỏi </a>

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
                        <img width="200" height="150" src="http://nhipcausuckhoe.com.vn/images/stories/NGOCPHUONG/NAM2012/THANG12/1212/lam-sao-de-nhu-hoa-nho-ra-1.jpg" alt="mau-nguyet-san-mau-den-co-the-do-thuoc-tranh-thai" style="margin-right: 10px; float: left;"></em>
                </p>
               
            </div>
        </div>--%>
          <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
         <%--<asp:Literal ID="ltrCom" runat="server"></asp:Literal>--%>
        <%-- <div class="comments"  >
             <span style="font-family:Arial;font-size:15px;font-weight:bold;">Nguyễn Hoàng Vân</span> <span style="font-size:13px;color:#808080" >22/12/200</span> <br /> &nbsp&nbsp
             Tôi vắt sữa mang về nhà) và sữa ngoài 100ml. Vừa rồi tôi mang cháu đi khám, được BS tư vấn rằng ở độ tuổi này của cháu thì mỗi ngày cháu cần tối thiểu 750ml sữa, và khuyên tôi nên giảm sữa mẹ, chuyển sang cho cháu bú sữa ngoài vì lúc này sữa mẹ đã dần bị mất chất. Vậy tôi xin BS tư vấn giúp tôi hai vấn đề: 1. Ở độ tuổi này mỗi ngày cháu cần bao nhiêu sữa? 2. Tôi 
             có nên giảm sữa mẹ và chuyển sang sữa ngoài cho cháu không? Tôi xin cảm ơn BS! - (Đ.T Thắm – huyenthoai...@yahoo.com)
         </div>--%>
         <asp:ListView ID="lvDemo" runat="server" >
    <LayoutTemplate>
        <div>
            <div id="itemPlaceholder" runat="server" />
        </div>
    </LayoutTemplate>
    <ItemTemplate>
         <div class="comments" runat="server" > <%# Eval("Title")%> </div>
    </ItemTemplate>
</asp:ListView> 
         <cc1:CollectionPager ID="CollectionPager1"
    FirstText="Đầu" 
    BackText="« Trước &amp;nbsp;" 
    LabelText="" 
    LastText="Cuối" 
    NextText="&amp;nbsp; Sau  »" 
    ShowFirstLast="True" 
    SliderSize="5" PagingMode="PostBack"
    runat="server" BackNextLinkSeparator="" BackNextLocation="Split" 
    PageNumbersDisplay="Numbers" ResultsLocation="None" 
    BackNextDisplay="Buttons">
</cc1:CollectionPager>

<%--asp:ListView ID="DS_Test" runat="server">
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" style="width:100%;">
                <div runat="server" id="itemPlaceholder"></div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div style="float:left; width:189px;background-color:red">
           <asp:Literal ID="ltrCom" runat="server"></asp:Literal>
             <img class="hinh_phim" src=<%# "../hinh/phim/thumb/" + Eval("hinh") %> />
                <div style="text-align:left; margin:5px 0px 0px 10px;">
                <%# Eval("tensanpham") %>
                </div>
            </div>
        </ItemTemplate>
        </asp:ListView>

         
<asp:DataPager ID="DataPager1" QueryStringField="page" PageSize="5" PagedControlID="DS_Test" runat="server">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" />
            <asp:NextPreviousPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="true"
            FirstPageText="Trang đầu" LastPageText ="Trang cuối" NextPageText="Tiếp theo"
             PreviousPageText="Quay lại" ShowFirstPageButton="true" ShowLastPageButton="true"
              ShowNextPageButton="true" ShowPreviousPageButton="true" />
        </Fields>
    </asp:DataPager>--%>


       <%--  <div id="dv_111">
            <div class="dv_paging">
                <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>

            </div>
        </div>--%>
        <%--<asp:DataGrid ID="grdCom" runat="server" Width="96%"  AutoGenerateColumns="false"
            AllowPaging="true" PageSize="3" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
         OnPageIndexChanged="grdCom_PageIndexChanged" BorderColor="Red" CellPadding="30"
          >
           
            <Columns>
              
                <asp:BoundColumn DataField="Detail" 
                    Visible="true" />
            </Columns>
           
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
                PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>--%>

       <div class="comment" style="text-align:left;color:#2c2424">
            <div class="head-comment" >&nbsp Viết bình luận</div>
             <div style="margin-left:30px">
             Họ tên:<span style="color:red">(*)</span><asp:TextBox CssClass="txtcom" ID="txtfullname" runat="server"></asp:TextBox></br>
             Email:  <span style="color:red">(*)</span><asp:TextBox CssClass="txtcom"  ID="txtemail" runat="server"></asp:TextBox></br>
             Nội dung <span style="color:red">(*)</span><br />
             <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine" Height="131px" Width="245px"></asp:TextBox>
              </div>
                <div>
            <recaptcha:RecaptchaControl ID="recaptcha" 
                runat="server"
                PublicKey="6LcBJeISAAAAAGms0UFjoVlkvRdNZRLJEvYL308L"
                PrivateKey="6LcBJeISAAAAAIOuwhKZsBRsQQ2aySrhdKBmah43"
                Theme="white" />
            <asp:Label Visible="False" ID="lblResult" runat="server" ForeColor="Red" />
            <asp:Button ID="btnSubmit" runat="server" Text="Gửi trả lời" OnClick="btnSubmit_Click" />
           </div>
         </div>
        <div style="margin-top:15px;width:98%;border-bottom:4px solid #242121;color:#061d75;font-family:'Times New Roman';font-size:16px;font-weight:bold;text-align:left">
            Tin khác cùng chuyên mục
        </div>
         <%--<table>
          <tr>
                                    <td valign="top" align="left" style="width: 8px; padding-top: 5px; padding-left: 3px; padding-right: 5px">
                                        <img src="/App_Themes/Default/images/nut_tinnoibat1.png">
                                    </td>
                                    <td align="left" style="padding-right: 4px">
                                        <a href="" class="newother">
                                            Hội nghị Tổng kết công tác Đảng năm 2012 và phương hướng, nhiệm vụ năm 2013 của Đảng bộ Bộ Y tế</a> <font style="font-weight: normal;
                                                font-size: 8pt; color: #2055c7; font-family: Tahoma">(12/03/2013 - 08:47:18 AM)</font>
                                    </td>
                                </tr>

         </table>--%>
         <asp:Literal ID="ltrEnquiryOther" runat="server"></asp:Literal>
           
    </div>
   
</asp:Content>
