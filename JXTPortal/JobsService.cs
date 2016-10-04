

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Linq;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Common;
using System.Web;

#endregion

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'Jobs' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class JobsService : JobsServiceBase
    {
        private SiteLanguagesService _sitelanguagesservice;
        private SiteWorkTypeService _siteworktypeservice;
        private SiteAreaService _siteareaservice;
        private SiteLocationService _sitelocationservice;
        private SiteRolesService _siterolesservice;
        private SiteProfessionService _siteprofessionsservice;

        private JobAreaService _jobareaservice;
        private JobRolesService _jobrolesservice;
        private JobItemsTypeService _jobitemstypeservice;

        private ProfessionService _professionservice;
        private LocationService _locationservice;
        private RolesService _rolesservice;
        private AreaService _areaservice;

        private InvoiceItemService _invoiceitemservice;
        private GlobalSettingsService _globalsettingservice;
        private AdvertisersService _advertisersservice;

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

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionsservice == null)
                {
                    _siteprofessionsservice = new SiteProfessionService();
                }
                return _siteprofessionsservice;
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

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobrolesservice == null)
                {
                    _jobrolesservice = new JobRolesService();
                }
                return _jobrolesservice;
            }
        }

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionservice == null)
                {
                    _professionservice = new ProfessionService();
                }
                return _professionservice;
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

        private RolesService RolesService
        {
            get
            {
                if (_rolesservice == null)
                {
                    _rolesservice = new RolesService();
                }
                return _rolesservice;
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

        private InvoiceItemService InvoiceItemService
        {
            get
            {
                if (_invoiceitemservice == null)
                {
                    _invoiceitemservice = new InvoiceItemService();
                }
                return _invoiceitemservice;
            }
        }

        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobitemstypeservice == null)
                {
                    _jobitemstypeservice = new JobItemsTypeService();
                }
                return _jobitemstypeservice;
            }
        }

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingservice == null)
                {
                    _globalsettingservice = new GlobalSettingsService();
                }
                return _globalsettingservice;
            }
        }

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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the JobsService class.
        /// </summary>
        public JobsService()
            : base()
        {
        }
        #endregion Constructors

        public string GetJobUrl(string strProfessionName, string strJobTitle, int jobid)
        {

            return String.Format("/{0}-jobs/{1}/{2}", strProfessionName, strJobTitle, jobid);
            //return String.Format("/{0}-jobs/{1}/{2}", UrlFriendlyName(strProfessionName), UrlFriendlyName(strJobTitle), jobid);            
        }

        /// <summary>
        /// Return if the Advertiser can access this job
        /// </summary>
        /// <param name="jobID">Job ID</param>
        /// <param name="jobArchiveID">Archive ID</param>
        /// <returns></returns>
        public bool isAdvertiserJob(int? jobID, int? jobArchiveID)
        {
            if (jobID.HasValue && jobID.Value > 0)
            {
                using (Entities.Jobs job = GetByJobId(jobID.Value))
                {
                    if (job.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                        return true;
                }
            }

            if (jobArchiveID.HasValue && jobArchiveID.Value > 0)
            {
                JobsArchiveService jobsArchiveService = new JobsArchiveService();

                using (Entities.JobsArchive jobArchive = jobsArchiveService.GetByJobId(jobArchiveID.Value))
                {
                    if (jobArchive.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                        return true;
                }
            }

            return false;
        }

        public override bool Insert(Jobs entity)
        {
            bool valid = base.Insert(entity);

            //if (valid && entity.Billed)
            //{
            //    base.CustomCalculateJobCount(entity.SiteId, entity.JobId, true);
            //    JobX_SubmitQueue(entity.JobId);
            //}

            return valid;
        }

        public override bool Update(Jobs entity)
        {
            string message = string.Empty;

            return Update(entity, out message);
        }

        public bool Update(Jobs entity, out string message)
        {
            entity = SearchIndex(entity);
            message = string.Empty;

            foreach (SiteLanguages sl in SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                foreach (JobRoles jr in JobRolesService.GetByJobId(entity.JobId))
                {
                    TList<Roles> roles = RolesService.GetByRoleId(jr.RoleId);
                    if (roles.Count > 0)
                    {
                        Roles role = roles[0];

                        Profession profession = ProfessionService.GetByProfessionId(role.ProfessionId);

                        if (profession != null)
                        {
                            entity.SearchField += " " + Utils.SpecialCharsSearchField(SiteRolesService.GetTranslatedRolesById(jr.RoleId.Value, profession.ProfessionId, sl.LanguageId, SessionData.Site.UseCustomProfessionRole).SiteRoleName);
                            entity.SearchField += " " + Utils.SpecialCharsSearchField(SiteProfessionService.GetTranslatedProfessionById(profession.ProfessionId, SessionData.Site.UseCustomProfessionRole).SiteProfessionName);
                        }

                    }
                }

                foreach (JobArea ja in JobAreaService.GetByJobId(entity.JobId))
                {
                    Area area = AreaService.GetByAreaId(ja.AreaId);
                    if (area != null)
                    {
                        Location location = LocationService.GetByLocationId(area.LocationId);

                        if (location != null)
                        {
                            entity.SearchField += " " + Utils.SpecialCharsSearchField(SiteAreaService.GetTranslatedArea(ja.AreaId, location.LocationId, SessionData.Site.SiteId).SiteAreaName);
                            entity.SearchField += " " + Utils.SpecialCharsSearchField(SiteLocationService.GetTranslatedLocation(location.LocationId, location.CountryId).SiteLocationName);
                        }

                    }
                }

                entity.SearchField += " " + Utils.SpecialCharsSearchField(SiteWorkTypeService.GetTranslatedWorkTypesById(entity.WorkTypeId, sl.LanguageId).SiteWorkTypeName);
            }

            int expired = entity.GetOriginalEntity().Expired.Value;
            bool billed = entity.GetOriginalEntity().Billed;
            int originalexpired = entity.GetOriginalEntity().Expired.Value;
            var valid = base.Update(entity);

            PortalEnums.Advertiser.AccountType acctype = PortalEnums.Advertiser.AccountType.Credit_Card;
            Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(entity.AdvertiserId.Value);
            if (advertiser != null)
            {
                acctype = (PortalEnums.Advertiser.AccountType)advertiser.AdvertiserAccountTypeId;
            }

            if (valid)
            {
                // When expired then calculate the job count.
                if (entity.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired)
                {
                    base.CustomCalculateJobCount(entity.SiteId, entity.JobId, false);

                    // Archive job
                    JobArchive(entity.JobId);
                }
                else
                {
                    if (entity.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Live)
                    {
                        // Pay for the Job if it is job board
                        if (SessionData.Site.IsJobBoard)
                        {
                            if (acctype == PortalEnums.Advertiser.AccountType.Credit_Card)
                            {
                                DataSet dsresult = InvoiceItemService.CustomPayJob(entity.JobId);
                                string msg = dsresult.Tables[0].Rows[0][0].ToString();
                                valid = (msg == "Success" || msg == "Job Exists");
                                if (!valid)
                                {
                                    // Failed to pay and rollback to original status
                                    entity.Expired = originalexpired;
                                    message = "Advertiser does not have credit";
                                    base.Update(entity);
                                    return valid;
                                }
                            }
                            else
                            {
                                using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
                                {
                                    TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                                    jobitemtypes.Filter = string.Format("JobItemTypeParentId = {0} AND TotalNumberOfJobs = 1", entity.JobItemTypeId);
                                    if (jobitemtypes.Count > 0)
                                    {
                                        InvoiceItemService.CustomJobBoardAccountPostJob(entity.JobId, entity.EnteredByAdvertiserUserId, jobitemtypes[0].JobItemTypeParentId, GlobalSettings.Gst, GlobalSettings.CurrencyId, null, null);
                                        return true;
                                    }
                                    else
                                    {
                                        message = "Job Item Type Missing";
                                        return false;
                                    }
                                }
                            }
                        }

                        base.CustomCalculateJobCount(entity.SiteId, entity.JobId, true);
                        // Job needs to be live to submit to the queue.
                        JobX_SubmitQueue(entity.JobId);
                    }
                }

                // Job needs to be live to submit to the queue.
                /*if (entity.Billed)
                {
                    JobX_SubmitQueue(entity.JobId);
                }*/
            }

            return valid;
        }

        public override void JobX_SubmitQueue(int? jobId)
        {
            try
            {
                base.JobX_SubmitQueue(jobId);
            }
            catch (Exception ex)
            {
                //log exception in the database
            }
        }

        /// <summary>
        /// Update the SearchField of the Job
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private Jobs SearchIndex(Jobs entity)
        {
            try
            {

                ViewJobsService ViewJobsService = new ViewJobsService();
                using (VList<ViewJobs> viewJobs = ViewJobsService.GetByID(entity.JobId, SessionData.Site.SiteId))
                {

                    if (viewJobs != null && viewJobs.Count > 0)
                    {
                        ViewJobs jobs = viewJobs[0];

                        String strSearchField = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                                            jobs.JobId,
                                                            Utils.SpecialCharsSearchField(entity.JobName),
                                                            Utils.SpecialCharsSearchField(entity.FullDescription),
                                                            Utils.SpecialCharsSearchField(entity.CompanyName),
                                                            entity.RefNo,
                                                            entity.SalaryText,
                                                            entity.PublicTransport,
                                                            entity.Address,
                                                           Utils.SpecialCharsSearchField(entity.ContactDetails),
                                                            Utils.SpecialCharsSearchField(entity.BulletPoint1),
                                                            Utils.SpecialCharsSearchField(entity.BulletPoint2),
                                                            Utils.SpecialCharsSearchField(entity.BulletPoint3),

                                                            entity.Tags,
                                                            Utils.SpecialCharsSearchField(entity.Description),
                                                            entity.ApplicationEmailAddress);

                        // Strip HTML and Remove multiple Spaces
                        entity.SearchField = Utils.CleanStringSpaces(Utils.StripHTML(strSearchField));

                        // Decode the &amp; &lt; etc
                        entity.SearchField = HttpUtility.HtmlDecode(entity.SearchField);

                    }
                    else
                        entity.SearchField = string.Empty;
                }
            }
            catch
            {
                entity.SearchField = string.Empty;
            }


            return entity;
        }

        public string GetRSSFeedUrl(int? professionID, int? roleID, int? locationID, int? areaID, int? countryID)
        {
            System.Text.StringBuilder strRSS = new System.Text.StringBuilder();
            strRSS.Append("/job/rss.aspx?search=1");

            if (!String.IsNullOrEmpty(SessionData.JobSearch.Keywords))
            {
                strRSS.Append("&keywords=");
                strRSS.Append(HttpUtility.UrlEncode(SessionData.JobSearch.Keywords));
            }

            if (!String.IsNullOrEmpty(SessionData.JobSearch.ProfessionID))
            {
                strRSS.Append("&professionid=");
                strRSS.Append(SessionData.JobSearch.ProfessionID);
            }
            else if (roleID.HasValue)
            {
                strRSS.Append("&professionid=");
                strRSS.Append(HttpUtility.UrlEncode(professionID.Value.ToString()));
            }

            if (!String.IsNullOrEmpty(SessionData.JobSearch.RoleIDs))
            {
                strRSS.Append("&roleids=");
                strRSS.Append(HttpUtility.UrlEncode(SessionData.JobSearch.RoleIDs));
            }
            else if (roleID.HasValue)
            {
                strRSS.Append("&roleids=");
                strRSS.Append(HttpUtility.UrlEncode(roleID.Value.ToString()));
            }

            if (SessionData.JobSearch.CountryID.HasValue)
            {
                strRSS.Append("&countryid=");
                strRSS.Append(SessionData.JobSearch.CountryID);
            }
            else if (countryID.HasValue)
            {
                strRSS.Append("&countryid=");
                strRSS.Append(HttpUtility.UrlEncode(countryID.Value.ToString()));
            }

            if (!String.IsNullOrEmpty(SessionData.JobSearch.LocationID))
            {
                strRSS.Append("&locationid=");
                strRSS.Append(SessionData.JobSearch.LocationID);
            }
            else if (locationID.HasValue)
            {
                strRSS.Append("&locationid=");
                strRSS.Append(HttpUtility.UrlEncode(locationID.Value.ToString()));
            }

            if (!String.IsNullOrEmpty(SessionData.JobSearch.AreaIDs))
            {
                strRSS.Append("&areaids=");
                strRSS.Append(HttpUtility.UrlEncode(SessionData.JobSearch.AreaIDs));
            }
            else if (areaID.HasValue)
            {
                strRSS.Append("&areaids=");
                strRSS.Append(HttpUtility.UrlEncode(areaID.Value.ToString()));
            }

            if (SessionData.JobSearch.CurrencyID.HasValue)
            {
                strRSS.Append("&currencyid=");
                strRSS.Append(SessionData.JobSearch.CurrencyID);
            }

            if (SessionData.JobSearch.SalaryLowerBand.HasValue)
            {
                strRSS.Append("&salarylowerband=");
                strRSS.Append(SessionData.JobSearch.SalaryLowerBand);
            }


            if (SessionData.JobSearch.SalaryUpperBand.HasValue)
            {
                strRSS.Append("&salaryupperband=");
                strRSS.Append(SessionData.JobSearch.SalaryUpperBand);
            }
            if (SessionData.JobSearch.WorkTypeID.HasValue)
            {
                strRSS.Append("&worktypeid=");
                strRSS.Append(SessionData.JobSearch.WorkTypeID);
            }
            if (SessionData.JobSearch.AdvertiserID.HasValue && SessionData.JobSearch.AdvertiserID.Value > 0)
            {
                strRSS.Append("&advertiserid=");
                strRSS.Append(SessionData.JobSearch.AdvertiserID);
            }

            return strRSS.ToString();
        }

        public bool JobGetByExternalID(int siteID, int advertiserID, string externalID, out int? jobID, out int? archivedJobID)
        {
            DataSet externalJobDS = CustomGetJobByExternalJobId(siteID, advertiserID, externalID);

            if (externalJobDS.Tables[0].Rows.Count > 0)
            {
                DataRow thisRow = externalJobDS.Tables[0].Rows[0];

                bool resultHasJobId = ((int)thisRow["JobId"]) != 0;
                bool resultHasJobArchiveId = ((int)thisRow["JobArchiveId"]) != 0;

                if (resultHasJobId)
                {
                    //int? expired = (int)thisRow["Expired"];
                    //DateTime expiryDate = (DateTime)thisRow["ExpiryDate"];
                    //if ((expired.HasValue && expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || expiryDate < DateTime.Now)
                    //{
                    //    jobID = null;
                    //    archivedJobID = null;
                    //    return false;
                    //}

                    jobID = (int?)thisRow["JobId"];
                    archivedJobID = null;
                    return true;
                }
                else if (resultHasJobArchiveId)
                {
                    jobID = null;
                    archivedJobID = (int?)thisRow["JobArchiveId"];
                    return true;
                }
            }

            jobID = null;
            archivedJobID = null;
            return false;
        }

        public bool CreateNewBullhornJob(int siteID, int advertiserID, string title, string description, string BHJobID, bool isPublic)
        {

            Jobs newJob = new Jobs
            {
                SiteId = siteID,
                AdvertiserId = advertiserID,
                JobName = title,
                FullDescription = description,
                JobExternalId = BHJobID,
                
            };

            base.Insert(newJob);
            return true;

        }




    }//End Class

} // end namespace
