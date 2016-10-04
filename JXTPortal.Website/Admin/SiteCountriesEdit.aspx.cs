
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
using JXTPortal.Common;
#endregion

public partial class SiteCountriesEdit : System.Web.UI.Page
{
    #region Declarations

    private CountriesService _countriesservice;
    private SiteCountriesService _sitecountriesservice;
    private int _countryid = 0;

    #endregion

    #region Properties

    private CountriesService CountriesService
    {
        get
        {
            if (_countriesservice == null)
            {
                _countriesservice = new CountriesService();
            }
            return _countriesservice;
        }
    }

    private SiteCountriesService SiteCountriesService
    {
        get
        {
            if (_sitecountriesservice == null)
            {
                _sitecountriesservice = new SiteCountriesService();
            }
            return _sitecountriesservice;
        }
    }

    private int CountryID
    {
        get
        {
            if ((Request.QueryString["CountryID"] != null))
            {
                if (int.TryParse((Request.QueryString["CountryID"].Trim()), out _countryid))
                {
                    _countryid = Convert.ToInt32(Request.QueryString["CountryID"]);
                }
                return _countryid;
            }

            return _countryid;
        }
    }

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDefaultCountry();
        }
    }

    #endregion

    #region Method

    private void LoadDefaultCountry()
    {
        if (CountryID > 0)
        {
            using (DataSet country = CountriesService.GetDetailWithSite(SessionData.Site.SiteId, CountryID))
            {
                if (country.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = country.Tables[0].Rows[0];

                    lbCountry.Text = dr["CountryName"].ToString();
                    dataCountryName.Text = dr["SiteCountryName"].ToString();
                    dataFriendlyUrl.Text = dr["SiteCountryFriendlyUrl"].ToString();
                    dataCurrency.Text = dr["Currency"].ToString();
                }   
            }
        }
        else
            Response.Redirect("SiteLocationArea.aspx");
    }

    #endregion

    #region Events

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (TList<JXTPortal.Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                sitecountries.Filter = "CountryId = " + CountryID.ToString();
                if (sitecountries.Count > 0)
                {
                    JXTPortal.Entities.SiteCountries sitecountry = sitecountries[0];
                    sitecountry.CountryId = CountryID;
                    sitecountry.SiteId = SessionData.Site.SiteId;
                    sitecountry.SiteCountryName = dataCountryName.Text;
                    sitecountry.SiteCountryFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                    sitecountry.Currency = dataCurrency.Text;
                    SiteCountriesService.Update(sitecountry);
                    Response.Redirect("sitelocationarea.aspx");
                }
                else
                {
                    using (JXTPortal.Entities.SiteCountries sitecountry = new JXTPortal.Entities.SiteCountries())
                    {
                        sitecountry.CountryId = CountryID;
                        sitecountry.SiteId = SessionData.Site.SiteId;
                        sitecountry.SiteCountryName = dataCountryName.Text;
                        sitecountry.SiteCountryFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                        sitecountry.Currency = dataCurrency.Text;
                        SiteCountriesService.Insert(sitecountry);
                        Response.Redirect("sitelocationarea.aspx");
                    }
                }
            }
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("sitelocationarea.aspx");
    }

    #endregion
}


