<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBrowseProfession.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucBrowseProfession" %>
<h2>
    <asp:Literal ID="ltHeader" runat="server" />
</h2>
<div class="line-break">
</div>
<asp:Repeater ID="rptProfessionRoles" runat="server" 
    onitemdatabound="rptProfessionRoles_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:Literal ID="ltLink" runat="server" /></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>