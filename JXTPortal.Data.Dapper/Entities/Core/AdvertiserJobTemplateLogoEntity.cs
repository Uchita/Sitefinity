using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class AdvertiserJobTemplateLogoEntity : BaseEntity
    {
        public int AdvertiserJobTemplateLogoID { get; set; }
        public int AdvertiserID { get; set; }
        public string JobLogoName { get; set; }
        public byte[] JobTemplateLogo { get; set; }
        public string JobTemplateLogoURL { get; set; }
    }
}
