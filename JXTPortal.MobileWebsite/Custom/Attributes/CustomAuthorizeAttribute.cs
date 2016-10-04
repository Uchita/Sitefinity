using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;

namespace JXTPortal.MobileWebsite.Custom.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            return (SessionData.Member != null && SessionData.Member.MemberId > 0);
        }
    }
}