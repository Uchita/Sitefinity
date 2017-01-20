using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using JXTPortal.Common;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class SiteProcessor : ImageProcessor<SitesEntity>
    {
        ISitesRepository _sitesRepository;
        public SiteProcessor(ISitesRepository sitesRepository)
        {
            _sitesRepository = sitesRepository;
        }

        public override string Type { get { return "Site"; } }

        public override int Priority { get { return 10; } }

        public override string Folder
        {
            get { return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"]); }
        }
        
        public override IEnumerable<SitesEntity> GetEntitiesToUpdate(int? batchSize)
        {
            //Only migrate sites that have a logo, but not one that has already been migrated
            IEnumerable<SitesEntity> sites = _sitesRepository.SelectAll()
                                                            .Where(site => site.SiteAdminLogo != null && site.SiteAdminLogo.Length > 0 && string.IsNullOrEmpty(site.SiteAdminLogoUrl));

            if (batchSize.HasValue)
            {
                sites = sites.Take(batchSize.Value);
            }
            return sites;
        }

        public override byte[] GetBinaryData(SitesEntity entity)
        {
            return entity.SiteAdminLogo;
        }

        public override int GetId(SitesEntity entity)
        {
            return entity.SiteID;
        }

        public override void UpdateEntity(SitesEntity entity, string filename)
        {
            entity.SiteAdminLogoUrl = filename;
            _sitesRepository.Update(entity);            
        }
    }
}