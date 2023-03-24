<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LastBought.aspx.cs" Inherits="PUsers_LastBought" Title="::ParsianMovie:: خریدهای قبلی" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
            <tr>
                <td>
                <asp:GridView ID="GWFilms" runat="server" AllowPaging="True" PageSize="50" OnPageIndexChanging="GWFilms_PageIndexChanging" OnRowEditing="GWFilms_RowEditing">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table width="100%">
                                <tr>
                                    <td width="9%"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                    <td width="8%"><asp:Label ID="Label5" runat="server" Text='نوع' /></td>
                                    <td width="33%"><asp:Label ID="Label2" runat="server" Text='نام اصلی' /></td>
                                    <td width="33%"><asp:Label ID="Label3" runat="server" Text='نام فارسی' /></td>
                                    <td width="7%"><asp:Label ID="Label4" runat="server" Text='تعداد بخش' /></td>
                                    <td width="10%"><asp:Label ID="Label6" runat="server" Text='قیمت' /></td>
                                </tr>
                             </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Panel ID="Panel9" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td width="9%"><asp:Label ID="LBfldFilmID" runat="server" Text='<%# Eval("fldFilmID") %>' /></td>
                                        <td width="8%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldKindOfferName") %>' /></td>
                                        <td width="33%"><asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("fldEnglishName") %>' CausesValidation="false" CommandName="Edit"></asp:LinkButton></td>
                                        <td width="33%"><asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("fldFarsiName") %>' CausesValidation="false" CommandName="Edit"></asp:LinkButton></td>
                                        <td width="7%"><asp:Label ID="Label4" runat="server" Text='<%# Eval("fldSection") %>' /></td>
                                        <td width="10%"><asp:Label ID="Label6" runat="server" Text='<%# Eval("fldPrice","{0:#,###,###}") %>' /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ItemTemplate>
                        <ItemStyle BorderWidth="1px" />
                        <HeaderStyle BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </td>
            </tr>
        </table> 
        
        <asp:Button runat="server" ID="FilmDetailHiddenTargetControlForModalPopup" style="display:none"/>
        <cc1:ModalPopupExtender runat="server" ID="FilmDetailModalPopup"
        TargetControlID="FilmDetailHiddenTargetControlForModalPopup"
        PopupControlID="FilmDetailPopup" 
        BackgroundCssClass="modalBackground"
        DropShadow="True"
        CancelControlID="btnClose"
        PopupDragHandleControlID="FilmDetailPopupDragHandle" >
        </cc1:ModalPopupExtender>    
        <asp:Panel runat="server" CssClass="modalPopup" ID="FilmDetailPopup" style="display:none;width:490px;height:auto;padding:10px; text-align:right;">
            <table>
                <tr style="background-color:#DDDDDD;">
                    <td width="1%" dir="ltr">
                        <div id="btnCloseParent" style="border:solid 1px black; float: right; opacity: 50; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=50);">
                            <asp:LinkButton id="btnClose" runat="server" CausesValidation="false" Text="X" ToolTip="Close"
                             Style="background-color: #666666; color: #FFFFFF;text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;"/>
                        </div>        
                    </td>
                    <td width="99%">
                        <asp:Panel runat="Server" ID="FilmDetailPopupDragHandle" Style="cursor: move;border:solid 1px Gray;color:Black;text-align:center;">
                            جزئيات
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br />
            <div style="direction:rtl; text-align:center; float:left; width: 120px; z-index: 1" id="layer1">
                <asp:Label ID="LBTime" runat="server" CssClass="meghdar" Text=""></asp:Label>
                <label class="onvan">ساعت</label>
                <br />
                <img runat="server" id="Picture" class="filmPicture"/>
                <br />
                <asp:Label ID="LBSection" runat="server" CssClass="onvanBold" Text=""></asp:Label>
                <label class="onvan">بخش</label>
                <br />
                <div align=right>
                <label class="onvan">نظر شما</label>
                <cc1:Rating ID="YourRating" runat="server" BehaviorID="RatingBehavior1"
                    MaxRating="5"
                    StarCssClass="ratingStar"
                    WaitingStarCssClass="savedRatingStar"
                    FilledStarCssClass="filledRatingStar"
                    EmptyStarCssClass="emptyRatingStar"
                    OnChanged="YourRating_Changed"
                    AutoPostBack="false"
                    style="float: left; position:absolute"/>
                </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

