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

namespace JXTPortal.Website.advertiser
{
    public partial class ChangePwd : System.Web.UI.Page
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

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Change Password");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        #endregion

        #region Methods
        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId))
                {
                    advertiseruser.UserPassword = CommonFunction.EncryptMD5(tbNewPassword.Text);
                    AdvertiserUsersService.Update(advertiseruser);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }

        protected void CusVal_CurrentPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId))
            {
                args.IsValid = (CommonFunction.EncryptMD5(tbCurrentPassword.Text) == advertiseruser.UserPassword);
            }
        }

        protected void CusVal_ConfirmNewPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (tbNewPassword.Text == tbConfirmNewPassword.Text);
        }

        #endregion
    }
}
