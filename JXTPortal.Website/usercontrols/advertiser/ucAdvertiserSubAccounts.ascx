<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserSubAccounts.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucAdvertiserSubAccounts" %>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountHeader" runat="server" SetLanguageCode="LabelSubAccounts" />
    </h2>
</div>
    <asp:Literal ID="litMessage" runat="server" />
    <div class="search-sequence">
        <p>
            <asp:Repeater ID="rptSubAccounts" runat="server" OnItemCommand="rptSubAccounts_ItemCommand"
                OnItemDataBound="rptSubAccounts_ItemDataBound">
                <HeaderTemplate>
                    <table id="box-table">
                        <thead>
                            <tr>
                                <th scope="col">
                                    &nbsp;
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountUsername" runat="server" SetLanguageCode="LabelUserName" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountFirstname" runat="server" SetLanguageCode="LabelFirstName" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountSurname" runat="server" SetLanguageCode="LabelSurname" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountEmail" runat="server" SetLanguageCode="LabelEmail" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountNewsletter" runat="server" SetLanguageCode="LabelNewsletter" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountValidated" runat="server" SetLanguageCode="LabelValidated" />
                                </th>
                                <th scope="col">
                                    <JXTControl:ucLanguageLiteral ID="ltUcAdvSubAccountLastModified" runat="server" SetLanguageCode="LabelLastModified" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbSelect" runat="server" ValidationGroup="SubAccounts" CommandName="Select"
                                Text="Select" />
                        </td>
                        <td scope="col">
                            <asp:Label ID="lblUserName" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Label ID="lblFirstName" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Label ID="lblSurame" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Label ID="lblEmail" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:CheckBox ID="cbNewsletter" runat="server" Enabled="false" />
                        </td>
                        <td scope="col">
                            <asp:CheckBox ID="cbValidated" runat="server" Enabled="false" />
                        </td>
                        <td scope="col">
                            <asp:Label ID="lblLastModified" runat="server" Enabled="false" />
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
                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="SubAccounts" />
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </p>
    </div>
    <br />
    <asp:Button runat="server" ID="btnAdvertiserUsers" OnClientClick="javascript:location.href='/advertiser/register.aspx?action=add'; return false;"
        ValidationGroup="SubAccounts" Text="Add New" CssClass="mini-new-buttons sub-accounts-button" />

