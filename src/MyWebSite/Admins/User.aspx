<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="User.aspx.cs" Inherits="MyWebSite.Admins.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản lý người dùng</div>
    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdUser" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="False" OnItemDataBound="grdUser_ItemDataBound" OnItemCommand="grdUser_ItemCommand" OnPageIndexChanged="grdUser_PageIndexChanged">
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <ItemStyle CssClass="trOdd"></ItemStyle>
            <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
            <Columns>
                <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="tdCenter"></ItemStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
                <asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
                <asp:TemplateColumn ItemStyle-CssClass="Text">
                    <HeaderTemplate>Họ tên</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# MyWebSite.Common.StringClass.ShowNameLevel(DataBinder.Eval(Container.DataItem, "Name").ToString(), DataBinder.Eval(Container.DataItem, "Level").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Username" HeaderText="Tên đăng nhập" ItemStyle-CssClass="Text" Visible="true" />
               
                <%--<asp:BoundColumn DataField="Admin" HeaderText="Quản trị?" ItemStyle-CssClass="CheckBox" Visible="true" />--%>
                <asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Kích hoạt</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                       <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWebSite.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <table class="TableUpdate" border="1">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Họ tên:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblUsername" runat="server" Text="Tên đăng nhập:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="datetime"></asp:TextBox></td>
            </tr>
            <tr >
                <th>
                    <asp:Label ID="lblAdmin" runat="server" Text="Quyền hạn:"></asp:Label></th>
                <td>
                    <asp:label id="lbIdRule" runat="server" Text="" Visible="false" ></asp:label>
            <asp:DropDownList ID="ddlFilterRule" runat="server" OnSelectedIndexChanged="ddlFilterRule_SelectedIndexChanged">
            </asp:DropDownList></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtOrd" runat="server" CssClass="text number" /><asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label></th>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" /></td>
            </tr>
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
