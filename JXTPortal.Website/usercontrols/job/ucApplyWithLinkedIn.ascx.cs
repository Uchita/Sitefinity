using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucApplyWithLinkedIn : System.Web.UI.UserControl
    {
        int _productId = 0;
        string _productName = string.Empty;
        string _linkedinapi = string.Empty;
        string _linkedincompanyid = "402565";
        string _linkedinlogo = string.Empty;
        string _linkedinemail = string.Empty;
        string _linkedinapplicationlink = string.Empty;

        public int ProductID
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public string LinkedInAPI
        {
            get { return _linkedinapi; }
            set { _linkedinapi = value; }
        }

        public string LinkedInCompanyID
        {
            get { return _linkedincompanyid; }
            set { _linkedincompanyid = value; }
        }

        public string LinkedInLogo
        {
            get { return _linkedinlogo; }
            set { _linkedinlogo = value; }
        }

        public string LinkedInEmail
        {
            get { return _linkedinemail; }
            set { _linkedinemail = value; }
        }

        public string LinkedInApplicationLink
        {
            get { return _linkedinapplicationlink; }
            set { _linkedinapplicationlink = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GlobalSettingsService gss = new GlobalSettingsService();
                TList<JXTPortal.Entities.GlobalSettings> tgs = gss.GetBySiteId(SessionData.Site.SiteId);
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        LinkedInAPI = gs.LinkedInApi;
                    }
                    else
                    {
                        this.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(gs.LinkedInLogo))
                    {
                        LinkedInLogo = gs.LinkedInLogo;
                    }

                    if (gs.LinkedInCompanyId.HasValue)
                    {
                        LinkedInCompanyID = gs.LinkedInCompanyId.ToString();
                    }

                    if (!string.IsNullOrEmpty(gs.LinkedInEmail))
                    {
                        LinkedInEmail = gs.LinkedInEmail;
                    }

                    LinkedInApplicationLink = "http://www." + SessionData.Site.SiteUrl + "/LinkedInJobApplication.aspx";

                    JobsService js = new JobsService();
                    Int32.TryParse(Request.QueryString["jobid"], out _productId);

                    JXTPortal.Entities.Jobs job =  js.GetByJobId(ProductID);
                    if (job != null)
                    {
                        ProductName = job.JobName.Replace("\"", "'");
                        if (!string.IsNullOrEmpty(job.RefNo))
                        {
                            ProductName = string.Format("{0}({1})", ProductName, job.RefNo);
                        }
                    }
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}