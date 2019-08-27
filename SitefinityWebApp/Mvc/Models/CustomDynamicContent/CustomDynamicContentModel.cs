using JXTNext.Sitefinity.Common.Constants;
using SitefinityWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTNext.Telemetry;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.DynamicContent.Mvc.Models;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;

namespace SitefinityWebApp.Mvc.Models.CustomDynamicContent
{
    public class CustomDynamicContentModel : DynamicContentModel
    {
        protected override void PopulateListViewModel(int page, IQueryable<IDataItem> query, ContentListViewModel viewModel)
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.PopulateListViewModel"))
            {
                base.PopulateListViewModel(page, query, viewModel);
            }
        }

        protected override IQueryable<IDataItem> GetItemsQuery()
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.GetItemsQuery"))
            {
                var query = base.GetItemsQuery().Cast<DynamicContent>();
                switch (this.ContentType.FullName)
                {
                    case DynamicTypeConstants.Pressrelease.FullTypeName:
                        query = FilterPressReleaseByDate(query);
                        break;
                }
                return query;
            }
        }


        protected override IEnumerable<IDataItem> FetchItems(IQueryable<IDataItem> query)
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.FetchItems"))
            {
                return base.FetchItems(query);
            }
        }

        protected override IEnumerable<ItemViewModel> ApplyListSettings(int page, IQueryable<IDataItem> query, out int? totalPages)
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.ApplyListSettings"))
            {
                if (page < 1)
                    throw new ArgumentException("'page' argument has to be at least 1.", "page");

                int? itemsToSkip = (page - 1) * this.ItemsPerPage;
                itemsToSkip = this.DisplayMode == ListDisplayMode.Paging ? ((page - 1) * this.ItemsPerPage) : null;
                int? totalCount = 0;
                int? take = null;

                if (this.DisplayMode == ListDisplayMode.Limit)
                {
                    take = this.LimitCount;
                }
                else if (this.DisplayMode == ListDisplayMode.Paging)
                {
                    take = this.ItemsPerPage;
                }

                IList<ItemViewModel> result = new List<ItemViewModel>();

                query = this.UpdateExpression(query, itemsToSkip, take, ref totalCount);

                var queryResult = this.FetchItems(query);
                queryResult.SetRelatedDataSourceContext();

                foreach (var item in queryResult)
                {
                    result.Add(this.CreateItemViewModelInstance(item));
                }

                if (this.ItemsPerPage.HasValue && this.ItemsPerPage.Value > 0)
                {
                    totalPages = (totalCount.Value + this.ItemsPerPage.Value - 1) / this.ItemsPerPage.Value;
                    totalPages = this.DisplayMode == ListDisplayMode.Paging ? totalPages : null;
                }
                else
                {
                    totalPages = 1;
                }

                if (this.ContentType.FullName == DynamicTypeConstants.Article.FullTypeName)
                {
                    if (HttpContext.Current.Items.Contains(ArticlesTotalCountFlag))
                    {
                        HttpContext.Current.Items[ArticlesTotalCountFlag] = totalCount;
                    }
                    else
                    {
                        HttpContext.Current.Items.Add(ArticlesTotalCountFlag, totalCount);
                    }


                    if (HttpContext.Current.Items.Contains(ArticlesItemsPerPageFlag))
                    {
                        HttpContext.Current.Items[ArticlesItemsPerPageFlag] = this.ItemsPerPage;
                    }
                    else
                    {
                        HttpContext.Current.Items.Add(ArticlesItemsPerPageFlag, this.ItemsPerPage);
                    }
                }
                
                return result;
            }
        }

        protected override IQueryable<TItem> SetExpression<TItem>(IQueryable<TItem> query, string filterExpression, string sortExpr, int? itemsToSkip, int? itemsToTake, ref int? totalCount)
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.SetExpression"))
            {
                if (this.ContentType.FullName == DynamicTypeConstants.Article.FullTypeName)
                {
                    var dynamicSortExpr = ContentHelper.GetSortExpression();

                    if (dynamicSortExpr != null)
                        sortExpr = dynamicSortExpr;
                }

                return base.SetExpression(query, filterExpression, sortExpr, itemsToSkip, itemsToTake, ref totalCount);
            }
        }

        private static IQueryable<DynamicContent> FilterPressReleaseByDate(IQueryable<DynamicContent> query)
        {
            using (new StatsDPerformanceMeasure("CustomDynamicContentModel.FilterPressReleaseByDate"))
            {
                string filter = HttpContext.Current.Request.QueryString["filter"];
                if (!string.IsNullOrEmpty(filter))
                {
                    DateTime filterDate = DateTime.Now;
                    switch (filter.ToUpper())
                    {
                        case "PAST_6_MONTHS":
                            filterDate = filterDate.AddMonths(-6);
                            break;
                        case "PAST_YEAR":
                            filterDate = filterDate.AddMonths(-12);
                            break;
                        case "PAST_2_YEARS":
                            filterDate = filterDate.AddMonths(-24);
                            break;
                        default:
                            filterDate = DateTime.MinValue;
                            break;
                    }
                    if (filterDate > DateTime.MinValue)
                        query = query.Where(item => item.GetValue<DateTime?>(DynamicTypeConstants.Pressrelease.Fields.IssueDate) > filterDate);
                }
                
                return query;
            }
        }
        
        public const string ArticlesTotalCountFlag = "articles-total-count";
        public const string ArticlesItemsPerPageFlag = "articles-items-per-page";
    }
}