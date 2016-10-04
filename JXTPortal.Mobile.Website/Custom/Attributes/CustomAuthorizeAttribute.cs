using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;

namespace JXTPortal.Mobile.Website.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            return (SessionData.Member != null && SessionData.Member.MemberId > 0);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result == null)
            {
                return;
            }
            else if (filterContext.Result.GetType() == typeof(HttpUnauthorizedResult)
                && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ContentResult();
                filterContext.HttpContext.Response.StatusCode = 403;
            }
        }
    }
}