<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UsersInformation.aspx.cs" Inherits="PSuperAdmin_UsersInformation" Title="::ParsianMovie:: به روز رسانی کاربران" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <cc1:Accordion ID="Advertisment" runat="server" HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
            SelectedIndex="-1" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
            <Panes>
                <cc1:AccordionPane ID="CreateUser" runat="server">
                    <Header>
                        ایجاد کاربر جدید
                    </Header>
                    <Content>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" FinishDestinationPageUrl="~/PSuperAdmin/UsersInformation.aspx"
                                    ContinueDestinationPageUrl="~/PSuperAdmin/UsersInformation.aspx" LoginCreatedUser="false"
                                    CancelButtonText="انصراف" CompleteSuccessText="حساب کاربری شما با موفقیت ثبت شد."
                                    ContinueButtonText="ادامه" CreateUserButtonText="ایجاد کاربری" DuplicateEmailErrorMessage="آدرس ایمیل تکراری می باشد لطفاً دوباره تلاش نمائید"
                                    DuplicateUserNameErrorMessage="نام کاربری تکراری میباشد لطفاً دوباره تلاش نمائید"
                                    FinishCompleteButtonText="اتمام" FinishPreviousButtonText="قبلی" InvalidAnswerErrorMessage="لطفاٌ جواب امنیتی دیگری وارد نمائید"
                                    InvalidEmailErrorMessage="لطفاً آدرس ایمیل معتبری را وارد تمائید" InvalidQuestionErrorMessage="لطفاٌ سوال امنیتی دیگری وارد نمائید"
                                    StartNextButtonText="بعدی" StepNextButtonText="بعدی" StepPreviousButtonText="قبلی"
                                    UnknownErrorMessage="حساب کاربری شما ایجاد نشد لطفاً دوباره تلاش نمائید" OnCreatedUser="CreateUserWizard1_CreatedUser"
                                    Width="100%" InvalidPasswordErrorMessage="حداقل پسورد 6 کلمه میباشد">
                                    <WizardSteps>
                                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="ایجاد حساب کاربری جدید">
                                            <ContentTemplate>
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <div class="meteor">
                                                                <h4>
                                                                    ایجاد حساب کاربری</h4>
                                                            </div>
                                                        </td>
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
                                                        <td colspan="2">
                                                            <div class="meteor">
                                                                <h4>
                                                                    در صورت فراموشی رمز عبور</h4>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">سوال امنیتی:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                                                ErrorMessage="سوال امنیتی مورد نیاز است" ToolTip="سوال امنیتی مورد نیاز است"
                                                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="Question" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">جواب امنیتی:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                                                ErrorMessage="جواب امنیتی مورد نیاز است" ToolTip="جواب امنیتی مورد نیاز است"
                                                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="Answer" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div class="meteor">
                                                                <h4>
                                                                    اطلاعات ضروری برای تماس با شما(به دقت وارد نمائید!)</h4>
                                                            </div>
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
                                                                ErrorMessage="شماره تماس مورد نیاز است" ToolTip="شماره تماس مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
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
                                                                ErrorMessage="آدرس مورد نیاز است" ToolTip="آدرس مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="PostalCodeLabel" runat="server" AssociatedControlID="PostalCode">کد پستی:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PostalCode"
                                                                ErrorMessage="کد پستی مورد نیاز است" ToolTip="کد پستی مورد نیاز است" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="PostalCode" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            تعیین نقش
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DRPSelectRole" runat="server" CssClass="inputbox" Width="150px">
                                                                <asp:ListItem Text="کاربران" Value="Users"></asp:ListItem>
                                                                <asp:ListItem Text="مدیر" Value="Admin"></asp:ListItem>
                                                                <asp:ListItem Text="سوپر مدیر" Value="SuperAdmin"></asp:ListItem>
                                                            </asp:DropDownList>
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
                                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                            <ContentTemplate>
                                                <table border="0" style="font-size: 100%; width: 100%">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            تبریک</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            حساب کاربری شما با موفقیت ثبت شد.</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                                Text="ادامه" ValidationGroup="CreateUserWizard1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:CompleteWizardStep>
                                    </WizardSteps>
                                    <FinishNavigationTemplate>
                                        <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                                            Text="قبلی" />
                                        <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" Text="اتمام" />
                                    </FinishNavigationTemplate>
                                </asp:CreateUserWizard>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="UpdateUser" OnPreRender="UpdateUser_Load" runat="server">
                    <Header>
                        لیست کاربران
                    </Header>
                    <Content>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table width="100%" border="0">
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="لطفاً نام کاربری را وارد نمائید"
                                                ControlToValidate="TXTUsername" ValidationGroup="search">*</asp:RequiredFieldValidator>
                                            نام کاربری :
                                            <asp:TextBox ID="TXTUsername" runat="server" Width="100px" ValidationGroup="search"></asp:TextBox>
                                            <asp:LinkButton ID="LBUsername" runat="server" OnClick="LBUsername_OnClick" ValidationGroup="search">جستجو</asp:LinkButton>
                                        </td>
                                        <td>
                                            نقش ها :
                                            <asp:DropDownList ID="DRPRole" runat="server" CssClass="inputbox" Width="100px" OnSelectedIndexChanged="DRPRole_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="کاربران" Value="Users"></asp:ListItem>
                                                <asp:ListItem Text="مدیر" Value="Admin"></asp:ListItem>
                                                <asp:ListItem Text="سوپر مدیر" Value="SuperAdmin"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="GWUsers" runat="server" AllowPaging="True" PageSize="25" OnRowDeleting="GWUser_RowDeleting"
                                                OnRowUpdating="GWUser_RowUpdating" OnRowEditing="GWUser_RowEditing" OnRowCancelingEdit="GWUser_RowCanceling"
                                                OnPageIndexChanging="GWUser_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="20%" align="right">
                                                                        <asp:Label ID="Label1" runat="server" Text='نام کاربری' /></td>
                                                                    <td width="30%" align="right">
                                                                        <asp:Label ID="Label2" runat="server" Text='نام' /></td>
                                                                    <td width="30%" align="right">
                                                                        <asp:Label ID="Label3" runat="server" Text='نام خانوادگی' /></td>
                                                                    <td width="20%" align="right">
                                                                        <asp:Label ID="Label4" runat="server" Text='ایمیل' /></td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                                                <div>
                                                                    <div>
                                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" CommandName="Delete"
                                                                            Text="حذف" /></div>
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderDelete" runat="server" TargetControlID="LinkButton2"
                                                                        ConfirmText="آیا از پاك كردن اين سطر مطمئن هستيد؟" />
                                                                    <div>
                                                                        <asp:LinkButton ID="LinkButton1" CausesValidation="false" runat="server" CommandName="Edit"
                                                                            Text="سبد" /></div>
                                                                    <div>
                                                                        <asp:LinkButton ID="LinkButton3" CausesValidation="false" runat="server" CommandName="Update"
                                                                            Text="خرید" /></div>
                                                                    <div>
                                                                        <asp:LinkButton ID="LinkButton4" CausesValidation="false" runat="server" CommandName="Cancel"
                                                                            Text="مشخصات" /></div>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel9" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="20%">
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("fldUsername") %>' /></td>
                                                                        <td width="30%">
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("fldName") %>' /></td>
                                                                        <td width="30%">
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("fldFamily") %>' /></td>
                                                                        <td width="20%">
                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("fldEmail") %>' /></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <cc1:HoverMenuExtender ID="hme2" runat="Server" PopupControlID="PopupMenu" PopupPosition="Left"
                                                                TargetControlID="Panel9" PopDelay="25" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderWidth="1px" />
                                                        <HeaderStyle BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <hr />
                                            <br />
                                            <asp:GridView ID="GWFilms" runat="server" EnableViewState="false" OnRowDeleting="GWFilms_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="9%">
                                                                        <asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="8%">
                                                                        <asp:Label ID="Label5" runat="server" Text='نوع' /></td>
                                                                    <td width="33%">
                                                                        <asp:Label ID="Label2" runat="server" Text='نام اصلی' /></td>
                                                                    <td width="33%">
                                                                        <asp:Label ID="Label3" runat="server" Text='نام فارسی' /></td>
                                                                    <td width="7%">
                                                                        <asp:Label ID="Label4" runat="server" Text='تعداد بخش' /></td>
                                                                    <td width="10%">
                                                                        <asp:Label ID="Label6" runat="server" Text='قیمت' /></td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                                                <div>
                                                                    <div>
                                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" CommandName="Delete"
                                                                            Text="Delete" /></div>
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderDelete" runat="server" TargetControlID="LinkButton2"
                                                                        ConfirmText="آیا از پاك كردن اين سطر مطمئن هستيد؟" />
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel9" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="9%">
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("fldFilmID") %>' /></td>
                                                                        <td width="8%">
                                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("fldKindOfferName") %>' /></td>
                                                                        <td width="33%">
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("fldEnglishName") %>' /></td>
                                                                        <td width="33%">
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("fldFarsiName") %>' /></td>
                                                                        <td width="7%">
                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("fldSection") %>' /></td>
                                                                        <td width="10%">
                                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("fldPrice","{0:#,###,###}") %>' /></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <cc1:HoverMenuExtender ID="hme2" runat="Server" PopupControlID="PopupMenu" PopupPosition="Left"
                                                                TargetControlID="Panel9" PopDelay="25" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderWidth="1px" />
                                                        <HeaderStyle BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div runat="server" enableviewstate="false" dir="rtl" id="PriceFilms" visible="false">
                                            قیمت فیلم ها :
                                            <asp:Label ID="LBPriceFilms" runat="server" Text="0"></asp:Label>
                                            ریال
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Repeater ID="RepeaterBought" runat="server" EnableViewState="false">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <a target="_blank" href='BuyDetail.aspx?BuyID=<%# Eval("fldBuyID") %>'>
                                                                    <%# Eval("fldBuyDate")%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <SeparatorTemplate>
                                                    <hr />
                                                </SeparatorTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="PanelUserInformation" runat="server" EnableViewState="false" Visible="false" Width="100%">
                                                <table border="0">
                                                <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Label ID="Label8" Font-Size="Small" Font-Bold="true" runat="server">مشخصات</asp:Label>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">ایمیل:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:Label ID="Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">نام:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="FamilyLabel" runat="server" AssociatedControlID="Family">نام خانوادگی:</asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Family" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Tellabel" runat="server" AssociatedControlID="Tel">شماره تماس:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:Label ID="Tel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="MobLabel" runat="server" AssociatedControlID="Mob">شماره همراه:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:Label ID="Mob" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">آدرس:</asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Address" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="PostalCodeLabel" runat="server" AssociatedControlID="PostalCode">کد پستی:</asp:Label></td>
                                                        <td dir="ltr" align="right">
                                                            <asp:Label ID="PostalCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </Content>
                </cc1:AccordionPane>
            </Panes>
        </cc1:Accordion>
    </div>
</asp:Content>
