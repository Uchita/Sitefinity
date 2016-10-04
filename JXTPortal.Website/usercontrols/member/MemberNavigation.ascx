<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberNavigation.ascx.cs" Inherits="JXTPortal.Website.usercontrols.navigation.MemberNavigation" %>
<div class="login-status">
    <p><JXTControl:ucLanguageLiteral ID="litnavmemberCurrentLogin" runat="server" SetLanguageCode="LabelCurrentLogin" />
    </p>
    <p class="login-name"><asp:Literal ID="ltMemberLoginName" runat="server"></asp:Literal></p>
    <hr />
    <p>
        <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" CausesValidation="false">
        </asp:LinkButton>
        <a href="/member/register.aspx"> / 
            <JXTControl:ucLanguageLiteral ID="litnavmemberregister" runat="server" SetLanguageCode="LabelRegister" />
        </a>
    </p>
</div>

<div class="side-left-header"><JXTControl:ucLanguageLiteral ID="litnavmemberjobseeker" runat="server" SetLanguageCode="LabelJobSeeker" /></div>
<div class="links-2">
    <ul>
        <li id='liMemberHome'><a href="/member/default.aspx"><JXTControl:ucLanguageLiteral ID="litnavmembermyhome" runat="server" SetLanguageCode="LabelMyHome" /></a>
            <ul>
                <li id='liMemberMyDetails'><a href="/member/settings.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMyDetails" runat="server" SetLanguageCode="LabelMyDetails" /></a></li>
                <li id='liMemberMySearchCrtiteria'><a href="/member/searchcriteria.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMySearchCrtiteria" runat="server" SetLanguageCode="LabelMySearchCriteria" /></a></li>
                <li id='liMemberMyPassword'><a href="/member/changepassword.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMyPassword" runat="server" SetLanguageCode="LabelMyPassword" /></a></li>
                <li id='liMemberMyResumeCoverLetter'><a href="/member/myresumecoverletter.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMyResumeCoverLetter" runat="server" SetLanguageCode="LabelMyResumeCoverLetter" /></a></li>
            </ul>
        </li>
        <li id='liMemberMyJobTools'><a href="#"><JXTControl:ucLanguageLiteral ID="litnavmemberMyJobTools" runat="server" SetLanguageCode="LabelMyJobTools" /></a>
            <ul>
                <li id='liMemberMyJobAlerts'><a href="/member/myjobalerts.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMyJobAlerts" runat="server" SetLanguageCode="LabelMyJobAlerts" /></a></li>
                <li id='liMemberMySavedJobs'><a href="/member/mysavedjobs.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMySavedJobs" runat="server" SetLanguageCode="LabelMySavedJobs" /></a></li>
                <li id='liMemberMyApplicationTracker'><a href="/member/applicationtracker.aspx"><JXTControl:ucLanguageLiteral ID="litnavmemberMyApplicationTracker" runat="server" SetLanguageCode="LabelMyApplicationTracker" /></a></li>                
            </ul>
        
        </li>
    </ul>
</div>