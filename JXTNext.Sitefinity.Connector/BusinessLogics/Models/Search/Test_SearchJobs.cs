using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search
{
    public class Test_SearchJobsRequest : ISearchJobsRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string Keywords { get; set; }
        public List<FiltersSearchRoot> FiltersSearch { get; set; }
    }

    public class Test_SearchJobsResponse : ISearchJobsResponse
    {
        public List<JobDetailsFullModel> SearchResults { get; set; } 
    }

    public class FiltersSearchRoot
    {
        public bool HasSearchElements { get { return Filters != null && Filters.Count > 0; } }
        public string RootID { get; set; }
        public List<FiltersSearchElement> Filters { get; set; }
    }

    public class FiltersSearchElement
    {
        public string ID { get; set; }
        public List<FiltersSearchElement> Filters { get; set; }
    }

}
