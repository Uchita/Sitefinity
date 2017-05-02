using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using JXTPortal.Entities;

namespace JXTPortal.Website.member
{
    public partial class EmailFriend : System.Web.UI.Page
    {
        #region Declaration

        private JobsService _jobsService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;
        private AreaService _areaService;
        private SiteLocationService _siteLocationService;
        private int _jobid;
        private string _professionProfessionFriendlyName;

        #endregion

        #region Properties


        private ViewJobsService _viewJobsService;

        private ViewJobsService ViewJobsService
        {
            get
            {
                if (_viewJobsService == null)
                    _viewJobsService = new ViewJobsService();
                return _viewJobsService;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobAreaService == null)
                {
                    _jobAreaService = new JobAreaService();
                }
                return _jobAreaService;
            }
        }

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobRolesService == null)
                {
                    _jobRolesService = new JobRolesService();
                }
                return _jobRolesService;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                {
                    _areaService = new AreaService();
                }
                return _areaService;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                {
                    _siteLocationService = new SiteLocationService();
                }
                return _siteLocationService;
            }
        }

        protected int JobID
        {
            get
            {
                if ((Request.QueryString["JobID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobID"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["JobID"]);
                    }
                    return _jobid;
                }

                return _jobid;
            }
        }

        protected string ProfessionFriendlyName
        {
            get
            {
                if (Request.QueryString["profession"] != null)
                {
                    _professionProfessionFriendlyName = Request.QueryString["profession"];
                }
                return _professionProfessionFriendlyName;
            }
        }

        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CommonPage.SetBrowserPageTitle(Page, "Email Friend");
                plGooleReCaptcha.Attributes.Add("data-sitekey", GoogleReCaptcha.SiteKey);
                plGooleReCaptcha.Attributes.Add("data-stoken", GoogleReCaptcha.SecureTokenGet());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;

            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    hfBackUrl.Value = Request.UrlReferrer.OriginalString;
                }

                LoadJobDetails();
            }

            SetFormValues();

        }

        public void SetFormValues()
        {
            rfvYourName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvYourEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            cvYourEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            rfvYourFriendName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvYourFriendEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            cvYourFriendEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            btnBack.Text = CommonFunction.GetResourceValue("ButtonBack");
            btnSend.Text = CommonFunction.GetResourceValue("ButtonSend");
            cbEmailJobToAFriend.Text = CommonFunction.GetResourceValue("LabelEmailJobToAFriend");

        }

        #endregion

        #region Methods

        private void LoadJobDetails()
        {
            if (JobID > 0)
            {
                Entities.Jobs job = JobsService.GetByJobId(JobID);
                if (job != null)
                {
                    litJobTitle.Text = job.JobName;
                }
                else
                {
                    Response.Redirect("~/advancedsearch.aspx");
                }
            }
            else
            {
                Response.Redirect("~/advancedsearch.aspx");
            }
        }

        #endregion

        #region Events

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfBackUrl.Value) && Request.UrlReferrer.OriginalString != hfBackUrl.Value)
            {
                Response.Redirect(hfBackUrl.Value);
            }
            else
            {
                Response.Redirect("~/advancedsearch.aspx");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //reset the captcha message
            captchaReqMsg.Visible = false;

            bool GoogleCaptchaValid = ValidateGoogleCaptcha();

            if (!GoogleCaptchaValid)
            {
                captchaReqMsg.Visible = true;
                return;
            }

            if (Page.IsValid)
            {
                string JobUrl = "";

                if (!string.IsNullOrEmpty(tbYourEmail.Text))
                {
                    if (!CommonFunction.VerifyEmail(tbYourEmail.Text))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                if (cbEmailJobToAFriend.Checked)
                {
                    if (string.IsNullOrEmpty(tbYourFriendEmail.Text) == false)
                    {
                        if (!CommonFunction.VerifyEmail(tbYourFriendEmail.Text))
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }


                using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(JobID, SessionData.Site.SiteId))
                {
                    if (jobs.Count > 0)
                    {

                        JobUrl = Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName);
                        MailService.SendMemberJobEmail(tbYourName.Text, tbYourEmail.Text, jobs[0].JobName, JobUrl, (int)PortalEnums.Email.EmailFormat.HTML, SessionData.Language.LanguageId);

                        if (cbEmailJobToAFriend.Checked)
                        {
                            MailService.SendFriendJobEmail(tbYourName.Text, tbYourEmail.Text, tbYourFriendName.Text, tbYourFriendEmail.Text, tbMessageForYourFriend.Text, jobs[0].JobName, JobUrl, SessionData.Language.LanguageId);
                        }

                        litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelEmailFriendSuccess"), jobs[0].JobName);
                        pnlSend.Visible = false;
                        btnSend.Visible = false;
                    }
                }

                /*Entities.Jobs job = JobsService.GetByJobId(JobID);
                Entities.JobArea jobarea = JobAreaService.GetByJobId(job.JobId)[0];
                Entities.Area area = AreaService.GetByAreaId(jobarea.AreaId);
                Entities.JobRoles jobroles = JobRolesService.GetByJobId(job.JobId)[0];
                */
            }
        }

        protected void cvYourEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CommonFunction.VerifyEmail(tbYourEmail.Text);
        }

        protected void cvYourFriendEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            bool valid = true;

            string[] emails = tbYourFriendEmail.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (emails.Length == 0)
            {
                args.IsValid = false;
                return;
            }

            foreach (string email in emails)
            {
                if (!string.IsNullOrEmpty(email.Trim()))
                {
                    if (CommonFunction.VerifyEmail(email.Trim()))
                    {
                        count++;
                    }
                    else
                    {
                        valid = false;
                        break;
                    }
                }
            }

            args.IsValid = (valid && (count > 0));
        }

        #endregion

        protected void cbEmailJobToAFriend_CheckedChanged(object sender, EventArgs e)
        {
            phEmailFriend.Visible = cbEmailJobToAFriend.Checked;
        }


        private bool ValidateGoogleCaptcha()
        {
            bool valid = false;
            string captchaResponse = Request["g-recaptcha-response"];

            if (!string.IsNullOrEmpty(captchaResponse))
            {
                valid = GoogleReCaptcha.Validate(0, captchaResponse);
            }

            return valid;

        }

    }
}
