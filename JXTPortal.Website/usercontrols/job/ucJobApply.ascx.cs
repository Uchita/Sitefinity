using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Web;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.JobApplications.PeopleProfile;
using JXTPortal.Entities.Models;
using System.Text;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucJobApply : System.Web.UI.UserControl
    {
        #region Declaration

        public double? MapLat = null;
        public double? MapLng = null;
        public string MapKey = null;
        public string JobAddress = string.Empty;


        private int memberID = 0;
        private int _jobid = 0;
        private string _profession = string.Empty;
        private int _professionid = 0;
        private JobsService _jobsservice;
        private ViewJobsService _viewjobsservice;
        private SiteProfessionService _siteprofessionservice;
        private JobsArchiveService _jobsarchiveservice;
        private JobApplicationService _jobApplicationService;
        private JobsSavedService _jobsSavedService;
        private GlobalSettingsService _globalsettingsservice;
        private IntegrationsService _integrationsService;
        private JobAreaService _jobareaservice;
        private LocationService _locationservice;
        private AreaService _areaservice;
        private SiteLocationService _sitelocationservice;
        private SiteAreaService _siteareaservice;

        #endregion

        #region Properties

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

        protected int JobID
        {
            get
            {
                if ((Request.QueryString["JobID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobID"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["JobID"]);
                    }
                    return _jobid;
                }

                return _jobid;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                    _siteprofessionservice = new SiteProfessionService();

                return _siteprofessionservice;
            }
        }

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                    _globalsettingsservice = new GlobalSettingsService();

                return _globalsettingsservice;
            }
        }


        protected string Profession
        {
            get
            {
                if ((Request.QueryString["Profession"] != null))
                {
                    _profession = Request.QueryString["Profession"];


                }
                if (!string.IsNullOrEmpty(Request.QueryString["professionid"]))
                {
                    int professionId = Convert.ToInt32(Request.QueryString["professionid"]);
                    TList<JXTPortal.Entities.SiteProfession> sps = SiteProfessionService.GetByProfessionId(professionId);
                    sps.Filter = "SiteId = " + SessionData.Site.SiteId.ToString();
                    if (sps.Count > 0)
                    {
                        _profession = sps[0].SiteProfessionFriendlyUrl;
                    }
                }
                return _profession;
            }
        }

        protected int ProfessionId
        {
            get
            {
                if ((Request.QueryString["ProfessionID"] != null))
                {
                    _professionid = Convert.ToInt32(Request.QueryString["ProfessionID"]);


                }
                if (!string.IsNullOrEmpty(Request.QueryString["profession"]))
                {
                    string profession = Request.QueryString["profession"].ToString();
                    System.Data.DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, profession);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _professionid = Convert.ToInt32(ds.Tables[0].Rows[0]["ProfessionId"]);
                    }
                }
                return _professionid;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsservice == null)
                {
                    _jobsservice = new JobsService();
                }
                return _jobsservice;
            }
        }

        private ViewJobsService ViewJobsService
        {
            get
            {
                if (_viewjobsservice == null)
                {
                    _viewjobsservice = new ViewJobsService();
                }
                return _viewjobsservice;
            }
        }

        private JobsArchiveService JobsArchiveService
        {
            get
            {
                if (_jobsarchiveservice == null)
                {
                    _jobsarchiveservice = new JobsArchiveService();
                }
                return _jobsarchiveservice;
            }
        }

        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }

        }

        private JobsSavedService JobsSavedService
        {
            get
            {
                if (_jobsSavedService == null)
                {
                    _jobsSavedService = new JobsSavedService();
                }
                return _jobsSavedService;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobareaservice == null)
                {
                    _jobareaservice = new JobAreaService();
                }
                return _jobareaservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
            }
        }

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

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                {
                    _siteareaservice = new SiteAreaService();
                }
                return _siteareaservice;
            }
        }

        private string _indeedapitoken = string.Empty;
        protected string IndeedAPIToken
        {
            get { return _indeedapitoken; }
            set { _indeedapitoken = value; }
        }

        private string _joblocation = string.Empty;
        protected string JobLocation
        {
            get { return _joblocation; }
            set { _joblocation = value; }
        }

        private string _companyname = string.Empty;
        protected string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _jobtitle = string.Empty;
        protected string JobTitle
        {
            get { return _jobtitle; }
            set { _jobtitle = value; }
        }

        private string _joburl = string.Empty;
        protected string JobURL
        {
            get { return _joburl; }
            set { _joburl = value; }
        }

        private string _posturl = string.Empty;
        protected string PostURL
        {
            get { return _posturl; }
            set { _posturl = value; }
        }
        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            // Set the Title
            //CommonPage.SetBrowserPageTitle(Page, "Job Apply");

            // Email / Print Job
            hypPrintJob.NavigateUrl = "javascript:window.print();";
            hypEmailJob.NavigateUrl = "#";
            //ibApplyWithLinkedIn.Attributes.Remove("border");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetFormValues();

            if (JobID <= 0)
            {
                Response.Redirect("~/advancedsearch.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (gslist.Count > 0)
                        {
                            GlobalSettings gs = gslist[0];
                            if (string.IsNullOrWhiteSpace(gs.LinkedInApi) || string.IsNullOrWhiteSpace(gs.LinkedInApiSecret))
                            {
                                ibApplyWithLinkedIn.Visible = false;
                                
                            }
                        }
                        else
                        {
                            ibApplyWithLinkedIn.Visible = false;
                        }
                    }

                    using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                    {
                        if (job == null)
                        {
                            using (JXTPortal.Entities.JobsArchive jobarchive = JobsArchiveService.GetByJobId(JobID))
                            {
                                if (jobarchive == null)
                                {
                                    Response.Redirect("~/advancedsearch.aspx");
                                }
                                else
                                {
                                    TwitterArchivedJob();

                                    lbApplied.Text = CommonFunction.GetResourceValue("LabelJobIsArchived");
                                    lbApplied.Visible = false; // true
                                    divApplyNow.Visible = false;
                                    divApplyNowBottom.Visible = false;
                                    ibApplyWithLinkedIn.Visible = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(Request.Params["profession"]) && string.IsNullOrEmpty(Request.Params["professionid"]))
                            {
                                Response.Redirect("~/advancedsearch.aspx");
                            }
                            else
                            {
                                VList<Entities.ViewJobs> jobs = ViewJobsService.GetByID(JobID, SessionData.Site.SiteId);
                                if (jobs.Count > 0)
                                {
                                    bool found = false;
                                    TList<Entities.SiteProfession> sps = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId);

                                    foreach (Entities.ViewJobs j in jobs)
                                    {
                                        foreach (Entities.SiteProfession sp in sps)
                                        {
                                            if (j.ProfessionId == sp.ProfessionId)
                                            {
                                                found = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (!found)
                                    {
                                        Response.Redirect("~/advancedsearch.aspx");
                                    }


                                    // Get the similar jobs.
                                    SimilarJobs(jobs[0].JobId, jobs[0].ProfessionId, jobs[0].RoleId);

                                }
                                else
                                {
                                    Response.Redirect("~/advancedsearch.aspx");
                                }
                            }

                            DateTime timenow = DateTime.Now;

                            TwitterJob();

                            hypEmailJob.NavigateUrl = Utils.GetEmailFriendUrl(Profession, job.JobId);
                            //hypRssJob.NavigateUrl = JobsService.GetRSSFeedUrl(null, null, null, null, null);

                            if (job.Expired != null && (job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired)
                                    || (job.ExpiryDate < DateTime.Now))
                            {
                                lbApplied.Text = CommonFunction.GetResourceValue("LabelJobIsExpired");
                                lbApplied.Visible = false; // true
                                divApplyNow.Visible = false;
                                divApplyNowBottom.Visible = false;
                                ibApplyWithLinkedIn.Visible = false;
                                return;
                            }

                            //show map location if exists
                            string joblocname = string.Empty, jobareaname = string.Empty;

                            TList<Entities.JobArea> jobareas = JobAreaService.GetByJobId(job.JobId);
                            if (jobareas.Count > 0)
                            {
                                Entities.Area area = AreaService.GetByAreaId(jobareas[0].AreaId);
                                if (area != null)
                                {
                                    Entities.Location location = LocationService.GetByLocationId(area.LocationId);
                                    SiteLocation siteloc =  SiteLocationService.GetTranslatedLocation(location.LocationId, location.CountryId);
                                    SiteArea sitearea = SiteAreaService.GetTranslatedArea(area.AreaId, location.LocationId, SessionData.Site.SiteId);
                                    if (siteloc != null)
                                    {
                                        joblocname = siteloc.SiteLocationName;
                                        jobareaname = sitearea.SiteAreaName;
                                    }
                                }
                            }

                            ToggleJobMapLocation(job.JobLatitude, job.JobLongitude, job.AddressStatus, job.Address, job.JobId, job.JobName, job.CompanyName, joblocname, jobareaname);

                            if (job.ApplicationMethod == null || job.ApplicationMethod == (int)PortalEnums.Jobs.ApplicationMethod.None)
                            {
                                divApplyNow.Visible = false;
                                divApplyNowBottom.Visible = false;
                            }

                            // Job external email address is blank OR is a JOBBOARD then Linkedin and apply now buttons is HIDDEN
                            if (string.IsNullOrWhiteSpace(job.ApplicationEmailAddress) || SessionData.Site.IsJobBoard)
                            {
                                ibApplyWithLinkedIn.Visible = false;
                            }
                            
                            if (IsSimpleExternalLogon(job)) // If it is external job, makes the job apply link target to _blank
                            {
                                string strApplicationUrl = string.Empty;

                                strApplicationUrl = string.Format("/jobtracking.aspx?jobid={0}", job.JobId);

                                // Append the UTM source tag for the third party application.
                                strApplicationUrl = Utils.GetTrackingUtmTags(strApplicationUrl);
   

                                // TODO - HARDCODED for PeopleProfiler - ServiceDott
                                if (SessionData.Member != null) //logged in user
                                {
                                    // job.ApplicationUrl
                                    strApplicationUrl = ServiceDottIntegration.ExternalApplicationLinkGet(strApplicationUrl, SessionData.Member.EmailAddress, SessionData.Member.FirstName, SessionData.Member.Surname);
                                }
                                else
                                {
                                    // Else it puts back the Job Tracking
                                    strApplicationUrl = ServiceDottIntegration.ExternalApplicationLinkGet(strApplicationUrl, null, null, null);
                                }

                                lbApplyNow.Target = "_blank";
                                lbApplyNowBottom.Target = "_blank";

                                lbApplyNow.Attributes.Add("rel", "nofollow");
                                lbApplyNowBottom.Attributes.Add("rel", "nofollow");

                                lbApplyNow.NavigateUrl = strApplicationUrl;
                                lbApplyNowBottom.NavigateUrl = strApplicationUrl;

                                // Don't show Indeed if external application
                                phApplyWithIndeed.Visible = false;
                            }
                            else // default redirect to apply page
                            {

                                // Job external email address is blank then apply now buttons are disabled
                                if (string.IsNullOrWhiteSpace(job.ApplicationEmailAddress))
                                {
                                    divApplyNow.Visible = false;
                                    divApplyNowBottom.Visible = false;
                                }
                                else
                                {
                                    string strApplicationUrl = string.Empty;


                                    // Check if there is any CUSTOM APPLICATION FORM 
                                    JobApplicationTypeService JobApplicationTypeService = new JobApplicationTypeService();
                                    using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                                    {
                                        if (globalSetting.Count > 0)
                                        {
                                            if (globalSetting[0].JobApplicationTypeId.HasValue)
                                            {
                                                // 

                                                using (JXTPortal.Entities.JobApplicationType jobapplicationType = JobApplicationTypeService.GetByJobApplicationTypeId(globalSetting[0].JobApplicationTypeId.Value))
                                                {
                                                    // Todo 
                                                    // /job/application/customquestions.aspx?jobid=$0&profession=$1

                                                    if (jobapplicationType != null)
                                                    {
                                                        strApplicationUrl = string.Format(jobapplicationType.JobApplicationTypeUrl, JobID, Profession);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    // JXT Application Form
                                    if (string.IsNullOrWhiteSpace(strApplicationUrl))
                                    {
                                        strApplicationUrl = string.Format("/applyjob{0}", Utils.GetJobUrl(JobID, job.JobFriendlyName, Profession));
                                    }

                                    lbApplyNow.NavigateUrl = strApplicationUrl;
                                    lbApplyNowBottom.NavigateUrl = strApplicationUrl;
                                }
                            }


                            // Todo for checking if applied for the job.
                            if (SessionData.Member != null && job.ApplicationMethod != (int)PortalEnums.Jobs.ApplicationMethod.URL)
                            {

                                using (TList<JobApplication> jobApplicationList = JobApplicationService.CustomGetByJobIdMemberId(JobID, SessionData.Member.MemberId))
                                {
                                    if (jobApplicationList != null && jobApplicationList.Count > 0 &&
                                            SessionData.Member.MemberId == jobApplicationList[0].MemberId &&
                                            jobApplicationList[0].Draft == false)
                                    {

                                        divApplyNow.Visible = false;
                                        divApplyNowBottom.Visible = false;
                                        ibApplyWithLinkedIn.Visible = false;

                                        DateTime auTime = ((DateTime)jobApplicationList[0].ApplicationDate);
                                        string userTimeZoneID = "AUS Eastern Standard Time";
                                        TimeZoneInfo ausTimeZone = TimeZoneInfo.FindSystemTimeZoneById(userTimeZoneID);
                                        DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(auTime, ausTimeZone);

                                        //lbApplied.Text = "You applied for this job on " + ((DateTime)jobappps[0].ApplicationDate).ToString("dd MMM yyyy");
                                        //lbApplied.Text = "AU: " + auTime.ToLongDateString() + " " + auTime.ToLongTimeString() + "|| utc:" + utcTime.ToLongDateString() + " " + utcTime.ToLongTimeString() + "||" + utcTime.ToString("s") + "Z";

                                        //by default display the AU time (ie the system time)
                                        lbApplied.Text = String.Format("{0} <span data-utctime='{1}' data-dateformat='{2}'>{3}</span>", CommonFunction.GetResourceValue("LabelJobApplied"),
                                                        utcTime.ToString("s") + "Z", SessionData.Site.DateFormat, auTime.ToString(SessionData.Site.DateFormat));
                                        //lbApplied.Attributes.Add("data-utctime", utcTime.ToString("s") + "Z");

                                        lbApplied.Visible = true; // true
                                    }
                                }

                                /*
                                using (TList<JXTPortal.Entities.JobApplication> jobappps = JobApplicationService.GetByMemberId(SessionData.Member.MemberId))
                                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                                {
                                    jobappps.Filter = "JobID = " + JobID.ToString();

                                    if (jobappps.Count > 0)
                                    {
                                        if (job.ApplicationMethod == (int?)PortalEnums.Jobs.ApplicationMethod.URL)
                                        {
                                            //lbApplied.Text = "You might have applied for this job on " +
                                            //            ((DateTime)jobappps[0].ApplicationDate).ToString("dd MMM yyyy");
                                            lbApplied.Text = String.Format("{0}{1}", CommonFunction.GetResourceValue("LabelJobHaveApplied"),
                                                            ((DateTime)jobappps[0].ApplicationDate).ToString("dd MMM yyyy"));
                                        }
                                        else
                                        {
                                            divApplyNow.Visible = false;
                                            divApplyNowBottom.Visible = false;
                                            //lbApplied.Text = "You applied for this job on " + ((DateTime)jobappps[0].ApplicationDate).ToString("dd MMM yyyy");
                                            lbApplied.Text = String.Format("{0} {1}", CommonFunction.GetResourceValue("LabelJobApplied"),
                                                            ((DateTime)jobappps[0].ApplicationDate).ToString("dd MMM yyyy"));
                                        }
                                        lbApplied.Visible = false; // true
                                        //Me.dcAlreadyApplied.Visible = True
                                    }
                                }*/
                            }
                        }
                    }

                }
            }
        }

        #endregion

        #region Methods

        private void SimilarJobs(int jobid, int professionId, int roleId)
        {
            ViewJobSearchService ViewJobSearchService = new ViewJobSearchService();
            // STANDARD / STAND OUT JOBS
            StringBuilder strBuilder = new StringBuilder();

            using (VList<ViewJobSearch> viewJobSearchs = ViewJobSearchService.GetBySearchFilter(string.Empty,
                                                        SessionData.Site.SiteId, null,
                                                        null, null, null, null, null,
                                                        professionId, roleId.ToString(),
                                                        null, null, string.Empty, null,
                                                        0, 10, string.Empty, null))
            {
                if (viewJobSearchs != null && viewJobSearchs.Where(s => s.JobId != jobid).Count() >= 5)
                {
                    // Jobs which are not the job which you are viewing. Take max 5
                    foreach (var viewJobSearch in viewJobSearchs.Where(s => s.JobId != jobid).Take(5))
                    {

                        strBuilder.AppendFormat(@"
<li>
	<a href='{0}' class='jxt-similar-job'>
		<span class='jxt-similar-job-title'>{1}</span>
		<span class='jxt-similar-job-location'><i class='fa fa-map-marker'></i> {2}</span>
		<span class='jxt-similar-job-worktype'><i class='fa fa-briefcase'></i> {3}</span>
	</a>
</li>
",
    Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
    viewJobSearch.JobName,
    viewJobSearch.LocationName,
    viewJobSearch.WorkTypeName
    );
                    }
                }
                else
                {
                    using (VList<ViewJobSearch> viewJobSearchs_1 = ViewJobSearchService.GetBySearchFilter(string.Empty,
                                                        SessionData.Site.SiteId, null,
                                                        null, null, null, null, null,
                                                        professionId, string.Empty,
                                                        null, null, string.Empty, null, SessionData.Language.LanguageId,
                                                        0, 10, string.Empty, null))
                    {
                        if (viewJobSearchs_1 != null && viewJobSearchs_1.Where(s => s.JobId != jobid).Count() > 0)
                        {
                            // Jobs which are not the job which you are viewing. Take max 5
                            foreach (var viewJobSearch in viewJobSearchs_1.Where(s => s.JobId != jobid).Take(5))
                            {

                                strBuilder.AppendFormat(@"
<li>
	<a href='{0}' class='jxt-similar-job'>
		<span class='jxt-similar-job-title'>{1}</span>
		<span class='jxt-similar-job-location'><i class='fa fa-map-marker'></i> {2}</span>
		<span class='jxt-similar-job-worktype'><i class='fa fa-briefcase'></i> {3}</span>
	</a>
</li>
",
            Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
            viewJobSearch.JobName,
            viewJobSearch.LocationName,
            viewJobSearch.WorkTypeName
            );
                            }


                        }
                    }
                }
            }

            if (strBuilder.Length > 0)
            {
                ltlSimilarJobs.Text = "<ul>" + strBuilder.ToString() + "</ul>";
                phSimilarJobs.Visible = true;
            }
        }
        private void ToggleJobMapLocation(double? lat, double? lng, int? addressStatus, string jobAddress, int jobid, string jobname, string companyname, string locationame, string areaname)
        {
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if ((lat != null && lng != null && addressStatus != null && (PortalEnums.Jobs.JobGeocodeStatus)addressStatus == PortalEnums.Jobs.JobGeocodeStatus.Valid)
                || string.IsNullOrWhiteSpace(jobAddress) == false)
            {

                if (integrations != null && integrations.GoogleMap != null)
                {
                    if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                    {
                        //assign variables for ascx use
                        MapLat = lat;
                        MapLng = lng;
                        MapKey = integrations.GoogleMap.ServerKey;

                        phJobMapLocation.Visible = true;
                    }
                }

                if (!string.IsNullOrWhiteSpace(jobAddress))
                {
                    JobAddress = jobAddress.Replace("'", "\\'");
                    phJobMapLocation.Visible = true;
                }

            }

            // Load Indeed
            if (integrations != null && integrations.Indeed != null)
            {
                AdminIntegrations.Indeed indeed = integrations.Indeed;
                if (indeed.Valid)
                {
                    IndeedAPIToken = indeed.APIToken;
                    JobLocation = areaname + ", " + locationame;
                    CompanyName = companyname;
                    JobTitle = jobname.Replace("\"", "'"); ;
                    JobURL = string.Format("{0}://{1}{2}", (Request.IsSecureConnection) ? "https" : "http", Request.Url.Host, JobsService.GetJobUrl(Profession, jobname, jobid));
                    PostURL = string.Format("{0}://{1}{2}", (Request.IsSecureConnection) ? "https" : "http", Request.Url.Host,
                        "/oauthcallback.aspx?cbtype=indeed&cbaction=apply&jobid=" + JobID.ToString() +
                        "&profession=" + Profession + "&jobname=" + HttpUtility.UrlEncode(jobname)
                        );
                    //protected string PostURL
                    phApplyWithIndeed.Visible = true;
                }
            }
        }

        private bool IsSimpleExternalLogon(JXTPortal.Entities.Jobs job)
        {
            if (job != null)
            {
                if (job.ApplicationMethod == (int)PortalEnums.Jobs.ApplicationMethod.URL && !string.IsNullOrEmpty(job.ApplicationUrl))
                {
                    return true;
                }
            }

            return false;
        }

        public void SetFormValues()
        {
            lnkSavedJobs.Text = CommonFunction.GetResourceValue("LinkButtonSavedJobs");
            lbApplyNow.Text = CommonFunction.GetResourceValue("LinkButtonApplyNow");
            lbApplyNowBottom.Text = CommonFunction.GetResourceValue("LinkButtonApplyNow");
            hypPrintJob.Text = CommonFunction.GetResourceValue("LinkButtonPrintJob");
            hypEmailJob.Text = CommonFunction.GetResourceValue("LinkButtonEmailJob");
            //ltJobNote.Text = CommonFunction.GetResourceValue("LinkButtonAddNote");
            //ltJobTag.Text = CommonFunction.GetResourceValue("LinkButtonAddTag");
            hypFacebookJob.Text = CommonFunction.GetResourceValue("LinkButtonJobShareFacebook");
            hypTwitterJob.Text = CommonFunction.GetResourceValue("LinkButtonJobShareTwitter");
            hypLinkedInJob.Text = CommonFunction.GetResourceValue("LinkButtonJobLinkedIn");
            hypGooglePlusJob.Text = CommonFunction.GetResourceValue("LabelShareOnGooglePlus");
            //hypRssJob.Text = CommonFunction.GetResourceValue("LinkButtonJobRSS");
        }

        #endregion

        #region Events

        protected void lnkSavedJobs_Click(object sender, EventArgs e)
        {
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            Response.Redirect("~/member/mysavedjobs.aspx?id=" + JobID);
        }


        protected void lnkRssJob_Click(object sender, EventArgs e)
        {

        }

        protected void TwitterJob()
        {
            using (Entities.Jobs jobs = JobsService.GetByJobId(JobID))
            {

                string twitterLink = "https://twitter.com/intent/tweet?text=[JobTitle]+in+[JobURL]";
                string strJobURL = string.Empty;
                string strJobName = string.Empty;

                if (!string.IsNullOrEmpty(jobs.JobName))
                {
                    strJobName = jobs.JobName;
                }

                // ToDO: Add Friendly Job Url
                if(SessionData.Site.EnableSsl)
                    strJobURL = "https://" + Request.ServerVariables["HTTP_HOST"] + string.Format("/p/{0}/j/{1}", ProfessionId, JobID);
                else
                    strJobURL = "http://" + Request.ServerVariables["HTTP_HOST"] + string.Format("/p/{0}/j/{1}", ProfessionId, JobID);

                twitterLink = twitterLink.Replace("[JobTitle]", HttpUtility.UrlEncode(strJobName));
                twitterLink = twitterLink.Replace("[JobURL]", strJobURL);
                hypTwitterJob.Attributes.Add("target", "_blank");
                hypTwitterJob.Attributes.Add("href", twitterLink);

                hiddenMobiJobName.Value = strJobName;
                hiddenMobiJobURL.Value = strJobURL;

            }
        }

        protected void TwitterArchivedJob()
        {
            using (Entities.JobsArchive jobs = JobsArchiveService.GetByJobId(JobID))
            {

                string twitterLink = "https://twitter.com/intent/tweet?text=[JobTitle]+in+[JobURL]";
                string strJobURL = string.Empty;
                string strJobName = string.Empty;

                if (!string.IsNullOrEmpty(jobs.JobName))
                {
                    strJobName = jobs.JobName;
                }

                // ToDO: Add Friendly Job Url
                if (SessionData.Site.EnableSsl)
                    strJobURL = "https://" + Request.ServerVariables["HTTP_HOST"] + string.Format("/p/{0}/j/{1}", ProfessionId, JobID);
                else
                    strJobURL = "http://" + Request.ServerVariables["HTTP_HOST"] + string.Format("/p/{0}/j/{1}", ProfessionId, JobID);

                twitterLink = twitterLink.Replace("[JobTitle]", HttpUtility.UrlEncode(strJobName));
                twitterLink = twitterLink.Replace("[JobURL]", strJobURL);
                hypTwitterJob.Attributes.Add("target", "_blank");
                hypTwitterJob.Attributes.Add("href", twitterLink);

                hiddenMobiJobName.Value = strJobName;
                hiddenMobiJobURL.Value = strJobURL;
            }
        }

        #endregion

        protected void ibApplyWithLinkedIn_Click(object sender, ImageClickEventArgs e)
        {
            oAuthLinkedIn _oauth = new oAuthLinkedIn();
            string LinkedInAPI = string.Empty;
            string urlsuffix = string.Empty;

            using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        LinkedInAPI = gs.LinkedInApi;
                        string http = (HttpContext.Current.Request.IsSecureConnection) ? "https://" : "http://";

                        urlsuffix = http + HttpContext.Current.Request.Url.Host;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(LinkedInAPI))
                Response.Redirect(_oauth.RequestToken(LinkedInAPI, urlsuffix, JobID.ToString(), HttpContext.Current.Request.RawUrl, Utils.GetUrlReferrerDomain(), new List<string> { "cbtype=linkedin", "cbaction=Apply" }));
        }
    }
}