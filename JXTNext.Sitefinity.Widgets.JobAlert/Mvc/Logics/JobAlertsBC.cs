namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Logics
{
    using JXTNext.Sitefinity.Connector.BusinessLogics;
    using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
    using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="JobAlertsBC" />
    /// </summary>
    public class JobAlertsBC
    {
        /// <summary>
        /// Defines the _BLconnector
        /// </summary>
        private IBusinessLogicsConnector _BLconnector;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertsBC"/> class.
        /// </summary>
        /// <param name="businessLogicsConnectors">The businessLogicsConnectors<see cref="IEnumerable{IBusinessLogicsConnector}"/></param>
        public JobAlertsBC(IEnumerable<IBusinessLogicsConnector> businessLogicsConnectors)
        {
            _BLconnector = businessLogicsConnectors.Where(c => c.ConnectorType == Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        /// <summary>
        /// The MemberJobAlertsGet
        /// </summary>
        /// <returns>The <see cref="List{JobAlertViewModel}"/></returns>
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

        /// <summary>
        /// The MemberJobAlertGet
        /// </summary>
        /// <param name="jobAlertId">The jobAlertId<see cref="int"/></param>
        /// <returns>The <see cref="JobAlertViewModel"/></returns>
        public JobAlertViewModel MemberJobAlertGet(int jobAlertId)
        {
            List<JobAlertViewModel> allJobAlerts = MemberJobAlertsGet();
            if (allJobAlerts != null)
                return allJobAlerts.Where(c => c.Id == jobAlertId).FirstOrDefault();

            return null;
        }

        /// <summary>
        /// The MemberJobAlertUpsert
        /// </summary>
        /// <param name="jobAlertData">The jobAlertData<see cref="JobAlertViewModel"/></param>
        /// <param name="update">The update<see cref="bool"/></param>
        /// <returns>The <see cref="IMemberUpsertJobAlertResponse"/></returns>
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
                MemberJobAlertId = memberJobAlertId
            };
            IMemberUpsertJobAlertResponse response = _BLconnector.MemberUpsertJobAlert(request);

            return response;
        }

        /// <summary>
        /// The MemberJobAlertDelete
        /// </summary>
        /// <param name="jobAlertId">The jobAlertId<see cref="int"/></param>
        /// <returns>The <see cref="IBaseResponse"/></returns>
        public IBaseResponse MemberJobAlertDelete(int jobAlertId)
        {
            IBaseResponse deleteResponse = _BLconnector.MemberJobAlertDelete(jobAlertId);

            return deleteResponse;
        }

        /// <summary>
        /// The ConvertJobAlertData
        /// </summary>
        /// <param name="data">The data<see cref="dynamic"/></param>
        /// <returns>The <see cref="JobAlertViewModel"/></returns>
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

        /// <summary>
        /// The ConvertToSerializeData
        /// </summary>
        /// <param name="jobAlertData">The jobAlertData<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="string"/></returns>
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
