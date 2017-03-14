#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Website;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using JXTPortal.Common;
using JXTPortal.Entities.Models;
using JXTPortal.Client.Bullhorn;
using System.IO;
using System.Text.RegularExpressions;
using JXTPortal.Website.usercontrols.common;
using log4net;
#endregion

namespace JXTPortal.Website.member
{
    public partial class profile : System.Web.UI.Page
    {
        ILog _logger;
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string candidateFolder, memberFileFolder;

        #region "Properties"

        public IFileManager FileManagerService { get; set; }

        private string ContentValidationRegex = ConfigurationManager.AppSettings["ContentValidationRegex"];

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToLower().Replace("yyyy", "yy"); }
        }

        private MembersService _membersService;

        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                    _membersService = new MembersService();

                return _membersService;
            }
        }

        private MemberWizardService _memberwizardService;

        private MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberwizardService == null)
                    _memberwizardService = new MemberWizardService();

                return _memberwizardService;
            }
        }

        private MemberPositionsService _memberpositionsService;

        private MemberPositionsService MemberPositionsService
        {
            get
            {
                if (_memberpositionsService == null)
                    _memberpositionsService = new MemberPositionsService();

                return _memberpositionsService;
            }
        }

        private MemberQualificationService _memberqualificationService;

        private MemberQualificationService MemberQualificationService
        {
            get
            {
                if (_memberqualificationService == null)
                    _memberqualificationService = new MemberQualificationService();

                return _memberqualificationService;
            }
        }

        private MemberCertificateMembershipsService _membercertificatemembershipsService;

        private MemberCertificateMembershipsService MemberCertificateMembershipsService
        {
            get
            {
                if (_membercertificatemembershipsService == null)
                    _membercertificatemembershipsService = new MemberCertificateMembershipsService();

                return _membercertificatemembershipsService;
            }
        }

        private MemberLicensesService _memberlicensesService;

        private MemberLicensesService MemberLicensesService
        {
            get
            {
                if (_memberlicensesService == null)
                    _memberlicensesService = new MemberLicensesService();

                return _memberlicensesService;
            }
        }

        private MemberFilesService _memberfilesService;

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberfilesService == null)
                    _memberfilesService = new MemberFilesService();

                return _memberfilesService;
            }
        }

        private MemberLanguagesService _memberlanguagesService;

        private MemberLanguagesService MemberLanguagesService
        {
            get
            {
                if (_memberlanguagesService == null)
                    _memberlanguagesService = new MemberLanguagesService();

                return _memberlanguagesService;
            }
        }

        private MemberReferencesService _memberreferencesService;

        private MemberReferencesService MemberReferencesService
        {
            get
            {
                if (_memberreferencesService == null)
                    _memberreferencesService = new MemberReferencesService();

                return _memberreferencesService;
            }
        }

        private CountriesService _countriesService;

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                    _countriesService = new CountriesService();

                return _countriesService;
            }
        }

        private MemberFileTypesService _memberfiletypesService;

        private MemberFileTypesService MemberFileTypesService
        {
            get
            {
                if (_memberfiletypesService == null)
                    _memberfiletypesService = new MemberFileTypesService();

                return _memberfiletypesService;
            }
        }

        private SiteWorkTypeService _siteworktypeService;
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeService == null)
                    _siteworktypeService = new SiteWorkTypeService();

                return _siteworktypeService;
            }
        }

        private SiteSalaryTypeService _sitesalarytypeService;
        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeService == null)
                    _sitesalarytypeService = new SiteSalaryTypeService();

                return _sitesalarytypeService;
            }
        }

        private SiteProfessionService _siteprofessionService;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionService == null)
                    _siteprofessionService = new SiteProfessionService();

                return _siteprofessionService;
            }
        }

        private SiteRolesService _siterolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesService == null)
                    _siterolesService = new SiteRolesService();

                return _siterolesService;
            }
        }

        private SiteCountriesService _sitecountriesService;
        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesService == null)
                    _sitecountriesService = new SiteCountriesService();

                return _sitecountriesService;
            }
        }

        private LocationService _locationService;
        private LocationService LocationService
        {
            get
            {
                if (_locationService == null)
                    _locationService = new LocationService();

                return _locationService;
            }
        }

        private SiteLocationService _sitelocationService;
        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationService == null)
                    _sitelocationService = new SiteLocationService();

                return _sitelocationService;
            }
        }

        private SiteAreaService _siteareaService;
        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaService == null)
                    _siteareaService = new SiteAreaService();

                return _siteareaService;
            }
        }

        private SiteLanguagesService _sitelanguagesService;
        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesService == null)
                    _sitelanguagesService = new SiteLanguagesService();

                return _sitelanguagesService;
            }
        }

        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                    _integrationsService = new IntegrationsService();

                return _integrationsService;
            }
        }

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

        private List<ListItem> TitleList;
        private Dictionary<string, int> CurrentStatusList;
        private Dictionary<string, int> QualificationLevelList;
        private Dictionary<string, int> ProficiencyList;
        private Dictionary<string, int> RelationshipList;
        private List<Countries> CountryList;
        private List<Entities.Location> LocationList;
        private List<Entities.SiteProfession> ProfessionList;
        private List<Entities.SiteWorkType> WorkTypeList;
        private List<Entities.SiteSalaryType> SalaryTypeList;
        private List<ListItem> DayList;
        private List<ListItem> MonthList;
        private List<ListItem> YearList;
        private List<ListItem> FutureYearList;
        private int MinEducationEntry = 0;
        private int MinExperienceEntry = 0;
        private int MinReferenceEntry = 0;

        #endregion

        public profile()
        {
            _logger = LogManager.GetLogger(typeof(profile));
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            // ONLY FOR ENWORLD SITES - redirect to custom profile page
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
            ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " "))
            {
                Response.Redirect("/member/enworld/profile.aspx");
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            if (!SessionData.Site.IsUsingS3)
            {
                candidateFolder = ConfigurationManager.AppSettings["FTPMemberProfilePicUrl"];
                memberFileFolder = ConfigurationManager.AppSettings["FTPHost"] + ConfigurationManager.AppSettings["MemberRootFolder"] + "/" + ConfigurationManager.AppSettings["MemberFilesFolder"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                candidateFolder = ConfigurationManager.AppSettings["AWSS3MediaFolder"] + ConfigurationManager.AppSettings["AWSS3CandidateFolder"];
                memberFileFolder = ConfigurationManager.AppSettings["AWSS3MemberRootFolder"] + ConfigurationManager.AppSettings["AWSS3MemberFilesFolder"];
            }

            CommonPage.SetBrowserPageTitle(Page, "Profile");

            if (!Page.IsPostBack)
            {
                ProcessFocusSectionFlag();


                AssignInputPlaceHolders();

                LoadMemberTitle();
                LoadMemberCurrentlySeeking();
                LoadMemberQualificationLevel();
                LoadMemberProficiency();
                LoadRelationship();
                LoadCountry();
                LoadCalendar();
                LoadProfession();
                LoadLocation();
                LoadWorkType();
                LoadSalaryType();
                LoadSkills();
                SkillsAutoCompleteJS(true);
                LicenseTypesAutoCompleteJS(true);
                QualificationNamesAutoCompleteJS(true);

                SetMemberInformation();

            }
            else
            {
                SetSupplementaryQuestions();
            }

            ////this has to be last, bool flags are placed in the above functions to calculate progress bar
            //SetProgressBar();
        }

        #region Profile

        private void LoadMemberTitle()
        {
            TitleList = new List<ListItem>();

            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMr"), "Mr"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMrs"), "Mrs"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMs"), "Ms"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMiss"), "Miss"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelDr"), "Dr"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelProfessor"), "Professor"));
            TitleList.Add(new ListItem(CommonFunction.GetResourceValue("LabelOther"), "Other"));
        }

        private void LoadMemberCurrentlySeeking()
        {
            CurrentStatusList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.CurrentlySeeking>();
        }

        private void SetMemberInformation()
        {
            JXTPortal.Entities.MemberWizard memberWizard = null;

            using (memberWizard = MemberWizardService.GetAll().Find(s => s.SiteId.Equals(SessionData.Site.SiteId) && s.GlobalTemplate.Equals(false)))
            {
                if (memberWizard == null)
                {
                    memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));
                }
            }

            //Set min to variables
            MinEducationEntry = memberWizard.MinEducationsEntry;
            MinExperienceEntry = memberWizard.MinExperiencesEntry;
            MinReferenceEntry = memberWizard.MinReferencesEntry;

            phMultilingual.Visible = (SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId).Count > 1);

            // Set Member points
            SetMemberPoints();

            AssignSectionTitle(memberWizard);

            // Initialize the values
            ddlProfileTitle.Items.Clear();
            ddlProfileTitle.DataValueField = "value";
            ddlProfileTitle.DataTextField = "text";
            ddlProfileTitle.DataSource = TitleList;
            ddlProfileTitle.DataBind();

            ddlProfileCurrentStatus.Items.Clear();
            ddlProfileCurrentStatus.DataValueField = "Value";
            ddlProfileCurrentStatus.DataTextField = "Key";
            ddlProfileCurrentStatus.DataSource = CurrentStatusList;
            ddlProfileCurrentStatus.DataBind();
            ddlProfileCurrentStatus.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "-1"));

            ddlEducationAddQualificationLevel.Items.Clear();
            ddlEducationAddQualificationLevel.DataValueField = "Value";
            ddlEducationAddQualificationLevel.DataTextField = "Key";
            ddlEducationAddQualificationLevel.DataSource = QualificationLevelList;
            ddlEducationAddQualificationLevel.DataBind();
            ddlEducationAddQualificationLevel.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));

            ddlLanguageProficiency.Items.Clear();
            ddlLanguageProficiency.DataValueField = "Value";
            ddlLanguageProficiency.DataTextField = "Key";
            ddlLanguageProficiency.DataSource = ProficiencyList;
            ddlLanguageProficiency.DataBind();

            ddlReferencesAddRelationship.Items.Clear();
            ddlReferencesAddRelationship.DataValueField = "Value";
            ddlReferencesAddRelationship.DataTextField = "Key";
            ddlReferencesAddRelationship.DataSource = RelationshipList;
            ddlReferencesAddRelationship.DataBind();
            ddlReferencesAddRelationship.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));

            ddlDetailsCountry.Items.Clear();
            ddlDetailsCountry.DataValueField = "CountryID";
            ddlDetailsCountry.DataTextField = "CountryName";
            ddlDetailsCountry.DataSource = CountryList;
            ddlDetailsCountry.DataBind();

            ddlDetailsMailingCountry.Items.Clear();
            ddlDetailsMailingCountry.DataValueField = "CountryID";
            ddlDetailsMailingCountry.DataTextField = "CountryName";
            ddlDetailsMailingCountry.DataSource = CountryList;
            ddlDetailsMailingCountry.DataBind();
            ddlDetailsMailingCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));

            ddlDetailsDay.Items.Clear();
            ddlDetailsDay.DataValueField = "value";
            ddlDetailsDay.DataTextField = "text";
            ddlDetailsDay.DataSource = DayList;
            ddlDetailsDay.DataBind();
            ddlDetailsDay.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayDD"), ""));

            ddlDetailsMonth.Items.Clear();
            ddlDetailsMonth.DataValueField = "value";
            ddlDetailsMonth.DataTextField = "text";
            ddlDetailsMonth.DataSource = MonthList;
            ddlDetailsMonth.DataBind();
            ddlDetailsMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), ""));

            ddlDetailsYear.Items.Clear();
            ddlDetailsYear.DataValueField = "value";
            ddlDetailsYear.DataTextField = "text";
            ddlDetailsYear.DataSource = YearList;
            ddlDetailsYear.DataBind();
            ddlDetailsYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), ""));


            ddlExperienceAddCountry.Items.Clear();
            ddlExperienceAddCountry.DataValueField = "CountryID";
            ddlExperienceAddCountry.DataTextField = "CountryName";
            ddlExperienceAddCountry.DataSource = CountryList;
            ddlExperienceAddCountry.DataBind();
            ddlExperienceAddCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

            ddlExperienceAddStartMonth.Items.Clear();
            ddlExperienceAddStartMonth.DataValueField = "value";
            ddlExperienceAddStartMonth.DataTextField = "text";
            ddlExperienceAddStartMonth.DataSource = MonthList;
            ddlExperienceAddStartMonth.DataBind();
            ddlExperienceAddStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlExperienceAddStartYear.Items.Clear();
            ddlExperienceAddStartYear.DataValueField = "value";
            ddlExperienceAddStartYear.DataTextField = "text";
            ddlExperienceAddStartYear.DataSource = YearList;
            ddlExperienceAddStartYear.DataBind();
            ddlExperienceAddStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlExperienceAddEndMonth.Items.Clear();
            ddlExperienceAddEndMonth.DataValueField = "value";
            ddlExperienceAddEndMonth.DataTextField = "text";
            ddlExperienceAddEndMonth.DataSource = MonthList;
            ddlExperienceAddEndMonth.DataBind();
            ddlExperienceAddEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlExperienceAddEndYear.Items.Clear();
            ddlExperienceAddEndYear.DataValueField = "value";
            ddlExperienceAddEndYear.DataTextField = "text";
            ddlExperienceAddEndYear.DataSource = YearList;
            ddlExperienceAddEndYear.DataBind();
            ddlExperienceAddEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlDirectorshipAddStartMonth.Items.Clear();
            ddlDirectorshipAddStartMonth.DataValueField = "value";
            ddlDirectorshipAddStartMonth.DataTextField = "text";
            ddlDirectorshipAddStartMonth.DataSource = MonthList;
            ddlDirectorshipAddStartMonth.DataBind();
            ddlDirectorshipAddStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlDirectorshipAddStartYear.Items.Clear();
            ddlDirectorshipAddStartYear.DataValueField = "value";
            ddlDirectorshipAddStartYear.DataTextField = "text";
            ddlDirectorshipAddStartYear.DataSource = YearList;
            ddlDirectorshipAddStartYear.DataBind();
            ddlDirectorshipAddStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlDirectorshipAddEndMonth.Items.Clear();
            ddlDirectorshipAddEndMonth.DataValueField = "value";
            ddlDirectorshipAddEndMonth.DataTextField = "text";
            ddlDirectorshipAddEndMonth.DataSource = MonthList;
            ddlDirectorshipAddEndMonth.DataBind();
            ddlDirectorshipAddEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlDirectorshipAddEndYear.Items.Clear();
            ddlDirectorshipAddEndYear.DataValueField = "value";
            ddlDirectorshipAddEndYear.DataTextField = "text";
            ddlDirectorshipAddEndYear.DataSource = YearList;
            ddlDirectorshipAddEndYear.DataBind();
            ddlDirectorshipAddEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlEducationAddCountry.Items.Clear();
            ddlEducationAddCountry.DataValueField = "CountryID";
            ddlEducationAddCountry.DataTextField = "CountryName";
            ddlEducationAddCountry.DataSource = CountryList;
            ddlEducationAddCountry.DataBind();
            ddlEducationAddCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

            ddlEducationAddStartMonth.Items.Clear();
            ddlEducationAddStartMonth.DataValueField = "value";
            ddlEducationAddStartMonth.DataTextField = "text";
            ddlEducationAddStartMonth.DataSource = MonthList;
            ddlEducationAddStartMonth.DataBind();
            ddlEducationAddStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlEducationAddStartYear.Items.Clear();
            ddlEducationAddStartYear.DataValueField = "value";
            ddlEducationAddStartYear.DataTextField = "text";
            ddlEducationAddStartYear.DataSource = YearList;
            ddlEducationAddStartYear.DataBind();
            ddlEducationAddStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlEducationAddEndMonth.Items.Clear();
            ddlEducationAddEndMonth.DataValueField = "value";
            ddlEducationAddEndMonth.DataTextField = "text";
            ddlEducationAddEndMonth.DataSource = MonthList;
            ddlEducationAddEndMonth.DataBind();
            ddlEducationAddEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlEducationAddEndYear.Items.Clear();
            ddlEducationAddEndYear.DataValueField = "value";
            ddlEducationAddEndYear.DataTextField = "text";
            ddlEducationAddEndYear.DataSource = FutureYearList;
            //ddlEducationAddEndYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlEducationAddEndYear.DataBind();
            ddlEducationAddEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlCertificateAddStartMonth.Items.Clear();
            ddlCertificateAddStartMonth.DataValueField = "value";
            ddlCertificateAddStartMonth.DataTextField = "text";
            ddlCertificateAddStartMonth.DataSource = MonthList;
            ddlCertificateAddStartMonth.DataBind();
            ddlCertificateAddStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlCertificateAddStartYear.Items.Clear();
            ddlCertificateAddStartYear.DataValueField = "value";
            ddlCertificateAddStartYear.DataTextField = "text";
            ddlCertificateAddStartYear.DataSource = YearList;
            ddlCertificateAddStartYear.DataBind();
            ddlCertificateAddStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlCertificateAddEndMonth.Items.Clear();
            ddlCertificateAddEndMonth.DataValueField = "value";
            ddlCertificateAddEndMonth.DataTextField = "text";
            ddlCertificateAddEndMonth.DataSource = MonthList;
            ddlCertificateAddEndMonth.DataBind();
            ddlCertificateAddEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlCertificateAddEndYear.Items.Clear();
            ddlCertificateAddEndYear.DataValueField = "value";
            ddlCertificateAddEndYear.DataTextField = "text";
            ddlCertificateAddEndYear.DataSource = FutureYearList;
            ddlCertificateAddEndYear.DataBind();
            ddlCertificateAddEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlLicenseAddIssueMonth.Items.Clear();
            ddlLicenseAddIssueMonth.DataValueField = "value";
            ddlLicenseAddIssueMonth.DataTextField = "text";
            ddlLicenseAddIssueMonth.DataSource = MonthList;
            ddlLicenseAddIssueMonth.DataBind();
            ddlLicenseAddIssueMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlLicenseAddIssueYear.Items.Clear();
            ddlLicenseAddIssueYear.DataValueField = "value";
            ddlLicenseAddIssueYear.DataTextField = "text";
            ddlLicenseAddIssueYear.DataSource = YearList;
            ddlLicenseAddIssueYear.DataBind();
            //ddlLicenseAddIssueYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlLicenseAddIssueYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlLicenseAddExpiryMonth.Items.Clear();
            ddlLicenseAddExpiryMonth.DataValueField = "value";
            ddlLicenseAddExpiryMonth.DataTextField = "text";
            ddlLicenseAddExpiryMonth.DataSource = MonthList;
            ddlLicenseAddExpiryMonth.DataBind();
            ddlLicenseAddExpiryMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

            ddlLicenseAddExpiryYear.Items.Clear();
            ddlLicenseAddExpiryYear.DataValueField = "value";
            ddlLicenseAddExpiryYear.DataTextField = "text";
            ddlLicenseAddExpiryYear.DataSource = FutureYearList;
            ddlLicenseAddExpiryYear.DataBind();
            //ddlLicenseAddExpiryYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlLicenseAddExpiryYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

            ddlLicenseAddCountry.Items.Clear();
            ddlLicenseAddCountry.DataValueField = "CountryID";
            ddlLicenseAddCountry.DataTextField = "CountryName";
            ddlLicenseAddCountry.DataSource = CountryList;
            ddlLicenseAddCountry.DataBind();
            ddlLicenseAddCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

            ddlRolePreferenceJobClassification.Items.Clear();
            ddlRolePreferenceJobClassification.DataValueField = "ProfessionID";
            ddlRolePreferenceJobClassification.DataTextField = "SiteProfessionName";
            ddlRolePreferenceJobClassification.DataSource = ProfessionList;
            ddlRolePreferenceJobClassification.DataBind();
            ddlRolePreferenceJobClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseOne"), "0"));

            ddlRolePreferenceWorkType.Items.Clear();
            ddlRolePreferenceWorkType.DataValueField = "WorkTypeID";
            ddlRolePreferenceWorkType.DataTextField = "SiteWorkTypeName";
            ddlRolePreferenceWorkType.DataSource = WorkTypeList;
            ddlRolePreferenceWorkType.DataBind();
            ddlRolePreferenceWorkType.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));
            ddlRolePreferenceWorkType.Items[0].Attributes.Add("disabled", "disabled");

            ddlRolePreferenceSalaryRequirements.Items.Clear();
            ddlRolePreferenceSalaryRequirements.DataValueField = "SalaryTypeID";
            ddlRolePreferenceSalaryRequirements.DataTextField = "SalaryTypeName";
            ddlRolePreferenceSalaryRequirements.DataSource = SalaryTypeList;
            ddlRolePreferenceSalaryRequirements.DataBind();
            ddlRolePreferenceSalaryRequirements.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));

            ddlRolePreferenceEligibleToWorkIn.Items.Clear();
            ddlRolePreferenceEligibleToWorkIn.DataValueField = "CountryID";
            ddlRolePreferenceEligibleToWorkIn.DataTextField = "CountryName";
            List<Countries> validcountries = CountryList.Where(c => c.Sequence != -1).ToList();
            ddlRolePreferenceEligibleToWorkIn.DataSource = validcountries;
            ddlRolePreferenceEligibleToWorkIn.DataBind();

            hfSummaryEdit.HRef = "#" + ecSummary.ClientID;
            hfSummaryClose.HRef = "#" + ecSummary.ClientID;
            hfSummaryCancel.HRef = "#" + ecSummary.ClientID;

            //set min message for exp, edu and ref
            if (MinExperienceEntry > 0)
                ltExperienceMin.Text = String.Format(CommonFunction.GetResourceValue("LabelProfileMinEntries"), MinExperienceEntry);
            if (MinEducationEntry > 0)
                ltEducationMin.Text = String.Format(CommonFunction.GetResourceValue("LabelProfileMinEntries"), MinEducationEntry);
            if (MinReferenceEntry > 0)
            {
                ltReferencesMin.Text = String.Format(CommonFunction.GetResourceValue("LabelProfileMinEntries"), MinReferenceEntry);
                phUponRequest.Visible = false;
            }

            Entities.Members member = null;
            using (member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    int summarypoint = 0;
                    int personaldetailspoint = 0;
                    int workexperiencepoint = 0;
                    int educationpoint = 0;
                    int skillspoint = 0;
                    int certifcationspoint = 0;
                    int licensespoint = 0;
                    int rolepreferencespoint = 0;
                    int attachresumepoint = 0;
                    int attachcoverletterpoint = 0;
                    int languagespoint = 0;
                    int referencespoint = 0;
                    int supplementaryquestionspoint = 0;
                    int directiorshippoint = 0;

                    // Set Member Info
                    if (!string.IsNullOrWhiteSpace(member.ProfilePicture))
                    {
                        profilePic.ImageUrl = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberUploadPicturePaths"], member.ProfilePicture);
                    }
                    ltTitle.Text = HttpUtility.HtmlEncode(member.Title);
                    if (!string.IsNullOrWhiteSpace(member.FirstName))
                        ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
                    else
                        ltFirstName.Text = CommonFunction.GetResourceValue("LabelFirstName") + " |";

                    if (!string.IsNullOrWhiteSpace(member.Surname))
                        ltLastName.Text = HttpUtility.HtmlEncode(member.Surname);
                    else
                        ltLastName.Text = CommonFunction.GetResourceValue("LabelLastName");

                    if (!string.IsNullOrWhiteSpace(member.MultiLingualFirstName) || !string.IsNullOrWhiteSpace(member.MultiLingualSurame))
                        ltMultilingualFirstName.Text = string.Format(@"<div id='local-name'><h5><strong>{0} :</strong> 
                                                                    <span class='local-first-name'>{1}</span> <span class='loca-last-name'>{2}</span></h5></div>",
                                                                    CommonFunction.GetResourceValue("LabelLocalName"),
                                                                    HttpUtility.HtmlEncode(member.MultiLingualFirstName),
                                                                    HttpUtility.HtmlEncode(member.MultiLingualSurame)
                                                                    );
                    //ltMultilingualLastName.Text = HttpUtility.HtmlEncode(member.MultiLingualSurame);
                    ltHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
                    if (member.AvailabilityId.HasValue && member.AvailabilityId.Value > 0)
                    {
                        ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)member.AvailabilityId))));
                    }
                    else
                    {
                        ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status missing'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription(PortalEnums.Members.CurrentlySeeking.NotSeeking))));
                    }

                    if (member.AvailabilityFromDate.HasValue)
                    {
                        ltAvailableDayFrom.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-clock-o highlight'></span><span id='availability-date'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"), member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
                    }

                    if (member.LastModifiedDate.HasValue)
                        ltlLastModifiedDate.Text = string.Format(@"<div class='col-sm-6'><p class='last-modified-date'><strong>{0}:</strong> {1}</p></div>",
                                                                        CommonFunction.GetResourceValue("LabelLastModified"), member.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat));

                    ddlProfileTitle.SelectedValue = member.Title;
                    tbProfileFirstName.Text = member.FirstName;
                    tbProfileLastName.Text = member.Surname;
                    tbProfileHeadline.Text = member.PreferredJobTitle;
                    tbProfileFirstNameLocalLanguage.Text = member.MultiLingualFirstName;
                    tbProfileLastNameLocalLanguage.Text = member.MultiLingualSurame;
                    ddlProfileCurrentStatus.SelectedValue = (member.AvailabilityId.HasValue) ? member.AvailabilityId.Value.ToString() : "-1";
                    memberavailableDate.Text = (member.AvailabilityFromDate.HasValue) ? member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat) : string.Empty;

                    //set profile submitted date
                    if (member.LastProfileSubmittedDate == null)
                        ltProfileSubmittedDate.Text = CommonFunction.GetResourceValue("LabelProfileStatus") + ": " + CommonFunction.GetResourceValue("LabelNotYetSubmitted");
                    else
                        ltProfileSubmittedDate.Text = CommonFunction.GetResourceValue("LabelProfileStatus") + ": " + String.Format(CommonFunction.GetResourceValue("LabelProfileStatusSubmittedDateFormat"), member.LastProfileSubmittedDate.Value.ToString(SessionData.Site.DateFormat));

                    // Set Summary
                    if (memberWizard.SummaryPoints >= 0)
                    {
                        summarypoint = SetSummary(member, 0);
                    }
                    else
                    {
                        phNavSummary.Visible = false;
                    }
                    // Set Personal Details
                    if (memberWizard.PersonalDetailsPoints >= 0)
                    {
                        personaldetailspoint = SetPeronsalDetails(member, 0);
                    }
                    // Set Work Experience
                    if (memberWizard.ExperiencePoints >= 0)
                    {
                        workexperiencepoint = SetWorkExperience();
                    }
                    else
                    {
                        phNavWorkExperience.Visible = false;
                    }
                    // Set Education
                    if (memberWizard.EducationPoints >= 0)
                    {
                        educationpoint = SetEducation();
                    }
                    else
                    {
                        phNavEducation.Visible = false;
                    }
                    // Set Skills
                    if (memberWizard.SkillsPoints >= 0)
                    {
                        skillspoint = SetSkills(member, 0);
                    }
                    else
                    {
                        phNavSkills.Visible = false;
                    }
                    // Set Certifications & Memberships
                    if (memberWizard.MembershipsPoints >= 0)
                    {
                        certifcationspoint = SetCertifications();
                    }
                    else
                    {
                        phNavCertification.Visible = false;
                    }
                    // Set Licenses
                    if (memberWizard.LicensesPoints >= 0)
                    {
                        licensespoint = SetLicenses();
                    }
                    else
                    {
                        phNavLicenses.Visible = false;
                    }
                    // Set Role Preferences
                    if (memberWizard.RolePreferencesPoints >= 0)
                    {
                        rolepreferencespoint = SetRolePreferences(member, 0);
                    }
                    else
                    {
                        phNavRolePreferences.Visible = false;
                    }
                    // Set Attach Resume
                    if (memberWizard.CvPoints >= 0)
                    {
                        attachresumepoint = SetAttachResume(member, 0);
                    }
                    else
                    {
                        phNavResume.Visible = false;
                    }
                    // Set Attach Coverletter
                    if (memberWizard.AttachCoverLetterPoints >= 0)
                    {
                        SetAttachCoverletter();
                    }
                    else
                    {
                        phNavCoverLetter.Visible = false;
                    }
                    // Set Languages
                    if (memberWizard.LanguagesPoints >= 0)
                    {
                        languagespoint = SetLanguages(member, 0);
                    }
                    else
                    {
                        phNavLanguages.Visible = false;
                    }
                    // Set References
                    if (memberWizard.ReferencesPoints >= 0)
                    {
                        referencespoint = SetReferences(member, 0);
                    }
                    else
                    {
                        phNavReferences.Visible = false;
                    }
                    // Set Supplementary Questions
                    if (memberWizard.CustomQuestionPoints >= 0)
                    {
                        supplementaryquestionspoint = SetSupplementaryQuestions();
                    }
                    else
                    {
                        phNavCustomQuestions.Visible = false;
                    }
                    // Set Directorship
                    if (memberWizard.DirectorshipPoints >= 0)
                    {
                        directiorshippoint = SetDirectorship();
                    }
                    else
                    {
                        phNavDirectorship.Visible = false;
                    }
                    // Set Profile Progress according to the points

                    phSectionSummary.Visible = (memberWizard.SummaryPoints >= 0);
                    phSectionDirectorship.Visible = (memberWizard.DirectorshipPoints >= 0);
                    phSectionExperience.Visible = (memberWizard.ExperiencePoints >= 0);
                    phSectionEducation.Visible = (memberWizard.EducationPoints >= 0);
                    phSectionSkills.Visible = (memberWizard.SkillsPoints >= 0);
                    phSectionCertification.Visible = (memberWizard.MembershipsPoints >= 0);
                    phSectionLicense.Visible = (memberWizard.LicensesPoints >= 0);
                    phSectionRolePreference.Visible = (memberWizard.RolePreferencesPoints >= 0);
                    phSectionResume.Visible = (memberWizard.CvPoints >= 0);
                    phSectionCoverLetter.Visible = (memberWizard.AttachCoverLetterPoints >= 0);
                    phSectionLanguages.Visible = (memberWizard.LanguagesPoints >= 0);
                    phSectionReferences.Visible = (memberWizard.ReferencesPoints >= 0);
                    phSectionCustomQuestions.Visible = (memberWizard.CustomQuestionPoints >= 0);

                }
            }
        }

        private void SaveMemberInformation()
        {
            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    member.Title = ddlProfileTitle.SelectedValue;
                    member.FirstName = tbProfileFirstName.Text;
                    member.Surname = tbProfileLastName.Text;
                    member.PreferredJobTitle = tbProfileHeadline.Text;
                    member.MultiLingualFirstName = tbProfileFirstNameLocalLanguage.Text;
                    member.MultiLingualSurame = tbProfileLastNameLocalLanguage.Text;
                    member.AvailabilityId = (string.IsNullOrEmpty(ddlProfileCurrentStatus.SelectedValue)) ? (int?)null : Convert.ToInt32(ddlProfileCurrentStatus.SelectedValue);
                    if (!string.IsNullOrWhiteSpace(memberavailableDate.Text))
                        member.AvailabilityFromDate = DateTime.ParseExact(memberavailableDate.Text, SessionData.Site.DateFormat, null);
                    else
                        member.AvailabilityFromDate = null;

                    ltTitle.Text = HttpUtility.HtmlEncode(member.Title);

                    if (!string.IsNullOrWhiteSpace(member.FirstName))
                        ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
                    else
                        ltFirstName.Text = CommonFunction.GetResourceValue("LabelFirstName") + " |";

                    if (!string.IsNullOrWhiteSpace(member.Surname))
                        ltLastName.Text = HttpUtility.HtmlEncode(member.Surname);
                    else
                        ltLastName.Text = CommonFunction.GetResourceValue("LabelLastName");

                    if (!string.IsNullOrWhiteSpace(member.MultiLingualFirstName) || !string.IsNullOrWhiteSpace(member.MultiLingualSurame))
                        ltMultilingualFirstName.Text = string.Format(@"<div id='local-name'><h5><strong>{0} :</strong> 
                                                                    <span class='local-first-name'>{1}</span> <span class='loca-last-name'>{2}</span></h5></div>",
                                                                    CommonFunction.GetResourceValue("LabelLocalName"),
                                                                    HttpUtility.HtmlEncode(member.MultiLingualFirstName),
                                                                    HttpUtility.HtmlEncode(member.MultiLingualSurame)
                                                                    );
                    //ltMultilingualLastName.Text = HttpUtility.HtmlEncode(member.MultiLingualSurame);
                    ltHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
                    ltCurrentSeeking.Text = string.Empty;
                    ltAvailableDayFrom.Text = string.Empty;

                    if (member.AvailabilityId.HasValue && member.AvailabilityId.Value > 0)
                    {
                        ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)member.AvailabilityId))));
                    }
                    else
                    {
                        ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status missing'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription(PortalEnums.Members.CurrentlySeeking.NotSeeking))));
                    }

                    if (member.AvailabilityFromDate.HasValue)
                    {
                        ltAvailableDayFrom.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-clock-o highlight'></span><span id='availability-date'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"), member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
                    }


                    if (member.LastModifiedDate.HasValue)
                        ltlLastModifiedDate.Text = string.Format(@"<div class='col-sm-6'><p class='last-modified-date'><strong>{0}:</strong> {1}</p></div>",
                                                                        CommonFunction.GetResourceValue("LabelLastModified"), member.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat));

                    // Member
                    //MemberID
                    //Title
                    //FirstName
                    //Surname
                    //AvailabilityID
                    //AvailabilityFromDate
                    //PreferredJobTitle
                    //SearchField
                    //ProfilePicture
                    //MultiLingualFirstName
                    //MultiLingualSurame
                    MembersService.Update(member);
                }
            }
        }

        protected void lbProfileSave_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            string controltofocus = string.Empty;

            phProfileFirstNameError.Visible = false;
            phProfileLastNameError.Visible = false;
            phProfileTitleError.Visible = false;
            phProfileHeadlineError.Visible = false;
            phProfileAvailDateError.Visible = false;
            phProfileFirstNameLocalError.Visible = false;
            phProfileLastNameLocalError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbProfileFirstName.Text))
            {
                hasError = true;
                phProfileFirstNameError.Visible = true;
                ltErrorProfileFirstName.SetLanguageCode = "LabelRequiredField1";
                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbProfileFirstName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbProfileFirstName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phProfileFirstNameError.Visible = true;
                    ltErrorProfileFirstName.SetLanguageCode = "ValidateNoHTMLContent";
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbProfileFirstName.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbProfileLastName.Text))
            {
                hasError = true;
                phProfileLastNameError.Visible = true;
                ltErrorProfileLastName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbProfileLastName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbProfileLastName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phProfileLastNameError.Visible = true;
                    ltErrorProfileLastName.SetLanguageCode = "ValidateNoHTMLContent";
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbProfileLastName.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbProfileFirstNameLocalLanguage.Text))
            {
                if (Regex.IsMatch(tbProfileFirstNameLocalLanguage.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phProfileFirstNameLocalError.Visible = true;
                    ltErrorProfileFirstNameLocal.SetLanguageCode = "ValidateNoHTMLContent";
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbProfileFirstNameLocalLanguage.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbProfileLastNameLocalLanguage.Text))
            {
                if (Regex.IsMatch(tbProfileLastNameLocalLanguage.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phProfileLastNameLocalError.Visible = true;
                    ltErrorProfileLastNameLocal.SetLanguageCode = "ValidateNoHTMLContent";
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbProfileLastNameLocalLanguage.ClientID;
                    }
                }
            }


            if (string.IsNullOrWhiteSpace(tbProfileHeadline.Text))
            {
                hasError = true;
                phProfileHeadlineError.Visible = true;

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbProfileHeadline.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbProfileHeadline.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phProfileHeadlineError.Visible = true;
                    ucProfileHeadlineError.SetLanguageCode = "ValidateNoHTMLContent";
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbProfileHeadline.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(memberavailableDate.Text))
            {
                try
                {
                    DateTime dunCare = DateTime.ParseExact(memberavailableDate.Text, SessionData.Site.DateFormat, null);
                }
                catch
                {
                    //error date
                    hasError = true;
                    phProfileAvailDateError.Visible = true;
                    controltofocus = memberavailableDate.ClientID;
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenRepeaterDiv(string.Empty, controltofocus);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Calendar", @"
            if( $(""#memberavailableDate"").length ){
	             $(""#memberavailableDate"").datepicker({ 
	 	            minDate: new Date(1916, 1 - 1, 1),
	 	            dateFormat: """ + SessionData.Site.DateFormat.ToLower().Replace("yyyy", "yy") + @""", 
	             });
	            }", true);

                basicProfile.Attributes.Add("class", "col-sm-8 col-md-5 col-xs-12 section-content edit-mode");
                basicProfileEdit.Attributes.Add("class", "profile-edit collapse overlayEdit in");

                SetMemberPoints();
                return;
            }

            SaveMemberInformation();
            StandardResetJS();
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Calendar", @"
            if( $(""#memberavailableDate"").length ){
	             $(""#memberavailableDate"").datepicker({ 
	 	            minDate: new Date(1916, 1 - 1, 1),
	 	             dateFormat: """ + SessionData.Site.DateFormat.ToLower().Replace("yyyy", "yy") + @""",
	             });
	            }", true);

            basicProfile.Attributes.Add("class", "col-sm-8 col-md-5 col-xs-12 section-content");
            basicProfileEdit.Attributes.Add("class", "profile-edit collapse overlayEdit");

            SetMemberPoints();
        }

        protected void lbProfileSubmit_Click(object sender, EventArgs e)
        {
            phProfilePicError.Visible = false;

            SetSupplementaryQuestions();
            if (fuProfile.HasFile && fuProfile.FileContent.Length > 0)
            {
                using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (member != null)
                    {
                        if (fuProfile.HasFile && fuProfile.PostedFile.ContentLength > 0)
                        {
                            bool hasError = false;
                            string errormsg = string.Empty;
                            string filename = string.Format("Profile_{0}{1}", SessionData.Member.MemberId, System.IO.Path.GetExtension(fuProfile.PostedFile.FileName));


                            bool found = false;
                            string extension = System.IO.Path.GetExtension(fuProfile.PostedFile.FileName);
                            foreach (string ext in ConfigurationManager.AppSettings["ImageFileTypes"].Split(new char[] { ',' }))
                            {
                                if (ext == extension)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                hasError = true;
                                errormsg = "LabelUploadProfileImageInvalid";
                                // phProfileErrorType.Visible = true;
                            }

                            if (!hasError && fuProfile.PostedFile.ContentLength > 512000)
                            {
                                hasError = true;
                                errormsg = "LabelUploadProfileImageInvalidFileSize";
                                // phProfileErrorSize.Visible = true;
                            }

                            if (!hasError)
                            {
                                FileManagerService.UploadFile(bucketName, candidateFolder, filename, fuProfile.PostedFile.InputStream, out errormsg);
                                if (string.IsNullOrEmpty(errormsg))
                                {
                                    member.ProfilePicture = filename;
                                    profilePic.ImageUrl = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberUploadPicturePaths"], filename);

                                    MembersService.Update(member);
                                }
                            }
                            else
                            {
                                phProfilePicError.Visible = true;
                                ucProfilePicError.SetLanguageCode = errormsg;
                            }
                        }

                    }
                }

            }

        }

        #endregion

        #region Summary

        private int SetSummary(Entities.Members member, int point)
        {
            phNavSummary.Visible = (string.IsNullOrWhiteSpace(member.ShortBio));
            phTickSummary.Visible = !(string.IsNullOrWhiteSpace(member.ShortBio));

            if (!string.IsNullOrWhiteSpace(member.ShortBio))
            {
                ltSummary.Text = "<p>" + HttpUtility.HtmlEncode(member.ShortBio).Replace("\n", "<br />") + "</p>";
                tbSummary.Text = member.ShortBio;
            }
            else
            {
                ltSummary.Text = string.Format("<p class='empty-case_field text-center'>{0}</p>", "Add an entry"); // TODO
            }

            return 0;
        }

        private void SaveSummary()
        {
            Entities.Members member = null;
            using (member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    // Member

                    // MemberID
                    member.ShortBio = tbSummary.Text;

                    phNavSummary.Visible = (string.IsNullOrWhiteSpace(member.ShortBio));
                    phTickSummary.Visible = !(string.IsNullOrWhiteSpace(member.ShortBio));

                    ltSummary.Text = "<p>" + HttpUtility.HtmlEncode(tbSummary.Text).Replace("\n", "<br />") + "</p>";
                    MembersService.Update(member);
                }
            }
        }

        protected void lbSummarySave_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            string controltofocus = string.Empty;

            phSummaryError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbSummary.Text))
            {
                hasError = true;
                phSummaryError.Visible = true;
                ucSummaryError.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbSummary.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbSummary.Text.Replace("\n", ""), ContentValidationRegex) == false)
                {
                    hasError = true;
                    phSummaryError.Visible = true;
                    ucSummaryError.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbSummary.ClientID;
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenRepeaterDiv(string.Empty, controltofocus);

                acSummary.Attributes.Add("class", "section-content edit-mode");
                ecSummary.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            SaveSummary();

            StandardResetJS();
            acSummary.Attributes.Add("class", "section-content");
            ecSummary.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Personal Details

        private int SetPeronsalDetails(Entities.Members member, int point)
        {
            ltEmail.Text = HttpUtility.HtmlEncode(member.EmailAddress);
            ltDateOfBirth.Text = string.Empty;
            ltAddress1.Text = string.Empty;
            ltAddress2.Text = string.Empty;
            ltCity.Text = string.Empty;
            ltState.Text = string.Empty;
            ltPostcode.Text = string.Empty;
            ltCountry.Text = string.Empty;
            ltSecondaryEmail.Text = string.Empty;
            ltPhoneNumber.Text = string.Empty;
            ltMobileNumber.Text = string.Empty;
            ltPassportNumber.Text = string.Empty;
            ltMailingAddress1.Text = string.Empty;
            ltMailingAddress2.Text = string.Empty;
            ltMailingCity.Text = string.Empty;
            ltMailingState.Text = string.Empty;
            ltMailingPostcode.Text = string.Empty;
            ltMailingCountry.Text = string.Empty;
            ltLineSelected.Text = string.Empty;

            //DOB
            if (member.DateOfBirth.HasValue)
                ltDateOfBirth.Text = string.Format("<span class='highlight dob-heading'>{0}</span><span class='personal-detail-content dob'>{1}</span>", CommonFunction.GetResourceValue("LabelDateOfBirth"), member.DateOfBirth.Value.ToString(SessionData.Site.DateFormat));
            else
                ltDateOfBirth.Text = string.Format("<span class='highlight dob-heading'>{0}</span><span class='personal-detail-content dob missing'>{1}</span>", CommonFunction.GetResourceValue("LabelDateOfBirth"), CommonFunction.GetResourceValue("LabelMissingInformation"));

            //gender
            if (string.IsNullOrWhiteSpace(member.Gender))
            {
                ltGender.Text = string.Format("<span class='highlight gender-heading'>{0}</span><span class='personal-detail-content gender-detail missing'>{1}</span>", CommonFunction.GetResourceValue("LabelGender"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                string genderDisplay = member.Gender == "M" ? CommonFunction.GetResourceValue("LabelMale") : CommonFunction.GetResourceValue("LabelFemale");

                ltGender.Text = string.Format("<span class='highlight gender-heading'>{0}</span><span class='personal-detail-content gender-detail'>{1}</span>", CommonFunction.GetResourceValue("LabelGender"), genderDisplay);
            }

            //address
            if (string.IsNullOrWhiteSpace(member.Address1)
                && string.IsNullOrWhiteSpace(member.Address2)
                && string.IsNullOrWhiteSpace(member.Suburb)
                && string.IsNullOrWhiteSpace(member.States)
                && string.IsNullOrWhiteSpace(member.PostCode)
                && member.CountryId == 0
            )
            {
                ltAddress1.Text = string.Format("<span class='address1 missing'>{0}</span>", CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(member.Address1))
                    ltAddress1.Text = string.Format("<span class='address1'>{0}</span>", HttpUtility.HtmlEncode(member.Address1));

                if (!string.IsNullOrWhiteSpace(member.Address2))
                    ltAddress2.Text = string.Format("<span class='address2'>{0}</span>", HttpUtility.HtmlEncode(member.Address2));
                if (!string.IsNullOrWhiteSpace(member.Suburb))
                    ltCity.Text = string.Format("<span class='addCity'>{0}</span>", HttpUtility.HtmlEncode(member.Suburb));
                if (!string.IsNullOrWhiteSpace(member.States))
                    ltState.Text = string.Format("<span class='addState'>{0}</span>", HttpUtility.HtmlEncode(member.States));
                if (!string.IsNullOrWhiteSpace(member.PostCode))
                    ltPostcode.Text = string.Format("<span class='addPostcode'>{0}</span>", HttpUtility.HtmlEncode(member.PostCode));
                foreach (ListItem listitem in ddlDetailsCountry.Items)
                {
                    if (listitem.Value == member.CountryId.ToString())
                    {
                        ltCountry.Text = string.Format("<span class='addCountry'>{0}</span>", HttpUtility.HtmlEncode(listitem.Text));
                        break;
                    }
                }
            }

            //second email
            if (string.IsNullOrWhiteSpace(member.SecondaryEmail))
                ltSecondaryEmail.Text = string.Format("<span class='highlight secondary-email-heading'>{0}</span><span class='personal-detail-content secondary-email missing'>{1}</span>", CommonFunction.GetResourceValue("LabelSecondaryEmail"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            else
                ltSecondaryEmail.Text = string.Format("<span class='highlight secondary-email-heading'>{0}</span><span class='personal-detail-content secondary-email'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelSecondaryEmail"), HttpUtility.HtmlEncode(member.SecondaryEmail));

            //homephone
            if (string.IsNullOrWhiteSpace(member.HomePhone))
                ltPhoneNumber.Text = string.Format("<span class='highlight ph_home_numb-heading'>{0}</span><span class='personal-detail-content ph_home_numb missing'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPhoneHome"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            else
                ltPhoneNumber.Text = string.Format("<span class='highlight ph_home_numb-heading'>{0}</span><span class='personal-detail-content ph_home_numb'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPhoneHome"), HttpUtility.HtmlEncode(member.HomePhone));

            //mobile
            if (string.IsNullOrWhiteSpace(member.MobilePhone))
                ltMobileNumber.Text = string.Format("<span class='highlight ph_mobile_numb-heading'>{0}</span><span class='personal-detail-content ph_mobile_numb missing'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPhoneMobile"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            else
                ltMobileNumber.Text = string.Format("<span class='highlight ph_mobile_numb-heading'>{0}</span><span class='personal-detail-content ph_mobile_numb'>{1}</span>",
                                        CommonFunction.GetResourceValue("LabelPhoneMobile"), HttpUtility.HtmlEncode(member.MobilePhone));

            //passport number
            if (string.IsNullOrWhiteSpace(member.PassportNo))
                ltPassportNumber.Text = string.Format("<span class='highlight ph_passport_numb-heading'>{0}</span><span class='personal-detail-content ph_passport_numb missing'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPassportNumber"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            else
                ltPassportNumber.Text = string.Format("<span class='highlight ph_passport_numb-heading'>{0}</span><span class='personal-detail-content ph_passport_numb'>{1}</span>",
                                        CommonFunction.GetResourceValue("LabelPassportNumber"), HttpUtility.HtmlEncode(member.PassportNo));

            //mailing address
            if (string.IsNullOrWhiteSpace(member.MailingAddress1)
                && string.IsNullOrWhiteSpace(member.MailingAddress2)
                && string.IsNullOrWhiteSpace(member.MailingSuburb)
                && string.IsNullOrWhiteSpace(member.MailingStates)
                && string.IsNullOrWhiteSpace(member.MailingPostCode)
            )
            {
                ltMailingAddress1.Text = string.Format("<span class='mailing-address1 missing'>{0}</span>", CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(member.MailingAddress1))
                    ltMailingAddress1.Text = string.Format("<span class='mailing-address1'>{0}</span>", HttpUtility.HtmlEncode(member.MailingAddress1));
                if (!string.IsNullOrWhiteSpace(member.MailingAddress2))
                    ltMailingAddress2.Text = string.Format("<span class='mailing-address2'>{0}</span>", HttpUtility.HtmlEncode(member.MailingAddress2));
                if (!string.IsNullOrWhiteSpace(member.MailingSuburb))
                    ltMailingCity.Text = string.Format("<span class='mailing-City'>{0}</span>", HttpUtility.HtmlEncode(member.MailingSuburb));
                if (!string.IsNullOrWhiteSpace(member.MailingStates))
                    ltMailingState.Text = string.Format("<span class='mailing-State'>{0}</span>", HttpUtility.HtmlEncode(member.MailingStates));
                if (!string.IsNullOrWhiteSpace(member.MailingPostCode))
                    ltMailingPostcode.Text = string.Format("<span class='mailing-Postcode'>{0}</span>", HttpUtility.HtmlEncode(member.MailingPostCode));

                if (member.MailingCountryId.HasValue)
                {
                    foreach (ListItem listitem in ddlDetailsMailingCountry.Items)
                    {
                        if (listitem.Value == member.MailingCountryId.ToString())
                        {
                            ltMailingCountry.Text = string.Format("<span class='addCountry'>{0}</span>", HttpUtility.HtmlEncode(listitem.Text));
                            break;
                        }
                    }
                }
            }

            //preferred line
            if (member.PreferredLine == 0)
            {
                ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content missing'><span class='preferred-line'>{1}</span></span>",
                                                    CommonFunction.GetResourceValue("LabelPreferredLine"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                if (member.PreferredLine == 1)
                {
                    ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content'><span class='preferred-line'>{1}</span></span>",
                                                        CommonFunction.GetResourceValue("LabelPreferredLine"), HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneHome")));
                }
                else if (member.PreferredLine == 2)
                {
                    ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content'><span class='preferred-line'>{1}</span></span>",
                                                        CommonFunction.GetResourceValue("LabelPreferredLine"), HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneMobile")));
                }
            }


            tbDetailsPrimaryEmail.Text = member.EmailAddress;
            tbDetailsSecondaryEmail.Text = member.SecondaryEmail;
            if (!string.IsNullOrWhiteSpace(member.Gender))
            {
                if (member.Gender == "M")
                    rbDetailsMale.Checked = true;
                else
                    rbDetailsFemale.Checked = true;
            }

            if (member.DateOfBirth.HasValue)
            {
                ddlDetailsDay.SelectedValue = member.DateOfBirth.Value.Day.ToString();
                ddlDetailsMonth.SelectedValue = member.DateOfBirth.Value.Month.ToString();
                ddlDetailsYear.SelectedValue = member.DateOfBirth.Value.Year.ToString();
            }

            tbDetailsHomePhone.Text = !string.IsNullOrWhiteSpace(member.HomePhone) ? member.HomePhone.Trim() : string.Empty;
            rbPreferHomePhone.Checked = (member.PreferredLine == 1);
            tbDetailsMobilePhone.Text = !string.IsNullOrWhiteSpace(member.MobilePhone) ? member.MobilePhone.Trim() : string.Empty;
            rbPreferMobilePhone.Checked = (member.PreferredLine == 2);

            tbDetailsAddress1.Text = member.Address1;
            tbDetailsAddress2.Text = member.Address2;
            tbDetailsSuburb.Text = member.Suburb;
            tbDetailsState.Text = member.States;
            tbDetailsPostcode.Text = member.MailingPostCode;
            if (member.CountryId > 0)
            {
                ddlDetailsCountry.SelectedValue = member.CountryId.ToString();
            }
            tbDetailsPassportNumber.Text = member.PassportNo;
            tbDetailsVideoURL.Text = member.VideoUrl;
            // cbDetailsSameAsAbove.Text = member.EmailAddress;
            tbDetailsMailingAddress1.Text = member.MailingAddress1;
            tbDetailsMailingAddress2.Text = member.MailingAddress2;
            tbDetailsMailingSuburb.Text = member.MailingSuburb;
            tbDetailsMailingState.Text = member.MailingStates;
            tbDetailsMailingPostcode.Text = member.MailingPostCode;
            if (member.MailingCountryId.HasValue)
            {
                ddlDetailsMailingCountry.SelectedValue = member.MailingCountryId.ToString();
            }

            return 0;
        }

        private void SavePeronsalDetails()
        {
            bool hasError = false;
            string controltofocus = string.Empty;

            phDetailsDOBError.Visible = false;
            phDetailsSecondaryEmailError.Visible = false;

            if (ddlDetailsDay.SelectedValue != "" && ddlDetailsMonth.SelectedValue != "" && ddlDetailsYear.SelectedValue != "")
            {
                DateTime dob = DateTime.Now;

                if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", ddlDetailsDay.SelectedValue, ddlDetailsMonth.SelectedValue, ddlDetailsYear.SelectedValue), out dob))
                {
                    hasError = true;
                    phDetailsDOBError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlDetailsDay.ClientID;
                    }
                }
                else
                {
                    if (dob >= DateTime.Now)
                    {
                        hasError = true;
                        phDetailsDOBError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlDetailsDay.ClientID;
                        }
                    }
                }

            }

            if (!string.IsNullOrEmpty(tbDetailsSecondaryEmail.Text))
            {
                if (Utils.VerifyEmail(tbDetailsSecondaryEmail.Text) == false)
                {
                    hasError = true;
                    phDetailsSecondaryEmailError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDetailsSecondaryEmail.ClientID;
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenRepeaterDiv(string.Empty, controltofocus);
                personalDetailsform.Attributes.Add("class", "personalDetails-form form-all collapse in");

                return;
            }

            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    member.SecondaryEmail = tbDetailsSecondaryEmail.Text;

                    if (ddlDetailsDay.SelectedValue != "" && ddlDetailsMonth.SelectedValue != "" && ddlDetailsYear.SelectedValue != "")
                    {
                        member.DateOfBirth = new DateTime(Convert.ToInt32(ddlDetailsYear.SelectedValue), Convert.ToInt32(ddlDetailsMonth.SelectedValue), Convert.ToInt32(ddlDetailsDay.SelectedValue));
                    }
                    else
                    {
                        member.DateOfBirth = (DateTime?)null;
                    }

                    if (rbDetailsMale.Checked)
                    {
                        member.Gender = "M";
                    }
                    if (rbDetailsFemale.Checked)
                    {
                        member.Gender = "F";
                    }

                    member.HomePhone = tbDetailsHomePhone.Text;
                    member.MobilePhone = tbDetailsMobilePhone.Text;
                    member.Address1 = tbDetailsAddress1.Text;
                    member.Address2 = tbDetailsAddress2.Text;
                    member.Suburb = tbDetailsSuburb.Text;
                    member.States = tbDetailsState.Text;
                    member.PostCode = tbDetailsPostcode.Text;
                    member.CountryId = (string.IsNullOrEmpty(ddlDetailsCountry.SelectedValue)) ? 0 : Convert.ToInt32(ddlDetailsCountry.SelectedValue);
                    member.PassportNo = tbDetailsPassportNumber.Text;
                    member.VideoUrl = tbDetailsVideoURL.Text;

                    if (cbDetailsSameAsAbove.Checked)
                    {
                        tbDetailsMailingAddress1.Text = tbDetailsAddress1.Text;
                        tbDetailsMailingAddress2.Text = tbDetailsAddress2.Text;
                        tbDetailsMailingSuburb.Text = tbDetailsSuburb.Text;
                        tbDetailsMailingState.Text = tbDetailsState.Text;
                        tbDetailsMailingPostcode.Text = tbDetailsPostcode.Text;
                        ddlDetailsMailingCountry.SelectedValue = ddlDetailsCountry.SelectedValue;
                    }
                    member.MailingAddress1 = tbDetailsMailingAddress1.Text;
                    member.MailingAddress2 = tbDetailsMailingAddress2.Text;
                    member.MailingSuburb = tbDetailsMailingSuburb.Text;
                    member.MailingStates = tbDetailsMailingState.Text;
                    member.MailingPostCode = tbDetailsMailingPostcode.Text;
                    member.MailingCountryId = (string.IsNullOrEmpty(ddlDetailsMailingCountry.SelectedValue)) ? (int?)null : Convert.ToInt32(ddlDetailsMailingCountry.SelectedValue);
                    if (rbPreferHomePhone.Checked)
                    {
                        member.PreferredLine = 1;
                    }

                    if (rbPreferMobilePhone.Checked)
                    {
                        member.PreferredLine = 2;
                    }

                    //ltEmail.Text = HttpUtility.HtmlEncode(member.EmailAddress);
                    //ltDateOfBirth.Text = (member.DateOfBirth.HasValue) ? member.DateOfBirth.Value.ToString("dd/MM/yyyy") : string.Empty;
                    //ltGender.Text = member.Gender;
                    //ltAddress1.Text = HttpUtility.HtmlEncode(member.Address1);
                    //ltAddress2.Text = HttpUtility.HtmlEncode(member.Address2);
                    //ltCity.Text = HttpUtility.HtmlEncode(member.Suburb);
                    //ltState.Text = HttpUtility.HtmlEncode(member.States);
                    //ltPostcode.Text = HttpUtility.HtmlEncode(member.PostCode);
                    //ltCountry.Text = HttpUtility.HtmlEncode(member.CountryName);

                    ////ltSecondaryEmail.Text = HttpUtility.HtmlEncode(member.SecondaryEmail);
                    //ltSecondaryEmail.Text = string.Format("<span class='highlight'>{0}</span><span class='personal-detail-content secondary-email'>{1}</span>",
                    //                                    CommonFunction.GetResourceValue("LabelSecondaryEmail"), HttpUtility.HtmlEncode(member.SecondaryEmail));

                    //ltPhoneNumber.Text = HttpUtility.HtmlEncode(member.HomePhone);
                    //ltMobileNumber.Text = HttpUtility.HtmlEncode(member.MobilePhone);
                    //ltPassportNumber.Text = HttpUtility.HtmlEncode(member.PassportNo);
                    //ltMailingAddress1.Text = HttpUtility.HtmlEncode(member.MailingAddress1);
                    //ltMailingAddress2.Text = HttpUtility.HtmlEncode(member.MailingAddress2);
                    //ltMailingCity.Text = HttpUtility.HtmlEncode(member.MailingSuburb);
                    //ltMailingState.Text = HttpUtility.HtmlEncode(member.MailingStates);
                    //ltMailingPostcode.Text = HttpUtility.HtmlEncode(member.MailingPostCode);
                    //ltMailingCountry.Text = HttpUtility.HtmlEncode(member.MailingCountryName);

                    MembersService.Update(member);

                    // Set the personal details
                    SetPeronsalDetails(member, 0);

                    StandardResetJS();
                    personalDetailsform.Attributes.Add("class", "personalDetails-form form-all collapse");
                    OpenAddDiv(string.Empty, "section-3");

                    //scroll to next section
                    ScrollToNextSectionJS(lbDetailsSave.ClientID);
                }
            }
        }

        protected void lbDetailsSave_Click(object sender, EventArgs e)
        {
            SavePeronsalDetails();
            SetMemberPoints();
        }

        #endregion

        #region Directorship

        private int SetDirectorship()
        {
            using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
            {
                memberpositions.Filter = "isDirectorship = true";
                rptDirectorship.DataSource = memberpositions.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptDirectorship.DataBind();

                phNavDirectorship.Visible = (memberpositions.Count == 0);
                phAddEntryTextDirectorship.Visible = (memberpositions.Count == 0);
                phTickDirectorship.Visible = (memberpositions.Count > 0);
            }
            return 0;
        }

        private void DeleteDirectorship(int directorshipid)
        {
            using (MemberPositions memberposition = MemberPositionsService.GetByMemberPositionId(directorshipid))
            {
                if (memberposition != null && memberposition.MemberId == SessionData.Member.MemberId)
                {
                    MemberPositionsService.Delete(memberposition);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptDirectorship_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acDirectorshipAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newDirectorshipExperience.Attributes.Add("class", "profile-edit collapse");

            Literal ltDirectorshipCompanyName = e.Item.FindControl("ltDirectorshipCompanyName") as Literal;
            PlaceHolder phDirectorshipCompanyNameError = e.Item.FindControl("phDirectorshipCompanyNameError") as PlaceHolder;
            ucLanguageLiteral ltErrorDirectorshipCompanyName = e.Item.FindControl("ltErrorDirectorshipCompanyName") as ucLanguageLiteral;
            Literal ltDirectorshipJobTitle = e.Item.FindControl("ltDirectorshipJobTitle") as Literal;
            PlaceHolder phDirectorshipJobTitleError = e.Item.FindControl("phDirectorshipJobTitleError") as PlaceHolder;
            ucLanguageLiteral ltErrorDirectorshipJobTitle = e.Item.FindControl("ltErrorDirectorshipJobTitle") as ucLanguageLiteral;
            PlaceHolder phDirectorshipWebsiteError = e.Item.FindControl("phDirectorshipWebsiteError") as PlaceHolder;
            ucLanguageLiteral ltErrorDirectorshipWebsite = e.Item.FindControl("ltErrorDirectorshipWebsite") as ucLanguageLiteral;

            //HyperLink hlDirectorshipWebsite = e.Item.FindControl("hlDirectorshipWebsite") as HyperLink;
            Literal ltDirectorshipWebsite = e.Item.FindControl("ltDirectorshipWebsite") as Literal;
            Literal ltDirectorshipDateTime = e.Item.FindControl("ltDirectorshipDateTime") as Literal;
            Literal ltDirectorshipDescription = e.Item.FindControl("ltDirectorshipDescription") as Literal;
            Literal ltDirectorshipResponsibilities = e.Item.FindControl("ltDirectorshipResponsibilities") as Literal;
            Literal ltDirectorshipTypes = e.Item.FindControl("ltDirectorshipTypes") as Literal;
            Literal ltDirectorshipAdditionalRoles = e.Item.FindControl("ltDirectorshipAdditionalRoles") as Literal;
            TextBox tbDirectorshipJobTitle = e.Item.FindControl("tbDirectorshipJobTitle") as TextBox;
            TextBox tbDirectorshipCompanyName = e.Item.FindControl("tbDirectorshipCompanyName") as TextBox;
            TextBox tbDirectorshipWebsite = e.Item.FindControl("tbDirectorshipWebsite") as TextBox;
            DropDownList ddlDirectorshipStartMonth = e.Item.FindControl("ddlDirectorshipStartMonth") as DropDownList;
            DropDownList ddlDirectorshipStartYear = e.Item.FindControl("ddlDirectorshipStartYear") as DropDownList;
            DropDownList ddlDirectorshipEndMonth = e.Item.FindControl("ddlDirectorshipEndMonth") as DropDownList;
            DropDownList ddlDirectorshipEndYear = e.Item.FindControl("ddlDirectorshipEndYear") as DropDownList;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipCurrent = e.Item.FindControl("cbDirectorshipCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            TextBox tbDirectorshipSummary = e.Item.FindControl("tbDirectorshipSummary") as TextBox;
            TextBox tbDirectorshipResponsibilities = e.Item.FindControl("tbDirectorshipResponsibilities") as TextBox;
            DropDownList ddlDirectorshipType = e.Item.FindControl("ddlDirectorshipType") as DropDownList;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipAuditCommittee = e.Item.FindControl("cbDirectorshipAuditCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipRiskCommittee = e.Item.FindControl("cbDirectorshipRiskCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipNominationsCommittee = e.Item.FindControl("cbDirectorshipNominationsCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipRemunerationCommittee = e.Item.FindControl("cbDirectorshipRemunerationCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipOHSCommittee = e.Item.FindControl("cbDirectorshipOHSCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipOther = e.Item.FindControl("cbDirectorshipOther") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            LinkButton lbDirectorshipSave = e.Item.FindControl("lbDirectorshipSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlAnchor aDirectorshipEdit = e.Item.FindControl("aDirectorshipEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            PlaceHolder phDirectorshipEndError = e.Item.FindControl("phDirectorshipEndError") as PlaceHolder;
            ucLanguageLiteral ltErroDirectorshipEnd = e.Item.FindControl("DirectorshipEnd") as ucLanguageLiteral;

            System.Web.UI.HtmlControls.HtmlGenericControl acDirectorship = e.Item.FindControl("acDirectorship") as System.Web.UI.HtmlControls.HtmlGenericControl;

            PlaceHolder phDirectorshipSummaryError = e.Item.FindControl("phDirectorshipSummaryError") as PlaceHolder;
            ucLanguageLiteral ltErrorDirectorshipSummary = e.Item.FindControl("ltErrorDirectorshipSummary") as ucLanguageLiteral;
            PlaceHolder phDirectorshipResponsibilitiesError = e.Item.FindControl("phDirectorshipResponsibilitiesError") as PlaceHolder;
            ucLanguageLiteral ltErrorDirectorshipResponsibilities = e.Item.FindControl("ltErrorDirectorshipResponsibilities") as ucLanguageLiteral;

            ddlDirectorshipEndMonth.Enabled = !(cbDirectorshipCurrent.Checked);
            ddlDirectorshipEndYear.Enabled = !(cbDirectorshipCurrent.Checked);

            if (e.CommandName == "DirectorshipSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;
                phDirectorshipEndError.Visible = false;
                phDirectorshipCompanyNameError.Visible = false;
                phDirectorshipJobTitleError.Visible = false;
                phDirectorshipWebsiteError.Visible = false;
                phDirectorshipSummaryError.Visible = false;
                phDirectorshipResponsibilitiesError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbDirectorshipJobTitle.Text))
                {
                    hasError = true;
                    phDirectorshipJobTitleError.Visible = true;
                    ltErrorDirectorshipJobTitle.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipJobTitle.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbDirectorshipJobTitle.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phDirectorshipJobTitleError.Visible = true;
                        ltErrorDirectorshipJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbDirectorshipJobTitle.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbDirectorshipCompanyName.Text))
                {
                    hasError = true;
                    phDirectorshipCompanyNameError.Visible = true;
                    ltErrorDirectorshipCompanyName.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipCompanyName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbDirectorshipCompanyName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phDirectorshipCompanyNameError.Visible = true;
                        ltErrorDirectorshipCompanyName.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbDirectorshipCompanyName.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbDirectorshipWebsite.Text))
                {
                    if (Regex.IsMatch(tbDirectorshipWebsite.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phDirectorshipWebsiteError.Visible = true;
                        ltErrorDirectorshipWebsite.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbDirectorshipWebsite.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbDirectorshipSummary.Text))
                {
                    if (Regex.IsMatch(tbDirectorshipSummary.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phDirectorshipSummaryError.Visible = true;
                        ltErrorDirectorshipSummary.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbDirectorshipSummary.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbDirectorshipResponsibilities.Text))
                {
                    if (Regex.IsMatch(tbDirectorshipResponsibilities.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phDirectorshipResponsibilitiesError.Visible = true;
                        ltErrorDirectorshipResponsibilities.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbDirectorshipResponsibilities.ClientID;
                        }
                    }
                }

                if ((ddlDirectorshipStartYear.SelectedValue == "0" || ddlDirectorshipStartMonth.SelectedValue == "0")
                || DateTime.Now < new DateTime(Convert.ToInt32(ddlDirectorshipStartYear.SelectedValue), Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue), 1))
                {
                    hasError = true;
                    phDirectorshipEndError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlDirectorshipStartMonth.ClientID;
                    }
                }

                // Date Error Checking
                if (!cbDirectorshipCurrent.Checked)
                {
                    if (ddlDirectorshipEndYear.SelectedValue == "0" || ddlDirectorshipEndMonth.SelectedValue == "0"
                        || (Convert.ToInt32(ddlDirectorshipStartYear.SelectedValue) > Convert.ToInt32(ddlDirectorshipEndYear.SelectedValue))
                        || ((Convert.ToInt32(ddlDirectorshipEndYear.SelectedValue) == Convert.ToInt32(ddlDirectorshipStartYear.SelectedValue) && (Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue) < Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue)))))
                    {
                        phDirectorshipEndError.Visible = true;
                        hasError = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlDirectorshipStartMonth.ClientID;
                        }
                    }
                }

                if (hasError)
                {
                    StandardResetJS();
                    OpenRepeaterDiv(string.Empty, controltofocus);
                    acDirectorship.Attributes.Add("class", "section-content edit-mode");

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "DirectorshipError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-DirectorshipExperience" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);

                    return;
                }


                using (MemberPositions directorship = MemberPositionsService.GetByMemberPositionId(Convert.ToInt32(e.CommandArgument)))
                {

                    if (directorship != null)
                    {


                        directorship.CompanyName = tbDirectorshipCompanyName.Text;
                        directorship.Title = tbDirectorshipJobTitle.Text;

                        directorship.StartMonth = Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue);
                        directorship.StartYear = Convert.ToInt32(ddlDirectorshipStartYear.SelectedValue);

                        directorship.EndMonth = Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue);
                        directorship.EndYear = Convert.ToInt32(ddlDirectorshipEndYear.SelectedValue);

                        directorship.IsCurrent = cbDirectorshipCurrent.Checked;
                        if (cbDirectorshipCurrent.Checked)
                        {
                            ddlDirectorshipEndMonth.Enabled = false;
                            ddlDirectorshipEndYear.Enabled = false;

                            directorship.EndMonth = null;
                            directorship.EndYear = null;
                        }

                        directorship.OrganisationWebsite = tbDirectorshipWebsite.Text;
                        directorship.Summary = tbDirectorshipSummary.Text;
                        directorship.ResponsibilitiesAndAchievements = tbDirectorshipResponsibilities.Text;
                        directorship.TypeOfDirectorship = ddlDirectorshipType.SelectedValue;

                        string additionRolesResponsibilities = string.Empty;
                        if (cbDirectorshipAuditCommittee.Checked)
                        {
                            additionRolesResponsibilities += "AuditCommittee" + ",";
                        }
                        if (cbDirectorshipRiskCommittee.Checked)
                        {
                            additionRolesResponsibilities += "RiskCommittee" + ",";
                        }
                        if (cbDirectorshipNominationsCommittee.Checked)
                        {
                            additionRolesResponsibilities += "NominationsCommittee" + ",";
                        }
                        if (cbDirectorshipRemunerationCommittee.Checked)
                        {
                            additionRolesResponsibilities += "RemunerationCommittee" + ",";
                        }
                        if (cbDirectorshipOHSCommittee.Checked)
                        {
                            additionRolesResponsibilities += "OHSCommittee" + ",";
                        }
                        if (cbDirectorshipOther.Checked)
                        {
                            additionRolesResponsibilities += "Other" + ",";
                        }

                        directorship.AdditionalRolesAndResponsibilities = additionRolesResponsibilities.TrimEnd(new char[] { ',' });

                        MemberPositionsService.Update(directorship);
                        UpdateMemberLastModified();

                        string experiencedate = string.Empty;
                        DateTime StartDate = new DateTime(directorship.StartYear.Value, directorship.StartMonth.Value, 1);
                        DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        if (!directorship.IsCurrent && directorship.EndYear.HasValue && directorship.EndMonth.HasValue)
                        {
                            EndDate = new DateTime(directorship.EndYear.Value, directorship.EndMonth.Value, 1);
                        }
                        TimeSpan timespan = EndDate.Subtract(StartDate);

                        string startmonth = string.Empty;
                        string endmonth = string.Empty;
                        string duration = string.Empty;
                        DateTime timespandt = DateTime.MinValue + timespan;

                        foreach (ListItem month in ddlDirectorshipStartMonth.Items)
                        {
                            if (month.Value == directorship.StartMonth.Value.ToString())
                            {
                                startmonth = CommonFunction.GetResourceValue(month.Text);
                                break;
                            }
                        }
                        if (directorship.EndMonth.HasValue)
                        {
                            foreach (ListItem month in ddlDirectorshipEndMonth.Items)
                            {
                                if (month.Value == directorship.EndMonth.Value.ToString())
                                {
                                    endmonth = CommonFunction.GetResourceValue(month.Text);
                                    break;
                                }
                            }
                        }

                        if (timespandt.Year - 1 > 0)
                        {
                            duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                        }

                        if (timespandt.Month - 1 > 0)
                        {
                            if (!string.IsNullOrWhiteSpace(duration))
                            {
                                duration += ", ";
                            }

                            duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                        }

                        if (timespandt.Year == 1 && timespandt.Month == 1)
                        {
                            duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                        }

                        if (directorship.IsCurrent)
                        {
                            experiencedate = string.Format("{0} {1} - {2} / ({3})", startmonth, directorship.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                        }
                        else
                        {
                            experiencedate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, directorship.StartYear, endmonth, directorship.EndYear, duration);
                        }



                        ltDirectorshipCompanyName.Text = HttpUtility.HtmlEncode(directorship.CompanyName);
                        ltDirectorshipJobTitle.Text = HttpUtility.HtmlEncode(directorship.Title);

                        ltDirectorshipDateTime.Text = experiencedate;
                        ltDirectorshipDescription.Text = HttpUtility.HtmlEncode(directorship.Summary).Replace("\n", "<br />");
                        ltDirectorshipResponsibilities.Text = HttpUtility.HtmlEncode(directorship.ResponsibilitiesAndAchievements).Replace("\n", "<br />");
                        ltDirectorshipTypes.Text = ddlDirectorshipType.SelectedItem.Text;

                        ltDirectorshipAdditionalRoles.Text = string.Empty;
                        if (cbDirectorshipAuditCommittee.Checked || cbDirectorshipRiskCommittee.Checked ||
                        cbDirectorshipNominationsCommittee.Checked || cbDirectorshipRemunerationCommittee.Checked ||
                        cbDirectorshipOHSCommittee.Checked || cbDirectorshipOther.Checked)
                        {
                            ltDirectorshipAdditionalRoles.Text = "<strong>" + HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelAdditionalRolesAndResponsibilities")) + ":</strong> ";

                            if (cbDirectorshipAuditCommittee.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbAuditCommittee") + ", ");
                            }
                            if (cbDirectorshipRiskCommittee.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbRiskCommittee") + ", ");
                            }
                            if (cbDirectorshipNominationsCommittee.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbNominationsCommittee") + ", ");
                            }
                            if (cbDirectorshipRemunerationCommittee.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbRemunerationCommittee") + ", ");
                            }
                            if (cbDirectorshipOHSCommittee.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbOHSCommittee") + ", ");
                            }
                            if (cbDirectorshipOther.Checked)
                            {
                                ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbOther") + ", ");
                            }

                            ltDirectorshipAdditionalRoles.Text = ltDirectorshipAdditionalRoles.Text.TrimEnd(new char[] { ',', ' ' });
                        }



                        if (!string.IsNullOrEmpty(tbDirectorshipWebsite.Text))
                        {
                            ltDirectorshipWebsite.Text = string.Format("<h4 class='director-website'><a href='{0}' target='_blank'>{0}</a></h4>", directorship.OrganisationWebsite);
                            //hlDirectorshipWebsite.Visible = true;
                            //hlDirectorshipWebsite.Text = tbDirectorshipWebsite.Text;
                            //hlDirectorshipWebsite.NavigateUrl = tbDirectorshipWebsite.Text;
                        }
                        else
                        {
                            //hlDirectorshipWebsite.Visible = false;
                        }

                    }
                }
            }

            if (e.CommandName == "DirectorshipDelete")
            {
                DeleteDirectorship(Convert.ToInt32(e.CommandArgument));

                /*using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    memberpositions.Filter = "isDirectorship = true";
                    rptDirectorship.DataSource = memberpositions;
                    rptDirectorship.DataBind();

                    phNavDirectorship.Visible = (memberpositions.Count == 0);
                    phAddEntryTextDirectorship.Visible = (memberpositions.Count == 0);
                    phTickDirectorship.Visible = (memberpositions.Count > 0);
                }*/
            }

            LoadCalendar();

            SetDirectorship();


            StandardResetJS();

            acDirectorship.Attributes.Add("class", "section-content");

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "DirectorshipNoError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-DirectorshipExperience" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);
            SetMemberPoints();
        }

        protected void rptDirectorship_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltDirectorshipCompanyName = e.Item.FindControl("ltDirectorshipCompanyName") as Literal;
                Literal ltDirectorshipJobTitle = e.Item.FindControl("ltDirectorshipJobTitle") as Literal;
                //HyperLink hlDirectorshipWebsite = e.Item.FindControl("hlDirectorshipWebsite") as HyperLink;

                Literal ltDirectorshipWebsite = e.Item.FindControl("ltDirectorshipWebsite") as Literal;
                Literal ltDirectorshipDateTime = e.Item.FindControl("ltDirectorshipDateTime") as Literal;
                Literal ltDirectorshipDescription = e.Item.FindControl("ltDirectorshipDescription") as Literal;
                Literal ltDirectorshipResponsibilities = e.Item.FindControl("ltDirectorshipResponsibilities") as Literal;
                Literal ltDirectorshipTypes = e.Item.FindControl("ltDirectorshipTypes") as Literal;
                Literal ltDirectorshipAdditionalRoles = e.Item.FindControl("ltDirectorshipAdditionalRoles") as Literal;

                TextBox tbDirectorshipJobTitle = e.Item.FindControl("tbDirectorshipJobTitle") as TextBox;
                TextBox tbDirectorshipCompanyName = e.Item.FindControl("tbDirectorshipCompanyName") as TextBox;
                TextBox tbDirectorshipWebsite = e.Item.FindControl("tbDirectorshipWebsite") as TextBox;
                DropDownList ddlDirectorshipStartMonth = e.Item.FindControl("ddlDirectorshipStartMonth") as DropDownList;
                DropDownList ddlDirectorshipStartYear = e.Item.FindControl("ddlDirectorshipStartYear") as DropDownList;
                DropDownList ddlDirectorshipEndMonth = e.Item.FindControl("ddlDirectorshipEndMonth") as DropDownList;
                DropDownList ddlDirectorshipEndYear = e.Item.FindControl("ddlDirectorshipEndYear") as DropDownList;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipCurrent = e.Item.FindControl("cbDirectorshipCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                TextBox tbDirectorshipSummary = e.Item.FindControl("tbDirectorshipSummary") as TextBox;
                TextBox tbDirectorshipResponsibilities = e.Item.FindControl("tbDirectorshipResponsibilities") as TextBox;
                DropDownList ddlDirectorshipType = e.Item.FindControl("ddlDirectorshipType") as DropDownList;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipAuditCommittee = e.Item.FindControl("cbDirectorshipAuditCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipRiskCommittee = e.Item.FindControl("cbDirectorshipRiskCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipNominationsCommittee = e.Item.FindControl("cbDirectorshipNominationsCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipRemunerationCommittee = e.Item.FindControl("cbDirectorshipRemunerationCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipOHSCommittee = e.Item.FindControl("cbDirectorshipOHSCommittee") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbDirectorshipOther = e.Item.FindControl("cbDirectorshipOther") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                LinkButton lbDirectorshipSave = e.Item.FindControl("lbDirectorshipSave") as LinkButton;
                LinkButton lbDirectorshipDelete = e.Item.FindControl("lbDirectorshipDelete") as LinkButton;

                tbDirectorshipJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
                tbDirectorshipCompanyName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOrganisationName"));
                tbDirectorshipWebsite.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOrganisationWebsite"));

                System.Web.UI.HtmlControls.HtmlAnchor aDirectorshipEdit = e.Item.FindControl("aDirectorshipEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aDirectorshipEdit.Attributes.Add("href", "#edit-DirectorshipExperience" + (e.Item.ItemIndex + 1).ToString());
                Entities.MemberPositions directorship = e.Item.DataItem as Entities.MemberPositions;

                lbDirectorshipDelete.CommandArgument = directorship.MemberPositionId.ToString();
                lbDirectorshipDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbDirectorshipDelete.ClientID + "').prop('href'))});";

                ddlDirectorshipStartMonth.Items.Clear();
                ddlDirectorshipStartMonth.DataValueField = "value";
                ddlDirectorshipStartMonth.DataTextField = "text";
                ddlDirectorshipStartMonth.DataSource = MonthList;
                ddlDirectorshipStartMonth.DataBind();
                ddlDirectorshipStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlDirectorshipStartYear.Items.Clear();
                ddlDirectorshipStartYear.DataValueField = "value";
                ddlDirectorshipStartYear.DataTextField = "text";
                ddlDirectorshipStartYear.DataSource = YearList;
                ddlDirectorshipStartYear.DataBind();
                ddlDirectorshipStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlDirectorshipEndMonth.Items.Clear();
                ddlDirectorshipEndMonth.DataValueField = "value";
                ddlDirectorshipEndMonth.DataTextField = "text";
                ddlDirectorshipEndMonth.DataSource = MonthList;
                ddlDirectorshipEndMonth.DataBind();
                ddlDirectorshipEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlDirectorshipEndYear.Items.Clear();
                ddlDirectorshipEndYear.DataValueField = "value";
                ddlDirectorshipEndYear.DataTextField = "text";
                ddlDirectorshipEndYear.DataSource = YearList;
                ddlDirectorshipEndYear.DataBind();
                ddlDirectorshipEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                string experiencedate = string.Empty;

                if (directorship.StartMonth.HasValue && directorship.StartYear.HasValue && directorship.StartMonth.Value != 0 && directorship.StartYear.Value != 0)
                {
                    DateTime StartDate = new DateTime(directorship.StartYear.Value, directorship.StartMonth.Value, 1);
                    DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    if (!directorship.IsCurrent && directorship.EndYear.HasValue && directorship.EndMonth.HasValue)
                    {
                        EndDate = new DateTime(directorship.EndYear.Value, directorship.EndMonth.Value, 1);
                    }
                    TimeSpan timespan = EndDate.Subtract(StartDate);

                    string startmonth = string.Empty;
                    string endmonth = string.Empty;
                    string duration = string.Empty;
                    DateTime timespandt = DateTime.MinValue + timespan;

                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == directorship.StartMonth.Value.ToString())
                        {
                            startmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }
                    if (directorship.EndMonth.HasValue)
                    {
                        foreach (ListItem month in MonthList)
                        {
                            if (month.Value == directorship.EndMonth.Value.ToString())
                            {
                                endmonth = CommonFunction.GetResourceValue(month.Text);
                                break;
                            }
                        }
                    }

                    if (timespandt.Year - 1 > 0)
                    {
                        duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                    }

                    if (timespandt.Month - 1 > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(duration))
                        {
                            duration += ", ";
                        }

                        duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                    }

                    if (timespandt.Year == 1 && timespandt.Month == 1)
                    {
                        duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                    }

                    if (directorship.IsCurrent)
                    {
                        experiencedate = string.Format("{0} {1} - {2} / ({3})", startmonth, directorship.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                    }
                    else
                    {
                        experiencedate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, directorship.StartYear, endmonth, directorship.EndYear, duration);
                    }
                }

                if (!string.IsNullOrEmpty(directorship.OrganisationWebsite))
                {
                    ltDirectorshipWebsite.Text = string.Format("<h4 class='director-website'><a href='{0}' target='_blank'>{0}</a></h4>", directorship.OrganisationWebsite);
                    //hlDirectorshipWebsite.Visible = true;
                    //hlDirectorshipWebsite.Text = directorship.OrganisationWebsite;
                    //hlDirectorshipWebsite.NavigateUrl = directorship.OrganisationWebsite;
                }

                tbDirectorshipCompanyName.Text = directorship.CompanyName;
                tbDirectorshipJobTitle.Text = directorship.Title;

                if (directorship.StartMonth.HasValue)
                {
                    ddlDirectorshipStartMonth.SelectedValue = directorship.StartMonth.Value.ToString();
                }
                if (directorship.StartYear.HasValue)
                {
                    ddlDirectorshipStartYear.SelectedValue = directorship.StartYear.Value.ToString();
                }
                if (directorship.EndMonth.HasValue)
                {
                    ddlDirectorshipEndMonth.SelectedValue = directorship.EndMonth.Value.ToString();
                }
                if (directorship.EndYear.HasValue)
                {
                    ddlDirectorshipEndYear.SelectedValue = directorship.EndYear.Value.ToString();
                }

                if (directorship.IsCurrent)
                {
                    cbDirectorshipCurrent.Checked = true;
                    ddlDirectorshipEndMonth.Enabled = false;
                    ddlDirectorshipEndYear.Enabled = false;
                }
                tbDirectorshipSummary.Text = directorship.Summary;

                tbDirectorshipWebsite.Text = directorship.OrganisationWebsite;
                tbDirectorshipSummary.Text = directorship.Summary;
                tbDirectorshipResponsibilities.Text = directorship.ResponsibilitiesAndAchievements;
                ddlDirectorshipType.SelectedValue = directorship.TypeOfDirectorship;

                if (!string.IsNullOrWhiteSpace(directorship.AdditionalRolesAndResponsibilities))
                {
                    if (directorship.AdditionalRolesAndResponsibilities.Contains("AuditCommittee"))
                    {
                        cbDirectorshipAuditCommittee.Checked = true;
                    }

                    if (directorship.AdditionalRolesAndResponsibilities.Contains("RiskCommittee"))
                    {
                        cbDirectorshipRiskCommittee.Checked = true;
                    }

                    if (directorship.AdditionalRolesAndResponsibilities.Contains("RemunerationCommittee"))
                    {
                        cbDirectorshipRemunerationCommittee.Checked = true;
                    }

                    if (directorship.AdditionalRolesAndResponsibilities.Contains("NominationsCommittee"))
                    {
                        cbDirectorshipNominationsCommittee.Checked = true;
                    }

                    if (directorship.AdditionalRolesAndResponsibilities.Contains("OHSCommittee"))
                    {
                        cbDirectorshipOHSCommittee.Checked = true;
                    }
                    if (directorship.AdditionalRolesAndResponsibilities.Contains("Other"))
                    {
                        cbDirectorshipOther.Checked = true;
                    }
                }


                ltDirectorshipCompanyName.Text = HttpUtility.HtmlEncode(directorship.CompanyName);
                ltDirectorshipJobTitle.Text = HttpUtility.HtmlEncode(directorship.Title);

                ltDirectorshipDateTime.Text = experiencedate;
                ltDirectorshipDescription.Text = HttpUtility.HtmlEncode(directorship.Summary).Replace("\n", "<br />");
                ltDirectorshipResponsibilities.Text = HttpUtility.HtmlEncode(directorship.ResponsibilitiesAndAchievements).Replace("\n", "<br />");
                ltDirectorshipTypes.Text = ddlDirectorshipType.SelectedItem.Text;
                ltDirectorshipAdditionalRoles.Text = string.Empty;
                if (cbDirectorshipAuditCommittee.Checked || cbDirectorshipRiskCommittee.Checked ||
                cbDirectorshipNominationsCommittee.Checked || cbDirectorshipRemunerationCommittee.Checked ||
                cbDirectorshipOHSCommittee.Checked || cbDirectorshipOther.Checked)
                {
                    ltDirectorshipAdditionalRoles.Text = "<strong>" + HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelAdditionalRolesAndResponsibilities") + ": ") + "</strong>";

                    if (cbDirectorshipAuditCommittee.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbAuditCommittee") + ", ");
                    }
                    if (cbDirectorshipRiskCommittee.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbRiskCommittee") + ", ");
                    }
                    if (cbDirectorshipNominationsCommittee.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbNominationsCommittee") + ", ");
                    }
                    if (cbDirectorshipRemunerationCommittee.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbRemunerationCommittee") + ", ");
                    }
                    if (cbDirectorshipOHSCommittee.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbOHSCommittee") + ", ");
                    }
                    if (cbDirectorshipOther.Checked)
                    {
                        ltDirectorshipAdditionalRoles.Text += HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("cbOther") + ", ");
                    }

                    ltDirectorshipAdditionalRoles.Text = ltDirectorshipAdditionalRoles.Text.TrimEnd(new char[] { ',', ' ' });
                }
                lbDirectorshipSave.CommandName = "DirectorshipSave";
                lbDirectorshipSave.CommandArgument = directorship.MemberPositionId.ToString();
            }
        }

        protected void lbDirectorshipAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptDirectorship.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acDirectorship = item.FindControl("acDirectorship") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acDirectorship.Attributes.Add("class", "section-content");
            }

            bool hasError = false;
            phDirectorshipAddEndError.Visible = false;
            string controltofocus = string.Empty;
            phDirectorshipAddCompanyNameError.Visible = false;
            phDirectorshipAddJobTitleError.Visible = false;
            phDirectorshipAddWebsiteError.Visible = false;
            phDirectorshipAddSummaryError.Visible = false;
            phDirectorshipAddResponsibilitiesError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbDirectorshipAddJobTitle.Text))
            {
                hasError = true;
                phDirectorshipAddJobTitleError.Visible = true;
                ltErrorAddDirectorshipJobTitle.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbDirectorshipAddJobTitle.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbDirectorshipAddJobTitle.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddJobTitleError.Visible = true;
                    ltErrorAddDirectorshipJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddJobTitle.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbDirectorshipAddCompanyName.Text))
            {
                hasError = true;
                phDirectorshipAddCompanyNameError.Visible = true;
                ltErrorAddDirectorshipCompanyName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbDirectorshipAddCompanyName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbDirectorshipAddJobTitle.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddJobTitleError.Visible = true;
                    ltErrorAddDirectorshipJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddJobTitle.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbDirectorshipAddCompanyName.Text))
            {
                if (Regex.IsMatch(tbDirectorshipAddCompanyName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddCompanyNameError.Visible = true;
                    ltErrorAddDirectorshipCompanyName.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddCompanyName.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbDirectorshipAddWebsite.Text))
            {
                if (Regex.IsMatch(tbDirectorshipAddWebsite.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddWebsiteError.Visible = true;
                    ltErrorAddDirectorshipWebsite.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddWebsite.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbDirectorshipAddSummary.Text))
            {
                if (Regex.IsMatch(tbDirectorshipAddSummary.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddSummaryError.Visible = true;
                    ltErrorAddDirectorshipSummary.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddSummary.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbDirectorshipAddResponsibilities.Text))
            {
                if (Regex.IsMatch(tbDirectorshipAddResponsibilities.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phDirectorshipAddResponsibilitiesError.Visible = true;
                    ltErrorAddDirectorshipResponsibilities.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbDirectorshipAddResponsibilities.ClientID;
                    }
                }
            }

            if ((ddlDirectorshipAddStartYear.SelectedValue == "0" || ddlDirectorshipAddStartMonth.SelectedValue == "0")
                || DateTime.Now < new DateTime(Convert.ToInt32(ddlDirectorshipAddStartYear.SelectedValue), Convert.ToInt32(ddlDirectorshipAddStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phDirectorshipAddEndError.Visible = true;

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = ddlDirectorshipAddStartMonth.ClientID;
                }
            }

            // Date Error Checking
            if (!cbDirectorshipAddCurrent.Checked)
            {
                if (ddlDirectorshipAddEndYear.SelectedValue == "0" || ddlDirectorshipAddEndMonth.SelectedValue == "0"
                    || (Convert.ToInt32(ddlDirectorshipAddStartYear.SelectedValue) > Convert.ToInt32(ddlDirectorshipAddEndYear.SelectedValue))
                    || ((Convert.ToInt32(ddlDirectorshipAddEndYear.SelectedValue) == Convert.ToInt32(ddlDirectorshipAddStartYear.SelectedValue) && (Convert.ToInt32(ddlDirectorshipAddEndMonth.SelectedValue) < Convert.ToInt32(ddlDirectorshipAddStartMonth.SelectedValue)))))
                {
                    phDirectorshipAddEndError.Visible = true;
                    hasError = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlDirectorshipAddStartMonth.ClientID;
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenAddDiv(string.Empty, controltofocus);
                acDirectorshipAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newDirectorshipExperience.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            MemberPositions directorship = new MemberPositions();

            directorship.CompanyName = tbDirectorshipAddCompanyName.Text;
            directorship.Title = tbDirectorshipAddJobTitle.Text;

            directorship.StartMonth = Convert.ToInt32(ddlDirectorshipAddStartMonth.SelectedValue);
            directorship.StartYear = Convert.ToInt32(ddlDirectorshipAddStartYear.SelectedValue);

            directorship.EndMonth = Convert.ToInt32(ddlDirectorshipAddEndMonth.SelectedValue);
            directorship.EndYear = Convert.ToInt32(ddlDirectorshipAddEndYear.SelectedValue);

            directorship.IsCurrent = cbDirectorshipAddCurrent.Checked;
            if (cbDirectorshipAddCurrent.Checked)
            {
                ddlDirectorshipAddEndMonth.Enabled = false;
                ddlDirectorshipAddEndYear.Enabled = false;

                directorship.EndMonth = null;
                directorship.EndYear = null;
            }

            directorship.OrganisationWebsite = tbDirectorshipAddWebsite.Text;
            directorship.Summary = tbDirectorshipAddSummary.Text;
            directorship.ResponsibilitiesAndAchievements = tbDirectorshipAddResponsibilities.Text;
            directorship.TypeOfDirectorship = ddlDirectorshipAddType.SelectedValue;
            directorship.IsCurrent = cbDirectorshipAddCurrent.Checked;

            string additionRolesResponsibilities = string.Empty;
            if (cbDirectorshipAddAuditCommittee.Checked)
            {
                additionRolesResponsibilities += "AuditCommittee" + ",";
            }
            if (cbDirectorshipAddRiskCommittee.Checked)
            {
                additionRolesResponsibilities += "RiskCommittee" + ",";
            }
            if (cbDirectorshipAddNominationsCommittee.Checked)
            {
                additionRolesResponsibilities += "NominationsCommittee" + ",";
            }
            if (cbDirectorshipAddRemunerationCommittee.Checked)
            {
                additionRolesResponsibilities += "RemunerationCommittee" + ",";
            }
            if (cbDirectorshipAddOHSCommittee.Checked)
            {
                additionRolesResponsibilities += "OHSCommittee" + ",";
            }
            if (cbDirectorshipAddOther.Checked)
            {
                additionRolesResponsibilities += "Other" + ",";
            }

            directorship.AdditionalRolesAndResponsibilities = additionRolesResponsibilities.TrimEnd(new char[] { ',' });
            directorship.MemberId = SessionData.Member.MemberId;
            directorship.IsDirectorship = true;

            MemberPositionsService.Insert(directorship);
            UpdateMemberLastModified();
            LoadCalendar();

            SetDirectorship();
            /*using (TList<Entities.MemberPositions> directorships = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
            {
                directorships.Filter = "isDirectorship = true";
                rptDirectorship.DataSource = directorships;
                rptDirectorship.DataBind();

                phNavDirectorship.Visible = (directorships.Count == 0);
                phAddEntryTextDirectorship.Visible = (directorships.Count == 0);
                phTickDirectorship.Visible = (directorships.Count > 0);

            }*/

            tbDirectorshipAddCompanyName.Text = string.Empty;
            tbDirectorshipAddJobTitle.Text = string.Empty;

            ddlDirectorshipAddStartMonth.SelectedIndex = 0;
            ddlDirectorshipAddStartYear.SelectedIndex = 0;

            ddlDirectorshipAddEndMonth.SelectedIndex = 0;
            ddlDirectorshipAddEndYear.SelectedIndex = 0;

            cbDirectorshipAddCurrent.Checked = false;

            ddlDirectorshipAddEndMonth.Enabled = true;
            ddlDirectorshipAddEndYear.Enabled = true;


            tbDirectorshipAddWebsite.Text = string.Empty;
            tbDirectorshipAddSummary.Text = string.Empty;
            tbDirectorshipAddResponsibilities.Text = string.Empty;
            ddlDirectorshipAddType.SelectedIndex = 0;


            cbDirectorshipAddAuditCommittee.Checked = false;
            cbDirectorshipAddRiskCommittee.Checked = false;
            cbDirectorshipAddNominationsCommittee.Checked = false;
            cbDirectorshipAddRemunerationCommittee.Checked = false;
            cbDirectorshipAddOHSCommittee.Checked = false;
            cbDirectorshipAddOther.Checked = false;

            StandardResetJS();

            acDirectorshipAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newDirectorshipExperience.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Experience

        private int SetWorkExperience()
        {
            using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
            {
                memberpositions.Filter = "isDirectorship = false";
                rptExperience.DataSource = memberpositions.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptExperience.DataBind();

                phNavWorkExperience.Visible = (memberpositions.Count < MinExperienceEntry);
                phAddEntryTextExperience.Visible = (memberpositions.Count < MinExperienceEntry);
                phTickWorkExperience.Visible = (memberpositions.Count >= MinExperienceEntry);
            }

            return 0;
        }

        private void DeleteWorkExperience(int experienceid)
        {
            using (MemberPositions memberposition = MemberPositionsService.GetByMemberPositionId(experienceid))
            {
                if (memberposition != null && memberposition.MemberId == SessionData.Member.MemberId)
                {
                    MemberPositionsService.Delete(memberposition);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptExperience_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acExperienceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newExperience.Attributes.Add("class", "profile-edit collapse");

            Literal ltExperienceCompanyNameAndLocation = e.Item.FindControl("ltExperienceCompanyNameAndLocation") as Literal;
            Literal ltExperienceJobTitle = e.Item.FindControl("ltExperienceJobTitle") as Literal;
            Literal ltExperienceDate = e.Item.FindControl("ltExperienceDate") as Literal;
            Literal ltExperienceDescription = e.Item.FindControl("ltExperienceDescription") as Literal;
            TextBox tbExperienceCompanyName = e.Item.FindControl("tbExperienceCompanyName") as TextBox;
            PlaceHolder phExperienceCompanyNameError = e.Item.FindControl("phExperienceCompanyNameError") as PlaceHolder;
            ucLanguageLiteral ltErrorExperienceCompanyName = e.Item.FindControl("ltErrorExperienceCompanyName") as ucLanguageLiteral;
            TextBox tbExperienceJobTitle = e.Item.FindControl("tbExperienceJobTitle") as TextBox;
            PlaceHolder phExperienceJobTitleError = e.Item.FindControl("phExperienceJobTitleError") as PlaceHolder;
            ucLanguageLiteral ltErrorExperienceJobTitle = e.Item.FindControl("ltErrorExperienceJobTitle") as ucLanguageLiteral;
            DropDownList ddlExperienceCountry = e.Item.FindControl("ddlExperienceCountry") as DropDownList;
            TextBox tbExperienceCity = e.Item.FindControl("tbExperienceCity") as TextBox;
            TextBox tbExperienceState = e.Item.FindControl("tbExperienceState") as TextBox;
            DropDownList ddlExperienceStartMonth = e.Item.FindControl("ddlExperienceStartMonth") as DropDownList;
            DropDownList ddlExperienceStartYear = e.Item.FindControl("ddlExperienceStartYear") as DropDownList;
            DropDownList ddlExperienceEndMonth = e.Item.FindControl("ddlExperienceEndMonth") as DropDownList;
            DropDownList ddlExperienceEndYear = e.Item.FindControl("ddlExperienceEndYear") as DropDownList;
            PlaceHolder phExperienceEndError = e.Item.FindControl("phExperienceEndError") as PlaceHolder;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbExperienceCurrent = e.Item.FindControl("cbExperienceCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            TextBox tbExperienceDescription = e.Item.FindControl("tbExperienceDescription") as TextBox;
            LinkButton lbExperienceSave = e.Item.FindControl("lbExperienceSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlGenericControl acExperience = e.Item.FindControl("acExperience") as System.Web.UI.HtmlControls.HtmlGenericControl;
            System.Web.UI.HtmlControls.HtmlAnchor aExperienceEdit = e.Item.FindControl("aExperienceEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            aExperienceEdit.Attributes.Add("href", "#edit-Experience" + (e.Item.ItemIndex + 1).ToString());

            PlaceHolder phExperienceCityError = e.Item.FindControl("phExperienceCityError") as PlaceHolder;
            ucLanguageLiteral ltErrorExperienceCity = e.Item.FindControl("ltErrorExperienceCity") as ucLanguageLiteral;
            PlaceHolder phExperienceStateError = e.Item.FindControl("phExperienceStateError") as PlaceHolder;
            ucLanguageLiteral ltErrorExperienceState = e.Item.FindControl("ltErrorExperienceState") as ucLanguageLiteral;
            PlaceHolder phExperienceDescriptionError = e.Item.FindControl("phExperienceDescriptionError") as PlaceHolder;
            ucLanguageLiteral ltErrorExperienceDescription = e.Item.FindControl("ltErrorExperienceDescription") as ucLanguageLiteral;

            ddlExperienceEndMonth.Enabled = !(cbExperienceCurrent.Checked);
            ddlExperienceEndYear.Enabled = !(cbExperienceCurrent.Checked);

            if (e.CommandName == "ExperienceSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;

                phExperienceCompanyNameError.Visible = false;
                phExperienceJobTitleError.Visible = false;
                phExperienceEndError.Visible = false;
                phExperienceCityError.Visible = false;
                phExperienceStateError.Visible = false;
                phExperienceDescriptionError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbExperienceCompanyName.Text))
                {
                    hasError = true;
                    phExperienceCompanyNameError.Visible = true;
                    ltErrorExperienceCompanyName.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceCompanyName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbExperienceCompanyName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phExperienceCompanyNameError.Visible = true;
                        ltErrorExperienceCompanyName.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbExperienceCompanyName.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbExperienceJobTitle.Text))
                {
                    hasError = true;
                    phExperienceJobTitleError.Visible = true;
                    ltErrorExperienceJobTitle.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceJobTitle.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbExperienceJobTitle.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phExperienceJobTitleError.Visible = true;
                        ltErrorExperienceJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbExperienceJobTitle.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbExperienceCity.Text))
                {
                    if (Regex.IsMatch(tbExperienceCity.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phExperienceCityError.Visible = true;
                        ltErrorExperienceCity.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbExperienceCity.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbExperienceState.Text))
                {
                    if (Regex.IsMatch(tbExperienceState.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phExperienceStateError.Visible = true;
                        ltErrorExperienceState.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbExperienceState.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbExperienceDescription.Text))
                {
                    if (Regex.IsMatch(tbExperienceDescription.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phExperienceDescriptionError.Visible = true;
                        ltErrorExperienceDescription.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbExperienceDescription.ClientID;
                        }
                    }
                }


                if (DateTime.Now < new DateTime(Convert.ToInt32(ddlExperienceStartYear.SelectedValue), Convert.ToInt32(ddlExperienceStartMonth.SelectedValue), 1))
                {
                    hasError = true;
                    phExperienceEndError.Visible = true;
                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlExperienceStartMonth.ClientID;
                    }
                }

                // Date Error Checking
                if (!cbExperienceCurrent.Checked)
                {
                    if ((Convert.ToInt32(ddlExperienceStartYear.SelectedValue) > Convert.ToInt32(ddlExperienceEndYear.SelectedValue))
                        || ((Convert.ToInt32(ddlExperienceEndYear.SelectedValue) == Convert.ToInt32(ddlExperienceStartYear.SelectedValue) && (Convert.ToInt32(ddlExperienceEndMonth.SelectedValue) < Convert.ToInt32(ddlExperienceStartMonth.SelectedValue)))))
                    {
                        phExperienceEndError.Visible = true;
                        hasError = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlExperienceStartMonth.ClientID;
                        }
                    }

                }

                if (hasError)
                {
                    StandardResetJS();
                    OpenRepeaterDiv(string.Empty, controltofocus);

                    acExperience.Attributes.Add("class", "section-content edit-mode");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ExperienceError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Experience" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);


                    return;
                }


                int memberpositionid = Convert.ToInt32(e.CommandArgument);

                using (MemberPositions memberposition = MemberPositionsService.GetByMemberPositionId(memberpositionid))
                {
                    if (memberposition != null)
                    {
                        memberposition.CompanyName = tbExperienceCompanyName.Text;
                        memberposition.Title = tbExperienceJobTitle.Text;
                        memberposition.CountryId = Convert.ToInt32(ddlExperienceCountry.SelectedValue);
                        memberposition.City = tbExperienceCity.Text;
                        memberposition.State = tbExperienceState.Text;
                        memberposition.StartMonth = Convert.ToInt32(ddlExperienceStartMonth.SelectedValue);
                        memberposition.StartYear = Convert.ToInt32(ddlExperienceStartYear.SelectedValue);
                        if (cbExperienceCurrent.Checked)
                        {
                            memberposition.IsCurrent = true;
                            memberposition.EndMonth = (int?)null;
                            memberposition.EndYear = (int?)null;
                        }
                        else
                        {
                            memberposition.IsCurrent = false;
                            memberposition.EndMonth = Convert.ToInt32(ddlExperienceEndMonth.SelectedValue);
                            memberposition.EndYear = Convert.ToInt32(ddlExperienceEndYear.SelectedValue);
                        }
                        memberposition.Summary = tbExperienceDescription.Text;

                        MemberPositionsService.Update(memberposition);
                        UpdateMemberLastModified();
                        List<string> companynameandlocation = new List<string>();
                        companynameandlocation.Add(memberposition.CompanyName);
                        companynameandlocation.Add(memberposition.City);

                        if (!string.IsNullOrEmpty(memberposition.State))
                            companynameandlocation.Add(memberposition.State);

                        if (memberposition.CountryId.HasValue)
                        {
                            foreach (ListItem country in ddlExperienceCountry.Items)
                            {
                                if (country.Value == memberposition.CountryId.Value.ToString())
                                {
                                    companynameandlocation.Add(country.Text);
                                    break;
                                }
                            }
                        }

                        string experiencedate = string.Empty;

                        DateTime StartDate = new DateTime(memberposition.StartYear.Value, memberposition.StartMonth.Value, 1);
                        DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        if (!memberposition.IsCurrent)
                        {
                            EndDate = new DateTime(memberposition.EndYear.Value, memberposition.EndMonth.Value, 1);
                        }
                        TimeSpan timespan = EndDate.Subtract(StartDate);

                        string startmonth = string.Empty;
                        string endmonth = string.Empty;
                        string duration = string.Empty;
                        DateTime timespandt = DateTime.MinValue + timespan;

                        foreach (ListItem month in ddlExperienceStartMonth.Items)
                        {
                            if (month.Value == memberposition.StartMonth.Value.ToString())
                            {
                                startmonth = CommonFunction.GetResourceValue(month.Text);
                                break;
                            }
                        }
                        if (memberposition.EndMonth.HasValue)
                        {
                            foreach (ListItem month in ddlExperienceEndMonth.Items)
                            {
                                if (month.Value == memberposition.EndMonth.Value.ToString())
                                {
                                    endmonth = CommonFunction.GetResourceValue(month.Text);
                                    break;
                                }
                            }
                        }

                        if (timespandt.Year - 1 > 0)
                        {
                            duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                        }

                        if (timespandt.Month - 1 > 0)
                        {
                            if (!string.IsNullOrWhiteSpace(duration))
                            {
                                duration += ", ";
                            }

                            duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                        }

                        if (timespandt.Year == 1 && timespandt.Month == 1)
                        {
                            duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                        }

                        if (memberposition.IsCurrent)
                        {
                            experiencedate = string.Format("{0} {1} - {2} / ({3})", startmonth, memberposition.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                        }
                        else
                        {
                            experiencedate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, memberposition.StartYear, endmonth, memberposition.EndYear, duration);
                        }

                        if (companynameandlocation.Count > 0)
                        {
                            ltExperienceCompanyNameAndLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'><!-- icon --></span>{0}</address>",
                                                                            HttpUtility.HtmlEncode(JoinText(companynameandlocation)));
                        }

                        ltExperienceJobTitle.Text = HttpUtility.HtmlEncode(memberposition.Title);

                        ltExperienceDate.Text = experiencedate;
                        ltExperienceDescription.Text = HttpUtility.HtmlEncode(memberposition.Summary).Replace("\n", "<br />");


                    }
                }
            }

            if (e.CommandName == "ExperienceDelete")
            {
                DeleteWorkExperience(Convert.ToInt32(e.CommandArgument));

                /*using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    memberpositions.Filter = "isDirectorship = false";
                    rptExperience.DataSource = memberpositions;
                    rptExperience.DataBind();

                    phNavWorkExperience.Visible = (memberpositions.Count == 0);
                    phAddEntryTextExperience.Visible = (memberpositions.Count == 0);
                    phTickWorkExperience.Visible = memberpositions.Count() > 0;
                }*/
            }

            LoadCountry();
            LoadCalendar();

            SetWorkExperience();

            StandardResetJS();

            acExperience.Attributes.Add("class", "section-content");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ExperienceError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Experience" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);


            SetMemberPoints();
        }

        protected void rptExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltExperienceCompanyNameAndLocation = e.Item.FindControl("ltExperienceCompanyNameAndLocation") as Literal;
                Literal ltExperienceJobTitle = e.Item.FindControl("ltExperienceJobTitle") as Literal;
                Literal ltExperienceDate = e.Item.FindControl("ltExperienceDate") as Literal;
                Literal ltExperienceDescription = e.Item.FindControl("ltExperienceDescription") as Literal;
                TextBox tbExperienceCompanyName = e.Item.FindControl("tbExperienceCompanyName") as TextBox;
                TextBox tbExperienceJobTitle = e.Item.FindControl("tbExperienceJobTitle") as TextBox;
                DropDownList ddlExperienceCountry = e.Item.FindControl("ddlExperienceCountry") as DropDownList;
                TextBox tbExperienceCity = e.Item.FindControl("tbExperienceCity") as TextBox;
                TextBox tbExperienceState = e.Item.FindControl("tbExperienceState") as TextBox;
                DropDownList ddlExperienceStartMonth = e.Item.FindControl("ddlExperienceStartMonth") as DropDownList;
                DropDownList ddlExperienceStartYear = e.Item.FindControl("ddlExperienceStartYear") as DropDownList;
                DropDownList ddlExperienceEndMonth = e.Item.FindControl("ddlExperienceEndMonth") as DropDownList;
                DropDownList ddlExperienceEndYear = e.Item.FindControl("ddlExperienceEndYear") as DropDownList;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbExperienceCurrent = e.Item.FindControl("cbExperienceCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                TextBox tbExperienceDescription = e.Item.FindControl("tbExperienceDescription") as TextBox;
                LinkButton lbExperienceSave = e.Item.FindControl("lbExperienceSave") as LinkButton;
                LinkButton lbExperienceDelete = e.Item.FindControl("lbExperienceDelete") as LinkButton;
                System.Web.UI.HtmlControls.HtmlAnchor aExperienceEdit = e.Item.FindControl("aExperienceEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aExperienceEdit.Attributes.Add("href", "#edit-Experience" + (e.Item.ItemIndex + 1).ToString());

                //placeholders
                tbExperienceCompanyName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCompanyName"));
                tbExperienceJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
                tbExperienceCity.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityTown"));
                tbExperienceState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelState"));
                tbExperienceDescription.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelDescriptionHere"));

                Entities.MemberPositions memberposition = e.Item.DataItem as Entities.MemberPositions;

                lbExperienceDelete.CommandArgument = memberposition.MemberPositionId.ToString();
                lbExperienceDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbExperienceDelete.ClientID + "').prop('href'))});";
                ddlExperienceStartMonth.Items.Clear();
                ddlExperienceStartMonth.DataValueField = "value";
                ddlExperienceStartMonth.DataTextField = "text";
                ddlExperienceStartMonth.DataSource = MonthList;
                ddlExperienceStartMonth.DataBind();

                ddlExperienceStartYear.Items.Clear();
                ddlExperienceStartYear.DataValueField = "value";
                ddlExperienceStartYear.DataTextField = "text";
                ddlExperienceStartYear.DataSource = YearList;
                ddlExperienceStartYear.DataBind();

                ddlExperienceEndMonth.Items.Clear();
                ddlExperienceEndMonth.DataValueField = "value";
                ddlExperienceEndMonth.DataTextField = "text";
                ddlExperienceEndMonth.DataSource = MonthList;
                ddlExperienceEndMonth.DataBind();

                ddlExperienceEndYear.Items.Clear();
                ddlExperienceEndYear.DataValueField = "value";
                ddlExperienceEndYear.DataTextField = "text";
                ddlExperienceEndYear.DataSource = YearList;
                ddlExperienceEndYear.DataBind();

                ddlExperienceCountry.Items.Clear();
                ddlExperienceCountry.DataValueField = "CountryID";
                ddlExperienceCountry.DataTextField = "CountryName";
                ddlExperienceCountry.DataSource = CountryList;
                ddlExperienceCountry.DataBind();
                ddlExperienceCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

                List<string> companynameandlocation = new List<string>();
                companynameandlocation.Add(memberposition.CompanyName);
                companynameandlocation.Add(memberposition.City);

                if (!string.IsNullOrEmpty(memberposition.State))
                    companynameandlocation.Add(memberposition.State);

                if (memberposition.CountryId.HasValue)
                {
                    foreach (Entities.Countries country in CountryList)
                    {
                        if (country.CountryId == memberposition.CountryId.Value)
                        {
                            companynameandlocation.Add(country.CountryName);
                            break;
                        }
                    }
                }

                string experiencedate = string.Empty;
                DateTime StartDate = new DateTime(memberposition.StartYear.Value, memberposition.StartMonth.Value, 1);
                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (!memberposition.IsCurrent)
                {
                    EndDate = new DateTime(memberposition.EndYear.Value, memberposition.EndMonth.Value, 1);
                }
                TimeSpan timespan = EndDate.Subtract(StartDate);

                string startmonth = string.Empty;
                string endmonth = string.Empty;
                string duration = string.Empty;
                DateTime timespandt = DateTime.MinValue + timespan;

                foreach (ListItem month in MonthList)
                {
                    if (month.Value == memberposition.StartMonth.Value.ToString())
                    {
                        startmonth = CommonFunction.GetResourceValue(month.Text);
                        break;
                    }
                }
                if (memberposition.EndMonth.HasValue)
                {
                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == memberposition.EndMonth.Value.ToString())
                        {
                            endmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }
                }

                if (timespandt.Year - 1 > 0)
                {
                    duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                }

                if (timespandt.Month - 1 > 0)
                {
                    if (!string.IsNullOrWhiteSpace(duration))
                    {
                        duration += ", ";
                    }

                    duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                }

                if (timespandt.Year == 1 && timespandt.Month == 1)
                {
                    duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                }

                if (memberposition.IsCurrent)
                {
                    experiencedate = string.Format("{0} {1} - {2} / ({3})", startmonth, memberposition.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                }
                else
                {
                    experiencedate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, memberposition.StartYear, endmonth, memberposition.EndYear, duration);
                }


                if (companynameandlocation.Count > 0)
                {
                    ltExperienceCompanyNameAndLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'><!-- icon --></span>{0}</address>",
                                                                    HttpUtility.HtmlEncode(JoinText(companynameandlocation)));
                }

                ltExperienceJobTitle.Text = HttpUtility.HtmlEncode(memberposition.Title);

                ltExperienceDate.Text = experiencedate;
                ltExperienceDescription.Text = HttpUtility.HtmlEncode(memberposition.Summary).Replace("\n", "<br />");

                tbExperienceCompanyName.Text = memberposition.CompanyName;
                tbExperienceJobTitle.Text = memberposition.Title;
                if (memberposition.CountryId.HasValue)
                {
                    ddlExperienceCountry.SelectedValue = memberposition.CountryId.ToString();
                }
                tbExperienceCity.Text = memberposition.City;
                tbExperienceState.Text = memberposition.State;
                if (memberposition.StartMonth.HasValue)
                {
                    ddlExperienceStartMonth.SelectedValue = memberposition.StartMonth.Value.ToString();
                }
                if (memberposition.StartYear.HasValue)
                {
                    ddlExperienceStartYear.SelectedValue = memberposition.StartYear.Value.ToString();
                }
                if (memberposition.EndMonth.HasValue)
                {
                    ddlExperienceEndMonth.SelectedValue = memberposition.EndMonth.Value.ToString();
                }
                if (memberposition.EndYear.HasValue)
                {
                    ddlExperienceEndYear.SelectedValue = memberposition.EndYear.Value.ToString();
                }

                if (memberposition.IsCurrent)
                {
                    cbExperienceCurrent.Checked = true;
                    ddlExperienceEndMonth.Enabled = false;
                    ddlExperienceEndYear.Enabled = false;
                }
                tbExperienceDescription.Text = memberposition.Summary;
                lbExperienceSave.CommandName = "ExperienceSave";
                lbExperienceSave.CommandArgument = memberposition.MemberPositionId.ToString();
            }
        }

        protected void lbExperienceAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptExperience.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acExperience = item.FindControl("acExperience") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acExperience.Attributes.Add("class", "section-content");
            }

            bool hasError = false;
            string controltofocus = string.Empty;

            phExperienceAddCompanyNameError.Visible = false;
            phExperienceAddJobTitleError.Visible = false;
            phExperienceAddEndError.Visible = false;
            phExperienceAddCityError.Visible = false;
            phExperienceAddStateError.Visible = false;
            phExperienceAddDescriptionError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbExperienceAddCompanyName.Text))
            {
                hasError = true;
                phExperienceAddCompanyNameError.Visible = true;
                ltErrorAddExperienceCompanyName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbExperienceAddCompanyName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbExperienceAddCompanyName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phExperienceAddCompanyNameError.Visible = true;
                    ltErrorAddExperienceCompanyName.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceAddCompanyName.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbExperienceAddJobTitle.Text))
            {
                hasError = true;
                phExperienceAddJobTitleError.Visible = true;
                ltErrorAddExperienceJobTitle.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbExperienceAddJobTitle.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbExperienceAddJobTitle.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phExperienceAddJobTitleError.Visible = true;
                    ltErrorAddExperienceJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceAddJobTitle.ClientID;
                    }
                }
            }

            if ((ddlExperienceAddStartYear.SelectedValue == "0" || ddlExperienceAddStartMonth.SelectedValue == "0" )
                || DateTime.Now < new DateTime(Convert.ToInt32(ddlExperienceAddStartYear.SelectedValue), Convert.ToInt32(ddlExperienceAddStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phExperienceAddEndError.Visible = true;

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = ddlExperienceAddStartMonth.ClientID;
                }
            }

            if (!string.IsNullOrEmpty(tbExperienceAddCity.Text))
            {
                if (Regex.IsMatch(tbExperienceAddCity.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phExperienceAddCityError.Visible = true;
                    ltErrorAddExperienceCity.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceAddCity.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbExperienceAddState.Text))
            {
                if (Regex.IsMatch(tbExperienceAddState.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phExperienceAddStateError.Visible = true;
                    ltErrorAddExperienceState.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceAddState.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbExperienceAddDescription.Text))
            {
                if (Regex.IsMatch(tbExperienceAddDescription.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phExperienceAddDescriptionError.Visible = true;
                    ltErrorAddExperienceDescription.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbExperienceAddDescription.ClientID;
                    }
                }
            }

            // Date Error Checking
            if (!cbExperienceAddCurrent.Checked)
            {
                if ( ddlExperienceAddEndYear.SelectedValue == "0" || ddlExperienceAddEndMonth.SelectedValue == "0" 
                    || (Convert.ToInt32(ddlExperienceAddStartYear.SelectedValue) > Convert.ToInt32(ddlExperienceAddEndYear.SelectedValue))
                    || ((Convert.ToInt32(ddlExperienceAddEndYear.SelectedValue) == Convert.ToInt32(ddlExperienceAddStartYear.SelectedValue) && (Convert.ToInt32(ddlExperienceAddEndMonth.SelectedValue) < Convert.ToInt32(ddlExperienceAddStartMonth.SelectedValue)))))
                {
                    phExperienceAddEndError.Visible = true;
                    hasError = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlExperienceAddStartMonth.ClientID;
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenAddDiv(string.Empty, controltofocus);

                acExperienceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newExperience.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            MemberPositions memberposition = new MemberPositions();

            memberposition.CompanyName = tbExperienceAddCompanyName.Text;
            memberposition.Title = tbExperienceAddJobTitle.Text;
            memberposition.CountryId = Convert.ToInt32(ddlExperienceAddCountry.SelectedValue);
            memberposition.City = tbExperienceAddCity.Text;
            memberposition.State = tbExperienceAddState.Text;
            memberposition.StartMonth = Convert.ToInt32(ddlExperienceAddStartMonth.SelectedValue);
            memberposition.StartYear = Convert.ToInt32(ddlExperienceAddStartYear.SelectedValue);
            if (cbExperienceAddCurrent.Checked)
            {
                memberposition.IsCurrent = true;
                memberposition.EndMonth = (int?)null;
                memberposition.EndYear = (int?)null;
            }
            else
            {
                memberposition.IsCurrent = false;
                memberposition.EndMonth = Convert.ToInt32(ddlExperienceAddEndMonth.SelectedValue);
                memberposition.EndYear = Convert.ToInt32(ddlExperienceAddEndYear.SelectedValue);
            }
            memberposition.Summary = tbExperienceAddDescription.Text;
            memberposition.MemberId = SessionData.Member.MemberId;

            MemberPositionsService.Insert(memberposition);
            UpdateMemberLastModified();
            LoadCountry();
            LoadCalendar();

            SetWorkExperience();
            /*using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
            {
                memberpositions.Filter = "isDirectorship = false";
                rptExperience.DataSource = memberpositions;
                rptExperience.DataBind();

                phNavWorkExperience.Visible = (memberpositions.Count == 0);
                phAddEntryTextExperience.Visible = (memberpositions.Count == 0);
                phTickWorkExperience.Visible = memberpositions.Count() > 0;
            }*/

            // clear the fields
            tbExperienceAddCompanyName.Text = string.Empty;
            tbExperienceAddJobTitle.Text = string.Empty;
            ddlExperienceAddCountry.SelectedIndex = 0;
            tbExperienceAddCity.Text = string.Empty;
            tbExperienceAddState.Text = string.Empty;
            ddlExperienceAddStartMonth.SelectedIndex = 0;
            ddlExperienceAddStartYear.SelectedIndex = 0;
            ddlExperienceAddEndMonth.SelectedIndex = 0;
            ddlExperienceAddEndYear.SelectedIndex = 0;
            cbExperienceAddCurrent.Checked = false;
            tbExperienceAddDescription.Text = string.Empty;


            StandardResetJS();

            acExperienceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newExperience.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();

        }

        #endregion

        #region Education

        private void LoadMemberQualificationLevel()
        {
            QualificationLevelList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.QualificationLevel>(true);
        }

        private int SetEducation()
        {
            using (TList<Entities.MemberQualification> membereducations = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (membereducations != null && membereducations.Count > 0)
                {
                    rptEducation.DataSource = membereducations.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                    rptEducation.DataBind();
                }
                else
                {
                    rptEducation.DataSource = null;
                    rptEducation.DataBind();
                }

                phNavEducation.Visible = (membereducations.Count < MinEducationEntry);
                phAddEntryTextEducation.Visible = (membereducations.Count < MinEducationEntry);
                phTickEducation.Visible = (membereducations.Count >= MinEducationEntry);
            }

            return 0;
        }

        private void DeleteEducation(int educationid)
        {
            using (MemberQualification memberqualification = MemberQualificationService.GetByMemberQualificationId(educationid))
            {
                if (memberqualification != null && memberqualification.MemberId == SessionData.Member.MemberId)
                {
                    MemberQualificationService.Delete(memberqualification);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acEducationAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newEducation.Attributes.Add("class", "profile-edit collapse");

            Literal ltInstitute = e.Item.FindControl("ltInstitute") as Literal;
            Literal ltEducationLocation = e.Item.FindControl("ltEducationLocation") as Literal;
            Literal ltQualificationName = e.Item.FindControl("ltQualificationName") as Literal;
            Literal ltEducationDate = e.Item.FindControl("ltEducationDate") as Literal;
            Literal ltEducationDescription = e.Item.FindControl("ltEducationDescription") as Literal;

            TextBox tbEducationInstitute = e.Item.FindControl("tbEducationInstitute") as TextBox;
            PlaceHolder phEducationInstituteError = e.Item.FindControl("phEducationInstituteError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationInstitute = e.Item.FindControl("ltErrorEducationInstitute") as ucLanguageLiteral;

            DropDownList ddlEducationCountry = e.Item.FindControl("ddlEducationCountry") as DropDownList;
            TextBox tbEducationState = e.Item.FindControl("tbEducationState") as TextBox;
            DropDownList ddlEducationQualificationLevel = e.Item.FindControl("ddlEducationQualificationLevel") as DropDownList;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbEducationGraduated = e.Item.FindControl("cbEducationGraduated") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            TextBox tbEducationGraduatedCredits = e.Item.FindControl("tbEducationGraduatedCredits") as TextBox;

            PlaceHolder phEducationQualificationLevelError = e.Item.FindControl("phEducationQualificationLevelError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationQualificationLevel = e.Item.FindControl("ltErrorEducationQualificationLevel") as ucLanguageLiteral;

            TextBox tbEducationQualificationName = e.Item.FindControl("tbEducationQualificationName") as TextBox;
            PlaceHolder phEducationQualificationNameError = e.Item.FindControl("phEducationQualificationNameError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationQualificationName = e.Item.FindControl("ltErrorEducationQualificationName") as ucLanguageLiteral;

            TextBox tbEducationOtherQualification = e.Item.FindControl("tbEducationOtherQualification") as TextBox;
            DropDownList ddlEducationGraduated = e.Item.FindControl("ddlEducationGraduated") as DropDownList;
            DropDownList ddlEducationStartMonth = e.Item.FindControl("ddlEducationStartMonth") as DropDownList;
            DropDownList ddlEducationStartYear = e.Item.FindControl("ddlEducationStartYear") as DropDownList;
            DropDownList ddlEducationEndMonth = e.Item.FindControl("ddlEducationEndMonth") as DropDownList;
            DropDownList ddlEducationEndYear = e.Item.FindControl("ddlEducationEndYear") as DropDownList;
            PlaceHolder phEducationEndError = e.Item.FindControl("phEducationEndError") as PlaceHolder;

            PlaceHolder phEducationStateError = e.Item.FindControl("phEducationStateError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationState = e.Item.FindControl("ltErrorEducationState") as ucLanguageLiteral;

            PlaceHolder phEducationOtherQualificationError = e.Item.FindControl("phEducationOtherQualificationError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationOtherQualification = e.Item.FindControl("ltErrorEducationOtherQualification") as ucLanguageLiteral;

            PlaceHolder phEducationGraduatedCreditsError = e.Item.FindControl("phEducationGraduatedCreditsError") as PlaceHolder;
            ucLanguageLiteral ltErrorEducationGraduatedCredits = e.Item.FindControl("ltErrorEducationGraduatedCredits") as ucLanguageLiteral;

            System.Web.UI.HtmlControls.HtmlInputCheckBox cbEducationCurrent = e.Item.FindControl("cbEducationCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            LinkButton lbEducationSave = e.Item.FindControl("lbEducationSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlAnchor aEducationEdit = e.Item.FindControl("aEducationEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            aEducationEdit.Attributes.Add("href", "#edit-Education" + (e.Item.ItemIndex + 1).ToString());
            System.Web.UI.HtmlControls.HtmlGenericControl acEducation = e.Item.FindControl("acEducation") as System.Web.UI.HtmlControls.HtmlGenericControl;

            ddlEducationEndMonth.Enabled = !(cbEducationCurrent.Checked);
            ddlEducationEndYear.Enabled = !(cbEducationCurrent.Checked);

            if (e.CommandName == "EducationSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;

                phEducationInstituteError.Visible = false;
                phEducationQualificationLevelError.Visible = false;
                phEducationQualificationNameError.Visible = false;
                phEducationEndError.Visible = false;
                phEducationStateError.Visible = false;
                phEducationOtherQualificationError.Visible = false;
                phEducationGraduatedCreditsError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbEducationInstitute.Text))
                {
                    hasError = true;
                    phEducationInstituteError.Visible = true;
                    ltErrorEducationInstitute.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationInstitute.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbEducationInstitute.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phEducationInstituteError.Visible = true;
                        ltErrorEducationInstitute.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbEducationInstitute.ClientID;
                        }
                    }
                }

                if (ddlEducationQualificationLevel.SelectedIndex == 0)
                {
                    hasError = true;
                    phEducationQualificationLevelError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlEducationQualificationLevel.ClientID;
                    }
                }

                if (string.IsNullOrWhiteSpace(tbEducationQualificationName.Text))
                {
                    hasError = true;
                    phEducationQualificationNameError.Visible = true;
                    ltErrorEducationQualificationName.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationQualificationName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbEducationQualificationName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phEducationQualificationNameError.Visible = true;
                        ltErrorEducationQualificationName.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbEducationQualificationName.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbEducationState.Text))
                {
                    if (Regex.IsMatch(tbEducationState.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phEducationStateError.Visible = true;
                        ltErrorEducationState.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbEducationState.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbEducationOtherQualification.Text))
                {
                    if (Regex.IsMatch(tbEducationOtherQualification.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phEducationOtherQualificationError.Visible = true;
                        ltErrorEducationOtherQualification.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbEducationOtherQualification.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbEducationGraduatedCredits.Text))
                {
                    if (Regex.IsMatch(tbEducationGraduatedCredits.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phEducationGraduatedCreditsError.Visible = true;
                        ltErrorEducationGraduatedCredits.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbEducationGraduatedCredits.ClientID;
                        }
                    }
                }

                bool hasStartDate = false;
                DateTime? thisStartDate = null;
                if (ddlEducationStartYear.SelectedValue != "0" && ddlEducationStartMonth.SelectedValue != "0")
                {
                    hasStartDate = true;
                    thisStartDate = new DateTime(Convert.ToInt32(ddlEducationStartYear.SelectedValue), Convert.ToInt32(ddlEducationStartMonth.SelectedValue), 1);
                    if (DateTime.Now < thisStartDate)
                    {
                        hasError = true;
                        phEducationEndError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlEducationStartMonth.ClientID;
                        }
                    }
                }

                bool hasEndDate = false;
                if (ddlEducationEndYear.SelectedValue != "0" && ddlEducationEndMonth.SelectedValue != "0")
                {
                    hasEndDate = true;
                    if (thisStartDate != null)
                    {
                        if (thisStartDate > new DateTime(Convert.ToInt32(ddlEducationEndYear.SelectedValue), Convert.ToInt32(ddlEducationEndMonth.SelectedValue), 1))
                        {
                            hasError = true;
                            phEducationEndError.Visible = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlEducationStartMonth.ClientID;
                            }
                        }
                    }
                }

                // Date Error Checking
                if (!hasError && hasStartDate && hasEndDate)
                {
                    if (!cbEducationCurrent.Checked)
                    {
                        if ((Convert.ToInt32(ddlEducationStartYear.SelectedValue) > Convert.ToInt32(ddlEducationEndYear.SelectedValue))
                            || ((Convert.ToInt32(ddlEducationEndYear.SelectedValue) == Convert.ToInt32(ddlEducationStartYear.SelectedValue) && (Convert.ToInt32(ddlEducationEndMonth.SelectedValue) < Convert.ToInt32(ddlEducationStartMonth.SelectedValue)))))
                        {
                            phEducationEndError.Visible = true;
                            hasError = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlEducationStartMonth.ClientID;
                            }
                        }
                    }
                }

                if (hasError)
                {
                    QualificationNamesAutoCompleteJS(false);

                    StandardResetJS();
                    OpenRepeaterDiv(string.Empty, controltofocus);

                    acEducation.Attributes.Add("class", "section-content edit-mode");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "EducationError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Education" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);

                    return;
                }

                int educationid = Convert.ToInt32(e.CommandArgument);

                using (MemberQualification education = MemberQualificationService.GetByMemberQualificationId(educationid))
                {
                    if (education != null)
                    {
                        education.SchoolName = tbEducationInstitute.Text;
                        education.CountryId = (string.IsNullOrWhiteSpace(ddlEducationCountry.SelectedValue)) ? (int?)null : Convert.ToInt32(ddlEducationCountry.SelectedValue);
                        education.City = tbEducationState.Text;
                        education.QualificationLevelId = Convert.ToInt32(ddlEducationQualificationLevel.SelectedValue);
                        education.Degree = tbEducationQualificationName.Text;
                        education.QualificationLevelOther = tbEducationOtherQualification.Text;
                        if (hasStartDate)
                        {
                            education.StartMonth = Convert.ToInt32(ddlEducationStartMonth.SelectedValue);
                            education.StartYear = Convert.ToInt32(ddlEducationStartYear.SelectedValue);
                        }
                        else
                        {
                            education.StartMonth = null;
                            education.StartYear = null;
                        }

                        if (hasEndDate)
                        {
                            education.EndMonth = Convert.ToInt32(ddlEducationEndMonth.SelectedValue);
                            education.EndYear = Convert.ToInt32(ddlEducationEndYear.SelectedValue);
                        }
                        else
                        {
                            education.EndMonth = null;
                            education.EndYear = null;
                        }

                        education.Present = cbEducationCurrent.Checked;

                        //graduated
                        education.Graduated = cbEducationGraduated.Checked;
                        int nonGradCredits = 0;
                        if (cbEducationGraduated.Checked)
                            education.NonGraduatedCredits = null;
                        else
                        {
                            if (string.IsNullOrEmpty(tbEducationGraduatedCredits.Text))
                            {
                                education.NonGraduatedCredits = null;
                            }
                            else if (int.TryParse(tbEducationGraduatedCredits.Text, out nonGradCredits))
                            {
                                education.NonGraduatedCredits = nonGradCredits;
                            }
                        }

                        if (education.Present.Value)
                        {
                            education.EndMonth = null;
                            education.EndYear = null;
                        }

                        MemberQualificationService.Update(education);
                        UpdateMemberLastModified();
                        string educationdate = string.Empty;
                        if (education.StartYear.HasValue && education.StartMonth.HasValue)
                        {
                            DateTime StartDate = new DateTime(education.StartYear.Value, education.StartMonth.Value, 1);
                            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            if (education.EndYear.HasValue && education.EndMonth.HasValue)
                            {
                                EndDate = new DateTime(education.EndYear.Value, education.EndMonth.Value, 1);
                            }
                            TimeSpan timespan = EndDate.Subtract(StartDate);

                            string startmonth = string.Empty;
                            string endmonth = string.Empty;
                            string duration = string.Empty;
                            DateTime timespandt = DateTime.MinValue + timespan;

                            foreach (ListItem month in ddlEducationStartMonth.Items)
                            {
                                if (month.Value == education.StartMonth.Value.ToString())
                                {
                                    startmonth = CommonFunction.GetResourceValue(month.Text);
                                    break;
                                }
                            }
                            if (education.EndMonth.HasValue)
                            {
                                foreach (ListItem month in ddlEducationEndMonth.Items)
                                {
                                    if (month.Value == education.EndMonth.Value.ToString())
                                    {
                                        endmonth = CommonFunction.GetResourceValue(month.Text);
                                        break;
                                    }
                                }
                            }

                            if (timespandt.Year - 1 > 0)
                            {
                                duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                            }

                            if (timespandt.Month - 1 > 0)
                            {
                                if (!string.IsNullOrWhiteSpace(duration))
                                {
                                    duration += ", ";
                                }

                                duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                            }

                            if (timespandt.Year == 1 && timespandt.Month == 1)
                            {
                                duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                            }

                            if (education.Present.Value)
                            {
                                educationdate = string.Format("{0} {1} - {2} / ({3})", startmonth, education.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                            }
                            else
                            {
                                educationdate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, education.StartYear, endmonth, education.EndYear, duration);
                            }
                        }

                        ltInstitute.Text = HttpUtility.HtmlEncode(education.SchoolName);


                        List<string> educationlocation = new List<string>();
                        if (!string.IsNullOrWhiteSpace(education.City))
                            educationlocation.Add(education.City);

                        if (education.CountryId.HasValue)
                        {
                            foreach (ListItem country in ddlEducationCountry.Items)
                            {
                                if (country.Value == education.CountryId.Value.ToString())
                                {
                                    educationlocation.Add(country.Text);
                                    break;
                                }
                            }
                        }

                        if (educationlocation != null && educationlocation.Count > 0)
                            ltEducationLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'><!-- icon --></span>{0}</address>",
                                                                        HttpUtility.HtmlEncode(JoinText(educationlocation)));

                        //ltEducationLocation.Text = HttpUtility.HtmlEncode(JoinText(educationlocation));
                        ltQualificationName.Text = HttpUtility.HtmlEncode(education.Degree);
                        ltEducationDate.Text = educationdate;
                        ltEducationDescription.Text = HttpUtility.HtmlEncode(education.QualificationLevelOther);


                        if (education.QualificationLevelId.HasValue)
                        {
                            ltInstitute.Text += " (" + HttpUtility.HtmlEncode(ddlEducationQualificationLevel.SelectedItem.Text) + ")";
                        }
                    }
                }

            }

            if (e.CommandName == "EducationDelete")
            {
                DeleteEducation(Convert.ToInt32(e.CommandArgument));


                /*using (TList<Entities.MemberQualification> educations = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId))
                {
                    rptEducation.DataSource = educations;
                    rptEducation.DataBind();

                    phNavEducation.Visible = (educations.Count == 0);
                    phAddEntryTextEducation.Visible = (educations.Count == 0);
                    phTickEducation.Visible = (educations.Count > 0);
                }*/
            }

            // Update education
            LoadCountry();
            LoadCalendar();
            LoadMemberQualificationLevel();

            SetEducation();

            QualificationNamesAutoCompleteJS(false);

            StandardResetJS();

            acEducation.Attributes.Add("class", "section-content");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "EducationError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Education" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);
            SetMemberPoints();
        }

        protected void rptEducation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltInstitute = e.Item.FindControl("ltInstitute") as Literal;
                Literal ltEducationLocation = e.Item.FindControl("ltEducationLocation") as Literal;
                Literal ltQualificationName = e.Item.FindControl("ltQualificationName") as Literal;
                Literal ltEducationDate = e.Item.FindControl("ltEducationDate") as Literal;
                Literal ltEducationDescription = e.Item.FindControl("ltEducationDescription") as Literal;

                TextBox tbEducationInstitute = e.Item.FindControl("tbEducationInstitute") as TextBox;
                DropDownList ddlEducationCountry = e.Item.FindControl("ddlEducationCountry") as DropDownList;
                TextBox tbEducationState = e.Item.FindControl("tbEducationState") as TextBox;
                DropDownList ddlEducationQualificationLevel = e.Item.FindControl("ddlEducationQualificationLevel") as DropDownList;
                TextBox tbEducationQualificationName = e.Item.FindControl("tbEducationQualificationName") as TextBox;
                TextBox tbEducationOtherQualification = e.Item.FindControl("tbEducationOtherQualification") as TextBox;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbEducationGraduated = e.Item.FindControl("cbEducationGraduated") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                TextBox tbEducationGraduatedCredits = e.Item.FindControl("tbEducationGraduatedCredits") as TextBox;
                DropDownList ddlEducationStartMonth = e.Item.FindControl("ddlEducationStartMonth") as DropDownList;
                DropDownList ddlEducationStartYear = e.Item.FindControl("ddlEducationStartYear") as DropDownList;
                DropDownList ddlEducationEndMonth = e.Item.FindControl("ddlEducationEndMonth") as DropDownList;
                DropDownList ddlEducationEndYear = e.Item.FindControl("ddlEducationEndYear") as DropDownList;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbEducationCurrent = e.Item.FindControl("cbEducationCurrent") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                LinkButton lbEducationSave = e.Item.FindControl("lbEducationSave") as LinkButton;
                LinkButton lbEducationDelete = e.Item.FindControl("lbEducationDelete") as LinkButton;
                System.Web.UI.HtmlControls.HtmlAnchor aEducationEdit = e.Item.FindControl("aEducationEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aEducationEdit.Attributes.Add("href", "#edit-Education" + (e.Item.ItemIndex + 1).ToString());

                //placeholders
                tbEducationInstitute.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelInstitutionName"));
                tbEducationState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityState"));
                tbEducationQualificationName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelQualificationName"));
                tbEducationOtherQualification.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOtherQualification"));

                Entities.MemberQualification education = e.Item.DataItem as Entities.MemberQualification;
                lbEducationDelete.CommandArgument = education.MemberQualificationId.ToString();
                lbEducationDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbEducationDelete.ClientID + "').prop('href'))});";
                ddlEducationStartMonth.Items.Clear();
                ddlEducationStartMonth.DataValueField = "value";
                ddlEducationStartMonth.DataTextField = "text";
                ddlEducationStartMonth.DataSource = MonthList;
                ddlEducationStartMonth.DataBind();
                ddlEducationStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlEducationStartYear.Items.Clear();
                ddlEducationStartYear.DataValueField = "value";
                ddlEducationStartYear.DataTextField = "text";
                ddlEducationStartYear.DataSource = YearList;
                ddlEducationStartYear.DataBind();
                ddlEducationStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlEducationEndMonth.Items.Clear();
                ddlEducationEndMonth.DataValueField = "value";
                ddlEducationEndMonth.DataTextField = "text";
                ddlEducationEndMonth.DataSource = MonthList;
                ddlEducationEndMonth.DataBind();
                ddlEducationEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlEducationEndYear.Items.Clear();
                ddlEducationEndYear.DataValueField = "value";
                ddlEducationEndYear.DataTextField = "text";
                ddlEducationEndYear.DataSource = FutureYearList;
                ddlEducationEndYear.DataBind();
                ddlEducationEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlEducationCountry.Items.Clear();
                ddlEducationCountry.DataValueField = "CountryID";
                ddlEducationCountry.DataTextField = "CountryName";
                ddlEducationCountry.DataSource = CountryList;
                ddlEducationCountry.DataBind();
                ddlEducationCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

                ddlEducationQualificationLevel.Items.Clear();
                ddlEducationQualificationLevel.DataValueField = "Value";
                ddlEducationQualificationLevel.DataTextField = "Key";
                ddlEducationQualificationLevel.DataSource = QualificationLevelList;
                ddlEducationQualificationLevel.DataBind();
                ddlEducationQualificationLevel.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));

                //Graduated
                if (education.Graduated != null && education.Graduated.Value)
                {
                    tbEducationGraduatedCredits.Enabled = false;
                    cbEducationGraduated.Checked = true;
                }
                else
                {
                    tbEducationGraduatedCredits.Enabled = true;
                    tbEducationGraduatedCredits.Text = education.NonGraduatedCredits == null ? "0" : education.NonGraduatedCredits.ToString();
                    cbEducationGraduated.Checked = false;
                }

                string educationdate = string.Empty;
                if (education.StartYear.HasValue && education.StartMonth.HasValue)
                {
                    DateTime StartDate = new DateTime(education.StartYear.Value, education.StartMonth.Value, 1);
                    DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    if (education.EndYear.HasValue && education.EndMonth.HasValue)
                    {
                        EndDate = new DateTime(education.EndYear.Value, education.EndMonth.Value, 1);
                    }
                    TimeSpan timespan = EndDate.Subtract(StartDate);

                    string startmonth = string.Empty;
                    string endmonth = string.Empty;
                    string duration = string.Empty;
                    DateTime timespandt = DateTime.MinValue + timespan;

                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == education.StartMonth.Value.ToString())
                        {
                            startmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }
                    if (education.EndMonth.HasValue)
                    {
                        foreach (ListItem month in MonthList)
                        {
                            if (month.Value == education.EndMonth.Value.ToString())
                            {
                                endmonth = CommonFunction.GetResourceValue(month.Text);
                                break;
                            }
                        }
                    }

                    if (timespandt.Year - 1 > 0)
                    {
                        duration = (timespandt.Year - 1).ToString() + " " + ((timespandt.Year - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                    }

                    if (timespandt.Month - 1 > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(duration))
                        {
                            duration += ", ";
                        }

                        duration += (timespandt.Month - 1).ToString() + " " + ((timespandt.Month - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                    }

                    if (timespandt.Year == 1 && timespandt.Month == 1)
                    {
                        duration += "1 " + CommonFunction.GetResourceValue("LabelMonth");
                    }

                    if (education.Present.Value)
                    {
                        educationdate = string.Format("{0} {1} - {2} / ({3})", startmonth, education.StartYear, CommonFunction.GetResourceValue("LabelPresent"), duration);
                    }
                    else
                    {
                        educationdate = string.Format("{0} {1} - {2} {3} / ({4})", startmonth, education.StartYear, endmonth, education.EndYear, duration);
                    }
                }

                ltInstitute.Text = HttpUtility.HtmlEncode(education.SchoolName);


                List<string> educationlocation = new List<string>();
                if (!string.IsNullOrWhiteSpace(education.City))
                    educationlocation.Add(education.City);
                if (education.CountryId.HasValue)
                {
                    foreach (Entities.Countries country in CountryList)
                    {
                        if (country.CountryId == education.CountryId.Value)
                        {
                            educationlocation.Add(country.CountryName);
                            break;
                        }
                    }
                }

                if (educationlocation != null && educationlocation.Count > 0)
                    ltEducationLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'><!-- icon --></span>{0}</address>",
                                                                HttpUtility.HtmlEncode(JoinText(educationlocation)));

                ltQualificationName.Text = HttpUtility.HtmlEncode(education.Degree);
                ltEducationDate.Text = educationdate;
                ltEducationDescription.Text = HttpUtility.HtmlEncode(education.QualificationLevelOther);

                tbEducationInstitute.Text = education.SchoolName;
                if (education.CountryId.HasValue)
                {
                    ddlEducationCountry.SelectedValue = education.CountryId.Value.ToString();
                }
                tbEducationState.Text = education.City;
                if (education.QualificationLevelId.HasValue)
                {
                    ddlEducationQualificationLevel.SelectedValue = education.QualificationLevelId.Value.ToString();
                }

                tbEducationQualificationName.Text = education.Degree;
                tbEducationOtherQualification.Text = education.QualificationLevelOther;


                if (education.StartYear.HasValue)
                {
                    ddlEducationStartYear.SelectedValue = education.StartYear.Value.ToString();
                }

                if (education.StartMonth.HasValue)
                {
                    ddlEducationStartMonth.SelectedValue = education.StartMonth.Value.ToString();
                }

                if (education.EndYear.HasValue)
                {
                    ddlEducationEndYear.SelectedValue = education.EndYear.Value.ToString();
                }

                if (education.EndMonth.HasValue)
                {
                    ddlEducationEndMonth.SelectedValue = education.EndMonth.Value.ToString();
                }

                if (education.Present.HasValue)
                {
                    cbEducationCurrent.Checked = education.Present.Value;
                    if (cbEducationCurrent.Checked)
                    {
                        ddlEducationEndMonth.Enabled = false;
                        ddlEducationEndYear.Enabled = false;
                    }
                }
                lbEducationSave.CommandName = "EducationSave";
                lbEducationSave.CommandArgument = education.MemberQualificationId.ToString();
                if (education.QualificationLevelId.HasValue)
                {
                    ltInstitute.Text += " (" + HttpUtility.HtmlEncode(ddlEducationQualificationLevel.SelectedItem.Text) + ")";
                }


            }
        }

        protected void lbEducationAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptEducation.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acEducation = item.FindControl("acEducation") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acEducation.Attributes.Add("class", "section-content");
            }

            bool hasError = false;
            string controltofocus = string.Empty;

            phEducationAddInstituteError.Visible = false;
            phEducationAddQualificationLevelError.Visible = false;
            phEducationAddQualificationNameError.Visible = false;
            phEducationAddEndError.Visible = false;
            phEducationAddStateError.Visible = false;
            phEducationAddOtherQualificationError.Visible = false;
            phEducationAddGraduatedCreditsError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbEducationAddInstitute.Text))
            {
                hasError = true;
                phEducationAddInstituteError.Visible = true;
                ltErrorAddEdicationInstitute.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbEducationAddInstitute.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbEducationAddInstitute.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phEducationAddInstituteError.Visible = true;
                    ltErrorAddEdicationInstitute.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationAddInstitute.ClientID;
                    }
                }
            }

            if (ddlEducationAddQualificationLevel.SelectedIndex == 0)
            {
                hasError = true;
                phEducationAddQualificationLevelError.Visible = true;
                ltErrorAddEdicationInstitute.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = ddlEducationAddQualificationLevel.ClientID;
                }
            }

            if (string.IsNullOrWhiteSpace(tbEducationAddQualificationName.Text))
            {
                hasError = true;
                phEducationAddQualificationNameError.Visible = true;
                ltErrorAddEducationAddQualificationName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbEducationAddQualificationName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbEducationAddQualificationName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phEducationAddQualificationNameError.Visible = true;
                    ltErrorAddEducationAddQualificationName.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationAddQualificationName.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbEducationAddState.Text))
            {
                if (Regex.IsMatch(tbEducationAddState.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phEducationAddStateError.Visible = true;
                    ltErrorAddEducationState.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationAddState.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbEducationAddOtherQualification.Text))
            {
                if (Regex.IsMatch(tbEducationAddOtherQualification.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phEducationAddOtherQualificationError.Visible = true;
                    ltErrorAddEducationOtherQualification.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationAddOtherQualification.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbEducationAddGraduatedCredits.Text))
            {
                if (Regex.IsMatch(tbEducationAddGraduatedCredits.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phEducationAddGraduatedCreditsError.Visible = true;
                    ltErrorAddEducationGraduatedCredits.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbEducationAddGraduatedCredits.ClientID;
                    }
                }
            }

            bool hasStartDate = false;
            DateTime? thisStartDate = null;
            if (ddlEducationAddStartYear.SelectedValue != "0" && ddlEducationAddStartMonth.SelectedValue != "0")
            {
                hasStartDate = true;
                thisStartDate = new DateTime(Convert.ToInt32(ddlEducationAddStartYear.SelectedValue), Convert.ToInt32(ddlEducationAddStartMonth.SelectedValue), 1);
                if (DateTime.Now < thisStartDate)
                {
                    hasError = true;
                    phEducationAddEndError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlEducationAddStartMonth.ClientID;
                    }
                }
            }

            bool hasEndDate = false;
            if (ddlEducationAddEndYear.SelectedValue != "0" && ddlEducationAddEndMonth.SelectedValue != "0")
            {
                hasEndDate = true;
                if (thisStartDate != null)
                {
                    if (thisStartDate > new DateTime(Convert.ToInt32(ddlEducationAddEndYear.SelectedValue), Convert.ToInt32(ddlEducationAddEndMonth.SelectedValue), 1))
                    {
                        hasError = true;
                        phEducationAddEndError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlEducationAddStartMonth.ClientID;
                        }
                    }
                }
            }

            // Date Error Checking
            if (!hasError && hasStartDate && hasEndDate)
            {
                if (!cbEducationAddCurrent.Checked)
                {
                    if ((Convert.ToInt32(ddlEducationAddStartYear.SelectedValue) > Convert.ToInt32(ddlEducationAddEndYear.SelectedValue))
                        || ((Convert.ToInt32(ddlEducationAddEndYear.SelectedValue) == Convert.ToInt32(ddlEducationAddStartYear.SelectedValue) && (Convert.ToInt32(ddlEducationAddEndMonth.SelectedValue) < Convert.ToInt32(ddlEducationAddStartMonth.SelectedValue)))))
                    {
                        phEducationAddEndError.Visible = true;
                        hasError = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlEducationAddStartMonth.ClientID;
                        }
                    }
                }
            }

            if (hasError)
            {
                QualificationNamesAutoCompleteJS(false);

                StandardResetJS();
                OpenAddDiv(string.Empty, controltofocus);

                acEducationAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newEducation.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            MemberQualification education = new MemberQualification();

            education.SchoolName = tbEducationAddInstitute.Text;
            education.CountryId = Convert.ToInt32(ddlEducationAddCountry.SelectedValue);
            education.City = tbEducationAddState.Text;
            education.QualificationLevelId = Convert.ToInt32(ddlEducationAddQualificationLevel.SelectedValue);
            education.Degree = tbEducationAddQualificationName.Text;
            education.QualificationLevelOther = tbEducationAddOtherQualification.Text;
            if (hasStartDate)
            {
                education.StartMonth = Convert.ToInt32(ddlEducationAddStartMonth.SelectedValue);
                education.StartYear = Convert.ToInt32(ddlEducationAddStartYear.SelectedValue);
            }
            else
            {
                education.StartMonth = null;
                education.StartYear = null;
            }
            if (hasEndDate)
            {
                education.EndMonth = Convert.ToInt32(ddlEducationAddEndMonth.SelectedValue);
                education.EndYear = Convert.ToInt32(ddlEducationAddEndYear.SelectedValue);
            }
            else
            {
                education.EndMonth = null;
                education.EndYear = null;
            }
            education.Present = cbEducationAddCurrent.Checked;
            if (cbEducationAddCurrent.Checked)
            {
                education.EndMonth = null;
                education.EndYear = null;
            }
            education.MemberId = SessionData.Member.MemberId;

            //graduated
            education.Graduated = cbEducationAddGraduated.Checked;
            int nonGradCredits = 0;
            if (cbEducationAddGraduated.Checked)
                education.NonGraduatedCredits = null;
            else
            {
                if (string.IsNullOrEmpty(tbEducationAddGraduatedCredits.Text))
                {
                    education.NonGraduatedCredits = null;
                }
                else if (int.TryParse(tbEducationAddGraduatedCredits.Text, out nonGradCredits))
                {
                    education.NonGraduatedCredits = nonGradCredits;
                }
            }

            MemberQualificationService.Insert(education);
            UpdateMemberLastModified();
            LoadCountry();
            LoadCalendar();
            LoadMemberQualificationLevel();

            SetEducation();
            /*using (TList<Entities.MemberQualification> educations = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptEducation.DataSource = educations;
                rptEducation.DataBind();

                phNavEducation.Visible = (educations.Count == 0);
                phAddEntryTextEducation.Visible = (educations.Count == 0);
                phTickEducation.Visible = (educations.Count > 0);
            }*/

            // clear the fields
            tbEducationAddInstitute.Text = string.Empty;
            ddlEducationAddCountry.SelectedIndex = 0;
            tbEducationAddState.Text = string.Empty;
            ddlEducationAddQualificationLevel.SelectedIndex = 0;
            tbEducationAddQualificationName.Text = string.Empty;
            tbEducationAddOtherQualification.Text = string.Empty;
            ddlEducationAddStartMonth.SelectedIndex = 0;
            ddlEducationAddStartYear.SelectedIndex = 0;
            ddlEducationAddEndMonth.SelectedIndex = 0;
            ddlEducationAddEndYear.SelectedIndex = 0;
            cbEducationAddCurrent.Checked = false;
            ddlEducationAddEndMonth.Enabled = true;
            ddlEducationAddEndYear.Enabled = true;

            cbEducationAddGraduated.Checked = false;
            tbEducationAddGraduatedCredits.Text = string.Empty;

            QualificationNamesAutoCompleteJS(false);

            StandardResetJS();


            acEducationAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newEducation.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Skills

        private void LoadSkills()
        {
            //set skills for member
            if (SessionData.Member != null)
            {
                int currentMemberID = SessionData.Member.MemberId;

                MembersService _serv = new MembersService();
                using (JXTPortal.Entities.Members objMembers = _serv.GetByMemberId(currentMemberID))
                {
                    if (objMembers != null && objMembers.SiteId == SessionData.Site.SiteId)
                    {
                        if (!string.IsNullOrEmpty(objMembers.Skills))
                        {
                            string[] split = objMembers.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).ToArray();

                            rptSkills.DataSource = split;
                            rptSkills.DataBind();

                            phTickSkills.Visible = split.Count() > 0;
                            phAddEntryTextSkills.Visible = (split.Count() == 0);
                            phSkillsDisplay.Visible = (split.Count() > 0);
                        }

                        phNavSkills.Visible = (string.IsNullOrWhiteSpace(objMembers.Skills) || objMembers.Skills == "||");
                    }
                }
            }
        }

        private int SetSkills(Entities.Members member, int point)
        {
            // Member

            // MemberID
            // Skills
            //SearchField

            return 0;
        }

        protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SkillDelete")
            {
                string targetValue = e.CommandArgument as string;

                if (SessionData.Member != null)
                {
                    int currentMemberID = SessionData.Member.MemberId;

                    MembersService _serv = new MembersService();
                    using (JXTPortal.Entities.Members objMembers = _serv.GetByMemberId(currentMemberID))
                    {
                        if (objMembers != null && objMembers.SiteId == SessionData.Site.SiteId)
                        {

                            if (!string.IsNullOrEmpty(objMembers.Skills))
                            {
                                string targetPattern = @"||" + targetValue + @"||";
                                int targetIndex = objMembers.Skills.IndexOf(targetPattern);

                                if (targetIndex != -1)
                                {
                                    targetIndex += 2; //add 2 to avoid the "||" prior
                                    objMembers.Skills = objMembers.Skills.Remove(targetIndex, targetPattern.Length - 2);

                                    _serv.Update(objMembers);

                                    LoadSkills();
                                }
                            }
                        }
                    }
                }
            }

            StandardResetJS();

            //set autocomplete            
            SkillsAutoCompleteJS(false);
            SetMemberPoints();

        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltSkill = e.Item.FindControl("ltSkill") as Literal;
                LinkButton lbSkillDelete = e.Item.FindControl("lbSkillDelete") as LinkButton;

                string skillStr = e.Item.DataItem as string;
                ltSkill.Text = HttpUtility.HtmlEncode(skillStr);
                lbSkillDelete.CommandArgument = skillStr;
            }
        }

        protected void lbSkillsAdd_Click(object sender, EventArgs e)
        {
            ltAddSkillErrorMsgWrapper.Visible = false;

            if (!string.IsNullOrWhiteSpace(tbSkillsAddSkill.Text))
            {
                if (Regex.IsMatch(tbSkillsAddSkill.Text, ContentValidationRegex) == false)
                {
                    ltAddSkillErrorMsgWrapper.Visible = true;
                    ltAddSkillErrorMsg.SetLanguageCode = "ValidateNoHTMLContent";

                    StandardResetJS();
                    OpenRepeaterDiv(string.Empty, tbSkillsAddSkill.ClientID);

                    SkillsAutoCompleteJS(false);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AddSkillNoHTMLFocus", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#tbSkillsAddSkill').focus();
		                });
                    </script>
                    ", false);
                    return;
                }
            }

            string targetValue = tbSkillsAddSkill.Text;

            if (SessionData.Member != null && !string.IsNullOrWhiteSpace(targetValue) && !targetValue.Contains("||"))
            {
                int currentMemberID = SessionData.Member.MemberId;
                targetValue = targetValue.Trim();

                MembersService _serv = new MembersService();
                using (JXTPortal.Entities.Members objMembers = _serv.GetByMemberId(currentMemberID))
                {
                    if (objMembers != null && objMembers.SiteId == SessionData.Site.SiteId)
                    {
                        bool alreadyExists = !string.IsNullOrEmpty(objMembers.Skills) && objMembers.Skills.ToLower().Contains("||" + targetValue.ToLower() + "||");

                        //no matter what, we keep this skills panel open
                        acSkills.Attributes.Add("class", "section-content new-block-holder edit-mode");
                        newSkill.Attributes.Add("class", "profile-edit collapse in");

                        if (alreadyExists)
                        {
                            ltAddSkillErrorMsgWrapper.Visible = true;
                            ltAddSkillErrorMsg.SetLanguageCode = "LabelAddSkillAlreadyExist";

                            StandardResetJS();
                            OpenRepeaterDiv(string.Empty, tbSkillsAddSkill.ClientID);

                            //set autocomplete            
                            SkillsAutoCompleteJS(false);
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AddSkillFocus", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#tbSkillsAddSkill').focus();
		                });
                    </script>
                    ", false);
                            return;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(objMembers.Skills))
                                objMembers.Skills = "||";
                            else
                            {
                                //because existing profiles may have skills value but does not have the || at the end of it, we have to check that too
                                if (!objMembers.Skills.Trim().EndsWith("||"))
                                {
                                    objMembers.Skills += "||";
                                }
                            }

                            objMembers.Skills += targetValue + "||";
                            _serv.Update(objMembers);

                            LoadSkills();
                            tbSkillsAddSkill.Text = string.Empty;
                        }

                    }
                }
            }

            StandardResetJS();
            SkillsAutoCompleteJS(false);

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AddSkillFocus", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#tbSkillsAddSkill').focus();
		                });
                    </script>
                    ", false);

            //hide the add skills form
            //acSkills.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            //newSkill.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Certificates

        private int SetCertifications()
        {
            using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptCertification.DataSource = membercertificates.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptCertification.DataBind();

                phNavCertification.Visible = (membercertificates.Count == 0);
                phAddEntryTextCertificates.Visible = (membercertificates.Count == 0);
                phTickCertificate.Visible = (membercertificates.Count > 0);
            }

            return 0;
        }

        private void DeleteCertifications(int certificateid)
        {
            using (MemberCertificateMemberships membercertificate = MemberCertificateMembershipsService.GetByMemberCertificateMembershipId(certificateid))
            {
                if (membercertificate != null && membercertificate.MemberId == SessionData.Member.MemberId)
                {
                    MemberCertificateMembershipsService.Delete(membercertificate);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptCertification_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acCertificateAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newCnM.Attributes.Add("class", "profile-edit collapse");

            Literal ltAuthority = e.Item.FindControl("ltAuthority") as Literal;
            Literal ltCertificateMembershipName = e.Item.FindControl("ltCertificateMembershipName") as Literal;
            Literal ltCertificateMembershipDate = e.Item.FindControl("ltCertificateMembershipDate") as Literal;
            Literal ltCertificateMembershipUrl = e.Item.FindControl("ltCertificateMembershipUrl") as Literal;
            Literal ltCertificateMembershipUrlNo = e.Item.FindControl("ltCertificateMembershipUrlNo") as Literal;

            TextBox tbCertificateCertificateMembershipName = e.Item.FindControl("tbCertificateCertificateMembershipName") as TextBox;
            PlaceHolder phCertificateMembershipNameError = e.Item.FindControl("phCertificateMembershipNameError") as PlaceHolder;
            ucLanguageLiteral ltErrorCertificateMembershipName = e.Item.FindControl("ltErrorCertificateMembershipName") as ucLanguageLiteral;
            TextBox tbCertificateAuthority = e.Item.FindControl("tbCertificateAuthority") as TextBox;
            PlaceHolder phCertificateAuthorityError = e.Item.FindControl("phCertificateAuthorityError") as PlaceHolder;
            ucLanguageLiteral ltErrorCertificateAuthority = e.Item.FindControl("ltErrorCertificateAuthority") as ucLanguageLiteral;
            TextBox tbCertificateMembershipNumber = e.Item.FindControl("tbCertificateMembershipNumber") as TextBox;
            TextBox tbCertificateURL = e.Item.FindControl("tbCertificateURL") as TextBox;
            DropDownList ddlCertificateStartMonth = e.Item.FindControl("ddlCertificateStartMonth") as DropDownList;
            DropDownList ddlCertificateStartYear = e.Item.FindControl("ddlCertificateStartYear") as DropDownList;
            DropDownList ddlCertificateEndMonth = e.Item.FindControl("ddlCertificateEndMonth") as DropDownList;
            DropDownList ddlCertificateEndYear = e.Item.FindControl("ddlCertificateEndYear") as DropDownList;
            PlaceHolder phCertificateError = e.Item.FindControl("phCertificateError") as PlaceHolder;
            System.Web.UI.HtmlControls.HtmlInputCheckBox cbCertificateDoesNotExpire = e.Item.FindControl("cbCertificateDoesNotExpire") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            LinkButton lbCertificateSave = e.Item.FindControl("lbCertificateSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlAnchor aCertificateEdit = e.Item.FindControl("aCertificateEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            aCertificateEdit.Attributes.Add("href", "#edit-CnM" + (e.Item.ItemIndex + 1).ToString());
            System.Web.UI.HtmlControls.HtmlGenericControl acCertificate = e.Item.FindControl("acCertificate") as System.Web.UI.HtmlControls.HtmlGenericControl;

            PlaceHolder phCertificateMembershipNumberError = e.Item.FindControl("phCertificateMembershipNumberError") as PlaceHolder;
            ucLanguageLiteral ltErrorCertificateMembershipNumber = e.Item.FindControl("ltErrorCertificateMembershipNumber") as ucLanguageLiteral;

            PlaceHolder phCertificateURLError = e.Item.FindControl("phCertificateURLError") as PlaceHolder;
            ucLanguageLiteral ltErrorCertificateURL = e.Item.FindControl("ltErrorCertificateURL") as ucLanguageLiteral;

            ddlCertificateEndMonth.Enabled = !(cbCertificateDoesNotExpire.Checked);
            ddlCertificateEndYear.Enabled = !(cbCertificateDoesNotExpire.Checked);

            if (e.CommandName == "CertificateSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;

                phCertificateMembershipNameError.Visible = false;
                phCertificateAuthorityError.Visible = false;
                phCertificateMembershipNumberError.Visible = false;
                phCertificateURLError.Visible = false;
                phCertificateError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbCertificateCertificateMembershipName.Text))
                {
                    hasError = true;
                    phCertificateMembershipNameError.Visible = true;
                    ltErrorCertificateMembershipName.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateCertificateMembershipName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbCertificateCertificateMembershipName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phCertificateMembershipNameError.Visible = true;
                        ltErrorCertificateMembershipName.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbCertificateCertificateMembershipName.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbCertificateAuthority.Text))
                {
                    hasError = true;
                    phCertificateAuthorityError.Visible = true;
                    ltErrorCertificateAuthority.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateAuthority.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbCertificateAuthority.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phCertificateAuthorityError.Visible = true;
                        ltErrorCertificateAuthority.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbCertificateAuthority.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbCertificateMembershipNumber.Text))
                {
                    if (Regex.IsMatch(tbCertificateMembershipNumber.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phCertificateMembershipNumberError.Visible = true;
                        ltErrorCertificateMembershipNumber.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbCertificateMembershipNumber.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tbCertificateURL.Text))
                {
                    if (Regex.IsMatch(tbCertificateURL.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phCertificateURLError.Visible = true;
                        ltErrorCertificateURL.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbCertificateURL.ClientID;
                        }
                    }
                }

                bool hasAddDate = false;
                DateTime? thisIssueDateTime = null;
                if (ddlCertificateStartYear.SelectedValue != "0" && ddlCertificateStartMonth.SelectedValue != "0")
                {
                    hasAddDate = true;
                    DateTime thisDateTime1;
                    try
                    {
                        thisIssueDateTime = new DateTime(Convert.ToInt32(ddlCertificateStartYear.SelectedValue), Convert.ToInt32(ddlCertificateStartMonth.SelectedValue), 1);
                        if (DateTime.Now < thisIssueDateTime)
                        {
                            hasError = true;
                            phCertificateError.Visible = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlCertificateStartMonth.ClientID;
                            }
                        }
                    }
                    catch
                    {
                        hasError = true;
                        phCertificateError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlCertificateStartMonth.ClientID;
                        }
                    }
                }

                bool hasExpiryDate = false;
                if (ddlCertificateEndYear.SelectedValue != "0" && ddlCertificateEndMonth.SelectedValue != "0")
                {
                    hasExpiryDate = true;
                    DateTime thisExpiryTime;
                    try
                    {
                        thisExpiryTime = new DateTime(Convert.ToInt32(ddlCertificateEndYear.SelectedValue), Convert.ToInt32(ddlCertificateEndMonth.SelectedValue), 1);

                        if (thisIssueDateTime != null)
                        {
                            if (thisIssueDateTime > thisExpiryTime)
                            {
                                hasError = true;
                                phCertificateError.Visible = true;

                                if (string.IsNullOrWhiteSpace(controltofocus))
                                {
                                    controltofocus = ddlCertificateEndMonth.ClientID;
                                }
                            }
                        }

                    }
                    catch
                    {
                        hasError = true;
                        phCertificateError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlCertificateEndMonth.ClientID;
                        }
                    }
                }

                // Date Error Checking
                if (!cbCertificateDoesNotExpire.Checked)
                {
                    if (!hasError && hasExpiryDate && hasAddDate)
                    {

                        if ((Convert.ToInt32(ddlCertificateStartYear.SelectedValue) > Convert.ToInt32(ddlCertificateEndYear.SelectedValue))
                            || ((Convert.ToInt32(ddlCertificateEndYear.SelectedValue) == Convert.ToInt32(ddlCertificateStartYear.SelectedValue) && (Convert.ToInt32(ddlCertificateEndMonth.SelectedValue) < Convert.ToInt32(ddlCertificateStartMonth.SelectedValue)))))
                        {
                            phCertificateError.Visible = true;
                            hasError = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlCertificateStartMonth.ClientID;
                            }
                        }
                    }
                }

                if (hasError)
                {
                    StandardResetJS();
                    OpenRepeaterDiv(aCertificateEdit.ClientID, controltofocus);

                    acCertificate.Attributes.Add("class", "section-content edit-mode");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CertificateError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Education" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);

                    return;
                }

                using (MemberCertificateMemberships certificate = MemberCertificateMembershipsService.GetByMemberCertificateMembershipId(Convert.ToInt32(e.CommandArgument)))
                {

                    if (certificate != null)
                    {
                        certificate.MemberCertificateMembershipName = tbCertificateCertificateMembershipName.Text;
                        certificate.CertificationAuthority = tbCertificateAuthority.Text;
                        certificate.LicenseNumber = tbCertificateMembershipNumber.Text;
                        certificate.CertificationUrl = tbCertificateURL.Text;


                        if (hasAddDate)
                        {
                            certificate.StartMonth = Convert.ToInt32(ddlCertificateStartMonth.SelectedValue);
                            certificate.StartYear = Convert.ToInt32(ddlCertificateStartYear.SelectedValue);
                        }
                        else
                        {
                            certificate.StartMonth = null;
                            certificate.StartYear = null;
                        }
                        if (hasExpiryDate)
                        {
                            certificate.EndMonth = Convert.ToInt32(ddlCertificateEndMonth.SelectedValue);
                            certificate.EndYear = Convert.ToInt32(ddlCertificateEndYear.SelectedValue);
                        }
                        else
                        {
                            certificate.EndMonth = null;
                            certificate.EndYear = null;
                        }

                        if (cbCertificateDoesNotExpire.Checked)
                        {
                            certificate.DoesnotExpire = true;
                            certificate.StartMonth = null;
                            certificate.StartYear = null;
                            certificate.EndMonth = null;
                            certificate.EndYear = null;
                        }

                        MemberCertificateMembershipsService.Update(certificate);
                        UpdateMemberLastModified();
                        string certificatedate = string.Empty;
                        string certificateurlno = string.Empty;
                        string startmonth = string.Empty;
                        string endmonth = string.Empty;

                        ltAuthority.Text = HttpUtility.HtmlEncode(certificate.CertificationAuthority);
                        ltCertificateMembershipName.Text = HttpUtility.HtmlEncode(certificate.MemberCertificateMembershipName);

                        if (certificate.StartMonth.HasValue && certificate.StartYear.HasValue && certificate.EndMonth.HasValue && certificate.EndYear.HasValue)
                        {
                            if (certificate.StartMonth.Value != 0 && certificate.StartYear.Value != 0 && certificate.EndMonth.Value != 0 && certificate.EndYear.Value != 0)
                            {
                                foreach (ListItem month in ddlCertificateStartMonth.Items)
                                {
                                    if (month.Value == certificate.StartMonth.ToString())
                                    {
                                        startmonth = CommonFunction.GetResourceValue(month.Text);
                                        break;
                                    }
                                }

                                certificatedate = startmonth + " " + certificate.StartYear.ToString();


                                foreach (ListItem month in ddlCertificateEndMonth.Items)
                                {
                                    if (month.Value == certificate.EndMonth.ToString())
                                    {
                                        endmonth = CommonFunction.GetResourceValue(month.Text);
                                        break;
                                    }
                                }

                                certificatedate += " - " + endmonth + " " + certificate.EndYear.ToString();
                            }
                            else
                                certificatedate = string.Empty;
                        }
                        else
                        {
                            if (certificate.DoesnotExpire.HasValue && certificate.DoesnotExpire.Value)
                                certificatedate = CommonFunction.GetResourceValue("LabelCertificateDoesNotExpire");
                        }



                        if (!string.IsNullOrWhiteSpace(certificate.CertificationUrl))
                        {
                            certificateurlno = certificate.CertificationUrl;
                        }


                        ltCertificateMembershipDate.Text = HttpUtility.HtmlEncode(certificatedate);
                        ltCertificateMembershipUrlNo.Text = HttpUtility.HtmlEncode(certificate.LicenseNumber);

                        ltCertificateMembershipUrl.Text = string.Format("<a class=\"certificate-url\" target=\"_blank\" href=\"{0}\">{0}</a> ", HttpUtility.HtmlEncode(certificate.CertificationUrl));
                        if (!string.IsNullOrWhiteSpace(certificate.LicenseNumber) && !string.IsNullOrWhiteSpace(certificate.CertificationUrl))
                        {
                            ltCertificateMembershipUrl.Text += "&nbsp;|&nbsp;";
                        }

                    }
                }
            }

            if (e.CommandName == "CertificateDelete")
            {
                DeleteCertifications(Convert.ToInt32(e.CommandArgument));


                /*using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    rptCertification.DataSource = membercertificates;
                    rptCertification.DataBind();

                    phNavCertification.Visible = (membercertificates.Count == 0);
                    phAddEntryTextCertificates.Visible = (membercertificates.Count == 0);
                    phTickCertificate.Visible = (membercertificates.Count > 0);
                }*/
            }


            LoadCountry();
            LoadCalendar();
            // Set certifications
            SetCertifications();


            StandardResetJS();
            CertificateResetJS();

            acCertificate.Attributes.Add("class", "section-content");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CertificateError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-CnM" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);
            SetMemberPoints();
        }

        protected void rptCertification_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltAuthority = e.Item.FindControl("ltAuthority") as Literal;
                Literal ltCertificateMembershipName = e.Item.FindControl("ltCertificateMembershipName") as Literal;
                Literal ltCertificateMembershipDate = e.Item.FindControl("ltCertificateMembershipDate") as Literal;
                Literal ltCertificateMembershipUrl = e.Item.FindControl("ltCertificateMembershipUrl") as Literal;
                Literal ltCertificateMembershipUrlNo = e.Item.FindControl("ltCertificateMembershipUrlNo") as Literal;

                TextBox tbCertificateCertificateMembershipName = e.Item.FindControl("tbCertificateCertificateMembershipName") as TextBox;
                TextBox tbCertificateAuthority = e.Item.FindControl("tbCertificateAuthority") as TextBox;
                TextBox tbCertificateMembershipNumber = e.Item.FindControl("tbCertificateMembershipNumber") as TextBox;
                TextBox tbCertificateURL = e.Item.FindControl("tbCertificateURL") as TextBox;
                DropDownList ddlCertificateStartMonth = e.Item.FindControl("ddlCertificateStartMonth") as DropDownList;
                DropDownList ddlCertificateStartYear = e.Item.FindControl("ddlCertificateStartYear") as DropDownList;
                DropDownList ddlCertificateEndMonth = e.Item.FindControl("ddlCertificateEndMonth") as DropDownList;
                DropDownList ddlCertificateEndYear = e.Item.FindControl("ddlCertificateEndYear") as DropDownList;
                System.Web.UI.HtmlControls.HtmlInputCheckBox cbCertificateDoesNotExpire = e.Item.FindControl("cbCertificateDoesNotExpire") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
                LinkButton lbCertificateSave = e.Item.FindControl("lbCertificateSave") as LinkButton;
                LinkButton lbCertificateDelete = e.Item.FindControl("lbCertificateDelete") as LinkButton;
                System.Web.UI.HtmlControls.HtmlAnchor aCertificateEdit = e.Item.FindControl("aCertificateEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aCertificateEdit.Attributes.Add("href", "#edit-CnM" + (e.Item.ItemIndex + 1).ToString());

                //placeholders
                tbCertificateCertificateMembershipName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEditCertificationsMembershipName"));
                tbCertificateAuthority.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelAuthority"));
                tbCertificateMembershipNumber.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCertificateMembershipNumber"));
                tbCertificateURL.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCertificationURL"));

                MemberCertificateMemberships certificate = e.Item.DataItem as MemberCertificateMemberships;
                lbCertificateDelete.CommandArgument = certificate.MemberCertificateMembershipId.ToString();
                lbCertificateDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbCertificateDelete.ClientID + "').prop('href'))});";

                ddlCertificateStartMonth.Items.Clear();
                ddlCertificateStartMonth.DataValueField = "value";
                ddlCertificateStartMonth.DataTextField = "text";
                ddlCertificateStartMonth.DataSource = MonthList;
                ddlCertificateStartMonth.DataBind();
                ddlCertificateStartMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlCertificateStartYear.Items.Clear();
                ddlCertificateStartYear.DataValueField = "value";
                ddlCertificateStartYear.DataTextField = "text";
                ddlCertificateStartYear.DataSource = YearList;
                ddlCertificateStartYear.DataBind();
                ddlCertificateStartYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlCertificateEndMonth.Items.Clear();
                ddlCertificateEndMonth.DataValueField = "value";
                ddlCertificateEndMonth.DataTextField = "text";
                ddlCertificateEndMonth.DataSource = MonthList;
                ddlCertificateEndMonth.DataBind();
                ddlCertificateEndMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlCertificateEndYear.Items.Clear();
                ddlCertificateEndYear.DataValueField = "value";
                ddlCertificateEndYear.DataTextField = "text";
                ddlCertificateEndYear.DataSource = FutureYearList;
                ddlCertificateEndYear.DataBind();
                ddlCertificateEndYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                string certificatedate = string.Empty;
                string certificateurlno = string.Empty;
                string startmonth = string.Empty;
                string endmonth = string.Empty;

                ltAuthority.Text = HttpUtility.HtmlEncode(certificate.CertificationAuthority);
                ltCertificateMembershipName.Text = HttpUtility.HtmlEncode(certificate.MemberCertificateMembershipName);

                if (certificate.StartMonth.HasValue && certificate.StartYear.HasValue && certificate.EndMonth.HasValue && certificate.EndYear.HasValue)
                {
                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == certificate.StartMonth.ToString())
                        {
                            startmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }

                    certificatedate = startmonth + " " + certificate.StartYear.ToString();

                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == certificate.EndMonth.ToString())
                        {
                            endmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }

                    certificatedate += " - " + endmonth + " " + certificate.EndYear.ToString();
                }
                else
                {
                    if (certificate.DoesnotExpire.HasValue && certificate.DoesnotExpire.Value)
                        certificatedate = CommonFunction.GetResourceValue("LabelCertificateDoesNotExpire");
                }

                if (!string.IsNullOrWhiteSpace(certificate.CertificationUrl))
                {
                    certificateurlno = certificate.CertificationUrl;
                }

                if (!string.IsNullOrWhiteSpace(certificate.LicenseNumber))
                {
                    if (!string.IsNullOrWhiteSpace(certificateurlno))
                    {
                        certificateurlno += " | ";
                    }

                    certificateurlno += string.Format("{0}: {1}", CommonFunction.GetResourceValue("LabelCertificate"), certificate.LicenseNumber);
                }

                ltCertificateMembershipDate.Text = HttpUtility.HtmlEncode(certificatedate);

                ltCertificateMembershipUrl.Text = string.Format("<a class=\"certificate-url\" target=\"_blank\" href=\"{0}\">{0}</a> ", HttpUtility.HtmlEncode(certificate.CertificationUrl));
                ltCertificateMembershipUrlNo.Text = HttpUtility.HtmlEncode(certificate.LicenseNumber);
                if (!string.IsNullOrWhiteSpace(certificate.LicenseNumber) && !string.IsNullOrWhiteSpace(certificate.CertificationUrl))
                {
                    ltCertificateMembershipUrl.Text += "&nbsp;|&nbsp;";
                }

                tbCertificateCertificateMembershipName.Text = certificate.MemberCertificateMembershipName;
                tbCertificateAuthority.Text = certificate.CertificationAuthority;
                tbCertificateMembershipNumber.Text = certificate.LicenseNumber;
                tbCertificateURL.Text = certificate.CertificationUrl;

                if (certificate.StartMonth.HasValue)
                {
                    ddlCertificateStartMonth.SelectedValue = certificate.StartMonth.Value.ToString();
                }
                if (certificate.StartYear.HasValue)
                {
                    ddlCertificateStartYear.SelectedValue = certificate.StartYear.Value.ToString();
                }
                if (certificate.EndMonth.HasValue)
                {
                    ddlCertificateEndMonth.SelectedValue = certificate.EndMonth.Value.ToString();
                }
                if (certificate.EndYear.HasValue)
                {
                    ddlCertificateEndYear.SelectedValue = certificate.EndYear.Value.ToString();
                }

                if (certificate.DoesnotExpire.HasValue && certificate.DoesnotExpire.Value)
                {
                    cbCertificateDoesNotExpire.Checked = true;
                    ddlCertificateStartMonth.Enabled = false;
                    ddlCertificateStartYear.Enabled = false;
                    ddlCertificateEndMonth.Enabled = false;
                    ddlCertificateEndYear.Enabled = false;
                }

                lbCertificateSave.CommandName = "CertificateSave";
                lbCertificateSave.CommandArgument = certificate.MemberCertificateMembershipId.ToString();
            }

        }

        private void CertificateResetJS()
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CertificateReset", @"
	        /* certificate validity date - checkbox action */
	        $("".certificate_checkbox .btn-checkbox"").change(function(){
		        if($(this).is("":checked"")){
				        $("".certificate_validity_wrap select"").prop('disabled', 'disabled');
			        }
			        else
			        {
				        $("".certificate_validity_wrap select"").removeAttr(""disabled"");
			        }
	        });
        ", true);
        }

        protected void lbCertificateAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptCertification.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acCertificate = item.FindControl("acCertificate") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acCertificate.Attributes.Add("class", "section-content");
            }


            bool hasError = false;
            string controltofocus = string.Empty;

            phCertificateAddNameError.Visible = false;
            phCertificateAddAuthorityError.Visible = false;
            phCertificateAddError.Visible = false;
            phCertificateAddMembershipNumberError.Visible = false;
            phCertificateAddURLError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbCertificateAddCertificateMembershipName.Text))
            {
                hasError = true;
                phCertificateAddNameError.Visible = true;
                ltErrorAddCertificateName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbCertificateAddCertificateMembershipName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbCertificateAddCertificateMembershipName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phCertificateAddNameError.Visible = true;
                    ltErrorAddCertificateName.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateAddCertificateMembershipName.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbCertificateAddAuthority.Text))
            {
                hasError = true;
                phCertificateAddAuthorityError.Visible = true;
                ltErrorAddCertificateAuthority.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbCertificateAddAuthority.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbCertificateAddAuthority.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phCertificateAddAuthorityError.Visible = true;
                    ltErrorAddCertificateAuthority.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateAddAuthority.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbCertificateAddMembershipNumber.Text))
            {
                if (Regex.IsMatch(tbCertificateAddMembershipNumber.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phCertificateAddMembershipNumberError.Visible = true;
                    ltErrorAddCertificateMembershipNumber.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateAddMembershipNumber.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbCertificateAddURL.Text))
            {
                if (Regex.IsMatch(tbCertificateAddURL.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phCertificateAddURLError.Visible = true;
                    ltErrorAddCertificateURL.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbCertificateAddURL.ClientID;
                    }
                }
            }

            bool hasAddDate = false;
            DateTime? thisIssueDateTime = null;
            if (ddlCertificateAddStartYear.SelectedValue != "0" && ddlCertificateAddStartMonth.SelectedValue != "0")
            {
                hasAddDate = true;
                DateTime thisDateTime1;
                try
                {
                    thisIssueDateTime = new DateTime(Convert.ToInt32(ddlCertificateAddStartYear.SelectedValue), Convert.ToInt32(ddlCertificateAddStartMonth.SelectedValue), 1);
                    if (DateTime.Now < thisIssueDateTime)
                    {
                        hasError = true;
                        phCertificateAddError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlCertificateAddStartMonth.ClientID;
                        }
                    }
                }
                catch
                {
                    hasError = true;
                    phCertificateAddError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlCertificateAddStartMonth.ClientID;
                    }
                }
            }

            bool hasExpiryDate = false;
            if (ddlCertificateAddEndYear.SelectedValue != "0" && ddlCertificateAddEndMonth.SelectedValue != "0")
            {
                hasExpiryDate = true;
                DateTime thisExpiryTime;
                try
                {
                    thisExpiryTime = new DateTime(Convert.ToInt32(ddlCertificateAddEndYear.SelectedValue), Convert.ToInt32(ddlCertificateAddEndMonth.SelectedValue), 1);

                    if (thisIssueDateTime != null)
                    {
                        if (thisIssueDateTime > thisExpiryTime)
                        {
                            hasError = true;
                            phCertificateAddError.Visible = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlCertificateAddEndMonth.ClientID;
                            }
                        }
                    }

                }
                catch
                {
                    hasError = true;
                    phCertificateAddError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlCertificateAddEndMonth.ClientID;
                    }
                }
            }

            // Date Error Checking
            if (!cbCertificateAddDoesNotExpire.Checked)
            {
                if (!hasError && hasExpiryDate && hasAddDate)
                {
                    if ((Convert.ToInt32(ddlCertificateAddStartYear.SelectedValue) > Convert.ToInt32(ddlCertificateAddEndYear.SelectedValue))
                        || ((Convert.ToInt32(ddlCertificateAddEndYear.SelectedValue) == Convert.ToInt32(ddlCertificateAddStartYear.SelectedValue) && (Convert.ToInt32(ddlCertificateAddEndMonth.SelectedValue) < Convert.ToInt32(ddlCertificateAddStartMonth.SelectedValue)))))
                    {
                        phCertificateAddError.Visible = true;
                        hasError = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlCertificateAddStartMonth.ClientID;
                        }
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                OpenAddDiv(hfCertificateAdd.ClientID, controltofocus);

                acCertificateAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newCnM.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            MemberCertificateMemberships certificate = new MemberCertificateMemberships();

            certificate.MemberCertificateMembershipName = tbCertificateAddCertificateMembershipName.Text;
            certificate.CertificationAuthority = tbCertificateAddAuthority.Text;
            certificate.LicenseNumber = tbCertificateAddMembershipNumber.Text;
            certificate.CertificationUrl = tbCertificateAddURL.Text;

            if (hasAddDate)
            {
                certificate.StartMonth = Convert.ToInt32(ddlCertificateAddStartMonth.SelectedValue);
                certificate.StartYear = Convert.ToInt32(ddlCertificateAddStartYear.SelectedValue);
            }
            else
            {
                certificate.StartMonth = null;
                certificate.StartYear = null;
            }
            if (hasExpiryDate)
            {
                certificate.EndMonth = Convert.ToInt32(ddlCertificateAddEndMonth.SelectedValue);
                certificate.EndYear = Convert.ToInt32(ddlCertificateAddEndYear.SelectedValue);
            }
            else
            {
                certificate.EndMonth = null;
                certificate.EndYear = null;
            }

            if (cbCertificateAddDoesNotExpire.Checked)
            {
                certificate.DoesnotExpire = true;
                certificate.StartMonth = null;
                certificate.StartYear = null;
                certificate.EndMonth = null;
                certificate.EndYear = null;
            }
            certificate.MemberId = SessionData.Member.MemberId;
            MemberCertificateMembershipsService.Insert(certificate);
            UpdateMemberLastModified();
            LoadCountry();
            LoadCalendar();

            SetCertifications();
            /*using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptCertification.DataSource = membercertificates;
                rptCertification.DataBind();

                phNavCertification.Visible = (membercertificates.Count == 0);
                phAddEntryTextCertificates.Visible = (membercertificates.Count == 0);
                phTickCertificate.Visible = (membercertificates.Count > 0);

            }*/

            // clear the fields
            tbCertificateAddCertificateMembershipName.Text = string.Empty;
            tbCertificateAddAuthority.Text = string.Empty;
            tbCertificateAddMembershipNumber.Text = string.Empty;
            tbCertificateAddURL.Text = string.Empty;
            cbCertificateAddDoesNotExpire.Checked = false;
            ddlCertificateAddStartMonth.SelectedIndex = 0;
            ddlCertificateAddStartYear.SelectedIndex = 0;
            ddlCertificateAddEndMonth.SelectedIndex = 0;
            ddlCertificateAddEndYear.SelectedIndex = 0;
            ddlCertificateAddStartMonth.Enabled = true;
            ddlCertificateAddStartYear.Enabled = true;
            ddlCertificateAddEndMonth.Enabled = true;
            ddlCertificateAddEndYear.Enabled = true;


            StandardResetJS();

            CertificateResetJS();

            acCertificateAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newCnM.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Licenses

        private int SetLicenses()
        {
            using (TList<Entities.MemberLicenses> memberlicenses = MemberLicensesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptLicenses.DataSource = memberlicenses.OrderByDescending(s => s.IssueDate);
                rptLicenses.DataBind();

                phNavLicenses.Visible = (memberlicenses.Count == 0);
                phAddEntryTextLicenses.Visible = (memberlicenses.Count == 0);
                phTickLicense.Visible = (memberlicenses.Count > 0);
            }

            return 0;
        }

        private void DeleteLicenses(int licenseid)
        {
            using (MemberLicenses memberlicense = MemberLicensesService.GetByMemberLicenseId(licenseid))
            {
                if (memberlicense != null && memberlicense.MemberId == SessionData.Member.MemberId)
                {
                    MemberLicensesService.Delete(memberlicense);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptLicenses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acLicenseAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newLicense.Attributes.Add("class", "profile-edit collapse");

            Literal ltLicenseName = e.Item.FindControl("ltLicenseName") as Literal;
            Literal ltLicenseType = e.Item.FindControl("ltLicenseType") as Literal;
            Literal ltLicenseDate = e.Item.FindControl("ltLicenseDate") as Literal;
            Literal ltLicenseStateCountry = e.Item.FindControl("ltLicenseStateCountry") as Literal;

            PlaceHolder phLicenseAddress = e.Item.FindControl("phLicenseAddress") as PlaceHolder;
            TextBox tbLicenseName = e.Item.FindControl("tbLicenseName") as TextBox;
            PlaceHolder phLicenseNameError = e.Item.FindControl("phLicenseNameError") as PlaceHolder;
            ucLanguageLiteral ltErrorLicenseName = e.Item.FindControl("ltErrorLicenseName") as ucLanguageLiteral;
            PlaceHolder phLicenseStateError = e.Item.FindControl("phLicenseStateError") as PlaceHolder;
            ucLanguageLiteral ltErrorLicenseState = e.Item.FindControl("ltErrorLicenseState") as ucLanguageLiteral;

            TextBox tbLicenseType = e.Item.FindControl("tbLicenseType") as TextBox;
            ucLanguageLiteral ltErrorLicenseType = e.Item.FindControl("ltErrorLicenseType") as ucLanguageLiteral;
            PlaceHolder phLicenseTypeError = e.Item.FindControl("phLicenseTypeError") as PlaceHolder;
            DropDownList ddlLicenseCountry = e.Item.FindControl("ddlLicenseCountry") as DropDownList;
            TextBox tbLicenseState = e.Item.FindControl("tbLicenseState") as TextBox;
            DropDownList ddlLicenseIssueMonth = e.Item.FindControl("ddlLicenseIssueMonth") as DropDownList;
            DropDownList ddlLicenseIssueYear = e.Item.FindControl("ddlLicenseIssueYear") as DropDownList;
            DropDownList ddlLicenseExpiryMonth = e.Item.FindControl("ddlLicenseExpiryMonth") as DropDownList;
            DropDownList ddlLicenseExpiryYear = e.Item.FindControl("ddlLicenseExpiryYear") as DropDownList;
            PlaceHolder phLicenseError = e.Item.FindControl("phLicenseError") as PlaceHolder;
            LinkButton lbLicenseSave = e.Item.FindControl("lbLicenseSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlAnchor aLicenseEdit = e.Item.FindControl("aLicenseEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            aLicenseEdit.Attributes.Add("href", "#edit-License" + (e.Item.ItemIndex + 1).ToString());
            System.Web.UI.HtmlControls.HtmlGenericControl acLicense = e.Item.FindControl("acLicense") as System.Web.UI.HtmlControls.HtmlGenericControl;

            if (e.CommandName == "LicenseSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;

                phLicenseNameError.Visible = false;
                phLicenseTypeError.Visible = false;
                phLicenseStateError.Visible = false;
                phLicenseError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbLicenseName.Text))
                {
                    hasError = true;
                    phLicenseNameError.Visible = true;
                    ltErrorLicenseName.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLicenseName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbLicenseName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phLicenseNameError.Visible = true;
                        ltErrorLicenseName.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbLicenseName.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbLicenseType.Text))
                {
                    hasError = true;
                    phLicenseTypeError.Visible = true;
                    ltErrorLicenseType.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLicenseType.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbLicenseType.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phLicenseTypeError.Visible = true;
                        ltErrorLicenseType.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbLicenseType.ClientID;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(tbLicenseState.Text))
                {
                    if (Regex.IsMatch(tbLicenseState.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phLicenseStateError.Visible = true;
                        ltErrorLicenseState.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbLicenseState.ClientID;
                        }
                    }
                }

                bool hasAddDate = false;
                DateTime? thisIssueDateTime = null;
                if (ddlLicenseIssueYear.SelectedValue != "0" && ddlLicenseIssueMonth.SelectedValue != "0")
                {
                    hasAddDate = true;
                    try
                    {
                        thisIssueDateTime = new DateTime(Convert.ToInt32(ddlLicenseIssueYear.SelectedValue), Convert.ToInt32(ddlLicenseIssueMonth.SelectedValue), 1);
                        if (DateTime.Now < thisIssueDateTime)
                        {
                            hasError = true;
                            phLicenseError.Visible = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlLicenseIssueMonth.ClientID;
                            }
                        }
                    }
                    catch
                    {
                        hasError = true;
                        phLicenseError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlLicenseIssueMonth.ClientID;
                        }
                    }
                }

                bool hasExpiryDate = false;
                if (ddlLicenseExpiryYear.SelectedValue != "0" && ddlLicenseExpiryMonth.SelectedValue != "0")
                {
                    hasExpiryDate = true;
                    DateTime thisExpiryTime;
                    try
                    {
                        thisExpiryTime = new DateTime(Convert.ToInt32(ddlLicenseExpiryYear.SelectedValue), Convert.ToInt32(ddlLicenseExpiryMonth.SelectedValue), 1);

                        if (thisIssueDateTime != null)
                        {
                            if (thisIssueDateTime > thisExpiryTime)
                            {
                                hasError = true;
                                phLicenseError.Visible = true;

                                if (string.IsNullOrWhiteSpace(controltofocus))
                                {
                                    controltofocus = ddlLicenseExpiryMonth.ClientID;
                                }
                            }
                        }
                    }
                    catch
                    {
                        hasError = true;
                        phLicenseError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlLicenseIssueMonth.ClientID;
                        }
                    }
                }

                // Date Error Checking only if none of the above failed
                if (!hasError && hasExpiryDate && hasAddDate)
                {
                    if (!string.IsNullOrEmpty(ddlLicenseIssueYear.SelectedValue) || !string.IsNullOrEmpty(ddlLicenseIssueMonth.SelectedValue)
                        || !string.IsNullOrEmpty(ddlLicenseExpiryYear.SelectedValue) || !string.IsNullOrEmpty(ddlLicenseExpiryMonth.SelectedValue))
                    {
                        if ((Convert.ToInt32(ddlLicenseIssueYear.SelectedValue) > Convert.ToInt32(ddlLicenseExpiryYear.SelectedValue))
                            || ((Convert.ToInt32(ddlLicenseExpiryYear.SelectedValue) == Convert.ToInt32(ddlLicenseIssueYear.SelectedValue) && (Convert.ToInt32(ddlLicenseExpiryMonth.SelectedValue) < Convert.ToInt32(ddlLicenseIssueMonth.SelectedValue)))))
                        {
                            phLicenseError.Visible = true;
                            hasError = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlLicenseIssueMonth.ClientID;
                            }
                        }
                    }
                }

                if (hasError)
                {
                    LicenseTypesAutoCompleteJS(false);

                    StandardResetJS();
                    OpenRepeaterDiv(aLicenseEdit.ClientID, controltofocus);

                    acLicenseAdd.Attributes.Add("class", "section-content edit-mode");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "LicenseError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-License" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);

                    return;
                }

                using (MemberLicenses license = MemberLicensesService.GetByMemberLicenseId(Convert.ToInt32(e.CommandArgument)))
                {
                    if (license != null)
                    {
                        license.MemberLicenseName = tbLicenseName.Text;
                        license.LicenseType = tbLicenseType.Text;
                        license.CountryId = Convert.ToInt32(ddlLicenseCountry.SelectedValue);
                        license.State = tbLicenseState.Text;

                        if (hasAddDate)
                            license.IssueDate = new DateTime(Convert.ToInt32(ddlLicenseIssueYear.SelectedValue), Convert.ToInt32(ddlLicenseIssueMonth.SelectedValue), 1);
                        else
                            license.IssueDate = null;
                        if (hasExpiryDate)
                            license.ExpiryDate = new DateTime(Convert.ToInt32(ddlLicenseExpiryYear.SelectedValue), Convert.ToInt32(ddlLicenseExpiryMonth.SelectedValue), 1);
                        else
                            license.ExpiryDate = null;

                        MemberLicensesService.Update(license);
                        UpdateMemberLastModified();
                        string licensedate = string.Empty;
                        string startmonth = string.Empty;
                        string endmonth = string.Empty;

                        ltLicenseName.Text = HttpUtility.HtmlEncode(license.MemberLicenseName);
                        ltLicenseType.Text = HttpUtility.HtmlEncode(license.LicenseType);

                        #region State and Country Display
                        LoadCountry();
                        bool hasStateAndCountryDisplay = false;
                        List<string> licenseStateAndCountry = new List<string>();

                        if (!string.IsNullOrWhiteSpace(license.State))
                        {
                            licenseStateAndCountry.Add(HttpUtility.HtmlEncode(license.State));
                            hasStateAndCountryDisplay = true;
                        }

                        if (license.CountryId.HasValue && license.CountryId != 0)
                        {
                            Countries thisCountry = CountryList.Where(c => c.CountryId == license.CountryId.Value).FirstOrDefault();
                            string countryName = thisCountry == null ? string.Empty : thisCountry.CountryName;

                            licenseStateAndCountry.Add(HttpUtility.HtmlEncode(countryName));
                            hasStateAndCountryDisplay = true;
                        }

                        ltLicenseStateCountry.Text = String.Join(", ", licenseStateAndCountry);

                        phLicenseAddress.Visible = hasStateAndCountryDisplay;

                        #endregion


                        if (license.IssueDate.HasValue)
                        {
                            foreach (ListItem month in ddlLicenseIssueMonth.Items)
                            {
                                if (month.Value == license.IssueDate.Value.Month.ToString())
                                {
                                    startmonth = CommonFunction.GetResourceValue(month.Text);
                                    break;
                                }
                            }

                            licensedate = startmonth + " " + license.IssueDate.Value.Year.ToString();
                        }

                        if (license.ExpiryDate.HasValue)
                        {
                            foreach (ListItem month in ddlLicenseExpiryMonth.Items)
                            {
                                if (month.Value == license.ExpiryDate.Value.Month.ToString())
                                {
                                    endmonth = CommonFunction.GetResourceValue(month.Text);
                                    break;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(licensedate))
                            {
                                licensedate += " - ";
                            }

                            licensedate += endmonth + " " + license.ExpiryDate.Value.Year.ToString();
                        }

                        ltLicenseDate.Text = licensedate;

                    }
                }
            }

            if (e.CommandName == "LicenseDelete")
            {
                DeleteLicenses(Convert.ToInt32(e.CommandArgument));


                /*using (TList<Entities.MemberLicenses> licenses = MemberLicensesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    rptLicenses.DataSource = licenses;
                    rptLicenses.DataBind();

                    phNavLicenses.Visible = (licenses.Count == 0);
                    phAddEntryTextLicenses.Visible = (licenses.Count == 0);
                    phTickLicense.Visible = (licenses.Count > 0);
                }*/
            }

            // Set Licences

            LoadCountry();
            LoadCalendar();

            SetLicenses();

            LicenseTypesAutoCompleteJS(false);
            StandardResetJS();

            acLicense.Attributes.Add("class", "section-content");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "LicenseError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-License" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);
            SetMemberPoints();
        }

        protected void rptLicenses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLicenseName = e.Item.FindControl("ltLicenseName") as Literal;
                Literal ltLicenseType = e.Item.FindControl("ltLicenseType") as Literal;
                Literal ltLicenseDate = e.Item.FindControl("ltLicenseDate") as Literal;
                Literal ltLicenseStateCountry = e.Item.FindControl("ltLicenseStateCountry") as Literal;

                PlaceHolder phLicenseAddress = e.Item.FindControl("phLicenseAddress") as PlaceHolder;

                TextBox tbLicenseName = e.Item.FindControl("tbLicenseName") as TextBox;
                TextBox tbLicenseType = e.Item.FindControl("tbLicenseType") as TextBox;
                DropDownList ddlLicenseCountry = e.Item.FindControl("ddlLicenseCountry") as DropDownList;
                TextBox tbLicenseState = e.Item.FindControl("tbLicenseState") as TextBox;
                DropDownList ddlLicenseIssueMonth = e.Item.FindControl("ddlLicenseIssueMonth") as DropDownList;
                DropDownList ddlLicenseIssueYear = e.Item.FindControl("ddlLicenseIssueYear") as DropDownList;
                DropDownList ddlLicenseExpiryMonth = e.Item.FindControl("ddlLicenseExpiryMonth") as DropDownList;
                DropDownList ddlLicenseExpiryYear = e.Item.FindControl("ddlLicenseExpiryYear") as DropDownList;
                LinkButton lbLicenseSave = e.Item.FindControl("lbLicenseSave") as LinkButton;
                LinkButton lbLicenseDelete = e.Item.FindControl("lbLicenseDelete") as LinkButton;
                System.Web.UI.HtmlControls.HtmlAnchor aLicenseEdit = e.Item.FindControl("aLicenseEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aLicenseEdit.Attributes.Add("href", "#edit-License" + (e.Item.ItemIndex + 1).ToString());
                //placeholders
                tbLicenseName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelLicenseName"));
                tbLicenseType.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelLicenseType"));
                tbLicenseState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityState"));
                MemberLicenses license = e.Item.DataItem as MemberLicenses;
                lbLicenseDelete.CommandArgument = license.MemberLicenseId.ToString();
                lbLicenseDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbLicenseDelete.ClientID + "').prop('href'))});";
                ddlLicenseIssueMonth.Items.Clear();
                ddlLicenseIssueMonth.DataValueField = "value";
                ddlLicenseIssueMonth.DataTextField = "text";
                ddlLicenseIssueMonth.DataSource = MonthList;
                ddlLicenseIssueMonth.DataBind();
                ddlLicenseIssueMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlLicenseIssueYear.Items.Clear();
                ddlLicenseIssueYear.DataValueField = "value";
                ddlLicenseIssueYear.DataTextField = "text";
                ddlLicenseIssueYear.DataSource = YearList;
                ddlLicenseIssueYear.DataBind();
                ddlLicenseIssueYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlLicenseExpiryMonth.Items.Clear();
                ddlLicenseExpiryMonth.DataValueField = "value";
                ddlLicenseExpiryMonth.DataTextField = "text";
                ddlLicenseExpiryMonth.DataSource = MonthList;
                ddlLicenseExpiryMonth.DataBind();
                ddlLicenseExpiryMonth.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayMM"), "0"));

                ddlLicenseExpiryYear.Items.Clear();
                ddlLicenseExpiryYear.DataValueField = "value";
                ddlLicenseExpiryYear.DataTextField = "text";
                ddlLicenseExpiryYear.DataSource = FutureYearList;
                ddlLicenseExpiryYear.DataBind();
                ddlLicenseExpiryYear.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelDateDisplayYYYY"), "0"));

                ddlLicenseCountry.Items.Clear();
                ddlLicenseCountry.DataValueField = "CountryID";
                ddlLicenseCountry.DataTextField = "CountryName";
                ddlLicenseCountry.DataSource = CountryList;
                ddlLicenseCountry.DataBind();
                ddlLicenseCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), "0"));

                string licensedate = string.Empty;
                string startmonth = string.Empty;
                string endmonth = string.Empty;

                ltLicenseName.Text = HttpUtility.HtmlEncode(license.MemberLicenseName);
                ltLicenseType.Text = HttpUtility.HtmlEncode(license.LicenseType);

                #region State and Country Display
                bool hasStateAndCountryDisplay = false;
                List<string> licenseStateAndCountry = new List<string>();

                if (!string.IsNullOrWhiteSpace(license.State))
                {
                    licenseStateAndCountry.Add(HttpUtility.HtmlEncode(license.State));
                    hasStateAndCountryDisplay = true;
                }

                if (license.CountryId.HasValue && license.CountryId != 0)
                {
                    Countries thisCountry = CountryList.Where(c => c.CountryId == license.CountryId.Value).FirstOrDefault();
                    string countryName = thisCountry == null ? string.Empty : thisCountry.CountryName;

                    licenseStateAndCountry.Add(HttpUtility.HtmlEncode(countryName));
                    hasStateAndCountryDisplay = true;
                }

                ltLicenseStateCountry.Text = String.Join(", ", licenseStateAndCountry);

                phLicenseAddress.Visible = hasStateAndCountryDisplay;

                #endregion

                if (license.IssueDate.HasValue)
                {
                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == license.IssueDate.Value.Month.ToString())
                        {
                            startmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }

                    licensedate = startmonth + " " + license.IssueDate.Value.Year.ToString();
                }

                if (license.ExpiryDate.HasValue)
                {
                    foreach (ListItem month in MonthList)
                    {
                        if (month.Value == license.ExpiryDate.Value.Month.ToString())
                        {
                            endmonth = CommonFunction.GetResourceValue(month.Text);
                            break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(licensedate))
                    {
                        licensedate += " - ";
                    }

                    licensedate += endmonth + " " + license.ExpiryDate.Value.Year.ToString();
                }

                ltLicenseDate.Text = licensedate;

                tbLicenseName.Text = license.MemberLicenseName;
                tbLicenseType.Text = license.LicenseType;
                ddlLicenseCountry.SelectedValue = license.CountryId.ToString();
                tbLicenseState.Text = license.State;
                if (license.IssueDate.HasValue)
                {
                    ddlLicenseIssueMonth.SelectedValue = license.IssueDate.Value.Month.ToString();
                    ddlLicenseIssueYear.SelectedValue = license.IssueDate.Value.Year.ToString();
                }

                if (license.ExpiryDate.HasValue)
                {
                    ddlLicenseExpiryMonth.SelectedValue = license.ExpiryDate.Value.Month.ToString();
                    ddlLicenseExpiryYear.SelectedValue = license.ExpiryDate.Value.Year.ToString();
                }

                lbLicenseSave.CommandName = "LicenseSave";
                lbLicenseSave.CommandArgument = license.MemberLicenseId.ToString();
            }
        }

        protected void lbLicenseAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptLicenses.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acLicense = item.FindControl("acLicense") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acLicense.Attributes.Add("class", "section-content");
            }

            bool hasError = false;
            string controltofocus = string.Empty;

            phLicenseAddNameError.Visible = false;
            phLicenseAddTypeError.Visible = false;
            phLicenseAddStateError.Visible = false;
            phLicenseAddError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbLicenseAddName.Text))
            {
                hasError = true;
                phLicenseAddNameError.Visible = true;
                ltErrorAddLicenseName.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbLicenseAddName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbLicenseAddName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phLicenseAddNameError.Visible = true;
                    ltErrorAddLicenseName.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLicenseAddName.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbLicenseAddType.Text))
            {
                hasError = true;
                phLicenseAddTypeError.Visible = true;
                ltErrorAddLicenseType.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbLicenseAddType.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbLicenseAddType.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phLicenseAddTypeError.Visible = true;
                    ltErrorAddLicenseType.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLicenseAddType.ClientID;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(tbLicenseAddState.Text))
            {
                if (Regex.IsMatch(tbLicenseAddState.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phLicenseAddStateError.Visible = true;
                    ltErrorAddLicenseState.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLicenseAddState.ClientID;
                    }
                }
            }

            bool hasAddDate = false;
            DateTime? thisIssueDateTime = null;
            if (ddlLicenseAddIssueYear.SelectedValue != "0" && ddlLicenseAddIssueMonth.SelectedValue != "0")
            {
                hasAddDate = true;
                DateTime thisDateTime1;
                try
                {
                    thisIssueDateTime = new DateTime(Convert.ToInt32(ddlLicenseAddIssueYear.SelectedValue), Convert.ToInt32(ddlLicenseAddIssueMonth.SelectedValue), 1);
                    if (DateTime.Now < thisIssueDateTime)
                    {
                        hasError = true;
                        phLicenseAddError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = ddlLicenseAddIssueMonth.ClientID;
                        }
                    }
                }
                catch
                {
                    hasError = true;
                    phLicenseAddError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlLicenseAddIssueMonth.ClientID;
                    }
                }
            }

            bool hasExpiryDate = false;
            if (ddlLicenseAddExpiryYear.SelectedValue != "0" && ddlLicenseAddExpiryMonth.SelectedValue != "0")
            {
                hasExpiryDate = true;
                DateTime thisExpiryTime;
                try
                {
                    thisExpiryTime = new DateTime(Convert.ToInt32(ddlLicenseAddExpiryYear.SelectedValue), Convert.ToInt32(ddlLicenseAddExpiryMonth.SelectedValue), 1);

                    if (thisIssueDateTime != null)
                    {
                        if (thisIssueDateTime > thisExpiryTime)
                        {
                            hasError = true;
                            phLicenseAddError.Visible = true;

                            if (string.IsNullOrWhiteSpace(controltofocus))
                            {
                                controltofocus = ddlLicenseAddExpiryMonth.ClientID;
                            }
                        }
                    }

                }
                catch
                {
                    hasError = true;
                    phLicenseAddError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlLicenseAddIssueMonth.ClientID;
                    }
                }
            }

            // Date Error Checking only if none of the above failed
            if (!hasError && hasExpiryDate && hasAddDate)
            {
                if ((Convert.ToInt32(ddlLicenseAddIssueYear.SelectedValue) > Convert.ToInt32(ddlLicenseAddExpiryYear.SelectedValue))
                    || ((Convert.ToInt32(ddlLicenseAddExpiryYear.SelectedValue) == Convert.ToInt32(ddlLicenseAddIssueYear.SelectedValue) && (Convert.ToInt32(ddlLicenseAddExpiryMonth.SelectedValue) < Convert.ToInt32(ddlLicenseAddIssueMonth.SelectedValue)))))
                {
                    phLicenseAddError.Visible = true;
                    hasError = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = ddlLicenseAddIssueMonth.ClientID;
                    }
                }
            }

            if (hasError)
            {
                LicenseTypesAutoCompleteJS(false);
                StandardResetJS();

                OpenAddDiv(string.Empty, controltofocus);
                acLicenseAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newLicense.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            MemberLicenses license = new MemberLicenses();

            license.MemberLicenseName = tbLicenseAddName.Text;
            license.LicenseType = tbLicenseAddType.Text;
            license.CountryId = Convert.ToInt32(ddlLicenseAddCountry.SelectedValue);
            license.State = tbLicenseAddState.Text;
            if (hasAddDate)
                license.IssueDate = new DateTime(Convert.ToInt32(ddlLicenseAddIssueYear.SelectedValue), Convert.ToInt32(ddlLicenseAddIssueMonth.SelectedValue), 1);
            else
                license.IssueDate = null;
            if (hasExpiryDate)
                license.ExpiryDate = new DateTime(Convert.ToInt32(ddlLicenseAddExpiryYear.SelectedValue), Convert.ToInt32(ddlLicenseAddExpiryMonth.SelectedValue), 1);
            else
                license.ExpiryDate = null;
            license.MemberId = SessionData.Member.MemberId;

            MemberLicensesService.Insert(license);
            UpdateMemberLastModified();
            LoadCountry();
            LoadCalendar();

            SetLicenses();
            /*using (TList<Entities.MemberLicenses> licenses = MemberLicensesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptLicenses.DataSource = licenses;
                rptLicenses.DataBind();

                phNavLicenses.Visible = (licenses.Count == 0);
                phAddEntryTextLicenses.Visible = (licenses.Count == 0);
                phTickLicense.Visible = (licenses.Count > 0);
            }*/

            tbLicenseAddName.Text = string.Empty;
            tbLicenseAddType.Text = string.Empty;
            ddlLicenseAddCountry.SelectedIndex = 0;
            tbLicenseAddState.Text = string.Empty;
            ddlLicenseAddIssueYear.SelectedValue = "2016";
            ddlLicenseAddIssueMonth.SelectedIndex = 0;
            ddlLicenseAddExpiryYear.SelectedValue = "2016";
            ddlLicenseAddExpiryMonth.SelectedIndex = 0;

            LicenseTypesAutoCompleteJS(false);
            StandardResetJS();

            acLicenseAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newLicense.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Role Preference

        private void LoadRolePreferenceArea(string selectedlocations = "")
        {
            ddlRolePreferenceDesiredRegion.Items.Clear();
            ddlRolePreferenceDesiredRegion.DataTextField = "AreaName";
            ddlRolePreferenceDesiredRegion.DataValueField = "AreaId";

            if (!string.IsNullOrWhiteSpace(selectedlocations))
            {
                foreach (string slocation in selectedlocations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    List<Entities.SiteArea> areas = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(slocation), SessionData.Language.LanguageId);

                    foreach (Entities.SiteArea area in areas)
                    {
                        ddlRolePreferenceDesiredRegion.Items.Add(new ListItem(area.SiteAreaName, area.AreaId.ToString()));
                    }


                }
            }

        }

        private void LoadProfession()
        {
            ProfessionList = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);

        }

        private void LoadRolePreferenceRoles(int professionid)
        {
            ddlRolePreferenceJobSubClassification.Items.Clear();
            ddlRolePreferenceJobSubClassification.DataTextField = "SiteRoleName";
            ddlRolePreferenceJobSubClassification.DataValueField = "RoleId";

            List<SiteRoles> siteroles = SiteRolesService.GetTranslatedByProfessionID(professionid, SessionData.Site.UseCustomProfessionRole);
            ddlRolePreferenceJobSubClassification.DataSource = siteroles;
            ddlRolePreferenceJobSubClassification.DataBind();

            //if (siteroles.Count > 0)
            //{
            //    ddlRolePreferenceJobSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseOne"), "0"));
            //    ddlRolePreferenceJobSubClassification.Items[0].Attributes.Add("disabled", "");
            //}
        }

        private void LoadWorkType()
        {
            WorkTypeList = SiteWorkTypeService.GetTranslatedWorkTypes();
        }

        private void LoadSalaryType()
        {
            SalaryTypeList = new List<Entities.SiteSalaryType>();

            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {
                if (sitesalarytype.SalaryTypeId != (int)PortalEnums.Search.SalaryType.NA)
                {
                    SalaryTypeList.Add(sitesalarytype);
                }
            }
        }

        private int SetRolePreferences(Entities.Members member, int point)
        {
            //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetMultiselect", @"
            //                        <script src='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>", false);

            ddlRolePreferenceWorkType.Attributes.Add("onchange", "$('#" + hfRolePreferenceWorkType.ClientID + "').val($('#" + ddlRolePreferenceWorkType.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(member.WorkTypeId) && member.WorkTypeId != "0")
            {
                hfRolePreferenceWorkType.Value = member.WorkTypeId;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetWorkType", @"
            $(document).ready(function() {
                
                $('#" + ddlRolePreferenceWorkType.ClientID + @"').multiselect(" + (!string.IsNullOrWhiteSpace(member.WorkTypeId) ? "'select', ['" + member.WorkTypeId.Replace(",", "','") + @"']" : string.Empty) + @")

            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetWorkType", @"
                    $(document).ready(function() {
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceWorkType.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    });
                    ", true);

            }

            if (member.PreferredSalaryId.HasValue)
            {
                ddlRolePreferenceSalaryRequirements.SelectedValue = member.PreferredSalaryId.Value.ToString();
            }
            tbRolePreferenceSalaryMin.Text = member.PreferredSalaryFrom;
            tbRolePreferenceSalaryMax.Text = member.PreferredSalaryTo;
            if (string.IsNullOrWhiteSpace(member.PreferredCategoryId) == false && member.PreferredCategoryId != "0")
            {
                ddlRolePreferenceJobClassification.SelectedValue = member.PreferredCategoryId;
                LoadRolePreferenceRoles(Convert.ToInt32(member.PreferredCategoryId));
            }

            ddlRolePreferenceJobSubClassification.Attributes.Add("onchange", "$('#" + hfRolePreferenceJobSubClassification.ClientID + "').val($('#" + ddlRolePreferenceJobSubClassification.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(member.PreferredSubCategoryId) && member.PreferredSubCategoryId != "0")
            {
                hfRolePreferenceJobSubClassification.Value = member.PreferredSubCategoryId;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetRole", @"
            $(document).ready(function() {
                 $('#" + ddlRolePreferenceJobSubClassification.ClientID + @"').multiselect('select', ['" + member.PreferredSubCategoryId.Replace(",", "','") + @"']);
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetRole", @"
                    $(document).ready(function() {
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceJobSubClassification.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    });
                    ", true);

            }

            ddlRolePreferenceDesiredLocation.SelectedValue = member.LocationId;
            LoadRolePreferenceArea(member.LocationId);

            ddlRolePreferenceDesiredRegion.Attributes.Add("onchange", "$('#" + hfRolePreferenceDesiredRegion.ClientID + "').val($('#" + ddlRolePreferenceDesiredRegion.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(member.AreaId) && member.AreaId != "0")
            {
                hfRolePreferenceDesiredRegion.Value = member.AreaId;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetArea", @"
            $(document).ready(function() {
                $('#" + ddlRolePreferenceDesiredRegion.ClientID + @"').multiselect('select', ['" + member.AreaId.Replace(",", "','") + @"']);
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetArea", @"
                    $(document).ready(function() {
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceDesiredRegion.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    });
                    ", true);

            }

            ddlRolePreferenceEligibleToWorkIn.Attributes.Add("onchange", "$('#" + hfRolePreferenceEligibleWorkIn.ClientID + "').val($('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(member.EligibleToWorkIn))
            {
                hfRolePreferenceEligibleWorkIn.Value = member.EligibleToWorkIn;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEligible", @"
            $(document).ready(function() {
                $('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect('select', ['" + member.EligibleToWorkIn.Replace(",", "','") + @"']);
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEligible", @"
                    $(document).ready(function() {
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    });
                    ", true);

            }

            string strSalary = string.Empty;
            string strLocation = string.Empty;
            string strProfession = string.Empty;
            string strRole = string.Empty;
            string strWorkType = string.Empty;
            string strEligibleToWorkIn = string.Empty;
            string strCurrency = GetCurrency(member.LocationId);

            ltRolePreferencesSalary.Text = string.Empty;

            //Salary From display
            if (!string.IsNullOrWhiteSpace(member.PreferredSalaryFrom))
            {
                strSalary = strCurrency + member.PreferredSalaryFrom;
            }

            //Salary To display
            if (!string.IsNullOrWhiteSpace(member.PreferredSalaryTo))
            {
                if (!string.IsNullOrWhiteSpace(strSalary))
                {
                    strSalary += " - ";
                }

                strSalary += strCurrency + member.PreferredSalaryTo;
            }

            if (ddlRolePreferenceSalaryRequirements.SelectedValue != "")
            {
                strSalary = ddlRolePreferenceSalaryRequirements.SelectedItem.Text + " " + strSalary;
            }


            if (ddlRolePreferenceDesiredLocation.SelectedValue != "0")
            {
                strLocation = ddlRolePreferenceDesiredLocation.SelectedItem.Text;

                if (!string.IsNullOrWhiteSpace(hfRolePreferenceDesiredRegion.Value))
                {
                    strLocation += " -";
                    foreach (string split in hfRolePreferenceDesiredRegion.Value.Split(new char[] { ',' }))
                    {
                        foreach (ListItem area in ddlRolePreferenceDesiredRegion.Items)
                        {
                            if (area.Value == split)
                            {
                                strLocation += " " + area.Text + ",";
                                break;
                            }
                        }
                    }

                }
            }

            if (ddlRolePreferenceJobClassification.SelectedValue != "0")
            {
                strProfession = ddlRolePreferenceJobClassification.SelectedItem.Text;

                if (!string.IsNullOrWhiteSpace(hfRolePreferenceJobSubClassification.Value))
                {
                    foreach (string split in hfRolePreferenceJobSubClassification.Value.Split(new char[] { ',' }))
                    {
                        foreach (ListItem role in ddlRolePreferenceJobSubClassification.Items)
                        {
                            if (role.Value == split)
                            {
                                strRole += role.Text + ", ";
                                break;
                            }
                        }
                    }
                }
            }


            foreach (string split in hfRolePreferenceEligibleWorkIn.Value.Split(new char[] { ',' }))
            {
                foreach (ListItem country in ddlRolePreferenceEligibleToWorkIn.Items)
                {
                    if (country.Value == split)
                    {
                        strEligibleToWorkIn += country.Text + ", ";
                        break;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(member.WorkTypeId))
            {
                foreach (string split in member.WorkTypeId.Split(new char[] { ',' }))
                {
                    foreach (ListItem worktype in ddlRolePreferenceWorkType.Items)
                    {
                        if (worktype.Value == split)
                        {
                            strWorkType += worktype.Text + ", ";
                            break;
                        }
                    }
                }
            }

            ltRolePreferencesSalary.Text = HttpUtility.HtmlEncode(strSalary);

            if (!string.IsNullOrWhiteSpace(strLocation))
                ltRolePreferencesLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'></span>{0}</address>", HttpUtility.HtmlEncode(strLocation.TrimEnd(new char[] { ',', '-' })));
            else
                ltRolePreferencesLocation.Text = string.Empty;

            ltRolePreferencesProfession.Text = HttpUtility.HtmlEncode(strProfession);
            ltRolePreferencesRole.Text = HttpUtility.HtmlEncode(strRole.TrimEnd(new char[] { ',', ' ' }));

            if (!string.IsNullOrWhiteSpace(strWorkType))
                ltRolePreferencesWorktype.Text = string.Format("<p><strong>{0}:</strong><br />{1}</p>", CommonFunction.GetResourceValue("LabelWorkType"), HttpUtility.HtmlEncode(strWorkType.TrimEnd(new char[] { ',', ' ' })));
            else
                ltRolePreferencesWorktype.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(strEligibleToWorkIn))
                ltEligibleToWorkIn.Text = string.Format("<strong>{0}:</strong><br />{1}", CommonFunction.GetResourceValue("LabelEligibleToWorkIn"), HttpUtility.HtmlEncode(strEligibleToWorkIn.TrimEnd(new char[] { ',', ' ' })));
            else
                ltEligibleToWorkIn.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(ltRolePreferencesLocation.Text)
                && string.IsNullOrWhiteSpace(ltRolePreferencesProfession.Text)
                && string.IsNullOrWhiteSpace(ltRolePreferencesRole.Text)
                && string.IsNullOrWhiteSpace(ltRolePreferencesSalary.Text)
                )
            {
                phNavRolePreferences.Visible = true;
                phTickRolePreference.Visible = false;
            }
            else
            {
                phNavRolePreferences.Visible = false;
                phTickRolePreference.Visible = true;
            }

            //Add An Entry to not show when any one of the things are not empty
            if (!string.IsNullOrWhiteSpace(ltRolePreferencesLocation.Text)
                || !string.IsNullOrWhiteSpace(ltRolePreferencesProfession.Text)
                || !string.IsNullOrWhiteSpace(ltRolePreferencesRole.Text)
                || !string.IsNullOrWhiteSpace(ltRolePreferencesSalary.Text)
                || !string.IsNullOrWhiteSpace(strWorkType)
                || !string.IsNullOrWhiteSpace(strEligibleToWorkIn)
            )
            {
                phAddEntryTextRolePreferences.Visible = false;
            }
            else
                phAddEntryTextRolePreferences.Visible = true;

            return 0;
        }

        protected void ddlRolePreferenceJobClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfRolePreferenceJobSubClassification.Value = string.Empty;

            LoadRolePreferenceRoles(Convert.ToInt32(ddlRolePreferenceJobClassification.SelectedValue));

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiSelectReset", @"
            <script type='text/javascript'>
            $(document).ready(function() {

$('#" + ddlRolePreferenceJobSubClassification.ClientID + @"').multiselect({
            maxHeight: 200,
            numberDisplayed: 2,
            buttonClass: 'form-control'
            });

                //call custom function if any
                if (typeof CustomFunction == 'function') { 
                  CustomFunction('member/profile.aspx'); 
                }

            });
            </script>
            ", false);
        }

        protected void ddlRolePreferenceDesiredLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfRolePreferenceDesiredRegion.Value = string.Empty;

            LoadRolePreferenceArea(ddlRolePreferenceDesiredLocation.SelectedValue);


            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiSelectLocationReset", @"
            <script type='text/javascript'>
            $(document).ready(function() {

$('#" + ddlRolePreferenceDesiredRegion.ClientID + @"').multiselect({
            maxHeight: 200,
            numberDisplayed: 2,
            buttonClass: 'form-control'
            });

$('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect({
            maxHeight: 200,
            numberDisplayed: 2,
            buttonClass: 'form-control'
            });


$('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').val(['" + hfRolePreferenceEligibleWorkIn.Value.Replace(",", "','") + @"']);
$('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect('refresh');

                //call custom function if any
                if (typeof CustomFunction == 'function') { 
                  CustomFunction('member/profile.aspx'); 
                }

            });

            </script>
            ", false);
        }

        protected void lbRolePreferenceSave_Click(object sender, EventArgs e)
        {
            phRolePreferenceSalaryMinError.Visible = false;
            phRolePreferenceSalaryMaxError.Visible = false;
            phRolePreferenceSalaryRangeError.Visible = false;

            ddlRolePreferenceWorkType.Items[0].Attributes.Add("disabled", "disabled");

            bool hasError = false;
            string controltofocus = string.Empty;

            double min = 0;
            double max = 0;

            if (!string.IsNullOrEmpty(tbRolePreferenceSalaryMin.Text))
            {

                if (tbRolePreferenceSalaryMin.Text.Contains(',') || double.TryParse(tbRolePreferenceSalaryMin.Text, out min) == false)
                {
                    hasError = true;
                    phRolePreferenceSalaryMinError.Visible = true;

                    if (string.IsNullOrEmpty(controltofocus))
                    {
                        controltofocus = tbRolePreferenceSalaryMin.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbRolePreferenceSalaryMax.Text))
            {

                if (tbRolePreferenceSalaryMax.Text.Contains(',') || double.TryParse(tbRolePreferenceSalaryMax.Text, out max) == false)
                {
                    hasError = true;
                    phRolePreferenceSalaryMaxError.Visible = true;

                    if (string.IsNullOrEmpty(controltofocus))
                    {
                        controltofocus = tbRolePreferenceSalaryMax.ClientID;
                    }
                }
            }

            if (!string.IsNullOrEmpty(tbRolePreferenceSalaryMin.Text) && !string.IsNullOrEmpty(tbRolePreferenceSalaryMax.Text) && hasError == false)
            {
                if (max < min)
                {
                    hasError = true;
                    phRolePreferenceSalaryRangeError.Visible = true;

                    if (string.IsNullOrEmpty(controltofocus))
                    {
                        controltofocus = tbRolePreferenceSalaryMax.ClientID;
                    }
                }
            }

            StandardResetJS();

            //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetMultiselect", @"
            //                        <script src='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>", false);

            ddlRolePreferenceWorkType.Attributes.Add("onchange", "$('#" + hfRolePreferenceWorkType.ClientID + "').val($('#" + ddlRolePreferenceWorkType.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(hfRolePreferenceWorkType.Value))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetWorkType", @"
            $(document).ready(function() {
                
                $('#" + ddlRolePreferenceWorkType.ClientID + @"').multiselect(" + (!string.IsNullOrWhiteSpace(hfRolePreferenceWorkType.Value) ? "'select', ['" + hfRolePreferenceWorkType.Value.Replace(",", "','") + @"']" : string.Empty) + @")

            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetWorkType", @"
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceWorkType.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    ", true);

            }

            ddlRolePreferenceJobSubClassification.Attributes.Add("onchange", "$('#" + hfRolePreferenceJobSubClassification.ClientID + "').val($('#" + ddlRolePreferenceJobSubClassification.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(hfRolePreferenceJobSubClassification.Value))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetRole", @"
            $(document).ready(function() {
                 $('#" + ddlRolePreferenceJobSubClassification.ClientID + @"').multiselect('select', ['" + hfRolePreferenceJobSubClassification.Value.Replace(",", "','") + @"']);
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetRole", @"
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceJobSubClassification.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    ", true);

            }

            ddlRolePreferenceDesiredRegion.Attributes.Add("onchange", "$('#" + hfRolePreferenceDesiredRegion.ClientID + "').val($('#" + ddlRolePreferenceDesiredRegion.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(hfRolePreferenceDesiredRegion.Value))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetArea", @"
            $(document).ready(function() {
                $('#" + ddlRolePreferenceDesiredRegion.ClientID + @"').multiselect('select', ['" + hfRolePreferenceDesiredRegion.Value.Replace(",", "','") + @"']);
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetArea", @"
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceDesiredRegion.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    ", true);

            }

            ddlRolePreferenceEligibleToWorkIn.Attributes.Add("onchange", "$('#" + hfRolePreferenceEligibleWorkIn.ClientID + "').val($('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + "').val());");
            if (!string.IsNullOrWhiteSpace(hfRolePreferenceEligibleWorkIn.Value))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEligible", @"
            $(document).ready(function() {
                
                $('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect('select', ['" + hfRolePreferenceEligibleWorkIn.Value.Replace(",", "','") + @"']);
               
            });
            ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEligible", @"
                        $(document).ready(function() {

                            $('#" + ddlRolePreferenceEligibleToWorkIn.ClientID + @"').multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
                            });
                        });
                    ", true);

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Test", @"
            $(document).ready(function() {
              $('button').prop('class', 'multiselect dropdown-toggle form-control');
               
            });
            ", true);

            if (hasError)
            {
                OpenRepeaterDiv(string.Empty, controltofocus);

                acRolePrefrence.Attributes.Add("class", "section-content edit-mode");
                editRole.Attributes.Add("class", "profile-edit collapse in");
                return;
            }
            acRolePrefrence.Attributes.Add("class", "section-content");
            editRole.Attributes.Add("class", "profile-edit collapse");

            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null && member.SiteId == SessionData.Site.SiteId)
                {
                    member.WorkTypeId = hfRolePreferenceWorkType.Value;
                    if (!string.IsNullOrWhiteSpace(ddlRolePreferenceSalaryRequirements.SelectedValue))
                    {
                        member.PreferredSalaryId = Convert.ToInt32(ddlRolePreferenceSalaryRequirements.SelectedValue);
                    }
                    else
                    {
                        member.PreferredSalaryId = (int?)null;
                    }

                    member.PreferredSalaryFrom = tbRolePreferenceSalaryMin.Text;
                    member.PreferredSalaryTo = tbRolePreferenceSalaryMax.Text;

                    member.PreferredCategoryId = ddlRolePreferenceJobClassification.SelectedValue;
                    member.PreferredSubCategoryId = hfRolePreferenceJobSubClassification.Value;

                    member.LocationId = ddlRolePreferenceDesiredLocation.SelectedValue;
                    member.AreaId = hfRolePreferenceDesiredRegion.Value;
                    member.EligibleToWorkIn = hfRolePreferenceEligibleWorkIn.Value;

                    if (MembersService.Update(member))
                    {
                        SetRolePreferences(member, 0);
                        SetMemberPoints();
                    }
                }
            }

            //scroll to next section
            ScrollToNextSectionJS(lbRolePreferenceSave.ClientID);
        }

        #endregion

        #region Resume

        private int SetAttachResume(Entities.Members member, int point)
        {
            using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(member.MemberId))
            {
                resumes.Filter = "DocumentTypeId = 2";

                rptResume.DataSource = resumes;
                rptResume.DataBind();

                phNavResume.Visible = (resumes.Count == 0);
                phAddEntryTextResume.Visible = (resumes.Count == 0);
                phTickResume.Visible = (resumes.Count > 0);
            }

            return 0;
        }

        private void DeleteAttachResume(int resumeid)
        {
            using (MemberFiles memberfile = MemberFilesService.GetByMemberFileId(resumeid))
            {
                if (memberfile != null && memberfile.MemberId == SessionData.Member.MemberId)
                {
                    MemberFilesService.Delete(memberfile);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptResume_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ResumeDownload")
            {

            }

            if (e.CommandName == "ResumeDelete")
            {
                DeleteAttachResume(Convert.ToInt32(e.CommandArgument));

                using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    resumes.Filter = "DocumentTypeId = 2";

                    rptResume.DataSource = resumes;
                    rptResume.DataBind();

                    phNavResume.Visible = (resumes.Count == 0);
                    phAddEntryTextResume.Visible = (resumes.Count == 0);
                    phTickResume.Visible = (resumes.Count > 0);
                }
            }

            StandardResetJS();

            OpenAddDiv(string.Empty, hfResume.ClientID);
            SetMemberPoints();
        }

        protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltResumeFileName = e.Item.FindControl("ltResumeFileName") as Literal;
                HyperLink hlResumeDownload = e.Item.FindControl("hlResumeDownload") as HyperLink;
                LinkButton lbResumeDelete = e.Item.FindControl("lbResumeDelete") as LinkButton;

                MemberFiles resume = e.Item.DataItem as MemberFiles;

                ltResumeFileName.Text = (string.IsNullOrEmpty(resume.MemberFileTitle)) ? HttpUtility.HtmlEncode(resume.MemberFileName) : HttpUtility.HtmlEncode(resume.MemberFileTitle);
                hlResumeDownload.NavigateUrl = "/download.aspx?type=mf&id=" + resume.MemberFileId.ToString();
                lbResumeDelete.CommandArgument = resume.MemberFileId.ToString();
                lbResumeDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbResumeDelete.ClientID + "').prop('href'))});";
            }
        }

        protected void lbResumeSave_Click(object sender, EventArgs e)
        {
            phCustomCoverLetterError.Visible = false;
            phCoverLetterTitleError.Visible = false;
            phCoverLetterError.Visible = false;
            phResumeError.Visible = false;

            using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
            {
                resumes.Filter = "DocumentTypeId = 2";

                if (resumes.Count >= 3)
                {
                    rptResume.DataSource = resumes;
                    rptResume.DataBind();

                    phNavResume.Visible = (resumes.Count == 0);
                    phAddEntryTextResume.Visible = (resumes.Count == 0);
                    phTickResume.Visible = (resumes.Count > 0);

                    return;
                }
            }

            if (fuResume.HasFile && fuResume.PostedFile.ContentLength > 0)
            {
                bool hasExistingResume = false;
                bool updateResume = false;
                MemberFiles mf = new MemberFiles();
                using (TList<MemberFiles> memberfiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    foreach (MemberFiles memberfile in memberfiles)
                    {
                        if (memberfile.DocumentTypeId == 2)
                        {
                            mf = memberfile;
                            hasExistingResume = true;
                            break;
                        }
                    }
                }
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    mf.MemberFileName = System.IO.Path.GetFileName(fuResume.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                }
                mf.MemberFileSearchExtension = System.IO.Path.GetExtension(fuResume.PostedFile.FileName).Trim();

                bool found = false;

                foreach (string ext in ConfigurationManager.AppSettings["ApplicationFileTypes"].Split(new char[] { ',' }))
                {
                    if (ext == mf.MemberFileSearchExtension)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    phResumeError.Visible = true;

                    StandardResetJS();
                    OpenAddDiv(hfResume.ClientID, fuResume.ClientID);

                    newResume.Attributes.Add("class", "profile-edit collapse in");
                    return;
                }
                else
                {
                    updateResume = true;
                    mf.MemberFileTitle = mf.MemberFileName;
                    mf.MemberId = SessionData.Member.MemberId;
                    mf.MemberFileTypeId = MemberFileTypeID(fuResume.PostedFile.FileName);
                    mf.DocumentTypeId = 2;
                }
                if (updateResume)
                {
                    //if (hasExistingResume)
                    //{
                    //    if (MemberFilesService.Update(mf))
                    //    {
                    //    }
                    //}
                    //else
                    {
                        if (MemberFilesService.Insert(mf))
                        {
                            string extension = string.Empty;

                            extension = Path.GetExtension(fuResume.PostedFile.FileName);
                            string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                            string errormessage = string.Empty;

                            FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, fuResume.PostedFile.InputStream, out errormessage);
                            
                            mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);

                            MemberFilesService.Update(mf);

                            UpdateMemberLastModified();

                            //Upload to the BH if enabled
                            if (BullhornSettings != null && BullhornSettings.EnableCandidateSync)
                            {
                                //get member's external ID
                                Entities.Members thisMember = MembersService.GetByMemberId(SessionData.Member.MemberId);

                                if (!string.IsNullOrEmpty(thisMember.ExternalMemberId))
                                {
                                    try
                                    {
                                        //Resume
                                        BullhornRESTAPI.BHCandidateFileAttach(int.Parse(thisMember.ExternalMemberId), SessionData.Site.SiteId, null, this.fuResume.PostedFile.InputStream, this.fuResume.PostedFile.FileName);

                                        //Send confirmation email to new member and site's admin
                                        MailService.SendMemberUploadResumeToSiteAdmin(thisMember, new List<HttpPostedFile>() { fuResume.PostedFile });
                                    }
                                    catch (Exception ex)
                                    {
                                        //TODO: log exception
                                        _logger.Error("Failed to process candidate file via Bullhorn API", ex);

                                        throw new Exception("Failed to process candidate file via Bullhorn API - Exception ID: " + -1);
                                    }
                                }
                            }

                        }
                    }

                    using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                    {
                        resumes.Filter = "DocumentTypeId = 2";

                        rptResume.DataSource = resumes;
                        rptResume.DataBind();

                        phNavResume.Visible = (resumes.Count == 0);
                        phAddEntryTextResume.Visible = (resumes.Count == 0);
                        phTickResume.Visible = (resumes.Count > 0);
                    }


                }
            }
            SetSupplementaryQuestions();

            OpenAddDiv(string.Empty, upResume.ClientID);
            newResume.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();

            //scroll to next section
            ScrollToNextSectionJS(lbResumeSave.ClientID);
        }

        #endregion

        #region Cover Letter

        private void SetAttachCoverletter()
        {
            using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
            {
                coverletters.Filter = "DocumentTypeId = 1";

                rptCoverLetter.DataSource = coverletters;
                rptCoverLetter.DataBind();

                phNavCoverLetter.Visible = (coverletters.Count == 0);
                phAddEntryTextCoverletter.Visible = (coverletters.Count == 0);
                phTickCoverLetter.Visible = (coverletters.Count > 0);
            }

        }

        private void DeleteAttachCoverletter(int coverletterid)
        {
            using (MemberFiles memberfile = MemberFilesService.GetByMemberFileId(coverletterid))
            {
                if (memberfile != null && memberfile.MemberId == SessionData.Member.MemberId)
                {
                    MemberFilesService.Delete(memberfile);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void rptCoverLetter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CoverLetterDownload")
            {

            }

            if (e.CommandName == "CoverLetterDelete")
            {
                DeleteAttachCoverletter(Convert.ToInt32(e.CommandArgument));

                using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    coverletters.Filter = "DocumentTypeId = 1";

                    rptCoverLetter.DataSource = coverletters;
                    rptCoverLetter.DataBind();

                    phNavCoverLetter.Visible = (coverletters.Count == 0);
                    phAddEntryTextCoverletter.Visible = (coverletters.Count == 0);
                    phTickCoverLetter.Visible = (coverletters.Count > 0);
                }
            }

            StandardResetJS();
            OpenAddDiv(string.Empty, hfCoverLetter.ClientID);
            SetMemberPoints();
        }

        protected void rptCoverLetter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltCoverLetterFileName = e.Item.FindControl("ltCoverLetterFileName") as Literal;
                HyperLink hlCoverLetterDownload = e.Item.FindControl("hlCoverLetterDownload") as HyperLink;
                LinkButton lbCoverLetterDelete = e.Item.FindControl("lbCoverLetterDelete") as LinkButton;

                MemberFiles coverletter = e.Item.DataItem as MemberFiles;

                ltCoverLetterFileName.Text = (string.IsNullOrEmpty(coverletter.MemberFileTitle)) ? HttpUtility.HtmlEncode(coverletter.MemberFileName) : HttpUtility.HtmlEncode(coverletter.MemberFileTitle);
                hlCoverLetterDownload.NavigateUrl = "/download.aspx?type=mf&id=" + coverletter.MemberFileId.ToString();
                lbCoverLetterDelete.CommandArgument = coverletter.MemberFileId.ToString();
                lbCoverLetterDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbCoverLetterDelete.ClientID + "').prop('href'))});";
            }
        }

        protected void lbCoverLetterSave_Click(object sender, EventArgs e)
        {
            phCustomCoverLetterError.Visible = false;
            phCoverLetterTitleError.Visible = false;
            phCoverLetterError.Visible = false;
            phResumeError.Visible = false;
            // Cover Letter

            using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
            {
                coverletters.Filter = "DocumentTypeId = 1";

                if (coverletters.Count >= 3)
                {
                    rptCoverLetter.DataSource = coverletters;
                    rptCoverLetter.DataBind();

                    phNavCoverLetter.Visible = (coverletters.Count == 0);
                    phAddEntryTextCoverletter.Visible = (coverletters.Count == 0);
                    phTickCoverLetter.Visible = (coverletters.Count > 0);

                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(tbCoverLetterTitle.Text))
            {
                phCoverLetterTitleError.Visible = true;
                ltErrorCoverLetterTitle.SetLanguageCode = "LabelRequiredField1";
                StandardResetJS();
                OpenAddDiv(hfCoverLetter.ClientID, tbCoverLetterTitle.ClientID);
                newCoverletter.Attributes.Add("class", "profile-edit collapse in");

                return;
            }
            else
            {
                if (Regex.IsMatch(tbCoverLetterTitle.Text, ContentValidationRegex) == false)
                {
                    phCoverLetterTitleError.Visible = true;
                    ltErrorCoverLetterTitle.SetLanguageCode = "ValidateNoHTMLContent";

                    StandardResetJS();
                    OpenAddDiv(hfCoverLetter.ClientID, tbCoverLetterTitle.ClientID);
                    newCoverletter.Attributes.Add("class", "profile-edit collapse in");

                    return;
                }
            }


            MemberFiles mf = new MemberFiles();

            if (rbCoverLetterUpload.Checked)
            {
                if (fuCoverLetter.HasFile && fuCoverLetter.PostedFile.ContentLength > 0)
                {
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        mf.MemberFileName = System.IO.Path.GetFileName(fuCoverLetter.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                    }
                    mf.MemberFileSearchExtension = System.IO.Path.GetExtension(fuCoverLetter.PostedFile.FileName).Trim();

                    bool found = false;

                    foreach (string ext in ConfigurationManager.AppSettings["ApplicationFileTypes"].Split(new char[] { ',' }))
                    {
                        if (ext == mf.MemberFileSearchExtension)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        // Error
                        phCoverLetterError.Visible = true;

                        StandardResetJS();
                        OpenAddDiv(hfCoverLetter.ClientID, fuCoverLetter.ClientID);

                        return;
                    }
                    else
                    {
                        mf.MemberFileTitle = tbCoverLetterTitle.Text;
                        mf.MemberId = SessionData.Member.MemberId;
                        mf.MemberFileTypeId = MemberFileTypeID(fuCoverLetter.PostedFile.FileName);
                        mf.DocumentTypeId = 1;
                    }
                }
                else
                {
                    // Error
                    phCoverLetterError.Visible = true;

                    StandardResetJS();
                    OpenAddDiv(hfCoverLetter.ClientID, fuCoverLetter.ClientID);
                    newCoverletter.Attributes.Add("class", "profile-edit collapse");

                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbCustomCoverLetter.Text))
                {


                    mf.MemberFileName = "CoverLetter.txt";

                    mf.MemberFileSearchExtension = System.IO.Path.GetExtension("CoverLetter.txt").Trim();
                    mf.MemberFileTitle = tbCoverLetterTitle.Text;
                    mf.MemberId = SessionData.Member.MemberId;
                    mf.MemberFileTypeId = MemberFileTypeID("CoverLetter.txt");
                    mf.DocumentTypeId = 1;
                }
                else
                {
                    phCustomCoverLetterError.Visible = true;
                    StandardResetJS();
                    OpenAddDiv(hfCoverLetter.ClientID, tbCustomCoverLetter.ClientID);

                    return;
                }
            }

            MemberFilesService.Insert(mf);

            string extension = string.Empty;

            extension = mf.MemberFileSearchExtension;
            string filepath = string.Format("MemberFiles_{0}{1}",mf.MemberFileId, extension);
            string errormessage = string.Empty;

            Stream ms = null;
            if (rbCoverLetterUpload.Checked)
            {
                ms = fuCoverLetter.PostedFile.InputStream;   
            }
            else
            {
                ms = new MemoryStream(GetBytes(tbCustomCoverLetter.Text));
            }

            FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, ms, out errormessage);

            mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);

            MemberFilesService.Update(mf);


            UpdateMemberLastModified();

            //Upload to the BH if enabled
            if (BullhornSettings != null && BullhornSettings.EnableCandidateSync)
            {
                //get member's external ID
                Entities.Members thisMember = MembersService.GetByMemberId(SessionData.Member.MemberId);

                if (!string.IsNullOrEmpty(thisMember.ExternalMemberId))
                {
                    BullhornRESTAPI.BHCandidateFileAttach(int.Parse(thisMember.ExternalMemberId), SessionData.Site.SiteId, null, ms, mf.MemberFileName);
                }
            }

            using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
            {
                coverletters.Filter = "DocumentTypeId = 1";

                rptCoverLetter.DataSource = coverletters;
                rptCoverLetter.DataBind();

                phNavCoverLetter.Visible = (coverletters.Count == 0);
                phAddEntryTextCoverletter.Visible = (coverletters.Count == 0);
                phTickCoverLetter.Visible = (coverletters.Count > 0);
            }

            tbCoverLetterTitle.Text = string.Empty;
            rbCoverLetterUpload.Checked = true;
            tbCustomCoverLetter.Text = string.Empty;

            OpenAddDiv(string.Empty, upCoverLetter.ClientID);
            SetMemberPoints();
        }

        #endregion

        #region Languages

        private void LoadMemberProficiency()
        {
            ProficiencyList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.LanguagesProfieciency>();
        }

        private int SetLanguages(Entities.Members member, int point)
        {
            using (TList<Entities.MemberLanguages> memberlanguages = MemberLanguagesService.GetByMemberId(member.MemberId))
            {
                rptLanguages.DataSource = memberlanguages;
                rptLanguages.DataBind();

                phNavLanguages.Visible = (memberlanguages.Count == 0);
                phAddEntryTextLanguages.Visible = (memberlanguages.Count == 0);
                phTickLanguage.Visible = (memberlanguages.Count > 0);
            }

            return 0;
        }

        private void DeleteLanguages(int languageid)
        {
            using (MemberLanguages memberlanguage = MemberLanguagesService.GetByMemberLanguageId(languageid))
            {
                if (memberlanguage != null && memberlanguage.MemberId == SessionData.Member.MemberId)
                {
                    MemberLanguagesService.Delete(memberlanguage);
                    UpdateMemberLastModified();
                }
            }
        }

        protected void lbLanguageAdd_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            string controltofocus = string.Empty;

            phLanguageNameError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbLanguageName.Text))
            {
                hasError = true;
                phLanguageNameError.Visible = true;
                ucLanguageNameError.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbLanguageName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbLanguageName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phLanguageNameError.Visible = true;
                    ucLanguageNameError.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbLanguageName.ClientID;
                    }
                }
            }

            if (hasError)
            {
                phLanguageNameError.Visible = true;

                StandardResetJS();
                OpenAddDiv(string.Empty, controltofocus);

                acLanguage.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newLanguage.Attributes.Add("class", "profile-edit collapse in");

                return;
            }

            Entities.MemberLanguages language = new MemberLanguages();
            language.Langauges = tbLanguageName.Text;
            language.Profieciency = Convert.ToInt32(ddlLanguageProficiency.SelectedValue);
            language.MemberId = SessionData.Member.MemberId;




            MemberLanguagesService.Insert(language);
            UpdateMemberLastModified();
            using (TList<Entities.MemberLanguages> languages = MemberLanguagesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptLanguages.DataSource = languages;
                rptLanguages.DataBind();

                phNavLanguages.Visible = (languages.Count == 0);
                phAddEntryTextLanguages.Visible = (languages.Count == 0);
                phTickLanguage.Visible = (languages.Count > 0);
            }

            tbLanguageName.Text = string.Empty;
            ddlLanguageProficiency.SelectedIndex = 0;

            StandardResetJS();

            acLanguage.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newLanguage.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        protected void rptLanguages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "LanguageDelete")
            {
                MemberLanguagesService.Delete(Convert.ToInt32(e.CommandArgument));
                UpdateMemberLastModified();
            }

            using (TList<Entities.MemberLanguages> languages = MemberLanguagesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptLanguages.DataSource = languages;
                rptLanguages.DataBind();

                phNavLanguages.Visible = (languages.Count == 0);
                phAddEntryTextLanguages.Visible = (languages.Count == 0);
                phTickLanguage.Visible = (languages.Count > 0);
            }

            StandardResetJS();
            SetMemberPoints();
        }

        protected void rptLanguages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLanguageName = e.Item.FindControl("ltLanguageName") as Literal;
                Literal ltProficiency = e.Item.FindControl("ltProficiency") as Literal;
                LinkButton lbLanguageDelete = e.Item.FindControl("lbLanguageDelete") as LinkButton;

                MemberLanguages language = e.Item.DataItem as MemberLanguages;

                ltLanguageName.Text = HttpUtility.HtmlEncode(language.Langauges);
                if (language.Profieciency.HasValue)
                {
                    foreach (ListItem item in ddlLanguageProficiency.Items)
                    {
                        if (item.Value == language.Profieciency.Value.ToString())
                        {
                            ltProficiency.Text = HttpUtility.HtmlEncode(item.Text);
                            break;
                        }
                    }

                }

                lbLanguageDelete.CommandArgument = language.MemberLanguageId.ToString();

            }
        }

        #endregion

        #region Reference

        private void LoadRelationship()
        {
            RelationshipList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.ReferencesRelationship>();
        }

        protected void LoadReferences()
        {
            using (TList<MemberReferences> references = MemberReferencesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptReferences.DataSource = references;
                rptReferences.DataBind();

                phNavReferences.Visible = (references.Count == 0);
                phTickReferences.Visible = (references.Count > 0);
                phUponRequest.Visible = (MinReferenceEntry == 0 && references.Count == 0);
                refUponRequest.Checked = (references.Count == 0);
                phAddEntryTextReferences.Visible = (references.Count == 0);
            }
        }

        private int SetReferences(Entities.Members member, int point)
        {
            using (TList<Entities.MemberReferences> memberreferences = MemberReferencesService.GetByMemberId(member.MemberId))
            {
                rptReferences.DataSource = memberreferences;
                rptReferences.DataBind();

                phUponRequest.Visible = (MinReferenceEntry == 0 && memberreferences.Count == 0);
                refUponRequest.Checked = (memberreferences.Count == 0) ? (member.ReferenceUponRequest.HasValue) ? member.ReferenceUponRequest.Value : true : false;

                phNavReferences.Visible = (memberreferences.Count < MinReferenceEntry);
                phAddEntryTextReferences.Visible = (memberreferences.Count < MinReferenceEntry);
                phTickReferences.Visible = (memberreferences.Count >= MinReferenceEntry);
            }
            return 0;
        }

        private void DeleteReferences(int referenceid)
        {
            using (MemberReferences memberreference = MemberReferencesService.GetByMemberReferenceId(referenceid))
            {
                if (memberreference != null && memberreference.MemberId == SessionData.Member.MemberId)
                {
                    MemberReferencesService.Delete(memberreference);
                    UpdateMemberLastModified();
                }
            }

        }

        private void UponRequestResetJS()
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "UponRequestReset", @"
            /* upon request checkbox functionality */
	        $("".uponrequest-btn"").change(function(){
		        $("".upon-request-submit-btn"").css({""opacity"":1,""width"":'auto', ""visibility"":'visible'});
	        });

	        /* certificate validity date - checkbox action */
	        $("".certificate_checkbox .btn-checkbox"").change(function(){
		        if($(this).is("":checked"")){
				        $("".certificate_validity_wrap select"").prop('disabled', 'disabled');
			        }
			        else
			        {
				        $("".certificate_validity_wrap select"").removeAttr(""disabled"");
			        }
	        });
            ", true);
        }

        protected void rptReferences_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            acReferenceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newReference.Attributes.Add("class", "profile-edit collapse");

            Literal ltReferencesCompany = e.Item.FindControl("ltReferencesCompany") as Literal;
            Literal ltReferencesName = e.Item.FindControl("ltReferencesName") as Literal;
            Literal ltReferencesJobTitle = e.Item.FindControl("ltReferencesJobTitle") as Literal;
            Literal ltReferencesRelationship = e.Item.FindControl("ltReferencesRelationship") as Literal;
            Literal ltReferencePhone = e.Item.FindControl("ltReferencePhone") as Literal;
            Literal ltReferenceEmail = e.Item.FindControl("ltReferenceEmail") as Literal;

            PlaceHolder phReferencesPhone = e.Item.FindControl("phReferencesPhone") as PlaceHolder;

            PlaceHolder phReferencesPhoneError = e.Item.FindControl("phReferencesPhoneError") as PlaceHolder;
            ucLanguageLiteral ucReferencesPhoneError = e.Item.FindControl("ucReferencesPhoneError") as ucLanguageLiteral;

            PlaceHolder phReferencesNameError = e.Item.FindControl("phReferencesNameError") as PlaceHolder;
            ucLanguageLiteral ucReferencesNameError = e.Item.FindControl("ucReferencesNameError") as ucLanguageLiteral;

            PlaceHolder phReferencesCompanyError = e.Item.FindControl("phReferencesCompanyError") as PlaceHolder;
            ucLanguageLiteral ucReferencesCompanyError = e.Item.FindControl("ucReferencesCompanyError") as ucLanguageLiteral;

            PlaceHolder phReferencesEmailRequiredError = e.Item.FindControl("phReferencesEmailRequiredError") as PlaceHolder;
            PlaceHolder phReferencesEmailError = e.Item.FindControl("phReferencesEmailError") as PlaceHolder;

            TextBox tbReferencesName = e.Item.FindControl("tbReferencesName") as TextBox;

            TextBox tbReferencesJobTitle = e.Item.FindControl("tbReferencesJobTitle") as TextBox;
            ucLanguageLiteral ucReferencesJobTitleError = e.Item.FindControl("ucReferencesJobTitleError") as ucLanguageLiteral;

            PlaceHolder phReferencesJobTitleError = e.Item.FindControl("phReferencesJobTitleError") as PlaceHolder;
            TextBox tbRefernecesCompany = e.Item.FindControl("tbRefernecesCompany") as TextBox;
            TextBox tbReferencesPhone = e.Item.FindControl("tbReferencesPhone") as TextBox;
            TextBox tbReferencesEmail = e.Item.FindControl("tbReferencesEmail") as TextBox;
            DropDownList ddlReferencesRelationship = e.Item.FindControl("ddlReferencesRelationship") as DropDownList;
            LinkButton lbReferencesSave = e.Item.FindControl("lbReferencesSave") as LinkButton;
            System.Web.UI.HtmlControls.HtmlAnchor aReferenceEdit = e.Item.FindControl("aReferenceEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
            aReferenceEdit.Attributes.Add("href", "#edit-Reference" + (e.Item.ItemIndex + 1).ToString());
            System.Web.UI.HtmlControls.HtmlGenericControl acReference = e.Item.FindControl("acReference") as System.Web.UI.HtmlControls.HtmlGenericControl;

            if (e.CommandName == "ReferencesSave")
            {
                bool hasError = false;
                string controltofocus = string.Empty;

                phReferencesPhoneError.Visible = false;
                phReferencesNameError.Visible = false;
                phReferencesJobTitleError.Visible = false;
                phReferencesCompanyError.Visible = false;
                phReferencesEmailError.Visible = false;
                phReferencesEmailRequiredError.Visible = false;

                if (string.IsNullOrWhiteSpace(tbReferencesPhone.Text))
                {
                    hasError = true;
                    phReferencesPhoneError.Visible = true;
                    ucReferencesPhoneError.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesPhone.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbReferencesPhone.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phReferencesPhoneError.Visible = true;
                        ucReferencesPhoneError.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbReferencesPhone.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbReferencesName.Text))
                {
                    hasError = true;
                    phReferencesNameError.Visible = true;
                    ucReferencesNameError.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesName.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbReferencesName.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phReferencesNameError.Visible = true;
                        ucReferencesNameError.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbReferencesName.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbReferencesJobTitle.Text))
                {
                    hasError = true;
                    phReferencesJobTitleError.Visible = true;
                    ucReferencesJobTitleError.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesJobTitle.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbReferencesJobTitle.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phReferencesJobTitleError.Visible = true;
                        ucReferencesJobTitleError.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbReferencesJobTitle.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbRefernecesCompany.Text))
                {
                    hasError = true;
                    phReferencesCompanyError.Visible = true;
                    ucReferencesCompanyError.SetLanguageCode = "LabelRequiredField1";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbRefernecesCompany.ClientID;
                    }
                }
                else
                {
                    if (Regex.IsMatch(tbRefernecesCompany.Text, ContentValidationRegex) == false)
                    {
                        hasError = true;
                        phReferencesCompanyError.Visible = true;
                        ucReferencesCompanyError.SetLanguageCode = "ValidateNoHTMLContent";

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbReferencesJobTitle.ClientID;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(tbReferencesEmail.Text))
                {
                    hasError = true;
                    phReferencesEmailRequiredError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesEmail.ClientID;
                    }
                }
                else
                {
                    if (Utils.VerifyEmail(tbReferencesEmail.Text) == false)
                    {
                        hasError = true;
                        phReferencesEmailError.Visible = true;

                        if (string.IsNullOrWhiteSpace(controltofocus))
                        {
                            controltofocus = tbReferencesEmail.ClientID;
                        }
                    }
                }

                if (hasError)
                {
                    StandardResetJS();
                    UponRequestResetJS();
                    OpenRepeaterDiv(string.Empty, controltofocus);

                    acReference.Attributes.Add("class", "section-content edit-mode");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ReferenceError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Reference" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse in');
		                });
                    </script>
                    ", false);

                    return;

                }

                using (MemberReferences reference = MemberReferencesService.GetByMemberReferenceId(Convert.ToInt32(e.CommandArgument)))
                {

                    if (reference != null)
                    {
                        reference.MemberReferenceName = tbReferencesName.Text;
                        reference.JobTitle = tbReferencesJobTitle.Text;
                        reference.Company = tbRefernecesCompany.Text;
                        reference.Phone = tbReferencesPhone.Text;
                        reference.ReferenceEmail = tbReferencesEmail.Text;

                        reference.Relationship = Convert.ToInt32(ddlReferencesRelationship.SelectedValue);

                        ltReferencesCompany.Text = HttpUtility.HtmlEncode(reference.Company);
                        ltReferencesName.Text = HttpUtility.HtmlEncode(reference.MemberReferenceName);
                        ltReferencesJobTitle.Text = HttpUtility.HtmlEncode(reference.JobTitle);
                        if (reference.Relationship.HasValue)
                        {
                            ltReferencesRelationship.Text = HttpUtility.HtmlEncode(ddlReferencesRelationship.SelectedItem.Text);
                        }
                        ltReferencePhone.Text = HttpUtility.HtmlEncode(reference.Phone);
                        ltReferenceEmail.Text = HttpUtility.HtmlEncode(reference.ReferenceEmail ?? string.Empty);

                        if (!string.IsNullOrEmpty(reference.Phone))
                        {
                            phReferencesPhone.Visible = true;
                        }

                        MemberReferencesService.Update(reference);
                        UpdateMemberLastModified();
                    }
                }
            }

            LoadRelationship();
            if (e.CommandName == "ReferencesDelete")
            {
                DeleteReferences(Convert.ToInt32(e.CommandArgument));


                using (TList<MemberReferences> references = MemberReferencesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    rptReferences.DataSource = references;
                    rptReferences.DataBind();

                    if (references.Count == 0)
                    {
                        using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
                        {
                            if (member != null)
                            {
                                member.ReferenceUponRequest = true;

                                MembersService.Update(member);
                            }
                        }
                    }

                    phNavReferences.Visible = (references.Count == 0);
                    phTickReferences.Visible = (references.Count > 0);
                    phAddEntryTextReferences.Visible = (references.Count == 0);

                    phUponRequest.Visible = (MinReferenceEntry == 0 && references.Count == 0);
                    refUponRequest.Checked = (references.Count == 0);
                }
            }

            // Load all references
            LoadReferences();


            StandardResetJS();
            UponRequestResetJS();

            acReference.Attributes.Add("class", "section-content");
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ReferenceError", @"
                    <script type='text/javascript'>
                        $(document).ready(function() {
                            $('#edit-Reference" + (e.Item.ItemIndex + 1).ToString() + @"').prop('class', 'profile-edit collapse');
		                });
                    </script>
                    ", false);
            SetMemberPoints();
        }

        protected void rptReferences_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal ltReferencesCompany = e.Item.FindControl("ltReferencesCompany") as Literal;
                Literal ltReferencesName = e.Item.FindControl("ltReferencesName") as Literal;
                Literal ltReferencesJobTitle = e.Item.FindControl("ltReferencesJobTitle") as Literal;
                Literal ltReferencesRelationship = e.Item.FindControl("ltReferencesRelationship") as Literal;
                Literal ltReferencePhone = e.Item.FindControl("ltReferencePhone") as Literal;
                Literal ltReferencesEmailDisplay = e.Item.FindControl("ltReferencesEmailDisplay") as Literal;

                PlaceHolder phReferencesPhone = e.Item.FindControl("phReferencesPhone") as PlaceHolder;

                TextBox tbReferencesName = e.Item.FindControl("tbReferencesName") as TextBox;
                TextBox tbReferencesJobTitle = e.Item.FindControl("tbReferencesJobTitle") as TextBox;
                TextBox tbRefernecesCompany = e.Item.FindControl("tbRefernecesCompany") as TextBox;
                TextBox tbReferencesPhone = e.Item.FindControl("tbReferencesPhone") as TextBox;
                TextBox tbReferencesEmail = e.Item.FindControl("tbReferencesEmail") as TextBox;
                DropDownList ddlReferencesRelationship = e.Item.FindControl("ddlReferencesRelationship") as DropDownList;
                LinkButton lbReferencesSave = e.Item.FindControl("lbReferencesSave") as LinkButton;
                LinkButton lbReferencesDelete = e.Item.FindControl("lbReferencesDelete") as LinkButton;
                System.Web.UI.HtmlControls.HtmlAnchor aReferenceEdit = e.Item.FindControl("aReferenceEdit") as System.Web.UI.HtmlControls.HtmlAnchor;
                aReferenceEdit.Attributes.Add("href", "#edit-Reference" + (e.Item.ItemIndex + 1).ToString());

                //placeholder
                tbReferencesName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelName"));
                tbReferencesJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
                tbRefernecesCompany.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCompany"));
                tbReferencesPhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhone"));
                tbReferencesEmail.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEmail"));

                MemberReferences reference = e.Item.DataItem as MemberReferences;
                lbReferencesDelete.CommandArgument = reference.MemberReferenceId.ToString();
                lbReferencesDelete.OnClientClick = "$('#confirmDeleteYes').click(function() { eval($('#" + lbReferencesDelete.ClientID + "').prop('href'))});";
                ddlReferencesRelationship.Items.Clear();
                ddlReferencesRelationship.DataValueField = "Value";
                ddlReferencesRelationship.DataTextField = "Key";
                ddlReferencesRelationship.DataSource = RelationshipList;
                ddlReferencesRelationship.DataBind();


                tbReferencesName.Text = reference.MemberReferenceName;
                tbReferencesJobTitle.Text = reference.JobTitle;
                tbRefernecesCompany.Text = reference.Company;
                tbReferencesPhone.Text = reference.Phone;
                tbReferencesEmail.Text = reference.ReferenceEmail ?? string.Empty;
                if (reference.Relationship.HasValue)
                {
                    ddlReferencesRelationship.SelectedValue = reference.Relationship.Value.ToString();
                }

                ltReferencesCompany.Text = HttpUtility.HtmlEncode(reference.Company);
                ltReferencesName.Text = HttpUtility.HtmlEncode(reference.MemberReferenceName);
                ltReferencesJobTitle.Text = HttpUtility.HtmlEncode(reference.JobTitle);
                ltReferencePhone.Text = HttpUtility.HtmlEncode(reference.Phone);
                if (!string.IsNullOrEmpty(reference.ReferenceEmail))
                    ltReferencesEmailDisplay.Text = @"<span class=""fa fa-envelope""><!-- icon --></span> " + HttpUtility.HtmlEncode(reference.ReferenceEmail);

                if (reference.Relationship.HasValue)
                {
                    ltReferencesRelationship.Text = HttpUtility.HtmlEncode(ddlReferencesRelationship.SelectedItem.Text);
                }

                if (!string.IsNullOrEmpty(reference.Phone))
                {
                    phReferencesPhone.Visible = true;
                }

                lbReferencesSave.CommandName = "ReferencesSave";
                lbReferencesSave.CommandArgument = reference.MemberReferenceId.ToString();
            }
        }

        protected void lbReferencesSubmit_Click(object sender, EventArgs e)
        {
            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    member.ReferenceUponRequest = refUponRequest.Checked;

                    MembersService.Update(member);
                }
            }

            StandardResetJS();
            UponRequestResetJS();
        }

        protected void lbReferencesAddSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptReferences.Items)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl acReference = item.FindControl("acReference") as System.Web.UI.HtmlControls.HtmlGenericControl;
                acReference.Attributes.Add("class", "section-content");
            }

            bool hasError = false;
            string controltofocus = string.Empty;

            phReferencesAddNameError.Visible = false;
            phReferencesAddPhoneError.Visible = false;
            phRelationshipError.Visible = false;
            phReferencesAddJobTitleError.Visible = false;
            phReferencesAddCompany.Visible = false;
            phReferencesAddEmailError.Visible = false;
            phReferencesAddEmailRequiredError.Visible = false;

            if (string.IsNullOrWhiteSpace(tbReferencesAddPhone.Text))
            {
                hasError = true;
                phReferencesAddPhoneError.Visible = true;
                ucReferencesAddPhone.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbReferencesAddPhone.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbReferencesAddPhone.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phReferencesAddPhoneError.Visible = true;
                    ucReferencesAddPhone.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesAddPhone.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbReferencesAddName.Text))
            {
                hasError = true;
                phReferencesAddNameError.Visible = true;
                ucReferencesAddNameError.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbReferencesAddName.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbReferencesAddName.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phReferencesAddNameError.Visible = true;
                    ucReferencesAddNameError.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesAddName.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(ddlReferencesAddRelationship.SelectedValue))
            {
                hasError = true;
                phRelationshipError.Visible = true;

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbReferencesAddJobTitle.ClientID;
                }
            }

            if (string.IsNullOrWhiteSpace(tbReferencesAddJobTitle.Text))
            {
                hasError = true;
                phReferencesAddJobTitleError.Visible = true;
                ucReferencesAddJobTitle.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbReferencesAddJobTitle.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbReferencesAddJobTitle.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phReferencesAddJobTitleError.Visible = true;
                    ucReferencesAddJobTitle.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesAddJobTitle.ClientID;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbRefernecesAddCompany.Text))
            {
                hasError = true;
                phReferencesAddCompany.Visible = true;
                ucReferencesAddCompany.SetLanguageCode = "LabelRequiredField1";

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbRefernecesAddCompany.ClientID;
                }
            }
            else
            {
                if (Regex.IsMatch(tbRefernecesAddCompany.Text, ContentValidationRegex) == false)
                {
                    hasError = true;
                    phReferencesAddCompany.Visible = true;
                    ucReferencesAddCompany.SetLanguageCode = "ValidateNoHTMLContent";

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbRefernecesAddCompany.ClientID;
                    }
                }
            }
            if (string.IsNullOrEmpty(tbReferencesAddEmail.Text))
            {
                hasError = true;
                phReferencesAddEmailRequiredError.Visible = true;

                if (string.IsNullOrWhiteSpace(controltofocus))
                {
                    controltofocus = tbReferencesAddEmail.ClientID;
                }
            }
            else
            {
                if (Utils.VerifyEmail(tbReferencesAddEmail.Text) == false)
                {
                    hasError = true;
                    phReferencesAddEmailError.Visible = true;

                    if (string.IsNullOrWhiteSpace(controltofocus))
                    {
                        controltofocus = tbReferencesAddEmail.ClientID;
                    }
                }
            }

            if (hasError)
            {
                StandardResetJS();
                UponRequestResetJS();
                OpenAddDiv(hfReferenceAdd.ClientID, controltofocus);

                acReferenceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode");
                newReference.Attributes.Add("class", "profile-edit collapse in");

                return;

            }
            MemberReferences reference = new MemberReferences();

            reference.MemberReferenceName = tbReferencesAddName.Text;
            reference.JobTitle = tbReferencesAddJobTitle.Text;
            reference.Company = tbRefernecesAddCompany.Text;
            reference.Phone = tbReferencesAddPhone.Text;
            reference.ReferenceEmail = tbReferencesAddEmail.Text;

            reference.Relationship = Convert.ToInt32(ddlReferencesAddRelationship.SelectedValue);
            reference.MemberId = SessionData.Member.MemberId;

            MemberReferencesService.Insert(reference);

            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    member.ReferenceUponRequest = false;

                    MembersService.Update(member);
                }
            }

            UpdateMemberLastModified();
            LoadRelationship();

            // Load all references
            LoadReferences();
            /*using (TList<MemberReferences> references = MemberReferencesService.GetByMemberId(SessionData.Member.MemberId))
            {
                rptReferences.DataSource = references;
                rptReferences.DataBind();

                phNavReferences.Visible = (references.Count == 0);
                phTickReferences.Visible = (references.Count > 0);
                phUponRequest.Visible = (references.Count == 0);
                refUponRequest.Checked = (references.Count == 0);
                phAddEntryTextReferences.Visible = (references.Count == 0);
            }*/

            tbReferencesAddName.Text = string.Empty;
            tbReferencesAddJobTitle.Text = string.Empty;
            tbRefernecesAddCompany.Text = string.Empty;
            tbReferencesAddPhone.Text = string.Empty;
            tbReferencesAddEmail.Text = string.Empty;

            ddlReferencesAddRelationship.SelectedIndex = 0;

            StandardResetJS();
            UponRequestResetJS();

            acReferenceAdd.Attributes.Add("class", "section-content new-block-holder edit-mode hidden");
            newReference.Attributes.Add("class", "profile-edit collapse");
            SetMemberPoints();
        }

        #endregion

        #region Custom Questions

        private int SetSupplementaryQuestions(bool onUpdate = false, string tempanswers = "")
        {
            // MemberWizard
            TList<Entities.MemberWizard> memberwizardlist = null;
            using (memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId))
            {

                memberwizardlist.Filter = "GlobalTemplate = false";
                List<CustomQuestion> customquestionlist = new List<CustomQuestion>();
                bool hasError = false;

                if (memberwizardlist.Count > 0)
                {
                    Entities.MemberWizard memberwizard = memberwizardlist[0];
                    string customquestionxml = memberwizard.CustomQuestionsXml;

                    string customquestionanswer = string.Empty;

                    using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
                    {
                        if (member != null)
                        {
                            customquestionanswer = member.ProfileDataXml;
                        }
                    }


                    try
                    {
                        if (phNavCustomQuestions.Visible)
                        {
                            phNavCustomQuestions.Visible = (string.IsNullOrWhiteSpace(customquestionxml));
                            phTickCustomQuestions.Visible = !(string.IsNullOrWhiteSpace(customquestionanswer));
                        }
                        if (!string.IsNullOrWhiteSpace(customquestionxml))
                        {
                            XmlDocument customquestions = new XmlDocument();
                            customquestions.LoadXml(customquestionxml);

                            foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                            {
                                if (questionnode["Status"].InnerXml == "1")
                                {
                                    CustomQuestion question = new CustomQuestion();

                                    question.Id = Convert.ToInt32(questionnode["Id"].InnerXml);
                                    XmlNode languagesnode = questionnode["Languages"];
                                    foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                    {
                                        if (languagenode["Id"].InnerXml == SessionData.Language.LanguageId.ToString())
                                        {
                                            List<string> parameters = new List<string>();

                                            question.Title = HttpUtility.HtmlDecode(languagenode["Title"].InnerXml);
                                            string parametersstring = string.Empty;

                                            XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                            if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                            {
                                                question.Parameters = new List<string>();

                                                foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                                {
                                                    question.Parameters.Add(HttpUtility.HtmlDecode(itemnode.InnerXml.Trim(new char[] { '"' })));
                                                }
                                            }
                                        }
                                    }

                                    question.Type = questionnode["Type"].InnerXml;
                                    question.Sequence = Convert.ToInt32(questionnode["Sequence"].InnerXml);
                                    question.Mandatory = Convert.ToBoolean(questionnode["Mandatory"].InnerXml);
                                    question.Answer = GetCustomQuestionAnswer(customquestionanswer, Convert.ToInt32(question.Id));
                                    question.TempAnswer = GetCustomQuestionAnswer(customquestionanswer, Convert.ToInt32(question.Id));
                                    question.ErrorType = eErrorType.NoError;

                                    if (onUpdate)
                                    {
                                        question.TempAnswer = GetCustomQuestionAnswer(tempanswers, Convert.ToInt32(question.Id));

                                        

                                        if (question.Mandatory && string.IsNullOrWhiteSpace(question.TempAnswer))
                                        {
                                            hasError = true;
                                            question.ErrorType = eErrorType.Missing;
                                        }
                                        else
                                        {
                                            if (question.Type == "textbox" || question.Type == "textarea")
                                            {
                                                if (Regex.IsMatch(question.TempAnswer, ContentValidationRegex) == false)
                                                {
                                                    hasError = true;
                                                    question.ErrorType = eErrorType.InvalidContent;
                                                }
                                            }
                                        }
                                    }

                                    customquestionlist.Add(question);
                                }

                            }


                            if (onUpdate)
                            {
                                StandardResetJS();
                                if (!hasError)
                                {
                                    acCustomQuestions.Attributes.Add("class", "section-content qa-section");
                                    editsupplementaryQuestions.Attributes.Add("class", "profile-edit collapse");

                                    using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
                                    {
                                        if (member != null)
                                        {
                                            member.ProfileDataXml = tempanswers;
                                            MembersService.Update(member);

                                            SetSupplementaryQuestions();
                                            return 0;
                                        }
                                    }
                                }
                                else
                                {
                                    OpenRepeaterDiv(string.Empty, hfCustomQuestions.ClientID);

                                    acCustomQuestions.Attributes.Add("class", "section-content qa-section edit-mode");
                                    editsupplementaryQuestions.Attributes.Add("class", "profile-edit collapse in");
                                }

                            }
                            customquestionlist = customquestionlist.OrderBy(q => q.Sequence).ToList();

                            rptCustomQuestions.DataSource = customquestionlist;
                            rptCustomQuestions.DataBind();

                            rptCustomQuestionsAnswers.DataSource = customquestionlist;
                            rptCustomQuestionsAnswers.DataBind();
                        }
                    }
                    catch { }

                }
            }
            return 0;
        }

        protected void rptCustomQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltQuestion = e.Item.FindControl("ltQuestion") as Literal;
                Literal ltAnswer = e.Item.FindControl("ltAnswer") as Literal;

                CustomQuestion question = e.Item.DataItem as CustomQuestion;
                ltQuestion.Text = HttpUtility.HtmlEncode(question.Title);
                if (question.Type == "textbox" || question.Type == "textarea")
                {
                    ltAnswer.Text = "<p>" + HttpUtility.HtmlEncode(question.Answer).Trim() + "</p>";
                }

                if (question.Type == "dropdown" || question.Type == "radio")
                {
                    for (int i = 0; i < question.Parameters.Count; i++)
                    {
                        if ((i + 1).ToString() == question.Answer)
                        {
                            ltAnswer.Text = "<p>" + HttpUtility.HtmlEncode(question.Parameters[i]).Trim() + "</p>";
                            break;
                        }
                    }
                }

                if (question.Type == "multiselect")
                {
                    foreach (string split in question.Answer.Split(new char[] { ',' }))
                    {
                        for (int i = 0; i < question.Parameters.Count; i++)
                        {
                            if ((i + 1).ToString() == split)
                            {
                                ltAnswer.Text += question.Parameters[i].Trim() + ", ";
                                break;
                            }
                        }
                    }

                    ltAnswer.Text = "<p>" + HttpUtility.HtmlEncode(ltAnswer.Text.TrimEnd(new char[] { ' ', ',' })) + "</p>";
                }

                if (ltAnswer.Text == "<p></p>" || string.IsNullOrWhiteSpace(ltAnswer.Text))
                {
                    ltAnswer.Text = "<p class=\"empty-case_field\">Answer Question</p>";
                }
            }
        }

        private string GetCustomQuestionAnswer(string xml, int questionid)
        {
            string value = string.Empty;

            if (!string.IsNullOrWhiteSpace(xml))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                foreach (XmlNode answernode in xmldoc.GetElementsByTagName("Answer"))
                {
                    if (answernode["Id"].InnerText == questionid.ToString())
                    {
                        value = answernode["Value"].InnerText;
                        break;
                    }
                }
            }

            return value;
        }

        protected void rptCustomQuestionsAnswers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltQuestion = e.Item.FindControl("ltQuestion") as Literal;
                Literal ltAnswer = e.Item.FindControl("ltAnswer") as Literal;
                System.Web.UI.HtmlControls.HtmlGenericControl divInput = e.Item.FindControl("divInput") as System.Web.UI.HtmlControls.HtmlGenericControl;
                PlaceHolder phCustomQuestionError = e.Item.FindControl("phCustomQuestionError") as PlaceHolder;
                ucLanguageLiteral ucCustomQuestionError = e.Item.FindControl("ucCustomQuestionError") as ucLanguageLiteral;

                CustomQuestion question = e.Item.DataItem as CustomQuestion;
                ltQuestion.Text = "<label>" + HttpUtility.HtmlEncode(question.Title);
                if (question.Mandatory)
                {
                    ltQuestion.Text += "<span class=\"form-required\">*</span>";
                }
                ltQuestion.Text += "</label>";

                if (question.ErrorType != eErrorType.NoError)
                {
                    phCustomQuestionError.Visible = true;
                    if (question.ErrorType == eErrorType.Missing)
                    {
                        ucCustomQuestionError.SetLanguageCode = "LabelRequiredField1";
                    }

                    if (question.ErrorType == eErrorType.InvalidContent)
                    {
                        ucCustomQuestionError.SetLanguageCode = "ValidateNoHTMLContent";
                    }

                }

                if (question.Type == "textbox")
                {
                    TextBox tbQuestion = new TextBox();
                    tbQuestion.ID = string.Format("CustomQuestion_{0}_{1}", question.Type, question.Id);
                    tbQuestion.CssClass = "form-control";
                    tbQuestion.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPleaseAnswer"));

                    tbQuestion.Text = question.TempAnswer;
                    divInput.Controls.Add(tbQuestion);
                }

                if (question.Type == "textarea")
                {
                    TextBox tbQuestion = new TextBox();
                    tbQuestion.ID = string.Format("CustomQuestion_{0}_{1}", question.Type, question.Id);
                    tbQuestion.TextMode = TextBoxMode.MultiLine;
                    tbQuestion.Columns = 5;
                    tbQuestion.Rows = 5;
                    tbQuestion.CssClass = "form-control";
                    tbQuestion.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPleaseAnswer"));

                    tbQuestion.Text = question.TempAnswer;
                    divInput.Controls.Add(tbQuestion);
                }

                if (question.Type == "dropdown")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "custom-select");

                    System.Web.UI.HtmlControls.HtmlSelect select = new HtmlSelect();
                    select.ID = string.Format("CustomQuestion_{0}_{1}", question.Type, question.Id);
                    select.Attributes.Add("class", "form-control");
                    int index = 1;
                    foreach (string item in question.Parameters)
                    {
                        ListItem newitem = new ListItem(item, index.ToString());
                        if (index.ToString() == question.TempAnswer)
                        {
                            newitem.Selected = true;
                        }
                        select.Items.Add(newitem);

                        index++;
                    }
                    select.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseOne"), ""));

                    span.Controls.Add(select);
                    divInput.Controls.Add(span);
                }

                if (question.Type == "multiselect")
                {
                    int index = 1;

                    foreach (string item in question.Parameters)
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl label = new HtmlGenericControl("label");
                        System.Web.UI.HtmlControls.HtmlGenericControl text = new HtmlGenericControl();
                        text.InnerText = item;

                        System.Web.UI.HtmlControls.HtmlInputCheckBox checkbox = new HtmlInputCheckBox();
                        checkbox.ID = string.Format("CustomQuestion_{0}_{1}_{2}", question.Type, question.Id, index);
                        checkbox.Value = item;
                        checkbox.Attributes.Add("class", "form-control");

                        label.Attributes.Add("for", checkbox.ClientID);

                        foreach (string split in question.TempAnswer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (index.ToString() == split)
                            {
                                checkbox.Checked = true;
                            }
                        }

                        label.Controls.Add(checkbox);
                        label.Controls.Add(text);

                        divInput.Controls.Add(label);


                        index++;
                    }

                }

                if (question.Type == "radio")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl div = new HtmlGenericControl("div");

                    div.Attributes.Add("class", "btn-group btn-radio-group");

                    int index = 1;
                    foreach (string item in question.Parameters)
                    {
                        System.Web.UI.HtmlControls.HtmlInputRadioButton radio = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                        radio.ID = string.Format("CustomQuestion_{0}_{1}_{2}", question.Type, question.Id, index);

                        if (index.ToString() == question.TempAnswer)
                        {
                            radio.Checked = true;
                        }

                        radio.Value = string.Format("{0}|{1}", question.Id, index);
                        System.Web.UI.HtmlControls.HtmlGenericControl label = new HtmlGenericControl("label");
                        label.Attributes.Add("for", string.Format("ctl00_ContentPlaceHolder1_rptCustomQuestionsAnswers_ctl{0}_", e.Item.ItemIndex.ToString("00")) + radio.ClientID);
                        label.InnerText = item;

                        div.Controls.Add(radio);
                        div.Controls.Add(label);

                        index++;
                    }

                    divInput.Controls.Add(div);
                }
            }
        }

        protected void lbCustomQuestionsSave_Click(object sender, EventArgs e)
        {
            List<CustomQuestionAnswer> customquestionanswers = new List<CustomQuestionAnswer>();

            foreach (string key in Request.Params.AllKeys)
            {
                if (key != null && (key.Contains("CustomQuestion_") || key.Contains("rptCustomQuestionsAnswers")))
                {
                    CustomQuestionAnswer customquestionanswer = new CustomQuestionAnswer();

                    if (key.Contains("textbox"))
                    {
                        string answer = Request.Params[key];
                        string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        string questionid = keysplit[keysplit.Length - 1];

                        customquestionanswer.Id = Convert.ToInt32(questionid);
                        customquestionanswer.Type = "textbox";
                        customquestionanswer.Value = answer;

                        customquestionanswers.Add(customquestionanswer);
                    }
                    else if (key.Contains("textarea"))
                    {
                        string answer = Request.Params[key];
                        string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        string questionid = keysplit[keysplit.Length - 1];

                        customquestionanswer.Id = Convert.ToInt32(questionid);
                        customquestionanswer.Type = "textarea";
                        customquestionanswer.Value = answer;

                        customquestionanswers.Add(customquestionanswer);
                    }
                    else if (key.Contains("dropdown"))
                    {
                        string answer = Request.Params[key];
                        string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        string questionid = keysplit[keysplit.Length - 1];

                        if (!string.IsNullOrWhiteSpace(answer))
                        {
                            customquestionanswer.Id = Convert.ToInt32(questionid);
                            customquestionanswer.Type = "dropdown";
                            customquestionanswer.Value = answer;

                            customquestionanswers.Add(customquestionanswer);
                        }
                    }
                    else
                    {
                        if (key.Contains("multiselect"))
                        {
                            string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            string questionid = keysplit[keysplit.Length - 2];
                            string answer = keysplit[keysplit.Length - 1];

                            // check if multiselect exists
                            bool found = false;
                            foreach (CustomQuestionAnswer ans in customquestionanswers)
                            {
                                if (ans.Id.ToString() == questionid)
                                {
                                    ans.Value += "," + answer;

                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                customquestionanswer.Id = Convert.ToInt32(questionid);
                                customquestionanswer.Type = "multiselect";
                                customquestionanswer.Value = answer;

                                customquestionanswers.Add(customquestionanswer);
                            }
                        }
                        else
                        {
                            // radio
                            string answer = Request.Params[key];
                            string[] ansplit = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            string questionid = ansplit[0];
                            string index = ansplit[1];

                            customquestionanswer.Id = Convert.ToInt32(questionid);
                            customquestionanswer.Type = "radio";
                            customquestionanswer.Value = index;

                            customquestionanswers.Add(customquestionanswer);
                        }

                    }
                }
            }

            // Construct Answer XML
            StringBuilder sbAnswer = new StringBuilder();

            if (customquestionanswers.Count > 0)
            {
                sbAnswer.AppendLine("<Answers>");

                foreach (CustomQuestionAnswer answer in customquestionanswers)
                {
                    sbAnswer.AppendFormat(@"<Answer>
                                                <Id>{0}</Id>
                                                <Type>{1}</Type>
                                                <Value>{2}</Value>
                                            </Answer>", answer.Id, answer.Type, Utils.XmlEncode(answer.Value));
                }

                sbAnswer.AppendLine("</Answers>");
            }

            SetSupplementaryQuestions(true, sbAnswer.ToString());

        }

        #endregion

        #region PDF / Profile Submit

        protected void PDFGetButton_Click(object sender, EventArgs e)
        {
            //define full virtual path
            var fullPath = "~/usercontrols/member/ucCVProfileDownload.ascx";

            //initialize a new page to host the control
            Page page = new Page();
            //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
            page.EnableEventValidation = false;

            //load the control and add it to the page's form
            JXTPortal.Website.usercontrols.member.ucCVProfileDownload control = (JXTPortal.Website.usercontrols.member.ucCVProfileDownload)page.LoadControl(fullPath);
            control.Setup(SessionData.Member.MemberId);
            page.Controls.Add(control);

            //call RenderControl method to get the generated HTML
            string html = RenderControl(page);

            byte[] file = new PDFCreator().ConvertHTMLToPDF(html);

            Response.AddHeader("content-disposition", @"attachment;filename=""MyFile.pdf""");

            Response.OutputStream.Write(file, 0, file.Length);
            Response.ContentType = "application/pdf";
            Response.End();


        }

        #endregion

        #region UI

        private void AssignInputPlaceHolders()
        {
            //My Personal Details
            tbDetailsSecondaryEmail.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelSecondaryEmail"));
            tbDetailsHomePhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhoneHome"));
            tbDetailsMobilePhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhoneMobile"));
            tbDetailsAddress1.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelStreetAddress1"));
            tbDetailsAddress2.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelStreetAddress2"));
            tbDetailsSuburb.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityTown"));
            tbDetailsState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelState"));
            tbDetailsPostcode.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPostcode"));
            tbDetailsVideoURL.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelVideoURL"));
            tbDetailsPassportNumber.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPassportNumber"));

            tbDetailsMailingAddress1.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelStreetAddress1"));
            tbDetailsMailingAddress2.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelStreetAddress2"));
            tbDetailsMailingSuburb.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityTown"));
            tbDetailsMailingState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelState"));
            tbDetailsMailingPostcode.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPostcode"));


            //Directorship
            tbDirectorshipAddJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
            tbDirectorshipAddCompanyName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOrganisationName"));
            tbDirectorshipAddWebsite.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOrganisationWebsite"));

            //work experience
            tbExperienceAddCompanyName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCompanyName"));
            tbExperienceAddJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
            tbExperienceAddCity.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityTown"));
            tbExperienceAddState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelState"));
            tbExperienceAddDescription.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelDescriptionHere"));

            //Education
            tbEducationAddInstitute.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelInstitutionName"));
            tbEducationAddState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityState"));
            tbEducationAddQualificationName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelQualificationName"));
            tbEducationAddOtherQualification.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelOtherQualification"));

            //Skills
            tbSkillsAddSkill.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelSkills"));

            //Cert & membership
            tbCertificateAddCertificateMembershipName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEditCertificationsMembershipName"));
            tbCertificateAddAuthority.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelAuthority"));
            tbCertificateAddMembershipNumber.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCertificateMembershipNumber"));
            tbCertificateAddURL.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCertificationURL"));

            //License
            tbLicenseAddName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelLicenseName"));
            tbLicenseAddType.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelLicenseType"));
            tbLicenseAddState.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCityState"));

            //Role Pref
            tbRolePreferenceSalaryMin.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMin"));
            tbRolePreferenceSalaryMax.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMax"));

            //Cover letter
            tbCoverLetterTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelTitle"));
            tbCustomCoverLetter.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCustomCoverLetter"));

            //language
            tbLanguageName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEnterLanguage"));

            //References
            tbReferencesAddName.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelName"));
            tbReferencesAddJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelJobTitle"));
            tbRefernecesAddCompany.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCompany"));
            tbReferencesAddPhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhone"));
            tbReferencesAddEmail.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEmail"));

            //Assign Other Language stuffs here
            validatorHomePhone.ErrorMessage = CommonFunction.GetResourceValue(validatorHomePhone.ErrorMessage);
            validatorMobilePhone.ErrorMessage = CommonFunction.GetResourceValue(validatorMobilePhone.ErrorMessage);

            // Content Checking
            revHomePhone.ValidationExpression = ContentValidationRegex;
            revHomePhone.ErrorMessage = CommonFunction.GetResourceValue(revHomePhone.ErrorMessage);

            revMobilePhone.ValidationExpression = ContentValidationRegex;
            revMobilePhone.ErrorMessage = CommonFunction.GetResourceValue(revMobilePhone.ErrorMessage);

            revAddress1.ValidationExpression = ContentValidationRegex;
            revAddress1.ErrorMessage = CommonFunction.GetResourceValue(revAddress1.ErrorMessage);

            revAddress2.ValidationExpression = ContentValidationRegex;
            revAddress2.ErrorMessage = CommonFunction.GetResourceValue(revAddress2.ErrorMessage);

            revSuburb.ValidationExpression = ContentValidationRegex;
            revSuburb.ErrorMessage = CommonFunction.GetResourceValue(revSuburb.ErrorMessage);

            revState.ValidationExpression = ContentValidationRegex;
            revState.ErrorMessage = CommonFunction.GetResourceValue(revState.ErrorMessage);

            revPostcode.ValidationExpression = ContentValidationRegex;
            revPostcode.ErrorMessage = CommonFunction.GetResourceValue(revPostcode.ErrorMessage);

            revVideoURL.ValidationExpression = ContentValidationRegex;
            revVideoURL.ErrorMessage = CommonFunction.GetResourceValue(revVideoURL.ErrorMessage);

            revPassportNumber.ValidationExpression = ContentValidationRegex;
            revPassportNumber.ErrorMessage = CommonFunction.GetResourceValue(revPassportNumber.ErrorMessage);

            revMailingAddress1.ValidationExpression = ContentValidationRegex;
            revMailingAddress1.ErrorMessage = CommonFunction.GetResourceValue(revMailingAddress1.ErrorMessage);

            revMailingAddress2.ValidationExpression = ContentValidationRegex;
            revMailingAddress2.ErrorMessage = CommonFunction.GetResourceValue(revMailingAddress2.ErrorMessage);

            revMailingState.ValidationExpression = ContentValidationRegex;
            revMailingState.ErrorMessage = CommonFunction.GetResourceValue(revMailingState.ErrorMessage);

            revMailingSuburb.ValidationExpression = ContentValidationRegex;
            revMailingSuburb.ErrorMessage = CommonFunction.GetResourceValue(revMailingSuburb.ErrorMessage);

            revMailingPostcode.ValidationExpression = ContentValidationRegex;
            revMailingPostcode.ErrorMessage = CommonFunction.GetResourceValue(revMailingPostcode.ErrorMessage);

        }

        private void LoadCountry()
        {
            CountryList = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

            if (CountryList != null)
            {
                CountryList = CountryList.Where(c => c.Sequence != -1 && c.Abbr != "CC").OrderBy(c => c.CountryName).ToList();

            }
        }

        private void LoadLocation()
        {
            LocationList = new List<Entities.Location>();

            ddlRolePreferenceDesiredLocation.Items.Clear();
            TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId);

            foreach (Entities.SiteCountries country in sitecountries)
            {
                List<Entities.SiteLocation> locations = SiteLocationService.GetTranslatedLocationsByCountryID(country.CountryId, SessionData.Language.LanguageId);

                if (locations.Count > 0)
                {
                    ddlRolePreferenceDesiredLocation.AddItemGroup(CountriesService.GetTranslatedCountry(country.CountryId, SessionData.Language.LanguageId).CountryName);
                }

                foreach (Entities.SiteLocation location in locations)
                {
                    ddlRolePreferenceDesiredLocation.Items.Add(new ListItem(location.SiteLocationName, location.LocationId.ToString()));
                }
            }

            ddlRolePreferenceDesiredLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelChooseOne"), "0"));
            ddlRolePreferenceDesiredLocation.Items[0].Attributes.Add("disabled", "");

        }

        private void LoadCalendar()
        {
            DayList = new List<ListItem>();
            for (int i = 1; i <= 31; i++)
            {
                DayList.Add(new ListItem(i.ToString(), i.ToString()));
            }

            MonthList = new List<ListItem>();
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelJan"), "1"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelFeb"), "2"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMar"), "3"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelApr"), "4"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelMay"), "5"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelJun"), "6"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelJul"), "7"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelAug"), "8"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelSep"), "9"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelOct"), "10"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelNov"), "11"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelDec"), "12"));

            YearList = new List<ListItem>();
            int year = 0;
            for (int i = 0; i < 100; i++)
            {
                year = DateTime.Now.Year - i;
                YearList.Add(new ListItem(year.ToString(), year.ToString()));
            }
            FutureYearList = new List<ListItem>();
            year = 0;
            for (int i = 2050; i > 1950; i--)
            {
                year = i;
                FutureYearList.Add(new ListItem(year.ToString(), year.ToString()));
            }
        }

        private void SkillsAutoCompleteJS(bool isInit)
        {
            if (isInit)
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.Skills))
                        {
                            string[] split = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"$(document).ready(function() { var availableSkills = " + jsArray + @"; $( ""#tbSkillsAddSkill"" ).autocomplete({ source: availableSkills }); });";

                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "SkillsAutocomplete", scriptText, true);
                        }
                    }
                }
            }
            else
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.Skills))
                        {
                            string[] split = objMW.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"var availableSkills = " + jsArray + @"; $( ""#tbSkillsAddSkill"" ).autocomplete({ source: availableSkills });";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "SkillsAutocomplete", scriptText, true);
                        }
                    }
                }
            }
        }

        private void LicenseTypesAutoCompleteJS(bool isInit)
        {
            if (isInit)
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.LicenseTypes))
                        {
                            string[] split = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"$(document).ready(function() { var availableLicenseTypes = " + jsArray + @"; $( "".licenseTypeAutocomplete"" ).autocomplete({ source: availableLicenseTypes }); });";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "LicenseTypesAutocomplete", scriptText, true);
                        }
                    }
                }
            }
            else
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.LicenseTypes))
                        {
                            string[] split = objMW.LicenseTypes.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"var availableLicenseTypes = " + jsArray + @"; $( "".licenseTypeAutocomplete"" ).autocomplete({ source: availableLicenseTypes });";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "LicenseTypesAutocomplete", scriptText, true);
                        }
                    }
                }
            }
        }

        private void QualificationNamesAutoCompleteJS(bool isInit)
        {
            if (isInit)
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.QualificationNames))
                        {
                            string[] split = objMW.QualificationNames.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"$(document).ready(function() { var availableQualificationNames = " + jsArray + @"; $( "".QualificationNameAutocomplete"" ).autocomplete({ source: availableQualificationNames }); });";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "QualificationNameAutocomplete", scriptText, true);
                        }
                    }
                }
            }
            else
            {
                using (JXTPortal.Entities.MemberWizard objMW = MemberWizardService.GetMemberWizardBySite(SessionData.Site.SiteId))
                {
                    if (objMW != null)
                    {
                        if (!string.IsNullOrEmpty(objMW.QualificationNames))
                        {
                            string[] split = objMW.QualificationNames.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                            split = split.OrderBy(c => c).Select(c => "unescape('" + HttpUtility.HtmlEncode(c) + "')").ToArray();

                            string jsArray = "[ " + string.Join(", ", split) + "]";

                            String scriptText = @"var availableQualificationNames = " + jsArray + @"; $( "".QualificationNameAutocomplete"" ).autocomplete({ source: availableQualificationNames });";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "QualificationNameAutocomplete", scriptText, true);
                        }
                    }
                }
            }
        }

        private void AssignSectionTitle(JXTPortal.Entities.MemberWizard memberWizard)
        {
            string strProfile = memberWizard.ProfileTitle;
            string strSummary = memberWizard.SummaryTitle;
            string strPersonalDetails = memberWizard.PersonalDetailsTitle;
            string strDirectorship = memberWizard.DirectorshipTitle;
            string strExperience = memberWizard.ExperienceTitle;
            string strEducation = memberWizard.EducationTitle;
            string strSkills = memberWizard.SkillsTitle;
            string strMemberships = memberWizard.MembershipsTitle;
            string strLicenses = memberWizard.LicensesTitle;
            string strRolePreferences = memberWizard.RolePreferencesTitle;
            string strCv = memberWizard.CvTitle;
            string strAttachCoverLetter = memberWizard.AttachCoverLetterTitle;
            string strLanguages = memberWizard.LanguagesTitle;
            string strReferences = memberWizard.ReferencesTitle;
            string strCustomQuestion = memberWizard.CustomQuestionTitle;
            string strSummaryInfo = string.Empty;
            string strPersonalDetailsInfo = string.Empty;
            string strDirectorshipInfo = string.Empty;
            string strExperienceInfo = string.Empty;
            string strEducationInfo = string.Empty;
            string strSkillsInfo = string.Empty;
            string strMembershipsInfo = string.Empty;
            string strLicensesInfo = string.Empty;
            string strRolePreferencesInfo = string.Empty;
            string strCvInfo = string.Empty;
            string strAttachCoverLetterInfo = string.Empty;
            string strLanguagesInfo = string.Empty;
            string strReferencesInfo = string.Empty;
            string strCustomQuestionInfo = string.Empty;


            if (memberWizard != null)
            {
                if (!string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(memberWizard.WizardLanguageXml);

                    XmlNode infonode = xmldoc.SelectSingleNode("MemberWizards/Info");
                    if (infonode != null)
                    {
                        XmlNode cvnode = infonode.SelectSingleNode("CV");
                        if (cvnode != null && !string.IsNullOrWhiteSpace(cvnode.InnerText))
                        { strCvInfo = cvnode.InnerText; }
                        XmlNode rolepreferencesnode = infonode.SelectSingleNode("RolePreferences");
                        if (rolepreferencesnode != null && !string.IsNullOrWhiteSpace(rolepreferencesnode.InnerText))
                        { strRolePreferencesInfo = rolepreferencesnode.InnerText; }
                        XmlNode educationnode = infonode.SelectSingleNode("Education");
                        if (educationnode != null && !string.IsNullOrWhiteSpace(educationnode.InnerText))
                        { strEducationInfo = educationnode.InnerText; }
                        XmlNode membershipsnode = infonode.SelectSingleNode("Memberships");
                        if (membershipsnode != null && !string.IsNullOrWhiteSpace(membershipsnode.InnerText))
                        { strMembershipsInfo = membershipsnode.InnerText; }
                        XmlNode experiencenode = infonode.SelectSingleNode("Experience");
                        if (experiencenode != null && !string.IsNullOrWhiteSpace(experiencenode.InnerText))
                        { strExperienceInfo = experiencenode.InnerText; }
                        XmlNode skillsnode = infonode.SelectSingleNode("Skills");
                        if (skillsnode != null && !string.IsNullOrWhiteSpace(skillsnode.InnerText))
                        { strSkillsInfo = skillsnode.InnerText; }
                        XmlNode directorshipnode = infonode.SelectSingleNode("Directorship");
                        if (directorshipnode != null && !string.IsNullOrWhiteSpace(directorshipnode.InnerText))
                        { strDirectorshipInfo = directorshipnode.InnerText; }
                        XmlNode summarynode = infonode.SelectSingleNode("Summary");
                        if (summarynode != null && !string.IsNullOrWhiteSpace(summarynode.InnerText))
                        { strSummaryInfo = summarynode.InnerText; }
                        XmlNode personaldetailsnode = infonode.SelectSingleNode("PersonalDetails");
                        if (personaldetailsnode != null && !string.IsNullOrWhiteSpace(personaldetailsnode.InnerText))
                        { strPersonalDetailsInfo = personaldetailsnode.InnerText; }
                        XmlNode licensesnode = infonode.SelectSingleNode("Licenses");
                        if (licensesnode != null && !string.IsNullOrWhiteSpace(licensesnode.InnerText))
                        { strLicensesInfo = licensesnode.InnerText; }
                        XmlNode attachcoverletternode = infonode.SelectSingleNode("AttachCoverLetter");
                        if (attachcoverletternode != null && !string.IsNullOrWhiteSpace(attachcoverletternode.InnerText))
                        { strAttachCoverLetterInfo = attachcoverletternode.InnerText; }
                        XmlNode languagesnode = infonode.SelectSingleNode("Languages");
                        if (languagesnode != null && !string.IsNullOrWhiteSpace(languagesnode.InnerText))
                        { strLanguagesInfo = languagesnode.InnerText; }
                        XmlNode referencesnode = infonode.SelectSingleNode("References");
                        if (referencesnode != null && !string.IsNullOrWhiteSpace(referencesnode.InnerText))
                        { strReferencesInfo = referencesnode.InnerText; }
                        XmlNode customquestionnode = infonode.SelectSingleNode("CustomQuestion");
                        if (customquestionnode != null && !string.IsNullOrWhiteSpace(customquestionnode.InnerText))
                        { strCustomQuestionInfo = customquestionnode.InnerText; }
                    }

                    foreach (XmlNode xmlnode in xmldoc.SelectNodes("MemberWizards/MemberWizard"))
                    {
                        XmlNode langnode = xmlnode.SelectSingleNode("LanguageID");
                        if (langnode != null && SessionData.Language.LanguageId == Convert.ToInt32(langnode.InnerText))
                        {
                            XmlNode profilenode = xmlnode.SelectSingleNode("Profile");
                            if (profilenode != null && !string.IsNullOrWhiteSpace(profilenode.InnerText))
                            { strProfile = profilenode.InnerText; }
                            XmlNode cvnode = xmlnode.SelectSingleNode("CV");
                            if (cvnode != null && !string.IsNullOrWhiteSpace(cvnode.InnerText))
                            { strCv = cvnode.InnerText; }
                            XmlNode rolepreferencesnode = xmlnode.SelectSingleNode("RolePreferences");
                            if (rolepreferencesnode != null && !string.IsNullOrWhiteSpace(rolepreferencesnode.InnerText))
                            { strRolePreferences = rolepreferencesnode.InnerText; }
                            XmlNode educationnode = xmlnode.SelectSingleNode("Education");
                            if (educationnode != null && !string.IsNullOrWhiteSpace(educationnode.InnerText))
                            { strEducation = educationnode.InnerText; }
                            XmlNode membershipsnode = xmlnode.SelectSingleNode("Memberships");
                            if (membershipsnode != null && !string.IsNullOrWhiteSpace(membershipsnode.InnerText))
                            { strMemberships = membershipsnode.InnerText; }
                            XmlNode experiencenode = xmlnode.SelectSingleNode("Experience");
                            if (experiencenode != null && !string.IsNullOrWhiteSpace(experiencenode.InnerText))
                            { strExperience = experiencenode.InnerText; }
                            XmlNode skillsnode = xmlnode.SelectSingleNode("Skills");
                            if (skillsnode != null && !string.IsNullOrWhiteSpace(skillsnode.InnerText))
                            { strSkills = skillsnode.InnerText; }
                            XmlNode directorshipnode = xmlnode.SelectSingleNode("Directorship");
                            if (directorshipnode != null && !string.IsNullOrWhiteSpace(directorshipnode.InnerText))
                            { strDirectorship = directorshipnode.InnerText; }
                            XmlNode summarynode = xmlnode.SelectSingleNode("Summary");
                            if (summarynode != null && !string.IsNullOrWhiteSpace(summarynode.InnerText))
                            { strSummary = summarynode.InnerText; }
                            XmlNode personaldetailsnode = xmlnode.SelectSingleNode("PersonalDetails");
                            if (personaldetailsnode != null && !string.IsNullOrWhiteSpace(personaldetailsnode.InnerText))
                            { strPersonalDetails = personaldetailsnode.InnerText; }
                            XmlNode licensesnode = xmlnode.SelectSingleNode("Licenses");
                            if (licensesnode != null && !string.IsNullOrWhiteSpace(licensesnode.InnerText))
                            { strLicenses = licensesnode.InnerText; }
                            XmlNode attachcoverletternode = xmlnode.SelectSingleNode("AttachCoverLetter");
                            if (attachcoverletternode != null && !string.IsNullOrWhiteSpace(attachcoverletternode.InnerText))
                            { strAttachCoverLetter = attachcoverletternode.InnerText; }
                            XmlNode languagesnode = xmlnode.SelectSingleNode("Languages");
                            if (languagesnode != null && !string.IsNullOrWhiteSpace(languagesnode.InnerText))
                            { strLanguages = languagesnode.InnerText; }
                            XmlNode referencesnode = xmlnode.SelectSingleNode("References");
                            if (referencesnode != null && !string.IsNullOrWhiteSpace(referencesnode.InnerText))
                            { strReferences = referencesnode.InnerText; }
                            XmlNode customquestionnode = xmlnode.SelectSingleNode("CustomQuestion");
                            if (customquestionnode != null && !string.IsNullOrWhiteSpace(customquestionnode.InnerText))
                            { strCustomQuestion = customquestionnode.InnerText; }
                            XmlNode cvnodeInfo = xmlnode.SelectSingleNode("CVInfo");
                            if (cvnodeInfo != null)
                            { strCvInfo = cvnodeInfo.InnerText; }
                            XmlNode rolepreferencesnodeInfo = xmlnode.SelectSingleNode("RolePreferencesInfo");
                            if (rolepreferencesnodeInfo != null)
                            { strRolePreferencesInfo = rolepreferencesnodeInfo.InnerText; }
                            XmlNode educationnodeInfo = xmlnode.SelectSingleNode("EducationInfo");
                            if (educationnodeInfo != null)
                            { strEducationInfo = educationnodeInfo.InnerText; }
                            XmlNode membershipsnodeInfo = xmlnode.SelectSingleNode("MembershipsInfo");
                            if (membershipsnodeInfo != null)
                            { strMembershipsInfo = membershipsnodeInfo.InnerText; }
                            XmlNode experiencenodeInfo = xmlnode.SelectSingleNode("ExperienceInfo");
                            if (experiencenodeInfo != null)
                            { strExperienceInfo = experiencenodeInfo.InnerText; }
                            XmlNode skillsnodeInfo = xmlnode.SelectSingleNode("SkillsInfo");
                            if (skillsnodeInfo != null)
                            { strSkillsInfo = skillsnodeInfo.InnerText; }
                            XmlNode directorshipnodeInfo = xmlnode.SelectSingleNode("DirectorshipInfo");
                            if (directorshipnodeInfo != null)
                            { strDirectorshipInfo = directorshipnodeInfo.InnerText; }
                            XmlNode summarynodeInfo = xmlnode.SelectSingleNode("SummaryInfo");
                            if (summarynodeInfo != null)
                            { strSummaryInfo = summarynodeInfo.InnerText; }
                            XmlNode personaldetailsnodeInfo = xmlnode.SelectSingleNode("PersonalDetailsInfo");
                            if (personaldetailsnodeInfo != null)
                            { strPersonalDetailsInfo = personaldetailsnodeInfo.InnerText; }
                            XmlNode licensesnodeInfo = xmlnode.SelectSingleNode("LicensesInfo");
                            if (licensesnodeInfo != null)
                            { strLicensesInfo = licensesnodeInfo.InnerText; }
                            XmlNode attachcoverletternodeInfo = xmlnode.SelectSingleNode("AttachCoverLetterInfo");
                            if (attachcoverletternodeInfo != null)
                            { strAttachCoverLetterInfo = attachcoverletternodeInfo.InnerText; }
                            XmlNode languagesnodeInfo = xmlnode.SelectSingleNode("LanguagesInfo");
                            if (languagesnodeInfo != null)
                            { strLanguagesInfo = languagesnodeInfo.InnerText; }
                            XmlNode referencesnodeInfo = xmlnode.SelectSingleNode("ReferencesInfo");
                            if (referencesnodeInfo != null)
                            { strReferencesInfo = referencesnodeInfo.InnerText; }
                            XmlNode customquestionnodeInfo = xmlnode.SelectSingleNode("CustomQuestionInfo");
                            if (customquestionnodeInfo != null)
                            { strCustomQuestionInfo = customquestionnodeInfo.InnerText; }
                        }
                    }
                }
            }

            ltTitleProfile.Text = HttpUtility.HtmlEncode(strProfile);
            ltTitleSummary.Text = HttpUtility.HtmlEncode(strSummary);
            ltTitleMyPersonalDetails.Text = HttpUtility.HtmlEncode(strPersonalDetails);
            ltTitleDirectorship.Text = HttpUtility.HtmlEncode(strDirectorship);
            ltTitleExperience.Text = HttpUtility.HtmlEncode(strExperience);
            ltTitleEducation.Text = HttpUtility.HtmlEncode(strEducation);
            ltTitleSkills.Text = HttpUtility.HtmlEncode(strSkills);
            ltTitleCertification.Text = HttpUtility.HtmlEncode(strMemberships);
            ltTitleLicenses.Text = HttpUtility.HtmlEncode(strLicenses);
            ltTitleRolePreferences.Text = HttpUtility.HtmlEncode(strRolePreferences);
            ltRolePreferencesEditTitle.Text = HttpUtility.HtmlEncode(strRolePreferences);
            ltTitleResume.Text = HttpUtility.HtmlEncode(strCv);
            ltTitleCoverLetter.Text = HttpUtility.HtmlEncode(strAttachCoverLetter);
            ltTitleLanguage.Text = HttpUtility.HtmlEncode(strLanguages);
            ltTitleReferences.Text = HttpUtility.HtmlEncode(strReferences);
            ltTitleCustomQuestions.Text = HttpUtility.HtmlEncode(strCustomQuestion);
            ltTitleCustomQuestionsEdit.Text = HttpUtility.HtmlEncode(strCustomQuestion);

            ucAttachCoverLetter.Text = HttpUtility.HtmlEncode(strAttachCoverLetter);
            ucAttachResume.Text = HttpUtility.HtmlEncode(strCv);

            ltNavSummary.Text = HttpUtility.HtmlEncode(strSummary);
            ltNavDirectorship.Text = HttpUtility.HtmlEncode(strDirectorship);
            ltNavWorkExperience.Text = HttpUtility.HtmlEncode(strExperience);
            ltNavEducation.Text = HttpUtility.HtmlEncode(strEducation);
            ltNavSkills.Text = HttpUtility.HtmlEncode(strSkills);
            ltNavCertification.Text = HttpUtility.HtmlEncode(strMemberships);
            ltNavLicenses.Text = HttpUtility.HtmlEncode(strLicenses);
            ltNavRolePreferences.Text = HttpUtility.HtmlEncode(strRolePreferences);
            ltNavResume.Text = HttpUtility.HtmlEncode(strCv);
            ltNavCoverLetter.Text = HttpUtility.HtmlEncode(strAttachCoverLetter);
            ltNavLanguages.Text = HttpUtility.HtmlEncode(strLanguages);
            ltNavReferences.Text = HttpUtility.HtmlEncode(strReferences);
            ltNavCustomQuestions.Text = HttpUtility.HtmlEncode(strCustomQuestion);

            if (!string.IsNullOrWhiteSpace(strSummaryInfo)) summaryInfo.Attributes.Add("title", strSummaryInfo);
            if (!string.IsNullOrWhiteSpace(strPersonalDetailsInfo)) personalDetailsInfo.Attributes.Add("title", strPersonalDetailsInfo);
            if (!string.IsNullOrWhiteSpace(strCvInfo)) resumeInfo.Attributes.Add("title", strCvInfo);
            if (!string.IsNullOrWhiteSpace(strAttachCoverLetterInfo)) coverLetterInfo.Attributes.Add("title", strAttachCoverLetterInfo);
            if (!string.IsNullOrWhiteSpace(strDirectorshipInfo)) directorshipInfo.Attributes.Add("title", strDirectorshipInfo);
            if (!string.IsNullOrWhiteSpace(strExperienceInfo)) experienceInfo.Attributes.Add("title", strExperienceInfo);
            if (!string.IsNullOrWhiteSpace(strEducationInfo)) educationInfo.Attributes.Add("title", strEducationInfo);
            if (!string.IsNullOrWhiteSpace(strSkillsInfo)) skillsInfo.Attributes.Add("title", strSkillsInfo);
            if (!string.IsNullOrWhiteSpace(strMembershipsInfo)) certificationInfo.Attributes.Add("title", strMembershipsInfo);
            if (!string.IsNullOrWhiteSpace(strLicensesInfo)) licenseInfo.Attributes.Add("title", strLicensesInfo);
            if (!string.IsNullOrWhiteSpace(strRolePreferencesInfo)) rolePrefenceInfo.Attributes.Add("title", strRolePreferencesInfo);
            if (!string.IsNullOrWhiteSpace(strLanguagesInfo)) languageInfo.Attributes.Add("title", strLanguagesInfo);
            if (!string.IsNullOrWhiteSpace(strReferencesInfo)) referencesInfo.Attributes.Add("title", strReferencesInfo);
            if (!string.IsNullOrWhiteSpace(strCustomQuestionInfo)) customQuestionInfo.Attributes.Add("title", strCustomQuestionInfo);
        }

        private void SetMemberPoints()
        {
            // Set the member points
            int? memberPoints = 0;
            MemberWizardService.CustomGetMemberPoints(SessionData.Site.SiteId, SessionData.Member.MemberId, ref memberPoints);

            if (memberPoints.HasValue)
            {
                ltProfileProgress.Text = memberPoints.Value.ToString();
                ltProfileLevel.Text = GetMemberProfilePercentageLabel(memberPoints.Value);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ProgressReset", @"
                    <script type='text/javascript'>
                    $(document).ready(function() {
                            $('.status').html(""" + memberPoints.Value.ToString() + @""");
                            var pro_status = $.trim($('.status').html());
		                    var pro_wrap_height = $("".profile-status-wrap"").height();
		                    //console.log(pro_wrap_height);
		                    var px_height = parseInt((pro_status / 100) * pro_wrap_height);
		                    $("".profile-status"").stop().animate({ height: px_height }, 2000);
		                    $("".profile_status_info"").stop().animate({ bottom: px_height - 1 }, 2000);
                            if( px_height > pro_wrap_height - 15  ){
                                $("".profile_status_info"").addClass('info-btm');
                        }
                    });
                    </script>
                    ", false);

                phIncompletedSectionHeading.Visible = memberPoints.Value < 100;

            }


        }

        private void OpenAddDiv(string divid, string controltofocus)
        {
            if (!string.IsNullOrEmpty(divid))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "OpenAddDiv", @"
            <script type='text/javascript'>
            $(document).ready(function() {
                $('.section-content:not(.new-block-holder) .profile-edit').removeClass('in').addClass('collapse');
		        $('.section-content:not(.new-block-holder)').removeClass('edit-mode');

		        var addBlockID = $('#" + divid + @"').attr('href');
		        if( !$(addBlockID).is(':visible') ){
			        $(addBlockID).parent().removeClass('hidden');
			        $(addBlockID)
				        .removeAttr('style')
				        .slideDown(300 , function(){
					        $('#" + divid + @"')
					        .addClass('in')
					        .removeAttr('style');
				        })
				        .parent().addClass('edit-mode');	
			
			        //scroll new block to visible area of screen
			        $('body,html').animate({
					        scrollTop: $(addBlockID).height()>$(window).height()/1.5? $(addBlockID).offset().top : $(addBlockID).offset().top - 200
				        },300);
				    }
		        });
            </script>
            ", false);
            }

            if (!string.IsNullOrWhiteSpace(controltofocus))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "OpenAddDivFocus", @"
                <script type='text/javascript'>
                $(document).ready(function() {
                    $('#" + controltofocus + @"').focus();        
                    $('html, body').animate({
                          scrollTop: $('#" + controltofocus + @"').height()>$(window).height()/1.5? $('#" + controltofocus + @"').offset().top : $('#" + controltofocus + @"').offset().top - 200
                        }, 300);  
		            });
                </script>
                ", false);
            }
        }

        private void OpenRepeaterDiv(string divid, string controltofocus)
        {
            if (!string.IsNullOrEmpty(divid))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "OpenRepeaterDiv", @"
            <script type='text/javascript'>
                $(document).ready(function() {
                    var editbtn = document.getElementById('" + divid + @"');
                    editbtn.click();
		        });
            </script>
            ", false);
            }

            if (!string.IsNullOrWhiteSpace(controltofocus))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenRepeaterDivFocus", @"
                <script type='text/javascript'>
                $(document).ready(function() {
                    $('#" + controltofocus + @"').focus();
                    $('html, body').animate({
                          scrollTop: $('#" + controltofocus + @"').height()>$(window).height()/1.5? $('#" + controltofocus + @"').offset().top : $('#" + controltofocus + @"').offset().top - 200
                        }, 300);  
		            });
                </script>
                ", false);
            }


        }

        private void StandardResetJS()
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Reset", @"

           $('#content').removeClass('col-sm-8 col-md-9');
		    /* scroll bar on summary section*/
	        //run jscrollpane only if there is summary class element
	        if( $('.summary').length ){	
		        $('.summary').jScrollPane();
		        $( window ).resize(function() {
			        $('.summary').jScrollPane();
		        });
	        }

	        $('.fa-edit').on('click', function(){
		        $(this).parents('.section-content').addClass('edit-mode');
		        var editBlockId = $(this).attr('href');
		        //close other edit-mode sections if any
		        $('.profile-edit').not($(this).parents('.section-content').find('.profile-edit')).removeClass('in').addClass('collapse');
		        $('.fa-edit').not(this).parents('.section-content').removeClass('edit-mode');
		        $('.new-block-holder').addClass('hidden').find('.profile-edit').removeClass('in').addClass('collapse');

		        //only for personal details section
		        if( editBlockId == ""#personalDetails-form"" ){
			        $('body,html').animate({
				        scrollTop: $(this).offset().top + $(this).height()
			        },300);
		        }
	        });

	        $('.close-btn, .cancel-btn').on( 'click', function(){
		        var closeBlockID;
		        if($(this).parents('.new-block-holder').length)
		        {	
			        var temp = $(this).attr('href');
			        closeBlockID = $(temp).parents("".form-section"");
		        }
		        else
		        {
			        var temp = $(this).attr('href');
			        closeBlockID = $(temp).parent();
		        }
		        //scroll new block to visible area of screen
			        $('body,html').animate({
					        scrollTop: $(closeBlockID).offset().top - $(""header"").height()
				        },300);
		        // for add new section only
		        if( $(this).parents('.new-block-holder').find('.profile-edit').is(':visible') ){
			        $(this).parents('.new-block-holder').find('.profile-edit').slideUp(300,function(){
				        $(this).parents('.new-block-holder').addClass('hidden');	
				        $(this).removeClass('in').addClass('collapse');
			        });
			        return false;
		        }
		        $(this).parents('.section-content').removeClass('edit-mode');
	        });

          $('.add-btn, .edit-resume').on( 'click', function(e){
		    e.preventDefault();
		    //close other edit-mode sectons if any
		    $('.section-content:not(.new-block-holder) .profile-edit').removeClass('in').addClass('collapse');
		    $('.section-content:not(.new-block-holder)').removeClass('edit-mode');

		    var addBlockID = $(this).attr('href');
		    if( !$(addBlockID).is(':visible') ){
			    $(addBlockID).parent().removeClass('hidden');
			    $(addBlockID)
				    .removeAttr('style')
				    .slideDown(300 , function(){
					    $(this)
					    .addClass('in')
					    .removeAttr('style');
				    })
				    .parent().addClass('edit-mode');	
			
			    //scroll new block to visible area of screen
			    $('body,html').animate({
					    scrollTop: $(addBlockID).height()>$(window).height()/1.5? $(addBlockID).offset().top : $(addBlockID).offset().top - 200
				    },300);
				
		    }else{
			    return false;
		    }
		
	});

    /* disable end date with marked checkbox*/  
	$( "".date_wrap"" ).each(function() {
		var ele = $(this);
		$(this).find("".current-date"").change(function(){
			if($(this).is("":checked"")){
				ele.find("".end-date-wrap select"").prop('disabled', 'disabled');
			}
			else
			{
				ele.find("".end-date-wrap select"").removeAttr(""disabled"");
			}
		});
	});

    /* Quick links view more btn*/
	if($(""#ctl00_ContentPlaceHolder1_upNavigation"").length  && $("".quick-links"").length){
		var wrap_height = 2 * $("".quick-links"").outerHeight() + 2 * $("".quick-links"").css(""marginBottom"").replace('px', '');
		var autoHeight = $(""#ctl00_ContentPlaceHolder1_upNavigation"").css('height', 'auto').height(); //get auto height
		
		$(""#ctl00_ContentPlaceHolder1_upNavigation"").css({""height"":wrap_height,""opacity"":1});

        if ($('.quick-links').length > 4) {
            $('.viewmore_btn').removeClass('hidden');
        }
        else
            $('.viewmore_btn').addClass('hidden');

		$("".viewmore_btn"").on( 'click', function(){
			$(this).toggleClass(""viewless"");
			$(""#ctl00_ContentPlaceHolder1_upNavigation"").toggleClass(""full"").toggleClass(""small"");
			$("".full"").stop().animate({ height: autoHeight });
			$("".small"").stop().animate({ height: wrap_height });
		});
	}

    $(""#ctl00_ContentPlaceHolder1_upNavigation a"").on('click', function(e){
    	var target_section = $(this).attr(""href"");
    	var target_form = $(this).attr(""data-form"");

        $(""html, body"").animate({
                scrollTop: $(target_section).offset().top - $("".navbar-wrapper"").height() - 50
            }, 100);
        
        if($(this).is("".clicked""))
        {
        	//do nothing
        }
        else{
        	$(target_section).find(target_form).trigger( ""click"" );
        	 $(""#ctl00_ContentPlaceHolder1_upNavigation a.clicked"").removeClass(""clicked"");
        	$(this).addClass(""clicked"");

        }

	});

	$("".equal-height-blocks .col-md-6"").eqHeight();

    $('#ctl00_ContentPlaceHolder1_ddlRolePreferenceSalaryRequirements').on('change', function () {
        SalaryTypeChanged();
    });

    SalaryTypeChanged();

    //call custom function if any
    if (typeof CustomFunction == 'function') { 
      CustomFunction('member/profile.aspx'); 
    }

", true);
        }

        #endregion

        #region Private helpers

        private string JoinText(List<string> texts)
        {
            string result = string.Empty;

            foreach (string text in texts)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        result = text;
                    }
                    else
                    {
                        result += ", " + text;
                    }
                }
            }

            return result;
        }

        private int MemberFileTypeID(string filename)
        {
            int _memberFileTypeID = 0;

            using (TList<Entities.MemberFileTypes> objMemberFileTypes = MemberFileTypesService.GetAll())
            {

                Entities.MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", System.IO.Path.GetExtension(filename).Trim());

                if (objMemberFileType != null)
                {
                    _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                }

            }
            return _memberFileTypeID;
        }

        protected string GetCurrency(string locationID)
        {
            string currency = string.Empty;

            if (!string.IsNullOrWhiteSpace(locationID))
            {
                Entities.Location loc = LocationService.GetByLocationId(Convert.ToInt32(locationID));
                if (loc != null)
                {
                    Entities.SiteCountries country = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, loc.CountryId);

                    if (country != null)
                    {
                        currency = country.Currency;
                    }
                }
            }

            return currency;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        /// <summary>
        /// Returns the generated HTML markup for a Control object
        /// </summary>
        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }

        private void UpdateMemberLastModified()
        {
            using (Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (member != null)
                {
                    member.LastModifiedDate = DateTime.Now;

                    MembersService.Update(member);
                }
            }
        }

        public string GetMemberProfilePercentageLabel(int points)
        {
            /*
Beginner 	20% below
Intermeditate 	20 - 60%
Advanced 	60% - 90%
Expert	90% +
             */

            if (points < 20)
                return CommonFunction.GetResourceValue("LabelBeginner");
            else if (points >= 20 && points < 60)
                return CommonFunction.GetResourceValue("LabelIntermediate");
            else if (points >= 60 && points < 90)
                return CommonFunction.GetResourceValue("LabelAdvanced");
            //else if (points >= 90)

            return CommonFunction.GetResourceValue("LabelExpert");
        }

        private void ProcessFocusSectionFlag()
        {
            string flag = Request["focus"];

            switch (flag)
            {
                case "personal":
                    string controltofocus = tbDetailsPrimaryEmail.ClientID;

                    OpenRepeaterDiv(string.Empty, controltofocus);
                    personalDetailsform.Attributes.Add("class", "personalDetails-form form-all collapse in");
                    break;
                default:
                    break;
            }
        }

        private void ScrollToNextSectionJS(string fromSectionID)
        {
            //show next section
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "NextSectionDivFocus", @"
                        <script type='text/javascript'>
                        $(document).ready(function() {
                            ScrollToNextSection('#" + fromSectionID + @"');
	                    });
                        </script>
                    ", false);
        }

        #endregion

        internal enum eErrorType
        {
            NoError = 0,
            Missing = 1,
            InvalidContent = 2
        }

        internal class CustomQuestion
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            public List<string> Parameters { get; set; }
            public int Sequence { get; set; }
            public bool Mandatory { get; set; }
            public int Status { get; set; }
            public string Answer { get; set; }
            public string TempAnswer { get; set; }
            public eErrorType ErrorType { get; set; }

            
        }

        internal class CustomQuestionAnswer
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        //private enum eAction
        //{
        //    Insert = 1,
        //    Update = 2,
        //    Delete = 3
        //}

        //private void BullhornSync(object JXTEntity, eAction action)
        //{
        //    if (JXTEntity is Entities.Members)
        //    {       
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberPositions)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberQualification)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberCertificateMemberships)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberLicenses)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberReferences)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberFiles)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //    else if (JXTEntity is Entities.MemberLanguages)
        //    {
        //        if (action == eAction.Insert)
        //        {

        //        }
        //        else if (action == eAction.Update)
        //        {

        //        }
        //        else if (action == eAction.Delete)
        //        {

        //        }
        //    }
        //}
    }
}