<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SamanEPayment.aspx.cs" Inherits="PUsers_SamanEPayment" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>::ParsianMovie:: پرداخت اینترنتی سامان</title>
</head>
<body dir="rtl">
    <form id="form1" action="https://acquirer.sb24.com/CardServices/controller" method="post">
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
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" Width="98%" BorderStyle="Groove">
                <br />
                <table width="100%">
        <tr>
            <td align="left">
                قیمت فیلم ها : <asp:Label ID="LBPriceFilms" runat="server" Text="0"></asp:Label> ریال
            </td>
        </tr>
        <tr>
        <tr>
            <td>
                <hr width="50%" />
            </td>
        </tr>
            <td>
                نوع ارسال : <asp:Label ID="LBTransmissionKind" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                قیمت ارسال : <asp:Label ID="LBPriceTransmissionKind" runat="server" Text="0"></asp:Label> ریال
            </td>
        </tr>
        <tr>
            <td>
                <hr width="50%" />
            </td>
        </tr>
        <tr>
            <td>
                نوع دی وی دی : <asp:Label ID="LBDVDKind" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                تعداد 
                <asp:Label ID="LBDVDNumber" runat="server" Text="0"></asp:Label> عدد * قیمت واحد 
                <asp:Label ID="LBPriceOneDVD" runat="server" Text="0"></asp:Label> ریال = قیمت دی وی دی ها : <asp:Label ID="LBPriceDVDKind" runat="server" Text="0"></asp:Label> ریال
            </td>
        </tr>
        <tr>
            <td>
                <hr width="50%" />
            </td>
        </tr>
        <tr>
            <td align="left">
                 مبلغ کل پرداخنی : <asp:Label ID="LBPriceKol" runat="server" Text="0"></asp:Label> ریال
            </td>
        </tr>
                </table>
                <br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                    <input id="Amount" name="Amount" type="hidden" runat="server" />
                    <input id="MID" name="MID" type="hidden" runat="server" />
                    <input id="ResNum" name="ResNum" type="hidden" runat="server" />
                    <input id="RedirectURL" name="RedirectURL" type="hidden" runat="server" />
                    
                    <input id="btnSubmit1" name="btnSubmit1" type="submit" value="تأئید و ادامه" />
            </td>
        </tr>
    </table>
</div>
    </form>
</body>
</html>

