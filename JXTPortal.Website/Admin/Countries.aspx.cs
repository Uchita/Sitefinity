using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Web.UI;

namespace JXTPortal.Website.Admin
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormUtil.RedirectAfterUpdate(GridView1, "countries.aspx?page={0}");
            FormUtil.SetPageIndex(GridView1, "page");
            FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urlParams = string.Format("CountryId={0}", GridView1.SelectedDataKey.Values[0]);
            Response.Redirect("countriesedit.aspx?" + urlParams, true);
        }
    }
}
