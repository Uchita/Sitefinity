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
                    alerts.Add(new JobAlertViewModel
                    {
                        Id = jItem.Value<string>("Id"),
                        Name = jItem.Value<string>("Name"),
                        EmailAlerts = true,
                        Filters = jItem.Value<string>("Data") == null ? new List<JobAlertFilters>() : JsonConvert.DeserializeObject<List<JobAlertFilters>>(jItem.Value<string>("Data")),
                        //LastModifiedTime
                    });
                }
                return alerts;
            }

            return null;
        }

        private List<JobAlertViewModel> ConvertJobAlertData(dynamic data)
        {
            return new List<JobAlertViewModel>
            {

            };
        }

    }
}
