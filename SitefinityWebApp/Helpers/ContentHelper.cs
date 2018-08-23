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

namespace SitefinityWebApp.Helpers
{
    public static class ContentHelper
    {
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
            var articleCategories = new ItemViewModel(article).GetHierarchicalTaxons(JXTNext.Sitefinity.Common.Constants.DynamicTypeConstants.Article.Fields.Category);
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

            var taxon = taxonomy.Taxa.FirstOrDefault(t => t.Name == taxonName.ToLower());
            return taxon == null ? 
                instance : instance.Where(item => item.GetValue<TrackedList<Guid>>(fieldName).Contains(taxon.Id)); // TODO;
        }
    }
}