using System.Collections.Generic;

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
            ResponseClassFtpItemList = new List<ResponseClassFtpItem>();
        }

        public bool blnSuccess { get; set; }
        public string strMessage { get; set; }
        public string FullFilePath { get; set; }
        public string ResponseXML { get; set; }
        public List<ResponseClassFtpItem> ResponseClassFtpItemList { get; set; }
    }

    public class ResponseClassFtpItem
    {
        public ResponseClassFtpItem()
        {
            FullFilePath = string.Empty;
            ResponseXML = string.Empty;
        }

        public string FullFilePath { get; set; }
        public string ResponseXML { get; set; }
    }
}
