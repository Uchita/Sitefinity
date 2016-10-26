	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Linq;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Configuration;
using System.Collections.Generic;
using JXTPortal.Common;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Profession' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ProfessionService : JXTPortal.ProfessionServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ProfessionService class.
		/// </summary>
		public ProfessionService() : base()
		{
		}

        #endregion Constructors

        #region "Constants"
        #endregion

        #region "Methods"

        public List<Profession> GetTranslatedProfessions(int languageID, bool isCustom)
        {
            string url = GetXMLUrl(languageID, isCustom);
            TList<Entities.Profession> professions = new TList<Profession>();
            if (isCustom)
            {
                professions = GetByReferredSiteId(SessionData.Site.SiteId);
            }
            else
            {
                professions = GetAll();
            }

            return XMLLanguageService.Translate(professions.ToList(), "ProfessionId", "ProfessionName", url);
        }

        public Profession GetTranslatedProfession(int professionID, int languageID, bool isCustom)
        {
            string url = GetXMLUrl(languageID, isCustom);

            return XMLLanguageService.Translate(GetByProfessionId(professionID), "ProfessionId", "ProfessionName", url);

        }

        public string GetTranslatedStringProfession(int professionID, int languageID, bool isCustom)
        {
            string url = GetXMLUrl(languageID, isCustom);
            return XMLLanguageService.TranslateString(professionID, "ProfessionId", "ProfessionName", url);
        }

        private string GetXMLUrl(int languageid, bool isCustom)
        {
            if (isCustom)
            {
                string xmlprefix = "{0}{2}_{3}_{1}.xml";

                string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        Convert.ToInt32(languageid),
                                        PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, SessionData.Site.SiteId);

                return url;
            }
            else
            {
                string xmlprefix = "{0}{2}_{1}.xml";
                string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageid,
                                        PortalConstants.XMLTranslationFiles.XML_PROFESSION_FILENAME);

                return url;
            }
             
        }

        #endregion

        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public List<Profession> GetTranslatedProfessions(int languageID, int siteID, string xmlFilesPath, bool isCustom)
        {
            string url = GetXMLUrl(languageID, isCustom, xmlFilesPath);
            TList<Entities.Profession> professions = new TList<Profession>();
            if (isCustom)
            {
                professions = GetByReferredSiteId(siteID);
            }
            else
            {
                professions = GetAll();
            }

            return XMLLanguageService.Translate(professions.ToList(), "ProfessionId", "ProfessionName", url);
        }


        private string GetXMLUrl(int languageid, bool isCustom, string xmlFilesPath)
        {
            if (isCustom)
            {
                string xmlprefix = "{0}{2}_{3}_{1}.xml";

                string url = string.Format(xmlprefix,
                                        xmlFilesPath,
                                        Convert.ToInt32(languageid),
                                        PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, SessionData.Site.SiteId);

                return url;
            }
            else
            {
                string xmlprefix = "{0}{2}_{1}.xml";
                string url = string.Format(xmlprefix,
                                        xmlFilesPath,
                                        languageid,
                                        PortalConstants.XMLTranslationFiles.XML_PROFESSION_FILENAME);

                return url;
            }

        }

        #endregion


	}//End Class

} // end namespace
