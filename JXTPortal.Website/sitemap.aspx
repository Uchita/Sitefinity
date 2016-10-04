<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="sitemap.aspx.cs" Inherits="JXTPortal.Website.sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <%--<h1>
                JXT Sitemap</h1>
            <p>
                Please find attached JXT Consultings sitemap.</p>--%>
                
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_SiteMap" />
                
            <div class="sitemap">
                <asp:Literal ID="litSiteMap" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
