using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;
using System.Configuration;
using System.Xml;

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

        private List<ListItem> MonthList;
        private int MinExperienceEntry = 0;
        private int MinEducationEntry = 0;

        #endregion

        #region Properties

        protected string MemberUrlExtension
        {
            get
            {
                if ((Request.QueryString["memberurlextension"] != null))
                {
                    _memberurlextension = Request.QueryString["memberurlextension"].ToString();
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MemberUrlExtension))
            {
                JXTPortal.Entities.Members member = MembersService.GetByMemberId(Convert.ToInt32(MemberUrlExtension));

                if (member != null)
                {
                    LoadCalendar();
                    LoadMemberInfo(member);
                    SetAttachResume(member.MemberId);
                    SetAttachCoverletter(member.MemberId);
                    SetWorkExperience(member.MemberId);
                    SetEducation(member.MemberId);
                    LoadSkills(member.MemberId);
                    SetCertifications(member.MemberId);
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
        }

        

        public void LoadMemberInfo(Entities.Members member)
        {
            ltTitle.Text = HttpUtility.HtmlEncode(member.Title);
            ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
            ltLastName.Text = HttpUtility.HtmlEncode(member.Surname);
            ltHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
            ltlLastModifiedDate.Text = HttpUtility.HtmlEncode(member.LastModifiedDate);

             
            JXTPortal.Entities.MemberWizard memberWizard = null;

            using (memberWizard = MemberWizardService.GetAll().Find(s => s.SiteId.Equals(SessionData.Site.SiteId) && s.GlobalTemplate.Equals(false)))
            {
                if (memberWizard == null)
                {
                    memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));
                }
            }

            AssignSectionTitle(memberWizard);

            // Profile PIcture
            if (!string.IsNullOrWhiteSpace(member.ProfilePicture))
            {
                profilePic.ImageUrl = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberUploadPicturePaths"], member.ProfilePicture);
            }

            // Availability Status
            if (member.AvailabilityId.HasValue && member.AvailabilityId > 0)
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

            // Availability Date
            if (member.AvailabilityFromDate.HasValue)
            {
                ltAvailableDayFrom.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-clock-o highlight'></span><span id='availability-date'> {1}</span></div>",
                                                CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"), member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
            }

            // Last Modified Date
            if (member.LastModifiedDate.HasValue)
            {
                ltlLastModifiedDate.Text = string.Format(@"<div class='col-sm-6'><p class='last-modified-date'><strong>{0}:</strong> {1}</p></div>",
                                                                CommonFunction.GetResourceValue("LabelLastModified"), member.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat));
            }

            // Load Member Summary
            loadSummary(member);

            //Load Member Personal Details
            loadPersonalDetails(member);


        }

        public void loadSummary(Entities.Members member)
        {
            string summary = member.ShortBio;

            if (!string.IsNullOrWhiteSpace(summary))
            {
                ltSummary.Text = HttpUtility.HtmlEncode(member.ShortBio);
            }
            else
            {
                ltSummary.Text = CommonFunction.GetResourceValue("LabelMissingInformation");
            }
        }

        public void loadPersonalDetails(Entities.Members member)
        {
            //Email
            if (!string.IsNullOrWhiteSpace(member.EmailAddress))
            {
                ltEmail.Text = HttpUtility.HtmlEncode(member.EmailAddress);
            }
            else
            {
                ltEmail.Text = CommonFunction.GetResourceValue("LabelMissingInformation");
            }  
          
            //DOB
            if (member.DateOfBirth.HasValue)
            {
                ltDateOfBirth.Text = string.Format("<span class='highlight dob-heading'>{0}</span><span class='personal-detail-content dob'>{1}</span>", CommonFunction.GetResourceValue("LabelDateOfBirth"), member.DateOfBirth.Value.ToString(SessionData.Site.DateFormat));
            }
            else
            {
                ltDateOfBirth.Text = string.Format("<span class='highlight dob-heading'>{0}</span><span class='personal-detail-content dob missing'>{1}</span>", CommonFunction.GetResourceValue("LabelDateOfBirth"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }

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
                {
                    ltAddress1.Text = string.Format("<span class='address1'>{0}</span>", HttpUtility.HtmlEncode(member.Address1));
                }

                if (!string.IsNullOrWhiteSpace(member.Address2))
                {
                    ltAddress2.Text = string.Format("<span class='address2'>{0}</span>", HttpUtility.HtmlEncode(member.Address2));
                }

                if (!string.IsNullOrWhiteSpace(member.Suburb))
                {
                    ltCity.Text = string.Format("<span class='addCity'>{0}</span>", HttpUtility.HtmlEncode(member.Suburb));
                }

                if (!string.IsNullOrWhiteSpace(member.States))
                {
                    ltState.Text = string.Format("<span class='addState'>{0}</span>", HttpUtility.HtmlEncode(member.States));

                }

                if (!string.IsNullOrWhiteSpace(member.PostCode))
                {
                    ltPostcode.Text = string.Format("<span class='addPostcode'>{0}</span>", HttpUtility.HtmlEncode(member.PostCode));
                }


                if (!string.IsNullOrWhiteSpace(member.CountryId.ToString()))
                {
                    ltCountry.Text = string.Format("<span class='addCountry'>{0}</span>", HttpUtility.HtmlEncode(getCountryName(member.CountryId)));
                }                
            }

            //second email
            if (string.IsNullOrWhiteSpace(member.SecondaryEmail))
            {
                ltSecondaryEmail.Text = string.Format("<span class='highlight secondary-email-heading'>{0}</span><span class='personal-detail-content secondary-email missing'>{1}</span>", CommonFunction.GetResourceValue("LabelSecondaryEmail"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                ltSecondaryEmail.Text = string.Format("<span class='highlight secondary-email-heading'>{0}</span><span class='personal-detail-content secondary-email'>{1}</span>",
                                                    CommonFunction.GetResourceValue("LabelSecondaryEmail"), HttpUtility.HtmlEncode(member.SecondaryEmail));
            }

            //homephone
            if (string.IsNullOrWhiteSpace(member.HomePhone))
            {
                ltPhoneNumber.Text = string.Format("<span class='highlight ph_home_numb-heading'>{0}</span><span class='personal-detail-content ph_home_numb missing'>{1}</span>",
                                                       CommonFunction.GetResourceValue("LabelPhoneHome"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                ltPhoneNumber.Text = string.Format("<span class='highlight ph_home_numb-heading'>{0}</span><span class='personal-detail-content ph_home_numb'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPhoneHome"), HttpUtility.HtmlEncode(member.HomePhone));
            }

            //mobile
            if (string.IsNullOrWhiteSpace(member.MobilePhone))
            {
                ltMobileNumber.Text = string.Format("<span class='highlight ph_mobile_numb-heading'>{0}</span><span class='personal-detail-content ph_mobile_numb missing'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPhoneMobile"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                ltMobileNumber.Text = string.Format("<span class='highlight ph_mobile_numb-heading'>{0}</span><span class='personal-detail-content ph_mobile_numb'>{1}</span>",
                                        CommonFunction.GetResourceValue("LabelPhoneMobile"), HttpUtility.HtmlEncode(member.MobilePhone));
            }

            //passport number
            if (string.IsNullOrWhiteSpace(member.PassportNo))
            {
                ltPassportNumber.Text = string.Format("<span class='highlight ph_passport_numb-heading'>{0}</span><span class='personal-detail-content ph_passport_numb missing'>{1}</span>",
                                                        CommonFunction.GetResourceValue("LabelPassportNumber"), CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                ltPassportNumber.Text = string.Format("<span class='highlight ph_passport_numb-heading'>{0}</span><span class='personal-detail-content ph_passport_numb'>{1}</span>",
                                        CommonFunction.GetResourceValue("LabelPassportNumber"), HttpUtility.HtmlEncode(member.PassportNo));
            }

            //mailing address
            if (string.IsNullOrWhiteSpace(member.MailingAddress1)
                && string.IsNullOrWhiteSpace(member.MailingAddress2)
                && string.IsNullOrWhiteSpace(member.MailingSuburb)
                && string.IsNullOrWhiteSpace(member.MailingStates)
                && string.IsNullOrWhiteSpace(member.MailingPostCode)
            )
            {
                ltMailingAddress1.Text = string.Format("<span class='mailing-address1 missing'>{0}</span>", 
                                                        CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(member.MailingAddress1))
                {
                    ltMailingAddress1.Text = string.Format("<span class='mailing-address1'>{0}</span>", HttpUtility.HtmlEncode(member.MailingAddress1));
                }

                if (!string.IsNullOrWhiteSpace(member.MailingAddress2))
                {
                    ltMailingAddress2.Text = string.Format("<span class='mailing-address2'>{0}</span>", HttpUtility.HtmlEncode(member.MailingAddress2));
                }

                if (!string.IsNullOrWhiteSpace(member.MailingSuburb))
                {
                    ltMailingCity.Text = string.Format("<span class='mailing-City'>{0}</span>", HttpUtility.HtmlEncode(member.MailingSuburb));
                }

                if (!string.IsNullOrWhiteSpace(member.MailingStates))
                {
                    ltMailingState.Text = string.Format("<span class='mailing-State'>{0}</span>", HttpUtility.HtmlEncode(member.MailingStates));
                }

                if (!string.IsNullOrWhiteSpace(member.MailingPostCode))
                {
                    ltMailingPostcode.Text = string.Format("<span class='mailing-Postcode'>{0}</span>", HttpUtility.HtmlEncode(member.MailingPostCode));
                }

                if (member.MailingCountryId.HasValue)
                {
                    ltMailingCountry.Text = string.Format("<span class='addCountry'>{0}</span>", HttpUtility.HtmlEncode(getCountryName(member.CountryId)));
                }
            }

            //preferred line
            if (member.PreferredLine == 0)
            {
                ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content missing'><span class='preferred-line'>{1}</span></span>",
                                                    CommonFunction.GetResourceValue("LabelPreferredLine"), 
                                                    CommonFunction.GetResourceValue("LabelMissingInformation"));
            }
            else
            {
                if (member.PreferredLine == 1)
                {
                    ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content'><span class='preferred-line'>{1}</span></span>",
                                                        CommonFunction.GetResourceValue("LabelPreferredLine"), 
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneHome")));
                }
                else if (member.PreferredLine == 2)
                {
                    ltLineSelected.Text = string.Format("<span class='highlight line-heading'>{0}</span><span class='personal-detail-content'><span class='preferred-line'>{1}</span></span>",
                                                        CommonFunction.GetResourceValue("LabelPreferredLine"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelPhoneMobile")));
                }
            }
            
        }

        public string getCountryName(int countryID)
        {
            SiteCountriesService _sitecountry = new SiteCountriesService();

            var memberCountry = _sitecountry.GetByCountryId(countryID).FirstOrDefault();

            var countryName = memberCountry.SiteCountryName;

            return countryName;
        }

        private int SetAttachResume(int memberID)
        {
            using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(memberID))
            {
                resumes.Filter = "DocumentTypeId = 2";

                rptResume.DataSource = resumes;
                rptResume.DataBind();

                phAddEntryTextResume.Visible = (resumes.Count == 0);
            }

            return 0;
        }

        protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltResumeFileName = e.Item.FindControl("ltResumeFileName") as Literal;
                HyperLink hlResumeDownload = e.Item.FindControl("hlResumeDownload") as HyperLink;
                
                MemberFiles resume = e.Item.DataItem as MemberFiles;

                ltResumeFileName.Text = (string.IsNullOrEmpty(resume.MemberFileTitle)) ? HttpUtility.HtmlEncode(resume.MemberFileName) : HttpUtility.HtmlEncode(resume.MemberFileTitle);
                hlResumeDownload.NavigateUrl = "/download.aspx?type=mf&id=" + resume.MemberFileId.ToString();
            }
        }

        private void SetAttachCoverletter(int memberID)
        {
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltCoverLetterFileName = e.Item.FindControl("ltCoverLetterFileName") as Literal;
                HyperLink hlCoverLetterDownload = e.Item.FindControl("hlCoverLetterDownload") as HyperLink;
                LinkButton lbCoverLetterDelete = e.Item.FindControl("lbCoverLetterDelete") as LinkButton;

                MemberFiles coverletter = e.Item.DataItem as MemberFiles;

                ltCoverLetterFileName.Text = (string.IsNullOrEmpty(coverletter.MemberFileTitle)) ? HttpUtility.HtmlEncode(coverletter.MemberFileName) : HttpUtility.HtmlEncode(coverletter.MemberFileTitle);
                hlCoverLetterDownload.NavigateUrl = "/download.aspx?type=mf&id=" + coverletter.MemberFileId.ToString();
            }
        }

        private int SetWorkExperience(int memberID)
        {
            using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(memberID))
            {
                memberpositions.Filter = "isDirectorship = false";
                rptExperience.DataSource = memberpositions.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptExperience.DataBind();

                phAddEntryTextExperience.Visible = (memberpositions.Count <= MinExperienceEntry);

            }

            return 0;
        }

        protected void rptExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
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
            }
        }

        private int SetEducation(int memberID)
        {
            using (TList<Entities.MemberQualification> membereducations = MemberQualificationService.GetByMemberId(memberID))
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

                phAddEntryTextEducation.Visible = (membereducations.Count <= MinEducationEntry);

            }

            return 0;
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

                Entities.MemberQualification education = e.Item.DataItem as Entities.MemberQualification;

                var educationdate = calculateEducationTimePeriod(education);
                
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
            int currentMemberID = memberID;

            using (JXTPortal.Entities.Members objMembers = MembersService.GetByMemberId(currentMemberID))
            {
                if (objMembers != null && objMembers.SiteId == SessionData.Site.SiteId)
                {
                    if (!string.IsNullOrEmpty(objMembers.Skills))
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltSkill = e.Item.FindControl("ltSkill") as Literal;

                string skillStr = e.Item.DataItem as string;

                ltSkill.Text = HttpUtility.HtmlEncode(skillStr);
            }
        }

        private string calculateEducationTimePeriod(Entities.MemberQualification education)
        {
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

            return educationdate;
        }

        private int SetCertifications(int memberID)
        {
            using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(memberID))
            {
                rptCertification.DataSource = membercertificates.OrderByDescending(s => s.StartYear).ThenByDescending(s => s.StartMonth);
                rptCertification.DataBind();

                phAddEntryTextCertificates.Visible = (membercertificates.Count <= 0);
            }

            return 0;
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

        private void LoadCalendar()
        {
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
                        // CV
                        XmlNode cvnode = infonode.SelectSingleNode("CV");

                        if (cvnode != null && !string.IsNullOrWhiteSpace(cvnode.InnerText))
                        { 
                            strCvInfo = cvnode.InnerText; 
                        }

                        // Preference Roles
                        XmlNode rolepreferencesnode = infonode.SelectSingleNode("RolePreferences");

                        if (rolepreferencesnode != null && !string.IsNullOrWhiteSpace(rolepreferencesnode.InnerText))
                        { 
                            strRolePreferencesInfo = rolepreferencesnode.InnerText; 
                        }

                        // Education
                        XmlNode educationnode = infonode.SelectSingleNode("Education");

                        if (educationnode != null && !string.IsNullOrWhiteSpace(educationnode.InnerText))
                        { 
                            strEducationInfo = educationnode.InnerText; 
                        }

                        // Membership
                        XmlNode membershipsnode = infonode.SelectSingleNode("Memberships");

                        if (membershipsnode != null && !string.IsNullOrWhiteSpace(membershipsnode.InnerText))
                        { 
                            strMembershipsInfo = membershipsnode.InnerText; 
                        }

                        // Experience
                        XmlNode experiencenode = infonode.SelectSingleNode("Experience");

                        if (experiencenode != null && !string.IsNullOrWhiteSpace(experiencenode.InnerText))
                        { 
                            strExperienceInfo = experiencenode.InnerText; 
                        }

                        // Sills
                        XmlNode skillsnode = infonode.SelectSingleNode("Skills");

                        if (skillsnode != null && !string.IsNullOrWhiteSpace(skillsnode.InnerText))
                        { 
                            strSkillsInfo = skillsnode.InnerText; 
                        }

                        // Directorship
                        XmlNode directorshipnode = infonode.SelectSingleNode("Directorship");

                        if (directorshipnode != null && !string.IsNullOrWhiteSpace(directorshipnode.InnerText))
                        { 
                            strDirectorshipInfo = directorshipnode.InnerText; 
                        }

                        // Summary
                        XmlNode summarynode = infonode.SelectSingleNode("Summary");

                        if (summarynode != null && !string.IsNullOrWhiteSpace(summarynode.InnerText))
                        { 
                            strSummaryInfo = summarynode.InnerText; 
                        }

                        // Personal Details
                        XmlNode personaldetailsnode = infonode.SelectSingleNode("PersonalDetails");

                        if (personaldetailsnode != null && !string.IsNullOrWhiteSpace(personaldetailsnode.InnerText))
                        { 
                            strPersonalDetailsInfo = personaldetailsnode.InnerText; 
                        }

                        // Licence
                        XmlNode licensesnode = infonode.SelectSingleNode("Licenses");

                        if (licensesnode != null && !string.IsNullOrWhiteSpace(licensesnode.InnerText))
                        { 
                            strLicensesInfo = licensesnode.InnerText; 
                        }

                        // Cover Letter
                        XmlNode attachcoverletternode = infonode.SelectSingleNode("AttachCoverLetter");

                        if (attachcoverletternode != null && !string.IsNullOrWhiteSpace(attachcoverletternode.InnerText))
                        { 
                            strAttachCoverLetterInfo = attachcoverletternode.InnerText; 
                        }

                        // Languages
                        XmlNode languagesnode = infonode.SelectSingleNode("Languages");

                        if (languagesnode != null && !string.IsNullOrWhiteSpace(languagesnode.InnerText))
                        { 
                            strLanguagesInfo = languagesnode.InnerText; 
                        }

                        // References
                        XmlNode referencesnode = infonode.SelectSingleNode("References");

                        if (referencesnode != null && !string.IsNullOrWhiteSpace(referencesnode.InnerText))
                        { 
                            strReferencesInfo = referencesnode.InnerText; 
                        }

                        // Custom Questions
                        XmlNode customquestionnode = infonode.SelectSingleNode("CustomQuestion");

                        if (customquestionnode != null && !string.IsNullOrWhiteSpace(customquestionnode.InnerText))
                        { 
                            strCustomQuestionInfo = customquestionnode.InnerText; 
                        }
                    }

                    foreach (XmlNode xmlnode in xmldoc.SelectNodes("MemberWizards/MemberWizard"))
                    {
                        XmlNode langnode = xmlnode.SelectSingleNode("LanguageID");

                        if (langnode != null && SessionData.Language.LanguageId == Convert.ToInt32(langnode.InnerText))
                        {
                            // Profile
                            XmlNode profilenode = xmlnode.SelectSingleNode("Profile");

                            if (profilenode != null && !string.IsNullOrWhiteSpace(profilenode.InnerText))
                            { 
                                strProfile = profilenode.InnerText; 
                            }

                            // CV
                            XmlNode cvnode = xmlnode.SelectSingleNode("CV");

                            if (cvnode != null && !string.IsNullOrWhiteSpace(cvnode.InnerText))
                            { 
                                strCv = cvnode.InnerText; 
                            }

                            // Role Preferences
                            XmlNode rolepreferencesnode = xmlnode.SelectSingleNode("RolePreferences");

                            if (rolepreferencesnode != null && !string.IsNullOrWhiteSpace(rolepreferencesnode.InnerText))
                            { 
                                strRolePreferences = rolepreferencesnode.InnerText; 
                            }

                            // Education
                            XmlNode educationnode = xmlnode.SelectSingleNode("Education");

                            if (educationnode != null && !string.IsNullOrWhiteSpace(educationnode.InnerText))
                            { 
                                strEducation = educationnode.InnerText; 
                            }

                            // Memberships
                            XmlNode membershipsnode = xmlnode.SelectSingleNode("Memberships");

                            if (membershipsnode != null && !string.IsNullOrWhiteSpace(membershipsnode.InnerText))
                            { 
                                strMemberships = membershipsnode.InnerText; 
                            }

                            // Experience
                            XmlNode experiencenode = xmlnode.SelectSingleNode("Experience");

                            if (experiencenode != null && !string.IsNullOrWhiteSpace(experiencenode.InnerText))
                            { 
                                strExperience = experiencenode.InnerText; 
                            }

                            // SKills
                            XmlNode skillsnode = xmlnode.SelectSingleNode("Skills");

                            if (skillsnode != null && !string.IsNullOrWhiteSpace(skillsnode.InnerText))
                            { 
                                strSkills = skillsnode.InnerText; 
                            }

                            // Directorship
                            XmlNode directorshipnode = xmlnode.SelectSingleNode("Directorship");
                            
                            if (directorshipnode != null && !string.IsNullOrWhiteSpace(directorshipnode.InnerText))
                            { 
                                strDirectorship = directorshipnode.InnerText; 
                            }

                            // Summary
                            XmlNode summarynode = xmlnode.SelectSingleNode("Summary");

                            if (summarynode != null && !string.IsNullOrWhiteSpace(summarynode.InnerText))
                            { 
                                strSummary = summarynode.InnerText; 
                            }

                            // Personal Details
                            XmlNode personaldetailsnode = xmlnode.SelectSingleNode("PersonalDetails");
                            
                            if (personaldetailsnode != null && !string.IsNullOrWhiteSpace(personaldetailsnode.InnerText))
                            { 
                                strPersonalDetails = personaldetailsnode.InnerText;
                            }

                            // Licence Node
                            XmlNode licensesnode = xmlnode.SelectSingleNode("Licenses");

                            if (licensesnode != null && !string.IsNullOrWhiteSpace(licensesnode.InnerText))
                            { 
                                strLicenses = licensesnode.InnerText; 
                            }

                            // Attach Coverletter
                            XmlNode attachcoverletternode = xmlnode.SelectSingleNode("AttachCoverLetter");
                            
                            if (attachcoverletternode != null && !string.IsNullOrWhiteSpace(attachcoverletternode.InnerText))
                            { 
                                strAttachCoverLetter = attachcoverletternode.InnerText;
                            }

                            // Languages
                            XmlNode languagesnode = xmlnode.SelectSingleNode("Languages");

                            if (languagesnode != null && !string.IsNullOrWhiteSpace(languagesnode.InnerText))
                            { 
                                strLanguages = languagesnode.InnerText;
                            }

                            // References
                            XmlNode referencesnode = xmlnode.SelectSingleNode("References");

                            if (referencesnode != null && !string.IsNullOrWhiteSpace(referencesnode.InnerText))
                            { 
                                strReferences = referencesnode.InnerText; 
                            }

                            // Custom Questions
                            XmlNode customquestionnode = xmlnode.SelectSingleNode("CustomQuestion");

                            if (customquestionnode != null && !string.IsNullOrWhiteSpace(customquestionnode.InnerText))
                            { 
                                strCustomQuestion = customquestionnode.InnerText; 
                            }
                        }
                    }
                }
            }

            ltTitleProfile.Text = HttpUtility.HtmlEncode(strProfile);
            ltTitleSummary.Text = HttpUtility.HtmlEncode(strSummary);
            ltTitleMyPersonalDetails.Text = HttpUtility.HtmlEncode(strPersonalDetails);
            //ltTitleDirectorship.Text = HttpUtility.HtmlEncode(strDirectorship);
            ltTitleExperience.Text = HttpUtility.HtmlEncode(strExperience);
            ltTitleEducation.Text = HttpUtility.HtmlEncode(strEducation);
            ltTitleSkills.Text = HttpUtility.HtmlEncode(strSkills);
            ltTitleCertification.Text = HttpUtility.HtmlEncode(strMemberships);
           // ltTitleLicenses.Text = HttpUtility.HtmlEncode(strLicenses);
            //ltTitleRolePreferences.Text = HttpUtility.HtmlEncode(strRolePreferences);
           // ltRolePreferencesEditTitle.Text = HttpUtility.HtmlEncode(strRolePreferences);
            ltTitleResume.Text = HttpUtility.HtmlEncode(strCv);
            ltTitleCoverLetter.Text = HttpUtility.HtmlEncode(strAttachCoverLetter);
           // ltTitleLanguage.Text = HttpUtility.HtmlEncode(strLanguages);
           // ltTitleReferences.Text = HttpUtility.HtmlEncode(strReferences);
           // ltTitleCustomQuestions.Text = HttpUtility.HtmlEncode(strCustomQuestion);
            
        }
    }
}