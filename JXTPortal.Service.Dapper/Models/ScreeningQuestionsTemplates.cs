using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities;

namespace JXTPortal.Service.Dapper.Models
{
    public class ScreeningQuestionsTemplateDetail
    {
        public int SiteId { get; set; }
        public int TotalCount { get; set; }
        public List<ScreeningQuestionsTemplate> ScreeningQuestionsTemplates { get; set; }
    }

    public class ScreeningQuestionsTemplate
    {
        public int ScreeningQuestionsTemplateId { get; set; }
        public string TemplateName { get; set; }
        public int SiteId { get; set; }
        public bool Visible { get; set; }
        public DateTime LastModified { get; set; }
        public int LastModifiedBy { get; set; }
        public string LastModifiedByName { get; set; }
    }
}
