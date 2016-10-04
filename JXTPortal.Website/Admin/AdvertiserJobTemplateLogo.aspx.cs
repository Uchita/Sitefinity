using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class AdvertiserJobTemplateLogo : System.Web.UI.Page
    {
        #region Declarations

        private int _advertiserid = 0;
        private AdvertisersService _advertisersservice;

        #endregion

        #region Properties

        protected int AdvertiserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserID"].Trim()), out _advertiserid))
                    {
                        _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserID"]);
                    }
                    return _advertiserid;
                }

                return _advertiserid;
            }
        }

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }


        #endregion

        #region Page Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AdvertiserID > 0)
            {
                using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                {
                    if (advertiser != null)
                    {
                        if (advertiser.SiteId != SessionData.Site.SiteId)
                        {
                            Response.Redirect("Advertisers.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("Advertisers.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/admin/advertisers.aspx");
            }
        }

        #endregion
    }
}
