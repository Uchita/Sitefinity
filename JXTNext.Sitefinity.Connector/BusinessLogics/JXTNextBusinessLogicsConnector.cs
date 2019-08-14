using JXTNext.Common.API.Models;
using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public class JXTNextBusinessLogicsConnector : ConnectorBase, IBusinessLogicsConnector
    {
        IJobListingMapper _jobMapper;
        IMemberMapper _memberMapper;

        public IMemberGetByIdResponse GetMemberByEmail(string email)
        {
            try
            {
                ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
                {
                    HeaderValues = HTTP_Request_HeaderValues,
                    TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/GetMemberByEmail/{email}")
                };
                ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

                //parse the response
                bool actionSuccessful = response.Success;

                if (actionSuccessful)
                {
                    dynamic responseObj = JObject.Parse(response.Response);

                    if (responseObj["status"] == 200)
                        return new JXTNext_MemberGetByIdResponse { Success = true, Member = _memberMapper.Member_ConvertToLocalEntity<MemberModel>(responseObj) };
                    else
                        return new JXTNext_MemberGetByIdResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
                }
                else
                    return new JXTNext_MemberGetByIdResponse { Success = false, Errors = new List<string> { response.Response } };
            }
            catch (Exception ex)
            {

                return new JXTNext_MemberGetByIdResponse { Success = false, Errors = new List<string> { ex.Message } };
            }


        }

        public IMemberGetByIdResponse UpdateMember(MemberModel modelData)
        {
            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                Data = _memberMapper.Member_ConvertToAPIEntity(modelData),
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/UpdateMemberResumeFiles")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_MemberGetByIdResponse { Success = true, Member = _memberMapper.Member_ConvertToLocalEntity<MemberModel>(responseObj) };
                else
                    return new JXTNext_MemberGetByIdResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberGetByIdResponse { Success = false, Errors = new List<string> { response.Response } };
        }


        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.JXTNext;

        public JXTNextBusinessLogicsConnector(IEnumerable<IJobListingMapper> jobMappers, IEnumerable<IMemberMapper> memberMapper, IRequestSession session) : base(session)
        {
            _jobMapper = jobMappers.Where(c => c.mapperType == IntegrationMapperType.JXTNext).FirstOrDefault();
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

            if (actionSuccessful)
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

                if (responseObj["status"] == 200)
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

        public IMemberSaveJobResponse MemberSaveJob(IMemberSaveJob saveJob)
        {
            JXTNext_MemberSaveJobRequest saveRequest = saveJob as JXTNext_MemberSaveJobRequest;

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/job/{saveRequest.JobId}/save")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_MemberSaveJobResponse { Success = true, SavedJobId = (int?)responseObj["id"] };
                else
                    return new JXTNext_MemberSaveJobResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberSaveJobResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberGetSavedJobsResponse MemberGetSavedJobs()
        {
            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/job/saved")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                {
                    return new JXTNext_MemberGetSavedJobResponse { Success = true, SavedJobs = _memberMapper.MemberSavedJob_ConvertToLocalEntity<MemberSavedJob>(JsonConvert.DeserializeObject<dynamic>(responseObj["data"].ToString())) };
                }
                else
                    return new JXTNext_MemberGetSavedJobResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberGetSavedJobResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberSaveJobResponse MemberDeleteSavedJob(int savedJobId)
        {
            ConnectorDeleteRequest connectorRequest = new ConnectorDeleteRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/job/saved/{savedJobId}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Delete(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                {
                    return new JXTNext_MemberSaveJobResponse { Success = true };
                }
                else
                    return new JXTNext_MemberSaveJobResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberSaveJobResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberUpsertJobAlertResponse MemberUpsertJobAlert(IMemberUpsertJobAlertRequest jobAlert, bool isUserLoggedIn)
        {
            JXTNext_MemberUpsertJobAlertRequest createJobAlert = jobAlert as JXTNext_MemberUpsertJobAlertRequest;

            if (createJobAlert.MemberJobAlertId.HasValue)
                return MemberUpdateJobAlert(createJobAlert);
            else
                return MemberCreateJobAlert(createJobAlert, isUserLoggedIn);
        }

        public IMemberJobAlertsResponse MemberJobAlertsGet()
        {
            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/jobalert")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                {
                    dynamic jobAlerts = JsonConvert.DeserializeObject<dynamic>(responseObj["data"].ToString());
                    return new JXTNext_MemberJobAlertsResponse { Success = true, MemberJobAlerts = jobAlerts };
                }
                else
                    return new JXTNext_MemberJobAlertsResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberJobAlertsResponse { Success = false, Errors = new List<string> { response.Response } };

        }

        public IMemberJobAlertsResponse MemberJobAlertGet(int jobAlertId)
        {
            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/jobalert/{jobAlertId}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                {
                    dynamic jobAlert = JsonConvert.DeserializeObject<dynamic>(responseObj["data"].ToString());
                    return new JXTNext_MemberJobAlertsResponse { Success = true, MemberJobAlerts = jobAlert };
                }
                else
                    return new JXTNext_MemberJobAlertsResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberJobAlertsResponse { Success = false, Errors = new List<string> { response.Response } };

        }

        public IBaseResponse MemberJobAlertDelete(int jobAlertId)
        {
            ConnectorDeleteRequest connectorRequest = new ConnectorDeleteRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/jobalert/{jobAlertId}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Delete(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_MemberJobAlertDeleteResponse { Success = true };
                else
                    return new JXTNext_MemberJobAlertDeleteResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberJobAlertDeleteResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberAppliedJobResponse MemberAppliedJobGetByJobId(int jobId)
        {
            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/job/{jobId}/MemberAppliedJobGetByJobId")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200 && responseObj["data"] != null)
                {
                    return new JXTNext_MemberAppliedJobByIdResponse { Success = true, MemberAppliedJobById = JsonConvert.DeserializeObject<MemberAppliedJob>(responseObj["data"].ToString()) };
                }
                else
                    return new JXTNext_MemberAppliedJobByIdResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberAppliedJobByIdResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IMemberAppliedJobResponse MemberAppliedJobsGet()
        {
            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/jobapplications")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200 && responseObj["data"] != null)
                {
                    return new JXTNext_MemberAppliedJobResponse { Success = true, MemberAppliedJobs = _memberMapper.MemberAppliedJob_ConvertToLocalEntity<MemberAppliedJob>(JsonConvert.DeserializeObject<dynamic>(responseObj["data"].ToString())) };
                }
                else
                    return new JXTNext_MemberAppliedJobResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberAppliedJobResponse { Success = false, Errors = new List<string> { response.Response } };
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

            if (jobSearch.FieldSearches == null)
            {
                dynamic fieldSearch = new ExpandoObject();
                fieldSearch.Status = 1;
                jobSearch.FieldSearches = fieldSearch;
            }

            jobSearch.FieldRanges = new RangeSearch() { ExpiryDate = new DateRange() { LowerRange = (long)DateTime.Now.ToUniversalTime().Subtract(UnixEpoch).TotalMilliseconds } };
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
                dynamic responseObjDataSearchResultsFilters = JsonConvert.DeserializeObject<dynamic>(responseObjData.SearchResultsFilters.ToString());

                if (responseObj["status"] == 200)
                    return new JXTNext_SearchJobsResponse { Success = true, Total = responseObjDataSearchResults.total, SearchResults = _jobMapper.ConvertSearchResultsToLocal<JobDetailsFullModel>(responseObjDataSearchResults.searchResults), SearchResultsFilters = _jobMapper.ConvertSearchResultsFiltersToLocal<JobFilterRoot>(responseObjDataSearchResultsFilters.Data) };

                else
                    return new JXTNext_SearchJobsResponse { Success = false, Errors = responseObj.errors };
            }
            else
                return new JXTNext_SearchJobsResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        public IBaseResponse UnsubscribeJobAlert(Guid unsubscribeGuid)
        {
            ConnectorPutRequest connectorRequest = new ConnectorPutRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/unsubscribe/jobalert/"),
                Data = new { UnsubscribeGuid = unsubscribeGuid }
            };

            ConnectorResponse response = JXTNext.Common.API.Connector.Put(connectorRequest);

            if (response.Success)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                {
                    return new JXTNext_MemberJobAlertUnsubscribeResponse { Success = true };
                }
                else
                {
                    return new JXTNext_MemberJobAlertUnsubscribeResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
                }
            }
            else
            {
                return new JXTNext_MemberJobAlertUnsubscribeResponse { Success = false, Errors = new List<string> { response.Response } };
            }
        }

        #region Private Members
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        #region Private Methods

        private IMemberUpsertJobAlertResponse MemberUpdateJobAlert(JXTNext_MemberUpsertJobAlertRequest jobAlert)
        {
            ConnectorPutRequest connectorRequest = new ConnectorPutRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                Data = jobAlert,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/member/jobalert/{jobAlert.MemberJobAlertId}")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Put(connectorRequest);

            return ProcessJobAlertResponse(response);
        }

        private IMemberUpsertJobAlertResponse MemberCreateJobAlert(JXTNext_MemberUpsertJobAlertRequest jobAlert, bool isUserLoggedIn)
        {
            string path = $"/api/member/email/{jobAlert.Email}/jobalert";
            if (!isUserLoggedIn)
                path = $"/api/guest/email/{jobAlert.Email}/jobalert";

            ConnectorPostRequest connectorRequest = new ConnectorPostRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = base.HTTP_Request_HeaderValues,
                Data = jobAlert,
                TargetUri = new Uri(CONFIG_DataAccessTarget + path)
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Post(connectorRequest);

            return ProcessJobAlertResponse(response);
        }

        /// <summary>
        /// Potentially you should modify this to use generic types and process standrad responses for all connector requests
        /// Because as you can see currently there are a lot of duplicated code
        /// </summary>
        /// <returns></returns>
        private JXTNext_MemberUpsertJobAlertResponse ProcessJobAlertResponse(ConnectorResponse response)
        {
            //parse the response
            bool actionSuccessful = response.Success;

            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                if (responseObj["status"] == 200)
                    return new JXTNext_MemberUpsertJobAlertResponse { Success = true, MemberJobAlertId = (int?)responseObj["id"] };
                else
                    return new JXTNext_MemberUpsertJobAlertResponse { Success = false, Errors = JsonConvert.DeserializeObject<List<string>>(responseObj["errors"].ToString()) };
            }
            else
                return new JXTNext_MemberUpsertJobAlertResponse { Success = false, Errors = new List<string> { response.Response } };
        }

        #endregion

    }
}
