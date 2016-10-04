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
using JXTPortal.Data.Dapper.Repositories;
#endregion

public partial class KnowledgeBaseCategories : System.Web.UI.Page
{
    public IKnowledgeBaseCategoryRepository KnowledgeBaseCategoryRepository { get; set; }

    protected void Page_Load(object sender, EventArgs e)
	{
        if (!Page.IsPostBack)
        {
            KnowledgeBaseCategoriesBinding();
        }
    }

    private void KnowledgeBaseCategoriesBinding()
    {
        rptKnowledgeBaseCategories.DataSource = KnowledgeBaseCategoryRepository.SelectAll();
        rptKnowledgeBaseCategories.DataBind();
    }
}