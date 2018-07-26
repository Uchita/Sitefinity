using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Common.API.Models;
using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JXTNext.Sitefinity.Connector.Options
{
    public class JXTNextOptionsConnector : ConnectorBase, IOptionsConnector
    {
        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.JXTNext;

        public JXTNextOptionsConnector(IRequestSession session) : base(session)
        {}

        public TRes JobFilters<TReq, TRes>(TReq request) where TReq : class, IGetJobFiltersRequest where TRes : class, IGetJobFiltersResponse
        {
            JXTNext_GetJobFiltersRequest optionsRequest = request as JXTNext_GetJobFiltersRequest;

            ConnectorGetRequest connectorRequest = new ConnectorGetRequest(HTTP_Requests_MaxWaitTime)
            {
                HeaderValues = HTTP_Request_HeaderValues,
                TargetUri = new Uri(CONFIG_DataAccessTarget + $"/api/options/JobFilters")
            };
            ConnectorResponse response = JXTNext.Common.API.Connector.Get(connectorRequest);

            //parse the response
            bool actionSuccessful = response.Success;
            if (actionSuccessful)
            {
                dynamic responseObj = JObject.Parse(response.Response);

                return new JXTNext_GetJobFiltersResponse { Success = true, Filters = ConvertToData(responseObj) } as TRes;
            }
            else
                return new JXTNext_GetJobFiltersResponse { Success = false, Messages = new List<string> { response.Response } } as TRes;
        }

        private JobFiltersData ConvertToData(dynamic responseData)
        {
            return JsonConvert.DeserializeObject<JobFiltersData>(responseData.ToString());
        }

    }
}
