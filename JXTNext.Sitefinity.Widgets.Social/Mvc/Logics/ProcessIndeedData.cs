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
            SocialMediaProcessedResponse processedResponse = null;
            if (data.IsNullOrEmpty() && stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    processedResponse = new SocialMediaProcessedResponse();
                    try
                    {
                        var indeedData = reader.ReadToEnd();

                        IndeedSocialMediaRequest indeedReq = new IndeedSocialMediaRequest();
                        indeedReq.IndeedApplicationJson = indeedData;

                        IndeedSocialMediaService indeedSocialMediaService = new IndeedSocialMediaService();
                        // Indeed API call
                        var indeedAPIResponse = indeedSocialMediaService.ProcessSocialMediaIntegration<IndeedSocialMediaResponse, IndeedSocialMediaRequest>(indeedReq);

                        if(indeedAPIResponse.SocialMediaProcessSuccess)
                        {
                            processedResponse.Success = true;
                            processedResponse.Email = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.Email;
                            processedResponse.FirstName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.FirstName;
                            processedResponse.LastName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.LastName;
                            processedResponse.PhoneNumber = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.PhoneNumber;
                            processedResponse.FileStream = indeedAPIResponse.IndeedJobApplication.IndeedResume.data;
                            processedResponse.FileName = indeedAPIResponse.IndeedJobApplication.IndeedResume.fileName;

                            if (Int32.TryParse(indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobId, out int jobId))
                                processedResponse.JobId = jobId;
                        }
                        else
                        {
                            processedResponse.Success = false;
                            processedResponse.Errors = indeedAPIResponse.Errors;
                        }
                    }
                    catch (Exception ex)
                    {
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
