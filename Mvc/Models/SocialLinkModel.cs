using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class SocialLinkModel
    {
        public bool IsSelected { get; set; }
        public string DisplayName { get; set; }
        public string UrlPath { get; set; }
        public string EMCssClass { get; set; }
    }
}