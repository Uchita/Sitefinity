
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

public partial class SiteLocationEdit : System.Web.UI.Page
{
    #region Declarations

    private SiteLocationService _sitelocationservice;
    private LocationService _locationservice;
    private CountriesService _countriesservice;
    private SiteCountriesService _sitecountriesservice;
    private int _locationid = 0;

    #endregion

    #region Properties

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

    private LocationService LocationService
    {
        get
        {
            if (_locationservice == null)
            {
                _locationservice = new LocationService();
            }
            return _locationservice;
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

    private int LocationID
    {
        get
        {
            if ((Request.QueryString["LocationID"] != null))
            {
                if (int.TryParse((Request.QueryString["LocationID"].Trim()), out _locationid))
                {
                    _locationid = Convert.ToInt32(Request.QueryString["LocationID"]);
                }
                return _locationid;
            }

            return _locationid;
        }
    }

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDefaultLocation();
        }
    }

    #endregion

    #region Method

    private void LoadDefaultLocation()
    {
        if (LocationID > 0)
        {
            using (DataSet location = LocationService.GetDetailWithSite(SessionData.Site.SiteId, LocationID))
            {
                if (location.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = location.Tables[0].Rows[0];
                    lbLocationName.Text = dr["LocationName"].ToString();
                    dataLocationName.Text = dr["SiteLocationName"].ToString();
                    dataFriendlyUrl.Text = dr["SiteLocationFriendlyUrl"].ToString();
                }
                else
                    Response.Redirect("sitelocationarea.aspx");
            }
        }
        else
            Response.Redirect("sitelocationarea.aspx");
    }

    #endregion

    #region Events

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (TList<JXTPortal.Entities.SiteLocation> sitelocations = SiteLocationService.GetBySiteId(SessionData.Site.SiteId))
            {
                sitelocations.Filter = "LocationId = " + LocationID.ToString();
                if (sitelocations.Count > 0)
                {
                    JXTPortal.Entities.SiteLocation sitelocation = sitelocations[0];
                    sitelocation.LocationId = LocationID;
                    sitelocation.SiteId = SessionData.Site.SiteId;
                    sitelocation.SiteLocationName = dataLocationName.Text;
                    sitelocation.SiteLocationFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                    sitelocation.Valid = true;

                    SiteLocationService.Update(sitelocation);
                    Response.Redirect("sitelocationarea.aspx");
                }
                else
                {
                    using (JXTPortal.Entities.SiteLocation sitelocation = new JXTPortal.Entities.SiteLocation())
                    {
                        sitelocation.LocationId = LocationID;
                        sitelocation.SiteId = SessionData.Site.SiteId;
                        sitelocation.SiteLocationName = dataLocationName.Text;
                        sitelocation.SiteLocationFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                        sitelocation.Valid = true;

                        SiteLocationService.Insert(sitelocation);
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


