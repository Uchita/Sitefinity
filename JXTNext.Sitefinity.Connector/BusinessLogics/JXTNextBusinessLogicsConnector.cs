using JXTNext.Common.API.Models;
using JXTNext.Sitefinity.Common.Models;
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

        public JXTNextBusinessLogicsConnector(IEnumerable<IJobListingMapper> jobMappers, IEnumerable<IMemberMapper> memberMapper, IRequestSession session) : base(session)
        {
            _jobMapper = jobMappers.Where(c=>c.mapperType == IntegrationMapperType.JXTNext).FirstOrDefault();
            _memberMapper = memberMapper.Where(c => c.mapperType == IntegrationMapperType.JXTNext).FirstOrDefault();
        }

        public ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListingRequest jobDetails)
        {
            JXTNext_CreateJobListingRequest jobRequest = jobDetails as JXTNext_CreateJobListingRequest;

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                Data = _jobMapper.ConvertToAPIEntity(jobDetails.JobData),
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiseruser/job")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            if( actionSuccessful)
                return new JXTNext_CreateJobListingResponse(true, data["JobId"] as int?);
            else
                return new JXTNext_CreateJobListingResponse(false, (List<string>)data["errors"]);
        }

        public IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails)
        {
            JXTNext_GetJobListingRequest jobRequest = jobDetails as JXTNext_GetJobListingRequest;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiseruser/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);
                return new JXTNext_GetJobListingResponse { Success = true, Job = _jobMapper.ConvertToLocalEntity<JobDetailsModel>(responseObj) };
            }
            else
                return new JXTNext_GetJobListingResponse { Success = false, Errors = new List<string> { response.Response } };
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
                HeaderValues = base.HTTP_Request_HeaderValues,
                Data = JsonConvert.SerializeObject(apiObj),
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/register")
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
