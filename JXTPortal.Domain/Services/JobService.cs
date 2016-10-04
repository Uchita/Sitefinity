using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using JXTPortal.Entities;
using AutoMapper;
using System.Configuration;
using JXTPortal.Domain.ViewModel;
using System.Data;
using JXTPortal.Common;
using System.IO;
using System.Web;

namespace JXTPortal.Domain.Services
{
    public class JobService
    {

        public const string PAGE_SIZE_KEY = "PageSize";

        public JobModel.JobDetail GetById(int SiteId, int JobId)
        {
            JobModel.JobDetail model = new JobModel.JobDetail();
            Mapper.CreateMap<ViewJobs, JobModel.JobDetail>();

            var job = ViewJobsService.GetByID(JobId, SiteId);
            if (job.Count > 0)
            {
                model = Mapper.Map<ViewJobs, JobModel.JobDetail>(job[0]);
                model.IsJobApplied = false;
                model.IsJobSaved = false;
            }

            if (SiteId > 0)
            {
                var settings = GlobalSettingsService.GetBySiteId(SiteId);
                if (settings.Count > 0)
                {
                    model.LinkedInAPI = settings[0].LinkedInApi;
                    model.LinkedInSecret = settings[0].LinkedInApiSecret;
                    model.LinkedInLogo = settings[0].LinkedInLogo;
                    model.LinkedInCompanyID = (settings[0].LinkedInCompanyId.HasValue) ? settings[0].LinkedInCompanyId.Value : 0;
                    model.LinkedInEmail = settings[0].LinkedInEmail;
                    model.LinkedInJobName = (string.IsNullOrEmpty(model.RefNo)) ? model.JobName.Replace("\"", "'") : string.Format("{0}({1})", model.JobName.Replace("\"", "'"), model.RefNo);
                }

                var site = SitesService.GetBySiteId(SiteId);
                if (site != null)
                {
                    model.LinkedInApplicationLink = "http://www." + site.SiteUrl + "/LinkedInJobApplication.aspx";
                }
            }

            if (SessionData.Member != null)
            {
                //TODO: Generate a SP - in JobsSaved that accept jobid and memberid
                model.IsJobSaved = (JobsSavedService.GetByMemberId(SessionData.Member.MemberId)
                                    .Where(x => x.JobId == JobId).ToList().Count != 0);

                //TODO: Generate a SP - in JobApplicationService that accept jobid and memberid
                model.IsJobApplied = (JobApplicationService.GetByMemberId(SessionData.Member.MemberId)
                                    .Where(x => x.JobId == JobId).ToList().Count != 0);
            }

            return model;

        }

        public JobModel.Result Search(int SiteId, JobModel.Search model, int PageNo)
        {
            JobModel.Result resultmodel = new JobModel.Result();
            resultmodel.PageNo = PageNo;

            string kw = resultmodel.JobSearchModel.Keyword;
            string roleid = null;
            string areaid = null;
            int? professionid = null;
            int? locationid = null;
            int? worktypeid = null;
            DateTime? dateFrom = null;

            if (model.ProfessionId > 0)
                professionid = model.ProfessionId;

            if (model.RoleId != null && model.RoleId.Count() > 0)
                roleid = string.Join(",", model.RoleId.ToArray());

            if (model.WorkTypeId > 0)
                worktypeid = model.WorkTypeId;

            if (model.LocationId > 0)
                locationid = model.LocationId;

            if (model.AreaId != null && model.AreaId.Count() > 0)
                areaid = string.Join(",", model.AreaId.ToArray());

            //0 means all
            if (areaid == "0")
                areaid = null;
            if (roleid == "0")
                roleid = null;

            //set the automapping
            Mapper.CreateMap<ViewJobSearch, JobModel.Job>();

            EasyFts fts = new EasyFts();
            kw = fts.ToFtsQuery(model.Keyword);

            resultmodel.JobSearchModel = model;

            //model.SalaryFromId
            int? currencyId = null;
            decimal? salaryFrom = null;
            decimal? salaryTo = null;

            if (model.SalaryFromId != null && model.SalaryToId != null)
            {
                string[] valueset = model.SalaryFromId.Split(';');
                if (valueset.Count() > 2)
                {
                    currencyId = Convert.ToInt32(valueset[0]);
                    salaryFrom = Convert.ToDecimal(valueset[1]);
                }
                valueset = model.SalaryToId.Split(';');
                if (valueset.Count() > 2)
                {
                    salaryTo = Convert.ToDecimal(valueset[1]);
                }
            }

            foreach (var result in ViewJobSearchService.GetBySearchFilter(kw, SiteId,
                                                                        null, currencyId,
                                                                        salaryFrom, salaryTo,
                                                                        model.SalaryTypeId, worktypeid,
                                                                        professionid, roleid,
                                                                        null, locationid, areaid, dateFrom,
                                                                        PageNo, Convert.ToInt32(ConfigurationManager.AppSettings[PAGE_SIZE_KEY]), string.Empty, null))
            {
                //URL decode all the bullet points
                result.BulletPoint1 = HttpUtility.HtmlDecode(result.BulletPoint1);
                result.BulletPoint2 = HttpUtility.HtmlDecode(result.BulletPoint2);
                result.BulletPoint3 = HttpUtility.HtmlDecode(result.BulletPoint3);

                resultmodel.JobSearchResults.Add(Mapper.Map<ViewJobSearch, JobModel.Job>(result));
            }

            //this is used to control the paging
            DataSet dsRedefine = ViewJobSearchService.GetBySearchFilterRedefine(kw, SiteId,
                                                                        null, currencyId,
                                                                        salaryFrom, salaryTo,
                                                                        model.SalaryTypeId, worktypeid,
                                                                        professionid, roleid,
                                                                        null, locationid, areaid, dateFrom,
                                                                        SessionData.Language.LanguageId);
            if (dsRedefine.Tables.Count > 0)
            {
                var totaljobs = (from dt in dsRedefine.Tables[0].AsEnumerable()
                                 where dt.Field<int>("RefineTypeID") == (int)PortalEnums.Search.Redefine.Classification
                                 select dt.Field<int>("RefineCount")).Sum();
                resultmodel.TotalRecord = totaljobs;
                resultmodel.TotalPage = GetTotalPage(totaljobs);
            }

            return resultmodel;
        }

        public SavedJobModels SavedJobsForMember(int MemberId, int PageNo)
        {
            SavedJobModels model = new SavedJobModels();

            using (DataSet dataSetJobSaved = JobsSavedService.GetJobNameByMemberID(MemberId, Convert.ToInt32(ConfigurationManager.AppSettings[PAGE_SIZE_KEY]), PageNo + 1))
            {
                foreach (DataRow row in dataSetJobSaved.Tables[0].Rows)
                {
                    model.SavedJobs.Add(new SavedJobModel()
                    {
                        JobID = Convert.ToInt32(row["JobID"]),
                        JobFriendlyName = row["JobFriendlyName"].ToString(),
                        JobName = row["JobName"].ToString(),
                        JobSaveID = Convert.ToInt32(row["JobSaveID"]),
                        LastModified = Convert.ToDateTime(row["LastModified"]),
                        MemberID = Convert.ToInt32(row["MemberID"]),
                        SiteProfessionName = row["SiteProfessionName"].ToString()
                    });
                }
            }

            return model;
        }

        public JobModel.JobAlert JobAlertForMember(int MemberId)
        {
            JobModel.JobAlert jobalertmodel = new JobModel.JobAlert();
            jobalertmodel.JobAlerts = new List<JobModel.JobAlertDetail>();

            //set the automapping
            Mapper.CreateMap<JobAlerts, JobModel.JobAlertDetail>();

            foreach (var result in JobAlertsService.GetByMemberId(MemberId))
            {
                jobalertmodel.JobAlerts.Add(Mapper.Map<JobAlerts, JobModel.JobAlertDetail>(result));
            }

            return jobalertmodel;
        }

        public JobModel.JobAlertDetail JobAlert(int JobAlertID)
        {
            JobModel.JobAlertDetail jobalertmodel = new JobModel.JobAlertDetail();
            //set the automapping
            Mapper.CreateMap<JobAlerts, JobModel.JobAlertDetail>();
            //TODO: can we make sure this jobalertID is the right one for this particular member
            return Mapper.Map<JobAlerts, JobModel.JobAlertDetail>(JobAlertsService.GetByJobAlertId(JobAlertID));
        }

        public bool JobAlertSave(JobModel.JobAlertDetail jobalert)
        {
            JobAlerts jobalertEntity = new JobAlerts();
            bool success = false;

            if (jobalert.JobAlertId > 0)
            {
                jobalertEntity = JobAlertsService.GetByJobAlertId(jobalert.JobAlertId);
            }
            jobalertEntity.JobAlertName = jobalert.JobAlertName;
            jobalertEntity.SearchKeywords = jobalert.SearchKeywords;
            jobalertEntity.ProfessionId = jobalert.ProfessionId.HasValue ? jobalert.ProfessionId.Value.ToString() : string.Empty;
            jobalertEntity.LocationId = jobalert.LocationId.HasValue ? jobalert.LocationId.Value.ToString() : string.Empty;

            if (jobalert.ProfessionId == 0)
                jobalertEntity.ProfessionId = null;

            if (jobalert.SearchRoleIds != null && jobalert.SearchRoleIds.Count() > 0)
                jobalertEntity.SearchRoleIds = jobalert.SearchRoleIds;//string.Join(",", jobalert.SearchRoleIds.ToArray());

            if (jobalert.LocationId == 0)
                jobalertEntity.LocationId = null;

            if (jobalert.AreaIds != null && jobalert.AreaIds.Count() > 0)
                jobalertEntity.AreaIds = jobalert.AreaIds;//string.Join(",", jobalert.AreaIds.ToArray());

            //0 means all
            if (jobalert.AreaIds == "0")
                jobalertEntity.AreaIds = null;

            if (jobalert.SearchRoleIds == "0")
                jobalertEntity.SearchRoleIds = null;

            jobalertEntity.MemberId = SessionData.Member.MemberId;
            jobalertEntity.SiteId = SessionData.Site.SiteId;
            jobalertEntity.AlertActive = true;

            if (jobalert.JobAlertId > 0)
            {
                success = JobAlertsService.Update(jobalertEntity);
            }
            else
            {
                success = JobAlertsService.Insert(jobalertEntity);
            }

            return success;
        }

        private int GetTotalPage(int totalrecord)
        {
            if ((totalrecord % Convert.ToInt32(ConfigurationManager.AppSettings[PAGE_SIZE_KEY])) == 0)
                return (totalrecord / Convert.ToInt32(ConfigurationManager.AppSettings[PAGE_SIZE_KEY]));

            return (totalrecord / Convert.ToInt32(ConfigurationManager.AppSettings[PAGE_SIZE_KEY])) + 1;
        }

        public bool ApplyJob(MemberModel.ApplyJobModel model, string CoverLetterLocation, string ResumeLocation)
        {
            bool success = false;

            using (JobApplication jobApp = new JobApplication())
            {
                jobApp.ApplicationDate = DateTime.Now;
                jobApp.JobId = model.JobId;
                jobApp.MemberId = model.MemberId;

                jobApp.JobAppValidateId = new Guid();
                jobApp.SiteIdReferral = SessionData.Site.SiteId;
                jobApp.UrlReferral = "";
                jobApp.FirstName = model.FirstName;
                jobApp.Surname = model.Surname;
                jobApp.EmailAddress = model.Email;
                jobApp.MobilePhone = model.ContactNo;
                jobApp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                jobApp.Draft = false;

                success = JobApplicationService.Insert(jobApp);

                if (success)
                {
                    if (model.CoverLetterSelection == 1 && model.CoverLetterID > 0)
                    {
                        MemberFiles coverletter = MemberFilesService.GetByMemberFileId(model.CoverLetterID);

                        if (coverletter != null)
                        {
                            string filepath = string.Format("{0}{1}_Coverletter_{2}", CoverLetterLocation, jobApp.JobApplicationId, coverletter.MemberFileName);
                            jobApp.MemberCoverLetterFile = string.Format("{0}_Coverletter_{1}", jobApp.JobApplicationId, coverletter.MemberFileName);

                            Utils.EncryptFile(coverletter.MemberFileContent, filepath);
                        }
                        coverletter = null;
                    }
                    else if (model.CoverLetterSelection == 3 && !string.IsNullOrWhiteSpace(model.CoverLetter))
                    {
                        string filepath = string.Format("{0}{1}_Coverletter.txt", ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"], jobApp.JobApplicationId);
                        byte[] byteArray = Encoding.ASCII.GetBytes(model.CoverLetter);
                        MemoryStream stream = new MemoryStream(byteArray);
                        Utils.EncryptFile(stream, filepath);
                        jobApp.MemberCoverLetterFile = string.Format("{0}_Coverletter.txt", jobApp.JobApplicationId);
                    }


                    if (model.ResumeSelection == 1 && model.ResumeID > 0)
                    {
                        MemberFiles resume = MemberFilesService.GetByMemberFileId(model.ResumeID);

                        if (resume != null)
                        {
                            string filepath = string.Format("{0}{1}_Resume_{2}", CoverLetterLocation, jobApp.JobApplicationId, resume.MemberFileName);
                            jobApp.MemberCoverLetterFile = string.Format("{0}_Resume_{1}", jobApp.JobApplicationId, resume.MemberFileName);

                            Utils.EncryptFile(resume.MemberFileContent, filepath);
                        }
                        resume = null;
                    }
                    else if (model.ResumeSelection == 2 && !string.IsNullOrWhiteSpace(model.Resume))
                    {
                        string filepath = string.Format("{0}{1}_Resume.txt", ConfigurationManager.AppSettings["ApplicationUploadResumePaths"], jobApp.JobApplicationId);
                        byte[] byteArray = Encoding.ASCII.GetBytes(model.Resume);
                        MemoryStream stream = new MemoryStream(byteArray);
                        Utils.EncryptFile(stream, filepath);
                        jobApp.MemberCoverLetterFile = string.Format("{0}_Resume.txt", jobApp.JobApplicationId);
                    }

                    //update with resume and cover letter
                    success = JobApplicationService.Update(jobApp);

                    if (success)
                    {
                         Entities.Jobs job = new JobsService().GetByJobId(jobApp.JobId.Value);

                        Members member = new MembersService().GetByMemberId(model.MemberId);
                        MailService.SendMemberJobApplicationEmail(member);
                        MailService.SendAdvertiserJobApplicationEmail(member, jobApp, ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"],
                                                                        ConfigurationManager.AppSettings["ApplicationUploadResumePaths"], new HybridDictionary(), job.SiteId);
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Send Email to Friend for Mobile website, called from Javascript
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="fromEmail"></param>
        /// <param name="fromName"></param>
        /// <param name="friendName"></param>
        /// <param name="friendEmail"></param>
        /// <param name="message"></param>
        /// <param name="jobUrl"></param>
        /// <returns></returns>
        public void SendMemberJobEmail(string jobName, string yourName, string yourEmail,
                                                int jobID, int siteID)
        {
            JXTPortal.Entities.ViewJobs jobs = ViewJobsService.GetByID(jobID, SessionData.Site.SiteId).FirstOrDefault();

            if (jobs != null)
            {
                string JobUrl = string.Empty;

                JobUrl = Utils.GetJobUrl(jobs.JobId, jobs.JobFriendlyName);

                MailService.SendMemberJobEmail(yourName, yourEmail, jobName, JobUrl, (int)PortalEnums.Email.EmailFormat.HTML, SessionData.Site.DefaultEmailLanguageId);
            }

        }

        #region "Properties

        private JobAlertsService _jobAlertsService;

        private JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                    _jobAlertsService = new JobAlertsService();

                return _jobAlertsService;
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

        private ViewJobSearchService _viewJobSearchService;

        private ViewJobSearchService ViewJobSearchService
        {
            get
            {
                if (_viewJobSearchService == null)
                    _viewJobSearchService = new ViewJobSearchService();
                return _viewJobSearchService;
            }
        }

        private JobsSavedService _jobsSavedService;

        private JobsSavedService JobsSavedService
        {
            get
            {
                if (_jobsSavedService == null)
                    _jobsSavedService = new JobsSavedService();

                return _jobsSavedService;
            }
        }

        private JobApplicationService _jobApplicationService;

        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();

                return _jobApplicationService;
            }
        }

        private MemberFilesService _memberFilesService;

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberFilesService == null)
                    _memberFilesService = new MemberFilesService();

                return _memberFilesService;
            }
        }

        private GlobalSettingsService _globalSettingsService;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                    _globalSettingsService = new GlobalSettingsService();

                return _globalSettingsService;
            }
        }

        private SitesService _sitesService;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                    _sitesService = new SitesService();

                return _sitesService;
            }
        }
        #endregion
    }
}
