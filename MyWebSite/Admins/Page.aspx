<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="MyWebSite.Admins.Page" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản lý danh mục trang</div>
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
        <asp:DataGrid ID="grdPage" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="False" OnItemDataBound="grdPage_ItemDataBound" OnItemCommand="grdPage_ItemCommand" OnPageIndexChanged="grdPage_PageIndexChanged">
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
                    <HeaderTemplate>Tên trang</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# MyWebSite.Common.StringClass.ShowNameLevel(DataBinder.Eval(Container.DataItem, "Name").ToString(), DataBinder.Eval(Container.DataItem, "Level").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="TextShort">
                    <HeaderTemplate>Kiểu trang</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowPageType(DataBinder.Eval(Container.DataItem, "Type").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text" Visible="true" />
                <asp:BoundColumn DataField="Target" HeaderText="Kiểu liên kết" ItemStyle-CssClass="TextShort" Visible="true" />
                <asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="TextShort">
                    <HeaderTemplate>Trạng thái</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdAddSub" runat="server" AlternateText="Thêm cấp con" CommandName="AddSub" CssClass="Add" ToolTip="Thêm cấp con" ImageUrl="/App_Themes/Admin/images/add.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Level")%>' /><asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWebSite.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
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
        <table border="1" class="TableUpdate">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lbtUpdateT" runat="server" CssClass="uupdate"
                                OnClick="Update_Click">Ghi lại</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbtBackT" runat="server" CausesValidation="False"
                                CssClass="uback" OnClick="Back_Click">Trở về</asp:LinkButton>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tên trang:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="txtId" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblType" runat="server" Text="Kiểu trang:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="Link">
                <th>
                    <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlLinkType" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlLinkType_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="ddlLink" runat="server" Visible="False" Style="margin: 3px 0;">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="text" Style="margin: 3px 0;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTarget" runat="server" Text="Kiểu hiển thị:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlTarget" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Mô tả:"></asp:Label>
                </th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server"></FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr id="Content">
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
                </th>
                <td>
                    <fckeditorv2:fckeditor id="fckDetail" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTitle" runat="server" Text="Title meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDescription" runat="server" Text="Description meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPosition" runat="server" Text="Vị trí hiển thị:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlPosition" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtOrd" runat="server" CssClass="text number" />
                    <asp:RequiredFieldValidator ID="rfvOrd" runat="server"
                        ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIndex" runat="server" Text="Trang chủ:"></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="chkIndex" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lbtUpdateB" runat="server" CssClass="uupdate"
                                OnClick="Update_Click">Ghi lại</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbtBackB" runat="server" CausesValidation="False"
                                CssClass="uback" OnClick="Back_Click">Trở về</asp:LinkButton>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {
            ChangeType($("#<%= ddlType.ClientID %>").val());
            ChangeLinkType($("#<%= ddlLinkType.ClientID %>").val());
            $("#<%= ddlType.ClientID %>").change(function () {
                ChangeType(this.value);
            });
            $("#<%= ddlLinkType.ClientID %>").change(function () {
                ChangeLinkType(this.value);
                ChangeLink("/");
            });
            $("#<%= ddlLink.ClientID %>").change(function () {
                ChangeLink(this.value);
            });
            function ChangeType(value) {
                $("#Content, #Content td, #Content iframe").css("height", "320px");
                if (value == 1) {
                    $("#Link").css("display", "");
                    $("#Content").css("display", "none");
                }
                else {
                    $("#Link").css("display", "none");
                    $("#Content").css("display", "");
                }
            }

            function ChangeLinkType(value) {
                if (value == 1) {
                    $("#LinkInput").css("display", "");
                    $("#LinkModule").css("display", "none");
                    $("#<%= txtLink.ClientID %>").focus();
                } else {
                    $("#LinkInput").css("display", "none");
                    $("#LinkModule").css("display", "");
                }
            }
            function ChangeLink(value) {
                $("#<%= txtLink.ClientID %>").val(value);
            }
        });
    </script>
</asp:Content>
