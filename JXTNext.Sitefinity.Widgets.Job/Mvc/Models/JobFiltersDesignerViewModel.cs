using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JXTNext.Sitefinity.Common.Helpers;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobFiltersDesignerViewModel
    {
        public JobFiltersDesignerViewModel()
        {
            if (string.IsNullOrWhiteSpace(this.SerializedJobFilterModel))
            {
                var filterModel = new List<JobFiltersModel>();
                var topLovelCategories = SitefinityHelper.GetTopLevelCategories();
                int index = 1;
                foreach (var taxon in topLovelCategories)
                {
                    filterModel.Add(new JobFiltersModel() { TaxonamyName = taxon.Title, TaxonomyId = taxon.Id.ToString(), Selected = false, TrackId = index });
                    index++;
                }
                filterModel.Add(new JobFiltersModel() { TaxonamyName = "CompanyName", Selected = false, TrackId = index });
                this.SerializedJobFilterModel = JsonConvert.SerializeObject(filterModel);
            }
        }

        public List<JobFiltersModel> GetViewDesignerModel()
        {
            var filters = JsonConvert.DeserializeObject<List<JobFiltersModel>>(this.SerializedJobFilterModel);
            var selectedFilters = filters.Where(l => l.Selected == true).ToList();

            return selectedFilters;
        }

        public virtual string SerializedJobFilterModel { get; set; }
    }
}
