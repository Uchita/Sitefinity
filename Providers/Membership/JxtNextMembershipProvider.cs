using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Security.Model;

namespace SitefinityWebApp.Providers.Membership
{
    public class JxtNextMembershipProvider : Telerik.Sitefinity.Security.Data.MembershipDataProvider
    {
        private int SiteID { get; set; }


        public override User CreateUser(string email)
        {
            throw new NotImplementedException();
        }

        public override User CreateUser(Guid id, string email)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public override User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<User> GetUsers()
        {
            base.GetUsers();

        }
    }
}