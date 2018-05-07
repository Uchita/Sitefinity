using Jxt.Sitefinity.Jobs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxt.Sitefinity.Jobs.Model
{
    public class JobsModel
    {
        public List<JobViewModel> GetListViewModel()
        {
            var manager = JobsManager.GetManager();
            var jobListings = manager.GetJobListings();
            var vmList = new List<JobViewModel>();

            foreach (var jl in jobListings)
            {
                vmList.Add(new JobViewModel() { Id = jl.Id, Title = jl.Title, Description = jl.Description });
            }

            return vmList;
        }

        public JobViewModel GetEditViewModel(Guid id)
        {
            var manager = JobsManager.GetManager();
            var jl = manager.GetJobListing(id);
            return new JobViewModel() { Id = jl.Id, Title = jl.Title, Description = jl.Description };
        }
    }
}
