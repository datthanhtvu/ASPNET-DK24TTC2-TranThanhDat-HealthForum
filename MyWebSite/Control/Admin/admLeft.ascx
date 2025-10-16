<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="admLeft.ascx.cs" Inherits="MyWebSite.Control.Admin.admLeft" %>
<table class="table" cellspacing="0" cellpadding="0">
<tr>
    <td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    <td>Quản lý </td>
    <td class="image"><img alt="" id="imgdiv1" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div1');"/></td>
    <td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
</tr>
</table>
<asp:Panel ID="div1" CssClass="content" ClientIDMode="Static" runat="server">
<ul>
        <li><img alt="" src="/App_Themes/admin/images/icon_system.jpg"/><asp:LinkButton 
                ID="lbtConfig" CausesValidation="false" runat="server" onclick="LinkButton_Click">Cấu hình</asp:LinkButton></li>
        <li><img alt="" src="/App_Themes/admin/images/icon_user.jpg"/><asp:LinkButton 
                ID="lbtUser" CausesValidation="false" runat="server" onclick="LinkButton_Click">Người dùng</asp:LinkButton></li>
		<li><img alt="" src="/App_Themes/admin/images/icon_page.jpg"/>
            <asp:LinkButton 
                ID="lbtPage" CausesValidation="false" runat="server" onclick="LinkButton_Click">Danh mục trang</asp:LinkButton></li>
		<li><img alt="" src="/App_Themes/admin/images/icon_contact.jpg"/><asp:LinkButton 
                ID="lbtContact" CausesValidation="false" runat="server" onclick="LinkButton_Click">Liên hệ, phản hồi</asp:LinkButton></li>
       
		<li><img alt="" src="/App_Themes/admin/images/icon_adv.jpg"/><asp:LinkButton 
    ID="lbtAdvertise" CausesValidation="false" runat="server" onclick="LinkButton_Click">Liên kết, quảng cáo</asp:LinkButton></li>
        
    </ul>
</asp:Panel>
	<table class="table" cellspacing="0" cellpadding="0"><tr><td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td><td>Tin tức </td><td class="image"><img alt="" id="imgdiv10" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div10');"/></td><td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td></tr></table>
 <asp:Panel ID="div10" CssClass="content" ClientIDMode="Static" runat="server"><ul> <li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/><asp:LinkButton 
    ID="lbtGroupNews" runat="server" onclick="LinkButton_Click">Nhóm tin</asp:LinkButton></li> <li><img alt="" src="/App_Themes/admin/images/icon_pro.jpg"/><asp:LinkButton 
        ID="lbtNews" runat="server" onclick="LinkButton_Click">Danh sách tin</asp:LinkButton></li> </ul></asp:Panel>
	
	<table class="table" cellspacing="0" cellpadding="0">
    <tr>
    <td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    <td>Kiểm duyệt Độc giả</td><td class="image"><img alt="" id="imgdiv9" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div9');"/></td>
    <td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td>
    </tr>
    </table>
    <asp:Panel ID="div9" CssClass="content" ClientIDMode="Static" runat="server"><ul>
    <li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/>
    <asp:LinkButton ID="lbtEnquiryCheck" CausesValidation="false" runat="server" onclick="LinkButton_Click">Hỏi đáp</asp:LinkButton></li> 
    <li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/>
    <asp:LinkButton ID="lbtCommentCheck" CausesValidation="false" runat="server" onclick="LinkButton_Click">Bình luận</asp:LinkButton></li> 
    
        </ul>
     
     </asp:Panel>

	<table class="table" cellspacing="0" cellpadding="0"><tr><td class="left"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td><td>Thống kê</td><td class="image"><img alt="" id="imgdiv8" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div8');"/></td><td class="right"><img alt="" src="/App_Themes/admin/images/blank.gif" /></td></tr></table>
    <asp:Panel ID="div8" CssClass="content" ClientIDMode="Static" runat="server"><ul><li><img alt="" src="/App_Themes/admin/images/icon_gpro.jpg"/><asp:LinkButton 
    ID="lbtStatistics" CausesValidation="false" runat="server" onclick="LinkButton_Click">Thống kê</asp:LinkButton></li> </ul></asp:Panel>

   