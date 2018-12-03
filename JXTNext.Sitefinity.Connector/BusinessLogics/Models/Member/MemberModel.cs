using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class MemberModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        //public int Type { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string LogoUrl { get; set; }
        public double DateCreated { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public string Data { get; set; }
        public string ResumeFiles { get; set; }
    }
}
