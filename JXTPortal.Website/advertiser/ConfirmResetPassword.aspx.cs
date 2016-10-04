using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class ConfirmResetPassword : System.Web.UI.Page
    {
        #region Declarations
        private AdvertiserUsersService _advertiserusersservice;
        private AdvertisersService _advertisersservice;
        private int _advertiseruserid = 0;
        private string _key = "";
        #endregion

        #region Properties

        protected int AdvertiserUserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserUserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserUserID"].Trim()), out _advertiseruserid))
                    {
                        _advertiseruserid = Convert.ToInt32(Request.QueryString["AdvertiserUserID"]);
                    }
                    return _advertiseruserid;
                }

                return _advertiseruserid;
            }
        }

        protected string Key
        {
            get
            {
                if ((Request.QueryString["key"] != null))
                {
                    _key = Request.QueryString["key"];
                    return _key;
                }

                return _key;
            }
        }

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersservice == null)
                {
                    _advertiserusersservice = new AdvertiserUsersService();
                }
                return _advertiserusersservice;
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

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Confirm Reset Password");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AdvertiserUserID == 0 || string.IsNullOrEmpty(Key))
            {
                pnlResetPassword.Visible = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                SetNewPassword();
            }
            SetFormValues();

        }

        public void SetFormValues()
        {
            btnReset.Text = CommonFunction.GetResourceValue("ButtonReset");
            ReqValNewPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqValRetypePassword.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            CusValRetypePassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorConfirmPasswordNotMatch");
        }

        private void SetNewPassword()
        {
            Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID);
            if (user != null)
            {
                Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(user.AdvertiserId);
                if (!user.ValidateGuid.HasValue)
                {
                    ltMessage.Visible = true;
                    ltMessage.SetLanguageCode = "LabelResetGUIDFailed";
                    pnlResetPassword.Visible = false;
                    return;
                }

                if (advertiser.SiteId == SessionData.Site.SiteId && Key.ToLower() == user.ValidateGuid.Value.ToString().ToLower())
                {
                    ltMessage.Visible = false;
                }
                else
                {
                    pnlResetPassword.Visible = false;
                }
            }
            else
            {
                pnlResetPassword.Visible = false;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID);
                user.UserPassword = CommonService.EncryptMD5(tbNewPassword.Text);
                user.LastLoginDate = DateTime.Now;
                user.ValidateGuid = null;
                user.Validated = true; // validate the person when he resets the password.
                if (AdvertiserUsersService.Update(user))
                {
                //    SessionService.RemoveMember();
                //    SessionService.RemoveAdminUser();
                //    SessionService.SetAdvertiserUser(user);

                    Response.Redirect("~/advertiser/login.aspx?msg=1");
                }
                else
                {
                    ltMessage.SetLanguageCode = CommonFunction.GetResourceValue("LabelResetFailed");
                }
            }
        }

        protected void CusValRetypePassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (tbNewPassword.Text == tbRetypePassword.Text);
        }
    }
}
