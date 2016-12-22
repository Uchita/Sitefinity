using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Configuration;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucJobPreview : System.Web.UI.UserControl
    {

        #region "Properties"

        private ViewJobsService _viewJobsService;

        private ViewJobsService ViewJobsService
        {
            get
            {
                if (_viewJobsService == null)
                    _viewJobsService = new ViewJobsService();
                return _viewJobsService;
            }
        }

        private ViewJobsArchiveService _viewJobsArchiveService;

        private ViewJobsArchiveService ViewJobsArchiveService
        {
            get
            {
                if (_viewJobsArchiveService == null)
                    _viewJobsArchiveService = new ViewJobsArchiveService();
                return _viewJobsArchiveService;
            }
        }

        private JobTemplatesService _jobTemplatesService;

        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobTemplatesService == null)
                    _jobTemplatesService = new JobTemplatesService();

                return _jobTemplatesService;
            }
        }

        private SiteProfessionService _siteprofessionservice;

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                    _siteprofessionservice = new SiteProfessionService();

                return _siteprofessionservice;
            }
        }

        private ProfessionService _professionservice;

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionservice == null)
                    _professionservice = new ProfessionService();

                return _professionservice;
            }
        }

        private SiteRolesService _siteroleservice;

        private SiteRolesService SiteRoleService
        {
            get
            {
                if (_siteroleservice == null)
                    _siteroleservice = new SiteRolesService();

                return _siteroleservice;
            }
        }

        private SiteLocationService _sitelocservice;

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocservice == null)
                    _sitelocservice = new SiteLocationService();

                return _sitelocservice;
            }
        }

        private SiteAreaService _siteareaservice;

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                    _siteareaservice = new SiteAreaService();

                return _siteareaservice;
            }
        }

        private SiteWorkTypeService _siteworktypeservice;

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeservice == null)
                    _siteworktypeservice = new SiteWorkTypeService();

                return _siteworktypeservice;
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

        private JobCustomXmlService _jobcustomxmlService = null;

        private JobCustomXmlService JobCustomXmlService
        {
            get
            {
                if (_jobcustomxmlService == null)
                {
                    _jobcustomxmlService = new JobCustomXmlService();
                }
                return _jobcustomxmlService;
            }
        }

        private ConsultantsService _consultantservice = null;
        private ConsultantsService ConsultantsService
        {
            get
            {
                if (_consultantservice == null)
                {
                    _consultantservice = new ConsultantsService();
                }
                return _consultantservice;
            }
        }

        private SiteMappingsService _sitemappingsservice = null;
        private SiteMappingsService SiteMappingsService
        {
            get
            {
                if (_sitemappingsservice == null)
                {
                    _sitemappingsservice = new SiteMappingsService();
                }
                return _sitemappingsservice;
            }
        }

        private AdvertiserJobTemplateLogoService _advertiserjobtemplatelogoService = null;
        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserjobtemplatelogoService == null)
                {
                    _advertiserjobtemplatelogoService = new AdvertiserJobTemplateLogoService();
                }
                return _advertiserjobtemplatelogoService;
            }
        }

        public int JobId
        {
            get
            {
                int _jobId = 0;

                if (Request.QueryString["JobId"] != null && Int32.TryParse(Request.QueryString["JobId"], out _jobId))
                {
                    _jobId = Convert.ToInt32(Request.QueryString["JobId"]);
                }
                return _jobId;
            }
        }

        public string Profession
        {
            get
            {
                string _profession = string.Empty;

                _profession = Request.QueryString["profession"];

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

        private bool _isAdvertiserPreview = false;

        public bool isAdvertiserPreview
        {
            get { return _isAdvertiserPreview; }
            set { _isAdvertiserPreview = value; }
        }

        #endregion

        #region "Event Handlers"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadJobPreview();

            phBackToResult.Visible = !isAdvertiserPreview;
        }

        #endregion

        #region "Methods"

        private void LoadJobPreview()
        {
            if (JobId > 0)
            {
                bool blnIsJob = false;
                string previewprofession = string.Empty;

                using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(JobId, SessionData.Site.SiteId))
                {
                    int jcount = jobs.Count;

                    if (jcount > 0)
                    {

                        JXTPortal.Entities.ViewJobs job = null;

                        if (Request.RawUrl.ToLower().Contains("jobpreview.aspx"))
                        {
                            job = jobs[0];
                            JobRolesService jrs = new JobRolesService();
                            using (TList<JXTPortal.Entities.SiteProfession> sps = SiteProfessionService.GetBySiteIdProfessionId(SessionData.Site.SiteId, job.ProfessionId))
                            {
                                //sps.Filter = "SiteId = " + SessionData.Site.SiteId.ToString();
                                if (sps.Count > 0)
                                {
                                    previewprofession = sps[0].SiteProfessionFriendlyUrl;
                                }
                            }
                        }
                        else
                        {

                            foreach (JXTPortal.Entities.ViewJobs j in jobs)
                            {
                                using (DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, (!string.IsNullOrEmpty(Profession)) ? Profession : previewprofession))
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        DataRow dr = ds.Tables[0].Rows[0];
                                        if (j.ProfessionId == Convert.ToInt32(dr["ProfessionID"]))
                                        {
                                            job = j;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        //TODO: Create a boolean function to check whether the site is a public or not
                        if (job != null)
                        {
                            ViewJobsService.SetJobLanguage(ref job, SessionData.Site.DefaultLanguageId, SessionData.Language.LanguageId);

                            // When you are on Job Detail page and the job is not live then redirect to the advanced search page.
                            if (!isAdvertiserPreview && job.Expired.HasValue && job.Expired != (int)PortalEnums.Jobs.JobStatus.Live)
                                Response.Redirect("~/advancedsearch.aspx");


                            int totalcount = 0;

                            // CanonicalUrl get the Role Canonical else the profession
                            string canonicalUrl = (string.IsNullOrWhiteSpace(job.SiteRoleCanonicalUrl)) ? job.SiteProfessionCanonicalUrl : job.SiteRoleCanonicalUrl;

                            if (!string.IsNullOrWhiteSpace(canonicalUrl))
                            {
                                Literal ltCanonicalUrl = new Literal() { Text = @"<link rel=""canonical"" href=""" + canonicalUrl.Replace("\"", "") + @""" />" };
                                Page.Header.Controls.Add(ltCanonicalUrl);
                            }
                            else
                            {
                                // If there is no profession role urls then job url.
                                canonicalUrl = string.Format("{0}://{1}{2}",
                                                                (SessionData.Site.EnableSsl ? "https" : "http"),
                                                                (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl,
                                                                Utils.GetJobUrl(job.JobId, job.JobFriendlyName));

                                Literal ltCanonicalUrl = new Literal() { Text = @"<link rel=""canonical"" href=""" + canonicalUrl.Replace("\"", "") + @""" />" };
                                Page.Header.Controls.Add(ltCanonicalUrl);
                            }

                            // Canonical Og Url for sharing to social media
                            Literal ltCanonicalOgUrl = new Literal()
                            {
                                Text = @"<meta property=""og:url"" content=""" +
                                             string.Format("{0}://{1}{2}",
                                                                (SessionData.Site.EnableSsl ? "https" : "http"),
                                                                (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl,
                                                                Utils.GetJobUrl(job.JobId, job.JobFriendlyName)) +
                                                 @""" />"
                            };
                            Page.Header.Controls.Add(ltCanonicalOgUrl);

                            using (JXTPortal.Entities.JobTemplates template = JobTemplatesService.GetByJobTemplateId(job.JobTemplateId.Value))
                            using (DataSet siteprofessions = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, (!string.IsNullOrEmpty(Profession)) ? Profession : previewprofession))
                            {
                                blnIsJob = true;

                                hLinkJob.Text = job.JobName;
                                hLinkJob.NavigateUrl = Utils.GetJobUrl(job.JobId, job.JobFriendlyName);
                                hLinkProfession.Text = HttpUtility.HtmlEncode(SiteProfessionService.GetTranslatedProfessionById(job.ProfessionId, SessionData.Site.UseCustomProfessionRole).SiteProfessionName);
                                hLinkProfession.NavigateUrl = string.Format("/advancedsearch.aspx?search=1&ProfessionID={0}",
                                    siteprofessions.Tables[0].Rows[0]["ProfessionID"]);


                                // Replace Full Description with script encoded Description 
                                template.JobTemplateHtml = template.JobTemplateHtml.Replace("{Description}", CommonService.DecodeString(job.Description, true, false, true));
                                template.JobTemplateHtml = template.JobTemplateHtml.Replace("{FullDescription}", CommonService.EncodeString(job.FullDescription, false, false, true));

                                //remove Salary decimal value .00 and add "," separate for thousand
                                if (!job.ShowSalaryRange)
                                {
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryLowerBand}", string.Empty);
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryUpperBand}", string.Empty);
                                    //template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryTypeName}", string.Empty);
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{CurrencySymbol}", string.Empty);
                                }
                                else
                                {
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryLowerBand}", (job.SalaryLowerBand == 0) ? "0" : job.SalaryLowerBand.ToString("0,0.##"));
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryUpperBand}", job.SalaryUpperBand.ToString("0,0.##"));
                                }

                                /*
                                if (job.QualificationsRecognised)
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{QualificationsRecognised}", CommonFunction.GetResourceValue("LabelQualificationsRecognised"));
                                */
                                if (job.ResidentOnly)
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{ResidentOnly}", CommonFunction.GetResourceValue("LabelCandidatesRight"));
                                else
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{ResidentOnly}", string.Empty);

                                if (!job.ShowSalaryDetails)
                                {
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryText}", string.Empty);
                                }

                                // Hardcoded the tag for Job Views 
                                if (template.JobTemplateHtml.Contains("{JobViewCount}"))
                                {
                                    ViewJobsService viewJobsService = new ViewJobsService();

                                    using (DataSet ds = viewJobsService.GetViewCount(JobId))
                                    {
                                        int intViews = 0;
                                        if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out intViews))
                                            intViews = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{JobViewCount}", intViews > 0 ? intViews.ToString() : string.Empty);
                                    }
                                }

                                //translate to language selected
                                template.JobTemplateHtml = TranslateJobPreviewToSelectedLanguage(template.JobTemplateHtml, job.LocationId, job.ProfessionId, job.RoleId, job.WorkTypeId, job.AreaId);

                                // Replace all the job tokens in the Job Template
                                litJobPreview.Text = Utils.TokenReplace(job, template.JobTemplateHtml);

                                // Advertiser Job Template Logo
                                string strAdvertiserLogo = string.Empty;
                                if (job.AdvertiserJobTemplateLogoId.GetValueOrDefault(0) > 0)
                                    strAdvertiserLogo = String.Format(@"<img src='/getfile.aspx?advertiserjobtemplatelogoid={0}' alt='{1}' />",
                                                                        job.AdvertiserJobTemplateLogoId.Value,
                                                                        job.CompanyName);

                                //replace the advertiser logo
                                litJobPreview.Text = litJobPreview.Text.Replace("{AdvertiserLogo}", strAdvertiserLogo);

                                // SEO - Job Name on the Browser Title
                                using (Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId))
                                {
                                    if (globalSettings != null)
                                        CommonPage.SetBrowserPageTitle(Page, job.JobName + " " + globalSettings.PageTitleSuffix);
                                    else
                                        CommonPage.SetBrowserPageTitle(Page, job.JobName);
                                }

                                // SEO - Set the Browser Description - Description or Bulletpoints
                                string strJobDescription = string.Empty;
                                if ((!string.IsNullOrEmpty(job.BulletPoint1) && job.BulletPoint1.Trim().Length > 0) ||
                                        (!string.IsNullOrEmpty(job.BulletPoint2) && job.BulletPoint2.Trim().Length > 0) ||
                                        (!string.IsNullOrEmpty(job.BulletPoint3) && job.BulletPoint3.Trim().Length > 0))
                                    if ((string.IsNullOrEmpty(job.BulletPoint3)) && (string.IsNullOrEmpty(job.BulletPoint2)))
                                        strJobDescription = job.BulletPoint1;
                                    else if (string.IsNullOrEmpty(job.BulletPoint3))
                                        strJobDescription = String.Format(@"{0}, {1}",
                                                                job.BulletPoint1,
                                                                job.BulletPoint2);
                                    else
                                        strJobDescription = String.Format(@"{0}, {1}, {2}",
                                                                    job.BulletPoint1,
                                                                    job.BulletPoint2,
                                                                    job.BulletPoint3);
                                else
                                {
                                    strJobDescription = job.Description;

                                    if (strJobDescription.Length > 150)
                                    {
                                        strJobDescription = (new System.Text.StringBuilder(strJobDescription, 0, 150, 150)).ToString();
                                    }
                                }
                                CommonPage.SetBrowserPageDescription(Page, strJobDescription);


                                // Show the job is expired if the record is still in Job table
                                if ((job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || job.ExpiryDate < DateTime.Now)
                                {

                                    litJobExpired.Text = string.Format(@"<div class='expired-notification'><h1>{0}</h1></div>",
                                                                            string.Format(CommonFunction.GetResourceValue("LabelJobTitleIsExpired"), job.JobName));
                                    //CommonFunction.GetResourceValue("LabelJobExpired");

                                    phExpiredJob.Visible = true;
                                }
                            }


                            // Consultants
                            string firstname = string.Empty;
                            string lastname = string.Empty;
                            string consultantemail = string.Empty;
                            string consultantphone = string.Empty;
                            string consultantimageurl = string.Empty;

                            string MultiFirstName = string.Empty;
                            string MultiLastName = string.Empty;

                            if (!string.IsNullOrWhiteSpace(job.ApplicationEmailAddress))
                            {
                                int consultantcount = 0;
                                string sSiteId = SessionData.Site.SiteId.ToString();

                                using (TList<SiteMappings> sitemappings = SiteMappingsService.GetByMasterSiteId(SessionData.Site.MasterSiteId))
                                {
                                    if (sitemappings.Count > 0)
                                    {
                                        sSiteId += "," + SessionData.Site.MasterSiteId.ToString();

                                        foreach (SiteMappings sitemapping in sitemappings)
                                        {
                                            if (sitemapping.SiteId != SessionData.Site.SiteId)
                                            {
                                                sSiteId += "," + sitemapping.SiteId.ToString();
                                            }
                                        }
                                    }
                                }

                                using (TList<Consultants> consultants = ConsultantsService.GetPaged(string.Format("SiteId IN ({0}) and Email = '{1}' and Valid = 1", sSiteId, job.ApplicationEmailAddress.Replace("'", "''")), string.Empty, 1, 0, out consultantcount))
                                {
                                    if (consultants.Count > 0)
                                    {
                                        firstname = HttpUtility.HtmlEncode(consultants[0].FirstName);
                                        lastname = HttpUtility.HtmlEncode(consultants[0].LastName);
                                        consultantemail = HttpUtility.HtmlEncode(consultants[0].Email);
                                        consultantphone = HttpUtility.HtmlEncode(consultants[0].Phone);

                                        if (!string.IsNullOrWhiteSpace(consultants[0].ConsultantImageUrl))
                                        {
                                            consultantimageurl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["ConsultantsFolder"], consultants[0].ConsultantImageUrl);
                                        }
                                        else
                                        {
                                            if (consultants[0].ImageUrl != null)
                                            {
                                                consultantimageurl = "/getfile.aspx?consultantid=" + consultants[0].ConsultantId.ToString();
                                            }
                                        }

                                        if (!string.IsNullOrWhiteSpace(consultants[0].ConsultantsXml))
                                        {
                                            XmlDocument langxml = new XmlDocument();

                                            langxml.LoadXml(consultants[0].ConsultantsXml);

                                            XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                                            foreach (XmlNode langnode in langlist)
                                            {
                                                if (langnode.ChildNodes[0].InnerXml == SessionData.Language.LanguageId.ToString())
                                                {
                                                    MultiFirstName = langnode["FirstName"].InnerXml;
                                                    MultiLastName = langnode["LastName"].InnerXml;

                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantFirstName}", (!string.IsNullOrWhiteSpace(MultiFirstName)) ? MultiFirstName : firstname);
                            litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantLastName}", (!string.IsNullOrWhiteSpace(MultiLastName)) ? MultiLastName : lastname);
                            litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantEmail}", consultantemail);
                            litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantPhone}", consultantphone);
                            litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantImageUrl}", consultantimageurl);
                        }

                    }
                }

                // Show as Archive
                if (!blnIsJob)
                {
                    using (VList<JXTPortal.Entities.ViewJobsArchive> jobs = ViewJobsArchiveService.GetByID(JobId, SessionData.Site.SiteId))
                    {
                        if (jobs.Count > 0)
                        {
                            JXTPortal.Entities.ViewJobsArchive job = null;
                            foreach (JXTPortal.Entities.ViewJobsArchive j in jobs)
                            {
                                DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, (!string.IsNullOrEmpty(Profession)) ? Profession : previewprofession);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    DataRow dr = ds.Tables[0].Rows[0];
                                    if (j.ProfessionId == Convert.ToInt32(dr["ProfessionID"]))
                                    {
                                        job = j;
                                        break;
                                    }
                                }
                            }
                            //TODO: Create a boolean function to check whether the site is a public or not
                            if (job != null)
                            {
                                using (JXTPortal.Entities.JobTemplates template = JobTemplatesService.GetByJobTemplateId(job.JobTemplateId.Value))
                                using (DataSet siteprofessions = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, Profession))
                                {
                                    hLinkJob.Text = job.JobName;
                                    hLinkJob.NavigateUrl = Utils.GetJobUrl(job.JobId, job.JobFriendlyName);
                                    hLinkProfession.Text = HttpUtility.HtmlEncode(ProfessionService.GetTranslatedProfession(job.ProfessionId, SessionData.Language.LanguageId, SessionData.Site.UseCustomProfessionRole).ProfessionName);
                                    hLinkProfession.NavigateUrl = string.Format("/advancedsearch.aspx?search=1&ProfessionID={0}", siteprofessions.Tables[0].Rows[0]["ProfessionID"]);

                                    //if (!job.ShowSalaryRange)
                                    //{
                                    //    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryText}", "");
                                    //}
                                    //else
                                    //{
                                    //    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryText}", string.Format("{0}{1:#,###}-{0}{2:#,###} {3}", job.CurrencySymbol, job.SalaryLowerBand, job.SalaryLowerBand, job.SalaryTypeName));
                                    //}

                                    // Replace Full Description with script encoded Description
                                    template.JobTemplateHtml = template.JobTemplateHtml.Replace("{FullDescription}", CommonService.EncodeString(job.FullDescription, false, false, true));

                                    //remove Salary decimal value .00 and add "," separate for thousand
                                    if (!job.ShowSalaryRange)
                                    {
                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryLowerBand}", "");
                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryUpperBand}", "");
                                        //template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryTypeName}", "");
                                    }
                                    else
                                    {
                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryLowerBand}", job.SalaryLowerBand.ToString("G29"));
                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryUpperBand}", job.SalaryUpperBand.ToString("G29"));
                                    }

                                    if (!job.ShowSalaryDetails)
                                    {
                                        template.JobTemplateHtml = template.JobTemplateHtml.Replace("{SalaryText}", string.Empty);
                                    }

                                    //translate to language selected
                                    template.JobTemplateHtml = TranslateJobPreviewToSelectedLanguage(template.JobTemplateHtml, job.LocationId, job.ProfessionId, job.RoleId, job.WorkTypeId, job.AreaId);

                                    litJobPreview.Text = Utils.TokenReplace(job, template.JobTemplateHtml);

                                    // Job Name on the Browser Title
                                    CommonPage.SetBrowserPageTitle(Page, job.JobName);


                                    // CanonicalUrl get the Role Canonical else the profession
                                    /*string canonicalUrl = (string.IsNullOrWhiteSpace(job.SiteRoleCanonicalUrl)) ? job.SiteProfessionCanonicalUrl : job.SiteRoleCanonicalUrl;

                                    if (!string.IsNullOrWhiteSpace(canonicalUrl))
                                    {
                                        Literal ltCanonicalUrl = new Literal() { Text = @"<link rel=""canonical"" href=""" + canonicalUrl.Replace("\"", "") + @""" />" };
                                        Page.Header.Controls.Add(ltCanonicalUrl);
                                    }
                                    else*/
                                    /*{
                                        // If there is no profession role urls then job url.
                                        string canonicalUrl = string.Format("{0}://{1}{2}",
                                                                        (SessionData.Site.EnableSsl ? "https" : "http"),
                                                                        (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl,
                                                                        Utils.GetJobUrl(job.JobId, job.JobFriendlyName));

                                        Literal ltCanonicalUrl = new Literal() { Text = @"<link rel=""canonical"" href=""" + canonicalUrl.Replace("\"", "") + @""" />" };
                                        Page.Header.Controls.Add(ltCanonicalUrl);


                                        // Canonical Og Url for sharing to social media
                                        Literal ltCanonicalOgUrl = new Literal()
                                        {
                                            Text = @"<meta property=""og:url"" content=""" +
                                                         string.Format("{0}://{1}{2}",
                                                                            (SessionData.Site.EnableSsl ? "https" : "http"),
                                                                            (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl,
                                                                            Utils.GetJobUrl(job.JobId, job.JobFriendlyName)) +
                                                             @""" />"
                                        };
                                        Page.Header.Controls.Add(ltCanonicalOgUrl);
                                    }*/


                                    // Advertiser Job Template Logo
                                    string strAdvertiserLogo = string.Empty;

                                    if (job.AdvertiserJobTemplateLogoId.GetValueOrDefault(0) > 0)
                                    {
                                        using (AdvertiserJobTemplateLogo logo = AdvertiserJobTemplateLogoService.GetByAdvertiserJobTemplateLogoId(job.AdvertiserJobTemplateLogoId.Value))
                                        {
                                            if (!string.IsNullOrWhiteSpace(logo.JobTemplateLogoUrl))
                                            {
                                                strAdvertiserLogo = String.Format(@"<img src='/media/{0}/{1}' alt='{2}' />",
                                                                                            ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"],
                                                                                            logo.JobTemplateLogoUrl,
                                                                                            job.CompanyName);
                                            }
                                            else
                                            {
                                                if (logo.JobTemplateLogo != null)
                                                {
                                                    if (job.AdvertiserJobTemplateLogoId.GetValueOrDefault(0) > 0)
                                                        strAdvertiserLogo = String.Format(@"<img src='/getfile.aspx?advertiserjobtemplatelogoid={0}' alt='{1}' />",
                                                                                            job.AdvertiserJobTemplateLogoId.Value,
                                                                                            job.CompanyName);
                                                }
                                            }

                                        }
                                    }

                                    //replace the advertiser logo
                                    litJobPreview.Text = litJobPreview.Text.Replace("{AdvertiserLogo}", strAdvertiserLogo);

                                    litJobExpired.Text = string.Format(@"<div class='expired-notification'><h1>{0}</h1></div>",
                                                                            string.Format(CommonFunction.GetResourceValue("LabelJobTitleIsExpired"), job.JobName));
                                    //CommonFunction.GetResourceValue("LabelJobExpired");

                                    phExpiredJob.Visible = true;
                                }

                                // Consultants
                                string jobowner = string.Empty;
                                string consultantemail = string.Empty;
                                string consultantphone = string.Empty;
                                string consultantimageurl = string.Empty;

                                if (!string.IsNullOrWhiteSpace(job.ApplicationEmailAddress))
                                {
                                    int consultantcount = 0;
                                    TList<Consultants> consultants = ConsultantsService.GetPaged(string.Format("SiteId = {0} and Email = '{1}' and Valid = 1", SessionData.Site.SiteId, job.ApplicationEmailAddress), string.Empty, 1, 0, out consultantcount);
                                    if (consultants.Count > 0)
                                    {
                                        jobowner = HttpUtility.HtmlEncode(consultants[0].FirstName);
                                        consultantemail = HttpUtility.HtmlEncode(consultants[0].Email);
                                        consultantphone = HttpUtility.HtmlEncode(consultants[0].Phone);
                                        
                                        if (!string.IsNullOrWhiteSpace(consultants[0].ConsultantImageUrl))
                                        {
                                            consultantimageurl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["ConsultantsFolder"], consultants[0].ConsultantImageUrl);
                                        }
                                        else
                                        {
                                            if (consultants[0].ImageUrl != null)
                                            {
                                                consultantimageurl = "/getfile.aspx?consultantid=" + consultants[0].ConsultantId.ToString();
                                            }
                                        }
                                    }
                                }

                                litJobPreview.Text = litJobPreview.Text.Replace("{JobOwner}", jobowner);
                                litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantEmail}", consultantemail);
                                litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantPhone}", consultantphone);
                                litJobPreview.Text = litJobPreview.Text.Replace("{ConsultantImageUrl}", consultantimageurl);

                            }

                        }
                    }

                }

            }
        }

        #endregion

        #region "Private Helpers"

        private string TranslateJobPreviewToSelectedLanguage(string templateHTML, int locationID, int professionID, int roleID, int worktypeID, int areaID)
        {
            //Do any translate according to the selected language
            if (SessionData.Language.LanguageId != (int)PortalEnums.Languages.Language.English)
            {
                //get the country ID
                int location_countryID = 0;
                using (Entities.Location location = new LocationService().GetByLocationId(locationID))
                {
                    if (location != null)
                        location_countryID = location.CountryId;
                }

                using (Entities.SiteProfession siteProfession = SiteProfessionService.GetTranslatedProfessionById(professionID, SessionData.Site.UseCustomProfessionRole))
                using (Entities.SiteRoles siteRole = SiteRoleService.GetTranslatedRolesById(roleID, professionID, SessionData.Site.UseCustomProfessionRole))
                using (Entities.SiteWorkType siteWorkType = SiteWorkTypeService.GetTranslatedWorkTypesById(worktypeID))
                using (Entities.SiteLocation siteLocation = SiteLocationService.GetTranslatedLocation(locationID, location_countryID))
                using (Entities.SiteArea siteArea = SiteAreaService.GetTranslatedArea(areaID, locationID, SessionData.Site.SiteId))
                {
                    //Profession
                    templateHTML = (siteProfession != null ? templateHTML.Replace("{SiteProfessionName}", siteProfession.SiteProfessionName) : templateHTML);
                    //Role
                    templateHTML = (siteRole != null ? templateHTML.Replace("{SiteRoleName}", siteRole.SiteRoleName) : templateHTML);
                    //Worktype
                    templateHTML = (siteWorkType != null ? templateHTML.Replace("{SiteWorkTypeName}", siteWorkType.SiteWorkTypeName) : templateHTML);
                    //Location
                    templateHTML = (siteLocation != null ? templateHTML.Replace("{SiteLocationName}", siteLocation.SiteLocationName) : templateHTML);
                    //Area
                    templateHTML = (siteArea != null ? templateHTML.Replace("{SiteAreaName}", siteArea.SiteAreaName) : templateHTML);
                }
            }



            return templateHTML;
        }

        #endregion

    }
}