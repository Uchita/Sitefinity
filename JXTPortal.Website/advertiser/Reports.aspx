<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="JXTPortal.Website.advertiser.Reports" %>

<%@ Register Src="~/usercontrols/advertiser/ucCurrentJobStatistics.ascx" TagName="ucCurrentJobStatistics"
    TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/advertiser/ucHistoricalJobStatistics.ascx" TagName="ucHistoricalJobStatistics"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release" ></ajaxToolkit:ToolkitScriptManager>
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_Reports" />
            <div class="tabs-holder">
                <ul id="ulTabs" class="tabs">
                    <li><a href="#tab1">
                        <JXTControl:ucLanguageLiteral ID="litCurrentJobStatistics" runat="server" SetLanguageCode="LabelCurrentJobStatistics" />
                    </a></li>
                    <li><a href="#tab2">
                        <JXTControl:ucLanguageLiteral ID="litHistoricalJobStatistics" runat="server" SetLanguageCode="LabelHistoricalJobStatistics" />
                    </a></li>
                </ul>
                <div id="tabcontainer" runat="server" class="tab_container">
                    <div id="tab1" class="tab_content">
                        <uc1:ucCurrentJobStatistics ID="ucCurrentJobStatistics1" runat="server" />
                    </div>
                    <div id="tab2" class="tab_content">
                        <asp:UpdatePanel ID="updatePanel" runat="server">
                            <ContentTemplate>
                                <uc2:ucHistoricalJobStatistics id="ucHistoricalJobStatistics1" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                $(document).ready(function() {

                    //When page loads...
                    $(".tab_content").hide(); //Hide all content
                    $("ul.tabs li").removeClass("active");
                    $("ul.tabs li:eq(<%=SelectedTabIndex %>)").addClass("active").show(); //Activate first tab
                    $(".tab_content:eq(<%=SelectedTabIndex %>)").show(); //Show first tab content

                    //On Click Event
                    $("ul.tabs li").click(function() {

                        $("ul.tabs li").removeClass("active"); //Remove any "active" class
                        $(this).addClass("active"); //Add "active" class to selected tab
                        $(".tab_content").hide(); //Hide all tab content

                        var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
                        $(activeTab).fadeIn(); //Fade in the active ID content
                        return false;
                    });

                });

            </script>

        </div>
    </div>
</asp:Content>
