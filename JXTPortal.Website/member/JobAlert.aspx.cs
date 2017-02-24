using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Client.Salesforce;

namespace JXTPortal.Website.members
{
    public partial class JobAlert : System.Web.UI.Page
    {
        #region Declare variables
        private JobAlertsService _jobAlertsService;
        private MembersService _membersService = null;
        private SiteCountriesService _siteCountriesService = null;
        private SiteLocationService _siteLocationService = null;
        private SiteAreaService _siteAreaService = null;
        private SiteProfessionService _siteProfessionService = null;
        private SiteRolesService _siteRolesService = null;
        private SiteWorkTypeService _siteWorkTypeService = null;
        private GlobalSettingsService _globalSettingsService = null;

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

        #endregion

        #region Properties

        private bool IsFav
        {
            get
            {
                return (Request.QueryString["isfav"] == "1");
            }
        }

        private bool RetainSearch
        {
            get
            {
                return (Request.QueryString["retainsearch"] == "1");

            }
        }
        public int JobAlertID
        {
            get
            {
                int _id = -1;

                if (Request.QueryString["id"] != null &&
                    !string.IsNullOrEmpty(Request.QueryString["id"]) &&
                    Int32.TryParse(Request.QueryString["id"], out _id))
                {
                    _id = Convert.ToInt32(Request.QueryString["id"]);
                }

                return _id;

            }
        }

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

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                {
                    _siteLocationService = new SiteLocationService();
                }
                return _siteLocationService;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteAreaService == null)
                {
                    _siteAreaService = new SiteAreaService();
                }
                return _siteAreaService;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null)
                {
                    _siteProfessionService = new SiteProfessionService();
                }
                return _siteProfessionService;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                {
                    _siteRolesService = new SiteRolesService();
                }
                return _siteRolesService;
            }
        }

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteWorkTypeService == null)
                {
                    _siteWorkTypeService = new SiteWorkTypeService();
                }
                return _siteWorkTypeService;
            }
        }

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
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            //CommonPage.SetBrowserPageTitle(Page, "Create Job Alert");
            phProfileSection.Visible = (SessionData.Member == null);
            if (SessionData.Member != null)
            {
                phProfileSection.Visible = false;
                using (Entities.JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
                {
                    if (jobAlert != null && jobAlert.JobAlertId > 0 && jobAlert.MemberId == SessionData.Member.MemberId)
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditJobAlert"));
                            CommonPage.SetBrowserPageTitle(Page, "Edit Job Alert");
                        }
                        else
                        {
                            ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditFavouriteSearch"));
                            CommonPage.SetBrowserPageTitle(Page, "Edit Favourite Search");

                        }
                    }
                }
            }
            if (IsFav)
            {
                ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelCreateFavouriteSearch"));
                CommonPage.SetBrowserPageTitle(Page, "Create Favourite Search");
            }
            else
            {
                ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelCreateJobAlert"));
                CommonPage.SetBrowserPageTitle(Page, "Create Job Alert");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDefaultCountry();
                LoadCountries();
                LoadLocationArea();
                LoadClassification();
                LoadWorkType();

                if (JobAlertID > 0)
                {
                    if (Entities.SessionData.Member != null)
                    {
                        MembersService service = new MembersService();
                        bool blnResult = false;
                        using (Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId))
                        {
                            if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                                blnResult = true;
                        }

                        if (blnResult)
                        {
                            Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                        }
                    }
                    else
                    {
                        Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                        return;
                    }

                    LoadJobAlert();
                    //enable delete button
                    btnDelete.Visible = true;
                    btnDelete.CommandArgument = JobAlertID.ToString();

                }
                else
                {
                    // When creating disable and check
                    //chkReceiveEmails.Enabled = false;
                    //chkReceiveEmails.Checked = true;
                    chkSendEmailAlerts.Checked = true;

                }
            }

            SetFormValues();
        }

        private void LoadDefaultCountry()
        {
            TList<GlobalSettings> service = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
            if (service.Count > 0)
            {
                if (service[0].DefaultCountryId.HasValue)
                {
                    hfDefaultCountryID.Value = service[0].DefaultCountryId.ToString();
                    phSalary.Enabled = true;
                }
            }
        }

        private void LoadCountries()
        {
            List<Entities.SiteCountries> sitecountries = SiteCountriesService.GetTranslatedCountries();
            rptCountry.DataSource = sitecountries;
            rptCountry.DataBind();
        }

        private void LoadLocationArea()
        {
            TList<Entities.SiteCountries> sitecountrylist = new TList<Entities.SiteCountries>();
            rptCountryLocationArea.DataSource = null;


            foreach (RepeaterItem countryitem in rptCountry.Items)
            {
                HiddenField hfCountry = countryitem.FindControl("hfCountry") as HiddenField;
                CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;

                if (cbCountry.Checked)
                {
                    sitecountrylist.Add(SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, Convert.ToInt32(hfCountry.Value)));
                }
            }
            rptCountryLocationArea.DataSource = sitecountrylist;
            rptCountryLocationArea.DataBind();

            string selectedLocation = hfLocationSelected.Value;
            string selectedArea = hfAreaSelected.Value;

            string[] locationsplit = selectedLocation.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] areasplit = selectedArea.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            hfLocationSelected.Value = string.Empty;
            hfAreaSelected.Value = string.Empty;

            if (locationsplit.Length > 0)
            {
                foreach (RepeaterItem countryitem in rptCountryLocationArea.Items)
                {
                    Repeater rptLocation = countryitem.FindControl("rptLocation") as Repeater;


                    foreach (RepeaterItem locationitem in rptLocation.Items)
                    {
                        HiddenField hfLocation = locationitem.FindControl("hfLocation") as HiddenField;
                        CheckBox cbLocation = locationitem.FindControl("cbLocation") as CheckBox;
                        Repeater rptArea = locationitem.FindControl("rptArea") as Repeater;

                        foreach (string s in locationsplit)
                        {
                            if (s == hfLocation.Value)
                            {
                                cbLocation.Checked = true;
                                hfLocationSelected.Value += hfLocation.Value + ",";
                            }
                        }

                        foreach (RepeaterItem areaitem in rptArea.Items)
                        {
                            HiddenField hfArea = areaitem.FindControl("hfArea") as HiddenField;
                            CheckBox cbArea = areaitem.FindControl("cbArea") as CheckBox;

                            foreach (string s in areasplit)
                            {
                                if (s == hfArea.Value)
                                {
                                    cbArea.Checked = true;
                                    hfAreaSelected.Value += hfArea.Value + ",";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoadClassification()
        {
            List<Entities.SiteProfession> siteprofessions = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);
            rptClassification.DataSource = siteprofessions;
            rptClassification.DataBind();
        }

        private void LoadWorkType()
        {
            List<Entities.SiteWorkType> siteworktypes = SiteWorkTypeService.GetTranslatedWorkTypes();
            rptWorkType.DataSource = siteworktypes;
            rptWorkType.DataBind();
        }

        protected void rptWorkType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfWorkType = e.Item.FindControl("hfWorkType") as HiddenField;
                CheckBox cbWorkType = e.Item.FindControl("cbWorkType") as CheckBox;
                Literal ltWorkType = e.Item.FindControl("ltWorkType") as Literal;

                Entities.SiteWorkType siteworktype = e.Item.DataItem as Entities.SiteWorkType;
                hfWorkType.Value = siteworktype.WorkTypeId.ToString();
                ltWorkType.Text = siteworktype.SiteWorkTypeName;
            }
        }

        protected void rptClassification_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfClassification = e.Item.FindControl("hfClassification") as HiddenField;
                CheckBox cbClassification = e.Item.FindControl("cbClassification") as CheckBox;
                Literal ltClassification = e.Item.FindControl("ltClassification") as Literal;
                Repeater rptSubClassification = e.Item.FindControl("rptSubClassification") as Repeater;

                Entities.SiteProfession siteprofession = e.Item.DataItem as Entities.SiteProfession;
                hfClassification.Value = siteprofession.ProfessionId.ToString();
                ltClassification.Text = siteprofession.SiteProfessionName;
                cbClassification.Attributes.Add("onclick", "ClassificationChecked('" + cbClassification.ClientID + "')");

                List<Entities.SiteRoles> siteroles = SiteRolesService.GetTranslatedByProfessionID(siteprofession.ProfessionId, SessionData.Site.UseCustomProfessionRole);
                rptSubClassification.DataSource = siteroles;
                rptSubClassification.DataBind();
            }
        }

        protected void rptSubClassification_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfSubClassification = e.Item.FindControl("hfSubClassification") as HiddenField;
                CheckBox cbSubClassification = e.Item.FindControl("cbSubClassification") as CheckBox;
                Literal ltSubClassification = e.Item.FindControl("ltSubClassification") as Literal;
                HtmlGenericControl divSubClassification = e.Item.FindControl("divSubClassification") as HtmlGenericControl;

                Entities.SiteRoles siteroles = e.Item.DataItem as Entities.SiteRoles;
                hfSubClassification.Value = siteroles.RoleId.ToString();
                ltSubClassification.Text = siteroles.SiteRoleName;

                CheckBox cbClassification = cbSubClassification.Parent.Parent.Parent.Parent.FindControl("cbClassification") as CheckBox;
                cbSubClassification.Attributes.Add("onclick", "SubClassificationChecked('" + cbSubClassification.ClientID + "', '" + cbClassification.ClientID + "')");
                divSubClassification.Attributes.Add("style", "display: none");
            }
        }

        protected void LoadJobAlert()
        {

            using (Entities.JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
            {
                if (jobAlert != null && jobAlert.JobAlertId > 0 && jobAlert.MemberId == SessionData.Member.MemberId)
                {
                    string[] splits = null;
                    string[] splits2 = null;
                    // Load Job Alert
                    txtKeywords.Text = jobAlert.SearchKeywords;

                    // Checking selected profession & role

                    hfProfessionSelected.Value = string.Empty;
                    hfRoleSelected.Value = string.Empty;

                    if (!string.IsNullOrWhiteSpace(jobAlert.ProfessionId))
                    {
                        splits = jobAlert.ProfessionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        splits2 = (string.IsNullOrWhiteSpace(jobAlert.SearchRoleIds)) ? new string[1] { "" } : jobAlert.SearchRoleIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (RepeaterItem professionitem in rptClassification.Items)
                        {
                            HiddenField hfClassification = professionitem.FindControl("hfClassification") as HiddenField;
                            CheckBox cbClassification = professionitem.FindControl("cbClassification") as CheckBox;
                            Repeater rptSubClassification = professionitem.FindControl("rptSubClassification") as Repeater;

                            foreach (string s in splits)
                            {
                                if (hfClassification.Value == s)
                                {
                                    cbClassification.Checked = true;
                                    hfProfessionSelected.Value += hfClassification.Value + ",";
                                    break;
                                }
                            }

                            foreach (RepeaterItem roleitem in rptSubClassification.Items)
                            {
                                HiddenField hfSubClassification = roleitem.FindControl("hfSubClassification") as HiddenField;
                                CheckBox cbSubClassification = roleitem.FindControl("cbSubClassification") as CheckBox;
                                HtmlGenericControl divSubClassification = roleitem.FindControl("divSubClassification") as HtmlGenericControl;

                                if (cbClassification.Checked)
                                {
                                    divSubClassification.Attributes.Remove("style");
                                }

                                foreach (string s in splits2)
                                {
                                    if (hfSubClassification.Value == s)
                                    {
                                        cbSubClassification.Checked = true;
                                        hfRoleSelected.Value += hfSubClassification.Value + ",";
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    //Country
                    
                    if (!string.IsNullOrWhiteSpace(jobAlert.CountryId))
                    {
                        splits = jobAlert.CountryId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        phSalary.Enabled = (splits.Length == 1);
                        foreach (RepeaterItem countryitem in rptCountry.Items)
                        {
                            HiddenField hfCountry = countryitem.FindControl("hfCountry") as HiddenField;
                            CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;

                            foreach (string s in splits)
                            {
                                if (hfCountry.Value == s)
                                {
                                    cbCountry.Checked = true;
                                    cbCountry.Enabled = true;
                                    if (splits.Length == 1)
                                    {
                                        cbCountry.Enabled = false;
                                    }
                                    else
                                    {
                                        cbCountry.Enabled = true;
                                    }
                                }
                            }
                        }

                        //Location & Area
                        LoadLocationArea();

                        if (!string.IsNullOrWhiteSpace(jobAlert.LocationId))
                        {
                            splits = jobAlert.LocationId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            splits2 = (string.IsNullOrWhiteSpace(jobAlert.AreaIds)) ? new string[1] { "" } : jobAlert.AreaIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (RepeaterItem countryitem in rptCountryLocationArea.Items)
                            {
                                Repeater rptLocation = countryitem.FindControl("rptLocation") as Repeater;

                                foreach (RepeaterItem locationitem in rptLocation.Items)
                                {
                                    HiddenField hfLocation = locationitem.FindControl("hfLocation") as HiddenField;
                                    CheckBox cbLocation = locationitem.FindControl("cbLocation") as CheckBox;
                                    Repeater rptArea = locationitem.FindControl("rptArea") as Repeater;

                                    foreach (string s in splits)
                                    {
                                        if (hfLocation.Value == s)
                                        {
                                            cbLocation.Checked = true;
                                            hfLocationSelected.Value += hfLocation.Value + ",";
                                            break;
                                        }
                                    }

                                    foreach (RepeaterItem roleitem in rptArea.Items)
                                    {
                                        HiddenField hfArea = roleitem.FindControl("hfArea") as HiddenField;
                                        CheckBox cbArea = roleitem.FindControl("cbArea") as CheckBox;
                                        HtmlGenericControl divArea = roleitem.FindControl("divArea") as HtmlGenericControl;

                                        if (cbLocation.Checked)
                                        {
                                            divArea.Attributes.Remove("style");
                                        }

                                        foreach (string s in splits2)
                                        {
                                            if (hfArea.Value == s)
                                            {
                                                cbArea.Checked = true;
                                                hfAreaSelected.Value += hfArea.Value + ",";
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //Work Type
                    if (!string.IsNullOrWhiteSpace(jobAlert.WorkTypeIds))
                    {
                        splits = jobAlert.WorkTypeIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (RepeaterItem worktypeitem in rptWorkType.Items)
                        {
                            HiddenField hfWorkType = worktypeitem.FindControl("hfWorkType") as HiddenField;
                            CheckBox cbWorkType = worktypeitem.FindControl("cbWorkType") as CheckBox;

                            foreach (string s in splits)
                            {
                                if (hfWorkType.Value == s)
                                {
                                    cbWorkType.Checked = true;
                                }
                            }
                        }
                    }

                    if (jobAlert.SalaryTypeId.HasValue)
                    {
                        ddlSalaryType.SelectedValue = jobAlert.SalaryTypeId.ToString();
                        if (ddlSalaryType.SelectedValue != "0")
                        {
                            tbSalaryFrom.Enabled = true;
                            tbSalaryTo.Enabled = true;
                        }
                    }

                    ////if (jobAlert.CurrencyId.HasValue)
                    //{
                    if (jobAlert.SalaryLowerBand.HasValue)
                    {
                        tbSalaryFrom.Text = string.Format("{0}", jobAlert.SalaryLowerBand);
                    }

                    if (jobAlert.SalaryUpperBand.HasValue)
                    {
                        tbSalaryTo.Text = string.Format("{0}", jobAlert.SalaryUpperBand);
                    }
                    //}

                    txtNameOfTheFeed.Text = jobAlert.JobAlertName;
                    chkSendEmailAlerts.Checked = jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value ? true : false;
                    ////chkMainAlert.Checked = (jobAlert.PrimaryAlert.HasValue ? true : false);
                    ////chkReceiveEmails.Checked = (jobAlert.AlertActive.HasValue ? true : false);

                    ////chkTermsAndConditions.Checked = true;
                    //ucJobAlert1.SetSalary();

                    if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                    {
                        ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditJobAlert"));
                        CommonPage.SetBrowserPageTitle(Page, "Edit Job Alert");
                    }
                    else
                    {
                        ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditFavouriteSearch"));
                        CommonPage.SetBrowserPageTitle(Page, "Edit Favourite Search");
                    }
                }
                else
                {
                    Response.Redirect("~/member/createjobalert.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entities.JobAlerts jobAlert = new JXTPortal.Entities.JobAlerts();

            if (JobAlertID > 0)
            {

                using (jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
                {
                    if (jobAlert == null || SessionData.Member == null)
                    {
                        Response.Redirect("~/member/jobalert.aspx");
                    }
                }
            }


            String strError = string.Empty;

            ltlMessage.Text = String.Empty;

            if (!Page.IsValid)
                return;
            //if (!ucJobAlert1.IsValid(ref strError))
            //{
            //    ltlMessage.Text = String.Format("{0}{1}", ltlMessage.Text, strError);
            //}

            SalesforceMemberSync memberSync = new SalesforceMemberSync();

            if (phProfileSection.Visible)
            {
                if (!Common.Utils.VerifyEmail(tbEmail.Text.Trim()))
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailInvalid"));

                if (!string.IsNullOrEmpty(tbEmail.Text.Trim()))
                {
                    using (JXTPortal.Entities.Members member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, tbEmail.Text.Trim()))
                    {
                        if (member != null)
                        {
                            ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailAlreadyExist"));
                        }
                    }
                    
                    // SALESFORCE - If exists from Sales force then save in the platform then alert the email already exists.
                    int memberid = 0; string errormsg = string.Empty;
                    if (ltlMessage.Text.Length < 1 && memberSync.GetContactFromSalesForceAndSave(tbEmail.Text.Trim(), string.Empty, SessionData.Site.MasterSiteId, ref memberid, ref errormsg))
                    {
                        ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailAlreadyExist"));
                    }
                }

            }

            //if (txtNameOfTheFeed.Text.Trim().Length < 1)
            //{
            //    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelNameFeedMandatory"));
            //}

            //if (!chkTermsAndConditions.Checked)
            //{
            //    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("ErrorAcceptTermCondition"));
            //}

            if (ltlMessage.Text.Length < 1)
            {
                string countryselected = string.Empty;
                string worktypeselected = string.Empty;

                foreach (RepeaterItem countryitem in rptCountry.Items)
                {
                    HiddenField hfCountry = countryitem.FindControl("hfCountry") as HiddenField;
                    CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;

                    if (cbCountry.Checked)
                    {
                        countryselected += hfCountry.Value + ",";
                    }
                }

                foreach (RepeaterItem worktypeitem in rptWorkType.Items)
                {
                    HiddenField hfWorkType = worktypeitem.FindControl("hfWorkType") as HiddenField;
                    CheckBox cbWorkType = worktypeitem.FindControl("cbWorkType") as CheckBox;

                    if (cbWorkType.Checked)
                    {
                        worktypeselected += hfWorkType.Value + ",";
                    }
                }
                jobAlert.JobAlertName = txtNameOfTheFeed.Text;
                jobAlert.SearchKeywords = Utils.StripHTML(txtKeywords.Text);
                jobAlert.ProfessionId = hfProfessionSelected.Value.TrimEnd(new char[] { ',' });
                jobAlert.SearchRoleIds = hfRoleSelected.Value.TrimEnd(new char[] { ',' });
                jobAlert.CountryId = countryselected.TrimEnd(new char[] { ',' });
                jobAlert.LocationId = hfLocationSelected.Value.TrimEnd(new char[] { ',' });
                jobAlert.AreaIds = hfAreaSelected.Value.TrimEnd(new char[] { ',' });
                jobAlert.WorkTypeIds = worktypeselected;
                jobAlert.SalaryTypeId = (ddlSalaryType.SelectedValue == "0") ? (int?)null : Convert.ToInt32(ddlSalaryType.SelectedValue);
                jobAlert.CurrencyId = null; //(string.IsNullOrEmpty(ucJobAlert1.SalaryLowerBand)) ? (int?)null : Convert.ToInt32(ucJobAlert1.SalaryLowerBand.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[0])

                if (jobAlert.SalaryTypeId > 0)
                {
                    jobAlert.SalaryLowerBand = CommonFunction.GetSalaryDecimalAmount(tbSalaryFrom.Text);
                    jobAlert.SalaryUpperBand = CommonFunction.GetSalaryDecimalAmount(tbSalaryTo.Text);
                }
                else
                {
                    jobAlert.SalaryLowerBand = (decimal?)null;
                    jobAlert.SalaryUpperBand = (decimal?)null;
                }

                if (SessionData.Member == null)
                {
                    using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                    {
                        objMembers.SiteId = SessionData.Site.MasterSiteId;
                        objMembers.FirstName = tbFirstName.Text;
                        objMembers.Surname = tbSurname.Text;
                        objMembers.EmailAddress = tbEmail.Text.Trim();
                        objMembers.Password = CommonService.EncryptMD5(tbPassword.Text);
                        objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        objMembers.Username = tbEmail.Text;
                        objMembers.CountryId = 1;

                        TList<GlobalSettings> service = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
                        if (service.Count > 0)
                        {
                            if (service[0].DefaultCountryId.HasValue)
                            {
                                objMembers.CountryId = service[0].DefaultCountryId.Value;
                            }
                        }

                        objMembers.ValidateGuid = Guid.NewGuid();
                        objMembers.SearchField = String.Format("{0} {1}",
                                                   objMembers.FirstName,
                                                   objMembers.Surname);
                        objMembers.ReferringSiteId = SessionData.Site.SiteId;
                        MembersService.Insert(objMembers);

                        //Send confirmation email
                        //MailService.SendNewJobApplicationAccount(objMembers, newpassword);
                        MailService.SendMemberRegistration(objMembers, tbPassword.Text);

                        // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce.
                        memberSync = new SalesforceMemberSync(objMembers);

                        jobAlert.MemberId = objMembers.MemberId;
                        jobAlert.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    }
                }
                else
                {
                    jobAlert.MemberId = SessionData.Member.MemberId;
                    jobAlert.EmailFormat = SessionData.Member.EmailFormat;
                }

                // Save Job Alert
                // ToDo - Insert - Update 
                jobAlert.JobAlertName = txtNameOfTheFeed.Text.Trim();
                jobAlert.PrimaryAlert = false;
                jobAlert.AlertActive = chkSendEmailAlerts.Checked;

                bool isInserted = false;
                if (JobAlertID > 0)
                {
                    JobAlertsService.Update(jobAlert);
                    isInserted = false;
                }
                else
                {
                    jobAlert.UnsubscribeValidateId = Guid.NewGuid();
                    jobAlert.EditValidateId = Guid.NewGuid();
                    jobAlert.ViewValidateId = Guid.NewGuid();

                    JobAlertsService.Insert(jobAlert);
                    isInserted = true;
                }

                // Redirect to list page
                if (SessionData.Member == null)
                {
                    //if (Convert.ToString(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", "")) == "")
                    if (DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", "") == null || (DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_REGISTRATION_SUCCESS, "", "", "")).Length == 0)
                        ltlMessage.Text = String.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"));
                    //ltlalertsuccess.Text = Convert.ToString(CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"));
                    else
                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", ""));
                    //pnlJobAlert.Visible = false;
                    return;
                }
                else
                {
                    if (isInserted)
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=1");
                        }
                        else
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=3");
                        }
                    }
                    else
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=2");
                        }
                        else
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=4");
                        }
                    }
                }
            }

            if (ltlMessage.Text.Length > 0)
                ltlMessage.Text = String.Format("<div class='form-error-message'><ul>{0}</ul></div>", ltlMessage.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;

            JobAlertsService.Delete(Convert.ToInt32(string.Format("{0}", thisButton.CommandArgument)));

            Response.Redirect("~/member/myjobalerts.aspx");
        }


        public void SetFormValues()
        {
            ddlSalaryType.Items[0].Text = CommonFunction.GetResourceValue("LabelPleaseSelectSalaryType");
            ddlSalaryType.Items[1].Text = CommonFunction.GetResourceValue("LabelSalaryAnnually");
            ddlSalaryType.Items[2].Text = CommonFunction.GetResourceValue("LabelSalaryHourly");

            cvCountry.ErrorMessage = CommonFunction.GetResourceValue("LabelCountryRequired");
            rfvEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            rfvFirstName.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            rfvLastName.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            rfvNameOfTheFeed.ErrorMessage = CommonFunction.GetResourceValue("LabelNameOfAlertRequired");

            btnSave.Text = CommonFunction.GetResourceValue("ButtonSave");
            btnDelete.Text = CommonFunction.GetResourceValue("LabelDelete");

            int selected = 0;
            foreach (RepeaterItem countryitem in rptCountry.Items)
            {
                CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;
                if (cbCountry.Checked)
                {
                    selected++;
                }
            }

            if (selected == 0)
            {
                foreach (RepeaterItem countryitem in rptCountry.Items)
                {
                    CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;
                    HiddenField hfCountry = countryitem.FindControl("hfCountry") as HiddenField;

                    if (hfCountry.Value == hfDefaultCountryID.Value)
                    {
                        cbCountry.Checked = true;
                        cbCountry.Enabled = false;
                    }
                }

                LoadLocationArea();
            }

            //chkReceiveEmails.Text = CommonFunction.GetResourceValue("LabelRequestAlertEmail");
            //pnlSendEmailAlerts.Visible = !IsFav;
            if (JobAlertID < 0)
            {
                chkSendEmailAlerts.Checked = !IsFav;
            }

            if (RetainSearch)
            {
                txtNameOfTheFeed.Focus();
            }
        }

        protected void rptCountry_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.SiteCountries sitecountry = e.Item.DataItem as Entities.SiteCountries;
                HiddenField hfCountry = e.Item.FindControl("hfCountry") as HiddenField;
                CheckBox cbCountry = e.Item.FindControl("cbCountry") as CheckBox;
                Literal ltCountry = e.Item.FindControl("ltCountry") as Literal;
                hfCountry.Value = sitecountry.CountryId.ToString();
                ltCountry.Text = sitecountry.SiteCountryName;
            }
        }

        protected void cbCountry_CheckedChanged(object sender, EventArgs e)
        {
            int selected = 0;
            foreach (RepeaterItem countryitem in rptCountry.Items)
            {
                CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;
                if (cbCountry.Checked)
                {
                    cbCountry.Enabled = true;
                    selected++;
                }
            }

            if (selected == 1)
            {
                foreach (RepeaterItem countryitem in rptCountry.Items)
                {
                    CheckBox cbCountry = countryitem.FindControl("cbCountry") as CheckBox;
                    if (cbCountry.Checked)
                    {
                        cbCountry.Enabled = false;
                    }
                }
            }

            phSalary.Enabled = (selected == 1);
            if (!phSalary.Enabled)
            {
                ddlSalaryType.SelectedValue = "0";
                tbSalaryFrom.Text = string.Empty;
                tbSalaryTo.Text = string.Empty;
            }

            if (phSalary.Enabled && ddlSalaryType.SelectedValue != "0")
            {
                tbSalaryFrom.Enabled = true;
                tbSalaryTo.Enabled = true;
            }
            LoadLocationArea();
            // System.Threading.Thread.Sleep(1000);
        }

        protected void rptLocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfLocation = e.Item.FindControl("hfLocation") as HiddenField;
                CheckBox cbLocation = e.Item.FindControl("cbLocation") as CheckBox;
                Literal ltLocation = e.Item.FindControl("ltLocation") as Literal;
                Repeater rptArea = e.Item.FindControl("rptArea") as Repeater;

                SiteLocation sitelocation = e.Item.DataItem as SiteLocation;
                hfLocation.Value = sitelocation.LocationId.ToString();
                ltLocation.Text = sitelocation.SiteLocationName;

                cbLocation.Attributes.Add("onclick", "LocationChecked('" + cbLocation.ClientID + "')");

                rptArea.DataSource = SiteAreaService.GetTranslatedAreas(sitelocation.LocationId);
                rptArea.DataBind();
            }
        }

        protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hfArea = e.Item.FindControl("hfArea") as HiddenField;
            CheckBox cbArea = e.Item.FindControl("cbArea") as CheckBox;
            Literal ltArea = e.Item.FindControl("ltArea") as Literal;
            HtmlGenericControl divArea = e.Item.FindControl("divArea") as HtmlGenericControl;


            SiteArea sitearea = e.Item.DataItem as SiteArea;
            hfArea.Value = sitearea.AreaId.ToString();
            ltArea.Text = sitearea.SiteAreaName;

            CheckBox cbLocation = cbArea.Parent.Parent.Parent.Parent.FindControl("cbLocation") as CheckBox;
            cbArea.Attributes.Add("onclick", "AreaChecked('" + cbArea.ClientID + "', '" + cbLocation.ClientID + "')");
            divArea.Attributes.Add("style", "display: none");
        }

        protected void rptCountryLocationArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal ltCountry = e.Item.FindControl("ltCountry") as Literal;
            Entities.SiteCountries sitecountry = e.Item.DataItem as Entities.SiteCountries;
            Repeater rptLocation = e.Item.FindControl("rptLocation") as Repeater;

            ltCountry.Text = sitecountry.SiteCountryName;

            rptLocation.DataSource = null;
            List<Entities.SiteLocation> sitelocations = new List<SiteLocation>();

            sitelocations.AddRange(SiteLocationService.GetTranslatedLocationsByCountryID(Convert.ToInt32(sitecountry.CountryId)));

            if (sitelocations.Count > 0)
            {
                rptLocation.DataSource = sitelocations;
            }

            rptLocation.DataBind();


        }

        protected void cvCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            foreach (RepeaterItem ri in rptCountry.Items)
            {
                CheckBox cbCountry = ri.FindControl("cbCountry") as CheckBox;
                HiddenField hfCountry = ri.FindControl("hfCountry") as HiddenField;

                if (cbCountry.Checked)
                {
                    count++;
                }
            }

            args.IsValid = (count > 0);
        }

    }
}
