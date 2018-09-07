using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberAppliedJob;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberSavedJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Logics
{
    public class MemberAppliedJobBC
    {
        IBusinessLogicsConnector _BLConnector;
        public MemberAppliedJobBC(IEnumerable<IBusinessLogicsConnector> _bConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        public bool GetList(out List<MemberAppliedJobItem> displayItems)
        {
            JXTNext_MemberAppliedJobResponse savedJobsResponse = _BLConnector.MemberAppliedJobsGet() as JXTNext_MemberAppliedJobResponse;

            if (!savedJobsResponse.Success)
            {
                displayItems = null;
                return false;
            }

            displayItems = ConvertToDisplayItem(savedJobsResponse.MemberAppliedJobs);
            return true;
        }

        private List<MemberAppliedJobItem> ConvertToDisplayItem(List<MemberAppliedJob> items)
        {
            if (items == null)
                return null;
            return items.Select(c => new MemberAppliedJobItem
            {
                Id = c.Id,
                DisplayTitle = c.JobName,
                JobId = c.JobId,
                DateAdded = ConversionHelper.GetDateTimeFromUnix(c.DateCreated)
            }).ToList();
        }

    }
}
