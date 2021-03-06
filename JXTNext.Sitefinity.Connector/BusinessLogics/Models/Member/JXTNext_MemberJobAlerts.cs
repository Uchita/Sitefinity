﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberUpsertJobAlertRequest : ConnectorBaseRequest, IMemberUpsertJobAlertRequest
    {
        public int? MemberJobAlertId { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public long DateCreated { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }
        public EmailNotificationSettings EmailNotification { get; set; }
    }

    public class JXTNext_MemberUpsertJobAlertResponse : ConnectorBaseResponse, IMemberUpsertJobAlertResponse
    {
        public int? MemberJobAlertId { get; set; }
    }

    public class JXTNext_MemberJobAlertsResponse : ConnectorBaseResponse, IMemberJobAlertsResponse
    {
        public dynamic MemberJobAlerts { get; set; }
    }

    public class JXTNext_MemberJobAlertDeleteResponse : ConnectorBaseResponse, IBaseResponse
    {
    }

    public class JXTNext_MemberJobAlertUnsubscribeResponse : ConnectorBaseResponse, IBaseResponse
    {
    }

    public class JXTNext_MemberJobAlerts
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public long DateCreated { get; set; }
        public long? DateLastRun { get; set; }
        public string Data { get; set; }
    }


}
