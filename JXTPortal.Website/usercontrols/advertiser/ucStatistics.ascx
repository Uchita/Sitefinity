<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucStatistics.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucStatistics" %>
<asp:Panel ID="pnlTitle" runat="server">
    <div class="form-header-group">
        <h2 class="form-header">
            <JXTControl:ucLanguageLiteral ID="ltStatistics" runat="server" SetLanguageCode="LabelStatistics" />
        </h2>
    </div>
</asp:Panel>
<asp:Panel ID="pnlStatistics" runat="server">
    <div class="table-responsive">
        <table class="box-table table table-hover">
            <thead>
                <tr>
                    <th scope="col">
                        &nbsp;
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltNumber" runat="server" SetLanguageCode="LabelNumber" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltApplications" runat="server" SetLanguageCode="LabelApplications" />
                    </th>
                    <th scope="col">
                        <JXTControl:ucLanguageLiteral ID="ltViewed" runat="server" SetLanguageCode="LabelViewed" />
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptStatistics" runat="server" OnItemDataBound="rptStatistics_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <strong>
                                    <asp:HyperLink ID="hlJobType" runat="server" />
                                    <asp:Literal ID="litJobType" runat="server" Visible="false" /></strong>
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litNumber" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litApplications" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViewed" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Panel>
