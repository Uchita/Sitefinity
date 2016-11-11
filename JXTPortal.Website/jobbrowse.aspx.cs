using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    public partial class jobbrowse : DefaultBase
    {
        #region Declaration

        public string strMemberJobIds = string.Empty;

        int _resultCount = 0;
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
        public int SearchResultCount
        {
            set
            {
                _resultCount = value;
                ltResultNo.Text = value.ToString();
            }
            get
            {
                if (!String.IsNullOrEmpty(ltResultNo.Text))
                    return int.Parse(ltResultNo.Text);

                return _resultCount;
            }
        }

        public int? PagingCount
        {
            get
            {
                return CommonFunction.GetInt(ConfigurationManager.AppSettings["AdvancedSearchPaging"]);
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

        private string SiteProfession
        {
            get
            {
                string _siteprofession = string.Empty;
                _siteprofession = Request.QueryString["SiteProfession"];
                return _siteprofession;
            }
        }

        private string SiteRole
        {
            get
            {
                string _siterole = string.Empty;
                _siterole = Request.QueryString["SiteRole"];
                return _siterole;
            }
        }

        private string SiteCountry
        {
            get
            {
                string _sitecountry = string.Empty;
                _sitecountry = Request.QueryString["SiteCountry"];
                return _sitecountry;
            }
        }

        private string SiteLocation
        {
            get
            {
                string _sitelocation = string.Empty;
                _sitelocation = Request.QueryString["SiteLocation"];
                return _sitelocation;
            }
        }

        private string SiteWorkType
        {
            get
            {
                string _siteworktype = string.Empty;
                _siteworktype = Request.QueryString["SiteWorkType"];
                return _siteworktype;
            }
        }

        private int PageNo
        {
            get
            {
                int _pageno = 1;
                Int32.TryParse(Request.QueryString["PageNo"], out _pageno);
                if (_pageno == 0)
                    _pageno = 1;
                return _pageno;
            }
        }

        private SiteLocationService _sitelocationservice;
        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
            }
        }

        private SiteCountriesService _sitecountriesservice;
        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                {
                    _sitecountriesservice = new SiteCountriesService();
                }
                return _sitecountriesservice;
            }
        }

        private SiteProfessionService _siteprofessionservice;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                {
                    _siteprofessionservice = new SiteProfessionService();
                }
                return _siteprofessionservice;
            }
        }

        private SiteRolesService _siterolesservice;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesservice == null)
                {
                    _siterolesservice = new SiteRolesService();
                }
                return _siterolesservice;
            }
        }

        private SiteWorkTypeService _siteworktypeservice;
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeservice == null)
                {
                    _siteworktypeservice = new SiteWorkTypeService();
                }
                return _siteworktypeservice;
            }
        }

        private SiteLanguagesService _sitelanguagesservice;
        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }

        #endregion

        #region Page
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Job Browse");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!SessionData.Language.LanguageName.Contains("English"))
            {
                Response.Redirect("/Default.aspx");
            }
            */

            SetBreadCrumbs();
            DoSearch();
        }

        #endregion

        #region Methods

        private void SetBreadCrumbs()
        {
            string curl = string.Empty;
            string lurl = string.Empty;
            string wurl = string.Empty;
            string purl = string.Empty;
            string rurl = string.Empty;

            if (!string.IsNullOrEmpty(SiteCountry))
            {
                DataSet ds = SiteCountriesService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteCountry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    curl = string.Format(" &gt; <a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(string.Empty, string.Empty, SiteCountry, string.Empty, string.Empty, 1), ds.Tables[0].Rows[0]["SiteCountryName"], string.Format("Browse {0} Jobs", ds.Tables[0].Rows[0]["SiteCountryName"]));
                }
            }

            if (!string.IsNullOrEmpty(SiteLocation))
            {
                TList<Entities.SiteLocation> sl = SiteLocationService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteLocation);
                if (sl.Count > 0)
                {
                    lurl = string.Format(" &gt; <a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(string.Empty, string.Empty, SiteCountry, SiteLocation, string.Empty, 1), sl[0].SiteLocationName, string.Format("Browse {0} Jobs", sl[0].SiteLocationName));
                }
            }

            if (!string.IsNullOrEmpty(SiteWorkType))
            {
                TList<Entities.SiteWorkType> sw = SiteWorkTypeService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteWorkType);
                if (sw.Count > 0)
                {
                    wurl = string.Format(" &gt; <a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(string.Empty, string.Empty, SiteCountry, SiteLocation, SiteWorkType, 1), sw[0].SiteWorkTypeName, string.Format("Browse {0} Jobs", sw[0].SiteWorkTypeName));
                }
            }

            if (!string.IsNullOrEmpty(SiteProfession))
            {
                DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteProfession);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    purl = string.Format(" &gt; <a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, string.Empty, SiteCountry, SiteLocation, SiteWorkType, 1), ds.Tables[0].Rows[0]["SiteProfessionName"], string.Format("Browse {0} Jobs", ds.Tables[0].Rows[0]["SiteProfessionName"]));
                }
            }

            if (!string.IsNullOrEmpty(SiteRole))
            {
                TList<Entities.SiteRoles> sr = SiteRolesService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteRole);
                if (sr.Count > 0)
                {
                    rurl = string.Format(" &gt; <a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry, SiteLocation, SiteWorkType, 1), sr[0].SiteRoleName, string.Format("Browse {0} Jobs", sr[0].SiteRoleName));
                }
            }

            litBreadCrumb.Text = string.Format("{0}{1}{2}{3}{4}", curl, lurl, wurl, purl, rurl);

            litBreadCrumb.Text = "<a href='/jobbrowse.aspx'>Jobs</a>" + litBreadCrumb.Text;

        }

        public void DoSearch()
        {
            int? professionid = null;
            int? roleid = null;
            int? countryid = null;
            int? locationid = null;
            int? worktypeid = null;
            int pageno = 0;

            if (!string.IsNullOrEmpty(SiteProfession))
            {
                DataSet dsp = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteProfession);
                if (dsp.Tables[0].Rows.Count > 0)
                {
                    professionid = Convert.ToInt32(dsp.Tables[0].Rows[0]["ProfessionID"]);
                }
            }

            if (!string.IsNullOrEmpty(SiteRole))
            {
                TList<Entities.SiteRoles> sr = SiteRolesService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteRole);
                if (sr.Count > 0)
                {
                    roleid = sr[0].RoleId;
                }
            }

            if (!string.IsNullOrEmpty(SiteCountry))
            {
                DataSet dsc = SiteCountriesService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteCountry);
                if (dsc.Tables[0].Rows.Count > 0)
                {
                    countryid = Convert.ToInt32(dsc.Tables[0].Rows[0]["CountryID"]);
                }
            }

            if (!string.IsNullOrEmpty(SiteLocation))
            {
                TList<Entities.SiteLocation> sl = SiteLocationService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteLocation);
                if (sl.Count > 0)
                {
                    locationid = Convert.ToInt32(sl[0].LocationId);
                }
            }

            if (!string.IsNullOrEmpty(SiteWorkType))
            {
                TList<Entities.SiteWorkType> sw = SiteWorkTypeService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteWorkType);
                if (sw.Count > 0)
                {
                    worktypeid = sw[0].WorkTypeId;
                }
            }

            if (PageNo > 0)
            {
                pageno = PageNo - 1;
            }

            // Get the member saved job ids
            JobsSavedService JobsSavedService = new JobsSavedService();
            strMemberJobIds = JobsSavedService.GetMemberSavedJobs();

            using (VList<ViewJobSearch> viewJobSearch = ViewJobSearchService.GetBySearchFilter(
                                                    string.Empty,
                                                    SessionData.Site.SiteId, null, null, null,
                                                    null, null, worktypeid,
                                                    professionid, roleid.ToString(),
                                                    null, locationid, string.Empty, (DateTime?)null, SessionData.Language.LanguageId,
                                                    pageno, PagingCount, string.Empty, null))
            {

                rptJobResults.DataSource = viewJobSearch;
                rptJobResults.DataBind();

                int count = 0;
                using (DataSet dsJobSearch = ViewJobSearchService.GetBySearchFilterRedefine(
                                                   string.Empty,
                                                   SessionData.Site.SiteId, null, null, null,
                                                   null, null, worktypeid,
                                                   professionid, roleid.ToString(),
                                                   null, locationid,
                                                   string.Empty,
                                                   (DateTime?)null,
                                                   SessionData.Language.LanguageId))
                {

                    DataTable dtJobSearch = dsJobSearch.Tables[0];
                    if (!professionid.HasValue)
                    {
                        // Classification Count the Records
                        int.TryParse(dtJobSearch.Compute("Sum(RefineCount)", String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Classification)).ToString(), out count);
                    }
                    else
                    {
                        // Subclassification Count the Records
                        int.TryParse(dtJobSearch.Compute("Sum(RefineCount)", String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.SubClassification)).ToString(), out count);
                    }
                }

                ltResultNo.Text = count.ToString();
            }

            SetPaging();
        }

        protected void SetPaging()
        {
            if (PageCount > 1)
            {
                List<PagingClass> pagingClassList = new List<PagingClass>();
                PagingClass pagingClass = null;
                for (int i = 1; i <= PageCount; i++)
                {
                    pagingClass = new PagingClass();
                    pagingClass.PageNo = i.ToString();
                    if (PageNo == i)
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

        #endregion

        #region Events
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
                    strJobDescription = String.Format(@"<ul><li>{0}</li><li>{1}</li><li>{2}</li></ul>",
                                                viewJobSearch.BulletPoint1,
                                                viewJobSearch.BulletPoint2,
                                                viewJobSearch.BulletPoint3);
                else
                    strJobDescription = viewJobSearch.Description;


                // Advertiser Job Template Logo
                string strAdvertiserLogo = string.Empty;

                if (viewJobSearch.AdvertiserId.HasValue) //AdvertiserJobTemplateLogoId
                {
                    if (viewJobSearch.HasAdvertiserLogo == 1)
                    {
                        strAdvertiserLogo = String.Format(@"<a href='{2}'><img src='/getfile.aspx?advertiserid={0}' alt='{1}' /></a>",
                                                                viewJobSearch.AdvertiserId.Value,
                                                                viewJobSearch.CompanyName,
                                                                Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName));
                    }

                    if (viewJobSearch.HasAdvertiserLogo == 2)
                    {
                        using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(viewJobSearch.AdvertiserId.Value))
                        {
                            strAdvertiserLogo = String.Format(@"<a href='{2}'><img src='/media/{0}/{1}' alt='{3}' /></a>", ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl, Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName), viewJobSearch.CompanyName);
                        }
                    }
                }



                //<a id='aSaveJob{9}' href='javascript:void(0);' onclick='return SaveJob(""aSaveJob{9}"",{9});'>save job</a>
                ltlJob.Text = String.Format(@"
<div id='job-holder' onmouseover='MouseMover_row(this)' onmouseout='MouseOut_row(this)'>
    <div class='job-toplink'>
        <a href='{7}'>{0}</a>
        <div class='nameofcompany'>{1}</div>
    </div>
    <div class='job-rightlinks'>
        <a class='search-result-save-job-link{13}' id='aSaveJob{8}' onclick='return SaveJob(""aSaveJob{8}"",{8});' href='/member/mysavedjobs.aspx?id={8}'>{11}</a> | <a href='{10}'>{12}</a>
        <br />
        <span class='dateText'>{2}</span>
    </div>
    <div class='description-holder'>
        <div class='job-checkbox' style='width: 20px;'>&nbsp;</div>
        <div class='locandsalary'>
            {3}<br />
            {4}</div>
        <div class='description-text'>{5}</div>
        <div class='description-logo'>{6}</div>
    </div>
    <!-- end of description holder -->
    <div class='job-breadcrumbs'>{9}</div>
</div>
<!-- end of job holder-->
", viewJobSearch.JobName, viewJobSearch.CompanyName,
 viewJobSearch.DatePosted.ToString(SessionData.Site.DateFormat), viewJobSearch.LocationName,
 viewJobSearch.WorkTypeName, strJobDescription,
 strAdvertiserLogo, Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
 viewJobSearch.JobId, viewJobSearch.BreadCrumbNavigation,
 Utils.GetEmailFriendUrl(viewJobSearch.JobFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0], viewJobSearch.JobId),
 IsMemberSavedJob(viewJobSearch.JobId) ? CommonFunction.GetResourceValue("LabelJobSaved") : CommonFunction.GetResourceValue("LinkButtonSaveJob"),
 CommonFunction.GetResourceValue("LinkButtonSendEmail"),
 IsMemberSavedJob(viewJobSearch.JobId) ? " job-saved" : string.Empty);


                // ToDO - Need breadcrumbs - Profession name, Role Name with Links

            }
        }

        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                HyperLink lnkButtonPaging = (HyperLink)e.Item.FindControl("lnkButtonPaging");

                lnkButtonPaging.NavigateUrl = Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry, SiteLocation, SiteWorkType, Convert.ToInt32(pagingClass.PageNo));
                //lnkButtonPaging.CommandArgument = (Convert.ToInt32(pagingClass.PageNo) - 1).ToString();
                lnkButtonPaging.Text = pagingClass.PageNo.ToString();

                if (!pagingClass.Enabled)
                {
                    lnkButtonPaging.CssClass = "disabled_tnt_pagination";
                    lnkButtonPaging.Enabled = false;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                HyperLink lnkButtonPrevious = (HyperLink)e.Item.FindControl("lnkButtonPrevious");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                if (PageNo - 1 <= 0)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination";
                    lnkButtonPrevious.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.NavigateUrl = Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry, SiteLocation, SiteWorkType, PageNo - 1);
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                HyperLink lnkButtonNext = (HyperLink)e.Item.FindControl("lnkButtonNext");
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                if (PageNo >= PageCount)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination";
                    lnkButtonNext.Enabled = false;
                }
                else
                {
                    lnkButtonNext.NavigateUrl = Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry, SiteLocation, SiteWorkType, PageNo + 1);
                }
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
    }
}
