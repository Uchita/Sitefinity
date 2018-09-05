using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics
{
    public interface IBaseRequest
    {
    }

    public interface IBaseResponse
    {
        bool Success { get; set; }
        List<string> Errors { get; set; }
    }
}
