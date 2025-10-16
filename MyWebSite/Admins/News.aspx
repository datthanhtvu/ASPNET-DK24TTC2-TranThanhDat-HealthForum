<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="MyWebSite.Admins.News" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="PageName">
        Quản lý tin</div>
    
    <asp:Panel ID="pnView" runat="server">
        <div id="search_block">
            Nhóm tin:
            <asp:DropDownList ID="ddlFilterGroupNews" runat="server">
            </asp:DropDownList>
            Tiêu đề tin:
            <asp:TextBox ID="txtFilterName" runat="server" CssClass="text"></asp:TextBox>
            Thời gian:
            <asp:TextBox ID="txtFilterDateF" runat="server" CssClass="date"></asp:TextBox>
            <asp:MaskedEditExtender ID="meeDateFrom" runat="server" Mask="99/99/9999" MaskType="Date"
                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtFilterDateF">
            </asp:MaskedEditExtender>
            <asp:CalendarExtender ID="cdeDateFrom" runat="server" TargetControlID="txtFilterDateF" />
            -
            <asp:TextBox ID="txtFilterDateT" runat="server" CssClass="date" /><asp:MaskedEditExtender
                ID="meeDateTo" runat="server" Mask="99/99/9999" MaskType="Date" OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError" TargetControlID="txtFilterDateT">
            </asp:MaskedEditExtender>
            <asp:CalendarExtender ID="cdeDateTo" runat="server" TargetControlID="txtFilterDateT" />
            Trạng thái:
            <asp:DropDownList ID="ddlFilterActive" runat="server" CssClass="active">
            </asp:DropDownList>
            <asp:Button ID="Filter" runat="server" Text="Lọc" CssClass="filter" OnClick="Filter_Click" />
            <asp:Button ID="UnFilter" runat="server" Text="Bỏ lọc" OnClick="UnFilter_Click" /></div>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdNews" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="false"
            AllowPaging="true" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
            OnItemCommand="grdNews_ItemCommand" OnItemDataBound="grdNews_ItemDataBound" OnPageIndexChanged="grdNews_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Tiêu đề tin" ItemStyle-CssClass="Text"
                    Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>
                        Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript">   playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="DateTime">
                    <HeaderTemplate>
                        Ngày đăng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# MyWebSite.Common.DateTimeClass.ConvertDateTime(DataBinder.Eval(Container.DataItem, "Date").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>
                        Tin trang chủ</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWebSite.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Index").ToString())%>' />

                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>
                        Trạng thái</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWebSite.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>
                        Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                            CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                        <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete"
                            CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png"
                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
                        <asp:ImageButton ID="cmdActive" runat="server" AlternateText='<%#MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                            CommandName="Active" CssClass="Active" ToolTip='<%# MyWebSite.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                            ImageUrl='<%#MyWebSite.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
                PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
            </ul>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="false">
        <table class="TableUpdate" border="1">
            <tr>
                <td class="Control" colspan="2">
                    <ul>
                        <li>
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" CausesValidation="False"
                                OnClick="Back_Click">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblGroupNewsId" runat="server" Text="Nhóm tin:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlGroupNews" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGroupNews" runat="server" ControlToValidate="ddlGroupNews"
                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" />
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Tiêu đề tin:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
             <tr>
                <th>
                    <asp:Label ID="Label2" runat="server" Text="Hình ảnh đại diện:"></asp:Label></th>
                <td>

                  <input id="btnImgImage" type="button" onclick="BrowseServer('<% =txtimage.ClientID %>','Images');"
                        value="Browse Server" />
                        <asp:TextBox ID="txtimage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Tóm tắt:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="text multiline" TextMode="MultiLine"
                        MaxLength="230"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
                </th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckDetail" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDate" runat="server" Text="Ngày đăng:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="text datetime" /><asp:MaskedEditExtender
                        ID="meeDate" runat="server" Mask="99/99/9999 99:99:99" MaskType="DateTime" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" AcceptAMPM="True"
                        Century="2000" />
                    <asp:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate" ControlToValidate="txtDate"
                        Display="Dynamic" EmptyValueBlurredText="Date and time is required" IsValidEmpty="True"
                        InvalidValueBlurredMessage="Date and time is invalid" SetFocusOnError="True" />
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
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblKeyword" runat="server" Text="Keyword meta:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblIndex" runat="server" Text="Tin trang chủ:"></asp:Label>
                </th>
                <td>
                    <asp:CheckBox ID="chkIndex" runat="server" />
                </td>
            </tr>
            <tr >
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
                            <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" CausesValidation="False"
                                OnClick="Back_Click">Trở về</asp:LinkButton></li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
