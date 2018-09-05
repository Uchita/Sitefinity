using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public interface IMemberCreateJobAlertRequest : IBaseRequest
    {
        int MemberId { get; set; }
        string Name { get; set; }
        int? Status { get; set; }
        long DateCreated { get; set; }
        string Data { get; set; }
    }

    public interface IMemberCreateJobAlertResponse : IBaseResponse
    {
        int? MemberJobAlertId { get; set; }
    }

    public interface IMemberJobAlertsResponse : IBaseResponse
    {
        dynamic MemberJobAlerts { get; set; }
    }

}
