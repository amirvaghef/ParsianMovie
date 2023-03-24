<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="PUsers_Basket" Title="::ParsianMovie:: سبد خرید" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="لطفاً شماره فیلم را وارد نمائید" ControlToValidate="TXTFilmID" ValidationGroup="insert">*</asp:RequiredFieldValidator>
                    شماره فیلم : <asp:TextBox ID="TXTFilmID" runat="server" MaxLength="4" Width="100px" ValidationGroup="insert"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="TXTFilmID1" runat="server" TargetControlID="TXTFilmID" FilterType="Numbers" />
                    <asp:LinkButton ID="LBInsertFilm" runat="server" OnClick="LBInsertFilm_OnClick"  ValidationGroup="insert">درج در سبد</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                <asp:GridView ID="GWFilms" runat="server" OnRowDeleting="GWFilms_RowDeleting">
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
                            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                <div>
                                    <div><asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" CommandName="Delete" Text="Delete" /></div>
                                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtenderDelete" runat="server" 
                                                                    TargetControlID="LinkButton2"
                                                                    ConfirmText="آیا از پاك كردن اين سطر مطمئن هستيد؟" />
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel9" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td width="9%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldFilmID") %>' /></td>
                                        <td width="8%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldKindOfferName") %>' /></td>
                                        <td width="33%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldEnglishName") %>' /></td>
                                        <td width="33%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldFarsiName") %>' /></td>
                                        <td width="7%"><asp:Label ID="Label4" runat="server" Text='<%# Eval("fldSection") %>' /></td>
                                        <td width="10%"><asp:Label ID="Label6" runat="server" Text='<%# Eval("fldPrice","{0:#,###,###}") %>' /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                    PopupControlID="PopupMenu"
                                    PopupPosition="Left"
                                    TargetControlID="Panel9"
                                    PopDelay="25" />
                        </ItemTemplate>
                        <ItemStyle BorderWidth="1px" />
                        <HeaderStyle BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left">
                    قیمت فیلم ها : <asp:Label ID="LBPriceFilms" runat="server" Text="0"></asp:Label> ریال
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً نوع ارسال را انتخاب نمائید" ControlToValidate="RBLTransmissionKind">*</asp:RequiredFieldValidator>
                    نوع ارسال: <asp:RadioButtonList ID="RBLTransmissionKind" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLTransmissionKind_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    قیمت ارسال : <asp:Label ID="LBPriceTransmissionKind" runat="server" Text="0"></asp:Label> ریال
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RBLDVDKind"
                        ErrorMessage="لطفاً نوع دی وی دی را انتخاب نمائید">*</asp:RequiredFieldValidator>نوع دی وی دی: <asp:RadioButtonList ID="RBLDVDKind" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLDVDKind_SelectedIndexChanged">
                    </asp:RadioButtonList>
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
                    <asp:Label ID="Label7" CssClass="onvanZirNevis" runat="server" Text="*در صورت خرید VCD آنها بر روی بهترین نوع CD موجود رایت می شود و قیمت آن با قیمت فیلم محاسبه می شود."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RBLPaymentWay"
                        ErrorMessage="لطفاً روش پرداخت را انتخاب نمائید">*</asp:RequiredFieldValidator>روش پرداخت: <asp:RadioButtonList ID="RBLPaymentWay" runat="server" AutoPostBack="false" OnSelectedIndexChanged="RBLPaymentWay_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    مبلغ کل پرداختی : <asp:Label ID="LBPriceKol" runat="server" Text="0"></asp:Label> ریال
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageButton SkinID="BuyButton" ID="IBBuy" runat="server" OnClick="IBBuy_Click" />
                </td>
            </tr>
            <tr>
                <td>
                <br />
                    یوسفی&nbsp;<br />
                شماره تماس : 09354340109
                <br />
                آدرس ایمیل : info@parsianmovie.com
                <br />
                شناسه یاهو : amir_vaghef
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="WithoutHiddenTargetControlForModalPopup" style="display:none"/>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="WithoutModalPopup"
        TargetControlID="WithoutHiddenTargetControlForModalPopup"
        PopupControlID="WithoutPopup" 
        BackgroundCssClass="modalBackground"
        OkControlID="hideWithoutModalPopupViaServer"
        DropShadow="True"
        PopupDragHandleControlID="WithoutPopupDragHandle" >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" CssClass="modalPopup" ID="WithoutPopup" style="display:none;width:350px;padding:10px">
        <asp:Panel runat="Server" ID="WithoutPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
            جستجو
        </asp:Panel>
        <br />
        هيچ موردی يافت نشد
        <br />
        <p align="center">
        <asp:Button runat="server" Width="80px" ID="hideWithoutModalPopupViaServer" CausesValidation="false" Text="ادامه"/>
        </p>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

