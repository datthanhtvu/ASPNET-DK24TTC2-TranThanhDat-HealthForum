<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_TopIndex.ascx.cs" Inherits="MyWebSite.Control.Default.My_U_TopIndex" %>
<link href="../../Content/Site.css" rel="stylesheet" />
<style type="text/css">
   
    .auto-style1 {
        width: 107px;
    }
   
</style>
<div class="top-index">
 <table cellpadding="0px" cellspacing="0px" >
 <tr>
 <td id="chuchay" class="td-top">
 <marquee onmouseover="this.stop()" onmouseout="this.start()"; align="center" ;width="100%";height="100%";direction="left" scrollamount="2" padding-right="40px";>
 TẠP CHÍ Y HỌC THỰC HÀNH - BỘ Y TẾ - JOURNAL OF PRACTICAL MEDICINE
 </marquee>
 </td>
 <td id="ngaythang" >
 <asp:Label ID="lbtime" 
         runat="server" ForeColor="#0033CC" Font-Size="12px"></asp:Label>
     </td>
 <td id="timkiem" >
  <div class="search"> 
<%--  <input type="text"; name="" ; placeholder="Nhập từ khóa tìm kiếm" />--%>
  <%--<input type="image" style=" width:28px; border-width :0px;" src="../../Content/themes/base/images/icon-timkiem.jpg" id="btsearch" name="n_Search"/>--%>
     
       <asp:TextBox ID="txtkeyword" runat="server" Width="271px" CssClass="txt-timkiem" OnClick="txtkeyword_Click"></asp:TextBox> 
     
       <asp:ImageButton ID="imgbtn" CausesValidation="false" CssClass="img-timkiem"
                    runat="server" ImageUrl="~/App_Themes/Default/img/btn_tiemkiem.png" OnClick="imgbtn_Click" 
                     />
                
      
                
  </div>
 </td>
 <td id="ngonngu" class="td-top">
<input type="image" style=" width:28px; border-width :0px;" src="../../Content/themes/base/images/icon-english.jpg" id="search-english" name="n_Search$english"/>
<input type="image" style=" width:28px; border-width :0px;" src="../../Content/themes/base/images/icon-vietnamese.jpg" id="search-vietnamese" name="n_Search$vietnamese"/>
 </td>
 </tr>
 </table>
</div>