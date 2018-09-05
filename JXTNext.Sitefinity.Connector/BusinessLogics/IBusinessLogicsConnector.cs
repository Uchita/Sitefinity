using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public interface IBusinessLogicsConnector
    {
        IntegrationConnectorType ConnectorType { get; }

        #region Member Calls
        bool MemberRegister(IMemberRegister memberDetails, out string errorMessage);
        IMemberApplicationResponse MemberCreateJobApplication(IMemberApplication memberApplication, string emailOverride);
        IMemberApplicationResponse MemberCreateJobApplication(IMemberApplication memberApplication);
        IMemberApplicationResponse MemberCreateJobApplication_FileUploadUpdate(IMemberApplication memberApplication);
        IMemberCreateJobAlertResponse MemberCreateJobAlert(IMemberCreateJobAlertRequest jobAlert);
        IMemberJobAlertsResponse MemberJobAlertsGet();
        IMemberJobAlertsResponse MemberJobAlertGet(int jobAlertId);
        IBaseResponse MemberJobAlertDelete(int jobAlertId);
        #endregion

        #region Advertiser User Calls
        void AdvertiserRegister();
        ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListingRequest jobDetails);
        IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails);
        void AdvertiserUpdateJob();
        IDeleteJobListingResponse AdvertiserDeleteJob(IDeleteJobListingRequest jobDetails);
        #endregion

        #region Guest Calls
        IGetJobListingResponse GuestGetJob(IGetJobListingRequest jobDetails);
        #endregion

        ISearchJobsResponse SearchJobs(ISearchJobsRequest search);
    }
}
