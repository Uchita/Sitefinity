<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsCategoryList.ascx.cs" Inherits="JXTPortal.Website.usercontrols.navigation.ucNewsCategoryList" %>
<asp:Repeater ID="rptNewsCategories" runat="server" OnItemDataBound="rptNewsCategories_ItemDataBound">
    <HeaderTemplate>
        <div class="side-left-header"><asp:Literal ID="ltlNews" runat="server" /></div>
        <div class="links-2">
        <ul>
            <li><asp:HyperLink ID="hlnkAllCategories" runat="server" Text="All Categories" />
                <ul>
    </HeaderTemplate>
    <ItemTemplate>
            <li><asp:HyperLink ID="hlinkNewsCategory" runat="server" /></li>        
    </ItemTemplate>
    <FooterTemplate>
                </ul>
            </li>
        </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>