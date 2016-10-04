using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPosterTransform.Library.Common
{
    public class ResponseClass
    {
        public ResponseClass()
        {
            blnSuccess = false;
            strMessage = string.Empty;
            FullFilePath = string.Empty;
            ResponseXML = string.Empty;
        }

        public bool blnSuccess { get; set; }
        public string strMessage { get; set; }
        public string FullFilePath { get; set; }
        public string ResponseXML { get; set; }
    }
}
