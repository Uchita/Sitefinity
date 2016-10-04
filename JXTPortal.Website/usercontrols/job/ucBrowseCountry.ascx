<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBrowseCountry.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucBrowseCountry" %>
<h2>
    <asp:Literal ID="ltHeader" runat="server" /></h2>
<div class="line-break">
</div>
<asp:Repeater ID="rptCountryLocation" runat="server" OnItemDataBound="rptCountryLocation_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:Literal ID="ltLink" runat="server" /></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
