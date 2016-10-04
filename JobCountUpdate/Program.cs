using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;

namespace JobCountUpdate
{
    class Program
    {
        #region Declaration

        private static SitesService _siteService = null;
        private static JobsService _jobService = null;

        #endregion

        #region Properties

        private static SitesService SitesService
        {
            get {
                if (_siteService == null)
                    _siteService = new SitesService();

                return _siteService; 
            
            }
        }

        private static JobsService JobsService
        {
            get
            {
                if (_jobService == null)
                    _jobService = new JobsService();

                return _jobService;

            }
        }

        #endregion

        static void Main(string[] args)
        {
            try
            {
                using (TList<Sites> sites = SitesService.Get_List())
                {
                    foreach (Sites site in sites)
                    {
                        Console.WriteLine("Updating {0}", site.SiteName);
                        JobsService.CustomUpdateSiteJobCount(site.SiteId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
