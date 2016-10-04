<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberDraftJobs.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberDraftJobs" %>
    <asp:Repeater ID="rptMemberApplicationTracker" runat="server" OnItemDataBound="rptMemberApplicationTracker_ItemDataBound">
        <HeaderTemplate>
            <table id="box-table">
                <tbody>
                    <tr>
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerJobsName" runat="server"
                                SetLanguageCode="LabelJobTitle" />
                        </th>
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerAdvertiser" runat="server"
                                SetLanguageCode="LabelAdvertiser" />
                        </th>
                        <th scope="col">
                            <JXTControl:ucLanguageLiteral ID="ltHeaderDraftDate" runat="server" SetLanguageCode="LabelDraftDate" />
                        </th>
                        <th scope="col">
                            &nbsp;
                        </th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink runat="server" ID="hypJobUrl" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltAdvertiserName" runat="server" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltDatePosted" runat="server" />
                </td>
                <td>
                    <asp:HyperLink ID="hlCoverLetterDownload" runat="server" CssClass="btn btn-success btn-xs">
                        <JXTControl:ucLanguageLiteral ID="ucContinueApplication" runat="server" SetLanguageCode="LabelContinueApplication" />
                    </asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="Member-nojob-tracker">
        <label>
            <asp:Literal ID="ltMemberNoJobTracker" runat="server" Visible="false" />
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
        <asp:HyperLink ID="hypApplicationTrackerViewLink" runat="server" NavigateUrl="/member/draftjobs.aspx"
            Visible="false"></asp:HyperLink>
    </div>
