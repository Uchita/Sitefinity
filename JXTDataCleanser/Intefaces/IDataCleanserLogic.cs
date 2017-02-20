using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTDataCleanser.Models;

namespace JXTDataCleanser.Intefaces
{
    public interface IDataCleanserLogic
    {
        bool CanHandle(string[] args);
        void Process(string[] args);
    }
}