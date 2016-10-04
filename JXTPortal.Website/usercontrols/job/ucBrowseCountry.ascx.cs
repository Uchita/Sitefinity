using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucBrowseCountry : System.Web.UI.UserControl
    {
        #region Properties

        private SiteLocationService _sitelocationservice;
        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
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

        private string SiteProfession
        {
            get
            {
                string _siteprofession = string.Empty;
                _siteprofession = Request.QueryString["SiteProfession"];
                return _siteprofession;
            }
        }

        private string SiteRole
        {
            get
            {
                string _siterole = string.Empty;
                _siterole = Request.QueryString["SiteRole"];
                return _siterole;
            }
        }

        private string SiteCountry
        {
            get
            {
                string _sitecountry = string.Empty;
                _sitecountry = Request.QueryString["SiteCountry"];
                return _sitecountry;
            }
        }

        private string SiteLocation
        {
            get
            {
                string _sitelocation = string.Empty;
                _sitelocation = Request.QueryString["SiteLocation"];
                return _sitelocation;
            }
        }

        private string SiteWorkType
        {
            get
            {
                string _siteworktype = string.Empty;
                _siteworktype = Request.QueryString["SiteWorkType"];
                return _siteworktype;
            }
        }

        private int PageNo
        {
            get
            {
                int _pageno = 1;
                Int32.TryParse(Request.QueryString["PageNo"], out _pageno);
                return _pageno;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCountryLocation();
            }
        }

        private void LoadCountryLocation()
        {
            if (string.IsNullOrEmpty(SiteCountry))
            {
                using (TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
                {
                    rptCountryLocation.DataSource = sitecountries;
                    rptCountryLocation.DataBind();
                }
                ltHeader.Text = "Jobs By Country";
            }
            else
            {
                ltHeader.Text = "Jobs By Location";
                int countryid = 0;
                DataSet dssitecountries = SiteCountriesService.GetBySiteIdFriendlyUrl(SessionData.Site.SiteId, SiteCountry);
                if (dssitecountries.Tables[0].Rows.Count > 0)
                {
                    countryid = Convert.ToInt32(dssitecountries.Tables[0].Rows[0]["CountryID"]);
                }

                if (countryid > 0)
                {
                    using (TList<Entities.SiteLocation> sitelocations = SiteLocationService.GetByCountryID(SessionData.Site.SiteId, countryid))
                    {
                        if (sitelocations.Count > 0)
                        {
                            rptCountryLocation.DataSource = sitelocations;
                            rptCountryLocation.DataBind();
                        }
                    }
                }

            }
        }

        protected void rptCountryLocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem is Entities.SiteCountries)
                {
                    Entities.SiteCountries sitecountry = e.Item.DataItem as Entities.SiteCountries;
                    Literal ltLink = e.Item.FindControl("ltLink") as Literal;
                    ltLink.Text = string.Format(@"<a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, SiteRole, sitecountry.SiteCountryFriendlyUrl,
                        SiteLocation, SiteWorkType, 1), sitecountry.SiteCountryName, string.Format("Browse {0} Jobs", sitecountry.SiteCountryName));
                }
                else if (e.Item.DataItem is Entities.SiteLocation)
                {
                    Entities.SiteLocation sitelocation = e.Item.DataItem as Entities.SiteLocation;
                    Literal ltLink = e.Item.FindControl("ltLink") as Literal;
                    ltLink.Text = string.Format(@"<a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry,
                        sitelocation.SiteLocationFriendlyUrl, SiteWorkType, 1), sitelocation.SiteLocationName, string.Format("Browse {0} Jobs", sitelocation.SiteLocationName));
                }
            }
        }
    }
}