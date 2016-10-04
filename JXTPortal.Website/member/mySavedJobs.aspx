<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="mySavedJobs.aspx.cs" Inherits="JXTPortal.Website.members.mySavedJobs" %>
<%@ Register Src="~/usercontrols/member/ucMemberSavedJobs.ascx" TagName="ucMemberSavedJobs" TagPrefix="uc1" %>
<%@ Register src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" tagname="ucMemberAccountNavigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-container">
    <div id="content">  
        <div class="content-holder">
            <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_MemberMySavedJobs" />          
            
            <uc1:ucMemberSavedJobs ID="ucMemberSavedJobs" runat="server" />
            
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
