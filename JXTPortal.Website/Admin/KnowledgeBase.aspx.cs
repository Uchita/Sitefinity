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
using System.Collections;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Service.Dapper;
#endregion

public partial class KnowledgeBase : System.Web.UI.Page
{
    public IKnowledgeBaseService KnowledgeBaseService { get; set; }

    protected void Page_Load(object sender, EventArgs e)
	{
        if (!Page.IsPostBack)
        {
            KnowledgeBaseRepeaterBinding();
        }
    }

    private void KnowledgeBaseRepeaterBinding()
    {
        rptKnowledgeBase.DataSource = KnowledgeBaseService.SelectAll();
        rptKnowledgeBase.DataBind();
    }
}