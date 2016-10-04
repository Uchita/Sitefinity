using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Client.Salesforce;

namespace JXTPortal.Website.member
{
    public partial class ConfirmResetPassword : System.Web.UI.Page
    {
        #region Declarations

        private MembersService _membersService;
        private int _memberid = 0;
        private string _key = "";
        
        #endregion

        #region Properties

        protected int MemberID
        {
            get
            {
                if ((Request.QueryString["MemberID"] != null))
                {
                    if (int.TryParse((Request.QueryString["MemberID"].Trim()), out _memberid))
                    {
                        _memberid = Convert.ToInt32(Request.QueryString["MemberID"]);
                    }
                    return _memberid;
                }

                return _memberid;
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

        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Confirm Reset Password");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (MemberID == 0 || string.IsNullOrEmpty(Key))
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

        #endregion

        #region Method

        private void SetNewPassword()
        {
            Entities.Members members = MembersService.GetByMemberId(MemberID);

            if (members != null)
            {
                if (!members.ValidateGuid.HasValue)
                {
                    ltMessage.Visible = true;
                    ltMessage.SetLanguageCode = "LabelResetGUIDFailed";
                    pnlResetPassword.Visible = false;
                    return;
                }

                if (members.SiteId == SessionData.Site.MasterSiteId && Key.ToLower() == members.ValidateGuid.Value.ToString().ToLower())
                {
                    ltMessage.Visible = false;

                    if (members.Valid == false ||  members.Validated == false)
                    {
                        members.Valid = true;
                        members.Validated = true;

                        MembersService.Update(members);
                    }
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

        #endregion

        #region Events

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entities.Members member = MembersService.GetByMemberId(MemberID);
                
                // SALESFORCE - Update the details from Sales force
                if (GetFromSalesforceAndSave(member.EmailAddress, member.ExternalMemberId))
                {
                    member = MembersService.GetByMemberId(member.MemberId);
                }

                member.Password = CommonService.EncryptMD5(txtNewPassword.Text);
                member.LastLogon = DateTime.Now;
                member.Valid = true;
                member.Validated = true;
                member.ValidateGuid = null;
                member.RequiredPasswordChange = false;

                if (MembersService.Update(member))
                {
                    SessionService.RemoveAdvertiserUser();
                    SessionService.RemoveAdminUser();
                    SessionService.SetMember(member);

                    Response.Redirect("~/member/default.aspx");
                }
                else
                {
                    ltMessage.SetLanguageCode = CommonFunction.GetResourceValue("LabelResetFailed");
                }
            }
        }

        protected void CusValRetypePassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtNewPassword.Text == txtRetypePassword.Text);
        }

        #endregion



        #region SALESFORCE

        /// <summary>
        /// SALESFORCE - If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce AND send reset password email to member.
        /// </summary>
        /// <param name="strEmail"></param>
        private bool GetFromSalesforceAndSave(string strEmail, string SalesForceContactID)
        {
            SalesforceMemberSync memberSync = new SalesforceMemberSync();
            int memberid = 0; string errormsg = string.Empty;

            // Get Candidate from Salesforce by email
            // And If candidate exists in Sales force, save in Boardy platform.
            if (memberSync.GetContactFromSalesForceAndSave(strEmail, SalesForceContactID, SessionData.Site.MasterSiteId, ref memberid, ref errormsg) && memberid > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
