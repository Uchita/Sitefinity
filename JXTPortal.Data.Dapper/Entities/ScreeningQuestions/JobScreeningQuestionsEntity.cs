using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class JobScreeningQuestionsEntity : BaseEntity
    {
        public int JobScreeningQuestionId {get; set;}
        public int? JobId {get; set;}
        public int? JobArchiveId {get; set;}
        public int ScreeningQuestionId {get; set;}

    }
}
