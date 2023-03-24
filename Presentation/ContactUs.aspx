<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="::ParsianMovie:: تماس با ما" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <table align="center">
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="LBError" runat="server" Text=""></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                از ایمیل : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="TXTFrom" runat="server" Width="230px" CssClass="inputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTFrom"
                    ErrorMessage="لطفاً آدرس ایمیل را وارد نمائید">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTFrom"
                    ErrorMessage="لطفاً آدرس ایمیل را با فرمت درست وارد نمائید" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="left">
                به سمت : 
            </td>
            <td colspan="2">
                <asp:DropDownList ID="DRPTO" runat="server" Width="237px" CssClass="inputbox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTFrom"
                    ErrorMessage="لطفاً آدرس سمت ارسال را انتخاب نمائید">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left">
                موضوع : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="TXTSubject" runat="server" Width="230px" CssClass="inputbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                متن پیام : 
            </td>
            <td colspan="2">
                <asp:TextBox ID="TXTMessage" runat="server" TextMode="MultiLine" Height="150px" Width="400px" CssClass="inputbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="center">
                <asp:ImageButton SkinID="SendMail" ID="IBSubmit" runat="server" OnClick="IBSubmit_Click" />
            </td>
            <td align="center">
                <asp:ImageButton SkinID="CancelMail" ID="IBReset" runat="server" CausesValidation="False" OnClick="IBReset_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <b>یوسفی</b>
                <br />
                شماره تماس : 09354340109
                <br />
                آدرس ایمیل : info@parsianmovie.com
                <br />
                شناسه یاهو : amir_vaghef
            </td>
        </tr>
    </table>
</div>
</asp:Content>

