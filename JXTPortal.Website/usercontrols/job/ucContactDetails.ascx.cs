using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucContactDetails : System.Web.UI.UserControl
    {
        public event System.EventHandler OptionChanged;
        private MembersService _memebrsService;

        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListItem li = new ListItem(CommonFunction.GetResourceValue("LabelJustApply"), "JustApply");
                li.Selected = true;
                rbOptions.Items.Add(li);

                rbOptions.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelAlreadyRegistered"), "Login"));
            }
            
            SetFormValues();       
        }

        public void SetFormValues()
        {
            ReqVal_FirstName.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            ReqVal_Surname.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            ReqVal_Phone.ErrorMessage = CommonFunction.GetResourceValue("LabelPhoneRequired");
            ReqVal_Email.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            CusVal_Email.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
        }

        public JXTPortal.Entities.Members Save()
        {
            JXTPortal.Entities.Members member = null;

            if (SessionData.Member == null)
            {
                member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, tbEmail.Text.Trim());
                if (member != null)
                {
                    member.FirstName = tbFirstName.Text;
                    member.Surname = tbSurname.Text;
                    member.MobilePhone = tbPhone.Text;
                    member.SearchField = String.Format("{0} {1} {2}",
                                               member.FirstName,
                                               member.Surname,
                                               member.SearchField);

                    MembersService.Update(member);
                }
                else
                {
                    member = MembersService.GetBySiteIdUsername (SessionData.Site.MasterSiteId, tbEmail.Text.Trim());
                    if (member != null)
                    {
                        litMessage.Text = CommonFunction.GetResourceValue("LabelUsernameExists");
                        return null;
                    }
                }

            }

            if (member == null)
            {
                member = new JXTPortal.Entities.Members();
                string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                member.FirstName = tbFirstName.Text.Trim();
                member.Surname = tbSurname.Text.Trim();
                member.Username = tbEmail.Text.Trim();
                member.EmailAddress = tbEmail.Text.Trim();
                member.MobilePhone = tbPhone.Text.Trim();
                member.RequiredPasswordChange = true;
                member.EmailFormat = 1;
                member.CountryId = 1;
                member.SiteId = SessionData.Site.MasterSiteId;
                member.ValidateGuid = Guid.NewGuid();
                member.Password = CommonService.EncryptMD5(newpassword);
                member.MonthlyUpdate = true;
                member.Validated = true;
                member.Valid = true;
                member.ReferringSiteId = SessionData.Site.SiteId;
                member.SearchField = String.Format("{0} {1}",
                                               member.FirstName,
                                               member.Surname);

                MembersService.Insert(member);

                MailService.SendNewJobApplicationAccount(member, newpassword);
            }

            return member;
        }

        private bool LoginCheck()
        {
            bool valid = false;

            using (JXTPortal.Entities.Members member = MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, txtUserName.Text))
            {
                if (member != null && member.Valid && member.Validated && member.Password == CommonService.EncryptMD5(txtPassword.Text))
                {
                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);
                    valid = true;
                }
            }

            return valid;
        }

        private void UpdateLastLoginDate()
        {
            using (Entities.Members objMembers = MembersService.GetByMemberId(SessionData.Member.MemberId))
            {
                objMembers.LastLogon = DateTime.Now;
                MembersService.Update(objMembers);
            }
        }

        protected void CusVal_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string EmailAddress = tbEmail.Text.Trim();
            bool validEmail = Regex.IsMatch(EmailAddress, @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$");
            args.IsValid = validEmail;
        }

        protected void rbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbOptions.SelectedValue == "JustApply")
            {
                pnlContactDetails.Visible = true;
                pnlLogin.Visible = false;
            }
            else
            {
                pnlContactDetails.Visible = false;
                pnlLogin.Visible = true;
            }

            if (OptionChanged != null)
            {
                OptionChanged(sender, e);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {
                //Update Last Login date
                UpdateLastLoginDate();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ltErrorMessage.Text = CommonFunction.GetResourceValue("LabelAccessDenied");
            }
        }

        protected void CusVal_Phone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbPhone.Text.Length > 40)
            {
                CusVal_Phone.ErrorMessage = CommonFunction.GetResourceValue("ErrorPhoneSize");
                args.IsValid = false;
            }
        }
    }
}