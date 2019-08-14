using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobFiltersModel
    {
        public string TaxonamyName { get; set; }
        public string TaxonomyId { get; set; }
        public bool Selected { get; set; }
        public int TrackId { get; set; }
    }
}
