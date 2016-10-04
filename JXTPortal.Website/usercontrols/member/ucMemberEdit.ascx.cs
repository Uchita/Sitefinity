using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal;
using JXTPortal.Client.Salesforce;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberEdit : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;

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

        private SiteProfessionService _siteProfessionService;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null)
                    _siteProfessionService = new SiteProfessionService();
                return _siteProfessionService;
            }
        }

        private SiteRolesService _siteRolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                    _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }

        private SiteCountriesService _siteCountriesService;
        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null)
                    _siteCountriesService = new SiteCountriesService();
                return _siteCountriesService;
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

        private SiteLocationService _siteLocationService;
        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                    _siteLocationService = new SiteLocationService();
                return _siteLocationService;
            }
        }

        private SiteAreaService _siteAreaService;
        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteAreaService == null)
                    _siteAreaService = new SiteAreaService();
                return _siteAreaService;
            }
        }

        private SiteLanguagesService _sitelanguagesservice = null;
        public SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }


        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }

            SetFormValues();

        }

        #endregion

        #region Methods

        protected void initForm()
        {
            populateEducations();
            loadYears();
            loadMonth();
            loadDate();
            loadCountry();
            LoadSiteLangauge();
        }

        protected void loadForm()
        {
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            memberID = Entities.SessionData.Member.MemberId;

            initForm();

            using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
            {
                ddlTitle.ClearSelection();
                ddlTitle.SelectedValue = Convert.ToString(objMembers.Title);
                txtFirstName.Text = CommonService.DecodeString(objMembers.FirstName.Trim());
                txtSurname.Text = CommonService.DecodeString(objMembers.Surname.Trim());
                if (!string.IsNullOrWhiteSpace(objMembers.MultiLingualFirstName))
                {
                    txtMultilingualFirstName.Text = CommonService.DecodeString(objMembers.MultiLingualFirstName.Trim());
                }

                if (!string.IsNullOrWhiteSpace(objMembers.MultiLingualSurame))
                {
                    txtMultilingualSurname.Text = CommonService.DecodeString(objMembers.MultiLingualSurame.Trim());
                }
                txtUsername.Text = CommonService.DecodeString(objMembers.Username.Trim());
                txtEmailAddress.Text = CommonService.DecodeString(objMembers.EmailAddress.Trim());

                if (!string.IsNullOrWhiteSpace(objMembers.SecondaryEmail))
                {
                    txtSecondaryEmailAddress.Text = CommonService.DecodeString(objMembers.SecondaryEmail.Trim());
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
                    DateTime dob = (DateTime)objMembers.DateOfBirth;
                    ddlYear.ClearSelection();
                    ddlYear.SelectedValue = dob.Year.ToString();
                    ddlMonth.ClearSelection();
                    ddlMonth.SelectedValue = dob.Month.ToString();
                    ddlDay.ClearSelection();
                    ddlDay.SelectedValue = dob.Day.ToString();
                    loadDate();
                }

                txtMemberAddress.Text = (string.IsNullOrEmpty(objMembers.Address1)) ? string.Empty : CommonService.DecodeString(objMembers.Address1.Trim());
                txtSuburb.Text = (string.IsNullOrEmpty(objMembers.Suburb)) ? string.Empty : CommonService.DecodeString(objMembers.Suburb.Trim());
                txtPostcode.Text = (string.IsNullOrEmpty(objMembers.PostCode)) ? string.Empty : CommonService.DecodeString(objMembers.PostCode.Trim());
                txtState.Text = (string.IsNullOrEmpty(objMembers.States)) ? string.Empty : CommonService.DecodeString(objMembers.States.Trim());

                if (!string.IsNullOrWhiteSpace(objMembers.CountryName))
                {
                    objMembers.CountryId = -1;
                    ddlCountry.Items.Add(new ListItem(objMembers.CountryName, "-1"));
                }

                ddlCountry.SelectedValue = objMembers.CountryId.ToString();

                tbMailingAddress.Text = (string.IsNullOrEmpty(objMembers.MailingAddress1)) ? string.Empty : CommonService.DecodeString(objMembers.MailingAddress1.Trim());
                tbMailingSuburb.Text = (string.IsNullOrEmpty(objMembers.MailingSuburb)) ? string.Empty : CommonService.DecodeString(objMembers.MailingSuburb.Trim());
                tbMailingPostcode.Text = (string.IsNullOrEmpty(objMembers.MailingPostCode)) ? string.Empty : CommonService.DecodeString(objMembers.MailingPostCode.Trim());
                tbMailingState.Text = (string.IsNullOrEmpty(objMembers.MailingStates)) ? string.Empty : CommonService.DecodeString(objMembers.MailingStates.Trim());
                
                if (!string.IsNullOrWhiteSpace(objMembers.MailingCountryName))
                {
                    objMembers.MailingCountryId = -1;
                    ddlMailingCountry.Items.Add(new ListItem(objMembers.MailingCountryName, "-1"));
                }

                ddlMailingCountry.SelectedValue = objMembers.MailingCountryId.ToString();
                if (objMembers.DefaultLanguageId.HasValue)
                {
                    ddlLanguage.SelectedValue = objMembers.DefaultLanguageId.Value.ToString();
                }

                if (string.IsNullOrEmpty(tbMailingAddress.Text) == false || string.IsNullOrEmpty(tbMailingSuburb.Text) == false || string.IsNullOrEmpty(tbMailingPostcode.Text) == false
                        || string.IsNullOrEmpty(tbMailingState.Text) == false || ddlMailingCountry.SelectedValue != "0")
                {
                    ckAddMailingAddress.Checked = true;
                    divMailingAddress.Style["display"] = "block";
                    divMailingSuburb.Style["display"] = "block";
                    divMailingPostcode.Style["display"] = "block";
                    divMailingState.Style["display"] = "block";
                    divMailingCountry.Style["display"] = "block";
                }
                else
                {
                    ckAddMailingAddress.Checked = false;
                    divMailingAddress.Style["display"] = "none";
                    divMailingSuburb.Style["display"] = "none";
                    divMailingPostcode.Style["display"] = "none";
                    divMailingState.Style["display"] = "none";
                    divMailingCountry.Style["display"] = "none";
                }

                txtHomePhone.Text = (string.IsNullOrEmpty(objMembers.HomePhone)) ? string.Empty : CommonService.DecodeString(objMembers.HomePhone.Trim());
                txtWorkPhone.Text = (string.IsNullOrEmpty(objMembers.WorkPhone)) ? string.Empty : CommonService.DecodeString(objMembers.WorkPhone.Trim());
                txtMobilePhone.Text = (string.IsNullOrEmpty(objMembers.MobilePhone)) ? string.Empty : CommonService.DecodeString(objMembers.MobilePhone.Trim());
                txtFax.Text = (string.IsNullOrEmpty(objMembers.Fax)) ? string.Empty : CommonService.DecodeString(objMembers.Fax.Trim());
                ddlEducation.ClearSelection();
                ddlEducation.SelectedValue = Convert.ToString(objMembers.EducationId);
                txtMemberTags.Text = (string.IsNullOrEmpty(objMembers.Tags)) ? string.Empty : CommonService.DecodeString(objMembers.Tags.Trim());
                tbPassportNo.Text = (string.IsNullOrEmpty(objMembers.PassportNo)) ? string.Empty : CommonService.DecodeString(objMembers.PassportNo.Trim());

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

        private void LoadSiteLangauge()
        {
            using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                phLanguage.Visible = (sitelanguages.Count > 1);
                //phMultiLingual.Visible = (sitelanguages.Count > 1);
                ddlLanguage.Items.Clear();
                foreach (SiteLanguages sitelang in sitelanguages)
                {
                    ddlLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));
                }
            }
        }

        private void loadCountry()
        {
            List<Countries> siteCountries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

            if (siteCountries != null)
            {
                siteCountries = siteCountries.Where(c => c.Sequence != -1).OrderBy(c => c.CountryName).ToList();

                ddlCountry.DataSource = siteCountries;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllCountries"), "0"));

                ddlMailingCountry.DataSource = siteCountries;
                ddlMailingCountry.DataTextField = "CountryName";
                ddlMailingCountry.DataValueField = "CountryID";
                ddlMailingCountry.DataBind();
                ddlMailingCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllCountries"), "0"));
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

        protected void populateEducations()
        {
            ddlEducation.DataSource = EducationsService.GetTranslatedSiteEducations();
            ddlEducation.DataTextField = "EducationName";
            ddlEducation.DataValueField = "EducationParentId";
            ddlEducation.DataBind();

            ddlEducation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectEducation"), "0"));
        }



        #endregion

        #region Return Properties

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //((JXTPortal.Website.members._default)Page).SelectedTabIndex = 1;

            memberID = Entities.SessionData.Member.MemberId;

            if (Page.IsValid)
            {
                string sfContactID;

                #region Update to Database
                using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
                {
                    sfContactID = objMembers.ExternalMemberId;

                    objMembers.Title = CommonService.EncodeString(ddlTitle.SelectedValue);
                    objMembers.FirstName = CommonService.EncodeString(txtFirstName.Text);
                    objMembers.Surname = CommonService.EncodeString(txtSurname.Text);
                    objMembers.MultiLingualFirstName = CommonService.EncodeString(txtMultilingualFirstName.Text);
                    objMembers.MultiLingualSurame = CommonService.EncodeString(txtMultilingualSurname.Text);
                    objMembers.EmailFormat = Convert.ToInt32(radlEmailFormat.SelectedValue);
                    objMembers.Gender = CommonService.EncodeString(radlGender.SelectedValue);
                    objMembers.LastModifiedDate = DateTime.Now.Date;
                    if (this.ddlYear.SelectedValue.Length > 0 && this.ddlMonth.SelectedIndex > 0 && this.ddlDay.SelectedValue.Length > 0)
                    {
                        objMembers.DateOfBirth = new DateTime(Convert.ToInt32(this.ddlYear.SelectedValue), Convert.ToInt32(this.ddlMonth.SelectedIndex),
                                Convert.ToInt32(this.ddlDay.SelectedValue));
                    }
                    else
                    {
                        objMembers.DateOfBirth = (DateTime?)null;
                    }

                    // objMembers.EmailAddress = txtEmailAddress.Text;
                    objMembers.SecondaryEmail = txtSecondaryEmailAddress.Text;
                    objMembers.Address1 = CommonService.EncodeString(txtMemberAddress.Text.Trim());
                    objMembers.Suburb = CommonService.EncodeString(txtSuburb.Text.Trim());
                    objMembers.PostCode = CommonService.EncodeString(txtPostcode.Text.Trim());
                    objMembers.States = CommonService.EncodeString(txtState.Text.Trim());
                    if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
                    {
                        objMembers.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                        objMembers.CountryName = string.Empty;
                    }

                    objMembers.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                    if (ckAddMailingAddress.Checked)
                    {
                        objMembers.MailingAddress1 = CommonService.EncodeString(tbMailingAddress.Text);
                        objMembers.MailingSuburb = CommonService.EncodeString(tbMailingSuburb.Text);
                        objMembers.MailingPostCode = CommonService.EncodeString(tbMailingPostcode.Text);
                        objMembers.MailingStates = CommonService.EncodeString(tbMailingState.Text);
                        if (Convert.ToInt32(ddlMailingCountry.SelectedValue) > 0)
                        {
                            objMembers.MailingCountryId = Convert.ToInt32(ddlMailingCountry.SelectedValue);
                            objMembers.MailingCountryName = string.Empty;
                        }

                        divMailingAddress.Style["display"] = "block";
                        divMailingSuburb.Style["display"] = "block";
                        divMailingPostcode.Style["display"] = "block";
                        divMailingState.Style["display"] = "block";
                        divMailingCountry.Style["display"] = "block";

                        if (tbMailingAddress.Text == string.Empty &&
                        tbMailingSuburb.Text == string.Empty &&
                        tbMailingPostcode.Text == string.Empty &&
                        tbMailingState.Text == string.Empty && ddlMailingCountry.SelectedValue == "0")
                        {
                            ckAddMailingAddress.Checked = false;
                        }
                    }

                    if (ckAddMailingAddress.Checked == false)
                    {
                        divMailingAddress.Style["display"] = "none";
                        divMailingSuburb.Style["display"] = "none";
                        divMailingPostcode.Style["display"] = "none";
                        divMailingState.Style["display"] = "none";
                        divMailingCountry.Style["display"] = "none";

                        objMembers.MailingAddress1 = string.Empty;
                        objMembers.MailingSuburb = string.Empty;
                        objMembers.MailingPostCode = string.Empty;
                        objMembers.MailingStates = string.Empty;

                        objMembers.MailingCountryId = (int?)null;
                    }

                    objMembers.HomePhone = CommonService.EncodeString(txtHomePhone.Text.Trim());
                    objMembers.WorkPhone = CommonService.EncodeString(txtWorkPhone.Text.Trim());
                    objMembers.MobilePhone = CommonService.EncodeString(txtMobilePhone.Text.Trim());
                    objMembers.Fax = CommonService.EncodeString(txtFax.Text.Trim());


                    if (ddlEducation.SelectedIndex != 0)
                    {
                        objMembers.EducationId = Convert.ToInt32(ddlEducation.SelectedValue);
                    }

                    objMembers.Tags = CommonService.EncodeString(txtMemberTags.Text);
                    objMembers.PassportNo = CommonService.EncodeString(tbPassportNo.Text);
                    //objMembers.Subscribed = chkNews.Checked;

                    string strCountry = string.Empty;
                    string strLocation = string.Empty;
                    string strArea = string.Empty;
                    string strDesiredPay = string.Empty;

                    if (objMembers.CountryId > 0)
                    {
                        using (TList<Entities.SiteCountries> sc = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            sc.Filter = "CountryID = " + objMembers.CountryId.ToString();
                            if (sc.Count > 0)
                                strCountry = sc[0].SiteCountryName;
                        }
                    }

                    //if (objMembers.LocationId > 0)
                    //{
                    //    TList<SiteLocation> sl = SiteLocationService.GetBySiteId(SessionData.Site.SiteId);
                    //    sl.Filter = "LocationID = " + objMembers.LocationId.ToString();
                    //    if (sl.Count > 0)
                    //        strLocation = sl[0].SiteLocationName;
                    //}

                    //if (objMembers.AreaId > 0)
                    //{
                    //    TList<SiteArea> sa = SiteAreaService.GetBySiteId(SessionData.Site.SiteId);
                    //    sa.Filter = "AreaID = " + objMembers.AreaId.ToString();
                    //    if (sa.Count > 0)
                    //        strArea = sa[0].SiteAreaName;
                    //}

                    if (objMembers.PreferredSalaryId.HasValue)
                    {

                    }

                    string strProfession = string.Empty;
                    string strRole = string.Empty;

                    //if (objMembers.PreferredCategoryId.HasValue)
                    //{
                    //    TList<JXTPortal.Entities.SiteProfession> sp = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId);
                    //    sp.Filter = "ProfessionID = " + objMembers.PreferredCategoryId.ToString();
                    //    if (sp.Count > 0)
                    //        strProfession = sp[0].SiteProfessionName;
                    //}

                    //if (objMembers.PreferredSubCategoryId.HasValue)
                    //{
                    //    TList<JXTPortal.Entities.SiteRoles> sr = SiteRolesService.GetBySiteId(SessionData.Site.SiteId);
                    //    sr.Filter = "RoleID = " + objMembers.PreferredSubCategoryId.ToString();
                    //    if (sr.Count > 0)
                    //        strRole = sr[0].SiteRoleName;
                    //}

                    objMembers.SearchField = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",
                                                objMembers.FirstName,
                                                objMembers.Surname,
                                                Utils.CleanStringSpaces(objMembers.Address1),
                                                strCountry,
                                                strLocation,
                                                strArea,
                                                radlGender.SelectedItem.Text,
                                                strProfession,
                                                strRole,
                                                (ddlEducation.SelectedValue == "0") ? "" : ddlEducation.SelectedItem.Text,
                                                strDesiredPay,
                                                Utils.CleanStringSpaces(objMembers.Tags));
                    //Update members
                    MembersService.Update(objMembers);

                    // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce.
                    SalesforceMemberSync memberSync = new SalesforceMemberSync(SessionData.Site.SiteId);
                    memberSync.CheckContactAndSaveInSalesForce(objMembers, objMembers.SiteId);

                    ltlMessage.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelMemberEditSuccess"), BootstrapAlertType.Success);
                }
                #endregion


            }
        }

        protected void btnCloseAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/member/confirmdelete.aspx");
        }

        #endregion

        public void SetFormValues()
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
            rfvFirstname.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            rfvSurname.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            CusValDOB.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidDate");
            this.ddlTitle.Items[0].Text = CommonFunction.GetResourceValue("LabelMr");
            this.ddlTitle.Items[1].Text = CommonFunction.GetResourceValue("LabelMrs");
            this.ddlTitle.Items[2].Text = CommonFunction.GetResourceValue("LabelMs");
            this.ddlTitle.Items[3].Text = CommonFunction.GetResourceValue("LabelMiss");
            this.ddlTitle.Items[4].Text = CommonFunction.GetResourceValue("LabelDr");
            this.ddlTitle.Items[5].Text = CommonFunction.GetResourceValue("LabelProfessor");
            this.ddlTitle.Items[6].Text = CommonFunction.GetResourceValue("LabelOther");
            this.radlEmailFormat.Items[0].Text = CommonFunction.GetResourceValue("LabelHTML");
            this.radlEmailFormat.Items[1].Text = CommonFunction.GetResourceValue("LabelText");
            this.radlGender.Items[0].Text = CommonFunction.GetResourceValue("LabelMale");
            this.radlGender.Items[1].Text = CommonFunction.GetResourceValue("LabelFemale");
            this.ddlDay.Items[0].Text = CommonFunction.GetResourceValue("LabelDay");
            this.ddlMonth.Items[0].Text = CommonFunction.GetResourceValue("LabelMonth");
            this.ddlYear.Items[0].Text = CommonFunction.GetResourceValue("LabelYear");

        }

        protected void CusValDOB_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlYear.SelectedValue.Length > 0 || this.ddlMonth.SelectedIndex > 0 || this.ddlDay.SelectedIndex > 0)
            {
                DateTime dt;
                args.IsValid = DateTime.TryParse(string.Format("{0}/{1}/{2}", ddlDay.SelectedValue, ddlMonth.SelectedIndex, ddlYear.SelectedValue), out dt);
            }
        }
    }
}