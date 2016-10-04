using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPosterTransform.Library.Common;
using System.Web.Mvc;

namespace JXTPosterTransform.Website.Models
{
    public class PTDisplayModel
    {
        public int PosterTransformId { get; set; }
        public string PosterTransformName { get; set; }
        public string PosterTransformDescription { get; set; }
        public PTCommonEnums.PosterTransform.Valid Valid { get; set; }

        [AllowHtml]
        public string PosterTransformXSL { get; set; }
        [AllowHtml]
        public string TestXML { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}