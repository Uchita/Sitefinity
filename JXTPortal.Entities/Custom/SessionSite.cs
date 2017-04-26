using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    [Serializable]
    public class SessionSite
    {
        public int SiteId { get; set;}

        public string SiteName { get; set; }

        public string SiteUrl { get; set; }

        public string SiteUrlAlias { get; set; }

        public string SiteDescription { get; set; }

        public int SiteIdAlias { get; set; }

        public bool HasAdminLogo { get; set; }

        public int DefaultEmailLanguageId { get; set; }

        public bool IsLive { get; set; }

        public string MemberRegistrationNotificationEmail { get; set; }

        public bool WWWRedirect { get; set; }

        public bool UseCustomProfessionRole { get; set; }

        public bool IsPrivateSite { get; set; }

        public string PrivateRedirectUrl { get; set; }

        public bool IsJobBoard { get; set; }

        public bool EnableSsl { get; set; }

        public string FileFolderLocation { get; set; }

        public bool IsUsingS3 { get; set; }

        public PortalEnums.Admin.AdvertiserApproval AdvertiserApprovalProcess { get; set; }

        public string AuthToken { get; set; }

        /* Language Related */
        public int DefaultLanguageId { get; set; }
        //public PortalEnums.Languages.Language DefaultLanguage { get { return (PortalEnums.Languages.Language) DefaultLanguageId; } }
        public List<PortalEnums.Languages.URLLanguage> SiteAvailableLanguage { get; set; }

        public int MasterSiteId { get; set; }

        public string DateFormat { get; set; }

        //Mapping of Language -> Custom ResourceFileName
        public Dictionary<PortalEnums.Languages.Language, string> ResourceFileNameMappings { get; private set; }
        public string ResourceFileNameMappingGet(int langID)
        {
            PortalEnums.Languages.Language lang = (PortalEnums.Languages.Language)langID;
            return ResourceFileNameMappings.Keys.Contains(lang) ? ResourceFileNameMappings[lang] : null;
        }

        public SessionSite()
        {
            ResourceFileNameMappings = new Dictionary<PortalEnums.Languages.Language, string>();
        }

    }
}
