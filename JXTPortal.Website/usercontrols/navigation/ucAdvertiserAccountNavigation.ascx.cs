using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class ucAdvertiserAccountNavigation : System.Web.UI.UserControl
    {
        #region Declarations

        private int AdvertiserUserId = 0;
        private int AdvertiserId = 0;

        #endregion

        #region Properties

        AdvertiserUsersService _AdvertiserUsersService;
        AdvertiserUsersService AdvUserService
        {
            get
            {
                if (_AdvertiserUsersService == null)
                {
                    _AdvertiserUsersService = new AdvertiserUsersService();
                }

                return _AdvertiserUsersService;
            }
        }

        AdvertisersService _AdvertiserService;
        AdvertisersService AdvService
        {
            get
            {
                if (_AdvertiserService == null)
                {
                    _AdvertiserService = new AdvertisersService();
                }

                return _AdvertiserService;
            }
        }

        GlobalSettingsService _GlobalSettingsService;
        GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                {
                    _GlobalSettingsService = new GlobalSettingsService();
                }

                return _GlobalSettingsService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            loadForm();

            SetFormValues();
        }

        public void Setup()
        {
            loadForm();

            SetFormValues();
        }


        public void SetFormValues()
        {
            lnkLogout.Text = CommonFunction.GetResourceValue("LabelLogout");
            hlManageJobs.Text = CommonFunction.GetResourceValue("LinkButtonManageJobs");
            hlBuyJobCredits.Text = CommonFunction.GetResourceValue("LinkButtonBuyJobCredits");

            int cartAmount = SessionData.AdvertiserUser.CartItems == null ? 0 : SessionData.AdvertiserUser.CartItems.Count();
            hlCart.Text = CommonFunction.GetResourceValue("LinkButtonCart") + " (" + cartAmount + ")";

            if (cartAmount == 0)
                hlCart.NavigateUrl = "/advertiser/productselect.aspx";

            hlCreateNewJobAd.Text = CommonFunction.GetResourceValue("LinkButtonCreateNewJobAd");
            hlCurrentJobAds.Text = CommonFunction.GetResourceValue("LinkButtonCurrentJobAds");
            hlPendingJobs.Text = CommonFunction.GetResourceValue("LinkButtonPendingJobAds");
            hlDeclinedJobs.Text = CommonFunction.GetResourceValue("LinkButtonDeclinedJobAds");
            hlDraftJobAds.Text = CommonFunction.GetResourceValue("LinkButtonDraftJobAds");
            hlArchivedJobAds.Text = CommonFunction.GetResourceValue("LinkButtonArchivedJobAds");
            hlAccountDetails.Text = CommonFunction.GetResourceValue("LinkButtonAccountDetails");
            hlSubAccounts.Text = CommonFunction.GetResourceValue("LinkButtonSubAccounts");
            hlChangePassword.Text = CommonFunction.GetResourceValue("LabelChangePwd");
            hlChangeTemplateLogo.Text = CommonFunction.GetResourceValue("LinkButtonChangeTemplateLogo");
            hlViewChangeLogo.Text = CommonFunction.GetResourceValue("LinkButtonViewChangeLogo");
            //hlViewChangeTemplateLogo.Text = CommonFunction.GetResourceValue("LinkButtonViewChangeTemplateLogo");
            //hlPeopleSearch.Text = CommonFunction.GetResourceValue("LinkButtonPeopleSearch");
            hlJobTracker.Text = CommonFunction.GetResourceValue("LinkButtonJobTracker");
            hlStatistics.Text = CommonFunction.GetResourceValue("LinkButtonStatistics");
        }

        protected void loadForm()
        {
            if (Entities.SessionData.AdvertiserUser != null && Entities.SessionData.AdvertiserUser.AdvertiserId > 0)
            {
                AdvertiserUserId = Entities.SessionData.AdvertiserUser.AdvertiserUserId;

                using (Entities.AdvertiserUsers advu = AdvUserService.GetByAdvertiserUserId(AdvertiserUserId))
                {
                    if (advu != null)
                    {
                        ltAdvertiserLoginName.Text = advu.FirstName;

                        // Show pending jobs when job screening process is enabled
                        using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            if (globalsettings.Count > 0)
                            {
                                Entities.GlobalSettings globalsetting = globalsettings[0];
                                phPendingJobs.Visible = (globalsetting.JobScreeningProcess.HasValue) ? globalsetting.JobScreeningProcess.Value : false;
                            }
                        }
                    }
                }
            }

            if (!SessionData.Site.IsJobBoard)
            {
                hlBuyJobCredits.Visible = false;
                hlCart.Visible = false;
            }
            else
            {
                if (SessionData.AdvertiserUser.AccountType == PortalEnums.Advertiser.AccountType.Account)
                {
                    hlBuyJobCredits.Visible = false;
                    hlCart.Visible = false;
                }
                else
                {
                    if (SessionData.AdvertiserUser.CartItems == null || SessionData.AdvertiserUser.CartItems.Count() == 0)
                        hlCart.Visible = false;
                    else
                        hlCart.Visible = true;
                }
            }

        }
    }
}