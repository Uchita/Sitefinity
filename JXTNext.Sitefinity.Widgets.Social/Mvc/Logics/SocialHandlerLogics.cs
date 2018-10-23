using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class SocialHandlerLogics
    {
        IEnumerable<IProcessSocialMediaData> _processSocialMediaData;
        IJobApplicationService _jobApplicationService;
       
        public SocialHandlerLogics(IEnumerable<IProcessSocialMediaData> processSocialMediaData, IJobApplicationService jobApplicationService)
        {
            _processSocialMediaData = processSocialMediaData;
            _jobApplicationService = jobApplicationService;
        }

        public SocialMediaProcessedResponse ProcessSocialHandlerData(string data, string state, Stream stream)
        {
            foreach(var item in _processSocialMediaData)
            {
                var result = item.ProcessData(data, state, stream);
                if (result != null && result.Success)
                    return result;
                    
            }

            return null;
        }
    }
}
