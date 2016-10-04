<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="JXTPortal.Website.advertiser.Statistics" %>

<%@ Register Src="~/usercontrols/advertiser/ucStatistics.ascx" TagName="ucStatistics"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container" class="newDash">
        <div id="content">
            <div class="content-holder">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserStatistics" />
                <uc1:ucStatistics ID="ucStatistics1" runat="server" ShowTitle="false" />
            </div>
        </div>
    </div>
</asp:Content>
