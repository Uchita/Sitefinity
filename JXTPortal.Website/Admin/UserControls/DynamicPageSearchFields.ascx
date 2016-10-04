<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicPageSearchFields.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.DynamicPageSearchFields" %>
    
<div class="form-all">
    <table class="tblNoBorder">
        <tbody>
            <tr>
                <td>
                    <label class="form-label-left">Search Keyword:<span class="form-required">*</span></label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchKeyword" runat="server" /><asp:RequiredFieldValidator ID="ReqVal_SearchKeyword"
                    runat="server" Display="Dynamic" ControlToValidate="txtSearchKeyword" ErrorMessage="Required"></asp:RequiredFieldValidator>    
                </td>
            </tr>
            <tr>
                <td>
                    <label class="form-label-left">Language: <span class="form-required">*</span></label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLanguage" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="jxtadminbutton" Text="Search"
                    OnClick="btnSearch_Click" />
                </td>
            </tr>
            
        </tbody>
    </table>
    
    <span class="form-message">
        <asp:Literal ID="litMessage" runat="server" Visible="false" />
    </span>
   
   <asp:Panel ID="pnlSearchResult" runat="server" Visible="false">
        <asp:Repeater ID="rptDynamicPages" runat="server" OnItemCommand="rptDynamicPages_ItemCommand"
            OnItemDataBound="rptDynamicPages_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid" id="tblDynamicPagesRepeater" visible="false">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                <asp:Label ID="lbDynamicPageName" runat="server">Page Name</asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="lbDynamicPageTitle" runat="server">Page Title</asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="lbFriendlyName" runat="server">Friendly Name</asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="lbLastModified" runat="server">Last Modified</asp:Label>
                            </th>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbSelect" runat="server" Text="Select" CommandName="Select" />
                    </td>
                    <td>
                        <asp:Literal ID="ltDynamicPageName" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltDynamicPageTitle" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltFriendlyName" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModified" runat="server" />
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel ID="pnlSiteSearchPaging" runat="server" Visible="false">
    
        <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
            <HeaderTemplate>
                <tfoot>
                    <tr>
                        <td colspan="8">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="litPage" runat="server" Text="Page:" />
                                    </td>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="AdminMember" />
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr> </table> </td> </tr> </tfoot></table>
            </FooterTemplate>
        </asp:Repeater>
        
    </asp:Panel>
    
</div>
