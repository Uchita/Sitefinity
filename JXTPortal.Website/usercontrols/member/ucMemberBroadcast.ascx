<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberBroadcast.ascx.cs" Inherits="JXTPortal.Website.usercontrols.member.ucMemberBroadcast" %>
<%@ Register Src="~/usercontrols/member/ucMemberSavedJobs.ascx" TagName="ucMemberSavedJobs" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/member/ucMemberApplicationTracker.ascx" TagName="ucMemberApplicationTracker" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/member/ucMemberJobAlert.ascx" TagName="ucMemberJobAlert" TagPrefix="uc3" %>
<h2><JXTControl:ucLanguageLiteral ID="UcMemberheaderbroadcast" runat="server" SetLanguageCode="LabelMyBroadcast" /></h2>
<p><JXTControl:ucLanguageLiteral ID="UcMemberwelcomebroadbast" runat="server" SetLanguageCode="LabelWelcomeBroadcast" /></p>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="UcMemberBcastSavedjobs" runat="server" SetLanguageCode="LabelMySavedJobs" />
    </h2>
</div>


<div class="form-all">
    <ul class="form-section">
        
        <li id="memberBroadcast-SavedJobs">
            <uc1:ucMemberSavedJobs ID="ucMemberSavedJobs" runat="server" />
        </li>
        
        
        <li id="memberBroadcast-HeaderApplicationTracker">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="UcMemberBcastAppTracker" runat="server" SetLanguageCode="LabelMyApplicationTracker" />
                </h2>
            </div>
        </li>
        
        <li id="memberBroadcast-ApplicationTracker">
            <uc2:ucMemberApplicationTracker ID="ucMemberApplicationTracker" runat="server" />
        </li>
        
        <li id="memberBroadcast-HeaderJobAlert">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="UcMemberBcastJobAlert" runat="server" SetLanguageCode="LabelMyJobAlerts" />
                </h2>
            </div>
        </li>
        
        <li id="memberBroadcast-JobAlert">
            <uc3:ucMemberJobAlert ID="ucMemberJobAlert" runat="server" />            
        </li>
        
        
    </ul>
</div>