
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
#endregion

public partial class WidgetContainersEdit : System.Web.UI.Page
{
    #region Declare variables
    #endregion

    #region Properties

    private int WidgetId
    {
        get
        {
            int _widgetId = 0;

            if (Request.QueryString["WidgetId"] != null && Int32.TryParse(Request.QueryString["WidgetId"], out _widgetId))
            {
                _widgetId = Convert.ToInt32(Request.QueryString["WidgetId"]);
            }

            return _widgetId;
        }
    }

    private SiteLanguagesService _siteLanguagesService;
    private SiteLanguagesService SiteLanguagesService
    {
        get
        {
            if (_siteLanguagesService == null) _siteLanguagesService = new SiteLanguagesService();
            return _siteLanguagesService;
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



    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadLanguages();
            LoadProfessions();
            LoadCountries();

            if (WidgetId > 0)
            {
                LoadLocations();
                LoadWidget();
            }
        }
        else
        {
            if (ddlDefaultCountryId.SelectedItem != null && ddlDefaultCountryId.SelectedValue != "")
            {
                //LoadLocations();
            }
        }

    }

    #endregion

    #region Click Event handlers

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        JXTPortal.Entities.WidgetContainers widgetContainers;

        if (WidgetId > 0)
        {
            widgetContainers = WidgetContainersService.GetByWidgetId(WidgetId);

            if (widgetContainers != null && widgetContainers.SiteId != SessionData.Site.SiteId)
                Response.Redirect("/admin/widgetcontainers.aspx");
        }
        else
        {
            widgetContainers = new JXTPortal.Entities.WidgetContainers();
            widgetContainers.SiteId = SessionData.Site.SiteId;
        }

        widgetContainers.LanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
        widgetContainers.WidgetName = txtWidgetName.Text.Trim();

        widgetContainers.WidgetDomain = txtWidgetDomain.Text.Trim();
        widgetContainers.WidgetContainerClass = string.Empty;
        widgetContainers.WidgetContainerHeaderClass = string.Empty;
        widgetContainers.WidgetItemClass = string.Empty;
        widgetContainers.WidgetJobLinkCss = string.Empty;
        //widgetContainers.WidgetItemLinkImageId = txtWidgetContainerClass.Text.Trim();
        widgetContainers.Valid = chkValid.Checked;
        widgetContainers.ShowJobs = chkShowJobs.Checked;
        widgetContainers.ShowCompanies = chkShowCompanies.Checked;
        widgetContainers.ShowSite = chkShowSite.Checked;
        widgetContainers.ShowPeople = chkShowPeople.Checked;
        widgetContainers.JobHtml = txtJobHtml.Text.Trim();
        widgetContainers.CompanyHtml = txtCompanyHtml.Text.Trim();
        widgetContainers.SiteHtml = txtSiteHtml.Text.Trim();
        widgetContainers.PeopleHtml = txtPeopleHtml.Text.Trim();
        widgetContainers.Javascript = txtJavascript.Text.Trim();
        widgetContainers.SearchCss = txtSearchCss.Text.Trim();

        if (ddlDefaultProfessionId.SelectedItem != null && ddlDefaultProfessionId.SelectedValue != "")
            widgetContainers.DefaultProfessionId = int.Parse(ddlDefaultProfessionId.SelectedValue);
        else
            widgetContainers.DefaultProfessionId = null;

        if (ddlDefaultCountryId.SelectedItem != null && ddlDefaultCountryId.SelectedValue != "")
            widgetContainers.DefaultCountryId = int.Parse(ddlDefaultCountryId.SelectedValue);
        else
            widgetContainers.DefaultCountryId = null;

        if (ddlLocationId.SelectedItem != null && ddlLocationId.SelectedValue != "")
            widgetContainers.DefaultLocationId = int.Parse(ddlLocationId.SelectedValue);
        else
            widgetContainers.DefaultLocationId = null;

        if (!String.IsNullOrEmpty(txtWidth.Text.Trim()))
            widgetContainers.Width = int.Parse(txtWidth.Text.Trim());
        else
            widgetContainers.Width = null;

        if (!String.IsNullOrEmpty(txtHeight.Text.Trim()))
            widgetContainers.Height = int.Parse(txtHeight.Text.Trim());
        else
            widgetContainers.Height = null;

        widgetContainers.OnAdvancedSearch = chkOnAdvancedSearch.Checked;

        if (WidgetId > 0)
        {
            WidgetContainersService.Update(widgetContainers);
            widgetContainers.Dispose();
        }
        else
        {
            WidgetContainersService.Insert(widgetContainers);
            widgetContainers.Dispose();
            Response.Redirect("~/admin/widgetcontainersedit.aspx?WidgetId=" + widgetContainers.WidgetId.ToString());
        }


        if (((Button)sender).Text == "Update")
            Response.Redirect("~/admin/widgetcontainers.aspx");


    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/widgetcontainers.aspx");
    }

    #endregion

    #region Methods

    private void LoadLanguages()
    {
        using (TList<SiteLanguages> siteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
        {
            ddlLanguage.DataSource = siteLanguages;
            ddlLanguage.DataTextField = "SiteLanguageName";
            ddlLanguage.DataValueField = "LanguageID";
            ddlLanguage.DataBind();
        }
        ddlLanguage.Items.Insert(0, new ListItem("-Select Language-", ""));
    }

    protected void LoadProfessions()
    {
        SiteProfessionService siteProfessions = new SiteProfessionService();

        using (TList<JXTPortal.Entities.SiteProfession> siteProffession = siteProfessions.GetBySiteId(SessionData.Site.SiteId))
        {
            ddlDefaultProfessionId.DataSource = siteProffession;
            ddlDefaultProfessionId.DataTextField = "SiteProfessionName";
            ddlDefaultProfessionId.DataValueField = "ProfessionID";
            ddlDefaultProfessionId.DataBind();
        }
        ddlDefaultProfessionId.Items.Insert(0, new ListItem("-Select Profession-", ""));
    }

    protected void LoadLocations()
    {
        ddlLocationId.Items.Clear();

         SiteLocationService siteLocations = new SiteLocationService();

            using (TList<SiteLocation> siteLocation = siteLocations.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlLocationId.DataSource = siteLocation;
                ddlLocationId.DataTextField = "SiteLocationName";
                ddlLocationId.DataValueField = "LocationID";
                ddlLocationId.DataBind();
            }
            ddlLocationId.Items.Insert(0, new ListItem("-Select Location-", ""));
    }

    protected void LoadCountries()
    {
        SiteCountriesService siteCountriesService = new SiteCountriesService();

        //populate Country dropdown
        using (TList<JXTPortal.Entities.SiteCountries> siteCountries = siteCountriesService.GetBySiteId(SessionData.Site.SiteId))
        {
            ddlDefaultCountryId.DataSource = siteCountries;
            ddlDefaultCountryId.DataTextField = "SiteCountryName";
            ddlDefaultCountryId.DataValueField = "CountryID";
            ddlDefaultCountryId.DataBind();
        }
        ddlDefaultCountryId.Items.Insert(0, new ListItem("-Select Country-", ""));

    }

    private void LoadWidget()
    {
        if (WidgetId > 0)
        {

            using (JXTPortal.Entities.WidgetContainers widgetContainers = WidgetContainersService.GetByWidgetId(WidgetId))
            {
                if (widgetContainers != null && widgetContainers.WidgetId > 0)
                {
                    if (widgetContainers.SiteId != SessionData.Site.SiteId)
                        Response.Redirect("~/admin/widgetcontainers.aspx");

                    JXTPortal.Website.CommonFunction.SetDropDownByValue(ddlLanguage, widgetContainers.LanguageId.ToString());
                    JXTPortal.Website.CommonFunction.SetDropDownByValue(ddlDefaultProfessionId, widgetContainers.DefaultProfessionId.ToString());
                    JXTPortal.Website.CommonFunction.SetDropDownByValue(ddlDefaultCountryId, widgetContainers.DefaultCountryId.ToString());
                    LoadLocations();
                    JXTPortal.Website.CommonFunction.SetDropDownByValue(ddlLocationId, widgetContainers.DefaultLocationId.ToString());

                    txtWidgetName.Text = widgetContainers.WidgetName;
                    txtWidgetDomain.Text = widgetContainers.WidgetDomain;
                    chkValid.Checked = (widgetContainers.Valid.HasValue ? widgetContainers.Valid.Value : false);
                    chkShowJobs.Checked = (widgetContainers.ShowJobs.HasValue ? widgetContainers.ShowJobs.Value : false);
                    chkShowCompanies.Checked = (widgetContainers.ShowCompanies.HasValue ? widgetContainers.ShowCompanies.Value : false);
                    chkShowSite.Checked = (widgetContainers.ShowSite.HasValue ? widgetContainers.ShowSite.Value : false);
                    chkShowPeople.Checked = (widgetContainers.ShowPeople.HasValue ? widgetContainers.ShowPeople.Value : false);
                    txtJobHtml.Text = widgetContainers.JobHtml;
                    txtCompanyHtml.Text = widgetContainers.CompanyHtml;
                    txtSiteHtml.Text = widgetContainers.SiteHtml;
                    txtPeopleHtml.Text = widgetContainers.PeopleHtml;
                    txtJavascript.Text = widgetContainers.Javascript;
                    txtSearchCss.Text = widgetContainers.SearchCss;

                    if (widgetContainers.Width.HasValue)
                        txtWidth.Text = widgetContainers.Width.Value.ToString();

                    if (widgetContainers.Height.HasValue)
                        txtHeight.Text = widgetContainers.Height.Value.ToString();

                    chkOnAdvancedSearch.Checked = (widgetContainers.OnAdvancedSearch.HasValue ? widgetContainers.OnAdvancedSearch.Value : false);
                }
                else
                {
                    Response.Redirect("~/admin/widgetcontainers.aspx");
                }
            }
        }
    }

    #endregion

    protected void ddlDefaultCountryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLocations();
    }

}


