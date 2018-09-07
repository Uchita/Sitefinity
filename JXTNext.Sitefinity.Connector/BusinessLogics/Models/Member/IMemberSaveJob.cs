using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public interface IMemberSaveJob
    {
        int JobId { get; set; }
    }

    public interface IMemberSaveJobResponse
    {
        int? SavedJobId { get; set; }
        bool Success { get; set; }
        List<string> Errors { get; set; }
    }
}
