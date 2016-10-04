using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Data;

namespace JXTPosterTransform.Library.Services
{
    public class PT_PosterTransformService : IDisposable    
    {
        private PosterTransformEntities _context = new PosterTransformEntities();

        public List<PosterTransform> PosterTransformAllGet()
        {
            List<PosterTransform> pts = (from m in _context.PosterTransforms select m).ToList();

            return pts;
        }

        public PosterTransform PosterTransformGetByID(int ptID)
        {
            PosterTransform pt = (from m in _context.PosterTransforms where m.PosterTransformId == ptID select m).FirstOrDefault();

            return pt;
        }

        public bool PosterTransformUpdate(int ptID, string name, string description, int valid, string XSL, string testXML, int modifiedBy)
        {
            PosterTransform pt = PosterTransformGetByID(ptID);

            if (pt != null)
            {
                pt.PosterTransformName = name;
                pt.PosterTransformDescription = description;
                pt.Valid = valid;
                pt.TestXML = testXML;
                pt.PosterTransformXSL = XSL;

                pt.LastModifiedDate = DateTime.Now;
                pt.LastModifiedBy = modifiedBy;

                _context.SaveChanges();

                return true;
            }

            return false;
        }


        #region IDisposable Members
        
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #endregion
    }
}
