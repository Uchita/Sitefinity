using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class JobTemplatesEntity : BaseEntity
    {
        public int JobTemplateID { get; set; }
        public int? SiteID { get; set; }
        public string JobTemplateDescription { get; set; }
        public string JobTemplateHTML { get; set; }
        public bool GlobalTemplate { get; set; }
        public byte[] JobTemplateLogo { get; set; }
        public int AdvertiserID { get; set; }
        public string JobTemplateLogoUrl { get; set; }
    }
}
