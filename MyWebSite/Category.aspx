<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="MyWebSite.Category" %>

<%@ Register Src="~/Control/Default/My_U_Ky_Yeu.ascx" TagPrefix="uc1" TagName="My_U_Ky_Yeu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:My_U_Ky_Yeu runat="server" ID="My_U_Ky_Yeu" />
   <div class="nhomtin">
<%--<div class="head-item-right"><p>VĂN BẢN MỚI BAN HÀNH<p> </div>
<div class="item-nhomtin">
 <table >
 <tr>
     
 <td rowspan="3" class="img-nhomtin" style="">
 <a href="" style="padding:0px"><img alt="" src="../../Images/img-tinlienquan.jpg" /></a>
 </td>
 <td class="tieude-item-nhomtin"> <a href="http://localhost:2148/New.aspx"> Thư của bộ trưởng y tế nhân ngày nhà giáo Việt Nam 22-11 hjh hbhjk hbkk kbhk </a></td>
 </tr>
 <tr>
  <td class="tomtat-item-nhomtin" > Nhân ngày nhà giáo Việt Nam 20/11 ,thay mặt bộ trưởng ý tế tôi gửi đến toàn bộ thầy, cô giáo và toàn thể cán  bộ...</td>
 </tr>
 <tr>
  <td align="right"> <a href="" style="color:Red;font-size:13px">Chi tiết</a> <a href="">
      <img src="../../Content/themes/base/images/icon-chitiet.jpg" /></a> </td>
  </tr>
 </table>

</div>--%>
       <asp:Literal ID="ltNews" runat="server"></asp:Literal>
        <div id="dv_111">
        <div class="dv_paging">
            <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>
            

        </div>
    </div>
        
<%--<div class="tintuckhac" > 
<table>
<tr>
<th colspan="2" align="left">Tin tức khác</th>
</tr>
<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>
     <tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>

<tr > <td valign="top" style="padding-top:7px"><img src="../../Content/themes/base/images/nut_tinnoibat1.png" /> </td>
    <td style="padding-left:5px;padding-right:8px"> <a href="">Báo Sức khỏe và Đời Sống kỷ niệm 50 năm thành lập nhận được huân chương lao động hạng 3 </a><font  style="font-weight: normal; font-size: 8pt; color: #2055c7; font-family: Tahoma"> (24/05/2010 01:18 AM)</font></td>
     </tr>


</table>
</div>--%>
</div>
</asp:Content>
