using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class SubTarget
    {
        public string ItemID { get; set; }
        public object SubTargets { get; set; }
    }

    public class Value
    {
        public string ItemID { get; set; }
        public List<SubTarget> SubTargets { get; set; }
    }

    public class Filter
    {
        public object searchTarget { get; set; }
        public string rootId { get; set; }
        public List<Value> values { get; set; }
    }

    public class FilterModelParser
    {
        public List<Filter> Filters { get; set; }
        public string Keywords { get; set; }
        public object ConsultantSearch { get; set; }
        public int Page { get; set; }
        public object Salary { get; set; }
        public string SortBy { get; set; }
        public object Classification { get; set; }
        public object SubClassification { get; set; }
        public object Country { get; set; }
        public object Location { get; set; }
        public object Area { get; set; }
        public object WorkType { get; set; }
        public object CompanyName { get; set; }
        public object SalaryType { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
    }
}
