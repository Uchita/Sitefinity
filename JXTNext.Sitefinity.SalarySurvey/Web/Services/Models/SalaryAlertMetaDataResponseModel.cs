using JXTNext.Sitefinity.SalarySurvey.Web.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace JXTNext.Sitefinity.SalarySurvey.Web.Services.Models
{
    public class SalaryAlertMetaDataResponseModel : GenericResponseModel
    {
        public string SiteName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailTemplate { get; set; }
        public string EmailFromName { get; set; }
        public string EmailFromAddress { get; set; }
        public int SalaryAlertCount { get; set; }
        public string SalaryItemTemplate { get; set; }
        public Dictionary<string, string> Taxonomies { get; set; }
    }
}
