using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class SocialHandlerLogics
    {
        IEnumerable<IProcessSocialMediaData> _processSocialMediaData;
        public SocialHandlerLogics(IEnumerable<IProcessSocialMediaData> processSocialMediaData)
        {
            _processSocialMediaData = processSocialMediaData;
        }

        public string ProcessSocialHandlerData(string data)
        {
            foreach(var item in _processSocialMediaData)
            {
                (string result, bool isProcessed) = item.ProcessData(data);
                if(isProcessed)
                    return result;
            }

            return null;
        }
    }
}
