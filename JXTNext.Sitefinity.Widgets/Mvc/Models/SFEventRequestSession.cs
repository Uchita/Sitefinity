using JXTNext.Sitefinity.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class SFEventRequestSession : IRequestSession
    {
        public string Domain => HttpContext.Current.Request.Url.Host;
        public string UserEmail { get; set; }

    }
}
