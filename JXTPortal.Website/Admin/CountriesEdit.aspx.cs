using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal;

public partial class CountriesEdit : System.Web.UI.Page
{
    #region Declaration

    private int _countryid = 0;
    private CountriesService _countriesservice;

    #endregion

    #region Properties

    protected int CountryID
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

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCountry();
        }

        InsertButton.Visible = (CountryID  == 0);
        UpdateButton.Visible = (CountryID > 0);
    }

    #endregion

    #region Methods

    private void LoadCountry()
    {
        if (CountryID > 0)
        {
            using (JXTPortal.Entities.Countries country = CountriesService.GetByCountryId(CountryID))
            {
                if (country != null)
                {
                    dataCountryName.Text = country.CountryName;
                    dataAbbr.Text = country.Abbr;
                    dataValid.Checked = country.Valid;
                }
                else
                    Response.Redirect("countries.aspx");
            }
        }
    }

    #endregion

    #region Events

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Countries country = new JXTPortal.Entities.Countries())
        {
            country.CountryId = CountryID;
            country.CountryName = dataCountryName.Text;
            country.Abbr = dataAbbr.Text;
            country.Valid = dataValid.Checked;
            country.Sequence = 0;

            CountriesService.Insert(country);

            Response.Redirect("countries.aspx");
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Countries country = new JXTPortal.Entities.Countries())
        {
            country.CountryId = CountryID;
            country.CountryName = dataCountryName.Text;
            country.Abbr = dataAbbr.Text;
            country.Valid = dataValid.Checked;
            country.Sequence = 0;

            CountriesService.Update(country);

            Response.Redirect("countries.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("countries.aspx");
    }
    #endregion
}
