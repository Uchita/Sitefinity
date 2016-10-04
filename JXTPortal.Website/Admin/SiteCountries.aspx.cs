

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;

using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
#endregion

public partial class SiteCountries : System.Web.UI.Page
{
    #region Properties

    private CountriesService _countriesservice;

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

    private SiteCountriesService _sitecountriesservice;

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


    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        ltlMessage.Text = string.Empty;

        if (!Page.IsPostBack)
        {
            LoadCountries();
        }
    }

    private void LoadCountries()
    {

        rptCountries.DataSource = null;
        //TreeView1.Nodes.Clear();

        using (TList<Countries> countries = CountriesService.GetAll())
        using (TList<JXTPortal.Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
        {
            rptCountries.DataSource = countries.FindAll(s => s.Valid == true); // Only valid countries
            rptCountries.DataBind();

            foreach (JXTPortal.Entities.SiteCountries sitecountry in sitecountries)
            {
                foreach (RepeaterItem item in rptCountries.Items)
                {
                    HiddenField hfCountry = item.FindControl("hfCountry") as HiddenField;
                    CheckBox cbCountry = item.FindControl("cbCountry") as CheckBox;
                    TextBox tbSequence = item.FindControl("tbSequence") as TextBox;

                    if (sitecountry.CountryId == Convert.ToInt32(hfCountry.Value))
                    {
                        cbCountry.Checked = true;
                        tbSequence.Text = sitecountry.Sequence.ToString();

                        break;
                    }
                }
            }

        }

    }

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        using (TList<JXTPortal.Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
        {
            foreach (RepeaterItem item in rptCountries.Items)
            {
                HiddenField hfCountry = item.FindControl("hfCountry") as HiddenField;
                CheckBox cbCountry = item.FindControl("cbCountry") as CheckBox;
                TextBox tbSequence = item.FindControl("tbSequence") as TextBox;

                bool found = false;

                foreach (JXTPortal.Entities.SiteCountries sitecountry in sitecountries)
                {
                    if (sitecountry.CountryId == Convert.ToInt32(hfCountry.Value))
                    {
                        found = true;

                        if (!cbCountry.Checked)
                        {
                            // Remove associated Site Location & Area of the Country


                            SiteCountriesService.Delete(sitecountry);                            

                            break;
                        }
                        else
                        {
                            int sequence = 0;
                            int.TryParse(tbSequence.Text, out sequence);
                            sitecountry.Sequence = sequence;

                            SiteCountriesService.Update(sitecountry);
                            break;
                        }
                    }

                }

                if (!found && cbCountry.Checked)
                {
                    JXTPortal.Entities.Countries origincountry = CountriesService.GetByCountryId(Convert.ToInt32(hfCountry.Value));
                    if (origincountry != null)
                    {
                        JXTPortal.Entities.SiteCountries newsitecountry = new JXTPortal.Entities.SiteCountries();
                        newsitecountry.SiteId = SessionData.Site.SiteId;
                        newsitecountry.CountryId = origincountry.CountryId;
                        newsitecountry.Currency = origincountry.Currency;
                        newsitecountry.SiteCountryName = origincountry.CountryName;
                        newsitecountry.SiteCountryFriendlyUrl = Utils.UrlFriendlyName(origincountry.CountryName);
                        int sequence = 0;
                        int.TryParse(tbSequence.Text, out sequence);
                        newsitecountry.Sequence = sequence;

                        SiteCountriesService.Insert(newsitecountry);
                    }
                }
            }
        }

        LoadCountries();
        ltlMessage.Text = "Countries allocated successfully.";
    }

    protected void rptCountries_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Countries country = (Countries)e.Item.DataItem;
            HiddenField hfCountry = e.Item.FindControl("hfCountry") as HiddenField;
            TextBox tbSequence = e.Item.FindControl("tbSequence") as TextBox;
            Literal ltCountry = e.Item.FindControl("ltCountry") as Literal;

            hfCountry.Value = country.CountryId.ToString();
            tbSequence.Text = (country.Sequence.HasValue) ? country.Sequence.Value.ToString() : string.Empty;
            ltCountry.Text = string.Format("<a href=\"./SiteCountriesEdit.aspx?CountryID={0}\">{1}</a>", country.CountryId, country.CountryName);
        }
    }
}


