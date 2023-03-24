<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Specification.aspx.cs" Inherits="PAdmin_Specification" Title="::Parsian Movie:: تغییرات بخش مدیریتی" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <cc1:Accordion runat="server" ID="AccordionFilms" SelectedIndex="-1"
        HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent" AutoSize="None" RequireOpenedPane="false" 
        SuppressHeaderPostbacks="true">
        <Panes>
            <cc1:AccordionPane runat="server" ID="AccordionPaneChangePassword">
                <Header>
                    تغییر رمز عبور
                </Header>
                <Content>
                    <asp:ChangePassword ID="ChangePassword1" runat="server" CancelButtonText="لغو" ChangePasswordButtonText="تغییر رمز" ChangePasswordTitleText="" ConfirmNewPasswordLabelText="تکرار رمز عبور جدید:" ConfirmPasswordCompareErrorMessage="رمز جدید با تکرار آن برابر نمی باشد" ConfirmPasswordRequiredErrorMessage="تکرار رمز عبور مورد نیاز می باشد" ContinueButtonText="ادامه" NewPasswordLabelText="رمز عبور جدید:" NewPasswordRegularExpressionErrorMessage="لطفاً رمز متفاوتی را وارد نمائید" NewPasswordRequiredErrorMessage="رمز جدید مورد نیاز می باشد" PasswordLabelText="رمز عبور قدیمی:" PasswordRequiredErrorMessage="رمز عبور مورد نیاز می باشد" SuccessText="رمزعبور تغییر یافت" SuccessTitleText="" UserNameLabelText="نام کاربری:" UserNameRequiredErrorMessage="نام کاربری مورد نیاز می باشد" SuccessPageUrl="~/PAdmin/Specification.aspx">
                        <ChangePasswordTemplate>
                            <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">رمز عبور قدیمی:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                        ErrorMessage="رمز عبور مورد نیاز می باشد" ToolTip="رمز عبور مورد نیاز می باشد"
                                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">رمز عبور جدید:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                        ErrorMessage="رمز جدید مورد نیاز می باشد" ToolTip="رمز جدید مورد نیاز می باشد"
                                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">تکرار رمز عبور جدید:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                        ErrorMessage="تکرار رمز عبور مورد نیاز می باشد" ToolTip="تکرار رمز عبور مورد نیاز می باشد"
                                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                        ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="رمز جدید با تکرار آن برابر نمی باشد"
                                                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                        Text="تغییر رمز" ValidationGroup="ChangePassword1" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                        Text="لغو" Width="80px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ChangePasswordTemplate>
                    </asp:ChangePassword>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane runat="server" ID="AccordionPaneUpdateUser" OnPreRender="AccordionPaneUpdateUser_PreRender">
                <Header>
                    نغییر مشخصات کاربری
                </Header>
                <Content>
                    <table border="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">ایمیل:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage="ایمیل مورد نیاز است" ToolTip="ایمیل مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Email" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">نام:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="FamilyLabel" runat="server" AssociatedControlID="Family">نام خانوادگی:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Family" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Tellabel" runat="server" AssociatedControlID="Tel">شماره تماس:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Tel"
                                    ErrorMessage="شماره تماس مورد نیاز است" ToolTip="شماره تماس مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Tel" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="MobLabel" runat="server" AssociatedControlID="Mob">شماره همراه:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:TextBox ID="Mob" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">آدرس:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Address" runat="server" Width="300px" CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Address"
                                    ErrorMessage="آدرس مورد نیاز است" ToolTip="آدرس مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PostalCodeLabel" runat="server" AssociatedControlID="PostalCode">کد پستی:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PostalCode"
                                    ErrorMessage="کد پستی مورد نیاز است" ToolTip="کد پستی مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="PostalCode" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: red">
                                <asp:ValidationSummary ID="ValidationSummary" ValidationGroup="CreateUserWizard1" ShowSummary="true" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="BTSubmit" runat="server" Text="تأئید" OnClick="BTSubmit_Click" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
</div>
</asp:Content>
