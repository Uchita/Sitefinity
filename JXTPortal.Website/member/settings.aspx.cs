using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Client.Salesforce;

namespace JXTPortal.Website.members
{
    public partial class Settings : System.Web.UI.Page
    {
        #region Declare Variables

        private int memberID = 0;

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Settings");

            if (SessionData.Member == null)
            {
                Response.Redirect("login.aspx");
            }


            if (!IsPostBack)
            {
                loadForm();
            }

            SetFormValues();
            
        }

        #endregion

        #region "Properties"

        private SiteLanguagesService _sitelanguagesservice = null;
        public SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }

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


        protected void loadForm()
        {
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            memberID = Entities.SessionData.Member.MemberId;

            LoadSiteLangauge();

            using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
            {
                txtUsername.Text = CommonService.DecodeString(objMembers.Username.Trim());
                txtEmailAddress.Text = CommonService.DecodeString(objMembers.EmailAddress.Trim());

                if (!string.IsNullOrWhiteSpace(objMembers.SecondaryEmail))
                {
                    txtSecondaryEmailAddress.Text = CommonService.DecodeString(objMembers.SecondaryEmail.Trim());
                }

                this.radlEmailFormat.Items.FindByValue(Convert.ToString(objMembers.EmailFormat)).Selected = true;

                if (objMembers.DefaultLanguageId.HasValue)
                {
                    ddlLanguage.SelectedValue = objMembers.DefaultLanguageId.Value.ToString();
                }

            }
        }



        #region Click Event handlers

        protected void btnCloseAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/member/confirmdelete.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            memberID = Entities.SessionData.Member.MemberId;

            if (Page.IsValid)
            {
                string sfContactID;

                #region Update to Database
                using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
                {
                    sfContactID = objMembers.ExternalMemberId;

                    objMembers.EmailFormat = Convert.ToInt32(radlEmailFormat.SelectedValue);
                    objMembers.LastModifiedDate = DateTime.Now.Date;

                    // objMembers.EmailAddress = txtEmailAddress.Text;
                    objMembers.SecondaryEmail = txtSecondaryEmailAddress.Text;

                    objMembers.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);

                    if (!string.IsNullOrWhiteSpace(txtMemberNewPassword.Text))
                    {
                        using (Entities.Members members = MembersService.GetByMemberId(SessionData.Member.MemberId))
                        {
                            members.Password = CommonService.EncryptMD5(txtMemberNewPassword.Text);
                            members.RequiredPasswordChange = false;
                            MembersService.Update(members);
                        }
                    }

                    /*
                    objMembers.SearchField = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}",
                                                objMembers.FirstName,
                                                objMembers.Surname,
                                                Utils.CleanStringSpaces(objMembers.Address1),
                                                strCountry,
                                                strLocation,
                                                strArea,
                                                radlGender.SelectedItem.Text,
                                                strProfession,
                                                strRole,
                                                (ddlEducation.SelectedValue == "0") ? "" : ddlEducation.SelectedItem.Text,
                                                strDesiredPay,
                                                Utils.CleanStringSpaces(objMembers.Tags));*/
                    //Update members
                    MembersService.Update(objMembers);

                    // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce.
                    SalesforceMemberSync memberSync = new SalesforceMemberSync(SessionData.Site.SiteId);
                    memberSync.CheckContactAndSaveInSalesForce(objMembers, objMembers.SiteId);


                    if (!string.IsNullOrWhiteSpace(txtMemberNewPassword.Text))
                        ltlMessage.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelPwdChanged"), BootstrapAlertType.Success);
                    else                    
                        ltlMessage.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelMemberEditSuccess"), BootstrapAlertType.Success);
                }

                #endregion



            }
        }


        #endregion

        private void LoadSiteLangauge()
        {
            using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                phLanguage.Visible = (sitelanguages.Count > 1);
                //phMultiLingual.Visible = (sitelanguages.Count > 1);
                ddlLanguage.Items.Clear();
                foreach (SiteLanguages sitelang in sitelanguages)
                {
                    ddlLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));
                }
            }
        }

        protected void CusVal_CurrentPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(txtMemberCurrentPassword.Text))
            {
                using (Entities.Members members = MembersService.GetByMemberId(SessionData.Member.MemberId))
                {
                    args.IsValid = (CommonService.EncryptMD5(txtMemberCurrentPassword.Text) == members.Password);                    
                }

                if (!string.IsNullOrWhiteSpace(txtMemberCurrentPassword.Text) && !string.IsNullOrWhiteSpace(txtMemberCurrentPassword.Text))
                {
                    revPassword.Text = CommonFunction.GetResourceValue("LabelPasswordNotMatch"); 
                }
            }
        }

        protected void CusVal_ConfirmNewPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (txtMemberNewPassword.Text == txtMemberConfirmNewPassword.Text);
            //CusVal_CurrentPassword.Text = CommonFunction.GetResourceValue("revPassword"); 
        }


        public void SetFormValues()
        {
            //btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
            this.radlEmailFormat.Items[0].Text = CommonFunction.GetResourceValue("LabelHTML");
            this.radlEmailFormat.Items[1].Text = CommonFunction.GetResourceValue("LabelText");

            revPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelPasswordPrompt");
            
            this.radlEmailFormat.Items[0].Text = CommonFunction.GetResourceValue("LabelHTML");
            this.radlEmailFormat.Items[1].Text = CommonFunction.GetResourceValue("LabelText");

            revSecondaryEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");

            btnSave.Text = CommonFunction.GetResourceValue("ButtonSave");
            btnCloseAccount.Text = CommonFunction.GetResourceValue("LabelCloseMyAccount");
        }

    }
}
