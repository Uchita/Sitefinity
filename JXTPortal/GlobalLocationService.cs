	

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
	/// An component type implementation of the 'GlobalLocation' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class GlobalLocationService : JXTPortal.GlobalLocationServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the GlobalLocationService class.
		/// </summary>
		public GlobalLocationService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"


        public List<GlobalLocation> GetTranslatedLocations(int countryId)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, countryId);
            return XMLLanguageService.Translate(GetByCountryId(countryId).ToList(), "LocationId", "LocationName", url);
        }

        public GlobalLocation GetTranslatedLocationById(int locationID, int countryId)
        {
            string xmlprefix = "{0}{2}_{1}_{3}.xml";
            string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, countryId);

            List<GlobalLocation> list = new List<GlobalLocation>();
            list.Add(GetByLocationId(locationID));
            return XMLLanguageService.Translate(list, "LocationId", "LocationName", url)[0];
        }

        #endregion
		
	}//End Class

} // end namespace
