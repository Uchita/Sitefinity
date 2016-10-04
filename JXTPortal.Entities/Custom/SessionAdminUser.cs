using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    [Serializable]
    public class SessionAdminUser
    {
        public int AdminUserId { get; set; }

        public int AdminRoleId { get; set; }

        public string FirstName { get; set; }

        public bool isAdminUser { get; set; }

        public int SiteId { get; set; }

    }
}
