<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="CustomError.aspx.cs" Inherits="CustomError" Title="بروز خطا" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <label style="color:Red;"><br /><b>سیستم با مشکل مواجه شده است.</b><br /> لطفاً </label>
    <asp:HyperLink ID="HyperLink1" runat="server">[کلیک نمائید]</asp:HyperLink>
    <label style="color:Red;"> و در صورت عدم رفع اشکال با ما(09354340109   یوسفی) تماس حاصل نمائید. </label>
    <br />
    <br />
    <br />
    <div dir="ltr" align="left"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
</div>
</asp:Content>

