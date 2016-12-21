using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class ScreeningQuestionsMappingsEntity : BaseEntity
    {
        public int ScreeningQuestionsMappingId { get; set; }
        public int QuestionType { get; set; }
        public bool Mandatory { get; set; }
        public int ScreeningQuestionsTemplateId { get; set; }
        public bool Visible { get; set; }
        public int ScreeningQuestionId { get; set; }
    }
}
