<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberAccountNavigation.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.navigation.ucMemberAccountNavigation" %>
<ul id="memberProfileLinks" class="pull-right nav navbar-right">
    <li><a href="#" id="memberProfileDropdown" role="button" class="dropdown-toggle btn btn-default"
        data-toggle="dropdown">
        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelMyAccountProfile" />
        <b class="caret"></b></a>
        <ul class="dropdown-menu" role="menu" aria-labelledby="memberProfileDropdown">
            <li id="memberProfileHome"><a href="/member/default.aspx">
                <JXTControl:ucLanguageLiteral ID="litnavmembermyhome" runat="server" SetLanguageCode="LabelDashboard" />
            </a></li>
            <li id="memberProfileDetails"><a href="/member/settings.aspx">
                <JXTControl:ucLanguageLiteral ID="litnavmemberMyDetails" runat="server" SetLanguageCode="LinkButtonAccountDetails" />
            </a></li>
            <li id="memberProfilePassword"><a href="/member/changepassword.aspx">
                <JXTControl:ucLanguageLiteral ID="litnavmemberMyPassword" runat="server" SetLanguageCode="LabelMyPassword" />
            </a></li>
            <li id="memberProfileCV"><a href="/member/profile.aspx">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelProfile" />
            </a></li>
            <%--<li id="memberProfileCV"><a href="/member/cvbuilder.aspx"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelCVResumeBuilder" /></a></li>--%>
            <li class="divider"></li>
            <li id="memberProfileAlerts"><a href="/member/myjobalerts.aspx">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelFavouriteSearches" /> / <JXTControl:ucLanguageLiteral ID="litnavmemberMyJobAlerts" runat="server" SetLanguageCode="LabelMyJobAlerts" />
            </a></li>
            <li id="memberProfileSavedJobs"><a href="/member/mysavedjobs.aspx">
                <JXTControl:ucLanguageLiteral ID="litnavmemberMySavedJobs" runat="server" SetLanguageCode="LabelMySavedJobs" />
            </a></li>
            <li id="memberProfileApplication"><a href="/member/applicationtracker.aspx">
                <JXTControl:ucLanguageLiteral ID="litnavmemberMyApplicationTracker" runat="server"
                    SetLanguageCode="LabelMyApplicationTracker" />
            </a></li>
            <asp:PlaceHolder ID="phDraftJobs" runat="server" Visible="false">
                <li id='memberDraftJobs'><a href="/member/draftjobs.aspx">
                    <JXTControl:ucLanguageLiteral ID="litnavmemberDraftJobs" runat="server" SetLanguageCode="LabelDraftJobs" />
                </a></li>
            </asp:PlaceHolder>
            <li class="divider"></li>
            <li id="memberProfileLogout"><a href="/logout.aspx">
                <JXTControl:ucLanguageLiteral ID="UcLabelLogout" runat="server" SetLanguageCode="LabelLogout" />
            </a></li>
        </ul>
    </li>
</ul>
