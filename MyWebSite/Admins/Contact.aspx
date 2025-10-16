<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True" CodeBehind="Contact.aspx.cs" Inherits="MyWebSite.Admins.Contact" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản lý liên hệ, phản hồi</div>
    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <li><%--<asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton>--%></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdContact" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdContact_ItemDataBound" OnItemCommand="grdContact_ItemCommand" OnPageIndexChanged="grdContact_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Họ tên" ItemStyle-CssClass="Text" Visible="true" />
                <asp:BoundColumn DataField="Company" HeaderText="Công ty" ItemStyle-CssClass="MultiLine" Visible="true" />
                <asp:BoundColumn DataField="Address" HeaderText="Địa chỉ" ItemStyle-CssClass="MultiLine" Visible="true" />
                <asp:BoundColumn DataField="Tel" HeaderText="Điện thoại" ItemStyle-CssClass="Text" Visible="true" />
                <asp:BoundColumn DataField="Mail" HeaderText="Mail" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="DateTime">
                    <HeaderTemplate>Ngày đăng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# MyWebSite.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "Date").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Active">
                    <HeaderTemplate>Chưa xem</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWebSite.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li><%--<asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" onclick="AddButton_Click">Thêm mới</asp:LinkButton>--%></li>
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
                    <asp:Label ID="lblCompany" runat="server" Text="Công ty:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTel" runat="server" Text="Điện thoại:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label></th>
                <td>
               
                    <FCKeditorV2:FCKeditor ID="fckDetail" runat="server"></FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDate" runat="server" Text="Ngày đăng:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="text datetime" /> 
                   
                </td>
            </tr>
            <tr>
                <th>
                    
                <asp:Label ID="lblActive" runat="server" Text="Chưa xem:"></asp:Label>
                    </th>
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
