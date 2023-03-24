<%@Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="::Parsian Movie:: مشهورترین فیلم های دنیا-فروشگاه اينترنتی" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link rel="stylesheet" href="JScript/floating-window.css" media="screen" type="text/css">
<script language="javascript" src="JScript/tooltip.js" type="text/javascript"></script>
<div id=toolTipLayer dir="ltr" style="VISIBILITY: hidden; POSITION: absolute"></div>
<script language="javascript"  type="text/javascript"><!--
    initToolTips();
 //-->
</script>
<script type="text/javascript" src="JScript/ajax.js"></script>
<script type="text/javascript" src="JScript/floating-window.js"></script>

<div id="content">
<a name="hdr" id="hdr"></a>        
<!-- Panel Buy -->
<asp:Panel ID="PLBuy" runat="server" Visible="false" Width="100%">            
<table id="Table_01" width="416" height="122" border="0" cellpadding="0" cellspacing="0" dir="ltr" align="center">
	<tr>
		<td colspan="3">
			<img src="App_Themes/Space/images/Panel/top_01.gif" width="273" height="12" alt=""></td>
		<td colspan="2">
			<img src="App_Themes/Space/images/Panel/top_02.gif" width="142" height="12" alt=""></td>
		<td>
			<img src="App_Themes/Space/images/Panel/spacer.gif" width="1" height="12" alt=""></td>
	</tr>
	<tr>
		<td colspan="3">
			<img src="App_Themes/Space/images/Panel/top_03.jpg" width="273" height="48" alt=""></td>
		<td rowspan="3" background="App_Themes/Space/images/Panel/top_04.gif" width="130" height="98">
		    <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
            	<tr>
                	<td valign="top" dir="rtl" align="center">
                	    <asp:Label ID="LBPricePanel" runat="server" CssClass="meghdar" Text=""></asp:Label><label class="onvan">&nbsp;ريال</label>
                        <br />
                        <label class="onvanZirNevis">(بدون هزينه های جانبی)</label>
                    </td>
                </tr>
                <tr>
                	<td align="center" valign="bottom">
                	    <asp:HyperLink ID="HyperLink1" SkinID="FullBasketPL" NavigateUrl="~/PUsers/Basket.aspx" Visible="false" runat="server"></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" SkinID="EmptyBasketPL" NavigateUrl="~/PUsers/Basket.aspx" Visible="false" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </table>
		</td>
		<td rowspan="3">
			<img src="App_Themes/Space/images/Panel/top_05.jpg" width="12" height="98" alt=""></td>
		<td>
			<img src="App_Themes/Space/images/Panel/spacer.gif" width="1" height="48" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="App_Themes/Space/images/Panel/top_06.jpg" width="158" height="28" alt=""></td>
		<td background="App_Themes/Space/images/Panel/top_07.jpg" width="63" height="28" align="center">
		    <asp:Label ID="LBFilmNumber" runat="server" Text="0"></asp:Label>
		</td>
		<td>
			<img src="App_Themes/Space/images/Panel/top_08.jpg" width="52" height="28" alt=""></td>
		<td>
			<img src="App_Themes/Space/images/Panel/spacer.gif" width="1" height="28" alt=""></td>
	</tr>
	<tr>
		<td colspan="3" rowspan="2">
			<img src="App_Themes/Space/images/Panel/top_09.jpg" width="273" height="34" alt=""></td>
		<td>
			<img src="App_Themes/Space/images/Panel/spacer.gif" width="1" height="22" alt=""></td>
	</tr>
	<tr>
		<td colspan="2">
			<img src="App_Themes/Space/images/Panel/top_10.jpg" width="142" height="12" alt=""></td>
		<td>
			<img src="App_Themes/Space/images/Panel/spacer.gif" width="1" height="12" alt=""></td>
	</tr>
</table>
</asp:Panel>
<!-- Panel Buy -->

    <br />
        
    <div class="meteor"><h4>آخرين فيلمهای اضافه شده</h4></div>
        <asp:DataList ID="DLLastFilms" runat="server" RepeatColumns="4" RepeatDirection="horizontal">
            <ItemTemplate>
                <br />
                <asp:Panel CssClass="BorderImage" ID="Panel1" runat="server"><a href="#hdr" onclick="customFunctionCreateWindow('FilmDetail.aspx?FilmID=<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>&Page=index.aspx',535,490,350,50);return false"><img onmouseover="toolTip('<div align=right dir=rtl>نام فارسی:  <%#DataBinder.Eval(Container.DataItem, "fldFarsiName")%> <hr width=180px />نام اصلی:  <%#DataBinder.Eval(Container.DataItem, "fldEnglishName").ToString().Replace("'", " ")%> </div>' , '180')" onmouseout="toolTip()" src="<%#DataBinder.Eval(Container.DataItem, "fldPoster")%>" class="filmPicture"/></a></asp:Panel>
                
                <div dir="ltr" align="center">
                <script type="text/javascript" src="JScript/prototype.js"></script>
                <script type="text/javascript" src="JScript/stars.js"></script>
                <script type="text/javascript">
										var s3 = new Stars({
											maxRating: 5,
											actionURL: 'rate.aspx?FilmID=<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>&rating=',
											imagePath: 'images/',
											value: <%#CalculateRate(DataBinder.Eval(Container.DataItem, "fldSumVotes"), DataBinder.Eval(Container.DataItem, "fldCountVotes"))%>
										});
				</script>
                </div>
                
            </ItemTemplate>
        </asp:DataList>
</div>
</asp:Content>

