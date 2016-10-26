	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Configuration;
using System.Linq;
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
	/// An component type implementation of the 'Roles' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class RolesService : JXTPortal.RolesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the RolesService class.
		/// </summary>
		public RolesService() : base()
		{
		}
		#endregion Constructors

        #region "Constants"
        const string xmlprefix = "{0}{2}_{1}_{3}.xml";
        #endregion

        #region "Methods"

        public List<Roles> GetTranslatedRoles(int professionID, int languageID, bool isCustom)
        {
            string url = GetXMLUrl(languageID, professionID, isCustom);

            return XMLLanguageService.Translate(GetByProfessionId(professionID).ToList(), "RoleId", "RoleName", url);
        }

        public Roles GetTranslatedRole(int roleID, int languageID, bool isCustom)
        {
            Roles role = GetByRoleId(roleID);
            string url = GetXMLUrl(languageID, role.ProfessionId, isCustom);
            return XMLLanguageService.Translate(role, "RoleId", "RoleName", url);

        }

        public string GetTranslatedStringRole(int roleID, int languageID, bool isCustom)
        {
            Roles role = GetByRoleId(roleID);

            string url = GetXMLUrl(languageID, role.ProfessionId, isCustom);
            return XMLLanguageService.TranslateString(roleID, "RoleId", "RoleName", url);
        }


        private string GetXMLUrl(int languageid, int professionid, bool isCustom)
        {
            if (isCustom)
            {
                string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";

                string url = string.Format(xmlprefix,
                                         ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageid,
                                         PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, professionid, SessionData.Site.SiteId);

                return url;

            }
            else
            {
                string xmlprefix = "{0}{2}_{1}_{3}.xml";
                string url = string.Format(xmlprefix,
                                       ConfigurationManager.AppSettings["XMLFilesPath"],
                                       languageid,
                                       PortalConstants.XMLTranslationFiles.XML_ROLE_FILENAME, professionid);

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
        public List<Roles> GetTranslatedRoles(int languageID, List<int> professionIDs, string xmlFilesPath, bool isCustom)
        {
            List<Roles> fullRoleList = new List<Roles>();

            foreach(int pID in professionIDs)
            {

                string url = GetXMLUrl(languageID, pID, isCustom, xmlFilesPath);

                fullRoleList.AddRange( XMLLanguageService.Translate(GetByProfessionId(pID).ToList(), "RoleId", "RoleName", url));
            }
            
            return fullRoleList;
        }



        private string GetXMLUrl(int languageid, int professionid, bool isCustom, string xmlFilesPath)
        {
            if (isCustom)
            {
                string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";

                string url = string.Format(xmlprefix,
                                         xmlFilesPath,
                                          languageid,
                                         PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, professionid, SessionData.Site.SiteId);

                return url;

            }
            else
            {
                string xmlprefix = "{0}{2}_{1}_{3}.xml";
                string url = string.Format(xmlprefix,
                                       xmlFilesPath,
                                       languageid,
                                       PortalConstants.XMLTranslationFiles.XML_ROLE_FILENAME, professionid);

                return url;
            }

        }

        #endregion


	}//End Class

} // end namespace
