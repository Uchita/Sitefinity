using JXTNext.Common.JXTAPI.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using System;
using System.Configuration;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public class JXTNextBusinessLogicsConnector : IBusinessLogicsConnector
    {
        string API_TARGET_PATH = ConfigurationManager.AppSettings["JXTNextAPI_Path"];
        IJobListingMapper _jobMapper;

        public JXTNextBusinessLogicsConnector(IJobListingMapper jobMapper)
        {
            _jobMapper = jobMapper;
        }

        public ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListing jobDetails)
        {
            JXTNext_CreateJobListing jobRequest = jobDetails as JXTNext_CreateJobListing;

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest
            {
                Data = _jobMapper.To(jobDetails.JobData),
                TargetUri = new Uri(API_TARGET_PATH + $"/api/advertiser/job")
            };
            ConnectorResponse response = JXTNext.Common.JXTAPI.Connector.Post(connectorRequest);

            return new JXTNext_CreateJobListingResponse { Success = response.Success, Message = response.Response };
        }

        public IGetJobListingResponse AdvertiserGetJob(IGetJobListing jobDetails)
        {
            JXTNext_GetJobListing jobRequest = jobDetails as JXTNext_GetJobListing;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest
            {
                TargetUri = new Uri(API_TARGET_PATH + $"/api/advertiser/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.JXTAPI.Connector.Get(connectorRequest);

            return new JXTNext_GetJobListingResponse { Success = response.Success, Message = response.Response };
        }

        public void AdvertiserRegister()
        {
            throw new NotImplementedException();
        }

        public void AdvertiserUpdateJob()
        {
            throw new NotImplementedException();
        }

        public void MemberApplyJob()
        {
            throw new NotImplementedException();
        }

        public void MemberRegister()
        {
            throw new NotImplementedException();
        }

        public void SearchJob()
        {
            throw new NotImplementedException();
        }

        public ISearchJobsResponse SearchJobs(ISearchJobs search)
        {
            throw new NotImplementedException();
        }
    }
}
