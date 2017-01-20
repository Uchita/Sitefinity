using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class AdvertiserNavigation : System.Web.UI.UserControl
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
        
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();

                //Hide the subaccount if the advertiser is not a Primary user.
                if (Entities.SessionData.AdvertiserUser != null && !SessionData.AdvertiserUser.PrimaryAccount)
                {
                    phSubAccounts.Visible = false;
                }

            }

            SetFormValues();

        }


        public void SetFormValues()
        {
            lnkLogout.Text = CommonFunction.GetResourceValue("LabelLogout");
            hlManageJobs.Text = CommonFunction.GetResourceValue("LinkButtonManageJobs");
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
            hlViewChangeTemplateLogo.Text = CommonFunction.GetResourceValue("LinkButtonViewChangeTemplateLogo");
            hlPeopleSearch.Text = CommonFunction.GetResourceValue("LinkButtonPeopleSearch");
            hlScreeningQuestionTemplate.Text = CommonFunction.GetResourceValue("LinkButtonScreeningQuestionsTemplate");
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
                                phPeopleSearch.Visible = globalsetting.EnablePeopleSearch;
                                phScreeningQuestions.Visible = globalsetting.EnableScreeningQuestions;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Click Event handlers

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            SessionService.RemoveAdvertiserUser();
            SessionService.SessionAbandon();

            Response.Redirect("~/");
        }

        #endregion
    }
}