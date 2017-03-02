using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities;

namespace JXTPortal.Service.Dapper.Models
{
    public class JobApplicationScreeningAnswerDetail
    {
        public int JobApplicationId { get; set; }
        public List<JobApplicationScreeningAnswer> JobApplicationScreeningAnswers { get; set; }
    }

    public class JobApplicationScreeningAnswer
    {
        public int ScreeningQuestionId { get; set; }
        public int ScreeningQuestionIndex { get; set; }
        public string QuestionTitle { get; set; }
        public string Answer { get; set; }
    }
}
