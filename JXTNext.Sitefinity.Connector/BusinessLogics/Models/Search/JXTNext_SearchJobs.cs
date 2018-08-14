using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search
{
    public class JXTNext_SearchJobsRequest : ConnectorBaseRequest, ISearchJobsRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public ConsultantIdentitySearch ConsultantSearchIdentity { get; set; }
        public List<KeywordSearch> KeywordsSearchCriteria { get; set; }
        public List<IClassificationSearch> ClassificationsSearchCriteria { get; set; }
        public ConsultantSearch ConsultantSearchCriteria { get; set; }

        public SearchSortBy SortBy { get; set; }
    }

    public class JXTNext_SearchJobsResponse : ConnectorBaseResponse, ISearchJobsResponse
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; } //amount of jobs in total that met the search request
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; } //amount of jobs returned in this search
        [JsonProperty(PropertyName = "searchResults")]
        public List<JobDetailsFullModel> SearchResults { get; set; }
    }

    public enum SearchSortBy
    {
        Recent,
        Oldest,
        A_to_Z,
        Z_to_A,
        Salary_High_to_Low,
        Salary_Low_to_High
    }

    public class KeywordSearch
    {
        public string Keyword { get; set; }
    }

    public class ConsultantIdentitySearch
    {
        public string Email { get; set; }
    }

    public enum ClassificationSearchType
    {
        Undefined,
        Categories,
        Range
    }

    public class ConsultantSearch
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface IClassificationSearch
    {
        ClassificationSearchType SearchType { get; }
        string ClassificationRootName { get; set; }
    }

    public class Classification_CategorySearch : IClassificationSearch
    {
        public ClassificationSearchType SearchType => ClassificationSearchType.Categories;
        public string ClassificationRootName { get; set; }
        public List<Classification_CategorySearchTarget> TargetClassifications { get; set; }
    }

    public class Classification_CategorySearchTarget
    {
        public string TargetValue { get; set; }
        public List<Classification_CategorySearchTarget> SubTargets { get; set; }
    }

    public class Classification_RangeSearch : IClassificationSearch
    {
        public ClassificationSearchType SearchType => ClassificationSearchType.Range;
        public string ClassificationRootName { get; set; }
        public int? UpperRange { get; set; }
        public int? LowerRange { get; set; }
    }

}
