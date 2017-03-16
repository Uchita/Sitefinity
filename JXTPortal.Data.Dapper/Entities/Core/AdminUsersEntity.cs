using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class AdminUsersEntity : BaseEntity
    {
        public int AdminUserID { get; set; }
        public int AdminRoleID { get; set; }
        public int SiteID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int LoginAttempts { get; set; }
        public DateTime? LastAttemptDate { get; set; }
        public int Status { get; set; }
    }
}
