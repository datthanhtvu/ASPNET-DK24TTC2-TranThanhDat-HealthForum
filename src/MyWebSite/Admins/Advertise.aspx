<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="MyWebSite.Admins.Advertise" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">Quản lý quảng cáo</div>
    <asp:Panel ID="pnView" runat="server">
        <div id="search_block">
            Vị trí quảng cáo:
            <asp:DropDownList ID="drlvitriquangcao"
                runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="drlvitriquangcao_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
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
        <asp:DataGrid ID="grdAdvertise" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdAdvertise_ItemDataBound" OnItemCommand="grdAdvertise_ItemCommand" OnPageIndexChanged="grdAdvertise_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Tên quảng cáo" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>
               
                <asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>Vị trí</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPosition" runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowAdvertisePosition(DataBinder.Eval(Container.DataItem, "Position").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
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
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandName="Active" CssClass="Active" ToolTip='<%# MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' ImageUrl='<%#MyWebSite.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next" Mode="NumericPages"></PagerStyle>
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
            <tr style="display: none">
                <th>
                    <asp:Label ID="lblPageId" runat="server" Text="Trang quảng cáo:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlPage" runat="server"></asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvPage" runat="server" ControlToValidate="ddlPage" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"/>--%></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tên quảng cáo:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="display:none">
                <th>
                    <asp:Label ID="lblType" runat="server" Text="Kiểu quảng cáo:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="Link">
                <th>
                    <asp:Label ID="lblImage" runat="server" Text="Hình ảnh:"></asp:Label></th>
                <td>&nbsp;<input id="file_Image" runat="server" name="file1" style="WIDTH: 308px" type="file" /><asp:Label ID="lblImg" runat="server" Visible="False"></asp:Label><asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td>
            </tr>
                      
            <tr id="Link3">
                <th>
                    <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr id="Link4">
                <th>
                    <asp:Label ID="lblTarget" runat="server" Text="Kiểu liên kết:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlTarget" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="Content">
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Nội dung:"></asp:Label></th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server"></FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblPosition" runat="server" Text="Vị trí:"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddlPosition" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblClick" runat="server" Text="Lượt click:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtClick" runat="server" CssClass="text"></asp:TextBox></td>
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
    <script type="text/javascript">
        $(document).ready(function () {
            ChangeType($("#<%= ddlType.ClientID %>").val());
            $("#<%= ddlType.ClientID %>").change(function () {
                ChangeType(this.value);
            });
            function ChangeType(value) {
                $("#Content, #Content td, #Content iframe").css("height", "320px");
                if (value == 1) {
                    $("#Link").css("display", "");
                    $("#Link1").css("display", "");
                    $("#Link2").css("display", "");
                    $("#Link3").css("display", "");
                    $("#Link4").css("display", "");
                    $("#Content").css("display", "none");
                }
                else {
                    $("#Link").css("display", "none");
                    $("#Link1").css("display", "none");
                    $("#Link2").css("display", "none");
                    $("#Link3").css("display", "none");
                    $("#Link4").css("display", "none");
                    $("#Content").css("display", "");
                }
            }
        });
    </script>
</asp:Content>
