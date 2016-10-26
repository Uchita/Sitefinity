	

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
	/// An component type implementation of the 'WorkType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class WorkTypeService : JXTPortal.WorkTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the WorkTypeService class.
		/// </summary>
		public WorkTypeService() : base()
		{
		}
		#endregion Constructors

        #region "Constants"
        const string xmlprefix = "{0}{2}_{1}.xml";
        #endregion

        #region "Methods"

        public List<WorkType> GetTranslatedWorkTypes(int languageID)
        {
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);
            return XMLLanguageService.Translate(GetAll().ToList(), "WorkTypeId", "WorkTypeName", url);
        }

        public WorkType GetTranslatedWorkType(int workTypeID, int languageID)
        {
            string url = string.Format(xmlprefix,
                                      ConfigurationManager.AppSettings["XMLFilesPath"],
                                      languageID,
                                      PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);
            return XMLLanguageService.Translate(GetByWorkTypeId(workTypeID), "WorkTypeId", "WorkTypeName", url);

        }

        public string GetTranslatedStringWorkType(int workTypeID, int languageID)
        {
            string url = string.Format(xmlprefix,
                                          ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);
            return XMLLanguageService.TranslateString(workTypeID, "WorkTypeId", "WorkTypeName", url);
        }
        #endregion




	}//End Class

} // end namespace
