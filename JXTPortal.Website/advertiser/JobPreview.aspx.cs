using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Web.UI;
using JXTPortal.Common;
using System.Text.RegularExpressions;
using System.Reflection;

namespace JXTPortal.Website.advertiser
{
    public partial class JobPreview : DefaultBase
    {
        private int _jobID;
        private int JobID
        {
            get
            {
                int _jobID = 0;

                if (int.TryParse(Request.QueryString["JobID"], out _jobID))
                {
                    return _jobID;
                }

                return _jobID;
            }
            set
            {
                _jobID = value;
            }
        }

        private JobItemsTypeService _jobItemsTypeService;
        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobItemsTypeService == null)
                    _jobItemsTypeService = new JobItemsTypeService();
                return _jobItemsTypeService;
            }
        }

        private JobsService _jobsService;
        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
            }
        }
        private AdvertiserUsersService _advertiserusersService;
        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersService == null)
                    _advertiserusersService = new AdvertiserUsersService();
                return _advertiserusersService;
            }
        }

        private InvoiceItemService _invoiceitemService;
        private InvoiceItemService InvoiceItemService
        {
            get
            {
                if (_invoiceitemService == null)
                    _invoiceitemService = new InvoiceItemService();
                return _invoiceitemService;
            }
        }


        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            LoginCheck("~/advertiser/login.aspx", SessionData.AdvertiserUser);

            CommonPage.SetBrowserPageTitle(Page, "Advertiser Job Preview");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Next button will be disabled if the job is pending / suspended/ declined
                using (Entities.Jobs job = JobsService.GetByJobId(JobID))
                {
                    if (job != null)
                    {
                        if (job.Expired.HasValue &&
                                (job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired ||
                                job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Pending ||
                            //job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Declined ||
                                job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Suspended))
                        {
                            btnNext.Visible = false;
                        }
                    }
                }
            }

            btnBack.Text = CommonFunction.GetResourceValue("ButtonBack");
            btnNext.Text = CommonFunction.GetResourceValue("ButtonContinue");
        }

        #endregion

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/advertiser/jobcreate.aspx?jobid=" + JobID.ToString());
            /*
            if (btnNext.Visible)
            {
                Response.Redirect("~/advertiser/jobcreate.aspx?jobid=" + JobID.ToString());
            }
            else
            {
                Response.Redirect("~/advertiser/jobspending.aspx");
            }*/
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            using (Entities.Jobs job = JobsService.GetByJobId(JobID))
            {

                bool jobscreeningprocess = false;
                GlobalSettingsService gs = new GlobalSettingsService();
                using (TList<Entities.GlobalSettings> globalsettings = gs.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (globalsettings.Count > 0)
                    {
                        jobscreeningprocess = (globalsettings[0].JobScreeningProcess.HasValue) ? globalsettings[0].JobScreeningProcess.Value : false;
                    }
                }

                if (job != null)
                {
                    job.SearchFieldExtension = string.Empty;

                    // If site is using job screening process and not billed, makes job pending and send email to admin                
                    if (jobscreeningprocess)
                    {
                        // If the job is set to live or else set to draft
                        if (job.Visible)
                            job.Expired = (int)PortalEnums.Jobs.JobStatus.Pending;
                        else
                            job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;

                        // Update the job.
                        JobsService.Update(job);

                        // Send Email to the Admin that there was new job created
                        Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId);
                        if (advuser != null)
                        {
                            MailService.SendNewJobCreated(job, advuser.Email, (advuser.DefaultLanguageId.HasValue) ? advuser.DefaultLanguageId.Value : SessionData.Site.DefaultEmailLanguageId);
                        }
                    }
                    // Make the job live if the job is visible.
                    // If the job is expired or if the job is live
                    else if (job.Visible || (job.Expired.HasValue && job.Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired)                        )
                    {
                        if (job.Expired.Value != (int)PortalEnums.Jobs.JobStatus.Expired && job.Expired.Value != (int)PortalEnums.Jobs.JobStatus.Live)
                        {
                            job.Expired = (int)PortalEnums.Jobs.JobStatus.Live;
                            int daysactive = 30;

                            if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                            {
                                TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                                jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + job.JobItemTypeId.ToString();
                                if (jobitemtypes.Count > 0)
                                {
                                    daysactive = jobitemtypes[0].DaysActive;
                                }
                            }
                            job.ExpiryDate = DateTime.Now.AddDays(daysactive);
                        }

                        // Update the job.
                        JobsService.Update(job);

                        // Update the job counts when expired and live
                        if (job.Expired == (int)PortalEnums.Jobs.JobStatus.Expired)
                            JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, false);
                        else
                            JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);

                        // Submit to the Jobx queue.
                        JobsService.JobX_SubmitQueue(job.JobId);
                    }

                    // Todo in future for Draft Job
                }
            }

            DynamicPagesService service = new DynamicPagesService();
            Response.Redirect(service.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
        }

    }
}
