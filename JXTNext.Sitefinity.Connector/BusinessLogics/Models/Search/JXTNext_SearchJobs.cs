using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search
{
    public class JXTNext_SearchJobsRequest : ConnectorBaseRequest, ISearchJobsRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string Keywords { get; set; }
        public List<FiltersSearchRoot> FiltersSearch { get; set; }
    }

    public class JXTNext_SearchJobsResponse : ConnectorBaseResponse, ISearchJobsResponse
    {
        public int Total { get; set; } //amount of jobs in total that met the search request
        public int Count { get; set; } //amount of jobs returned in this search
        public List<JobDetailsFullModel> SearchResults { get; set; }

    }
}
