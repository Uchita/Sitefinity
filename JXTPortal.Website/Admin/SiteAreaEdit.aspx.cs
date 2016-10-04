
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

public partial class SiteAreaEdit : System.Web.UI.Page
{
    #region Declarations

    private SiteCountriesService _sitecountriesservice;
    private CountriesService _countriesservice;
    private SiteLocationService _sitelocationservice;
    private LocationService _locationservice;
    private AreaService _areaservice;
    private SiteAreaService _siteareaservice;

    private int _areaid = 0;

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

    private SiteAreaService SiteAreaService
    {
        get
        {
            if (_siteareaservice == null)
            {
                _siteareaservice = new SiteAreaService();
            }
            return _siteareaservice;
        }
    }

    private AreaService AreaService
    {
        get
        {
            if (_areaservice == null)
            {
                _areaservice = new AreaService();
            }
            return _areaservice;
        }
    }

    private int AreaID
    {
        get
        {
            if ((Request.QueryString["AreaID"] != null))
            {
                if (int.TryParse((Request.QueryString["AreaID"].Trim()), out _areaid))
                {
                    _areaid = Convert.ToInt32(Request.QueryString["AreaID"]);
                }
                return _areaid;
            }

            return _areaid;
        }
    }

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDefaultArea();
        }
    }

    #endregion

    #region Method

    private void LoadDefaultArea()
    {
        if (AreaID > 0)
        {
            using (DataSet area = AreaService.GetDetailWithSite(SessionData.Site.SiteId, AreaID))
            {
                if (area.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = area.Tables[0].Rows[0];

                    lbLocation.Text = dr["LocationName"].ToString();
                    lbAreaName.Text = dr["AreaName"].ToString();
                    dataAreaName.Text = dr["AreaName"].ToString();
                    lbSiteLocation.Text = dr["SiteLocationName"].ToString();
                    dataAreaName.Text = dr["SiteAreaName"].ToString();
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
            using (TList<JXTPortal.Entities.SiteArea> siteareas = SiteAreaService.GetBySiteId(SessionData.Site.SiteId))
            {
                siteareas.Filter = "AreaId = " + AreaID.ToString();
                if (siteareas.Count > 0)
                {
                    SiteAreaService.Delete(siteareas);
                }

                using (JXTPortal.Entities.SiteArea sitearea = new JXTPortal.Entities.SiteArea())
                {
                    sitearea.AreaId = AreaID;
                    sitearea.SiteId = SessionData.Site.SiteId;
                    sitearea.SiteAreaName = dataAreaName.Text;
                    sitearea.Valid = true;

                    SiteAreaService.Insert(sitearea);
                    Response.Redirect("sitelocationarea.aspx");
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


