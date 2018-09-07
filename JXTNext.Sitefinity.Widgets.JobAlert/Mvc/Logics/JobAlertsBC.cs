using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Logics
{
    public class JobAlertsBC
    {
        private IBusinessLogicsConnector _BLconnector; 

        public JobAlertsBC(IEnumerable<IBusinessLogicsConnector> businessLogicsConnectors)
        {
            _BLconnector = businessLogicsConnectors.Where(c => c.ConnectorType == Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        public List<JobAlertViewModel> MemberJobAlertsGet()
        {
            IMemberJobAlertsResponse jobAlertResponse = _BLconnector.MemberJobAlertsGet();

            if( jobAlertResponse.Success )
            {
                List<JobAlertViewModel> alerts = new List<JobAlertViewModel>();
                foreach(dynamic item in jobAlertResponse.MemberJobAlerts)
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
            if ( allJobAlerts != null)
                return allJobAlerts.Where(c=>c.Id == jobAlertId).FirstOrDefault();

            return null;
        }

        public bool MemberJobAlertCreate(JobAlertViewModel jobAlertData)
        {

            IMemberCreateJobAlertRequest request = new JXTNext_MemberCreateJobAlertRequest
            {
                Name = jobAlertData.Name,
                DateCreated = jobAlertData.LastModifiedTime,
                Data = ConvertToSerializeData(jobAlertData),
                Status = 1
            };
            IMemberCreateJobAlertResponse response = _BLconnector.MemberCreateJobAlert(request);

            return response.Success;
        }

        public bool MemberJobAlertDelete(int jobAlertId)
        {
            IBaseResponse deleteResponse = _BLconnector.MemberJobAlertDelete(jobAlertId);

            return deleteResponse.Success;
        }

        private JobAlertViewModel ConvertJobAlertData(dynamic data)
        {
            string Data = data.Value<string>("Data");
            if(Data != null)
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
