using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public interface IBusinessLogicsConnector
    {
        IntegrationConnectorType ConnectorType { get; }

        bool MemberRegister(IMemberRegister memberDetails, out string errorMessage);
        void MemberApplyJob();

        void AdvertiserRegister();
        ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListingRequest jobDetails);
        IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails);
        void AdvertiserUpdateJob();
        IDeleteJobListingResponse AdvertiserDeleteJob(IDeleteJobListingRequest jobDetails);

        ISearchJobsResponse SearchJobs(ISearchJobsRequest search);
    }
}
