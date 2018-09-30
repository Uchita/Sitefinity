using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class ProcessSeekData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessSeekData()
        {

        }

        // Interface method
        public (string, bool) ProcessData(string data)
        {
            return (null, false);
        }
    }
}
