﻿using JXTNext.Common.JXTAPI.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public class JXTNextBusinessLogicsConnector : IBusinessLogicsConnector
    {
        string API_TARGET_PATH = ConfigurationManager.AppSettings["JXTNextAPI_Path"];
        int API_Operation_MaxWaitTimeMs;
        IJobListingMapper _jobMapper;

        public JXTNextBusinessLogicsConnector(IJobListingMapper jobMapper)
        {
            _jobMapper = jobMapper;

            bool parseWaitTimeSuccess = int.TryParse(ConfigurationManager.AppSettings["JXTNextAPI_WaitTimeMs"], out API_Operation_MaxWaitTimeMs);
            if (!parseWaitTimeSuccess)
                API_Operation_MaxWaitTimeMs = 10000; //set default
        }

        public ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListing jobDetails)
        {
            JXTNext_CreateJobListing jobRequest = jobDetails as JXTNext_CreateJobListing;

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(API_Operation_MaxWaitTimeMs)
            {
                Data = _jobMapper.To(jobDetails.JobData),
                TargetUri = new Uri(API_TARGET_PATH + $"/api/advertiser/job")
            };
            ConnectorResponse response = JXTNext.Common.JXTAPI.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            if( actionSuccessful)
                return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, Message = response.Response };
            else
                return new JXTNext_CreateJobListingResponse { Success = actionSuccessful, Message = ((List<string>)data["errors"]).FirstOrDefault()};
        }

        public IGetJobListingResponse AdvertiserGetJob(IGetJobListing jobDetails)
        {
            JXTNext_GetJobListing jobRequest = jobDetails as JXTNext_GetJobListing;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(API_Operation_MaxWaitTimeMs)
            {
                TargetUri = new Uri(API_TARGET_PATH + $"/api/advertiser/job/{jobRequest.JobID}")
            };
            ConnectorResponse response = JXTNext.Common.JXTAPI.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            dynamic data = JObject.Parse(response.Response);

            if (actionSuccessful)
                return new JXTNext_GetJobListingResponse { Success = actionSuccessful, Message = response.Response };
            else
                return new JXTNext_GetJobListingResponse { Success = actionSuccessful, Message = ((List<string>)data["errors"]).FirstOrDefault() };
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