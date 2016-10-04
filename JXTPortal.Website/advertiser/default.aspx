<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="JXTPortal.Website.advertiser._default" %>

<%@ Register Src="~/usercontrols/advertiser/ucAdvertiserBroadcast.ascx" TagName="ucAdvertiserBroadcast"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div id="content-container" class="newDash">
        <div id="content">
            <div class="content-holder">
                <%--<h2>
                    <asp:Literal ID="ltHomeAdvertiserName" runat="server" /></h2>--%>
                <%--            <div class="tabs-holder">
                <ul class="tabs">
                    <li><a href="#tab1">
                        <JXTControl:ucLanguageLiteral ID="ltMemberDefMyBroad" runat="server" SetLanguageCode="LabelMyBroadcast" />
                    </a></li>
                </ul>
                <div class="tab_container">
                    <div id="tab1" class="tab_content">
                        <uc1:ucAdvertiserBroadcast ID="ucAdvertiserBroadcast1" runat="server" />
                    </div>
                </div>

            </div>--%>
                <asp:Literal ID="ltlSystemDynamicPage" runat="server" />
            </div>
        </div>
    </div>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js'></script>
</asp:Content>
