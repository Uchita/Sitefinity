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
                coverletterPath = jxtAppDetails.CoverletterPath
            };

            return apiObj;
        }

    }
}
