<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberSavedJobs.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberSavedJobs" %>
<asp:Repeater ID="rptMemberSavedJobs" runat="server" OnItemDataBound="rptMemberSavedJobs_ItemDataBound">
    <HeaderTemplate>
        <table id="box-table">
            <thead>
                <tr>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelReferenceNumber" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltHeaderSavedJobsName" runat="server" SetLanguageCode="LabelJobTitle" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelDatePosted" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelExpiryDate" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltHeaderSavedJobsDate" runat="server" SetLanguageCode="LabelSavedDate" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltAction" runat="server" SetLanguageCode="LabelAction" />
                    </th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td scope="col">
                <asp:Literal ID="ltRefNo" runat="server" />
            </td>
            <td scope="col">
                <asp:HyperLink ID="hlSavedJobsName" runat="server" />
            </td>
            <td scope="col">
                <asp:Literal ID="ltDatePosted" runat="server" />
            </td>
            <td scope="col">
                <asp:Literal ID="ltExpiryDate" runat="server" />
            </td>
            <td scope="col">
                <asp:Literal ID="ltSavedJobsDate" runat="server" />
            </td>
            <td>
                <asp:LinkButton ID="lnkSavedJobsDelete" runat="server" ValidationGroup="SubAccounts"
                    OnClick="lnkSavedJobsDelete_Click" CausesValidation="false">
                </asp:LinkButton>|
                <asp:HyperLink ID="hlViewSavedJobs" runat="server">
                    <asp:Literal ID="ltViewSavedJobs" runat="server" /></asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
<div class="Member-nosave-jobs">
    <label>
        <asp:Literal ID="ltMemberNoSaveJobs" runat="server" Visible="false" />
    </label>
</div>
<asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
    <HeaderTemplate>
        <div id="tnt_pagination">
    </HeaderTemplate>
    <ItemTemplate>
        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<div class="linkMemberBroadcastViewMore">
    <asp:HyperLink ID="hypSavedJobsViewLink" runat="server" NavigateUrl="/member/mysavedjobs.aspx"
        Visible="false"></asp:HyperLink>
</div>
