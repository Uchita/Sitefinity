using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucJobAlert : System.Web.UI.UserControl
    {
        #region Declare variables

        private SiteWorkTypeService _siteWorkTypeService;
        private SiteCountriesService _siteCountriesService;
        private SiteLocationService _siteLocationService;
        private LocationService _LocationService;
        private SiteAreaService _siteAreaService;
        private SiteProfessionService _siteProfessionService;
        private SiteRolesService _siteRolesService;
        private SiteSalaryTypeService _sitesalarytypeservice;
        private ViewSalaryService _viewsalaryservice = null;

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

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteAreaService == null)
                    _siteAreaService = new SiteAreaService();
                return _siteAreaService;
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

        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeservice == null)
                    _sitesalarytypeservice = new SiteSalaryTypeService();
                return _sitesalarytypeservice;
            }

        }

        private ViewSalaryService ViewSalaryService
        {
            get
            {
                if (_viewsalaryservice == null)
                    _viewsalaryservice = new ViewSalaryService();
                return _viewsalaryservice;
            }
        }

        #endregion

        #region Return Properties

        public string SearchKeywords
        {
            get
            {
                return txtKeywords.Text.Trim();
            }
            set
            {
                txtKeywords.Text = value;
            }
        }

        public string ProfessionId
        {
            get
            {
                if (ddlProfession.SelectedItem != null && ddlProfession.SelectedValue.Length > 0 && Convert.ToInt32(ddlProfession.SelectedValue) > 0)
                    return ddlProfession.SelectedValue;
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    CommonFunction.SetDropDownByValue(ddlProfession, value.ToString());
                    LoadRoles(value);
                }
            }
        }

        public string SearchRoleIds
        {
            get
            {
                if (ddlRole.SelectedItem != null && ddlRole.SelectedValue.Length > 0 && Convert.ToInt32(ddlRole.SelectedValue) > 0)
                    return ddlRole.SelectedValue;
                return string.Empty;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    CommonFunction.SetDropDownByValue(ddlRole, value);
            }
        }

        public string LocationID
        {
            get
            {
                if (ddlLocation.SelectedItem != null && ddlLocation.SelectedValue.Length > 0 && Convert.ToInt32(ddlLocation.SelectedValue) > 0)
                    return ddlLocation.SelectedValue;
                return null;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    CommonFunction.SetDropDownByValue(ddlLocation, value);
                    LoadArea();
                }
            }
        }

        public string AreaIds
        {
            get
            {
                if (lstBoxArea.SelectedItem != null && lstBoxArea.SelectedValue.Length > 0)
                    return CommonFunction.GetListBoxByValue(lstBoxArea);
                return string.Empty;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    CommonFunction.SetListBoxByValue(lstBoxArea, value.ToString());
            }
        }
        public int? SalaryTypeId
        {
            get
            {
                if (ddlSalary.SelectedItem != null && ddlSalary.SelectedValue.Length > 0 && Convert.ToInt32(ddlSalary.SelectedValue) > 0)
                    return Convert.ToInt32(ddlSalary.SelectedValue);
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    CommonFunction.SetDropDownByValue(ddlSalary, value.Value.ToString());
                    //LoadSalaryFrom(value.Value);
                    //LoadSalaryTo(value.Value, 0, 0);
                }
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
        /*
        public string SalaryLowerBand
        {
            get
            {
                if (ddlSalaryFrom.SelectedItem != null && ddlSalaryFrom.SelectedValue.Length > 0)
                    return ddlSalaryFrom.SelectedValue;
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CommonFunction.SetDropDownByValue(ddlSalaryFrom, value.ToString());

                    string[] parts = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    LoadSalaryTo(SalaryTypeId.Value, Convert.ToInt32(parts[0]), Convert.ToDecimal(parts[1]));
                }
            }
        }

        public string SalaryUpperBand
        {
            get
            {
                if (ddlSalaryTo.SelectedItem != null && ddlSalaryTo.SelectedValue.Length > 0)
                    return ddlSalaryTo.SelectedValue;
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    CommonFunction.SetDropDownByValue(ddlSalaryTo, value.ToString());
            }
        }
        */
        public int? WorkTypeIds
        {
            get
            {
                if (ddlWorkType.SelectedItem != null && ddlWorkType.SelectedValue.Length > 0 && Convert.ToInt32(ddlWorkType.SelectedValue) > 0)
                    return Convert.ToInt32(ddlWorkType.SelectedValue);
                return null;
            }
            set
            {
                if (value.HasValue)
                    CommonFunction.SetDropDownByValue(ddlWorkType, value.Value.ToString());
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                BindControls();
            }
            else
            {
                string js = @"$(document).ready(function () {
                            // Decimal value valiation
                            $('.numbersOnly').keyup(function () {
                                this.value = this.value.replace(/[^0-9\.]/g, '');
                            });
                    });";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "numberOnlyJS", js, true);
            }
        }

        #endregion

        #region Drop Down Events

        protected void ddlProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles(ddlProfession.SelectedValue);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "SetSalaryPlaceholders", "SalaryChange();", true);
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
        }

        protected void ddlSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (Convert.ToInt32(ddlSalary.SelectedValue) == (int) PortalEnums.Search.SalaryType.Annual)
                txtSalaryLowerBand.Attributes.Add("placeholder",CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualTo"));
            if (Convert.ToInt32(ddlSalary.SelectedValue) == (int)PortalEnums.Search.SalaryType.Hourly)
                txtSalaryUpperBand.Attributes.Add("placeholder",CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyTo"));
            */
            SetSalary();

        }

        /*      
               protected void ddlSalaryFrom_SelectedIndexChanged(object sender, EventArgs e)
               {
                   string result = ddlSalaryFrom.SelectedValue;
                   string[] parts = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                   LoadSalaryTo(Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToInt32(parts[0]), Convert.ToDecimal(parts[1]));
               }
               */
        #endregion


        #region Click Event handlers
        #endregion

        #region Methods

        public void BindControls()
        {
            LoadWorkType();
            LoadSalary();
            LoadLocation();
            LoadArea();
            LoadProfession();
            LoadRoles(null);

            if (RetainSearch)
            {
                txtKeywords.Text = SessionData.JobSearch.Keywords;
                ddlProfession.SelectedValue = (!string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID)) ? SessionData.JobSearch.ProfessionID : "0";
                if (!string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID))
                {
                    LoadRoles(SessionData.JobSearch.ProfessionID);
                }
                ddlRole.SelectedValue = (SessionData.JobSearch.RoleIDs != string.Empty) ? SessionData.JobSearch.RoleIDs : "0";
                ddlLocation.SelectedValue = (!string.IsNullOrWhiteSpace(SessionData.JobSearch.LocationID)) ? SessionData.JobSearch.LocationID : "0";
                if (!string.IsNullOrWhiteSpace(SessionData.JobSearch.LocationID))
                {
                    LoadArea();
                }
                lstBoxArea.SelectedValue = (SessionData.JobSearch.AreaIDs != string.Empty) ? SessionData.JobSearch.AreaIDs : "0";
                ddlSalary.SelectedValue = (SessionData.JobSearch.SalaryTypeID.HasValue) ? SessionData.JobSearch.SalaryTypeID.Value.ToString() : "0";
                txtSalaryLowerBand.Text = (SessionData.JobSearch.SalaryLowerBand.HasValue) ? SessionData.JobSearch.SalaryLowerBand.Value.ToString() : string.Empty;
                txtSalaryUpperBand.Text = (SessionData.JobSearch.SalaryUpperBand.HasValue) ? SessionData.JobSearch.SalaryUpperBand.Value.ToString() : string.Empty;
                ddlWorkType.SelectedValue = (SessionData.JobSearch.WorkTypeID.HasValue) ? SessionData.JobSearch.WorkTypeID.Value.ToString() : "0";
            }

        }

        public Boolean IsValid(ref String strError)
        {
            if (txtKeywords.Text.Length > 100)
            {
                strError = strError + "<li>" + CommonFunction.GetResourceValue("ErrorKeywordSize") + "</li>";
            }

            /* && 
                (ddlProfession.SelectedItem != null && ddlProfession.SelectedValue == "0") &&
                    (ddlSalary.SelectedItem != null && ddlSalary.SelectedValue == "0") &&
                    (ddlWorkType.SelectedItem != null && ddlWorkType.SelectedValue == "0"))*/
            /*if ((ddlLocation.SelectedItem != null && ddlLocation.SelectedValue == "0"))
            {
                strError = strError + "<li>" + CommonFunction.GetResourceValue("ErrorEnterKeyword") + "</li>";

            }*/

            if (strError.Length > 0)
                return false;

            return true;
        }

        private void LoadWorkType()
        {
            List<JXTPortal.Entities.SiteWorkType> siteWorkTypes = SiteWorkTypeService.GetTranslatedWorkTypes();
            ddlWorkType.DataSource = siteWorkTypes;
            ddlWorkType.DataBind();
            ddlWorkType.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllWorkTypes"), "0"));

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

            SetSalary();
        }

        public void SetSalary()
        {
            using (TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if ((ddlLocation.SelectedValue != "" && Convert.ToInt32(ddlLocation.SelectedValue) > 0) || sitecountries.Count == 1)
                    ddlSalary.Enabled = true;
                else
                {
                    ddlSalary.Enabled = false;
                    ddlSalary.SelectedIndex = 0;
                    txtSalaryLowerBand.Text = "";
                    txtSalaryUpperBand.Text = "";
                }
            }
            // Enable salary 
            txtSalaryLowerBand.Enabled = (Convert.ToInt32(ddlSalary.SelectedValue) > 0) ? true : false;
            txtSalaryUpperBand.Enabled = (Convert.ToInt32(ddlSalary.SelectedValue) > 0) ? true : false;

            if (Convert.ToInt32(ddlSalary.SelectedValue) < 1)
            {
                txtSalaryLowerBand.Text = "";
                txtSalaryUpperBand.Text = "";
            }

            txtSalaryLowerBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMinimum"));
            txtSalaryUpperBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMaximum"));

            /*
            for (int i = 0; i < ddlSalary.Items.Count; i++)
            {
                ddlSalary.Items[i].Attributes.Add("placeholdertag",
                                            (ddlSalary.Items[i].Value != ((int)PortalEnums.Search.SalaryType.Hourly).ToString() ?
                                                    CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryAnnualTo") :
                                                    CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyFrom") + ";" + CommonFunction.GetResourceValue("PlaceHolderSalaryHourlyTo")));
            }*/
        }

        /*
        private void LoadSalaryFrom(int salarytypeid)
        {
            ddlSalaryFrom.Items.Clear();

            VList<ViewSalary> salaryFromList = ViewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salarytypeid);
            foreach (ViewSalary vs in salaryFromList)
            {
                ListItem li = new ListItem();
                li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
                li.Text = vs.SalaryDisplay;

                ddlSalaryFrom.Items.Add(li);
            }
        }
        private void LoadSalaryTo(int salarytypeid, int currecnyid, decimal amount)
        {
            ddlSalaryTo.Items.Clear();

            VList<ViewSalary> salaryToList = ViewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currecnyid, salarytypeid, amount);
            foreach (ViewSalary vs in salaryToList)
            {
                ListItem li = new ListItem();
                li.Value = string.Format("{0};{1}", vs.CurrencyId, vs.Amount);
                li.Text = vs.SalaryDisplay;

                ddlSalaryTo.Items.Add(li);
            }
        }*/


        private void LoadLocation()
        {
            ddlLocation.Items.Clear();

            SiteCountriesService siteCountriesService = new SiteCountriesService();
            SiteLocationService siteLocationService = new SiteLocationService();
            List<Entities.SiteCountries> siteCountriesList = siteCountriesService.GetTranslatedCountries();

            ddlLocation.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelAllLocation"), "0"));


            foreach (Entities.SiteCountries siteCountries in siteCountriesList)
            {
                ddlLocation.AddItemGroup(siteCountries.SiteCountryName);

                List<Entities.SiteLocation> filteredList = siteLocationService.GetTranslatedLocationsByCountryID(siteCountries.CountryId);

                foreach (Entities.SiteLocation siteLocation in filteredList)
                {

                    ddlLocation.Items.Add(new ListItem(siteLocation.SiteLocationName, siteLocation.LocationId.ToString()));
                    ddlLocation.Items[ddlLocation.Items.Count - 1].Attributes.Add("data-placeholdertag", siteCountries.Currency);

                }
            }
        }

        private void LoadArea()
        {
            if (ddlLocation.SelectedItem != null && ddlLocation.SelectedValue != "0")
            {
                lstBoxArea.DataSource = SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue));
                lstBoxArea.DataTextField = "SiteAreaName";
                lstBoxArea.DataValueField = "AreaId";
                lstBoxArea.DataBind();


                // Salary Currency
                using (Entities.Location location = LocationService.GetByLocationId(Convert.ToInt32(ddlLocation.SelectedValue)))
                {
                    if (location != null)
                    {
                        using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, location.CountryId))
                        {

                            if (siteCountry != null)
                            {
                                ltlLowerCurrency.Text = siteCountry.Currency;
                                ltlUpperCurrency.Text = siteCountry.Currency;
                            }
                        }
                    }
                }

                // Enable salary 
                SetSalary();
            }
            else
            {
                lstBoxArea.Items.Clear();
                lstBoxArea.DataSource = null;
                lstBoxArea.DataBind();

                // ToDo - Please choose Location
                lstBoxArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectLocationFirst"), "0"));


                // Disable salary 
                SetSalary();
            }

        }

        private void LoadProfession()
        {
            ddlProfession.DataSource = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.UseCustomProfessionRole);
            ddlProfession.DataTextField = "SiteProfessionName";
            ddlProfession.DataValueField = "ProfessionId";
            ddlProfession.DataBind();
            ddlProfession.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllClassifications"), "0"));
        }

        private void LoadRoles(string ProfessionId)
        {
            if (!string.IsNullOrWhiteSpace(ProfessionId))
            {
                ddlRole.DataSource = SiteRolesService.GetTranslatedByProfessionID(Convert.ToInt32(ProfessionId), SessionData.Site.UseCustomProfessionRole);
                ddlRole.DataTextField = "SiteRoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllSubClassifications"), "0"));
            }
            else
            {
                ddlRole.DataSource = null;
                ddlRole.DataBind();

                // Please choose Classification
                ddlRole.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectClassificationFirst"), "0"));
            }
        }

        #endregion


    }
}