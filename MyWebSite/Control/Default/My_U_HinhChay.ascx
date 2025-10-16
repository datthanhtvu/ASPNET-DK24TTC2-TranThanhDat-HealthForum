<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_HinhChay.ascx.cs" Inherits="MyWebSite.Control.Default.My_U_HinhChay" %>
<link href="Site.css" rel="stylesheet" />
<div class="content-bottom">
<marquee scrollamount="3"; behavior="alternate"; onmouseover="this.stop()"; truespeed="truespeed"; onmouseout="this.start()" ; align="center";derection="left" height="50"; width="100%";behavior="alternate" ;> 
 <a href="" ><img style="height:80px;width:150px"  alt="" src="http://localhost:3281/Upload/Images/anh-sang-1434f.jpg" /></a>
    <asp:Literal ID="ltrShowImg" runat="server"></asp:Literal>
</marquee>
  
</div>
