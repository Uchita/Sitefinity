using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public interface IBusinessLogicsConnector
    {
        IntegrationConnectorType ConnectorType { get; }

        void MemberRegister(IMemberRegister memberDetails);
        void MemberApplyJob();

        void AdvertiserRegister();
        ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListingRequest jobDetails);
        IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails);
        void AdvertiserUpdateJob();

        ISearchJobsResponse SearchJobs(ISearchJobsRequest search);
    }
}
