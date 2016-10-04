using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        #region Properties

        private AdvertiserUsersService _advertiserUsersService = null;
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

        private DynamicPagesService _dynamicPagesService = null;
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

        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Retrieve Password");

            //is recruiter board?
            /*if (!SessionData.Site.IsJobBoard)
            {
                Response.Redirect("404.aspx");
            }*/
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            litMessage.Text = "";
            SetFormValues();
        }


        public void SetFormValues()
        {
            btnRetrieve.Text = CommonFunction.GetResourceValue("ButtonReset");
        }

        #endregion

        #region Events

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text.Trim()) && string.IsNullOrEmpty(tbEmail.Text.Trim()))
            {
                litMessage.Text = CommonFunction.GetResourceValue("ErrorEnterEmailUsername");
                return;
            }

            if (!string.IsNullOrEmpty(tbEmail.Text.Trim()))
            {

                using (TList<Entities.AdvertiserUsers> users = AdvertiserUsersService.GetAdvertiserUserPassword(tbUserName.Text, tbEmail.Text, SessionData.Site.SiteId))
                {
                    if (users.Count > 0)
                    {
                        Entities.AdvertiserUsers user = users[0];
                        user.ValidateGuid = Guid.NewGuid();
                        user.LoginAttempts = 0;
                        user.LastAttemptDate = null;
                        user.Status = (int)PortalEnums.AdvertiserUser.UserStatus.Valid;

                        if (AdvertiserUsersService.Update(user))
                        {
                            MailService.SendAdvertiserForgottenPasswordEmail(user);
                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.ADVERTISER_FORGETPASSWORD_SUCCESS, "", "", ""));
                        }
                        else
                        {
                            litMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
                        }
                    }
                    else
                    {
                        litMessage.Text = CommonFunction.GetResourceValue("ErrorNoAdvertiserFound");
                    }
                }
            }
            else if (!string.IsNullOrEmpty(tbUserName.Text.Trim()))
            {
                using (TList<Entities.AdvertiserUsers> userr = AdvertiserUsersService.GetByUserNameSiteId(tbUserName.Text, SessionData.Site.SiteId))
                {
                    if (userr.Count > 0)
                    {
                        Entities.AdvertiserUsers user = userr[0];
                        user.ValidateGuid = Guid.NewGuid();
                        user.LoginAttempts = 0;
                        user.LastAttemptDate = null;
                        user.Status = (int)PortalEnums.AdvertiserUser.UserStatus.Valid;

                        if (AdvertiserUsersService.Update(user))
                        {
                            MailService.SendAdvertiserForgottenPasswordEmail(user);
                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.ADVERTISER_FORGETPASSWORD_SUCCESS, "", "", ""));
                        }   
                    }
                    else
                    {
                        litMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
                    }
                }
            }
            else
            {
                litMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
            }


        }

        #endregion
    }
}
