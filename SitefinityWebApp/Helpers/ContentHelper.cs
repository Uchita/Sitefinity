using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.OpenAccess;
using Telerik.Sitefinity.ContentLocations;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Frontend.DynamicContent.Mvc.Models;
using SitefinityWebApp.Mvc.Models.CustomDynamicContent;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Fluent.Pages;
using Telerik.Sitefinity.Abstractions;

namespace SitefinityWebApp.Helpers
{
    public static class ContentHelper
    {

        public static string FindPagebyUrlNativeAPI(string urlName, string parentNodeUrl)
        {
            var rootPageNodes = App.WorkWith().Pages().LocatedIn(PageLocation.Frontend).Where(p => p.Parent.Id == SiteInitializer.CurrentFrontendRootNodeId).Get().ToList();
            string pageTitle = string.Empty;

            if (parentNodeUrl == "/specialist-recruitment-group")
            {
                PageNode rootPageNode = rootPageNodes.Where(r => r.UrlName.Value == "specialist-recruitment-group").FirstOrDefault();

                if (rootPageNode != null && rootPageNode.ShowInNavigation && rootPageNode.Nodes.Count > 0)
                {
                    PageNode node = rootPageNode.Nodes.Where(r => r.UrlName.Value == "~/specialist-recruitment").FirstOrDefault();
                    if (node != null)
                    {
                        PageNode subNode = node.Nodes.Where(n => n.UrlName.Value.Replace("~", "").Replace("/", "") == urlName.Replace("/", "")).FirstOrDefault();
                        if (subNode != null) pageTitle = subNode.GetPageData().HtmlTitle.Value.Replace("| Bayside Group", string.Empty);
                    }
                }
            }

            else if (parentNodeUrl == "/contact")
            {
                PageNode rootPageNode1 = rootPageNodes.Where(r => r.UrlName.Value == "contact").FirstOrDefault();

                var pageManager = PageManager.GetManager();

                if (rootPageNode1 != null && rootPageNode1.ShowInNavigation && rootPageNode1.Nodes.Count > 0)
                {
                    PageNode node1 = rootPageNode1.Nodes.Where(r => r.UrlName.Value == "our-brands").FirstOrDefault();
                    if (node1 != null)
                    {
                        PageNode subNode1 = node1.Nodes.Where(n => n.UrlName.Value.Replace("contact", "").Replace("our-brands", "").Replace("~", "").Replace("/", "") == urlName.Replace("/", "").Replace("contact", "").Replace("our-brands", "").Replace("~", "").Replace("/", "")).FirstOrDefault();
                        if (subNode1 != null)
                        {
                            PageNode linkedPageNode = pageManager.GetPageNode(subNode1.LinkedNodeId);
                            if (linkedPageNode != null)
                                pageTitle = linkedPageNode.GetPageData().HtmlTitle.Value.Replace("| Bayside Group", string.Empty);

                        }
                    }
                }
            }

            return pageTitle;
        }

        public static ItemViewModel GetLastInsight()
        {
            // Todo - filter insight articles only.
            var article = GetArticles()
                .FilterByFlatTaxonName("Tags", "Insights", "Tags")
                .OrderByDescending(a => a.GetValue<DateTime>("PublicationDate")).FirstOrDefault();
            return article == null ? null : new ItemViewModel(article);
        }

        public static ItemViewModel GetFeaturedArticle()
        {
            // TODO: Get only featured artcle.
            var article = GetArticles()
                .FilterByFlatTaxonName("Tags", "Featured", "Tags")
                .OrderByDescending(a => a.GetValue<DateTime>("PublicationDate")).FirstOrDefault();
            return article == null ? null : new ItemViewModel(article);
        }

        public static string GetBestArticleUrl(IDataItem article)
        {
            var locationService = SystemManager.GetContentLocationService();
            var articleCategories = new ItemViewModel(article).GetHierarchicalTaxons(JXTNext.Sitefinity.Common.Constants.DynamicTypeConstants.Article.Fields.Articles);
            var category = articleCategories.FirstOrDefault();

            if (category == null)
                return locationService.GetItemDefaultLocation(article).ItemAbsoluteUrl;

            var locations = locationService.GetItemLocations(article);
            var bestLocation = locations.FirstOrDefault(l => new Uri(l.ItemAbsoluteUrl).Segments.Any(s => s.ToLower() == category.Name.ToLower()));
            return bestLocation == null ? locationService.GetItemDefaultLocation(article).ItemAbsoluteUrl : bestLocation.ItemAbsoluteUrl;
        }

        private static IQueryable<DynamicContent> GetArticles()
        {
            return DynamicModuleManager.GetManager()
                .GetDataItems(JXTNext.Sitefinity.Common.Constants.DynamicTypeConstants.Article.ResolvedType)
                .Where(i => i.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live &&
                i.Visible)
                .Cast<DynamicContent>();
        }

        public static IQueryable<DynamicContent> FilterByFlatTaxonName(this IQueryable<DynamicContent> instance, string classificationName, string taxonName, string fieldName)
        {
            var taxonomy = TaxonomyManager.GetManager().GetTaxonomies<FlatTaxonomy>()
                .FirstOrDefault(t => t.Name == classificationName);

            var taxon = taxonomy.Taxa.FirstOrDefault(t => t.Name.ToLower() == taxonName.ToLower());
            return taxon == null ?
                instance : instance.Where(item => item.GetValue<TrackedList<Guid>>(fieldName).Contains(taxon.Id)); // TODO;
        }

        public static List<DynamicContent> GetRelatedDynamicContentItemsByHierarchicalTaxonomy(TrackedList<Guid> detailsPageItemTaxonIds, Guid detailPageItemId, string fieldName, string dynamicContentType)
        {
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
            Type contentType = TypeResolutionService.ResolveType(dynamicContentType);
            var allItems = dynamicModuleManager.GetDataItems(contentType).Where(h => h.Status == ContentLifecycleStatus.Live && h.Visible && h.ApprovalWorkflowState == "Published").ToList();
            List<DynamicContent> relatedItems = new List<DynamicContent>();
            foreach (var item in allItems)
            {
                var articleTaxonIds = item.GetValue<TrackedList<Guid>>(fieldName);
                if (articleTaxonIds.Any(x => detailsPageItemTaxonIds.Contains(x)))
                {
                    // Skip the current loaded item in the details page
                    if (item.Id != detailPageItemId)
                    {
                        relatedItems.Add(item);
                    }
                }
            }

            return relatedItems;
        }

        public static string GetSortExpression()
        {
            string orderByValue = HttpContext.Current.Request.QueryString["orderby"];
            string sortExpr = null;

            if (!string.IsNullOrWhiteSpace(orderByValue))
            {
                switch (orderByValue.ToLower())
                {
                    case "date-asc":
                        sortExpr = "PublicationDate ASC";
                        break;
                    case "date-desc":
                        sortExpr = "PublicationDate DESC";
                        break;
                    case "title-asc":
                        sortExpr = "Title ASC";
                        break;
                    case "title-desc":
                        sortExpr = "Title DESC";
                        break;
                    default:
                        break;
                }
            }

            return sortExpr;
        }

        public static string GetSortParameter()
        {
            string orderByValue = HttpContext.Current.Request.QueryString["orderby"];
            string sortParam = null;

            if (!string.IsNullOrWhiteSpace(orderByValue))
            {
                switch (orderByValue.ToLower())
                {
                    case "date-asc":
                    case "date-desc":
                    case "title-asc":
                    case "title-desc":
                        sortParam = orderByValue;
                        break;
                    default:
                        break;
                }
            }

            return sortParam;
        }

        public static string GetItemsPagingInfo(DynamicContentListViewModel model)
        {
            var itemsCount = model.Items.Count();

            if (itemsCount == 0)
            {
                return string.Empty;
            }
            else if (itemsCount == 1)
            {
                return "Displaying item 1 of 1";
            }
            else
            {
                string messageTemplate = "Displaying items {0} to {1} out of {2}";
                int firstItemOnPageOrdinal = 1;
                int lastItemOnPageOrdinal = itemsCount;
                int totalItems = itemsCount;
                int itemsPerPage = itemsCount;

                if (HttpContext.Current.Items.Contains(CustomDynamicContentModel.ArticlesItemsPerPageFlag))
                {
                    itemsPerPage = Convert.ToInt32(HttpContext.Current.Items[CustomDynamicContentModel.ArticlesItemsPerPageFlag]);
                    HttpContext.Current.Items.Remove(CustomDynamicContentModel.ArticlesItemsPerPageFlag);
                }

                if (HttpContext.Current.Items.Contains(CustomDynamicContentModel.ArticlesTotalCountFlag))
                {
                    totalItems = Convert.ToInt32(HttpContext.Current.Items[CustomDynamicContentModel.ArticlesTotalCountFlag]);
                    HttpContext.Current.Items.Remove(CustomDynamicContentModel.ArticlesTotalCountFlag);
                }

                if (model.CurrentPage > 1)
                {
                    firstItemOnPageOrdinal = ((model.CurrentPage - 1) * itemsPerPage) + 1;
                    lastItemOnPageOrdinal = firstItemOnPageOrdinal + itemsPerPage - 1;
                }

                if (model.CurrentPage == model.TotalPagesCount)
                {
                    lastItemOnPageOrdinal = totalItems;
                }

                var message = string.Format(messageTemplate, firstItemOnPageOrdinal, lastItemOnPageOrdinal, totalItems);

                return message;
            }
        }
    }
}