using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.members
{
    public partial class ConfirmDelete : System.Web.UI.Page
    {
        #region 
        private MembersService _membersService;
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

        private MemberFilesService _memberFilesService;
        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberFilesService == null)
                {
                    _memberFilesService = new MemberFilesService();
                }
                return _memberFilesService;
            }
        }

        #endregion
        #region Page Event handlers


        protected void Page_Load(object sender, EventArgs e)
        {
            //Members only
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            CommonPage.SetBrowserPageTitle(Page, "Member Edit");

        }

        #endregion

        #region Click Event handlers

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/member/settings.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if( SessionData.Member == null )
                    Response.Redirect("/member/login.aspx");

                //check password inputs again (incase)
                if (!txtCurrentPassword.Text.Equals(txtConfirmPassword.Text))
                    Response.Redirect("/member/login.aspx");

                int currentMemberID = SessionData.Member.MemberId;
                if (!EnteredPasswordForMemberIsCorrect(currentMemberID, txtCurrentPassword.Text) )
                {
                    ltErrorMessage.Text = "Account closure failed. Incorrect password";
                    return;
                }

                //updates all the account details (ie removing it)
                MembersService.MemberAccountClosure(currentMemberID);

                //Remove files associated with the account
                MemberFilesService.MemberAccountClosure(currentMemberID);

                // BULLHORN close account
                string errorMsg = string.Empty;
                BullhornRESTAPI bullhornRestAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                bullhornRestAPI.BHCloseCandidate(currentMemberID, out errorMsg);

                Response.Redirect("/logout.aspx");
            }
        }
        #endregion


        #region Private Methods

        private bool EnteredPasswordForMemberIsCorrect(int memberID, string password)
        {
            Entities.Members member = MembersService.GetByMemberId(memberID);
            //check password against record
            string encrpytedEnteredPassword = CommonService.EncryptMD5(password);

            return member.Password.Equals(encrpytedEnteredPassword);
        }

        #endregion

    }
}
