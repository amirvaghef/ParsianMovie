<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="SearchNResult.aspx.cs" Inherits="SearchNResult" Title="::Parsian Movie:: جستجو و ليست فيلمها"%>

<%@ Register TagPrefix="pgr" Namespace="CutePager" Assembly="ASPnetPagerV2netfx2_0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="lightstyle.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="JScript/floating-window.css" media="screen" type="text/css">
<script language="javascript" src="JScript/tooltip.js" type="text/javascript"></script>
<div id=toolTipLayer dir="ltr" style="VISIBILITY: hidden; POSITION: absolute"></div>
<script language="javascript"  type="text/javascript"><!--
    initToolTips();
 //-->
</script>
<script type="text/javascript" src="JScript/ajax.js"></script>
<script type="text/javascript" src="JScript/floating-window.js"></script>
<script type="text/javascript" src="JScript/prototype.js"></script>
<script type="text/javascript" src="JScript/stars.js"></script>
                                
    <asp:ObjectDataSource ID="KindOfferObjectDataSource" runat="server"
        DataObjectTypeName="Common.Data.SingleKindOfferDS" DeleteMethod="Update" InsertMethod="Update"
        SelectMethod="GetAll" TypeName="Business.KindOfferBL" UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceLanguage" runat="server" DataObjectTypeName="Common.Data.SingleLanguageDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.LanguageBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceSubtitles" runat="server" DataObjectTypeName="Common.Data.SingleSubtitlesDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.SubtitlesBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceGenre" runat="server" DataObjectTypeName="Common.Data.SingleGenreDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.GenreBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceCountryProduct" runat="server" DataObjectTypeName="Common.Data.SingleCountryProductDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.CountryProductBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceQuality" runat="server" DataObjectTypeName="Common.Data.SingleQualityDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.QualityBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceRank" runat="server" DataObjectTypeName="Common.Data.SingleRankDS"
        DeleteMethod="Update" InsertMethod="Update" SelectMethod="GetAll" TypeName="Business.RankBL"
        UpdateMethod="Update"></asp:ObjectDataSource>
        
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
        
            <asp:Panel ID="AccordionPaneSearch" runat="server">
                <asp:Panel ID="Header0" runat="server" CssClass="accordionHeader">
                    جستجوی پیشرفته
                </asp:Panel>
                <asp:Panel ID="Content0" runat="server" CssClass="accordionContent">
                    <table>
                        <tr>
                            <td>
                                نام اصلی فيلم:
                            </td>
                            <td align=right colspan="3" dir=ltr>
                                <asp:TextBox ID="TXTEnglishNameSearch" MaxLength="200" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                نام بازيگر:
                            </td>
                            <td align=right dir=ltr>
                                <input type="text" ID="TXTActorsSearch" MaxLength="200" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)">
                            </td>
                            <td>
                                نام كارگردان:
                            </td>
                            <td align=right dir=ltr>
                                <input type="text" ID="TXTDirectorSearch" MaxLength="100" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                سال توليد:
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TXTYearsOfProductSearch1" MaxLength="4" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                زيرنويس:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPSubtitlesSearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceSubtitles" DataTextField="fldSubtitlesName" DataValueField="fldSubtitlesID" AppendDataBoundItems="true">
                                    <asp:ListItem Selected="True" Text="" Value="">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                زبان فيلم:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPLanguageSearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceLanguage" DataTextField="fldLanguageName" DataValueField="fldLanguageID" AppendDataBoundItems="true">
                                   <asp:ListItem Selected="True" Text="" Value="">
                                   </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ژانر فيلم:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPGenreSearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceGenre" DataTextField="fldGenreName" DataValueField="fldGenreID" AppendDataBoundItems="true">
                                    <asp:ListItem Selected="True" Text="" Value="">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                محصول كشور:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPCountrySearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceCountryProduct" DataTextField="fldCountryProductName" DataValueField="fldCountryProductID" AppendDataBoundItems="true">
                                    <asp:ListItem Selected="True" Text="" Value="">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                نوع ارائه:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPKindOfferSearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="KindOfferObjectDataSource" DataTextField="fldKindOfferName" DataValueField="fldKindOfferID" AppendDataBoundItems="true">
                                    <asp:ListItem Selected="True" Text="" Value="">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                 درجه فيلم:
                            </td>
                            <td>
                                <asp:DropDownList ID="DRPRankSearch" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceRank" DataTextField="fldRankName" DataValueField="fldRankID" AppendDataBoundItems="true">
                                    <asp:ListItem Selected="True" Text="" Value="">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left">
                                <asp:CheckBox ID="CHAnd1" Checked="true" Text="جستجوی ترکیبی" TextAlign="Right" runat="server"/><br />
                                
                                <asp:ImageButton ID="IBAdvancedSearch" runat="server" SkinID="AdvancedSearchButton" OnClick="IBAdvancedSearch_Click" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <br />
            <asp:Panel ID="AccordionPaneResult" runat="server">
                <asp:Panel ID="Header" runat="server" CssClass="accordionHeader">
                    لیست فيلمها
                </asp:Panel>
                <asp:Panel ID="Content" runat="server" CssClass="accordionContent">
                    <div>
                    <pgr:Pager
                        OnCommand="pager_Command"
                        ShowFirstLast="true" EnableSmartShortCuts="true" 
                        id="pager1" FromClause="تا" GoClause="به" GoToLastClause="آخرین صفحه" NextToPageClause="رفتن به صفحه" ToClause="تا" ShowingResultClause="" ShowResultClause=""
                        runat="server" OfClause="از" PageClause="صفحه" BackToFirstClause="اولین صفحه" BackToPageClause="برگشت به صفحه" RTL="True">
                    </pgr:Pager>
                    </div>
                    <hr />
                    <asp:Label ID="LBError" runat="server" Text="هیچ عنوانی یافت نشد" Visible="false"></asp:Label>
                    
                    <asp:DataList ID="DataListFilms" Width="100%" runat="server" RepeatColumns="1" RepeatDirection="Vertical" OnDeleteCommand="FullBasketDataList_Click" OnUpdateCommand="EmptyBasketDataList_Click" RepeatLayout="Table">
                        <ItemTemplate>
                            <asp:Label ID="LBfldFilmID" runat="server" CssClass="meghdarList" Text='<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>' Visible="false"></asp:Label>
                            <div style="direction:rtl; text-align:center; float:right; width: 120px; z-index: 1; padding-left:9px; padding-top:5px" id="layer1">
                                <asp:Panel CssClass="BorderImage" ID="Panel1" runat="server"><a href="#hdr" onclick="customFunctionCreateWindow('FilmDetailWitoutBuy.aspx?FilmID=<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>',535,490,350,50);return false"><img onmouseover="toolTip('<div align=center dir=ltr><span dir=rtl align=center>نام بازیگران</span><hr width=180px /><%#DataBinder.Eval(Container.DataItem, "fldActors").ToString().Replace("'", " ")%> </div>' , '180')" onmouseout="toolTip()" src="<%#DataBinder.Eval(Container.DataItem, "fldPoster")%>" class="filmPicture"/></a></asp:Panel>
                                <div dir="ltr" align="center">
                                <script type="text/javascript">
										var s3 = new Stars({
											maxRating: 5,
											actionURL: 'rate.aspx?FilmID=<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>&rating=',
											imagePath: 'images/',
											value: <%#CalculateRate(DataBinder.Eval(Container.DataItem, "fldSumVotes"), DataBinder.Eval(Container.DataItem, "fldCountVotes"))%>
										});
				                </script>
                                </div>
                            </div>
                            <div style="direction:rtl; text-align:center; float:left; width: 120px; z-index: 1" id="Div1">
                                <asp:Label ID="LBSection" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "fldSection")%>'></asp:Label>
                                <label class="onvan">بخش</label>
                                <br />
                                <br />
                                <asp:Label ID="LBPrice" runat="server" CssClass="meghdarList" Text='<%#Eval("fldPrice","{0:#,###,###}")%>'></asp:Label>
                                <label class="onvan">ريال</label>
                                <br />
                                <asp:ImageButton ID="EmptyBasket" SkinID="EmptyBasket" runat="server" CommandName="Update" />
                                <asp:ImageButton ID="FullBasket" SkinID="FullBasket" runat="server" Visible="false" CommandName="Delete"/>
                            </div>
                            <asp:Label ID="LBFilmID" runat="server" CssClass="meghdarList" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>'></asp:Label>
                            <label class="onvan">نوع ارائه : </label>
                            <asp:Image ID="DVD" SkinID="DVD" runat="server" Visible='<%# Eval("fldKindOfferName").Equals("DVD") %>' />
                            <asp:Image ID="MKV" SkinID="MKV" runat="server" Visible='<%# Eval("fldKindOfferName").Equals("MKV") %>' />
                            <asp:Image ID="DIVX" SkinID="DIVX" runat="server" Visible='<%# Eval("fldKindOfferName").Equals("DIVX") %>' />
                            <br />
                            <br />
                            <label class="onvan">نام اصلی : </label>
                            <asp:Label ID="LBEnglishName" runat="server" CssClass="meghdarName" Text='<%#DataBinder.Eval(Container.DataItem, "fldEnglishName")%>'></asp:Label>                
                            <br />
                            <label class="onvan">نام فارسی : </label>
                            <asp:Label ID="LBFarsiName" runat="server" CssClass="meghdarName" Text='<%#DataBinder.Eval(Container.DataItem, "fldFarsiName")%>'></asp:Label>
                            <br />
                            <label class="onvan">سال توليد : </label>
                            <asp:Label ID="LBYearsOfProduct" runat="server" CssClass="meghdarYellow" Text='<%#DataBinder.Eval(Container.DataItem, "fldYearsOfProduct")%>'></asp:Label>
                            <br />
                            <label class="onvan">مدت زمان : </label>
                            <asp:Label ID="LBTime" runat="server" CssClass="meghdarList" Text='<%#DataBinder.Eval(Container.DataItem, "fldTime")%>'></asp:Label>
                            <br />
                            <label class="onvan">درجه فيلم : </label>
                            <asp:Label ID="LBRank" runat="server" CssClass="meghdarList" Text='<%#DataBinder.Eval(Container.DataItem, "fldRankName")%>'></asp:Label>
                            <br />
                            <label class="onvan">در Imdb (رتبه): </label>
                            <asp:Label ID="LBIMDBRating" runat="server" CssClass="meghdarYellow" Text='<%#DataBinder.Eval(Container.DataItem, "fldIMDBRating")%>'></asp:Label>
                            <br />
                            <label class="onvan">كيفيت فيلم : </label>
                            <asp:Label ID="LBQuality" runat="server" CssClass="meghdarList" Text='<%#DataBinder.Eval(Container.DataItem, "fldQualityName")%>'></asp:Label>
                            <br />
                            <label class="onvan">زيرنويس : </label>
                            <asp:DataList ID="DLSubtitles" runat="server" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <label class="meghdarBlue"><%#DataBinder.Eval(Container.DataItem,"fldSubtitlesName")%></label>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <label class="meghdar">,</label>
                                </SeparatorTemplate>
                            </asp:DataList>
                            <br />
                            <div align="center">
                                <a href="#hdr" onclick="customFunctionCreateWindow('FilmDetailWitoutBuy.aspx?FilmID=<%#DataBinder.Eval(Container.DataItem, "fldFilmID")%>',535,490,350,50);return false">[+جزئيات]</a>
                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <hr />
                        </SeparatorTemplate>
                    </asp:DataList>
                    
                    <hr />
                    <div>
                    <pgr:Pager
                        OnCommand="pager_Command"
                        ShowFirstLast="true" EnableSmartShortCuts="true" 
                        id="pager2" FromClause="تا" GoClause="به" GoToLastClause="آخرین صفحه" NextToPageClause="رفتن به صفحه" ToClause="تا" ShowingResultClause="" ShowResultClause=""
                        runat="server" OfClause="از" PageClause="صفحه" BackToFirstClause="اولین صفحه" BackToPageClause="برگشت به صفحه" RTL="True">
                    </pgr:Pager>
                    </div>
                </asp:Panel>
            </asp:Panel>
</div>
</asp:Content>