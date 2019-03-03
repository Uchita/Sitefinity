using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{

    public interface IMemberGetByIdRequest
    {
        MemberModel Member { get; set; }
    }


    public interface IMemberGetByIdResponse
    {
        MemberModel Member { get; set; }
    }
}
