<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCurrentJobStatistics.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucCurrentJobStatistics" %>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltCurrentJobStatistics" runat="server" SetLanguageCode="LinkButtonJobReports" />
    </h2>
</div>
<div class="form-all">
    <JXTControl:ucLanguageLiteral ID="ltSortBy" runat="server" SetLanguageCode="LabelSortBy" />
    &nbsp;<asp:DropDownList ID="ddlSortBy" runat="server" />
    &nbsp;<asp:DropDownList ID="ddlOrder" runat="server" />
    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" CssClass="mini-new-buttons" /><br />
    <br />
    <JXTControl:ucLanguageLiteral ID="ltNoResult" runat="server" SetLanguageCode="LabelNoResultFound"
        Visible="false" />
    <asp:Panel ID="pnlStatistics" runat="server" Visible="false">
        <table id="box-table">
            <thead>
                <tr>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitRefNo" runat="server" SetLanguageCode="LabelRefNo" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitDatePosted" runat="server" SetLanguageCode="LabelDatePosted" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitDaysTillExpiry" runat="server" SetLanguageCode="LabelDaysTillExpiry" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitViewed" runat="server" SetLanguageCode="LabelViewed" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="UclitApplications" runat="server" SetLanguageCode="LabelApplications" />
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptCurrentJobStatistics" runat="server" OnItemDataBound="rptCurrentJobStatistics_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="litJobTitle" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litDatePosted" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litDaysTillExpiry" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViewed" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litApplications" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </asp:Panel>
    <br />
    <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click"
        ValidationGroup="Current" CssClass="mini-new-buttons" />
</div>
