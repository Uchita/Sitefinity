using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Common.Models
{
    public interface IRequestSession
    {
        string Domain { get; }
        string UserEmail { get; }
    }
}
