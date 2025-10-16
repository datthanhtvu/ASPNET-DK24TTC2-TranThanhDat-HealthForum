<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyWebSite.Contact" %>

<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>

<%@ Register Src="Control/Default/My_U_Ky_Yeu.ascx" TagName="My_U_Ky_Yeu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript">
    function Validate(source, args) {
        var fckBody = FCKeditorAPI.GetInstance('<%=fckDetail.ClientID %>');
        args.IsValid = fckBody.GetXHTML(true) != "";
    }
</script>--%>
    <uc1:My_U_Ky_Yeu ID="My_U_Ky_Yeu1" runat="server" />
    <div class='nhomtin'>
        <div class="head-item-right">
            <span>Liên hệ/phản hồi</span>
        </div>
        <table class="tcontact">
            <tr>
                <td colspan="2">
                    <asp:Literal ID="ltrContact" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblName" runat="server" Text="Họ tên:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblCompany" runat="server" Text="Công ty:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="multiline"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="multiline"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTel" runat="server" Text="Điện thoại:"></asp:Label></th>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtTel" Display="Dynamic" ErrorMessage="*"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="datetime"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtMail" ErrorMessage="*"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtMail" Display="Dynamic" ErrorMessage="*"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="rfvDetail" runat="server" 
        ControlToValidate="fckDetail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>--%></th>
                <td>
                    <asp:TextBox ID="txtcontents" runat="server" Height="142px"
                        TextMode="MultiLine" Width="366px"></asp:TextBox>
                    <asp:CustomValidator runat="server" ID="cvBody" SetFocusOnError="true" Display="dynamic" Text="*" ClientValidationFunction="Validate"></asp:CustomValidator>
                </td>
            </tr>
           
            <tr>
                <td></td><td>     
                     
                <recaptcha:RecaptchaControl 
                ID="recaptcha"
                runat="server"
                PublicKey="6LcBJeISAAAAAGms0UFjoVlkvRdNZRLJEvYL308L"
                PrivateKey="6LcBJeISAAAAAIOuwhKZsBRsQQ2aySrhdKBmah43"
                Theme="white" />
            <asp:Label Visible="false" ID="lblResult" runat="server" />
           <asp:Button ID="btnContact" runat="server" Text="Gửi" CssClass="css_btncontact"
                        OnClick="btnContact_Click" /></td><td></td>
            </tr>
            
        </table>
    </div>
</asp:Content>
