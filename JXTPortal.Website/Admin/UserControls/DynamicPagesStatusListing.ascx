<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicPagesStatusListing.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.DynamicPagesStatusListing" %>
<asp:Panel ID="DraftPanel" runat="server">
    <h1>
        Dynamic Page (Drafts)</h1>
    <asp:Repeater ID="rptDraftsList" runat="server" OnItemDataBound="rptDraftsList_ItemDataBound"
        OnItemCommand="rptDraftsList_ItemCommand">
        <HeaderTemplate>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" class="grid">
                <thead>
                    <tr>
                        <th>
                            Page ID
                        </th>
                        <th>
                            Unique Page Code
                        </th>
                        <th>
                            Title
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Submitted On
                        </th>
                        <th>
                            Submitted By (Username)
                        </th>
                        <th>
                            Actions
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="plNoDraftMsg" runat="server">
                        <tr>
                            <td colspan="7">
                                There are no dynamic pages with draft status
                            </td>
                        </tr>
                    </asp:PlaceHolder>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Literal ID="ltPageID" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltPageNme" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltPageTitle" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltStatus" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltSubmittedOn" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltSubmittedBy" runat="server" />
                </td>
                <td>
                    <%--                    <asp:LinkButton ID="lbRevisionRevert" runat="server" Text="Revert" CommandName="Revert" />
                    |
                    --%>
                    <asp:HyperLink ID="hlRevisionView" runat="server" Text="View" Target="_blank" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <br /><br />
</asp:Panel>
<asp:Panel ID="PendingPanel" runat="server">
    <h1>
        Dynamic Page (Pending)</h1>
    <asp:Repeater ID="rptPendingsList" runat="server" OnItemDataBound="rptPendingsList_ItemDataBound"
        OnItemCommand="rptPendingsList_ItemCommand">
        <HeaderTemplate>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" class="grid">
                <thead>
                    <tr>
                        <th>
                            Page ID
                        </th>
                        <th>
                            Unique Page Code
                        </th>
                        <th>
                            Title
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Submitted On
                        </th>
                        <th>
                            Submitted By (Username)
                        </th>
                        <th>
                            Actions
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="plNoPendingMsg" runat="server">
                        <tr>
                            <td colspan="7">
                                There are no dynamic pages with pending status
                            </td>
                        </tr>
                    </asp:PlaceHolder>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Literal ID="ltPageID" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltPageNme" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltPageTitle" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltStatus" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltSubmittedOn" runat="server" />
                </td>
                <td>
                    <asp:Literal ID="ltSubmittedBy" runat="server" />
                </td>
                <td>
                    <%--                    <asp:LinkButton ID="lbRevisionRevert" runat="server" Text="Revert" CommandName="Revert" />
                    |
                    --%>
                    <asp:HyperLink ID="hlRevisionView" runat="server" Text="View" Target="_blank" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>
