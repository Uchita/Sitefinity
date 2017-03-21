using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Client.Salesforce;
using System.IO;

namespace JXTPortal.Website.member
{
    public partial class CVBuilder : System.Web.UI.Page
    {
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string candidateFolder, memberFileFolder;

        #region Properties
        public IFileManager FileManagerService { get; set; }

        ArrayList wizardlist;
        private DynamicPagesService _dynamicPagesService = null;

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

        private GlobalSettingsService _globalSettingsService = null;

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

        private MemberFileTypesService _memberfiletypeservice = null;

        private MemberFileTypesService MemberFileTypesService
        {
            get
            {
                if (_memberfiletypeservice == null)
                {
                    _memberfiletypeservice = new MemberFileTypesService();
                }
                return _memberfiletypeservice;
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

        private MembersService _membersservice = null;

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

        private MemberFilesService _memberfilesservice = null;

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberfilesservice == null)
                {
                    _memberfilesservice = new MemberFilesService();
                }
                return _memberfilesservice;
            }
        }

        private MemberQualificationService _memberqualificationservice = null;

        private MemberQualificationService MemberQualificationService
        {
            get
            {
                if (_memberqualificationservice == null)
                {
                    _memberqualificationservice = new MemberQualificationService();
                }
                return _memberqualificationservice;
            }
        }

        private MemberMembershipsService _membermembershipsservice = null;

        private MemberMembershipsService MemberMembershipsService
        {
            get
            {
                if (_membermembershipsservice == null)
                {
                    _membermembershipsservice = new MemberMembershipsService();
                }
                return _membermembershipsservice;
            }
        }

        private MemberPositionsService _memberpositionsservice = null;

        private MemberPositionsService MemberPositionsService
        {
            get
            {
                if (_memberpositionsservice == null)
                {
                    _memberpositionsservice = new MemberPositionsService();
                }
                return _memberpositionsservice;
            }
        }
        #endregion
        List<string> shortmonths;

        protected void Page_Init(object sender, EventArgs e)
        {
            // ONLY FOR ENWORLD SITES - redirect to custom profile page
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
            ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " "))
            {
                Response.Redirect("/member/enworld/profile.aspx");
                return;
            }

            CommonPage.SetBrowserPageTitle(Page, "Update Profile");

            Response.Redirect("/member/profile.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

            shortmonths = new List<string>();
            shortmonths.Add("Jan");
            shortmonths.Add("Jan");
            shortmonths.Add("Feb");
            shortmonths.Add("Mar");
            shortmonths.Add("Apr");
            shortmonths.Add("May");
            shortmonths.Add("Jun");
            shortmonths.Add("Jul");
            shortmonths.Add("Aug");
            shortmonths.Add("Sep");
            shortmonths.Add("Oct");
            shortmonths.Add("Nov");
            shortmonths.Add("Dec");

            if (SessionData.Member != null)
            {
                MembersService service = new MembersService();
                Entities.Members member = service.GetByMemberId(SessionData.Member.MemberId);

                if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                }
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            if (!Page.IsPostBack)
            {
                wizardlist = new ArrayList();
                LoadMemberWizard();
                LoadCurrentStatus();
                LoadSiteProfession();
                LoadRoles();
                LoadSiteLocation();
                LoadArea();
                LoadWorkType();
                LoadMemberCV();
            }

        }

        private void LoadCV()
        {
            phCoverLetter.Visible = false;
            phResume.Visible = false;
            phFileList.Visible = false;

            TList<Entities.MemberFiles> memberfiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId);
            foreach (Entities.MemberFiles memberfile in memberfiles)
            {
                if (memberfile.DocumentTypeId == 1)
                {
                    phCoverLetter.Visible = true;
                    phFileList.Visible = true;
                    hfCoverLetterID.Value = memberfile.MemberFileId.ToString();
                    ltCoverLetterFileName.Text = HttpUtility.HtmlEncode(memberfile.MemberFileName);
                    hlCoverLetterDownload.NavigateUrl = "/download.aspx?type=mf&id=" + memberfile.MemberFileId.ToString();
                }

                if (memberfile.DocumentTypeId == 2)
                {
                    phResume.Visible = true;
                    phFileList.Visible = true;
                    hfResumeDocID.Value = memberfile.MemberFileId.ToString();
                    ltResumeFileName.Text = HttpUtility.HtmlEncode(memberfile.MemberFileName);
                    hlResumeDownload.NavigateUrl = "/download.aspx?type=mf&id=" + memberfile.MemberFileId.ToString();
                }

            }
        }

        private void LoadMemberCV()
        {
            Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);
            if (member != null)
            {
                // Profile
                tbHeadline.Text = CommonService.DecodeString(member.PreferredJobTitle);
                tbShortBio.Text = CommonService.DecodeString(member.ShortBio);
                ddlCurrentStatus.SelectedValue = member.MemberStatusId.ToString();
                if (!string.IsNullOrEmpty(member.ProfilePicture))
                {
                    imProfile.Visible = true;
                    imProfile.ImageUrl = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberUploadPicturePaths"], member.ProfilePicture);
                }

                // CV
                LoadCV();

                // Roles
                ddlLocations.SelectedValue = member.LocationId;
                if (ddlLocations.SelectedValue != "0")
                {
                    LoadArea(member.AreaId);
                    hfArea.Value = member.AreaId;
                }

                ddlClassification.SelectedValue = member.PreferredCategoryId;
                if (ddlClassification.SelectedValue != "0")
                {
                    LoadRoles(member.PreferredSubCategoryId);
                    hfSubClassification.Value = member.PreferredSubCategoryId;
                }

                if (!string.IsNullOrEmpty(member.WorkTypeId))
                {
                    LoadWorkType(member.WorkTypeId);
                    hfWorkType.Value = member.WorkTypeId;
                }

                // Education    
                LoadEducation();

                // Memberships
                LoadMemberships(member.Memberships);

                // Experience
                LoadPositions();

                // Experience
                LoadDirectorships();

                //Skills
                skillTags.Text = CommonService.DecodeString(member.Skills);
            }
        }

        private void LoadEducation()
        {
            rptQualifications.DataSource = null;
            TList<Entities.MemberQualification> memberqualifications = MemberQualificationService.GetByMemberId(SessionData.Member.MemberId);
            if (memberqualifications.Count > 0)
            {
                rptQualifications.DataSource = memberqualifications;
            }
            rptQualifications.DataBind();
        }

        private void LoadPositions()
        {
            rptExperience.DataSource = null;
            TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId);
            memberpositions.Filter = "IsDirectorship = false";
            if (memberpositions.Count > 0)
            {
                rptExperience.DataSource = memberpositions;
            }
            rptExperience.DataBind();
        }

        private void LoadDirectorships()
        {
            rptDirectorship.DataSource = null;
            TList<Entities.MemberPositions> memberpositions = MemberPositionsService.GetByMemberId(SessionData.Member.MemberId);
            memberpositions.Filter = "IsDirectorship = true";
            if (memberpositions.Count > 0)
            {
                rptDirectorship.DataSource = memberpositions;
            }
            rptDirectorship.DataBind();
        }

        protected void rptAMC_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cbAMC = e.Item.FindControl("cbAMC") as CheckBox;
                Literal ltAMC = e.Item.FindControl("ltAMC") as Literal;
                HiddenField hfMembershipID = e.Item.FindControl("hfMembershipID") as HiddenField;

                Entities.MemberMemberships membership = e.Item.DataItem as Entities.MemberMemberships;
                ltAMC.Text = HttpUtility.HtmlEncode(membership.MemberMembershipsName);
                hfMembershipID.Value = membership.MemberMembershipsId.ToString();
            }
        }

        protected void rptQualifications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltQualification = e.Item.FindControl("ltQualification") as Literal;
                Literal ltQualificationInstitutionName = e.Item.FindControl("ltQualificationInstitutionName") as Literal;
                Literal ltStart = e.Item.FindControl("ltStart") as Literal;
                Literal ltEnd = e.Item.FindControl("ltEnd") as Literal;
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                MemberQualification qualification = e.Item.DataItem as MemberQualification;
                ltQualification.Text = qualification.Degree;
                ltQualificationInstitutionName.Text = qualification.SchoolName;
                ltStart.Text = (qualification.StartYear.HasValue) ? qualification.StartYear.Value.ToString() : string.Empty;
                ltEnd.Text = (qualification.EndYear.HasValue) ? qualification.EndYear.Value.ToString() : CommonFunction.GetResourceValue("LabelCurrent");
                lbEdit.CommandArgument = qualification.MemberQualificationId.ToString();
                lbDelete.CommandArgument = qualification.MemberQualificationId.ToString();
            }
        }

        protected void rptQualifications_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            phQualificationTitleError.Visible = false;
            phInstitutionNameError.Visible = false;
            phEndDate.Visible = false;

            if (e.CommandName == "Edit")
            {
                hfQualificationID.Value = e.CommandArgument.ToString();
                phAddEducation.Visible = false;
                phEditEducation.Visible = true;

                Entities.MemberQualification qualification = MemberQualificationService.GetByMemberQualificationId(Convert.ToInt32(e.CommandArgument));
                if (qualification != null)
                {
                    tbQualificationTitle.Text = CommonService.DecodeString(qualification.Degree);
                    tbInstitutionName.Text = CommonService.DecodeString(qualification.SchoolName);
                    ddlStartDate.SelectedValue = qualification.StartYear.Value.ToString();
                    ddlEndDate.SelectedValue = (qualification.EndYear.HasValue) ? qualification.EndYear.Value.ToString() : "Current";
                    // cbCurrent.Checked 
                }
            }
            else if (e.CommandName == "Delete")
            {
                phAddEducation.Visible = true;
                phEditEducation.Visible = false;

                if (MemberQualificationService.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    LoadEducation();
                }
            }

            CallCalendarJS();
        }

        protected void rptDirectorship_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltTitle = e.Item.FindControl("ltTitle") as Literal;
                Literal ltCompany = e.Item.FindControl("ltCompany") as Literal;
                Literal ltDirectorshipStart = e.Item.FindControl("ltDirectorshipStart") as Literal;
                Literal ltDirectorshipEnd = e.Item.FindControl("ltDirectorshipEnd") as Literal;
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                string startmonth = "Jan";
                string endmonth = string.Empty;

                MemberPositions position = e.Item.DataItem as MemberPositions;
                if (position.StartMonth.HasValue)
                {
                    startmonth = shortmonths[position.StartMonth.Value];
                }

                if (position.EndMonth.HasValue)
                {
                    endmonth = shortmonths[position.EndMonth.Value];
                }

                ltTitle.Text = position.Title;
                ltCompany.Text = position.CompanyName;
                ltDirectorshipStart.Text = (position.StartYear.HasValue) ? startmonth + " " + position.StartYear.Value.ToString() : string.Empty;
                ltDirectorshipEnd.Text = (position.EndMonth.HasValue && position.EndYear.HasValue) ? endmonth + " " + position.EndYear.Value.ToString() : CommonFunction.GetResourceValue("LabelCurrent");
                lbEdit.CommandArgument = position.MemberPositionId.ToString();
                lbDelete.CommandArgument = position.MemberPositionId.ToString();
            }
        }

        protected void rptDirectorship_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            phDirectorshipJobTitleError.Visible = false;
            phDirectorshipCompanyNameError.Visible = false;
            phDirectorshipEndError.Visible = false;

            if (e.CommandName == "Edit")
            {
                hfDirectorshipID.Value = e.CommandArgument.ToString();

                phAddDirectorship.Visible = false;
                phEditDirectorship.Visible = true;
                cbAuditCommittee.Checked = false;
                cbRiskCommittee.Checked = false;
                cbNominationsCommittee.Checked = false;
                cbRemunerationCommittee.Checked = false;
                cbOHSCommittee.Checked = false;
                cbOther.Checked = false;

                Entities.MemberPositions position = MemberPositionsService.GetByMemberPositionId(Convert.ToInt32(e.CommandArgument));
                if (position != null)
                {
                    tbDirectorshipJobTitle.Text = CommonService.DecodeString(position.Title);
                    tbDirectorshipCompanyName.Text = CommonService.DecodeString(position.CompanyName);
                    ddlDirectorshipStartMonth.SelectedValue = position.StartMonth.Value.ToString();
                    ddlDirectorshipStart.SelectedValue = position.StartYear.Value.ToString();
                    if (position.EndYear.HasValue && position.EndMonth.HasValue)
                    {
                        ddlDirectorshipEnd.SelectedValue = position.EndYear.Value.ToString();
                        ddlDirectorshipEndMonth.SelectedValue = position.EndMonth.Value.ToString();

                        ddlDirectorshipEnd.Enabled = true;
                        ddlDirectorshipEndMonth.Enabled = true;
                        cbDirectorshipCurrent.Checked = false;
                    }
                    else
                    {
                        ddlDirectorshipEnd.Enabled = false;
                        ddlDirectorshipEndMonth.Enabled = false;
                        cbDirectorshipCurrent.Checked = true;
                    }
                    tbDirectorshipSummary.Text = position.Summary;
                    tbOrganisationWebsite.Text = position.OrganisationWebsite;
                    tbResponsibilities.Text = position.ResponsibilitiesAndAchievements;
                    ddlTypeOfDirectorship.SelectedValue = position.TypeOfDirectorship;
                    ddlTypeOfDirectorship.SelectedValue = position.TypeOfDirectorship;
                    if (!string.IsNullOrWhiteSpace(position.AdditionalRolesAndResponsibilities))
                    {
                        if (position.AdditionalRolesAndResponsibilities.Contains("AuditCommittee"))
                        {
                            cbAuditCommittee.Checked = true;
                        }

                        if (position.AdditionalRolesAndResponsibilities.Contains("RiskCommittee"))
                        {
                            cbRiskCommittee.Checked = true;
                        }

                        if (position.AdditionalRolesAndResponsibilities.Contains("RemunerationCommittee"))
                        {
                            cbRemunerationCommittee.Checked = true;
                        }

                        if (position.AdditionalRolesAndResponsibilities.Contains("NominationsCommittee"))
                        {
                            cbNominationsCommittee.Checked = true;
                        }

                        if (position.AdditionalRolesAndResponsibilities.Contains("OHSCommittee"))
                        {
                            cbOHSCommittee.Checked = true;
                        }
                        if (position.AdditionalRolesAndResponsibilities.Contains("Other"))
                        {
                            cbOther.Checked = true;
                        }



                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                phAddDirectorship.Visible = true;
                phEditDirectorship.Visible = false;


                if (MemberPositionsService.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    LoadDirectorships();
                }
            }
        }
        protected void rptExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltTitle = e.Item.FindControl("ltTitle") as Literal;
                Literal ltCompany = e.Item.FindControl("ltCompany") as Literal;
                Literal ltExperienceStart = e.Item.FindControl("ltExperienceStart") as Literal;
                Literal ltExperienceEnd = e.Item.FindControl("ltExperienceEnd") as Literal;
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                string startmonth = "Jan";
                string endmonth = string.Empty;

                MemberPositions position = e.Item.DataItem as MemberPositions;
                if (position.StartMonth.HasValue)
                {
                    startmonth = shortmonths[position.StartMonth.Value];
                }

                if (position.EndMonth.HasValue)
                {
                    endmonth = shortmonths[position.EndMonth.Value];
                }

                ltTitle.Text = position.Title;
                ltCompany.Text = position.CompanyName;
                ltExperienceStart.Text = (position.StartYear.HasValue) ? startmonth + " " + position.StartYear.Value.ToString() : string.Empty;
                ltExperienceEnd.Text = (position.EndMonth.HasValue && position.EndYear.HasValue) ? endmonth + " " + position.EndYear.Value.ToString() : CommonFunction.GetResourceValue("LabelCurrent");
                lbEdit.CommandArgument = position.MemberPositionId.ToString();
                lbDelete.CommandArgument = position.MemberPositionId.ToString();
            }
        }

        protected void rptExperience_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            phJobTitleError.Visible = false;
            phCompanyNameError.Visible = false;
            phExperienceEndError.Visible = false;

            if (e.CommandName == "Edit")
            {
                hfExperienceID.Value = e.CommandArgument.ToString();

                phAddExperience.Visible = false;
                phEditExperience.Visible = true;

                Entities.MemberPositions position = MemberPositionsService.GetByMemberPositionId(Convert.ToInt32(e.CommandArgument));
                if (position != null)
                {
                    tbJobTitle.Text = CommonService.DecodeString(position.Title);
                    tbCompanyName.Text = CommonService.DecodeString(position.CompanyName);
                    ddlExperienceStart.SelectedValue = position.StartYear.Value.ToString();
                    ddlExperienceStartMonth.SelectedValue = position.StartMonth.Value.ToString();
                    if (position.EndYear.HasValue && position.EndMonth.HasValue)
                    {
                        ddlExperienceEnd.SelectedValue = position.EndYear.Value.ToString();
                        ddlExperienceEndMonth.SelectedValue = position.EndMonth.Value.ToString();

                        ddlExperienceEnd.Enabled = true;
                        ddlExperienceEndMonth.Enabled = true;
                        cbExperienceCurrent.Checked = false;
                    }
                    else
                    {
                        ddlExperienceEnd.Enabled = false;
                        ddlExperienceEndMonth.Enabled = false;
                        cbExperienceCurrent.Checked = true;
                    }
                    tbSummary.Text = CommonService.DecodeString(position.Summary);
                }
            }
            else if (e.CommandName == "Delete")
            {
                phAddExperience.Visible = true;
                phEditExperience.Visible = false;

                if (MemberPositionsService.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    LoadPositions();
                }
            }
        }

        private void LoadMemberships(string values)
        {
            TList<Entities.MemberMemberships> membermemberships = MemberMembershipsService.CustomGetBySiteID(SessionData.Site.MasterSiteId);
            rptAMC.DataSource = membermemberships;
            rptAMC.DataBind();

            divOthers.Style.Value = "display: none";
            tbOthers.Text = string.Empty;

            string[] splits = (string.IsNullOrEmpty(values)) ? null : values.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits != null && splits.Length > 0)
            {

                foreach (RepeaterItem ri in rptAMC.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox cbAMC = ri.FindControl("cbAMC") as CheckBox;
                        Literal ltAMC = ri.FindControl("ltAMC") as Literal;
                        HiddenField hfMembershipID = ri.FindControl("hfMembershipID") as HiddenField;

                        string othertext = string.Empty;
                        foreach (string s in splits)
                        {
                            if (hfMembershipID.Value == s)
                            {
                                cbAMC.Checked = true;
                                break;
                            }
                        }
                    }
                }

                foreach (string s in splits)
                {
                    int membershipid = 0;

                    if (int.TryParse(s, out membershipid) == false)
                    {
                        cbOthers.Checked = true;
                        tbOthers.Text = CommonService.DecodeString(s);
                        divOthers.Style.Value = string.Empty;
                    }
                }

            }
        }

        private void LoadStepTabs(int activestep = 1)
        {

            Entities.MemberWizard memberwizard = MemberWizardService.GetMemberWizardBySite(SessionData.Site.MasterSiteId);
            if (memberwizard == null)
            {
                memberwizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate == true);
            }

            if (memberwizard != null)
            {
                int step = 1;

                if (memberwizard == null) wizardlist = new ArrayList();

                //if (memberwizard.ProfileEnable.HasValue && memberwizard.ProfileEnable.Value)
                {
                    phProfileStep.Visible = true;
                    phProfile.Visible = true;
                    ltProfileStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardprofile\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.ProfileTitle);
                    ltProfile.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title\">{1}</h3>", step, memberwizard.ProfileTitle);

                    if (activestep == step)
                    {
                        ltProfileStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardprofile\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.ProfileTitle);
                        ltProfile.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title\">{1}</h3>", step, memberwizard.ProfileTitle);
                    }

                    ltProfileClose.Text = "</div>";
                    wizardlist.Add("Profile");
                    step++;
                }

                //if (memberwizard.CvEnable.HasValue && memberwizard.CvEnable.Value)
                {
                    phCoverLetterResumeStep.Visible = true;
                    phCoverLetterResume.Visible = true;
                    ltCoverLetterResumeStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardcover\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.CvTitle);
                    ltCoverLetterResume.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.CvTitle);

                    if (activestep == step)
                    {
                        ltCoverLetterResumeStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardcover\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.CvTitle);
                        ltCoverLetterResume.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.CvTitle);
                    }
                    ltCoverLetterResumeClose.Text = "</div>";
                    wizardlist.Add("CV");
                    step++;
                }

                //if (memberwizard.RolePreferencesEnable.HasValue && memberwizard.RolePreferencesEnable.Value)
                {
                    phRolePreferencesStep.Visible = true;
                    phRolePreferences.Visible = true;
                    ltRolePreferencesStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardrole\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.RolePreferencesTitle);
                    ltRolePreferences.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.RolePreferencesTitle);

                    if (activestep == step)
                    {
                        ltRolePreferencesStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardrole\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.RolePreferencesTitle);
                        ltRolePreferences.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.RolePreferencesTitle);
                    }

                    ltRolesClose.Text = "</div>";
                    wizardlist.Add("RolePreferences");
                    step++;
                }

                //if (memberwizard.EducationEnable.HasValue && memberwizard.EducationEnable.Value)
                {
                    phEducationStep.Visible = true;
                    phEducation.Visible = true;
                    ltEducationStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardedu\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.EducationTitle);
                    ltEducation.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.EducationTitle);
                    if (activestep == step)
                    {
                        ltEducationStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardedu\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.EducationTitle);
                        ltEducation.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.EducationTitle);
                    }
                    ltEducationClose.Text = "</div>";
                    wizardlist.Add("Education");
                    step++;
                }

                //if (memberwizard.MembershipsEnable.HasValue && memberwizard.MembershipsEnable.Value)
                {
                    phMembershipsStep.Visible = true;
                    phMemberships.Visible = true;
                    ltMembershipsStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardmembership\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.MembershipsTitle);
                    ltMemberships.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.MembershipsTitle);
                    if (activestep == step)
                    {
                        ltMembershipsStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardmembership\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.MembershipsTitle);
                        ltMemberships.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.MembershipsTitle);
                    }
                    ltMembershipsClose.Text = "</div>";
                    wizardlist.Add("Memberships");
                    step++;
                }

                //if (memberwizard.DirectorshipEnable.HasValue && memberwizard.DirectorshipEnable.Value)
                {
                    phDirectorshipStep.Visible = true;
                    phDirectorship.Visible = true;

                    ltDirectorshipStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizarddirectorship\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.DirectorshipTitle);
                    ltDirectorship.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.DirectorshipTitle);
                    if (activestep == step)
                    {
                        ltDirectorshipStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizarddirectorship\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.DirectorshipTitle);
                        ltDirectorship.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.DirectorshipTitle);
                    }
                    ltDirectorshipClose.Text = "</div>";
                    wizardlist.Add("Directorship Experience");
                    step++;
                }

                //if (memberwizard.ExperienceEnable.HasValue && memberwizard.ExperienceEnable.Value)
                {
                    phExperienceStep.Visible = true;
                    phExperience.Visible = true;
                    ltExperienceStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardexp\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.ExperienceTitle);
                    ltExperience.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.ExperienceTitle);
                    if (activestep == step)
                    {
                        ltExperienceStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardexp\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.ExperienceTitle);
                        ltExperience.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.ExperienceTitle);
                    }
                    ltExperienceClose.Text = "</div>";
                    wizardlist.Add("Experience");
                    step++;
                }

                //if (memberwizard.SkillsEnable.HasValue && memberwizard.SkillsEnable.Value)
                {
                    phSkillsStep.Visible = true;
                    phSkills.Visible = true;
                    ltSkillsStep.Text = string.Format("<li><a href=\"#tab{0}\" id=\"wizardskills\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.SkillsTitle);
                    ltSkills.Text = string.Format("<div class=\"tab-pane fade\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.SkillsTitle);
                    if (activestep == step)
                    {
                        ltSkillsStep.Text = string.Format("<li class=\"active\"><a href=\"#tab{0}\" id=\"wizardskills\" data-toggle=\"tab\"><span class=\"step\">{0}</span><span class=\"step-name\">{1}</span></a></li>", step, memberwizard.SkillsTitle);
                        ltSkills.Text = string.Format("<div class=\"tab-pane fade active in\" id=\"tab{0}\"><h3 class=\"tab-title \">{1}</h3>", step, memberwizard.SkillsTitle);
                    }
                    ltSkillsClose.Text = "</div>";
                    wizardlist.Add("Skills");
                    step++;
                }

                ViewState["Wizard"] = wizardlist;
            }
        }

        private void LoadMemberWizard()
        {
            // Start Year
            List<string> startyears = new List<string>();
            List<ListItem> months = new List<ListItem>();

            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 100; i--)
            {
                startyears.Add(i.ToString());
            }

            months.Add(new ListItem("January", "1"));
            months.Add(new ListItem("February", "2"));
            months.Add(new ListItem("March", "3"));
            months.Add(new ListItem("April", "4"));
            months.Add(new ListItem("May", "5"));
            months.Add(new ListItem("June", "6"));
            months.Add(new ListItem("July", "7"));
            months.Add(new ListItem("August", "8"));
            months.Add(new ListItem("September", "9"));
            months.Add(new ListItem("October", "10"));
            months.Add(new ListItem("November", "11"));
            months.Add(new ListItem("December", "12"));


            ddlStartDate.Items.Clear();
            ddlStartDate.DataSource = startyears;
            ddlStartDate.DataBind();

            ddlDirectorshipStart.Items.Clear();
            ddlDirectorshipStart.DataSource = startyears;
            ddlDirectorshipStart.DataBind();

            ddlExperienceStart.Items.Clear();
            ddlExperienceStart.DataSource = startyears;
            ddlExperienceStart.DataBind();

            List<string> endyears = startyears;
            ddlDirectorshipEnd.Items.Clear();
            ddlDirectorshipEnd.DataSource = startyears;
            ddlDirectorshipEnd.DataBind();

            ddlExperienceEnd.Items.Clear();
            ddlExperienceEnd.DataSource = startyears;
            ddlExperienceEnd.DataBind();

            endyears.Insert(0, "Current");
            ddlEndDate.Items.Clear();
            ddlEndDate.DataSource = startyears;
            ddlEndDate.DataBind();

            ddlDirectorshipStartMonth.Items.Clear();
            ddlDirectorshipEndMonth.Items.Clear();

            ddlDirectorshipStartMonth.DataSource = months;
            ddlDirectorshipStartMonth.DataValueField = "value";
            ddlDirectorshipStartMonth.DataTextField = "text";
            ddlDirectorshipStartMonth.DataBind();

            ddlDirectorshipEndMonth.DataSource = months;
            ddlDirectorshipEndMonth.DataValueField = "value";
            ddlDirectorshipEndMonth.DataTextField = "text";
            ddlDirectorshipEndMonth.DataBind();

            ddlExperienceStartMonth.Items.Clear();
            ddlExperienceEndMonth.Items.Clear();

            ddlExperienceStartMonth.DataSource = months;
            ddlExperienceStartMonth.DataValueField = "value";
            ddlExperienceStartMonth.DataTextField = "text";
            ddlExperienceStartMonth.DataBind();

            ddlExperienceEndMonth.DataSource = months;
            ddlExperienceEndMonth.DataValueField = "value";
            ddlExperienceEndMonth.DataTextField = "text";
            ddlExperienceEndMonth.DataBind();


            LoadStepTabs();
        }

        private void LoadSiteProfession()
        {
            ddlClassification.Items.Clear();
            TList<Entities.SiteProfession> siteprofessions = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId);
            ddlClassification.DataTextField = "SiteProfessionName";
            ddlClassification.DataValueField = "ProfessionID";
            ddlClassification.DataSource = siteprofessions;
            ddlClassification.DataBind();

            ddlClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllClassification"), "0"));
        }

        private void LoadRoles(string values = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select id=\"ddlSubClassification\" name=\"ddlSubClassification\" class=\"multiselect form-control\" multiple>");
            TList<Entities.SiteRoles> siteroles = SiteRolesService.GetByProfessionID(SessionData.Site.SiteId, Convert.ToInt32(ddlClassification.SelectedValue));
            string[] splits = (string.IsNullOrEmpty(values)) ? null : values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Entities.SiteRoles siterole in siteroles)
            {
                if (splits != null && splits.Length > 0)
                {
                    bool found = false;
                    foreach (string s in splits)
                    {
                        if (s == siterole.RoleId.ToString())
                        {
                            sb.AppendLine(string.Format("<option value=\"{0}\" selected>{1}</option>", siterole.RoleId, HttpUtility.HtmlEncode(siterole.SiteRoleName)));
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", siterole.RoleId, HttpUtility.HtmlEncode(siterole.SiteRoleName)));
                    }
                }
                else
                {
                    sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", siterole.RoleId, HttpUtility.HtmlEncode(siterole.SiteRoleName)));
                }
            }
            sb.AppendLine("</select>");
            ltSubClassification.Text = sb.ToString();
        }

        protected void ddlClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfSubClassification.Value = string.Empty;
            LoadRoles();

            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiSubClassification", "$(document).ready(function() {$('#ddlSubClassification').multiselect(); $('#ddlSubClassification').on('change', function () {$('#hfSubClassification').val($('#ddlSubClassification').val());});});", true);
        }

        private void LoadSiteLocation()
        {
            /*
            ddlLocations.Items.Clear();
            List<Entities.SiteLocation> sitelocations = SiteLocationService.GetTranslatedLocationsByCountryID(1);
            ddlLocations.DataTextField = "SiteLocationName";
            ddlLocations.DataValueField = "LocationID";
            ddlLocations.DataSource = sitelocations;
            ddlLocations.DataBind();

            ddlLocations.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllLocation"), "0"));

            */
            ddlLocations.Items.Clear();

            SiteCountriesService siteCountriesService = new SiteCountriesService();
            SiteLocationService siteLocationService = new SiteLocationService();
            List<Entities.SiteCountries> siteCountriesList = siteCountriesService.GetTranslatedCountries();

            ddlLocations.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelAllLocation"), "0"));


            foreach (Entities.SiteCountries siteCountries in siteCountriesList)
            {
                ddlLocations.AddItemGroup(siteCountries.SiteCountryName);

                List<Entities.SiteLocation> filteredList = siteLocationService.GetTranslatedLocationsByCountryID(siteCountries.CountryId);

                foreach (Entities.SiteLocation siteLocation in filteredList)
                {

                    ddlLocations.Items.Add(new ListItem(siteLocation.SiteLocationName, siteLocation.LocationId.ToString()));
                    ddlLocations.Items[ddlLocations.Items.Count - 1].Attributes.Add("data-placeholdertag", siteCountries.Currency);

                }
            }
        }

        private void LoadArea(string values = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select id=\"ddlArea\" name=\"ddlArea\" class=\"multiselect form-control\" multiple>");
            List<Entities.SiteArea> siteareas = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocations.SelectedValue));
            string[] splits = (string.IsNullOrEmpty(values)) ? null : values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Entities.SiteArea sitearea in siteareas)
            {
                if (splits != null && splits.Length > 0)
                {
                    bool found = false;
                    foreach (string s in splits)
                    {
                        if (s == sitearea.AreaId.ToString())
                        {
                            sb.AppendLine(string.Format("<option value=\"{0}\" selected>{1}</option>", sitearea.AreaId, HttpUtility.HtmlEncode(sitearea.SiteAreaName)));
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", sitearea.AreaId, HttpUtility.HtmlEncode(sitearea.SiteAreaName)));
                    }
                }
                else
                {
                    sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", sitearea.AreaId, HttpUtility.HtmlEncode(sitearea.SiteAreaName)));
                }
            }
            sb.AppendLine("</select>");
            ltArea.Text = sb.ToString();
        }

        protected void ddlLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfArea.Value = string.Empty;
            LoadArea();
            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiArea", "$(document).ready(function() {$('#ddlArea').multiselect(); $('#ddlArea').on('change', function () {$('#hfArea').val($('#ddlArea').val());});});", true);
        }

        private void LoadCurrentStatus()
        {
            ddlCurrentStatus.Items.Clear();
            TList<Entities.MemberStatus> statuses = MemberStatusService.CustomGetBySiteID(SessionData.Site.MasterSiteId);
            foreach (Entities.MemberStatus status in statuses)
            {
                ddlCurrentStatus.Items.Add(new ListItem(status.MemberStatusName, status.MemberStatusId.ToString()));
            }
        }

        private void LoadWorkType(string values = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select id=\"ddlWorkType\" name=\"ddlWorkType\" class=\"multiselect form-control\" multiple>");
            TList<Entities.SiteWorkType> siteworktypes = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId);
            string[] splits = values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Entities.SiteWorkType siteworktype in siteworktypes)
            {
                if (splits != null && splits.Length > 0)
                {
                    bool found = false;
                    foreach (string s in splits)
                    {
                        if (s == siteworktype.WorkTypeId.ToString())
                        {
                            sb.AppendLine(string.Format("<option value=\"{0}\" selected>{1}</option>", siteworktype.WorkTypeId, HttpUtility.HtmlEncode(siteworktype.SiteWorkTypeName)));
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", siteworktype.WorkTypeId, HttpUtility.HtmlEncode(siteworktype.SiteWorkTypeName)));
                    }
                }
                else
                {
                    sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", siteworktype.WorkTypeId, HttpUtility.HtmlEncode(siteworktype.SiteWorkTypeName)));
                }
            }
            sb.AppendLine("</select>");
            ltWorkType.Text = sb.ToString();
        }

        private void CallCalendarJS()
        {
            string script = @"$(document).ready(function(){$('#startdate').datetimepicker({
            pickTime: false
            }).on('dp.change', function (e) {
                $('#enddate').data('DateTimePicker').setMinDate(e.date);
            });
            $('#enddate').datetimepicker({
                pickTime: false
            }).on('dp.change', function (e) {
                $('#startdate').data('DateTimePicker').setMaxDate(e.date);
            });});";

            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CalendarJS", script, true);
        }

        protected void lbAddEducation_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phQualificationTitleError.Visible = false;
            phInstitutionNameError.Visible = false;
            phEndDate.Visible = false;

            if (string.IsNullOrWhiteSpace(tbQualificationTitle.Text))
            {
                phQualificationTitleError.Visible = true;
                tbQualificationTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbInstitutionName.Text))
            {
                phInstitutionNameError.Visible = true;
                if (!isFocused)
                {
                    tbInstitutionName.Focus();
                }

                hasError = true;
            }

            if (DateTime.Now < new DateTime(Convert.ToInt32(ddlStartDate.SelectedValue), 1, 1))
            {
                hasError = true;
                phEndDate.Visible = true;
            }


            // Date Error Checking
            if (ddlEndDate.SelectedValue != "Current")
            {
                if (Convert.ToInt32(ddlStartDate.SelectedValue) > Convert.ToInt32(ddlEndDate.SelectedValue))
                {
                    phEndDate.Visible = true;
                    hasError = true;
                }
            }

            if (!hasError)
            {

                MemberQualification qualification = new MemberQualification();
                qualification.Degree = CommonService.EncodeString(tbQualificationTitle.Text);
                qualification.SchoolName = CommonService.EncodeString(tbInstitutionName.Text);


                qualification.StartYear = Convert.ToInt32(ddlStartDate.SelectedValue);
                qualification.EndYear = (ddlEndDate.SelectedValue == "Current") ? (int?)null : Convert.ToInt32(ddlEndDate.SelectedValue);

                qualification.MemberId = SessionData.Member.MemberId;

                if (MemberQualificationService.Insert(qualification))
                {
                    LoadEducation();
                }

                tbQualificationTitle.Text = string.Empty;
                tbInstitutionName.Text = string.Empty;
                ddlStartDate.SelectedIndex = 0;
                ddlEndDate.SelectedIndex = 0;
            }
        }

        protected void lbEditEducation_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phQualificationTitleError.Visible = false;
            phInstitutionNameError.Visible = false;
            phEndDate.Visible = false;

            if (string.IsNullOrWhiteSpace(tbQualificationTitle.Text))
            {
                phQualificationTitleError.Visible = true;
                tbQualificationTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbInstitutionName.Text))
            {
                phInstitutionNameError.Visible = true;
                if (!isFocused)
                {
                    tbInstitutionName.Focus();
                }

                hasError = true;
            }

            // Date Error Checking
            if (ddlEndDate.SelectedValue != "Current")
            {
                if (Convert.ToInt32(ddlStartDate.SelectedValue) > Convert.ToInt32(ddlEndDate.SelectedValue))
                {
                    phEndDate.Visible = true;
                    hasError = true;
                }
            }

            // Make sure the qualification belong to the member

            int qualificationid = 0;
            if (int.TryParse(hfQualificationID.Value, out qualificationid))
            {
                MemberQualification qualification = MemberQualificationService.GetByMemberQualificationId(qualificationid);
                if (qualification != null)
                {
                    if (qualification.MemberId != SessionData.Member.MemberId)
                    {
                        hasError = true;
                    }
                }
                else
                {
                    hasError = true;
                }
            }
            else
            {
                hasError = true;
            }


            if (!hasError)
            {

                MemberQualification qualification = MemberQualificationService.GetByMemberQualificationId(Convert.ToInt32(hfQualificationID.Value));
                qualification.Degree = CommonService.EncodeString(tbQualificationTitle.Text);
                qualification.SchoolName = CommonService.EncodeString(tbInstitutionName.Text);

                qualification.StartYear = Convert.ToInt32(ddlStartDate.SelectedValue);
                qualification.EndYear = (ddlEndDate.SelectedValue == "Current") ? (int?)null : Convert.ToInt32(ddlEndDate.SelectedValue);

                if (MemberQualificationService.Update(qualification))
                {
                    phQualificationTitleError.Visible = false;
                    phInstitutionNameError.Visible = false;

                    phEditEducation.Visible = false;
                    phAddEducation.Visible = true;

                    tbQualificationTitle.Text = string.Empty;
                    tbInstitutionName.Text = string.Empty;
                    ddlStartDate.SelectedIndex = 0;
                    ddlEndDate.SelectedIndex = 0;

                    LoadEducation();
                }
            }

            CallCalendarJS();
        }

        protected void lbCancelEducation_Click(object sender, EventArgs e)
        {
            phEditEducation.Visible = false;
            phAddEducation.Visible = true;

            tbQualificationTitle.Text = string.Empty;
            tbInstitutionName.Text = string.Empty;
            ddlStartDate.SelectedIndex = 0;
            ddlEndDate.SelectedIndex = 0;

            CallCalendarJS();
        }

        protected void lbAddDirectorship_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phDirectorshipJobTitleError.Visible = false;
            phDirectorshipCompanyNameError.Visible = false;
            phDirectorshipEndError.Visible = false;

            //strip all htmls in inputs before doing validation
            Directorship_StripInputsHTML();

            if (string.IsNullOrWhiteSpace(tbDirectorshipJobTitle.Text))
            {
                phDirectorshipJobTitleError.Visible = true;
                tbDirectorshipJobTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbDirectorshipCompanyName.Text))
            {
                phDirectorshipCompanyNameError.Visible = true;
                if (!isFocused)
                {
                    tbDirectorshipCompanyName.Focus();
                }

                hasError = true;
            }

            if (DateTime.Now < new DateTime(Convert.ToInt32(ddlDirectorshipStart.SelectedValue), Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phDirectorshipEndError.Visible = true;
                ddlDirectorshipEndMonth.Focus();
                toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
            }

            if (!hasError)
            {
                if (!cbDirectorshipCurrent.Checked)
                {
                    if (Convert.ToInt32(ddlDirectorshipEnd.SelectedValue) < Convert.ToInt32(ddlDirectorshipStart.SelectedValue))
                    {
                        hasError = true;
                        phDirectorshipEndError.Visible = true;
                        ddlDirectorshipEndMonth.Focus();
                        toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlDirectorshipEnd.SelectedValue) == Convert.ToInt32(ddlDirectorshipStart.SelectedValue)
                            && Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue) < Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue))
                        {
                            hasError = true;
                            phDirectorshipEndError.Visible = true;
                            ddlDirectorshipEndMonth.Focus();
                            toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
                        }
                    }
                }
            }

            if (!hasError)
            {
                MemberPositions position = new MemberPositions();
                position.IsDirectorship = true;
                position.Title = (tbDirectorshipJobTitle.Text);
                position.CompanyName = (tbDirectorshipCompanyName.Text);

                position.StartMonth = Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue);
                position.StartYear = Convert.ToInt32(ddlDirectorshipStart.SelectedValue);

                if (!cbDirectorshipCurrent.Checked)
                {
                    position.EndMonth = Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue);
                    position.EndYear = Convert.ToInt32(ddlDirectorshipEnd.SelectedValue);
                }
                else
                {
                    position.EndMonth = (int?)null;
                    position.EndYear = (int?)null;
                }
                position.Summary = tbDirectorshipSummary.Text;

                position.MemberId = SessionData.Member.MemberId;
                position.IsCurrent = cbDirectorshipCurrent.Checked;
                position.OrganisationWebsite = CommonService.DecodeString(tbOrganisationWebsite.Text);
                position.ResponsibilitiesAndAchievements = CommonService.DecodeString(tbResponsibilities.Text);
                position.TypeOfDirectorship = ddlTypeOfDirectorship.SelectedValue;
                string additionRolesResponsibilities = string.Empty;
                if (cbAuditCommittee.Checked)
                {
                    additionRolesResponsibilities += "AuditCommittee" + ",";
                }
                if (cbRiskCommittee.Checked)
                {
                    additionRolesResponsibilities += "RiskCommittee" + ",";
                }
                if (cbNominationsCommittee.Checked)
                {
                    additionRolesResponsibilities += "NominationsCommittee" + ",";
                }
                if (cbRemunerationCommittee.Checked)
                {
                    additionRolesResponsibilities += "RemunerationCommittee" + ",";
                }
                if (cbOHSCommittee.Checked)
                {
                    additionRolesResponsibilities += "OHSCommittee" + ",";
                }
                if (cbOther.Checked)
                {
                    additionRolesResponsibilities += "Other" + ",";
                }

                position.AdditionalRolesAndResponsibilities = additionRolesResponsibilities.TrimEnd(new char[] { ',' });

                if (MemberPositionsService.Insert(position))
                {
                    tbDirectorshipJobTitle.Text = string.Empty;
                    tbDirectorshipCompanyName.Text = string.Empty;
                    ddlDirectorshipStart.SelectedIndex = 0;
                    ddlDirectorshipStartMonth.SelectedIndex = 0;
                    ddlDirectorshipEnd.SelectedIndex = 0;
                    ddlDirectorshipEndMonth.SelectedIndex = 0;
                    ddlDirectorshipEnd.Enabled = true;
                    ddlDirectorshipEndMonth.Enabled = true;
                    cbDirectorshipCurrent.Checked = false;
                    tbDirectorshipSummary.Text = string.Empty;
                    tbOrganisationWebsite.Text = string.Empty;
                    tbResponsibilities.Text = string.Empty;
                    cbAuditCommittee.Checked = false;
                    cbRiskCommittee.Checked = false;
                    cbNominationsCommittee.Checked = false;
                    cbRemunerationCommittee.Checked = false;
                    cbOHSCommittee.Checked = false;
                    cbOther.Checked = false;
                    ddlTypeOfDirectorship.SelectedIndex = 0;
                    LoadDirectorships();
                }
            }
        }

        protected void lbEditDirectorship_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phDirectorshipJobTitleError.Visible = false;
            phDirectorshipCompanyNameError.Visible = false;
            phDirectorshipEndError.Visible = false;
            ddlDirectorshipEndMonth.Enabled = !cbDirectorshipCurrent.Checked;
            ddlDirectorshipEnd.Enabled = !cbDirectorshipCurrent.Checked;

            //strip all htmls in inputs before doing validation
            Directorship_StripInputsHTML();

            if (string.IsNullOrWhiteSpace(tbDirectorshipJobTitle.Text))
            {
                phDirectorshipJobTitleError.Visible = true;
                tbDirectorshipJobTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbDirectorshipCompanyName.Text))
            {
                phDirectorshipCompanyNameError.Visible = true;
                if (!isFocused)
                {
                    tbDirectorshipCompanyName.Focus();
                }

                hasError = true;
            }

            if (DateTime.Now < new DateTime(Convert.ToInt32(ddlDirectorshipStart.SelectedValue), Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phDirectorshipEndError.Visible = true;
                ddlDirectorshipEndMonth.Focus();
                toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
            }

            if (!hasError)
            {

                if (!cbDirectorshipCurrent.Checked)
                {
                    if (Convert.ToInt32(ddlDirectorshipEnd.SelectedValue) < Convert.ToInt32(ddlDirectorshipStart.SelectedValue))
                    {
                        hasError = true;
                        phDirectorshipEndError.Visible = true;
                        ddlDirectorshipEndMonth.Focus();
                        toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlDirectorshipEnd.SelectedValue) == Convert.ToInt32(ddlDirectorshipStart.SelectedValue)
                            && Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue) < Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue))
                        {
                            hasError = true;
                            phDirectorshipEndError.Visible = true;
                            ddlDirectorshipEndMonth.Focus();
                            toolkitScriptManager.SetFocus(ddlDirectorshipEndMonth);
                        }
                    }
                }
            }

            if (!hasError)
            {
                MemberPositions position = MemberPositionsService.GetByMemberPositionId(Convert.ToInt32(hfDirectorshipID.Value));
                position.Title = tbDirectorshipJobTitle.Text;
                position.CompanyName = tbDirectorshipCompanyName.Text;

                position.StartMonth = Convert.ToInt32(ddlDirectorshipStartMonth.SelectedValue);
                position.StartYear = Convert.ToInt32(ddlDirectorshipStart.SelectedValue);

                if (!cbDirectorshipCurrent.Checked)
                {
                    position.EndMonth = Convert.ToInt32(ddlDirectorshipEndMonth.SelectedValue);
                    position.EndYear = Convert.ToInt32(ddlDirectorshipEnd.SelectedValue);
                }
                else
                {
                    position.EndMonth = (int?)null;
                    position.EndYear = (int?)null;
                }
                position.Summary = (tbDirectorshipSummary.Text);
                position.IsCurrent = cbDirectorshipCurrent.Checked;
                position.OrganisationWebsite = (tbOrganisationWebsite.Text);
                position.ResponsibilitiesAndAchievements = (tbResponsibilities.Text);
                position.TypeOfDirectorship = ddlTypeOfDirectorship.SelectedValue;
                string additionRolesResponsibilities = string.Empty;
                if (cbAuditCommittee.Checked)
                {
                    additionRolesResponsibilities += "AuditCommittee" + ",";
                }
                if (cbRiskCommittee.Checked)
                {
                    additionRolesResponsibilities += "RiskCommittee" + ",";
                }
                if (cbNominationsCommittee.Checked)
                {
                    additionRolesResponsibilities += "NominationsCommittee" + ",";
                }
                if (cbRemunerationCommittee.Checked)
                {
                    additionRolesResponsibilities += "RemunerationCommittee" + ",";
                }
                if (cbOHSCommittee.Checked)
                {
                    additionRolesResponsibilities += "OHSCommittee" + ",";
                }
                if (cbOther.Checked)
                {
                    additionRolesResponsibilities += "Other" + ",";
                }

                position.AdditionalRolesAndResponsibilities = additionRolesResponsibilities.TrimEnd(new char[] { ',' });

                if (MemberPositionsService.Update(position))
                {
                    phJobTitleError.Visible = false;
                    phCompanyNameError.Visible = false;
                    phEditDirectorship.Visible = false;
                    phAddDirectorship.Visible = true;

                    tbDirectorshipJobTitle.Text = string.Empty;
                    tbDirectorshipCompanyName.Text = string.Empty;
                    ddlDirectorshipStart.SelectedIndex = 0;
                    ddlDirectorshipStartMonth.SelectedIndex = 0;
                    ddlDirectorshipEnd.SelectedIndex = 0;
                    ddlDirectorshipEndMonth.SelectedIndex = 0;
                    ddlDirectorshipEnd.Enabled = true;
                    ddlDirectorshipEndMonth.Enabled = true;
                    cbDirectorshipCurrent.Checked = false;
                    tbDirectorshipSummary.Text = string.Empty;
                    tbOrganisationWebsite.Text = string.Empty;
                    tbResponsibilities.Text = string.Empty;
                    cbAuditCommittee.Checked = false;
                    cbRiskCommittee.Checked = false;
                    cbNominationsCommittee.Checked = false;
                    cbRemunerationCommittee.Checked = false;
                    cbOHSCommittee.Checked = false;
                    cbOther.Checked = false;
                    ddlTypeOfDirectorship.SelectedIndex = 0;
                    LoadDirectorships();
                }
            }
        }

        protected void lbCancelDirectorship_Click(object sender, EventArgs e)
        {
            phEditDirectorship.Visible = false;
            phAddDirectorship.Visible = true;
            phDirectorshipEndError.Visible = false;

            tbDirectorshipJobTitle.Text = string.Empty;
            tbDirectorshipCompanyName.Text = string.Empty;
            ddlDirectorshipStart.SelectedIndex = 0;
            ddlDirectorshipStartMonth.SelectedIndex = 0;
            ddlDirectorshipEnd.SelectedIndex = 0;
            ddlDirectorshipEndMonth.SelectedIndex = 0;
            ddlDirectorshipEnd.Enabled = true;
            ddlDirectorshipEndMonth.Enabled = true;
            cbDirectorshipCurrent.Checked = false;
            tbDirectorshipSummary.Text = string.Empty;
            tbOrganisationWebsite.Text = string.Empty;
            tbResponsibilities.Text = string.Empty;
            cbAuditCommittee.Checked = false;
            cbRiskCommittee.Checked = false;
            cbNominationsCommittee.Checked = false;
            cbRemunerationCommittee.Checked = false;
            cbOHSCommittee.Checked = false;
            cbOther.Checked = false;
            ddlTypeOfDirectorship.SelectedIndex = 0;
        }

        protected void lbAddExperience_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phJobTitleError.Visible = false;
            phCompanyNameError.Visible = false;
            phExperienceEndError.Visible = false;

            //strip all htmls in inputs before doing validation
            Experience_StripInputsHTML();

            if (string.IsNullOrWhiteSpace(tbJobTitle.Text))
            {
                phJobTitleError.Visible = true;
                tbJobTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbCompanyName.Text))
            {
                phCompanyNameError.Visible = true;
                if (!isFocused)
                {
                    tbCompanyName.Focus();
                }

                hasError = true;
            }

            if (DateTime.Now < new DateTime(Convert.ToInt32(ddlExperienceStart.SelectedValue), Convert.ToInt32(ddlExperienceStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phExperienceEndError.Visible = true;
            }

            if (!cbExperienceCurrent.Checked)
            {
                if (Convert.ToInt32(ddlExperienceEnd.SelectedValue) < Convert.ToInt32(ddlExperienceStart.SelectedValue))
                {
                    hasError = true;
                    phExperienceEndError.Visible = true;
                }
                else
                {
                    if (Convert.ToInt32(ddlExperienceEnd.SelectedValue) == Convert.ToInt32(ddlExperienceStart.SelectedValue)
                        && Convert.ToInt32(ddlExperienceEndMonth.SelectedValue) < Convert.ToInt32(ddlExperienceStartMonth.SelectedValue))
                    {
                        hasError = true;
                        phExperienceEndError.Visible = true;
                    }
                }
            }

            if (!hasError)
            {
                MemberPositions position = new MemberPositions();
                position.IsDirectorship = false;
                position.Title = (tbJobTitle.Text);
                position.CompanyName = (tbCompanyName.Text);

                position.StartMonth = Convert.ToInt32(ddlExperienceStartMonth.SelectedValue);
                position.StartYear = Convert.ToInt32(ddlExperienceStart.SelectedValue);

                if (!cbExperienceCurrent.Checked)
                {
                    position.EndMonth = Convert.ToInt32(ddlExperienceEndMonth.SelectedValue);
                    position.EndYear = Convert.ToInt32(ddlExperienceEnd.SelectedValue);
                }
                else
                {
                    position.EndMonth = (int?)null;
                    position.EndYear = (int?)null;
                }
                position.Summary = tbSummary.Text;

                position.MemberId = SessionData.Member.MemberId;
                position.IsCurrent = cbExperienceCurrent.Checked;

                if (MemberPositionsService.Insert(position))
                {
                    tbJobTitle.Text = string.Empty;
                    tbCompanyName.Text = string.Empty;
                    ddlExperienceStart.SelectedIndex = 0;
                    ddlExperienceStartMonth.SelectedIndex = 0;
                    ddlExperienceEnd.SelectedIndex = 0;
                    ddlExperienceEndMonth.SelectedIndex = 0;
                    ddlExperienceEnd.Enabled = true;
                    ddlExperienceEndMonth.Enabled = true;
                    cbExperienceCurrent.Checked = false;
                    tbSummary.Text = string.Empty;

                    LoadPositions();
                }
            }
        }

        protected void lbEditExperience_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            bool isFocused = false;
            phJobTitleError.Visible = false;
            phCompanyNameError.Visible = false;
            phExperienceEndError.Visible = false;
            ddlExperienceEndMonth.Enabled = !cbExperienceCurrent.Checked;
            ddlExperienceEnd.Enabled = !cbExperienceCurrent.Checked;

            //strip all htmls in inputs before doing validation
            Experience_StripInputsHTML();

            if (string.IsNullOrWhiteSpace(tbJobTitle.Text))
            {
                phJobTitleError.Visible = true;
                tbJobTitle.Focus();
                isFocused = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tbCompanyName.Text))
            {
                phCompanyNameError.Visible = true;
                if (!isFocused)
                {
                    tbCompanyName.Focus();
                }

                hasError = true;
            }

            if (DateTime.Now < new DateTime(Convert.ToInt32(ddlExperienceStart.SelectedValue), Convert.ToInt32(ddlExperienceStartMonth.SelectedValue), 1))
            {
                hasError = true;
                phExperienceEndError.Visible = true;
            }

            if (!cbExperienceCurrent.Checked)
            {
                if (Convert.ToInt32(ddlExperienceEnd.SelectedValue) < Convert.ToInt32(ddlExperienceStart.SelectedValue))
                {
                    hasError = true;
                    phExperienceEndError.Visible = true;
                }
                else
                {
                    if (Convert.ToInt32(ddlExperienceEnd.SelectedValue) == Convert.ToInt32(ddlExperienceStart.SelectedValue)
                        && Convert.ToInt32(ddlExperienceEndMonth.SelectedValue) < Convert.ToInt32(ddlExperienceStartMonth.SelectedValue))
                    {
                        hasError = true;
                        phExperienceEndError.Visible = true;
                    }
                }
            }

            // Make sure the position belong to the member

            int positionid = 0;
            if (int.TryParse(hfExperienceID.Value, out positionid))
            {
                MemberPositions position = MemberPositionsService.GetByMemberPositionId(positionid);
                if (position != null)
                {
                    if (position.MemberId != SessionData.Member.MemberId)
                    {
                        hasError = true;
                    }
                }
                else
                {
                    hasError = true;
                }
            }
            else
            {
                hasError = true;
            }

            if (!hasError)
            {

                MemberPositions position = MemberPositionsService.GetByMemberPositionId(Convert.ToInt32(hfExperienceID.Value));
                position.Title = (tbJobTitle.Text);
                position.CompanyName = (tbCompanyName.Text);

                position.StartMonth = Convert.ToInt32(ddlExperienceStartMonth.SelectedValue);
                position.StartYear = Convert.ToInt32(ddlExperienceStart.SelectedValue);

                if (!cbExperienceCurrent.Checked)
                {
                    position.EndMonth = Convert.ToInt32(ddlExperienceEndMonth.SelectedValue);
                    position.EndYear = Convert.ToInt32(ddlExperienceEnd.SelectedValue);
                }
                else
                {
                    position.EndMonth = (int?)null;
                    position.EndYear = (int?)null;
                }
                position.Summary = tbSummary.Text;
                position.IsCurrent = cbExperienceCurrent.Checked;

                if (MemberPositionsService.Update(position))
                {
                    phJobTitleError.Visible = false;
                    phCompanyNameError.Visible = false;
                    phEditExperience.Visible = false;
                    phAddExperience.Visible = true;
                    tbJobTitle.Text = string.Empty;
                    tbCompanyName.Text = string.Empty;
                    ddlExperienceStart.SelectedIndex = 0;
                    ddlExperienceStartMonth.SelectedIndex = 0;
                    ddlExperienceEnd.SelectedIndex = 0;
                    ddlExperienceEndMonth.SelectedIndex = 0;
                    ddlExperienceEnd.Enabled = true;
                    ddlExperienceEndMonth.Enabled = true;
                    cbExperienceCurrent.Checked = false;
                    tbSummary.Text = string.Empty;
                    LoadPositions();
                }
            }
        }

        protected void lbCancelExperience_Click(object sender, EventArgs e)
        {
            phEditExperience.Visible = false;
            phAddExperience.Visible = true;

            tbJobTitle.Text = string.Empty;
            tbCompanyName.Text = string.Empty;
            ddlExperienceStart.SelectedIndex = 0;
            ddlExperienceStartMonth.SelectedIndex = 0;
            ddlExperienceEnd.SelectedIndex = 0;
            ddlExperienceEndMonth.SelectedIndex = 0;
            ddlExperienceEnd.Enabled = true;
            ddlExperienceEndMonth.Enabled = true;
            cbExperienceCurrent.Checked = false;
            tbSummary.Text = string.Empty;
        }

        protected void lbFinish_Click(object sender, EventArgs e)
        {
            Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);
            if (member != null)
            {
                member.Skills = CommonService.EncodeString(skillTags.Text);
                if (MembersService.Update(member))
                {
                    Response.Redirect("CVProfile.aspx");
                }

            }
        }

        protected void CoverLetter_CheckedChanged(object sender, EventArgs e)
        {
            phUploadCoverLetter.Visible = rbUploadCoverLetter.Checked;
            phWriteCoverLetter.Visible = rbWriteCoverLetter.Checked;

            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "SetCVCSS", "$('input:not([type=checkbox]):not([type=submit]):not([type=reset]):not([type=file]):not([type=image]):not([type=date]):not([type=radio]), select, textarea').addClass('form-control');", true);

        }

        protected void lbSaveAndContinue_Click(object sender, EventArgs e)
        {
            int index = 0;
            int.TryParse(hfCurrentTab.Value.Replace("#tab", string.Empty), out index);

            if (index > 0)
            {
                wizardlist = ViewState["Wizard"] as ArrayList;
                string tabname = wizardlist[index - 1].ToString();

                if (tabname == "Profile")
                {
                    phProfileErrorType.Visible = false;
                    phProfileErrorSize.Visible = false;

                    bool hasError = false;
                    bool isFocused = false;
                    phHeadline.Visible = false;
                    phShortBio.Visible = false;

                    if (string.IsNullOrWhiteSpace(tbHeadline.Text))
                    {
                        phHeadline.Visible = true;
                        tbHeadline.Focus();
                        isFocused = true;
                        hasError = true;
                    }

                    if (string.IsNullOrWhiteSpace(tbShortBio.Text))
                    {
                        phShortBio.Visible = true;
                        if (!isFocused)
                        {
                            tbShortBio.Focus();
                        }

                        hasError = true;
                    }


                    if (hasError)
                    {
                        ResetBootstrap(1);
                        return;
                    }
                    else
                    {
                        Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

                        if (member != null)
                        {
                            member.PreferredJobTitle = CommonService.EncodeString(tbHeadline.Text);
                            member.ShortBio = CommonService.EncodeString(tbShortBio.Text);
                            member.MemberStatusId = Convert.ToInt32(ddlCurrentStatus.SelectedValue);

                            if (fuProfile.HasFile && fuProfile.PostedFile.ContentLength > 0)
                            {
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
                                    phProfileErrorType.Visible = true;
                                }

                                if (!hasError && fuProfile.PostedFile.ContentLength > 512000)
                                {
                                    hasError = true;
                                    phProfileErrorSize.Visible = true;
                                }

                                if (!hasError)
                                {
                                    FileManagerService.UploadFile(bucketName, candidateFolder, filename, fuProfile.PostedFile.InputStream, out errormsg);

                                    if (string.IsNullOrEmpty(errormsg))
                                    {
                                        member.ProfilePicture = filename;
                                        imProfile.Visible = true;
                                        imProfile.ImageUrl = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberUploadPicturePaths"], filename);
                                    }
                                }
                            }

                            MembersService.Update(member);
                        }
                    }

                }
                else if (tabname == "CV")
                {
                    // Cover Letter

                    phCoverLetterError.Visible = false;
                    phResumeError.Visible = false;

                    bool hasExistingCoverLetter = false;
                    bool coverLetterError = false;
                    bool updateCoverLetter = false;
                    bool resumeError = false;
                    MemberFiles mf = new MemberFiles();
                    TList<Entities.MemberFiles> memberfiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId);
                    foreach (MemberFiles memberfile in memberfiles)
                    {
                        if (memberfile.DocumentTypeId == 1)
                        {
                            mf = memberfile;
                            hasExistingCoverLetter = true;
                            break;
                        }
                    }

                    if (rbUploadCoverLetter.Checked)
                    {
                        if (fuCoverletter.HasFile && fuCoverletter.PostedFile.ContentLength > 0)
                        {
                            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                            {
                                mf.MemberFileName = System.IO.Path.GetFileName(fuCoverletter.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                            }
                            mf.MemberFileSearchExtension = System.IO.Path.GetExtension(fuCoverletter.PostedFile.FileName).Trim();

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
                                coverLetterError = true;
                                phCoverLetterError.Visible = true;
                            }
                            else
                            {
                                updateCoverLetter = true;

                                if (hasExistingCoverLetter)
                                {
                                    string extension = string.Empty;
                                    extension = Path.GetExtension(fuCoverletter.PostedFile.FileName);

                                    string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, mf.MemberFileSearchExtension);
                                    string errormessage = string.Empty;

                                    FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, fuCoverletter.PostedFile.InputStream, out errormessage);

                                    mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                }

                                mf.MemberFileTitle = mf.MemberFileName;
                                mf.MemberId = SessionData.Member.MemberId;
                                mf.MemberFileTypeId = MemberFileTypeID(fuCoverletter.PostedFile.FileName);
                                mf.DocumentTypeId = 1;
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(tbWriteCoverLetter.Text))
                        {
                            updateCoverLetter = true;

                            mf.MemberFileName = "CoverLetter.txt";

                            mf.MemberFileSearchExtension = System.IO.Path.GetExtension("CoverLetter.txt").Trim();

                            if (hasExistingCoverLetter)
                            {
                                string filepath = string.Format("MemberFiles_{0}{1}", SessionData.Member.MemberId, mf.MemberFileId, mf.MemberFileSearchExtension);
                                string errormessage = string.Empty;

                                FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, new MemoryStream(Encoding.UTF8.GetBytes(tbWriteCoverLetter.Text)), out errormessage);
                            }

                            mf.MemberFileTitle = "CoverLetter.txt";
                            mf.MemberId = SessionData.Member.MemberId;
                            mf.MemberFileTypeId = MemberFileTypeID("CoverLetter.txt");
                            mf.DocumentTypeId = 1;
                        }
                    }

                    if (updateCoverLetter)
                    {
                        if (string.IsNullOrWhiteSpace(mf.MemberFileUrl) || mf.MemberFileContent != null)
                        {
                            if (hasExistingCoverLetter)
                            {
                                if (MemberFilesService.Update(mf))
                                {
                                    LoadCV();
                                }
                            }
                            else
                            {
                                if (MemberFilesService.Insert(mf))
                                {
                                    string extension = string.Empty;

                                    if (rbUploadCoverLetter.Checked)
                                    {
                                        extension = Path.GetExtension(fuCoverletter.PostedFile.FileName);
                                        string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                        string errormessage = string.Empty;

                                        FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, fuCoverletter.PostedFile.InputStream, out errormessage);
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(tbWriteCoverLetter.Text))
                                        {
                                            extension = ".txt";
                                            string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                            string errormessage = string.Empty;

                                            FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, new MemoryStream(Encoding.UTF8.GetBytes(tbWriteCoverLetter.Text)), out errormessage);
                                        }
                                    }
                                    mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                    mf.MemberFileTitle = mf.MemberFileName;
                                    mf.MemberId = SessionData.Member.MemberId;
                                    mf.MemberFileTypeId = MemberFileTypeID(fuCoverletter.PostedFile.FileName);
                                    mf.DocumentTypeId = 1;

                                    MemberFilesService.Update(mf);

                                    LoadCV();
                                }
                            }
                        }
                    }

                    // Resume

                    if (fuResume.HasFile && fuResume.PostedFile.ContentLength > 0)
                    {
                        bool hasExistingResume = false;
                        bool updateResume = false;
                        mf = new MemberFiles();
                        memberfiles = MemberFilesService.GetByMemberId(SessionData.Member.MemberId);
                        foreach (MemberFiles memberfile in memberfiles)
                        {
                            if (memberfile.DocumentTypeId == 2)
                            {
                                mf = memberfile;
                                hasExistingResume = true;
                                break;
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
                            resumeError = true;
                            phResumeError.Visible = true;
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
                            if (hasExistingResume)
                            {
                                string extension = string.Empty;

                                if (rbUploadCoverLetter.Checked)
                                {
                                    extension = Path.GetExtension(fuResume.PostedFile.FileName);
                                    string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                    string errormessage = string.Empty;

                                    FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, fuResume.PostedFile.InputStream, out errormessage);

                                    mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                }

                                if (MemberFilesService.Update(mf))
                                {
                                    LoadCV();
                                }
                            }
                            else
                            {
                                if (MemberFilesService.Insert(mf))
                                {
                                    string extension = string.Empty;

                                    extension = Path.GetExtension(fuResume.PostedFile.FileName);
                                    string filepath = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                                    string errormessage = string.Empty;

                                    FileManagerService.UploadFile(bucketName, string.Format("{0}/{1}", memberFileFolder, SessionData.Member.MemberId), filepath, fuResume.PostedFile.InputStream, out errormessage);
                                    
                                    mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);

                                    if (MemberFilesService.Update(mf))
                                    {
                                        LoadCV();
                                    }
                                }
                            }
                        }
                    }

                    if (coverLetterError || resumeError)
                    {
                        ResetBootstrap(2);
                        return;
                    }

                }
                else if (tabname == "RolePreferences")
                {
                    Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

                    if (member != null)
                    {
                        if (ddlLocations.SelectedValue != "0")
                        {
                            member.LocationId = ddlLocations.SelectedValue;
                            member.AreaId = hfArea.Value;
                        }

                        if (ddlClassification.SelectedValue != "0")
                        {
                            member.PreferredCategoryId = ddlClassification.SelectedValue;

                            member.PreferredSubCategoryId = hfSubClassification.Value;

                        }

                        member.WorkTypeId = hfWorkType.Value;

                        // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce.
                        SalesforceMemberSync memberSync = new SalesforceMemberSync(member);

                        MembersService.Update(member);
                    }
                }
                else if (tabname == "Education") { }
                else if (tabname == "Memberships")
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (RepeaterItem ri in rptAMC.Items)
                    {
                        if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox cbAMC = ri.FindControl("cbAMC") as CheckBox;
                            Literal ltAMC = ri.FindControl("ltAMC") as Literal;
                            HiddenField hfMembershipID = ri.FindControl("hfMembershipID") as HiddenField;

                            if (cbAMC.Checked)
                            {
                                sb.Append(hfMembershipID.Value + "|");
                            }
                        }
                    }

                    if (cbOthers.Checked && string.IsNullOrWhiteSpace(tbOthers.Text) == false)
                    {
                        sb.Append(CommonService.EncodeString(tbOthers.Text));
                    }

                    Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);
                    if (member != null)
                    {
                        member.Memberships = sb.ToString().TrimEnd(new char[] { '|' });
                        if (MembersService.Update(member))
                        {
                            LoadMemberships(member.Memberships);
                        }
                    }
                }
                else if (tabname == "Experience") { }
                else if (tabname == "Skills")
                {

                }
            }

            if (index == ((ArrayList)ViewState["Wizard"]).Count)
            {
                btnSaveAndContinue.Style.Value = "display: none;";
                liFinish.Style.Value = string.Empty;
            }
            else
            {
                linext.Style.Value = "display: inline;";
                btnSaveAndContinue.Style.Value = string.Empty;
                liFinish.Style.Value = "display: none;";
            }
            ResetBootstrap(index + 1);
            Entities.Members member2 = MembersService.GetByMemberId(SessionData.Member.MemberId);
            if (member2 != null)
            {
                LoadArea(member2.AreaId);
                LoadRoles(member2.PreferredSubCategoryId);

                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiArea", "$(document).ready(function() {$('#ddlArea').multiselect(); $('#ddlArea').on('change', function () {$('#hfArea').val($('#ddlArea').val());});});", true);
                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiSubClassification", "$(document).ready(function() {$('#ddlSubClassification').multiselect(); $('#ddlSubClassification').on('change', function () {$('#hfSubClassification').val($('#ddlSubClassification').val());});});", true);
                LoadWorkType(string.IsNullOrEmpty(member2.WorkTypeId) ? "" : member2.WorkTypeId);
            }
            divOthers.Style.Value = (cbOthers.Checked) ? string.Empty : "display: none";
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

        private void ResetBootstrap(int tabid)
        {
            LoadStepTabs(tabid);
            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Reset", Resources.CVBuilderResource.CVBuilderScript, true);
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

        protected void btnResumeDelete_Click(object sender, EventArgs e)
        {
            if (MemberFilesService.Delete(Convert.ToInt32(hfResumeDocID.Value)))
            {
                LoadCV();
            }
        }

        protected void btnCoverLetterDelete_Click(object sender, EventArgs e)
        {
            if (MemberFilesService.Delete(Convert.ToInt32(hfCoverLetterID.Value)))
            {
                LoadCV();
            }
        }


        #region Private Methods

        private void Directorship_StripInputsHTML()
        {
            tbDirectorshipJobTitle.Text = CommonService.EncodeString(tbDirectorshipJobTitle.Text);
            tbDirectorshipCompanyName.Text = CommonService.EncodeString(tbDirectorshipCompanyName.Text);
            tbDirectorshipSummary.Text = CommonService.EncodeString(tbDirectorshipSummary.Text);
            tbOrganisationWebsite.Text = CommonService.EncodeString(tbOrganisationWebsite.Text);
            tbResponsibilities.Text = CommonService.EncodeString(tbResponsibilities.Text);
        }

        private void Experience_StripInputsHTML()
        {
            tbJobTitle.Text = CommonService.EncodeString(tbJobTitle.Text);
            tbCompanyName.Text = CommonService.EncodeString(tbCompanyName.Text);

            tbSummary.Text = CommonService.EncodeString(tbSummary.Text);
        }


        #endregion

    }
}