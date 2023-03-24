<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SamanEPaymentRedirect.aspx.cs" Inherits="PUsers_SamanEPaymentRedirect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::ParsianMovie:: تکمیل فرآیند خرید از پرداخت اینترنتی سامان</title>
</head>
<body dir="rtl">
    <form id="form1" action="SamanEPaymentRedirect.aspx" method="post" runat="server">
    <div>
        <table width="800px" align="center">
        <tr>
            <td align="right">
                <img src="Saman-Logo.gif" />
            </td>
            <td align="left">
                <img src="SEP-Logo.gif" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center">
        <asp:Panel ID="Panel1" runat="server" Width="98%" BorderStyle="Groove">
        <br />
        <table width="100%">
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <p>
                <asp:Label ID="LBResNum" runat="server" Text=""></asp:Label>
                </p>
                <asp:Label ID="LBMessage" runat="server" Text=""></asp:Label>
                <hr width="70%"/>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:HyperLink ID="HLBuy" NavigateUrl="~/PUsers/Basket.aspx" runat="server">بازگشت به صفحه خرید</asp:HyperLink>
            </td>
            <td align="center">
                <asp:HyperLink ID="HLHome" NavigateUrl="~/index.aspx" runat="server">بازگشت به صفحه اول</asp:HyperLink>
            </td>
        </tr>
        <br />
        </asp:Panel>
        </td>
        </tr>
        </table>  
    </div>
    </form>
</body>
</html>
