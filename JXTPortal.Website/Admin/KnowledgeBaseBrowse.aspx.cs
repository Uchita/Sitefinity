using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Service.Dapper;

namespace JXTPortal.Website.Admin
{
    public partial class KnowledgeBaseBrowse : System.Web.UI.Page
    {
        public IKnowledgeBaseCategoryService KnowledgeBaseCategoryService { get; set; }

        public IKnowledgeBaseService KnowledgeBaseService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CategoriesRepeaterBinding();
            }
        }

        protected void CategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                int parentId = Convert.ToInt32((e.Item.FindControl("hfParentId") as HiddenField).Value);
                Repeater rptChildCategory = e.Item.FindControl("rptChildCategory") as Repeater;

                rptChildCategory.DataSource = KnowledgeBaseCategoryService.GetCategoryByParentCategoryId(parentId).Where(x => x.Valid);
                rptChildCategory.DataBind();
            }
        }

        protected void ChildCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                // Knowledge Base
                int knowledgeBaseCategoryId = Convert.ToInt32((e.Item.FindControl("hfKnowledgeBaseCategoryId") as HiddenField).Value);
                Repeater rptKnowledgebase = e.Item.FindControl("rptKnowledgebase") as Repeater;

                rptKnowledgebase.DataSource = KnowledgeBaseService.SelectAll().Where(x => x.KnowledgeBaseCategoryID == knowledgeBaseCategoryId && x.Valid);
                rptKnowledgebase.DataBind();
            }
        }

        protected void CategoriesRepeaterBinding()
        {            
            var knowledgeBaseCategoryService = KnowledgeBaseCategoryService.SelectAll().Where(x => x.ParentId == 0 && x.Valid).ToList();

            if (knowledgeBaseCategoryService.Any())
            {
                rptCategories.DataSource = knowledgeBaseCategoryService;
                rptCategories.DataBind();
            }
            else
            {
                ltlMessage.Text = "<h3>There is no Knowledge Base available at the moment</h3>";
            }            
        }
    }
}