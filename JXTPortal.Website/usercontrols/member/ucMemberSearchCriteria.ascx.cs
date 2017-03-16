using System;
using System.Collections;
using System.Collections.Generic;
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

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberSearchCriteria : System.Web.UI.UserControl
    {
        private int memberID = 0;

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

        private GlobalLocationService _globalLocationService;
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

        private GlobalAreaService _globalAreaService;
        private GlobalAreaService GlobalAreaService
        {
            get
            {
                if (_globalAreaService == null)
                    _globalAreaService = new GlobalAreaService();
                return _globalAreaService;
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

        public int? _Profession
        {
            get
            {
                if (ddlprefClassification.SelectedItem != null && ddlprefClassification.SelectedValue.Length > 0 && Convert.ToInt32(ddlprefClassification.SelectedValue) > 0)
                    return Convert.ToInt32(ddlprefClassification.SelectedValue);
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    CommonFunction.SetDropDownByValue(ddlprefClassification, value.Value.ToString());
                    populateRoles(value.Value);
                }
            }
        }

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

        public string SalaryLowerBand
        {
            get
            {
                decimal? _temp = CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text);
                if (!String.IsNullOrWhiteSpace(txtSalaryLowerBand.Text) && _temp.HasValue)
                    return _temp.Value.ToString();
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    txtSalaryLowerBand.Text = value;
                }
            }
        }

        public string SalaryUpperBand
        {
            get
            {
                decimal? _temp = CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text);
                if (!String.IsNullOrWhiteSpace(txtSalaryLowerBand.Text) && _temp.HasValue)
                    return _temp.Value.ToString();
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    txtSalaryUpperBand.Text = value;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }
        }

        protected void initForm()
        {
            populateProfessions();
            populateRoles(0);
            populateCountries();
            //populateSalaries();
            LoadSalary();
            populateAvailableStatus();

            //rvFirstApprovedDate.Type = ValidationDataType.Date;
            //rvFirstApprovedDate.MaximumValue = new DateTime(DateTime.Now.Year + 100, 12, 31).ToString("yyyy-MM-dd");
            //rvFirstApprovedDate.MinimumValue = System.Data.SqlTypes.SqlDateTime.MinValue.Value.ToString("yyyy-MM-dd");
        }

        protected void loadForm()
        {
            //if (Entities.SessionData.Member == null)
            //{
            //    Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
            //    return;
            //}

            //memberID = Entities.SessionData.Member.MemberId;

            //initForm();

            //rfvArea.ErrorMessage = CommonFunction.GetResourceValue("LabelAreaRequired");
            //cvFirstApprovedDate.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidDate");
            //rvFirstApprovedDate.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidDateRange");
            //rfvCountry.ErrorMessage = CommonFunction.GetResourceValue("LabelCountryRequired");

            //using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
            //{
            //    ddlSalary.SelectedValue = Convert.ToString(objMembers.PreferredSalaryId);

            //    if (objMembers.PreferredSalaryId > 0)
            //    {
            //        //LoadSalaryFrom(Convert.ToInt32(objMembers.PreferredSalaryId), objMembers.PreferredSalaryFrom);

            //        txtSalaryLowerBand.Text = Convert.ToString(objMembers.PreferredSalaryFrom);

            //        //LoadSalaryTo(Convert.ToInt32(objMembers.PreferredSalaryId), 1, Convert.ToDecimal(objMembers.PreferredSalaryFrom), objMembers.PreferredSalaryTo);

            //        txtSalaryUpperBand.Text = Convert.ToString(objMembers.PreferredSalaryTo);
            //    }

            //    if (objMembers.PreferredCategoryId.HasValue)
            //    {
            //        CommonFunction.SetDropDownByValue(ddlprefClassification, objMembers.PreferredCategoryId.Value.ToString());
            //        populateRoles(objMembers.PreferredCategoryId.Value);
            //    }

            //    if (objMembers.PreferredSubCategoryId.HasValue)
            //    {
            //        CommonFunction.SetDropDownByValue(ddlprefSubClassification, objMembers.PreferredSubCategoryId.Value.ToString());
            //    }

            //    if (objMembers.CountryId > 0)
            //    {
            //        CommonFunction.SetDropDownByValue(ddlCountry, objMembers.CountryId.ToString());
            //        populateLocations(objMembers.CountryId);
            //    }

            //    if (objMembers.LocationId > 0)
            //    {
            //        CommonFunction.SetDropDownByValue(ddlLocation, objMembers.LocationId.ToString());
            //        populateAreas(objMembers.LocationId);
            //    }

            //    if (objMembers.AreaId > 0)
            //    {
            //        CommonFunction.SetDropDownByValue(ddlArea, objMembers.AreaId.ToString());
            //    }

            //    ddlAvailability.SelectedValue = Convert.ToString(objMembers.AvailabilityId);

            //    if (!string.IsNullOrEmpty(Convert.ToString(objMembers.AvailabilityFromDate)))
            //    {
            //        txtAvailabilityDate.Text = string.Format("{0:dd/MM/yyyy}", objMembers.AvailabilityFromDate);
            //    }
            //}
        }

        private void LoadSalary()
        {
            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            ddlSalary.Items.Clear();

            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {
                if (sitesalarytype.SalaryTypeId != (int)PortalEnums.Search.SalaryType.NA)
                {
                    ddlSalary.Items.Add(new ListItem(sitesalarytype.SalaryTypeName, sitesalarytype.SalaryTypeId.ToString()));
                }
            }

            ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
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

        private void LoadSalaryTo(int salarytypeid, int currecnyid, decimal amount, string salaryToValue)
        {
            ddlSalaryTo.Items.Clear();

            VList<ViewSalary> salaryToList = ViewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currecnyid, salarytypeid, amount);
            bool isAlreadySelected = false;
            foreach (ViewSalary vs in salaryToList)
            {
                ListItem li = new ListItem();
                li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
                li.Text = vs.SalaryDisplay;

                if (!string.IsNullOrEmpty(salaryToValue))
                {
                    if (vs.Amount == Convert.ToDecimal(salaryToValue))
                    {
                        if (!isAlreadySelected)
                        {
                            li.Selected = true;
                        }
                        isAlreadySelected = true;
                    }
                }

                ddlSalaryTo.Items.Add(li);
            }
        }

        protected void ddlSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalaryFrom(Convert.ToInt32(ddlSalary.SelectedValue), string.Empty);
            LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), 0, 0, string.Empty);
        }

        protected void ddlSalaryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = ddlSalaryFrom.SelectedValue;
            string[] parts = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToInt32(parts[0]), Convert.ToDecimal(parts[1]), string.Empty);
        }*/

        protected void populateProfessions()
        {
            ddlprefClassification.DataSource = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);
            ddlprefClassification.DataTextField = "SiteProfessionName";
            ddlprefClassification.DataValueField = "ProfessionId";
            ddlprefClassification.DataBind();
            ddlprefClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllClassifications"), "0"));
        }

        protected void populateRoles(int ProfessionId)
        {
            ddlprefSubClassification.Items.Clear();

            if (ProfessionId > 0)
            {
                ddlprefSubClassification.DataSource = SiteRolesService.GetTranslatedByProfessionID(ProfessionId, SessionData.Site.UseCustomProfessionRole);
                ddlprefSubClassification.DataTextField = "SiteRoleName";
                ddlprefSubClassification.DataValueField = "RoleId";
                ddlprefSubClassification.DataBind();
                ddlprefSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllSubClassifications"), "0"));
            }
            else
            {
                ddlprefSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectClassificationFirst"), "0"));
            }
        }

        protected void populateCountries()
        {
            ddlCountry.DataSource = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllCountries"), "0"));
        }

        private void populateLocations(int CountryID)
        {
            if (CountryID > 0)
            {
                ddlLocation.DataSource = GlobalLocationService.GetTranslatedLocations(CountryID);
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationID";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllLocations"), "0"));


                using (JXTPortal.Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, CountryID))
                {

                    if (siteCountry != null)
                    {
                        ltlLowerCurrency.Text = siteCountry.Currency;
                        ltlUpperCurrency.Text = siteCountry.Currency;
                    }
                }
            }
            else
            {
                ddlLocation.Items.Clear();
                ddlLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectCountryFirst"), "0"));
            }
        }

        private void populateAreas(int LocationID)
        {
            if (LocationID > 0)
            {
                ddlArea.DataSource = GlobalAreaService.GetTranslatedAreas(LocationID);
                ddlArea.DataTextField = "AreaName";
                ddlArea.DataValueField = "AreaID";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllAreas"), "0"));
            }
            else
            {
                ddlArea.Items.Clear();
                ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectLocationFirst"), "0"));
            }
        }

        protected void populateAvailableStatus()
        {
            List<JXTPortal.Entities.AvailableStatus> avs = AvailableStatusService.GetTranslatedSiteAvailableStatus();
            IEnumerable ieavs;
            ieavs = avs.Where((availablestatus) => { return (availablestatus.SiteId == SessionData.Site.MasterSiteId && availablestatus.IsValid); }).OrderBy(availablestatus => availablestatus.Sequence);

            ddlAvailability.DataSource = ieavs;
            ddlAvailability.DataTextField = "AvailableStatusName";
            ddlAvailability.DataValueField = "AvailableStatusParentId";
            ddlAvailability.DataBind();

            ddlAvailability.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectAvailableStatus"), "0"));
        }

        protected void ddlprefClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlprefClassification.SelectedValue))
            {
                populateRoles(Convert.ToInt32(ddlprefClassification.SelectedValue));
            }
        }

        protected void ctmMemberLocation_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!(Convert.ToInt32(ddlLocation.SelectedValue) > 0))
            {
                args.IsValid = false;
                ctmMemberLocation.ErrorMessage = CommonFunction.GetResourceValue("LabelLocationRequired");
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                populateLocations(Convert.ToInt32(ddlCountry.SelectedValue));
                populateAreas(Convert.ToInt32(ddlLocation.SelectedValue));

            }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlLocation.SelectedValue))
            {
                populateAreas(Convert.ToInt32(ddlLocation.SelectedValue));


            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //((JXTPortal.Website.members._default)Page).SelectedTabIndex = 2;

            //memberID = Entities.SessionData.Member.MemberId;

            //if (Page.IsValid)
            //{
            //    using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
            //    {
            //        objMembers.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            //        objMembers.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);
            //        objMembers.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
            //        objMembers.AvailabilityId = Convert.ToInt32(ddlAvailability.SelectedValue);

            //        if (ddlSalary.SelectedValue != "0")
            //        {

            //            objMembers.PreferredSalaryId = Convert.ToInt32(ddlSalary.SelectedValue);
            //            objMembers.PreferredSalaryFrom = SalaryLowerBand;
            //            objMembers.PreferredSalaryTo = SalaryUpperBand;
            //        }
            //        else
            //        {
            //            objMembers.PreferredSalaryId = (int?)null;
            //            objMembers.PreferredSalaryFrom = string.Empty;
            //            objMembers.PreferredSalaryTo = string.Empty;
            //        }

            //        if (!string.IsNullOrEmpty(txtAvailabilityDate.Text))
            //        {
            //            objMembers.AvailabilityFromDate = Convert.ToDateTime(txtAvailabilityDate.Text);
            //        }

            //        string strEducation = string.Empty;

            //        objMembers.PreferredCategoryId = (ddlprefClassification.SelectedValue != "0") ? Convert.ToInt32(ddlprefClassification.SelectedValue) : (int?)null;
            //        objMembers.PreferredSubCategoryId = (ddlprefSubClassification.SelectedValue != "0") ? Convert.ToInt32(ddlprefSubClassification.SelectedValue) : (int?)null;

            //        if (objMembers.EducationId.HasValue)
            //        {
            //            TList<JXTPortal.Entities.Educations> edu = EducationsService.GetBySiteId(SessionData.Site.SiteId);
            //            edu.Filter = "EducationParentID = " + objMembers.EducationId;
            //            if (edu.Count > 0)
            //            {
            //                strEducation = edu[0].EducationName;
            //            }
            //        }

            //        objMembers.SearchField = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",
            //                                  objMembers.FirstName,
            //                                  objMembers.Surname,
            //                                  Utils.CleanStringSpaces(objMembers.Address1),
            //                                  (ddlCountry.SelectedValue == "0") ? "" : ddlCountry.SelectedItem.Text,
            //                                  (ddlLocation.SelectedValue == "0") ? "" : ddlLocation.SelectedItem.Text,
            //                                  (ddlArea.SelectedValue == "0") ? "" : ddlArea.SelectedItem.Text,
            //                                  objMembers.Gender,
            //                                  (ddlprefClassification.SelectedValue == "0") ? "" : ddlprefClassification.SelectedItem.Text,
            //                                  (ddlprefSubClassification.SelectedValue == "0") ? "" : ddlprefSubClassification.SelectedItem.Text,
            //                                  strEducation,
            //                                  objMembers.PreferredSalaryFrom,
            //                                  objMembers.PreferredSalaryTo,
            //                                  Utils.CleanStringSpaces(objMembers.Tags));
            //        //Update members
            //        MembersService.Update(objMembers);
            //    }
            //}
        }
    }
}