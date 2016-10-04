using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Data;

namespace JXTPosterTransform.Library.Services
{
    public class ClientSetupLogService : IDisposable  
    {
        private PosterTransformEntities _context = new PosterTransformEntities();

        public bool CreateClientSetupLog(GetAllClientSetupsToRun_Result clientSetup, string RawXMLPath, string RequestXMLPath, string ResponseXMLPath, DateTime CreatedDate)
        {

            ClientSetupLog thisClient = new ClientSetupLog();

            thisClient.ClientId = clientSetup.ClientId;
            thisClient.ClientSetupId = clientSetup.ClientSetupId;
            thisClient.PosterTransformId = clientSetup.PosterTransformId.HasValue ? clientSetup.PosterTransformId.Value : 0;
            thisClient.FinishedDate = DateTime.Now;
            thisClient.CreatedDate = CreatedDate;
            thisClient.Failed = 0;

            thisClient.RawData = RawXMLPath;
            thisClient.RequestData = RequestXMLPath;
            thisClient.ResponseData = ResponseXMLPath;

            _context.ClientSetupLogs.AddObject(thisClient);
            _context.SaveChanges();

            return true;

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
