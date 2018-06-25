using Jxt.Sitefinity.Jobs.Data.Model;
using Jxt.Sitefinity.Jobs.ViewModel;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxt.Sitefinity.Jobs.Model
{
    public class JobsModel
    {
        IBusinessLogicsConnector _jxtBLConnector;
        IJobsConverter _jxtJobsConverter;

        static JobsModel()
        {
            jobs = new List<JobDetailsFullModel>()
            {
                new JobDetailsFullModel() { JobID = 123, Title = "Software Developer - default", Description = "test" },
                new JobDetailsFullModel() { JobID = 456, Title = "UX Architect - default", Description = "test" },
                new JobDetailsFullModel() { JobID = 789, Title = "QA Engineer - default", Description = "test" }
            };
        }
        
        public JobViewModel GetSingleViewModel(int id)
        {
            IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = id };
            IGetJobListingResponse jobListingResponse = _jxtBLConnector.AdvertiserGetJob(jobListingRequest);

            if (jobListingResponse.Job == null)
                return null;

            return this.GetVM(jobListingResponse.Job);
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

            ICreateJobListingRequest jobCreateRequest = new JXTNext_CreateJobListingRequest {  JobData = _jxtJobsConverter.Convert(job) };
            ICreateJobListingResponse jobCreateResponse = _jxtBLConnector.AdvertiserCreateJob(jobCreateRequest);

            if (jobCreateResponse.JobId.HasValue)
                return GetSingleViewModel(jobCreateResponse.JobId.Value);
            else
                return null;
        }
        
        public JobViewModel Update(JobViewModel job)
        {
            //this.Delete(job.Id);
            //this.Create(job);
            return job;
        }

        public void Delete(Guid id)
        {
            //jobs.Remove(jobs.Single(j => j.Id == id));
        }

        private JobViewModel GetVM(JobDetailsFullModel jl)
        {
            return _jxtJobsConverter.Convert(jl);
        }

        static volatile List<JobDetailsFullModel> jobs;
    }
}
