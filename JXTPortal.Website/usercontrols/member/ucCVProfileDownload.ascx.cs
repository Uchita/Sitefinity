using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using System.Text;
using System.Data;
using JXTPortal.Common;
using System.Xml;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucCVProfileDownload : System.Web.UI.UserControl
    {
        
        private List<ListItem> DayList;
        private List<ListItem> MonthList;
        private List<ListItem> YearList;
        private List<Countries> CountryList;

        #region Service Declarations

        private MembersService _membersService;

        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
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
        private MemberMembershipsService _MemberMembershipsService;

        private MemberMembershipsService MemberMembershipsService
        {
            get
            {
                if (_MemberMembershipsService == null)
                {
                    _MemberMembershipsService = new MemberMembershipsService();
                }
                return _MemberMembershipsService;
            }
        }
        private MemberQualificationService _MemberQualificationService;

        private MemberQualificationService MemberQualificationService
        {
            get
            {
                if (_MemberQualificationService == null)
                {
                    _MemberQualificationService = new MemberQualificationService();
                }
                return _MemberQualificationService;
            }
        }

        private MemberWizardService _memberwizardservice = null;

        private MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberwizardservice == null)
                {
                    _memberwizardservice = new MemberWizardService();
                }
                return _memberwizardservice;
            }
        }

        private MemberStatusService _memberstatusservice = null;

        private MemberStatusService MemberStatusService
        {
            get
            {
                if (_memberstatusservice == null)
                {
                    _memberstatusservice = new MemberStatusService();
                }
                return _memberstatusservice;
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

        private SiteWorkTypeService _SiteWorkTypesservice = null;

        private SiteWorkTypeService SiteWorkTypesService
        {
            get
            {
                if (_SiteWorkTypesservice == null)
                {
                    _SiteWorkTypesservice = new SiteWorkTypeService();
                }
                return _SiteWorkTypesservice;
            }
        }

        private SiteProfessionService _siteprofessionservice = null;

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

        private SiteRolesService _siterolesservice = null;

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

        private SiteLocationService _sitelocationservice = null;

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

        private SiteAreaService _siteareaservice = null;

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
        
        private SiteWorkTypeService _siteworktypeservice = null;

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

        private MemberFilesService _MembersFilesservice = null;

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_MembersFilesservice == null)
                {
                    _MembersFilesservice = new MemberFilesService();
                }
                return _MembersFilesservice;
            }
        }

        private MemberPositionsService _MemberPositionsService = null;

        private MemberPositionsService MemberPositionsService
        {
            get
            {
                if (_MemberPositionsService == null)
                {
                    _MemberPositionsService = new MemberPositionsService();
                }
                return _MemberPositionsService;
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
        #endregion

        #region Variable Declarations

        private Entities.MemberWizard _memberWizard;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupPageDetails(SessionData.Member.MemberId);
        }

        public void Setup(int MemberId)
        {
            SetupPageDetails(MemberId);
        }

        private void SetupPageDetails(int MemberId)
        {
            //setup header/footer image
            // IMPORTANT - for the PDF logos to work 
            string imageURL = "http://jxt1.com.jxt1.com/admin/getadminlogo.aspx?siteid=" + SessionData.Site.SiteId;
            imgHeaderLogo.ImageUrl = imageURL;
            //imgFooterLogo.ImageUrl = imageURL;

            SetMemberInformation(MemberId);
        }


        #region Member Profile

        private bool SetMemberInformation(int MemberId)
        {
            LoadCountry();

            _memberWizard = GetMemberWizardEntityForCurrentSite();

            using (Entities.Members objMembers = MembersService.GetByMemberId(MemberId))
            {
                ltlName.Text = string.Format("{0} {1}", HttpUtility.HtmlEncode(objMembers.FirstName), HttpUtility.HtmlEncode(objMembers.Surname));
                ltlHeadline.Text = objMembers.PreferredJobTitle;
                ltlShortBio.Text = Utils.ReplaceNewlineWithBRTags(HttpUtility.HtmlEncode(objMembers.ShortBio));

                string addressDisplay = string.Empty;
                if (!string.IsNullOrEmpty(objMembers.Suburb) && !string.IsNullOrEmpty(objMembers.States))
                    addressDisplay = "<span class='fa fa-map-marker'></span>" + HttpUtility.HtmlEncode(objMembers.Suburb) + ", " + HttpUtility.HtmlEncode(objMembers.States) + "<br>";

                ltlMemberContacts.Text =
                    String.Format(@"
<span class='fa fa-envelope'></span>{0}<br>
{1}
{2}
{3}
"
                                            , HttpUtility.HtmlEncode(objMembers.EmailAddress)
                                            , addressDisplay
                                            , objMembers.HomePhone != null && !string.IsNullOrEmpty(objMembers.HomePhone.Trim()) ? "<span class='fa fa-phone'></span>" + HttpUtility.HtmlEncode(objMembers.HomePhone.Trim()) + "<br>" : string.Empty
                                            , objMembers.MobilePhone != null && !string.IsNullOrEmpty(objMembers.MobilePhone.Trim()) ? "<span class='fa fa-mobile'></span>" + HttpUtility.HtmlEncode(objMembers.MobilePhone.Trim()) : string.Empty
                                           );

                if (!string.IsNullOrWhiteSpace(objMembers.ProfilePicture))
                    imgMemberProfile.ImageUrl = "http://10.0.20.87:84/media/candidate/" + objMembers.ProfilePicture;

                //SetCurrentStatus(objMembers.MemberStatusId);

                if (objMembers.AvailabilityId.HasValue && objMembers.AvailabilityId.Value > 0)
                {
                    ltlCurrentStatus.Text = string.Format(@"
<div class='aside-section faGroup'>
    <h2>{0}</h2>
    <p><span class='fa fa-eye'></span>{1}</p>
</div>
", CommonFunction.GetResourceValue("LabelSeekingStatus"), HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)objMembers.AvailabilityId))));
                }

                if (objMembers.AvailabilityFromDate.HasValue)
                {
                    ltAvailableDayFrom.Text = string.Format(@"
<div class='aside-section faGroup'>
    <h2>{0}</h2>
    <p><span class='fa fa-clock-o'></span>{1}</p>
</div>", CommonFunction.GetResourceValue("LabelAvailableFrom"), objMembers.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
                }


                SetClassifications(objMembers);

                AssignSectionTitle(_memberWizard);
                if (_memberWizard.EducationPoints >= 0)
                    SetQualifications(MemberId);
                //SetMemberships(objMembers.Memberships);
                if (_memberWizard.DirectorshipPoints >= 0)
                    SetDirectorship(MemberId);
                else
                    phDirectorship.Visible = false;

                if (_memberWizard.ExperiencePoints >= 0)
                    SetExperience(MemberId);
                if (_memberWizard.SkillsPoints >= 0)
                    SetSkills(objMembers.Skills);

                if (_memberWizard.MembershipsPoints >= 0)
                {
                    using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(MemberId))
                    {
                        if (membercertificates != null && membercertificates.Count > 0)
                        {
                            ltlCertification.Text = string.Empty;
                            foreach (var item in membercertificates.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth))
                            {
                                List<string> lastLineDisplay = new List<string>();
                                if( !string.IsNullOrWhiteSpace(HttpUtility.HtmlEncode(item.CertificationUrl))) 
                                    lastLineDisplay.Add(item.CertificationUrl);
                                if(!string.IsNullOrWhiteSpace(item.LicenseNumber))
                                    lastLineDisplay.Add(string.Format("{0}: {1}", CommonFunction.GetResourceValue("LabelCertificateMembershipNumber"), HttpUtility.HtmlEncode(item.LicenseNumber)));
                                    
                                ltlCertification.Text = string.Format(@"
{0}<div class='section-group'>
<p class='sub-heading'><strong>{1}</strong></p>
<h3 class='title'>{2}</h3>
{3}
<p>{4}</p>
</div>
", ltlCertification.Text, HttpUtility.HtmlEncode(item.CertificationAuthority), HttpUtility.HtmlEncode(item.MemberCertificateMembershipName),
     item.DoesnotExpire.HasValue && item.DoesnotExpire.Value ? CommonFunction.GetResourceValue("LabelCertificateDoesNotExpire") :
     (item.StartMonth.HasValue ? string.Format("<p class='date'><span class='start-date'><b class='month'>{0}</b> <b class='year'>{1}</b></span> - <span class='end-date'>{2}</span></p>",
     item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty,
                        item.StartYear,
                        (item.EndYear.HasValue ? CommonFunction.GetResourceValue("LabelCurrent") :
                                string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                    item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                    item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty))) : string.Empty)                                    
                                    ,
                                    String.Join(" | ", lastLineDisplay));
                            }

                            ltlCertification.Text = string.Format(@"
<div class='section'>
<h2>{0}</h2>
{1}     
<hr>
</div>
", ltTitleCertification.Text, ltlCertification.Text);


                        }                        
                    }
                }


                if (_memberWizard.LicensesPoints >= 0)
                {
                    using (TList<Entities.MemberLicenses> memberLicenses = MemberLicensesService.GetByMemberId(MemberId))
                    {
                        if (memberLicenses != null && memberLicenses.Count > 0)
                        {
                            LoadCalendar();

                            ltlLicenses.Text = string.Empty;

                            string licensedate = string.Empty;
                            string startmonth = string.Empty;
                            string endmonth = string.Empty;


                            string countryName = string.Empty;
                            Countries countries = new Countries();

                            foreach (var item in memberLicenses.OrderByDescending(s => s.IssueDate))
                            {

                                if (item.IssueDate.HasValue)
                                {
                                    foreach (ListItem month in MonthList)
                                    {
                                        if (month.Value == item.IssueDate.Value.Month.ToString())
                                        {
                                            startmonth = CommonFunction.GetResourceValue(month.Text);
                                            break;
                                        }
                                    }

                                    licensedate = string.Format("<span class='start-date'><b class='month'>{0}</b> <b class='year'>{1}</b></span>", startmonth, item.IssueDate.Value.Year.ToString());
                                }

                                if (item.ExpiryDate.HasValue)
                                {
                                    foreach (ListItem month in MonthList)
                                    {
                                        if (month.Value == item.ExpiryDate.Value.Month.ToString())
                                        {
                                            endmonth = CommonFunction.GetResourceValue(month.Text);
                                            break;
                                        }
                                    }

                                    if (!string.IsNullOrWhiteSpace(licensedate))
                                    {
                                        //licensedate += " - ";
                                    }

                                    licensedate += string.Format(" - <span class='end-date'>{0}</span>", endmonth + " " + item.ExpiryDate.Value.Year.ToString());
                                }
                                else
                                {
                                    licensedate += string.Format(" - <span class='end-date'>{0}</span>", CommonFunction.GetResourceValue("LabelCurrent"));
                                }

                                countryName = string.Empty;
                                if (item.CountryId.HasValue && item.CountryId.Value> 0)
                                {
                                    countries = CountryList.Where(s => s.CountryId == item.CountryId.Value).FirstOrDefault();
                                    if (countries != null)
                                        countryName = countries.CountryName;
                                }


                                ltlLicenses.Text = string.Format(@"
{0}
<div class='section-group'>
<p class='sub-heading'><strong>{1}</strong></p>
<h3 class='title'>{2}</h3>
{4}
<p class='date'>{3}</p>
</div>
", ltlLicenses.Text, HttpUtility.HtmlEncode(item.LicenseType), HttpUtility.HtmlEncode(item.MemberLicenseName),
        licensedate,
        (!string.IsNullOrWhiteSpace(item.State) || item.CountryId.HasValue) ?
            string.Format("<span class='fa fa-map-marker'></span> {0}", (!string.IsNullOrWhiteSpace(item.State) ? HttpUtility.HtmlEncode(item.State) + ", " : string.Empty) + countryName) : string.Empty
        );
                            }

                            ltlLicenses.Text = string.Format(@"
<div class='section'>
<h2>{0}</h2>
{1}     
<hr>
</div>
", ltTitleLicenses.Text, ltlLicenses.Text);

                            
                        }

                    }
                }


                if (_memberWizard.LanguagesPoints >= 0)
                {
                    using (TList<Entities.MemberLanguages> languages = MemberLanguagesService.GetByMemberId(MemberId))
                    {
                        if (languages != null && languages.Count > 0)
                        {
                            ltlLanguages.Text = string.Empty;
                            foreach (var item in languages)
                            {
                                ltlLanguages.Text = string.Format("{0} <li>{1}<br>- {2}</li>",
                                                                        ltlLanguages.Text,
                                                                        HttpUtility.HtmlEncode(item.Langauges),
                                                                        item.Profieciency.HasValue ? CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.LanguagesProfieciency)item.Profieciency)) : string.Empty);
                            }

                            ltlLanguages.Text = string.Format(@"
<div class='aside-section'>
    <h2>{0}</h2>
    <ul>
    {1} 
    </ul>
</div>", ltTitleLanguage.Text, ltlLanguages.Text);


                        }
                    }
                }


                if (_memberWizard.ReferencesPoints >= 0)
                {
                    using (TList<Entities.MemberReferences> memberreferences = MemberReferencesService.GetByMemberId(MemberId))
                    {
                        if (memberreferences != null && memberreferences.Count > 0)
                        {
                            ltlReferences.Text = string.Empty;
                            foreach (var item in memberreferences)
                            {
                                ltlReferences.Text = string.Format(@"
{0}<div class='section-group'>
    <p class='sub-heading'><strong>{1}</strong></p>
    <h3 class='title'>{2}</h3>
    <p class='sub-heading'>{3}</p>
    <div class='row'>
        {4}
        {5}
    </div>
</div>                            
                            ",
                                 ltlReferences.Text,
                                 HttpUtility.HtmlEncode(item.Company),
                                 HttpUtility.HtmlEncode(item.MemberReferenceName),
                                 HttpUtility.HtmlEncode(item.JobTitle),
                                 !string.IsNullOrWhiteSpace(item.Phone) ? "<div class='col-md-3'><span class='fa fa-phone'></span> " + HttpUtility.HtmlEncode(item.Phone) + "</div>" : string.Empty,
                                 item.Relationship.HasValue ? ("<div class='col-md-5'><strong>" + CommonFunction.GetResourceValue("LabelRelationship") + ":</strong> " + CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.ReferencesRelationship)item.Relationship)) + "</div>") : string.Empty);
                            }

                            ltlReferences.Text = string.Format(@"
<div class='section'>
<h2>{0}</h2>
{1} 
</div>", ltTitleReferences.Text, ltlReferences.Text);


                        }
                    }
                }
            }

            return true;
        }


            
        #endregion

        #region Member Wizard

        private void AssignSectionTitle(JXTPortal.Entities.MemberWizard memberWizard)
        {
            string strProfile = memberWizard.ProfileTitle;
            string strSummary = memberWizard.SummaryTitle;
            string strPersonalDetails = memberWizard.PersonalDetailsTitle;
            string strDirectorship = memberWizard.DirectorshipTitle;
            string strExperience = memberWizard.ExperienceTitle;
            string strEducation = memberWizard.EducationTitle;
            string stSkills = memberWizard.SkillsTitle;
            string strMemberships = memberWizard.MembershipsTitle;
            string strLicenses = memberWizard.LicensesTitle;
            string strRolePreferences = memberWizard.RolePreferencesTitle;
            string strCv = memberWizard.CvTitle;
            string strAttachCoverLetter = memberWizard.AttachCoverLetterTitle;
            string strLanguages = memberWizard.LanguagesTitle;
            string strReferences = memberWizard.ReferencesTitle;
            string strCustomQuestion = memberWizard.CustomQuestionTitle;

            if (memberWizard != null)
            {
                if (!string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(memberWizard.WizardLanguageXml);

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
                            { stSkills = skillsnode.InnerText; }
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
                        }
                    }
                }
            }


            ltTitleSummary.Text = HttpUtility.HtmlEncode(strSummary);
            ltTitleMyPersonalDetails.Text = HttpUtility.HtmlEncode(strPersonalDetails);
            ltlDirectorship.Text = "<h2>" + HttpUtility.HtmlEncode(strDirectorship) + "</h2>";
            ltlExperience.Text = "<h2>" + HttpUtility.HtmlEncode(strExperience) + "</h2>";
            ltlQualifications.Text = "<h2>" + HttpUtility.HtmlEncode(strEducation) + "</h2>";
            ltlSkills.Text = "<h2>" + HttpUtility.HtmlEncode(stSkills) + "</h2>";
            ltTitleCertification.Text = "<h2>" + HttpUtility.HtmlEncode(strMemberships) + "</h2>";
            ltTitleLicenses.Text = "<h2>" + HttpUtility.HtmlEncode(strLicenses) + "</h2>";
            ltlRolePreferences.Text = HttpUtility.HtmlEncode(strRolePreferences);
            
            ltTitleLanguage.Text = HttpUtility.HtmlEncode(strLanguages);
            ltTitleReferences.Text = HttpUtility.HtmlEncode(strReferences);
            

        }

        #endregion


        #region Locations

        protected string SetLocations(string strLocationID, string strAreaIDs)
        {
            string currency = string.Empty;

            int locationID = 0;

            StringBuilder strBuilder = new StringBuilder();
            LocationService LocationService = new LocationService();
            AreaService AreaService = new AreaService();
            if (!String.IsNullOrWhiteSpace(strLocationID) && int.TryParse(strLocationID, out locationID))
            {
                using (Entities.Location siteLocation = LocationService.GetByLocationId(locationID))
                {
                    if (siteLocation != null)
                    {
                        using (Countries country = CountriesService.GetByCountryId(siteLocation.CountryId))
                        {
                            if (country != null)
                            {
                                currency = country.Currency;
                            }
                        }

                        using (TList<Entities.Area> siteAreas = AreaService.GetByLocationId(locationID))
                        {
                            Entities.Area siteArea = new Entities.Area();
                            if (!String.IsNullOrWhiteSpace(strAreaIDs) && siteAreas != null && siteAreas.Count > 0)
                            {
                                List<int> strAreaValues = strAreaIDs.Split(',').Select(n => int.Parse(n)).ToList();
                                foreach (int intAreaValue in strAreaValues)
                                {
                                    if (intAreaValue != 0)
                                    {
                                        siteArea = siteAreas.Where(s => s.AreaId == intAreaValue).FirstOrDefault();
                                        if (siteArea != null)
                                        {
                                            if (strBuilder.Length > 0)
                                                strBuilder.AppendFormat(", {0}", siteArea.AreaName);
                                            else
                                                strBuilder.AppendFormat("{0}", siteArea.AreaName);
                                        }
                                    }
                                }
                            }
                        }

                        ltlLocations.Text = string.Format(@"<span class='fa fa-map-marker'></span> {0} - {1}", siteLocation.LocationName, strBuilder.ToString());
                    }
                }


            }



            /*
            if (String.IsNullOrWhiteSpace(ltlLocations.Text))
                ltlLocations.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");*/

            return currency;
        }

        #endregion

        #region Classification / Subclassification

        protected void SetClassifications(Entities.Members objMembers)
        {
            //objMembers.PreferredCategoryId, objMembers.PreferredSubCategoryId
            int classificationID = 0;

            if (!String.IsNullOrWhiteSpace(objMembers.PreferredCategoryId) && int.TryParse(objMembers.PreferredCategoryId, out classificationID))
            {
                Entities.SiteProfession profession = SiteProfessionService.GetTranslatedProfessionById(classificationID, SessionData.Site.UseCustomProfessionRole);

                if (profession != null)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    List<SiteRoles> siteRoles = SiteRolesService.GetTranslatedByProfessionID(classificationID, SessionData.Site.UseCustomProfessionRole);
                    SiteRoles siteRole = new SiteRoles();

                    if (!String.IsNullOrWhiteSpace(objMembers.PreferredSubCategoryId))
                    {
                        List<int> strRoleValues = objMembers.PreferredSubCategoryId.Split(',').Select(n => int.Parse(n)).ToList();
                        foreach (int intRoleValue in strRoleValues)
                        {
                            if (intRoleValue != 0)
                            {
                                siteRole = siteRoles.Where(s => s.RoleId == intRoleValue).FirstOrDefault();
                                if (siteRole != null)
                                {
                                    if (strBuilder.Length > 0)
                                        strBuilder.AppendFormat(", {0}", siteRole.SiteRoleName);
                                    else
                                        strBuilder.AppendFormat("{0}", siteRole.SiteRoleName);
                                }
                            }
                        }
                    }


                    ltlClassifications.Text = string.Format(@"
<h3 class='title'>{0}</h3>
<p>{1}</p>", profession.SiteProfessionName, strBuilder.ToString());

                }
            }

            // Set Worktypes
            SetWorkTypes(objMembers.WorkTypeId);

            // set Country / location / areas
            string currency = SetLocations(objMembers.LocationId, objMembers.AreaId);

            // Set Salary
            if (objMembers.PreferredSalaryId.HasValue && objMembers.PreferredSalaryId.Value > 0)
                ltlSalary.Text = string.Format("<p class='sub-heading'><strong>{0} - {3}{1} to {3}{2}</strong></p>",
                                                    CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Search.SalaryType)objMembers.PreferredSalaryId)), 
                                                    objMembers.PreferredSalaryFrom, 
                                                    objMembers.PreferredSalaryTo, 
                                                    currency);

            // Set Eligibility to work in
            if (!string.IsNullOrWhiteSpace(objMembers.EligibleToWorkIn))
            {
                string strEligibleToWorkIn = string.Empty;
                Countries country = new Countries();
                foreach (string split in objMembers.EligibleToWorkIn.Split(new char[] { ',' }))
                {
                    country = CountryList.Where(s => s.CountryId == int.Parse(split)).FirstOrDefault();

                    if (country != null)
                    {
                        if (!string.IsNullOrWhiteSpace(strEligibleToWorkIn))
                            strEligibleToWorkIn += ", " + country.CountryName;
                        else
                            strEligibleToWorkIn = country.CountryName;
                    }

                }

                ltlEligibleToWork.Text = string.Format("<h3 class='title'>{0}:</h3><p>{1}</p>", CommonFunction.GetResourceValue("LabelEligibleToWorkIn"), strEligibleToWorkIn);
            }


            /*
            if (String.IsNullOrWhiteSpace(ltlClassifications.Text))
                ltlClassifications.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");*/
        }

        #endregion

        #region Qualification

        protected void SetQualifications(int MemberId)
        {

            StringBuilder strBuilder = new StringBuilder();
            using (TList<Entities.MemberQualification> memberQualificationList = MemberQualificationService.GetByMemberId(MemberId))
            {

                if (memberQualificationList != null && memberQualificationList.Count > 0)
                {
                    string countryName = string.Empty;
                    Countries countries = new Countries();
                    foreach (Entities.MemberQualification item in memberQualificationList.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth))
                    {
                        countryName = string.Empty;
                        if (item.CountryId.HasValue && item.CountryId.Value > 0)
                        {
                            countries = CountryList.Where(s => s.CountryId == item.CountryId.Value).FirstOrDefault();
                            if (countries != null)
                                countryName = countries.CountryName;
                        }
                        

                        strBuilder.AppendFormat(@"
<div class='section-group'>
    <p class='sub-heading'><strong>{1}</strong></p>
    <h3 class='title'>{0} {6}</h3>
    {5}
    <p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>
</div>", 
       HttpUtility.HtmlEncode(item.Degree), 
       HttpUtility.HtmlEncode(item.SchoolName), 
       item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty,
       item.StartYear,
       item.Present.HasValue && item.Present.Value ? CommonFunction.GetResourceValue("LabelCurrent") :
                            string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                            item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                            item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty),
                                            (!string.IsNullOrWhiteSpace(item.City) || item.CountryId.HasValue) ?
                                                string.Format("<span class='fa fa-map-marker'></span> {0}", (!string.IsNullOrWhiteSpace(item.City) ? HttpUtility.HtmlEncode(item.City) + ", " : string.Empty) + countryName) : string.Empty, 
                                            item.QualificationLevelId.HasValue ? " (" + CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.QualificationLevel)item.QualificationLevelId)) + ")" : string.Empty 
                                            );
                    }
                    ltlQualificationList.Text = strBuilder.ToString();
                }
                else
                    ltlQualificationList.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
            }
        }

        /*
        protected void SetMemberships(string strMembership)
        {
            StringBuilder strBuilder = new StringBuilder();

            TList<Entities.MemberMemberships> MemberMembershipsList = MemberMembershipsService.CustomGetBySiteID(SessionData.Site.MasterSiteId);
            Entities.MemberMemberships memberMemberships = new Entities.MemberMemberships();

            if (!String.IsNullOrWhiteSpace(strMembership))
            {
                string[] strMembershipValues = strMembership.Split('|');
                int intMembershipID = 0;

                if (strMembershipValues.Count() > 0)
                {
                    foreach (string item in strMembershipValues)
                    {
                        // value example - 1|2|3|"MCAD Certificate"
                        if (int.TryParse(item, out intMembershipID))
                        {
                            memberMemberships = MemberMembershipsList.Where(s => s.MemberMembershipsId == intMembershipID).FirstOrDefault();
                            if (memberMemberships != null)
                                strBuilder.AppendFormat("<li>{0}</li>", memberMemberships.MemberMembershipsName);

                        }
                        else
                            strBuilder.AppendFormat("<li>{0}</li>", item);
                    }

                }
            }


        }*/

        #endregion

        #region Directorship

        protected void SetDirectorship(int MemberId)
        {

            StringBuilder strBuilder = new StringBuilder();
            using (TList<Entities.MemberPositions> memberPositionsList = MemberPositionsService.GetByMemberId(MemberId))
            {
                memberPositionsList.Filter = "IsDirectorship = true";
                string additionalrolesandresponsibilities = string.Empty;
                string[] splits = null;

                string typeOfDirectorship = string.Empty;

                if (memberPositionsList != null && memberPositionsList.Count > 0)
                {
                    foreach (Entities.MemberPositions item in memberPositionsList.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth))
                    {
                        additionalrolesandresponsibilities = string.Empty;
                        splits = item.AdditionalRolesAndResponsibilities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (splits.Length > 0)
                        {
                            foreach (string s in splits)
                            {

                                if (s.Contains("AuditCommittee"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "Audit Committee";
                                    else
                                        additionalrolesandresponsibilities += ", Audit Committee";
                                }

                                if (s.Contains("RiskCommittee"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "Risk Committee";
                                    else
                                        additionalrolesandresponsibilities += ", Risk Committee";
                                }

                                if (s.Contains("RemunerationCommittee"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "Remuneration Committee";
                                    else
                                        additionalrolesandresponsibilities += ", Remuneration Committee";
                                }

                                if (s.Contains("NominationsCommittee"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "Nominations Committee";
                                    else
                                        additionalrolesandresponsibilities += ", Nominations Committee";
                                }

                                if (s.Contains("OHSCommittee"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "OHS Committee";
                                    else
                                        additionalrolesandresponsibilities += ", OHS Committee";
                                }
                                if (s.Contains("Other"))
                                {
                                    if (string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                        additionalrolesandresponsibilities = "Other";
                                    else
                                        additionalrolesandresponsibilities += ", Other";
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(additionalrolesandresponsibilities))
                                additionalrolesandresponsibilities = string.Format("<p><strong>Additional Roles and responsibilities:</strong> {0}</p>", additionalrolesandresponsibilities);
                        }


                        typeOfDirectorship = string.Empty;
                        switch (item.TypeOfDirectorship)
                        {
                            case "chair":
                                typeOfDirectorship = "Chair";
                                break;
                            case "nonexecutiveDirector":
                                typeOfDirectorship = "Non-executive Director";
                                break;
                            case "executivedirector":
                                typeOfDirectorship = "Executive Director";
                                break;
                            case "managingdirector":
                                typeOfDirectorship = "Managing Director";
                                break;
                            case "other":
                                typeOfDirectorship = "Other";
                                break;
                            default:
                                break;
                        }
                        /*
                        <asp:ListItem Value="chair" Text="Chair" />
                        <asp:ListItem Value="nonexecutiveDirector" Text="Non-executive Director" />
                        <asp:ListItem Value="executivedirector" Text="Executive Director" />
                        <asp:ListItem Value="managingdirector" Text="Managing Director" />
                        <asp:ListItem Value="other" Text="Other" />*/

                        strBuilder.AppendFormat(@"


<div class='section-group'>
    <p class='sub-heading'><strong>{1}</strong> <span class='directorship-type'> | {8} </span>{6}</p>
    <h3 class='title'>{0}</h3>
    <p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>

    <p>{5}</p>

    {7}

    {9}
    
</div>
", HttpUtility.HtmlEncode(item.Title) // Format 0
, HttpUtility.HtmlEncode(item.CompanyName) // Format 1
, item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty// Format 2
, item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty // Format 3
, item.IsCurrent ? CommonFunction.GetResourceValue("LabelCurrent") :
                    string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                    item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                    item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty)  // Format 4
, Utils.ReplaceNewlineWithBRTags(HttpUtility.HtmlEncode(item.Summary)) // Format 5
, string.IsNullOrEmpty(item.OrganisationWebsite) ? string.Empty : String.Format(@"<span class='organisation-website'>| {0}</span>", HttpUtility.HtmlEncode(item.OrganisationWebsite)) // Format 6
, string.IsNullOrEmpty(item.ResponsibilitiesAndAchievements) ? string.Empty : string.Format("<p><strong>Responsibilities and Achievements:</strong></p><p>{0}</p>",
                                                                                        Utils.ReplaceNewlineWithBRTags(HttpUtility.HtmlEncode(item.ResponsibilitiesAndAchievements))) // Format 7
, typeOfDirectorship // Format 8
, string.IsNullOrEmpty(additionalrolesandresponsibilities) ? string.Empty : String.Format(@"{0}", additionalrolesandresponsibilities) // Format 9
                                    );

                    }

                    ltlDirectorshipList.Text = strBuilder.ToString();
                }
                else
                    ltlDirectorshipList.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
            }



        }

        #endregion

        #region Experience

        protected void SetExperience(int MemberId)
        {

            StringBuilder strBuilder = new StringBuilder();
            using (TList<Entities.MemberPositions> memberPositionsList = MemberPositionsService.GetByMemberId(MemberId))
            {
                memberPositionsList.Filter = "IsDirectorship = false";

                if (memberPositionsList != null && memberPositionsList.Count > 0)
                {
                    foreach (Entities.MemberPositions item in memberPositionsList.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth))
                    {
                        strBuilder.AppendFormat(@"
<div class='section-group'>
    <p class='sub-heading'><strong>{1}</strong></p>
    <h3 class='title'>{0}</h3>
    <p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>

    <p>{5}</p>
</div>
", HttpUtility.HtmlEncode(item.Title), HttpUtility.HtmlEncode(item.CompanyName),
           item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty,
           item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty,
           item.IsCurrent ? CommonFunction.GetResourceValue("LabelCurrent") :
                    string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                    item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                    item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty), Utils.ReplaceNewlineWithBRTags(HttpUtility.HtmlEncode(item.Summary)));

                    }

                    ltlExperienceList.Text = strBuilder.ToString();
                }
                else
                    ltlExperienceList.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
            }


        }

        #endregion

        #region WorkType

        protected void SetWorkTypes(string strWorkTypeID)
        {

            StringBuilder strBuilder = new StringBuilder();

            List<Entities.SiteWorkType> SiteWorkTypes = SiteWorkTypesService.GetTranslatedWorkTypes();
            Entities.SiteWorkType siteWorkType = new Entities.SiteWorkType();

            if (!String.IsNullOrWhiteSpace(strWorkTypeID))
            {
                List<int> strWorkTypeValues = strWorkTypeID.Split(',').Select(n => int.Parse(n)).ToList();
                if (strWorkTypeValues.Count() > 0)
                {
                    foreach (int intWorkTypeValue in strWorkTypeValues)
                    {
                        if (intWorkTypeValue != 0)
                        {
                            siteWorkType = SiteWorkTypes.Where(s => s.WorkTypeId == intWorkTypeValue).FirstOrDefault();
                            if (siteWorkType != null)
                            {
                                if (strBuilder.Length > 0)
                                    strBuilder.AppendFormat(", {0}", siteWorkType.SiteWorkTypeName);
                                else
                                    strBuilder.AppendFormat("{0}", siteWorkType.SiteWorkTypeName);
                            }
                        }
                    }

                    ltlWorktypes.Text = string.Format(@"<h3 class='title'>{0}</h3><p>{1}</p>", CommonFunction.GetResourceValue("LabelWorkType"), strBuilder.ToString());
                }
            }


            /*if (String.IsNullOrWhiteSpace(ltlWorktypes.Text))
                ltlWorktypes.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");*/
        }

        #endregion

        #region Skills

        protected void SetSkills(string strSkills)
        {
            StringBuilder strBuilder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(strSkills))
            {
                string[] strSkillsValues = strSkills.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (strSkillsValues.Count() > 0)
                {
                    foreach (string item in strSkillsValues)
                    {
                        strBuilder.AppendFormat("<li>{0}</li>", HttpUtility.HtmlEncode(item));

                    }

                    ltlSkillsTags.Text = string.Format(@"<ul>
									{0}
								</ul>", strBuilder.ToString());
                }

            }

            if (string.IsNullOrWhiteSpace(ltlSkillsTags.Text))
                ltlSkills.Text = string.Empty;
        }

        #endregion

        #region Private Helpers


        private void LoadCalendar()
        {
            DayList = new List<ListItem>();
            for (int i = 1; i <= 31; i++)
            {
                DayList.Add(new ListItem(i.ToString(), i.ToString()));
            }

            MonthList = new List<ListItem>();
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelJan"), "1"));
            MonthList.Add(new ListItem(CommonFunction.GetResourceValue("LabelFeb"), "1"));
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
            for (int i = 0; i < 100; i++)
            {
                int year = DateTime.Now.Year - i;
                YearList.Add(new ListItem(year.ToString(), year.ToString()));
            }
        }


        private void LoadCountry()
        {
            CountryList = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

            if (CountryList != null)
            {
                CountryList = CountryList.Where(c => c.Sequence != -1).OrderBy(c => c.CountryName).ToList();

            }
        }


        private Entities.MemberWizard GetMemberWizardEntityForCurrentSite()
        {
            Entities.MemberWizard res = MemberWizardService.GetMemberWizardBySite(SessionData.Site.MasterSiteId);
            if (res == null)
            {
                res = MemberWizardService.GetAll().Find(s => s.GlobalTemplate == true);
            }
            return res;
        }
        #endregion

    }
}