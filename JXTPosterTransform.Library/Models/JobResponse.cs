using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPosterTransform.Library.Models
{
    //{"Summary":{"DateCreated":"\/Date(1412192743230+1000)\/","FinishedDate":"\/Date(1412192744377+1000)\/","Inserted":0,"Sent":1,"Updated":1,"Archived":0,"Failed":0},"JobPosting":[{"Action":"UPDATE","ReferenceNo":"JO-1409-69964","URL":"http://miningpeople-2014.com.au/process-plant-laboratory-jobs/process-technician/211068","Title":"Process Technician"}],"ResponseCode":"SUCCESS","ResponseMessage":""}
    public class JobResponse
    {
        public JobResponse()
        {
            JobPosting = new List<JobPosting>();
            Summary = new Summary();
        }

        public IList<JobPosting> JobPosting { get; set; }
        public Summary Summary { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class Summary
    {
        public DateTime DateCreated { get; set; }
        public DateTime FinishedDate { get; set; }
        public int Inserted { get; set; }
        public int Sent { get; set; }
        public int Updated { get; set; }
        public int Archived { get; set; }
        public int Failed { get; set; }
    }

    public class JobPosting
    {
        public string Action { get; set; }
        public string ReferenceNo { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
