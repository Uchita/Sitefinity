

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class JobStatistics : System.Web.UI.Page
    {
        #region "Properties"

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

        #endregion

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            dgJobStatistic.DataSource = JobViewsService.GetGroupByDateRange(SessionData.Site.SiteId, DateTime.ParseExact(txtDateFrom.Text, SessionData.Site.DateFormat, null), DateTime.ParseExact(txtDateFrom.Text, SessionData.Site.DateFormat, null));
            dgJobStatistic.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgJobStatistic.DataSource = JobViewsService.GetGroupByDateRange(SessionData.Site.SiteId, DateTime.Now.Date, DateTime.Now.Date);
                dgJobStatistic.DataBind();
            }
        }
    }
}


