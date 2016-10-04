using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website
{
    public partial class jobs_jobadderapplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = string.Empty;

            url = string.Format("http://my.jobadder.com/JobApplication/ApplicationForm.aspx?id={0}&job={1}&source={2}", Request.Params["id"], Request.Params["Job"], Request.Params["Source"]);

            if (!Page.IsPostBack)
            {
                iframe_app.Attributes.Add("src", url);
            }
        }
    }
}