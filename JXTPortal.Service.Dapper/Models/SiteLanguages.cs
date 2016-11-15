using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities;

namespace JXTPortal.Service.Dapper.Models
{
    public class SiteLanguages
    {
        public int SiteID { get; set; }
        public List<SiteLanguageDetails> Languages { get; set; }
    }

    public class SiteLanguageDetails
    {
        public int SiteLanguageID { get; set; }
        public int LanguageID { get; set; }
        public PortalEnums.Languages.Language SiteLanguage { get { return (PortalEnums.Languages.Language)LanguageID; } }
        public PortalEnums.Languages.URLLanguage SiteLanguageURL { get { return (PortalEnums.Languages.URLLanguage)SiteLanguage; } }
        public string SiteLanguageName { get; set; }
        public string ResourceFileName { get; set; }
    }
}
