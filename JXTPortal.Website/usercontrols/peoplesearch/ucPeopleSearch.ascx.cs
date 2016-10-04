using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.peoplesearch
{
    public partial class ucPeopleSearch : System.Web.UI.UserControl
    {
        #region Declarations

        private SiteProfessionService _siteProfessionService;
        private SiteRolesService _siteRolesService;
        private SiteCountriesService _siteCountriesService;
        private CountriesService _countriesService;
        private GlobalLocationService _globalLocationService;
        private GlobalAreaService _globalAreaService;
        private LocationService _locationService;
        private AreaService _areaService;
        private AvailableStatusService _availableStatusService;
        private MembersService _memberService;
        private SiteSalaryTypeService _siteSalaryTypeService;
        private int SelectedCurrencyId = 0;
        
        #endregion

        #region Properties

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null) _siteProfessionService = new SiteProfessionService();
                return _siteProfessionService;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null) _siteRolesService = new SiteRolesService();
                return _siteRolesService;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null) _siteCountriesService = new SiteCountriesService();
                return _siteCountriesService;
            }
        }

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null) _countriesService = new CountriesService();
                return _countriesService;
            }
        }     

        private LocationService LocationService
        {
            get
            {
                if (_locationService == null) _locationService = new LocationService();
                return _locationService;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null) _areaService = new AreaService();
                return _areaService;
            }
        }

        private AvailableStatusService AvailableStatusService
        {
            get
            {
                if (_availableStatusService == null) _availableStatusService = new AvailableStatusService();
                return _availableStatusService;
            }
        }

        private MembersService MembersService
        {
            get
            {
                if (_memberService == null) _memberService = new MembersService();
                return _memberService;
            }
        }

        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_siteSalaryTypeService == null)
                {
                    _siteSalaryTypeService = new SiteSalaryTypeService();
                }
                return _siteSalaryTypeService;
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }

        }


        private int TotalPageCount
        {
            get;
            set;
        }
        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadClassification();
                LoadSubClassification();
                LoadCountry();
                LoadLocation();
                LoadArea();
                LoadSalary();
                LoadAvailability();
            }

            SetFormValues();

        }
        #endregion

        public void SetFormValues()
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSubmit");
            this.ddlCategory.Items[0].Text = CommonFunction.GetResourceValue("LabelAllClassifications");
            this.ddlCountry.Items[0].Text = CommonFunction.GetResourceValue("LabelSelectCountry");
            this.ddlLocation.Items[0].Text = CommonFunction.GetResourceValue("LabelAllLocation");
            this.ddlSalary.Items[0].Text = CommonFunction.GetResourceValue("LabelAllSalary");
            this.ddlAvailability.Items[0].Text = CommonFunction.GetResourceValue("LabelAllAvailability");
            //ddlSubCategory.Items[0].Text = CommonFunction.GetResourceValue("LabelSelectClassificationFirst");


        }


        #region Methods

        private void LoadClassification()
        {
            List<JXTPortal.Entities.SiteProfession> professions = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.UseCustomProfessionRole);

            ddlCategory.DataValueField = "ProfessionID";
            ddlCategory.DataTextField = "SiteProfessionName";
            ddlCategory.DataSource = professions;
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("- All Classifications -", "0"));
        }

        private void LoadSubClassification()
        {
            ddlSubCategory.Items.Clear();
            if (ddlCategory.SelectedValue != "0")
            {
                List<JXTPortal.Entities.SiteRoles> roles = SiteRolesService.GetTranslatedByProfessionID(Convert.ToInt32(ddlCategory.SelectedValue), SessionData.Site.UseCustomProfessionRole);

                ddlSubCategory.DataValueField = "RoleID";
                ddlSubCategory.DataTextField = "SiteRoleName";
                ddlSubCategory.DataSource = roles;
                ddlSubCategory.DataBind();

                //ddlSubCategory.Items.Insert(0, new ListItem("- All Sub Classifications -", "0"));
                ddlSubCategory.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllSubClassifications"), "0"));
                //ddlSubCategory.Items[0].Text = CommonFunction.GetResourceValue("LabelAllSubClassifications");
                
            }
            else
            {
                //ddlSubCategory.Items.Insert(0, new ListItem("- Select a Classification First -", "0"));
                ddlSubCategory.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectClassificationFirst"), "0"));
                //this.ddlSubCategory.Items[0].Text = CommonFunction.GetResourceValue("LabelSelectClassificationFirst");
            }
        }

        private void LoadCountry()
        {
            List<JXTPortal.Entities.Countries> countries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);
            
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataSource = countries;
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectCountry"), "0"));
        }

        private void LoadLocation()
        {
            ddlLocation.Items.Clear();

            List<JXTPortal.Entities.Location> locations = null;

            if (ddlCountry.SelectedValue != "0")
            {
                locations = LocationService.GetTranslatedLocations(SessionData.Language.LanguageId, Convert.ToInt32(ddlCountry.SelectedValue));
            }
            ddlLocation.DataValueField = "LocationID";
            ddlLocation.DataTextField = "LocationName";
            ddlLocation.DataSource = locations;
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllLocation"), "0"));

        }

        private void LoadArea()
        {
            ddlArea.Items.Clear();

            if (ddlLocation.SelectedValue != "0")
            {
                List<JXTPortal.Entities.Area> areas = AreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue), SessionData.Language.LanguageId);

                ddlArea.DataValueField = "AreaID";
                ddlArea.DataTextField = "AreaName";
                ddlArea.DataSource = areas;
                ddlArea.DataBind();

                ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllArea"), "0"));
                //this.ddlArea.Items[0].Text = CommonFunction.GetResourceValue("LabelAllArea");
            }
            else
            {
                ddlArea.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectLocationFirst"), "0"));
                //this.ddlArea.Items[0].Text = CommonFunction.GetResourceValue("LabelSelectLocationFirst");
            }
        }

        private void LoadSalary()
        {
            List<Entities.SiteSalaryType> salaryTypeList = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);

            ddlSalary.DataValueField = "SalaryTypeId";
            ddlSalary.DataTextField = "SalaryTypeName";
            ddlSalary.DataSource = salaryTypeList;
            ddlSalary.DataBind();

            ddlSalary.Items.Insert(0, new ListItem("- All Salary -", "0"));

        }

        private void LoadAvailability()
        {
            using (TList<JXTPortal.Entities.AvailableStatus> availabilities = AvailableStatusService.GetBySiteId(SessionData.Site.MasterSiteId))
            {
                ddlAvailability.DataValueField = "AvailableStatusID";
                ddlAvailability.DataTextField = "AvailableStatusName";
                ddlAvailability.DataSource = availabilities;
                ddlAvailability.DataBind();

                ddlAvailability.Items.Insert(0, new ListItem("- All Availability -", "0"));
            }
        }

        private void PeopleSearch()
        {
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            TotalPageCount = 0;
            pnlSearchResult.Visible = true;
            int prefCategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            int prefSubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedValue);
            int prefSalaryId = Convert.ToInt32(ddlSalary.SelectedValue);
            int prefAvailabilityId = Convert.ToInt32(ddlAvailability.SelectedValue);
            int countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            int locationId = Convert.ToInt32(ddlLocation.SelectedValue);
            int areaId = Convert.ToInt32(ddlArea.SelectedValue);

            DataSet ds = MembersService.PeopleSearch(SessionData.Site.MasterSiteId, prefCategoryId, prefSubCategoryId, prefSalaryId, (ddlSalaryLowerBand.Items.Count > 0) ? Convert.ToDecimal(ddlSalaryLowerBand.SelectedValue) : (decimal?)null, (ddlSalaryUpperBand.Items.Count > 0) ? Convert.ToDecimal(ddlSalaryUpperBand.SelectedValue) : (decimal?)null, prefAvailabilityId, 
                            countryId, locationId, areaId, tbKeyword.Text, "", CurrentPage, sitePageCount);
            if (ds.Tables.Count > 1)
            {
                int totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);

                if (totalCount > 0)
                {
                    litResultNumber.Text = totalCount.ToString();

                    if (totalCount % sitePageCount == 0)
                        TotalPageCount = totalCount / sitePageCount;
                    else
                        TotalPageCount = (totalCount / sitePageCount) + 1;

                    List<PagingClass> pagingClassList = new List<PagingClass>();
                    PagingClass pagingClass = null;
                    for (int i = 1; i <= TotalPageCount; i++)
                    {
                        pagingClass = new PagingClass();
                        pagingClass.PageNo = i.ToString();
                        if (CurrentPage == i)
                            pagingClass.Enabled = false;
                        else
                            pagingClass.Enabled = true;

                        pagingClassList.Add(pagingClass);
                    }

                    rptPaging.DataSource = pagingClassList;
                    rptPaging.DataBind();

                    rptPeopleSearchResults.DataSource = ds.Tables[0];
                    rptPeopleSearchResults.DataBind();

                    // If paging < 2
                    if (TotalPageCount < 2)
                        rptPaging.Visible = false;

                }
                else
                {
                    litResultNumber.Text = "0";
                    rptPaging.DataSource = null;
                    rptPaging.DataBind();

                    rptPeopleSearchResults.DataSource = null;
                    rptPeopleSearchResults.DataBind();
                }
            }

            
             
        }

        #endregion

        #region Events

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubClassification();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocation();
            LoadArea();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
        }


        protected void rptPeopleSearchResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litLocation = e.Item.FindControl("litLocation") as Literal;
                Literal litArea = e.Item.FindControl("litArea") as Literal;
                Literal litLastUpdate = e.Item.FindControl("litLastUpdate") as Literal;
                HyperLink hlName = e.Item.FindControl("hlName") as HyperLink;
                Literal litName = e.Item.FindControl("litName") as Literal;
                Literal litClassification = e.Item.FindControl("litClassification") as Literal;
                Literal litSubClassification = e.Item.FindControl("litSubClassification") as Literal;
                Literal litDesiredPay = e.Item.FindControl("litDesiredPay") as Literal;
                HyperLink hlViewProfile = e.Item.FindControl("hlViewProfile") as HyperLink;
                Literal ltViewProfile = e.Item.FindControl("ltViewProfile") as Literal;
                Image imgPhoto = e.Item.FindControl("imgPhoto") as Image;
                
                DataRowView drw = e.Item.DataItem as DataRowView;
                string locationname = "";
                if (!string.IsNullOrEmpty(drw["LocationID"].ToString()) && drw["LocationID"].ToString() != "0")
                {
                    JXTPortal.Entities.Location sl = LocationService.GetTranslatedLocation(Convert.ToInt32(drw["LocationID"]), SessionData.Language.LanguageId);
                    if (sl != null)
                    {
                        locationname = sl.LocationName;
                    }
                }

                string areaname = "";
                if (!string.IsNullOrEmpty(drw["AreaID"].ToString()) && drw["AreaID"].ToString() != "0")
                {
                    JXTPortal.Entities.Area sa =  AreaService.GetTranslatedArea(Convert.ToInt32(drw["AreaID"]), SessionData.Language.LanguageId);
                    if (sa != null)
                    {
                        areaname = sa.AreaName;
                    }
                }

                string category = "";
                if (!string.IsNullOrEmpty(drw["PreferredCategoryID"].ToString()) && drw["PreferredCategoryID"].ToString() != "0")
                {
                    JXTPortal.Entities.SiteProfession sp = SiteProfessionService.GetTranslatedProfessionById(Convert.ToInt32(drw["PreferredCategoryID"]), SessionData.Site.UseCustomProfessionRole);
                    if (sp != null)
                    {
                        category = sp.SiteProfessionName;
                    }
                }

                string subcategory = "";
                if (!string.IsNullOrEmpty(drw["PreferredSubCategoryID"].ToString()) && drw["PreferredSubCategoryID"].ToString() != "0")
                {
                    JXTPortal.Entities.SiteRoles sr = SiteRolesService.GetTranslatedRolesById(Convert.ToInt32(drw["PreferredSubCategoryID"]), Convert.ToInt32(drw["PreferredCategoryID"]), SessionData.Site.UseCustomProfessionRole);
                    if (sr != null)
                    {
                        subcategory = sr.SiteRoleName;
                    }
                }

                litLocation.Text = locationname;
                litArea.Text = areaname;
                litLastUpdate.Text = (string.IsNullOrEmpty(drw["LastModifiedDate"].ToString())) ? "" : ((DateTime)drw["LastModifiedDate"]).ToString(SessionData.Site.DateFormat);
                litName.Text = drw["FirstName"].ToString() + " " + drw["Surname"].ToString(); 
                litClassification.Text = category; 
                litSubClassification.Text = subcategory;
                litDesiredPay.Text = drw["PreferredSalary"].ToString();
                hlName.NavigateUrl = "~/members/" + drw["MemberID"].ToString() + "/";
                hlViewProfile.NavigateUrl = "~/members/" + drw["MemberID"].ToString() + "/";
            }
        }

        protected void rptPeopleSearchResults_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            PeopleSearch();
        }

        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("paging"))
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());

                // Search again
                PeopleSearch();
            }
        }

        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                LinkButton lnkButtonPaging = (LinkButton)e.Item.FindControl("lnkButtonPaging");

                lnkButtonPaging.CommandArgument = (Convert.ToInt32(pagingClass.PageNo) - 1).ToString();
                lnkButtonPaging.Text = pagingClass.PageNo.ToString();

                pagingClass.Enabled = (Convert.ToInt32(lnkButtonPaging.CommandArgument) != CurrentPage);

                if (!pagingClass.Enabled)
                {
                    lnkButtonPaging.CssClass = "disabled_tnt_pagination";
                    lnkButtonPaging.Enabled = false;
                }
                else
                {
                    lnkButtonPaging.CssClass = "tnt_pagination";
                    lnkButtonPaging.Enabled = true;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                LinkButton lnkButtonPrevious = (LinkButton)e.Item.FindControl("lnkButtonPrevious");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                if (CurrentPage <= 0)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination";
                    lnkButtonPrevious.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.CommandArgument = (CurrentPage - 1).ToString();
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                LinkButton lnkButtonNext = (LinkButton)e.Item.FindControl("lnkButtonNext");
                //Todo - Translation
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                if (CurrentPage >= TotalPageCount - 1)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination";
                    lnkButtonNext.Enabled = false;
                }
                else
                {
                    lnkButtonNext.CommandArgument = (CurrentPage + 1).ToString();
                }
            }
        }
        #endregion

        #region Paging Class

        private class PagingClass
        {
            public string PageNo { get; set; }
            public string PageUrl { get; set; }
            public bool Enabled { get; set; }
        }

        #endregion

        protected void ddlSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSalaryLowerBand.Items.Clear();
            ddlSalaryUpperBand.Items.Clear();

            VList<ViewSalary> salaryFromList = new VList<ViewSalary>();
            if (ddlSalary.SelectedValue != "0")
            {
                ViewSalaryService viewSalaryService = new ViewSalaryService();
                salaryFromList = viewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, Convert.ToInt32(ddlSalary.SelectedValue));
                
                ddlSalaryLowerBand.DataValueField = "Amount";
                ddlSalaryLowerBand.DataTextField = "SalaryDisplay";

                ddlSalaryLowerBand.DataSource = salaryFromList;
                ddlSalaryLowerBand.DataBind();

                if (ddlSalaryLowerBand.Items.Count > 0)
                {
                    VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, 0, Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToDecimal(ddlSalaryLowerBand.SelectedValue));
                    ddlSalaryUpperBand.DataValueField = "Amount";
                    ddlSalaryUpperBand.DataTextField = "SalaryDisplay";

                    ddlSalaryUpperBand.DataSource = salaryToList;
                    ddlSalaryUpperBand.DataBind();
                }
            }
        }

        protected void ddlSalaryLowerBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSalaryUpperBand.Items.Clear();

            if (ddlSalaryLowerBand.Items.Count > 0)
            {
                ViewSalaryService viewSalaryService = new ViewSalaryService();
                VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, 0, Convert.ToInt32(ddlSalary.SelectedValue), Convert.ToDecimal(ddlSalaryLowerBand.SelectedValue));
                ddlSalaryUpperBand.DataValueField = "Amount";
                ddlSalaryUpperBand.DataTextField = "SalaryDisplay";

                ddlSalaryUpperBand.DataSource = salaryToList;
                ddlSalaryUpperBand.DataBind();
            }
        }
    }
}