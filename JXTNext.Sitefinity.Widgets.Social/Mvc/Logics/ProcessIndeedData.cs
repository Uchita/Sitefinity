using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using JXTNext.SocialMedia.Models.Indeed;
using JXTNext.SocialMedia.Services.Indeed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class ProcessIndeedData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessIndeedData()
        {

        }

        // Interface method
        public SocialMediaProcessedResponse ProcessData(string data, string state, Stream stream)
        {
            Log.Write("ProcessData Indeed In : " + data, ConfigurationPolicy.ErrorLog);
            SocialMediaProcessedResponse processedResponse = null;
            if (data.IsNullOrEmpty() && stream != null)
            {
                Log.Write("ProcessData Indeed Intial Condtion pass : ", ConfigurationPolicy.ErrorLog);
                using (StreamReader reader = new StreamReader(stream))
                {
                    processedResponse = new SocialMediaProcessedResponse();
                    try
                    {
                        Log.Write("ProcessData Indeed entered try block : ", ConfigurationPolicy.ErrorLog);
                        var indeedData = reader.ReadToEnd();

                        IndeedSocialMediaRequest indeedReq = new IndeedSocialMediaRequest();
                        indeedReq.IndeedApplicationJson = indeedData;

                        IndeedSocialMediaService indeedSocialMediaService = new IndeedSocialMediaService();
                        // Indeed API call
                        var indeedAPIResponse = indeedSocialMediaService.ProcessSocialMediaIntegration<IndeedSocialMediaResponse, IndeedSocialMediaRequest>(indeedReq);

                        if(indeedAPIResponse.SocialMediaProcessSuccess)
                        {
                            Log.Write("ProcessData Indeed indeedAPIResponse.SocialMediaProcessSuccess : ", ConfigurationPolicy.ErrorLog);
                            processedResponse.Success = true;
                            processedResponse.Email = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.Email;
                            processedResponse.FirstName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.FirstName;
                            processedResponse.LastName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.LastName;
                            processedResponse.PhoneNumber = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.PhoneNumber;
                            processedResponse.FileStream = indeedAPIResponse.IndeedJobApplication.IndeedResume.data;
                            processedResponse.FileName = indeedAPIResponse.IndeedJobApplication.IndeedResume.fileName;

                            if (Int32.TryParse(indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobId, out int jobId))
                            {
                                Log.Write("ProcessData Indeed indeedAPIResponse.SocialMediaProcessSuccess job id is extracted : ", ConfigurationPolicy.ErrorLog);
                                processedResponse.JobId = jobId;
                            }
                        }
                        else
                        {
                            Log.Write("ProcessData Indeed indeedAPIResponse.SocialMediaProcessSuccess false: " + indeedAPIResponse.Errors.FirstOrDefault(), ConfigurationPolicy.ErrorLog);
                            processedResponse.Success = false;
                            processedResponse.Errors = indeedAPIResponse.Errors;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Write("ProcessData Indeed catch block : " + ex.Message, ConfigurationPolicy.ErrorLog);

                        processedResponse.Success = false;
                        List<string> errors = new List<string>();
                        errors.Add(ex.Message);
                        processedResponse.Errors = errors;
                    }
                }
            }
            return processedResponse;
        }
    }
}
