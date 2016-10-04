<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobsArchived.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucJobsArchived" %>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobArchived" runat="server" SetLanguageCode="LabelArchivedJobs" />
    </h2>
</div>
<div class="form-all">
    <span style="width: 700px; display: block;">
        <asp:Literal ID="litMessage" runat="server" /></span>
    <asp:Panel ID="pnlArchivedJobs" runat="server">
        <table id="box-table" data-limit-navigation="10">
            <thead>
                <tr>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcJobRefNo" runat="server" SetLanguageCode="LabelRefNo" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcViews" runat="server" SetLanguageCode="LabelViews" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcApplications" runat="server" SetLanguageCode="LabelApplications" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcPosted" runat="server" SetLanguageCode="LabelPosted" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltUcExpiry" runat="server" SetLanguageCode="LabelExpiry" />
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptArchivedJobs" runat="server" OnItemDataBound="rptArchivedJobs_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td scope="col">
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litJobTitle" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViews" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litApplications" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litPosted" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litExpiry" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody></table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <JXTControl:ucLanguageLiteral ID="ltPage" runat="server" SetLanguageCode="LabelPage" />
                        :
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
    </asp:Panel>
</div>
