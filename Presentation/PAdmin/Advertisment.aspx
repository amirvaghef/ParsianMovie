<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Advertisment.aspx.cs" Inherits="PAdmin_Advertisment" ValidateRequest="false" Title="::ParsianMovie:: درج و حذف تبلیغات" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <cc1:Accordion ID="Advertisment" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent" SelectedIndex="-1" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
            <cc1:AccordionPane ID="ExpiredAdvertisment" OnPreRender="ExpiredAdvertisment_Load" runat="server">
                <Header>
                    تبلیغات از تاریخ گذشته
                </Header>
                <Content>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:GridView ID="GWExpiredAdvertisment" runat="server" OnRowDeleting="GWExpiredAdvertisment_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table width="100%">
                                <tr>
                                    <td width="10%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                    <td width="50%" align="right"><asp:Label ID="Label2" runat="server" Text='نام' /></td>
                                    <td width="20%" align="right"><asp:Label ID="Label3" runat="server" Text='تاریخ شروع' /></td>
                                    <td width="20%" align="right"><asp:Label ID="Label4" runat="server" Text='تاریخ پایان' /></td>
                                </tr>
                             </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                <div>
                                    <div><asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" CommandName="Delete" Text="Delete" /></div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel9" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td width="10%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldAdvertismentsID") %>' /></td>
                                        <td width="50%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldName") %>' /></td>
                                        <td width="20%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldStartDate") %>' /></td>
                                        <td width="20%"><asp:Label ID="Label4" runat="server" Text='<%# Eval("fldEndDate") %>' /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:HoverMenuExtender ID="hme2" runat="Server"
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
                </ContentTemplate>    
                </asp:UpdatePanel>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="CurrentAdvertisment" OnPreRender="CurrentAdvertisment_Load" runat="server">
                <Header>
                    لیست تبلیغات
                </Header>
                <Content>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:GridView ID="GWCurrentAdvertisment" runat="server" OnRowDeleting="GWCurrentAdvertisment_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table width="100%">
                                <tr>
                                    <td width="10%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                    <td width="50%" align="right"><asp:Label ID="Label2" runat="server" Text='نام' /></td>
                                    <td width="20%" align="right"><asp:Label ID="Label3" runat="server" Text='تاریخ شروع' /></td>
                                    <td width="20%" align="right"><asp:Label ID="Label4" runat="server" Text='تاریخ پایان' /></td>
                                </tr>
                             </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                <div>
                                    <div><asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" CommandName="Delete" Text="Delete" /></div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel9" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td width="10%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldAdvertismentsID") %>' /></td>
                                        <td width="50%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldName") %>' /></td>
                                        <td width="20%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldStartDate") %>' /></td>
                                        <td width="20%"><asp:Label ID="Label4" runat="server" Text='<%# Eval("fldEndDate") %>' /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:HoverMenuExtender ID="hme2" runat="Server"
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
                </ContentTemplate>    
                </asp:UpdatePanel>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="InsertAdvertisment" runat="server">
                <Header>
                    درج تبلیغات
                </Header>
                <Content>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="IBUploadPanel" />
                </Triggers>
                <ContentTemplate>
                <table align="center" >
                    <tr>
                        <td colspan="2" align="center">
                            <label class="onvanZirNevis">حداکثر طول عکس 145 باشد</label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Insert" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            نام تبلیغ : 
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TXTName" runat="server" Width="230px" ValidationGroup="Insert" CssClass="inputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTName"
                                ErrorMessage="لطفاً نام تبلیغ را وارد نمائید" ValidationGroup="Insert">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            کد تبلیغ : 
                        </td>
                        <td align="right" dir="ltr" colspan="2">
                            <asp:ImageButton SkinID="UploadButton" ID="IBUpload" runat="server" CausesValidation="False" OnClick="IBUpload_Click" />&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTCode"
                                ErrorMessage="لطفاً کد تبلیغ را وارد نمائید" ValidationGroup="Insert">*</asp:RequiredFieldValidator>&nbsp;
                            <asp:TextBox ID="TXTCode" runat="server" TextMode="MultiLine" Width="300px" ValidationGroup="Insert" CssClass="inputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            مدت تبلیغ : 
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TXTTime" runat="server" Width="230px" CssClass="inputbox"></asp:TextBox>&nbsp;
                            <cc1:FilteredTextBoxExtender ID="TXTTimeFTXT" runat="server" TargetControlID="TXTTime" FilterType="Numbers" />
                            <asp:DropDownList ID="DRPTime" runat="server" CssClass="inputbox">
                                <asp:ListItem Text="روز" Value="0"></asp:ListItem>
                                <asp:ListItem Text="ماه" Value="1"></asp:ListItem>
                                <asp:ListItem Text="سال" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:ImageButton SkinID="submitButton" ID="IBSubmit" runat="server" ValidationGroup="Insert" OnClick="IBSubmit_Click" />
                        </td>
                        <td align="center">
                            <asp:ImageButton SkinID="resetButton" ID="IBReset" runat="server" CausesValidation="False" OnClick="IBReset_Click" />
                        </td>
                    </tr>
                </table>
                                <asp:Button runat="server" ID="WithoutHiddenTargetControlForModalPopup" style="display:none"/>
                                <cc1:ModalPopupExtender runat="server" ID="WithoutModalPopup"
                                    TargetControlID="WithoutHiddenTargetControlForModalPopup"
                                    PopupControlID="WithoutPopup" 
                                    BackgroundCssClass="modalBackground"
                                    DropShadow="True"
                                    PopupDragHandleControlID="WithoutPopupDragHandle" >
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" CssClass="modalPopup" ID="WithoutPopup" style="display:none;width:350px;padding:10px">
                                    <asp:Panel runat="Server" ID="WithoutPopupDragHandle" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black;text-align:center;">
                                        تولید کد
                                    </asp:Panel>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:ValidationSummary ValidationGroup="panel" ID="ValidationSummary1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                عکس : 
                                            </td>
                                            <td align="right">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="inputbox"/>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
                                                    ErrorMessage="لطفاً عکس را وارد نمائید" ValidationGroup="panel">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                لینک : 
                                            </td>
                                            <td align="right" dir="ltr">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TXTLink"
                                                    ErrorMessage="لطفاً لینک را وارد نمائید" ValidationGroup="panel">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTLink"
                                                    ErrorMessage="لطفاً لینک را با فرمت درست وارد نمائید" ValidationGroup="panel" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator>
                                                <asp:TextBox ID="TXTLink" runat="server" ValidationGroup="panel" CssClass="inputbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton SkinID="insertbutton" ID="IBUploadPanel" runat="server" ValidationGroup="panel" OnClick="IBUploadPanel_Click" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton SkinID="CancelButton" ID="IBCancelPanel" runat="server" ValidationGroup="panel" CausesValidation="false" OnClick="IBCancelPanel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                </ContentTemplate>    
                </asp:UpdatePanel>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
    </div>
</asp:Content>