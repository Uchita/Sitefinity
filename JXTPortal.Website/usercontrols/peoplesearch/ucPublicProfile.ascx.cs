using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;
using System.Configuration;

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

        private List<ListItem> MonthList;

        private int MinExperienceEntry = 0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MemberUrlExtension))
            {
                JXTPortal.Entities.Members member = MembersService.GetByMemberId(Convert.ToInt32(MemberUrlExtension));

                if (member != null)
                {
                    LoadCalendar();

                    LoadMemberInfo(member);
                    SetAttachResume(member);
                    SetAttachCoverletter(member);
                    SetWorkExperience(member);

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

            if (member.LastModifiedDate.HasValue)
            {
                ltlLastModifiedDate.Text = string.Format(@"<div class='col-sm-6'><p class='last-modified-date'><strong>{0}:</strong> {1}</p></div>",
                                                                CommonFunction.GetResourceValue("LabelLastModified"), member.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat));
            }

            loadSummary(member);
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

        private int SetAttachResume(Entities.Members member)
        {
            using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(member.MemberId))
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

        private void SetAttachCoverletter(Entities.Members member)
        {
            using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(member.MemberId))
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

        private int SetWorkExperience(Entities.Members member)
        {
            using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(member.MemberId))
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
    }
}