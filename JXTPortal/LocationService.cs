	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using System.Xml.Serialization;
using System.Data;

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
	/// An component type implementation of the 'Location' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class LocationService : JXTPortal.LocationServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the LocationService class.
		/// </summary>
		public LocationService() : base()
		{
		}
		#endregion Constructors

        #region "Constants"
        const string xmlprefix = "{0}{2}_{1}_{3}.xml";
        #endregion

        #region "Methods"

        public List<Location> GetTranslatedLocations(int languageID, int countryID)
        {
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, countryID);
            return XMLLanguageService.Translate(GetByCountryId(countryID).ToList(), "LocationId", "LocationName", url);            
        }

        public Location GetTranslatedLocation(int locationID, int languageID)
        {
            Location loc = GetByLocationId(locationID);

            string url = string.Format(xmlprefix,
                                      ConfigurationManager.AppSettings["XMLFilesPath"],
                                      languageID,
                                      PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, loc.CountryId);
            return XMLLanguageService.Translate(loc, "LocationId", "LocationName", url);

        }

        public string GetTranslatedStringLocation(int locationID, int languageID)
        {
            Location loc = GetByLocationId(locationID);
            string url = string.Format(xmlprefix,
                                          ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, loc.CountryId);
            return XMLLanguageService.TranslateString(locationID, "LocationId", "LocationName", url);
        }
        #endregion



        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public List<Location> GetTranslatedLocations(int languageID, List<int> countryIDs, string xmlFilesPath)
        {
            List<Location> fullLocationList = new List<Location>();

            foreach (int countryID in countryIDs)
            {
                string url = string.Format(xmlprefix,
                                xmlFilesPath,
                                languageID,
                                PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, countryID);

                fullLocationList.AddRange(XMLLanguageService.Translate(GetByCountryId(countryID).ToList(), "LocationId", "LocationName", url));
            }

            return fullLocationList;
        }


        #endregion

	}//End Class

} // end namespace
