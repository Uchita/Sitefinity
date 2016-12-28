using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Common;

namespace JXTMoveImageToFTP
{
    public interface IProcessor
    {
        int Priority { get; }
        void Begin(IFtpClient ftpClient);
    }
}