<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="::Parsian Movie:: بزرگترين فروشگاه اينترنتی فيلم" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" align=center>
                  <asp:LoginView ID="LoginView1" runat="server">
                            <AnonymousTemplate>
                                <asp:Login ID="Login1" runat="server" FailureText="تلاش موفقيت آميز نبود لطفاً دوباره تلاش نمائيد" LoginButtonText="ورود" PasswordLabelText="رمز عبور:" PasswordRequiredErrorMessage="لطفاً رمز عبور را وارد نمائيد" RememberMeText="مرا به خاطر بسپار" TextLayout="TextOnTop" TitleText="" UserNameLabelText="نام كاربری:" UserNameRequiredErrorMessage="لطفاً نام كاربري را وارد نمائيد" DestinationPageUrl="~/index.aspx">
                                    <LayoutTemplate>
                                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                                            <tr>
                                                <td style="width: 297px">
                                                    <table border="0" cellpadding="0">
                                                        <tr>
                                                            <td style="width: 100px">
                                                                نام كاربری:
                                                            </td>
                                                            <td style="width: 214px">
                                                                <asp:TextBox ID="UserName" runat="server" CssClass="txtusername"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                    ErrorMessage="لطفاً نام كاربري را وارد نمائيد" ToolTip="لطفاً نام كاربري را وارد نمائيد"
                                                                    ValidationGroup="ctl00$ctl05$Login1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px">
                                                                رمز عبور:
                                                            </td>
                                                            <td style="width: 214px">
                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="txtpassword"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                    ErrorMessage="لطفاً رمز عبور را وارد نمائيد" ToolTip="لطفاً رمز عبور را وارد نمائيد"
                                                                    ValidationGroup="ctl00$ctl05$Login1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="color: red" colspan="2">
                                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:ImageButton ID="LoginButton" SkinID="LoginButton" runat="server" CommandName="Login" ValidationGroup="ctl00$ctl05$Login1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:Login>
                            </AnonymousTemplate>
                        </asp:LoginView>
</div>                        
</asp:Content>

