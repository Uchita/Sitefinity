using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public class ProcessIndeedData : IProcessSocialMediaData
    {
        // Constructor
        public ProcessIndeedData()
        {

        }

        // Interface method
        public (string, bool) ProcessData(string data)
        {
            return (null, true);
        }
    }
}
