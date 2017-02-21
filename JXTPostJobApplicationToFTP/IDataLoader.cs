using System;
using System.Collections.Generic;
namespace JXTPostJobApplicationToFTP
{
    public interface IDataLoader
    {
        IEnumerable<int> GetMemberIds(string fileName);
    }
}
