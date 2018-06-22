using JXTNext.Common.API.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public class TestBusinessLogicsConnector : IBusinessLogicsConnector
    {
        #region Mock Data

        List<JobDetailsFullModel> AvailablJobs;

        public void InitData()
        {
            JobFilterRoot Australia_Sydney_Central = new JobFilterRoot { ID = "AE-1234", Filters = new List<JobFilter> { new JobFilter { ID = "DD-3123", Filters = new List<JobFilter> { new JobFilter { ID = "EG-12553223", Filters = new List<JobFilter> { new JobFilter { ID = "F4-98723" } } } } } } };
            JobFilterRoot Australia_Sydney_Central_TownHall = new JobFilterRoot { ID = "AE-1234", Filters = new List<JobFilter> { new JobFilter { ID = "DD-3123", Filters = new List<JobFilter> { new JobFilter { ID = "EG-12553223", Filters = new List<JobFilter> { new JobFilter { ID = "F4-98723" }, new JobFilter { ID = "FG-13223" } } } } } } };
            JobFilterRoot Australia_Melbourne_George = new JobFilterRoot { ID = "AE-1234", Filters = new List<JobFilter> { new JobFilter { ID = "DD-3123", Filters = new List<JobFilter> { new JobFilter { ID = "EG-1573223", Filters = new List<JobFilter> { new JobFilter { ID = "FG-1393" } } } } } } };
            JobFilterRoot Australia_Melbourne_George_Pitt_Central = new JobFilterRoot { ID = "AE-1234", Filters = new List<JobFilter> { new JobFilter { ID = "DD-3123", Filters = new List<JobFilter> { new JobFilter { ID = "EG-1573223", Filters = new List<JobFilter> { new JobFilter { ID = "FG-1393" }, new JobFilter { ID = "BX-1373" }, new JobFilter { ID = "LG-9a233" } } } } } } };

            JobFilterRoot NZ_Auckland = new JobFilterRoot { ID = "AE-1234", Filters = new List<JobFilter> { new JobFilter { ID = "HD-345", Filters = new List<JobFilter> { new JobFilter { ID = "AF-0f34" } } } } };


            JobFilterRoot Accounting_AccountantCost_AccountantFinancial = new JobFilterRoot { ID = "AE-8654", Filters = new List<JobFilter> { new JobFilter { ID = "KJ-3755", Filters = new List<JobFilter> { new JobFilter { ID = "EG-1223" }, new JobFilter { ID = "AB-gg3223" } } } } };
            JobFilterRoot Accounting_AccountantTax = new JobFilterRoot { ID = "AE-8654", Filters = new List<JobFilter> { new JobFilter { ID = "KJ-3755", Filters = new List<JobFilter> { new JobFilter { ID = "EH-123523" } } } } };
            JobFilterRoot Sales_Analyst_Telesales_Causal = new JobFilterRoot { ID = "AE-8654", Filters = new List<JobFilter> { new JobFilter { ID = "GF-3783", Filters = new List<JobFilter> { new JobFilter { ID = "EG-6890" }, new JobFilter { ID = "EG-4gj5" }, new JobFilter { ID = "EG-gg345" } } } } };

            AvailablJobs = new List<JobDetailsFullModel>
            {
                new JobDetailsFullModel { JobID = "1", Title = "Job Title 1", Description = "Job Description 1", ShortDescription = "Short Description 1", Filters = new List<JobFilterRoot> { Australia_Sydney_Central, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "3", Title = "Job Title 3", Description = "Job Description 3", ShortDescription = "Short Description 3", Filters = new List<JobFilterRoot> { Australia_Sydney_Central_TownHall, Accounting_AccountantTax } },
                new JobDetailsFullModel { JobID = "5", Title = "Job Title 5", Description = "Job Description 5", ShortDescription = "Short Description 5", Filters = new List<JobFilterRoot> { Australia_Melbourne_George, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "7", Title = "Job Title 7", Description = "Job Description 7", ShortDescription = "Short Description 7", Filters = new List<JobFilterRoot> { Australia_Sydney_Central, Accounting_AccountantTax } },
                new JobDetailsFullModel { JobID = "8", Title = "Job Title 9", Description = "Job Description 9", ShortDescription = "Short Description 9", Filters = new List<JobFilterRoot> { NZ_Auckland, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "1A", Title = "Job Title 1A", Description = "Job Description 1A", ShortDescription = "Short Description 1A", Filters = new List<JobFilterRoot> { Australia_Sydney_Central, Sales_Analyst_Telesales_Causal } },
                new JobDetailsFullModel { JobID = "3A", Title = "Job Title 3A", Description = "Job Description 3A", ShortDescription = "Short Description 3A", Filters = new List<JobFilterRoot> { Australia_Sydney_Central_TownHall, Sales_Analyst_Telesales_Causal } },
                new JobDetailsFullModel { JobID = "5A", Title = "Job Title 5A", Description = "Job Description 5A", ShortDescription = "Short Description 5A", Filters = new List<JobFilterRoot> { Australia_Melbourne_George, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "7A", Title = "Job Title 7A", Description = "Job Description 7A", ShortDescription = "Short Description 7A", Filters = new List<JobFilterRoot> { NZ_Auckland, Accounting_AccountantTax } },
                new JobDetailsFullModel { JobID = "8A", Title = "Job Title 9A", Description = "Job Description 9A", ShortDescription = "Short Description 9A", Filters = new List<JobFilterRoot> { Australia_Sydney_Central, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "1B", Title = "Job Title 1B", Description = "Job Description 1B", ShortDescription = "Short Description 1B", Filters = new List<JobFilterRoot> { Australia_Sydney_Central_TownHall, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "3B", Title = "Job Title 3B", Description = "Job Description 3B", ShortDescription = "Short Description 3B", Filters = new List<JobFilterRoot> { NZ_Auckland, Accounting_AccountantTax } },
                new JobDetailsFullModel { JobID = "5B", Title = "Job Title 5B", Description = "Job Description 5B", ShortDescription = "Short Description 5B", Filters = new List<JobFilterRoot> { Australia_Melbourne_George, Accounting_AccountantCost_AccountantFinancial } },
                new JobDetailsFullModel { JobID = "7B", Title = "Job Title 7B", Description = "Job Description 7B", ShortDescription = "Short Description 7B", Filters = new List<JobFilterRoot> { Australia_Sydney_Central_TownHall, Sales_Analyst_Telesales_Causal } },
                new JobDetailsFullModel { JobID = "8B", Title = "Job Title 9B", Description = "Job Description 9B", ShortDescription = "Short Description 9B", Filters = new List<JobFilterRoot> { NZ_Auckland, Sales_Analyst_Telesales_Causal } }
            };
        }

        #endregion

        string API_TARGET_PATH = ConfigurationManager.AppSettings["JXTNextAPI_Path"];
        int API_Operation_MaxWaitTimeMs;
        IJobListingMapper _jobMapper;

        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.Test;

        public TestBusinessLogicsConnector(IEnumerable<IJobListingMapper> jobMappers)
        {
            _jobMapper = jobMappers.Where(c => c.mapperType == IntegrationMapperType.Test).FirstOrDefault();

            bool parseWaitTimeSuccess = int.TryParse(ConfigurationManager.AppSettings["JXTNextAPI_WaitTimeMs"], out API_Operation_MaxWaitTimeMs);
            if (!parseWaitTimeSuccess)
                API_Operation_MaxWaitTimeMs = 10000; //set default

            InitData();
        }

        public ICreateJobListingResponse AdvertiserCreateJob(ICreateJobListing jobDetails)
        {
            throw new NotImplementedException();
        }

        public IGetJobListingResponse AdvertiserGetJob(IGetJobListingRequest jobDetails)
        {
            Test_GetJobListingRequest jobRequest = jobDetails as Test_GetJobListingRequest;

            JobDetailsFullModel jobSearchResults = AvailablJobs.Where(c => c.JobID == jobRequest.JobID).FirstOrDefault();

            if (jobSearchResults != null)
                return new Test_GetJobListingResponse { Success = true, Job = jobSearchResults };
            else
                return new Test_GetJobListingResponse { Success = false, Messages = new List<string> { "Requested job was not found" } };
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

        public void MemberRegister(IMemberRegister memberRegister)
        {
            throw new NotImplementedException();
        }

        public ISearchJobsResponse SearchJobs(ISearchJobsRequest search)
        {
            Test_SearchJobsRequest searchDetails = (Test_SearchJobsRequest)search;
            int page = searchDetails.Page;
            int pageSize = searchDetails.PageSize;
            bool hasAnySearchElements = false;

            if(searchDetails != null && searchDetails.FiltersSearch != null)
                hasAnySearchElements = searchDetails.FiltersSearch.Where(c => c.HasSearchElements).Any();

            if (string.IsNullOrEmpty(searchDetails.Keywords) && (searchDetails.FiltersSearch == null || !hasAnySearchElements))
            {
                List<JobDetailsFullModel> availablJobssToReturn = AvailablJobs.Skip(page * pageSize).Take(pageSize).ToList();
                return new Test_SearchJobsResponse { Total = AvailablJobs.Count(), Count = availablJobssToReturn.Count(), SearchResults = availablJobssToReturn };
            }

            List<JobDetailsFullModel> jobsMatched;
            
            if(hasAnySearchElements)
            { 
                jobsMatched = new List<JobDetailsFullModel>();

                searchDetails.FiltersSearch.ForEach(filterRoot => {

                    string rootID = filterRoot.RootID;
                    string targetID = filterRoot.Filters.FirstOrDefault().ID;

                    //this is not the actual search logic, just a quick and dirty search will do
                    //for now, we will just search the first level ID, if its found then its valid                            
                    foreach (JobDetailsFullModel job in AvailablJobs)
                    {
                        bool searchMatch = job.FakeSearch(filterRoot.RootID, targetID);

                        if (searchMatch && !jobsMatched.Where(c => c.JobID == job.JobID).Any())
                            jobsMatched.Add(job);
                    }

                });
            }
            else
            {
                //return the full list of jobs
                jobsMatched = AvailablJobs;
            }

            //next filter by keywords
            if ( !string.IsNullOrWhiteSpace(searchDetails.Keywords ))
                jobsMatched = jobsMatched.Where(c => c.Title.Contains(searchDetails.Keywords) || c.Description.Contains(searchDetails.Keywords) || c.ShortDescription.Contains(searchDetails.Keywords)).ToList();

            List<JobDetailsFullModel> jobsToReturn = jobsMatched.Skip(page * pageSize).Take(pageSize).ToList();
            Test_SearchJobsResponse response = new Test_SearchJobsResponse { Total = jobsMatched.Count(), Count = jobsToReturn.Count(), SearchResults = jobsToReturn };
            return response;
        }
    }
}
