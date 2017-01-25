using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;
using System.Text;
using System.Xml;
using JXTPortal.Entities.Models;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucSearchResults : System.Web.UI.UserControl
    {

        #region Declare variables

        public string strMemberJobIds = string.Empty;
        protected string sPrefix = string.Empty;
        private GlobalSettingsService _globalsettingsservice;
        
        #endregion

        #region Properties

        int _resultCount = 0;

        public int SearchResultCount
        {
            set
            {
                _resultCount = value;
                ltlResultCount.Text = value.ToString();
            }
            get
            {
                if (!String.IsNullOrEmpty(ltlResultCount.Text))
                    return int.Parse(ltlResultCount.Text);

                return _resultCount;
            }
        }

        public int? PagingCount
        {
            get
            {
                //Release RN71 - Hard code to 12 results displayed - Himmy
                return 12;
                //return CommonFunction.GetInt(ConfigurationManager.AppSettings["AdvancedSearchPaging"]);
            }
        }

        public int PageCount
        {
            get
            {
                if ((SearchResultCount % PagingCount.Value) == 0)
                    return (SearchResultCount / PagingCount.Value);

                return (SearchResultCount / PagingCount.Value) + 1;
            }
        }

        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }

        private AdvertisersService _advertisersservice;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private JobsService _jobsService = null;
        public JobsService JobsService
        {

            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
            }
        }
        private ViewJobSearchService _viewJobSearchService = null;

        public ViewJobSearchService ViewJobSearchService
        {

            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }

        private SiteProfessionService _siteprofessionService = null;

        public SiteProfessionService SiteProfessionService
        {

            get
            {
                if (_siteprofessionService == null)
                {
                    _siteprofessionService = new SiteProfessionService();
                }
                return _siteprofessionService;
            }
        }

        private SiteRolesService _siterolesService = null;

        public SiteRolesService SiteRolesService
        {

            get
            {
                if (_siterolesService == null)
                {
                    _siterolesService = new SiteRolesService();
                }
                return _siterolesService;
            }
        }


        private SiteSalaryTypeService _sitesalaryService = null;

        public SiteSalaryTypeService SiteSalaryService
        {

            get
            {
                if (_sitesalaryService == null)
                {
                    _sitesalaryService = new SiteSalaryTypeService();
                }
                return _sitesalaryService;
            }
        }

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                {
                    _globalsettingsservice = new GlobalSettingsService();
                }
                return _globalsettingsservice;
            }
        }
        public string CampaignName
        {
            get { return ViewState["CampaignName"] != null ? ViewState["CampaignName"].ToString() : string.Empty; }
            set { ViewState["CampaignName"] = value; }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            sPrefix = (HttpContext.Current.Request.IsLocal) ? "http://localhost:49188" : string.Empty;
            SetFormValues();
            ToggleGoogleMapFunctions();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //setting this after the child controls (including event handlers in childs) are done with what they need to do
            if (!SessionData.JobSearch.SalaryTypeID.HasValue)
            {
                if (ddlSorting.Items.FindByValue("SalaryHighToLow") != null)
                    ddlSorting.Items.FindByValue("SalaryHighToLow").Attributes.Add("Disabled", "Disabled");

                if (ddlSorting.Items.FindByValue("SalaryLowToHigh") != null)
                    ddlSorting.Items.FindByValue("SalaryLowToHigh").Attributes.Add("Disabled", "Disabled");

                if (ddlSorting.SelectedValue == "SalaryHighToLow" || ddlSorting.SelectedValue == "SalaryLowToHigh")
                {
                    ddlSorting.SelectedIndex = 0;
                    ltlSortSelected.Text = ddlSorting.SelectedItem.Text;
                }

            }
        }

        public void SetFormValues()
        {
            hypLinkRSSFeed.Text = CommonFunction.GetResourceValue("ButtonRSSFeed");

            // For Sorting
            if (!Page.IsPostBack)
            {
                ddlSorting.Items.Clear();
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortByRecentPosts"), ""));
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortByOldestPosts"), "Old"));
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortByAlphabeticalAZ"), "AZ"));
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortByAlphabeticalZA"), "ZA"));
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortBySalaryHighLow"), "SalaryHighToLow"));
                ddlSorting.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortBySalaryLowHigh"), "SalaryLowToHigh"));
            }

            if (ddlSorting.SelectedItem != null)
                ltlSortSelected.Text = ddlSorting.SelectedItem.Text;

            phNotLoggedInJS.Visible = (SessionData.Member == null); // show the javascript that overwrite the href of fav search & create job alert button
        }


        #endregion

        #region Click Event handlers


        #endregion

        #region Methods

        public void DoSearch()
        {

            if (!Page.IsPostBack)
            {

                if (!String.IsNullOrEmpty(Request.QueryString["campaign"]))
                {
                    // Change the language which comes from session.
                    DynamicPagesService DynamicPagesService = new JXTPortal.DynamicPagesService();

                    using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, Request.QueryString["campaign"]))
                    {
                        if (dynamicPage != null && dynamicPage.Valid)
                        {
                            CampaignName = dynamicPage.PageTitle;   // Page title has the campaign keywords
                            ltlCampaign.Text = String.Format("<div class='jxt-mini-campaign'>{0}</div>", dynamicPage.PageContent);
                        }
                    }

                }
            }

            string kw = string.Empty;

            // Check the keywords or if there is a campaign
            EasyFts fts = new EasyFts();
            if (!String.IsNullOrEmpty(CampaignName))
                kw = fts.ToFtsQuery(CampaignName);
            if (!String.IsNullOrEmpty(SessionData.JobSearch.Keywords))
                kw = fts.ToFtsQuery(SessionData.JobSearch.Keywords);

            // Get the member saved job ids
            JobsSavedService JobsSavedService = new JobsSavedService();
            strMemberJobIds = JobsSavedService.GetMemberSavedJobs();

            // PREMIUM JOBS - Only first page, Don't display when keywords are entered, Only when there is a profession.
            if (SessionData.JobSearch.PageIndex == 0 && string.IsNullOrWhiteSpace(kw) && Common.Utils.IsValidInt(SessionData.JobSearch.ProfessionID))
            {
                JobItemsTypeService JobItemsTypeService = new JXTPortal.JobItemsTypeService();
                using (TList<GlobalSettings> globalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (globalSettings.Count > 0)
                    {

                        // Premium jobs if is Premium type is enabled.
                        List<Entities.JobItemsType> jobitemstypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId)
                                                                                        .Where(c => c.Valid && c.JobItemTypeParentId == (int)PortalEnums.Jobs.JobItemType.Premium).ToList();

                        if (jobitemstypes.Count > 0)
                        {

                            using (VList<ViewJobSearch> viewPremiumJobSearch = ViewJobSearchService.GetPremiumSearchFilter(
                                                                SessionData.Site.SiteId,
                                                                Convert.ToInt32(SessionData.JobSearch.ProfessionID),
                                                                SessionData.JobSearch.RoleIDs,
                                                                "Random",
                                                                globalSettings[0].NumberOfPremiumJobs))
                            {
                                ViewJobSearchService.SetJobLanguage(viewPremiumJobSearch, SessionData.Site.DefaultLanguageId, SessionData.Language.LanguageId);

                                rptPremiumJobResults.DataSource = viewPremiumJobSearch;
                                rptPremiumJobResults.DataBind();
                            }
                        }
                    }
                }
            }

            // STANDARD / STAND OUT JOBS
            using (VList<ViewJobSearch> viewJobSearch = ViewJobSearchService.GetBySearchFilter(
                                                    kw,
                                                    SessionData.Site.SiteId, SessionData.JobSearch.AdvertiserID,
                                                    SessionData.JobSearch.CurrencyID, SessionData.JobSearch.SalaryLowerBand, SessionData.JobSearch.SalaryUpperBand,
                                                    SessionData.JobSearch.SalaryTypeID, SessionData.JobSearch.WorkTypeID,
                                                    !string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID) ? Convert.ToInt32(SessionData.JobSearch.ProfessionID) : (int?)null,
                                                    SessionData.JobSearch.RoleIDs,
                                                    SessionData.JobSearch.CountryID,
                                                    !string.IsNullOrWhiteSpace(SessionData.JobSearch.LocationID) ? Convert.ToInt32(SessionData.JobSearch.LocationID) : (int?)null, 
                                                    SessionData.JobSearch.AreaIDs,
                                                    SessionData.JobSearch.DateFrom,
                                                    SessionData.Language.LanguageId,
                                                    SessionData.JobSearch.PageIndex, PagingCount, ddlSorting.SelectedValue, null))
            {
                ViewJobSearchService.SetJobLanguage(viewJobSearch, SessionData.Site.DefaultLanguageId, SessionData.Language.LanguageId);

                rptJobResults.DataSource = viewJobSearch;
                rptJobResults.DataBind();
            }

            SetRSSFeed();

            SetPaging();
        }

        protected void SetRSSFeed()
        {
            hypLinkRSSFeed.NavigateUrl = JobsService.GetRSSFeedUrl(null, null, null, null, null);
            hypLinkRSSFeed.Target = "_blank";
        }

        protected void SetPaging()
        {
            if (PageCount > 1)
            {
                List<PagingClass> pagingClassList = new List<PagingClass>();
                PagingClass pagingClass = null;
                int intPageStart = 1;
                int intPageEnd = 1;

                if (SessionData.JobSearch.PageIndex <= 4)
                {
                    intPageStart = 1;
                }
                else
                {
                    if (PageCount <= 10)
                    {
                        intPageStart = 1;
                    }
                    else
                    {
                        intPageStart = SessionData.JobSearch.PageIndex - 3;
                    }
                }

                if ((intPageStart + 8) >= PageCount)
                {
                    intPageEnd = PageCount;
                    intPageStart = intPageEnd - 9;
                    if (intPageStart < 1)
                    {
                        intPageStart = 1;
                    }
                }
                else
                {
                    intPageEnd = intPageStart + 9;
                }

                for (int i = intPageStart; i <= intPageEnd; i++)
                {
                    pagingClass = new PagingClass();
                    pagingClass.PageNo = i.ToString();
                    if (SessionData.JobSearch.PageIndex == i - 1)
                        pagingClass.Enabled = false;
                    else
                        pagingClass.Enabled = true;

                    pagingClassList.Add(pagingClass);
                }

                rptPaging.DataSource = pagingClassList;
                rptPaging.DataBind();

                // Show Paging
                rptPaging.Visible = true;
            }
            else
                rptPaging.Visible = false;
        }

        private string GetBreadCrumbNavigation(int professionId, int roleId)
        {
            string profString = string.Empty;
            string roleString = string.Empty;

            using(Entities.SiteProfession profession = SiteProfessionService.GetTranslatedProfessionById(professionId, SessionData.Site.UseCustomProfessionRole))
            using (Entities.SiteRoles role = SiteRolesService.GetTranslatedRolesById(roleId, professionId, SessionData.Site.UseCustomProfessionRole))
            {
                profString = profession != null ? profession.SiteProfessionName : string.Empty;
                roleString = role != null ? role.SiteRoleName : string.Empty;
            }
            return string.Format("<a href=\"/advancedsearch.aspx?search=1&professionid={0}\">{1}</a> &gt; <a href=\"/advancedsearch.aspx?search=1&professionid={0}&roleIDs={2}\">{3}</a>", professionId, HttpUtility.HtmlEncode(profString), roleId, HttpUtility.HtmlEncode(roleString));
        }

        private void ToggleGoogleMapFunctions()
        {
            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if (integrations.GoogleMap != null && integrations.GoogleMap.Valid)
            {
                phMapSwitchOptions.Visible = true;
                phMapResultsMap.Visible = true;
            }

        }

        #endregion

        #region Premium Job Search Repeater

        protected void rptPremiumJobResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ViewJobSearch viewJobSearch = e.Item.DataItem as ViewJobSearch;
                Literal ltlJob = e.Item.FindControl("ltlJob") as Literal;
                String strItem = string.Empty;

                // Description or Bulletpoints
                string strJobDescription = string.Empty;
                if ((!string.IsNullOrEmpty(viewJobSearch.BulletPoint1) && viewJobSearch.BulletPoint1.Trim().Length > 0) ||
                        (!string.IsNullOrEmpty(viewJobSearch.BulletPoint2) && viewJobSearch.BulletPoint2.Trim().Length > 0) ||
                        (!string.IsNullOrEmpty(viewJobSearch.BulletPoint3) && viewJobSearch.BulletPoint3.Trim().Length > 0))
                    if ((string.IsNullOrEmpty(viewJobSearch.BulletPoint3)) && (string.IsNullOrEmpty(viewJobSearch.BulletPoint2)))
                        strJobDescription = String.Format(@"<ul><li>{0}</li></ul>",
                                                viewJobSearch.BulletPoint1);
                    else if (string.IsNullOrEmpty(viewJobSearch.BulletPoint3))
                        strJobDescription = String.Format(@"<ul><li>{0}</li><li>{1}</li></ul>",
                                                viewJobSearch.BulletPoint1,
                                                viewJobSearch.BulletPoint2);
                    else
                        strJobDescription = String.Format(@"<ul><li>{0}</li><li>{1}</li><li>{2}</li></ul>",
                                                    viewJobSearch.BulletPoint1,
                                                    viewJobSearch.BulletPoint2,
                                                    viewJobSearch.BulletPoint3);
                else
                {
                    strJobDescription = Utils.StripHTML(viewJobSearch.Description);

                    if (strJobDescription.Length > 150)
                    {
                        strJobDescription = (new System.Text.StringBuilder(strJobDescription, 0, 150, 150)).ToString() + "...";
                    }
                }


                // Advertiser Job Template Logo
                string strAdvertiserLogo = string.Empty;

                // Todo - The hyperlink is hardcoded to job but it should be for advertiser
                if (viewJobSearch.AdvertiserId.HasValue && viewJobSearch.HasAdvertiserLogo > 0) //AdvertiserJobTemplateLogoId
                {
                    strAdvertiserLogo = buildImageURL(Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName), Convert.ToString(viewJobSearch.AdvertiserId.Value), Convert.ToString(viewJobSearch.DatePosted.ToEpocTimestamp()), viewJobSearch.CompanyName);
                }


                //<a id='aSaveJob{9}' href='javascript:void(0);' onclick='return SaveJob(""aSaveJob{9}"",{9});'>save job</a>
                //onmouseover='MouseMover_row(this)' onmouseout='MouseOut_row(this)'
                ltlJob.Text = String.Format(@"
<div class='job-holder jxt-premium-job'>
    <div class='job-toplink'>
        <a href='{8}'>{0}</a>
        <div class='nameofcompany'>{1}</div>
    </div>
    <div class='job-rightlinks'>
        <a class='search-result-save-job-link{14} aSaveJob{9}' {15} href='/member/mysavedjobs.aspx?id={9}'>{12}</a> <span class='search-result-links-separator'>|</span> <a class='search-result-send-email-link' href='{11}'>{13}</a>
        <br />
        <span class='dateText'>{2}</span>
    </div>
    <div class='description-holder'>
        <!--<div class='job-checkbox'><input name='chkSaveJob' id='chkSaveJob' type='checkbox' value='{9}' /></div>-->
        <div class='locandsalary'>
            <span class='jxt-result-loc'>{3}</span>
            <span class='jxt-result-area'>{16}</span>
            <span class='jxt-result-salary'>{4}</span>
            <span class='jxt-result-worktype'>{5}</span>
            <span class='jxt-result-publictransport hidden'>{17}</span>
        </div>
        <div class='description-text'>{6}</div>
        <div class='description-logo'>{7}</div>
    </div>
    <!-- end of description holder -->
    <div class='job-breadcrumbs'>{10}</div>
</div>
<!-- end of job holder-->
", viewJobSearch.JobName,
 viewJobSearch.CompanyName,
 viewJobSearch.DatePosted.ToString(SessionData.Site.DateFormat),
 viewJobSearch.LocationName,
 (viewJobSearch.ShowSalaryRange) ? string.Format("{0}{1} - {0}{2:#,###} {3}",
 viewJobSearch.CurrencySymbol,
 (viewJobSearch.SalaryLowerBand == 0) ? "0" : viewJobSearch.SalaryLowerBand.ToString("#,###"),
 viewJobSearch.SalaryUpperBand, SiteSalaryService.Get_TranslatedSalaryType(SessionData.Site.SiteId, viewJobSearch.SalaryTypeId).SalaryTypeName) : SiteSalaryService.Get_TranslatedSalaryType(SessionData.Site.SiteId, viewJobSearch.SalaryTypeId).SalaryTypeName,
 viewJobSearch.WorkTypeName,
 strJobDescription,
 strAdvertiserLogo,
 Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
 viewJobSearch.JobId,
 GetBreadCrumbNavigation(viewJobSearch.ProfessionId, viewJobSearch.RoleId),
 Utils.GetEmailFriendUrl(viewJobSearch.JobFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0], viewJobSearch.JobId),
 IsMemberSavedJob(viewJobSearch.JobId) ? CommonFunction.GetResourceValue("LabelJobSaved") : CommonFunction.GetResourceValue("LinkButtonSaveJob"),
 CommonFunction.GetResourceValue("LinkButtonSendEmail"),
 IsMemberSavedJob(viewJobSearch.JobId) ? " job-saved" : string.Empty,
 SessionData.Member != null && SessionData.Member.MemberId > 0 ? string.Format(" onclick=\"return SaveJob(this, 'aSaveJob{0}',{0});\" ", viewJobSearch.JobId) : string.Empty,
 viewJobSearch.AreaName,
 viewJobSearch.PublicTransport
 );


                // ToDO - Need breadcrumbs - Profession name, Role Name with Links

            }
        }

        #endregion


        public string buildImageURL(string jobURL, string advertiserID, string timestamp, string companyName )
        {
            var imageUrl = string.Format("<img src='/getfile.aspx?advertiserid={0}&ver={1}' alt='{2}' />", advertiserID, timestamp,companyName);

            var assetUrl = string.Format("<a href='{0}'>{1}</a>", jobURL,imageUrl);

            return assetUrl;
        }

        #region Job Search Repeater

        protected void rptJobResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ViewJobSearch viewJobSearch = e.Item.DataItem as ViewJobSearch;
                Literal ltlJob = e.Item.FindControl("ltlJob") as Literal;
                String strItem = string.Empty;

                // Description or Bulletpoints
                string strJobDescription = string.Empty;
                if ((!string.IsNullOrEmpty(viewJobSearch.BulletPoint1) && viewJobSearch.BulletPoint1.Trim().Length > 0) ||
                        (!string.IsNullOrEmpty(viewJobSearch.BulletPoint2) && viewJobSearch.BulletPoint2.Trim().Length > 0) ||
                        (!string.IsNullOrEmpty(viewJobSearch.BulletPoint3) && viewJobSearch.BulletPoint3.Trim().Length > 0))
                    if ((string.IsNullOrEmpty(viewJobSearch.BulletPoint3)) && (string.IsNullOrEmpty(viewJobSearch.BulletPoint2)))
                        strJobDescription = String.Format(@"<ul><li>{0}</li></ul>",
                                                viewJobSearch.BulletPoint1);
                    else if (string.IsNullOrEmpty(viewJobSearch.BulletPoint3))
                        strJobDescription = String.Format(@"<ul><li>{0}</li><li>{1}</li></ul>",
                                                viewJobSearch.BulletPoint1,
                                                viewJobSearch.BulletPoint2);
                    else
                        strJobDescription = String.Format(@"<ul><li>{0}</li><li>{1}</li><li>{2}</li></ul>",
                                                    viewJobSearch.BulletPoint1,
                                                    viewJobSearch.BulletPoint2,
                                                    viewJobSearch.BulletPoint3);
                else
                {
                    strJobDescription = Utils.StripHTML(viewJobSearch.Description);

                    if (strJobDescription.Length > 150)
                    {
                        strJobDescription = (new System.Text.StringBuilder(strJobDescription, 0, 150, 150)).ToString() + "...";
                    }
                }


                // Advertiser Job Template Logo
                string strAdvertiserLogo = string.Empty;

                // Todo - The hyperlink is hardcoded to job but it should be for advertiser
                if (viewJobSearch.AdvertiserId.HasValue && viewJobSearch.HasAdvertiserLogo > 0) //AdvertiserJobTemplateLogoId
                {
                    strAdvertiserLogo = buildImageURL(Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName), Convert.ToString(viewJobSearch.AdvertiserId.Value), Convert.ToString(viewJobSearch.DatePosted.ToEpocTimestamp()), viewJobSearch.CompanyName);
                                
                }

                //<a id='aSaveJob{9}' href='javascript:void(0);' onclick='return SaveJob(""aSaveJob{9}"",{9});'>save job</a>
                // onmouseover='MouseMover_row(this)' onmouseout='MouseOut_row(this)'
                ltlJob.Text = String.Format(@"
<div class='job-holder{16}'>
    <div class='job-toplink'>
        <a href='{8}'>{0}</a>
        <div class='nameofcompany'>{1}</div>
    </div>
    <div class='job-rightlinks'>
        <a class='search-result-save-job-link{14} aSaveJob{9}' {15} href='/member/mysavedjobs.aspx?id={9}'>{12}</a> <span class='search-result-links-separator'>|</span> <a class='search-result-send-email-link' href='{11}'>{13}</a>
        <br />
        <span class='dateText'>{2}</span>
    </div>
    <div class='description-holder'>
        <!--<div class='job-checkbox'><input name='chkSaveJob' id='chkSaveJob' type='checkbox' value='{9}' /></div>-->
        <div class='locandsalary'>
            <span class='jxt-result-loc'>{3}</span>
            <span class='jxt-result-area'>{17}</span>
            <span class='jxt-result-salary'>{4}</span>
            <span class='jxt-result-worktype'>{5}</span>
            <span class='jxt-result-publictransport hidden'>{18}</span>
        </div>
        <div class='description-text'>{6}</div>
        <div class='description-logo'>{7}</div>
    </div>
    <!-- end of description holder -->
    <div class='job-breadcrumbs'>{10}</div>
</div>
<!-- end of job holder-->
", viewJobSearch.JobName,
 viewJobSearch.CompanyName,
 viewJobSearch.DatePosted.ToString(SessionData.Site.DateFormat), 
 viewJobSearch.LocationName, 
 (viewJobSearch.ShowSalaryRange) ? string.Format("{0}{1} - {0}{2:#,###} {3}",  
 viewJobSearch.CurrencySymbol,  
 (viewJobSearch.SalaryLowerBand == 0) ? "0" : viewJobSearch.SalaryLowerBand.ToString("#,###"),
 viewJobSearch.SalaryUpperBand, SiteSalaryService.Get_TranslatedSalaryType(SessionData.Site.SiteId, viewJobSearch.SalaryTypeId).SalaryTypeName) : SiteSalaryService.Get_TranslatedSalaryType(SessionData.Site.SiteId, viewJobSearch.SalaryTypeId).SalaryTypeName,
 viewJobSearch.WorkTypeName, 
 strJobDescription,
 strAdvertiserLogo, 
 Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
 viewJobSearch.JobId, 
 GetBreadCrumbNavigation(viewJobSearch.ProfessionId, viewJobSearch.RoleId), 
 Utils.GetEmailFriendUrl(viewJobSearch.JobFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0], viewJobSearch.JobId),
 IsMemberSavedJob(viewJobSearch.JobId) ? CommonFunction.GetResourceValue("LabelJobSaved") : CommonFunction.GetResourceValue("LinkButtonSaveJob"), 
 CommonFunction.GetResourceValue("LinkButtonSendEmail"),
 IsMemberSavedJob(viewJobSearch.JobId) ? " job-saved" : string.Empty,
 SessionData.Member != null && SessionData.Member.MemberId > 0 ? string.Format(" onclick=\"return SaveJob(this, 'aSaveJob{0}',{0});\" ", viewJobSearch.JobId) : string.Empty,
 (viewJobSearch.SiteId == SessionData.Site.SiteId && viewJobSearch.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.StandOut ? " jxt-standout-job" : string.Empty),  // Show as Standout only on the created site.
 viewJobSearch.AreaName,
 viewJobSearch.PublicTransport
 );


                // ToDO - Need breadcrumbs - Profession name, Role Name with Links

            }
        }
        
        #endregion

        #region Paging Repeater Databound

        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                LinkButton lnkButtonPaging = (LinkButton)e.Item.FindControl("lnkButtonPaging");

                lnkButtonPaging.CommandArgument = (Convert.ToInt32(pagingClass.PageNo) - 1).ToString();
                lnkButtonPaging.Text = pagingClass.PageNo.ToString();

                if (!pagingClass.Enabled)
                {
                    lnkButtonPaging.CssClass = "disabled_tnt_pagination active";
                    //lnkButtonPaging.Enabled = false;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                LinkButton lnkButtonPrevious = (LinkButton)e.Item.FindControl("lnkButtonPrevious");
                LinkButton lbFirst = (LinkButton)e.Item.FindControl("lbFirst");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                lnkButtonPrevious.CssClass = "search-previous-button";
                if (SessionData.JobSearch.PageIndex <= 0)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination search-previous-button";
                    //lnkButtonPrevious.Enabled = false;
                    //lbFirst.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.CommandArgument = (SessionData.JobSearch.PageIndex - 1).ToString();
                }

                lbFirst.Text = "&lt;&lt;";
                lbFirst.CommandArgument = "0";

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                LinkButton lnkButtonNext = (LinkButton)e.Item.FindControl("lnkButtonNext");
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                LinkButton lbLast = (LinkButton)e.Item.FindControl("lbLast");

                lnkButtonNext.CssClass = "search-next-button";
                if (SessionData.JobSearch.PageIndex >= PageCount - 1)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination search-next-button";
                    //lnkButtonNext.Enabled = false;
                    //lbLast.Enabled = false;
                }
                else
                {
                    lnkButtonNext.CommandArgument = (SessionData.JobSearch.PageIndex + 1).ToString();
                }

                lbLast.CommandArgument = (PageCount - 1).ToString();
                lbLast.Text = "&gt;&gt;";
            }
        }

        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("paging"))
            {
                SessionData.JobSearch.PageIndex = Convert.ToInt32(e.CommandArgument.ToString());

                // Search again
                DoSearch();
            }

        }

        #endregion

        #region Paging Class

        private class PagingClass
        {
            public string PageNo { get; set; }
            public string PageUrl { get; set; }
            public bool Enabled { get; set; }
        }

        #endregion


        #region Member Saved Job method

        /// <summary>
        /// Check if the member has saved the live job.
        /// </summary>
        /// <param name="savedJobId"></param>
        /// <returns></returns>
        public bool IsMemberSavedJob(int savedJobId)
        {
            if (!string.IsNullOrWhiteSpace(strMemberJobIds))
                return strMemberJobIds.Contains(string.Format(" {0} ", savedJobId.ToString()));

            return false;
        }
        
        #endregion

        #region Sorting

        protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltlSortSelected.Text = ddlSorting.SelectedItem.Text;

            if (!SessionData.JobSearch.SalaryTypeID.HasValue)
            {
                ddlSorting.Items.FindByValue("SalaryHighToLow").Attributes.Add("Disabled", "Disabled");
                ddlSorting.Items.FindByValue("SalaryLowToHigh").Attributes.Add("Disabled", "Disabled");
            }

            DoSearch();
        }

        #endregion
    }
}