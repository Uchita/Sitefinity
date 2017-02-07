using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities.Custom
{
    public class SequenceAttribute : System.Attribute
    {
        private int _SequenceNumber = 0;

        public int SequenceNumber { get { return _SequenceNumber; } }

        public SequenceAttribute(int seqNumber)
        {
            this._SequenceNumber = seqNumber;
        }

    }
}
