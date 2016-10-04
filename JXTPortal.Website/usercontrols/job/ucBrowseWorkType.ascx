<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBrowseWorkType.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucBrowseWorkType" %>
<h2>
    Jobs By Work Type</h2>
<div class="line-break">
</div>
<asp:Repeater ID="rptWorkType" runat="server" OnItemDataBound="rptWorkType_ItemDataBound">
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
