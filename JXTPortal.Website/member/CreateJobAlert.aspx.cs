using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Text.RegularExpressions;

namespace JXTPortal.Website.members
{
    public partial class CreateJobAlert : System.Web.UI.Page
    {
        #region Declare variables
        private string ContentValidationRegex = ConfigurationManager.AppSettings["ContentValidationRegex"];

        private JobAlertsService _jobAlertsService;
        private MembersService _membersService = null;

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

        #region Properties

        private bool IsFav
        {
            get
            {
                return (Request.QueryString["isfav"] == "1");
            }
        }

        private bool RetainSearch
        {
            get
            {
                return (Request.QueryString["retainsearch"] == "1");

            }
        }
        public int JobAlertID
        {
            get
            {
                int _id = -1;

                if (Request.QueryString["id"] != null &&
                    !string.IsNullOrEmpty(Request.QueryString["id"]) &&
                    Int32.TryParse(Request.QueryString["id"], out _id))
                {
                    _id = Convert.ToInt32(Request.QueryString["id"]);
                }

                return _id;

            }
        }

        private JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                {
                    _jobAlertsService = new JobAlertsService();
                }
                return _jobAlertsService;
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

        private GlobalSettingsService _globalSettingsService;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                    _globalSettingsService = new GlobalSettingsService();
                return _globalSettingsService;
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {

            string multisiteids = ConfigurationManager.AppSettings["MultiSiteIDs"];

            if (multisiteids.Contains(string.Format(" {0} ", SessionData.Site.MasterSiteId)))
            {
                Response.Redirect("/member/jobalert.aspx");
            }


            //CommonPage.SetBrowserPageTitle(Page, "Create Job Alert");
            pnlLogin.Visible = (SessionData.Member == null);
            if (SessionData.Member != null)
            {
                using (Entities.JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
                {
                    if (jobAlert != null && jobAlert.JobAlertId > 0 && jobAlert.MemberId == SessionData.Member.MemberId)
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditJobAlert"));
                            CommonPage.SetBrowserPageTitle(Page, "Edit Job Alert");
                        }
                        else
                        {
                            ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditFavouriteSearch"));
                            CommonPage.SetBrowserPageTitle(Page, "Edit Favourite Search");

                        }
                    }
                }
            }
            if (IsFav)
            {
                ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelCreateFavouriteSearch"));
                //CommonPage.SetBrowserPageTitle(Page, "Create Favourite Search");
            }
            else
            {
                ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelCreateJobAlert"));
                //CommonPage.SetBrowserPageTitle(Page, "Create Job Alert");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (JobAlertID > 0)
                {
                    if (Entities.SessionData.Member != null)
                    {
                        MembersService service = new MembersService();
                        bool blnResult = false;
                        using (Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId))
                        {
                            if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                                blnResult = true;
                        }

                        if (blnResult)
                        {
                            Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                        }
                    }
                    else
                    {
                        Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                        return;
                    }

                    LoadJobAlert();
                    //enable delete button
                    btnDelete.Visible = true;
                    //btnSendJobAlert.Visible = true;
                    btnDelete.CommandArgument = JobAlertID.ToString();
                    //btnSendJobAlert.CommandArgument = JobAlertID.ToString();
                }
                else
                {
                    // When creating disable and check
                    //chkReceiveEmails.Enabled = false;
                    //chkReceiveEmails.Checked = true;
                    chkSendEmailAlerts.Checked = true;

                }
            }

            SetFormValues();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Page Unload Script", @"
            <script type='text/javascript'>
            $(document).ready(function() {
                //call custom function if any
                if (typeof CustomFunction == 'function') { 
                  CustomFunction('member/createjobalert.aspx'); 
                }
            });
            </script>
            ", false);
        }

        protected void LoadJobAlert()
        {

            using (Entities.JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
            {
                if (jobAlert != null && jobAlert.JobAlertId > 0 && jobAlert.MemberId == SessionData.Member.MemberId)
                {
                    // Load Job Alert
                    ucJobAlert1.SearchKeywords = jobAlert.SearchKeywords;
                    ucJobAlert1.ProfessionId = jobAlert.ProfessionId;

                    if (!String.IsNullOrEmpty(jobAlert.SearchRoleIds))
                        ucJobAlert1.SearchRoleIds = jobAlert.SearchRoleIds;

                    ucJobAlert1.LocationID = jobAlert.LocationId;

                    if (!String.IsNullOrEmpty(jobAlert.AreaIds))
                        ucJobAlert1.AreaIds = jobAlert.AreaIds;

                    if (!String.IsNullOrEmpty(jobAlert.WorkTypeIds))
                        ucJobAlert1.WorkTypeIds = Convert.ToInt32(jobAlert.WorkTypeIds);

                    if (jobAlert.SalaryTypeId.HasValue)
                    {
                        ucJobAlert1.SalaryTypeId = jobAlert.SalaryTypeId;
                    }

                    //if (jobAlert.CurrencyId.HasValue)
                    {
                        if (jobAlert.SalaryLowerBand.HasValue)
                        {
                            ucJobAlert1.SalaryLowerBand = string.Format("{0}", jobAlert.SalaryLowerBand);
                        }

                        if (jobAlert.SalaryUpperBand.HasValue)
                        {
                            ucJobAlert1.SalaryUpperBand = string.Format("{0}", jobAlert.SalaryUpperBand);
                        }
                    }

                    txtNameOfTheFeed.Text = CommonService.DecodeString(jobAlert.JobAlertName);
                    chkSendEmailAlerts.Checked = jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value ? true : false;
                    //chkMainAlert.Checked = (jobAlert.PrimaryAlert.HasValue ? true : false);
                    //chkReceiveEmails.Checked = (jobAlert.AlertActive.HasValue ? true : false);

                    //chkTermsAndConditions.Checked = true;
                    ucJobAlert1.SetSalary();

                    if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                    {
                        ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditJobAlert"));
                        CommonPage.SetBrowserPageTitle(Page, "Edit Job Alert");
                    }
                    else
                    {
                        ucSystemDynamicPage.Text = string.Format(ucSystemDynamicPage.Text, CommonFunction.GetResourceValue("LabelEditFavouriteSearch"));
                        CommonPage.SetBrowserPageTitle(Page, "Edit Favourite Search");
                    }
                }
                else
                {
                    Response.Redirect("~/member/createjobalert.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entities.JobAlerts jobAlert = new JXTPortal.Entities.JobAlerts();

            if (SessionData.Member == null && pnlLogin.Visible == false)
            {
                Response.Redirect("~/member/createjobalert.aspx");
            }

            if (JobAlertID > 0)
            {

                using (jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
                {
                    if (jobAlert == null || SessionData.Member == null)
                    {
                        Response.Redirect("~/member/createjobalert.aspx");
                    }
                    else
                    {
                        if (jobAlert != null && SessionData.Member != null && jobAlert.MemberId != SessionData.Member.MemberId)
                        {
                            Response.Redirect("~/member/createjobalert.aspx");
                        }
                    }
                }

            }


            String strError = string.Empty;

            ltlMessage.Text = String.Empty;

            if (!ucJobAlert1.IsValid(ref strError))
            {
                ltlMessage.Text = String.Format("{0}{1}", ltlMessage.Text, strError);
            }

            if (pnlLogin.Visible)
            {
                if (string.IsNullOrEmpty(tbFirstName.Text.Trim()))
                {
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelFirstNameMandatory"));
                }
                else
                {
                    if (Regex.IsMatch(tbFirstName.Text, ContentValidationRegex) == false)
                    {
                        ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("ValidateNoHTMLContent"));
                    }
                }

                if (string.IsNullOrEmpty(tbSurname.Text.Trim()))
                {
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelSurameMandatory"));
                }
                else
                {
                    if (Regex.IsMatch(tbSurname.Text, ContentValidationRegex) == false)
                    {
                        ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("ValidateNoHTMLContent"));
                    }
                }

                if (string.IsNullOrEmpty(tbEmail.Text.Trim()))
                {
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailMandatory"));
                }
                else
                {
                    if (!Common.Utils.VerifyEmail(tbEmail.Text.Trim()))
                        ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailInvalid"));
                }
                if (!string.IsNullOrEmpty(tbEmail.Text.Trim()))
                {
                    using (JXTPortal.Entities.Members member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, tbEmail.Text.Trim()))
                    {
                        if (member != null)
                        {
                            ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelEmailAlreadyExist"));
                        }
                    }
                }

                if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
                {
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("labellPasswordRequired"));
                }
                else
                {
                    string pattern = @"^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
                    if (!Regex.Match(tbPassword.Text, pattern).Success)
                    {
                        ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelPasswordPrompt") );
                    }
                }
            }

            if (txtNameOfTheFeed.Text.Trim().Length < 1)
            {
                ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("LabelNameFeedMandatory"));
            }
            else
            {
                if (Regex.IsMatch(txtNameOfTheFeed.Text, ContentValidationRegex) == false)
                {
                    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("ValidateNoHTMLContent"));
                }
            }

            //if (!chkTermsAndConditions.Checked)
            //{
            //    ltlMessage.Text = String.Format("{0}<li>{1}</li>", ltlMessage.Text, CommonFunction.GetResourceValue("ErrorAcceptTermCondition"));
            //}

            if (ltlMessage.Text.Length < 1)
            {
                jobAlert.SearchKeywords = Common.Utils.StripHTML(ucJobAlert1.SearchKeywords);
                jobAlert.ProfessionId = ucJobAlert1.ProfessionId;
                jobAlert.SearchRoleIds = ucJobAlert1.SearchRoleIds;
                jobAlert.LocationId = ucJobAlert1.LocationID;
                jobAlert.AreaIds = ucJobAlert1.AreaIds;
                jobAlert.WorkTypeIds = (ucJobAlert1.WorkTypeIds.HasValue ? ucJobAlert1.WorkTypeIds.ToString() : null);
                jobAlert.SalaryTypeId = ucJobAlert1.SalaryTypeId;
                jobAlert.CurrencyId = null; //(string.IsNullOrEmpty(ucJobAlert1.SalaryLowerBand)) ? (int?)null : Convert.ToInt32(ucJobAlert1.SalaryLowerBand.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[0])
                jobAlert.SalaryLowerBand = CommonFunction.GetSalaryDecimalAmount(ucJobAlert1.SalaryLowerBand);
                jobAlert.SalaryUpperBand = CommonFunction.GetSalaryDecimalAmount(ucJobAlert1.SalaryUpperBand);

                if (SessionData.Member == null)
                {
                    using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                    {
                        objMembers.SiteId = SessionData.Site.MasterSiteId;
                        objMembers.FirstName = CommonService.EncodeString(tbFirstName.Text);
                        objMembers.Surname = CommonService.EncodeString(tbSurname.Text);
                        objMembers.EmailAddress = CommonService.EncodeString(tbEmail.Text.Trim());
                        objMembers.Password = CommonService.EncryptMD5(tbPassword.Text);
                        objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        objMembers.Username = CommonService.EncodeString(tbEmail.Text);
                        objMembers.CountryId = 1;

                        TList<GlobalSettings> service = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
                        if (service.Count > 0)
                        {
                            if (service[0].DefaultCountryId.HasValue)
                            {
                                objMembers.CountryId = service[0].DefaultCountryId.Value;
                            }
                        }

                        objMembers.ValidateGuid = Guid.NewGuid();
                        objMembers.ReferringSiteId = SessionData.Site.SiteId;
                        objMembers.SearchField = String.Format("{0} {1}",
                                                   objMembers.FirstName,
                                                   objMembers.Surname);
                        MembersService.Insert(objMembers);

                        //Send confirmation email
                        //MailService.SendNewJobApplicationAccount(objMembers, newpassword);
                        MailService.SendMemberRegistration(objMembers, tbPassword.Text);

                        //Send member registration alert email to admin
                        if (!string.IsNullOrEmpty(SessionData.Site.MemberRegistrationNotificationEmail))
                            MailService.SendMemberRegistrationToSiteAdmin(objMembers, string.Empty , string.Empty, null, SessionData.Site.MemberRegistrationNotificationEmail);

                        jobAlert.MemberId = objMembers.MemberId;
                        jobAlert.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    }
                }
                else
                {
                    jobAlert.MemberId = SessionData.Member.MemberId;
                    jobAlert.EmailFormat = SessionData.Member.EmailFormat;
                }

                // Save Job Alert
                // ToDo - Insert - Update 
                jobAlert.JobAlertName = CommonService.EncodeString(txtNameOfTheFeed.Text.Trim());
                jobAlert.PrimaryAlert = false;
                jobAlert.AlertActive = chkSendEmailAlerts.Checked;

                bool isInserted = false;
                if (JobAlertID > 0)
                {
                    JobAlertsService.Update(jobAlert);
                    isInserted = false;
                }
                else
                {
                    jobAlert.UnsubscribeValidateId = Guid.NewGuid();
                    jobAlert.EditValidateId = Guid.NewGuid();
                    jobAlert.ViewValidateId = Guid.NewGuid();

                    JobAlertsService.Insert(jobAlert);
                    isInserted = true;
                }

                // Redirect to list page
                if (SessionData.Member == null)
                {
                    //if (Convert.ToString(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", "")) == "")
                    if (DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", "") == null || (DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_REGISTRATION_SUCCESS, "", "", "")).Length == 0)
                        ltlMessage.Text = String.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"));
                    //ltlalertsuccess.Text = Convert.ToString(CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"));
                    else
                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_CREATE_SUCCESS, "", "", ""));
                    pnlJobAlert.Visible = false;
                    return;
                }
                else
                {
                    if (isInserted)
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=1");
                        }
                        else
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=3");
                        }
                    }
                    else
                    {
                        if (jobAlert.AlertActive.HasValue && jobAlert.AlertActive.Value)
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=2");
                        }
                        else
                        {
                            Response.Redirect("~/member/myjobalerts.aspx?msg=4");
                        }
                    }
                }
            }

            if (ltlMessage.Text.Length > 0)
                ltlMessage.Text = String.Format("<div class='form-error-message'><ul>{0}</ul></div>", ltlMessage.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;

            JobAlertsService.Delete(Convert.ToInt32(string.Format("{0}", thisButton.CommandArgument)));

            Response.Redirect("~/member/myjobalerts.aspx");
        }
        /*
        protected void btnSendJobAlert_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            // Convert.ToInt32(string.Format("{0}", thisButton.CommandArgument))

            JobAlertEmailService jobalertEmailService = new JobAlertEmailService();
            bool blnSuccess = jobalertEmailService.SendJobAlertEmail(SessionData.Site.SiteId, Convert.ToInt32(thisButton.CommandArgument));

            if (blnSuccess)
                ltlMessage.Text = String.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelEmailSuccess"));  
        }
        */
        public void SetFormValues()
        {

            btnSave.Text = CommonFunction.GetResourceValue("ButtonSave");
            btnDelete.Text = CommonFunction.GetResourceValue("LabelDelete");
            //btnSendJobAlert.Text = CommonFunction.GetResourceValue("LabelSendaJobAlertNow");

            //chkReceiveEmails.Text = CommonFunction.GetResourceValue("LabelRequestAlertEmail");
            //pnlSendEmailAlerts.Visible = !IsFav;
            if (JobAlertID < 0)
            {
                chkSendEmailAlerts.Checked = !IsFav;
            }

            if (RetainSearch)
            {
                txtNameOfTheFeed.Focus();
            }
        }


    }
}
