using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using JXTPortal.Client.Salesforce;

namespace JXTPortal.Website.member
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        #region Properties

        private MembersService _membersService = null;
        private MembersService MembersService
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
            CommonPage.SetBrowserPageTitle(Page, "Member Retrieve Password");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ltMessage.Text = "";
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
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) && string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                ltMessage.Text = CommonFunction.GetResourceValue("ErrorEnterEmailUsername");
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                using (Entities.Members members = MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, txtEmail.Text.Trim()))
                {
                    if (members != null)
                    {
                        members.ValidateGuid = Guid.NewGuid();
                        members.LoginAttempts = 0;
                        members.LastAttemptDate = null;
                        members.Status = (int)PortalEnums.Members.UserStatus.Valid;
                        if (MembersService.Update(members))
                        {
                            MailService.SendMemberForgottenPasswordEmail(members);
                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_FORGETPASSWORD_SUCCESS, "", "", ""));
                        }
                        else
                        {
                            ltMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
                        }
                    }
                    else
                    {
                        // Sales Force Integration for Mining People
                        GetFromSalesforceAndSave(txtEmail.Text.Trim());
                    }
                }
            }
            else if (!string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                using (Entities.Members members = MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, txtUsername.Text.Trim()))
                {
                    if (members != null)
                    {
                        members.ValidateGuid = Guid.NewGuid();
                        members.LoginAttempts = 0;
                        members.LastAttemptDate = null;
                        members.Status = (int)PortalEnums.Members.UserStatus.Valid;

                        if (MembersService.Update(members))
                        {
                            MailService.SendMemberForgottenPasswordEmail(members);
                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_FORGETPASSWORD_SUCCESS, "", "", ""));
                        }
                        else
                        {
                            ltMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
                        }
                    }
                    else
                    {
                        // Sales Force Integration for Mining People
                        GetFromSalesforceAndSave(txtUsername.Text.Trim());
                    }
                }
            }
            else
            {
                ltMessage.Text = CommonFunction.GetResourceValue("ErrorEnterDetailAgain");
            }
        }

        #endregion


        #region SALESFORCE

        /// <summary>
        /// If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce AND send reset password email to member.
        /// </summary>
        /// <param name="strEmail"></param>
        private bool GetFromSalesforceAndSave(string strEmail)
        {
            // *********** SALESFORCE ***********
            SalesforceMemberSync memberSync = new SalesforceMemberSync();
            int memberid = 0; string errormsg = string.Empty;

            // Get Candidate from Salesforce by email
            // And If candidate exists in Sales force, save in Boardy platform.
            if (memberSync.GetContactFromSalesForceAndSave(strEmail, string.Empty, SessionData.Site.MasterSiteId, ref memberid, ref errormsg) && memberid > 0)
            {
                using (Entities.Members members = MembersService.GetByMemberId(memberid))
                {
                    // Send the user the reset password email to change his password.
                    MailService.SendMemberForgottenPasswordEmail(members);
                }

                Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_FORGETPASSWORD_SUCCESS, "", "", ""));

            }
            else
                ltMessage.Text = CommonFunction.GetResourceValue("ErrorNoMemberFound");


            return false;
        }

        #endregion
    }
}
