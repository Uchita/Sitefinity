using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class ScreeningQuestionsEntity : BaseEntity
    {
        public int ScreeningQuestionId { get; set; }
        public int ScreeningQuestionIndex { get; set; }
        public string QuestionTitle { get; set; }
        public int LanguageId { get; set; }
        public string KnockoutValue { get; set; }
        public string Options { get; set; }
        public int? LastModifiedByAdvertiserUserId { get; set; }
    }
}
