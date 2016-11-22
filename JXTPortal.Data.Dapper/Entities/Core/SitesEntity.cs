using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class SitesEntity : BaseEntity
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public string SiteDescription { get; set; }
        public byte[] SiteAdminLogo { get; set; }
        public bool? Live { get; set; }
        public bool MobileEnabled { get; set; }
        public string MobileUrl { get; set; }
        public string SiteAdminLogoUrl { get; set; }
    }
}
