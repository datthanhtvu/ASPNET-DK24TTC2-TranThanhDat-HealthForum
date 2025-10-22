<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SearchResultNews.aspx.cs" Inherits="MyWebSite.SearchResultNews" %>

<%@ Register Src="Control/Default/My_U_Ky_Yeu.ascx" TagName="My_U_Ky_Yeu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:My_U_Ky_Yeu ID="My_U_Ky_Yeu1" runat="server" />
    <div class="nhomtin">
        <div class="head-item-right"><span style="font-size: 14px;">
            <asp:Label ID="lbsearch" runat="server"></asp:Label>
        </span>


        </div>

        <table style="margin-top:20px" >
            <tr>
                <td> <asp:RadioButton ID="rdGroupNews" AutoPostBack="true" Text="Tin tức" GroupName="rd" runat="server" OnCheckedChanged="rdGroupNews_CheckedChanged" />
               <asp:RadioButton ID="rdEnquiry" AutoPostBack="true" Text="Hỏi đáp" GroupName="rd" runat="server" OnCheckedChanged="rdEnquiry_CheckedChanged" />
                  <asp:DropDownList ID="ddlNhomtin" runat="server" ></asp:DropDownList></td>
                 </tr>
            <tr>
                <td colspan="2"> <asp:TextBox ID="txtkeyword" runat="server" Width="271px" CssClass="" ></asp:TextBox>
           
                <asp:ImageButton ID="imgbtn" CausesValidation="false"                    
            runat="server" ImageUrl="~/App_Themes/Default/img/btn_tiemkiem.png" CssClass="img-timkiem" OnClick="imgbtn_Click" />
           <br /> <asp:Label ID="lbbaoloi" runat="server" Text="" Visible="false" ></asp:Label>
                </td>
            </tr>
        </table>
  
        <div style="border-bottom:2px solid #0f440f" ></div>

       
        <asp:Literal ID="ltNews" runat="server"></asp:Literal>
        <div id="dv_111">
            <div class="dv_paging">
                <asp:Literal ID="ltrpaging" runat="server"></asp:Literal>


            </div>
        </div>


    </div>
</asp:Content>
