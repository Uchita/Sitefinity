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
        public string LastModified { get; set; }
        public string Keywords { get; set; }
        public List<JobAlertFilters> Filters { get; set; }
    }

    public class JobAlertFilters
    {
        public string RootId { get; set; }
        public List<string> Values { get; set; }
    }
}