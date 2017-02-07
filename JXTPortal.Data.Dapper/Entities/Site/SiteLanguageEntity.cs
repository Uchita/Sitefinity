using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.Site
{
    public class SiteLanguageEntity : BaseEntity
    {
        public int SiteLanguageID { get; set; }
        public int SiteID { get; set; }
        public int LanguageID { get; set; }
        public string SiteLanguageName { get; set; }
        public string ResourceFileName { get; set; }

    }
}
