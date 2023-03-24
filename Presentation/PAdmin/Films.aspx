<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Films.aspx.cs" Inherits="PAdmin_Films" Title="::ParsianMovie:: ويرايش فيلم" Theme="Space" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
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
        
    <cc1:Accordion runat="server" ID="AccordionFilms" SelectedIndex="0"
        HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent" AutoSize="None" RequireOpenedPane="false" 
        SuppressHeaderPostbacks="true">
        <Panes>
            <cc1:AccordionPane runat="server" ID="AccordionPaneInsert">
                <Header>
                    درج
                </Header>
                <Content>
                    <asp:UpdatePanel ID="UpdatePanelInsert" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BTSubmit" />
                            <asp:PostBackTrigger ControlID="OKTwiceModalPopupViaServer" />
                        </Triggers>
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        نوع ارائه:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RBLKindOffer" Text="*" runat="server" ValidationGroup="insert" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList ID="RBLKindOffer" runat="server" RepeatDirection="Horizontal" DataSourceID="KindOfferObjectDataSource" DataTextField="fldKindOfferName" DataValueField="fldKindOfferID" ValidationGroup="insert">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام فارسی فيلم:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TXTFarsiName" Text="*" runat="server" ValidationGroup="insert" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <input type="text" ID="TXTFarsiName" MaxLength="200" size="18" runat="server" class="inputbox" onkeypress="keyenterall(this,event)" >
                                    </td>
                                    <td>
                                       نام انگليسی فيلم:
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TXTEnglishName" Text="*" runat="server" ValidationGroup="insert" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" dir="ltr">
                                        <asp:TextBox ID="TXTEnglishName" MaxLength="200" Width="140" runat="server" CssClass="inputbox" ValidationGroup="insert"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام بازيگران:
                                    </td>
                                    <td colspan="3"  align="right" dir="ltr">
                                        <input type="text" ID="TXTActors" MaxLength="500" size="60" runat="server" class="inputbox" onkeypress="keyentersome(this,event)" >
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام كارگردان:
                                    </td>
                                    <td  align="right" dir="ltr">
                                        <input type="text" ID="TXTDirector" MaxLength="100" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)" >
                                    </td>
                                    <td>
                                        سال توليد:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTYearsOfProduct1" MaxLength="4" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="TXTYearsOfProduct" runat="server" TargetControlID="TXTYearsOfProduct1" FilterType="Numbers" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        رتبه در IMDB:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTIMDBRating1" MaxLength="5" Width="140" runat="server" CssClass="inputbox" Text="0"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="TXTIMDBRating" runat="server" TargetControlID="TXTIMDBRating1" FilterType="Custom, Numbers" ValidChars="." />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        پوستر:
                                    </td>
                                    <td colspan="3">
                                        <asp:FileUpload ID="FUPoster" Width="390" CssClass="inputbox" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        زبانها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLLanguages" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceLanguage" DataTextField="fldLanguageName" DataValueField="fldLanguageID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        زيرنويس ها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLSubtitles" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceSubtitles" DataTextField="fldSubtitlesName" DataValueField="fldSubtitlesID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        ژانرها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLGenre" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceGenre" DataTextField="fldGenreName" DataValueField="fldGenreID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        خلاصه فيلم:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTAbstract" MaxLength="4000" Width="387" TextMode="MultiLine" runat="server" CssClass="inputbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        تعداد بخش ها:
                                    </td>
                                    <td dir="ltr" align="right">
                                        <asp:TextBox ID="TXTSection1" runat="server" Text="2" Width="140" CssClass="inputbox" />
                                        <cc1:NumericUpDownExtender ID="TXTSection" runat="server" TargetControlID="TXTSection1" Width="140" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID="" TargetButtonUpID="" Minimum = "1" Maximum = "50" />
                                    </td>
                                    <td>
                                        مدت زمان:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTTime1" runat="server" Width="140px" CssClass="inputbox"/>
                                        <cc1:MaskedEditExtender ID="TXTTime" runat="server" TargetControlID="TXTTime1" 
                                            InputDirection="RightToLeft"
                                            Mask="99:99"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            AcceptAMPM="True"
                                            ErrorTooltipEnabled="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="ltr">
                                        اطلاعات بيشتر:
                                        <div class="helpbox">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ErrorMessage="<b>خطای ورود اطلاعات</b><br /><br />لطفاً نام سايت را در فرمت درست وارد نمائيد<br />http://www.site.com"
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ControlToValidate="TXTInformation"></asp:RegularExpressionValidator>
                                        <cc1:ValidatorCalloutExtender runat="Server" ID="RegularExpressionValidatorAjax"
                                            TargetControlID="RegularExpressionValidator1"
                                            HighlightCssClass="validatorCalloutHighlight"/>
                                        </div>
                                    </td>
                                    <td align="right" dir="ltr">
                                        <asp:TextBox ID="TXTInformation" MaxLength="200" Width="140" runat="server" CssClass="inputbox" ValidationGroup="insert"></asp:TextBox>
                                    </td>
                                    <td>
                                        محصول كشور:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPCountry" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceCountryProduct" DataTextField="fldCountryProductName" DataValueField="fldCountryProductID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        كيفيت:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPQuality" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceQuality" DataTextField="fldQualityName" DataValueField="fldQualityID">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        درجه فيلم:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPRank" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceRank" DataTextField="fldRankName" DataValueField="fldRankID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        قيمت(ريال):
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTPrice1" runat="server" CssClass="inputbox" Width="140" ValidationGroup="insert"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="TXTPrice" runat="server" TargetControlID="TXTPrice1"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative="None"
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <cc1:MaskedEditValidator ID="ValidatorTXTPrice" ValidationGroup="insert" runat="server"
                                            ControlExtender="TXTPrice"
                                            ControlToValidate="TXTPrice1"
                                            IsValidEmpty="False"
                                            MaximumValue="3000000"
                                            EmptyValueMessage="عدد نياز است"
                                            InvalidValueMessage="عدد قابل قبول است"
                                            MaximumValueMessage="بزرگترين 3,000,000 است"
                                            MinimumValueMessage="كوچكترين صفر است"
                                            MinimumValue="0"
                                            Display="Dynamic"
                                            TooltipMessage="عددي بين صفر تا 3,000,000 وارد نمائيد"
                                            EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="*"
                                            MaximumValueBlurredMessage="*"
                                            MinimumValueBlurredText="*" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TXTPrice1" Text="*" runat="server" ValidationGroup="insert" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        توضيحات:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTComment" MaxLength="4000" TextMode="MultiLine" runat="server" Width="387" CssClass="inputbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                     <hr width="80%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="BTSubmit" SkinID="SubmitButton" runat="server" ValidationGroup="insert" OnClick="BTSubmit_Click" />
                                    </td>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="BTReset" SkinID="ResetButton" runat="server" CausesValidation="false" OnClick="BTReset_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            
                                <asp:Button runat="server" ID="InsertHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="InsertModalPopup"
                                    TargetControlID="InsertHiddenTargetControlForModalPopup"
                                    PopupControlID="InsertPopup" 
                                    BackgroundCssClass="modalBackground"
                                    DropShadow="True"
                                    PopupDragHandleControlID="InsertPopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="InsertPopup" style="display:none;width:350px;padding:10px">
                                    <asp:Panel runat="Server" ID="InsertPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        درج
                                    </asp:Panel>
                                    <br />
                                    فیلم به شماره  <asp:Label ID="fldFilmIDInsert" runat="server" Text=""></asp:Label>  به درستی درح شد
                                    <br />
                                    عمل درج با موفقيت انجام شد
                                    <br />
                                    <p align="center">
                                    <asp:Button runat="server" Width="80px" ID="hideInsertModalPopupViaServer" CausesValidation="false" Text="ادامه" OnClick="hideInsertModalPopupViaServer_Click" />
                                    </p>
                                </asp:Panel>
                                
                                <asp:Button runat="server" ID="TwiceHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="TwiceModalPopup"
                                    TargetControlID="TwiceHiddenTargetControlForModalPopup"
                                    PopupControlID="TwicePopup" 
                                    BackgroundCssClass="modalBackground"
                                    DropShadow="True"
                                    PopupDragHandleControlID="TwicePopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="TwicePopup" style="display:none;width:490px;height:auto;padding:10px; text-align:right;">
                                    <asp:Panel runat="Server" ID="TwicePopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        <asp:Label ID="CountTwice" runat="server"></asp:Label> عدد تكراری
                                    </asp:Panel>
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
                                    <table align="center">
                                        <tr>
                                            <td align="center">
                                                <asp:Button runat="server" Width="80px" ID="OKTwiceModalPopupViaServer" CausesValidation="false" Text="بلی" OnClick="OKTwiceModalPopupViaServer_Click" />
                                            </td>
                                            <td align="center">
                                                <asp:Button runat="server" Width="80px" ID="CancelTwiceModalPopupViaServer" CausesValidation="false" Text="خير" OnClick="CancelTwiceModalPopupViaServer_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane runat="server" ID="AccordionPaneUpdate">
                <Header>
                    به روزرسانی
                </Header>
                <Content>
                    <asp:UpdatePanel ID="UpdatePanelUpdate" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BTUpdate" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:MultiView ID="MultiViewSearch" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vAdvancedSearch" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                نام اصلی فيلم:
                                            </td>
                                            <td align="right" colspan="3" dir="ltr">
                                                <asp:TextBox ID="TXTEnglishNameSearch" MaxLength="200" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                نام بازيگر:
                                            </td>
                                            <td align="right" dir="ltr">
                                                <input type="text" ID="TXTActorsSearch" MaxLength="200" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)">
                                            </td>
                                            <td>
                                                نام كارگردان:
                                            </td>
                                            <td align="right" dir="ltr">
                                                <input type="text" ID="TXTDirectorSearch" MaxLength="100" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                سال توليد:
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="TXTYearsOfProductSearch1" MaxLength="4" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="TXTYearsOfProductSearch" runat="server" TargetControlID="TXTYearsOfProductSearch1" FilterType="Numbers" />
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
                                                <asp:CheckBox ID="CHAnd1" Checked="true" Text="" TextAlign="right" runat="server"/><br />
                                                <cc1:ToggleButtonExtender ID="CHAnd" runat="server" 
                                                    TargetControlID="CHAnd1"
                                                    SkinID="CHAndSearch" />
                                                <asp:ImageButton ID="IBAdvancedSearch" runat="server" SkinID="AdvancedSearchButton" OnClick="IBAdvancedSearch_Click" CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vResult" runat="server">
                                    <table width="100%">
                                    <tr>
                                    <td align="left">
                                        <asp:LinkButton ID="LBSearchBack2" runat="server" OnClick="LBSearchBack_Click" CausesValidation="false">جستجو</asp:LinkButton>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td width="100%">
                                    <asp:GridView ID="GridViewFilm" runat="server" AllowPaging="True" PageSize="25" AllowSorting="True" OnPageIndexChanging="GridViewFilm_PageIndexChanging" OnRowDeleting="GridViewFilm_RowDeleting" OnRowEditing="GridViewFilm_RowEditing" OnSorting="GridViewFilm_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="اعمال">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="BTGridDelete" Text="حذف" runat="server" CausesValidation="false" CommandName="Delete"/>
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderDelete" runat="server" 
                                                        TargetControlID="BTGridDelete"
                                                        ConfirmText="آیا از پاك كردن اين سطر مطمئن هستيد؟" />
                                                    <asp:LinkButton ID="BTGridEdit" Text="تغيير" runat="server" CausesValidation="false" CommandName="Edit"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="fldFilmID" HeaderText="رديف" SortExpression="fldFilmID" />
                                            <asp:BoundField DataField="fldKindOfferName" HeaderText="نوع ارائه" SortExpression="fldKindOfferName" />
                                            <asp:BoundField DataField="fldFarsiName" HeaderText="نام فارسی" SortExpression="fldFarsiName" />
                                            <asp:BoundField DataField="fldEnglishName" HeaderText="نام اصلی" SortExpression="fldEnglishName" />
                                            <asp:BoundField DataField="fldCountryProductName" HeaderText="محصول كشور" SortExpression="fldCountryProductName" />
                                            <asp:BoundField DataField="fldYearsOfProduct" HeaderText="سال توليد" SortExpression="fldYearsOfProduct" />
                                        </Columns>
                                    </asp:GridView>
                                    </td>
                                    </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vUpdate" runat="server">
                                    <table>
                                <tr>
                                    <td>
                                        شماره فيلم:
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TXTfldFilmID" Width="140" runat="server" CssClass="disableinputbox" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="LBSearchBack1" runat="server" OnClick="LBSearchBack_Click" CausesValidation="false">جستجو</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نوع ارائه:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RBLKindOfferUpdate" Text="*" runat="server" ValidationGroup="update" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList ID="RBLKindOfferUpdate" runat="server" RepeatDirection="Horizontal" DataSourceID="KindOfferObjectDataSource" DataTextField="fldKindOfferName" DataValueField="fldKindOfferID" ValidationGroup="update">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام فارسی فيلم:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TXTFarsiNameUpdate" Text="*" runat="server" ValidationGroup="update" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <input type="text" ID="TXTFarsiNameUpdate" MaxLength="200" size="18" runat="server" class="inputbox" onkeypress="keyenterall(this,event)" >
                                    </td>
                                    <td>
                                       نام انگليسی فيلم:
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="TXTEnglishNameUpdate" Text="*" runat="server" ValidationGroup="update" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" dir="ltr">
                                        <asp:TextBox ID="TXTEnglishNameUpdate" MaxLength="200" Width="140" runat="server" CssClass="inputbox" ValidationGroup="update"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام بازيگران:
                                    </td>
                                    <td colspan="3"  align="right" dir="ltr">
                                        <input type="text" ID="TXTActorsUpdate" MaxLength="500" size="60" runat="server" class="inputbox" onkeypress="keyentersome(this,event)" >
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        نام كارگردان:
                                    </td>
                                    <td  align="right" dir="ltr">
                                        <input type="text" ID="TXTDirectorUpdate" MaxLength="100" size="18" runat="server" class="inputbox" onkeypress="keyentersome(this,event)" >
                                    </td>
                                    <td>
                                        سال توليد:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTYearsOfProductUpdate1" MaxLength="4" Width="140" runat="server" CssClass="inputbox"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="TXTYearsOfProductUpdate" runat="server" TargetControlID="TXTYearsOfProductUpdate1" FilterType="Numbers" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        رتبه در IMDB:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTIMDBRatingUpdate1" MaxLength="5" Width="140" runat="server" CssClass="inputbox" Text="0"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="TXTIMDBRatingUpdate" runat="server" TargetControlID="TXTIMDBRatingUpdate1" FilterType="Custom, Numbers" ValidChars="." />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        پوستر:
                                    </td>
                                    <td colspan="3">
                                        <asp:FileUpload ID="FUPosterUpdate" Width="390" CssClass="inputbox" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        زبانها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLLanguagesUpdate" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceLanguage" DataTextField="fldLanguageName" DataValueField="fldLanguageID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        زيرنويس ها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLSubtitlesUpdate" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceSubtitles" DataTextField="fldSubtitlesName" DataValueField="fldSubtitlesID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        ژانرها:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBoxList ID="CHLGenreUpdate" runat="server" RepeatColumns="5" DataSourceID="ObjectDataSourceGenre" DataTextField="fldGenreName" DataValueField="fldGenreID">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        خلاصه فيلم:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTAbstractUpdate" MaxLength="4000" Width="387" TextMode="MultiLine" runat="server" CssClass="inputbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        تعداد بخش ها:
                                    </td>
                                    <td dir="ltr" align="right">
                                        <asp:TextBox ID="TXTSectionUpdate1" runat="server" Text="2" Width="140" CssClass="inputbox" />
                                        <cc1:NumericUpDownExtender ID="TXTSectionUpdate" runat="server" TargetControlID="TXTSectionUpdate1" Width="140" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID="" TargetButtonUpID="" Minimum = "1" Maximum = "50" />
                                    </td>
                                    <td>
                                        مدت زمان:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTTimeUpdate1" runat="server" Width="140px" CssClass="inputbox"/>
                                        <cc1:MaskedEditExtender ID="TXTTimeUpdate" runat="server" TargetControlID="TXTTimeUpdate1" 
                                            InputDirection="RightToLeft"
                                            Mask="99:99"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            AcceptAMPM="True"
                                            ErrorTooltipEnabled="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="ltr">
                                        اطلاعات بيشتر:
                                        <div class="helpbox">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorUpdate1" runat="server" Display="None" ErrorMessage="<b>خطای ورود اطلاعات</b><br /><br />لطفاً نام سايت را در فرمت درست وارد نمائيد<br />http://www.site.com"
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ControlToValidate="TXTInformationUpdate"></asp:RegularExpressionValidator>
                                        <cc1:ValidatorCalloutExtender runat="Server" ID="RegularExpressionValidatorAjaxUpdate"
                                            TargetControlID="RegularExpressionValidatorUpdate1"
                                            HighlightCssClass="validatorCalloutHighlight" />
                                         </div>
                                    </td>
                                    <td align="right" dir="ltr">
                                        <asp:TextBox ID="TXTInformationUpdate" MaxLength="200" Width="140" runat="server" CssClass="inputbox" ValidationGroup="update"></asp:TextBox>
                                    </td>
                                    <td>
                                        محصول كشور:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPCountryUpdate" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceCountryProduct" DataTextField="fldCountryProductName" DataValueField="fldCountryProductID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        كيفيت:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPQualityUpdate" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceQuality" DataTextField="fldQualityName" DataValueField="fldQualityID">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        درجه فيلم:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DRPRankUpdate" runat="server" Width="145" CssClass="inputbox" DataSourceID="ObjectDataSourceRank" DataTextField="fldRankName" DataValueField="fldRankID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        قيمت(ريال):
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTPriceUpdate1" runat="server" CssClass="inputbox" Width="140" ValidationGroup="update"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="TXTPriceUpdate" runat="server" TargetControlID="TXTPriceUpdate1"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative="None"
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <cc1:MaskedEditValidator ID="ValidatorTXTPriceUpdate" ValidationGroup="update" runat="server"
                                            ControlExtender="TXTPriceUpdate"
                                            ControlToValidate="TXTPriceUpdate1"
                                            IsValidEmpty="False"
                                            MaximumValue="3000000"
                                            EmptyValueMessage="عدد نياز است"
                                            InvalidValueMessage="عدد قابل قبول است"
                                            MaximumValueMessage="بزرگترين 3,000,000 است"
                                            MinimumValueMessage="كوچكترين صفر است"
                                            MinimumValue="0"
                                            Display="Dynamic"
                                            TooltipMessage="عددي بين صفر تا 3,000,000 وارد نمائيد"
                                            EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="*"
                                            MaximumValueBlurredMessage="*"
                                            MinimumValueBlurredText="*" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TXTPriceUpdate1" Text="*" runat="server" ValidationGroup="update" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        توضيحات:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TXTCommentUpdate" MaxLength="4000" TextMode="MultiLine" runat="server" Width="387" CssClass="inputbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                     <hr width="80%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton ID="BTUpdate" SkinID="UpdateButton" runat="server" ValidationGroup="update" OnClick="BTUpdate_Click"/>
                                                </td>
                                                <td align="center">
                                                    <asp:ImageButton ID="BTDelete" SkinID="DeleteButton" runat="server" CausesValidation="false" OnClick="BTDelete_Click"/>
                                                </td>
                                                <td align="center">
                                                    <asp:ImageButton ID="BTCancel" SkinID="CancelButton" runat="server" CausesValidation="false" OnClick="BTCancel_Click"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                </table>
                                </asp:View>
                            </asp:MultiView>
                            
                                <asp:Button runat="server" ID="DeleteHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="DeleteModalPopup"
                                    TargetControlID="DeleteHiddenTargetControlForModalPopup"
                                    PopupControlID="DeletePopup" 
                                    BackgroundCssClass="modalBackground"
                                    OkControlID="hideDeleteModalPopupViaServer"
                                    DropShadow="True"
                                    PopupDragHandleControlID="DeletePopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="DeletePopup" style="display:none;width:350px;padding:10px">
                                    <asp:Panel runat="Server" ID="DeletePopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        حذف
                                    </asp:Panel>
                                    <br />
                                    عمل حذف با موفقيت انجام شد
                                    <br />
                                    <p align="center">
                                    <asp:Button runat="server" Width="80px" ID="hideDeleteModalPopupViaServer" CausesValidation="false" Text="ادامه" OnClick="hideDeleteModalPopupViaServer_Click" />
                                    </p>
                                </asp:Panel>
                                
                                <asp:Button runat="server" ID="UpdateHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="UpdateModalPopup"
                                    TargetControlID="UpdateHiddenTargetControlForModalPopup"
                                    PopupControlID="UpdatePopup" 
                                    BackgroundCssClass="modalBackground"
                                    OkControlID="hideUpdateModalPopupViaServer"
                                    DropShadow="True"
                                    PopupDragHandleControlID="UpdatePopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="UpdatePopup" style="display:none;width:350px;padding:10px">
                                    <asp:Panel runat="Server" ID="UpdatePopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        به روز رسانی
                                    </asp:Panel>
                                    <br />
                                    عمل به روز رسانی با موفقيت انجام شد
                                    <br />
                                    <p align="center">
                                    <asp:Button runat="server" Width="80px" ID="hideUpdateModalPopupViaServer" CausesValidation="false" Text="ادامه" OnClick="hideUpdateModalPopupViaServer_Click" />
                                    </p>
                                </asp:Panel>
                                
                                <asp:Button runat="server" ID="WithoutHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="WithoutModalPopup"
                                    TargetControlID="WithoutHiddenTargetControlForModalPopup"
                                    PopupControlID="WithoutPopup" 
                                    BackgroundCssClass="modalBackground"
                                    OkControlID="hideWithoutModalPopupViaServer"
                                    DropShadow="True"
                                    PopupDragHandleControlID="WithoutPopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="WithoutPopup" style="display:none;width:350px;padding:10px">
                                    <asp:Panel runat="Server" ID="WithoutPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        جستجو
                                    </asp:Panel>
                                    <br />
                                    هيچ موردی يافت نشد
                                    <br />
                                    <p align="center">
                                    <asp:Button runat="server" Width="80px" ID="hideWithoutModalPopupViaServer" CausesValidation="false" Text="ادامه" OnClick="hideWithoutModalPopupViaServer_Click" />
                                    </p>
                                </asp:Panel>
                                
                                <input id="Hidden1" runat="server" type="hidden" value="fldFilmID ASC" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
    </div>
</asp:Content>