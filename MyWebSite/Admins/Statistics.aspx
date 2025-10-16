<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="MyWebSite.Admins.Statistics" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="PageName">
        Quản lý tin</div>
    

        <div id="search_block">
           Từ ngày:
            <asp:TextBox ID="txtDatefrom" runat="server" CssClass="date"></asp:TextBox>
            
            <asp:CalendarExtender ID="cldDatefrom" TargetControlID="txtDatefrom" runat="server" Format="dd/MM/yyyy"></asp:CalendarExtender>
             
            Đến ngày:
            <asp:TextBox ID="txtDateTo" runat="server" CssClass="date"></asp:TextBox>

            <asp:CalendarExtender ID="cldDateTo"   TargetControlID="txtDateTo" runat="server" Format="dd/MM/yyyy"></asp:CalendarExtender>
            <asp:Button runat="server" Text="Thong ke" ID="btnXuat" OnClick="btnXuat_Click"  />
           
        </div>
       
   
</asp:Content>
