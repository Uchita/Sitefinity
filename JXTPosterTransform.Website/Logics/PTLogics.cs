using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPosterTransform.Library.Services;
using JXTPosterTransform.Data;
using JXTPosterTransform.Website.Models;
using JXTPosterTransform.Library.Common;

namespace JXTPosterTransform.Website.Logics
{
    public class PTLogics
    {

        #region Services Connections

        private PT_PosterTransformService _ptPosterTransformService;
        private PT_PosterTransformService PTPosterTransformService
        {
            get
            {
                if (_ptPosterTransformService == null)
                    _ptPosterTransformService = new PT_PosterTransformService();
                return _ptPosterTransformService;
            }
        }

        #endregion


        public List<PTDisplayModel> PosterTransformsListingGet()
        {
            List<PosterTransform> ptList = PTPosterTransformService.PosterTransformAllGet();

            return (from m in ptList
                    select new PTDisplayModel
                    {
                        PosterTransformId = m.PosterTransformId,
                        PosterTransformName = m.PosterTransformName,
                        PosterTransformDescription = m.PosterTransformDescription,
                        Valid = (PTCommonEnums.PosterTransform.Valid)m.Valid,
                        PosterTransformXSL = m.PosterTransformXSL,
                        TestXML = m.TestXML,
                        CreatedDate = m.CreatedDate,
                        LastModifiedBy = m.LastModifiedBy,
                        LastModifiedDate = m.LastModifiedDate
                    }).ToList();
        }

        public PTDisplayModel PosterTransformGet(int id)
        {
            PosterTransform thisPT = PTPosterTransformService.PosterTransformGetByID(id);

            return new PTDisplayModel
                    {
                        PosterTransformId = thisPT.PosterTransformId,
                        PosterTransformName = thisPT.PosterTransformName,
                        PosterTransformDescription = thisPT.PosterTransformDescription,
                        Valid = (PTCommonEnums.PosterTransform.Valid)thisPT.Valid,
                        PosterTransformXSL = thisPT.PosterTransformXSL,
                        TestXML = thisPT.TestXML,
                        CreatedDate = thisPT.CreatedDate,
                        LastModifiedBy = thisPT.LastModifiedBy,
                        LastModifiedDate = thisPT.LastModifiedDate
                    };
        }

        public bool PosterTransformUpdate(PTDisplayModel ptDetails)
        {
            bool updatePosterTransformSuccess = PTPosterTransformService.PosterTransformUpdate(ptDetails.PosterTransformId, ptDetails.PosterTransformName, ptDetails.PosterTransformDescription,
                (int)ptDetails.Valid, ptDetails.PosterTransformXSL, ptDetails.TestXML, 0);

            return updatePosterTransformSuccess;
        }

    }
}