<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="JobsArchived.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobsArchived"
    EnableEventValidation="false" %>

<%@ Register Src="~/usercontrols/advertiser/ucHistoricalJobStatistics.ascx" TagName="ucHistoricalJobStatistics"
    TagPrefix="uc1" %>
<%@ Register Src="/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx" TagName="ucAdvertiserAccountNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/lib/footable.core.css" />
    <!-- New Script -->
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        function RepostJobs() {
            if ($('#jobsTable input[type=checkbox]:checked').length == 0) {
                alert('<%=JXTPortal.Website.CommonFunction.GetResourceValue("LabelNoJobSelected")%>');
                return false;
            }
            else {
                if (confirm('<%=JXTPortal.Website.CommonFunction.GetResourceValue("LabelConfirmRepost")%>')) {
                    return true;
                }
                else {
                    return false;
                }

            }
            return false;
        }
    </script>
    <div id="content-container" class="newDash">
        <div id="content">
            <div class="content-holder">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserJobsArchived" />
                <uc2:ucAdvertiserAccountNavigation ID="ucAdvertiserAccountNavigation1" runat="server" />
                <%--<asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>--%>
                <uc1:ucHistoricalJobStatistics ID="ucHistoricalJobStatistics1" runat="server" IsAdmin="false" />
                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function LoadFooTable() {

            $("#jobsTable").footable();

        }
    </script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.sort.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.filter.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.paginate.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.bookmarkable.js"
        type="text/javascript"></script>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js' type="text/javascript"></script>
</asp:Content>
