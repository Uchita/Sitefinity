using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    [Serializable]
    public class SessionMember
    {
        public int MemberId { get; set; }

        public string EmailAddress { get; set; }

        public int EmailFormat { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Username { get; set; }

        public string LinkedInAccessToken { get; set; }

        public DateTime? LastTermsAndConditionsDate { get; set; }

        public int? ReferringSiteID { get; set; }
    }
}
