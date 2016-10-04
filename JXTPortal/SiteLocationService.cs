	

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
using System.Collections.Generic;
using JXTPortal.Common;
using System.Configuration;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'SiteLocation' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteLocationService : JXTPortal.SiteLocationServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteLocationService class.
		/// </summary>
		public SiteLocationService() : base()
		{
		}
		#endregion Constructors


        #region "Methods"


        const string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";


        public List<SiteLocation> GetTranslatedLocationsByCountryID(int countryID)
        {
            return GetTranslatedLocationsByCountryID(countryID, SessionData.Language.LanguageId);
        }
        public List<SiteLocation> GetTranslatedLocationsByCountryID(int countryID, int languageID)
        {
            string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_SITELOCATION_FILENAME, countryID, SessionData.Site.SiteId);
            
            return XMLLanguageService.Translate( GetByCountryID(SessionData.Site.SiteId, countryID).ToList(), "LocationId", "SiteLocationName", url);
        }


        public SiteLocation GetTranslatedLocation(int locationID, int CountryID)
        {
            return GetTranslatedLocation(locationID, CountryID, SessionData.Language.LanguageId);
        }

        public SiteLocation GetTranslatedLocation(int locationID, int CountryID, int languageID)
        {
            SiteLocation loc = null;
            TList<SiteLocation> siteloc = GetByLocationId(locationID);
            siteloc.Filter = "SiteId = " + SessionData.Site.SiteId;

            if (siteloc.Count > 0)
            {
                loc = siteloc[0];

                string url = string.Format(xmlprefix,
                                          System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_SITELOCATION_FILENAME, CountryID, SessionData.Site.SiteId);
                return XMLLanguageService.Translate(loc, "LocationId", "SiteLocationName", url);
            }
            else
            {
                return null;
            }
        }

        #endregion

	}//End Class

} // end namespace
