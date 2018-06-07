using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class JobSearchResultsFilterModel
    {
        public List<JobSearchFilterReceiver> Filters { get; set; }
        public string Keywords { get; set; }
        public int Page { get; set; }
    }

    public class JobSearchFilterReceiver
    {
        public string searchTarget { get; set; }
        public string rootId { get; set; }
        public List<string> values { get; set; }
    }

    public class JobTypesDesignerViewModel
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
    }
}