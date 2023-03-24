<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BaseInformation.aspx.cs" Inherits="PAdmin_BaseInformation" Title="::ParsianMovie:: اطلاعات پایه" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="insert" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DropDownList ID="DRPBaseInfo" runat="server" OnSelectedIndexChanged="DRPBaseInfo_SelectedIndexChanged" AutoPostBack="true" Width="300px" CssClass="inputbox">
                            <asp:ListItem Value="null" Text=" "></asp:ListItem>
                            <asp:ListItem Value="Rank">درجه</asp:ListItem>
                            <asp:ListItem Value="CountryProduct">محصول کشور</asp:ListItem>
                            <asp:ListItem Value="KindOffer">نوع ارائه</asp:ListItem>
                            <asp:ListItem Value="Quality">کیفیت</asp:ListItem>
                            <asp:ListItem Value="Subtitles">زیرنویس</asp:ListItem>
                            <asp:ListItem Value="Genre">ژانر</asp:ListItem>
                            <asp:ListItem Value="Language">زبان</asp:ListItem>
                            <asp:ListItem Value="DVDKind">نوع دی وی دی</asp:ListItem>
                            <asp:ListItem Value="TransmissionKind">طریقه ارسال</asp:ListItem>
                            <asp:ListItem Value="PaymentWay">طریقه پرداخت</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiViewBaseInfo" runat="server">
                            <asp:View ID="Rank" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWRank" runat="server" OnRowDeleting="GWRank_RowDeleting" OnRowUpdating="GWRank_RowUpdating" OnRowEditing="GWRank_RowEditing" OnRowCancelingEdit="GWRank_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label5" runat="server" Text='درجه' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldRankID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldRankName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldRankID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً درجه را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldRankName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceRank" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.RankBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        درجه : 
                                                        <asp:TextBox ID="TXTRankName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً درجه را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTRankName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBRank" runat="server" ValidationGroup="insert" OnClick="IBRank_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="CountryProduct" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWCountryProduct" runat="server" OnRowDeleting="GWCountryProduct_RowDeleting" OnRowUpdating="GWCountryProduct_RowUpdating" OnRowEditing="GWCountryProduct_RowEditing" OnRowCancelingEdit="GWCountryProduct_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label5" runat="server" Text='محصول کشور' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldCountryProductID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldCountryProductName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldCountryProductID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً محصول کشور را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldCountryProductName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceCountryProduct" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.CountryProductBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                         محصول کشور : 
                                                        <asp:TextBox ID="TXTCountryProductName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="لطفاً محصول کشور را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTCountryProductName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBCountryProduct" runat="server" ValidationGroup="insert" OnClick="IBCountryProduct_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="KindOffer" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWKindOffer" runat="server" OnRowDeleting="GWKindOffer_RowDeleting" OnRowUpdating="GWKindOffer_RowUpdating" OnRowEditing="GWKindOffer_RowEditing" OnRowCancelingEdit="GWKindOffer_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label2" runat="server" Text='نوع ارائه' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldKindOfferID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldKindOfferName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldKindOfferID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً نوع ارائه را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldKindOfferName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceKindOffer" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.KindOfferBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        نوع ارائه : 
                                                        <asp:TextBox ID="TXTKindOfferName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="لطفاً نوع ارائه را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTKindOfferName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBKindOffer" runat="server" ValidationGroup="insert" OnClick="IBKindOffer_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="Quality" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWQuality" runat="server" OnRowDeleting="GWQuality_RowDeleting" OnRowUpdating="GWQuality_RowUpdating" OnRowEditing="GWQuality_RowEditing" OnRowCancelingEdit="GWQuality_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label2" runat="server" Text='کیفیت' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldQualityID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldQualityName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldQualityID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً کیفیت را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldQualityName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceQuality" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.QualityBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        کیفیت : 
                                                        <asp:TextBox ID="TXTQualityName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="لطفاً کیفیت را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTQualityName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBQuality" runat="server" ValidationGroup="insert" OnClick="IBQuality_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="Subtitles" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWSubtitles" runat="server" OnRowDeleting="GWSubtitles_RowDeleting" OnRowUpdating="GWSubtitles_RowUpdating" OnRowEditing="GWSubtitles_RowEditing" OnRowCancelingEdit="GWSubtitles_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label2" runat="server" Text='زیرنویس' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldSubtitlesID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldSubtitlesName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldSubtitlesID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً زیرنویس را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldSubtitlesName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceSubtitles" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SingleSubtitlesBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        زیرنویس : 
                                                        <asp:TextBox ID="TXTSubtitlesName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="لطفاً زیرنویس را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTSubtitlesName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBSubtitles" runat="server" ValidationGroup="insert" OnClick="IBSubtitles_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="Genre" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWGenre" runat="server" OnRowDeleting="GWGenre_RowDeleting" OnRowUpdating="GWGenre_RowUpdating" OnRowEditing="GWGenre_RowEditing" OnRowCancelingEdit="GWGenre_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label2" runat="server" Text='ژانر' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldGenreID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldGenreName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldGenreID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً ژانر را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldGenreName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceGenre" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.GenreBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        ژانر : 
                                                        <asp:TextBox ID="TXTGenreName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="لطفاً ژانر را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTGenreName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBGenre" runat="server" ValidationGroup="insert" OnClick="IBGenre_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="Language" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWLanguage" runat="server" OnRowDeleting="GWLanguage_RowDeleting" OnRowUpdating="GWLanguage_RowUpdating" OnRowEditing="GWLanguage_RowEditing" OnRowCancelingEdit="GWLanguage_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="30%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="70%" align="right"><asp:Label ID="Label2" runat="server" Text='زبان' /></td>
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
                                                                    <td width="30%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldLanguageID") %>' /></td>
                                                                    <td width="70%"><asp:Label ID="Label5" runat="server" Text='<%# Eval("fldLanguageName") %>' /></td>
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
                                                                        <td width="30%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldLanguageID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="70%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً زبان را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldLanguageName") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceLanguage" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.LanguageBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        زبان : 
                                                        <asp:TextBox ID="TXTLanguageName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="لطفاً زبان را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTLanguageName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBLanguage" runat="server" ValidationGroup="insert" OnClick="IBLanguage_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="DVDKind" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWDVDKind" runat="server" OnRowDeleting="GWDVDKind_RowDeleting" OnRowUpdating="GWDVDKind_RowUpdating" OnRowEditing="GWDVDKind_RowEditing" OnRowCancelingEdit="GWDVDKind_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="15%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="50%" align="right"><asp:Label ID="Label2" runat="server" Text='نام' /></td>
                                                                    <td width="35%" align="right"><asp:Label ID="Label3" runat="server" Text='قیمت' /></td>
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
                                                                    <td width="15%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldDVDKindID") %>' /></td>
                                                                    <td width="50%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldDVDKindName") %>' /></td>
                                                                    <td width="35%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldDVDKindPrice","{0:#,###,###}") %>' /></td>
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
                                                                        <td width="15%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldDVDKindID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="50%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً نام را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldDVDKindName") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="35%">
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox3"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative=None
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="MaskedEditExtender1"
                                            ControlToValidate="TextBox3"
                                            IsValidEmpty="False"
                                            MaximumValue="3000000"
                                            EmptyValueMessage="عدد نياز است"
                                            InvalidValueMessage="عدد قابل قبول است"
                                            MaximumValueMessage="بزرگترين 3,000,000 است"
                                            MinimumValueMessage="كوچكترين صفر است"
                                            MinimumValue="0"
                                            Display=Dynamic
                                            TooltipMessage="عددي بين صفر تا 3,000,000 وارد نمائيد"
                                            EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="*"
                                            MaximumValueBlurredMessage="*"
                                            MinimumValueBlurredText="*" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفاً قیمت را پر نمائید" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fldDVDKindPrice") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceDVDKind" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SingleDVDKindBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        نام : 
                                                        <asp:TextBox ID="TXTDVDKindName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="لطفاً نام را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTDVDKindName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        قیمت : 
                                                        <asp:TextBox ID="TXTDVDKindPrice" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TXTDVDKindPrice"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative=None
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" ValidationGroup="insert" runat="server"
                                            ControlExtender="MaskedEditExtender1"
                                            ControlToValidate="TXTDVDKindPrice"
                                            IsValidEmpty="False"
                                            MaximumValue="3000000"
                                            EmptyValueMessage="عدد نياز است"
                                            InvalidValueMessage="عدد قابل قبول است"
                                            MaximumValueMessage="بزرگترين 3,000,000 است"
                                            MinimumValueMessage="كوچكترين صفر است"
                                            MinimumValue="0"
                                            Display=Dynamic
                                            TooltipMessage="عددي بين صفر تا 3,000,000 وارد نمائيد"
                                            EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="*"
                                            MaximumValueBlurredMessage="*"
                                            MinimumValueBlurredText="*" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفاً قیمت را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTDVDKindPrice">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBDVDKind" runat="server" ValidationGroup="insert" OnClick="IBDVDKind_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="TransmissionKind" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWTransmissionKind" runat="server" OnRowDeleting="GWTransmissionKind_RowDeleting" OnRowUpdating="GWTransmissionKind_RowUpdating" OnRowEditing="GWTransmissionKind_RowEditing" OnRowCancelingEdit="GWTransmissionKind_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="15%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="50%" align="right"><asp:Label ID="Label2" runat="server" Text='روش ارسال' /></td>
                                                                    <td width="35%" align="right"><asp:Label ID="Label3" runat="server" Text='قیمت' /></td>
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
                                                                    <td width="15%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldTransmissionKindID") %>' /></td>
                                                                    <td width="50%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldTransmissionKindName") %>' /></td>
                                                                    <td width="35%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldTransmissionKindPrice","{0:#,###}") %>' /></td>
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
                                                                        <td width="15%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldTransmissionKindID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="50%">    
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفاً روش ارسال را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldTransmissionKindName") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="35%">
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox3"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative=None
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="MaskedEditExtender1"
                                            ControlToValidate="TextBox3"
                                            IsValidEmpty="False"
                                            MaximumValue="3000000"
                                            EmptyValueMessage="عدد نياز است"
                                            InvalidValueMessage="عدد قابل قبول است"
                                            MaximumValueMessage="بزرگترين 3,000,000 است"
                                            MinimumValueMessage="كوچكترين صفر است"
                                            MinimumValue="0"
                                            Display=Dynamic
                                            TooltipMessage="عددي بين صفر تا 3,000,000 وارد نمائيد"
                                            EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="*"
                                            MaximumValueBlurredMessage="*"
                                            MinimumValueBlurredText="*" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفاً قیمت را پر نمائید" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fldTransmissionKindPrice") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourceTransmissionKind" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SingleTransmissionKindBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        روش ارسال : 
                                                        <asp:TextBox ID="TXTTransmissionKindName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="لطفاً روش ارسال را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTTransmissionKindName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        قیمت : 
                                                        <asp:TextBox ID="TXTTransmissionKindPrice" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <ajaxToolkit:MaskedEditExtender ID="TXTPrice" runat="server" TargetControlID="TXTTransmissionKindPrice"
                                            Mask="9,999,999"
                                            MessageValidatorTip="true"
                                            MaskType="Number"
                                            InputDirection="RightToLeft"
                                            AcceptNegative=None
                                            DisplayMoney="Right"
                                            ErrorTooltipEnabled="true"
                                            OnInvalidCssClass="validatorCalloutHighlight"
                                            ErrorTooltipCssClass="helpbox" />
                                        <ajaxToolkit:MaskedEditValidator ID="ValidatorTXTPrice" ValidationGroup="insert" runat="server"
                                            ControlExtender="TXTPrice"
                                            ControlToValidate="TXTTransmissionKindPrice"
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
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="لطفاً قیمت را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTTransmissionKindPrice">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBTransmissionKind" runat="server" ValidationGroup="insert" OnClick="IBTransmissionKind_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="PaymentWay" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GWPaymentWay" runat="server" OnRowDeleting="GWPaymentWay_RowDeleting" OnRowUpdating="GWPaymentWay_RowUpdating" OnRowEditing="GWPaymentWay_RowEditing" OnRowCancelingEdit="GWPaymentWay_RowCancelingEdit">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="15%" align="right"><asp:Label ID="Label1" runat="server" Text='شماره' /></td>
                                                                    <td width="50%" align="right"><asp:Label ID="Label2" runat="server" Text='روش پرداخت' /></td>
                                                                    <td width="35%" align="right"><asp:Label ID="Label3" runat="server" Text='صفحه ارجاع' /></td>
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
                                                                    <td width="15%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("fldPaymentWayID") %>' /></td>
                                                                    <td width="50%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("fldPaymentWayName") %>' /></td>
                                                                    <td width="35%"><asp:Label ID="Label3" runat="server" Text='<%# Eval("fldPaymentWayPage") %>' /></td>
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
                                                                        <td width="15%"><asp:TextBox Font-Bold="true" ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("fldPaymentWayID") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="50%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفاً روش پرداخت را پر نمائید" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fldPaymentWayName") %>' Width="80%" CssClass="inputbox" /></td>
                                                                        <td width="35%">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="لطفاً صفحه ارجاع را پر نمائید" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fldPaymentWayPage") %>' Width="80%" CssClass="inputbox" /></td>
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
                                            <asp:ObjectDataSource ID="ObjectDataSourcePaymentWay" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SinglePaymentWayBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        روش پرداخت : 
                                                        <asp:TextBox ID="TXTPaymentWayName" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفاً روش پرداخت را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTPaymentWayName">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        صفحه ارجاع : 
                                                        <asp:TextBox ID="TXTPaymentWayPage" runat="server" CssClass="inputbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="لطفاً صفحه ارجاع را پر نمائید" ValidationGroup="insert" ControlToValidate="TXTPaymentWayPage">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton SkinID="InsertButton" ID="IBPaymentWay" runat="server" ValidationGroup="insert" OnClick="IBPaymentWay_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="vError" runat="server">
                                <br />
                                <asp:Panel ID="Panel1" runat="server" align="center" BorderStyle="groove" BorderWidth="2" Height="50px" Width="100%">
                                    <asp:Label ID="LBError" runat="server" Text="شما مجاز به دسترسی به این داده ها نیستید"></asp:Label>
                                </asp:Panel>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

