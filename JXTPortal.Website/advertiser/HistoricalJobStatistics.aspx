<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="HistoricalJobStatistics.aspx.cs" Inherits="JXTPortal.Website.advertiser.HistoricalJobStatistics" %>

<%@ Register Src="~/usercontrols/advertiser/ucHistoricalJobStatistics.ascx" TagName="ucHistoricalJobStatistics"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserHistoricalStatistics" />
            <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>
                    <uc1:ucHistoricalJobStatistics ID="ucHistoricalJobStatistics1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

