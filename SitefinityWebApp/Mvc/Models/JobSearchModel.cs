using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class JobSearchModel
    {
        public int RowId { get; set; }
        public string ControlType { get; set; }
        public string FilterType { get; set; }
        public string DefaultValue { get; set; }
        public string PlaceholderText { get; set; }
        public List<JobSearchItem> Data { get; set; }
    }

    public class JobSearchItem
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
        public List<JobSearchItem> Data { get; set; }
    }
}