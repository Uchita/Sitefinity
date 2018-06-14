using Jxt.Sitefinity.Jobs.Data.Model;
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
        static JobsModel()
        {
            jobs = new List<JobListing>()
            {
                new JobListing() { Id = Guid.NewGuid(), Title = "Software Developer - default", Description = "test" },
                new JobListing() { Id = Guid.NewGuid(), Title = "UX Architect - default", Description = "test" },
                new JobListing() { Id = Guid.NewGuid(), Title = "QA Engineer - default", Description = "test" }
            };
        }
        
        public JobViewModel GetSingleViewModel(Guid id)
        {
            var jl = jobs.Single(j => j.Id == id);
            return new JobViewModel() { Id = jl.Id, Title = jl.Title, Description = jl.Description };
        }
        
        public List<JobViewModel> GetListViewModel()
        {
            var vmList = new List<JobViewModel>();

            foreach (var jl in jobs)
            {
                vmList.Add(this.GetVM(jl));
            }

            return vmList;
        }

        public JobViewModel Create(JobViewModel job)
        {
            var jl = new JobListing();
            jl.Title = job.Title;
            jl.Description = job.Description;

            if (job.Id == Guid.Empty)
                jl.Id = Guid.NewGuid();
            else
                jl.Id = job.Id;

            jobs.Add(jl);
            return this.GetVM(jl);
        }
        
        public JobViewModel Update(JobViewModel job)
        {
            this.Delete(job.Id);
            this.Create(job);
            return job;
        }

        public void Delete(Guid id)
        {
            jobs.Remove(jobs.Single(j => j.Id == id));
        }

        private JobViewModel GetVM(JobListing jl)
        {
            return new JobViewModel() { Id = jl.Id, Title = jl.Title, Description = jl.Description };
        }

        static volatile List<JobListing> jobs;
    }
}
