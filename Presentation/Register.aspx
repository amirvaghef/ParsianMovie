<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="::Parsian Movie:: ثبت نام در بخش کاربری" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" FinishDestinationPageUrl="~/index.aspx" ContinueDestinationPageUrl="~/index.aspx"
        CancelButtonText="انصراف" CompleteSuccessText="حساب کاربری شما با موفقیت ثبت شد." 
        ContinueButtonText="ادامه" CreateUserButtonText="ایجاد کاربری" 
        DuplicateEmailErrorMessage="آدرس ایمیل تکراری می باشد لطفاً دوباره تلاش نمائید" 
        DuplicateUserNameErrorMessage="نام کاربری تکراری میباشد لطفاً دوباره تلاش نمائید" 
        FinishCompleteButtonText="اتمام" FinishPreviousButtonText="قبلی" InvalidAnswerErrorMessage="لطفاٌ جواب امنیتی دیگری وارد نمائید" 
        InvalidEmailErrorMessage="لطفاً آدرس ایمیل معتبری را وارد تمائید" InvalidQuestionErrorMessage="لطفاٌ سوال امنیتی دیگری وارد نمائید" 
        StartNextButtonText="بعدی" StepNextButtonText="بعدی" StepPreviousButtonText="قبلی" UnknownErrorMessage="حساب کاربری شما ایجاد نشد لطفاً دوباره تلاش نمائید" InvalidPasswordErrorMessage="حداقل پسورد 6 کلمه میباشد" OnCreatedUser="CreateUserWizard1_CreatedUser">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="ایجاد حساب کاربری جدید">
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td colspan="2">
                                <div class="meteor"><h4>ایجاد حساب کاربری</h4></div></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">نام کاربری:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="نام کاربری مورد نیاز است" ToolTip="نام کاربری مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="UserName" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">رمز عبور:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="رمز عبور مورد نیاز است" ToolTip="رمز عبور مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">تکرار رمز:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                    ErrorMessage="تکرار رمز عبور مورد نیاز است" ToolTip="تکرار رمز عبور مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
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
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Visible="false">سوال امنیتی:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                    ErrorMessage="سوال امنیتی مورد نیاز است" ToolTip="سوال امنیتی مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1" Visible="false">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Question" runat="server" CssClass="inputbox" Text="What is your name?" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Visible="false">جواب امنیتی:</asp:Label></td>
                            <td dir="ltr" align="right">
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                    ErrorMessage="جواب امنیتی مورد نیاز است" ToolTip="جواب امنیتی مورد نیاز است"
                                    ValidationGroup="CreateUserWizard1" Visible="false">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Answer" runat="server" CssClass="inputbox" Text="Amir" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    
                        <tr>
                            <td colspan="2">
                                <div class="meteor"><h4>اطلاعات ضروری برای تماس با شما(به دقت وارد نمائید!)</h4></div>
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
                    </table>
                    <br />
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="رمز عبور و تکرار آن باید برابر باشد"
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: red">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title="مرحله پایانی">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</div>
</asp:Content>

