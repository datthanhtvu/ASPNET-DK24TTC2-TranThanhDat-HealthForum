<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admTop.ascx.cs" Inherits="MyWebSite.Control.Admin.admTop" %>
<%@ Import Namespace="MyWebSite.Common" %>
<div class="div"><table class="table" cellspacing="0" cellpadding="0">
<tr>
    <td colspan="3" class="logo">ADMIN PAGE MANAGER</td>
</tr>
<tr>
    <td class="left">Wellcome: <strong><%= Session["FullName"]%></strong>&nbsp; </td>
    <td class="right">[ <a href="<%=GlobalClass.ApplicationPath %>/Admins/Default.aspx" target="_self">Trang chủ </a> ] &nbsp; [ <a href="<%=GlobalClass.ApplicationPath %>/Admins/RePass.aspx" target="_self">Đổi mật khẩu</a> ] &nbsp; [<a href="<%=GlobalClass.ApplicationPath %>/Default.aspx" target="_self">Thoát </a> ]</td>
    
</tr>
</table>
</div>


