﻿using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using JXTNext.SocialMedia.Models.Seek;
using JXTNext.SocialMedia.Services.Seek;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
//using JXTNext.SocialMedia.Models.Seek;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class ProcessSeekData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessSeekData()
        {

        }

        // Interface method
        public SocialMediaProcessedResponse ProcessData(string code, string state, string indeedData)
        {
            Log.Write("ProcessData Seek ProcessData : ", ConfigurationPolicy.ErrorLog);
            SocialMediaProcessedResponse processedResponse = null;

            if (!code.IsNullOrEmpty())
            {
                Log.Write("ProcessData Seek Condtion check true : ", ConfigurationPolicy.ErrorLog);
                processedResponse = new SocialMediaProcessedResponse();
                try
                {
                    var siteSettingsHelper = new SiteSettingsHelper();

                    // Fetaching Seek information from site settings
                    var clientId = siteSettingsHelper.GetCurrentSiteSeekClientId();
                    var clientSecret = siteSettingsHelper.GetCurrentSiteSeekClientSecret();
                    var advertiserId = siteSettingsHelper.GetCurrentSiteSeekClientAdvertiserId();
                    var redirectUri = siteSettingsHelper.GetCurrentSiteSeekRedirectUri();

                    // Fill the seek request for the API call
                    SeekSocialMediaRequest req = new SeekSocialMediaRequest();
                    req.AuthorisationCode = code;
                    req.ClientId = clientId;
                    req.ClientSecret = clientSecret;
                    req.AdvertiserId = advertiserId;
                    req.RedirectUri = redirectUri;
                    req.JobTitle = "developer";
                    req.CountryCode = "61";
                    req.JobUrl = "http://localhost:60876/jobs";
                    req.PositionUrl = "dfdf";
                    req.PostalCode = "2145";

                    SeekSocialMediaService seekSocialMediaService = new SeekSocialMediaService();
                    if (Int32.TryParse(state, out int jobId))
                        processedResponse.JobId = jobId;
                    // Seek API call
                    var seekAPIResponse = seekSocialMediaService.ProcessSocialMediaIntegration<SeekSocialMediaResponse, SeekSocialMediaRequest>(req);

                    #region Downloading the resume 
                    // Downloading the resume from seek 
                    if (seekAPIResponse.SocialMediaProcessSuccess && seekAPIResponse.SeekApplication.resume != null)
                    {
                        processedResponse.Success = true;
                        processedResponse.Email = seekAPIResponse.SeekApplication.applicantInfo.emailAddress;
                        processedResponse.FirstName = seekAPIResponse.SeekApplication.applicantInfo.firstName;
                        processedResponse.LastName  = seekAPIResponse.SeekApplication.applicantInfo.lastName;
                        processedResponse.PhoneNumber = seekAPIResponse.SeekApplication.applicantInfo.phoneNumber;

                        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(seekAPIResponse.SeekApplication.resume.link);
                        webReq.ContentType = "application/json";
                        webReq.Accept = "application/octet-stream";
                        webReq.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + seekAPIResponse.SeekApplication.OAuthToken);

                        WebResponse webResponse = webReq.GetResponse();

                        string[] splits = webResponse.Headers["Content-Disposition"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        string resumeFileNameSplit = splits.Where(c => c.Contains("filename=")).FirstOrDefault();
                        string resumeFileName = resumeFileNameSplit.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).Last();
                        
                        MemoryStream fileStream = new MemoryStream();

                        byte[] fileBytes = GetStreamBytes(webResponse);
                        fileStream = new MemoryStream(fileBytes);
                        processedResponse.FileStream = fileStream;
                        processedResponse.FileName = resumeFileName;
                    }
                    else
                    {
                        if(!seekAPIResponse.SocialMediaProcessSuccess)
                        {
                            processedResponse.Success = false;
                            processedResponse.Errors = seekAPIResponse.Errors;
                        }
                        else
                        {
                            processedResponse.Success = false;
                            processedResponse.ResumeLinkNotExists = true;
                            processedResponse.Errors = new List<string>() { "Seek Resume Link is NULL" };
                        }
                    }
                }
                #endregion

                catch (Exception ex)
                {
                    processedResponse.Success = false;
                    List<string> errors = new List<string>();
                    errors.Add(ex.Message);
                    processedResponse.Errors = errors;
                }
            }

            return processedResponse;
        }


        private byte[] GetStreamBytes(WebResponse webResponse)
        {
            using (var responseStream = webResponse.GetResponseStream())
            {
                using (var stream = new MemoryStream())
                {
                    responseStream.CopyTo(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
