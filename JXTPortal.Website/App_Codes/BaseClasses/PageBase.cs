using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal.Entities;
using System.Web.UI.WebControls;
using JXTPortal.Website.usercontrols.common;
using System.Configuration;
using System.Data;
using System.Text;
using JXTPortal.Common;


namespace JXTPortal.Website
{
    public class PageBase : System.Web.UI.MasterPage
    {

        #region Properties

        private DynamicPagesService _dynamicPagesService = null;

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        private RelatedDynamicPagesService _relateddynamicPagesService = null;

        private RelatedDynamicPagesService RelatedDynamicPagesService
        {
            get
            {
                if (_relateddynamicPagesService == null)
                {
                    _relateddynamicPagesService = new RelatedDynamicPagesService();
                }
                return _relateddynamicPagesService;
            }
        }

        private GlobalSettingsService _globalSettingsService = null;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        private DynamicpagesCustomWidgetService _DynamicpagesCustomWidgetService = null;

        private DynamicpagesCustomWidgetService DynamicpagesCustomWidgetService
        {
            get
            {
                if (_DynamicpagesCustomWidgetService == null)
                {
                    _DynamicpagesCustomWidgetService = new DynamicpagesCustomWidgetService();
                }
                return _DynamicpagesCustomWidgetService;
            }
        }

        private AdvertisersService _advertiserServicesService = null;

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertiserServicesService == null)
                {
                    _advertiserServicesService = new AdvertisersService();
                }
                return _advertiserServicesService;
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            SessionService.SessionVerify();
        }

        /// <summary>
        /// Set the Header, Footer, Meta Content, CSS/ Scripts, and Set Page Title
        /// </summary>
        /// <param name="ucHeader"></param>
        /// <param name="ucFooter"></param>
        /// <param name="ltlLeftNavigation"></param>
        /// <param name="ltlRightNavigation"></param>
        /// <param name="ltlMetaContent"></param>
        /// <param name="ltlCSSAndScripts"></param>
        /// <param name="page"></param>
        /// <param name="strPageTitle"></param>
        public void LoadPageContent(ucHeader ucHeader, ucFooter ucFooter, 
                                    Literal ltlLeftNavigation, Literal ltlRightNavigation,
                                    Literal ltlAboveHeader, Literal ltlBelowFooter,
                                    Literal ltlMetaContent, Literal ltlDocType, Literal ltlCSSAndScripts, 
                                    System.Web.UI.Page page, String strPageTitle)
        {
            // ToDo - May be Meta keywords, and description - in future

            // Change the language which comes from session.
            using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId,
                                                                        ConfigurationManager.AppSettings["DefaultPageCodeForLayout"], 
                                                                        SessionData.Language.LanguageId))
            {   
                if (dynamicPage != null)
                {
                    if (dynamicPage.DynamicPageWebPartTemplateId.HasValue)
                    {

                        string strHeader = string.Empty, strFooter = string.Empty, strLefNav = string.Empty, strRightNav = string.Empty;
                        string strAboveHeader = string.Empty; string strBelowFooter = string.Empty;

                        DynamicPagesService.SetDynamicPageWebPartTemplateId(dynamicPage.DynamicPageWebPartTemplateId.Value,
                                                                                ref strHeader, ref strLefNav,
                                                                                ref strRightNav, ref strFooter, ref strAboveHeader, ref strBelowFooter, CommonPage.PageName);

                        //Breadcrumb

                        strAboveHeader = ReplaceWebPartBreadcrumb(strAboveHeader, dynamicPage);
                        strBelowFooter = ReplaceWebPartBreadcrumb(strBelowFooter, dynamicPage);
                        strHeader = ReplaceWebPartBreadcrumb(strHeader, dynamicPage);
                        strFooter = ReplaceWebPartBreadcrumb(strFooter, dynamicPage);
                        strLefNav = ReplaceWebPartBreadcrumb(strLefNav, dynamicPage);
                        strRightNav = ReplaceWebPartBreadcrumb(strRightNav, dynamicPage);

                        // Sign out / Sign In
                        strAboveHeader = LoadMemberSignAndOutAndDashboard(strAboveHeader);
                        strBelowFooter = LoadMemberSignAndOutAndDashboard(strBelowFooter);
                        strHeader = LoadMemberSignAndOutAndDashboard(strHeader);
                        strFooter = LoadMemberSignAndOutAndDashboard(strFooter);
                        strLefNav = LoadMemberSignAndOutAndDashboard(strLefNav);
                        strRightNav = LoadMemberSignAndOutAndDashboard(strRightNav);

                        // Replace login status menu
                        strAboveHeader = LoadLoginStatusMenu(strAboveHeader);
                        strBelowFooter = LoadLoginStatusMenu(strBelowFooter);
                        strHeader = LoadLoginStatusMenu(strHeader);
                        strFooter = LoadLoginStatusMenu(strFooter);
                        strLefNav = LoadLoginStatusMenu(strLefNav);
                        strRightNav = LoadLoginStatusMenu(strRightNav);

                        // Replace member counters
                        strAboveHeader = LoadMemberResultCounters(strAboveHeader);
                        strBelowFooter = LoadMemberResultCounters(strBelowFooter);
                        strHeader = LoadMemberResultCounters(strHeader);
                        strFooter = LoadMemberResultCounters(strFooter);
                        strLefNav = LoadMemberResultCounters(strLefNav);
                        strRightNav = LoadMemberResultCounters(strRightNav);
                        
                        // Custom Widget
                        strLefNav = ReplaceLeftNavWidget(strLefNav, dynamicPage);
                        strRightNav = ReplaceRightNavWidget(strRightNav, dynamicPage);

                        ltlAboveHeader.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strAboveHeader);
                        ltlBelowFooter.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strBelowFooter);

                        ucHeader.SetContent = CommonAdvancedSearch.GetAdvancedSearchWidget(strHeader);
                        ucFooter.SetContent = CommonAdvancedSearch.GetAdvancedSearchWidget(strFooter);

                        ucHeader.Visible = !string.IsNullOrEmpty(strHeader);
                        ucFooter.Visible = !string.IsNullOrEmpty(strFooter);
                        
                        
                        if (ltlLeftNavigation != null)
                        {
                            strLefNav = LoadRelatedPages(strLefNav).Replace(PortalConstants.DynamicNavigation.DYNAMIC_NAVIGATION, string.Empty);
                            ltlLeftNavigation.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strLefNav);
                        }

                        if (ltlRightNavigation != null)
                        {
                            strRightNav = LoadRelatedPages(strRightNav).Replace(PortalConstants.DynamicNavigation.DYNAMIC_NAVIGATION, string.Empty);
                            ltlRightNavigation.Text = CommonAdvancedSearch.GetAdvancedSearchWidget(strRightNav);
                        }

                    }
                    
                    if (ltlMetaContent != null)
                        SetMetaContentWithFavIcon(ltlMetaContent, ltlDocType, page, strPageTitle, string.Empty, string.Empty, false, false);
                    

                    // Load CSS and Javascript of the page
                    ltlCSSAndScripts.Text = DynamicPagesService.GetDynamicPageJavascriptCSS(dynamicPage.PageName);

                }
            }
        }

        public string ReplaceWebPartBreadcrumb(string text, JXTPortal.Entities.DynamicPages dynamicPage, bool isPageContent = false)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB) || isPageContent)
            {
                StringBuilder sb = new StringBuilder();
                TList<Entities.DynamicPages> pagelist = new TList<Entities.DynamicPages>();
                pagelist.Add(dynamicPage);

                if (dynamicPage.ParentDynamicPageId != 0)
                {
                    JXTPortal.Entities.DynamicPages page = DynamicPagesService.GetByDynamicPageId(dynamicPage.ParentDynamicPageId);
                    if (page != null)
                    {
                        pagelist.Insert(0, page);

                        if (page.ParentDynamicPageId != 0)
                        {
                            JXTPortal.Entities.DynamicPages parentpage = DynamicPagesService.GetByDynamicPageId(page.ParentDynamicPageId);
                            pagelist.Insert(0, parentpage);
                        }
                    }
                }

                for (int i = 0; i < pagelist.Count; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"parent\""));
                    }
                    else if (i == 1)
                    {
                        sb.Append(" / " + DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"child\""));
                    }
                    else
                    {
                        sb.Append(" / " + DynamicPagesService.GetDynamicPageLink(pagelist[i], "class=\"grandchild\""));
                    }
                }
                if (isPageContent)
                {
                    return "<div class=\"dynamic-breadcrumb\" itemprop=\"breadcrumb\">" + sb.ToString() + "</div>";
                }
                else
                {
                    return text.Replace(PortalConstants.DynamicNavigation.WEBPART_BREADCRUMB, "<div class=\"webpart-breadcrumb\">" + sb.ToString() + "</div>"); //  itemprop=\"breadcrumb\"
                }
            }

            return text;
        }


        public string ReplaceLeftNavWidget(string text, JXTPortal.Entities.DynamicPages dynamicPage)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_LEFT))
            {
                // Retrieve all widgets

                StringBuilder sb = new StringBuilder();

                DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dynamicPage.DynamicPageId, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.AppendLine(string.Format("<div class=\"custom-widget custom-widget-{0} {1}\">\n{2}\n</div>", dr["CustomWidgetID"].ToString(), dr["CustomWidgetCSSSelectorClassName"].ToString(), dr["Content"].ToString()));
                    }
                }

                text = text.Replace(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_LEFT, string.Format("<div class=\"custom-widget-group-left\">\n{0}\n</div>", sb.ToString()));
            }

            return text;
        }

        public string ReplaceRightNavWidget(string text, JXTPortal.Entities.DynamicPages dynamicPage)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_RIGHT))
            {
                // Retrieve all widgets

                StringBuilder sb = new StringBuilder();

                DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dynamicPage.DynamicPageId, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.AppendLine(string.Format("<div class=\"custom-widget custom-widget-{0} {1}\">\n{2}\n</div>", dr["CustomWidgetID"].ToString(), dr["CustomWidgetCSSSelectorClassName"].ToString(), dr["Content"].ToString()));
                    }
                }

                text = text.Replace(PortalConstants.DynamicNavigation.CUSTOM_WIDGET_GROUP_RIGHT, string.Format("<div class=\"custom-widget-group-right\">\n{0}\n</div>", sb.ToString()));
            }

            return text;
        }

        public string LoadLoginStatusMenu(string text)
        {
            #region No Menu
            if (text.Contains(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_NO_MENU))
            {
                // Logged in as Candidate
                if (SessionData.Member != null)
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_NO_MENU, 
                        string.Format(@"
<div class=""boardy-GroupStatus-noMenu boardy-GroupStatus-ForCandidate"">
<span class=""GroupStatus-profilepic""><img src=""//images.jxt.net.au/test-board-widget/images/propic.jpg"" width=""25"" height=""25"" alt=""Profile Photo"" /></span>
<span class=""GroupStatus-user"">{0}</span>
<span class=""GroupStatus-bar"">|</span>
<span class=""GroupStatus-dashboard""><a href=""/member/default.aspx"">{1}</a></span>
</div>
                        ", SessionData.Member.Username, CommonFunction.GetResourceValue("LabelDashboard"))
                         );
                }
                // Logged in as Advertiser
                else if (SessionData.AdvertiserUser != null)
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_NO_MENU,
                        string.Format(@"
<div class=""boardy-GroupStatus-noMenu boardy-GroupStatus-ForAdvertiser"">
<span class=""GroupStatus-profilepic""><img src=""//images.jxt.net.au/test-board-widget/images/propic.jpg"" width=""25"" height=""25"" alt=""Profile Photo"" /></span>
<span class=""GroupStatus-user"">{0}</span>
<span class=""GroupStatus-bar"">|</span>
<span class=""GroupStatus-dashboard""><a href=""/advertiser/default.aspx"">{1}</a></span>
</div>
                        ", SessionData.AdvertiserUser.Username, CommonFunction.GetResourceValue("LabelDashboard"))
                        );
                }
                // Not logged in
                else
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_NO_MENU,
                        string.Format(@"
<div class=""boardy-GroupStatus-noMenu boardy-GroupStatus-loginBefore"">
<span class=""GroupStatus-logInBefore""><a href=""#boardy-popbox"" name=""boardy-modal"" data-content=""<a href='/member/login.aspx' class='boardy-GroupStatus-btn'>{0}</a><a href='/advertiser/login.aspx' class='boardy-GroupStatus-btn'>{1}</a>"" data-title=""<h2>{2}</h2>"">{4}</a></span>
<span class=""GroupStatus-bar"">|</span>
<span class=""GroupStatus-registerBefore""><a href=""#boardy-popbox"" name=""boardy-modal"" data-content=""<a href='/member/register.aspx' class='boardy-GroupStatus-btn'>{0}</a><a href='/advertiser/register.aspx' class='boardy-GroupStatus-btn'>{1}</a>"" data-title=""<h2>{3}</h2>"">{5}</a></span>
</div>
                        "
                        , CommonFunction.GetResourceValue("LabelCandidate") // Format {0}
                        , CommonFunction.GetResourceValue("LabelAdvertiser") // Format {1}
                        , CommonFunction.GetResourceValue("LabelSelectUserLogin") // Format {2}
                        , CommonFunction.GetResourceValue("LabelSelectUserRegister") // Format {3}
                        , CommonFunction.GetResourceValue("LabelLogin") // Format {4}
                        , CommonFunction.GetResourceValue("LabelRegister") // Format {5}
                        )
                        
                        );
                }
            }
            #endregion

            #region With Menu
            if (text.Contains(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_WITH_MENU))
            {
                // Logged in as Member/Candidate
                if (SessionData.Member != null)
                {
                    bool displayDraftJobsMenu = false;

                    #region Set boolean flags
                    GlobalSettingsService GlobalSettingsService = new GlobalSettingsService();
                    JobApplicationTypeService JobApplicationTypeService = new JobApplicationTypeService();
                    using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (globalSetting.Count > 0)
                        {
                            if (globalSetting[0].JobApplicationTypeId.HasValue)
                            {
                                displayDraftJobsMenu = true;
                            }
                        }
                    }
                    #endregion

                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_WITH_MENU,
                        string.Format(@"
<div class=""boardy-GroupStatus-withMenu boardy-GroupStatus-ForCandidate"">
<span class=""GroupStatus-profilepic""><img src=""//images.jxt.net.au/test-board-widget/images/propic.jpg"" width=""25"" height=""25"" alt=""Profile Photo"" /></span>
<span class=""GroupStatus-dashboard""><a class=""boardy-dropdown-toggle"" href=""javascript:void(0)"" title=""DashBoard"" onclick=""BoardyDropDownToggle(this);"">{0} <b class=""boardy-caret""><!-- --></b></a>
<ul class=""boardy-dropdown"">
	<li id=""memberProfileHome""><a href=""/member/default.aspx"">{1}</a></li>
	<li id=""memberProfileDetails""><a href=""/member/settings.aspx"">{2}</a></li>
	<li id=""memberProfilePassword""><a href=""/member/changepassword.aspx"">{3}</a></li>
	<li id=""memberProfileCV""><a href=""/member/profile.aspx"">{4}</a></li>
	<li id=""memberProfileAlerts""><a href=""/member/myjobalerts.aspx"">{5}</a></li>
	<li id=""memberProfileSavedJobs""><a href=""/member/mysavedjobs.aspx"">{6}</a></li>
	<li id=""memberProfileApplication""><a href=""/member/applicationtracker.aspx"">{7}</a></li>
    {8}
	<li id=""memberProfileLogout""><a href=""/logout.aspx"">{9}</a></li>
</ul>
</span>
</div>
                        "
                        , !string.IsNullOrWhiteSpace(SessionData.Member.FirstName) ? SessionData.Member.FirstName : SessionData.Member.Username // Format {0}
                        , CommonFunction.GetResourceValue("LabelDashboard") // Format {1}
                        , CommonFunction.GetResourceValue("LinkButtonAccountDetails") // Format {2}
                        , CommonFunction.GetResourceValue("LabelMyPassword") // Format {3}
                        , CommonFunction.GetResourceValue("LabelProfile") // Format {4}
                        , CommonFunction.GetResourceValue("LabelFavouriteSearches") + " / " + CommonFunction.GetResourceValue("LabelMyJobAlerts") // Format {5}
                        , CommonFunction.GetResourceValue("LabelMySavedJobs") // Format {6}
                        , CommonFunction.GetResourceValue("LabelMyApplicationTracker") // Format {7}
                        , displayDraftJobsMenu ? string.Format(@"<li id=""memberDraftJobs""><a href=""/member/draftjobs.aspx"">{0}</a></li>", CommonFunction.GetResourceValue("LabelDraftJobs")) : string.Empty // Format {8}
                        , CommonFunction.GetResourceValue("LabelLogout") // Format {9}
                        
                        )
                     );
                }
                // Logged in as Advertiser
                else if (SessionData.AdvertiserUser != null)
                {
                    bool siteHasJobScreenProcess = false;
                    bool isPrimaryAccount = false; // Advertiser account primary user
                    bool showBuyCreditLink = false;
                    bool showCheckoutLink = false;
                    bool showPeoplSearchLink = false;
                    bool showScreeningQuestionsLink = false;

                    #region Set boolean flags

                    if (Entities.SessionData.AdvertiserUser.AdvertiserId > 0)
                    {
                        using (Entities.AdvertiserUsers advu = new AdvertiserUsersService().GetByAdvertiserUserId(Entities.SessionData.AdvertiserUser.AdvertiserUserId))
                        {
                            if (advu != null)
                            {
                                // Show pending jobs when job screening process is enabled
                                using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                                using (Entities.Advertisers thisAdvertiser = AdvertisersService.GetByAdvertiserId(advu.AdvertiserId))
                                {
                                    if (globalsettings.Count > 0)
                                    {
                                        Entities.GlobalSettings globalsetting = globalsettings[0];
                                        siteHasJobScreenProcess = (globalsetting.JobScreeningProcess.HasValue) ? globalsetting.JobScreeningProcess.Value : false;
                                        showPeoplSearchLink = globalsetting.EnablePeopleSearch && thisAdvertiser.AllowPeopleSearchAccess;
                                        showScreeningQuestionsLink = globalsetting.EnableScreeningQuestions;
                                    }
                                }
                            }
                        }
                    }

                    if (SessionData.AdvertiserUser.PrimaryAccount)
                    {
                        isPrimaryAccount = true;
                    }

                    if (SessionData.Site.IsJobBoard)
                    {
                        if (SessionData.AdvertiserUser != null)
                        {
                            if (SessionData.AdvertiserUser.AccountType == PortalEnums.Advertiser.AccountType.Credit_Card)
                                showBuyCreditLink = true;

                            if (SessionData.AdvertiserUser.CartItems != null && SessionData.AdvertiserUser.CartItems.Count() > 0)
                                showCheckoutLink = true;
                        }
                    }

                    #endregion

                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_WITH_MENU,
                        string.Format(@"
<div class=""boardy-GroupStatus-withMenu boardy-GroupStatus-ForAdvertiser"">
<span class=""GroupStatus-profilepic""><img src=""//images.jxt.net.au/test-board-widget/images/propic.jpg"" width=""25"" height=""25"" alt=""Profile Photo"" /></span>
<span class=""GroupStatus-dashboard""><a class=""boardy-dropdown-toggle"" href=""javascript:void(0)"" title=""DashBoard"" onclick=""BoardyDropDownToggle(this);"">{0} <b class=""boardy-caret""><!-- --></b></a>
<ul class=""boardy-dropdown"">
	<li id=""advertProfileHome""><a href=""/advertiser/default.aspx"">{1}</a></li>
    {17}
    {18}
	<li id=""advertProfilePost""><a href=""/advertiser/jobcreate.aspx"">{2}</a></li>
	<li id=""advertProfileCurrent""><a href=""/advertiser/jobscurrent.aspx"">{3}</a></li>
    {4}
    {5}
	<li id=""advertProfileDraft""><a href=""/advertiser/jobsdraft.aspx"">{6}</a></li>
	<li id=""advertProfileArchived""><a href=""/advertiser/jobsarchived.aspx"">{7}</a></li>
    <li class=""divider""></li>
	<li id=""advertProfileAccDetails""><a href=""/advertiser/edit.aspx"">{8}</a></li>
	{9}
	<li id=""advertProfileAccPassword""><a href=""/advertiser/edit.aspx?tab=2"">{10}</a></li>
    <li class=""divider""></li>
	<!--{11}-->
	<li id=""advertProfileTempLogoEdit2""><a href=""/advertiser/logoedit.aspx"">{12}</a></li>
	<li id=""advertProfileTempLogoEdit2""><a href=""/advertiser/advertiserjobtemplatelogo.aspx"">{13}</a></li>
    <li class=""divider""></li>
    {19}
	<li id=""advertProfileJobTracker""><a href=""/advertiser/jobtracker.aspx"">{14}</a></li>
	<li id=""advertProfileStats""><a href=""/advertiser/statistics.aspx"">{15}</a></li>
    <li class=""divider""></li>
    <li id=""advertProfileLogout""><a href=""/logout.aspx?advertiser=true"">{16}</a></li>
</ul>
</span>
</div>
                        "
                        , SessionData.AdvertiserUser.Username
                        , CommonFunction.GetResourceValue("LinkButtonManageJobs") // Format {1}
                        , CommonFunction.GetResourceValue("LinkButtonCreateNewJobAd") // Format {2}
                        , CommonFunction.GetResourceValue("LinkButtonCurrentJobAds") // Format {3}
                        , siteHasJobScreenProcess ? string.Format(@"<li id=""advertProfilePending""><a href=""/advertiser/jobspending.aspx"">{0}</a></li>", CommonFunction.GetResourceValue("LinkButtonPendingJobAds")) : string.Empty // Format {4}
                        , siteHasJobScreenProcess ? string.Format(@"<li id=""advertProfileDeclined""><a href=""/advertiser/jobsdeclined.aspx"">{0}</a></li>", CommonFunction.GetResourceValue("LinkButtonDeclinedJobAds")) : string.Empty // Format {5}
                        , CommonFunction.GetResourceValue("LinkButtonDraftJobAds") // Format {6}
                        , CommonFunction.GetResourceValue("LinkButtonArchivedJobAds") // Format {7}                        
                        , CommonFunction.GetResourceValue("LinkButtonAccountDetails") // Format {8}
                        , isPrimaryAccount ? string.Format(@"<li id=""advertProfileAccPassword""><a href=""/advertiser/edit.aspx?tab=1"">{0}</a></li>", CommonFunction.GetResourceValue("LinkButtonSubAccounts")) : string.Empty // Format {9}
                        , CommonFunction.GetResourceValue("LabelChangePwd") // Format {10}
                        , string.Empty //CommonFunction.GetResourceValue("LinkButtonViewChangeTemplateLogo") // Format {11}
                        , CommonFunction.GetResourceValue("LinkButtonViewChangeLogo") // Format {12}
                        , CommonFunction.GetResourceValue("LinkButtonViewChangeTemplateLogo") // Format {13}
                        , CommonFunction.GetResourceValue("LinkButtonJobTracker") // Format {14}
                        , CommonFunction.GetResourceValue("LinkButtonStatistics") // Format {15}                 
                        , CommonFunction.GetResourceValue("LabelLogout") // Format {16}                        
                        , showBuyCreditLink ? string.Format(@"<li id=""advertProfileBuyCred""><a href=""/advertiser/productselect.aspx"">{0}</a></li>", CommonFunction.GetResourceValue("LinkButtonBuyJobCredits")) : string.Empty //Format {17}
                        , showCheckoutLink ? string.Format(@"<li id=""advertProfileCheckout""><a href=""/advertiser/orderpayment.aspx"">{0} ({1})</a></li> ", CommonFunction.GetResourceValue("LinkButtonCart"), SessionData.AdvertiserUser.CartItems.Count()) : string.Empty//Format {18}
                        , showPeoplSearchLink? string.Format(@"<li id=""advertPeopleSearch""><a href=""/peoplesearch.aspx"">{0}</a></li> ", CommonFunction.GetResourceValue("LinkButtonPeopleSearch")) : string.Empty //Format {19}
                        , showScreeningQuestionsLink ? string.Format(@"<li id=""advertScreeningQuestions""><a href=""/advertiser/screeningquestionstemplates.aspx"">{0}</a></li> ", CommonFunction.GetResourceValue("LinkScreeningQuestionsTemplate")) : string.Empty //Format {19}
                        )
                    );
                }
                // Not logged in
                else
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.USER_LOGINSTATUS_WITH_MENU,
                        string.Format(@"
<div class=""boardy-GroupStatus-withMenu boardy-GroupStatus-loginBefore"">
<span class=""GroupStatus-logInBefore""><a href=""#boardy-popbox"" name=""boardy-modal"" data-content=""<a href='/member/login.aspx' class='boardy-GroupStatus-btn'>{0}</a><a href='/advertiser/login.aspx' class='boardy-GroupStatus-btn'>{1}</a>"" data-title=""<h2>{2}</h2>"">{4}</a></span>
<span class=""GroupStatus-bar"">|</span>
<span class=""GroupStatus-registerBefore""><a href=""#boardy-popbox"" name=""boardy-modal"" data-content=""<a href='/member/register.aspx' class='boardy-GroupStatus-btn'>{0}</a><a href='/advertiser/register.aspx' class='boardy-GroupStatus-btn'>{1}</a>"" data-title=""<h2>{3}</h2>"">{5}</a></span>
</div>

<!-- Boardy Popup -->
<div id=""boardy-popup"">

<div id=""boardy-popbox"" class=""window"">
<a href=""#"" class=""boardy-popclose""></a>

<div class=""boardy-styleBox"">

<div class=""boardy-poptitle""><!-- --></div>
<div class=""boardy-popcontent""><!-- --></div>
</div>
</div>


<!-- Mask to cover the whole screen -->
<div id=""boardy-popshadow""><!-- --></div>
</div>
                        "
                        , CommonFunction.GetResourceValue("LabelCandidate") // Format {0}
                        , CommonFunction.GetResourceValue("LabelAdvertiser") // Format {1}                        
                        , CommonFunction.GetResourceValue("LabelSelectUserLogin") // Format {2}
                        , CommonFunction.GetResourceValue("LabelSelectUserRegister") // Format {3}
                        , CommonFunction.GetResourceValue("LabelLogin") // Format {4}
                        , CommonFunction.GetResourceValue("LabelRegister") // Format {5}                        
                        )
                     );
                }
            }

            #endregion

            return text;
        }

        /// <summary>
        /// Load Member results counters for saved jobs, job applications and favourite searches
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string LoadMemberResultCounters(string text)
        {
            // Logged in as Candidate

            // Todo - in the future change the methods used to get count and not the list.

            // Counter for Member Saved jobs
            if (text.Contains(PortalConstants.DynamicNavigation.MEMBER_COUNTER_SAVED_JOBS))
            {
                if (SessionData.Member != null)
                {
                    JobsSavedService JobsSavedService = new JobsSavedService();
                    int totalCount = 0;
                    using (DataSet dsJobsSaved = JobsSavedService.GetJobNameByMemberID(SessionData.Member.MemberId, 1, 1))
                    {
                        if (dsJobsSaved.Tables[0].Rows.Count > 0)
                        {
                            totalCount = Convert.ToInt32(dsJobsSaved.Tables[0].Rows[0]["TotalCount"]);
                        }
                        else
                            totalCount = 0;
                    }

                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_SAVED_JOBS, string.Format(@"<span class='member-savedjobs-count'>{0}</span>", totalCount));
                }
                else
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_SAVED_JOBS, string.Empty);
            }

            // Counter for Member Job applications
            if (text.Contains(PortalConstants.DynamicNavigation.MEMBER_COUNTER_JOB_APPLICATIONS))
            {
                if (SessionData.Member != null)
                {
                    JobApplicationService JobApplicationService = new JobApplicationService();
                    int totalCount = 0;
                    using (DataSet dsJobApplication = JobApplicationService.GetJobsNameByMemberId(SessionData.Member.MemberId, 1, 1))
                    {
                        if (dsJobApplication.Tables[0].Rows.Count > 0)
                        {
                            totalCount = Convert.ToInt32(dsJobApplication.Tables[0].Rows[0]["TotalCount"]);
                        }
                        else
                            totalCount = 0;
                    }

                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_JOB_APPLICATIONS, string.Format(@"<span class='member-applicationtracker-count'>{0}</span>", totalCount));
                }
                else
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_JOB_APPLICATIONS, string.Empty);
            }

            // Counter for Member Favourite Searches
            if (text.Contains(PortalConstants.DynamicNavigation.MEMBER_COUNTER_FAVOURITE_SEARCHES))
            {
                if (SessionData.Member != null)
                {
                    JobAlertsService JobAlertsService = new JobAlertsService();
                    int totalCount = 0;
                    using (TList<JobAlerts> jobalertList = JobAlertsService.GetByMemberId(SessionData.Member.MemberId))
                    {
                        if (jobalertList.Count > 0)
                            totalCount = jobalertList.Where(s => s.AlertActive == false).Count();
                        else
                            totalCount = 0;
                    }

                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_FAVOURITE_SEARCHES, string.Format(@"<span class='member-favsearches-count'>{0}</span>", totalCount));
                }
                else
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_COUNTER_FAVOURITE_SEARCHES, string.Empty);
            }


            return text;
        }

        public string LoadMemberSignAndOutAndDashboard(string text)
        {
            if (text.Contains(PortalConstants.DynamicNavigation.MEMBER_SIGNIN_SIGNOUT))
            {
                if (SessionData.Member == null)
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_SIGNIN_SIGNOUT, "<a href='/member/login.aspx' class='user-loggedOut'>" + CommonFunction.GetResourceValue("LabelLogin") + "</a>");
                }
                else
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_SIGNIN_SIGNOUT, "<a href='/logout.aspx' class='user-loggedIn'>" + CommonFunction.GetResourceValue("LabelLogout") + "</a>");
                }
            }

            
            if (text.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD))
            {
                if (SessionData.Member == null)
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD, 
string.Format(@"<li id='memberStatusDashLogin'><a href='/member/login.aspx' class='member-status-login'>{0}</a></li>
<li id='memberStatusDashRegister'><a href='/member/register.aspx' class='member-status-register'>{1}</a></li>"
, CommonFunction.GetResourceValue("LabelLogin"), CommonFunction.GetResourceValue("LabelRegister")));
                }
                else
                {
                    text = text.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD, "<li id='memberStatusDashHome'><a href='/member/default.aspx' class='member-status-home'><img src='//images.jxt.net.au/user-icon-light.png' /> " + CommonFunction.GetResourceValue("LabelDashboard") + "</a></li>");
                }
            }

            return text;
        }

        private string LoadRelatedPages(String strNav)
        {
            string strtorepalce = string.Empty;
            Entities.DynamicPages dumppage = new Entities.DynamicPages();


            strtorepalce = string.Empty;

            string pagecode = CommonPage.PageName;
            if (!string.IsNullOrEmpty(pagecode) && strNav.Contains(PortalConstants.DynamicNavigation.RELATED_PAGES))
            {
                Entities.DynamicPages page = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, pagecode);
                if (page != null)
                {
                    DataSet ds = RelatedDynamicPagesService.CustomGetByDynamicPageID(page.DynamicPageId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<div id=\"related-links\">\n<ul>");

                        foreach (DataRow relatedpage in ds.Tables[0].Rows)
                        {
                            dumppage.CustomUrl = (relatedpage["CustomUrl"] == null) ? string.Empty : relatedpage["CustomUrl"].ToString();
                            dumppage.HyperLink = (relatedpage["HyperLink"] == null) ? string.Empty : relatedpage["HyperLink"].ToString();
                            dumppage.PageFriendlyName = (relatedpage["PageFriendlyName"] == null) ? string.Empty : relatedpage["PageFriendlyName"].ToString();
                            dumppage.OpenInNewWindow = Convert.ToBoolean(relatedpage["OpenInNewWindow"].ToString());
                            dumppage.PageTitle = (relatedpage["PageTitle"] == null) ? string.Empty : relatedpage["PageTitle"].ToString();

                            sb.AppendFormat("<li>{0}</li>", DynamicPagesService.GetDynamicPageLink(dumppage, string.Empty));
                        }

                        sb.Append("</ul>\n</div>");
                        strtorepalce = sb.ToString();
                    }
                }
            }


            strNav = strNav.Replace(PortalConstants.DynamicNavigation.RELATED_PAGES, strtorepalce);


            return strNav;
        }

        public void SetMetaContentWithFavIcon(Literal ltlMetaContent, Literal ltlDocType, System.Web.UI.Page page, String strPageTitle, 
                                                String strMetaDescription, String strMetaKeywords, Boolean blnHomepage, Boolean blnPage)
        {
            
            // Get Site Global Settings
            Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId);
            if (globalSettings != null)
            {
                String strFavIcon = String.Empty;
                String strMetaTags = String.Empty;

                if (!blnHomepage && !blnPage)
                {
                    // System Page Meta tags And Global Meta Tags
                    strMetaTags = String.Format("{0} {1}", globalSettings.MetaTags, globalSettings.SystemMetaTags);
                }
                else
                {
                    // Global Meta Tags
                    strMetaTags = globalSettings.MetaTags;
                }

                // Todo - change favicon to textbox in Global settings
                /*
                if (globalSettings.SiteFavIconId.HasValue)
                    strFavIcon = String.Format("<link rel='shortcut icon' href='/GetFile.aspx?id={0}'/>",
                                                    globalSettings.SiteFavIconId.Value);
                */

                // Doc Type of the Website
                if (ltlDocType != null)
                {
                    if (String.IsNullOrEmpty(globalSettings.SiteDocType) && String.IsNullOrEmpty(ltlDocType.Text))
                        ltlDocType.Text = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
                    else
                        ltlDocType.Text = globalSettings.SiteDocType;
                }



                // Get from Global Settings Keywords, Description and FavIcon - Check if Homepage
                if (blnHomepage)        // Only for homepage
                {
                    // Meta Keywords and Description
                    if (String.IsNullOrEmpty(strMetaDescription))
                        strMetaDescription = globalSettings.HomeDescription;
                    if (String.IsNullOrEmpty(strMetaKeywords))
                        strMetaKeywords = globalSettings.HomeKeywords;
                    
                    // If Global Setting Home title has value show - else show the default title
                    if (!String.IsNullOrEmpty(globalSettings.HomeTitle.Trim()))
                        page.Header.Title = globalSettings.HomeTitle;
                    else
                        page.Header.Title = globalSettings.PageTitlePrefix + " " + strPageTitle + " " + globalSettings.PageTitleSuffix;


                    ltlMetaContent.Text = String.Format(@"
<meta name=""description"" content=""{0}"">
<meta name=""keywords"" content=""{1}"">
<meta property=""og:title"" content=""{4}"" />
<meta property=""og:description"" content=""{0}"" />
{2}
{3}",
strMetaDescription,
strMetaKeywords,
strFavIcon,
strMetaTags,
page.Header.Title.Trim());
                    
                }
                else if (page.MasterPageFile.Contains("Job")) // All the Job Master Pages
                {
                    ltlMetaContent.Text = String.Format(@"
{0}
{1}
<meta name=""keywords"" content=""{2}"">",
        strFavIcon,
        strMetaTags,
        globalSettings.DefaultKeywords);

                }

                else
                {

                    strPageTitle = globalSettings.PageTitlePrefix + " " + strPageTitle + " " + globalSettings.PageTitleSuffix;

                    // Set ASPX meta titles
                    SetMetaForAspxPages(page, ref strPageTitle, ref strMetaDescription, ref strMetaKeywords);

                    // Meta Keywords and Description
                    if (String.IsNullOrEmpty(strMetaDescription))
                        strMetaDescription = globalSettings.DefaultDescription;
                    if (String.IsNullOrEmpty(strMetaKeywords))
                        strMetaKeywords = globalSettings.DefaultKeywords;

                    // Don't display the meta content for News
                    if (page.Request.Path.Contains("news.aspx"))
                    {
                        ltlMetaContent.Text = String.Format(@"
{0}
{1}",
        strFavIcon,
        strMetaTags);

                        page.Header.Title = "{0}";
                    }
                    else
                    {
                        //page.Header.Title = strPageTitle;

                        CommonPage.SetBrowserPageTitle(page, strPageTitle);

                        ltlMetaContent.Text = String.Format(@"

<meta name=""description"" content=""{0}"" />
<meta name=""keywords"" content=""{1}"" />

<meta property=""og:description"" content=""{0}"" />
{2}
{3}
",
        Utils.RemoveMetaSpecialCharacters(strMetaDescription, JXTPortal.Entities.SessionData.Language.LanguageId),
        Utils.RemoveMetaSpecialCharacters(strMetaKeywords, JXTPortal.Entities.SessionData.Language.LanguageId),
        strFavIcon,
        strMetaTags
        //, page.Header.Title.Contains("{0}") ? string.Empty : string.Format(@"<meta property=""og:title"" content=""{0}"" />", page.Header.Title.Trim()) // show only if it is dynamic page and not system page
        );
                    }

                }

            }
            else
                page.Header.Title = strPageTitle.Trim();


            // If the url of the site has .jxt1.com then block from google or spiders .. In the future we can add for SSL also.
            if (page.Request.Url.Host.Contains(ConfigurationManager.AppSettings[PortalConstants.WebConfigurationKeys.WEBSITEURLPOSTFIX]))
            {
                ltlMetaContent.Text = ltlMetaContent.Text + "<meta name='robots' content='noindex, nofollow' />";
            }
        }

        /// <summary>
        /// Set ASPX meta titles
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strPageTitle"></param>
        /// <param name="strMetaDescription"></param>
        /// <param name="strMetaKeywords"></param>
        public void SetMetaForAspxPages(System.Web.UI.Page page, ref String strPageTitle, ref String strMetaDescription, ref String strMetaKeywords)
        {
            string strAspxFileName = page.Request.FilePath.ToLower();
            string strSystemPageName = string.Empty;
            /*
1.	/errorpage.aspx - 
2.	/404.aspx
3.	/sitemap.aspx
4.	/advertiser/register.aspx
5.	/member/createjobalert.aspx
6.	/advertiser/login.aspx
7.	/member/login.aspx
8.	/news.aspx (as they are multiple pages – need to understand how the SEO meta tag will work – let me know when we all can discuss)
9.	Email a friend (as they are multiple pages – need to understand how the SEO meta tag will work – let me know when we all can discuss)
10.	/jobbrowse.aspx (as they are multiple pages – need to understand how the SEO meta tag will work – let me know when we all can discuss)
11.	Apply job (as they are multiple pages – need to understand how the SEO meta tag will work – let me know when we all can discuss)
12.	/advancedsearch.aspx (as they are multiple pages – need to understand how the SEO meta tag will work – let me know when we all can discuss)

             
             */
            if (strAspxFileName.Contains("/errorpage.aspx"))
                strSystemPageName = "SystemPage_ErrorPage";
            else if (strAspxFileName.Contains("/404.aspx"))
                strSystemPageName = "SystemPage_404";
            else if (strAspxFileName.Contains("/sitemap.aspx"))
                strSystemPageName = "SystemPage_SiteMap";
            else if (strAspxFileName.Contains("/advertiser/register.aspx"))
                strSystemPageName = "SystemPage_AdvertiserRegistration";
            else if (strAspxFileName.Contains("/advertiser/login.aspx"))
                strSystemPageName = "SystemPage_AdvertiserLogin";
            else if (strAspxFileName.Contains("/member/createjobalert.aspx"))
                strSystemPageName = "SystemPage_MemberCreateJobAlert";
            else if (strAspxFileName.Contains("/member/login.aspx"))
                strSystemPageName = "SystemPage_MemberLogin";

            #region temp

            /*
            switch (strAspxFileName)
            {

                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserHistoricalStatistics";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "systempage_advertiser_job_application_edit";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_NewsSearch";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_SiteMap";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_EmailFriend";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobsArchived";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobsCurrent";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_PublicProfile";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserStatistics";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserCurrentJobStats";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_CreateJob";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_Advertiser_Job_Tracker";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AllAdvertiserTypesApprovalProcess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserForgetpasswordSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_JobAlertSuccessful";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserDefaultWelcome";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "systempage_onlycreditcardautoapproved";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserAccountType";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberForgetPassword";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_CompanySearch";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_JobApplySuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_JobAlertUnsubscribeSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserForgetPassword";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_PeopleSearch";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserRegistration";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_JobBrowse";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberCreateJobAlert";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobCreate";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserLogin";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserLogoEdit";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberDefaultWelcome";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_News";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_EnquiryPages";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberForgetpasswordSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberLogin";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberJobAlert";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberRegister";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserEdit";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_CreateJob_Success";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "systempage_memberedit";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberValidationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberApplicationTracker";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberMySavedJobs";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobDraft";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserValidationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberApplicationTracker";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberMySavedJobs";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobDraft";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserValidationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserValidationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_ApplyJob";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserJobTemplateLogo";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserDefaultHome";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvanceSearch";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_MemberRegistrationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_AdvertiserRegistrationSuccess";
                    break;
                case "/errorpage.aspx":
                    strSystemPageName = "SystemPage_404";
                    break;

                default:
                    break;
            }*/
            #endregion

            if (!string.IsNullOrWhiteSpace(strSystemPageName))
            {
                JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, strSystemPageName, SessionData.Language.LanguageId);

                // If dynamic page is null or found and meta title is empty
                if (dynamicPage == null || (dynamicPage != null && string.IsNullOrWhiteSpace(dynamicPage.MetaTitle)))
                {
                    if (SessionData.Language.LanguageId != PortalConstants.DEFAULT_LANGUAGE_ID)
                        dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, strSystemPageName, PortalConstants.DEFAULT_LANGUAGE_ID);
                }

                if (dynamicPage == null || (dynamicPage != null && string.IsNullOrWhiteSpace(dynamicPage.MetaTitle)))
                {
                    dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), strSystemPageName, PortalConstants.DEFAULT_LANGUAGE_ID);
                }
                
                if (dynamicPage != null)
                {
                    if (!string.IsNullOrWhiteSpace(dynamicPage.MetaTitle))
                    {
                        if (!String.IsNullOrEmpty(strPageTitle))
                            strPageTitle = String.Format(strPageTitle, dynamicPage.MetaTitle);
                        else
                            strPageTitle = dynamicPage.MetaTitle;
                    }

                    if (!string.IsNullOrWhiteSpace(dynamicPage.MetaDescription))
                    {
                        strMetaDescription = dynamicPage.MetaDescription;
                    }

                    if (!string.IsNullOrWhiteSpace(dynamicPage.MetaKeywords))
                    {
                        strMetaKeywords = dynamicPage.MetaKeywords;
                    }
                }
            }
        }

        public string GetCurrentPageName()
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        }

        public string GetReturnURL()
        {
            string returnUrl = string.Empty;

            if (HttpContext.Current.Request.QueryString["ReturnURL"] != null
                    && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ReturnURL"]))
            {
                returnUrl = HttpContext.Current.Request.QueryString["ReturnURL"];
            }

            return returnUrl;
        }

        
        public void LoginCheck<T>(string urlReturn, T token)
        {
            if (token == null
                    && this.GetCurrentPageName().ToLower() != "login.aspx")
            {
                Response.Redirect(urlReturn + "?ReturnURL=" + Server.UrlEncode("~" + HttpContext.Current.Request.Url.PathAndQuery));
            }
            else if (token != null && token is AdminUsers)
            { 
                //ToDo: get the page name Fransiscus
            }
        }

        public void PrivateSiteCheck()
        {
            // Redirect to appropiate login page when this site is private
            if (SessionData.Site != null && SessionData.Site.IsPrivateSite)
            {
                if (Request.Path.ToLower().Contains("/login.aspx") == false                 // Ignore the login page (member / advertiser)
                        && !Request.Path.ToLower().Contains("errorpage.aspx")          // Ignore this page (member / advertiser)
                        && !Request.Path.ToLower().Contains("forgetpassword.aspx")          // Ignore this page (member / advertiser)
                        && !Request.Path.ToLower().Contains("confirmresetpassword.aspx"))   // Ignore this page (member / advertiser)
                {
                    if (SessionData.Member == null && Request.Path.ToLower().Contains("member/") && Request.Path.ToLower().Contains("register.aspx")) // They can't access Register page.
                        Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.RawUrl)); //SessionData.Site.PrivateRedirectUrl
                    
                    /*if (Request.Path.ToLower().Contains("advertiser/") && SessionData.AdvertiserUser == null)
                        Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));*/

                    if (SessionData.Member == null && SessionData.AdvertiserUser == null && !Request.Path.ToLower().Contains("advertiser/")) // When no one is logged in and the path is not advertiser
                        Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));

                    /*
                    if ( Request.Path.ToLower().Contains("advertiser/") && ((SessionData.AdvertiserUser == null
                                && !Request.Path.ToLower().Contains("forgetpassword.aspx")     // Ignore this page
                                && !Request.Path.ToLower().Contains("confirmresetpassword.aspx")     // Ignore this page
                        ) || SessionData.AdvertiserUser != null && Request.Path.ToLower().Contains("register.aspx")))  //  && !Request.Path.ToLower().Contains("register.aspx")
                        Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery)); //SessionData.Site.PrivateRedirectUrl
                    //Response.Redirect("~/Admin/login.aspx" + "?ReturnURL=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
                    */
                }
            }
        }

        public void SitesLiveCheck()
        {
            if (SessionData.Site != null && !SessionData.Site.IsLive && SessionData.AdminUser == null)
            {
                Response.Redirect("~/admin/login.aspx" + "?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            }
        }

        public Boolean DoLogin<T>(string userName, string password, ref T token)
        {
            bool valid = false;

            if (token is JXTPortal.Entities.AdminUsers)
            {
                AdminUsersService _adminUsersService = new AdminUsersService();
            }
            else if (token is JXTPortal.Entities.Members)
            {
                MembersService _membersService = new MembersService();
            }
            else if (token is JXTPortal.Entities.Advertisers)
            {
                AdvertisersService _advertiserService = new AdvertisersService();
            }

            return valid;
        }

       
    }
}
