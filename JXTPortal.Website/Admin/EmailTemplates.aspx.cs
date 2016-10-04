using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class EmailTemplates : System.Web.UI.Page
    {
        #region Page
        /// <summary>
        /// Method to set GridView
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            FormUtil.RedirectAfterUpdate(GridView1, "EmailTempaltes.aspx?page={0}");
            FormUtil.SetPageIndex(GridView1, "page");
            //FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));

            // To display only per Site
            EmailTemplatesDataSource.Parameters.Add("SiteId", SessionData.Site.SiteId.ToString());
        }

        #endregion

        #region Grid View Events
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urlParams = string.Format("EmailTemplateId={0}", GridView1.SelectedDataKey.Values[0]);
            Response.Redirect("emailtemplatesedit.aspx?" + urlParams, true);
        }
        #endregion
    }
}
