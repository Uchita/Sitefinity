using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class ScreeningQuestionsTemplatesEntity : BaseEntity
    {
        public int ScreeningQuestionsTemplateId { get; set; }
        public string TemplateName { get; set; }
        public int SiteId { get; set; }
        public bool Visible { get; set; }
        public int? CreatedByAdvertiserId { get; set; }
    }
}
