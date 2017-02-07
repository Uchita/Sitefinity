#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Website;
using JXTPortal.Common;
using JXTPortal;
using JXTPortal.Client.Salesforce;
using JXTPortal.Client.Bullhorn;
using System.Configuration;
using log4net;
#endregion

public partial class MembersEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int memberID = 0;
    private SiteProfessionService _siteProfessionService;
    private SiteRolesService _siteRolesService;
    private CountriesService _countriesService;
    private GlobalLocationService _globalLocationService;
    private GlobalAreaService _globalAreaService;
    private AreaService _areaService;
    private RolesService _rolesService;
    private GlobalSettingsService _globalSettingsService;
    private DynamicContentService  _dynamicContentService;
    private ILog _logger;
    #endregion

    #region Properties

    private SiteCountriesService _siteCountriesService;
    private SiteCountriesService SiteCountriesService
    {
        get
        {
            if (_siteCountriesService == null)
            {
                _siteCountriesService = new SiteCountriesService();
            }
            return _siteCountriesService;
        }
    }

    MembersService _membersService;
    MembersService MembersService
    {
        get
        {
            if (_membersService == null)
            {
                _membersService = new JXTPortal.MembersService();
            }
            return _membersService;
        }
    }


    MemberFilesService _memberFileService;
    MemberFilesService MemberFileService
    {
        get
        {
            if (_memberFileService == null)
            {
                _memberFileService = new JXTPortal.MemberFilesService();
            }
            return _memberFileService;
        }
    }

    private int MemberID
    {
        get
        {
            if ((Request.QueryString["MemberID"] != null))
            {
                if (int.TryParse((Request.QueryString["MemberID"].Trim()), out memberID))
                {
                    memberID = Convert.ToInt32(Request.QueryString["MemberID"]);
                }
                return memberID;
            }

            return memberID;
        }
    }

    MemberFilesService _membersFilesService;
    MemberFilesService MembersFilesService
    {
        get
        {
            if (_membersFilesService == null)
            {
                _membersFilesService = new JXTPortal.MemberFilesService();
            }
            return _membersFilesService;
        }
    }

    JobAlertsService _jobalertsservice;
    JobAlertsService JobAlertsService
    {
        get
        {
            if (_jobalertsservice == null)
            {
                _jobalertsservice = new JXTPortal.JobAlertsService();
            }
            return _jobalertsservice;
        }
    }

    EducationsService _educationsService;
    EducationsService EducationsService
    {
        get
        {
            if (_educationsService == null)
            {
                _educationsService = new EducationsService();
            }
            return _educationsService;
        }
    }

    AvailableStatusService _availableStatusService;
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

    private CountriesService CountriesService
    {
        get
        {
            if (_countriesService == null)
                _countriesService = new CountriesService();
            return _countriesService;
        }
    }

    private GlobalLocationService GlobalLocationService
    {
        get
        {
            if (_globalLocationService == null)
            {
                _globalLocationService = new GlobalLocationService();
            }
            return _globalLocationService;
        }
    }

    private GlobalAreaService GlobalAreaService
    {
        get
        {
            if (_globalAreaService == null)
                _globalAreaService = new GlobalAreaService();
            return _globalAreaService;
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

    private RolesService RolesService
    {
        get
        {
            if (_rolesService == null)
                _rolesService = new RolesService();
            return _rolesService;
        }
    }

    private SitesService _sitesService;
    private SitesService SitesService
    {
        get
        {
            if (_sitesService == null) _sitesService = new SitesService();

            return _sitesService;
        }
    }

    private GlobalSettingsService GlobalSettingsService
    {
        get
        {
            if (_globalSettingsService == null) _globalSettingsService = new GlobalSettingsService();

            return _globalSettingsService;
        }
    }

    private TList<JXTPortal.Entities.Educations> siteEducations;
    private TList<JXTPortal.Entities.AvailableStatus> siteAvailableStatus;

    private SiteSalaryTypeService _sitesalarytypeservice;
    private SiteSalaryTypeService SiteSalaryTypeService
    {
        get
        {
            if (_sitesalarytypeservice == null)
                _sitesalarytypeservice = new SiteSalaryTypeService();
            return _sitesalarytypeservice;
        }

    }

    private ViewSalaryService _viewsalaryservice = null;
    private ViewSalaryService ViewSalaryService
    {
        get
        {
            if (_viewsalaryservice == null)
                _viewsalaryservice = new ViewSalaryService();
            return _viewsalaryservice;
        }
    }

    private SiteLanguagesService _sitelanguagesservice = null;
    private SiteLanguagesService SiteLanguagesService
    {
        get
        {
            if (_sitelanguagesservice == null)
                _sitelanguagesservice = new SiteLanguagesService();
            return _sitelanguagesservice;
        }
    }

    private DynamicContentService DynamicContentService
    {
        get
        {
            if (_dynamicContentService == null)
            {
                _dynamicContentService = new DynamicContentService();
            }
            return _dynamicContentService;
        }
    }


    public string SalaryLowerBand
    {
        get
        {
            //decimal? _temp = CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text);
            //if (!String.IsNullOrWhiteSpace(txtSalaryLowerBand.Text) && _temp.HasValue)
            //    return _temp.Value.ToString();
            return string.Empty;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                //txtSalaryLowerBand.Text = value;
            }
        }
    }

    public string SalaryUpperBand
    {
        get
        {
            //decimal? _temp = CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text);
            //if (!String.IsNullOrWhiteSpace(txtSalaryLowerBand.Text) && _temp.HasValue)
            //    return _temp.Value.ToString();
            return string.Empty;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                //txtSalaryUpperBand.Text = value;
            }
        }
    }

    #endregion

    public MembersEdit()
    {
        _logger = LogManager.GetLogger(typeof(MembersEdit));
    }

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];

        if (!IsPostBack)
        {
            if ((Request.QueryString["MemberID"] != null))
            {
                loadForm();
                using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
                {
                    phLanguage.Visible = (sitelanguages.Count > 1);
                }
            }
            else
            {
                Response.Redirect("Members.aspx");
            }
        }
    }

    #endregion

    #region Methods

    protected void initForm()
    {
        LoadSiteLangauge();
        LoadSalary();
        populateAvailableStatus();
        populateCountries();
        populateProfessions();
        populateRoles(0);

        loadSites();
        loadYears();
        loadMonth();
        loadDate();

        //rvFirstApprovedDate.Type = ValidationDataType.Date;
        //rvFirstApprovedDate.MinimumValue = System.Data.SqlTypes.SqlDateTime.MinValue.Value.ToString("yyyy-MM-dd");
        //rvFirstApprovedDate.MaximumValue = new DateTime(DateTime.Now.Year + 100, 12, 31).ToString("yyyy-MM-dd");

        populateMemberFiles();
        populateJobAlerts();
    }

    protected void loadForm()
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }
        ((BoundField)grdJobAlert.Columns[3]).DataFormatString = "{0:" + SessionData.Site.DateFormat + "}";
        
        initForm();
        
        using (TList<JXTPortal.Entities.DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId))
        {
            foreach (JXTPortal.Entities.DynamicContent dynamiccontent in dynamiccontents)
            {
                if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions) && dynamiccontent.Active)
                {
                    phLastTCDate.Visible = true;
                }
            }
        }

        if (MemberID > 0)
        {
            JXTPortal.Entities.Members objMembers = MembersService.GetByMemberId(MemberID);
            {
                if (objMembers != null)
                {
                    if (objMembers.SiteId == SessionData.Site.SiteId || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator)
                    {

                        // SALESFORCE - Update the details from Sales force
                        if (GetFromSalesforceAndSave(objMembers.EmailAddress, objMembers.ExternalMemberId))
                        {
                            objMembers = MembersService.GetByMemberId(objMembers.MemberId);
                        }

                        if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
                        {
                            //txtPassword.Enabled = false;
                        }

                        if (objMembers.Status == (int)PortalEnums.Members.UserStatus.Closed)
                        {
                            MemberStatusClosedMessage.Visible = true;
                            btnSubmit.Visible = false;
                            btnLoginAsMember.Visible = false;
                        }
                        else
                        {
                            //Password locked panel
                            if (objMembers.Status == (int)PortalEnums.Members.UserStatus.Locked &&
                                objMembers.LastAttemptDate.HasValue &&
                                DateTime.Now <= objMembers.LastAttemptDate.Value.AddHours(1))
                            {
                                btnLoginAsMember.Visible = false;
                                PasswordLockedForm.Visible = true;
                                PasswordLockedTime.Text = objMembers.LastAttemptDate.HasValue ? objMembers.LastAttemptDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt") : string.Empty;
                            }

                            btnLoginAsMember.Visible = ((SessionData.AdminUser.isAdminUser || (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer)) && (objMembers.SiteId == SessionData.Site.SiteId));
                            btnLoginAsMember.Visible = objMembers.Validated;
                        }


                        //ddlSite.ClearSelection();
                        //ddlSite.SelectedValue = Convert.ToString(objMembers.SiteId);
                        txtUsername.ReadOnly = true;
                        txtUsername.Text = CommonService.DecodeString(objMembers.Username);

                        //setup the member validated display
                        lblMemberValidated.Text = objMembers.Validated ? "Yes" : "No";
                        cbMemberValidated.Checked = objMembers.Validated;

                        if ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId == PortalEnums.Admin.AdminRole.Administrator)
                            cbMemberValidated.Visible = true;
                        else
                            lblMemberValidated.Visible = true;

                        lblMemberAccountStatus.Text = objMembers.Status == null ? "Not Available" : ((PortalEnums.Members.UserStatus) objMembers.Status).ToString();

                        chkMemberValid.Checked = objMembers.Valid;
                        lblMemberLastModifiedDate.Text = objMembers.LastModifiedDate.HasValue ? string.Format("{0:" + SessionData.Site.DateFormat+ "}", objMembers.LastModifiedDate) : string.Empty;
                        lblMemberRegisteredDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objMembers.RegisteredDate);
                        ddlTitle.ClearSelection();
                        ddlTitle.SelectedValue = Convert.ToString(objMembers.Title);
                        txtFirstName.Text = CommonService.DecodeString(objMembers.FirstName);
                        txtSurname.Text = CommonService.DecodeString(objMembers.Surname);
                        if (!string.IsNullOrWhiteSpace(objMembers.MultiLingualFirstName))
                        {
                            txtMultilingualFirstName.Text = CommonService.DecodeString(objMembers.MultiLingualFirstName);
                        }
                        if (!string.IsNullOrWhiteSpace(objMembers.MultiLingualSurame))
                        {
                            txtMultilingualSurname.Text = CommonService.DecodeString(objMembers.MultiLingualSurame);
                        }

                        if (!string.IsNullOrEmpty(objMembers.ExternalMemberId))
                        {
                            ltExternalID.Text = objMembers.ExternalMemberId;
                            phExternalID.Visible = true;
                        }

                        txtEmailAddress.Text = objMembers.EmailAddress;
                        if (!string.IsNullOrWhiteSpace(objMembers.SecondaryEmail))
                        {
                            txtSecondaryEmailAddress.Text = objMembers.SecondaryEmail;
                        }
                        this.radlEmailFormat.Items.FindByValue(Convert.ToString(objMembers.EmailFormat)).Selected = true;

                        if (!string.IsNullOrEmpty(objMembers.Gender))
                        {
                            if ((this.radlGender.Items.FindByValue(objMembers.Gender) != null))
                            {
                                this.radlGender.Items.FindByValue(objMembers.Gender).Selected = true;
                            }
                        }

                        if (objMembers.DateOfBirth != null)
                        {
                            ddlYear.ClearSelection();
                            ddlMonth.ClearSelection();
                            ddlDay.ClearSelection();

                            ddlYear.SelectedValue = ((DateTime)objMembers.DateOfBirth).Year.ToString();
                            ddlMonth.SelectedValue = ((DateTime)objMembers.DateOfBirth).Month.ToString();
                            ddlDay.SelectedValue = ((DateTime)objMembers.DateOfBirth).Day.ToString();
                        }
                        loadDate();

                        txtMemberAddress1.Text = CommonService.DecodeString(objMembers.Address1);
                        txtMemberAddress2.Text = CommonService.DecodeString(objMembers.Address2);

                        if (!string.IsNullOrEmpty(objMembers.Suburb))
                            txtMemberSuburb.Text = CommonService.DecodeString(objMembers.Suburb);
                        if (!string.IsNullOrEmpty(objMembers.PostCode))
                            txtMemberPostcode.Text = CommonService.DecodeString(objMembers.PostCode);
                        if (!string.IsNullOrEmpty(objMembers.States))
                            txtMemberState.Text = CommonService.DecodeString(objMembers.States);
                        if (!string.IsNullOrWhiteSpace(objMembers.CountryName))
                        {
                            objMembers.CountryId = -1;
                            ddlCountry.Items.Add(new ListItem(objMembers.CountryName, "-1"));
                        }

                        ddlCountry.SelectedValue = objMembers.CountryId.ToString();

                        tbMailingAddress1.Text = CommonService.DecodeString(objMembers.MailingAddress1);
                        tbMailingAddress2.Text = CommonService.DecodeString(objMembers.MailingAddress2);

                        if (!string.IsNullOrEmpty(objMembers.MailingSuburb))
                            tbMailingSuburb.Text = CommonService.DecodeString(objMembers.MailingSuburb);
                        if (!string.IsNullOrEmpty(objMembers.MailingPostCode))
                            tbMailingPostcode.Text = CommonService.DecodeString(objMembers.MailingPostCode);
                        if (!string.IsNullOrEmpty(objMembers.MailingStates))
                            tbMailingState.Text = CommonService.DecodeString(objMembers.MailingStates);

                        if (!string.IsNullOrWhiteSpace(objMembers.MailingCountryName))
                        {
                            objMembers.MailingCountryId = -1;
                            ddlMailingCountry.Items.Add(new ListItem(objMembers.MailingCountryName, "-1"));
                        }

                        ddlMailingCountry.SelectedValue = objMembers.MailingCountryId.ToString();

                        txtHomePhone.Text = CommonService.DecodeString(objMembers.HomePhone);
                        //txtWorkPhone.Text = CommonService.DecodeString(objMembers.WorkPhone);
                        txtMobilePhone.Text = CommonService.DecodeString(objMembers.MobilePhone);

                        //if (objMembers.PreferredCategoryId.HasValue)
                        //{
                        //    CommonFunction.SetDropDownByValue(ddlprefClassification, objMembers.PreferredCategoryId.Value.ToString());
                        //    populateRoles(objMembers.PreferredCategoryId.Value);
                        //}

                        //if (objMembers.PreferredSubCategoryId.HasValue)
                        //{
                        //    CommonFunction.SetDropDownByValue(ddlprefSubClassification, objMembers.PreferredSubCategoryId.Value.ToString());
                        //}

                        //if (objMembers.CountryId > 0)
                        //{
                        //    CommonFunction.SetDropDownByValue(ddlCountry, objMembers.CountryId.ToString());
                        //    populateLocations(objMembers.CountryId);
                        //}

                        //if (objMembers.LocationId > 0)
                        //{
                        //    CommonFunction.SetDropDownByValue(ddlLocation, objMembers.LocationId.ToString());
                        //    populateAreas(objMembers.LocationId);
                        //}

                        //if (objMembers.AreaId > 0)
                        //{
                        //    CommonFunction.SetDropDownByValue(ddlArea, objMembers.AreaId.ToString());
                        //}

                        //ddlSalary.ClearSelection();
                        //ddlSalary.SelectedValue = Convert.ToString(objMembers.PreferredSalaryId);

                        if (objMembers.PreferredSalaryId > 0)
                        {
                            //LoadSalaryFrom(Convert.ToInt32(objMembers.PreferredSalaryId), objMembers.PreferredSalaryFrom);

                            //txtSalaryLowerBand.Text = Convert.ToString(objMembers.PreferredSalaryFrom);

                            //LoadSalaryTo(Convert.ToInt32(objMembers.PreferredSalaryId), 1, Convert.ToDecimal(objMembers.PreferredSalaryFrom), objMembers.PreferredSalaryTo);

                            //txtSalaryUpperBand.Text = Convert.ToString(objMembers.PreferredSalaryTo);
                        }

                        tbPassportNo.Text = CommonService.DecodeString(objMembers.PassportNo);
                        if (objMembers.DefaultLanguageId.HasValue)
                        {
                            ddlLanguage.SelectedValue = objMembers.DefaultLanguageId.Value.ToString();
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(objMembers.AvailabilityFromDate)))
                        {
                            //txtAvailabilityDate.Text = string.Format("{0:dd/MM/yyyy}", objMembers.AvailabilityFromDate);
                        }

                        if (objMembers.LastTermsAndConditionsDate.HasValue)
                        {
                            lbLastTermsAndConditionsDate.Text = objMembers.LastTermsAndConditionsDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        }
                    }
                    else
                    {
                        Response.Redirect("Members.aspx");
                    }

                    objMembers.Dispose();
                }
                else
                {
                    Response.Redirect("Members.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Members.aspx");
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members();

            try
            {
                //not used?
                //int? defaultcountryid = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].DefaultCountryId;

                if (MemberID > 0)
                {
                    objMembers = MembersService.GetByMemberId(MemberID);

                    //site check
                    if (objMembers == null || ( !SessionData.AdminUser.isAdminUser && objMembers.SiteId != SessionData.Site.SiteId) )
                        Response.Redirect("/admin/members.aspx");

                }
                else
                {
                    objMembers.Username = CommonService.EncodeString(txtUsername.Text);
                }

                //objMembers.MemberId = MemberID;

                if (txtPassword.Text != null && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    objMembers.Password = CommonService.EncryptMD5(txtPassword.Text);
                }

                objMembers.Valid = chkMemberValid.Checked;

                if ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId == PortalEnums.Admin.AdminRole.Administrator)
                    objMembers.Validated = cbMemberValidated.Checked;
                
                objMembers.LastModifiedDate = DateTime.Now;
                objMembers.Title = ddlTitle.SelectedValue;
                objMembers.FirstName = CommonService.EncodeString(txtFirstName.Text);
                objMembers.Surname = CommonService.EncodeString(txtSurname.Text);
                objMembers.MultiLingualFirstName = CommonService.EncodeString(txtMultilingualFirstName.Text);
                objMembers.MultiLingualSurame = CommonService.EncodeString(txtMultilingualSurname.Text);
                //objMembers.CountryId = (Convert.ToInt32(ddlCountry.SelectedValue) == 0) ? ((defaultcountryid.HasValue) ? defaultcountryid.Value : 1) : Convert.ToInt32(ddlCountry.SelectedValue);
                objMembers.EmailAddress = txtEmailAddress.Text;
                objMembers.SecondaryEmail = txtSecondaryEmailAddress.Text;
                objMembers.EmailFormat = Convert.ToInt32(radlEmailFormat.SelectedValue);
                objMembers.Gender = radlGender.SelectedValue;

                if (this.ddlYear.SelectedValue.Length > 0 && this.ddlMonth.SelectedIndex > 0 && this.ddlDay.SelectedValue.Length > 0)
                {
                    objMembers.DateOfBirth = new DateTime(Convert.ToInt32(this.ddlYear.SelectedValue), Convert.ToInt32(this.ddlMonth.SelectedIndex),
                        Convert.ToInt32(this.ddlDay.SelectedValue));
                }
                else
                {
                    objMembers.DateOfBirth = (DateTime?)null;
                }

                objMembers.Address1 = CommonService.EncodeString(txtMemberAddress1.Text);
                objMembers.Address2 = CommonService.EncodeString(txtMemberAddress2.Text);
                objMembers.Suburb = CommonService.EncodeString(txtMemberSuburb.Text);
                objMembers.PostCode = CommonService.EncodeString(txtMemberPostcode.Text);
                objMembers.States = CommonService.EncodeString(txtMemberState.Text);

                if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
                {
                    objMembers.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    objMembers.CountryName = string.Empty;
                }

                objMembers.MailingAddress1 = CommonService.EncodeString(tbMailingAddress1.Text);
                objMembers.MailingAddress2 = CommonService.EncodeString(tbMailingAddress2.Text);
                objMembers.MailingSuburb = CommonService.EncodeString(tbMailingSuburb.Text);
                objMembers.MailingPostCode = CommonService.EncodeString(tbMailingPostcode.Text);
                objMembers.MailingStates = CommonService.EncodeString(tbMailingState.Text);
                if (Convert.ToInt32(ddlMailingCountry.SelectedValue) > 0)
                {
                    objMembers.MailingCountryId = Convert.ToInt32(ddlMailingCountry.SelectedValue);
                    objMembers.MailingCountryName = string.Empty;
                }

                objMembers.HomePhone = CommonService.EncodeString(txtHomePhone.Text);
                //objMembers.WorkPhone = CommonService.EncodeString(txtWorkPhone.Text);
                objMembers.MobilePhone = CommonService.EncodeString(txtMobilePhone.Text);
                

                //objMembers.PreferredCategoryId = (ddlprefClassification.SelectedValue != "0") ? Convert.ToInt32(ddlprefClassification.SelectedValue) : (int?)null;
                //objMembers.PreferredSubCategoryId = (ddlprefSubClassification.SelectedValue != "0") ? Convert.ToInt32(ddlprefSubClassification.SelectedValue) : (int?)null;
                //objMembers.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);
                //objMembers.AreaId = Convert.ToInt32(ddlArea.SelectedValue);


                //string[] salaryFrom = ddlSalaryFrom.SelectedValue.Split(';');
                //string[] salaryTo = ddlSalaryTo.SelectedValue.Split(';'); ;


                //objMembers.PreferredSalaryId = Convert.ToInt32(ddlSalary.SelectedValue);
                objMembers.PreferredSalaryFrom = SalaryLowerBand;
                objMembers.PreferredSalaryTo = SalaryUpperBand;

                /*
                if (ddlSalaryFrom.SelectedValue.Length > 0)
                {
                    objMembers.PreferredSalaryFrom = salaryFrom[1];
                }
                else
                {
                    objMembers.PreferredSalaryFrom = string.Empty;
                }

                if (ddlSalaryTo.SelectedValue.Length > 0)
                {
                    objMembers.PreferredSalaryTo = salaryTo[1];
                }
                else
                {
                    objMembers.PreferredSalaryTo = string.Empty;
                }
                */
                
                objMembers.PassportNo = CommonService.EncodeString(tbPassportNo.Text);

                //if (!string.IsNullOrEmpty(txtAvailabilityDate.Text))
                //{
                //    objMembers.AvailabilityFromDate = Convert.ToDateTime(txtAvailabilityDate.Text);
                //}
                objMembers.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                
                objMembers.SearchField = String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                               objMembers.FirstName,
                                               objMembers.Surname,
                                               Utils.CleanStringSpaces(objMembers.Address1),
                    //ddlCountry.SelectedItem.Text,
                    //ddlLocation.SelectedItem.Text,
                    //ddlArea.SelectedItem.Text,
                                               radlGender.SelectedItem.Text,
                    //(ddlprefClassification.SelectedValue == "0") ? "" : ddlprefClassification.SelectedItem.Text,
                    //(ddlprefSubClassification.SelectedValue == "0") ? "" : ddlprefSubClassification.SelectedItem.Text,

                                               objMembers.PreferredSalaryFrom,
                                               objMembers.PreferredSalaryTo,

                                               Utils.CleanStringSpaces(objMembers.Tags));

                if (MemberID > 0)
                {
                    //Update Member
                    MembersService.Update(objMembers);
                }
                else
                {
                    //Insert New Member
                    objMembers.ReferringSiteId = SessionData.Site.SiteId;
                    MembersService.Insert(objMembers);
                    objMembers.MemberUrlExtension = objMembers.MemberId.ToString();
                    MembersService.Update(objMembers);
                }

                // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce.
                SalesforceMemberSync memberSync = new SalesforceMemberSync(objMembers);

                Response.Redirect("Members.aspx");
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.ToString();
            }
            finally
            {
                objMembers.Dispose();
            }


        }
    }

    protected void btnLoginAsMember_Click(object sender, EventArgs e)
    {
        if (MemberID > 0)
        {
            JXTPortal.Entities.Members member = MembersService.GetByMemberId(MemberID);

            //user role test
            bool roleValid = SessionData.AdminUser != null && ( SessionData.AdminUser.isAdminUser || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor);

            //site check
            bool siteValid = member.SiteId == SessionData.Site.SiteId;

            if (member == null || !roleValid || !siteValid)
                Response.Redirect("/admin/members.aspx");

            if (member.Validated)
            {
                // SALESFORCE - Update the details from Sales force
                if (GetFromSalesforceAndSave(member.EmailAddress, member.ExternalMemberId))
                {
                    member = MembersService.GetByMemberId(member.MemberId);
                }

                // Bullhorn Candidate Sync
                string errorMsg = string.Empty;
                BullhornRESTAPI bullhornRestAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                bullhornRestAPI.SyncCandidate(member, out errorMsg);

                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    _logger.Error("MembersEdit.aspx -> btnLoginAsMember_Click" + errorMsg);  
                }

                SessionService.RemoveAdvertiserUser();
                SessionService.SetMember(member);

                member.Dispose();

                Response.Redirect("~/member/default.aspx");
            }
            else
            {
                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MemberLoginError", "alert('This member has to be validated first.')", true);
            }

        }
    }

    protected void btnPasswordUnlock_Click(object sender, EventArgs e)
    {
        if (MemberID > 0)
        {
            JXTPortal.Entities.Members member = MembersService.GetByMemberId(MemberID);

            //user role test
            bool roleValid = SessionData.AdminUser != null && (SessionData.AdminUser.isAdminUser || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor);

            //site check
            bool siteValid = member.SiteId == SessionData.Site.SiteId;

            if (member == null || !roleValid || !siteValid)
                Response.Redirect("/admin/members.aspx");

            if (member.Status == (int) PortalEnums.Members.UserStatus.Locked)
            {
                member.Status = (int)PortalEnums.Members.UserStatus.Valid;
                member.LastAttemptDate = null;
                member.LoginAttempts = 0;

                MembersService.Update(member);
            }

            Response.Redirect(Request.RawUrl);
        }
    }

    #endregion

    #region Methods

    private void LoadSiteLangauge()
    {
        using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
        {
            phLanguage.Visible = (sitelanguages.Count > 1);
            ddlLanguage.Items.Clear();
            foreach (SiteLanguages sitelang in sitelanguages)
            {
                ddlLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));
            }
        }
    }

    private void loadSites()
    {
        //only load the current site into the site DDL
        List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites> { SitesService.GetBySiteId(SessionData.Site.SiteId) };

        ddlSite.ClearSelection();
        ddlSite.SelectedValue = Convert.ToString(SessionData.Site.SiteId);

        ddlSite.DataSource = sites;
        ddlSite.DataTextField = "SiteName";
        ddlSite.DataValueField = "SiteID";
        ddlSite.DataBind();

    }

    protected void populateMemberFiles()
    {
        using (TList<JXTPortal.Entities.MemberFiles> objmembers = MembersFilesService.GetByMemberId(MemberID))
        {
            grdDoc.DataSource = objmembers;
            grdDoc.DataBind();
        }
    }

    protected void populateJobAlerts()
    {
        using (TList<JXTPortal.Entities.JobAlerts> objjobalerts = JobAlertsService.GetByMemberId(MemberID))
        {
            grdJobAlert.DataSource = objjobalerts;
            grdJobAlert.DataBind();
        }
    }

    protected void loadYears()
    {
        int i = 0;
        ListItem lstitem = new ListItem("Year", "");

        this.ddlYear.Items.Add(lstitem);

        for (i = 1940; i <= DateTime.Today.Year; i++)
        {
            lstitem = new ListItem(i.ToString(), i.ToString());
            this.ddlYear.Items.Add(lstitem);
        }

    }

    protected void loadMonth()
    {
        int i = 0;
        ListItem lstitem = new ListItem("Month", "");

        this.ddlMonth.Items.Add(lstitem);

        DateTime now = new DateTime(1);
        for (i = 0; i < 12; i++)
        {
            lstitem = new ListItem(now.ToString("MMMM"), (i + 1).ToString());
            now = now.AddMonths(1);
            this.ddlMonth.Items.Add(lstitem);

        }

    }

    protected void loadDate()
    {
        int i = 0;
        ListItem lstitem = new ListItem("Date", "");
        ListItem selectedDay = ddlDay.SelectedItem;

        this.ddlDay.Items.Clear();

        if (!string.IsNullOrEmpty(ddlYear.SelectedValue) && !string.IsNullOrEmpty(ddlMonth.SelectedValue))
        {
            DateTime now = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedIndex), 1);

            now = now.AddMonths(1).AddDays(-1);
            for (i = 1; i <= now.Day; i++)
            {
                lstitem = new ListItem(i.ToString(), i.ToString());
                this.ddlDay.Items.Add(lstitem);
            }
        }
        else
        {
            for (i = 1; i <= 31; i++)
            {
                lstitem = new ListItem(i.ToString(), i.ToString());
                this.ddlDay.Items.Add(lstitem);
            }
        }

        ddlDay.Items.Insert(0, new ListItem("Day", "0"));
        ddlDay.ClearSelection();
        if (ddlDay.Items.Contains(selectedDay))
        {
            ddlDay.SelectedValue = selectedDay.Value;
        }
        else
        {
            ddlDay.SelectedValue = "0";
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDate();
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDate();
    }


    private void LoadSalary()
    {
        //ddlSalary.DataSource = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
        //ddlSalary.DataBind();
        //ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
    }

    /*
    private void LoadSalaryFrom(int salarytypeid, string salaryFromValue)
    {
        ddlSalaryFrom.Items.Clear();

        if (salarytypeid > 0)
        {
            VList<ViewSalary> salaryFromList = ViewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salarytypeid);
            foreach (ViewSalary vs in salaryFromList)
            {
                ListItem li = new ListItem();
                li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
                li.Text = vs.SalaryDisplay;

                if (!string.IsNullOrEmpty(salaryFromValue))
                {
                    if (vs.Amount == Convert.ToDecimal(salaryFromValue))
                    {
                        li.Selected = true;
                    }
                }

                ddlSalaryFrom.Items.Add(li);
            }
        }

    }

    private void LoadSalaryTo(int salarytypeid, int currencyid, decimal amount, string salaryToValue)
    {
        ddlSalaryTo.Items.Clear();

        VList<ViewSalary> salaryToList = ViewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currencyid, salarytypeid, amount);
        foreach (ViewSalary vs in salaryToList)
        {
            ListItem li = new ListItem();
            li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
            li.Text = vs.SalaryDisplay;

            if (!string.IsNullOrEmpty(salaryToValue))
            {
                if (vs.Amount == Convert.ToDecimal(salaryToValue))
                {
                    li.Selected = true;
                }
            }

            ddlSalaryTo.Items.Add(li);
        }
    }


    protected void ddlSalary_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSalaryLowerBand.Focus();

        //LoadSalaryFrom(Convert.ToInt32(ddlSalary.SelectedValue), string.Empty);
        //LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), 0, 0, string.Empty);
    }

    protected void ddlSalaryFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = ddlSalaryFrom.SelectedValue;
        string[] parts = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToInt32(parts[0]), Convert.ToDecimal(parts[1]), string.Empty);
    }*/

    protected void populateAvailableStatus()
    {
        //siteAvailableStatus = AvailableStatusService.GetBySiteId(SessionData.Site.SiteId);

        //ddlAvailability.DataSource = siteAvailableStatus;
        //ddlAvailability.DataTextField = "AvailableStatusName";
        //ddlAvailability.DataValueField = "AvailableStatusID";
        //ddlAvailability.DataBind();

        //ddlAvailability.Items.Insert(0, new ListItem("-Select Available Status-", "0"));
    }

    private void populateProfessions()
    {
        //ddlprefClassification.DataSource = SiteProfessionService.GetTranslatedProfessions(true, SessionData.Site.UseCustomProfessionRole);
        //ddlprefClassification.DataTextField = "SiteProfessionName";
        //ddlprefClassification.DataValueField = "ProfessionId";
        //ddlprefClassification.DataBind();
        //ddlprefClassification.Items.Insert(0, new ListItem("-All Classifications-", "0"));
    }

    private void populateRoles(int ProfessionId)
    {
        //if (ProfessionId > 0)
        //{
        //    ddlprefSubClassification.DataSource = SiteRolesService.GetTranslatedByProfessionID(ProfessionId, SessionData.Site.UseCustomProfessionRole);
        //    ddlprefSubClassification.DataTextField = "SiteRoleName";
        //    ddlprefSubClassification.DataValueField = "RoleId";
        //    ddlprefSubClassification.DataBind();
        //    ddlprefSubClassification.Items.Insert(0, new ListItem("-All SubClassifications-", "0"));
        //}
        //else
        //{
        //    ddlprefSubClassification.Items.Clear();
        //    ddlprefSubClassification.Items.Insert(0, new ListItem("-Select a Classification First-", "0"));
        //}
    }

    protected void populateCountries()
    {
        System.Collections.Generic.List<JXTPortal.Entities.Countries> countrylist = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

        ddlCountry.DataSource = countrylist;
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryID";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("-All Countries-", "0"));

        ddlMailingCountry.DataSource = countrylist;
        ddlMailingCountry.DataTextField = "CountryName";
        ddlMailingCountry.DataValueField = "CountryID";
        ddlMailingCountry.DataBind();
        ddlMailingCountry.Items.Insert(0, new ListItem("-All Countries-", "0"));
    }

    private void populateLocations(int CountryID)
    {
        //if (CountryID > 0)
        //{
        //    ddlLocation.DataSource = GlobalLocationService.GetTranslatedLocations(CountryID);
        //    ddlLocation.DataTextField = "LocationName";
        //    ddlLocation.DataValueField = "LocationID";
        //    ddlLocation.DataBind();
        //    ddlLocation.Items.Insert(0, new ListItem("-All Locations-", "0"));


        //    using (JXTPortal.Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, CountryID))
        //    {

        //        if (siteCountry != null)
        //        {
        //            ltlLowerCurrency.Text = siteCountry.Currency;
        //            ltlUpperCurrency.Text = siteCountry.Currency;
        //        }
        //    }
        //}
        //else
        //{
        //    ddlLocation.Items.Clear();
        //    ddlLocation.Items.Insert(0, new ListItem("-Select a Country First-", "0"));
        //}
        //populateAreas(Convert.ToInt32(ddlLocation.SelectedValue));

    }

    private void populateAreas(int LocationID)
    {
        //if (LocationID > 0)
        //{
        //    ddlArea.DataSource = GlobalAreaService.GetTranslatedAreas(LocationID);
        //    ddlArea.DataTextField = "AreaName";
        //    ddlArea.DataValueField = "AreaID";
        //    ddlArea.DataBind();
        //    ddlArea.Items.Insert(0, new ListItem("-All Areas-", "0"));


        //}
        //else
        //{
        //    ddlArea.Items.Clear();
        //    ddlArea.Items.Insert(0, new ListItem("-Select a Location First-", "0"));
        //}
    }

    protected void ddlprefClassification_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(ddlprefClassification.SelectedValue))
        //{
        //    populateRoles(Convert.ToInt32(ddlprefClassification.SelectedValue));
        //}
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
        //{
        //    populateLocations(Convert.ToInt32(ddlCountry.SelectedValue));
        //    populateAreas(Convert.ToInt32(ddlLocation.SelectedValue));
        //}
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(ddlLocation.SelectedValue))
        //{
        //    populateAreas(Convert.ToInt32(ddlLocation.SelectedValue));
        //}
    }

    #endregion

    #region Return Properties

    public int? _Profession
    {
        get
        {
            //    if (ddlprefClassification.SelectedItem != null && ddlprefClassification.SelectedValue.Length > 0 && Convert.ToInt32(ddlprefClassification.SelectedValue) > 0)
            //        return Convert.ToInt32(ddlprefClassification.SelectedValue);
            return null;
        }
        set
        {
            if (value.HasValue)
            {
                //CommonFunction.SetDropDownByValue(ddlprefClassification, value.Value.ToString());
                //populateRoles(value.Value);
            }
        }
    }

    public int? _Country
    {
        get
        {
            //if (ddlCountry.SelectedItem != null && ddlCountry.SelectedValue.Length > 0 && Convert.ToInt32(ddlCountry.SelectedValue) > 0)
            //    return Convert.ToInt32(ddlCountry.SelectedValue);
            return null;
        }
        set
        {
            if (value.HasValue)
            {
                //CommonFunction.SetDropDownByValue(ddlCountry, value.Value.ToString());
                //populateLocations(value.Value);
            }
        }
    }

    public int? _Location
    {
        get
        {
            //if (ddlLocation.SelectedItem != null && ddlLocation.SelectedValue.Length > 0 && Convert.ToInt32(ddlLocation.SelectedValue) > 0)
            //    return Convert.ToInt32(ddlLocation.SelectedValue);
            return null;
        }
        set
        {
            if (value.HasValue)
            {
                //CommonFunction.SetDropDownByValue(ddlLocation, value.Value.ToString());
                //populateAreas(value.Value);
            }
        }
    }


    #endregion

    #region Server Validate

    protected void ctmEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
    {
        JXTPortal.Entities.Members member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.SiteId, txtEmailAddress.Text);

        if (member != null)
        {
            if (member.MemberId != MemberID)
            {
                args.IsValid = false;
                ctmEmailAddress.ErrorMessage = "Email address already exists!";
            }
        }
    }


    protected void CusValDOB_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (this.ddlYear.SelectedValue.Length > 0 || this.ddlMonth.SelectedIndex > 0 || this.ddlDay.SelectedIndex > 0)
        {
            DateTime dt;
            args.IsValid = DateTime.TryParse(string.Format("{0}/{1}/{2}", ddlDay.SelectedValue, ddlMonth.SelectedIndex, ddlYear.SelectedValue), out dt);
        }
    }

    #endregion

    #region Grid Method
    protected void grdDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("MemberFileId={0}", grdDoc.SelectedDataKey.Values[0]);
        Response.Redirect("MemberFilesEdit.aspx?" + urlParams, true);
    }

    protected void grdJobAlert_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int jobalertids = 0;

        jobalertids = Convert.ToInt32(grdJobAlert.Rows[e.RowIndex].Cells[1].Text.ToString());


        try
        {
            JXTPortal.Entities.JobAlerts jobalerts = JobAlertsService.GetByJobAlertId(jobalertids);
            if (jobalerts != null)
            {
                jobalerts.AlertActive = false;
                JobAlertsService.Update(jobalerts);
            }

            Response.Redirect("~/Admin/MembersEdit.aspx?memberID=" + MemberID);
        }
        catch (Exception ex)
        {
            ltlMessage.Text = ex.Message;
        }


    }

    //protected void btnRemove_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    //{
    //    int jobalertids = 0;
    //    jobalertids = Convert.ToInt32(e.CommandArgument);

    //    try
    //    {
    //        JobAlertsService.Delete(jobalertids);
    //        Response.Redirect("~/Admin/MembersEdit.aspx?memberID=" + MemberID);
    //    }
    //    catch (Exception ex)
    //    {
    //        ltlMessage.Text = ex.Message;
    //    }

    //}

    #endregion



    #region SALESFORCE

    /// <summary>
    /// SALESFORCE - If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce AND send reset password email to member.
    /// </summary>
    /// <param name="strEmail"></param>
    private bool GetFromSalesforceAndSave(string strEmail, string SalesForceContactID)
    {
        SalesforceMemberSync memberSync = new SalesforceMemberSync();
        int memberid = 0; string errormsg = string.Empty;

        // Get Candidate from Salesforce by email
        // And If candidate exists in Sales force, save in Boardy platform.
        if (memberSync.GetContactFromSalesForceAndSave(strEmail, SalesForceContactID, SessionData.Site.MasterSiteId, ref memberid, ref errormsg) && memberid > 0)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// SALESFORCE - Check if the contact exists in Sales force and create/update the contact in Salesforce.
    /// </summary>
    /// <param name="strEmail"></param>
    private bool CheckContactAndSaveInSalesForce(JXTPortal.Entities.Members member)
    {
        SalesforceMemberSync memberSync = new SalesforceMemberSync();

        if (memberSync.CheckContactAndSaveInSalesForce(member, SessionData.Site.SiteId))
            return true;

        return false;
    }

    #endregion
}


