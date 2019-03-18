using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using JXTNext.SocialMedia.Models.Indeed;
using JXTNext.SocialMedia.Services.Indeed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class ProcessLinkedInData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessLinkedInData()
        {

        }

        // Interface method
        public SocialMediaProcessedResponse ProcessData(string data, string state, string indeedData)
        {
            SocialMediaProcessedResponse processedResponse = null;

            if (data.IsNullOrEmpty() && !indeedData.IsNullOrEmpty())
            {
                processedResponse = new SocialMediaProcessedResponse();

                try
                {
                    IndeedSocialMediaRequest indeedReq = new IndeedSocialMediaRequest();
                    indeedReq.IndeedApplicationJson = indeedData;

                    IndeedSocialMediaService indeedSocialMediaService = new IndeedSocialMediaService();

                    var indeedAPIResponse = indeedSocialMediaService.ProcessSocialMediaIntegration<IndeedSocialMediaResponse, IndeedSocialMediaRequest>(indeedReq);

                    if (indeedAPIResponse.SocialMediaProcessSuccess)
                    {
                        processedResponse.Success = true;
                        processedResponse.Email = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.Email;
                        processedResponse.FirstName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.FullName?.Split(' ').FirstOrDefault();
                        processedResponse.LastName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.FullName?.Split(' ').LastOrDefault();
                        processedResponse.PhoneNumber = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.PhoneNumber;
                        processedResponse.FileStream = indeedAPIResponse.IndeedJobApplication.IndeedResume.data;
                        processedResponse.FileName = indeedAPIResponse.IndeedJobApplication.IndeedResume.fileName;
                        if (!string.IsNullOrEmpty(indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobMeta))
                        {
                            string[] metaData = indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobMeta.Split(new char[] { ';' });

                            if (metaData.Count() >= 1)
                            {
                                string email = metaData[1];
                                if (!string.IsNullOrEmpty(email))
                                {
                                    email = email.Trim();
                                    processedResponse.LoginUserEmail = this.isValidEmail(email) ? email : null;
                                    processedResponse.LoginUserEmail = email;
                                }
                            }

                            if (metaData.Count() >= 2)
                            {
                                string source = metaData[2];
                                if (!string.IsNullOrEmpty(source))
                                {
                                    source = source.Trim();
                                    processedResponse.JobSource = source;
                                }
                            }

                        }

                        if (Int32.TryParse(indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobId, out int jobId))
                        {
                            processedResponse.JobId = jobId;
                        }
                    }
                    else
                    {
                        processedResponse.Success = false;
                        processedResponse.Errors = indeedAPIResponse.Errors;
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex);

                    processedResponse.Success = false;
                    List<string> errors = new List<string>();
                    errors.Add(ex.Message);
                    processedResponse.Errors = errors;
                }
            }

            return processedResponse;
        }

        private bool isValidEmail(string email)
        {
            try
            {
                MailAddress eamilValue = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
