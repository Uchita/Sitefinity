<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="PublicProfile.aspx.cs" Inherits="JXTPortal.Website.members.PublicProfile" %>

<%@ Register Src="~/usercontrols/peoplesearch/ucPublicProfile.ascx" TagName="ucPublicProfile"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.structure.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.theme.css" />
    <link rel="stylesheet" href="/styles/member/jscrollpane.css" />
    <link rel="stylesheet" href="/styles/member/member_profile.css" />
    <!-- the mousewheel plugin -->
    <script type="text/javascript" src="/scripts/member/jquery.mousewheel.js"></script>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="/scripts/member/jquery.jscrollpane.js"></script>
    <script src='/scripts/member/jquery-ui.js'></script>
    <script src='/scripts/member/profile-builder.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_PublicProfile" />
            <uc1:ucPublicProfile ID="ucPeopleSearchPublicProfile" runat="server" />
        </div>
    </div>
</asp:Content>
