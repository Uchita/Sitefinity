using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucSearchResultsGoogleMap : System.Web.UI.UserControl
    {
        #region Properties

        private ViewJobSearchService _viewJobSearchService = null;

        public ViewJobSearchService ViewJobSearchService
        {

            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }

        public string CampaignName
        {
            get { return ViewState["CampaignName"] != null ? ViewState["CampaignName"].ToString() : string.Empty; }
            set { ViewState["CampaignName"] = value; }
        }

        #endregion


    }
}