

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
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Website;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
#endregion

public partial class DynamicPageWebPartTemplates : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
        DynamicPageWebPartTemplatesService service = new DynamicPageWebPartTemplatesService();
        TList<JXTPortal.Entities.DynamicPageWebPartTemplates> templates = service.GetBySiteId(SessionData.Site.SiteId);
        rptWebContainer.DataSource = templates;
        rptWebContainer.DataBind();

        
    }

    protected void rptWebContainer_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            JXTPortal.Entities.DynamicPageWebPartTemplates template = e.Item.DataItem as JXTPortal.Entities.DynamicPageWebPartTemplates;

            Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
            ltLastModified.Text = template.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

        }
    }

	
}


