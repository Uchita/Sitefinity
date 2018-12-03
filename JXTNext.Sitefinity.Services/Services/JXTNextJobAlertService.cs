using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace JXTNext.Sitefinity.Services.Services
{
    public class JXTNextJobAlertService : IJobAlertService
    {
        private IBusinessLogicsConnector _BLconnector;

        public JXTNextJobAlertService(IEnumerable<IBusinessLogicsConnector> businessLogicsConnectors)
        {
            _BLconnector = businessLogicsConnectors.Where(c => c.ConnectorType == Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        public List<JobAlertViewModel> MemberJobAlertsGet()
        {
            IMemberJobAlertsResponse jobAlertResponse = _BLconnector.MemberJobAlertsGet();

            if (jobAlertResponse.Success)
            {
                List<JobAlertViewModel> alerts = new List<JobAlertViewModel>();
                foreach (dynamic item in jobAlertResponse.MemberJobAlerts)
                {
                    JObject jItem = JObject.Parse(item.ToString());
                    alerts.Add(ConvertJobAlertData(jItem));
                }
                return alerts;
            }

            return null;
        }

        public JobAlertViewModel MemberJobAlertGet(int jobAlertId)
        {
            List<JobAlertViewModel> allJobAlerts = MemberJobAlertsGet();
            if (allJobAlerts != null)
                return allJobAlerts.Where(c => c.Id == jobAlertId).FirstOrDefault();

            return null;
        }

        public IMemberUpsertJobAlertResponse MemberJobAlertUpsert(JobAlertViewModel jobAlertData, bool update = false)
        {
            int? memberJobAlertId = null;
            if (update)
                memberJobAlertId = jobAlertData.Id;

            IMemberUpsertJobAlertRequest request = new JXTNext_MemberUpsertJobAlertRequest
            {
                Name = jobAlertData.Name,
                DateCreated = jobAlertData.LastModifiedTime,
                Data = ConvertToSerializeData(jobAlertData),
                Status = 1,
                MemberJobAlertId = memberJobAlertId,
                Email = jobAlertData.Email
            };
            IMemberUpsertJobAlertResponse response = _BLconnector.MemberUpsertJobAlert(request, SitefinityHelper.IsUserLoggedIn());

            return response;
        }

        public IBaseResponse MemberJobAlertDelete(int jobAlertId)
        {
            IBaseResponse deleteResponse = _BLconnector.MemberJobAlertDelete(jobAlertId);

            return deleteResponse;
        }

        private JobAlertViewModel ConvertJobAlertData(dynamic data)
        {
            string Data = data.Value<string>("Data");
            if (Data != null)
            {
                var jobAlertModel = JsonConvert.DeserializeObject<JobAlertViewModel>(Data);
                jobAlertModel.Id = data.Value<int>("Id");
                jobAlertModel.Name = data.Value<string>("Name");

                return jobAlertModel;
            }

            return new JobAlertViewModel
            {
                Id = data.Value<int>("Id"),
                Name = data.Value<string>("Name"),
            };
        }

        private string ConvertToSerializeData(JobAlertViewModel jobAlertData)
        {
            dynamic data = new ExpandoObject();
            if (jobAlertData.Filters != null)
                data.Filters = jobAlertData.Filters;

            if (jobAlertData.Salary != null)
                data.Salary = jobAlertData.Salary;

            if (jobAlertData.Keywords != null)
                data.Keywords = jobAlertData.Keywords;

            data.EmailAlerts = jobAlertData.EmailAlerts;

            return JsonConvert.SerializeObject(data);
        }
    }
}
