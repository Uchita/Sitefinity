using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Logics
{
    public interface IProcessSocialMediaData
    {
        SocialMediaProcessedResponse ProcessData(string data, string state, string indeedData);
    }
}
