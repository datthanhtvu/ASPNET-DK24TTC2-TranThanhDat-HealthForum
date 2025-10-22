<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="MyWebSite.Admins.Export" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="PageName"style="text-align:center; font-weight:bold; font-size:25px; margin-bottom:10px;">
                Thống Kê Bài viết
            </div>
            <asp:DataGrid ID="grdCustomer" runat="server" Width="100%" CssClass="TableView"
                AutoGenerateColumns="False" PagerStyle-Mode="NumericPages"
                PagerStyle-HorizontalAlign="Center">
                <HeaderStyle CssClass="trHeader"></HeaderStyle>
                <ItemStyle CssClass="trOdd"></ItemStyle>
                <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
                <Columns>
                    <%--   <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />--%>
                    <asp:TemplateColumn ItemStyle-CssClass="Text">
                        <HeaderTemplate>
                            Họ tên
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("Name").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-CssClass="Text">
                        <HeaderTemplate>
                            Tên đăng nhập
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Username").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-CssClass="Text">
                        <HeaderTemplate>
                            Số bài đăng
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Sobaidang").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    

                </Columns>
                <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
                    PrevPageText="Next" Mode="NumericPages"></PagerStyle>

            </asp:DataGrid>
            <div style="float: left; margin-left: 50px; color: red;">
                <asp:Label ID="lblsumpay" runat="server"></asp:Label>
            </div>
            <div style="margin-top: 20px; float: left;">
                <%--<asp:ImageButton ID="imgExport" runat="server" ImageUrl="/App_Themes/Admin/images/printicon.gif" OnClick="imgExport_Click"/>
                <asp:ImageButton ID="imgblack" runat="server" ImageUrl="/App_Themes/Admin/images/back.png" OnClick="imgblack_Click" />--%>
                <asp:LinkButton ID="lbt" runat="server" Text="Export" OnClick="lbt_Click"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Quay lại" OnClick="LinkButton1_Click"></asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>
