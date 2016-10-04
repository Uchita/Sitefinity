using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.JobApplications.Models;
using System.Xml.Serialization;
using System.IO;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.job.application.pdf
{
    public partial class aicd_scholarship_pdf : System.Web.UI.Page
    {

        private AicdSponsorshipModel _formData;

        //for front end grab
        public AicdSponsorshipModel FormData
        {
            get
            {
                if (_formData == null)
                    return new AicdSponsorshipModel();
                return _formData;
            }
        }

        private int _appid = 0;
        protected int ApplicationID
        {
            get
            {
                if ((Request.QueryString["appid"] != null))
                {
                    if (int.TryParse((Request.QueryString["appid"].Trim()), out _appid))
                    {
                        _appid = Convert.ToInt32(Request.QueryString["appid"]);
                    }
                    return _appid;
                }

                return _appid;
            }
        }

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

        private JobApplicationService _jobApplicationService;
        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            // Todo
            /*if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }*/

            if (ApplicationID > 1)
            {
                JobApplications.FormGenerator formGenerator = new JobApplications.FormGenerator();


                using (JobApplication jobApplication = JobApplicationService.GetByJobApplicationId(ApplicationID))              
                {
                    // Todo - Check its advertisers application
                    if (jobApplication != null) // Todo && jobApplicationList[0].Draft == false)
                    {

                        using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(jobApplication.JobId, SessionData.Site.SiteId))
                        {
                            // If expired redirect to the job detail page.
                            if ((jobs[0].Expired.HasValue && jobs[0].Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || jobs[0].ExpiryDate < DateTime.Now)
                            {
                                Response.Redirect("~/" + Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName));
                            }

                            hypLinkJobTitle.Text = jobs[0].JobName + " - Application complete";
                            hypLinkJobTitle.NavigateUrl = Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName);
                            
                        }

                        //_formData = new AicdSponsorshipModel();
                        //_formData.tab8 = Utils.ProcessXMLFromXmlString(_formData.tab8, jobApplication.CustomQuestionnaireXml);
                        //formGenerator.GenerateForm(ref plhTab1, _formData.tab8 != null ? _formData.tab8.tab1Values : null, true);


                        if (!string.IsNullOrWhiteSpace(jobApplication.ExternalXmlFilename))
                        {
                            string strXmlString = JobApplicationService.ReadXMLFromFTP(jobApplication.ExternalXmlFilename);

                            _formData = Utils.ProcessXMLFromXmlString(FormData, strXmlString);
                        }

                    }
                }



            }
            else
                Response.Redirect("/advancedsearch.aspx");


        }


    }
}