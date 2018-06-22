using JXTNext.Common.API.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public class JXTNextBusinessLogicsConnector : ConnectorBase, IBusinessLogicsConnector
    {
        IJobListingMapper _jobMapper;
        IMemberMapper _memberMapper;

        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.JXTNext;

        public JXTNextBusinessLogicsConnector(IEnumerable<IJobListingMapper> jobMappers, IEnumerable<IMemberMapper> memberMapper) : base()
        {
            _jobMapper = jobMappers.Where(c=>c.mapperType == IntegrationMapperType.JXTNext).FirstOrDefault();
            _memberMapper = memberMapper.Where(c => c.mapperType == IntegrationMapperType.JXTNext).FirstOrDefault();
        }

        public ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListing jobDetails)
        {
            JXTNext_CreateJobListing jobRequest = jobDetails as JXTNext_CreateJobListing;

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                Data = _jobMapper.ConvertToAPIEntity(jobDetails.JobData),
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiser/job")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            if( actionSuccessful)
                return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, JobId = data["JobId"] };
            else
                return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, Messages = (List<string>)data["errors"]};
        }

        public IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails)
        {
            JXTNext_GetJobListing jobRequest = jobDetails as JXTNext_GetJobListing;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiser/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            if (actionSuccessful)
                return new JXTNext_GetJobListingResponse { Success = actionSuccessful, Job = _jobMapper.ConvertToLocalEntity<JobDetailsModel>(data) };
            else
                return new JXTNext_GetJobListingResponse { Success = actionSuccessful, Messages = (List<string>)data["errors"] };
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

        public void MemberRegister(IMemberRegister memberDetails)
        {
            JXTNext_MemberRegister regRequest = memberDetails as JXTNext_MemberRegister;

            //convert with mapper
            dynamic apiObj = _memberMapper.Register_ConvertToAPIEntity<JXTNext_MemberRegister>(regRequest);

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                Data = JsonConvert.SerializeObject(apiObj),
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiser/job")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            //if (actionSuccessful)
            //    return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, JobId = data["JobId"] };
            //else
            //    return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, Messages = (List<string>)data["errors"] };
        }

        public ISearchJobsResponse SearchJobs(ISearchJobsRequest search)
        {
            throw new NotImplementedException();
        }
    }
}
