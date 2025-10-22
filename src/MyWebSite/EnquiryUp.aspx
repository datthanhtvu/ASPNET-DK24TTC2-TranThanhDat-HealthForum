<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EnquiryUp.aspx.cs" Inherits="MyWebSite.EnquiryUp" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Control/Default/My_U_Ky_Yeu.ascx" TagName="My_U_Ky_Yeu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .text {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:My_U_Ky_Yeu ID="My_U_Ky_Yeu1" runat="server" />
    <div class="nhomtin" style="color: black; font-size: 14px; font-weight: bold;">
        <%-- <div class="head-item-right">Gửi câu hỏi</div>
        <div style="width:98%">
        <div style="margin-top:30px;text-align:left">
        Tên bạn:<span style="color:red">(*)</span><asp:TextBox ID="txtName" runat="server" Width="231px" ></asp:TextBox></br> 
        Email:<span style="color:red">(*)</span>&nbsp &nbsp<asp:TextBox ID="txtMail" runat="server" Width="230px" ></asp:TextBox></div></br>
           Tiêu đề câu hỏi:<span style="color:red">(*)</span>
             </br>
           <input ID="file_Image" runat="server" name="file1" style="WIDTH: 308px" type="file" /><asp:Label ID="lblImg" runat="server" Visible="False"></asp:Label>&nbsp; <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" />
            <asp:TextBox ID="txtNameQuery" runat="server" Width="430px" Height="33px" TextMode="MultiLine" ></asp:TextBox></div></br>
        Nội dung câu hỏi:<span style="color:red">(*)</span>
        
        <div style="width:95%"><asp:TextBox ID="txtDetail" runat="server" Height="391px" style="margin-left: 0px" TextMode="MultiLine" Width="495px"></asp:TextBox></div>
        --%>
        <div class="head-item-right">Gửi câu hỏi</div>
        <asp:Panel ID="pnUpdate" runat="server" Visible="true">
            <table class="TableEn" style="width: 98%; margin-top: 10px">
                <tr>
                    <th>
                        <asp:Label ID="lbFullName" runat="server" Text="Tên bạn:"></asp:Label></th>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="text" Width="208px"></asp:TextBox><span style="color: red">(*)</span></td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="lbEmail" runat="server" Text="Email:"></asp:Label></th>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Width="208px"></asp:TextBox><span style="color: red">(*)</span></td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="lblGroupNewsId" runat="server" Text="Chuyên mục:"></asp:Label></th>
                    <td>
                        <asp:DropDownList ID="ddlGroupNews" runat="server"></asp:DropDownList>

                        <span style="color: red">(*)</span></td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="lblNameE" runat="server" Text="Tiêu đề câu hỏi:"></asp:Label></th>
                    <td>
                        <asp:TextBox ID="txtNameE" runat="server" CssClass="text" Width="208px"></asp:TextBox><span style="color: red">(*)</span></td>
                </tr>
                <tr id="Link">
                    <th>
                        <asp:Label ID="lblImage" runat="server" Text="Ảnh minh họa:"></asp:Label></th>
                    <td>&nbsp;<input id="file_Image" runat="server" name="file1" style="WIDTH: 308px" type="file" /><asp:Label ID="lblImg" runat="server" Visible="False"></asp:Label><asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" /></td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label><span style="color: red">(*)</span></th>
                    <td>
                        <asp:TextBox ID="txtDetail" runat="server" CssClass="text multiline"
                            TextMode="MultiLine" MaxLength="230" Height="300px" Width="422px"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label1" runat="server" Text="Mã xác thực:"></asp:Label></th>
                    <td>

                        <recaptcha:RecaptchaControl
                            ID="recaptcha"
                            runat="server"
                            PublicKey="6LcBJeISAAAAAGms0UFjoVlkvRdNZRLJEvYL308L"
                            PrivateKey="6LcBJeISAAAAAIOuwhKZsBRsQQ2aySrhdKBmah43"
                            Theme="white" />
                        <asp:Label Visible="false" ID="lblResult" runat="server" />
                        <asp:Button ID="btnSubmit" runat="server" Text="Gửi câu hỏi" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>

        </asp:Panel>



    </div>
</asp:Content>
