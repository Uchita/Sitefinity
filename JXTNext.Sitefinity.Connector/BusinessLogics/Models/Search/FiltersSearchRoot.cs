using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search
{
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
