using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class JobAlertViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool EmailAlerts { get; set; }
        public long LastModifiedTime { get; set; }
        public string Keywords { get; set; }
        public List<JobAlertFilters> Filters { get; set; }
    }

    public class JobAlertFilters
    {
        public string RootId { get; set; }
        public List<string> Values { get; set; }
    }

    public class JobAlertEditViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool EmailAlerts { get; set; }
        public string Keywords { get; set; }
        public List<JobAlertEditFilterRootItem> Data { get; set; }
    }

    public class JobAlertEditFilterRootItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<JobAlertEditFilterItem> Filters { get; set; }
    }

    public class JobAlertEditFilterItem
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
        public List<JobAlertEditFilterItem> Filters { get; set; }
    }
}