<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebSite.Default" %>
<%@ Register src="Control/Default/My_U_Slide.ascx" tagname="My_U_Slide" tagprefix="uc1" %>
<%@ Register src="Control/Default/My_U_Top_News.ascx" tagname="My_U_Top_News" tagprefix="uc2" %>
<%@ Register src="Control/Default/My_U_Top3_News.ascx" tagname="My_U_Top3_News" tagprefix="uc3" %>

<%@ Register src="Control/Default/My_U_Item_Main-News.ascx" tagname="My_U_Item_Main" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:My_U_Slide ID="My_U_Slide1" runat="server" />
    <uc2:My_U_Top_News ID="My_U_Top_News1" runat="server" />
    <uc3:My_U_Top3_News ID="My_U_Top3_News1" runat="server" />

       <uc4:My_U_Item_Main ID="My_U_Item_Main1" runat="server" />

  
  


  
</asp:Content>
