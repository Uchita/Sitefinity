using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;

namespace JXTPortal.Website
{
    public partial class ApplyJob : System.Web.UI.Page
    {
        #region Declaration

        private MemberFilesService _memberFilesService;
        private JobsService _jobsService;
        private JobApplicationService _jobApplicationService;
        private MembersService _memebrsService;
        private SiteProfessionService _siteprofessionservice;
        private JobAlertsService _jobalertsservice;
        private JobRolesService _jobrolesservice;
        private JobAreaService _jobareaservice;
        private AreaService _areaservice;
        private LocationService _locationservice;
        private JobViewsService _jobviewsservice;

        private int _jobid = 0;

        #endregion

        #region Properties

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

        private string _profession = string.Empty;
        protected string Profession
        {
            get
            {
                if ((Request.QueryString["Profession"] != null))
                {
                    _profession = Request.QueryString["Profession"];
                    return _profession;
                }

                return _profession;
            }
        }

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

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberFilesService == null)
                    _memberFilesService = new MemberFilesService();
                return _memberFilesService;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
            }
        }

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

        private JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobalertsservice == null)
                    _jobalertsservice = new JobAlertsService();
                return _jobalertsservice;
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
        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
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

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobrolesservice == null)
                    _jobrolesservice = new JobRolesService();
                return _jobrolesservice;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobareaservice == null)
                    _jobareaservice = new JobAreaService();
                return _jobareaservice;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                    _areaservice = new AreaService();
                return _areaservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                    _locationservice = new LocationService();
                return _locationservice;
            }
        }

        private JobViewsService JobViewsService
        {
            get
            {
                if (_jobviewsservice == null)
                    _jobviewsservice = new JobViewsService();
                return _jobviewsservice;
            }
        }

        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            //CommonPage.SetBrowserPageTitle(Page, "Apply Job");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;
            
            string strOnCoverLetterSelection = string.Format("OnCoverLetterSelection('{0}', '{1}', '{2}', '{3}')", rbNoCoverLetter.ClientID, rbWriteOneNow.ClientID, rbUploadCoverLetter.ClientID, rbExistingCoverLetter.ClientID);

            rbNoCoverLetter.Attributes.Add("OnClick", strOnCoverLetterSelection);
            rbWriteOneNow.Attributes.Add("OnClick", strOnCoverLetterSelection);
            rbUploadCoverLetter.Attributes.Add("OnClick", strOnCoverLetterSelection);
            rbExistingCoverLetter.Attributes.Add("OnClick", strOnCoverLetterSelection);

            string strOnResumeSelection = string.Format("OnResumeSelection('{0}', '{1}', '{2}', '{3}')", rbUploadResume.ClientID, rbNoResume.ClientID, rbExistingResume.ClientID, rbUseMyProfile.ClientID);
            rbUploadResume.Attributes.Add("OnClick", strOnResumeSelection);
            rbNoResume.Attributes.Add("OnClick", strOnResumeSelection);
            rbExistingResume.Attributes.Add("OnClick", strOnResumeSelection);
            rbUseMyProfile.Attributes.Add("OnClick", strOnResumeSelection);

            if (JobID > 0)
            {
                using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(JobID, SessionData.Site.SiteId))
                {
                    if (jobs.Count > 0)
                    {
                        // Update Job View for the Job.
                        if (Utils.GetCookieDomain(Request.Cookies["JobsViewed"], JobID) == string.Empty)
                        {
                            bool needupdate = false;
                            string domain = Utils.GetUrlDomain();
                            Utils.UpdateJobsViewedCookie(JobID, domain, out needupdate);
                            if (needupdate)
                            {
                                JobViewsService.UpdateCounter(JobID, SessionData.Site.SiteId, domain, DateTime.Now.Date);
                            }
                        }

                        JXTPortal.Entities.ViewJobs job = null;
                        foreach (JXTPortal.Entities.ViewJobs j in jobs)
                        {
                            using (DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, Profession))
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

                        DateTime timenow = DateTime.Now;
                        litJobName.Text = job.JobName;

                        using (DataSet siteprofessions = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, Profession))
                        {
                            hLinkJob.Text = job.JobName;
                            hLinkJob.NavigateUrl = Utils.GetJobUrl(job.JobId, job.JobFriendlyName);
                            hLinkProfession.Text = job.SiteProfessionName;
                            hLinkProfession.NavigateUrl = string.Format("/advancedsearch.aspx?search=1&professionid={0}", siteprofessions.Tables[0].Rows[0]["ProfessionID"]);
                        }

                        // Check if the job is expired if yes then redirect to the job detail page.
                        if (job.Expired.HasValue && (job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || (job.ExpiryDate < new DateTime(timenow.Year, timenow.Month, timenow.Day, 23, 59, 59)))
                        {
                            Response.Redirect(Utils.GetJobUrl(job.JobId, job.JobFriendlyName));
                        }

                        // You can only apply for live jobs.
                        if (job.Expired.HasValue && (job.Expired.Value != (int)PortalEnums.Jobs.JobStatus.Live))
                            Response.Redirect("~/advancedsearch.aspx");
                        

                        CancelButton.OnClientClick = string.Format("location.href = '~/{0}'", Utils.GetJobUrl(JobID, job.JobFriendlyName, Profession));
                        CancelButton.PostBackUrl = string.Format("~/{0}", Utils.GetJobUrl(JobID, job.JobFriendlyName, Profession));



                        // SEO - Job Name on the Browser Title
                        using (Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId))
                        {
                            if (globalSettings != null)
                                CommonPage.SetBrowserPageTitle(Page, string.Format("Apply job - {0} {1}", job.JobName, globalSettings.PageTitleSuffix));
                            else
                                CommonPage.SetBrowserPageTitle(Page, "Apply job - " + job.JobName);
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
                    }
                    else
                    {
                        Response.Redirect("~/advancedsearch.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/advancedsearch.aspx");
            }

            if (SessionData.Member == null)
            {
                pnlLoggedIn.Visible = false;
                rbExistingCoverLetter.Visible = false;
                rbExistingResume.Visible = false;
            }
            else
            {
                using (TList<JXTPortal.Entities.JobApplication> jobapp = JobApplicationService.GetByJobId(JobID))
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (jobapp != null)
                    {
                        jobapp.Filter = "MemberID = " + SessionData.Member.MemberId.ToString();
                        if (jobapp.Count > 0)
                        {
                            if (job == null)
                            {
                                Response.Redirect("advancedsearch.aspx");
                            }
                            else
                            {
                                Response.Redirect(Utils.GetJobUrl(job.JobId, job.JobFriendlyName, Profession));
                            }
                        }
                    }
                }
                phUseMyPorfile.Visible = true;


                ucContactDetails1.Visible = false;
                string strLoggedIn = CommonFunction.GetResourceValue("LabelCurrentLogin");
                litLoggedIn.Text = string.Format("{0} {1}", strLoggedIn, SessionData.Member.Username);

                // Check if applied job
                using (TList<JXTPortal.Entities.JobApplication> jobappps = JobApplicationService.GetByMemberId(SessionData.Member.MemberId))
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    jobappps.Filter = "JobID = " + JobID.ToString();

                    if (jobappps.Count > 0)
                    {
                        if (job == null)
                        {
                            Response.Redirect("advancedsearch.aspx");
                        }
                        else
                        {
                            Response.Redirect(Utils.GetJobUrl(job.JobId, job.JobFriendlyName, Profession));
                        }
                    }
                }


                if (!Page.IsPostBack)
                {
                    LoadCoverLetter();
                    LoadResume();
                }
            }

            SetDisplay();


            // Custom Form - Currently this is hardcoded in future will change to dynamic form.
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["PeopleBankWLs"]) && ConfigurationManager.AppSettings["PeopleBankWLs"].Contains(" " + SessionData.Site.SiteId + " "))
            {
                pnlPeopleBank.Visible = true;
            }
            else
            {
                pnlPeopleBank.Visible = false;
            }

            // Application Method - If Internal or external

            // If Internal then apply

            // Save the files as a Physical file - Use Encrypt method to encrypt the file 
            // use CommonFunction.Compress()

            // Email to advertiser / advertiser user / Application email

            // Send user email that he applied.

            SetFormValues();
        }

        public void SetFormValues()
        {
            ucContactDetails1.OptionChanged += new EventHandler(ucContactDetails1_OptionChanged);
            rbNoCoverLetter.Text = CommonFunction.GetResourceValue("ButtonNoCoverLetter");
            rbWriteOneNow.Text = CommonFunction.GetResourceValue("ButtonWriteOneNow");
            rbUseMyProfile.Text = CommonFunction.GetResourceValue("ButtonUseMyProfile");
            CusVal_CoverLetterText.ErrorMessage = CommonFunction.GetResourceValue("ButtonWriteOneNow");
            CusVal_CoverLetterText.ErrorMessage = CommonFunction.GetResourceValue("ErrorCoverLetterEmpty");
            rbUploadCoverLetter.Text = CommonFunction.GetResourceValue("ButtonUploadCoverLetterNow");
            CusVal_FileUploadCV.ErrorMessage = CommonFunction.GetResourceValue("LabelPleaseSelectDoc");
            rbExistingCoverLetter.Text = CommonFunction.GetResourceValue("LabelSelectExistingCover");
            CusVal_CoverLetter.ErrorMessage = CommonFunction.GetResourceValue("LabelPleaseSelectDoc");
            rbUploadResume.Text = CommonFunction.GetResourceValue("ButtonUploadResumeNow");
            CusVal_FileUploadResume.ErrorMessage = CommonFunction.GetResourceValue("LabelPleaseSelectDoc");
            rbNoResume.Text = CommonFunction.GetResourceValue("ButtonNoResume");
            rbExistingResume.Text = CommonFunction.GetResourceValue("LabelSelectExistingResume");
            CusVal_Resume.ErrorMessage = CommonFunction.GetResourceValue("LabelPleaseSelectDoc");
            rbJobAlertYes.Text = CommonFunction.GetResourceValue("LabelJobAlertYes");
            rbJobAlertNo.Text = CommonFunction.GetResourceValue("LabelJobAlertNo");
            ApplyButton.Text = CommonFunction.GetResourceValue("LinkButtonApplyNow");
            CancelButton.Text = CommonFunction.GetResourceValue("ButtonCancel");
        }

        private void ucContactDetails1_OptionChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = sender as RadioButtonList;
            if (rbl.SelectedValue == "JustApply")
            {
                ApplyButton.Enabled = true;
            }
            else
            {
                ApplyButton.Enabled = false;
            }
        }

        #endregion

        #region Methods

        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }

        private void SetDisplay()
        {
            if (Page.IsPostBack)
            {
                if (rbNoCoverLetter.Checked)
                {
                    divCoverLetterText.Style["display"] = "none";
                    divFileUploadCV.Style["display"] = "none";
                    divCoverLetter.Style["display"] = "none";
                }

                if (rbWriteOneNow.Checked)
                {
                    divCoverLetterText.Style["display"] = "block";
                    divFileUploadCV.Style["display"] = "none";
                    divCoverLetter.Style["display"] = "none";
                }

                if (rbUploadCoverLetter.Checked)
                {
                    divCoverLetterText.Style["display"] = "none";
                    divFileUploadCV.Style["display"] = "block";
                    divCoverLetter.Style["display"] = "none";
                }

                if (rbExistingCoverLetter.Checked)
                {
                    divCoverLetterText.Style["display"] = "none";
                    divFileUploadCV.Style["display"] = "none";
                    divCoverLetter.Style["display"] = "block";
                }

                if (rbUploadResume.Checked)
                {
                    divFileUploadResume.Style["display"] = "block";
                }

                if (rbNoResume.Checked)
                {
                    divFileUploadResume.Style["display"] = "none";
                }

                if (rbExistingResume.Checked)
                {
                    divResume.Style["display"] = "block";
                    divFileUploadResume.Style["display"] = "none";
                }
            }
        }

        private void LoadCoverLetter()
        {
            if (SessionData.Member != null)
            {
                using (TList<JXTPortal.Entities.MemberFiles> MemberFiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    ddlCoverLetter.DataSource = MemberFiles;
                    MemberFiles.Filter = "DocumentTypeID = 1";
                    ddlCoverLetter.DataBind();
                }
            }

            ddlCoverLetter.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseCover"), "0"));
        }

        private void LoadResume()
        {
            if (SessionData.Member != null)
            {
                using (TList<JXTPortal.Entities.MemberFiles> MemberFiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    ddlResume.DataSource = MemberFiles;
                    MemberFiles.Filter = "DocumentTypeID = 2";
                    ddlResume.DataBind();
                }
            }

            ddlResume.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseResume"), "0"));
        }

        #endregion

        #region Events

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.Members member = null;

                if (SessionData.Member == null)
                {
                    member = ucContactDetails1.Save();
                    if (member == null)
                    {
                        return;
                    }
                }
                else
                {
                    member = MembersService.GetByMemberId(SessionData.Member.MemberId);
                }
                int jobappid = 0;
                string jobapplicationemail = string.Empty;
                // Check existing member

                if (member != null)
                {
                    string strUrlReferral = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], JobID);

                    // [TODO] Member Apply for job sp
                    using (JXTPortal.Entities.JobApplication jobapp = new JXTPortal.Entities.JobApplication())
                    {
                        jobapp.ApplicationDate = DateTime.Now;
                        jobapp.JobId = JobID;
                        jobapp.MemberId = member.MemberId;

                        jobapp.JobAppValidateId = new Guid();
                        jobapp.SiteIdReferral = SessionData.Site.SiteId;
                        jobapp.UrlReferral = strUrlReferral;
                        jobapp.FirstName = member.FirstName;
                        jobapp.Surname = member.Surname;
                        jobapp.EmailAddress = member.EmailAddress;
                        jobapp.MobilePhone = member.MobilePhone;
                        jobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                        jobapp.Draft = false;
                        JobApplicationService.Insert(jobapp);
                        jobappid = jobapp.JobApplicationId;

                        // Disable the Apply Button
                        ApplyButton.Enabled = false;

                        using (Entities.Jobs job = JobsService.GetByJobId(jobapp.JobId.Value))
                        {
                            if (job != null)
                            {
                                jobapplicationemail = job.ApplicationEmailAddress;
                                string domain = string.Empty;
                                ltReferrer.Text = domain;

                                // Retrieve value from JobsViewed Cookie, the format is {JobID}|{Domain},...
                                domain = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], JobID);

                                // call JobClientTracking to retrieve job application email if matches criteria (for Broadbean atm) 
                                JobClientTracking tracking = new JobClientTracking(jobapplicationemail);
                                jobapplicationemail = tracking.RetrieveEmail(domain);

                            }
                        }

                    }

                    if (rbJobAlertYes.Checked)
                    {
                        int jobAlertID = JobAlertsService.SaveMemberJobAlert(JobID, SessionData.Site.SiteId, member.MemberId, member.EmailFormat, Profession);

                        /*
                        using (Entities.JobAlerts jobAlert = new Entities.JobAlerts())
                        using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
                        using (TList<JXTPortal.Entities.JobArea> jobareas = JobAreaService.GetByJobId(JobID))
                        {
                            if (!string.IsNullOrEmpty(Profession))
                            {
                                System.Data.DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, Profession);
                                int professionid = Convert.ToInt32(ds.Tables[0].Rows[0]["ProfessionID"]);
                                TList<JXTPortal.Entities.JobRoles> jobroles = JobRolesService.GetByJobIdProfessionId(JobID, professionid);

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    JXTPortal.Entities.JobArea ja = jobareas[0];

                                    Entities.Area area = AreaService.GetByAreaId(ja.AreaId);
                                    Entities.Location location = LocationService.GetByLocationId(area.LocationId);
                                    string roles = string.Empty;
                                    foreach (Entities.JobRoles jr in jobroles)
                                    {
                                        roles += jr.RoleId.ToString() + ",";
                                    }
                                    roles = roles.TrimEnd(new char[] { ',' });

                                    jobAlert.SearchKeywords = string.Empty;
                                    jobAlert.ProfessionId = professionid;
                                    jobAlert.SearchRoleIds = roles;
                                   
                                    jobAlert.LocationId = area.LocationId;
                                    jobAlert.AreaIds = area.AreaId.ToString();
                                    jobAlert.WorkTypeIds = job.WorkTypeId.ToString();
                                    //jobAlert.SalaryIds = job.SalaryId.ToString();

                                    jobAlert.MemberId = member.MemberId;
                                    jobAlert.EmailFormat = member.EmailFormat;

                                    jobAlert.JobAlertName = string.Format("{0} Jobs", ds.Tables[0].Rows[0]["SiteProfessionName"]);
                                    jobAlert.PrimaryAlert = false;
                                    jobAlert.AlertActive = true;

                                    JobAlertsService.Insert(jobAlert);
                                }
                            }
                        }*/
                    }
                }

                using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(jobappid))
                {
                    if (jobapp != null)
                    {
                        int coverletterid = 0;
                        int resumeid = 0;

                        Entities.MemberFiles coverletter = null;
                        Entities.MemberFiles resume = null;

                        string errormessage = string.Empty;

                        bool useFTP = (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"]));
                        string ftpclpath = string.Empty;
                        string ftpresumepath = string.Empty;
                        string ftpusername = string.Empty;
                        string ftppassword = string.Empty;


                        Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                        FtpClient ftpclient = new FtpClient();
                        if (useFTP)
                        {
                            ftpclpath = ConfigurationManager.AppSettings["FTPJobApplyCoverLetterUrl"];
                            ftpresumepath = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];
                            ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                            ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                        }

                        if (rbExistingCoverLetter.Checked && ddlCoverLetter.SelectedValue != "0")
                        {
                            coverletterid = Convert.ToInt32(ddlCoverLetter.SelectedValue);
                            coverletter = MemberFilesService.GetByMemberFileId(coverletterid);

                            jobapp.MemberCoverLetterFile = string.Format("{0}_Coverletter_{1}", jobappid, r.Replace(coverletter.MemberFileName, "_"));

                            if (useFTP)
                            {
                                ftpclient.Host = ftpclpath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(new MemoryStream(coverletter.MemberFileContent), ftpclpath + jobapp.MemberCoverLetterFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Coverletter_{2}", (ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"]), jobappid, coverletter.MemberFileName);


                                Utils.EncryptFile(new MemoryStream(coverletter.MemberFileContent), filepath);
                            }
                        }

                        if (rbExistingResume.Checked && ddlResume.SelectedValue != "0")
                        {
                            resumeid = Convert.ToInt32(ddlResume.SelectedValue);
                            resume = MemberFilesService.GetByMemberFileId(resumeid);

                            jobapp.MemberResumeFile = string.Format("{0}_Resume_{1}", jobappid, r.Replace(resume.MemberFileName, "_"));
                            if (useFTP)
                            {
                                ftpclient.Host = ftpresumepath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(new MemoryStream(resume.MemberFileContent), ftpresumepath + jobapp.MemberResumeFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Resume_{2}", (ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]), jobappid, resume.MemberFileName);

                                Utils.EncryptFile(new MemoryStream(resume.MemberFileContent), filepath);
                            }
                        }

                        if (rbUploadCoverLetter.Checked && fileUploadCV.PostedFile.ContentLength > 0)
                        {
                            jobapp.MemberCoverLetterFile = string.Format("{0}_Coverletter_{1}", jobappid, r.Replace(fileUploadCV.PostedFile.FileName, "_"));
                            if (useFTP)
                            {
                                ftpclient.Host = ftpclpath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(fileUploadCV.PostedFile.InputStream, ftpclpath + jobapp.MemberCoverLetterFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Coverletter_{2}", (ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"]), jobappid, r.Replace(fileUploadCV.PostedFile.FileName, "_"));
                                fileUploadCV.PostedFile.SaveAs(filepath);
                                //Utils.EncryptFile(fileUploadCV.PostedFile.InputStream, filepath);
                            }
                        }

                        if (rbUploadResume.Checked && fileUploadResume.PostedFile != null && fileUploadResume.PostedFile.ContentLength > 0)
                        {
                            jobapp.MemberResumeFile = string.Format("{0}_Resume_{1}", jobappid, r.Replace(fileUploadResume.PostedFile.FileName, "_"));

                            if (useFTP)
                            {
                                ftpclient.Host = ftpresumepath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(fileUploadResume.PostedFile.InputStream, ftpresumepath + jobapp.MemberResumeFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Resume_{2}", (ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]), jobappid, r.Replace(fileUploadResume.PostedFile.FileName, "_"));
                                fileUploadResume.SaveAs(filepath);

                                //Utils.EncryptFile(fileUploadResume.PostedFile.InputStream, filepath);
                            }
                        }

                        if (rbWriteOneNow.Checked)
                        {
                            byte[] byteArray = Encoding.ASCII.GetBytes(txtCoverLetterText.Text);
                            MemoryStream stream = new MemoryStream(byteArray);
                            jobapp.MemberCoverLetterFile = string.Format("{0}_Coverletter.txt", jobappid);

                            if (useFTP)
                            {
                                ftpclient.Host = ftpclpath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(stream, ftpclpath + jobapp.MemberCoverLetterFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Coverletter.txt", (ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"]), jobappid);


                                StreamWriter sw = File.CreateText(filepath);
                                sw.Write(txtCoverLetterText.Text);
                                sw.Close();
                                //Utils.EncryptFile(stream, filepath);

                            }
                        }

                        // When Use my profile is checked
                        if (rbUseMyProfile.Checked)
                        {

                            //define full virtual path
                            var fullPath = "~/usercontrols/member/ucCVProfileDownload.ascx";

                            //initialize a new page to host the control
                            Page page = new Page();
                            //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
                            page.EnableEventValidation = false;

                            //load the control and add it to the page's form
                            JXTPortal.Website.usercontrols.member.ucCVProfileDownload control = (JXTPortal.Website.usercontrols.member.ucCVProfileDownload)page.LoadControl(fullPath);
                            control.Setup();
                            page.Controls.Add(control);

                            //call RenderControl method to get the generated HTML
                            string html = RenderControl(page);

                            byte[] file = new PDFCreator().ConvertHTMLToPDF(html);
                            
                            jobapp.MemberResumeFile = string.Format("{0}_Resume_{1}.pdf", jobappid, SessionData.Member.MemberId); // using memberid is as suffix of file name

                            if (useFTP)
                            {
                                ftpclient.Host = ftpresumepath;
                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;
                                ftpclient.UploadFileFromStream(new MemoryStream(file), ftpresumepath + jobapp.MemberResumeFile, out errormessage);
                            }
                            else
                            {
                                string filepath = string.Format("{0}{1}_Resume_{2}.pdf", (ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]), jobappid, SessionData.Member.MemberId);
                                Utils.EncryptFile(new MemoryStream(file), filepath);
                            }
                        }

                        // Custom Fields
                        HybridDictionary customEmailFields = new HybridDictionary();
                        if (pnlPeopleBank.Visible)
                        {
                            customEmailFields.Add("CUSTOM_LANDLINE", txtLandline.Text);
                            customEmailFields.Add("CUSTOM_STATE", ddlState.SelectedValue);
                            customEmailFields.Add("CUSTOM_RESIDENCYSTATUS", ddlResidencyStatus.SelectedValue);
                        }

                        if (JobApplicationService.Update(jobapp))
                        {
                            int siteid = SessionData.Site.SiteId;
                            using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(JobID)))
                            {
                                if (job != null)
                                {
                                    siteid = job.SiteId;
                                }
                            }

                            MailService.SendMemberJobApplicationEmail(member);
                            MailService.SendAdvertiserJobApplicationEmail(member, jobapp, customEmailFields, siteid, jobapplicationemail);
                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBAPPLY_SUCCESS, "", "", ""));
                        }
                        else
                        {
                            litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelJobApplyFailed"));
                            ApplyButton.Enabled = true;
                        }
                    }
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
            {
                Response.Redirect("~/" + Utils.GetJobUrl(JobID, job.JobFriendlyName, Profession));
            }
        }

        protected void CusVal_CoverLetterText_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbWriteOneNow.Checked)
            {
                if (string.IsNullOrEmpty(Utils.StripHTML(txtCoverLetterText.Text.Trim())))
                {
                    SetFocus(txtCoverLetterText.ClientID);
                    args.IsValid = false;
                }
            }
        }

        protected void CusVal_FileUploadCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbUploadCoverLetter.Checked)
            {
                if (fileUploadCV.PostedFile.ContentLength == 0 || string.IsNullOrEmpty(fileUploadCV.PostedFile.FileName))
                {
                    SetFocus(fileUploadCV.ClientID);
                    args.IsValid = false;
                    ltCLRestriction.Visible = false;
                    return;
                }


                args.IsValid = CommonFunction.CheckExtension(fileUploadCV.PostedFile.FileName);
                if (!args.IsValid)
                {
                    SetFocus(fileUploadCV.ClientID);
                    ltCLRestriction.Visible = false;
                    CusVal_FileUploadCV.ErrorMessage = CommonFunction.GetResourceValue("ErrorInvalidFileType");
                }
            }
        }

        protected void CusVal_CoverLetter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbExistingCoverLetter.Checked)
            {
                if (ddlCoverLetter.SelectedValue == "0")
                {
                    SetFocus(ddlCoverLetter.ClientID);
                    args.IsValid = false;
                }
            }
        }

        protected void CusVal_FileUploadResume_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbUploadResume.Checked)
            {
                if (fileUploadResume.PostedFile == null || fileUploadResume.PostedFile.ContentLength == 0 || string.IsNullOrEmpty(fileUploadResume.PostedFile.FileName))
                {
                    SetFocus(fileUploadResume.ClientID );
                    ltResumeRestriction.Visible = false;
                    args.IsValid = false;
                    return;
                }

                args.IsValid = CommonFunction.CheckExtension(fileUploadResume.PostedFile.FileName);
                if (!args.IsValid)
                {
                    SetFocus(fileUploadResume.ClientID);
                    ltResumeRestriction.Visible = false;
                    CusVal_FileUploadResume.ErrorMessage = CommonFunction.GetResourceValue("ErrorInvalidFileType");
                }
            }
        }

        protected void CusVal_Resume_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rbExistingResume.Checked)
            {
                if (ddlResume.SelectedValue == "0")
                {
                    args.IsValid = false;
                    SetFocus(ddlResume.ClientID);
                }
            }
        }

        private void SetFocus(string clientid)
        {
            string js = "$(document).ready(function() { var el = document.getElementById(\"" + clientid + "\"); el.scrollIntoView(false); })";
            
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "focusJS", js, true);
        }
        #endregion


    }
}
