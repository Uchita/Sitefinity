using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Entities.Models;

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

        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }

        public string CampaignName
        {
            get { return ViewState["CampaignName"] != null ? ViewState["CampaignName"].ToString() : string.Empty; }
            set { ViewState["CampaignName"] = value; }
        }

        public string MapKey
        {
            get
            {
                AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);
                if (integrations != null && integrations.GoogleMap != null)
                {
                    //only assign anything to the geocode and address status if there is a server key in the integrations of the site
                    if (!string.IsNullOrWhiteSpace(integrations.GoogleMap.ServerKey) && integrations.GoogleMap.Valid)
                    {
                        //set key for ascx use
                        return integrations.GoogleMap.ServerKey;
                    }
                }
                return null;
            }
        }

        #endregion


    }
}