<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteRepeaters.ascx.cs" Inherits="JXTPortal.Website.Admin.UserControls.SiteRepeaters" %>
<asp:Repeater ID="rptSitesObject" runat="server" 
    onitemdatabound="rptSitesObject_ItemDataBound">
    <HeaderTemplate>
        <h5><asp:Label ID="lblHeader" runat="server" /></h5>
    </HeaderTemplate>
    <ItemTemplate>
           <asp:CheckBox ID="chkID" runat="server" />
           <asp:CheckBox ID="chkOriginalID" runat="server" Visible="false" />
           <asp:HiddenField ID="hfID" runat="server" />
           <asp:Label ID="lblName" runat="server" /><br />
    </ItemTemplate>
    <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater>