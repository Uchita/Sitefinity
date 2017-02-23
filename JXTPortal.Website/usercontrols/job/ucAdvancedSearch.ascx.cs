using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Text;
using System.Data;
using JXTPortal.Website.job.ajaxcalls;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucAdvancedSearch : System.Web.UI.UserControl
    {
        #region Declarations

        private const string _KEYWORDS = "{Keywords}";
        private const string _PROFESSIONS = "{Professions}";
        private const string _ROLES = "{Roles}";
        private const string _COUNTRY = "{Country}";
        private const string _LOCATION = "{Location}";
        private const string _LOCATIONAREA = "{LocationArea}";
        private const string _LOCATIONAREADROPDOWN = "{LocationAreaDropDown}";
        private const string _WORKTYPES = "{WorkTypes}";
        private const string _SALARY = "{Salary}";
        private const string _ADVERTISERS = "{Advertisers}";

        Entities.WidgetContainers widgetContainer = null;
        public String strJobHTML = String.Empty;

        #endregion

        #region Properties


        public bool IsAdvancedSearch { get; set; }

        public string IsDynamicWidget { get; set; }

        int _WidgetID = 0;
        public int WidgetID
        {
            get
            {
                if (_WidgetID > 0)
                    return _WidgetID;

                if (Request.QueryString["WidgetID"] != null && Int32.TryParse(Request.QueryString["WidgetID"], out _WidgetID))
                {
                    _WidgetID = Convert.ToInt32(Request.QueryString["WidgetID"]);
                }

                return _WidgetID;
            }
            set
            {

                _WidgetID = value;
            }
        }

        private WidgetContainersService _widgetContainersService;
        private WidgetContainersService WidgetContainersService
        {
            get
            {
                if (_widgetContainersService == null) _widgetContainersService = new WidgetContainersService();
                return _widgetContainersService;
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


        private SiteWorkTypeService _siteworktypeservice;
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

        private ViewSalaryService _viewSalaryService;
        private ViewSalaryService ViewSalaryService
        {
            get
            {
                if (_viewSalaryService == null)
                {
                    _viewSalaryService = new ViewSalaryService();
                }
                return _viewSalaryService;
            }
        }

        private SiteSalaryTypeService _siteSalaryTypeService;
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

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSearch();
            }
        }

        public string LoadSearch()
        {

            // Reset the page index to 0
            SessionData.JobSearch.PageIndex = 0;

            LoadAdvancedSearch();

            // Set the Control contents
            SetKeywords();
            SetProfessions();
            SetRoles();
            SetCountry();
            SetLocation();
            SetLocationArea();
            SetWorkTypes();
            SetAdvertisers();
            SetSalary();

            // Replaced html contents
            ltlJobSearch.Text = strJobHTML;

            return string.Format(@"
{0}
{1}
{2}", strJobHTML, ltlJavascript.Text, ltlCSS.Text);


        }

        #endregion

        #region Load Content

        protected void SetKeywords()
        {
            if (FindKeyword(_KEYWORDS))
            {
                strJobHTML = strJobHTML.Replace(_KEYWORDS, @"<input id='keywords" + IsDynamicWidget + "' type='text' class='form-textbox' placeholder='" + CommonFunction.GetResourceValue("LabelEnterKeywords").ToLower() + "' />");
            }
        }

        protected void SetProfessions()
        {
            if (FindKeyword(_PROFESSIONS))
            {
                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\">", "professionID" + IsDynamicWidget);
                List<Entities.SiteProfession> siteProfessionList = SiteProfessionService.GetTranslatedProfessions(false, SessionData.Site.UseCustomProfessionRole);
                //IEnumerable<Entities.SiteProfession> sps = siteProfessionList.Where(s => s.TotalJobs > 0);

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllClassifications") + "</option>");


                foreach (Entities.SiteProfession siteProfession in siteProfessionList)
                {
                    if (widgetContainer.DefaultProfessionId.HasValue &&
                            siteProfession.ProfessionId == widgetContainer.DefaultProfessionId.Value)
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteProfession.ProfessionId.ToString(), siteProfession.SiteProfessionName);

                        // Set the Roles with the default Profession ID
                        strJobHTML = strJobHTML.Replace(_ROLES, ajaxMethods.GetRoles(widgetContainer.DefaultProfessionId.Value.ToString(), IsDynamicWidget));

                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteProfession.ProfessionId.ToString(), siteProfession.SiteProfessionName);
                    }
                }
                strSelectHtml.Append("</select>");

                strJobHTML = strJobHTML.Replace(_PROFESSIONS, strSelectHtml.ToString());


            }
        }

        protected void SetRoles()
        {
            if (FindKeyword(_ROLES))
            {
                strJobHTML = strJobHTML.Replace(_ROLES, @"<div id='divRoleID" + IsDynamicWidget + "'><select class='form-dropdown' id='roleIDs" + IsDynamicWidget + @"'>
<option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectClassificationFirst") + "</option></select></div>");
            }
        }


        protected void SetCountry()
        {
            if (FindKeyword(_COUNTRY))
            {
                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\">", "countryID" + IsDynamicWidget);
                List<Entities.SiteCountries> siteCountriesList = SiteCountriesService.GetTranslatedCountries();

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllCountry") + "</option>");

                foreach (Entities.SiteCountries siteCountry in siteCountriesList)
                {
                    if (widgetContainer.DefaultCountryId.HasValue && siteCountry.CountryId == widgetContainer.DefaultCountryId.Value)
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteCountry.CountryId.ToString(), siteCountry.SiteCountryName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteCountry.CountryId.ToString(), siteCountry.SiteCountryName);
                    }
                }
                strSelectHtml.Append("</select>");

                strJobHTML = strJobHTML.Replace(_COUNTRY, strSelectHtml.ToString());
            }
        }

        protected void SetLocation()
        {
            if (FindKeyword(_LOCATION))
            {

                if (widgetContainer.DefaultLocationId.HasValue && widgetContainer.DefaultLocationId.Value > 0)
                {
                    strJobHTML = strJobHTML.Replace(_LOCATION, ajaxMethods.GetLocations(widgetContainer.DefaultLocationId.Value.ToString(), IsDynamicWidget, (widgetContainer.DefaultCountryId.HasValue) ? widgetContainer.DefaultCountryId.Value.ToString() : null));
                    if (FindKeyword(_LOCATIONAREA))
                    {
                        strJobHTML = strJobHTML.Replace(_LOCATIONAREA, ajaxMethods.GetAreas(widgetContainer.DefaultLocationId.Value.ToString(), IsDynamicWidget));
                    }
                    else
                    {
                        if (FindKeyword(_LOCATIONAREADROPDOWN))
                        {
                            strJobHTML = strJobHTML.Replace(_LOCATIONAREADROPDOWN, ajaxMethods.GetAreas(widgetContainer.DefaultLocationId.Value.ToString(), IsDynamicWidget));
                        }
                    }
                }
                else
                    strJobHTML = strJobHTML.Replace(_LOCATION, ajaxMethods.GetLocations(string.Empty, IsDynamicWidget, (widgetContainer.DefaultCountryId.HasValue) ? widgetContainer.DefaultCountryId.Value.ToString() : null));


            }
        }

        protected void SetLocationArea()
        {
            if (FindKeyword(_LOCATIONAREA))
            {
                strJobHTML = strJobHTML.Replace(_LOCATIONAREA, @"<div id='divArea" + IsDynamicWidget + "'><select class='form-dropdown' id='areaIDs" + IsDynamicWidget + "' multiple='multiple' size='4'><option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectLocationFirst") + "</option></select></div>");
            }
            else
            {
                if (FindKeyword(_LOCATIONAREADROPDOWN))
                {
                    strJobHTML = strJobHTML.Replace(_LOCATIONAREADROPDOWN, @"<div id='divAreaDropDown" + IsDynamicWidget + "'><select class='form-dropdown' id='areaIDs" + IsDynamicWidget + "'><option value='-1'>" + CommonFunction.GetResourceValue("LabelSelectLocationFirst") + "</option></select></div>");
                }
            }
        }

        protected void SetSalary()
        {
            if (FindKeyword(_SALARY))
            {
                StringBuilder strSelectHtml = new StringBuilder();

                List<Entities.SiteSalaryType> salaryTypeList = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
                int count = 0;
                strSelectHtml.AppendFormat("<div id='divSalaryType" + IsDynamicWidget + "'><select class='form-dropdown' id=\"{0}\">", "salaryID" + IsDynamicWidget);

                strSelectHtml.AppendFormat("<option value=\"\">{0}</option>", CommonFunction.GetResourceValue("LabelPleaseChoose"));

                foreach (Entities.SiteSalaryType salaryType in salaryTypeList)
                {
                    if (salaryType.SalaryTypeId != (int)PortalEnums.Search.SalaryType.NA)
                    {

                        strSelectHtml.AppendFormat("<option value=\"{0}\" {2}>{1}</option>", salaryType.SalaryTypeId, salaryType.SalaryTypeName, "");
                        count++;
                    }
                }
                strSelectHtml.Append("</select></div>");
                //strSelectHtml.AppendFormat("<div id='divSalaryFrom" + IsDynamicWidget + "'><select class='form-dropdown' id=\"{0}\" onchange=\"SalaryFromChange" + IsDynamicWidget + "();\">", "salarylowerband" + IsDynamicWidget);
                strSelectHtml.AppendFormat("<div id='divSalaryFrom" + IsDynamicWidget + "'><label for='{0}' class='divSalaryCurrency" + IsDynamicWidget + "'></label><input type='text' class='form-textbox numbersOnly' id=\"{0}\" placeholder=\"{1}\" />",
                                                            "salarylowerband" + IsDynamicWidget,
                                                            CommonFunction.GetResourceValue("LabelMinimum"));

                /*VList<ViewSalary> salaryFromList = new VList<ViewSalary>();
                if (salaryTypeList.Count > 0)
                {
                    ViewSalaryService viewSalaryService = new ViewSalaryService();
                    salaryFromList = viewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeList[0].SalaryTypeId);

                    

                    foreach (ViewSalary salary in salaryFromList)
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", string.Format("{0};{1}", salary.CurrencyId, salary.Amount), salary.SalaryDisplay);
                    }
                }
                else
                {
                    strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED> </option>");
                }*/

                strSelectHtml.Append("</div>"); //</select>
                strSelectHtml.Append(string.Format(" <div id=\"divTo\">{0}</div> ", CommonFunction.GetResourceValue("LabelTo")));

                strSelectHtml.AppendFormat("<div id='divSalaryTo" + IsDynamicWidget + "'><label for='{0}' class='divSalaryCurrency" + IsDynamicWidget + "'></label><input type='text' class='form-textbox numbersOnly' id=\"{0}\" placeholder=\"{1}\" />",
                                                            "salaryupperband" + IsDynamicWidget,
                                                            CommonFunction.GetResourceValue("LabelMaximum"));
                /*if (salaryFromList.Count > 0)
                {
                    ViewSalary vsFrom = salaryFromList[0];
                    ViewSalaryService viewSalaryService = new ViewSalaryService();
                    VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, vsFrom.CurrencyId, vsFrom.SalaryTypeId, vsFrom.Amount);
                    int tocount = salaryToList.Count;
                    int i = 0;

                    foreach (ViewSalary salary in salaryToList)
                    {
                        string strSelected = string.Empty;
                        if (i == tocount - 1)
                        {
                            strSelected = " selected";
                        }
                        strSelectHtml.AppendFormat("<option value=\"{0}\"{2}>{1}</option>", string.Format("{0};{1}", salary.CurrencyId, salary.Amount), salary.SalaryDisplay, strSelected);

                        i++;
                    }
                }
                else
                {
                    strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED> </option>");
                }*/
                strSelectHtml.Append("</div>"); //</select>
                strJobHTML = strJobHTML.Replace(_SALARY, strSelectHtml.ToString());
            }
        }

        protected void SetWorkTypes()
        {
            if (FindKeyword(_WORKTYPES))
            {
                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\">", "workTypeID" + IsDynamicWidget);
                List<Entities.SiteWorkType> siteWorkTypeList = SiteWorkTypeService.GetTranslatedWorkTypes();

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelAllWorkTypes") + "</option>");

                foreach (Entities.SiteWorkType siteWorkType in siteWorkTypeList)
                {
                    if (siteWorkType.SiteWorkTypeName == "")
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\" SELECTED>{1}</option>", siteWorkType.WorkTypeId.ToString(), siteWorkType.SiteWorkTypeName);
                    }
                    else
                    {
                        strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", siteWorkType.WorkTypeId.ToString(), siteWorkType.SiteWorkTypeName);
                    }
                }
                strSelectHtml.Append("</select>");

                strJobHTML = strJobHTML.Replace(_WORKTYPES, strSelectHtml.ToString());
            }
        }

        protected void SetAdvertisers()
        {
            if (FindKeyword(_ADVERTISERS))
            {
                StringBuilder strSelectHtml = new StringBuilder();
                strSelectHtml.AppendFormat("<select class='form-dropdown' id=\"{0}\">", "advertiserid" + IsDynamicWidget);
                AdvertisersService AdvertisersService = new JXTPortal.AdvertisersService();

                // Get advertisers who are approved and order by company name
                IEnumerable<Entities.Advertisers> advertiserList = AdvertisersService.GetBySiteId(SessionData.Site.SiteId)
                                                                        .Where(s => s.AdvertiserAccountStatusId == (int)PortalEnums.Advertiser.AccountStatus.Approved)
                                                                        .OrderBy(s => s.CompanyName);

                strSelectHtml.AppendFormat("<option value=\"-1\" SELECTED>" + CommonFunction.GetResourceValue("LabelSelectACompany") + "</option>");

                foreach (Entities.Advertisers advertiser in advertiserList)
                {
                    strSelectHtml.AppendFormat("<option value=\"{0}\">{1}</option>", advertiser.AdvertiserId.ToString(), advertiser.CompanyName);
                }
                strSelectHtml.Append("</select>");

                strJobHTML = strJobHTML.Replace(_ADVERTISERS, strSelectHtml.ToString());
            }
        }


        private Boolean FindKeyword(String strKeyword)
        {
            if (strJobHTML.IndexOf(strKeyword) > 0)
                return true;

            return false;
        }

        #endregion

        #region Methods

        protected void LoadAdvancedSearch()
        {
            if (ltlJobSearch == null || ltlJavascript == null || ltlCSS == null)
            {
                ltlJobSearch = new Literal();
                ltlJavascript = new Literal();
                ltlCSS = new Literal();
            }

            if (IsAdvancedSearch)
            {
                // Advanced Search
                using (TList<Entities.WidgetContainers> widgetContainersList = WidgetContainersService.GetBySiteId(SessionData.Site.SiteId))
                {
                    widgetContainersList.Filter = "OnAdvancedSearch = true";

                    if (widgetContainersList.Count > 0)
                    {
                        bool found = false;
                        foreach (Entities.WidgetContainers wc in widgetContainersList)
                        {
                            if (wc.LanguageId == SessionData.Language.LanguageId)
                            {
                                widgetContainer = wc;
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            widgetContainer = widgetContainersList[0];
                        }

                        strJobHTML = widgetContainer.JobHtml;

                        #region Javascript and CSS

                        if (!String.IsNullOrEmpty(widgetContainer.Javascript))
                        {
                            ltlJavascript.Text = String.Format(@"
{0}
", widgetContainer.Javascript);
                        }

                        if (!String.IsNullOrEmpty(widgetContainer.SearchCss))
                        {
                            ltlCSS.Text = String.Format(@"
{0}
", widgetContainer.SearchCss);
                        }

                        #endregion
                    }
                }
            }
            else
            {
                // Widget Search
                if (WidgetID > 0)
                {
                    if (ucSystemDynamicPage != null)
                    {
                        ucSystemDynamicPage.Visible = false;
                        ucSystemDynamicPage.Dispose();
                    }

                    using (widgetContainer = WidgetContainersService.GetByWidgetId(WidgetID))
                    {
                        if (widgetContainer != null && widgetContainer.SiteId == SessionData.Site.SiteId)
                        {
                            strJobHTML = widgetContainer.JobHtml;

                            #region Javascript and CSS

                            if (!String.IsNullOrEmpty(widgetContainer.Javascript))
                            {
                                ltlJavascript.Text = String.Format(@"

{0}

", widgetContainer.Javascript);
                            }

                            if (!String.IsNullOrEmpty(widgetContainer.SearchCss))
                            {
                                ltlCSS.Text = String.Format(@"

{0}

", widgetContainer.SearchCss);
                            }

                            #endregion
                        }
                    }
                }
            }

            using (TList<Entities.SiteCountries> scountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (scountries != null && scountries.Count > 0)
                {
                    strJobHTML += @"<input id='hfCountryCount' type='hidden' value='" + scountries.Count + "' />";
                }
                else
                {
                    strJobHTML += @"<input id='hfCountryCount' type='hidden' value='0' />";
                }
            }

        }

        private ajaxMethods _ajaxMethods;

        private ajaxMethods ajaxMethods
        {
            get
            {
                if (_ajaxMethods == null)
                    _ajaxMethods = new ajaxMethods();
                return _ajaxMethods;
            }
        }
        #endregion

    }
}