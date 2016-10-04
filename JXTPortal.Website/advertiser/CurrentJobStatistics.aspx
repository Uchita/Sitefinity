<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="CurrentJobStatistics.aspx.cs" Inherits="JXTPortal.Website.advertiser.CurrentJobStatistics" %>

<%@ Register Src="~/usercontrols/advertiser/uccurrentjobstatistics.ascx" TagName="ucCurrentJobStatistics"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
    <div class="content-holder">
        <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserCurrentJobStats" />    
        <uc1:ucCurrentJobStatistics id="ucCurrentJobStatistics1" runat="server" />
    </div>
    </div>
</asp:Content>
