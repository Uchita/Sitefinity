
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
using JXTPortal;
using JXTPortal.Entities;
#endregion

public partial class AreaEdit : System.Web.UI.Page
{
    #region Declaration

    private int _areaid = 0;
    private AreaService _areaservice;
    private LocationService _locationservice;

    #endregion

    #region Properties

    protected int AreaID
    {
        get
        {
            if ((Request.QueryString["AreaID"] != null))
            {
                if ((Request.QueryString["AreaID"] != null))
                    if (int.TryParse((Request.QueryString["AreaID"].Trim()), out _areaid))
                    {
                        _areaid = Convert.ToInt32(Request.QueryString["AreaID"]);
                    }
                return _areaid;
            }

            return _areaid;
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

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadLocation();
            LoadArea();
        }

        UpdateButton.Visible = (AreaID > 0);

        // Insert is commented out for webservice purposes - Ditto 21/02/2013
        // InsertButton.Visible = (AreaID == 0);
        
    }

    #endregion

    #region Methods

    private void LoadLocation()
    {
        dataLocation.Items.Clear();

        using (TList<JXTPortal.Entities.Location> locations = LocationService.GetAll())
        {
            dataLocation.DataSource = locations;
            dataLocation.DataBind();
        }
    }

    private void LoadArea()
    {
        if (AreaID > 0)
        {
            using (JXTPortal.Entities.Area area = AreaService.GetByAreaId(AreaID))
            {
                if (area != null)
                {
                    using (JXTPortal.Entities.Location location = LocationService.GetByLocationId(area.LocationId))
                    {
                        LoadLocation();
                    }

                    dataLocation.SelectedValue = area.LocationId.ToString();
                    dataAreaName.Text = area.AreaName;
                    dataValid.Checked = area.Valid;
                }
                else
                    Response.Redirect("area.aspx");
            }
        }

    }

    #endregion

    #region Events

    // Insert is commented out for webservice purposes - Ditto 21/02/2013

    //protected void InsertButton_Click(object sender, EventArgs e)
    //{
    //    using (JXTPortal.Entities.Area area = new JXTPortal.Entities.Area())
    //    {
    //        area.AreaId = AreaID;
    //        area.LocationId = Convert.ToInt32(dataLocation.SelectedValue);
    //        area.AreaName = dataAreaName.Text;
    //        area.Valid = dataValid.Checked;

    //        AreaService.Insert(area);

    //        Response.Redirect("area.aspx");
    //    }
    //}

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Area area = new JXTPortal.Entities.Area())
        {
            area.AreaId = AreaID;
            area.LocationId = Convert.ToInt32(dataLocation.SelectedValue);
            area.AreaName = dataAreaName.Text;
            area.Valid = dataValid.Checked;

            AreaService.Update(area);

            Response.Redirect("area.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("area.aspx");
    }
    #endregion
}


