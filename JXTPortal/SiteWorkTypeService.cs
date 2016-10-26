	

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
using JXTPortal.Common;
using System.Configuration;
using System.Collections.Generic;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'SiteWorkType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteWorkTypeService : JXTPortal.SiteWorkTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeService class.
		/// </summary>
		public SiteWorkTypeService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<SiteWorkType> GetTranslatedWorkTypes()
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);
            return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "WorkTypeId", "SiteWorkTypeName", url);
        }


        public SiteWorkType GetTranslatedWorkTypesById(int worktypeid)
        {
            return GetTranslatedWorkTypesById(worktypeid, SessionData.Language.LanguageId);
        }

        public SiteWorkType GetTranslatedWorkTypesById(int worktypeid, int languageid)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageid,
                                        PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);

            List<SiteWorkType> list = new List<SiteWorkType>();
            TList<SiteWorkType> swt = GetBySiteId(SessionData.Site.SiteId);
            swt.Filter = "WorkTypeID = " + worktypeid.ToString();
            list.Add(swt[0]);

            return XMLLanguageService.Translate(list, "WorkTypeId", "SiteWorkTypeName", url)[0];
        }
        #endregion


        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public List<SiteWorkType> GetTranslatedWorkTypes(int languageID, int siteID, string xmlFilesPath)
        {
            List<SiteWorkType> siteWorkTypeList = new List<SiteWorkType>();

            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        xmlFilesPath,
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);

            return XMLLanguageService.Translate(GetBySiteId(siteID).ToList(), "WorkTypeId", "SiteWorkTypeName", url);            
        }

        #endregion



	}//End Class

} // end namespace
