	

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

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'GlobalArea' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class GlobalAreaService : JXTPortal.GlobalAreaServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the GlobalAreaService class.
		/// </summary>
		public GlobalAreaService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<GlobalArea> GetTranslatedAreas(int locationID)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, locationID);
            return XMLLanguageService.Translate(GetByLocationId(locationID).ToList(), "AreaId", "AreaName", url);
            //ToDo - Use GetByLocationID(SessionData.Site.SiteId, locationID)
        }

        public GlobalArea GetTranslatedAreaById(int areaID, int locationID)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, locationID);

            List<GlobalArea> list = new List<GlobalArea>();
            list.Add(GetByAreaId(areaID));
            return XMLLanguageService.Translate(list, "AreaId", "AreaName", url)[0];
        }

        #endregion
    }//End Class

} // end namespace
