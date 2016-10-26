	

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
	/// An component type implementation of the 'AvailableStatus' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AvailableStatusService : JXTPortal.AvailableStatusServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AvailableStatusService class.
		/// </summary>
		public AvailableStatusService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<AvailableStatus> GetTranslatedAvailableStatus(int languageID)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_AVAILABLESTATUS_FILENAME);

            //return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "AvailableStatusID", "AvailableStatusName", url);

            TList<AvailableStatus> availableStatus = GetAll();
            availableStatus.Filter = "GlobalTemplate = True";

            return XMLLanguageService.Translate(availableStatus.ToList(), "AvailableStatusId", "AvailableStatusName", url);

        }

        public List<AvailableStatus> GetTranslatedSiteAvailableStatus()
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_AVAILABLESTATUS_FILENAME);

            return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "AvailableStatusParentId", "AvailableStatusName", url);

        }

        #endregion

    }//End Class

} // end namespace
