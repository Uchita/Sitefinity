﻿using JXTNext.Sitefinity.Common.Helpers;
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
    public class ProcessIndeedData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessIndeedData()
        {

        }

        // Interface method
        public SocialMediaProcessedResponse ProcessData(string data, string state, string indeedData)
        {
            Log.Write("ProcessData Indeed In : " + data, ConfigurationPolicy.ErrorLog);
            SocialMediaProcessedResponse processedResponse = null;
            if (data.IsNullOrEmpty() && !indeedData.IsNullOrEmpty())
            {
                Log.Write("ProcessData Indeed Intial Condtion pass : ", ConfigurationPolicy.ErrorLog);
                Log.Write("ProcessData Indeed, indeedData : " + indeedData, ConfigurationPolicy.ErrorLog);
                processedResponse = new SocialMediaProcessedResponse();
                try
                {
                    Log.Write("ProcessData Indeed entered try block : ", ConfigurationPolicy.ErrorLog);

                    IndeedSocialMediaRequest indeedReq = new IndeedSocialMediaRequest();
                    indeedReq.IndeedApplicationJson = indeedData;

                    IndeedSocialMediaService indeedSocialMediaService = new IndeedSocialMediaService();
                    // Indeed API call
                    var indeedAPIResponse = indeedSocialMediaService.ProcessSocialMediaIntegration<IndeedSocialMediaResponse, IndeedSocialMediaRequest>(indeedReq);

                    if (indeedAPIResponse.SocialMediaProcessSuccess)
                    {
                        Log.Write("ProcessData Indeed indeedAPIResponse.SocialMediaProcessSuccess : ", ConfigurationPolicy.ErrorLog);
                        processedResponse.Success = true;
                        processedResponse.Email = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.Email;
                        processedResponse.FirstName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.FirstName;
                        processedResponse.LastName = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.LastName;
                        processedResponse.PhoneNumber = indeedAPIResponse.IndeedJobApplication.IndeedApplicant.PhoneNumber;
                        processedResponse.FileStream = indeedAPIResponse.IndeedJobApplication.IndeedResume.data;
                        processedResponse.FileName = indeedAPIResponse.IndeedJobApplication.IndeedResume.fileName;
                        if (string.IsNullOrEmpty(indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobCompany))
                        {
                            string email = indeedAPIResponse.IndeedJobApplication.JXTNextJob.jobCompany.Split(new char[] { ','}).Last();
                            Log.Write("ProcessData Indeed email: " + email, ConfigurationPolicy.ErrorLog);

                            if (!string.IsNullOrEmpty(email))
                            {
                                email = email.Trim(' ');
                                Log.Write("ProcessData Indeed this.isValidEmail(email): " + this.isValidEmail(email), ConfigurationPolicy.ErrorLog);
                                Log.Write("ProcessData Indeed email: " + email, ConfigurationPolicy.ErrorLog);
                                processedResponse.LoginUserEmail = this.isValidEmail(email) ? email : null;
                                processedResponse.LoginUserEmail = email;
                            }
                        }
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
