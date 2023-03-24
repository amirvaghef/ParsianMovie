<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilmDetailWitoutBuy.aspx.cs" Inherits="FilmDetailWitoutBuy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>جزئیات</title>
</head>

<body dir="rtl">
    <form id="form1" runat="server">
    <div align="center" class="body">
        
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:Panel runat="server" CssClass="modalPopup2" ID="FilmDetailPopup" style="width:490px;height:auto;padding:10px; text-align:right;">
            <div style="direction:rtl; text-align:center; float:left; width: 120px; z-index: 1" id="layer1">
                <asp:Label ID="LBTime" runat="server" CssClass="meghdar" Text=""></asp:Label>
                <label class="onvan">ساعت</label>
                <br />
                <img runat="server" id="Picture" class="filmPicture"/>
                <br />
                <asp:Label ID="LBSection" runat="server" CssClass="onvanBold" Text=""></asp:Label>
                <label class="onvan">بخش</label>
                <br />
                <asp:Label ID="LBPrice" runat="server" CssClass="meghdarOrange" Text=""></asp:Label>
                <label class="onvan">ريال</label>
            </div>
            <asp:Label ID="LBFilmID" runat="server" CssClass="meghdar" Visible="false" Text=""></asp:Label>
            <label class="onvan">نوع ارائه : </label>
            <asp:Image ID="DVD" SkinID="DVD" runat="server" Visible="false" />
            <asp:Image ID="MKV" SkinID="MKV" runat="server" Visible="false" />
            <asp:Image ID="DIVX" SkinID="DIVX" runat="server" Visible="false" />
            <br />
            <br />
            <label class="onvan">نام اصلی : </label>
            <asp:Label ID="LBEnglishName" runat="server" CssClass="meghdarName" Text=""></asp:Label>                
            <br />
            <label class="onvan">نام فارسی : </label>
            <asp:Label ID="LBFarsiName" runat="server" CssClass="meghdarName" Text=""></asp:Label>
            <br />
            <label class="onvan">سال توليد : </label>
            <asp:Label ID="LBYearsOfProduct" runat="server" CssClass="meghdarBlue" Text=""></asp:Label>
            <br />
            <label class="onvan">محصول كشور : </label>
            <asp:Label ID="LBCountryProduct" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <label class="onvan">درجه فيلم : </label>
            <asp:Label ID="LBRank" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <label class="onvan">كيفيت فيلم : </label>
            <asp:Label ID="LBQuality" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <label class="onvan">در Imdb (رتبه): </label>
            <asp:Label ID="LBIMDBRating" runat="server" CssClass="meghdarBlue" Text=""></asp:Label>
            <br />
            <label class="onvan">كارگردان : </label>
            <asp:Label ID="LBDirector" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <label class="onvan">بازيگران : </label>
            <asp:Label ID="LBActors" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <br />
            <label class="onvan">زيرنويس : </label>
            <br />
            <asp:DataList ID="DLSubtitles" runat="server" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <label class="meghdarBlue"><%#DataBinder.Eval(Container.DataItem,"fldSubtitlesName")%></label>
                </ItemTemplate>
                <SeparatorTemplate>
                    <label class="meghdar">,</label>
                </SeparatorTemplate>
            </asp:DataList>
            <label class="onvan">ژانر : </label>
            <br />
            <asp:DataList ID="DLGenre" runat="server" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <label class="meghdarBlue"><%#DataBinder.Eval(Container.DataItem,"fldGenreName")%></label>
                </ItemTemplate>
                <SeparatorTemplate>
                    <label class="meghdar">,</label>
                </SeparatorTemplate>
            </asp:DataList>
            <label class="onvan">زبان : </label>
            <br />
            <asp:DataList ID="DLLanguage" runat="server" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <label class="meghdarBlue"><%#DataBinder.Eval(Container.DataItem,"fldLanguageName")%></label>
                </ItemTemplate>
                <SeparatorTemplate>
                    <label class="meghdar">,</label>
                </SeparatorTemplate>
            </asp:DataList>
            <br />
            <label class="onvan">خلاصه : </label>
            <br />
            <asp:Label ID="LBAbstract" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <label class="onvan">حرف ما با شما : </label>
            <br />
            <asp:Label ID="LBComment" runat="server" CssClass="meghdar" Text=""></asp:Label>
            <br />
            <br />
            <div align="center">
            <asp:HyperLink ID="HLInformation" Target="_blank" runat="server">[+اطلاعات بيشتر]</asp:HyperLink>
            </div>
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
