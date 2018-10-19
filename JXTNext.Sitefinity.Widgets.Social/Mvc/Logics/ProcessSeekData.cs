using JXTNext.Sitefinity.Common.Helpers;
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
        public SocialMediaProcessedResponse ProcessData(string code, string state, Stream stream)
        {
            SocialMediaProcessedResponse processedResponse = null;

            if (!code.IsNullOrEmpty())
            {
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

                    // Seek API call
                    var seekAPIResponse = seekSocialMediaService.ProcessSocialMediaIntegration<SeekSocialMediaResponse, SeekSocialMediaRequest>(req);

                    #region Downloading the resume 
                    // Downloading the resume from seek 
                    if (seekAPIResponse.SocialMediaProcessSuccess)
                    {
                        processedResponse.Success = true;
                        processedResponse.Email = seekAPIResponse.SeekApplication.applicantInfo.emailAddress;
                        processedResponse.FirstName = seekAPIResponse.SeekApplication.applicantInfo.firstName;
                        processedResponse.LastName  = seekAPIResponse.SeekApplication.applicantInfo.lastName;
                        processedResponse.PhoneNumber = seekAPIResponse.SeekApplication.applicantInfo.phoneNumber;

                        if (Int32.TryParse(state, out int jobId))
                            processedResponse.JobId = jobId;

                        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(seekAPIResponse.SeekApplication.resume.link);
                        webReq.ContentType = "application/json";
                        webReq.Accept = "application/octet-stream";
                        webReq.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + seekAPIResponse.SeekApplication.OAuthToken);

                        WebResponse webResponse = webReq.GetResponse();

                        string[] splits = webResponse.Headers["Content-Disposition"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        string resumeFileNameSplit = splits.Where(c => c.Contains("filename=")).FirstOrDefault();
                        string resumeFileName = resumeFileNameSplit.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).Last();
                        string responseMessage = null;

                        using (StreamReader resStreamReader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            responseMessage = resStreamReader.ReadToEnd();
                        }
                                            
                        MemoryStream fileStream = null;

                        if (!string.IsNullOrWhiteSpace(responseMessage))
                        {
                            var fileBytes = Encoding.UTF8.GetBytes(responseMessage);
                            fileStream = new MemoryStream(fileBytes);
                        }

                        processedResponse.FileStream = fileStream;
                        processedResponse.FileName = resumeFileName;
                    }
                    else
                    {
                        processedResponse.Success = false;
                        processedResponse.Errors = seekAPIResponse.Errors;
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
    }
}
