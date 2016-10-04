using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Entities;
using System.Text.RegularExpressions;

namespace JXTPortal.Website
{
    public partial class JobDetail : System.Web.UI.Page
    {
        #region "Properties"

        private int _jobid = 0;

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

        private JobViewsService _jobViewsService;

        private JobViewsService JobViewsService
        {
            get
            {
                if (_jobViewsService == null)
                    _jobViewsService = new JobViewsService();
                return _jobViewsService;
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

        //public AjaxControlToolkit.ModalPopupExtender PopupExtender
        //{
        //    get { return programmaticModalPopup; }
        //}

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;
            if (!Page.IsPostBack)
            {
                if (ucJobPreview.JobId > 0)
                {
                    string domain = Utils.GetUrlReferrerDomain();
                    ltReferrer.Text = domain;


                    bool needupdate = false;

                    Utils.UpdateJobsViewedCookie(ucJobPreview.JobId, domain, out needupdate);
                    if (needupdate)
                    {
                        JobViewsService.UpdateCounter(ucJobPreview.JobId, SessionData.Site.SiteId, domain, DateTime.Now.Date);
                    }
                }

            }
        }
    }
}
