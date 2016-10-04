using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;

namespace JXTPortal.Website.Admin.reports
{
    public partial class JobApplicationDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((BoundField)gvJobApplicationDetail.Columns[10]).DataFormatString = "{0:" + SessionData.Site.DateFormat + "}";
            ltlMessage.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(Request.QueryString["date"]) == false)
            {
                try
                {
                    string dt = Request.QueryString["date"]; // "20141104";
                    DateTime applicationDate = DateTime.ParseExact(dt,
                                                            "yyyyMMdd",
                                                            System.Globalization.CultureInfo.InvariantCulture,
                                                            System.Globalization.DateTimeStyles.None);

                    JobApplicationService _jobApplicationService = new JobApplicationService();

                    using (DataSet jobapps = _jobApplicationService.CustomGetJobApplicationDetails(applicationDate, SessionData.Site.SiteId)) // 500 is hardcoded
                    {
                        gvJobApplicationDetail.DataSource = jobapps.Tables[0];
                        gvJobApplicationDetail.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }
    }
}