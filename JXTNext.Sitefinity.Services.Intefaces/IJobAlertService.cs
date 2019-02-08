using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlertJson;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Services.Intefaces
{
    public interface IJobAlertService
    {
        List<JobAlertViewModel> MemberJobAlertsGet();
        JobAlertViewModel MemberJobAlertGet(int jobAlertId);
        IMemberUpsertJobAlertResponse MemberJobAlertUpsert(JobAlertViewModel jobAlertData, bool update = false);
        IBaseResponse MemberJobAlertDelete(int jobAlertId);
        SearchModel GetMemeberJobAlert(int jobAlertId);
        IBaseResponse UnsubscribeJobAlert(Guid unsubscribeGuid);
    }
}
