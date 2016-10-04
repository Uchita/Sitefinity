using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class AdvertiserApplicationNote : System.Web.UI.Page
    {
        #region Declaration
        private JobApplicationService _jobApplicationService;
        private JobsService _jobsService;
        private int _jobapplicationid = 0;
        #endregion

        #region Properties

        protected int JobApplicationID
        {
            get
            {
                if ((Request.QueryString["jobappid"] != null))
                {
                    if ((Request.QueryString["jobappid"] != null))
                        if (int.TryParse((Request.QueryString["jobappid"].Trim()), out _jobapplicationid))
                        {
                            _jobapplicationid = Convert.ToInt32(Request.QueryString["jobappid"]);
                        }
                    return _jobapplicationid;
                }

                return _jobapplicationid;
            }
        }

        JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                {
                    _jobApplicationService = new JobApplicationService();
                }

                return _jobApplicationService;
            }
        }

        JobsService JobsService
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

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Job Application Note");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }
            if (!Page.IsPostBack)
            {
                LoadJobApplications();
            }

            SetFormValues();

        }

        private void LoadJobApplications()
        {
            using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
            {
                if (jobapp != null)
                {
                    if (JobsService.isAdvertiserJob(jobapp.JobId, jobapp.JobArchiveId))
                    {

                        if (jobapp.ApplicationDate != null)
                        {
                            dataApplicationDate.Text = jobapp.ApplicationDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        }

                        if (jobapp.MemberResumeFile != null)
                        {
                            dataResume.NavigateUrl = "~/getapplicationfile.aspx?id=" + jobapp.JobApplicationId.ToString() + "&doctype=" + ((int)PortalEnums.JobApplications.DocumentType.Resume).ToString(); ;
                        }

                        if (jobapp.MemberCoverLetterFile != null)
                        {
                            dataCoverLetter.NavigateUrl = "~/getapplicationfile.aspx?id=" + jobapp.JobApplicationId.ToString() + "&doctype=" + ((int)PortalEnums.JobApplications.DocumentType.CoverLetter).ToString(); ;
                        }

                        if (jobapp.ApplicationStatus != null)
                        {
                            dataApplicationStatus.Text = ((PortalEnums.JobApplications.ApplicationStatus)((int)jobapp.ApplicationStatus)).ToString();
                        }

                        if (jobapp.ApplicantGrade != null)
                        {
                            dataApplicantGrade.Text = jobapp.ApplicantGrade.ToString();
                        }

                        if (jobapp.LastViewedDate != null)
                        {
                            dataLastViewedDate.Text = jobapp.LastViewedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        }

                        if (jobapp.FirstName != null)
                        {
                            dataFirstName.Text = jobapp.FirstName;
                        }

                        if (jobapp.Surname != null)
                        {
                            dataSurname.Text = jobapp.Surname;
                        }

                        if (jobapp.EmailAddress != null)
                        {
                            dataEmailAddress.Text = jobapp.EmailAddress;
                            dataEmailAddress.NavigateUrl = "mailto:" + jobapp.EmailAddress;
                        }

                        if (jobapp.MobilePhone != null)
                        {
                            dataMobilePhone.Text = jobapp.MobilePhone;
                        }

                        if (jobapp.AdvertiserNote != null)
                        {
                            dataNote.Text = jobapp.AdvertiserNote;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
            {
                if (jobapp != null)
                {
                    jobapp.AdvertiserNote = dataNote.Text;

                    JobApplicationService.Update(jobapp);
                    Response.Redirect("~/advertiser/jobtracker.aspx");
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/advertiser/jobtracker.aspx");
        }

        public void SetFormValues()
        {
            btnBack.Text = CommonFunction.GetResourceValue("ButtonBack");
            btnUpdate.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            dataResume.Text = CommonFunction.GetResourceValue("LinkButtonDownload");
            dataCoverLetter.Text = CommonFunction.GetResourceValue("LinkButtonDownload");
            ReqVal_Note.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");

        }
    }
}
