<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Faq.aspx.cs" Inherits="Faq" Title="::ParsianMovie:: سوالات متداول" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content">
                    
                        <asp:Repeater ID="RepeaterKindOffer" runat="server" DataSourceID="ObjectDataSourceFAQ">
                            <ItemTemplate>
                                <table width="100%">
                                <tr>
                                <td>
                    <asp:Panel ID="PLFormatHeader" runat="server" Width="100%" CssClass="verticalmenuBG">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("fldFAQQuestion") %>' Width="80%"/>
                    </asp:Panel>
                                </td>
                                </tr>
                                <tr>
                                <td>
                    <asp:Panel ID="PLFormatContent" runat="server" Width="100%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("fldFAQAnswer") %>' />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>    
                    <br />
                    <br />
                                </td>
                                </tr>
                                </table>
                    
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:ObjectDataSource ID="ObjectDataSourceFAQ" runat="server" SelectMethod="GetAll"
                                                TypeName="Business.SingleFAQBL"></asp:ObjectDataSource>
</div>
</asp:Content>

