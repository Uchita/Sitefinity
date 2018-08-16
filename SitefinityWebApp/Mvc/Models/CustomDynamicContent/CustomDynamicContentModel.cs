using JXTNext.Sitefinity.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.DynamicContent.Mvc.Models;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Models.CustomDynamicContent
{
    public class CustomDynamicContentModel : DynamicContentModel
    {
        protected override IQueryable<IDataItem> GetItemsQuery()
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

        private static IQueryable<DynamicContent> FilterPressReleaseByDate(IQueryable<DynamicContent> query)
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
}