using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.ScreeningQuestions
{
    public class JobApplicationScreeningAnswersEntity : BaseEntity
    {
        public int JobApplicationScreeningAnswerId { get; set; }
        public int ScreeningQuestionId { get; set; }
        public string Answer { get; set; }
        public int JobApplicationId { get; set; }

    }
}
