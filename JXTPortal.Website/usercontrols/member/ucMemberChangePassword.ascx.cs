using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberChangePassword : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;

        #endregion

        #region "Properties"

        MembersService _membersService;
        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("login.aspx");
            }

            SetFormValues();
        }

        #endregion

        #region Methods
        #endregion

        #region Click Event handlers

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //((JXTPortal.Website.members._default)Page).SelectedTabIndex = 4;

            if (Page.IsValid)
            {
                using (Entities.Members members = MembersService.GetByMemberId(SessionData.Member.MemberId))
                {
                    members.Password = CommonService.EncryptMD5(txtMemberNewPassword.Text);
                    members.RequiredPasswordChange = false;
                    MembersService.Update(members);
                    litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelPwdChanged"));
                }

                if (!string.IsNullOrEmpty(Request.Params["ReturnUrl"]))
                {
                    Response.Redirect(Request.Params["ReturnUrl"]);
                }

                //((JXTPortal.Website.members._default)Page).SelectedTabIndex = 3;


            }
        }

        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("default.aspx");
        //}

        protected void CusVal_CurrentPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (Entities.Members members = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                args.IsValid = (CommonService.EncryptMD5(txtMemberCurrentPassword.Text) == members.Password);
            }
        }

        protected void CusVal_ConfirmNewPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtMemberNewPassword.Text == txtMemberConfirmNewPassword.Text);
        }

        #endregion

        public void SetFormValues()
        {
            btnSave.Text = CommonFunction.GetResourceValue("ButtonSave");
            ReqVal_CurrentPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            CusVal_CurrentPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorIncorrectCurrentPassword");
            ReqVal_NewPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_ConfirmNewPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelConfirmNewPassword");
            CusVal_ConfirmNewPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorConfirmPasswordNotMatch");

        }

    }
}