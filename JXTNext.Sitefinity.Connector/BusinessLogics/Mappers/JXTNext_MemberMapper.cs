using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Mappers
{
    public class JXTNext_MemberMapper : IMemberMapper
    {
        public IntegrationMapperType mapperType => IntegrationMapperType.JXTNext;

        public dynamic Register_ConvertToAPIEntity<T>(T registerDetails)
        {
            JXTNext_MemberRegister jxtRegDetails = registerDetails as JXTNext_MemberRegister;

            //do the assignment from the local register model to API
            dynamic apiObj = new
            {
                firstName = jxtRegDetails.FirstName,
                lastName = jxtRegDetails.LastName,
                email = jxtRegDetails.Email,
                password = jxtRegDetails.Password
            };

            return apiObj;
        }

        public dynamic Application_ConvertToAPIEntity<T>(T applyDetails)
        {
            JXTNext_MemberApplicationRequest jxtAppDetails = applyDetails as JXTNext_MemberApplicationRequest;

            //do the assignment from the local register model to API
            dynamic apiObj = new
            {
                jobId = jxtAppDetails.ApplyResourceID,
                resumePath = jxtAppDetails.ResumePath,
                coverletterPath = jxtAppDetails.CoverletterPath,
                emailNotification = jxtAppDetails.EmailNotification,
                documentsPath = jxtAppDetails.DocumentsPath
            };

            return apiObj;
        }

        public List<T> MemberSavedJob_ConvertToLocalEntity<T>(dynamic data) where T : class
        {
            List<MemberSavedJob> savedJobs = new List<MemberSavedJob>();
            foreach (var d in data)
            {
                MemberSavedJob local = new MemberSavedJob
                {
                    //{\"Id\":1,\"SiteId\":10,\"MemberId\":3,\"JobId\":17584,\"_JobTitle\":\"Redundant\",\"DateAdded\":153245}
                    SavedJobId = d["Id"],
                    //= d["MemberId"],
                    JobId = d["JobId"],
                    Title = d["_JobTitle"],
                    DateAdded = d["DateAdded"]
                };

                savedJobs.Add(local);
            }
            return savedJobs as List<T>;
        }

        public List<T> MemberAppliedJob_ConvertToLocalEntity<T>(dynamic data) where T : class
        {
            List<MemberAppliedJob> appliedJobs = new List<MemberAppliedJob>();
            foreach (var d in data)
            {
                MemberAppliedJob local = new MemberAppliedJob
                {
                    //{\"Id\":1,\"SiteId\":10,\"MemberId\":3,\"JobId\":17584,\"_JobTitle\":\"Redundant\",\"DateAdded\":153245}
                    Id = d["Id"],
                    //= d["MemberId"],
                    JobId = d["JobId"],
                    JobName = d["JobName"],
                    DateCreated = d["DateCreated"]
                };

                appliedJobs.Add(local);
            }
            return appliedJobs as List<T>;
        }

        public T Member_ConvertToLocalEntity<T>(dynamic data) where T : class
        {
            MemberModel local = new MemberModel();
            local.Id = data["id"];
            local.SiteId = data["siteId"];
            //Type = data["Type"],
            local.FirstName = data["firstName"];
            local.Surname = data["surname"];
            local.Email = data["email"];
            local.DateCreated = data["dateCreated"];
            local.Status = data["status"];
            local.UserId = data["userId"];
            local.Data = data["data"];
            local.ResumeFiles = data["resumeFiles"];

            return local as T;
        }

        public dynamic Member_ConvertToAPIEntity(MemberModel local)
        {
            
            dynamic apiObj = new
            {
                id = local.Id,
                siteId = local.SiteId,
                //Type = data["Type"],
                firstName  = local.FirstName,
                surname = local.Surname,
                email = local.Email,
                dateCreated = local.DateCreated,
            status = local.Status,
            userId = local.UserId,
            data = local.Data,
                resumeFiles = local.ResumeFiles
        };

            return apiObj;
        }

    }
}
