<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Item_Tudien.ascx.cs" Inherits="MyWebSite.Control.Default.My_U_Item_Tudien" %>
<link href="../../Content/Site.css" rel="stylesheet" />
<div class="item-right">
<div class="head-item-right"> <p>TRA TỪ ĐIỂN</p></div>

 <table cellpadding="0" cellspacing="0" style="margin:3px; width:220px; font-size:14px">
  <tr>
  <td style="width:65px; "><strong> Từ điển:</strong></td>
  <td colspan="2" style=" ">
  <select class="sltudien" name="sltudien">
   <option value="anh-viet"> Anh - việt</option>
   <option value="vietanh"> việt-Anh</option>
</select>
  </td>

  
  </tr>
   <tr >
  <td style="width:65px; "> <strong>Từ khóa:</strong></td>
  <td style="width:65px; ">
   <input type="text" style="width:100px" value="" /></td>
  <td style="width:65px; "> 
  <input type="button"  value="Go" id="btgo" />
  </td>
  
  </tr>
</table>
<p style="font-family:Tahoma;color:#392a85" > Đại từ điển trực tuyến</p>
</div>