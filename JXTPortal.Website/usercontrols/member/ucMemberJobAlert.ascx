<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberJobAlert.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberJobAlert" %>
<asp:Repeater ID="rptJobAlerts" runat="server" OnItemCommand="rptJobAlerts_ItemCommand"
    OnItemDataBound="rptJobAlerts_ItemDataBound">
    <HeaderTemplate>
        <table id="box-table">
            <thead>
                <tr>
                    <th scope="col" style="width: 40%">
                        <JXTControl:ucLanguageLiteral ID="ltlAlertNameTitle" runat="server" SetLanguageCode="LabelName" />
                    </th>
                    <th scope="col" style="width: 20%">
                        <JXTControl:ucLanguageLiteral ID="ltSendEmail" runat="server" SetLanguageCode="LabelSendEmailAlerts" />
                    </th>
                    <th scope="col" style="width: 20%">
                        <JXTControl:ucLanguageLiteral ID="ltlDateEnteredTitle" runat="server" SetLanguageCode="LabelDateEntered" />
                    </th>
                    <th scope="col" style="width: 20%">
                        <JXTControl:ucLanguageLiteral ID="ltlAction" runat="server" SetLanguageCode="LabelAction" />
                    </th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Eval("JobAlertName") %>
            </td>
            <td>
                <asp:Literal ID="ltlSendEmail" runat="server"></asp:Literal>
            </td>
            <td>
                <asp:Literal ID="ltLastModified" runat="server" />
            </td>
            <td>
                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("JobAlertID") %>' />
                |
                <span class="member-jobalerts-view"><asp:LinkButton ID="lbViewResults" runat="server" CommandName="View" CommandArgument='<%# Eval("JobAlertID") %>' />
                |</span>
                <asp:LinkButton ID="lbDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                    CommandName="Delete" CommandArgument='<%# Eval("JobAlertID") %>' CausesValidation="false">Delete</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
<p class="Member-nojob-alerts">
    <label>
        <asp:Literal ID="ltMemberNoJobAlerts" runat="server" Visible="false" />
    </label>
</p>
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
    <asp:HyperLink ID="hypJobAlertsViewLink" runat="server" NavigateUrl="/member/MyJobAlerts.aspx"
        Visible="false"></asp:HyperLink>
</div>
