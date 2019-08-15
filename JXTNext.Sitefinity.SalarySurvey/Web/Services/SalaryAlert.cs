using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Web.Services.Interfaces;
using JXTNext.Sitefinity.SalarySurvey.Web.Services.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Multisite;

namespace JXTNext.Sitefinity.SalarySurvey.Web.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SalaryAlert : ISalaryAlert
    {
        protected SettingsHelper settings;

        public SalaryAlert()
        {
            settings = new SettingsHelper();
        }

        public SalaryAlertMetaDataResponseModel MetaData()
        {
            var response = new SalaryAlertMetaDataResponseModel();

            if (!_IsClientIpAllowed())
            {
                HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;

                response.Status = HttpContext.Current.Response.StatusCode;
                response.Message = "Client IP '" + GenericHelper.GetClientIpAddress() + "' does not match with the set task server IP.";

                return response;
            }

            response.SiteName = new MultisiteContext().CurrentSite.Name;
            response.Status = (int)System.Net.HttpStatusCode.OK;
            response.SalaryAlertCount = settings.SalaryAlertCount;
            response.SalaryItemTemplate = settings.SalaryAlertSalaryItemTemplate;
            response.EmailFromAddress = settings.SalaryAlertEmailFromAddress;
            response.EmailFromName = settings.SalaryAlertEmailFromName;

            _SetEmailSubjectAndTemplate(response);

            response.Taxonomies = new Dictionary<string, string>();
            _PopulateCountries(response.Taxonomies);
            _PopulateIndustries(response.Taxonomies);
            _PopulateJobTypes(response.Taxonomies);

            return response;
        }

        private void _SetEmailSubjectAndTemplate(SalaryAlertMetaDataResponseModel response)
        {
            if (settings.SalaryAlertEmailTemplateId == null)
            {
                return;
            }

            var emailTemplate = GenericHelper.GetEmailTemplate(settings.SalaryAlertEmailTemplateId);
            if (emailTemplate == null)
            {
                return;
            }

            response.EmailSubject = emailTemplate.GetValue("Title").ToString();
            response.EmailTemplate = emailTemplate.GetValue("htmlEmailContent").ToString();
        }

        private void _PopulateCountries(Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(settings.CountryTaxonomyId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);

                _PopulateLocations(Guid.Parse(item.Value), list);
            }
        }

        private void _PopulateLocations(Guid locationId, Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(locationId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);
            }
        }

        private void _PopulateIndustries(Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(settings.IndustryTaxonomyId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);

                _PopulateClassifications(Guid.Parse(item.Value), list);
            }
        }

        private void _PopulateClassifications(Guid locationId, Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(locationId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);

                _PopulateSubClassifications(Guid.Parse(item.Value), list);
            }
        }

        private void _PopulateSubClassifications(Guid classificationId, Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(classificationId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);
            }
        }

        private void _PopulateJobTypes(Dictionary<string, string> list)
        {
            var items = GenericHelper.GetCategoryItems(settings.JobTypeTaxonomyId);

            foreach (var item in items)
            {
                list.Add(item.Value, item.Text);
            }
        }

        private bool _IsClientIpAllowed()
        {
            var clientIp = GenericHelper.GetClientIpAddress();

            var serverIp = settings.SalaryAlertTaskServerIp;

            return clientIp.Equals(serverIp);
        }
    }
}
