

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Collections.Generic;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Common;

#endregion

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'SiteProfession' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class SiteProfessionService : JXTPortal.SiteProfessionServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SiteProfessionService class.
        /// </summary>
        public SiteProfessionService()
            : base()
        {

        }
        #endregion Constructors

        #region "Methods"

        /// <summary>
        /// Default Method of getting Translated Professions, put false if you want to show professions with total jobs
        /// </summary>
        /// <returns></returns>
        public List<SiteProfession> GetTranslatedProfessions(int siteID, bool isCustom)
        {
            return GetTranslatedProfessions(siteID, true, isCustom);
        }

        public List<SiteProfession> GetTranslatedProfessions(int siteID, bool showAllJobs, bool isCustom)
        {
            string xmlprefix = string.Empty;
            string url = string.Empty;
            List<SiteProfession> list = null;

            if (isCustom)
            {
                xmlprefix = "{0}{2}_{3}_{1}.xml";
                url = string.Format(xmlprefix,
                                            ConfigurationManager.AppSettings["XMLFilesPath"],
                                            SessionData.Language.LanguageId,
                                            PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, siteID);
            }
            else
            {
                xmlprefix = "{0}{2}_{1}.xml";
                url = string.Format(xmlprefix,
                                                ConfigurationManager.AppSettings["XMLFilesPath"],
                                                SessionData.Language.LanguageId,
                                                PortalConstants.XMLTranslationFiles.XML_PROFESSION_FILENAME);
            }

            if (showAllJobs)
                list = GetBySiteId(siteID).ToList();
            else
                list = GetBySiteId(siteID).Where(s => s.TotalJobs > 0).ToList();

            return XMLLanguageService.Translate(list, "ProfessionId", "SiteProfessionName", url);
        }

        public SiteProfession GetTranslatedProfessionById(int professionID, bool isCustom)
        {
            return GetTranslatedProfessionById(professionID, true, isCustom);
        }

        public SiteProfession GetTranslatedProfessionById(int professionID, bool showAllJobs, bool isCustom)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_PROFESSION_FILENAME);
            if (isCustom)
            {
                xmlprefix = "{0}{2}_{3}_{1}.xml";
                url = string.Format(xmlprefix,
                                            ConfigurationManager.AppSettings["XMLFilesPath"],
                                            SessionData.Language.LanguageId,
                                            PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, SessionData.Site.SiteId);
            }


            List<SiteProfession> list = new List<SiteProfession>();

            // Todo
            TList<SiteProfession> sp = CustomGetBySiteIDProfessionID(SessionData.Site.SiteId, professionID);

            if (sp.Count > 0)
            {
                list.Add(sp[0]);

                if (!showAllJobs)
                {
                    list = GetBySiteId(SessionData.Site.SiteId).Where(s => s.TotalJobs > 0).ToList();
                }

                return XMLLanguageService.Translate(list, "ProfessionId", "SiteProfessionName", url)[0];
            }
            else
                return null;
        }

        /// <summary>
        /// Get all professions with the active jobs
        /// </summary>
        /// <param name="WhitelabelID"></param>
        /// <returns></returns>
        public List<SiteProfession> GetBySiteIDWithActiveJobs(int WhitelabelID)
        {
            return GetBySiteId(SessionData.Site.SiteId).Where(s => s.TotalJobs > 0).ToList();
        }

        #endregion
    }//End Class

} // end namespace
