using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.Text;
using System.Collections;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucJobSearchFilter : System.Web.UI.UserControl
    {
        #region Declarations

        // Todo - translate remove
        String strRemove = CommonFunction.GetResourceValue("LabelRemove");

        #endregion

        #region Properties


        private SiteCountriesService _siteCountriesService;
        private LocationService _LocationService;
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

        private SiteProfessionService _siteProfessionService;
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

        private SiteRolesService _siteRolesService;
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

        private SiteLocationService _siteLocationService;
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

        private SiteAreaService _siteAreaService;
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

        private SiteWorkTypeService _siteWorkTypeService;
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

        private SiteSalaryTypeService _salaryTypeService;
        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_salaryTypeService == null)
                {
                    _salaryTypeService = new SiteSalaryTypeService();
                }
                return _salaryTypeService;
            }
        }

        private ViewJobSearchService _viewJobSearchService = null;
        protected ViewJobSearchService ViewJobSearchService
        {

            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }

        private string _campaignName = string.Empty;
        public string CampaignName
        {
            set
            {
                _campaignName = value;
            }
            get
            {
                return _campaignName;
            }
        }
        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("SomeText");


            if (!Page.IsPostBack)
            {

                using (TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (sitecountries != null)
                    {
                        ViewState["SiteCountriesCount"] = sitecountries.Count;

                        if (sitecountries.Count == 1)
                        {
                            Entities.SiteCountries siteCountry = sitecountries[0];
                            ltlLowerCurrency.Text = siteCountry.Currency;
                            ltlUpperCurrency.Text = siteCountry.Currency;
                            hfCurrency.Value = siteCountry.Currency;
                        }
                    }
                    else
                    {
                        ViewState["SiteCountriesCount"] = 0;
                    }
                }
                DoFilter();
            }
        }

        #endregion

        #region Methods

        protected void DoFilter()
        {
            SetNames();
            LoadSalary();

            int count = 0;
            string kw = string.Empty;

            // Check the keywords or if there is a campaign
            if (!string.IsNullOrEmpty(SessionData.JobSearch.Keywords) || !String.IsNullOrEmpty(Request.QueryString["campaign"]))
            {


                if (!String.IsNullOrEmpty(Request.QueryString["campaign"]))
                {
                    DynamicPagesService DynamicPagesService = new JXTPortal.DynamicPagesService();

                    JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Language.LanguageId, Request.QueryString["campaign"]);
                    if (dynamicPage != null && dynamicPage.Valid)
                    {
                        CampaignName = dynamicPage.PageTitle; // Page title has the campaign keywords
                    }
                }

                // Change the language which comes from session.
                EasyFts fts = new EasyFts();
                if (!String.IsNullOrEmpty(CampaignName))
                    kw = fts.ToFtsQuery(CampaignName);
                if (!String.IsNullOrEmpty(SessionData.JobSearch.Keywords))
                    kw = fts.ToFtsQuery(SessionData.JobSearch.Keywords);

            }

            using (DataSet dsJobSearch = ViewJobSearchService.GetBySearchFilterRedefine(
                                                    kw,
                                                    SessionData.Site.SiteId, SessionData.JobSearch.AdvertiserID,
                                                    SessionData.JobSearch.CurrencyID, SessionData.JobSearch.SalaryLowerBand, SessionData.JobSearch.SalaryUpperBand,
                                                    SessionData.JobSearch.SalaryTypeID,
                                                    SessionData.JobSearch.WorkTypeID,
                                                    !string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID) ? Convert.ToInt32(SessionData.JobSearch.ProfessionID) : (int?)null,
                                                    SessionData.JobSearch.RoleIDs,
                                                    SessionData.JobSearch.CountryID, !string.IsNullOrWhiteSpace(SessionData.JobSearch.LocationID) ? Convert.ToInt32(SessionData.JobSearch.LocationID) : (int?)null,
                                                    SessionData.JobSearch.AreaIDs,
                                                    SessionData.JobSearch.DateFrom,
                                                    SessionData.Language.LanguageId))
            {

                DataTable dtJobSearch = dsJobSearch.Tables[0];

                rptClassification.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Classification), "RefineLabel");
                rptClassification.DataBind();

                rptSubClassification.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.SubClassification), "RefineLabel");
                rptSubClassification.DataBind();

                rptCountry.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Country), "RefineLabel");
                rptCountry.DataBind();

                rptLocation.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Location), "RefineLabel");
                rptLocation.DataBind();

                rptArea.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Area), "RefineLabel");
                rptArea.DataBind();

                rptWorkType.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.WorkType), "RefineLabel");
                rptWorkType.DataBind();

                //rptSalary.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Salary));
                //rptSalary.DataBind();

                rptCompany.DataSource = dtJobSearch.Select(String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Company), "RefineLabel");
                rptCompany.DataBind();

                if (dtJobSearch.Rows.Count > 0)
                {
                    if (int.TryParse(SessionData.JobSearch.RoleIDs, out count))
                    {
                        // Subclassification Count the Records
                        count = 0;
                        foreach (DataRow dr in dtJobSearch.Rows)
                        {
                            if (Convert.ToInt32(dr["RefineTypeID"]) == (int)PortalEnums.Search.Redefine.SubClassification && dr["RefineID"].ToString() == SessionData.JobSearch.RoleIDs)
                            {
                                count = Convert.ToInt32(dr["RefineCount"]);
                            }
                        }
                    }
                    else
                    {
                        //if (SessionData.JobSearch.ProfessionID.HasValue)
                        //{
                        // Classification Count the Records
                        count = int.Parse(dtJobSearch.Compute("Sum(RefineCount)", String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.Classification)).ToString());
                        //}
                    }
                }
                else
                    count = 0; // no jobs

                // Set what was search for
                SetSearchedFor(ref dtJobSearch);

                dtJobSearch.Dispose();
            }

            ContentPlaceHolder contentPlaceHolderLeftNav =
                (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolder1");
            if (contentPlaceHolderLeftNav != null)
            {
                ucSearchResults ucSearchResultsControl = (ucSearchResults)contentPlaceHolderLeftNav.FindControl("ucSearchResults1");

                // Do the results
                if (ucSearchResultsControl != null)
                {
                    // Set the Result Count - For Paging
                    ucSearchResultsControl.SearchResultCount = count;

                    // Do Search
                    ucSearchResultsControl.DoSearch();

                }
            }

        }

        private void SetNames()
        {
            // Todo - Translation
            ltlClassification.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelClassification"));
            ltlSubClassification.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelSubClassification"));
            ltlCountry.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelCountry"));
            ltlLocation.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelLocation"));
            ltlArea.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelArea"));
            ltlWorkType.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelWorkType"));
            ltlSalary.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelSalary"));
            ltlCompany.Text = String.Format("<a href='#'>{0}</a>", CommonFunction.GetResourceValue("LabelCompany"));
            btnSalaryRefine.Text = CommonFunction.GetResourceValue("ButtonSubmit");
            /*ltlSalaryTags.Text = string.Format(@"<ul><li id='liAnnualTab' {2}><a href='javascript:void(0)' id='salaryAnnualTab'>{0}</a></li>
                                                        <li id='liHourlyTab' {3}><a href='javascript:void(0)' id='salaryHourlyTab'>{1}</a></li></ul>",
                                                    CommonFunction.GetResourceValue("LabelSalaryAnnual"),
                                                    CommonFunction.GetResourceValue("LabelSalaryHourly"),
                                                    (SessionData.JobSearch.SalaryTypeID.HasValue && SessionData.JobSearch.SalaryTypeID.Value == (int)PortalEnums.Search.SalaryType.Annual ? "class='active'" : string.Empty),
                                                    (SessionData.JobSearch.SalaryTypeID.HasValue && SessionData.JobSearch.SalaryTypeID.Value == (int)PortalEnums.Search.SalaryType.Hourly ? "class='active'" : string.Empty)

                                                    );*/

            txtSalaryLowerBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMinimum"));
            txtSalaryUpperBand.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelMaximum"));
        }

        private void LoadSalary()
        {

            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            ddlSalary.Items.Clear();

            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {
                ddlSalary.Items.Add(new ListItem(sitesalarytype.SalaryTypeName, sitesalarytype.SalaryTypeId.ToString()));
            }

            ddlSalary.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));

        }
        #endregion

        #region Event Handlers

        protected void rptJobResultFilter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRow dataRow = (DataRow)e.Item.DataItem;

                LinkButton lbLink = (LinkButton)e.Item.FindControl("lbLink");
                lbLink.CommandName = dataRow[0].ToString();
                lbLink.CommandArgument = dataRow[2].ToString();
                lbLink.Text = String.Format("{0} <span class=\"filter-tally\">({1})</span>", dataRow[3].ToString(), dataRow[4].ToString());
            }

        }

        protected void rptJobResultFilter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "0":
                    SessionData.JobSearch.ProfessionID = e.CommandArgument.ToString();
                    break;
                case "1":
                    SessionData.JobSearch.RoleIDs = e.CommandArgument.ToString();
                    break;
                case "2":
                    SessionData.JobSearch.LocationID = e.CommandArgument.ToString();
                    break;
                case "3":
                    SessionData.JobSearch.AreaIDs = e.CommandArgument.ToString();
                    break;
                case "4":
                    SessionData.JobSearch.WorkTypeID = int.Parse(e.CommandArgument.ToString());
                    break;
                case "5":
                    SessionData.JobSearch.AdvertiserID = int.Parse(e.CommandArgument.ToString());
                    break;
                case "6":
                    SessionData.JobSearch.CurrencyID = int.Parse(e.CommandArgument.ToString());
                    break;
                case "7":
                    SessionData.JobSearch.CountryID = int.Parse(e.CommandArgument.ToString());
                    break;
                default:
                    break;
            }

            // Reset the Page Index
            SessionData.JobSearch.PageIndex = 0;

            // Get the New Filter
            DoFilter();

        }

        #endregion

        #region Search For Methods

        protected void SetSearchedFor(ref DataTable dtJobSearch)
        {
            DataRow[] dr = null;
            ArrayList values = new ArrayList();

            if (!String.IsNullOrEmpty(SessionData.JobSearch.Keywords.Trim()))
            {
                values.Add(new SearchForClass("-1", "-1", SessionData.JobSearch.Keywords.Trim(),
                                                        CommonFunction.GetResourceValue("Keywords")));

            }

            // Classification
            if (!string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID))
            {
                dr = dtJobSearch.Select("RefineTypeID = 0 and RefineID = " + SessionData.JobSearch.ProfessionID);
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("0", SessionData.JobSearch.ProfessionID,
                                                    dr[0]["RefineLabel"].ToString(), CommonFunction.GetResourceValue("Classification")));

                    ltlClassification.Visible = false;
                    rptClassification.Visible = false;
                    ltlSubClassification.Visible = true;
                    rptSubClassification.Visible = true;
                }
                else
                {
                    using (Entities.SiteProfession siteprofessions = SiteProfessionService.GetTranslatedProfessionById(Convert.ToInt32(SessionData.JobSearch.ProfessionID), SessionData.Site.UseCustomProfessionRole))
                    {
                        if (siteprofessions != null)
                        {
                            values.Add(new SearchForClass("0", SessionData.JobSearch.ProfessionID,
                                                        siteprofessions.SiteProfessionName, CommonFunction.GetResourceValue("Classification")));
                        }
                    }
                }
            }
            else
            {
                ltlClassification.Visible = true;
                rptClassification.Visible = true;
                // When Classification is not selcted then hide Sub Classification
                ltlSubClassification.Visible = false;
                rptSubClassification.Visible = false;
            }

            // SubClassification
            if (!String.IsNullOrEmpty(SessionData.JobSearch.RoleIDs))
            {
                dr = dtJobSearch.Select("RefineTypeID = 1 and RefineID in (" + SessionData.JobSearch.RoleIDs + ")");
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("1", SessionData.JobSearch.RoleIDs,
                                                    dr[0]["RefineLabel"].ToString(), CommonFunction.GetResourceValue("Sub Classification")));
                    ltlSubClassification.Visible = false;
                    rptSubClassification.Visible = false;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(SessionData.JobSearch.ProfessionID))
                    {
                        using (Entities.SiteRoles siteroles = SiteRolesService.GetTranslatedRolesById(Convert.ToInt32(SessionData.JobSearch.RoleIDs), Convert.ToInt32(SessionData.JobSearch.ProfessionID), SessionData.Site.UseCustomProfessionRole))
                        {
                            if (siteroles != null)
                            {
                                values.Add(new SearchForClass("1", SessionData.JobSearch.RoleIDs,
                                                            siteroles.SiteRoleName, CommonFunction.GetResourceValue("Sub Classification")));
                            }
                        }
                    }
                }
            }

            
            // Location

            if (!String.IsNullOrEmpty(SessionData.JobSearch.LocationID))
            {
                using (Entities.Location location = LocationService.GetByLocationId(Convert.ToInt32(SessionData.JobSearch.LocationID)))
                {
                    dr = dtJobSearch.Select("RefineTypeID = 2 and RefineID = " + SessionData.JobSearch.LocationID);

                    using (Entities.SiteLocation sitelocation = SiteLocationService.GetTranslatedLocation(Convert.ToInt32(SessionData.JobSearch.LocationID), location.CountryId))
                    {
                        if (sitelocation != null)
                        {
                            values.Add(new SearchForClass("2", SessionData.JobSearch.LocationID,
                                                   sitelocation.SiteLocationName, CommonFunction.GetResourceValue("Location")));
                        }
                    }

                    if (dr.Length > 0)
                    {
                        ltlArea.Visible = true;
                        rptArea.Visible = true;

                        // Only when there is a location then display
                        plHolderSalary.Visible = true;

                        // Salary Currency
                        if (location != null)
                        {
                            using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, location.CountryId))
                            {

                                if (siteCountry != null)
                                {
                                    ltlLowerCurrency.Text = siteCountry.Currency;
                                    ltlUpperCurrency.Text = siteCountry.Currency;
                                    hfCurrency.Value = siteCountry.Currency;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ltlLocation.Visible = true;
                rptLocation.Visible = true;

                // When Classification is not selcted then hide Area
                ltlArea.Visible = false;
                rptArea.Visible = false;


                plHolderSalary.Visible = (Convert.ToInt32(ViewState["SiteCountriesCount"]) == 1);

            }

            // Country

            if (SessionData.JobSearch.CountryID.HasValue)
            {
                dr = dtJobSearch.Select("RefineTypeID = 7 and RefineID = " + SessionData.JobSearch.CountryID);

                using (Entities.SiteCountries siteCountry = SiteCountriesService.GetTranslatedCountries().Where(c => c.CountryId == SessionData.JobSearch.CountryID).FirstOrDefault())
                {
                    if (siteCountry != null)
                    {
                        values.Add(new SearchForClass("7", SessionData.JobSearch.CountryID.ToString(),
                                               siteCountry.SiteCountryName, CommonFunction.GetResourceValue("LabelCountry")));
                    }
                }

                if (dr.Length > 0)
                {
                    plHolderSalary.Visible = true;

                    ltlCountry.Visible = false;
                    rptCountry.Visible = false;

                    // Salary Currency

                    using (Entities.SiteCountries siteCountry = SiteCountriesService.GetBySiteIdCountryId(SessionData.Site.SiteId, SessionData.JobSearch.CountryID.Value))
                    {

                        if (siteCountry != null)
                        {
                            ltlLowerCurrency.Text = siteCountry.Currency;
                            ltlUpperCurrency.Text = siteCountry.Currency;
                            hfCurrency.Value = siteCountry.Currency;
                        }
                    }

                }

            }
            else
            {
                ltlCountry.Visible = true;
                rptCountry.Visible = true;

                plHolderSalary.Visible = (Convert.ToInt32(ViewState["SiteCountriesCount"]) == 1);
            }


            // Area
            if (!String.IsNullOrEmpty(SessionData.JobSearch.AreaIDs))
            {
                dr = dtJobSearch.Select("RefineTypeID = 3 and RefineID in (" + SessionData.JobSearch.AreaIDs + ")");
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("3", SessionData.JobSearch.AreaIDs, dr[0]["RefineLabel"].ToString(),
                                                        CommonFunction.GetResourceValue("Area")));
                    ltlArea.Visible = false;
                    rptArea.Visible = false;
                }
                else
                {
                    if (!String.IsNullOrEmpty(SessionData.JobSearch.LocationID))
                    {
                        using (Entities.SiteArea sitearea = SiteAreaService.GetTranslatedArea(Convert.ToInt32(SessionData.JobSearch.AreaIDs), Convert.ToInt32(SessionData.JobSearch.LocationID), SessionData.Site.SiteId))
                        {
                            if (sitearea != null)
                            {
                                values.Add(new SearchForClass("3", SessionData.JobSearch.AreaIDs, sitearea.SiteAreaName,
                                                                    CommonFunction.GetResourceValue("Area")));
                            }
                        }
                    }
                }
            }

            // Work Type
            if (SessionData.JobSearch.WorkTypeID.HasValue && SessionData.JobSearch.WorkTypeID.Value > 0)
            {
                dr = dtJobSearch.Select("RefineTypeID = 4 and RefineID = " + SessionData.JobSearch.WorkTypeID.Value);
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("4", SessionData.JobSearch.WorkTypeID.Value.ToString(), dr[0]["RefineLabel"].ToString(),
                                                        CommonFunction.GetResourceValue("Work Type")));
                    ltlWorkType.Visible = false;
                    rptWorkType.Visible = false;
                }
                else
                {
                    using (Entities.SiteWorkType siteworktype = SiteWorkTypeService.GetTranslatedWorkTypesById(SessionData.JobSearch.WorkTypeID.Value))
                    {
                        if (siteworktype != null)
                        {
                            values.Add(new SearchForClass("4", SessionData.JobSearch.WorkTypeID.Value.ToString(), siteworktype.SiteWorkTypeName,
                                                            CommonFunction.GetResourceValue("Work Type")));
                        }
                    }
                }
            }
            else
            {
                ltlWorkType.Visible = true;
                rptWorkType.Visible = true;
            }

            // Salary
            //if (SessionData.JobSearch.CurrencyID.HasValue && SessionData.JobSearch.CurrencyID.Value > 0)
            if (SessionData.JobSearch.SalaryTypeID.HasValue)
            {
                /*dr = dtJobSearch.Select("RefineTypeID = 6 and RefineID = " + SessionData.JobSearch.CurrencyID.Value);
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("6", SessionData.JobSearch.CurrencyID.Value.ToString(), dr[0]["RefineLabel"].ToString(),
                                                            CommonFunction.GetResourceValue("Salary")));
                    ltlSalary.Visible = false;
                    //rptSalary.Visible = false;
                }*/

                plHolderSalary.Visible = false;
                string salarytype = string.Empty;

                if (SessionData.JobSearch.SalaryTypeID.HasValue)
                {
                    using (Entities.SiteSalaryType siteSalaryType = SiteSalaryTypeService.Get_TranslatedSalaryType(SessionData.Site.SiteId, SessionData.JobSearch.SalaryTypeID.Value))
                    {
                        if (siteSalaryType != null)
                        {
                            salarytype = siteSalaryType.SalaryTypeName;
                        }
                    }
                }

                values.Add(new SearchForClass("6", "",
                                                salarytype +
                                                ((SessionData.JobSearch.SalaryLowerBand.HasValue || SessionData.JobSearch.SalaryUpperBand.HasValue) ? (" - " +
                                                (SessionData.JobSearch.SalaryUpperBand.HasValue ? string.Empty : CommonFunction.GetResourceValue("LabelFrom") + " ") +
                                                hfCurrency.Value + (SessionData.JobSearch.SalaryLowerBand.HasValue ? SessionData.JobSearch.SalaryLowerBand.Value.ToString() : "0") +
                                                (SessionData.JobSearch.SalaryUpperBand.HasValue ? " - " : string.Empty) +
                                                (SessionData.JobSearch.SalaryUpperBand.HasValue ? hfCurrency.Value + SessionData.JobSearch.SalaryUpperBand.Value.ToString() : "")) : string.Empty),
                                                "Salary"
                                                ));
            }
            else
            {
                //plHolderSalary.Visible = true;
                //rptSalary.Visible = true;
            }

            // Hide if they are no results
            if (dtJobSearch.Rows.Count < 1)
                plHolderSalary.Visible = false;

            // Company - Advertiser Id
            if (SessionData.JobSearch.AdvertiserID.HasValue && SessionData.JobSearch.AdvertiserID.Value > 0)
            {
                dr = dtJobSearch.Select("RefineTypeID = 5 and RefineID = " + SessionData.JobSearch.AdvertiserID.Value);
                if (dr.Length > 0)
                {
                    values.Add(new SearchForClass("5", SessionData.JobSearch.AdvertiserID.Value.ToString(), dr[0]["RefineLabel"].ToString(),
                                                        CommonFunction.GetResourceValue("Company")));
                    ltlCompany.Visible = false;
                    rptCompany.Visible = false;
                }
            }
            else
            {
                ltlCompany.Visible = true;
                rptCompany.Visible = true;
            }

            hfSearchFor.Value = string.Empty;
            rptSearchFor.DataSource = values;
            rptSearchFor.DataBind();

            //ToDo - Translation
            ltlSearchedFor.Text = String.Format("<div class='side-left-header'>{0}:</div>", CommonFunction.GetResourceValue("LabelRefineResults"));

            // Show the Filter only when atleast one of them is selected
            if (rptSearchFor.Items.Count < 1)
                rptSearchFor.Visible = false;
            else
                rptSearchFor.Visible = true;


        }


        protected void rptSearchFor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "-1":
                    {
                        // Remove Keywords
                        SessionData.JobSearch.Keywords = string.Empty;
                    }
                    break;
                case "0":
                    {
                        // Remove Profession
                        SessionData.JobSearch.ProfessionID = null;
                        SessionData.JobSearch.RoleIDs = string.Empty;
                    }
                    break;
                case "1":
                    {
                        // Remove Roles
                        SessionData.JobSearch.RoleIDs = string.Empty;
                    }
                    break;
                case "2":
                    {
                        // Remove Location
                        SessionData.JobSearch.LocationID = null;
                        SessionData.JobSearch.AreaIDs = string.Empty;
                    }
                    break;
                case "3":
                    {
                        // Remove Area
                        SessionData.JobSearch.AreaIDs = string.Empty;
                    }
                    break;
                case "4":
                    {
                        // Remove Work type
                        SessionData.JobSearch.WorkTypeID = null;
                    }
                    break;
                case "5":
                    {
                        // Remove Advertiser
                        SessionData.JobSearch.AdvertiserID = null;
                    }
                    break;
                case "6":
                    {
                        // Remove Salary
                        SessionData.JobSearch.CurrencyID = null;
                        SessionData.JobSearch.SalaryTypeID = null;
                        SessionData.JobSearch.SalaryUpperBand = null;
                        SessionData.JobSearch.SalaryLowerBand = null;
                    }
                    break;
                case "7":
                    {
                        // Remove Roles
                        SessionData.JobSearch.CountryID = null;
                    }
                    break;

                default:
                    break;
            }

            // Get the New Filter
            DoFilter();
        }

        protected void rptSearchFor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlText = (Literal)e.Item.FindControl("ltlText");
                Literal ltlTitle = (Literal)e.Item.FindControl("ltlTitle");
                LinkButton lbtnSearchFor = (LinkButton)e.Item.FindControl("lbtnSearchFor");
                SearchForClass searchForClass = (SearchForClass)e.Item.DataItem;

                lbtnSearchFor.CommandArgument = searchForClass.RefineID;
                lbtnSearchFor.CommandName = searchForClass.RefineTypeId;

                ltlText.Text = Server.HtmlEncode(searchForClass.RefineLabel);

                string tmplabel = searchForClass.Heading.ToString();
                if (tmplabel == "Classification")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelClassification");
                if (tmplabel == "Location")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelLocation");
                if (tmplabel == "Work Type")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelWorkType");
                if (tmplabel == "Area")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelArea");
                if (tmplabel == "Salary")
                {
                    if (SessionData.JobSearch.SalaryTypeID.HasValue)
                    {
                        using (Entities.SiteSalaryType siteSalaryType = SiteSalaryTypeService.Get_TranslatedSalaryType(SessionData.Site.SiteId, SessionData.JobSearch.SalaryTypeID.Value))
                        {
                            if (siteSalaryType != null)
                            {
                                ltlTitle.Text = siteSalaryType.SalaryTypeName + " " + CommonFunction.GetResourceValue("LabelSalary");
                            }
                        }

                        /*
                        if (SessionData.JobSearch.SalaryTypeID.Value == (int)PortalEnums.Search.SalaryType.Annual)
                            ltlTitle.Text = CommonFunction.GetResourceValue("LabelSalaryAnnual") + " " + CommonFunction.GetResourceValue("LabelSalary");

                        if (SessionData.JobSearch.SalaryTypeID.Value == (int)PortalEnums.Search.SalaryType.Hourly)
                            ltlTitle.Text = CommonFunction.GetResourceValue("LabelSalaryHourly") + " " + CommonFunction.GetResourceValue("LabelSalary");*/
                    }
                    else if (SessionData.JobSearch.SalaryLowerBand.HasValue || SessionData.JobSearch.SalaryUpperBand.HasValue)
                    {
                        ltlTitle.Text = CommonFunction.GetResourceValue("LabelSalaryAnnual") + " " + CommonFunction.GetResourceValue("LabelSalary");
                    }
                }
                if (tmplabel == "Company")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelCompany");
                if (tmplabel == "Sub Classification")
                    ltlTitle.Text = CommonFunction.GetResourceValue("LabelSubClassification");

                //ltlTitle.Text = searchForClass.Heading;

                lbtnSearchFor.Text = strRemove;

                //Assign Value to Hidden Field hfSearchFor for Favourite and Alert
                if (string.IsNullOrEmpty(searchForClass.RefineID))
                {
                    hfSearchFor.Value += string.Format("{0}^{1}^{2}|", searchForClass.RefineTypeId, SessionData.JobSearch.SalaryTypeID, searchForClass.RefineLabel); // Refine Type
                }
                else
                {
                    hfSearchFor.Value += string.Format("{0}^{1}^{2}|", searchForClass.RefineTypeId, searchForClass.RefineID, searchForClass.RefineLabel); // Refine Type
                }
            }

        }

        #endregion

        #region Search For Class

        public class SearchForClass
        {
            private string refineTypeId, refineID, refineLabel, heading;

            public SearchForClass(string refineTypeId, string refineID, string refineLabel, string heading)
            {
                this.refineTypeId = refineTypeId;
                this.refineID = refineID;
                this.refineLabel = refineLabel;
                this.heading = heading;
            }

            public string RefineTypeId
            {
                get
                {
                    return refineTypeId;
                }
            }

            public string RefineID
            {
                get
                {
                    return refineID;
                }
            }

            public string RefineLabel
            {
                get
                {
                    return refineLabel;
                }
            }

            public string Heading
            {
                get
                {
                    return heading;
                }
            }
        }

        #endregion

        // Search Filter for Salary.
        protected void btnSalaryRefine_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(ddlSalary.SelectedValue) > 0)
                SessionData.JobSearch.SalaryTypeID = Convert.ToInt32(ddlSalary.SelectedValue);
            else
                SessionData.JobSearch.SalaryTypeID = (int)PortalEnums.Search.SalaryType.Annual; // By default if not selected then its annual

            SessionData.JobSearch.SalaryLowerBand = CommonFunction.GetSalaryDecimalAmount(txtSalaryLowerBand.Text);
            SessionData.JobSearch.SalaryUpperBand = CommonFunction.GetSalaryDecimalAmount(txtSalaryUpperBand.Text);


            // Get the New Filter
            DoFilter();
        }


    }
}