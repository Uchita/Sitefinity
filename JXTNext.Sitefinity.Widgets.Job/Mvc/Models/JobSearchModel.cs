using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobSearchModel
    {
        public int RowId { get; set; }
        public string ID { get; set; }
        public string FilterType { get; set; }
        public string ControlType { get; set; }
        public string DefaultValue { get; set; }
        public string PlaceholderText { get; set; }
        public List<JobSearchItem> Filters { get; set; }
    }

    public class JobSearchItem
    {
        public string ID { get; set; }
        public string ParentId { get; set; }
        public string Label { get; set; }
        public bool Show { get; set; }
        public string Level { get; set; }
        public List<JobSearchItem> Filters { get; set; }
    }
}