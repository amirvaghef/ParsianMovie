<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Peyk.aspx.cs" Inherits="PUsers_Peyk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::ParsianMovie:: پیک موتوری</title>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <div>
    <table width="800px" align="center">
        <tr>
            <td align="right">
                <img src="Motorcycle1.jpg" />
            </td>
            <td align="left">
                <img src="Motorcycle.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right" style="font-size:medium">
                <span style="color:Yellow;font-weight:bold">
                    برای خرید بوسیله پیک موتوری توجه داشته باشید که : 
                    <ul>
                        <li>
                            پیک موتوری فقط ویژه تهران می باشد.
                        </li> 
                        <li>
                            اگر در روش ارسال پست را انتخاب کرده باشید ما آنرا برای شما پیک موتوری در نظر می گیریم.
                        </li>
                    </ul>
                </span>
                <br />
                <br />
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
                <br />
            </td>
        </tr>
        
        <tr>
            <td colspan="2" align="center">
                <asp:ImageButton ID="IBBuy" SkinID="BuyButton" runat="server" OnClick="IBBuy_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:HyperLink ID="HLCancel" runat="server" NavigateUrl="~/PUsers/Basket.aspx">بازگشت به سبد خرید</asp:HyperLink>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
