using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Website.job.ajaxcalls;
using JXTPortal.Entities;
using System.Text;
using System.Data;
using AjaxControlToolkit;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using BullhornPartnerApi;
using JXTPortal.Entities.Models;
using JXTPortal.Client.Bullhorn;
using System.IO;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;
using System.Configuration;

namespace JXTPortal.Website.job
{
    public partial class BullhornIntegration : System.Web.UI.Page
    {

        #region Declarations

        private GlobalSettingsService _globalSettingsService;
        private AdvertiserJobTemplateLogoService _advertiserJobTemplateLogo;
        private SiteWorkTypeService _siteWorkTypeService;
        private AdvertisersService _advertisersservice;
        private AdvertiserUsersService _advertiserusersservice;
        private AdminUsersService _adminusersservice;
        private JobItemsTypeService _jobitemstypeservice;
        private JobTemplatesService _jobtemplatesservice;
        private JobsService _jobsservice;
        private JobsArchiveService _jobsarchiveservice;
        private SiteSalaryTypeService _sitesalarytypeservice;
        private ViewSalaryService _viewsalaryservice = null;
        private IntegrationsService _integrationsService;

        private SiteCountriesService _siteCountriesService;
        private SiteLocationService _siteLocationService;
        private SiteAreaService _siteAreaService;
        private SiteProfessionService _siteProfessionService;
        private SiteRolesService _siteRolesService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;
        private AreaService _areaService;
        private LocationService _locationService;
        private RolesService _rolesService;
        private DynamicPagesService _dynamicPagesService = null;
        private InvoiceService _invoiceService = null;
        private AdvertiserJobPricingService _advertiserJobPricingService = null;

        //ascx variables
        public bool HasAddressInputValue = false;
        public bool HasLatLngInputValues = false;

        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string advertiserJobTemplateLogoFolder;
        #endregion

        #region Properties

        public IFileManager FileManagerService { get; set; }
        private const string ExternalIDPrefix = ""; //Bullhorn

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

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteWorkTypeService == null)
                {
                    _siteWorkTypeService = new SiteWorkTypeService();
                }
                return _siteWorkTypeService;
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

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersservice == null)
                {
                    _advertiserusersservice = new AdvertiserUsersService();
                }
                return _advertiserusersservice;
            }
        }

        private AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminusersservice == null)
                {
                    _adminusersservice = new AdminUsersService();
                }
                return _adminusersservice;
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

        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobtemplatesservice == null)
                {
                    _jobtemplatesservice = new JobTemplatesService();
                }
                return _jobtemplatesservice;
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


        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null)
                    _siteCountriesService = new SiteCountriesService();
                return _siteCountriesService;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                {
                    _siteLocationService = new SiteLocationService();
                }
                return _siteLocationService;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteAreaService == null)
                    _siteAreaService = new SiteAreaService();
                return _siteAreaService;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null)
                    _siteProfessionService = new SiteProfessionService();
                return _siteProfessionService;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                    _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobAreaService == null)
                    _jobAreaService = new JobAreaService();
                return _jobAreaService;
            }
        }

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobRolesService == null)
                    _jobRolesService = new JobRolesService();
                return _jobRolesService;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                    _areaService = new AreaService();
                return _areaService;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationService == null)
                    _locationService = new LocationService();
                return _locationService;
            }
        }

        private RolesService RolesService
        {
            get
            {
                if (_rolesService == null)
                    _rolesService = new RolesService();
                return _rolesService;
            }
        }

        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserJobTemplateLogo == null)
                    _advertiserJobTemplateLogo = new AdvertiserJobTemplateLogoService();
                return _advertiserJobTemplateLogo;
            }
        }

        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeservice == null)
                    _sitesalarytypeservice = new SiteSalaryTypeService();
                return _sitesalarytypeservice;
            }

        }

        private ViewSalaryService ViewSalaryService
        {
            get
            {
                if (_viewsalaryservice == null)
                    _viewsalaryservice = new ViewSalaryService();
                return _viewsalaryservice;
            }
        }

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

        private AdvertiserJobPricingService AdvertiserJobPricingService
        {
            get
            {
                if (_advertiserJobPricingService == null)
                {
                    _advertiserJobPricingService = new AdvertiserJobPricingService();
                }
                return _advertiserJobPricingService;
            }
        }

        private InvoiceService InvoiceService
        {
            get
            {
                if (_invoiceService == null)
                {
                    _invoiceService = new InvoiceService();
                }
                return _invoiceService;
            }
        }

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

        private string Req_EntityType
        {
            get { return Request["EntityType"]; }
        }
        private int Req_EntityID
        {
            get { return int.Parse(Request["EntityID"]); }
        }
        private int Req_UserID
        {
            get { return int.Parse(Request["UserID"]); }
        }
        private int Req_CorporationID
        {
            get { return int.Parse(Request["CorporationID"]); }
        }
        private int Req_PrivateLabelID
        {
            get { return int.Parse(Request["PrivateLabelID"]); }
        }
        private string Req_CurrentBullhornUrl
        {
            get { return Request["currentBullhornUrl"]; }
        }

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToLower(); }
        }


        #endregion

        private AdminIntegrations.Bullhorn _bhSettings;
        private AdminIntegrations.Bullhorn BullhornSettings
        {
            get
            {
                if (_bhSettings == null)
                {
                    _bhSettings = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId).Bullhorn;
                }
                return _bhSettings;
            }
        }

        private int? _BullhornSettingsDefaultAdvertiserID;
        private int BullhornSettingsDefaultAdvertiserID
        {
            get
            {
                if (_BullhornSettingsDefaultAdvertiserID == null)
                {
                    if (BullhornSettings.DefaultAdvertiserUserID > 0)
                    {
                        using (Entities.AdvertiserUsers advUser = AdvertiserUsersService.GetByAdvertiserUserId(BullhornSettings.DefaultAdvertiserUserID))
                        {
                            _BullhornSettingsDefaultAdvertiserID = advUser.AdvertiserId;
                        }
                    }
                }
                if (_BullhornSettingsDefaultAdvertiserID.HasValue)
                    return _BullhornSettingsDefaultAdvertiserID.Value;
                else
                    return 0;

            }
        }

        private BullhornRESTAPI _bullhornRESTAPI;
        private BullhornRESTAPI BullhornRESTAPI
        {
            get
            {
                if (_bullhornRESTAPI == null)
                {
                    //// Consumer Key + Secret from SFDC account
                    //string clientKey = BullhornSettings.ClientKey;
                    //string clientSecret = BullhornSettings.ClientSecret;

                    //// Consumer logins
                    //string clientUsername = BullhornSettings.ClientUsername;
                    //string clientPassword = BullhornSettings.ClientPassword;

                    //_bullhornRESTAPI = new BullhornRESTAPI(clientKey, clientSecret, clientUsername, clientPassword, !BullhornSettings.isLive);
                    _bullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                }
                return _bullhornRESTAPI;
            }
        }


        #region Settings

        private int AdvertiserID;
        private int AdvertiserUserID;
        private PortalEnums.Advertiser.AccountType AdvertiserAccountType = PortalEnums.Advertiser.AccountType.Account;


        #endregion

        #region models

        public class ListingClassification
        {
            //[DataMember(Order = 1)]
            public string WorkType { get; set; }

            //[DataMember(Order = 2)]
            public string Sector { get; set; }

            //[DataMember(Order = 3)]
            public string StreetAddress { get; set; }

            //[DataMember(Order = 4)]
            public string Tags { get; set; }

            //[DataMember(Order = 5)]
            public string Country { get; set; }

            //[DataMember(Order = 6)]
            public string Location { get; set; }

            //[DataMember(Order = 7)]
            public string Area { get; set; }
        }

        public class Salary
        {
            //[DataMember(Order = 1)]
            [XmlElement(IsNullable = true)]
            public string SalaryType { get; set; }

            //[DataMember(Order = 2)]
            [XmlElement(IsNullable = true)]
            public string Min { get; set; }

            //[DataMember(Order = 3)]
            [XmlElement(IsNullable = true)]
            public string Max { get; set; }

            //[DataMember(Order = 4)]
            [XmlElement(IsNullable = true)]
            public string AdditionalText { get; set; }

            //[DataMember(Order = 5)]
            [XmlElement(IsNullable = true)]
            public bool? ShowSalaryDetails { get; set; }
        }

        public class Category
        {
            //[DataMember(Order = 1)]
            [XmlElement(IsNullable = true)]
            public string Classification { get; set; }

            //[DataMember(Order = 2)]
            [XmlElement(IsNullable = true)]
            public string SubClassification { get; set; }
        }

        public class ApplicationMethod
        {

            //[DataMember(Order = 1)]
            [XmlElement(IsNullable = true)]
            public string JobApplicationType { get; set; }

            //[DataMember(Order = 2)]
            [XmlElement(IsNullable = true)]
            public string ApplicationUrl { get; set; }

            //[DataMember(Order = 3)]
            [XmlElement(IsNullable = true)]
            public string ApplicationEmail { get; set; }
        }

        public class BullhornCustomJobDetails
        {
            public string JobAdType { get; set; } //Job Item Type
            public ListingClassification ListingClassification { get; set; }
            public Salary Salary { get; set; }
            public List<Category> Categories { get; set; }
            public string JobTemplateID { get; set; }
            public ApplicationMethod ApplicationMethod { get; set; }
        }
        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionData.Site.IsUsingS3)
            {
                advertiserJobTemplateLogoFolder = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"]);

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                advertiserJobTemplateLogoFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3AdvertiserJobTemplateLogoFolder"];
            }

            revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];

            cal_tbStartDate.Format = SessionData.Site.DateFormat;
            //Everytime starts of this page, we get the advertiser details from integration settings
            AdvertiserID = BullhornSettingsDefaultAdvertiserID;
            AdvertiserUserID = BullhornSettings.DefaultAdvertiserUserID;
            AdvertiserAccountType = PortalEnums.Advertiser.AccountType.Account; //always account type

            if (Request["code"] != null || Request["error"] != null || Request["error_description"] != null)
            {
                if (Request["error"] != null || Request["error_description"] != null)
                {
                    DisplayPageLoadError(Request["error"] + " - " + Request["error_description"]);
                    return;
                }
                else
                {
                    string errorMsg;
                    bool newAuthSuccess = ProcessBullhornRedirect(out errorMsg);

                    if (newAuthSuccess)
                    {
                        string redirectBackToJobURL = Session["BHSessionData"].ToString();
                        Session.Remove("BHSessionData");

                        Response.Redirect(redirectBackToJobURL, true);
                    }
                    else
                    {
                        DisplayPageLoadError("Failed to authorize with Bullhorn.");
                        return;
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                //set to ViewState for future use
                string rawURL = string.Format("{0}://{1}{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.RawUrl);

                ViewState["RequestURL"] = rawURL;

                NonPostBackPageLoad();
            }
            else
            {
                ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "SetSalaryProps", "$(document).ready(function() { SalaryChange(); $('#txtSalaryLowerBand, #txtSalaryUpperBand').keyup(function () {this.value = this.value.replace(/[^0-9\\.]/g, '');});$('#txtSalaryLowerBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));$('#txtSalaryUpperBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));$('#ddlSalary').change(function () {SalaryChange();$('#txtSalaryLowerBand').focus();}); });", true);
            }

        }


        #endregion

        #region Methods

        private void DisplayPageLoadError(string errorMessage)
        {
            formJobFields.Visible = false;
            phInvalidAccountTypeMessage.Visible = true;
            ErrorMessage.Text = errorMessage;
        }

        private void NonPostBackPageLoad()
        {
            //reset
            phInvalidAccountTypeMessage.Visible = false;
            phInvalidAccountTypeMessage.Visible = false;
            formJobFields.Visible = false;
            InsertButton.Visible = false;
            UpdateButton.Visible = false;

            //check integrations settings
            if (BullhornSettings == null || !BullhornSettings.HasFilledAllCredentials())
            {
                DisplayPageLoadError("Bullhorn integrations credentials has not been filled.");
                return;
            }

            //validate url of the iframe being passed in using Bullhorn's Soap API
            bool urlSessionValid = BullhornValidateURL();

            if (!urlSessionValid)
            {
                DisplayPageLoadError("Invalid URL session");
                return;
            }
            else if (AdvertiserAccountType != PortalEnums.Advertiser.AccountType.Account)
            {
                DisplayPageLoadError("Invalid account type");
                return;
            }
            else if (!AdvertiserUserAccountValid())
            {
                DisplayPageLoadError("Invalid advertiser user account");
                return;
            }
            else
            {
                phInvalidAccountTypeMessage.Visible = false;
                formJobFields.Visible = true;

                string errorMsg = null;
                int bh_entityID = int.Parse(Request["EntityID"]);
                int bh_userID = int.Parse(Request["UserID"]);
                int bh_corporationID = int.Parse(Request["CorporationID"]);
                int bh_privateLabelID = int.Parse(Request["PrivateLabelID"]);

                int? JXTjobID, JXTarchivedJobID;
                //get job from JXT
                bool hasJobReturned = JobsService.JobGetByExternalID(SessionData.Site.SiteId, BullhornSettingsDefaultAdvertiserID, ExternalIDPrefix + bh_entityID, out JXTjobID, out JXTarchivedJobID);

                BullhornRESTAPI.BHJobOrderRecord bhRecord;
                bool recordGetSuccess = BullhornJobRecordGet(bh_entityID, out bhRecord, out errorMsg);

                if (recordGetSuccess)
                {
                    //Load GoogleMap JS
                    #region Google Map Setup
                    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

                    if (integrations != null && integrations.GoogleMap != null)
                    {
                        //only assign anything to the geocode and address status if there is a server key in the integrations of the site
                        if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                        {
                            //set js
                            ltGoogleMapJSHeader.Text = @"<script type=""text/javascript"" src=""//maps.google.com/maps/api/js?key=" + integrations.GoogleMap.ServerKey + @"&sensor=false&v=3.exp&signed_in=true&libraries=places""></script>";
                        }
                    }
                    #endregion

                    // Conditions
                    //=================================
                    //2a. If found on JXT - 
                    //    2aa. If BH job record status is live (BH: isPublic = true), 
                    //          - JXT Record status is expired, Update BH isPublic to false, Update JXT From Tab Frame, display record
                    //          - JXT Record NOT expired (expired flag and expiry date), leave the expiry flags untouched, Update BH record with details on the JXT TAB, Update JXT record with details on JXT TAB, display record
                    //    2ab. If BH job record status is expired (BH: isPublic = false), Archive the job if not already, display archived (partial info display), no change allowed
                    //2b. If NOT found on JXT - display form with the details from BH      

                    bool jobIsEditable = true;
                    bool foundInJXT = hasJobReturned;

                    if (foundInJXT)
                    {
                        //if found in JXT Jobs table
                        if (JXTjobID != null)
                        {
                            //get JXT job
                            Entities.Jobs thisJob = JobsService.GetByJobId(JXTjobID.Value);

                            //bh job record shows isPublic == true (ie LIVE)
                            if (bhRecord.IsPublic_Boolean)
                            {
                                //JXT job expired
                                if ((thisJob.Expired.HasValue && thisJob.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || thisJob.ExpiryDate < DateTime.Now)
                                {
                                    //Update BH isPublic to false, Update JXT, display record
                                    bool updateBHStatusSuccess = BullhornJobStatusUpdate(bhRecord.JobOrderID, true);
                                    jobIsEditable = false;
                                }
                                else // JXT job NOT expired
                                {
                                    //leave the expiry flags untouched display record
                                }
                            }
                            else //BH record shows isPublic == false 
                            {
                                //only change JXT record to expired IF the JXT job is live
                                if (thisJob.Expired.HasValue && thisJob.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Live)
                                {
                                    UpdateJobStatusToExpiredToJXT(JXTjobID.Value);

                                    //because updating a job status from live to expired will trigger auto move from Jobs table to JobsArchived table
                                    //we need to update the changes
                                    JXTarchivedJobID = JXTjobID;
                                    JXTjobID = null;
                                }
                            }
                        }
                        else if (JXTarchivedJobID != null)
                        {
                            //found in JXT jobs archived table
                            bool updateBHStatusSuccess = BullhornJobStatusUpdate(bhRecord.JobOrderID, true);
                            jobIsEditable = false;
                        }
                    }
                    else
                    {
                        //update details to form
                        txtJobName.Text = CommonService.DecodeString(bhRecord.title);
                        txtFullDescription.Text = bhRecord.description;
                    }

                    //finally hide/show the insert/update buttons
                    if (!hasJobReturned)
                    {
                        InsertButton.Visible = true;
                        phPostedDates.Visible = false;
                        phPostedBy.Visible = false;
                        phlastmodifiedByAdvuserID.Visible = false;
                        ltJobLiveMessage.Visible = false;
                    }
                    else if (hasJobReturned && jobIsEditable)
                    {
                        UpdateButton.Visible = true;
                        phPostedDates.Visible = true;
                        ltJobLiveMessage.Visible = true;
                    }

                }
                else
                {
                    //failed to retreive record from BH
                    DisplayPageLoadError(errorMsg);
                }


                //Load the job details and display accordingly
                LoadForm();
                SetFormValues();

                if (hasJobReturned)
                {
                    //reget job details to ensure the latest copy
                    if (JXTjobID != null)
                    {
                        Entities.Jobs thisJob = JobsService.GetByJobId(JXTjobID.Value);
                        //JXT job expired
                        if ((thisJob.Expired.HasValue && thisJob.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || thisJob.ExpiryDate < DateTime.Now)
                        {
                            LoadExpiredJob(thisJob, null);
                        }
                        else // JXT job NOT expired
                        {
                            LoadJob(thisJob);
                        }
                    }
                    else if (JXTarchivedJobID != null)
                    {
                        Entities.JobsArchive thisJob = JobsArchiveService.GetByJobId(JXTarchivedJobID.Value);
                        LoadExpiredJob(null, thisJob);
                    }
                }
                else
                {
                    //load empty form

                    // For new jobs set the Application email address from the Advertiser User.
                    using (Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(BullhornSettings.DefaultAdvertiserUserID))
                    {
                        if (advertiseruser != null)
                        {
                            txtApplicationEmailAddress.Text = advertiseruser.ApplicationEmailAddress;
                        }
                    }

                    //set expiry date value to 30 days from today
                    tbExpiryDate.Text = String.Format("{0:" + SessionData.Site.DateFormat + "}", DateTime.Now.AddDays(30));
                }

            }
        }

        private bool AdvertiserUserAccountValid()
        {
            using (Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(BullhornSettings.DefaultAdvertiserUserID))
            {
                if (advertiseruser == null)
                    return false;

                using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advertiseruser.AdvertiserId))
                {
                    if (advertiser.SiteId != SessionData.Site.SiteId)
                        return false;
                }

                if (advertiseruser.Validated == true && (advertiseruser.AccountStatus.HasValue && advertiseruser.AccountStatus == (int)PortalEnums.Advertiser.AccountStatus.Approved))
                {
                    // if locked and attempted within 1 hour - tell user their account has been locked - return
                    if (advertiseruser.Status == (int)PortalEnums.Admin.UserStatus.Locked || advertiseruser.Status == (int)PortalEnums.Admin.UserStatus.Closed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool BullhornJobRecordGet(int BHJobID, out BullhornRESTAPI.BHJobOrderRecord bhRecord, out string errorMsg)
        {
            if (BullhornSettings == null
                || string.IsNullOrEmpty(BullhornSettings.ClientKey)
                || string.IsNullOrEmpty(BullhornSettings.ClientSecret)
                || string.IsNullOrEmpty(BullhornSettings.ClientUsername)
                || string.IsNullOrEmpty(BullhornSettings.ClientPassword)
                )
            {
                errorMsg = "Incomplete Bullhorn settings: Client Key, Client Secret, Login Username and Login Password is required";
                bhRecord = null;
                return false;
            }

            BullhornRESTAPI.BHRestToken restToken = null;
            bool tokenGetSuccess = BullhornRestTokenGet(out restToken, out errorMsg);

            if (!tokenGetSuccess)
            {
                bhRecord = null;
                return false;
            }

            //now continue to core api class with the REST Token
            if (restToken != null)
            {
                try
                {
                    bhRecord = BullhornRESTAPI.BHJobGetByID(BHJobID, restToken);
                    errorMsg = null;
                    return true;
                }
                catch (Exception e)
                {
                    bhRecord = null;
                    errorMsg = "Failed to retreive record. Contact JXT to refresh the Bullhorn token.";
                    return false;
                }
            }

            errorMsg = "Failed to login to BullHorn.";
            bhRecord = null;
            return false;
        }

        private bool BullhornJobStatusUpdate(int BHJobID, bool isExpired)
        {
            var jsonObj = new { isPublic = isExpired ? 0 : 1 };

            BullhornRESTAPI.BHRestToken restToken = null;
            string errorMsg2 = null;
            bool tokenGetSuccess = BullhornRestTokenGet(out restToken, out errorMsg2);
            return BullhornRESTAPI.BHJobUpdateByID(BHJobID, jsonObj, restToken);
        }

        private bool BullhornRestTokenGet(out BullhornRESTAPI.BHRestToken RESTToken, out string errorMsg)
        {
            bool apiLoginSuccess = BullhornRESTAPI.BullHornAPILogin(BullhornSettings.RESTAuthToken, out RESTToken);

            if (!apiLoginSuccess)
            {
                //try refresh token
                BullhornRESTAPI.AuthorizeToken newAuthToken;
                bool refreshTokenSuccess = BullhornRESTAPI.BullhornTokenRefresh(BullhornSettings.RESTAuthRefreshToken, out newAuthToken);

                if (refreshTokenSuccess)
                {
                    IntegrationsService.BullhornRESTTokenUpdate(SessionData.Site.SiteId, newAuthToken.access_token, newAuthToken.refresh_token);

                    //reset variable
                    _bhSettings = null;

                    apiLoginSuccess = BullhornRESTAPI.BullHornAPILogin(newAuthToken.access_token, out RESTToken);

                    if (!apiLoginSuccess) //login with new credentials failed again
                    {
                        errorMsg = "Failed to login using auth access token.";
                        RESTToken = null;
                        return false;
                    }
                }
                else
                {
                    if (Session["BHSessionData"] == null)
                    {
                        Session["BHSessionData"] = Request.Url;
                        //sends to authorize again
                        string authorizeRedirectURL = BullhornTokenResetURLGet();

                        Response.Redirect(authorizeRedirectURL, true);
                    }

                    //if it falls here, it means we tried to re-authorize already, but failed again
                    //clean up and throw error 
                    Session.Remove("BHSessionData");

                    errorMsg = "Failed to re-authorize for API token.";
                    RESTToken = null;
                    return false;
                }
            }

            errorMsg = null;
            return true;
        }

        private bool ProcessBullhornRedirect(out string errorMsg)
        {
            string bhCode = Request["code"];
            string bhError = Request["error"];
            string bhErrorDesc = Request["error_description"];

            if (string.IsNullOrEmpty(bhCode))
            {
                errorMsg = "Authentication failed. No authorization code detected.";
                return false;
            }

            AdminIntegrations.Bullhorn bullhornSettings = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId).Bullhorn;

            if (bullhornSettings == null
                || string.IsNullOrEmpty(bullhornSettings.ClientKey)
                || string.IsNullOrEmpty(bullhornSettings.ClientSecret)
                || string.IsNullOrEmpty(bullhornSettings.ClientUsername)
                || string.IsNullOrEmpty(bullhornSettings.ClientPassword)
                )
            {
                errorMsg = "Incomplete Bullhorn settings: Client Key, Client Secret, Login Username and Login Password is required";
                return false;
            }

            // Consumer Key + Secret from SFDC account
            string clientKey = bullhornSettings.ClientKey;
            string clientSecret = bullhornSettings.ClientSecret;

            // Consumer logins
            string clientUsername = bullhornSettings.ClientUsername;
            string clientPassword = bullhornSettings.ClientPassword;

            // Redirect URL configured in SFDC account
            HttpRequest currentReq = HttpContext.Current.Request;
            string hostName = currentReq.IsLocal ? currentReq.Url.Authority : currentReq.Url.Host;
            string redirectURL = String.Format("{0}://{1}/{2}", (currentReq.IsSecureConnection ? "https" : "http"), hostName, "job/bullhornintegration.aspx");

            BullhornRESTAPI bhapi = new BullhornRESTAPI(clientKey, clientSecret, redirectURL, clientUsername, clientPassword, !bullhornSettings.isLive);

            string jsonToken = null;
            bool tokenGetSuccess = bhapi.GetTokenWithAuthorizeCode(bhCode, out jsonToken);

            if (tokenGetSuccess == false)
            {
                errorMsg = "Failed to exchange code to token";
                return false;
            }

            JavaScriptSerializer ser = new JavaScriptSerializer();
            JXTPortal.Client.Bullhorn.BullhornRESTAPI.AuthorizeToken thisToken = ser.Deserialize<JXTPortal.Client.Bullhorn.BullhornRESTAPI.AuthorizeToken>(jsonToken);

            bool tokenUpdate = IntegrationsService.BullhornRESTTokenUpdate(SessionData.Site.SiteId, thisToken.access_token, thisToken.refresh_token);

            if (tokenUpdate == false)
            {
                errorMsg = "Failed to update token details";
                return false;
            }

            errorMsg = null;
            return true;
        }

        public string GenerateJsonFromInputFields()
        {
            List<Category> categoryListing = new List<Category>();
            #region Pre-Processes
            categoryListing.Add(new Category { Classification = ddlProfession1.SelectedValue, SubClassification = ddlRole1.SelectedValue });
            if (ddlProfession2.SelectedItem != null)
                categoryListing.Add(new Category { Classification = ddlProfession2.SelectedValue, SubClassification = ddlRole2.SelectedValue });
            if (ddlProfession3.SelectedItem != null)
                categoryListing.Add(new Category { Classification = ddlProfession3.SelectedValue, SubClassification = ddlRole3.SelectedValue });
            #endregion

            BullhornCustomJobDetails job = new BullhornCustomJobDetails
            {
                JobAdType = ddlJobItemType.SelectedValue,
                ListingClassification = new ListingClassification
                {
                    Area = string.Empty,
                    Country = ddlLocation.SelectedValue,
                    Location = ddlArea.SelectedValue,
                    Sector = string.Empty,
                    StreetAddress = string.Empty,
                    Tags = string.Empty,
                    WorkType = ddlWorkType.SelectedValue
                },
                Salary = new Salary
                {
                    AdditionalText = txtSalaryText.Text,
                    Max = txtSalaryUpperBand.Text,
                    Min = txtSalaryLowerBand.Text,
                    SalaryType = ddlSalary.SelectedValue,
                    ShowSalaryDetails = chkShowSalaryDetails.Checked
                },
                Categories = categoryListing,
                JobTemplateID = ddlJobTemplateID.SelectedValue,
                ApplicationMethod = new ApplicationMethod
                {
                    ApplicationEmail = txtApplicationEmailAddress.Text,
                    ApplicationUrl = txtApplicationURL.Text,
                    JobApplicationType = ddlApplicationMethod.SelectedValue
                }
            };
            string json = new JavaScriptSerializer().Serialize(job);
            return json;
        }

        private void AssignAddressGeocodes(JXTPortal.Entities.Jobs jobReferenceObj)
        {
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //defaults
            jobReferenceObj.JobLatitude = null;
            jobReferenceObj.JobLongitude = null;
            jobReferenceObj.AddressStatus = null;

            if (integrations != null && integrations.GoogleMap != null)
            {

                //only assign anything to the geocode and address status if there is a server key in the integrations of the site
                if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                {
                    if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    {
                        jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Invalid;
                    }
                    else
                    {
                        //assign geocodes if any
                        if (hfAddressLat != null && hfAddressLng != null & !string.IsNullOrWhiteSpace(hfAddressLat.Value) && !string.IsNullOrWhiteSpace(hfAddressLng.Value))
                        {
                            double parseLat = 0, parseLng = 0;
                            if (double.TryParse(hfAddressLat.Value, out parseLat) && double.TryParse(hfAddressLng.Value, out parseLng))
                            {
                                jobReferenceObj.JobLatitude = parseLat;
                                jobReferenceObj.JobLongitude = parseLng;
                                jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Valid;
                            }
                            else
                            {
                                jobReferenceObj.JobLatitude = null;
                                jobReferenceObj.JobLongitude = null;
                                jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Queued;
                            }
                        }
                        else
                        {
                            jobReferenceObj.JobLatitude = null;
                            jobReferenceObj.JobLongitude = null;
                            jobReferenceObj.AddressStatus = (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Queued;
                        }
                    }
                }
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        private void LoadExpiredJob(Entities.Jobs job, Entities.JobsArchive jobArchive)
        {
            if (jobArchive != null)
            {
                expiredTitle.Text = jobArchive.JobName;
                expiredDatePosted.Text = jobArchive.DatePosted.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)jobArchive.EnteredByAdvertiserUserId))
                {
                    if (advertiserusers != null)
                        expiredPostedBy.Text = CommonService.DecodeString(advertiserusers.UserName);
                    else
                        lblPostedByAdvertiserUser.Text = "";
                }
                expiredLastModified.Text = jobArchive.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                expiredDescription.Text = jobArchive.FullDescription;
                expiredDateExpired.Text = jobArchive.ExpiryDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                expiredChkBoxExpired.Text = jobArchive.Expired == (int)PortalEnums.Jobs.JobStatus.Expired ? "YES" : "NO";

                ExpiredArchivedDisplay.Visible = true;
                pnhScripts.Visible = false;
                formJobFields.Visible = false;
            }
            else
            {
                expiredTitle.Text = job.JobName;
                expiredDatePosted.Text = job.DatePosted.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.EnteredByAdvertiserUserId))
                {
                    if (advertiserusers != null)
                        expiredPostedBy.Text = CommonService.DecodeString(advertiserusers.UserName);
                    else
                        lblPostedByAdvertiserUser.Text = "";
                }
                expiredLastModified.Text = job.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                expiredDescription.Text = job.FullDescription;
                expiredDateExpired.Text = job.ExpiryDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                expiredChkBoxExpired.Text = job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired ? "YES" : "NO";

                ExpiredArchivedDisplay.Visible = true;
                pnhScripts.Visible = false;
                formJobFields.Visible = false;

            }
        }

        private void LoadJob(Entities.Jobs job)
        {
            /*if (SessionData.AdvertiserUser != null)
            {
                txtApplicationEmailAddress.Text = SessionData.AdvertiserUser.ApplicationEmailAddress;
            }*/

            if (job.AdvertiserId != BullhornSettingsDefaultAdvertiserID)
            {
                DisplayPageLoadError("Invalid advertiser user account");
            }

            if (job != null && job.SiteId == SessionData.Site.SiteId)
            {
                JobValidation(job);

                ddlJobItemType.SelectedValue = job.JobItemTypeId.ToString();

                if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                {
                    // phJobStartDate.Visible = true;
                }

                if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                {
                    ddlJobItemType.Enabled = false;

                    // Set Job Type Drop Down to have selected job type only
                    ddlJobItemType.Items.Clear();
                    TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                    jobitemtypes.Filter = string.Format("JobItemTypeParentId = {0} AND TotalNumberOfJobs = 1", job.JobItemTypeId);
                    if (jobitemtypes.Count > 0)
                    {
                        ddlJobItemType.Items.Add(new ListItem(jobitemtypes[0].JobItemTypeDescription, jobitemtypes[0].JobItemTypeParentId.ToString()));
                    }

                    ltJobLiveMessage.Visible = true;
                    plEndFormMessage.Visible = true;
                }

                if (job.Expired != (int)PortalEnums.Jobs.JobStatus.Live || job.Expired != (int)PortalEnums.Jobs.JobStatus.Expired)
                {
                    tbStartDate.Enabled = false;
                    ibStartDate.Enabled = false;
                    rqStartDate.Enabled = false;
                    cvStartDate.Enabled = false;
                }

                //LoadAdvertiserUser((job.EnteredByAdvertiserUserId.HasValue) ? (int)job.EnteredByAdvertiserUserId : 0);
                // Disable Friendly Url

                txtFriendlyUrl.Enabled = false;

                txtApplicationEmailAddress.Text = CommonService.DecodeString(job.ApplicationEmailAddress);
                ddlWorkType.SelectedValue = job.WorkTypeId.ToString();
                //ddlSalary.SelectedValue = job.SalaryId.ToString();
                chkShowSalaryRange.Checked = job.ShowSalaryRange;
                txtJobName.Text = CommonService.DecodeString(job.JobName.ToString());
                txtDescription.Text = CommonService.DecodeString(job.Description.ToString());
                txtFullDescription.Text = job.FullDescription.ToString();
                txtRefNo.Text = CommonService.DecodeString(job.RefNo.ToString());
                //chkVisible.Checked = job.Visible;
                lblDatePosted.Text = job.DatePosted.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                //expiry date display
                lblExpiryDate.Text = job.ExpiryDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                //expiry date changeable by user
                tbExpiryDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", job.ExpiryDate);

                chkJobExpired.Checked = (job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) ? true : false;
                //txtJobItemPrice.Text = (job.JobItemPrice.HasValue) ? job.JobItemPrice.ToString() : string.Empty;
                //chkBilled.Checked = job.Billed;
                lblLastModified.Text = job.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                chkShowSalaryDetails.Checked = job.ShowSalaryDetails;
                txtSalaryText.Text = (!string.IsNullOrEmpty(job.SalaryText)) ? CommonService.DecodeString(job.SalaryText.ToString()) : string.Empty;

                // Set the Friendly Url if it is not Set
                if (!String.IsNullOrEmpty(txtFriendlyUrl.Text.Trim()))
                    txtFriendlyUrl.Text = Common.Utils.UrlFriendlyName(job.JobName);
                else
                    txtFriendlyUrl.Text = job.JobFriendlyName;
                txtCompanyName.Text = CommonService.DecodeString(job.CompanyName);

                //dataAdvertiserId.SelectedValue = job.AdvertiserId.ToString();

                if (job.EnteredByAdvertiserUserId != null)
                {
                    using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.EnteredByAdvertiserUserId))
                    {
                        if (advertiserusers != null)
                            lblPostedByAdvertiserUser.Text = CommonService.DecodeString(advertiserusers.UserName);
                        else
                            lblPostedByAdvertiserUser.Text = "";
                    }
                }
                else
                {
                    lblPostedByAdvertiserUser.Text = "";
                }

                if (job.LastModifiedByAdvertiserUserId != null)
                {
                    using (Entities.AdvertiserUsers advertiserusers = AdvertiserUsersService.GetByAdvertiserUserId((int)job.LastModifiedByAdvertiserUserId))
                    {
                        if (advertiserusers != null)
                            lblLastModifiedByAdvertiserUserId.Text = CommonService.DecodeString(advertiserusers.UserName);
                        else
                            lblLastModifiedByAdvertiserUserId.Text = "";
                    }
                }
                else
                {
                    phlastmodifiedByAdvuserID.Visible = false;
                }


                if (job.JobItemTypeId.HasValue)
                    ddlJobItemType.SelectedValue = job.JobItemTypeId.ToString();

                ddlApplicationMethod.SelectedValue = job.ApplicationMethod.ToString();

                if (Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
                    txtApplicationURL.Enabled = true;
                else
                    txtApplicationURL.Enabled = false;

                if (job.ApplicationUrl != null)
                {
                    txtApplicationURL.Text = CommonService.DecodeString(job.ApplicationUrl.ToString());
                }

                if (!string.IsNullOrEmpty(job.Tags))
                    txtTags.Text = CommonService.DecodeString(job.Tags.ToString());

                ddlSalary.SelectedValue = job.SalaryTypeId.ToString();
                //LoadSalaryFrom(job.SalaryTypeId);
                txtSalaryLowerBand.Text = job.SalaryLowerBand.ToString();
                //LoadSalaryTo(job.SalaryTypeId, job.CurrencyId, job.SalaryLowerBand);
                txtSalaryUpperBand.Text = job.SalaryUpperBand.ToString();

                if (job.JobTemplateId.HasValue)
                {
                    ddlJobTemplateID.SelectedValue = job.JobTemplateId.ToString();
                    imgAdvJobTemplate.ImageUrl = string.Format("/getfile.aspx?jobtemplateid={0}&ver={1}", job.JobTemplateId.ToString(), job.LastModified.ToEpocTimestamp());

                    imgAdvJobTemplate.Attributes.Add("style", "display:block");
                }
                else
                {
                    imgAdvJobTemplate.Attributes.Add("style", "display:none");
                }

                //dataSearchFieldExtension.Text = job.SearchFieldExtension.ToString();
                //dataAdvertiserJobTemplateLogoID.Text = job.AdvertiserJobTemplateLogoId.ToString();
                if (job.AdvertiserJobTemplateLogoId.GetValueOrDefault(0) > 0)
                    ddlAdvertiserJobTemplateLogo.SelectedValue = Convert.ToString(job.AdvertiserJobTemplateLogoId);
                //chkRequireLogonForExternalApplications.Checked = job.RequireLogonForExternalApplications;
                chkShowLocationDetails.Checked = (job.ShowLocationDetails == null) ? false : (bool)job.ShowLocationDetails;
                if (!string.IsNullOrEmpty(job.PublicTransport))
                    txtPublicTransport.Text = CommonService.DecodeString(job.PublicTransport.ToString());
                if (!string.IsNullOrEmpty(job.Address))
                {
                    HasAddressInputValue = true;  //flag for ascx use
                    txtAddress.Text = CommonService.DecodeString(job.Address.ToString());

                    if (job.JobLatitude != null && job.JobLongitude != null)
                    {
                        hfAddressLat.Value = job.JobLatitude.ToString();
                        hfAddressLng.Value = job.JobLongitude.ToString();

                        HasLatLngInputValues = true; //flag for ascx use
                    }
                }
                txtContactDetails.Text = CommonService.DecodeString(job.ContactDetails.ToString());
                if (!string.IsNullOrEmpty(job.JobContactPhone))
                    txtJobContactPhone.Text = CommonService.DecodeString(job.JobContactPhone.ToString());
                if (!string.IsNullOrEmpty(job.JobContactName))
                    txtJobContactName.Text = CommonService.DecodeString(job.JobContactName.ToString());
                chkQualificationsRecognised.Checked = job.QualificationsRecognised;
                chkResidentOnly.Checked = job.ResidentOnly;
                //txtDocumentLink.Text = job.DocumentLink.ToString();
                txtBulletPoint1.Text = (string.IsNullOrEmpty(job.BulletPoint1)) ? "" : CommonService.DecodeString(job.BulletPoint1.ToString());
                txtBulletPoint2.Text = (string.IsNullOrEmpty(job.BulletPoint2)) ? "" : CommonService.DecodeString(job.BulletPoint2.ToString());
                txtBulletPoint3.Text = (string.IsNullOrEmpty(job.BulletPoint3)) ? "" : CommonService.DecodeString(job.BulletPoint3.ToString());
                //chkHotJob.Checked = job.HotJob;
                //isRepostJob = (job.SearchFieldExtension == "Repost");
                foreach (JXTPortal.Entities.JobArea jobArea in JobAreaService.GetByJobId(job.JobId))
                {
                    using (JXTPortal.Entities.Area area = AreaService.GetByAreaId(jobArea.AreaId))
                    {

                        LoadLocation();
                        CommonFunction.SetDropDownByValue(ddlLocation, area.LocationId.ToString());

                        LoadArea();
                        CommonFunction.SetDropDownByValue(ddlArea, jobArea.AreaId.ToString());
                    }
                }

                using (TList<JXTPortal.Entities.JobRoles> jobRoles = JobRolesService.GetByJobId(job.JobId))
                {
                    if (jobRoles.Count > 0 && jobRoles[0] != null)
                    {
                        using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[0].RoleId.Value))
                        {
                            CommonFunction.SetDropDownByValue(ddlProfession1, role.ProfessionId.ToString());
                            LoadRoles(role.ProfessionId, ref ddlRole1);
                            CommonFunction.SetDropDownByValue(ddlRole1, jobRoles[0].RoleId.Value.ToString());
                        }

                    }

                    if (jobRoles.Count > 1 && jobRoles[1] != null && jobRoles[1].RoleId.HasValue)
                    {
                        using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[1].RoleId.Value))
                        {
                            CommonFunction.SetDropDownByValue(ddlProfession2, role.ProfessionId.ToString());
                            LoadRoles(role.ProfessionId, ref ddlRole2);
                            CommonFunction.SetDropDownByValue(ddlRole2, jobRoles[1].RoleId.Value.ToString());
                        }
                    }

                    if (jobRoles.Count > 2 && jobRoles[2] != null && jobRoles[2].RoleId.HasValue)
                    {
                        using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(jobRoles[2].RoleId.Value))
                        {
                            CommonFunction.SetDropDownByValue(ddlProfession3, role.ProfessionId.ToString());
                            LoadRoles(role.ProfessionId, ref ddlRole3);
                            CommonFunction.SetDropDownByValue(ddlRole3, jobRoles[2].RoleId.Value.ToString());
                        }
                    }

                }
            }
            else
            {
                DisplayPageLoadError("Invalid job item request");
            }
        }

        private void JobValidation(Entities.Jobs job)
        {
            // You can't update the expired job.
            //if ((job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || (job.Expired != (int)PortalEnums.Jobs.JobStatus.Draft && job.ExpiryDate < DateTime.Now))
            //{
            //    // Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
            //    Response.Redirect("~/advertiser/default.aspx");
            //}

            // Disable Expired checkbox if draft, pending, declined or suspended
            if (job.Expired.HasValue && (job.Expired == (int)PortalEnums.Jobs.JobStatus.Draft ||
                    job.Expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                    job.Expired == (int)PortalEnums.Jobs.JobStatus.Declined ||
                    job.Expired == (int)PortalEnums.Jobs.JobStatus.Suspended))
                chkJobExpired.Enabled = false;
            else
                chkJobExpired.Enabled = true;


            // When Job is live disable the profession and roles
            if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
            {
                ddlProfession1.Enabled = false;
                ddlProfession2.Enabled = false;
                ddlProfession3.Enabled = false;
                ddlRole1.Enabled = false;
                ddlRole2.Enabled = false;
                ddlRole3.Enabled = false;
            }
            else
            {
                ddlProfession1.Enabled = true;
                ddlProfession2.Enabled = true;
                ddlProfession3.Enabled = true;
                ddlRole1.Enabled = true;
                ddlRole2.Enabled = true;
                ddlRole3.Enabled = true;
            }


            using (TList<Entities.GlobalSettings> gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (gs.Count > 0)
                {
                    // if Site is using Job Screening Process
                    // Check if this job is expired/live/pending/suspended 
                    // then redirect back to advertiser dash board
                    if (gs[0].JobScreeningProcess.HasValue && gs[0].JobScreeningProcess.Value)
                    {
                        // Open if the job is draft
                        if (job.Expired.HasValue && job.Expired == (int)PortalEnums.Jobs.JobStatus.Draft)
                        {
                        }
                        // When the Job is live .. you can only make the Job Expire and can't change it to pending or suspended.
                        else if (job.Expired.HasValue && job.Expired == (int)PortalEnums.Jobs.JobStatus.Live)
                        {
                        }
                    }
                }
            }
        }

        private void UpdateJobStatusToExpiredToJXT(int JobID)
        {
            using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
            {
                job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;

                JobsService.Update(job);
            }
        }

        private void UpdateJobDetailsToJXT(int JobID, out bool jobExpiredFromLiveStatus)
        {
            jobExpiredFromLiveStatus = false;

            using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
            {
                if (job == null || job.SiteId != SessionData.Site.SiteId)
                {
                    //ERROR
                    DisplayPageLoadError("Job record not found at JXT.");
                    return;
                }
                else
                {
                    bool billed = job.Billed;
                    //bool needsUpdateFromDraft = (job.Billed == false && pnlSaveAsDraft.Visible && chkSaveAsDraft.Checked == false);

                    job.JobId = JobID;
                    job.SiteId = SessionData.Site.SiteId;

                    job.WorkTypeId = Convert.ToInt32(ddlWorkType.SelectedValue);

                    job.JobName = CommonService.EncodeString(txtJobName.Text);
                    job.Description = CommonService.EncodeString(txtDescription.Text);
                    job.FullDescription = txtFullDescription.Text;
                    job.RefNo = CommonService.EncodeString(txtRefNo.Text);

                    //job.DatePosted = DateTime.Now;
                    //job.JobItemPrice = (string.IsNullOrEmpty(txtJobItemPrice.Text)) ? (decimal?)null : Convert.ToDecimal(txtJobItemPrice.Text);

                    //string[] salaryFrom = ddlSalaryFrom.SelectedValue.Split(';');
                    //string[] salaryTo = ddlSalaryTo.SelectedValue.Split(';'); ;
                    job.CurrencyId = 1; // Todo - Currency is not used .. and its hardcoded. - Don't remove this - it breaks the advanced search.

                    job.SalaryLowerBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).Value : 0);
                    job.SalaryUpperBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).Value : 0);

                    //job.SalaryLowerBand = Convert.ToDecimal(salaryFrom[1]);
                    //job.SalaryUpperBand = Convert.ToDecimal(salaryTo[1]);
                    job.SalaryTypeId = Convert.ToInt32(ddlSalary.SelectedValue);

                    job.ShowSalaryRange = chkShowSalaryRange.Checked;
                    job.ShowSalaryDetails = chkShowSalaryDetails.Checked;

                    job.SalaryText = CommonService.EncodeString(txtSalaryText.Text);


                    // Default values.
                    job.Visible = false;
                    //job.Billed = false;

                    /*
                    // Save it as draft when the check box is checked.
                    if (pnlSaveAsDraft.Visible && chkSaveAsDraft.Checked)
                        job.Visible = false;
                    else
                        job.Visible = true; // means billed = 1 and not a draft.*/


                    //if (job.Expired != (int)PortalEnums.Jobs.JobStatus.Live)
                    //{
                    //    job.DatePosted = DateTime.Now;
                    //    job.ExpiryDate = DateTime.Now.AddDays(30);
                    //}

                    // By default the job is in the draft
                    //job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                    // If job is checked as Expired.
                    if (chkJobExpired.Checked)
                    {
                        job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;
                        jobExpiredFromLiveStatus = true;
                    }
                    else
                    {
                        // Else job is Live by default.
                        job.Visible = true;

                        if (!string.IsNullOrEmpty(tbExpiryDate.Text))
                            job.ExpiryDate = DateTime.Parse(tbExpiryDate.Text);

                    }
                    // Only when in Admin page
                    job.LastModifiedByAdminUserId = (int?)null;
                    //job.LastModifiedByAdvertiserUserId = (IsAdmin) ? AdvertiserUserID : SessionData.AdvertiserUser.AdvertiserUserId;
                    //job.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;


                    job.JobItemTypeId = Convert.ToInt32(ddlJobItemType.SelectedValue);
                    job.ApplicationEmailAddress = CommonService.EncodeString(txtApplicationEmailAddress.Text);

                    job.ApplicationMethod = Convert.ToInt32(ddlApplicationMethod.SelectedValue);
                    job.ApplicationUrl = CommonService.EncodeString(txtApplicationURL.Text);

                    //Upload Method always 1 (Website) as the job is posted manually
                    job.UploadMethod = 1;

                    job.Tags = CommonService.EncodeString(txtTags.Text);
                    job.JobTemplateId = Convert.ToInt32(ddlJobTemplateID.SelectedValue);
                    //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                    //job.AdvertiserJobTemplateLogoId = 
                    //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);
                    job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);

                    if (docInput.HasFile)
                    {
                        Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();
                        objAdvJobTemplateLogo.AdvertiserId = BullhornSettingsDefaultAdvertiserID;

                        objAdvJobTemplateLogo.JobLogoName = tbJobLogoName.Text.Trim();

                        AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);

                        if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                        {
                            if (this.docInput.PostedFile != null)
                            {
                                System.IO.MemoryStream objInputMemoryStream = new System.IO.MemoryStream(this.getArray(this.docInput.PostedFile));
                                System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(objInputMemoryStream);
                                System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage,
                                    PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                                System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                                
                                string errormessage = string.Empty;
                                string extension = Utils.GetImageExtension(objOriginalImage);
                                FileManagerService.UploadFile(bucketName, advertiserJobTemplateLogoFolder, string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension), objOutputMemorySTream, out errormessage);

                                if (string.IsNullOrWhiteSpace(errormessage))
                                {
                                    objAdvJobTemplateLogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension);
                                    AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                                }
                            }

                        }

                        job.AdvertiserJobTemplateLogoId = objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId;
                    }


                    job.RequireLogonForExternalApplications = false;
                    job.ShowLocationDetails = chkShowLocationDetails.Checked;
                    job.PublicTransport = CommonService.EncodeString(txtPublicTransport.Text);
                    job.Address = CommonService.EncodeString(txtAddress.Text);

                    //assign geocodes if any
                    AssignAddressGeocodes(job);

                    job.ContactDetails = CommonService.EncodeString(txtContactDetails.Text);
                    job.JobContactPhone = CommonService.EncodeString(txtJobContactPhone.Text);
                    job.JobContactName = CommonService.EncodeString(txtJobContactName.Text);
                    job.QualificationsRecognised = chkQualificationsRecognised.Checked;
                    job.ResidentOnly = chkResidentOnly.Checked;
                    //job.DocumentLink = txtDocumentLink.Text;
                    job.BulletPoint1 = CommonService.EncodeString(txtBulletPoint1.Text);
                    job.BulletPoint2 = CommonService.EncodeString(txtBulletPoint2.Text);

                    job.BulletPoint3 = CommonService.EncodeString(txtBulletPoint3.Text);
                    job.HotJob = false;

                    job.JobFriendlyName = Common.Utils.UrlFriendlyName(txtFriendlyUrl.Text);

                    using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(BullhornSettingsDefaultAdvertiserID))
                    {
                        job.AdvertiserId = advertiser.AdvertiserId;
                        job.CompanyName = advertiser.CompanyName;
                    }
                    //if (IsAdmin && ddlAdvertiserUser.SelectedValue != "0")
                    //{
                    //    job.EnteredByAdvertiserUserId = Convert.ToInt32(ddlAdvertiserUser.SelectedValue);

                    /*
                    job.SearchField = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}", job.JobName, JXTPortal.Common.Utils.StripHTML(job.Description), JXTPortal.Common.Utils.StripHTML(job.FullDescription),
                       (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession1.SelectedValue, (ddlProfession2.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue, (ddlProfession1.SelectedIndex == 0) ? "" : ddlProfession3.SelectedValue,
                       (ddlRole1.SelectedIndex == 0) ? "" : ddlRole1.SelectedValue, (ddlRole2.SelectedIndex == 0) ? "" : ddlRole2.SelectedValue, (ddlRole3.SelectedIndex == 0) ? "" : ddlRole3.SelectedValue,
                       (ddlLocation.SelectedIndex == 0) ? "" : ddlLocation.SelectedValue, (ddlArea.SelectedIndex == 0) ? "" : ddlArea.SelectedValue, (ddlWorkType.SelectedIndex == 0) ? "" : ddlWorkType.SelectedValue, (ddlSalary.SelectedIndex == 0) ? "" : ddlSalary.SelectedValue,
                       job.CompanyName);
                    */

                    using (TList<JXTPortal.Entities.JobArea> objJobAreas = JobAreaService.GetByJobId(job.JobId))
                    {
                        JXTPortal.Entities.JobArea objJobArea = null;
                        if (objJobAreas.Count > 0)
                        {
                            objJobArea = objJobAreas[0];
                            objJobArea.JobId = job.JobId;
                            objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                            if (JobAreaService.Update(objJobArea))
                            {
                                using (TList<JXTPortal.Entities.JobRoles> objJobRoles = JobRolesService.GetByJobId(JobID))
                                {
                                    JobRolesService.Delete(objJobRoles);

                                    JXTPortal.Entities.JobRoles objJobRole = new JXTPortal.Entities.JobRoles();

                                    if (ddlRole1.SelectedValue != "0")
                                    {
                                        objJobRole.JobId = job.JobId;
                                        objJobRole.RoleId = (ddlRole1.SelectedValue != "0") ? Convert.ToInt32(ddlRole1.SelectedValue) : (int?)null;
                                        JobRolesService.Insert(objJobRole);
                                    }

                                    if (ddlRole2.SelectedValue != "0")
                                    {
                                        objJobRole.JobId = job.JobId;
                                        objJobRole.RoleId = (ddlRole2.SelectedValue != "0") ? Convert.ToInt32(ddlRole2.SelectedValue) : (int?)null;
                                        JobRolesService.Insert(objJobRole);
                                    }

                                    if (ddlRole3.SelectedValue != "0")
                                    {
                                        objJobRole.JobId = job.JobId;
                                        objJobRole.RoleId = (ddlRole3.SelectedValue != "0") ? Convert.ToInt32(ddlRole3.SelectedValue) : (int?)null;
                                        JobRolesService.Insert(objJobRole);
                                    }
                                }


                                JobsService.Update(job);
                            }
                        }
                        else
                        {
                            objJobArea = new JXTPortal.Entities.JobArea();
                            objJobArea.JobId = job.JobId;
                            objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                            if (JobAreaService.Insert(objJobArea))
                            {
                                if (JobsService.Update(job))
                                {
                                    //Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                                }
                            }
                        }
                    }
                }
            }
        }

        private string BullhornTokenResetURLGet()
        {
            //get site's integrations
            IntegrationsService iService = new IntegrationsService();
            AdminIntegrations.Integrations integrations = iService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //dump
            iService = null;

            AdminIntegrations.Bullhorn bullhornSettings = integrations.Bullhorn;

            if (bullhornSettings == null
                || string.IsNullOrEmpty(bullhornSettings.ClientKey)
                || string.IsNullOrEmpty(bullhornSettings.ClientSecret)
                || string.IsNullOrEmpty(bullhornSettings.ClientUsername)
                || string.IsNullOrEmpty(bullhornSettings.ClientPassword)
                )
            {
                //should not fall here
                //return "Incomplete Bullhorn settings: Client Key, Client Secret, Login Username and Login Password is required. You may need to save your existing details before resetting the tokens.";
            }
            // Consumer Key, Secret from SFDC account
            string clientKey = bullhornSettings.ClientKey;
            string clientSecret = bullhornSettings.ClientSecret;

            // Consumer logins
            string clientUsername = bullhornSettings.ClientUsername;
            string clientPassword = bullhornSettings.ClientPassword;

            // Redirect URL configured in SFDC account
            HttpRequest currentReq = HttpContext.Current.Request;

            string hostName = currentReq.IsLocal ? currentReq.Url.Authority : currentReq.Url.Host;
            string redirectURL = String.Format("{0}://{1}/{2}", (currentReq.IsSecureConnection ? "https" : "http"), hostName, "job/bullhornintegration.aspx");

            //Live logins
            //======================
            //clientUsername = "JXTAPI";
            //clientPassword = "301_perth";

            BullhornRESTAPI bhapi = new BullhornRESTAPI(clientKey, clientSecret, redirectURL, clientUsername, clientPassword, !bullhornSettings.isLive);

            string BHAuthorizeURL = bhapi.GetAuthorizeUrl();

            return BHAuthorizeURL;

        }

        #region Load Controls Method

        public void LoadForm()
        {
            SetValidationMessages();

            LoadJobType();
            LoadApplicationMethod();
            LoadWorkType();
            LoadSalary();
            LoadAdvertiser(); ;
            LoadJobTemplate();
            LoadAdvertiserJobTemplateLogo();
            LoadLocation();
            LoadArea();
            LoadProfession();
            LoadRoles(0, ref ddlRole1);
            LoadRoles(0, ref ddlRole2);
            LoadRoles(0, ref ddlRole3);

            //LoadJob();
            //LoadUI();
        }

        private void LoadAdvertiser()
        {
            using (Entities.AdvertiserUsers advUser = AdvertiserUsersService.GetByAdvertiserUserId(BullhornSettings.DefaultAdvertiserUserID))
            {
                using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(BullhornSettingsDefaultAdvertiserID))
                {
                    advertiserNameDisplay.Text = string.Format("{0} {1} ({2})", advUser.FirstName, advUser.Surname, advUser.UserName);
                    lblusername.Text = advertiser.CompanyName;
                }
            }
        }

        private void LoadJobType()
        {
            int advertiseruserid = 0;
            int advertiserid = 0;
            PortalEnums.Advertiser.AccountType accountype = PortalEnums.Advertiser.AccountType.Account;

            advertiseruserid = AdvertiserUserID;
            advertiserid = AdvertiserID;
            accountype = AdvertiserAccountType;

            using (DataSet jobcreditlist = InvoiceService.CustomJobCreditList(advertiseruserid))
            {
                ddlJobItemType.Items.Clear();

                foreach (DataRow row in jobcreditlist.Tables[0].Rows)
                {
                    if (SessionData.Site.IsJobBoard && accountype == PortalEnums.Advertiser.AccountType.Credit_Card)
                    {
                        //if (Convert.ToInt32(row["Remaining"]) != 0)
                        //{
                        ddlJobItemType.Items.Add(new ListItem(string.Format("{0} ({1})", row["JobItemTypeDescription"].ToString(), row["Remaining"].ToString()), row["JobItemTypeID"].ToString()));
                        //}
                    }
                    else
                    {
                        ddlJobItemType.Items.Add(new ListItem(row["JobItemTypeDescription"].ToString(), row["JobItemTypeID"].ToString()));
                    }
                }

                // Set Visibility for Premium job type
                // phJobStartDate.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
                phInfo.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
                cal_tbStartDate.SelectedDate = DateTime.Now;
            }
        }

        private void LoadLocation()
        {
            ddlLocation.Items.Clear();

            SiteCountriesService siteCountriesService = new SiteCountriesService();
            SiteLocationService siteLocationService = new SiteLocationService();
            List<Entities.SiteCountries> siteCountriesList = siteCountriesService.GetTranslatedCountries();

            ddlLocation.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));

            ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));

            foreach (Entities.SiteCountries siteCountries in siteCountriesList)
            {
                ddlLocation.AddItemGroup(siteCountries.SiteCountryName);

                List<Entities.SiteLocation> filteredList = siteLocationService.GetTranslatedLocationsByCountryID(siteCountries.CountryId);

                foreach (Entities.SiteLocation siteLocation in filteredList)
                {
                    ddlLocation.Items.Add(new ListItem(siteLocation.SiteLocationName, siteLocation.LocationId.ToString()));
                }
            }
        }

        private void LoadArea()
        {
            ddlArea.DataSource = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue));
            ddlArea.DataTextField = "SiteAreaName";
            ddlArea.DataValueField = "AreaId";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));


            // Salary Currency
            using (Entities.Location location = LocationService.GetByLocationId(Convert.ToInt32(ddlLocation.SelectedValue)))
            {
                if (location != null)
                {
                    using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, location.CountryId))
                    {

                        if (siteCountry != null)
                        {
                            ltlLowerCurrency.Text = siteCountry.Currency;
                            ltlUpperCurrency.Text = siteCountry.Currency;
                        }
                    }
                }
            }
        }

        private void LoadProfession()
        {
            //we just need to get the data once
            List<JXTPortal.Entities.SiteProfession>
                siteProfessionList = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole).OrderBy(siteProfession => siteProfession.Sequence).ToList();

            LoadProfession(siteProfessionList, ddlProfession1);
            ddlRole1.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
            LoadProfession(siteProfessionList, ddlProfession2);
            ddlRole2.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
            LoadProfession(siteProfessionList, ddlProfession3);
            ddlRole3.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadProfession(List<JXTPortal.Entities.SiteProfession> prof, DropDownList ddlProfessionControl)
        {
            ddlProfessionControl.DataSource = prof;
            ddlProfessionControl.DataTextField = "SiteProfessionName";
            ddlProfessionControl.DataValueField = "ProfessionId";
            ddlProfessionControl.DataBind();
            ddlProfessionControl.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadRoles(int ProfessionId, ref DropDownList ddlRoleControl)
        {
            ddlRoleControl.DataSource = SiteRolesService.GetTranslatedByProfessionID(ProfessionId, SessionData.Site.UseCustomProfessionRole).OrderBy(siteRole => siteRole.Sequence).ToList();
            ddlRoleControl.DataTextField = "SiteRoleName";
            ddlRoleControl.DataValueField = "RoleId";
            ddlRoleControl.DataBind();
            ddlRoleControl.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadWorkType()
        {
            List<JXTPortal.Entities.SiteWorkType> siteWorkTypes = SiteWorkTypeService.GetTranslatedWorkTypes().OrderBy(siteWorktype => siteWorktype.Sequence).ToList();
            ddlWorkType.DataSource = siteWorkTypes;
            ddlWorkType.DataBind();
            ddlWorkType.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadSalary()
        {
            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            ddlSalary.Items.Clear();

            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {                
                ddlSalary.Items.Add(new ListItem(sitesalarytype.SalaryTypeName, sitesalarytype.SalaryTypeId.ToString()));                
            }

            ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));


            txtSalaryLowerBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMinimum"));
            txtSalaryUpperBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMaximum"));

            /*
            ddlSalary.DataSource = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            ddlSalary.DataBind();
            ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));


            for (int i = 1; i < ddlSalary.Items.Count; i++)
            {
                ddlSalary.Items[i].Attributes.Add("placeholdertag",
                                            (ddlSalary.Items[i].Value != "2" ?
                                                    CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualTo") :
                                                    CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyTo")));
            }*/
        }

        private void LoadJobTemplate()
        {
            
 
            int aid = AdvertiserID;

            if (aid > 0)
            {
                using (DataSet jobtemplates = JobTemplatesService.GetAdvertiserJobTemplates(SessionData.Site.SiteId, aid))
                {
                    ddlJobTemplateID.DataSource = jobtemplates;
                    ddlJobTemplateID.DataBind();
                }
            }

            //show template image
            if (!string.IsNullOrEmpty(ddlJobTemplateID.SelectedValue))
            {
                imgAdvJobTemplate.ImageUrl = string.Format("/getfile.aspx?jobtemplateid={0}", ddlJobTemplateID.SelectedValue.ToString());

                imgAdvJobTemplate.Attributes.Add("style", "display:block");
            }
            else
            {
                imgAdvJobTemplate.Attributes.Add("style", "display:none");
            }

            //ddlJobTemplateID.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        private void LoadApplicationMethod()
        {
            ddlApplicationMethod.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.Jobs.ApplicationMethod>();
            ddlApplicationMethod.DataTextField = "Key";
            ddlApplicationMethod.DataValueField = "Value";
            ddlApplicationMethod.DataBind();
        }

        private void LoadAdvertiserJobTemplateLogo()
        {
            ddlAdvertiserJobTemplateLogo.DataSource = AdvertiserJobTemplateLogoService.GetByAdvertiserId(BullhornSettingsDefaultAdvertiserID);

            ddlAdvertiserJobTemplateLogo.DataTextField = "JobLogoName";
            ddlAdvertiserJobTemplateLogo.DataValueField = "AdvertiserJobTemplateLogoID";
            ddlAdvertiserJobTemplateLogo.DataBind();
            //ddlAdvertiserJobTemplateLogo.Items.Insert(0, new ListItem("< Please Choose ...>", "0"));
            ddlAdvertiserJobTemplateLogo.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }

        public void SetValidationMessages()
        {
            ReqVal_WorkType.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Salary.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_JobArea.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Prof1.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Role1.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_ApplicationEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ctmApplicationMethod.ErrorMessage = CommonFunction.GetResourceValue("LabelWarningBlankURL");
            ReqValJobTemplate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rqStartDate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");

        }

        public void SetFormValues()
        {
            InsertButton.Text = CommonFunction.GetResourceValue("ButtonSave");
            UpdateButton.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            //CancelButton.Text = CommonFunction.GetResourceValue("ButtonCancel");
            //ReqVal_JobItemPrice.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            //RangeVal_JobItemPrice.ErrorMessage = CommonFunction.GetResourceValue("LabelPriceRange");
            ReqVal_JobName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_FriendlyUrl.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_ExpiryDate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_WorkType.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Description.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Salary.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_JobArea.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Role1.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            CusValJobProfessionRole.ErrorMessage = CommonFunction.GetResourceValue("LabelErrorDuplicateRole");
            ReqVal_ApplicationEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ctmApplicationMethod.ErrorMessage = CommonFunction.GetResourceValue("LabelWarningBlankURL");
            ReqVal_ContactDetails.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqValJobTemplate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rvjobFieldFullDescription.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvAdvJobTemplateLogoName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvAdvJobTemplateLogoImage.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rqStartDate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");

        }

        #endregion

        #endregion

        #region Controls Events

        protected void CusValJobProfessionRole_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;

            if (ddlRole1.SelectedValue != "0")
            {
                if (ddlRole1.SelectedValue == ddlRole2.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole1.SelectedValue == ddlRole3.SelectedValue)
                {
                    valid = false;
                }
            }

            if (ddlRole2.SelectedValue != "0")
            {
                if (ddlRole2.SelectedValue == ddlRole1.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole2.SelectedValue == ddlRole3.SelectedValue)
                {
                    valid = false;
                }
            }

            if (ddlRole3.SelectedValue != "0")
            {
                if (ddlRole3.SelectedValue == ddlRole1.SelectedValue)
                {
                    valid = false;
                }

                if (ddlRole3.SelectedValue == ddlRole2.SelectedValue)
                {
                    valid = false;
                }
            }

            args.IsValid = valid;
        }

        protected void cvalExpiryDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;

            if (!string.IsNullOrEmpty(tbExpiryDate.Text))
            {
                try
                {
                    DateTime expDate;
                    if (!DateTime.TryParse(tbExpiryDate.Text, out expDate))
                        valid = false;
                    else
                    {
                        DateTime validDate = DateTime.Today.AddDays(1);

                        if (expDate < validDate)
                            valid = false;
                    }
                }
                catch (Exception e)
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                cvExpiryDate.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidDate");
            }


            args.IsValid = valid;
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
        }

        protected void ddlProfession1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession1.SelectedValue), ref ddlRole1);
        }

        protected void ddlProfession2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession2.SelectedValue), ref ddlRole2);
        }

        protected void ddlProfession3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(Convert.ToInt32(ddlProfession3.SelectedValue), ref ddlRole3);
        }

        protected void ddlJobItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set Visibility for Premium job type
            // phJobStartDate.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
            plClassifications.Visible = (ddlJobItemType.SelectedValue != ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());
            phInfo.Visible = (ddlJobItemType.SelectedValue == ((int)PortalEnums.Jobs.JobItemType.Premium).ToString());

        }

        protected void ddlJobTemplateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(ddlJobTemplateID.SelectedValue))
            {
                imgAdvJobTemplate.ImageUrl = string.Format("/getfile.aspx?jobtemplateid={0}", ddlJobTemplateID.SelectedValue.ToString());

                imgAdvJobTemplate.Attributes.Add("style", "display:block");
            }
            else
            {
                imgAdvJobTemplate.Attributes.Add("style", "display:none");
            }
        }

        protected void ddlApplicationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
            {
                txtApplicationURL.Enabled = true;
            }
            else
            {
                txtApplicationURL.Enabled = false;
                txtApplicationURL.Text = string.Empty;
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int bh_entityID = int.Parse(Request["EntityID"]);

                #region Insert New Job
                using (JXTPortal.Entities.Jobs job = new JXTPortal.Entities.Jobs())
                {

                    int daysactive = 30;

                    //set external id
                    job.JobExternalId = ExternalIDPrefix + bh_entityID;

                    if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                    {
                        TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                        jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + ddlJobItemType.SelectedValue.ToString();
                        if (jobitemtypes.Count > 0)
                        {
                            daysactive = jobitemtypes[0].DaysActive;
                        }
                    }

                    job.SiteId = SessionData.Site.SiteId;
                    //job.DatePosted = DateTime.Now;
                    job.WebServiceProcessed = false;
                    job.WorkTypeId = Convert.ToInt32(ddlWorkType.SelectedValue);

                    job.JobName = CommonService.EncodeString(txtJobName.Text);
                    job.Description = CommonService.EncodeString(txtDescription.Text);
                    job.FullDescription = txtFullDescription.Text;
                    job.RefNo = CommonService.EncodeString(txtRefNo.Text); // ADD
                    job.DatePosted = DateTime.Now;

                    if (!string.IsNullOrEmpty(tbExpiryDate.Text))
                        job.ExpiryDate = DateTime.Parse(tbExpiryDate.Text);
                    else
                        job.ExpiryDate = DateTime.Now.AddDays(daysactive);

                    //job.Expired = chkJobExpired.Checked ? (int) PortalEnums.Jobs.JobStatus.Expired : (int) PortalEnums.Jobs.JobStatus.Live;
                    /*if (!string.IsNullOrEmpty(txtJobItemPrice.Text))
                    {
                        job.JobItemPrice = Convert.ToDecimal(txtJobItemPrice.Text);
                    }*/

                    //string[] salaryFrom = ddlSalaryFrom.SelectedValue.Split(';');
                    //string[] salaryTo = ddlSalaryTo.SelectedValue.Split(';'); ;
                    job.CurrencyId = 1; // Todo - Currency is not used .. and its hardcoded. - Don't remove this - it breaks the advanced search.
                    job.SalaryLowerBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text).Value : 0);
                    job.SalaryUpperBand = (CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).HasValue ?
                                                CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text).Value : 0);
                    job.SalaryTypeId = Convert.ToInt32(ddlSalary.SelectedValue);


                    job.ShowSalaryRange = chkShowSalaryRange.Checked;
                    job.ShowSalaryDetails = chkShowSalaryDetails.Checked;
                    job.SalaryText = txtSalaryText.Text;
                    job.JobItemTypeId = Convert.ToInt32(ddlJobItemType.SelectedValue);

                    job.ApplicationEmailAddress = txtApplicationEmailAddress.Text;

                    job.ApplicationMethod = Convert.ToInt32(ddlApplicationMethod.SelectedValue);
                    job.ApplicationUrl = txtApplicationURL.Text;

                    //Upload Method always 1 (Website) as the job is posted manually
                    job.UploadMethod = 1;

                    job.Tags = txtTags.Text;        // ADD
                    job.JobTemplateId = Convert.ToInt32(ddlJobTemplateID.SelectedValue);
                    //job.SearchFieldExtension = dataSearchFieldExtension.Text;
                    //job.AdvertiserJobTemplateLogoId = 
                    //    (string.IsNullOrEmpty(dataAdvertiserJobTemplateLogoID.Text)) ? (int?)null : Convert.ToInt32(dataAdvertiserJobTemplateLogoID.Text);

                    job.AdvertiserJobTemplateLogoId = Convert.ToInt32(ddlAdvertiserJobTemplateLogo.SelectedValue);      //ADD
                    if (docInput.HasFile)
                    {
                        Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();
                        objAdvJobTemplateLogo.AdvertiserId = BullhornSettingsDefaultAdvertiserID;

                        objAdvJobTemplateLogo.JobLogoName = tbJobLogoName.Text.Trim();

                        AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);

                        if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                        {
                            if (this.docInput.PostedFile != null)
                            {
                                System.IO.MemoryStream objInputMemoryStream = new System.IO.MemoryStream(this.getArray(this.docInput.PostedFile));
                                System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(objInputMemoryStream);
                                System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage,
                                    PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                                System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                                
                                string errormessage = string.Empty;
                                string extension = Utils.GetImageExtension(objOriginalImage);
                                
                                FileManagerService.UploadFile(bucketName, advertiserJobTemplateLogoFolder, string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension), objOutputMemorySTream, out errormessage);
                                if (string.IsNullOrWhiteSpace(errormessage))
                                {
                                    objAdvJobTemplateLogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension);
                                    AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                                }
                            }

                        }

                        job.AdvertiserJobTemplateLogoId = objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId;
                    }

                    job.RequireLogonForExternalApplications = false; // chkRequireLogonForExternalApplications.Checked;
                    job.ShowLocationDetails = chkShowLocationDetails.Checked;
                    job.PublicTransport = txtPublicTransport.Text;
                    job.Address = txtAddress.Text;

                    //assign geocodes if any
                    AssignAddressGeocodes(job);

                    job.ContactDetails = CommonService.EncodeString(txtContactDetails.Text);
                    job.JobContactPhone = txtJobContactPhone.Text;
                    job.JobContactName = txtJobContactName.Text;
                    job.QualificationsRecognised = chkQualificationsRecognised.Checked;
                    job.ResidentOnly = chkResidentOnly.Checked;
                    //job.DocumentLink = txtDocumentLink.Text;
                    job.BulletPoint1 = CommonService.EncodeString(txtBulletPoint1.Text);
                    job.BulletPoint2 = CommonService.EncodeString(txtBulletPoint2.Text);
                    job.BulletPoint3 = CommonService.EncodeString(txtBulletPoint3.Text);
                    job.HotJob = false; // chkHotJob.Checked;

                    job.JobFriendlyName = Common.Utils.UrlFriendlyName(txtFriendlyUrl.Text);


                    // By default the job is in the draft
                    job.Expired = (int)PortalEnums.Jobs.JobStatus.Live;
                    // If job is checked as Expired.
                    if (chkJobExpired.Checked)
                        job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;
                    else // Else job is Live by default.
                        job.Visible = true;


                    using (Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(BullhornSettings.DefaultAdvertiserUserID))
                    {
                        job.AdvertiserId = advertiseruser.AdvertiserId;
                    }

                    //job.AdvertiserId = BullhornSettings.DefaultAdvertiserUserID;
                    job.EnteredByAdvertiserUserId = BullhornSettings.DefaultAdvertiserUserID;

                    if (job.AdvertiserId.HasValue)
                    {
                        using (Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(job.AdvertiserId.Value))
                        {
                            job.CompanyName = advertiser.CompanyName;
                        }
                    }

                    job.LastModifiedByAdminUserId = (int?)null;
                    job.LastModifiedByAdvertiserUserId = BullhornSettings.DefaultAdvertiserUserID;



                    if (phJobStartDate.Visible)
                    {
                        job.DatePosted = DateTime.ParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null);
                    }

                    if (JobsService.Insert(job))
                    {
                        using (JXTPortal.Entities.JobArea objJobArea = new JXTPortal.Entities.JobArea())
                        {
                            objJobArea.JobId = job.JobId;
                            objJobArea.AreaId = Convert.ToInt32(ddlArea.SelectedValue);

                            if (JobAreaService.Insert(objJobArea))
                            {
                                using (JXTPortal.Entities.JobRoles objJobRoles = new JXTPortal.Entities.JobRoles())
                                {
                                    if (ddlRole1.SelectedValue != "0")
                                    {
                                        objJobRoles.JobId = job.JobId;
                                        objJobRoles.RoleId = (ddlRole1.SelectedValue != "0") ? Convert.ToInt32(ddlRole1.SelectedValue) : (int?)null;
                                        JobRolesService.Insert(objJobRoles);
                                    }

                                    // Ignore job role 2 - 3 if it is premium job
                                    if (job.JobItemTypeId.Value != (int)PortalEnums.Jobs.JobItemType.Premium)
                                    {
                                        if (ddlRole2.SelectedValue != "0")
                                        {
                                            objJobRoles.JobId = job.JobId;
                                            objJobRoles.RoleId = (ddlRole2.SelectedValue != "0") ? Convert.ToInt32(ddlRole2.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRoles);
                                        }

                                        if (ddlRole3.SelectedValue != "0")
                                        {
                                            objJobRoles.JobId = job.JobId;
                                            objJobRoles.RoleId = (ddlRole3.SelectedValue != "0") ? Convert.ToInt32(ddlRole3.SelectedValue) : (int?)null;
                                            JobRolesService.Insert(objJobRoles);
                                        }
                                    }

                                    // Update for the Search Field
                                    JobsService.Update(job);
                                }

                            }
                        }
                    }
                    //update bullhorn record to live
                    bool updateBHStatusSuccess = BullhornJobStatusUpdate(bh_entityID, false);

                }
                #endregion

                ltFormMessage.Text = "Job details has been updated successfully.";
                ltFormMessage.Visible = true;
                plEndFormMessage.Visible = true;
                phlastmodifiedByAdvuserID.Visible = true;

                //reload page
                NonPostBackPageLoad();
            }

            //  AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "scrolling", "$('#submitMessages').focus();", true);
        }


        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            ltFormMessage.Visible = false;

            if (Page.IsValid)
            {
                bool jobExpired = false;
                int bh_entityID = int.Parse(Request["EntityID"]);
                int? JXTjobID, JXTarchivedJobID;
                bool hasJobReturned = JobsService.JobGetByExternalID(SessionData.Site.SiteId, BullhornSettingsDefaultAdvertiserID, ExternalIDPrefix + bh_entityID, out JXTjobID, out JXTarchivedJobID);

                if (!hasJobReturned)
                {
                    //ERROR
                    DisplayPageLoadError("Job record not found at JXT.");
                    return;
                }
                else
                {
                    if (JXTjobID.HasValue)
                    {
                        Entities.Jobs thisJob = JobsService.GetByJobId(JXTjobID.Value);

                        //check if JXT job expired, you can not modified this
                        if ((thisJob.Expired.HasValue && thisJob.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || thisJob.ExpiryDate < DateTime.Now)
                        {
                            //ERROR
                            DisplayPageLoadError("This job is now expired. You can not modify this job anymore.");
                            return;
                        }
                        else
                        {
                            //OK, update                            
                            UpdateJobDetailsToJXT(thisJob.JobId, out jobExpired);
                        }
                    }
                    else if (JXTarchivedJobID.HasValue)
                    {
                        //ERROR
                        //archived, can not be modified
                        DisplayPageLoadError("This job is now expired. You can not modify this job anymore.");
                    }
                }

                if (jobExpired)
                {
                    BullhornJobStatusUpdate(bh_entityID, true);

                    NonPostBackPageLoad();

                    ltFormMessage.Visible = false;
                    plEndFormMessage.Visible = false;
                }
                else
                {
                    NonPostBackPageLoad();

                    ltFormMessage.Text = "Job details has been updated successfully.";
                    ltFormMessage.Visible = true;
                    plEndFormMessage.Visible = true;

                    //ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "focusJS", "$(document).ready(function() { $('#UpdateButton').focus();  })", true);
                    //AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "scrolling", "alert('333'); $('#UpdateButton').focus(); $('#InsertButton').focus(); ", true);

                }
            }


        }

        protected void cvStartDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbStartDate.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (!string.IsNullOrWhiteSpace(ddlJobItemType.SelectedValue))
                    {
                        using (DataSet ds = AdvertiserJobPricingService.CustomGetByAdvertiserIDJobItemsTypeID(AdvertiserID, Convert.ToInt32(ddlJobItemType.SelectedValue)))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow advertiserjobpricingrow = ds.Tables[0].Rows[0];
                                if (advertiserjobpricingrow["StartDate"] != DBNull.Value)
                                {
                                    if (dt < Convert.ToDateTime(advertiserjobpricingrow["StartDate"]) || dt >Convert.ToDateTime(advertiserjobpricingrow["ExpiryDate"]))
                                    {
                                        cvStartDate.ErrorMessage = "Date out of range.";

                                        args.IsValid = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                        {
                            cvStartDate.ErrorMessage = "Date out of range.";

                            args.IsValid = false;
                        }
                    }
                }
                else
                {
                    cvStartDate.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }

        #endregion

        #region Custom Validators


        protected void CusValBulletPoint1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtBulletPoint1.Text.Length > 160)
            {
                CusValBulletPoint1.ErrorMessage = CommonFunction.GetResourceValue("ErrorBulletPointSize");
                args.IsValid = false;
            }
        }

        protected void CusValBulletPoint2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtBulletPoint2.Text.Length > 160)
            {
                CusValBulletPoint2.ErrorMessage = CommonFunction.GetResourceValue("ErrorBulletPointSize");
                args.IsValid = false;
            }
        }

        protected void CusValBulletPoint3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtBulletPoint3.Text.Length > 160)
            {
                CusValBulletPoint3.ErrorMessage = CommonFunction.GetResourceValue("ErrorBulletPointSize");
                args.IsValid = false;
            }
        }

        protected void ctmApplicationMethod_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(txtApplicationURL.Text) && Convert.ToInt32(ddlApplicationMethod.SelectedValue) == 2)
            {
                valid = false;
            }

            args.IsValid = valid;
        }

        protected void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfFileCheck.Value == "1")
            {
                if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
                {
                    string strExt = Path.GetExtension(docInput.PostedFile.FileName).Trim();

                    switch (strExt.ToUpper().Trim())
                    {
                        case ".GIF":
                        case ".JPG":
                        case ".JPEG":
                        case ".PNG":
                            args.IsValid = true;
                            break;

                        default:
                            if (string.IsNullOrEmpty(strExt))
                            {
                                this.cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageNoExtension");
                                args.IsValid = false;
                                hfFileError.Value = cvalFileName.ClientID;
                            }
                            else
                            {
                                this.cvalFileName.ErrorMessage = String.Format("{0} {1} {2}", CommonFunction.GetResourceValue("ErrorImageExtension"),
                                                string.Format("<strong>{0}</strong>", strExt), CommonFunction.GetResourceValue("ErrorNotAccepted"));
                                //+ String.Format(@"<strong>{0}</strong>", strExt) +                    
                                args.IsValid = false;
                                hfFileError.Value = cvalFileName.ClientID;
                            }
                            break;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfFileCheck.Value == "1")
            {
                if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
                {
                    if (docInput.PostedFile.ContentLength == 0)
                    {
                        this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageInvalidSize");
                        args.IsValid = false;
                        hfFileError.Value = cvalFileName.ClientID;

                    }
                    else if ((docInput.PostedFile.ContentLength / (Math.Pow(1024, 2))) > 1)
                    {
                        this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageExceed");
                        args.IsValid = false;
                        hfFileError.Value = cvalFileName.ClientID;

                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
                else
                {
                    args.IsValid = false;
                    hfFileError.Value = cvalFileName.ClientID;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }


        #endregion

        #region BH_Partner Session

        //public void demonstrateGetPartnerSession()
        //{

        //    // Update these values with those from your sandbox account
        //    int apiUserId = 7; // The ID of the Bullhorn user account you are logging in as
        //    int apiCorporationId = 7064; // the ID of the corporation account you are logging into
        //    String apiKey = "1307FAE3-A6A2-9B30-6CC45E56CED67F3B"; // The API key provided to you by Bullhorn
        //    String sharedSecret = "pass_RXT55"; // This must be set up with your API key

        //    ApiService service = new ApiService();
        //    BullhornOauth bhOauth = new BullhornOauth(service);

        //    //apiStartSessionResult res = service.startSession("rxtadminuser", "rxt123rxt", apiKey);

        //    partnerSessionRequest partnerSessionRequest = new partnerSessionRequest();
        //    partnerSessionRequest = bhOauth.generatePartnerSessionRequest(apiKey, sharedSecret, apiUserId, apiCorporationId);
        //    apiStartSessionResult startSessionResult = service.startPartnerSession(partnerSessionRequest);

        //    //Console.Write("Your session key is: " + startSessionResult.session);

        //}

        /// <summary>
        /// Demonstrate validating Oauth generated URL
        /// </summary>
        public bool BullhornValidateURL()
        {
            if (BullhornSettings != null && BullhornSettings.Valid)
            {
                String encodedUrl = (string)ViewState["RequestURL"];

                String apiKey = BullhornSettings.ClientSoapKey; // The API key provided to you by Bullhorn
                String sharedSecret = BullhornSettings.ClientSoapSecret; // This must be set up with your API key

                ApiService service = new ApiService();
                BullhornOauth bhOauth = new BullhornOauth(service);

                string oldCode, newCode;

                bool isValid = bhOauth.validateURLRequest(apiKey, sharedSecret, encodedUrl, out oldCode, out newCode);

                return isValid;
            }

            return false;
        }

        #endregion

    }
}