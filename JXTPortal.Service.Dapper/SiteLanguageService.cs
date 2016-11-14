using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Entities.Site;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Factories;
using JXTPortal.Service.Dapper.Models;

namespace JXTPortal.Service.Dapper
{
    public interface ISiteLanguageService
    {
        SiteLanguages GetBySiteID(int siteID);
    }

    public class SiteLanguageService : ISiteLanguageService
    {
        ISiteLanguageRepository _siteLanguageRepository;

        public SiteLanguageService(ISiteLanguageRepository siteLanguageRepository)
        {
            _siteLanguageRepository = siteLanguageRepository;
        }


        public SiteLanguages GetBySiteID(int siteID)
        {
            List<SiteLanguageEntity> siteLangs = _siteLanguageRepository.SelectBySiteID(siteID);

            SiteLanguages returnModel = new SiteLanguages { SiteID = siteID };

            if (siteLangs != null)
                returnModel.Languages = siteLangs.Select(c => new SiteLanguageDetails { SiteLanguageID = c.SiteLanguageID, LanguageID = c.LanguageID, SiteLanguageName = c.SiteLanguageName, ResourceFileName = c.ResourceFileName }).ToList();

            return returnModel;
        }

    }
}
