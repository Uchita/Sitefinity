<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserAccountNavigation.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.navigation.ucAdvertiserAccountNavigation" %>
<ul id='advertiserDropdownLinks' class='pull-right nav navbar-right'>
    <li><a href='#' id='advertiserDropdown' role='button' class='dropdown-toggle btn btn-default'
        data-toggle='dropdown'>Advertiser menu <b class='caret'></b></a>
        <ul class='dropdown-menu' role='menu' aria-labelledby='advertiserDropdown'>
            <li class='advertiserLoggedas'>
                <JXTControl:ucLanguageLiteral ID="litnavAdvertiserCurrentLogin" runat="server" SetLanguageCode="LabelCurrentLogin" />
                <strong><asp:Literal ID="ltAdvertiserLoginName" runat="server" /></strong></li>
            <li class='divider'></li>
            <li id='advertiserDashHome'>
                <asp:HyperLink ID="hlManageJobs" runat="server" NavigateUrl="/advertiser/default.aspx">
                </asp:HyperLink>
                <ul class='dropdown-menu-sub'>
                    <li>
                        <asp:HyperLink ID="hlBuyJobCredits" runat="server" NavigateUrl="/advertiser/productselect.aspx">
                        </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hlCart" runat="server" NavigateUrl="/advertiser/orderpayment.aspx">
                        </asp:HyperLink></li>
                    <li id='advertiserDashNewJob'>
                        <asp:HyperLink ID="hlCreateNewJobAd" runat="server" NavigateUrl="/advertiser/jobcreate.aspx">
                        </asp:HyperLink></li>
                    <li id='advertiserDashCurrentJob'>
                        <asp:HyperLink ID="hlCurrentJobAds" runat="server" NavigateUrl="/advertiser/jobscurrent.aspx">
                        </asp:HyperLink></li>
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
                    <li id='advertiserDashDraft'>
                        <asp:HyperLink ID="hlDraftJobAds" runat="server" NavigateUrl="/advertiser/jobsdraft.aspx">
                        </asp:HyperLink></li>
                    <li id='advertiserDashArchived'>
                        <asp:HyperLink ID="hlArchivedJobAds" runat="server" NavigateUrl="/advertiser/jobsarchived.aspx">
                        </asp:HyperLink></li>
                </ul>
            </li>
            <li class='divider'></li>
            <li id='advertiserDashDetails'><asp:HyperLink ID="hlAccountDetails" runat="server" NavigateUrl="/advertiser/edit.aspx">
            </asp:HyperLink>
                <ul class='dropdown-menu-sub'>
                    <li id='advertiserDashSubaccount'><asp:HyperLink ID="hlSubAccounts" runat="server" NavigateUrl="/advertiser/edit.aspx?tab=1">
                    </asp:HyperLink></li>
                    <li id='advertiserDashAdvlogo'><asp:HyperLink ID="hlViewChangeLogo" runat="server" NavigateUrl="/advertiser/logoedit.aspx">
                    </asp:HyperLink></li>
                    <li id='advertiserDashPassword'><asp:HyperLink ID="hlChangePassword" runat="server" NavigateUrl="/advertiser/edit.aspx?tab=2">
                    </asp:HyperLink></li>
                </ul>
            </li>
            <li class='divider'></li>
            <li id='advertiserDashTemplatelogo'><asp:HyperLink ID="hlChangeTemplateLogo" runat="server" NavigateUrl="/advertiser/advertiserjobtemplatelogo.aspx">
            </asp:HyperLink></li>
            <li class='divider'></li>
            <li id='advertiserDashTracker'><asp:HyperLink ID="hlJobTracker" runat="server" NavigateUrl="~/advertiser/jobtracker.aspx">
            </asp:HyperLink>
            </li>
            <li class='divider'></li>
            <li id='advertiserDashStatistics'><asp:HyperLink ID="hlStatistics" runat="server" NavigateUrl="~/advertiser/statistics.aspx">
            </asp:HyperLink>
            </li>
            <li class='divider'></li>
            <li id='advertiserDashLogout'><asp:HyperLink ID="lnkLogout" runat="server" NavigateUrl="~/logout.aspx?advertiser=true"></asp:HyperLink></li>
        </ul>
    </li>
</ul>
