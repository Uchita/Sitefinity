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
using JXTPortal.Entities;
using JXTPortal;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucAdvertiserChangePassword : System.Web.UI.UserControl
    {
        #region Declarations

        private AdvertiserUsersService _advertiserusersservice;

        #endregion

        #region Properties

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

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("login.aspx");
            }

            SetFormValues();
        }

        #endregion

        #region Methods

        private void SetFormValues()
        {
            ltlChangePwd.Text = CommonFunction.GetResourceValue("LabelChangePwd");

            ReqVal_CurrentPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorRequired");
            CusVal_CurrentPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorIncorrectCurrentPassword");
            ReqVal_NewPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorRequired");
            ReqVal_ConfirmNewPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorRequired");
            CusVal_ConfirmNewPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorConfirmPasswordNotMatch");
        }


        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ((JXTPortal.Website.advertiser.edit)Page).SelectedTabIndex = 2;
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId))
                {
                    advertiseruser.UserPassword = CommonService.EncryptMD5(tbNewPassword.Text);
                    AdvertiserUsersService.Update(advertiseruser);
                    litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelPwdChanged"));
                }
                //Response.Redirect("edit.aspx");
            }
        }

        protected void CusVal_CurrentPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId))
            {
                args.IsValid = (CommonService.EncryptMD5(tbCurrentPassword.Text) == advertiseruser.UserPassword);
            }
        }

        protected void CusVal_ConfirmNewPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (tbNewPassword.Text == tbConfirmNewPassword.Text);
        }

        #endregion
    }
}