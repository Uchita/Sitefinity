using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Data;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucCVProfileDownload1 : System.Web.UI.UserControl
    {

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

        #endregion

        #region Variable Declarations

        private Entities.MemberWizard _memberWizard;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupPageDetails();
        }

        public void Setup()
        {
            SetupPageDetails();
        }

        private void SetupPageDetails()
        {
            //setup header/footer image
            // IMPORTANT - for the PDF logos to work 
            string imageURL = "http://jxt1.com.jxt1.com/admin/getadminlogo.aspx?siteid=" + SessionData.Site.SiteId;
            imgHeaderLogo.ImageUrl = imageURL;
            imgFooterLogo.ImageUrl = imageURL;

            SetMemberInformation();
        }


        #region Member Profile

        private bool SetMemberInformation()
        {

            using (Entities.Members objMembers = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                ltlName.Text = string.Format("<span class='first-name'>{0}</span> <span class='last-name'>{1}</span>", objMembers.FirstName, objMembers.Surname);
                ltlHeadline.Text = objMembers.PreferredJobTitle;
                ltlShortBio.Text = Utils.ReplaceNewlineWithBRTags(objMembers.ShortBio);

                string addressDisplay = string.Empty;
                if (!string.IsNullOrEmpty(objMembers.Suburb) && !string.IsNullOrEmpty(objMembers.States))
                    addressDisplay = objMembers.Suburb + ", " + objMembers.States + "</br>";

                ltlMemberContacts.Text =
                    String.Format(@"<p class=""candidate-info""><a href=""mailto:{0}"">{0}</a></br>
			                        {1}
			                        {2}
			                        {3}</p>"
                                            , objMembers.EmailAddress
                                            , addressDisplay
                                            , objMembers.HomePhone != null && !string.IsNullOrEmpty(objMembers.HomePhone.Trim()) ? "P " + objMembers.HomePhone.Trim() + "</br>" : string.Empty
                                            , objMembers.MobilePhone != null && !string.IsNullOrEmpty(objMembers.MobilePhone.Trim()) ? "M " + objMembers.MobilePhone.Trim() : string.Empty
                                           );

                if (!string.IsNullOrWhiteSpace(objMembers.ProfilePicture))
                    imgMemberProfile.ImageUrl = "http://10.0.20.87:84/media/candidate/" + objMembers.ProfilePicture;

                SetCurrentStatus(objMembers.MemberStatusId);

                SetLocations(objMembers.CountryId, objMembers.LocationId, objMembers.AreaId);
                SetClassifications(objMembers.PreferredCategoryId, objMembers.PreferredSubCategoryId);
                SetWorkTypes(objMembers.WorkTypeId);

                SetWizardTitles();
                SetQualifications();
                //SetMemberships(objMembers.Memberships);
                SetDirectorship();
                SetExperience();
                SetSkills(objMembers.Skills);
            }

            return true;
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
                //ltlCoverletter.Text = _memberWizard.CvTitle;
                ltlDirectorship.Text = _memberWizard.DirectorshipTitle;
                ltlExperience.Text = _memberWizard.ExperienceTitle;
                ltlMemberships.Text = _memberWizard.MembershipsTitle;
                ltlQualifications.Text = _memberWizard.EducationTitle;
                ltlRolePreferences.Text = _memberWizard.RolePreferencesTitle;
                ltlSkills.Text = _memberWizard.SkillsTitle;
            }
        }

        #endregion

        #region Resume and CoverLetter

        //        protected void SetResumeCoverLetter()
        //        {

        //            ltlFiles.Text = string.Empty;
        //            using (TList<MemberFiles> objmembers = MemberFilesService.GetByMemberId(SessionData.Member.MemberId))
        //            {
        //                if (objmembers != null && objmembers.Count > 0)
        //                {
        //                    StringBuilder strBuilder = new StringBuilder();

        //                    plhCoverletter.Visible = true;
        //                    string strFileType = string.Empty;
        //                    foreach (MemberFiles item in objmembers)
        //                    {
        //                        strFileType = string.Empty;
        //                        if (item.DocumentTypeId.HasValue)
        //                        {
        //                            switch (item.DocumentTypeId.Value)
        //                            {
        //                                case 1:
        //                                    strFileType = CommonFunction.GetResourceValue("LabelCoverLetter");
        //                                    break;
        //                                case 2:
        //                                    strFileType = CommonFunction.GetResourceValue("LabelResume");
        //                                    break;
        //                                case 3:
        //                                    strFileType = CommonFunction.GetResourceValue("LabelAdditionalDocuments");
        //                                    break;

        //                            }
        //                        }
        //                        strBuilder.AppendFormat(@"<tr>
        //										    <td>{0}</td>
        //                                            <td>{1}</td>
        //										    <td class='text-right'><a href='/download.aspx?type=mf&id={2}' class='btn btn-success btn-xs'><i class='fa fa-download'><!--ICON--></i> Download</a></td>
        //									    </tr>", item.MemberFileName,
        //                                              strFileType,
        //                                              item.MemberFileId);
        //                    }

        //                    ltlFiles.Text = strBuilder.ToString();
        //                }
        //                else
        //                {
        //                    plhCoverletter.Visible = false;
        //                    ltlFilesMessage.Text = CommonFunction.GetResourceValue("LabelRequiredFieldsNeeded");
        //                }

        //            }
        //        }

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

            if (countryID > 0)
            {
                Entities.SiteCountries siteCountries = SiteCountriesService.GetTranslatedCountries().Where(s => s.CountryId == countryID).FirstOrDefault();

                if (siteCountries != null)
                {
                    int locationID = 0;

                    StringBuilder strBuilder = new StringBuilder();

                    if (!String.IsNullOrWhiteSpace(strLocationID) && int.TryParse(strLocationID, out locationID))
                    {
                        Entities.SiteLocation siteLocation = SiteLocationService.GetTranslatedLocationsByCountryID(countryID).Where(s => s.LocationId == locationID).FirstOrDefault();
                        if (siteLocation != null)
                        {
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
	<li class='country'>{0}
		<ul>
			<li>{1}
				<ul class='area'>
					{2}
				</ul>
			</li>
		</ul>
	</li>											
</ul>
", siteCountries.SiteCountryName, siteLocation.SiteLocationName, strBuilder.ToString());
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
                    foreach (Entities.MemberQualification item in memberQualificationList)
                    {
                        strBuilder.AppendFormat(@"
<div class='qualification'>
	<p class='title'><strong>{0}</strong></p>
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

        /*protected void SetMemberships(string strMembership)
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


        }*/

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
                    phDirectorship.Visible = false;
                else
                {
                    StringBuilder strBuilder = new StringBuilder();
                    using (TList<Entities.MemberPositions> memberPositionsList = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId))
                    {
                        memberPositionsList.Filter = "IsDirectorship = true";
                        string additionalrolesandresponsibilities = string.Empty;
                        string[] splits = null;


                        if (memberPositionsList != null && memberPositionsList.Count > 0)
                        {
                            foreach (Entities.MemberPositions item in memberPositionsList)
                            {
                                additionalrolesandresponsibilities = string.Empty;
                                splits = item.AdditionalRolesAndResponsibilities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                if (splits.Length > 0)
                                {
                                    foreach (string s in splits)
                                    {
                                        additionalrolesandresponsibilities += string.Format("<li>{0}</li>", CommonFunction.GetResourceValue(s));
                                    }

                                    additionalrolesandresponsibilities = string.Format("<ul>{0}</ul>", additionalrolesandresponsibilities);
                                }


                                strBuilder.AppendFormat(@"
<div class='directorship'>
	<h4 class='title'>{0}</h4>
	<p class='company'>{1} <span class='directorship-type'> | {8} </span>{6}</p>
	<p class='date'><span class='start-date'><b class='month'>{2}</b> <b class='year'>{3}</b></span> - <span class='end-date'>{4}</span></p>
	<div class='summary'>
		{5}
	</div>
    <div class='responsibilities'>
		{7}
	</div>
    {9}
</div>", item.Title // Format 0
       , item.CompanyName // Format 1
       , item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty// Format 2
       , item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty // Format 3
       , item.IsCurrent ? CommonFunction.GetResourceValue("LabelCurrent") :
                            string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                            item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                            item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty)  // Format 4
       , Utils.ReplaceNewlineWithBRTags(item.Summary) // Format 5
       , string.IsNullOrEmpty(item.OrganisationWebsite) ? string.Empty : String.Format(@"<span class='organisation-website'>| {0}</span>", item.OrganisationWebsite) // Format 6
       , Utils.ReplaceNewlineWithBRTags(item.ResponsibilitiesAndAchievements) // Format 7
       , CommonFunction.GetResourceValue(item.TypeOfDirectorship) // Format 8
       , string.IsNullOrEmpty(additionalrolesandresponsibilities) ? string.Empty : String.Format(@"<ul class='add-roles'>{0}</ul>", additionalrolesandresponsibilities) // Format 9
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
</div>", item.Title, item.CompanyName,
           item.StartMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.StartMonth.Value) : string.Empty,
           item.StartYear.HasValue ? item.StartYear.Value.ToString() : string.Empty,
           item.IsCurrent ? CommonFunction.GetResourceValue("LabelCurrent") :
                    string.Format("<b class='month'>{0}</b> <b class='year'>{1}</b>",
                                    item.EndMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.EndMonth.Value) : string.Empty,
                                    item.EndYear.HasValue ? item.EndYear.Value.ToString() : string.Empty), Utils.ReplaceNewlineWithBRTags(item.Summary));

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

        #region Private Helpers
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