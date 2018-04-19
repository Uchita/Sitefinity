using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public interface IBusinessLogicsConnector
    {
        void MemberRegister();
        void MemberApplyJob();

        void AdvertiserRegister();
        ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListing jobDetails);
        IGetJobListingResponse AdvertiserGetJob(IGetJobListing jobDetails);
        void AdvertiserUpdateJob();

        ISearchJobsResponse SearchJobs(ISearchJobs search);
        void SearchJob();
    }
}
