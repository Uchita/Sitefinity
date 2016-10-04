using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.advertiser
{
    public partial class validate : System.Web.UI.Page
    {
        #region Declaration

        private AdvertiserUsersService _advertiserUsersService;
        private DynamicPagesService _dynamicPagesService = null;

        #endregion

        #region Properties

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserUsersService == null)
                {
                    _advertiserUsersService = new AdvertiserUsersService();
                }

                return _advertiserUsersService;
            }
        }

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
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

        private AdvertisersService _advertisersService;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersService == null)
                {
                    _advertisersService = new AdvertisersService();
                }

                return _advertisersService;
            }
        }


        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Validation");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ValidateEmail();
            }
        }

        #endregion

        #region Method

        private void ValidateEmail()
        {
            bool isValid = false;

            if (Request.QueryString["User"] != null && Request.QueryString["ValidationID"] != null)
            {
                using (TList<JXTPortal.Entities.AdvertiserUsers> advertiserusers = AdvertiserUsersService.GetByUserNameSiteId(Request.QueryString["User"],
                    SessionData.Site.SiteId))
                {
                    if (advertiserusers.Count() > 0)
                    {
                        if (advertiserusers[0].Validated == false && advertiserusers[0].ValidateGuid.Value.ToString().ToLower()
                           == Request.QueryString["ValidationID"].ToLower())
                        {
                            advertiserusers[0].Validated = true;

                            //We will try the Bullhorn executions first before we actually call the update to the local db
                            //this is because if bullhorn login failed, this gets redirected to BH to re-authorize.
                            //and if we updated the advertiser account status first, when we comes back from BH re-authorize, it will
                            //never hit the BH sync function
                            //Bullhorn Integration
                            //- When advertiser user validates, we push account to BH
                            #region BH Advertiser/Users sync
                            BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(JXTPortal.Entities.SessionData.Site.SiteId);
                            if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                            {
                                string errorMsg = string.Empty;

                                using (JXTPortal.Entities.Advertisers Advertisers = AdvertisersService.GetBySiteId(JXTPortal.Entities.SessionData.Site.SiteId).Where(s => s.AdvertiserId == advertiserusers[0].AdvertiserId).FirstOrDefault())
                                {
                                    if (Advertisers != null)
                                    {
                                        //only sync if the advertiser account is active/approved
                                        if ((PortalEnums.Advertiser.AccountStatus)Advertisers.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                                            BullhornRESTAPI.SyncAdvertiserAndUser(JXTPortal.Entities.SessionData.Site.SiteId, Advertisers, advertiserusers[0], true, out errorMsg);
                                    }
                                }
                            }
                            #endregion

                            if (AdvertiserUsersService.Update(advertiserusers[0]))
                            {
                                isValid = true;
                                //SessionService.RemoveMember();
                                //SessionService.SetAdvertiserUser(advertiserusers[0]);                                
                            }
                        }
                        else if (advertiserusers[0].Validated.HasValue && advertiserusers[0].Validated.Value)
                        {
                            litMessage.Text = CommonFunction.GetResourceValue("LabelAdvertiserInvalid");
                            return;
                        }
                    }
                }
            }

            if (isValid)
                Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.ADVERTISER_VALIDATION_SUCCESS, "", "", ""));
            else
                litMessage.Text = CommonFunction.GetResourceValue("LabelAccessDenied");
        }

        #endregion

    }
}
