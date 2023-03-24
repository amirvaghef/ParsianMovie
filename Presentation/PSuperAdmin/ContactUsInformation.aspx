<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUsInformation.aspx.cs" Inherits="PSuperAdmin_ContactUsInformation" Title="::ParsianMovie:: اطلاعات تماس با ما" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWEmail" Visible="true" runat="server" OnRowDeleting="GWEmail_RowDeleting" OnRowUpdating="GWEmail_RowUpdating" OnRowEditing="GWEmail_RowEditing" OnRowCancelingEdit="GWEmail_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="10%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="35%" align="right"><asp:Label ID="Label2" runat="server" Text='سمت' /></td>
                                                                    <td width="55%" align="right"><asp:Label ID="Label3" runat="server" Text='ایمیل' /></td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                        <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                                            <div>
                                                                <div><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit" /></div>
                                                                <div><asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" /></div>
                                                                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtenderDelete" runat="server" 
                                                                    TargetControlID="LinkButton2"
                                                                    ConfirmText="آیا از پاك كردن اين سطر مطمئن هستيد؟" />
                                                            </div>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel9" runat="server">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="10%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldEmailID") %>' /></td>
                                                                    <td width="35%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldAppointedTask") %>' /></td>
                                                                    <td width="55%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldEmailAddress") %>' /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <ajaxToolkit:HoverMenuExtender ID="hme2" runat="Server"
                                                            PopupControlID="PopupMenu"
                                                            PopupPosition="Left"
                                                            TargetControlID="Panel9"
                                                            PopDelay="25" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>  
                                                            <asp:Panel ID="Panel9" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="10%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldEmailID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="35%"><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldAppointedTask") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="55%" align="right" dir="ltr"><asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# Bind("fldEmailAddress") %>' Width="80%" CssClass="inputbox" /></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <ajaxToolkit:HoverMenuExtender ID="hme1" runat="Server"
                                                                TargetControlID="Panel9"
                                                                PopupControlID="PopupMenu"
                                                                HoverCssClass="popupHover"
                                                                PopupPosition="Left" />
                                                            <asp:Panel ID="PopupMenu" runat="server" CssClass="popupMenu" Width="80">
                                                                <div>
                                                                    <div><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" /></div>
                                                                    <div><asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></div>
                                                                </div>
                                                            </asp:Panel>
                                                        </EditItemTemplate>
                                                        <ItemStyle BorderWidth="1px" />
                                                        <HeaderStyle BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:ObjectDataSource ID="ObjectDataSourceEmail" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SingleEmailBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                        سمت : 
                                                    </td>
                                                    <td width="90%" colspan="2" align="right">
                                                        <asp:TextBox ID="TXTAppointedTask" runat="server" Width="100%" CssClass="inputbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        ایمیل : 
                                                    </td>
                                                    <td width="90%" colspan="2" align="right" dir="ltr">
                                                        <asp:TextBox ID="TXTEmailAddress" TextMode="MultiLine" runat="server" Width="100%" CssClass="inputbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBEmail" runat="server" OnClick="IBEmail_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

