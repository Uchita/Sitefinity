using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberSavedJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Logics
{
    public class MemberSavedJobBC
    {
        IBusinessLogicsConnector _BLConnector;
        public MemberSavedJobBC(IEnumerable<IBusinessLogicsConnector> _bConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        public bool GetList(out List<MemberSavedJobDisplayItem> displayItems)
        {
            JXTNext_MemberGetSavedJobResponse savedJobsResponse = _BLConnector.MemberGetSavedJobs() as JXTNext_MemberGetSavedJobResponse;

            if (!savedJobsResponse.Success)
            {
                displayItems = null;
                return false;
            }

            displayItems = ConvertToDisplayItem(savedJobsResponse.SavedJobs);
            return true;
        }

        private List<MemberSavedJobDisplayItem> ConvertToDisplayItem(List<MemberSavedJob> items)
        {
            if (items == null)
                return null;
            return items.Select(c => new MemberSavedJobDisplayItem
            {
                Id = c.SavedJobId,
                DisplayTitle = c.Title,
                JobId = c.JobId,
                DateAdded = ConversionHelper.GetDateTimeFromUnix(c.DateAdded)
            }).ToList();
        }

    }
}
