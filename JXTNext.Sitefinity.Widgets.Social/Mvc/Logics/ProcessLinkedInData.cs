using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using JXTNext.SocialMedia.Models.LinkedIn;
using JXTNext.SocialMedia.Services.LinkedIn;
using System;
using System.Collections.Generic;
using System.IO;
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
        public SocialMediaProcessedResponse ProcessData(string data, string state, string linkedInJson)
        {
            SocialMediaProcessedResponse processedResponse = null;

            if (!linkedInJson.IsNullOrEmpty())
            {
                processedResponse = new SocialMediaProcessedResponse();

                try
                {                   
                    var linkedInRequest = new LinkedInSocialMediaRequest();
                    linkedInRequest.LinkedInApplicationJson = linkedInJson;

                    var linkedInSocialMediaService = new LinkedInSocialMediaService();

                    var linkedInSocialMediaResponse = linkedInSocialMediaService.ProcessSocialMediaIntegration<LinkedInSocialMediaResponse, LinkedInSocialMediaRequest>(linkedInRequest);

                    if (linkedInSocialMediaResponse.SocialMediaProcessSuccess)
                    {
                        processedResponse.Success = true;
                        processedResponse.Email = linkedInSocialMediaResponse.LinkedInJobApplication.emailAddress;
                        processedResponse.FirstName = linkedInSocialMediaResponse.LinkedInJobApplication.firstName;
                        processedResponse.LastName = linkedInSocialMediaResponse.LinkedInJobApplication.lastName;
                        processedResponse.PhoneNumber = linkedInSocialMediaResponse.LinkedInJobApplication.phoneNumber;

                        processedResponse.FileStream = GenerateWordResumeStream(linkedInSocialMediaResponse.HTMLResumeFile);
                        processedResponse.FileName = processedResponse.FirstName.ToLower() + "-" + processedResponse.LastName.ToLower() + "-" + DateTime.Now.ToFileTime() + ".docx";
                    }
                    else
                    {
                        processedResponse.Success = false;
                        processedResponse.Errors = linkedInSocialMediaResponse.Errors;
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

        /// <summary>
        /// This Method Generates Word File Stream using the HTML resume
        /// </summary>
        /// <param name="htmlResume">Generated HTML Resume using the LinkedIn JobApplication</param>
        /// <returns>Applicant Resume as a MemoryStream</returns>
        private MemoryStream GenerateWordResumeStream(string htmlResume)
        {
            MemoryStream linkedInResumeResponse = null;

            if (!string.IsNullOrWhiteSpace(htmlResume))
            {
                linkedInResumeResponse = new MemoryStream();

                using (MemoryStream generatedDocument = new MemoryStream())
                {
                    using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = package.MainDocumentPart;

                        if (mainPart == null)
                        {
                            mainPart = package.AddMainDocumentPart();
                            new Document(new Body()).Save(mainPart);
                        }

                        HtmlConverter converter = new HtmlConverter(mainPart);
                        Body body = mainPart.Document.Body;

                        var paragraphs = converter.Parse(htmlResume);

                        for (int i = 0; i < paragraphs.Count; i++)
                        {
                            body.Append(paragraphs[i]);
                        }

                        mainPart.Document.Save();
                    }

                    generatedDocument.Position = 0;
                    generatedDocument.CopyTo(linkedInResumeResponse);
                    linkedInResumeResponse.Position = 0;
                }
            }

            return linkedInResumeResponse;
        }
    }
}
