using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using System.Xml;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;
using System.Text;
using System.IO;
using log4net;

namespace JXTPortal.Website.usercontrols.peoplesearch
{
    public partial class ucPublicProfile : System.Web.UI.UserControl
    {
        #region Declaration

        private string _memberurlextension = "";
        private MembersService _membersservice;
        private AvailableStatusService _availableStatusService;
        private MemberFilesService _memberfilesService;
        private MemberPositionsService _memberpositionsService;
        private MemberWizardService _memberwizardService;
        private MemberQualificationService _memberqualificationService;
        private MemberCertificateMembershipsService _membercertificatemembershipsService;
        private MemberLicensesService _memberlicensesService;
        private LocationService _locationService;
        private SiteCountriesService _sitecountriesService;
        private SiteProfessionService _siteprofessionService;
        private SiteWorkTypeService _siteworktypeService;
        private SiteSalaryTypeService _sitesalarytypeService;
        private CountriesService _countriesService;
        private SiteRolesService _siterolesService;
        private MemberReferencesService _memberreferencesService;
        private MemberLanguagesService _memberlanguagesService;
        
        private List<ListItem> MonthList;
        private List<Entities.SiteRoles> siteroles;
        private List<Entities.SiteProfession> ProfessionList;
        private List<Entities.SiteWorkType> WorkTypeList;
        private List<Entities.SiteSalaryType> SalaryTypeList;

        List<Entities.Countries> countryList;
        List<Entities.MemberLanguages> Memberlanguages;
        Entities.MemberWizard memberWizard = null;

        private Dictionary<string, int> ProficiencyList;
        private Dictionary<string, int> RelationshipList;

        private int MinExperienceEntry = 0;
        private int MinEducationEntry = 0;
        private int MinReferenceEntry = 0;
        private int currentMemberID;

        string missingInformationlabel = CommonFunction.GetResourceValue("LabelMissingInformation");

        ILog _logger;

        #endregion

        #region Properties

        protected string MemberUrlExtension
        {
            get
            {
                if ((Request.QueryString["memberid"] != null))
                {
                    _memberurlextension = Request.QueryString["memberid"].ToString();
                }

                return _memberurlextension;
            }
        }

        AvailableStatusService AvailableStatusService
        {
            get
            {
                if (_availableStatusService == null)
                {
                    _availableStatusService = new AvailableStatusService();
                }
                return _availableStatusService;
            }
        }

        private MembersService MembersService
        {
            get
            {
                if (_membersservice == null)
                {
                    _membersservice = new MembersService();
                }
                return _membersservice;
            }
        }

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberfilesService == null)
                    _memberfilesService = new MemberFilesService();

                return _memberfilesService;
            }
        }

        private MemberPositionsService MemberPositionsService
        {
            get
            {
                if (_memberpositionsService == null)
                    _memberpositionsService = new MemberPositionsService();

                return _memberpositionsService;
            }
        }

        private MemberReferencesService MemberReferencesService
        {
            get
            {
                if (_memberreferencesService == null)
                    _memberreferencesService = new MemberReferencesService();

                return _memberreferencesService;
            }
        }

        private MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberwizardService == null)
                    _memberwizardService = new MemberWizardService();

                return _memberwizardService;
            }
        }

        private MemberQualificationService MemberQualificationService
        {
            get
            {
                if (_memberqualificationService == null)
                    _memberqualificationService = new MemberQualificationService();

                return _memberqualificationService;
            }
        }

        private MemberCertificateMembershipsService MemberCertificateMembershipsService
        {
            get
            {
                if (_membercertificatemembershipsService == null)
                    _membercertificatemembershipsService = new MemberCertificateMembershipsService();

                return _membercertificatemembershipsService;
            }
        }

        private MemberLanguagesService MemberLanguagesService
        {
            get
            {
                if (_memberlanguagesService == null)
                    _memberlanguagesService = new MemberLanguagesService();

                return _memberlanguagesService;
            }
        }

        private MemberLicensesService MemberLicensesService
        {
            get
            {
                if (_memberlicensesService == null)
                    _memberlicensesService = new MemberLicensesService();

                return _memberlicensesService;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesService == null)
                    _sitecountriesService = new SiteCountriesService();

                return _sitecountriesService;
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

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionService == null)
                    _siteprofessionService = new SiteProfessionService();

                return _siteprofessionService;
            }
        }
        
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeService == null)
                    _siteworktypeService = new SiteWorkTypeService();

                return _siteworktypeService;
            }
        }
        
        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeService == null)
                    _sitesalarytypeService = new SiteSalaryTypeService();

                return _sitesalarytypeService;
            }
        }

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                    _countriesService = new CountriesService();

                return _countriesService;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesService == null)
                    _siterolesService = new SiteRolesService();

                return _siterolesService;
            }
        }

        #endregion

        public ucPublicProfile()
        {
            _logger = LogManager.GetLogger(typeof(ucPublicProfile));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Debug("Public Profile Page loading\n");

            if (!string.IsNullOrWhiteSpace(MemberUrlExtension))
            {
                //Advertiser level flag check
                if (Entities.SessionData.AdvertiserUser == null || !Entities.SessionData.AdvertiserUser.AllowedToAccessPeopleSearch)
                {
                    Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                    return;
                }

                JXTPortal.Entities.Members member = MembersService.GetByMemberId(Convert.ToInt32(MemberUrlExtension));

                if (member != null)
                {
                    currentMemberID = member.MemberId;
                    _logger.DebugFormat("Current member ID Assigned: {0}\n", currentMemberID);

                    LoadCalendar();
                    LoadMemberInfo(member);
                    SetAttachResume(currentMemberID);
                    SetAttachCoverletter(currentMemberID);
                    SetWorkExperience(currentMemberID);
                    SetEducation(currentMemberID);
                    LoadSkills(currentMemberID);
                    SetCertifications(currentMemberID);
                    SetLicenses(currentMemberID);
                    LoadProfession();
                    LoadSalaryType();
                    SetRolePreferences(member);
                    LoadWorkType();
                    SetLanguages(currentMemberID);
                    SetReferences(currentMemberID);
                }
                else
                {  
                    Response.Redirect("~/PeopleSearch.aspx");
                }
            }
            else
            {
                Response.Redirect("~/PeopleSearch.aspx");
            }

            _logger.Debug("End of page Load\n");
        }

      
        private void LoadMemberInfo(Entities.Members member)
        {
            _logger.Debug("LoadMemberInfo() loaded");

            // {0} - Label Name    {1} - Fontawesome class   {2} - missing info status    {3} - Member Availability Status
            string htmlNotationAvailableStatus = @"<div class='col-sm-6'><h5>{0}:</h5><span class='{1} highlight'></span><span id='current-status {2}'> {3}</span></div>";

            // {0} - Label Name    {1} - Fontawesome class   {2} - missing info status    {3} - Available date
            string htmlNotationAvailabledate = @"<div class='col-sm-6'><h5>{0}:</h5><span class='{1} highlight'></span><span id='availability-date' class='{2}'>{3}</span></div>";

            // {0} - Label Name    {1} - LastModified Date
            string htmlNotationLastModifiedDate = @"<div class='col-sm-6'><p class='last-modified-date'><strong>{0}:</strong> {1}</p></div>";


            string eyeCssClass = "fa fa-eye";
            string clockCssclass = "fa fa-clock-o";


            // Member Identity Information
            ltTitle.Text = HttpUtility.HtmlEncode(member.Title);
            ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
            ltLastName.Text = HttpUtility.HtmlEncode(member.Surname);
            ltHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
            ltlLastModifiedDate.Text = HttpUtility.HtmlEncode(member.LastModifiedDate);

            // Assigning Titles Profile Sections
            AssignSectionTitle();

            // Profile PIcture
            if (!string.IsNullOrWhiteSpace(member.ProfilePicture))
            {
                profilePic.ImageUrl = string.Format("{0}{1}", 
                                                    ConfigurationManager.AppSettings["MemberUploadPicturePaths"], 
                                                    member.ProfilePicture);

                _logger.DebugFormat("Member Profile picture URL: {0}", profilePic.ImageUrl);
            }

            // Availability Status
            bool memberIsAvailable = member.AvailabilityId.HasValue && member.AvailabilityId > 0;

            PortalEnums.Members.CurrentlySeeking memberStatus = memberIsAvailable ? (PortalEnums.Members.CurrentlySeeking)member.AvailabilityId:PortalEnums.Members.CurrentlySeeking.NotSeeking;
            ltCurrentSeeking.Text = string.Format(htmlNotationAvailableStatus,
                                                      CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                      eyeCssClass,
                                                      memberIsAvailable ? string.Empty : "missing",
                                                      HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription(memberStatus))));

            // Availability Date
            if (member.AvailabilityFromDate.HasValue)
            {
                ltAvailableDayFrom.Text = string.Format(htmlNotationAvailabledate,
                                                        CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"),
                                                        clockCssclass,
                                                        "availableDate",
                                                        member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));

            }
            else
            {
                ltAvailableDayFrom.Text = string.Format(htmlNotationAvailabledate,
                                                        CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"),
                                                        clockCssclass,
                                                        "missing",
                                                        missingInformationlabel);
            }
            
            // Last Modified Date
            if(member.LastModifiedDate.HasValue)
            {
                ltlLastModifiedDate.Text = string.Format(htmlNotationLastModifiedDate,
                                                        CommonFunction.GetResourceValue("LabelLastModified"), 
                                                        member.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat));

                _logger.DebugFormat("Member Profile Last Modified Date: {0}", ltlLastModifiedDate.Text);
            }

            // Download Resume Button (This Downloads Latest resume)
            var resume = GetLatestResumeID();

            _logger.DebugFormat("Lastest resume: {0}", resume);

            if (resume != 0)
            {
                linkDownloadResume.NavigateUrl = "/download.aspx?type=mf&id=" + resume.ToString();

                _logger.DebugFormat("Lastest resume download URL: {0}", linkDownloadResume.NavigateUrl);
            }
            else
            {
                phLastestResume.Visible = false;
                _logger.Debug("Lastest resume Not found and download button not visible: {0}");
            }

            //Render Member Summary
            RenderMemberSummary(member.ShortBio);

            //Render Member Personal Details
            RenderPersonalDetails(member);

            _logger.Debug("End of LoadMemberInfo()");

        }

        private void RenderMemberSummary(string summary)
        {
            _logger.Debug("RenderMemberSummary() method loaded!");

            if (!string.IsNullOrWhiteSpace(summary))
            {
                ltSummary.Text = HttpUtility.HtmlEncode(summary);
            }
            else
            {
                _logger.Debug("Member Summary Missing!");

                ltSummary.Text = CommonFunction.GetResourceValue("LabelMissingInformation");
            }

            _logger.Debug("End of RenderMemberSummary() method!");
        }

        private void RenderPersonalDetails(Entities.Members member)
        {
            _logger.Debug("RenderPersonalDetails() loaded!");

            // {0} - LabelName      {1} - Css class (if there is)       {2} - Value
            string htmlNotationDOB = "<span class='highlight dob-heading'>{0}</span><span class='personal-detail-content dob {1}'>{2}</span>";

            string htmlNotationGender = "<span class='highlight gender-heading'>{0}</span><span class='personal-detail-content gender-detail {1}'>{2}</span>";

            string htmlNotationSecondEmail = "<span class='highlight secondary-email-heading'>{0}</span><span class='personal-detail-content secondary-email {1}'>{2}</span>";

            string htmlNotationHomePhone = "<span class='highlight ph_home_numb-heading'>{0}</span><span class='personal-detail-content ph_home_numb {1}'>{2}</span>";

            string htmlNotationMobile = "<span class='highlight ph_mobile_numb-heading'>{0}</span><span class='personal-detail-content ph_mobile_numb {1}'>{2}</span>";

            string htmlNotationPassportNo = "<span class='highlight ph_passport_numb-heading'>{0}</span><span class='personal-detail-content ph_passport_numb {1}'>{2}</span>";

            string htmlNotationPrefferedLine = "<span class='highlight line-heading'>{0}</span><span class='personal-detail-content {1}'><span class='preferred-line'>{2}</span></span>";

            
            //Email
            ltEmail.Text = (!string.IsNullOrWhiteSpace(member.EmailAddress)) ? HttpUtility.HtmlEncode(member.EmailAddress) : missingInformationlabel;
          
            //DOB
            if (member.DateOfBirth.HasValue)
            {
                ltDateOfBirth.Text = string.Format(htmlNotationDOB, CommonFunction.GetResourceValue("LabelDateOfBirth"), string.Empty, member.DateOfBirth.Value.ToString(SessionData.Site.DateFormat));
            }
            else
            {
                ltDateOfBirth.Text = string.Format(htmlNotationDOB, CommonFunction.GetResourceValue("LabelDateOfBirth"), "missing", missingInformationlabel);
                _logger.Debug("Member DOB Missing!");
            }

            //gender
            if (!string.IsNullOrWhiteSpace(member.Gender))
            {
                string genderDisplay = member.Gender == "M" ? CommonFunction.GetResourceValue("LabelMale") : CommonFunction.GetResourceValue("LabelFemale");

                ltGender.Text = string.Format(htmlNotationGender, CommonFunction.GetResourceValue("LabelGender"), string.Empty, genderDisplay);
  
            }
            else
            {
                ltGender.Text = string.Format(htmlNotationGender, CommonFunction.GetResourceValue("LabelGender"), "missing", missingInformationlabel);

                _logger.Debug("Member Gender Details Missing!");
            }

            //address
            RenderMemberAddress(member.Address1,
                            member.Address2,
                            member.Suburb,
                            member.States,
                            member.PostCode,
                            member.CountryId,
                            "address");

            //second email
            SetLiteralText(member.SecondaryEmail, ltSecondaryEmail, htmlNotationSecondEmail, "LabelSecondaryEmail");
  
            //homephone
            SetLiteralText(member.HomePhone, ltPhoneNumber, htmlNotationHomePhone, "LabelPhoneHome");

            //mobile
            SetLiteralText(member.MobilePhone, ltMobileNumber, htmlNotationMobile, "LabelPhoneMobile");
          
            //passport number
            SetLiteralText(member.PassportNo, ltPassportNumber, htmlNotationPassportNo, "LabelPassportNumber");

            //mailing address
            RenderMemberAddress(member.MailingAddress1,
                            member.MailingAddress2,
                            member.MailingSuburb,
                            member.MailingStates,
                            member.MailingPostCode,
                            member.CountryId,
                            "mailing-address");
            
            //preferred line
            if (member.PreferredLine == 1)
            {
                ltLineSelected.Text = string.Format(htmlNotationPrefferedLine,
                                                    CommonFunction.GetResourceValue("LabelPreferredLine"),
                                                    string.Empty,
                                                    HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneHome")));
            }
            else if (member.PreferredLine == 2)
            {
                ltLineSelected.Text = string.Format(htmlNotationPrefferedLine,
                                                    CommonFunction.GetResourceValue("LabelPreferredLine"),
                                                    string.Empty,
                                                    HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneMobile")));
            }
            else
            {
                ltLineSelected.Text = string.Format(htmlNotationPrefferedLine,
                                                    CommonFunction.GetResourceValue("LabelPreferredLine"),
                                                    "missing",
                                                    missingInformationlabel);

                _logger.Debug("Member Preffered Line Missing!");
            }

            _logger.Debug("RenderPersonalDetails() loaded!");
        }

        /// <summary>
        /// This Method Sets the text that goes into a certain literal
        /// </summary>
        /// <param name="content">Member Content <example>member.memberId</example></param>
        /// <param name="control">Literal ID</param>
        /// <param name="htmlFormat">Formatted HTML (if there is any)</param>
        /// <param name="resourceName">Value that needs to be assigned to the literal</param>
        private void SetLiteralText(string content, Literal control, string htmlFormat, string resourceName)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                control.Text = string.Format(htmlFormat, CommonFunction.GetResourceValue(resourceName), string.Empty, HttpUtility.HtmlEncode(content));             
            }
            else
            {
                control.Text = string.Format(htmlFormat, CommonFunction.GetResourceValue(resourceName), "missing", missingInformationlabel);
            }
        }

        public void RenderMemberAddress(string address1, string address2, string suburb, string states, string postcode, int countryID, string addressType)
        {
            _logger.Debug("RenderMemberAddress() method loaded!");

            // {0} - field      {1} - Label
            string htmlNotationMissingInformation = "<span class='{0} missing'>{1}</span>";
            
            // {0} - field      {1} - Label
            string htmlNotationAddress = "<span class='{0}'>{1}</span>";
            
            _logger.DebugFormat("Member Adress Type: {0}", addressType);
            _logger.DebugFormat("Member Adress Field {0}: {1}", 1, address1);
            _logger.DebugFormat("Member Adress Field {0}: {1}", 2, address2);
            _logger.DebugFormat("Member Adress Field {0}: {1}", "suburb", suburb);
            _logger.DebugFormat("Member Adress Field {0}: {1}", "state", states);
            _logger.DebugFormat("Member Adress Field {0}: {1}", "poastcode", postcode);
            _logger.DebugFormat("Member Adress Field {0}: {1}", "countryID", countryID);
           
            bool hasAddress = !(string.IsNullOrWhiteSpace(address1) && string.IsNullOrWhiteSpace(address2)
                            && string.IsNullOrWhiteSpace(suburb) && string.IsNullOrWhiteSpace(states)
                            && string.IsNullOrWhiteSpace(postcode) && countryID == 0);

            if (!hasAddress)
            {
                if(addressType == "address")
                {
                    ltAddress1.Text = string.Format(htmlNotationMissingInformation,
                                                   "adress1",
                                                   CommonFunction.GetResourceValue("LabelMissingInformation"));
                   
                    _logger.Debug("Adress Information Are Missing!");
                }
                else
                {
                    ltMailingAddress1.Text = string.Format(htmlNotationMissingInformation,
                                                          "mailing-address1",
                                                          CommonFunction.GetResourceValue("LabelMissingInformation"));
                    
                    _logger.Debug("Mailing Adress Information Are Missing!");
                }

                return;
            }


            // Address line 1

            if (!string.IsNullOrWhiteSpace(address1))
            {
                if (addressType == "address")
                    ltAddress1.Text = string.Format(htmlNotationAddress,
                                                    "address1",
                                                    HttpUtility.HtmlEncode(address1));
                else
                    ltMailingAddress1.Text = string.Format(htmlNotationAddress,
                                                            "mailing-address1",
                                                            HttpUtility.HtmlEncode(address1));
            }

            // Address line 2
            if (!string.IsNullOrWhiteSpace(address2))
            {
                if (addressType == "address")
                    ltAddress2.Text = string.Format(htmlNotationAddress,
                                                    "address2",
                                                    HttpUtility.HtmlEncode(address1));
                else
                    ltMailingAddress2.Text = string.Format(htmlNotationAddress,
                                                            "mailing-address2",
                                                            HttpUtility.HtmlEncode(address1));
            }

            // Suburb
            if (!string.IsNullOrWhiteSpace(suburb))
            {
                if (addressType == "address")
                    ltCity.Text = string.Format(htmlNotationAddress,
                                                    "addCity",
                                                    HttpUtility.HtmlEncode(suburb));
                else
                    ltMailingCity.Text = string.Format(htmlNotationAddress,
                                                            "mailing-City",
                                                            HttpUtility.HtmlEncode(address1));
            }

            // State
            if (!string.IsNullOrWhiteSpace(states))
            {
                if (addressType == "address")
                    ltState.Text = string.Format(htmlNotationAddress,
                                                "addState",
                                                HttpUtility.HtmlEncode(states));
                else
                    ltMailingState.Text = string.Format(htmlNotationAddress,
                                                        "mailing-State", 
                                                        HttpUtility.HtmlEncode(states));
            }

            // Postcode
            if (!string.IsNullOrWhiteSpace(postcode))
            {
                if (addressType == "address") 
                    ltPostcode.Text = string.Format(htmlNotationAddress,
                                                    "addPostcode", 
                                                    HttpUtility.HtmlEncode(postcode));
                else
                    ltMailingPostcode.Text = string.Format(htmlNotationAddress,
                                                        "mailing-Postcode", 
                                                        HttpUtility.HtmlEncode(postcode));
            }

            // Country
            if (!string.IsNullOrWhiteSpace(countryID.ToString()))
            {
                if (addressType == "address")
                {
                    ltCountry.Text = string.Format(htmlNotationAddress,
                                                "addCountry",
                                                    HttpUtility.HtmlEncode(getCountryName(countryID)));

                    _logger.DebugFormat("Address Country Name: {0}", ltCountry.Text);
                }
                else
                {
                    ltMailingCountry.Text = string.Format(htmlNotationAddress,
                                                "addCountry",
                                                    HttpUtility.HtmlEncode(getCountryName(countryID)));

                    _logger.DebugFormat("Mailing-Address Country Name: {0}", ltMailingCountry.Text);
                }
            }


            _logger.Debug("End of RenderMemberAddress() method!");
        }

        public string getCountryName(int countryID)
        {
            _logger.Debug("getCountryName() loaded!");

            var memberCountry = SiteCountriesService.GetByCountryId(countryID).FirstOrDefault();

            if (memberCountry != null)
            {
                var countryName = memberCountry.SiteCountryName;
                
                _logger.Debug("End of getCountryName()");
                return countryName;
            }
            else
            {
                _logger.Debug("Country Name null, End of getCountryName()");
                return string.Empty;
            }

            
        }

        private void SetAttachResume(int memberID)
        {
            _logger.Debug("SetAttachResume() loaded");

            using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(memberID))
            {
                resumes.Filter = "DocumentTypeId = 2";

                rptResume.DataSource = resumes;
                rptResume.DataBind();

                phAddEntryTextResume.Visible = (resumes.Count == 0);
            }
        }

        protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("Binding resumed data to download");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltResumeFileName = e.Item.FindControl("ltResumeFileName") as Literal;
                HyperLink hlResumeDownload = e.Item.FindControl("hlResumeDownload") as HyperLink;

                if (e.Item.DataItem is MemberFiles)
                {
                    MemberFiles resume = e.Item.DataItem as MemberFiles;
                    ltResumeFileName.Text = (string.IsNullOrEmpty(resume.MemberFileTitle)) ? HttpUtility.HtmlEncode(resume.MemberFileName) : HttpUtility.HtmlEncode(resume.MemberFileTitle);

                    hlResumeDownload.NavigateUrl = "/download.aspx?type=mf&id=" + resume.MemberFileId.ToString();

                    _logger.DebugFormat("Resume {0}: Download Link = {1}", ltResumeFileName.Text, hlResumeDownload.NavigateUrl);
                }
                else
                {
                    phAddEntryTextResume.Visible = true;

                    _logger.Debug("Resume DataItem type is not Memberfiles");
                    return;
                }
            }

            _logger.Debug("End of Binding resumed data to Download");
        }

        private void SetAttachCoverletter(int memberID)
        {
            _logger.Debug("SetAttachCoverletter() loaded");

            using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(memberID))
            {
                coverletters.Filter = "DocumentTypeId = 1";

                rptCoverLetter.DataSource = coverletters;
                rptCoverLetter.DataBind();

                phAddEntryTextCoverletter.Visible = (coverletters.Count == 0);
            }

        }

        protected void rptCoverLetter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("Binding cover letter data to download");
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltCoverLetterFileName = e.Item.FindControl("ltCoverLetterFileName") as Literal;
                HyperLink hlCoverLetterDownload = e.Item.FindControl("hlCoverLetterDownload") as HyperLink;
                LinkButton lbCoverLetterDelete = e.Item.FindControl("lbCoverLetterDelete") as LinkButton;

                if (e.Item.DataItem is MemberFiles)
                {
                    MemberFiles coverletter = e.Item.DataItem as MemberFiles;

                    ltCoverLetterFileName.Text = (string.IsNullOrEmpty(coverletter.MemberFileTitle)) ? HttpUtility.HtmlEncode(coverletter.MemberFileName) : HttpUtility.HtmlEncode(coverletter.MemberFileTitle);
                    hlCoverLetterDownload.NavigateUrl = "/download.aspx?type=mf&id=" + coverletter.MemberFileId.ToString();

                    _logger.DebugFormat("Cover letter {0}: Download Link = {1}", ltCoverLetterFileName.Text, hlCoverLetterDownload.NavigateUrl);
                }
                else
                {
                    phAddEntryTextCoverletter.Visible = true;
                    _logger.Debug("Coverletter DataItem type is not Memberfiles");
                    return;
                }
            }
            _logger.Debug("rptCoverLetter_ItemDataBound End");
        }

        private void SetWorkExperience(int memberID)
        {
            _logger.Debug("Setting member work experience!");

            using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(memberID))
            {
                memberpositions.Filter = "isDirectorship = false";
                rptExperience.DataSource = memberpositions.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptExperience.DataBind();

                phAddEntryTextExperience.Visible = (memberpositions.Count <= MinExperienceEntry);

            }
        }

        protected void rptExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("Binding Member Experience data to display");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltExperienceCompanyNameAndLocation = e.Item.FindControl("ltExperienceCompanyNameAndLocation") as Literal;
                Literal ltExperienceJobTitle = e.Item.FindControl("ltExperienceJobTitle") as Literal;
                Literal ltExperienceDate = e.Item.FindControl("ltExperienceDate") as Literal;
                Literal ltExperienceDescription = e.Item.FindControl("ltExperienceDescription") as Literal;

                Entities.MemberPositions memberposition = e.Item.DataItem as Entities.MemberPositions;

                List<string> companynameandlocation = new List<string>();

                companynameandlocation.Add(memberposition.CompanyName);
                companynameandlocation.Add(memberposition.City);

                if (!string.IsNullOrWhiteSpace(memberposition.State))
                {
                    companynameandlocation.Add(memberposition.State);
                }

                if (memberposition.CountryId.HasValue)
                {
                    var countryName = getCountryName(Convert.ToInt32(memberposition.CountryId));

                    companynameandlocation.Add(countryName);
                }


                string experiencedate = string.Empty;

                DateTime StartDate = new DateTime(memberposition.StartYear.Value, memberposition.StartMonth.Value, 1);

                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                if (!memberposition.IsCurrent)
                {
                    EndDate = new DateTime(memberposition.EndYear.Value, memberposition.EndMonth.Value, 1);
                }

                string startmonth = string.Empty;
                string endmonth = string.Empty;
                string duration = string.Empty;
                
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

                TimeSpan experienceDuration = EndDate.Subtract(StartDate);

                int totalYears = experienceDuration.TotalYears();
                int totalMonths = experienceDuration.TotalMonths();
                if (totalYears > 0)
                {
                    duration = totalYears.ToString() + " " + (totalYears == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                }

                if (totalMonths - 1 > 0)
                {
                    if (!string.IsNullOrWhiteSpace(duration))
                    {
                        duration += ", ";
                    }

                    duration += totalMonths.ToString() + " " + ((totalMonths) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                }

                if (totalYears == 1 && totalMonths == 1)
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

        private int SetEducation(int memberID)
        {
            _logger.Debug("Setting Member Education");

            using (TList<Entities.MemberQualification> membereducations = MemberQualificationService.GetByMemberId(memberID))
            {
                if (membereducations != null && membereducations.Count > 0)
                {
                    rptEducation.DataSource = membereducations.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                    rptEducation.DataBind();
                }
                else
                {
                    _logger.Debug("Member Education Null");
                    rptEducation.DataSource = null;
                    rptEducation.DataBind();
                }

                phAddEntryTextEducation.Visible = (membereducations.Count <= MinEducationEntry);

            }

            return 0;
        }

        protected void rptEducation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("rptEducation_ItemDataBound() loaded");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltInstitute = e.Item.FindControl("ltInstitute") as Literal;
                Literal ltEducationLocation = e.Item.FindControl("ltEducationLocation") as Literal;
                Literal ltQualificationName = e.Item.FindControl("ltQualificationName") as Literal;
                Literal ltEducationDate = e.Item.FindControl("ltEducationDate") as Literal;
                Literal ltEducationDescription = e.Item.FindControl("ltEducationDescription") as Literal;

                Entities.MemberQualification education = e.Item.DataItem as Entities.MemberQualification;

                var educationdate = CalculateEducationTimePeriod(education);
                
                ltInstitute.Text = HttpUtility.HtmlEncode(education.SchoolName);

                List<string> educationlocation = new List<string>();

                if (!string.IsNullOrWhiteSpace(education.City))
                {
                    educationlocation.Add(education.City);
                }

                if (education.CountryId.HasValue)
                {
                    var countryName = getCountryName(Convert.ToInt32(education.CountryId));

                    educationlocation.Add(countryName);                
                    
                }

                if (educationlocation != null && educationlocation.Count > 0)
                {
                    ltEducationLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'><!-- icon --></span>{0}</address>",
                                                                HttpUtility.HtmlEncode(JoinText(educationlocation)));
                }

                ltQualificationName.Text = HttpUtility.HtmlEncode(education.Degree);
                ltEducationDate.Text = educationdate;
                ltEducationDescription.Text = HttpUtility.HtmlEncode(education.QualificationLevelOther);

            }
        }

        private void LoadSkills(int memberID)
        {
            _logger.Debug("Loading member skills");

            using (JXTPortal.Entities.Members objMembers = MembersService.GetByMemberId(memberID))
            {
                if (objMembers != null && objMembers.SiteId == SessionData.Site.SiteId)
                {
                    if (!string.IsNullOrWhiteSpace(objMembers.Skills))
                    {
                        string[] split = objMembers.Skills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        split = split.OrderBy(c => c).ToArray();

                        rptSkills.DataSource = split;
                        rptSkills.DataBind();

                        phAddEntryTextSkills.Visible = (split.Count() <= 0);
                        phSkillsDisplay.Visible = (split.Count() > 0);
                    }
                }
            }
        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("Binding member skills to display");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltSkill = e.Item.FindControl("ltSkill") as Literal;

                string skillStr = e.Item.DataItem as string;

                ltSkill.Text = HttpUtility.HtmlEncode(skillStr);
            }
        }

        private string CalculateEducationTimePeriod(Entities.MemberQualification education)
        {
            _logger.Debug("calculateEducationTimePeriod() loaded");

            string educationdate = string.Empty;

            if (education.StartYear.HasValue && education.StartMonth.HasValue)
            {
                DateTime StartDate = new DateTime(education.StartYear.Value, education.StartMonth.Value, 1);

                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                if (education.EndYear.HasValue && education.EndMonth.HasValue)
                {
                    EndDate = new DateTime(education.EndYear.Value, education.EndMonth.Value, 1);
                }

                string startmonth = string.Empty;
                string endmonth = string.Empty;
                string duration = string.Empty;

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

                TimeSpan experienceDuration = EndDate.Subtract(StartDate);

                int totalYears = experienceDuration.TotalYears();
                int totalMonths = experienceDuration.TotalMonths();

                if (totalYears > 0)
                {
                    duration = (totalYears).ToString() + " " + ((totalYears - 1) == 1 ? CommonFunction.GetResourceValue("LabelYear") : CommonFunction.GetResourceValue("LabelYears"));
                }

                if (totalMonths - 1 > 0)
                {
                    if (!string.IsNullOrWhiteSpace(duration))
                    {
                        duration += ", ";
                    }

                    duration += (totalMonths - 1).ToString() + " " + ((totalMonths - 1) == 1 ? CommonFunction.GetResourceValue("LabelMonth") : CommonFunction.GetResourceValue("LabelMonths"));
                }

                if (totalYears == 1 && totalMonths == 1)
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
            else
            {
                _logger.Debug("Education Start information is null or empty");

                educationdate = string.Empty;
            }

            return educationdate;
        }

        private void SetCertifications(int memberID)
        {
            _logger.Debug("Setting Member Certification to Display");

            using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(memberID))
            {
                rptCertification.DataSource = membercertificates.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptCertification.DataBind();

                phAddEntryTextCertificates.Visible = (membercertificates.Count <= 0);
            }
        }

        protected void rptCertification_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("Binding Member Certification to Display");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltAuthority = e.Item.FindControl("ltAuthority") as Literal;
                Literal ltCertificateMembershipName = e.Item.FindControl("ltCertificateMembershipName") as Literal;
                Literal ltCertificateMembershipDate = e.Item.FindControl("ltCertificateMembershipDate") as Literal;
                Literal ltCertificateMembershipUrl = e.Item.FindControl("ltCertificateMembershipUrl") as Literal;
                Literal ltCertificateMembershipUrlNo = e.Item.FindControl("ltCertificateMembershipUrlNo") as Literal;

                MemberCertificateMemberships certificate = e.Item.DataItem as MemberCertificateMemberships;
                
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
                    {
                        certificatedate = CommonFunction.GetResourceValue("LabelCertificateDoesNotExpire");
                    }
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
            }

        }

        private void SetLicenses(int memberID)
        {
            _logger.Debug("Setting Member Licences to Display");

            using (TList<Entities.MemberLicenses> memberlicenses = MemberLicensesService.GetByMemberId(memberID))
            {
                rptLicenses.DataSource = memberlicenses.OrderByDescending(s => s.IssueDate);
                rptLicenses.DataBind();

                phAddEntryTextLicenses.Visible = (memberlicenses.Count <= 0);
            }
        }

        protected void rptLicenses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("rptLicenses_ItemDataBound() loaded");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLicenseName = e.Item.FindControl("ltLicenseName") as Literal;
                Literal ltLicenseType = e.Item.FindControl("ltLicenseType") as Literal;
                Literal ltLicenseDate = e.Item.FindControl("ltLicenseDate") as Literal;
                Literal ltLicenseStateCountry = e.Item.FindControl("ltLicenseStateCountry") as Literal;

                MemberLicenses license = e.Item.DataItem as MemberLicenses;

                string licensedate = string.Empty;
                string startmonth = string.Empty;
                string endmonth = string.Empty;

                ltLicenseName.Text = HttpUtility.HtmlEncode(license.MemberLicenseName);
                ltLicenseType.Text = HttpUtility.HtmlEncode(license.LicenseType);


                bool hasStateAndCountryDisplay = false;

                List<string> licenseStateAndCountry = new List<string>();


                if (!string.IsNullOrWhiteSpace(license.State))
                {
                    licenseStateAndCountry.Add(HttpUtility.HtmlEncode(license.State));
                    hasStateAndCountryDisplay = true;
                }

                if (license.CountryId.HasValue && license.CountryId != 0)
                {
                  
                    licenseStateAndCountry.Add(HttpUtility.HtmlEncode(getCountryName(Convert.ToInt32(license.CountryId))));
                    hasStateAndCountryDisplay = true;
                }

                ltLicenseStateCountry.Text = String.Join(", ", licenseStateAndCountry);


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

            }
        }

        private int SetRolePreferences(Entities.Members member)
        {
            _logger.Debug("SetRolePreferences() loaded");

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

            // Salary Type
            if (!string.IsNullOrWhiteSpace(member.PreferredSalaryId.ToString()))
            {
                var salaryType = SalaryTypeList.Where(salaryT => salaryT.SalaryTypeId == member.PreferredSalaryId).FirstOrDefault();

                if (salaryType != null)
                {
                    strSalary += " " + salaryType.SalaryTypeName;
                }
            }


            // Preference Location
            if (member.LocationId != null)
            {
                Entities.Location location = LocationService.GetByLocationId(Convert.ToInt32(member.LocationId));

                Entities.Countries country = CountriesService.GetByCountryId(location.CountryId);

                if (location != null && country != null)
                {
                    strLocation += country.CountryName + " - " + location.LocationName;
                }
            }

            // Preffered Position
            if (member.PreferredCategoryId != null)
            {
                if (ProfessionList != null)
                {
                    foreach (string split in member.PreferredCategoryId.ToString().Split(new char[] { ',' }))
                    {
                        foreach (var role in ProfessionList)
                        {
                            if (role.ProfessionId.ToString() == split)
                            {
                                strProfession += role.SiteProfessionName.ToString() + ", ";
                                break;
                            }
                        }
                    }
                }

            }

            // Preffered Role
            if (!string.IsNullOrWhiteSpace(member.PreferredCategoryId))
            {
                int memberPreferredRoleId = Convert.ToInt32(member.PreferredCategoryId);

                LoadRolePreferenceRoles(memberPreferredRoleId);

                if (siteroles != null && member.PreferredSubCategoryId != null)
                {
                    foreach (string split in member.PreferredSubCategoryId.Split(new char[] { ',' }))
                    {
                        foreach (var role in siteroles)
                        {
                            if (role.RoleId.ToString() == split)
                            {
                                strRole += role.SiteRoleName + ", ";
                                break;
                            }
                        }
                    }

                }
            }

            // Eligle to work locations
            loadCountries();

            if (member.EligibleToWorkIn != null)
            {
                countryList = countryList.Where(c => c.Sequence != -1 && c.Abbr != "CC").OrderBy(c => c.CountryName).ToList();

                foreach (string split in member.EligibleToWorkIn.ToString().Split(new char[] { ',' }))
                {
                    foreach (var country in countryList)
                    {
                        if (country.CountryId.ToString() == split)
                        {
                            strEligibleToWorkIn += country.CountryName.ToString() + ", ";
                            break;
                        }
                    }
                }

            }

            // Member Work Types

            if (!string.IsNullOrWhiteSpace(member.WorkTypeId))
            {
                foreach (string split in member.WorkTypeId.Split(new char[] { ',' }))
                {
                    foreach (var worktype in SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (worktype.WorkTypeId.ToString() == split)
                        {
                            strWorkType += worktype.SiteWorkTypeName + ", ";
                            break;
                        }
                    }
                }
            }

            ltRolePreferencesSalary.Text = HttpUtility.HtmlEncode(strSalary);

            if (!string.IsNullOrWhiteSpace(strLocation))
            {
                ltRolePreferencesLocation.Text = string.Format("<address class='inline-field'><span class='fa fa-map-marker'></span>{0}</address>", HttpUtility.HtmlEncode(strLocation.TrimEnd(new char[] { ',', '-' })));
            }
            else
            {
                ltRolePreferencesLocation.Text = string.Empty;
            }

            ltRolePreferencesProfession.Text = HttpUtility.HtmlEncode(strProfession);
            ltRolePreferencesRole.Text = HttpUtility.HtmlEncode(strRole.TrimEnd(new char[] { ',', ' ' }));

            if (!string.IsNullOrWhiteSpace(strWorkType))
            {
                ltRolePreferencesWorktype.Text = string.Format("<p><strong>{0}:</strong><br />{1}</p>", CommonFunction.GetResourceValue("LabelWorkType"), HttpUtility.HtmlEncode(strWorkType.TrimEnd(new char[] { ',', ' ' })));
            }
            else
            {
                ltRolePreferencesWorktype.Text = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(strEligibleToWorkIn))
            {
                ltEligibleToWorkIn.Text = string.Format("<strong>{0}:</strong><br />{1}", CommonFunction.GetResourceValue("LabelEligibleToWorkIn"), HttpUtility.HtmlEncode(strEligibleToWorkIn.TrimEnd(new char[] { ',', ' ' })));
            }
            else
            {
                ltEligibleToWorkIn.Text = string.Empty;
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
            {
                phAddEntryTextRolePreferences.Visible = true;
            }

            return 0;
        }

        private void LoadProfession()
        {
            _logger.Debug("LoadProfession() loaded");

            ProfessionList = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);

        }

        private void LoadRolePreferenceRoles(int professionid)
        {
            _logger.Debug("LoadRolePreferenceRoless() loaded");
            siteroles = SiteRolesService.GetTranslatedByProfessionID(professionid, SessionData.Site.UseCustomProfessionRole);
        }

        private void LoadWorkType()
        {
            _logger.Debug("LoadWorkType() loaded");
            WorkTypeList = SiteWorkTypeService.GetTranslatedWorkTypes();
        }

        private void LoadSalaryType()
        {
            _logger.Debug("LoadSalaryType() loaded");

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

        private void SetLanguages(int memberID)
        {
            _logger.Debug("SetLanguages() loaded");

            using (TList<Entities.MemberLanguages> memberlanguages = MemberLanguagesService.GetByMemberId(memberID))
            {
                rptLanguages.DataSource = memberlanguages;
                rptLanguages.DataBind();

                phAddEntryTextLanguages.Visible = (memberlanguages.Count <= 0);
            }

        }

        protected void rptLanguages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("rptLanguages_ItemDataBound() loaded");

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLanguageName = e.Item.FindControl("ltLanguageName") as Literal;
                Literal ltProficiency = e.Item.FindControl("ltProficiency") as Literal;

                MemberLanguages language = e.Item.DataItem as MemberLanguages;

                ltLanguageName.Text = HttpUtility.HtmlEncode(language.Langauges);

                if (language.Profieciency.HasValue)
                {
                    _logger.Debug("Call to LoadMemberProficiency()");
                    LoadMemberProficiency();

                    foreach (var item in ProficiencyList)
                    {
                        if (item.Value == language.Profieciency.Value)
                        {
                            ltProficiency.Text = HttpUtility.HtmlEncode(item.Key);
                            break;
                        }
                    }

                }
            }
        }

        private void SetReferences(int memberID)
        {
            _logger.Debug("SetReferences() loaded");

            using (TList<Entities.MemberReferences> memberreferences = MemberReferencesService.GetByMemberId(memberID))
            {
                rptReferences.DataSource = memberreferences;
                rptReferences.DataBind();

                phAddEntryTextReferences.Visible = (memberreferences.Count <= MinReferenceEntry);
            }
        }

        protected void rptReferences_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _logger.Debug("rptReferences_ItemDataBound() loaded");

            var relationship = string.Empty;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal ltReferencesCompany = e.Item.FindControl("ltReferencesCompany") as Literal;
                Literal ltReferencesName = e.Item.FindControl("ltReferencesName") as Literal;
                Literal ltReferencesJobTitle = e.Item.FindControl("ltReferencesJobTitle") as Literal;
                Literal ltReferencesRelationship = e.Item.FindControl("ltReferencesRelationship") as Literal;
                Literal ltReferencePhone = e.Item.FindControl("ltReferencePhone") as Literal;
                Literal ltReferencesEmailDisplay = e.Item.FindControl("ltReferencesEmailDisplay") as Literal;

                PlaceHolder phReferencesPhone = e.Item.FindControl("phReferencesPhone") as PlaceHolder;

                MemberReferences reference = e.Item.DataItem as MemberReferences;

                ltReferencesCompany.Text = HttpUtility.HtmlEncode(reference.Company);
                ltReferencesName.Text = HttpUtility.HtmlEncode(reference.MemberReferenceName);
                ltReferencesJobTitle.Text = HttpUtility.HtmlEncode(reference.JobTitle);
                ltReferencePhone.Text = HttpUtility.HtmlEncode(reference.Phone);

                if (!string.IsNullOrEmpty(reference.ReferenceEmail))
                {
                    ltReferencesEmailDisplay.Text = @"<span class=""fa fa-envelope""><!-- icon --></span> " + HttpUtility.HtmlEncode(reference.ReferenceEmail);
                }

                if (reference.Relationship.HasValue)
                {
                    _logger.Debug(" Call to LoadRelationship()");
                    LoadRelationship();

                    if(RelationshipList != null)
                    {
                        foreach (var relationshipItem in RelationshipList)
                        {
                            if (relationshipItem.Value == reference.Relationship.Value)
                            {
                                ltReferencesRelationship.Text = HttpUtility.HtmlEncode(relationshipItem.Key);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(reference.Phone))
                {
                    phReferencesPhone.Visible = true;
                }
            }
        }

        private void LoadRelationship()
        {
            _logger.Debug("LoadRelationship() loaded");

            RelationshipList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.ReferencesRelationship>();
        }

        /// <summary>
        /// Returns the generated HTML markup for a Control object
        /// </summary>
        private string RenderControl(Control control)
        {
            _logger.Debug("RenderControl() loaded");

            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }

        protected void PDFGetButton_Click(object sender, EventArgs e)
        {
            _logger.Debug("PDFGetButton_Click() loaded (This Generates profile PDF)");

            //define full virtual path
            var fullPath = "~/usercontrols/member/ucCVProfileDownload.ascx";

            //initialize a new page to host the control
            Page page = new Page();
            //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
            page.EnableEventValidation = false;

            //load the control and add it to the page's form
            JXTPortal.Website.usercontrols.member.ucCVProfileDownload control = (JXTPortal.Website.usercontrols.member.ucCVProfileDownload)page.LoadControl(fullPath);

            control.Setup(currentMemberID);

            page.Controls.Add(control);

            //call RenderControl method to get the generated HTML
            string html = RenderControl(page);

            byte[] file = new PDFCreator().ConvertHTMLToPDF(html);

            Response.AddHeader("content-disposition", @"attachment;filename=""MyFile.pdf""");

            Response.OutputStream.Write(file, 0, file.Length);
            Response.ContentType = "application/pdf";
            Response.End();
        }

        private string JoinText(List<string> texts)
        {
            _logger.Debug("JoinText() loaded");

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

        private void loadCountries()
        {
            _logger.Debug("loadCountries() loaded");

            countryList = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);
        }

        private void LoadCalendar()
        {
            _logger.Debug("Loadcalender() loaded");

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
        }

        private void LoadMemberProficiency()
        {
            _logger.Debug("LoadMemberProficiency() loaded");

            ProficiencyList = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.LanguagesProfieciency>();
        }

        protected string GetCurrency(string locationID)
        {
            _logger.Debug("GetCurrency() Loaded");

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
                {
                    _logger.DebugFormat("Location with locationId {0}, doesnt exist(null or empty)", locationID);
                }
            }
            else
            {
                _logger.Debug("location ID is Null");
            }

            return currency;
        }

        private void AssignSectionTitle()
        {
            _logger.Debug("AssignSectionTitle() loaded");

            string strProfile = CommonFunction.GetResourceValue("LabelPublicProfile");
            string strSummary = CommonFunction.GetResourceValue("LabelPublicProfileSummary");
            string strPersonalDetails = CommonFunction.GetResourceValue("LabelPublicProfilePersonalDetails");
            string strDirectorship = CommonFunction.GetResourceValue("LabelPublicProfileDirectorship");
            string strExperience = CommonFunction.GetResourceValue("LabelPublicProfileExperience");
            string strEducation = CommonFunction.GetResourceValue("LabelPublicProfileEducation");
            string strSkills = CommonFunction.GetResourceValue("LabelPublicProfileSkills");
            string strMemberships = CommonFunction.GetResourceValue("LabelPublicProfileCertification");
            string strLicenses = CommonFunction.GetResourceValue("LabelPublicProfileLicences");
            string strRolePreferences = CommonFunction.GetResourceValue("LabelPublicProfileRolePreferences");
            string strCv = CommonFunction.GetResourceValue("LabelPublicProfileResume");
            string strAttachCoverLetter = CommonFunction.GetResourceValue("LabelPublicProfileCoverLetter");
            string strLanguages = CommonFunction.GetResourceValue("LabelPublicProfileLanguage");
            string strReferences = CommonFunction.GetResourceValue("LabelPublicProfileReferences");
            string strCustomQuestion = CommonFunction.GetResourceValue("LabelPublicProfileCustomQuestions");


            ltTitleProfile.Text = HttpUtility.HtmlEncode(strProfile);
            ltTitleSummary.Text = HttpUtility.HtmlEncode(strSummary);
            ltTitleMyPersonalDetails.Text = HttpUtility.HtmlEncode(strPersonalDetails);
            //ltTitleDirectorship.Text = HttpUtility.HtmlEncode(strDirectorship);
            ltTitleExperience.Text = HttpUtility.HtmlEncode(strExperience);
            ltTitleEducation.Text = HttpUtility.HtmlEncode(strEducation);
            ltTitleSkills.Text = HttpUtility.HtmlEncode(strSkills);
            ltTitleCertification.Text = HttpUtility.HtmlEncode(strMemberships);
            ltTitleLicenses.Text = HttpUtility.HtmlEncode(strLicenses);
            ltTitleRolePreferences.Text = HttpUtility.HtmlEncode(strRolePreferences);
            ltTitleResume.Text = HttpUtility.HtmlEncode(strCv);
            ltTitleCoverLetter.Text = HttpUtility.HtmlEncode(strAttachCoverLetter);
            ltTitleLanguage.Text = HttpUtility.HtmlEncode(strLanguages);
            ltTitleReferences.Text = HttpUtility.HtmlEncode(strReferences);
            //ltTitleCustomQuestions.Text = HttpUtility.HtmlEncode(strCustomQuestion);

            _logger.Debug("End of AssignSectionTitle() Method");
        }

        private int GetLatestResumeID()
        {
            _logger.Debug("GetLatestResumeID() method loaded");

            var latestResume = MemberFilesService.GetByMemberId(currentMemberID).Where(file => file.DocumentTypeId == 2).OrderByDescending(file => file.LastModifiedDate).FirstOrDefault();

            if (latestResume != null)
            {
                _logger.DebugFormat("Latest resume Found! Returning File ID: {0}", latestResume.MemberFileId);
                return latestResume.MemberFileId;
            }
            else
            {
                _logger.Debug("No resume found! Returning 0");
                return 0; 
            }
        }
    }
}