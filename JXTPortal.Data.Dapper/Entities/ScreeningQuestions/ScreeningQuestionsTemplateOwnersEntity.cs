using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class ScreeningQuestionsTemplateOwnersEntity : BaseEntity
    {
        public int ScreeningQuestionsTemplatesOwnerId { get; set; }
        public int ScreeningQuestionsTemplateId { get; set; }
        public int AdvertiserId { get; set; }
    }
}
