using Jxt.Sitefinity.Jobs.Data.Model;
using Jxt.Sitefinity.Jobs.ViewModel;
using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;
using System.Collections.Generic;

namespace Jxt.Sitefinity.Jobs.Model
{
    public class JobsModel : IJobsModel
    {
        IBusinessLogicsConnector _jxtBLConnector;
        IJobsConverter _jxtJobsConverter;

        public JobsModel()
        {
            DrawDependencies();

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

            ISearchJobsRequest jobListingRequest = new JXTNext_SearchJobsRequest { };
            JXTNext_SearchJobsResponse jobListingResponse = (JXTNext_SearchJobsResponse) _jxtBLConnector.SearchJobs(jobListingRequest);

            if(jobListingResponse.Success)
            { 
                foreach (var jl in jobListingResponse.SearchResults)
                {
                    vmList.Add(this.GetVM(jl));
                }
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

        public void Delete(int id)
        {
            IDeleteJobListingRequest jobDeleteRequest = new JXTNext_DeleteJobListingRequest { JobID = id };
            IDeleteJobListingResponse jobDeleteResponse = _jxtBLConnector.AdvertiserDeleteJob(jobDeleteRequest);
        }

        private JobViewModel GetVM(JobDetailsFullModel jl)
        {
            return _jxtJobsConverter.Convert(jl);
        }

        private void DrawDependencies()
        {
            _jxtJobsConverter = new JXTNext_JobsConverter();

            IJobListingMapper jobMapper = new JXTNext_JobListingMapper();
            IMemberMapper memberMapper = new JXTNext_MemberMapper();
            IRequestSession session = new SFRequestSession();

            _jxtBLConnector = new JXTNextBusinessLogicsConnector(
                new List<IJobListingMapper> { jobMapper }, new List<IMemberMapper> { memberMapper }, session);

        }

        static volatile List<JobDetailsFullModel> jobs;
    }
}
