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
        IMemberSaveJobResponse MemberSaveJob(IMemberSaveJob saveJob);
        IMemberGetSavedJobsResponse MemberGetSavedJobs();
        IMemberSaveJobResponse MemberDeleteSavedJob(int savedJobId);
        IMemberUpsertJobAlertResponse MemberUpsertJobAlert(IMemberUpsertJobAlertRequest jobAlert, bool isUserLoggedIn = true);
        IMemberJobAlertsResponse MemberJobAlertsGet();
        IMemberJobAlertsResponse MemberJobAlertGet(int jobAlertId);
        IBaseResponse MemberJobAlertDelete(int jobAlertId);
        IMemberAppliedJobResponse MemberAppliedJobsGet();
        IMemberGetByIdResponse GetMemberByEmail(string email);
        IMemberGetByIdResponse UpdateMember(MemberModel modelData);
        IMemberAppliedJobResponse MemberAppliedJobGetByJobId(int jobId);
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
