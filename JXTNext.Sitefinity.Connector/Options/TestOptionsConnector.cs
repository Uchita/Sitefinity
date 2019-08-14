using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;

namespace JXTNext.Sitefinity.Connector.Options
{
    public class TestOptionsConnector : IOptionsConnector
    {
        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.Test;

        public TRes JobFilters<TReq, TRes>(TReq request) where TReq : class,IGetJobFiltersRequest where TRes : class, IGetJobFiltersResponse
        {
            #region json raw
            string rawJson = "{\"Data\":[{\"ID\":\"AE-1234\",\"Name\":\"Locations\",\"Type\":\"Multi-Level\",\"Filters\":[{\"ID\":\"DD-3123\",\"Label\":\"Australia\",\"Filters\":[{\"ID\":\"EG-12553223\",\"Label\":\"Sydney\",\"Filters\":[{\"ID\":\"FG-13223\",\"Label\":\"Town Hall\",\"Filters\":null},{\"ID\":\"KD-13723\",\"Label\":\"St. James\",\"Filters\":null},{\"ID\":\"F4-98723\",\"Label\":\"Central\",\"Filters\":null}]},{\"ID\":\"EG-1573223\",\"Label\":\"Melbourne\",\"Filters\":[{\"ID\":\"FG-1393\",\"Label\":\"George St\",\"Filters\":null},{\"ID\":\"BX-1373\",\"Label\":\"Pitt St\",\"Filters\":null},{\"ID\":\"LG-9a233\",\"Label\":\"Central\",\"Filters\":null}]}]},{\"ID\":\"HD-345\",\"Label\":\"New Zealand\",\"Filters\":[{\"ID\":\"AF-0f34\",\"Label\":\"Auckland\",\"Filters\":null},{\"ID\":\"EH-sf355\",\"Label\":\"Christchurch\",\"Filters\":null}]}]},{\"ID\":\"AE-8654\",\"Name\":\"Job Categories\",\"Type\":\"Multi-Level\",\"Filters\":[{\"ID\":\"KJ-3755\",\"Label\":\"Accounting\",\"Filters\":[{\"ID\":\"EG-1223\",\"Label\":\"Accountant - Cost\",\"Filters\":null},{\"ID\":\"AB-gg3223\",\"Label\":\"Accountant - Financial\",\"Filters\":null},{\"ID\":\"EH-123523\",\"Label\":\"Accountant - Tax\",\"Filters\":null},{\"ID\":\"LK-7995\",\"Label\":\"Accountant - Insolvency\",\"Filters\":null},{\"ID\":\"YF-235\",\"Label\":\"Accountant - Other\",\"Filters\":null}]},{\"ID\":\"GF-3783\",\"Label\":\"Sales\",\"Filters\":[{\"ID\":\"EG-6890\",\"Label\":\"Analyst\",\"Filters\":null},{\"ID\":\"EG-4gj5\",\"Label\":\"Telesales\",\"Filters\":null},{\"ID\":\"EG-235\",\"Label\":\"Sales Manager\",\"Filters\":null},{\"ID\":\"EG-gg345\",\"Label\":\"Casual\",\"Filters\":null},{\"ID\":\"EG-578\",\"Label\":\"Accounts\",\"Filters\":null}]}]}]}";
            #endregion

            JobFiltersData filtersData = JsonConvert.DeserializeObject<JobFiltersData>(rawJson);

            Test_GetJobFiltersResponse filtersResponse = new Test_GetJobFiltersResponse
            {
                Filters = filtersData
            };

            return filtersResponse as TRes;
        }
    }
}
