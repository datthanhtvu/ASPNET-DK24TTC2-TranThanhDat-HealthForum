<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="My_U_Menu.ascx.cs" Inherits="MyWebSite.Control.Default.My_U_Menu" %>

<link href="../../Content/Site.css" rel="stylesheet" />
<link href="../../Content/ddlevelsmenu-base.css" rel="stylesheet"  />
<link href="../../Content/ddlevelsmenu-topbar.css" rel="stylesheet"  />
<link href="../../Content/ddlevelsmenu-sidebar.css" rel="stylesheet" />
<%--<link href="../../Content/ddlevelsmenu-sidebar.css" rel="stylesheet"  />--%>
<script src="../../Scripts/ddlevelsmenu.js"></script>
<%--<div class="menu">--%>
 <%--<div id="ddtopmenubar" class="mattblackmenu">
  <ul>
        <li><a href="http://localhost:3281/Default.aspx">Trang Chủ   </a>  </li>
        <li><a href="#" rel="ddsubmenu1">Văn Bản Mới</a></li>
        <li><a href="#" rel="ddsubmenu2">Tin hoạt động</a></li>
        <li><a href="#" rel="ddsubmenu3">HIV/AIDS</a></li>
        <li><a href="#" rel="ddsubmenu4">Y học trong nước</a></li>
        <li><a href="#" rel="ddsubmenu5">Y học cổ truyền</a></li>
        <li><a href="#" rel="ddsubmenu6">Tin đó đây</a></li>
        <li><a href="#" rel="ddsubmenu7">Thư viện</a></li>
        <li><a href="#" rel="ddsubmenu8">Bệnh thường gặp</a></li>
        <li><a href="#" rel="ddsubmenu9">Giới thiệu</a></li>
        <li><a href="#" rel="ddsubmenu10">Liên hệ</a></li>
        <li><a href="#" rel="ddsubmenu11">Mail YHTH</a></li>

    </ul>
 </div>
    <script type="text/javascript">
       ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>
    <ul id="ddsubmenu1" class="ddsubmenustyle">
    <li> <a href="#"> Kiến thức HIV </a></li>
    </ul>
 <ul id="ddsubmenu2" class="ddsubmenustyle">
    <li> <a href="#"> Kiến thức HIV2 </a></li>
    </ul>--%>


<%--</div>--%>
<div class="menu" >
<div id="ddtopmenubar" class="mattblackmenu" >
<ul>
<%--<li><a href="">Home</a></li>
<li><a href="" rel="ddsubmenu1">DHTML</a></li>
<li><a href="" rel="ddsubmenu2">CSS</a></li>
<li><a href="">Forums</a></li>
<li><a href="" rel="ddsubmenu3">Web Tools</a></li>--%>
    <asp:Literal ID="ltrMain" runat="server"
></asp:Literal></ul>
</div>
</div>
<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>
<asp:Literal ID="ltrSub" runat="server"></asp:Literal>


<%--<ul id="ddsubmenu1" class="ddsubmenustyle">
<li><a href="#">Item 1a</a></li>
<li><a href="#">Item 2a</a></li>
<li><a href="#">Item Folder 3a</a>
  <ul>
  <li><a href="#">Sub Item 3.1a</a></li>
  <li><a href="#">Sub Item 3.2a</a></li>
  <li><a href="#">Sub Item 3.3a</a></li>
  <li><a href="#">Sub Item 3.4a</a></li>
  </ul>
</li>
<li><a href="#">Item 4a</a></li>
<li><a href="#">Item Folder 5a</a>
  <ul>
  <li><a href="#">Sub Item 5.1a</a></li>
  <li><a href="#">Item Folder 5.2a</a>
    <ul>
    <li><a href="#">Sub Item 5.2.1a</a></li>
    <li><a href="#">Sub Item 5.2.2a</a></li>
    <li><a href="#">Sub Item 5.2.3a</a></li>
    <li><a href="#">Sub Item 5.2.4a</a></li>
    </ul>
  </li>
	</ul>
</li>
<li><a href="#">Item 6a</a></li>
</ul>


<ul id="ddsubmenu2" class="ddsubmenustyle">
<li><a href="#">Item 1b</a></li>
<li><a href="#">Item 2b</a></li>
<li><a href="#">Item Folder 3b</a>
  <ul>
  <li><a href="#">Sub Item 3.1b</a></li>
  <li><a href="#">Sub Item 3.2b</a></li>
  <li><a href="#">Sub Item 3.3b</a></li>
  <li><a href="#">Sub Item 3.4b</a></li>
  </ul>
</li>
<li><a href="#">Item 4b</a></li>
<li><a href="#">Item Folder 5b</a>
  <ul>
  <li><a href="#">Sub Item 5.1b</a></li>
  <li><a href="#">Item Folder 5.2b</a>
    <ul>
    <li><a href="#">Sub Item 5.2.1b</a></li>
    <li><a href="#">Sub Item 5.2.2b</a></li>
    <li><a href="#">Sub Item 5.2.3b</a></li>
    </ul>
  </li>
	</ul>
</li>
<li><a href="#">Item 6b</a></li>
</ul>


<ul id="ddsubmenu3" class="ddsubmenustyle">
<li><a href="http://tools.dynamicdrive.com/imageoptimizer/">Image Optimizer</a></li>
<li><a href="http://tools.dynamicdrive.com/favicon/">FavIcon Generator</a></li>
<li><a href="http://www.dynamicdrive.com/emailriddler/">Email Riddler</a></li>
<li><a href="http://tools.dynamicdrive.com/password/">htaccess Password</a></li>
<li><a href="http://tools.dynamicdrive.com/userban/">htaccess Banning</a></li>
</ul>
--%>
