
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

public partial class LocationEdit : System.Web.UI.Page
{
    #region Declaration

    private int _locationid = 0;
    private LocationService _locationservice;
    
    #endregion

    #region Properties

    protected int LocationID
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
        }

        UpdateButton.Visible = (LocationID > 0);

        // Insert is commented out for webservice purposes - Ditto 21/02/2013
        // InsertButton.Visible = (LocationID == 0);
        
    }

    #endregion

    #region Methods

    private void LoadLocation()
    {
        if (LocationID > 0)
        {
            using (JXTPortal.Entities.Location location = LocationService.GetByLocationId(LocationID))
            {
                if (location != null)
                {
                    dataLocationName.Text = location.LocationName;
                    dataValid.Checked = location.Valid;
                }
                else
                    Response.Redirect("location.aspx");
            }
        }

    }

    #endregion

    #region Events

    // Insert is commented out for webservice purposes - Ditto 21/02/2013

    //protected void InsertButton_Click(object sender, EventArgs e)
    //{
    //    using (JXTPortal.Entities.Location location = new JXTPortal.Entities.Location())
    //    {
    //        location.LocationId = LocationID;
    //        location.LocationName = dataLocationName.Text;
    //        location.Valid = dataValid.Checked;

    //        LocationService.Insert(location);

    //        Response.Redirect("location.aspx");
    //    }
    //}

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Location location = LocationService.GetByLocationId(LocationID))
        {
            location.LocationId = LocationID;
            location.LocationName = dataLocationName.Text;
            location.Valid = dataValid.Checked;

            LocationService.Update(location);

            Response.Redirect("location.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("location.aspx");
    }
    #endregion
}


