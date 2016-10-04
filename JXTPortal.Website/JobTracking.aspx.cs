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
using JXTPortal.JobApplications.PeopleProfile;

namespace JXTPortal.Website
{
    public partial class JobTracking : System.Web.UI.Page
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            JXTPortal.Entities.Members member = null;

            if (SessionData.Member != null)
            {
                member = MembersService.GetByMemberId(SessionData.Member.MemberId);
            }

            //int jobappid = 0;
            string jobapplicationemail = string.Empty;
            // Check existing member

            string strUrlReferral = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], JobID);

            // [TODO] Member Apply for job sp
            using (Entities.Jobs job = JobsService.GetByJobId(JobID))
            {
                if (job != null)
                {
                    if (job.ApplicationMethod == (int)PortalEnums.Jobs.ApplicationMethod.URL && !string.IsNullOrEmpty(job.ApplicationUrl))
                    {
                        // Save the Job application
                        using (JXTPortal.Entities.JobApplication jobapp = new JXTPortal.Entities.JobApplication())
                        {
                            bool blnAlreadyApplied = false;

                            if (SessionData.Member != null)
                            {
                                // Check if all applied then only redirect
                                using (TList<JobApplication> jobApplicationList = JobApplicationService.CustomGetByJobIdMemberId(JobID, SessionData.Member.MemberId))
                                {
                                    if (jobApplicationList != null && jobApplicationList.Count > 0)
                                    {
                                        jobapp.EmailAddress = jobApplicationList[0].EmailAddress;
                                        jobapp.FirstName = jobApplicationList[0].FirstName;
                                        jobapp.Surname = jobApplicationList[0].Surname;

                                        blnAlreadyApplied = true;
                                    }
                                }
                            }

                            if (!blnAlreadyApplied)
                            {
                                jobapp.ApplicationDate = DateTime.Now;
                                jobapp.JobId = JobID;
                                jobapp.JobAppValidateId = new Guid();
                                jobapp.SiteIdReferral = SessionData.Site.SiteId;
                                jobapp.UrlReferral = strUrlReferral;

                                if (member != null)
                                {
                                    jobapp.MemberId = member.MemberId;
                                    jobapp.FirstName = member.FirstName;
                                    jobapp.Surname = member.Surname;
                                    jobapp.EmailAddress = member.EmailAddress;
                                    jobapp.MobilePhone = member.MobilePhone;
                                }

                                jobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                                jobapp.Draft = false;
                                JobApplicationService.Insert(jobapp);
                                //jobappid = jobapp.JobApplicationId;
                            }

                            jobapplicationemail = job.ApplicationEmailAddress;

                            ltReferrer.Text = strUrlReferral;

                            // Redirect to external applicatione

                            string strAppUrl = CommonService.DecodeString(job.ApplicationUrl);

                            // TODO - HARDCODED for FastTrack 
                            if (!string.IsNullOrWhiteSpace(strAppUrl) && Request.QueryString["utm_source"] != null)
                                strAppUrl = strAppUrl.Replace("Jobsite=JXT", "Jobsite=" + Request.QueryString["utm_source"]);

                            // TODO - HARDCODED for PeopleProfiler - ServiceDott
                            strAppUrl = ServiceDottIntegration.ExternalApplicationLinkGet(strAppUrl, jobapp.EmailAddress, jobapp.FirstName, jobapp.Surname);

                            Response.Redirect(strAppUrl);
                        }



                    }
                    else
                    {
                        // Not external job
                        Response.Redirect(Utils.GetJobUrl(JobID, job.JobFriendlyName));
                    }
                }
                else
                {
                    if (Request.UrlReferrer != null)
                    {
                        Response.Redirect(Request.UrlReferrer.OriginalString);
                    }
                }

            }
        }
    }
}