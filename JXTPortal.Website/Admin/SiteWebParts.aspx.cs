

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

public partial class SiteWebParts : System.Web.UI.Page
{
    TList<JXTPortal.Entities.SiteWebParts> defaultlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteWebPartsService service = new SiteWebPartsService();

        TList<JXTPortal.Entities.SiteWebParts> sitewebparts = service.GetBySiteId(SessionData.Site.SiteId);
        rptWebPart.DataSource = sitewebparts;
        rptWebPart.DataBind();

        
    }

    protected void rptWebPart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltWebPartType = e.Item.FindControl("ltWebPartType") as Literal;
            JXTPortal.Entities.SiteWebParts webpart = e.Item.DataItem as JXTPortal.Entities.SiteWebParts;

                    ltWebPartType.Text = ((PortalEnums.SiteWebParts.SiteWebPartTypes) webpart.SiteWebPartTypeId).ToString();
            
        }
    }

}


