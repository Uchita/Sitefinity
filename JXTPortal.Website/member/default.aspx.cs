using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using JXTPortal.Entities;
using System.Text;

namespace JXTPortal.Website.members
{
    public partial class default2 : System.Web.UI.Page
    {
        #region Declare Variables

        string strEdit = string.Empty;
        string strViewResults = string.Empty;
        string strDelete = string.Empty;

        #endregion

        #region "Properties"

        MembersService _membersService;
        MembersService MembersService
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

        JobApplicationService _jobApplicationService;
        JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                {
                    _jobApplicationService = new JobApplicationService();
                }
                return _jobApplicationService;
            }
        }

        private JobsSavedService _jobsSavedService;
        private JobsSavedService JobsSavedService
        {
            get
            {
                if (_jobsSavedService == null)
                {
                    _jobsSavedService = new JobsSavedService();
                }
                return _jobsSavedService;
            }
        }

        private JobAlertsService _jobAlertsService;
        private JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                {
                    _jobAlertsService = new JobAlertsService();
                }
                return _jobAlertsService;
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

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Default");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadForm();

            }
            SetFormValues();

        }

        #endregion

        protected void loadForm()
        {

            if (SessionData.Member != null)
            {
                MembersService service = new MembersService();
                bool blnRequiredPasswordChange = false;

                MemberWizardService memberWizardService = new MemberWizardService();
                int? memberPoints = 0;
                memberWizardService.CustomGetMemberPoints(SessionData.Site.SiteId, SessionData.Member.MemberId, ref memberPoints);

                if (memberPoints.HasValue)
                {
                    ltlMemberPercentage.Text = string.Format(
                                            "<div class='progress-bar' data-percent='{0}' data-duration='2000' data-color='white,#ffa64d' data-label='{1}'></div>",
                                                memberPoints.Value,
                                                GetMemberProfilePercentageLabel(memberPoints.Value));

                    //while we have the points, we set the status bar as well
                    string greenStatusClassName = memberPoints.Value == 100 ? "status-yes" : string.Empty;
                    ltDashStatusProfileInfo.Text = string.Format(@"<span class=""jxt_dash-statusInfo {1}"" title=""{0}% profile completed""><span class=""fa fa-check""><span class=""perc-overlay"" style=""height: {0}%;""></span></span>{2}</span>", memberPoints.Value, greenStatusClassName, CommonFunction.GetResourceValue("LabelProfileDetails"));
                }

                Entities.Members member = null;
                using (member = service.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (member != null)
                    {
                        if (member.RequiredPasswordChange.HasValue)
                        {
                            blnRequiredPasswordChange = member.RequiredPasswordChange.Value;
                        }

                        if (!string.IsNullOrWhiteSpace(member.ProfilePicture))
                            imgMemberProfile.ImageUrl = ConfigurationManager.AppSettings["MemberUploadPicturePaths"] + member.ProfilePicture;


                        if (!string.IsNullOrWhiteSpace(member.FirstName))
                            ltlFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
                        else
                            ltlFirstName.Text = CommonFunction.GetResourceValue("LabelFirstName") + " |";

                        if (!string.IsNullOrWhiteSpace(member.Surname))
                            ltlLastName.Text = HttpUtility.HtmlEncode(member.Surname);
                        else
                            ltlLastName.Text = CommonFunction.GetResourceValue("LabelLastName");

                        ltlHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
                        //ltlSeekingStatus.Text = member.AvailabilityId;
                        if (member.AvailabilityId.HasValue && member.AvailabilityId.Value > 0)
                        {
                            ltlSeekingStatus.Text = string.Format(@"<div class='col-xs-6'>
                                                        <div class='lbl'>{0}: </div>
                                                        <span class='fa fa-eye highlight'></span> <span id='current-status'>{1}</span>
                                                    </div>", CommonFunction.GetResourceValue("LabelCurrentStatus"), CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)member.AvailabilityId)));

                        }

                        if (member.AvailabilityFromDate.HasValue)
                        {
                            ltlAvailabilityDate.Text = string.Format("<div class='col-xs-6'><div class='lbl'>{0}: </div><span class='fa fa-clock-o highlight'></span> <span id='availability-date'>{1}</span></div>",
                                                                             CommonFunction.GetResourceValue("LabelAvailabilityDate"), member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
                        }

                        ltlEmailAddress.Text = HttpUtility.HtmlEncode(member.EmailAddress);

                        if (!string.IsNullOrWhiteSpace(member.MobilePhone))
                        {
                            ltlPhone.Text = string.Format("<span class='highlight'>{0}</span><span class='personal-detail-content ph_numb'>{1}</span>",
                                                            CommonFunction.GetResourceValue("LabelTel"), HttpUtility.HtmlEncode(member.MobilePhone));
                        }

                        if (member.DateOfBirth.HasValue)
                        {
                            ltlDOB.Text = string.Format("<span class='highlight'>{0}</span><span class='personal-detail-content dob'>{1}</span>",
                                                            CommonFunction.GetResourceValue("LabelDateOfBirth"), member.DateOfBirth.Value.ToString(SessionData.Site.DateFormat));
                        }

                        string strCountry = string.Empty;

                        if (member.CountryId > 0)
                        {
                            SiteCountriesService SiteCountriesService = new SiteCountriesService();
                            using (TList<Entities.SiteCountries> sc = SiteCountriesService.GetByCountryId(member.CountryId))
                            {
                                if (sc.Count > 0)
                                    strCountry = sc[0].SiteCountryName;
                            }
                        }

                        ltlAddress.Text = string.Empty;

                        if (!string.IsNullOrWhiteSpace(member.Address1))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='address1'>{0}</span>", HttpUtility.HtmlEncode(member.Address1));
                        if (!string.IsNullOrWhiteSpace(member.Address2))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='address2'>{0}</span>", HttpUtility.HtmlEncode(member.Address2));
                        if (!string.IsNullOrWhiteSpace(member.Suburb))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='addCity'>{0}</span>", HttpUtility.HtmlEncode(member.Suburb));
                        if (!string.IsNullOrWhiteSpace(member.States))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='addState'>{0}</span>", HttpUtility.HtmlEncode(member.States));
                        if (!string.IsNullOrWhiteSpace(member.PostCode))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='addPostcode'>{0}</span>", HttpUtility.HtmlEncode(member.PostCode));
                        if (!string.IsNullOrWhiteSpace(strCountry))
                            ltlAddress.Text = ltlAddress.Text + string.Format("<span class='addCountry'>{0}</span>", HttpUtility.HtmlEncode(strCountry));

                        /*string.Format("<span class='address1'>{0}</span><span class='address2'>{1}</span><span class='addCity'>{2}</span><span class='addState'>{3}</span><span class='addPostcode'>{4}</span><span class='addCountry'>{5}</span>",
                            member.Address1, member.Address2, member.Suburb, member.States, member.PostCode, strCountry);*/
                        //<span class="address1">Level 2, 50</span><span class="address2">York Street</span><span class="addCity">Sydney</span><span class="addState">NSW</span><span class="addPostcode">2000</span><span class="addCountry">Australia</span>
                        /*if (!blnRequiredPasswordChange)
                            SetDynamicPageWithWidgets(member);*/

                        //Set the profile status widget
                        SetProfileStatusWidget(member);
                    }
                }

                if (blnRequiredPasswordChange)
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                }


                loadApplications();
                loadJobAlerts();
                loadSavedJobs();




                // *****************CLIENT Specific Shortcodes

                // BULLHORN ONBOARDING SSO
                string strUrl = string.Empty;

                JXTPortal.Client.Bullhorn.BullhornRESTAPI bullhornRestAPI = new JXTPortal.Client.Bullhorn.BullhornRESTAPI(SessionData.Site.SiteId);

                if (bullhornRestAPI.integrations != null && bullhornRestAPI.integrations.BullhornOnBoardingSSO != null)
                {
                    // Get the OnBoarding SSO Url
                    bullhornRestAPI.GetOnBoardingSSO(member, out strUrl);

                    // Set the Onboarding URL
                    if (!string.IsNullOrWhiteSpace(strUrl))
                    {
                        ltlBullhornOnBoarding.Text = string.Format(@"<div class='row'><div class='col-xs-6'><a href='{0}' target='_blank' class='btn btn-sm btn-primary'>Onboarding Documents</a></div></div>", strUrl);
                    }
                    /*else
                    {
                        strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_BULLHORN_ONBOARDING_SSO_LINK, string.Empty);
                    }*/

                }



            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }
        }

        private void SetProfileStatusWidget(Entities.Members member)
        {
            JXTPortal.Entities.MemberWizard memberWizard = null;

            using (memberWizard = MemberWizardService.GetAll().Find(s => s.SiteId.Equals(SessionData.Site.SiteId) && s.GlobalTemplate.Equals(false)))
            {
                if (memberWizard == null)
                {
                    memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));
                }
            }

            StringBuilder statusWidgetHtml = new StringBuilder();

            // Set Summary
            if (memberWizard.SummaryPoints >= 0 && string.IsNullOrWhiteSpace(member.ShortBio))
            {
                statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-2"" class=""fa fa-file-text-o"" title=""Summary""></a></span>");
            }

            // Set Work Experience
            if (memberWizard.ExperiencePoints >= 0)
            {
                using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (memberpositions.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-4"" class=""fa fa-briefcase"" title=""Experience""></a></span>");
                }
            }

            // Set Education
            if (memberWizard.EducationPoints >= 0)
            {
                using (TList<Entities.MemberQualification> membereducations = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (membereducations.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-5"" class=""fa fa-pencil"" title=""Education""></a></span>");
                }
            }

            // Set Skills
            if (memberWizard.SkillsPoints >= 0 && string.IsNullOrEmpty(member.Skills))
            {
                statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-Skills"" class=""fa fa-trophy"" title=""Skills""></a></span>");
            }

            // Set Certifications & Memberships
            if (memberWizard.MembershipsPoints >= 0)
            {
                using (TList<Entities.MemberCertificateMemberships> membercertificates = MemberCertificateMembershipsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (membercertificates.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-7"" class=""fa fa-user"" title=""Certifications & Memberships""></a></span>");
                }
            }

            // Set Licenses
            if (memberWizard.LicensesPoints >= 0)
            {
                using (TList<Entities.MemberLicenses> memberlicenses = MemberLicensesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    if (memberlicenses.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-8"" class=""fa fa-user"" title=""Licenses""></a></span>");
                }
            }

            // Set Role Preferences
            if (memberWizard.RolePreferencesPoints >= 0)
            {
                if (member.LocationId == null || member.PreferredCategoryId == null || member.PreferredSubCategoryId == null || member.PreferredSalaryId == null)
                    statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-9"" class=""fa fa-heart-o"" title=""Roles""></a></span>");
            }

            // Set Attach Resume
            if (memberWizard.CvPoints >= 0)
            {
                using (TList<Entities.MemberFiles> resumes = MemberFilesService.GetByMemberId(member.MemberId))
                {
                    resumes.Filter = "DocumentTypeId = 2";

                    if (resumes.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-AttachResume"" class=""fa fa-file-text-o"" title=""Attach Resume""></a></span>");
                }
            }
            // Set Attach Coverletter
            if (memberWizard.AttachCoverLetterPoints >= 0)
            {
                using (TList<Entities.MemberFiles> coverletters = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
                {
                    coverletters.Filter = "DocumentTypeId = 1";

                    if (coverletters.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-AttachCoverletter"" class=""fa fa-file-text-o"" title=""Attach Cover Letter""></a></span>");
                }
            }

            // Set Languages
            if (memberWizard.LanguagesPoints >= 0)
            {
                using (TList<Entities.MemberLanguages> memberlanguages = MemberLanguagesService.GetByMemberId(member.MemberId))
                {
                    if (memberlanguages.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#sec-Languages"" class=""fa fa-commenting-o"" title=""Languages""></a></span>");
                }
            }

            // Set References
            if (memberWizard.ReferencesPoints >= 0)
            {
                using (TList<Entities.MemberReferences> memberreferences = MemberReferencesService.GetByMemberId(member.MemberId))
                {
                    if (memberreferences.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-13"" class=""fa fa-commenting-o"" title=""References""></a></span>");
                }
            }

            // Set Supplementary Questions
            if (memberWizard.CustomQuestionPoints >= 0)
            {
                if (string.IsNullOrEmpty(memberWizard.CustomQuestionsXml))
                    statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-14"" class=""fa fa-user"" title=""Custom Question""></a></span>");
            }

            // Set Directorship
            if (memberWizard.DirectorshipPoints >= 0)
            {
                using (TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                {
                    memberpositions.Filter = "isDirectorship = true";

                    if (memberpositions.Count == 0)
                        statusWidgetHtml.Append(@"<span class=""jxt_profile-sec-icon""><a href=""/member/profile.aspx#section-15"" class=""fa fa-user"" title=""Directorships""></a></span>");
                }
            }

            if (string.IsNullOrEmpty(statusWidgetHtml.ToString()))
            {
                //profile all filled
                phProfileStatusWidget.Visible = false;
            }
            else
            {
                //profile not filled
                phProfileStatusWidget.Visible = true;
                ltProfileStatusIcons.Text = statusWidgetHtml.ToString();
            }

        }


        public void SetFormValues()
        {
            strEdit = CommonFunction.GetResourceValue("LinkButtonEdit");
            strViewResults = CommonFunction.GetResourceValue("LinkButtonView");
            strDelete = CommonFunction.GetResourceValue("LinkButtonDelete");


            hypJobAlertsViewLink.Text = CommonFunction.GetResourceValue("LabelViewMore");
            ltMemberNoJobAlerts.Text = CommonFunction.GetResourceValue("LabelNoJobAlerts");
            hypSavedJobsViewLink.Text = CommonFunction.GetResourceValue("LabelViewMore");
            ltMemberNoSaveJobs.Text = CommonFunction.GetResourceValue("LabelNoSavedJob");
            ltMemberNoJobTracker.Text = CommonFunction.GetResourceValue("LabelNoJobTracked");
        }


        #region Methods


        protected void loadJobAlerts()
        {
            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["MemberJobAlertPaging"]);

            JobAlertsService aus = new JobAlertsService();
            using (TList<Entities.JobAlerts> JobAlerts = aus.GetByMemberId(SessionData.Member.MemberId, 0, sitePageCount, out totalCount))
            {

                if (JobAlerts.Count > 0)
                {
                    ArrayList pagelist = new ArrayList();
                    ltMemberNoJobAlerts.Visible = false;

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;

                    for (int i = 0; i < pageCount; i++)
                    {
                        pagelist.Add(i);
                    }

                    if (totalCount > 5)
                    {
                        hypJobAlertsViewLink.Visible = true;
                    }

                    rptJobAlerts.DataSource = JobAlerts;
                    rptJobAlerts.DataBind();
                }
                else
                {
                    rptJobAlerts.DataSource = null;
                    rptJobAlerts.DataBind();
                    ltMemberNoJobAlerts.Visible = true;
                }
            }
        }
        protected void rptJobAlerts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.JobAlerts jobalert = e.Item.DataItem as Entities.JobAlerts;

                CheckBox cbAlertEnabled = e.Item.FindControl("cbAlertEnabled") as CheckBox;
                Literal ltlJobAlertSwitch = e.Item.FindControl("ltlJobAlertSwitch") as Literal;

                HiddenField hfAlertID = (HiddenField)e.Item.FindControl("hfAlertID");
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                hfAlertID.Value = jobalert.JobAlertId.ToString();

                if (jobalert.AlertActive.HasValue && jobalert.AlertActive.Value)
                    cbAlertEnabled.Checked = true;
                else
                    cbAlertEnabled.Checked = false;

                ltlJobAlertSwitch.Text = string.Format("<span class='switch-label' data-on='{0}' data-off='{1}'></span>", CommonFunction.GetResourceValue("LabelYes"), CommonFunction.GetResourceValue("LabelNo"));

                ltLastModified.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", jobalert.LastModified);
                //Literal ltlSendEmail = e.Item.FindControl("ltlSendEmail") as Literal;
                //LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                //LinkButton lbViewResults = e.Item.FindControl("lbViewResults") as LinkButton;
                //LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                //lbEdit.Text = strEdit;
                //lbViewResults.Text = strViewResults;
                //lbDelete.Text = strDelete;

                /*
                if (jobalert.AlertActive.HasValue && jobalert.AlertActive.Value)
                    ltlSendEmail.Text = CommonFunction.GetResourceValue("LabelYes");
                else
                    ltlSendEmail.Text = CommonFunction.GetResourceValue("LabelNo");*/
            }
        }
        protected void rptJobAlerts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string urlParams = string.Format("id={0}", e.CommandArgument);
                Response.Redirect("CreateJobAlert.aspx?" + urlParams, true);
            }
            else if (e.CommandName == "View")
            {
                string url = string.Format("/advancedsearch.aspx?search=1&searchid={0}", e.CommandArgument);
                Response.Redirect(url, true);
            }
            else if (e.CommandName == "Delete")
            {
                JobAlertsService.Delete(Convert.ToInt32(string.Format("{0}", e.CommandArgument)));
                Response.Redirect("~/member/myjobalerts.aspx");
            }

        }
        protected void cbAlertEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbSelect = sender as CheckBox;
            foreach (RepeaterItem item in rptJobAlerts.Items)
            {
                CheckBox thisCB = (CheckBox)item.FindControl("cbAlertEnabled");
                if (thisCB == cbSelect)
                {
                    HiddenField hfAlertID = (HiddenField)item.FindControl("hfAlertID");
                    /*if (int.Parse(hfAlertID.Value) == targetParentTypeID)
                    {
                        thisCB.Checked = false;

                    }*/

                    using (JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(int.Parse(hfAlertID.Value)))
                    {
                        jobAlert.AlertActive = cbSelect.Checked;

                        JobAlertsService.Update(jobAlert);
                    }
                }

            }

            loadJobAlerts();
        }

        protected void loadApplications()
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            int memberID = SessionData.Member.MemberId;

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["MemberSavedJobsPaging"]);

            using (DataSet datasetJobApplication = JobApplicationService.GetJobsNameByMemberId(memberID, sitePageCount, 1))
            {
                if (datasetJobApplication.Tables[0].Rows.Count > 0)
                {
                    //rptMemberApplicationTracker.DataSource = datasetJobApplication.Tables[0];

                    totalCount = Convert.ToInt32(datasetJobApplication.Tables[0].Rows[0]["TotalCount"]);
                    ltMemberNoJobTracker.Visible = false;

                    ArrayList pagelist = new ArrayList();

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;


                    if (totalCount > 5)
                    {
                        hypApplicationTrackerViewLink.Visible = true;
                    }

                    rptMemberApplicationTracker.DataSource = datasetJobApplication;
                    rptMemberApplicationTracker.DataBind();
                }
                else
                {
                    rptMemberApplicationTracker.DataSource = null;
                    rptMemberApplicationTracker.DataBind();
                    ltMemberNoJobTracker.Visible = true;
                }
            }

        }
        protected void rptMemberApplicationTracker_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {

            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltMemberApplicationJobView = e.Item.FindControl("ltMemberApplicationJobView") as Literal;
                //Literal ltAdvertiserName = e.Item.FindControl("ltAdvertiserName") as Literal;
                Literal ltDateApplied = e.Item.FindControl("ltDateApplied") as Literal;
                HyperLink hypJobUrl = e.Item.FindControl("hypJobUrl") as HyperLink;

                DataRowView rowJobSaved = (DataRowView)e.Item.DataItem;
                //ltMemberApplicationJobView.Text = rowJobSaved["JobName"].ToString();
                ltDateApplied.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["ApplicationDate"]);
                //ltMemberApplicationJobView.Text = rowJobSaved["JobName"].ToString();
                //ltAdvertiserName.Text = rowJobSaved["CompanyName"].ToString();
                hypJobUrl.NavigateUrl = JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobId"].ToString()), rowJobSaved["JobFriendlyName"].ToString());
                hypJobUrl.Text = rowJobSaved["JobName"].ToString();
            }
        }

        protected void loadSavedJobs()
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            int memberID = SessionData.Member.MemberId;

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["MemberSavedJobsPaging"]);

            using (DataSet dataSetJobSaved = JobsSavedService.GetJobNameByMemberID(memberID, sitePageCount, 1))
            {
                if (dataSetJobSaved.Tables[0].Rows.Count > 0)
                {
                    //rptMemberSavedJobs.DataSource = dataSetJobSaved.Tables[0];

                    totalCount = Convert.ToInt32(dataSetJobSaved.Tables[0].Rows[0]["TotalCount"]);
                    ltMemberNoSaveJobs.Visible = false;
                    ArrayList pagelist = new ArrayList();

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;



                    if (totalCount > 5)
                    {
                        hypSavedJobsViewLink.Visible = true;
                    }
                    else
                        hypSavedJobsViewLink.Visible = false;

                    rptMemberSavedJobs.DataSource = dataSetJobSaved;
                    rptMemberSavedJobs.DataBind();
                }
                else
                {
                    rptMemberSavedJobs.DataSource = null;
                    rptMemberSavedJobs.DataBind();
                    ltMemberNoSaveJobs.Visible = true;

                }
            }
        }
        protected void rptMemberSavedJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkSavedJobsDelete = e.Item.FindControl("lnkSavedJobsDelete") as LinkButton;
                //Literal ltSavedJobsDelete = e.Item.FindControl("ltSavedJobsDelete") as Literal;
                Literal ltViewSavedJobs = e.Item.FindControl("ltViewSavedJobs") as Literal;
                Literal ltlSavedJobsName = e.Item.FindControl("ltlSavedJobsName") as Literal;
                //Literal ltSavedJobsDate = e.Item.FindControl("ltSavedJobsDate") as Literal;
                Literal ltDatePosted = e.Item.FindControl("ltDatePosted") as Literal;
                //Literal ltExpiryDate = e.Item.FindControl("ltExpiryDate") as Literal;
                //Literal ltRefNo = e.Item.FindControl("ltRefNo") as Literal;
                HyperLink hlViewSavedJobs = e.Item.FindControl("hlViewSavedJobs") as HyperLink;
                

                //lnkSavedJobsDelete.Text = CommonFunction.GetResourceValue("LinkButtonDelete");
                string message = CommonFunction.GetResourceValue("LabelConfirmDeleteRecord");
                lnkSavedJobsDelete.OnClientClick = "return confirm('" + message + "')";


                ltViewSavedJobs.Text = CommonFunction.GetResourceValue("LinkButtonView");
                DataRowView rowJobSaved = (DataRowView)e.Item.DataItem;
                hlViewSavedJobs.NavigateUrl = "~/" + JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobID"]), rowJobSaved["JobFriendlyName"].ToString());
                lnkSavedJobsDelete.CommandArgument = rowJobSaved["JobSaveID"].ToString();

                ltlSavedJobsName.Text = Convert.ToString(rowJobSaved["JobName"]);
                //ltlSavedJobsName.NavigateUrl = "~/" + JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobID"]), rowJobSaved["JobFriendlyName"].ToString());
                //ltRefNo.Text = rowJobSaved["RefNo"].ToString();
                //ltSavedJobsDate.Text = string.Format("{0:dd/MM/yyy}", rowJobSaved["LastModified"]);
                ltDatePosted.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["DatePosted"]);
                //ltExpiryDate.Text = string.Format("{0:dd/MM/yyy}", rowJobSaved["ExpiryDate"]);

            }
        }
        protected void lnkSavedJobsDelete_Click(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            int JobSaveID = 0;
            int memberID = SessionData.Member.MemberId;
            LinkButton lb = (LinkButton)sender;
            JobSaveID = Convert.ToInt32(lb.CommandArgument);

            using (TList<Entities.JobsSaved> objjobsaved = JobsSavedService.GetByMemberId(memberID))
            {
                JobsSavedService jobsSavedService = new JobsSavedService();
                jobsSavedService.Delete(JobSaveID);
            }

            loadSavedJobs();
            //Response.Redirect("~/member/mysavedjobs.aspx");
        }

        #endregion





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


    }
}