

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Common;

#endregion

namespace JXTPortal
{
    /// <summary>
    /// An component type implementation of the 'SiteRoles' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class SiteRolesService : JXTPortal.SiteRolesServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SiteRolesService class.
        /// </summary>
        public SiteRolesService()
            : base()
        {
        }
        #endregion Constructors

        #region "Methods"
        /// <summary>
        /// Default Method of getting Translated Roles, put false if you want to show professions with total jobs
        /// </summary>
        /// <param name="professionid"></param>
        /// <returns></returns>
        public List<SiteRoles> GetTranslatedByProfessionID(int professionID, bool isCustom)
        {
            return GetTranslatedByProfessionID(professionID, true, isCustom);
        }

        public List<SiteRoles> GetTranslatedByProfessionID(int professionID, bool showAllJobs, bool isCustom)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix, 
                                        ConfigurationManager.AppSettings["XMLFilesPath"], 
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_ROLE_FILENAME, professionID);

            if (isCustom)
            {
                xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";
                url = string.Format(xmlprefix,
                                            ConfigurationManager.AppSettings["XMLFilesPath"],
                                            SessionData.Language.LanguageId,
                                            PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, professionID, SessionData.Site.SiteId);
            }

            List<SiteRoles> list = GetByProfessionID(SessionData.Site.SiteId, professionID).ToList();

            if (!showAllJobs)
            {
                list = list.Where(l => l.TotalJobs > 0).ToList();
            }

            return XMLLanguageService.Translate(list, "RoleId", "SiteRoleName", url);
        }

        public SiteRoles GetTranslatedRolesById(int roleID, int professionID, bool isCustom)
        {
            return GetTranslatedRolesById(roleID, professionID, SessionData.Language.LanguageId, true, isCustom);
        }

        public SiteRoles GetTranslatedRolesById(int roleID, int professionID, int languageId, bool isCustom)
        {
            return GetTranslatedRolesById(roleID, professionID, languageId, true, isCustom);
        }

        public SiteRoles GetTranslatedRolesById(int roleID, int professionID, bool showAllJobs, bool isCustom)
        {
            return GetTranslatedRolesById(roleID, professionID, SessionData.Language.LanguageId, showAllJobs, isCustom);
        }

        public SiteRoles GetTranslatedRolesById(int roleID, int professionID, int languageId, bool showAllJobs, bool isCustom)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageId,
                                        PortalConstants.XMLTranslationFiles.XML_ROLE_FILENAME, professionID);

            if (isCustom)
            {
                xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";
                url = string.Format(xmlprefix,
                                            ConfigurationManager.AppSettings["XMLFilesPath"],
                                            SessionData.Language.LanguageId,
                                            PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, professionID, SessionData.Site.SiteId);
            }

            List<SiteRoles> list = new List<SiteRoles>();

            // Todo
            TList<SiteRoles> sr = GetBySiteIdRoleId(SessionData.Site.SiteId, roleID);
            
            if (sr != null && sr.Count > 0)
            {
                // remove try catches.
                try
                {

                    list.Add(sr[0]);

                    if (!showAllJobs)
                    {
                        list = list.Where(l => l.TotalJobs > 0).ToList();
                    }
                }
                catch
                {
                    throw new Exception(string.Format("Role - {0} {1} {2}", roleID, professionID, url));
                }

                try
                {
                    return XMLLanguageService.Translate(list, "RoleId", "SiteRoleName", url)[0];
                }
                catch
                {
                    throw new Exception(string.Format("Role translation - {0} {1} {2}", roleID, professionID, url));
                }
            }

            return new SiteRoles();
        }

        /// <summary>
        /// This is used to return all SiteRoles with active jobs
        /// </summary>
        /// <param name="SiteProfessionID"></param>
        /// <returns></returns>
        public List<SiteRoles> GetByProfessionIDWithActiveJobs(int SiteID, int ProfessionID)
        {
            return GetByProfessionID(SiteID, ProfessionID).Where(l => l.TotalJobs > 0).ToList();
        }

        #endregion


    }//End Class

} // end namespace
