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

                if( responseObj["status"] == 200)
                    return new JXTNext_GetJobListingResponse { Success = true, Job = _jobMapper.ConvertToLocalEntity<JobDetailsFullModel>(JObject.Parse(responseObj["data"].Value)) };
                else
                    return new JXTNext_GetJobListingResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_GetJobListingResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IDeleteJobListingResponse AdvertiserDeleteJob(IDeleteJobListingRequest jobDetails)
        {
            JXTNext_DeleteJobListingRequest jobRequest = jobDetails as JXTNext_DeleteJobListingRequest;

            ConnectorDeleteRequest connectorRequest = new ConnectorDeleteRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/advertiseruser/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Delete(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_DeleteJobListingResponse { Success = true };
                else
                    return new JXTNext_DeleteJobListingResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_DeleteJobListingResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public void AdvertiserRegister()
        {
            throw new NotImplementedException();
        }

        public void AdvertiserUpdateJob()
        {
            throw new NotImplementedException();
        }

        public IMemberApplicationResponse MemberCreateJobApplication(IMemberApplication memberApplication, string emailOverride)
        {
            base.ProcessHeaderValuesForSessionOverride(emailOverride);
            return MemberCreateJobApplication(memberApplication);
        }

        public IMemberApplicationResponse MemberCreateJobApplication(IMemberApplication memberApplication)
        {
            JXTNext_MemberApplicationRequest application = memberApplication as JXTNext_MemberApplicationRequest;
            dynamic applyDetails = _memberMapper.Application_ConvertToAPIEntity(application);

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                Data = applyDetails,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/apply/job/{application.ApplyResourceID}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            { 
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_MemberApplicationResponse { Success = true, ApplicationID = (int?)responseObj["id"] };
                else
                    return new JXTNext_MemberApplicationResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberApplicationResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberApplicationResponse MemberCreateJobApplication_FileUploadUpdate(IMemberApplication memberApplication)
        {
            throw new NotImplementedException();
        }

        public bool MemberRegister(IMemberRegister memberDetails, out string errorMessage)
        {
            JXTNext_MemberRegister regRequest = memberDetails as JXTNext_MemberRegister;

            //convert with mapper
            dynamic apiObj = _memberMapper.Register_ConvertToAPIEntity<JXTNext_MemberRegister>(regRequest);

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                Data = apiObj,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/register")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            if (response.Success)
            {
                errorMessage = null;
                return true;
            }

            errorMessage = null;
            return response.Success;
        }

        public IGetJobListingResponse GuestGetJob(IGetJobListingRequest jobDetails)
        {
            JXTNext_GetJobListingRequest jobRequest = jobDetails as JXTNext_GetJobListingRequest;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/guest/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);
                JObject jobItem = JObject.Parse(responseObj["data"].Value);

                if (responseObj["status"] == 200)
                    return new JXTNext_GetJobListingResponse { Success = true, Job = _jobMapper.ConvertToLocalEntity<JobDetailsFullModel>(jobItem) };
                else
                    return new JXTNext_GetJobListingResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_GetJobListingResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public ISearchJobsResponse SearchJobs(ISearchJobsRequest search)
        {
            JXTNext_SearchJobsRequest jobSearch = search as JXTNext_SearchJobsRequest;

            //An extra logic layer should be added to handle this model conversion
            dynamic searchAPIModel = new { search = jobSearch, legacyJobSource = Settings_LegacyJobSource };

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/guest/job/search"),
                Data = searchAPIModel
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JsonConvert.DeserializeObject<dynamic>(response.Response);
                dynamic responseObjData = JsonConvert.DeserializeObject<dynamic>(responseObj.data.ToString());
                dynamic responseObjDataSearchResults = JsonConvert.DeserializeObject<dynamic>(responseObjData.jobsearchresults.ToString());

                if (responseObj["status"] == 200)
                    return new JXTNext_SearchJobsResponse { Success = true, Total = responseObjDataSearchResults.total,  SearchResults = _jobMapper.ConvertSearchResultsToLocal<JobDetailsFullModel>(responseObjDataSearchResults.searchResults) };
                else
                    return new JXTNext_SearchJobsResponse { Success = false, Errors = responseObj.errors };
            }
            else
                return new JXTNext_SearchJobsResponse { Success = false, Errors = new List<string> { response.Response } };
        }
    }
}
