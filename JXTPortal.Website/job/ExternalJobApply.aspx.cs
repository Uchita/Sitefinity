using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.job
{
    public partial class ExternalJobApply : System.Web.UI.Page
    {

        #region "Properties"

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SetJobDetails();
        }

        private void SetJobDetails()
        {
            string URL = string.Empty;
            if (Request.UrlReferrer != null && Request.UrlReferrer.Segments.Count() > 2)
            {
                int intNum;

                if (int.TryParse(Request.UrlReferrer.Segments[3], out intNum))
                {
                    int jobid = Convert.ToInt32(Request.UrlReferrer.Segments[3]);

                    JXTPortal.Entities.ViewJobs job = ViewJobsService.GetByID(jobid, SessionData.Site.SiteId).FirstOrDefault();

                    if (job != null)
                    {

                        // Job Name on the Browser Title
                        CommonPage.SetBrowserPageTitle(Page, job.JobName);

                        URL = string.Format("http://f.jxt.com.au/FORMS/IMR/Register/register.php?sfm_from_iframe=1&jobid={0}&title={1}&refno={2}", jobid, HttpUtility.UrlPathEncode(job.JobName),
                            HttpUtility.UrlPathEncode(job.RefNo));

                        iframe_app.Attributes.Add("src", URL);
                    }
                    else
                    {
                        ltExternalJobApply.Visible = true;

                        iframe_app.Visible = false;
                    }
                }
            }
        }
    }
}