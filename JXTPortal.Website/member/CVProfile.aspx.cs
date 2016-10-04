using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using System.Data;
using System.Configuration;
using JXTPortal.Common;

namespace JXTPortal.Website.member
{
    public partial class CVProfile : System.Web.UI.Page
    {
        // Todo image

        #region Services Declarations

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

        private SiteCountriesService _siteCountriesservice = null;

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesservice == null)
                {
                    _siteCountriesservice = new SiteCountriesService();
                }
                return _siteCountriesservice;
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


        private LocationService _LocationService = null;

        private LocationService LocationService
        {
            get
            {
                if (_LocationService == null)
                {
                    _LocationService = new LocationService();
                }
                return _LocationService;
            }
        }
        #endregion

        #region Variable Declarations

        private Entities.MemberWizard _memberWizard;

        bool hasCover, hasRoles, hasEdu, hasExp, hasSkills, hasDirectorship;

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            // ONLY FOR ENWORLD SITES - redirect to custom profile page
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
            ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " "))
            {
                Response.Redirect("/member/enworld/profile.aspx");
                return;
            }

            Response.Redirect("/member/profile.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            CommonPage.SetBrowserPageTitle(Page, "Profile");

            SetMemberInformation();

            SetWizardTitles();
            SetResumeCoverLetter();

            //this has to be last, bool flags are placed in the above functions to calculate progress bar
            SetProgressBar();
        }

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

        #region Member Profile

        private bool SetMemberInformation()
        {

            using (Entities.Members objMembers = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                ltlName.Text = string.Format("<span class='first-name'>{0}</span> <span class='last-name'>{1}</span>", objMembers.FirstName, objMembers.Surname);
                ltlHeadline.Text = Utils.ReplaceNewlineWithBRTags(objMembers.PreferredJobTitle);
                ltlShortBio.Text = Utils.ReplaceNewlineWithBRTags(objMembers.ShortBio);

                if (!string.IsNullOrWhiteSpace(objMembers.ProfilePicture))
                    imgMemberProfile.ImageUrl = ConfigurationManager.AppSettings["MemberUploadPicturePaths"] + objMembers.ProfilePicture;

                SetCurrentStatus(objMembers.MemberStatusId);

                SetLocations(objMembers.CountryId, objMembers.LocationId, objMembers.AreaId);
                SetClassifications(objMembers.PreferredCategoryId, objMembers.PreferredSubCategoryId);
                SetWorkTypes(objMembers.WorkTypeId);

                SetQualifications();
                SetMemberships(objMembers.Memberships);
                SetDirectorship();
                SetExperience();
                SetSkills(objMembers.Skills);

                //set last modified date
                ltlProfileProgressLastDate.Text = objMembers.LastModifiedDate == null ? "-" : objMembers.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat);


                // Set Contact Information
                ltContactEmail.Text = objMembers.EmailAddress;
                ltContactNumber.Text = (string.IsNullOrWhiteSpace(objMembers.MobilePhone)) ? string.Empty : objMembers.MobilePhone.Trim();
                if (string.IsNullOrEmpty(ltContactNumber.Text))
                {
                    ltContactNumber.Text = (string.IsNullOrWhiteSpace(objMembers.WorkPhone)) ? string.Empty : objMembers.WorkPhone.Trim();
                }
                if (string.IsNullOrEmpty(ltContactNumber.Text))
                {
                    ltContactNumber.Text = (string.IsNullOrWhiteSpace(objMembers.HomePhone)) ? string.Empty : objMembers.HomePhone.Trim();
                }

                if (string.IsNullOrEmpty(ltContactNumber.Text))
                {
                    phContactNumber.Visible = false;
                }
            }

            return true;
        }

        protected void SetProgressBar()
        {
            int percentage = 0;

            if (_memberWizard == null)
                _memberWizard = GetMemberWizardEntityForCurrentSite();

            if (_memberWizard != null)
            {
                //Directorship not enabled
                if (_memberWizard.DirectorshipEnable == null || !_memberWizard.DirectorshipEnable.Value)
                {
                    //base
                    percentage = 40;

                    if (hasCover) percentage += 20;
                    if (hasRoles) percentage += 10;
                    if (hasEdu) percentage += 10;
                    if (hasExp) percentage += 10;
                    if (hasSkills) percentage += 10;
                }
                else //Directorship enabled
                {
                    //base
                    percentage = 30;

                    if (hasCover) percentage += 20;
                    if (hasRoles) percentage += 10;
                    if (hasEdu) percentage += 10;
                    if (hasExp) percentage += 10;
                    if (hasSkills) percentage += 10;
                    if (hasDirectorship) percentage += 10;
                }

                ltlProfileProgressPercent.Text = percentage + "%";
                ltlProgressBarBar.Text = @"<div class=""progress-bar"" role=""progressbar"" aria-valuenow=""" + percentage + @""" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: " + percentage + @"%;""> <span class=""sr-only"">" + percentage + @"% Complete</span> </div>";

            }
        }

        protected void SetCurrentStatus(int? intStatusID)
        {
            if (intStatusID.HasValue)
            {
                DataSet statusDS = MemberStatusService.GetByMemberStatusId(intStatusID);
                if (statusDS != null && statusDS.Tables.Count > 0)
                    ltlCurrentStatus.Text = "<ul id='current-status'><li>" + statusDS.Tables[0].Rows[0]["MemberStatusName"].ToString() + "</li></ul>";
            }
        }

        #endregion

        #region Member Wizard

        protected void SetWizardTitles()
        {
            _memberWizard = GetMemberWizardEntityForCurrentSite();

            if (_memberWizard != null)
            {
                ltlCoverletter.Text = _memberWizard.CvTitle;
                ltlDirectorship.Text = _memberWizard.DirectorshipTitle;
                ltlExperience.Text = _memberWizard.ExperienceTitle;
                ltlMemberships.Text = _memberWizard.MembershipsTitle;
                ltlQualifications.Text = _memberWizard.EducationTitle;
                ltlRolePreferences.Text = _memberWizard.RolePreferencesTitle;
                ltlSkills.Text = _memberWizard.SkillsTitle;

                ltlCoverletter2.Text = _memberWizard.CvTitle;
                ltlDirectorship2.Text = _memberWizard.DirectorshipEnable.HasValue && _memberWizard.DirectorshipEnable.Value ? @"<li><a href=""#tab6"" id=""BtnTab6"">" + _memberWizard.DirectorshipTitle + "</a></li>" : string.Empty;
                ltlExperience2.Text = _memberWizard.ExperienceTitle;
                ltlMemberships2.Text = _memberWizard.MembershipsTitle;
                ltlQualifications2.Text = _memberWizard.EducationTitle;
                ltlRolePreferences2.Text = _memberWizard.RolePreferencesTitle;
                ltlSkills2.Text = _memberWizard.SkillsTitle;
            }

        }


        #endregion

        #region Resume and CoverLetter

        protected void SetResumeCoverLetter()
        {

            ltlFiles.Text = string.Empty;
            using (TList<MemberFiles> objmembers = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
            {
                if (objmembers != null && objmembers.Count > 0)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    plhCoverletter.Visible = true;
                    string strFileType = string.Empty;
                    foreach (MemberFiles item in objmembers)
                    {
                        //flag for percentage count
                        hasCover = true;

                        strFileType = string.Empty;
                        if (item.DocumentTypeId.HasValue)
                        {
                            switch (item.DocumentTypeId.Value)
                            {
                                case 1:
                                    strFileType = CommonFunction.GetResourceValue("LabelCoverLetter");
                                    break;
                                case 2:
                                    strFileType = CommonFunction.GetResourceValue("LabelResume");
                                    break;
                                case 3:
                                    strFileType = CommonFunction.GetResourceValue("LabelAdditionalDocuments");
                                    break;

                            }
                        }
                        strBuilder.AppendFormat(@"<tr>
										    <td>{0}</td>
                                            <td>{1}</td>
										    <td class='text-right'><a href='/download.aspx?type=mf&id={2}' class='btn btn-success btn-xs'><i class='fa fa-download'><!--ICON--></i> Download</a></td>
									    </tr>", item.MemberFileName,
                                              strFileType,
                                              item.MemberFileId);
                    }

                    ltlFiles.Text = strBuilder.ToString();
                }
                else
                {
                    plhCoverletter.Visible = false;
                    ltlFilesMessage.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
                }

            }
        }

        #endregion

        #region Locations

        protected void SetLocations(int countryID, string strLocationID, string strAreaIDs)
        {
            /*
<ul class="locations">
	<li class="country"><strong>Australia</strong>
		<ul>
			<li>NSW
				<ul class="area">
					<li>Sydney CBD</li>
					<li>Lower North Shore</li>
					<li>Eastern Surburbs</li>
					<li>Sydney Regional</li>
				</ul>
			</li>
		</ul>
	</li>											
</ul>
*/


            int locationID = 0;

            StringBuilder strBuilder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(strLocationID) && int.TryParse(strLocationID, out locationID))
            {
                using (Entities.Location location = LocationService.GetByLocationId(locationID))
                {
                    if (location != null)
                    {
                        using (Entities.SiteLocation siteLocation = SiteLocationService.GetTranslatedLocationsByCountryID(location.CountryId).Where(s => s.LocationId == locationID).FirstOrDefault())
                        {
                            if (siteLocation != null)
                            {
                                using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(siteLocation.SiteId, location.CountryId))
                                {
                                    //flag for percentage count
                                    hasRoles = true;

                                    List<SiteArea> siteAreas = SiteAreaService.GetTranslatedAreas(locationID);
                                    SiteArea siteArea = new SiteArea();
                                    if (!String.IsNullOrWhiteSpace(strAreaIDs))
                                    {
                                        List<int> strAreaValues = strAreaIDs.Split(',').Select(n => int.Parse(n)).ToList();
                                        foreach (int intAreaValue in strAreaValues)
                                        {
                                            if (intAreaValue != 0)
                                            {
                                                siteArea = siteAreas.Where(s => s.AreaId == intAreaValue).FirstOrDefault();
                                                if (siteArea != null)
                                                    strBuilder.AppendFormat("<li>{0}</li>", siteArea.SiteAreaName);

                                            }
                                        }
                                    }

                                    ltlLocations.Text = string.Format(@"
<ul class='locations'>
	<li class='country'><strong>{0}</strong>
		<ul>
			<li>{1}
				<ul class='area'>
					{2}
				</ul>
			</li>
		</ul>
	</li>											
</ul>
", siteCountry.SiteCountryName, siteLocation.SiteLocationName, strBuilder.ToString());
                                }
                            }
                        }
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(ltlLocations.Text))
                ltlLocations.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
            //Todo
        }

        #endregion

        #region Classification / Subclassification

        protected void SetClassifications(string strClassificationID, string strSubClassificationID)
        {
            int classificationID = 0;

            if (!String.IsNullOrWhiteSpace(strClassificationID) && int.TryParse(strClassificationID, out classificationID))
            {
                Entities.SiteProfession profession = SiteProfessionService.GetTranslatedProfessionById(classificationID, SessionData.Site.UseCustomProfessionRole);

                if (profession != null)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    List<SiteRoles> siteRoles = SiteRolesService.GetTranslatedByProfessionID(classificationID, SessionData.Site.UseCustomProfessionRole);
                    SiteRoles siteRole = new SiteRoles();

                    if (!String.IsNullOrWhiteSpace(strSubClassificationID))
                    {
                        List<int> strRoleValues = strSubClassificationID.Split(',').Select(n => int.Parse(n)).ToList();
                        foreach (int intRoleValue in strRoleValues)
                        {
                            if (intRoleValue != 0)
                            {
                                siteRole = siteRoles.Where(s => s.RoleId == intRoleValue).FirstOrDefault();
                                if (siteRole != null)
                                    strBuilder.AppendFormat("<li>{0}</li>", siteRole.SiteRoleName);

                            }
                        }
                    }


                    ltlClassifications.Text = string.Format(@"<ul class='classification'>
									                            <li>{0}
										                            <ul class='sub-classification'>
											                            {1}
										                            </ul>
									                            </li>
								                            </ul>", profession.SiteProfessionName, strBuilder.ToString());

                }
            }

            if (String.IsNullOrWhiteSpace(ltlClassifications.Text))
                ltlClassifications.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
        }

        #endregion

        #region Qualification

        protected void SetQualifications()
        {

            StringBuilder strBuilder = new StringBuilder();
            using (TList<Entities.MemberQualification> memberQualificationList = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId))
            {

                if (memberQualificationList != null && memberQualificationList.Count > 0)
                {
                    //flag for percentage count
                    hasEdu = true;

                    foreach (Entities.MemberQualification item in memberQualificationList)
                    {
                        strBuilder.AppendFormat(@"
<div class='qualification'>
	<p class='title'>{0}</p>
	<p class='institution'>{1}</p>
	<p class='qualification-dates'><span class='startdate'>{2}</span> - <span class='enddate'>{3}</span></p>
</div>", item.Degree, item.SchoolName, item.StartYear, item.EndYear.HasValue ? item.EndYear.Value.ToString() : CommonFunction.GetResourceValue("LabelCurrent"));
                    }
                    ltlQualificationList.Text = strBuilder.ToString();
                }
                else
                    ltlQualificationList.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
            }
        }

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

                    ltlMembershipsValues.Text = string.Format(@"<ul class='dynamic-content'>
									{0}
								</ul>", strBuilder.ToString());
                }
            }



            if (string.IsNullOrWhiteSpace(ltlMembershipsValues.Text))
                ltlMembershipsValues.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");


        }

        #endregion

        #region Directorship

        protected void SetDirectorship()
        {
            if (_memberWizard == null)
                _memberWizard = GetMemberWizardEntityForCurrentSite();

            if (_memberWizard != null)
            {
                //show or not show depends on the flag
                if (_memberWizard.DirectorshipEnable == null || !_memberWizard.DirectorshipEnable.Value)
                {
                    phDirectorship.Visible = false;
                    hlExperience.HRef = "/member/cvbuilder.aspx?tab=tab6";
                    hlSkills.HRef = "/member/cvbuilder.aspx?tab=tab7";
                }
                else
                {

                    phDirectorship.Visible = true;
                    hlExperience.HRef = "/member/cvbuilder.aspx?tab=tab7";
                    hlSkills.HRef = "/member/cvbuilder.aspx?tab=tab8";
                    StringBuilder strBuilder = new StringBuilder();
                    using (TList<Entities.MemberPositions> memberPositionsList = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                    {
                        memberPositionsList.Filter = "IsDirectorship = true";
                        string additionalrolesandresponsibilities = string.Empty;
                        string[] splits = null;

                        if (memberPositionsList != null && memberPositionsList.Count > 0)
                        {
                            //flag for percentage count
                            hasDirectorship = true;

                            foreach (Entities.MemberPositions item in memberPositionsList)
                            {
                                additionalrolesandresponsibilities = string.Empty;
                                splits = item.AdditionalRolesAndResponsibilities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                if (splits.Length > 0)
                                {
                                    foreach (string s in splits)
                                    {
                                        additionalrolesandresponsibilities += string.Format("<li>{0}</li>", CommonFunction.GetResourceValue("cb" + s));
                                    }

                                    additionalrolesandresponsibilities = string.Format("<ul>{0}</ul>", additionalrolesandresponsibilities);
                                }

                                strBuilder.AppendFormat(@"
<div class='experience'>
	<h4 class='title'>{0}</h4>
	<p class='company'>{1}</p>
	<p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>
	<div class='summary'>
		{5}
	</div>
    <div class='organisarionwebsite'>
		{6}
	</div>
    <div class='responsibilitiesandachievements'>
		{7}
	</div>
    <div class='typeofdirectorship'>
		{8}
	</div>
    <div class='additionalrolesandresponsibilities'>
		{9}
	</div>
</div>", item.Title, item.CompanyName,
                   item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty,
                   item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty,
                   item.IsCurrent ? CommonFunction.GetResourceValue("LabelCurrent") :
                            string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                            item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                            item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty), Utils.ReplaceNewlineWithBRTags(item.Summary),
                                            item.OrganisationWebsite, Utils.ReplaceNewlineWithBRTags(item.ResponsibilitiesAndAchievements), CommonFunction.GetResourceValue(item.TypeOfDirectorship),
                                            additionalrolesandresponsibilities
                                            );

                            }

                            ltlDirectorshipList.Text = strBuilder.ToString();
                        }
                        else
                            ltlDirectorshipList.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
                    }
                }
            }


        }

        #endregion

        #region Experience

        protected void SetExperience()
        {

            StringBuilder strBuilder = new StringBuilder();
            using (TList<Entities.MemberPositions> memberPositionsList = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
            {
                memberPositionsList.Filter = "IsDirectorship = false";

                if (memberPositionsList != null && memberPositionsList.Count > 0)
                {
                    //flag for percentage count
                    hasExp = true;

                    foreach (Entities.MemberPositions item in memberPositionsList)
                    {
                        strBuilder.AppendFormat(@"
<div class='experience'>
	<h4 class='title'>{0}</h4>
	<p class='company'>{1}</p>
	<p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>
	<div class='summary'>
		{5}
	</div>
</div>"
                            , item.Title
                            , item.CompanyName
                            , item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty
                            , item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty
                            , item.IsCurrent ?
                                    CommonFunction.GetResourceValue("LabelCurrent")
                                    : string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>", item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty, item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty)
                            , Utils.ReplaceNewlineWithBRTags(item.Summary));

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
                                strBuilder.AppendFormat("<li>{0}</li>", siteWorkType.SiteWorkTypeName);

                        }
                    }

                    ltlWorktypes.Text = string.Format(@"<ul class='work-type'>
									{0}
								</ul>", strBuilder.ToString());
                }
            }


            if (String.IsNullOrWhiteSpace(ltlWorktypes.Text))
                ltlWorktypes.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
        }

        #endregion

        #region Skills

        protected void SetSkills(string strSkills)
        {
            StringBuilder strBuilder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(strSkills))
            {
                string[] strSkillsValues = strSkills.Split(',');
                if (strSkillsValues.Count() > 0)
                {
                    //flag for percentage count
                    hasSkills = true;

                    foreach (string item in strSkillsValues)
                    {
                        strBuilder.AppendFormat("<li>{0}</li>", item);

                    }

                    ltlSkillsTags.Text = string.Format(@"<ul>
									{0}
								</ul>", strBuilder.ToString());
                }

            }

            if (string.IsNullOrWhiteSpace(ltlSkillsTags.Text))
                ltlSkillsTags.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
        }

        #endregion

        #region Private helpers

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