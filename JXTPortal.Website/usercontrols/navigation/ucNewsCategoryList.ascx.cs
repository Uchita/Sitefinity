using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class ucNewsCategoryList : System.Web.UI.UserControl
    {
        private NewsCategoriesService _newscategoriesservice;

        private NewsCategoriesService NewsCategoriesService
        {
            get
            {
                if (_newscategoriesservice == null)
                {
                    _newscategoriesservice = new NewsCategoriesService();
                }
                return _newscategoriesservice;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCategories();
            }


        }

        private void LoadCategories()
        {
            using (TList<JXTPortal.Entities.NewsCategories> newscategories = NewsCategoriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                newscategories.Filter = "Valid = true";
                
                if (newscategories.Count > 0)
                {
                    rptNewsCategories.DataSource = newscategories.OrderBy(s => s.Sequence);
                    rptNewsCategories.DataBind();
                }
            }

        }


        protected void rptNewsCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                JXTPortal.Entities.NewsCategories categoryNews = e.Item.DataItem as JXTPortal.Entities.NewsCategories;
                //Literal ltCategoryName = e.Item.FindControl("ltCategoryName") as Literal;

                HyperLink hlinkNewsCategory = e.Item.FindControl("hlinkNewsCategory") as HyperLink;

                //string urlNewsCategory = string.Format("/news/{0}/{1}", news.PageFriendlyName, news.NewsId);
                //string urlAllCategories = string.Format("/news/{0}/{1}", news.PageFriendlyName, news.NewsId);

                string urlNewsCategory = string.Format("/news/category/{0}/", categoryNews.PageFriendlyName);


                hlinkNewsCategory.Text = categoryNews.NewsCategoryName;
                hlinkNewsCategory.NavigateUrl = urlNewsCategory;

            }
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltlNews = e.Item.FindControl("ltlNews") as Literal;
                HyperLink hlnkAllCategories = e.Item.FindControl("hlnkAllCategories") as HyperLink;
                
                // ToDo - Language
                ltlNews.Text = CommonFunction.GetResourceValue("LabelNews");   //"News"; 
                hlnkAllCategories.Text = "All Categories";
                hlnkAllCategories.NavigateUrl = "/news/";
            }
        }


    }
}