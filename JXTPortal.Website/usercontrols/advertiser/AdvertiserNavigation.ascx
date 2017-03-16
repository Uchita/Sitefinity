<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserNavigation.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.AdvertiserNavigation" %>
<div class="login-status">
    <p>
        <JXTControl:ucLanguageLiteral ID="litnavAdvertiserCurrentLogin" runat="server" SetLanguageCode="LabelCurrentLogin" />
    </p>
    <p class="login-name">
        <asp:Literal ID="ltAdvertiserLoginName" runat="server" /></p>
    <hr />
    <p>
        <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click" CausesValidation="false"></asp:LinkButton>
        <a href="/advertiser/register.aspx">/
            <JXTControl:ucLanguageLiteral ID="litnavAdvertiserRegister" runat="server" SetLanguageCode="LabelRegister" />
        </a>
    </p>
</div>
<div class="side-left-header">
    <JXTControl:ucLanguageLiteral ID="litnavAdvertiser" runat="server" SetLanguageCode="LabelAdvertiser" />
</div>
<div class="links-2">
    <ul>
        <li>
            <asp:HyperLink ID="hlManageJobs" runat="server" NavigateUrl="/advertiser/default.aspx">
            </asp:HyperLink>
            <ul>
                <li>
                    <asp:HyperLink ID="hlCreateNewJobAd" runat="server" NavigateUrl="/advertiser/jobcreate.aspx">
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlCurrentJobAds" runat="server" NavigateUrl="/advertiser/jobscurrent.aspx">
                    </asp:HyperLink>
                </li>
                <asp:PlaceHolder ID="phPendingJobs" runat="server" Visible="False">
                    <li>
                        <asp:HyperLink ID="hlPendingJobs" runat="server" NavigateUrl="/advertiser/jobspending.aspx">
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlDeclinedJobs" runat="server" NavigateUrl="/advertiser/jobsdeclined.aspx">
                        </asp:HyperLink>
                    </li>
                </asp:PlaceHolder>
                <li>
                    <asp:HyperLink ID="hlDraftJobAds" runat="server" NavigateUrl="/advertiser/jobsdraft.aspx">
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlArchivedJobAds" runat="server" NavigateUrl="/advertiser/jobsarchived.aspx">
                    </asp:HyperLink>
                </li>
            </ul>
        </li>
        <li>
            <asp:HyperLink ID="hlAccountDetails" runat="server" NavigateUrl="/advertiser/edit.aspx">
            </asp:HyperLink>
            <ul>
                <asp:PlaceHolder ID="phSubAccounts" runat="server">
                    <li>
                        <asp:HyperLink ID="hlSubAccounts" runat="server" NavigateUrl="/advertiser/edit.aspx?tab=1">
                        </asp:HyperLink>
                    </li>
                </asp:PlaceHolder>
                <li>
                    <asp:HyperLink ID="hlViewChangeLogo" runat="server" NavigateUrl="/advertiser/logoedit.aspx">
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlChangePassword" runat="server" NavigateUrl="/advertiser/edit.aspx?tab=2">
                    </asp:HyperLink>
                </li>
            </ul>
        </li>
        <li>
            <asp:HyperLink ID="hlChangeTemplateLogo" runat="server" NavigateUrl="/advertiser/advertiserjobtemplatelogo.aspx">
            </asp:HyperLink>
            <ul>
                <li>
                    <asp:HyperLink ID="hlViewChangeTemplateLogo" runat="server" NavigateUrl="/advertiser/advertiserjobtemplatelogo.aspx">
                    </asp:HyperLink>
                </li>
            </ul>
        </li>
        <asp:PlaceHolder ID="phPeopleSearch" runat="server" Visible="false">
            <li>
                <asp:HyperLink ID="hlPeopleSearch" runat="server" NavigateUrl="~/peoplesearch.aspx">
                </asp:HyperLink>
            </li>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phScreeningQuestions" runat="server" Visible="false">
            <li>
                <asp:HyperLink ID="hlScreeningQuestionTemplate" runat="server" NavigateUrl="~/advertiser/screeningquestionstemplates.aspx">
                </asp:HyperLink>
            </li>
        </asp:PlaceHolder>
        <li>
            <asp:HyperLink ID="hlJobTracker" runat="server" NavigateUrl="~/advertiser/jobtracker.aspx">
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="hlStatistics" runat="server" NavigateUrl="~/advertiser/statistics.aspx">
            </asp:HyperLink>
        </li>
        
    </ul>
</div>
