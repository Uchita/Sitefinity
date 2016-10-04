using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace JXTPortal.Website.advertiser
{
    public partial class PublicProfile : System.Web.UI.Page
    {
        private int AdvertiserID
        {
            get
            {
                int _advertiserID = -1;
                int.TryParse(Request.QueryString["AdvertiserId"], out _advertiserID);
                return _advertiserID;
            }
        }

        private AdvertisersService _advertisersservice;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (AdvertiserID > 0)
                {
                    using(JXTPortal.Entities.Advertisers advs = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                    {
                        if (advs != null)
                            this.Title = advs.CompanyName + CommonFunction.GetResourceValue("LabelsProfile");
                    }
                }
            }
        }
    }
}
